using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            EmployeeLogin2DB employeeLogin2DB = new EmployeeLogin2DB();
            if( !ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP) )
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "サーバーログイン部品準備の準備に失敗しました。サーバー環境が正しいかどうか確認してください。", null, -8);
            }
            Console.ReadLine();
        }
    }
}
