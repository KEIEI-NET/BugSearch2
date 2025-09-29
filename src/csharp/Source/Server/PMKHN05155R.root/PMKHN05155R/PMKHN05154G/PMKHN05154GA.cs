//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換 SlipNoConvertDB仲介クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
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
    /// <br>Note       : このクラスはISlipNoConvertDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SectionConvertDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    public class MediationSlipNoConvertDB
    {
        // <summary>
        /// SlipNoConvertDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public MediationSlipNoConvertDB()
        {
            // 処理なし
        }

        /// <summary>
        /// ISlipNoConvertDBインターフェース取得
        /// </summary>
        /// <returns>ISlipNoConvertDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        public static ISlipNoConvertDB GetSlipNoConvertDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            //wkStr = "http://localhost:9001";
            wkStr = "http://localhost:8009";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISlipNoConvertDB)Activator.GetObject(typeof(ISlipNoConvertDB), string.Format("{0}/MyAppSlipNoConvert", wkStr));
        }
    }
}
