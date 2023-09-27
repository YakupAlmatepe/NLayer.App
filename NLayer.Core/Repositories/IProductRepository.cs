using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //generic repositorydeki veriler gelecek (ıgenericrepositoryden miras aldığım için) yrıca ıproduct repositorynin implement işlemlerini yapmış olacağım
        Task<List<Product>> GetProductsWithCategory();
    }
}
