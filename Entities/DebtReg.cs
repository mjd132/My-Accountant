using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p1.Entities
{
    public class DebtReg
    {

        public long Id { get; set; }
        public DateTime RegDate { get; set; }
        public User MadarKharj { get; set; }
        public long MadarKharjId { get; set; }
        public ICollection<User> DebtUsers { get; set; }
        public float Amount { get; set; }
    }

}
