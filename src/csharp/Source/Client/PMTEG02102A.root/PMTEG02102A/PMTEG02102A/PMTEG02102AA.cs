//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形明細表アクセスクラス
// プログラム概要   : 手形明細表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/04/28  修正内容 : 新規作成
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 手形明細表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形明細表で使用するデータを取得する</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    public class TegataMeisaiListReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形明細表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形明細表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        public TegataMeisaiListReportAcs()
		{
            this._iTegataMeisaiListReportResultDB = (ITegataMeisaiListReportResultDB)MediationTegataMeisaiListReportResultDB.GetTegataMeisaiListReportResultDB();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 手形明細表検索インタフェース
        ITegataMeisaiListReportResultDB _iTegataMeisaiListReportResultDB;

        // DataSetオブジェクト
        private DataSet _dataSet;

        //日付取得部品
        private DateGetAcs _dateGet;

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
        #region ◎ 手形明細表データ取得
        /// <summary>
        /// 手形明細表データ取得
        /// </summary>
        /// <param name="tegataMeisaiListReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形明細表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        public int SearchTegataMeisaiListReportProcMain(TegataMeisaiListReport tegataMeisaiListReport, out string errMsg)
        {
            return this.SearchTegataMeisaiListReportProc(tegataMeisaiListReport, out errMsg);
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
        /// <param name="tegataMeisaiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形明細表データを取得する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        private int SearchTegataMeisaiListReportProc(TegataMeisaiListReport tegataMeisaiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02105EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                TegataMeisaiListReportParaWork tegataMeisaiListReportparaWork = new TegataMeisaiListReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataMeisaiListReport, out tegataMeisaiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataMeisaiListReportparaWork;
                status = _iTegataMeisaiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02105EA.ct_Tbl_TegataMeisaiListReportData], (ArrayList)retList, tegataMeisaiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02105EA.ct_Tbl_TegataMeisaiListReportData].Rows.Count < 1)
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
                        errMsg = "手形明細表の帳票出力データの取得に失敗しました。";
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
        /// <param name="tegataMeisaiListReport">UI抽出条件クラス</param>
        /// <param name="tegataMeisaiListReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        private int SetCondInfo(ref TegataMeisaiListReport tegataMeisaiListReport, out TegataMeisaiListReportParaWork tegataMeisaiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataMeisaiListReportParaWork = new TegataMeisaiListReportParaWork();
            try
            {  
                // 企業コード
                tegataMeisaiListReportParaWork.EnterpriseCode = tegataMeisaiListReport.EnterpriseCode;

                // 入金日（開始）
                tegataMeisaiListReportParaWork.DepositDateSt = tegataMeisaiListReport.DepositDateSt;

                // 入金日（終了）
                tegataMeisaiListReportParaWork.DepositDateEd = tegataMeisaiListReport.DepositDateEd;

                // 満期日（開始）
                tegataMeisaiListReportParaWork.MaturityDateSt = tegataMeisaiListReport.MaturityDateSt;

                // 満期日（終了）
                tegataMeisaiListReportParaWork.MaturityDateEd = tegataMeisaiListReport.MaturityDateEd;

                // 手形区分
                tegataMeisaiListReportParaWork.DraftDivide = tegataMeisaiListReport.DraftDivide;

                // 改頁
                tegataMeisaiListReportParaWork.ChangePageDiv = tegataMeisaiListReport.ChangePageDiv;

                // ソート順
                tegataMeisaiListReportParaWork.SortOrder = tegataMeisaiListReport.SortOrder;

                // 銀行/支店開始
                tegataMeisaiListReportParaWork.BankAndBranchCdSt = tegataMeisaiListReport.BankAndBranchCdSt;

                // 銀行/支店終了
                tegataMeisaiListReportParaWork.BankAndBranchCdEd = tegataMeisaiListReport.BankAndBranchCdEd;

                // 手形種別
                if (tegataMeisaiListReport.DraftKindCds.Length != 0)
                {
                    tegataMeisaiListReportParaWork.DraftKindCds = tegataMeisaiListReport.DraftKindCds;
                }
                else
                {
                    tegataMeisaiListReportParaWork.DraftKindCds = null;
                }

                // 手形種別名称
                tegataMeisaiListReportParaWork.DraftKindCdsHt = tegataMeisaiListReport.DraftKindCdsHt;

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
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataMeisaiListReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataMeisaiListReportResultWork rsltInfo = null;
            // 取引先コード
            string customerCode = null;
            string bankAndBranchCd = null;
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
                rsltInfo = (TegataMeisaiListReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // 手形種別
                dr[PMTEG02105EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                dr[PMTEG02105EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd];
                // 銀行支店
                dr[PMTEG02105EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02105EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // 支払日
                if (DateTime.MinValue != rsltInfo.DepositDate)
                {
                    dr[PMTEG02105EA.ct_Col_DepositDate] = rsltInfo.DepositDate.ToString("yyyy/MM/dd");
                }
                // 振出日
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02105EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // 満期日
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02105EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                    dr[PMTEG02105EA.ct_Col_ValidityTermForGroup] = dateTime.ToString("yyyy/MM/dd");
                    // サイト サイトは 振出日から満期日までの日数を印字する。
                    if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                    {
                        dr[PMTEG02105EA.ct_Col_Site] = dateTime.Subtract(rsltInfo.DraftDrawingDate).Days;
                        
                    }
                }

                // 自他区 0=自振、1=他振
                dr[PMTEG02105EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "自振" : "他振";

                // 手形番号
                dr[PMTEG02105EA.ct_Col_RcvDraftNo] = rsltInfo.RcvDraftNo;

                // 取引先名称 支払手形データの計上拠点コード、仕入先コード、仕入先略称
                dr[PMTEG02105EA.ct_Col_CustomerSnm] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode
                    + " " + rsltInfo.CustomerSnm;

                // 金額
                dr[PMTEG02105EA.ct_Col_Deposit] = rsltInfo.Deposit;
                // 摘要１
                dr[PMTEG02105EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // 摘要2
                dr[PMTEG02105EA.ct_Col_Outline2] = rsltInfo.Outline2;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
