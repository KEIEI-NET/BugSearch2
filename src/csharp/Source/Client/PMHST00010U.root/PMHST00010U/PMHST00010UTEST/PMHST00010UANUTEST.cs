using System;
using System.Configuration;
using System.ServiceProcess;

using NUnit.Framework;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace System.ServiceProcess.ServiceBase
{
    [TestFixture]
    public class PMHST00010UANUTEST : ApplicationController
    {
        [SetUp]
        public void Setup()
        {
            _parameter = new string[] { "b74902bb-1fb4-4a30-bbe0-a344be9f18d0", "20000" };
            string msg = "";
            ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
        }
        private static void ApplicationReleased(object sender, EventArgs e)
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// ProcessStart_Test
        /// </summary>
        [Test(Description = "ProcessStart")]
        public void ProcessStart_Test()
        {
            try
            {
                ProcessStart();
            }
            finally
            {
            }
        }
        /// <summary>
        /// CreateUrl_Test
        /// </summary>
        [Test(Description = "CreateUrl")]
        public void CreateUrl_Test()
        {
            try
            {
                string url = "";
                CreateUrl(out url);

                Assert.AreEqual("HTTP://10.30.30.246:80/products/index.html", url);
            }
            finally
            {
            }
        }
        /// <summary>
        /// Replace_Test
        /// </summary>
        //[TestCase("0140150842030049","1.0.0")]
        //public void UrlReplace_Test(string enterpriseCode, string assemblyVersion)
        [Test(Description = "UrlReplace")]
        public void Replace_Test()
        {
            try
            {
                string domain = "HTTP://10.30.30.246:80"+"$enterpriseCode";
                string path = "/products/index.html" + "$assemblyVersion";

                // íuä∑
                string wkStr = UrlReplace(domain, path);

                Assert.AreEqual("HTTP://10.30.30.246:800140150842030049/products/index.html1.0.0", wkStr);
            }
            finally
            {
            }
        }
    }
}
