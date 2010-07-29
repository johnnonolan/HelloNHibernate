using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acme.Model
{
    public class Product
    {
        public virtual int? ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual UnitOfMeasure UOM { get; set; }
    }
}
