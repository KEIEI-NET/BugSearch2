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
using Broadleaf.Library.Text;
using Broadleaf.Library.Net.Mail;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// メール送信管理設定クラス
	/// </summary>
	/// <remarks>
	/// <br>note		: メール送信管理設定を行います
	///					: IMasterMaintenanceSingleTypeを実装しています</br>
	/// <br>Programer	: 22013 久保 将太</br>
	/// <br>Date		: 2005.04.15</br>
	/// <br></br>
	/// <br>Update Note : 2005.06.13 22024 寺坂 誉志</br>
	/// <br>            : ①携帯メール文書最大サイズにて0表示される様に変更</br>
	/// <br>            : ②署名ファイル名称にフォーカス遷移するバグ対応（コンポーネントバグ？）</br>
	/// <br>Update Note : 2005.06.21 22024 寺坂 誉志</br>
	/// <br>            : ①Viewの"未設定"表示を""に変更</br>
	/// <br>Update Note : 2005.06.21 22024 寺坂　誉志</br>
	/// <br>            : ①CatchMouse、TNedit(ZeroSupp、ImeMode)、HotTracking</br>
	/// <br>Update Note : 2005.06.27 22024 寺坂　誉志</br>
	/// <br>            : ①閉じるボタン上で↓キーや→キー入力時にフォーカス遷移しないように修正</br>
	/// <br>Update Note : 2005.07.05 23013 牧　将人</br>
	/// <br>            : フレームの最終最小化対応</br>
	/// <br>			: ArrowKeyControlのCatchMouseプロパティをTrueに設定</br>
	/// <br>Update Note : 2005.07.06 23013 牧 将人</br>
	/// <br>					・排他制御処理　排他がかかったとき、statusを表示しないよう修正</br>
	/// <br>Update Note : 2005.07.08 23013 牧 将人</br>
	/// <br>					・エラーメッセージが出た時UI画面を閉じる処理</br>
	/// <br>Update Note : 2005.07.11 23013 牧 将人</br>
	/// <br>					・排他制御処理の中に最小化対応を追加</br>
	/// <br>Update Note : 2005.09.03 23006 高橋 明子</br>
	/// <br>					・閉じるボタンへのフォーカスセット処理</br>
    /// <br>Update Note : 2005.09.08  23006 高橋 明子</br>
	/// <br>				    ・企業コード取得処理</br>
	/// <br>Update Note : 2005.09.24  23006 高橋 明子</br>
	/// <br>				    ・TMsgDisp部品対応</br>
	/// <br>Update Note : 2005.10.06  23006 高橋 明子</br>
	/// <br>				    ・ガイドボタン実装対応</br>
	/// <br>Update Note : 2005.10.19  23006 高橋 明子</br>
	/// <br>				    ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br>Update Note : 2006.07.26  23006 高橋 明子</br>
    /// <br>                    ・ブラッシュアップ対応</br>
    /// <br>Update Note : 2006.11.06  23013 牧　将人</br>
    /// <br>                    ・項目追加・UI画面・マスメンタイプ大幅変更</br>
    /// </remarks>
    public class SFDML09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel MailAddress_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3UserId_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3Password_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3ServerName_Label;
		private Infragistics.Win.Misc.UltraLabel SmtpServerName_Label;
		private Infragistics.Win.Misc.UltraLabel SenderName_Label;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
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
        private Infragistics.Win.Misc.UltraLabel BackupFormal_Label;
        private Infragistics.Win.Misc.UltraLabel MailServerTimeoutVal_Label;
        private Infragistics.Win.Misc.UltraLabel PopServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel MailSendDivUnitCnt_Label;
        private TNedit MailServerTimeoutVal_tNedit;
        private TNedit SmtpServerPortNo_tNedit;
        private TNedit PopServerPortNo_tNedit;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SmtpAuthUseDiv_ultraCheckEditor;
        private RadioButton SmtpAuthUseDiv1_radioButton;
        private RadioButton PopBeforeSmtpUseDiv_radioButton;
        private RadioButton SmtpAuthUseDiv2_radioButton;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor BackupSendDivCd_ultraCheckEditor;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor MailSendDivUnitCnt_ultraCheckEditor;
        private TNedit MailSendDivUnitCnt_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel SelectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TEdit SectionName_tEdit;
        private TEdit SectionCode_tEdit;
        private TComboEditor BackupFormal_tComboEditor;
        private Infragistics.Win.Misc.UltraButton Check_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region コンストラクタ
		/// <summary>
		/// SFDML09060Uコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: メール送信管理設定コンストラクタです</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		public SFDML09060UA()
		{
			InitializeComponent();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = false;
            this._canDelete = false;
            this._canLogicalDeleteDataExtraction = false;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            this._nextData = false;
            this._totalCount = 0;

			// mailSndMngクラス
			this._mailSndMng = new MailSndMng();
			// mailSndMngクラスアクセスクラス
			this._mailSndMngAcs = new MailSndMngAcs();            

            this._mailSndMngTable = new Hashtable();

			//　企業コードを取得する
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// 印刷可能フラグを設定します。
			// Frameの印刷ボタンの表示非表示の制御に使用します。
			this._canPrint = false;

            this._indexBuf = -2;
		}
		#endregion

		#region Private Member
		/// <summary>
		/// グローバル変数・定数宣言
		/// </summary>
		private MailSndMng _mailSndMng;
		private MailSndMngAcs _mailSndMngAcs;
		private MailSndMng mailSndMngClone; // データ比較用        
		private string enterpriseCode;

        //HashTable
        private Hashtable _mailSndMngTable;

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

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE                = "削除日";                
        private const string VIEW_SECTIONNAME           = "拠点名称";
        private const string VIEW_SENDERNAME            = "差出人名";
        private const string VIEW_MAILADDRESS           = "メールアドレス";
        private const string VIEW_POP3USERID            = "POP3ユーザーID";
        private const string VIEW_POP3PASSWORD          = "POP3パスワード";
        private const string VIEW_POP3SERVERNAME        = "POP3サーバー名";
        private const string VIEW_SMTPSERVERNAME        = "SMTPサーバー名";
        private const string VIEW_SMTPAUTHUSEDIV        = "SMTP認証使用";
        private const string VIEW_SMTPUSERID            = "SMTPユーザーID";
        private const string VIEW_SMTPPASSWORD          = "SMTPパスワード";
        private const string VIEW_POPBEFORESMTPUSEDIV   = "受信メールサーバーにログオン";
        private const string VIEW_POPSERVERPORTNO       = "POPサーバー ポート番号";
        private const string VIEW_SMTPSERVERPORTNO      = "SMTPサーバー ポート番号";
        private const string VIEW_MAILSERVERTIMEOUTVAL  = "メールサーバータイムアウト値";
        private const string VIEW_BACKUPSENDDIVCD       = "バックアップ送信区分";
        private const string VIEW_BACKUPFORMAL          = "バックアップ形式";
        private const string VIEW_MAILSENDDIVUNITCNT    = "メール送信分割単位件数";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

		private const string HTML_HEADER_TITLE	= "設定項目";
		private const string HTML_HEADER_VALUE	= "設定値";
////////////////////////////////////////////// 2005.06.21 TERASAKA DEL STA //
//		private const string HTML_UNREGISTER	= "未設定";
// 2005.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.21 TERASAKA ADD STA //
		private const string HTML_UNREGISTER	= "";
