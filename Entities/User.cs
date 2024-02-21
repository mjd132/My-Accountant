using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace p1.Entities
{

    [Index(nameof(userName))]
    public class User
    {
        public long Id { get; set; }
        public string fName { get; set; }
        public int? age { get; set; }
        public string? lName { get; set; }
        public string password { get; set; }
        //public DateTime registerDate { get; set; }
        //public string idTelegram { get; set; }
        //public string roomCode { get; set; }
        [Required(ErrorMessage = "username is empty")]
        public string userName { get; set; }


        //public string phone { get; set; }
        //public string city { get; set; }
        //public ICollection<Friend> friends { get; set; }

        //room relationship

        public long? roomId { get; set; }
        public Room? room { get; set; }



        //accounting

        //public ICollection<Account>? Accounts { get; set; }

        //debtRegs
        public ICollection<DebtReg>? MadarKharjis { get; set; }
        public ICollection<DebtReg>? Debts { get; set; }
    }
}
