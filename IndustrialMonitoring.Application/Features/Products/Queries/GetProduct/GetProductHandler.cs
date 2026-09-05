using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustrialMonitoring.Application.DTOs;
using IndustrialMonitoring.Application.Interfaces;

namespace IndustrialMonitoring.Application.Features.Products.Queries.GetProduct
{
    public class GetProductHandler
    {
        private readonly IProductRepository _repository;

        public GetProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> HandleAsync(
            GetProductQuery query)
        {
            var product = await _repository.GetByIdAsync(query.Id);

            if (product is null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            return new ProductDto
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name
            };
        }
    }
}
