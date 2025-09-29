//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理DB仲介クラス
// プログラム概要   : 提供データ削除処理DBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 提供データ削除処理 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIOfferDataDeleteDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接RetGoodsReasonReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    public class MediationOfferDataDeleteDB
    {
        /// <summary>
        /// OfferDataDeleteDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public MediationOfferDataDeleteDB()
        {
        }
        /// <summary>
        /// IOfferDataDeleteDBインターフェース取得
        /// </summary>
        /// <returns>IOfferDataDeleteDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IOfferDataDeleteDBインターフェースを取得する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public static IOfferDataDeleteDB GetOfferDataDeleteDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);

#if DEBUG
            wkStr = "http://localhost:9002";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOfferDataDeleteDB)Activator.GetObject(typeof(IOfferDataDeleteDB), string.Format("{0}/MyAppOfferDataDelete", wkStr));
        }
    }
}
