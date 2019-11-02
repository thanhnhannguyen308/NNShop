namespace NNShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}