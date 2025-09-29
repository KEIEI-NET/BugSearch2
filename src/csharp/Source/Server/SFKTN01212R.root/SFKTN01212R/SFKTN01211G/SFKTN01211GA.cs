using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// SectionInfo仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはISectionInfoクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接SectionInfoを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSectionInfo
	{
		/// <summary>
		/// SectionInfo仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		public MediationSectionInfo()
		{
		}
		/// <summary>
		/// ISectionInfoインターフェース取得
		/// </summary>
		/// <returns>ISectionInfoオブジェクト</returns>
		public static ISectionInfo GetSectionInfo()
		{
			//アプリケーションサーバー接続切り替え対応↓↓↓↓↓
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettingsからの取得は行わず自分で引数文字列を生成する
            return (ISectionInfo)Activator.GetObject(typeof(ISectionInfo),string.Format("{0}/MyAppSectionInfo",wkStr));
			//アプリケーションサーバー接続切り替え対応↑↑↑↑↑
		}
	}
}
