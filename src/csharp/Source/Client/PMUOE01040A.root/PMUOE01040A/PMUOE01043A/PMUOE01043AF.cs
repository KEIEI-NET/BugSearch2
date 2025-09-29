//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥＵＯＥ発注データアクセスクラス
// プログラム概要   : ＵＯＥＵＯＥ発注データアクセスを行う
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
	/// ＵＯＥ発注データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ発注データアクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        # region ＵＯＥ発注データ作成（データリスト→データーテーブル）
        /// <summary>
        /// ＵＯＥ発注データ作成（データリスト→データーテーブル）
        /// </summary>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int ToDataTableFromUOEOrderDtlList(List<UOEOrderDtlWork> list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                UOEOrderDtlSchema.SettingDataSet(ref _uoeJnlDataSet);

                foreach (UOEOrderDtlWork rst in list)
                {
                    //送受信ＪＮＬの保存
                    DataRow dr = UOEOrderDtlTable.NewRow();
                    CreateUOEOrderDtlSchema(ref dr, rst);
                    UOEOrderDtlTable.Rows.Add(dr);
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

        # region ＵＯＥ発注データ更新（データリスト→データーテーブル）
        /// <summary>
        /// ＵＯＥ発注データ更新（データリスト→データーテーブル）
        /// </summary>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromUOEOrderDtlList(List<UOEOrderDtlWork> list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (UOEOrderDtlWork rst in list)
                {
                    // ＵＯＥ発注DataTableのFIND処理
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = rst.UOESupplierCd;
                    findUOEOrderDtl[1] = rst.UOESalesOrderNo;
                    findUOEOrderDtl[2] = rst.UOESalesOrderRowNo;
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);

                    //ＵＯＥ発注DataTableの更新
                    if (uOEOrderDtlRow != null)
                    {
                        CreateUOEOrderDtlSchema(ref uOEOrderDtlRow, rst);
                    }
                    //ＵＯＥ発注DataTableの追加
                    else
                    {
                        DataRow dr = UOEOrderDtlTable.NewRow();
                        CreateUOEOrderDtlSchema(ref dr, rst);
                        UOEOrderDtlTable.Rows.Add(dr);
                    }
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

        # region ＵＯＥ発注データ＜DataRow → クラス＞作成
        /// <summary>
        /// ＵＯＥ発注データ＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">ＵＯＥ発注データ</param>
        public UOEOrderDtlWork CreateUOEOrderDtlWorkFromSchema(ref DataRow dr)
        {
            return (CreateUOEOrderDtlWorkFromSchemaProc(ref dr));
        }
        # endregion

        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region ＵＯＥ発注データテーブルRow作成
        /// <summary>
        /// ＵＯＥ発注データテーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">ＵＯＥ発注データクラス</param>
        private void CreateUOEOrderDtlSchema(ref DataRow dr, UOEOrderDtlWork rst)
        {
            dr[UOEOrderDtlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[UOEOrderDtlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd;	// システム区分
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo;	// UOE発注番号
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo;	// UOE発注行番号
            dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo;	// 送信端末番号
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd;	// UOE発注先コード
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName;	// UOE発注先名称
            dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId;	// 通信アセンブリID
            dr[UOEOrderDtlSchema.ct_Col_OnlineNo] = rst.OnlineNo;	// オンライン番号
            dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo;	// オンライン行番号
            dr[UOEOrderDtlSchema.ct_Col_SalesDate] = rst.SalesDate;	// 売上日付
            dr[UOEOrderDtlSchema.ct_Col_InputDay] = rst.InputDay;	// 入力日
            dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime;	// データ更新日時
            dr[UOEOrderDtlSchema.ct_Col_UOEKind] = rst.UOEKind;	// UOE種別
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// 売上伝票番号
            dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// 受注ステータス
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum;	// 売上明細通番
            dr[UOEOrderDtlSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[UOEOrderDtlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[UOEOrderDtlSchema.ct_Col_CustomerCode] = rst.CustomerCode;	// 得意先コード
            dr[UOEOrderDtlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm;	// 得意先略称
            dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo;	// レジ番号
            dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// 共通通番
            dr[UOEOrderDtlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// 仕入形式
            dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// 仕入伝票番号
            dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// 仕入明細通番
            dr[UOEOrderDtlSchema.ct_Col_BoCode] = rst.BoCode;	// BO区分
            dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv;	// 納品区分
            dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm;	// 納品区分名称
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv;	// フォロー納品区分
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm;	// フォロー納品区分名称
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection;	// UOE指定拠点
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm;	// UOE指定拠点名称
            dr[UOEOrderDtlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode;	// 従業員コード
            dr[UOEOrderDtlSchema.ct_Col_EmployeeName] = rst.EmployeeName;	// 従業員名称
            dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// 商品メーカーコード
            dr[UOEOrderDtlSchema.ct_Col_MakerName] = rst.MakerName;	// メーカー名称
            dr[UOEOrderDtlSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// 商品番号
            dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen;	// ハイフン無商品番号
            dr[UOEOrderDtlSchema.ct_Col_GoodsName] = rst.GoodsName;	// 商品名称
            dr[UOEOrderDtlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// 倉庫コード
            dr[UOEOrderDtlSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// 倉庫名称
            dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// 倉庫棚番
            dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt;	// 受注数量
            dr[UOEOrderDtlSchema.ct_Col_ListPrice] = rst.ListPrice;	// 定価（浮動）
            dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost;	// 原価単価
            dr[UOEOrderDtlSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[UOEOrderDtlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// ＵＯＥリマーク１
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// ＵＯＥリマーク２
            dr[UOEOrderDtlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate;	// 受信日付
            dr[UOEOrderDtlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime;	// 受信時刻
            dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd;	// 回答メーカーコード
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo;	// 回答品番
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName;	// 回答品名
            dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo;	// 代替品番
            dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = rst.UOESectOutGoodsCnt;	// UOE拠点出庫数
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = rst.BOShipmentCnt1;	// BO出庫数1
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = rst.BOShipmentCnt2;	// BO出庫数2
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = rst.BOShipmentCnt3;	// BO出庫数3
            dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = rst.MakerFollowCnt;	// メーカーフォロー数
            dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = rst.NonShipmentCnt;	// 未出庫数
            dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = rst.UOESectStockCnt;	// UOE拠点在庫数
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount1] = rst.BOStockCount1;	// BO在庫数1
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount2] = rst.BOStockCount2;	// BO在庫数2
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount3] = rst.BOStockCount3;	// BO在庫数3
            dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = rst.UOESectionSlipNo;	// UOE拠点伝票番号
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = rst.BOSlipNo1;	// BO伝票番号１
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = rst.BOSlipNo2;	// BO伝票番号２
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = rst.BOSlipNo3;	// BO伝票番号３
            dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = rst.EOAlwcCount;	// EO引当数
            dr[UOEOrderDtlSchema.ct_Col_BOManagementNo] = rst.BOManagementNo;	// BO管理番号
            dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;	// 回答定価
            dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost;	// 回答原価単価
            dr[UOEOrderDtlSchema.ct_Col_UOESubstMark] = rst.UOESubstMark;	// UOE代替マーク
            dr[UOEOrderDtlSchema.ct_Col_UOEStockMark] = rst.UOEStockMark;	// UOE在庫マーク
            dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd;	// 層別コード
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = rst.MazdaUOEShipSectCd1;	// UOE出荷拠点コード１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = rst.MazdaUOEShipSectCd2;	// UOE出荷拠点コード２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = rst.MazdaUOEShipSectCd3;	// UOE出荷拠点コード３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = rst.MazdaUOESectCd1;	// UOE拠点コード１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = rst.MazdaUOESectCd2;	// UOE拠点コード２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = rst.MazdaUOESectCd3;	// UOE拠点コード３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = rst.MazdaUOESectCd4;	// UOE拠点コード４（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = rst.MazdaUOESectCd5;	// UOE拠点コード５（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = rst.MazdaUOESectCd6;	// UOE拠点コード６（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = rst.MazdaUOESectCd7;	// UOE拠点コード７（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = rst.MazdaUOEStockCnt1;	// UOE在庫数１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = rst.MazdaUOEStockCnt2;	// UOE在庫数２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = rst.MazdaUOEStockCnt3;	// UOE在庫数３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = rst.MazdaUOEStockCnt4;	// UOE在庫数４（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = rst.MazdaUOEStockCnt5;	// UOE在庫数５（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = rst.MazdaUOEStockCnt6;	// UOE在庫数６（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = rst.MazdaUOEStockCnt7;	// UOE在庫数７（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = rst.UOEDistributionCd;	// UOE卸コード
            dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = rst.UOEOtherCd;	// UOE他コード
            dr[UOEOrderDtlSchema.ct_Col_UOEHMCd] = rst.UOEHMCd;	// UOEＨＭコード
            dr[UOEOrderDtlSchema.ct_Col_BOCount] = rst.BOCount;	// ＢＯ数
            dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = rst.UOEMarkCode;	// UOEマークコード
            dr[UOEOrderDtlSchema.ct_Col_SourceShipment] = rst.SourceShipment;	// 出荷元
            dr[UOEOrderDtlSchema.ct_Col_ItemCode] = rst.ItemCode;	// アイテムコード
            dr[UOEOrderDtlSchema.ct_Col_UOECheckCode] = rst.UOECheckCode;	// UOEチェックコード
            dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage;	// ヘッドエラーメッセージ
            dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage;	// ラインエラーメッセージ
            dr[UOEOrderDtlSchema.ct_Col_DataSendCode] = rst.DataSendCode;	// データ送信区分
            dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv;	// データ復旧区分
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = rst.EnterUpdDivSec;	// 入庫更新区分（拠点）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = rst.EnterUpdDivBO1;	// 入庫更新区分（BO1）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = rst.EnterUpdDivBO2;	// 入庫更新区分（BO2）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = rst.EnterUpdDivBO3;	// 入庫更新区分（BO3）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = rst.EnterUpdDivMaker;	// 入庫更新区分（ﾒｰｶｰ）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = rst.EnterUpdDivEO;	// 入庫更新区分（EO）
            dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// 明細関連付けGUID
        }
        # endregion

   		# region ＵＯＥ発注データ＜DataRow → クラス＞作成
		/// <summary>
		/// ＵＯＥ発注データ＜DataRow → クラス＞作成
		/// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">ＵＯＥ発注データ</param>
        private UOEOrderDtlWork CreateUOEOrderDtlWorkFromSchemaProc(ref DataRow dr)
        {
            UOEOrderDtlWork rst = new UOEOrderDtlWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_CreateDateTime];	// 作成日時
                rst.UpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.SystemDivCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SystemDivCd];	// システム区分
                rst.UOESalesOrderNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo];	// UOE発注番号
                rst.UOESalesOrderRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo];	// UOE発注行番号
                rst.SendTerminalNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo];	// 送信端末番号
                rst.UOESupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd];	// UOE発注先コード
                rst.UOESupplierName = (string)dr[UOEOrderDtlSchema.ct_Col_UOESupplierName];	// UOE発注先名称
                rst.CommAssemblyId = (string)dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId];	// 通信アセンブリID
                rst.OnlineNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineNo];	// オンライン番号
                rst.OnlineRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo];	// オンライン行番号
                rst.SalesDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_SalesDate];	// 売上日付
                rst.InputDay = (DateTime)dr[UOEOrderDtlSchema.ct_Col_InputDay];	// 入力日
                rst.DataUpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime];	// データ更新日時
                rst.UOEKind = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOEKind];	// UOE種別
                rst.SalesSlipNum = (string)dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum];	// 売上伝票番号
                rst.AcptAnOdrStatus = (Int32)dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus];	// 受注ステータス
                rst.SalesSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum];	// 売上明細通番
                rst.SectionCode = (string)dr[UOEOrderDtlSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.CustomerCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_CustomerCode];	// 得意先コード
                rst.CustomerSnm = (string)dr[UOEOrderDtlSchema.ct_Col_CustomerSnm];	// 得意先略称
                rst.CashRegisterNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo];	// レジ番号
                rst.CommonSeqNo = (Int64)dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo];	// 共通通番
                rst.SupplierFormal = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierFormal];	// 仕入形式
                rst.SupplierSlipNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo];	// 仕入伝票番号
                rst.StockSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum];	// 仕入明細通番
                rst.BoCode = (string)dr[UOEOrderDtlSchema.ct_Col_BoCode];	// BO区分
                rst.UOEDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv];	// 納品区分
                rst.DeliveredGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm];	// 納品区分名称
                rst.FollowDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv];	// フォロー納品区分
                rst.FollowDeliGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm];	// フォロー納品区分名称
                rst.UOEResvdSection = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection];	// UOE指定拠点
                rst.UOEResvdSectionNm = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm];	// UOE指定拠点名称
                rst.EmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeCode];	// 従業員コード
                rst.EmployeeName = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeName];	// 従業員名称
                rst.GoodsMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd];	// 商品メーカーコード
                rst.MakerName = (string)dr[UOEOrderDtlSchema.ct_Col_MakerName];	// メーカー名称
                rst.GoodsNo = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNo];	// 商品番号
                rst.GoodsNoNoneHyphen = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen];	// ハイフン無商品番号
                rst.GoodsName = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsName];	// 商品名称
                rst.WarehouseCode = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseCode];	// 倉庫コード
                rst.WarehouseName = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseName];	// 倉庫名称
                rst.WarehouseShelfNo = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo];	// 倉庫棚番
                rst.AcceptAnOrderCnt = (Double)dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt];	// 受注数量
                rst.ListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_ListPrice];	// 定価（浮動）
                rst.SalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost];	// 原価単価
                rst.SupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierSnm = (string)dr[UOEOrderDtlSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.UoeRemark1 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark1];	// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark2];	// ＵＯＥリマーク２
                rst.ReceiveDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_ReceiveDate];	// 受信日付
                rst.ReceiveTime = (Int32)dr[UOEOrderDtlSchema.ct_Col_ReceiveTime];	// 受信時刻
                rst.AnswerMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd];	// 回答メーカーコード
                rst.AnswerPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo];	// 回答品番
                rst.AnswerPartsName = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName];	// 回答品名
                rst.SubstPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo];	// 代替品番
                rst.UOESectOutGoodsCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE拠点出庫数
                rst.BOShipmentCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1];	// BO出庫数1
                rst.BOShipmentCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2];	// BO出庫数2
                rst.BOShipmentCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3];	// BO出庫数3
                rst.MakerFollowCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt];	// メーカーフォロー数
                rst.NonShipmentCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt];	// 未出庫数
                rst.UOESectStockCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt];	// UOE拠点在庫数
                rst.BOStockCount1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount1];	// BO在庫数1
                rst.BOStockCount2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount2];	// BO在庫数2
                rst.BOStockCount3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount3];	// BO在庫数3
                rst.UOESectionSlipNo = (string)dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo];	// UOE拠点伝票番号
                rst.BOSlipNo1 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1];	// BO伝票番号１
                rst.BOSlipNo2 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2];	// BO伝票番号２
                rst.BOSlipNo3 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3];	// BO伝票番号３
                rst.EOAlwcCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount];	// EO引当数
                rst.BOManagementNo = (string)dr[UOEOrderDtlSchema.ct_Col_BOManagementNo];	// BO管理番号
                rst.AnswerListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice];	// 回答定価
                rst.AnswerSalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];	// 回答原価単価
                rst.UOESubstMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOESubstMark];	// UOE代替マーク
                rst.UOEStockMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOEStockMark];	// UOE在庫マーク
                rst.PartsLayerCd = (string)dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd];	// 層別コード
                rst.MazdaUOEShipSectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE出荷拠点コード１（マツダ）
                rst.MazdaUOEShipSectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE出荷拠点コード２（マツダ）
                rst.MazdaUOEShipSectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE出荷拠点コード３（マツダ）
                rst.MazdaUOESectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1];	// UOE拠点コード１（マツダ）
                rst.MazdaUOESectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2];	// UOE拠点コード２（マツダ）
                rst.MazdaUOESectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3];	// UOE拠点コード３（マツダ）
                rst.MazdaUOESectCd4 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4];	// UOE拠点コード４（マツダ）
                rst.MazdaUOESectCd5 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5];	// UOE拠点コード５（マツダ）
                rst.MazdaUOESectCd6 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6];	// UOE拠点コード６（マツダ）
                rst.MazdaUOESectCd7 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7];	// UOE拠点コード７（マツダ）
                rst.MazdaUOEStockCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE在庫数１（マツダ）
                rst.MazdaUOEStockCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE在庫数２（マツダ）
                rst.MazdaUOEStockCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE在庫数３（マツダ）
                rst.MazdaUOEStockCnt4 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE在庫数４（マツダ）
                rst.MazdaUOEStockCnt5 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE在庫数５（マツダ）
                rst.MazdaUOEStockCnt6 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE在庫数６（マツダ）
                rst.MazdaUOEStockCnt7 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE在庫数７（マツダ）
                rst.UOEDistributionCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd];	// UOE卸コード
                rst.UOEOtherCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd];	// UOE他コード
                rst.UOEHMCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEHMCd];	// UOEＨＭコード
                rst.BOCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOCount];	// ＢＯ数
                rst.UOEMarkCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode];	// UOEマークコード
                rst.SourceShipment = (string)dr[UOEOrderDtlSchema.ct_Col_SourceShipment];	// 出荷元
                rst.ItemCode = (string)dr[UOEOrderDtlSchema.ct_Col_ItemCode];	// アイテムコード
                rst.UOECheckCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOECheckCode];	// UOEチェックコード
                rst.HeadErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage];	// ヘッドエラーメッセージ
                rst.LineErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage];	// ラインエラーメッセージ
                rst.DataSendCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataSendCode];	// データ送信区分
                rst.DataRecoverDiv = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv];	// データ復旧区分
                rst.EnterUpdDivSec = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];	// 入庫更新区分（拠点）
                rst.EnterUpdDivBO1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];	// 入庫更新区分（BO1）
                rst.EnterUpdDivBO2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];	// 入庫更新区分（BO2）
                rst.EnterUpdDivBO3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];	// 入庫更新区分（BO3）
                rst.EnterUpdDivMaker = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];	// 入庫更新区分（ﾒｰｶｰ）
                rst.EnterUpdDivEO = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];	// 入庫更新区分（EO）
                rst.DtlRelationGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid];	// 明細関連付けGUID
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion
		# endregion
	}
}
