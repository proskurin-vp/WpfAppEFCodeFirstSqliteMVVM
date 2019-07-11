using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEF_MVVM_promUa.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
