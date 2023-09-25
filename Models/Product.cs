using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Lager.Models
{
    public class Product
    {
        public string? productTitle { get; set; }
        public string? groupId { get; set; }
        public string? price { get; set; }
        public string? size { get; set; }
        public string? description { get; set; }
    }
}
