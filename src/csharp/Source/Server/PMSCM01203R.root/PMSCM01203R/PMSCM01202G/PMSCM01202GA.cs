//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   自動送受信バッチ処理クラス                    //
//                  :   PMSCM01203R.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting.Adapter        //
// Programmer       :   qianl                                         //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// BackUpExecutionDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIBackUpExecutionDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接BackUpExecutionDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2011.07.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationISndAndRcvCSVDB
    {
        /// <summary>
        /// BackUpExecutionDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        public MediationISndAndRcvCSVDB()
        {
        }

		/// <summary>
        /// IBackUpExecutionDBインターフェース取得
		/// </summary>
        /// <returns>IBackUpExecutionDBオブジェクト</returns>
        public static ISndAndRcvCSVDB GetSndAndRcvCSVDBDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISndAndRcvCSVDB)Activator.GetObject(typeof(ISndAndRcvCSVDB), string.Format("{0}/MyAppSndAndRcvCSV", wkStr));
        }
    }
}
