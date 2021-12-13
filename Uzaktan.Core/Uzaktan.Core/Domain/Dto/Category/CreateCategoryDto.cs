using System;
using System.Collections.Generic;
using System.Text;

namespace Uzaktan.Core.Domain.Dto.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
