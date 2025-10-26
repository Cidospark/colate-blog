using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.RepliesDTO;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;

        public ReplyService(IReplyRepository replyRepository, IMapper mapper)
        {
            _replyRepository = replyRepository;
            _mapper = mapper;
        }

        public async Task<ReplyResponse> AddAsync(ReplyRequest request)
        {
            var entity = _mapper.Map<ReplyTbl>(request);
            var created = await _replyRepository.AddAsync(entity);
            return _mapper.Map<ReplyResponse>(created);
        }

        public async Task<IEnumerable<ReplyResponse>> GetAllAsync(int page, int size)
        {
            var query = await _replyRepository.GetAllAsync(page, size);
            var list = query.ToList();
            return _mapper.Map<IEnumerable<ReplyResponse>>(list);
        }

        public async Task<ReplyResponse?> GetByIdAsync(string id)
        {
            var reply = await _replyRepository.GetByIdAsync(id);
            return reply == null ? null : _mapper.Map<ReplyResponse>(reply);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            // Check if reply exists
            var reply = await _replyRepository.GetByIdAsync(id);
            if (reply == null)
            {
                return false;
            }

            // Delete the reply
            var result = await _replyRepository.DeleteAsync(id);
            return result;
        }
    }
}