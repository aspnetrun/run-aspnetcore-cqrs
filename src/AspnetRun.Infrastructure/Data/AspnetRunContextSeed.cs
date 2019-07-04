using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Specification> _specificationRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;

        public AspnetRunContextSeed(
            AspnetRunContext aspnetRunContext,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository,
            IRepository<Specification> specificationRepository,
            IRepository<Cart> cartRepository,
            IRepository<Order> orderRepository)
        {
            _aspnetRunContext = aspnetRunContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _specificationRepository = specificationRepository;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _aspnetRunContext.Database.Migrate();
            // _aspnetRunContext.Database.EnsureCreated();

            // categories - specifications - reviews - tags
            await SeedCategoriesAsync();
            await SeedSpecificationsAsync();

            // products - related products - lists
            await SeedProductsAsync();

            // cart and cart items - order and order items
            await SeedCartAndItemsAsync();
            await SeedOrderAndItemsAsync();
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
                    new Specification
                    {
                        Name = "Full HD Camcorder",
                        Description = "Full HD Camcorder"
                    },
                    new Specification
                    {
                        Name = "Dual Video Recording",
                        Description = "Dual Video Recording"
                    },
                    new Specification
                    {
                        Name = "X type battery operation",
                        Description = "X type battery operation"
                    },
                    new Specification
                    {
                        Name = "Full HD Camcorder",
                        Description = "Full HD Camcorder"
                    },
                    new Specification
                    {
                        Name = "Dual Video Recording",
                        Description = "Dual Video Recording"
                    },
                    new Specification
                    {
                        Name = "X type battery operation",
                        Description = "X type battery operation"
                    }
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
                        CategoryId = 4,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 4,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 4,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 4,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 5,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 5,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 5,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 5,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 5,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 6,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 6,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 1,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 2,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 7,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 8,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 8,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 3,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 3,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 3,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
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
                        CategoryId = 9,
                        Specifications = _specificationRepository.Table.ToList()
                    }
                };

                await _productRepository.AddRangeAsync(products);
            }
        }

        private async Task SeedCartAndItemsAsync()
        {
            if (!_cartRepository.Table.Any())
            {
                var carts = new List<Cart>()
                {
                    new Cart
                    {
                        UserName = "mehmetozkaya@gmail.com",
                        Items = new List<CartItem>
                        {
                            new CartItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "uPhone X"),
                                Quantity = 2,
                                Color = "Black",
                                UnitPrice = 295,
                                TotalPrice = 590
                            },
                            new CartItem
                            {
                                Product = _productRepository.Table.FirstOrDefault(p => p.Name == "Game Station X 22"),
                                Quantity = 1,
                                Color = "Red",
                                UnitPrice = 295,
                                TotalPrice = 295
                            },
                            new CartItem
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

                await _cartRepository.AddRangeAsync(carts);
            }
        }

        private async Task SeedOrderAndItemsAsync()
        {
            if (!_orderRepository.Table.Any())
            {
                var address = new Address
                {
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
                };

                var addressShipping = new Address
                {
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
                };

                var orders = new List<Order>()
                {
                    new Order
                    {
                        UserName = "mehmetozkaya@gmail.com",
                        BillingAddress = address,
                        ShippingAddress = addressShipping,
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
    }
}
