
using API.DTOs;
using AutoMapper;
using Core.Entitites;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IGenericRepo<ProductBrand> _productBrandRepo;
        public readonly IGenericRepo<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepo<Product> productRepo, IGenericRepo<ProductBrand> productBrandRepo, IGenericRepo<ProductType> productTypeRepo, IMapper mapper)
        {       
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductRetDTO>>> GetProducts()
        {
            var spec = new ProductsWInfoSpec();
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductRetDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRetDTO>> GetProduct(int id)
        {
            var spec = new ProductsWInfoSpec(id);
            var product =  await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductRetDTO>(product);
        }
 
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}