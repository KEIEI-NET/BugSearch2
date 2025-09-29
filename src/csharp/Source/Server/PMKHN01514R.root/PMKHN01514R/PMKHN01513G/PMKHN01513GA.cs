//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/15  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MonthlyTtlStockUpdDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはMediationYuuRyouDataDelDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接MediationYuuRyouDataDelDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer	: 梁森東</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationYuuRyouDataDelDB
    {
        /// <summary>
        /// MediationYuuRyouDataDelDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public MediationYuuRyouDataDelDB()
        {

        }

        /// <summary>
        /// IYuuRyouDataDelDBインターフェース取得
        /// </summary>
        /// <returns>IYuuRyouDataDelDBオブジェクト</returns>
        public static IYuuRyouDataDelDB GetYuuRyouDataDelDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IYuuRyouDataDelDB)Activator.GetObject(typeof(IYuuRyouDataDelDB), string.Format("{0}/MyAppYuuRyouDataDel", wkStr));
        }
    }
}
