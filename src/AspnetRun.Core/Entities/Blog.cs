using AspnetRun.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Core.Entities
{
    public class Blog : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
