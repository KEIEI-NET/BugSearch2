using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 見積確認表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 見積確認表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
	/// <br></br>
    /// <br>Update Note: 2008.07.31 30413 犬飼</br>
    /// <br>           : PM.NS対応 </br>
    /// <br></br>
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>           : 障害対応10579(見積残数追加) </br>
    /// <br>Update Note: 2009.02.13 30452 上野 俊治</br>
    /// <br>           : 障害対応10579(受注数量、受注調整数追加) </br>
    /// <br>Update Note: 2011/11/11 x_zhuxk</br>
    /// <br>           : #redmine 26537 </br>
	/// </remarks>
	public class DCMIT02104EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_EstimateList = "Tbl_EstimateList";


        /// <summary> 実績計上拠点コード </summary>
        public const string ct_Col_ResultsAddUpSecCd = "ResultsAddUpSecCd";
        /// <summary> 実績計上拠点ガイド名称 </summary>
        public const string ct_Col_ResultsAddUpSecNm = "ResultsAddUpSecNm";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 入力日付 </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        /// <summary> 見積日付 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 見積伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 売上行番号 </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";
        /// <summary> 見積書番号 </summary>
        public const string ct_Col_EstimateFormNo = "EstimateFormNo";
        /// <summary> 販売従業員コード </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> 販売従業員名称 </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> 伝票備考 </summary>
        public const string ct_Col_SlipNote = "SlipNote";
        /// <summary> 伝票備考２ </summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";
        /// <summary> 伝票備考３ </summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";
        /// <summary> 見積区分 </summary>
        public const string ct_Col_EstimateDivide = "EstimateDivide";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（全角） </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> 定価（税抜，浮動） </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt"; // ADD 2009/02/13
        /// <summary> 受注調整数 </summary>
        public const string ct_Col_AcptAnOdrAdjustCnt = "AcptAnOdrAdjustCnt"; // ADD 2009/02/13
        /// <summary> 現在の受注数(受注数量+受注調整数) </summary>
        public const string ct_Col_AcceptAnOrderCntPlusAdjustCnt = "AcceptAnOrderCntPlusAdjustCnt"; // ADD 2009/02/13
        /// <summary> 見積残数(受注残数) </summary>
        public const string ct_Col_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt"; // ADD 2009/02/02
        /// <summary> 原価単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> 売上金額（税抜き） </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 販売区分コード </summary>
        public const string ct_Col_SalesCode = "SalesCode";
        /// <summary> 販売区分名称 </summary>
        public const string ct_Col_SalesCdNm = "SalesCdNm";
        /// <summary> 伝票メモ１ </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> 伝票メモ２ </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> 伝票メモ３ </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        /// <summary> 社内メモ１ </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> 社内メモ２ </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> 社内メモ３ </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        /// <summary> 見積備考１ </summary>
        public const string ct_Col_EstimateNote1 = "EstimateNote1";
        /// <summary> 見積備考２ </summary>
        public const string ct_Col_EstimateNote2 = "EstimateNote2";
        /// <summary> 見積備考３ </summary>
        public const string ct_Col_EstimateNote3 = "EstimateNote3";
        /// <summary> 見積備考４ </summary>
        public const string ct_Col_EstimateNote4 = "EstimateNote4";
        /// <summary> 見積備考５ </summary>
        public const string ct_Col_EstimateNote5 = "EstimateNote5";
        /// <summary> 見積有効期限 </summary>
        public const string ct_Col_EstimateValidityDate = "EstimateValidityDate";
        /// <summary> 車種全角名称 </summary>
        public const string ct_Col_ModelFullName = "ModelFullName";
        /// <summary> 車種半角名称 </summary>
        public const string ct_Col_ModelHalfName = "ModelHalfName";
        /// <summary> 型式（フル型） </summary>
        public const string ct_Col_FullModel = "FullModel";
        /// <summary> 型式指定番号 </summary>
        public const string ct_Col_ModelDesignationNo = "ModelDesignationNo";
        /// <summary> 類別番号 </summary>
        public const string ct_Col_CategoryNo = "CategoryNo";
        /// <summary> 車輌管理コード </summary>
        public const string ct_Col_CarMngCode = "CarMngCode";
        /// <summary> 初年度 </summary>
        public const string ct_Col_FirstEntryDate = "FirstEntryDate";
        /// <summary> 売上伝票区分（明細） </summary>
        public const string ct_Col_SalesSlipCdDtl = "SalesSlipCdDtl";

        // ↓↓テーブル仕様以外
        /// <summary> 見積区分名称 </summary>
        public const string ct_Col_EstimateDivideNm = "EstimateDivideNm";
        /// <summary> 類別(明細) </summary>
        public const string ct_Col_CategoryDtl = "CategoryDtl";
        /// <summary> 得意先コード(印字用) </summary>
        public const string ct_Col_PrtCustomerCode = "PrtCustomerCode";
        /// <summary> 仕入先コード(印字用) </summary>
        public const string ct_Col_PrtSupplierCd = "PrtSupplierCd";
        /// <summary> 販売区分コード(印字用) </summary>
        public const string ct_Col_PrtSalesCode = "PrtSalesCode";
        /// <summary> BL商品コード(印字用) </summary>
        public const string ct_Col_PrtBLGoodsCode = "PrtBLGoodsCode";

        //2011/11/11 ADD --------------------------------->>
        /// <summary> BL商品コード(印字用) </summary>
        public const string ct_Col_AutoAnswerDivSCMRF = "AutoAnswerDivSCMRF";
        /// <summary> BL商品コード(印字用) </summary>
        public const string ct_Col_AcceptOrOrderKindRF = "AcceptOrOrderKindRF";
        //2011/11/11 ADD ---------------------------------<<
        
		#endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 見積確認表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 見積確認表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCMIT02104EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// <summary>
		/// 在庫・倉庫移動DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
                // スキーマ設定
                dt = new DataTable( ct_Tbl_EstimateList );

                // デフォルト値
                string defValuestring = string.Empty;
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0;
                DateTime defValueDateTime = DateTime.MinValue;
                //2011/11/11 ADD----------------------->>
                Int16 defValueInt16 = 0;
                //2011/11/11 ADD-----------------------<<
                # region <Column追加>

                // 実績計上拠点コード
                dt.Columns.Add(ct_Col_ResultsAddUpSecCd, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecCd].DefaultValue = defValuestring;

                // 実績計上拠点ガイド名称
                dt.Columns.Add(ct_Col_ResultsAddUpSecNm, typeof(string));
                dt.Columns[ct_Col_ResultsAddUpSecNm].DefaultValue = defValuestring;

                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = defValueInt32;

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = defValuestring;

                // 入力日付
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(DateTime));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = defValueDateTime;

                // 見積日付
                dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
                dt.Columns[ct_Col_SalesDate].DefaultValue = defValueDateTime;

                // 見積伝票番号
                dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;

                // 売上行番号
                dt.Columns.Add(ct_Col_SalesRowNo, typeof(Int32));
                dt.Columns[ct_Col_SalesRowNo].DefaultValue = defValueInt32;

                // 見積書番号
                dt.Columns.Add(ct_Col_EstimateFormNo, typeof(string));
                dt.Columns[ct_Col_EstimateFormNo].DefaultValue = defValuestring;

                // 販売従業員コード
                dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = defValuestring;

                // 販売従業員名称
                dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = defValuestring;

                // 伝票備考
                dt.Columns.Add(ct_Col_SlipNote, typeof(string));
                dt.Columns[ct_Col_SlipNote].DefaultValue = defValuestring;

                // 伝票備考２
                dt.Columns.Add(ct_Col_SlipNote2, typeof(string));
                dt.Columns[ct_Col_SlipNote2].DefaultValue = defValuestring;

                // 伝票備考３
                dt.Columns.Add(ct_Col_SlipNote3, typeof(string));
                dt.Columns[ct_Col_SlipNote3].DefaultValue = defValuestring;

                // 見積区分
                dt.Columns.Add(ct_Col_EstimateDivide, typeof(Int32));
                dt.Columns[ct_Col_EstimateDivide].DefaultValue = defValueInt32;

                // 商品メーカーコード
                dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
                dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;

                // メーカー名称
                dt.Columns.Add(ct_Col_MakerName, typeof(string));
                dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;

                // 商品番号
                dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;

                // 商品名称
                dt.Columns.Add(ct_Col_GoodsName, typeof(string));
                dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;

                // BL商品コード
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;

                // BL商品コード名称（全角）
                dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
                dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defValuestring;

                // 定価（税抜，浮動）
                dt.Columns.Add(ct_Col_ListPriceTaxExcFl, typeof(Double));
                dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;

                // 出荷数
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;

                // --- ADD 2009/02/13 -------------------------------->>>>>
                // 受注数量
                dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                // 受注調整数
                dt.Columns.Add(ct_Col_AcptAnOdrAdjustCnt, typeof(Double));
                dt.Columns[ct_Col_AcptAnOdrAdjustCnt].DefaultValue = defValueDouble;

                // 現在の受注数
                dt.Columns.Add(ct_Col_AcceptAnOrderCntPlusAdjustCnt, typeof(Double));
                dt.Columns[ct_Col_AcceptAnOrderCntPlusAdjustCnt].DefaultValue = defValueDouble;
                // --- ADD 2009/02/13 --------------------------------<<<<<
                // --- ADD 2009/02/02 -------------------------------->>>>>
                // 見積残数
                dt.Columns.Add(ct_Col_AcptAnOdrRemainCnt, typeof(Double));
                dt.Columns[ct_Col_AcptAnOdrRemainCnt].DefaultValue = defValueDouble;
                // --- ADD 2009/02/02 --------------------------------<<<<<

                // 原価単価
                dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
                dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defValueDouble;

                // 売上単価（税抜，浮動）
                dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;

                // 売上金額（税抜き）
                dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(Int64));
                dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = defValueInt64;

                // 仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;

                // 仕入先略称
                dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;

                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;

                // 倉庫名称
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;

                // 販売区分コード
                dt.Columns.Add(ct_Col_SalesCode, typeof(Int32));
                dt.Columns[ct_Col_SalesCode].DefaultValue = defValueInt32;

                // 販売区分名称
                dt.Columns.Add(ct_Col_SalesCdNm, typeof(string));
                dt.Columns[ct_Col_SalesCdNm].DefaultValue = defValuestring;

                // 伝票メモ１
                dt.Columns.Add(ct_Col_SlipMemo1, typeof(string));
                dt.Columns[ct_Col_SlipMemo1].DefaultValue = defValuestring;

                // 伝票メモ２
                dt.Columns.Add(ct_Col_SlipMemo2, typeof(string));
                dt.Columns[ct_Col_SlipMemo2].DefaultValue = defValuestring;

                // 伝票メモ３
                dt.Columns.Add(ct_Col_SlipMemo3, typeof(string));
                dt.Columns[ct_Col_SlipMemo3].DefaultValue = defValuestring;

                // 社内メモ１
                dt.Columns.Add(ct_Col_InsideMemo1, typeof(string));
                dt.Columns[ct_Col_InsideMemo1].DefaultValue = defValuestring;

                // 社内メモ２
                dt.Columns.Add(ct_Col_InsideMemo2, typeof(string));
                dt.Columns[ct_Col_InsideMemo2].DefaultValue = defValuestring;

                // 社内メモ３
                dt.Columns.Add(ct_Col_InsideMemo3, typeof(string));
                dt.Columns[ct_Col_InsideMemo3].DefaultValue = defValuestring;

                // 見積備考１
                dt.Columns.Add(ct_Col_EstimateNote1, typeof(string));
                dt.Columns[ct_Col_EstimateNote1].DefaultValue = defValuestring;

                // 見積備考２
                dt.Columns.Add(ct_Col_EstimateNote2, typeof(string));
                dt.Columns[ct_Col_EstimateNote2].DefaultValue = defValuestring;

                // 見積備考３
                dt.Columns.Add(ct_Col_EstimateNote3, typeof(string));
                dt.Columns[ct_Col_EstimateNote3].DefaultValue = defValuestring;

                // 見積備考４
                dt.Columns.Add(ct_Col_EstimateNote4, typeof(string));
                dt.Columns[ct_Col_EstimateNote4].DefaultValue = defValuestring;

                // 見積備考５
                dt.Columns.Add(ct_Col_EstimateNote5, typeof(string));
                dt.Columns[ct_Col_EstimateNote5].DefaultValue = defValuestring;

                // 見積有効期限
                dt.Columns.Add(ct_Col_EstimateValidityDate, typeof(DateTime));
                dt.Columns[ct_Col_EstimateValidityDate].DefaultValue = defValueDateTime;

                // 車種全角名称
                dt.Columns.Add(ct_Col_ModelFullName, typeof(string));
                dt.Columns[ct_Col_ModelFullName].DefaultValue = defValuestring;

                // 車種半角名称
                dt.Columns.Add(ct_Col_ModelHalfName, typeof(string));
                dt.Columns[ct_Col_ModelHalfName].DefaultValue = defValuestring;

                // 型式（フル型）
                dt.Columns.Add(ct_Col_FullModel, typeof(string));
                dt.Columns[ct_Col_FullModel].DefaultValue = defValuestring;

                // 型式指定番号
                dt.Columns.Add(ct_Col_ModelDesignationNo, typeof(Int32));
                dt.Columns[ct_Col_ModelDesignationNo].DefaultValue = defValueInt32;

                // 類別番号
                dt.Columns.Add(ct_Col_CategoryNo, typeof(Int32));
                dt.Columns[ct_Col_CategoryNo].DefaultValue = defValueInt32;

                // 車輌管理コード
                dt.Columns.Add(ct_Col_CarMngCode, typeof(string));
                dt.Columns[ct_Col_CarMngCode].DefaultValue = defValuestring;

                // 初年度
                dt.Columns.Add(ct_Col_FirstEntryDate, typeof(string));
                dt.Columns[ct_Col_FirstEntryDate].DefaultValue = defValuestring;

                // 売上伝票区分（明細）
                dt.Columns.Add(ct_Col_SalesSlipCdDtl, typeof(Int32));
                dt.Columns[ct_Col_SalesSlipCdDtl].DefaultValue = defValueInt32;

                // ↓↓テーブル仕様以外
                // 見積区分名称
                dt.Columns.Add(ct_Col_EstimateDivideNm, typeof(string));
                dt.Columns[ct_Col_EstimateDivideNm].DefaultValue = defValuestring;

                // 類別(明細)
                dt.Columns.Add(ct_Col_CategoryDtl, typeof(string));
                dt.Columns[ct_Col_CategoryDtl].DefaultValue = defValuestring;

                // 得意先コード(印字用)
                dt.Columns.Add(ct_Col_PrtCustomerCode, typeof(string));
                dt.Columns[ct_Col_PrtCustomerCode].DefaultValue = defValuestring;

                // 仕入先コード(印字用)
                dt.Columns.Add(ct_Col_PrtSupplierCd, typeof(string));
                dt.Columns[ct_Col_PrtSupplierCd].DefaultValue = defValuestring;

                // 販売区分コード(印字用)
                dt.Columns.Add(ct_Col_PrtSalesCode, typeof(string));
                dt.Columns[ct_Col_PrtSalesCode].DefaultValue = defValuestring;

                // BL商品コード(印字用)
                dt.Columns.Add(ct_Col_PrtBLGoodsCode, typeof(string));
                dt.Columns[ct_Col_PrtBLGoodsCode].DefaultValue = defValueInt32;

                // 2011/11/11 ADD----------------------------->>
                // 連携伝票出力区分
                dt.Columns.Add(ct_Col_AutoAnswerDivSCMRF, typeof(string));
                dt.Columns[ct_Col_AutoAnswerDivSCMRF].DefaultValue = defValueInt32;

                // 連携伝票対象区分
                dt.Columns.Add(ct_Col_AcceptOrOrderKindRF, typeof(string));
                dt.Columns[ct_Col_AcceptOrOrderKindRF].DefaultValue = defValueInt16;
                // 2011/11/11 ADD-----------------------------<<
                # endregion
            }
		}
		#endregion
		#endregion
	}
}
