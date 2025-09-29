using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller.Agent
{
    using DBConditionType       = OprtnHisLogSrchWork;
    using SectionItemType       = CodeNamePair<string>;
    using JobTypeItemType       = CodeNamePair<int>;
    using EmploymentFormItemType= CodeNamePair<int>;
    using CategoryItemType      = CodeNamePair<int>;
    using PgItemType            = CodeNamePair<string>;
    using OperationItemType     = CodeNamePair<int>;
    using LogKindItemType       = CodeNamePair<int>;

    /// <summary>
    /// ログの抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: K2016/10/28 時シン</br>
    /// <br>管理番号   : 11202046-00</br>
    /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
    /// <br>Update Note: 2021/12/15  陳艶丹</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
    /// </remarks>
    public sealed class LogCondition : DBConditionType
    {
        #region <企業コード/>

        #endregion  // <企業コード/>

        #region <開始ログデータ作成日時/>

        /// <summary>
        /// 開始日時のアクセサ
        /// </summary>
        /// <value>開始日時</value>
        public DateTime From
        {
            get { return St_LogDataCreateDateTime; }
            set { St_LogDataCreateDateTime = value; }
        }

        #endregion  // <開始ログデータ作成日時/>

        #region <終了ログデータ作成日時/>

        /// <summary>
        /// 終了日時のアクセサ
        /// </summary>
        /// <value>終了日時</value>
        public DateTime To
        {
            get { return Ed_LogDataCreateDateTime; }
            set { Ed_LogDataCreateDateTime = value; }
        }

        #endregion  // <終了ログデータ作成日時/>

        #region <ログイン拠点コード/>

        /// <summary>全社のコード</summary>
        public const string ALL_SECTION_CODE = "";     // LITERAL:
        /// <summary>全社の名称</summary>
        public const string ALL_SECTION_NAME = "全社"; // LITERAL:

        /// <summary>拠点リスト</summary>
        private List<SectionItemType> _sectionList;
        /// <summary>
        /// 拠点リストを取得します。
        /// </summary>
        /// <value>拠点リスト</value>
        private List<SectionItemType> SectionList
        {
            get
            {
                if (_sectionList == null) _sectionList = new List<SectionItemType>();
                return _sectionList;
            }
        }

        /// <summary>
        /// 拠点の条件があるか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasSection
        {
            get { return SectionList.Count > 0; }
        }

        /// <summary>
        /// 拠点を追加します。
        /// </summary>
        /// <param name="sectionItem">拠点</param>
        public void AddSection(SectionItemType sectionItem)
        {
            #region <Guard Phrase/>

            if (sectionItem == null) return;

            #endregion  // <Guard Phrase/>

            SectionList.Add(sectionItem);
        }

        /// <summary>
        /// ログイン拠点コードを取得します。
        /// </summary>
        public new string[] LoginSectionCd
        {
            get
            {
                if (SectionList.Count > 0)
                {
                    base.LoginSectionCd = null;
                    base.LoginSectionCd = new string[SectionList.Count];
                    for (int i = 0; i < SectionList.Count; i++)
                    {
                        base.LoginSectionCd[i] = SectionList[i].Code;
                    }
                }

                return base.LoginSectionCd;
            }
            set
            {
                if (_sectionList != null)
                {
                    _sectionList.Clear();
                    _sectionList = null;
                }
                base.LoginSectionCd = value;

                if (value == null) return;
                for (int i = 0; i < value.Length; i++)
                {
                    AddSection(new SectionItemType(value[i], value[i]));
                }
            }
        }

        #endregion

        #region <端末名/>

        /// <summary>
        /// 端末名のアクセサ
        /// </summary>
        /// <value>端末名</value>
        public string MachineName
        {
            get { return LogDataMachineName; }
            set { LogDataMachineName = value; }
        }

        /// <summary>
        /// 端末名の条件があるか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasMachineName
        {
            get { return !string.IsNullOrEmpty(MachineName); }
        }

        #endregion  // <端末名/>

        #region <職種/>

        /// <summary>全職種のコード</summary>
        public const int ALL_JOB_TYPE_LEVEL = -1;
        /// <summary>全職種の名称</summary>
        public const string ALL_JOB_TYPE_NAME = "";

        /// <summary>職種</summary>
        private JobTypeItemType _jobType;
        /// <summary>
        /// 職種のアクセサ
        /// </summary>
        /// <value>職種</value>
        public JobTypeItemType JobType
        {
            get { return _jobType; }
            set { _jobType = value; }
        }

        /// <summary>
        /// 職種の条件があるか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasJobType
        {
            get
            {
                if (JobType == null) return false;
                return !JobType.Code.Equals(ALL_JOB_TYPE_LEVEL);
            }
        }

        #endregion  // <職種/>

        #region <雇用形態/>

        /// <summary>全雇用形態のコード</summary>
        public const int ALL_EMPLOYMENT_FORM_CODE = -1;
        /// <summary>全雇用形態の名称</summary>
        public const string ALL_EMPLOYMENT_FORM_NAME = "";

        /// <summary>雇用形態</summary>
        private EmploymentFormItemType _employmentForm;
        /// <summary>
        /// 雇用形態を取得します。
        /// </summary>
        /// <value>雇用形態</value>
        public EmploymentFormItemType EmploymentForm
        {
            get { return _employmentForm; }
            set { _employmentForm = value; }
        }

        /// <summary>
        /// 雇用形態の条件があるか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasEmploymentForm
        {
            get
            {
                if (EmploymentForm == null) return false;
                return !EmploymentForm.Code.Equals(ALL_EMPLOYMENT_FORM_CODE);
            }
        }

        #endregion  // <雇用形態/>

        #region <従業員/>

        /// <summary>
        /// 従業員コードのアクセサ
        /// </summary>
        public string EmployeeCode
        {
            get { return LogDataAgentCd; }
            set { LogDataAgentCd = value; }
        }

        /// <summary>
        /// 従業員コードを条件にもつか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasEmployeeCode
        {
            get { return !string.IsNullOrEmpty(EmployeeCode); }
        }

        #endregion  // <従業員/>

        #region <カテゴリ/>

        /// <summary>全カテゴリのコード</summary>
        public const int ALL_CATEGORY_CODE = -1;
        /// <summary>全カテゴリの名称</summary>
        public const string ALL_CATEGORY_NAME = "";

        /// <summary>カテゴリ</summary>
        private CategoryItemType _category;
        /// <summary>
        /// カテゴリのアクセサ
        /// </summary>
        /// <value>カテゴリ</value>
        public CategoryItemType Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// カテゴリの条件をもつか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasCategory
        {
            get
            {
                if (Category == null) return false;
                return !Category.Code.Equals(ALL_CATEGORY_CODE);
            }
        }

        #endregion  // <カテゴリ/>

        #region <機能/>

        /// <summary>全機能のID</summary>
        public const string ALL_PG_ID = "";
        /// <summary>全機能の名称</summary>
        public const string ALL_PG_NAME = "";

        /// <summary>機能</summary>
        private PgItemType _pg;
        /// <summary>
        /// 機能のアクセサ
        /// </summary>
        /// <value>機能</value>
        public PgItemType Pg
        {
            get { return _pg; }
            set
            {
                _pg = value;

                if (value == null) return;
                LogDataObjAssemblyID = value.Code;
            }
        }

        /// <summary>
        /// 機能を条件にもつか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasPg
        {
            get
            {
                if (Pg == null) return false;
                return !Pg.Code.Equals(ALL_PG_ID);
            }
        }

        #endregion  // <機能/>

        #region <操作/>

        /// <summary>全操作のコード</summary>
        public const int ALL_OPERATION_CODE = -1;
        /// <summary>全操作の名称</summary>
        public const string ALL_OPERATION_NAME = "";

        /// <summary>操作</summary>
        private OperationItemType _operation;
        /// <summary>
        /// 操作のアクセサ
        /// </summary>
        /// <value>操作</value>
        public OperationItemType Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;

                if (value == null) return;
                LogDataOperationCd = value.Code;
            }
        }

        /// <summary>
        /// 操作を条件にもつか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasOperation
        {
            get
            {
                if (Operation == null) return false;
                return !Operation.Code.Equals(ALL_OPERATION_CODE);
            }
        }

        #endregion  // <操作/>

        #region <ログ種別/>

        /// <summary>全ログ種別のコード</summary>
        public const int ALL_KIND_CODE = -1;
        /// <summary>全ログ種別の名称</summary>
        public const string ALL_KIND_NAME = "";

        /// <summary>ログ種別</summary>
        private LogKindItemType _logKind;
        /// <summary>
        /// ログ種別のアクセサ
        /// </summary>
        /// <value>ログ種別</value>
        public LogKindItemType LogKind
        {
            get { return _logKind; }
            set
            {
                _logKind = value;

                if (value == null) return;
                LogDataKindCd = value.Code;
            }
        }

        /// <summary>
        /// ログ種別を条件にもつか判定します。
        /// </summary>
        /// <value>true :あり<br/>false:なし</value>
        public bool HasLogKind
        {
            get
            {
                if (LogKind == null) return false;
                return !LogKind.Code.Equals(ALL_KIND_CODE);
            }
        }

        #endregion  // <ログ種別/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public LogCondition() : base()
        {
            EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            DateTime now = DateTime.Now;
            St_LogDataCreateDateTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            Ed_LogDataCreateDateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            LogDataOperationCd = ALL_OPERATION_CODE;    // TODO:デフォルトは全オペレーションコード
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="logDataKindCd">ログ種別</param>
        public LogCondition(LogDataKind logDataKindCd) : this()
        {
            LogDataKindCd = (int)logDataKindCd;
        }

        #endregion

        /// <summary>
        /// 操作履歴ログの検索条件を生成します。
        /// </summary>
        /// <returns>操作履歴ログの検索条件</returns>
        /// <remarks>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        public DBConditionType CreateOprtnHisLogSrchWork()
        {
            DBConditionType ret = new DBConditionType();

            ret.EnterpriseCode          = EnterpriseCode;
            ret.St_LogDataCreateDateTime= St_LogDataCreateDateTime;
            ret.Ed_LogDataCreateDateTime= Ed_LogDataCreateDateTime;
            ret.LoginSectionCd          = this.LoginSectionCd;
            ret.LogDataKindCd           = LogDataKindCd;
            ret.LogDataMachineName      = LogDataMachineName;
            ret.LogDataAgentCd          = LogDataAgentCd;
            ret.LogDataObjAssemblyID    = LogDataObjAssemblyID;
            ret.LogDataOperationCd      = LogDataOperationCd;

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            // 時刻で検索可能のフラグ
            ret.TimeSearchFlag = TimeSearchFlag;
            // 時刻（時）
            ret.SearchHourSt = SearchHourSt;
            ret.SearchHourEd = SearchHourEd;
            // 時刻（分）
            ret.SearchMinuteSt = SearchMinuteSt;
            ret.SearchMinuteEd = SearchMinuteEd;
            // 時刻（秒）
            ret.SearchSecondSt = SearchSecondSt;
            ret.SearchSecondEd = SearchSecondEd;

            // 00:00:00に跨っている場合
            ret.TimeSearchFlag2 = TimeSearchFlag2;
            // 時刻（時）
            ret.SearchHourSt2 = SearchHourSt2;
            ret.SearchHourEd2 = SearchHourEd2;
            // 時刻（分）
            ret.SearchMinuteSt2 = SearchMinuteSt2;
            ret.SearchMinuteEd2 = SearchMinuteEd2;
            // 時刻（秒）
            ret.SearchSecondSt2 = SearchSecondSt2;
            ret.SearchSecondEd2 = SearchSecondEd2;
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            // 24時間を超える場合
            ret.TimeSearchFlagOverDay = TimeSearchFlagOverDay;
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

            return ret;
        }

        #region <検索条件の構築/>

        /// <summary>
        /// where文字列を取得します。
        /// </summary>
        /// <returns>where文字列</returns>
        public string GetWhere()
        {
            StringBuilder sqlWhere = new StringBuilder();

            // 拠点
            if (HasSection)
            {
                foreach (SectionItemType section in SectionList)
                {
                    if (section.Code.Equals(ALL_SECTION_CODE)) break;

                    if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.OR);

                    sqlWhere.Append(LogDataSet.ClmIdx.SectionCode);
                    sqlWhere.Append(ADOUtil.EQ);
                    sqlWhere.Append(ADOUtil.GetString(section.Code));
                }
            }

            // 日時
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.LogDateTime);
                sqlWhere.Append(ADOUtil.LARGE_EQ);
                sqlWhere.Append(ADOUtil.GetString(From.ToString()));
                sqlWhere.Append(ADOUtil.AND);
                sqlWhere.Append(LogDataSet.ClmIdx.LogDateTime);
                sqlWhere.Append(ADOUtil.LESS_EQ);
                sqlWhere.Append(ADOUtil.GetString(To.ToString()));
            }

            // 端末名
            if (HasMachineName)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.MachineName);
                sqlWhere.Append(ADOUtil.LIKE);
                sqlWhere.Append(ADOUtil.GetWild(MachineName));
            }

            // 職種
            if (HasJobType)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.JobTypeLevel);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(JobType.Code);
            }

            // 雇用形態
            if (HasEmploymentForm)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.EmploymentFormLevel);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(EmploymentForm.Code);
            }

            // 従業員
            if (HasEmployeeCode)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.EmployeeCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(EmployeeCode));
            }

            // カテゴリ
            if (HasCategory)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(Category.Code);
            }

            // 機能
            if (HasPg)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(Pg.Code));
            }

            // 操作
            if (HasOperation)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.OperationCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(Operation.Code);
            }

            // ログ種別
            if (HasLogKind)
            {
                if (!string.IsNullOrEmpty(sqlWhere.ToString())) sqlWhere.Append(ADOUtil.AND);

                sqlWhere.Append(LogDataSet.ClmIdx.LogKindCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(LogKind.Code);
            }

            return sqlWhere.ToString();
        }

        #endregion  // <検索条件の構築/>
    }
}
