using System;
using Uzaktan.Core.Domain.Entities;

namespace Uzaktan.Core.Domain.Entites
{
    public class Product:BaseEntity<int>
    {
        public string ProductName { get; set; }
        public int UnitInStock { get; set; }

        public int CatId { get; set; }     //Foreign Key
        public Category Category { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastupDate { get; set; }
    }
}
