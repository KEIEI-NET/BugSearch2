//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表DB仲介クラス
// プログラム概要   : IRetGoodsReasonReportResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/11  修正内容 : 新規作成
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
    /// 返品理由一覧表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRetGoodsReasonReportResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接RetGoodsReasonReportResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.11</br>
    /// </remarks>
    public class MediationRetGoodsReasonReportResultDB
    {
        /// <summary>
        /// RetGoodsReasonReportResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public MediationRetGoodsReasonReportResultDB()
        {
        }
        /// <summary>
        /// IRetGoodsReasonReportResultDBインターフェース取得
        /// </summary>
        /// <returns>IRetGoodsReasonReportResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IRetGoodsReasonReportResultDBインターフェースを取得する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        public static IRetGoodsReasonReportResultDB GetRetGoodsReasonReportResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRetGoodsReasonReportResultDB)Activator.GetObject(typeof(IRetGoodsReasonReportResultDB), string.Format("{0}/MyAppRetGoodsReasonReportResult", wkStr));
        }
    }
}
