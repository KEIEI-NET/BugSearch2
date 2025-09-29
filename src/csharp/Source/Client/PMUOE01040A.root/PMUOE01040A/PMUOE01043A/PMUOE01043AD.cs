//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信ＪＮＬ（在庫）アクセスクラス
// プログラム概要   : ＵＯＥ送受信ＪＮＬ（在庫）アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 送受信ＪＮＬ（在庫）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 送受信ＪＮＬ（在庫）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

        # region ＵＯＥ発注データ→ＵＯＥ送受信ＪＮＬ＜在庫＞
        /// <summary>
        /// ＵＯＥ発注データ→ＵＯＥ送受信ＪＮＬ＜在庫＞
        /// </summary>
        /// <param name="mode">0:新規 1:更新</param>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int stockJnlFromDtlWrite(List<UOEOrderDtlWork> uOEOrderDtlWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                StockSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);

                List<StockSndRcvJnl> JnlList = GetToStockFromOrderDtl(uOEOrderDtlWork);
                foreach (StockSndRcvJnl rst in JnlList)
                {
                    //送受信ＪＮＬの保存
                    DataRow dr = StockTable.NewRow();
                    CreateStockSchemaFromJnl(ref dr, rst);
                    StockTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

		# region 送受信ＪＮＬ（在確）データテーブルRow作成
		/// <summary>
		/// 送受信ＪＮＬ（在確）データテーブルRow作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private void CreateStockSchemaFromJnl(ref DataRow dr, StockSndRcvJnl rst)
		{
            dr[StockSndRcvJnlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime; // 作成日時
            dr[StockSndRcvJnlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime; // 更新日時
            dr[StockSndRcvJnlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode; // 企業コード
            //dr[StockSndRcvJnlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid; // GUID
            dr[StockSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode; // 更新従業員コード
            dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1; // 更新アセンブリID1
            dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2; // 更新アセンブリID2
            dr[StockSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode; // 論理削除区分
            dr[StockSndRcvJnlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd; // システム区分
            dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo; // UOE発注番号
            dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo; // UOE発注行番号
            dr[StockSndRcvJnlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo; // 送信端末番号
            dr[StockSndRcvJnlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd; // UOE発注先コード
            dr[StockSndRcvJnlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName; // UOE発注先名称
            dr[StockSndRcvJnlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId; // 通信アセンブリID
            dr[StockSndRcvJnlSchema.ct_Col_OnlineNo] = rst.OnlineNo; // オンライン番号
            dr[StockSndRcvJnlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo; // オンライン行番号
            dr[StockSndRcvJnlSchema.ct_Col_SalesDate] = rst.SalesDate; // 売上日付
            dr[StockSndRcvJnlSchema.ct_Col_InputDay] = rst.InputDay; // 入力日
            dr[StockSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime; // データ更新日時
            dr[StockSndRcvJnlSchema.ct_Col_UOEKind] = rst.UOEKind; // UOE種別
            dr[StockSndRcvJnlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum; // 売上伝票番号
            dr[StockSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus; // 受注ステータス
            dr[StockSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum; // 売上明細通番
            dr[StockSndRcvJnlSchema.ct_Col_SectionCode] = rst.SectionCode; // 拠点コード
            dr[StockSndRcvJnlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode; // 部門コード
            dr[StockSndRcvJnlSchema.ct_Col_CustomerCode] = rst.CustomerCode; // 得意先コード
            dr[StockSndRcvJnlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm; // 得意先略称
            dr[StockSndRcvJnlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo; // レジ番号
            dr[StockSndRcvJnlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo; // 共通通番
            dr[StockSndRcvJnlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal; // 仕入形式
            dr[StockSndRcvJnlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo; // 仕入伝票番号
            dr[StockSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum; // 仕入明細通番
            dr[StockSndRcvJnlSchema.ct_Col_BoCode] = rst.BoCode; // BO区分
            dr[StockSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv; // 納品区分
            dr[StockSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm; // 納品区分名称
            dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv; // フォロー納品区分
            dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm; // フォロー納品区分名称
            dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection; // UOE指定拠点
            dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm; // UOE指定拠点名称
            dr[StockSndRcvJnlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode; // 従業員コード
            dr[StockSndRcvJnlSchema.ct_Col_EmployeeName] = rst.EmployeeName; // 従業員名称
            dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd; // 商品メーカーコード
            dr[StockSndRcvJnlSchema.ct_Col_MakerName] = rst.MakerName; // メーカー名称
            dr[StockSndRcvJnlSchema.ct_Col_GoodsNo] = rst.GoodsNo; // 商品番号
            dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen; // ハイフン無商品番号
            dr[StockSndRcvJnlSchema.ct_Col_GoodsName] = rst.GoodsName; // 商品名称
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode; // 倉庫コード
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseName] = rst.WarehouseName; // 倉庫名称
            dr[StockSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo; // 倉庫棚番
            dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt; // 受注数量
            dr[StockSndRcvJnlSchema.ct_Col_ListPrice] = rst.ListPrice; // 定価（浮動）
            dr[StockSndRcvJnlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost; // 原価単価
            dr[StockSndRcvJnlSchema.ct_Col_SupplierCd] = rst.SupplierCd; // 仕入先コード
            dr[StockSndRcvJnlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm; // 仕入先略称
            dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1; // ＵＯＥリマーク１
            dr[StockSndRcvJnlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2; // ＵＯＥリマーク２
            dr[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate; // 受信日付
            dr[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime; // 受信時刻
            dr[StockSndRcvJnlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd; // 回答メーカーコード
            dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo; // 回答品番
            dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName; // 回答品名
            dr[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo; // 代替品番
            dr[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo] = rst.CenterSubstPartsNo; // 代替品番（センター）
            dr[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice; // 回答定価
            dr[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost; // 回答原価単価
            dr[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = rst.GoodsAPrice; // 商品Ａ価格
            dr[StockSndRcvJnlSchema.ct_Col_UOEStopCd] = rst.UOEStopCd; // UOE中止コード
            dr[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = rst.UOESubstCode; // UOE代替コード
            dr[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = rst.UOEDelivDateCd; // UOE納期コード
            dr[StockSndRcvJnlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd; // 層別コード
            dr[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice] = rst.ShopStUnitPrice; // 販売店仕入単価
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode1] = rst.UOESectionCode1; // UOE拠点コード１
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode2] = rst.UOESectionCode2; // UOE拠点コード２
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode3] = rst.UOESectionCode3; // UOE拠点コード３
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode4] = rst.UOESectionCode4; // UOE拠点コード４
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode5] = rst.UOESectionCode5; // UOE拠点コード５
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode6] = rst.UOESectionCode6; // UOE拠点コード６
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode7] = rst.UOESectionCode7; // UOE拠点コード７
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode8] = rst.UOESectionCode8; // UOE拠点コード８
            dr[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = rst.HeadQtrsStock; // 本部在庫
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = rst.UOESectionStock1; // UOE拠点在庫数１
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = rst.UOESectionStock2; // UOE拠点在庫数２
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = rst.UOESectionStock3; // UOE拠点在庫数３
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = rst.UOESectionStock4; // UOE拠点在庫数４
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = rst.UOESectionStock5; // UOE拠点在庫数５
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = rst.UOESectionStock6; // UOE拠点在庫数６
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = rst.UOESectionStock7; // UOE拠点在庫数７
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = rst.UOESectionStock8; // UOE拠点在庫数８
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = rst.UOESectionStock9; // UOE拠点在庫数９
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = rst.UOESectionStock10; // UOE拠点在庫数１０
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = rst.UOESectionStock11; // UOE拠点在庫数１１
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = rst.UOESectionStock12; // UOE拠点在庫数１２
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = rst.UOESectionStock13; // UOE拠点在庫数１３
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = rst.UOESectionStock14; // UOE拠点在庫数１４
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = rst.UOESectionStock15; // UOE拠点在庫数１５
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = rst.UOESectionStock16; // UOE拠点在庫数１６
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = rst.UOESectionStock17; // UOE拠点在庫数１７
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = rst.UOESectionStock18; // UOE拠点在庫数１８
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = rst.UOESectionStock19; // UOE拠点在庫数１９
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = rst.UOESectionStock20; // UOE拠点在庫数２０
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = rst.UOESectionStock21; // UOE拠点在庫数２１
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = rst.UOESectionStock22; // UOE拠点在庫数２２
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = rst.UOESectionStock23; // UOE拠点在庫数２３
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = rst.UOESectionStock24; // UOE拠点在庫数２４
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = rst.UOESectionStock25; // UOE拠点在庫数２５
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = rst.UOESectionStock26; // UOE拠点在庫数２６
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = rst.UOESectionStock27; // UOE拠点在庫数２７
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = rst.UOESectionStock28; // UOE拠点在庫数２８
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = rst.UOESectionStock29; // UOE拠点在庫数２９
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = rst.UOESectionStock30; // UOE拠点在庫数３０
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = rst.UOESectionStock31; // UOE拠点在庫数３１
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock32] = rst.UOESectionStock32; // UOE拠点在庫数３２
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock33] = rst.UOESectionStock33; // UOE拠点在庫数３３
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock34] = rst.UOESectionStock34; // UOE拠点在庫数３４
            dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock35] = rst.UOESectionStock35; // UOE拠点在庫数３５
            dr[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage; // ヘッドエラーメッセージ
            dr[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage; // ラインエラーメッセージ
            dr[StockSndRcvJnlSchema.ct_Col_DataSendCode] = rst.DataSendCode; // データ送信区分
            dr[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv; // データ復旧区分
        }
		# endregion

		# region 送受信ＪＮＬ（在庫）＜DataRow → クラス＞作成
		/// <summary>
		/// 送受信ＪＮＬ（在庫）＜DataRow → クラス＞作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private StockSndRcvJnl CreateStockJnlFromSchema(ref DataRow dr)
		{
			StockSndRcvJnl rst = new StockSndRcvJnl();

            //rst.CreateDateTime = (Int64)dr[StockSndRcvJnlSchema.ct_Col_CreateDateTime]; // 作成日時
            //rst.UpdateDateTime = (Int64)dr[StockSndRcvJnlSchema.ct_Col_UpdateDateTime]; // 更新日時
            rst.EnterpriseCode = (string)dr[StockSndRcvJnlSchema.ct_Col_EnterpriseCode]; // 企業コード
            //rst.FileHeaderGuid = (Guid)dr[StockSndRcvJnlSchema.ct_Col_FileHeaderGuid]; // GUID
            rst.UpdEmployeeCode = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdEmployeeCode]; // 更新従業員コード
            rst.UpdAssemblyId1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId1]; // 更新アセンブリID1
            rst.UpdAssemblyId2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UpdAssemblyId2]; // 更新アセンブリID2
            rst.LogicalDeleteCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_LogicalDeleteCode]; // 論理削除区分
            rst.SystemDivCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SystemDivCd]; // システム区分
            rst.UOESalesOrderNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]; // UOE発注番号
            rst.UOESalesOrderRowNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]; // UOE発注行番号
            rst.SendTerminalNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SendTerminalNo]; // 送信端末番号
            rst.UOESupplierCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESupplierCd]; // UOE発注先コード
            rst.UOESupplierName = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESupplierName]; // UOE発注先名称
            rst.CommAssemblyId = (string)dr[StockSndRcvJnlSchema.ct_Col_CommAssemblyId]; // 通信アセンブリID
            rst.OnlineNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_OnlineNo]; // オンライン番号
            rst.OnlineRowNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_OnlineRowNo]; // オンライン行番号
            rst.SalesDate = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_SalesDate]; // 売上日付
            rst.InputDay = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_InputDay]; // 入力日
            rst.DataUpdateDateTime = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_DataUpdateDateTime]; // データ更新日時
            rst.UOEKind = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOEKind]; // UOE種別
            rst.SalesSlipNum = (string)dr[StockSndRcvJnlSchema.ct_Col_SalesSlipNum]; // 売上伝票番号
            rst.AcptAnOdrStatus = (Int32)dr[StockSndRcvJnlSchema.ct_Col_AcptAnOdrStatus]; // 受注ステータス
            rst.SalesSlipDtlNum = (Int64)dr[StockSndRcvJnlSchema.ct_Col_SalesSlipDtlNum]; // 売上明細通番
            rst.SectionCode = (string)dr[StockSndRcvJnlSchema.ct_Col_SectionCode]; // 拠点コード
            rst.SubSectionCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SubSectionCode]; // 部門コード
            rst.CustomerCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_CustomerCode]; // 得意先コード
            rst.CustomerSnm = (string)dr[StockSndRcvJnlSchema.ct_Col_CustomerSnm]; // 得意先略称
            rst.CashRegisterNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_CashRegisterNo]; // レジ番号
            rst.CommonSeqNo = (Int64)dr[StockSndRcvJnlSchema.ct_Col_CommonSeqNo]; // 共通通番
            rst.SupplierFormal = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierFormal]; // 仕入形式
            rst.SupplierSlipNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierSlipNo]; // 仕入伝票番号
            rst.StockSlipDtlNum = (Int64)dr[StockSndRcvJnlSchema.ct_Col_StockSlipDtlNum]; // 仕入明細通番
            rst.BoCode = (string)dr[StockSndRcvJnlSchema.ct_Col_BoCode]; // BO区分
            rst.UOEDeliGoodsDiv = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv]; // 納品区分
            rst.DeliveredGoodsDivNm = (string)dr[StockSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm]; // 納品区分名称
            rst.FollowDeliGoodsDiv = (string)dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv]; // フォロー納品区分
            rst.FollowDeliGoodsDivNm = (string)dr[StockSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm]; // フォロー納品区分名称
            rst.UOEResvdSection = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSection]; // UOE指定拠点
            rst.UOEResvdSectionNm = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEResvdSectionNm]; // UOE指定拠点名称
            rst.EmployeeCode = (string)dr[StockSndRcvJnlSchema.ct_Col_EmployeeCode]; // 従業員コード
            rst.EmployeeName = (string)dr[StockSndRcvJnlSchema.ct_Col_EmployeeName]; // 従業員名称
            rst.GoodsMakerCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd]; // 商品メーカーコード
            rst.MakerName = (string)dr[StockSndRcvJnlSchema.ct_Col_MakerName]; // メーカー名称
            rst.GoodsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNo]; // 商品番号
            rst.GoodsNoNoneHyphen = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen]; // ハイフン無商品番号
            rst.GoodsName = (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsName]; // 商品名称
            rst.WarehouseCode = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseCode]; // 倉庫コード
            rst.WarehouseName = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseName]; // 倉庫名称
            rst.WarehouseShelfNo = (string)dr[StockSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; // 倉庫棚番
            rst.AcceptAnOrderCnt = (Double)dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt]; // 受注数量
            rst.ListPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_ListPrice]; // 定価（浮動）
            rst.SalesUnitCost = (Double)dr[StockSndRcvJnlSchema.ct_Col_SalesUnitCost]; // 原価単価
            rst.SupplierCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_SupplierCd]; // 仕入先コード
            rst.SupplierSnm = (string)dr[StockSndRcvJnlSchema.ct_Col_SupplierSnm]; // 仕入先略称
            rst.UoeRemark1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1]; // ＵＯＥリマーク１
            rst.UoeRemark2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark2]; // ＵＯＥリマーク２
            rst.ReceiveDate = (DateTime)dr[StockSndRcvJnlSchema.ct_Col_ReceiveDate]; // 受信日付
            rst.ReceiveTime = (Int32)dr[StockSndRcvJnlSchema.ct_Col_ReceiveTime]; // 受信時刻
            rst.AnswerMakerCd = (Int32)dr[StockSndRcvJnlSchema.ct_Col_AnswerMakerCd]; // 回答メーカーコード
            rst.AnswerPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo]; // 回答品番
            rst.AnswerPartsName = (string)dr[StockSndRcvJnlSchema.ct_Col_AnswerPartsName]; // 回答品名
            rst.SubstPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_SubstPartsNo]; // 代替品番
            rst.CenterSubstPartsNo = (string)dr[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo]; // 代替品番（センター）
            rst.AnswerListPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_AnswerListPrice]; // 回答定価
            rst.AnswerSalesUnitCost = (Double)dr[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost]; // 回答原価単価
            rst.GoodsAPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_GoodsAPrice]; // 商品Ａ価格
            rst.UOEStopCd = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEStopCd]; // UOE中止コード
            rst.UOESubstCode = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESubstCode]; // UOE代替コード
            rst.UOEDelivDateCd = (string)dr[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd]; // UOE納期コード
            rst.PartsLayerCd = (string)dr[StockSndRcvJnlSchema.ct_Col_PartsLayerCd]; // 層別コード
            rst.ShopStUnitPrice = (Double)dr[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice]; // 販売店仕入単価
            rst.UOESectionCode1 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode1]; // UOE拠点コード１
            rst.UOESectionCode2 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode2]; // UOE拠点コード２
            rst.UOESectionCode3 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode3]; // UOE拠点コード３
            rst.UOESectionCode4 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode4]; // UOE拠点コード４
            rst.UOESectionCode5 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode5]; // UOE拠点コード５
            rst.UOESectionCode6 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode6]; // UOE拠点コード６
            rst.UOESectionCode7 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode7]; // UOE拠点コード７
            rst.UOESectionCode8 = (string)dr[StockSndRcvJnlSchema.ct_Col_UOESectionCode8]; // UOE拠点コード８
            rst.HeadQtrsStock = (string)dr[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock]; // 本部在庫
            rst.UOESectionStock1 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock1]; // UOE拠点在庫数１
            rst.UOESectionStock2 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock2]; // UOE拠点在庫数２
            rst.UOESectionStock3 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock3]; // UOE拠点在庫数３
            rst.UOESectionStock4 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock4]; // UOE拠点在庫数４
            rst.UOESectionStock5 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock5]; // UOE拠点在庫数５
            rst.UOESectionStock6 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock6]; // UOE拠点在庫数６
            rst.UOESectionStock7 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock7]; // UOE拠点在庫数７
            rst.UOESectionStock8 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock8]; // UOE拠点在庫数８
            rst.UOESectionStock9 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock9]; // UOE拠点在庫数９
            rst.UOESectionStock10 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock10]; // UOE拠点在庫数１０
            rst.UOESectionStock11 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock11]; // UOE拠点在庫数１１
            rst.UOESectionStock12 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock12]; // UOE拠点在庫数１２
            rst.UOESectionStock13 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock13]; // UOE拠点在庫数１３
            rst.UOESectionStock14 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock14]; // UOE拠点在庫数１４
            rst.UOESectionStock15 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock15]; // UOE拠点在庫数１５
            rst.UOESectionStock16 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock16]; // UOE拠点在庫数１６
            rst.UOESectionStock17 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock17]; // UOE拠点在庫数１７
            rst.UOESectionStock18 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock18]; // UOE拠点在庫数１８
            rst.UOESectionStock19 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock19]; // UOE拠点在庫数１９
            rst.UOESectionStock20 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock20]; // UOE拠点在庫数２０
            rst.UOESectionStock21 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock21]; // UOE拠点在庫数２１
            rst.UOESectionStock22 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock22]; // UOE拠点在庫数２２
            rst.UOESectionStock23 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock23]; // UOE拠点在庫数２３
            rst.UOESectionStock24 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock24]; // UOE拠点在庫数２４
            rst.UOESectionStock25 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock25]; // UOE拠点在庫数２５
            rst.UOESectionStock26 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock26]; // UOE拠点在庫数２６
            rst.UOESectionStock27 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock27]; // UOE拠点在庫数２７
            rst.UOESectionStock28 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock28]; // UOE拠点在庫数２８
            rst.UOESectionStock29 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock29]; // UOE拠点在庫数２９
            rst.UOESectionStock30 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock30]; // UOE拠点在庫数３０
            rst.UOESectionStock31 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock31]; // UOE拠点在庫数３１
            rst.UOESectionStock32 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock32]; // UOE拠点在庫数３２
            rst.UOESectionStock33 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock33]; // UOE拠点在庫数３３
            rst.UOESectionStock34 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock34]; // UOE拠点在庫数３４
            rst.UOESectionStock35 = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESectionStock35]; // UOE拠点在庫数３５
            rst.HeadErrorMassage = (string)dr[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage]; // ヘッドエラーメッセージ
            rst.LineErrorMassage = (string)dr[StockSndRcvJnlSchema.ct_Col_LineErrorMassage]; // ラインエラーメッセージ
            rst.DataSendCode = (Int32)dr[StockSndRcvJnlSchema.ct_Col_DataSendCode]; // データ送信区分
            rst.DataRecoverDiv = (Int32)dr[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv]; // データ復旧区分

			return (rst);
		}
		# endregion

		# endregion
	}
}
