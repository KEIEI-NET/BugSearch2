//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DB仲介クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2019/12/02  修正内容 : 新規作成
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
    /// SalCprtSndLogDB仲介クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはISalCprtSndLogDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>             完全スタンドアロンにする場合にはこのクラスで直接SalCprtSndLogDBを</br>
    /// <br>             インスタンス化して戻します。</br>
    /// <br>Programmer : 自動生成</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class MediationSalCprtSndLogDB
    {
        /// <summary>
        /// SalCprtSndLogDB仲介クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
        /// <br>Programmer : 自動生成</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public MediationSalCprtSndLogDB()
        {
        }

		/// <summary>
        /// ISalCprtSndLogDBインターフェース取得
		/// </summary>
        /// <returns>ISalCprtSndLogDBオブジェクト</returns>
        public static ISalCprtSndLogDB GetSalCprtSndLogDB()
        {
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISalCprtSndLogDB)Activator.GetObject(typeof(ISalCprtSndLogDB), string.Format("{0}/MyAppSalCprtSndLog", wkStr));
        }
    }
}
