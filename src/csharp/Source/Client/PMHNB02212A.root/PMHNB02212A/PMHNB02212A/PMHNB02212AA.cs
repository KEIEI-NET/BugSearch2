//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧アクセスクラス
// プログラム概要   : 返品理由一覧で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/12  修正内容 : 新規作成
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 返品理由一覧アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧で使用するデータを取得する</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.06.26</br>
    /// </remarks>
    public class RetGoodsReasonReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 返品理由一覧アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 返品理由一覧アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        public RetGoodsReasonReportAcs()
		{
            this._iRetGoodsReasonReportResultDB = (IRetGoodsReasonReportResultDB)MediationRetGoodsReasonReportResultDB.GetRetGoodsReasonReportResultDB();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 返品理由一覧検索インタフェース
        IRetGoodsReasonReportResultDB _iRetGoodsReasonReportResultDB;

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
        #region ◎ 返品理由一覧データ取得
        /// <summary>
        /// 返品理由一覧データ取得
        /// </summary>
        /// <param name="henbiRiyuListReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する返品理由一覧データを取得する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        public int SearchRetGoodsReasonReportProcMain(HenbiRiyuListReport henbiRiyuListReport, out string errMsg)
        {
            return this.SearchRetGoodsReasonReportProcProc(henbiRiyuListReport, out errMsg);
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
        /// <param name="henbiRiyuListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する返品理由一覧データを取得する。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        private int SearchRetGoodsReasonReportProcProc(HenbiRiyuListReport henbiRiyuListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02215EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                RetGoodsReasonReportParaWork retGoodReasonReportparaWork = new RetGoodsReasonReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref henbiRiyuListReport, out retGoodReasonReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = retGoodReasonReportparaWork;
                status = _iRetGoodsReasonReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData], (ArrayList)retList, retGoodReasonReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData].Rows.Count < 1)
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
                        errMsg = "返品理由一覧表の帳票出力データの取得に失敗しました。";
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
        /// <param name="henbiRiyuListReport">UI抽出条件クラス</param>
        /// <param name="retGoodsReasonReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        private int SetCondInfo(ref HenbiRiyuListReport henbiRiyuListReport, out RetGoodsReasonReportParaWork retGoodsReasonReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            retGoodsReasonReportParaWork = new RetGoodsReasonReportParaWork();
            try
            {  
                // 企業コード
                retGoodsReasonReportParaWork.EnterpriseCode = henbiRiyuListReport.EnterpriseCode; 
 
                // 拠点
                if (henbiRiyuListReport.SectionCodes.Length != 0)
                {
                    if (henbiRiyuListReport.IsSelectAllSection)
                    {
                        // 全社の時
                        retGoodsReasonReportParaWork.SectionCodes = null;
                    }
                    else
                    {
                        retGoodsReasonReportParaWork.SectionCodes = henbiRiyuListReport.SectionCodes;
                    }
                }
                else
                {
                    retGoodsReasonReportParaWork.SectionCodes = null;
                }

                // 得意先コード（開始）
                retGoodsReasonReportParaWork.CustomerCodeSt = henbiRiyuListReport.CustomerCodeSt;

                // 得意先コード（終了）
                retGoodsReasonReportParaWork.CustomerCodeEd = henbiRiyuListReport.CustomerCodeEd;

                // 担当者コード（開始）
                retGoodsReasonReportParaWork.SalesEmployeeCdRFSt = henbiRiyuListReport.SalesEmployeeCdRFSt;

                // 担当者コード（終了）
                retGoodsReasonReportParaWork.SalesEmployeeCdRFEd = henbiRiyuListReport.SalesEmployeeCdRFEd;

                // 受注者コード（開始）
                retGoodsReasonReportParaWork.FrontEmployeeCdRFSt = henbiRiyuListReport.FrontEmployeeCdRFSt;

                // 受注者コード（終了）
                retGoodsReasonReportParaWork.FrontEmployeeCdRFEd = henbiRiyuListReport.FrontEmployeeCdRFEd;

                // 発行者コード（開始）
                retGoodsReasonReportParaWork.SalesInputCdRFSt = henbiRiyuListReport.SalesInputCdRFSt;

                // 発行者コード（終了）
                retGoodsReasonReportParaWork.SalesInputCdRFEd = henbiRiyuListReport.SalesInputCdRFEd;

                // 返品理由コード（開始）
                retGoodsReasonReportParaWork.RetGoodsReasonDivSt = henbiRiyuListReport.RetGoodsReasonDivSt;

                // 返品理由コード（終了）
                retGoodsReasonReportParaWork.RetGoodsReasonDivEd = henbiRiyuListReport.RetGoodsReasonDivEd;

                // 前回締処理日（開始）
                retGoodsReasonReportParaWork.PrevTotalDay = henbiRiyuListReport.PrevTotalDay;

                // 今回締処理日
                retGoodsReasonReportParaWork.CurrentTotalDay = henbiRiyuListReport.CurrentTotalDay;

                // 年度開始日
                retGoodsReasonReportParaWork.StartYearDate = henbiRiyuListReport.StartYearDate;

                // 年度終了日
                retGoodsReasonReportParaWork.EndYearDate = henbiRiyuListReport.EndYearDate;

                // 出力順
                retGoodsReasonReportParaWork.PrintType = henbiRiyuListReport.PrintType;

                //伝票種別
                retGoodsReasonReportParaWork.SlipKindCd = henbiRiyuListReport.SlipKindCd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        ///// <summary>
        ///// 年月取得処理（YYYYMM ← DateTime）
        ///// </summary>
        ///// <param name="dateTime"></param>
        ///// <returns></returns>
        //private int GetYearMonthFromDateTime(DateTime dateTime)
        //{
        //    // 年月をYYYYMMのintで返す
        //    return (dateTime.Year * 100 + dateTime.Month);
        //}
        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, RetGoodsReasonReportParaWork paraWork)
        {
            for (int i = 0; i < retList.Count; i++)
            {
                RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                DataRow dr = null;
                dr = dataTable.NewRow();
                // 拠点コード
                dr[PMHNB02215EA.ct_Col_SectionCode] = rsltInfo.ResultsAddUpSecCd.PadLeft(2,'0');
                // 拠点名称
                dr[PMHNB02215EA.ct_Col_SectionName] = rsltInfo.SectionName;
                // 得意先コード
                if (0 == rsltInfo.CustomerCode)
                {
                    dr[PMHNB02215EA.ct_Col_CustomerCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02215EA.ct_Col_CustomerCode] = rsltInfo.CustomerCode.ToString("D8");
                }
                // 得意先名称
                dr[PMHNB02215EA.ct_Col_CustomerName] = rsltInfo.CustomerName;
                // 担当者コード
                dr[PMHNB02215EA.ct_Col_SalesEmployeeCd] = rsltInfo.SalesEmployeeCd.PadLeft(4, '0');
                // 担当者名称
                dr[PMHNB02215EA.ct_Col_SalesEmployeeNm] = rsltInfo.SalesEmployeeNm;
                // 受注者コード
                dr[PMHNB02215EA.ct_Col_FrontEmployeeCd] = rsltInfo.FrontEmployeeCd.PadLeft(4, '0');
                // 受注者名称
                dr[PMHNB02215EA.ct_Col_FrontEmployeeNm] = rsltInfo.FrontEmployeeNm;
                // 発行者コード
                dr[PMHNB02215EA.ct_Col_SalesInputCode] = rsltInfo.SalesInputCode.PadLeft(4, '0');
                // 発行者名称
                dr[PMHNB02215EA.ct_Col_SalesInputName] = rsltInfo.SalesInputName;

                // 返品理由コード
                if (0 == rsltInfo.RetGoodsReasonDiv)
                {
                    dr[PMHNB02215EA.ct_Col_RetGoodsReasonDiv] = rsltInfo.RetGoodsReasonDiv.ToString("D4");
                    // 返品理由コード = 0 と返品理由名称は空白の場合
                    if (string.IsNullOrEmpty(rsltInfo.RetGoodsReason))
                    {
                        dr[PMHNB02215EA.ct_Col_RetGoodsReason] = "未登録";
                    }
                    else
                    {
                        dr[PMHNB02215EA.ct_Col_RetGoodsReason] = rsltInfo.RetGoodsReason;
                    }
                }
                else
                {
                    dr[PMHNB02215EA.ct_Col_RetGoodsReasonDiv] = rsltInfo.RetGoodsReasonDiv;
                    // 返品理由名称
                    dr[PMHNB02215EA.ct_Col_RetGoodsReason] = rsltInfo.RetGoodsReason;
                }
                // 種別
                dr[PMHNB02215EA.ct_Col_SlipKind] = rsltInfo.SlipKind;
                // 金額
                dr[PMHNB02215EA.ct_Col_MoneySum] = rsltInfo.SalesTotalTaxExc;
                // 件数
                dr[PMHNB02215EA.ct_Col_Count] = rsltInfo.Count;
                // 比率
                int printType = paraWork.PrintType;
                CountRate(dr, retList, printType);
                // 売上行番号
                SetSlipKey(dr, retList, printType);
                // 詳細
                SetDetailInfo(dr, retList, printType);

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        /// <summary>
        /// 比率を設定処理
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="printType">出力順</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void CountRate(DataRow dr, ArrayList retList, int printType)
        {   
            // 金額
            long currMoney = (long)dr[PMHNB02215EA.ct_Col_MoneySum];
            // 集計金額(得意先計、担当者計、受注者計、発行者計)
            long detailMoney =0;
            // 集計金額(拠点計)
            long secMoney = 0;
            // 集計金額(総合計)
            long sumMoney = 0;
            // 返品理由
            if (0 == printType)
            {
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // 集計金額
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                        secMoney += rsltInfo.SalesTotalTaxExc; 
                    }
                }

            }
            // 得意先
            else if (1 == printType)
            {
                string customer = dr[PMHNB02215EA.ct_Col_CustomerCode].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // 集計金額
                for (int i = 0; i < retList.Count; i++)
                {
                  RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                  string currCustomer = rsltInfo.CustomerCode.ToString("D8");
                  string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                  sumMoney += rsltInfo.SalesTotalTaxExc;
                  if (currCustomer.Equals(customer) && currSection.Equals(section))
                  {
                      detailMoney += rsltInfo.SalesTotalTaxExc;
                  }
                  if (currSection.Equals(section))
                  {
                      secMoney += rsltInfo.SalesTotalTaxExc;
                  }
                }

            }
            // 担当者
            else if (2 == printType)
            {
                string salesEmployee = dr[PMHNB02215EA.ct_Col_SalesEmployeeCd].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // 集計金額
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSalesEmployee = rsltInfo.SalesEmployeeCd.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSalesEmployee.Equals(salesEmployee) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // 受注者
            else if (3 == printType)
            {
                string frontEmployee = dr[PMHNB02215EA.ct_Col_FrontEmployeeCd].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // 集計金額
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currFrontEmployee = rsltInfo.FrontEmployeeCd.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currFrontEmployee.Equals(frontEmployee) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // 発行者
            else if (4 == printType)
            {
                string salesInput = dr[PMHNB02215EA.ct_Col_SalesInputCode].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // 集計金額
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSalesInput = rsltInfo.SalesInputCode.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSalesInput.Equals(salesInput) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // 比率
            if (0 == currMoney || 0 == detailMoney)
            {
                dr[PMHNB02215EA.ct_Col_Rate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_Rate] = (double)((decimal)currMoney / (decimal)detailMoney * 100);
            }
            // 比率(得意先計、担当者計、受注者計、発行者計)
            if (0 == detailMoney || 0 == secMoney)
            {
                dr[PMHNB02215EA.ct_Col_DetailRate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_DetailRate] = (double)((decimal)detailMoney / (decimal)secMoney * 100);
            }
            // 比率(拠点計)
            if (0 == secMoney || 0 == sumMoney)
            {
                dr[PMHNB02215EA.ct_Col_SectionRate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_SectionRate] = (double)((decimal)secMoney / (decimal)sumMoney * 100);

            }
            
        }

        /// <summary>
        /// キーを設定処理
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="printType">出力順</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void　SetSlipKey(DataRow dr, ArrayList retList, int printType)
        {
            switch (printType)
            {
                case (0):// 返品理由
                    {
                        
                    }
                    break;
                case (1):// 得意先
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_CustomerCode].ToString().Trim();
                    }
                    break;
                case (2):// 担当者
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_SalesEmployeeCd].ToString().Trim();
                    }
                    break;
                case (3):// 受注者
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_FrontEmployeeCd].ToString().Trim();
                    }
                    break;
                case (4):// 発行者
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_SalesInputCode].ToString().Trim();
                    }
                    break;
            }

        }

        /// <summary>
        /// 出力順により詳細を設定処理
        /// </summary>
        /// <param name="dr">行データ</param>
        /// <param name="retList">検索情報リスト</param>
        /// <param name="printType">出力順</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SetDetailInfo(DataRow dr, ArrayList retList, int printType)
        {
            switch (printType)
            {
                case (0):// 返品理由
                    {

                    }
                    break;
                case (1):// 得意先
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_CustomerCode];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_CustomerName];
                    }
                    break;
                case (2):// 担当者
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_SalesEmployeeCd];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_SalesEmployeeNm];
                    }
                    break;
                case (3):// 受注者
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_FrontEmployeeCd];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_FrontEmployeeNm];
                    }
                    break;
                case (4):// 発行者
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_SalesInputCode];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_SalesInputName];
                    }
                    break;
            }

        }

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
