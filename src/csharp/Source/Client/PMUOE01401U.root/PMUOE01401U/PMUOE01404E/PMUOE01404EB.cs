//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ発注データテーブルスキーマクラス
// プログラム概要   : ＵＯＥ発注データテーブル定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ＵＯＥ発注データテーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ発注抽出結果テーブルスキーマ</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/12/01</br>
    /// </remarks>
    public class UOEOrderDtlSchema
    {
        #region Public Members
        /// <summary>ＵＯＥ発注データテーブル名</summary>
        public const string CT_SendUOEOrderDtlDataTable = "SendUOEOrderDtlDataTable";

        #region カラム初期情報
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValuestring = "";
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
        /// <summary> システム区分 </summary>
        public const string ct_Col_SystemDivCd = "SystemDivCd";
        /// <summary> UOE発注番号 </summary>
        public const string ct_Col_UOESalesOrderNo = "UOESalesOrderNo";
        /// <summary> UOE発注行番号 </summary>
        public const string ct_Col_UOESalesOrderRowNo = "UOESalesOrderRowNo";
        /// <summary> 送信端末番号 </summary>
        public const string ct_Col_SendTerminalNo = "SendTerminalNo";
        /// <summary> UOE発注先コード </summary>
        public const string ct_Col_UOESupplierCd = "UOESupplierCd";
        /// <summary> UOE発注先名称 </summary>
        public const string ct_Col_UOESupplierName = "UOESupplierName";
        /// <summary> 通信アセンブリID </summary>
        public const string ct_Col_CommAssemblyId = "CommAssemblyId";
        /// <summary> オンライン番号 </summary>
        public const string ct_Col_OnlineNo = "OnlineNo";
        /// <summary> オンライン行番号 </summary>
        public const string ct_Col_OnlineRowNo = "OnlineRowNo";
        /// <summary> 売上日付 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 入力日 </summary>
        public const string ct_Col_InputDay = "InputDay";
        /// <summary> データ更新日時 </summary>
        public const string ct_Col_DataUpdateDateTime = "DataUpdateDateTime";
        /// <summary> UOE種別 </summary>
        public const string ct_Col_UOEKind = "UOEKind";
        /// <summary> 売上伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 受注ステータス </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> 売上明細通番 </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 部門コード </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> レジ番号 </summary>
        public const string ct_Col_CashRegisterNo = "CashRegisterNo";
        /// <summary> 共通通番 </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> 仕入形式 </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> 仕入伝票番号 </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 仕入明細通番 </summary>
        public const string ct_Col_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> BO区分 </summary>
        public const string ct_Col_BoCode = "BoCode";
        /// <summary> 納品区分 </summary>
        public const string ct_Col_UOEDeliGoodsDiv = "UOEDeliGoodsDiv";
        /// <summary> 納品区分名称 </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> フォロー納品区分 </summary>
        public const string ct_Col_FollowDeliGoodsDiv = "FollowDeliGoodsDiv";
        /// <summary> フォロー納品区分名称 </summary>
        public const string ct_Col_FollowDeliGoodsDivNm = "FollowDeliGoodsDivNm";
        /// <summary> UOE指定拠点 </summary>
        public const string ct_Col_UOEResvdSection = "UOEResvdSection";
        /// <summary> UOE指定拠点名称 </summary>
        public const string ct_Col_UOEResvdSectionNm = "UOEResvdSectionNm";
        /// <summary> 従業員コード </summary>
        public const string ct_Col_EmployeeCode = "EmployeeCode";
        /// <summary> 従業員名称 </summary>
        public const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> 商品メーカーコード </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> メーカー名称 </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> 商品番号 </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ハイフン無商品番号 </summary>
        public const string ct_Col_GoodsNoNoneHyphen = "GoodsNoNoneHyphen";
        /// <summary> 商品名称 </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> 倉庫コード </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称 </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> 倉庫棚番 </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> 受注数量 </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 定価（浮動） </summary>
        public const string ct_Col_ListPrice = "ListPrice";
        /// <summary> 原価単価 </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> ＵＯＥリマーク１ </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> ＵＯＥリマーク２ </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> 受信日付 </summary>
        public const string ct_Col_ReceiveDate = "ReceiveDate";
        /// <summary> 受信時刻 </summary>
        public const string ct_Col_ReceiveTime = "ReceiveTime";
        /// <summary> 回答メーカーコード </summary>
        public const string ct_Col_AnswerMakerCd = "AnswerMakerCd";
        /// <summary> 回答品番 </summary>
        public const string ct_Col_AnswerPartsNo = "AnswerPartsNo";
        /// <summary> 回答品名 </summary>
        public const string ct_Col_AnswerPartsName = "AnswerPartsName";
        /// <summary> 代替品番 </summary>
        public const string ct_Col_SubstPartsNo = "SubstPartsNo";
        /// <summary> UOE拠点出庫数 </summary>
        public const string ct_Col_UOESectOutGoodsCnt = "UOESectOutGoodsCnt";
        /// <summary> BO出庫数1 </summary>
        public const string ct_Col_BOShipmentCnt1 = "BOShipmentCnt1";
        /// <summary> BO出庫数2 </summary>
        public const string ct_Col_BOShipmentCnt2 = "BOShipmentCnt2";
        /// <summary> BO出庫数3 </summary>
        public const string ct_Col_BOShipmentCnt3 = "BOShipmentCnt3";
        /// <summary> メーカーフォロー数 </summary>
        public const string ct_Col_MakerFollowCnt = "MakerFollowCnt";
        /// <summary> 未出庫数 </summary>
        public const string ct_Col_NonShipmentCnt = "NonShipmentCnt";
        /// <summary> UOE拠点在庫数 </summary>
        public const string ct_Col_UOESectStockCnt = "UOESectStockCnt";
        /// <summary> BO在庫数1 </summary>
        public const string ct_Col_BOStockCount1 = "BOStockCount1";
        /// <summary> BO在庫数2 </summary>
        public const string ct_Col_BOStockCount2 = "BOStockCount2";
        /// <summary> BO在庫数3 </summary>
        public const string ct_Col_BOStockCount3 = "BOStockCount3";
        /// <summary> UOE拠点伝票番号 </summary>
        public const string ct_Col_UOESectionSlipNo = "UOESectionSlipNo";
        /// <summary> BO伝票番号１ </summary>
        public const string ct_Col_BOSlipNo1 = "BOSlipNo1";
        /// <summary> BO伝票番号２ </summary>
        public const string ct_Col_BOSlipNo2 = "BOSlipNo2";
        /// <summary> BO伝票番号３ </summary>
        public const string ct_Col_BOSlipNo3 = "BOSlipNo3";
        /// <summary> EO引当数 </summary>
        public const string ct_Col_EOAlwcCount = "EOAlwcCount";
        /// <summary> BO管理番号 </summary>
        public const string ct_Col_BOManagementNo = "BOManagementNo";
        /// <summary> 回答定価 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 回答原価単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> UOE代替マーク </summary>
        public const string ct_Col_UOESubstMark = "UOESubstMark";
        /// <summary> UOE在庫マーク </summary>
        public const string ct_Col_UOEStockMark = "UOEStockMark";
        /// <summary> 層別コード </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> UOE出荷拠点コード１（マツダ） </summary>
        public const string ct_Col_MazdaUOEShipSectCd1 = "MazdaUOEShipSectCd1";
        /// <summary> UOE出荷拠点コード２（マツダ） </summary>
        public const string ct_Col_MazdaUOEShipSectCd2 = "MazdaUOEShipSectCd2";
        /// <summary> UOE出荷拠点コード３（マツダ） </summary>
        public const string ct_Col_MazdaUOEShipSectCd3 = "MazdaUOEShipSectCd3";
        /// <summary> UOE拠点コード１（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd1 = "MazdaUOESectCd1";
        /// <summary> UOE拠点コード２（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd2 = "MazdaUOESectCd2";
        /// <summary> UOE拠点コード３（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd3 = "MazdaUOESectCd3";
        /// <summary> UOE拠点コード４（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd4 = "MazdaUOESectCd4";
        /// <summary> UOE拠点コード５（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd5 = "MazdaUOESectCd5";
        /// <summary> UOE拠点コード６（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd6 = "MazdaUOESectCd6";
        /// <summary> UOE拠点コード７（マツダ） </summary>
        public const string ct_Col_MazdaUOESectCd7 = "MazdaUOESectCd7";
        /// <summary> UOE在庫数１（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt1 = "MazdaUOEStockCnt1";
        /// <summary> UOE在庫数２（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt2 = "MazdaUOEStockCnt2";
        /// <summary> UOE在庫数３（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt3 = "MazdaUOEStockCnt3";
        /// <summary> UOE在庫数４（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt4 = "MazdaUOEStockCnt4";
        /// <summary> UOE在庫数５（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt5 = "MazdaUOEStockCnt5";
        /// <summary> UOE在庫数６（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt6 = "MazdaUOEStockCnt6";
        /// <summary> UOE在庫数７（マツダ） </summary>
        public const string ct_Col_MazdaUOEStockCnt7 = "MazdaUOEStockCnt7";
        /// <summary> UOE卸コード </summary>
        public const string ct_Col_UOEDistributionCd = "UOEDistributionCd";
        /// <summary> UOE他コード </summary>
        public const string ct_Col_UOEOtherCd = "UOEOtherCd";
        /// <summary> UOEＨＭコード </summary>
        public const string ct_Col_UOEHMCd = "UOEHMCd";
        /// <summary> ＢＯ数 </summary>
        public const string ct_Col_BOCount = "BOCount";
        /// <summary> UOEマークコード </summary>
        public const string ct_Col_UOEMarkCode = "UOEMarkCode";
        /// <summary> 出荷元 </summary>
        public const string ct_Col_SourceShipment = "SourceShipment";
        /// <summary> アイテムコード </summary>
        public const string ct_Col_ItemCode = "ItemCode";
        /// <summary> UOEチェックコード </summary>
        public const string ct_Col_UOECheckCode = "UOECheckCode";
        /// <summary> ヘッドエラーメッセージ </summary>
        public const string ct_Col_HeadErrorMassage = "HeadErrorMassage";
        /// <summary> ラインエラーメッセージ </summary>
        public const string ct_Col_LineErrorMassage = "LineErrorMassage";
        /// <summary> データ送信区分 </summary>
        public const string ct_Col_DataSendCode = "DataSendCode";
        /// <summary> データ復旧区分 </summary>
        public const string ct_Col_DataRecoverDiv = "DataRecoverDiv";
        /// <summary> 入庫更新区分（拠点） </summary>
        public const string ct_Col_EnterUpdDivSec = "EnterUpdDivSec";
        /// <summary> 入庫更新区分（BO1） </summary>
        public const string ct_Col_EnterUpdDivBO1 = "EnterUpdDivBO1";
        /// <summary> 入庫更新区分（BO2） </summary>
        public const string ct_Col_EnterUpdDivBO2 = "EnterUpdDivBO2";
        /// <summary> 入庫更新区分（BO3） </summary>
        public const string ct_Col_EnterUpdDivBO3 = "EnterUpdDivBO3";
        /// <summary> 入庫更新区分（ﾒｰｶｰ） </summary>
        public const string ct_Col_EnterUpdDivMaker = "EnterUpdDivMaker";
        /// <summary> 入庫更新区分（EO） </summary>
        public const string ct_Col_EnterUpdDivEO = "EnterUpdDivEO";
        /// <summary> 明細関連付けGUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// ＵＯＥ発注データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/01</br>
        /// </remarks>
        public UOEOrderDtlSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/01</br>
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
        /// ＵＯＥ発注作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/01</br>
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
            // システム区分
            dt.Columns.Add(ct_Col_SystemDivCd, typeof(Int32));
            dt.Columns[ct_Col_SystemDivCd].DefaultValue = defValueInt32;
            // UOE発注番号
            dt.Columns.Add(ct_Col_UOESalesOrderNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderNo].DefaultValue = defValueInt32;
            // UOE発注行番号
            dt.Columns.Add(ct_Col_UOESalesOrderRowNo, typeof(Int32));
            dt.Columns[ct_Col_UOESalesOrderRowNo].DefaultValue = defValueInt32;
            // 送信端末番号
            dt.Columns.Add(ct_Col_SendTerminalNo, typeof(Int32));
            dt.Columns[ct_Col_SendTerminalNo].DefaultValue = defValueInt32;
            // UOE発注先コード
            dt.Columns.Add(ct_Col_UOESupplierCd, typeof(Int32));
            dt.Columns[ct_Col_UOESupplierCd].DefaultValue = defValueInt32;
            // UOE発注先名称
            dt.Columns.Add(ct_Col_UOESupplierName, typeof(string));
            dt.Columns[ct_Col_UOESupplierName].DefaultValue = defValuestring;
            // 通信アセンブリID
            dt.Columns.Add(ct_Col_CommAssemblyId, typeof(string));
            dt.Columns[ct_Col_CommAssemblyId].DefaultValue = defValuestring;
            // オンライン番号
            dt.Columns.Add(ct_Col_OnlineNo, typeof(Int32));
            dt.Columns[ct_Col_OnlineNo].DefaultValue = defValueInt32;
            // オンライン行番号
            dt.Columns.Add(ct_Col_OnlineRowNo, typeof(Int32));
            dt.Columns[ct_Col_OnlineRowNo].DefaultValue = defValueInt32;
            // 売上日付
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // 入力日
            dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
            dt.Columns[ct_Col_InputDay].DefaultValue = DateTime.MinValue;
            // データ更新日時
            dt.Columns.Add(ct_Col_DataUpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_DataUpdateDateTime].DefaultValue = DateTime.MinValue;
            // UOE種別
            dt.Columns.Add(ct_Col_UOEKind, typeof(Int32));
            dt.Columns[ct_Col_UOEKind].DefaultValue = defValueInt32;
            // 売上伝票番号
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // 受注ステータス
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // 売上明細通番
            dt.Columns.Add(ct_Col_SalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defValueInt64;
            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // 部門コード
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // 得意先コード
            dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defValueInt32;
            // 得意先略称
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defValuestring;
            // レジ番号
            dt.Columns.Add(ct_Col_CashRegisterNo, typeof(Int32));
            dt.Columns[ct_Col_CashRegisterNo].DefaultValue = defValueInt32;
            // 共通通番
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // 仕入形式
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // 仕入伝票番号
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // 仕入明細通番
            dt.Columns.Add(ct_Col_StockSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNum].DefaultValue = defValueInt64;
            // BO区分
            dt.Columns.Add(ct_Col_BoCode, typeof(string));
            dt.Columns[ct_Col_BoCode].DefaultValue = defValuestring;
            // 納品区分
            dt.Columns.Add(ct_Col_UOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_UOEDeliGoodsDiv].DefaultValue = defValuestring;
            // 納品区分名称
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;
            // フォロー納品区分
            dt.Columns.Add(ct_Col_FollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDiv].DefaultValue = defValuestring;
            // フォロー納品区分名称
            dt.Columns.Add(ct_Col_FollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_FollowDeliGoodsDivNm].DefaultValue = defValuestring;
            // UOE指定拠点
            dt.Columns.Add(ct_Col_UOEResvdSection, typeof(string));
            dt.Columns[ct_Col_UOEResvdSection].DefaultValue = defValuestring;
            // UOE指定拠点名称
            dt.Columns.Add(ct_Col_UOEResvdSectionNm, typeof(string));
            dt.Columns[ct_Col_UOEResvdSectionNm].DefaultValue = defValuestring;
            // 従業員コード
            dt.Columns.Add(ct_Col_EmployeeCode, typeof(string));
            dt.Columns[ct_Col_EmployeeCode].DefaultValue = defValuestring;
            // 従業員名称
            dt.Columns.Add(ct_Col_EmployeeName, typeof(string));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = defValuestring;
            // 商品メーカーコード
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // メーカー名称
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // 商品番号
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // ハイフン無商品番号
            dt.Columns.Add(ct_Col_GoodsNoNoneHyphen, typeof(string));
            dt.Columns[ct_Col_GoodsNoNoneHyphen].DefaultValue = defValuestring;
            // 商品名称
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // 倉庫コード
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // 倉庫名称
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // 倉庫棚番
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // 受注数量
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;
            // 定価（浮動）
            dt.Columns.Add(ct_Col_ListPrice, typeof(Double));
            dt.Columns[ct_Col_ListPrice].DefaultValue = defValueDouble;
            // 原価単価
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defValueDouble;
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // ＵＯＥリマーク１
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defValuestring;
            // ＵＯＥリマーク２
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defValuestring;
            // 受信日付
            dt.Columns.Add(ct_Col_ReceiveDate, typeof(DateTime));
            dt.Columns[ct_Col_ReceiveDate].DefaultValue = DateTime.MinValue;
            // 受信時刻
            dt.Columns.Add(ct_Col_ReceiveTime, typeof(Int32));
            dt.Columns[ct_Col_ReceiveTime].DefaultValue = defValueInt32;
            // 回答メーカーコード
            dt.Columns.Add(ct_Col_AnswerMakerCd, typeof(Int32));
            dt.Columns[ct_Col_AnswerMakerCd].DefaultValue = defValueInt32;
            // 回答品番
            dt.Columns.Add(ct_Col_AnswerPartsNo, typeof(string));
            dt.Columns[ct_Col_AnswerPartsNo].DefaultValue = defValuestring;
            // 回答品名
            dt.Columns.Add(ct_Col_AnswerPartsName, typeof(string));
            dt.Columns[ct_Col_AnswerPartsName].DefaultValue = defValuestring;
            // 代替品番
            dt.Columns.Add(ct_Col_SubstPartsNo, typeof(string));
            dt.Columns[ct_Col_SubstPartsNo].DefaultValue = defValuestring;
            // UOE拠点出庫数
            dt.Columns.Add(ct_Col_UOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectOutGoodsCnt].DefaultValue = defValueInt32;
            // BO出庫数1
            dt.Columns.Add(ct_Col_BOShipmentCnt1, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt1].DefaultValue = defValueInt32;
            // BO出庫数2
            dt.Columns.Add(ct_Col_BOShipmentCnt2, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt2].DefaultValue = defValueInt32;
            // BO出庫数3
            dt.Columns.Add(ct_Col_BOShipmentCnt3, typeof(Int32));
            dt.Columns[ct_Col_BOShipmentCnt3].DefaultValue = defValueInt32;
            // メーカーフォロー数
            dt.Columns.Add(ct_Col_MakerFollowCnt, typeof(Int32));
            dt.Columns[ct_Col_MakerFollowCnt].DefaultValue = defValueInt32;
            // 未出庫数
            dt.Columns.Add(ct_Col_NonShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_NonShipmentCnt].DefaultValue = defValueInt32;
            // UOE拠点在庫数
            dt.Columns.Add(ct_Col_UOESectStockCnt, typeof(Int32));
            dt.Columns[ct_Col_UOESectStockCnt].DefaultValue = defValueInt32;
            // BO在庫数1
            dt.Columns.Add(ct_Col_BOStockCount1, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount1].DefaultValue = defValueInt32;
            // BO在庫数2
            dt.Columns.Add(ct_Col_BOStockCount2, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount2].DefaultValue = defValueInt32;
            // BO在庫数3
            dt.Columns.Add(ct_Col_BOStockCount3, typeof(Int32));
            dt.Columns[ct_Col_BOStockCount3].DefaultValue = defValueInt32;
            // UOE拠点伝票番号
            dt.Columns.Add(ct_Col_UOESectionSlipNo, typeof(string));
            dt.Columns[ct_Col_UOESectionSlipNo].DefaultValue = defValuestring;
            // BO伝票番号１
            dt.Columns.Add(ct_Col_BOSlipNo1, typeof(string));
            dt.Columns[ct_Col_BOSlipNo1].DefaultValue = defValuestring;
            // BO伝票番号２
            dt.Columns.Add(ct_Col_BOSlipNo2, typeof(string));
            dt.Columns[ct_Col_BOSlipNo2].DefaultValue = defValuestring;
            // BO伝票番号３
            dt.Columns.Add(ct_Col_BOSlipNo3, typeof(string));
            dt.Columns[ct_Col_BOSlipNo3].DefaultValue = defValuestring;
            // EO引当数
            dt.Columns.Add(ct_Col_EOAlwcCount, typeof(Int32));
            dt.Columns[ct_Col_EOAlwcCount].DefaultValue = defValueInt32;
            // BO管理番号
            dt.Columns.Add(ct_Col_BOManagementNo, typeof(string));
            dt.Columns[ct_Col_BOManagementNo].DefaultValue = defValuestring;
            // 回答定価
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // 回答原価単価
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // UOE代替マーク
            dt.Columns.Add(ct_Col_UOESubstMark, typeof(string));
            dt.Columns[ct_Col_UOESubstMark].DefaultValue = defValuestring;
            // UOE在庫マーク
            dt.Columns.Add(ct_Col_UOEStockMark, typeof(string));
            dt.Columns[ct_Col_UOEStockMark].DefaultValue = defValuestring;
            // 層別コード
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
            // UOE出荷拠点コード１（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd1].DefaultValue = defValuestring;
            // UOE出荷拠点コード２（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd2].DefaultValue = defValuestring;
            // UOE出荷拠点コード３（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEShipSectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOEShipSectCd3].DefaultValue = defValuestring;
            // UOE拠点コード１（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd1, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd1].DefaultValue = defValuestring;
            // UOE拠点コード２（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd2, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd2].DefaultValue = defValuestring;
            // UOE拠点コード３（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd3, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd3].DefaultValue = defValuestring;
            // UOE拠点コード４（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd4, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd4].DefaultValue = defValuestring;
            // UOE拠点コード５（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd5, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd5].DefaultValue = defValuestring;
            // UOE拠点コード６（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd6, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd6].DefaultValue = defValuestring;
            // UOE拠点コード７（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOESectCd7, typeof(string));
            dt.Columns[ct_Col_MazdaUOESectCd7].DefaultValue = defValuestring;
            // UOE在庫数１（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt1, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt1].DefaultValue = defValueInt32;
            // UOE在庫数２（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt2, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt2].DefaultValue = defValueInt32;
            // UOE在庫数３（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt3, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt3].DefaultValue = defValueInt32;
            // UOE在庫数４（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt4, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt4].DefaultValue = defValueInt32;
            // UOE在庫数５（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt5, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt5].DefaultValue = defValueInt32;
            // UOE在庫数６（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt6, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt6].DefaultValue = defValueInt32;
            // UOE在庫数７（マツダ）
            dt.Columns.Add(ct_Col_MazdaUOEStockCnt7, typeof(Int32));
            dt.Columns[ct_Col_MazdaUOEStockCnt7].DefaultValue = defValueInt32;
            // UOE卸コード
            dt.Columns.Add(ct_Col_UOEDistributionCd, typeof(string));
            dt.Columns[ct_Col_UOEDistributionCd].DefaultValue = defValuestring;
            // UOE他コード
            dt.Columns.Add(ct_Col_UOEOtherCd, typeof(string));
            dt.Columns[ct_Col_UOEOtherCd].DefaultValue = defValuestring;
            // UOEＨＭコード
            dt.Columns.Add(ct_Col_UOEHMCd, typeof(string));
            dt.Columns[ct_Col_UOEHMCd].DefaultValue = defValuestring;
            // ＢＯ数
            dt.Columns.Add(ct_Col_BOCount, typeof(Int32));
            dt.Columns[ct_Col_BOCount].DefaultValue = defValueInt32;
            // UOEマークコード
            dt.Columns.Add(ct_Col_UOEMarkCode, typeof(string));
            dt.Columns[ct_Col_UOEMarkCode].DefaultValue = defValuestring;
            // 出荷元
            dt.Columns.Add(ct_Col_SourceShipment, typeof(string));
            dt.Columns[ct_Col_SourceShipment].DefaultValue = defValuestring;
            // アイテムコード
            dt.Columns.Add(ct_Col_ItemCode, typeof(string));
            dt.Columns[ct_Col_ItemCode].DefaultValue = defValuestring;
            // UOEチェックコード
            dt.Columns.Add(ct_Col_UOECheckCode, typeof(string));
            dt.Columns[ct_Col_UOECheckCode].DefaultValue = defValuestring;
            // ヘッドエラーメッセージ
            dt.Columns.Add(ct_Col_HeadErrorMassage, typeof(string));
            dt.Columns[ct_Col_HeadErrorMassage].DefaultValue = defValuestring;
            // ラインエラーメッセージ
            dt.Columns.Add(ct_Col_LineErrorMassage, typeof(string));
            dt.Columns[ct_Col_LineErrorMassage].DefaultValue = defValuestring;
            // データ送信区分
            dt.Columns.Add(ct_Col_DataSendCode, typeof(Int32));
            dt.Columns[ct_Col_DataSendCode].DefaultValue = defValueInt32;
            // データ復旧区分
            dt.Columns.Add(ct_Col_DataRecoverDiv, typeof(Int32));
            dt.Columns[ct_Col_DataRecoverDiv].DefaultValue = defValueInt32;
            // 入庫更新区分（拠点）
            dt.Columns.Add(ct_Col_EnterUpdDivSec, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivSec].DefaultValue = defValueInt32;
            // 入庫更新区分（BO1）
            dt.Columns.Add(ct_Col_EnterUpdDivBO1, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO1].DefaultValue = defValueInt32;
            // 入庫更新区分（BO2）
            dt.Columns.Add(ct_Col_EnterUpdDivBO2, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO2].DefaultValue = defValueInt32;
            // 入庫更新区分（BO3）
            dt.Columns.Add(ct_Col_EnterUpdDivBO3, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivBO3].DefaultValue = defValueInt32;
            // 入庫更新区分（ﾒｰｶｰ）
            dt.Columns.Add(ct_Col_EnterUpdDivMaker, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivMaker].DefaultValue = defValueInt32;
            // 入庫更新区分（EO）
            dt.Columns.Add(ct_Col_EnterUpdDivEO, typeof(Int32));
            dt.Columns[ct_Col_EnterUpdDivEO].DefaultValue = defValueInt32;
            // 明細関連付けGUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // PrimaryKeyの設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_OnlineNo], dt.Columns[ct_Col_OnlineRowNo] };
        }
        #endregion
    }
}