import { IAtlasCustomLinks } from "@/Models/Interfaces/IAtlasCustomLink";
import { router } from "@inertiajs/vue3";

export const  adminLinkItems : IAtlasCustomLinks = {
    linkItems : [
        {label:'Salir', path:'', customFun: () => {   
            
            router.replace('/auth/signout');


            // Push a new state to the history stack
history.pushState(null, '', location.href);

// Listen for back/forward button clicks
window.onpopstate = function () {
    // Force the user forward if they try to go back
    history.go(1);
};

            

         }  },
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