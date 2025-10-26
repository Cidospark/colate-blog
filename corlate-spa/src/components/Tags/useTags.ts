// useTags.ts
import { useEffect, useRef, useState } from "react";
import axios from "axios";
//import { Base_URL } from "./Base_URL"; 

const BASE_URL = import.meta.env.VITE_API_URL || "http://localhost:5086";


export interface Tag {
    id?: number;
    name?: string;
  
    [k: string]: any;
}

interface UseTagsOptions {
    page?: number;
    size?: number;
    append?: boolean;
}


export function useTags({ page = 1, size = 10, append = false }: UseTagsOptions = {}) {
    const [items, setItems] = useState<Tag[]>([]);
    const [total, setTotal] = useState<number | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    // keep previous pages when append mode is used
    useEffect(() => {
        const controller = new AbortController();
        setLoading(true);
        setError(null);

        axios.get(`${BASE_URL}/api/Tags`, {
            params: { page, size },
            signal: controller.signal as unknown as AbortSignal // axios accepts signal in recent versions
        })
            .then(res => {
                const data = res.data as any;
                let arr: Tag[] = [];
                let tot: number | null = null;

                if (Array.isArray(data)) {
                    arr = data;
                } else if (data.items && Array.isArray(data.items)) {
                    arr = data.items;
                    tot = typeof data.total === "number" ? data.total : null;
                } else if (data.data && Array.isArray(data.data)) {
                    arr = data.data;
                } else {
                    const found = Object.values(data).find(v => Array.isArray(v));
                    arr = (found as Tag[]) || [];
                }

                setItems(prev => append ? [...prev, ...arr] : arr);
                if (tot !== null) setTotal(tot);
            })
            .catch(err => {
                if (axios.isCancel?.(err)) return; // fallback if Cancel used elsewhere
                if (err.name === "CanceledError" || err.message === "canceled") return;
                setError(err?.message ?? "Failed to fetch tags");
            })
            .finally(() => setLoading(false));

        return () => controller.abort();
    }, [page, size, append]);

    return { items, total, loading, error };
}
