using System;

namespace NNShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NNShopDbContext Init();
    }
}