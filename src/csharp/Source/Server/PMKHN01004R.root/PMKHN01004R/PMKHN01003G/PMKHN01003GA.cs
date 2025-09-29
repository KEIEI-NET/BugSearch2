//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理DB 仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
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
    /// DataClearDB 仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIDataClearDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接DataClearDBを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationDataClearDB
    {
        /// <summary>
        /// DataClearDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public MediationDataClearDB()
        {
        }
        /// <summary>
        /// IDataClearDBインターフェース取得
        /// </summary>
        /// <returns>IDataClearDBオブジェクト</returns>
        public static IDataClearDB GetDataClearDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IDataClearDB)Activator.GetObject(typeof(IDataClearDB), string.Format("{0}/MyAppDataClear", wkStr));
        }
    }
}
