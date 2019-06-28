using AspnetRun.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Core.Entities
{
    public class Contact : Entity
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(10)]
        [Required]
        public string Message { get; set; }
    }
}
