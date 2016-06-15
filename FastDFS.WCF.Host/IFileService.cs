using System.ServiceModel;
using FastDFS.WCF.Host.Contract;

namespace FastDFS.WCF.Host
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        FileLocation Upload(byte[] bytes);

        [OperationContract]
        void ChangeGroup(string groupName);

        [OperationContract]
        byte[] DownLoad(FileLocation fileLocation);
    }



}
