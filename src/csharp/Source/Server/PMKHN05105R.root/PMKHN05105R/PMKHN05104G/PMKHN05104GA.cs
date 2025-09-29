//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換WarehouseConvertDB仲介クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// WarehouseConvertDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはIWarehouseConvertDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接WarehouseConvertDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class MediationWarehouseConvertDB
    {
        // <summary>
        /// WarehouseConvertDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public MediationWarehouseConvertDB()
        {
            // 処理なし
        }

        /// <summary>
        /// IWarehouseConvertDBインターフェース取得
        /// </summary>
        /// <returns>IWarehouseConvertDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public static IWarehouseConvertDB GetWarehouseConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IWarehouseConvertDB)Activator.GetObject(typeof(IWarehouseConvertDB), string.Format("{0}/MyAppWarehouseConvert", wkStr));
        }
    }
}
