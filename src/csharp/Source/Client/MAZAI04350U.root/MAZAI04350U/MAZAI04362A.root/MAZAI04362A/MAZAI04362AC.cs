using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	//********************************************************************************
	//  イベントパラメータ定義
	//********************************************************************************
	//==================================================================
	//  パブリッククラス
	//==================================================================
	/// <summary>
	/// 伝票明細行操作後イベント引数クラス
	/// </summary>
	public class SlipDtlRowChangedEventArgs : EventArgs
	{
		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数
		/// <summary>対象の行インデックス(0～)</summary>
		private int _rowIndex;
		/// <summary>操作対象オブジェクト</summary>
		private object _object;
		#endregion

		//--------------------------------------------------------
		//  コンストラクタ
		//--------------------------------------------------------
		#region コンストラクタ
		/// <summary>
		/// 伝票明細行操作後イベント引数クラスのコンストラクター
		/// </summary>
		/// <param name="rowIndex">対象行インデックス(0～)</param>
		/// <param name="dest">対象行の値</param>
		public SlipDtlRowChangedEventArgs(int rowIndex, object dest)
			: base()
		{
			this._rowIndex = rowIndex;
			this._object = dest;
		}
		#endregion

		//--------------------------------------------------------
		//  プロパティ
		//--------------------------------------------------------
		#region プロパティ
		/// <summary>対象行インデックス</summary>
		public int RowIndex
		{
			get { return this._rowIndex; }
		}

		/// <summary>操作対象行の内容</summary>
		public object Destination
		{
			get { return this._object; }
		}
		#endregion
	}

	/// <summary>
	/// 伝票明細行操作前イベント引数クラス
	/// </summary>
	public class SlipDtlRowChangingEventArgs : SlipDtlRowChangedEventArgs
	{
		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数
		/// <summary>操作キャンセルフラグ</summary>
		private bool _cancel;
		#endregion

		//--------------------------------------------------------
		//  コンストラクタ
		//--------------------------------------------------------
		#region コンストラクタ
		/// <summary>
		/// 伝票明細行操作前イベント引数クラスコンストラクター
		/// </summary>
		/// <param name="rowIndex">対象行インデックス(0～)</param>
		/// <param name="dest">対象行の値</param>
		public SlipDtlRowChangingEventArgs(int rowIndex, object dest)
			: base(rowIndex, dest)
		{
			this._cancel = false;
		}
		#endregion

		//--------------------------------------------------------
		//  プロパティ
		//--------------------------------------------------------
		#region プロパティ
		/// <summary>キャンセルフラグ</summary>
		public bool Cancel
		{
			get { return this._cancel; }
			set { this._cancel = value; }
		}
		#endregion
	}


	/// <summary>
	/// 伝票明細列操作前イベント引数クラス
	/// </summary>
	public class SlipDtlColChangingEventArgs : SlipDtlColChangedEventArgs
	{
		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数
		/// <summary>キャンセルフラグ</summary>
		private bool _cancel;
		#endregion

		//--------------------------------------------------------
		//  コンストラクタ
		//--------------------------------------------------------
		#region コンストラクタ
		/// <summary>
		/// 伝票明細列操作前イベント引数クラスコンストラクタ
		/// </summary>
		/// <param name="row">対象行インデックス(0~)</param>
		/// <param name="column">対象列のデータカラム</param>
		/// <param name="dest">対象列の値</param>
		public SlipDtlColChangingEventArgs(int row, System.Data.DataColumn column, object dest)
			: base(row, column, dest)
		{
			this._cancel = false;
		}
		#endregion

		//--------------------------------------------------------
		//  プロパティ
		//--------------------------------------------------------
		#region プロパティ
		/// <summary>
		/// キャンセルフラグ
		/// </summary>
		public bool Cancel
		{
			get { return this._cancel; }
			set { this._cancel = value; }
		}
		#endregion
	}

	/// <summary>
	/// 伝票明細列操作後イベント引数クラスのコンストラクター
	/// </summary>
	public class SlipDtlColChangedEventArgs : SlipDtlRowChangedEventArgs
	{
		//--------------------------------------------------------
		//  プライベート変数
		//--------------------------------------------------------
		#region プライベート変数
		/// <summary>イベントが発生したカラム位置</summary>
		private System.Data.DataColumn _dataColumn;
		#endregion

		//--------------------------------------------------------
		//  コンストラクタ
		//--------------------------------------------------------
		#region コンストラクタ
		/// <summary>
		/// 伝票明細列操作後イベント引数クラスのコンストラクタ
		/// </summary>
		/// <param name="row">対象行インデックス</param>
		/// <param name="column">対象列のデータカラム</param>
		/// <param name="dest">対象列の値</param>
		public SlipDtlColChangedEventArgs(int row, System.Data.DataColumn column, object dest)
			: base(row, dest)
		{
			this._dataColumn = column;
		}
		#endregion

		//--------------------------------------------------------
		//  プロパティ
		//--------------------------------------------------------
		#region プロパティ
		/// <summary>イベントが発生した列の列名称</summary>
		public string ColumnName
		{
			get { return this._dataColumn.ColumnName; }
		}

		/// <summary>イベントが発生した列のデータカラム</summary>
		public System.Data.DataColumn Column
		{
			get { return this._dataColumn; }
		}
		#endregion
	}

    /// <summary>
    /// 在庫マスタ重複判断用クラス
    /// </summary>
    public class ChkStock
    {
        private string enterPriseCode;
        private string sectionCode;
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //private int makerCode;
        //private string goodsCode;
        private int goodsMakerCd;
        private string goodsNo;
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        private string productNumber;
        // 2008.03.28 追加 >>>>>>>>>>>>>>>>>>>>
        private string warehouseCode;
        // 2008.03.28 追加 <<<<<<<<<<<<<<<<<<<<

        public ChkStock()
        {
        }

        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public ChkStock(string EnterPriseCode, string SectionCode, int MakerCode, string GoodsCode, string ProductNumber)
        // 2008.03.28 修正 >>>>>>>>>>>>>>>>>>>>
        //public ChkStock(string EnterPriseCode, string SectionCode, int GoodsMakerCd, string GoodsNo, string ProductNumber)
        public ChkStock(string EnterPriseCode, string SectionCode, int GoodsMakerCd, string GoodsNo, string ProductNumber, string WarehouseCode)
        // 2008.03.28 修正 <<<<<<<<<<<<<<<<<<<<
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        {
            enterPriseCode = EnterPriseCode;
            sectionCode = SectionCode;
            // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
            //makerCode = MakerCode;
            //goodsCode = GoodsCode;
            goodsMakerCd = GoodsMakerCd;
            goodsNo = GoodsNo;
            // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
            productNumber = ProductNumber;
            // 2008.03.28 追加 >>>>>>>>>>>>>>>>>>>>
            warehouseCode = WarehouseCode;
            // 2008.03.28 追加 <<<<<<<<<<<<<<<<<<<<
        }

        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }
        public string SectionCode
        {
            get { return this.sectionCode;}
            set { this.sectionCode = value; }
        }
        // 2007.10.11 修正 >>>>>>>>>>>>>>>>>>>>
        //public int MakerCode
        //{
        //    get { return this.makerCode; }
        //    set { this.makerCode = value; }
        //}
        //public string GoodsCode
        //{
        //    get { return this.goodsCode; }
        //    set { this.goodsCode = value; }
        //}
        public int GoodsMakerCd
        {
            get { return this.goodsMakerCd; }
            set { this.goodsMakerCd = value; }
        }
        public string GoodsNo
        {
            get { return this.goodsNo; }
            set { this.goodsNo = value; }
        }
        // 2007.10.11 修正 <<<<<<<<<<<<<<<<<<<<
        public string ProductNumber
        {
            get { return this.productNumber; }
            set { this.productNumber = value; }
        }
        // 2008.03.28 追加 >>>>>>>>>>>>>>>>>>>>
        public string WarehouseCode
        {
            get { return this.warehouseCode; }
            set { this.warehouseCode = value; }
        }
        // 2008.03.28 追加 <<<<<<<<<<<<<<<<<<<<
    }

}
