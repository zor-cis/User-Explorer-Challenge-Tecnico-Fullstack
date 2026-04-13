import { User } from "../types/User";

type Props = {
    users: User[];
    loading: boolean;
    error: string | null;
};

export default function UserList({ users, loading, error }: Props) {
    if (loading) return <p className="text-center">Cargando...</p>;
    if (error) return <p className="text-center text-red-500">{error}</p>;
    if (users.length === 0) return <p className="text-center">No hay usuarios</p>;

    return (
        <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
            {users.map((user) => (
                <div
                    key={user.id}
                    className="bg-white p-4 rounded-2xl shadow-md hover:shadow-xl hover:scale-[1.02] transition-all duration-200"
                >
                    <h3 className="text-lg font-semibold text-gray-800 mb-2">
                        {user.name}
                    </h3>

                    <p className="text-sm text-gray-600">{user.email}</p>
                    <p className="text-sm text-gray-600">{user.phone}</p>

                    <div className="mt-3 text-sm">
                        <p className="text-gray-500">
                            {user.company}
                        </p>
                        <p className="text-gray-500">
                            📍 {user.city}
                        </p>
                    </div>
                </div>
            ))}
        </div>
    );
}