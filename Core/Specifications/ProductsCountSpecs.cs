using Core.Entitites;

namespace Core.Specifications
{
    public class ProductsCountSpecs : BaseSpecs<Product>
    {
        public ProductsCountSpecs(ProductParams productParams) : 
            base(x => 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) && 
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
        }
    }
}