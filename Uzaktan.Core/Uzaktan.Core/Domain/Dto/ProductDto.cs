namespace Uzaktan.Core.Domain.Dto
{
    public class ProductDto:BaseDto<int>
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
