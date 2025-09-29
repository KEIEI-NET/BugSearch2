//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換CustomerConvertDB仲介クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// CustomerConvertDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはICustomerConvertDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接CustomerConvertDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class MediationCustomerConvertDB
    {
        #region -- Constructor --

        // <summary>
        /// CustomerConvertDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public MediationCustomerConvertDB()
        {
            // 処理なし
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// ICustomerConvertDBインターフェース取得
        /// </summary>
        /// <returns>ICustomerConvertDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public static ICustomerConvertDB GetCustomerConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ICustomerConvertDB)Activator.GetObject(typeof(ICustomerConvertDB), string.Format("{0}/MyAppCustomerConvert", wkStr));
        }

        #endregion
    }
}
