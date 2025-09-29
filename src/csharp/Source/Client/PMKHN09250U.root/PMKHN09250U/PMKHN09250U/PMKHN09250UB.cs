using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 売上目標設定用フォームコントロールクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上目標設定用のフォームコントロールするクラス</br>
	/// <br>Programmer : 30414 忍 幸史</br>
	/// <br>Date       : 2008/10/08</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
	/// </remarks>
	internal class FormControlInfo_InventInput
	{
		# region Constructor
		/// <summary>
		/// 売上目標設定用フォームコントロールクラスコンストラクタ
		/// </summary>
		/// <param name="key">このプログラムアイテムのUniqueなID</param>
		/// <param name="assemblyId">このプログラムアイテムのアセンブリID</param>
		/// <param name="classId">このプログラムアイテムのクラスID</param>
		/// <param name="name">このプログラムの名称</param>
		/// <param name="icon">このプログラムのアイコン</param>
		/// <remarks>
		/// <br>Note       : 売上目標設定用フォームコントロールクラスの新しいインスタンスを初期化する</br>
		/// <br>Programmer : 30414 忍 幸史</br>
		/// <br>Date       : 2008/10/08</br>
		/// <br></br>
		/// <br>UpdateNote : </br>
		/// </remarks>
		public FormControlInfo_InventInput(string key, string assemblyId, string classId, string name, object icon)
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
		}
		# endregion

		# region Private Members
		private string _key;
		private string _assemblyID;
		private string _classID;
		private string _name;
		private System.Drawing.Image _icon;
		private Form _form;
		# endregion

		# region Properties
		/// <summary>キープロパティ</summary>
		/// <value>このプログラムアイテムのキーを取得または設定する</value>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}

		/// <summary>アセンブリIDプロパティ</summary>
		/// <value>このプログラムアイテムのアセンブリ名称を取得または設定する</value>
		public string AssemblyID
		{
			get{ return _assemblyID; }
			set{ _assemblyID = value; }
		}

		/// <summary>クラスIDプロパティ</summary>
		/// <value>このプログラムアイテムのクラス厳密名称を取得または設定する</value>
		public string ClassID
		{
			get{ return _classID; }
			set{ _classID = value; }
		}

		/// <summary>プログラム名称プロパティ</summary>
		/// <value>このプログラムの名称を取得または設定する</value>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		/// <summary>アイコンプロパティ</summary>
		/// <value>アイコンを取得または設定する</value>
		public System.Drawing.Image Icon
		{
			get{ return _icon; }
			set{ _icon = value; }
		}

		/// <summary>棚卸子画面オブジェクトプロパティ</summary>
		/// <value>Form型にキャストした個別アセンブリのフォームオブジェクトを取得または設定する</value>
		public System.Windows.Forms.Form Form
		{
			get{ return _form; }
			set{ _form = value; }
		}
		# endregion
	}
}
