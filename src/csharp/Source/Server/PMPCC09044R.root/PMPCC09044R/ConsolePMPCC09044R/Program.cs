using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace ConsolePMPCC09044R
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
         
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

            Broadleaf.Application.Remoting.PccItemGrpDB ROBJ = new PccItemGrpDB();

            Console.ReadLine();
        }
    }
}
