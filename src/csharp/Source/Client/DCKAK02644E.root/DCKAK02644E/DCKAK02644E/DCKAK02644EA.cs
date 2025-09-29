using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 買掛残高一覧表 得意先売掛金額データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 買掛残高一覧表 得意先売掛金額データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木　正臣</br>
	/// <br>Date       : 2007.10.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date	   : 2020/03/02</br>
    /// <br>UpdateNote : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 3H 仰亮亮</br>
    /// <br>Date       : 2022/10/09</br>
	/// </remarks>
	public class DCKAK02644EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string ct_Tbl_AccPaymentList = "Tbl_AccPaymentList";

        /// <summary> 計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 計上拠点名称 </summary>
        public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        /// <summary> 支払先コード </summary>
        public const string ct_Col_PayeeCode = "PayeeCode";
        ///// <summary> 支払先名称 </summary>
        //public const string ct_Col_PayeeName = "PayeeName";
        ///// <summary> 支払先名称2 </summary>
        //public const string ct_Col_PayeeName2 = "PayeeName2";
        /// <summary> 支払先略称 </summary>
        public const string ct_Col_PayeeSnm = "PayeeSnm";
        /// <summary> 前回買掛金額 </summary>
        public const string ct_Col_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> 今回支払金額（通常支払） </summary>
        public const string ct_Col_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> 今回手数料額（通常支払） </summary>
        public const string ct_Col_ThisTimeFeePayNrml = "ThisTimeFeePayNrml";
        /// <summary> 今回値引額（通常支払） </summary>
        public const string ct_Col_ThisTimeDisPayNrml = "ThisTimeDisPayNrml";
        /// <summary> 今回繰越残高（買掛計） </summary>
        public const string ct_Col_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> 相殺後今回仕入金額 </summary>
        public const string ct_Col_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> 返品値引 </summary>
        public const string ct_Col_ThisRgdsDisPric = "ThisRgdsDisPric";
        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string ct_Col_OfsThisStockTax = "OfsThisStockTax";
        // 2009.01.29 30413 犬飼 今回仕入金額の復活 >>>>>>START
        /// <summary> 今回仕入金額 </summary>
        public const string ct_Col_ThisTimeStockPrice = "ThisTimeStockPrice";
        // 2009.01.29 30413 犬飼 今回仕入金額の復活 <<<<<<END
        ///// <summary> 今回仕入消費税 </summary>
        //public const string ct_Col_ThisStcPrcTax = "ThisStcPrcTax";
        ///// <summary> 今回返品金額 </summary>
        //public const string ct_Col_ThisStckPricRgds = "ThisStckPricRgds";
        ///// <summary> 今回返品消費税 </summary>
        //public const string ct_Col_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        ///// <summary> 今回値引金額 </summary>
        //public const string ct_Col_ThisStckPricDis = "ThisStckPricDis";
        ///// <summary> 今回値引消費税 </summary>
        //public const string ct_Col_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        ///// <summary> 今回受取金額 </summary>
        //public const string ct_Col_ThisRecvOffset = "ThisRecvOffset";
        ///// <summary> 今回受取相殺消費税 </summary>
        //public const string ct_Col_ThisRecvOffsetTax = "ThisRecvOffsetTax";
        ///// <summary> 消費税調整額 </summary>
        //public const string ct_Col_TaxAdjust = "TaxAdjust";
        ///// <summary> 残高調整額 </summary>
        //public const string ct_Col_BalanceAdjust = "BalanceAdjust";
        /// <summary> 仕入合計残高（買掛計） </summary>
        public const string ct_Col_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> 仕入伝票枚数 </summary>
        public const string ct_Col_StockSlipCount = "StockSlipCount";
        ///// <summary> 支払条件 </summary>
        //public const string ct_Col_PaymentCond = "PaymentCond";
        ///// <summary> 支払締日 </summary>
        //public const string ct_Col_PaymentTotalDay = "PaymentTotalDay";
        ///// <summary> 支払月区分名称 </summary>
        //public const string ct_Col_PaymentMonthName = "PaymentMonthName";
        ///// <summary> 支払日 </summary>
        //public const string ct_Col_PaymentDay = "PaymentDay";
        /// <summary> 今回返品値引金額 </summary>
        public const string ct_Col_ThisStockPricRgdsDis = "ThisStockPricRgdsDis";
        /// <summary> 今回合計金額（印刷用） </summary>
        public const string ct_Col_StockPricTax = "StockPricTax";
        /// <summary> 現金 </summary>
        public const string ct_Col_CashPayment = "CashPayment";
        /// <summary> 振込 </summary>
        public const string ct_Col_TrfrPayment = "TrfrPayment";
        /// <summary> 小切手 </summary>
        public const string ct_Col_CheckPayment = "CheckPayment";
        /// <summary> 手形 </summary>
        public const string ct_Col_DraftPayment = "DraftPayment";
        /// <summary> 相殺 </summary>
        public const string ct_Col_OffsetPayment = "OffsetPayment";
        /// <summary> 口座振替 </summary>
        public const string ct_Col_FundTransferPayment = "FundTransferPayment";
        /// <summary> その他 </summary>
        public const string ct_Col_OthsPayment = "OthsPayment";

        // 印刷用
        /// <summary> 純仕入額 </summary>
        public const string ct_Col_PureStock = "PureStock";

        /// <summary> 月次締未更新 </summary>
        public const string Col_MonAddUpNonProc = "MonAddUpNonProc";

        // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
        /// <summary> 仕入額(計税率1) </summary>
        public const string Col_TotalThisTimeStockPriceTaxRate1 = "TotalThisTimeStockPriceTaxRate1";

        /// <summary> 仕入額(計税率2) </summary>
        public const string Col_TotalThisTimeStockPriceTaxRate2 = "TotalThisTimeStockPriceTaxRate2";

        /// <summary> 仕入額(計その他) </summary>
        public const string Col_TotalThisTimeStockPriceOther = "TotalThisTimeStockPriceOther";

        /// <summary> 返品値引(計税率1) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate1 = "TotalThisRgdsDisPricTaxRate1";

        /// <summary> 返品値引(計税率2) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate2 = "TotalThisRgdsDisPricTaxRate2";

        /// <summary> 返品値引(計その他) </summary>
        public const string Col_TotalThisRgdsDisPricOther = "TotalThisRgdsDisPricOther";

        /// <summary> 純仕入額(計税率1) </summary>
        public const string Col_TotalPureStockTaxRate1 = "TotalPureStockTaxRate1";

        /// <summary> 純仕入額(計税率2) </summary>
        public const string Col_TotalPureStockTaxRate2 = "TotalPureStockTaxRate2";

        /// <summary> 純仕入額(計その他) </summary>
        public const string Col_TotalPureStockOther = "TotalPureStockOther";

        /// <summary> 消費税(計税率1) </summary>
        public const string Col_TotalStockPricTaxTaxRate1 = "TotalStockPricTaxTaxRate1";

        /// <summary> 消費税(計税率2) </summary>
        public const string Col_TotalStockPricTaxTaxRate2 = "TotalStockPricTaxTaxRate2";

        /// <summary> 消費税(計その他) </summary>
        public const string Col_TotalStockPricTaxOther = "TotalStockPricTaxOther";

        /// <summary> 当月合計(計税率1) </summary>
        public const string Col_TotalStckTtlAccPayBalanceTaxRate1 = "TotalStckTtlAccPayBalanceTaxRate1";

        /// <summary> 当月合計(計税率2) </summary>
        public const string Col_TotalStckTtlAccPayBalanceTaxRate2 = "TotalStckTtlAccPayBalanceTaxRate2";

        /// <summary> 当月合計(計その他) </summary>
        public const string Col_TotalStckTtlAccPayBalanceOther = "TotalStckTtlAccPayBalanceOther";

        /// <summary> 枚数(計税率1) </summary>
        public const string Col_TotalStockSlipCountTaxRate1 = "TotalStockSlipCountTaxRate1";

        /// <summary> 枚数(計税率2) </summary>
        public const string Col_TotalStockSlipCountTaxRate2 = "TotalStockSlipCountTaxRate2";

        /// <summary> 枚数(計その他) </summary>
        public const string Col_TotalStockSlipCountOther = "TotalStockSlipCountOther";

        /// <summary> 税率1タイトル </summary>
        public const string Col_TitleTaxRate1 = "TitleTaxRate1";

        /// <summary> 税率2タイトル </summary>
        public const string Col_TitleTaxRate2 = "TitleTaxRate2";
        // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<

        // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
        /// <summary> 仕入額(計非課税) </summary>
        public const string Col_TotalThisTimeStockPriceTaxFree = "TotalThisTimeStockPriceTaxFree";
        /// <summary> 返品値引(計非課税) </summary>
        public const string Col_TotalThisRgdsDisPricTaxFree = "TotalThisRgdsDisPricTaxFree";
        /// <summary> 純仕入額(計非課税) </summary>
        public const string Col_TotalPureStockTaxFree = "TotalPureStockTaxFree";
        /// <summary> 消費税(計非課税) </summary>
        public const string Col_TotalStockPricTaxTaxFree = "TotalStockPricTaxTaxFree";
        /// <summary> 当月合計(計非課税) </summary>
        public const string Col_TotalStckTtlAccPayBalanceTaxFree = "TotalStckTtlAccPayBalanceTaxFree";
        /// <summary> 枚数(計非課税) </summary>
        public const string Col_TotalStockSlipCountTaxFree = "TotalStockSlipCountTaxFree";
        // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
        /// 買掛残高一覧表 得意先売掛金額データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 買掛残高一覧表 得意先売掛金額データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.10.24</br>
		/// </remarks>
		public DCKAK02644EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable
		/// <summary>
        /// 得意先売掛金額DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22018 鈴木　正臣</br>
		/// <br>Date       : 2007.10.24</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/03/02</br>
		/// </remarks>
        static public void CreateDataTable(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_AccPaymentList))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_AccPaymentList].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_AccPaymentList);

                DataTable dt = ds.Tables[ct_Tbl_AccPaymentList];

                // 計上拠点コード
                dt.Columns.Add( ct_Col_AddUpSecCode, typeof( string ) );
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;

                // 計上拠点名称
                dt.Columns.Add( ct_Col_SectionGuideNm, typeof( string ) );
                dt.Columns[ct_Col_SectionGuideNm].DefaultValue = string.Empty;

                // 支払先コード
                dt.Columns.Add( ct_Col_PayeeCode, typeof( Int32 ) );
                dt.Columns[ct_Col_PayeeCode].DefaultValue = 0;

                //// 支払先名称
                //dt.Columns.Add( ct_Col_PayeeName, typeof( string ) );
                //dt.Columns[ct_Col_PayeeName].DefaultValue = string.Empty;

                //// 支払先名称2
                //dt.Columns.Add( ct_Col_PayeeName2, typeof( string ) );
                //dt.Columns[ct_Col_PayeeName2].DefaultValue = string.Empty;

                // 支払先略称
                dt.Columns.Add( ct_Col_PayeeSnm, typeof( string ) );
                dt.Columns[ct_Col_PayeeSnm].DefaultValue = string.Empty;

                // 前回買掛金額
                dt.Columns.Add( ct_Col_LastTimeAccPay, typeof( Int64 ) );
                dt.Columns[ct_Col_LastTimeAccPay].DefaultValue = 0;

                // 今回支払金額（通常支払）
                dt.Columns.Add( ct_Col_ThisTimePayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimePayNrml].DefaultValue = 0;

                // 今回手数料額（通常支払）
                dt.Columns.Add( ct_Col_ThisTimeFeePayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeFeePayNrml].DefaultValue = 0;

                // 今回値引額（通常支払）
                dt.Columns.Add( ct_Col_ThisTimeDisPayNrml, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeDisPayNrml].DefaultValue = 0;

                // 今回繰越残高（買掛計）
                dt.Columns.Add( ct_Col_ThisTimeTtlBlcAcPay, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisTimeTtlBlcAcPay].DefaultValue = 0;

                // 相殺後今回仕入金額
                dt.Columns.Add( ct_Col_OfsThisTimeStock, typeof( Int64 ) );
                dt.Columns[ct_Col_OfsThisTimeStock].DefaultValue = 0;

                // 返品値引
                dt.Columns.Add(ct_Col_ThisRgdsDisPric, typeof(Int64));
                dt.Columns[ct_Col_ThisRgdsDisPric].DefaultValue = 0;

                // 相殺後今回仕入消費税
                dt.Columns.Add( ct_Col_OfsThisStockTax, typeof( Int64 ) );
                dt.Columns[ct_Col_OfsThisStockTax].DefaultValue = 0;

                // 2009.01.29 30413 犬飼 今回仕入金額の復活 >>>>>>START
                // 今回仕入金額
                dt.Columns.Add(ct_Col_ThisTimeStockPrice, typeof(Int64));
                dt.Columns[ct_Col_ThisTimeStockPrice].DefaultValue = 0;
                // 2009.01.29 30413 犬飼 今回仕入金額の復活 <<<<<<END
                
                //// 今回仕入消費税
                //dt.Columns.Add( ct_Col_ThisStcPrcTax, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisStcPrcTax].DefaultValue = 0;

                //// 今回返品金額
                //dt.Columns.Add( ct_Col_ThisStckPricRgds, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisStckPricRgds].DefaultValue = 0;

                //// 今回返品消費税
                //dt.Columns.Add( ct_Col_ThisStcPrcTaxRgds, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisStcPrcTaxRgds].DefaultValue = 0;

                //// 今回値引金額
                //dt.Columns.Add( ct_Col_ThisStckPricDis, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisStckPricDis].DefaultValue = 0;

                //// 今回値引消費税
                //dt.Columns.Add( ct_Col_ThisStcPrcTaxDis, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisStcPrcTaxDis].DefaultValue = 0;

                //// 今回受取金額
                //dt.Columns.Add( ct_Col_ThisRecvOffset, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisRecvOffset].DefaultValue = 0;

                //// 今回受取相殺消費税
                //dt.Columns.Add( ct_Col_ThisRecvOffsetTax, typeof( Int64 ) );
                //dt.Columns[ct_Col_ThisRecvOffsetTax].DefaultValue = 0;

                //// 消費税調整額
                //dt.Columns.Add( ct_Col_TaxAdjust, typeof( Int64 ) );
                //dt.Columns[ct_Col_TaxAdjust].DefaultValue = 0;

                //// 残高調整額
                //dt.Columns.Add( ct_Col_BalanceAdjust, typeof( Int64 ) );
                //dt.Columns[ct_Col_BalanceAdjust].DefaultValue = 0;

                // 仕入合計残高（買掛計）
                dt.Columns.Add( ct_Col_StckTtlAccPayBalance, typeof( Int64 ) );
                dt.Columns[ct_Col_StckTtlAccPayBalance].DefaultValue = 0;

                // 仕入伝票枚数
                dt.Columns.Add( ct_Col_StockSlipCount, typeof( Int32 ) );
                dt.Columns[ct_Col_StockSlipCount].DefaultValue = 0;

                //// 支払条件
                //dt.Columns.Add( ct_Col_PaymentCond, typeof( Int32 ) );
                //dt.Columns[ct_Col_PaymentCond].DefaultValue = 0;

                //// 支払締日
                //dt.Columns.Add( ct_Col_PaymentTotalDay, typeof( Int32 ) );
                //dt.Columns[ct_Col_PaymentTotalDay].DefaultValue = 0;

                //// 支払月区分名称
                //dt.Columns.Add( ct_Col_PaymentMonthName, typeof( string ) );
                //dt.Columns[ct_Col_PaymentMonthName].DefaultValue = string.Empty;

                //// 支払日
                //dt.Columns.Add( ct_Col_PaymentDay, typeof( Int32 ) );
                //dt.Columns[ct_Col_PaymentDay].DefaultValue = 0;

                // 現金
                dt.Columns.Add(ct_Col_CashPayment, typeof(Int64));
                dt.Columns[ct_Col_CashPayment].DefaultValue = 0;

                // 振込
                dt.Columns.Add(ct_Col_TrfrPayment, typeof(Int64));
                dt.Columns[ct_Col_TrfrPayment].DefaultValue = 0;

                // 小切手
                dt.Columns.Add(ct_Col_CheckPayment, typeof(Int64));
                dt.Columns[ct_Col_CheckPayment].DefaultValue = 0;

                // 手形
                dt.Columns.Add(ct_Col_DraftPayment, typeof(Int64));
                dt.Columns[ct_Col_DraftPayment].DefaultValue = 0;

                // 相殺
                dt.Columns.Add(ct_Col_OffsetPayment, typeof(Int64));
                dt.Columns[ct_Col_OffsetPayment].DefaultValue = 0;

                // 口座振替
                dt.Columns.Add(ct_Col_FundTransferPayment, typeof(Int64));
                dt.Columns[ct_Col_FundTransferPayment].DefaultValue = 0;

                // その他
                dt.Columns.Add(ct_Col_OthsPayment, typeof(Int64));
                dt.Columns[ct_Col_OthsPayment].DefaultValue = 0;

                // 今回返品値引金額（印刷用）
                dt.Columns.Add( ct_Col_ThisStockPricRgdsDis, typeof( Int64 ) );
                dt.Columns[ct_Col_ThisStockPricRgdsDis].DefaultValue = 0;

                // 今回合計金額（印刷用）
                dt.Columns.Add( ct_Col_StockPricTax, typeof( Int64 ) );
                dt.Columns[ct_Col_StockPricTax].DefaultValue = 0;

                // 印刷用
                // 純仕入額
                dt.Columns.Add(ct_Col_PureStock, typeof(Int64));
                dt.Columns[ct_Col_PureStock].DefaultValue = 0;

                // 月次締未更新
                dt.Columns.Add(Col_MonAddUpNonProc, typeof(bool));
                dt.Columns[Col_MonAddUpNonProc].DefaultValue = false;

                // --- ADD START 3H 劉星光 2020/03/02 ---------->>>>>
                // 仕入額(計税率1)
                dt.Columns.Add(Col_TotalThisTimeStockPriceTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalThisTimeStockPriceTaxRate1].DefaultValue = 0;

                // 仕入額(計税率2)
                dt.Columns.Add(Col_TotalThisTimeStockPriceTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalThisTimeStockPriceTaxRate2].DefaultValue = 0;

                // 仕入額(計その他)
                dt.Columns.Add(Col_TotalThisTimeStockPriceOther, typeof(Int64));
                dt.Columns[Col_TotalThisTimeStockPriceOther].DefaultValue = 0;

                // 返品値引(計税率1)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxRate1].DefaultValue = 0;

                // 返品値引(計税率2)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxRate2].DefaultValue = 0;

                // 返品値引(計その他)
                dt.Columns.Add(Col_TotalThisRgdsDisPricOther, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricOther].DefaultValue = 0;

                // 純仕入額(計税率1)
                dt.Columns.Add(Col_TotalPureStockTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalPureStockTaxRate1].DefaultValue = 0;

                // 純仕入額(計税率2)
                dt.Columns.Add(Col_TotalPureStockTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalPureStockTaxRate2].DefaultValue = 0;

                // 純仕入額(計その他)
                dt.Columns.Add(Col_TotalPureStockOther, typeof(Int64));
                dt.Columns[Col_TotalPureStockOther].DefaultValue = 0;

                // 消費税(計税率1)
                dt.Columns.Add(Col_TotalStockPricTaxTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalStockPricTaxTaxRate1].DefaultValue = 0;

                // 消費税(計税率2)
                dt.Columns.Add(Col_TotalStockPricTaxTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalStockPricTaxTaxRate2].DefaultValue = 0;

                // 消費税(計その他)
                dt.Columns.Add(Col_TotalStockPricTaxOther, typeof(Int64));
                dt.Columns[Col_TotalStockPricTaxOther].DefaultValue = 0;

                // 当月合計(計税率1)
                dt.Columns.Add(Col_TotalStckTtlAccPayBalanceTaxRate1, typeof(Int64));
                dt.Columns[Col_TotalStckTtlAccPayBalanceTaxRate1].DefaultValue = 0;

                // 当月合計(計税率2)
                dt.Columns.Add(Col_TotalStckTtlAccPayBalanceTaxRate2, typeof(Int64));
                dt.Columns[Col_TotalStckTtlAccPayBalanceTaxRate2].DefaultValue = 0;

                // 当月合計(計その他)
                dt.Columns.Add(Col_TotalStckTtlAccPayBalanceOther, typeof(Int64));
                dt.Columns[Col_TotalStckTtlAccPayBalanceOther].DefaultValue = 0;

                // 枚数(計税率1)
                dt.Columns.Add(Col_TotalStockSlipCountTaxRate1, typeof(Int32));
                dt.Columns[Col_TotalStockSlipCountTaxRate1].DefaultValue = 0;

                // 枚数(計税率2)
                dt.Columns.Add(Col_TotalStockSlipCountTaxRate2, typeof(Int32));
                dt.Columns[Col_TotalStockSlipCountTaxRate2].DefaultValue = 0;

                // 枚数(計その他)
                dt.Columns.Add(Col_TotalStockSlipCountOther, typeof(Int32));
                dt.Columns[Col_TotalStockSlipCountOther].DefaultValue = 0;

                // 税率1タイトル
                dt.Columns.Add(Col_TitleTaxRate1, typeof(string));
                dt.Columns[Col_TitleTaxRate1].DefaultValue = string.Empty;

                // 税率2タイトル
                dt.Columns.Add(Col_TitleTaxRate2, typeof(string));
                dt.Columns[Col_TitleTaxRate2].DefaultValue = string.Empty;
                // --- ADD END 3H 劉星光 2020/03/02 ----------<<<<<
                // --- ADD START 3H 仰亮亮 2022/10/09 ----->>>>>
                // 仕入額(計非課税)
                dt.Columns.Add(Col_TotalThisTimeStockPriceTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisTimeStockPriceTaxFree].DefaultValue = 0;

                // 返品値引(計非課税)
                dt.Columns.Add(Col_TotalThisRgdsDisPricTaxFree, typeof(Int64));
                dt.Columns[Col_TotalThisRgdsDisPricTaxFree].DefaultValue = 0;
        
                // 純仕入額(計非課税)
                dt.Columns.Add(Col_TotalPureStockTaxFree, typeof(Int64));
                dt.Columns[Col_TotalPureStockTaxFree].DefaultValue = 0;

                // 消費税(計非課税)
                dt.Columns.Add(Col_TotalStockPricTaxTaxFree, typeof(Int64));
                dt.Columns[Col_TotalStockPricTaxTaxFree].DefaultValue = 0;
        
                // 当月合計(計非課税)
                dt.Columns.Add(Col_TotalStckTtlAccPayBalanceTaxFree, typeof(Int64));
                dt.Columns[Col_TotalStckTtlAccPayBalanceTaxFree].DefaultValue = 0;

                // 枚数(計非課税)
                dt.Columns.Add(Col_TotalStockSlipCountTaxFree, typeof(Int32));
                dt.Columns[Col_TotalStockSlipCountTaxFree].DefaultValue = 0;
                // --- ADD END 3H 仰亮亮 2022/10/09 -----<<<<<
            }
		}
		#endregion
		#endregion
	}
}
