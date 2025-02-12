export interface Type {
    id: number;
    name: string;
    image: string;
    active: boolean;
}
export interface TypeResponse{
    isModified: boolean;
    error: {
        existedError: string,
        imageError: string,
        nameError: string
    }
}