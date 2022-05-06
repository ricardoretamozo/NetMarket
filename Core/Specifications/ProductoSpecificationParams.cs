using System;

namespace Core.Specifications
{
    public class ProductoSpecificationParams
    {
        public int? marcaId { get; set; }
        
        public  int? categoriaId { get; set; }
        
        public  string sort { get; set; }

        public int PageIndex { get; set; } = 1;
        
        public string Search { get; set; }

        private const int MaxPageSize = 50;

        private int _pageSize = 3;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}