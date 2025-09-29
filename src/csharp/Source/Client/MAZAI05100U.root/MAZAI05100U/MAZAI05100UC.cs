using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
	/// 棚卸用フォームコントロールクラス
	/// </summary>
    internal class FormControlInfo_Invent
    {
        # region Private Members
		private string _key;
		private string _assemblyID;
		private string _classID;
		private string _name;
		private System.Drawing.Image _icon;
		private Form _form;
		# endregion

		# region Constructor
		/// <summary>
		/// 棚卸用用フォームコントロールクラスコンストラクタ
		/// </summary>
		/// <param name="key">クラスのキー情報</param>
		/// <param name="assemblyId">アセンブリＩＤ</param>
		/// <param name="classId">クラスＩＤ</param>
		/// <param name="name">名称</param>
		/// <param name="icon">アイコン</param>
		public FormControlInfo_Invent(string key, string assemblyId, string classId, string name, object icon )
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
		}
		# endregion

		# region Properties
		/// <summary>キープロパティ</summary>
		/// <value>このプログラムアイテムのキーを取得または設定します。</value>
		public string Key
		{
			get{ return _key; }
			set{ _key = value; }
		}

		/// <summary>アセンブリIDプロパティ</summary>
		/// <value>このプログラムアイテムのアセンブリ名称を取得または設定します。</value>
		public string AssemblyID
		{
			get{ return _assemblyID; }
			set{ _assemblyID = value; }
		}

		/// <summary>クラスIDプロパティ</summary>
		/// <value>このプログラムアイテムのクラス厳密名称を取得または設定します。</value>
		public string ClassID
		{
			get{ return _classID; }
			set{ _classID = value; }
		}

		/// <summary>プログラム名称プロパティ</summary>
		/// <value>このプログラムの名称を取得または設定します。</value>
		public string Name
		{
			get{ return _name; }
			set{ _name = value; }
		}

		/// <summary>アイコンプロパティ</summary>
		/// <value>アイコンを取得または設定します。</value>
		public System.Drawing.Image Icon
		{
			get{ return _icon; }
			set{ _icon = value; }
		}

		/// <summary>子フォームオブジェクトプロパティ</summary>
		/// <value>Form型にキャストした個別アセンブリのフォームオブジェクトを取得または設定します。</value>
		public System.Windows.Forms.Form Form
		{
			get{ return _form; }
			set{ _form = value; }
		}
		# endregion

		# region Internal Methods
		# endregion
    }
}
