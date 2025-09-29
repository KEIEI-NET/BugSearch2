//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム名称   : ＴＢＯ情報出力 仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00   作成担当 : 黄亜光
// 作 成 日 : 2016/05/20    修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// TBODataExportDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : このクラスはITBODataExportDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>    完全スタンドアロンにする場合にはこのクラスで直接ITBODataExportDBを</br>
    /// <br>    インスタンス化して戻します。</br>
    /// <br>Programmer  : 黄亜光</br>
    /// <br>Date        : 2016/05/20</br>
    /// <br></br>
    /// </remarks>
    public class MediationTBODataExportDB
    {
        /// <summary>
        /// TBODataExportDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public MediationTBODataExportDB()
        {
        }

        /// <summary>
        /// ITBODataExportDBインターフェース取得
        /// </summary>
        /// <returns>ITBODataExportDBオブジェクト</returns>
        /// <remarks>
        /// <br>Note        : ITBODataExportDBインターフェース取得。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// <br></br>
        /// </remarks>
        public static ITBODataExportDB GetTBODataExportDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ITBODataExportDB)Activator.GetObject(typeof(ITBODataExportDB), string.Format("{0}/MyAppTBODataExport", wkStr));
        }
    }
}
