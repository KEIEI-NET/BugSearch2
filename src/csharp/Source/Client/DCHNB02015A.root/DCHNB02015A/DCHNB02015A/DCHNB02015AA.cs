using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受注貸出確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>受注貸出確認表で使用するデータを取得する。</br>
    /// <br>UpdateNote :2008/10/31 照田 貴志　消費税印字方法変更</br>
    /// <br>UpdateNote :2009/01/30 上野 俊治　発行タイプの仕様変更。受注数、受注残数追加。</br>
    /// <br>UpdateNote :2011/07/21 王飛３　連番No.946 未計上分のみの印刷ができないの対応</br>
    /// <br>UpdateNote :2011/08/11 王飛３　Redmine23472 一部計上の伝票は「貸出」「計上済」の両方で対象としてください。</br>
    /// <br>UpdateNote :2011/08/11 caohh　Redmine#23472対応</br>
    /// <br>UpdateNote :2011/09/30 yangyi　Redmine#25724対応</br>
    /// <br>UpdateNote :2011/10/09 鄧潘ハン　Redmine#25724対応</br>
    /// <br>UpdateNote :2011/10/10 鄧潘ハン　Redmine#25724対応</br>
    /// <br>UpdateNote :2011/12/02 陳建明　障害報告 #8316対応 貸出確認表/金額の算出方法の変更</br>
    /// <br>UpdateNote :2011/12/18 陳建明　障害報告 #8316対応 貸出確認表/金額の算出方法の変更</br>
    /// <br>UpdateNote :2011/12/19 陳建明　障害報告 #8316対応 貸出確認表/金額の算出方法の変更</br>
    /// </remarks>
    public class SaleConfAcs
    {
        // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
        #region public constant
        /// <summary>全拠点レコード用拠点コード</summary>
        public const string CT_AllSectionCode = "000000";
        #endregion

        // ===================================================================================== //
        //  スタティック変数
        // ===================================================================================== //
        #region static variable

        /// <summary>自拠点コード</summary>
        private static string mySectionCode = "";
        // <summary>帳票出力設定データクラス</summary>
        private static PrtOutSet prtOutSetData = null;

        #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;
        /// <summary>帳票出力設定アクセスクラス</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>印刷用DataSet</summary>
        public DataSet _printDataSet;
        /// <summary>バッファDataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>受注出荷確認表データテーブル名</summary>
        private string _SalesConfDataTable;

        // 帳票タイプ（合計 or 明細判定用）
        private int _printDiv;      //ADD 2008/10/31

        // ------ ADD caohh 2011/08/11 ------->>>>>
        // 発行タイプ（判定用）
        private int _publicationType;
        // ------ ADD caohh 2011/08/11 -------<<<<<

        /// <summary>表示順位</summary>

        private string CT_Sort1_Odr01 = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo ";	    //（拠点）＋受注日＋伝票番号＋行番号
        private string CT_Sort1_Odr02 = "SectionCode, ShipmentDay, SalesSlipNum, SalesRowNo ";	//（拠点）＋出荷日＋伝票番号＋行番号
        private string CT_Sort2_Odr = "SectionCode,SalesSlipNum";									//（拠点）＋伝票番号
        private string CT_Sort3_Odr = "SectionCode,CustomerCode, SalesSlipNum";					//（拠点）＋得意先＋伝票番号
        private string CT_Sort4_Odr = "SectionCode,SalesEmployeeCd, SalesSlipNum";				//（拠点）＋販売従業員(担当者)コード＋伝票番号

        private string CT_UpperOrder = " ASC";   // 昇順出力
        //private string CT_DownOrder  = " DESC";  // 降順出力

        #endregion

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        ///// <summary>受注出荷確認表バッファデータテーブル名</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター

        /// <summary>
        /// 受注貸出確認表アクセスクラスコンストラクター
        /// </summary>
        public SaleConfAcs()
        {
            this.SettingDataTable();

            // 印刷用DataSet
            this._printDataSet = new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // バッファテーブルデータセット
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // 拠点情報取得
            this.CreateSecInfoAcs();

        }

        #endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

        /// <summary>
        /// 受注貸出確認表アクセスクラス静的コンストラクター
        /// </summary>
        static SaleConfAcs()
        {
            // 帳票出力設定アクセスクラスインスタンス化
            prtOutSetAcs = new PrtOutSetAcs();

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                mySectionCode = loginEmployee.BelongSectionCode;
            }
        }

        #endregion

        // ===================================================================================== //
        // 外部提供関数
        // ===================================================================================== //
        #region public method

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>UpdateNote : public int ReadPrtOutSet → public static int ReadPrtOutSet にしました。</br>
        /// <br>Programmer : 30191 A.Mabuchi</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // データは読込済みか？
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "帳票出力設定の読込に失敗しました。";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// 受注貸出確認表データ初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Static情報を初期化します。
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --テーブル行初期化-----------------------
            // 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[_SalesConfDataTable] != null)
            {
                this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();
            }
            // 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_SalesConfDataTable] != null)
            {
                _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Clear();
            }
        }
        /// <summary>
        /// 受注貸出確認表データ取得処理
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_DCHNB02013E saleConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(saleConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(saleConfListCndtn, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only の場合はリモーティングに行かない
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }


        /// <summary>
        /// 受注貸出確認表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_SalesConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }
        /// <summary>
        /// 受注貸出確認表データ取得処理
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>対象範囲の受注出荷確認表データを取得します。</br>
        /// <br>UpdateNote :2011/09/30 yangyi　Redmine#25724対応</br>
        /// <br>UpdateNote :2011/10/09 鄧潘ハン　Redmine#25724対応</br>
        /// <br>UpdateNote :2011/10/10 鄧潘ハン　Redmine#25724対応</br>
        /// <br>UpdateNote :2011/12/02 陳建明　Redmine#8316対応</br>
        /// </remarks>
        private int Search(ExtrInfo_DCHNB02013E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            int printDiv = saleConfListCndtn.PrintDiv;	//SearchByModeに渡す、伝票形式区分の判定用変数
            this._publicationType = saleConfListCndtn.PublicationType;	//発行タイプの判定用変数 // ADD caohh 2011/08/11
            Dictionary<string, DataRow> _dicSalesNum = new Dictionary<string, DataRow>();        // ADD yangyi 2011/09/30  

            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                OrderConfShWork orderConfShWork = new OrderConfShWork();
                // 抽出条件パラメータセット
                this.SearchParaSet(saleConfListCndtn, ref orderConfShWork);

                status = this.SearchByMode(out retObj, orderConfShWork, printDiv);

                this._printDiv = printDiv;      //ADD 2008/10/31  SetTebleRowFromRetList内で使用する為

                ArrayList retList = (ArrayList)retObj;
                // ----- ADD K2011/09/28 --------------------------->>>>>
                List<DataRow> drList = new List<DataRow>();
                List<DataRow> drListRet = new List<DataRow>();
                if (printDiv == 1 || printDiv == 3)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);
                        drList.Add(dr);
                    }
                    foreach (DataRow dr in drList)
                    {
                        if (!_dicSalesNum.ContainsKey(dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()))
                        {
                            _dicSalesNum.Add(dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString(), dr);
                        }
                        else
                        {
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF].ToString())).ToString();
                            //---DEL 2011/10/09 --------------------------------------------------->>>>>
                            //_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_Tax] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_Tax].ToString())
                            //                    + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_Tax].ToString())).ToString();
                            //_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax].ToString())
                            //                    + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax].ToString())).ToString();
                            //---DEL 2011/10/09 ---------------------------------------------------<<<<<
                            //---ADD 2011/10/09 --------------------------------------------------->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesMoney] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesMoney].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney].ToString())).ToString();
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt].ToString())).ToString();
                            //---ADD 2011/10/10 --------------------------------------------------->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].ToString())).ToString();
                            //---ADD 2011/10/10 ---------------------------------------------------<<<<<
                            //---ADD 2011/10/09 ---------------------------------------------------<<<<<
                            //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_TotalCostRF] = Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_TotalCostRF])
                                               + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_TotalCostRF]);
                            //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                        }

                    }
                    foreach (string numKey in _dicSalesNum.Keys)
                    {
                        drListRet.Add(_dicSalesNum[numKey]);
                    }
                    foreach (DataRow dr in drListRet)
                    {
                        //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                        //原価
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRF];
                        //add 2011/12/18 陳建明 Redmine #8316----->>>>>
                        if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF])==0)//売上
                        {
                        //add 2011/12/18 陳建明 Redmine #8316-----<<<<<   
                            //粗利：金額‐原価
                            dr[DCHNB02014EA.CT_OrderConf_GrossProfit] =
                                Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) -
                                Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_TotalCostRF]);
                            //粗利率(合計)
                            //金額 0 の場合、粗利率は0としてセットする
                            if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) == 0)
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = 0;
                            }
                            else
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] =
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfit]) * 100 /
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]);
                            }
                            //粗利：金額‐原価
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] =
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) -
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_TotalCostSl]);
                        //add 2011/12/18 陳建明 Redmine #8316----->>>>>
                        }
                        else if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF]) == 1)//返品
                        {
                            //粗利：金額‐原価
                            dr[DCHNB02014EA.CT_OrderConf_GrossProfit] = dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit];

                            //粗利率(合計)
                            //金額 0 の場合、粗利率は0としてセットする
                            if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney]) == 0)
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = 0;
                            }
                            else
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] =
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfit]) * 100 /
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney]);
                            }
                            //粗利：金額‐原価
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = dr[DCHNB02014EA.CT_OrderConf_GrossProfit];
                            //金額
                            dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney];
                            //消費税
                            dr[DCHNB02014EA.CT_OrderConf_SalesTax] = dr[DCHNB02014EA.CT_OrderConf_ReturnTax];
                            //合計金額
                            dr[DCHNB02014EA.CT_OrderConf_SalesTotalAll] = dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll];
                            //原価
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn];
                                
                        }
                        //add 2011/12/18 陳建明 Redmine #8316-----<<<<<
                        //粗利チェックマーク(合計)
                        if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckLower)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin1Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckBest)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin2Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckUpper)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin3Mark;
                        }
                        else 
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin4Mark;
                        }
                        //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);
                        //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                        //粗利率(明細)
                        //金額 0 の場合、粗利率は0としてセットする
                        if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF]) == 0)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = 0;
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] =
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl])*100 /
                                                 Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF]);
                        }
                        //add 2011/12/18 陳建明 Redmine #8316----->>>>>
                        if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF]) == 1)//返品
                        {
                            //粗利：金額‐原価
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfitDtl];
                            //金額
                            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = dr[DCHNB02014EA.CT_OrderConf_SalesMoneyRtnDtl];
                            //消費税
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl];
                            //原価
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl];
                        }
                        //add 2011/12/18 陳建明 Redmine #8316-----<<<<<
                        //粗利チェックマーク(明細)
                        if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckLower)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin1Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckBest)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin2Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckUpper)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin3Mark;
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin4Mark;
                        }
                        //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                // ----- ADD K2011/09/01 ---------------------------<<<<<

                // --- ADD 2009/01/30 -------------------------------->>>>>
                // 受注残数によるフィルタ処理
                FilterByAcptAnOdrRemainCnt(saleConfListCndtn);

                if (this._printDataSet.Tables[_SalesConfDataTable].Rows.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // --- ADD 2009/01/30 -------------------------------->>>>>

                // バッファテーブルへの格納
                _printBuffDataSet = this._printDataSet.Copy();
            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        private void SearchParaSet(ExtrInfo_DCHNB02013E saleConfListCndtn, ref OrderConfShWork orderConfShWork)
        {
            orderConfShWork.EnterpriseCode = saleConfListCndtn.EnterpriseCode;				// 企業コード

            // 拠点
            if (saleConfListCndtn.ResultsAddUpSecList.Length != 0)
            {
                if (saleConfListCndtn.ResultsAddUpSecList[0] == "0")
                {
                    // 全社の時
                    orderConfShWork.ResultsAddUpSecList = new string[0];						// 拠点コード
                    // 2008.07.25 30413 犬飼 不要プロパティの削除 >>>>>>START
                    //orderConfShWork.IsOutputAllSecRec = true;
                    //orderConfShWork.IsSelectAllSection = true;
                    // 2008.07.25 30413 犬飼 不要プロパティの削除 <<<<<<END
                }
                else
                {
                    orderConfShWork.ResultsAddUpSecList = saleConfListCndtn.ResultsAddUpSecList;// 拠点コード
                    // 2008.07.25 30413 犬飼 不要プロパティの削除 >>>>>>START
                    //orderConfShWork.IsSelectAllSection = false;
                    //// 全拠点にチェックがつけられているかどうかのチェック
                    //if (_secInfoAcs.SecInfoSetList.Length == saleConfListCndtn.ResultsAddUpSecList.Length)
                    //{
                    //    orderConfShWork.IsOutputAllSecRec = true;
                    //}
                    //else
                    //{
                    //    orderConfShWork.IsOutputAllSecRec = false;
                    //}
                    // 2008.07.25 30413 犬飼 不要プロパティの削除 <<<<<<END
                }
            }
            else
            {
                orderConfShWork.ResultsAddUpSecList = new string[0];    // 拠点コード
                // 2008.07.25 30413 犬飼 不要プロパティの削除 >>>>>>START
                //orderConfShWork.IsOutputAllSecRec = true;               // 全拠点集計レコードでの出力
                //orderConfShWork.IsSelectAllSection = false;
                // 2008.07.25 30413 犬飼 不要プロパティの削除 <<<<<<END
            }

            //リモートへデータを渡す
            orderConfShWork.AcptAnOdrStatus = saleConfListCndtn.AcptAnOdrStatus;			//受注出荷判定

            orderConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDateSt;			// 開始入力日（伝票検索日付）
            orderConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDateEd;			// 終了入力日（伝票検索日付）

            orderConfShWork.SalesDateSt = saleConfListCndtn.SalesDateSt;                    // 開始売上日
            orderConfShWork.SalesDateEd = saleConfListCndtn.SalesDateEd;                    // 終了売上日
            orderConfShWork.ShipmentDaySt = saleConfListCndtn.ShipmentDaySt;                // 開始出荷日
            orderConfShWork.ShipmentDayEd = saleConfListCndtn.ShipmentDayEd;                // 終了出荷日

            orderConfShWork.CustomerCodeSt = saleConfListCndtn.CustomerCodeSt;              // 開始得意先コード
            orderConfShWork.CustomerCodeEd = saleConfListCndtn.CustomerCodeEd;              // 終了得意先コード
            orderConfShWork.SalesEmployeeCdSt = saleConfListCndtn.SalesEmployeeCdSt;        // 開始担当コード
            orderConfShWork.SalesEmployeeCdEd = saleConfListCndtn.SalesEmployeeCdEd;        // 終了担当コード

            orderConfShWork.GrsProfitCheckLower = saleConfListCndtn.GrsProfitCheckLower;	// 粗利率(下限)
            orderConfShWork.GrsProfitCheckBest = saleConfListCndtn.GrsProfitCheckBest;		// 粗利率(適正)
            orderConfShWork.GrsProfitCheckUpper = saleConfListCndtn.GrsProfitCheckUpper;	// 粗利率(上限)

            orderConfShWork.GrossMargin1Mark = saleConfListCndtn.GrossMargin1Mark;			//粗利チェックマーク1
            orderConfShWork.GrossMargin2Mark = saleConfListCndtn.GrossMargin2Mark;			//粗利チェックマーク2
            orderConfShWork.GrossMargin3Mark = saleConfListCndtn.GrossMargin3Mark;			//粗利チェックマーク3
            orderConfShWork.GrossMargin4Mark = saleConfListCndtn.GrossMargin4Mark;			//粗利チェックマーク4

            orderConfShWork.SalesSlipCd = -1;					// 売上伝票区分[伝票]（抽出条件）
            // 2008.07.25 30413 犬飼 ↑で同じ処理を行っているので削除 >>>>>>START
            //orderConfShWork.SalesSlipCd = -1;              // 売上伝票区分[明細]（抽出条件）
            // 2008.07.25 30413 犬飼 ↑で同じ処理を行っているので削除 <<<<<<END

            // 2008.07.25 30413 犬飼 発行タイプの追加 >>>>>>START
            orderConfShWork.PrintDiv = saleConfListCndtn.PublicationType;                   // 発行タイプ
            // 2008.07.25 30413 犬飼 発行タイプの追加 <<<<<<END

            //orderConfShWork.DebitNoteDiv = saleConfListCndtn.DebitNoteDiv;                  // 赤伝区分（抽出条件）

        }

        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.DCHNB02014EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// Search呼出処理
        /// </summary>
        /// <object name="retObj">取得データオブジェクト</object>
        /// <object name="salesConfShWork">リモート検索条件クラス</object>
        /// <returns>ステータス</returns>

        private int SearchByMode(out object retObj, OrderConfShWork orderConfShWork, int printDiv)
        {
            int status = 0;

            retObj = null;

            IOrderConfDB _iOrderConfDB = (IOrderConfDB)MediationOrderConfDB.GetOrderConfDB();	//G:AとOを仲介

            switch (printDiv)
            {
                case 1:		//伝票形式
                case 3:
                    status = _iOrderConfDB.SearchSlip(out retObj, orderConfShWork);
                    break;

                case 2:		//明細形式
                case 4:
                    status = _iOrderConfDB.SearchDetail(out retObj, orderConfShWork);
                    break;
            }

            return status;
        }
        ///// <param name="retObj">取得データオブジェクト</param>
        ///// <param name="salesConfShWork">リモート検索条件クラス</param>
        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        ///  DataViewに設定する印字順位のクエリを作成します。
        /// </remarks>
        private string GetPrintOderQuerry(ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            string orderQuerry = "";

            // ソート順設定
            switch (saleConfListCndtn.SortOrder)
            {
                case 0:
                    {
                        if (saleConfListCndtn.AcptAnOdrStatus == 20)
                        {
                            orderQuerry = CT_Sort1_Odr01;
                        }
                        else
                        {
                            orderQuerry = CT_Sort1_Odr02;
                        }
                        break;
                    }
                case 1:
                    {

                        orderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {

                        orderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {

                        orderQuerry = CT_Sort4_Odr;
                        break;
                    }

            }

            // 昇順固定
            orderQuerry += CT_UpperOrder;

            return orderQuerry;
        }



        /// <summary>
        /// データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            this._SalesConfDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_OrderConfDataTable;
        }

        /// <summary>
        /// データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        {
            OrderConfWork orderConfWork = (OrderConfWork)retList[setCnt];

            //[共通]
            dr[DCHNB02014EA.CT_OrderConf_SectionCode] = orderConfWork.SectionCode;					// 拠点コード					(string)
            dr[DCHNB02014EA.CT_OrderConf_SectionGuideNm] = orderConfWork.SectionGuideNm;			// 拠点ガイド名称（拠点名称）	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = orderConfWork.SalesDate;					// 売上（受注）日付			　	(Int32)
            //dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = orderConfWork.ShipmentDay;				// 出荷日付						(DateTime)
            // 2008.09.24 30413 犬飼 受注日と貸出日の設定変更 >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SalesDate);   // 売上（受注）日付			　	(Int32)
            //dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.ShipmentDay); // 出荷日付						(DateTime)
            if (orderConfWork.SalesDate != DateTime.MinValue)
            {
                // 受注日が設定されている
                dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SalesDate);   // 売上（受注）日付			　	(DateTime)
            }
            if (orderConfWork.ShipmentDay != DateTime.MinValue)
            {
                // 貸出日が設定されている
                dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.ShipmentDay); // 貸出日付						(DateTime)
            }
            dr[DCHNB02014EA.CT_OrderConf_CustomerCodeRF] = orderConfWork.CustomerCode;				// 得意先コード					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerSnmRF] = orderConfWork.CustomerSnm;				// 得意先略称 				　	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = orderConfWork.SearchSlipDate;			// （伝票検索日付）入力日付[共通](DateTime)
            dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SearchSlipDate);   // （伝票検索日付）入力日付[共通](DateTime)
            dr[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF] = orderConfWork.PartySaleSlipNum;      // 相手先伝票番号（得意先注文番号）[共通](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF] = orderConfWork.SalesEmployeeNm;		// 販売従業員（担当者）名称[共通](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF] = orderConfWork.SalesEmployeeCd;
            dr[DCHNB02014EA.CT_OrderConf_SalesInputNameRF] = orderConfWork.SalesInputName;			// 売上入力者名称[共通]		(string)
            // 2008.07.25 30413 犬飼 [共通]の項目追加 >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_FrontEmployeeCd] = orderConfWork.FrontEmployeeCd;          // 受付従業員コード[共通](string)
            dr[DCHNB02014EA.CT_OrderConf_FrontEmployeeNm] = orderConfWork.FrontEmployeeNm;          // 受付従業員名称[共通](string)
            // 2008.07.25 30413 犬飼 [共通]の項目追加 <<<<<<END
            // --- ADD 2009/01/30 -------------------------------->>>>>
            dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] = orderConfWork.AcptAnOdrRemainCnt; // 受注残数
            dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCnt] = orderConfWork.AcceptAnOrderCnt; // 受注数量
            dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrAdjustCnt] = orderConfWork.AcptAnOdrAdjustCnt; // 受注調整数
            dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt] = orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt; // 受注数
            // --- ADD 2009/01/30 --------------------------------<<<<<

            //[伝票]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF] = orderConfWork.SalesSlipNum;				// 売上伝票番号					(string)
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = orderConfWork.GrossMarginRate;			// 粗利率[伝票]					(Double)//del 2011/12/02 陳建明 Redmine #8316
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfWork.GrossMarginMarkSlip;	// 粗利チェックマーク[伝票]		(string)//del 2011/12/02 陳建明 Redmine #8316
            dr[DCHNB02014EA.CT_OrderConf_TransactionNameRF] = orderConfWork.TransactionName;		// 取引区分名[伝票]			　	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = orderConfWork.SalesTotalTaxExc;		// 売上（受注）伝票合計(税抜)[伝票](Int64) // DEL caohh 2011/08/11
            // ------ ADD caohh 2011/08/11 ------>>>>>
            // 数量
            double cnt = 0;
            // 金額 = 数量*売上単価
            double salesTotalTaxExc = 0;
            // 受注、貸出
            if (this._publicationType == 0 || this._publicationType == 2)
            {
                //受注/貸出残数
                cnt = orderConfWork.AcptAnOdrRemainCnt;
            }
            // 受注計上済、貸出計上済
            else
            {
                //受注/貸出数－残数
                cnt = orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt - orderConfWork.AcptAnOdrRemainCnt;
            }
            salesTotalTaxExc = cnt * orderConfWork.SalesUnPrcTaxExcFl;
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = salesTotalTaxExc;		//売上（受注）伝票合計(税抜)[伝票](Int64)
            // ------ ADD caohh 2011/08/11 ------<<<<<
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF] = orderConfWork.SalesTotalTaxInc;		// 売上（受注）伝票合計(税込)[伝票](Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = orderConfWork.SalesDisTtlTaxExc;	// 売上（受注）値引金額計(税抜)[伝票]
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF] = orderConfWork.SalesDisTtlTaxInclu;// 売上（受注）値引金額計(税込)[伝票]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF] = orderConfWork.SalesSlipCd;				// 売上伝票区分[伝票]
            dr[DCHNB02014EA.CT_OrderConf_AccRecDivCd] = orderConfWork.AccRecDivCd;					// 売掛伝票区分[伝票]
            //消費税（税込み売上値引金額-税抜き売上値引金額）[伝票]
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlip] = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc;
            //消費税（値引き）（税込み売上値引金額-税抜き売上値引金額）[伝票]
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxDisSlip] = orderConfWork.SalesDisTtlTaxInclu - orderConfWork.SalesDisTtlTaxExc;
            //原価金額計[伝票]　（純売上）
            //dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.TotalCost; //del 2011/12/02 陳建明 Redmine #8316
            //add 2011/12/02 陳建明 Redmine #8316----->>>>>
            //原価＝原価＊貸出残数(貸出未計上)
            if ((this._printDiv == 1 && this._publicationType == 0) || (this._publicationType == 2 && this._printDiv == 3))
            {
                dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.SalesUnitCost * orderConfWork.AcptAnOdrRemainCnt;
            }
            //原価＝原価＊（数量‐貸出残数）(貸出計上)
            else if ((this._printDiv == 1 && this._publicationType == 1) || (this._publicationType == 3 && this._printDiv == 3))
            {
                dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.SalesUnitCost * (orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt - orderConfWork.AcptAnOdrRemainCnt);
            }
            //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
            // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
            // 伝票タイプ
            long salesTax = 0;          // 売上／返品の消費税
            long salesTotalAll = 0;     // 売上／返品の合計金額
            long distTax = 0;           // 値引の消費税
            long distTotalAll = 0;      // 値引の合計金額
            // 明細タイプ
            long salesDtlTax = 0;       // 売上／返品の消費税
            long distDtlTax = 0;        // 値引の消費税
            // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

            // 2009.01.27 30413 犬飼 消費税の計算位置を変更 >>>>>>START
            // 消費税の設定
            if ((this._printDiv == 1) || (this._printDiv == 3))
            {
                // 伝票単位に出力時

                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if ((orderConfWork.ConsTaxLayMethod == 2) ||
                    (orderConfWork.ConsTaxLayMethod == 3) ||
                    (orderConfWork.ConsTaxLayMethod == 9))
                {
                    // 消費税
                    dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
                    // 合計金額
                    //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                    //合計金額：消費税の金額を除く
                    dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc;
                    //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                    //del 2011/12/02 陳建明 Redmine #8316----->>>>>
                    //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
                    //                                                             + (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
                    //del 2011/12/02 陳建明 Redmine #8316-----<<<<<
                    // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                    // 伝票タイプの消費税と合計金額を算出
                    salesTax = orderConfWork.SalAmntConsTaxInclu;
                    salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalAmntConsTaxInclu - orderConfWork.SalesDisTtlTaxExc - salesTax;//add 2011/12/02 陳建明 Redmine #8316
                    //salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalAmntConsTaxInclu - orderConfWork.SalesDisTtlTaxExc;//del 2011/12/02 陳建明 Redmine #8316
                    distTax = orderConfWork.SalesDisTtlTaxInclu;
                    distTotalAll = orderConfWork.SalesDisTtlTaxExc + orderConfWork.SalesDisTtlTaxInclu;
                    // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END
                }
                // 消費税転嫁方式　0：伝票単位、1：明細単位
                else
                {
                    // 消費税
                    dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
                    // 合計金額
                    //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                    //合計金額：消費税の金額を除く
                    dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc;
                    //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                    //del 2011/12/02 陳建明 Redmine #8316----->>>>>
                    //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
                    //                                                        + (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
                    //del 2011/12/02 陳建明 Redmine #8316-----<<<<<
                    // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                    // 伝票タイプの消費税と合計金額を算出
                    salesTax = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisOutTax;
                    //add 2011/12/02 陳建明 Redmine #8316----->>>>>
                    salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalesTotalTaxInc -
                                    orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc -
                                    orderConfWork.SalesDisOutTax - salesTax;
                    //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
                    //salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.SalesDisOutTax;//del 2011/12/02 陳建明 Redmine #8316
                    distTax = orderConfWork.SalesDisOutTax;
                    distTotalAll = orderConfWork.SalesDisTtlTaxExc + orderConfWork.SalesDisOutTax;
                    // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END
                }
            }
            else
            {
                // 明細単位に出力時

                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                if ((orderConfWork.ConsTaxLayMethod == 2) ||
                    (orderConfWork.ConsTaxLayMethod == 3) ||
                    (orderConfWork.ConsTaxLayMethod == 9))
                {
                    // 課税区分　2：内税
                    if (orderConfWork.TaxationDivCd == 2)
                    {
                        // 消費税
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    }
                    // 課税区分　0：課税、1：非課税
                    else
                    {
                        // 消費税
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = DBNull.Value;
                    }
                }
                // 消費税転嫁方式　0：伝票単位、1：明細単位
                else
                {
                    // 2009.01.27 30413 犬飼 明細タイプの帳票で伝票転嫁の場合、売上行番号が1行目のみに消費税を設定 >>>>>>START                        
                    // 消費税
                    //dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    if (orderConfWork.ConsTaxLayMethod == 0)
                    {
                        // 消費税転嫁方式　0：伝票単位
                        if (orderConfWork.SalesRowNo == 1)
                        {
                            // 売上行番号が1行目
                            // 消費税
                            dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);

                            // 2009.01.27 30413 犬飼 小計部の消費税を追加 >>>>>>START
                            // 明細タイプの消費税を算出
                            salesDtlTax = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisOutTax;
                            distDtlTax = orderConfWork.SalesDisOutTax;
                            // 2009.01.27 30413 犬飼 小計部の消費税を追加 <<<<<<END
                        }
                        else
                        {
                            // 上記以外
                            // 消費税
                            dr[DCHNB02014EA.CT_OrderConf_Tax] = 0;
                        }
                    }
                    else
                    {
                        // 消費税転嫁方式　1：明細単位
                        // 消費税
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    }
                    // 2009.01.27 30413 犬飼 明細タイプの帳票で伝票転嫁の場合、売上行番号が1行目のみに消費税を設定 <<<<<<END                        
                }
            }
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxLayMethod] = orderConfWork.ConsTaxLayMethod;        // 消費税転嫁方式
            dr[DCHNB02014EA.CT_OrderConf_TaxationDivCd] = orderConfWork.TaxationDivCd;              // 課税区分
            // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

            // （合計）：『売上』/『返品』判断。
            //カウント、売上額・返品額、原価金額、消費税の計算。帳票のプロパティで合計させる。
            switch (orderConfWork.SalesSlipCd)
            {
                case 0:	//売上
                    {
                        //売上金額（売上伝票合計[税抜き]-売上値引き金額計[税抜き]）[伝票]
                        //dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc; // DEL caohh 2011/08/11
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = salesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc; // ADD caohh 2011/08/11
                        //『売上』数[伝票]カウント
                        dr[DCHNB02014EA.CT_OrderConf_CntSales] = 1;

                        //『売上』数[明細]カウント
                        //（明細）の中でやると明細行1行づつをカウントしてしまう。[伝票]の数を数えたいのでこちらで処理。
                        if (orderConfWork.SalesRowNo == 1)	//明細行Noが1の時だけカウント＝2行目3行目は数えない
                        {
                            dr[DCHNB02014EA.CT_OrderConf_CntSalesDtl] = 1;
                        }

                        // 原価金額計（売上）[伝票]			
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = orderConfWork.TotalCost;//del 2011/12/02 陳建明 Redmine #8316

                        //消費税（売上伝票合計(税込)-売上値引金額計(税込)-売上伝票合計(税込)+）[伝票]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip]
                                                                    = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesDisTtlTaxInclu
                                                                                                - orderConfWork.SalesTotalTaxExc + orderConfWork.SalesDisTtlTaxExc;

                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 >>>>>>START
                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 >>>>>>START
                        // 売上合計粗利
                        //dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost;
                        dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.TotalCost;
                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 <<<<<<END
                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 <<<<<<END

                        // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                        // 売上合計消費税(伝票)
                        dr[DCHNB02014EA.CT_OrderConf_SalesTax] = salesTax;

                        // 売上の消費税込合計金額(伝票)
                        dr[DCHNB02014EA.CT_OrderConf_SalesTotalAll] = salesTotalAll;
                        // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

                        break;
                    }

                case 1:	//返品
                    {
                        //返品金額（売上伝票合計[税抜き]-売上値引き金額計[税抜き]）[伝票]
                        dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc;

                        //『返品』数[伝票]カウント
                        //dr[DCHNB02014EA.CT_OrderConf_CntReturn] = 1;//del 2011/12/18 陳建明 Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_CntSales] = 1;//add 2011/12/18 陳建明 Redmine #8316

                        //『返品』数[明細]カウント
                        if (orderConfWork.SalesRowNo == 1)
                        {
                            //dr[DCHNB02014EA.CT_OrderConf_CntReturnDtl] = 1;//del 2011/12/18 陳建明 Redmine #8316
                            dr[DCHNB02014EA.CT_OrderConf_CntSalesDtl] = 1;//add 2011/12/18 陳建明 Redmine #8316
                        }

                        // 原価金額計（返品）[伝票]				
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn] = orderConfWork.TotalCost;

                        //消費税（返品）（『返品金額』*0.05）[伝票]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip]
                                                                    = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesDisTtlTaxInclu
                                                                                                - orderConfWork.SalesTotalTaxExc + orderConfWork.SalesDisTtlTaxExc;
                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 >>>>>>START
                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 >>>>>>START
                        // 返品合計粗利
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost;
                        dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.TotalCost;
                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 <<<<<<END
                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 <<<<<<END

                        // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
                        // 返品合計消費税(伝票)
                        dr[DCHNB02014EA.CT_OrderConf_ReturnTax] = salesTax;

                        // 売上の消費税込合計金額(伝票)
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll;//del 2011/12/18 陳建明 Redmine #8316
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll - salesTax;//add 2011/12/18 陳建明 Redmine #8316 //del 2011/12/19 陳建明 Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll;//add 2011/12/19 陳建明 Redmine #8316
                        // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

                        break;
                    }
            }

            // 2009.01.23 30413 犬飼 値引の粗利計算を変更 >>>>>>START
            //// 2008.07.28 30413 犬飼 [伝票]の項目追加 >>>>>>START
            //// 値引きの設定

            //// 値引き合計原価金額(伝票)
            //dr[DCHNB02014EA.CT_OrderConf_DistCost] = (orderConfWork.TotalCost);
            dr[DCHNB02014EA.CT_OrderConf_DistCost] = orderConfWork.DisCost;

            //// 値引き合計粗利(伝票)
            //dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = (orderConfWork.SalesDisTtlTaxExc - orderConfWork.Cost);
            dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = orderConfWork.SalesDisTtlTaxExc - orderConfWork.DisCost;
            //// 2008.07.28 30413 犬飼 [伝票]の項目追加 <<<<<<END
            // 2009.01.23 30413 犬飼 値引の粗利計算を変更 <<<<<<END

            // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 >>>>>>START
            // 値引き合計消費税(伝票)
            dr[DCHNB02014EA.CT_OrderConf_DistTax] = distTax;

            // 値引きの消費税込合計金額(伝票)
            dr[DCHNB02014EA.CT_OrderConf_DistTotalAll] = distTotalAll;
            // 2009.01.27 30413 犬飼 小計部の消費税と合計金額を追加 <<<<<<END

            // 2008.07.25 30413 犬飼 [伝票]の項目追加 >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_SlipNote] = orderConfWork.SlipNote; // 伝票備考[伝票](string)
            // 2008.07.25 30413 犬飼 [伝票]の項目追加 <<<<<<END


            //[明細]
            dr[DCHNB02014EA.CT_OrderConf_GoodsNoRF] = orderConfWork.GoodsNo;						// 商品コード					(string)
            dr[DCHNB02014EA.CT_OrderConf_GoodsNameRF] = orderConfWork.GoodsName;					// 商品名称						(string)
            dr[DCHNB02014EA.CT_OrderConf_MakerNameRF] = orderConfWork.MakerName;					// メーカー名					(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesRowNoRF] = orderConfWork.SalesRowNo;					// 売上行番号[明細]				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentCntRF] = orderConfWork.ShipmentCnt;				// 出荷数（数量）[明細]			(double)
            dr[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF] = orderConfWork.SalesUnPrcTaxExcFl;	// 売上単価（税抜き）[明細]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF] = orderConfWork.SalesMoneyTaxInc;	// 売上金額（税込み）[明細]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = orderConfWork.SalesMoneyTaxExc;		// 売上金額（税抜き）[明細]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = orderConfWork.GrossMarginRateDtl;	// 粗利率[明細]					(Double)//del 2011/12/02 陳建明 Redmine #8316
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfWork.GrossMarginMarkDtl;	// 粗利チェックマーク[明細]		(string)
            //dr[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF] = orderConfWork.PartySlipNumDtl;		// 相手先伝票番号（得意先注文番号）[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdDtlRF] = orderConfWork.SalesSlipCdDtl;			//売上伝票区分[明細]
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = orderConfWork.SalesMoneyTaxExc;		//売上金額（税抜き）[明細] // DEL caohh 2011/08/11
            // ------ ADD caohh 2011/08/11 ------>>>>>
            // 金額 = 数量*売上単価
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = cnt * orderConfWork.SalesUnPrcTaxExcFl;		//売上金額（税抜き）[明細]
            // ------ ADD caohh 2011/08/11 ------<<<<<
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl] = orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc;//消費税
            dr[DCHNB02014EA.CT_OrderConf_SalesUnitCostRF] = orderConfWork.SalesUnitCost;			//原価単価           
            //add 2011/12/02 陳建明 Redmine #8316----->>>>>>
            //未計上 原価＝原価＊貸出残数
            //計上 原価＝原価＊（数量‐貸出残数）
            if (this._printDiv == 4 || this._printDiv == 2)
            {
                dr[DCHNB02014EA.CT_OrderConf_CostRF] = cnt * orderConfWork.SalesUnitCost;							//原価金額
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_CostRF] = orderConfWork.Cost;								//原価金額
            }
            //add 2011/12/02 陳建明 Redmine #8316-----<<<<<<
            //dr[DCHNB02014EA.CT_OrderConf_CostRF] = orderConfWork.Cost;								//原価金額//del 2011/12/02 陳建明 Redmine #8316
            // 2008.07.25 30413 犬飼 不要カラムの削除 >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_UnitNameRF] = orderConfWork.UnitName;						//単位名称
            // 2008.07.25 30413 犬飼 [共通]の項目追加 <<<<<<END
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl] = this.GetSalesSlipNmDtl(orderConfWork.SalesSlipCdDtl);//売上伝票区分名

            // 2008.11.27 30413 犬飼 印刷項目の追加 >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_ListPriceTaxExcFl] = orderConfWork.ListPriceTaxExcFl;
            // 2008.11.27 30413 犬飼 印刷項目の追加 <<<<<<END

            // （明細）：『売上』/『返品』判断。
            //カウント、売上額・返品額、原価金額、消費税の計算。帳票のプロパティで合計させる。
            switch (orderConfWork.SalesSlipCdDtl)
            {
                case 0:	//売上
                    {
                        //『売上』売上金額（税抜き）[明細]
                        //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = orderConfWork.SalesMoneyTaxExc;// DEL caohh 2011/08/11
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = cnt * orderConfWork.SalesUnPrcTaxExcFl; // ADD 2011/08/11

                        // 原価金額計（売上）[明細]			
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = orderConfWork.Cost;//del 2011/12/02 陳建明 Redmine #8316

                        //add 2011/12/02 陳建明 Redmine #8316----->>>>>>
                        //未計上 原価＝原価＊貸出残数
                        //計上 原価＝原価＊（数量‐貸出残数）
                        if (this._printDiv == 4 || this._printDiv == 2)
                        {
                            // 原価金額計（売上）[明細]			
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_CostRF]);
                        }
                        else
                        {
                            // 原価金額計（売上）[明細]			
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = orderConfWork.Cost;
                        }
                        //add 2011/12/02 陳建明 Redmine #8316-----<<<<<<

                        //消費税（）[明細]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 犬飼 [明細]の項目追加 >>>>>>START
                        // 売上合計粗利(明細)
                        //dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);//del 2011/12/02 陳建明 Redmine #8316
                        //add 2011/12/02 陳建明 Redmine #8316----->>>>>>
                        ////粗率：金額　‐　原価
                        if (this._printDiv == 4 || this._printDiv == 2)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (cnt * orderConfWork.SalesUnPrcTaxExcFl - cnt * orderConfWork.SalesUnitCost);
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        }
                        //add 2011/12/02 陳建明 Redmine #8316-----<<<<<<
                        // 2008.07.28 30413 犬飼 [明細]の項目追加 <<<<<<END

                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 >>>>>>START
                        // 売上合計消費税(明細)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = salesDtlTax;
                            // 値引き合計消費税(明細)
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // 上記以外
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 <<<<<<END

                        break;
                    }

                case 1:	//返品
                    {
                        //返品金額（売上伝票合計[税抜き]-売上値引き金額計[税抜き]）[伝票]
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoneyRtnDtl] = orderConfWork.SalesMoneyTaxExc;

                        // 原価金額計（返品）[明細]				
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = orderConfWork.TotalCost;//del 2011/12/18 陳建明 Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = orderConfWork.Cost;//add 2011/12/18 陳建明 Redmine #8316
                        //消費税（返品）[明細]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 >>>>>>START
                        // 返品合計粗利(明細)
                        dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        // 2008.07.28 30413 犬飼 [明細]の項目追加 <<<<<<END

                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 >>>>>>START
                        // 返品合計消費税(明細)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                            dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = salesDtlTax;
                            // 値引き合計消費税(明細)
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // 上記以外
                            dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 <<<<<<END

                        break;
                    }
                case 2:	//値引
                    {
                        //『値引』金額[明細]
                        dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcDtl] = orderConfWork.SalesDisTtlTaxExc;

                        //// 『値引』原価金額[明細]				
                        //dr[DCHNB02014EA.CT_OrderConf_TotalDisCostRtnDtl] = orderConfWork.TotalCost;

                        //『値引』消費税[明細]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxDisDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 犬飼 [伝票]の項目追加 >>>>>>START
                        // 値引き合計原価金額(税抜き)(明細)
                        dr[DCHNB02014EA.CT_OrderConf_DistDtlCost] = (orderConfWork.Cost);

                        // 値引き合計粗利(明細)
                        dr[DCHNB02014EA.CT_OrderConf_DistGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        // 2008.07.28 30413 犬飼 [明細]の項目追加 <<<<<<END

                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 >>>>>>START
                        // 値引き合計消費税(明細)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // 消費税転嫁方式が"0:伝票"かつ明細行が1行目
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                            if (orderConfWork.SalesSlipCd == 0)
                            {
                                // 売上伝票区分が"0:売上"
                                dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = salesDtlTax;
                            }
                            else if (orderConfWork.SalesSlipCd == 1)
                            {
                                // 売上伝票区分が"1:返品"
                                dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = salesDtlTax;
                            }
                        }
                        else
                        {
                            // 上記以外
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 犬飼 小計部の消費税を追加 <<<<<<END

                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 >>>>>>START
                        //// 2008.12.09 30413 犬飼 [伝票]の項目追加 >>>>>>START
                        //// 値引きの設定

                        //// 値引き合計原価金額(伝票)
                        //dr[DCHNB02014EA.CT_OrderConf_DistCost] = (orderConfWork.TotalCost);

                        //// 値引き合計粗利(伝票)
                        //dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = (orderConfWork.SalesDisTtlTaxExc - orderConfWork.Cost);
                        //// 2008.12.09 30413 犬飼 [伝票]の項目追加 <<<<<<END
                        // 2009.01.23 30413 犬飼 値引の粗利計算を変更 <<<<<<END

                        break;
                    }
            }

            // 2008.07.25 30413 犬飼 [明細]の項目追加 >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = orderConfWork.SupplierCd;                        // 仕入先コード[明細](Int32)
            if (orderConfWork.SupplierCd == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = orderConfWork.SupplierCd.ToString("d06");                       // 仕入先コード[明細](Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SupplierSnm] = orderConfWork.SupplierSnm;                      // 仕入先略称[明細](string)
            //dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = orderConfWork.SupplierSlipNo;                // 仕入伝票番号[明細] (Int32)
            if (orderConfWork.SupplierSlipNo == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = orderConfWork.SupplierSlipNo.ToString();               // 仕入伝票番号[明細] (Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_WarehouseCode] = orderConfWork.WarehouseCode;                  // 倉庫コード[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_WarehouseName] = orderConfWork.WarehouseName;                  // 倉庫名称[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_BusinessTypeCode] = orderConfWork.BusinessTypeCode;            // 業種コード[明細](Int32)
            dr[DCHNB02014EA.CT_OrderConf_BusinessTypeName] = orderConfWork.BusinessTypeName;            // 業種名称[明細](string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesCode] = orderConfWork.SalesCode;                          // 販売区分コード[明細](Int32)
            if (orderConfWork.SalesCode == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesCode] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesCode] = orderConfWork.SalesCode.ToString("d04");                         // 販売区分コード (Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SalesCdNm] = orderConfWork.SalesCdNm;                          // 販売区分名称[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_ModelFullName] = orderConfWork.ModelFullName;                  // 車種全角名称[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_FullModel] = orderConfWork.FullModel;                          // 型式（フル型）[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_ModelDesignationNo] = orderConfWork.ModelDesignationNo;        // 型式指定番号[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_CategoryNo] = orderConfWork.CategoryNo;                        // 類別番号[明細](Int32)
            // 2008.11.27 30413 犬飼 車両管理コードと初年度の印字設定を売上確認表と同様に変更 >>>>>>START
            //if (orderConfWork.CarMngCode != "")
            //{
            //    // 車両管理コードが設定されている
            //    dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = orderConfWork.CarMngCode;                    // 車輌管理コード[明細](string)
            //    dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", orderConfWork.FirstEntryDate);     // 初年度[明細](String)
            //}
            //else
            //{
            //    //　車両管理コードが未設定
            //    dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = "";                                          // 車輌管理コード[明細](string)
            //    dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = "";                                      // 初年度[明細](String)
            //}
            dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = orderConfWork.CarMngCode;                        // 車輌管理コード[明細](string)
            dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", orderConfWork.FirstEntryDate);     // 初年度[明細](String)
            // 2008.11.27 30413 犬飼 車両管理コードと初年度の印字設定を売上確認表と同様に変更 <<<<<<END
            dr[DCHNB02014EA.CT_OrderConf_SlipNote2] = orderConfWork.SlipNote2;                          // 伝票備考２[明細](string)

            // 2008.12.08 30413 犬飼 備考３を追加 >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_SlipNote3] = orderConfWork.SlipNote3;                          // 伝票備考３[明細](string)
            // 2008.12.08 30413 犬飼 備考３を追加 <<<<<<END

            //dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = orderConfWork.BLGoodsCode;                      // BL商品コード[明細](Int32)
            if (orderConfWork.BLGoodsCode == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = orderConfWork.BLGoodsCode.ToString("d05");                     // BL商品コード[明細](Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivCd] = orderConfWork.SalesOrderDivCd;              // 売上在庫取寄せ区分(Int32)
            // 2008.07.25 30413 犬飼 [明細]の項目追加 <<<<<<END

            // 売上伝票区分名称の設定
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipName] = orderConfWork.TransactionName;       // 取引区分名[伝票]でOK？

            // 類別(明細)の設定
            if ((orderConfWork.ModelDesignationNo != 0) || (orderConfWork.CategoryNo != 0))
            {
                // 型式指定番号と類別番号がゼロ以外の場合
                dr[DCHNB02014EA.CT_OrderConf_CategoryDtl] = orderConfWork.ModelDesignationNo.ToString("d05") + "-" + orderConfWork.CategoryNo.ToString("d04");
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_CategoryDtl] = "";
            }

            // 売上在庫取寄せ区分名称の設定
            if (orderConfWork.SalesOrderDivCd == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivName] = "取寄";
            }
            else if (orderConfWork.SalesOrderDivCd == 1)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivName] = "在庫";
            }

            // 2009.01.27 30413 犬飼 消費税の計算位置を変更 >>>>>>START
            //// 消費税の設定
            ////dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);        //DEL 2008/10/31 条件によって変化する為
            //// --- ADD 2008/10/31 ---------------------------------------------------------------------->>>>>
            //if ((this._printDiv == 1) || (this._printDiv == 3))
            //{
            //    // 伝票単位に出力時

            //    // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
            //    if ((orderConfWork.ConsTaxLayMethod == 2) ||
            //        (orderConfWork.ConsTaxLayMethod == 3) ||
            //        (orderConfWork.ConsTaxLayMethod == 9))
            //    {
            //        // 消費税
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
            //        // 合計金額
            //        dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
            //                                                                + (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
            //    }
            //    // 消費税転嫁方式　0：伝票単位、1：明細単位
            //    else
            //    {
            //        // 消費税
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
            //        // 合計金額
            //        dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
            //                                                                + (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
            //    }
            //}
            //else
            //{
            //    // 明細単位に出力時

            //    // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
            //    if ((orderConfWork.ConsTaxLayMethod == 2) ||
            //        (orderConfWork.ConsTaxLayMethod == 3) ||
            //        (orderConfWork.ConsTaxLayMethod == 9))
            //    {
            //        // 課税区分　2：内税
            //        if (orderConfWork.TaxationDivCd == 2)
            //        {
            //            // 消費税
            //            dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
            //        }
            //        // 課税区分　0：課税、1：非課税
            //        else
            //        {
            //            // 消費税
            //            dr[DCHNB02014EA.CT_OrderConf_Tax] = DBNull.Value;
            //        }
            //    }
            //    // 消費税転嫁方式　0：伝票単位、1：明細単位
            //    else
            //    {
            //        // 消費税
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
            //    }
            //}
            //dr[DCHNB02014EA.CT_OrderConf_ConsTaxLayMethod] = orderConfWork.ConsTaxLayMethod;        // 消費税転嫁方式
            //dr[DCHNB02014EA.CT_OrderConf_TaxationDivCd] = orderConfWork.TaxationDivCd;              // 課税区分
            //// --- ADD 2008/10/31 ----------------------------------------------------------------------<<<<<
            // 2009.01.27 30413 犬飼 消費税の計算位置を変更 <<<<<<END

            // 粗利(税抜き)(伝票)の設定
            //dr[DCHNB02014EA.CT_OrderConf_GrossProfit] = (orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost);//del 2011/12/02 陳建明 Redmine #8316

            // 粗利(税抜き)(明細)の設定
            //dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);//del 2011/12/02 陳建明 Redmine #8316

            //add 2011/12/02 陳建明 Redmine #8316----->>>>>>
            //粗率：金額　‐　原価
            if (this._printDiv == 4 || this._printDiv == 2)
            {
                // 粗利(税抜き)(明細)の設定
                dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (cnt * orderConfWork.SalesUnPrcTaxExcFl - cnt * orderConfWork.SalesUnitCost);
            }
            else
            {
                // 粗利(税抜き)(明細)の設定
                dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
            }
            //add 2011/12/02 陳建明 Redmine #8316-----<<<<<
        }

        /// <summary>
        /// データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            //[共通]
            dr[DCHNB02014EA.CT_OrderConf_SectionCode] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SectionCode];			// 拠点コード				(string)
            dr[DCHNB02014EA.CT_OrderConf_SectionGuideNm] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SectionGuideNm];			// 拠点ガイド名称			(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDateRF];            // 売上日付					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ShipmentDayRF];          // 出荷日付					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerCodeRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CustomerCodeRF];         // 得意先コード				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerSnmRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CustomerSnmRF];			// 得意先名称				(string)
            dr[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF];			// 相手先伝票番号[共通]		(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF];			// 販売従業員コード			(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF];			// 販売従業員名称			(string)
            dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF];				// 入力日付[共通]			(DateTime)
            dr[DCHNB02014EA.CT_OrderConf_SalesInputNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesInputNameRF];				//売上入力者名称[共通]		(string)
            //[伝票]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF];					// 売上伝票番号				(string)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostSl];						// 原価金額計（純売上）[伝票]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRF];						// 原価金額計（売上）[伝票]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRtn];						// 原価金額計（返品）[伝票]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginRate];				// 粗利率[伝票]				(Double)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip];		// 粗利チェックマーク[伝票]	(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF];		//売上伝票合計(税抜)[伝票]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF];			//売上伝票合計(税抜)[伝票]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF];			//売上伝票合計(税込)[伝票]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlip];						//消費税（売上）[伝票]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TransactionNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TransactionNameRF];			// 取引区分名[伝票]			(string)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip];					//消費税（売上）[伝票]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip];					//消費税（返品）[伝票]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney];				//返品額[伝票](Int64)		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF];					//売上伝票区分[伝票]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF];		// 売上値引金額計(税抜)[伝票](Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF];	// 売上値引金額計(税込)[伝票](Int64)
            dr[DCHNB02014EA.CT_OrderConf_CntSales] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CntSales];								//売上数[伝票]
            dr[DCHNB02014EA.CT_OrderConf_CntReturn] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CntReturn];							//返品数[伝票]
            //[明細]
            dr[DCHNB02014EA.CT_OrderConf_GoodsNoRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GoodsNoRF];				// 商品番号					(string)
            dr[DCHNB02014EA.CT_OrderConf_GoodsNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GoodsNameRF];            // 商品名称					(string)
            dr[DCHNB02014EA.CT_OrderConf_MakerNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_MakerNameRF];            // メーカー名				(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesRowNoRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesRowNoRF];           // 売上行番号				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentCntRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ShipmentCntRF];          // 出荷数（数量）[明細]		(double)
            dr[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF];	// 売上単価(税抜)[明細]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF]	 = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF];		// 売上金額（税込み）		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF];     // 売上金額（税抜）		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl];		// 粗利率[明細]				(Double)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl];		// 粗利チェックマーク[明細]	(string)
            //dr[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF]		 = sourceDataRow[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF];		// 相手先伝票番号[明細]		(string)
            //dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];						//消費税（売上）[明細]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl];						//消費税（売上）[明細]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl];			//消費税（返品）[明細]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_CostRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CostRF];									// 原価金額[明細]			(Int64)			
            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostDtl];						// 原価金額計（売上）[明細]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl];				// 原価金額計（返品）[明細]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_UnitNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_UnitNameRF];							//単位名称
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl];					//売上伝票区分名
        }

        /// <summary>
        /// 『行区分』（売上伝票区分[明細]）名称化処理
        /// </summary>
        private string GetSalesSlipNmDtl(int salesSlipCdDtl)
        {
            string wkStr = "";

            switch (salesSlipCdDtl)
            {
                case 0:
                    {
                        wkStr = "";		//"売上"の場合は表示させない
                        break;
                    }
                case 1:
                    {
                        wkStr = "返品";
                        break;
                    }
                case 2:
                    {
                        wkStr = "値引";
                        break;
                    }
                case 9:
                    {
                        wkStr = "一式";
                        break;
                    }
            }

            return wkStr;
        }


        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        // --- ADD 2009/01/30 -------------------------------->>>>>
        /// <summary>
        /// 受注残数フィルタ処理
        /// </summary>
        /// <remarks>
        /// <br>受注残数が0件のデータを削除する</br>
        /// </remarks>
        private void FilterByAcptAnOdrRemainCnt(ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            // 伝票番号順にソート
            DataTable copyTable = this._printDataSet.Tables[_SalesConfDataTable].Copy();

            DataRow[] drList = copyTable.Select("", DCHNB02014EA.CT_OrderConf_SalesSlipNumRF);

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            foreach (DataRow sortedRow in drList)
            {
                this._printDataSet.Tables[_SalesConfDataTable].ImportRow(sortedRow);
            }
            // --- DEL 2011/08/11 ----->>>>>
            //// --- ADD 2011/07/21 ----->>>>>
            //// 受注、貸出
            //if (saleConfListCndtn.PublicationType == 0
            //    || saleConfListCndtn.PublicationType == 2)
            //{
            //    bool isOK = false; // 印字対象フラグ
            //    bool falseflag = false;
            //    DataRow dr;
            //    List<int> sameSlipRowIndex = new List<int>();
            //    // 前回処理伝票番号
            //    string beforeSalesSlip = string.Empty;
            //    for (int i = this._printDataSet.Tables[_SalesConfDataTable].Rows.Count - 1; i >= 0; i--)
            //    {
            //        dr = this._printDataSet.Tables[_SalesConfDataTable].Rows[i];

            //        if (dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString() == beforeSalesSlip)
            //        {
            //            // 同じ伝票番号中には、全部データチャックを行う
            //            // チェック
            //            isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);

            //            // 同じ伝票番号中には、一つデータのチャック結果はFalseならば
            //            // 全部同じ伝票番号データ結果リストから削除
            //            if (!isOK)
            //            {
            //                falseflag = true;
            //            }
            //            sameSlipRowIndex.Add(i);
            //        }
            //        else
            //        {
            //            if (beforeSalesSlip != string.Empty
            //                && falseflag)
            //            {
            //                // 削除処理実行
            //                foreach (int delIndex in sameSlipRowIndex)
            //                {
            //                    this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
            //                }
            //                falseflag = false;
            //            }

            //            // 初期化
            //            isOK = false;
            //            sameSlipRowIndex.Clear();
            //            beforeSalesSlip = dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString();

            //            // チェック
            //            isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);
            //            if (!isOK)
            //            {
            //                falseflag = true;
            //            }

            //            sameSlipRowIndex.Add(i);
            //        }

            //        if (i == 0)
            //        {
            //            if (falseflag)
            //            {
            //                // 削除処理実行
            //                foreach (int delIndex in sameSlipRowIndex)
            //                {
            //                    this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
            //                }
            //                falseflag = false;
            //            }
            //        }
            //    }
            //}
            //// --- ADD 2011/07/21 -----<<<<<

            //// 受注計上済、貸出計上済
            //else
            //{
            // --- DEL 2011/08/11 -----<<<<<

            bool isOK = false; // 印字対象フラグ
            DataRow dr;
            List<int> sameSlipRowIndex = new List<int>();
            // 前回処理伝票番号
            string beforeSalesSlip = string.Empty;
            for (int i = this._printDataSet.Tables[_SalesConfDataTable].Rows.Count - 1; i >= 0; i--)
            {
                dr = this._printDataSet.Tables[_SalesConfDataTable].Rows[i];

                if (dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString() == beforeSalesSlip)
                {
                    if (!isOK)
                    {
                        // チェック
                        isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);
                    }

                    sameSlipRowIndex.Add(i);
                }
                else
                {
                    if (beforeSalesSlip != string.Empty
                        && !isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
                        }
                    }

                    // 初期化
                    isOK = false;
                    sameSlipRowIndex.Clear();
                    beforeSalesSlip = dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString();

                    // チェック
                    isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);

                    sameSlipRowIndex.Add(i);
                }

                if (i == 0)
                {
                    if (!isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
                        }
                    }
                }
            }
            //}// DEL 2011/08/11
        }

        /// <summary>
        /// 1明細の受注残数チェック
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="saleConfListCndtn"></param>
        /// <returns></returns>
        private bool CheckByAcptAnOdrRemainCnt(DataRow dr, ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            if (saleConfListCndtn.PublicationType == 0
                || saleConfListCndtn.PublicationType == 2)
            {
                // 受注、貸出
                // 受注残数が0でない
                if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0))// ADD 2011/08/11
                //if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0)) // DEL 2011/07/21
                // --- DEL 2011/08/11 ----->>>>>
                //// --- ADD 2011/07/21 ----->>>>>
                //if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0)
                //    && ((double)dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt]
                //    == (double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt]))
                //// --- ADD 2011/07/21 -----<<<<<
                // --- DEL 2011/08/11 -----<<<<<
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // 受注計上済、貸出計上済
                // 受注数(受注数量+受注調整数)と受注残数が異なる
                if ((double)dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt]
                    != (double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // --- ADD 2009/01/30 -------------------------------->>>>>

        #endregion

    }
}