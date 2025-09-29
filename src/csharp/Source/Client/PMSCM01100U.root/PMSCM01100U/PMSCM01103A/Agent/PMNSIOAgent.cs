//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/03/05  修正内容 : ユーザDBデータ(受注データ、車両情報、明細情報)取得時に、自拠点コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/03/15  修正内容 : 起動パラメータに伝票番号の追加
//                                  2010/03/05の不具合対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/03/30  修正内容 : 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/04/08  修正内容 : 起動パラメータの変更
//                                  (売上伝票入力から１問合せに対し複数伝票となる登録を行った場合、最終伝票しか送信されない為)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/17  修正内容 : SCM障害対応 SCM連携未送信データ取得条件を修正 №10414
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/03/11  修正内容 : SCM仕掛一覧№10639対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/30  修正内容 : ②SCM仕掛一覧№10707 ログ出力の追加
//----------------------------------------------------------------------------//

#define _LOCAL_DEBUG_

using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller.Util; // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707

//#if _LOCAL_DEBUG_

//using SCMLocalDebug;

//#endif

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// PM.NSのI/Oアクセスの代理人クラス
    /// </summary>
    public sealed class PMNSIOAgent : SCMIOAgent
    {
        /// <summary>ログ用の名称</summary>
        private const string MY_NAME = "PMNSIOAgent";

        #region <本物のアクセサ>

        /// <summary>本物のアクセサ</summary>
        private IIOWriteScmDB _realAccesser;
        /// <summary>本物のアクセサを取得します。</summary>
        private IIOWriteScmDB RealAccesser
        {
            get
            {
                if (_realAccesser == null)
                {
                    _realAccesser = MediationIOWriteScmDB.GetIOWriteScmDB();
                }
                return _realAccesser;
            }
        }

        #endregion // </本物のアクセサ>

        #region <得意先マスタ>

        /// <summary>得意先マスタDBのアクセサ</summary>
        private CustomerAgent _customerDB;
        /// <summary>得意先マスタDBのアクセサを取得します。</summary>
        private CustomerAgent CustomerDB
        {
            get
            {
                if (_customerDB == null)
                {
                    _customerDB = new CustomerAgent();
                }
                return _customerDB;
            }
        }

        #endregion // </得意先マスタ>

        #region <Constructor>

        // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
        ///// <summary>
        ///// デフォルトコンストラクタ
        ///// </summary>
        //public PMNSIOAgent() : base() { }
        // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<
        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="withoutCustomerInfo">得意先を必要としないフラグ</param>
        public PMNSIOAgent(bool withoutCustomerInfo) : base(withoutCustomerInfo) { }
        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<

        #endregion // </Constructor>

        #region <検索結果>
        List<ISCMOrderHeaderRecord> _headerList;
        List<ISCMOrderAnswerRecord> _answerList;
        List<ISCMOrderCarRecord> _carList;
        // -- ADD 2011/08/10   ------ >>>>>>
        List<ISCMAcOdSetDtRecord> _setDtList;
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <SCMデータ検索>
        /// <summary>
        /// 送信するSCM受注データを検索します。
        /// </summary>
        /// <returns>送信するSCM受注データ</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderHeaderRecord> FindSendingHeaderData()
        {
            IList<ISCMOrderHeaderRecord> foundList = new List<ISCMOrderHeaderRecord>();
            {
                if (this._headerList != null)
                {
                    foundList = this._headerList;
                }
                else
                {
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._headerList;
                    }
                }
            }
            return foundList;
        }

        /// <summary>
        /// 送信するSCM受注明細データ(回答)を検索します。
        /// </summary>
        /// <returns>送信するSCM受注明細データ(回答)</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderAnswerRecord> FindSendingAnswerData()
        {
            IList<ISCMOrderAnswerRecord> foundList = new List<ISCMOrderAnswerRecord>();
            {
                if (this._answerList != null)
                {
                    foundList = this._answerList;
                }
                else
                {
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._answerList;
                    }
                }

            }
            return foundList;
        }

        /// <summary>
        /// 送信するSCM受注データ(車両情報)を検索します。
        /// </summary>
        /// <returns>送信するSCM受注データ(車両情報)</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderCarRecord> FindSendingCarData()
        {
            IList<ISCMOrderCarRecord> foundList = new List<ISCMOrderCarRecord>();
            {
                if (this._carList != null)
                {
                    foundList = this._carList;
                }
                else
                {
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._carList;
                    }
                }
            }
            return foundList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// 送信するSCMセットマスタを検索します。
        /// </summary>
        /// <returns>送信するSCMセットマスタ</returns>
        protected override IList<ISCMAcOdSetDtRecord> FindSendingSetDtData()
        {
            IList<ISCMAcOdSetDtRecord> foundList = new List<ISCMAcOdSetDtRecord>();
            {
                if (this._setDtList != null)
                {
                    foundList = this._setDtList;
                }
                else
                {
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._setDtList;
                    }
                }
            }
            return foundList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        /// <summary>
        /// ユーザDBデータ(受注データ、車両情報、明細情報)を取得する。
        /// </summary>
        /// <returns></returns>
        private int GetUserDBData()
        {
            const string METHOD = "GetUserDBData";
            const string INDENT = "\t    ";

            #region テストロジック
            //this._headerList = CreateScmOdrDataForTest();
            //this._detailList = new List<ISCMOrderDetailRecord>();
            //this._answerList = CreateScmOdDtAnsForTest();
            //this._carList = CreateScmOdDtCarForTest();

            //return 0;
            #endregion

            // --- ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707 ------------------------------>>>>>
            try
            {
            // --- ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707 ------------------------------<<<<<
                this._headerList = new List<ISCMOrderHeaderRecord>();
                this._answerList = new List<ISCMOrderAnswerRecord>();
                this._carList = new List<ISCMOrderCarRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                _setDtList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<

                IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();

                // 未送信データの取得
                readWork.EnterpriseCode = EnterpriseCd;
                // 2010/03/15 Del >>>
                ////>>>2010/03/05
                //readWork.InqOtherSecCd = BelongSectionCode;
                ////<<<2010/03/05
                // 2010/03/15 Del <<<

                // ADD 2014/03/11 SCM仕掛一覧№10639 -------------------------------------------------------------->>>>>
                object paraSalesSlipNumList = (object)SalesSlipNumList;
                // ADD 2014/03/11 SCM仕掛一覧№10639 --------------------------------------------------------------<<<<< 
                object paraObject = readWork; // 引数
                object retObject = new CustomSerializeArrayList(); // 戻り

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "IIOWriteScmDB.ScmZeroSearch()：リモートアクセス中…");
                // CHG 2014/03/11 SCM仕掛一覧№10639 -------------------------------------------------------------->>>>>
                //int status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject);
                // UPD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                //int status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject, paraSalesSlipNumList, InquiryNumber);
                int retryLimit = 0;              // リトライ回数
                int sleepMS = 0;  // 待ち
                if (SettingInformation != null)
                {
                    // 設定情報プロパティが設定されている場合リトライ設定を取得する
                    retryLimit = SettingInformation.ReadRetry;
                    // ThreadSleepの精度ミリ秒なので1000倍する
                    sleepMS = SettingInformation.ReadSleepSec * 1000;
                }

                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                int count = 0;
                for (count = 0; count <= retryLimit; count++)
                {
                    status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject, paraSalesSlipNumList, InquiryNumber);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                    System.Threading.Thread.Sleep(sleepMS);
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, string.Format("{0}リトライ回数:{1}", INDENT, count));
                // UPD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                // CHG 2014/03/11 SCM仕掛一覧№10639 --------------------------------------------------------------<<<<<
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "IIOWriteScmDB.ScmZeroSearch()：リモートアクセス完了");

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "DB取得結果を展開中…");
                    // 展開
                    foreach (object ret in (CustomSerializeArrayList)retObject)
                    {
                        SCMAcOdrDataWork header;
                        List<SCMAcOdrDtlIqWork> detailList;
                        List<SCMAcOdrDtlAsWork> answerList;
                        SCMAcOdrDtCarWork car;

                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<SCMAcOdSetDtWork> setDtList;
                        // -- ADD 2011/08/10   ------ <<<<<<

                        //IOWriterUtil.ExpandSCMReadRet(ret, out header, out detailList, out answerList, out car);              // DEL 2011/08/12
                        IOWriterUtil.ExpandSCMReadRet(ret, out header, out detailList, out answerList, out setDtList, out car); // ADD 2011/08/12

                        // 回答データがないデータは対象外
                        if (answerList.Count == 0)
                        {
                            continue;
                        }

                        // >>> 2010/04/08
                        //// 2010/03/15 Add >>>
                        //// 受注ステータスがセットされている場合
                        //if (AcptAnOdrStatus != 0)
                        //{
                        //    // 送信対象のデータ以外は対象外
                        //    if (header.AcptAnOdrStatus != AcptAnOdrStatus || header.SalesSlipNum.Trim() != SalesSlipNum.Trim())
                        //    {
                        //        continue;
                        //    }
                        //}
                        //// 2010/03/15 Add <<<

                        // 問合せ番号が設定されている場合、同問合せ番号のみ送信対象とする
                        if (InquiryNumber != 0)
                        {
                            if ((header.InquiryNumber != InquiryNumber) || (header.InqOrdDivCd != InqOrdDivCd))
                            {
                                continue;
                            }
                        }
                        //<<<2010/04/08

                        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
                        // パラメータに売上伝票番号が設定されている時、対象売上伝票番号のみ送信対象とする
                        bool retFound = false;  // true:送信対象　false:送信対象外
                        if (SalesSlipNumList != null && SalesSlipNumList.Count != 0)
                        {
                            for (int i = 0; i < SalesSlipNumList.Count; i++)
                            {
                                if (header.SalesSlipNum.Trim() == SalesSlipNumList[i].Trim())
                                {
                                    retFound = true;
                                    break;
                                }
                            }
                            if (!retFound)
                            {
                                continue;
                            }
                        }
                        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<

                        this._headerList.Add(new UserSCMOrderHeaderRecord(header));

                        answerList.Sort(new SCMAcOdrDtlAsWorkCompare());    // 2010/03/24 Add

                        foreach (SCMAcOdrDtlAsWork answer in answerList)
                        {
                            this._answerList.Add(new UserSCMOrderAnswerRecord(answer));
                        }

                        this._carList.Add(new UserSCMOrderCarRecord(car));

                        // -- ADD 2011/08/10   ------ >>>>>>
                        if (setDtList != null && setDtList.Count > 0)
                        {
                            setDtList.Sort(new SCMAcOdrSetDtWorkCompare());

                            foreach (SCMAcOdSetDtWork setDt in setDtList)
                            {
                                this._setDtList.Add(new UserSCMAcOdSetDtRecord(setDt));
                            }
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "DB取得結果を展開完了");

                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD,
                        string.Format("{0}ユーザDBデータ取得でエラー ステータス：{1}", INDENT, status));
                    // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            // --- ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707 ------------------------------>>>>>
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, MsgHelper.GetDebugMsg(msg));
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // --- ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707 ------------------------------<<<<<
        }

        /// <summary>
        /// SCM受発注明細データ（回答）を、キー順にソートする(行番号、行枝番のみ逆順
        /// </summary>
        /// <remarks></remarks>
        private class SCMAcOdrDtlAsWorkCompare : Comparer<SCMAcOdrDtlAsWork>
        {
            public override int Compare(SCMAcOdrDtlAsWork x, SCMAcOdrDtlAsWork y)
            {
                int result = x.InqOriginalEpCd.Trim().CompareTo(y.InqOriginalEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOriginalSecCd.Trim().CompareTo(y.InqOriginalSecCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherEpCd.Trim().CompareTo(y.InqOtherEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherSecCd.Trim().CompareTo(y.InqOtherSecCd.Trim());
                if (result != 0) return result;

                result = x.InquiryNumber.CompareTo(y.InquiryNumber);
                if (result != 0) return result;

                result = x.UpdateDate.CompareTo(y.UpdateDate);
                if (result != 0) return result;

                result = x.UpdateTime.CompareTo(y.UpdateTime);
                if (result != 0) return result;

                result = y.InqRowNumber.CompareTo(x.InqRowNumber);
                if (result != 0) return result;

                result = y.InqRowNumDerivedNo.CompareTo(x.InqRowNumDerivedNo);
                if (result != 0) return result;

                return result;
            }
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCMセットマスタを、キー順にソートする(行番号、行枝番のみ逆順
        /// </summary>
        /// <remarks></remarks>
        private class SCMAcOdrSetDtWorkCompare : Comparer<SCMAcOdSetDtWork>
        {
            public override int Compare(SCMAcOdSetDtWork x, SCMAcOdSetDtWork y)
            {
                int result = x.InqOriginalEpCd.Trim().CompareTo(y.InqOriginalEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOriginalSecCd.Trim().CompareTo(y.InqOriginalSecCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherEpCd.Trim().CompareTo(y.InqOtherEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherSecCd.Trim().CompareTo(y.InqOtherSecCd.Trim());
                if (result != 0) return result;

                result = x.InquiryNumber.CompareTo(y.InquiryNumber);
                if (result != 0) return result;

                return result;
            }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <testデータ>

        //private readonly Int64 testInquiryNumber = 0;
        //private readonly DateTime testUpdateDate = DateTime.MinValue;
        //private readonly string salesSlipNum = "333444555";
        //private readonly int acptAnOdrStatus = 30; // 売上

        ///// <summary>
        ///// テスト用受発注データ作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderHeaderRecord> CreateScmOdrDataForTest()
        //{
        //    List<ISCMOrderHeaderRecord> testDataList = new List<ISCMOrderHeaderRecord>();

        //    SCMAcOdrDataWork testData1 = new SCMAcOdrDataWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InqOtherEpCd = "0101150842020000";//問合せ先企業コード
        //    testData1.InqOtherSecCd = "01";//問合せ先拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号
        //    testData1.CustomerCode = 555; // 得意先コード
        //    testData1.UpdateDate = DateTime.MinValue;//更新年月日
        //    testData1.UpdateTime = 0;//更新時分秒ミリ秒
        //    testData1.AnswerDivCd = 0;//回答区分
        //    testData1.JudgementDate = DateTime.Now;//確定日
        //    testData1.InqOrdNote = "1";//問合せ・発注備考
        //    testData1.InqEmployeeCd = "0001";//問合せ従業員コード
        //    testData1.InqEmployeeNm = "1";//問合せ従業員名称
        //    testData1.AnsEmployeeCd = "0001";//回答従業員コード
        //    testData1.AnsEmployeeNm = "1";//回答従業員名称
        //    testData1.InquiryDate = DateTime.Now;//問合せ日
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // 受注ステータス
        //    testData1.SalesSlipNum = salesSlipNum; // 売上伝票番号
        //    testData1.SalesTotalTaxInc = 10500; // 伝票合計税込
        //    testData1.SalesSubtotalTax = 500; // 売上小計(税)
        //    testData1.InqOrdDivCd = 2; // 問合せ・発注種別 2:発注
        //    testData1.InqOrdAnsDivCd = 2; // 問発回答　2:回答
        //    testData1.ReceiveDateTime = DateTime.MinValue;//受信日時
        //    testData1.AnswerCreateDiv = 0; // 自動

        //    testDataList.Add(new UserSCMOrderHeaderRecord(testData1));

        //    return testDataList;
        //}

        ///// <summary>
        ///// テスト用受発注明細データ(問合せ・発注)作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderDetailRecord> CreateScmOdDtInqForTest()
        //{
        //    List<ISCMOrderDetailRecord> testDataList = new List<ISCMOrderDetailRecord>();

        //    return testDataList;
        //}

        ///// <summary>
        ///// テスト用受発注明細データ(回答)作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderAnswerRecord> CreateScmOdDtAnsForTest()
        //{
        //    List<ISCMOrderAnswerRecord> testDataList = new List<ISCMOrderAnswerRecord>();

        //    SCMAcOdrDtlAsWork testData1 = new SCMAcOdrDtlAsWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InqOtherEpCd = "0101150842020000";//問合せ先企業コード
        //    testData1.InqOtherSecCd = "01";//問合せ先拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号
        //    testData1.UpdateDate = DateTime.MinValue;//更新年月日 
        //    testData1.UpdateTime = 0;//更新時分秒ミリ秒

        //    testData1.InqRowNumber = 1; // 問合せ行番号
        //    testData1.InqRowNumDerivedNo = 1; // 問合せ行番号枝番
        //    testData1.InqOrgDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ元明細識別GUID
        //    testData1.InqOthDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // 問合せ先明細識別GUID
        //    testData1.GoodsDivCd = 0; // 商品種別 0:純正 1:優良 2:リビルド 3:中古 4:平均相場
        //    testData1.RecyclePrtKindCode = 1; // リサイクル部品種別 1リビルド
        //    testData1.RecyclePrtKindName = "リビルド";
        //    testData1.DeliveredGoodsDiv = 0; // 納品区分 0:配送 1:引取
        //    testData1.HandleDivCode = 0; // 取扱区分 0:取扱品 1:納期確認中 2:未取扱品
        //    testData1.GoodsShape = 1; // 商品形態 1:部品 2:用品
        //    testData1.DelivrdGdsConfCd = 0; // 納品確認区分 0:未確認 1:確認
        //    testData1.DeliGdsCmpltDueDate = DateTime.Now.AddMonths(3); // 納品完了予定日
        //    testData1.BLGoodsCode = 0001; // BL商品コード
        //    testData1.BLGoodsDrCode = 1; // BL商品コード枝番
        //    testData1.InqGoodsName = "1"; // 問発商品名
        //    testData1.AnsGoodsName = "1"; // 回答商品名
        //    testData1.SalesOrderCount = 2; // 発注数
        //    testData1.DeliveredGoodsCount = 1; // 納品数
        //    testData1.GoodsNo = "TESTUENOret100"; // 商品番号
        //    testData1.GoodsMakerCd = 1; // 商品メーカーコード
        //    testData1.PureGoodsMakerCd = 1; // 純正商品メーカーコード
        //    testData1.InqPureGoodsNo = "TESTUENOpure100"; // 問発純正商品番号
        //    testData1.AnsPureGoodsNo = "TESTUENOpure100"; // 回答純正商品番号
        //    testData1.ListPrice = 100; // 定価
        //    testData1.UnitPrice = 100; // 単価
        //    testData1.GoodsAddInfo = "1"; // 商品補足情報
        //    testData1.RoughRrofit = 5; // 粗利額
        //    testData1.RoughRate = 5; // 粗利率
        //    testData1.AnswerLimitDate = DateTime.Now; // 回答期限
        //    testData1.CommentDtl = "1"; // 備考(明細)
        //    testData1.ShelfNo = ""; // 棚番
        //    testData1.AdditionalDivCd = 0; // 追加区分
        //    testData1.CorrectDivCD = 0; // 訂正区分
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // 受注ステータス
        //    testData1.SalesSlipNum = salesSlipNum; // 売上伝票番号
        //    testData1.CampaignCode = 1; // キャンペーンコード
        //    testData1.StockDiv = 1; // 在庫区分
        //    testData1.InqOrdDivCd = 1; // 問合せ・発注種別
        //    testData1.DisplayOrder = 1; // 表示順位
        //    testData1.GoodsMngNo = 1; // 商品管理番号？

        //    testDataList.Add(new UserSCMOrderAnswerRecord(testData1));

        //    return testDataList;
        //}

        ///// <summary>
        ///// テスト用受発注データ(車両情報)作成
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderCarRecord> CreateScmOdDtCarForTest()
        //{
        //    List<ISCMOrderCarRecord> testDataList = new List<ISCMOrderCarRecord>();

        //    SCMAcOdrDtCarWork testData1 = new SCMAcOdrDtCarWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//問合せ元企業コード
        //    testData1.InqOriginalSecCd = "000001";//問合せ元拠点コード
        //    testData1.InquiryNumber = testInquiryNumber;//問合せ番号

        //    testData1.NumberPlate1Code = 11; // 陸運事務所番号
        //    testData1.NumberPlate1Name = "1"; // 陸運事務局名称
        //    testData1.NumberPlate2 = "1"; // 車両登録番号(種別)
        //    testData1.NumberPlate3 = "1"; // 車両登録番号(カナ)
        //    testData1.NumberPlate4 = 1234; // 車両登録番号(プレート番号)
        //    testData1.ModelDesignationNo = 5; // 型式指定番号
        //    testData1.CategoryNo = 1; // 類別番号
        //    testData1.MakerCode = 1; // メーカーコード
        //    testData1.ModelCode = 1; // 車種コード
        //    testData1.ModelSubCode = 1; // 車種サブコード
        //    testData1.ModelName = "1"; // 車種名
        //    testData1.CarInspectCertModel = "1"; // 車検証型式
        //    testData1.FullModel = "1"; // 型式(フル型)
        //    testData1.FrameNo = "1"; // 車台番号
        //    testData1.FrameModel = "1"; // 車台型式
        //    testData1.ChassisNo = "1"; // シャシーNo
        //    testData1.CarProperNo = 1234; // 車両固有番号
        //    testData1.ProduceTypeOfYearNum = 201012; // 生産年式(Numタイプ)
        //    testData1.Comment = "1"; // コメント
        //    testData1.RpColorCode = "1"; // リペアカラーコード
        //    testData1.ColorName1 = "1"; // カラー名称1
        //    testData1.TrimCode = "1"; // トリムコード
        //    testData1.TrimName = "1"; // トリム名称
        //    testData1.Mileage = 999999; // 車両走行距離
        //    testData1.EquipObj = System.Text.Encoding.Unicode.GetBytes("1"); // 装備オブジェト
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // 受注ステータス
        //    testData1.SalesSlipNum = salesSlipNum; // 売上伝票番号

        //    testDataList.Add(new UserSCMOrderCarRecord(testData1));

        //    return testDataList;
        //}
        #endregion testデータ

        #region <送信処理画面用データセット>

        /// <summary>
        /// 送信処理画面用データセットを生成します。
        /// </summary>
        /// <returns>送信処理画面用データセット</returns>
        /// <see cref="SCMIOAgent"/>
        public override SCMSendViewDataSet CreateSCMSendViewDataSet()
        {
            const string METHOD = "CreateSCMSendViewDataSet";
            const string INDENT = "\t  ";

            SCMSendViewDataSet sendingViewDB = new SCMSendViewDataSet();
            {
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM受注データを構築中…");
                // SCM受注データ
                long headerID = 0;
                foreach (ISCMOrderHeaderRecord headerRecord in FoundSendingHeaderList)
                {
                    string sendStatus;

                    if (headerRecord.UpdateDate == DateTime.MinValue)
                    {
                        sendStatus = "未送信";
                    }
                    else
                    {
                        sendStatus = "送信済";
                    }

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("送信伝票リスト用テーブルを生成：headerID = [{0}]", headerID)); // ADD 2015/06/30② T.Miyamoto SCM仕掛一覧№10707

                    sendingViewDB.SendingSlipHeader.AddSendingSlipHeaderRow(
                        headerID++,                                     // ID
                        sendStatus,                                     // 通信状態(回答区分)
                        headerRecord.InquiryNumber,                     // 問合せ番号
                        headerRecord.AcptAnOdrStatus,                   // 受注ステータス
                        GetSlipTypeName(headerRecord.AcptAnOdrStatus),  // 伝票種別
                        headerRecord.SalesSlipNum,                      // 伝票番号
                        headerRecord.InquiryDate,                       // 売上日付
                        headerRecord.SalesTotalTaxInc,                  // 合計金額
                        headerRecord.InqOrdNote,                        // 備考(問合せ・発注備考)
                        headerRecord.CustomerCode,                      // 得意先コード
                        headerRecord.InqOriginalEpCd.Trim(),                   // 問合せ元企業コード//@@@@20230303
                        headerRecord.InqOriginalSecCd,                  // 問合せ元拠点コード
                        headerRecord.InqOtherEpCd,                      // 問合せ先企業コード
                        headerRecord.InqOtherSecCd,                     // 問合せ先拠点コード
                        headerRecord.UpdateDate,                        // 更新年月日
                        headerRecord.UpdateTime,                        // 更新時分秒ミリ秒
                        headerRecord.InqOrdDivCd                        // 問合せ・発注種別
                    );

                    if (!WithoutCustomerInfo)   // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
                    {
                        Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("[{0}] @{1} : 得意先データを取得中…", headerID, headerRecord.CustomerCode));
                        CustomerDB.TakeCustomerInfo(headerRecord);  // FIXME:意外と時間がかかる処理
                        Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("[{0}] @{1} : 得意先データを取得完了", headerID, headerRecord.CustomerCode));
                    }
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM受注データを構築完了");

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM受注明細データ(回答)を構築中…");
                // SCM受注明細データ(回答)
                long detailID = 0;
                foreach (ISCMOrderAnswerRecord answerRecord in FoundSendingAnswerList)
                {
                    sendingViewDB.SendingSlipDetail.AddSendingSlipDetailRow(
                        detailID++,                                             // ID
                        RelationalHeaderMap[answerRecord.ToRelationKey() + answerRecord.SalesSlipNum.PadLeft(9, '0') + answerRecord.AcptAnOdrStatus.ToString("d2")].Key,  // 対応するSCM受注データのID
                        answerRecord.BLGoodsCode,           // BLコード(BL商品コード)
                        answerRecord.GoodsNo,               // 品番(商品番号)
                        answerRecord.AnsGoodsName,          // 品名(回答商品名(カナ))
                        answerRecord.DeliveredGoodsCount,   // 数量(納品数)
                        answerRecord.UnitPrice,             // 単価
                        (long)Math.Round(answerRecord.UnitPrice * answerRecord.DeliveredGoodsCount, 0, MidpointRounding.AwayFromZero)  // 小数点第1位で四捨五入
                    );
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM受注明細データ(回答)を構築完了");

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "得意先データを構築中…");
                // 得意先マスタ
                foreach (CustomerInfo customerInfo in CustomerDB.CustomerInfoMap.Values)
                {
                    sendingViewDB.SendingCustomer.AddSendingCustomerRow(
                        customerInfo.CustomerCode,  // 得意先コード
                        customerInfo.CustomerSnm,   // 得意先名称
                        customerInfo.OnlineKindDiv
                    );
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "得意先データを構築完了");
            }
            return sendingViewDB;
        }

        #endregion // </送信処理画面用データセット>

        #region <更新処理実行>
        /// <summary>
        /// 更新処理実行(Insertではない)
        /// </summary>
        /// <returns></returns>
        public override int UpdateData(object wirtePara)
        {
            int status;

            status = this.RealAccesser.ScmDeleteInsert(ref wirtePara);

            return status;
        }
        #endregion

        /// <summary>
        /// 回答区分
        /// </summary>
        private enum AnswerDivCd : int
        {
            /// <summary>未回答</summary>
            NoAction = 0,
            /// <summary>回答中(Web側のみのステータス)</summary>
            OnAnswer = 1,
            /// <summary>一部回答</summary>
            AnsParts = 10,
            /// <summary>回答完了</summary>
            AnsComplete = 20,
            /// <summary>キャンセル</summary>
            Cancel = 99
        }
    }
}
