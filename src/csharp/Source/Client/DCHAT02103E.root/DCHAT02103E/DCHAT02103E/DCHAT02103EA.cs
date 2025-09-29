using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OrderListCndtn
	/// <summary>
	///                      発注一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   発注一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008.12.10  渋谷　大輔</br>
    /// <br>                 :   帳票タイプ区分追加</br>
    /// <br>Note             :   ハンディターミナル二次開発の対応</br>
    /// <br>Programmer       :   譚洪</br>
    /// <br>Date             :   2017/09/14</br>
    /// <br>Update Note      :   ㈱ダイサブの対応</br>
    /// <br>Programmer       :   譚洪</br>
    /// <br>Date             :   2019/11/05</br>
	/// </remarks>
	public class OrderListCndtn
	{
        # region ■ private field ■

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード（複数指定）</summary>
        /// <remarks>（配列）（仕入明細）</remarks>
        private string[] _sectionCodes = new string[0];

        /// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>倉庫指定（複数指定）</summary>
		/// <remarks>nullの場合は、開始終了範囲指定を使用</remarks>
        private string[] _warehouseCodes = new string[0];

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCode;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCode;

		/// <summary>仕入先指定（複数指定</summary>
		/// <remarks>nullの場合は、開始終了範囲指定を使用</remarks>
		private Int32[] _supplierCodes;

		/// <summary>受託在庫区分</summary>
		/// <remarks>0:発注対象としない,1:発注対象とする</remarks>
		private Int32 _trustStockDiv;

		/// <summary>対象区分</summary>
		/// <remarks>0:全て,1:UOE発注分,2:UOE発注以外</remarks>
		private Int32 _objDiv;

		/// <summary>UOE以外発注残更新</summary>
		/// <remarks>0:する,しない</remarks>
		private Int32 _orderRemainUpDate;

		/// <summary>現在庫数基準</summary>
		/// <remarks>0:ﾏｲﾅｽはｾﾞﾛで計算,1:ﾏｲﾅｽも含めて計算</remarks>
		private Int32 _stkCntStandard;

		/// <summary>発注基準</summary>
		/// <remarks>0:最低在庫,1:最高在庫</remarks>
		private Int32 _orderStandard;

		/// <summary>貸出数計算</summary>
		/// <remarks>0:する,しない</remarks>
		private Int32 _lendCntCalc;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>0:発注一覧表,1:発注残一覧表</remarks>
        private Int32 _prtPaperTypeDiv;

        /// <summary>企業名称</summary>
		private string _enterpriseName = "";

        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
        /// <summary>メーカー出力区分</summary>
        /// <remarks>0:出力しない,1:出力する</remarks>
        private Int32 _makerCdDiv;

        /// <summary>自社名印字区分</summary>
        private Int32 _coNmPrintOutCd;
        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

        # endregion  ■ private field ■

        # region ■ public propaty ■

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コード（複数指定）プロパティ</summary>
        /// <value>（配列）（仕入明細）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
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

		/// public propaty name  :  WarehouseCodes
		/// <summary>倉庫指定（複数指定）プロパティ</summary>
		/// <value>nullの場合は、開始終了範囲指定を使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫指定（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] WarehouseCodes
		{
			get{return _warehouseCodes;}
			set{_warehouseCodes = value;}
		}

		/// public propaty name  :  St_SupplierCode
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SupplierCode
		{
			get{return _st_SupplierCode;}
			set{_st_SupplierCode = value;}
		}

		/// public propaty name  :  Ed_SupplierCode
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_SupplierCode
		{
			get{return _ed_SupplierCode;}
			set{_ed_SupplierCode = value;}
		}

		/// public propaty name  :  SupplierCodes
		/// <summary>仕入先指定（複数指定プロパティ</summary>
		/// <value>nullの場合は、開始終了範囲指定を使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先指定（複数指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] SupplierCodes
		{
			get{return _supplierCodes;}
			set{_supplierCodes = value;}
		}

		/// public propaty name  :  TrustStockDiv
		/// <summary>受託在庫区分プロパティ</summary>
		/// <value>0:発注対象としない,1:発注対象とする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受託在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TrustStockDiv
		{
			get{return _trustStockDiv;}
			set{_trustStockDiv = value;}
		}

		/// public propaty name  :  ObjDiv
		/// <summary>対象区分プロパティ</summary>
		/// <value>0:全て,1:UOE発注分,2:UOE発注以外</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ObjDiv
		{
			get{return _objDiv;}
			set{_objDiv = value;}
		}

		/// public propaty name  :  OrderRemainUpDate
		/// <summary>UOE以外発注残更新プロパティ</summary>
		/// <value>0:する,しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE以外発注残更新プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderRemainUpDate
		{
			get{return _orderRemainUpDate;}
			set{_orderRemainUpDate = value;}
		}

		/// public propaty name  :  StkCntStandard
		/// <summary>現在庫数基準プロパティ</summary>
		/// <value>0:ﾏｲﾅｽはｾﾞﾛで計算,1:ﾏｲﾅｽも含めて計算</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   現在庫数基準プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StkCntStandard
		{
			get{return _stkCntStandard;}
			set{_stkCntStandard = value;}
		}

		/// public propaty name  :  OrderStandard
		/// <summary>発注基準プロパティ</summary>
		/// <value>0:最低在庫,1:最高在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注基準プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderStandard
		{
			get{return _orderStandard;}
			set{_orderStandard = value;}
		}

		/// public propaty name  :  LendCntCalc
		/// <summary>貸出数計算プロパティ</summary>
		/// <value>0:する,しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   貸出数計算プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LendCntCalc
		{
			get{return _lendCntCalc;}
			set{_lendCntCalc = value;}
		}

        /// public propaty name  :  PrtPaperTypeDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>0:発注一覧表,1:発注残一覧表</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtPaperTypeDiv
        {
            get { return _prtPaperTypeDiv; }
            set { _prtPaperTypeDiv = value; }
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

        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- >>>>
        /// public propaty name  :  MakerCdDiv
        /// <summary>メーカー出力区分プロパティ</summary>
        /// <value>0:出力しない,1:出力する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCdDiv
        {
            get { return _makerCdDiv; }
            set { _makerCdDiv = value; }
        }

        /// public propaty name  :  CoNmPrintOutCd
        /// <summary>自社名印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名印字区分プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 CoNmPrintOutCd
        {
            get { return _coNmPrintOutCd; }
            set { _coNmPrintOutCd = value; }
        }
        // ------ ADD 2019/11/05 譚洪 ㈱ダイサブの対応 --------- <<<<

		# endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
        ///// <summary>
        ///// メモ印刷区分
        ///// </summary>
        //private NotePrintDivState _notePrintDiv;

        /// <summary>
        /// 処理日
        /// </summary>
        private DateTime _processDay;

        /// <summary>
        /// 一括仕入入力データ作成区分
        /// </summary>
        private int _blanketStockInputDataDiv;

        /// <summary>
        /// 現在庫・最低・最高印字区分
        /// </summary>
        private int _stockMinMaxPrintDiv;

        /// <summary>
        /// ロット計算区分
        /// </summary>
        private int _lotCalcDiv;

        /// <summary>
        /// 貸出数印字区分
        /// </summary>
        private int _lendCntPrintDiv;

        /// <summary>
        /// 改頁区分
        /// </summary>
        private int _newPageDiv;

        /// <summary>
        /// FAX送信区分
        /// </summary>
        private int _faxSendDiv;

        /// <summary>
        /// 印刷順区分
        /// </summary>
        private PrintSortDivState _printSortDiv;

        /// <summary>
        /// 倉庫抽出条件
        /// </summary>
        private int _warehouseExtra;

        /// <summary>
        /// 仕入先抽出条件
        /// </summary>
        private int _supplierExtra;

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>バーコード表示区分</summary>
        private int _barCodeShowDiv;
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<


        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
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
        ///// <summary>
        ///// メモ印刷区分
        ///// </summary>
        //public NotePrintDivState NotePrintDiv
        //{
        //    get { return this._notePrintDiv; }
        //    set { this._notePrintDiv = value; }
        //}

        /// <summary>
        /// 処理日
        /// </summary>
        public DateTime ProcessDay
        {
            get { return this._processDay; }
            set { this._processDay = value; }
        }

        /// <summary>
        /// 一括仕入入力データ作成区分
        /// </summary>
        public int BlanketStockInputDataDiv
        {
            get { return this._blanketStockInputDataDiv; }
            set { this._blanketStockInputDataDiv = value; }
        }

        /// <summary>
        /// 現在庫・最低・最高印字区分
        /// </summary>
        public int StockMinMaxPrintDiv
        {
            get { return this._stockMinMaxPrintDiv; }
            set { this._stockMinMaxPrintDiv = value; }
        }

        /// <summary>
        /// ロット計算区分
        /// </summary>
        public int LotCalcDiv
        {
            get { return this._lotCalcDiv; }
            set { this._lotCalcDiv = value; }
        }

        /// <summary>
        /// 貸出数印字区分
        /// </summary>
        public int LendCntPrintDiv
        {
            get { return this._lendCntPrintDiv; }
            set { this._lendCntPrintDiv = value; }
        }

        /// <summary>
        /// 改頁区分
        /// </summary>
        public int NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// FAX送信区分
        /// </summary>
        public int FaxSendDiv
        {
            get { return this._faxSendDiv; }
            set { this._faxSendDiv = value; }
        }

        /// <summary>
        /// 印刷順区分
        /// </summary>
        public PrintSortDivState PrintSortDiv
        {
            get { return this._printSortDiv; }
            set { this._printSortDiv = value; }
        }

        /// <summary>
        /// 倉庫抽出条件
        /// </summary>
        public int WarehouseExtra
        {
            get { return this._warehouseExtra; }
            set { this._warehouseExtra = value; }
        }

        /// <summary>
        /// 仕入先抽出条件
        /// </summary>
        public int SupplierExtra
        {
            get { return this._supplierExtra; }
            set { this._supplierExtra = value; }
        }

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// public propaty name  :  BarCodeShowDiv
        /// <summary>バーコード表示区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコード表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int BarCodeShowDiv
        {
            get { return _barCodeShowDiv; }
            set { _barCodeShowDiv = value; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<


        /// <summary>
        /// 印刷順名称取得
        /// </summary>
        public string PrintSortDivTitle
        {
            get
            {
                switch ( this._printSortDiv )
                {
                    case PrintSortDivState.ByOrderMakerGoodNo: return ct_PrintSortDivState_ByOrderMakerGoodNo;
                    case PrintSortDivState.ByOrderShelfNo: return ct_PrintSortDivState_ByOrderShelfNo;
                    default: return string.Empty;
                }
            }
        }
        ///// <summary>
        ///// 発注済み区分名称
        ///// </summary>
        //public string OrderFormIssuedDivTitle
        //{
        //    get
        //    {
        //        string returnString = string.Empty;

        //        for ( int index = 0; index < this._orderFormIssuedDivs.Length; index++ )
        //        {
        //            OrderFormIssuedDivState orderformIssuedDivState = (OrderFormIssuedDivState)this._orderFormIssuedDivs[index];

        //            switch ( orderformIssuedDivState )
        //            {
        //                case OrderFormIssuedDivState.NoPrinted:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_OrderFormIssuedDivState_NoPrinted;
        //                    break;
        //                case OrderFormIssuedDivState.Printed:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_OrderFormIssuedDivState_Printed;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        return returnString;
        //    }
        //}
        ///// <summary>
        ///// 発注形態名称取得
        ///// </summary>
        //public string StockOrderDivCdTitle
        //{
        //    get
        //    {
        //        string returnString = string.Empty;

        //        for ( int index = 0; index < this._stockOrderDivCds.Length; index++ )
        //        {
        //            StockOrderDivCdState stockOrderDivCdState = (StockOrderDivCdState)this._stockOrderDivCds[index];

        //            switch ( stockOrderDivCdState )
        //            {
        //                case StockOrderDivCdState.Order:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_StockOrderDivCdState_Order;
        //                    break;
        //                case StockOrderDivCdState.Stock:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_StockOrderDivCdState_Stock;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        return returnString;
        //    }
        //}
        ///// <summary>
        ///// 入荷状況名称取得
        ///// </summary>
        //public string ArrivalStateDivTitle
        //{
        //    get
        //    {
        //        string returnString = string.Empty;

        //        for ( int index = 0; index < this._arrivalStateDiv.Length; index++ )
        //        {
        //            ArrivalStateDivState arrivalState = (ArrivalStateDivState)this._arrivalStateDiv[index];

        //            switch ( arrivalState )
        //            {
        //                case ArrivalStateDivState.NoArrivaled:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_ArrivalStateDivState_NoArrivaled;
        //                    break;
        //                case ArrivalStateDivState.PartArrivaled:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_ArrivalStateDivState_PartArrivaled;
        //                    break;
        //                case ArrivalStateDivState.AllArrivaled:
        //                    if ( returnString != string.Empty ) returnString += "＋";
        //                    returnString += ct_ArrivalStateDivState_AllArrivaled;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        return returnString;
        //    }
        //}
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        ///// <summary>
        ///// メモ印刷区分　列挙体
        ///// </summary>
        //public enum NotePrintDivState
        //{
        //    /// <summary>印刷しない</summary>
        //    None = 0,
        //    /// <summary>印刷する</summary>
        //    Print = 1,
        //}
        /// <summary>
        /// 印刷順区分　列挙体
        /// </summary>
        public enum PrintSortDivState
        {
            /// <summary>メーカー・品番順</summary>
            ByOrderMakerGoodNo = 0,
            /// <summary>棚番順</summary>
            ByOrderShelfNo = 1,
        }
        ///// <summary>
        ///// 入荷状況区分　列挙体
        ///// </summary>
        //public enum ArrivalStateDivState
        //{
        //    /// <summary>未入荷</summary>
        //    NoArrivaled = 0,
        //    /// <summary>一部入荷済み</summary>
        //    PartArrivaled = 1,
        //    /// <summary>全て入荷済み</summary>
        //    AllArrivaled = 2,
        //}
        ///// <summary>
        ///// 発注書発行済み区分　列挙体
        ///// </summary>
        //public enum OrderFormIssuedDivState
        //{
        //    /// <summary>未発行</summary>
        //    NoPrinted = 0,
        //    /// <summary>発行済</summary>
        //    Printed = 1,
        //}
        ///// <summary>
        ///// 仕入在庫取寄せ区分　列挙体
        ///// </summary>
        //public enum StockOrderDivCdState
        //{
        //    /// <summary>取寄</summary>
        //    Order = 0,
        //    /// <summary>在庫</summary>
        //    Stock = 1,
        //}
        ///// <summary>
        ///// 赤伝区分　列挙体
        ///// </summary>
        //public enum DebitNoteDivState
        //{
        //    /// <summary>黒伝</summary>
        //    Normal = 0,
        //    /// <summary>赤伝</summary>
        //    DebitNote = 1,
        //    /// <summary>元黒</summary>
        //    OrgNormal = 2,
        //}
        ///// <summary>
        ///// 仕入伝票区分　列挙体
        ///// </summary>
        //public enum SupplierSlipCdState
        //{
        //    /// <summary>仕入</summary>
        //    Stock = 10,
        //    /// <summary>返品</summary>
        //    Return = 20,
        //}
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>印刷順区分　メーカー・品番順</summary>
        public const string ct_PrintSortDivState_ByOrderMakerGoodNo = "メーカー・品番順";
        /// <summary>印刷順区分　棚番順</summary>
        public const string ct_PrintSortDivState_ByOrderShelfNo = "棚番順";
        ///// <summary>印刷順区分　発注日順</summary>
        //public const string ct_PrintSortDivState_ByOrderFormPrintDate = "発注日";
        ///// <summary>印刷順区分　メーカー・商品別発注日順</summary>
        //public const string ct_PrintSortDivState_ByMakerGoodsSalesOrderDate = "メーカー＋商品番号＋発注日";
        ///// <summary>印刷順区分　発注先別発注日順</summary>
        //public const string ct_PrintSortDivState_BySupplierSalesOrderDate = "発注先＋発注日";

        ///// <summary>発注書発行済区分　未発注</summary>
        //public const string ct_OrderFormIssuedDivState_NoPrinted = "未発注";
        ///// <summary>発注書発行済区分　発注済</summary>
        //public const string ct_OrderFormIssuedDivState_Printed = "発注済み";

        ///// <summary>赤伝区分　黒伝</summary>
        //public const string ct_DebitNoteDivState_Normal = "黒伝";
        ///// <summary>赤伝区分　赤伝</summary>
        //public const string ct_DebitNoteDivState_DebitNote = "赤伝";
        ///// <summary>赤伝区分　元黒</summary>
        //public const string ct_DebitNoteDivState_OrgNormal = "元黒";

        ///// <summary>仕入伝票区分　仕入</summary>
        //public const string ct_SupplierSlipCdState_Stock = "仕入";
        ///// <summary>仕入伝票区分　返品</summary>
        //public const string ct_SupplierSlipCdState_Return = "返品";

        ///// <summary>入荷状況　未入荷</summary>
        //public const string ct_ArrivalStateDivState_NoArrivaled = "未入荷";
        ///// <summary>入荷状況　一部入荷済</summary>
        //public const string ct_ArrivalStateDivState_PartArrivaled = "一部入荷済";
        ///// <summary>入荷状況　全て入荷済</summary>
        //public const string ct_ArrivalStateDivState_AllArrivaled = "全て入荷済";

        ///// <summary>仕入在庫取寄せ区分　取寄せ</summary>
        //public const string ct_StockOrderDivCdState_Order = "取寄せ";
        ///// <summary>仕入在庫取寄せ区分　在庫</summary>
        //public const string ct_StockOrderDivCdState_Stock = "在庫";

        #endregion ■ public const (自動生成以外) ■

        # region ■ public static Method (自動生成以外) ■
        ///// <summary>
        ///// 赤伝区分名称取得処理
        ///// </summary>
        ///// <param name="debitNoteDiv">赤伝区分</param>
        ///// <returns>赤伝区分名称</returns>
        //public static string GetDebitNoteDivNm( int debitNoteDiv )
        //{
        //    switch (debitNoteDiv) {
        //        case ( int ) DebitNoteDivState.Normal: return ct_DebitNoteDivState_Normal;
        //        case ( int ) DebitNoteDivState.DebitNote: return ct_DebitNoteDivState_DebitNote;
        //        case ( int ) DebitNoteDivState.OrgNormal: return ct_DebitNoteDivState_OrgNormal;                    
        //    }
        //    return string.Empty;
        //}
        ///// <summary>
        ///// 仕入伝票区分名称取得処理
        ///// </summary>
        ///// <param name="supplierSlipCd">仕入伝票区分</param>
        ///// <returns>仕入伝票区分名称</returns>
        //public static string GetSupplierSlipCdNm( int supplierSlipCd ) 
        //{
        //    switch (supplierSlipCd) {
        //        case ( int ) SupplierSlipCdState.Stock: return ct_SupplierSlipCdState_Stock;
        //        case ( int ) SupplierSlipCdState.Return: return ct_SupplierSlipCdState_Return;
        //    }
        //    return string.Empty;
        //}
        ///// <summary>
        ///// 発注書発行済区分名称取得処理
        ///// </summary>
        ///// <param name="orderFormIssuedDivCd">発注書発行済区分</param>
        ///// <returns>発注書発行済区分名称</returns>
        //public static string GetOrderFormIssuedDivNm ( int orderFormIssuedDivCd ) 
        //{
        //    switch ( orderFormIssuedDivCd ) {
        //        case ( int ) OrderFormIssuedDivState.NoPrinted: return ct_OrderFormIssuedDivState_NoPrinted;
        //        case ( int ) OrderFormIssuedDivState.Printed: return ct_OrderFormIssuedDivState_Printed;
        //    }
        //    return string.Empty;
        //}
        ///// <summary>
        ///// 仕入在庫取り寄せ区分名称取得
        ///// </summary>
        ///// <param name="stockOrderDivCd">仕入在庫取り寄せ区分</param>
        ///// <returns>仕入在庫取り寄せ区分名称</returns>
        //public static string GetStockOrderDivCdNm ( int stockOrderDivCd )
        //{
        //    switch ( stockOrderDivCd ) {
        //        case ( int ) StockOrderDivCdState.Order: return ct_StockOrderDivCdState_Order;
        //        case ( int ) StockOrderDivCdState.Stock: return ct_StockOrderDivCdState_Stock;
        //    }
        //    return string.Empty;
        //}
        # endregion ■ public static Method (自動生成以外) ■　

        # region ■ Constructor ■
        /// <summary>
        /// 発注一覧表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>OrderListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OrderListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}
