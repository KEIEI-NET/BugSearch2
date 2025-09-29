//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形決済一覧表アクセスクラス
// プログラム概要   : 手形決済一覧表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 手形決済一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形決済一覧表で使用するデータを取得する</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataKessaiReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形決済一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形決済一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataKessaiReportAcs()
		{
            this._iTegataKessaiReportResultDB = (ITegataKessaiReportResultDB)MediationTegataKessaiReportResultDB.GetTegataKessaiReportResultDB();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
		}
        #endregion ■ Constructor

        #region ■ Private Member
        // 手形決済一覧表検索インタフェース
        ITegataKessaiReportResultDB _iTegataKessaiReportResultDB;

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
        #region ◎ 手形決済一覧表データ取得
        /// <summary>
        /// 手形決済一覧表データ取得
        /// </summary>
        /// <param name="tegataKessaiReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形決済一覧表データを取得する。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataKessaiReportProcMain(TegataKessaiReport tegataKessaiReport, out string errMsg)
        {
            return this.SearchTegataKessaiReportProc(tegataKessaiReport, out errMsg);
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
        /// <param name="tegataKessaiReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形決済一覧表データを取得する。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataKessaiReportProc(TegataKessaiReport tegataKessaiReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02205EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                TegataKessaiReportParaWork tegataKessaiReportparaWork = new TegataKessaiReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataKessaiReport, out tegataKessaiReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataKessaiReportparaWork;
                status = _iTegataKessaiReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02205EA.ct_Tbl_TegataKessaiReportData], (ArrayList)retList, tegataKessaiReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02205EA.ct_Tbl_TegataKessaiReportData].Rows.Count < 1)
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
                        errMsg = "手形決済一覧表の帳票出力データの取得に失敗しました。";
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
        /// <param name="tegataKessaiReport">UI抽出条件クラス</param>
        /// <param name="tegataKessaiReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataKessaiReport tegataKessaiReport, out TegataKessaiReportParaWork tegataKessaiReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataKessaiReportParaWork = new TegataKessaiReportParaWork();
            try
            {  
                // 企業コード
                tegataKessaiReportParaWork.EnterpriseCode = tegataKessaiReport.EnterpriseCode;

                // 入金/支払日（開始）
                tegataKessaiReportParaWork.DepositDateSt = tegataKessaiReport.DateSt;

                // 入金/支払日（終了）
                tegataKessaiReportParaWork.DepositDateEd = tegataKessaiReport.DateEd;

                // 満期日（開始）
                tegataKessaiReportParaWork.MaturityDateSt = tegataKessaiReport.MaturityDateSt;

                // 満期日（終了）
                tegataKessaiReportParaWork.MaturityDateEd = tegataKessaiReport.MaturityDateEd;

                // 手形区分
                tegataKessaiReportParaWork.DraftDivide = tegataKessaiReport.DraftDivide;

                // ソート順
                tegataKessaiReportParaWork.SortOrder = tegataKessaiReport.SortOrder;

                // 銀行/支店開始
                tegataKessaiReportParaWork.BankAndBranchCdSt = tegataKessaiReport.BankAndBranchCdSt;

                // 銀行/支店終了
                tegataKessaiReportParaWork.BankAndBranchCdEd = tegataKessaiReport.BankAndBranchCdEd;

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
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataKessaiReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataKessaiReportResultWork rsltInfo = null;
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
                rsltInfo = (TegataKessaiReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // 手形種別
                dr[PMTEG02205EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                if (rsltInfo.DraftKindCd == 0)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "手持手形";
                } 
                else if (rsltInfo.DraftKindCd == 1)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "取立手形";
                } 
                else if (rsltInfo.DraftKindCd == 2)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "割引手形";
                }
                else if (rsltInfo.DraftKindCd == 3)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "譲渡手形";
                }
                else if (rsltInfo.DraftKindCd == 4)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "担保手形";
                }
                else if (rsltInfo.DraftKindCd == 5)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "不渡手形";
                }
                else if (rsltInfo.DraftKindCd == 6)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "支払手形";
                }
                else if (rsltInfo.DraftKindCd == 7)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "先付手形";
                }
                else if (rsltInfo.DraftKindCd == 9)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "決済手形";
                }
             
                // 銀行支店
                dr[PMTEG02205EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02205EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // 入金/支払日
                if (DateTime.MinValue != rsltInfo.DepositDate)
                {
                    dr[PMTEG02205EA.ct_Col_Date] = rsltInfo.DepositDate.ToString("yyyy/MM/dd");
                }
                // 振出日
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02205EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // 満期日
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02205EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                    dr[PMTEG02205EA.ct_Col_ValidityTermForGroup] = dateTime.ToString("yyyy/MM/dd");
                }

                // 自他区 0=自振、1=他振
                dr[PMTEG02205EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "自振" : "他振";

                // 手形番号
                dr[PMTEG02205EA.ct_Col_DraftNo] = rsltInfo.RcvDraftNo;

                // 取引先名称
                dr[PMTEG02205EA.ct_Col_CustomerSnm] = rsltInfo.CustomerSnm;

                // 取引先コード
                dr[PMTEG02205EA.ct_Col_CustomerCode] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode;
                // 金額
                dr[PMTEG02205EA.ct_Col_Amount] = rsltInfo.Deposit;
                // 摘要１
                dr[PMTEG02205EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // 摘要2
                dr[PMTEG02205EA.ct_Col_Outline2] = rsltInfo.Outline2;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
