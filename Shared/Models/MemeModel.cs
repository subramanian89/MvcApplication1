using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Models
{
    public class MemeModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        public long Vote { get; set; }
    }
}
