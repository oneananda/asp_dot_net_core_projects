import { useEffect, useState } from 'react';
import { getContentByType } from '../services/api';

export default function ContentList({ type = "blog" }) {
    const [content, setContent] = useState([]);

    useEffect(() => {
        getContentByType(type).then(res => setContent(res.data));
    }, [type]);

    return (
        <div className="p-4">
            <h1 className="text-xl font-bold mb-4">{type} list</h1>
            <table className="w-full border">
                <thead>
                    <tr>
                        <th className="border p-2">Title</th>
                        <th className="border p-2">Updated</th>
                    </tr>
                </thead>
                <tbody>
                    {content.map(item => (
                        <tr key={item.id}>
                            <td className="border p-2">{item.title}</td>
                            <td className="border p-2">{new Date(item.updatedAt).toLocaleString()}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
