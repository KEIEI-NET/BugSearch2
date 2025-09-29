//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限設定アクセス
// プログラム概要   : 操作権限の設定状態を管理します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller.Util
{
    using JobTypeDataRow        = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using EmploymentFormDataRow = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using EmployeeType          = Employee;

    using SettingAppFormatMapValue = Pair<string, bool>;

    /// <summary>
    /// 操作権限設定の状態クラス
    /// </summary>
    public abstract class SettingState
    {
        #region <Const/>

        /// <summary>全カテゴリのコード</summary>
        public const int ALL_CATEGORY_CODE = -1;

        /// <summary>全カテゴリの文字列</summary>
        public const string ALL_CATEGORY_NAME = "全体"; // LITERAL:

        /// <summary>カテゴリ全体の設定のため変更できません。</summary>
        public const string CANNOT_SET_BECAUSE_ALL_CATEGOTY = "カテゴリ全体の設定のため変更できません。";   // LITERAL:

        #endregion  // <Const/>

        #region <名称/>

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <value>名称</value>
        protected abstract string Name { get; }

        #endregion  // <名称/>

        #region <操作/>

        /// <summary>オペレーションマスタDBのレコード</summary>
        protected Operation _operationRecord;
        /// <summary>
        /// オペレーションマスタDBのレコードを取得します。
        /// </summary>
        /// <value>オペレーションマスタDBのレコード</value>
        protected Operation OperationRecord
        {
            get { return _operationRecord; }
        }

        #endregion  // <操作/>

        #region <許可/>

        /// <summary>
        /// 許可内容を取得します。
        /// </summary>
        public string Admission
        {
            get { return MsgUtil.GetAdmissionName(OperationLimit); }
        }

        #endregion  // <許可/>

        #region <設定適用/>

        ///// <summary>
        ///// 設定適用を取得します。
        ///// </summary>
        ///// <value>設定適用</value>
        //public string SettingApp
        //{
        //    get
        //    {
        //        if (this.OperationLimit.Equals(OperationLimit.Enable)) return string.Empty;
        //        return GetSettingApp();
        //    }
        //}

        #endregion  // <設定適用/>

        #region <操作権限/>

        /// <summary>操作権限</summary>
        private OperationLimit _operationLimit;
        /// <summary>
        /// 操作権限のアクセサ
        /// </summary>
        /// <value>操作権限</value>
        public virtual OperationLimit OperationLimit
        {
            get { return _operationLimit; }
            set { _operationLimit = value; }
        }

        #endregion  // <操作権限/>

        #region <制限/>

        /// <summary>
        /// 制限内容を取得します。
        /// </summary>
        /// <value>制限内容</value>
        public string Limitation
        {
            get
            {
                switch (this.OperationLimit)
                {
                    //case OperationLimit.Enable:
                    //    return "制限なし";                  // LITERAL:
                    case OperationLimit.EnableWithLog:
                        return Name + " はログ記録する";    // LITERAL:
                    default:
                        return Name + " は許可しない";      // LITERAL:
                }
            }
        }

        #endregion  // <制限/>

        /// <summary>グリッド上のカテゴリ全体の操作権限</summary>
        private OperationLimit _operationLimitOfAllcategoryOnGrid;
        /// <summary>
        /// グリッド上のカテゴリ全体の操作権限のアクセサ
        /// </summary>
        /// <value>グリッド上のカテゴリ全体の操作権限</value>
        public OperationLimit OperationLimitOfAllcategoryOnGrid
        {
            get { return _operationLimitOfAllcategoryOnGrid; }
            set { _operationLimitOfAllcategoryOnGrid = value; }
        }

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        protected SettingState(OperationLimit operationLimit)
        {
            _operationLimit = operationLimit;
            _operationLimitOfAllcategoryOnGrid = OperationLimit.Disable;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 設定適用を取得します。
        /// </summary>
        /// <returns>設定適用</returns>
        protected abstract string GetSettingApp();

        /// <summary>
        /// オペレーションマスタDBのレコードを生成します。
        /// </summary>
        /// <param name="settingRow">操作権限設定行</param>
        /// <returns>オペレーションマスタDBのレコード</returns>
        protected static Operation CreateOperation(SettingDataSet.SettingRow settingRow)
        {
            Operation ope = new Operation();
            {
                ope.CategoryCode    = settingRow.CategoryCode;
                ope.CategoryDspOdr  = settingRow.CategoryDspOdr;
                ope.CategoryName    = settingRow.CategoryName;
                ope.OfferDate       = TDateTime.DateTimeToLongDate(settingRow.OfferDate);
                ope.OperationCode   = settingRow.OperationCode;
                ope.OperationDspOdr = settingRow.OperationDspOdr;
                ope.OperationName   = settingRow.OperationName;
                ope.PgDspOdr        = settingRow.PgDspOdr;
                ope.PgId            = settingRow.PgId;
                ope.PgName          = settingRow.PgName;
            }
            return ope;
        }

        /// <summary>
        /// 全カテゴリの設定であるか判定します。
        /// </summary>
        /// <value>true :全カテゴリ設定である。<br/>false:全カテゴリ設定ではない。</value>
        protected bool AmAllCategorySetting
        {
            get { return OperationRecord.PgId.Equals(OperationLimitation.ALL_CATEGORY_ID); }
        }
    }

    #region <職種/>

    /// <summary>
    /// 職種の操作権限設定の状態クラス
    /// </summary>
    public sealed class JobTypeSettingState : SettingState
    {
        #region <職種レベル（権限レベル1）/>

        /// <summary>職種レベル（権限レベル1）</summary>
        private readonly CodeNamePair<int> _jobTypeLevel;
        /// <summary>
        /// 職種レベル（権限レベル1）を取得します。
        /// </summary>
        /// <value>職種レベル（権限レベル1）</value>
        public CodeNamePair<int> JobTypeLevel
        {
            get { return _jobTypeLevel; }
        }

        #endregion  // <職種レベル（権限レベル1）/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        /// <param name="jobTypeInfo">職種情報</param>
        private JobTypeSettingState(
            OperationLimit operationLimit,
            JobTypeDataRow jobTypeInfo
        ) : base(operationLimit)
        {
            _jobTypeLevel   = new CodeNamePair<int>(jobTypeInfo.AuthorityLevelCd, jobTypeInfo.AuthorityLevelNm);
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタレコード</param>
        /// <param name="jobTypeInfo">職種情報</param>
        public JobTypeSettingState(
            Operation operationMasterRecord,
            JobTypeDataRow jobTypeInfo
        ) : this(
            OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB.GetOperationLimitFromJobType(
                operationMasterRecord.CategoryCode,
                operationMasterRecord.PgId,
                operationMasterRecord.OperationCode,
                jobTypeInfo.AuthorityLevelCd
            ),
            jobTypeInfo
        )
        {
            _operationRecord= operationMasterRecord;
            _jobTypeLevel   = new CodeNamePair<int>(jobTypeInfo.AuthorityLevelCd, jobTypeInfo.AuthorityLevelNm);
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="settingRow">操作権限設定レコード</param>
        public JobTypeSettingState(SettingDataSet.SettingRow settingRow) : base((OperationLimit)settingRow.OperationLimit)
        {
            _operationRecord = CreateOperation(settingRow);

            AuthorityLevelLcDBAgent jobTypeLevelDB = OperationAuthoritySettingAcs.Instance.AuthorityLevelMasterDB;
            _jobTypeLevel = new CodeNamePair<int>(
                settingRow.AuthorityLevel1,
                jobTypeLevelDB.GetJobTypeName(settingRow.AuthorityLevel1)
            );
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <value>名称</value>
        protected override string Name
        {
            get
            {
                return "業種:" + JobTypeLevel.Name; // LITERAL:
            }
        }

        /// <summary>
        /// 操作権限のアクセサ
        /// </summary>
        /// <value>操作権限</value>
        /// <exception cref="InvalidOperationException">カテゴリ全体の設定のため変更できません。</exception>
        public override OperationLimit OperationLimit
        {
            get { return base.OperationLimit; }
            set
            {
                if (AmAllCategorySetting)
                {
                    base.OperationLimit = value;
                    return;
                }

                if (!OperationLimitOfAllcategoryOnGrid.Equals(OperationLimit.EnableWithLog))
                {
                    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                }

                // HACK:ゴミ掃除
                //OperationStDBAgent operationSettingMasterDB = OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB;
                //if (operationSettingMasterDB.IsCategorySettingWhatJobType(OperationRecord.CategoryCode, JobTypeLevel.Code))
                //{
                //    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                //}

                base.OperationLimit = value;
            }
        }

        /// <summary>
        /// 設定適用を取得します。
        /// </summary>
        /// <returns>設定適用</returns>
        protected override string GetSettingApp()
        {
            if (OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB.IsCategorySettingWhatJobType(
                OperationRecord.CategoryCode,
                OperationRecord.OperationCode,
                JobTypeLevel.Code
            ))
            {
                return OperationRecord.CategoryName + ALL_CATEGORY_NAME;
            }
            return string.Empty;
        }

        #endregion  // <Override/>
    }

    #endregion  // <職種/>

    #region <雇用形態/>

    /// <summary>
    /// 雇用形態の操作権限設定の状態クラス
    /// </summary>
    public sealed class EmploymentFormSettingState : SettingState
    {
        #region <雇用形態レベル（権限レベル2）/>

        /// <summary>雇用形態レベル（権限レベル2）</summary>
        private readonly CodeNamePair<int> _employmentFormLevel;
        /// <summary>
        /// 雇用形態レベル（権限レベル2）を取得します。
        /// </summary>
        /// <value>雇用形態レベル（権限レベル2）</value>
        public CodeNamePair<int> EmploymentFormLevel
        {
            get { return _employmentFormLevel; }
        }

        #endregion  // <雇用形態レベル（権限レベル2）/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        /// <param name="employmentFormInfo">雇用形態情報</param>
        private EmploymentFormSettingState(
            OperationLimit operationLimit,
            EmploymentFormDataRow employmentFormInfo
        ) : base(operationLimit)
        {
            _employmentFormLevel= new CodeNamePair<int>(employmentFormInfo.AuthorityLevelCd, employmentFormInfo.AuthorityLevelNm);
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタレコード</param>
        /// <param name="employmentFormInfo">雇用形態情報</param>
        public EmploymentFormSettingState(
            Operation operationMasterRecord,
            EmploymentFormDataRow employmentFormInfo
        ) : this(
            OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB.GetOperationLimitFromEmploymentForm(
                operationMasterRecord.CategoryCode,
                operationMasterRecord.PgId,
                operationMasterRecord.OperationCode,
                employmentFormInfo.AuthorityLevelCd
            ),
            employmentFormInfo
        )
        {
            _operationRecord    = operationMasterRecord;
            _employmentFormLevel= new CodeNamePair<int>(employmentFormInfo.AuthorityLevelCd, employmentFormInfo.AuthorityLevelNm);
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="settingRow">操作権限設定レコード</param>
        public EmploymentFormSettingState(SettingDataSet.SettingRow settingRow) : base((OperationLimit)settingRow.OperationLimit)
        {
            _operationRecord = CreateOperation(settingRow);

            AuthorityLevelLcDBAgent employmentFormLevelDB = OperationAuthoritySettingAcs.Instance.AuthorityLevelMasterDB;
            _employmentFormLevel = new CodeNamePair<int>(
                settingRow.AuthorityLevel2,
                employmentFormLevelDB.GetEmploymentFormName(settingRow.AuthorityLevel2)
            );
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <value>名称</value>
        protected override string Name
        {
            get
            {
                return "雇用形態:" + EmploymentFormLevel.Name; // LITERAL:
            }
        }

        /// <summary>
        /// 操作権限のアクセサ
        /// </summary>
        /// <value>操作権限</value>
        /// <exception cref="InvalidOperationException">カテゴリ全体の設定のため変更できません。</exception>
        public override OperationLimit OperationLimit
        {
            get { return base.OperationLimit; }
            set
            {
                if (AmAllCategorySetting)
                {
                    base.OperationLimit = value;
                    return;
                }

                if (!OperationLimitOfAllcategoryOnGrid.Equals(OperationLimit.EnableWithLog))
                {
                    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                }

                // HACK:ゴミ掃除
                //OperationStDBAgent operationSettingMasterDB = OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB;
                //if (operationSettingMasterDB.IsCategorySettingWhatEmploymentForm(OperationRecord.CategoryCode, EmploymentFormLevel.Code))
                //{
                //    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                //}

                base.OperationLimit = value;
            }
        }

        /// <summary>
        /// 設定適用を取得します。
        /// </summary>
        /// <returns>設定適用</returns>
        protected override string GetSettingApp()
        {
            if (OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB.IsCategorySettingWhatEmploymentForm(
                OperationRecord.CategoryCode,
                OperationRecord.OperationCode,
                EmploymentFormLevel.Code
            ))
            {
                return OperationRecord.CategoryName + ALL_CATEGORY_NAME;
            }
            return string.Empty;
        }

        #endregion  // <Override/>
    }

    #endregion  // <雇用形態/>

    #region <従業員/>

    /// <summary>
    /// 従業員の操作権限設定の状態クラス
    /// </summary>
    public sealed class EmployeeSettingState : SettingState
    {
        #region <設定適用マップ/>

        /// <summary>設定適用マップ</summary>
        private static Dictionary<string, SettingAppFormatMapValue> _settingAppMap;
        /// <summary>
        /// 設定適用マップを取得します。
        /// </summary>
        /// <remarks>
        /// キーの値：従業員のOperationLimit.ToString() + 雇用形態のOperationLimit.ToString() + 職種のOperationLimit.ToString()
        /// </remarks>
        /// <value>設定適用マップ</value>
        private static Dictionary<string, SettingAppFormatMapValue> SettingAppMap
        {
            get
            {
                if (_settingAppMap == null)
                {
                    _settingAppMap = new Dictionary<string, SettingAppFormatMapValue>();

                    #region <テーブルの設定/>

                    const string JOB_TYPE = "ロール（業務）:{2}";                                 // LITERAL:
                    const string EMPLOYMENT_FORM = "ロール（権限）:{1}";                      // LITERAL:
                    const string JOB_EMPLOYMENT = JOB_TYPE + "、" + EMPLOYMENT_FORM;    // LITERAL;

                    //// ①従業員：なし／雇用形態：なし／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(string.Empty, true)
                    //);
                    //// ②従業員：なし／雇用形態：なし／職種：ログ
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, true)
                    //);
                    //// ③従業員：なし／雇用形態：なし／職種：制限
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, false)
                    //);
                    //// ④従業員：なし／雇用形態：ログ／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, true)
                    //);
                    //// ⑤従業員：なし／雇用形態：ログ／職種：ログ
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString(),
                    //    new SettingAppFormatMapValue(JOB_EMPLOYMENT, true)
                    //);
                    //// ⑥従業員：なし／雇用形態：ログ／職種：制限
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, false)
                    //);
                    //// ⑦従業員：なし／雇用形態：制限／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    //);
                    //// ⑧従業員：なし／雇用形態：制限／職種：ログ
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    //);
                    //// ⑨従業員：なし／雇用形態：制限／職種：制限
                    //_settingAppMap.Add(
                    //    OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString(),
                    //    new SettingAppFormatMapValue(JOB_EMPLOYMENT, false)
                    //);
                    // ⑩従業員：ログ／雇用形態：なし／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(string.Empty, true)
                    //);
                    //// ⑪従業員：ログ／雇用形態：なし／職種：ログ
                    //_settingAppMap.Add(
                    //    OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, true)
                    //);
                    //// ⑫従業員：ログ／雇用形態：なし／職種：制限
                    //_settingAppMap.Add(
                    //    OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, false)
                    //);
                    //// ⑬従業員：ログ／雇用形態：ログ／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, true)
                    //);
                    // ⑭従業員：ログ／雇用形態：ログ／職種：ログ
                    _settingAppMap.Add(
                        OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString(),
                        new SettingAppFormatMapValue(JOB_EMPLOYMENT, true)
                    );
                    // ⑮従業員：ログ／雇用形態：ログ／職種：制限
                    _settingAppMap.Add(
                        OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString(),
                        new SettingAppFormatMapValue(JOB_TYPE, false)
                    );
                    //// ⑯従業員：ログ／雇用形態：制限／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    //);
                    // ⑰従業員：ログ／雇用形態：制限／職種：ログ
                    _settingAppMap.Add(
                        OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString(),
                        new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    );
                    // ⑱従業員：ログ／雇用形態：制限／職種：制限
                    _settingAppMap.Add(
                        OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString(),
                        new SettingAppFormatMapValue(JOB_EMPLOYMENT, false)
                    );
                    //// ⑲従業員：制限／雇用形態：なし／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(string.Empty, true)
                    //);
                    //// ⑳従業員：制限／雇用形態：なし／職種：ログ
                    //_settingAppMap.Add(
                    //    OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.EnableWithLog.ToString(),
                    //    new SettingAppFormatMapValue(string.Empty,true)
                    //);
                    //// (21)従業員：制限／雇用形態：なし／職種：制限
                    //_settingAppMap.Add(
                    //    OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString() + OperationLimit.Disable.ToString(),
                    //    new SettingAppFormatMapValue(JOB_TYPE, false)
                    //);
                    //// (22)従業員：制限／雇用形態：ログ／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(string.Empty, true)
                    //);
                    // (23)従業員：制限／雇用形態：ログ／職種：ログ
                    _settingAppMap.Add(
                        OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.EnableWithLog.ToString(),
                        new SettingAppFormatMapValue(string.Empty, true)
                    );
                    // (24)従業員：制限／雇用形態：ログ／職種：制限
                    _settingAppMap.Add(
                        OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString() + OperationLimit.Disable.ToString(),
                        new SettingAppFormatMapValue(JOB_TYPE, false)
                    );
                    //// (25)従業員：制限／雇用形態：制限／職種：なし
                    //_settingAppMap.Add(
                    //    OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Enable.ToString(),
                    //    new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    //);
                    // (26)従業員：制限／雇用形態：制限／職種：ログ
                    _settingAppMap.Add(
                        OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.EnableWithLog.ToString(),
                        new SettingAppFormatMapValue(EMPLOYMENT_FORM, false)
                    );
                    // (27)従業員：制限／雇用形態：制限／職種：制限
                    _settingAppMap.Add(
                        OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString() + OperationLimit.Disable.ToString(),
                        new SettingAppFormatMapValue(JOB_EMPLOYMENT, false)
                    );

                    #endregion  // <テーブルの設定/>
                }
                return _settingAppMap;
            }
        }

        /// <summary>
        /// 設定適用マップのキーを取得します。
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタDBのレコード</param>
        /// <param name="employeeMasterRecord">従業員マスタDBのレコード</param>
        /// <returns>設定適用マップのキー</returns>
        private string GetSettingAppMapKey(
            Operation operationMasterRecord,
            Employee employeeMasterRecord
        )
        {
            StringBuilder sqlWhere = new StringBuilder();
            {
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.CategoryCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(operationMasterRecord.CategoryCode);
                sqlWhere.Append(ADOUtil.AND);
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.PgId);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(operationMasterRecord.PgId));
                sqlWhere.Append(ADOUtil.AND);
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.OperationCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(operationMasterRecord.OperationCode);
                sqlWhere.Append(ADOUtil.AND);
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.OperationStDiv);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append((int)OperationSettingMasterDataSet.OperationStDiv.EmployeeCode);
                sqlWhere.Append(ADOUtil.AND);
                sqlWhere.Append(OperationSettingMasterDataSet.ClmIdx.EmployeeCode);
                sqlWhere.Append(ADOUtil.EQ);
                sqlWhere.Append(ADOUtil.GetString(employeeMasterRecord.EmployeeCode));
            }

            OperationStDBAgent operationSettingMasterDB = OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB;
            DataRow[] foundRows = operationSettingMasterDB.Tbl.Select(sqlWhere.ToString());

            OperationLimit employeeLimit = OperationLimit.EnableWithLog;
            if (foundRows.Length > 0)
            {
                const int SINGLE_ROW = 0;   // 職種、雇用形態、従業員コードで3者択一になるので、単一行となる
                switch (((OperationSettingMasterDataSet.OperationSettingMasterRow)foundRows[SINGLE_ROW]).LimitDiv)
                {
                    case (int)OperationSettingMasterDataSet.LimitDiv.WithLog:
                        employeeLimit = OperationLimit.EnableWithLog;
                        break;
                    case (int)OperationSettingMasterDataSet.LimitDiv.Limitation:
                        employeeLimit = OperationLimit.Disable;
                        break;
                }
            }

            OperationLimit employmentFormLimit = operationSettingMasterDB.GetOperationLimitFromEmploymentForm(
                operationMasterRecord.CategoryCode,
                operationMasterRecord.PgId,
                operationMasterRecord.OperationCode,
                employeeMasterRecord.AuthorityLevel2
            );

            OperationLimit jobTypeLimit = operationSettingMasterDB.GetOperationLimitFromJobType(
                operationMasterRecord.CategoryCode,
                operationMasterRecord.PgId,
                operationMasterRecord.OperationCode,
                employeeMasterRecord.AuthorityLevel1
            );

            // キーの値：従業員のOperationLimit.ToString() + 雇用形態のOperationLimit.ToString() + 職種のOperationLimit.ToString()
            return employeeLimit.ToString() + employmentFormLimit.ToString() + jobTypeLimit.ToString();
        }

        /// <summary>
        /// 操作権限が設定できるか判定します。
        /// </summary>
        /// <returns>true :できる。<br/>false:できない。</returns>
        private bool CanSetOperationLimit()
        {
            string formatKey = GetSettingAppMapKey(OperationRecord, EmployeeRecord);
            return SettingAppMap[formatKey].Second;
        }

        /// <summary>
        /// 設定適用フォーマットを取得します。
        /// </summary>
        /// <returns>設定適用フォーマット</returns>
        private string GetSettingAppFormat()
        {
            string formatKey = GetSettingAppMapKey(OperationRecord, EmployeeRecord);
            return SettingAppMap[formatKey].First;
        }

        #endregion  // <設定適用フォーマット/>

        #region <従業員情報/>

        /// <summary>従業員マスタDBのレコード</summary>
        private readonly EmployeeType _employeeRecord;
        /// <summary>
        /// 従業員マスタDBのレコードを取得します。
        /// </summary>
        /// <value>従業員マスタDBのレコード</value>
        public EmployeeType EmployeeRecord
        {
            get { return _employeeRecord; }
        }

        #endregion  // <従業員情報/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationLimit">操作権限</param>
        /// <param name="employeeInfo">従業員情報</param>
        private EmployeeSettingState(
            OperationLimit operationLimit,
            EmployeeType employeeInfo
        ) : base(operationLimit)
        {
            _employeeRecord = employeeInfo;
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="operationMasterRecord">オペレーションマスタレコード</param>
        /// <param name="employeeInfo">従業員情報</param>
        public EmployeeSettingState(
            Operation operationMasterRecord,
            EmployeeType employeeInfo
        ) : this(
            OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB.GetOperationLimit(
                operationMasterRecord.CategoryCode,
                operationMasterRecord.PgId,
                operationMasterRecord.OperationCode,
                employeeInfo
            ),
            employeeInfo
        )
        {
            _operationRecord    = operationMasterRecord;
            _employeeRecord     = employeeInfo;
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="settingRow">操作権限設定レコード</param>
        public EmployeeSettingState(SettingDataSet.SettingRow settingRow) : base((OperationLimit)settingRow.OperationLimit)
        {
            _operationRecord = CreateOperation(settingRow);

            EmployeeAcsAgent employeeMasterDB = OperationAuthoritySettingAcs.Instance.EmployeeMasterDB;
            _employeeRecord = employeeMasterDB.RecordMap[settingRow.EmployeeCode];
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 名称を取得します。
        /// </summary>
        /// <value>名称</value>
        protected override string Name
        {
            get
            {
                return "従業員:" + EmployeeRecord.Name;   // LITERAL:
            }
        }

        /// <summary>
        /// 操作権限のアクセサ
        /// </summary>
        /// <value>操作権限</value>
        /// <exception cref="InvalidOperationException">職種または雇用形態の操作権限が優先されるため、設定できません。</exception>
        public override OperationLimit OperationLimit
        {
            get { return base.OperationLimit; }
            set
            {
                string formatKey = GetSettingAppMapKey(OperationRecord, EmployeeRecord);
                if (!CanSetOperationLimit())
                {
                    throw new InvalidOperationException(
                        "職種または雇用形態の操作権限が優先されるため、設定できません。"    // LITERAL:
                    );
                }

                if (AmAllCategorySetting)
                {
                    base.OperationLimit = value;
                    return;
                }

                if (!OperationLimitOfAllcategoryOnGrid.Equals(OperationLimit.EnableWithLog))
                {
                    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                }

                // HACK:ゴミ掃除
                //OperationStDBAgent operationSettingMasterDB = OperationAuthoritySettingAcs.Instance.OperationSettingMasterDB;
                //if (operationSettingMasterDB.IsCategorySettingWhatEmployeeCode(OperationRecord.CategoryCode, EmployeeRecord.EmployeeCode))
                //{
                //    throw new InvalidOperationException(CANNOT_SET_BECAUSE_ALL_CATEGOTY);
                //}

                base.OperationLimit = value;
            }
        }

        /// <summary>
        /// 設定適用を取得します。
        /// </summary>
        /// <returns>設定適用</returns>
        protected override string GetSettingApp()
        {
            AuthorityLevelLcDBAgent authorityLevelMasterDB = OperationAuthoritySettingAcs.Instance.AuthorityLevelMasterDB;
            string employeeName = EmployeeRecord.Name;
            string employmentFormName = authorityLevelMasterDB.GetEmploymentFormName(EmployeeRecord.AuthorityLevel2);
            string jobTypeName = authorityLevelMasterDB.GetJobTypeName(EmployeeRecord.AuthorityLevel1);

            return string.Format(GetSettingAppFormat(), employeeName, employmentFormName, jobTypeName);
        }

        #endregion  // <Override/>
    }

    #endregion  // <従業員/>
}
