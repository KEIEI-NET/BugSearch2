//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換EmployeeConvertDB仲介クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// EmployeeConvertDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIEmployeeConvertDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接EmployeeConvertDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class MediationEmployeeConvertDB
    {
        #region -- Constructor --

        // <summary>
        /// EmployeeConvertDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public MediationEmployeeConvertDB()
        {
            // 処理なし
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// IEmployeeConvertDBインターフェース取得
        /// </summary>
        /// <returns>IEmployeeConvertDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public static IEmployeeConvertDB GetEmployeeConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IEmployeeConvertDB)Activator.GetObject(typeof(IEmployeeConvertDB), string.Format("{0}/MyAppEmployeeConvert", wkStr));
        }

        #endregion
    }
}
