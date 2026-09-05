using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsHandler
    {
        private readonly IProductRepository _repository;

        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ProductDto>> HandleAsync(
            GetProductsQuery query)
        {
            var products = await _repository.GetAllAsync();

            return products
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name
                })
                .ToList();
        }
    }
}
