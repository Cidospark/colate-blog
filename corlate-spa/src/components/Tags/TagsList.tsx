// TagsList.tsx
import React, { useMemo, useState } from "react";
import "./TagCloud.css";
import { type Tag, useTags } from "./useTags";
import type { JSX } from "react/jsx-dev-runtime";

const DEFAULT_SIZE = 10; // keep in sync with your backend / swagger

export default function TagsList(): JSX.Element {
    // base page stays 1; appendedPages controls how many additional pages to fetch
    const [appendedPages, setAppendedPages] = useState<number>(0);
    const appendMode = appendedPages > 0;
    const size = DEFAULT_SIZE;

    const { items, total, loading, error } = useTags({
        page: appendMode ? appendedPages + 1 : 1,
        size,
        append: appendMode
    });

    const lastPage = useMemo<number | null>(() => {
        if (total == null) return null;
        return Math.max(1, Math.ceil(total / size));
    }, [total, size]);

    function handleShowMore() {
        setAppendedPages(n => n + 1);
    }

    return (
        <aside className="tagcloud-sidebar" aria-label="Tag Cloud sidebar">
            <div className="tagcloud-card">
                <h4 className="tagcloud-heading">Tag Cloud</h4>

                {loading && <div className="tagcloud-loading">Loading tags...</div>}
                {error && <div className="tagcloud-error">Error: {error}</div>}

                <div className="tagcloud-list">
                    {items && items.length === 0 && !loading ? (
                        <p className="tagcloud-no">No tags found.</p>
                    ) : (
                        items.map((tag: Tag) => {
                            const id = tag.id ?? tag.tagId ?? tag.Id ?? JSON.stringify(tag);
                            const label = tag.name ?? tag.title ?? tag.tag ?? JSON.stringify(tag);
                            return (
                                <button
                                    key={id}
                                    type="button"
                                    className="tagcloud-item"
                                    onClick={() => {
                                        /* replace with navigation or filter logic */
                                        console.log("Clicked tag:", label);
                                    }}
                                >
                                    {label}
                                </button>
                            );
                        })
                    )}
                </div>

                <div className="tagcloud-footer">
                    <button
                        className="tagcloud-seemore"
                        onClick={handleShowMore}
                        disabled={loading || (lastPage !== null && (1 + appendedPages) >= lastPage)}
                    >
                        See More
                    </button>

                    {total != null && (
                        <div className="tagcloud-total">
                            Total: <strong>{total}</strong>
                        </div>
                    )}
                </div>
            </div>
        </aside>
    );
}
