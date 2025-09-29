//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
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
    /// CarManagementDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICarManagementDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CarManagementDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.09.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationCarShipmentPartsDispDB
    {
        /// <summary>
        /// CarManagementDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public MediationCarShipmentPartsDispDB()
        {

        }

        /// <summary>
        /// ICarManagementDBインターフェース取得
        /// </summary>
        /// <returns>ICarManagementDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : ICarManagementDBの処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public static ICarShipmentPartsDispDB GetCarShipmentPartsDispDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICarShipmentPartsDispDB)Activator.GetObject(typeof(ICarShipmentPartsDispDB), string.Format("{0}/MyAppCarShipmentPartsDisp", wkStr));
        }
    }
}
