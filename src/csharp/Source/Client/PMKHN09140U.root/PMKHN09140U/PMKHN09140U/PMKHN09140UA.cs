//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作履歴ログ表示
// プログラム概要   : 一般操作履歴ログの表示を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/02/22  修正内容 : 列サイズの自動調整=ONを初期値に変更。
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 作 成 日  2011/04/06  修正内容 : Redmine#20388の対応。
//----------------------------------------------------------------------------//
// 管理番号  11202046-00 作成担当 : 時シン
// 作 成 日  K2016/10/28 修正内容 : 神姫産業㈱ テキスト出力機能追加と時刻検索条件の追加対応
//----------------------------------------------------------------------------//
// 管理番号  11770181-00 作成担当 : 陳艶丹
// 作 成 日  2021/12/15  修正内容 : テキスト出力機能追加と時刻検索条件の追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms.Items;

using Infragistics.Win.UltraWinGrid;
using System.IO; // ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応

namespace Broadleaf.Windows.Forms
{
    using SectionItemType       = CodeNamePair<string>;
    using JobTypeDataRow        = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using JobTypeItemType       = CodeNamePair<int>;
    using EmploymentFormDataRow = AuthorityLevelMasterDataSet.AuthorityLevelMasterRow;
    using EmploymentFormItemType= CodeNamePair<int>;
    using CategoryItemType      = CodeNamePair<int>;
    using PgItemType            = CodeNamePair<string>;
    using OperationItemType     = CodeNamePair<int>;

