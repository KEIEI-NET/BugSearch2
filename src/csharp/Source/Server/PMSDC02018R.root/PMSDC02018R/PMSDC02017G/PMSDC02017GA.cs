//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 11570219-00      作成担当 : 田建委
// 作 成 日 2019/12/02       修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SalesCprtWorkDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalesCprtWorkDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接SalesCprtWorkDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// </remarks>
    public class MediationSalesCprtResultDB
    {
        /// <summary>
        /// SalesCprtWorkDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public MediationSalesCprtResultDB()
        {
        }
        /// <summary>
        /// ISalesCprtWorkDBインターフェース取得
        /// </summary>
        /// <returns>ISalesCprtWorkDBオブジェクト</returns>
        public static ISalesCprtWorkDB GetSalesCprtWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            // デバッグ用
#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalesCprtWorkDB)Activator.GetObject(typeof(ISalesCprtWorkDB), string.Format("{0}/MyAppISalesCprt", wkStr));
        }
    }
}
