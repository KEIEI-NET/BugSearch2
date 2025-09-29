//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷実績表
// プログラム概要   : 型式別出荷実績表 帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ModelShipResultDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIModelShipResultDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接ModelShipResultDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : zhshh</br>
    /// <br>Date       : 2010.04.22</br>
    /// <br></br>
    /// </remarks>
    public class MediationModelShipResultDB
    {
        /// <summary>
        /// ModelShipResultDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public MediationModelShipResultDB()
        {
        }
        /// <summary>
        /// IPrtmanageDBインターフェース取得
        /// </summary>
        /// <returns>IPrtmanageDBオブジェクト</returns>
        public static IModelShipResultDB GetModelShipWorkDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IModelShipResultDB)Activator.GetObject(typeof(IModelShipResultDB), string.Format("{0}/MyAppModelShipResult", wkStr));
        }
    }
}
