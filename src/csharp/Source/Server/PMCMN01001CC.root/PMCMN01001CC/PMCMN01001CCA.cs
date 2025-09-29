using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// ユーザーAPリモートプロキシサーバークラスリソース（個別配信用）
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはリモートオブジェクトのプロキシクラス用リソースです。</br>
    /// <br>Programmer : wangf</br>
    /// <br>Date       : 2012/07/05</br>
    /// <br>Update Note: K2014/12/12 chenyk </br>
    /// <br>           : 11070149-00、個別配信、Redmine#30682 障害の対応</br>
    /// </remarks>
    //public class Tbs001ServerServiceResource // DEL chenyk 2014/12/12
    public class CustomServerServiceResource // ADD chenyk 2014/12/12
    {
        /// <summary>
        /// リソース情報取得
        /// </summary>
        /// <returns>リソース情報</returns>
        /// <remarks>
        /// <br>Note       : リソース情報取得を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/07/05</br>
        /// </remarks>
        public static List<RemoteAssemblyInfo> GetRemoteResource()
        {
            List<RemoteAssemblyInfo> retList = new List<RemoteAssemblyInfo>();

            return retList;
        }
    }
}
