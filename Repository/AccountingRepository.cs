using AutoMapper;
using Microsoft.EntityFrameworkCore;
using p1.DTO;
using p1.Entities;
using p1.Intefaces;
using p1.Repository.context;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace p1.Repository
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly EntitiesDbContext _context;
        private readonly IMapper _mapper;
        private bool disposedValue;
        public AccountingRepository(EntitiesDbContext entitiesDbContext,IMapper mapper) {
            _context = entitiesDbContext;
            _mapper = mapper;
        }
        



        public void DebtRegister(DebtFormDto debtForm)
        {
            User madarkharj = _context.Users.FirstOrDefault(u => u.userName == debtForm.MadarKharjUsername);
            if (madarkharj == null)
            {
                //user not found
                return;
            }
            ICollection<User> debtUsers = new List<User>();
            foreach (string debtUser in debtForm.DebtUsernames)
            {
                var debuser = _context.Users.FirstOrDefault(u => u.userName == debtUser);
                if (debuser == null)
                {
                    //user not found
                    return;
                }

                debtUsers.Add(debuser);

            }

            DebtReg debt = new DebtReg()
            {
                MadarKharj = madarkharj,
                DebtUsers = debtUsers,
                Amount = debtForm.Amount,
                RegDate = DateTime.Now

            };
            try
            {
                _context.Debts.Add(debt);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            Console.WriteLine(debt.DebtUsers.ToString());
        }
        private void CompleteDebt(DebtReg debt)
        {

        }
        public ICollection<DebtDto> GetAllDebts()
        {
            List<DebtReg> debt= _context.Debts.AsQueryable().Include(d=>d.DebtUsers).Include(d=>d.MadarKharj).Select(r=>r).ToList();
            ICollection<DebtDto> debts = _mapper.Map<List<DebtDto>>(debt);
            return debts;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();

                }

                
                disposedValue = true;
            }
        }

        

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
