namespace Uzaktan.Core.Domain.Dto
{
    public class CategoryDto:BaseDto<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
