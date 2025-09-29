//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）ビュー
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成（SFCMN09200Uを移植およびアレンジ）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms.Other
{
    using DataTableType     = ServerPrinterSettingDataSet.SrvPrtStDataTable;
    using PrinterProfileType= Dictionary<string, object>;
    using PrinterProfileMap = Dictionary<string, Dictionary<string, object>>;

    /// <summary>
    /// プリンタ設定マスタ（サーバ用）入力フォーム
    /// </summary>
    public partial class PrtManageForm : Form
    {
        #region <Controller>

        /// <summary>プリンタ設定マスタ（サーバ用）コントローラ</summary>
        private readonly ServerPrinterSettingController _myController;
        /// <summary>プリンタ設定マスタ（サーバ用）コントローラを取得します。</summary>
        private ServerPrinterSettingController MyController { get { return _myController; } }

        /// <summary>企業コードを取得します。</summary>
        private string EnterpriseCode
        {
            get { return MyController.EnterpriseCode; }
        }

        #endregion // </Controller>

        #region <編集モード>

        /// <summary>
        /// 編集モード列挙型
        /// </summary>
        public enum EditMode : int
        {
            /// <summary>新規</summary>
            New,
            /// <summary>更新</summary>
            Update,
            /// <summary>削除</summary>
            Delete
        }

        /// <summary>
        /// 編集モード名称を取得します。
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <returns>
        /// <c>EditMode.New</c>   :新規モード<br/>
        /// <c>EditMode.Update</c>:更新モード<br/>
        /// <c>EditMode.Delete</c>:削除モード<br/>
        /// それ以外は ？？モード を返します。
        /// </returns>
        private static string GetEditModeName(EditMode editMode)
        {
            switch (editMode)
            {
                case EditMode.New:
                    return "新規モード";    // LITERAL:
                case EditMode.Update:
                    return "更新モード";    // LITERAL:
                case EditMode.Delete:
                    return "削除モード";    // LITERAL:
                default:
                    return "？？モード";    // LITERAL:
            }
        }

        /// <summary>現在の編集モード</summary>
        private EditMode _currentEditMode;
        /// <summary>現在の編集モードを取得および設定します。</summary>
        private EditMode CurrentEditMode
        {
            get { return _currentEditMode; }
            set { _currentEditMode = value; }
        }

        #endregion // </編集モード>

        /// <summary>プリンタ情報のマップ</summary>
        private readonly PrinterProfileMap _printerMap = new PrinterProfileMap();
        /// <summary>プリンタ情報のマップを取得します。</summary>
        private PrinterProfileMap PrinterMap { get { return _printerMap; } }

        /// <summary>起動時のプリンタ設定内容</summary>
        private PrtManage _initialPrtManage;
        /// <summary>起動時のプリンタ設定内容を取得および設定します。</summary>
        private PrtManage InitialPrtManage
        {
            get { return _initialPrtManage; }
            set { _initialPrtManage = value; }
        }

        /// <summary>新規プリンタ管理No</summary>
        public const int NONE_PRINTER_MNG_NO = ServerPrinterSettingController.NULL_PRINTER_MNG_NO;

        /// <summary>現在のプリンタ管理No</summary>
        private int _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
        /// <summary>現在のプリンタ管理番号を取得または設定します。</summary>
        private int CurrentPrinterMngNo
        {
            get { return _currentPrinterMngNo; }
            set { _currentPrinterMngNo = value; }
        }

        /// <summary>プログラムID</summary>
        private const string PG_ID = "PMKHN09581U";

        #region <Constractor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="myController">コントローラ</param>
        /// <param name="editMode">編集モード</param>
        public PrtManageForm(
            ServerPrinterSettingController myController,
            EditMode editMode
        ) : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _myController = myController;
            if (myController.DoingRecord != null)
            {
                _currentPrinterMngNo = myController.DoingRecord.PrinterMngNo;
            }
            else
            {
                _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
            }
            _currentEditMode = editMode;

            // 新規モードの場合、強制的にプリンタ管理Noを設定
            if (editMode.Equals(EditMode.New))
            {
                _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
            }
        }

        #endregion // <Constractor>

        #region <初期化>

        /// <summary>
        /// プリンタ設定マスタ（サーバ用）入力フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void PrtManageForm_Load(object sender, System.EventArgs e)
        {
            Cursor previousCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 画面を初期化
                InitializeFormControls();
                InitializeFormByMode();
            }
            finally
            {
                Cursor.Current = previousCursor;
            }
        }

        /// <summary>
        /// 画面を初期化します。
        /// </summary>
        private void InitializeFormControls()
        {
            // プリンター情報をWIN32のクエリを使って取得
            ManagementObjectSearcher mngObjSearcher = new ManagementObjectSearcher("Select * from Win32_Printer");
            ManagementObjectCollection mngObjCollection = mngObjSearcher.Get();

            // プリンタ名コンボボックスを初期化
            this.cboPrinterName.Items.Clear();
            if (mngObjCollection.Count > 0) this.cboPrinterName.Items.Add(string.Empty);
            foreach (ManagementObject mngObj in mngObjCollection)
            {
                // プリンタ情報
                PrinterProfileType printerProfile = new PrinterProfileType();
                {
                    printerProfile.Add("Name",      mngObj["Name"]);    // 名称
                    printerProfile.Add("Status",    mngObj["Status"]);  // 状態
                    printerProfile.Add("PortName",  mngObj["PortName"]);// ポート番号

                    #region <参考>

                    printerProfile.Add("Caption",       mngObj["Caption"]);     // キャプション
                    printerProfile.Add("Description",   mngObj["Description"]); // ディスクリプション
                    printerProfile.Add("DeviceID",      mngObj["DeviceID"]);    // ドライバID
                    printerProfile.Add("DriverName",    mngObj["DriverName"]);  // ドライバ名称
                    printerProfile.Add("Location",      mngObj["Location"]);    // 場所
                    printerProfile.Add("PrinterState",  mngObj["PrinterState"]);// プリンタ状態
                    printerProfile.Add("SeverName",     mngObj["ServerName"]);  // サーバー名称
                    printerProfile.Add("ShareName",     mngObj["ShareName"]);   // 共有名称
                    printerProfile.Add("StatusInfo",    mngObj["StatusInfo"]);  // 状態情報

                    #endregion // </参考>

                    // プリンタ情報を保持
                    PrinterMap.Add((string)mngObj["Name"], printerProfile);

                    this.cboPrinterName.Items.Add((string)mngObj["Name"]);
                }
            }

            #region <参考>
            
            //				// デフォルトのプリンタか調べる
            //				if ((((uint) mo["Attributes"]) & 4) == 4)
            //				{
            //					// コンボのTextにデフォルトのプリンタ名を表示
            //					PrinterName_tComboEditor.Text = mo["Name"].ToString();
            //				}
            
            #endregion // </参考>

            // プリンタ種別コンボボックスを初期化
            this.cboPrinterKind.Items.Clear();
            if (this.cboPrinterName.Items.Count > 0)
            {
                foreach (string printerKindName in ServerPrinterSettingDataSet.GetPrinterKindNameList())
                {
                    this.cboPrinterKind.Items.Add(printerKindName);
                }
                this.cboPrinterKind.SelectedIndex = 0;  // 先頭を選択
            }

            // ボタンの位置を調整（[閉じる]ボタンの画面デザインの位置から計算）
            Point buttonLocation = this.btnClose.Location;
            buttonLocation.X -= this.btnClose.Size.Width;
            this.btnSave.Location = buttonLocation;         // [保存]ボタン
            this.btnRevive.Location = buttonLocation;       // [復活]ボタン
            buttonLocation.X -= this.btnClose.Size.Width;
            this.btnDestroy.Location = buttonLocation;      // [完全削除]ボタン
        }

        /// <summary>
        /// モードに基づいて画面を初期化します。
        /// </summary>
        private void InitializeFormByMode()
        {
            this.lblEditMode.Text = GetEditModeName(CurrentEditMode);

            // 新規モード
            if (CurrentEditMode.Equals(EditMode.New))
            {
                this.btnSave.Visible    = true; // [保存]ボタン
                this.btnClose.Visible   = true; // [閉じる]ボタン
                this.btnDestroy.Visible = false;// [完全削除]ボタン
                this.btnRevive.Visible  = false;// [復活]ボタン

                SetEnabledOfFormControls(true);

                InitialPrtManage = new PrtManage();
                SetFormControls(InitialPrtManage);

                this.txtPrinterMngNo.Focus();   // プリンタ管理No
                return;
            }

            // 更新モード／削除モード
            PrtManage foundPrtManage = MyController.Find(CurrentPrinterMngNo);
            if (foundPrtManage != null)
            {
                InitialPrtManage = foundPrtManage.Clone();
                SetFormControls(InitialPrtManage);
            }
            else
            {
                Debug.Assert(false, "該当するプリンタ設定がありません：" + CurrentPrinterMngNo.ToString());
            }

            // 更新モード
            if (!EntityUtil.Deleted(InitialPrtManage))
            {
                this.btnSave.Visible    = true; // [保存]ボタン
                this.btnClose.Visible   = true; // [閉じる]ボタン
                this.btnDestroy.Visible = false;// [完全削除]ボタン
                this.btnRevive.Visible  = false;// [復活]ボタン

                SetEnabledOfFormControls(true);

                // 更新モードの場合は、プリンタ管理コードのみ入力不可とする
                this.txtPrinterMngNo.Enabled = false;

                this.cboPrinterName.Focus();    // プリンタ名

                CurrentEditMode = EditMode.Update;
                return;
            }

            // 削除モード
            this.lblEditMode.Text = GetEditModeName(EditMode.Delete);

            this.btnSave.Visible    = false;// [保存]ボタン
            this.btnClose.Visible   = true; // [閉じる]ボタン
            this.btnDestroy.Visible = true; // [完全削除]ボタン
            this.btnRevive.Visible  = true; // [復活]ボタン

            SetEnabledOfFormControls(false);

            this.btnDestroy.Focus();    // [完全削除]ボタン

            CurrentEditMode = EditMode.Delete;
        }

        /// <summary>
        /// 画面の有効フラグを設定します。
        /// </summary>
        /// <param name="enabled">有効フラグ</param>
        private void SetEnabledOfFormControls(bool enabled)
        {
            this.txtPrinterMngNo.Enabled= enabled;  // プリンタ管理No
            this.cboPrinterName.Enabled = enabled;  // プリンタ名
            this.cboPrinterKind.Enabled = enabled;  // プリンタ種別
        }

        #endregion // </初期化>

        #region <プリンタ設定データ>

        /// <summary>
        /// 画面の入力情報からプリンタ設定データを生成します。
        /// </summary>
        /// <returns>プリンタ設定データ</returns>
        private PrtManage CreatePrtManageFromFormInput()
        {
            PrtManage prtManage = new PrtManage();
            {
                // 企業コード
                prtManage.EnterpriseCode = EnterpriseCode;
                // プリンタ管理No
                if (string.IsNullOrEmpty(this.txtPrinterMngNo.Text.Trim()))
                {
                    prtManage.PrinterMngNo = 0;
                }
                else
                {
                    prtManage.PrinterMngNo = int.Parse(this.txtPrinterMngNo.Text.Trim());
                }
                prtManage.PrinterName = this.cboPrinterName.Text.Trim();    //プリンタ名
                prtManage.PrinterPort = this.txtPrinterPort.Text.Trim();    //プリンタポート（パス）
                // プリンタ種別
                prtManage.PrinterKind = ServerPrinterSettingDataSet.GetPrinterKind(this.cboPrinterKind.Text);
            }
            return prtManage;
        }

        /// <summary>
        /// プリンタ設定データを画面に設定します。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        private void SetFormControls(PrtManage prtManage)
        {
            this.lblGUID.Text = prtManage.FileHeaderGuid.ToString();

            // プリンタ管理No
            if (prtManage.PrinterMngNo <= 0)
            {
                this.txtPrinterMngNo.Text = string.Empty;
            }
            else
            {
                this.txtPrinterMngNo.Text = prtManage.PrinterMngNo.ToString();
            }
            this.cboPrinterName.SelectedItem= prtManage.PrinterName;    // プリンタ名
            this.txtPrinterPort.Text        = prtManage.PrinterPort;    // プリンタパス

            // プリンタ種別
            this.cboPrinterKind.SelectedItem= ServerPrinterSettingDataSet.GetPrinterKindName(prtManage.PrinterKind);
        }

        #endregion // </プリンタ設定データ>

        #region <プリンタ管理Noの入力操作>

        /// <summary>
        /// [プリンタ管理No]テキストボックスのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void txtPrinterMngNo_Leave(object sender, EventArgs e)
        {
            int printerMngNo = EntityUtil.ConvertNaturalNumberIf(this.txtPrinterMngNo.Text);
            if (printerMngNo <= 0)
            {
                Debug.WriteLine("不正なプリンタ管理Noです：" + this.txtPrinterMngNo.Text);
                return;
            }

            // 新規モード→更新モード／削除モード
            if (!CurrentEditMode.Equals(EditMode.New)) return;

            PrtManage foundPrtManage = MyController.Find(printerMngNo);
            if (foundPrtManage != null)
            {
                CurrentPrinterMngNo = printerMngNo;
                CurrentEditMode = ShowAlertOfChangingMode(foundPrtManage);
                InitializeFormByMode();
            }
        }

        /// <summary>
        /// モード変更のアラートを表示します。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        /// <returns>編集モード</returns>
        private EditMode ShowAlertOfChangingMode(PrtManage prtManage)
        {
            if (EntityUtil.Deleted(prtManage))
            {
                TMsgDisp.Show(
                    this, 					        // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                    PG_ID,						    // アセンブリＩＤまたはクラスID
                    "入力されたコードのプリンタ設定情報は既に削除されています。",   // LITERAL:表示するメッセージ
                    0, 								// ステータス値
                    MessageBoxButtons.OK            // 表示するボタン
                );
                return EditMode.Delete;
            }

            DialogResult result = TMsgDisp.Show(
                this,                           // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,    // エラーレベル
                PG_ID,                          // アセンブリIDまたはクラスID
                "入力されたコードのプリンタ設定情報が既に登録されています。\n編集を行いますか？",   // LITERAL:表示するメッセージ
                0,                              // ステータス値
                MessageBoxButtons.YesNo // 表示するボタン
            );
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        return EditMode.Update;
                    }
                case DialogResult.No:
                    {
                        CurrentPrinterMngNo = NONE_PRINTER_MNG_NO;
                        return EditMode.New;
                    }
            }

            return CurrentEditMode;
        }

        #endregion // </プリンタ管理Noの入力操作>

        #region <プリンタ名の入力操作>

        /// <summary>
        /// プリンタ名コンボボックスのValueChangedイベントハンドラ
        /// </summary>
        /// <remarks>
        /// プリンタ名を選択した時、プリンタポートを表示します。
        /// </remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void cboPrinterName_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboPrinterName.Text)) return;

            if (PrinterMap.ContainsKey(this.cboPrinterName.Text))
            {
                PrinterProfileType printerProfile = PrinterMap[this.cboPrinterName.Text];
                {
                    this.txtPrinterPort.Text = (string)printerProfile["PortName"];
                }
            }
        }

        #endregion // </プリンタ名の入力操作>

        #region <閉じる操作>

        /// <summary>
        /// [閉じる]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 編集中なら登録確認を表示
            Control nextControl = null;
            Control nowFocusd = this.ActiveControl;
            if (!CanClose(out nextControl))
            {
                if (nextControl == null)
                {
                    nowFocusd.Focus();
                }
                else
                {
                    nextControl.Focus();
                }
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 終了可能か判断します。
        /// </summary>
        /// <remarks>
        /// 編集中なら登録確認を行います。
        /// </remarks>
        /// <param name="nextControl">登録チェックNG時のフォーカス移動先</param>
        /// <returns>
        /// <c>true</c> :終了可<br/>
        /// <c>false</c>:終了不可
        /// </returns>
        private bool CanClose(out Control nextControl)
        {
            nextControl = null;

            // 入力状態を取得
            PrtManage inputedPrtManage = CreatePrtManageFromFormInput();

            // 入力状態を初期状態と比較
            if (!IsSameInput(InitialPrtManage, inputedPrtManage))
            {
                // 編集中
                switch (TMsgDisp.Show(
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_QUESTION,
                    PG_ID,
                    "編集中のデータが存在します\r\n\r\n登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo
                ))
                {
                    case DialogResult.Yes:
                        return RegistData(out nextControl); // 登録する
                    default:
                        return true;    // 閉じる
                }
            }
            return true;
        }

        /// <summary>
        /// 同じ入力データであるか判断します。
        /// </summary>
        /// <param name="prtManage1">プリンタ設定データ1</param>
        /// <param name="prtManage2">プリンタ設定データ2</param>
        /// <returns>
        /// <c>true</c> :同じ入力データです。<br/>
        /// <c>false</c>:同じ入力データではありません。
        /// </returns>
        private static bool IsSameInput(
            PrtManage prtManage1,
            PrtManage prtManage2
        )
        {
            #region <Guard Phrase>

            if (prtManage1 == null && prtManage2 == null)
            {
                return true;
            }

            if (!(prtManage1 != null && prtManage2 != null))
            {
                return false;
            }

            #endregion // </Guard Phrase>

            // プリンタ管理No
            if (!prtManage1.PrinterMngNo.Equals(prtManage2.PrinterMngNo))
            {
                return false;
            }
            // プリンタ名
            if (!prtManage1.PrinterName.Trim().Equals(prtManage2.PrinterName.Trim()))
            {
                return false;
            }
            // プリンタ種別
            if (!prtManage1.PrinterKind.Equals(prtManage2.PrinterKind))
            {
                return false;
            }
            return true;
        }

        #endregion // </閉じる操作>

        #region <保存操作>

        /// <summary>
        /// [保存]ボタンのClickイベントイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Control errorControl = null;
            if (!RegistData(out errorControl))
            {
                if (errorControl != null) errorControl.Focus();
                return;
            }

            // 新規登録モードの場合は画面を終了せずに連続入力を可能とする
            if (CurrentEditMode.Equals(EditMode.New))
            {
                CurrentPrinterMngNo = NONE_PRINTER_MNG_NO;
                InitializeFormByMode();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// プリンタ設定データを登録します。
        /// </summary>
        /// <param name="errorControl">不正な入力を持つコントロール ※無ければ、<c>null</c>を返します。</param>
        /// <returns>
        /// <c>true</c> :登録に成功<br/>
        /// <c>false</c>:登録に失敗
        /// </returns>
        private bool RegistData(out Control errorControl)
        {
            errorControl = null;

            // 入力チェック
            string message = string.Empty;
            if (!ValidatesInputData(ref errorControl, out message))
            {
                TMsgDisp.Show(
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PG_ID,
                    message,
                    0,
                    MessageBoxButtons.OK
                );
                return false;
            }

            PrtManage writingPrtManage = GetDoingPrtManage();

            MyController.DoingRecord = writingPrtManage;
            MyController.WriteRecord();

            int status = MyController.DoneStatus;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        return true;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PG_ID,
                            "このプリンタ管理コードは既に使用されています。",
                            status,
                            MessageBoxButtons.OK
                        );
                        errorControl = this.txtPrinterMngNo;
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "プリンタ管理情報設定",
                            "RegistData",
                            TMsgDisp.OPE_UPDATE,
                            "読み込みに失敗しました。",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        this.Close();
                        return false;
                    }
            }
        }

        /// <summary>
        /// 処理するプリンタ設定データを取得します。
        /// </summary>
        /// <returns>
        /// 新規モードの場合、新たに生成したデータに画面入力データを反映したもの<br/>
        /// それ以外は、既存のデータに画面入力データを反映したもの
        /// </returns>
        private PrtManage GetDoingPrtManage()
        {
            PrtManage writingPrtManage = null;
            {
                PrtManage inputedPrtManage = CreatePrtManageFromFormInput();
                if (CurrentEditMode.Equals(EditMode.New))
                {
                    writingPrtManage = inputedPrtManage;
                }
                else
                {
                    writingPrtManage = MyController.Find(CurrentPrinterMngNo);
                    if (writingPrtManage != null)
                    {
                        writingPrtManage.PrinterMngNo= inputedPrtManage.PrinterMngNo;
                        writingPrtManage.PrinterName = inputedPrtManage.PrinterName;
                        writingPrtManage.PrinterPort = inputedPrtManage.PrinterPort;
                        writingPrtManage.PrinterKind = inputedPrtManage.PrinterKind;
                    }
                    else
                    {
                        Debug.Assert(false, "DBに存在しない？");
                    }
                }
            }
            return writingPrtManage;
        }

        /// <summary>
        /// 画面入力データが正しいか判断します。
        /// </summary>
        /// <param name="errorControl">不正対象コントロール</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>
        /// <c>true</c> :正しい<br/>
        /// <c>false</c>:正しくない
        /// </returns>
        private bool ValidatesInputData(
            ref Control errorControl,
            out string errorMessage
        )
        {
            errorMessage = string.Empty;

            // プリンタ管理No
            int printerMngNo = EntityUtil.ConvertNaturalNumberIf(this.txtPrinterMngNo.Text);
            if (printerMngNo <= 0)
            {
                errorControl = this.txtPrinterMngNo;
                errorMessage = this.lblPrinterMngNo.Text + "は 1以上 の値を入力して下さい。";
                return false;
            }

            PrtManage foundPrtManage = MyController.Find(printerMngNo);
            if (foundPrtManage != null)
            {
                if (CurrentEditMode.Equals(EditMode.New))
                {
                    errorControl = this.txtPrinterMngNo;
                    errorMessage = "このプリンタ管理コードは既に使用されています。";
                    return false;
                }
            }

            // プリンタ名
            if (string.IsNullOrEmpty(this.cboPrinterName.Text))
            {
                errorControl = this.cboPrinterName;
                errorMessage = this.lblPrinterName.Text + "を入力して下さい。";
                return false;
            }

            // プリンタ種別
            if (string.IsNullOrEmpty(this.cboPrinterKind.Text.Trim()))
            {
                errorControl = this.cboPrinterKind;
                errorMessage = this.lblPrinterKind.Text + "を入力して下さい。";
                return false;
            }

            // 重複チェック
            int foundPrinterMngNo = 0;
            if (MyController.Exists(this.cboPrinterName.Text.Trim(), out foundPrinterMngNo))
            {
                // 自身の情報でなければエラー
                if (!foundPrinterMngNo.Equals(printerMngNo))
                {
                    errorControl = this.cboPrinterName;
                    errorMessage = "同じプリンタは登録できません";
                    return false;
                }
            }

            return true;
        }

        #endregion // </保存操作>

        #region <復活操作>

        /// <summary>
        /// [復活]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnRevive_Click(object sender, EventArgs e)
        {
            PrtManage revivingPrtManage = GetDoingPrtManage();

            MyController.DoingRecord = revivingPrtManage;
            MyController.ReviveRecord();

            int status = MyController.DoneStatus;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "プリンタ管理情報設定",
                            "Revive_Button_Click",
                            TMsgDisp.OPE_UPDATE,
                            "既にデータが完全削除されています。",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "プリンタ管理情報設定",
                            "Revive_Button_Click",
                            TMsgDisp.OPE_UPDATE,
                            "復活に失敗しました。",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        this.Close();
                        break;
                    }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion // </復活操作>

        #region <完全削除操作>

        /// <summary>
        /// [完全削除]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnDestroy_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                PG_ID,
                "データを削除します。" + "\r\n" + "よろしいですか？",
                0,
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2
            );
            if (result.Equals(DialogResult.OK))
            {
                PrtManage destroyingPrtManage = GetDoingPrtManage();

                MyController.DoingRecord = destroyingPrtManage;
                MyController.DestroyRecord();

                int status = MyController.DoneStatus;
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,
                                Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                                PG_ID,
                                "プリンタ管理情報設定",
                                "Delete_Button_Click",
                                TMsgDisp.OPE_DELETE,
                                "削除に失敗しました。",
                                status,
                                "SFCMN09202A",
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1
                            );
                            this.Close();
                            return;
                        }
                }
            }
            else
            {
                btnDestroy.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion // </完全削除操作>

        #region <参考：論理削除>

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <remarks>
        /// 選択中のデータを削除します。
        /// </remarks>
        /// <returns>ステータス</returns>
        private int Delete()
        {
            PrtManage prtManage = GetDoingPrtManage();

            MyController.DoingRecord = prtManage;
            MyController.DeleteRecord();

            int status = MyController.DoneStatus;
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                TMsgDisp.Show(
                    this,
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                    PG_ID,
                    "プリンタ管理情報設定",
                    "Delete",
                    TMsgDisp.OPE_DELETE,
                    "削除に失敗しました。",
                    status,
                    "SFCMN09202A",
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1
                );
                this.Close();

                return status;
            }

            #region <ボツ>

            //status = PrtManageAccesser.Read(prtManage.EnterpriseCode, prtManage.PrinterMngNo, out prtManage);
            //if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            //{
            //    if (ExclusiveControl(status) == false)
            //    {
            //        return status;
            //    }
            //    TMsgDisp.Show(
            //        this,
            //        Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
            //        PG_ID,
            //        "プリンタ管理情報設定",
            //        "Delete",
            //        TMsgDisp.OPE_DELETE,
            //        "読み込みに失敗しました。",
            //        status,
            //        "SFCMN09202A",
            //        MessageBoxButtons.OK,
            //        MessageBoxDefaultButton.Button1
            //    );
            //    this.Close();

            //    return status;
            //}

            #endregion // </ボツ>

            return status;
        }

        #endregion // </参考：論理削除>
    }
}