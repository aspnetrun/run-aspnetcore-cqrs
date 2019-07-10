using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly UserManager<AspnetRunUser> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<ProductSpecification> _productSpecificationRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Specification> _specificationRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Order> _orderRepository;

        public AspnetRunContextSeed(
            AspnetRunContext aspnetRunContext,
            UserManager<AspnetRunUser> userManager,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository,
            IRepository<ProductSpecification> productSpecificationRepository,
            IRepository<Specification> specificationRepository,
            IRepository<Customer> customerRepository,
            IRepository<Address> addressRepository,
            IRepository<Order> orderRepository)
        {
            _aspnetRunContext = aspnetRunContext;
            _userManager = userManager;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productSpecificationRepository = productSpecificationRepository;
            _specificationRepository = specificationRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _aspnetRunContext.Database.Migrate();
            // _aspnetRunContext.Database.EnsureCreated();

            // categories - specifications
            await SeedCategoriesAsync();
            await SeedSpecificationsAsync();

            // products
            await SeedProductsAsync();

            // customers
            await SeedCustomersAsync();

            // order and order items
            await SeedOrderAndItemsAsync();

            // users
            await SeedUsersAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (!_categoryRepository.Table.Any())
            {
                var categories = new List<Category>
                {
                    new Category() { Name = "Laptop"}, // 1
                    new Category() { Name = "Drone"}, // 2
                    new Category() { Name = "TV & Audio"}, // 3
                    new Category() { Name = "Phone & Tablet"}, // 4
                    new Category() { Name = "Camera & Printer"}, // 5
                    new Category() { Name = "Games"}, // 6
                    new Category() { Name = "Accessories"}, // 7
                    new Category() { Name = "Watch"}, // 8
                    new Category() { Name = "Home & Kitchen Appliances"} // 9
                };

                await _categoryRepository.AddRangeAsync(categories);
            }
        }

        private async Task SeedSpecificationsAsync()
        {
            if (!_specificationRepository.Table.Any())
            {
                var specifications = new List<Specification>()
                {
                    new Specification { Name = "Full HD Camcorder", Description = "Full HD Camcorder" },
                    new Specification { Name = "Dual Video Recording", Description = "Dual Video Recording" },
                    new Specification { Name = "X type battery operation", Description = "X type battery operation" },
                };

                await _specificationRepository.AddRangeAsync(specifications);
            }
        }

        private async Task SeedProductsAsync()
        {
            if (!_productRepository.Table.Any())
            {
                var products = new List<Product>
                {
                    // Phone
                    new Product()
                    {
                        Name = "uPhone X",
                        Slug = "uphone-x",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-1.png",
                        UnitPrice = 295,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Phone & Tablet")
                    },
                    new Product()
                    {
                        Name = "Ornet Note 9",
                        Slug = "ornet-note",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-17.png",
                        UnitPrice = 285,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Phone & Tablet")
                    },
                    new Product()
                    {
                        Name = "Sany Experia Z5",
                        Slug = "sany-experia",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-24.png",
                        UnitPrice = 360,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Phone & Tablet")
                    },
                    new Product()
                    {
                        Name = "Flex P 3310",
                        Slug = "flex-p",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-19.png",
                        UnitPrice = 220,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Phone & Tablet")
                    },
                    // Camera                
                    new Product()
                    {
                        Name = "Mony Handycam Z 105",
                        Slug = "mony-handycam-z",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-5.png",
                        UnitPrice = 145,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Camera & Printer")
                    },
                    new Product()
                    {
                        Name = "Axor Digital Camera",
                        Slug = "axor-digital",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-6.png",
                        UnitPrice = 199,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Camera & Printer")
                    },
                    new Product()
                    {
                        Name = "Silvex DSLR Camera T 32",
                        Slug = "silvex-camera",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-7.png",
                        UnitPrice = 580,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Camera & Printer")
                    },
                    new Product()
                    {
                        Name = "Necta Instant Camera",
                        Slug = "necta-instant",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-8.png",
                        UnitPrice = 320,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Camera & Printer")
                    },
                    // Printer
                    new Product()
                    {
                        Name = "Pranon Photo Printer Y 25",
                        Slug = "pranon-printer",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-11.png",
                        UnitPrice = 210,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Camera & Printer")
                    },
                    // Game                
                    new Product()
                    {
                        Name = "Game Station X 22",
                        Slug = "game-station-x",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-3.png",
                        UnitPrice = 295,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Games")
                    },
                    new Product()
                    {
                        Name = "Game Stations PW 25",
                        Slug = "game-station-pw",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-13.png",
                        UnitPrice = 285,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Games")
                    },
                    // Laptop      
                    new Product()
                    {
                        Name = "Zeon Zen 4 Pro",
                        Slug = "zeon-zen",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-1.png",
                        UnitPrice = 295,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Laptop")
                    },
                    // Drone                
                    new Product()
                    {
                        Name = "Aquet Drone D 420",
                        Slug = "aquet-drone",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-2.png",
                        UnitPrice = 275,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Drone")
                    },
                    // Accessories
                    new Product()
                    {
                        Name = "Roxxe Headphone Z 75",
                        Slug = "roxxe-headphone-z",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-4.png",
                        UnitPrice = 110,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Accessories")
                    },
                    // Watch
                    new Product()
                    {
                        Name = "Mascut Smart Watch",
                        Slug = "mascut-smart",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-9.png",
                        UnitPrice = 365,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Watch")
                    },
                    new Product()
                    {
                        Name = "Z Bluetooth Headphone",
                        Slug = "z-bluetooth",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-10.png",
                        UnitPrice = 189,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Watch")
                    },
                    // TV & Audio
                    new Product()
                    {
                        Name = "Roses Speaker Box",
                        Slug = "roses-speaker",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-12.png",
                        UnitPrice = 210,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "TV & Audio")
                    },
                    new Product()
                    {
                        Name = "Nexo Andriod TV Box",
                        Slug = "nexo-andriod",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-16.png",
                        UnitPrice = 360,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "TV & Audio")
                    },
                    new Product()
                    {
                        Name = "Xonet Speaker P 9",
                        Slug = "xonet-speaker",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-18.png",
                        UnitPrice = 185,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "TV & Audio")
                    },
                    // Home & Kitchen Appliances
                    new Product()
                    {
                        Name = "Zorex Coffe Maker",
                        Slug = "zorex-coffe",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-14.png",
                        UnitPrice = 210,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    },
                    new Product()
                    {
                        Name = "Jeilips Steam Iron K 2",
                        Slug = "jeilips-steam",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-15.png",
                        UnitPrice = 365,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    },
                    new Product()
                    {
                        Name = "Jackson Toster V 27",
                        Slug = "jackson-toster",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-20.png",
                        UnitPrice = 185,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    },
                    new Product()
                    {
                        Name = "Mega Juice Maker",
                        Slug = "mega-juice",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-21.png",
                        UnitPrice = 185,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    },
                    new Product()
                    {
                        Name = "Shine Microwave Oven",
                        Slug = "shine-microwave",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-22.png",
                        UnitPrice = 185,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    },
                    new Product()
                    {
                        Name = "Auto Rice Cooker",
                        Slug = "auto-rice",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                        ImageFile = "product-23.png",
                        UnitPrice = 130,
                        UnitsInStock = 10,
                        Star = 4.3,
                        Category = _categoryRepository.Table.FirstOrDefault(c => c.Name == "Home & Kitchen Appliances")
                    }
                };

                await _productRepository.AddRangeAsync(products);

                var productSpecifications = from product in _productRepository.Table
                                            from specification in _specificationRepository.Table
                                            select new ProductSpecification { Product = product, Specification = specification };

                await _productSpecificationRepository.AddRangeAsync(productSpecifications);
            }
        }

        private async Task SeedCustomersAsync()
        {
            if (!_customerRepository.Table.Any())
            {
                var customers = new List<Customer>()
                {
                    new Customer
                    {
                        Name = "Abdulkadir",
                        Surname = "Genc",
                        Phone = "05013333333",
                        DefaultAddress = null,
                        Email = "aspnetrun@outlook.com",
                        CitizenId = "55555555555",
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                AddressTitle ="Home Address",
                                AddressLine = "Esenler",
                                City = "Istanbul",
                                Country = "Turkey",
                                EmailAddress = "aspnetrun@outlook.com",
                                FirstName = "Abdulkadir",
                                LastName = "Genc",
                                CompanyName = "AspnetRun",
                                PhoneNo = "05013333333",
                                State = "027",
                                ZipCode = "34056"
                            },
                            new Address
                            {
                                AddressTitle ="Office Address",
                                AddressLine = "Maslak",
                                City = "Istanbul",
                                Country = "Turkey",
                                EmailAddress = "aspnetrun@outlook.com",
                                FirstName = "Abdulkadir",
                                LastName = "Genc",
                                CompanyName = "AspnetRun",
                                PhoneNo = "05013333333",
                                State = "027",
                                ZipCode = "34056"
                            }
                        }
                    },
                    new Customer
                    {
                        Name = "Mehmet",
                        Surname = "Ozkaya",
                        Phone = "05012222222",
                        DefaultAddress = null,
                        Email = "aspnetrun@outlook.com",
                        CitizenId = "11111111111",
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                AddressTitle ="Home Address",
                                AddressLine = "Gungoren",
                                City = "Istanbul",
                                Country = "Turkey",
                                EmailAddress = "aspnetrun@outlook.com",
                                FirstName = "Mehmet",
                                LastName = "Ozkaya",
                                CompanyName = "AspnetRun",
                                PhoneNo = "05012222222",
                                State = "027",
                                ZipCode = "34056"
                            },
                            new Address
                            {
                                AddressTitle = "Office Address",
                                AddressLine = "Maslak",
                                City = "Istanbul",
                                Country = "Turkey",
                                EmailAddress = "aspnetrun@outlook.com",
                                FirstName = "Mehmet",
                                LastName = "Ozkaya",
                                CompanyName = "AspnetRun",
                                PhoneNo = "05012222222",
                                State = "027",
                                ZipCode = "34056"
                            }
                        }
                    }
                };
                customers.ForEach(c => c.DefaultAddress = c.Addresses.FirstOrDefault());
                var addresses = customers.SelectMany(p => p.Addresses);

                await _addressRepository.AddRangeAsync(addresses);
                await _customerRepository.AddRangeAsync(customers);
            }
        }

        private async Task SeedOrderAndItemsAsync()
        {
            if (!_orderRepository.Table.Any())
            {
                var cust1 = _customerRepository.Table.FirstOrDefault(c => c.Name == "Abdulkadir");
                var cust2 = _customerRepository.Table.FirstOrDefault(c => c.Name == "Mehmet");

                var orders = new List<Order>()
                {
                    new Order
                    {
                        Customer = cust1,
                        BillingAddress = cust1.Addresses.FirstOrDefault(),
                        ShippingAddress = cust1.Addresses.FirstOrDefault(),
                        PaymentMethod = PaymentMethod.Cash,
                        Status = OrderStatus.Progress,
                        GrandTotal = 347,
                        Items = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "uPhone X"),
                                Quantity = 2,
                                Color = "Black",
                                UnitPrice = 295,
                                TotalPrice = 590
                            },
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "Game Station X 22"),
                                Quantity = 1,
                                Color = "Red",
                                UnitPrice = 295,
                                TotalPrice = 295
                            },
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                                Quantity = 1,
                                Color = "Black",
                                UnitPrice = 185,
                                TotalPrice = 185
                            }
                        }
                    },
                    new Order
                    {
                        Customer = cust2,
                        BillingAddress = cust2.Addresses.FirstOrDefault(),
                        ShippingAddress = cust2.Addresses.FirstOrDefault(),
                        PaymentMethod = PaymentMethod.Cash,
                        Status = OrderStatus.Progress,
                        GrandTotal = 347,
                        Items = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "uPhone X"),
                                Quantity = 2,
                                Color = "Black",
                                UnitPrice = 295,
                                TotalPrice = 590
                            },
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "Game Station X 22"),
                                Quantity = 1,
                                Color = "Red",
                                UnitPrice = 295,
                                TotalPrice = 295
                            },
                            new OrderItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                                Quantity = 1,
                                Color = "Black",
                                UnitPrice = 185,
                                TotalPrice = 185
                            }
                        }
                    }
                };

                await _orderRepository.AddRangeAsync(orders);
            }
        }

        private async Task SeedUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync("aspnetrun@outlook.com");
            if (user == null)
            {
                user = new AspnetRunUser
                {
                    FirstName = "Aspnet",
                    LastName = "Run",
                    Email = "aspnetrun@outlook.com",
                    UserName = "aspnetrun"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }

                _aspnetRunContext.Entry(user).State = EntityState.Unchanged;
            }
        }
    }
}
