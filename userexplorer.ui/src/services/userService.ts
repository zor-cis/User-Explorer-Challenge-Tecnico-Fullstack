import { User } from "../types/User";

const API_URL = "https://localhost:7002/api";

export async function getUsers(): Promise<User[]> {
    const response = await fetch(`${API_URL}/users`);

    if (!response.ok) {
        throw new Error("Error al obtener usuarios");
    }

    return await response.json();
}

export async function getUserById(id: number): Promise<User> {
    const response = await fetch(`${API_URL}/users/${id}`);

    if (!response.ok) {
        throw new Error("Usuario no encontrado");
    }

    return await response.json();
}

export async function createUser(
    userData: Omit<User, "id">
): Promise<User> {
    const response = await fetch(`${API_URL}/users`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
    });

    const data = await response.json();

    if (!response.ok) {
        throw new Error("Error al crear usuario");
    }

    return data;
}

export async function searchUsers(
    search: string = "",
    company: string = "",
    city: string = ""
): Promise<User[]> {
    const params = new URLSearchParams();

    if (search) params.append("search", search);
    if (company) params.append("company", company);
    if (city) params.append("city", city);

    const url = params.toString()
        ? `${API_URL}/users?${params.toString()}`
        : `${API_URL}/users`;

    const response = await fetch(url);

    if (!response.ok) {
        throw new Error("Error en la búsqueda");
    }

    return await response.json();
}