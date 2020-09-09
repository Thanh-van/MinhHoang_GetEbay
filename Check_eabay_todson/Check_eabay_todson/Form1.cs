using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //keywordSearch = txtKeyword.Text.Trim();
            Thread newThread = new Thread(DoWork);
            newThread.Start();

        }
        /// <summary>
        /// Load link-product ebay 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public void LoadPageEbayByKeyword(string keyword)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            //client.Headers["User-Agent"] = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.5 Mobile/15E148 Snapchat/10.77.5.59 (like Safari/604.1)";
            string htmlRequest = client.DownloadString($"https://www.ebay.com/sch/i.html?_nkw={keyword}");
            if (true)
            {

            }


            MatchCollection mcLinkProduct = Regex.Matches(htmlRequest, "<a (.+?) class=s-item__link href=(.+?)>(.+?)</a>");
            if (mcLinkProduct.Count != 0)
            {
                foreach (Match item in mcLinkProduct)
                {
                    //linkProductModel.NameProduct = item.Groups[2].Value.Trim();
                    String link_product = item.Groups[2].Value.Trim();
                    //WriteLogHistory(link_product, Color.Green);
                    LoadLink(link_product);
                    break;
                }
            }

        }
        public String LoadLink(string link)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            //client.Headers["User-Agent"] = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.5 Mobile/15E148 Snapchat/10.77.5.59 (like Safari/604.1)";
            string htmlRequest = client.DownloadString($"{link}");
            //WriteLogSolid(htmlRequest, Color.Green);
            if (true)
            {

            }

            MatchCollection mcLinksolod = Regex.Matches(htmlRequest, "<a class=\"vi-txt-underline\" href=(.+?)>(.+?)</a>");
            if (mcLinksolod.Count != 0)
            {
                MatchCollection mcLinkProduct = Regex.Matches(htmlRequest, "<h1 (.+?)>(.+?)</span>(.+?)</h1>");
                foreach (Match item in mcLinkProduct)
                {
                    String name = item.Groups[3].Value.Trim();
                    if (name == null)
                        name = "Thanh Van";
                    WriteLogSolid(link, Color.Red);
                    WriteLogSolid(name, Color.Green);

                    break;
                }
                foreach (Match item in mcLinksolod)
                {

                    String soild = item.Groups[2].Value.Trim();
                    WriteLogSolid(soild, Color.Green);
                    //WriteLogSolid(link, Color.Red);
                    break;
                }

            }
            //else
            //{
            //	WriteLogSolid("Thanh Van", Color.Red);
            //}

            return "";
        }
        private void WriteLogSolid(string logText, Color status)
        {
            //_busy.WaitOne();
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtlogebay.Select(0, 0);
                    txtlogebay.SelectionColor = status;
                    txtlogebay.SelectedText = DateTime.Now.ToString("HH:mm:ss") + " : " + logText + "\r\n";
                    //var lines = txtLogHistory.Lines;
                    //txtLogHistory.Lines = lines.Skip(lines.Length - 20).ToArray();
                    return;
                }));
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// Load name product link
        /// </summary>
        /// 
        public bool NameProduct(string htmlRequest)
        {
            MatchCollection mcLinkProduct = Regex.Matches(htmlRequest, "<h5><a(.+?)>(.+?)</a></h5>");
            if (mcLinkProduct.Count > 1)
            {
                foreach (Match item in mcLinkProduct)
                {
                    String dl = item.Groups[2].Value.Trim();
                    if (dl != "Tags")
                    {
                        WriteLogHistory(dl, Color.Green);
                        LoadPageEbayByKeyword(dl);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Loadtdson()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            List<String> str = new List<String>();
            str.Add("velox");
            str.Add("onguard");
            str.Add("elite");
            str.Add("topeak");
            foreach (var item in str)
            {
                int x = 0, i = 0;
                WriteLogHistory("------------------Đầu "+item+"----------------------------", Color.Red);
                while (x != 1)
                    while (x != 1)
                {
                    i++;
                    client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36";
                    string velox = client.DownloadString($"https://www.todson.com/collections/{item}?page={i}");
                    if (NameProduct(velox))
                            NameProduct(velox);
                    else
                        x = 1;
                }
                WriteLogHistory("------------------Hết " + item + "----------------------------", Color.Red);
            }
            
        }

        private void WriteLogHistory(string logText, Color status)
        {
            //_busy.WaitOne();
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogHistory.Select(0, 0);
                    txtLogHistory.SelectionColor = status;
                    txtLogHistory.SelectedText = DateTime.Now.ToString("HH:mm:ss") + " : " + logText + "\r\n";
                    return;
                }));
            }
            catch (Exception)
            {
                return;
            }
        }
        private void WriteLogEbay(string logText, Color status)
        {
            //_busy.WaitOne();
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtlogebay.Select(0, 0);
                    txtlogebay.SelectionColor = status;
                    txtlogebay.SelectedText = DateTime.Now.ToString("HH:mm:ss") + " : " + logText + "\r\n";
                    return;
                }));
            }
            catch (Exception)
            {
                return;
            }
        }
        public void DoWork()
        {
            Loadtdson();

        }
    }
}
