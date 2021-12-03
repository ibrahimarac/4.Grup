using Uzaktan.Core.Domain.Entities;

namespace Uzaktan.Core.Domain.Entites
{
    public class Product:BaseEntity<int>
    {
        public string ProductName { get; set; }

        public int CategoryId { get; set; }     //Foreign Key
        public Category Category { get; set; }

        public bool IsActive { get; set; }
    }
}
