import UserForm from "../components/UserForm";
import UserList from "../components/UserList";
import { useUsers } from "../hooks/useUsers";

export default function UsersPage() {
    const {
        users,
        loading,
        error,
        refetch,
        search,
        setSearch,
        company,
        setCompany,
        city,
        setCity
    } = useUsers();

    return (
        <div className="min-h-screen bg-gradient-to-br from-gray-100 to-gray-200 py-8 px-4">
            <div className="max-w-6xl mx-auto">

                <h1 className="text-4xl font-bold text-center text-gray-800 mb-8">
                    User Explorer
                </h1>

                <div className="bg-white p-4 rounded-2xl shadow-md mb-6">
                    <div className="grid gap-3 md:grid-cols-3">
                        <input
                            placeholder="Buscar..."
                            value={search}
                            onChange={(e) => setSearch(e.target.value)}
                            className="border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                        />

                        <input
                            placeholder="Empresa..."
                            value={company}
                            onChange={(e) => setCompany(e.target.value)}
                            className="border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                        />

                        <input
                            placeholder="Ciudad..."
                            value={city}
                            onChange={(e) => setCity(e.target.value)}
                            className="border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                        />
                    </div>
                </div>

                <UserForm onUserCreated={refetch} />

                <UserList
                    users={users}
                    loading={loading}
                    error={error}
                />

            </div>
        </div>
    );
}