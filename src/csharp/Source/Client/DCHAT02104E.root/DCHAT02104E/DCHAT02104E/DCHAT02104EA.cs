using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 発注一覧表テーブルスキーマ定義クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 発注一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br>Note       : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/09/14</br>
	/// </remarks>
	public class DCHAT02104EA
	{
		#region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_OrderList = "Tbl_OrderList";

        ///// <summary> 赤伝区分 </summary>
        //public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";
        ///// <summary> 仕入伝票区分 </summary>
        //public const string ct_Col_SupplierSlipCd = "SupplierSlipCd";
        ///// <summary> 相手先伝票番号 </summary>
        //public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";
        ///// <summary> 発注書発行日 </summary>
        //public const string ct_Col_OrderFormPrintDate = "OrderFormPrintDate";
        ///// <summary> 受注番号 </summary>
        //public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        ///// <summary> 仕入形式 </summary>
        //public const string ct_Col_SupplierFormal = "SupplierFormal";
        ///// <summary> 仕入伝票番号 </summary>
        //public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        ///// <summary> 仕入行番号 </summary>
        //public const string ct_Col_StockRowNo = "StockRowNo";
        ///// <summary> 拠点コード </summary>
        //public const string ct_Col_SectionCode = "SectionCode";
        ///// <summary> 仕入担当者コード </summary>
        //public const string ct_Col_StockAgentCode = "StockAgentCode";
        ///// <summary> 仕入担当者名称 </summary>
        //public const string ct_Col_StockAgentName = "StockAgentName";
        ///// <summary> 仕入入力者コード </summary>
        //public const string ct_Col_StockInputCode = "StockInputCode";
        ///// <summary> 仕入入力者名称 </summary>
        //public const string ct_Col_StockInputName = "StockInputName";
        ///// <summary> 商品メーカーコード </summary>
        //public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        ///// <summary> メーカー名称 </summary>
        //public const string ct_Col_MakerName = "MakerName";
        ///// <summary> 商品番号 </summary>
        //public const string ct_Col_GoodsNo = "GoodsNo";
        ///// <summary> 商品名称 </summary>
        //public const string ct_Col_GoodsName = "GoodsName";
        ///// <summary> 倉庫コード </summary>
        //public const string ct_Col_WarehouseCode = "WarehouseCode";
        ///// <summary> 倉庫名称 </summary>
        //public const string ct_Col_WarehouseName = "WarehouseName";
        ///// <summary> 仕入在庫取寄せ区分 </summary>
        //public const string ct_Col_StockOrderDivCd = "StockOrderDivCd";
        ///// <summary> 単位コード </summary>
        //public const string ct_Col_UnitCode = "UnitCode";
        ///// <summary> 単位名称 </summary>
        //public const string ct_Col_UnitName = "UnitName";
        ///// <summary> 仕入単価（税抜，浮動） </summary>
        //public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        ///// <summary> 仕入単価（税込，浮動） </summary>
        //public const string ct_Col_StockUnitTaxPriceFl = "StockUnitTaxPriceFl";
        ///// <summary> 特売区分コード </summary>
        //public const string ct_Col_BargainCd = "BargainCd";
        ///// <summary> 特売区分名称 </summary>
        //public const string ct_Col_BargainNm = "BargainNm";
        ///// <summary> 仕入数 </summary>
        //public const string ct_Col_StockCount = "StockCount";
        ///// <summary> 仕入金額（税抜き） </summary>
        //public const string ct_Col_StockPriceTaxExc = "StockPriceTaxExc";
        ///// <summary> 仕入金額（税込み） </summary>
        //public const string ct_Col_StockPriceTaxInc = "StockPriceTaxInc";
        ///// <summary> 仕入伝票明細備考1 </summary>
        //public const string ct_Col_StockDtiSlipNote1 = "StockDtiSlipNote1";
        ///// <summary> 販売先コード </summary>
        //public const string ct_Col_SalesCustomerCode = "SalesCustomerCode";
        ///// <summary> 販売先略称 </summary>
        //public const string ct_Col_SalesCustomerSnm = "SalesCustomerSnm";
        ///// <summary> 仕入先コード </summary>
        //public const string ct_Col_SupplierCd = "SupplierCd";
        ///// <summary> 仕入先略称 </summary>
        //public const string ct_Col_SupplierSnm = "SupplierSnm";
        ///// <summary> 納品先コード </summary>
        //public const string ct_Col_AddresseeCode = "AddresseeCode";
        ///// <summary> 納品先名称 </summary>
        //public const string ct_Col_AddresseeName = "AddresseeName";
        ///// <summary> 残数更新日 </summary>
        //public const string ct_Col_RemainCntUpdDate = "RemainCntUpdDate";
        ///// <summary> 直送区分 </summary>
        //public const string ct_Col_DirectSendingCd = "DirectSendingCd";
        ///// <summary> 発注番号 </summary>
        //public const string ct_Col_OrderNumber = "OrderNumber";
        ///// <summary> 注文方法 </summary>
        //public const string ct_Col_WayToOrder = "WayToOrder";
        ///// <summary> 納品完了予定日 </summary>
        //public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        ///// <summary> 希望納期 </summary>
        //public const string ct_Col_ExpectDeliveryDate = "ExpectDeliveryDate";
        ///// <summary> 発注数量 </summary>
        //public const string ct_Col_OrderCnt = "OrderCnt";
        ///// <summary> 発注調整数 </summary>
        //public const string ct_Col_OrderAdjustCnt = "OrderAdjustCnt";
        ///// <summary> 発注残数 </summary>
        //public const string ct_Col_OrderRemainCnt = "OrderRemainCnt";
        ///// <summary> 消込フラグ </summary>
        //public const string ct_Col_ReconcileFlag = "ReconcileFlag";
        ///// <summary> 発注書発行済区分 </summary>
        //public const string ct_Col_OrderFormIssuedDiv = "OrderFormIssuedDiv";
        ///// <summary> 発注データ作成日 </summary>
        //public const string ct_Col_OrderDataCreateDate = "OrderDataCreateDate";
        ///// <summary> 伝票メモ１ </summary>
        //public const string ct_Col_SlipMemo1 = "SlipMemo1";
        ///// <summary> 伝票メモ２ </summary>
        //public const string ct_Col_SlipMemo2 = "SlipMemo2";
        ///// <summary> 伝票メモ３ </summary>
        //public const string ct_Col_SlipMemo3 = "SlipMemo3";
        ///// <summary> 伝票メモ４ </summary>
        //public const string ct_Col_SlipMemo4 = "SlipMemo4";
        ///// <summary> 伝票メモ５ </summary>
        //public const string ct_Col_SlipMemo5 = "SlipMemo5";
        ///// <summary> 伝票メモ６ </summary>
        //public const string ct_Col_SlipMemo6 = "SlipMemo6";
        ///// <summary> 社内メモ１ </summary>
        //public const string ct_Col_InsideMemo1 = "InsideMemo1";
        ///// <summary> 社内メモ２ </summary>
        //public const string ct_Col_InsideMemo2 = "InsideMemo2";
        ///// <summary> 社内メモ３ </summary>
        //public const string ct_Col_InsideMemo3 = "InsideMemo3";
        ///// <summary> 社内メモ４ </summary>
        //public const string ct_Col_InsideMemo4 = "InsideMemo4";
        ///// <summary> 社内メモ５ </summary>
        //public const string ct_Col_InsideMemo5 = "InsideMemo5";
        ///// <summary> 社内メモ６ </summary>
        //public const string ct_Col_InsideMemo6 = "InsideMemo6";
        ///// <summary> 仕入明細通番 </summary>
        //public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";

        /// <summary> 処理日 </summary>
        public const string ct_Col_ProcessDay = "ProcessDay";

        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";

        /// <summary> 拠点ガイド略称 </summary>
        public const string ct_Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";

        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";

        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";

        /// <summary> 仕入在庫数 </summary>
        public const string ct_Col_SupplierStock = "SupplierStock";

        /// <summary> 受注数 </summary>
        public const string ct_Col_AcpOdrCount = "AcpOdrCount";

        /// <summary> 発注数(発注残) </summary>
        public const string ct_Col_SalesOrderCount = "SalesOrderCount";

        /// <summary> 在庫区分 </summary>
        public const string ct_Col_StockDiv = "StockDiv";

        /// <summary> 移動中仕入在庫数 </summary>
        public const string ct_Col_MovingSupliStock = "MovingSupliStock";

        /// <summary> 出荷可能数 </summary>
        public const string ct_Col_ShipmentPosCnt = "ShipmentPosCnt";

        /// <summary> 最低在庫数 </summary>
        public const string ct_Col_MinimumStockCnt = "MinimumStockCnt";

        /// <summary> 最高在庫数 </summary>
        public const string ct_Col_MaximumStockCnt = "MaximumStockCnt";

        /// <summary> 発注単位 </summary>
        public const string ct_Col_SalesOrderUnit = "SalesOrderUnit";

        /// <summary> 在庫発注先コード </summary>
        public const string ct_Col_StockSupplierCode = "StockSupplierCode";

        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";

        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 重複棚番１ </summary>
        public const string ct_Col_DuplicationShelfNo1 = "DuplicationShelfNo1";

        /// <summary> 重複棚番２ </summary>
        public const string ct_Col_DuplicationShelfNo2 = "DuplicationShelfNo2";

        /// <summary> 出荷数（未計上） </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> 入荷数（未計上） </summary>
        public const string ct_Col_ArrivalCnt = "ArrivalCnt";

        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";

        /// <summary> 発注ロット </summary>
        public const string ct_Col_SupplierLot = "SupplierLot";

        /// <summary> 自動発注数 </summary>
        public const string ct_Col_AutoOrderCount = "AutoOrderCount";

        /// <summary> 自社名称１ </summary>
        public const string ct_Col_EnterpriseName1 = "EnterpriseName1";

        /// <summary> 自社名称２ </summary>
        public const string ct_Col_EnterpriseName2 = "EnterpriseName2";

        /// <summary> 自社電話番号 </summary>
        public const string ct_Col_EnterpriseTel = "EnterpriseTel";

        /// <summary> 自社FAX番号 </summary>
        public const string ct_Col_EnterpriseFax = "EnterpriseFax";

        /// <summary> 仕入先コード(印字用) </summary>
        public const string ct_Col_SupplierCodePrint = "SupplierCodePrint";

        /// <summary> 仕入先名称 </summary>
        public const string ct_Col_SupplierName = "SupplierName";

        /// <summary> 受注数(ロット計算後) </summary>
        public const string ct_Col_SalesOrderCountLotCalc = "SalesOrderCountLotCalc";

        /// <summary> UOE発注分区分 </summary>
        public const string ct_Col_UOEOrderDiv = "UOEOrderDiv";

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary> 仕入SEQ番号(バーコード化用) </summary>
        public const string ct_Col_SupplierSeqNoForBarCode = "SupplierSeqNoForBarCode";
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        // 改頁用
        /// <summary> 拠点+倉庫(改頁用) </summary>
        public const string ctCol_SectionWareHouse = "SectionWareHouse";

        ///// <summary> 印刷用　拠点ガイド名称 </summary>
        //public const string ct_Col_SectionGuideNm = "SectionGuideNm";
        ///// <summary> 印刷用　発注金額 </summary>
        //public const string ct_Col_OrderPrice = "OrderPrice";
        ///// <summary> 印刷用　発注残金額 </summary>
        //public const string ct_Col_OrderRemainPrice = "OrderRemainPrice";
        ///// <summary> 印刷用　赤伝区分名称 </summary>
        //public const string ct_Col_DebitNoteDivNm = "DebitNoteDivNm";
        ///// <summary> 印刷用　仕入伝票区分名称 </summary>
        //public const string ct_Col_SupplierSlipCdNm = "SupplierSlipCdNm";
        ///// <summary> 印刷用　仕入在庫取寄せ区分</summary>
        //public const string ct_Col_StockOrderDivNm = "StockOrderDivNm";
        ///// <summary> 印刷用　発注書発行済み区分</summary>
        //public const string ct_Col_OrderFormIssuedDivNm = "OrderFormIssuedDivNm";
        ///// <summary> 印刷用　発注数（発注数＋発注調整数） </summary>
        //public const string ct_Col_OrderAndAdjustCnt = "OrderAndAdjustCnt";

        ///// <summary> ソート用　拠点コード </summary>
        //public const string ct_Col_Sort_SectionCode = "Sort_SectionCode";
        ///// <summary> ソート用　発注書発行日 </summary>
        //public const string ct_Col_Sort_OrderFormPrintDate = "Sort_OrderFormPrintDate";
        ///// <summary> ソート用　商品メーカーコード </summary>
        //public const string ct_Col_Sort_GoodsMakerCd = "Sort_GoodsMakerCd";
        ///// <summary> ソート用　商品番号 </summary>
        //public const string ct_Col_Sort_GoodsNo = "Sort_GoodsNo";
        ///// <summary> ソート用　仕入先コード </summary>
        //public const string ct_Col_Sort_SupplierCd = "Sort_SupplierCd";
        ///// <summary> ソート用　入力日 </summary>
        //public const string ct_Col_Sort_OrderDataCreateDate = "Sort_OrderDataCreateDate";
        ///// <summary> ソート用　希望納期 </summary>
        //public const string ct_Col_Sort_ExpectDeliveryDate = "Sort_ExpectDeliveryDate";
        ///// <summary> ソート用　仕入伝票番号 </summary>
        //public const string ct_Col_Sort_SupplierSlipNo = "Sort_SupplierSlipNo";
        ///// <summary> ソート用　仕入行番号 </summary>
        //public const string ct_Col_Sort_StockRowNo = "Sort_StockRowNo";
        ///// <summary> ソート用　仕入明細通番 </summary>
        //public const string ct_Col_Sort_StockSlipDtlNum = "Sort_StockSlipDtlNum";

        #endregion ■ Public Const

		#region ■ Constructor
		/// <summary>
		/// 発注一覧表テーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCHAT02104EA()
		{
		}
		#endregion

		#region ■ Static Public Method
		#region ◆ DataSetテーブルスキーマ設定
		/// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="dt">設定対象データテーブル</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		static public void CreateDataTable(ref DataTable dt)
		{
            string defValuestring = "";
            Int32 defValueInt32 = 0;
            double defValueDouble = 0.0;

			// テーブルが存在するかどうかのチェック
			if ( dt != null )
			{
				// テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
				dt.Clear();
			}
			else
			{
                // スキーマ設定
                dt = new DataTable(ct_Tbl_OrderList);

                #region << Column 追加 >>

                //dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32)); // 赤伝区分
                //dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(Int32)); // 仕入伝票区分
                //dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string)); // 相手先伝票番号
                //dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_OrderFormPrintDate, typeof(string)); // 発注書発行日
                //dt.Columns[ct_Col_OrderFormPrintDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_AcceptAnOrderNo, typeof(Int32)); // 受注番号
                //dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32)); // 仕入形式
                //dt.Columns[ct_Col_SupplierFormal].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32)); // 仕入伝票番号
                //dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_StockRowNo, typeof(Int32)); // 仕入行番号
                //dt.Columns[ct_Col_StockRowNo].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SectionCode, typeof(string)); // 拠点コード
                //dt.Columns[ct_Col_SectionCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockAgentCode, typeof(string)); // 仕入担当者コード
                //dt.Columns[ct_Col_StockAgentCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockAgentName, typeof(string)); // 仕入担当者名称
                //dt.Columns[ct_Col_StockAgentName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockInputCode, typeof(string)); // 仕入入力者コード
                //dt.Columns[ct_Col_StockInputCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockInputName, typeof(string)); // 仕入入力者名称
                //dt.Columns[ct_Col_StockInputName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32)); // 商品メーカーコード
                //dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_MakerName, typeof(string)); // メーカー名称
                //dt.Columns[ct_Col_MakerName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_GoodsNo, typeof(string)); // 商品番号
                //dt.Columns[ct_Col_GoodsNo].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_GoodsName, typeof(string)); // 商品名称
                //dt.Columns[ct_Col_GoodsName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_WarehouseCode, typeof(string)); // 倉庫コード
                //dt.Columns[ct_Col_WarehouseCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_WarehouseName, typeof(string)); // 倉庫名称
                //dt.Columns[ct_Col_WarehouseName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockOrderDivCd, typeof(Int32)); // 仕入在庫取寄せ区分
                //dt.Columns[ct_Col_StockOrderDivCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_UnitCode, typeof(Int32)); // 単位コード
                //dt.Columns[ct_Col_UnitCode].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_UnitName, typeof(string)); // 単位名称
                //dt.Columns[ct_Col_UnitName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockUnitPriceFl, typeof(Double)); // 仕入単価（税抜，浮動）
                //dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_StockUnitTaxPriceFl, typeof(Double)); // 仕入単価（税込，浮動）
                //dt.Columns[ct_Col_StockUnitTaxPriceFl].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_BargainCd, typeof(Int32)); // 特売区分コード
                //dt.Columns[ct_Col_BargainCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_BargainNm, typeof(string)); // 特売区分名称
                //dt.Columns[ct_Col_BargainNm].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockCount, typeof(Double)); // 仕入数
                //dt.Columns[ct_Col_StockCount].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_StockPriceTaxExc, typeof(Int64)); // 仕入金額（税抜き）
                //dt.Columns[ct_Col_StockPriceTaxExc].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_StockPriceTaxInc, typeof(Int64)); // 仕入金額（税込み）
                //dt.Columns[ct_Col_StockPriceTaxInc].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_StockDtiSlipNote1, typeof(string)); // 仕入伝票明細備考1
                //dt.Columns[ct_Col_StockDtiSlipNote1].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SalesCustomerCode, typeof(Int32)); // 販売先コード
                //dt.Columns[ct_Col_SalesCustomerCode].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SalesCustomerSnm, typeof(string)); // 販売先略称
                //dt.Columns[ct_Col_SalesCustomerSnm].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32)); // 仕入先コード
                //dt.Columns[ct_Col_SupplierCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_SupplierSnm, typeof(string)); // 仕入先略称
                //dt.Columns[ct_Col_SupplierSnm].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_AddresseeCode, typeof(Int32)); // 納品先コード
                //dt.Columns[ct_Col_AddresseeCode].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_AddresseeName, typeof(string)); // 納品先名称
                //dt.Columns[ct_Col_AddresseeName].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_RemainCntUpdDate, typeof(string)); // 残数更新日               
                //dt.Columns[ct_Col_RemainCntUpdDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_DirectSendingCd, typeof(Int32)); // 直送区分
                //dt.Columns[ct_Col_DirectSendingCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderNumber, typeof(string)); // 発注番号
                //dt.Columns[ct_Col_OrderNumber].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_WayToOrder, typeof(Int32)); // 注文方法
                //dt.Columns[ct_Col_WayToOrder].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_DeliGdsCmpltDueDate, typeof(string)); // 納品完了予定日
                //dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_ExpectDeliveryDate, typeof(string)); // 希望納期
                //dt.Columns[ct_Col_ExpectDeliveryDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_OrderCnt, typeof(Double)); // 発注数量
                //dt.Columns[ct_Col_OrderCnt].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderAdjustCnt, typeof(Double)); // 発注調整数
                //dt.Columns[ct_Col_OrderAdjustCnt].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderRemainCnt, typeof(Double)); // 発注残数
                //dt.Columns[ct_Col_OrderRemainCnt].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_ReconcileFlag, typeof(Int32)); // 消込フラグ
                //dt.Columns[ct_Col_ReconcileFlag].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderFormIssuedDiv, typeof(Int32)); // 発注書発行済区分
                //dt.Columns[ct_Col_OrderFormIssuedDiv].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderDataCreateDate, typeof(string)); // 発注データ作成日
                //dt.Columns[ct_Col_OrderDataCreateDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo1, typeof(string)); // 伝票メモ１
                //dt.Columns[ct_Col_SlipMemo1].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo2, typeof(string)); // 伝票メモ２
                //dt.Columns[ct_Col_SlipMemo2].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo3, typeof(string)); // 伝票メモ３
                //dt.Columns[ct_Col_SlipMemo3].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo4, typeof(string)); // 伝票メモ４
                //dt.Columns[ct_Col_SlipMemo4].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo5, typeof(string)); // 伝票メモ５
                //dt.Columns[ct_Col_SlipMemo5].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SlipMemo6, typeof(string)); // 伝票メモ６
                //dt.Columns[ct_Col_SlipMemo6].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo1, typeof(string)); // 社内メモ１
                //dt.Columns[ct_Col_InsideMemo1].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo2, typeof(string)); // 社内メモ２
                //dt.Columns[ct_Col_InsideMemo2].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo3, typeof(string)); // 社内メモ３
                //dt.Columns[ct_Col_InsideMemo3].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo4, typeof(string)); // 社内メモ４
                //dt.Columns[ct_Col_InsideMemo4].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo5, typeof(string)); // 社内メモ５
                //dt.Columns[ct_Col_InsideMemo5].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_InsideMemo6, typeof(string)); // 社内メモ６
                //dt.Columns[ct_Col_InsideMemo6].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_StockSlipDtlNum, typeof(Int64)); // 仕入明細通番
                //dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = 0;


                //dt.Columns.Add(ct_Col_SectionGuideNm, typeof(string)); // 拠点ガイド名称
                //dt.Columns[ct_Col_SectionGuideNm].DefaultValue = "";

                //dt.Columns.Add(ct_Col_OrderPrice, typeof(Int64)); // 発注金額
                //dt.Columns[ct_Col_OrderPrice].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_OrderRemainPrice, typeof(Int64)); // 発注残金額
                //dt.Columns[ct_Col_OrderRemainPrice].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_DebitNoteDivNm, typeof(string)); // 赤伝区分名称
                //dt.Columns[ct_Col_DebitNoteDivNm].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_SupplierSlipCdNm, typeof(string)); // 仕入伝票区分名称
                //dt.Columns[ct_Col_SupplierSlipCdNm].DefaultValue = "";

                //dt.Columns.Add(ct_Col_OrderAndAdjustCnt, typeof(Double)); // 印刷用　発注数（発注数＋発注調整数）
                //dt.Columns[ct_Col_OrderAndAdjustCnt].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_StockOrderDivNm, typeof(string)); // 印刷用　仕入在庫取寄せ区分
                //dt.Columns[ct_Col_StockOrderDivNm].DefaultValue = "";

                //dt.Columns.Add(ct_Col_OrderFormIssuedDivNm, typeof(string)); // 印刷用　発注書発行済み区分
                //dt.Columns[ct_Col_OrderFormIssuedDivNm].DefaultValue = "";



                //dt.Columns.Add(ct_Col_Sort_OrderFormPrintDate, typeof(string)); // 発注書発行日（ソート用）
                //dt.Columns[ct_Col_Sort_OrderFormPrintDate].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_SectionCode, typeof(string)); // 拠点コード（ソート用）
                //dt.Columns[ct_Col_Sort_SectionCode].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_GoodsMakerCd, typeof(Int32)); // 商品メーカーコード（ソート用）
                //dt.Columns[ct_Col_Sort_GoodsMakerCd].DefaultValue = 0;
                
                //dt.Columns.Add(ct_Col_Sort_GoodsNo, typeof(string)); // 商品番号（ソート用）
                //dt.Columns[ct_Col_Sort_GoodsNo].DefaultValue = "";
                
                //dt.Columns.Add(ct_Col_Sort_SupplierCd, typeof(Int32)); // 仕入先コード（ソート用）
                //dt.Columns[ct_Col_Sort_SupplierCd].DefaultValue = 0;

                //dt.Columns.Add(ct_Col_Sort_OrderDataCreateDate, typeof(string)); // 入力日（ソート用）
                //dt.Columns[ct_Col_Sort_OrderDataCreateDate].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_ExpectDeliveryDate, typeof(string)); // 希望納期（ソート用）
                //dt.Columns[ct_Col_Sort_ExpectDeliveryDate].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_SupplierSlipNo, typeof(string)); // 仕入伝票番号（ソート用）
                //dt.Columns[ct_Col_Sort_SupplierSlipNo].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_StockRowNo, typeof(string)); // 仕入行番号（ソート用）
                //dt.Columns[ct_Col_Sort_StockRowNo].DefaultValue = "";

                //dt.Columns.Add(ct_Col_Sort_StockSlipDtlNum, typeof(Int64)); // 仕入明細通番
                //dt.Columns[ct_Col_Sort_StockSlipDtlNum].DefaultValue = 0;

                // 処理日
                dt.Columns.Add(ct_Col_ProcessDay, typeof(string));
                dt.Columns[ct_Col_ProcessDay].DefaultValue = defValuestring;

                // 拠点コード
                dt.Columns.Add(ct_Col_SectionCode, typeof(string));
                dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;

                // 拠点ガイド略称
                dt.Columns.Add(ct_Col_SectionGuideSnm, typeof(string));
                dt.Columns[ct_Col_SectionGuideSnm].DefaultValue = defValuestring;

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

                // 仕入在庫数
                dt.Columns.Add(ct_Col_SupplierStock, typeof(Double));
                dt.Columns[ct_Col_SupplierStock].DefaultValue = defValueDouble;

                // 受注数
                dt.Columns.Add(ct_Col_AcpOdrCount, typeof(Double));
                dt.Columns[ct_Col_AcpOdrCount].DefaultValue = defValueDouble;

                // 発注数(発注残)
                dt.Columns.Add(ct_Col_SalesOrderCount, typeof(Double));
                dt.Columns[ct_Col_SalesOrderCount].DefaultValue = defValueDouble;

                // 在庫区分
                dt.Columns.Add(ct_Col_StockDiv, typeof(Int32));
                dt.Columns[ct_Col_StockDiv].DefaultValue = defValueInt32;

                // 移動中仕入在庫数
                dt.Columns.Add(ct_Col_MovingSupliStock, typeof(Double));
                dt.Columns[ct_Col_MovingSupliStock].DefaultValue = defValueDouble;

                // 出荷可能数
                dt.Columns.Add(ct_Col_ShipmentPosCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentPosCnt].DefaultValue = defValueDouble;

                // 最低在庫数
                dt.Columns.Add(ct_Col_MinimumStockCnt, typeof(Double));
                dt.Columns[ct_Col_MinimumStockCnt].DefaultValue = defValueDouble;

                // 最高在庫数
                dt.Columns.Add(ct_Col_MaximumStockCnt, typeof(Double));
                dt.Columns[ct_Col_MaximumStockCnt].DefaultValue = defValueDouble;

                // 発注単位
                dt.Columns.Add(ct_Col_SalesOrderUnit, typeof(Int32));
                dt.Columns[ct_Col_SalesOrderUnit].DefaultValue = defValueInt32;

                // 在庫発注先コード
                dt.Columns.Add(ct_Col_StockSupplierCode, typeof(Int32));
                dt.Columns[ct_Col_StockSupplierCode].DefaultValue = defValueInt32;

                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;

                // 倉庫名称
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;

                // 倉庫棚番
                dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
                dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;

                // 重複棚番１
                dt.Columns.Add(ct_Col_DuplicationShelfNo1, typeof(string));
                dt.Columns[ct_Col_DuplicationShelfNo1].DefaultValue = defValuestring;

                // 重複棚番２
                dt.Columns.Add(ct_Col_DuplicationShelfNo2, typeof(string));
                dt.Columns[ct_Col_DuplicationShelfNo2].DefaultValue = defValuestring;

                // 出荷数（未計上）
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;

                // 入荷数（未計上）
                dt.Columns.Add(ct_Col_ArrivalCnt, typeof(Double));
                dt.Columns[ct_Col_ArrivalCnt].DefaultValue = defValueDouble;

                // 仕入先コード
                dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;

                // 発注ロット
                dt.Columns.Add(ct_Col_SupplierLot, typeof(Int32));
                dt.Columns[ct_Col_SupplierLot].DefaultValue = defValueInt32;

                // 自動発注数
                dt.Columns.Add(ct_Col_AutoOrderCount, typeof(Double));
                dt.Columns[ct_Col_AutoOrderCount].DefaultValue = defValueDouble;

                // 自社名称１
                dt.Columns.Add(ct_Col_EnterpriseName1, typeof(string));
                dt.Columns[ct_Col_EnterpriseName1].DefaultValue = defValuestring;

                // 自社名称２
                dt.Columns.Add(ct_Col_EnterpriseName2, typeof(string));
                dt.Columns[ct_Col_EnterpriseName2].DefaultValue = defValuestring;

                // 自社電話番号
                dt.Columns.Add(ct_Col_EnterpriseTel, typeof(string));
                dt.Columns[ct_Col_EnterpriseTel].DefaultValue = defValuestring;

                // 自社FAX番号
                dt.Columns.Add(ct_Col_EnterpriseFax, typeof(string));
                dt.Columns[ct_Col_EnterpriseFax].DefaultValue = defValuestring;

                // 仕入先コード(印字用)
                dt.Columns.Add(ct_Col_SupplierCodePrint, typeof(string));
                dt.Columns[ct_Col_SupplierCodePrint].DefaultValue = defValuestring;

                // 仕入先名称
                dt.Columns.Add(ct_Col_SupplierName, typeof(string));
                dt.Columns[ct_Col_SupplierName].DefaultValue = defValuestring;

                // 2009.01.07 30413 犬飼 浮動小数に修正 >>>>>>START
                // 受注数(ロット計算後)
                //dt.Columns.Add(ct_Col_SalesOrderCountLotCalc, typeof(Int32));
                //dt.Columns[ct_Col_SalesOrderCountLotCalc].DefaultValue = defValueInt32;
                dt.Columns.Add(ct_Col_SalesOrderCountLotCalc, typeof(Double));
                dt.Columns[ct_Col_SalesOrderCountLotCalc].DefaultValue = defValueDouble;
                // 2009.01.07 30413 犬飼 浮動小数に修正 <<<<<<END
                
                // UOE発注区分
                dt.Columns.Add(ct_Col_UOEOrderDiv, typeof(Int32));
                dt.Columns[ct_Col_UOEOrderDiv].DefaultValue = defValueInt32;

                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
                dt.Columns.Add(ct_Col_SupplierSeqNoForBarCode, typeof(string)); // 仕入伝票番号
                dt.Columns[ct_Col_SupplierSeqNoForBarCode].DefaultValue = defValuestring;
                // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

                #endregion << Column 追加 >>

                // 改頁用
                dt.Columns.Add(ctCol_SectionWareHouse, typeof(string));
                dt.Columns[ctCol_SectionWareHouse].DefaultValue = defValuestring;
            }
		}
		#endregion
		#endregion
	}
}
