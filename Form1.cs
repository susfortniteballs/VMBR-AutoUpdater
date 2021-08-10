using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VMBR_AutoUpdater
{
	public partial class Form1 : Form
	{


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			using (var client = new WebClient())
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string homeFolderVMBR = @"C:\Users\"+Environment.UserName+@"\VM Battle Royale";
				string downloadToThisPath = @"C:\Users\" + Environment.UserName + @"\VM Battle Royale\AutoInstaller\"; //path
				string jsonPath = @"C:\Users\" + Environment.UserName + @"\VM Battle Royale\AutoInstaller\version.json"; // peth
				// If directory does not exist, create it. 
				if (!Directory.Exists(homeFolderVMBR))
				{
					Directory.CreateDirectory(homeFolderVMBR);
					Directory.CreateDirectory(downloadToThisPath);
				}
				client.DownloadFile("https://raw.githubusercontent.com/MichaelEpicA/VMBattleRoyale/development/version.json", jsonPath);
				string content = System.IO.File.ReadAllText(jsonPath);
				string version = JObject.Parse(content)["version"].ToObject<JValue>().Value.ToString();
				// painnnnn and suferinnnnngngggggggg
				versionLabel.Text = version;
			}


		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
