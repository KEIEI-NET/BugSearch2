using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 入金一覧表入金データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金一覧表入金データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22013 久保　将太</br>
	/// <br>Date       : 2007.03.05</br>
	/// <br></br>
    /// <br>Update Note: 2007.11.14 980035 金沢 貞義</br>
    ///                :    ・DC.NS対応（金種別集計の追加）
    /// <br>UpdateNote : 2008.01.30 980035 金沢 貞義</br>
    /// <br>                ・DC.NS対応（不具合修正）</br>
    /// <br>UpdateNote : 2008.07.10 30413 犬飼</br>
    /// <br>                ・PM.NS対応</br>
    /// <br>Update Note: 2009/03/26 30452 上野 俊治</br>
    /// <br>            ・障害対応11735</br>
    /// </remarks>
	public class MAHNB02014EA
	{
		#region ■ Public Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_DepositMain				= "Tbl_DepositMain";

        // --- DEL 2009/03/26 -------------------------------->>>>>
        //// 2009.02.18 30413 犬飼 作成日時の追加 >>>>>>START
        ///// <summary> 作成日時 </summary>
        //public const string ct_Col_CreateDateTime           = "CreateDateTime";
        //// 2009.02.18 30413 犬飼 作成日時の追加 <<<<<<END
        // --- DEL 2009/03/26 --------------------------------<<<<<
        // --- ADD 2009/03/26 -------------------------------->>>>>
        /// <summary> 入力日 </summary>
        public const string ct_Col_InputDay = "InputDay";
        // --- ADD 2009/03/26 --------------------------------<<<<<
        
		/// <summary> 入金赤黒区分 </summary>
		/// <remarks>0:黒,1:赤,2:相殺済み黒</remarks>
		public const string ct_Col_DepositDebitNoteCd		= "DepositDebitNoteCd";

		/// <summary> 入金赤黒区分名称 </summary>
		public const string ct_Col_DepositDebitNoteCdName	= "DepositDebitNoteCdName";

		/// <summary> 入金赤黒区分 記号</summary>
		public const string ct_Col_DepositDebitNoteSign		= "DepositDebitNoteSign";
		
		/// <summary> 入金伝票番号 </summary>
		public const string ct_Col_DepositSlipNo			= "DepositSlipNo";
		
		/// <summary> 赤黒入金連結番号 </summary>
		public const string ct_Col_DebitNoteLinkDepoNo		= "DebitNoteLinkDepoNo";

		/// <summary> 入金入力拠点コード </summary>
		/// <remarks> 入金入力した拠点コード</remarks>
		public const string ct_Col_InputDepositSecCd		= "InputDepositSecCd";
		
		/// <summary> 入金入力拠点名称 </summary>
		public const string ct_Col_InputDepositSecNm		= "InputDepositSecNm";
		
		/// <summary> 計上拠点コード </summary>
		/// <remarks> 集計の対象となっている拠点コード</remarks>
		public const string ct_Col_AddUpSecCode				= "AddUpSecCode";
		
		/// <summary> 計上拠点名称 </summary>
		public const string ct_Col_AddUpSecName				= "AddUpSecName";
		
		/// <summary> 計上拠点名称(明細用) </summary>
		public const string ct_Col_AddUpSecName_Detail		= "AddUpSecName_Detail";
		
		/// <summary> 入金日付 </summary>
		public const string ct_Col_DepositDate				= "DepositDate";
		
		/// <summary> ソート用入金日付 </summary>
		public const string ct_Col_Sort_DepositDate			= "Sort_DepositDate";
		
		/// <summary> 計上日付 </summary>
		public const string ct_Col_AddUpADate				= "AddUpADate";
		
		/// <summary> ソート用計上日付 </summary>
		public const string ct_Col_Sort_AddUpADate			= "Sort_AddUpADate";
		
		/// <summary> 入金金種コード </summary>
		public const string ct_Col_DepositKindCode			= "DepositKindCode";
		
		/// <summary> 入金金種名称 </summary>
		public const string ct_Col_DepositKindName			= "DepositKindName";
		
		/// <summary> 入金金種区分 </summary>
		public const string ct_Col_DepositKindDivCd			= "DepositKindDivCd";
		
		/// <summary> 入金計 </summary>
		public const string ct_Col_DepositTotal				= "DepositTotal";
		
		/// <summary> 入金金額 </summary>
		/// <remarks>値引・手数料を除いた額</remarks>
		public const string ct_Col_Deposit					= "Deposit";
		
		/// <summary> 手数料入金額 </summary>
		public const string ct_Col_FeeDeposit				= "FeeDeposit";
		
		/// <summary> 値引入金額 </summary>
		public const string ct_Col_DiscountDeposit			= "DiscountDeposit";
		
		/// <summary> リベート入金額 </summary>
		public const string ct_Col_RebateDeposit			= "RebateDeposit";
		
		/// <summary> 自動入金区分 </summary>
		/// <remarks>0:通常入金,1:自動入金</remarks>
		public const string ct_Col_AutoDepositCd			= "AutoDepositCd";
		
		/// <summary> 自動入金区分名称 </summary>
		public const string ct_Col_AutoDepositCdName		= "AutoDepositCdName";
		
		/// <summary> 預り金区分 </summary>
		/// <remarks>0:通常入金,1:預り金入金</remarks>
		public const string ct_Col_DepositCd				= "DepositCd";
		
		/// <summary> 預り金区分名称</summary>
		public const string ct_Col_DepositCdName			= "DepositCdName";
		
		/// <summary> 預り金記号 </summary>
		public const string ct_Col_DepositCdSign			= "DepositCdSign";

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// <summary> クレジット／ローン区分 </summary>
        ///// <remarks>1:クレジット,2:ローン</remarks>
        //public const string ct_Col_CreditOrLoanCd			= "CreditOrLoanCd";
		
        ///// <summary> クレジット／ローン区分名称 </summary>
        //public const string ct_Col_CreditOrLoanCdNm			= "CreditOrLoanCdNm";
		
        ///// <summary> クレジット会社コード </summary>
        //public const string ct_Col_CreditCompanyCode		= "CreditCompanyCode";
		
        ///// <summary> クレジット会社名称 </summary>
        //public const string ct_Col_CreditCompanyName		= "CreditCompanyName";
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// <summary> 手形振出日 </summary>
		public const string ct_Col_DraftDrawingDate			= "DraftDrawingDate";
		
		/// <summary> 手形支払期日 </summary>
		public const string ct_Col_DraftPayTimeLimit		= "DraftPayTimeLimit";

        // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary> 手形種類 </summary>
        public const string ct_Col_DraftKind                = "DraftKind";

        /// <summary> 手形種類名称 </summary>
        public const string ct_Col_DraftKindName            = "DraftKindName";

        /// <summary> 手形区分 </summary>
        public const string ct_Col_DraftDivide              = "DraftDivide";

        /// <summary> 手形区分名称 </summary>
        public const string ct_Col_DraftDivideName          = "DraftDivideName";

        /// <summary> 手形番号 </summary>
        public const string ct_Col_DraftNo                  = "DraftNo";

        /// <summary> 銀行コード </summary>
        public const string ct_Col_BankCode                 = "BankCode";

        /// <summary> 銀行名称 </summary>
        public const string ct_Col_BankName                 = "BankName";
        // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary> 手形振出日又はクレジット会社名称 </summary>
		public const string ct_Col_DraftOrCreditName		= "DraftOrCreditName";

		/// <summary> 入金引当額 </summary>
		public const string ct_Col_DepositAllowance			= "DepositAllowance";
		
		/// <summary> 入金引当残高 </summary>
		public const string ct_Col_DepositAlwcBlnce			= "DepositAlwcBlnce";
		
		/// <summary> 最終消し込み計上日 </summary>
		public const string ct_Col_LastReconcileAddUpDt		= "LastReconcileAddUpDt";
		
		/// <summary> 得意先コード </summary>
		public const string ct_Col_CustomerCode				= "CustomerCode";
		
		/// <summary> 得意先名称 </summary>
		public const string ct_Col_CustomerName				= "CustomerName";
		
		/// <summary> 得意先名称2 </summary>
		public const string ct_Col_CustomerName2			= "CustomerName2";

		/// <summary> カナ </summary>
		public const string ct_Col_Kana						= "Kana";

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// <summary> 個人・法人区分 </summary>
        //public const string ct_Col_CorporateDivCode			= "CorporateDivCode";
		
        ///// <summary> 個人・法人区分名称 </summary>
        //public const string ct_Col_CorporateDivName			= "CorporateDivName";
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// <summary> 伝票摘要 </summary>
		public const string ct_Col_Outline					= "Outline";

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// <summary> 担当者コード </summary>
        //public const string ct_Col_AgentCode				= "AgentCode";
		
        ///// <summary> 担当者名称 </summary>
        //public const string ct_Col_AgentNm					= "AgentNm";
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
        // 2008.07.14 30413 犬飼 請求先の追加 >>>>>>START
        /// <summary> 請求先コード </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";

        /// <summary> 請求先略称 </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";
        // 2008.07.14 30413 犬飼 請求先の追加 <<<<<<END


        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        // キーブレイク用 DataTable列名 -------------------------------------------------------
        ///// <summary> 小計出力キーブレイク </summary>
        //public const string ct_Col_MiniTotal_KeyBleak		= "MiniTotal_KeyBleak";
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        

		// 総合計用 DataTable列名 ------------------------------------------------------------
		/// <summary> 通常入金計 </summary>
		public const string ct_Col_NomalDepositTotal		= "NomalDepositTotal";
		/// <summary> 預り金入金計 </summary>
		public const string ct_Col_ChargeDepositTotal		= "ChargeDepositTotal";
		/// <summary> 自動入金計 </summary>
		public const string ct_Col_AutoDepositTotal			= "AutoDepositTotal";

        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary> 入金金種テーブル01 </summary>
        public const string ct_Col_DepositKind_No1          = "DepositKind_No1";
        /// <summary> 入金金種テーブル02 </summary>
        public const string ct_Col_DepositKind_No2          = "DepositKind_No2";
        /// <summary> 入金金種テーブル03 </summary>
        public const string ct_Col_DepositKind_No3          = "DepositKind_No3";
        /// <summary> 入金金種テーブル04 </summary>
        public const string ct_Col_DepositKind_No4          = "DepositKind_No4";
        /// <summary> 入金金種テーブル05 </summary>
        public const string ct_Col_DepositKind_No5          = "DepositKind_No5";
        /// <summary> 入金金種テーブル06 </summary>
        public const string ct_Col_DepositKind_No6          = "DepositKind_No6";
        /// <summary> 入金金種テーブル07 </summary>
        public const string ct_Col_DepositKind_No7          = "DepositKind_No7";
        /// <summary> 入金金種テーブル08 </summary>
        public const string ct_Col_DepositKind_No8          = "DepositKind_No8";
        /// <summary> 入金金種テーブル09 </summary>
        public const string ct_Col_DepositKind_No9          = "DepositKind_No9";
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.10 30413 犬飼 入金金種テーブルの追加 >>>>>>START
        /// <summary> 入金金種テーブル09 </summary>
        public const string ct_Col_DepositKind_No10 = "DepositKind_No10";
        // 2008.07.10 30413 犬飼 入金金種テーブルの追加 <<<<<<END

        // 2008.07.10 30413 犬飼 有効期限の追加 >>>>>>START
        /// <summary> 有効期限 </summary>
        public const string ct_Col_ValidityTerm = "ValidityTerm";
        // 2008.07.10 30413 犬飼 有効期限の追加 <<<<<<END

		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 入金一覧表入金データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金一覧表入金データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MAHNB02014EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ CreateDataTable(ref DataSet ds)
		/// <summary>
		/// 入金DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : 入金データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		static public void CreateDataTableDepositMain(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
			if ( ds.Tables.Contains( ct_Tbl_DepositMain ) )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				ds.Tables[ct_Tbl_DepositMain].Clear();
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(ct_Tbl_DepositMain);
				DataTable dt = ds.Tables[ct_Tbl_DepositMain];

                // --- DEL 2009/03/26 -------------------------------->>>>>
                //// 2009.02.18 30413 犬飼 作成日時の追加 >>>>>>START
                //dt.Columns.Add(ct_Col_CreateDateTime            , typeof(string));		// 作成日時
                //dt.Columns[ct_Col_CreateDateTime                ].DefaultValue = "";
                //// 2009.02.18 30413 犬飼 作成日時の追加 <<<<<<END
                // --- DEL 2009/03/26 --------------------------------<<<<<
                // --- ADD 2009/03/26 -------------------------------->>>>>
                dt.Columns.Add(ct_Col_InputDay, typeof(string));		// 入力日
                dt.Columns[ct_Col_InputDay].DefaultValue = "";
                // --- ADD 2009/03/26 --------------------------------<<<<<
                
				dt.Columns.Add(ct_Col_DepositDebitNoteCd		, typeof(int));			// 入金赤黒区分
				dt.Columns[ct_Col_DepositDebitNoteCd			].DefaultValue = 0;		
	
				dt.Columns.Add(ct_Col_DepositDebitNoteCdName	, typeof(string));		// 入金赤黒区分名称
				dt.Columns[ct_Col_DepositDebitNoteCdName		].DefaultValue = "";		
	
				dt.Columns.Add(ct_Col_DepositDebitNoteSign		,typeof(string));		// 入金赤黒区分記号
				dt.Columns[ct_Col_DepositDebitNoteSign			].DefaultValue = "";
				
				dt.Columns.Add(ct_Col_DepositSlipNo				, typeof(int));			// 入金伝票番号
				dt.Columns[ct_Col_DepositSlipNo					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DebitNoteLinkDepoNo		, typeof(int));			// 赤黒入金連結番号
				dt.Columns[ct_Col_DebitNoteLinkDepoNo			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_InputDepositSecCd			, typeof(string));		// 入金入力拠点コード
				dt.Columns[ct_Col_InputDepositSecCd				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_InputDepositSecNm			, typeof(string));		// 入金入力拠点名称
				dt.Columns[ct_Col_InputDepositSecNm				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_AddUpSecCode				, typeof(string));		// 計上拠点コード
				dt.Columns[ct_Col_AddUpSecCode					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_AddUpSecName				, typeof(string));		// 計上拠点名称
				dt.Columns[ct_Col_AddUpSecName					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_AddUpSecName_Detail		, typeof(string));		// 計上拠点名称(明細)
				dt.Columns[ct_Col_AddUpSecName_Detail			].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DepositDate				, typeof(string));		// 入金日付
				dt.Columns[ct_Col_DepositDate					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_DepositDate			, typeof(long));		// ソート用入金日付
				dt.Columns[ct_Col_Sort_DepositDate				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AddUpADate				, typeof(string));		// 計上日付
				dt.Columns[ct_Col_AddUpADate					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_AddUpADate			, typeof(long));		// ソート用計上日付
				dt.Columns[ct_Col_Sort_AddUpADate				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositKindCode			, typeof(int));			// 入金金種コード
				dt.Columns[ct_Col_DepositKindCode				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositKindName			, typeof(string));		// 入金金種名称
				dt.Columns[ct_Col_DepositKindName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DepositKindDivCd			, typeof(int));			// 入金金種区分
				dt.Columns[ct_Col_DepositKindDivCd				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositTotal				, typeof(long));		// 入金計
				dt.Columns[ct_Col_DepositTotal					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_Deposit					, typeof(long));		// 入金金額
				dt.Columns[ct_Col_Deposit						].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_FeeDeposit				, typeof(long));		// 手数料入金額
				dt.Columns[ct_Col_FeeDeposit					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DiscountDeposit			, typeof(long));		// 値引入金額
				dt.Columns[ct_Col_DiscountDeposit				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_RebateDeposit				, typeof(long));		// リベート入金額
				dt.Columns[ct_Col_RebateDeposit					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AutoDepositCd				, typeof(int));			// 自動入金区分
				dt.Columns[ct_Col_AutoDepositCd					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AutoDepositCdName			, typeof(string));		// 自動入金区分名称
				dt.Columns[ct_Col_AutoDepositCdName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DepositCd					, typeof(int));			// 預り金区分
				dt.Columns[ct_Col_DepositCd						].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositCdName				, typeof(string));		// 預り金区分名称
				dt.Columns[ct_Col_DepositCdName					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DepositCdSign				, typeof(string));		// 預り金記号
				dt.Columns[ct_Col_DepositCdSign					].DefaultValue = "";

                // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
                //dt.Columns.Add(ct_Col_CreditOrLoanCd, typeof(int));			// クレジット／ローン区分
                //dt.Columns[ct_Col_CreditOrLoanCd				].DefaultValue = 0;		
				
                //dt.Columns.Add(ct_Col_CreditOrLoanCdNm			, typeof(string));		// クレジット／ローン区分名称
                //dt.Columns[ct_Col_CreditOrLoanCdNm				].DefaultValue = "";		
				
                //dt.Columns.Add(ct_Col_CreditCompanyCode			, typeof(string));		// クレジット会社コード
                //dt.Columns[ct_Col_CreditCompanyCode				].DefaultValue = "";		
				
                //dt.Columns.Add(ct_Col_CreditCompanyName			, typeof(string));		// クレジット会社名称
                //dt.Columns[ct_Col_CreditCompanyName				].DefaultValue = "";
                // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
				dt.Columns.Add(ct_Col_DraftDrawingDate			, typeof(string));		// 手形振出日
				dt.Columns[ct_Col_DraftDrawingDate				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DraftPayTimeLimit			, typeof(string));		// 手形支払期日
				dt.Columns[ct_Col_DraftPayTimeLimit				].DefaultValue = "";		
				
                // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
                // 手形種類
                dt.Columns.Add(ct_Col_DraftKind                 , typeof(int));
                dt.Columns[ct_Col_DraftKind                     ].DefaultValue = 0;

                // 手形種類名称
                dt.Columns.Add(ct_Col_DraftKindName             , typeof(string));
                dt.Columns[ct_Col_DraftKindName                 ].DefaultValue = "";

                // 手形区分
                dt.Columns.Add(ct_Col_DraftDivide               , typeof(int));
                dt.Columns[ct_Col_DraftDivide                   ].DefaultValue = 0;

                // 手形区分名称
                dt.Columns.Add(ct_Col_DraftDivideName           , typeof(string));
                dt.Columns[ct_Col_DraftDivideName               ].DefaultValue = "";

                // 手形番号
                dt.Columns.Add(ct_Col_DraftNo                   , typeof(string));
                dt.Columns[ct_Col_DraftNo                       ].DefaultValue = "";

                // 銀行コード
                dt.Columns.Add(ct_Col_BankCode                  , typeof(int));
                dt.Columns[ct_Col_BankCode                      ].DefaultValue = 0;

                // 銀行名称
                dt.Columns.Add(ct_Col_BankName                  , typeof(string));
                dt.Columns[ct_Col_BankName                      ].DefaultValue = "";
                // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<

				dt.Columns.Add(ct_Col_DraftOrCreditName			, typeof(string));		// 手形振出日又はクレジット会社名称
				dt.Columns[ct_Col_DraftOrCreditName				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_DepositAllowance			, typeof(long));		// 入金引当額
				dt.Columns[ct_Col_DepositAllowance				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositAlwcBlnce			, typeof(long));		// 入金引当残高
				dt.Columns[ct_Col_DepositAlwcBlnce				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_LastReconcileAddUpDt		, typeof(string));		// 最終消し込み計上日
				dt.Columns[ct_Col_LastReconcileAddUpDt			].DefaultValue = "";			
				
				dt.Columns.Add(ct_Col_CustomerCode				, typeof(int));			// 得意先コード
				dt.Columns[ct_Col_CustomerCode					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_CustomerName				, typeof(string));		// 得意先名称
				dt.Columns[ct_Col_CustomerName					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_CustomerName2				, typeof(string));		// 得意先名称2
				dt.Columns[ct_Col_CustomerName2					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Kana						, typeof(string));		// カナ
				dt.Columns[ct_Col_Kana							].DefaultValue = "";

                // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
                //dt.Columns.Add(ct_Col_CorporateDivCode, typeof(int));			// 個人・法人区分
                //dt.Columns[ct_Col_CorporateDivCode				].DefaultValue = 0;		
				
                //dt.Columns.Add(ct_Col_CorporateDivName			, typeof(string));		// 個人・法人区分名称
                //dt.Columns[ct_Col_CorporateDivName				].DefaultValue = "";
                // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
				dt.Columns.Add(ct_Col_Outline					, typeof(string));		// 伝票摘要
				dt.Columns[ct_Col_Outline						].DefaultValue = "";

                // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
                //dt.Columns.Add(ct_Col_AgentCode, typeof(string));		// 担当者コード
                //dt.Columns[ct_Col_AgentCode						].DefaultValue = "";		
				
                //dt.Columns.Add(ct_Col_AgentNm					, typeof(string));		// 担当者名称
                //dt.Columns[ct_Col_AgentNm						].DefaultValue = "";
                // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
                
                // 2008.07.14 30413 犬飼 請求先の追加 >>>>>>START
                // 請求先コード
                dt.Columns.Add(ct_Col_ClaimCode, typeof(Int32));
                dt.Columns[ct_Col_ClaimCode].DefaultValue = 0;
                
                // 請求先略称
                dt.Columns.Add(ct_Col_ClaimSnm, typeof(string));
                dt.Columns[ct_Col_ClaimSnm].DefaultValue = "";
                // 2008.07.14 30413 犬飼 請求先の追加 <<<<<<END

                // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
                //dt.Columns.Add(ct_Col_MiniTotal_KeyBleak, typeof(string));		// 小計出力キーブレイク
                //dt.Columns[ct_Col_MiniTotal_KeyBleak			].DefaultValue	= "";
                // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
				dt.Columns.Add(ct_Col_NomalDepositTotal			, typeof(long));		// 通常入金計
				dt.Columns[ct_Col_NomalDepositTotal				].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_ChargeDepositTotal		, typeof(long));		// 預り金入金計
				dt.Columns[ct_Col_ChargeDepositTotal			].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_AutoDepositTotal			, typeof(long));		// 自動入金計
				dt.Columns[ct_Col_AutoDepositTotal				].DefaultValue = 0;		

                // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns.Add(ct_Col_DepositKind_No1           , typeof(long));        // 入金金種テーブル01
                dt.Columns[ct_Col_DepositKind_No1               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No2           , typeof(long));        // 入金金種テーブル02
                dt.Columns[ct_Col_DepositKind_No2               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No3           , typeof(long));        // 入金金種テーブル03
                dt.Columns[ct_Col_DepositKind_No3               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No4           , typeof(long));        // 入金金種テーブル04
                dt.Columns[ct_Col_DepositKind_No4               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No5           , typeof(long));        // 入金金種テーブル05
                dt.Columns[ct_Col_DepositKind_No5               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No6           , typeof(long));        // 入金金種テーブル06
                dt.Columns[ct_Col_DepositKind_No6               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No7           , typeof(long));        // 入金金種テーブル07
                dt.Columns[ct_Col_DepositKind_No7               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No8           , typeof(long));        // 入金金種テーブル08
                dt.Columns[ct_Col_DepositKind_No8               ].DefaultValue = 0;
                dt.Columns.Add(ct_Col_DepositKind_No9           , typeof(long));        // 入金金種テーブル09
                dt.Columns[ct_Col_DepositKind_No9               ].DefaultValue = 0;
                // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

                // 2008.07.10 30413 犬飼 入金金種テーブルの追加 >>>>>>START
                dt.Columns.Add(ct_Col_DepositKind_No10, typeof(long));                  // 入金金種テーブル10
                dt.Columns[ct_Col_DepositKind_No10].DefaultValue = 0;
                // 2008.07.10 30413 犬飼 入金金種テーブルの追加 <<<<<<END

                // 2008.07.10 30413 犬飼 有効期限の追加 >>>>>>START
                // 有効期限
                dt.Columns.Add(ct_Col_ValidityTerm, typeof(string));
                dt.Columns[ct_Col_ValidityTerm].DefaultValue = "";
                // 2008.07.10 30413 犬飼 有効期限の追加 <<<<<<END
        
			}
		}
		#endregion
		#endregion
	}
}
