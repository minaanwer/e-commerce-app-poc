using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

     

        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        public Expression<Func<T, object>> orderBy { get; private set; }

        public Expression<Func<T, object>> orderByDescending { get; private set; }

        public void AddOrderBy(Expression<Func<T, object>> orderByExp)
        {
            this.orderBy = orderByExp;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByExp)
        {
            this.orderByDescending = orderByExp;
        }
    }
}
