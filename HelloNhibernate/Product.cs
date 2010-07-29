using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace HelloNhibernate
{
    public class Product
    {
        public virtual int? ProductId { get; set; }
        public virtual string ProductName { get; set; }
    }
}
