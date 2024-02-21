using p1.Entities;

namespace p1.DTO
{
    public class DebtDto
    {
        
        public DateTime RegDate { get; set; }

        public UDto MadarKharj { get; set; }
        
        public ICollection<UDto> DebtUsers { get; set; }
        public float Amount { get; set; }
    }
}
