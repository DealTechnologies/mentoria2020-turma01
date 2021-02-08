export interface Login {
    id?: string
    token?: string
    cpf: string;
    senha: string;
    data?: {
        id: string,
        token: string
    }
}