//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信ＪＮＬ（在庫）データテーブルスキーマクラス
// プログラム概要   : ＵＯＥ送受信ＪＮＬ（在庫）データテーブル定義を行う
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
	/// ＵＯＥ送受信ＪＮＬ（在庫）データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送受信ＪＮＬ（在庫）抽出結果テーブルスキーマ</br>
	/// <br>Programmer : 96186　立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// </remarks>
	public class StockSndRcvJnlSchema
	{
		#region Public Members
		/// <summary>ＵＯＥ送受信ＪＮＬ（在庫）データテーブル名</summary>
		public const string CT_StockSndRcvJnlDataTable = "StockSndRcvJnlDataTable";

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
        /// <summary> 代替品番（センター） </summary>
        public const string ct_Col_CenterSubstPartsNo = "CenterSubstPartsNo";
        /// <summary> 回答定価 </summary>
        public const string ct_Col_AnswerListPrice = "AnswerListPrice";
        /// <summary> 回答原価単価 </summary>
        public const string ct_Col_AnswerSalesUnitCost = "AnswerSalesUnitCost";
        /// <summary> 商品Ａ価格 </summary>
        public const string ct_Col_GoodsAPrice = "GoodsAPrice";
        /// <summary> UOE中止コード </summary>
        public const string ct_Col_UOEStopCd = "UOEStopCd";
        /// <summary> UOE代替コード </summary>
        public const string ct_Col_UOESubstCode = "UOESubstCode";
        /// <summary> UOE納期コード </summary>
        public const string ct_Col_UOEDelivDateCd = "UOEDelivDateCd";
        /// <summary> 層別コード </summary>
        public const string ct_Col_PartsLayerCd = "PartsLayerCd";
        /// <summary> 販売店仕入単価 </summary>
        public const string ct_Col_ShopStUnitPrice = "ShopStUnitPrice";
        /// <summary> UOE拠点コード１ </summary>
        public const string ct_Col_UOESectionCode1 = "UOESectionCode1";
        /// <summary> UOE拠点コード２ </summary>
        public const string ct_Col_UOESectionCode2 = "UOESectionCode2";
        /// <summary> UOE拠点コード３ </summary>
        public const string ct_Col_UOESectionCode3 = "UOESectionCode3";
        /// <summary> UOE拠点コード４ </summary>
        public const string ct_Col_UOESectionCode4 = "UOESectionCode4";
        /// <summary> UOE拠点コード５ </summary>
        public const string ct_Col_UOESectionCode5 = "UOESectionCode5";
        /// <summary> UOE拠点コード６ </summary>
        public const string ct_Col_UOESectionCode6 = "UOESectionCode6";
        /// <summary> UOE拠点コード７ </summary>
        public const string ct_Col_UOESectionCode7 = "UOESectionCode7";
        /// <summary> UOE拠点コード８ </summary>
        public const string ct_Col_UOESectionCode8 = "UOESectionCode8";
        /// <summary> 本部在庫 </summary>
        public const string ct_Col_HeadQtrsStock = "HeadQtrsStock";
        /// <summary> UOE拠点在庫数１ </summary>
        public const string ct_Col_UOESectionStock1 = "UOESectionStock1";
        /// <summary> UOE拠点在庫数２ </summary>
        public const string ct_Col_UOESectionStock2 = "UOESectionStock2";
        /// <summary> UOE拠点在庫数３ </summary>
        public const string ct_Col_UOESectionStock3 = "UOESectionStock3";
        /// <summary> UOE拠点在庫数４ </summary>
        public const string ct_Col_UOESectionStock4 = "UOESectionStock4";
        /// <summary> UOE拠点在庫数５ </summary>
        public const string ct_Col_UOESectionStock5 = "UOESectionStock5";
        /// <summary> UOE拠点在庫数６ </summary>
        public const string ct_Col_UOESectionStock6 = "UOESectionStock6";
        /// <summary> UOE拠点在庫数７ </summary>
        public const string ct_Col_UOESectionStock7 = "UOESectionStock7";
        /// <summary> UOE拠点在庫数８ </summary>
        public const string ct_Col_UOESectionStock8 = "UOESectionStock8";
        /// <summary> UOE拠点在庫数９ </summary>
        public const string ct_Col_UOESectionStock9 = "UOESectionStock9";
        /// <summary> UOE拠点在庫数１０ </summary>
        public const string ct_Col_UOESectionStock10 = "UOESectionStock10";
        /// <summary> UOE拠点在庫数１１ </summary>
        public const string ct_Col_UOESectionStock11 = "UOESectionStock11";
        /// <summary> UOE拠点在庫数１２ </summary>
        public const string ct_Col_UOESectionStock12 = "UOESectionStock12";
        /// <summary> UOE拠点在庫数１３ </summary>
        public const string ct_Col_UOESectionStock13 = "UOESectionStock13";
        /// <summary> UOE拠点在庫数１４ </summary>
        public const string ct_Col_UOESectionStock14 = "UOESectionStock14";
        /// <summary> UOE拠点在庫数１５ </summary>
        public const string ct_Col_UOESectionStock15 = "UOESectionStock15";
        /// <summary> UOE拠点在庫数１６ </summary>
        public const string ct_Col_UOESectionStock16 = "UOESectionStock16";
        /// <summary> UOE拠点在庫数１７ </summary>
        public const string ct_Col_UOESectionStock17 = "UOESectionStock17";
        /// <summary> UOE拠点在庫数１８ </summary>
        public const string ct_Col_UOESectionStock18 = "UOESectionStock18";
        /// <summary> UOE拠点在庫数１９ </summary>
        public const string ct_Col_UOESectionStock19 = "UOESectionStock19";
        /// <summary> UOE拠点在庫数２０ </summary>
        public const string ct_Col_UOESectionStock20 = "UOESectionStock20";
        /// <summary> UOE拠点在庫数２１ </summary>
        public const string ct_Col_UOESectionStock21 = "UOESectionStock21";
        /// <summary> UOE拠点在庫数２２ </summary>
        public const string ct_Col_UOESectionStock22 = "UOESectionStock22";
        /// <summary> UOE拠点在庫数２３ </summary>
        public const string ct_Col_UOESectionStock23 = "UOESectionStock23";
        /// <summary> UOE拠点在庫数２４ </summary>
        public const string ct_Col_UOESectionStock24 = "UOESectionStock24";
        /// <summary> UOE拠点在庫数２５ </summary>
        public const string ct_Col_UOESectionStock25 = "UOESectionStock25";
        /// <summary> UOE拠点在庫数２６ </summary>
        public const string ct_Col_UOESectionStock26 = "UOESectionStock26";
        /// <summary> UOE拠点在庫数２７ </summary>
        public const string ct_Col_UOESectionStock27 = "UOESectionStock27";
        /// <summary> UOE拠点在庫数２８ </summary>
        public const string ct_Col_UOESectionStock28 = "UOESectionStock28";
        /// <summary> UOE拠点在庫数２９ </summary>
        public const string ct_Col_UOESectionStock29 = "UOESectionStock29";
        /// <summary> UOE拠点在庫数３０ </summary>
        public const string ct_Col_UOESectionStock30 = "UOESectionStock30";
        /// <summary> UOE拠点在庫数３１ </summary>
        public const string ct_Col_UOESectionStock31 = "UOESectionStock31";
        /// <summary> UOE拠点在庫数３２ </summary>
        public const string ct_Col_UOESectionStock32 = "UOESectionStock32";
        /// <summary> UOE拠点在庫数３３ </summary>
        public const string ct_Col_UOESectionStock33 = "UOESectionStock33";
        /// <summary> UOE拠点在庫数３４ </summary>
        public const string ct_Col_UOESectionStock34 = "UOESectionStock34";
        /// <summary> UOE拠点在庫数３５ </summary>
        public const string ct_Col_UOESectionStock35 = "UOESectionStock35";
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
		/// ＵＯＥ送受信ＪＮＬ（在庫）データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ＵＯＥ送受信ＪＮＬ（在庫）データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 96186　立花裕輔</br>
		/// <br>Date       : 2008.05.26</br>
		/// </remarks>
		public StockSndRcvJnlSchema()
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
			if ((ds.Tables.Contains(CT_StockSndRcvJnlDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_StockSndRcvJnlDataTable].Clear();
			}
			else
			{
				CreateTable(ref ds);

			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬ（在庫）作成処理
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
			ds.Tables.Add(CT_StockSndRcvJnlDataTable);
			dt = ds.Tables[CT_StockSndRcvJnlDataTable];

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
            // 代替品番（センター）
            dt.Columns.Add(ct_Col_CenterSubstPartsNo, typeof(string));
            dt.Columns[ct_Col_CenterSubstPartsNo].DefaultValue = defValuestring;
            // 回答定価
            dt.Columns.Add(ct_Col_AnswerListPrice, typeof(Double));
            dt.Columns[ct_Col_AnswerListPrice].DefaultValue = defValueDouble;
            // 回答原価単価
            dt.Columns.Add(ct_Col_AnswerSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_AnswerSalesUnitCost].DefaultValue = defValueDouble;
            // 商品Ａ価格
            dt.Columns.Add(ct_Col_GoodsAPrice, typeof(Double));
            dt.Columns[ct_Col_GoodsAPrice].DefaultValue = defValueDouble;
            // UOE中止コード
            dt.Columns.Add(ct_Col_UOEStopCd, typeof(string));
            dt.Columns[ct_Col_UOEStopCd].DefaultValue = defValuestring;
            // UOE代替コード
            dt.Columns.Add(ct_Col_UOESubstCode, typeof(string));
            dt.Columns[ct_Col_UOESubstCode].DefaultValue = defValuestring;
            // UOE納期コード
            dt.Columns.Add(ct_Col_UOEDelivDateCd, typeof(string));
            dt.Columns[ct_Col_UOEDelivDateCd].DefaultValue = defValuestring;
            // 層別コード
            dt.Columns.Add(ct_Col_PartsLayerCd, typeof(string));
            dt.Columns[ct_Col_PartsLayerCd].DefaultValue = defValuestring;
            // 販売店仕入単価
            dt.Columns.Add(ct_Col_ShopStUnitPrice, typeof(Double));
            dt.Columns[ct_Col_ShopStUnitPrice].DefaultValue = defValueDouble;
            // UOE拠点コード１
            dt.Columns.Add(ct_Col_UOESectionCode1, typeof(string));
            dt.Columns[ct_Col_UOESectionCode1].DefaultValue = defValuestring;
            // UOE拠点コード２
            dt.Columns.Add(ct_Col_UOESectionCode2, typeof(string));
            dt.Columns[ct_Col_UOESectionCode2].DefaultValue = defValuestring;
            // UOE拠点コード３
            dt.Columns.Add(ct_Col_UOESectionCode3, typeof(string));
            dt.Columns[ct_Col_UOESectionCode3].DefaultValue = defValuestring;
            // UOE拠点コード４
            dt.Columns.Add(ct_Col_UOESectionCode4, typeof(string));
            dt.Columns[ct_Col_UOESectionCode4].DefaultValue = defValuestring;
            // UOE拠点コード５
            dt.Columns.Add(ct_Col_UOESectionCode5, typeof(string));
            dt.Columns[ct_Col_UOESectionCode5].DefaultValue = defValuestring;
            // UOE拠点コード６
            dt.Columns.Add(ct_Col_UOESectionCode6, typeof(string));
            dt.Columns[ct_Col_UOESectionCode6].DefaultValue = defValuestring;
            // UOE拠点コード７
            dt.Columns.Add(ct_Col_UOESectionCode7, typeof(string));
            dt.Columns[ct_Col_UOESectionCode7].DefaultValue = defValuestring;
            // UOE拠点コード８
            dt.Columns.Add(ct_Col_UOESectionCode8, typeof(string));
            dt.Columns[ct_Col_UOESectionCode8].DefaultValue = defValuestring;
            // 本部在庫
            dt.Columns.Add(ct_Col_HeadQtrsStock, typeof(string));
            dt.Columns[ct_Col_HeadQtrsStock].DefaultValue = defValuestring;
            // UOE拠点在庫数１
            dt.Columns.Add(ct_Col_UOESectionStock1, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock1].DefaultValue = defValueInt32;
            // UOE拠点在庫数２
            dt.Columns.Add(ct_Col_UOESectionStock2, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock2].DefaultValue = defValueInt32;
            // UOE拠点在庫数３
            dt.Columns.Add(ct_Col_UOESectionStock3, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock3].DefaultValue = defValueInt32;
            // UOE拠点在庫数４
            dt.Columns.Add(ct_Col_UOESectionStock4, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock4].DefaultValue = defValueInt32;
            // UOE拠点在庫数５
            dt.Columns.Add(ct_Col_UOESectionStock5, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock5].DefaultValue = defValueInt32;
            // UOE拠点在庫数６
            dt.Columns.Add(ct_Col_UOESectionStock6, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock6].DefaultValue = defValueInt32;
            // UOE拠点在庫数７
            dt.Columns.Add(ct_Col_UOESectionStock7, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock7].DefaultValue = defValueInt32;
            // UOE拠点在庫数８
            dt.Columns.Add(ct_Col_UOESectionStock8, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock8].DefaultValue = defValueInt32;
            // UOE拠点在庫数９
            dt.Columns.Add(ct_Col_UOESectionStock9, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock9].DefaultValue = defValueInt32;
            // UOE拠点在庫数１０
            dt.Columns.Add(ct_Col_UOESectionStock10, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock10].DefaultValue = defValueInt32;
            // UOE拠点在庫数１１
            dt.Columns.Add(ct_Col_UOESectionStock11, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock11].DefaultValue = defValueInt32;
            // UOE拠点在庫数１２
            dt.Columns.Add(ct_Col_UOESectionStock12, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock12].DefaultValue = defValueInt32;
            // UOE拠点在庫数１３
            dt.Columns.Add(ct_Col_UOESectionStock13, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock13].DefaultValue = defValueInt32;
            // UOE拠点在庫数１４
            dt.Columns.Add(ct_Col_UOESectionStock14, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock14].DefaultValue = defValueInt32;
            // UOE拠点在庫数１５
            dt.Columns.Add(ct_Col_UOESectionStock15, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock15].DefaultValue = defValueInt32;
            // UOE拠点在庫数１６
            dt.Columns.Add(ct_Col_UOESectionStock16, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock16].DefaultValue = defValueInt32;
            // UOE拠点在庫数１７
            dt.Columns.Add(ct_Col_UOESectionStock17, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock17].DefaultValue = defValueInt32;
            // UOE拠点在庫数１８
            dt.Columns.Add(ct_Col_UOESectionStock18, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock18].DefaultValue = defValueInt32;
            // UOE拠点在庫数１９
            dt.Columns.Add(ct_Col_UOESectionStock19, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock19].DefaultValue = defValueInt32;
            // UOE拠点在庫数２０
            dt.Columns.Add(ct_Col_UOESectionStock20, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock20].DefaultValue = defValueInt32;
            // UOE拠点在庫数２１
            dt.Columns.Add(ct_Col_UOESectionStock21, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock21].DefaultValue = defValueInt32;
            // UOE拠点在庫数２２
            dt.Columns.Add(ct_Col_UOESectionStock22, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock22].DefaultValue = defValueInt32;
            // UOE拠点在庫数２３
            dt.Columns.Add(ct_Col_UOESectionStock23, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock23].DefaultValue = defValueInt32;
            // UOE拠点在庫数２４
            dt.Columns.Add(ct_Col_UOESectionStock24, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock24].DefaultValue = defValueInt32;
            // UOE拠点在庫数２５
            dt.Columns.Add(ct_Col_UOESectionStock25, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock25].DefaultValue = defValueInt32;
            // UOE拠点在庫数２６
            dt.Columns.Add(ct_Col_UOESectionStock26, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock26].DefaultValue = defValueInt32;
            // UOE拠点在庫数２７
            dt.Columns.Add(ct_Col_UOESectionStock27, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock27].DefaultValue = defValueInt32;
            // UOE拠点在庫数２８
            dt.Columns.Add(ct_Col_UOESectionStock28, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock28].DefaultValue = defValueInt32;
            // UOE拠点在庫数２９
            dt.Columns.Add(ct_Col_UOESectionStock29, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock29].DefaultValue = defValueInt32;
            // UOE拠点在庫数３０
            dt.Columns.Add(ct_Col_UOESectionStock30, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock30].DefaultValue = defValueInt32;
            // UOE拠点在庫数３１
            dt.Columns.Add(ct_Col_UOESectionStock31, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock31].DefaultValue = defValueInt32;
            // UOE拠点在庫数３２
            dt.Columns.Add(ct_Col_UOESectionStock32, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock32].DefaultValue = defValueInt32;
            // UOE拠点在庫数３３
            dt.Columns.Add(ct_Col_UOESectionStock33, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock33].DefaultValue = defValueInt32;
            // UOE拠点在庫数３４
            dt.Columns.Add(ct_Col_UOESectionStock34, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock34].DefaultValue = defValueInt32;
            // UOE拠点在庫数３５
            dt.Columns.Add(ct_Col_UOESectionStock35, typeof(Int32));
            dt.Columns[ct_Col_UOESectionStock35].DefaultValue = defValueInt32;
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