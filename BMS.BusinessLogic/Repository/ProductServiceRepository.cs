using System.Collections.Generic;
using System.Linq;
using BMS.BusinessLogic.Infrastructure;
using BMS.DataAccess.Data;
using BMS.DataAccess.Models;

namespace BMS.BusinessLogic.Repository
{
    public class ProductServiceRepository : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductServiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ProductService> GetAllService()
        {
            return _dbContext.ProductServices;
        }

        public ProductService GetById(int id)
        {
            return _dbContext.ProductServices.FirstOrDefault(s => s.Id == id);
        }

        public void Add(ProductService service)
        {
            _dbContext.ProductServices.Add(service);
        }

        public void Delete(int id)
        {
            var service = GetById(id);
            if (service != null)
            {
                _dbContext.ProductServices.Remove(service);
            }
        }

        public void Update(ProductService service)
        {
            _dbContext.ProductServices.Update(service);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}