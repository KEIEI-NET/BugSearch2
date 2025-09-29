//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信制御アクセスクラス
// プログラム概要   : ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 :【要件No.2】																																							
//	                                発注先にトヨタを指定時には、リマーク２の入力は不可とする（連携時、ﾘﾏｰｸ2に連携番号として使用する為）																																							
//	                                仕入明細（発注データ）の作成を行い通信は行わない様にする																																							
//                       修正内容 :【要件No.3】
//                                  発注先の入力制御（トヨタは入力不可とする）を行う
//                                  トヨタ電子カタログで使用する送信・受信データの保存場所を設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/11/08  修正内容 : Redmine#26275 UOE仕入データ作成処理　回答データに伝票番号がセットされていないデータについての対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/23  修正内容 : 06/27配信分、Redmine#29900 在庫入庫更新 在庫入庫更新で検索時にエラーが発生するの対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 修 正 日  2013/01/09  修正内容 : 2013/03/13配信分、Redmine#33989 伝票番号引当処理 仕入データは作成時入荷日が不正の対応
//----------------------------------------------------------------------------//
// 管理番号   作成担当 : 堀田
// 修 正 日  2013/03/08  修正内容 : 10801804-00[2012/05/23]の対応内容を削除し元に戻す
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2014/11/04  修正内容 : PM-SCM仕掛一覧№10689
//                                  SCM回答送信処理とリモート伝発機能の実装対応
//----------------------------------------------------------------------------//
// 管理番号  11400910-00  作成担当 : 田建委
// 作 成 日  2018/07/26   修正内容 : Redmine#49725 UOE発注データ削除処理対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

