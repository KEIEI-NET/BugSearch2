using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// NoteGuidBdDB仲介クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : このクラスはINoteGuidBdDBクラスオブジェクトをGetObjectで戻します。</br>
	/// <br>			完全スタンドアロンにする場合にはこのクラスで直接NoteGuidBdDBを</br>
	/// <br>			インスタンス化して戻します。</br>
	/// <br>Programmer : 21052　山田　圭</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationNoteGuidBdDB
	{
		/// <summary>
		/// NoteGuidBdDB仲介クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特にコンストラクタ内の処理は無し。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		/// </remarks>
		public MediationNoteGuidBdDB()
		{
		}
		/// <summary>
		/// INoteGuidBdDBインターフェース取得
		/// </summary>
		/// <returns>INoteGuidBdDBオブジェクト</returns>
		/// <br>Note       : INoteGuidBdDBインターフェースを取得します。</br>
		/// <br>Programmer : 21052　山田　圭</br>
		/// <br>Date       : 2005.10.13</br>
		public static INoteGuidBdDB GetNoteGuidBdDB()
		{
			//USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

			// デバッグ用
#if DEBUG
			wkStr = "http://localhost:8001";
# endif

			//AppSettingsからの取得は行わず自分で引数文字列を生成する
			return (INoteGuidBdDB)Activator.GetObject(typeof(INoteGuidBdDB),string.Format("{0}/MyAppNoteGuidBd",wkStr));
		}
	}
}
