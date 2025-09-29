//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信制御アクセスクラス
// プログラム概要   : ホンダＵＯＥ ＷＥＢ e-Parts引当制御処理
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
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/11/08  修正内容 : ホンダＵＯＥ ＷＥＢ e-Parts引当制御の対象判定を修正。
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 鄭慕鈞  2013/03/13配信分
// 作 成 日  2013/01/31  修正内容 : Redmine#33991  伝票番号引当処理 仕入データの仕入先コードの設定不正の対応                               
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// ＵＯＥ送受信制御アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ホンダＵＯＥ ＷＥＢ e-Parts引当制御処理</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2009/05/25 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note  : 2009/12/29 xuxh</br>
    /// <br>              ・【要件No.2】と【要件No.3】の修正</br>
    /// <br>Update Note  : 2010/11/08 22018 鈴木 正臣</br>
    /// <br>              ・ホンダＵＯＥ ＷＥＢ e-Parts引当制御の対象判定を修正。</br>
    /// </remarks>
	public partial class UoeSndRcvCtlAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
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
        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts引当制御処理
        /// <summary>
        /// ホンダＵＯＥ ＷＥＢ e-Parts引当制御処理
        /// </summary>
        /// <param name="list">買上一覧データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 96186 立花 裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        public int EpartsUoeWebBuyCtl(ref List<BuyOutLsthead> list, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                // 買上一覧データリストの保存
                List<BuyOutLsthead> retBuyOutLsthead = new List<BuyOutLsthead>();

                foreach (BuyOutLsthead hed in list)
                {
                    // ＵＯＥ送受信制御初期化
                    if ((status = UoeSndRcvCtlInit(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        break;
                    }

                    //ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御メイン
                    BuyOutLsthead buyOutLsthead = hed.Clone();

                    //買上一覧処理
                    if (buyOutLsthead.CsvKnd == 0)
                    {
                        if ((status = EpartsUoeWebBuyCtlProc(ref buyOutLsthead, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }
                    //認識不明形式
                    else
                    {
                        continue;
                    }

                    retBuyOutLsthead.Add(buyOutLsthead);
                }


                //戻値を設定
                list = retBuyOutLsthead;
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
        # region ■ ホンダＵＯＥ ＷＥＢ e-Parts引当処理
        # region ▽ ホンダＵＯＥ ＷＥＢ e-Parts引当制御メイン
        /// <summary>
        /// ホンダＵＯＥ ＷＥＢ e-Parts引当制御メイン
        /// </summary>
        /// <param name="list">買上一覧データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 96186 立花 裕輔</br>
        /// <br>Date       : 2009/05/25</br>
        /// </remarks>
        private int EpartsUoeWebBuyCtlProc(ref BuyOutLsthead hed, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // 結果クラスの初期化
                //-----------------------------------------------------------
                # region 結果クラスの初期化
                # region 買上一覧明細クラス
                // 買上買上一覧明細クラス
                ArrayList lstDtl = hed.LstDtl;
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
                # endregion

                # region 買上一覧明細データテーブルRow作成
                //買上一覧明細データテーブルRow作成
                if ((status = _uoeSndRcvJnlAcs.buyOutLstDtlFromDtlWrite(lstDtl, out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    hed.UpdRsl = -1;
                    return (status);
                }
                # endregion

                # region 「注文月日+注文時伝票番号」・「買上日+買上時伝票番号」値を算出
                //買上時伝票番号Dictionary
                Dictionary<string, BuyOutLstDtl> buyOutDictionary = new Dictionary<string, BuyOutLstDtl>();

                //注文時伝票番号Dictionary
                Dictionary<string, BuyOutLstDtl> orderDictionary = new Dictionary<string, BuyOutLstDtl>();

                // 「相手先伝票番号」値を算出
                foreach (BuyOutLstDtl dtl in lstDtl)
                {
                    //買上時伝票番号(9999999999)
                    string buyOutKey = dtl.BuyOutSlipNo.Trim();
                    if (buyOutDictionary.ContainsKey(buyOutKey) != true)
                    {
                        buyOutDictionary.Add(buyOutKey, dtl);
                    }

                    //注文時伝票番号(999999)
                    string orderKey = dtl.OrderSlipNo.Trim();
                    if (orderDictionary.ContainsKey(orderKey) != true)
                    {
                        orderDictionary.Add(orderKey, dtl);
                    }
                }
                # endregion
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
                    return (-1);
                }
                #endregion
                
                //-----------------------------------------------------------
                // 仕入データの読込（リモート処理実行）
                //-----------------------------------------------------------
                # region 仕入データの読込（リモート処理実行）
                # region 条件抽出クラスの作成
                //注文時伝票番号Dictionary
                Dictionary<string, StockSlipWork> stockSlipInfoDictionary = new Dictionary<string, StockSlipWork>();

                # region 買上時相手先伝票番号
                //買上時相手先伝票番号
                foreach (string key in buyOutDictionary.Keys)
                {
                    BuyOutLstDtl dtl = buyOutDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    stockSlipWork.SectionCode = hed.SectionCode;        //拠点コード
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //仕入先コード
                    stockSlipWork.SupplierFormal = 0;                   //0:仕入
                    stockSlipWork.StockDate = DateTime.MinValue;        //仕入日
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //入荷日
                    stockSlipWork.PartySaleSlipNum = dtl.BuyOutSlipNo.Trim(); //相手先伝票番号

                    //格納処理
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region 買上時相手先伝票番号 + 「-F」
                //買上時相手先伝票番号 + 「-F」
                foreach (string key in buyOutDictionary.Keys)
                {
                    BuyOutLstDtl dtl = buyOutDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    stockSlipWork.SectionCode = hed.SectionCode;        //拠点コード
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //仕入先コード
                    stockSlipWork.SupplierFormal = 0;                   //0:仕入
                    stockSlipWork.StockDate = DateTime.MinValue;        //仕入日
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //入荷日
                    stockSlipWork.PartySaleSlipNum = dtl.BuyOutSlipNo.Trim() + "-F"; //相手先伝票番号

                    //格納処理
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region 注文時相手先伝票番号
                //注文時相手先伝票番号
                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    stockSlipWork.SectionCode = hed.SectionCode;        //拠点コード
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //仕入先コード
                    stockSlipWork.SupplierFormal = 0;                   //0:仕入
                    stockSlipWork.StockDate = DateTime.MinValue;        //仕入日
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //入荷日
                    stockSlipWork.PartySaleSlipNum = dtl.OrderSlipNo.Trim(); //相手先伝票番号

                    //格納処理
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region 注文時相手先伝票番号 + 「-F」
                //注文時相手先伝票番号 + 「-F」
                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    StockSlipWork stockSlipWork = new StockSlipWork();

                    stockSlipWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    stockSlipWork.SectionCode = hed.SectionCode;        //拠点コード
                    stockSlipWork.SupplierCd = uOESupplier.SupplierCd;  //仕入先コード
                    stockSlipWork.SupplierFormal = 0;                   //0:仕入
                    stockSlipWork.StockDate = DateTime.MinValue;        //仕入日
                    stockSlipWork.ArrivalGoodsDay = DateTime.MinValue;  //入荷日
                    stockSlipWork.PartySaleSlipNum = dtl.OrderSlipNo.Trim() + "-F"; //相手先伝票番号

                    //格納処理
                    string stockKey = stockSlipWork.PartySaleSlipNum;
                    if (stockSlipInfoDictionary.ContainsKey(stockKey) != true)
                    {
                        stockSlipInfoDictionary.Add(stockKey, stockSlipWork);
                    }
                }
                # endregion

                # region 条件抽出クラスの作成
                //条件抽出クラスの作成
                ArrayList stockSlipWorkAry = new ArrayList();

                foreach (string key in stockSlipInfoDictionary.Keys)
                {
                    StockSlipWork stockSlipWork = stockSlipInfoDictionary[key];
                    stockSlipWorkAry.Add(stockSlipWork);
                }
                # endregion
                # endregion

                # region 抽出リモート処理の実行
                //抽出リモート処理の実行
                List<StockSlipWork> stockSlipWorkList = null;  //仕入ワークリスト
                List<StockDetailWork> stockDetailWorkList = null;  //仕入明細ワークリスト

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
                        //相手先伝票番号
                        string key = stockSlipWork.PartySaleSlipNum.Trim();
                        if (stockSlipWorkDictionary.ContainsKey(key) != true)
                        {
                            stockSlipWorkDictionary.Add(key, stockSlipWork);
                        }
                    }
                }

                # endregion
                # endregion

                //-----------------------------------------------------------
                // UOE発注データの読込（リモート処理実行）
                //-----------------------------------------------------------
                # region UOE発注データの読込（リモート処理実行）
                # region 条件抽出クラスの作成
                //注文時相手先伝票番号
                //注文時伝票番号Dictionary
                Dictionary<string, UOEStockUpdSearchWork> uOEStockUpdSearchDictionary = new Dictionary<string, UOEStockUpdSearchWork>();

                foreach (string key in orderDictionary.Keys)
                {
                    BuyOutLstDtl dtl = orderDictionary[key];

                    UOEStockUpdSearchWork uOEStockUpdSearchWork = new UOEStockUpdSearchWork();

                    uOEStockUpdSearchWork.EnterpriseCode = hed.EnterpriseCode;  //企業コード
                    uOEStockUpdSearchWork.SectionCode = hed.SectionCode;        //拠点コード
                    uOEStockUpdSearchWork.UOESupplierCd = hed.UOESupplierCd;
                    uOEStockUpdSearchWork.SlipNo = dtl.OrderSlipNo.Trim();      //相手先伝票番号

                    //格納処理
                    string slipNoKey = uOEStockUpdSearchWork.SlipNo;
                    if (uOEStockUpdSearchDictionary.ContainsKey(slipNoKey) != true)
                    {
                        uOEStockUpdSearchDictionary.Add(slipNoKey, uOEStockUpdSearchWork);
                    }
                }

                # region 条件抽出クラスの作成
                //条件抽出クラスの作成
                ArrayList paraAry = new ArrayList();

                foreach (string key in uOEStockUpdSearchDictionary.Keys)
                {
                    UOEStockUpdSearchWork uOEStockUpdSearchWork = uOEStockUpdSearchDictionary[key];
                    paraAry.Add(uOEStockUpdSearchWork);
                }
                # endregion

                # endregion
                
                # region 抽出リモート処理の実行
                //抽出リモート処理の実行
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;

                status = _uoeOrderInfoAcs.SearchAllPartySlip(
                            paraAry,
                            out uOEOrderDtlWorkList,
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

                # region UOE発注データDictionaryのキャッシュ処理
                //UOE発注データDictionaryのキャッシュ処理
                Dictionary<string, string> uOEOrderDtlSlipDictionary = new Dictionary<string, string>();

                if (uOEOrderDtlWorkList != null)
                {
                    foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
                    {
                        for(int i=0; i<4; i++)
                        {
                            //相手先伝票番号
                            string key = String.Empty;
                            switch (i)
                            {
                                case 0:
                                    key = uOEOrderDtlWork.UOESectionSlipNo.Trim();
                                    break;
                                case 1:
                                    key = uOEOrderDtlWork.BOSlipNo1.Trim();
                                    break;
                                case 2:
                                    key = uOEOrderDtlWork.BOSlipNo2.Trim();
                                    break;
                                case 3:
                                    key = uOEOrderDtlWork.BOSlipNo3.Trim();
                                    break;
                            }

                            // UOE発注データDictionaryの追加
                            if (key.Trim() == String.Empty) continue;
                            if (uOEOrderDtlSlipDictionary.ContainsKey(key) == true) continue;
                            uOEOrderDtlSlipDictionary.Add(key, key);
                        }
                    }
                }
                # endregion
                # endregion

                //-----------------------------------------------------------
                // データテーブルへの格納処理
                //-----------------------------------------------------------
                # region データテーブルへの格納処理
                # region 仕入明細→仕入明細テーブルの作成
                //仕入明細→仕入明細テーブルの作成
                if (stockDetailWorkList != null)
                {
                    foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                    {
                        stockDetailWork.DtlRelationGuid = Guid.NewGuid();

                        status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(StockDetailTable, stockDetailWork, "", 0, out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return (status);
                        }
                    }
                }
                # endregion

                # region 仕入→仕入テーブルの作成
                //仕入→仕入テーブルの作成
                if (stockSlipWorkList != null)
                {
                    foreach (StockSlipWork stockSlipWork in stockSlipWorkList)
                    {
                        status = _uoeSndRcvJnlAcs.InsertTableFromStockSlipWork(StockSlipTable, stockSlipWork, stockSlipWork.SupplierSlipNo.ToString("d9"), out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return (status);
                        }
                    }
                }

                # endregion
                # endregion

                //仕入情報の追加・更新用パラメータ定義
                List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

                foreach (string buyOutKey in buyOutDictionary.Keys)
                {
                    //-----------------------------------------------------------
                    // 初期処理
                    //-----------------------------------------------------------
                    # region 初期処理
                    BuyOutLstDtl dtl = buyOutDictionary[buyOutKey];
                    string orderKey = dtl.OrderSlipNo.Trim();
                    # endregion

                    //-----------------------------------------------------------
                    // 支払先コードにて仕入月次及び仕入締次の締日チェック
                    //-----------------------------------------------------------
                    # region 支払先コードにて仕入月次及び仕入締次の締日チェック
                    if ((supplier.PaymentSectionCode.Trim() != "") && (supplier.PayeeCode != 0))
                    {
                        //仕入締次の締日チェック
                        if (_totalDayCalculator.CheckPayment(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.BuyOutDate) != false)
                        {
                            DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                            SetUpdRslFromEpartsBuy(view, 4);    //4:締次更新処理済
                            continue;
                        }
                        //仕入月次の締日チェック
                        else if (_totalDayCalculator.CheckMonthlyAccPay(supplier.PaymentSectionCode, supplier.PayeeCode, dtl.BuyOutDate) != false)
                        {
                            DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                            SetUpdRslFromEpartsBuy(view, 5);    //5:月次更新処理済
                            continue;
                        }
                    }
                    # endregion
                        
                    //-----------------------------------------------------------
                    // ＵＯＥ未発注分＆拠点出荷分の仕入情報更新処理
                    //-----------------------------------------------------------
                    # region ＵＯＥ未発注分＆拠点出荷分の仕入情報更新処理
                    if (stockSlipWorkDictionary.ContainsKey(orderKey) == true)
                    {
                        List<StockSlipGrp> list = EpartsUoeWebBuyUpdate(
                                    hed,
                                    dtl.OrderSlipNo,     //相手先伝票番号
                                    supplier);

                        if (list == null) continue;
                        if (list.Count == 0) continue;
                        foreach (StockSlipGrp stockSlipGrp in list)
                        {
                            stockSlipGrpList.Add(stockSlipGrp);
                        }

                    }
                    # endregion

                    //-----------------------------------------------------------
                    // ＢＯ出荷分の仕入情報更新処理
                    //-----------------------------------------------------------
                    # region ＢＯ出荷分の仕入情報更新処理
                    else if (stockSlipWorkDictionary.ContainsKey(orderKey + "-F") == true)
                    {
                        List<StockSlipGrp> list = EpartsUoeWebBuyUpdate(
                                    hed,
                                    dtl.OrderSlipNo + "-F",     //相手先伝票番号
                                    supplier);

                        if (list == null) continue;
                        if (list.Count == 0) continue;
                        foreach (StockSlipGrp stockSlipGrp in list)
                        {
                            stockSlipGrpList.Add(stockSlipGrp);
                        }
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 引当済の判定（ＡＢＯＲＴ）
                    //-----------------------------------------------------------
                    # region 引当済の判定（ＡＢＯＲＴ）
                    else if (stockSlipWorkDictionary.ContainsKey(buyOutKey) == true)
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                        SetUpdRslFromEpartsBuy(view, 9);    //9:引当済
                    }
                    else if (stockSlipWorkDictionary.ContainsKey(buyOutKey + "-F") == true)
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo + "-F");
                        SetUpdRslFromEpartsBuy(view, 9);    //9:引当済
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入情報の新規作成
                    //-----------------------------------------------------------
                    # region 仕入情報の新規作成
                    else if (hed.StcCreDiv == 1)
                    {
                        if (uOEOrderDtlSlipDictionary.ContainsKey(orderKey) == true)    continue;

                        StockSlipGrp stockSlipGrp = EpartsUoeWebBuyInsert(
                                    hed,
                                    dtl,                    // 買上一覧明細オブジェクト
                                    subSectionCode,         // 部門コード
                                    supplier,               // 仕入先オブジェクト
                                    uOESupplier);           // UOE発注先オブジェクト

                        if (stockSlipGrp == null) continue;
                        stockSlipGrpList.Add(stockSlipGrp);
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 該当なしの判定（ＡＢＯＲＴ）
                    //-----------------------------------------------------------
                    # region 該当なしの判定（ＡＢＯＲＴ）
                    else
                    {
                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(1, dtl.OrderSlipNo);
                        SetUpdRslFromEpartsBuy(view, 2);    //2:該当なし
                    }
                    # endregion
                }

                //-----------------------------------------------------------
                // 仕入情報の更新処理（リモート処理実行）
                //-----------------------------------------------------------
                # region 仕入情報の更新処理（リモート処理実行）
                if ((stockSlipGrpList == null) || (stockSlipGrpList.Count == 0))
                {
                    hed.UpdRsl = 0;
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
                }
                # endregion

                //-----------------------------------------------------------
                // 戻り値の設定
                //-----------------------------------------------------------
                # region 戻り値の設定
                // 買上一覧明細部＜更新結果＞の設定
                DataView viewUpdRsl = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0);
                SetUpdRslFromEpartsBuy(viewUpdRsl, 2);    //2:該当なし

                ArrayList dtlList = GetBuyOutDtlListForDataTable();

                //戻り値の設定
                if (dtlList == null)
                {
                    hed.UpdRsl = -1;//-1:エラー
                }
                else
                {
                    hed.LstDtl = dtlList;
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

        # region ▽ 買上一覧明細データ(ArrayList)取得
        /// <summary>
        /// ▽ 買上一覧明細データ(ArrayList)取得
        /// </summary>
        /// <returns>買上一覧明細データ</returns>
        private ArrayList GetBuyOutDtlListForDataTable()
        {
            ArrayList list = new ArrayList();

            try
            {
                DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView();

                foreach (DataRowView dataRowView in view)
                {
                    BuyOutLstDtl dtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(dataRowView.Row);
                    list.Add(dtl);
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return (list);
        }
        # endregion

        # region ▽ 買上一覧Viewの更新結果を設定
        /// <summary>
        /// ▽ 買上一覧Viewの更新結果を設定
        /// </summary>
        /// <param name="dv">買上一覧View</param>
        /// <param name="updRsl">更新結果</param>
        /// <returns>ステータス</returns>
        private int SetUpdRslFromEpartsBuy(DataView view, Int32 updRsl)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;

            try
            {
                if (view.Count == 0) return (status);

                foreach (DataRowView dataRowView in view)
                {
                    dataRowView[BuyOutLstDtlSchema.ct_Col_UpdRsl] = updRsl;
                }
            }
            catch (Exception)
            {
                status = -1;
            }
            return (status);
        }
        # endregion

        # region ▽ ＜新規用＞ホンダＵＯＥ ＷＥＢ e-Parts 引当新規作成
        /// <summary>
        /// ▽ ホンダＵＯＥ ＷＥＢ e-Parts 引当新規作成
        /// </summary>
        /// <param name="hed">買上一覧データオブジェクト</param>
        /// <param name="dtl">買上一覧明細オブジェクト</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        private StockSlipGrp EpartsUoeWebBuyInsert(BuyOutLsthead hed, BuyOutLstDtl dtl, Int32 subSectionCode, Supplier supplier, UOESupplier uOESupplier)
        {
            //変数の初期化
            StockSlipGrp stockSlipGrp = null;

            try
            {
                //-----------------------------------------------------------
                // 更新対象の買上一覧クラスの抽出
                //-----------------------------------------------------------
                # region 更新対象の買上一覧クラスの抽出
                DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(0, dtl.BuyOutSlipNo);
                if (view.Count == 0) return (stockSlipGrp);

                List<BuyOutLstDtl> buyDtlList = new List<BuyOutLstDtl>();
                foreach (DataRowView dataRowView in view)
                {
                    BuyOutLstDtl buyDtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(dataRowView.Row);
                    buyDtlList.Add(buyDtl);

                    // 買上一覧明細データテーブル「更新結果・注文時単価」を設定
                    dataRowView[BuyOutLstDtlSchema.ct_Col_OrderCost] = buyDtl.BuyOutCost;
                    dataRowView[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 6;  //6:仕入データ作成
                }
                # endregion

                //-----------------------------------------------------------
                // 仕入明細データの取得（買上一覧）
                //-----------------------------------------------------------
                # region 仕入明細データの取得（買上一覧）
                List<StockDetailWork> stockDetailWorkList = GetStockDetailFromEpartsBuyInsert(
                                                                hed,
                                                                subSectionCode, //部門コード
                                                                buyDtlList,     //買上一覧データクラス
                                                                supplier,       //仕入情報オブジェクト
                                                                uOESupplier);   //UOE発注情報オブジェクト
                if (stockDetailWorkList == null) return (stockSlipGrp);
                if (stockDetailWorkList.Count == 0) return (stockSlipGrp);
                # endregion

                //-----------------------------------------------------------
                // 仕入データの取得
                //-----------------------------------------------------------
                #region 仕入データの取得
                StockSlipWork stockSlipWork = GetstockSlipFromEpartsBuyInsert(
                                                                hed.EnterpriseCode, //企業コード
                                                                hed.SectionCode,    //拠点コード
                                                                subSectionCode,     //部門コード
                                                                buyDtlList,         //買上一覧データクラス
                                                                stockDetailWorkList,//仕入明細オブジェクト
                                                                supplier);          //仕入情報オブジェクト
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
            catch (Exception ex)
            {
                string message = ex.Message;
                stockSlipGrp = null;
            }

            return (stockSlipGrp);
        }
        # endregion

        # region ▽ ＜新規用＞仕入データの取得（買上一覧）
        /// <summary>
        /// 仕入データの取得（買上一覧）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="list">注文一覧明細(手入力)データクラス</param>
        /// <param name="list">仕入明細オブジェクト</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        private StockSlipWork GetstockSlipFromEpartsBuyInsert(string enterpriseCode, string sectionCode, Int32 subSectionCode, List<BuyOutLstDtl> list, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //変数の初期化
            StockSlipWork stockSlipWork = null;
            try
            {
                //-----------------------------------------------------------
                // 買上一覧明細の取得
                //-----------------------------------------------------------
                BuyOutLstDtl buyOutLstDtl = list[0];

                //-----------------------------------------------------------
                // 仕入データの設定
                //-----------------------------------------------------------
                stockSlipWork = GetStockSlipFromEpartsInsert(
                                    enterpriseCode,             //企業コード
                                    sectionCode,                //拠点コード
                                    subSectionCode,             //部門コード
                                    buyOutLstDtl.BuyOutDate,    //仕入日付
                                    buyOutLstDtl.BuyOutSlipNo,  //相手先伝票番号
                                    stockDetailWorkList,        //仕入明細オブジェクト
                                    supplier);                  //仕入情報オブジェクト
            }
            catch (Exception)
            {
                stockSlipWork = null;
            }
            return (stockSlipWork);
        }
        # endregion

        # region ▽ ＜新規用＞仕入明細データの取得（買上一覧）
        /// <summary>
        /// 仕入明細データの取得（買上一覧）
        /// </summary>
        /// <param name="hed">買上一覧データオブジェクト</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="list">買上一覧データクラス</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <returns>仕入明細オブジェクト</returns>
        private List<StockDetailWork> GetStockDetailFromEpartsBuyInsert(BuyOutLsthead hed, Int32 subSectionCode, List<BuyOutLstDtl> list, Supplier supplier, UOESupplier uOESupplier)
        {
            //変数の初期化
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
            try
            {
                int stockRowNo = 1; //仕入行番号

                foreach (BuyOutLstDtl dtl in list)
                {
                    StockDetailWork stockDetailWork = GetStockDetailWorkFromEpartsInsert(
                                                            hed.EnterpriseCode,     //企業コード
                                                            hed.SectionCode,        //拠点コード
                                                            subSectionCode,         //部門コード
                                                            stockRowNo,             //仕入行番号
                                                            dtl.GoodsNo,            //品番
                                                            dtl.GoodsName,          //品名
                                                            dtl.ShipmentCnt,        //数量
                                                            dtl.AnswerListPrice,    //定価
                                                            dtl.BuyOutCost,         //単価
                                                            hed.StockAgentCode,     //担当者コード
                                                            hed.StockAgentName,     //担当者名
                                                            supplier,               //仕入情報オブジェクト
                                                            uOESupplier);           //UOE発注情報オブジェクト
                    if (stockDetailWork == null)
                    {
                        stockDetailWorkList = null;
                        break;
                    }

                    stockDetailWorkList.Add(stockDetailWork);
                    stockRowNo++;
                }
            }
            catch (Exception)
            {
                stockDetailWorkList = null;
            }
            return (stockDetailWorkList);
        }
        # endregion

        # region ▽ ＜更新用＞ホンダＵＯＥ ＷＥＢ e-Parts 引当更新処理
        /// <summary>
        /// ▽ ＜更新用＞ホンダＵＯＥ ＷＥＢ e-Parts 引当更新処理
        /// </summary>
        /// <param name="hed">買上一覧データオブジェクト</param>
        /// <param name="orderSlipNo">注文時伝票番号</param>
        /// <param name="supplier">仕入情報オブジェクト</param>
        /// <returns></returns>
        private List<StockSlipGrp> EpartsUoeWebBuyUpdate(BuyOutLsthead hed, string orderSlipNo, Supplier supplier)
        {
            //変数の初期化
            List<StockSlipGrp> stockSlipGrpList = new List<StockSlipGrp>();

            try
            {
                //-----------------------------------------------------------
                // 仕入伝票番号の算出
                //-----------------------------------------------------------
                # region 仕入伝票番号の算出
                DataView viewStockSlip = new DataView(this.StockSlipTable);

                // フィルタ設定
                string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                StockSlipSchema.ct_Col_SupplierFormal, 0,
                                                StockSlipSchema.ct_Col_PartySaleSlipNum, orderSlipNo
                                                );
                // ソート順設定
                string sortText = string.Format("{0}",
                                                StockSlipSchema.ct_Col_SupplierSlipNo
                                                );
                viewStockSlip.RowFilter = rowFilterText;
                viewStockSlip.Sort = sortText;

                if (viewStockSlip == null) return (stockSlipGrpList);
                if (viewStockSlip.Count == 0) return (stockSlipGrpList);
                # endregion

                foreach (DataRowView dataRowViewStockSlip in viewStockSlip)
                {
                    //仕入データの取得
                    StockSlipWork stockSlipWork = _uoeSndRcvJnlAcs.CreateStockSlipWorkFromSchema(dataRowViewStockSlip.Row);

                    //-----------------------------------------------------------
                    // 仕入明細データの取得
                    //-----------------------------------------------------------
                    # region 仕入明細データの取得
                    # region 仕入明細の取得＜仕入伝票番号・品番・数量＞
                    //仕入明細の取得＜仕入伝票番号＞
                    DataView viewStockDetail = new DataView(this.StockDetailTable);

                    // フィルタ設定
                    string viewStockDetailRowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                    StockDetailSchema.ct_Col_SupplierFormal, 0,
                                                    StockDetailSchema.ct_Col_SupplierSlipNo, stockSlipWork.SupplierSlipNo
                                                    );
                    // ソート順設定
                    string viewStockDetailSortText = string.Format("{0}",
                                                    StockDetailSchema.ct_Col_StockRowNo
                                                    );
                    viewStockDetail.RowFilter = viewStockDetailRowFilterText;
                    viewStockDetail.Sort = viewStockDetailSortText;

                    if (viewStockDetail.Count == 0)
                    {
                        return (stockSlipGrpList);

                    }
                    # endregion

                    // 仕入明細データリストの定義
                    List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                    
                    // 買上明細クラス
                    BuyOutLstDtl buyDtl = null;

                    foreach(DataRowView dataRowViewStockDetail in viewStockDetail)
                    {
                        # region お買上一覧クラスの抽出＜注文時日付・注文時伝票番号・品番・数量・更新結果＞
                        // お買上一覧クラスの抽出＜注文時日付・注文時伝票番号・品番・数量・更新結果＞
                        string goodsNo = (string)dataRowViewStockDetail[StockDetailSchema.ct_Col_GoodsNo];
                        double shipmentCnt = (double)dataRowViewStockDetail[StockDetailSchema.ct_Col_OrderCnt];
                        double orderCost = (double)dataRowViewStockDetail[StockDetailSchema.ct_Col_StockUnitPriceFl];

                        DataView view = _uoeSndRcvJnlAcs.GetBuyOutLstDtlFormCreateView(
                                                    orderSlipNo,
                                                    goodsNo,
                                                    shipmentCnt,
                                                    0);
                        
                        if(view.Count == 0) continue;
                        buyDtl = _uoeSndRcvJnlAcs.CreateBuyOutLstDtlFromSchema(view[0].Row);
                        # endregion

                        # region 仕入明細の算出
                        // (算出用)仕入明細の定義
                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(dataRowViewStockDetail.Row);

                        // 注文時単価の設定
                        view[0].Row[BuyOutLstDtlSchema.ct_Col_OrderCost] = orderCost;

                        // 単価更新あり
                        if ((hed.CostUpdtDiv == 1) && (buyDtl.BuyOutCost != orderCost))
                        {
                            view[0].Row[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 7;  //単価変更
                        }
                        // 単価更新なし
                        else
                        {
                            view[0].Row[BuyOutLstDtlSchema.ct_Col_UpdRsl] = 1;  //引当正常
                        }
                        
                        //仕入明細データの再計算
                        GetStockDetailWorkFromEpartsUpdate(hed, ref stockDetailWork, buyDtl, supplier);

                        // 算出した仕入明細データを格納
                        stockDetailWorkList.Add(stockDetailWork);
                        # endregion
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入データの算出
                    //-----------------------------------------------------------
                    #region 仕入データの取得
                    GetStockSlipFromEpartsUpdate(
                            ref stockSlipWork,
                            buyDtl.BuyOutDate,
                            buyDtl.BuyOutSlipNo,
                            stockDetailWorkList,
                            supplier);
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入情報オブジェクトの取得
                    //-----------------------------------------------------------
                    # region 仕入情報オブジェクトの作成
                    StockSlipGrp stockSlipGrp = new StockSlipGrp();
                    stockSlipGrp.stockSlipWork = stockSlipWork;
                    stockSlipGrp.stockDetailWorkList = stockDetailWorkList;

                    stockSlipGrpList.Add(stockSlipGrp);
                    # endregion
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                stockSlipGrpList = null;
            }
            return (stockSlipGrpList);
        }
        # endregion

        #region ▽ ＜更新用＞仕入明細データの取得（買上一覧）
        /// <summary>
        /// ▽ ＜更新用＞仕入明細データの取得
        /// </summary>
        /// <param name="hed">買上一覧データオブジェクト</param>
        /// <param name="stockDetailWork">仕入明細オブジェクト</param>
        /// <param name="buyDtl">買上一覧明細オブジェクト</param>
        /// <returns>ステータス</returns>
        private int GetStockDetailWorkFromEpartsUpdate(BuyOutLsthead hed, ref StockDetailWork stockDetailWork, BuyOutLstDtl buyDtl, Supplier supplier)
        {   
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = "";

            try
            {
                //仕入担当者コード
                stockDetailWork.StockAgentCode = hed.StockAgentCode;

                //仕入担当者名称
                stockDetailWork.StockAgentName = hed.StockAgentName;

                // 単価更新あり
                if (hed.CostUpdtDiv == 1)
                {
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
                    // 変更前仕入単価（浮動）
                    //-----------------------------------------------------------
                    #region 変更前仕入単価（浮動）
                    stockDetailWork.BfStockUnitPriceFl = stockDetailWork.StockUnitPriceFl;
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入単価変更区分
                    //-----------------------------------------------------------
                    #region 仕入単価変更区分
                    //仕入単価変更区分
                    //変更前原価と回答原価が異なる

                    double srcCost = stockDetailWork.BfStockUnitPriceFl;
                    double dstCost = buyDtl.BuyOutCost;

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
                    stockDetailWork.StockUnitPriceFl = dstCost;

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
                        double cnt = stockDetailWork.OrderCnt;

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
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ▽ ＜更新用＞仕入データの取得（買上一覧）
        /// <summary>
        /// ▽ ＜更新用＞仕入データの取得（買上一覧）
        /// </summary>
        /// <param name="stockDate">仕入日</param>
        /// <param name="partySaleSlipNum">相手先伝票番号</param>
        /// <param name="list">仕入明細オブジェクト</param>
        /// <param name="supplier">仕入先オブジェクト</param>
        /// <returns>仕入情報オブジェクト</returns>
        /// <br>Update Note: 2013/01/31 鄭慕鈞</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
        /// <br>           : redmine#33991 伝票番号引当処理 仕入データの仕入先コードの設定不正の対応</br>
        private int GetStockSlipFromEpartsUpdate(ref StockSlipWork rst, DateTime stockDate, string partySaleSlipNum, List<StockDetailWork> stockDetailWorkList, Supplier supplier)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = "";

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
                rst.StockAddUpSectionCd = supplier.PaymentSectionCode;                      // 仕入計上拠点コード
                rst.StockDate = stockDate;	                                                // 仕入日
                rst.PayeeCode = supplier.PayeeCode;                                         // 支払先コード

                Supplier payee = _uoeSndRcvCtlInitAcs.GetSupplier(supplier.PayeeCode);      // 支払先略称
                rst.PayeeSnm = payee.SupplierSnm;	                                        // 

                //rst.SupplierCd = stockDetailWork.SupplierCd;	                            // 仕入先コード  DEL 2013/01/31 鄭慕鈞　Redmine#33991 
                // -----ADD 鄭慕鈞　Redmine#33991 2013/01/31------ >>>>>
                if (stockDetailWork.SupplierCd == 0)
                {
                    rst.SupplierCd = supplier.SupplierCd;	                                // 仕入先コード
                }
                else
                {
                    rst.SupplierCd = stockDetailWork.SupplierCd;	                        // 仕入先コード
                }
                // -----ADD 鄭慕鈞　Redmine#33991 2013/01/31------ <<<<<
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

                rst.SuppCTaxLayCd = supplier.SuppCTaxLayCd;	                                // 仕入先消費税転嫁方式コード
                rst.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);	// 仕入先消費税税率

                // 仕入データの情報算出
                //仕入端数処理区分
                //1:切捨て,2:四捨五入,3:切上げ　（消費税）
                //端数処理単位
                StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                            1,
                                                            supplier.StockCnsTaxFrcProcCd,
                                                            999999999);
                rst.StockFractionProcCd = stockProcMoney.FractionProcCd;                    //仕入端数処理区分

                rst.PartySaleSlipNum = partySaleSlipNum;	                                // 相手先伝票番号

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
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion
        # endregion

        # endregion
    }
}
