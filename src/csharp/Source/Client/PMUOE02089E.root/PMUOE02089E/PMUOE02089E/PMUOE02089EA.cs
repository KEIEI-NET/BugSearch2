using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 発注送信エラーリストテーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注送信エラーリストテーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.12.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SupplierSendErResult
    {

        /// <summary> テーブル名称 </summary>
        public const string Col_Tbl_Result_SupplierSendEr = "Tbl_Result_SupplierSendEr";

        /// <summary> 作成日時 </summary>
        public const string Col_CreateDateTime = "CreateDateTime";

        /// <summary> 更新日時 </summary>
        public const string Col_UpdateDateTime = "UpdateDateTime";

        /// <summary> 企業コード </summary>
        public const string Col_EnterpriseCode = "EnterpriseCode";

        /// <summary> GUID </summary>
        public const string Col_FileHeaderGuid = "FileHeaderGuid";

        /// <summary> 更新従業員コード </summary>
        public const string Col_UpdEmployeeCode = "UpdEmployeeCode";

        /// <summary> 更新アセンブリID1 </summary>
        public const string Col_UpdAssemblyId1 = "UpdAssemblyId1";

        /// <summary> 更新アセンブリID2 </summary>
        public const string Col_UpdAssemblyId2 = "UpdAssemblyId2";

        /// <summary> 論理削除区分 </summary>
        public const string Col_LogicalDeleteCode = "LogicalDeleteCode";

        /// <summary> システム区分 </summary>
        public const string Col_SystemDivCd = "SystemDivCd";

        /// <summary> UOE発注番号 </summary>
        public const string Col_UOESalesOrderNo = "UOESalesOrderNo";

        /// <summary> UOE発注行番号 </summary>
        public const string Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";

        /// <summary> 送信端末番号 </summary>
        public const string Col_SendTerminalNo = "SendTerminalNo";

        /// <summary> UOE発注先コード </summary>
        public const string Col_UOESupplierCd = "UOESupplierCd";

        /// <summary> UOE発注先名称 </summary>
        public const string Col_UOESupplierName = "UOESupplierName";

        /// <summary> 通信アセンブリID </summary>
        public const string Col_CommAssemblyId = "CommAssemblyId";

        /// <summary> 通信アセンブリID </summary>
        public const string Col_OnlineNo = "OnlineNo";

        /// <summary> オンライン行番号 </summary>
        public const string Col_OnlineRowNo = "OnlineRowNo";

        /// <summary> 売上日付 </summary>
        public const string Col_SalesDate = "SalesDate";

        /// <summary> 入力日 </summary>
        public const string Col_InputDay = "InputDay";

        /// <summary> データ更新日時 </summary>
        public const string Col_DataUpdateDateTime = "DataUpdateDateTime";

        /// <summary> UOE種別 </summary>
        public const string Col_UOEKind = "UOEKind";

        /// <summary> 売上伝票番号 </summary>
        public const string Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 受注ステータス </summary>
        public const string Col_AcptAnOdrStatus = "AcptAnOdrStatus";

        /// <summary> 売上明細通番 </summary>
        public const string Col_SalesSlipDtlNum = "SalesSlipDtlNum";

        /// <summary> 拠点コード </summary>
        public const string Col_SectionCode = "SectionCode";

        /// <summary> 拠点ガイド略称 </summary>
        public const string Col_SectionGuideSnm = "SectionGuideSnm";

        /// <summary> 部門コード </summary>
        public const string Col_SubSectionCode = "SubSectionCode";

        /// <summary> 得意先コード </summary>
        public const string Col_CustomerCode = "CustomerCode";

        /// <summary> 得意先略称 </summary>
        public const string Col_CustomerSnm = "CustomerSnm";

        /// <summary> レジ番号 </summary>
        public const string Col_CashRegisterNo = "CashRegisterNo";

        /// <summary> 共通通番 </summary>
        public const string Col_CommonSeqNo = "CommonSeqNo";

        /// <summary> 仕入形式 </summary>
        public const string Col_SupplierFormal = "SupplierFormal";

        /// <summary> 仕入伝票番号 </summary>
        public const string Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> 仕入明細通番 </summary>
        public const string Col_StockSlipDtlNum = "StockSlipDtlNum";

        /// <summary> BO区分 </summary>
        public const string Col_BoCode = "BoCode";

        /// <summary> UOE納品区分 </summary>
        public const string Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";

        /// <summary> 納品区分名称 </summary>
        public const string Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";

        /// <summary> フォロー納品区分 </summary>
        public const string Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";

        /// <summary> フォロー納品区分名称 </summary>
        public const string Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";

        /// <summary> UOE指定拠点 </summary>
        public const string Col_UOEResvdSection = "UOEResvdSection";

        /// <summary> UOE指定拠点名称 </summary>
        public const string Col_UOEResvdSectionNm = "UOEResvdSectionNm";

        /// <summary> 従業員コード </summary>
        public const string Col_EmployeeCode = "EmployeeCode";

        /// <summary> 従業員名称 </summary>
        public const string Col_EmployeeName = "EmployeeName";

        /// <summary> 商品メーカーコード </summary>
        public const string Col_GoodsMakerCd = "GoodsMakerCd";

        /// <summary> メーカー名称 </summary>
        public const string Col_MakerName = "MakerName";

        /// <summary> 商品番号 </summary>
        public const string Col_GoodsNo = "GoodsNo";

        /// <summary> ハイフン無商品番号 </summary>
        public const string Col_GoodsNoNoneHyphen = "GoodsNoNoneHyphen";

        /// <summary> 商品名称 </summary>
        public const string Col_GoodsName = "GoodsName";

        /// <summary> 倉庫コード </summary>
        public const string Col_WarehouseCode = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string Col_WarehouseName = "WarehouseName";

        /// <summary> 倉庫棚番 </summary>
        public const string Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 受注数量 </summary>
        public const string Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";

        /// <summary> 定価（浮動） </summary>
        public const string Col_ListPrice = "ListPrice";

        /// <summary> 原価単価 </summary>
        public const string Col_SalesUnitCost = "SalesUnitCost";

        /// <summary> 仕入先コード </summary>
        public const string Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先略称 </summary>
        public const string Col_SupplierSnm = "SupplierSnm";

        /// <summary> ＵＯＥリマーク１ </summary>
        public const string Col_UoeRemark1 = "UoeRemark1";

        /// <summary> ＵＯＥリマーク２ </summary>
        public const string Col_UoeRemark2 = "UoeRemark2";

        /// <summary> 受信日付 </summary>
        public const string Col_ReceiveDate = "ReceiveDate";

        /// <summary> 受信時刻 </summary>
        public const string Col_ReceiveTime = "ReceiveTime";

        /// <summary> 回答メーカーコード </summary>
        public const string Col_AnswerMakerCd = "AnswerMakerCd";

        /// <summary> 回答品番 </summary>
        public const string Col_AnswerPartsNo = "AnswerPartsNo";

        /// <summary> 回答品名 </summary>
        public const string Col_AnswerPartsName = "AnswerPartsName";

        /// <summary> 代替品番 </summary>
        public const string Col_SubstPartsNo = "SubstPartsNo";

        /// <summary> UOE拠点出庫数 </summary>
        public const string Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";

        /// <summary> BO出庫数1 </summary>
        public const string Col_BOShipmentCnt1 = "BOShipmentCnt1";

        /// <summary> BO出庫数2 </summary>
        public const string Col_BOShipmentCnt2 = "BOShipmentCnt2";

        /// <summary> BO出庫数3 </summary>
        public const string Col_BOShipmentCnt3 = "BOShipmentCnt3";

        /// <summary> メーカーフォロー数 </summary>
        public const string Col_MakerFollowCnt = "MakerFollowCnt";

        /// <summary> 未出庫数 </summary>
        public const string Col_NonShipmentCnt = "NonShipmentCnt";

        /// <summary> UOE拠点在庫数 </summary>
        public const string Col_UOESectStockCnt = "UOESectStockCnt";

        /// <summary> BO在庫数1 </summary>
        public const string Col_BOStockCount1 = "BOStockCount1";

        /// <summary> BO在庫数2 </summary>
        public const string Col_BOStockCount2 = "BOStockCount2";

        /// <summary> BO在庫数3 </summary>
        public const string Col_BOStockCount3 = "BOStockCount3";

        /// <summary> UOE拠点伝票番号 </summary>
        public const string Col_UOESectionSlipNo = "UOESectionSlipNo";

        /// <summary> BO伝票番号１ </summary>
        public const string Col_BOSlipNo1 = "BOSlipNo1";

        /// <summary> BO伝票番号２ </summary>
        public const string Col_BOSlipNo2 = "BOSlipNo2";

        /// <summary> BO伝票番号３ </summary>
        public const string Col_BOSlipNo3 = "BOSlipNo3";

        /// <summary> EO引当数 </summary>
        public const string Col_EOAlwcCount = "EOAlwcCount";

        /// <summary> BO管理番号 </summary>
        public const string Col_BOManagementNo = "BOManagementNo";

        /// <summary> 回答定価 </summary>
        public const string Col_AnswerListPrice = "AnswerListPrice";

        /// <summary> 回答原価単価 </summary>
        public const string Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";

        /// <summary> UOE代替マーク </summary>
        public const string Col_UOESubstMark = "UOESubstMark";

        /// <summary> UOE在庫マーク </summary>
        public const string Col_UOEStockMark = "UOEStockMark";

        /// <summary> 層別コード </summary>
        public const string Col_PartsLayerCd = "PartsLayerCd";

        /// <summary> UOE出荷拠点コード１（マツダ） </summary>
        public const string Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";

        /// <summary> UOE出荷拠点コード２（マツダ） </summary>
        public const string Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";

        /// <summary> UOE出荷拠点コード３（マツダ） </summary>
        public const string Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";

        /// <summary> UOE拠点コード１（マツダ） </summary>
        public const string Col_MazdaUOESectCd1 = "MazdaUOESectCd1";

        /// <summary> UOE拠点コード２（マツダ） </summary>
        public const string Col_MazdaUOESectCd2 = "MazdaUOESectCd2";

        /// <summary> UOE拠点コード３（マツダ） </summary>
        public const string Col_MazdaUOESectCd3 = "MazdaUOESectCd3";

        /// <summary> UOE拠点コード４（マツダ） </summary>
        public const string Col_MazdaUOESectCd4 = "MazdaUOESectCd4";

        /// <summary> UOE拠点コード５（マツダ） </summary>
        public const string Col_MazdaUOESectCd5 = "MazdaUOESectCd5";

        /// <summary> UOE拠点コード６（マツダ） </summary>
        public const string Col_MazdaUOESectCd6 = "MazdaUOESectCd6";

        /// <summary> UOE拠点コード７（マツダ） </summary>
        public const string Col_MazdaUOESectCd7 = "MazdaUOESectCd7";

        /// <summary> UOE在庫数１（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt1 = "MazdaUOEStockCnt1";

        /// <summary> UOE在庫数２（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt2 = "MazdaUOEStockCnt2";

        /// <summary> UOE在庫数３（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt3 = "MazdaUOEStockCnt3";

        /// <summary> UOE在庫数４（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt4 = "MazdaUOEStockCnt4";

        /// <summary> UOE在庫数５（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt5 = "MazdaUOEStockCnt5";

        /// <summary> UOE在庫数６（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt6 = "MazdaUOEStockCnt6";

        /// <summary> UOE在庫数７（マツダ） </summary>
        public const string Col_MazdaUOEStockCnt7 = "MazdaUOEStockCnt7";

        /// <summary> UOE卸コード </summary>
        public const string Col_UOEDistributionCd = "UOEDistributionCd";

        /// <summary> UOE他コード </summary>
        public const string Col_UOEOtherCd = "UOEOtherCd";

        /// <summary> UOEＨＭコード </summary>
        public const string Col_UOEHMCd = "UOEHMCd";

        /// <summary> ＢＯ数 </summary>
        public const string Col_BOCount = "BOCount";

        /// <summary> UOEマークコード </summary>
        public const string Col_UOEMarkCode = "UOEMarkCode";

        /// <summary> 出荷元 </summary>
        public const string Col_SourceShipment = "SourceShipment";

        /// <summary> アイテムコード </summary>
        public const string Col_ItemCode = "ItemCode";

        /// <summary> UOEチェックコード </summary>
        public const string Col_UOECheckCode = "UOECheckCode";

        /// <summary> ヘッドエラーメッセージ </summary>
        public const string Col_HeadErrorMassage = "HeadErrorMassage";

        /// <summary> ラインエラーメッセージ </summary>
        public const string Col_LineErrorMassage = "LineErrorMassage";

        /// <summary> データ送信区分 </summary>
        public const string Col_DataSendCode = "DataSendCode";

        /// <summary> データ復旧区分 </summary>
        public const string Col_DataRecoverDiv = "DataRecoverDiv";

        /// <summary> 入庫更新区分（拠点） </summary>
        public const string Col_EnterUpdDivSec = "EnterUpdDivSec";

        /// <summary> 入庫更新区分（BO1） </summary>
        public const string Col_EnterUpdDivBO1 = "EnterUpdDivBO1";

        /// <summary> 入庫更新区分（BO2） </summary>
        public const string Col_EnterUpdDivBO2 = "EnterUpdDivBO2";

        /// <summary> 入庫更新区分（BO3） </summary>
        public const string Col_EnterUpdDivBO3 = "EnterUpdDivBO3";

        /// <summary> 入庫更新区分（ﾒｰｶｰ） </summary>
        public const string Col_EnterUpdDivMaker = "EnterUpdDivMaker";

        /// <summary> 入庫更新区分（EO） </summary>
        public const string Col_EnterUpdDivEO = "EnterUpdDivEO";

        // 印刷用
        /// <summary> 受信日付(印刷用) </summary>
        public const string Col_ReceiveDate_Print = "ReceiveDate_Print";

        /// <summary> システム区分(印刷用) </summary>
        public const string Col_SystemDivCd_Print = "SystemDivCd_Print";

        /// <summary>
        /// 発注送信エラーリストテーブルスキーマ定義クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注送信エラーリストテーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.12.10</br>
		/// </remarks>
        public SupplierSendErResult()
		{
		}

        /// <summary>
		/// DataSetテーブルスキーマ設定
		/// </summary>
		/// <param name="ds">設定対象データセット</param>
		/// <remarks>
		/// <br>Note       : データセットのスキーマを設定する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        static public void CreateDataTableResultSupplierSendEr(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(Col_Tbl_Result_SupplierSendEr))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[Col_Tbl_Result_SupplierSendEr].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(Col_Tbl_Result_SupplierSendEr);

                DataTable dt = ds.Tables[Col_Tbl_Result_SupplierSendEr];

                string defValuestring = "";
                Int32 defValueInt32 = 0;
                Int64 defValueInt64 = 0;
                double defValueDouble = 0.0;

                dt.Columns.Add(Col_CreateDateTime, typeof(DateTime));               // 作成日時
                dt.Columns[Col_CreateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_UpdateDateTime, typeof(DateTime));               // 更新日時
                dt.Columns[Col_UpdateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_EnterpriseCode, typeof(string));                 // 企業コード
                dt.Columns[Col_EnterpriseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FileHeaderGuid, typeof(Guid));                   // GUID
                dt.Columns[Col_FileHeaderGuid].DefaultValue = Guid.Empty;

                dt.Columns.Add(Col_UpdEmployeeCode, typeof(string));                // 更新従業員コード
                dt.Columns[Col_UpdEmployeeCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdAssemblyId1, typeof(string));                 // 更新アセンブリID1
                dt.Columns[Col_UpdAssemblyId1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UpdAssemblyId2, typeof(string));                 // 更新アセンブリID2
                dt.Columns[Col_UpdAssemblyId2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LogicalDeleteCode, typeof(Int32));               // 論理削除区分
                dt.Columns[Col_LogicalDeleteCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SystemDivCd, typeof(Int32));                     // システム区分
                dt.Columns[Col_SystemDivCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESalesOrderNo, typeof(Int32));                 // UOE発注番号
                dt.Columns[Col_UOESalesOrderNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESalesOrderRowNo, typeof(Int32));              // UOE発注行番号
                dt.Columns[Col_UOESalesOrderRowNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SendTerminalNo, typeof(Int32));                  // 送信端末番号
                dt.Columns[Col_SendTerminalNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESupplierCd, typeof(Int32));                   // UOE発注先コード
                dt.Columns[Col_UOESupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESupplierName, typeof(string));                // UOE発注先名称
                dt.Columns[Col_UOESupplierName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CommAssemblyId, typeof(string));                 // 通信アセンブリID
                dt.Columns[Col_CommAssemblyId].DefaultValue = defValuestring;

                dt.Columns.Add(Col_OnlineNo, typeof(Int32));                        // 通信アセンブリID
                dt.Columns[Col_OnlineNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_OnlineRowNo, typeof(Int32));                     // オンライン行番号
                dt.Columns[Col_OnlineRowNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesDate, typeof(DateTime));                    // 売上日付
                dt.Columns[Col_SalesDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_InputDay, typeof(DateTime));                     // 入力日
                dt.Columns[Col_InputDay].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_DataUpdateDateTime, typeof(DateTime));           // データ更新日時
                dt.Columns[Col_DataUpdateDateTime].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_UOEKind, typeof(Int32));                         // UOE種別
                dt.Columns[Col_UOEKind].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesSlipNum, typeof(string));                   // 売上伝票番号
                dt.Columns[Col_SalesSlipNum].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcptAnOdrStatus, typeof(Int32));                 // 受注ステータス
                dt.Columns[Col_AcptAnOdrStatus].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SalesSlipDtlNum, typeof(Int64));                 // 売上明細通番
                dt.Columns[Col_SalesSlipDtlNum].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_SectionCode, typeof(string));                    // 拠点コード
                dt.Columns[Col_SectionCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SectionGuideSnm, typeof(string));                // 拠点ガイド略称
                dt.Columns[Col_SectionGuideSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SubSectionCode, typeof(Int32));                  // 部門コード
                dt.Columns[Col_SubSectionCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CustomerCode, typeof(Int32));                    // 得意先コード
                dt.Columns[Col_CustomerCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CustomerSnm, typeof(string));                    // 得意先略称
                dt.Columns[Col_CustomerSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_CashRegisterNo, typeof(Int32));                  // レジ番号
                dt.Columns[Col_CashRegisterNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_CommonSeqNo, typeof(Int64));                     // 共通通番
                dt.Columns[Col_CommonSeqNo].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_SupplierFormal, typeof(Int32));                  // 仕入形式
                dt.Columns[Col_SupplierFormal].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSlipNo, typeof(Int32));                  // 仕入伝票番号
                dt.Columns[Col_SupplierSlipNo].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_StockSlipDtlNum, typeof(Int64));                 // 仕入明細通番
                dt.Columns[Col_StockSlipDtlNum].DefaultValue = defValueInt64;

                dt.Columns.Add(Col_BoCode, typeof(string));                         // BO区分
                dt.Columns[Col_BoCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEDeliGoodsDiv, typeof(string));                // UOE納品区分
                dt.Columns[Col_UOEDeliGoodsDiv].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DeliveredGoodsDivNm, typeof(string));            // 納品区分名称
                dt.Columns[Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FollowDeliGoodsDiv, typeof(string));             // フォロー納品区分
                dt.Columns[Col_FollowDeliGoodsDiv].DefaultValue = defValuestring;

                dt.Columns.Add(Col_FollowDeliGoodsDivNm, typeof(string));           // フォロー納品区分名称
                dt.Columns[Col_FollowDeliGoodsDivNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEResvdSection, typeof(string));                // UOE指定拠点
                dt.Columns[Col_UOEResvdSection].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEResvdSectionNm, typeof(string));              // UOE指定拠点名称
                dt.Columns[Col_UOEResvdSectionNm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EmployeeCode, typeof(string));                   // 従業員コード
                dt.Columns[Col_EmployeeCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EmployeeName, typeof(string));                   // 従業員名称
                dt.Columns[Col_EmployeeName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsMakerCd, typeof(Int32));                    // 商品メーカーコード
                dt.Columns[Col_GoodsMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerName, typeof(string));                      // メーカー名称
                dt.Columns[Col_MakerName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNo, typeof(string));                        // 商品番号
                dt.Columns[Col_GoodsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsNoNoneHyphen, typeof(string));              // ハイフン無商品番号
                dt.Columns[Col_GoodsNoNoneHyphen].DefaultValue = defValuestring;

                dt.Columns.Add(Col_GoodsName, typeof(string));                      // 商品名称
                dt.Columns[Col_GoodsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseCode, typeof(string));                  // 倉庫コード
                dt.Columns[Col_WarehouseCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseName, typeof(string));                  // 倉庫名称
                dt.Columns[Col_WarehouseName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_WarehouseShelfNo, typeof(string));               // 倉庫棚番
                dt.Columns[Col_WarehouseShelfNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AcceptAnOrderCnt, typeof(Double));               // 受注数量
                dt.Columns[Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_ListPrice, typeof(Double));                      // 定価（浮動）
                dt.Columns[Col_ListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SalesUnitCost, typeof(Double));                  // 原価単価
                dt.Columns[Col_SalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_SupplierCd, typeof(Int32));                      // 仕入先コード
                dt.Columns[Col_SupplierCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_SupplierSnm, typeof(string));                    // 仕入先略称
                dt.Columns[Col_SupplierSnm].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark1, typeof(string));                     // ＵＯＥリマーク１
                dt.Columns[Col_UoeRemark1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UoeRemark2, typeof(string));                     // ＵＯＥリマーク２
                dt.Columns[Col_UoeRemark2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ReceiveDate, typeof(DateTime));                  // 受信日付
                dt.Columns[Col_ReceiveDate].DefaultValue = DateTime.MinValue;

                dt.Columns.Add(Col_ReceiveTime, typeof(Int32));                     // 受信時刻
                dt.Columns[Col_ReceiveTime].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerMakerCd, typeof(Int32));                   // 回答メーカーコード
                dt.Columns[Col_AnswerMakerCd].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_AnswerPartsNo, typeof(string));                  // 回答品番
                dt.Columns[Col_AnswerPartsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerPartsName, typeof(string));                // 回答品名
                dt.Columns[Col_AnswerPartsName].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SubstPartsNo, typeof(string));                   // 代替品番
                dt.Columns[Col_SubstPartsNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOESectOutGoodsCnt, typeof(Int32));              // UOE拠点出庫数
                dt.Columns[Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt1, typeof(Int32));                  // BO出庫数1
                dt.Columns[Col_BOShipmentCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt2, typeof(Int32));                  // BO出庫数2
                dt.Columns[Col_BOShipmentCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOShipmentCnt3, typeof(Int32));                  // BO出庫数3
                dt.Columns[Col_BOShipmentCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MakerFollowCnt, typeof(Int32));                  // メーカーフォロー数
                dt.Columns[Col_MakerFollowCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_NonShipmentCnt, typeof(Int32));                  // 未出庫数
                dt.Columns[Col_NonShipmentCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectStockCnt, typeof(Int32));                 // UOE拠点在庫数
                dt.Columns[Col_UOESectStockCnt].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount1, typeof(Int32));                   // BO在庫数1
                dt.Columns[Col_BOStockCount1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount2, typeof(Int32));                   // BO在庫数2
                dt.Columns[Col_BOStockCount2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOStockCount3, typeof(Int32));                   // BO在庫数3
                dt.Columns[Col_BOStockCount3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOESectionSlipNo, typeof(string));               // UOE拠点伝票番号
                dt.Columns[Col_UOESectionSlipNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo1, typeof(string));                      // BO伝票番号１
                dt.Columns[Col_BOSlipNo1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo2, typeof(string));                      // BO伝票番号２
                dt.Columns[Col_BOSlipNo2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOSlipNo3, typeof(string));                      // BO伝票番号３
                dt.Columns[Col_BOSlipNo3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_EOAlwcCount, typeof(Int32));                     // EO引当数
                dt.Columns[Col_EOAlwcCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_BOManagementNo, typeof(string));                 // BO管理番号
                dt.Columns[Col_BOManagementNo].DefaultValue = defValuestring;

                dt.Columns.Add(Col_AnswerListPrice, typeof(Double));                // 回答定価
                dt.Columns[Col_AnswerListPrice].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_AnswerSalesUnitCost, typeof(Double));            // 回答原価単価
                dt.Columns[Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;

                dt.Columns.Add(Col_UOESubstMark, typeof(string));                   // UOE代替マーク
                dt.Columns[Col_UOESubstMark].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEStockMark, typeof(string));                   // UOE在庫マーク
                dt.Columns[Col_UOEStockMark].DefaultValue = defValuestring;

                dt.Columns.Add(Col_PartsLayerCd, typeof(string));                   // 層別コード
                dt.Columns[Col_PartsLayerCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd1, typeof(string));            // UOE出荷拠点コード１（マツダ）
                dt.Columns[Col_MazdaUOEShipSectCd1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd2, typeof(string));            // UOE出荷拠点コード２（マツダ）
                dt.Columns[Col_MazdaUOEShipSectCd2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEShipSectCd3, typeof(string));            // UOE出荷拠点コード３（マツダ）
                dt.Columns[Col_MazdaUOEShipSectCd3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd1, typeof(string));                // UOE拠点コード１（マツダ）
                dt.Columns[Col_MazdaUOESectCd1].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd2, typeof(string));                // UOE拠点コード２（マツダ）
                dt.Columns[Col_MazdaUOESectCd2].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd3, typeof(string));                // UOE拠点コード３（マツダ）
                dt.Columns[Col_MazdaUOESectCd3].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd4, typeof(string));                // UOE拠点コード４（マツダ）
                dt.Columns[Col_MazdaUOESectCd4].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd5, typeof(string));                // UOE拠点コード５（マツダ）
                dt.Columns[Col_MazdaUOESectCd5].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd6, typeof(string));                // UOE拠点コード６（マツダ）
                dt.Columns[Col_MazdaUOESectCd6].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOESectCd7, typeof(string));                // UOE拠点コード７（マツダ）
                dt.Columns[Col_MazdaUOESectCd7].DefaultValue = defValuestring;

                dt.Columns.Add(Col_MazdaUOEStockCnt1, typeof(Int32));               // UOE在庫数１（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt2, typeof(Int32));               // UOE在庫数２（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt3, typeof(Int32));               // UOE在庫数３（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt4, typeof(Int32));               // UOE在庫数４（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt4].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt5, typeof(Int32));               // UOE在庫数５（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt5].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt6, typeof(Int32));               // UOE在庫数６（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt6].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_MazdaUOEStockCnt7, typeof(Int32));               // UOE在庫数７（マツダ）
                dt.Columns[Col_MazdaUOEStockCnt7].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOEDistributionCd, typeof(string));              // UOE卸コード
                dt.Columns[Col_UOEDistributionCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEOtherCd, typeof(string));                     // UOE他コード
                dt.Columns[Col_UOEOtherCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOEHMCd, typeof(string));                        // UOEＨＭコード
                dt.Columns[Col_UOEHMCd].DefaultValue = defValuestring;

                dt.Columns.Add(Col_BOCount, typeof(Int32));                         // ＢＯ数
                dt.Columns[Col_BOCount].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_UOEMarkCode, typeof(string));                    // UOEマークコード
                dt.Columns[Col_UOEMarkCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SourceShipment, typeof(string));                 // 出荷元
                dt.Columns[Col_SourceShipment].DefaultValue = defValuestring;

                dt.Columns.Add(Col_ItemCode, typeof(string));                       // アイテムコード
                dt.Columns[Col_ItemCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_UOECheckCode, typeof(string));                   // UOEチェックコード
                dt.Columns[Col_UOECheckCode].DefaultValue = defValuestring;

                dt.Columns.Add(Col_HeadErrorMassage, typeof(string));               // ヘッドエラーメッセージ
                dt.Columns[Col_HeadErrorMassage].DefaultValue = defValuestring;

                dt.Columns.Add(Col_LineErrorMassage, typeof(string));               // ラインエラーメッセージ
                dt.Columns[Col_LineErrorMassage].DefaultValue = defValuestring;

                dt.Columns.Add(Col_DataSendCode, typeof(Int32));                    // データ送信区分
                dt.Columns[Col_DataSendCode].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_DataRecoverDiv, typeof(Int32));                  // データ復旧区分
                dt.Columns[Col_DataRecoverDiv].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivSec, typeof(Int32));                  // 入庫更新区分（拠点）
                dt.Columns[Col_EnterUpdDivSec].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO1, typeof(Int32));                  // 入庫更新区分（BO1）
                dt.Columns[Col_EnterUpdDivBO1].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO2, typeof(Int32));                  // 入庫更新区分（BO2）
                dt.Columns[Col_EnterUpdDivBO2].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivBO3, typeof(Int32));                  // 入庫更新区分（BO3）
                dt.Columns[Col_EnterUpdDivBO3].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivMaker, typeof(Int32));                // 入庫更新区分（ﾒｰｶｰ）
                dt.Columns[Col_EnterUpdDivMaker].DefaultValue = defValueInt32;

                dt.Columns.Add(Col_EnterUpdDivEO, typeof(Int32));                   // 入庫更新区分（EO）
                dt.Columns[Col_EnterUpdDivEO].DefaultValue = defValueInt32;

                // 印刷用
                dt.Columns.Add(Col_ReceiveDate_Print, typeof(string));              // 受信日付(印刷用)
                dt.Columns[Col_ReceiveDate_Print].DefaultValue = defValuestring;

                dt.Columns.Add(Col_SystemDivCd_Print, typeof(string));              // システム区分(印刷用)
                dt.Columns[Col_SystemDivCd_Print].DefaultValue = defValuestring;

            }
        }
    }
}
