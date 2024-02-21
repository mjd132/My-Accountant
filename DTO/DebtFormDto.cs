using p1.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace p1.DTO
{
    public class DebtFormDto
    {
        public string MadarKharjUsername { get; set; }
        public List<string> DebtUsernames { get; set; } = new List<string>();
        public float Amount { get; set; }
    }
}
