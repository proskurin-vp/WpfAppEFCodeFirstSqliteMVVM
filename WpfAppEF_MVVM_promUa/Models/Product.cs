using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEF_MVVM_promUa.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public int Quantity { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
