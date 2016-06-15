using System;
using System.IO;
using System.Windows.Forms;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using FastDFS.Client.Demo.ServiceReference1;
using FastDFS.WCF.Host.Contract;

namespace FastDFS.Client.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.Run(new Form2());


            //FileService service = new FileService();
            //byte[] bytes = File.ReadAllBytes("test.jpg");//读取图片字节流
            //foreach (byte b in bytes)
            //{
            //    File.AppendAllText("D:\\upload.txt", ((int)b)+Environment.NewLine);
            //}
            //File.WriteAllBytes("D:\\upload.jpg", bytes);//test

            //var tmp = service.Upload(bytes);//上传图片
            //byte[] res = service.DownLoad(tmp);//下载图片字节流

            //foreach (byte b in res)
            //{
            //    File.AppendAllText("D:\\download.txt", ((int)b) + Environment.NewLine);
            //}
            //File.WriteAllBytes("D:\\download.jpg", res);//test


            //System.IO.MemoryStream ms = new System.IO.MemoryStream(res);
            //System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            //Form1 frm=new Form1();
            //frm.pictureBox1.Image = img;
            //frm.textBox1.Text = System.Convert.ToBase64String(bytes);
            //frm.textBox2.Text = System.Convert.ToBase64String(res);
            //Application.Run(frm);
            //Console.ReadLine();


            //var client = new FileServiceClient();
            //client.ChangeGroup("G1");
            //DateTime dt1 = DateTime.Now;
            //for (int i = 0; i < 100; ++i)
            //{
            //    FileLocation q = client.Upload(File.ReadAllBytes("test2.png"));
            //    Console.WriteLine(q.FileId);
            //}
            //DateTime dt2 = DateTime.Now;
            //Console.WriteLine((dt2 - dt1).ToString());

            //Console.ReadLine();

            ;
            ;
            //client.DownLoad(q);
            ;
            ;

            var config = FastDfsManager.GetConfigSection();

            StorageNode storageNode = null;

            var fileName = "";

            do
            {
                Console.WriteLine("\r\n1.Init");
                Console.WriteLine("2.GetStorageNode");
                Console.WriteLine("3.UploadFile");
                Console.WriteLine("4.RemoveFile");
                Console.WriteLine("5.UploadSlaveFile");
                Console.WriteLine("6.UploadAppenderFile");
                Console.WriteLine("7.AppendFile");
                Console.WriteLine("8.DownloadFile");
                Console.WriteLine("9.GetFileInfo");

                Console.Write("请输入命令：");
                var cmd = Console.ReadLine();


                switch (cmd)
                {
                    case "1":
                        ConnectionManager.InitializeForConfigSection(config);
                        break;

                    case "2":
                        storageNode = FastDFSClient.GetStorageNode(config.GroupName);
                        Console.WriteLine("EndPoint:"+storageNode.EndPoint+Environment.NewLine
                            + "storageNode.StorePathIndex:"+storageNode.StorePathIndex);
                        break;

                    case "3":
                        DateTime dt1 = DateTime.Now;
                        for (int i = 0; i < 2; i++)
                        {
                            fileName = FastDFSClient.UploadFile(storageNode, File.ReadAllBytes("test2.png"), "png");
                            Console.WriteLine(fileName);
                        }
                        DateTime dt2 = DateTime.Now;
                        MessageBox.Show((dt2 - dt1).ToString());
                        break;

                    case "4":
                        FastDFSClient.RemoveFile(config.GroupName, fileName);
                        break;

                    case "5":
                        FastDFSClient.UploadSlaveFile(config.GroupName, File.ReadAllBytes("test.jpg"), @"M00/00/00/wKiK9VVKHqaARCZMAAInn_BrY3k965.jpg", "slave", "jpg");
                        break;
                    case "8":
                        var tt = FastDFSClient.DownloadFile(storageNode, fileName);
                        File.WriteAllBytes("D:\\download2.jpg", tt);
                        break;
                    case "9":
                        FastDFSClient.GetFileInfo(storageNode, @"M00/00/00/wKiK9VVKHqaARCZMAAInn_BrY3k965.jpg");
                        break;
                }

            } while (true);
        }
    }
}