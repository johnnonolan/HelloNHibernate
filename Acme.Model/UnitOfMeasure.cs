using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acme.Model
{
    public class UnitOfMeasure
    {
        public virtual int? UomId { get; set; }
        public virtual string UomDescription { get; set; }
    }
}
