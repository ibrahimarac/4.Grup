
using System.Collections.Generic;
using Uzaktan.Core.Domain.Entities;

namespace Uzaktan.Core.Domain.Entites
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
