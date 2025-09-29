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
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/03/30  修正内容 : 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using HeaderPair = KeyValuePair<SCMAcOdrDataWork, SCMAcOdrData>; // SCM受注データのペア(NS版とPM7版)

    /// <summary>
    /// PM7のI/Oアクセスの代理人クラス
    /// </summary>
    public sealed class PM7IOAgent : SCMIOAgent
    {
        const string MY_NAME = "PM7IOAgent";    // ログ用

        #region <ファイルオープンのリトライ>

        /// <summary>リトライの最大回数</summary>
        private const int RETRY_LIMIT = 5;
        /// <summary>リトライの最大回数を取得します。</summary>
        private int RetryLimit { get { return RETRY_LIMIT; } }

        /// <summary>リトライ時の待ち時間[msec]</summary>
        private const int WAIT_MILLI_SEC = 1000;
        /// <summary>リトライ時の待ち時間[msec]を取得します。</summary>
        private int WaitMilliSec { get { return WAIT_MILLI_SEC; } }

        #endregion // </ファイルオープンのリトライ>

        #region <データパス>

        /// <summary>データパス</summary>
        private readonly string _dataPath;
        /// <summary>データパスを取得します。</summary>
        private string DataPath { get { return _dataPath; } }

        /// <summary>起動パラメータの売上伝票番号</summary>
        private readonly string _defaultSalesSlipNum;
        /// <summary>起動パラメータの売上伝票番号を取得します。</summary>
        private string DefaultSalesSlipNum { get { return _defaultSalesSlipNum; } } 

        /// <summary>起動パラメータの受注ステータス</summary>
        private readonly int _defaultAcptAnOdrStatus;
        /// <summary>起動パラメータの受注ステータスを取得します。</summary>
        private int DefaultAcptAnOdrStatus { get { return _defaultAcptAnOdrStatus; } } 

        /// <summary>起動パラメータのサーバ番号</summary>
        private readonly int _defaultServerNumber = -1;
        /// <summary>起動パラメータのサーバ番号を取得します。</summary>
        private int DefaultServerNumber { get { return _defaultServerNumber; } } 

        /// <summary>起動パラメータの得意先コード</summary>
        private readonly int _defaultCustomerCd;
        /// <summary>起動パラメータの得意先コードを取得します。</summary>
        private int DefaultCustomerCd { get { return _defaultCustomerCd; } } 

        #endregion // </データパス>

        #region <XMLファイル名>
        /// <summary>送信対象得意先リストのファイル名</summary>
        public const string CUSTOMER_LIST_FILE_NAME = "ScmList.xml";

        /// <summary>SCM受発注データ.xmlのファイル名(拡張子なし)</summary>
        private const string HEADER_FILE_BODY = "ScmSdRvDt";

        /// <summary>SCM受発注明細データ(回答).xmlのファイル名(拡張子なし)</summary>
        private const string ANSWER_FILE_BODY = "ScmSdRvDtl";

        /// <summary>SCM受発注データ(車両情報).xmlのファイル名(拡張子なし)</summary>
        private const string CAR_FILE_BODY = "ScmSdRvSya";

        /// <summary>更新用CSVファイル名(拡張子なし)</summary>
        private const string UPDATE_CSV_BODY = "InquiryNumber";

        /// <summary>更新年月日を数値変換する際のフォーマット</summary>
        private const string UPDATE_DATE_TO_NUMBER_FORMAT = "yyyyMMdd";
        #endregion

        #region <処理用保持データ>
        /// <summary>読込みXML枝番保持Dic (Key:得意先コード(8桁埋め) + 伝票番号 value:枝番)</summary>
        private Dictionary<string, int> _filePathDic;

        /// <summary>問合せ番号0の伝票番号リスト</summary>
        private List<string> _inquiryZeroSalesSlipList;
        #endregion

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ(PM7NormalController用)
        /// </summary>
        /// <param name="dataPath">データパス</param>
        public PM7IOAgent(
            string dataPath
        ) : base(false) // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
        {
            _dataPath = dataPath;

            this._filePathDic = new Dictionary<string, int>();
            this._inquiryZeroSalesSlipList = new List<string>();
        }

        /// <summary>
        /// カスタムコンストラクタ(PM7BatchController用)
        /// </summary>
        /// <param name="dataPath">データパス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="serverNumber">サーバ番号</param>
        /// <param name="customerCd">起動パラメータの得意先コード</param>
        public PM7IOAgent(
            string dataPath,
            string salesSlipNum,
            int acptAnOdrStatus,
            int serverNumber,
            int customerCd
        ) : base(true)  // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
        {
            _dataPath = dataPath;
            _defaultSalesSlipNum = salesSlipNum;
            _defaultAcptAnOdrStatus = acptAnOdrStatus;
            _defaultServerNumber = serverNumber;
            _defaultCustomerCd = customerCd;

            this._filePathDic = new Dictionary<string, int>();
            this._inquiryZeroSalesSlipList = new List<string>();
        }

        #endregion // </Constructor>

        #region <検索結果>

        List<ISCMOrderHeaderRecord> _headerList;
        List<ISCMOrderAnswerRecord> _answerList;
        List<ISCMOrderCarRecord> _carList;

        /// <summary>NS版とPM7版のSCM受注データのマップ</summary>
        private IDictionary<string, HeaderPair> _nsPM7HeaderDataMap;
        /// <summary>NS版とPM7版のSCM受注データのマップ</summary>
        /// <remarks>キー：SCM受注データ同士の関連キー（得意先コード + "_" + 受注ステータス + "_" + 売上伝票番号）</remarks>
        private IDictionary<string, HeaderPair> NSPM7HeaderDataMap
        {
            get
            {
                if (_nsPM7HeaderDataMap == null)
                {
                    _nsPM7HeaderDataMap = new Dictionary<string, HeaderPair>();
                }
                return _nsPM7HeaderDataMap;
            }
        }

        /// <summary>
        /// NS版とPM7版のSCM受注データを追加します。
        /// </summary>
        /// <param name="headerPair">NS版とPM7版のSCM受注データの対</param>
        private void AddHeaderPair(HeaderPair headerPair)
        {
            string relationKey = SimpleXMLDB.GetHeaderRelationKey(headerPair.Key);
            if (!NSPM7HeaderDataMap.ContainsKey(relationKey))
            {
                NSPM7HeaderDataMap.Add(relationKey, headerPair);
            }
        }

        /// <summary>
        /// PM7版のSCM受注データを検索します。
        /// </summary>
        /// <param name="scmAcOdrDataWork">NS版のSCM受注データ</param>
        /// <returns>対になるPM7版のSCM受注データ ※該当するものがない場合、<c>null</c>を返します。</returns>
        private SCMAcOdrData FindPM7SCMAcOdrData(SCMAcOdrDataWork scmAcOdrDataWork)
        {
            string relationKey = SimpleXMLDB.GetHeaderRelationKey(scmAcOdrDataWork);
            if (NSPM7HeaderDataMap.ContainsKey(relationKey))
            {
                return NSPM7HeaderDataMap[relationKey].Value;
            }
            return null;
        }

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
                    int status = this.GetUserXMLData();

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
                    int status = this.GetUserXMLData();

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
                    int status = this.GetUserXMLData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._carList;
                    }
                }
            }
            return foundList;
        }

        //--- ADD 2011/08/12 -------------------------------------------->>>
        /// <summary>
        /// 送信するSCMセットマスタを検索します。
        /// </summary>
        /// <returns>送信するSCMセットマスタ</returns>
        protected override IList<ISCMAcOdSetDtRecord> FindSendingSetDtData()
        {
            return null;
        }
        //--- ADD 2011/08/12 --------------------------------------------<<<

        /// <summary>
        /// 回答XMLデータ取得
        /// </summary>
        /// <returns></returns>
        private int GetUserXMLData()
        {
            _headerList = new List<ISCMOrderHeaderRecord>();
            _answerList = new List<ISCMOrderAnswerRecord>();
            _carList = new List<ISCMOrderCarRecord>();

            NSPM7HeaderDataMap.Clear();

            if (DefaultCustomerCd == 0)
            {
                // 単体起動検索
                return this.GetUserXMLDataALL();
            }
            else
            {
                // 送信起動検索
                return this.GetUserXMLDataDefault();
            }
        }

        /// <summary>
        /// 回答XML全件取得(単体起動用)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SCMFileOpeningException">XMLデータファイルが作成中です。</exception>
        private int GetUserXMLDataALL()
        {
            const string METHOD_NAME = "GetUserXMLDataALL()";   // ログ用

            // XMLのデータリスト(フィルタ前)
            List<SCMAcOdrDataWork> scmAcOdrDataWorkList = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList = new List<SCMAcOdrDtlAsWork>();
            List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList = new List<SCMAcOdrDtCarWork>();

            // フォルダ一覧の取得
            string[] custFolderList; // 得意先毎のフォルダ一覧
            string[] salesslipFolderList; // 得意先フォルダ下の伝票番号毎フォルダ一覧

            try
            {
                custFolderList = Directory.GetDirectories(DataPath);

                foreach (string custFolder in custFolderList)
                {
                    salesslipFolderList = Directory.GetDirectories(custFolder);

                    foreach (string salesslipFolder in salesslipFolderList)
                    {
                        for (int iCnt = 99; iCnt >= 0; iCnt--)
                        {
                            string check_SCMAcOdrDataFile = salesslipFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注データ

                            if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                            this.ReadAnswerXMLFiles(salesslipFolder, iCnt, ref scmAcOdrDataWorkList, ref scmAcOdrDtlAsWorkList, ref scmAcOdrDtCarWorkList);

                            break;
                        }
                    }
                }

                // 更新日時が設定されているデータを削除
                scmAcOdrDataWorkList.RemoveAll(
                    delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                    {
                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                scmAcOdrDtlAsWorkList.RemoveAll(
                    delegate(SCMAcOdrDtlAsWork scmAcOdrDtlAsWork)
                    {
                        if (scmAcOdrDtlAsWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // 車両情報はヘッダと同キーのデータを取得
                scmAcOdrDtCarWorkList.RemoveAll(
                    delegate(SCMAcOdrDtCarWork scmAcOdrDtCarWork)
                    {
                        if (!scmAcOdrDataWorkList.Exists(
                                delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                                {
                                    if (scmAcOdrDataWork.InqOriginalEpCd.Trim() == scmAcOdrDtCarWork.InqOriginalEpCd.Trim()
                                        && scmAcOdrDataWork.InqOriginalSecCd.Trim() == scmAcOdrDtCarWork.InqOriginalSecCd.Trim()
                                        && scmAcOdrDataWork.InquiryNumber == scmAcOdrDtCarWork.InquiryNumber
                                        && scmAcOdrDataWork.AcptAnOdrStatus == scmAcOdrDtCarWork.AcptAnOdrStatus
                                        && scmAcOdrDataWork.SalesSlipNum == scmAcOdrDtCarWork.SalesSlipNum)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            )
                            )
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                foreach (SCMAcOdrDataWork scmAcOdrDataWork in scmAcOdrDataWorkList)
                {
                    _headerList.Add(new UserSCMOrderHeaderRecord(scmAcOdrDataWork));
                }

                foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsWork in scmAcOdrDtlAsWorkList)
                {
                    _answerList.Add(new UserSCMOrderAnswerRecord(scmAcOdrDtlAsWork));
                }

                foreach (SCMAcOdrDtCarWork scmAcOdrDtCarWork in scmAcOdrDtCarWorkList)
                {
                    _carList.Add(new UserSCMOrderCarRecord(scmAcOdrDtCarWork));
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (SCMFileOpeningException ex)
            {
                #region <Log>

                string msg = "XMLデータが作成中です。" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                throw ex;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n" + ex.ToString());

                #region <Log>

                string msg = "XMLデータの読込みに失敗しました。" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 回答XML全件取得(送信起動用)
        /// </summary>
        /// <returns></returns>
        private int GetUserXMLDataDefault()
        {
            const string METHOD_NAME = "GetUserXMLDataDefault()";   // ログ用

            // XMLのデータリスト(フィルタ前)
            List<SCMAcOdrDataWork> scmAcOdrDataWorkList = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList = new List<SCMAcOdrDtlAsWork>();
            List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList = new List<SCMAcOdrDtCarWork>();

            string fileFolder = DataPath
                                + @"\" + GetCustomerFolderName(DefaultCustomerCd)
                                + @"\" + GetSalesSlipNumberFolderName(DefaultAcptAnOdrStatus, DefaultSalesSlipNum);
            
            try
            {
                // 枝番取得
                for (int iCnt = 99; iCnt >= 0; iCnt--)
                {
                    string check_SCMAcOdrDataFile = fileFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注データ

                    if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                    this.ReadAnswerXMLFiles(fileFolder, iCnt, ref scmAcOdrDataWorkList, ref scmAcOdrDtlAsWorkList, ref scmAcOdrDtCarWorkList);

                    break;
                }

                // 更新日時が設定されているデータを削除
                scmAcOdrDataWorkList.RemoveAll(
                    delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                    {
                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                scmAcOdrDtlAsWorkList.RemoveAll(
                    delegate(SCMAcOdrDtlAsWork scmAcOdrDtlAsWork)
                    {
                        if (scmAcOdrDtlAsWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // 車両情報はヘッダと同キーのデータを取得
                scmAcOdrDtCarWorkList.RemoveAll(
                    delegate(SCMAcOdrDtCarWork scmAcOdrDtCarWork)
                    {
                        if (!scmAcOdrDataWorkList.Exists(
                                delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                                {
                                    if (scmAcOdrDataWork.InqOriginalEpCd.Trim() == scmAcOdrDtCarWork.InqOriginalEpCd.Trim()
                                        && scmAcOdrDataWork.InqOriginalSecCd.Trim() == scmAcOdrDtCarWork.InqOriginalSecCd.Trim()
                                        && scmAcOdrDataWork.InquiryNumber == scmAcOdrDtCarWork.InquiryNumber
                                        && scmAcOdrDataWork.AcptAnOdrStatus == scmAcOdrDtCarWork.AcptAnOdrStatus
                                        && scmAcOdrDataWork.SalesSlipNum == scmAcOdrDtCarWork.SalesSlipNum)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            )
                            )
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                foreach (SCMAcOdrDataWork scmAcOdrDataWork in scmAcOdrDataWorkList)
                {
                    _headerList.Add(new UserSCMOrderHeaderRecord(scmAcOdrDataWork));
                }

                foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsWork in scmAcOdrDtlAsWorkList)
                {
                    _answerList.Add(new UserSCMOrderAnswerRecord(scmAcOdrDtlAsWork));
                }

                foreach (SCMAcOdrDtCarWork scmAcOdrDtCarWork in scmAcOdrDtCarWorkList)
                {
                    _carList.Add(new UserSCMOrderCarRecord(scmAcOdrDtCarWork));
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                #region <Log>

                string msg = "XMLデータの読込みに失敗しました。" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 指定フォルダの回答XMLを読み込む
        /// </summary>
        /// <param name="targetFolder">フォルダパス</param>
        /// <param name="iCnt">ファイル枝番</param>
        /// <param name="scmAcOdrDataWorkList"></param>
        /// <param name="scmAcOdrDtlAsWorkList"></param>
        /// <param name="scmAcOdrDtCarWorkList"></param>
        /// <exception cref="SCMFileOpeningException">XMLデータファイルが作成中です。</exception>
        private void ReadAnswerXMLFiles(string targetFolder, 
                                        int iCnt,
                                        ref List<SCMAcOdrDataWork> scmAcOdrDataWorkList, 
                                        ref List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList, 
                                        ref List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList)
        {
            string scmAcOdrDataFile = targetFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注データ
            string scmAcOdrDtlAsWorkFile = targetFolder + String.Format(@"\" + ANSWER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注明細データ(回答)
            // TODO:ゴミ掃除…string scmAcOdrDtCarWorkFile = targetFolder + @"\" + CAR_FILE_BODY + @".xml"; // 受注データ(車両)
            string scmAcOdrDtCarWorkFile = targetFolder + String.Format(@"\" + CAR_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注データ(車両)

            for (int retryCount = 0; retryCount <= RetryLimit; retryCount++)
            {
                string openingFileName = string.Empty;
                try
                {
                    // 受注データ
                    System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                        = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));

                    openingFileName = scmAcOdrDataFile;
                    SCMAcOdrDataWork scmAcOdrDataWork;
                    using (System.IO.FileStream scmAcOdrData_Stream = new System.IO.FileStream(scmAcOdrDataFile, System.IO.FileMode.Open))
                    {
                        //scmAcOdrDataWork = SimpleXMLDB.DeserializeHeaderData(scmAcOdrData_Serializer, scmAcOdrData_Stream);

                        // TODO:NS版とPM7版のSCM受注データを取得し、保持する ∵送信後にPM7版のサーバ番号を使用するため
                        HeaderPair headerPair = SimpleXMLDB.DeserializeHeaderData(scmAcOdrData_Stream);
                        {
                            AddHeaderPair(headerPair);
                        }
                        scmAcOdrDataWork = headerPair.Key;
                        scmAcOdrDataWorkList.Add(scmAcOdrDataWork);
                    }

                    // 受注明細データ(回答)
                    System.Xml.Serialization.XmlSerializer scmAcOdrDtlAs_Serializer
                        = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtlAsWork[]));

                    openingFileName = scmAcOdrDtlAsWorkFile;
                    using (System.IO.FileStream scmAcOdrDtlAs_Stream = new System.IO.FileStream(scmAcOdrDtlAsWorkFile, System.IO.FileMode.Open))
                    {
                        SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWork = SimpleXMLDB.DeserializeAnswerData(scmAcOdrDtlAs_Serializer, scmAcOdrDtlAs_Stream);
                        scmAcOdrDtlAsWorkList.AddRange(scmAcOdrDtlAsWork);
                    }

                    if (System.IO.File.Exists(scmAcOdrDtCarWorkFile))
                    {
                        // 受注データ(車両)
                        System.Xml.Serialization.XmlSerializer scmAcOdrDtCar_Serializer
                            = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtCarWork));

                        openingFileName = scmAcOdrDtCarWorkFile;
                        using (System.IO.FileStream scmAcOdrDtCar_Stream = new System.IO.FileStream(scmAcOdrDtCarWorkFile, System.IO.FileMode.Open))
                        {
                            SCMAcOdrDtCarWork scmAcOdrDtCarWork = SimpleXMLDB.DeserializeCarData(scmAcOdrDtCar_Serializer, scmAcOdrDtCar_Stream);
                            scmAcOdrDtCarWorkList.Add(scmAcOdrDtCarWork);
                        }
                    }

                    // 各伝票番号フォルダ配下の枝番を保持(更新時に正しいファイルを対象にするため)
                    this._filePathDic.Add(scmAcOdrDataWork.CustomerCode.ToString("d8") + scmAcOdrDataWork.SalesSlipNum, iCnt);

                    // 問合せ番号0の伝票番号リストを保持(回答後のCSV出力用)
                    if (scmAcOdrDataWork.InquiryNumber == 0)
                    {
                        this._inquiryZeroSalesSlipList.Add(scmAcOdrDataWork.SalesSlipNum);
                    }

                    break;
                }
                catch (IOException ex)
                {
                    if (retryCount.Equals(RetryLimit))
                    {
                        string msg = string.Format("データファイルがオープン中({0})", openingFileName);
                        throw new SCMFileOpeningException(msg, ex);
                    }
                    System.Threading.Thread.Sleep(WaitMilliSec);
                }
            }   // for (int retryCount = 0; retryCount <= RetryLimit; retryCount++)
        }
        #endregion

        #region <送信処理画面用データセット>
        /// <summary>
        /// 送信処理画面用データセットを生成します。
        /// </summary>
        /// <returns>送信処理画面用データセット</returns>
        /// <see cref="SCMIOAgent"/>
        public override SCMSendViewDataSet CreateSCMSendViewDataSet()
        {
            SCMSendViewDataSet sendingViewDB = new SCMSendViewDataSet();

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

                //CustomerDB.TakeCustomerInfo(headerRecord);
            }

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

            #region 送信先対象得意先リスト情報の取得
            string _customerListPath = Path.Combine(DataPath, CUSTOMER_LIST_FILE_NAME);

            TspCustomer[] tsplst = null;

            System.Xml.Serialization.XmlSerializer cust_serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspCustomer[]));
            using (System.IO.FileStream stream = new System.IO.FileStream(_customerListPath, System.IO.FileMode.Open))
            {
                tsplst = (TspCustomer[])cust_serializer.Deserialize(stream);
            }

            // 得意先マスタ
            foreach (TspCustomer tspCustomer in tsplst)
            {
                sendingViewDB.SendingCustomer.AddSendingCustomerRow(
                    tspCustomer.PmCustomerCode,  // 得意先コード
                    tspCustomer.PmCustomerName,  // 得意先名称
                    10                           // 10:SCM 固定
                );
            }

            #endregion

            return sendingViewDB;
        }
        #endregion

        #region 得意先リストテーブル(TspCustomer)
        /// <summary>
        /// 得意先テーブルクラス
        /// </summary>
        public class TspCustomer
        {
            #region コンストラクタ
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public TspCustomer()
            {
                _PmEnterpriseCode = "";
                _PmSectionCode = "";
                _PmCustomerCode = 0;
                _PmCustomerName = "";
            }
            #endregion

            #region フィールド
            /// <summary>企業コード</summary>
            public const string CUST_PmEnterpriseCode = "PmEnterpriseCode";
            /// <summary>拠点コード</summary>
            public const string CUST_PmSectionCode = "PmSectionCode";
            /// <summary>得意先コード</summary>
            public const string CUST_PmCustomerCode = "PmCustomerCode";
            /// <summary>得意先名称</summary>
            public const string CUST_PmCustomerName = "PmCustomerName";
            #endregion

            #region プロパティ
            private string _PmEnterpriseCode;
            private string _PmSectionCode;
            private int _PmCustomerCode;
            private string _PmCustomerName;

            /// <summary>
            /// 企業コード
            /// </summary>
            public string PmEnterpriseCode
            {
                set { _PmEnterpriseCode = value; }

                get { return _PmEnterpriseCode; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string PmSectionCode
            {
                set { _PmSectionCode = value; }

                get { return _PmSectionCode; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int PmCustomerCode
            {
                set { _PmCustomerCode = value; }

                get { return _PmCustomerCode; }
            }
            /// <summary>
            /// 得意先名称
            /// </summary>
            public string PmCustomerName
            {
                set { _PmCustomerName = value; }

                get { return _PmCustomerName; }
            }

            #endregion
        }

        #endregion

        #region <更新処理実行>
        /// <summary>
        /// 更新処理実行(Insertではない)
        /// </summary>
        /// <returns></returns>
        public override int UpdateData(object wirtePara)
        {
            CustomSerializeArrayList writeList = (CustomSerializeArrayList)wirtePara;

            try
            {
                foreach (CustomSerializeArrayList oneData in writeList)
                {
                    SCMAcOdrDataWork header;
                    List<SCMAcOdrDtlIqWork> detailList;
                    List<SCMAcOdrDtlAsWork> answerList;
                    SCMAcOdrDtCarWork car;

                    IOWriterUtil.ExpandSCMReadRet(oneData, out header, out detailList, out answerList, out car);

                    // 得意先コード、伝票番号より対象ファイルを検索
                    string folderPath = DataPath
                                      + @"\" + GetCustomerFolderName(header)        // 得意先フォルダ 
                                      + @"\" + GetSalesSlipNumberFolderName(header) // 伝票番号フォルダ
                                      + @"\";

                    // 枝番を取得
                    int branchNum = this._filePathDic[header.CustomerCode.ToString("d8") + header.SalesSlipNum];

                    // 回答CSV出力処理
                    if (header.InquiryNumber != 0
                        && this._inquiryZeroSalesSlipList.Contains(header.SalesSlipNum))
                    {
                        // 更新前の問合せ番号が0で、更新されている場合CSV出力
                        this.OutputUpdateCSV(header, folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml");
                    }

                    // 各ファイルに上書き
                    // 受注データ
                    //System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));
                    System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrData));

                    Debug.WriteLine(folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml");
                    using (System.IO.FileStream stream1 = new System.IO.FileStream(folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                    {
                        MemoryStream memstr = new MemoryStream();

                        // TODO:PM7版のSCM受注データでXMLデータを展開
                        SCMAcOdrData pm7SCMAcOdrData = FindPM7SCMAcOdrData(header);
                        if (pm7SCMAcOdrData != null)
                        {
                            SimpleXMLDB.CopyHeaderData(header, ref pm7SCMAcOdrData);
                            serializer1.Serialize(memstr, pm7SCMAcOdrData);
                        }
                        else
                        {
                            Debug.Assert(false, "対になるPM7版のSCM受注データが存在しません。");
                            serializer1.Serialize(memstr, header);
                        }
                        byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                        stream1.Write(baff, 0, baff.Length);
                    }

                    // 受注データ(車両)
                    if (car != null)
                    {
                        System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtCarWork));

                        using (System.IO.FileStream stream2 = new System.IO.FileStream(folderPath + CAR_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                        {
                            MemoryStream memstr = new MemoryStream();
                            serializer2.Serialize(memstr, car);
                            byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                            stream2.Write(baff, 0, baff.Length);
                        }
                    }

                    // 受注明細データ(回答)
                    System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtlAsWork[]));

                    using (System.IO.FileStream stream3 = new System.IO.FileStream(folderPath + ANSWER_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                    {
                        MemoryStream memstr = new MemoryStream();
                        serializer3.Serialize(memstr, answerList.ToArray());
                        byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                        stream3.Write(baff, 0, baff.Length);
                    }
                }

                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n" + ex.ToString());
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 得意先フォルダ名を取得します。
        /// </summary>
        /// <param name="headerData">SCM受注データ</param>
        /// <returns>得意先コード(8桁)</returns>
        private static string GetCustomerFolderName(SCMAcOdrDataWork headerData)
        {
            return GetCustomerFolderName(headerData.CustomerCode);
        }

        /// <summary>
        /// 得意先フォルダ名を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先コード(8桁)</returns>
        private static string GetCustomerFolderName(int customerCode)
        {
            return customerCode.ToString("d8");
        }

        /// <summary>
        /// 伝票番号フォルダ名を取得します。
        /// </summary>
        /// <param name="headerData">SCM受注データ</param>
        /// <returns>受注ステータス + "_" + 売上伝票番号(8桁)</returns>
        private static string GetSalesSlipNumberFolderName(SCMAcOdrDataWork headerData)
        {
            return GetSalesSlipNumberFolderName(headerData.AcptAnOdrStatus, headerData.SalesSlipNum);
        }

        /// <summary>
        /// 伝票番号フォルダ名を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>受注ステータス + "_" + 売上伝票番号(8桁)</returns>
        private static string GetSalesSlipNumberFolderName(
            int acptAnOdrStatus,
            string salesSlipNum
        )
        {
            return acptAnOdrStatus.ToString() + "_" + salesSlipNum.Trim().PadLeft(8, '0');
        }

        /// <summary>
        /// 受注ステータス列挙型
        /// </summary>
        private enum AcptAnOdrStatus : int
        {
            /// <summary>10:見積</summary>
            Estimate = 10,
            /// <summary>20:受注</summary>
            Order = 20,
            /// <summary>30:売上</summary>
            Sales = 30
        }

        /// <summary>
        /// PM7の伝票種別列挙型
        /// </summary>
        private enum PM7SlipType : int
        {
            /// <summary>売上</summary>
            Sales = 10,
            /// <summary>見積</summary>
            Estimate = 93
        }

        /// <summary>
        /// 更新CSV出力処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="filePath"></param>
        private void OutputUpdateCSV(SCMAcOdrDataWork header, string filePath)
        {
            StringBuilder csvSB = new StringBuilder();
            {
                const string COMMA = ",";

                                        // 問合せ番号
                csvSB.Append(ConvertCSVCell(header.InquiryNumber));
                csvSB.Append(COMMA);    // 更新年月日
                csvSB.Append(ConvertCSVCell(header.UpdateDate.ToString(UPDATE_DATE_TO_NUMBER_FORMAT)));
                csvSB.Append(COMMA);    // 更新時分秒ミリ秒
                csvSB.Append(ConvertCSVCell(header.UpdateTime));
                csvSB.Append(COMMA);    // 問合せ元企業コード
                csvSB.Append(ConvertCSVCell(header.InqOriginalEpCd.Trim()));//@@@@20230303
                csvSB.Append(COMMA);    // 問合せ元拠点コード
                csvSB.Append(ConvertCSVCell(header.InqOriginalSecCd));
                csvSB.Append(COMMA);    // サーバー番号
                csvSB.Append(ConvertCSVCell(GetServerNumber(header)));
                csvSB.Append(COMMA);    // 伝票種別
                csvSB.Append(ConvertCSVCell(ConvertPM7SlipType(header)));
                csvSB.Append(COMMA);    // 伝票番号
                csvSB.Append(ConvertCSVCell(header.SalesSlipNum));
            }
            // TODO:ゴミ掃除
            #region ボツ
            //using (FileStream _fs = new FileStream(DataPath + @"\" + UPDATE_CSV_BODY + header.SalesSlipNum + @".csv",
            //                                FileMode.Create, FileAccess.Write, FileShare.None))
            #endregion // ボツ
            using (FileStream _fs = new FileStream(
                    DataPath + @"\" + GetInquiryCSVFileName(header),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None
            ))
            {
                using (StreamWriter _sw = new StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    _sw.WriteLine(csvSB.ToString());
                }
            }
        }

        /// <summary>
        /// サーバ番号を取得します。
        /// </summary>
        /// <param name="header">NS版のSCM受注データ</param>
        /// <returns>
        /// <c>DefaultServerNumber</c>が正の値の場合、<c>DefaultServerNumber</c>を返します。
        /// </returns>
        private int GetServerNumber(SCMAcOdrDataWork header)
        {
            if (DefaultServerNumber >= 0)
            {
                return DefaultServerNumber;
            }
            // 単体起動時のサーバ番号
            SCMAcOdrData pm7SCMAcOdrData = FindPM7SCMAcOdrData(header);
            if (pm7SCMAcOdrData != null)
            {
                return pm7SCMAcOdrData.ServerNumber;
            }
            return 0;
        }

        /// <summary>
        /// CSVデータのセル値に変換します。
        /// </summary>
        /// <typeparam name="T">値の型</typeparam>
        /// <param name="cellValue">値</param>
        /// <returns>" + 値 + "</returns>
        private static string ConvertCSVCell<T>(T cellValue)
        {
            return "\"" + cellValue.ToString() + "\"";
        }

        /// <summary>
        /// 問合せ番号更新用CSVファイル名を取得します。
        /// </summary>
        /// <param name="header">SCM受注データ</param>
        /// <returns>"InquiryNumber" + "_" + 問合せ番号 + "_" + 更新日時 + ".csv"</returns>
        private static string GetInquiryCSVFileName(SCMAcOdrDataWork header)
        {
            StringBuilder csvFileName = new StringBuilder();
            {
                const string DELIM = "_";

                csvFileName.Append(UPDATE_CSV_BODY);
                csvFileName.Append(DELIM);  // 問合せ番号
                csvFileName.Append(header.InquiryNumber);

                // 更新日付
                string dateValue = header.UpdateDate.ToString(UPDATE_DATE_TO_NUMBER_FORMAT);

                // 更新時刻
                string timeValue = header.UpdateTime.ToString("000000");
                if (header.UpdateTime >= 100000000)
                {
                    timeValue = timeValue.Substring(0, 6);
                }

                csvFileName.Append(DELIM);  // 更新年月日 + 更新時分秒ミリ秒(HHmmss)
                csvFileName.Append(dateValue).Append(timeValue);

                csvFileName.Append(".csv");
            }
            return csvFileName.ToString();
        }

        /// <summary>
        /// 受注ステータスに変換します。
        /// </summary>
        /// <param name="pm7SlipType">PM7の伝票種別</param>
        /// <returns>
        /// 93の場合、見積(=10)<br/>
        /// 10の場合、売上(=30)
        /// </returns>
        /// <exception cref="ArgumentException">
        /// PM7の伝票種別が売上(=10)または見積(=93)ではありません。
        /// </exception>
        public static int ConvertAcptAnOdrStatus(int pm7SlipType)
        {
            switch (pm7SlipType)
            {
                case (int)PM7SlipType.Sales:
                    return (int)AcptAnOdrStatus.Sales;
                case (int)PM7SlipType.Estimate:
                    return (int)AcptAnOdrStatus.Estimate;
                default:
                    string msg = string.Format(
                        "PM7の伝票種別が売上(={0})または見積(={1})ではありません。",
                        (int)PM7SlipType.Sales,
                        (int)PM7SlipType.Estimate
                    );
                    throw new ArgumentException(msg);
            }
        }

        /// <summary>
        /// PM7の伝票種別に変換します。
        /// </summary>
        /// <param name="header">SCM受注データ</param>
        /// <returns>
        /// SCM受注データ.受注ステータスが見積(=10)の場合、93<br/>
        /// SCM受注データ.受注ステータスが売上(=30)の場合、10
        /// </returns>
        /// <exception cref="ArgumentException">
        /// SCM受注データ.受注ステータスが見積(=10)または売上(=30)ではありません。
        /// </exception>
        private static int ConvertPM7SlipType(SCMAcOdrDataWork header)
        {
            switch (header.AcptAnOdrStatus)
            {
                case (int)AcptAnOdrStatus.Estimate: //10:見積
                    return (int)PM7SlipType.Estimate;
                case (int)AcptAnOdrStatus.Sales:    // 30:売上
                    return (int)PM7SlipType.Sales;
                default:
                    string msg = string.Format(
                        "SCM受注データ.受注ステータスが見積(={0})または売上(={1})ではありません。",
                        (int)AcptAnOdrStatus.Estimate,
                        (int)AcptAnOdrStatus.Sales
                    );
                    throw new ArgumentException(msg);
            }
        }
        #endregion // <更新処理実行>

        #region <保持期限切れXMLファイル削除処理>
        /// <summary>
        /// データ保持期限切れXML削除
        /// </summary>
        public override void DeletePassedPeriodXMLFiles(DateTime limit)
        {
            // フォルダ一覧の取得
            string[] custFolderList; // 得意先毎のフォルダ一覧
            string[] salesslipFolderList; // 得意先フォルダ下の伝票番号毎フォルダ一覧

            custFolderList = Directory.GetDirectories(DataPath);

            foreach (string custFolder in custFolderList)
            {
                salesslipFolderList = Directory.GetDirectories(custFolder);

                foreach (string salesslipFolder in salesslipFolderList)
                {
                    for (int iCnt = 99; iCnt >= 0; iCnt--)
                    {
                        string check_SCMAcOdrDataFile = salesslipFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // 受注データ

                        if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                        string scmAcOdrDataFile = check_SCMAcOdrDataFile;

                        // HACK:ゴミ掃除…受注データ
                        //System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                        //    = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));
                        System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                            = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrData));

                        SCMAcOdrDataWork scmAcOdrDataWork;
                        using (System.IO.FileStream scmAcOdrData_Stream = new System.IO.FileStream(scmAcOdrDataFile, System.IO.FileMode.Open))
                        {
                            // 復号処理
                            byte[] decryptXML = Broadleaf.Windows.Forms.TSPSendXMLReader.DecryptXML(scmAcOdrData_Stream);
                            MemoryStream memStr = new MemoryStream(decryptXML);
                            // TODO:ゴミ掃除…scmAcOdrDataWork = (SCMAcOdrDataWork)scmAcOdrData_Serializer.Deserialize(memStr);
                            SCMAcOdrData pm7SCMAcOdrData = (SCMAcOdrData)scmAcOdrData_Serializer.Deserialize(memStr);
                            scmAcOdrDataWork = SimpleXMLDB.CreateSCMAcOdrDataWork(pm7SCMAcOdrData);
                        }

                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue
                            && scmAcOdrDataWork.InquiryDate.CompareTo(limit) <= 0)
                        {
                            // 回答済 かつ 問合せ日が期限よりも前であれば削除対象
                            Directory.Delete(salesslipFolder, true);
                        }

                        break;
                    }
                }

                string[] remainFolderList = Directory.GetDirectories(custFolder);

                if (remainFolderList.Length == 0)
                {
                    Directory.Delete(custFolder, true);
                }
            }
        }
        #endregion
    }
}
