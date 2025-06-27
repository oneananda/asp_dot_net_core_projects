import { Link } from 'react-router-dom';

export default function Sidebar() {
    return (
        <div className="w-64 h-screen bg-gray-800 text-white p-4">
            <h2 className="text-2xl mb-6">CMS Admin</h2>
            <ul className="space-y-2">
                <li><Link to="/" className="hover:underline">Dashboard</Link></li>
                <li><Link to="/content/blog" className="hover:underline">Blog Posts</Link></li>
                <li><Link to="/media" className="hover:underline">Media Manager</Link></li>
            </ul>
        </div>
    );
}
