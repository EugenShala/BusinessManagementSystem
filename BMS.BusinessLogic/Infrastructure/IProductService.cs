using BMS.DataAccess.Models;
using System.Collections;
using System.Collections.Generic;

namespace BMS.BusinessLogic.Infrastructure
{
    public interface IProductService
    {
        IEnumerable<ProductService> GetAllService();
        ProductService GetById(int id);
        void Add(ProductService service);
        void Delete(int id);
        void Update(ProductService service);

        void Save();

    }
}