// 2005.06.21 TERASAKA ADD END //////////////////////////////////////////////

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

        // 2006.11.06 Maki Del
		// 定数
		//private const string UNITOFCHAR	 = "字（半角）";

        private int _indexBuf;

		#endregion

		#region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            this.MailAddress_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3UserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3Password_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3ServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SenderName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
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
            this.BackupFormal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailServerTimeoutVal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailSendDivUnitCnt_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MailServerTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpAuthUseDiv_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SmtpAuthUseDiv1_radioButton = new System.Windows.Forms.RadioButton();
            this.SmtpAuthUseDiv2_radioButton = new System.Windows.Forms.RadioButton();
            this.PopBeforeSmtpUseDiv_radioButton = new System.Windows.Forms.RadioButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BackupSendDivCd_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.MailSendDivUnitCnt_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.MailSendDivUnitCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.SelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BackupFormal_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
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
            ((System.ComponentModel.ISupportInitialize)(this.MailSendDivUnitCnt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupFormal_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // MailAddress_Label
            // 
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance7.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColor = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(685, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // Ok_Button
            // 
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(545, 620);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
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
            this.Close_Button.UseHotTracking= Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(670, 620);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 22;
            this.Close_Button.Text = "閉じる(&X)";
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // MailAddress_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlign = Infragistics.Win.HAlign.Left;
            this.MailAddress_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlign = Infragistics.Win.HAlign.Left;
            this.MailAddress_tEdit.Appearance = appearance9;
            this.MailAddress_tEdit.AutoSelect = true;
            this.MailAddress_tEdit.DataText = "";
            this.MailAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.MailAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailAddress_tEdit.Location = new System.Drawing.Point(210, 105);
            this.MailAddress_tEdit.MaxLength = 64;
            this.MailAddress_tEdit.Name = "MailAddress_tEdit";
            this.MailAddress_tEdit.Size = new System.Drawing.Size(523, 24);
            this.MailAddress_tEdit.TabIndex = 2;
            // 
            // Pop3UserId_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3UserId_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3UserId_tEdit.Appearance = appearance11;
            this.Pop3UserId_tEdit.AutoSelect = true;
            this.Pop3UserId_tEdit.DataText = "";
            this.Pop3UserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3UserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3UserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3UserId_tEdit.Location = new System.Drawing.Point(210, 140);
            this.Pop3UserId_tEdit.MaxLength = 64;
            this.Pop3UserId_tEdit.Name = "Pop3UserId_tEdit";
            this.Pop3UserId_tEdit.Size = new System.Drawing.Size(523, 24);
            this.Pop3UserId_tEdit.TabIndex = 3;
            // 
            // Pop3Password_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3Password_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3Password_tEdit.Appearance = appearance13;
            this.Pop3Password_tEdit.AutoSelect = true;
            this.Pop3Password_tEdit.DataText = "";
            this.Pop3Password_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3Password_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3Password_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3Password_tEdit.Location = new System.Drawing.Point(210, 175);
            this.Pop3Password_tEdit.MaxLength = 24;
            this.Pop3Password_tEdit.Name = "Pop3Password_tEdit";
            this.Pop3Password_tEdit.PasswordChar = '*';
            this.Pop3Password_tEdit.Size = new System.Drawing.Size(203, 24);
            this.Pop3Password_tEdit.TabIndex = 4;
            // 
            // Pop3ServerName_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3ServerName_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3ServerName_tEdit.Appearance = appearance15;
            this.Pop3ServerName_tEdit.AutoSelect = true;
            this.Pop3ServerName_tEdit.DataText = "";
            this.Pop3ServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3ServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3ServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3ServerName_tEdit.Location = new System.Drawing.Point(210, 210);
            this.Pop3ServerName_tEdit.MaxLength = 64;
            this.Pop3ServerName_tEdit.Name = "Pop3ServerName_tEdit";
            this.Pop3ServerName_tEdit.Size = new System.Drawing.Size(523, 24);
            this.Pop3ServerName_tEdit.TabIndex = 5;
            // 
            // SmtpServerName_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpServerName_tEdit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpServerName_tEdit.Appearance = appearance17;
            this.SmtpServerName_tEdit.AutoSelect = true;
            this.SmtpServerName_tEdit.DataText = "";
            this.SmtpServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpServerName_tEdit.Location = new System.Drawing.Point(210, 245);
            this.SmtpServerName_tEdit.MaxLength = 64;
            this.SmtpServerName_tEdit.Name = "SmtpServerName_tEdit";
            this.SmtpServerName_tEdit.Size = new System.Drawing.Size(523, 24);
            this.SmtpServerName_tEdit.TabIndex = 6;
            // 
            // SenderName_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SenderName_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SenderName_tEdit.Appearance = appearance19;
            this.SenderName_tEdit.AutoSelect = true;
            this.SenderName_tEdit.DataText = "";
            this.SenderName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SenderName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SenderName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SenderName_tEdit.Location = new System.Drawing.Point(210, 70);
            this.SenderName_tEdit.MaxLength = 32;
            this.SenderName_tEdit.Name = "SenderName_tEdit";
            this.SenderName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SenderName_tEdit.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SmtpUserId_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpUserId_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpUserId_tEdit.Appearance = appearance45;
            this.SmtpUserId_tEdit.AutoSelect = true;
            this.SmtpUserId_tEdit.DataText = "";
            this.SmtpUserId_tEdit.Enabled = false;
            this.SmtpUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpUserId_tEdit.Location = new System.Drawing.Point(210, 380);
            this.SmtpUserId_tEdit.MaxLength = 64;
            this.SmtpUserId_tEdit.Name = "SmtpUserId_tEdit";
            this.SmtpUserId_tEdit.Size = new System.Drawing.Size(523, 24);
            this.SmtpUserId_tEdit.TabIndex = 10;
            // 
            // SmtpPassword_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpPassword_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpPassword_tEdit.Appearance = appearance47;
            this.SmtpPassword_tEdit.AutoSelect = true;
            this.SmtpPassword_tEdit.DataText = "";
            this.SmtpPassword_tEdit.Enabled = false;
            this.SmtpPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpPassword_tEdit.Location = new System.Drawing.Point(210, 415);
            this.SmtpPassword_tEdit.MaxLength = 24;
            this.SmtpPassword_tEdit.Name = "SmtpPassword_tEdit";
            this.SmtpPassword_tEdit.PasswordChar = '*';
            this.SmtpPassword_tEdit.Size = new System.Drawing.Size(203, 24);
            this.SmtpPassword_tEdit.TabIndex = 11;
            // 
            // SmtpPassword_Label
            // 
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance49.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SmtpUserId_Label.Appearance = appearance49;
            this.SmtpUserId_Label.Enabled = false;
            this.SmtpUserId_Label.Location = new System.Drawing.Point(65, 380);
            this.SmtpUserId_Label.Name = "SmtpUserId_Label";
            this.SmtpUserId_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpUserId_Label.TabIndex = 25;
            this.SmtpUserId_Label.Tag = "13";
            this.SmtpUserId_Label.Text = "SMTPユーザーID";
            // 
            // BackupFormal_Label
            // 
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.BackupFormal_Label.Appearance = appearance40;
            this.BackupFormal_Label.Enabled = false;
            this.BackupFormal_Label.Location = new System.Drawing.Point(455, 520);
            this.BackupFormal_Label.Name = "BackupFormal_Label";
            this.BackupFormal_Label.Size = new System.Drawing.Size(180, 23);
            this.BackupFormal_Label.TabIndex = 36;
            this.BackupFormal_Label.Tag = "16";
            this.BackupFormal_Label.Text = "バックアップ形式";
            // 
            // MailServerTimeoutVal_Label
            // 
            appearance41.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MailServerTimeoutVal_Label.Appearance = appearance41;
            this.MailServerTimeoutVal_Label.Location = new System.Drawing.Point(65, 560);
            this.MailServerTimeoutVal_Label.Name = "MailServerTimeoutVal_Label";
            this.MailServerTimeoutVal_Label.Size = new System.Drawing.Size(210, 23);
            this.MailServerTimeoutVal_Label.TabIndex = 35;
            this.MailServerTimeoutVal_Label.Tag = "16";
            this.MailServerTimeoutVal_Label.Text = "メールサーバータイムアウト";
            // 
            // PopServerPortNo_Label
            // 
            appearance42.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance43.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SmtpServerPortNo_Label.Appearance = appearance43;
            this.SmtpServerPortNo_Label.Location = new System.Drawing.Point(65, 525);
            this.SmtpServerPortNo_Label.Name = "SmtpServerPortNo_Label";
            this.SmtpServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.SmtpServerPortNo_Label.TabIndex = 32;
            this.SmtpServerPortNo_Label.Tag = "16";
            this.SmtpServerPortNo_Label.Text = "SMTPサーバー ポート番号";
            // 
            // MailSendDivUnitCnt_Label
            // 
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MailSendDivUnitCnt_Label.Appearance = appearance39;
            this.MailSendDivUnitCnt_Label.Enabled = false;
            this.MailSendDivUnitCnt_Label.Location = new System.Drawing.Point(455, 585);
            this.MailSendDivUnitCnt_Label.Name = "MailSendDivUnitCnt_Label";
            this.MailSendDivUnitCnt_Label.Size = new System.Drawing.Size(180, 23);
            this.MailSendDivUnitCnt_Label.TabIndex = 37;
            this.MailSendDivUnitCnt_Label.Tag = "16";
            this.MailSendDivUnitCnt_Label.Text = "メール送信分割単位件数";
            // 
            // PopServerPortNo_tNedit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.TextHAlign = Infragistics.Win.HAlign.Right;
            this.PopServerPortNo_tNedit.ActiveAppearance = appearance37;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlign = Infragistics.Win.HAlign.Right;
            this.PopServerPortNo_tNedit.Appearance = appearance38;
            this.PopServerPortNo_tNedit.AutoSelect = true;
            this.PopServerPortNo_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
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
            this.PopServerPortNo_tNedit.TabIndex = 13;
            // 
            // SmtpServerPortNo_tNedit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance35.TextHAlign = Infragistics.Win.HAlign.Right;
            this.SmtpServerPortNo_tNedit.ActiveAppearance = appearance35;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextHAlign = Infragistics.Win.HAlign.Right;
            this.SmtpServerPortNo_tNedit.Appearance = appearance36;
            this.SmtpServerPortNo_tNedit.AutoSelect = true;
            this.SmtpServerPortNo_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
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
            this.SmtpServerPortNo_tNedit.TabIndex = 14;
            // 
            // MailServerTimeoutVal_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailServerTimeoutVal_tNedit.ActiveAppearance = appearance33;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailServerTimeoutVal_tNedit.Appearance = appearance34;
            this.MailServerTimeoutVal_tNedit.AutoSelect = true;
            this.MailServerTimeoutVal_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.MailServerTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailServerTimeoutVal_tNedit.DataText = "";
            this.MailServerTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailServerTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.MailServerTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailServerTimeoutVal_tNedit.Location = new System.Drawing.Point(285, 560);
            this.MailServerTimeoutVal_tNedit.MaxLength = 4;
            this.MailServerTimeoutVal_tNedit.Name = "MailServerTimeoutVal_tNedit";
            this.MailServerTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailServerTimeoutVal_tNedit.Size = new System.Drawing.Size(44, 24);
            this.MailServerTimeoutVal_tNedit.TabIndex = 15;
            // 
            // SmtpAuthUseDiv_ultraCheckEditor
            // 
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.SmtpAuthUseDiv_ultraCheckEditor.Appearance = appearance32;
            this.SmtpAuthUseDiv_ultraCheckEditor.Location = new System.Drawing.Point(25, 290);
            this.SmtpAuthUseDiv_ultraCheckEditor.Name = "SmtpAuthUseDiv_ultraCheckEditor";
            this.SmtpAuthUseDiv_ultraCheckEditor.Size = new System.Drawing.Size(260, 20);
            this.SmtpAuthUseDiv_ultraCheckEditor.TabIndex = 7;
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
            this.SmtpAuthUseDiv1_radioButton.TabIndex = 8;
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
            this.SmtpAuthUseDiv2_radioButton.TabIndex = 9;
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
            this.PopBeforeSmtpUseDiv_radioButton.TabIndex = 12;
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
            // BackupSendDivCd_ultraCheckEditor
            // 
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.BackupSendDivCd_ultraCheckEditor.Appearance = appearance31;
            this.BackupSendDivCd_ultraCheckEditor.Location = new System.Drawing.Point(400, 490);
            this.BackupSendDivCd_ultraCheckEditor.Name = "BackupSendDivCd_ultraCheckEditor";
            this.BackupSendDivCd_ultraCheckEditor.Size = new System.Drawing.Size(305, 20);
            this.BackupSendDivCd_ultraCheckEditor.TabIndex = 16;
            this.BackupSendDivCd_ultraCheckEditor.Text = "自社アドレスにバックアップを送信する";
            this.BackupSendDivCd_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.BackupSendDivCd_ultraCheckEditor_CheckedChanged);
            // 
            // MailSendDivUnitCnt_ultraCheckEditor
            // 
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.MailSendDivUnitCnt_ultraCheckEditor.Appearance = appearance30;
            this.MailSendDivUnitCnt_ultraCheckEditor.Location = new System.Drawing.Point(400, 555);
            this.MailSendDivUnitCnt_ultraCheckEditor.Name = "MailSendDivUnitCnt_ultraCheckEditor";
            this.MailSendDivUnitCnt_ultraCheckEditor.Size = new System.Drawing.Size(200, 20);
            this.MailSendDivUnitCnt_ultraCheckEditor.TabIndex = 18;
            this.MailSendDivUnitCnt_ultraCheckEditor.Text = "メール送信自動分割する";
            this.MailSendDivUnitCnt_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.MailSendDivUnitCnt_ultraCheckEditor_CheckedChanged);
            // 
            // MailSendDivUnitCnt_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailSendDivUnitCnt_tNedit.ActiveAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailSendDivUnitCnt_tNedit.Appearance = appearance29;
            this.MailSendDivUnitCnt_tNedit.AutoSelect = true;
            this.MailSendDivUnitCnt_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.MailSendDivUnitCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailSendDivUnitCnt_tNedit.DataText = "";
            this.MailSendDivUnitCnt_tNedit.Enabled = false;
            this.MailSendDivUnitCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailSendDivUnitCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MailSendDivUnitCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailSendDivUnitCnt_tNedit.Location = new System.Drawing.Point(645, 585);
            this.MailSendDivUnitCnt_tNedit.MaxLength = 3;
            this.MailSendDivUnitCnt_tNedit.Name = "MailSendDivUnitCnt_tNedit";
            this.MailSendDivUnitCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailSendDivUnitCnt_tNedit.Size = new System.Drawing.Size(36, 24);
            this.MailSendDivUnitCnt_tNedit.TabIndex = 19;
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
            appearance27.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.Appearance = appearance27;
            this.ultraLabel3.Location = new System.Drawing.Point(330, 560);
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
            appearance26.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SelectionCode_Title_Label.Appearance = appearance26;
            this.SelectionCode_Title_Label.BackColor = System.Drawing.Color.Transparent;
            this.SelectionCode_Title_Label.Location = new System.Drawing.Point(65, 25);
            this.SelectionCode_Title_Label.Name = "SelectionCode_Title_Label";
            this.SelectionCode_Title_Label.Size = new System.Drawing.Size(135, 23);
            this.SelectionCode_Title_Label.TabIndex = 118;
            this.SelectionCode_Title_Label.Text = "拠点名称";
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
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SectionName_tEdit.ActiveAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SectionName_tEdit.Appearance = appearance25;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 29, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(210, 25);
            this.SectionName_tEdit.MaxLength = 29;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(242, 24);
            this.SectionName_tEdit.TabIndex = 120;
            // 
            // SectionCode_tEdit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionCode_tEdit.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionCode_tEdit.Appearance = appearance23;
            this.SectionCode_tEdit.AutoSelect = true;
            this.SectionCode_tEdit.DataText = "";
            this.SectionCode_tEdit.Enabled = false;
            this.SectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionCode_tEdit.Location = new System.Drawing.Point(455, 25);
            this.SectionCode_tEdit.MaxLength = 12;
            this.SectionCode_tEdit.Name = "SectionCode_tEdit";
            this.SectionCode_tEdit.Size = new System.Drawing.Size(51, 24);
            this.SectionCode_tEdit.TabIndex = 121;
            this.SectionCode_tEdit.Visible = false;
            // 
            // BackupFormal_tComboEditor
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BackupFormal_tComboEditor.ActiveAppearance = appearance20;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            this.BackupFormal_tComboEditor.Appearance = appearance21;
            this.BackupFormal_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BackupFormal_tComboEditor.Enabled = false;
            this.BackupFormal_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "メール形式(BCC)";
            this.BackupFormal_tComboEditor.Items.Add(valueListItem1);
            this.BackupFormal_tComboEditor.Location = new System.Drawing.Point(645, 520);
            this.BackupFormal_tComboEditor.Name = "BackupFormal_tComboEditor";
            this.BackupFormal_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.BackupFormal_tComboEditor.TabIndex = 17;
            // 
            // Check_Button
            // 
            this.Check_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Check_Button.Location = new System.Drawing.Point(420, 620);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(125, 34);
            this.Check_Button.TabIndex = 20;
            this.Check_Button.Text = "接続テスト(&T)";
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // SFDML09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(816, 683);
            this.Controls.Add(this.Check_Button);
            this.Controls.Add(this.BackupFormal_tComboEditor);
            this.Controls.Add(this.SectionCode_tEdit);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.SelectionCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.MailSendDivUnitCnt_tNedit);
            this.Controls.Add(this.MailSendDivUnitCnt_ultraCheckEditor);
            this.Controls.Add(this.BackupSendDivCd_ultraCheckEditor);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PopBeforeSmtpUseDiv_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv2_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv1_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv_ultraCheckEditor);
            this.Controls.Add(this.MailServerTimeoutVal_tNedit);
            this.Controls.Add(this.SmtpServerPortNo_tNedit);
            this.Controls.Add(this.PopServerPortNo_tNedit);
            this.Controls.Add(this.MailSendDivUnitCnt_Label);
            this.Controls.Add(this.BackupFormal_Label);
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
            this.Controls.Add(this.Ok_Button);
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
            this.Name = "SFDML09060UA";
            this.Text = "メール送信管理設定";
            this.VisibleChanged += new System.EventHandler(this.SFDML09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFDML09060UA_Closing);
            this.Load += new System.EventHandler(this.SFDML09060UA_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.MailSendDivUnitCnt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupFormal_tComboEditor)).EndInit();
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
			System.Windows.Forms.Application.Run(new SFDML09060UA());
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

        #region Public Method

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList mailSndMngList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._mailSndMngAcs.Search(out mailSndMngList, this.enterpriseCode);

                this._totalCount = mailSndMngList.Count;
            }
            else
            {
                status = this._mailSndMngAcs.SearchAll(
                    out mailSndMngList,
                    out this._totalCount,
                    out this._nextData,
                    this.enterpriseCode,
                    readCount,
                    this._mailSndMng);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (mailSndMngList.Count > 0)
                        {
                            // 最終のメール送信管理設定をオブジェクトを退避する
                            this._mailSndMng = ((MailSndMng)mailSndMngList[mailSndMngList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // 読み込んだインスタンス
                        foreach (MailSndMng mailSndMng in mailSndMngList)
                        {
                            // DataSetにセットする
                            MailSndMngToDataSet(mailSndMng.Clone(), index);
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
                            "SFDML09060U", 						// アセンブリＩＤまたはクラスＩＤ
                            "メール管理設定",      			    // プログラム名称
                            "Search", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._mailSndMngAcs, 				// エラーが発生したオブジェクト
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Delete()
        {            
            return 0;
        }        
            
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));            
            //拠点名称
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
            //SMTP認証使用
            appearanceTable.Add(VIEW_SMTPAUTHUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTPユーザー名
            appearanceTable.Add(VIEW_SMTPUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTPパスワード
            appearanceTable.Add(VIEW_SMTPPASSWORD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP Before SMTP使用区分
            appearanceTable.Add(VIEW_POPBEFORESMTPUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POPサーバー ポート番号
            appearanceTable.Add(VIEW_POPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //POPサーバー ポート番号
            appearanceTable.Add(VIEW_SMTPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //メールサーバータイムアウト値
            appearanceTable.Add(VIEW_MAILSERVERTIMEOUTVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //バックアップ送信区分
            appearanceTable.Add(VIEW_BACKUPSENDDIVCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //バックアップ形式
            appearanceTable.Add(VIEW_BACKUPFORMAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //メール送信分割単位件数
            appearanceTable.Add(VIEW_MAILSENDDIVUNITCNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        #endregion
        #endregion
        
        #region Private Properties 2006.11.06 Del
        /*

		/// <summary>
		/// Dmnoプロパティ
		/// </summary>
		/// <remarks>
		/// Dmnoを取得または設定します。
		/// </remarks>
		private int Dmno
		{
			get{ return _dmno; }
			set{ _dmno = value; }
		}

		#endregion End Private Properties

		#region Public Method (IMasterMeintenanceSingleTypeから継承)
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を実行します（未実装）</br>
		/// <br>Programmer	: 22013 久保 将太</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public int Print()
		{
			// 未実装
			return 0;
		}

		/// <summary>
		/// HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note		: ビュー用のHTMLコードを取得します</br>
		/// <br>Programmer	: 22013 久保 将太</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public string GetHtmlCode()
		{
			// 出力HTMLコード
			string outCode = "";

			// tHtmlGenerate部品の引数を生成する
			string [,] array = new string[17,2];

			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

			// タイトル設定
			array[0,0] = HTML_HEADER_TITLE;//「設定項目」
			array[0,1] = HTML_HEADER_VALUE;//「設定値」

            array[1, 0] = this.SenderName_Label.Text;			// 差出人名
			array[2,0]  = this.MailAddress_Label.Text;			// メールアドレス
			array[3,0]  = this.Pop3UserId_Label.Text;				// POP3ユーザーID
			array[4,0]  = this.Pop3Password_Label.Text;				// POP3パスワード
			array[5,0]  = this.Pop3ServerName_Label.Text;			// POP3サーバー名
			array[6,0]  = this.SmtpServerName_Label.Text;				// SMTPサーバー名
            array[7, 0] = "SMTP認証使用";					// SMTP認証使用区分
            array[8,0]  = this.SmtpUserId_Label.Text;			// SMTPユーザーID
			array[9,0]  = this.SmtpPassword_Label.Text;					// SMTPパスワード
			//array[8,0]  = this.SmtpAuthUseDiv_Label.Text;					// ダイアルアップ区分
            //array[8, 0] = "SMTP認証使用";					// SMTP認証使用区分
			//array[9,0]  = this.SenderName_Label.Text;			// 差出人名
			//array[10,0] = this.PopBeforeSmtpUseDiv_Label.Text;				// ダイアルアップログイン名
            array[10, 0] = "受信メールサーバーにログオン";				// POP Before SMTP使用区分
			array[11,0] = this.PopServerPortNo_Label.Text;				// POPサーバーポート番号
			array[12,0] = this.SmtpServerPortNo_Label.Text;					// SMTPサーバーポート番号
			array[13,0] = this.MailServerTimeoutVal_Label.Text;					// メールサーバータイムアウト値
			//array[14,0] = this.BackupSendDivCd_Label.Text;					// バックアップ送信区分
            array[14, 0] = "バックアップ送信";					// バックアップ送信区分
			array[15,0] = this.BackupFormal_Label.Text;				// バックアップ形式
			array[16,0] = this.MailSendDivUnitCnt_Label.Text;				// メール送信分割単位件数

			// TODO 1: 読み込み処理（ReadMailSndMng）
			int status = mailSndMngAcs.Read(out this.mailSndMng,this.enterpriseCode);
			// TODO guid1: dmno設定
			// メール送信管理マスタから読み込んだ署名ファイルパスと、メール文書管理マスタの署名ファイルパスが
			// 合致するものを探す関数を作成する。（while文でくるくる回して探す？）
			if ( status == 0 )
			{
                // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>
//                string companySignAttach = "";
//                switch(mailSndMng.CompanySignAttachCd)
//                {
//                    case 1:
//                    {
//                        companySignAttach = "添付する";
//                        break;
//                    }
//                    default:
//                    {
//                        companySignAttach = "添付しない";
//                        break;					
//                    }
//                }
//                array[1,1]  = companySignAttach;									// 自社署名区分
////				array[2,1]  = mailSndMng.AttachFilePath;							// 署名ファイルパス
//                array[2,1]  = RemovalExtensions(mailSndMng.AttachFilePath);			// 署名ファイルパス（拡張子削除後）
//                array[3,1]  = mailSndMng.MailDocMaxSize + UNITOFCHAR;				// メール文書最大サイズ
//                array[4,1]  = mailSndMng.MailLineStrMaxSize + UNITOFCHAR;			// メール文書行文字数最大サイズ
//                array[5,1]  = mailSndMng.PMailDocMaxSize + UNITOFCHAR;				// 携帯メール文書最大サイズ
//                array[6,1]  = mailSndMng.PMailLineStrMaxSize + UNITOFCHAR;			// 携帯メール文書行文字数最大サイズ
//                array[7,1]  = mailSndMng.MailAddress;								// メールアドレス

//                // ダイアルアップ区分変更
//                string dialUp;
//                switch(mailSndMng.DialUpCode)
//                {
//                    case 0:
//                    {
//                        dialUp = "ダイアル";
//                        break;
//                    }
//                    default:
//                    {
//                        dialUp = "LAN";
//                        break;
//                    }
//                }
//                array[8,1]  = dialUp;										// ダイアルアップ区分
//                array[9,1]  = mailSndMng.DialUpConnectName;					// ダイアルアップ接続名称
//                array[10,1] = mailSndMng.DialUpLoginName;					// ダイアルアップログイン名
//                array[11,1] = mailSndMng.DialUpPassword;					// ダイアルアップパスワード
//                array[12,1] = mailSndMng.Pop3UserId;						// POP3ユーザーID
//                array[13,1] = mailSndMng.Pop3Password;						// POP3パスワード
//                array[14,1] = mailSndMng.SenderName;						// 差出人名
//                array[15,1] = mailSndMng.Pop3ServerName;					// POP3サーバー名
//                array[16,1] = mailSndMng.SmtpServerName;					// SMTPサーバー名
                // 
                // 2006.11.01 Maki Add
                array[1, 1] = mailSndMng.SenderName;
                array[2, 1]  = mailSndMng.MailAddress;
                array[3, 1]  = mailSndMng.Pop3UserId;
                array[4, 1]  = mailSndMng.Pop3Password;
                array[5, 1]  = mailSndMng.Pop3ServerName;
                array[6, 1]  = mailSndMng.SmtpServerName;
                string smtpAuthUse;
                switch (mailSndMng.SmtpAuthUseDiv)
                {
                    case 0:
                        {
                            smtpAuthUse = "使用しない";
                            break;
                        }
                    case 1:
                        {
                            smtpAuthUse = "POP認証と同じID・パスワードを使用する";
                            break;
                        }
                    case 2:
                        {
                            smtpAuthUse = "SMTP認証と同じID・パスワードを使用する";
                            break;
                        }
                    default:
                        {
                            smtpAuthUse = HTML_UNREGISTER;
                            break;
                        }
                }
                array[7, 1] = smtpAuthUse;
                array[8, 1]  = mailSndMng.SmtpUserId;
                array[9, 1]  = mailSndMng.SmtpPassword;
                //string smtpAuthUse;
                //switch (mailSndMng.SmtpAuthUseDiv)
                //{
                //    case 0:
                //        {
                //            smtpAuthUse = "使用しない";
                //            break;
                //        }
                //    case 1:
                //        {
                //            smtpAuthUse = "POP認証と同じID・パスワードを使用する";
                //            break;
                //        }
                //    case 2:
                //        {
                //            smtpAuthUse = "SMTP認証と同じID・パスワードを使用する";
                //            break;
                //        }
                //    default:
                //        {
                //            smtpAuthUse = HTML_UNREGISTER;
                //            break;
                //        }
                //}
                //array[8, 1] = smtpAuthUse;
                //array[9, 1]  = mailSndMng.SenderName;
                string popBeforeSmtpUse;
                switch (mailSndMng.PopBeforeSmtpUseDiv)
                {
                    case 0:
                        {
                            popBeforeSmtpUse = "使用しない";
                            break;
                        }
                    case 1:
                        {
                            popBeforeSmtpUse = "受信メールサーバーにログオンする";
                            break;
                        }
                    default:
                        {
                            popBeforeSmtpUse = HTML_UNREGISTER;
                            break;
                        }
                }
                array[10, 1] = popBeforeSmtpUse;
                array[11, 1] = mailSndMng.PopServerPortNo.ToString();
                array[12, 1] = mailSndMng.SmtpServerPortNo.ToString();
                array[13, 1] = mailSndMng.MailServerTimeoutVal.ToString();
                string backupSend;
                switch (mailSndMng.BackupSendDivCd)
                {
                    case 0:
                        {
                            backupSend = "自社アドレスにバックアップ送信する";
                            break;
                        }
                    case 1:
                        {
                            backupSend = "送信しない";
                            break;
                        }
                    default:
                        {
                            backupSend = HTML_UNREGISTER;
                            break;
                        }
                }
                array[14, 1] = backupSend;
                string backupFormal;
                switch (mailSndMng.BackupFormal)
                {
                    case 0:
                        {
                            backupFormal = "メール形式(BCC)";
                            break;
                        }
                    case 1:
                        {
                            backupFormal = "一覧表形式(簡易)";
                            break;
                        }
                    default:
                        {
                            backupFormal = HTML_UNREGISTER;
                            break;
                        }
                }
                array[15, 1] = backupFormal;
                string mailSendDivUnit;
                switch (mailSndMng.MailSendDivUnitCnt)
                {
                    case 0:
                        {
                            mailSendDivUnit = "自動分割しない";
                            break;
                        }
                    default:
                        {
                            mailSendDivUnit = mailSndMng.MailSendDivUnitCnt.ToString();
                            break;
                        }
                }
                array[16, 1] = mailSendDivUnit;
                //
			}
			else
			{
				array[1,1]  = HTML_UNREGISTER;	// 自社署名区分
				array[2,1]  = HTML_UNREGISTER;	// 署名ファイルパス
				array[3,1]  = HTML_UNREGISTER;	// メール文書最大サイズ
				array[4,1]  = HTML_UNREGISTER;	// メール文書行文字数最大サイズ
				array[5,1]  = HTML_UNREGISTER;	// 携帯メール文書最大サイズ
				array[6,1]  = HTML_UNREGISTER;	// 携帯メール文書行文字数最大サイズ
				array[7,1]  = HTML_UNREGISTER;	// メールアドレス
				array[8,1]  = HTML_UNREGISTER;	// ダイアルアップ区分
				array[9,1]  = HTML_UNREGISTER;	// ダイアルアップ接続名称
				array[10,1] = HTML_UNREGISTER;	// ダイアルアップログイン名
				array[11,1] = HTML_UNREGISTER;	// ダイアルアップパスワード
				array[12,1] = HTML_UNREGISTER;	// POP3ユーザーID
				array[13,1] = HTML_UNREGISTER;	// POP3パスワード
				array[14,1] = HTML_UNREGISTER;	// 差出人名
				array[15,1] = HTML_UNREGISTER;	// POP3サーバー名
				array[16,1] = HTML_UNREGISTER;	// SMTPサーバー名

			}

			// データの２次元配列のみを指定して、プロパティを使用してグリッド表示する
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;
		}
        */
		#endregion

		#region Private Method
        /// <summary>
        /// メール送信管理設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="mailSndMng">メール送信管理設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : メール送信管理設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void MailSndMngToDataSet(MailSndMng mailSndMng, int index)
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
            if (mailSndMng.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = mailSndMng.UpdateDateTimeJpInFormal;
            }
            // 拠点名称
            string sectionName;
            int status = this._mailSndMngAcs.ReadSectionName(out sectionName, this.enterpriseCode, mailSndMng.SectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = "";
            }
            // 差出人名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDERNAME] = mailSndMng.SenderName;
            // メールアドレス
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILADDRESS] = mailSndMng.MailAddress;
            // POP3ユーザーID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3USERID] = mailSndMng.Pop3UserId;
            // POP3パスワード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3PASSWORD] = mailSndMng.Pop3Password;
            // POP3サーバー名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3SERVERNAME] = mailSndMng.Pop3ServerName;
            // SMTPサーバー名
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERNAME] = mailSndMng.SmtpServerName;
            // SMTP認証使用
            switch (mailSndMng.SmtpAuthUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "使用しない";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "POP認証と同じID・パスワードを使用";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "SMTP認証のID・パスワードを使用";
                        break;
                    }
            }
            // SMTPユーザーID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPUSERID] = mailSndMng.SmtpUserId;                
            // SMTPパスワード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPPASSWORD] = mailSndMng.SmtpPassword;
            // POP Before SMTP使用区分
            switch (mailSndMng.PopBeforeSmtpUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPBEFORESMTPUSEDIV] = "使用しない";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPBEFORESMTPUSEDIV] = "使用する";
                        break;
                    }
            }
            // POPサーバーポート番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPSERVERPORTNO] = mailSndMng.PopServerPortNo;
            // SMTPサーバーポート番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERPORTNO] = mailSndMng.SmtpServerPortNo;
            // メールサーバータイムアウト値
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSERVERTIMEOUTVAL] = mailSndMng.MailServerTimeoutVal;
            // バックアップ送信区分
            switch (mailSndMng.BackupSendDivCd)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPSENDDIVCD] = "自社アドレスにバックアップ送信する";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPSENDDIVCD] = "送信しない";
                        break;
                    }
            }
            // バックアップ形式
            switch (mailSndMng.BackupFormal)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPFORMAL] = "メール形式(BCC)";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPFORMAL] = "一覧表形式(簡易)";
                        break;
                    }
            }            
            // メール送信分割単位件数
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSENDDIVUNITCNT] = "自動分割しない";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSENDDIVUNITCNT] = mailSndMng.MailSendDivUnitCnt.ToString();
            }
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = mailSndMng.FileHeaderGuid;

            // インスタンステーブルにもセットする
            if (this._mailSndMngTable.ContainsKey(mailSndMng.FileHeaderGuid) == true)
            {
                this._mailSndMngTable.Remove(mailSndMng.FileHeaderGuid);
            }
            this._mailSndMngTable.Add(mailSndMng.FileHeaderGuid, mailSndMng);
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mailSndMngTable = new DataTable(VIEW_TABLE);

            //// Addを行う順番が、列の表示順位となります。
            mailSndMngTable.Columns.Add(DELETE_DATE, typeof(string));               //削除日            
            mailSndMngTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //拠点名称
            mailSndMngTable.Columns.Add(VIEW_SENDERNAME, typeof(string));           //差出人名
            mailSndMngTable.Columns.Add(VIEW_MAILADDRESS, typeof(string));          //メールアドレス
            mailSndMngTable.Columns.Add(VIEW_POP3USERID, typeof(string));           //POP3ユーザーID
            mailSndMngTable.Columns.Add(VIEW_POP3PASSWORD, typeof(string));         //POP3パスワード
            mailSndMngTable.Columns.Add(VIEW_POP3SERVERNAME, typeof(string));       //POP3サーバー名
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERNAME, typeof(string));       //SMTPサーバー名
            mailSndMngTable.Columns.Add(VIEW_SMTPAUTHUSEDIV, typeof(string));       //SMTP認証使用区分
            mailSndMngTable.Columns.Add(VIEW_SMTPUSERID, typeof(string));           //SMTPユーザーID
            mailSndMngTable.Columns.Add(VIEW_SMTPPASSWORD, typeof(string));         //SMTPパスワード
            mailSndMngTable.Columns.Add(VIEW_POPBEFORESMTPUSEDIV, typeof(string));  //POP Before SMTP使用区分
            mailSndMngTable.Columns.Add(VIEW_POPSERVERPORTNO, typeof(int));         //POPサーバー ポート番号
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERPORTNO, typeof(int));        //SMTPサーバー ポート番号
            mailSndMngTable.Columns.Add(VIEW_MAILSERVERTIMEOUTVAL, typeof(int));    //メールサーバータイムアウト値
            mailSndMngTable.Columns.Add(VIEW_BACKUPSENDDIVCD, typeof(string));      //バックアップ送信区分
            mailSndMngTable.Columns.Add(VIEW_BACKUPFORMAL, typeof(string));         //バックアップ形式
            mailSndMngTable.Columns.Add(VIEW_MAILSENDDIVUNITCNT, typeof(string));   //メール送信分割単位件数
            mailSndMngTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(mailSndMngTable);
        }

		/// <summary>
		///	画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	画面の初期設定を行います。</br>
		/// <br>Programmer		:	22013久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void ScreenInitialSetting()
        {
            #region 2006/11/06 Del
            // 自社署名区分
            //CompanySignAttachCd_tComboEditor.Clear();
            //CompanySignAttachCd_tComboEditor.Items.Add(0,"添付しない");
            //CompanySignAttachCd_tComboEditor.Items.Add(1,"添付する");
            //CompanySignAttachCd_tComboEditor.MaxDropDownItems = CompanySignAttachCd_tComboEditor.Items.Count;
			
            //// ダイアルアップ区分
            //DialUpCode_tComboEditor.Clear();
            //DialUpCode_tComboEditor.Items.Add(0,"ダイアル");
            //DialUpCode_tComboEditor.Items.Add(1,"LAN");
            #endregion
            // Edit系クリア
			EditClear("","0");
        }

        #region 2006.11.06 削除
        /*
		/// <summary>
		/// 画面情報⇒メール送信管理設定クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note		:	画面情報からメール送信管理設定クラスにデータを格納します</br>
		/// <br>Programmer	:	22013  久保　将太</br>
		/// <br>Date		:   2005.4.26</br>
		/// </remarks>
		private void ScreenToMailSndMng( ref MailSndMng copyMailSndMng)
		{
			if (copyMailSndMng == null)
			{
				// 新規の場合
				copyMailSndMng = new MailSndMng();
			}

			// ヘッダ部
//			copyMailSndMng.FileHeaderGuid = System.Guid.NewGuid();
			// e-mail送信管理番号（ゼロ固定）
			copyMailSndMng.MailSendMngNo = 0;
            //// 自社署名添付区分
            //copyMailSndMng.CompanySignAttachCd = Convert.ToInt32(this.CompanySignAttachCd_tComboEditor.SelectedItem.DataValue);
            //// 署名ファイルパス
            //if (!this.AttachFilePath_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.AttachFilePath = this.AttachFilePath_tEdit.DataText + ".txt"; 
            //}
            //else
            //{ 
            //    copyMailSndMng.AttachFilePath = HTML_UNREGISTER;	
            //}
            //// メール文書最大サイズ
            //if (!this.MailDocMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.MailDocMaxSize = this.MailDocMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.MailDocMaxSize = 0;
            //}
            //// メール文書行最大サイズ
            //if (!this.MailLineStrMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.MailLineStrMaxSize = this.MailLineStrMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.MailDocMaxSize = 0;
            //}
            //// 携帯メール文書最大サイズ
            //if (!this.PMailDocMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.PMailDocMaxSize = this.PMailDocMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.PMailDocMaxSize = 0;
            //}
            //// メール文書行最大サイズ
            //if (!this.PMailLineStrMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.PMailLineStrMaxSize = this.PMailLineStrMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.PMailDocMaxSize = 0;
            //}            
            //// ダイアルアップ区分
            //copyMailSndMng.DialUpCode = Convert.ToInt32(this.DialUpCode_tComboEditor.SelectedItem.DataValue);
            //// ダイアルアップ接続名称
            //if (!this.DialUpConnectName_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpConnectName = this.DialUpConnectName_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpConnectName = HTML_UNREGISTER;
            //}
            //// ダイアルアップログイン名
            //if (!this.DialUpLoginName_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpLoginName = this.DialUpLoginName_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpLoginName = HTML_UNREGISTER;
            //}
            //// ダイアルアップパスワード
            //if (!this.DialUpPassword_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpPassword = this.DialUpPassword_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpPassword = HTML_UNREGISTER;
            //}
            //// 接続先電話番号（未使用）
            //copyMailSndMng.AccessTelNo = "";

            // 差出人名
            if (!this.SenderName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SenderName = this.SenderName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SenderName = HTML_UNREGISTER;
            }
            // メールアドレス
            if (!this.MailAddress_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.MailAddress = this.MailAddress_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.MailAddress = HTML_UNREGISTER;
            }
			// POP3ユーザーID
			if (!this.Pop3UserId_tEdit.DataText.Equals(""))
			{
				copyMailSndMng.Pop3UserId = this.Pop3UserId_tEdit.DataText;
			}
			else
			{
				copyMailSndMng.Pop3UserId = HTML_UNREGISTER;
			}
			// POP3パスワード
			if (!this.Pop3Password_tEdit.DataText.Equals(""))
			{
				copyMailSndMng.Pop3Password = this.Pop3Password_tEdit.DataText;
			}
			else
			{
				copyMailSndMng.Pop3Password = HTML_UNREGISTER;
			}
            // POP3サーバー名
            if (!this.Pop3ServerName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.Pop3ServerName = this.Pop3ServerName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.Pop3ServerName = HTML_UNREGISTER;
            }
            // SMTPサーバー名
            if (!this.SmtpServerName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpServerName = this.SmtpServerName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpServerName = HTML_UNREGISTER;
            }
            // SMTP認証使用区分
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    // SMTP認証使用区分 1:POP3認証と同じID・パスワードを使用
                    copyMailSndMng.SmtpAuthUseDiv = 1;
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    // SMTP認証使用区分 2:SMTP認証のID・パスワードを使用
                    copyMailSndMng.SmtpAuthUseDiv = 2;
                }
                else if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    // POP Before SMTP使用区分 1:使用する
                    copyMailSndMng.PopBeforeSmtpUseDiv = 1;
                }
            }
            else
            {
                // SMTP認証使用区分 0:使用しない
                copyMailSndMng.SmtpAuthUseDiv = 0;
                // POP Before SMTP使用区分 0:使用しない
                copyMailSndMng.PopBeforeSmtpUseDiv = 0;
            }
            // SMTPユーザーID
            if (!this.SmtpUserId_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpUserId = this.SmtpUserId_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpUserId = HTML_UNREGISTER;
            }
            // SMTPパスワード
            if (!this.SmtpPassword_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpPassword = this.SmtpPassword_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpPassword = HTML_UNREGISTER;
            }
            // POPサーバーポート番号
            if (this.PopServerPortNo_tNedit.GetInt() != 0)
            {
                copyMailSndMng.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.PopServerPortNo = 0;
            }
            // SMTPサーバーポート番号
            if (this.SmtpServerPortNo_tNedit.GetInt() != 0)
            {
                copyMailSndMng.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.SmtpServerPortNo = 0;
            }
            // メールサーバータイムアウト値
            if (this.MailServerTimeoutVal_tNedit.GetInt() != 0)
            {
                copyMailSndMng.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.MailServerTimeoutVal = 0;
            }
            // バックアップ送信区分 TODO
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {
                // バックアップ送信区分 0:自社アドレスにバックアップ送信する
                copyMailSndMng.BackupSendDivCd = 0;
            }
            else
            {
                // バックアップ送信区分 1:送信しない
                copyMailSndMng.BackupSendDivCd = 1;
            }
            // バックアップ形式 0:メール形式(BCC) 現在しか使用しない
            copyMailSndMng.BackupFormal = 0;
            // メール送信分割単位件数
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                // メール送信分割単位件数
                copyMailSndMng.MailSendDivUnitCnt = this.MailServerTimeoutVal_tNedit.GetInt();
            }
            else
            {
                // メール送信分割単位件数 0:自動分割しない
                copyMailSndMng.MailSendDivUnitCnt = 0;
            }
		}
        */
        #endregion
        
        #region 2006.11.06 削除
        /*
		/// <summary>
		///	メール送信管理設定設定画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	メール送信管理設定設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer		:	22013  久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void MailSndMngToScreen()
		{
			//this.CompanySignAttachCd_tComboEditor.Value = mailSndMng.CompanySignAttachCd;			// 自社署名添付区分
//			this.AttachFilePath_tEdit.DataText = mailSndMng.AttachFilePath;							// 署名ファイルパス
			//this.AttachFilePath_tEdit.DataText = RemovalExtensions(mailSndMng.AttachFilePath);		// 署名ファイルパス（拡張子削除後）
			//bool setEnabled = IsSetAttachFilePathEnabled(mailSndMng.CompanySignAttachCd);			// 画面表示時ボタンのEnabledを設定
//			this.AttachFilePath_tEdit.Enabled = setEnabled;											// 署名ファイルパスEnabled設定
            //this.AttachFilePath_GuidUButton.Enabled = setEnabled;									// 署名ファイルパスガイドボタンEnabled設定
            //this.MailDocMaxSize_tNedit.DataText = mailSndMng.MailDocMaxSize.ToString();				// メール文書最大サイズ
            //this.MailLineStrMaxSize_tNedit.DataText = mailSndMng.MailLineStrMaxSize.ToString();		// メール文書行文字最大サイズ
            //this.PMailDocMaxSize_tNedit.DataText = mailSndMng.PMailDocMaxSize.ToString();			// 携帯メール文書最大サイズ
            //this.PMailLineStrMaxSize_tNedit.DataText = mailSndMng.PMailLineStrMaxSize.ToString();	// 携帯メール文書行文字最大サイズ
			this.MailAddress_tEdit.DataText = mailSndMng.MailAddress;       						// メールアドレス
            //this.DialUpCode_tComboEditor.Value = mailSndMng.DialUpCode;								// ダイアルアップ区分
            //this.DialUpConnectName_tEdit.DataText = mailSndMng.DialUpConnectName;					// ダイアルアップ接続名称
            //this.DialUpLoginName_tEdit.DataText = mailSndMng.DialUpLoginName;						// ダイアルアップログイン名	
            //this.DialUpPassword_tEdit.DataText = mailSndMng.DialUpPassword;							// ダイアルアップパスワード
			this.Pop3UserId_tEdit.DataText = mailSndMng.Pop3UserId;									// POP3ユーザー名
			this.Pop3Password_tEdit.DataText = mailSndMng.Pop3Password;								// POP3パスワード
            this.Pop3ServerName_tEdit.DataText = mailSndMng.Pop3ServerName;							// POP3サーバー名
            this.SmtpServerName_tEdit.DataText = mailSndMng.SmtpServerName;							// SMTPサーバー名
            this.SmtpUserId_tEdit.DataText = mailSndMng.SmtpUserId;							// SMTPサーバー名
            this.SmtpPassword_tEdit.DataText = mailSndMng.SmtpPassword;							// SMTPサーバー名
            //this.SmtpAuthUseDiv_ultraComboEditor.Value = mailSndMng.SmtpAuthUseDiv;							// SMTPサーバー名
            if (mailSndMng.SmtpAuthUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                if (mailSndMng.SmtpAuthUseDiv == 1)
                {
                    this.SmtpAuthUseDiv1_radioButton.Checked = true;
                }
                else if (mailSndMng.SmtpAuthUseDiv == 2)
                {
                    this.SmtpAuthUseDiv2_radioButton.Checked = true;
                }
                else if (mailSndMng.PopBeforeSmtpUseDiv == 1)
                {
                    this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
                }
            }
            //this.SmtpAuthUseDiv_ultraComboEditor.Value = mailSndMng.SmtpAuthUseDiv;							// SMTPサーバー名
            this.SenderName_tEdit.DataText = mailSndMng.SenderName;									// 差出人名			
            //this.PopBeforeSmtpUseDiv_ultraComboEditor.Value = mailSndMng.PopBeforeSmtpUseDiv;
            this.PopServerPortNo_tNedit.SetInt(mailSndMng.PopServerPortNo);
            this.SmtpServerPortNo_tNedit.SetInt(mailSndMng.SmtpServerPortNo);
            this.MailServerTimeoutVal_tNedit.SetInt(mailSndMng.MailServerTimeoutVal);
            if (mailSndMng.BackupSendDivCd == 0)
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = true;
            }
            else
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = false;
            }
            //this.BackupSendDivCd_ultraComboEditor.Value = mailSndMng.BackupSendDivCd;
            this.BackupFormal_ultraComboEditor.Value = mailSndMng.BackupFormal;
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.MailSendDivUnitCnt_tNedit.SetInt(mailSndMng.MailSendDivUnitCnt);
            }
            //this.MailSendDivUnitCnt_ultraComboEditor.Value = mailSndMng.MailSendDivUnitCnt;
		}
        */
        #endregion

        /// <summary>
		/// エディットボックス初期化処理
		/// </summary>
		/// <param name="tEditValue">tEditに代入する値</param>
		/// <param name="tNEditValue">tNEditに代入する値</param>
		/// <remarks>
		/// <br>Note		:	TEdit,TNEditを初期化します</br>
		/// <br>Programmer	:	22013  久保　将太</br>
		/// <br>Date		:   2005.4.26</br>
		/// </remarks>
		private void EditClear(string tEditValue, string tNEditValue)
		{
			MailAddress_tEdit.DataText      = tEditValue;				// メールアドレス
			Pop3UserId_tEdit.DataText       = tEditValue;				// POP3ユーザーID
			Pop3Password_tEdit.DataText     = tEditValue;				// POP3パスワード
            Pop3ServerName_tEdit.DataText   = tEditValue;				// POP3サーバー名
            SmtpServerName_tEdit.DataText   = tEditValue;				// SMTPサーバー名
            SmtpUserId_tEdit.DataText       = tEditValue;               // SMTPユーザーID
            SmtpPassword_tEdit.DataText     = tEditValue;               // SMTPパスワード
            SenderName_tEdit.DataText       = tEditValue;				// 差出人名						
		}

		/// <summary>
		/// 画面クリアー処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面をクリアーします</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		private void ScreenClear()
		{            
            this.BackupFormal_tComboEditor.SelectedIndex = 0;

			EditClear("","");									// Edit系クリア
            this.PopServerPortNo_tNedit.SetInt(0);
            this.SmtpServerPortNo_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 22013 久保　将太</br>
		/// <br>Date       : 2005.04.26</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            if (this.DataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;
                
                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                MailSndMng mailSndMng = (MailSndMng)this._mailSndMngTable[guid];                

                if (mailSndMng.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;

                    ScreenInputPermissionControl(true);
                    
                    // 差出人名
                    this.SenderName_tEdit.Focus();
                    // 画面展開処理
                    MailSndMngToScreen(mailSndMng);                    

                    // クローン作成
                    this.mailSndMngClone = mailSndMng.Clone();
                    DispToMailSndMng(ref this.mailSndMngClone);
                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    this.SenderName_tEdit.Focus();
                    this.SenderName_tEdit.SelectAll();
                }                
            }            
		}

        /// <summary>
        /// 画面情報メール送信管理設定クラス格納処理
        /// </summary>
        /// <param name="mailSndMng">メール送信管理設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からメール送信管理設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void DispToMailSndMng(ref MailSndMng mailSndMng)
        {
            if (mailSndMng == null)
            {
                // 新規の場合
                mailSndMng = new MailSndMng();
            }

            // 各項目のセット
            mailSndMng.EnterpriseCode = this.enterpriseCode;			// ← 要変更
            // 拠点コード
            mailSndMng.SectionCode = this.SectionCode_tEdit.Text;
            
            // e-mail送信管理番号
            mailSndMng.MailSendMngNo = 0; //0固定
            // 差出人名
            mailSndMng.SenderName = this.SenderName_tEdit.Text;
            // メールアドレス
            mailSndMng.MailAddress = this.MailAddress_tEdit.Text;
            // POP3ユーザーID
            mailSndMng.Pop3UserId = this.Pop3UserId_tEdit.Text;
            // POP3パスワード
            mailSndMng.Pop3Password = this.Pop3Password_tEdit.Text;
            // POP3サーバー名
            mailSndMng.Pop3ServerName = this.Pop3ServerName_tEdit.Text;
            // SMTPサーバー名
            mailSndMng.SmtpServerName = this.SmtpServerName_tEdit.Text;
            // SMTP認証使用区分
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 1; //POP認証と同じID・パスワードを使用
                    mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 2; //SMTP認証のID・パスワードを使用
                    mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
                }
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 0;      //SMTP認証使用しない
                    mailSndMng.PopBeforeSmtpUseDiv = 1; //使用する                    
                }
            }
            else
            {
                mailSndMng.SmtpAuthUseDiv = 0; //SMTP認証使用しない
                mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP 使用しない
            }
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv1_radioButton.Checked)
            {
                // SMTPユーザーID
                mailSndMng.SmtpUserId = this.Pop3UserId_tEdit.Text;
                // SMTPパスワード
                mailSndMng.SmtpPassword = this.Pop3Password_tEdit.Text;
            }
            else
            {
                // SMTPユーザーID
                mailSndMng.SmtpUserId = this.SmtpUserId_tEdit.Text;
                // SMTPパスワード
                mailSndMng.SmtpPassword = this.SmtpPassword_tEdit.Text;
            }
            // POPサーバーポート番号
            mailSndMng.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            // SMTPサーバーポート番号
            mailSndMng.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            // メールサーバータイムアウト値
            mailSndMng.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            // バックアップ送信区分
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {
                mailSndMng.BackupSendDivCd = 0; //自社アドレスにバックアップ送信する
            }
            else
            {
                mailSndMng.BackupSendDivCd = 1; //送信しない
            }
            // バックアップ形式
            mailSndMng.BackupFormal = 0; //メール形式(BCC)←今はゼロ固定
            // メール送信分割単位件数
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                mailSndMng.MailSendDivUnitCnt = this.MailSendDivUnitCnt_tNedit.GetInt(); //自動分割する単位件数
            }
            else
            {
                mailSndMng.MailSendDivUnitCnt = 0; //自動分割しない
            }
        }

        /// <summary>
        /// メール送信管理設定クラス画面展開処理
        /// </summary>
        /// <param name="mailSndMng">メール送信管理設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : メール送信管理設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void MailSndMngToScreen(MailSndMng mailSndMng)
        {
            // 各項目のセット
            // 拠点コード
            this.SectionCode_tEdit.Text = mailSndMng.SectionCode;
            // 拠点名称
            string sectionName;
            int st = this._mailSndMngAcs.ReadSectionName(out sectionName, this.enterpriseCode, mailSndMng.SectionCode);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionName_tEdit.Text = sectionName;
            }
            else
            {
                TMsgDisp.Show(this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                "SMDML09060U",						// アセンブリＩＤまたはクラスＩＤ
                                "拠点名称取得に失敗しました。",      // 表示するメッセージ 
                                st,								// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン
            }            
            // 差出人名
            this.SenderName_tEdit.Text = mailSndMng.SenderName;
            // メールアドレス
            this.MailAddress_tEdit.Text = mailSndMng.MailAddress;
            // POP3ユーザーID
            this.Pop3UserId_tEdit.Text = mailSndMng.Pop3UserId;
            // POP3パスワード
            this.Pop3Password_tEdit.Text = mailSndMng.Pop3Password;
            // POP3サーバー名
            this.Pop3ServerName_tEdit.Text = mailSndMng.Pop3ServerName;
            // SMTPサーバー名
            this.SmtpServerName_tEdit.Text = mailSndMng.SmtpServerName;
            // SMTP認証使用区分
            if (mailSndMng.SmtpAuthUseDiv == 1) //1:Pop認証と同じID・パスワード
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            else if (mailSndMng.SmtpAuthUseDiv == 2) //2:SMTP認証のID・パスワード
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = true;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // POP Before SMTP 使用区分
            if (mailSndMng.PopBeforeSmtpUseDiv == 1)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
            }
            // SMTPユーザーID
            this.SmtpUserId_tEdit.Text = mailSndMng.SmtpUserId;
            // SMTPパスワード
            this.SmtpPassword_tEdit.Text = mailSndMng.SmtpPassword;
            // POPサーバーポート番号            
            this.PopServerPortNo_tNedit.SetInt(mailSndMng.PopServerPortNo);
            // SMTPサーバーポート番号
            this.SmtpServerPortNo_tNedit.SetInt(mailSndMng.SmtpServerPortNo);
            // メールサーバータイムアウト値
            this.MailServerTimeoutVal_tNedit.SetInt(mailSndMng.MailServerTimeoutVal);
            // バックアップ送信区分
            if (mailSndMng.BackupSendDivCd == 0)
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = true;
            }
            else
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = false;
            }
            // バックアップ形式
            // メール送信分割単位件数
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = false;
                this.MailSendDivUnitCnt_tNedit.SetInt(0);
            }
            else
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = true;
                this.MailSendDivUnitCnt_tNedit.SetInt(mailSndMng.MailSendDivUnitCnt);
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {                        
            this.SenderName_tEdit.Enabled = enabled;
            this.MailAddress_tEdit.Enabled = enabled;
            this.Pop3UserId_tEdit.Enabled = enabled;
            this.Pop3Password_tEdit.Enabled = enabled;
            this.Pop3ServerName_tEdit.Enabled = enabled;
            this.SmtpServerName_tEdit.Enabled = enabled;
            this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = enabled;
            this.PopServerPortNo_tNedit.Enabled = enabled;
            this.SmtpServerPortNo_tNedit.Enabled = enabled;
            this.MailServerTimeoutVal_tNedit.Enabled = enabled;
            this.BackupSendDivCd_ultraCheckEditor.Enabled = enabled;
            this.MailSendDivUnitCnt_ultraCheckEditor.Enabled = enabled;
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// 署名ファイルパスEnabled設定関数
		/// </summary>
		/// <param name="attatchFilePathCode">自社署名添付区分</param>
		/// <returns>attachFilePathCode{1 : true | 1以外 : false}</returns>
		/// <remarks>
		/// <br>Note		: 自社署名添付区分に対する、署名ファイルパスのEnabledを設定します。</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.04.27</br>
		/// </remarks>
		private bool IsSetAttachFilePathEnabled(int attatchFilePathCode)
		{
			switch(attatchFilePathCode)
			{
				case 1:
				{
					// 送信するとき
					return true;
				}
				default:
				{
					// 送信しない、またはそれ以外の値が入っていたとき
					return false;
				}
			}
		}
        */
        #endregion

        /// <summary>
		/// OK_Button_Clickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 保存ボタンクリックイベント</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2005.05.02</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 保存前データチェック
			if ( !IsValueCheck() )
			{
				// チェックＮＧの場合処理終了
				return;
			}
			// データ保存
			if ( !IsSaveProc() )
			{
				// 保存に失敗したときは処理終了
				return;
			}

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // データインデックスを初期化する
                this.DataIndex = -1;

                // 画面クリア処理
                ScreenClear();

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;
            }
            else
            {
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
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			//this.mailSndMngClone = null;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		}
        
		/// <summary>
		/// 保存前データチェックメソッド
		/// </summary>
		/// <returns>チェック結果｛true : チェックＯＫ | false : チェックＮＧ｝</returns>
		/// <remarks>
		/// <br>Note		: 保存前データチェックメソッド</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		: 2005.05.02</br>
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
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFDML09060U",							// アセンブリID
						errorMsg,	                        　　// 表示するメッセージ
						0,   									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

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
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.05.02</br>
		/// <br></br>
		/// </remarks>
		private bool IsSaveProc()
        {
            #region 2006.11.06 Maki Del
            /*
			// 画面情報のセット
			ScreenToMailSndMng(ref this.mailSndMng);

			int status = this.mailSndMngAcs.Write(ref this.mailSndMng);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				
				// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status);
					
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this.mailSndMngClone = null;
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
					return false;
				}
				// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFDML09060U",							// アセンブリID
						"メール送信管理設定",                   // プログラム名称
						"IsSaveProc",                           // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this.mailSndMngAcs,				     	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this.mailSndMngClone = null;
					// 2005.07.11 排他制御処理の中に最小化対応を追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 エラーメッセージが出た時UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END	
					return false;
				}
			}
			DialogResult dialogResult = DialogResult.OK;
			
			Mode_Label.Text = UPDATE_MODE;
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = dialogResult;

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
			return true;
            */
            //Control control = null;
            //string message = null;
            //string loginID = "";
            //Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
            #endregion

            MailSndMng mailSndMng = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                mailSndMng = ((MailSndMng)this._mailSndMngTable[guid]).Clone();
            }
            
            this.DispToMailSndMng(ref mailSndMng);

            int status = this._mailSndMngAcs.Write(ref mailSndMng);

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
                            "SMDML09060U",						// アセンブリＩＤまたはクラスＩＤ
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
                            "SFDML09060U",						// アセンブリＩＤまたはクラスＩＤ
                            "メール送信管理設定",							// プログラム名称
                            "IsSaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "登録に失敗しました。",						// 表示するメッセージ 
                            status,								// ステータス値
                            this._mailSndMngAcs,					// エラーが発生したオブジェクト
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
            MailSndMngToDataSet(mailSndMng, this.DataIndex);

            return true;

		}
		/// <summary>
		/// エラーチェック処理
		/// </summary>
		/// <param name="errorMsg">エラーメッセージ格納用変数（受け取り時は空）</param>
		/// <returns>フォーカスをセットするコンポーネント</returns>
		/// <remarks>
		/// <br>Note		: コンポーネントにフォーカスをセットします。</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		; 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private int CheckError(ref string errorMsg)
        {
            #region 2006.11.02 Maki 削除
            // 長さ比較用
            //int mailDocMaxSizeNum = TStrConv.StrToIntDef(this.MailDocMaxSize_tNedit.DataText,0);
            //int mailLineStrMaxSizeNum = TStrConv.StrToIntDef(this.MailLineStrMaxSize_tNedit.DataText,0);
            //int pMailDocMaxSizeNum = TStrConv.StrToIntDef(this.PMailDocMaxSize_tNedit.DataText,0);
            //int pMailLineStrMaxSizeNum = TStrConv.StrToIntDef(this.PMailLineStrMaxSize_tNedit.DataText,0);

			            
            //// 自社署名添付区分が添付するの場合
            //if ( (int)CompanySignAttachCd_tComboEditor.SelectedItem.DataValue == 1 ) 
            //{
            //    // 署名ファイル名欄空白はだめ
            //    if ( CompanySignAttachCd_tComboEditor.SelectedItem.DisplayText.Trim().Equals("") )
            //    {
            //        errorMsg = "署名ファイル名称を入力してください。";
            //        setFocusNum = 11;
            //    }
            //}
            //    // メール文書最大サイズがゼロのとき
            //else if ( mailDocMaxSizeNum == 0)
            //{
            //    errorMsg = "サイズを設定してください。";
            //    setFocusNum = 20;
            //}
            //    // メール文書行最大文字数がゼロのとき
            //else if ( mailLineStrMaxSizeNum == 0 )
            //{
            //    errorMsg = "サイズを設定してください。";
            //    setFocusNum = 21;
            //}
            //    // 携帯メール文書最大サイズがゼロのとき
            //else if ( pMailDocMaxSizeNum == 0)
            //{
            //    errorMsg = "サイズを設定してください。";
            //    setFocusNum = 30;
            //}
            //    // 携帯メール文書行最大文字数がゼロのとき
            //else if ( pMailLineStrMaxSizeNum == 0 )
            //{
            //    errorMsg = "サイズを設定してください。";
            //    setFocusNum = 30;
            //}
            //    // メール文書行最大文字数は７２文字まで
            //else if ( TStrConv.StrToIntDef( this.MailLineStrMaxSize_tNedit.DataText, 99 ) > 72 )
            //{
            //    errorMsg = "１行の文字数は７２文字までです。";
            //    setFocusNum = 21;
            //}
            //    // 携帯メール文書行最大文字数は７２文字まで
            //else if ( TStrConv.StrToIntDef( this.PMailLineStrMaxSize_tNedit.DataText, 99 ) > 72 )
            //{
            //    errorMsg = "１行の文字数は７２文字までです。";
            //    setFocusNum = 31;
            //}
            //    // メール文書最大サイズオーバー
            //else if ( TStrConv.StrToIntDef( this.MailDocMaxSize_tNedit.DataText, 99999) > 65536 )
            //{
            //    errorMsg = "メール文書のサイズは最大６５５３６文字までです。";
            //    setFocusNum = 20;
            //}
            //    // 携帯メール文書最大サイズオーバー
            //else if ( TStrConv.StrToIntDef( this.PMailDocMaxSize_tNedit.DataText, 99999) > 65536 )
            //{
            //    errorMsg = "メール文書のサイズは最大６５５３６文字までです。";
            //    setFocusNum = 30;
            //}
            //    // １行の文字数が最大サイズを超えている場合（ＰＣ）
            //else if ( mailDocMaxSizeNum < mailLineStrMaxSizeNum )
            //{
            //    errorMsg = "数値が不正です。";
            //    setFocusNum = 20;
            //}
            //    // １行の文字数が最大サイズを超えている場合（携帯）
            //else if ( pMailDocMaxSizeNum < pMailLineStrMaxSizeNum )
            //{
            //    errorMsg = "数値が不正です。";
            //    setFocusNum = 30;
            //}
            //    // メールアドレスが設定されていないとだめ
            //else if ( this.MailAddress_tEdit.DataText.Equals("") )
            //{
            //    errorMsg = "メールアドレスを設定してください。";
            //    setFocusNum = 40;
            //}
            //    // 差出人名称にダブルクオテーション（半・全角）が含まれている場合
            //else if ( ( this.SenderName_tEdit.DataText.IndexOf('\"' ) != -1) ||
            //    ( SenderName_tEdit.DataText.IndexOf('”' ) != -1) )
            //{
            //    errorMsg = "差出人名称に「\"」は設定できません。";
            //    setFocusNum = 47;
            //}
#endregion

            // フォーカスセットするエディットの番号
            int setFocusNum = 0;            

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
                errorMsg = "メールアドレスを設定してください。";
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
            // メール送信分割単位件数
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                if (this.MailSendDivUnitCnt_tNedit.GetInt() == 0)
                {
                    errorMsg = "自動分割件する単位件数を入力してください。";
                    setFocusNum = 10;
                    return setFocusNum;
                }
            }
            
			return setFocusNum;
		}
		/// <summary>
		/// フォーカスセット処理
		/// </summary>
		/// <param name="setFocusNum">フォーカスセットするコンポーネント番号</param>
		/// <remarks>
		/// <br>Note		: コンポーネントにフォーカスをセットします。</br>
		/// <br>Programmer	: 22013　久保　将太</br>
		/// <br>Date		; 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private void SetFocusToComponent(int setFocusNum)
		{
			// フォーカスセット
			switch ( setFocusNum )
            {
                #region 2006.11.02 Maki 削除
                //    // 自社署名区分
                //case 10:
                //{
                //    this.CompanySignAttachCd_tComboEditor.Focus();
                //    break;
                //}
                //    // 署名ファイルパスガイドボタン
                //case 11:
                //{
                //    this.AttachFilePath_GuidUButton.Focus();
                //    break;
                //}
                //    // メール文書最大サイズ
                //case 20:
                //{
                //    this.MailDocMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // メール文書行最大文字数（１行あたりの文字数）
                //case 21:
                //{
                //    this.MailLineStrMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // 携帯メール文書最大サイズ
                //case 30:
                //{
                //    this.PMailDocMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // 携帯メール文書行最大文字数（１行あたりの文字数）
                //case 31:
                //{
                //    this.PMailLineStrMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // メールアドレス
                //case 40:
                //{
                //    this.MailAddress_tEdit.Focus();
                //    break;
                //}
                //    // ダイアルアップ区分
                //case 41:
                //{
                //    this.DialUpCode_tComboEditor.Focus();
                //    break;
                //}
                //    // ダイアルアップ接続名称
                //case 42:
                //{
                //    this.DialUpConnectName_tEdit.Focus();
                //    break;
                //}
                //    // ダイアルアップログイン名
                //case 43:
                //{
                //    this.DialUpLoginName_tEdit.Focus();
                //    break;
                //}
                //    // ダイアルアップパスワード
                //case 44:
                //{
                //    this.DialUpPassword_tEdit.Focus();
                //    break;
                //}
                //    // ＰＯＰ３ユーザーＩＤ
                //case 45:
                //{
                //    this.Pop3UserId_tEdit.Focus();
                //    break;
                //}
                //    // ＰＯＰ３パスワード
                //case 46:
                //{
                //    this.Pop3Password_tEdit.Focus();
                //    break;
                //}
                //    // 差出人名
                //case 47:
                //{
                //    this.SenderName_tEdit.Focus();
                //    break;
                //}
                //    // ＰＯＰ３サーバー名
                //case 48:
                //{
                //    this.Pop3ServerName_tEdit.Focus();
                //    break;
                //}
                //    // ＳＭＴＰサーバー名
                //case 49:
                //{
                //    this.SmtpServerName_tEdit.Focus();
                //    break;
                //}
                //    // ELSE
                //default:
                //{
                //    break;
                //}
                #endregion
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
                        // 自動分割する単位件数
                        this.MailSendDivUnitCnt_tNedit.Focus();
                        break;
                    }                
                default:
                    {
                        break;
                    }
			}
        }

        #region 2006/11/06 Maki Del
        /*
		/// <summary>
		/// 拡張子削除処理（.txt専用）
		/// </summary>
		/// <param name="removalString">拡張子を除去する文字列</param>
		/// <returns>拡張子除去後文字列</returns>
		/// <remarks>
		/// <br>Note		: 文字列から拡張子を除去します。署名ファイルパスから「.txt」を除くために使用します。</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private string RemovalExtensions(string removalString)
		{
			int extensionStartCount = 0;
			string beforeRemovalString = removalString;
			// 「.txt」開始位置検索
			extensionStartCount = removalString.IndexOf(".txt");
			if (extensionStartCount != -1)
			{
				beforeRemovalString = removalString.Remove(extensionStartCount,4);
			}

			return beforeRemovalString;
		}
        */
        #endregion

        /// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 23013 牧　将人</br>
		/// <br>Date       : 2006.11.06</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFDML09060U",							// アセンブリID
						"既に他端末より更新されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFDML09060U",							// アセンブリID
						"既に他端末より削除されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
					break;
				}
			}
        }

        #region 2006.11.06 Maki Del
        /*
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.06 TAKAHASHI ADD START
		/// <summary>
		/// ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ガイドを起動し、選択内容を画面に適用します。</br>
		/// <br>Programmer	: 23006  高橋 明子</br>
		/// <br>Date		: 2005.10.06</br>
		/// </remarks>
		private void StartGuidProc(string objectName)
		{
			// 署名ファイルガイド
			// TODO : どこ見るの？？　マスタがない為保留
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.06 TAKAHASHI ADD END
        */
        #endregion

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2006.11.28</br>
        /// </remarks>
        private string AuthenticationCheck(int status)
        {
            string message = "";
            switch (status)
            {
                case 0: case 1:
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

		#endregion Private Method End

		# region Control Events
		/// <summary>
		///	Form.Load イベント(SFDML09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer		:	22013  久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する			
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Close_Button.ImageList = imageList24;            			

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Close_Button.Appearance.Image = Size24_Index.CLOSE;

			// 画面初期設定処理
			ScreenInitialSetting();

		}
		/// <summary>
		///	Form.VisibleChanged イベント(SFDML09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	画面の表示、非表示が変わった時に発生します。</br>
		/// <br>Programmer		:	22013  久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// メインフレームアクティブ化
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
            //if (this.mailSndMngClone != null)
            //{
            //    return;
            //}
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

			timer1.Enabled = true;

			ScreenClear();		
		}

		/// <summary>
		///	Form.Load イベント(SFDML09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer		:	22013  久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
        {
            #region 2006.11.06 Maki Del
            /*
			// 保存確認
			MailSndMng compareMailSndMng = new MailSndMng();
			compareMailSndMng = this.mailSndMngClone.Clone();
			// 現在の画面情報を取得する
			ScreenToMailSndMng(ref compareMailSndMng);

			//最初に取得した画面情報と比較
			if (!(this.mailSndMngClone.Equals(compareMailSndMng)))	
			{
				//画面情報が変更されていた場合は、保存確認メッセージを表示する
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
					"SFDML09060U", 			                              // アセンブリＩＤまたはクラスＩＤ
					null, 					                              // 表示するメッセージ
					0, 					                                  // ステータス値
					MessageBoxButtons.YesNoCancel);	                      // 表示するボタン
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				switch(res)
				{
					case DialogResult.Yes:
					{
						// 保存前データチェックか登録自体が失敗していたら処理中断
						if ( !IsValueCheck() || !IsSaveProc() )
						{
							return;
						}
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					default:
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Close_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			DialogResult dialogResult = DialogResult.Cancel;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			this.mailSndMngClone = null;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
 */
            #endregion
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                MailSndMng compareMailSndMng = new MailSndMng();
                compareMailSndMng = this.mailSndMngClone.Clone();
                //現在の画面情報を取得する
                DispToMailSndMng(ref compareMailSndMng);
                //最初に取得した画面情報と比較
                if (!(this.mailSndMngClone.Equals(compareMailSndMng)))
                {
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        "SFDML09060U",						// アセンブリＩＤまたはクラスＩＤ
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
		/// Form.Closingイベント(SFDML09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームクローズ時のイベントです</br>
		/// <br>Programmer	: 22013  久保　将太</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			//this.mailSndMngClone = null;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
		/// <br>Programmer		:	22013 久保　将太</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();		
		}

        /// <summary>
        /// SMTP認証区分使用チェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	SMTP認証区分使用チェックチェンジ処理</br>
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// バックアップ送信区分チェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	バックアップ送信区分チェックチェンジ処理</br>
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
        /// </remarks>
        private void BackupSendDivCd_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {                
                this.BackupFormal_tComboEditor.Enabled = true;
            }
            else
            {                
                this.BackupFormal_tComboEditor.Enabled = false;
            }
        }

        /// <summary>
        /// メール送信分割単位件数チェックチェンジ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	メール送信分割単位件数チェックチェンジ処理</br>
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.03</br>
        /// </remarks>
        private void MailSendDivUnitCnt_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                this.MailSendDivUnitCnt_tNedit.Enabled = true;                
            }
            else
            {
                this.MailSendDivUnitCnt_tNedit.Enabled = false;                
            }
        }

        /// <summary>
        /// Check_Buttonクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	Check_Buttonクリックイベント</br>
        /// <br>Programmer		:	23013 牧　将人</br>
        /// <br>Date			:	2006.11.28</br>
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
            tSmtp.TraceOptions.TraceLogPath = "c:\\smtp.log"; // TODO

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
                    case 7: case 9:
                        TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    "SFDML09060U",							// アセンブリID
                                    smtpMessage + "\n"
                                    + tSmtp.StatusMessage,              　　// 表示するメッセージ
                                    tSmtp.Status,							// ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    default:
                        TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        "SFDML09060U",							// アセンブリID
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
                tPop.TraceOptions.TraceLogPath = "c:\\pop.log"; //TODO

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
                    switch(popStatus)
                    {
                        case 9:
                            // エラー
                            TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                                    "SFDML09060U",							// アセンブリID
                                    popMessage + "\n"
                                    + tPop.StatusMessage,              　　 // 表示するメッセージ
                                    tPop.Status,							// ステータス値
                                    MessageBoxButtons.OK);					// 表示するボタン
                        break;
                        default:
                                // エラー
                                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                                     "SFDML09060U",							// アセンブリID
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
                                "SFDML09060U",							// アセンブリID
                                popMessage,                        　　 // 表示するメッセージ
                                tPop.Status,							// ステータス値
                                MessageBoxButtons.OK);					// 表示するボタン
                }
            }
            // カーソルをDefaultに戻す
            this.Cursor = Cursors.Default;

        }
        #endregion Control Events End        
    }
}
