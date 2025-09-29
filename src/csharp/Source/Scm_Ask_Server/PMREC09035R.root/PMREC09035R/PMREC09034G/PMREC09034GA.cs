//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品グループ設定マスタ
// プログラム概要   : お買い得商品グループ設定マスタDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RecBgnGrpDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRecBgnGrpDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接RecBgnGrpDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRecBgnGrpDB
    {
        /// <summary>
        /// RecBgnGrpDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public MediationRecBgnGrpDB()
        {
        }

		/// <summary>
        /// IRecBgnGrpDBインターフェース取得
		/// </summary>
        /// <returns>IRecBgnGrpDBオブジェクト</returns>
        public static IRecBgnGrpDB GetRecBgnGrpDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);
            //string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRecBgnGrpDB)Activator.GetObject(typeof(IRecBgnGrpDB), string.Format("{0}/MyAppPMRecBgnGrp", wkStr));
        }
    }
}
