using System;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// マスタメンテナンスフレーム用プログラム情報管理クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : マスタメンテナンスフレームにて起動するプログラム情報を管理するクラスです。</br>
	/// <br>Programmer : 30154 安藤　昌仁</br>
	/// <br>Date       : 2007.04.18</br>
	/// </remarks>
	internal class ProgramItemMAKAU09130U
	{
		# region Private Members
		private string _key;
		private string _assemblyID;
		private string _classID;
		private string _name;
		private ProgramPatternMAKAU09130U _pattern;
		private ProgramConditionMAKAU09130U _condition;
		private Type _classType;
		private Object _object;
		private Form _customForm;
		private Form _viewForm;
		private MasterMaintenanceConstructionMAKAU09130U _construction;
		# endregion

		# region Constructor
		/// <summary>
		/// プログラム情報管理クラスコンストラクタ
		/// </summary>
		/// <param name="key">キー</param>
		/// <param name="assemblyId">アセンブリＩＤ</param>
		/// <param name="classId">クラスＩＤ</param>
		/// <param name="name">名称</param>
		/// <param name="pattern">タイプ</param>
		/// <remarks>
		/// <br>Note       : 一覧表示フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        public ProgramItemMAKAU09130U(string key, string assemblyId, string classId, string name, ProgramPatternMAKAU09130U pattern)
		{
			_key = key;
			_assemblyID = assemblyId;
			_classID = classId;
			_name = name;
			_pattern = pattern;
            _condition = ProgramConditionMAKAU09130U.UnChecked;
			_classType = null;
			_object = null;
			_customForm = null;
			_viewForm = null;
			_construction = null;
		}
		# endregion

		# region Properties
		/// <summary>キープロパティ</summary>
		/// <value>このクラスのキーとなる情報（Unique)を取得または設定します。</value>
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

		/// <summary>プログラムパターンプロパティ</summary>
		/// <value>このプログラムのパターンを取得または設定します。</value>
        public ProgramPatternMAKAU09130U Pattern
		{
			get{ return _pattern; }
			set{ _pattern = value; }
		}

		/// <summary>プログラム状態プロパティ</summary>
		/// <value>このプログラムの状態を取得または設定します。</value>
        public ProgramConditionMAKAU09130U Condition
		{
			get{ return _condition; }
			set{ _condition = value; }
		}

		/// <summary>クラスタイププロパティ</summary>
		/// <value>クラスの型情報を取得または設定します。</value>
		public Type ClassType
		{
			get{ return _classType; }
			set{ _classType = value; }
		}

		/// <summary>オブジェクトプロパティ</summary>
		/// <value>リフレクションでインスタンス化したアセンブリのオブジェクトを取得または設定します。</value>
		public Object Object
		{
			get{ return _object; }
			set{ _object = value; }
		}

		/// <summary>マスメン固有フォームオブジェクトプロパティ</summary>
		/// <value>Form型にキャストした個別アセンブリのフォームオブジェクトを取得または設定します。</value>
		public Form CustomForm
		{
			get{ return _customForm; }
			set{ _customForm = value; }
		}

		/// <summary>ビュー用フォームオブジェクトプロパティ</summary>
		/// <value>Form型にキャストしたビュー用フォームオブジェクトを取得または設定します。</value>
		public Form ViewForm
		{
			get{ return _viewForm; }
			set{ _viewForm = value; }
		}

		/// <summary>マスタメンテナンス設定クラスオブジェクトプロパティ</summary>
		/// <value>マスタメンテナンス固有のマスタメンテナンス設定クラスオブジェクトを取得または設定します。</value>
        public MasterMaintenanceConstructionMAKAU09130U Construction
		{
			get{ return _construction; }
			set{ _construction = value; }
		}
		# endregion
    }

    # region enum ProgramPatternMAKAU09130U
    /// <summary>マスタメンテナンスのパターンの列挙型です。</summary>
    internal enum ProgramPatternMAKAU09130U : int
	{
		/// <summary>（通常は使われません）</summary>
		None = 0,

		/// <summary>マスタメンテナンスシングルタイプ</summary>
		Single = 1,

		/// <summary>マスタメンテナンスマルチタイプ</summary>
		Multi = 2,

		/// <summary>マスタメンテナンス配列タイプ</summary>
		Array = 3,

		/// <summary>マスタメンテナンス３階層配列タイプ</summary>
		ThreeArray = 4,

		/// <summary>マスタメンテナンスその他タイプ</summary>
		Other = 5
	}

	/// <summary>
	/// <summary>マスタメンテナンスの状態の列挙型です。</summary>
	/// </summary>
    internal enum ProgramConditionMAKAU09130U : int
	{
		/// <summary>未変更の状態です。（チェックボックス未チェック）</summary>
		UnChecked = 0,

		/// <summary>変更済みの状態です。（チェックボックスチェック済み）</summary>
		Checked = 1,
	}
	# endregion
}
