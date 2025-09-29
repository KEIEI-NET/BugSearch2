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
// 作 成 日  2011/10/27  修正内容 : 22008 長内 数馬 伝票明細追加情報セット不具合の修正
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
using Broadleaf.Library.Windows.Forms;

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
        // 列挙体
        // ===================================================================================== //
        # region Enums
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        public enum OptWorkSettingType : int
        {
            /// <summary>登録</summary>
            Write = 0,
            /// <summary>読込</summary>
            Read = 1,
            /// <summary>削除</summary>
            Delete = 2,
        }
        #endregion

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
        # region ■ 仕入情報データセット
        /// <summary>
        /// 仕入情報の書き込み処理
        /// </summary>
        /// <param name="stockSlipGrpList">仕入情報</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int WriteStockInfo(List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            return(WriteStockInfoProc(stockSlipGrpList, out message));
        }
		# endregion
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 仕入情報データセット
        /// <summary>
        /// 仕入情報の書き込み処理
        /// </summary>
        /// <param name="stockSlipGrpList">仕入情報</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int WriteStockInfoProc(List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //      --iOWriteCtrlOptWork            売上・仕入制御オプション
            //------------------------------------------------------------------------------------

            # region 変数の初期化
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            //戻り値の初期化
            # endregion

            try
            {
                //------------------------------------------------------
                // 仕入情報リストパラメータ設定
                //------------------------------------------------------
                # region 仕入情報リストパラメータ設定
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();     // 統合リスト
                status = GetStockInfoPara(ref paraList, stockSlipGrpList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                //------------------------------------------------------
                // リモート参照用パラメータ
                //------------------------------------------------------
                # region リモート参照用パラメータ
                if (paraList.Count == 0)
                {
                    return (status);
                }

                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
                this.SettingIOWriteCtrlOptWork(OptWorkSettingType.Write, out iOWriteCtrlOptWork); // リモート参照用パラメータ設定処理
                paraList.Add(iOWriteCtrlOptWork);
                #endregion
                #endregion

                //------------------------------------------------------
                // 更新処理
                //------------------------------------------------------
                #region 更新処理
                // 保存用変数初期化
                string retItemInfo = string.Empty;
                object paraObj = (object)paraList;

                // 更新処理
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                do
                {
                    status = this._iIOWriteControlDB.Write(ref paraObj, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "シェアチェックエラー（拠点ロック）です。\r"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                }while ((status == 850) || (status == 851) || (status == 852));

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 仕入情報データセット
        /// <summary>
        /// 仕入情報データセット
        /// </summary>
        /// <param name="paraList">仕入リスト＜CustomSerializeArrayList＞</param>
        /// <param name="stockSlipGrpList">仕入リスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetStockInfoPara(ref CustomSerializeArrayList paraList, List<StockSlipGrp> stockSlipGrpList, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //------------------------------------------------------------------------------------
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = String.Empty;

            try
            {
                int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // ADD 2011/10/27

                foreach (StockSlipGrp stockSlipGrp in stockSlipGrpList)
                {
                    StockSlipWork stockSlipWork = stockSlipGrp.stockSlipWork;
                    
                    //-----------------------------------------------------------
                    // 伝票明細追加情報の作成
                    //-----------------------------------------------------------
                    # region 伝票明細追加情報の作成
                    //int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // DEL 2011/10/27
                    ArrayList stockDetailWorkAry = new ArrayList();
                    ArrayList slipDetailAddInfoWorkAry = new ArrayList();

                    foreach (StockDetailWork stockDetailWork in stockSlipGrp.stockDetailWorkList)
                    {
                        slipDtlRegOrder++;
                        SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                        //slipDetailAddInfoWork.DtlRelationGuid = stockDetailWork.DtlRelationGuid;
                        slipDetailAddInfoWork.DtlRelationGuid = Guid.Empty;
                        slipDetailAddInfoWork.GoodsEntryDiv = 0;
                        slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceUpdateDiv = 0;
                        slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;
                        slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;
                        slipDetailAddInfoWork.AddUpRemDiv = 0;

                        slipDetailAddInfoWorkAry.Add(slipDetailAddInfoWork);
                        stockDetailWorkAry.Add(stockDetailWork);
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入情報(CustomSerializeArrayList)の作成
                    //-----------------------------------------------------------
                    # region 仕入情報(CustomSerializeArrayList)の作成
                    CustomSerializeArrayList grpAry = new CustomSerializeArrayList();
                    grpAry.Add(stockSlipWork);
                    grpAry.Add(stockDetailWorkAry);
                    grpAry.Add(slipDetailAddInfoWorkAry);

                    paraList.Add(grpAry);
                    # endregion
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

        # region リモート参照用パラメータ設定処理
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;                     // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
            iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;     // 受注データ計上残区分
            iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().ShipmAddUpRemDiv;         // 出荷データ計上残区分
            iOWriteCtrlOptWork.EstimateAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().EstmateAddUpRemDiv;    // 見積データ計上残区分
            iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().RetGoodsStockEtyDiv;   // 返品時在庫登録区分
            iOWriteCtrlOptWork.RemainCntMngDiv = this._uoeSndRcvCtlInitAcs.GetAllDefSet().RemainCntMngDiv;            // 残数管理区分
            iOWriteCtrlOptWork.SupplierSlipDelDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SupplierSlipDelDiv;     // 仕入伝票削除区分
            iOWriteCtrlOptWork.CarMngDivCd = 0;                                                                       // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            switch (optWorkSettinType)
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
            }
        }
        # endregion


    }
}
