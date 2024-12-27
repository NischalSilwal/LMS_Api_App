using LMS_Api_App.Application.DTOs;
using LMS_Api_App.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace LMS_Api_App.Application.Mappers
{
    public static class ProductMapper
    {
        /*
        // Map to create a new Product entity from ProductDTO and imagePath
        public static Product MapToUpdateProduct(ProductDTO productDTO, Product product, string imagePath)
        {
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;
            if (!string.IsNullOrEmpty(imagePath))
            {
                product.ImagePath = imagePath;
            }
            return product;  // Return the updated product
        }
        public static Product MapToProduct(ProductDTO productDTO, string imagePath)
        {
            return new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                ImagePath = imagePath // Full image path
            };
        }


        // Method for updating an existing product
        public static void MapToExistingProduct(ProductDTO productDTO, Product product, string imagePath = null)
        {
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;

            // Update the ImagePath only if a new image path is provided
            if (!string.IsNullOrEmpty(imagePath))
            {
                product.ImagePath = imagePath;
            }
        }

        // Other methods remain the same
        public static GetAllProductDTO ToDto(Product product)
        {
            return new GetAllProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public static GetProductByIdDTO ToGetProductByIdDTO(Product product)
        {
            return new GetProductByIdDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public static IEnumerable<GetAllProductDTO> ToDto(IEnumerable<Product> products)
        {
            return products.Select(product => ToDto(product)).ToList();
        }
         */
    }

}
