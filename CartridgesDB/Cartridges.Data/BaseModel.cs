using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
