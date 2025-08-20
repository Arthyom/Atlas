import { IAtlasCustomLinks } from "@/Models/Interfaces/IAtlasCustomLink";

export const  adminLinkItems : IAtlasCustomLinks = {
    linkItems : [
        {label: 'Producto',  path:'/admin/producto/index'},
        {label: 'Categoria',  path:'/admin/categoria/index'},
        {label: 'Venta', path: '/admin/venta/index'}
    ]
} ;