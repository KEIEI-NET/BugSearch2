//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリストリDB仲介クラス
// プログラム概要   : IOrderSetMasListDBオブジェクトを取得します
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 発注点設定マスタリストリDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIDemoFeeMessDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			 完全スタンドアロンにする場合にはこのクラスで直接OrderSetMasListDBを</br>
    /// <br>			 インスタンス化して戻します。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationOrderSetMasListDB
    {
        /// <summary>
        /// 発注点設定マスタリストDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public MediationOrderSetMasListDB()
        {
        }

        /// <summary>
        /// IOrderSetMasListDBオブジェクトの取得
        /// </summary>
        /// <returns>IOrderSetMasListDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : IOrderSetMasListDBオブジェクトを取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public static IOrderSetMasListDB GetOrderSetMasListDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IOrderSetMasListDB)Activator.GetObject(typeof(IOrderSetMasListDB), string.Format("{0}/MyAppOrderSetMasList", wkStr));
        }
    }
}
