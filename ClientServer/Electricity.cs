using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientServer
{
    public partial class Electricity : Form
    {
        public Electricity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Personal_Check = textBox1.Text;
            string uri = "https://localhost:44318/api/Values";
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = new WebProxy() { UseDefaultCredentials = true };
            req.Headers.Add("Erbol", "application/json");
            List<Clients> result = new List<Clients>();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            string res = "";
            try
            {
                var response = (HttpWebResponse)req.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                res = responseString.ToString();
                List<Clients> json = JsonConvert.DeserializeObject<List<Clients>>(res);
                int i = 0;
                foreach (var value in json)
                {

                }

            }
            catch (Exception ex)
            {
                res = "Ошибка подключения к интегрированному сервису:" + ex.Message;
                MessageBox.Show(res);
            }
        }

    }
}

