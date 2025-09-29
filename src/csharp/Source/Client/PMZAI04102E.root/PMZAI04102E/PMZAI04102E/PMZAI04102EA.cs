using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockHistoryDspSearchParamWork
	/// <summary>
	///                      在庫実績照会抽出条件ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫実績照会抽出条件ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 王増喜 テキスト出力対応</br>
	/// </remarks>
	[Serializable]
	public class StockHistoryDspSearchParam
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>開始年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>終了年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

        /// <summary>開始年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stAddUpDate;

        /// <summary>終了年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _edAddUpDate;

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>倉庫コードリスト</summary>
        private List<string> _warehouseCodeList = new List<string>();

        /// <summary>棚番リスト</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>メーカーコードリスト</summary>
        private List<Int32> _makerCodeList = new List<Int32>();

        /// <summary>BLコードリスト</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();

        /// <summary>品番リスト</summary>
        private List<string> _goodsNoList = new List<string>();
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>開始年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>終了年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

        /// public propaty name  :  StAddUpDate
        /// <summary>開始年月プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StAddUpDate
        {
            get { return _stAddUpDate; }
            set { _stAddUpDate = value; }
        }

        /// public propaty name  :  EdAddUpDate
        /// <summary>終了年月プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdAddUpDate
        {
            get { return _edAddUpDate; }
            set { _edAddUpDate = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// public propaty name  :  WarehouseCodeList
        /// <summary>倉庫コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> WarehouseCodeList
        {
            get { return _warehouseCodeList; }
            set { _warehouseCodeList = value; }
        }

        /// public propaty name  :  WarehouseShelfNoList
        /// <summary>棚番リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> WarehouseShelfNoList
        {
            get { return _warehouseShelfNoList; }
            set { _warehouseShelfNoList = value; }
        }

        /// public propaty name  :  MakerCodeList
        /// <summary>メーカーコードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> MakerCodeList
        {
            get { return _makerCodeList; }
            set { _makerCodeList = value; }
        }

        /// public propaty name  :  BlGoodsCodeList
        /// <summary>BLコードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<Int32> BlGoodsCodeList
        {
            get { return _blGoodsCodeList; }
            set { _blGoodsCodeList = value; }
        }

        /// public propaty name  :  GoodsNoList
        /// <summary>品番コードリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> GoodsNoList
        {
            get { return _goodsNoList; }
            set { _goodsNoList = value; }
        }
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

		/// <summary>
		/// 在庫実績照会抽出条件ワークコンストラクタ
		/// </summary>
		/// <returns>StockHistoryDspSearchParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockHistoryDspSearchParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockHistoryDspSearchParam()
		{
		}

        
        /// <summary>
        /// 在庫実績照会クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(集計の対象となっている拠点コード)</param>
        /// <param name="stAddUpYearMonth">計上年月(開始)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">計上年月(終了)(YYYYMM)</param>
        /// <param name="warehouseCodeList">倉庫コードリスト</param>
        /// <param name="warehouseShelfNoList">棚番リスト</param>
        /// <param name="makerCodeList">メーカーコードリスト</param>
        /// <param name="blGoodsCodeList">BLコードリスト</param>
        /// <param name="goodsNoList">品番コードリスト</param>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmentPartsDspParamクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchParam(string enterpriseCode, string GoodsNo, Int32 GoodsMakerCd, string WarehouseCode, Int32 StAddUpYearMonth, Int32 EdAddUpYearMonth, Int32 StAddUpDate, Int32 EdAddUpDate, string SectionCode, List<string> warehouseCodeList, List<string> warehouseShelfNoList, List<Int32> makerCodeList, List<Int32> blGoodsCodeList, List<string> goodsNoList)
        {
            this._enterpriseCode = enterpriseCode;
            this._goodsNo = GoodsNo;
            this._goodsMakerCd = GoodsMakerCd;
            this._warehouseCode = WarehouseCode;
            this._stAddUpYearMonth = StAddUpYearMonth;
            this._edAddUpYearMonth = EdAddUpYearMonth;
            this._stAddUpDate = StAddUpDate;
            this._edAddUpDate = EdAddUpDate;
            this._sectionCode = SectionCode;
            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            this._warehouseCodeList = warehouseCodeList;
            this._warehouseShelfNoList = warehouseShelfNoList;
            this._makerCodeList = makerCodeList;
            this._blGoodsCodeList = blGoodsCodeList;
            this._goodsNoList = goodsNoList;
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
        }

	
        /// <summary>
        /// 出荷部品表示条件クラス複製処理
        /// </summary>
        /// <returns>ShipmentPartsDspParamクラスのインスタンス</returns>
        /// <remarks>
        /// 
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmentPartsDspParamクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockHistoryDspSearchParam Clone()
        {
            return new StockHistoryDspSearchParam(this._enterpriseCode, this._goodsNo,this._goodsMakerCd, this._warehouseCode, this._stAddUpYearMonth, this._edAddUpYearMonth, this._stAddUpDate, this._edAddUpDate, this._sectionCode, this._warehouseCodeList, this._warehouseShelfNoList, this._makerCodeList, this._blGoodsCodeList, this._goodsNoList);
        }
    }
}
