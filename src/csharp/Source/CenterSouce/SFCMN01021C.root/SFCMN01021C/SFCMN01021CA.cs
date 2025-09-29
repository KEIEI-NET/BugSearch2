using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// ユーザーAPリモートプロキシサーバークラスリソース
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはリモートオブジェクトのプロキシクラス用リソースです。</br>
    /// <br>Programmer : 20402　杉村 利彦</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/16 22018 鈴木 正臣</br>
    /// <br>           : SCM統合プロジェクト 拠点管理改良対応</br>
    /// <br></br>
    /// <br>Update Note: 2014/09/24 22008 長内 数馬</br>
    /// <br>           : SCM高速化対応 通信ログデータ更新用リモート追加</br>
    /// <br>Update     : 2015/10/08 30350 櫻井 亮太</br>
    /// <br>           : 11170140-00 LSMサーバー配信改良 LSMログアップデータを追加</br>
    /// <br>Update Note: 2020/05/29 31794 志賀 紀之</br>
    /// <br>           : 11570229-00 拠点管理サーバAWS移行　通信チェックツールの追加</br>
    /// </remarks>
    public class Tbs021ServerServiceResource
    {
        /// <summary>
        /// リソース情報取得
        /// </summary>
        /// <returns>リソース情報</returns>
        public static List<RemoteAssemblyInfo> GetRemoteResource()
        {
            List<RemoteAssemblyInfo> retList = new List<RemoteAssemblyInfo>();

            #region 置換開始位置
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN00021R.DLL", "Broadleaf.Application.Remoting.VersionChkWorkDB", "MyAppVersionChkWorkDB", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07401R.DLL", "Broadleaf.Application.Remoting.DCControlDB", "MyAppDCControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07410R.DLL", "Broadleaf.Application.Remoting.DCSalesSlipDB", "MyAppDCSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07420R.DLL", "Broadleaf.Application.Remoting.DCSalesDetailDB", "MyAppDCSalesDetail", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07430R.DLL", "Broadleaf.Application.Remoting.DCSalesHistoryDB", "MyAppDCSalesHistory", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07440R.DLL", "Broadleaf.Application.Remoting.DCSalesHistDtlDB", "MyAppDCSalesHistDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07450R.DLL", "Broadleaf.Application.Remoting.DCDepsitMainDB", "MyAppDCDepsitMain", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07460R.DLL", "Broadleaf.Application.Remoting.DCDepsitDtlDB", "MyAppDCDepsitDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07470R.DLL", "Broadleaf.Application.Remoting.DCStockSlipDB", "MyAppDCStockSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07480R.DLL", "Broadleaf.Application.Remoting.DCStockDetailDB", "MyAppDCStockDetail", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07490R.DLL", "Broadleaf.Application.Remoting.DCStockSlipHistDB", "MyAppDCStockSlipHist", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07500R.DLL", "Broadleaf.Application.Remoting.DCStockSlHistDtlDB", "MyAppDCStockSlHistDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07510R.DLL", "Broadleaf.Application.Remoting.DCPaymentSlpDB", "MyAppDCPaymentSlp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07520R.DLL", "Broadleaf.Application.Remoting.DCPaymentDtlDB", "MyAppDCPaymentDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07530R.DLL", "Broadleaf.Application.Remoting.DCAcceptOdrDB", "MyAppDCAcceptOdr", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07540R.DLL", "Broadleaf.Application.Remoting.DCAcceptOdrCarDB", "MyAppDCAcceptOdrCar", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07550R.DLL", "Broadleaf.Application.Remoting.DCMTtlSalesSlipDB", "MyAppDCMTtlSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07560R.DLL", "Broadleaf.Application.Remoting.DCGoodsMTtlSaSlipDB", "MyAppDCGoodsMTtlSaSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07570R.DLL", "Broadleaf.Application.Remoting.DCMTtlStockSlipDB", "MyAppDCMTtlStockSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO06401R.DLL", "Broadleaf.Application.Remoting.MstDCControlDB", "MyAppMstDCControl", WellKnownObjectMode.Singleton ) );
            #endregion

            // --- ADD m.suzuki 2011/08/16 ---------->>>>>
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09405R.DLL", "Broadleaf.Application.Remoting.SndRcvHisDB", "MyAppSndRcvHis", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09505R.DLL", "Broadleaf.Application.Remoting.SndRcvHisTableDB", "MyAppSndRcvHisTable", WellKnownObjectMode.Singleton ) );
            // --- ADD m.suzuki 2011/08/16 ----------<<<<<
            // --- ADD -------- 2014/09/24 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKYO00201R.DLL", "Broadleaf.Application.Remoting.APNSNetworkTestDB", "MyAppAPNSNetworkTest", WellKnownObjectMode.Singleton));
            // --- ADD -------- 2014/09/24 ---------->>>>>

            // --- ADD r.sakurai 2015/10/08 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00086R.DLL", "Broadleaf.Application.Remoting.LsmHisLogDB", "MyAppLsmHisLog", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00091R.DLL", "Broadleaf.Application.Remoting.LsmChkWordDB", "MyAppLsmChkWord", WellKnownObjectMode.Singleton));
            // --- ADD r.sakurai 2015/10/08 ---------->>>>>

            // --- ADD n.shiga 2015/10/08 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "NsNetworkChkAwsR.dll", "Broadleaf.Application.Remoting.AWSCommTstRsltDB", "MyAppAWSCommTstRslt", WellKnownObjectMode.Singleton));
            // --- ADD n.shiga 2015/10/08 ----------<<<<<

            return retList;
        }
    }
}
