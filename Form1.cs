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

namespace VMBR_AutoUpdater
{
	public partial class Form1 : Form
	{

		public class jsona
		{
			public string version { get; set; }
		}


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			using (var client = new WebClient())
			{
				string homeFolderVMBR = @"C:\Users\"+Environment.UserName+@"\VMBR";
				string downloadToThisPath = @"C:\Users\" + Environment.UserName + @"\VMBR\AutoInstaller\"; //path
				string jsonPath = @"C:\Users\" + Environment.UserName + @"\VMBR\AutoInstaller\version.json"; // peth
				// If directory does not exist, create it. 
				if (!Directory.Exists(homeFolderVMBR))
				{
					Directory.CreateDirectory(homeFolderVMBR);
					Directory.CreateDirectory(downloadToThisPath);
				}
				WebClient webClient = new WebClient();
				//webClient.DownloadFile("http://raw.githubusercontent.com/MichaelEpicA/VMBattleRoyale/development/version.json", downloadToThisPath+@"version.json");
				string content = System.IO.File.ReadAllText(jsonPath);
				var version = JsonConvert.DeserializeObject<List<jsona>>(jsonPath);
				version.Select(appVer => appVer.version.Equals("version")); // painnnnn and suferinnnnngngggggggg
				versionLabel.Text = version.Select(appVer => appVer.version.Equals("version"));
			}


		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
