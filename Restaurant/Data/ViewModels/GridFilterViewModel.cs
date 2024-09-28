using System.Linq.Expressions;

namespace Restaurant.Data.ViewModels
{
    public class GridFilterViewModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public IList<Sort> Sort { get; set; }
        public string FilterTerm { get; set; }
        public int FilterType { get; set; }
    }

    public class Sort
    {
        public string Column { get; set; }
        public string Direction { get; set; }
    }
}
