using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BasketItems
    {
        public int Id { get; set; }
    
      public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public String PictureUrl { get; set; }

        public String Brand { get; set; }

        public String Type { get; set; }


    }
}
