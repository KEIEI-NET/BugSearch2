//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形取引先別表アクセスクラス
// プログラム概要   : 手形取引先別表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 手形取引先別表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形取引先別表で使用するデータを取得する</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class TegataTorihikisakiListReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形取引先別表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形取引先別表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        public TegataTorihikisakiListReportAcs()
		{
            this._iTegataTorihikisakiListReportResultDB = (ITegataTorihikisakiListReportResultDB)MediationTegataTorihikisakiListReportResultDB.GetTegataTorihikisakiListReportResultDB();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 手形取引先別表検索インタフェース
        ITegataTorihikisakiListReportResultDB _iTegataTorihikisakiListReportResultDB;

        // DataSetオブジェクト
        private DataSet _dataSet;

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 手形取引先別表データ取得
        /// <summary>
        /// 手形取引先別表データ取得
        /// </summary>
        /// <param name="tegataTorihikisakiListReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形取引先別表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        public int SearchTegataTorihikisakiListReportProcMain(TegataTorihikisakiListReport tegataTorihikisakiListReport, out string errMsg)
        {
            return this.SearchTegataTorihikisakiListReportProcProc(tegataTorihikisakiListReport, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="tegataTorihikisakiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形取引先別表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        private int SearchTegataTorihikisakiListReportProcProc(TegataTorihikisakiListReport tegataTorihikisakiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02505EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                TegataTorihikisakiListReportParaWork tegataTorihikisakiListReportparaWork = new TegataTorihikisakiListReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataTorihikisakiListReport, out tegataTorihikisakiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataTorihikisakiListReportparaWork;
                status = _iTegataTorihikisakiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02505EA.ct_Tbl_TegataTorihikisakiListReportData], (ArrayList)retList, tegataTorihikisakiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02505EA.ct_Tbl_TegataTorihikisakiListReportData].Rows.Count < 1)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "手形取引先別表の帳票出力データの取得に失敗しました。";
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

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="tegataTorihikisakiListReport">UI抽出条件クラス</param>
        /// <param name="tegataTorihikisakiListReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        private int SetCondInfo(ref TegataTorihikisakiListReport tegataTorihikisakiListReport, out TegataTorihikisakiListReportParaWork tegataTorihikisakiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataTorihikisakiListReportParaWork = new TegataTorihikisakiListReportParaWork();
            try
            {  
                // 企業コード
                tegataTorihikisakiListReportParaWork.EnterpriseCode = tegataTorihikisakiListReport.EnterpriseCode; 
 
                // 拠点
                if (tegataTorihikisakiListReport.SectionCodes.Length != 0)
                {
                    if (tegataTorihikisakiListReport.IsSelectAllSection)
                    {
                        // 全社の時
                        tegataTorihikisakiListReportParaWork.SectionCodes = null;
                    }
                    else
                    {
                        tegataTorihikisakiListReportParaWork.SectionCodes = tegataTorihikisakiListReport.SectionCodes;
                    }
                }
                else
                {
                    tegataTorihikisakiListReportParaWork.SectionCodes = null;
                }

                // 取引先コード（開始）
                tegataTorihikisakiListReportParaWork.CustomerCodeSt = tegataTorihikisakiListReport.CustomerCodeSt;

                // 取引先コード（終了）
                tegataTorihikisakiListReportParaWork.CustomerCodeEd = tegataTorihikisakiListReport.CustomerCodeEd;

                // 印刷範囲年月
                tegataTorihikisakiListReportParaWork.SalesDate = tegataTorihikisakiListReport.SalesDate;

                // 印刷タイプ
                tegataTorihikisakiListReportParaWork.PrintType = tegataTorihikisakiListReport.PrintType;

                // 手形区分
                tegataTorihikisakiListReportParaWork.DraftDivide = tegataTorihikisakiListReport.DraftDivide;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
        /// <br>Note       : DataTableにデータを設定処理を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataTorihikisakiListReportParaWork paraWork)
        {
            string nextCustomerCode = string.Empty;
            // 指定月
            int month = 0;

            // （開始月分～６ヶ月目分）と６ヶ月以降の合計値
            long[] sumMonthGokei = new long[7];
            // （開始月分～６ヶ月目分）と６ヶ月以降の合計値(手形区分＝「0：自振」)
            long[] sumMonthSelf = new long[7];
            // （開始月分～６ヶ月目分）と６ヶ月以降の合計値(手形区分＝「1：他振」)
            long[] sumMonthElse = new long[7];

            DataRow dr = null;
            TegataTorihikisakiListReportResultWork rsltInfo = null;
            // 取引先コード
            string customerCode = null;
            string formatStr = null;
            // 受取手形
            if (paraWork.DraftDivide == 0)
            {
                formatStr = "D8";
            }
            // 支払手形
            else
            {
                formatStr = "D6";
            }

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataTorihikisakiListReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);

                // 拠点コード、得意先コード、有効期限で集計を行い印字する。
                if (!nextCustomerCode.Equals(rsltInfo.SectionCode.Trim().PadLeft(2, '0') + "-" + customerCode))
                {
                    if (i != 0)
                    {
                        SetDataRow(ref dr, sumMonthGokei, sumMonthSelf, sumMonthElse);
                        dataTable.Rows.Add(dr);
                    }
                    nextCustomerCode = rsltInfo.SectionCode.Trim().PadLeft(2, '0') + "-" + customerCode;
                    dr = dataTable.NewRow();

                    // 拠点コード
                    dr[PMTEG02505EA.ct_Col_SectionCode] = rsltInfo.SectionCode.PadLeft(2, '0');
                    // 取引先コード
                    if (0 == rsltInfo.CustomerCode)
                    {
                        dr[PMTEG02505EA.ct_Col_CustomerCode] = string.Empty;
                    }
                    else
                    {
                        dr[PMTEG02505EA.ct_Col_CustomerCode] = nextCustomerCode;
                    }
                    // 取引先名称
                    dr[PMTEG02505EA.ct_Col_CustomerName] = rsltInfo.CustomerSnm;

                    sumMonthGokei = new long[7];
                    sumMonthSelf = new long[7];
                    sumMonthElse = new long[7];
                }

                // 開始月分
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == (this.DateTimeToLongDateYM(paraWork.SalesDate)).ToString())
                {
                    sumMonthGokei[0] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0) 
                        sumMonthSelf[0] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[0] += rsltInfo.Deposit; 
                }
                // ２ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[1] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[1] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[1] += rsltInfo.Deposit; 
                }
                // ３ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[2] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[2] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[2] += rsltInfo.Deposit; 
                }
                // ４ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[3] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[3] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[3] += rsltInfo.Deposit; 
                }
                // ５ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[4] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[4] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[4] += rsltInfo.Deposit; 
                }
                // ６ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[5] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[5] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[5] += rsltInfo.Deposit; 
                }
                // ６ヶ月以降分
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6).CompareTo(month.ToString()) > 0)
                {
                    sumMonthGokei[6] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[6] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[6] += rsltInfo.Deposit; 
                }

                // 最後のレコード
                if (i == retList.Count - 1)
                {
                    SetDataRow(ref dr, sumMonthGokei, sumMonthSelf, sumMonthElse);
                    dataTable.Rows.Add(dr);
                }
            }
        }
        #endregion
        
        /// <summary>
        /// datarowの設定
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="sumMonthGokei">（開始月分～６ヶ月目分）と６ヶ月以降の合計値</param>
        /// <param name="sumMonthSelf">（開始月分～６ヶ月目分）と６ヶ月以降の合計値(手形区分＝「0：自振」)</param>
        /// <param name="sumMonthElse">（開始月分～６ヶ月目分）と６ヶ月以降の合計値(手形区分＝「1：他振」)</param>
        /// <remarks>
        /// <br>Note       : datarowの設定を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void SetDataRow(ref DataRow dr, long[] sumMonthGokei, long[] sumMonthSelf, long[] sumMonthElse)
        {
            // 開始月分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth1] = sumMonthGokei[0];
            // ２ヶ月目分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth2] = sumMonthGokei[1];
            // ２ヶ月目分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth3] = sumMonthGokei[2];
            // ２ヶ月目分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth4] = sumMonthGokei[3];
            // ２ヶ月目分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth5] = sumMonthGokei[4];
            // ２ヶ月目分の合計
            dr[PMTEG02505EA.ct_Col_SumMonth6] = sumMonthGokei[5];
            // ６ヶ月以降分の合計
            dr[PMTEG02505EA.ct_Col_SumMonthSpare] = sumMonthGokei[6];
            // 合計
            dr[PMTEG02505EA.ct_Col_SumMonthAll] = sumMonthGokei[0] + sumMonthGokei[1] + sumMonthGokei[2] + sumMonthGokei[3] + sumMonthGokei[4] + sumMonthGokei[5] + sumMonthGokei[6];

            // 開始月分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth1Self] = sumMonthSelf[0];
            // ２ヶ月目分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth2Self] = sumMonthSelf[1];
            // ２ヶ月目分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth3Self] = sumMonthSelf[2];
            // ２ヶ月目分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth4Self] = sumMonthSelf[3];
            // ２ヶ月目分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth5Self] = sumMonthSelf[4];
            // ２ヶ月目分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonth6Self] = sumMonthSelf[5];
            // ６ヶ月以降分の合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonthSpareSelf] = sumMonthSelf[6];
            // 合計(自振)
            dr[PMTEG02505EA.ct_Col_SumMonthAllSelf] = sumMonthSelf[0] + sumMonthSelf[1] + sumMonthSelf[2] + sumMonthSelf[3] + sumMonthSelf[4] + sumMonthSelf[5] + sumMonthSelf[6];

            // 開始月分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth1Else] = sumMonthElse[0];
            // ２ヶ月目分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth2Else] = sumMonthElse[1];
            // ２ヶ月目分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth3Else] = sumMonthElse[2];
            // ２ヶ月目分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth4Else] = sumMonthElse[3];
            // ２ヶ月目分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth5Else] = sumMonthElse[4];
            // ２ヶ月目分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonth6Else] = sumMonthElse[5];
            // ６ヶ月以降分の合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonthSpareElse] = sumMonthElse[6];
            // 合計(他振)
            dr[PMTEG02505EA.ct_Col_SumMonthAllElse] = sumMonthElse[0] + sumMonthElse[1] + sumMonthElse[2] + sumMonthElse[3] + sumMonthElse[4] + sumMonthElse[5] + sumMonthElse[6];
        }

        /// <summary>
        /// LongDate DateTime 変換処理(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTimeからLongDateに変換します。</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int DateTimeToLongDateYM(DateTime dt)
        {
            return TDateTime.DateTimeToLongDate("YYYYMM", dt);
        }

        /// <summary>
        /// 年月計算処理
        /// </summary>
        /// <param name="yearMonth">計算前年月</param>
        /// <param name="monthes">加算(減算)月数</param>
        /// <returns>計算後年月</returns>
        /// <remarks>
        /// <br>Note       : 指定された月数を加算した年月を返します。</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int CalculateYearMonth(int yearMonth, int monthes)
        {
            int resultYearMonth = 0;

            // 一旦月に変換
            int wkMonth = (yearMonth / 100) * 12 + (yearMonth % 100) - 1;

            // 加算(減算)月数を反映
            wkMonth += monthes;

            // 年月に戻す
            resultYearMonth = (wkMonth / 12) * 100 + wkMonth % 12 + 1;

            return resultYearMonth;
        }

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
