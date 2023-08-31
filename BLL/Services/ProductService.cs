using AutoMapper;
using BLL.DTO;
using DAL.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private DAL.Repository.ProductRepo _DAL;
        private Mapper _Mapper;
        public ProductService()
        {
            _DAL = new DAL.Repository.ProductRepo();
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>().ReverseMap());
            _Mapper = new Mapper(_config);
        }
        public List<ProductDTO> GetAll()
        {
            List<Product> product = _DAL.GetAll();
            List<ProductDTO> productDTOs = _Mapper.Map<List<Product>, List<ProductDTO>>(product);
            return productDTOs;
        }
        public ProductDTO GetById(int id)
        {
            var data = _DAL.GetById(id);
            ProductDTO productDTO = _Mapper.Map<Product, ProductDTO>(data);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return productDTO;

        }
        public void post(ProductDTO productDTO)
        {
            Product product = _Mapper.Map<ProductDTO, Product>(productDTO);
            _DAL.post(product);
        }
        public void Delete(int id)
        {

            _DAL.delete(id);
        }
        public ProductDTO Update(int id, ProductDTO productDTO)
        {
            Product product = _Mapper.Map<ProductDTO, Product>(productDTO);
            _DAL.Update(id, product);
            return productDTO;
        }
    }
}
