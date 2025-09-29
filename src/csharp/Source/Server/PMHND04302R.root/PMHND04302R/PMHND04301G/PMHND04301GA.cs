﻿//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル発注先ガイドDB仲介クラス
// プログラム概要   : ハンディターミナル発注先ガイドDB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// ハンディターミナル発注先ガイドDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIHandySupplierGuideDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接HandySupplierGuideDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationHandySupplierGuideDB
    {
        /// <summary>
        /// HandySupplierGuideDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public MediationHandySupplierGuideDB()
        {
        }

        /// <summary>
        /// IHandySupplierGuideDBインターフェース取得
        /// </summary>
        /// <returns>IHandySupplierGuideDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IHandyStockDBインターフェースを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public static IHandySupplierGuideDB GetHandySupplierGuideDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:8008";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IHandySupplierGuideDB)Activator.GetObject(typeof(IHandySupplierGuideDB), string.Format("{0}/MyAppHandySupplierGuide", wkStr));
        }
    }
}
