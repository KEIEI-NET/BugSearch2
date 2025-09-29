using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入伝票入力フォームコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入伝票入力フォームにて起動するフォームをコントロールするクラスです。</br>
	/// <br>Programmer : 21027 須川  程志郎</br>
	/// <br>Date       : 2006.05.30</br>
	/// <br></br>
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
		private string _nextForm;
		private string _beforeForm;
		# endregion

		# region Constructor
		/// <summary>
		/// 仕入伝票入力フォームコントロールクラスコンストラクタ
		/// </summary>
		/// <param name="key">クラスのキー情報</param>
		/// <param name="assemblyId">アセンブリＩＤ</param>
		/// <param name="classId">クラスＩＤ</param>
		/// <param name="name">名称</param>
		/// <param name="icon">アイコン</param>
		/// <param name="nextForm">次のフォームＩＤ</param>
		/// <param name="beforeForm">前のフォームＩＤ</param>
		/// <remarks>
		/// <br>Note       : 仕入伝票入力フォームコントロールクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2006.05.30</br>
		/// </remarks>
		public FormControlInfo(string key, string assemblyId, string classId, string name, object icon, string nextForm, string beforeForm)
		{
			this._key = key;
			this._assemblyID = assemblyId;
			this._classID = classId;
			this._name = name;
			this._icon = icon as System.Drawing.Image;
			this._form = null;
			this._nextForm = nextForm;
			this._beforeForm = beforeForm;
		}
		# endregion

		# region Properties
		/// <summary>キープロパティ</summary>
		/// <value>このプログラムアイテムのキーを取得または設定します。</value>
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}

		/// <summary>アセンブリIDプロパティ</summary>
		/// <value>このプログラムアイテムのアセンブリ名称を取得または設定します。</value>
		public string AssemblyID
		{
			get { return _assemblyID; }
			set { _assemblyID = value; }
		}

		/// <summary>クラスIDプロパティ</summary>
		/// <value>このプログラムアイテムのクラス厳密名称を取得または設定します。</value>
		public string ClassID
		{
			get { return _classID; }
			set { _classID = value; }
		}

		/// <summary>プログラム名称プロパティ</summary>
		/// <value>このプログラムの名称を取得または設定します。</value>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>アイコンプロパティ</summary>
		/// <value>アイコンを取得または設定します。</value>
		public System.Drawing.Image Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}

		/// <summary>CSエントリ子フォームオブジェクトプロパティ</summary>
		/// <value>Form型にキャストした個別アセンブリのフォームオブジェクトを取得または設定します。</value>
		public System.Windows.Forms.Form Form
		{
			get { return _form; }
			set { _form = value; }
		}

		/// <summary>次のフォームＩＤ（クラスＩＤ）プロパティ</summary>
		/// <value>自身の次に表示されるフォームＩＤを取得または設定します。</value>
		public string NextForm
		{
			get { return _nextForm; }
			set { _nextForm = value; }
		}

		/// <summary>前のフォームＩＤ（クラスＩＤ）プロパティ</summary>
		/// <value>自身の前に表示されるフォームＩＤを取得または設定します。</value>
		public string BeforeForm
		{
			get { return _beforeForm; }
			set { _beforeForm = value; }
		}
		# endregion

		# region Internal Methods
		# endregion
	}
}