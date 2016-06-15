using System;
using System.IO;
using FastDFS.Client;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using FastDFS.WCF.Host.Contract;

namespace FastDFS.WCF.Host
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class FileService : IFileService
    {
        private StorageNode storageNode;

        public FileService()
        {
            Init(FastDfsManager.GetConfigSection());
        }



        /// <summary>
        ///     初始化连接
        /// </summary>
        /// <param name="config"></param>
        public void Init(FastDfsConfig config)
        {
            try
            {
                ConnectionManager.InitializeForConfigSection(config);
                storageNode = FastDFSClient.GetStorageNode(config.GroupName);
            }
            catch (Exception ex)
            {
                
                File.AppendAllText(DateTime.Now.ToShortDateString() + ".log",ex.Message);
                throw;
            }
        }

        /// <summary>
        ///     修改组
        /// </summary>
        /// <param name="groupName"></param>
        public void ChangeGroup(string groupName)
        {
            storageNode = FastDFSClient.GetStorageNode(groupName);
        }

        public FileLocation Upload(byte[] bytes)
        {
            try
            {
                string fileName = FastDFSClient.UploadFile(storageNode, bytes, "dfs");
                return new FileLocation
                {
                    GroupName = storageNode.GroupName,
                    FileId = fileName
                };
            }
            catch (Exception ex)
            {
                File.AppendAllText(DateTime.Now.ToShortDateString() + ".log",ex.Message);
                throw;
            }
        }

        public byte[] DownLoad(FileLocation fileLocation)
        {
            StorageNode node = FastDFSClient.GetStorageNode(fileLocation.GroupName);
            return FastDFSClient.DownloadFile(node, fileLocation.FileId);
        }
    }
}