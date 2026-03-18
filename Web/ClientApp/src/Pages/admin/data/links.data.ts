import { IAtlasCustomLinks } from "@/Models/Interfaces/IAtlasCustomLink";

export const  adminLinkItems : IAtlasCustomLinks = {
    linkItems : [
        {label:'Salir', path:'/auth/signout'},
        {label: 'Producto',  path:'/admin/producto/index'},
        {label: 'Categoria',  path:'/admin/categoria/index'},
        {label: 'Venta', path: '/admin/venta/index'},
        {label: 'Pedidos', path: '/admin/purchase/index'}
    ]
} ;


export const  StoreLinkItems : IAtlasCustomLinks = {
    linkItems : [
        {label: 'Gorras',  path:'/admin/producto/index'},
        {label: 'Perfumes',  path:'/admin/categoria/index'},
        {label: 'Playeras', path: '/admin/venta/index'},
        {label: 'Admin', path: '/admin/index'}

    ]
} ;