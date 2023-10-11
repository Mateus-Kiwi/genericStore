using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecs<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Includes {get;}
    }
}