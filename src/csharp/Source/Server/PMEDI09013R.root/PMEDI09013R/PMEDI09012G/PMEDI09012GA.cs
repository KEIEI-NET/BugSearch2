//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : EDI連携設定マスタDB仲介クラス
// プログラム概要   : EDI連携設定マスタDB仲介クラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/16   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EDICooperatStDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEDICooperatStDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接EDICooperatStDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/16</br>
    /// </remarks>
    public class MediationEDICooperatStDB
    {
        /// <summary>
        /// SAndESettingDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public MediationEDICooperatStDB()
        {

        }

        /// <summary>
        /// IEDICooperatStDBインターフェース取得
        /// </summary>
        /// <returns>IEDICooperatStDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IEDICooperatStDBインターフェースを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public static IEDICooperatStDB GetEDICooperatStDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEDICooperatStDB)Activator.GetObject(typeof(IEDICooperatStDB), string.Format("{0}/MyAppEDICooperatSt", wkStr));
        }
    }
}
