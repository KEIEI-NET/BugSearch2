using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 受注残照会テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注残照会テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           : </br>
    /// </remarks>
    public class DCJUT04102AC
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_AcptAnOdrRemainRef = "Tbl_AcptAnOdrRemainRef";

        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> 受注日 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 通算行番号 </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> 売上明細通番 </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 品番 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> 品名 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 担当者 </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> 発行者 </summary>
        public const string ct_Col_SalesInputNm = "SalesInputNm";
        /// <summary> 受注者 </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> 納品先名称 </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> 納品先名称2 </summary>
        public const string ct_Col_AddresseeName2 = "AddresseeName2";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 受注残数 </summary>
        public const string ct_Col_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> 原価単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> 明細備考 </summary>
        public const string ct_Col_DtlNote = "DtlNote";
        


        /// <summary> 受注ステータス </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> 受注番号 </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        ///// <summary> 単位名称 </summary>
        //public const string ct_Col_UnitName = "UnitName";
        ///// <summary> 特売区分名称 </summary>
        //public const string ct_Col_BargainNm = "BargainNm";
        /// <summary> 相手先伝票番号（明細） </summary>
        public const string ct_Col_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary> 基準単価（売上単価） </summary>
        public const string ct_Col_StdUnPrcSalUnPrc = "StdUnPrcSalUnPrc";
        ///// <summary> 客先納期 </summary>
        //public const string ct_Col_CustomerDeliveryDate = "CustomerDeliveryDate";
        /// <summary> 伝票メモ１ </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> 伝票メモ２ </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> 伝票メモ３ </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        ///// <summary> 伝票メモ４ </summary>
        //public const string ct_Col_SlipMemo4 = "SlipMemo4";
        ///// <summary> 伝票メモ５ </summary>
        //public const string ct_Col_SlipMemo5 = "SlipMemo5";
        ///// <summary> 伝票メモ６ </summary>
        //public const string ct_Col_SlipMemo6 = "SlipMemo6";
        /// <summary> 社内メモ１ </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> 社内メモ２ </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> 社内メモ３ </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        ///// <summary> 社内メモ４ </summary>
        //public const string ct_Col_InsideMemo4 = "InsideMemo4";
        ///// <summary> 社内メモ５ </summary>
        //public const string ct_Col_InsideMemo5 = "InsideMemo5";
        ///// <summary> 社内メモ６ </summary>
        //public const string ct_Col_InsideMemo6 = "InsideMemo6";
        ///// <summary> 仕入形式 </summary>
        //public const string ct_Col_SupplierFormal = "SupplierFormal";
        ///// <summary> 仕入明細通番 </summary>
        //public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        ///// <summary> 発注番号 </summary>
        //public const string ct_Col_OrderNumber = "OrderNumber";
        ///// <summary> 希望納期 </summary>
        //public const string ct_Col_ExpectDeliveryDate = "ExpectDeliveryDate";
        ///// <summary> 納品完了予定日 </summary>
        //public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        ///// <summary> 入荷日 </summary>
        //public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        ///// <summary> 仕入数 </summary>
        //public const string ct_Col_StockCount = "StockCount";
        ///// <summary> 仕入単価（税抜，浮動） </summary>
        //public const string ct_Col_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 行№ </summary>
        public const string ct_Col_RowNoView = "RowNoView";
        // [9095]
        /// <summary> 行№ 表示用 </summary>
        public const string ct_Col_RowNoDisplay = "RowNoDisplay";
        // [9095]
        /// <summary> 行選択フラグ </summary>
        public const string ct_Col_SelectRowFlag = "SelectRowFlag";
        ///// <summary> 受注残金額 </summary>
        //public const string ct_Col_AcptAnOdrRemainPrice = "AcptAnOdrRemainPrice";
        /// <summary> メモマーク </summary>
        public const string ct_Col_MemoExistsMark = "MemoExistsMark";
        /// <summary> メモ有フラグ </summary>
        public const string ct_Col_MemoExistsFlag = "MemoExistsFlag";
        /// <summary> 売上日付（表示用） </summary>
        public const string ct_Col_SalesDateView = "SalesDateView";
        ///// <summary> 客先納期（表示用） </summary>
        //public const string ct_Col_CustomerDeliveryDateView = "CustomerDeliveryDateView";
        ///// <summary> 希望納期（表示用） </summary>
        //public const string ct_Col_ExpectDeliveryDateView = "ExpectDeliveryDateView";
        ///// <summary> 納品完了予定日（表示用） </summary>
        //public const string ct_Col_DeliGdsCmpltDueDateView = "DeliGdsCmpltDueDateView";
        ///// <summary> 入荷日（表示用） </summary>
        //public const string ct_Col_ArrivalGoodsDayView = "ArrivalGoodsDayView";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
        /// <summary> 売上伝票区分（明細） </summary>
        public const string ct_Col_SalesSlipCdDtl = "SalesSlipCdDtl";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> BL商品コード </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> 定価（税抜、浮動） </summary>
        public const string ct_Col_ListPriceTaxExc = "ListPriceTaxExc";
        /// <summary> 受注金額（計算） </summary>
        public const string ct_Col_SalesPriceTotal = "SalesPriceTotal";
        /// <summary> 消費税 </summary>
        public const string ct_Col_SalesPriceConsTax = "SalesPriceConsTax";
        /// <summary> 原価金額 </summary>
        public const string ct_Col_SalesTotalCost = "SalesTotalCost";
        /// <summary> 車両管理コード </summary>
        public const string ct_Col_CarMngCode = "CarMngCode";
        /// <summary> 型式指定番号 </summary>
        public const string ct_Col_ModelDesignationNo = "ModelDesignationNo";
        /// <summary> 類別番号 </summary>
        public const string ct_Col_CategoryNo = "CategoryNo";
        /// <summary> 類別型式 </summary>
        public const string ct_Col_ModelCategory = "ModelCategory";
        /// <summary> 車種全角名称 </summary>
        public const string ct_Col_ModelFullName = "ModelFullName";
        /// <summary> 型式（フル型） </summary>
        public const string ct_Col_FullModel = "FullModel";
        /// <summary> 倉庫名 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 入力日 </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        /// <summary> 入力日(表示) </summary>
        public const string ct_Col_SearchSlipDateString = "SearchSlipDateString";
        /// <summary> 出荷日 </summary>
        public const string ct_Col_ShipmentDay = "ShipmentDay";
        /// <summary> 出荷日(表示) </summary>
        public const string ct_Col_ShipmentDayString = "ShipmentDayString";
        /// <summary> 計上日 </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";
        /// <summary> 計上日(表示) </summary>
        public const string ct_Col_AddUpADateString = "AddUpADateString";
        /// <summary> 拠点名 </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> 請求先コード </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> 請求先略称 </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";

        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 出荷数 </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END        

        // 2008.12.12 add start [9095]
        /// <summary> 売上行番号 </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";
        // 2008.12.12 add end [9095]

        // 発行者表示区分(DCKHN09211Eの区分と合わせる必要あり)
        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 受注残照会テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受注残照会テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCJUT04102AC ()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ テーブルスキーマ設定
        /// <summary>
        /// 在庫・倉庫移動DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="dt">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 在庫・倉庫移動データセットのスキーマを設定する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        /// <param name="inpAgentDispDiv"></param>
        static public void CreateDataTable(ref DataTable dt, int inpAgentDispDiv)
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
                dt = new DataTable( ct_Tbl_AcptAnOdrRemainRef );

                // デフォルト値
                string defaultValueOfstring = string.Empty;
                Int32 defaultValueOfInt32 = 0;
                Int64 defaultValueOfInt64 = 0;
                double defaultValueOfDouble = 0;
                DateTime defaultValueOfDateTime = DateTime.MinValue;
                bool defaultValueOfBool = false;

                # region <Column追加>

                // 企業コード
                dt.Columns.Add( ct_Col_EnterpriseCode, typeof( string ) );
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defaultValueOfstring;

                // 受注ステータス
                dt.Columns.Add( ct_Col_AcptAnOdrStatus, typeof( Int32 ) );
                dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defaultValueOfInt32;

                // 売上伝票番号
                dt.Columns.Add( ct_Col_SalesSlipNum, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defaultValueOfstring;

                // 受注番号
                dt.Columns.Add( ct_Col_AcceptAnOrderNo, typeof( Int32 ) );
                dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defaultValueOfInt32;

                // 共通通番
                dt.Columns.Add( ct_Col_CommonSeqNo, typeof( Int64 ) );
                dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defaultValueOfInt64;

                // 売上明細通番
                dt.Columns.Add( ct_Col_SalesSlipDtlNum, typeof( Int64 ) );
                dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defaultValueOfInt64;

                // 得意先コード
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                //dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
                // 0の時は空白
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfstring;

                // 得意先略称
                dt.Columns.Add( ct_Col_CustomerSnm, typeof( string ) );
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = defaultValueOfstring;

                // 販売従業員名称
                dt.Columns.Add( ct_Col_SalesEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = defaultValueOfstring;

                // 納品先名称
                dt.Columns.Add( ct_Col_AddresseeName, typeof( string ) );
                dt.Columns[ct_Col_AddresseeName].DefaultValue = defaultValueOfstring;

                // 納品先名称2
                dt.Columns.Add( ct_Col_AddresseeName2, typeof( string ) );
                dt.Columns[ct_Col_AddresseeName2].DefaultValue = defaultValueOfstring;

                // 受付従業員名称
                dt.Columns.Add( ct_Col_FrontEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = defaultValueOfstring;

                // 発行者名称
                if (inpAgentDispDiv == INP_AGT_DISP)
                {
                    dt.Columns.Add(ct_Col_SalesInputNm, typeof(string));
                    dt.Columns[ct_Col_SalesInputNm].DefaultValue = defaultValueOfstring;
                }

                // 売上日付
                dt.Columns.Add( ct_Col_SalesDate, typeof( DateTime ) );
                dt.Columns[ct_Col_SalesDate].DefaultValue = defaultValueOfDateTime;

                // 商品番号
                dt.Columns.Add( ct_Col_GoodsNo, typeof( string ) );
                dt.Columns[ct_Col_GoodsNo].DefaultValue = defaultValueOfstring;

                // 商品名称
                dt.Columns.Add( ct_Col_GoodsName, typeof( string ) );
                dt.Columns[ct_Col_GoodsName].DefaultValue = defaultValueOfstring;

                // メーカー名称
                dt.Columns.Add( ct_Col_MakerName, typeof( string ) );
                dt.Columns[ct_Col_MakerName].DefaultValue = defaultValueOfstring;

                // 受注数量
                dt.Columns.Add( ct_Col_AcceptAnOrderCnt, typeof( Double ) );
                dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defaultValueOfDouble;

                // 受注残数
                dt.Columns.Add( ct_Col_AcptAnOdrRemainCnt, typeof( Double ) );
                dt.Columns[ct_Col_AcptAnOdrRemainCnt].DefaultValue = defaultValueOfDouble;

                //// 単位名称
                //dt.Columns.Add( ct_Col_UnitName, typeof( string ) );
                //dt.Columns[ct_Col_UnitName].DefaultValue = defaultValueOfstring;

                // 売上単価（税抜，浮動）
                dt.Columns.Add( ct_Col_SalesUnPrcTaxExcFl, typeof( Double ) );
                dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defaultValueOfDouble;

                //// 特売区分名称
                //dt.Columns.Add( ct_Col_BargainNm, typeof( string ) );
                //dt.Columns[ct_Col_BargainNm].DefaultValue = defaultValueOfstring;

                // 相手先伝票番号（明細）
                dt.Columns.Add( ct_Col_PartySlipNumDtl, typeof( string ) );
                dt.Columns[ct_Col_PartySlipNumDtl].DefaultValue = defaultValueOfstring;

                // 基準単価（売上単価）
                dt.Columns.Add( ct_Col_StdUnPrcSalUnPrc, typeof( Double ) );
                dt.Columns[ct_Col_StdUnPrcSalUnPrc].DefaultValue = defaultValueOfDouble;

                // 原価単価
                dt.Columns.Add( ct_Col_SalesUnitCost, typeof( Double ) );
                dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defaultValueOfDouble;

                // 仕入先略称
                dt.Columns.Add( ct_Col_SupplierSnm, typeof( string ) );
                dt.Columns[ct_Col_SupplierSnm].DefaultValue = defaultValueOfstring;

                // 明細備考
                dt.Columns.Add( ct_Col_DtlNote, typeof( string ) );
                dt.Columns[ct_Col_DtlNote].DefaultValue = defaultValueOfstring;

                //// 客先納期
                //dt.Columns.Add( ct_Col_CustomerDeliveryDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_CustomerDeliveryDate].DefaultValue = defaultValueOfDateTime;

                // 伝票メモ１
                dt.Columns.Add( ct_Col_SlipMemo1, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo1].DefaultValue = defaultValueOfstring;

                // 伝票メモ２
                dt.Columns.Add( ct_Col_SlipMemo2, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo2].DefaultValue = defaultValueOfstring;

                // 伝票メモ３
                dt.Columns.Add( ct_Col_SlipMemo3, typeof( string ) );
                dt.Columns[ct_Col_SlipMemo3].DefaultValue = defaultValueOfstring;

                //// 伝票メモ４
                //dt.Columns.Add( ct_Col_SlipMemo4, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo4].DefaultValue = defaultValueOfstring;

                //// 伝票メモ５
                //dt.Columns.Add( ct_Col_SlipMemo5, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo5].DefaultValue = defaultValueOfstring;

                //// 伝票メモ６
                //dt.Columns.Add( ct_Col_SlipMemo6, typeof( string ) );
                //dt.Columns[ct_Col_SlipMemo6].DefaultValue = defaultValueOfstring;

                // 社内メモ１
                dt.Columns.Add( ct_Col_InsideMemo1, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo1].DefaultValue = defaultValueOfstring;

                // 社内メモ２
                dt.Columns.Add( ct_Col_InsideMemo2, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo2].DefaultValue = defaultValueOfstring;

                // 社内メモ３
                dt.Columns.Add( ct_Col_InsideMemo3, typeof( string ) );
                dt.Columns[ct_Col_InsideMemo3].DefaultValue = defaultValueOfstring;

                //// 社内メモ４
                //dt.Columns.Add( ct_Col_InsideMemo4, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo4].DefaultValue = defaultValueOfstring;

                //// 社内メモ５
                //dt.Columns.Add( ct_Col_InsideMemo5, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo5].DefaultValue = defaultValueOfstring;

                //// 社内メモ６
                //dt.Columns.Add( ct_Col_InsideMemo6, typeof( string ) );
                //dt.Columns[ct_Col_InsideMemo6].DefaultValue = defaultValueOfstring;

                //// 仕入形式
                //dt.Columns.Add( ct_Col_SupplierFormal, typeof( Int32 ) );
                //dt.Columns[ct_Col_SupplierFormal].DefaultValue = defaultValueOfInt32;

                //// 仕入明細通番
                //dt.Columns.Add( ct_Col_StockSlipDtlNum, typeof( Int64 ) );
                //dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defaultValueOfInt64;

                //// 発注番号
                //dt.Columns.Add( ct_Col_OrderNumber, typeof( string ) );
                //dt.Columns[ct_Col_OrderNumber].DefaultValue = defaultValueOfstring;

                //// 希望納期
                //dt.Columns.Add( ct_Col_ExpectDeliveryDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_ExpectDeliveryDate].DefaultValue = defaultValueOfDateTime;

                //// 納品完了予定日
                //dt.Columns.Add( ct_Col_DeliGdsCmpltDueDate, typeof( DateTime ) );
                //dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = defaultValueOfDateTime;

                //// 入荷日
                //dt.Columns.Add( ct_Col_ArrivalGoodsDay, typeof( DateTime ) );
                //dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = defaultValueOfDateTime;

                //// 仕入数
                //dt.Columns.Add( ct_Col_StockCount, typeof( Double ) );
                //dt.Columns[ct_Col_StockCount].DefaultValue = defaultValueOfDouble;

                //// 仕入単価（税抜，浮動）
                //dt.Columns.Add( ct_Col_StockUnitPriceFl, typeof( Double ) );
                //dt.Columns[ct_Col_StockUnitPriceFl].DefaultValue = defaultValueOfDouble;

                // 行№
                dt.Columns.Add( ct_Col_RowNoView, typeof( Int32 ) );
                dt.Columns[ct_Col_RowNoView].DefaultValue = defaultValueOfInt32;

                // 行選択フラグ
                dt.Columns.Add( ct_Col_SelectRowFlag, typeof( bool ) );
                dt.Columns[ct_Col_SelectRowFlag].DefaultValue = defaultValueOfBool;

                //// 受注残金額
                //dt.Columns.Add( ct_Col_AcptAnOdrRemainPrice, typeof( Int64 ) );
                //dt.Columns[ct_Col_AcptAnOdrRemainPrice].DefaultValue = defaultValueOfInt64;

                // メモマーク
                dt.Columns.Add( ct_Col_MemoExistsMark, typeof( string ) );
                dt.Columns[ct_Col_MemoExistsMark].DefaultValue = defaultValueOfstring;

                // メモ有フラグ
                dt.Columns.Add( ct_Col_MemoExistsFlag, typeof( bool ) );
                dt.Columns[ct_Col_MemoExistsFlag].DefaultValue = defaultValueOfBool;

                // 売上日付（表示用）
                dt.Columns.Add( ct_Col_SalesDateView, typeof( string ) );
                dt.Columns[ct_Col_SalesDateView].DefaultValue = defaultValueOfstring;

                //// 客先納期（表示用）
                //dt.Columns.Add( ct_Col_CustomerDeliveryDateView, typeof( string ) );
                //dt.Columns[ct_Col_CustomerDeliveryDateView].DefaultValue = defaultValueOfstring;

                //// 希望納期（表示用）
                //dt.Columns.Add( ct_Col_ExpectDeliveryDateView, typeof( string ) );
                //dt.Columns[ct_Col_ExpectDeliveryDateView].DefaultValue = defaultValueOfstring;

                //// 納品完了予定日（表示用）
                //dt.Columns.Add( ct_Col_DeliGdsCmpltDueDateView, typeof( string ) );
                //dt.Columns[ct_Col_DeliGdsCmpltDueDateView].DefaultValue = defaultValueOfstring;

                //// 入荷日（表示用）
                //dt.Columns.Add( ct_Col_ArrivalGoodsDayView, typeof( string ) );
                //dt.Columns[ct_Col_ArrivalGoodsDayView].DefaultValue = defaultValueOfstring;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.12 TOKUNAGA ADD START
                // 仕入先コード
                //dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
                //dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
                // 0の時は空白
                dt.Columns.Add(ct_Col_SupplierCd, typeof(string));
                dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfstring;

                // 倉庫コード
                dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
                dt.Columns[ct_Col_WarehouseCode].DefaultValue = defaultValueOfstring;

                // 倉庫名
                dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
                dt.Columns[ct_Col_WarehouseName].DefaultValue = defaultValueOfstring;

                // 売上伝票区分（明細）
                dt.Columns.Add(ct_Col_SalesSlipCdDtl, typeof(string));
                dt.Columns[ct_Col_SalesSlipCdDtl].DefaultValue = defaultValueOfstring;

                // BL商品コード
                //dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
                //dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfInt32;
                // 0の時は空白
                dt.Columns.Add(ct_Col_BLGoodsCode, typeof(string));
                dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defaultValueOfstring;

                // 定価（税抜、浮動）
                dt.Columns.Add(ct_Col_ListPriceTaxExc, typeof(Double));
                dt.Columns[ct_Col_ListPriceTaxExc].DefaultValue = defaultValueOfDouble;

                // 金額
                dt.Columns.Add(ct_Col_SalesPriceTotal, typeof(Double));
                dt.Columns[ct_Col_SalesPriceTotal].DefaultValue = defaultValueOfDouble;

                // 消費税
                dt.Columns.Add(ct_Col_SalesPriceConsTax, typeof(Double));
                dt.Columns[ct_Col_SalesPriceConsTax].DefaultValue = defaultValueOfDouble;

                // 原価合計
                dt.Columns.Add(ct_Col_SalesTotalCost, typeof(Double));
                dt.Columns[ct_Col_SalesTotalCost].DefaultValue = defaultValueOfDouble;

                // 出荷数
                dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
                dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defaultValueOfDouble;

                // 車両管理コード
                dt.Columns.Add(ct_Col_CarMngCode, typeof(string));
                dt.Columns[ct_Col_CarMngCode].DefaultValue = defaultValueOfstring;

                // 型式指定番号
                dt.Columns.Add(ct_Col_ModelDesignationNo, typeof(Int32));
                dt.Columns[ct_Col_ModelDesignationNo].DefaultValue = defaultValueOfInt32;

                // 類別番号 
                dt.Columns.Add(ct_Col_CategoryNo, typeof(Int32));
                dt.Columns[ct_Col_CategoryNo].DefaultValue = defaultValueOfInt32;

                // 類別型式
                dt.Columns.Add(ct_Col_ModelCategory, typeof(string));
                dt.Columns[ct_Col_ModelCategory].DefaultValue = defaultValueOfstring;
                
                // 車種全角名称
                dt.Columns.Add(ct_Col_ModelFullName, typeof(string));
                dt.Columns[ct_Col_ModelFullName].DefaultValue = defaultValueOfstring;

                // 型式（フル型）
                dt.Columns.Add(ct_Col_FullModel, typeof(string));
                dt.Columns[ct_Col_FullModel].DefaultValue = defaultValueOfstring;

                // 伝票検索日付
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_SearchSlipDate, typeof(Int32));
                //dt.Columns[ct_Col_SearchSlipDate].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(DateTime));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END
                // 伝票検索日付（文字列）
                dt.Columns.Add(ct_Col_SearchSlipDateString, typeof(string));
                dt.Columns[ct_Col_SearchSlipDateString].DefaultValue = defaultValueOfstring;

                // 計上日付
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_AddUpADate, typeof(Int32));
                //dt.Columns[ct_Col_AddUpADate].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_AddUpADate, typeof(DateTime));
                dt.Columns[ct_Col_AddUpADate].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END

                // 計上日付（文字列）
                dt.Columns.Add(ct_Col_AddUpADateString, typeof(string));
                dt.Columns[ct_Col_AddUpADateString].DefaultValue = defaultValueOfstring;

                // 出荷日
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA MODIFY START
                //dt.Columns.Add(ct_Col_ShipmentDay, typeof(Int32));
                //dt.Columns[ct_Col_ShipmentDay].DefaultValue = defaultValueOfInt32;
                dt.Columns.Add(ct_Col_ShipmentDay, typeof(DateTime));
                dt.Columns[ct_Col_ShipmentDay].DefaultValue = defaultValueOfDateTime;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA MODIFY END

                // 出荷日（文字列）
                dt.Columns.Add(ct_Col_ShipmentDayString, typeof(string));
                dt.Columns[ct_Col_ShipmentDayString].DefaultValue = defaultValueOfstring;

                // 拠点名
                dt.Columns.Add(ct_Col_SectionName, typeof(string));
                dt.Columns[ct_Col_SectionName].DefaultValue = defaultValueOfstring;

                // 請求先コード
                //dt.Columns.Add(ct_Col_ClaimCode, typeof(Int32));
                //dt.Columns[ct_Col_ClaimCode].DefaultValue = defaultValueOfInt32;
                // 0の時は空白
                dt.Columns.Add(ct_Col_ClaimCode, typeof(string));
                dt.Columns[ct_Col_ClaimCode].DefaultValue = defaultValueOfstring;

                // 請求先略称
                dt.Columns.Add(ct_Col_ClaimSnm, typeof(string));
                dt.Columns[ct_Col_ClaimSnm].DefaultValue = defaultValueOfstring;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.12 TOKUNAGA ADD END

                // 2008.12.12 add start [9095]
                // 売上行番号
                dt.Columns.Add(ct_Col_SalesRowNo, typeof(Int32));
                dt.Columns[ct_Col_SalesRowNo].DefaultValue = defaultValueOfInt32;
                // 2008.12.12 add end [9095]

                // [9095]
                // 行№(表示用)
                dt.Columns.Add(ct_Col_RowNoDisplay, typeof(Int32));
                dt.Columns[ct_Col_RowNoDisplay].DefaultValue = defaultValueOfInt32;
                // [9095]

                # endregion
            }
        }
        #endregion
        #endregion
    }
}
