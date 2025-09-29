//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品MAX入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 陳艶丹
// 作 成 日  2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationPartsMaxStockArrivalDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : このクラスはIMediationPartsMaxStockArrivalDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>              完全スタンドアロンにする場合にはこのクラスで直接IMediationPartsMaxStockArrivalDBを</br>
    /// <br>              インスタンス化して戻します。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    public class MediationPartsMaxStockArrivalDB
    {
        /// <summary>
        /// YamanakaSalesGoodsAchieveDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public MediationPartsMaxStockArrivalDB()
        {
        }

        /// <summary>
        /// IPartsMaxStockArrivalDBインターフェース取得
        /// </summary>
        /// <returns>IPartsMaxStockArrivalDBオブジェクト</returns>
        public static IPartsMaxStockArrivalDB GetPartsMaxStockArrivalDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif   
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IPartsMaxStockArrivalDB)Activator.GetObject(typeof(IPartsMaxStockArrivalDB), string.Format("{0}/MyAppPartsMaxStockArrival", wkStr));
        }
    }
}
