//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 未入金一覧表アクセスクラス
// プログラム概要   : 未入金一覧表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 作 成 日  2010/12/20  修正内容 : 帳票レイアウト上の日付項目を売上日項目と入力日項目に分ける
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
    /// 未入金一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 未入金一覧表で使用するデータを取得する</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2010/07/01</br>
    /// </remarks>
    public class NoDepSalListAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 未入金一覧表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 未入金一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public NoDepSalListAcs()
        {
            this._iClaimSalesReadDB = (IClaimSalesReadDB)MediationClaimSalesReadDB.GetClaimSalesReadDB();
        }

        #endregion ■ Constructor

        #region ■ Private Member
        // 未入金一覧表検索インタフェース
        IClaimSalesReadDB _iClaimSalesReadDB;

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
        #region ◎ 未入金一覧表データ取得
        /// <summary>
        /// 未入金一覧表データ取得
        /// </summary>
        /// <param name="noDepSalListCdtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する未入金一覧表データを取得する。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public int SearchNoDepSalListProcMain( NoDepSalListCdtn noDepSalListCdtn, out string errMsg )
        {
            return this.SearchNoDepSalListProc( noDepSalListCdtn, out errMsg );
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
        /// <param name="noDepSalListCdtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する未入金一覧表データを取得する。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SearchNoDepSalListProc( NoDepSalListCdtn noDepSalListCdtn, out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKAU02005EA.CreateDataTable( ref _dataSet );

                // 抽出条件展開  --------------------------------------------------------------
                SearchParaClaimSalesRead paraWork = new SearchParaClaimSalesRead();
                // 画面検索情報->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo( ref noDepSalListCdtn, out paraWork, out errMsg );

                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = paraWork;
                status = _iClaimSalesReadDB.Search( out retList, paraWorkRef, 0, ConstantManagement.LogicalMode.GetData0 );

                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        ConverToDataSetForPdf( _dataSet.Tables[PMKAU02005EA.ct_Tbl_NoDepSalListData], (ArrayList)retList, noDepSalListCdtn );
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if ( this._dataSet.Tables[PMKAU02005EA.ct_Tbl_NoDepSalListData].Rows.Count < 1 )
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
                        errMsg = "未入金一覧表の帳票出力データの取得に失敗しました。";
                        break;
                }
            }
            catch ( Exception ex )
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
        /// <param name="noDepSalListCdtn">UI抽出条件クラス</param>
        /// <param name="paraWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SetCondInfo( ref NoDepSalListCdtn noDepSalListCdtn, out SearchParaClaimSalesRead paraWork, out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            paraWork = new SearchParaClaimSalesRead();
            try
            {
                // 企業コード
                paraWork.EnterpriseCode = noDepSalListCdtn.EnterpriseCode;

                // 日付（売上日or入力日）
                if ( noDepSalListCdtn.TargetDateDiv == 0 )
                {
                    // 売上日（開始）
                    paraWork.SearchSlipDateStart = noDepSalListCdtn.DateSt;
                    // 売上日（終了）
                    paraWork.SearchSlipDateEnd = noDepSalListCdtn.DateEd;
                }
                else
                {
                    // 入力日（開始）
                    paraWork.InputDateStart = noDepSalListCdtn.DateSt;
                    // 入力日（終了）
                    paraWork.InputDateEnd = noDepSalListCdtn.DateEd;
                }

                // 請求拠点コード（開始）
                paraWork.DemandAddUpSecCdStart = noDepSalListCdtn.DemandAddUpSecCdSt;
                // 請求拠点コード（終了）
                paraWork.DemandAddUpSecCdEnd = noDepSalListCdtn.DemandAddUpSecCdEd;
                // 請求得意先コード（開始）
                paraWork.ClaimCodeStart = noDepSalListCdtn.ClaimCodeSt;
                // 請求得意先コード（終了）
                paraWork.ClaimCodeEnd = noDepSalListCdtn.ClaimCodeEd;


                // 売掛区分を条件に含めない
                paraWork.AccRecDivCd = -1;

                // 自動入金を条件に含めない
                paraWork.AutoDepositCd = -1;

                // 未引当(部分引当済み含む)のみ
                paraWork.AlwcSalesSlipCall = 1;

                // 受注ステータス＝30:売上のみ
                paraWork.AcptAnOdrStatus = new int[] { 30 };
            }
            catch ( Exception ex )
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
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>            帳票レイアウト上の日付項目を売上日項目と入力日項目に分ける</br>
        /// </remarks>
        private void ConverToDataSetForPdf( DataTable dataTable, ArrayList retList, NoDepSalListCdtn paraWork )
        {

            DataRow row = null;

            foreach ( SearchClaimSalesWork retWork in retList )
            {
                row = dataTable.NewRow();

                # region [row←retWork]
                row[PMKAU02005EA.ct_Col_DemandAddUpSecCd] = retWork.DemandAddUpSecCd.Trim();
                row[PMKAU02005EA.ct_Col_DemandAddUpSecNm] = retWork.DemandAddUpSecNm;
                row[PMKAU02005EA.ct_Col_ClaimCode] = retWork.ClaimCode;
                row[PMKAU02005EA.ct_Col_ClaimSnm] = retWork.ClaimSnm;
                //row[PMKAU02005EA.ct_Col_SalesDate] = this.GetTargetDate( retWork, paraWork ).ToString( "yyyy/MM/dd" );// DEL 2010/12/17
                row[PMKAU02005EA.ct_Col_SalesDate] = retWork.SalesDate.ToString("yyyy/MM/dd");// ADD 2010/12/17
                row[PMKAU02005EA.ct_Col_SearchSlipDate] = retWork.SearchSlipDate.ToString( "yyyy/MM/dd" );// ADD 2010/12/17
                row[PMKAU02005EA.ct_Col_SalesSlipNum] = retWork.SalesSlipNum;
                row[PMKAU02005EA.ct_Col_SalesSlipCd] = retWork.SalesSlipCd;
                row[PMKAU02005EA.ct_Col_SalesSlipCdNm] = this.GetSalesSlipCdNm( retWork );
                row[PMKAU02005EA.ct_Col_CustomerSnm] = retWork.CustomerSnm;
                row[PMKAU02005EA.ct_Col_SalesTotal] = this.GetSalesTotal( retWork );
                row[PMKAU02005EA.ct_Col_DepositAlwcBlnce] = retWork.DepositAlwcBlnce;
                row[PMKAU02005EA.ct_Col_SalesEmployeeCd] = retWork.SalesEmployeeCd;
                row[PMKAU02005EA.ct_Col_SalesEmployeeNm] = retWork.SalesEmployeeNm;
                row[PMKAU02005EA.ct_Col_FrontEmployeeCd] = retWork.FrontEmployeeCd;
                row[PMKAU02005EA.ct_Col_FrontEmployeeNm] = retWork.FrontEmployeeNm;
                row[PMKAU02005EA.ct_Col_SlipNote] = retWork.SlipNote;
                # endregion

                dataTable.Rows.Add( row );
            }
        }

        /// <summary>
        /// 売上金額取得処理（転嫁方式で税抜or税込を判断する）
        /// </summary>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private Int64 GetSalesTotal( SearchClaimSalesWork retWork )
        {
            switch ( retWork.ConsTaxLayMethod )
            {
                default:
                // 伝票転嫁
                case 0:
                // 明細転嫁
                case 1:
                    {
                        // 税込
                        return retWork.SalesTotalTaxInc;
                    }
                // 請求親
                case 2:
                // 請求子
                case 3:
                // 非課税
                case 9:
                    {
                        // 税抜
                        return retWork.SalesTotalTaxExc;
                    }
            }
        }

        /// <summary>
        /// 対象日付取得
        /// </summary>
        /// <param name="retWork"></param>
        /// <param name="paraWork"></param>
        /// <returns></returns>
        private DateTime GetTargetDate( SearchClaimSalesWork retWork, NoDepSalListCdtn paraWork )
        {
            if ( paraWork.TargetDateDiv == 0 )
            {
                // 売上日
                return retWork.SalesDate;
            }
            else
            {
                // 入力日
                return retWork.SearchSlipDate;
            }
        }
        /// <summary>
        /// 伝票区分取得
        /// </summary>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private string GetSalesSlipCdNm( SearchClaimSalesWork retWork )
        {
            // 0:売上,1:返品
            switch ( retWork.SalesSlipCd )
            {
                default:
                case 0: return "売上";
                case 1: return "返品";
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
