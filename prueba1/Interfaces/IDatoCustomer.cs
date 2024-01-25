namespace prueba1.Interfaces
{
    public interface IDatoCustomer<TEntityModel> where TEntityModel : class 
    {

       Task<IEnumerable<TEntityModel>> ListCustomer();

        Task<TEntityModel> PostCustomer(TEntityModel model);
    }
}
