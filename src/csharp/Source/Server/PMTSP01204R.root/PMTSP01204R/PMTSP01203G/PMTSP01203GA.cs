//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP送信データ作成 DB仲介クラス
// プログラム概要   : TSP送信データ作成 DB仲介クラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// MediationTspSdRvDataDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはITspSdRvDataクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接TspSdRvDataを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    public class MediationTspSdRvDataDB
    {
        /// <summary>
        /// TspCommonSeqNo仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public MediationTspSdRvDataDB()
        {
        }
        /// <summary>
        /// ITspSdRvDataDBインターフェース取得
        /// </summary>
        /// <returns>ITspSdRvDataDBオブジェクト</returns>
        public static ITspSdRvDataDB GetTspSdRvDataDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:8008";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITspSdRvDataDB)Activator.GetObject(typeof(ITspSdRvDataDB), string.Format("{0}/MyAppTspSdRvDataDB", wkStr));
        }
    }
}
