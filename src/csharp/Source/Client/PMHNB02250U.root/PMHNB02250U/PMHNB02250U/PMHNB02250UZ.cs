//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 請求書発行(総括)フォームコントロールクラス
	/// </summary>
	/// <remarks>
	//// <br></br>
	/// </remarks>
	internal class FormControlInfo
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
        /// 請求書発行(総括)用フォームコントロールクラスコンストラクタ
		/// </summary>
		/// <param name="key">クラスのキー情報</param>
		/// <param name="assemblyId">アセンブリＩＤ</param>
		/// <param name="classId">クラスＩＤ</param>
		/// <param name="name">名称</param>
		/// <param name="icon">アイコン</param>
		/// <remarks>
		/// </remarks>
		public FormControlInfo(string key, string assemblyId, string classId, string name, object icon)
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

		/// <summary>CSエントリ子フォームオブジェクトプロパティ</summary>
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