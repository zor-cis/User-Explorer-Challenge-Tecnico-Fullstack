import { useState } from "react";
import { createUser } from "../services/userService";
import { User } from "../types/User";

type Props = {
    onUserCreated: () => void;
};

export default function UserForm({ onUserCreated }: Props) {
    const [form, setForm] = useState<Omit<User, "id">>({
        name: "",
        email: "",
        phone: "",
        company: "",
        city: "",
    });

    const [loading, setLoading] = useState(false);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            setLoading(true);
            await createUser(form);

            setForm({
                name: "",
                email: "",
                phone: "",
                company: "",
                city: "",
            });

            onUserCreated();
        } finally {
            setLoading(false);
        }
    };

    return (
        <form
            onSubmit={handleSubmit}
            className="bg-white p-6 rounded-2xl shadow-md mb-6"
        >
            <h2 className="text-xl font-semibold text-gray-700 mb-4">
                Crear Usuario
            </h2>

            <div className="grid gap-3 md:grid-cols-2">
                <input name="name" placeholder="Nombre" value={form.name} onChange={handleChange} className="border p-2 rounded-lg focus:ring-2 focus:ring-blue-400" required />
                <input name="email" placeholder="Email" value={form.email} onChange={handleChange} className="border p-2 rounded-lg focus:ring-2 focus:ring-blue-400" required />
                <input name="phone" placeholder="Teléfono" value={form.phone} onChange={handleChange} className="border p-2 rounded-lg focus:ring-2 focus:ring-blue-400" />
                <input name="company" placeholder="Empresa" value={form.company} onChange={handleChange} className="border p-2 rounded-lg focus:ring-2 focus:ring-blue-400" />
                <input name="city" placeholder="Ciudad" value={form.city} onChange={handleChange} className="border p-2 rounded-lg focus:ring-2 focus:ring-blue-400 md:col-span-2" />
            </div>

            <button
                type="submit"
                disabled={loading}
                className="mt-4 w-full md:w-auto bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-lg transition"
            >
                {loading ? "Creando..." : "Crear Usuario"}
            </button>
        </form>
    );
}