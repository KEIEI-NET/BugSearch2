//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形期日別表アクセスクラス
// プログラム概要   : 手形期日別表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/05/05  修正内容 : 新規作成
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
    /// 手形期日別表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形期日別表で使用するデータを取得する</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataKibiListReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形期日別表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形期日別表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataKibiListReportAcs()
		{
            this._iTegataKibiListReportResultDB = (ITegataKibiListReportResultDB)MediationTegataKibiListReportResultDB.GetTegataKibiListReportResultDB();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 手形期日別表検索インタフェース
        ITegataKibiListReportResultDB _iTegataKibiListReportResultDB;

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
        #region ◎ 手形期日別表データ取得
        /// <summary>
        /// 手形期日別表データ取得
        /// </summary>
        /// <param name="TegataKibiListReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形期日別表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataKibiListReportProcMain(TegataKibiListReport tegataKibiListReport, out string errMsg)
        {
            return this.SearchTegataKibiListReportProcProc(tegataKibiListReport, out errMsg);
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
        /// <param name="TegataKibiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形期日別表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataKibiListReportProcProc(TegataKibiListReport tegataKibiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02305EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                TegataKibiListReportParaWork tegataKibiListReportparaWork = new TegataKibiListReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataKibiListReport, out tegataKibiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataKibiListReportparaWork;
                status = _iTegataKibiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02305EA.ct_Tbl_TegataKibiListReportData], (ArrayList)retList, tegataKibiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02305EA.ct_Tbl_TegataKibiListReportData].Rows.Count < 1)
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
                        errMsg = "手形期日別表の帳票出力データの取得に失敗しました。";
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
        /// <param name="TegataKibiListReport">UI抽出条件クラス</param>
        /// <param name="TegataKibiListReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataKibiListReport tegataKibiListReport, out TegataKibiListReportParaWork tegataKibiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataKibiListReportParaWork = new TegataKibiListReportParaWork();
            try
            {  
                // 企業コード
                tegataKibiListReportParaWork.EnterpriseCode = tegataKibiListReport.EnterpriseCode;

                // 銀行/支店開始
                tegataKibiListReportParaWork.BankAndBranchCdSt = tegataKibiListReport.BankAndBranchCdSt;

                // 銀行/支店終了
                tegataKibiListReportParaWork.BankAndBranchCdEd = tegataKibiListReport.BankAndBranchCdEd;

                // 印刷範囲年月
                tegataKibiListReportParaWork.SalesDate = tegataKibiListReport.SalesDate;

                // 手形種別
                if (tegataKibiListReport.DraftKindCds.Length != 0)
                {
                    tegataKibiListReportParaWork.DraftKindCds = tegataKibiListReport.DraftKindCds;
                }
                else
                {
                    tegataKibiListReportParaWork.DraftKindCds = null;
                }

                // 手形種別名称
                tegataKibiListReportParaWork.DraftKindCdsHt = tegataKibiListReport.DraftKindCdsHt;

                // 手形区分
                tegataKibiListReportParaWork.DraftDivide = tegataKibiListReport.DraftDivide;
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
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataKibiListReportParaWork paraWork)
        {
            // 指定月
            int month = 0;
            // 有効期限
            string validityTermStr = null;

            // （開始月分～６ヶ月目分）の合計値
            long[,] sumMonthGokei = new long[6, 31];
            // （開始月分～６ヶ月目分）の件数合計
            long[,] countMonthGokei = new long[6, 31];

            DataRow dr = null;
            DataRow drNew = null;
            TegataKibiListReportResultWork rsltInfo = null;
            // 銀行/支店コード
            string bankAndBranchCd = string.Empty;
            // 手形種別コード
            int draftKindCd = 0;

            // 改ページコード
            string nextPageDiv = string.Empty;

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataKibiListReportResultWork)retList[i];
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");
                draftKindCd = rsltInfo.DraftKindCd;

                // 手形種別、銀行・支店コード、有効期限で集計を行い印字する。
                if (!nextPageDiv.Equals(draftKindCd + "\\&" + bankAndBranchCd))
                {
                    if (i != 0)
                    {
                        for (int k = 0; k < 31; k++) 
                        {
                            drNew = dataTable.NewRow();
                            drNew[PMTEG02305EA.ct_Col_DraftKindName] = dr[PMTEG02305EA.ct_Col_DraftKindName];
                            drNew[PMTEG02305EA.ct_Col_BankAndBranchNm] = dr[PMTEG02305EA.ct_Col_BankAndBranchNm];
                            drNew[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode];
                            SetDataRow(ref drNew, k, sumMonthGokei, countMonthGokei);
                            dataTable.Rows.Add(drNew);
                        }
                    }
                    nextPageDiv = draftKindCd + "\\&" + bankAndBranchCd;
                    dr = dataTable.NewRow();
                    // 手形種別
                    dr[PMTEG02305EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[draftKindCd];
                    // 銀行支店
                    dr[PMTEG02305EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                        + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                    // 手形種別 + 銀行支店
                    dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = nextPageDiv;

                    sumMonthGokei = new long[6, 31];
                    countMonthGokei = new long[6, 31];
                }

                validityTermStr = rsltInfo.ValidityTerm.ToString();
                // 開始月分
                month = this.DateTimeToLongDateYM(paraWork.SalesDate);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[0, j] += rsltInfo.Deposit;
                            countMonthGokei[0, j] += 1;
                        }
                    }
                }
                // ２ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[1, j] += rsltInfo.Deposit;
                            countMonthGokei[1, j] += 1;
                        }
                    }
                }
                // ３ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[2, j] += rsltInfo.Deposit;
                            countMonthGokei[2, j] += 1;
                        }
                    }
                }
                // ４ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[3, j] += rsltInfo.Deposit;
                            countMonthGokei[3, j] += 1;
                        }
                    }
                }
                // ５ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[4, j] += rsltInfo.Deposit;
                            countMonthGokei[4, j] += 1;
                        }
                    }
                }
                // ６ヶ月目分
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // ０１日～３１日に分けて、集計する
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[5, j] += rsltInfo.Deposit;
                            countMonthGokei[5, j] += 1;
                        }
                    }
                }

                // 最後のレコード
                if (i == retList.Count - 1)
                {
                    for (int k = 0; k < 31; k++)
                    {
                        drNew = dataTable.NewRow();
                        drNew[PMTEG02305EA.ct_Col_DraftKindName] = dr[PMTEG02305EA.ct_Col_DraftKindName];
                        drNew[PMTEG02305EA.ct_Col_BankAndBranchNm] = dr[PMTEG02305EA.ct_Col_BankAndBranchNm];
                        drNew[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode];
                        SetDataRow(ref drNew, k, sumMonthGokei, countMonthGokei);
                        dataTable.Rows.Add(drNew);
                    }
                }
            }
        }
        #endregion
        
        /// <summary>
        /// datarowの設定
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="k">日付のインデックス</param>
        /// <param name="sumMonthGokei">（開始月分～６ヶ月目分）の合計値</param>
        /// <param name="countMonthGokei">（開始月分～６ヶ月目分）の件数合計</param>
        /// <remarks>
        /// <br>Note       : datarowの設定を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void SetDataRow(ref DataRow dr, int k, long[,] sumMonthGokei, long[,] countMonthGokei)
        {

            // 日付
            dr[PMTEG02305EA.ct_Col_Day] = (k + 1).ToString().PadLeft(2, '0');

            // 開始月分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth1] = sumMonthGokei[0, k];
            // ２ヶ月目分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth2] = sumMonthGokei[1, k];
            // ３ヶ月目分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth3] = sumMonthGokei[2, k];
            // ４ヶ月目分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth4] = sumMonthGokei[3, k];
            // ５ヶ月目分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth5] = sumMonthGokei[4, k];
            // ６ヶ月目分の合計
            dr[PMTEG02305EA.ct_Col_SumMonth6] = sumMonthGokei[5, k];

            // 開始月分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth1] = countMonthGokei[0, k];
            // ２ヶ月目分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth2] = countMonthGokei[1, k];
            // ３ヶ月目分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth3] = countMonthGokei[2, k];
            // ４ヶ月目分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth4] = countMonthGokei[3, k];
            // ５ヶ月目分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth5] = countMonthGokei[4, k];
            // ６ヶ月目分の件数合計
            dr[PMTEG02305EA.ct_Col_CountMonth6] = countMonthGokei[5, k];
        }

        /// <summary>
        /// LongDate DateTime 変換処理(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTimeからLongDateに変換します。</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.05.05</br>
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
        /// <br>Date       : 2010.05.05</br>
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
