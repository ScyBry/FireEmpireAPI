using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.RequestFeatures
{

    public abstract class QueryStringParameters
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, MaxPageSize)]
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }
    }


    public class ProductParameters : QueryStringParameters
    {
        public ProductParameters() => OrderBy = "ProductName";

        public string Category { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MinPrice { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MaxPrice { get; set; }

        public HazardClass? HazardClass { get; set; }

        public string SearchTerm { get; set; }


    }
}
