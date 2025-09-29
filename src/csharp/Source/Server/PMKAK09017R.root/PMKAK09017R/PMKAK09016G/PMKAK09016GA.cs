//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表DB仲介クラス
// プログラム概要   : ISumSuppStPrintResultDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日  2012/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 仕入先総括マスタ一覧表 リモートオブジェクト仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISumSuppStPrintResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接MediationSumSuppStPrintResultDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    public class MediationSumSuppStPrintResultDB
    {
        /// <summary>
        /// MediationSumSuppStPrintResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public MediationSumSuppStPrintResultDB()
        {
        }
        /// <summary>
        /// ISumSuppStPrintResultDBインターフェース取得
        /// </summary>
        /// <returns>ISumSuppStPrintResultDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ISumSuppStPrintResultDBインターフェースを取得する。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public static ISumSuppStPrintResultDB GetSumSuppStPrintResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISumSuppStPrintResultDB)Activator.GetObject(typeof(ISumSuppStPrintResultDB), string.Format("{0}/MyAppSumSuppStPrintResult", wkStr));
        }
    }
}
