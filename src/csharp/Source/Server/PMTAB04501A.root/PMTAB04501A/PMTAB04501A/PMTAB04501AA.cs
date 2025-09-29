using System;
using System.Collections.Generic;
using Broadleaf.Runtime.Serialization.Json;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Web.Common;
using Broadleaf.Web;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Resources;
using Microsoft.VisualBasic;    // 2013.08.05 ADD

//履歴表示修正による対応　JSON変更に伴い、セット情報を変更 2013.07.17

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS 得意先伝票履歴WEBアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS　得意先元履歴情報取得処理を制御します。</br>
    /// <br>Programmer : 95094　大塚　たえ子</br>
    /// <br>Date       : 2013.05.28</br>
    /// <br>UpDate     : 2013.07.23　：ヘッダ情報判定処理変更、赤伝区分追加</br>
    /// <br>UpDate     : 2013.08.05　：メーカー名等追加</br>
    /// <br>UpDate     : 2013.08.19　：売上日(和暦→西暦）に変更</br>
    /// <br>管理番号   : 11070184-00　仕掛 №10652　RedMine#43261</br>
    /// <br>　　       : 2014.10.07 配信システムテスト障害№8対応 </br>
    /// <br>UpDate     : 2017.10.25：RedMine#49542 ヘッダ情報に「備考１」「備考２」「備考３」項目追加</br>
    /// <br>管理番号   : 11370050-00</br>
    /// </remarks>

    public class DBPmCustSlipHisWebAcs
    {
        #region << Constructor >>
        /// <summary>
        /// 
        /// </summary>
        public DBPmCustSlipHisWebAcs() { }
	
        #endregion

        #region << Private Const >>
        /// <summary>PGID</summary>
        private const string CT_PGID = "PMTAB04501A";

		/// <summary>JSONパラメータ　拠点情報結果オブジェクト</summary>
		private const string ctJSPara_SectionInfoArray = "SectionInfo";
        /// <summary>JSONパラメータ　履歴ヘッダ情報オブジェクト</summary>
        private const string ctJSPara_SalesSlipHeaderArray = "SalesSlipHeader";
        /// <summary>JSONパラメータ　履歴明細情報オブジェクト</summary>
        private const string ctJSPara_SalesSlipDetailArray = "SalesSlipDetail";

        //共通条件項目
        /// <summary>JSONパラメータ　業務セッションID</summary>
        private const string ctJSPara_BusinessSessionId = "BusinessSessionId";

        // 得意先検索履歴パラメータオブジェクトの内容
        /// <summary>検索開始件数</summary>							
        private const string ctJSPara_PmSearchStartCount = "SearchStartCount";
        /// <summary>得意先コード</summary>
        private const string ctJSPara_PmCustomercode = "CustomerCode";
        /// <summary>売上日(開始)(文字列)</summary>							
        private const string ctJSPara_PmSalesDateSt = "SalesDateSt";
        /// <summary>売上日(終了)(文字列)</summary>							
        private const string ctJSPara_PmSalesDateEd = "SalesDateEd";
        /// <summary>検索拠点コード</summary>							
        private const string ctJSPara_PmSearchSectionCode = "SearchSectionCode";
        /// <summary>売上入金区分</summary>							
        private const string ctJSPara_PmSalesDepoDiv = "SalesDepoDiv";
        /// <summary>受注ステータス</summary>							
        private const string ctJSPara_PmAcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary>売上伝票区分</summary>							
        private const string ctJSPara_PmSalesSlipCd = "SalesSlipCd";

        /// <summary>検索件数</summary>							
        private const string ctJSPara_PmSearchCount = "SearchCount";
        /// <summary>検索行番号</summary>							
        private const string ctJSPara_SearchRowNum = "SearchRowNum";
        /// <summary>売上伝票番号</summary>							
        private const string ctJSPara_SalesSlipNum = "SalesSlipNum";

        // 得意先検索条件結果オブジェクトの内容
        /// <summary>売上日(開始)(Int32)</summary>							
        private const string ctJSPara_PmSalesDateSt_s = "SalesDateSt-yyyymmdd";
        /// <summary>売上日(終了)(Int32)</summary>							
        private const string ctJSPara_PmSalesDateEd_s = "SalesDateEd-yyyymmdd";      
        /// <summary>ログイン拠点コード</summary>
        private const string ctJSPara_LogSectionCode = "LoginSectionCode";

        // 得意先履歴結果オブジェクトの内容
        /// <summary>検索終了件数</summary>							
        private const string ctJSPara_PmSearchEndCount = "SearchEndCount";
        /// <summary>伝票番号(開始)</summary>							
        private const string ctJSPara_PmSalesSlipNumSt = "SalesSlipNumSt";
        /// <summary>伝票番号(終了)</summary>							
        private const string ctJSPara_PmSalesSlipNumEd = "SalesSlipNumEd";
        /// <summary>小数点表示区分</summary>							
        private const string ctJSPara_PmDwnPlcDspDivCd = "DwnPlcDspDivCd";

        #endregion

        #region << Private Member >>

        /// <summary>タブレット表示情報リモートオブジェクト</summary>
        IPMTabletDispInfoDB _pMTabletDispInfoDB = null;
        /// <summary>業務セッションID情報DBアクセスクラス</summary>
        PMTabletBusinessSessionDBAcs _pMTabletBusinessSessionDBAcs = null;
        #endregion

        #region << Private Static Member >>

        #endregion

        #region << Private Enum >>

        #endregion

        #region << Private Class >>

        #endregion

        #region << Public Method（HTTPハンドラ） >>

        #region ■PM得意先伝票履歴抽出条件取得処理
        /// <summary>
        /// PM得意先伝票履歴抽出条件取得処理（拠点情報取得）
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 得意先伝票履歴抽出条件取得処理を実施します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        public int GetCustomerSlipHistryCndtnInfo(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.GetCustomerSlipHistryCndtnProc(parameterValue, out resultValue, out errMsg);
        }
        #endregion

        #region ■得意先伝票履歴取得処理
        /// <summary>
        /// 得意先伝票履歴取得処理
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 得意先伝票履歴リストを取得します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        public int GetCustomerSlipHistoryInfo(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.GetCustomerSlipHistoryInfoProc(parameterValue, out resultValue, out errMsg);
        }
        #endregion

        #region ■得意先伝票履歴選択処理
        /// <summary>
        /// 得意先伝票履歴選択処理(GetCustSlipHisPartsOdrInfo)
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 選択された得意先伝票履歴情報から車両情報を取得します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        public int GetCustSlipHisPartsOdrInfo(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.GetCustSlipHisPartsOdrInfoProc(parameterValue, out resultValue, out errMsg);
        }
        #endregion

        #endregion

        #region << Private Method（HTTPハンドラ） >>

        #region ■PM得意先伝票履歴条件取得処理(拠点情報）
        /// <summary>
        /// PM得意先伝票履歴条件取得処理
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 初期情報を取得します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        private int GetCustomerSlipHistryCndtnProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = String.Empty;

            try
            {
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();

                JsonObject paramObj = parameterValue as JsonObject;

                // ログイン従業員の企業コード、拠点コード取得
                AspLoginInfoAcquisition loginInfoAcq = new AspLoginInfoAcquisition();
                string enterpriseCode = loginInfoAcq.EnterpriseCode;

                bool msgDiv = false;
                // 検索条件（必須）
                string businessSessionId = string.Empty;
                if (paramObj != null)
                {
                    //業務セッションID
                    if (paramObj.HasValueString(ctJSPara_BusinessSessionId))
                    {
                        businessSessionId = paramObj.GetValueString(ctJSPara_BusinessSessionId);
                    }
                }

                if (this._pMTabletBusinessSessionDBAcs == null)
                    this._pMTabletBusinessSessionDBAcs = new PMTabletBusinessSessionDBAcs();
                //インスタンス化
                //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
                string wkStr_Scm_User = loginInfoAcq.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

                //AppSettingsからの取得は行わず自分で引数文字列を生成する
                if (this._pMTabletDispInfoDB == null)
                    this._pMTabletDispInfoDB = (IPMTabletDispInfoDB)Activator.GetObject(typeof(IPMTabletDispInfoDB), string.Format("{0}/MyAppPMTabletDispInfo", wkStr_Scm_User));

                if (this._pMTabletBusinessSessionDBAcs == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて初期化エラーが発生しました。", -1, null);
                }
                if (this._pMTabletDispInfoDB == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて初期化エラーが発生しました。", -1, null);
                }

                // 業務セッションチェック処理
                if (!this.BusinessSessionIdValidChk(businessSessionId,out msgDiv,out errMsg))
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                PmtSecInfoSetWork pmtSecInfoSetWork = new PmtSecInfoSetWork();
                pmtSecInfoSetWork.EnterpriseCode = enterpriseCode;
                //検索拠点コード追加 2013.07.16 ADD
                pmtSecInfoSetWork.SearchSectionCode = loginInfoAcq.Employee.BelongSectionCode;

                paraList.Add(pmtSecInfoSetWork);

                object retObj = paraList;


                Int32 salesDateSt_ymd = 0;
                Int32 salesDateEd_ymd = 0;
                string salesDateSt = string.Empty;
                string salesDateEd = string.Empty;
                string loginSectionCode = string.Empty;

                DateTime dToday = DateTime.Now;
                salesDateEd_ymd = TDateTime.DateTimeToLongDate(dToday);
                salesDateSt_ymd = TDateTime.DateTimeToLongDate(dToday.AddDays(-7));
                //和暦→西暦に変更
                //salesDateEd = TDateTime.LongDateToString("GGYYMMDD", salesDateEd_ymd);　//2013.08.19 DEL
                //salesDateSt = TDateTime.LongDateToString("GGYYMMDD", salesDateSt_ymd);  //2013.08.19 DEL
                salesDateEd = TDateTime.LongDateToString("YYYYMMDD", salesDateEd_ymd);    //2013.08.19 ADD
                salesDateSt = TDateTime.LongDateToString("YYYYMMDD", salesDateSt_ymd);    //2013.08.19 ADD

                #region 実プログラム

                // 拠点情報・得意先伝票履歴取得
                  status = _pMTabletDispInfoDB.GetPMTabletDispInfo(businessSessionId,enterpriseCode, ref retObj, out msgDiv, out errMsg);

                  if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                  {
                      #region レスポンスセット
                      if (loginInfoAcq.Employee != null)
                          loginSectionCode = loginInfoAcq.Employee.BelongSectionCode;

                      CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                      List<DBMnt_SectionInfo> jsParaSectionList = new List<DBMnt_SectionInfo>();
                      foreach (object obj in retList)
                      {
                          ArrayList resultList = obj as ArrayList;
                          for (int n = 0; n < resultList.Count; n++)
                          {

                              if (resultList[n] is PmtSecInfoSetWork)
                              {

                                  PmtSecInfoSetWork secInfoResult = new PmtSecInfoSetWork();
                                  secInfoResult = (PmtSecInfoSetWork)resultList[n];

                                  DBMnt_SectionInfo jsPara_SectionInfo = new DBMnt_SectionInfo();

                                  jsPara_SectionInfo.SectionCode = secInfoResult.SectionCode;
                                  jsPara_SectionInfo.SectionName = secInfoResult.SectionGuideNm;

                                  jsParaSectionList.Add(jsPara_SectionInfo);
                              }
                          }
                      }
                      JsonObject resultObj = new JsonObject();
                      resultObj.SetValue(ctJSPara_PmSalesDateSt, salesDateSt);
                      resultObj.SetValue(ctJSPara_PmSalesDateEd, salesDateEd);
                      resultObj.SetValue(ctJSPara_PmSalesDateSt_s, salesDateSt_ymd);
                      resultObj.SetValue(ctJSPara_PmSalesDateEd_s, salesDateEd_ymd);
                      resultObj.SetValue(ctJSPara_LogSectionCode, loginSectionCode);
                      resultObj.SetValue(ctJSPara_SectionInfoArray, (JsonArray)JsonSerializer.ConvertToJsonValue(jsParaSectionList.ToArray()));

                      resultValue = resultObj;
                      #endregion

                  }
                  else
                  {
                      //エラー時でも日付は、戻す
                      JsonObject resultObj = new JsonObject();
                      resultObj.SetValue(ctJSPara_PmSalesDateSt, salesDateSt);
                      resultObj.SetValue(ctJSPara_PmSalesDateEd, salesDateEd);
                      resultObj.SetValue(ctJSPara_PmSalesDateSt_s, salesDateSt_ymd);
                      resultObj.SetValue(ctJSPara_PmSalesDateEd_s, salesDateEd_ymd);
                      resultObj.SetValue(ctJSPara_LogSectionCode, loginSectionCode);
                      resultValue = resultObj;

                  }
                #endregion
                  
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    errMsg = string.Empty;


            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて例外が発生しました。", -1, ex);
            }

            return status;
        }
 
        #endregion


        #region ■得意先伝票履歴取得処理
        /// <summary>
        /// 得意先伝票履歴取得処理
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 得意先伝票履歴リストを取得します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        private int GetCustomerSlipHistoryInfoProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = String.Empty;

            try
            {
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();

                JsonObject paramObj = parameterValue as JsonObject;

                // ログイン従業員の企業コード、拠点コード取得
                AspLoginInfoAcquisition loginInfoAcq = new AspLoginInfoAcquisition();
                string enterpriseCode = loginInfoAcq.EnterpriseCode;

                // 検索条件の設定
                string businessSessionId = string.Empty;
                int para_SearchStartCount = 0;
                int para_SerachCount = 0;
                int para_SalesDateSt = 0;
                int para_SalesDateEd = 0;
                string para_SearchSectionCode = string.Empty;
                int para_SalesDepoDiv = 0;
                int para_AcptAnOdrStatus = 0;
                int para_SalesSlipCd = 0;

                // 検索条件（必須）
                if (paramObj != null)
                {
                    // 検索条件（任意）
                    // 業務セッションID
                    if (paramObj.HasValueString(ctJSPara_BusinessSessionId))
                    {
                        businessSessionId = paramObj.GetValueString(ctJSPara_BusinessSessionId);
                    }
                    //検索開始件数
                    para_SearchStartCount = paramObj.GetValueInt32(ctJSPara_PmSearchStartCount);
                    // 件数
                    para_SerachCount = paramObj.GetValueInt32(ctJSPara_PmSearchCount);

                    //売上日（開始）
                    para_SalesDateSt = paramObj.GetValueInt32(ctJSPara_PmSalesDateSt_s);
                    //売上日（終了）
                    para_SalesDateEd = paramObj.GetValueInt32(ctJSPara_PmSalesDateEd_s);
                    
                    //検索拠点コード
                    if (paramObj.HasValueString(ctJSPara_PmSearchSectionCode))
                    {
                        para_SearchSectionCode = paramObj.GetValueString(ctJSPara_PmSearchSectionCode);
                    }
                    //売上入金区分
                    para_SalesDepoDiv = paramObj.GetValueInt32(ctJSPara_PmSalesDepoDiv);
                    //受注ステータス
                    para_AcptAnOdrStatus = paramObj.GetValueInt32(ctJSPara_PmAcptAnOdrStatus);
                    //売上伝票区分
                    para_SalesSlipCd = paramObj.GetValueInt32(ctJSPara_PmSalesSlipCd);
                }

                if (this._pMTabletBusinessSessionDBAcs == null)
                    this._pMTabletBusinessSessionDBAcs = new PMTabletBusinessSessionDBAcs();
                //インスタンス化
                //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
                string wkStr_Scm_User = loginInfoAcq.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

                //AppSettingsからの取得は行わず自分で引数文字列を生成する
                if (this._pMTabletDispInfoDB == null)
                    this._pMTabletDispInfoDB = (IPMTabletDispInfoDB)Activator.GetObject(typeof(IPMTabletDispInfoDB), string.Format("{0}/MyAppPMTabletDispInfo", wkStr_Scm_User));
          
                if (this._pMTabletBusinessSessionDBAcs == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて初期化エラーが発生しました。", -1, null);
                }
                if (this._pMTabletDispInfoDB == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて初期化エラーが発生しました。", -1, null);
                }
                bool msgDiv = false;
             
                // 業務セッションチェック処理
                if (!this.BusinessSessionIdValidChk(businessSessionId,out msgDiv,out errMsg))
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                //日付チェック処理
                if (para_SalesDateSt > para_SalesDateEd)
                {
                    errMsg = "開始日を終了日よりも後にすることはできません。";
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //全体設定情報取得
                PmtSalesTtlStWork pmtSalesTtlSt = new PmtSalesTtlStWork();
                pmtSalesTtlSt.EnterpriseCode = enterpriseCode;
                pmtSalesTtlSt.SearchSectionCode = loginInfoAcq.Employee.BelongSectionCode;
                paraList.Add(pmtSalesTtlSt);
                //履歴取得
                PmTabPrtPprParaWork pmTabPrtPprParaWork = new PmTabPrtPprParaWork();
                pmTabPrtPprParaWork.EnterpriseCode = enterpriseCode;
                //検索拠点をログイン拠点で対応する
                //pmTabPrtPprParaWork.SearchSectionCode = para_SearchSectionCode;                // 2013.07.23 DEL
                pmTabPrtPprParaWork.SearchSectionCode = loginInfoAcq.Employee.BelongSectionCode; // 2013.07.23 ADD
                pmTabPrtPprParaWork.PmTabSearchGuid = businessSessionId; //検索GUID(業務セッションID）
              　pmTabPrtPprParaWork.PmTabStaRowNum = para_SearchStartCount;//開始番号
                pmTabPrtPprParaWork.PmTabCallCount = para_SerachCount; // 抽出行数
                paraList.Add(pmTabPrtPprParaWork);

                object retObj = paraList;

                // 情報取得
                status = this._pMTabletDispInfoDB.GetPMTabletDispInfo(businessSessionId,enterpriseCode, ref retObj, out msgDiv, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    #region レスポンスセット
                    CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                    List<DB_SalesSlipHeader> jsParaSalesSlipHeaderList = new List<DB_SalesSlipHeader>();
                    List<DB_SalesSlipDetail> jsParaSalesSlipDetailList = new List<DB_SalesSlipDetail>();
                    List<int> headerList = new List<int>();

                    int ncnt = 0;
                   // string dataNo = string.Empty; // 2013.07.23 DEL
                   // int acptAnOdrStatus = 0; // 2013.07.23 DEL
                    string salesSlipNumSt = string.Empty;
                    string salesSlipNumEd = string.Empty;
                    int totalRecordCount = 0;

                    PmtSalesTtlStWork pmtSalesTtlStWork = new PmtSalesTtlStWork();
 
                    foreach (object obj in retList)
                    {
                        ArrayList resultList = obj as ArrayList;
                        if (resultList != null)
                        {
                            for (int n = 0; n < resultList.Count; n++)
                            {
                                //全体設定取得処理
                                if (resultList[n] is PmtSalesTtlStWork)
                                {
                                    PmtSalesTtlStWork　pmtSalesTtlStWk = (PmtSalesTtlStWork)resultList[n];
                                    if ((pmtSalesTtlStWork.SectionCode.Trim() == string.Empty) &&
                                        (pmtSalesTtlStWk.SectionCode.Trim() == "00"))
                                    {
                                        pmtSalesTtlStWork = pmtSalesTtlStWk;
                                    }
                                    if (pmtSalesTtlStWk.SectionCode == loginInfoAcq.Employee.BelongSectionCode)
                                    {
                                        pmtSalesTtlStWork = pmtSalesTtlStWk;
                                        break;
                                    }
                                }
                                //履歴取得パラメータ処理
                                if (resultList[n] is PmTabPrtPprParaWork)
                                {
                                    PmTabPrtPprParaWork pmTabPrtPprPara = new PmTabPrtPprParaWork();
                                    pmTabPrtPprPara = (PmTabPrtPprParaWork)resultList[n];
                                    // パラメータクラスに戻り値追加後に対応する
                                    totalRecordCount = pmTabPrtPprPara.TotalRecordCount;

                                }
                                if (resultList[n] is PmTabPrtPprRsltWork)
                                {

                                    PmTabPrtPprRsltWork pmTabCustomerTmpWorkResult = new PmTabPrtPprRsltWork();

                                    pmTabCustomerTmpWorkResult = (PmTabPrtPprRsltWork)resultList[n];

                                    // ヘッダ情報の取得
                                    // 伝票番号と受注ステータスのどちらかが変更されたら違うデータとして対応する
                                    //if ((dataNo != pmTabCustomerTmpWorkResult.SalesSlipNum) ||              //2013.07.23 DEL
                                    //    (acptAnOdrStatus != pmTabCustomerTmpWorkResult.AcptAnOdrStatus ))   //2013.07.23 DEL
                                    // 2013.07.23 ADD START >>>>>>
                                    // 結果リストが伝票単位順で戻ってこないので・・・
                                    //　既にリスト済みか否かで判断するように変更します。
                                    bool headerTarget = true;
                                    foreach (int headerNo in headerList)
                                    {
                                        if (pmTabCustomerTmpWorkResult.PmTabSearchSlipNum == headerNo)
                                        {
                                            headerTarget = false;
                                            break;
                                        }
                                    }                                                                   
                                    if(headerTarget == true)
                                    //2013.07.23　ADD END<<<<<<
                                    {

                                        DB_SalesSlipHeader jsPara_PmHeader = new DB_SalesSlipHeader();
                                        jsPara_PmHeader.SalesDate = pmTabCustomerTmpWorkResult.SalesDate;
                                        jsPara_PmHeader.SalesSlipNum = pmTabCustomerTmpWorkResult.SalesSlipNum;
                                        
                                        // 入金伝票番号ならゼロ埋め　2013.07.16 ADD START >>>>
                                        if ((pmTabCustomerTmpWorkResult.SalesDepoDiv == 1) &&
                                           (pmTabCustomerTmpWorkResult.SalesSlipNum.Length != pmTabCustomerTmpWorkResult.SalesSlipNum.Trim().Length))
                                        {
                                            int depositSlipNo = 0;
                                            if (Int32.TryParse(pmTabCustomerTmpWorkResult.SalesSlipNum, out depositSlipNo))
                                            {
                                                jsPara_PmHeader.SalesSlipNum = string.Format("{0:D9}", depositSlipNo);
                                            }
                                        }
                                        // 2013.07.16 ADD END <<<<
                                        jsPara_PmHeader.AcptAnOdrStatus = pmTabCustomerTmpWorkResult.AcptAnOdrStatus;
                                        jsPara_PmHeader.ModelFullName = pmTabCustomerTmpWorkResult.ModelFullName;
                                        jsPara_PmHeader.SalesTotalTaxExc = pmTabCustomerTmpWorkResult.SalesTotalTaxExc;
                                        // 2013.07.17 ADD START >>>>
                                        // 項目追加
                                        //入金区分・売上伝票区分・伝票区分名称
                                        jsPara_PmHeader.SalesDepoDiv = pmTabCustomerTmpWorkResult.SalesDepoDiv;
                                        jsPara_PmHeader.SalesSlipCd = pmTabCustomerTmpWorkResult.SalesSlipCd;
                                        jsPara_PmHeader.SlipDivNm = GetSalesName(pmTabCustomerTmpWorkResult.SalesDepoDiv, pmTabCustomerTmpWorkResult.AcptAnOdrStatus, pmTabCustomerTmpWorkResult.SalesSlipCd); 
                                        // 2013.07.17 ADD END <<<<<<
                                        jsPara_PmHeader.DebitNoteDiv = pmTabCustomerTmpWorkResult.DebitNoteDiv;  // 2013.07.23 ADD　赤伝区分

                                        // --------------------- ADD 2017/10/25 陳艶丹 Redmine#49542 ---------------- >>>>
                                        // 伝票備考
                                        jsPara_PmHeader.SlipNote = pmTabCustomerTmpWorkResult.SlipNote;
                                        // 伝票備考２
                                        jsPara_PmHeader.SlipNote2 = pmTabCustomerTmpWorkResult.SlipNote2;
                                        // 伝票備考３
                                        jsPara_PmHeader.SlipNote3 = pmTabCustomerTmpWorkResult.SlipNote3;
                                        // --------------------- ADD 2017/10/25 陳艶丹 Redmine#49542 ---------------- <<<<

                                        jsParaSalesSlipHeaderList.Add(jsPara_PmHeader);
                                        //dataNo = pmTabCustomerTmpWorkResult.SalesSlipNum; // 2013.07.23 DEL
                                        //acptAnOdrStatus = pmTabCustomerTmpWorkResult.AcptAnOdrStatus; // 2013.07.23 DEL

                                        headerList.Add(pmTabCustomerTmpWorkResult.PmTabSearchSlipNum); // 2013.07.23 ADD
                                        ncnt++;

                                        //検索の最大伝票番号と最小伝票番号を取得
                                        if (salesSlipNumSt == string.Empty) salesSlipNumSt = pmTabCustomerTmpWorkResult.SalesSlipNum;
                                        if (salesSlipNumEd == string.Empty) salesSlipNumEd = pmTabCustomerTmpWorkResult.SalesSlipNum;
                                        if (salesSlipNumSt.CompareTo(pmTabCustomerTmpWorkResult.SalesSlipNum) > 0)
                                            salesSlipNumSt = pmTabCustomerTmpWorkResult.SalesSlipNum;
                                        if (salesSlipNumEd.CompareTo(pmTabCustomerTmpWorkResult.SalesSlipNum) < 0)
                                            salesSlipNumEd = pmTabCustomerTmpWorkResult.SalesSlipNum;

                                    }
                                    //明細情報の書き込み
                                    DB_SalesSlipDetail jsPara_PmDetail = new DB_SalesSlipDetail();

                                    jsPara_PmDetail.SalesSlipNum = pmTabCustomerTmpWorkResult.SalesSlipNum;
                                    // 入金伝票番号ならゼロ埋め　2013.07.16 ADD START >>>>
                                    if ((pmTabCustomerTmpWorkResult.SalesDepoDiv == 1) &&
                                       (pmTabCustomerTmpWorkResult.SalesSlipNum.Length != pmTabCustomerTmpWorkResult.SalesSlipNum.Trim().Length))
                                    {
                                        int depositSlipNo = 0;
                                        if (Int32.TryParse(pmTabCustomerTmpWorkResult.SalesSlipNum, out depositSlipNo))
                                        {
                                            jsPara_PmDetail.SalesSlipNum = string.Format("{0:D9}", depositSlipNo);
                                        }
                                    }
                                    // 2013.07.16 ADD END
                                    jsPara_PmDetail.AcptAnOdrStatus = pmTabCustomerTmpWorkResult.AcptAnOdrStatus;
                                    jsPara_PmDetail.SalesDepoDiv = pmTabCustomerTmpWorkResult.SalesDepoDiv;
                                    
                                    //売上区分表示方法確定次第対応
                                    //jsPara_PmDetail.SalesSlipCd = pmTabCustomerTmpWorkResult.SalesSlipCd; //売上伝票区分
                                    //jsPara_PmDetail.SalesSlipCd = pmTabCustomerTmpWorkResult.SalesSlipCdDtl;//売上伝票区分（明細）
                                    jsPara_PmDetail.SalesSlipCdDtl = pmTabCustomerTmpWorkResult.SalesSlipCdDtl;//売上伝票区分（明細）
                                    
                                    //伝票区分名称
                                    // 売上区分表示方式確定後対応(明細の売上区分名を表示）
                                    jsPara_PmDetail.SlipDivDtlNm = GetSalesName(pmTabCustomerTmpWorkResult.SalesDepoDiv, pmTabCustomerTmpWorkResult.AcptAnOdrStatus, pmTabCustomerTmpWorkResult.SalesSlipCdDtl);
                                    
                                    jsPara_PmDetail.AutoAnswerDivSCM = pmTabCustomerTmpWorkResult.AutoAnswerDivSCM;
                                    jsPara_PmDetail.AutoAnswerDivSCMNm = GetAutoAnswerDivSCMName(pmTabCustomerTmpWorkResult.AutoAnswerDivSCM);  //AutoAnswerDivSCMから変換処理実施する必要あり;

                                    jsPara_PmDetail.DebitNoteDiv = pmTabCustomerTmpWorkResult.DebitNoteDiv;  // 2013.07.23 ADD 赤伝区分

                                    jsPara_PmDetail.ModelFullName = pmTabCustomerTmpWorkResult.ModelFullName;
                                    jsPara_PmDetail.FullModel = pmTabCustomerTmpWorkResult.FullModel;
                                    jsPara_PmDetail.ModelDesignationNo = pmTabCustomerTmpWorkResult.ModelDesignationNo;
                                    jsPara_PmDetail.CategoryNo = pmTabCustomerTmpWorkResult.CategoryNo;
                                    jsPara_PmDetail.BLGoodsCode = pmTabCustomerTmpWorkResult.BLGoodsCode;
                                    jsPara_PmDetail.GoodsMakerCd = pmTabCustomerTmpWorkResult.GoodsMakerCd;
                                    jsPara_PmDetail.GoodsNo = pmTabCustomerTmpWorkResult.GoodsNo;
                                    jsPara_PmDetail.GoodsName = pmTabCustomerTmpWorkResult.GoodsName;
                                    jsPara_PmDetail.ListPriceTaxExcFl = pmTabCustomerTmpWorkResult.ListPriceTaxExcFl;
                                    jsPara_PmDetail.SalesUnPrcTaxExcFl = pmTabCustomerTmpWorkResult.SalesUnPrcTaxExcFl;
                                    
                                    //売上金額表示方法確定次第対応(現在、計金額に明細の売上金額をセット）
                                    //jsPara_PmDetail.SalesTotalTaxExc = pmTabCustomerTmpWorkResult.SalesTotalTaxExc;//売上金額計
                                    //jsPara_PmDetail.SalesTotalTaxExc = pmTabCustomerTmpWorkResult.SalesMoneyTaxExc;  //売上金額
                                    jsPara_PmDetail.SalesMoneyTaxExc = pmTabCustomerTmpWorkResult.SalesMoneyTaxExc;  //売上金額
                                    
                                    jsPara_PmDetail.ShipmentCnt = pmTabCustomerTmpWorkResult.ShipmentCnt;
                                    jsPara_PmDetail.SalesUnitCost = pmTabCustomerTmpWorkResult.SalesUnitCost;
                                  　
                                    //原価表示方法確定次第対応（現在、原価計に明細の原価をセット）
                                    //jsPara_PmDetail.TotalCost = pmTabCustomerTmpWorkResult.TotalCost;  //原価金額計
                                    //jsPara_PmDetail.TotalCost = pmTabCustomerTmpWorkResult.Cost;　　　 //原価（明細）
                                    jsPara_PmDetail.Cost = pmTabCustomerTmpWorkResult.Cost;　　　 //原価（明細）

                                    jsParaSalesSlipDetailList.Add(jsPara_PmDetail);
                                }
                            }
                        }else{
                            if (obj is PmTabPrtPprParaWork)
                            {
                                PmTabPrtPprParaWork pmTabPrtPprPara = obj as PmTabPrtPprParaWork;
                                if (pmTabPrtPprPara != null)
                                {
                                    // パラメータクラスに戻り値追加後に対応する
                                    totalRecordCount = pmTabPrtPprPara.TotalRecordCount;
                                }
                            }
                        }
                    }

                    #endregion

                    JsonObject resultObj = new JsonObject();
                    resultObj.SetValue("TotalRecordCount", totalRecordCount);
                    resultObj.SetValue(ctJSPara_PmSearchEndCount, ncnt);
                    resultObj.SetValue(ctJSPara_PmSalesSlipNumSt, salesSlipNumSt);
                    resultObj.SetValue(ctJSPara_PmSalesSlipNumEd, salesSlipNumEd);
                    resultObj.SetValue(ctJSPara_PmDwnPlcDspDivCd, pmtSalesTtlStWork.DwnPlcDspDivCd); // 全体設定.小数点表示区分

                    resultObj.SetValue(ctJSPara_SalesSlipHeaderArray, (JsonArray)JsonSerializer.ConvertToJsonValue(jsParaSalesSlipHeaderList.ToArray()));
                    resultObj.SetValue(ctJSPara_SalesSlipDetailArray, (JsonArray)JsonSerializer.ConvertToJsonValue(jsParaSalesSlipDetailList.ToArray()));

                    resultValue = resultObj;
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    errMsg = string.Empty;

            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて例外が発生しました。", -1, ex);
            }

            return status;
        }
 
        #endregion


        #region ■得意先伝票履歴選択処理(履歴から部品追加注文へ遷移する場合にCALL）
        /// <summary>
        /// 得意先伝票履歴選択部品追加発注処理
        /// </summary>
        /// <param name="parameterValue">パラメータ情報</param>
        /// <param name="resultValue">レスポンス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note        : 得意先伝票履歴から車両情報を取得します。</br>
        /// <br>Programmer  : 95094　大塚　たえ子</br>
        /// <br>Date        : 2013.05.28</br>
        /// </remarks>
        private int GetCustSlipHisPartsOdrInfoProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = String.Empty;

            try
            {
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();

                JsonObject paramObj = parameterValue as JsonObject;

                // ログイン従業員の企業コード、拠点コード取得
                AspLoginInfoAcquisition loginInfoAcq = new AspLoginInfoAcquisition();
                string enterpriseCode = loginInfoAcq.EnterpriseCode;

                // 検索条件の設定
                string businessSessionId = string.Empty;
                string para_SalesSlipNum = string.Empty;
                int para_AcptAnOdrStatus = 0;

                // 検索条件（必須）
                if (paramObj != null)
                {
                    // 検索条件（任意）
                    // 業務セッションID
                    if (paramObj.HasValueString(ctJSPara_BusinessSessionId))
                    {
                        businessSessionId = paramObj.GetValueString(ctJSPara_BusinessSessionId);
                    }
                    //売上伝票番号
                    if (paramObj.HasValueString(ctJSPara_SalesSlipNum))
                    {
                        para_SalesSlipNum = paramObj.GetValueString(ctJSPara_SalesSlipNum);
                    }
                    //受注ステータス
                    para_AcptAnOdrStatus = paramObj.GetValueInt32(ctJSPara_PmAcptAnOdrStatus);
                }

                if (this._pMTabletBusinessSessionDBAcs == null)
                    this._pMTabletBusinessSessionDBAcs = new PMTabletBusinessSessionDBAcs();
                //インスタンス化
                //USERデータアプリケーションサーバーのPathを取得（提供データAPサーバーの場合には引数を変える）
                string wkStr_Scm_User = loginInfoAcq.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP);

                //AppSettingsからの取得は行わず自分で引数文字列を生成する
                if (this._pMTabletDispInfoDB == null)
                    this._pMTabletDispInfoDB = (IPMTabletDispInfoDB)Activator.GetObject(typeof(IPMTabletDispInfoDB), string.Format("{0}/MyAppPMTabletDispInfo", wkStr_Scm_User));

                if (this._pMTabletBusinessSessionDBAcs == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴選択処理にて初期化エラーが発生しました。", -1, null);
                }
                if (this._pMTabletDispInfoDB == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴選択処理にて初期化エラーが発生しました。", -1, null);
                }
                bool msgDiv = false;

                // 業務セッションチェック処理
                if (!this.BusinessSessionIdValidChk(businessSessionId, out msgDiv, out errMsg))
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                PmTabPrtPprParaWork pmTabPrtPprParaWork = new PmTabPrtPprParaWork();
                pmTabPrtPprParaWork.EnterpriseCode = enterpriseCode;
                pmTabPrtPprParaWork.PmTabSearchGuid = businessSessionId;    //検索GUID(業務セッションID）
                pmTabPrtPprParaWork.SalesSlipNum = para_SalesSlipNum;       //売上伝票番号
                pmTabPrtPprParaWork.AcptAnOdrStatus = para_AcptAnOdrStatus; // 受注ステータス
                
                paraList.Add(pmTabPrtPprParaWork);

                object retObj = paraList;

                PmTabPrtPprRsltWork pmTabCustomerTmpWorkResult = new PmTabPrtPprRsltWork();
                // 履歴情報取得
                status = this._pMTabletDispInfoDB.GetPMTabletDispInfo(businessSessionId, enterpriseCode, ref retObj, out msgDiv, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    #region レスポンスセット
                    CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                    if (retList.Count > 0)
                    {
                        string dataNo = string.Empty;
                        string salesSlipNumSt = string.Empty;
                        string salesSlipNumEd = string.Empty;

                        foreach (object obj in retList)
                        {
                            ArrayList resultList = obj as ArrayList;
                            if (resultList != null)
                            {
                                for (int n = 0; n < resultList.Count; n++)
                                {
                                    if (resultList[n] is PmTabPrtPprRsltWork)
                                    {
                                        PmTabPrtPprRsltWork pmTabCustomerTmpWorkRet = new PmTabPrtPprRsltWork();
                                        //複数明細でも先頭情報のみの判定でOK
                                        pmTabCustomerTmpWorkRet = (PmTabPrtPprRsltWork)resultList[n];
                                        if (pmTabCustomerTmpWorkRet.SalesSlipNum == para_SalesSlipNum)
                                        {
                                            if ((pmTabCustomerTmpWorkRet.ModelDesignationNo == 0) &&
                                                (pmTabCustomerTmpWorkRet.CategoryNo == 0) &&
                                                (pmTabCustomerTmpWorkRet.FullModel == string.Empty))
                                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                            else
                                                pmTabCustomerTmpWorkResult = pmTabCustomerTmpWorkRet;
                                            
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                errMsg = "伝票履歴から車両情報が取得できません";
                            }
                        }
                    }
                    else
                    {
                        // 検索データ無し
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        errMsg = "伝票履歴から車両情報が取得できません";
                    }

                    // 売上（車両）がある場合は、下記処理を実行する
                    if ((CarDataChk(businessSessionId, enterpriseCode) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        || (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {


                        // 車両確定処理を実行する（PMTAB08011A)
                        DBPmCarSelectWebAcs dBPmCarSelectWebAcs = new DBPmCarSelectWebAcs();
                        JsonObject paraval = new JsonObject();
                        JsonValue retbval = null;

                        paraval.SetValue(ctJSPara_BusinessSessionId, businessSessionId);
                        paraval.SetValue("ModelDesignationNo", pmTabCustomerTmpWorkResult.ModelDesignationNo);
                        paraval.SetValue("CategoryNo", pmTabCustomerTmpWorkResult.CategoryNo);
                        paraval.SetValue("FullModel", pmTabCustomerTmpWorkResult.FullModel);
                        paraval.SetValue("FrameNo", pmTabCustomerTmpWorkResult.FrameNo);
                        paraval.SetValue("RpColorCode", pmTabCustomerTmpWorkResult.ColorCode);
                        //paraval.SetValue("TrimCode", pmTabCustomerTmpWorkResult.TrimCode);
                        paraval.SetValue("ColorName1", pmTabCustomerTmpWorkResult.ColorName1);　//2013.07.16 ADD
                        // 項目追加 2013.08.05 ADD START >>>>>>>>>>>>>>>>>>>
                        paraval.SetValue("MakerName", pmTabCustomerTmpWorkResult.MakerName);
                        #region Del 2014.10.07 duzg For Readmine#43261のシステムテスト障害№8対応
                        //string str = pmTabCustomerTmpWorkResult.ModelFullName;
                        //string modelName = Microsoft.VisualBasic.Strings.StrConv(str, VbStrConv.Narrow, 0);
                        //paraval.SetValue("ModelName", modelName);
                        #endregion
                        paraval.SetValue("ModelName", pmTabCustomerTmpWorkResult.ModelFullName);// Add 2014.10.07 duzg For Readmine#43261のシステムテスト障害№8対応
                        paraval.SetValue("MakerCode", pmTabCustomerTmpWorkResult.MakerCode);
                        paraval.SetValue("ModelCode", pmTabCustomerTmpWorkResult.ModelCode);
                        paraval.SetValue("ModelSubCode", pmTabCustomerTmpWorkResult.ModelSubCode);　

                        // 2013.08.05 ADD END <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        int statusDb = dBPmCarSelectWebAcs.WriteCarDeterminedInfoDataForCustSlipHis(paraval, out retbval, out errMsg);

                        if (statusDb != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            status = statusDb;
                    }
                    #endregion
                    resultValue = null;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    errMsg = string.Empty;

            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(CT_PGID, "得意先伝票履歴処理", "得意先伝票履歴処理にて例外が発生しました。", -1, ex);
            }

            return status;
        }

        #endregion
        
        #endregion

        #region << Private Method >>

        #region 業務セッションID有効チェック
        /// <summary>
        /// 業務セッションID有効チェック
        /// </summary>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <returns>チェック結果[true:有効 false:無効]</returns>
        /// <remarks>
        /// <br>Note        :  業務セッションIDが有効かチェックします。</br>
        /// </remarks>
        private bool BusinessSessionIdValidChk(string businessSessionId, out bool msgDiv, out string errMsg)
        {
            bool reChk = false;
            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                if ((businessSessionId == null) || (businessSessionId.Length < 1))
                    return reChk;

                // 業務セッション有効チェック
                if (_pMTabletBusinessSessionDBAcs == null)
                    _pMTabletBusinessSessionDBAcs = new PMTabletBusinessSessionDBAcs();
                reChk = this._pMTabletBusinessSessionDBAcs.CheckBusinessSessionValid(businessSessionId, out msgDiv, out errMsg);

            }
            catch (MobileWebException)
            {
                throw ;
            }
            catch (Exception ex)
            {
                throw new MobileWebException(CT_PGID, "業務セッション有効チェック処理", "業務セッション有効チェック処理にて例外が発生しました。\r\n", -1, ex);
            }

            return reChk;
        }
        #endregion


        #region 売上（車両情報）TMP有無チェック
        /// <summary>
        /// 売上（車両情報）存在チェック処理
        /// </summary>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>データ有無ステータス</returns>
        private int CarDataChk(string businessSessionId, string enterpriseCode)
        {

            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            PmTabSalesDtCarWork pmTabSalesDtCarWorkPara = new PmTabSalesDtCarWork();
            pmTabSalesDtCarWorkPara.BusinessSessionId = businessSessionId;
            paraList.Add(pmTabSalesDtCarWorkPara);

            string errMsg = string.Empty;
            object retObj = paraList;
            bool msgDiv = false;

            // 業務セッションID
            JsonObject resultObj = new JsonObject();

            // 業務セッション有効チェック
            if (!this.BusinessSessionIdValidChk(businessSessionId, out msgDiv, out errMsg))
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            PmTabSalesDtCarWork pmTabSalesDtCarWork = new PmTabSalesDtCarWork();

            int status = this._pMTabletDispInfoDB.GetPMTabletDispInfo(businessSessionId, enterpriseCode, ref retObj, out msgDiv, out errMsg);

            int dbCarStatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;

                foreach (object obj in retList)
                {
                    ArrayList resultList = obj as ArrayList;
                    for (int n = 0; n < resultList.Count; n++)
                    {
                        if (resultList[n] is PmTabSalesDtCarWork)
                        {
                            //1件取得
                            pmTabSalesDtCarWork = (PmTabSalesDtCarWork)resultList[n];
                            dbCarStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }
                }
            }
            return dbCarStatus;
        }
        #endregion


        #region 伝票関連名称取得処理

        /// <summary>
        /// 受注ステータス名称取得処理
        /// </summary>
        /// <param name=" acptAnOdrStatus">受注ステータス</param>
        /// <returns>受注ステータス名称</returns>
        private string GetAcptAnOdrStatusName(int acptAnOdrStatus)
        {
            //10:見積,11:見積キャンセル,20:受注,21:受注キャンセル,30:売上
            switch (acptAnOdrStatus)
            {
                case 10: return "見積";
                case 11: return "見積キャンセル";
                case 20: return "受注";
                case 21: return "受注キャンセル";
                case 30: return "売上";
                case 40: return "貸出";
                default: return string.Empty;
            }
        }
        /// <summary>
        /// 伝票区分名称取得処理
        /// </summary>
        /// <param name="salesDepoDiv">売上入金区分</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipCd">売上伝票区分</param>
        /// <returns>伝票区分名称</returns>
        private string GetSalesName(int salesDepoDiv, int acptAnOdrStatus, int salesSlipCd)
        {
            string retName = string.Empty;
            //0:売上,1:入金
            switch (salesDepoDiv)
            {
                case 0: 
                    {
                        return  GetSalesSlipCdName(acptAnOdrStatus, salesSlipCd);
                    } 
                case 1: return "入金";
                default: return string.Empty;
            }
        }
        /// <summary>
        /// 売上伝票区分名称取得
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipCd">売上伝票区分</param>
        /// <returns>売上伝票区分名称</returns>
        private string GetSalesSlipCdName(int acptAnOdrStatus, int salesSlipCd)
        {
            //0:売上,1:返品,2:値引,3:注釈
            switch (salesSlipCd)
            {
                case 0:
                {
                    return GetAcptAnOdrStatusName(acptAnOdrStatus);
                }
                case 1: return "返品";
                case 2: return "値引";
                // 2013.07.16 ADD 注釈対応　0：売上と同様の内容で表示する
                case 3: return GetAcptAnOdrStatusName(acptAnOdrStatus);
                default: return string.Empty;
            }
        }
        /// <summary>
        /// 自動回答区分(SCM)名称
        /// </summary>
        /// <param name="autoAnswerDivSCM">自動回答区分(SCM)</param>
        /// <returns>自動回答区分(SCM)名称</returns>
        private string GetAutoAnswerDivSCMName(int autoAnswerDivSCM)
        {
            //0:通常(PCC連携なし)、1:手動回答、2:自動回答
            switch (autoAnswerDivSCM)
            {
//                case 0: return "通常(PCC連携なし)";
//                case 0: return "通常";
                case 1: return "手動回答";
                case 2: return "自動回答";
                default: return string.Empty;
 
            }
        }
        #endregion
     
        #endregion
    }
}

/****************************************************************/
/*                     JSONパラメータクラス                     */
/****************************************************************/
namespace Broadleaf.Application.Remoting.ParamData
{

}

/****************************************************************/
/*                    JSONオブジェクトクラス                    */
/****************************************************************/
namespace Broadleaf.Application.Remoting.ParamData
{
    #region 拠点情報オブジェクトクラス
    /// <summary>
    ///拠点情報オブジェクトクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 95094　大塚　たえ子</br>
    /// <br>Date        : 2013.05.28</br>
    /// </remarks>
    [Serializable]
    public class DBMnt_SectionInfo
    {
        public DBMnt_SectionInfo()
        {
        }

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>拠点名称</summary>
        private string _sectionName = string.Empty;

        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }
    }
    #endregion


    #region 履歴ヘッダ情報オブジェクトクラス
    /// <summary>
    /// 履歴ヘッダ情報オブジェクトクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 95094　大塚　たえ子</br>
    /// <br>Date        : 2013.05.28</br>
    /// </remarks>
    [Serializable]
    public class DB_SalesSlipHeader
    {
        public DB_SalesSlipHeader()
        {
        }

        /// <summary>売上日付</summary>
        private Int32 _salesDate = 0;

        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }
        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = string.Empty;

        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// <summary>受注ステータス</summary>
        private Int32 _acptAnOdrStatus = 0;

        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>車種全角名称</summary>
        private string _modelFullName = string.Empty;

        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }
        /// <summary>売上伝票合計（税抜き）</summary>
        private Int64 _salesTotalTaxExc = 0;

        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }
        //2013.07.17 ADD START >>>>>>>>>>>>>>>>>
        /// <summary>売上入金区分</summary>
        private Int32 _salesDepoDiv = 0;

        public Int32 SalesDepoDiv
        {
            get { return _salesDepoDiv; }
            set { _salesDepoDiv = value; }
        }

        /// <summary>売上伝票区分</summary>
        private Int32 _salesSlipCd = 0;

        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }
        /// <summary>伝票区分名称</summary>
        private string _slipDivNm = string.Empty;

        public string SlipDivNm
        {
            get { return _slipDivNm; }
            set { _slipDivNm = value; }
        }
        // 2013.07.17 ADD END <<<<<<<<<<<<<<<<
        /// <summary>赤伝区分 2013.07.23 ADD</summary>
        private Int32 _debitNoteDiv = 0;

        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        // --------------------- ADD 2017/10/25 陳艶丹 Redmine#49542 ---------------- >>>>
        /// <summary>伝票備考</summary>
        private string _slipNote = string.Empty;

        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// <summary>伝票備考２</summary>
        private string _slipNote2 = string.Empty;

        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// <summary>伝票備考３</summary>
        private string _slipNote3 = string.Empty;

        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }
        // --------------------- ADD 2017/10/25 陳艶丹 Redmine#49542 ---------------- <<<<

    }
    #endregion

    #region 履歴明細情報オブジェクトクラス
    /// <summary>
    /// 履歴明細情報オブジェクトクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : 95094　大塚　たえ子</br>
    /// <br>Date        : 2013.05.28</br>
    /// </remarks>
    [Serializable]
    public class DB_SalesSlipDetail
    {
        public DB_SalesSlipDetail()
        {
        }
        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = string.Empty;

        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// <summary>受注ステータス</summary>
        private Int32 _acptAnOdrStatus = 0;

        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// <summary>売上入金区分</summary>
        private Int32 _salesDepoDiv = 0;

        public Int32 SalesDepoDiv
        {
            get { return _salesDepoDiv; }
            set { _salesDepoDiv = value; }
        }

        /// <summary>売上伝票区分（明細）</summary>
        private Int32 _salesSlipCdDtl = 0;

        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }
        /// <summary>伝票区分名称（明細）</summary>
        private string _slipDivDtlNm = string.Empty;

        public string SlipDivDtlNm
        {
            get { return _slipDivDtlNm; }
            set { _slipDivDtlNm = value; }
        }


        /// <summary>赤伝区分 2013.07.23 ADD</summary>
        private Int32 _debitNoteDiv = 0;

        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        
        /// <summary>自動回答区分(SCM)</summary>
        private Int32 _autoAnswerDivSCM = 0;

        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        /// <summary>自動回答区分(SCM)名称</summary>
        private string _autoAnswerDivSCMNm = string.Empty;

        public string AutoAnswerDivSCMNm
        {
            get { return _autoAnswerDivSCMNm; }
            set { _autoAnswerDivSCMNm = value; }
        }
        /// <summary>車種全角名称</summary>
        private string _modelFullName = string.Empty;

        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }
        /// <summary>型式（フル型）</summary>
        private string _fullModel = string.Empty;

        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }
        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo = 0;

        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }
        /// <summary>類別番号</summary>
        private Int32 _categoryNo = 0;

        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode = 0;

        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd = 0;

        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>商品番号</summary>
        private string _goodsNo = string.Empty;

        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }
        /// <summary>商品名称</summary>
        private string _goodsName = string.Empty;

        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// <summary>定価（税抜，浮動）</summary>
        private Double _listPriceTaxExcFl = 0;

        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl = 0;

        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _salesMoneyTaxExc = 0;

        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }
        /// <summary>出荷数</summary>
        private Double _shipmentCnt = 0;

        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// <summary>原価単価</summary>
        private Double _salesUnitCost = 0;

        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }
        /// <summary>原価</summary>
        private Int64 _cost = 0;

        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
    #endregion

}

