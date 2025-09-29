//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リモート伝発設定マスタメンテ
// プログラム概要   : リモート伝発設定マスタメンテDB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 欧方方
// 作 成 日  2011.08.03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// RmSlpPrtStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIRmSlpPrtStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接RmSlpPrtStDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 欧方方</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationRmSlpPrtStDB
    {
        /// <summary>
        /// SlipTypeMngDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public MediationRmSlpPrtStDB()
        {
        }
        /// <summary>
        /// IRmSlpPrtStDBインターフェース取得
        /// </summary>
        /// <returns>IRmSlpPrtStDBオブジェクト</returns>
        public static IRmSlpPrtStDB GetRmSlpPrtStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

#if DEBUG
            wkStr = "http://localhost:9002";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IRmSlpPrtStDB)Activator.GetObject(typeof(IRmSlpPrtStDB), string.Format("{0}/MyAppRmSlpPrtSt", wkStr));
        }
    }
}
