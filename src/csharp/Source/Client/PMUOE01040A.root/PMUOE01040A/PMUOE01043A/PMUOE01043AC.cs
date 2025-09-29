//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信ＪＮＬ（見積）アクセスクラス
// プログラム概要   : ＵＯＥ送受信ＪＮＬ（見積）アクセスを行う
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
	/// 送受信ＪＮＬ（見積）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 送受信ＪＮＬ（見積）アクセスクラス</br>
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

        # region ＵＯＥ発注データ→ＵＯＥ送受信ＪＮＬ＜見積＞
        /// <summary>
        /// ＵＯＥ発注データ→ＵＯＥ送受信ＪＮＬ＜見積＞
        /// </summary>
        /// <param name="mode">0:新規 1:更新</param>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int estmtJnlFromDtlWrite(List<UOEOrderDtlWork> uOEOrderDtlWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                EstmtSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);

                List<EstmtSndRcvJnl> JnlList = GetToEstmtFromOrderDtl(uOEOrderDtlWork);

                foreach (EstmtSndRcvJnl rst in JnlList)
                {
                    //送受信ＪＮＬの保存
                    DataRow dr = EstmtTable.NewRow();
                    CreateEstmSchemaFromJnl(ref dr, rst);
                    EstmtTable.Rows.Add(dr);
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

		# region 送受信ＪＮＬ（見積）データテーブルRow作成
		/// <summary>
		/// 送受信ＪＮＬ（見積）データテーブルRow作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private void CreateEstmSchemaFromJnl(ref DataRow dr, EstmtSndRcvJnl rst)
		{
            dr[EstmtSndRcvJnlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime; // 作成日時
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime; // 更新日時
            dr[EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode; // 企業コード
            //dr[EstmtSndRcvJnlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid; // GUID
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode; // 更新従業員コード
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1; // 更新アセンブリID1
            dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2; // 更新アセンブリID2
            dr[EstmtSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode; // 論理削除区分
            dr[EstmtSndRcvJnlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd; // システム区分
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo; // UOE発注番号
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo; // UOE発注行番号
            dr[EstmtSndRcvJnlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo; // 送信端末番号
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd; // UOE発注先コード
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName; // UOE発注先名称
            dr[EstmtSndRcvJnlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId; // 通信アセンブリID
            dr[EstmtSndRcvJnlSchema.ct_Col_OnlineNo] = rst.OnlineNo; // オンライン番号
            dr[EstmtSndRcvJnlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo; // オンライン行番号
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesDate] = rst.SalesDate; // 売上日付
            dr[EstmtSndRcvJnlSchema.ct_Col_InputDay] = rst.InputDay; // 入力日
            dr[EstmtSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime; // データ更新日時
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEKind] = rst.UOEKind; // UOE種別
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum; // 売上伝票番号
            dr[EstmtSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus; // 受注ステータス
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum; // 売上明細通番
            dr[EstmtSndRcvJnlSchema.ct_Col_SectionCode] = rst.SectionCode; // 拠点コード
            dr[EstmtSndRcvJnlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode; // 部門コード
            dr[EstmtSndRcvJnlSchema.ct_Col_CustomerCode] = rst.CustomerCode; // 得意先コード
            dr[EstmtSndRcvJnlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm; // 得意先略称
            dr[EstmtSndRcvJnlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo; // レジ番号
            dr[EstmtSndRcvJnlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo; // 共通通番
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal; // 仕入形式
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo; // 仕入伝票番号
            dr[EstmtSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum; // 仕入明細通番
            dr[EstmtSndRcvJnlSchema.ct_Col_BoCode] = rst.BoCode; // BO区分
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv; // 納品区分
            dr[EstmtSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm; // 納品区分名称
            dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv; // フォロー納品区分
            dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm; // フォロー納品区分名称
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection; // UOE指定拠点
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm; // UOE指定拠点名称
            dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode; // 従業員コード
            dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeName] = rst.EmployeeName; // 従業員名称
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd; // 商品メーカーコード
            dr[EstmtSndRcvJnlSchema.ct_Col_MakerName] = rst.MakerName; // メーカー名称
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNo] = rst.GoodsNo; // 商品番号
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen; // ハイフン無商品番号
            dr[EstmtSndRcvJnlSchema.ct_Col_GoodsName] = rst.GoodsName; // 商品名称
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode; // 倉庫コード
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseName] = rst.WarehouseName; // 倉庫名称
            dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo; // 倉庫棚番
            dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt; // 受注数量
            dr[EstmtSndRcvJnlSchema.ct_Col_ListPrice] = rst.ListPrice; // 定価（浮動）
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost; // 原価単価
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierCd] = rst.SupplierCd; // 仕入先コード
            dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm; // 仕入先略称
            dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1; // ＵＯＥリマーク１
            dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2; // ＵＯＥリマーク２
            dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = rst.EstimateRate; // 見積レート
            dr[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = rst.SelectCode; // 選択コード
            dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate; // 受信日付
            dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime; // 受信時刻
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd; // 回答メーカーコード
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo; // 回答品番
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName; // 回答品名
            dr[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo; // 代替品番
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice; // 回答定価
            dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = rst.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            dr[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = rst.HeadQtrsStock; // 本部在庫
            dr[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = rst.BranchStock; // 拠点在庫
            dr[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = rst.SectionStock; // 支店在庫
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode1] = rst.UOESectionCode1; // UOE拠点コード１
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode2] = rst.UOESectionCode2; // UOE拠点コード２
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode3] = rst.UOESectionCode3; // UOE拠点コード３
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock1] = rst.UOESectionStock1; // UOE拠点在庫数１
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock2] = rst.UOESectionStock2; // UOE拠点在庫数２
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock3] = rst.UOESectionStock3; // UOE拠点在庫数３
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = rst.UOEDelivDateCd; // UOE納期コード
            dr[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = rst.UOESubstCode; // UOE代替コード
            dr[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode] = rst.UOEPriceCode; // UOE価格コード
            dr[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost; // 回答原価単価
            dr[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd; // 層別コード
            dr[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage; // ヘッドエラーメッセージ
            dr[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage; // ラインエラーメッセージ
            dr[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = rst.DataSendCode; // データ送信区分
            dr[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv; // データ復旧区分
        }
		# endregion

		# region 送受信ＪＮＬ（見積）＜DataRow → クラス＞作成
		/// <summary>
		/// 送受信ＪＮＬ（見積）＜DataRow → クラス＞作成
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="rst"></param>
		private EstmtSndRcvJnl CreateEstmtJnlFromSchema(ref DataRow dr)
		{
			EstmtSndRcvJnl rst = new EstmtSndRcvJnl();

            //rst.CreateDateTime = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_CreateDateTime]; // 作成日時
            //rst.UpdateDateTime = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_UpdateDateTime]; // 更新日時
            rst.EnterpriseCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode]; // 企業コード
            //rst.FileHeaderGuid = (Guid)dr[EstmtSndRcvJnlSchema.ct_Col_FileHeaderGuid]; // GUID
            rst.UpdEmployeeCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdEmployeeCode]; // 更新従業員コード
            rst.UpdAssemblyId1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId1]; // 更新アセンブリID1
            rst.UpdAssemblyId2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UpdAssemblyId2]; // 更新アセンブリID2
            rst.LogicalDeleteCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_LogicalDeleteCode]; // 論理削除区分
            rst.SystemDivCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SystemDivCd]; // システム区分
            rst.UOESalesOrderNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]; // UOE発注番号
            rst.UOESalesOrderRowNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]; // UOE発注行番号
            rst.SendTerminalNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SendTerminalNo]; // 送信端末番号
            rst.UOESupplierCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd]; // UOE発注先コード
            rst.UOESupplierName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESupplierName]; // UOE発注先名称
            rst.CommAssemblyId = (string)dr[EstmtSndRcvJnlSchema.ct_Col_CommAssemblyId]; // 通信アセンブリID
            rst.OnlineNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_OnlineNo]; // オンライン番号
            rst.OnlineRowNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_OnlineRowNo]; // オンライン行番号
            rst.SalesDate = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_SalesDate]; // 売上日付
            rst.InputDay = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_InputDay]; // 入力日
            rst.DataUpdateDateTime = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_DataUpdateDateTime]; // データ更新日時
            rst.UOEKind = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOEKind]; // UOE種別
            rst.SalesSlipNum = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipNum]; // 売上伝票番号
            rst.AcptAnOdrStatus = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_AcptAnOdrStatus]; // 受注ステータス
            rst.SalesSlipDtlNum = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_SalesSlipDtlNum]; // 売上明細通番
            rst.SectionCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SectionCode]; // 拠点コード
            rst.SubSectionCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SubSectionCode]; // 部門コード
            rst.CustomerCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_CustomerCode]; // 得意先コード
            rst.CustomerSnm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_CustomerSnm]; // 得意先略称
            rst.CashRegisterNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_CashRegisterNo]; // レジ番号
            rst.CommonSeqNo = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_CommonSeqNo]; // 共通通番
            rst.SupplierFormal = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierFormal]; // 仕入形式
            rst.SupplierSlipNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSlipNo]; // 仕入伝票番号
            rst.StockSlipDtlNum = (Int64)dr[EstmtSndRcvJnlSchema.ct_Col_StockSlipDtlNum]; // 仕入明細通番
            rst.BoCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_BoCode]; // BO区分
            rst.UOEDeliGoodsDiv = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv]; // 納品区分
            rst.DeliveredGoodsDivNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm]; // 納品区分名称
            rst.FollowDeliGoodsDiv = (string)dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv]; // フォロー納品区分
            rst.FollowDeliGoodsDivNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm]; // フォロー納品区分名称
            rst.UOEResvdSection = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSection]; // UOE指定拠点
            rst.UOEResvdSectionNm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEResvdSectionNm]; // UOE指定拠点名称
            rst.EmployeeCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeCode]; // 従業員コード
            rst.EmployeeName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EmployeeName]; // 従業員名称
            rst.GoodsMakerCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsMakerCd]; // 商品メーカーコード
            rst.MakerName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_MakerName]; // メーカー名称
            rst.GoodsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNo]; // 商品番号
            rst.GoodsNoNoneHyphen = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen]; // ハイフン無商品番号
            rst.GoodsName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsName]; // 商品名称
            rst.WarehouseCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseCode]; // 倉庫コード
            rst.WarehouseName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseName]; // 倉庫名称
            rst.WarehouseShelfNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; // 倉庫棚番
            rst.AcceptAnOrderCnt = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt]; // 受注数量
            rst.ListPrice = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_ListPrice]; // 定価（浮動）
            rst.SalesUnitCost = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnitCost]; // 原価単価
            rst.SupplierCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierCd]; // 仕入先コード
            rst.SupplierSnm = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SupplierSnm]; // 仕入先略称
            rst.UoeRemark1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1]; // ＵＯＥリマーク１
            rst.UoeRemark2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark2]; // ＵＯＥリマーク２
            rst.EstimateRate = (string)dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate]; // 見積レート
            rst.SelectCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SelectCode]; // 選択コード
            rst.ReceiveDate = (DateTime)dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate]; // 受信日付
            rst.ReceiveTime = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime]; // 受信時刻
            rst.AnswerMakerCd = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerMakerCd]; // 回答メーカーコード
            rst.AnswerPartsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo]; // 回答品番
            rst.AnswerPartsName = (string)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName]; // 回答品名
            rst.SubstPartsNo = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo]; // 代替品番
            rst.AnswerListPrice = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice]; // 回答定価
            rst.SalesUnPrcTaxExcFl = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl]; // 売上単価（税抜，浮動）
            rst.HeadQtrsStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock]; // 本部在庫
            rst.BranchStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_BranchStock]; // 拠点在庫
            rst.SectionStock = (string)dr[EstmtSndRcvJnlSchema.ct_Col_SectionStock]; // 支店在庫
            rst.UOESectionCode1 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode1]; // UOE拠点コード１
            rst.UOESectionCode2 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode2]; // UOE拠点コード２
            rst.UOESectionCode3 = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode3]; // UOE拠点コード３
            rst.UOESectionStock1 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock1]; // UOE拠点在庫数１
            rst.UOESectionStock2 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock2]; // UOE拠点在庫数２
            rst.UOESectionStock3 = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock3]; // UOE拠点在庫数３
            rst.UOEDelivDateCd = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd]; // UOE納期コード
            rst.UOESubstCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode]; // UOE代替コード
            rst.UOEPriceCode = (string)dr[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode]; // UOE価格コード
            rst.AnswerSalesUnitCost = (Double)dr[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost]; // 回答原価単価
            rst.PartsLayerCd = (string)dr[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd]; // 層別コード
            rst.HeadErrorMassage = (string)dr[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage]; // ヘッドエラーメッセージ
            rst.LineErrorMassage = (string)dr[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage]; // ラインエラーメッセージ
            rst.DataSendCode = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_DataSendCode]; // データ送信区分
            rst.DataRecoverDiv = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv]; // データ復旧区分

			return (rst);
		}
		# endregion

		# endregion
	}
}
