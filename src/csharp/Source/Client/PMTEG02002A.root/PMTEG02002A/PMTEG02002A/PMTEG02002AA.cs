//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形確認表アクセスクラス
// プログラム概要   : 手形確認表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/05/05  修正内容 : 新規作成
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
    /// 手形確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形確認表で使用するデータを取得する</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataConfirmReportAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 手形確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 手形確認表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataConfirmReportAcs()
		{
            this._iTegataConfirmReportResultDB = (ITegataConfirmReportResultDB)MediationTegataConfirmReportResultDB.GetTegataConfirmReportResultDB();
            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();
            // 手形種別名称の設定
            _draftKindCdsHt = new Hashtable();
            _draftKindCdsHt.Add(0, "手持手形");
            _draftKindCdsHt.Add(1, "取立手形");
            _draftKindCdsHt.Add(2, "割引手形");
            _draftKindCdsHt.Add(3, "譲渡手形");
            _draftKindCdsHt.Add(4, "担保手形");
            _draftKindCdsHt.Add(5, "不渡手形");
            _draftKindCdsHt.Add(6, "支払手形");
            _draftKindCdsHt.Add(7, "先付手形");
            _draftKindCdsHt.Add(9, "決済手形");
		}

        #endregion ■ Constructor

        #region ■ Private Member
        // 手形確認表検索インタフェース
        ITegataConfirmReportResultDB _iTegataConfirmReportResultDB;

        // DataSetオブジェクト
        private DataSet _dataSet;

        // 手形種別名称
        private Hashtable _draftKindCdsHt;

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
        #region ◎ 手形確認表データ取得
        /// <summary>
        /// 手形確認表データ取得
        /// </summary>
        /// <param name="tegataConfirmReport">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形確認表データを取得する。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataConfirmReportProcMain(TegataConfirmReport tegataConfirmReport, out string errMsg)
        {
            return this.SearchTegataConfirmReportProc(tegataConfirmReport, out errMsg);
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
        /// <param name="tegataConfirmReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する手形確認表データを取得する。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataConfirmReportProc(TegataConfirmReport tegataConfirmReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02005EA.CreateDataTable(ref _dataSet);

                // 抽出条件展開  --------------------------------------------------------------
                TegataConfirmReportParaWork tegataConfirmReportparaWork = new TegataConfirmReportParaWork();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataConfirmReport, out tegataConfirmReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataConfirmReportparaWork;
                status = _iTegataConfirmReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02005EA.ct_Tbl_TegataConfirmReportData], (ArrayList)retList, tegataConfirmReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02005EA.ct_Tbl_TegataConfirmReportData].Rows.Count < 1)
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
                        errMsg = "手形確認表の帳票出力データの取得に失敗しました。";
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
        /// <param name="tegataConfirmReport">UI抽出条件クラス</param>
        /// <param name="tegataConfirmReportParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataConfirmReport tegataConfirmReport, out TegataConfirmReportParaWork tegataConfirmReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataConfirmReportParaWork = new TegataConfirmReportParaWork();
            try
            {  
                // 企業コード
                tegataConfirmReportParaWork.EnterpriseCode = tegataConfirmReport.EnterpriseCode;

                // 入金日（開始）
                tegataConfirmReportParaWork.DepositDateSt = tegataConfirmReport.DepositDateSt;

                // 入金日（終了）
                tegataConfirmReportParaWork.DepositDateEd = tegataConfirmReport.DepositDateEd;

                // 手形区分
                tegataConfirmReportParaWork.DraftDivide = tegataConfirmReport.DraftDivide;

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
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataConfirmReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataConfirmReportResultWork rsltInfo = null;
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
                rsltInfo = (TegataConfirmReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // 手形種別
                dr[PMTEG02005EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                dr[PMTEG02005EA.ct_Col_DraftKindName] = (string)this._draftKindCdsHt[rsltInfo.DraftKindCd];
                // 銀行支店
                dr[PMTEG02005EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02005EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // 支払日
                if (DateTime.MinValue != rsltInfo.Date)
                {
                    dr[PMTEG02005EA.ct_Col_DepositDate] = rsltInfo.Date.ToString("yyyy/MM/dd");
                }
                // 振出日
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02005EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // 満期日
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02005EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                }

                // 自他区 0=自振、1=他振
                dr[PMTEG02005EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "自振" : "他振";

                // 手形番号
                dr[PMTEG02005EA.ct_Col_RcvDraftNo] = rsltInfo.DraftNo;

                // 取引先名称 支払手形データの計上拠点コード、仕入先コード、仕入先略称
                dr[PMTEG02005EA.ct_Col_CustomerSnm] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode
                    + " " + rsltInfo.CustomerSnm;

                // 金額
                dr[PMTEG02005EA.ct_Col_Deposit] = rsltInfo.DepositOrPayment;
                // 摘要１
                dr[PMTEG02005EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // 摘要2
                dr[PMTEG02005EA.ct_Col_Outline2] = rsltInfo.Outline2;
                // 伝票番号
                dr[PMTEG02005EA.ct_Col_SlipNo] = rsltInfo.SlipNo.ToString();

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
