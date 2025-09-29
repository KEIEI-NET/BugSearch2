using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 従業員ログイン(Felica対応版)DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 23002　上野 耕平</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationEmployeeLogin2DB
    {
        /// <summary>
        /// EmployeeLogin2DB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 23002　上野 耕平</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        public MediationEmployeeLogin2DB()
        {
        }

        /// <summary>
        /// IEmployeeLogin2DBインターフェース取得
        /// </summary>
        /// <param name="domainStr">プロトコル://ドメイン名:ポートNo/</param>
        /// <returns>GetEmployeeLogin2DBオブジェクト</returns>
        public static IEmployeeLogin2DB GetEmployeeLogin2DB(string domainStr)
        {
# if DEBUG
            //リモートオブジェクト取得
            domainStr = "http://localhost:9001";
# endif
            //リモートオブジェクト取得
            return (IEmployeeLogin2DB)Activator.GetObject(typeof(IEmployeeLogin2DB), string.Format("{0}/MyAppEmployeeLogin2", domainStr));
        }
    }
}
