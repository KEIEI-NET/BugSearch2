//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CampTrgtPrintResultDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICampTrgtPrintResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接CampTrgtPrintResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCampTrgtPrintResultDB
    {
        /// <summary>
        /// SalTrgtPrintResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public MediationCampTrgtPrintResultDB()
        {
        }

        /// <summary>
        /// ICampTrgtPrintResultDBインターフェース取得
        /// </summary>
        /// <returns>ICampTrgtPrintResultDBオブジェクト</returns>
        public static ICampTrgtPrintResultDB GetCampTrgtPrintResultDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICampTrgtPrintResultDB)Activator.GetObject(typeof(ICampTrgtPrintResultDB), string.Format("{0}/MyAppCampTrgtPrintResult", wkStr));
        }
    }
}
