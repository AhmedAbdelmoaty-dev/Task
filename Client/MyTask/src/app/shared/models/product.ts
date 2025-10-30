export interface CreateProduct{ 
  name:string
  sku: string
  description: string,
  price: number,  
}


export interface UpdateProduct{
  name: string
  sku: string
  description: string,
  price: number,  
}

export interface Product{
    id: number,
    sku: string,
    name: string,
    description: string,
    price: number,
    createdAtUtc: Date,
    updatedAtUtc:Date
}

export interface ProductQuery {
  pageIndex?: number;
  pageSize?: number;
  search?: string;
  includeDeleted:boolean
}

export interface PagedResult{
    productsDtos: Product[]
    pageIndex: number,
    pageSize: number,
    totalCount: number
    search:string
}