// --- ADD 2014/11/04 Y.Wakita ---------->>>>>
using System.IO;
using System.Diagnostics;
using Broadleaf.Application.Resources;
// --- ADD 2014/11/04 Y.Wakita ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// ＵＯＥ送受信制御アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note  : 2009/12/29 xuxh</br>
    /// <br>              ・【要件No.2】と【要件No.3】の修正</br>
    /// <br>Update Note  : 2018/07/26 田建委</br>
    /// <br>               Redmine#49725 UOE発注データ削除処理対応</br>
    /// </remarks>
	public partial class UoeSndRcvCtlAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
        private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _employeeName = LoginInfoAcquisition.Employee.Name;
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
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
        # region 商品マスタ アクセスクラス
        /// <summary>
        /// 商品マスタ アクセスクラス
        /// </summary>
        public GoodsAcs _goodsAcs
        {
            get { return _uoeSndRcvJnlAcs.goodsAcs; }
            set { _uoeSndRcvJnlAcs.goodsAcs = value; }
        }
        # endregion

        # region 拠点設定マスタ
        /// <summary>
        /// 拠点設定マスタ
        /// </summary>
        public SecInfoSet _secInfoSet
        {
            get { return _uoeSndRcvJnlAcs.secInfoSet; }
        }
        # endregion
        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御
        /// <summary>
        /// ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御
        /// </summary>
        /// <param name="list">注文一覧データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ回答データ更新～発注回答表示までの処理推移を制御する</br>
        /// <br>Programmer : 96186 立花 裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// <br>Update Note: 2018/07/26 田建委</br>
        /// <br>管理番号   : 11400910-00</br>
        /// <br>             Redmine#49725 UOE発注データ削除処理対応</br>
        /// </remarks>
        public int EpartsUoeWebOrderCtl(ref List<OrderLsthead> list, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                List<OrderLsthead> retOrderLsthead = new List<OrderLsthead>();

                foreach (OrderLsthead hed in list)
                {
                    //ＵＯＥ送受信制御初期化
                    if ((status = UoeSndRcvCtlInit(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        break;
                    }

                    //ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御メイン
                    OrderLsthead orderLsthead = hed.Clone();
                    
                    //ＰＭ連動時処理
                    if(orderLsthead.CsvKnd == 0)
                    {
                        if ((status = EpartsUoeWebOrderCtlPm(ref orderLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //手入力時
                    else if (orderLsthead.CsvKnd == 1)
                    {
                        if ((status = EpartsUoeWebOrderCtlInput(ref orderLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //認識不明形式
                    else
                    {
                        continue;
                    }
                    
                    retOrderLsthead.Add(orderLsthead);
                }

                //戻値を設定
                list = retOrderLsthead;

                // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 -------------------->>>>>
                // 過去のUOE発注データの削除を行う
                this.DeleteUoeOrderData();
                // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 --------------------<<<<<
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

        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts回答更新
        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts回答更新（手入力時）
        # region ▽ ホンダＵＯＥ ＷＥＢ e-Parts回答更新（手入力時）
        /// <summary>
        /// ホンダＵＯＥ ＷＥＢ e-Parts回答更新（手入力時）
        /// </summary>
        /// <param name="hed">注文一覧データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
		/// <remarks>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2009/05/25</br>
		/// </remarks>
        private int EpartsUoeWebOrderCtlInput(ref OrderLsthead hed, out string message)
        {
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // 注文一覧明細（手入力）クラスのチェック
                //-----------------------------------------------------------
                # region 注文一覧明細（手入力）クラスのチェック
                if (hed.LstDtl == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                if (hed.LstDtl.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                ArrayList lstDtl = new ArrayList();
                foreach (OrderLstInputDtl dtl in hed.LstDtl)
                {
                    //お届予定日が未設定の場合、注文日をお届予定日に設定
                    if (dtl.PlanDate == DateTime.MinValue)
                    {
                        dtl.PlanDate = dtl.OrderDate;
                    }

                    //出庫元が「鈴鹿・狭山」の場合、伝票番号に「-F」を付加する
                    if ((dtl.SourceShipment.IndexOf("鈴鹿") != -1) || (dtl.SourceShipment.IndexOf("狭山") != -1))
                    {
                        if (!string.IsNullOrEmpty(dtl.SlipNoDtl)) // ADD 2011/11/08
                        { // ADD 2011/11/08
                            dtl.SlipNoDtl = dtl.SlipNoDtl.Trim() + "-F";
                        } // ADD 2011/11/08
                    }

                    lstDtl.Add(dtl);
                }
                # endregion

                //-----------------------------------------------------------
                // 部門コードの取得
                //-----------------------------------------------------------
                # region 部門コードの取得
                int subSectionCode = 0;
                EmployeeDtl employeeDtl = GetEmployeeDtl(hed.EnterpriseCode, _employeeCode);
                if (employeeDtl != null)
                {
                    subSectionCode = employeeDtl.BelongSubSectionCode;
                }
                # endregion

                //-----------------------------------------------------------
                // ＵＯＥ発注先マスタの取得
                //-----------------------------------------------------------
                # region ＵＯＥ発注先マスタの取得
                UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(hed.UOESupplierCd);
                if (uOESupplier == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                // --- UPD m.suzuki 2010/11/08 ---------->>>>>
                ////if (uOESupplier.CommAssemblyId.Trim() != "0502") // DEL 2009/12/29 xuxh
                //if (!CanSendAndReceive(uOESupplier)) // ADD 2009/12/29 xuxh
                if ( uOESupplier.CommAssemblyId.Trim() != EnumUoeConst.ctCommAssemblyId_0502 )
                // --- UPD m.suzuki 2010/11/08 ----------<<<<<
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 仕入先情報の取得
                //-----------------------------------------------------------
                #region 仕入先情報の設定
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(uOESupplier.SupplierCd);
                if (supplier == null)
                {
                    hed.UpdRsl = -1;
                    return (-1);
                }
                #endregion

                //-----------------------------------------------------------
                // 結果クラスの初期化
                //-----------------------------------------------------------
                # region 結果クラスの初期化
                # region 注文一覧明細(手入力)データテーブルRow作成
                //注文一覧明細(手入力)データテーブルRow作成
                if ((status = _uoeSndRcvJnlAcs.orderLstInputDtlFromDtlWrite(lstDtl, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # region 「仕入日+相手先伝票番号」値を算出
                //注文一覧ヘッダー部Dictionary
                Dictionary<string, OrderLstInputDtl> orderLstInputDictionary = new Dictionary<string, OrderLstInputDtl>();

                // 「お届予定日+相手先伝票番号」値を算出
                foreach (OrderLstInputDtl dtl in lstDtl)
                {
                    //仕入締次の締日チェック
                    if (_totalDayCalculator.CheckPayment(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.PlanDate) != false)
                    {
                        continue;
                    }
                    //仕入月次の締日チェック
                    else if (_totalDayCalculator.CheckMonthlyAccPay(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.PlanDate) != false)
                    {
                        continue;
                    }

                    //数量判定
                    if ((dtl.ShipmentCnt == 0)
                    || (dtl.ShipmGoodsNo.Trim() == String.Empty)
                    || (dtl.SlipNoDtl.Trim() == String.Empty))
                    {
                        continue;
                    }

                    //お届予定日(YYYYMMDD)+伝票番号(999999)
                    int orderDateInt = (dtl.PlanDate.Year * 10000)
                                     + (dtl.PlanDate.Month * 100)
                                     + dtl.PlanDate.Day;

                    string key = orderDateInt.ToString() + dtl.SlipNoDtl.Trim();
                    if (orderLstInputDictionary.ContainsKey(key) != true)
                    {
                        orderLstInputDictionary.Add(key, dtl);
                    }
                }

                //仕入締次・仕入月次のチェックにより処理データが存在しない場合、エラー終了する
                if (orderLstInputDictionary.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # endregion

                //-----------------------------------------------------------
                // 仕入データの読込（リモート処理実行）
                //-----------------------------------------------------------
                # region 仕入データの読込（リモート処理実行）
                # region 条件抽出クラスの作成
                //条件抽出クラスの作成
                ArrayList stockSlipWorkAry = new ArrayList();

                foreach (string key in orderLstInputDictionary.Keys)
                {
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    stockSlipWork.SectionCode = hed.SectionCode;        //拠点コード
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //仕入先コード
                    stockSlipWork.SupplierFormal = 0;                   //0:仕入
                    stockSlipWork.StockDate = dtl.PlanDate;            //仕入日
                    stockSlipWork.ArrivalGoodsDay = dtl.PlanDate;      //入荷日
                    stockSlipWork.PartySaleSlipNum = dtl.SlipNoDtl;    //相手先伝票番号

                    stockSlipWorkAry.Add(stockSlipWork);
                }
                # endregion

                # region 抽出リモート処理の実行
                //抽出リモート処理の実行
                List<StockSlipWork> stockSlipWorkList = null;       //仕入ワークリスト
                List<StockDetailWork> stockDetailWorkList = null;   //仕入明細ワークリスト

                status = _uoeOrderInfoAcs.StockSlipPartySaleSlipNumReadAll(
                            stockSlipWorkAry,
                            out stockSlipWorkList,
                            out stockDetailWorkList,
                            out message);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "";
                }
                else
                {
                    return (status);
                }

                # endregion

                # region 仕入データDictionaryのキャッシュ処理
                //仕入データDictionaryのキャッシュ処理
                Dictionary<string, StockSlipWork> stockSlipWorkDictionary = new Dictionary<string, StockSlipWork>();

                if (stockSlipWorkList != null)
                {
                    foreach (StockSlipWork stockSlipWork in stockSlipWorkList)
                    {
                        // 仕入データDictionaryの追加

                        //注文日(YYYYMMDD)+伝票番号(999999)
                        int stockDateInt = (stockSlipWork.StockDate.Year * 10000)
                                         + (stockSlipWork.StockDate.Month * 100)
                                         + stockSlipWork.StockDate.Day;

                        string key = stockDateInt.ToString() + stockSlipWork.PartySaleSlipNum.Trim();

                        if (stockSlipWorkDictionary.ContainsKey(key) != true)
                        {
                            stockSlipWorkDictionary.Add(key, stockSlipWork);
                        }
                    }
                }
                # endregion

                # region 更新対象の相手先伝票番号を算出
                //更新対象の相手先伝票番号を算出

                //注文一覧ヘッダー部Dictionary
                Dictionary<string, OrderLstInputDtl> dtlDictionary = new Dictionary<string, OrderLstInputDtl>();

                foreach (string key in orderLstInputDictionary.Keys)
                {
                    //既存の仕入データの存在チェック
                    if (stockSlipWorkDictionary.ContainsKey(key) == true) continue; 

                    //更新対象の相手先伝票番号を取得
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];
                    dtlDictionary.Add(key, dtl);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // 仕入情報の更新用パラメータの作成
                //-----------------------------------------------------------
                # region 仕入情報の更新用パラメータの作成

                //仕入情報の更新用パラメータ定義
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

                
                foreach (string key in dtlDictionary.Keys)
                {
                    # region 仕入日・相手先伝票番号で絞り込み
                    //仕入日・相手先伝票番号で絞り込み
                    OrderLstInputDtl dtl = orderLstInputDictionary[key];
                    DataView view = _uoeSndRcvJnlAcs.GetOrderLstInputFormCreateView(dtl.PlanDate, dtl.SlipNoDtl);
                    if (view.Count == 0) continue;
                    # endregion

                    # region 処理対象クラスの算出
                    //処理対象クラスの算出
                    List<OrderLstInputDtl> orderLstInputDtlList = new List<OrderLstInputDtl>();
                    foreach (DataRowView dataRowView in view)
                    {
                        OrderLstInputDtl orderLstInputDtl = _uoeSndRcvJnlAcs.CreateOrderLstInputDtlFromSchema(dataRowView.Row);
                        if(orderLstInputDtl == null)    continue;
                        orderLstInputDtlList.Add(orderLstInputDtl);
                    }
                    # endregion

                    # region 仕入情報の更新用パラメータの設定
                    //仕入情報の更新用パラメータの設定
                    StockSlipGrp stockSlipGrp = GetStockSlipGrpFromEpartsOrderInput(
                                                    hed.EnterpriseCode,
                                                    hed.SectionCode,
                                                    subSectionCode,
                                                    uOESupplier,
                                                    orderLstInputDtlList);
                    if(stockSlipGrp == null)    continue;
                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
                # endregion

                //-----------------------------------------------------------
                // 仕入情報の更新処理（リモート処理実行）
                //-----------------------------------------------------------
                # region 仕入情報の更新処理（リモート処理実行）
                if ((stockSlipGrpList == null) || (stockSlipGrpList.Count == 0))
                {
                    hed.UpdRsl = 3;
                }
                else
                {
                    status = _uOEAnswerAcs.WriteStockInfo(stockSlipGrpList, out message);
                    status = (int)EnumUoeConst.Status.ct_NORMAL;

                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        hed.UpdRsl = -1;
                        return (status);
                    }

                    //戻り値の設定
                    hed.UpdRsl = 0;//0:正常終了
                }
                # endregion
            }
            catch (Exception ex)
            {
                hed.UpdRsl = -1;
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ▽ ホンダＵＯＥ ＷＥＢ e-Parts 仕入情報の更新用パラメータの算出（手入力）
        /// <summary>
        /// 仕入情報の更新用パラメータの算出（手入力）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">注文一覧明細(手入力)データクラス</param>
        /// <returns>仕入情報オブジェクト</returns>
        private StockSlipGrp GetStockSlipGrpFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, UOESupplier uOESupplier, List<OrderLstInputDtl> list)
        {
   			//変数の初期化
            StockSlipGrp stockSlipGrp = null;
			try
			{
                //-----------------------------------------------------------
                // 仕入先情報の取得
                //-----------------------------------------------------------
                #region 仕入先情報の設定
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(uOESupplier.SupplierCd);
                if (supplier == null)
                {
                    return (null);
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入明細データの取得
                //-----------------------------------------------------------
                #region 仕入明細データの取得
                List<StockDetailWork> stockDetailWorkList = GetstockDetailFromEpartsOrderInput(enterpriseCode, sectionCode, subSectionCode, list, supplier, uOESupplier);
                if (stockDetailWorkList == null) return (stockSlipGrp);
                if (stockDetailWorkList.Count == 0) return (stockSlipGrp);
                #endregion

                //-----------------------------------------------------------
                // 仕入データの取得
                //-----------------------------------------------------------
                #region 仕入データの取得
                StockSlipWork stockSlipWork = GetstockSlipFromEpartsOrderInput(enterpriseCode, sectionCode, subSectionCode, list, stockDetailWorkList, supplier);
                if(stockSlipWork == null)   return (stockSlipGrp);
                #endregion

                //-----------------------------------------------------------
                // 仕入情報オブジェクトの取得
                //-----------------------------------------------------------
                # region 仕入情報オブジェクトの作成
                stockSlipGrp = new StockSlipGrp();
                stockSlipGrp.stockSlipWork = stockSlipWork;
                stockSlipGrp.stockDetailWorkList = stockDetailWorkList;
                # endregion
            }
            catch (Exception)
            {
                stockSlipGrp = null;
            }
            return (stockSlipGrp);
        }
        # endregion

        # region ▽ 仕入データの取得（手入力）
        /// <summary>
        /// 仕入データの取得（手入力）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="list">注文一覧明細(手入力)データクラス</param>
        /// <param name="list">仕入明細オブジェクト</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        private StockSlipWork GetstockSlipFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<OrderLstInputDtl> list, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //変数の初期化
            StockSlipWork rst = null;
            try
            {
                //-----------------------------------------------------------
                // 注文一覧明細の取得
                //-----------------------------------------------------------
                OrderLstInputDtl orderLstInputDtl = list[0];

                //-----------------------------------------------------------
                // 仕入明細の取得
                //-----------------------------------------------------------
                StockDetailWork stockDetailWork = stockDetailWorkList[0];

                //-----------------------------------------------------------
                // 仕入データの設定
                //-----------------------------------------------------------
                //仕入日付の算出
                DateTime stockDate = orderLstInputDtl.PlanDate;

                rst = GetStockSlipFromEpartsInsert(
                                    enterpriseCode,             //企業コード
                                    sectionCode,                //拠点コード
                                    subSectionCode,             //部門コード
                                    stockDate,                  //仕入日付
                                    orderLstInputDtl.SlipNoDtl, //相手先伝票番号
                                    stockDetailWorkList,        //仕入明細オブジェクト
                                    supplier);                  //仕入情報オブジェクト
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

        # region ▽ 仕入明細データの取得（手入力）
        /// <summary>
        /// 仕入明細データの取得（手入力）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="list">注文一覧明細(手入力)データクラス</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <returns>仕入明細オブジェクト</returns>
        private List<StockDetailWork> GetstockDetailFromEpartsOrderInput(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<OrderLstInputDtl> list, Supplier supplier, UOESupplier uOESupplier)
        {
            //変数の初期化
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
			try
			{
                int stockRowNo = 1; //仕入行番号

                foreach (OrderLstInputDtl dtl in list)
                {
                    StockDetailWork stockDetailWork = GetStockDetailWorkFromEpartsInsert(
                                        enterpriseCode,     //企業コード
                                        sectionCode,        //拠点コード
                                        subSectionCode,         //部門コード
                                        stockRowNo,             //仕入行番号
                                        dtl.ShipmGoodsNo,       //品番
                                        dtl.GoodsName,          //品名
                                        dtl.ShipmentCnt,        //数量
                                        dtl.AnswerListPrice,    //定価
                                        dtl.AnswerSalesUnitCost,//単価
                                        _employeeCode,          //担当者コード
                                        _employeeName,          //担当者名
                                        supplier,               //仕入情報オブジェクト
                                        uOESupplier);           //UOE発注情報オブジェクト

                    stockDetailWorkList.Add(stockDetailWork);
                }
            }
            catch (Exception)
            {
                stockDetailWorkList = null;
            }
            return (stockDetailWorkList);
        }
        # endregion

        # region ▽ 仕入データの取得
        /// <summary>
        /// ▽ 仕入データの取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="stockDate">仕入日</param>
        /// <param name="partySaleSlipNum">相手先伝票番号</param>
        /// <param name="list">仕入明細オブジェクト</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        private StockSlipWork GetStockSlipFromEpartsInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, DateTime stockDate, string partySaleSlipNum, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //変数の初期化
            StockSlipWork rst = new StockSlipWork();
            try
            {
                //-----------------------------------------------------------
                // 全体初期値設定マスタの取得
                //-----------------------------------------------------------
                AllDefSet allDefSet = _uoeSndRcvCtlInitAcs.GetAllDefSet();

                //-----------------------------------------------------------
                // 仕入明細の取得
                //-----------------------------------------------------------
                StockDetailWork stockDetailWork = stockDetailWorkList[0];

                //-----------------------------------------------------------
                // 仕入データの設定
                //-----------------------------------------------------------
                # region 仕入データの設定
                rst.EnterpriseCode = enterpriseCode;                                        // 企業コード
                rst.SupplierFormal = 0;	                                                    // 仕入形式　＝　0:仕入
                rst.SupplierSlipNo = 0;	                                                    // 仕入伝票番号
                rst.SectionCode = sectionCode;	                                            // 拠点コード
                rst.SubSectionCode = subSectionCode;	                                    // 部門コード
                rst.DebitNoteDiv = 0;	                                                    // 赤伝区分 ＝　0:黒伝
                rst.DebitNLnkSuppSlipNo = 0;	                                            // 赤黒連結仕入伝票番号
                rst.SupplierSlipCd = 10;	                                                // 仕入伝票区分　＝　10:仕入
                rst.StockGoodsCd = 0;	                                                    // 仕入商品区分　＝　0:商品
                rst.AccPayDivCd = 1;	                                                    // 買掛区分　＝　1:買掛
                rst.StockSectionCd = sectionCode;	                                        // 仕入拠点コード
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // 仕入計上拠点コード
                rst.StockSlipUpdateCd = 0;	                                                // 仕入伝票更新区分 0:未更新
                rst.InputDay = DateTime.Now;	                                            // 入力日　＝　システム日付
                //rst.ArrivalGoodsDay = DateTime.MinValue;	                                // 入荷日  // DEL 2013/01/09 Redmine #33989 張曼
                rst.ArrivalGoodsDay = stockDate;                                            // 入荷日  // ADD 2013/01/09 Redmine #33989 張曼
                rst.StockDate = stockDate;	                                                // 仕入日
                //rst.StockAddUpADate = DateTime.MinValue;	                                // 仕入計上日付
                rst.StockAddUpADate = stockDate;	                                        // 仕入計上日付
                rst.DelayPaymentDiv = 0;	                                                // 来勘区分 0:当月
                rst.PayeeCode = supplier.PayeeCode;                                         // 支払先コード

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // 支払先略称
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                rst.SupplierCd = stockDetailWork.SupplierCd;	                            // 仕入先コード
                rst.SupplierNm1 = supplier.SupplierNm1;                                     // 仕入先名1
                rst.SupplierNm2 = supplier.SupplierNm2;                                     // 仕入先名2
                rst.SupplierSnm = supplier.SupplierSnm;                                     // 仕入先略称
                rst.BusinessTypeCode = supplier.BusinessTypeCode;	                        // 業種コード
                rst.BusinessTypeName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(33, supplier.BusinessTypeCode);            // 業種名称

                rst.SalesAreaCode = supplier.SalesAreaCode;	                                // 販売エリアコード
                rst.SalesAreaName = _uoeSndRcvCtlInitAcs.GetUserGdBdString(21, supplier.SalesAreaCode);	// 販売エリア名称

                rst.StockInputCode = stockDetailWork.StockInputCode;	                    // 仕入入力者コード
                rst.StockInputName = stockDetailWork.StockInputName;	                    // 仕入入力者名称
                rst.StockAgentCode = stockDetailWork.StockAgentCode;	                    // 仕入担当者コード
                rst.StockAgentName = stockDetailWork.StockAgentName;	                    // 仕入担当者名称

                rst.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;	                    // 仕入先総額表示方法区分
                rst.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;	                    // 総額表示掛率適用区分


                rst.TaxAdjust = 0;	                                                        // 消費税調整額
                rst.BalanceAdjust = 0;	                                                    // 残高調整額
                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // 仕入先消費税転嫁方式コード
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);	// 仕入先消費税税率
                rst.AccPayConsTax = 0;	                                                    // 買掛消費税

                // 仕入データの情報算出
                //仕入端数処理区分
                //1:切捨て,2:四捨五入,3:切上げ　（消費税）
                //端数処理単位
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //仕入端数処理区分

                rst.AutoPayment = 0;	                                                    // 自動支払区分 0：通常支払
                rst.AutoPaySlipNum = 0;	                                                    // 自動支払伝票番号
                rst.RetGoodsReasonDiv = 0;	                                                // 返品理由コード
                rst.RetGoodsReason = string.Empty;	                                        // 返品理由
                rst.PartySaleSlipNum = partySaleSlipNum;	                                // 相手先伝票番号
                rst.SupplierSlipNote1 = string.Empty;	                                    // 仕入伝票備考1
                rst.SupplierSlipNote2 = string.Empty;	                                    // 仕入伝票備考2
                rst.DetailRowCount = stockDetailWorkList.Count;	                            // 明細行数　＝　行数カウント値
                rst.EdiSendDate = DateTime.MinValue;	                                    // ＥＤＩ送信日
                rst.EdiTakeInDate = DateTime.MinValue;	                                    // ＥＤＩ取込日
                rst.UoeRemark1 = string.Empty;                                              // ＵＯＥリマーク１
                rst.UoeRemark2 = string.Empty;                                              // ＵＯＥリマーク２
                rst.SlipPrintDivCd = 0;	                                                    // 伝票発行区分
                rst.SlipPrintFinishCd = 0;	                                                // 伝票発行済区分
                rst.StockSlipPrintDate = DateTime.MinValue;	                                // 仕入伝票発行日
                rst.SlipPrtSetPaperId = string.Empty;	                                    // 伝票印刷設定用帳票ID
                rst.SlipAddressDiv = 2;	                                                    // 伝票住所区分　＝　2:納入先
                rst.AddresseeCode = 0;	                                                    // 納品先コード
                rst.AddresseeName = string.Empty;	                                        // 納品先名称
                rst.AddresseeName2 = string.Empty;	                                        // 納品先名称2
                rst.AddresseePostNo = string.Empty;	                                        // 納品先郵便番号
                rst.AddresseeAddr1 = string.Empty;	                                        // 納品先住所1(都道府県市区郡・町村・字)
                rst.AddresseeAddr3 = string.Empty;	                                        // 納品先住所3(番地)
                rst.AddresseeAddr4 = string.Empty;	                                        // 納品先住所4(アパート名称)
                rst.AddresseeTelNo = string.Empty;	                                        // 納品先電話番号
                rst.AddresseeFaxNo = string.Empty;	                                        // 納品先FAX番号
                rst.DirectSendingCd = stockDetailWork.DirectSendingCd;	                    // 直送区分

                // 仕入データの情報算出
                StockSlipPriceCalculator.TotalPriceSetting(
                                            ref rst,
                                            stockDetailWorkList,
                                            stockProcMoney.FractionProcUnit,
                                            stockProcMoney.FractionProcCd);
                #endregion
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                //rst = null;
            }
            return (rst);
        }
        # endregion

        # region ▽ 仕入明細データの取得
        /// <summary>
        /// 仕入明細クラスの取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="stockRowNo">仕入行番号</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsName">品名</param>
        /// <param name="orderCnt">数量</param>
        /// <param name="answerListPrice">定価</param>
        /// <param name="answerSalesUnitCost">単価</param>

        /// <param name="stockAgentCode">仕入担当者コード</param>
        /// <param name="stockAgentName">仕入担当者名称</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <returns>仕入明細オブジェクト</returns>
        private StockDetailWork GetStockDetailWorkFromEpartsInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, int stockRowNo, string goodsNo, string goodsName, double orderCnt, double answerListPrice, double answerSalesUnitCost, string stockAgentCode, string stockAgentName, Supplier supplier, UOESupplier uOESupplier)
        {
            //変数の初期化
            StockDetailWork stockDetailWork = new StockDetailWork();

            try
            {
                //-----------------------------------------------------------
                // 項目値の設定
                //-----------------------------------------------------------
                #region 項目値の設定
                //仕入形式
                stockDetailWork.SupplierFormal = 0; //0:仕入

                //仕入伝票番号
                stockDetailWork.SupplierSlipNo = 0;

                //仕入行番号
                stockDetailWork.StockRowNo = stockRowNo;

                //企業コード
                stockDetailWork.EnterpriseCode = enterpriseCode;

                //拠点コード
                stockDetailWork.SectionCode = sectionCode;

                //部門コード
                stockDetailWork.SubSectionCode = subSectionCode;

                //仕入形式（元）
                stockDetailWork.SupplierFormalSrc = 0;  //0:仕入

                //仕入入力者コード
                stockDetailWork.StockInputCode = _employeeCode;

                //仕入入力者名称
                stockDetailWork.StockInputName = _employeeName;

                //仕入担当者コード
                stockDetailWork.StockAgentCode = stockAgentCode;

                //仕入担当者名称
                stockDetailWork.StockAgentName = stockAgentName;

                //仕入先コード
                stockDetailWork.SupplierCd = supplier.SupplierCd;

                //仕入先略称
                stockDetailWork.SupplierSnm = supplier.SupplierSnm;

                //注文方法
                stockDetailWork.WayToOrder = 0;

                //発注データ作成日
                stockDetailWork.OrderDataCreateDate = DateTime.MinValue;

                //発注書発行済区分
                stockDetailWork.OrderFormIssuedDiv = 0;
                #endregion

                //-----------------------------------------------------------
                // 品番検索結果の設定
                //-----------------------------------------------------------
                # region 品番検索結果の設定
                //商品番号
                stockDetailWork.GoodsNo = goodsNo;

                //商品名称
                stockDetailWork.GoodsName = goodsName;

                //品番検索
                List<GoodsUnitData> GoodsUnitDataList = null;

                int status = this._uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(
                    stockDetailWork.GoodsNo,
                    uOESupplier,
                    out GoodsUnitDataList,
                    false);

                if ((status == 0) && (GoodsUnitDataList != null))
                {
                    //クラス設定
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[0];
                    List<Stock> stockList = GoodsUnitDataList[0].StockList;
                    List<GoodsPrice> goodsPriceList = GoodsUnitDataList[0].GoodsPriceList;

                    //拠点倉庫の在庫情報
                    Stock stock = GetStock_FromSecInfoSet(stockList, goodsUnitData.SelectedWarehouseCode);

                    //価格マスタの取得
                    GoodsPrice goodsPrice = GetGoodsPrice_FromGoodsPriceList(goodsPriceList);

                    # region 商品情報
                    //商品情報
                    stockDetailWork.GoodsNameKana = goodsUnitData.GoodsNameKana;               //商品名称カナ
                    stockDetailWork.GoodsLGroup = goodsUnitData.GoodsLGroup;                   //商品大分類コード
                    stockDetailWork.GoodsLGroupName = goodsUnitData.GoodsLGroupName;           //商品大分類名称
                    stockDetailWork.GoodsMGroup = goodsUnitData.GoodsMGroup;                   //商品中分類コード
                    stockDetailWork.GoodsMGroupName = goodsUnitData.GoodsMGroupName;           //商品中分類名称
                    stockDetailWork.BLGroupCode = goodsUnitData.BLGroupCode;                   //BLグループコード
                    stockDetailWork.BLGroupName = goodsUnitData.BLGroupName;                   //BLグループコード名称
                    stockDetailWork.BLGoodsCode = goodsUnitData.BLGoodsCode;                   //BL商品コード
                    stockDetailWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;           //BL商品コード名称（全角）

                    stockDetailWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;   //自社分類コード
                    stockDetailWork.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;   //自社分類名称
                    stockDetailWork.TaxationCode = goodsUnitData.TaxationDivCd;                //課税区分

                    stockDetailWork.GoodsKindCode = goodsUnitData.GoodsKindCode;               //商品属性
                    stockDetailWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                 //商品メーカーコード
                    stockDetailWork.MakerName = goodsUnitData.MakerName;                       //メーカー名称
                    stockDetailWork.MakerKanaName = goodsUnitData.MakerKanaName;               //メーカーカナ名称
                    stockDetailWork.RateBLGoodsCode = goodsUnitData.BLGoodsCode;               //BL商品コード（掛率）
                    stockDetailWork.RateBLGoodsName = goodsUnitData.BLGoodsFullName;           //BL商品コード名称（掛率）
                    stockDetailWork.StockOrderDivCd = stock.WarehouseCode.Trim() == "" ? 0 : 1;//仕入在庫取寄せ区分 0:取寄せ,1:在庫
                    #endregion

                    # region 価格情報
                    //価格情報
                    if (goodsPrice != null)
                    {
                        stockDetailWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;                 //オープン価格区分
                    }
                    #endregion

                    # region 在庫情報
                    //在庫情報
                    if (stock != null)
                    {
                        //倉庫コード
                        stockDetailWork.WarehouseCode = stock.WarehouseCode;

                        //倉庫名称
                        stockDetailWork.WarehouseName = stock.WarehouseName;

                        //倉庫棚番
                        stockDetailWork.WarehouseShelfNo = stock.WarehouseShelfNo;
                    }
                    #endregion
                }
                #endregion

                //-----------------------------------------------------------
                // 発注数
                //-----------------------------------------------------------
                #region 発注数の設定
                stockDetailWork.OrderCnt = orderCnt;
                stockDetailWork.StockCount = orderCnt;
                stockDetailWork.OrderRemainCnt = orderCnt;
                #endregion

                //-----------------------------------------------------------
                // 課税区分の算出(0:課税,1:非課税,2:課税（内税）)
                //-----------------------------------------------------------
                #region 課税区分の算出
                int dstTaxationCode = (int)stockDetailWork.TaxationCode;

                if ((supplier.SuppCTaxLayCd == 9)
                || (supplier.SuppCTaxationCd == 1)
                || (dstTaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
                {
                    dstTaxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                }
                #endregion

                //-----------------------------------------------------------
                // 変更前定価
                //-----------------------------------------------------------
                #region 変更前定価
                stockDetailWork.BfListPrice = stockDetailWork.ListPriceTaxExcFl;
                #endregion

                //-----------------------------------------------------------
                // 定価
                //-----------------------------------------------------------
                #region 定価
                //定価（税抜，浮動）
                double dstPrice = answerListPrice;
                stockDetailWork.ListPriceTaxExcFl = dstPrice;

                //定価（税込，浮動）
                if (supplier != null)
                {
                    stockDetailWork.ListPriceTaxIncFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                }
                #endregion

                //-----------------------------------------------------------
                // 変更前仕入単価（浮動）
                //-----------------------------------------------------------
                #region 変更前仕入単価（浮動）
                stockDetailWork.BfStockUnitPriceFl = answerSalesUnitCost;
                #endregion

                //-----------------------------------------------------------
                // 仕入単価変更区分
                //-----------------------------------------------------------
                #region 仕入単価変更区分
                //仕入単価変更区分
                //変更前原価と回答原価が異なる

                double srcCost = stockDetailWork.BfStockUnitPriceFl;
                double dstCost = answerSalesUnitCost;

                if (srcCost != dstCost)
                {
                    stockDetailWork.StockUnitChngDiv = 1;
                }
                //変更前原価と回答原価が同一
                else
                {
                    stockDetailWork.StockUnitChngDiv = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入単価
                //-----------------------------------------------------------
                #region 仕入単価
                //仕入単価（税抜，浮動）
                stockDetailWork.StockUnitPriceFl = answerSalesUnitCost;

                //仕入単価（税込，浮動）
                if (supplier != null)
                {
                    stockDetailWork.StockUnitTaxPriceFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstCost, dstTaxationCode, supplier.StockCnsTaxFrcProcCd);
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入金額の算出
                //-----------------------------------------------------------
                #region 仕入金額
                if (supplier != null)
                {
                    long stockPriceTaxInc = 0;
                    long stockPriceTaxExc = 0;
                    long stockPriceConsTax = 0;
                    Int32 cnt = (Int32)orderCnt;

                    bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                        (double)cnt,
                        (double)stockDetailWork.StockUnitPriceFl,
                        dstTaxationCode,
                        supplier.StockMoneyFrcProcCd,
                        supplier.StockCnsTaxFrcProcCd,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax);

                    if (bStatus == true)
                    {
                        //仕入金額（税抜き）
                        stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;

                        //仕入金額（税込み）
                        stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
                    }
                    else
                    {
                        stockDetailWork.StockPriceTaxExc = 0;
                        stockDetailWork.StockPriceTaxInc = 0;
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // 消費税の算出
                //-----------------------------------------------------------
                #region 消費税
                //仕入金額消費税額
                stockDetailWork.StockPriceConsTax = (Int64)stockDetailWork.StockPriceTaxInc
                                                  - (Int64)stockDetailWork.StockPriceTaxExc;
                #endregion
            }
            catch (Exception)
            {
                stockDetailWork = null;
            }
            return (stockDetailWork);
        }
        # endregion

        # region ▽ メイン倉庫の在庫情報取得
        /// <summary>
        /// メイン倉庫の在庫情報取得
        /// </summary>
        /// <param name="list">在庫情報リスト</param>
        /// <param name="selectedWarehouseCode">選択倉庫コード</param>
        /// <returns>在庫情報</returns>
        private Stock GetStock_FromSecInfoSet(List<Stock> list, string selectedWarehouseCode)
        {
            string sectWarehouseCd = "";
            Stock returnStock = null;

            try
            {
                if (list == null)
                {
                    returnStock = new Stock();
                    return (returnStock);
                }

                for (int i = 0; (i < 4) && (returnStock == null); i++)
                {
                    switch (i)
                    {
                        //選択倉庫の検索
                        case 0:
                            sectWarehouseCd = selectedWarehouseCode;
                            break;
                        //優先倉庫①の検索
                        case 1:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd1;
                            break;
                        //優先倉庫②の検索
                        case 2:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd2;
                            break;
                        //優先倉庫③の検索
                        case 3:
                            sectWarehouseCd = _secInfoSet.SectWarehouseCd3;
                            break;
                    }

                    if (sectWarehouseCd == null) continue;
                    if (sectWarehouseCd.Trim() == "") continue;

                    foreach (Stock stock in list)
                    {
                        if (stock.WarehouseCode.Trim() == sectWarehouseCd.Trim())
                        {
                            returnStock = stock;
                            break;
                        }
                    }
                }
            }
            catch (ConstraintException)
            {
                returnStock = null;
            }
            if (returnStock == null)
            {
                returnStock = new Stock();
            }
            return (returnStock);
        }
        # endregion

        # region ▽ 価格マスタの検索
        /// <summary>
        /// 価格マスタの検索
        /// </summary>
        /// <param name="list">価格マスタリスト</param>
        /// <returns>価格マスタ</returns>
        public GoodsPrice GetGoodsPrice_FromGoodsPriceList(List<GoodsPrice> list)
        {
            return (_goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, list));
        }
        # endregion

        # region ▽ 従業員マスタクラスの取得
        /// <summary>
        /// 従業員マスタクラスの取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            Employee employee = null;
            EmployeeDtl employeeDtl = null;
                
            try
            {
                EmployeeAcs employeeAcs = new EmployeeAcs(); 			// 従業員情報 アクセスクラス
                int status = employeeAcs.Read(out employee, out employeeDtl, enterpriseCode, employeeCode);
                if (status != 0)
                {
                    employeeDtl = null;
                }
            }
            catch (ConstraintException)
            {
                employeeDtl = null;
            }
            return (employeeDtl);
        }
        #endregion
        # endregion

        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts回答更新（ＰＭ連動時）
        /// <summary>
        /// ホンダＵＯＥ ＷＥＢ e-Parts回答更新（ＰＭ連動時）
        /// </summary>
        /// <param name="hed">注文一覧データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
		/// <remarks>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2009/05/25</br>
        /// <br>Update Note: 2012/05/23 wangf </br>
        /// <br>           : 10801804-00、06/27配信分、Redmine#29900 在庫入庫更新 在庫入庫更新で検索時にエラーが発生するの対応</br>
        /// <br>Update Note: 2013/03/08 堀田 </br>
        /// <br>           : 10801804-00、06/27配信分、Redmine#29900の対応を削除し変更前に戻す</br>
        /// </remarks>
        private int EpartsUoeWebOrderCtlPm(ref OrderLsthead hed, out string message)
        {
			//変数の初期化
            string procNm = "EpartsUoeWebOrderCtlPm";
            string asseNm = "";
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // 結果クラスの初期化
                //-----------------------------------------------------------
                # region 結果クラスの初期化
                // 注文一覧明細（PM連動）クラス
                // 2013/03/08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////ArrayList lstDtl = hed.LstDtl;  // DEL wangf 2012/05/23 FOR Redmine#29900
                //// ------------ADD START wangf 2012/05/23 FOR Redmine#29900--------->>>>
                //ArrayList lstDtl = new ArrayList();
                //foreach (OrderLstPmDtl dtl in hed.LstDtl)
                //{
                //    //出庫元が「鈴鹿・狭山」の場合、伝票番号に「-F」を付加する
                //    if ((dtl.SourceShipment.IndexOf("鈴鹿") != -1) || (dtl.SourceShipment.IndexOf("狭山") != -1))
                //    {
                //        if (!string.IsNullOrEmpty(dtl.SlipNoDtl))
                //            dtl.SlipNoDtl = dtl.SlipNoDtl.Trim() + "-F";
                //    }
                //
                //    lstDtl.Add(dtl);
                //}
                //// ------------ADD END wangf 2012/05/23 FOR Redmine#29900---------<<<<<
                ArrayList lstDtl = hed.LstDtl;  
                // 2013/03/08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (lstDtl == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                if (lstDtl.Count == 0)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                _uOEOrderDtlWorkList = null;    //UOE発注ワークリスト
                _stockDetailWorkList = null;    //仕入明細ワークリスト
                # endregion

                //-----------------------------------------------------------
                // ＵＯＥ発注先マスタの取得
                //-----------------------------------------------------------
                # region ＵＯＥ発注先マスタの取得
                UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(hed.UOESupplierCd);
                if (uOESupplier == null)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }

                // --- UPD m.suzuki 2010/11/08 ---------->>>>>
                ////if (uOESupplier.CommAssemblyId.Trim() != "0502") // DEL 2009/12/29 xuxh
                //if (!CanSendAndReceive(uOESupplier)) // ADD 2009/12/29 xuxh
                if ( uOESupplier.CommAssemblyId.Trim() != EnumUoeConst.ctCommAssemblyId_0502 )
                // --- UPD m.suzuki 2010/11/08 ----------<<<<<
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // 発注情報の取得
                //-----------------------------------------------------------
                # region 発注情報の取得
                //ＫＥＹ情報の算出
                Dictionary<String, OrderLstPmDtl> orderLstPmDtlDictionary = new Dictionary<String, OrderLstPmDtl>();

                //条件抽出クラスの設定
                ArrayList paraAry = new ArrayList();
                foreach (OrderLstPmDtl dtl in lstDtl)
                {
                    //格納チェック
                    String dtlKey = dtl.LinkNo.ToString("d9") + dtl.OrderGoodsNo;
                    if (orderLstPmDtlDictionary.ContainsKey(dtlKey) == true) continue;
                    orderLstPmDtlDictionary.Add(dtlKey, dtl);
                    
                    //格納処理
                    UOEOdrDtlGodsReadCndtnWork uOEOdrDtlGodsReadCndtnWork = new UOEOdrDtlGodsReadCndtnWork();

                    uOEOdrDtlGodsReadCndtnWork.EnterpriseCode = hed.EnterpriseCode;
                    uOEOdrDtlGodsReadCndtnWork.SectionCode = hed.SectionCode;
                    uOEOdrDtlGodsReadCndtnWork.UOESupplierCd = hed.UOESupplierCd;
                    uOEOdrDtlGodsReadCndtnWork.UOESalesOrderNo = dtl.LinkNo;
                    uOEOdrDtlGodsReadCndtnWork.GoodsNoNoneHyphen = dtl.OrderGoodsNo;
                    uOEOdrDtlGodsReadCndtnWork.DataSendCodes = new int[2] {1, 9};

                    paraAry.Add(uOEOdrDtlGodsReadCndtnWork);
                }

                //発注情報の取得リモート実行
                List<UOEOrderDtlWork> returnUOEOrderDtlWorkList = null;
                List<StockDetailWork> returnStockDetailWorkList = null;

                status = _uoeOrderInfoAcs.UoeOdrDtlGodsReadAll(
			                paraAry,
                            out returnUOEOrderDtlWorkList,
                            out returnStockDetailWorkList,
			                out message);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (returnUOEOrderDtlWorkList.Count == 0)
                        {
                            message = "該当データが存在しません。";
                            hed.UpdRsl = -1;
                            return ((int)EnumUoeConst.Status.ct_NORMAL);
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "該当データが存在しません。";
                        hed.UpdRsl = -1;
                        return ((int)EnumUoeConst.Status.ct_NORMAL);
                    default:
                        return (status);
                }
                # endregion

                //-----------------------------------------------------------
                // ＜DtlRelationGuid＞設定
                //-----------------------------------------------------------
                # region ＜DtlRelationGuid＞設定
                Dictionary<Int64, Guid> guidDictionary = new Dictionary<Int64, Guid>();

                # region ＵＯＥ発注データの＜DtlRelationGuid＞設定
                // ＵＯＥ発注データの＜DtlRelationGuid＞設定
                _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();

                foreach(UOEOrderDtlWork dtl in returnUOEOrderDtlWorkList)
                {
                    if (dtl.DataSendCode != 1) continue;

                    Guid guid = Guid.NewGuid();
                    Int64 stockSlipDtlNum = dtl.StockSlipDtlNum;

                    dtl.DtlRelationGuid = guid;
                    if(guidDictionary.ContainsKey(stockSlipDtlNum) != true)
                    {
                        guidDictionary.Add(stockSlipDtlNum, guid);
                    }
                    _uOEOrderDtlWorkList.Add(dtl);
                }

                if (_uOEOrderDtlWorkList.Count == 0)
                {
                    hed.UpdRsl = 3; //取込済
                    return ((int)EnumUoeConst.Status.ct_NORMAL);
                }
                # endregion

                # region 仕入明細データの＜DtlRelationGuid＞設定
                // 仕入明細データの＜DtlRelationGuid＞設定
                _stockDetailWorkList = new List<StockDetailWork>();

                foreach(StockDetailWork dtl in returnStockDetailWorkList)
                {
                    Int64 stockSlipDtlNum = dtl.StockSlipDtlNum;
                    if (guidDictionary.ContainsKey(stockSlipDtlNum) != true) continue;

                    Guid guid = guidDictionary[stockSlipDtlNum];
                    dtl.DtlRelationGuid = guid;
                    _stockDetailWorkList.Add(dtl);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // 送受信ＪＮＬテーブル・ＵＯＥ発注データテーブル・仕入明細テーブルの作成
                //-----------------------------------------------------------
		        # region 送受信ＪＮＬテーブル・ＵＯＥ発注データテーブル・仕入明細テーブルの作成
                # region ＵＯＥ発注データ→ＵＯＥ発注データテーブルの作成
                // ＵＯＥ発注データ→ＵＯＥ発注データテーブルの作成
                status = _uoeSndRcvJnlAcs.ToDataTableFromUOEOrderDtlList(_uOEOrderDtlWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                # region 仕入明細→仕入明細テーブルの作成
                //仕入明細→仕入明細テーブルの作成
                foreach (StockDetailWork stockDetailWork in _stockDetailWorkList)
                {
                    status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(StockDetailTable, stockDetailWork, "", 0, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion

                # region 仕入明細テーブルに共通伝票番号・共通伝票行番号を設定
                // 仕入明細テーブルに共通伝票番号・共通伝票行番号を設定
                int supplierFormal = _stockDetailWorkList[0].SupplierFormal;
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailWork(
                                                            StockDetailTable,
                                                            supplierFormal,
                                                            uOEOrderDtlWork.DtlRelationGuid,
                                                            uOEOrderDtlWork.UOESalesOrderNo.ToString("d9"),
                                                            uOEOrderDtlWork.UOESalesOrderRowNo,
                                                            out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion

                # region ＵＯＥ発注データ→送受信ＪＮＬテーブルの作成
                // ＵＯＥ発注データ→送受信ＪＮＬテーブルの作成
				status = _uoeSndRcvJnlAcs.orderJnlFromDtlWrite(_uOEOrderDtlWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // ホンダＵＯＥ ＷＥＢ e-Parts回答データ更新処理
                //-----------------------------------------------------------
                # region ホンダＵＯＥ ＷＥＢ e-Parts回答データ更新処理
                asseNm = "ホンダＵＯＥ ＷＥＢ e-Parts回答データ更新処理";
                logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                if (_uOEAnswerAcs == null)
                {
                    _uOEAnswerAcs = new UOEAnswerAcs();
                }

                status = _uOEAnswerAcs.UpDtAnswerEParts(uOESupplier, lstDtl, out message);

                logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);

                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                for (int index = 0; index < 3; index++)
                {
                    //-----------------------------------------------------------
                    // 売上・仕入データ更新用マラメータの設定
                    //-----------------------------------------------------------
                    # region システム区分の決定
                    //システム区分の決定
                    _uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
                    _uoeSndRcvCtlPara.BusinessCode = (int)EnumUoeConst.TerminalDiv.ct_Order;
                    _uoeSndRcvCtlPara.EnterpriseCode = hed.EnterpriseCode;
                    _uoeSndRcvCtlPara.ProcessDiv = 0;   //0:通常
                    _uoeSndRcvCtlPara.SystemDivCd = 0;  //0:手入力 1:伝発 2:検索 3：一括 4：補充

                    switch(index)
                    {
                        //手入力
                        case 0:
                            _uoeSndRcvCtlPara.SystemDivCd = 0;  //0:手入力 1:伝発 2:検索 3：一括 4：補充
                            break;
                        //2:検索
                        case 1:
                            _uoeSndRcvCtlPara.SystemDivCd = 2;  //0:手入力 1:伝発 2:検索 3：一括 4：補充
                            break;
                        //3:伝発
                        case 2:
                            _uoeSndRcvCtlPara.SystemDivCd = 1;  //0:手入力 1:伝発 2:検索 3：一括 4：補充
                            break;
                    }
                    #endregion

                    # region UOE発注データテーブルの絞り込み
                    //UOE発注データテーブルの絞り込み
                    DataView view = new DataView(this.UOEOrderDtlTable);

                    string rowFilterText = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                                UOEOrderDtlSchema.ct_Col_SystemDivCd, _uoeSndRcvCtlPara.SystemDivCd,
                                UOEOrderDtlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_OK,
                                UOEOrderDtlSchema.ct_Col_DataRecoverDiv, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO
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

                    if (view.Count == 0) continue;
                    #endregion

                    # region UOE発注テーブル→送受信ＪＮＬ（発注）
                    //UOE発注テーブル→送受信ＪＮＬ（発注）

                    OrderTable.Clear(); //送受信JNL（発注）
                    foreach (DataRowView orderDtlRow in view)
                    {
                        DataRow jnlRow = OrderTable.NewRow();

                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CreateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_CreateDateTime];// 作成日時
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdateDateTime];// 更新日時
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterpriseCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterpriseCode];// 企業コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FileHeaderGuid] = (Guid)orderDtlRow[UOEOrderDtlSchema.ct_Col_FileHeaderGuid];// GUID
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdEmployeeCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode];// 更新従業員コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdAssemblyId1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1];// 更新アセンブリID1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UpdAssemblyId2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2];// 更新アセンブリID2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_LogicalDeleteCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode];// 論理削除区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SystemDivCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SystemDivCd];// システム区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo];// UOE発注番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo];// UOE発注行番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SendTerminalNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SendTerminalNo];// 送信端末番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESupplierCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESupplierCd];// UOE発注先コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESupplierName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESupplierName];// UOE発注先名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CommAssemblyId] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_CommAssemblyId];// 通信アセンブリID
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_OnlineNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_OnlineNo];// オンライン番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_OnlineRowNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_OnlineRowNo];// オンライン行番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesDate] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesDate];// 売上日付
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_InputDay] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_InputDay];// 入力日
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataUpdateDateTime] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime];// データ更新日時
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEKind] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEKind];// UOE種別
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesSlipNum] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesSlipNum];// 売上伝票番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AcptAnOdrStatus] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus];// 受注ステータス
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesSlipDtlNum] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum];// 売上明細通番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SectionCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SectionCode];// 拠点コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SubSectionCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SubSectionCode];// 部門コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CustomerCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_CustomerCode];// 得意先コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CustomerSnm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_CustomerSnm];// 得意先略称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CashRegisterNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_CashRegisterNo];// レジ番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_CommonSeqNo] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_CommonSeqNo];// 共通通番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierFormal] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierFormal];// 仕入形式
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierSlipNo] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierSlipNo];// 仕入伝票番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_StockSlipDtlNum] = (Int64)orderDtlRow[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum];// 仕入明細通番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BoCode];// BO区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv];// UOE納品区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DeliveredGoodsDivNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm];// 納品区分名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FollowDeliGoodsDiv] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv];// フォロー納品区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_FollowDeliGoodsDivNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm];// フォロー納品区分名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEResvdSection];// UOE指定拠点
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSectionNm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm];// UOE指定拠点名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EmployeeCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EmployeeCode];// 従業員コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EmployeeName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_EmployeeName];// 従業員名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsMakerCd];// 商品メーカーコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MakerName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MakerName];// メーカー名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsNo];// 商品番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen];// ハイフン無商品番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_GoodsName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_GoodsName];// 商品名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseCode];// 倉庫コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseName];// 倉庫名称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_WarehouseShelfNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo];// 倉庫棚番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt];// 受注数量
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ListPrice] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_ListPrice];// 定価（浮動）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SalesUnitCost] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_SalesUnitCost];// 原価単価
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierCd];// 仕入先コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SupplierSnm] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SupplierSnm];// 仕入先略称
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark1];// ＵＯＥリマーク１
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UoeRemark2];// ＵＯＥリマーク２
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = (DateTime)orderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveDate];// 受信日付
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_ReceiveTime];// 受信時刻
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerMakerCd];// 回答メーカーコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsNo];// 回答品番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerPartsName];// 回答品名
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SubstPartsNo];// 代替品番
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt];// UOE拠点出庫数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1];// BO出庫数1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2];// BO出庫数2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3];// BO出庫数3
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MakerFollowCnt];// メーカーフォロー数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_NonShipmentCnt];// 未出庫数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectStockCnt];// UOE拠点在庫数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount1];// BO在庫数1
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount2];// BO在庫数2
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOStockCount3];// BO在庫数3
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo];// UOE拠点伝票番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo1];// BO伝票番号１
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo2];// BO伝票番号２
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOSlipNo3];// BO伝票番号３
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EOAlwcCount];// EO引当数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOManagementNo];// BO管理番号
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerListPrice];// 回答定価
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = (Double)orderDtlRow[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];// 回答原価単価
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOESubstMark];// UOE代替マーク
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEStockMark] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEStockMark];// UOE在庫マーク
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_PartsLayerCd];// 層別コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1];// UOE出荷拠点コード１（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2];// UOE出荷拠点コード２（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3];// UOE出荷拠点コード３（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1];// UOE拠点コード１（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2];// UOE拠点コード２（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3];// UOE拠点コード３（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4];// UOE拠点コード４（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5];// UOE拠点コード５（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6];// UOE拠点コード６（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7];// UOE拠点コード７（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1];// UOE在庫数１（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2];// UOE在庫数２（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3];// UOE在庫数３（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4];// UOE在庫数４（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5];// UOE在庫数５（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6];// UOE在庫数６（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7];// UOE在庫数７（マツダ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEDistributionCd];// UOE卸コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEOtherCd];// UOE他コード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEHMCd] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEHMCd];// UOEＨＭコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_BOCount] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_BOCount];// ＢＯ数
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOEMarkCode];// UOEマークコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_SourceShipment];// 出荷元
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_ItemCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_ItemCode];// アイテムコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_UOECheckCode] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_UOECheckCode];// UOEチェックコード
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_HeadErrorMassage];// ヘッドエラーメッセージ
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = (string)orderDtlRow[UOEOrderDtlSchema.ct_Col_LineErrorMassage];// ラインエラーメッセージ
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataSendCode];// データ送信区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_DataRecoverDiv];// データ復旧区分
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivSec] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];// 入庫更新区分（拠点）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO1] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];// 入庫更新区分（BO1）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO2] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];// 入庫更新区分（BO2）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivBO3] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];// 入庫更新区分（BO3）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivMaker] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];// 入庫更新区分（ﾒｰｶｰ）
                        jnlRow[OrderSndRcvJnlSchema.ct_Col_EnterUpdDivEO] = (Int32)orderDtlRow[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];// 入庫更新区分（EO）

                        jnlRow[OrderSndRcvJnlSchema.ct_Col_DtlRelationGuid] = (Guid)orderDtlRow[UOEOrderDtlSchema.ct_Col_DtlRelationGuid];// 明細関連付けGUID

                        OrderTable.Rows.Add(jnlRow);
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 売上・仕入データ作成処理
                    //-----------------------------------------------------------
                    # region 売上・仕入データ作成処理
                    //売上・仕入データ作成処理
                    _uoeSalesList = null;
                    if (( (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                      || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                      || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)))
				    {
                        if (_uOESalesStockAcs == null)
                        {
                            _uOESalesStockAcs = new UOESalesStockAcs();
                        }

                        asseNm = "売上・仕入データ作成";
                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                        status = _uOESalesStockAcs.UpDtSalesStock(_uoeSndRcvCtlPara, out _uoeSalesList, out message);

                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);
                    }
                    #endregion

                    // --- ADD 2014/11/04 Y.Wakita ---------->>>>>
                    //-----------------------------------------------------------
                    // ＳＣＭ回答送信処理
                    //-----------------------------------------------------------
                    # region ＳＣＭ回答送信処理
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        if (_uOESalesStockAcs != null)
                        {
                            if (_uOESalesStockAcs.scmFlg)
                            {
                                if (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                                {
                                    List<string> salesSlipNumList = new List<string>();
                                    foreach (DataRow salesSlipRow in _uOESalesStockAcs.SalesSlipTable.Rows)
                                    {
                                        if (salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim().Length != 0)
                                        {
                                            salesSlipNumList.Add(salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim());
                                        }
                                    }
                                    //起動時パス
                                    string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                                    if (directoryName.Length > 0)
                                    {
                                        if (directoryName[directoryName.Length - 1] != '\\')
                                        {
                                            directoryName = directoryName + "\\";
                                        }
                                    }
                                    string startInfoFileName = directoryName + "PMSCM01100U.EXE";

                                    //起動時パラメータ
                                    string param = Environment.GetCommandLineArgs()[1] + " " +
                                                   Environment.GetCommandLineArgs()[2];

                                    string salesSlipNum = string.Empty;
                                    // 回答送信処理時に対象となる売上伝票番号リストをパラメータにセットする
                                    if (salesSlipNumList != null && salesSlipNumList.Count != 0)
                                    {
                                        for (int i = 0; i < salesSlipNumList.Count; i++)
                                        {
                                            if (i != 0)
                                            {
                                                salesSlipNum += ",";
                                            }
                                            salesSlipNum += salesSlipNumList[i].ToString();
                                        }
                                        Process p = Process.Start(startInfoFileName, param + " /A" + " 0:0:" + salesSlipNum);
                                        p.WaitForExit();
                                    }
                                }
                            }
                        }
                    }
                    # endregion
                    // --- ADD 2014/11/04 Y.Wakita ----------<<<<<

                    //-----------------------------------------------------------
                    // ＵＯＥ伝票印刷呼び出し
                    //-----------------------------------------------------------
                    # region ＵＯＥ伝票印刷呼び出し
                    if ((_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    && (_uoeSalesList != null))
                    {
                        if (_uoeSalesList.Count > 0)
                        {
                            // UOE伝票印刷条件セット
                            UOESlipPrintCndtn slipPrintCndtn = new UOESlipPrintCndtn();
                            slipPrintCndtn.EnterpriseCode = _enterpriseCode;
                            slipPrintCndtn.UOESalesList = _uoeSalesList;

                            // 伝票印刷
                            DCCMN02000UA printDisp = new DCCMN02000UA();
                            printDisp.ShowDialog(slipPrintCndtn, true);
                        }
                    }
                    #endregion
                }

            }
			catch (Exception ex)
			{
                hed.UpdRsl = -1;
                status = -1;
				message = ex.Message;
			}

            //正常終了を設定
            if (status == (int)EnumUoeConst.Status.ct_NORMAL)
            {
                hed.UpdRsl = 0;
            }
            return (status);
        }
        # endregion
        # endregion


        # endregion
    }
}
