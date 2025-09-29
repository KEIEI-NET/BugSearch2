//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Net.Mail;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メール情報設定マスタメンテナンスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: メール送信管理設定を行います
    ///					: IMasterMaintenanceSingleTypeを実装しています</br>
    /// <br>Programer	: 李占川</br>
    /// <br>Date		: 2010/05/24</br>
    /// <br></br>
    /// <br>Update Note : 2010/07/01 30517 夏野 駿希</br>
    /// <br>              Mantis.15717　拠点コードが一桁の場合0詰めして保存する様に変更</br>
    /// </remarks>
    public class PMKHN09590UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel MailAddress_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3UserId_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3Password_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3ServerName_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerName_Label;
        private Infragistics.Win.Misc.UltraLabel SenderName_Label;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Broadleaf.Library.Windows.Forms.TEdit MailAddress_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3UserId_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3Password_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3ServerName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SmtpServerName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SenderName_tEdit;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TEdit SmtpUserId_tEdit;
        private TEdit SmtpPassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel SmtpPassword_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpUserId_Label;
        private Infragistics.Win.Misc.UltraLabel MailServerTimeoutVal_Label;
        private Infragistics.Win.Misc.UltraLabel PopServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerPortNo_Label;
        private TNedit MailServerTimeoutVal_tNedit;
        private TNedit SmtpServerPortNo_tNedit;
        private TNedit PopServerPortNo_tNedit;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SmtpAuthUseDiv_ultraCheckEditor;
        private RadioButton SmtpAuthUseDiv1_radioButton;
        private RadioButton PopBeforeSmtpUseDiv_radioButton;
        private RadioButton SmtpAuthUseDiv2_radioButton;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel SelectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TEdit SectionName_tEdit;
        private TEdit MailSaveBeforeFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel MailSaveBeforeFolder_Label;
        private Infragistics.Win.Misc.UltraButton SaveFolder_Button;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Check_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private System.ComponentModel.IContainer components;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// PMKHN09590Uコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: メール送信管理設定コンストラクタです</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        public PMKHN09590UA()
        {
            InitializeComponent();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            this._nextData = false;
            this._totalCount = 0;

            // mailSndMngクラス
            this._mailInfoSetting = new MailInfoSetting();
            // mailSndMngクラスアクセスクラス
            this._mailInfoSettingAcs = new MailInfoSettingAcs();

            this._mailInfoSettingTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 印刷可能フラグを設定します。
            // Frameの印刷ボタンの表示非表示の制御に使用します。
            this._canPrint = false;

            this._indexBuf = -2;

            this._preSectionCode = string.Empty;
            this._preSectionName = string.Empty;
        }
        #endregion

        #region Private Member
        /// <summary>
        /// グローバル変数・定数宣言
        /// </summary>
        private MailInfoSetting _mailInfoSetting;
        private MailInfoSettingAcs _mailInfoSettingAcs;
        private MailInfoSetting _mailInfoSettingClone; // データ比較用        
        private string _enterpriseCode;

        //HashTable
        private Hashtable _mailInfoSettingTable;
        private string _preSectionCode;
        private string _preSectionName;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool _nextData;
        //件数
        private int _totalCount;

        private const string ASSEMBLY_ID = "PMKHN09590U";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";
        private const string VIEW_SECTIONCODE = "拠点コード";
        private const string VIEW_SECTIONNAME = "拠点";
        private const string VIEW_SENDERNAME = "差出人名";
        private const string VIEW_MAILADDRESS = "メールアドレス";
        private const string VIEW_POP3USERID = "POP3ユーザーID";
        private const string VIEW_POP3PASSWORD = "POP3パスワード";
        private const string VIEW_POP3SERVERNAME = "POP3サーバー名";
        private const string VIEW_SMTPSERVERNAME = "SMTPサーバー名";
        private const string VIEW_SMTPAUTHUSEDIV = "送信サーバー(SMTP)認証";
        private const string VIEW_SMTPUSERID = "SMTPユーザーID";
        private const string VIEW_SMTPPASSWORD = "SMTPパスワード";
        private const string VIEW_POPBEFORESMTPUSEDIV = "受信メールサーバーにログオン";
        private const string VIEW_POPSERVERPORTNO = "POPサーバー ポート番号";
        private const string VIEW_SMTPSERVERPORTNO = "SMTPサーバー ポート番号";
        private const string VIEW_MAILSERVERTIMEOUTVAL = "メールサーバータイムアウト";
        private const string VIEW_MAILSAVEBEFOREFOLDER = "メール保存先フォルダ";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private int _indexBuf;

        #endregion

        #region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            this.MailAddress_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3UserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3Password_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3ServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SenderName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.MailAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3UserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3Password_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3ServerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpServerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SenderName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SmtpUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpPassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailServerTimeoutVal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MailServerTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpAuthUseDiv_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SmtpAuthUseDiv1_radioButton = new System.Windows.Forms.RadioButton();
            this.SmtpAuthUseDiv2_radioButton = new System.Windows.Forms.RadioButton();
            this.PopBeforeSmtpUseDiv_radioButton = new System.Windows.Forms.RadioButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.SelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MailSaveBeforeFolder_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailSaveBeforeFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SaveFolder_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Check_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.MailAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3UserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3Password_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3ServerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenderName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopServerPortNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerPortNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailServerTimeoutVal_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailSaveBeforeFolder_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // MailAddress_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.MailAddress_Label.Appearance = appearance1;
            this.MailAddress_Label.Location = new System.Drawing.Point(65, 105);
            this.MailAddress_Label.Name = "MailAddress_Label";
            this.MailAddress_Label.Size = new System.Drawing.Size(135, 23);
            this.MailAddress_Label.TabIndex = 7;
            this.MailAddress_Label.Tag = "8";
            this.MailAddress_Label.Text = "メールアドレス";
            // 
            // Pop3UserId_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.Pop3UserId_Label.Appearance = appearance2;
            this.Pop3UserId_Label.Location = new System.Drawing.Point(65, 140);
            this.Pop3UserId_Label.Name = "Pop3UserId_Label";
            this.Pop3UserId_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3UserId_Label.TabIndex = 13;
            this.Pop3UserId_Label.Tag = "13";
            this.Pop3UserId_Label.Text = "POP3ユーザーID";
            // 
            // Pop3Password_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.Pop3Password_Label.Appearance = appearance3;
            this.Pop3Password_Label.Location = new System.Drawing.Point(65, 175);
            this.Pop3Password_Label.Name = "Pop3Password_Label";
            this.Pop3Password_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3Password_Label.TabIndex = 14;
            this.Pop3Password_Label.Tag = "14";
            this.Pop3Password_Label.Text = "POP3パスワード";
            // 
            // Pop3ServerName_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Pop3ServerName_Label.Appearance = appearance4;
            this.Pop3ServerName_Label.Location = new System.Drawing.Point(65, 210);
            this.Pop3ServerName_Label.Name = "Pop3ServerName_Label";
            this.Pop3ServerName_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3ServerName_Label.TabIndex = 15;
            this.Pop3ServerName_Label.Tag = "15";
            this.Pop3ServerName_Label.Text = "POP3サーバー名";
            // 
            // SmtpServerName_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.SmtpServerName_Label.Appearance = appearance5;
            this.SmtpServerName_Label.Location = new System.Drawing.Point(65, 245);
            this.SmtpServerName_Label.Name = "SmtpServerName_Label";
            this.SmtpServerName_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpServerName_Label.TabIndex = 16;
            this.SmtpServerName_Label.Tag = "16";
            this.SmtpServerName_Label.Text = "SMTPサーバー名";
            // 
            // SenderName_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.SenderName_Label.Appearance = appearance6;
            this.SenderName_Label.Location = new System.Drawing.Point(65, 70);
            this.SenderName_Label.Name = "SenderName_Label";
            this.SenderName_Label.Size = new System.Drawing.Size(135, 23);
            this.SenderName_Label.TabIndex = 17;
            this.SenderName_Label.Tag = "17";
            this.SenderName_Label.Text = "差出人名";
            // 
            // Mode_Label
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(685, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 660);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(816, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(670, 620);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 24;
            this.Close_Button.Text = "閉じる(&X)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // MailAddress_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Left";
            this.MailAddress_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Left";
            this.MailAddress_tEdit.Appearance = appearance9;
            this.MailAddress_tEdit.AutoSelect = true;
            this.MailAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MailAddress_tEdit.DataText = "";
            this.MailAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.MailAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailAddress_tEdit.Location = new System.Drawing.Point(210, 105);
            this.MailAddress_tEdit.MaxLength = 64;
            this.MailAddress_tEdit.Name = "MailAddress_tEdit";
            this.MailAddress_tEdit.Size = new System.Drawing.Size(528, 24);
            this.MailAddress_tEdit.TabIndex = 4;
            // 
            // Pop3UserId_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Left";
            this.Pop3UserId_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Left";
            this.Pop3UserId_tEdit.Appearance = appearance11;
            this.Pop3UserId_tEdit.AutoSelect = true;
            this.Pop3UserId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3UserId_tEdit.DataText = "";
            this.Pop3UserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3UserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3UserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3UserId_tEdit.Location = new System.Drawing.Point(210, 140);
            this.Pop3UserId_tEdit.MaxLength = 64;
            this.Pop3UserId_tEdit.Name = "Pop3UserId_tEdit";
            this.Pop3UserId_tEdit.Size = new System.Drawing.Size(528, 24);
            this.Pop3UserId_tEdit.TabIndex = 5;
            // 
            // Pop3Password_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlignAsString = "Left";
            this.Pop3Password_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Left";
            this.Pop3Password_tEdit.Appearance = appearance13;
            this.Pop3Password_tEdit.AutoSelect = true;
            this.Pop3Password_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3Password_tEdit.DataText = "";
            this.Pop3Password_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3Password_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3Password_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3Password_tEdit.Location = new System.Drawing.Point(210, 175);
            this.Pop3Password_tEdit.MaxLength = 24;
            this.Pop3Password_tEdit.Name = "Pop3Password_tEdit";
            this.Pop3Password_tEdit.PasswordChar = '*';
            this.Pop3Password_tEdit.Size = new System.Drawing.Size(203, 24);
            this.Pop3Password_tEdit.TabIndex = 6;
            // 
            // Pop3ServerName_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.TextHAlignAsString = "Left";
            this.Pop3ServerName_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            this.Pop3ServerName_tEdit.Appearance = appearance15;
            this.Pop3ServerName_tEdit.AutoSelect = true;
            this.Pop3ServerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3ServerName_tEdit.DataText = "";
            this.Pop3ServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3ServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3ServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3ServerName_tEdit.Location = new System.Drawing.Point(210, 210);
            this.Pop3ServerName_tEdit.MaxLength = 64;
            this.Pop3ServerName_tEdit.Name = "Pop3ServerName_tEdit";
            this.Pop3ServerName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.Pop3ServerName_tEdit.TabIndex = 7;
            // 
            // SmtpServerName_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.TextHAlignAsString = "Left";
            this.SmtpServerName_tEdit.ActiveAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Left";
            this.SmtpServerName_tEdit.Appearance = appearance51;
            this.SmtpServerName_tEdit.AutoSelect = true;
            this.SmtpServerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpServerName_tEdit.DataText = "";
            this.SmtpServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpServerName_tEdit.Location = new System.Drawing.Point(210, 245);
            this.SmtpServerName_tEdit.MaxLength = 64;
            this.SmtpServerName_tEdit.Name = "SmtpServerName_tEdit";
            this.SmtpServerName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SmtpServerName_tEdit.TabIndex = 8;
            // 
            // SenderName_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Left";
            this.SenderName_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Left";
            this.SenderName_tEdit.Appearance = appearance19;
            this.SenderName_tEdit.AutoSelect = true;
            this.SenderName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SenderName_tEdit.DataText = "";
            this.SenderName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SenderName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SenderName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SenderName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SenderName_tEdit.Location = new System.Drawing.Point(210, 70);
            this.SenderName_tEdit.MaxLength = 32;
            this.SenderName_tEdit.Name = "SenderName_tEdit";
            this.SenderName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SenderName_tEdit.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SmtpUserId_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.TextHAlignAsString = "Left";
            this.SmtpUserId_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Left";
            this.SmtpUserId_tEdit.Appearance = appearance45;
            this.SmtpUserId_tEdit.AutoSelect = true;
            this.SmtpUserId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpUserId_tEdit.DataText = "";
            this.SmtpUserId_tEdit.Enabled = false;
            this.SmtpUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpUserId_tEdit.Location = new System.Drawing.Point(210, 380);
            this.SmtpUserId_tEdit.MaxLength = 64;
            this.SmtpUserId_tEdit.Name = "SmtpUserId_tEdit";
            this.SmtpUserId_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SmtpUserId_tEdit.TabIndex = 12;
            // 
            // SmtpPassword_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlignAsString = "Left";
            this.SmtpPassword_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Left";
            this.SmtpPassword_tEdit.Appearance = appearance47;
            this.SmtpPassword_tEdit.AutoSelect = true;
            this.SmtpPassword_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpPassword_tEdit.DataText = "";
            this.SmtpPassword_tEdit.Enabled = false;
            this.SmtpPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpPassword_tEdit.Location = new System.Drawing.Point(210, 415);
            this.SmtpPassword_tEdit.MaxLength = 24;
            this.SmtpPassword_tEdit.Name = "SmtpPassword_tEdit";
            this.SmtpPassword_tEdit.PasswordChar = '*';
            this.SmtpPassword_tEdit.Size = new System.Drawing.Size(203, 24);
            this.SmtpPassword_tEdit.TabIndex = 13;
            // 
            // SmtpPassword_Label
            // 
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextVAlignAsString = "Middle";
            this.SmtpPassword_Label.Appearance = appearance48;
            this.SmtpPassword_Label.Enabled = false;
            this.SmtpPassword_Label.Location = new System.Drawing.Point(65, 415);
            this.SmtpPassword_Label.Name = "SmtpPassword_Label";
            this.SmtpPassword_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpPassword_Label.TabIndex = 27;
            this.SmtpPassword_Label.Tag = "14";
            this.SmtpPassword_Label.Text = "SMTPパスワード";
            // 
            // SmtpUserId_Label
            // 
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.SmtpUserId_Label.Appearance = appearance49;
            this.SmtpUserId_Label.Enabled = false;
            this.SmtpUserId_Label.Location = new System.Drawing.Point(65, 380);
            this.SmtpUserId_Label.Name = "SmtpUserId_Label";
            this.SmtpUserId_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpUserId_Label.TabIndex = 25;
            this.SmtpUserId_Label.Tag = "13";
            this.SmtpUserId_Label.Text = "SMTPユーザーID";
            // 
            // MailServerTimeoutVal_Label
            // 
            appearance41.TextVAlignAsString = "Middle";
            this.MailServerTimeoutVal_Label.Appearance = appearance41;
            this.MailServerTimeoutVal_Label.Location = new System.Drawing.Point(402, 491);
            this.MailServerTimeoutVal_Label.Name = "MailServerTimeoutVal_Label";
            this.MailServerTimeoutVal_Label.Size = new System.Drawing.Size(210, 23);
            this.MailServerTimeoutVal_Label.TabIndex = 35;
            this.MailServerTimeoutVal_Label.Tag = "16";
            this.MailServerTimeoutVal_Label.Text = "メールサーバータイムアウト";
            // 
            // PopServerPortNo_Label
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.PopServerPortNo_Label.Appearance = appearance42;
            this.PopServerPortNo_Label.Location = new System.Drawing.Point(65, 490);
            this.PopServerPortNo_Label.Name = "PopServerPortNo_Label";
            this.PopServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.PopServerPortNo_Label.TabIndex = 34;
            this.PopServerPortNo_Label.Tag = "14";
            this.PopServerPortNo_Label.Text = "POPサーバー ポート番号";
            // 
            // SmtpServerPortNo_Label
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.SmtpServerPortNo_Label.Appearance = appearance52;
            this.SmtpServerPortNo_Label.Location = new System.Drawing.Point(65, 525);
            this.SmtpServerPortNo_Label.Name = "SmtpServerPortNo_Label";
            this.SmtpServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.SmtpServerPortNo_Label.TabIndex = 32;
            this.SmtpServerPortNo_Label.Tag = "16";
            this.SmtpServerPortNo_Label.Text = "SMTPサーバー ポート番号";
            // 
            // PopServerPortNo_tNedit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.TextHAlignAsString = "Right";
            this.PopServerPortNo_tNedit.ActiveAppearance = appearance37;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.PopServerPortNo_tNedit.Appearance = appearance38;
            this.PopServerPortNo_tNedit.AutoSelect = true;
            this.PopServerPortNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PopServerPortNo_tNedit.DataText = "";
            this.PopServerPortNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PopServerPortNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PopServerPortNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PopServerPortNo_tNedit.Location = new System.Drawing.Point(285, 490);
            this.PopServerPortNo_tNedit.MaxLength = 4;
            this.PopServerPortNo_tNedit.Name = "PopServerPortNo_tNedit";
            this.PopServerPortNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PopServerPortNo_tNedit.Size = new System.Drawing.Size(44, 24);
            this.PopServerPortNo_tNedit.TabIndex = 15;
            // 
            // SmtpServerPortNo_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.SmtpServerPortNo_tNedit.ActiveAppearance = appearance40;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Right";
            this.SmtpServerPortNo_tNedit.Appearance = appearance36;
            this.SmtpServerPortNo_tNedit.AutoSelect = true;
            this.SmtpServerPortNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SmtpServerPortNo_tNedit.DataText = "";
            this.SmtpServerPortNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerPortNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SmtpServerPortNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SmtpServerPortNo_tNedit.Location = new System.Drawing.Point(285, 525);
            this.SmtpServerPortNo_tNedit.MaxLength = 4;
            this.SmtpServerPortNo_tNedit.Name = "SmtpServerPortNo_tNedit";
            this.SmtpServerPortNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SmtpServerPortNo_tNedit.Size = new System.Drawing.Size(44, 24);
            this.SmtpServerPortNo_tNedit.TabIndex = 17;
            // 
            // MailServerTimeoutVal_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlignAsString = "Right";
            this.MailServerTimeoutVal_tNedit.ActiveAppearance = appearance33;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            this.MailServerTimeoutVal_tNedit.Appearance = appearance34;
            this.MailServerTimeoutVal_tNedit.AutoSelect = true;
            this.MailServerTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailServerTimeoutVal_tNedit.DataText = "";
            this.MailServerTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailServerTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.MailServerTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailServerTimeoutVal_tNedit.Location = new System.Drawing.Point(622, 491);
            this.MailServerTimeoutVal_tNedit.MaxLength = 4;
            this.MailServerTimeoutVal_tNedit.Name = "MailServerTimeoutVal_tNedit";
            this.MailServerTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailServerTimeoutVal_tNedit.Size = new System.Drawing.Size(44, 24);
            this.MailServerTimeoutVal_tNedit.TabIndex = 16;
            // 
            // SmtpAuthUseDiv_ultraCheckEditor
            // 
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.SmtpAuthUseDiv_ultraCheckEditor.Appearance = appearance32;
            this.SmtpAuthUseDiv_ultraCheckEditor.Location = new System.Drawing.Point(25, 290);
            this.SmtpAuthUseDiv_ultraCheckEditor.Name = "SmtpAuthUseDiv_ultraCheckEditor";
            this.SmtpAuthUseDiv_ultraCheckEditor.Size = new System.Drawing.Size(260, 20);
            this.SmtpAuthUseDiv_ultraCheckEditor.TabIndex = 9;
            this.SmtpAuthUseDiv_ultraCheckEditor.Text = "送信サーバー(SMTP)は認証が必要";
            this.SmtpAuthUseDiv_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged);
            // 
            // SmtpAuthUseDiv1_radioButton
            // 
            this.SmtpAuthUseDiv1_radioButton.AutoSize = true;
            this.SmtpAuthUseDiv1_radioButton.Checked = true;
            this.SmtpAuthUseDiv1_radioButton.Enabled = false;
            this.SmtpAuthUseDiv1_radioButton.Location = new System.Drawing.Point(45, 320);
            this.SmtpAuthUseDiv1_radioButton.Name = "SmtpAuthUseDiv1_radioButton";
            this.SmtpAuthUseDiv1_radioButton.Size = new System.Drawing.Size(329, 19);
            this.SmtpAuthUseDiv1_radioButton.TabIndex = 10;
            this.SmtpAuthUseDiv1_radioButton.TabStop = true;
            this.SmtpAuthUseDiv1_radioButton.Text = "受信メールサーバーと同じ設定を使用する";
            this.SmtpAuthUseDiv1_radioButton.UseVisualStyleBackColor = true;
            this.SmtpAuthUseDiv1_radioButton.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv1_radioButton_CheckedChanged);
            // 
            // SmtpAuthUseDiv2_radioButton
            // 
            this.SmtpAuthUseDiv2_radioButton.AutoSize = true;
            this.SmtpAuthUseDiv2_radioButton.Enabled = false;
            this.SmtpAuthUseDiv2_radioButton.Location = new System.Drawing.Point(45, 350);
            this.SmtpAuthUseDiv2_radioButton.Name = "SmtpAuthUseDiv2_radioButton";
            this.SmtpAuthUseDiv2_radioButton.Size = new System.Drawing.Size(345, 19);
            this.SmtpAuthUseDiv2_radioButton.TabIndex = 11;
            this.SmtpAuthUseDiv2_radioButton.Text = "次のアカウントとパスワードでログオンする";
            this.SmtpAuthUseDiv2_radioButton.UseVisualStyleBackColor = true;
            this.SmtpAuthUseDiv2_radioButton.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv2_radioButton_CheckedChanged);
            // 
            // PopBeforeSmtpUseDiv_radioButton
            // 
            this.PopBeforeSmtpUseDiv_radioButton.AutoSize = true;
            this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
            this.PopBeforeSmtpUseDiv_radioButton.Location = new System.Drawing.Point(45, 450);
            this.PopBeforeSmtpUseDiv_radioButton.Name = "PopBeforeSmtpUseDiv_radioButton";
            this.PopBeforeSmtpUseDiv_radioButton.Size = new System.Drawing.Size(281, 19);
            this.PopBeforeSmtpUseDiv_radioButton.TabIndex = 14;
            this.PopBeforeSmtpUseDiv_radioButton.Text = "受信メールサーバーにログオンする";
            this.PopBeforeSmtpUseDiv_radioButton.UseVisualStyleBackColor = true;
            this.PopBeforeSmtpUseDiv_radioButton.CheckedChanged += new System.EventHandler(this.PopBeforeSmtpUseDiv_radioButton_CheckedChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 275);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel1.TabIndex = 48;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(20, 475);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel2.TabIndex = 52;
            // 
            // ultraLabel3
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance27;
            this.ultraLabel3.Location = new System.Drawing.Point(667, 491);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel3.TabIndex = 53;
            this.ultraLabel3.Tag = "16";
            this.ultraLabel3.Text = "秒";
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // SelectionCode_Title_Label
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.SelectionCode_Title_Label.Appearance = appearance26;
            this.SelectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SelectionCode_Title_Label.Location = new System.Drawing.Point(65, 25);
            this.SelectionCode_Title_Label.Name = "SelectionCode_Title_Label";
            this.SelectionCode_Title_Label.Size = new System.Drawing.Size(135, 23);
            this.SelectionCode_Title_Label.TabIndex = 118;
            this.SelectionCode_Title_Label.Text = "拠点";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(20, 55);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel4.TabIndex = 119;
            // 
            // SectionName_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Left";
            this.SectionName_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance21;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(210, 25);
            this.SectionName_tEdit.MaxLength = 2;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(239, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // MailSaveBeforeFolder_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.MailSaveBeforeFolder_Label.Appearance = appearance43;
            this.MailSaveBeforeFolder_Label.Location = new System.Drawing.Point(65, 563);
            this.MailSaveBeforeFolder_Label.Name = "MailSaveBeforeFolder_Label";
            this.MailSaveBeforeFolder_Label.Size = new System.Drawing.Size(210, 23);
            this.MailSaveBeforeFolder_Label.TabIndex = 122;
            this.MailSaveBeforeFolder_Label.Tag = "16";
            this.MailSaveBeforeFolder_Label.Text = "メール保存先フォルダ";
            // 
            // MailSaveBeforeFolder_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlignAsString = "Left";
            this.MailSaveBeforeFolder_tEdit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Left";
            this.MailSaveBeforeFolder_tEdit.Appearance = appearance17;
            this.MailSaveBeforeFolder_tEdit.AutoSelect = true;
            this.MailSaveBeforeFolder_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MailSaveBeforeFolder_tEdit.DataText = "";
            this.MailSaveBeforeFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailSaveBeforeFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.MailSaveBeforeFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailSaveBeforeFolder_tEdit.Location = new System.Drawing.Point(285, 562);
            this.MailSaveBeforeFolder_tEdit.MaxLength = 256;
            this.MailSaveBeforeFolder_tEdit.Name = "MailSaveBeforeFolder_tEdit";
            this.MailSaveBeforeFolder_tEdit.Size = new System.Drawing.Size(473, 24);
            this.MailSaveBeforeFolder_tEdit.TabIndex = 18;
            // 
            // SectionGuide_Button
            // 
            appearance39.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance39.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance39;
            this.SectionGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(452, 25);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // SaveFolder_Button
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SaveFolder_Button.Appearance = appearance35;
            this.SaveFolder_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveFolder_Button.Location = new System.Drawing.Point(768, 562);
            this.SaveFolder_Button.Name = "SaveFolder_Button";
            this.SaveFolder_Button.Size = new System.Drawing.Size(24, 24);
            this.SaveFolder_Button.TabIndex = 19;
            this.SaveFolder_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SaveFolder_Button.Click += new System.EventHandler(this.SaveFolder_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(413, 620);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(131, 34);
            this.Delete_Button.TabIndex = 22;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Revive_Button.Location = new System.Drawing.Point(545, 620);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 23;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(545, 620);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Check_Button
            // 
            this.Check_Button.Location = new System.Drawing.Point(413, 620);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(131, 34);
            this.Check_Button.TabIndex = 20;
            this.Check_Button.Text = "接続テスト(&T)";
            this.Check_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // PMKHN09590UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(816, 683);
            this.Controls.Add(this.Check_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.SaveFolder_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.MailSaveBeforeFolder_tEdit);
            this.Controls.Add(this.MailSaveBeforeFolder_Label);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.SelectionCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PopBeforeSmtpUseDiv_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv2_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv1_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv_ultraCheckEditor);
            this.Controls.Add(this.MailServerTimeoutVal_tNedit);
            this.Controls.Add(this.SmtpServerPortNo_tNedit);
            this.Controls.Add(this.PopServerPortNo_tNedit);
            this.Controls.Add(this.MailServerTimeoutVal_Label);
            this.Controls.Add(this.PopServerPortNo_Label);
            this.Controls.Add(this.SmtpServerPortNo_Label);
            this.Controls.Add(this.SmtpUserId_tEdit);
            this.Controls.Add(this.SmtpPassword_tEdit);
            this.Controls.Add(this.SmtpPassword_Label);
            this.Controls.Add(this.SmtpUserId_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.MailAddress_tEdit);
            this.Controls.Add(this.Pop3UserId_tEdit);
            this.Controls.Add(this.Pop3Password_tEdit);
            this.Controls.Add(this.Pop3ServerName_tEdit);
            this.Controls.Add(this.SmtpServerName_tEdit);
            this.Controls.Add(this.SenderName_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SenderName_Label);
            this.Controls.Add(this.SmtpServerName_Label);
            this.Controls.Add(this.Pop3ServerName_Label);
            this.Controls.Add(this.Pop3Password_Label);
            this.Controls.Add(this.Pop3UserId_Label);
            this.Controls.Add(this.MailAddress_Label);
            this.Controls.Add(this.Close_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PMKHN09590UA";
            this.Text = "メール情報設定";
            this.Load += new System.EventHandler(this.PMKHN09590UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09590UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09590UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.MailAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3UserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3Password_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3ServerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenderName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopServerPortNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerPortNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailServerTimeoutVal_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailSaveBeforeFolder_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Main Entry Point
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09590UA());
        }
        #endregion

        #region IMasterMaintenanceMultiTypeメンバ
        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Method --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList mailInfoSettingList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._mailInfoSettingAcs.Search(out mailInfoSettingList, this._enterpriseCode);

                this._totalCount = mailInfoSettingList.Count;
            }
            else
            {
                status = this._mailInfoSettingAcs.SearchAll(
                    out mailInfoSettingList,
                    out this._totalCount,
                    out this._nextData,
                    this._enterpriseCode,
                    readCount,
                    this._mailInfoSetting);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (mailInfoSettingList.Count > 0)
                        {
                            // 最終のメール送信管理設定をオブジェクトを退避する
                            this._mailInfoSetting = ((MailInfoSetting)mailInfoSettingList[mailInfoSettingList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // 読み込んだインスタンス
                        foreach (MailInfoSetting mailInfoSetting in mailInfoSettingList)
                        {
                            // DataSetにセットする
                            MailInfoSettingToDataSet(mailInfoSetting.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 全件読み込み完了の場合は、何もしない
                        break;
                    }
                default:
                    {
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "メール情報設定マスタメンテナンス", // プログラム名称
                            "Search", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._mailInfoSettingAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
            totalCount = this._totalCount;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            MailInfoSetting mailInfoSetting = (MailInfoSetting)this._mailInfoSettingTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // メール情報設定マスタ情報論理削除処理
            status = this._mailInfoSettingAcs.LogicalDelete(ref mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._mailInfoSettingAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // メール情報設定マスタ情報クラスデータセット展開処理
            MailInfoSettingToDataSet(mailInfoSetting.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //拠点
            appearanceTable.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //拠点Name
            appearanceTable.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //差出人名
            appearanceTable.Add(VIEW_SENDERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //メールアドレス
            appearanceTable.Add(VIEW_MAILADDRESS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3ユーザー名
            appearanceTable.Add(VIEW_POP3USERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3パスワード
            appearanceTable.Add(VIEW_POP3PASSWORD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3サーバー名
            appearanceTable.Add(VIEW_POP3SERVERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTPサーバー名
            appearanceTable.Add(VIEW_SMTPSERVERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //送信サーバー(SMTP)認証
            appearanceTable.Add(VIEW_SMTPAUTHUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POPサーバー ポート番号
            appearanceTable.Add(VIEW_POPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //SMTPサーバー ポート番号
            appearanceTable.Add(VIEW_SMTPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //メールサーバータイムアウト値
            appearanceTable.Add(VIEW_MAILSERVERTIMEOUTVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // メール保存先フォルダ
            appearanceTable.Add(VIEW_MAILSAVEBEFOREFOLDER, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// メール情報設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタメンテナンスクラスをデータセットに格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MailInfoSettingToDataSet(MailInfoSetting mailInfoSetting, int index)
        {
            // indexの値がDataSetの既存行をさしていなかったら
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

                // indexに行の最終行番号をセットする
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }
            if (mailInfoSetting.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = mailInfoSetting.UpdateDateTimeJpInFormal;
            }
            // 拠点コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE] = mailInfoSetting.SectionCode.Trim().PadLeft(2, '0');
            // 拠点名称
            string sectionName;
            int status = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, mailInfoSetting.SectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = "";
            }
            // 差出人名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDERNAME] = mailInfoSetting.SenderName;
            // メールアドレス
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILADDRESS] = mailInfoSetting.MailAddress;
            // POP3ユーザーID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3USERID] = mailInfoSetting.Pop3UserId;
            // POP3パスワード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3PASSWORD] = mailInfoSetting.Pop3Password;
            // POP3サーバー名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3SERVERNAME] = mailInfoSetting.Pop3ServerName;
            // SMTPサーバー名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERNAME] = mailInfoSetting.SmtpServerName;
            // 送信サーバー(SMTP)認証
            if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "必要";
            }
            // POPサーバーポート番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPSERVERPORTNO] = mailInfoSetting.PopServerPortNo;
            // SMTPサーバーポート番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERPORTNO] = mailInfoSetting.SmtpServerPortNo;
            // メールサーバータイムアウト
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSERVERTIMEOUTVAL] = mailInfoSetting.MailServerTimeoutVal;
            // メール保存先フォルダ
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSAVEBEFOREFOLDER] = mailInfoSetting.FilePathNm;
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = mailInfoSetting.FileHeaderGuid;

            // インスタンステーブルにもセットする
            if (this._mailInfoSettingTable.ContainsKey(mailInfoSetting.FileHeaderGuid) == true)
            {
                this._mailInfoSettingTable.Remove(mailInfoSetting.FileHeaderGuid);
            }
            this._mailInfoSettingTable.Add(mailInfoSetting.FileHeaderGuid, mailInfoSetting);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mailSndMngTable = new DataTable(VIEW_TABLE);

            //// Addを行う順番が、列の表示順位となります。
            mailSndMngTable.Columns.Add(DELETE_DATE, typeof(string));               //削除日
            mailSndMngTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));          //拠点
            mailSndMngTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //拠点名称
            mailSndMngTable.Columns.Add(VIEW_SENDERNAME, typeof(string));           //差出人名
            mailSndMngTable.Columns.Add(VIEW_MAILADDRESS, typeof(string));          //メールアドレス
            mailSndMngTable.Columns.Add(VIEW_POP3USERID, typeof(string));           //POP3ユーザーID
            mailSndMngTable.Columns.Add(VIEW_POP3PASSWORD, typeof(string));         //POP3パスワード
            mailSndMngTable.Columns.Add(VIEW_POP3SERVERNAME, typeof(string));       //POP3サーバー名
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERNAME, typeof(string));       //SMTPサーバー名
            mailSndMngTable.Columns.Add(VIEW_SMTPAUTHUSEDIV, typeof(string));       //送信サーバー(SMTP)認証
            mailSndMngTable.Columns.Add(VIEW_POPSERVERPORTNO, typeof(int));         //POPサーバー ポート番号
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERPORTNO, typeof(int));        //SMTPサーバー ポート番号
            mailSndMngTable.Columns.Add(VIEW_MAILSERVERTIMEOUTVAL, typeof(int));    //メールサーバータイムアウト値
            mailSndMngTable.Columns.Add(VIEW_MAILSAVEBEFOREFOLDER, typeof(string)); //メール保存先フォルダ
            mailSndMngTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(mailSndMngTable);
        }

        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note			:	画面の初期設定を行います。</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // Edit系クリア
            EditClear("", "0");
        }

        /// <summary>
        /// エディットボックス初期化処理
        /// </summary>
        /// <param name="tEditValue">tEditに代入する値</param>
        /// <param name="tNEditValue">tNEditに代入する値</param>
        /// <remarks>
        /// <br>Note		:	TEdit,TNEditを初期化します</br>
        /// <br>Programmer	:	李占川</br>
        /// <br>Date		:   2010/05/24</br>
        /// </remarks>
        private void EditClear(string tEditValue, string tNEditValue)
        {
            this._preSectionCode = tEditValue;
            this._preSectionName = tEditValue;
            SectionName_tEdit.DataText = tEditValue;
            MailAddress_tEdit.DataText = tEditValue;				// メールアドレス
            Pop3UserId_tEdit.DataText = tEditValue;				    // POP3ユーザーID
            Pop3Password_tEdit.DataText = tEditValue;				// POP3パスワード
            Pop3ServerName_tEdit.DataText = tEditValue;				// POP3サーバー名
            SmtpServerName_tEdit.DataText = tEditValue;				// SMTPサーバー名
            SmtpUserId_tEdit.DataText = tEditValue;                 // SMTPユーザーID
            SmtpPassword_tEdit.DataText = tEditValue;               // SMTPパスワード
            SenderName_tEdit.DataText = tEditValue;				    // 差出人名
            MailSaveBeforeFolder_tEdit.Text = tEditValue;

            this.PopServerPortNo_tNedit.Text = tNEditValue;
            this.SmtpServerPortNo_tNedit.Text = tNEditValue;
            this.MailServerTimeoutVal_tNedit.Text = tNEditValue;
        }

        /// <summary>
        /// 画面クリアー処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面をクリアーします</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        private void ScreenClear()
        {
            EditClear("", "");									// Edit系クリア
            this.PopServerPortNo_tNedit.SetInt(0);
            this.SmtpServerPortNo_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                MailInfoSetting mailInfoSetting = new MailInfoSetting();
                this._mailInfoSettingClone = mailInfoSetting.Clone();
                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // 画面展開処理
                MailInfoSettingToScreen(mailInfoSetting);

                // 画面情報メール情報設定マスタメンテナンスクラス格納処理
                DispToMailInfoSetting(ref this._mailInfoSettingClone);

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.SectionName_tEdit.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                MailInfoSetting mailInfoSetting = (MailInfoSetting)this._mailInfoSettingTable[guid];

                // 画面展開処理
                MailInfoSettingToScreen(mailInfoSetting);

                if (mailInfoSetting.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // クローン作成
                    this._mailInfoSettingClone = mailInfoSetting.Clone();
                    // 画面情報メール情報設定マスタメンテナンスクラス格納処理
                    DispToMailInfoSetting(ref this._mailInfoSettingClone);

                    this.SenderName_tEdit.Focus();
                    this.SenderName_tEdit.SelectAll();
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面情報メール情報設定マスタメンテナンスクラス格納処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からメール情報設定マスタオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void DispToMailInfoSetting(ref MailInfoSetting mailInfoSetting)
        {
            if (mailInfoSetting == null)
            {
                // 新規の場合
                mailInfoSetting = new MailInfoSetting();
            }

            // 各項目のセット
            mailInfoSetting.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            // 2010/07/01 >>>
            //mailInfoSetting.SectionCode = this._preSectionCode;
            mailInfoSetting.SectionCode = this._preSectionCode.Trim().PadLeft(2, '0');
            // 2010/07/01 <<<

            // e-mail送信管理番号
            mailInfoSetting.MailSendMngNo = 0; //0固定
            // 差出人名
            mailInfoSetting.SenderName = this.SenderName_tEdit.Text;
            // メールアドレス
            mailInfoSetting.MailAddress = this.MailAddress_tEdit.Text;
            // POP3ユーザーID
            mailInfoSetting.Pop3UserId = this.Pop3UserId_tEdit.Text;
            // POP3パスワード
            mailInfoSetting.Pop3Password = this.Pop3Password_tEdit.Text;
            // POP3サーバー名
            mailInfoSetting.Pop3ServerName = this.Pop3ServerName_tEdit.Text;
            // SMTPサーバー名
            mailInfoSetting.SmtpServerName = this.SmtpServerName_tEdit.Text;
            // SMTP認証使用区分
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 1; //POP認証と同じID・パスワードを使用
                    mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 2; //SMTP認証のID・パスワードを使用
                    mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
                }
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 0;      //SMTP認証使用しない
                    mailInfoSetting.PopBeforeSmtpUseDiv = 1; //使用する                    
                }
            }
            else
            {
                mailInfoSetting.SmtpAuthUseDiv = 0; //SMTP認証使用しない
                mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
            }
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv1_radioButton.Checked)
            {
                // SMTPユーザーID
                mailInfoSetting.SmtpUserId = this.Pop3UserId_tEdit.Text;
                // SMTPパスワード
                mailInfoSetting.SmtpPassword = this.Pop3Password_tEdit.Text;
            }
            else
            {
                // SMTPユーザーID
                mailInfoSetting.SmtpUserId = this.SmtpUserId_tEdit.Text;
                // SMTPパスワード
                mailInfoSetting.SmtpPassword = this.SmtpPassword_tEdit.Text;
            }
            // POPサーバーポート番号
            mailInfoSetting.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            // SMTPサーバーポート番号
            mailInfoSetting.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            // メールサーバータイムアウト値
            mailInfoSetting.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            // ファイルパス名
            mailInfoSetting.FilePathNm = this.MailSaveBeforeFolder_tEdit.Text;
        }

        /// <summary>
        /// メール情報設定マスタメンテナンスクラス画面展開処理
        /// </summary>
        /// <param name="mailInfoSetting">メール情報設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : メール情報設定マスタオブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MailInfoSettingToScreen(MailInfoSetting mailInfoSetting)
        {
            // 各項目のセット
            // 拠点コード
            this._preSectionCode = mailInfoSetting.SectionCode;
            // 拠点名称
            string sectionName;
            int st = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, mailInfoSetting.SectionCode);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionName_tEdit.Text = sectionName;
            }
            else
            {
                TMsgDisp.Show(this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                "拠点名称取得に失敗しました。",      // 表示するメッセージ 
                                st,								// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン
            }
            // 差出人名
            this.SenderName_tEdit.Text = mailInfoSetting.SenderName;
            // メールアドレス
            this.MailAddress_tEdit.Text = mailInfoSetting.MailAddress;
            // POP3ユーザーID
            this.Pop3UserId_tEdit.Text = mailInfoSetting.Pop3UserId;
            // POP3パスワード
            this.Pop3Password_tEdit.Text = mailInfoSetting.Pop3Password;
            // POP3サーバー名
            this.Pop3ServerName_tEdit.Text = mailInfoSetting.Pop3ServerName;
            // SMTPサーバー名
            this.SmtpServerName_tEdit.Text = mailInfoSetting.SmtpServerName;

            // SMTP認証使用区分:0:使用しない,POP Before SMTP使用区分:0:使用しない
            if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // SMTP認証使用区分:0:使用しない,POP Before SMTP使用区分:1:使用する
            else if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 1)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
            }
            // SMTP認証使用区分:1:POP認証と同じ,POP Before SMTP使用区分:0:使用しない
            else if (mailInfoSetting.SmtpAuthUseDiv == 1 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // SMTP認証使用区分:2:SMTP認証と同じ,POP Before SMTP使用区分:0:使用しない
            else if (mailInfoSetting.SmtpAuthUseDiv == 2 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = true;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // その他の組合せの場合
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }

            // SMTPユーザーID
            this.SmtpUserId_tEdit.Text = mailInfoSetting.SmtpUserId;
            // SMTPパスワード
            this.SmtpPassword_tEdit.Text = mailInfoSetting.SmtpPassword;
            // POPサーバーポート番号            
            this.PopServerPortNo_tNedit.SetInt(mailInfoSetting.PopServerPortNo);
            // SMTPサーバーポート番号
            this.SmtpServerPortNo_tNedit.SetInt(mailInfoSetting.SmtpServerPortNo);
            // メールサーバータイムアウト値
            this.MailServerTimeoutVal_tNedit.SetInt(mailInfoSetting.MailServerTimeoutVal);
            // ファイルパス名
            this.MailSaveBeforeFolder_tEdit.Text = mailInfoSetting.FilePathNm;
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // 入力項目
                    this.SectionName_tEdit.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.SenderName_tEdit.Enabled = true;
                    this.MailAddress_tEdit.Enabled = true;
                    this.Pop3UserId_tEdit.Enabled = true;
                    this.Pop3Password_tEdit.Enabled = true;
                    this.Pop3ServerName_tEdit.Enabled = true;
                    this.SmtpServerName_tEdit.Enabled = true;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = true;
                    this.PopServerPortNo_tNedit.Enabled = true;
                    this.SmtpServerPortNo_tNedit.Enabled = true;
                    this.MailServerTimeoutVal_tNedit.Enabled = true;
                    this.MailSaveBeforeFolder_tEdit.Enabled = true;
                    this.SaveFolder_Button.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case UPDATE_MODE:
                    // 入力項目
                    this.SectionName_tEdit.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SenderName_tEdit.Enabled = true;
                    this.MailAddress_tEdit.Enabled = true;
                    this.Pop3UserId_tEdit.Enabled = true;
                    this.Pop3Password_tEdit.Enabled = true;
                    this.Pop3ServerName_tEdit.Enabled = true;
                    this.SmtpServerName_tEdit.Enabled = true;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = true;
                    this.PopServerPortNo_tNedit.Enabled = true;
                    this.SmtpServerPortNo_tNedit.Enabled = true;
                    this.MailServerTimeoutVal_tNedit.Enabled = true;
                    this.MailSaveBeforeFolder_tEdit.Enabled = true;
                    this.SaveFolder_Button.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged(new object(), new EventArgs());
                    break;
                case DELETE_MODE:
                    // 入力項目
                    this.SectionName_tEdit.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SenderName_tEdit.Enabled = false;
                    this.MailAddress_tEdit.Enabled = false;
                    this.Pop3UserId_tEdit.Enabled = false;
                    this.Pop3Password_tEdit.Enabled = false;
                    this.Pop3ServerName_tEdit.Enabled = false;
                    this.SmtpServerName_tEdit.Enabled = false;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = false;
                    this.SmtpAuthUseDiv1_radioButton.Enabled = false;
                    this.SmtpAuthUseDiv2_radioButton.Enabled = false;
                    this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
                    this.SmtpUserId_tEdit.Enabled = false;
                    this.SmtpPassword_tEdit.Enabled = false;
                    this.PopServerPortNo_tNedit.Enabled = false;
                    this.SmtpServerPortNo_tNedit.Enabled = false;
                    this.MailServerTimeoutVal_tNedit.Enabled = false;
                    this.MailSaveBeforeFolder_tEdit.Enabled = false;
                    this.SaveFolder_Button.Enabled = false;

                    // ボタン
                    this.Ok_Button.Visible = false;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// OK_Button_Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: 保存ボタンクリックイベント</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 保存前データチェック
            if (!IsValueCheck())
            {
                // チェックＮＧの場合処理終了
                return;
            }
            // データ保存
            if (!IsSaveProc())
            {
                // 保存に失敗したときは処理終了
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 保存前データチェックメソッド
        /// </summary>
        /// <returns>チェック結果｛true : チェックＯＫ | false : チェックＮＧ｝</returns>
        /// <remarks>
        /// <br>Note		: 保存前データチェックメソッド</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private bool IsValueCheck()
        {
            string errorMsg = "";	// エラーメッセージ格納
            int setFocusNum = 0;	// フォーカスセットするための区分

            try
            {
                // エラーチェック
                setFocusNum = CheckError(ref errorMsg);
            }
            finally
            {
                if (setFocusNum == 0)
                {
                    // 正常
                }
                else
                {
                    // 警告メッセージの表示
                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							// アセンブリID
                        errorMsg,	                        　　// 表示するメッセージ
                        0,   									// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                    // フォーカスセット
                    SetFocusToComponent(setFocusNum);
                }
            }
            if (setFocusNum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <returns>Status｛成功：true ｜ 失敗：false｝</returns>
        /// <remarks>
        /// <br>Note		: データの保存処理を行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private bool IsSaveProc()
        {
            MailInfoSetting mailInfoSetting = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();
            }

            this.DispToMailInfoSetting(ref mailInfoSetting);

            int status = this._mailInfoSettingAcs.Write(ref mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            "この拠点は既に使用されています。",						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

                        this.SectionName_tEdit.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            "メール送信管理設定",							// プログラム名称
                            "IsSaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "登録に失敗しました。",						// 表示するメッセージ 
                            status,								// ステータス値
                            this._mailInfoSettingAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet展開処理
            MailInfoSettingToDataSet(mailInfoSetting, this.DataIndex);

            return true;

        }

        /// <summary>
        /// エラーチェック処理
        /// </summary>
        /// <param name="errorMsg">エラーメッセージ格納用変数（受け取り時は空）</param>
        /// <returns>フォーカスをセットするコンポーネント</returns>
        /// <remarks>
        /// <br>Note		: コンポーネントにフォーカスをセットします。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		; 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private int CheckError(ref string errorMsg)
        {
            // フォーカスセットするエディットの番号
            int setFocusNum = 0;

            // 拠点が入力されていない場合
            if (this.SectionName_tEdit.DataText.Equals(""))
            {
                errorMsg = "拠点を設定して下さい。";
                setFocusNum = 11;
                return setFocusNum;
            }

            // 差出人名称が入力されていない場合
            if (this.SenderName_tEdit.DataText.Equals(""))
            {
                errorMsg = "差出人名を入力してください。";
                setFocusNum = 1;
                return setFocusNum;
            }
            // 差出人名称にダブルクオテーション（半・全角）が含まれている場合
            if ((this.SenderName_tEdit.DataText.IndexOf('\"') != -1) ||
                (SenderName_tEdit.DataText.IndexOf('”') != -1))
            {
                errorMsg = "差出人名称に「\"」は設定できません。";
                setFocusNum = 2;
                return setFocusNum;
            }
            // メールアドレスが設定されていないとだめ
            if (this.MailAddress_tEdit.DataText.Equals(""))
            {
                errorMsg = "送信元メールアドレスを設定して下さい。";
                setFocusNum = 3;
                return setFocusNum;
            }
            // POP3ユーザーIDが設定されていないとだめ
            if (this.Pop3UserId_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3ユーザーIDを入力してください。";
                setFocusNum = 4;
                return setFocusNum;
            }
            // POP3パスワードが設定されていないとだめ
            if (this.Pop3Password_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3パスワードを入力してください。";
                setFocusNum = 5;
                return setFocusNum;
            }
            // POP3サーバー名が設定されていないとだめ
            if (this.Pop3ServerName_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3サーバー名を入力してください。";
                setFocusNum = 6;
                return setFocusNum;
            }
            // SMTPサーバー名が設定されていないとだめ
            if (this.SmtpServerName_tEdit.DataText.Equals(""))
            {
                errorMsg = "SMTPサーバー名を入力してください。";
                setFocusNum = 7;
                return setFocusNum;
            }
            // SMTP認証使用区分
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv2_radioButton.Checked)
            {
                // SMTPユーザーID
                if (this.SmtpUserId_tEdit.DataText.Equals(""))
                {
                    errorMsg = "SMTPユーザーIDを入力してください。";
                    setFocusNum = 8;
                    return setFocusNum;
                }
                // SMTPパスワード
                else if (this.SmtpPassword_tEdit.DataText.Equals(""))
                {
                    errorMsg = "SMTPパスワードを入力してください。";
                    setFocusNum = 9;
                    return setFocusNum;
                }
            }

            // メール保存用フォルダ
            if (this.MailSaveBeforeFolder_tEdit.DataText.Equals(""))
            {
                errorMsg = "メール保存用フォルダを設定して下さい。";
                setFocusNum = 10;
                return setFocusNum;
            }

            // メール保存フォルダ有効チェック
            if (!Directory.Exists(this.MailSaveBeforeFolder_tEdit.DataText))
            {
                errorMsg = "メール保存用フォルダが無効です。";
                setFocusNum = 10;
                return setFocusNum;
            }

            return setFocusNum;
        }

        /// <summary>
        /// フォーカスセット処理
        /// </summary>
        /// <param name="setFocusNum">フォーカスセットするコンポーネント番号</param>
        /// <remarks>
        /// <br>Note		: コンポーネントにフォーカスをセットします。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		; 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private void SetFocusToComponent(int setFocusNum)
        {
            // フォーカスセット
            switch (setFocusNum)
            {
                case 11:
                    {
                        // 拠点
                        this.SectionName_tEdit.Focus();
                        break;
                    }
                case 1:
                    {
                        // 差出人名
                        this.SenderName_tEdit.Focus();
                        break;
                    }
                case 2:
                    {
                        // 差出人名
                        this.SenderName_tEdit.Focus();
                        break;
                    }
                case 3:
                    {
                        // メールアドレス
                        this.MailAddress_tEdit.Focus();
                        break;
                    }
                case 4:
                    {
                        // POP3ユーザーID
                        this.Pop3UserId_tEdit.Focus();
                        break;
                    }
                case 5:
                    {
                        // POP3パスワード
                        this.Pop3Password_tEdit.Focus();
                        break;
                    }
                case 6:
                    {
                        // POP3サーバー名
                        this.Pop3ServerName_tEdit.Focus();
                        break;
                    }
                case 7:
                    {
                        // SMTPサーバー名
                        this.SmtpServerName_tEdit.Focus();
                        break;
                    }
                case 8:
                    {
                        // SMTPユーザーID
                        this.SmtpUserId_tEdit.Focus();
                        break;
                    }
                case 9:
                    {
                        // SMTPパスワード
                        this.SmtpPassword_tEdit.Focus();
                        break;
                    }
                case 10:
                    {
                        // メール保存先フォルダ
                        this.MailSaveBeforeFolder_tEdit.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "既に他端末より更新されています。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            "既に他端末より削除されています。",	    // 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._dataIndex = -1;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// SMTP POP サーバー認証チェック用
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : SMTP POP サーバー認証チェック用</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private string AuthenticationCheck(int status)
        {
            string message = "";
            switch (status)
            {
                case 0:
                case 1:
                    message = "SMTP POP サーバー認証に成功しました。";
                    break;
                case 3:
                    message = "POP認証エラー" + "\n" + "受信メールサーバー(POP3)に接続できませんでした。"
                        + "\n" + "サーバー名、ポート番号、ウイルススキャンの設定を確認してください。";
                    break;
                case 5:
                    message = "接続エラー" + "\n" + "送信メールサーバー(SMTP)に接続できませんでした。"
                        + "\n" + "サーバー名、ポート番号、ウイルススキャンの設定を確認してください。";
                    break;
                case 7:
                    message = "応答エラー";
                    break;
                case 9:
                    message = "エラー";
                    break;
                default:
                    break;
            }
            return message;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///　送受信対象拠点の存在チェック
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 送受信対象拠点の存在チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/05/24</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            bool status = false;

            if (this.DataIndex > 0 || this._indexBuf == -2)
            {
                return status;
            }

            string iMsg1 = "入力されたコードのメール情報設定が既に登録されています。\n\n編集を行いますか？";
            string iMsg2 = "入力されたコードのメール情報設定は既に削除されています。";

            string sectionCode = this.SectionName_tEdit.DataText.Trim().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string section = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE];

                if (sectionCode.Equals(section.Trim().PadLeft(2, '0')))
                {
                    // 入力されたコードは削除状態場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != string.Empty)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg2, 0, MessageBoxButtons.OK);

                        this.SectionName_tEdit.Clear();

                        return true;
                    }

                    // 入力されたコードが存在場合
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg1, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this.DataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            break;

                        case DialogResult.No:
                            this.SectionName_tEdit.Clear();
                            break;
                    }
                    return true;
                }
            }
            return status;
        }
        #endregion Private Method End

        # region Control Events
        /// <summary>
        ///	Form.Load イベント(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する			
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Close_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Close_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SaveFolder_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 画面初期設定処理
            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.VisibleChanged イベント(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	画面の表示、非表示が変わった時に発生します。</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();

                return;
            }

            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            timer1.Enabled = true;

            ScreenClear();
        }

        /// <summary>
        ///	Form.Load イベント(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void Close_Button_Click(object sender, System.EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                MailInfoSetting compareMailInfoSetting = new MailInfoSetting();
                compareMailInfoSetting = this._mailInfoSettingClone.Clone();
                //現在の画面情報を取得する
                DispToMailInfoSetting(ref compareMailInfoSetting);
                //最初に取得した画面情報と比較
                if (!(this._mailInfoSettingClone.Equals(compareMailInfoSetting)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!IsValueCheck() || !IsSaveProc())
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Close_Button.Focus();
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;
            this._preSectionCode = string.Empty;
            this._preSectionName = string.Empty;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Form.Closingイベント(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: フォームクローズ時のイベントです</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// タイマー処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	タイマー処理</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// SMTP認証区分使用チェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	SMTP認証区分使用チェックチェンジ処理</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                this.SmtpAuthUseDiv1_radioButton.Enabled = true;
                this.SmtpAuthUseDiv2_radioButton.Enabled = true;
                this.PopBeforeSmtpUseDiv_radioButton.Enabled = true;
                // SMTP認証使用 :POP認証と同じID・パスワードを使用する
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    this.SmtpUserId_tEdit.Text = this.Pop3UserId_tEdit.Text;
                    this.SmtpPassword_tEdit.Text = this.Pop3Password_tEdit.Text;
                }
                // SMTP認証使用 :SMTP認証のID・パスワードを使用する
                if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    this.SmtpUserId_tEdit.Enabled = true;
                    this.SmtpPassword_tEdit.Enabled = true;
                }
            }
            else
            {
                this.SmtpAuthUseDiv1_radioButton.Enabled = false;
                this.SmtpAuthUseDiv2_radioButton.Enabled = false;
                this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
        }

        /// <summary>
        /// SMTP認証区分使用ラジオボタンチェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	SMTP認証区分使用ラジオボタンチェックチェンジ処理</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv1_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SmtpAuthUseDiv1_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
                this.SmtpUserId_tEdit.Text = this.Pop3UserId_tEdit.Text;
                this.SmtpPassword_tEdit.Text = this.Pop3Password_tEdit.Text;
            }
        }

        /// <summary>
        /// SMTP認証区分使用ラジオボタンチェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	SMTP認証区分使用ラジオボタンチェックチェンジ処理</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv2_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SmtpAuthUseDiv2_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Enabled = true;
                this.SmtpPassword_tEdit.Enabled = true;
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
            else
            {
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// POP Before SMTP使用区分チェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	POP Before SMTP使用区分チェックチェンジ処理</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PopBeforeSmtpUseDiv_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PopBeforeSmtpUseDiv_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
        }

        /// <summary>
        /// Check_Buttonクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	Check_Buttonクリックイベント</br>
        /// <br>Programmer		:	李占川</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void Check_Button_Click(object sender, EventArgs e)
        {
            // 処理中はカーソルをWaitに設定
            this.Cursor = Cursors.WaitCursor;

            // 送信側SMTPサーバー認証
            TSMTP tSmtp = new TSMTP();

            // サーバー情報セット(SMTPサーバー)
            tSmtp.ServerInfo.POPPort = this.PopServerPortNo_tNedit.GetInt();
            tSmtp.ServerInfo.POPServer = this.Pop3ServerName_tEdit.Text;
            tSmtp.ServerInfo.POPTimeOut = this.MailServerTimeoutVal_tNedit.GetInt();
            tSmtp.ServerInfo.SMTPPort = this.SmtpServerPortNo_tNedit.GetInt();
            tSmtp.ServerInfo.SMTPServer = this.SmtpServerName_tEdit.Text;
            tSmtp.ServerInfo.SMTPTimeOut = this.MailServerTimeoutVal_tNedit.GetInt();

            // ユーザー認証情報セット
            tSmtp.AuthorizationInfo.PopAccount = this.Pop3UserId_tEdit.Text;
            tSmtp.AuthorizationInfo.PopPassWord = this.Pop3Password_tEdit.Text;
            tSmtp.AuthorizationInfo.SmtpAccount = this.SmtpUserId_tEdit.Text;
            tSmtp.AuthorizationInfo.SmtpPassWord = this.SmtpPassword_tEdit.Text;

            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    // POP Before SMTP型認証を設定
                    tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.POPBeforeSMTP;
                }
                else
                {
                    // SMTP AUTH と POP Before SMT を自動でトライしてくれる設定
                    tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.Auto;
                }
            }
            else
            {
                // 認証使用無し
                tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.None;
            }

            // トレース
            tSmtp.TraceOptions.Trace = false;
            tSmtp.TraceOptions.TraceLog = false;
            tSmtp.TraceOptions.TraceLogPath = "c:\\smtp.log";

            // ダイアログ表示
            tSmtp.ProgressDialog = true;
            tSmtp.DialogConfirm = false;

            // 接続チェック
            int smtpStatus = tSmtp.CheckServerConnection();

            // 認証エラーメッセージ表示
            string smtpMessage = this.AuthenticationCheck(smtpStatus);
            if (smtpStatus > 1)
            {
                switch (smtpStatus)
                {
                    case 7:
                    case 9:
                        TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    ASSEMBLY_ID,							// アセンブリID
                                    smtpMessage + "\n"
                                    + tSmtp.StatusMessage,              　　// 表示するメッセージ
                                    tSmtp.Status,							// ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    default:
                        TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ASSEMBLY_ID,							// アセンブリID
                        smtpMessage,                        　　// 表示するメッセージ
                        tSmtp.Status,							// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                        break;
                }
            }
            else
            {
                // SMTPの認証が成功している場合受信側の認証チェックを行う
                // 受信側POPサーバー認証
                TPOP tPop = new TPOP();

                tPop.Logout();

                // 受信方式設定
                tPop.MailOptions.ReceiveMethodEnumType = ReceiveMethodEnumTypes.Synchronous;

                // トレースオプションの設定
                tPop.TraceOptions.Trace = false;
                tPop.TraceOptions.TraceLog = false;
                tPop.TraceOptions.TraceLogPath = "c:\\pop.log";

                // ダイアログ関連設定
                tPop.ProgressDialog = true;
                tPop.DialogConfirm = false;

                // POP3サーバーの設定を行います。
                tPop.ServerInfo.POPServer = this.Pop3ServerName_tEdit.Text;
                tPop.ServerInfo.POPPort = this.PopServerPortNo_tNedit.GetInt();

                // POP3の認証に関する設定を行います。
                tPop.AuthorizationInfo.Account = this.Pop3UserId_tEdit.Text;
                tPop.AuthorizationInfo.PassWord = this.Pop3Password_tEdit.Text;
                tPop.AuthorizationInfo.AuthType = TPOP.AuthorizationTypes.Auto;

                //  接続チェック
                int popStatus = tPop.CheckServerConnection();

                // 認証エラーメッセージ表示
                string popMessage = this.AuthenticationCheck(popStatus);
                if (popStatus > 1)
                {
                    switch (popStatus)
                    {
                        case 9:
                            // エラー
                            TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    ASSEMBLY_ID,							// アセンブリID
                                    popMessage + "\n"
                                    + tPop.StatusMessage,              　　 // 表示するメッセージ
                                    tPop.Status,							// ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン
                            break;
                        default:
                            // エラー
                            TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                 ASSEMBLY_ID,							// アセンブリID
                                 popMessage,                        　　// 表示するメッセージ
                                 tPop.Status,							// ステータス値
                                 MessageBoxButtons.OK);					// 表示するボタン
                            break;
                    }
                }
                else
                {
                    // 成功
                    TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                ASSEMBLY_ID,							// アセンブリID
                                popMessage,                        　　 // 表示するメッセージ
                                tPop.Status,							// ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                }
            }
            // カーソルをDefaultに戻す
            this.Cursor = Cursors.Default;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.SectionName_tEdit.Text = secInfoSet.SectionCode.Trim();

                    if (this.ModeChangeProc())
                    {
                        return;
                    }

                    string sectionName;
                    this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, secInfoSet.SectionCode.Trim());
                    this.SectionName_tEdit.DataText = sectionName.Trim();
                    this._preSectionCode = secInfoSet.SectionCode.Trim();
                    this._preSectionName = this.SectionName_tEdit.Text;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(SaveFolder_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : メール保存先フォルダボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void SaveFolder_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "メール保存用フォルダ選択";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    MailSaveBeforeFolder_tEdit.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,    // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.Yes)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            MailInfoSetting mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();

            // メール情報設定マスタ削除処理
            int status = this._mailInfoSettingAcs.Delete(mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._mailInfoSettingTable.Remove(mailInfoSetting.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._mailInfoSettingAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // 確認メッセージ
            DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,                       // エラーレベル
                ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                "現在表示中のメール情報設定マスタを復活します。" + "\r\n"
                + "よろしいですか？", 					              // 表示するメッセージ
                0, 					                                  // ステータス値
                MessageBoxButtons.YesNo);	                          // 表示するボタン

            if (res != DialogResult.Yes)
            {
                this.Revive_Button.Focus();
                return;
            }

            // 復活対象データ取得
            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            MailInfoSetting mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();

            // メール情報設定マスタ論理削除復活処理
            int status = this._mailInfoSettingAcs.Revival(ref mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        MailInfoSettingToDataSet(mailInfoSetting, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._mailInfoSettingAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : フォーカスローストときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/05/24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.SectionName_tEdit)
            {
                // 送受信対象拠点の存在チェック
                if (this.ModeChangeProc())
                {
                    return;
                }
                bool flag = true;
                try
                {
                    // 拠点コード取得
                    string sectionCode = this.SectionName_tEdit.DataText.Trim();

                    if (sectionCode.Trim().Equals(""))
                    {
                        this.SectionName_tEdit.DataText = string.Empty;
                        this._preSectionCode = string.Empty;
                        this._preSectionName = string.Empty;
                        flag = false;
                        return;
                    }

                    if (sectionCode.Trim().Equals(this._preSectionName))
                    {
                        flag = false;
                        return;
                    }

                    // 拠点名称取得
                    string sectionName;
                    int st = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, sectionCode);
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.SectionName_tEdit.Text = sectionName;
                        this._preSectionCode = sectionCode;
                        this._preSectionName = sectionName;
                        flag = true;
                    }
                    else
                    {
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                ASSEMBLY_ID,							// アセンブリID
                                "指定した拠点コードは存在しません。",	// 表示するメッセージ
                                0,									    // ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン

                        this.SectionName_tEdit.Text = this._preSectionName;
                        flag = false;
                    }
                }
                finally
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (flag)
                            {
                                // フォーカス設定
                                e.NextCtrl = this.SenderName_tEdit;
                            }
                            else
                            {
                                // フォーカス設定
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                    }
                }
            }
        }
        #endregion Control Events End
    }
}
