using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ConfirmStockAdjustListCndtn
	/// <summary>
	///                      在庫調整確認表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫調整確認表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/01/26 照田 貴志　不具合対応[10505]</br>
    /// <br>Update Note      :   2010/11/15 tianjw</br>
    /// <br>                     ・ＰＭ．ＮＳ　機能改良Ｑ４</br>
	/// </remarks>
	public class ConfirmStockAdjustListCndtn
	{
		#region ■ Private Member
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>（配列）</remarks>
		//private string[] _sectionCodeList = "";
        private string[] _sectionCodeList;

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>受払元伝票区分</summary>
		//private Int32 _acPaySlipCd;           //DEL 2009/01/26 不具合対応[10505]
        private Int32[] _acPaySlipCd;           //ADD 2009/01/26 不具合対応[10505]

		/// <summary>受払元取引区分</summary>
		private Int32 _acPayTransCd;

		/// <summary>開始調整日付</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AdjustDate;

		/// <summary>終了調整日付</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AdjustDate;

        //--- ADD 2008/07/04 ---------->>>>>
        /// <summary>開始入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_InputDay;

        /// <summary>終了入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_InputDay;
        //--- ADD 2008/07/04 ----------<<<<<

		/// <summary>開始在庫調整伝票番号</summary>
		private Int32 _st_StockAdjustSlipNo;

		/// <summary>終了在庫調整伝票番号</summary>
		private Int32 _ed_StockAdjustSlipNo;

		/// <summary>開始メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>開始入力担当者</summary>
		private string _st_InputAgenCd = "";

		/// <summary>終了入力担当者</summary>
		private string _ed_InputAgenCd = "";

		/// <summary>在庫区分</summary>
		private Int32 _stockDiv;

		/// <summary>帳票タイプ区分</summary>
		/// <remarks>設定コードと同じ</remarks>
		private Int32 _printDiv;

		/// <summary>帳票タイプ区分名称</summary>
		private string _printDivName = "";

        //--- ADD 2008/07/07 ---------->>>>>
        /// <summary>
        /// 改頁情報
        /// </summary>
        private int _changePage;
        //--- ADD 2008/07/07 ----------<<<<<

        //--- ADD 2010/11/15 ---------->>>>>
        /// <summary>
        /// 出力順情報
        /// </summary>
        private int _outputSort;
        //--- ADD 2010/11/15 ----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat						= "YYYY/MM/DD";

		/// <summary>共通 全て コード</summary>
		public const int ct_All_Code							= -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name							= "全て";
		#endregion

		#region ■ Public Property
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

		/// public propaty name  :  SectionCodeList
		/// <summary>拠点コードプロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodeList
		{
			get{return _sectionCodeList;}
			set{_sectionCodeList = value;}
		}

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   金沢　貞義</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._sectionCodeList.Length == 1) && (this._sectionCodeList[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  St_WarehouseCode
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public Int32 AcPaySlipCd          //DEL 2009/01/26 不具合対応[10505]
		public Int32[] AcPaySlipCd          //ADD 2009/01/26 不具合対応[10505]
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>受払元取引区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元取引区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  St_AdjustDate
		/// <summary>開始調整日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始調整日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AdjustDate
		{
			get{return _st_AdjustDate;}
			set{_st_AdjustDate = value;}
		}

		/// public propaty name  :  Ed_AdjustDate
		/// <summary>終了調整日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了調整日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AdjustDate
		{
			get{return _ed_AdjustDate;}
			set{_ed_AdjustDate = value;}
		}

        //--- ADD 2008/07/04 ---------->>>>>
        /// public propaty name  :  St_AdjustDate
        /// <summary>開始入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_AdjustDate
        /// <summary>終了入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }
        //--- ADD 2008/07/04 ----------<<<<<
        
        /// public propaty name  :  St_StockAdjustSlipNo
		/// <summary>開始在庫調整伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始在庫調整伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_StockAdjustSlipNo
		{
			get{return _st_StockAdjustSlipNo;}
			set{_st_StockAdjustSlipNo = value;}
		}

		/// public propaty name  :  Ed_StockAdjustSlipNo
		/// <summary>終了在庫調整伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了在庫調整伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_StockAdjustSlipNo
		{
			get{return _ed_StockAdjustSlipNo;}
			set{_ed_StockAdjustSlipNo = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  St_InputAgenCd
		/// <summary>開始入力担当者プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力担当者プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_InputAgenCd
		{
			get{return _st_InputAgenCd;}
			set{_st_InputAgenCd = value;}
		}

		/// public propaty name  :  Ed_InputAgenCd
		/// <summary>終了入力担当者プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力担当者プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_InputAgenCd
		{
			get{return _ed_InputAgenCd;}
			set{_ed_InputAgenCd = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>在庫区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>帳票タイプ区分プロパティ</summary>
		/// <value>設定コードと同じ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

		/// public propaty name  :  PrintDivName
		/// <summary>帳票タイプ区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrintDivName
		{
			get{return _printDivName;}
			set{_printDivName = value;}
		}
        //--- ADD 2008/07/07 ---------->>>>>
        /// <summary>
        /// 改頁情報プロパティ
        /// </summary>
        public int ChangePage
        {
            get { return this._changePage; }
            set { this._changePage = value; }
        }
        //--- ADD 2008/07/07 ----------<<<<<

        //--- ADD 2010/11/15 ---------->>>>>
        /// <summary>
        /// 出力順情報プロパティ
        /// </summary>
        public int OutputSort
        {
            get { return this._outputSort; }
            set { this._outputSort = value; }
        }
        //--- ADD 2010/11/15 ----------<<<<<

		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
			/// <summary> 半黒作成確認表 </summary>
			HalfBlackSet = 1,
			/// <summary> 半黒解除確認表 </summary>
			HalfBlackClear = 2,
			/// <summary> 在庫数調整確認表 </summary>
			StockCountRegulation = 3,
			/// <summary> 原価訂正確認表 </summary>
			CostRevision = 4,
			/// <summary> 製造番号修正確認表 </summary>
			SerialNoRevision = 5,
		}
		#endregion
		#endregion ■ Public Enum

		#region ■ Constructor
		/// <summary>
		/// ワークコンストラクタ
		/// </summary>
		/// <returns>DepositMainCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositMainCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ConfirmStockAdjustListCndtn()
		{
            this._sectionCodeList			= new string[0];	// 計上拠点コードリスト 
            this._st_AdjustDate             = DateTime.Now;		// 開始調整日付
			this._ed_AdjustDate				= DateTime.Now;		// 終了調整日付
		}
		#endregion ■ Constructor

	}
}
