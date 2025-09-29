using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 入金一覧表引当データ用テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金一覧表の引当データ用テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22013 久保　将太</br>
	/// <br>Date       : 2007.03.05</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MAHNB02014EB
	{
		#region ■ Static Const

		/// <summary> テーブル名称 </summary>
		public const string ct_Tbl_DepositAlw				= "Tbl_DepositAlw";

		/// <summary> リレーション名称 </summary>
		public const string ct_Rel_DepositAlw				= "Rel_DepositAlw";

		/// <summary> 消込み計上日 </summary>
		public const string ct_Col_ReconcileAddUpDate		= "ReconcileAddUpDate";

		/// <summary> 受注番号 </summary>
		public const string ct_Col_AcceptAnOrderNo			= "AcceptAnOrderNo";
		
		/// <summary> 受注ステータス </summary>
		public const string ct_Col_AcptAnOdrStatus			= "AcptAnOdrStatus";
		
		/// <summary> 売上伝票種別 </summary>
		public const string ct_Col_SalesSlipKind			= "SalesSlipKind";
		
		/// <summary> 受注ステータス名称 </summary>
		public const string ct_Col_AcptAnOdrStatusName		= "AcptAnOdrStatusName";

		/// <summary> 売上伝票番号 </summary>
		public const string ct_Col_SalesSlipNum				= "SalesSlipNum";
		
		/// <summary> 承り伝票番号 </summary>
		public const string ct_Col_AcptAnOdrSlipNum			= "AcptAnOdrSlipNum";
		
		/// <summary> 見積伝票番号 </summary>
		public const string ct_Col_EstimateSlipNo			= "EstimateSlipNo";
		
		/// <summary> 検索伝票番号 </summary>
		public const string ct_Col_SearchSlipNo				= "SearchSlipNo";

		/// <summary> 赤伝区分 </summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
		public const string ct_Col_DebitNoteDiv				= "DebitNoteDiv";
		
		/// <summary> 赤伝区分名称 </summary>
		public const string ct_Col_DebitNoteDivName			= "DebitNoteDivName";
		
		/// <summary> 赤黒連結受注番号 </summary>
		/// <remarks>赤黒の相手方受注番号</remarks>
		public const string ct_Col_DebitNLnkAcptAnOdr		= "DebitNLnkAcptAnOdr";
		
		/// <summary> 売上伝票区分 </summary>
		/// <remarks>0:売上,1:返品,2:値引</remarks>
		public const string ct_Col_SalesSlipCd				= "SalesSlipCd";
		
		/// <summary> 売上伝票区分名称 </summary>
		public const string ct_Col_SalesSlipCdName			= "SalesSlipCdName";
		
		/// <summary> 売上形式 </summary>
		/// <remarks>10:店頭売上,11:外販,20:業務販売（売切）</remarks>
		public const string ct_Col_SalesFormal				= "SalesFormal";
		
		/// <summary> 売上形式名称 </summary>
		public const string ct_Col_SalesFormalName			= "SalesFormalName";
		
		/// <summary> 売上入力拠点コード </summary>
		public const string ct_Col_SalesInpSecCd			= "SalesInpSecCd";
		
		/// <summary> 売上入力拠点名称 </summary>
		/// <remarks>※ガイド名称</remarks>
		public const string ct_Col_SalesInpSecNm			= "SalesInpSecNm";
		
		/// <summary> 請求計上拠点コード </summary>
		public const string ct_Col_ResultsAddUpSecCd		= "ResultsAddUpSecCd";
		
		/// <summary> 請求計上拠点名称 </summary>
		/// <remarks>※ガイド名称</remarks>
		public const string ct_Col_ResultsAddUpSecNm		= "ResultsAddUpSecNm";
		
		/// <summary> 実績計上拠点コード </summary>
		public const string ct_Col_UpdateSecCd				= "UpdateSecCd";
		
		/// <summary> 実績計上拠点名称 </summary>
		/// <remarks>※ガイド名称</remarks>
		public const string ct_Col_UpdateSecNm				= "UpdateSecNm";
		
		/// <summary> 見積日付 </summary>
		public const string ct_Col_EstimateDate				= "EstimateDate";

		/// <summary> ソート用見積日付 </summary>
		public const string ct_Col_Sort_EstimateDate		= "Sort_EstimateDate";

		/// <summary> 受注日 </summary>
		public const string ct_Col_AcceptAnOrderDate		= "AcceptAnOrderDate";
		
		/// <summary> ソート用受注日 </summary>
		public const string ct_Col_Sort_AcceptAnOrderDate	= "Sort_AcceptAnOrderDate";
		
		/// <summary> 売上日付 </summary>
		public const string ct_Col_SalesDate				= "SalesDate";
		
		/// <summary> ソート用売上日付 </summary>
		public const string ct_Col_Sort_SalesDate			= "Sort_SalesDate";
		
		/// <summary> 売上計上日付 </summary>
		public const string ct_Col_SalesAddUpADate			= "SalesAddUpADate";

		/// <summary> ソート用売上計上日付 </summary>
		public const string ct_Col_Sort_SalesAddUpADate		= "Sort_SalesAddUpADate";
		
		/// <summary> 売掛区分 </summary>
		/// <remarks>0:売掛なし,1:売掛</remarks>
		public const string ct_Col_AccRecDivCd				= "AccRecDivCd";
		
		/// <summary> 売掛区分名称 </summary>
		public const string ct_Col_AccRecDivCdName			= "AccRecDivCdName";
		
		/// <summary> 請求合計額 </summary>
		/// <remarks>伝票全体の請求合計（クレジット手数料は含まない）</remarks>
		public const string ct_Col_DemandableTtl			= "DemandableTtl";
		
		/// <summary> 入金引当合計額 </summary>
		/// <remarks>預り金引当合計額を含む</remarks>
		public const string ct_Col_DepositAllowanceTtl		= "DepositAllowanceTtl";
		
		/// <summary> 預り金引当合計額 </summary>	
		public const string ct_Col_MnyDepoAllowanceTtl		= "MnyDepoAllowanceTtl";
		
		/// <summary> 入金引当残高 </summary>
		public const string ct_Col_DepositAlwcBlnce			= "DepositAlwcBlnce";
		
		/// <summary> 引当状態 </summary>
		/// <remarks> 0:引当済, 1:一部引当, 2:未引当</remarks>
		public const string ct_Col_AllowanceState			= "AllowanceState";
		
		/// <summary> 引当状態名称 </summary>
		public const string ct_Col_AllowanceStateName		= "AllowanceStateName";
		
		/// <summary> 請求先コード </summary>
		public const string ct_Col_ClaimCode				= "ClaimCode";
		
		/// <summary> 請求先名称1 </summary>
		public const string ct_Col_ClaimName1				= "ClaimName1";
		
		/// <summary> 請求先名称2 </summary>
		public const string ct_Col_ClaimName2				= "ClaimName2";
		
		/// <summary> 得意先コード </summary>
		public const string ct_Col_CustomerCode				= "CustomerCode";
		
		/// <summary> 得意先名称 </summary>
		public const string ct_Col_CustomerName				= "CustomerName";
		
		/// <summary> 得意先名称2 </summary>
		public const string ct_Col_CustomerName2			= "CustomerName2";
		
		/// <summary> 敬称 </summary>
		public const string ct_Col_HonorificTitle			= "HonorificTitle";
		
		/// <summary> カナ </summary>
		public const string ct_Col_Kana						= "Kana";

		/// <summary> 入金計上拠点コード </summary>
		public const string ct_Col_DepositAddupSecCd		= "DepositAddupSecCd";

		/// <summary> 入金計上拠点名称 </summary>
		public const string ct_Col_DepositAddupSecNm		= "DepositAddupSecNm";

		/// <summary> 入金伝票番号 </summary>
		public const string ct_Col_DepositSlipNo			= "DepositSlipNo";

		#endregion

		#region ■ Constructor
		/// <summary>
		/// 入金一覧表引当データ用テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金一覧表引当データ用テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		public MAHNB02014EB()
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
		/// <br>Note       : 引当データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		static public void CreateDataTableDepositAllowance(ref DataSet ds)
		{
			if ( ds == null )
				ds = new DataSet();

			// テーブルが存在するかどうかのチェック
			if ( ds.Tables.Contains( ct_Tbl_DepositAlw ) )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				ds.Tables[ct_Tbl_DepositAlw].Clear();
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(ct_Tbl_DepositAlw);
				DataTable dt = ds.Tables[ct_Tbl_DepositAlw];

				dt.Columns.Add(ct_Col_ReconcileAddUpDate		, typeof(string));		// 消込み計上日
				dt.Columns[ct_Col_ReconcileAddUpDate			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_AcceptAnOrderNo			, typeof(int));			// 受注番号
				dt.Columns[ct_Col_AcceptAnOrderNo				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcptAnOdrStatus			, typeof(int));			// 受注ステータス
				dt.Columns[ct_Col_AcptAnOdrStatus				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipKind				, typeof(int));			// 売上伝票種別
				dt.Columns[ct_Col_SalesSlipKind					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcptAnOdrStatusName		, typeof(string));		// 受注ステータス名称
				dt.Columns[ct_Col_AcptAnOdrStatusName			].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesSlipNum				, typeof(string));		// 売上伝票番号
				dt.Columns[ct_Col_SalesSlipNum					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_AcptAnOdrSlipNum			, typeof(string));		// 承り伝票番号
				dt.Columns[ct_Col_AcptAnOdrSlipNum				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_EstimateSlipNo			, typeof(string));		// 見積伝票番号
				dt.Columns[ct_Col_EstimateSlipNo				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_SearchSlipNo				, typeof(string));		// 検索伝票番号
				dt.Columns[ct_Col_SearchSlipNo					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DebitNoteDiv				, typeof(int));			// 赤伝区分
				dt.Columns[ct_Col_DebitNoteDiv					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DebitNoteDivName			, typeof(string));		// 赤伝区分名称
				dt.Columns[ct_Col_DebitNoteDivName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DebitNLnkAcptAnOdr		, typeof(int));			// 赤黒連結受注番号
				dt.Columns[ct_Col_DebitNLnkAcptAnOdr			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipCd				, typeof(int));			// 売上伝票区分
				dt.Columns[ct_Col_SalesSlipCd					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesSlipCdName			, typeof(string));		// 売上伝票区分名称
				dt.Columns[ct_Col_SalesSlipCdName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesFormal				, typeof(int));			// 売上形式
				dt.Columns[ct_Col_SalesFormal					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesFormalName			, typeof(string));		// 売上形式
				dt.Columns[ct_Col_SalesFormalName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_SalesInpSecCd				, typeof(string));		// 売上入力拠点コード
				dt.Columns[ct_Col_SalesInpSecCd					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_SalesInpSecNm				, typeof(string));		// 売上入力拠点名称
				dt.Columns[ct_Col_SalesInpSecNm					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ResultsAddUpSecCd			, typeof(string));		// 請求計上拠点コード
				dt.Columns[ct_Col_ResultsAddUpSecCd				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ResultsAddUpSecNm			, typeof(string));		// 請求計上拠点名称
				dt.Columns[ct_Col_ResultsAddUpSecNm				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_UpdateSecCd				, typeof(string));		// 実績計上拠点コード
				dt.Columns[ct_Col_UpdateSecCd					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_UpdateSecNm				, typeof(string));		// 実績計上拠点名称
				dt.Columns[ct_Col_UpdateSecNm					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_EstimateDate				, typeof(string));		// 見積日付
				dt.Columns[ct_Col_EstimateDate					].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_EstimateDate			, typeof(long));		// ソート用見積日付
				dt.Columns[ct_Col_EstimateDate					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AcceptAnOrderDate			, typeof(string));		// 受注日
				dt.Columns[ct_Col_AcceptAnOrderDate				].DefaultValue = "";		

				dt.Columns.Add(ct_Col_Sort_AcceptAnOrderDate	, typeof(long));		// ソート用受注日
				dt.Columns[ct_Col_Sort_AcceptAnOrderDate		].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesDate					, typeof(string));		// 売上日付
				dt.Columns[ct_Col_SalesDate						].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_SalesDate			, typeof(long));		// ソート用売上日付
				dt.Columns[ct_Col_Sort_SalesDate				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_SalesAddUpADate			, typeof(string));		// 売上計上日付
				dt.Columns[ct_Col_SalesAddUpADate				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_Sort_SalesAddUpADate		, typeof(long));		// ソート用売上計上日付
				dt.Columns[ct_Col_Sort_SalesAddUpADate			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AccRecDivCd				, typeof(int));			// 売掛区分
				dt.Columns[ct_Col_AccRecDivCd					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AccRecDivCdName			, typeof(string));		// 売掛区分名称
				dt.Columns[ct_Col_AccRecDivCdName				].DefaultValue = "";		
				
				dt.Columns.Add(ct_Col_DemandableTtl				, typeof(long));		// 請求合計額
				dt.Columns[ct_Col_DemandableTtl					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositAllowanceTtl		, typeof(long));		// 入金引当合計額
				dt.Columns[ct_Col_DepositAllowanceTtl			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_MnyDepoAllowanceTtl		, typeof(long));		// 預り金引当合計額
				dt.Columns[ct_Col_MnyDepoAllowanceTtl			].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_DepositAlwcBlnce			, typeof(long));		// 入金引当残高
				dt.Columns[ct_Col_DepositAlwcBlnce				].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_AllowanceState			, typeof(int));			// 引当状態
				dt.Columns[ct_Col_AllowanceState				].DefaultValue = 0;		

				dt.Columns.Add(ct_Col_AllowanceStateName		, typeof(string));		// 引当状態名称
				dt.Columns[ct_Col_AllowanceStateName			].DefaultValue = "";		

				dt.Columns.Add(ct_Col_ClaimCode					, typeof(int));			// 請求先コード
				dt.Columns[ct_Col_ClaimCode						].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_ClaimName1				, typeof(string));		// 請求先名称1
				dt.Columns[ct_Col_ClaimName1					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_ClaimName2				, typeof(string));		// 請求先名称2
				dt.Columns[ct_Col_ClaimName2					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_CustomerCode				, typeof(int));			// 得意先コード
				dt.Columns[ct_Col_CustomerCode					].DefaultValue = 0;		
				
				dt.Columns.Add(ct_Col_CustomerName				, typeof(string));		// 得意先名称
				dt.Columns[ct_Col_CustomerName					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_CustomerName2				, typeof(string));		// 得意先名称2
				dt.Columns[ct_Col_CustomerName2					].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_HonorificTitle			, typeof(string));		// 敬称
				dt.Columns[ct_Col_HonorificTitle				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_Kana						, typeof(string));		// カナ
				dt.Columns[ct_Col_Kana							].DefaultValue = "";

				dt.Columns.Add(ct_Col_DepositAddupSecCd			, typeof(string));		// 入金計上拠点コード
				dt.Columns[ct_Col_DepositAddupSecCd				].DefaultValue = "";	

				dt.Columns.Add(ct_Col_DepositAddupSecNm			, typeof(string));		// 入金計上拠点名称
				dt.Columns[ct_Col_DepositAddupSecNm				].DefaultValue = "";	
				
				dt.Columns.Add(ct_Col_DepositSlipNo				, typeof(int));			// 入金伝票番号
				dt.Columns[ct_Col_DepositSlipNo					].DefaultValue = 0;		
				
		}

		}
		#endregion
		#endregion

	}
}
