using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxFileManagerCore.ModelData.Models
{
    public class NewUploadFile
    {

        
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public bool IsStored { get; set; }
        public bool IsImage { get; set; }
        public string CdnUrl { get; set; }
        //public string CdnUrlModifers { get; set; }
        //public string MimeType { get; set; }
        //public string OrignalUrl { get; set; }
        //public string[] OrginalImageInfo { get; set; }
        //public string[] SourceInfo { get; set; }

    }
}
