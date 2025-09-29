using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 支払確認覧表支払データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払確認表支払データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 20081 疋田　勇人</br>
	/// <br>Date       : 2007.09.10</br>
    /// <br>UpdateNote : 2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	 ・PM.NS対応</br>
    /// <br>Update Note: 2009/02/19 30452 上野 俊治</br>
    /// <br>            ・障害対応11459(作成日時を追加)</br>
    /// <br>Update Note: 2009/03/26 30452 上野 俊治</br>
    /// <br>            ・障害対応11459(作成日時を削除、入力日を追加)</br>
	/// </remarks>
	public class DCKAK02525EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
        public const string Col_Tbl_PaymentMain = "Tbl_PaymentMain";

        /// <summary> 支払赤黒区分 </summary>
        /// <remarks>0:黒,1:赤,2:元黒</remarks>
        public const string Col_PaymentDebitNoteCd = "PaymentDebitNoteCd";

        /// <summary> 支払赤黒区分名称 </summary>
        public const string Col_PaymentDebitNoteCdName = "PaymentDebitNoteCdName";

        /// <summary> 支払赤黒区分 記号（▲：赤伝、●：相殺済黒伝）</summary>
        public const string Col_PaymentDebitNoteSign = "PaymentDebitNoteSign";

        /// <summary> 支払伝票番号 </summary>
        public const string Col_PaymentSlipNo = "PaymentSlipNo";

        /// <summary> 赤黒支払連結番号 </summary>
        public const string Col_DebitNoteLinkPayNo = "DebitNoteLinkPayNo";

        /// <summary> 支払入力拠点コード </summary>
        /// <remarks> 支払入力した拠点コード</remarks>
        public const string Col_InputPaymentSecCd = "InputPaymentSecCd";

        /// <summary> 支払入力拠点名称 </summary>
        public const string Col_InputPaymentSecNm = "InputPaymentSecNm";

        /// <summary> 計上拠点コード </summary>
        /// <remarks> 集計の対象となっている拠点コード</remarks>
        public const string Col_AddUpSecCode = "AddUpSecCode";

        /// <summary> 計上拠点名称 </summary>
        public const string Col_AddUpSecName = "AddUpSecName";

        /// <summary> 計上拠点名称(明細用) </summary>
        public const string Col_AddUpSecName_Detail = "AddUpSecName_Detail";

        /// <summary> 支払日付 </summary>
        public const string Col_PaymentDate = "PaymentDate";

        /// <summary> ソート用支払日付 </summary>
        public const string Col_Sort_PaymentDate = "Sort_PaymentDate";

        /// <summary> 計上日付 </summary>
        public const string Col_AddUpADate = "AddUpADate";

        /// <summary> ソート用計上日付 </summary>
        public const string Col_Sort_AddUpADate = "Sort_AddUpADate";

        /// <summary> 支払金種コード </summary>
        public const string Col_PaymentKindCode = "PaymentKindCode";

        /// <summary> 支払金種名称 </summary>
        public const string Col_PaymentKindName = "PaymentKindName";

        /// <summary> 支払金種区分 </summary>
        public const string Col_PaymentKindDivCd = "PaymentKindDivCd";

        /// <summary> 支払計 </summary>
        public const string Col_PaymentTotal = "PaymentTotal";

        /// <summary> 支払金額 </summary>
        /// <remarks>値引・手数料を除いた額</remarks>
        public const string Col_Payment = "Payment";

        /// <summary> 手数料 </summary>
        public const string Col_FeePayment = "FeePayment";

        /// <summary> 値引 </summary>
        public const string Col_DiscountPayment = "DiscountPayment";

        /// <summary> 自動支払区分 </summary>
        /// <remarks>0:通常入金,1:自動支払</remarks>
        public const string Col_AutoPaymentCd = "AutoPaymentCd";

        /// <summary> 自動支払区分名称 </summary>
        public const string Col_AutoPaymentCdName = "AutoPaymentCdName";

        /// <summary> 手形振出日 </summary>
        public const string Col_DraftDrawingDate = "DraftDrawingDate";

        /// <summary> 手形支払期日 </summary>
        public const string Col_DraftPayTimeLimit = "DraftPayTimeLimit";

        /// <summary> 手形種類 </summary>
        public const string Col_DraftKind = "DraftKind";

        /// <summary> 手形種類名称 </summary>
        public const string Col_DraftKindName = "DraftKindName";

        /// <summary> 手形区分 </summary>
        public const string Col_DraftDivide = "DraftDivide";

        /// <summary> 手形区分名称 </summary>
        public const string Col_DraftDivideName = "DraftDivideName";

        /// <summary> 手形番号 </summary>
        public const string Col_DraftNo = "DraftNo";

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary> 得意先コード </summary>
        //public const string Col_CustomerCode = "CustomerCode";

        ///// <summary> 得意先名称 </summary>
        //public const string Col_CustomerName = "CustomerName";

        ///// <summary> 得意先名称2 </summary>
        //public const string Col_CustomerName2 = "CustomerName2";
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        // --- ADD 2008/08/05 -------------------------------->>>>>
        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先名1 </summary>
        public const string Col_SupplierNm1 = "SupplierNm1";

        /// <summary> 仕入先名2 </summary>
        public const string Col_SupplierNm2 = "SupplierNm2";

        /// <summary> 仕入先略称 </summary>
        public const string Col_SupplierSnm = "SupplierSnm";    // ADD 2008/10/08 不具合対応[5868]

        /// <summary> 支払先コード </summary>
        public const string Col_PayeeCode = "PayeeCode";

        /// <summary> 支払先名称 </summary>
        public const string Col_PayeeName = "PayeeName";

        /// <summary> 支払先名称2 </summary>
        public const string Col_PayeeName2 = "PayeeName2";

        /// <summary> 支払先略称 </summary>
        public const string Col_PayeeSnm = "PayeeSnm";
        // --- ADD 2008/08/05 --------------------------------<<<<< 

        /// <summary> カナ </summary>
        public const string Col_Kana = "Kana";

        /// <summary> 伝票摘要 </summary>
        public const string Col_Outline = "Outline";

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary> 担当者コード </summary>
        //public const string Col_AgentCode = "AgentCode";

        ///// <summary> 担当者名称 </summary>
        //public const string Col_AgentNm = "AgentNm";
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        // --- DEL 2009/03/26 -------------------------------->>>>>
        // --- ADD 2009/02/19 -------------------------------->>>>>
        ///// <summary> 作成日時 </summary>
        //public const string Col_CreateDateTime = "CreateDateTime";
        // --- ADD 2009/02/19 --------------------------------<<<<<
        // --- DEL 2009/03/26 --------------------------------<<<<<
        // --- ADD 2009/03/26 -------------------------------->>>>>
        /// <summary>入力日</summary>
        public const string Col_InputDay = "InputDay";
        // --- ADD 2009/03/26 --------------------------------<<<<<

        // キーブレイク用 DataTable列名 -------------------------------------------------------
        /// <summary> 小計出力キーブレイク </summary>
        public const string Col_MiniTotal_KeyBleak = "MiniTotal_KeyBleak";

        // 総合計用 DataTable列名 -------------------------------------------------------------
        /// <summary> 通常支払計 </summary>
        public const string Col_NomalPaymentTotal = "NomalPaymentTotal";
        /// <summary> 手数料計 </summary>
        public const string Col_FeePaymentTotal = "FeePaymentTotal";
        /// <summary> 値引計 </summary>
        public const string Col_DiscountPaymentTotal = "DiscountPaymentTotal";
        /// <summary> 金種計 </summary>
        public const string Col_PayKindTotal = "PayKindTotal";

        // 金種別用----------------------------------------------------------------------------
        /// <summary> 現金 </summary>
        public const string Col_Cash = "Cash";
        /// <summary> 小切手 </summary>
        public const string Col_Check = "Check";
        /// <summary> 振込 </summary>
        public const string Col_Remittance = "Remittance";
        /// <summary> 手数料 </summary>
        public const string Col_Fee = "Fee";
        /// <summary> 手形 </summary>
        public const string Col_Bill = "Bill";
        /// <summary> 先付手形 </summary>
        public const string Col_ABill = "ABill";
        /// <summary> 相殺 </summary>
        public const string Col_Offset = "Offset";
        /// <summary> その他 </summary>
        public const string Col_Others = "Others";
        /// <summary> 値引 </summary>
        public const string Col_Discount = "Discount";

        // --- ADD 2008/08/05 -------------------------------->>>>>
        /// <summary>有効期限</summary>
        public const string Col_ValidityTerm = "ValidityTerm";
        /// <summary>金種１</summary>
        public const string Col_PaymentKind_No1 = "PaymentKind_No1";
        /// <summary>金種２</summary>
        public const string Col_PaymentKind_No2 = "PaymentKind_No2";
        /// <summary>金種３</summary>
        public const string Col_PaymentKind_No3 = "PaymentKind_No3";
        /// <summary>金種４</summary>
        public const string Col_PaymentKind_No4 = "PaymentKind_No4";
        /// <summary>金種５</summary>
        public const string Col_PaymentKind_No5 = "PaymentKind_No5";
        /// <summary>金種６</summary>
        public const string Col_PaymentKind_No6 = "PaymentKind_No6";
        /// <summary>金種７</summary>
        public const string Col_PaymentKind_No7 = "PaymentKind_No7";
        /// <summary>金種８</summary>
        public const string Col_PaymentKind_No8 = "PaymentKind_No8";
        /// <summary>金種９</summary>
        public const string Col_PaymentKind_No9 = "PaymentKind_No9";
        /// <summary>金種１０</summary>
        public const string Col_PaymentKind_No10 = "PaymentKind_No10";
        // --- ADD 2008/08/05 --------------------------------<<<<< 

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 支払確認表支払データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払確認表支払データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02525EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
		/// 支払DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : 支払データセットのスキーマを設定する。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        static public void CreateDataTablePaymentMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_PaymentMain))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_PaymentMain].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_PaymentMain);

                DataTable dt = ds.Tables[Col_Tbl_PaymentMain];

                dt.Columns.Add(Col_PaymentDebitNoteCd, typeof(int));			    // 支払赤黒区分
                dt.Columns[Col_PaymentDebitNoteCd].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentDebitNoteCdName, typeof(string));		    // 支払赤黒区分名称
                dt.Columns[Col_PaymentDebitNoteCdName].DefaultValue = "";

                dt.Columns.Add(Col_PaymentDebitNoteSign, typeof(string));		    // 支払赤黒区分記号
                dt.Columns[Col_PaymentDebitNoteSign].DefaultValue = "";

                dt.Columns.Add(Col_PaymentSlipNo, typeof(int));			            // 支払伝票番号
                dt.Columns[Col_PaymentSlipNo].DefaultValue = 0;

                dt.Columns.Add(Col_DebitNoteLinkPayNo, typeof(int));			    // 赤黒支払連結番号
                dt.Columns[Col_DebitNoteLinkPayNo].DefaultValue = 0;

                dt.Columns.Add(Col_InputPaymentSecCd, typeof(string));		        // 支払入力拠点コード
                dt.Columns[Col_InputPaymentSecCd].DefaultValue = "";

                dt.Columns.Add(Col_InputPaymentSecNm, typeof(string));      		// 支払入力拠点名称
                dt.Columns[Col_InputPaymentSecNm].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecCode, typeof(string));		            // 計上拠点コード
                dt.Columns[Col_AddUpSecCode].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName, typeof(string));	            	// 計上拠点名称
                dt.Columns[Col_AddUpSecName].DefaultValue = "";

                dt.Columns.Add(Col_AddUpSecName_Detail, typeof(string));		    // 計上拠点名称(明細)
                dt.Columns[Col_AddUpSecName_Detail].DefaultValue = "";

                dt.Columns.Add(Col_PaymentDate, typeof(string));		            // 支払日付
                dt.Columns[Col_PaymentDate].DefaultValue = "";

                dt.Columns.Add(Col_Sort_PaymentDate, typeof(long));         		// ソート用支払日付
                dt.Columns[Col_Sort_PaymentDate].DefaultValue = 0;

                dt.Columns.Add(Col_AddUpADate, typeof(string));		                // 計上日付
                dt.Columns[Col_AddUpADate].DefaultValue = "";

                dt.Columns.Add(Col_Sort_AddUpADate, typeof(long));		            // ソート用計上日付
                dt.Columns[Col_Sort_AddUpADate].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKindCode, typeof(int));			        // 支払金種コード
                dt.Columns[Col_PaymentKindCode].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKindName, typeof(string));		        // 支払金種名称
                dt.Columns[Col_PaymentKindName].DefaultValue = "";

                dt.Columns.Add(Col_PaymentKindDivCd, typeof(int));		            // 支払金種区分
                dt.Columns[Col_PaymentKindDivCd].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentTotal, typeof(long));		                // 支払計
                dt.Columns[Col_PaymentTotal].DefaultValue = 0;

                dt.Columns.Add(Col_Payment, typeof(long));		                    // 支払金額
                dt.Columns[Col_Payment].DefaultValue = 0;

                dt.Columns.Add(Col_FeePayment, typeof(long));		                // 手数料
                dt.Columns[Col_FeePayment].DefaultValue = 0;

                dt.Columns.Add(Col_DiscountPayment, typeof(long));		            // 値引
                dt.Columns[Col_DiscountPayment].DefaultValue = 0;

                dt.Columns.Add(Col_AutoPaymentCd, typeof(int));			            // 自動支払区分
                dt.Columns[Col_AutoPaymentCd].DefaultValue = 0;

                dt.Columns.Add(Col_AutoPaymentCdName, typeof(string));		        // 自動支払区分名称
                dt.Columns[Col_AutoPaymentCdName].DefaultValue = "";

                dt.Columns.Add(Col_DraftDrawingDate, typeof(string));	        	// 手形振出日
                dt.Columns[Col_DraftDrawingDate].DefaultValue = "";

                dt.Columns.Add(Col_DraftPayTimeLimit, typeof(string));		        // 手形支払期日
                dt.Columns[Col_DraftPayTimeLimit].DefaultValue = "";

                dt.Columns.Add(Col_DraftKind, typeof(int));		                    // 手形種類
                dt.Columns[Col_DraftKind].DefaultValue = 0;

                dt.Columns.Add(Col_DraftKindName, typeof(string));		            // 手形種類名称
                dt.Columns[Col_DraftKindName].DefaultValue = "";

                dt.Columns.Add(Col_DraftDivide, typeof(int));		                // 手形区分
                dt.Columns[Col_DraftDivide].DefaultValue = 0;

                dt.Columns.Add(Col_DraftDivideName, typeof(string));		        // 手形区分名称
                dt.Columns[Col_DraftDivideName].DefaultValue = "";

                dt.Columns.Add(Col_DraftNo, typeof(string));		                // 手形番号
                dt.Columns[Col_DraftNo].DefaultValue = "";

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //dt.Columns.Add(Col_CustomerCode, typeof(int));			        // 得意先コード
                //dt.Columns[Col_CustomerCode].DefaultValue = 0;

                //dt.Columns.Add(Col_CustomerName, typeof(string));		            // 得意先名称
                //dt.Columns[Col_CustomerName].DefaultValue = "";

                //dt.Columns.Add(Col_CustomerName2, typeof(string));		        // 得意先名称2
                //dt.Columns[Col_CustomerName2].DefaultValue = "";
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                // --- ADD 2008/08/05 -------------------------------->>>>>
                dt.Columns.Add(Col_SupplierCd, typeof(int));			            // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = 0;

                dt.Columns.Add(Col_SupplierNm1, typeof(string));		            // 仕入先名1
                dt.Columns[Col_SupplierNm1].DefaultValue = "";

                dt.Columns.Add(Col_SupplierNm2, typeof(string));		            // 仕入先名2
                dt.Columns[Col_SupplierNm2].DefaultValue = "";

                // ADD 2008/10/08 不具合対応[5868]---------->>>>>
                dt.Columns.Add(Col_SupplierSnm, typeof(string));		            // 仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = string.Empty;
                // ADD 2008/10/08 不具合対応[5868]----------<<<<<

                dt.Columns.Add(Col_PayeeCode, typeof(int));		                    // 支払先コード
                dt.Columns[Col_PayeeCode].DefaultValue = 0;

                dt.Columns.Add(Col_PayeeName, typeof(string));		                // 支払先名称
                dt.Columns[Col_PayeeName].DefaultValue = "";

                dt.Columns.Add(Col_PayeeName2, typeof(string));		                // 支払先名称2
                dt.Columns[Col_PayeeName2].DefaultValue = "";

                dt.Columns.Add(Col_PayeeSnm, typeof(string));		                // 支払先略称
                dt.Columns[Col_PayeeSnm].DefaultValue = "";
                // --- ADD 2008/08/05 --------------------------------<<<<< 

                dt.Columns.Add(Col_Kana, typeof(string));                      		// カナ
                dt.Columns[Col_Kana].DefaultValue = "";

                dt.Columns.Add(Col_Outline, typeof(string));		                // 伝票摘要
                dt.Columns[Col_Outline].DefaultValue = "";

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //dt.Columns.Add(Col_AgentCode, typeof(string));		                // 担当者コード
                //dt.Columns[Col_AgentCode].DefaultValue = "";

                //dt.Columns.Add(Col_AgentNm, typeof(string));		                // 担当者名称
                //dt.Columns[Col_AgentNm].DefaultValue = "";
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                // --- DEL 2009/03/26 -------------------------------->>>>>
                // --- ADD 2009/02/19 -------------------------------->>>>>
                //dt.Columns.Add(Col_CreateDateTime, typeof(string));		            // 作成日時
                //dt.Columns[Col_CreateDateTime].DefaultValue = "";
                // --- ADD 2009/02/19 --------------------------------<<<<<
                // --- DEL 2009/03/26 --------------------------------<<<<<
                // --- ADD 2009/03/26 -------------------------------->>>>>
                dt.Columns.Add(Col_InputDay, typeof(string));		            // 入力日
                dt.Columns[Col_InputDay].DefaultValue = "";
                // --- ADD 2009/03/26 --------------------------------<<<<<

                dt.Columns.Add(Col_MiniTotal_KeyBleak, typeof(string));		        // 小計出力キーブレイク
                dt.Columns[Col_MiniTotal_KeyBleak].DefaultValue = "";

                dt.Columns.Add(Col_NomalPaymentTotal, typeof(long));		        // 通常支払計
                dt.Columns[Col_NomalPaymentTotal].DefaultValue = 0;

                dt.Columns.Add(Col_FeePaymentTotal, typeof(long));		            // 手数料計
                dt.Columns[Col_FeePaymentTotal].DefaultValue = 0;

                dt.Columns.Add(Col_DiscountPaymentTotal, typeof(long));		        // 値引計
                dt.Columns[Col_DiscountPaymentTotal].DefaultValue = 0;

                dt.Columns.Add(Col_PayKindTotal, typeof(long));		                // 金種計
                dt.Columns[Col_PayKindTotal].DefaultValue = 0;

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //dt.Columns.Add(Col_Cash, typeof(long));		                    // 現金
                //dt.Columns[Col_Cash].DefaultValue = 0;

                //dt.Columns.Add(Col_Check, typeof(long));		                    // 小切手
                //dt.Columns[Col_Check].DefaultValue = 0;

                //dt.Columns.Add(Col_Remittance, typeof(long));		                // 振込
                //dt.Columns[Col_Remittance].DefaultValue = 0;
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                dt.Columns.Add(Col_Fee, typeof(long));		                        // 手数料
                dt.Columns[Col_Fee].DefaultValue = 0;

                // --- DEL 2008/08/05 -------------------------------->>>>>
                //dt.Columns.Add(Col_Bill, typeof(long));		                    // 手形
                //dt.Columns[Col_Bill].DefaultValue = 0;

                //dt.Columns.Add(Col_ABill, typeof(long));		                    // 先付手形
                //dt.Columns[Col_ABill].DefaultValue = 0;

                //dt.Columns.Add(Col_Offset, typeof(long));		                    // 相殺
                //dt.Columns[Col_Offset].DefaultValue = 0;

                //dt.Columns.Add(Col_Others, typeof(long));		                    // その他
                //dt.Columns[Col_Others].DefaultValue = 0;
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                dt.Columns.Add(Col_Discount, typeof(long));		                    // 値引
                dt.Columns[Col_Discount].DefaultValue = 0;

                // --- ADD 2008/08/05 -------------------------------->>>>>
                dt.Columns.Add(Col_PaymentKind_No1, typeof(long));   // 金種１
                dt.Columns[Col_PaymentKind_No1].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No2, typeof(long));   // 金種２
                dt.Columns[Col_PaymentKind_No2].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No3, typeof(long));   // 金種３
                dt.Columns[Col_PaymentKind_No3].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No4, typeof(long));   // 金種４
                dt.Columns[Col_PaymentKind_No4].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No5, typeof(long));   // 金種５
                dt.Columns[Col_PaymentKind_No5].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No6, typeof(long));   // 金種６
                dt.Columns[Col_PaymentKind_No6].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No7, typeof(long));   // 金種７
                dt.Columns[Col_PaymentKind_No7].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No8, typeof(long));   // 金種８
                dt.Columns[Col_PaymentKind_No8].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No9, typeof(long));   // 金種９
                dt.Columns[Col_PaymentKind_No9].DefaultValue = 0;

                dt.Columns.Add(Col_PaymentKind_No10, typeof(long));  // 金種１０
                dt.Columns[Col_PaymentKind_No10].DefaultValue = 0;

                dt.Columns.Add(Col_ValidityTerm, typeof(string));    // 有効期限            
                dt.Columns[Col_ValidityTerm].DefaultValue = "";
                // --- ADD 2008/08/05 --------------------------------<<<<< 
            }
		}
		#endregion
		#endregion
	}
}
