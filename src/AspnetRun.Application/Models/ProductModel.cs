using AspnetRun.Application.Models.Base;
using System;

namespace AspnetRun.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
