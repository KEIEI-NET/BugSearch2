using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Net;
using System.Web;
using System.Security.Cryptography;

namespace Broadleaf.Application.Common
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 在庫バッチ

            try
            {
                HttpWebRequest req = WebRequest.Create("https://scm-demo.magellanic-clouds.com/pm/users/0101150842021003/30146AFCD052B399F04EBAA63302A8D6450F94/batch/info") as HttpWebRequest;
                if (req == null)
                {
                    Console.WriteLine("nullでした。");
                    return;
                }
                req.Method = "GET";
                //req.ContentType = "application/json";
                //Stream s = req.GetRequestStream();
                //StreamWriter writer = new StreamWriter(s);
                //writer.WriteLine("{\"Status\":503}");
                //writer.Close();
                //★これはPM独自の認証KEYです。
                //req.Headers.Add("X-BL-PM-AUTHKEY", "831865880641F50A3A94B6884271D94FED394620");
                req.Headers.Add("X-BL-PM-AUTHKEY", "831865880641F50A3A94B6884271D94FED394620");

                //MagellanAuthUtils.AddOAuthInfo(req, "bl-rails-dev.app1", "tae5phoh4muchohdeisaep1ouquohgha9aingaiwooyaeLoobeoZooph8rahquoh");
                //MagellanAuthUtils.AddOAuthInfo(req, "bl-rails-dev.app3", "ahPhaixahb3raehooV9Po1ucae9en6rei4kiafeipheeSh2maijeijisheiW2ee9");


                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                if (res == null)
                {
                    Console.WriteLine("res is null");
                    return;
                }
                Console.WriteLine("HTTP STATUS:" + res.StatusCode);
            }
            catch (WebException e)
            {
                Console.WriteLine("HTTP STATUS:" + ((HttpWebResponse)e.Response).StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            #endregion
            //#region 在庫リアル
            //try{
            //    HttpWebRequest req = WebRequest.Create("https://scm-demo.magellanic-clouds.com/pm/users/0101150842021003/30146AFCD052B399F04EBAA63302A8D6450F94/stock") as HttpWebRequest;
            //    if (req == null)
            //    {
            //        Console.WriteLine("nullでした。");
            //        return;
            //    }
            //    req.Method = "PUT";
            //    //★これはPM独自の認証KEYです。
            //    req.Headers.Add("X-BL-PM-AUTHKEY", "831865880641F50A3A94B6884271D94FED394620");
            //    MagellanAuthUtils.AddOAuthInfo(req, "bl-rails-dev.app3", "ahPhaixahb3raehooV9Po1ucae9en6rei4kiafeipheeSh2maijeijisheiW2ee9");

            //    HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            //    if (res == null)
            //    {
            //        Console.WriteLine("res is null");
            //        return;
            //    }
            //    Console.WriteLine("HTTP STATUS:" + res.StatusCode);
            //}
            //catch (WebException e)
            //{
            //    Console.WriteLine("HTTP STATUS:" + ((HttpWebResponse)e.Response).StatusCode);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //}
            //#endregion

        }
    }
}
