//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 回答データアクセスクラス
// プログラム概要   : ホンダ UOE WEB専用 回答データアクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号  XXXXXXXX-00 作成担当 : 長内 数馬
// 作 成 日  2011/10/13  修正内容 : UOE発注データの出荷元項目で桁溢れが発生する不具合の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 回答データアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ホンダ UOE WEB専用 回答データアクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2009/05/25</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009/05/25 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// </remarks>
	public partial class UOEAnswerAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		# endregion

		// ===================================================================================== //
		// 定数群
		// ===================================================================================== //
		#region Public Const Member
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ホンダ UOE WEB専用 回答データ更新処理
        /// <summary>
        /// ホンダ UOE WEB専用 回答データ更新処理
		/// </summary>
        /// <param name="uOESupplier">UOE発注先クラス</param>
        /// <param name="lstDtl">注文一覧明細（PM連動）クラス</param>
        /// <param name="message">エラーメッセージ</param>
		/// <returns>0:正常 0以外:エラー</returns>
        public int UpDtAnswerEParts(UOESupplier uOESupplier, ArrayList lstDtl, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
                //-----------------------------------------------------------
                // パラメータ初期化処理
                //-----------------------------------------------------------
                # region パラメータ初期化処理
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();
                # endregion

                //-----------------------------------------------------------
                // 回答データの取得
                //-----------------------------------------------------------
                # region 回答データの取得
                status = UpDtAnswerEParts(uOESupplier, lstDtl, ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 回答データ更新処理
                //-----------------------------------------------------------
                # region 回答データ更新処理
                status = _uOEOrderDtlAcs.Write(ref stockSlipGrpList, ref uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 更新結果→Datatable
                //-----------------------------------------------------------
                # region 更新結果→Datatable
                if((stockSlipGrpList == null) || (uOEOrderDtlWorkList == null))
                {
                    return (status);
                }
                if ((stockSlipGrpList.Count == 0) && (uOEOrderDtlWorkList.Count == 0))
                {
                    return (status);
                }

                //ＵＯＥ発注データ→ＵＯＥ発注データテーブルの更新 
                status = _uoeSndRcvJnlAcs.UpdateTableFromUOEOrderDtlList(uOEOrderDtlWorkList, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                foreach (StockSlipGrp grp in stockSlipGrpList)
                {
                    //仕入明細→仕入明細テーブルの更新
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailList(StockDetailTable, grp.stockDetailWorkList, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }

                    //仕入データ→仕入データテーブルの更新
                    if (grp.stockSlipWork != null)
                    {
                        //仕入明細より共通伝票番号を取得
                        StockDetailWork work = null;
                        string commonSlipNo = "";

                        status = _uoeSndRcvJnlAcs.ReadStockDetailWork(
                                        StockDetailTable,
                                        grp.stockDetailWorkList[0].SupplierFormal,
                                        grp.stockDetailWorkList[0].DtlRelationGuid,
                                        out work,
                                        out commonSlipNo,
                                        out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }

                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockSlipWork(StockSlipTable, grp.stockSlipWork, commonSlipNo, out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region ホンダ UOE WEB専用 回答データの取得
        /// <summary>
        /// ホンダ UOE WEB専用 回答データの取得
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <param name="lstDtl">注文一覧明細（PM連動）クラス</param>
        /// <param name="stockSlipGrpList">仕入情報オブジェクト</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データオブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int UpDtAnswerEParts(UOESupplier uOESupplier, ArrayList lstDtl, ref List<StockSlipGrp> stockSlipGrpList, ref List<UOEOrderDtlWork> uOEOrderDtlWorkList, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                //-----------------------------------------------------------
                // 送受信ＪＮＬ（DataTable）の設定
                //-----------------------------------------------------------
                # region 送受信ＪＮＬ（DataTable）の設定
                foreach (OrderLstPmDtl dtl in lstDtl)
                {
                    # region 送受信ＪＮＬ（DataTable）のフィルタ処理
                    // 送受信ＪＮＬ（DataTable）のフィルタ処理
                    DataView view = GetOrderFormCreateView(
                        uOESupplier.UOESupplierCd,
                        dtl.LinkNo,
                        dtl.OrderGoodsNo);

                    if (view.Count == 0) continue;
                    # endregion

                    # region 出荷拠点の算出
                    // 出荷拠点の算出
                    string sourceShipment = String.Empty;
                    // -- UPD 2011/10/13 ------------------->>>
                    //if ((dtl.SourceShipment.IndexOf("鈴鹿") != -1) || (dtl.SourceShipment.IndexOf("狭山") != -1))
                    //{
                    //    sourceShipment = dtl.SourceShipment;
                    //}
                    
                    if (dtl.SourceShipment.IndexOf("鈴鹿") != -1)
                    {
                        sourceShipment = "鈴鹿";
                    }
                    if (dtl.SourceShipment.IndexOf("狭山") != -1)
                    {
                        sourceShipment = "狭山";
                    }
                    // -- UPD 2011/10/13 -------------------<<<
                    # endregion

                    # region 送受信ＪＮＬ項目の設定
                    // 送受信ＪＮＬ項目の設定
                    foreach (DataRowView dr in view)
                    {
                        # region 代替品番・回答メーカーコードの算出
                        // 代替品番・回答メーカーコードの算出
                        Int32 answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];	//発注時メーカーコード
                        string substPartsNo = dtl.ShipmGoodsNo.Replace("-", "");

                        //代替あり
                        if((dtl.OrderGoodsNo != substPartsNo)
                        && (dtl.ShipmGoodsNo.Trim() != String.Empty))
                        {
                            // 代替品番・メーカーコードの算出
                            List<GoodsUnitData> list = null;
                            int st = _uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(substPartsNo, uOESupplier, out list);
                            //選択なし
                            //該当品番なし
                            if ((st == -1) || (st == 1) || (list == null))
                            {
                                substPartsNo = dtl.ShipmGoodsNo;                                        //品番
                                answerMakerCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd];    //メーカーコード
                            }
                            //該当品番あり
                            else if (list.Count > 0)
                            {
                                substPartsNo = list[0].GoodsNo;			//品番
                                answerMakerCd = list[0].GoodsMakerCd;	//メーカーコード
                            }
                        }
                        //代替なし
                        else
                        {
                            substPartsNo = String.Empty;
                        }

                        # endregion

                        # region 出荷元の設定
                        // 出荷元の設定
                        if(sourceShipment != String.Empty)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = sourceShipment;
                        }
                        # endregion

                        # region 相手先伝票番号・引当数の設定
                        // 相手先伝票番号・引当数の設定
                        //引当数量・出荷品番のチェック
                        if((dtl.ShipmentCnt > 0)
                        && (dtl.ShipmGoodsNo.Trim() != String.Empty))
                        {
                            //拠点出庫
                            if(sourceShipment == String.Empty)
                            {
                                //既に設定済の場合は、設定しない
                                Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];
                                string slipNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];
                                if ((cnt != 0) || (slipNo.Trim() != String.Empty)) continue;

                                //伝票番号・数量の設定
                                dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dtl.ShipmentCnt;	// UOE拠点出庫数
                                dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = dtl.SlipNoDtl.ToString();	    // UOE拠点伝票番号
                            }
                            //ＢＯ出庫
                            else
                            {
                                //既に設定済の場合は、設定しない
                                Int32 cnt = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];
                                string slipNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];
                                if ((cnt != 0) || (slipNo.Trim() != String.Empty)) continue;

                                //伝票番号・数量の設定
                                dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = (Int32)dtl.ShipmentCnt;// BO出庫数1
                                dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = dtl.SlipNoDtl.ToString();	    // BO伝票番号１
                            }
                        }
                        # endregion

                        # region 入庫更新フラグ(1:入庫済)の設定
                        //初期処理
                        int enterUpdDivSec = 0;		//拠点
                        int enterUpdDivBO1 = 0;		//BO1
                        int enterUpdDivBO2 = 0;		//BO2
                        int enterUpdDivBO3 = 0;		//BO3
                        int enterUpdDivMaker = 0;	//ﾒｰｶｰ
                        int enterUpdDivEO = 0;		//EO

                        //システム区分
                        Int32 systemDivCd = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SystemDivCd];

                        //入庫更新フラグ(1:入庫済)の設定
                        int warehouseCode = 0;
                        UoeCommonFnc.ToInt32FromString((string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode], out warehouseCode);

                        //システム区分＝伝発発注分
                        //システム区分＝（手入力、検索発注）の取寄品
                        if ( (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                        || (((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                        || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search))
                            && (warehouseCode == 0)))
                        {
                            enterUpdDivSec = 1;		//拠点
                            enterUpdDivBO1 = 1;		//BO1
                            enterUpdDivBO2 = 1;		//BO2
                            enterUpdDivBO3 = 1;		//BO3
                            enterUpdDivMaker = 1;	//ﾒｰｶｰ
                            enterUpdDivEO = 1;		//EO
                        }
                        //システム区分＝（手入力、検索発注の在庫品）
                        //システム区分＝在庫一括
                        else if ((((systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
                                || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)) && (warehouseCode != 0))
                                || (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Lump))
                        {
                            //拠点
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] == 0) enterUpdDivSec = 1;
                            //BO1
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] == 0) enterUpdDivBO1 = 1;
                            //BO2
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] == 0) enterUpdDivBO2 = 1;
                            //BO3
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] == 0) enterUpdDivBO3 = 1;
                            //ﾒｰｶｰ
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] == 0) enterUpdDivMaker = 1;
                            //EO
                            if ((Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] == 0) enterUpdDivEO = 1;
                        }

                        //入庫更新区分
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivSec] = enterUpdDivSec;	    // 拠点
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO1] = enterUpdDivBO1;	    // BO1
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO2] = enterUpdDivBO2;	    // BO2
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO3] = enterUpdDivBO3;	    // BO3
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivMaker] = enterUpdDivMaker;	// ﾒｰｶｰ
                        dr[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivEO] = enterUpdDivEO;	        // EO
                        # endregion

                        # region 代替品番・回答メーカーコードの設定
                        // 代替品番・UOE代替マーク・回答メーカーコードの設定

                        //メーカーコード
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = answerMakerCd;

                        // 代替品番・UOE代替マーク
                        if (substPartsNo != String.Empty)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = substPartsNo;
                            dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "D";
                        }
                        # endregion

                        # region UOE回答データ部
                        //UOE回答データ部
                        dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = dtl.OrderDate;	                // 受信日付
                        dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = dtl.OrderTime;	                // 受信時刻
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = dtl.ShipmGoodsNo;	            // 回答品番
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = dtl.GoodsName;	            // 回答品名
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = dtl.AnswerListPrice;	        // 回答定価
                        dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = dtl.AnswerSalesUnitCost;	// 回答原価単価
                        # endregion

                        # region データ区分
                        // データ区分
                        dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = (int)EnumUoeConst.ctDataSendCode.ct_OK;	        // データ送信区分
                        dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	    // データ復旧区分
                        # endregion

                        # region ヘッドエラーメッセージの設定
                        // ヘッドエラーメッセージの設定
                        if (dtl.Msg.IndexOf("処理完了") == -1)
                        {
                            dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = dtl.Msg;
                        }
                        # endregion

                        break;
                    }
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // 仕入明細（DataTable）の設定
                //-----------------------------------------------------------
                # region 仕入明細DataTableの設定
                # region 変数の初期化処理
                // 変数の初期化処理
                Dictionary<Int32, Int32> uOESalesOrderNoDictionary = new Dictionary<Int32, Int32>();
                # endregion

                # region 送受信ＪＮＬ（DataTable）のフィルタ処理
                // 送受信ＪＮＬ（DataTable）のフィルタ処理
                DataView viewJnl = GetOrderFormCreateView(
                    0,
                    uOESupplier.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_OK,
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
                # endregion

                foreach (DataRowView dr in viewJnl)
                {
                    //-----------------------------------------------------------
                    // ＵＯＥ発注（DataTable）の設定
                    //-----------------------------------------------------------
                    # region ＵＯＥ発注（DataTable）の設定
                    # region ＵＯＥ発注（DataTable）のFIND処理
                    // 送受信ＪＮＬのFIND処理
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = uOESupplier.UOESupplierCd;
                    findUOEOrderDtl[1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    findUOEOrderDtl[2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo];
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);
                    if (uOEOrderDtlRow == null) continue;
                    # endregion

                    # region ＵＯＥ発注DataTable設定処理
                    //UOE回答データ部
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate] = (DateTime)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveDate];	// 受信日付
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_ReceiveTime];	// 受信時刻
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd];	// 回答メーカーコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo];	// 回答品番
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = (string)dr[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName];	// 回答品名
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo];	// 代替品番
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE拠点出庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];	// BO出庫数1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2];	// BO出庫数2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3];	// BO出庫数3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt];	// メーカーフォロー数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt];	// 未出庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt];	// UOE拠点在庫数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount1];	// BO在庫数1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount2];	// BO在庫数2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOStockCount3];	// BO在庫数3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo];	// UOE拠点伝票番号
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1];	// BO伝票番号１
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2];	// BO伝票番号２
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3];	// BO伝票番号３
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount];	// EO引当数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo] = (string)dr[OrderSndRcvJnlSchema.ct_Col_BOManagementNo];	// BO管理番号
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice];	// 回答定価
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = (Double)dr[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost];	// 回答原価単価
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOESubstMark];	// UOE代替マーク
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEStockMark];	// UOE在庫マーク
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd];	// 層別コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE出荷拠点コード１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE出荷拠点コード２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE出荷拠点コード３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1];	// UOE拠点コード１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2];	// UOE拠点コード２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3];	// UOE拠点コード３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4];	// UOE拠点コード４（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5];	// UOE拠点コード５（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6];	// UOE拠点コード６（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = (string)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7];	// UOE拠点コード７（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE在庫数１（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE在庫数２（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE在庫数３（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE在庫数４（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE在庫数５（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE在庫数６（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE在庫数７（マツダ）
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd];	// UOE卸コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd];	// UOE他コード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEHMCd];	// UOEＨＭコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_BOCount];	// ＢＯ数
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode];	// UOEマークコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment] = (string)dr[OrderSndRcvJnlSchema.ct_Col_SourceShipment];	// 出荷元
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_ItemCode];	// アイテムコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode] = (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode];	// UOEチェックコード
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage];	// ヘッドエラーメッセージ
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = (string)dr[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage];	// ラインエラーメッセージ

                    //データ区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataSendCode];	// データ送信区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv];	// データ復旧区分

                    //入庫更新区分
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];	// 拠点
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];	// BO1
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];	// BO2
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];	// BO3
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];	// ﾒｰｶｰ
                    uOEOrderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];	// EO
                    # endregion

                    # region ＵＯＥ発注(DataTable→UOEOrderDtlWork)
                    // ＵＯＥ発注(DataTable→UOEOrderDtlWork)
                    UOEOrderDtlWork uOEOrderDtlWork = _uoeSndRcvJnlAcs.CreateUOEOrderDtlWorkFromSchema(ref uOEOrderDtlRow);
                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    # endregion
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入明細のＲＥＡＤ処理
                    //-----------------------------------------------------------
                    # region 仕入明細のＲＥＡＤ処理
                    object[] findStockDetail = new object[2];
                    findStockDetail[0] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_SupplierFormal];
                    findStockDetail[1] = (Guid)dr[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid];
                    DataRow stockDetailRow = StockDetailTable.Rows.Find(findStockDetail);
                    if (stockDetailRow == null)
                    {
                        continue;
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入明細の項目設定
                    //-----------------------------------------------------------
                    # region 仕入明細の項目設定
                    # region 共通伝票番号の設定
                    // 共通伝票番号の設定

                    // 仕入先情報の取得
                    int supplierCd = (int)stockDetailRow[StockDetailSchema.ct_Col_SupplierCd];
                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(supplierCd);

                    //共通伝票番号の設定
                    Int32 uOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo] = uOESalesOrderNo;//UOE発注番号;

                    //共通伝票行番号の設定
                    stockDetailRow[StockDetailSchema.ct_Col_CommonSlipRowNo] = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];  // UOE発注行番号

                    // UOE発注番号Dictionaryの追加
                    if (uOESalesOrderNoDictionary.ContainsKey(uOESalesOrderNo) != true)
                    {
                        uOESalesOrderNoDictionary.Add(uOESalesOrderNo, uOESalesOrderNo);
                    }

                    # endregion

                    #region 発注数の設定
                    //発注数の設定
                    Int32 cnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt]
                                + (Int32)dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount];
                    stockDetailRow[StockDetailSchema.ct_Col_OrderCnt] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_StockCount] = (double)cnt;
                    stockDetailRow[StockDetailSchema.ct_Col_OrderRemainCnt] = (double)cnt;
                    #endregion

                    #region 課税区分の算出
                    int dstTaxationCode = (int)stockDetailRow[StockDetailSchema.ct_Col_TaxationCode];

                    if ((supplier.SuppCTaxLayCd == 9)
                    || (supplier.SuppCTaxationCd == 1)
                    || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    #endregion

                    #region 定価
                    //定価（税抜，浮動）
                    double dstPrice = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice];

                    stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = dstPrice;

                    //定価（税込，浮動）
                    if (supplier != null)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                    }
                    #endregion

                    #region 仕入単価変更区分
                    //仕入単価変更区分
                    //変更前原価と回答原価が異なる

                    double srcCost = (double)stockDetailRow[StockDetailSchema.ct_Col_BfStockUnitPriceFl];
                    double dstCost = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];

                    if (srcCost != dstCost)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 1;
                    }
                    //変更前原価と回答原価が同一
                    else
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitChngDiv] = 0;
                    }
                    #endregion

                    #region 仕入単価
                    //仕入単価（税抜，浮動）
                    stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl] = (double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];

                    //仕入単価（税込，浮動）
                    if (supplier != null)
                    {
                        stockDetailRow[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                    }
                    #endregion

                    #region 仕入金額
                    if (supplier != null)
                    {
                        long stockPriceTaxInc = 0;
                        long stockPriceTaxExc = 0;
                        long stockPriceConsTax = 0;

                        bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                            (double)cnt,
                            (double)stockDetailRow[StockDetailSchema.ct_Col_StockUnitPriceFl],
                            dstTaxationCode,
                            supplier.StockMoneyFrcProcCd,
                            supplier.StockCnsTaxFrcProcCd,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax);

                        if (bStatus == true)
                        {
                            //仕入金額（税抜き）
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                            //仕入金額（税込み）
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
                        }
                        else
                        {
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                            stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
                        }
                    }
                    #endregion

                    #region 消費税
                    //仕入金額消費税額
                    stockDetailRow[StockDetailSchema.ct_Col_StockPriceConsTax] = (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxInc]
                                                                               - (Int64)stockDetailRow[StockDetailSchema.ct_Col_StockPriceTaxExc];
                    #endregion
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // 仕入データの作成（仕入情報オブジェクトの作成）
                //-----------------------------------------------------------
                # region 仕入データ作成（仕入情報オブジェクトの作成）
                foreach (Int32 key in uOESalesOrderNoDictionary.Keys)
                {
                    # region ＵＯＥ発注先番号の取得
                    // ＵＯＥ発注先番号の取得
                    Int32 savUOESalesOrderNo = uOESalesOrderNoDictionary[key];
                    if (savUOESalesOrderNo == 0) continue;
                    # endregion

                    # region 仕入明細の取得
                    // 仕入明細の取得
                    DataView view = GetStockDetailFormCreateView(uOESupplier.UOESupplierCd, savUOESalesOrderNo);
                    if (view.Count == 0) continue;

                    List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                    foreach (DataRowView dataRowView in view)
                    {
                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowView.Row);
                        uoeStockDetailWorkList.Add(stockDetailWork);
                    }
                    #endregion

                    # region 仕入データＷｏｒｋの取得
                    //仕入データＷｏｒｋの取得
                    StockSlipWork stockSlipWork = GetStockSlipWorkFromStockDetailDataTable(
                                                            uOESupplier.UOESupplierCd,
                                                            savUOESalesOrderNo,
                                                            out message);
                    if (stockSlipWork == null)  continue;
                    #endregion

                    # region 仕入情報オブジェクトの作成
                    //仕入情報オブジェクトの作成
                    StockSlipGrp stockSlipGrp = new StockSlipGrp();
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrp.stockDetailWorkList = uoeStockDetailWorkList;
                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ＜送受信ＪＮＬ＞回答更新対象データの抽出
        /// <summary>
        /// ＜送受信ＪＮＬ＞回答更新対象データの抽出（UOE発注先コード・UOE発注先コード・ハイフン無商品番号）
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <returns>回答更新対象データ</returns>
        private DataView GetOrderFormCreateView(int uOESupplierCd, int uOESalesOrderNo, string goodsNoNoneHyphen)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = '{5}'",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, uOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen, goodsNoNoneHyphen
                                            );


            // ソート順設定
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }

        /// <summary>
        /// ＜送受信ＪＮＬ＞回答更新対象データの抽出（UOE発注先コード・データ送信区分・データ復旧区分）
        /// </summary>
        /// <param name="uOEKind">UOE種別</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="dataSendCode">データ送信区分</param>
        /// <param name="dataRecoverDiv">データ復旧区分</param>
        /// <returns>回答更新対象データ</returns>
        private DataView GetOrderFormCreateView(int uOEKind, int uOESupplierCd, int dataSendCode, int dataRecoverDiv)
        {
            DataView view = new DataView(this.OrderTable);

            string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5} AND {6} = {7}",
                                            OrderSndRcvJnlSchema.ct_Col_UOEKind, uOEKind,
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, uOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_DataSendCode, dataSendCode,
                                            OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv, dataRecoverDiv
                                            );

            // ソート順設定
            string sortText = string.Format("{0}, {1}, {2}, {3}, {4}",
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo,
                                            OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                            OrderSndRcvJnlSchema.ct_Col_OnlineRowNo
                                            );
            view.RowFilter = rowFilterText;
            view.Sort = sortText;

            return view;
        }
    	# endregion
        # endregion

    }
}
