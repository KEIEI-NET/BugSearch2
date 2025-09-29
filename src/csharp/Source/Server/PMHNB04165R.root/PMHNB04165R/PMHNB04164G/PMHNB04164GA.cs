//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//


using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// 担当者別実績照会 DB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスは担当者別実績照会 DBRemoteObjectインターフェースオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接担当者別実績照会 リモートオブジェクトを</br>
    /// <br>			インスタンス化して戻します。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationEmployeeResultsListDB
    {
        /// <summary>
        /// 担当者別実績照会 DB仲介クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public MediationEmployeeResultsListDB()
        {
        }
        /// <summary>
        /// IEmployeeResultsListWorkDBインターフェース取得
        /// </summary>
        /// <returns>IEmployeeResultsListWorkDBオブジェクト</returns>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public static IEmployeeResultsListDB GetEmployeeResultsListDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            //return (IEmployeeResultsListDB)Activator.GetObject(typeof(IEmployeeResultsListDB), string.Format("{0}/MyAppEmployeeResultsList", wkStr));
            return (IEmployeeResultsListDB)Activator.GetObject(typeof(IEmployeeResultsListDB), string.Format("{0}/MyAppEmployeeResultsListWork", wkStr));
        }
    }
}
