//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesHistoryJoinWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesSliptextResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesSliptextResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// </remarks>
    public class MediationSalesSliptextResultDB
    {
        /// <summary>
        /// SalesSliptextResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : SalesSliptextResultDB仲介クラスコンストラクタ</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public MediationSalesSliptextResultDB()
        {
        }

        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IPrtmanageDBインターフェース取得</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public static ISalesSliptextResultDB GetSalesSliptextResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // デバッグ用
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesSliptextResultDB)Activator.GetObject(typeof(ISalesSliptextResultDB), string.Format("{0}/MyAppSalesSliptextResult", wkStr));
        }
    }
}
