//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌別出荷実績表
// プログラム概要   : 車輌別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/10/13  修正内容 : 粗利率 =（粗利 ÷ 売上金額）*100を変更する
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Collections.Specialized;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車輌別出荷実績表 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 車輌別出荷実績表で使用するデータを取得する。</br>
    /// <br>Programmer	: 張莉莉</br>
    /// <br>Date		: 2009.09.15</br>
    /// <br>UpdateNote	: 張莉莉 2009.10.13</br>
    /// <br>    		: 粗利率 =（粗利 ÷ 売上金額）*100を変更する</br>
    /// </remarks>
    public class CarShipRsltAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 車輌別出荷実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌別出荷実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public CarShipRsltAcs()
        {
            this._iCarShipResultDB = (ICarShipResultDB)MediationCarShipResultDB.GetCarShipWorkDB();
        }

        /// <summary>
        /// 車輌別出荷実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車輌別出荷実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        static CarShipRsltAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // 帳票出力設定アクセスクラス

        #endregion ■ Static Member

        #region ■ Private Member
        ICarShipResultDB _iCarShipResultDB;

        private DataSet _carShipListDs;	    		// 印刷DataTable
        private bool lineFlg = false;
        // ページが変わった場合
        private bool newPage = false;
        // 計ランページが変わった場合
        private bool diffPage = false;
        // detailデータページが変わった場合
        private bool detailPage = false;
        // BLGroup計の場合ページが変わった場合
        private bool BLGroupPage = false;
        // Car計の場合ページが変わった場合
        private bool carPage = false;
        private bool carGroupPage = false;
        #endregion ■ Private Member

        #region ■ Pricate Const
        const string ct_Extr_Top = "最初から";
        const string ct_Extr_End = "最後まで";
        const string ct_Space = "　";
        #endregion ■ Pricate Const

        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataSet CarShipListDs
        {
            get { return this._carShipListDs; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 入金データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="carShip">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public int SearchCarShipProcMain(CarShipRsltListCndtn carShip, out string errMsg)
        {
            return this.SearchCarShipProc(carShip, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// 仕入データ取得
        /// </summary>
        /// <param name="carShipCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入データを取得する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int SearchCarShipProc(CarShipRsltListCndtn carShipCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSYA02005EA.CreateDataTable(ref this._carShipListDs);

                // 抽出条件展開  --------------------------------------------------------------
                CarShipRsltCndtnWork carShipRsltCndtnWork = new CarShipRsltCndtnWork();
                status = this.DevCarShip(carShipCndtn, out carShipRsltCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object carShipResultWork = null;
                status = this._iCarShipResultDB.Search(out carShipResultWork, (object)carShipRsltCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList carShipResultList = carShipResultWork as ArrayList;
                        // データ集計処理
                        if ((int)carShipCndtn.GroupBySectionDiv == 0)
                        {
                            CarDataGroup(carShipCndtn, ref carShipResultList);
                        }

                        // lineFlgの取得処理（抽出条件編集処理）
                        StringCollection extraInfomations;

                        this.MakeExtarCondition(out extraInfomations,carShipCndtn);


                        // データ展開処理
                        DevCarShipMainData(carShipCndtn, this._carShipListDs.Tables[PMSYA02005EA.Tbl_CarShipListData], carShipResultList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;                      
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "車輌別出荷実績表の帳票出力データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="carShipCndtn">UI抽出条件クラス</param>
        /// <param name="carShipRsltCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevCarShip(CarShipRsltListCndtn carShipCndtn, out CarShipRsltCndtnWork carShipRsltCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            carShipRsltCndtnWork = new CarShipRsltCndtnWork();
            try
            {
                // 企業コード 
                carShipRsltCndtnWork.EnterpriseCode = carShipCndtn.EnterpriseCode;
                // 拠点コードリスト
                carShipRsltCndtnWork.SectionCodeList = carShipCndtn.SectionCodeList;
                // 集計方法
                carShipRsltCndtnWork.GroupBySectionDiv = (int)carShipCndtn.GroupBySectionDiv;
                // 売上日(開始)
                carShipRsltCndtnWork.SalesDateSt = carShipCndtn.SalesDateSt;
                // 売上日(終了)
                carShipRsltCndtnWork.SalesDateEd = carShipCndtn.SalesDateEd;
                // 入力日(開始)
                carShipRsltCndtnWork.InputDateSt = carShipCndtn.InputDateSt;
                // 入力日(終了)
                carShipRsltCndtnWork.InputDateEd = carShipCndtn.InputDateEd;
                // 在庫取寄せ区分
                carShipRsltCndtnWork.RsltTtlDiv = (int)carShipCndtn.RsltTtlDiv;
                // 品番出力
                carShipRsltCndtnWork.GoodsNoPrint = (int)carShipCndtn.GoodsNoPrint;
                // 原価・粗利出力
                carShipRsltCndtnWork.CostGrossPrint = (int)carShipCndtn.CostGrossPrint;
                // 改頁
                carShipRsltCndtnWork.NewPageDiv = (int)carShipCndtn.NewPageDiv;
                // 明細単位
                carShipRsltCndtnWork.DetailDataValue = (int)carShipCndtn.DetailDataValue;
                // 開始得意先コード
                carShipRsltCndtnWork.CustomerCodeSt = carShipCndtn.CustomerCodeSt;
                // 終了得意先コード
                carShipRsltCndtnWork.CustomerCodeEd = carShipCndtn.CustomerCodeEd;
                // 開始管理番号コード
                carShipRsltCndtnWork.CarMngCodeSt = carShipCndtn.CarMngCodeSt;
                // 終了管理番号コード
                carShipRsltCndtnWork.CarMngCodeEd = carShipCndtn.CarMngCodeEd;
                // 開始BLグループコード
                carShipRsltCndtnWork.BLGroupCodeSt = carShipCndtn.BLGroupCodeSt;
                // 終了BLグループコード
                carShipRsltCndtnWork.BLGroupCodeEd = carShipCndtn.BLGroupCodeEd;
                // 開始BL商品コード
                carShipRsltCndtnWork.BLGoodsCodeSt = carShipCndtn.BLGoodsCodeSt;
                // 終了BL商品コード
                carShipRsltCndtnWork.BLGoodsCodeEd = carShipCndtn.BLGoodsCodeEd;
                // 開始品番
                carShipRsltCndtnWork.GoodsNoSt = carShipCndtn.GoodsNoSt;
                // 終了品番
                carShipRsltCndtnWork.GoodsNoEd = carShipCndtn.GoodsNoEd;
                // 車輌備考
                carShipRsltCndtnWork.SlipNoteCar = carShipCndtn.SlipNoteCar;
                // 車輌抽出区分
                carShipRsltCndtnWork.CarOutDiv = (int)carShipCndtn.CarOutDiv;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        #endregion ◎ 抽出条件展開処理

        #region ◆ データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="carShipCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void CarDataGroup(CarShipRsltListCndtn carShipCndtn, ref ArrayList resultWork)
        {
            Hashtable carDataTable = new Hashtable();
            string checkKey = string.Empty;

            foreach (CarShipResultWork carShipResultWork in resultWork)
            {
                // 集計方法は「実績表」、明細単位は「品番」
                // 集計時のＫＥＹ項目
                // 実績計上拠点コード・得意先コード・車輌管理コード・車両管理番号・グループコード・BLコード・商品番号・商品メーカーコード
                if ((int)carShipCndtn.DetailDataValue == 0)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                         "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                         "_" + carShipResultWork.CarMngCode +
                                         "_" + carShipResultWork.CarMngNo +
                                         "_" + carShipResultWork.BLGroupCode.ToString("00000") +
                                         "_" + carShipResultWork.BLGoodsCode.ToString("00000") +
                                         "_" + carShipResultWork.GoodsNo +
                                         "_" + carShipResultWork.GoodsMakerCd.ToString("0000");

                }

                // 集計方法は「実績表」、明細単位は「ＢＬコード」
                // 集計時のＫＥＹ項目
                // 実績計上拠点コード・得意先コード・車輌管理コード・車両管理番号・グループコード・BLコード
                if ((int)carShipCndtn.DetailDataValue == 1)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                        "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                        "_" + carShipResultWork.CarMngCode +
                                        "_" + carShipResultWork.CarMngNo +
                                        "_" + carShipResultWork.BLGroupCode.ToString("00000") +
                                        "_" + carShipResultWork.BLGoodsCode.ToString("00000");
                }
                // 集計方法は「実績表」、明細単位は「グループコード」
                // 集計時のＫＥＹ項目
                // 実績計上拠点コード・得意先コード・車輌管理コード・車両管理番号・グループコード
                if ((int)carShipCndtn.DetailDataValue == 2)
                {
                    checkKey = carShipResultWork.ResultsAddUpSecCd +
                                        "_" + carShipResultWork.CustomerCode.ToString("00000000") +
                                        "_" + carShipResultWork.CarMngCode +
                                        "_" + carShipResultWork.CarMngNo +
                                        "_" + carShipResultWork.BLGroupCode.ToString("00000");
                }

                if (carDataTable.Contains(checkKey))
                {
                    CarShipResultWork carShipResultWorkInTable = (CarShipResultWork)carDataTable[checkKey];
                    // 出荷数
                    carShipResultWork.ShipmentCnt += carShipResultWorkInTable.ShipmentCnt;
                    // 出荷数(在庫)
                    carShipResultWork.ShipmentCntIn += carShipResultWorkInTable.ShipmentCntIn;
                    // 出荷数(取寄)
                    carShipResultWork.ShipmentCntNotIn += carShipResultWorkInTable.ShipmentCntNotIn;
                    // 売上金額（税抜き）
                    carShipResultWork.SalesMoneyTaxExc += carShipResultWorkInTable.SalesMoneyTaxExc;
                    // 粗利金額
                    carShipResultWork.GrossProfit += carShipResultWorkInTable.GrossProfit;

                    carDataTable.Remove(checkKey);
                    carDataTable.Add(checkKey, carShipResultWork);

                }
                else
                {
                    carDataTable.Add(checkKey, carShipResultWork);
                }
            }
            List<string> sortKey = new List<string>();
            foreach (string key in carDataTable.Keys)
            {
                sortKey.Add(key);
            }
            sortKey.Sort();
            string keyDet = string.Empty;
            resultWork.Clear();
            for (int i = 0; i < sortKey.Count;i++ )
            {
                keyDet = sortKey[i];

                if (carDataTable.Contains(keyDet))
                {
                    resultWork.Add(carDataTable[keyDet]);
                }
            }
            //resultWork = new ArrayList(carDataTable.Values);
        }


        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得
        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得

        /// <summary>
        /// 帳票設定データ取得処理
        /// </summary>
        /// <param name="carShipRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="carShipRsltDt">carShipRsltDt</param>
        /// <param name="carShipRsltWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void DevCarShipMainData(CarShipRsltListCndtn carShipRsltListCndtn, DataTable carShipRsltDt, ArrayList carShipRsltWork)
        {
            DataRow dr;
            CarShipResultWork disCarShipResultWork = null;
            CarShipResultWork nextDisCarShipResultWork = null;
            CarShipResultWork lastDisCarShipResultWork = null;
            int count = carShipRsltWork.Count;
            int k = 0;
            for (int i = 0; i < count; i++)
            {
                disCarShipResultWork = (CarShipResultWork)carShipRsltWork[i];
                if (i + 1 < count)
                {
                    nextDisCarShipResultWork = (CarShipResultWork)carShipRsltWork[i + 1];
                }
                dr = carShipRsltDt.NewRow();
                //売上伝票番号
                dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = disCarShipResultWork.SalesSlipNum;
                //実績計上拠点コード
                dr[PMSYA02005EA.ct_Col_ResultsAddUpSecCdRF] = disCarShipResultWork.ResultsAddUpSecCd;
                //売上日付
                dr[PMSYA02005EA.ct_Col_SalesDateRF] = disCarShipResultWork.SalesDate;
                //得意先コード
                dr[PMSYA02005EA.ct_Col_CustomerCodeRF] = disCarShipResultWork.CustomerCode;
                //得意先略称
                if (string.IsNullOrEmpty(disCarShipResultWork.CustomerSnm))
                {
                    dr[PMSYA02005EA.ct_Col_CustomerSnmRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_CustomerSnmRF] = disCarShipResultWork.CustomerSnm;
                }
               
                //売上行番号
                dr[PMSYA02005EA.ct_Col_SalesRowNoRF] = disCarShipResultWork.SalesRowNo;
                //商品メーカーコード
                dr[PMSYA02005EA.ct_Col_GoodsMakerCdRF] = disCarShipResultWork.GoodsMakerCd;
                //商品番号
                dr[PMSYA02005EA.ct_Col_GoodsNoRF] = disCarShipResultWork.GoodsNo;
                //商品名称カナ
                dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = disCarShipResultWork.GoodsNameKana;
                //BL商品コード
                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;
                //BL商品コードCopy
                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRFCopy] = disCarShipResultWork.BLGoodsCode;
                //BL商品コード名称（半角）
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGoodsHalfName))
                {
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;
                }
                //BLグループコード
                dr[PMSYA02005EA.ct_Col_BLGroupCodeRF] = disCarShipResultWork.BLGroupCode;
                //BLグループコードCopy
                dr[PMSYA02005EA.ct_Col_BLGroupCodeRFCopy] = disCarShipResultWork.BLGroupCode;
                //BLグループコードカナ名称
                if (string.IsNullOrEmpty(disCarShipResultWork.BLGroupKanaName))
                {
                    dr[PMSYA02005EA.ct_Col_BLGroupKanaNameRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_BLGroupKanaNameRF] = disCarShipResultWork.BLGroupKanaName;
                }
                //定価（税抜，浮動）
                dr[PMSYA02005EA.ct_Col_ListPriceTaxExcFlRF] = disCarShipResultWork.ListPriceTaxExcFl;
                //売上単価（税抜，浮動）
                dr[PMSYA02005EA.ct_Col_SalesUnPrcTaxExcFlRF] = disCarShipResultWork.SalesUnPrcTaxExcFl;
                //原価単価
                dr[PMSYA02005EA.ct_Col_SalesUnitCostRF] = disCarShipResultWork.SalesUnitCost;
                //出荷数
                dr[PMSYA02005EA.ct_Col_ShipmentCntRF] = disCarShipResultWork.ShipmentCnt;
                //出荷数(在庫)
                dr[PMSYA02005EA.ct_Col_ShipmentCntInRF] = disCarShipResultWork.ShipmentCntIn;
                //出荷数(取寄)
                dr[PMSYA02005EA.ct_Col_ShipmentCntNotInRF] = disCarShipResultWork.ShipmentCntNotIn;
                // 売上在庫取寄せ区分
                // 売上在庫取寄せ区分＝1(在庫)は空白、＝0(取寄)は"*"をセット
                if (disCarShipResultWork.SalesOrderDivCd == 1)
                {
                    dr[PMSYA02005EA.ct_Col_SalesOrderDivCdRF] = "";
                }
                else if (disCarShipResultWork.SalesOrderDivCd == 0)
                {
                    dr[PMSYA02005EA.ct_Col_SalesOrderDivCdRF] = "*";
                }
                //売上金額（税抜き）
                dr[PMSYA02005EA.ct_Col_SalesMoneyTaxExcRF] = disCarShipResultWork.SalesMoneyTaxExc;
                //拠点ガイド略称
                if(string.IsNullOrEmpty(disCarShipResultWork.SectionGuideSnm))
                {
                    dr[PMSYA02005EA.ct_Col_SectionGuideSnmRF] = "未登録";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_SectionGuideSnmRF] = disCarShipResultWork.SectionGuideSnm;
                }
                
                //粗利金額
                dr[PMSYA02005EA.ct_Col_GrossProfitRF] = disCarShipResultWork.GrossProfit;
                //粗利率
                // 端数処理
                double grosspiv = 0;
                if (disCarShipResultWork.SalesMoneyTaxExc != 0)
                {
                    // --- UPD 2009/10/13 ------>>>>>
                    // 粗利率　（粗利 ÷ 売上金額）*100　
                    // grosspiv = ((double)disCarShipResultWork.GrossProfit)/((double)disCarShipResultWork.SalesMoneyTaxExc);
                    grosspiv = (((double)disCarShipResultWork.GrossProfit)/((double)disCarShipResultWork.SalesMoneyTaxExc))*100;
                    // --- UPD 2009/10/13 ------<<<<<
                }
                dr[PMSYA02005EA.ct_Col_GrossPivRF] = grosspiv.ToString("f2");
                //車両管理番号
                dr[PMSYA02005EA.ct_Col_CarMngNoRF] = disCarShipResultWork.CarMngCode + disCarShipResultWork.CarMngNo.ToString();
                //車輌管理コード
                dr[PMSYA02005EA.ct_Col_CarMngCodeRF] = disCarShipResultWork.CarMngCode;
                //陸運事務局名称
                dr[PMSYA02005EA.ct_Col_NumberPlate1NameRF] = disCarShipResultWork.NumberPlate1Name;
                //車両登録番号（種別）
                dr[PMSYA02005EA.ct_Col_NumberPlate2RF] = disCarShipResultWork.NumberPlate2;
                //車両登録番号（カナ）
                dr[PMSYA02005EA.ct_Col_NumberPlate3RF] = disCarShipResultWork.NumberPlate3;
                //車両登録番号（プレート番号）
                if (disCarShipResultWork.NumberPlate4 != 0)
                {
                    dr[PMSYA02005EA.ct_Col_NumberPlate4RF] = disCarShipResultWork.NumberPlate4;
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_NumberPlate4RF] = string.Empty;
                }

                //初年度
                if (DateTime.MinValue.Equals(disCarShipResultWork.FirstEntryDate))
                {
                    dr[PMSYA02005EA.ct_Col_FirstEntryDateRF] = "";
                }
                else
                {
                    dr[PMSYA02005EA.ct_Col_FirstEntryDateRF] = disCarShipResultWork.FirstEntryDate;
                }
                
                //メーカーコード
                dr[PMSYA02005EA.ct_Col_MakerCodeRF] = disCarShipResultWork.MakerCode;
                //車種コード
                dr[PMSYA02005EA.ct_Col_ModelCodeRF] = disCarShipResultWork.ModelCode;
                //車種サブコード
                dr[PMSYA02005EA.ct_Col_ModelSubCodeRF] = disCarShipResultWork.ModelSubCode;
                //車種半角名称
                dr[PMSYA02005EA.ct_Col_ModelHalfNameRF] = disCarShipResultWork.ModelHalfName;
                //型式（フル型）
                dr[PMSYA02005EA.ct_Col_FullModelRF] = disCarShipResultWork.FullModel;
                //車両走行距離
                dr[PMSYA02005EA.ct_Col_MileageRF] = disCarShipResultWork.Mileage;
                // lineShow
                dr[PMSYA02005EA.ct_Col_LineShow] = true;

                //空白を処理する
                if (count > 1)
                {
                    
                    if (i == 0)
                    {
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 1)
                        {
                            // Line_Show
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                if (disCarShipResultWork.SalesDate == nextDisCarShipResultWork.SalesDate)
                                {
                                    if (disCarShipResultWork.SalesSlipNum == nextDisCarShipResultWork.SalesSlipNum)
                                    {
                                        // lineShow
                                        dr[PMSYA02005EA.ct_Col_LineShow] = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lastDisCarShipResultWork = (CarShipResultWork)carShipRsltWork[i - 1];

                        //実績表
                        if (((int)carShipRsltListCndtn.GroupBySectionDiv == 0))
                        {
                            //品番
                            if (((int)carShipRsltListCndtn.DetailDataValue == 0) || ((int)carShipRsltListCndtn.DetailDataValue == 1))
                            {
                                if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                                {
                                    //実績表
                                    //拠点と得意先と車輌管理コードと車両管理番号
                                    if ((disCarShipResultWork.ResultsAddUpSecCd == lastDisCarShipResultWork.ResultsAddUpSecCd)
                                        && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                        && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                        && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                                    {
                                        if (disCarShipResultWork.BLGroupCode == lastDisCarShipResultWork.BLGroupCode)
                                        {
                                            if (disCarShipResultWork.BLGoodsCode == lastDisCarShipResultWork.BLGoodsCode)
                                            {
                                                //BL商品コード
                                                dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = string.Empty;
                                                //BL商品コード名称（半角）
                                                dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = string.Empty;

                                                if (disCarShipResultWork.GoodsNameKana == lastDisCarShipResultWork.GoodsNameKana)
                                                {
                                                    //商品名称カナ
                                                    dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = string.Empty;
                                                }
                                            }
                                        }
                                        

                                    }
                                }
                            }
                            else if ((int)carShipRsltListCndtn.DetailDataValue == 2)
                            {
                                //グループコード
                                //拠点と得意先と車輌管理コードと車両管理番号
                                if ((disCarShipResultWork.ResultsAddUpSecCd == lastDisCarShipResultWork.ResultsAddUpSecCd)
                                    && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                    && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                    && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                                {
                                    if (disCarShipResultWork.BLGroupCode == lastDisCarShipResultWork.BLGroupCode)
                                    {
                                        //グループコード
                                        dr[PMSYA02005EA.ct_Col_BLGroupCodeRF] = string.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //リスト
                            //拠点と得意先と車輌管理コードと車両管理番号
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(lastDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == lastDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == lastDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == lastDisCarShipResultWork.CarMngNo))
                            {

                                if (disCarShipResultWork.SalesDate == lastDisCarShipResultWork.SalesDate)
                                {
                                    //売上日付
                                    dr[PMSYA02005EA.ct_Col_SalesDateRF] = string.Empty;
                                    if (disCarShipResultWork.SalesSlipNum == lastDisCarShipResultWork.SalesSlipNum)
                                    {
                                        //売上伝票番号
                                        dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = string.Empty;
                                    }
                                }

                            }
                            // Line_Show
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                if (disCarShipResultWork.SalesDate == nextDisCarShipResultWork.SalesDate)
                                {
                                    if (disCarShipResultWork.SalesSlipNum == nextDisCarShipResultWork.SalesSlipNum)
                                    {
                                        // lineShow
                                        dr[PMSYA02005EA.ct_Col_LineShow] = false;
                                    }
                                }
                            }
                        }
                    }

                    //毎ページに、第一行データをセットする
                    if (i == 0)
                    {
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                             //品番
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k++;
                                k++;
                            }
                            else
                            {
                                k++;
                            }

                        }
                        else
                        {
                            k++;
                        }
                        
                    }
                   
                    string disCarMngNo = disCarShipResultWork.CarMngCode + disCarShipResultWork.CarMngNo.ToString();
                    string nextCarMngNo = nextDisCarShipResultWork.CarMngCode + nextDisCarShipResultWork.CarMngNo.ToString();
                    if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                    {
                        //実績表
                        //改頁 なし
                        if ((int)carShipRsltListCndtn.NewPageDiv == 0)
                        {
                            //拠点と得意先
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                //品番
                                if ((int)carShipRsltListCndtn.DetailDataValue == 0)
                                {
                                    //車輌計
                                    if ((disCarMngNo != nextCarMngNo))
                                    {
                                        //BL商品コード計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //BLグループコード計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        carGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //車輌計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        if (!newPage)
                                        {
                                            //管理番号ラン
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                        if (!newPage)
                                        {
                                            //グループコードラン
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        // BLグループコード
                                        if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                        {
                                            //BL商品コード計
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            //BLグループコード計
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            BLGroupPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            if (!newPage)
                                            {
                                                //グループコードラン
                                                k++;
                                                diffPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }
                                        }
                                        else
                                        {
                                            //BL商品コード
                                            if (disCarShipResultWork.BLGoodsCode != nextDisCarShipResultWork.BLGoodsCode)
                                            {
                                                //BL商品コード計
                                                k++;
                                                diffPage = true;
                                                detailPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }
                                        }
                                    }

                                }
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 1)
                                {
                                    // BLｺｰﾄﾞ
                                    //車輌計
                                    if (disCarMngNo != nextCarMngNo)
                                    {
                                        //BLグループコード計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        carGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        //車輌計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        if (!newPage)
                                        {
                                            //管理番号ラン
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                        if (!newPage)
                                        {
                                            //グループコードラン
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        // BLグループコード
                                        if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                        {
                                            //BLグループコード計
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            BLGroupPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                            if (!newPage)
                                            {
                                                //グループコードラン
                                                k++;
                                                diffPage = true;
                                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                            }

                                        }
                                    }
                                }

                                //BLグループコード
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 2)
                                {
                                    //車輌計
                                    if (disCarMngNo != nextCarMngNo)
                                    {
                                        //車輌計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        carPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                        if (!newPage)
                                        {
                                            //管理番号ラン
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //品番
                                if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                                {
                                    k = 2;
                                }
                                else
                                {
                                    k = 1;
                                }
                            }
                        }
                        else
                        {
                            //改頁 車輌
                            //拠点と得意先と車輌管理コードと車両管理番号
                            if ((disCarShipResultWork.ResultsAddUpSecCd == nextDisCarShipResultWork.ResultsAddUpSecCd)
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                //品番
                                if ((int)carShipRsltListCndtn.DetailDataValue == 0)
                                {
                                    //BLグループコード
                                    if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                    {
                                        // BL商品コード計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        // BLグループコー計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        // BLグループコーラン
                                        if (!newPage)
                                        {
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }
                                    else
                                    {
                                        //BL商品コード
                                        if (disCarShipResultWork.BLGoodsCode != nextDisCarShipResultWork.BLGoodsCode)
                                        {
                                            //BL商品コード計
                                            k++;
                                            diffPage = true;
                                            detailPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                                else if ((int)carShipRsltListCndtn.DetailDataValue == 1)
                                {
                                    //BLグループコード
                                    if (disCarShipResultWork.BLGroupCode != nextDisCarShipResultWork.BLGroupCode)
                                    {
                                        //BLグループコード計
                                        k++;
                                        diffPage = true;
                                        detailPage = true;
                                        BLGroupPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                        // BLグループコーラン
                                        if (!newPage)
                                        {
                                            k++;
                                            diffPage = true;
                                            k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //品番
                                if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                                {
                                    k = 2;
                                }
                                else
                                {
                                    k = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //リスト
                        //改頁 なし
                        if ((int)carShipRsltListCndtn.NewPageDiv == 0)
                        {
                            //拠点と得意先
                            if ((disCarShipResultWork.ResultsAddUpSecCd.Equals(nextDisCarShipResultWork.ResultsAddUpSecCd))
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);

                                //車輌計
                                if (disCarMngNo != nextCarMngNo)
                                {
                                    k++;
                                    diffPage = true;
                                    detailPage = true;
                                    k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                    // 管理番号ラン
                                    if (!newPage)
                                    {
                                        k++;
                                        diffPage = true;
                                        k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                                    }
                                }

                            }
                            else
                            {
                                k = 1;
                            }
                        }
                        else
                        {
                            //改頁 車輌
                            //拠点と得意先と車輌管理コードと車両管理番号
                            if ((disCarShipResultWork.ResultsAddUpSecCd == nextDisCarShipResultWork.ResultsAddUpSecCd)
                                && (disCarShipResultWork.CustomerCode == nextDisCarShipResultWork.CustomerCode)
                                && (disCarShipResultWork.CarMngCode == nextDisCarShipResultWork.CarMngCode)
                                && (disCarShipResultWork.CarMngNo == nextDisCarShipResultWork.CarMngNo))
                            {
                                k++;
                                detailPage = true;
                                k = DivPage(k, disCarShipResultWork, ref dr, carShipRsltListCndtn);
                            }
                            else
                            {
                                k = 1;
                            }
                        }
                    }
 
                }
                // TableにAdd
                carShipRsltDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 帳票データ処理
        /// </summary>
        /// <param name="k">line Num</param>
        /// <param name="disCarShipResultWork">取得データ</param>
        /// <param name="dr">DataRow</param>
        /// <param name="carShipRsltListCndtn">UI抽出条件クラス</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int DivPage(int k, CarShipResultWork disCarShipResultWork, ref DataRow dr, CarShipRsltListCndtn carShipRsltListCndtn)
        {
            newPage = false;
            int NUM = 32;
            if(lineFlg)
            {
                NUM = NUM - 1;
            }

            if (k / NUM == 1 && k % NUM == 1)
            {
                newPage = true;
                if(!diffPage)
                {
                    //BL商品コード
                    dr[PMSYA02005EA.ct_Col_BLGoodsCodeRF] = disCarShipResultWork.BLGoodsCode;

                    //BL商品コード名称（半角）
                    dr[PMSYA02005EA.ct_Col_BLGoodsHalfNameRF] = disCarShipResultWork.BLGoodsHalfName;

                    //商品名称カナ
                    dr[PMSYA02005EA.ct_Col_GoodsNameKanaRF] = disCarShipResultWork.GoodsNameKana;

                    //売上伝票番号
                    dr[PMSYA02005EA.ct_Col_SalesSlipNumRF] = disCarShipResultWork.SalesSlipNum;

                    //売上日付
                    dr[PMSYA02005EA.ct_Col_SalesDateRF] = disCarShipResultWork.SalesDate;
                }
                if (detailPage)
                {
                    if (diffPage)
                    {
                        // 実績表
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k = 3;
                            }
                            else
                            {
                                k = 2;
                            }
                            if (BLGroupPage && !carGroupPage)
                            {
                                k += 1;
                            }
                            // 車輌計改頁の場合
                            if (carPage)
                            {
                                k += 1;
                            }
                        }
                        else
                        {
                            k = 3;
                        }

                        
                    }
                    else
                    {
                        // 実績表
                        if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                        {
                            if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                            {
                                k = 3;
                            }
                            else
                            {
                                k = 2;
                            }
                        }
                        else
                        {
                            k = 2;
                        }
                    }
                    
                }
                else
                {
                    // 実績表
                    if ((int)carShipRsltListCndtn.GroupBySectionDiv == 0)
                    {
                        if ((int)carShipRsltListCndtn.DetailDataValue != 2)
                        {
                            k = 2;
                        }
                        else
                        {
                            k = 1;
                        }
                    }
                    else
                    {
                        k = 1;
                    }
                }
                
            }

            diffPage = false;
            detailPage = false;
            BLGroupPage = false;
            carPage = false;
            carGroupPage = false;
            return k;
        }

        #region ◎ 抽出条件出力情報作成
        /// <summary>
        /// 抽出条件出力情報作成
        /// </summary>
        /// <param name="extraConditions">作成後抽出条件コレクション</param>
        /// <param name="_carShipRsltListCndtn">抽出条件</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を作成する。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions, CarShipRsltListCndtn _carShipRsltListCndtn)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            // 売上日
            if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateSt))
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("売上日：{0} ～ {1}",
                         _carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                         _carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("売上日：{0} ～ {1}",
                        _carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("売上日：{0} ～ {1}",
                         ct_Extr_Top,
                         _carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // 入力日
            if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateSt))
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("入力日：{0} ～ {1}",
                         _carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                         _carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("入力日：{0} ～ {1}",
                        _carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(_carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("入力日：{0} ～ {1}",
                         ct_Extr_Top,
                         _carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // 在庫取寄指定
            this.EditCondition(ref addConditions, string.Format("在庫取寄指定：{0}",
                         _carShipRsltListCndtn.RsltTtlDivName));

            // 得意先
            if (_carShipRsltListCndtn.CustomerCodeSt != 0)
            {
                if (_carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("得意先：{0} ～ {1}",
                         _carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), _carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("得意先：{0} ～ {1}",
                        _carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("得意先：{0} ～ {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
            }

            // 管理番号
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeSt))
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("管理番号：{0} ～ {1}",
                         _carShipRsltListCndtn.CarMngCodeSt, _carShipRsltListCndtn.CarMngCodeEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("管理番号：{0} ～ {1}",
                        _carShipRsltListCndtn.CarMngCodeSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("管理番号：{0} ～ {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.CarMngCodeEd));
                }
            }

            // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
            if (_carShipRsltListCndtn.BLGroupCodeSt != 0)
            {
                if (_carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("グループコード：{0} ～ {1}",
                         _carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), _carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("グループコード：{0} ～ {1}",
                        _carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("グループコード：{0} ～ {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
            }

            // BLｺｰﾄﾞ
            if (_carShipRsltListCndtn.BLGoodsCodeSt != 0)
            {
                if (_carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BLコード：{0} ～ {1}",
                         _carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), _carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("BLコード：{0} ～ {1}",
                        _carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (_carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BLコード：{0} ～ {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
            }

            // 品番
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoSt))
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("品番：{0} ～ {1}",
                         _carShipRsltListCndtn.GoodsNoSt, _carShipRsltListCndtn.GoodsNoEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("品番：{0} ～ {1}",
                        _carShipRsltListCndtn.GoodsNoSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("品番：{0} ～ {1}",
                         ct_Extr_Top, _carShipRsltListCndtn.GoodsNoEd));
                }
            }

            // 車輌備考
            if (!string.IsNullOrEmpty(_carShipRsltListCndtn.SlipNoteCar))
            {
                // 車輌備考,車輌備考検索区分
                this.EditCondition(ref addConditions, string.Format("車輌備考：{0} {1}",
                         _carShipRsltListCndtn.SlipNoteCar, _carShipRsltListCndtn.CarOutDivName));

            }

            // 追加
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region ◎ 抽出条件文字列編集
        /// <summary>
        /// 抽出条件文字列編集
        /// </summary>
        /// <param name="editArea">格納エリア</param>
        /// <param name="target">対象文字列</param>
        /// <remarks>
        /// <br>Note       : 出力する抽出条件文字列を編集します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // 編集対象文字バイト数算出
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // 格納エリアのバイト数算出
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // 全角スペースを挿入
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
                else
                {
                    lineFlg = true;
                }
            }
            // 新規編集エリア作成
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion

        #endregion ■ Private Method

    }
}
