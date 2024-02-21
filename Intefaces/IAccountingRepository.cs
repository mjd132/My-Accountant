using p1.DTO;

namespace p1.Intefaces
{
    public interface IAccountingRepository :IDisposable
    {
        public void DebtRegister(DebtFormDto debtForm);

        public ICollection<DebtDto> GetAllDebts();



    }
}
