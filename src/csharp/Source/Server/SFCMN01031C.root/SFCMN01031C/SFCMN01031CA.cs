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
    /// <br>Update Note: </br>
    /// </remarks>
    public class Tbs031ServerServiceResource
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
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07701R.DLL", "Broadleaf.Application.Remoting.SKControlDB", "MyAppSKControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO06701R.DLL", "Broadleaf.Application.Remoting.MstTotalMachControlDB", "MyAppMstTotalMachControl", WellKnownObjectMode.Singleton ) );
            #endregion

            return retList;
        }
    }
}
