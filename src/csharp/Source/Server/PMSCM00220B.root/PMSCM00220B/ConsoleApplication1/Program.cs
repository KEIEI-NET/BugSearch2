using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sync();
            FirstBatchSync();
        }

        public static void FirstBatchSync()
        {

            SyncBasicInfo info = new SyncBasicInfo();
            info.PmSyncUrl = "http://10.30.30.246";
            info.EnterpriseCode = "0101150842021003";
            info.PmDbId = "test";
            //info.PmSyncUrl = "http://localhost:8080/pmscm/";

            ReplicaDBAccessControl controller = new ReplicaDBAccessControl(info);
            /*
            long transactionId = 12346;
            //controller.FirstSyncStart(transactionId, 0);
            SyncReqDataWork work = new SyncReqDataWork();
            List<SyncReqDataWork> workList = new List<SyncReqDataWork>();
            string tableId = "";
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    tableId = "STOCKRF";
                }
                else
                {
                    tableId = "RATERF";
                }
                //workList.Clear();
                for (int j = 0; j < 10; j++)
                {
                    work = new SyncReqDataWork();
                    work.UpdateDateTime = DateTime.Now;
                    work.CreateDateTime = DateTime.Now;
                    work.EnterpriseCode = info.EnterpriseCode;
                    work.LogicalDeleteCode = 0;
                    work.SyncObjRecKeyItmId = "KEY-A\tKEY-B\tKEY-C\t";
                    work.SyncObjRecKeyVal = string.Format("KEYA{0}\tKEYB{0}\tKEYC{0}\t", j);
                    work.SyncObjRecUpdItmId = "VAL-A";
                    work.SyncObjRecUpdVal = "VALA" + j;
                    work.SyncProcDiv = 1;
                    work.SyncReqDiv = 1;
                    work.SyncTableID = tableId;
                    work.SyncTargetDiv = 0;
                    work.TransctId = transactionId;
                    workList.Add(work);
                }
                //controller.FirstSyncWrite(transactionId,"", workList);

            }
            //int status = controller.TranslateStart(transactionId);
  
            Console.WriteLine("res.Status:" + status);
            */
        }
    }
}
