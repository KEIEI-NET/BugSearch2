using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;

namespace TestSFCMN00024C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OfflineDataSerializer ser = new OfflineDataSerializer();
            PartsRateWork rate = new PartsRateWork();
            rate.PartsSingleName1 = "1";
            rate.PartsSingleName2 = "2";
            rate.PartsSingleName3 = "3";
            rate.PartsSingleName4 = "4";
            rate.PartsSingleName5 = "5";
            rate.PartsSingleName6 = "6";
            rate.PartsSingleName7 = "7";

            string className = "TestSFCMN00024C";
            string[] keys = new string[] { "test1", "test2", "test3" };
            string path = Path.GetDirectoryName(this.GetType().Assembly.Location);

            ser.Serialize(className, keys, rate, path);

            //ここでデバッガでとめてファイル破壊

            object obj = ser.DeSerialize(className, keys, path);

            if (obj == null)
            {
                Console.WriteLine("obj はNULLです。");
            }
        }
    }
}