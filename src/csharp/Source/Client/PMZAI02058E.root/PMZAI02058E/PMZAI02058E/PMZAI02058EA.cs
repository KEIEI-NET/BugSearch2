using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockSignOrderCndtn
	/// <summary>
	///                      在庫看板印刷抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫看板印刷抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockSignOrderCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		private string[] _sectionCodes;

		/// <summary>倉庫コード(開始)</summary>
		private string _st_WarehouseCode = "";

		/// <summary>倉庫コード(終了)</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>商品メーカーコード(開始)</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>商品メーカーコード(終了)</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>倉庫棚番(開始)</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>倉庫棚番(終了)</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>商品番号(開始)</summary>
		private string _st_GoodsNo = "";

		/// <summary>商品番号(終了)</summary>
		private string _ed_GoodsNo = "";

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:棚番ラベル 1:在庫枚数分</remarks>
        private PrintTypeState _printType;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // 自動生成以外
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;
        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;

        /// <summary>印刷順</summary>
        private PrintOrderState _printOrder;
        /// <summary>ラベルタイプ</summary>
        private LabelTypeState _labelType;
        /// <summary>印刷開始行</summary>
        private PrintStartRowState _printStartRow;


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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>倉庫コード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>倉庫コード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>商品メーカーコード(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコード(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>商品メーカーコード(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコード(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>倉庫棚番(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>倉庫棚番(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>商品番号(開始)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号(開始)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>商品番号(終了)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号(終了)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>印刷タイププロパティ</summary>
		/// <value>0:棚番ラベル 1:在庫枚数分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public PrintTypeState PrintType
		{
			get{return _printType;}
			set{_printType = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        // 自動生成以外

        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// 印刷順
        /// </summary>
        public PrintOrderState PrintOrder
        {
            get { return _printOrder; }
            set { _printOrder = value; }
        }

        /// <summary>
        /// ラベルタイプ
        /// </summary>
        public LabelTypeState LabelType
        {
            get { return _labelType; }
            set { _labelType = value; }
        }

        /// <summary>
        /// 印刷開始行
        /// </summary>
        public PrintStartRowState PrintStartRow
        {
            get { return _printStartRow; }
            set { _printStartRow = value; }
        }


		/// <summary>
		/// 在庫看板印刷抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>StockSignOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSignOrderCndtn()
		{
		}

		/// <summary>
		/// 在庫看板印刷抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード（複数指定）</param>
		/// <param name="st_WarehouseCode">倉庫コード(開始)</param>
		/// <param name="ed_WarehouseCode">倉庫コード(終了)</param>
		/// <param name="st_GoodsMakerCd">商品メーカーコード(開始)</param>
		/// <param name="ed_GoodsMakerCd">商品メーカーコード(終了)</param>
		/// <param name="st_WarehouseShelfNo">倉庫棚番(開始)</param>
		/// <param name="ed_WarehouseShelfNo">倉庫棚番(終了)</param>
		/// <param name="st_GoodsNo">商品番号(開始)</param>
		/// <param name="ed_GoodsNo">商品番号(終了)</param>
		/// <param name="printType">印刷順(0:棚番ラベル 1:在庫枚数分)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>StockSignOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public StockSignOrderCndtn(string enterpriseCode, string[] sectionCodes, string st_WarehouseCode, string ed_WarehouseCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string st_WarehouseShelfNo, string ed_WarehouseShelfNo, string st_GoodsNo, string ed_GoodsNo, PrintTypeState printType, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, PrintOrderState printOrder, LabelTypeState labelType, PrintStartRowState printStartRow)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._st_WarehouseCode = st_WarehouseCode;
			this._ed_WarehouseCode = ed_WarehouseCode;
			this._st_GoodsMakerCd = st_GoodsMakerCd;
			this._ed_GoodsMakerCd = ed_GoodsMakerCd;
			this._st_WarehouseShelfNo = st_WarehouseShelfNo;
			this._ed_WarehouseShelfNo = ed_WarehouseShelfNo;
			this._st_GoodsNo = st_GoodsNo;
			this._ed_GoodsNo = ed_GoodsNo;
			this._printType = printType;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._printOrder = printOrder;
            this._labelType = labelType;
            this._printStartRow = printStartRow;
		}

		/// <summary>
		/// 在庫看板印刷抽出条件クラス複製処理
		/// </summary>
		/// <returns>StockSignOrderCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockSignOrderCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSignOrderCndtn Clone()
		{
            return new StockSignOrderCndtn(this._enterpriseCode, this._sectionCodes, this._st_WarehouseCode, this._ed_WarehouseCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._st_WarehouseShelfNo, this._ed_WarehouseShelfNo, this._st_GoodsNo, this._ed_GoodsNo, this._printType, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._printOrder, this._labelType, this._printStartRow);
		}

		/// <summary>
		/// 在庫看板印刷抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSignOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockSignOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_WarehouseCode == target.St_WarehouseCode)
				 && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
				 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
				 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
				 && (this.St_WarehouseShelfNo == target.St_WarehouseShelfNo)
				 && (this.Ed_WarehouseShelfNo == target.Ed_WarehouseShelfNo)
				 && (this.St_GoodsNo == target.St_GoodsNo)
				 && (this.Ed_GoodsNo == target.Ed_GoodsNo)
				 && (this.PrintType == target.PrintType)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.PrintOrder == target.PrintOrder)
                 && (this.LabelType == target.LabelType)
                 && (this.PrintStartRow == target.PrintStartRow)
                 );
		}

		/// <summary>
		/// 在庫看板印刷抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockSignOrderCndtn1">
		///                    比較するStockSignOrderCndtnクラスのインスタンス
		/// </param>
		/// <param name="stockSignOrderCndtn2">比較するStockSignOrderCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockSignOrderCndtn stockSignOrderCndtn1, StockSignOrderCndtn stockSignOrderCndtn2)
		{
			return ((stockSignOrderCndtn1.EnterpriseCode == stockSignOrderCndtn2.EnterpriseCode)
				 && (stockSignOrderCndtn1.SectionCodes == stockSignOrderCndtn2.SectionCodes)
				 && (stockSignOrderCndtn1.St_WarehouseCode == stockSignOrderCndtn2.St_WarehouseCode)
				 && (stockSignOrderCndtn1.Ed_WarehouseCode == stockSignOrderCndtn2.Ed_WarehouseCode)
				 && (stockSignOrderCndtn1.St_GoodsMakerCd == stockSignOrderCndtn2.St_GoodsMakerCd)
				 && (stockSignOrderCndtn1.Ed_GoodsMakerCd == stockSignOrderCndtn2.Ed_GoodsMakerCd)
				 && (stockSignOrderCndtn1.St_WarehouseShelfNo == stockSignOrderCndtn2.St_WarehouseShelfNo)
				 && (stockSignOrderCndtn1.Ed_WarehouseShelfNo == stockSignOrderCndtn2.Ed_WarehouseShelfNo)
				 && (stockSignOrderCndtn1.St_GoodsNo == stockSignOrderCndtn2.St_GoodsNo)
				 && (stockSignOrderCndtn1.Ed_GoodsNo == stockSignOrderCndtn2.Ed_GoodsNo)
				 && (stockSignOrderCndtn1.PrintType == stockSignOrderCndtn2.PrintType)
				 && (stockSignOrderCndtn1.EnterpriseName == stockSignOrderCndtn2.EnterpriseName)
                 && (stockSignOrderCndtn1.IsOptSection == stockSignOrderCndtn2.IsOptSection)
                 && (stockSignOrderCndtn1.IsSelectAllSection == stockSignOrderCndtn2.IsSelectAllSection)
                 && (stockSignOrderCndtn1.PrintOrder == stockSignOrderCndtn2.PrintOrder)
                 && (stockSignOrderCndtn1.LabelType == stockSignOrderCndtn2.LabelType)
                 && (stockSignOrderCndtn1.PrintStartRow == stockSignOrderCndtn2.PrintStartRow)
                 );
		}
		/// <summary>
		/// 在庫看板印刷抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSignOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockSignOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
			if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
			if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(this.St_WarehouseShelfNo != target.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
			if(this.Ed_WarehouseShelfNo != target.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
			if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
			if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
			if(this.PrintType != target.PrintType)resList.Add("PrintType");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsOptSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.PrintOrder != target.PrintOrder) resList.Add("PrintOrder");
            if (this.LabelType != target.LabelType) resList.Add("LabelType");
            if (this.PrintStartRow != target.PrintStartRow) resList.Add("PrintStartRow");

			return resList;
		}

		/// <summary>
		/// 在庫看板印刷抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockSignOrderCndtn1">比較するStockSignOrderCndtnクラスのインスタンス</param>
		/// <param name="stockSignOrderCndtn2">比較するStockSignOrderCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSignOrderCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockSignOrderCndtn stockSignOrderCndtn1, StockSignOrderCndtn stockSignOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(stockSignOrderCndtn1.EnterpriseCode != stockSignOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockSignOrderCndtn1.SectionCodes != stockSignOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(stockSignOrderCndtn1.St_WarehouseCode != stockSignOrderCndtn2.St_WarehouseCode)resList.Add("St_WarehouseCode");
			if(stockSignOrderCndtn1.Ed_WarehouseCode != stockSignOrderCndtn2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
			if(stockSignOrderCndtn1.St_GoodsMakerCd != stockSignOrderCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
			if(stockSignOrderCndtn1.Ed_GoodsMakerCd != stockSignOrderCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
			if(stockSignOrderCndtn1.St_WarehouseShelfNo != stockSignOrderCndtn2.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
			if(stockSignOrderCndtn1.Ed_WarehouseShelfNo != stockSignOrderCndtn2.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
			if(stockSignOrderCndtn1.St_GoodsNo != stockSignOrderCndtn2.St_GoodsNo)resList.Add("St_GoodsNo");
			if(stockSignOrderCndtn1.Ed_GoodsNo != stockSignOrderCndtn2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
			if(stockSignOrderCndtn1.PrintType != stockSignOrderCndtn2.PrintType)resList.Add("PrintType");
            if (stockSignOrderCndtn1.EnterpriseName != stockSignOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockSignOrderCndtn1.IsOptSection != stockSignOrderCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (stockSignOrderCndtn1.IsSelectAllSection != stockSignOrderCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (stockSignOrderCndtn1.PrintOrder != stockSignOrderCndtn2.PrintOrder) resList.Add("PrintOrder");
            if (stockSignOrderCndtn1.LabelType != stockSignOrderCndtn2.LabelType) resList.Add("LabelType");
            if (stockSignOrderCndtn1.PrintStartRow != stockSignOrderCndtn2.PrintStartRow) resList.Add("PrintStartRow");

			return resList;
		}

        #region ■列挙体
        /// <summary>
        /// 印刷タイプ
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>棚番ラベル</summary>
            ShelfNo = 0,
            /// <summary>在庫枚数分</summary>
            StockNum = 1
        }

        /// <summary>
        /// 印刷順
        /// </summary>
        public enum PrintOrderState
        {
            /// <summary>品番順</summary>
            GoodsNo = 0,
            /// <summary>棚番順</summary>
            ShelfNo = 1
        }

        /// <summary>
        /// ラベルタイプ
        /// </summary>
        public enum LabelTypeState
        {
            /// <summary>５×９（ドット）</summary>
            Dot_FiveByNine = 0,
            /// <summary>３×９（ドット）</summary>
            Dot_ThreeByNine = 1,
            /// <summary>３×９（レーザー）</summary>
            Laser_ThreeByNine = 2,
            /// <summary>４×１１（レーザー）</summary>
            Laser_FourByEleven = 3
        }

        /// <summary>
        /// 印刷開始行
        /// </summary>
        public enum PrintStartRowState
        {
            /// <summary>1行目</summary>
            One = 0,
            /// <summary>2行目</summary>
            Two = 1,
            /// <summary>3行目</summary>
            Three = 2,
            /// <summary>4行目</summary>
            Four = 3,
            /// <summary>5行目</summary>
            Five = 4,
            /// <summary>6行目</summary>
            Six = 5,
            /// <summary>7行目</summary>
            Seven = 6,
            /// <summary>8行目</summary>
            Eight = 7,
            /// <summary>9行目</summary>
            Nine = 8,
            /// <summary>10行目</summary>
            Ten = 9,
            /// <summary>11行目</summary>
            Eleven = 10
        }
        #endregion
    }
}
