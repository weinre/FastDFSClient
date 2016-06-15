using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using FastDFS.Client.Demo.webEyeSatisfactionSurvey;

namespace FastDFS.Client.Demo
{
    public partial class Form2 : Form
    {
        StorageNode storageNode = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var config = FastDfsManager.GetConfigSection();
            ConnectionManager.InitializeForConfigSection(config);
            storageNode = FastDFSClient.GetStorageNode(config.GroupName);
            textBox1.Text = FastDFSClient.UploadFile(storageNode, File.ReadAllBytes("test.jpg"), "jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(FastDFSClient.GetFileInfo(storageNode, textBox2.Text).Crc32.ToString());
            var tt = FastDFSClient.DownloadFile(storageNode, textBox2.Text);
            Stream  stream=new MemoryStream(tt);

            pictureBox1.Image = Image.FromStream(stream);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webEyeSatisfactionSurvey.SurveyServiceClient client = new webEyeSatisfactionSurvey.SurveyServiceClient("WsHttpBinding_SatisfactionSurvey_ISurvey");
            client.ClientCredentials.UserName.UserName = "eyeWcfUser";
            client.ClientCredentials.UserName.Password = "wcf88068896";
            //client.Init("optometry2003", "003"); //短信发送端口
            //client.SendSMShort(
            //    "15105777745",
            //    "content",
            //    "13971",
            //    "戴美权",
            //    "018",
            //    "信息中心"
            //    );
            client.SendSatisfactionSurvey(new SurveyDataEntity
            {
                Kind = "门诊医生",
                PatientName = "戴美权",
                EmployeeName = "戴美权",
                Mobile = "15105777745",
            });
        }
    }
}
