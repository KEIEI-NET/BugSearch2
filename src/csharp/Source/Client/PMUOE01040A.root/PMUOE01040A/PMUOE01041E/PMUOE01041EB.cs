//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信ＪＮＬ（見積）データテーブルスキーマクラス
// プログラム概要   : ＵＯＥ送受信ＪＮＬ（見積）データテーブル定義を行う
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
	/// ＵＯＥ送受信ＪＮＬ（見積）データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送受信ＪＮＬ（見積）抽出結果テーブルスキーマ</br>
	/// <br>Programmer : 96186　立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class EstmtSndRcvJnlSchema
	{
		#region Public Members
		/// <summary>ＵＯＥ送受信ＪＮＬ（見積）データテーブル名</summary>
		public const string CT_EstmtSndRcvJnlDataTable = "EstmtSndRcvJnlDataTable";

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
        /// <summary> 見積レート </summary>
        public const string ct_Col_EstimateRate = "EstimateRate";
        /// <summary> 選択コード </summary>
        public const string ct_Col_SelectCode = "SelectCode";
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
        /// <summary> 回答定価 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> 本部在庫 </summary>
        public const string ct_Col_HeadQtrsStock = "HeadQtrsStock";
        /// <summary> 拠点在庫 </summary>
        public const string ct_Col_BranchStock = "BranchStock";
        /// <summary> 支店在庫 </summary>
        public const string ct_Col_SectionStock = "SectionStock";
        /// <summary> UOE拠点コード１ </summary>
        public const string ct_Col_UOESectionCode1 = "UOESectionCode1";
        /// <summary> UOE拠点コード２ </summary>
        public const string ct_Col_UOESectionCode2 = "UOESectionCode2";
        /// <summary> UOE拠点コード３ </summary>
        public const string ct_Col_UOESectionCode3 = "UOESectionCode3";
        /// <summary> UOE拠点在庫数１ </summary>
        public const string ct_Col_UOESectionStock1 = "UOESectionStock1";
        /// <summary> UOE拠点在庫数２ </summary>
        public const string ct_Col_UOESectionStock2 = "UOESectionStock2";
        /// <summary> UOE拠点在庫数３ </summary>
        public const string ct_Col_UOESectionStock3 = "UOESectionStock3";
        /// <summary> UOE納期コード </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> UOE代替コード </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> UOE価格コード </summary>
        public const string ct_Col_UOEPriceCode = "UOEPriceCode";
        /// <summary> 回答原価単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> 層別コード </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> ヘッドエラーメッセージ </summary>
        public const string ct_Col_HeadErrorMassage = "HeadErrorMassage";
        /// <summary> ラインエラーメッセージ </summary>
        public const string ct_Col_LineErrorMassage = "LineErrorMassage";
        /// <summary> データ送信区分 </summary>
        public const string ct_Col_DataSendCode = "DataSendCode";
        /// <summary> データ復旧区分 </summary>
        public const string ct_Col_DataRecoverDiv = "DataRecoverDiv";
        #endregion

		#endregion

		#region Constructor
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬ（見積）データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ＵＯＥ送受信ＪＮＬ（見積）データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public EstmtSndRcvJnlSchema()
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
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_EstmtSndRcvJnlDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_EstmtSndRcvJnlDataTable].Clear();
			}
			else
			{
				CreateTable(ref ds);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬ（見積）作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		private static void CreateTable(ref DataSet ds)
		{
			DataTable dt = null;
			// スキーマ設定
			ds.Tables.Add(CT_EstmtSndRcvJnlDataTable);
			dt = ds.Tables[CT_EstmtSndRcvJnlDataTable];

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
            // 見積レート
            dt.Columns.Add(ct_Col_EstimateRate, typeof(string));
            dt.Columns[ct_Col_EstimateRate].DefaultValue = defValuestring;
            // 選択コード
            dt.Columns.Add(ct_Col_SelectCode, typeof(string));
            dt.Columns[ct_Col_SelectCode].DefaultValue = defValuestring;
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
            // 回答定価
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // 売上単価（税抜，浮動）
            dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;
            // 本部在庫
            dt.Columns.Add(ct_Col_HeadQtrsStock, typeof(string));
            dt.Columns[ct_Col_HeadQtrsStock].DefaultValue = defValuestring;
            // 拠点在庫
            dt.Columns.Add(ct_Col_BranchStock, typeof(string));
            dt.Columns[ct_Col_BranchStock].DefaultValue = defValuestring;
            // 支店在庫
            dt.Columns.Add(ct_Col_SectionStock, typeof(string));
            dt.Columns[ct_Col_SectionStock].DefaultValue = defValuestring;
            // UOE拠点コード１
            dt.Columns.Add(ct_Col_UOESectionCode1, typeof(string));
            dt.Columns[ct_Col_UOESectionCode1].DefaultValue = defValuestring;
            // UOE拠点コード２
            dt.Columns.Add(ct_Col_UOESectionCode2, typeof(string));
            dt.Columns[ct_Col_UOESectionCode2].DefaultValue = defValuestring;
            // UOE拠点コード３
            dt.Columns.Add(ct_Col_UOESectionCode3, typeof(string));
            dt.Columns[ct_Col_UOESectionCode3].DefaultValue = defValuestring;
            // UOE拠点在庫数１
            dt.Columns.Add(ct_Col_UOESectionStock1, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock1].DefaultValue = defValueInt32;
            // UOE拠点在庫数２
            dt.Columns.Add(ct_Col_UOESectionStock2, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock2].DefaultValue = defValueInt32;
            // UOE拠点在庫数３
            dt.Columns.Add(ct_Col_UOESectionStock3, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock3].DefaultValue = defValueInt32;
            // UOE納期コード
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defValuestring;
            // UOE代替コード
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defValuestring;
            // UOE価格コード
            dt.Columns.Add(ct_Col_UOEPriceCode, typeof(string));
            dt.Columns[ct_Col_UOEPriceCode].DefaultValue = defValuestring;
            // 回答原価単価
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // 層別コード
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
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

			dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_EnterpriseCode], dt.Columns[ct_Col_UOESupplierCd], dt.Columns[ct_Col_UOESalesOrderNo], dt.Columns[ct_Col_UOESalesOrderRowNo] };

		}
		#endregion
	}
}