namespace NNShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NNShopDbContext dbContext;

        public NNShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NNShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}