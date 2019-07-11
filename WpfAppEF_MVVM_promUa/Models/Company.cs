using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEF_MVVM_promUa.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
