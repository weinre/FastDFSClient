using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace FastDFS.WCF.Host.Contract
{
    [MessageContract]
    public class UploadFileInfo 
    {
        [MessageHeader]
        public string FileName { get; set; }

        [MessageBodyMember]
        public byte[] FileBytes { get; set; }
    }
}