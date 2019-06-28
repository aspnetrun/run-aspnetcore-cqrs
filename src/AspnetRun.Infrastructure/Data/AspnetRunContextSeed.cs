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
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<ProductRelatedProduct> _productRelatedProductRepository;
        private readonly IRepository<List> _listRepository;
        private readonly IRepository<ProductList> _productListRepository;
        private readonly IRepository<Wishlist> _wishlistRepository;
        private readonly IRepository<ProductWishlist> _productWishlistRepository;
        private readonly IRepository<Compare> _compareRepository;
        private readonly IRepository<ProductCompare> _productCompareRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Blog> _blogRepository;

        public AspnetRunContextSeed(
            AspnetRunContext aspnetRunContext,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository,
            IRepository<Specification> specificationRepository,
            IRepository<Review> reviewRepository,
            IRepository<Tag> tagRepository,
            IRepository<ProductRelatedProduct> productRelatedProductRepository,
            IRepository<List> listRepository,
            IRepository<ProductList> productListRepository,
            IRepository<Wishlist> wishlistRepository,
            IRepository<ProductWishlist> productWishlistRepository,
            IRepository<Compare> compareRepository,
            IRepository<ProductCompare> productCompareRepository,
            IRepository<Cart> cartRepository,
            IRepository<Order> orderRepository,
            IRepository<Blog> blogRepository)
        {
            _aspnetRunContext = aspnetRunContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _specificationRepository = specificationRepository;
            _reviewRepository = reviewRepository;
            _tagRepository = tagRepository;
            _productRelatedProductRepository = productRelatedProductRepository;
            _listRepository = listRepository;
            _productListRepository = productListRepository;
            _wishlistRepository = wishlistRepository;
            _productWishlistRepository = productWishlistRepository;
            _compareRepository = compareRepository;
            _productCompareRepository = productCompareRepository;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _blogRepository = blogRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _aspnetRunContext.Database.Migrate();
            // _aspnetRunContext.Database.EnsureCreated();

            // categories - specifications - reviews - tags
            await SeedCategoriesAsync();
            await SeedSpecificationsAsync();
            await SeedReviewsAsync();
            await SeedTagsAsync();

            // products - related products - lists
            await SeedProductsAsync();
            await SeedProductAndRelatedProductsAsync();
            await SeedListAndProductsAsync();

            // compares and wishlists
            await SeedCompareAndProductsAsync();
            await SeedWishlistAndProductsAsync();

            // cart and cart items - order and order items
            await SeedCartAndItemsAsync();
            await SeedOrderAndItemsAsync();

            // blog
            await SeedBlogsAsync();
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

        private async Task SeedReviewsAsync()
        {
            if (!_reviewRepository.Table.Any())
            {
                var reviews = new List<Review>()
                {
                    new Review
                    {
                        Name = "Cristopher Lee",
                        EMail = "cristopher@lee.com",
                        Star = 4.3,
                        Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                    },
                    new Review
                    {
                        Name = "Nirob Khan",
                        EMail = "nirob@lee.com",
                        Star = 4.3,
                        Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                    },
                    new Review
                    {
                        Name = "MD.ZENAUL ISLAM",
                        EMail = "zenaul@lee.com",
                        Star = 4.3,
                        Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                    }
                };

                await _reviewRepository.AddRangeAsync(reviews);
            }
        }

        private async Task SeedTagsAsync()
        {
            if (!_tagRepository.Table.Any())
            {
                var tags = new List<Tag>()
                {
                    new Tag
                    {
                        Name = "Electronic"
                    },
                    new Tag
                    {
                        Name = "Smartphone"
                    },
                    new Tag
                    {
                        Name = "Phone"
                    },
                    new Tag
                    {
                        Name = "Charger"
                    },
                    new Tag
                    {
                        Name = "Powerbank"
                    }
                };

                await _tagRepository.AddRangeAsync(tags);
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
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
                        Specifications = _specificationRepository.Table.ToList(),
                        Reviews = _reviewRepository.Table.ToList(),
                        Tags = _tagRepository.Table.ToList()
                    }
                };

                await _productRepository.AddRangeAsync(products);
            }
        }

        private async Task SeedProductAndRelatedProductsAsync()
        {
            if (!_productRelatedProductRepository.Table.Any())
            {
                var newRelatedProductLists = new List<ProductRelatedProduct>
                {
                    new ProductRelatedProduct
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                        RelatedProduct = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault()
                    },
                    new ProductRelatedProduct
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                        RelatedProduct = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(2).FirstOrDefault()
                    }
                };

                await _productRelatedProductRepository.AddRangeAsync(newRelatedProductLists);
            }
        }

        private async Task SeedListAndProductsAsync()
        {
            if (!_listRepository.Table.Any())
            {
                var lists = new List<List>()
                {
                    new List
                    {
                        Name = "FEATURED ITEMS",
                        Description = "",
                        ImageFile = "",
                        //Products = aspnetrunContext.Products.Where(x => x.Id % 2 == 1).Take(5).ToList()
                    },
                    new List
                    {
                        Name = "BEST SELLERS",
                        Description = "",
                        ImageFile = "",
                        //Products = aspnetrunContext.Products.Take(8).ToList()
                    },
                    new List
                    {
                        Name = "BEST DEALS",
                        Description = "",
                        ImageFile = "",
                        //Products = aspnetrunContext.Products.Where(p => p.Name.Length > 15).Take(5).ToList()
                    },
                    new List
                    {
                        Name = "NEW ARRIVAL",
                        Description = "",
                        ImageFile = "",
                        //Products = aspnetrunContext.Products.Where(x => x.Id % 2 != 1).Take(5).ToList()
                    },
                };

                await _listRepository.AddRangeAsync(lists);
            }

            if (!_productListRepository.Table.Any())
            {
                var newProductLists = new List<ProductList>
                {
                    new ProductList
                    {
                        List = _listRepository.Table.FirstOrDefault(l => l.Name == "FEATURED ITEMS"),
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).FirstOrDefault()
                    },
                    new ProductList
                    {
                        List = _listRepository.Table.FirstOrDefault(l => l.Name == "FEATURED ITEMS"),
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault()
                    },
                    new ProductList
                    {
                        List = _listRepository.Table.FirstOrDefault(l => l.Name == "BEST SELLERS"),
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(2).FirstOrDefault()
                    }
                };

                await _productListRepository.AddRangeAsync(newProductLists);
            }
        }

        private async Task SeedWishlistAndProductsAsync()
        {
            if (!_wishlistRepository.Table.Any())
            {
                var wishlists = new List<Wishlist>()
                {
                    new Wishlist
                    {
                        UserName = "mehmetozkaya@gmail.com"
                    }
                };

                await _wishlistRepository.AddRangeAsync(wishlists);
            }

            if (!_productWishlistRepository.Table.Any())
            {
                var newProductWishlists = new List<ProductWishlist>()
                {
                    new ProductWishlist
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                        Wishlist = _wishlistRepository.Table.FirstOrDefault()
                    },
                    new ProductWishlist
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault(),
                        Wishlist = _wishlistRepository.Table.FirstOrDefault()
                    }
                };

                await _productWishlistRepository.AddRangeAsync(newProductWishlists);
            }
        }

        private async Task SeedCompareAndProductsAsync()
        {
            if (!_compareRepository.Table.Any())
            {
                var compares = new List<Compare>()
                {
                    new Compare
                    {
                        UserName = "mehmetozkaya@gmail.com"
                    }
                };

                await _compareRepository.AddRangeAsync(compares);
            }

            if (!_productCompareRepository.Table.Any())
            {
                var newProductCompares = new List<ProductCompare>()
                {
                    new ProductCompare
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).FirstOrDefault(),
                        Compare = _compareRepository.Table.FirstOrDefault()
                    },
                    new ProductCompare
                    {
                        Product = _productRepository.Table.Where(x => x.Id % 2 == 1).Skip(1).FirstOrDefault(),
                        Compare = _compareRepository.Table.FirstOrDefault()
                    }
                };

                await _productCompareRepository.AddRangeAsync(newProductCompares);
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

        private async Task SeedBlogsAsync()
        {
            if (!_blogRepository.Table.Any())
            {
                var blogs = new List<Blog>()
                {
                    new Blog
                    {
                        Name = "Latest Drone for taking sky view image and 4K video",
                        Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                        ImageFile = "blog-10.jpg"
                    },
                    new Blog
                    {
                        Name = "Zeon Z 5 Pro Laptop makes your life easy and simple",
                        Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    },
                    new Blog
                    {
                        Name = "Latest Play Station for plying exclusive games",
                        Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                        ImageFile = "blog-11.jpg"
                    },
                    new Blog
                    {
                        Name = "The most attractive Smart watch comming in this February",
                        Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                        ImageFile = "blog-12.jpg"
                    }
                };

                await _blogRepository.AddRangeAsync(blogs);
            }
        }
    }
}
