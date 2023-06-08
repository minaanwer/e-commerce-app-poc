using System.Text.Json.Serialization;
using System.Xml.Linq;
 namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1; 
        private int _pageSize = 6;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
        
       
      
        public string sort { get; set; } = "";

         public int? brandId { get; set; }

       
        public int? typeId { get; set; }
        private string _search="";
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value.ToLower();
            }

        } 
    }
}
