//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタエクスポートDB仲介クラス
// プログラム概要   : 掛率マスタエクスポートDB仲介する
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-**  作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12   修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : K.Miura
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMas → RateText
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 黒澤　直貴
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   MediationStockMasDB → MediationRateTextDB
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 掛率マスタエクスポートDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIStockMasDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接RateTextDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12 </br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
// --- CHG  2015/10/14 黒澤 直貴 --- >>>>
//  public class MediationStockMasDB
    public class MediationRateTextDB     
// --- CHG  2015/10/14 黒澤 直貴 --- <<<<
    {
        /// <summary>
        /// RateTextDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12 </br>
        /// </remarks>
// --- CHG  2015/10/14 黒澤 直貴 --- >>>>
//      public MediationStockMasDB()
        public MediationRateTextDB()
// --- CHG  2015/10/14 黒澤 直貴 --- <<<<
        {

        }

        /// <summary>
        /// IStockMasDBインターフェース取得
        /// </summary>
        /// <returns>IStockMasDBオブジェクト</returns>
// --- CHG  2015/10/14 K.Miura --- >>>>
//      public static IStockMasDB GetStockMasDB()
        public static IRateTextDB GetRateTextDB()
// --- CHG  2015/10/14 K.Miura --- <<<<
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
// --- CHG  2015/10/14 K.Miura --- >>>>
//            return (IRateTextDB)Activator.GetObject(typeof(IRateTextDB), string.Format("{0}/MyAppStockMas", wkStr));
              return (IRateTextDB)Activator.GetObject(typeof(IRateTextDB), string.Format("{0}/MyAppRateText", wkStr));
// --- CHG  2015/10/14 K.Miura --- <<<<
        }
    }
}
