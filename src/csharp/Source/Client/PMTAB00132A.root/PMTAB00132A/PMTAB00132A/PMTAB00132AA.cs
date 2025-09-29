//****************************************************************************//
// システム         : PMTAB 自動回答処理(得意先情報)                          //
// プログラム名称   : PMTAB 自動回答処理(得意先情報)View                      //
// プログラム概要   :                                                         //
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : wangl2                                    //
// 作 成 日  2013/05/29  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB 自動回答処理(得意先情報)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB 自動回答処理(得意先情報)のアクセス制御を行います。</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: ソースチェック確認事項一覧NO.8の対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/10</br>
    /// <br>Update Note: ソースチェック確認事項一覧NO.9,NO.11の対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Update Note: Redmine#37231 FOR タブレットログ対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/25</br>
    /// <br>Update Note: 処理時間短縮の為、ログ出力削除</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : 吉岡</br>
    /// <br>Date       : 2013/07/29</br>
    /// <br>Update Note: ログ見直し</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : 吉岡</br>
    /// <br>Date       : 2013/07/29</br>
    /// <br>Update Note: Redmine#39755</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/08/08</br>
    /// <br>Update Note: Redmine#39923 請求先情報取得</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : 湯上</br>
    /// <br>Date       : 2013/08/13</br>
    /// </remarks>
    public class TabSCMCustomerAcs
    {
        #region [Private Members]
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ICustomerSearchDB _iCustomerSearchDB = null;

        /// <summary>リモートオブジェクト格納バッファ</summary>
        //private IPmTabCustomerTmpDB _iPmTabCustomerTmpDB = null;// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応
        private IPmTabCustTmpDB _iPmTabCustomerTmpDB = null;// ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応

        // タブレットログ対応　--------------------------------->>>>>
        private const string CLASS_NAME = "TabSCMCustomerAcs";
        // タブレットログ対応　---------------------------------<<<<<

        /// <summary>
        /// PMTAB全体設定マスタリモート
        /// </summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;// ADD 2013/08/08 wangl2 for Redmine#39755
        #endregion

        /// <summary>
        /// PMTAB 自動回答処理(得意先情報)テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB 自動回答処理(得意先情報)テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br></br>
        /// </remarks>
        public TabSCMCustomerAcs()
        {
            // タブレットログ対応　--------------------------------->>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            const string methodName = "TabSCMCustomerAcs";
            // タブレットログ対応　---------------------------------<<<<<

            try
            {
                // リモートオブジェクト取得
                this._iCustomerSearchDB = (ICustomerSearchDB)MediationCustomerSearchDB.GetCustomerSearchDB();
                //this._iPmTabCustomerTmpDB = (IPmTabCustomerTmpDB)MediationPmTabCustomerTmpDB.GetPmTabCustomerTmpDB();// DEL 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応
                this._iPmTabCustomerTmpDB = (IPmTabCustTmpDB)MediationPmTabCustTmpDB.GetPmTabCustTmpDB();// ADD 2013/06/10 wangl2 FOR ソースチェック確認事項一覧NO.8の対応
                this._iPmTabTtlStCustDB = (IPmTabTtlStCustDB)MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();// ADD 2013/08/08 wangl2 for Redmine#39755
            }
            // タブレットログ対応　--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // タブレットログ対応　---------------------------------<<<<<
                //オフライン時はnullをセット
                this._iCustomerSearchDB = null;
                this._iPmTabCustomerTmpDB = null;
            }
        }

        #region Public Methods
        #region Public Methods
        /// <summary>
        /// PMTAB得意先検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="kana">カナ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="mngSectionCode">管理拠点</param>
        /// <param name="kanaSearchType">得意先カナ検索タイプ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB得意先検索処理を行います。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public int SearchCustomerDataForTablet(string enterpriseCode, string sectionCode, string businessSessionId, string kana, int customerCode, string mngSectionCode, int kanaSearchType, out string errMsg)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SearchCustomerDataForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▼▼▼▼▼自動回答処理(得意先情報)　開始▼▼▼▼▼");
            EasyLogger.Write(CLASS_NAME, methodName, "▼自動回答処理(得意先情報)　開始▼");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // タブレットログ対応　---------------------------------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            // 検索結果リスト
            ArrayList pmTabCustomerTmpWorkList = new ArrayList();
            // 検索パラメーター
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            // 企業コード
            customerSearchPara.EnterpriseCode = enterpriseCode;
            // 管理拠点コード
            customerSearchPara.MngSectionCode = mngSectionCode;
            // 得意先カナ
            customerSearchPara.Kana = kana;
            // 得意先コード
            customerSearchPara.CustomerCode = customerCode;
            // 得意先カナ検索タイプ
            customerSearchPara.KanaSearchType = kanaSearchType;
            if (!string.IsNullOrEmpty(businessSessionId))
            {
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "自動回答処理（得意先情報）検索条件"
                    + "　企業コード：" + enterpriseCode
                    + "  拠点コード：" + sectionCode
                    + "  業務セッションID：" + businessSessionId
                    + "  得意先名カナ：" + kana
                    + "  得意先コード：" + customerCode
                    + "  管理拠点：" + mngSectionCode
                    + "  ｶﾅ名検索区分：" + kanaSearchType.ToString()
                    );
                // タブレットログ対応　---------------------------------<<<<<
                // PMTAB得意先情報検索(PM_USER_DB)
                status = this.SearchForTablet(out pmTabCustomerTmpWorkList, customerSearchPara, businessSessionId, sectionCode, ConstantManagement.LogicalMode.GetData0, out errMsg);
                // タブレットログ対応　--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "●得意先マスタ設定情報検索　status：" + status.ToString());
                // タブレットログ対応　---------------------------------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // タブレットログ対応　--------------------------------->>>>>
                    int cnt = 0;
                    if (pmTabCustomerTmpWorkList != null)
                    {
                        cnt = pmTabCustomerTmpWorkList.Count;
                    }
                    EasyLogger.Write(CLASS_NAME, methodName, "書込み対象件数：" + cnt.ToString());
                    // タブレットログ対応　---------------------------------<<<<<
                    if (pmTabCustomerTmpWorkList != null && pmTabCustomerTmpWorkList.Count > 0)
                    {
                        // 得意先データの登録処理(PM_SCM_DB)
                        status = this.WriteForTablet(ref pmTabCustomerTmpWorkList, out errMsg);
                        // タブレットログ対応　--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "●得意先マスタ設定情報書込み　status：" + status.ToString());
                        // タブレットログ対応　---------------------------------<<<<<
                    }
                    else
                    {
                        errMsg = "該当データが存在しません。";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            else 
            {
                errMsg = "PMTAB得意先情報検索に失敗しました。";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            // タブレットログ対応　--------------------------------->>>>>
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(得意先情報)　開始▲▲▲▲▲");
            EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(得意先情報)　開始▲");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return status;

        }
        #endregion

        
        #endregion

        #region Private Methods

        /// <summary>
        /// PMTAB得意先情報検索
        /// </summary>
        /// <param name="pmTabCustomerTmpWorkList">検索結果リスト</param>
        /// <param name="customerSearchPara">検索条件データ</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: PMTAB得意先情報検索を行います。</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/05/29</br>
        /// </remarks>
        private int SearchForTablet(out ArrayList pmTabCustomerTmpWorkList, CustomerSearchPara customerSearchPara, string businessSessionId, string sectionCode, ConstantManagement.LogicalMode logicalMode, out String errMsg)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "SearchForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            pmTabCustomerTmpWorkList = new ArrayList();
            // 検索条件ワーク
            CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();
            // 得意先検索条件クラス⇒得意先検索ワーククラス
            customerSearchParaWork = CopyToParamDataFromUIData(customerSearchPara);
            // 検索条件オブジェクト
            object paraObj = customerSearchParaWork;
            // 検索結果オブジェクト
            object retObj;
            errMsg = "";
            try
            {
                // 得意先検索 
                status = this._iCustomerSearchDB.SearchForTablet(out retObj, ref paraObj, logicalMode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList customerWorkList = retObj as ArrayList;
                            if (customerWorkList != null && customerWorkList.Count > 0)
                            {
                                // 得意先検索条件クラス⇒PMTAB得意先検索結果データ
                                pmTabCustomerTmpWorkList = CopyToCustomerDataToUIData(customerWorkList, customerSearchParaWork, businessSessionId, sectionCode);
                            }
                            break;
                        }
                    default:
                        {
                            errMsg = "PMTAB得意先情報検索に失敗しました。";
                            break;
                        }
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // タブレットログ対応　---------------------------------<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "PMTAB得意先情報検索に失敗しました。";
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return status;

        }

        /// <summary>
        /// 得意先情報全件登録処理
        /// </summary>
        /// <param name="pmTabCustomerTmpList">得意先データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: 得意先データの登録処理を行います。</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/05/29</br>
        /// </remarks>
        private int WriteForTablet(ref ArrayList pmTabCustomerTmpList, out string errMsg)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "WriteForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            bool msgDiv;// ADD 2013/06/11 wangl2 FOR ソースチェック確認事項NO.9,NO.11の対応
            try
            {
                // 得意先オブジェクト
                object pmTabCustomerTmpWorkobj = pmTabCustomerTmpList;

                // 得意先データの登録処理
                //status = this._iPmTabCustomerTmpDB.WriteForTablet(ref pmTabCustomerTmpWorkobj);// DEL 2013/06/11 wangl2 FOR ソースチェック確認事項NO.9,NO.11の対応
                status = this._iPmTabCustomerTmpDB.WriteForTablet(ref pmTabCustomerTmpWorkobj, out  msgDiv, out  errMsg);// ADD 2013/06/11 wangl2 FOR ソースチェック確認事項NO.9,NO.11の対応
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            errMsg = "PMTAB得意先情報登録に失敗しました。";
                            break;
                        }
                }
            }
            // タブレットログ対応　--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // タブレットログ対応　---------------------------------<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "PMTAB得意先情報登録に失敗しました。";
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return status;

        }

        /// <summary>
        /// クラスメンバーコピー処理（得意先検索条件クラス⇒得意先検索ワーククラス）
        /// </summary>
        /// <param name="customerSearchPara">得意先検索条件クラス</param>
        /// <returns>得意先検索ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 得意先検索条件クラスから得意先検索ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private CustomerSearchParaWork CopyToParamDataFromUIData(CustomerSearchPara customerSearchPara)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CopyToParamDataFromUIData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<
            CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();

            customerSearchParaWork.EnterpriseCode = customerSearchPara.EnterpriseCode;
            customerSearchParaWork.CustomerCode = customerSearchPara.CustomerCode;
            customerSearchParaWork.CustomerSubCode = customerSearchPara.CustomerSubCode;
            customerSearchParaWork.Kana = customerSearchPara.Kana;
            customerSearchParaWork.SearchTelNo = customerSearchPara.SearchTelNo;
            customerSearchParaWork.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
            customerSearchParaWork.KanaSearchType = customerSearchPara.KanaSearchType;
            customerSearchParaWork.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
            customerSearchParaWork.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
            customerSearchParaWork.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
            customerSearchParaWork.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
            customerSearchParaWork.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
            customerSearchParaWork.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
            customerSearchParaWork.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
            customerSearchParaWork.BillCollecterCd = customerSearchPara.BillCollecterCd;
            customerSearchParaWork.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
            customerSearchParaWork.MngSectionCode = customerSearchPara.MngSectionCode;
            customerSearchParaWork.Name = customerSearchPara.Name;
            customerSearchParaWork.NameSearchType = customerSearchPara.NameSearchType;
            customerSearchParaWork.TelNum = customerSearchPara.TelNum;
            customerSearchParaWork.TelNumSearchType = customerSearchPara.TelNumSearchType;
            customerSearchParaWork.PccuoeMode = customerSearchPara.PccuoeMode;
            customerSearchParaWork.CustomerSnm = customerSearchPara.CustomerSnm;
            customerSearchParaWork.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;

            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return customerSearchParaWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（得意先検索条件クラス⇒PMTAB得意先検索結果データ（一時）ワーククラス）
        /// </summary>
        /// <param name="customerWorkList">得意先検索結果リスト</param>
        /// <param name="customerSearchParaWork">得意先検索条件クラス</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>得意先検索ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 得意先検索条件クラスからPMTAB得意先検索結果データ（一時）クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private ArrayList CopyToCustomerDataToUIData(ArrayList customerWorkList, CustomerSearchParaWork customerSearchParaWork, string businessSessionId,string sectionCode)
        {
            // タブレットログ対応　--------------------------------->>>>>
            const string methodName = "CopyToCustomerDataToUIData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // タブレットログ対応　---------------------------------<<<<<
            ArrayList pmTabCustomerTmpList = new ArrayList();
            DateTime dateTime = System.DateTime.Now.AddDays(7);
            int i = 1;
            // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- >>>>>
            // BLP送信区分取得
            object objRetList;
            ArrayList resultList = null;
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            pmTabTtlStCustWork.EnterpriseCode = customerSearchParaWork.EnterpriseCode;
            object objSearchCond = pmTabTtlStCustWork;
            int status = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == 0)
            {
                resultList = objRetList as ArrayList;
            }
            bool Flag = false;
            // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- <<<<<
            // ADD 2013/08/13 Redmine#39923 請求先情報取得 ------------------------>>>>>
            CustomerInfoAcs customerDB = new CustomerInfoAcs();
            // ADD 2013/08/13 Redmine#39923 請求先情報取得 ------------------------<<<<<
            foreach (CustomerWork customerWork in customerWorkList)
            {
                PmTabCustTmpWork pmTabCustTmp = new PmTabCustTmpWork();
                #region
                pmTabCustTmp.CreateDateTime = customerWork.CreateDateTime;
                pmTabCustTmp.UpdateDateTime = customerWork.UpdateDateTime;
                pmTabCustTmp.EnterpriseCode = customerWork.EnterpriseCode;
                pmTabCustTmp.FileHeaderGuid = customerWork.FileHeaderGuid;
                pmTabCustTmp.UpdEmployeeCode = customerWork.UpdEmployeeCode;
                pmTabCustTmp.UpdAssemblyId1 = customerWork.UpdAssemblyId1;
                pmTabCustTmp.UpdAssemblyId2 = customerWork.UpdAssemblyId2;
                pmTabCustTmp.LogicalDeleteCode = customerWork.LogicalDeleteCode;
                pmTabCustTmp.CustomerCode = customerWork.CustomerCode;
                pmTabCustTmp.CustomerSubCode = customerWork.CustomerSubCode;
                pmTabCustTmp.Name = customerWork.Name;
                pmTabCustTmp.Name2 = customerWork.Name2;
                pmTabCustTmp.HonorificTitle = customerWork.HonorificTitle;
                pmTabCustTmp.Kana = customerWork.Kana;
                pmTabCustTmp.CustomerSnm = customerWork.CustomerSnm;
                pmTabCustTmp.OutputNameCode = customerWork.OutputNameCode;
                pmTabCustTmp.OutputName = customerWork.OutputName;
                pmTabCustTmp.CorporateDivCode = customerWork.CorporateDivCode;
                pmTabCustTmp.CustomerAttributeDiv = customerWork.CustomerAttributeDiv;
                pmTabCustTmp.JobTypeCode = customerWork.JobTypeCode;
                pmTabCustTmp.BusinessTypeCode = customerWork.BusinessTypeCode;
                pmTabCustTmp.SalesAreaCode = customerWork.SalesAreaCode;
                pmTabCustTmp.PostNo = customerWork.PostNo;
                pmTabCustTmp.Address1 = customerWork.Address1;
                pmTabCustTmp.Address3 = customerWork.Address3;
                pmTabCustTmp.Address4 = customerWork.Address4;
                pmTabCustTmp.HomeTelNo = customerWork.HomeTelNo;
                pmTabCustTmp.OfficeTelNo = customerWork.OfficeTelNo;
                pmTabCustTmp.PortableTelNo = customerWork.PortableTelNo;
                pmTabCustTmp.HomeFaxNo = customerWork.HomeFaxNo;
                pmTabCustTmp.OfficeFaxNo = customerWork.OfficeFaxNo;
                pmTabCustTmp.OthersTelNo = customerWork.OthersTelNo;
                pmTabCustTmp.MainContactCode = customerWork.MainContactCode;
                pmTabCustTmp.SearchTelNo = customerWork.SearchTelNo;
                pmTabCustTmp.MngSectionCode = customerWork.MngSectionCode;
                pmTabCustTmp.InpSectionCode = customerWork.InpSectionCode;
                pmTabCustTmp.CustAnalysCode1 = customerWork.CustAnalysCode1;
                pmTabCustTmp.CustAnalysCode2 = customerWork.CustAnalysCode2;
                pmTabCustTmp.CustAnalysCode3 = customerWork.CustAnalysCode3;
                pmTabCustTmp.CustAnalysCode4 = customerWork.CustAnalysCode4;
                pmTabCustTmp.CustAnalysCode5 = customerWork.CustAnalysCode5;
                pmTabCustTmp.CustAnalysCode6 = customerWork.CustAnalysCode6;
                pmTabCustTmp.BillOutputCode = customerWork.BillOutputCode;
                pmTabCustTmp.BillOutputName = customerWork.BillOutputName;
                pmTabCustTmp.TotalDay = customerWork.TotalDay;
                pmTabCustTmp.CollectMoneyCode = customerWork.CollectMoneyCode;
                pmTabCustTmp.CollectMoneyName = customerWork.CollectMoneyName;
                pmTabCustTmp.CollectMoneyDay = customerWork.CollectMoneyDay;
                pmTabCustTmp.CollectCond = customerWork.CollectCond;
                pmTabCustTmp.CollectSight = customerWork.CollectSight;
                pmTabCustTmp.ClaimCode = customerWork.ClaimCode;
                pmTabCustTmp.TransStopDate = customerWork.TransStopDate;
                pmTabCustTmp.DmOutCode = customerWork.DmOutCode;
                pmTabCustTmp.DmOutName = customerWork.DmOutName;
                pmTabCustTmp.MainSendMailAddrCd = customerWork.MainSendMailAddrCd;
                pmTabCustTmp.MailAddrKindCode1 = customerWork.MailAddrKindCode1;
                pmTabCustTmp.MailAddrKindName1 = customerWork.MailAddrKindName1;
                pmTabCustTmp.MailAddress1 = customerWork.MailAddress1;
                pmTabCustTmp.MailSendCode1 = customerWork.MailSendCode1;
                pmTabCustTmp.MailSendName1 = customerWork.MailSendName1;
                pmTabCustTmp.MailAddrKindCode2 = customerWork.MailAddrKindCode2;
                pmTabCustTmp.MailAddrKindName2 = customerWork.MailAddrKindName2;
                pmTabCustTmp.MailAddress2 = customerWork.MailAddress2;
                pmTabCustTmp.MailSendCode2 = customerWork.MailSendCode2;
                pmTabCustTmp.MailSendName2 = customerWork.MailSendName2;
                pmTabCustTmp.CustomerAgentCd = customerWork.CustomerAgentCd;
                pmTabCustTmp.BillCollecterCd = customerWork.BillCollecterCd;
                pmTabCustTmp.OldCustomerAgentCd = customerWork.OldCustomerAgentCd;
                pmTabCustTmp.CustAgentChgDate = customerWork.CustAgentChgDate;
                pmTabCustTmp.AcceptWholeSale = customerWork.AcceptWholeSale;
                pmTabCustTmp.CreditMngCode = customerWork.CreditMngCode;
                pmTabCustTmp.DepoDelCode = customerWork.DepoDelCode;
                pmTabCustTmp.AccRecDivCd = customerWork.AccRecDivCd;
                pmTabCustTmp.CustSlipNoMngCd = customerWork.CustSlipNoMngCd;
                pmTabCustTmp.PureCode = customerWork.PureCode;
                // DEL 2013/08/13 Redmine#39923 請求先情報取得 ------------------------>>>>>
                //pmTabCustTmp.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;
                //pmTabCustTmp.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;
                // DEL 2013/08/13 Redmine#39923 請求先情報取得 ------------------------<<<<<
                pmTabCustTmp.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;
                pmTabCustTmp.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;
                pmTabCustTmp.AccountNoInfo1 = customerWork.AccountNoInfo1;
                pmTabCustTmp.AccountNoInfo2 = customerWork.AccountNoInfo2;
                pmTabCustTmp.AccountNoInfo3 = customerWork.AccountNoInfo3;
                pmTabCustTmp.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd;
                pmTabCustTmp.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd;
                // DEL 2013/08/13 Redmine#39923 請求先情報取得 ------------------------>>>>>
                //pmTabCustTmp.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;
                // DEL 2013/08/13 Redmine#39923 請求先情報取得 ------------------------<<<<<
                pmTabCustTmp.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv;
                pmTabCustTmp.NTimeCalcStDate = customerWork.NTimeCalcStDate;
                pmTabCustTmp.CustomerAgent = customerWork.CustomerAgent;
                pmTabCustTmp.ClaimSectionCode = customerWork.ClaimSectionCode;
                pmTabCustTmp.CarMngDivCd = customerWork.CarMngDivCd;
                pmTabCustTmp.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd;
                pmTabCustTmp.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd;
                pmTabCustTmp.DefSalesSlipCd = customerWork.DefSalesSlipCd;
                pmTabCustTmp.LavorRateRank = customerWork.LavorRateRank;
                pmTabCustTmp.SlipTtlPrn = customerWork.SlipTtlPrn;
                pmTabCustTmp.DepoBankCode = customerWork.DepoBankCode;
                pmTabCustTmp.CustWarehouseCd = customerWork.CustWarehouseCd;
                pmTabCustTmp.QrcodePrtCd = customerWork.QrcodePrtCd;
                pmTabCustTmp.DeliHonorificTtl = customerWork.DeliHonorificTtl;
                pmTabCustTmp.BillHonorificTtl = customerWork.BillHonorificTtl;
                pmTabCustTmp.EstmHonorificTtl = customerWork.EstmHonorificTtl;
                pmTabCustTmp.RectHonorificTtl = customerWork.RectHonorificTtl;
                pmTabCustTmp.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv;
                pmTabCustTmp.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv;
                pmTabCustTmp.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv;
                pmTabCustTmp.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv;
                pmTabCustTmp.Note1 = customerWork.Note1;
                pmTabCustTmp.Note2 = customerWork.Note2;
                pmTabCustTmp.Note3 = customerWork.Note3;
                pmTabCustTmp.Note4 = customerWork.Note4;
                pmTabCustTmp.Note5 = customerWork.Note5;
                pmTabCustTmp.Note6 = customerWork.Note6;
                pmTabCustTmp.Note7 = customerWork.Note7;
                pmTabCustTmp.Note8 = customerWork.Note8;
                pmTabCustTmp.Note9 = customerWork.Note9;
                pmTabCustTmp.Note10 = customerWork.Note10;
                pmTabCustTmp.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
                pmTabCustTmp.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
                pmTabCustTmp.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
                pmTabCustTmp.EstimatePrtDiv = customerWork.EstimatePrtDiv;
                pmTabCustTmp.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
                pmTabCustTmp.ReceiptOutputCode = customerWork.ReceiptOutputCode;
                pmTabCustTmp.CustomerEpCode = customerWork.CustomerEpCode;
                pmTabCustTmp.CustomerSecCode = customerWork.CustomerSecCode;
                pmTabCustTmp.OnlineKindDiv = customerWork.OnlineKindDiv;
                pmTabCustTmp.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;
                pmTabCustTmp.DetailBillOutputCode = customerWork.DetailBillOutputCode;
                pmTabCustTmp.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;
                pmTabCustTmp.SimplInqAcntAcntGrId = customerWork.SimplInqAcntAcntGrId;
                pmTabCustTmp.SearchSectionCode = sectionCode;
                pmTabCustTmp.DataDeleteDate = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
                pmTabCustTmp.BusinessSessionId = businessSessionId;
                pmTabCustTmp.PmTabSearchRowNum = i;
                i++;
                // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- >>>>>
                Flag = false;
                if (resultList != null && resultList.Count > 0)
                {
                    // 得意先コード＝得意先マスタの得意先コード場合
                    foreach (PmTabTtlStCustWork pmTabTtlStCust in resultList)
                    {
                        if (pmTabTtlStCust.CustomerCode == pmTabCustTmp.CustomerCode)
                        {
                            pmTabCustTmp.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;
                            Flag = true;
                            break;
                        }
                    }
                    // 得意先コード＝ゼロ場合
                    if (!Flag)
                    {
                        foreach (PmTabTtlStCustWork pmTabTtlStCust in resultList)
                        {
                            if (pmTabTtlStCust.CustomerCode == 0)
                            {
                                pmTabCustTmp.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;
                                Flag = true;
                                break;
                            }
                        }
                    }
                    // いずれの場合でもデータが取得できなかった時
                    if (!Flag)
                    {
                        pmTabCustTmp.BlpSendDiv = 1;
                    }
                }
                // いずれの場合でもデータが取得できなかった時
                else 
                {
                    pmTabCustTmp.BlpSendDiv = 1;
                }
                // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- <<<<<
                // ADD 2013/08/13 Redmine#39923 請求先情報取得 ------------------------>>>>>
                // 得意先コード（子）の時は消費税関連情報は請求先よりセットする
                if (pmTabCustTmp.CustomerCode != pmTabCustTmp.ClaimCode)
                {
                    // 請求先情報取得
                    CustomerInfo claimInfo = new CustomerInfo();
                    customerDB.ReadDBData(pmTabCustTmp.EnterpriseCode, pmTabCustTmp.ClaimCode, out claimInfo);
                    if (claimInfo != null && claimInfo.CustomerCode != 0)
                    {
                        pmTabCustTmp.CustCTaXLayRefCd = claimInfo.CustCTaXLayRefCd;         // 得意先消費税転嫁方式参照区分
                        pmTabCustTmp.ConsTaxLayMethod = claimInfo.ConsTaxLayMethod;         // 消費税転嫁方式
                        pmTabCustTmp.SalesCnsTaxFrcProcCd = claimInfo.SalesCnsTaxFrcProcCd; // 売上消費税端数処理コード
                    }
                }
                else
                {
                    pmTabCustTmp.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;          // 得意先消費税転嫁方式参照区分
                    pmTabCustTmp.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;          // 消費税転嫁方式
                    pmTabCustTmp.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;  // 売上消費税端数処理コード
                }
                // ADD 2013/08/13 Redmine#39923 請求先情報取得 ------------------------<<<<<

                #endregion
                pmTabCustomerTmpList.Add(pmTabCustTmp);
                // DEL 2013/07/29 吉岡 処理時間短縮の為、ログ出力削除 --------->>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// タブレットログ対応　--------------------------------->>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, "検索結果（書込み内容）"
                //    + "　企業コード：" + pmTabCustTmp.EnterpriseCode
                //    + "　検索拠点コード：" + pmTabCustTmp.SearchSectionCode
                //    + "　業務セッションID：" + pmTabCustTmp.BusinessSessionId
                //    + "　PMTAB検索行番号：" + pmTabCustTmp.PmTabSearchRowNum.ToString()
                //    + "　得意先コード：" + pmTabCustTmp.CustomerCode.ToString()
                //    + "　得意先名：" + pmTabCustTmp.Name
                //    );
                //// タブレットログ対応　---------------------------------<<<<<
                #endregion
                // DEL 2013/07/29 吉岡 処理時間短縮の為、ログ出力削除 ---------<<<<<<<<<<<<<<<<<<
            }
            // タブレットログ対応　--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // タブレットログ対応　---------------------------------<<<<<
            return pmTabCustomerTmpList;
        }
        #endregion
    }
}
