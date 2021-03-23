using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEC_Builder
{
    public class ObjectEntity
    {
        public string ObjectType { get; set; } = string.Empty;

        public int object_id { get; set; } = -1;
        public string name { get; set; } = string.Empty;

        public ObjectEntity()
        {
        }
    }
}
