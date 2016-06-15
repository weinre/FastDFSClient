using System.Runtime.Serialization;

namespace FastDFS.WCF.Host.Contract
{
    /// <summary>
    /// 下载文件时的参数，需要提供组名和文件id
    /// </summary>
    [DataContract]
    public class FileLocation
    {
        [DataMember]
        public string GroupName { get; set; }//组名
        [DataMember]
        public string FileId { get; set; }//文件id
    }
}