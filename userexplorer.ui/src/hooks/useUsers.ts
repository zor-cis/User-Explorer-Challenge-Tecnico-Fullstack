import { useEffect, useState } from "react";
import { searchUsers } from "../services/userService";
import { User } from "../types/User";

export const useUsers = () => {
    const [users, setUsers] = useState<User[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const [search, setSearch] = useState("");
    const [company, setCompany] = useState("");
    const [city, setCity] = useState("");

    const fetchUsers = async () => {
        try {
            setLoading(true);

            const data = await searchUsers(search, company, city);
            setUsers(data);

        } catch (err: unknown) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError("Error cargando usuarios");
            }
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchUsers();
    }, [search, company, city]);

    return {
        users,
        loading,
        error,

        search,
        setSearch,
        company,
        setCompany,
        city,
        setCity,

        refetch: fetchUsers
    };
};