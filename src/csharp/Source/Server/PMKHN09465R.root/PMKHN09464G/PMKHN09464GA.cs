//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RateDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISingleGoodsRateDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接RateDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSingleGoodsRateDB
    {
        /// <summary>
        /// RateDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public MediationSingleGoodsRateDB()
        {
        }
        /// <summary>
        /// ISingleGoodsRateDBインターフェース取得
        /// </summary>
        /// <returns>ISingleGoodsRateDBオブジェクト</returns>
        public static ISingleGoodsRateDB GetSingleGoodsRateDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISingleGoodsRateDB)Activator.GetObject(typeof(ISingleGoodsRateDB), string.Format("{0}/MyAppSingleGoodsRate", wkStr));
        }
    }
}
