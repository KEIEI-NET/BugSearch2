#define ADD20060407

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 帳票共通用フォームコントロールクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 帳票共通フレームにて起動するフォームをコントロールするクラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br>Update Note: 2006.04.07 Y.Sasaki</br>
	/// <br>           : １.帳票毎に選択計上拠点、選択拠点、選択システムを持つように変更</br>
	/// <br>Update Note: 2006.08.09 Y.Sasaki</br>
	/// <br>           : １.帳票毎に選択可能システムを持つように変更</br>
	/// <br>Update Note: 2007.03.05 Y.Sasaki</br>
	/// <br>           : １.携帯.NS用に変更。</br>
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
		private Form _viewForm;
		private bool _isInit = false;
		private int _ctrlFuncCode = 10;
		private object _param = null;
#if ADD20060407
		private int _selSectionKindIndex;
		private string[] _selSections = new string[0];
		private int[] _selSystems = new int[0];
#endif
		// >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		private int[] _softwareCode = new int[0];
		// <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
		
		private List<AnalysisChartViewForm> _analysisChartViewFormLst = new List<AnalysisChartViewForm>();
		# endregion

		# region Constructor
		/// <summary>
		/// 帳票共通用フォームコントロールクラスコンストラクタ
		/// </summary>
		/// <param name="key">クラスのキー情報</param>
		/// <param name="assemblyId">アセンブリＩＤ</param>
		/// <param name="classId">クラスＩＤ</param>
		/// <param name="name">名称</param>
		/// <param name="icon">アイコン</param>
		/// <param name="ctrlFuncCode">制御拠点コード</param>
		/// <param name="softwareCode">選択可能システムコード</param>
		/// <remarks>
		/// <br>Note       : 帳票共通用フォームコントロールクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.17</br>
		/// <br>Update Note: 2006.08.09 Y.Sasaki</br>
		/// <br>           : １.選択可能システムコード追加</br>
		/// </remarks>
		public FormControlInfo(string key, string assemblyId, string classId, string name, object icon, int ctrlFuncCode, object param, int[] softwareCode)
		{
			this._key						= key;
			this._assemblyID		= assemblyId;
			this._classID				= classId;
			this._name					= name;
			this._icon					= icon as System.Drawing.Image;
			this._form					= null;
			this._viewForm			= null;
			this._isInit				= false;
			this._ctrlFuncCode	= ctrlFuncCode;
			this._param					= param;
			// >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
			this._softwareCode = softwareCode;
			// <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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

		/// <value>Form型にキャストした個別アセンブリのフォームオブジェクトを取得または設定します。</value>
		public System.Windows.Forms.Form Form
		{
			get{ return _form; }
			set{ _form = value; }
		}

		/// <value>Form型にキャストした個別アセンブリのビュー要フォームオブジェクトを取得または設定します。</value>
		public System.Windows.Forms.Form ViewForm
		{
			get{ return _viewForm; }
			set{ _viewForm = value; }
		}
		
		/// <summary>初回起動有無プロパティ</summary>
		/// <value>初回起動有無を取得または設定します。</value>
		public bool IsInit
		{
			get{ return _isInit; }
			set{ _isInit = value; }
		}
		
		/// <summary>制御機能コードプロパティ</summary>
		/// <value>制御機能コードを取得または設定します。</value>
		public int CtrlFuncCode
		{
			get{ return _ctrlFuncCode; }
			set{ _ctrlFuncCode = value; }
		}

		/// <summary>引数パラメータプロパティ</summary>
		/// <value>引数パラメータを取得または設定します。</value>
		public object Param
		{
			get{ return _param; }
			set{ _param = value; }
		}
		
		/// <summary>選択拠点種類プロパティ</summary>
		/// <value>選択拠点種類を取得または設定します。</value>
		public int SelSectionKindIndex
		{
			get{ return _selSectionKindIndex; }
			set{ _selSectionKindIndex = value; }
		}
		
		/// <summary>選択拠点プロパティ</summary>
		/// <value>選択拠点を取得または設定します。</value>
		public string[] SelSections
		{
			get{ return _selSections; }
			set{ _selSections = value; }
		}
		
		/// <summary>選択システムプロパティ</summary>
		/// <value>選択システムを取得または設定します。</value>
		public int[] SelSystems
		{
			get{ return _selSystems; }
			set{ _selSystems = value; }
		}

		// >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		/// <summary>選択可能システムプロパティ</summary>
		/// <value>選択可能システムを取得または設定します。</value>
		public int[] SoftWareCode
		{
			get { return _softwareCode; }
			set { _softwareCode = value; }
		}
		// <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

		public List<AnalysisChartViewForm> AnalysisChartViewFormLst
		{
			get { return _analysisChartViewFormLst; }
			set { _analysisChartViewFormLst = value; }
		}
		# endregion

		　# region Internal Methods
		# endregion
	}
}
