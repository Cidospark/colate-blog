using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.IdentityDTO.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = "";
        public UserResponse? User { get; set; }
        public List<string> Roles { get; set; } = [];
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
