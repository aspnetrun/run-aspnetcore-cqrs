interface NavAttributes {
    [propName: string]: any;
}
interface NavWrapper {
    attributes: NavAttributes;
    element: string;
}
interface NavBadge {
    text: string;
    variant: string;
}
interface NavLabel {
    class?: string;
    variant: string;
}

export interface NavData {
    name?: string;
    url?: string;
    icon?: string;
    badge?: NavBadge;
    title?: boolean;
    children?: NavData[];
    variant?: string;
    attributes?: NavAttributes;
    divider?: boolean;
    class?: string;
    label?: NavLabel;
    wrapper?: NavWrapper;
}

export const navItems: NavData[] = [
    { name: 'Dashboard', url: '/dashboard', icon: 'icon-speedometer', },
    { name: 'Products', url: '/product/product-list', icon: 'icon-list' },
    { name: 'Categories', url: '/category/category-list', icon: 'icon-folder-alt' },
    { name: 'Customer', url: '/customer/customer-list', icon: 'icon-folder-alt' },
    { name: 'About', url: '/about', icon: 'icon-folder-alt' },
];
