using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, object>> orderBy { get; private set; }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> orderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }


        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExp)
        {
            this.orderBy = orderByExp;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByExp)
        {
            this.orderByDescending = orderByExp;
        }
   
        public void ApplyPaging(int skip , int take)
        {
            IsPagingEnabled = true;
            this.Skip = skip;
            this.Take = take;
        }
    }
}
