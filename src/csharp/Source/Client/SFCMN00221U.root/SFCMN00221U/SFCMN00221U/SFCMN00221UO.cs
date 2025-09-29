using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// スーパースライダー起動パラメータ
	/// </summary>
	public class SFCMN00221UAParam
	{
		private int _supplierDiv = 0;
		private int _customerDefaultEditType = 0;
		private int _stockSlipDefaultEditType = 0;
		private bool _showCustomerList = false;
		private bool _showStockSlipList = false;
		private int _xmlNo = 0;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFCMN00221UAParam()
		{
			//
		}

		/// <summary>
		/// スーパースライダー起動パラメータコンストラクタ
		/// </summary>
		/// <param name="supplierDiv">仕入先区分</param>
		/// <param name="customerDefaultEditType">得意先検索初期抽出条件タイプ</param>
		/// <param name="stockSlipDefaultEditType">仕入伝票検索初期抽出条件タイプ</param>
		/// <param name="showCustomerList">最近参照した得意先表示</param>
		/// <param name="showStockSlipList">最近参照した仕入伝票表示</param>
		/// <param name="xmlNo">XML番号</param>
		public SFCMN00221UAParam(int supplierDiv, int customerDefaultEditType, int stockSlipDefaultEditType, bool showCustomerList, bool showStockSlipList, int xmlNo)
		{
			this.SupplierDiv = supplierDiv;
			this.CustomerDefaultEditType = customerDefaultEditType;
			this.StockSlipDefaultEditType = stockSlipDefaultEditType;
			this.ShowCustomerList = showCustomerList;
			this.ShowStockSlipList = showStockSlipList;
			this.XmlNo = xmlNo;
		}

		/// <summary>
		/// 仕入伝票検索初期抽出条件タイププロパティ
		/// </summary>
		/// <remarks>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockDate = 1;		// 仕入日</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_InputDay = 2;	// 計上日</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_SupplierSlipNo = 3;	// 伝票番号</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockAgentCode = 4;	// 仕入担当</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerCode = 5;	// 仕入先コード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CarrierEpCode = 6;	// 事業者コード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_WarehouseCode = 7;	// 倉庫コード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_PartySaleSlipNum = 8;// 相手先伝番</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_GoodsCode = 9;		// 商品コード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_StockTelNo1 = 10;	// 商品電話番号</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_ProductNumber1 = 11;	// 製造番号</br>
		/// </remarks>
		public int StockSlipDefaultEditType
		{
			get { return _stockSlipDefaultEditType; }
			set { _stockSlipDefaultEditType = value; }
		}

		/// <summary>
		/// 得意先検索初期抽出条件タイププロパティ
		/// </summary>
		/// <remarks>
		/// <br>SFCMN00221UI.EDIT_TYPE_Kana = 1;			// 得意先カナ</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerCode = 2;	// 得意先コード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_CustomerSubCode = 4;	// 得意先サブコード</br>
		/// <br>SFCMN00221UI.EDIT_TYPE_SearchTelNo = 6;		// 検索電話番号</br>
		/// </remarks>
		public int CustomerDefaultEditType
		{
			get { return _customerDefaultEditType; }
			set { _customerDefaultEditType = value; }
		}

		/// <summary>
		/// 仕入先区分
		/// </summary>
		/// <remarks>
		/// <br>0 : 仕入先以外</br>
		/// <br>1 : 仕入先</br>
		/// </remarks>
		public int SupplierDiv
		{
			get { return _supplierDiv; }
			set { _supplierDiv = value; }
		}

		/// <summary>
		/// XML番号
		/// </summary>
		public int XmlNo
		{
			get { return _xmlNo; }
			set { _xmlNo = value; }
		}

		/// <summary>
		/// 最近参照した得意先表示プロパティ
		/// </summary>
		public bool ShowCustomerList
		{
			get
			{
				return this._showCustomerList;
			}
			set
			{
				this._showCustomerList = value;
			}
		}

		/// <summary>
		/// 最近参照した仕入伝票表示プロパティ
		/// </summary>
		public bool ShowStockSlipList
		{
			get
			{
				return this._showStockSlipList;
			}
			set
			{
				this._showStockSlipList = value;
			}
		}

		/// <summary>
		/// スーパースライダー起動パラメータ複製処理
		/// </summary>
		/// <returns>スーパースライダー起動パラメータクラスのインスタンス</returns>
		public SFCMN00221UAParam Clone()
		{
			return new SFCMN00221UAParam(this._supplierDiv, this._customerDefaultEditType, this._stockSlipDefaultEditType, this._showCustomerList, this._showStockSlipList, this._xmlNo);
		}
	}
}
