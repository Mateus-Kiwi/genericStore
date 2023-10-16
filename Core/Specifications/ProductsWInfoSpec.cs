using System.Linq.Expressions;
using Core.Entitites;

namespace Core.Specifications
{
    public class ProductsWInfoSpec : BaseSpecs<Product>
    {
        public ProductsWInfoSpec()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWInfoSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}