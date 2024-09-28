using System.Linq.Expressions;

namespace Restaurant.Data.ViewModels
{
    public class BaseGridFilterViewModel<T>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public IList<string> Group { get; set; }

        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
