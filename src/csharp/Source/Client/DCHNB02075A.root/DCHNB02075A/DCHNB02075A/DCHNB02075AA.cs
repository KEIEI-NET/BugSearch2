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
    /// 売上月報年報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上月報年報にアクセスするクラスです</br>
    /// <br>Programer  : 980035　金沢　貞義</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br>Update Note: 2008.03.05 980035 金沢 貞義</br>
    /// <br>			 ・不具合修正（DC.NS対応）</br>
    /// <br>Update Note: 2008.09.08 30452 上野 俊治</br>
    /// <br>			 ・PM.NS対応</br>
    /// <br>Update Note: 2008/10/17       照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009.02.06 30452 上野 俊治</br>
    /// <br>			 ・障害対応10925,10984（ソートの修正）</br>
    /// <br>Update Note: 2009.02.06 30452 上野 俊治</br>
    /// <br>			 ・障害対応10943,10971,11113（拠点計の売上目標取得処理を追加）</br>
    /// <br>Update Note: 2009.02.09 30452 上野 俊治</br>
    /// <br>			 ・障害対応10927,10968（全項目が0のリモート抽出結果を印字対象から除外）</br>
    /// <br>Update Note: 2009/02/24 30452 上野 俊治</br>
    /// <br>			 ・障害対応10927,10968（除外した結果が0件の場合のエラー処理を追加）</br>
    /// <br>Update Note: 2009/03/24 30452 上野 俊治</br>
    /// <br>		     ・障害対応12682</br>
    /// <br>Update Note: 2009/03/27 30452 上野 俊治</br>
    /// <br>		     ・障害対応12682 (返品率を修正)</br>
    /// <br>Update Note: 2010/06/08 呉元嘯 </br>
    /// <br>             障害・改良対応（７月リリース案件）対応</br>
    /// <br>Update Note: 2010/06/22 呉元嘯 </br>
    /// <br>             Redmine#10072対応</br>
    /// <br>Update Note: 2012/05/02 98005 金沢 貞義 </br>
    /// <br>             出力順＝拠点の時の達成率の修正、当期目標金額の集計範囲修正</br>
    /// <br>UpdateNote  : 2013/07/26 duzg</br>
    /// <br>管理番号    : 10801804-00 2013/06/18配信分</br>
    /// <br>            : redmine #38722 </br>
    /// <br>            : ・No.6得意先順の場合、明細と小計の売上・粗利目標値は印字不正</br>
    /// <br>UpdateNote : 2014/02/25 田建委</br>
    /// <br>           : redmine #38722 </br>
    /// <br>           : 地区コードは「0000」の場合、売上目標印字不正</br>
    /// </remarks>
    public class SalesTableAcs
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
        /// <summary>帳票出力設定データクラス</summary>
        private static PrtOutSet prtOutSetData = null;

        #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member

        /// <summary>拠点情報アクセスクラス</summary>
        private static SecInfoAcs _secInfoAcs;
        /// <summary>帳票出力設定アクセスクラス</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>印刷用DataSet</summary>
        public DataSet _printDataSet;
        /// <summary>バッファDataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>売上月報年報データテーブル名</summary>
        private string _Tbl_MonthYearReportDtl;

        /// <summary>表示順位</summary>
        //private string CT_Sort1_Odr = "CustomerCode";                    // DEL 2008/09/08
        //private string CT_Sort2_Odr = "SalesAreaCode, CustomerCode";     // DEL 2008/09/08
        //private string CT_Sort3_Odr = "BusinessTypeCode, CustomerCode";  // DEL 2008/09/08

        //private string CT_UpperOrder = " ASC";   // 昇順出力  // DEL 2008/09/08
        //private string CT_DownOrder  = " DESC";  // 降順出力

        //private string ListTitle = "売上月報年報";    // 帳票タイトル

        private Dictionary<string, DataRow> _totalPriceDic = new Dictionary<string, DataRow>();

        // 順位付け用
        List<Int64> PureSalesTtlPrice = new List<Int64>();
        List<Int64> GrossProfitList = new List<Int64>();
        List<Int64> RetGoodsTtlPrice = new List<Int64>();

        // --- ADD 2009/02/06 -------------------------------->>>>>
        // 売上目標取得済拠点リスト
        private List<string> _salesTargetFinSecList;

        // 売上目標アクセス
        private SalesTargetAcs _salesTargetAcs;
        // 年度取得部品
        private DateGetAcs _dateGetAcs;
        // 月度開始日リスト
        List<DateTime> _startMonthDateList;
        // 月度締日リスト
        List<DateTime> _endMonthDateList;
        // --- ADD 2009/02/06 --------------------------------<<<<<
        // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
        // 売上目標(得意先)取得済キーリスト
        private List<string> _salesTargetFinCustList;
        // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<
        #endregion

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        ///// <summary>売上月報年報バッファデータテーブル名</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.DCHNB02074EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター

        /// <summary>
        /// 売上月報年報アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public SalesTableAcs()
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
        /// 売上月報年報アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static SalesTableAcs()
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
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
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
        /// 売上月報年報データ初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static情報を初期化します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --テーブル行初期化-----------------------
            // 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[_Tbl_MonthYearReportDtl] != null)
            {
                this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Clear();
            }
            // 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_Tbl_MonthYearReportDtl] != null)
            {
                _printBuffDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Clear();
            }
        }

        /// <summary>
        /// 売上月報年報データ取得処理
        /// </summary>
        /// <param name="salesMonthYearReportCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
        public int Search(SalesMonthYearReportCndtn salesMonthYearReportCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(salesMonthYearReportCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(salesMonthYearReportCndtn, out message);
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
        /// 売上月報年報スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Clear();

            if (_printBuffDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].NewRow();
                        buffDr = _printBuffDataSet.Tables[_Tbl_MonthYearReportDtl].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Add(dr);
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
        /// 売上月報年報データ取得処理
        /// </summary>
        /// <param name="salesMonthYearReportCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の売上月報年報データを取得します。</br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// <br>Update Note: 2010/06/08 呉元嘯 ＵＩで指定した、順位以外のデータが印刷されてしまう不具合の対応</br>
        /// <br>Update Note: 2010/06/22 呉元嘯 Redmine#10072対応</br>
        /// </remarks>
        private int Search(SalesMonthYearReportCndtn salesMonthYearReportCndtn, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            //--- ADD 2008.08.14 ---------->>>>>
            DataRow dr;
            object retObj;
            Comparer<Int64> comparer = AnalysisOrderComparerCreater.GetComparer(salesMonthYearReportCndtn);
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
            _salesTargetFinCustList = new List<string>();
            // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<
            _salesTargetFinSecList = new List<string>(); // ADD 2009/02/06

            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                SalesMonthYearReportParamWork salesListParamWork = new SalesMonthYearReportParamWork();
                // 抽出条件パラメータセット
                this.SearchParaSet(salesMonthYearReportCndtn, ref salesListParamWork);

                status = this.SearchByMode(out retObj, salesListParamWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                // テスト用
                //status = testProc(ref retList, salesMonthYearReportCndtn);


                if ((status == 0) && (retList.Count != 0))
                {
                    // --- ADD 2009/02/09 -------------------------------->>>>>
                    // 全項目0の明細を印字対象外にする。
                    this.RemoveAllZero(retList);
                    // --- ADD 2009/02/09 --------------------------------<<<<<
                    // --- ADD 2009/02/24 -------------------------------->>>>>
                    if (retList.Count == 0)
                    {
                        return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // --- ADD 2009/02/24 --------------------------------<<<<<

                    // 構成比算出用合計値取得
                    GetTotalPrice(retList, salesMonthYearReportCndtn);

                    // 情報取得
                    for (int i = 0; i < retList.Count; i++)
                    {
                        SetTebleRowFromRetList(retList, i, salesMonthYearReportCndtn);
                    }

                    //--- ADD 2008.08.14 ---------->>>>>
                    #region 順位付け処理 (全社)
                    // チャート表示でも使用する為、アクセスクラスで順位を設定する必要がある。
                    // ソート (ソートすると、(index+1)が順位になる)
                    PureSalesTtlPrice.Sort(comparer);
                    GrossProfitList.Sort(comparer);
                    RetGoodsTtlPrice.Sort(comparer);

                    // 各レコードに順位をセット
                    for (int index = 0; index < this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Count; index++)
                    {
                        dr = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows[index];

                        if (salesMonthYearReportCndtn.OrderAppointment == SalesMonthYearReportCndtn.OrderAppointmentDivState.GrossProfit)
                        {
                            // --------UPD 2010/06/22--------->>>>>
                            //if (GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_GrossProfitPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                            //{
                            //    if (salesMonthYearReportCndtn.PrintType != 1)
                            //    {
                            //        // 順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_GrossProfitPrice]) + 1;      // 粗利額順位
                            //    }
                            //    else
                            //    {
                            //        // 順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice]) + 1;      // 粗利額順位 
                            //    }
                            //}
                            if (salesMonthYearReportCndtn.PrintType != 1)
                            {
                                if (GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_GrossProfitPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_GrossProfitPrice]) + 1;     // 粗利額順位
                                }
                            }
                            else
                            {
                                if (GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = GrossProfitList.IndexOf((Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice]) + 1;     // 粗利額順位
                                }
                            }
                            // --------UPD 2010/06/22---------<<<<<
                        }
                        else if (salesMonthYearReportCndtn.OrderAppointment == SalesMonthYearReportCndtn.OrderAppointmentDivState.Sales)
                        {
                            // --------UPD 2010/06/22--------->>>>>
                            //if (PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                            //{
                            //    if (salesMonthYearReportCndtn.PrintType != 1)
                            //    {
                            //        // 順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice]) + 1;   // 純売上額順位
                            //    }
                            //    else
                            //    {
                            //        // 順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice]) + 1;   // 純売上額順位
                            //    }
                            //}
                            if (salesMonthYearReportCndtn.PrintType != 1)
                            {
                                if (PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice]) + 1;     // 純売上額順位
                                }
                            }
                            else
                            {
                                if (PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = PureSalesTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice]) + 1;     // 純売上額順位
                                }
                            }
                            // --------UPD 2010/06/22---------<<<<<
                        }
                        else
                        {
                            // --------UPD 2010/06/22--------->>>>>
                            //if (RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                            //{
                            //    if (salesMonthYearReportCndtn.PrintType != 1)
                            //    {
                            //        //順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice]) + 1;     // 返品額順位
                            //    }
                            //    else
                            //    {
                            //        //順位のセット
                            //        dr[DCHNB02074EA.CT_Order] = RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice]) + 1;     // 返品額順位
                            //    }
                            //}
                            if (salesMonthYearReportCndtn.PrintType != 1)
                            {
                                if (RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice]) + 1;     // 返品額順位
                                }
                            }
                            else
                            {
                                if (RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice]) + 1 <= salesMonthYearReportCndtn.OrderRange)
                                {
                                    // 順位のセット
                                    dr[DCHNB02074EA.CT_Order] = RetGoodsTtlPrice.IndexOf((Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice]) + 1;     // 返品額順位
                                }
                            }
                            // --------UPD 2010/06/22---------<<<<<
                        }
                    }
                    #endregion
                    //--- ADD 2008.08.14 ----------<<<<<

                    // --- ADD 2008/09/08 -------------------------------->>>>>
                    #region 順位付け処理 (小計毎)
                    // 順位付が小計毎でなければ処理なし
                    if (salesMonthYearReportCndtn.OrderUnit == 1)
                    {
                        // 得意先別の出力順"拠点"、販売区分別の集計方法"全社"の場合、全社の順位と同じになるため処理なし
                        if (!(salesMonthYearReportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer
                            && salesMonthYearReportCndtn.PrintingPattern == 1)
                            && !(salesMonthYearReportCndtn.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision
                            && salesMonthYearReportCndtn.PrintingPattern == 1))
                        {
                            // 順位付範囲が1未満の場合は処理なし
                            if (salesMonthYearReportCndtn.OrderRange >= 1)
                            {
                                // 小計の1つ上の列名
                                string subTotalColName = "";
                                // xx別、出力順"得意先"用 Sort文字列
                                string sortString = "";

                                switch (salesMonthYearReportCndtn.TotalType)
                                {
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先
                                        {
                                            // 印字パターン1は到達しない
                                            if (salesMonthYearReportCndtn.PrintingPattern == 0)
                                            {
                                                subTotalColName = DCHNB02074EA.CT_SectionCode;
                                            }
                                            else
                                            {
                                                subTotalColName = DCHNB02074EA.CT_Code;
                                            }
                                            break;
                                        }
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                                        {
                                            if (salesMonthYearReportCndtn.PrintingPattern == 0)
                                            {
                                                subTotalColName = DCHNB02074EA.CT_SectionCode;
                                            }
                                            else if (salesMonthYearReportCndtn.PrintingPattern == 1)
                                            {
                                                subTotalColName = DCHNB02074EA.CT_Code;
                                                // 拠点、codeでのソートが必要
                                                sortString = DCHNB02074EA.CT_SectionCode + ", ";
                                            }
                                            else if (salesMonthYearReportCndtn.PrintingPattern == 2)
                                            {
                                                subTotalColName = DCHNB02074EA.CT_Code;
                                            }

                                            break;
                                        }
                                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                                        {
                                            subTotalColName = DCHNB02074EA.CT_SectionCode;
                                            break;
                                        }
                                }

                                #region 順位指定対象列 (順売上、粗利、返品額)
                                string orderColumn = "";

                                if (salesMonthYearReportCndtn.OrderAppointment == SalesMonthYearReportCndtn.OrderAppointmentDivState.Sales)
                                {
                                    // 当期でなければ当月で順位付
                                    if (salesMonthYearReportCndtn.PrintType != 1)
                                    {
                                        orderColumn = DCHNB02074EA.CT_PureSalesTtlPrice;
                                    }
                                    else
                                    {
                                        orderColumn = DCHNB02074EA.CT_AnPureSalesTtlPrice;
                                    }
                                }
                                else if (salesMonthYearReportCndtn.OrderAppointment == SalesMonthYearReportCndtn.OrderAppointmentDivState.GrossProfit)
                                {
                                    // 当期でなければ当月で順位付
                                    if (salesMonthYearReportCndtn.PrintType != 1)
                                    {
                                        orderColumn = DCHNB02074EA.CT_GrossProfitPrice;
                                    }
                                    else
                                    {
                                        orderColumn = DCHNB02074EA.CT_AnGrossProfitPrice;
                                    }
                                }
                                else if (salesMonthYearReportCndtn.OrderAppointment == SalesMonthYearReportCndtn.OrderAppointmentDivState.SalesRetGoods)
                                {
                                    // 当期でなければ当月で順位付
                                    if (salesMonthYearReportCndtn.PrintType != 1)
                                    {
                                        orderColumn = DCHNB02074EA.CT_RetGoodsTtlPrice;
                                    }
                                    else
                                    {
                                        orderColumn = DCHNB02074EA.CT_AnRetGoodsTtlPrice;
                                    }
                                }
                                #endregion

                                // 小計毎の同順位カウンタ
                                int subTotalOrderCounter = 1;

                                // 小計、全社順位でSortしたDataRow配列を取得
                                // 順位がついていない行もあるので、順位指定対象列もsort条件に含める
                                string orderby;
                                if (salesMonthYearReportCndtn.OrderMethod == 0)
                                {
                                    orderby = "DESC";
                                }
                                else
                                {
                                    orderby = "ASC";
                                }

                                DataRow[] sortedRows = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Select("",
                                    sortString + subTotalColName + ", " + DCHNB02074EA.CT_Order + " ASC, " + orderColumn + " " + orderby);

                                // テーブル定義のコピー
                                DataTable orderedDT = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Clone();

                                for (int i = 0; i < sortedRows.Length; i++)
                                {
                                    dr = sortedRows[i];

                                    // 1行目か、小計値が前行と違うか。
                                    // 2つ目の条件は担当者別等の印字パターン2(拠点とコードの2つを見る必要がある。)
                                    //if (i == 0 || dr[subTotalColName].ToString() != sortedRows[i - 1][subTotalColName].ToString()) // DEL 2008/10/06
                                    if (i == 0
                                        || (sortString != ""
                                            && (dr[DCHNB02074EA.CT_SectionCode].ToString() != sortedRows[i - 1][DCHNB02074EA.CT_SectionCode].ToString()
                                                || dr[subTotalColName].ToString() != sortedRows[i - 1][subTotalColName].ToString()))
                                        || dr[subTotalColName].ToString() != sortedRows[i - 1][subTotalColName].ToString()) // ADD 2008/10/06
                                    {
                                        // 違う場合は別小計なので1位
                                        dr[DCHNB02074EA.CT_Order] = 1;
                                        // 同順位カウンタ初期化
                                        subTotalOrderCounter = 1;
                                    }
                                    else
                                    {
                                        // 前の順位付対象列値との比較
                                        if (dr[orderColumn].ToString() == sortedRows[i - 1][orderColumn].ToString())
                                        {
                                            // 同じ場合は同順位(同順位の場合、範囲チェックは必要ない)
                                            dr[DCHNB02074EA.CT_Order] = sortedRows[i - 1][DCHNB02074EA.CT_Order];
                                            // 同順位カウンタ加算
                                            subTotalOrderCounter += 1;
                                        }
                                        else
                                        {
                                            // 順位範囲チェック
                                            if (salesMonthYearReportCndtn.OrderRange >= (int)sortedRows[i - 1][DCHNB02074EA.CT_Order] + subTotalOrderCounter)
                                            {
                                                // 前の順位＋同順位カウンタ(1位が2つあれば、次は3位)
                                                dr[DCHNB02074EA.CT_Order] = (int)sortedRows[i - 1][DCHNB02074EA.CT_Order] + subTotalOrderCounter;
                                            }
                                            else
                                            {
                                                // 順位範囲を超えた場合は初期値を設定
                                                dr[DCHNB02074EA.CT_Order] = "10000000";
                                            }

                                            // 同順位カウンタ初期化
                                            subTotalOrderCounter = 1;
                                        }
                                    }

                                    // 再順位付したRowをDataTableに追加
                                    orderedDT.ImportRow(dr);
                                }

                                // データセットのテーブル入替
                                this._printDataSet.Tables.Remove(_Tbl_MonthYearReportDtl);
                                this._printDataSet.Tables.Add(orderedDT);
                            }
                        }
                    }

                    #endregion
                    // --- ADD 2008/09/08 --------------------------------<<<<<

                    // --------ADD 2010/06/08--------->>>>>
                    // テーブル定義
                    DataTable dtCopy = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Clone();
                    DataSet dsCopy = new DataSet();
                    // 画面設定した順位
                    int st = 0;
                    //順位以外のデータが印刷しない
                    for (int index = 0; index < this._printDataSet.Tables[0].Rows.Count; index++)
                    {
                        dr = this._printDataSet.Tables[0].Rows[index];
                        st = (int)dr[DCHNB02074EA.CT_Order];
                        if (st <= salesMonthYearReportCndtn.OrderRange)
                        {
                            dtCopy.ImportRow(dr);
                        }
                    }

                    if (dtCopy.Rows.Count > 0)
                    {
                        // データセットのテーブル入替
                        dsCopy.Tables.Add(dtCopy);
                        this._printDataSet = dsCopy.Copy();
                    }
                    // --------ADD 2010/06/08---------<<<<<
                    this._printDataSet.AcceptChanges();

                    // バッファテーブルへの格納
                    _printBuffDataSet = this._printDataSet.Copy();

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;

            #region ************* 仮データ ***************
            /*
            for (int i = 0; i < 5; i++)
            {
                Int64 totalPrice = 0;
                Int64 retGoodsPrice = 0;
                Int64 discountPrice = 0;
                int moneyUnit = 1;

                DataRow dr;
                dr = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].NewRow();

                dr[DCHNB02074EA.CT_SectionCode]    = "000001";        // 拠点コード
                dr[DCHNB02074EA.CT_SectionName]    = "テスト拠点";    // 拠点ガイド名称
                dr[DCHNB02074EA.CT_SubSectionCode] = 1; // 部門コード
                dr[DCHNB02074EA.CT_SubSectionName] = "テスト部署０１"; // 部門名称
                dr[DCHNB02074EA.CT_MinSectionCode] = 1; // 課コード
                dr[DCHNB02074EA.CT_MinSectionName] = "テスト課０１"; // 課名称
                dr[DCHNB02074EA.CT_EmployeeCode]   = "000000001"; // 従業員コード
                dr[DCHNB02074EA.CT_EmployeeName]   = "テスト担当者００００００００１";    // 従業員名称
                dr[DCHNB02074EA.CT_CustomerCode]   = 1;    // 得意先コード
                dr[DCHNB02074EA.CT_CustomerName]   = "テスト得意先０００００１";      // 得意先名称
                dr[DCHNB02074EA.CT_GoodsMakerCd]   = 1;      // 商品メーカーコード
                dr[DCHNB02074EA.CT_MakerName]      = "テストメーカー名称０００００１";   // メーカー名称

                switch (salesMonthYearReportCndtn.TotalType)
                {
                    case 0: // 拠点別
                        {
                            //dr[DCHNB02074EA.CT_RecordTitle] = "拠点";                       // 明細タイトル
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SectionCode]; 
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SectionName]; 
                            break;
                        }
                    case 1: // 得意先別
                        {
                            //dr[DCHNB02074EA.CT_RecordTitle] = "得意先";                     // 明細タイトル
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_CustomerCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_CustomerName];
                            break;
                        }
                    case 2: // 担当者別
                        {
                            //dr[DCHNB02074EA.CT_RecordTitle] = "担当者";                     // 明細タイトル
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_EmployeeCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_EmployeeName];
                            break;
                        }
                    case 3: // 部署別
                        {
                            //dr[DCHNB02074EA.CT_RecordTitle] = "課";                         // 明細タイトル
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_MinSectionCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_MinSectionName];
                            break;
                        }
                    case 4: // メーカー別
                    case 5: // 得意先別メーカー別
                        {
                            //dr[DCHNB02074EA.CT_RecordTitle] = "メーカー";                   // 明細タイトル
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_GoodsMakerCd];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_MakerName];   
                            break;
                        }
                }

                // 金額単位
                if (salesMonthYearReportCndtn.MoneyUnit == 1) moneyUnit = 1000;


                totalPrice = 8888888 / moneyUnit;
                dr[DCHNB02074EA.CT_StockTtlPrice] = totalPrice;                                   // 月間売上金額合計

                retGoodsPrice = 3333333 / moneyUnit;
                dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = retGoodsPrice;                                // 月間返品額

                discountPrice = 2222222 / moneyUnit;
                dr[DCHNB02074EA.CT_DiscountTtlPrice] = discountPrice;                                // 月間値引額

                dr[DCHNB02074EA.CT_PureStockTtlPrice] = totalPrice + retGoodsPrice + discountPrice;   // 月間純売上額

                // 月間返品率
                if (totalPrice == 0)
                {
                    dr[DCHNB02074EA.CT_RetGoodsTtlRate] = 0.00;
                }
                else
                {
                    dr[DCHNB02074EA.CT_RetGoodsTtlRate] = ((double)retGoodsPrice / (double)totalPrice) * 100;
                }

                // 月間値引率
                if (totalPrice == 0)
                {
                    dr[DCHNB02074EA.CT_DiscountTtlRate] = 0.00;
                }
                else
                {
                    dr[DCHNB02074EA.CT_DiscountTtlRate] = ((double)discountPrice / (double)totalPrice) * 100;
                }

                // 月間構成比
//                dr[DCHNB02074EA.CT_ComponentRatio] = 0;


                totalPrice = 99999999 / moneyUnit;
                dr[DCHNB02074EA.CT_AnStockTtlPrice] = totalPrice;                                       // 年間売上金額合計

                retGoodsPrice = 44444444 / moneyUnit;
                dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = retGoodsPrice;                                 // 年間返品額

                discountPrice = 11111111 / moneyUnit;
                dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = discountPrice;                                 // 年間値引額

                dr[DCHNB02074EA.CT_AnPureStockTtlPrice] = totalPrice + retGoodsPrice + discountPrice;   // 年間純売上額

                // 年間返品率
                if (totalPrice == 0)
                {
                    dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = 0.00;
                }
                else
                {
                    dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = ((double)retGoodsPrice / (double)totalPrice) * 100;
                }

                // 年間値引率
                if (totalPrice == 0)
                {
                    dr[DCHNB02074EA.CT_AnDiscountTtlRate] = 0.00;
                }
                else
                {
                    dr[DCHNB02074EA.CT_AnDiscountTtlRate] = ((double)discountPrice / (double)totalPrice) * 100;
                }

                // 年間構成比
//                dr[DCHNB02074EA.CT_AnComponentRatio] = 0;

                this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Add(dr);
            }
           
            status = 0;

            return status;

            */
            #endregion
        }
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        /// <param name="salesMonthYearReportCndtn">検索パラメータ</param>
        /// <param name="salesMonthYearReportParamWork">取得パラメータ</param>
        /// <remarks>
        /// <br>Note       : 検索パラメータの設定を行います。 </br>
        /// <br>Programer  : 980035　金沢　貞義</br>
        /// <br>Date       : 2007.12.07</br>
        /// </remarks>
        private void SearchParaSet(SalesMonthYearReportCndtn salesMonthYearReportCndtn, ref SalesMonthYearReportParamWork salesMonthYearReportParamWork)
        {
            #region < 企業コード >
            salesMonthYearReportParamWork.EnterpriseCode = salesMonthYearReportCndtn.EnterpriseCode;                                // 企業コード
            #endregion

            #region < 拠点 >
            // --- DEL 2008/09/08 -------------------------------->>>>> 
            //if (salesMonthYearReportCndtn.SectionCodes.Length != 0)
            //{
            //    if (salesMonthYearReportCndtn.SectionCodes == null)
            //    {
            //        // 全社の時
            //        salesMonthYearReportParamWork.SectionCodes = new string[0];                          // 拠点コード
            //    }
            //    else
            //    {
            //        salesMonthYearReportParamWork.SectionCodes = salesMonthYearReportCndtn.SectionCodes; // 拠点コード
            //    }
            //}
            //else
            //{
            //    salesMonthYearReportParamWork.SectionCodes = new string[0];                              // 拠点コード
            //}
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (salesMonthYearReportCndtn.SectionCodes == null)
            {
                // 全社の時
                salesMonthYearReportParamWork.SectionCodes = null;
            }
            else
            {
                // 全社以外
                salesMonthYearReportParamWork.SectionCodes = salesMonthYearReportCndtn.SectionCodes;
            }
            // --- ADD 2008/09/08 --------------------------------<<<<<
            #endregion

            //--- DEL 2008.08.14 ---------->>>>>
            #region < 部署 >
            //salesMonthYearReportParamWork.SectionDiv　      = salesMonthYearReportCndtn.SectionDiv;         // 部署管理区分
            //salesMonthYearReportParamWork.SectionCodeSt     = salesMonthYearReportCndtn.SectionCodeSt;      // 開始拠点
            //salesMonthYearReportParamWork.SectionCodeEd     = salesMonthYearReportCndtn.SectionCodeEd;      // 終了拠点
            //salesMonthYearReportParamWork.SubSectionCodeSt  = salesMonthYearReportCndtn.SubSectionCodeSt;   // 開始部門
            //salesMonthYearReportParamWork.SubSectionCodeEd  = salesMonthYearReportCndtn.SubSectionCodeEd;   // 終了部門
            //salesMonthYearReportParamWork.MinSectionCodeSt  = salesMonthYearReportCndtn.MinSectionCodeSt;   // 開始課
            //salesMonthYearReportParamWork.MinSectionCodeEd  = salesMonthYearReportCndtn.MinSectionCodeEd;   // 終了課
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            #region < 画面設定条件 >
            salesMonthYearReportParamWork.AddUpYearMonthSt = salesMonthYearReportCndtn.AddUpYearMonthSt;      // 開始計上年月
            salesMonthYearReportParamWork.AddUpYearMonthEd = salesMonthYearReportCndtn.AddUpYearMonthEd;      // 終了計上年月
            salesMonthYearReportParamWork.AnnualAddUpYearMonthSt = salesMonthYearReportCndtn.AnnualAddUpYearMonthSt;// 開始計上期年月
            salesMonthYearReportParamWork.AnnualAddUpYaerMonthEd = salesMonthYearReportCndtn.AnnualAddUpYaerMonthEd;// 終了計上期年月

            salesMonthYearReportParamWork.CustomerCodeSt = salesMonthYearReportCndtn.CustomerCodeSt;     // 開始得意先コード
            //salesMonthYearReportParamWork.CustomerCodeEd        = salesMonthYearReportCndtn.CustomerCodeEd;     // 終了得意先コード // DEL 2008/10/24
            // --- ADD 2008/10/24 -------------------------------->>>>>
            if (salesMonthYearReportCndtn.CustomerCodeEd == 0)
            {
                salesMonthYearReportParamWork.CustomerCodeEd = 99999999;
            }
            else
            {
                salesMonthYearReportParamWork.CustomerCodeEd = salesMonthYearReportCndtn.CustomerCodeEd;
            }
            // --- ADD 2008/10/24 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            salesMonthYearReportParamWork.SrchCodeSt = salesMonthYearReportCndtn.SearchCodeSt; // 検索条件(開始)
            //salesMonthYearReportParamWork.SrchCodeEd = salesMonthYearReportCndtn.SearchCodeEd; // 検索条件(終了) // DEL 2008/10/20
            // --- ADD 2008/10/24 -------------------------------->>>>>
            salesMonthYearReportParamWork.SrchCodeEd = salesMonthYearReportCndtn.SearchCodeEd;
            // --- ADD 2008/10/24 --------------------------------<<<<<
            // --- ADD 2008/09/08 --------------------------------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            //salesMonthYearReportParamWork.SalesEmployeeCdSt     = salesMonthYearReportCndtn.SalesEmployeeCdSt;  // 開始販売従業員コード
            //salesMonthYearReportParamWork.SalesEmployeeCdEd     = salesMonthYearReportCndtn.SalesEmployeeCdEd;  // 終了販売従業員コード
            //salesMonthYearReportParamWork.GoodsMakerCdSt        = salesMonthYearReportCndtn.GoodsMakerCdSt;     // 開始メーカーコード
            //salesMonthYearReportParamWork.GoodsMakerCdEd        = salesMonthYearReportCndtn.GoodsMakerCdEd;     // 終了メーカーコード
            //salesMonthYearReportParamWork.SalesAreaCodeSt       = salesMonthYearReportCndtn.SalesAreaCodeSt;    // 開始地区コード
            //salesMonthYearReportParamWork.SalesAreaCodeEd       = salesMonthYearReportCndtn.SalesAreaCodeEd;    // 終了地区コード
            //salesMonthYearReportParamWork.BusinessTypeCodeSt    = salesMonthYearReportCndtn.BusinessTypeCodeSt; // 開始業種コード
            //salesMonthYearReportParamWork.BusinessTypeCodeEd    = salesMonthYearReportCndtn.BusinessTypeCodeEd; // 終了業種コード
            //--- DEL 2008.08.14 ----------<<<<<

            salesMonthYearReportParamWork.TtlType = salesMonthYearReportCndtn.TtlType;            // 集計方法
            salesMonthYearReportParamWork.TotalType = salesMonthYearReportCndtn.TotalType;          // 集計単位
            salesMonthYearReportParamWork.PrintType = salesMonthYearReportCndtn.PrintType;          // 印刷タイプ
            //--- ADD 2008.08.14 ---------->>>>>
            salesMonthYearReportParamWork.OutType = salesMonthYearReportCndtn.OutType;            // 出力順
            //--- ADD 2008.08.14 ----------<<<<<
            #endregion

            #region < 画面設定条件(リスト) >
            #endregion
        }

        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.DCHNB02074EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="salesMonthYearReportParamWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByMode(out object retObj, SalesMonthYearReportParamWork salesMonthYearReportParamWork)
        {
            int status = 0;
            retObj = null;

            ISalesMonthYearReportResultDB _iSalesMonthYearReportResultDB = (ISalesMonthYearReportResultDB)MediationSalesMonthYearReportResultDB.GetSalesMonthYearReportResultDB();

            status = _iSalesMonthYearReportResultDB.Search(out retObj, salesMonthYearReportParamWork);

            return status;
        }

        // --- DEL 2008/09/08 -------------------------------->>>>>
        ///// <summary>
        ///// 印字順クエリ作成処理
        ///// </summary>
        ///// <returns>作成したクエリ</returns>
        ///// <remarks>
        ///// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        ///// <br>Programer  : 980035　金沢　貞義</br>
        ///// <br>Date       : 2007.12.07</br>
        ///// </remarks>
        //private string GetPrintOderQuerry(SalesMonthYearReportCndtn salesMonthYearReportCndtn)
        //{
        //    string orderQuerry = "";

        //    // ソート順設定
        //    //switch (salesMonthYearReportCndtn.SortOrder)
        //    switch (salesMonthYearReportCndtn.TotalType)
        //    {
        //        case 1:
        //            {
        //                // 得意先
        //                orderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                // 地区→得意先
        //                orderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                // 業種→得意先
        //                orderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //    }

        //    // 昇順固定
        //    orderQuerry += CT_UpperOrder;

        //    return orderQuerry;
        //}
        // --- DEL 2008/09/08 --------------------------------<<<<<

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            this._Tbl_MonthYearReportDtl = Broadleaf.Application.UIData.DCHNB02074EA.ct_Tbl_SalesMonthYearReportDtl;
        }

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        /// <param name="extraInfo">検索パラメータ</param>
        private void SetTebleRowFromRetList(ArrayList retList, int setCnt, SalesMonthYearReportCndtn extraInfo)
        {
            Int64 totalPrice = 0;
            //Int64 retGoodsPrice = 0;      // DEL 2008.08.14
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //Int64 discountPrice = 0;
            Int64 salesDiscount = 0;
            Int64 returnDiscount = 0;
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            Int64 purePrice = 0;
            Int64 grossProfit = 0;
            Int64 targetMoney = 0;
            Int64 targetProfit = 0;
            Int64 workInt1 = 0;
            Int64 workInt2 = 0;
            // --- ADD 2012/05/02 -------------------------------->>>>>
            Int64 work_PurePrice = 0;
            Int64 work_anPurePrice = 0;
            Int64 work_GrossProfitRate = 0;
            Int64 work_anGrossProfitRate = 0;
            // --- ADD 2012/05/02 --------------------------------<<<<<

            int moneyUnit = 1;
            string workKey = "";

            DataRow dr;
            dr = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].NewRow();

            // 明細単位
            SalesMonthYearReportResultWork salesMonthYearReportResultWork = (SalesMonthYearReportResultWork)retList[setCnt];

            // DictionaryKey作成
            workKey = GetDictionaryKey(salesMonthYearReportResultWork, extraInfo);

            dr[DCHNB02074EA.CT_SectionCode] = salesMonthYearReportResultWork.SectionCode;       // 拠点コード
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_SectionName]         = salesMonthYearReportResultWork.SectionGuideNm;    // 拠点ガイド名称
            //dr[DCHNB02074EA.CT_SubSectionCode]      = salesMonthYearReportResultWork.SubSectionCode;    // 部門コード
            //dr[DCHNB02074EA.CT_SubSectionName]      = salesMonthYearReportResultWork.SubSectionName;    // 部門名称
            //dr[DCHNB02074EA.CT_MinSectionCode]      = salesMonthYearReportResultWork.MinSectionCode;    // 課コード
            //dr[DCHNB02074EA.CT_MinSectionName]      = salesMonthYearReportResultWork.MinSectionName;    // 課名称
            //dr[DCHNB02074EA.CT_EmployeeCode]        = salesMonthYearReportResultWork.SalesEmployeeCd;   // 従業員コード
            //dr[DCHNB02074EA.CT_EmployeeName]        = salesMonthYearReportResultWork.SalesEmployeeNm;   // 従業員名称
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            dr[DCHNB02074EA.CT_SectionName] = salesMonthYearReportResultWork.CompanyName1;      // 拠点名称
            //--- ADD 2008.08.14 ----------<<<<<
            dr[DCHNB02074EA.CT_CustomerCode] = salesMonthYearReportResultWork.CustomerCode;      // 得意先コード
            dr[DCHNB02074EA.CT_CustomerName] = salesMonthYearReportResultWork.CustomerSnm;       // 得意先名称
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_GoodsMakerCd]        = salesMonthYearReportResultWork.GoodsMakerCd;      // 商品メーカーコード
            //dr[DCHNB02074EA.CT_MakerName]           = salesMonthYearReportResultWork.MakerName;         // メーカー名称
            //dr[DCHNB02074EA.CT_SalesAreaCode]       = salesMonthYearReportResultWork.SalesAreaCode;     // 地区コード
            //dr[DCHNB02074EA.CT_SalesAreaName]       = salesMonthYearReportResultWork.SalesAreaName;     // 地区名称
            //dr[DCHNB02074EA.CT_BusinessTypeCode]    = salesMonthYearReportResultWork.BusinessTypeCode;  // 業種コード
            //dr[DCHNB02074EA.CT_BusinessTypeName]    = salesMonthYearReportResultWork.BusinessTypeName;  // 業種名称
            //--- DEL 2008.08.14 ----------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            if (extraInfo.TotalType != (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer)
            {
                //dr[DCHNB02074EA.CT_Code] = salesMonthYearReportResultWork.Code; //検索条件コード // DEL 2009/02/06
                dr[DCHNB02074EA.CT_Code] = salesMonthYearReportResultWork.Code.Trim().PadLeft(4, '0'); //検索条件コード // ADD 2009/02/06
                dr[DCHNB02074EA.CT_Name] = salesMonthYearReportResultWork.Name; //検索条件名
            }
            else
            {
                // 得意先の場合はCode,Nameには値が返ってこないので代入
                dr[DCHNB02074EA.CT_Code] = salesMonthYearReportResultWork.CustomerCode;
                dr[DCHNB02074EA.CT_Name] = salesMonthYearReportResultWork.CustomerSnm;
            }


            // --- ADD 2008/09/08 --------------------------------<<<<<


            #region ◆明細単位設定
            switch (extraInfo.TotalType)
            {
                //--- DEL 2008.08.14 ---------->>>>>
                //    case 0: // 拠点別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SectionCode];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SectionName];
                //            break;
                //        }
                //    case 1: // 得意先別
                //    case 2: // 地区別得意先別
                //    case 3: // 業種別得意先別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_CustomerCode];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_CustomerName];
                //            break;
                //        }
                //    case 4: // 地区別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SalesAreaCode];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SalesAreaName];
                //            break;
                //        }
                //    case 5: // 業種別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_BusinessTypeCode];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_BusinessTypeName];
                //            break;
                //        }
                //    case 6: // 担当者別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_EmployeeCode];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_EmployeeName];
                //            break;
                //        }
                //    case 7: // 部署別
                //        {
                //            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //            //dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_MinSectionCode];
                //            //dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_MinSectionName];
                //            if (extraInfo.SectionDiv == 2)
                //            {
                //                dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_MinSectionCode];
                //                dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_MinSectionName];
                //            }
                //            else if (extraInfo.SectionDiv == 1)
                //            {
                //                dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SubSectionCode];
                //                dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SubSectionName];
                //            }
                //            else if (extraInfo.SectionDiv == 0)
                //            {
                //                dr[DCHNB02074EA.CT_RecordCode] = string.Empty;
                //                dr[DCHNB02074EA.CT_RecordName] = string.Empty;
                //            }
                //            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //            break;
                //        }
                //    case 8: // メーカー別
                //    case 9: // 得意先別メーカー別
                //        {
                //            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_GoodsMakerCd];
                //            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_MakerName];
                //            break;
                //        }
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer: // 得意先別
                    {
                        if (extraInfo.PrintingPattern == 0)
                        {
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_CustomerCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_CustomerName];
                        }
                        else
                        {
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SectionCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SectionName];
                        }
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                    {
                        if (extraInfo.PrintingPattern == 0)
                        {
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_Code];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_Name];
                        }
                        else if (extraInfo.PrintingPattern == 1)
                        {
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_CustomerCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_CustomerName];
                        }
                        else
                        {
                            dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_SectionCode];
                            dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_SectionName];
                        }
                        break;
                    }
                case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                    {
                        dr[DCHNB02074EA.CT_RecordCode] = dr[DCHNB02074EA.CT_Code];
                        dr[DCHNB02074EA.CT_RecordName] = dr[DCHNB02074EA.CT_Name];

                        break;
                    }
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/09/08 -------------------------------->>>>>

                // --- ADD 2008/09/08 --------------------------------<<<<< 
            }
            #endregion

            #region ◆明細金額設定
            // 金額単位
            if (extraInfo.MoneyUnit == 1) moneyUnit = 1000;

            // 月間売上金額合計
            //--- DEL 2008.08.14 ---------->>>>>
            //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////totalPrice = salesMonthYearReportResultWork.MonthSalesTotalTaxExc;
            //salesDiscount = salesMonthYearReportResultWork.MonthSalesDiscountPrice;     // 売上値引額
            //totalPrice    = salesMonthYearReportResultWork.MonthSalesTotalTaxExc - salesDiscount;
            //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_SalesTtlPrice] = GetUnitChangeProc(totalPrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            dr[DCHNB02074EA.CT_SalesTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesMoney, moneyUnit);
            //--- ADD 2008.08.14 ----------<<<<<

            // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる >>>>>>START
            // 月間返品額
            //--- DEL 2008.08.14 ---------->>>>>
            //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////retGoodsPrice = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice;
            //returnDiscount = salesMonthYearReportResultWork.MonthReturnDiscountPrice;   // 返品値引額
            ////※返品額は値引き分は含まれていないため返品値引額の減算は行わない！
            ////retGoodsPrice  = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice - returnDiscount; 
            //retGoodsPrice  = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice; 
            //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = GetUnitChangeProc(retGoodsPrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesRetGoodsPrice, moneyUnit);
            dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = -(GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesRetGoodsPrice, moneyUnit));
            //--- ADD 2008.08.14 ----------<<<<<

            // 月間値引額
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //discountPrice = salesMonthYearReportResultWork.MonthDiscountPrice;
            //dr[DCHNB02074EA.CT_DiscountTtlPrice]    = GetUnitChangeProc(discountPrice, moneyUnit);
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_DiscountTtlPrice] = GetUnitChangeProc(salesDiscount + returnDiscount, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_DiscountTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.MonthDiscountPrice, moneyUnit);
            dr[DCHNB02074EA.CT_DiscountTtlPrice] = -(GetUnitChangeProc(salesMonthYearReportResultWork.MonthDiscountPrice, moneyUnit));
            //--- ADD 2008.08.14 ----------<<<<<
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる <<<<<<END

            // 月間純売上額
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //purePrice = totalPrice + retGoodsPrice + discountPrice;
            //--- DEL 2008.08.14 ---------->>>>>
            //purePrice = totalPrice + retGoodsPrice + salesDiscount + returnDiscount;
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_PureSalesTtlPrice] = GetUnitChangeProc(purePrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            purePrice = salesMonthYearReportResultWork.MonthSalesMoney + salesMonthYearReportResultWork.MonthSalesRetGoodsPrice + salesMonthYearReportResultWork.MonthDiscountPrice;
            dr[DCHNB02074EA.CT_PureSalesTtlPrice] = GetUnitChangeProc(purePrice, moneyUnit);
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD 2012/05/02 -------------------------------->>>>>
            work_PurePrice = purePrice;
            // --- ADD 2012/05/02 --------------------------------<<<<<

            // 月間返品率
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_RetGoodsTtlRate] = GetRatioProc((double)retGoodsPrice, (double)totalPrice);
            //--- DEL 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_RetGoodsTtlRate] = (double)salesMonthYearReportResultWork.MonthSalesRetGoodsPrice / (double)salesMonthYearReportResultWork.MonthSalesMoney * 100;
            //--- ADD 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<< 
            // --- DEL 2009/03/27 -------------------------------->>>>>
            // --- ADD 2008/09/08 -------------------------------->>>>>
            //dr[DCHNB02074EA.CT_RetGoodsTtlRate] = GetRatioProc((double)salesMonthYearReportResultWork.MonthSalesRetGoodsPrice, (double)salesMonthYearReportResultWork.MonthSalesMoney);
            // --- ADD 2008/09/08 --------------------------------<<<<< 
            // --- DEL 2009/03/27 --------------------------------<<<<<
            // --- ADD 2009/03/27 -------------------------------->>>>>
            dr[DCHNB02074EA.CT_RetGoodsTtlRate] = GetRatioProc((double)salesMonthYearReportResultWork.MonthSalesRetGoodsPrice * -1, (double)salesMonthYearReportResultWork.MonthSalesMoney);
            // --- ADD 2009/03/27 --------------------------------<<<<<

            // 月間値引率
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //dr[DCHNB02074EA.CT_DiscountTtlRate]   = GetRatioProc((double)discountPrice, (double)totalPrice);
            dr[DCHNB02074EA.CT_DiscountTtlRate] = GetRatioProc((double)(salesDiscount + returnDiscount), (double)totalPrice);
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<

            // 月間売上目標金額
            targetMoney = salesMonthYearReportResultWork.MonthSalesTargetMoney;
            dr[DCHNB02074EA.CT_TargetMoney] = GetUnitChangeProc(targetMoney, moneyUnit);

            // 月間売上目標達成率
            dr[DCHNB02074EA.CT_TargetMoneyRate] = GetRatioProc((double)purePrice, (double)targetMoney);

            // 月間粗利額
            //--- DEL 2008.08.14 ---------->>>>>
            ////grossProfit = salesMonthYearReportResultWork.MonthGrossProfit;
            //grossProfit = purePrice - salesMonthYearReportResultWork.MonthTotalCost;
            //dr[DCHNB02074EA.CT_GrossProfitPrice]    = GetUnitChangeProc(grossProfit, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            grossProfit = GetUnitChangeProc(salesMonthYearReportResultWork.MonthGrossProfit, moneyUnit);
            dr[DCHNB02074EA.CT_GrossProfitPrice] = grossProfit;
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD 2012/05/02 -------------------------------->>>>>
            work_GrossProfitRate = grossProfit;
            // --- ADD 2012/05/02 --------------------------------<<<<<

            // 月間粗利率
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_GrossProfitRate] = GetRatioProc((double)grossProfit, (double)purePrice);
            //--- DEL 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_GrossProfitRate] = (double)salesMonthYearReportResultWork.MonthGrossProfit / (double)purePrice * 100;
            //--- ADD 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            dr[DCHNB02074EA.CT_GrossProfitRate] = GetRatioProc((double)salesMonthYearReportResultWork.MonthGrossProfit, (double)purePrice);
            // --- ADD 2008/09/08 --------------------------------<<<<<

            // 月間粗利目標金額
            targetProfit = salesMonthYearReportResultWork.MonthSalesTargetProfit;
            dr[DCHNB02074EA.CT_TargetProfit] = GetUnitChangeProc(targetProfit, moneyUnit);

            // 月間粗利目標達成率
            //dr[DCHNB02074EA.CT_TargetProfitRate]    = GetRatioProc((double)grossProfit, (double)targetProfit);                                    //DEL 2008/10/17 単位変換前の値で計算する為
            dr[DCHNB02074EA.CT_TargetProfitRate] = GetRatioProc((double)salesMonthYearReportResultWork.MonthGrossProfit, (double)targetProfit);     //ADD 2008/10/17



            // 年間売上金額合計
            //--- DEL 2008.08.14 ---------->>>>>
            //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////totalPrice = salesMonthYearReportResultWork.AnnualSalesTotalTaxExc;
            //salesDiscount = salesMonthYearReportResultWork.AnnualSalesDiscountPrice;    // 売上値引額
            //totalPrice    = salesMonthYearReportResultWork.AnnualSalesTotalTaxExc - salesDiscount;
            //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_AnSalesTtlPrice] = GetUnitChangeProc(totalPrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            dr[DCHNB02074EA.CT_AnSalesTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesMoney, moneyUnit);
            //--- ADD 2008.08.14 ----------<<<<<

            // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる >>>>>>START
            // 年間返品額
            //--- DEL 2008.08.14 ---------->>>>>
            //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            ////retGoodsPrice = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice;
            //returnDiscount = salesMonthYearReportResultWork.AnnualReturnDiscountPrice;  // 返品値引額
            ////※返品額は値引き分は含まれていないため返品値引額の減算は行わない！
            ////retGoodsPrice = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice - returnDiscount;
            //retGoodsPrice = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice;
            //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = GetUnitChangeProc(retGoodsPrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice, moneyUnit);
            dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = -(GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice, moneyUnit));
            //--- ADD 2008.08.14 ----------<<<<<

            // 年間値引額
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //discountPrice = salesMonthYearReportResultWork.AnnualDiscountPrice;
            //dr[DCHNB02074EA.CT_AnDiscountTtlPrice]  = GetUnitChangeProc(discountPrice, moneyUnit);
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = GetUnitChangeProc(salesDiscount + returnDiscount, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.AnnualDiscountPrice, moneyUnit);
            dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = -(GetUnitChangeProc(salesMonthYearReportResultWork.AnnualDiscountPrice, moneyUnit));
            //--- ADD 2008.08.14 ----------<<<<<
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる <<<<<<END

            // 年間純売上額
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //purePrice = totalPrice + retGoodsPrice + discountPrice;
            //--- DEL 2008.08.14 ---------->>>>>
            //purePrice = totalPrice + retGoodsPrice + salesDiscount + returnDiscount;
            //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = GetUnitChangeProc(purePrice, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            purePrice = salesMonthYearReportResultWork.AnnualSalesMoney + salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice + salesMonthYearReportResultWork.AnnualDiscountPrice;
            dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = GetUnitChangeProc(purePrice, moneyUnit);
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD 2012/05/02 -------------------------------->>>>>
            work_anPurePrice = purePrice;
            // --- ADD 2012/05/02 --------------------------------<<<<<

            // 年間返品率
            //--- DEL 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnRetGoodsTtlRate]   = GetRatioProc((double)retGoodsPrice, (double)totalPrice);
            //--- DEL 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = (double)salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice / (double)salesMonthYearReportResultWork.AnnualSalesMoney * 100;
            //--- ADD 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- DEL 2009/03/27 -------------------------------->>>>>
            // --- ADD 2008/09/08 -------------------------------->>>>>
            //dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = GetRatioProc((double)salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice, (double)salesMonthYearReportResultWork.AnnualSalesMoney);
            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- DEL 2009/03/27 -------------------------------->>>>>
            // --- ADD 2009/03/27 -------------------------------->>>>>
            dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = GetRatioProc((double)salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice * -1, (double)salesMonthYearReportResultWork.AnnualSalesMoney);
            // --- ADD 2009/03/27 --------------------------------<<<<<

            // 年間値引率
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //dr[DCHNB02074EA.CT_AnDiscountTtlRate] = GetRatioProc((double)discountPrice, (double)totalPrice);
            dr[DCHNB02074EA.CT_AnDiscountTtlRate] = GetRatioProc((double)(salesDiscount + returnDiscount), (double)totalPrice);
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<

            // 年間売上目標金額
            targetMoney = salesMonthYearReportResultWork.AnnualSalesTargetMoney;
            dr[DCHNB02074EA.CT_AnTargetMoney] = GetUnitChangeProc(targetMoney, moneyUnit);

            // 年間売上目標達成率
            dr[DCHNB02074EA.CT_AnTargetMoneyRate] = GetRatioProc((double)purePrice, (double)targetMoney);

            // 年間粗利額
            //--- DEL 2008.08.14 ---------->>>>>
            ////grossProfit = salesMonthYearReportResultWork.AnnualGrossProfit;
            //grossProfit = purePrice - salesMonthYearReportResultWork.AnnualTotalCost;
            //dr[DCHNB02074EA.CT_AnGrossProfitPrice]  = GetUnitChangeProc(grossProfit, moneyUnit);
            //--- DEL 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            //dr[DCHNB02074EA.CT_AnGrossProfitPrice] = GetUnitChangeProc(salesMonthYearReportResultWork.AnnualGrossProfit, moneyUnit);
            //--- ADD 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            grossProfit = GetUnitChangeProc(salesMonthYearReportResultWork.AnnualGrossProfit, moneyUnit);
            dr[DCHNB02074EA.CT_AnGrossProfitPrice] = grossProfit;
            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- ADD 2012/05/02 -------------------------------->>>>>
            work_anGrossProfitRate = grossProfit;
            // --- ADD 2012/05/02 --------------------------------<<<<<

            // 年間粗利率
            //dr[DCHNB02074EA.CT_AnGrossProfitRate]   = GetRatioProc((double)grossProfit, (double)purePrice);                                       //DEL 2008/10/17 単位変換前の値で計算する為
            dr[DCHNB02074EA.CT_AnGrossProfitRate] = GetRatioProc((double)salesMonthYearReportResultWork.AnnualGrossProfit, (double)purePrice);      //ADD 2008/10/17

            // 年間粗利目標金額
            targetProfit = salesMonthYearReportResultWork.AnnualSalesTargetProfit;
            dr[DCHNB02074EA.CT_AnTargetProfit] = GetUnitChangeProc(targetProfit, moneyUnit);

            // 年間粗利目標達成率
            //dr[DCHNB02074EA.CT_AnTargetProfitRate]  = GetRatioProc((double)grossProfit, (double)targetProfit);                                    //DEL 2008/10/17 単位変換前の値で計算する為
            dr[DCHNB02074EA.CT_AnTargetProfitRate] = GetRatioProc((double)salesMonthYearReportResultWork.AnnualGrossProfit, (double)targetProfit);  //ADD 2008/10/17      


            // 構成比算出用値セット
            if (this._totalPriceDic.ContainsKey(workKey) == true)
            {
                DataRow workdr = this._totalPriceDic[workKey];
                /* --- DEL 2008/10/17 構成比は単位変換前の値で求める為 ------------------------------------------->>>>>
                // 月間合計純売上額
                dr[DCHNB02074EA.CT_PureSalesTtlWork]   = workdr[DCHNB02074EA.CT_PureSalesTtlPrice];
                // 月間合計粗利額
                dr[DCHNB02074EA.CT_GrossProfitWork]    = workdr[DCHNB02074EA.CT_GrossProfitPrice];
                // 年間合計純売上額
                dr[DCHNB02074EA.CT_AnPureSalesTtlWork] = workdr[DCHNB02074EA.CT_AnPureSalesTtlPrice];
                // 年間合計粗利額
                dr[DCHNB02074EA.CT_AnGrossProfitWork]  = workdr[DCHNB02074EA.CT_AnGrossProfitPrice];
                   --- DEL 2008/10/17 ----------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/17 ---------------------------------------------------------------------------->>>>>
                // 月間合計純売上額
                dr[DCHNB02074EA.CT_PureSalesTtlWork] = workdr[DCHNB02074EA.CT_PureSalesTtlPriceNoUnitChange];
                // 月間合計粗利額
                dr[DCHNB02074EA.CT_GrossProfitWork] = workdr[DCHNB02074EA.CT_GrossProfitPriceNoUnitChange];
                // 年間合計純売上額
                dr[DCHNB02074EA.CT_AnPureSalesTtlWork] = workdr[DCHNB02074EA.CT_AnPureSalesTtlPriceNoUnitChange];
                // 年間合計粗利額
                dr[DCHNB02074EA.CT_AnGrossProfitWork] = workdr[DCHNB02074EA.CT_AnGrossProfitPriceNoUnitChange];
                // --- ADD 2008/10/17 ----------------------------------------------------------------------------<<<<<
            }
            else
            {
                // 月間合計純売上額
                dr[DCHNB02074EA.CT_PureSalesTtlWork] = 0;
                // 月間合計粗利額
                dr[DCHNB02074EA.CT_GrossProfitWork] = 0;
                // 年間合計純売上額
                dr[DCHNB02074EA.CT_AnPureSalesTtlWork] = 0;
                // 年間合計粗利額
                dr[DCHNB02074EA.CT_AnGrossProfitWork] = 0;
            }

            // 月間売上構成比
            //workInt1 = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice];          //DEL 2008/10/17 構成比は単位変換前の値で求める為
            // --- ADD 2008/10/17 -------------------------------------------------------------------------------------->>>>>
            workInt1 = (Int64)(salesMonthYearReportResultWork.MonthSalesMoney
                            + salesMonthYearReportResultWork.MonthSalesRetGoodsPrice
                            + salesMonthYearReportResultWork.MonthDiscountPrice);
            // --- ADD 2008/10/17 --------------------------------------------------------------------------------------<<<<<
            workInt2 = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlWork];
            dr[DCHNB02074EA.CT_CmpPureSalesRatio] = GetRatioProc((double)workInt1, (double)workInt2);

            // 月間粗利構成比
            //workInt1 = (Int64)dr[DCHNB02074EA.CT_GrossProfitPrice];           //DEL 2008/10/17 構成比は単位変換前の値で求める為
            workInt1 = (Int64)salesMonthYearReportResultWork.MonthGrossProfit;  //ADD 2008/10/17
            workInt2 = (Int64)dr[DCHNB02074EA.CT_GrossProfitWork];
            dr[DCHNB02074EA.CT_CmpProfitRatio] = GetRatioProc(workInt1, workInt2);

            // 年間売上構成比
            //workInt1 = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice];        //DEL 2008/10/17 構成比は単位変換前の値で求める為
            // --- ADD 2008/10/17 -------------------------------------------------------------------------------------->>>>>
            workInt1 = (Int64)(salesMonthYearReportResultWork.AnnualSalesMoney
                            + salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice
                            + salesMonthYearReportResultWork.AnnualDiscountPrice);
            // --- ADD 2008/10/17 --------------------------------------------------------------------------------------<<<<<
            workInt2 = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlWork];
            dr[DCHNB02074EA.CT_AnCmpPureSalesRatio] = GetRatioProc((double)workInt1, (double)workInt2);

            // 月間粗利構成比
            //workInt1 = (Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice];         //DEL 2008/10/17 構成比は単位変換前の値で求める為
            workInt1 = (Int64)salesMonthYearReportResultWork.AnnualGrossProfit;
            workInt2 = (Int64)dr[DCHNB02074EA.CT_AnGrossProfitWork];
            dr[DCHNB02074EA.CT_AnCmpProfitRatio] = GetRatioProc((double)workInt1, (double)workInt2);

            #endregion

            #region ◆改頁キーブレイク設定
            //--- DEL 2008.08.14 ---------->>>>>
            //switch (extraInfo.TotalType)
            //{
            //    case 0: // 拠点別
            //    case 1: // 得意先別
            //    case 4: // 地区別
            //    case 5: // 業種別
            //    case 6: // 担当者別
            //    case 8: // メーカー別
            //        {
            //            dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            break;
            //        }
            //    case 2: // 地区別得意先別
            //        {
            //            if (extraInfo.CrMode % 10 > 0)
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = salesMonthYearReportResultWork.SectionCode
            //                                                       + salesMonthYearReportResultWork.SalesAreaCode.ToString("d4");
            //            }
            //            else
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            }
            //            break;
            //        }
            //    case 3: // 業種別得意先別
            //        {
            //            if (extraInfo.CrMode % 10 > 0)
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = salesMonthYearReportResultWork.SectionCode
            //                                                       + salesMonthYearReportResultWork.BusinessTypeCode.ToString("d2");
            //            }
            //            else
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            }
            //            break;
            //        }
            //    case 7: // 部署別
            //        {
            //            if (extraInfo.CrMode % 10 > 0)
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = salesMonthYearReportResultWork.SectionCode
            //                                                       + salesMonthYearReportResultWork.SubSectionCode.ToString("d2");
            //            }
            //            else
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            }
            //            break;
            //        }
            //    case 9: // 得意先別メーカー別
            //        {
            //            if (extraInfo.CrMode % 10 > 0)
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = salesMonthYearReportResultWork.SectionCode
            //                                                       + salesMonthYearReportResultWork.CustomerCode.ToString("d9");
            //            }
            //            else
            //            {
            //                dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            }
            //            break;
            //        }
            //}
            //--- DEL 2008.08.14 ----------<<<<<

            // --- DEL 2008/09/08 -------------------------------->>>>>
            //--- ADD 2008.08.14 ---------->>>>>
            //switch (extraInfo.TotalType)
            //{
            //    case 0: // 得意先別
            //        {
            //            dr[DCHNB02074EA.CT_MiniTotal_KeyBleak] = dr[DCHNB02074EA.CT_SectionCode];
            //            break;
            //        }
            //}
            //--- ADD 2008.08.14 ----------<<<<<
            // --- DEL 2008/09/08 --------------------------------<<<<<

            #endregion

            //--- ADD 2008.08.14 ---------->>>>>
            #region 順位付けの為の準備
            if (extraInfo.PrintType != 1)
            {
                //PureSalesTtlPrice.Add(salesMonthYearReportResultWork.MonthSalesMoney + salesMonthYearReportResultWork.MonthSalesRetGoodsPrice + salesMonthYearReportResultWork.MonthDiscountPrice);   // 純売上額を登録
                //GrossProfitList.Add(salesMonthYearReportResultWork.MonthGrossProfit);           // 粗利金額を登録
                //RetGoodsTtlPrice.Add(salesMonthYearReportResultWork.MonthSalesRetGoodsPrice);   // 返品額を登録
                PureSalesTtlPrice.Add((Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice]);            // 純売上額を登録
                GrossProfitList.Add((Int64)dr[DCHNB02074EA.CT_GrossProfitPrice]);               // 粗利金額を登録
                RetGoodsTtlPrice.Add((Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice]);              // 返品額を登録
            }
            else
            {
                //PureSalesTtlPrice.Add(salesMonthYearReportResultWork.AnnualSalesMoney + salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice + salesMonthYearReportResultWork.AnnualDiscountPrice);   // 純売上額を登録
                //GrossProfitList.Add(salesMonthYearReportResultWork.AnnualGrossProfit);           // 粗利金額を登録
                //RetGoodsTtlPrice.Add(salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice);   // 返品額を登録 
                PureSalesTtlPrice.Add((Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice]);          // 純売上額を登録
                GrossProfitList.Add((Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice]);             // 粗利金額を登録
                RetGoodsTtlPrice.Add((Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice]);            // 返品額を登録
            }
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<
            // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
            if (extraInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area           // 地区
                || extraInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType)    // 業種
            {
                // 売上目標(地区計用)取得
                this.GetCustSalesTarget(extraInfo, salesMonthYearReportResultWork, ref dr);
            }
            // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<
            // --- ADD 2009/02/06 -------------------------------->>>>>
            // 売上目標(拠点計用)取得
            //this.GetSalesTarget(extraInfo, salesMonthYearReportResultWork.SectionCode, ref dr);   // DEL 2012/05/02
            this.GetSalesTarget(extraInfo, salesMonthYearReportResultWork.SectionCode, ref dr, (double)work_PurePrice, (double)work_anPurePrice, (double)work_GrossProfitRate, (double)work_anGrossProfitRate);   // ADD 2012/05/02
            // --- ADD 2009/02/06 --------------------------------<<<<<

            this._printDataSet.Tables[_Tbl_MonthYearReportDtl].Rows.Add(dr);
        }

        /// <summary>
        /// 起動モード毎データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            dr[DCHNB02074EA.CT_SectionCode] = sourceDataRow[DCHNB02074EA.CT_SectionCode];           // 拠点コード
            dr[DCHNB02074EA.CT_SectionName] = sourceDataRow[DCHNB02074EA.CT_SectionName];           // 拠点ガイド名称
            dr[DCHNB02074EA.CT_SubSectionCode] = sourceDataRow[DCHNB02074EA.CT_SubSectionCode];        // 部門コード
            dr[DCHNB02074EA.CT_SubSectionName] = sourceDataRow[DCHNB02074EA.CT_SubSectionName];        // 部門名称
            dr[DCHNB02074EA.CT_MinSectionCode] = sourceDataRow[DCHNB02074EA.CT_MinSectionCode];        // 課コード
            dr[DCHNB02074EA.CT_MinSectionName] = sourceDataRow[DCHNB02074EA.CT_MinSectionName];        // 課名称
            dr[DCHNB02074EA.CT_EmployeeCode] = sourceDataRow[DCHNB02074EA.CT_EmployeeCode];          // 販売従業員コード
            dr[DCHNB02074EA.CT_EmployeeName] = sourceDataRow[DCHNB02074EA.CT_EmployeeName];          // 販売従業員名称
            dr[DCHNB02074EA.CT_CustomerCode] = sourceDataRow[DCHNB02074EA.CT_CustomerCode];          // 得意先コード
            dr[DCHNB02074EA.CT_CustomerName] = sourceDataRow[DCHNB02074EA.CT_CustomerName];          // 得意先名称
            dr[DCHNB02074EA.CT_GoodsMakerCd] = sourceDataRow[DCHNB02074EA.CT_GoodsMakerCd];          // 商品メーカーコード
            dr[DCHNB02074EA.CT_MakerName] = sourceDataRow[DCHNB02074EA.CT_MakerName];             // メーカー名称
            dr[DCHNB02074EA.CT_SalesAreaCode] = sourceDataRow[DCHNB02074EA.CT_SalesAreaCode];         // 地区コード
            dr[DCHNB02074EA.CT_SalesAreaName] = sourceDataRow[DCHNB02074EA.CT_SalesAreaName];         // 地区名称
            dr[DCHNB02074EA.CT_BusinessTypeCode] = sourceDataRow[DCHNB02074EA.CT_BusinessTypeCode];      // 業種コード
            dr[DCHNB02074EA.CT_BusinessTypeName] = sourceDataRow[DCHNB02074EA.CT_BusinessTypeName];      // 業種名称
            dr[DCHNB02074EA.CT_RecordCode] = sourceDataRow[DCHNB02074EA.CT_RecordCode];            // 明細コード
            dr[DCHNB02074EA.CT_RecordName] = sourceDataRow[DCHNB02074EA.CT_RecordName];            // 明細名称

            dr[DCHNB02074EA.CT_SalesTtlPrice] = sourceDataRow[DCHNB02074EA.CT_SalesTtlPrice];         // 月間売上金額合計
            dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = sourceDataRow[DCHNB02074EA.CT_RetGoodsTtlPrice];      // 月間返品額
            dr[DCHNB02074EA.CT_DiscountTtlPrice] = sourceDataRow[DCHNB02074EA.CT_DiscountTtlPrice];      // 月間値引額
            dr[DCHNB02074EA.CT_PureSalesTtlPrice] = sourceDataRow[DCHNB02074EA.CT_PureSalesTtlPrice];     // 月間純売上額
            dr[DCHNB02074EA.CT_PureSalesTtlWork] = sourceDataRow[DCHNB02074EA.CT_PureSalesTtlWork];      // 月間合計純売上額（構成比算出用）
            dr[DCHNB02074EA.CT_RetGoodsTtlRate] = sourceDataRow[DCHNB02074EA.CT_RetGoodsTtlRate];       // 月間返品率
            dr[DCHNB02074EA.CT_DiscountTtlRate] = sourceDataRow[DCHNB02074EA.CT_DiscountTtlRate];       // 月間値引率
            dr[DCHNB02074EA.CT_CmpPureSalesRatio] = sourceDataRow[DCHNB02074EA.CT_CmpPureSalesRatio];     // 月間売上構成比

            dr[DCHNB02074EA.CT_TargetMoney] = sourceDataRow[DCHNB02074EA.CT_TargetMoney];           // 月間売上目標金額
            dr[DCHNB02074EA.CT_TargetMoneyRate] = sourceDataRow[DCHNB02074EA.CT_TargetMoneyRate];       // 月間売上目標達成率
            dr[DCHNB02074EA.CT_GrossProfitPrice] = sourceDataRow[DCHNB02074EA.CT_GrossProfitPrice];      // 月間粗利額
            dr[DCHNB02074EA.CT_GrossProfitRate] = sourceDataRow[DCHNB02074EA.CT_GrossProfitRate];       // 月間粗利率
            dr[DCHNB02074EA.CT_GrossProfitWork] = sourceDataRow[DCHNB02074EA.CT_GrossProfitWork];       // 月間合計粗利額（構成比算出用）
            dr[DCHNB02074EA.CT_TargetProfit] = sourceDataRow[DCHNB02074EA.CT_TargetProfit];          // 月間粗利目標金額
            dr[DCHNB02074EA.CT_TargetProfitRate] = sourceDataRow[DCHNB02074EA.CT_TargetProfitRate];      // 月間粗利目標達成率
            dr[DCHNB02074EA.CT_CmpProfitRatio] = sourceDataRow[DCHNB02074EA.CT_CmpProfitRatio];        // 月間粗利構成比

            dr[DCHNB02074EA.CT_AnSalesTtlPrice] = sourceDataRow[DCHNB02074EA.CT_AnSalesTtlPrice];       // 年間売上金額合計
            dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = sourceDataRow[DCHNB02074EA.CT_AnRetGoodsTtlPrice];    // 年間返品額
            dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = sourceDataRow[DCHNB02074EA.CT_AnDiscountTtlPrice];    // 年間値引額
            dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = sourceDataRow[DCHNB02074EA.CT_AnPureSalesTtlPrice];   // 年間純売上額
            dr[DCHNB02074EA.CT_AnPureSalesTtlWork] = sourceDataRow[DCHNB02074EA.CT_AnPureSalesTtlWork];    // 年間合計純売上額（構成比算出用）
            dr[DCHNB02074EA.CT_AnRetGoodsTtlRate] = sourceDataRow[DCHNB02074EA.CT_AnRetGoodsTtlRate];     // 年間返品率
            dr[DCHNB02074EA.CT_AnDiscountTtlRate] = sourceDataRow[DCHNB02074EA.CT_AnDiscountTtlRate];     // 年間値引率
            dr[DCHNB02074EA.CT_AnCmpPureSalesRatio] = sourceDataRow[DCHNB02074EA.CT_AnCmpPureSalesRatio];   // 年間売上構成比

            dr[DCHNB02074EA.CT_AnTargetMoney] = sourceDataRow[DCHNB02074EA.CT_AnTargetMoney];         // 年間売上目標金額
            dr[DCHNB02074EA.CT_AnTargetMoneyRate] = sourceDataRow[DCHNB02074EA.CT_AnTargetMoneyRate];     // 年間売上目標達成率
            dr[DCHNB02074EA.CT_AnGrossProfitPrice] = sourceDataRow[DCHNB02074EA.CT_AnGrossProfitPrice];    // 年間粗利額
            dr[DCHNB02074EA.CT_AnGrossProfitRate] = sourceDataRow[DCHNB02074EA.CT_AnGrossProfitRate];     // 年間粗利率
            dr[DCHNB02074EA.CT_AnGrossProfitWork] = sourceDataRow[DCHNB02074EA.CT_AnGrossProfitWork];     // 年間合計粗利額（構成比算出用）
            dr[DCHNB02074EA.CT_AnTargetProfit] = sourceDataRow[DCHNB02074EA.CT_AnTargetProfit];        // 年間粗利目標金額
            dr[DCHNB02074EA.CT_AnTargetProfitRate] = sourceDataRow[DCHNB02074EA.CT_AnTargetProfitRate];    // 年間粗利目標達成率
            dr[DCHNB02074EA.CT_AnCmpProfitRatio] = sourceDataRow[DCHNB02074EA.CT_AnCmpProfitRatio];      // 月間粗利構成比
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //dr[DCHNB02074EA.CT_MiniTotal_KeyBleak]  = sourceDataRow[DCHNB02074EA.CT_MiniTotal_KeyBleak];
            // --- DEL 2008/09/08 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            dr[DCHNB02074EA.CT_Code] = sourceDataRow[DCHNB02074EA.CT_Code]; // 検索条件コード
            dr[DCHNB02074EA.CT_Name] = sourceDataRow[DCHNB02074EA.CT_Name]; // 検索条件名
            dr[DCHNB02074EA.CT_Order] = sourceDataRow[DCHNB02074EA.CT_Order]; // 順位
            // --- ADD 2008/09/08 --------------------------------<<<<< 
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

        #region ◆構成比算出用合計額取得処理
        /// <summary>
        /// 構成比算出用合計額取得処理
        /// </summary>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="extraInfo">検索パラメータ</param>
        private void GetTotalPrice(ArrayList retList, SalesMonthYearReportCndtn extraInfo)
        {
            //Int64 totalPrice = 0;         // DEL 2008.08.14
            //Int64 retGoodsPrice = 0;      // DEL 2008.08.14
            // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
            //Int64 discountPrice = 0;
            //Int64 salesDiscount = 0;      // DEL 2008.08.14
            //Int64 returnDiscount = 0;     // DEL 2008.08.14
            // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
            //Int64 grossProfit = 0;        // DEL 2008.08.14

            string workKey = "";
            int moneyUnit = 1;

            DataRow dr;

            // 金額単位
            if (extraInfo.MoneyUnit == 1) moneyUnit = 1000;

            for (int i = 0; i < retList.Count; i++)
            {
                dr = this._printDataSet.Tables[_Tbl_MonthYearReportDtl].NewRow();

                // 明細単位
                SalesMonthYearReportResultWork salesMonthYearReportResultWork = (SalesMonthYearReportResultWork)retList[i];

                // DictionaryKey作成
                workKey = GetDictionaryKey(salesMonthYearReportResultWork, extraInfo);

                // DictionaryにKeyが存在するかチェック
                if (this._totalPriceDic.ContainsKey(workKey) == true)
                {
                    dr = this._totalPriceDic[workKey];
                }
                else
                {
                    this._totalPriceDic.Add(workKey, dr);
                }

                // 月間売上金額合計
                //--- DEL 2008.08.14 ---------->>>>>
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////totalPrice = salesMonthYearReportResultWork.MonthSalesTotalTaxExc;
                //salesDiscount = salesMonthYearReportResultWork.MonthSalesDiscountPrice;     // 売上値引額
                //totalPrice    = salesMonthYearReportResultWork.MonthSalesTotalTaxExc - salesDiscount;
                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_SalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_SalesTtlPrice] + GetUnitChangeProc(totalPrice, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_SalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_SalesTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesMoney, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<

                // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる >>>>>>START
                // 月間返品額
                //--- DEL 2008.08.14 ---------->>>>>
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////retGoodsPrice = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice;
                //returnDiscount = salesMonthYearReportResultWork.MonthReturnDiscountPrice;   // 返品値引額

                ////2008.04.04 修正 Keigo Yata
                ////retGoodsPrice  = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice - returnDiscount;

                //retGoodsPrice = salesMonthYearReportResultWork.MonthSalesRetGoodsPrice;

                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice] + GetUnitChangeProc(retGoodsPrice, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesRetGoodsPrice, moneyUnit);
                dr[DCHNB02074EA.CT_RetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_RetGoodsTtlPrice] - GetUnitChangeProc(salesMonthYearReportResultWork.MonthSalesRetGoodsPrice, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<

                // 月間値引額
                // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //discountPrice = salesMonthYearReportResultWork.MonthDiscountPrice;
                //dr[DCHNB02074EA.CT_DiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_DiscountTtlPrice] + GetUnitChangeProc(discountPrice, moneyUnit);
                //--- DEL 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_DiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_DiscountTtlPrice] + GetUnitChangeProc(salesDiscount + returnDiscount, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_DiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_DiscountTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.MonthDiscountPrice, moneyUnit);
                dr[DCHNB02074EA.CT_DiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_DiscountTtlPrice] - GetUnitChangeProc(salesMonthYearReportResultWork.MonthDiscountPrice, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる <<<<<<END

                // 月間純売上額
                // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[DCHNB02074EA.CT_PureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice] + GetUnitChangeProc((totalPrice + retGoodsPrice + discountPrice), moneyUnit);

                Object test1 = dr[DCHNB02074EA.CT_PureSalesTtlPrice];
                //--- DEL 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_PureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice] + GetUnitChangeProc((totalPrice + retGoodsPrice + salesDiscount + returnDiscount), moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_PureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlPrice] + GetUnitChangeProc((salesMonthYearReportResultWork.MonthSalesMoney + salesMonthYearReportResultWork.MonthSalesRetGoodsPrice + salesMonthYearReportResultWork.MonthDiscountPrice), moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/10/17 ---------------------------------------------------------------------------------------->>>>>
                // 月間純売上額（単位変換前）
                dr[DCHNB02074EA.CT_PureSalesTtlPriceNoUnitChange] = (Int64)dr[DCHNB02074EA.CT_PureSalesTtlPriceNoUnitChange]
                                                                    + (salesMonthYearReportResultWork.MonthSalesMoney
                                                                    + salesMonthYearReportResultWork.MonthSalesRetGoodsPrice
                                                                    + salesMonthYearReportResultWork.MonthDiscountPrice);
                // --- ADD 2008/10/17 ----------------------------------------------------------------------------------------<<<<<
                Object test = dr[DCHNB02074EA.CT_PureSalesTtlPrice];


                // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<

                // 月間粗利額
                //--- DEL 2008.08.14 ---------->>>>>
                ////grossProfit = salesMonthYearReportResultWork.MonthGrossProfit;
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////grossProfit = (totalPrice + retGoodsPrice + discountPrice) - salesMonthYearReportResultWork.MonthTotalCost;
                //grossProfit = (totalPrice + retGoodsPrice + salesDiscount + returnDiscount) - salesMonthYearReportResultWork.MonthTotalCost;
                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_GrossProfitPrice] = (Int64)dr[DCHNB02074EA.CT_GrossProfitPrice] + GetUnitChangeProc(grossProfit, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_GrossProfitPrice] = (Int64)dr[DCHNB02074EA.CT_GrossProfitPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.MonthGrossProfit, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/10/17 ---------------------------------------------------------------------------------------->>>>>
                // 月間粗利額（単位変換前）
                dr[DCHNB02074EA.CT_GrossProfitPriceNoUnitChange] = (Int64)dr[DCHNB02074EA.CT_GrossProfitPriceNoUnitChange]
                                                                    + salesMonthYearReportResultWork.MonthGrossProfit;
                // --- ADD 2008/10/17 ----------------------------------------------------------------------------------------<<<<<


                // 年間売上金額合計
                //--- DEL 2008.08.14 ---------->>>>>
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////totalPrice = salesMonthYearReportResultWork.AnnualSalesTotalTaxExc;
                //salesDiscount = salesMonthYearReportResultWork.AnnualSalesDiscountPrice;    // 売上値引額
                //totalPrice    = salesMonthYearReportResultWork.AnnualSalesTotalTaxExc - salesDiscount;
                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_AnSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnSalesTtlPrice] + GetUnitChangeProc(totalPrice, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_AnSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnSalesTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesMoney, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<

                // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる >>>>>>START
                // 年間返品額
                //--- DEL 2008.08.14 ---------->>>>>
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////retGoodsPrice = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice;
                //returnDiscount = salesMonthYearReportResultWork.AnnualReturnDiscountPrice;  // 返品値引額

                //// 2008.04.04 修正 Keigo Yata
                ////retGoodsPrice  = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice - returnDiscount;

                //retGoodsPrice = salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice;



                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] + GetUnitChangeProc(retGoodsPrice, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice, moneyUnit);
                dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnRetGoodsTtlPrice] - GetUnitChangeProc(salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<

                // 年間値引額
                // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //discountPrice = salesMonthYearReportResultWork.AnnualDiscountPrice;
                //dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnDiscountTtlPrice] + GetUnitChangeProc(discountPrice, moneyUnit);
                //--- DEL 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnDiscountTtlPrice] + GetUnitChangeProc(salesDiscount + returnDiscount, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnDiscountTtlPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.AnnualDiscountPrice, moneyUnit);
                dr[DCHNB02074EA.CT_AnDiscountTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnDiscountTtlPrice] - GetUnitChangeProc(salesMonthYearReportResultWork.AnnualDiscountPrice, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                // 2009.03.02 30413 犬飼 返品、値引の符号をPM7に合わせる <<<<<<END

                // 年間純売上額
                // 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] + GetUnitChangeProc((totalPrice + retGoodsPrice + discountPrice), moneyUnit);
                //--- DEL 2008.08.14 ---------->>>>>
                //dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] + GetUnitChangeProc((totalPrice + retGoodsPrice + salesDiscount + returnDiscount), moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPrice] + GetUnitChangeProc((salesMonthYearReportResultWork.AnnualSalesMoney + salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice + salesMonthYearReportResultWork.AnnualDiscountPrice), moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                // --- ADD 2008/10/17 ---------------------------------------------------------------------------------------->>>>>
                // 年間純売上額（単位変換前）
                dr[DCHNB02074EA.CT_AnPureSalesTtlPriceNoUnitChange] = (Int64)dr[DCHNB02074EA.CT_AnPureSalesTtlPriceNoUnitChange]
                                                                        + (salesMonthYearReportResultWork.AnnualSalesMoney
                                                                        + salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice
                                                                        + salesMonthYearReportResultWork.AnnualDiscountPrice);
                // --- ADD 2008/10/17 ----------------------------------------------------------------------------------------<<<<<

                // 年間粗利額
                //--- DEL 2008.08.14 ---------->>>>>
                ////grossProfit = salesMonthYearReportResultWork.AnnualGrossProfit;
                //// 2008.03.05 修正 >>>>>>>>>>>>>>>>>>>>
                ////grossProfit = (totalPrice + retGoodsPrice + discountPrice) - salesMonthYearReportResultWork.AnnualTotalCost;
                //grossProfit = (totalPrice + retGoodsPrice + salesDiscount + returnDiscount) - salesMonthYearReportResultWork.AnnualTotalCost;
                //// 2008.03.05 修正 <<<<<<<<<<<<<<<<<<<<
                //dr[DCHNB02074EA.CT_AnGrossProfitPrice] = (Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice] + GetUnitChangeProc(grossProfit, moneyUnit);
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                dr[DCHNB02074EA.CT_AnGrossProfitPrice] = (Int64)dr[DCHNB02074EA.CT_AnGrossProfitPrice] + GetUnitChangeProc(salesMonthYearReportResultWork.AnnualGrossProfit, moneyUnit);
                //--- ADD 2008.08.14 ----------<<<<<
                // --- ADD 2008/10/17 ---------------------------------------------------------------------------------------->>>>>
                // 年間粗利額（単位変換前）
                dr[DCHNB02074EA.CT_AnGrossProfitPriceNoUnitChange] = (Int64)dr[DCHNB02074EA.CT_AnGrossProfitPriceNoUnitChange]
                                                                    + salesMonthYearReportResultWork.AnnualGrossProfit;
                // --- ADD 2008/10/17 ----------------------------------------------------------------------------------------<<<<<
            }
        }
        #endregion

        #region ◆DictionaryKey作成
        /// <summary>
        /// DictionaryのKey取得処理
        /// </summary>
        internal string GetDictionaryKey(SalesMonthYearReportResultWork resultWork, SalesMonthYearReportCndtn extraInfo)
        {
            string workKey;

            // 構成比単位
            if (extraInfo.ConstUnit == 0)
            {
                workKey = "000000";
            }
            else
            {
                // --- DEL 2008/09/08 -------------------------------->>>>>
                //// 全社集計チェック
                ////string sectionKey;        // DEL 2008.08.14
                //if (extraInfo.TtlType == 0)
                //{
                //    //sectionKey = "000000";    // DEL 2008.08.14
                //    workKey = "000000";
                //}
                //else
                //{
                //    //sectionKey = resultWork.SectionCode;  // DEL 2008.08.14
                //    workKey = resultWork.SectionCode;
                //}
                // --- DEL 2008/09/08 --------------------------------<<<<<

                // --- ADD 2008/09/08 -------------------------------->>>>>
                switch (extraInfo.TotalType)
                {
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer:
                        {
                            if (extraInfo.PrintingPattern == 0)
                            {
                                workKey = resultWork.SectionCode;
                            }
                            else if (extraInfo.PrintingPattern == 1)
                            {
                                workKey = "000000";
                            }
                            else if (extraInfo.PrintingPattern == 2)
                            {
                                workKey = resultWork.CustomerCode.ToString();
                            }
                            else
                            {
                                workKey = "000000";
                            }
                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee: // 担当者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee: // 受注者
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput: // 発行者 
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area: // 地区
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType: // 業種
                        {
                            if (extraInfo.PrintingPattern == 0)
                            {
                                workKey = resultWork.SectionCode;
                            }
                            else if (extraInfo.PrintingPattern == 1)
                            {
                                workKey = resultWork.SectionCode + resultWork.Code;
                            }
                            else if (extraInfo.PrintingPattern == 2)
                            {
                                workKey = resultWork.Code;
                            }
                            else
                            {
                                workKey = "000000";
                            }
                            break;
                        }
                    case (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision: // 販売区分
                        {
                            if (extraInfo.PrintingPattern == 0)
                            {
                                workKey = resultWork.SectionCode;
                            }
                            else if (extraInfo.PrintingPattern == 1)
                            {
                                workKey = "000000";
                            }
                            else
                            {
                                workKey = "000000";
                            }
                            break;
                        }
                    default:
                        {
                            workKey = "000000";
                            break;
                        }
                }
                // --- ADD 2008/09/08 --------------------------------<<<<< 

                // 集計単位チェック
                //--- DEL 2008.08.14 ---------->>>>>
                //switch (extraInfo.TotalType)
                //{
                //    case 2: // 地区別得意先別時（地区）
                //        {
                //            workKey = sectionKey + resultWork.SalesAreaCode.ToString("d4");
                //            break;
                //        }
                //    case 3: // 業種別得意先別時（業種）
                //        {
                //            workKey = sectionKey + resultWork.BusinessTypeCode.ToString("d2");
                //            break;
                //        }
                //    case 7: // 部署別時（部門）
                //        {
                //            workKey = sectionKey + resultWork.SubSectionCode.ToString("d2");
                //            break;
                //        }
                //    case 9: // 得意先別メーカー別時（得意先）
                //        {
                //            workKey = sectionKey + resultWork.CustomerCode.ToString("d9");
                //            break;
                //        }
                //    default :
                //        {
                //            workKey = sectionKey;
                //            break;
                //        }
                //}
                //--- DEL 2008.08.14 ----------<<<<<
            }

            return workKey;
        }
        #endregion

        #region ◆単位変換処理
        /// <summary>
        /// 単位変換処理（四捨五入）
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        internal Int64 GetUnitChangeProc(Int64 numerator, Int64 denominator)
        {
            Int64 retInt;
            Int64 workInt;
            double workdbl;

            retInt = numerator / denominator;
            workdbl = (double)numerator / (double)denominator;

            workInt = (Int64)(workdbl * 10) % 10;
            if (workInt >= 5)
            {
                retInt++;
            }

            return retInt;
        }
        #endregion

        #region ◆率取得処理
        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatioProc(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/03/24

            return workRate;
        }
        #endregion
        // --- ADD duzg 2013/07/26 Redmine#38722 ------->>>>>>>>>>>
        #region 売上目標（得意先別）取得
        /// <summary>
        /// 売上目標（得意先別）取得処理
        /// </summary>
        /// <param name="extraInfo">売上月報年報出条件クラスワーク</param>
        /// <param name="retWk">売上月報年報抽出結果クラスワーク</param>
        /// <param name="dr">データ行</param>
        /// <remarks>
        /// <br>Note       : 売上目標（得意先別）取得処理を行います。</br>
        /// <br>Programmer : duzg</br>
        /// <br>Date       : 2013/07/26</br>
        /// <br>UpdateNote : 2014/02/25 田建委</br>
        /// <br>           : redmine #38722 </br>
        /// <br>           : 地区コードは「0000」の場合、売上目標印字不正</br>
        /// </remarks>
        private void GetCustSalesTarget(SalesMonthYearReportCndtn extraInfo, SalesMonthYearReportResultWork retWk, ref DataRow dr)
        {
            //----- ADD 2014/02/25 田建委 ---------->>>>>
            // 地区コードは「0000」の場合、売上目標を取得しない
            if (retWk.Code.Trim().PadLeft(4, '0').Equals("0000"))
            {
                dr[DCHNB02074EA.CT_SubTtlTargetMoney] = 0;
                dr[DCHNB02074EA.CT_SubTtlTargetProfit] = 0;
                dr[DCHNB02074EA.CT_AnSubTtlTargetMoney] = 0;
                dr[DCHNB02074EA.CT_AnSubTtlTargetProfit] = 0;
                return;
            }
            //----- ADD 2014/02/25 田建委 ----------<<<<<
            // 処理単位
            string key = retWk.SectionCode.Trim().PadLeft(6, '0') + "-" + retWk.Code.Trim().PadLeft(4, '0');

            // 1処理単位につき1件取得すれば良いので、処理済処理単位は処理なし
            if (this._salesTargetFinCustList.Contains(key))
            {
                return;
            }

            if (this._salesTargetAcs == null)
            {
                this._salesTargetAcs = new SalesTargetAcs();
            }

            if (this._dateGetAcs == null)
            {
                this._dateGetAcs = DateGetAcs.GetInstance();

                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;
                List<DateTime> yearMonthList;
                int year;
                int difYear;

                // 会計年度との年度差分を取得
                this._dateGetAcs.GetYearFromMonth(extraInfo.AddUpYearMonthEd, out year, out difYear);
                // 締日を取得
                this._dateGetAcs.GetFinancialYearTable(difYear, out startMonthDateList, out endMonthDateList, out yearMonthList);

                this._startMonthDateList = startMonthDateList;
                this._endMonthDateList = endMonthDateList;
            }

            List<CustSalesTarget> custSalesTargetList;
            SearchCustSalesTargetPara searchCustSalesTargetPara = new SearchCustSalesTargetPara();

            // 企業コード
            searchCustSalesTargetPara.EnterpriseCode = extraInfo.EnterpriseCode;
            // 拠点コード
            searchCustSalesTargetPara.SelectSectCd = new string[1];
            searchCustSalesTargetPara.SelectSectCd[0] = retWk.SectionCode.Trim();

            if (string.IsNullOrEmpty(retWk.SectionCode.Trim()))
            {
                searchCustSalesTargetPara.SelectSectCd = extraInfo.SectionCodes;
            }

            // 目標設定区分(10：月間目標,20：個別期間目標)
            searchCustSalesTargetPara.TargetSetCd = 10;
            // 集計単位が地区の場合
            if (extraInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area)       // 地区
            {
                // 販売エリアコード
                searchCustSalesTargetPara.SalesAreaCode = Convert.ToInt32(retWk.Code.Trim());
                // 目標対比区分(10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品)
                searchCustSalesTargetPara.TargetContrastCd = 32;
            }
            // 集計単位が業種の場合
            else if (extraInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType)       // 業種
            {
                // 販売エリアコード
                searchCustSalesTargetPara.BusinessTypeCode = Convert.ToInt32(retWk.Code.Trim());
                // 目標対比区分(10:拠点,20:拠点+部門,21:拠点+部門+課,22:拠点+従業員,30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,33:拠点+販売ｴﾘｱ+得意先,40:拠点+ﾒｰｶｰ,41:拠点+ﾒｰｶｰ+商品)
                searchCustSalesTargetPara.TargetContrastCd = 31;
            }

            // 適用開始日(開始)
            searchCustSalesTargetPara.StartApplyStaDate = _startMonthDateList[0];
            // 適用終了日(終了)
            searchCustSalesTargetPara.EndApplyEndDate = _endMonthDateList[11];

            // 売上目標検索
            int status = this._salesTargetAcs.Search(out custSalesTargetList, searchCustSalesTargetPara, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && custSalesTargetList.Count != 0)
            {
                Int64 empTargetMoney = 0;
                Int64 empTargetProfit = 0;
                Int64 anEmpTargetMoney = 0;
                Int64 anEmpTargetProfit = 0;

                int yearMonthSt = (extraInfo.AddUpYearMonthSt.Year * 100 + extraInfo.AddUpYearMonthSt.Month);
                int yearMonthEd = (extraInfo.AddUpYearMonthEd.Year * 100 + extraInfo.AddUpYearMonthEd.Month);
                int anyearMonthSt = (extraInfo.AnnualAddUpYearMonthSt.Year * 100 + extraInfo.AnnualAddUpYearMonthSt.Month);

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // 月度は目標区分コードで比較
                    if (yearMonthSt <= Convert.ToInt32(custSalesTarget.TargetDivideCode)
                        && Convert.ToInt32(custSalesTarget.TargetDivideCode) <= yearMonthEd)
                    {
                        // 月間目標に追加
                        empTargetMoney += custSalesTarget.SalesTargetMoney;
                        empTargetProfit += custSalesTarget.SalesTargetProfit;
                    }

                    if (anyearMonthSt <= Convert.ToInt32(custSalesTarget.TargetDivideCode)
                        && Convert.ToInt32(custSalesTarget.TargetDivideCode) <= yearMonthEd)
                    {
                        // 期間目標に追加
                        anEmpTargetMoney += custSalesTarget.SalesTargetMoney;
                        anEmpTargetProfit += custSalesTarget.SalesTargetProfit;
                    }
                }

                if (extraInfo.MoneyUnit == 1)
                {
                    dr[DCHNB02074EA.CT_SubTtlTargetMoney] = this.GetUnitChangeProc(empTargetMoney, 1000);
                    dr[DCHNB02074EA.CT_SubTtlTargetProfit] = this.GetUnitChangeProc(empTargetProfit, 1000);
                    dr[DCHNB02074EA.CT_AnSubTtlTargetMoney] = this.GetUnitChangeProc(anEmpTargetMoney, 1000);
                    dr[DCHNB02074EA.CT_AnSubTtlTargetProfit] = this.GetUnitChangeProc(anEmpTargetProfit, 1000);
                }
                else
                {
                    dr[DCHNB02074EA.CT_SubTtlTargetMoney] = empTargetMoney;
                    dr[DCHNB02074EA.CT_SubTtlTargetProfit] = empTargetProfit;
                    dr[DCHNB02074EA.CT_AnSubTtlTargetMoney] = anEmpTargetMoney;
                    dr[DCHNB02074EA.CT_AnSubTtlTargetProfit] = anEmpTargetProfit;
                }
            }
            else
            {
                dr[DCHNB02074EA.CT_SubTtlTargetMoney] = 0;
                dr[DCHNB02074EA.CT_SubTtlTargetProfit] = 0;
                dr[DCHNB02074EA.CT_AnSubTtlTargetMoney] = 0;
                dr[DCHNB02074EA.CT_AnSubTtlTargetProfit] = 0;
            }

            // 処理済みキーを保存
            this._salesTargetFinCustList.Add(key);
        }
        #endregion
        // --- ADD duzg 2013/07/26 Redmine#38722 -------<<<<<<<<<<<

        // --- ADD 2009/02/06 -------------------------------->>>>>
        #region 売上目標取得
        /// <summary>
        /// 売上目標取得処理
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="sectionCd"></param>
        /// <param name="dr"></param>
        /// <param name="purePrice"></param>        // ADD 2012/05/02
        /// <param name="anpurePrice"></param>      // ADD 2012/05/02
        /// <param name="monthGrossProfit"></param> // ADD 2012/05/02
        /// <param name="anGrossProfit"></param>    // ADD 2012/05/02
        //private void GetSalesTarget(SalesMonthYearReportCndtn extraInfo, string sectionCd, ref DataRow dr)    // DEL 2012/05/02
        // --- ADD 2012/05/02 -------------------------------->>>>>
        private void GetSalesTarget(SalesMonthYearReportCndtn extraInfo, string sectionCd, ref DataRow dr, double purePrice, double anpurePrice, double monthGrossProfit, double anGrossProfit)
        // --- ADD 2012/05/02 --------------------------------<<<<<
        {
            // 1拠点につき1件取得すれば良いので、処理済拠点は処理なし
            if (this._salesTargetFinSecList.Contains(sectionCd))
            {
                return;
            }

            if (this._salesTargetAcs == null)
            {
                this._salesTargetAcs = new SalesTargetAcs();
            }

            if (this._dateGetAcs == null)
            {
                this._dateGetAcs = DateGetAcs.GetInstance();

                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;
                List<DateTime> yearMonthList;
                int year;
                int difYear;

                // 会計年度との年度差分を取得
                this._dateGetAcs.GetYearFromMonth(extraInfo.AddUpYearMonthEd, out year, out difYear);
                // 締日を取得
                this._dateGetAcs.GetFinancialYearTable(difYear, out startMonthDateList, out endMonthDateList, out yearMonthList);

                this._startMonthDateList = startMonthDateList;
                this._endMonthDateList = endMonthDateList;
            }

            List<EmpSalesTarget> empSalesTargetList;
            SearchEmpSalesTargetPara searchEmpSalesTargetPara = new SearchEmpSalesTargetPara();

            // 企業コード
            searchEmpSalesTargetPara.EnterpriseCode = extraInfo.EnterpriseCode;
            // 拠点コード
            searchEmpSalesTargetPara.SelectSectCd = new string[1];
            searchEmpSalesTargetPara.SelectSectCd[0] = sectionCd.Trim();
            // 目標設定区分
            searchEmpSalesTargetPara.TargetSetCd = 10;
            // 目標対比区分
            searchEmpSalesTargetPara.TargetContrastCd = 10;

            // 適用開始日(開始)
            searchEmpSalesTargetPara.StartApplyStaDate = _startMonthDateList[0];
            // 適用終了日(終了)
            searchEmpSalesTargetPara.EndApplyEndDate = _endMonthDateList[11];

            // 売上目標検索
            int status = this._salesTargetAcs.Search(out empSalesTargetList, searchEmpSalesTargetPara, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && empSalesTargetList.Count != 0)
            {
                Int64 sectionTargetMoney = 0;
                Int64 sectionTargetProfit = 0;
                Int64 anSectionTargetMoney = 0;
                Int64 anSectionTargetProfit = 0;

                int yearMonthSt = (extraInfo.AddUpYearMonthSt.Year * 100 + extraInfo.AddUpYearMonthSt.Month);
                int yearMonthEd = (extraInfo.AddUpYearMonthEd.Year * 100 + extraInfo.AddUpYearMonthEd.Month);
                // --- ADD 2012/05/02 -------------------------------->>>>>
                int anyearMonthSt = (extraInfo.AnnualAddUpYearMonthSt.Year * 100 + extraInfo.AnnualAddUpYearMonthSt.Month);
                // --- ADD 2012/05/02 --------------------------------<<<<<

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // 月度は目標区分コードで比較
                    if (yearMonthSt <= Convert.ToInt32(empSalesTarget.TargetDivideCode)
                        && Convert.ToInt32(empSalesTarget.TargetDivideCode) <= yearMonthEd)
                    {
                        // 月間目標に追加
                        sectionTargetMoney += empSalesTarget.SalesTargetMoney;
                        sectionTargetProfit += empSalesTarget.SalesTargetProfit;
                    }

                    // --- DEL 2012/05/02 -------------------------------->>>>>
                    //if (Convert.ToInt32(empSalesTarget.TargetDivideCode) <= yearMonthEd)
                    // --- DEL 2012/05/02 --------------------------------<<<<<
                    // --- ADD 2012/05/02 -------------------------------->>>>>
                    if (anyearMonthSt <= Convert.ToInt32(empSalesTarget.TargetDivideCode)
                        && Convert.ToInt32(empSalesTarget.TargetDivideCode) <= yearMonthEd)
                    // --- ADD 2012/05/02 --------------------------------<<<<<
                    {
                        // 期間目標に追加
                        anSectionTargetMoney += empSalesTarget.SalesTargetMoney;
                        anSectionTargetProfit += empSalesTarget.SalesTargetProfit;
                    }
                }

                if (extraInfo.MoneyUnit == 1)
                {
                    dr[DCHNB02074EA.CT_SectionTargetMoney] = this.GetUnitChangeProc(sectionTargetMoney, 1000);
                    dr[DCHNB02074EA.CT_SectionTargetProfit] = this.GetUnitChangeProc(sectionTargetProfit, 1000);
                    dr[DCHNB02074EA.CT_AnSectionTargetMoney] = this.GetUnitChangeProc(anSectionTargetMoney, 1000);
                    dr[DCHNB02074EA.CT_AnSectionTargetProfit] = this.GetUnitChangeProc(anSectionTargetProfit, 1000);
                }
                else
                {
                    dr[DCHNB02074EA.CT_SectionTargetMoney] = sectionTargetMoney;
                    dr[DCHNB02074EA.CT_SectionTargetProfit] = sectionTargetProfit;
                    dr[DCHNB02074EA.CT_AnSectionTargetMoney] = anSectionTargetMoney;
                    dr[DCHNB02074EA.CT_AnSectionTargetProfit] = anSectionTargetProfit;
                }

                // --- ADD 2012/05/02 -------------------------------->>>>>
                if ((extraInfo.TotalType == (int)SalesMonthYearReportCndtn.TotalTypeEnum.Customer)
                    && (extraInfo.OutType == 1))
                {
                    dr[DCHNB02074EA.CT_TargetMoneyRate] = GetRatioProc(purePrice, sectionTargetMoney);
                    dr[DCHNB02074EA.CT_TargetProfitRate] = GetRatioProc(monthGrossProfit, sectionTargetProfit);
                    dr[DCHNB02074EA.CT_AnTargetMoneyRate] = GetRatioProc(anpurePrice, anSectionTargetMoney);
                    dr[DCHNB02074EA.CT_AnTargetProfitRate] = GetRatioProc(anGrossProfit, anSectionTargetProfit);
                }
                // --- ADD 2012/05/02 --------------------------------<<<<<
            }
            else
            {
                dr[DCHNB02074EA.CT_SectionTargetMoney] = 0;
                dr[DCHNB02074EA.CT_SectionTargetProfit] = 0;
                dr[DCHNB02074EA.CT_AnSectionTargetMoney] = 0;
                dr[DCHNB02074EA.CT_AnSectionTargetProfit] = 0;
            }

            // 処理済み拠点を保存
            this._salesTargetFinSecList.Add(sectionCd);
        }
        #endregion
        // --- ADD 2009/02/06 --------------------------------<<<<<

        // --- ADD 2009/02/09 -------------------------------->>>>>
        /// <summary>
        /// 全項目が0の明細をリストから削除
        /// </summary>
        /// <param name="retList"></param>
        private void RemoveAllZero(ArrayList retList)
        {
            for (int i = retList.Count - 1; i >= 0; i--)
            {
                SalesMonthYearReportResultWork salesMonthYearReportResultWork
                    = (SalesMonthYearReportResultWork)retList[i];

                if (salesMonthYearReportResultWork.MonthSalesMoney == 0
                    && salesMonthYearReportResultWork.MonthSalesRetGoodsPrice == 0
                    && salesMonthYearReportResultWork.MonthDiscountPrice == 0
                    && salesMonthYearReportResultWork.MonthSalesTargetMoney == 0
                    && salesMonthYearReportResultWork.MonthGrossProfit == 0
                    && salesMonthYearReportResultWork.MonthSalesTargetProfit == 0
                    && salesMonthYearReportResultWork.AnnualSalesMoney == 0
                    && salesMonthYearReportResultWork.AnnualSalesRetGoodsPrice == 0
                    && salesMonthYearReportResultWork.AnnualDiscountPrice == 0
                    && salesMonthYearReportResultWork.AnnualSalesTargetMoney == 0
                    && salesMonthYearReportResultWork.AnnualGrossProfit == 0
                    && salesMonthYearReportResultWork.AnnualSalesTargetProfit == 0)
                {
                    retList.RemoveAt(i);
                }
            }
        }
        // --- ADD 2009/02/09 --------------------------------<<<<<

        #endregion

        #region テストデータ作成
        /// <summary>
        /// テストデータ作成
        /// </summary>
        private int testProc(ref ArrayList retList, SalesMonthYearReportCndtn extraInfo)
        {
            // 明細単位
            SalesMonthYearReportResultWork work01 = new SalesMonthYearReportResultWork();

            work01.Code = "1111";
            work01.Name = "Name1";
            work01.SectionCode = "11";          // 3拠点コード
            work01.CompanyName1 = "拠点1";       // 4拠点ガイド名称
            work01.CustomerCode = 11111111;             // 5得意先コード
            work01.CustomerSnm = "得意1拠点11"; // 6得意先名称
            work01.MonthSalesMoney = 120000;  // 7当月売上金額
            work01.MonthSalesRetGoodsPrice = 40000;  // 8当月返品額
            work01.MonthDiscountPrice = -5000;  // 9当月値引金額
            work01.MonthSalesTargetMoney = 150000; // 10当月売上目標金額
            work01.MonthGrossProfit = 2000;      // 11当月粗利金額
            work01.MonthSalesTargetProfit = 3000;      // 12当月売上目標粗利額
            work01.AnnualSalesMoney = 1000000; // 13当期売上金額
            work01.AnnualSalesRetGoodsPrice = 100000; // 14当期返品額
            work01.AnnualDiscountPrice = -50000; // 15当期値引金額
            work01.AnnualSalesTargetMoney = 1200000; // 16当期売上目標金額
            work01.AnnualGrossProfit = 20000; // 17当期粗利金額
            work01.AnnualSalesTargetProfit = 15000; // 18当期売上目標粗利額

            // 追加
            retList.Add(work01);

            // 明細単位
            SalesMonthYearReportResultWork work02 = new SalesMonthYearReportResultWork();

            work02.Code = "1111";
            work02.Name = "Name1";
            work02.SectionCode = "11";          // 3拠点コード
            work02.CompanyName1 = "拠点11";       // 4拠点ガイド名称
            work02.CustomerCode = 22222222;             // 5得意先コード
            work02.CustomerSnm = "得意2拠点11"; // 6得意先名称
            work02.MonthSalesMoney = 11;  // 7当月売上金額
            work02.MonthSalesRetGoodsPrice = 2;  // 8当月返品額
            work02.MonthDiscountPrice = -1;  // 9当月値引金額
            work02.MonthSalesTargetMoney = 20; // 10当月売上目標金額
            work02.MonthGrossProfit = 200;      // 11当月粗利金額
            work02.MonthSalesTargetProfit = 300;      // 12当月売上目標粗利額
            work02.AnnualSalesMoney = 100; // 13当期売上金額
            work02.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
            work02.AnnualDiscountPrice = -10; // 15当期値引金額
            work02.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
            work02.AnnualGrossProfit = 2000; // 17当期粗利金額
            work02.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

            // 追加
            retList.Add(work02);

            // 明細単位
            SalesMonthYearReportResultWork work03 = new SalesMonthYearReportResultWork();

            work03.Code = "1111";
            work03.Name = "Name1";
            work03.SectionCode = "22";          // 3拠点コード
            work03.CompanyName1 = "拠点22";       // 4拠点ガイド名称
            work03.CustomerCode = 11111111;             // 5得意先コード
            work03.CustomerSnm = "得意1拠点22"; // 6得意先名称
            work03.MonthSalesMoney = 10;  // 7当月売上金額
            work03.MonthSalesRetGoodsPrice = 2;  // 8当月返品額
            work03.MonthDiscountPrice = -1;  // 9当月値引金額
            work03.MonthSalesTargetMoney = 40; // 10当月売上目標金額
            work03.MonthGrossProfit = 200;      // 11当月粗利金額
            work03.MonthSalesTargetProfit = 300;      // 12当月売上目標粗利額
            work03.AnnualSalesMoney = 100; // 13当期売上金額
            work03.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
            work03.AnnualDiscountPrice = -10; // 15当期値引金額
            work03.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
            work03.AnnualGrossProfit = 2000; // 17当期粗利金額
            work03.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

            // 追加
            retList.Add(work03);

            // 明細単位
            SalesMonthYearReportResultWork work04 = new SalesMonthYearReportResultWork();

            work04.Code = "1111";
            work04.Name = "Name1";
            work04.SectionCode = "22";          // 3拠点コード
            work04.CompanyName1 = "拠点22";       // 4拠点ガイド名称
            work04.CustomerCode = 22222222;             // 5得意先コード
            work04.CustomerSnm = "得意2拠点22"; // 6得意先名称
            work04.MonthSalesMoney = 14;  // 7当月売上金額
            work04.MonthSalesRetGoodsPrice = 2;  // 8当月返品額
            work04.MonthDiscountPrice = -1;  // 9当月値引金額
            work04.MonthSalesTargetMoney = 50; // 10当月売上目標金額
            work04.MonthGrossProfit = 200;      // 11当月粗利金額
            work04.MonthSalesTargetProfit = 300;      // 12当月売上目標粗利額
            work04.AnnualSalesMoney = 100; // 13当期売上金額
            work04.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
            work04.AnnualDiscountPrice = -10; // 15当期値引金額
            work04.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
            work04.AnnualGrossProfit = 2000; // 17当期粗利金額
            work04.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

            // 追加
            retList.Add(work04);


            // 明細単位
            SalesMonthYearReportResultWork work05 = new SalesMonthYearReportResultWork();

            work05.Code = "2222";
            work05.Name = "Name2";
            work05.SectionCode = "11";          // 3拠点コード
            work05.CompanyName1 = "拠点11";       // 4拠点ガイド名称
            work05.CustomerCode = 11111111;             // 5得意先コード
            work05.CustomerSnm = "得意1拠点11"; // 6得意先名称
            work05.MonthSalesMoney = 14;  // 7当月売上金額
            work05.MonthSalesRetGoodsPrice = 2;  // 8当月返品額
            work05.MonthDiscountPrice = -1;  // 9当月値引金額
            work05.MonthSalesTargetMoney = 1000; // 10当月売上目標金額
            work05.MonthGrossProfit = 200;      // 11当月粗利金額
            work05.MonthSalesTargetProfit = 300;      // 12当月売上目標粗利額
            work05.AnnualSalesMoney = 100; // 13当期売上金額
            work05.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
            work05.AnnualDiscountPrice = -10; // 15当期値引金額
            work05.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
            work05.AnnualGrossProfit = 2000; // 17当期粗利金額
            work05.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

            // 追加
            retList.Add(work05);
            /*
           // 明細単位
           SalesMonthYearReportResultWork work06 = new SalesMonthYearReportResultWork();

           work06.Code = "2222";
           work06.Name = "担当者2";
           work06.SectionCode = "22";          // 3拠点コード
           work06.CompanyName1 = "拠点22";       // 4拠点ガイド名称
           work06.CustomerCode = 11111111;             // 5得意先コード
           work06.CustomerSnm = "得意1拠点22担22"; // 6得意先名称
           work06.MonthSalesMoney = 14;  // 7当月売上金額
           work06.MonthSalesRetGoodsPrice = 2;  // 8当月返品額
           work06.MonthDiscountPrice = -1;  // 9当月値引金額
           work06.MonthSalesTargetMoney = 1000; // 10当月売上目標金額
           work06.MonthGrossProfit = 200;      // 11当月粗利金額
           work06.MonthSalesTargetProfit = 300;      // 12当月売上目標粗利額
           work06.AnnualSalesMoney = 100; // 13当期売上金額
           work06.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
           work06.AnnualDiscountPrice = -10; // 15当期値引金額
           work06.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
           work06.AnnualGrossProfit = 2000; // 17当期粗利金額
           work06.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

           // 追加
           retList.Add(work06);

           // 明細単位
           SalesMonthYearReportResultWork work07 = new SalesMonthYearReportResultWork();

           work07.Code = "3333";
           work07.Name = "担当者3";
           work07.SectionCode = "33";          // 3拠点コード
           work07.CompanyName1 = "拠点33";       // 4拠点ガイド名称
           work07.CustomerCode = 33333333;             // 5得意先コード
           work07.CustomerSnm = "１２３４５６７８９０１２３４５６７８９０"; // 6得意先名称
           work07.MonthSalesMoney = 1234567890;  // 7当月売上金額
           work07.MonthSalesRetGoodsPrice = 1234567890;  // 8当月返品額
           work07.MonthDiscountPrice = -999999999;  // 9当月値引金額
           work07.MonthSalesTargetMoney = 9876543210; // 10当月売上目標金額
           work07.MonthGrossProfit = 987654321;      // 11当月粗利金額
           work07.MonthSalesTargetProfit = 987654321;      // 12当月売上目標粗利額
           work07.AnnualSalesMoney = 100; // 13当期売上金額
           work07.AnnualSalesRetGoodsPrice = 20; // 14当期返品額
           work07.AnnualDiscountPrice = -10; // 15当期値引金額
           work07.AnnualSalesTargetMoney = 10000; // 16当期売上目標金額
           work07.AnnualGrossProfit = 2000; // 17当期粗利金額
           work07.AnnualSalesTargetProfit = 3000; // 18当期売上目標粗利額

           // 追加
           retList.Add(work07);

           // 明細単位
           SalesMonthYearReportResultWork work08 = new SalesMonthYearReportResultWork();

           work08.Code = "";
           work08.Name = "";
           work08.SectionCode = "";          // 3拠点コード
           work08.CompanyName1 = "";       // 4拠点ガイド名称
           work08.CustomerCode = 0;             // 5得意先コード
           work08.CustomerSnm = ""; // 6得意先名称
           work08.MonthSalesMoney = 0;  // 7当月売上金額
           work08.MonthSalesRetGoodsPrice = 0;  // 8当月返品額
           work08.MonthDiscountPrice = 0;  // 9当月値引金額
           work08.MonthSalesTargetMoney = 0; // 10当月売上目標金額
           work08.MonthGrossProfit = 0;      // 11当月粗利金額
           work08.MonthSalesTargetProfit = 0;      // 12当月売上目標粗利額
           work08.AnnualSalesMoney = 0; // 13当期売上金額
           work08.AnnualSalesRetGoodsPrice = 0; // 14当期返品額
           work08.AnnualDiscountPrice = 0; // 15当期値引金額
           work08.AnnualSalesTargetMoney = 0; // 16当期売上目標金額
           work08.AnnualGrossProfit = 0; // 17当期粗利金額
           work08.AnnualSalesTargetProfit = 0; // 18当期売上目標粗利額

           // 追加
           retList.Add(work08);

           */

            return 0;
        }
        #endregion

        #region ■　Sort用 比較クラス関連　■
        /// <summary>
        /// 降順比較クラス（順位付けの為に使用）DEC:降順
        /// </summary>
        internal class DecreasingAnalysisOrderComparer : Comparer<Int64>
        {
            public override int Compare(Int64 x, Int64 y)
            {
                return y.CompareTo(x);
            }
        }
        /// <summary>
        /// 昇順比較クラス（順位付けの為に使用）ASC:昇順
        /// </summary>
        internal class AscendingAnalysisOrderComparer : Comparer<Int64>
        {
            public override int Compare(Int64 x, Int64 y)
            {
                return x.CompareTo(y);
            }
        }
        /// <summary>
        /// 比較クラス生成クラス
        /// </summary>
        internal class AnalysisOrderComparerCreater
        {
            public static Comparer<Int64> GetComparer(SalesMonthYearReportCndtn cndtn)
            {
                // 上位　→　降順比較クラス
                if (cndtn.OrderMethod == SalesMonthYearReportCndtn.StockOrderDivState.High)
                {
                    return new DecreasingAnalysisOrderComparer();
                }
                // 下位　→　昇順比較クラス
                else if (cndtn.OrderMethod == SalesMonthYearReportCndtn.StockOrderDivState.Low)
                {
                    return new AscendingAnalysisOrderComparer();
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

    }
}
