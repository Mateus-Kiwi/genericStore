
using API.DTOs;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entitites;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
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

        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductRetDTO>>> GetProducts([FromQuery]ProductParams productParams)
        {
            var spec = new ProductsWInfoSpec(productParams);
            var countSpec = new ProductsCountSpecs(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductRetDTO>>(products);
            return Ok(new Pagination<ProductRetDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductRetDTO>> GetProduct(int id)
        {
            var spec = new ProductsWInfoSpec(id);
            var product =  await _productRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductRetDTO>(product);
        } 

        [Cached(600)]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [Cached(600)]
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}