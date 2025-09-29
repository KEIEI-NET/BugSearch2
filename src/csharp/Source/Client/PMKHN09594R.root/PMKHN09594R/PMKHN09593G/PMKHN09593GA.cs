//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
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
	/// MailInfoSettingDB仲介クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : このクラスはIMailInfoSettingDBクラスオブジェクトをGetObjectで戻します。</br>
    /// <br>			完全スタンドアロンにする場合にはこのクラスで直接MailInfoSettingDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 李占川</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMailInfoSettingDB
	{
		/// <summary>
		/// MailInfoSettingDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		/// </remarks>
		public MediationMailInfoSettingDB()
		{
		}
        /// <summary>
        /// IMailInfoSettingDBインターフェース取得
        /// </summary>
        /// <returns>IMailInfoSettingDBオブジェクト</returns>
        public static IMailInfoSettingDB GetMailInfoSettingDB()
		{
            //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (IMailInfoSettingDB)Activator.GetObject(typeof(IMailInfoSettingDB), string.Format("{0}/MyAppMailInfoSetting", wkStr));
        }
	}
}
