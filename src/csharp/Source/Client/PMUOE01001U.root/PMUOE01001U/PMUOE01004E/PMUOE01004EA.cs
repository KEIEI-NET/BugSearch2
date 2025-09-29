//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入明細テーブルスキーマクラス
// プログラム概要   : 仕入明細テーブル定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 仕入明細テーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入明細抽出結果テーブルスキーマ</br>
	/// <br>Programmer : 96186　立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class StockDetailSchema
	{
		#region Public Members
		/// <summary>仕入明細テーブル名</summary>
        public const string CT_SendStockDetailDataTable = "SendStockDetailDataTable";

		#region カラム初期情報
		public const double defValueDouble = 0;
		public const Int64 defValueInt64 = 0;
		public const Int32 defValueInt32 = 0;
		public const string defValuestring = "";
        public const bool defValueBoolean = true;
		#endregion

		#region カラム情報
        /// <summary> 作成日時 </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> 更新日時 </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> 更新従業員コード </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> 更新アセンブリID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> 更新アセンブリID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> 論理削除区分 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> 受注番号 </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> 仕入形式 </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> 仕入伝票番号 </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 仕入行番号 </summary>
        public const string ct_Col_StockRowNo = "StockRowNo";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 部門コード </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> 共通通番 </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> 仕入明細通番 </summary>
        public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> 仕入形式（元） </summary>
        public const string ct_Col_SupplierFormalSrc = "SupplierFormalSrc";
        /// <summary> 仕入明細通番（元） </summary>
        public const string ct_Col_StockSlipDtlNumSrc = "StockSlipDtlNumSrc";
        /// <summary> 受注ステータス（同時） </summary>
        public const string ct_Col_AcptAnOdrStatusSync = "AcptAnOdrStatusSync";
        /// <summary> 売上明細通番（同時） </summary>
        public const string ct_Col_SalesSlipDtlNumSync = "SalesSlipDtlNumSync";
        /// <summary> 仕入伝票区分（明細） </summary>
        public const string ct_Col_StockSlipCdDtl = "StockSlipCdDtl";
        /// <summary> 仕入入力者コード </summary>
        public const string ct_Col_StockInputCode = "StockInputCode";
        /// <summary> 仕入入力者名称 </summary>
        public const string ct_Col_StockInputName = "StockInputName";
        /// <summary> 仕入担当者コード </summary>
        public const string ct_Col_StockAgentCode = "StockAgentCode";
        /// <summary> 仕入担当者名称 </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";
        /// <summary> 商品属性 </summary>
        public const string ct_Col_GoodsKindCode = "GoodsKindCode";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> メーカーカナ名称 </summary>
        public const string ct_Col_MakerKanaName = "MakerKanaName";
        /// <summary> メーカーカナ名称（一式） </summary>
        public const string ct_Col_CmpltMakerKanaName = "CmpltMakerKanaName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 商品名称カナ </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        /// <summary> 商品大分類コード </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        /// <summary> 商品大分類名称 </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> 商品中分類コード </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> 商品中分類名称 </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BLグループコード </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BLグループコード名称 </summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（全角） </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> 自社分類コード </summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> 自社分類名称 </summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 仕入在庫取寄せ区分 </summary>
        public const string ct_Col_StockOrderDivCd = "StockOrderDivCd";
        /// <summary> オープン価格区分 </summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary> 商品掛率ランク </summary>
        public const string ct_Col_GoodsRateRank = "GoodsRateRank";
        /// <summary> 得意先掛率グループコード </summary>
        public const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> 仕入先掛率グループコード </summary>
        public const string ct_Col_SuppRateGrpCode = "SuppRateGrpCode";
        /// <summary> 定価（税抜，浮動） </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> 定価（税込，浮動） </summary>
        public const string ct_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";
        /// <summary> 仕入率 </summary>
        public const string ct_Col_StockRate = "StockRate";
        /// <summary> 掛率設定拠点（仕入単価） </summary>
        public const string ct_Col_RateSectStckUnPrc = "RateSectStckUnPrc";
        /// <summary> 掛率設定区分（仕入単価） </summary>
        public const string ct_Col_RateDivStckUnPrc = "RateDivStckUnPrc";
        /// <summary> 単価算出区分（仕入単価） </summary>
        public const string ct_Col_UnPrcCalcCdStckUnPrc = "UnPrcCalcCdStckUnPrc";
        /// <summary> 価格区分（仕入単価） </summary>
        public const string ct_Col_PriceCdStckUnPrc = "PriceCdStckUnPrc";
        /// <summary> 基準単価（仕入単価） </summary>
        public const string ct_Col_StdUnPrcStckUnPrc = "StdUnPrcStckUnPrc";
        /// <summary> 端数処理単位（仕入単価） </summary>
        public const string ct_Col_FracProcUnitStcUnPrc = "FracProcUnitStcUnPrc";
        /// <summary> 端数処理（仕入単価） </summary>
        public const string ct_Col_FracProcStckUnPrc = "FracProcStckUnPrc";
        /// <summary> 仕入単価（税抜，浮動） </summary>
        public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 仕入単価（税込，浮動） </summary>
        public const string ct_Col_StockUnitTaxPriceFl = "StockUnitTaxPriceFl";
        /// <summary> 仕入単価変更区分 </summary>
        public const string ct_Col_StockUnitChngDiv = "StockUnitChngDiv";
        /// <summary> 変更前仕入単価（浮動） </summary>
        public const string ct_Col_BfStockUnitPriceFl = "BfStockUnitPriceFl";
        /// <summary> 変更前定価 </summary>
        public const string ct_Col_BfListPrice = "BfListPrice";
        /// <summary> BL商品コード（掛率） </summary>
        public const string ct_Col_RateBLGoodsCode = "RateBLGoodsCode";
        /// <summary> BL商品コード名称（掛率） </summary>
        public const string ct_Col_RateBLGoodsName = "RateBLGoodsName";
        /// <summary> 商品掛率グループコード（掛率） </summary>
        public const string ct_Col_RateGoodsRateGrpCd = "RateGoodsRateGrpCd";
        /// <summary> 商品掛率グループ名称（掛率） </summary>
        public const string ct_Col_RateGoodsRateGrpNm = "RateGoodsRateGrpNm";
        /// <summary> BLグループコード（掛率） </summary>
        public const string ct_Col_RateBLGroupCode = "RateBLGroupCode";
        /// <summary> BLグループ名称（掛率） </summary>
        public const string ct_Col_RateBLGroupName = "RateBLGroupName";
        /// <summary> 仕入数 </summary>
        public const string ct_Col_StockCount = "StockCount";
        /// <summary> 発注数量 </summary>
        public const string ct_Col_OrderCnt = "OrderCnt";
        /// <summary> 発注調整数 </summary>
        public const string ct_Col_OrderAdjustCnt = "OrderAdjustCnt";
        /// <summary> 発注残数 </summary>
        public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";
        /// <summary> 残数更新日 </summary>
        public const string ct_Col_RemainCntUpdDate = "RemainCntUpdDate";
        /// <summary> 仕入金額（税抜き） </summary>
        public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> 仕入金額（税込み） </summary>
        public const string ct_Col_StockPriceTaxInc = "StockPriceTaxInc";
        /// <summary> 仕入商品区分 </summary>
        public const string ct_Col_StockGoodsCd = "StockGoodsCd";
        /// <summary> 仕入金額消費税額 </summary>
        public const string ct_Col_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> 課税区分 </summary>
        public const string ct_Col_TaxationCode = "TaxationCode";
        /// <summary> 仕入伝票明細備考1 </summary>
        public const string ct_Col_StockDtiSlipNote1 = "StockDtiSlipNote1";
        /// <summary> 販売先コード </summary>
        public const string ct_Col_SalesCustomerCode = "SalesCustomerCode";
        /// <summary> 販売先略称 </summary>
        public const string ct_Col_SalesCustomerSnm = "SalesCustomerSnm";
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
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 納品先コード </summary>
        public const string ct_Col_AddresseeCode = "AddresseeCode";
        /// <summary> 納品先名称 </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> 直送区分 </summary>
        public const string ct_Col_DirectSendingCd = "DirectSendingCd";
        /// <summary> 発注番号 </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> 注文方法 </summary>
        public const string ct_Col_WayToOrder = "WayToOrder";
        /// <summary> 納品完了予定日 </summary>
        public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        /// <summary> 希望納期 </summary>
        public const string ct_Col_ExpectDeliveryDate = "ExpectDeliveryDate";
        /// <summary> 発注データ作成区分 </summary>
        public const string ct_Col_OrderDataCreateDiv = "OrderDataCreateDiv";
        /// <summary> 発注データ作成日 </summary>
        public const string ct_Col_OrderDataCreateDate = "OrderDataCreateDate";
        /// <summary> 発注書発行済区分 </summary>
        public const string ct_Col_OrderFormIssuedDiv = "OrderFormIssuedDiv";
        /// <summary> 仕入差分数 </summary>
        public const string ct_Col_StockCountDifference = "StockCountDifference";
        /// <summary> 明細関連付けGUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        #endregion

		#endregion

		#region Constructor
		/// <summary>
		/// 仕入明細テーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入明細テーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public StockDetailSchema()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2006.01.21</br>
		/// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
		{
			// テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(dataTableName)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
                ds.Tables[dataTableName].Clear();
			}
			else
			{
                CreateTable(ref ds, dataTableName);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// 仕入明細作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
		{
			DataTable dt = null;
			// スキーマ設定
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // 作成日時
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
            // 更新日時
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
            // 企業コード
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // 更新従業員コード
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // 更新アセンブリID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // 更新アセンブリID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // 論理削除区分
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // 受注番号
            dt.Columns.Add(ct_Col_AcceptAnOrderNo, typeof(Int32));
            dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defValueInt32;
            // 仕入形式
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // 仕入伝票番号
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // 仕入行番号
            dt.Columns.Add(ct_Col_StockRowNo, typeof(Int32));
            dt.Columns[ct_Col_StockRowNo].DefaultValue = defValueInt32;
            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // 部門コード
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // 共通通番
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // 仕入明細通番
            dt.Columns.Add(ct_Col_StockSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defValueInt64;
            // 仕入形式（元）
            dt.Columns.Add(ct_Col_SupplierFormalSrc, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormalSrc].DefaultValue = defValueInt32;
            // 仕入明細通番（元）
            dt.Columns.Add(ct_Col_StockSlipDtlNumSrc, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNumSrc].DefaultValue = defValueInt64;
            // 受注ステータス（同時）
            dt.Columns.Add(ct_Col_AcptAnOdrStatusSync, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatusSync].DefaultValue = defValueInt32;
            // 売上明細通番（同時）
            dt.Columns.Add(ct_Col_SalesSlipDtlNumSync, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNumSync].DefaultValue = defValueInt64;
            // 仕入伝票区分（明細）
            dt.Columns.Add(ct_Col_StockSlipCdDtl, typeof(Int32));
            dt.Columns[ct_Col_StockSlipCdDtl].DefaultValue = defValueInt32;
            // 仕入入力者コード
            dt.Columns.Add(ct_Col_StockInputCode, typeof(string));
            dt.Columns[ct_Col_StockInputCode].DefaultValue = defValuestring;
            // 仕入入力者名称
            dt.Columns.Add(ct_Col_StockInputName, typeof(string));
            dt.Columns[ct_Col_StockInputName].DefaultValue = defValuestring;
            // 仕入担当者コード
            dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));
            dt.Columns[ct_Col_StockAgentCode].DefaultValue = defValuestring;
            // 仕入担当者名称
            dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
            dt.Columns[ct_Col_StockAgentName].DefaultValue = defValuestring;
            // 商品属性
            dt.Columns.Add(ct_Col_GoodsKindCode, typeof(Int32));
            dt.Columns[ct_Col_GoodsKindCode].DefaultValue = defValueInt32;
            // 商品メーカーコード
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // メーカー名称
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // メーカーカナ名称
            dt.Columns.Add(ct_Col_MakerKanaName, typeof(string));
            dt.Columns[ct_Col_MakerKanaName].DefaultValue = defValuestring;
            // メーカーカナ名称（一式）
            dt.Columns.Add(ct_Col_CmpltMakerKanaName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerKanaName].DefaultValue = defValuestring;
            // 商品番号
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // 商品名称
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // 商品名称カナ
            dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
            dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defValuestring;
            // 商品大分類コード
            dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defValueInt32;
            // 商品大分類名称
            dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defValuestring;
            // 商品中分類コード
            dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defValueInt32;
            // 商品中分類名称
            dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defValuestring;
            // BLグループコード
            dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_BLGroupCode].DefaultValue = defValueInt32;
            // BLグループコード名称
            dt.Columns.Add(ct_Col_BLGroupName, typeof(string));
            dt.Columns[ct_Col_BLGroupName].DefaultValue = defValuestring;
            // BL商品コード
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;
            // BL商品コード名称（全角）
            dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
            dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defValuestring;
            // 自社分類コード
            dt.Columns.Add(ct_Col_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // 自社分類名称
            dt.Columns.Add(ct_Col_EnterpriseGanreName, typeof(string));
            dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = defValuestring;
            // 倉庫コード
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // 倉庫名称
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // 倉庫棚番
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // 仕入在庫取寄せ区分
            dt.Columns.Add(ct_Col_StockOrderDivCd, typeof(Int32));
            dt.Columns[ct_Col_StockOrderDivCd].DefaultValue = defValueInt32;
            // オープン価格区分
            dt.Columns.Add(ct_Col_OpenPriceDiv, typeof(Int32));
            dt.Columns[ct_Col_OpenPriceDiv].DefaultValue = defValueInt32;
            // 商品掛率ランク
            dt.Columns.Add(ct_Col_GoodsRateRank, typeof(string));
            dt.Columns[ct_Col_GoodsRateRank].DefaultValue = defValuestring;
            // 得意先掛率グループコード
            dt.Columns.Add(ct_Col_CustRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_CustRateGrpCode].DefaultValue = defValueInt32;
            // 仕入先掛率グループコード
            dt.Columns.Add(ct_Col_SuppRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_SuppRateGrpCode].DefaultValue = defValueInt32;
            // 定価（税抜，浮動）
            dt.Columns.Add(ct_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;
            // 定価（税込，浮動）
            dt.Columns.Add(ct_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;
            // 仕入率
            dt.Columns.Add(ct_Col_StockRate, typeof(Double));
            dt.Columns[ct_Col_StockRate].DefaultValue = defValueDouble;
            // 掛率設定拠点（仕入単価）
            dt.Columns.Add(ct_Col_RateSectStckUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectStckUnPrc].DefaultValue = defValuestring;
            // 掛率設定区分（仕入単価）
            dt.Columns.Add(ct_Col_RateDivStckUnPrc, typeof(string));
            dt.Columns[ct_Col_RateDivStckUnPrc].DefaultValue = defValuestring;
            // 単価算出区分（仕入単価）
            dt.Columns.Add(ct_Col_UnPrcCalcCdStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdStckUnPrc].DefaultValue = defValueInt32;
            // 価格区分（仕入単価）
            dt.Columns.Add(ct_Col_PriceCdStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_PriceCdStckUnPrc].DefaultValue = defValueInt32;
            // 基準単価（仕入単価）
            dt.Columns.Add(ct_Col_StdUnPrcStckUnPrc, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcStckUnPrc].DefaultValue = defValueDouble;
            // 端数処理単位（仕入単価）
            dt.Columns.Add(ct_Col_FracProcUnitStcUnPrc, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitStcUnPrc].DefaultValue = defValueDouble;
            // 端数処理（仕入単価）
            dt.Columns.Add(ct_Col_FracProcStckUnPrc, typeof(Int32));
            dt.Columns[ct_Col_FracProcStckUnPrc].DefaultValue = defValueInt32;
            // 仕入単価（税抜，浮動）
            dt.Columns.Add(ct_Col_StockUnitPriceFl, typeof(Double));
            dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defValueDouble;
            // 仕入単価（税込，浮動）
            dt.Columns.Add(ct_Col_StockUnitTaxPriceFl, typeof(Double));
            dt.Columns[ct_Col_StockUnitTaxPriceFl].DefaultValue = defValueDouble;
            // 仕入単価変更区分
            dt.Columns.Add(ct_Col_StockUnitChngDiv, typeof(Int32));
            dt.Columns[ct_Col_StockUnitChngDiv].DefaultValue = defValueInt32;
            // 変更前仕入単価（浮動）
            dt.Columns.Add(ct_Col_BfStockUnitPriceFl, typeof(Double));
            dt.Columns[ct_Col_BfStockUnitPriceFl].DefaultValue = defValueDouble;
            // 変更前定価
            dt.Columns.Add(ct_Col_BfListPrice, typeof(Double));
            dt.Columns[ct_Col_BfListPrice].DefaultValue = defValueDouble;
            // BL商品コード（掛率）
            dt.Columns.Add(ct_Col_RateBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGoodsCode].DefaultValue = defValueInt32;
            // BL商品コード名称（掛率）
            dt.Columns.Add(ct_Col_RateBLGoodsName, typeof(string));
            dt.Columns[ct_Col_RateBLGoodsName].DefaultValue = defValuestring;
            // 商品掛率グループコード（掛率）
            dt.Columns.Add(ct_Col_RateGoodsRateGrpCd, typeof(Int32));
            dt.Columns[ct_Col_RateGoodsRateGrpCd].DefaultValue = defValueInt32;
            // 商品掛率グループ名称（掛率）
            dt.Columns.Add(ct_Col_RateGoodsRateGrpNm, typeof(string));
            dt.Columns[ct_Col_RateGoodsRateGrpNm].DefaultValue = defValuestring;
            // BLグループコード（掛率）
            dt.Columns.Add(ct_Col_RateBLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGroupCode].DefaultValue = defValueInt32;
            // BLグループ名称（掛率）
            dt.Columns.Add(ct_Col_RateBLGroupName, typeof(string));
            dt.Columns[ct_Col_RateBLGroupName].DefaultValue = defValuestring;
            // 仕入数
            dt.Columns.Add(ct_Col_StockCount, typeof(Double));
            dt.Columns[ct_Col_StockCount].DefaultValue = defValueDouble;
            // 発注数量
            dt.Columns.Add(ct_Col_OrderCnt, typeof(Double));
            dt.Columns[ct_Col_OrderCnt].DefaultValue = defValueDouble;
            // 発注調整数
            dt.Columns.Add(ct_Col_OrderAdjustCnt, typeof(Double));
            dt.Columns[ct_Col_OrderAdjustCnt].DefaultValue = defValueDouble;
            // 発注残数
            dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double));
            dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = defValueDouble;
            // 残数更新日
            dt.Columns.Add(ct_Col_RemainCntUpdDate, typeof(DateTime));
            dt.Columns[ct_Col_RemainCntUpdDate].DefaultValue = DateTime.MinValue;
            // 仕入金額（税抜き）
            dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = defValueInt64;
            // 仕入金額（税込み）
            dt.Columns.Add(ct_Col_StockPriceTaxInc, typeof(Int64));
            dt.Columns[ct_Col_StockPriceTaxInc].DefaultValue = defValueInt64;
            // 仕入商品区分
            dt.Columns.Add(ct_Col_StockGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_StockGoodsCd].DefaultValue = defValueInt32;
            // 仕入金額消費税額
            dt.Columns.Add(ct_Col_StockPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_StockPriceConsTax].DefaultValue = defValueInt64;
            // 課税区分
            dt.Columns.Add(ct_Col_TaxationCode, typeof(Int32));
            dt.Columns[ct_Col_TaxationCode].DefaultValue = defValueInt32;
            // 仕入伝票明細備考1
            dt.Columns.Add(ct_Col_StockDtiSlipNote1, typeof(string));
            dt.Columns[ct_Col_StockDtiSlipNote1].DefaultValue = defValuestring;
            // 販売先コード
            dt.Columns.Add(ct_Col_SalesCustomerCode, typeof(Int32));
            dt.Columns[ct_Col_SalesCustomerCode].DefaultValue = defValueInt32;
            // 販売先略称
            dt.Columns.Add(ct_Col_SalesCustomerSnm, typeof(string));
            dt.Columns[ct_Col_SalesCustomerSnm].DefaultValue = defValuestring;
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
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // 納品先コード
            dt.Columns.Add(ct_Col_AddresseeCode, typeof(Int32));
            dt.Columns[ct_Col_AddresseeCode].DefaultValue = defValueInt32;
            // 納品先名称
            dt.Columns.Add(ct_Col_AddresseeName, typeof(string));
            dt.Columns[ct_Col_AddresseeName].DefaultValue = defValuestring;
            // 直送区分
            dt.Columns.Add(ct_Col_DirectSendingCd, typeof(Int32));
            dt.Columns[ct_Col_DirectSendingCd].DefaultValue = defValueInt32;
            // 発注番号
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // 注文方法
            dt.Columns.Add(ct_Col_WayToOrder, typeof(Int32));
            dt.Columns[ct_Col_WayToOrder].DefaultValue = defValueInt32;
            // 納品完了予定日
            dt.Columns.Add(ct_Col_DeliGdsCmpltDueDate, typeof(DateTime));
            dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = DateTime.MinValue;
            // 希望納期
            dt.Columns.Add(ct_Col_ExpectDeliveryDate, typeof(DateTime));
            dt.Columns[ct_Col_ExpectDeliveryDate].DefaultValue = DateTime.MinValue;
            // 発注データ作成区分
            dt.Columns.Add(ct_Col_OrderDataCreateDiv, typeof(Int32));
            dt.Columns[ct_Col_OrderDataCreateDiv].DefaultValue = defValueInt32;
            // 発注データ作成日
            dt.Columns.Add(ct_Col_OrderDataCreateDate, typeof(DateTime));
            dt.Columns[ct_Col_OrderDataCreateDate].DefaultValue = DateTime.MinValue;
            // 発注書発行済区分
            dt.Columns.Add(ct_Col_OrderFormIssuedDiv, typeof(Int32));
            dt.Columns[ct_Col_OrderFormIssuedDiv].DefaultValue = defValueInt32;
            // 仕入差分数
            dt.Columns.Add(ct_Col_StockCountDifference, typeof(Double));
            dt.Columns[ct_Col_StockCountDifference].DefaultValue = defValueDouble;
            // 明細関連付けGUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // PrimaryKeyの設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SupplierFormal], dt.Columns[ct_Col_StockSlipDtlNum] };
        }
		#endregion
	}
}