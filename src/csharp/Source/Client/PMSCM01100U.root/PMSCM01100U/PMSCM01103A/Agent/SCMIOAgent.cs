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
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/03/05  修正内容 : ユーザDBデータ(受注データ、車両情報、明細情報)取得時に、自拠点コード追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/03/30  修正内容 : 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/17  修正内容 : SCM障害対応 SCM連携未送信データ取得条件を修正 №10414
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.Agent
{
#if DEBUG
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType    = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#else
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType    = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#endif

    /// <summary>
    /// SCMのI/Oアクセスの代理人クラス
    /// </summary>
    public abstract class SCMIOAgent
    {
        /// <summary>ログ用の名称</summary>
        private const string MY_NAME = "SCMIOAgent";

        #region <SCM受注データ>

        /// <summary>送信するSCM受注データのレコードリスト</summary>
        private IList<ISCMOrderHeaderRecord> _foundSendingHeaderList;
        /// <summary>送信するSCM受注データのレコードリストを取得します。</summary>
        public IList<ISCMOrderHeaderRecord> FoundSendingHeaderList
        {
            get
            {
                const string METHOD = "FoundSendingHeaderList_get";
                const string INDENT = "\t    ";

                if (_foundSendingHeaderList == null)
                {
                    _foundSendingHeaderList = FindSendingHeaderData();

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "ヘッダと明細を関連付けるデータを構築中…");

                    RelationalHeaderMap.Clear();
                    for (int i = 0; i < _foundSendingHeaderList.Count; i++)
                    {
                        AddToRelationalHeaderMap((long)i, _foundSendingHeaderList[i]);
                    }

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "ヘッダと明細を関連付けるデータを構築完了");
                }
                return _foundSendingHeaderList;
            }
            set
            {
                _foundSendingHeaderList = value;
            }
        }

        /// <summary>SCM受注データの関連マップ</summary>
        private readonly IDictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>> _relationalHeaderMap = new Dictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>>();
        /// <summary>SCM受注マップの関連マップを取得します。</summary>
        protected IDictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>> RelationalHeaderMap { get { return _relationalHeaderMap; } }
        /// <summary>
        /// SCM受注データの関連マップに追加します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        private void AddToRelationalHeaderMap(
            long id,
            ISCMOrderHeaderRecord headerRecord
        )
        {
            string key = headerRecord.ToRelationKey() + headerRecord.SalesSlipNum.PadLeft(9, '0') + headerRecord.AcptAnOdrStatus.ToString("d2");
            if (RelationalHeaderMap.ContainsKey(key))
            {
                RelationalHeaderMap.Remove(key);
            }
            RelationalHeaderMap.Add(key, new KeyValuePair<long, ISCMOrderHeaderRecord>(id, headerRecord));
        }

        #endregion // </SCM受注データ>

        #region <SCM受注明細データ(回答)>

        /// <summary>送信するSCM受注明細データ(回答)のレコードリスト</summary>
        private IList<ISCMOrderAnswerRecord> _foundSendingAnswerList;
        /// <summary>送信するSCM受注明細データ(回答)のレコードリストを取得します。</summary>
        public IList<ISCMOrderAnswerRecord> FoundSendingAnswerList
        {
            get
            {
                if (_foundSendingAnswerList == null)
                {
                    _foundSendingAnswerList = FindSendingAnswerData();

                    //// 問合せ番号を持たないものを分別
                    //AnswerMapWithoutInquiryNumber.Clear();
                    //foreach (ISCMOrderAnswerRecord detailRecord in _foundSendingAnswerList)
                    //{
                    //    if (detailRecord.InquiryNumber.Equals(0))
                    //    {
                    //        AddAnswerMapWithoutInquiryNumber(detailRecord);
                    //    }
                    //}
                }
                return _foundSendingAnswerList;
            }
            set
            {
                _foundSendingAnswerList = value;
            }
        }

        #endregion // </SCM受注明細データ(回答)>

        #region <SCM受注データ(車両情報)>

        /// <summary>送信するSCM受注データ(車両情報)のレコードリスト</summary>
        private IList<ISCMOrderCarRecord> _foundSendingCarList;
        /// <summary>送信するSCM受注データ(車両情報)のレコードリストを取得します。</summary>
        public IList<ISCMOrderCarRecord> FoundSendingCarList
        {
            get
            {
                if (_foundSendingCarList == null)
                {
                    _foundSendingCarList = FindSendingCarData();
                }
                return _foundSendingCarList;
            }
            set
            {
                _foundSendingCarList = value;
            }
        }

        #endregion // </SCM受注データ(車両情報)>

        #region <SCM受注明細データ(問合せ・発注)>

        ///// <summary>送信するSCM受注明細データ(問合せ・発注)のレコードリスト</summary>
        //private IList<ISCMOrderDetailRecord> _foundSendingDetailList;
        ///// <summary>送信するSCM受注明細データ(問合せ・発注)のレコードリストを取得します。</summary>
        //public IList<ISCMOrderDetailRecord> FoundSendingDetailList
        //{
        //    get
        //    {
        //        if (_foundSendingDetailList == null)
        //        {
        //            _foundSendingDetailList = FindSendingDetailData();
        //        }
        //        return _foundSendingDetailList;
        //    }
        //    set
        //    {
        //        _foundSendingDetailList = value;
        //    }
        //}

        #endregion // </SCM受注明細データ(問合せ・発注)>
        // -- ADD 2011/08/08   ------ >>>>>>
        #region <セット情報のレコードリスト>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCMセットマスタ>
        /// <summary>
        /// SCMセットマスタのレコードリスト
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> _foundSendingSetDtList;

        /// <summary>
        /// 送信するSCMセットマスタのレコードリストを取得します。
        /// </summary>
        public IList<ISCMAcOdSetDtRecord> FoundSendingSetDtList
        {
            get
            {
                if (_foundSendingSetDtList == null)
                {
                    _foundSendingSetDtList = FindSendingSetDtData();
                }

                return _foundSendingSetDtList;
            }

            set
            {
                _foundSendingSetDtList = value;
            }
        }

        #endregion      // <SCMセットマスタ>
        // -- ADD 2011/08/10   ------ <<<<<<

        #region <SCMデータ検索>
        /// <summary>
        /// 送信するSCM受注データを検索します。
        /// </summary>
        /// <returns>送信するSCM受注データ</returns>
        protected abstract IList<ISCMOrderHeaderRecord> FindSendingHeaderData();

        /// <summary>
        /// 送信するSCM受注明細データ(回答)を検索します。
        /// </summary>
        /// <returns>送信するSCM受注明細データ(回答)</returns>
        protected abstract IList<ISCMOrderAnswerRecord> FindSendingAnswerData();

        /// <summary>
        /// 送信するSCM受注データ(車両情報)を検索します。
        /// </summary>
        /// <returns>送信するSCM受注データ(車両情報)</returns>
        protected abstract IList<ISCMOrderCarRecord> FindSendingCarData();

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// 送信するSCMセットマスタを検索します。
        /// </summary>
        /// <returns>送信するSCMセットマスタ</returns>
        protected abstract IList<ISCMAcOdSetDtRecord> FindSendingSetDtData();
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <SCM User-DBの公開>
        /// <summary>
        /// SCM受注データのレコードリストを生成します。
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDataWork> CreateUserHeaderRecordList()
        {
            List<SCMAcOdrDataWork> userHeaderList = new List<SCMAcOdrDataWork>();

            foreach (UserSCMOrderHeaderRecord enmHeaderRecord in FoundSendingHeaderList)
            {
                userHeaderList.Add(enmHeaderRecord.RealRecord);
            }

            return userHeaderList;
        }

        /// <summary>
        /// SCM受注データ(車両情報)のレコードリストを生成します。
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDtCarWork> CreateUserCarRecordList()
        {
            List<SCMAcOdrDtCarWork> userCarList = new List<SCMAcOdrDtCarWork>();

            foreach (UserSCMOrderCarRecord enmCarRecord in FoundSendingCarList)
            {
                userCarList.Add(enmCarRecord.RealRecord);
            }

            return userCarList;
        }

        /// <summary>
        /// SCM受注明細データ(回答)のレコードリストを生成します。
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDtlAsWork> CreateUserAnswerRecordList()
        {
            List<SCMAcOdrDtlAsWork> userAnswerList = new List<SCMAcOdrDtlAsWork>();

            foreach (UserSCMOrderAnswerRecord enmAnswerRecord in FoundSendingAnswerList)
            {
                userAnswerList.Add(enmAnswerRecord.RealRecord);
            }

            return userAnswerList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCMセットマスタのレコードリストを生成します。
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdSetDtWork> CreateUserSetDtRecordList()
        {
            List<SCMAcOdSetDtWork> userSetDtList = new List<SCMAcOdSetDtWork>();

            foreach(UserSCMAcOdSetDtRecord enmSetDtRecord in FoundSendingSetDtList)
            {
                userSetDtList.Add(enmSetDtRecord.RealRecord);
            }

            return userSetDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <SCM Web-DB への変換>

        /// <summary>
        /// SCM受発注データのレコードリストを生成します。
        /// </summary>
        /// <returns>SCM受発注データのレコードリスト</returns>
        public List<WebHeaderRecordType> CreateWebHeaderRecordList()
        {
            List<WebHeaderRecordType> headerList = new List<WebHeaderRecordType>();
            {
                foreach (ISCMOrderHeaderRecord enmHeaderRecord in FoundSendingHeaderList)
                {
                    UserSCMOrderHeaderRecord userHeader = enmHeaderRecord as UserSCMOrderHeaderRecord;
                    if (userHeader == null) continue;

                    headerList.Add(userHeader.CopyToWebSCMOrderHeaderRecord().RealRecord);
                }
            }
            return headerList;
        }

        /// <summary>
        /// SCM受発注データ(車両情報)のレコードを生成します。
        /// </summary>
        /// <returns>SCM受発注データ(車両情報)のレコード</returns>
        public List<WebCarRecordType> CreateWebCarRecordList()
        {
            List<WebCarRecordType> carList = new List<WebCarRecordType>();
            {
                foreach (ISCMOrderCarRecord enmCarRecord in FoundSendingCarList)
                {
                    UserSCMOrderCarRecord userCar = enmCarRecord as UserSCMOrderCarRecord;
                    if (userCar == null) continue;

                    carList.Add(userCar.CopyToWebSCMOrderCarRecord().RealRecord);
                }
            }
            return carList;
        }

        /// <summary>
        /// SCM受発注明細データ(回答)のレコードリストを生成します。
        /// </summary>
        /// <returns>SCM受発注明細データ(回答)のレコードリスト</returns>
        public List<WebAnswerRecordType> CreateWebAnswerRecordList()
        {
            List<WebAnswerRecordType> answerList = new List<WebAnswerRecordType>();
            {
                foreach (ISCMOrderAnswerRecord enmAnswerRecord in FoundSendingAnswerList)
                {
                    UserSCMOrderAnswerRecord userAnswer = enmAnswerRecord as UserSCMOrderAnswerRecord;
                    if (userAnswer == null) continue;

                    answerList.Add(userAnswer.CopyToWebSCMOrderAnswerRecord().RealRecord);
                }
            }
            return answerList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCMセットマスタのレコードリストを生成します。
        /// </summary>
        /// <returns></returns>
        public List<WebSetDtRecordType> CreateWebSetDtRecordList()
        {
            List<WebSetDtRecordType> setDtList = new List<WebSetDtRecordType>();

            foreach (ISCMAcOdSetDtRecord enmSetDtRecord in FoundSendingSetDtList)
            {
                UserSCMAcOdSetDtRecord userSetDtRecord = enmSetDtRecord as UserSCMAcOdSetDtRecord;

                if (userSetDtRecord == null)
                {
                    continue;
                }

                setDtList.Add(userSetDtRecord.CopyToWebSCMAcOdSetDtRecord().RealRecord);
            }

            return setDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion // </SCM Web-DB への変換>

        #region <送信処理画面用データセット>
        /// <summary>
        /// 送信処理画面用データセットを生成します。
        /// </summary>
        /// <returns>送信処理画面用データセット</returns>
        public abstract SCMSendViewDataSet CreateSCMSendViewDataSet();

        /// <summary>
        /// 伝票種別(受注ステータス)列挙型
        /// </summary>
        private enum SlipType : int
        {
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>受注</summary>
            Order = 20,
            /// <summary>売上</summary>
            Sales = 30
        }

        /// <summary>
        /// 伝票種別名を取得します。
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <returns>10:見積/20:受注/30:売上</returns>
        protected static string GetSlipTypeName(int acptAnOdrStatus)
        {
            switch (acptAnOdrStatus)
            {
                case (int)SlipType.Estimate:
                    return "見積";  // LITERAL:
                case (int)SlipType.Order:
                    return "受注";  // LITERAL:
                case (int)SlipType.Sales:
                    return "売上";  // LITERAL:
                default:
                    return "未回答";// LITERAL:
            }
        }

        /// <summary>
        /// 売上日付を取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>
        /// 受注ステータスが見積：問合せ日<br/>
        /// 受注ステータスが売上：発注日
        /// </returns>
        protected static DateTime GetSalesDate(ISCMOrderHeaderRecord headerRecord)
        {
            return headerRecord.AcptAnOdrStatus.Equals((int)SlipType.Sales)
                ? headerRecord.InquiryDate
                : headerRecord.InquiryDate;
        }

        #endregion // </送信処理画面用データセット>

        #region <更新処理実行>
        /// <summary>
        /// 更新処理実行(Insertではない)
        /// </summary>
        /// <returns></returns>
        public abstract int UpdateData(object wirtePara);
        #endregion

        #region <保持期限切れXMLファイル削除処理>
        /// <summary>
        /// 期限切れXMLファイル削除処理
        /// </summary>
        /// <param name="limit"></param>
        public virtual void DeletePassedPeriodXMLFiles(DateTime limit) { }
        #endregion

        #region <Constructor>

        // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
        ///// <summary>
        ///// デフォルトコンストラクタ
        ///// </summary>
        //protected SCMIOAgent() { }
        // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<
        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="withoutCustomerInfo">得意先情報を必要としないフラグ</param>
        protected SCMIOAgent(bool withoutCustomerInfo)
        {
            _withoutCustomerInfo = withoutCustomerInfo;
        }
        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<

        #endregion // </Constructor>

        //>>>2010/03/05
        private string _enterpriseCd;

        /// <summary>
        /// 自企業コード
        /// </summary>
        public string EnterpriseCd
        {
            get
            {
                if (_enterpriseCd == null || _enterpriseCd == string.Empty)
                {
                    _enterpriseCd = LoginInfoAcquisition.EnterpriseCode;
                }

                return _enterpriseCd;
            }
        }
        
        private string _belongSectionCode;
        /// <summary>
        /// 自拠点コード
        /// </summary>
        public string BelongSectionCode
        {
            get
            {
                if (LoginInfoAcquisition.Employee != null)
                {
                    if ((_belongSectionCode == null) || (_belongSectionCode == string.Empty))
                    {
                        _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                    }
                }

                return _belongSectionCode;
            }
        }
        //<<<2010/03/05


        //>>>2010/04/08
        //// 2010/03/15 Add >>>
        //private int _acptAnOdrStatus;
        //private string _salesSlipNum;

        //public int AcptAnOdrStatus
        //{
        //    get { return _acptAnOdrStatus; }
        //    set { _acptAnOdrStatus = value; }
        //}


        //public string SalesSlipNum
        //{
        //    get { return _salesSlipNum; }
        //    set { _salesSlipNum = value; }
        //}
        //// 2010/03/15 Add <<<

        private Int64 _inquiryNumber;
        private int _inqOrdDivCd;
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
        private List<string> _salesSlipNumList = null;
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<

        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        public int InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }
        //<<<2010/04/08

        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------>>>>>
        public List<string> SalesSlipNumList
        {
            get { return _salesSlipNumList; }
            set { _salesSlipNumList = value; }
        }
        // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------<<<<<

        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
        #region 得意先情報を必要としないフラグ

        /// <summary>得意先情報を必要としないフラグ</summary>
        private readonly bool _withoutCustomerInfo;
        /// <summary>得意先情報を必要としないフラグを取得します。</summary>
        protected bool WithoutCustomerInfo { get { return _withoutCustomerInfo; } }

        #endregion // 得意先情報を必要としないフラグ
        // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<

        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
        #region <設定情報>
        // 設定情報
        private SCMSendSettingInformation _settingInfo = null;

        /// <summary>設定情報を取得または設定します。</summary>
        public SCMSendSettingInformation SettingInformation
        {
            get { return _settingInfo; }
            set { _settingInfo = value; }
        }
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
    }
}
#endregion 