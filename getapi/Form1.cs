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

namespace getapi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL = string.Format("https://graph.facebook.com/me?access_token=" + textBox1.Text);
            WebRequest reQuest = WebRequest.Create(URL);
            reQuest.Method = "GET";
            HttpWebResponse resPonse = null;
            resPonse = (HttpWebResponse)reQuest.GetResponse();
            using (Stream stream = resPonse.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                string json = sr.ReadToEnd();
                sr.Close();
                Root myRoot = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(json);
                MessageBox.Show(myRoot.error.code);
            }          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
    public class Error
    {
        public string message { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string fbtrace_id { get; set; }

    }

    public class Root
    {
        public Error error { get; set; }

    }

}
