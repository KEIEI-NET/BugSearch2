//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2013.06.26  修正内容 : 新規作成
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
    /// SAndESalSndLogDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISAndESalSndLogDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SAndESalSndLogDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2013.06.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSAndESalSndLogDB
    {
        /// <summary>
        /// SAndESalSndLogDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public MediationSAndESalSndLogDB()
        {
        }

		/// <summary>
        /// ISAndESalSndLogDBインターフェース取得
		/// </summary>
        /// <returns>ISAndESalSndLogDBオブジェクト</returns>
        public static ISAndESalSndLogDB GetSAndESalSndLogDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISAndESalSndLogDB)Activator.GetObject(typeof(ISAndESalSndLogDB), string.Format("{0}/MyAppSAndESalSndLog", wkStr));
        }
    }
}
