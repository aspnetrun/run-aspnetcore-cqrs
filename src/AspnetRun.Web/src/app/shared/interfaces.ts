export interface IProduct {
    id: number;
    name: string;
    description: string;
    unitPrice: number;
    category: ICategory;
}

export interface ICategory {
    id: number;
    name?: string;
    description?: string;
}
