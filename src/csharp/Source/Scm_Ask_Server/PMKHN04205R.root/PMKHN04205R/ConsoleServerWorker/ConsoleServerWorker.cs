using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServerWorker
{
    /// <summary>
    /// Class1 の概要の説明です。
    /// </summary>
    class Class1
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            ScmInqLogInquiryDB _scmInqLogDB = new ScmInqLogInquiryDB();

            //サーバーログイン部品準備
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS);

#if DEBUG
            Console.WriteLine("他社部品検索履歴照会 - Debug");
#else
            Console.WriteLine("他社部品検索履歴照会  - Release");
#endif

            Console.ReadLine();
        }
    }
}
