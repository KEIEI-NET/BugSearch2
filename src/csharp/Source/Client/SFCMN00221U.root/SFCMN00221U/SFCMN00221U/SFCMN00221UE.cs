using System;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 読み込みアセンブリ情報クラス(ランチャー起動用)
	/// </summary>
	/// <remarks>
	/// <br>Note       : アセンブリを読み込むための情報クラスです。</br>
	/// <br>Programer  : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2006.03.08</br>
	/// <br>Update Note:</br>
	/// <br>2006.11.17 men SoftwareCodeを追加</br>
	/// </remarks>
	[Serializable]
	public class LuncherStartAssemblyInfo
	{
		/// <summary>
		/// アセンブリ名称
		/// </summary>
		private	string _assemblyName = "";
		/// <summary>
		/// クラス名称
		/// </summary>
		private	string _className = "";
		/// <summary>
		/// 起動モード(0:引数なし 1:得意先指定 2:車両指定)
		/// </summary>
		private	int _mode;
		/// <summary>
		/// 画面表示名称
		/// </summary>
		private	string _dispName = "";
		/// <summary>
		/// アイコンイメージ番号
		/// </summary>
		private	int _imageNo = -1;
		/// <summary>
		/// オプションコード
		/// </summary>
		private string _softwareCode = "";

		/// <summary>
		/// アセンブリ名称プロパティ
		/// </summary>
		public string AssemblyName
		{
			get { return _assemblyName; }
			set { this._assemblyName = value; }
		}
		/// <summary>
		/// クラス名称プロパティ
		/// </summary>
		public string	ClassName
		{
			get { return _className; }
			set { this._className = value; }
		}
		/// <summary>
		/// 起動モードプロパティ
		/// </summary>
		public int	Mode
		{
			get { return _mode; }
			set { this._mode = value; }
		}
		/// <summary>
		/// 画面表示名称プロパティ
		/// </summary>
		public string	DispName
		{
			get { return _dispName; }
			set { this._dispName = value; }
		}
		/// <summary>
		/// アイコンイメージ番号プロパティ
		/// </summary>
		public int	ImageNo
		{
			get { return _imageNo; }
			set { this._imageNo = value; }
		}
		/// <summary>
		/// オプションコードプロパティ
		/// </summary>
		public string SoftwareCode
		{
			get { return _softwareCode; }
			set { this._softwareCode = value; }
		}
	}

	/// <summary>
	/// TOPメニュー表示情報クラス(ランチャー起動用)
	/// </summary>
	/// <remarks>
	/// <br>Note       : TOPメニューを表示する情報クラスです。</br>
	/// <br>Programer  : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2006.03.08</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class LuncherTopMenuInfo
	{
		/// <summary>
		/// 起動モード
		/// </summary>
		private	int			_mode;
		/// <summary>
		/// 画面表示名称
		/// </summary>
		private	string		_dispName;
		/// <summary>
		/// アイコンイメージ番号
		/// </summary>
		private	int			_imageNo = -1;

		/// <summary>
		/// アセンブリ名称
		/// </summary>
		private	string		_assemblyName;
		/// <summary>
		/// クラス名称
		/// </summary>
		private	string		_className;

		/// <summary>
		/// 起動モードプロパティ
		/// </summary>
		public int	Mode
		{
			get { return _mode; }
			set { this._mode = value; }
		}
		/// <summary>
		/// 画面表示名称プロパティ
		/// </summary>
		public string	DispName
		{
			get { return _dispName; }
			set { this._dispName = value; }
		}
		/// <summary>
		/// アイコンイメージ番号プロパティ
		/// </summary>
		public int	ImageNo
		{
			get { return _imageNo; }
			set { this._imageNo = value; }
		}

		/// <summary>
		/// アセンブリ名称プロパティ
		/// </summary>
		public string AssemblyName
		{
			get { return _assemblyName; }
			set { this._assemblyName = value; }
		}
		/// <summary>
		/// クラス名称プロパティ
		/// </summary>
		public string	ClassName
		{
			get { return _className; }
			set { this._className = value; }
		}
	}

	/// public class name:   SelectCustomerCarOrder
	/// <summary>
	/// 選択得意先・仕入伝票情報クラス
	/// </summary>
	/// <remarks>
	/// <br>note       : 選択得意先・仕入伝票クラス</br>
	/// <br>Programer  : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.19</br>
	/// <br>Update Note:</br>
	/// </remarks>
	[Serializable]
	public class SliderSelectedData
	{
		#region 得意先メンバ定義
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先サブコード</summary>
		private string _customerSubCode;

		/// <summary>名称</summary>
		private string _name;

		/// <summary>名称２</summary>
		private string _name2;

		#endregion

		#region 仕入伝票メンバ定義
		/// <summary>仕入形式</summary>
		/// <remarks>0:仕入,1:入荷</remarks>
		private Int32 _supplierFormal;

		/// <summary>仕入伝票番号</summary>
		private Int32 _supplierSlipNo;
		#endregion

		#region 得意先プロパティ定義
		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   徳永 誠</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   徳永 誠</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerSubCode
		/// <summary>得意先サブコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先サブコードプロパティ</br>
		/// <br>Programer        :   徳永 誠</br>
		/// </remarks>
		public string CustomerSubCode
		{
			get{return _customerSubCode;}
			set{_customerSubCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   徳永 誠</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Name2
		/// <summary>名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称２プロパティ</br>
		/// <br>Programer        :   徳永 誠</br>
		/// </remarks>
		public string Name2
		{
			get{return _name2;}
			set{_name2 = value;}
		}

		#endregion

		#region 仕入伝票プロパティ定義
		/// public propaty name  :  SupplierFormal
		/// <summary>仕入形式プロパティ</summary>
		/// <value>0:仕入,1:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierFormal
		{
			get { return _supplierFormal; }
			set { _supplierFormal = value; }
		}

		/// public propaty name  :  SupplierSlipNo
		/// <summary>仕入伝票プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipNo
		{
			get { return _supplierSlipNo; }
			set { _supplierSlipNo = value; }
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 得意先仕入伝票検索結果コンストラクタ
		/// </summary>
		public SliderSelectedData()
		{
		}
		#endregion
	}
}
