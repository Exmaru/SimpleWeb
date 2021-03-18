using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WEC_Builder
{
    public class ProjectInfo
    {

        public string Title { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public string ProjectFile
        {
            get
            {
                return System.IO.Path.Combine(Path, $"{Title}.wep");
            }
        }

        public ProjectInfo()
        {
        }
    }
}