    /// <summary>
    /// 一般操作履歴ログの表示フォームコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2010.02.22  22018 鈴木 正臣</br>
    /// <br>           : 列サイズの自動調整=ONを初期値に変更。</br>
    /// <br>Update Note: 2011/04/06  曹文傑</br>
    /// <br>           : Redmine#20388の対応。</br>
    /// <br>Update Note: K2016/10/28 時シン</br>
    /// <br>管理番号   : 11202046-00</br>
    /// <br>           : 神姫産業㈱ テキスト出力機能追加と時刻検索条件の追加対応</br>
    /// <br>Update Note: 2021/12/15  陳艶丹</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
    /// </remarks>
    //----- UPD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
    //public partial class PMKHN09140UA : Form, ISecurityManagementForm
    public partial class PMKHN09140UA : Form, ISecurityManagementForm, IDoTextOutForm
    //----- UPD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
    {
        //----- ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
        #region <Const メンバ/>
        // 区切り形式
        private const string CSVSTR = ",";
        private const string TXTSTR = "\t";

        /// <summary>ファイルが他で使用中</summary>
        private static string CT_FILEALRDYERROR = "出力ファイルが他で使用中です。";
        /// <summary>アクセスが拒否された</summary>
        private static string CT_FILEACCESSERROR = "出力ファイルへのアクセスが拒否されました。";

        /// <summary> 日付 </summary>
        private const string ct_Col_Date = "Date";
        /// <summary> 時刻 </summary>
        private const string ct_Col_Time = "Time";
        /// <summary> 拠点 </summary>
        private const string ct_Col_SectionName = "SectionName";
        /// <summary> 端末 </summary>
        private const string ct_Col_MachineName = "MachineName";
        /// <summary> 職種 </summary>
        private const string ct_Col_JobTypeName = "JobTypeName";
        /// <summary> 雇用形態 </summary>
        private const string ct_Col_EmployMentFormName = "EmployMentFormName";
        /// <summary> 従業員 </summary>
        private const string ct_Col_EmployeeName = "EmployeeName";
        /// <summary> カテゴリ </summary>
        private const string ct_Col_CategoryName = "CategoryName";
        /// <summary> 機能 </summary>
        private const string ct_Col_PgName = "PgName";
        /// <summary> 操作 </summary>
        private const string ct_Col_OperationName = "OperationName";
        /// <summary> メッセージ </summary>
        private const string ct_Col_Message = "Message";

        /// <summary>時刻（時）エラー</summary>
        private const string MSG_HOUR_ERR = "時刻（時）の入力が不正です。";
        /// <summary>時刻（分）エラー</summary>
        private const string MSG_MINUTE_ERR = "時刻（分）の入力が不正です。";
        /// <summary>時刻（秒）エラー</summary>
        private const string MSG_SECOND_ERR = "時刻（秒）の入力が不正です。";
        /// <summary>時刻範囲エラー</summary>
        private const string MSG_TIME_RANGE_ERR = "時刻の範囲指定に誤りがあります。";
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
        /// <summary>時刻範囲エラー</summary>
        private const string MSG_TIME_RANGE_ERR_2 = "時刻の範囲が不正です。「00:00:00～30:00:00」の範囲内で指定して下さい。";

        private const int CNT_ZERO = 0;
        private const string MINTIMESTR = "00";
        private const int MINTIME = 0;
        private const string MAXHOUR = "24";
        private const string TIMEFMT = "d2";
        private const int HSEC = 3600;
        private const int MSEC = 60;
        private const int ONEDAY = 1;
        private const int ONEDAYHOUR = 24;
        private const int INPUTMAXHOUR = 30;
        private const int NIGHTHOUR = 6;

        //チェックモード（0:時 1:分 2:秒）
        enum CheckTimeMode : int
        {
            CheckTimeH = 0,
            CheckTimeM = 1,
            CheckTimeS = 2,
        }
        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
        #endregion

        #region <Private メンバ/>
        /// <summary> 時刻検索条件を表示するフラグ </summary>
        /// <value>true:表表示 false:非表示</value>
        private bool CanTimeCondtDisplay = false;
        /// <summary> 設定情報 </summary>
        private ExtractionConditionSet ExtractionConditionSetObj;
        #endregion
        //----- ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<

        #region <ISecurityManagementForm メンバ/>

        /// <summary>
        /// 保存ボタンを表示するフラグ
        /// </summary>
        /// <value>true :保存ボタンを表示<br/>false:保存ボタンを非表示</value>
        public bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// 表示更新ボタンを表示するフラグ
        /// </summary>
        /// <value>true :表示更新ボタンを表示<br/>false:表示更新ボタンを非表示</value>
        public bool CanUpdateDisplay
        {
            get { return true; }
        }

        /// <summary>
        /// 保存ボタン押下時の処理を行います。
        /// </summary>
        /// <returns>成功時に 0(=(int)ResultCode.Normal) を返します。 </returns>
        public int Write()
        {
            return (int)ResultCode.Normal;  // 何も処理しない
        }

        /// <summary>
        /// 表示更新ボタン押下時の処理を行います。
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : K2016/10/28 時シン</br>
        /// <br>管理番号     : 11202046-00</br>
        /// <br>             : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note  : 2021/12/15  陳艶丹</br>
        /// <br>管理番号     : 11770181-00</br>
        /// <br>             : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        public void UpdateDisplay()
        {
            string message = string.Empty;
            if (!UIUtil.IsOKThatInputDateRangeCheck(this.fromTDateEdit, this.toTDateEdit, out message))
            {
                MessageBox.Show(message, MESSEAGE_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogCondition condition = GetCondition();

            //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (condition == null)
            {
                return;
            }
            //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
            if (DateTimeUtil.HasError( condition.From, condition.To ))
            {
                MessageBox.Show(
                    "日時の入力が不正です。",   // LITERAL:
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            this.operationLogDB = (LogDataSet)OperationHistoryAcs.Instance.RefreshLogSet(condition).Copy();
            RefreshOperationLogGrid(this.operationLogDB, condition);

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            //if (CanTimeCondtDisplay) // DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
            if (CanTimeCondtDisplay && this.ExtractionConditionSetObj != null) // 神姫産業のみ // DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
            {
                // 時刻検索条件の保存
                if (this.operationLogDB != null && this.operationLogDB.Log != null && this.operationLogDB.Log.DefaultView != null && this.operationLogDB.Log.DefaultView.Count > CNT_ZERO)
                {
                    this.uiMemInput1.WriteMemInput();
                }
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
        }

        /// <summary>
        /// 対応するタブがアクティブになった時の処理を行います。
        /// </summary>
        public void Active()
        {
            // TODO:必要に応じて
        }

        #endregion  // <ISecurityManagementForm メンバ/>

        #region <Const/>

        /// <summary>メッセージのキャプション</summary>
        private const string MESSEAGE_CAPTION = "情報－＜操作履歴表示＞";

        #endregion  // <Const/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMKHN09140UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // 拠点
            _sectionCheckedList = new SectionItemController(this.sectionCheckedListBox);

            // カテゴリ、機能、操作
            _operationItemComboBox = new OperationItemController(
                this.categoryTComboEditor,
                this.pgIdTComboEditor,
                this.operationTComboEditor
            );

            // 従業員ガイドのフォーカス制御
            _employeeGuideController = new GeneralGuideUIController(
                this.tEdit_EmployeeCode,
                this.employeeGuideButton,
                this.categoryTComboEditor
            );
        }

        #endregion  // <Constructor/>

        #region <フォーム/>

        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private void PMKHN09140UA_Load(object sender, EventArgs e)
        {
            // 日時
            UIUtil.InitializeDateTimeUI(this.fromTDateEdit, this.toTDateEdit);
            InitializeFromTo();

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (CanTimeCondtDisplay)
            {
                this.panel_Time.Visible = true;
                //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                //this.tEdit_Hour.Text = DateTime.Now.Hour.ToString( "00" );
                //this.tEdit_Minute.Text = DateTime.Now.Minute.ToString("00");
                //this.tEdit_Second.Text = DateTime.Now.Second.ToString("00");
                //this.label_TimeEd.Text = DateTime.Now.Date.ToString("hh:MM:ss");
                //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                this.tEdit_Hour.Text = MINTIMESTR;
                this.tEdit_Minute.Text = MINTIMESTR;
                this.tEdit_Second.Text = MINTIMESTR;
                this.tNedit_Hour_Ed.Text = MAXHOUR;
                this.tNedit_Minute_Ed.Text = MINTIMESTR;
                this.tNedit_Second_Ed.Text = MINTIMESTR;
                //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

                if (this.ExtractionConditionSetObj != null)
                {
                    //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                    //string endTime = string.Empty;
                    //string latenightTimezoneEnd = string.Empty;
                    //if (this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endTime) && this.CheckTime(this.ExtractionConditionSetObj.LatenightTimezoneEnd, out latenightTimezoneEnd))
                    //{
                    //    this.label_TimeEd.Text = endTime;
                    //}
                    //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

                    //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                    int endHour = 0;
                    int endMinute = 0;
                    int endSecode = 0;
                    if (this.CheckTime(this.ExtractionConditionSetObj.EndTime, out endHour, out endMinute, out endSecode))
                    {
                        this.tNedit_Hour_Ed.Text = endHour.ToString(TIMEFMT);
                        this.tNedit_Minute_Ed.Text = endMinute.ToString(TIMEFMT);
                        this.tNedit_Second_Ed.Text = endSecode.ToString(TIMEFMT);
                    }

                    // 開始時刻_時、分、秒の保存
                    List<Control> ctrlList = new List<Control>();
                    ctrlList.Add(this.tEdit_Hour);
                    ctrlList.Add(this.tEdit_Minute);
                    ctrlList.Add(this.tEdit_Second);
                    this.uiMemInput1.TargetControls = ctrlList;

                    this.uiMemInput1.ReadMemInput();
                    //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                }

                //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                //// 開始時刻_時、分、秒の保存
                //List<Control> ctrlList = new List<Control>();
                //ctrlList.Add(this.tEdit_Hour);
                //ctrlList.Add(this.tEdit_Minute);
                //ctrlList.Add(this.tEdit_Second);
                //this.uiMemInput1.TargetControls = ctrlList;

                //this.uiMemInput1.ReadMemInput();
                //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

            // 職種
            InitializeJobType();

            // 雇用形態
            InitializeEmploymentForm();

            // 従業員
            this.employeeGuideButton.ImageList = IconResourceManagement.ImageList16;
            this.employeeGuideButton.Appearance.Image = (int)Size16_Index.STAR1;
            // 従業員ガイドのフォーカス制御の開始
            EmployeeGuideController.StartControl();

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (!CanTimeCondtDisplay)
            {
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
                // 操作ログ
                InitializeOperationLogGrid();

                // 文字サイズ
                UIUtil.InitializeFontSizeUI(this.fontSizeTComboEditor);

                // --- ADD m.suzuki 2010/02/22 ---------->>>>>
                // 列幅自動調整
                this.autoFillToGridColumnCheckEditor.Checked = true;
                UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.operationLogGrid);
                // --- ADD m.suzuki 2010/02/22 ----------<<<<<
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            }
            else
            {
                timer1.Enabled = true;
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
        }

        #endregion  // <フォーム/>

        #region <拠点/>

        /// <summary>拠点チェックリスト</summary>
        private readonly SectionItemController _sectionCheckedList;
        /// <summary>
        /// 拠点チェックリストを取得します。
        /// </summary>
        /// <value>拠点チェックリスト</value>
        private SectionItemController SectionCheckedList
        {
            get { return _sectionCheckedList; }
        }

        #endregion  // <拠点/>

        #region <日時/>

        /// <summary>
        /// 開始日時と終了日時を初期化します。
        /// </summary>
        private void InitializeFromTo()
        {
            DateTime now = DateTime.Now;
            DateTime from = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            DateTime to = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            this.fromTime.Value = from;
            this.toTime.Value = to;
        }

        /// <summary>
        /// 開始日時のKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void fromTime_KeyDown(object sender, KeyEventArgs e)
        {
            UIUtil.OnArrowKeyDown(e, UIUtil.GetDateItem(this.fromTDateEdit, UIUtil.TDateEditItemIndex.Day), this.toTDateEdit);
        }

        /// <summary>
        /// 終了日時のKeyDownイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void toTime_KeyDown(object sender, KeyEventArgs e)
        {
            UIUtil.OnArrowKeyDown(e, UIUtil.GetDateItem(this.toTDateEdit, UIUtil.TDateEditItemIndex.Day), this.machineNameTEdit);
        }

        #endregion  // <日時/>

        #region <職種/>

        /// <summary>
        /// 職種を初期化します。
        /// </summary>
        private void InitializeJobType()
        {
            this.jobTypeTComboEditor.Items.Add(new JobTypeItemType(LogCondition.ALL_JOB_TYPE_LEVEL, LogCondition.ALL_JOB_TYPE_NAME));

            Dictionary<int, JobTypeItemType> entryJobTypeMap = new Dictionary<int, JobTypeItemType>();
            foreach (JobTypeDataRow jobTypeRow in OperationHistoryAcs.Instance.AuthorityLevelMasterDB.JobTypeTbl)
            {
                if (!entryJobTypeMap.ContainsKey(jobTypeRow.AuthorityLevelCd))
                {
                    entryJobTypeMap.Add(
                        jobTypeRow.AuthorityLevelCd,
                        new JobTypeItemType(jobTypeRow.AuthorityLevelCd, jobTypeRow.AuthorityLevelNm)
                    );
                    this.jobTypeTComboEditor.Items.Add(entryJobTypeMap[jobTypeRow.AuthorityLevelCd]);
                }
            }

            this.jobTypeTComboEditor.SelectedIndex = 0;
        }

        #endregion  // <職種/>

        #region <雇用形態/>

        /// <summary>
        /// 雇用形態を初期化します。
        /// </summary>
        private void InitializeEmploymentForm()
        {
            this.employmentFormTComboEditor.Items.Add(new EmploymentFormItemType(
                LogCondition.ALL_EMPLOYMENT_FORM_CODE,
                LogCondition.ALL_EMPLOYMENT_FORM_NAME
            ));

            Dictionary<int, EmploymentFormItemType> entryEmploymentFormMap = new Dictionary<int, EmploymentFormItemType>();
            foreach (EmploymentFormDataRow employmentFormRow in OperationHistoryAcs.Instance.AuthorityLevelMasterDB.EmploymentFormTbl)
            {
                if (!entryEmploymentFormMap.ContainsKey(employmentFormRow.AuthorityLevelCd))
                {
                    entryEmploymentFormMap.Add(
                        employmentFormRow.AuthorityLevelCd,
                        new EmploymentFormItemType(employmentFormRow.AuthorityLevelCd, employmentFormRow.AuthorityLevelNm)
                    );
                    this.employmentFormTComboEditor.Items.Add(entryEmploymentFormMap[employmentFormRow.AuthorityLevelCd]);
                }
            }

            this.employmentFormTComboEditor.SelectedIndex = 0;
        }

        #endregion  // <雇用形態/>

        #region <従業員/>

        /// <summary>従業員ガイドの制御オブジェクト</summary>
        private readonly GeneralGuideUIController _employeeGuideController;
        /// <summary>
        /// 従業員ガイドの制御オブジェクトを取得します。
        /// </summary>
        /// <value>従業員ガイドの制御オブジェクト</value>
        private GeneralGuideUIController EmployeeGuideController
        {
            get { return _employeeGuideController; }
        }

        /// <summary>
        /// 従業員ガイドボタンのClickイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void employeeGuideButton_Click(object sender, EventArgs e)
        {
            UIUtil.InputEmployeeCodeAndName(this.tEdit_EmployeeCode, this.employeeNameTEdit);
        }

        #endregion  // <従業員/>

        #region <カテゴリ、機能、操作/>

        /// <summary>カテゴリ、機能、操作コンボボックス</summary>
        private readonly OperationItemController _operationItemComboBox;
        /// <summary>
        /// カテゴリ、機能、操作コンボボックスを取得します。
        /// </summary>
        /// <value>カテゴリ、機能、操作コンボボックス</value>
        internal OperationItemController OperationItemComboBox
        {
            get { return _operationItemComboBox; }
        }

        #endregion  // <カテゴリ、機能、操作/>

        #region <操作ログ/>

        /// <summary>
        /// 操作ログのデータグリッドビューを初期化します。
        /// </summary>
        /// <remarks>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// </remarks>
        private void InitializeOperationLogGrid()
        {
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            // 抽出条件_時刻が非表示の場合
            if (!CanTimeCondtDisplay)
            {
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
                OperationHistoryAcs.Instance.OperationHistoryLogDB.RefreshLog(
                    new LogCondition(LogDataKind.OperationLog)
                );
                this.operationLogDB = (LogDataSet)OperationHistoryAcs.Instance.LogSet.Copy();
            } // ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加

            RefreshOperationLogGrid(this.operationLogDB, null);

            // 列幅自動調整
            this.operationLogGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 表示するカラムを設定
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList = new List<Pair<int, string>>();
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Date,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Time,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.SectionName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.MachineName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.JobTypeName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.EmploymentFormName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.EmployeeName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.CategoryName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.PgName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.OperationName,
                string.Empty
            ));
            columnIndexAndCaptionThatHiddenIsFalseList.Add(new Pair<int, string>(
                (int)LogDataSet.ClmIdx.Message,
                string.Empty
            ));

            FormControlUtil.SetDataGridColumnHidden(this.operationLogGrid, columnIndexAndCaptionThatHiddenIsFalseList);

            // セル選択時は行選択に
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.operationLogGrid.DisplayLayout.Bands[0];
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].CellClickAction = CellClickAction.RowSelect;
            }

            // 列サイズの自動調整
            UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.operationLogGrid);

            //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            // 抽出条件_時刻が表示の場合
            // 初期検索の時、時刻チェックにNGの場合、グリッドの構築完了後、エラーメッセージを表示する。
            if (CanTimeCondtDisplay)
            {
                LogCondition condition = new LogCondition(LogDataKind.OperationLog); // ログデータ種別区分コード(0:記録)
                // 時刻抽出条件のセット
                if (SetTimeToCondition(ref condition))
                {
                    return;
                }
                // 初期検索
                OperationHistoryAcs.Instance.OperationHistoryLogDB.RefreshLog(condition);
                this.operationLogDB = (LogDataSet)OperationHistoryAcs.Instance.LogSet.Copy();
            }
            //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
        }

        /// <summary>
        /// 操作ログのデータグリッドビューの表示を更新します。
        /// </summary>
        /// <param name="opeLogDB">操作ロググリッド</param>
        /// <param name="condition">検索条件</param>
        /// <br>Update Note: 2011/04/06 曹文傑 新しいログが明細部の上方に表示されるようにする為。</br>
        private void RefreshOperationLogGrid(
            LogDataSet opeLogDB,
            LogCondition condition
        )
        {
            Debug.WriteLine("件数：" + opeLogDB.Log.Count.ToString());

            DataView dataView = opeLogDB.Log.DefaultView;
            if (condition != null) dataView.RowFilter = condition.GetWhere();

            // TODO:表示順（ソート順）の定義
            StringBuilder sort = new StringBuilder();
            sort.Append(LogDataSet.ClmIdx.Date).Append(ADOUtil.DESC);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.Time).Append(ADOUtil.DESC);
            // --- ADD 2011/04/06 ---------->>>>>
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.LogDateTime).Append(ADOUtil.DESC);
            // --- ADD 2011/04/06 ----------<<<<<
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.SectionCode);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.MachineName);
            sort.Append(ADOUtil.COMMA);
            sort.Append(LogDataSet.ClmIdx.OperationCode);

            dataView.Sort = sort.ToString();

            this.operationLogGrid.DataSource = dataView;

            if (condition == null) return;

            if (dataView.Count.Equals(0))
            {
                MessageBox.Show(
                    "該当データが存在しません。",   // LITERAL:
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        #endregion  // <操作ログ/>

        #region <検索条件の構築/>

        /// <summary>
        /// 検索条件を取得します。
        /// </summary>
        /// <returns>検索条件</returns>
        /// <remarks>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// </remarks>
        private LogCondition GetCondition()
        {
            LogCondition condition = new LogCondition(LogDataKind.OperationLog);

            // 拠点
            List<SectionItemType> sectionList = SectionCheckedList.CreateCheckedItemList();
            foreach (SectionItemType section in sectionList)
            {
                if (section.Code.Equals(LogCondition.ALL_SECTION_CODE)) break;

                condition.AddSection(section);
            }
            
            // 日時
            string fromD = this.fromTDateEdit.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
            string fromT = DateTimeUtil.DEFAULT_FROM_TIME;
            condition.From = DateTime.Parse(fromD + " " + fromT);

            string toD = this.toTDateEdit.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
            string toT = DateTimeUtil.DEFAULT_TO_TIME;
            condition.To = DateTime.Parse(toD + " " + toT);

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (CanTimeCondtDisplay)
            {
                if (DateTimeUtil.HasError( condition.From, condition.To ))
                {
                    MessageBox.Show(
                        "日時の入力が不正です。",   // LITERAL:
                        MESSEAGE_CAPTION,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return null;
                }
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

            // 端末名
            condition.MachineName = this.machineNameTEdit.Text.Trim();

            // 職種
            condition.JobType = (JobTypeItemType)this.jobTypeTComboEditor.SelectedItem;

            // 雇用形態
            condition.EmploymentForm = (EmploymentFormItemType)this.employmentFormTComboEditor.SelectedItem;

            // 従業員
            condition.EmployeeCode = this.tEdit_EmployeeCode.Text.Trim();

            // カテゴリ
            condition.Category = (CategoryItemType)this.categoryTComboEditor.SelectedItem;

            // 機能
            condition.Pg = (PgItemType)this.pgIdTComboEditor.SelectedItem;

            // 操作
            condition.Operation = (OperationItemType)this.operationTComboEditor.SelectedItem;

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (CanTimeCondtDisplay)
            {
                // 時刻抽出条件のセット
                if (!SetTimeToCondition(ref condition))
                {
                    return null;
                }
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

            return condition;
        }

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
        /// <summary>
        /// 抽出条件に時刻のセット
        /// </summary>
        /// <param name="condition">抽出条件</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件に時刻のセットを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private bool SetTimeToCondition(ref LogCondition condition)
        {
            bool isOK = true;

            // 時刻の入力チェック
            //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            //if (!TimeInputCheck(this.tEdit_Hour, 0, MSG_HOUR_ERR))
            //{
            //    isOK = false;
            //    return isOK;
            //}
            //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

            if (!TimeInputCheck(this.tEdit_Minute, 1, MSG_MINUTE_ERR))
            {
                isOK = false;
                return isOK;
            }

            if (!TimeInputCheck(this.tEdit_Second, 2, MSG_SECOND_ERR))
            {
                isOK = false;
                return isOK;
            }

            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            if (!TimeInputCheck(this.tNedit_Minute_Ed, (int)CheckTimeMode.CheckTimeM, MSG_MINUTE_ERR))
            {
                isOK = false;
                return isOK;
            }

            if (!TimeInputCheck(this.tNedit_Second_Ed, (int)CheckTimeMode.CheckTimeS, MSG_SECOND_ERR))
            {
                isOK = false;
                return isOK;
            }
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

            // 時刻検索フラグ
            condition.TimeSearchFlag = true;

            // 時刻の処理
            DateTime timeSt = DateTime.Now;
            DateTime timeEd = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime latenightTimezoneEndDt = now;

            // 開始日と終了日が両方とも空白の場合
            if (this.fromTDateEdit.GetDateTime().Equals(DateTime.MinValue) &&
                this.toTDateEdit.GetDateTime().Equals(DateTime.MinValue))
            {
                // 開始日＝システム日付、終了日＝システム日付として動作する
                condition.From = now;
                condition.To = now;
            }

            /*----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            // 開始時刻
            timeSt = TimeStrToDateTime(now, string.Format("{0}:{1}:{2}",
                GetTimeFromText(this.tEdit_Hour.Text),
                GetTimeFromText(this.tEdit_Minute.Text),
                GetTimeFromText(this.tEdit_Second.Text)));

            if (this.ExtractionConditionSetObj != null)
            {
                // 深夜時間帯終了時間
                string latenightTimezoneEnd = string.Empty;
                if (this.CheckTime(this.ExtractionConditionSetObj.LatenightTimezoneEnd, out latenightTimezoneEnd))
                {
                    latenightTimezoneEndDt = TimeStrToDateTime(now, latenightTimezoneEnd);
                }
            }

            // 抽出上限
            timeEd = TimeStrToDateTime(now, this.label_TimeEd.Text);
            DateTime firstTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            bool isStTimeAddOneDay = false;
            bool isEdTimeAddOneDay = false;
            // 開始時刻は 00:00:00～深夜時間帯
            if (timeSt.CompareTo(firstTime) >= 0 && timeSt.CompareTo(latenightTimezoneEndDt) <= 0)
            {
                // 開始時刻 + 1D
                timeSt = timeSt.AddDays(1);
                isStTimeAddOneDay = true;
            }
            // 抽出上限は 00:00:00～深夜時間帯
            if (timeEd.CompareTo(firstTime) >= 0 && timeEd.CompareTo(latenightTimezoneEndDt) <= 0)
            {
                // 抽出上限 + 1D
                timeEd = timeEd.AddDays(1);
                isEdTimeAddOneDay = true;
            }

            // 開始時刻 ＞ 抽出上限
            if (timeSt.CompareTo(timeEd) > 0)
            {
                MessageBox.Show(
                     MSG_TIME_RANGE_ERR,
                     MESSEAGE_CAPTION,
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation
                );

                this.tEdit_Hour.Focus();
                isOK = false;
                return isOK;
            }
            else
            {
                // 開始日付(開始時刻付き)
                condition.From = new DateTime(condition.From.Year, condition.From.Month, condition.From.Day, timeSt.Hour, timeSt.Minute, timeSt.Second);
                // 終了日付(抽出上限付き)
                condition.To = new DateTime(condition.To.Year, condition.To.Month, condition.To.Day, timeEd.Hour, timeEd.Minute, timeEd.Second);

                // 開始時刻と抽出上限どちらも 00:00:00～深夜時間帯 の場合
                if (isStTimeAddOneDay && isEdTimeAddOneDay)
                {
                    // 日付
                    // 開始日付 + 1D
                    condition.From = condition.From.AddDays(1);
                    // 終了日付 + 1D
                    condition.To = condition.To.AddDays(1);

                    SetTimeToCondition(ref condition, false, timeSt, timeEd);
                }
                else if (isEdTimeAddOneDay)
                {
                    // 日付
                    // 終了日付 + 1D
                    condition.To = condition.To.AddDays(1);

                    condition.TimeSearchFlag2 = true;

                    // 画面時刻条件：18:30:00 ～ 03:30:00
                    //    ⇒18:30:00 ～ 23:59:59 と 00:00:00 ～ 03:30:00
                    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

                    SetTimeToCondition(ref condition, true, timeSt, timeEd);
                }
                // 開始時刻と抽出上限どちらも 深夜時間帯～23:59:59 の場合
                else if (!isStTimeAddOneDay && !isEdTimeAddOneDay)
                {
                    SetTimeToCondition(ref condition, false, timeSt, timeEd);
                }
            }
            //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<*/

            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            int hourStInt = MINTIME;
            int hourEdInt = MINTIME;
            int minuteStInt = MINTIME;
            int minuteEdInt = MINTIME;
            int secondStInt = MINTIME;
            int secondEdInt = MINTIME;
            bool isStTimeAddOneDay = false;
            bool isEdTimeAddOneDay = false;

            int.TryParse(this.tEdit_Hour.Text.Trim(), out hourStInt);
            int.TryParse(this.tNedit_Hour_Ed.Text.Trim(), out hourEdInt);
            int.TryParse(this.tEdit_Minute.Text.Trim(), out minuteStInt);
            int.TryParse(this.tNedit_Minute_Ed.Text.Trim(), out minuteEdInt);
            int.TryParse(this.tEdit_Second.Text.Trim(), out secondStInt);
            int.TryParse(this.tNedit_Second_Ed.Text.Trim(), out secondEdInt);

            int totalSecondsSt = hourStInt * HSEC + minuteStInt * MSEC + secondStInt;
            int totalSecondsEd = hourEdInt * HSEC + minuteEdInt * MSEC + secondEdInt;

            if (totalSecondsSt > totalSecondsEd)
            {
                MessageBox.Show(
                    MSG_TIME_RANGE_ERR,
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );

                this.tEdit_Hour.Focus();
                isOK = false;
                return isOK;
            }
            else if (totalSecondsSt > INPUTMAXHOUR * HSEC || totalSecondsEd > INPUTMAXHOUR * HSEC)
            {
                // FromとTo共に「00:00:00～30:00:00」まで入力可能
                MessageBox.Show(
                    MSG_TIME_RANGE_ERR_2,   // LITERAL:
                    MESSEAGE_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );

                if (totalSecondsSt > INPUTMAXHOUR * HSEC)
                {
                    this.tEdit_Hour.Focus();
                }
                else
                {
                    this.tNedit_Hour_Ed.Focus();
                }

                isOK = false;
                return isOK;
            }
            else if (totalSecondsEd - totalSecondsSt >= ONEDAYHOUR * HSEC)
            {
                // 24時間を超えてしまう時間指定の場合は、「00:00:00～24:00:00」と同一の条件で検索する。
                hourStInt = MINTIME;
                minuteStInt = MINTIME;
                secondStInt = MINTIME;

                hourEdInt = MINTIME;
                minuteEdInt = MINTIME;
                secondEdInt = MINTIME;

                condition.TimeSearchFlagOverDay = true;
            }
            else
            {
                if (totalSecondsSt >= ONEDAYHOUR * HSEC)
                {
                    isStTimeAddOneDay = true;
                    int tmp = totalSecondsSt - ONEDAYHOUR * HSEC;
                    hourStInt = tmp / HSEC;
                    int left = tmp % HSEC;
                    minuteStInt = left / MSEC;
                    secondStInt = left % MSEC;
                }

                if (totalSecondsEd >= ONEDAYHOUR * HSEC)
                {
                    isEdTimeAddOneDay = true;
                    int tmp = totalSecondsEd - ONEDAYHOUR * HSEC;
                    hourEdInt = tmp / HSEC;
                    int left = tmp % HSEC;
                    minuteEdInt = left / MSEC;
                    secondEdInt = left % MSEC;
                }
            }

            DateTime today = DateTime.Today;
            timeSt = new DateTime(today.Year, today.Month, today.Day, hourStInt, minuteStInt, secondStInt);
            timeEd = new DateTime(today.Year, today.Month, today.Day, hourEdInt, minuteEdInt, secondEdInt);

            // 開始日付(開始時刻付き)
            condition.From = new DateTime(condition.From.Year, condition.From.Month, condition.From.Day, timeSt.Hour, timeSt.Minute, timeSt.Second);
            // 終了日付(抽出上限付き)
            condition.To = new DateTime(condition.To.Year, condition.To.Month, condition.To.Day, timeEd.Hour, timeEd.Minute, timeEd.Second);

            // 24時間を超える場合
            if (condition.TimeSearchFlagOverDay)
            {
                // 終了日付 + 1D
                condition.To = condition.To.AddDays(ONEDAY);
            }

            if (isStTimeAddOneDay && isEdTimeAddOneDay)
            {
                // 日付
                // 開始日付 + 1D
                condition.From = condition.From.AddDays(ONEDAY);
                // 終了日付 + 1D
                condition.To = condition.To.AddDays(ONEDAY);

                SetTimeToCondition(ref condition, false, timeSt, timeEd);
            }
            else if (isEdTimeAddOneDay)
            {
                // 日付
                // 終了日付 + 1D
                condition.To = condition.To.AddDays(ONEDAY);

                condition.TimeSearchFlag2 = true;

                // 画面時刻条件：18:30:00 ～ 27:30:00
                //    ⇒18:30:00 ～ 23:59:59 と 00:00:00 ～ 03:30:00
                // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

                SetTimeToCondition(ref condition, true, timeSt, timeEd);
            }
            // 開始時刻と抽出上限どちらも 00:00:00～23:59:59 の場合
            else if (!isStTimeAddOneDay && !isEdTimeAddOneDay)
            {
                SetTimeToCondition(ref condition, false, timeSt, timeEd);
            }
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

            return isOK;
        }

        /// <summary>
        /// 時刻のチェック
        /// </summary>
        /// <param name="textBox">時刻</param>
        /// <param name="mode">モード（0:時 1:分 2:秒）</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>チェック結果(True:OK False:NG)</returns>
        /// <remarks>
        /// <br>Note       : 時刻のチェックを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool TimeInputCheck(Broadleaf.Library.Windows.Forms.TEdit textBox, int mode, string errorMessage)
        {
            bool isOK = true;

            if (!string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                if (!this.CheckTime(textBox.Text.Trim(), mode))
                {
                    MessageBox.Show(
                         errorMessage,
                         MESSEAGE_CAPTION,
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation
                     );
                    textBox.Focus();
                    isOK = false;
                }
            }
            else
            {
                textBox.Text = "00";
            }

            return isOK;
        }

        /// <summary>
        /// 抽出条件に時刻のセット
        /// </summary>
        /// <param name="condition">抽出条件</param>
        /// <param name="nextDayFlag">１日に跨ぐ</param>
        /// <param name="timeSt">開始時刻</param>
        /// <param name="timeEd">終了時刻</param>
        /// <remarks>
        /// <br>Note       : 抽出条件に時刻のセットを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void SetTimeToCondition(ref LogCondition condition, bool nextDayFlag, DateTime timeSt, DateTime timeEd)
        {
            if (nextDayFlag)
            {
                // 時刻（時）
                condition.SearchHourSt = timeSt.Hour;
                condition.SearchHourEd = 23;
                // 時刻（分）
                condition.SearchMinuteSt = timeSt.Minute;
                condition.SearchMinuteEd = 59;
                // 時刻（秒）
                condition.SearchSecondSt = timeSt.Second;
                condition.SearchSecondEd = 59;

                // 時刻（時）
                condition.SearchHourSt2 = 0;
                condition.SearchHourEd2 = timeEd.Hour;
                // 時刻（分）
                condition.SearchMinuteSt2 = 0;
                condition.SearchMinuteEd2 = timeEd.Minute;
                // 時刻（秒）
                condition.SearchSecondSt2 = 0;
                condition.SearchSecondEd2 = timeEd.Second;
            }
            else
            {
                // 時刻（時）
                condition.SearchHourSt = timeSt.Hour;
                condition.SearchHourEd = timeEd.Hour;
                // 時刻（分）
                condition.SearchMinuteSt = timeSt.Minute;
                condition.SearchMinuteEd = timeEd.Minute;
                // 時刻（秒）
                condition.SearchSecondSt = timeSt.Second;
                condition.SearchSecondEd = timeEd.Second;
            }
        }

        /// <summary>
        /// テキストから時刻の取得
        /// </summary>
        /// <param name="textValue">テキスト値</param>
        /// <returns>時刻</returns>
        /// <remarks>
        /// <br>Note       : テキストから時刻の取得を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private string GetTimeFromText(string textValue)
        {
            return string.IsNullOrEmpty(textValue.Trim()) ? "00" : textValue.Trim();
        }

        /// <summary>
        /// 時刻文字列⇒日付の変換
        /// </summary>
        /// <param name="now">システム日付</param>
        /// <param name="inputTime">入力時刻</param>
        /// <returns>変換後日付</returns>
        /// <remarks>
        /// <br>Note       : 時刻文字列⇒日付の変換を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private DateTime TimeStrToDateTime(DateTime now, string inputTime)
        {
            DateTime retDateTime = now;

            try
            {
                string[] time = inputTime.Split(new char[] { ':' });
                if (time != null && time.Length == 3)
                {
                    retDateTime = new DateTime(now.Year, now.Month, now.Day, int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                }
            }
            catch
            {
                retDateTime = DateTime.MinValue;
            }

            return retDateTime;
        }
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

        #endregion  // <検索条件の構築/>

        #region <列サイズの自動調整/>

        /// <summary>
        /// 列サイズの自動調整チェックボックスのCheckedChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void autoFillToGridColumnCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.operationLogGrid);
        }

        #endregion  // <列サイズの自動調整/>

        #region <文字サイズ/>

        /// <summary>
        /// 文字サイズのValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void fontSizeTComboEditor_ValueChanged(object sender, EventArgs e)
        {
            UIUtil.ChangeFontSize(this.fontSizeTComboEditor, this.operationLogGrid);
        }

        #endregion  // <文字サイズ/>

        /// <summary>
        /// コントロールのChangeFocusイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>対象コントロール：arrowKeyControl, retKeyControl, uiSetControl</br>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private void Control_ChangeFocus(
            object sender,
            Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e
        )
        {
            if (e.PrevCtrl ==  this.tEdit_EmployeeCode)
            {
                this.employeeNameTEdit.Text = UIUtil.GetEmployeeName(this.tEdit_EmployeeCode.Text.Trim());
            }

            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
            if (e.PrevCtrl != null && CanTimeCondtDisplay)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "toTDateEdit":
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    e.NextCtrl = this.tEdit_Hour; // 時刻（時）
                                    break;
                            }
                        }
                        break;
                    case "tEdit_Hour":
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    e.NextCtrl = this.toTDateEdit; // 日付終了
                                    break;
                            }
                        }
                        break;
                    case "tEdit_Second":
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    //e.NextCtrl = this.machineNameTEdit; // 端末名 // DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
                                    e.NextCtrl = this.tNedit_Hour_Ed; // 時刻（時終了）// ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
                                    break;
                                case Keys.Down:
                                    e.NextCtrl = this.tEdit_EmployeeCode; // 従業員
                                    break;
                            }
                        }
                        break;
                    //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                    case "tNedit_Hour_Ed":
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    e.NextCtrl = this.tEdit_Second; // 時刻（秒）
                                    break;
                            }
                        }
                        else
                        {

                            switch (e.Key)
                            {
                                case Keys.Down:
                                    e.NextCtrl = this.tEdit_EmployeeCode; // 従業員
                                    break;
                            }
                        }
                        break;
                    case "tNedit_Minute_Ed":
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    e.NextCtrl = this.tEdit_EmployeeCode; // 従業員
                                    break;
                            }
                        }
                        break;
                    case "tNedit_Second_Ed":
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    e.NextCtrl = this.machineNameTEdit; // 端末名
                                    break;
                                case Keys.Down:
                                    e.NextCtrl = this.employeeGuideButton; // 従業員ガイド
                                    break;
                            }
                        }
                        break;
                    //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                    case "machineNameTEdit":
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    //e.NextCtrl = this.tEdit_Second; // 時刻（秒）// DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
                                    e.NextCtrl = this.tNedit_Second_Ed; // 時刻（秒終了）// ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
                                    break;
                            }
                        }
                        break;
                }
            }
            //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

            UIUtil.UIColor.OnFocusChanged(e);
        }

        //----- ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ---->>>>>
        #region テキスト出力処理
        /// <summary>
        /// 設定情報の設定
        /// </summary>
        /// <param name="canDisplay">true:表表示 false:非表示</param>
        /// <param name="setting"> 設定情報</param>
        /// <remarks>
        /// <br>Note       : 設定情報の設定を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public void TransferSettingInfo(bool canDisplay, object setting)
        {
            this.CanTimeCondtDisplay = canDisplay;
            this.ExtractionConditionSetObj = (ExtractionConditionSet)setting;
        }

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="fileMode">ファイル形式(0:CSV 1:TXT)</param>
        /// <param name="fileCheckFlag">ファイルチェックフラグ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note        : テキスト出力処理</br>
        /// <br>Programmer	: 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        public int DoTextOut(string filePath, int fileMode, out bool fileCheckFlag, out string errMsg)
        {
            // エラーメッセージ
            errMsg = string.Empty;
            fileCheckFlag = false;

            // 初期ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // データビュー
            DataView dataView;
            try
            {
                dataView = this.CreateDataTable();

                // 検索結果がある場合
                if (dataView != null && dataView.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 検索結果ない場合
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }

                // [,]とTab変更処理
                this.StringItemProhibiticCharConvert(ref dataView, fileMode);

                // ファイルチェック
                string fileErrMsg = string.Empty;
                this.FileCheck(filePath, ref fileErrMsg);
                if (!string.IsNullOrEmpty(fileErrMsg))
                {
                    errMsg = fileErrMsg;
                    fileCheckFlag = true;
                    return status;
                }

                // テキスト出力
                status = this.TextOutPut(filePath, dataView, fileMode, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                dataView = null;
            }

            return status;
        }

        /// <summary>
        /// テーブルの作成
        /// </summary>
        /// <remarks>
        /// <returns>データビュー</returns>
        /// <br>Note        : テーブルの作成</br>
        /// <br>Programmer	: 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private DataView CreateDataTable()
        {
            // スキーマ設定
            DataTable dt = new DataTable();
            DataView dataView = new DataView();

            // 日付
            dt.Columns.Add(ct_Col_Date, typeof(String));
            dt.Columns[ct_Col_Date].DefaultValue = string.Empty;
            dt.Columns[ct_Col_Date].Caption = "日付";
            // 時刻
            dt.Columns.Add(ct_Col_Time, typeof(String));
            dt.Columns[ct_Col_Time].DefaultValue = string.Empty;
            dt.Columns[ct_Col_Time].Caption = "時刻";
            // 拠点
            dt.Columns.Add(ct_Col_SectionName, typeof(String));
            dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_SectionName].Caption = "拠点";
            // 端末
            dt.Columns.Add(ct_Col_MachineName, typeof(String));
            dt.Columns[ct_Col_MachineName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_MachineName].Caption = "端末";
            // 職種
            dt.Columns.Add(ct_Col_JobTypeName, typeof(String));
            dt.Columns[ct_Col_JobTypeName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_JobTypeName].Caption = "職種";
            // 雇用形態
            dt.Columns.Add(ct_Col_EmployMentFormName, typeof(String));
            dt.Columns[ct_Col_EmployMentFormName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_EmployMentFormName].Caption = "雇用形態";
            // 従業員
            dt.Columns.Add(ct_Col_EmployeeName, typeof(String));
            dt.Columns[ct_Col_EmployeeName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_EmployeeName].Caption = "従業員";
            // カテゴリ
            dt.Columns.Add(ct_Col_CategoryName, typeof(String));
            dt.Columns[ct_Col_CategoryName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_CategoryName].Caption = "カテゴリ";
            // 機能
            dt.Columns.Add(ct_Col_PgName, typeof(String));
            dt.Columns[ct_Col_PgName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_PgName].Caption = "機能";
            // 操作
            dt.Columns.Add(ct_Col_OperationName, typeof(String));
            dt.Columns[ct_Col_OperationName].DefaultValue = string.Empty;
            dt.Columns[ct_Col_OperationName].Caption = "操作";
            // メッセージ
            dt.Columns.Add(ct_Col_Message, typeof(String));
            dt.Columns[ct_Col_Message].DefaultValue = string.Empty;
            dt.Columns[ct_Col_Message].Caption = "メッセージ";

            // テキスト出力用データテーブル作成
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.operationLogGrid.Rows)
            {
                // 新規行
                DataRow dataRow = dt.NewRow();

                // 日付
                dataRow[ct_Col_Date] = row.Cells[ct_Col_Date].Value;
                // 時刻
                dataRow[ct_Col_Time] = row.Cells[ct_Col_Time].Value;
                // 拠点
                dataRow[ct_Col_SectionName] = row.Cells[ct_Col_SectionName].Value;
                // 端末
                dataRow[ct_Col_MachineName] = row.Cells[ct_Col_MachineName].Value;
                // 職種
                dataRow[ct_Col_JobTypeName] = row.Cells[ct_Col_JobTypeName].Value;
                // 雇用形態
                dataRow[ct_Col_EmployMentFormName] = row.Cells[ct_Col_EmployMentFormName].Value;
                // 従業員
                dataRow[ct_Col_EmployeeName] = row.Cells[ct_Col_EmployeeName].Value;
                // カテゴリ
                dataRow[ct_Col_CategoryName] = row.Cells[ct_Col_CategoryName].Value;
                // 機能
                dataRow[ct_Col_PgName] = row.Cells[ct_Col_PgName].Value;
                // 操作
                dataRow[ct_Col_OperationName] = row.Cells[ct_Col_OperationName].Value;
                // メッセージ
                dataRow[ct_Col_Message] = row.Cells[ct_Col_Message].Value;

                // 行追加
                dt.Rows.Add(dataRow);
            }

            // データビュー作成
            dataView = dt.DefaultView;
            return dataView;
        }

        #region ファイルチェック処理
        /// <summary>
        /// ファイルチェック処理を行う
        /// </summary>
        /// <param name="filePath">出力パス</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : ファイルチェック処理を行う</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool FileCheck(string filePath, ref string errMessage)
        {
            bool status = true;

            // ファイル排他チェック
            // message: 指定されたファイルが他で使用中です。
            if (PMKHN09140UA.IsFileLocked(filePath.Trim()) == 1)
            {
                errMessage = string.Format("{0}", CT_FILEALRDYERROR);
                status = false;
                return status;
            }
            // message: 出力先ファイルへのアクセスが拒否されました。
            else if (PMKHN09140UA.IsFileLocked(filePath.Trim()) == 2 || PMKHN09140UA.IsFileLocked(filePath.Trim()) == 3)
            {
                errMessage = string.Format("{0}", CT_FILEACCESSERROR);
                status = false;
                return status;
            }
            else
            {
                // なし
            }
            return status;
        }

        /// <summary>
        /// ファイル使用中チェック
        /// </summary>
        /// <param name="fileNm">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 指定ファイルが使用中かどうかをチェックする</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public static int IsFileLocked(string fileNm)
        {
            FileStream stream = null;

            // ﾌｧｲﾙが存在しない場合、ﾃｷｽﾄ出力時に作成している
            if (!File.Exists(fileNm))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                stream = File.Open(fileNm, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;
        }

        /// <summary>
        /// ファイル使用状態フラグ列挙体
        /// </summary>
        /// <remarks>
        /// <br>Note       : ファイル使用状態フラグ</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private enum FileLocked_Status
        {
            // ファイルは使用できる
            FileLocked_NORMAL = 0,
            // ファイルが他で使用中です
            FileLocked_LOCKED = 1,
            // ファイルがアクセスできない。
            FileLocked_CANNOTACCESS = 2,
            // その他エラー
            FileLocked_EOF = 3,
        }
        #endregion

        /// <summary>
        /// 文字列項目の特定文字変換
        /// </summary>
        /// <param name="dataView">データテーブル</param>
        /// <param name="fileMode">ファイル形式(0:CSV 1:TXT)</param>
        /// <remarks>
        /// <br>Note        : データテーブル中の文字列項目内に含まれる特定文字の変換を行う。</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private void StringItemProhibiticCharConvert(ref DataView dataView, int fileMode)
        {
            foreach (DataRow row in dataView.Table.Rows)
            {
                // 拠点名称
                row["SectionName"] = ProhibiticCharConvert(row["SectionName"].ToString(), fileMode);
                // 従業員名称
                row["EmployeeName"] = ProhibiticCharConvert(row["EmployeeName"].ToString(), fileMode);
                // メッセージ
                row["Message"] = ProhibiticCharConvert(row["Message"].ToString(), fileMode);
            }
        }

        /// <summary>
        /// 文字列の変換
        /// </summary>
        /// <param name="str">インプット文字列</param>
        /// <param name="fileMode">ファイル形式(0:CSV 1:TXT)</param>
        /// <returns>変換後の文字列</returns>
        /// <remarks>
        /// <br>Note        : 文字列の変換を行う。</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        public string ProhibiticCharConvert(string str, int fileMode)
        {
            // 変更後文字列
            string retStr = str;

            // 変更元記号
            string beforeStr = string.Empty;

            // 変更先記号
            string afterStr = string.Empty;

            switch (fileMode)
            { 
                case 0:
                    beforeStr = CSVSTR;
                    afterStr = TXTSTR;
                    break;
                case 1:
                    beforeStr = TXTSTR;
                    afterStr = CSVSTR;
                    break;
            }

            if (str.Contains(beforeStr))
            {
                retStr = str.Replace(beforeStr, afterStr);
            }

            return retStr;
        }

        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="fileName">出力ファイル名</param>
        /// <param name="dataView">データビュー</param>
        /// <param name="fileMode">ファイル形式(0:CSV 1:TXT)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note        : CSV出力処理</br>
        /// <br>Programmer	: 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private int TextOutPut(string fileName, DataView dataView, int fileMode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;
            int exportCount = 0;
            FormattedTextWriter formattedTextWriter = new FormattedTextWriter();

            try
            {
                // 出力項目名
                List<string> schemeList = new List<string>();

                // 日付
                schemeList.Add(ct_Col_Date);
                // 時刻
                schemeList.Add(ct_Col_Time);
                // 拠点
                schemeList.Add(ct_Col_SectionName);
                // 端末
                schemeList.Add(ct_Col_MachineName);
                // 職種
                schemeList.Add(ct_Col_JobTypeName);
                // 雇用形態
                schemeList.Add(ct_Col_EmployMentFormName);
                // 従業員
                schemeList.Add(ct_Col_EmployeeName);
                // カテゴリ
                schemeList.Add(ct_Col_CategoryName);
                // 機能
                schemeList.Add(ct_Col_PgName);
                // 操作
                schemeList.Add(ct_Col_OperationName);
                // メッセージ
                schemeList.Add(ct_Col_Message);

                // 項目括り適用
                String typeStr = string.Empty;

                List<Type> enclosingTypeList = new List<Type>();

                // データソース
                formattedTextWriter.DataSource = dataView;
                formattedTextWriter.DataMember = String.Empty;
                // ファイル名
                formattedTextWriter.OutputFileName = fileName;

                //テキスト出力する項目名のリスト
                formattedTextWriter.SchemeList = schemeList;
                // 区切り文字
                if (fileMode == 0)
                {
                    formattedTextWriter.Splitter = CSVSTR;
                }
                else
                {
                    formattedTextWriter.Splitter = TXTSTR;
                }
                // 項目括り文字
                formattedTextWriter.Encloser = "";
                formattedTextWriter.EnclosingTypeList = enclosingTypeList;
                formattedTextWriter.FormatList = null;
                // タイトル行出力
                formattedTextWriter.CaptionOutput = true;
                // 固定幅
                formattedTextWriter.FixedLength = false;
                formattedTextWriter.ReplaceList = null;

                status = formattedTextWriter.TextOut(out exportCount);
            }
            catch (Exception e)
            {
                errMsg = e.Message + e.StackTrace;
            }
            finally
            {
                formattedTextWriter = null;
            }

            return status;
        }
        #endregion

        #region Private メソッド
        /// <summary>
        /// 時刻のチェック
        /// </summary>
        /// <param name="inputTime">入力の時刻（XX:XX:XX）</param>
        /// <param name="outHour">戻る時</param>
        /// <param name="outMinute">戻る分</param>
        /// <param name="outSecond">戻る秒</param>
        /// <returns>チェック結果（True:OK False:NG）</returns>
        /// <remarks>
        /// <br>Note       : 時刻のチェックを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        //private bool CheckTime(string inputTime, out string outTime) // DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
        private bool CheckTime(string inputTime, out int outHour, out int outMinute, out int outSecond)  // ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
        {
            bool isOK = false;
            //outTime = string.Empty; // DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            outHour = MINTIME;
            outMinute = MINTIME;
            outSecond = MINTIME;
            //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<

            if (!string.IsNullOrEmpty(inputTime))
            {
                string[] time = inputTime.Split(new char[] { ':' });
                if (time != null && time.Length == 3)
                {
                    string hourStr = time[0];
                    string minuteStr = time[1];
                    string secondStr = time[2];

                    // 時のチェック
                    isOK = CheckTime(hourStr, 0);
                    // 分のチェック
                    if (isOK)
                    {
                        isOK = CheckTime(minuteStr, 1);
                    }
                    // 秒のチェック
                    if (isOK)
                    {
                        isOK = CheckTime(secondStr, 2);
                    }

                    if (isOK)
                    {
                        //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                        //outTime = string.Format("{0}:{1}:{2}", 
                        //    hourStr.PadLeft(2, '0'),
                        //    minuteStr.PadLeft(2, '0'),
                        //    secondStr.PadLeft(2, '0'));
                        //----- DEL 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                        int.TryParse(hourStr, out outHour);
                        int.TryParse(minuteStr, out outMinute);
                        int.TryParse(secondStr, out outSecond);

                        int totalSeconds = outHour * HSEC + outMinute * MSEC + outSecond;
                        if (totalSeconds <= NIGHTHOUR * HSEC)
                        {
                            // 夜間の「00:00:00～06:00:00」について、「24:00:00～30:00:00」と時刻を表記します。
                            outHour += ONEDAYHOUR;
                        }
                        //----- ADD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                    }
                }
            }

            return isOK;
        }

        /// <summary>
        /// 時刻のチェック
        /// </summary>
        /// <param name="timeStr">入力の時刻(時/分/秒)</param>
        /// <param name="mode">モード（0:時 1:分 2:秒）</param>
        /// <returns>チェック結果（True:OK False:NG）</returns>
        /// <remarks>
        /// <br>Note       : 時刻のチェックを行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool CheckTime(string timeStr, int mode)
        {
            bool isOK = false;
            int timeInt = 0;

            if (string.IsNullOrEmpty(timeStr.Trim()))
            {
                isOK = true;
            }
            else
            {
                switch (mode)
                {
                    case 0: // 時のチェック
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            // --- UPD テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                            //if (timeInt >= 0 && timeInt <= 23)
                            if (timeInt >= MINTIME && timeInt <= INPUTMAXHOUR)
                            // --- UPD テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
                            {
                                isOK = true;
                            }
                        }
                        break;
                    case 1: // 分のチェック
                    case 2: // 秒のチェック
                        if (int.TryParse(timeStr, out timeInt))
                        {
                            if (timeInt >= 0 && timeInt <= 59)
                            {
                                isOK = true;
                            }
                        }
                        break;
                    default:
                        isOK = false;
                        break;
                }
            }

            return isOK;
        }

        /// <summary>
        /// 時刻からフォーカスアウトの処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 操時刻からフォーカスアウトの処理を行う。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void tEdit_Leave(object sender, EventArgs e)
        {
            if (sender is Broadleaf.Library.Windows.Forms.TEdit)
            {
                Broadleaf.Library.Windows.Forms.TEdit textBox = (Broadleaf.Library.Windows.Forms.TEdit)sender;
                if (string.IsNullOrEmpty(textBox.Text.Trim()))
                {
                    textBox.Text = "00";
                }
                else
                {
                    textBox.Text = textBox.Text.PadLeft(2, '0');
                }
            }
        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 画面をロードしタイマーを起動する。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            // 文字サイズ
            UIUtil.InitializeFontSizeUI(this.fontSizeTComboEditor);

            // 列幅自動調整
            this.autoFillToGridColumnCheckEditor.Checked = true;
            UIUtil.DoAutoFillToGridColumn(this.autoFillToGridColumnCheckEditor, this.operationLogGrid);

            // 操作ログ
            InitializeOperationLogGrid();
        }
        #endregion
        //----- ADD 時シン K2016/10/28 神姫産業㈱ テキスト出力機能追加対応 ----<<<<<
    }

    //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
    /// <summary>
    /// 操作履歴抽出条件関連設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 操作履歴抽出条件関連設定クラス。</br>
    /// <br>Programmer : 時シン</br>
    /// <br>Date       : K2016/10/28</br>
    /// </remarks>
    public class ExtractionConditionSet
    {
        /// <summary>深夜時間帯終了時間</summary>
        private string LatenightTimezoneEndField = string.Empty;
        /// <summary>抽出上限</summary>
        private string EndTimeField = string.Empty;

        /// <summary>
        /// 深夜時間帯終了時間
        /// </summary>
        public string LatenightTimezoneEnd
        {
            get { return this.LatenightTimezoneEndField; }
            set { this.LatenightTimezoneEndField = value; }
        }

        /// <summary>
        /// 抽出上限
        /// </summary>
        public string EndTime
        {
            get { return this.EndTimeField; }
            set { this.EndTimeField = value; }
        }
    }
    //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
}
