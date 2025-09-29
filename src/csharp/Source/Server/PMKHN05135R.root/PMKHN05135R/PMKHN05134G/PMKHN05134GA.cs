//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換SectionConvertDB仲介クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// SectionConvertDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISectionConvertDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SectionConvertDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class MediationSectionConvertDB
    {
        // <summary>
        /// SectionConvertDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public MediationSectionConvertDB()
        {
            // 処理なし
        }

        /// <summary>
        /// ISectionConvertDBインターフェース取得
        /// </summary>
        /// <returns>ISectionConvertDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public static ISectionConvertDB GetSectionConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISectionConvertDB)Activator.GetObject(typeof(ISectionConvertDB), string.Format("{0}/MyAppSectionConvert", wkStr));
        }
    }
}
