//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 端末管理設定マスタ
// プログラム概要   : 端末管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/05  修正内容 : SCMオプション対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/08/11  修正内容 : IPアドレスの入力制御の変更および追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/09/24  修正内容 : 同端末名の登録を許可しない仕様とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2009/06/29  修正内容 : Mantis.15667　仕様変更
//----------------------------------------------------------------------------//
//#define _ADMIN_MODE_    // 強制的に管理者モードにするフラグ ※通常は無効にしておくこと！

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;   // ADD 2009/06/05
using Microsoft.VisualBasic;    // ADD 2009/06/05

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

using Broadleaf.Application.Resources;// 2010/06/29 Add

namespace Broadleaf.Windows.Forms
{
	/// <summary>端末管理設定(ローカルDB専用)クラス</summary>
	/// <remarks> 
	/// <br>note			:	ローカルDBのみに保持するPOS端末の設定を行います。
	///							IMasterMaintenanceSingleTypeを実装しています。</br>              
	/// <br>Programer		:	古賀　小百合</br>                            
	/// <br>Date			:	2007.04.16</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.06.11  古賀小百合　項目追加対応</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.07.03  古賀小百合　新規時にエラーが発生する障害を修正</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.07.05  古賀小百合　拠点を自拠点から端末設置拠点に変更</br>
    /// </remarks>
    //public class MAPOS09150UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType   // DEL 2009/06/05
    public class MAPOS09150UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType      // ADD 2009/06/05
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel CashRegisterNo_Title;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
        private System.Windows.Forms.Timer Initial_Timer;
        private TNedit CashRegisterNo_tNedit;
        private TComboEditor UseLanguageDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UseLanguageDivCd_Title;
        private DataSet Bind_DataSet;
        private TEdit tEdit_MachineName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TNedit tNedit_MachineIpAddr1;
        private TNedit tNedit_MachineIpAddr4;
        private TNedit tNedit_MachineIpAddr3;
        private TNedit tNedit_MachineIpAddr2;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.ComponentModel.IContainer components;
        private bool _scmFlg = false;    // 2010/06/29 Add
        private ArrayList _serverPosTerminalList = new ArrayList(); // 2010/06/29 Add
		# endregion

		# region Constructor
		/// <summary>MAPOS09150UAコンストラクタ</summary>
		/// <remarks> 
		/// <br>note        :	端末管理設定アクセスクラスを生成します。
		///						フレーム画面の印刷ボタン非表示設定を行います。</br>
		/// <br>Programer   :	古賀　小百合</br>                            
		/// <br>Date        :	2007.04.16</br>                              
		/// </remarks>
		public MAPOS09150UA()
        {
        #if _ADMIN_MODE_
            LoginInfoAcquisition.Employee.UserAdminFlag = 1;    // 仮の管理者設定
        #endif

			InitializeComponent();

			// companyInfクラスアクセスクラス
			this._posTerminalMgAcs = new PosTerminalMgAcs();

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点情報取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            # region 2007.07.05  S.Koga  DEL
            //this._sectionGuideName = this.posTerminalMgAcs.GetSecInfo(this._sectionCode);
            # endregion

            // 印刷可能フラグを設定します。
			// Frameの印刷ボタンの表示非表示の制御に使用します。
			_canPrint = false;

            // ADD 2009/06/05 ------>>>
            // データセット列情報構築処理
            DataSetColumnConstruction();

            // 変数初期化
            this._dataIndex = -1;
            this._totalCount = 0;
            this._posTerminalMgTable = new Hashtable();

            // 2010/06/29 Add >>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _scmFlg = true;
            }
            else
            {
                _scmFlg = false;
            }
            // 2010/06/29 Add <<<

            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                // 2010/06/29 SCMオプションが有効なら管理者モードで実行 Add >>>
                if (_scmFlg == true)
                {
                    // 2010/06/29 Add <<<
                    // 管理者モード
                    this._canNew = true;
                    this._canDelete = true;
                    this._canClose = true;
                    this._defaultAutoFillToColumn = false;
                    this._canSpecificationSearch = false;
                    this._canLogicalDeleteDataExtraction = true;
                    // 2010/06/29 Add >>>
                }
                else
                {
                    // 一般ユーザーモード
                    this._canNew = false;
                    this._canDelete = false;
                    this._canClose = true;
                    this._defaultAutoFillToColumn = false;
                    this._canSpecificationSearch = false;
                    this._canLogicalDeleteDataExtraction = false;
                }
                // 2010/06/29 Add <<<
            }
            else
            {
                // 一般ユーザーモード
                this._canNew = false;
                this._canDelete = false;
                this._canClose = true;
                this._defaultAutoFillToColumn = false;
                this._canSpecificationSearch = false;
                this._canLogicalDeleteDataExtraction = false;
            }
            
            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // ローカルマシン情報取得
            GetHostInfo();
            // ADD 2009/06/05 ------<<<
        }
		# endregion

		# region Dispose
		/// <summary>使用されているリソースに後処理を実行します。</summary>
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
		# endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAPOS09150UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNo_Title = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.CashRegisterNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UseLanguageDivCd_Title = new Infragistics.Win.Misc.UltraLabel();
            this.UseLanguageDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tEdit_MachineName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MachineIpAddr1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseLanguageDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr4)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(142, 196);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 8;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(273, 196);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(120, 34);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 240);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(405, 23);
            this.ultraStatusBar1.TabIndex = 10;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Mode_Label
            // 
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance9;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance10;
            this.Mode_Label.Location = new System.Drawing.Point(278, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 6;
            // 
            // CashRegisterNo_Title
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.CashRegisterNo_Title.Appearance = appearance12;
            this.CashRegisterNo_Title.Location = new System.Drawing.Point(12, 62);
            this.CashRegisterNo_Title.Name = "CashRegisterNo_Title";
            this.CashRegisterNo_Title.Size = new System.Drawing.Size(115, 24);
            this.CashRegisterNo_Title.TabIndex = 8;
            this.CashRegisterNo_Title.Text = "端末番号";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // CashRegisterNo_tNedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.CashRegisterNo_tNedit.ActiveAppearance = appearance3;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.CashRegisterNo_tNedit.Appearance = appearance11;
            this.CashRegisterNo_tNedit.AutoSelect = true;
            this.CashRegisterNo_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CashRegisterNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CashRegisterNo_tNedit.DataText = "";
            this.CashRegisterNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CashRegisterNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CashRegisterNo_tNedit.Location = new System.Drawing.Point(133, 62);
            this.CashRegisterNo_tNedit.MaxLength = 3;
            this.CashRegisterNo_tNedit.Name = "CashRegisterNo_tNedit";
            this.CashRegisterNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CashRegisterNo_tNedit.Size = new System.Drawing.Size(36, 24);
            this.CashRegisterNo_tNedit.TabIndex = 0;
            // 
            // UseLanguageDivCd_Title
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.UseLanguageDivCd_Title.Appearance = appearance13;
            this.UseLanguageDivCd_Title.Location = new System.Drawing.Point(12, 92);
            this.UseLanguageDivCd_Title.Name = "UseLanguageDivCd_Title";
            this.UseLanguageDivCd_Title.Size = new System.Drawing.Size(115, 24);
            this.UseLanguageDivCd_Title.TabIndex = 12;
            this.UseLanguageDivCd_Title.Text = "使用言語区分";
            // 
            // UseLanguageDivCd_tComboEditor
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.UseLanguageDivCd_tComboEditor.ActiveAppearance = appearance4;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance1.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.UseLanguageDivCd_tComboEditor.Appearance = appearance1;
            this.UseLanguageDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UseLanguageDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UseLanguageDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UseLanguageDivCd_tComboEditor.ItemAppearance = appearance2;
            this.UseLanguageDivCd_tComboEditor.Location = new System.Drawing.Point(133, 92);
            this.UseLanguageDivCd_tComboEditor.Name = "UseLanguageDivCd_tComboEditor";
            this.UseLanguageDivCd_tComboEditor.Size = new System.Drawing.Size(128, 24);
            this.UseLanguageDivCd_tComboEditor.TabIndex = 1;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tEdit_MachineName
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Left";
            this.tEdit_MachineName.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            this.tEdit_MachineName.Appearance = appearance6;
            this.tEdit_MachineName.AutoSelect = true;
            this.tEdit_MachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MachineName.DataText = "";
            this.tEdit_MachineName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MachineName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_MachineName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_MachineName.Location = new System.Drawing.Point(133, 153);
            this.tEdit_MachineName.MaxLength = 128;
            this.tEdit_MachineName.Name = "tEdit_MachineName";
            this.tEdit_MachineName.Size = new System.Drawing.Size(190, 24);
            this.tEdit_MachineName.TabIndex = 6;
            // 
            // ultraLabel1
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance24;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 123);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel1.TabIndex = 12;
            this.ultraLabel1.Text = "IPアドレス";
            // 
            // ultraLabel2
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance15;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 153);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel2.TabIndex = 12;
            this.ultraLabel2.Text = "端末名";
            // 
            // tNedit_MachineIpAddr1
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr1.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr1.Appearance = appearance21;
            this.tNedit_MachineIpAddr1.AutoSelect = true;
            this.tNedit_MachineIpAddr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr1.DataText = "";
            this.tNedit_MachineIpAddr1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr1.Location = new System.Drawing.Point(133, 123);
            this.tNedit_MachineIpAddr1.MaxLength = 3;
            this.tNedit_MachineIpAddr1.Name = "tNedit_MachineIpAddr1";
            this.tNedit_MachineIpAddr1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr1.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr1.TabIndex = 2;
            this.tNedit_MachineIpAddr1.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr1_ValueChanged);
            // 
            // tNedit_MachineIpAddr2
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr2.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr2.Appearance = appearance19;
            this.tNedit_MachineIpAddr2.AutoSelect = true;
            this.tNedit_MachineIpAddr2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr2.DataText = "";
            this.tNedit_MachineIpAddr2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr2.Location = new System.Drawing.Point(185, 123);
            this.tNedit_MachineIpAddr2.MaxLength = 3;
            this.tNedit_MachineIpAddr2.Name = "tNedit_MachineIpAddr2";
            this.tNedit_MachineIpAddr2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr2.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr2.TabIndex = 3;
            this.tNedit_MachineIpAddr2.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr2_ValueChanged);
            // 
            // tNedit_MachineIpAddr3
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr3.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr3.Appearance = appearance17;
            this.tNedit_MachineIpAddr3.AutoSelect = true;
            this.tNedit_MachineIpAddr3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr3.DataText = "";
            this.tNedit_MachineIpAddr3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr3.Location = new System.Drawing.Point(237, 123);
            this.tNedit_MachineIpAddr3.MaxLength = 3;
            this.tNedit_MachineIpAddr3.Name = "tNedit_MachineIpAddr3";
            this.tNedit_MachineIpAddr3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr3.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr3.TabIndex = 4;
            this.tNedit_MachineIpAddr3.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr3_ValueChanged);
            // 
            // tNedit_MachineIpAddr4
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr4.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr4.Appearance = appearance8;
            this.tNedit_MachineIpAddr4.AutoSelect = true;
            this.tNedit_MachineIpAddr4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr4.DataText = "";
            this.tNedit_MachineIpAddr4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr4.Location = new System.Drawing.Point(288, 123);
            this.tNedit_MachineIpAddr4.MaxLength = 3;
            this.tNedit_MachineIpAddr4.Name = "tNedit_MachineIpAddr4";
            this.tNedit_MachineIpAddr4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr4.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr4.TabIndex = 5;
            this.tNedit_MachineIpAddr4.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr4_ValueChanged);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(142, 196);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(13, 196);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ultraLabel3
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance23;
            this.ultraLabel3.Location = new System.Drawing.Point(170, 128);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel3.TabIndex = 12;
            this.ultraLabel3.Text = ".";
            // 
            // ultraLabel4
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance22;
            this.ultraLabel4.Location = new System.Drawing.Point(222, 128);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel4.TabIndex = 12;
            this.ultraLabel4.Text = ".";
            // 
            // ultraLabel5
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance14;
            this.ultraLabel5.Location = new System.Drawing.Point(273, 128);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel5.TabIndex = 12;
            this.ultraLabel5.Text = ".";
            // 
            // MAPOS09150UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(405, 263);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.tEdit_MachineName);
            this.Controls.Add(this.UseLanguageDivCd_tComboEditor);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.UseLanguageDivCd_Title);
            this.Controls.Add(this.tNedit_MachineIpAddr4);
            this.Controls.Add(this.tNedit_MachineIpAddr3);
            this.Controls.Add(this.tNedit_MachineIpAddr2);
            this.Controls.Add(this.tNedit_MachineIpAddr1);
            this.Controls.Add(this.CashRegisterNo_tNedit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CashRegisterNo_Title);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAPOS09150UA";
            this.Text = "端末管理設定";
            this.Load += new System.EventHandler(this.MAPOS09150UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAPOS09150UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAPOS09150UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseLanguageDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
        //public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;    // DEL 2009/06/05
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;       // ADD 2009/06/05
		# endregion

		#region Private Members
        //private PosTerminalMg posTerminalMg;  // DEL 2009/06/05
		private PosTerminalMgAcs _posTerminalMgAcs;
		private string _enterpriseCode;
        private string _sectionCode;
        # region 2007.07.05  S.Koga  DEL
        //private string _sectionGuideName;
        # endregion

        //比較用clone
        private PosTerminalMg _posTerminalMgClone;

        // ADD 2009/06/05 ------>>>
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private int _totalCount;
        private Hashtable _posTerminalMgTable;
        // ADD 2009/06/05 ------<<<
        
        // プロパティ用
		private bool _canPrint;
		/// <summary>終了プロパティ</summary>
		/// <remarks>
		/// アセンブリを終了するか、しないかを取得又はセットします。
		/// </remarks>
		private bool _canClose;

        // ADD 2009/06/05 ------>>>
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // ホスト名
        string _hostName = ""; 
        // IPアドレス
        IPAddress _address = null;
        // ADD 2009/06/05 ------<<<
        
        // メインフレームグリッド用表示項目タイトル
        private const string HTML_HEADER_TITLE = "設定項目";
		private const string HTML_HEADER_VALUE = "設定値";
		private const string HTML_UNREGISTER = "未設定";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

        // 2007.06.11  S.Koga  ADD --------------------------------------------
        // POS/PC端末区分
        private const string POSPCTERM_1 = "POS端末使用";
        private const string POSPCTERM_2 = "PC端末使用";
        // --------------------------------------------------------------------

        //--- ADD 2008/06/18 ---------->>>>>
        private const string USELANGUAGEDIV_1 = "日本語";
        private const string USELANGUAGEDIV_2 = "英語";
        private const string USELANGUAGEDIV_3 = "ロシア語";
        private const string USELANGUAGEDIV_4 = "中国語";
        private const string USELANGUAGEDIV_5 = "アラビア語";

        private const string USELANGUAGEDIVCD_1 = "ja";
        private const string USELANGUAGEDIVCD_2 = "en";
        private const string USELANGUAGEDIVCD_3 = "ru";
        private const string USELANGUAGEDIVCD_4 = "zh-CN";
        private const string USELANGUAGEDIVCD_5 = "ar";

        private const string USECULTUREDIVCD_1 = "ja-JP";
        private const string USECULTUREDIVCD_2 = "en-US";
        private const string USECULTUREDIVCD_3 = "ru-RU";
        private const string USECULTUREDIVCD_4 = "zh-CN";
        private const string USECULTUREDIVCD_5 = "ar-AE";
        //--- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        private const string PROGRAM_ID = "MAPOS09150U";    // プログラムID

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_CASH_REGISTER_NO_TITLE = "端末番号";
        private const string VIEW_USE_LANGUAGE_DIV_CD_TITLE = "使用言語区分";
        private const string VIEW_MACHINE_IP_ADDR_TITLE = "IPアドレス";
        private const string VIEW_MACHINE_NAME_TITLE = "端末名";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        // ADD 2009/06/05 ------<<<
        
        #endregion

		# region Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAPOS09150UA());
		}
		# endregion

		# region Properties
		/// <summary>印刷プロパティ</summary>
		/// <remarks>
		/// 印刷可能かどうかの設定を取得します。（false固定）
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

		/// <summary>画面クローズプロパティ</summary>
		/// <remarks>
		/// 画面クローズを許可するかどうかの設定を取得または設定します。
		/// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

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

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        // ADD 2009/06/05 ------<<<
        
		# endregion

		# region Public Methods
		/// <summary>印刷処理</summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note			:	（未実装）</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

        // DEL 2009/06/05 ------>>>
        ///// <summary>HTMLコード取得処理</summary>
        ///// <returns>HTMLコード</returns>
        ///// <remarks>
        ///// <br>Note			:	ビュー用のＨＴＭＬコードを取得します。</br>
        ///// <br>Programmer		:	古賀　小百合</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //public string GetHtmlCode()
        //{
        //    string outCode = "";

        //    // tHtmlGenerate部品の引数を生成する
        //    // 2007.06.11  S.Koga  amend --------------------------------------
        //    //string [,] array = new string[3,2];
        //    //string[,] array = new string[4, 2];       // DEL 2008/06/18
        //    string[,] array = new string[3, 2];         // ADD 2008/06/18
        //    // ----------------------------------------------------------------
			
        //    this.tHtmlGenerate1.Coltypes = new int[2];

        //    this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
        //    this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
				
        //    array[0,0] = HTML_HEADER_TITLE; //「設定項目」
        //    array[0,1] = HTML_HEADER_VALUE; //「設定値」

        //    //array[1,0] = this.Section_Title.Text;            //拠点       // DEL 2008/06/18
        //    //array[2, 0] = this.CashRegisterNo_Title.Text;    //レジ番号   // DEL 2008/06/18
        //    array[1, 0] = this.CashRegisterNo_Title.Text;    //端末番号     // ADD 2008/06/18
        //    // 2007.06.11  S.Koga  ADD ----------------------------------------
        //    //array[3, 0] = this.PosPCTerm_Title.Text;        // POS/PC端末区分     // DEL 2008/06/18
        //    // ----------------------------------------------------------------

        //    array[2, 0] = this.UseLanguageDivCd_Title.Text;   // 使用言語区分       // ADD 2008/06/18

        //    // レジ番号取得
        //    int status = this.posTerminalMgAcs.Search(out this.posTerminalMg, this._enterpriseCode);

        //    if (status == 0)
        //    {
        //        // 2007.07.05  S.Koga  AMEND ----------------------------------
        //        // 拠点
        //        //if (!this._sectionGuideName.Equals(""))
        //        //{
        //        //    array[1, 1] = this._sectionGuideName;
        //        //}
        //        //else
        //        //{
        //        //    array[1, 1] = HTML_UNREGISTER;
        //        //}
        //        // 端末設置拠点
        //        //array[1, 1] = GetSectionName(posTerminalMg.SectionCode);      // DEL 2008/06/18
        //        // ------------------------------------------------------------

        //        // 端末番号
        //        //array[2, 1] = posTerminalMg.CashRegisterNo.ToString();        // DEL 2008/06/18
        //        array[1, 1] = posTerminalMg.CashRegisterNo.ToString();
        //        //--- DEL 2008/06/18 ---------->>>>>
        //        // 2007.06.11  S.Koga  ADD ------------------------------------
        //        // POS/PC端末区分
        //        //switch (posTerminalMg.PosPCTermCd)
        //        //{
        //        //    case 1: // POS端末使用
        //        //        {
        //        //            array[3, 1] = POSPCTERM_1;
        //        //            break;
        //        //        }
        //        //    case 2: // PC端末使用
        //        //        {
        //        //            array[3, 1] = POSPCTERM_2;
        //        //            break;
        //        //        }
        //        //    default:
        //        //        {
        //        //            array[3, 1] = HTML_UNREGISTER;
        //        //            break;
        //        //        }
        //        //}
        //        // ------------------------------------------------------------
        //        //--- DEL 2008/06/18 ----------<<<<<
        //        //--- ADD 2008/06/18 ---------->>>>>
        //        if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_1;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_2;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_3;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_4;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_5;
        //        }
        //        else
        //        {
        //            array[2, 1] = HTML_UNREGISTER;
        //        }
        //        //--- ADD 2008/06/18 ----------<<<<<
        //    }
        //    else
        //    {
        //        // 2007.07.05  S.Koga  AMEND ----------------------------------
        //        // ※ 登録データがない場合の端末設置拠点のフレーム上表示は"未設定"とします。
        //        // ------------------------------------------------------------
        //        //if (!this._sectionGuideName.Equals(""))
        //        //{
        //        //    array[1, 1] = this._sectionGuideName;
        //        //}
        //        //else
        //        //{
        //        //    array[1, 1] = HTML_UNREGISTER;
        //        //}
        //        array[1, 1] = HTML_UNREGISTER;
        //        // ------------------------------------------------------------
        //        array[2, 1] = HTML_UNREGISTER;
        //        // 2007.06.11  S.Koga  ADD ------------------------------------
        //        //array[3, 1] = HTML_UNREGISTER;        // DEL 2008/06/18
        //        // ------------------------------------------------------------
        //    }

        //    this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);
        //    return outCode;
        //}
        // DEL 2009/06/05 ------<<<
		
        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
        ///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._posTerminalMgTable.Clear();

            // 全検索
            status = this._posTerminalMgAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 2010/06/29 Add >>>
                        status = this._posTerminalMgAcs.SearchServer(out _serverPosTerminalList, this._enterpriseCode);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                // 2010/06/29 Add <<<
                                int index = 0;
                                // 上記以外は、検索結果を展開
                                foreach (PosTerminalMg posTerminalMg in retList)
                                {
                                    // 端末管理設定のデータセット展開処理
                                    PosTerminalMgToDataSet(posTerminalMg.Clone(), index);
                                    ++index;
                                }

                                break;
                            // 2010/06/29 Add >>>
                            default:
                                {
                                    TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                                        PROGRAM_ID,							    // アセンブリID
                                        this.Text,              　　            // プログラム名称
                                        "Search",                               // 処理名称
                                        TMsgDisp.OPE_GET,                       // オペレーション
                                        "読み込みに失敗しました。",				// 表示するメッセージ
                                        status,									// ステータス値
                                        this._posTerminalMgAcs,					// エラーが発生したオブジェクト
                                        MessageBoxButtons.OK,					// 表示するボタン
                                        MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                                    break;
                                }
                        }
                        break;
                        // 2010/06/29 Add <<<
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                            PROGRAM_ID,							    // アセンブリID
                            this.Text,              　　            // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",				// 表示するメッセージ
                            status,									// ステータス値
                            this._posTerminalMgAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,					// 表示するボタン
                            MessageBoxDefaultButton.Button1);		// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

            int status;

            // 端末管理設定情報の論理削除処理
            status = this._posTerminalMgAcs.LogicalDelete(ref posTerminalMg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._posTerminalMgAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // 端末管理設定情報クラスのデータセット展開処理
            PosTerminalMgToDataSet(posTerminalMg.Clone(), this.DataIndex);

            return status;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 端末番号
            appearanceTable.Add(VIEW_CASH_REGISTER_NO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000", Color.Black));
            // 使用言語区分
            appearanceTable.Add(VIEW_USE_LANGUAGE_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // IPアドレス
            appearanceTable.Add(VIEW_MACHINE_IP_ADDR_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 端末名
            appearanceTable.Add(VIEW_MACHINE_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        // ADD 2009/06/05 ------<<<
        
		# endregion

		# region private Methods

        /// <summary>拠点ガイド名称取得処理</summary>
        /// <param name="sectioncode">拠点コード</param>
        /// <returns>指定された拠点コードの拠点ガイド名称</returns>
        /// <remarks>
        /// <br>Note        : 指定されたコードのガイド名称を取得します。</br>
        /// <br>            : ガイド名称が存在しない場合は"未設定"を返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        private string GetSectionName(string sectioncode)
        {
            string sectionname = "";

            if (!this._posTerminalMgAcs.GetSectionName(out sectionname, sectioncode))
                sectionname = HTML_UNREGISTER;

            return sectionname;
        }

		/// <summary>画面初期設定処理</summary>
		/// <remarks>
		/// <br>Note			:	画面の初期設定を行います。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            //// 拠点コード
            //this.SectionCode_tEdit.Clear();
            //// 拠点名称
            //this.SectionGuideNm_tEdit.Clear();
            //--- DEL 2008/06/18 ---------->>>>>
            //// 端末設置拠点
            //this.Section_tComboEditor.Items.Clear();              // DEL 2008/06/18
            //Hashtable sectionList = this.posTerminalMgAcs.GetSecInfoList();
            //ArrayList keys = new ArrayList();
            //foreach (string key in sectionList.Keys)
            //    keys.Add(key);
            //for (int count = 0; count < sectionList.Count; count++)
            //{
            //    string sectioncode = keys[count].ToString();
            //    this.Section_tComboEditor.Items.Add(sectioncode, sectionList[sectioncode].ToString());
            //}
            //this.Section_tComboEditor.SelectedIndex = -1;
            //--- DEL 2008/06/18 ----------<<<<<
            
            // ----------------------------------------------------------------
            // 端末番号
            this.CashRegisterNo_tNedit.Clear();
            //--- DEL 2008/06/18 ---------->>>>>
            // POS/PC端末区分
            //this.PosPCTerm_tComboEditor.Items.Clear();
            //this.PosPCTerm_tComboEditor.Items.Add(0, " ");
            //this.PosPCTerm_tComboEditor.Items.Add(1, POSPCTERM_1);
            //this.PosPCTerm_tComboEditor.Items.Add(2, POSPCTERM_2);
            //this.PosPCTerm_tComboEditor.SelectedIndex = 0;
            //--- DEL 2008/06/18 ----------<<<<<

            //--- ADD 2008/06/18 ---------->>>>>
            // 使用言語区分
            this.UseLanguageDivCd_tComboEditor.Items.Clear();
            this.UseLanguageDivCd_tComboEditor.Items.Add(0, USELANGUAGEDIV_1);
            this.UseLanguageDivCd_tComboEditor.Items.Add(1, USELANGUAGEDIV_2);
            this.UseLanguageDivCd_tComboEditor.Items.Add(2, USELANGUAGEDIV_3);
            this.UseLanguageDivCd_tComboEditor.Items.Add(3, USELANGUAGEDIV_4);
            this.UseLanguageDivCd_tComboEditor.Items.Add(4, USELANGUAGEDIV_5);
            //--- ADD 2008/06/18 ----------<<<<<

        }

        ///// <summary>画面情報－端末管理設定クラス格納処理</summary>
        ///// <remarks>
        ///// <br>Note			:	画面情報から端末管理設定クラスにデータを
        /////							格納します。</br>
        ///// <br>Programmer		:	古賀　小百合</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //private void ScreenToPosTerminalMg()
        //{
        //    // 新規の場合
        //    posTerminalMg = new PosTerminalMg();
			
        //    //ヘッダ部
        //    this.posTerminalMg.EnterpriseCode = this._enterpriseCode;

        //    // 2007.07.05  S.Koga  AMEND --------------------------------------
        //    // 拠点コード
        //    //this.posTerminalMg.SectionCode    = this.SectionCode_tEdit.Text;

        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //// 端末設置拠点
        //    //if(this.Section_tComboEditor.SelectedItem != null)
        //    //    this.posTerminalMg.SectionCode = this.Section_tComboEditor.SelectedItem.DataValue.ToString();
        //    //// ----------------------------------------------------------------
        //    //--- DEL 2008/06/18 ----------<<<<<

        //    // 端末番号
        //    this.posTerminalMg.CashRegisterNo = this.CashRegisterNo_tNedit.GetInt();

        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //// POS/PC端末区分
        //    //if(this.PosPCTerm_tComboEditor.SelectedItem != null)
        //    //    this.posTerminalMg.PosPCTermCd = (int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue;
        //    //--- DEL 2008/06/18 ----------<<<<<

        //    //--- ADD 2008/06/18 ---------->>>>>
        //    // 使用言語区分
        //    if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
        //    {
        //        if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_1)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_1;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_1;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_2)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_2;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_2;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_3)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_3;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_3;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_4)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_4;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_4;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_5)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_5;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_5;
        //        }
        //    }
        //    //--- ADD 2008/06/18 ----------<<<<<

        //}

		/// <summary>画面情報－端末管理設定クラス格納処理(保存確認メッセージ用)</summary>
		/// <param name="posTerminalMg">端末管理設定クラス</param>
		/// <remarks>
		/// <br>Note			:	画面情報から端末管理設定クラスにデータを
		///							格納します。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
        private void DispToPosTerminalMg(ref PosTerminalMg posTerminalMg)
        {
            if (posTerminalMg == null)
            {
                // 新規の場合
                posTerminalMg = new PosTerminalMg();
            }
            
            //ヘッダ部
            posTerminalMg.EnterpriseCode = this._enterpriseCode;

            //明細部
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            // 拠点コード
            //posTerminalMg.SectionCode = this.SectionCode_tEdit.Text;
            //--- DEL 2008/06/18 ---------->>>>>
            //// 端末設置拠点
            //if (this.Section_tComboEditor.SelectedItem != null)
            //    posTerminalMg.SectionCode = this.Section_tComboEditor.SelectedItem.DataValue.ToString();
            //// ----------------------------------------------------------------
            //--- DEL 2008/06/18 ----------<<<<<
            posTerminalMg.CashRegisterNo = this.CashRegisterNo_tNedit.GetInt();
            //--- DEL 2008/06/18 ---------->>>>>
            //// POS/PC端末区分
            //if (this.PosPCTerm_tComboEditor.SelectedItem != null)
            //    posTerminalMg.PosPCTermCd = (int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue;
            //--- DEL 2008/06/18 ----------<<<<<
            // DEL 2009/06/09 ------>>>
            //--- ADD 2008/06/18 ---------->>>>>
            //// 使用言語区分
            //if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
            //    posTerminalMg.UseLanguageDivCd = this.UseLanguageDivCd_tComboEditor.SelectedItem.DataValue.ToString();
            //--- ADD 2008/06/18 ----------<<<<<
            // DEL 2009/06/09 ------<<<

            // ADD 2009/06/09 ------>>>
            // 使用言語区分
            if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
            {
                if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_1)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_1;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_1;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_2)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_2;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_2;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_3)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_3;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_3;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_4)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_4;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_4;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_5)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_5;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_5;
                }
            }
            // ADD 2009/06/09 ------<<<

            // ADD 2009/06/05 ------>>>
            // IPアドレス
            string ipaddres = string.Format("{0}.{1}.{2}.{3}", tNedit_MachineIpAddr1.DataText, tNedit_MachineIpAddr2.DataText, tNedit_MachineIpAddr3.DataText, tNedit_MachineIpAddr4.DataText);
            posTerminalMg.MachineIpAddr = ipaddres;
            // 端末名称
            posTerminalMg.MachineName = tEdit_MachineName.Text;
            // ADD 2009/06/05 ------<<<
        }	

        ///// <summary>画面展開処理</summary>
        ///// <remarks>
        ///// <br>Note			:	端末管理設定クラスから画面にデータを展開します。</br>
        ///// <br>Programmer		:	古賀　小百合</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //private void companyInfToScreen()
        //{
        //    # region 2007.07.05  S.Koga  DEL
        //    //this.SectionCode_tEdit.Text = this._sectionCode;
        //    //this.SectionGuideNm_tEdit.Text = this._sectionGuideName;
        //    # endregion
        //    if (posTerminalMg != null)
        //    {
        //        // 2007.07.05  S.Koga  ADD ------------------------------------
        //        //this.Section_tComboEditor.Value = this.posTerminalMg.SectionCode;                 // DEL 2008/06/18
        //        // ------------------------------------------------------------
        //        this.CashRegisterNo_tNedit.SetInt(this.posTerminalMg.CashRegisterNo);
        //        //this.PosPCTerm_tComboEditor.Value = this.posTerminalMg.PosPCTermCd;               // DEL 2008/06/18

        //        //--- ADD 2008/06/18 ---------->>>>>
        //        if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
        //        }
        //        else
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = null;
        //        }
        //        //--- ADD 2008/06/18 ----------<<<<<
        //    }
        //    // 2007.07.05  S.Koga  ADD ----------------------------------------
        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //else
        //    //    this.Section_tComboEditor.Value = this._sectionCode;
        //    //--- DEL 2008/06/18 ----------<<<<<
        //    // ----------------------------------------------------------------
        //    //this.PosPCTerm_tComboEditor.Value = this.posTerminalMg.PosPCTermCd;
        //}

		/// <summary>端末管理設定画面展開処理</summary>
		/// <remarks>
		/// <br>Note			:	端末管理設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void ScreenClear()
		{
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            //this.SectionCode_tEdit.Clear();
            //this.SectionGuideNm_tEdit.Clear();
            //this.Section_tComboEditor.SelectedIndex = -1;         // DEL 2008/06/18
            // ----------------------------------------------------------------
            this.CashRegisterNo_tNedit.Clear();
            //this.PosPCTerm_tComboEditor.SelectedIndex = 0;        // DEL 2008/06/18
            this.UseLanguageDivCd_tComboEditor.SelectedIndex = -1;  // ADD 2008/06/18

            // ADD 2009/06/05 ------>>>
            this.tNedit_MachineIpAddr1.Clear();
            this.tNedit_MachineIpAddr2.Clear();
            this.tNedit_MachineIpAddr3.Clear();
            this.tNedit_MachineIpAddr4.Clear();
            this.tEdit_MachineName.Clear();
            // ADD 2009/06/05 ------<<<
		}

        /// <summary>画面チェック処理</summary>
		/// <param name="control">コントロール</param>
		/// <param name="checkMessage">メッセージ</param>
		/// <returns>true:正常　false:異常</returns>
		/// <remarks>
		/// <br>Note		:	画面入力データのチェック結果を返却します。</br>
		/// <br>Programer	:	古賀　小百合</br>
		/// <br>Date		:	2007.04.16</br>
		/// </remarks>
		private bool CheckInputData(ref Control control,ref string checkMessage)
		{
            //--- DEL 2008/06/18 ---------->>>>>
            //// 2007.07.05  S.Koga  ADD ----------------------------------------
            //// 端末設置拠点
            //if (this.Section_tComboEditor.SelectedItem == null)
            //{
            //    control = this.Section_tComboEditor;
            //    checkMessage = this.Section_Title.Text + "を選択して下さい。";
            //    return false;
            //}
            //--- DEL 2008/06/18 ----------<<<<<

            // ----------------------------------------------------------------
		    // 売上形式コード
            if (this.CashRegisterNo_tNedit.Text == "0" || this.CashRegisterNo_tNedit.Text == "")
            {
                control = this.CashRegisterNo_tNedit;
                checkMessage = this.CashRegisterNo_Title.Text + "を入力して下さい。";
                return false;
            }
            // ADD 2009/06/05 ------>>>
            else
            {
                if ((this._posTerminalMgClone.CashRegisterNo != 0) &&
                    (this.CashRegisterNo_tNedit.GetInt() != this._posTerminalMgClone.CashRegisterNo))
                {
                    // 端末番号が変更された場合、サーバーの登録済み端末番号と重複しないかチェック
                    PosTerminalMg readPosTerminalMg;
                    int status = this._posTerminalMgAcs.Read(out readPosTerminalMg, this._enterpriseCode, this.CashRegisterNo_tNedit.GetInt());
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (readPosTerminalMg != null))
                    {
                        control = this.CashRegisterNo_tNedit;
                        checkMessage = string.Format("{0}:【{1}】は他の端末で使用中のため、\n別の{2}を設定して下さい。", this.CashRegisterNo_Title.Text, this.CashRegisterNo_tNedit.GetInt(), this.CashRegisterNo_Title.Text);
                        return false;
                    }
                }
            }
            // ADD 2009/06/05 ------<<<
            
            //--- DEL 2008/06/18 ---------->>>>>
            //// POS/PC端末区分
            //if((this.PosPCTerm_tComboEditor.SelectedItem == null) || ((int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue == 0)){
            //    control = this.PosPCTerm_tComboEditor;
            //    checkMessage = this.PosPCTerm_Title.Text + "を選択して下さい。";
            //    return false;
            //}
            //--- DEL 2008/06/18 ----------<<<<<

            //--- ADD 2008/06/18 ---------->>>>>
            // 使用言語区分
            if (this.UseLanguageDivCd_tComboEditor.SelectedItem == null)
            {
                control = this.UseLanguageDivCd_tComboEditor;
                checkMessage = this.UseLanguageDivCd_Title.Text + "を選択して下さい。";
                return false;
            }
            //--- ADD 2008/06/18 ----------<<<<<

            // ADD 2009/06/05 ------>>>
            // 2010/06/29 >>>
            //if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1 && _scmFlg == true)
            // 2010/06/29 <<<
            {
                // IPアドレス
                if (tNedit_MachineIpAddr1.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr1;
                    checkMessage = this.ultraLabel1.Text + "を設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr2.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr2;
                    checkMessage = this.ultraLabel1.Text + "を設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr3.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr3;
                    checkMessage = this.ultraLabel1.Text + "を設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr4.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr4;
                    checkMessage = this.ultraLabel1.Text + "を設定して下さい。";
                    return false;
                }

                if (tNedit_MachineIpAddr1.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr1;
                    checkMessage = this.ultraLabel1.Text + "は【0.0.0.0】～【255.255.255.255】の\n範囲で設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr2.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr2;
                    checkMessage = this.ultraLabel1.Text + "は【0.0.0.0】～【255.255.255.255】の\n範囲で設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr3.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr3;
                    checkMessage = this.ultraLabel1.Text + "は【0.0.0.0】～【255.255.255.255】の\n範囲で設定して下さい。";
                    return false;
                }
                else if (tNedit_MachineIpAddr4.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr4;
                    checkMessage = this.ultraLabel1.Text + "は【0.0.0.0】～【255.255.255.255】の\n範囲で設定して下さい。";
                    return false;
                }

                // 端末名称
                if (tEdit_MachineName.DataText == "")
                {
                    control = this.tEdit_MachineName;
                    checkMessage = this.ultraLabel2.Text + "を設定して下さい。";
                    return false;
                }
            }
            // ADD 2009/06/05 ------<<<

            return true;
		}
		
		/// <summary>排他処理</summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.16</br>
		/// </remarks>
        //private void ExclusiveTransaction(int status)
        private void ExclusiveTransaction(int status, bool hide)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
                    //this.Hide();
                    if (hide == true)
                    {
                        CloseForm(DialogResult.Cancel);
                    }
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
                    //this.Hide();
                    if (hide == true)
                    {
                        CloseForm(DialogResult.Cancel);
                    }
					break;
				}
			}
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable scmTtlStTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。

            scmTtlStTable.Columns.Add(DELETE_DATE, typeof(string));			                // 削除日

            scmTtlStTable.Columns.Add(VIEW_CASH_REGISTER_NO_TITLE, typeof(int));            // 端末番号
            scmTtlStTable.Columns.Add(VIEW_USE_LANGUAGE_DIV_CD_TITLE, typeof(string));      // 使用言語区分
            scmTtlStTable.Columns.Add(VIEW_MACHINE_IP_ADDR_TITLE, typeof(string));          // IPアドレス
            scmTtlStTable.Columns.Add(VIEW_MACHINE_NAME_TITLE, typeof(string));             // 端末名
            
            scmTtlStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

            this.Bind_DataSet.Tables.Add(scmTtlStTable);
        }

        /// <summary>
        /// 端末管理設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="posTerminalMg">端末管理設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 端末管理設定クラスをデータセットに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void PosTerminalMgToDataSet(PosTerminalMg posTerminalMg, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (posTerminalMg.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = posTerminalMg.UpdateDateTimeJpInFormal;
            }

            // 端末番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASH_REGISTER_NO_TITLE] = posTerminalMg.CashRegisterNo;
            // 使用言語区分
            string useLanguageDivCd = "";
            if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
            {
                useLanguageDivCd = USELANGUAGEDIV_1;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
            {
                useLanguageDivCd = USELANGUAGEDIV_2;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
            {
                useLanguageDivCd = USELANGUAGEDIV_3;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
            {
                useLanguageDivCd = USELANGUAGEDIV_4;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
            {
                useLanguageDivCd = USELANGUAGEDIV_5;
            }
            else
            {
                useLanguageDivCd = HTML_UNREGISTER;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_USE_LANGUAGE_DIV_CD_TITLE] = useLanguageDivCd;

            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                // 2010/06/29 Add >>>
                if (_scmFlg)
                {
                    // 2010/06/29 Add <<<
                    // 管理者モード
                    // IPアドレス
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = posTerminalMg.MachineIpAddr;
                    // 端末名
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = posTerminalMg.MachineName;
                    // 2010/06/29 Add >>>
                }
                else
                {
                    // 一般ユーザーモード
                    // IPアドレス
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = _address.ToString();
                    // 端末名
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = _hostName;
                }
                // 2010/06/29 Add <<<
            }
            else
            {
                // 一般ユーザーモード
                // IPアドレス
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = _address.ToString();
                // 端末名
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = _hostName;
            }

            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = posTerminalMg.FileHeaderGuid;

            if (this._posTerminalMgTable.ContainsKey(posTerminalMg.FileHeaderGuid) == true)
            {
                this._posTerminalMgTable.Remove(posTerminalMg.FileHeaderGuid);
            }
            this._posTerminalMgTable.Add(posTerminalMg.FileHeaderGuid, posTerminalMg);
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
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
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._posTerminalMgClone = null;

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
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.CashRegisterNo_tNedit.Enabled = true;
                        this.UseLanguageDivCd_tComboEditor.Enabled = true;

                        if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                        {
                            // 2010/06/29 Add SCMオプションが有効なら管理者モードで実行 >>>
                            if (_scmFlg == true)
                            {
                                // 2010/06/29 Add <<<
                                // 管理者モード
                                this.tNedit_MachineIpAddr1.Enabled = true;
                                this.tNedit_MachineIpAddr2.Enabled = true;
                                this.tNedit_MachineIpAddr3.Enabled = true;
                                this.tNedit_MachineIpAddr4.Enabled = true;
                                this.tEdit_MachineName.Enabled = true;
                                // 2010/06/29 Add >>>
                            }
                            else
                            {
                                // 一般ユーザーモード
                                this.tNedit_MachineIpAddr1.Enabled = false;
                                this.tNedit_MachineIpAddr2.Enabled = false;
                                this.tNedit_MachineIpAddr3.Enabled = false;
                                this.tNedit_MachineIpAddr4.Enabled = false;
                                this.tEdit_MachineName.Enabled = false;
                            }
                            // 2010/06/29 Add <<<
                        }
                        else
                        {
                            // 一般ユーザーモード
                            this.tNedit_MachineIpAddr1.Enabled = false;
                            this.tNedit_MachineIpAddr2.Enabled = false;
                            this.tNedit_MachineIpAddr3.Enabled = false;
                            this.tNedit_MachineIpAddr4.Enabled = false;
                            this.tEdit_MachineName.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.CashRegisterNo_tNedit.Enabled = false;
                        this.UseLanguageDivCd_tComboEditor.Enabled = false;
                        this.tNedit_MachineIpAddr1.Enabled = false;
                        this.tNedit_MachineIpAddr2.Enabled = false;
                        this.tNedit_MachineIpAddr3.Enabled = false;
                        this.tNedit_MachineIpAddr4.Enabled = false;
                        this.tEdit_MachineName.Enabled = false;
                        
                        break;
                    }
            }
        }

        /// <summary>
        /// 端末管理設定クラス画面展開処理
        /// </summary>
        /// <param name="posTerminalMg">端末管理設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 端末管理設定オブジェクトから画面にデータを展開します。</br>
        /// <br></br>
        /// </remarks>
        private void PosTerminalMgToScreen(PosTerminalMg posTerminalMg)
        {
            // 2010/06/29 Add >>>
            bool serverFlg = false;
            bool adminFlg = false;
            PosTerminalMg serverPosTerminalMg = new PosTerminalMg();
            // Adminでログイン且つSCMフラグが有効なら管理者で実行
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)
                {
                    adminFlg = true;
                }
            }
            // 操作している端末の端末管理設定がUSER_APにあるかチェック
            if (adminFlg == false)
            {
                foreach (PosTerminalMg chkPosTerminalMg in _serverPosTerminalList)
                {
                    if (chkPosTerminalMg.MachineIpAddr == _address.ToString())
                    {
                        serverFlg = true;
                        serverPosTerminalMg = chkPosTerminalMg;
                        break;
                    }
                }
            }
            // 管理者ではなく、設定がUSER_APにある場合は初期表示はUSER_APの内容で表示する。
            if (adminFlg == false && serverFlg == true)
            {
                // 端末番号
                this.CashRegisterNo_tNedit.SetInt(serverPosTerminalMg.CashRegisterNo);

                // 使用言語区分
                if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
                }
                else
                {
                    this.UseLanguageDivCd_tComboEditor.Text = null;
                }

                // IPアドレス
                string[] parts;
                parts = Strings.Split(serverPosTerminalMg.MachineIpAddr, ".", -1, CompareMethod.Binary);
                if (parts.Length >= 4)
                {
                    this.tNedit_MachineIpAddr1.DataText = parts[0];
                    this.tNedit_MachineIpAddr2.DataText = parts[1];
                    this.tNedit_MachineIpAddr3.DataText = parts[2];
                    this.tNedit_MachineIpAddr4.DataText = parts[3];
                }
                // 端末名
                this.tEdit_MachineName.Text = serverPosTerminalMg.MachineName;
            }
            else
            {
                // 2010/06/29 Add <<<
                // 端末番号
                this.CashRegisterNo_tNedit.SetInt(posTerminalMg.CashRegisterNo);

                // 使用言語区分
                if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
                }
                else
                {
                    this.UseLanguageDivCd_tComboEditor.Text = null;
                }

                if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                {
                    // 2010/06/29 Add SCMオプションが有効なら管理者モードで実行 >>>
                    if (_scmFlg == true)
                    {
                        // 2010/06/29 Add <<<
                        // 管理者モード
                        // IPアドレス
                        string[] parts;
                        parts = Strings.Split(posTerminalMg.MachineIpAddr, ".", -1, CompareMethod.Binary);
                        if (parts.Length >= 4)
                        {
                            this.tNedit_MachineIpAddr1.DataText = parts[0];
                            this.tNedit_MachineIpAddr2.DataText = parts[1];
                            this.tNedit_MachineIpAddr3.DataText = parts[2];
                            this.tNedit_MachineIpAddr4.DataText = parts[3];
                        }
                        // 端末名
                        this.tEdit_MachineName.Text = posTerminalMg.MachineName;
                        // 2010/06/29 Add >>>
                    }
                    else
                    {
                        // 一般ユーザーモード
                        string[] parts;
                        parts = Strings.Split(_address.ToString(), ".", -1, CompareMethod.Binary);
                        if (parts.Length >= 4)
                        {
                            this.tNedit_MachineIpAddr1.DataText = parts[0];
                            this.tNedit_MachineIpAddr2.DataText = parts[1];
                            this.tNedit_MachineIpAddr3.DataText = parts[2];
                            this.tNedit_MachineIpAddr4.DataText = parts[3];
                        }
                        this.tEdit_MachineName.Text = _hostName;
                    }
                    // 2010/06/29 Add <<<
                }
                else
                {
                    // 一般ユーザーモード
                    string[] parts;
                    parts = Strings.Split(_address.ToString(), ".", -1, CompareMethod.Binary);
                    if (parts.Length >= 4)
                    {
                        this.tNedit_MachineIpAddr1.DataText = parts[0];
                        this.tNedit_MachineIpAddr2.DataText = parts[1];
                        this.tNedit_MachineIpAddr3.DataText = parts[2];
                        this.tNedit_MachineIpAddr4.DataText = parts[3];
                    }
                    this.tEdit_MachineName.Text = _hostName;
                }
            }   // 2010/06/29 Add
        }

        /// <summary>
        /// ローカルマシン情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ローカルマシン情報を取得します。</br>
        /// <br></br>
        /// </remarks>
        private void GetHostInfo()
        {
            // ローカルマシン名とIPアドレスを取得
            _hostName = Dns.GetHostName();


            // DEL 2009/08/11 IPアドレスの入力制御の変更および追加 ---------->>>>>
            //IPAddress[] adrList = Dns.GetHostAddresses(_hostName);
            //foreach (IPAddress address in adrList)
            //{
            //    _address = address;
            //}
            // DEL 2009/08/11 IPアドレスの入力制御の変更および追加 ----------<<<<<
            // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ---------->>>>>
            // IPアドレスを取得
            IPHostEntry ipHostEntry = Dns.GetHostEntry(_hostName);
            foreach (IPAddress ipAddress in ipHostEntry.AddressList)
            {
                if (IsIPv4Address(ipAddress.ToString()))
                {
                    _address = ipAddress;
                    break;
                }
            }
            // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ----------<<<<<
        }
        // ADD 2009/06/05 ------<<<

		# endregion

		# region Control Events
		/// <summary>Form.Load イベント(MAPOS09150UA)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void MAPOS09150UA_Load(object sender, System.EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
            // ADD 2009/06/05 ------>>>
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            // ADD 2009/06/05 ------<<<
            
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            // ADD 2009/06/05 ------>>>
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            // ADD 2009/06/05 ------<<<
            

			// 画面初期設定処理
			ScreenInitialSetting();
		}

        /// <summary>Control.Click イベント(Ok_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	保存ボタンコントロールがクリックされたときに
		///							発生します。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			SavePosTerminalMg();
		}

		/// <summary>保存処理(SavePosTerminalMg())</summary>
		/// <remarks>
		/// <br>Note　　　      : 保存処理を行います。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void SavePosTerminalMg()
		{

			Control control = null;
			string checkMessage = "";
			bool ret = true;

			//画面データ入力チェック処理
			ret = CheckInputData( ref control ,ref checkMessage );
			if(ret == false )
			{
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					"MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
					checkMessage, 						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン

				control.Focus();
				return;
			}

            // DEL 2009/06/05 ------>>>
            //// 画面から端末管理設定表示クラスにデータをセットします。
            //ScreenToPosTerminalMg();
            // DEL 2009/06/05 ------<<<

            // ADD 2009/06/05 ------>>>
            // 端末管理では、テーブルキー項目が修正可能のため、
            // 更新時は既存レコードの削除→新規作成とする
            PosTerminalMg posTerminalMg = null;

            // 画面情報を取得
            DispToPosTerminalMg(ref posTerminalMg);
            // ADD 2009/06/05 ------<<<

            // ADD 2009/09/24 同端末名の登録を許可しない仕様とする ---------->>>>>
            // 同端末名の登録があった場合の処理
            if (!GetReadyToWrite(posTerminalMg)) return;
            // ADD 2009/09/24 同端末名の登録を許可しない仕様とする ----------<<<<<

			// 端末管理設定マスタ登録
            //int status = this.posTerminalMgAcs.Write( ref posTerminalMg, this._posTerminalMgClone);   // DEL 2009/06/05
            // ADD 2009/06/05 ------>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this.DataIndex < 0)
            {
                // 新規
                status = this._posTerminalMgAcs.WriteAll(ref posTerminalMg, null);
            }
            else
            {
                // 更新
                status = this._posTerminalMgAcs.WriteAll(ref posTerminalMg, this._posTerminalMgClone);
            }
            // ADD 2009/06/05 ------<<<
            
            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    //ExclusiveTransaction(status);
                    ExclusiveTransaction(status, true);
                    return ;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
						"端末管理設定", 					// プログラム名称
						"SavePosTerminalMg", 				// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._posTerminalMgAcs, 			// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					
					return ;
				}
			}

            // 端末管理設定情報クラスのデータセット展開処理
			PosTerminalMgToDataSet(posTerminalMg, this.DataIndex);

			DialogResult dialogResult = DialogResult.OK;

			Mode_Label.Text = UPDATE_MODE;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;    // ADD 2009/06/05

			this._posTerminalMgClone = null;

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
            // 2010/07/01 Add >>>
            // 保存後再検索する。
            int totalCount = 0;
            int readCount = 0;
            Search(ref totalCount, readCount);
            // 2010/07/01 Add <<<
		}

		/// <summary>Control.Click イベント(Cancel_Button)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note			:	閉じるボタンコントロールがクリックされたときに
		///							発生します。</br>
		/// <br>Programmer		:	古賀　小百合</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            ////保存確認
            //PosTerminalMg comparePosTerminalMg = new PosTerminalMg();
            //comparePosTerminalMg = this.posTerminalMg.Clone();   
            ////現在の画面情報を取得する
            //DispToPosTerminalMg(ref comparePosTerminalMg);
            ////最初に取得した画面情報と比較 
            //if (!(this._posTerminalMgClone.Equals(comparePosTerminalMg)))	
            //{
            //    //画面情報が変更されていた場合は、保存確認メッセージを表示する 
            //    // 保存確認
            //    DialogResult res = TMsgDisp.Show( 
            //        this, 								// 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
            //        "MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
            //        null, 								// 表示するメッセージ
            //        0, 									// ステータス値
            //        MessageBoxButtons.YesNoCancel );	// 表示するボタン
            //    switch(res)
            //    {
            //        case DialogResult.Yes:
            //        {
            //            SavePosTerminalMg();
            //            return;
            //        }
            //        case DialogResult.No:
            //        {
            //            break;
            //        }
            //        default:
            //        {
            //            return;
            //        }
            //    }
            //}

            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                PosTerminalMg compareSCMTtlSt = new PosTerminalMg();

                compareSCMTtlSt = this._posTerminalMgClone.Clone();
                DispToPosTerminalMg(ref compareSCMTtlSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._posTerminalMgClone.Equals(compareSCMTtlSt))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PROGRAM_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SavePosTerminalMg();
                                return;
                            }
                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                this.Cancel_Button.Focus();
                                return;
                            }
                    }
                }
            }

			DialogResult dialogResult = DialogResult.Cancel;
            this._indexBuf = -2;    // ADD 2009/06/05

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			this._posTerminalMgClone = null;

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

		/// <summary>Form.Closing イベント(MAPOS09150UA)</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
		///							ようとしたときに発生します。</br>
		/// <br>Programmer		:	古賀　小百合k</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void MAPOS09150UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._posTerminalMgClone = null;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/// <summary>画面VisibleChangeイベント</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAPOS09150UA_VisibleChanged(object sender, System.EventArgs e)
		{
			
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// メインフレームアクティブ化
				this.Owner.Activate();
				return;
			}

			// データがセットされていたら抜ける
			if(this._posTerminalMgClone != null)
			{
				return;
			}

			Initial_Timer.Enabled = true;

			ScreenClear();		
		}

		/// <summary>画面再構築処理</summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.16</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            // DEL 2009/06/05 ------>>>
            //// companyInfクラス
            //this.posTerminalMg = new PosTerminalMg();

            //int status = posTerminalMgAcs.Search(out this.posTerminalMg, this._enterpriseCode);
            //if (status == 0 || status == 9) 
            //{
                
            //    Mode_Label.Text = UPDATE_MODE;

            //    // 全体初期表示設定クラス画面展開処理
            //    companyInfToScreen();

            //    # region 2007.07.05  S.Koga  DEL
            //    //this.SectionCode_tEdit.Enabled = false;
            //    //this.SectionGuideNm_tEdit.Enabled = false;
            //    # endregion

            //    // 初期フォーカスセット
            //    // 2007.07.05  S.Koga  AMEND ----------------------------------
            //    //this.CashRegisterNo_tNedit.Focus();
            //    //this.CashRegisterNo_tNedit.SelectAll();
            //    //this.Section_tComboEditor.Focus();            // DEL 2008/06/18
            //    //this.Section_tComboEditor.SelectAll();
            //    // ------------------------------------------------------------

            //    if (this.posTerminalMg == null)
            //    {
            //        this.posTerminalMg = new PosTerminalMg();
            //    }
            //    //クローン作成
            //    this._posTerminalMgClone = this.posTerminalMg.Clone();  
            //    //画面情報を比較用クローンにコピーする　　　　　   
            //    DispToPosTerminalMg(ref this._posTerminalMgClone);

            //}
            //else
            //{
            //    // サーチ
            //    TMsgDisp.Show( 
            //        this, 									// 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_STOP, 			// エラーレベル
            //        "MAPOS09150U", 							// アセンブリＩＤまたはクラスＩＤ
            //        "端末管理設定", 						// プログラム名称
            //        "ScreenReconstruction", 				// 処理名称
            //        TMsgDisp.OPE_READ, 						// オペレーション
            //        "端末管理設定マスタの読み込みに失敗しました。", // 表示するメッセージ
            //        status, 								// ステータス値
            //        this.posTerminalMgAcs, 					// エラーが発生したオブジェクト
            //        MessageBoxButtons.OK, 					// 表示するボタン
            //        MessageBoxDefaultButton.Button1 );		// 初期表示ボタン
            //    return;
            //}
            // DEL 2009/06/05 ------<<<

            // ADD 2009/06/05 ------>>>
            if (this.DataIndex < 0)
            {
                PosTerminalMg posTerminalMg = new PosTerminalMg();
                //クローン作成
                this._posTerminalMgClone = posTerminalMg.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                DispToPosTerminalMg(ref this._posTerminalMgClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.CashRegisterNo_tNedit.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

                // 端末管理設定クラス画面展開処理
                PosTerminalMgToScreen(posTerminalMg);

                if (posTerminalMg.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    // 2010/06/29 >>>
                    if (string.IsNullOrEmpty(posTerminalMg.MachineIpAddr))
                        this.Mode_Label.Text = INSERT_MODE;
                    else
                    // 2010/06/29 <<<
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.CashRegisterNo_tNedit.Focus();

                    // クローン作成
                    this._posTerminalMgClone = posTerminalMg.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    DispToPosTerminalMg(ref this._posTerminalMgClone);

                    if (LoginInfoAcquisition.Employee.UserAdminFlag != 1)
                    {
                        // 2010/06/29 Del 自動で書込みは行わない >>>
                        //// 一般ユーザーモード
                        //// サーバーに自端末が登録されているか確認
                        //PosTerminalMg readPosTerminalMg;
                        //int status = this._posTerminalMgAcs.Read(out readPosTerminalMg, this._enterpriseCode, this._posTerminalMgClone.CashRegisterNo);
                        //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        //{
                        //    // サーバーに登録されていない場合は登録する
                        //    PosTerminalMg writePosTerminalMg = new PosTerminalMg();
                        //    DispToPosTerminalMg(ref writePosTerminalMg);
                        //    status = this._posTerminalMgAcs.WriteServer(ref writePosTerminalMg, null);
                        //    switch (status)
                        //    {
                        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        //            {
                        //                break;
                        //            }
                        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        //            {
                        //                ExclusiveTransaction(status, true);
                        //                return;
                        //            }
                        //        default:
                        //            {
                        //                // 登録失敗
                        //                TMsgDisp.Show(
                        //                    this, 								// 親ウィンドウフォーム
                        //                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        //                    "MAPOS09150U", 						// アセンブリＩＤまたはクラスＩＤ
                        //                    "端末管理設定", 					// プログラム名称
                        //                    "ScreenReconstruction", 			// 処理名称
                        //                    TMsgDisp.OPE_UPDATE, 				// オペレーション
                        //                    "登録に失敗しました。", 			// 表示するメッセージ
                        //                    status, 							// ステータス値
                        //                    this._posTerminalMgAcs, 			// エラーが発生したオブジェクト
                        //                    MessageBoxButtons.OK, 				// 表示するボタン
                        //                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        //                return;
                        //            }
                        //    }
                        //}
                        // 2010/06/29 Del <<<
                    }
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
            // ADD 2009/06/05 ------<<<
        }

		/// <summary>改行キー制御処理</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ---------->>>>>
            // IPアドレスの値を補正
            if (e.PrevCtrl == this.tNedit_MachineIpAddr1)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr1, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr2)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr2, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr3)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr3, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr4)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr4, true);
            }
            // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ----------<<<<<
		}

		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

            // 完全削除処理
            int status = this._posTerminalMgAcs.Delete(posTerminalMg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._posTerminalMgTable.Remove(posTerminalMg.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // 完全削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._posTerminalMgAcs, 			// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
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

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = ((PosTerminalMg)this._posTerminalMgTable[guid]).Clone();

            // 復活処理
            status = this._posTerminalMgAcs.Revival(ref posTerminalMg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 端末管理設定情報クラスのデータセット展開処理
                        PosTerminalMgToDataSet(posTerminalMg, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._posTerminalMgAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
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
        // ADD 2009/06/05 ------<<<

        // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ---------->>>>>
        #region IPアドレス

        /// <summary>
        /// IPアドレス(1ブロック目)のValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tNedit_MachineIpAddr1_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr1, false);
        }

        /// <summary>
        /// IPアドレス(2ブロック目)のValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tNedit_MachineIpAddr2_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr2, false);
        }

        /// <summary>
        /// IPアドレス(3ブロック目)のValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tNedit_MachineIpAddr3_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr3, false);
        }

        /// <summary>
        /// IPアドレス(4ブロック目)のValueChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tNedit_MachineIpAddr4_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr4, false);
        }

        /// <summary>
        /// デフォルトIPアドレステキストを設定します。
        /// </summary>
        /// <param name="textBox">テキストボックス</param>
        /// <param name="emptyIsZero"><c>string.Empty</c>を<c>"0"</c>に設定するフラグ</param>
        private static void SetDefaultIPAddressText(
            TNedit textBox,
            bool emptyIsZero
        )
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                if (emptyIsZero) textBox.Text = "0";
                return;
            }

            int ipAddressValue = int.Parse(textBox.Text.Trim());
            if (ipAddressValue > 255)
            {
                textBox.Text = "255";
            }
            else if (ipAddressValue < 0)
            {
                textBox.Text = "0";
            }
        }

        /// <summary>
        /// IPv4アドレスであるか判定します。
        /// </summary>
        /// <param name="ipAddress">IPアドレス</param>
        /// <returns>
        /// <c>true</c> :IPv4アドレスです。<br/>
        /// <c>false</c>:IPv4アドレスではありません。
        /// </returns>
        private static bool IsIPv4Address(string ipAddress)
        {
            // TODO:たぶん、標準的な判定方法があると思います。
            string[] ipAddressTokens = ipAddress.Trim().Split('.');
            if (!ipAddressTokens.Length.Equals(4))
            {
                return false;
            }
            foreach (string ipAddressToken in ipAddressTokens)
            {
                int ipAddressNumber = 0;
                if (!int.TryParse(ipAddressToken, out ipAddressNumber))
                {
                    return false;
                }
            }
            return true;
        }

        # endregion // IPアドレス
        // ADD 2009/08/11 IPアドレスの入力制御の変更および追加 ----------<<<<<

        // ADD 2009/09/24 同端末名の登録を許可しない仕様とする ---------->>>>>
        #region 書込み前処理

        /// <summary>
        /// 書込む準備をします。
        /// </summary>
        /// <param name="writingRecord">書込む端末管理設定データ</param>
        /// <returns>
        /// <c>trur</c> :準備完了<br/>
        /// <c>false</c>:準備未完了
        /// <para>
        /// 同端末名が既に登録されている場合<br/>
        /// 管理者モード<br/>
        /// メッセージが表示され、<c>false</c>を返します。<br/>
        /// 一般ユーザーモード<br/>
        /// 該当データを完全削除し、処理が正常終了した場合、<c>true</c>を返します。
        /// </para>
        /// </returns>
        private bool GetReadyToWrite(PosTerminalMg writingRecord)
        {
            IList<PosTerminalMg> foundRecordList = FindAllByMachineName(writingRecord.MachineName);
            if (foundRecordList.Count.Equals(0)) return true;   // 同端末名なし
            if (
                foundRecordList.Count.Equals(1)
                    &&
                foundRecordList[0].CashRegisterNo.Equals(writingRecord.CashRegisterNo)
            ) return true;  // 書込む端末管理設定データ自身

            if (IsAdminMode())
            {
                // メッセージを出力
                string msg = string.Format(
                    "端末名：{0} は既にマスタに登録されています。\n該当データを完全削除の後、再度、登録してください。",
                    writingRecord.MachineName
                );
                MessageBox.Show(msg, PROGRAM_ID, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tEdit_MachineName.Focus();
                return false;
            }

            // 完全削除
            foreach (PosTerminalMg deletingRecord in foundRecordList)
            {
                // 書込む端末管理設定データ自身は無視
                if (deletingRecord.CashRegisterNo.Equals(writingRecord.CashRegisterNo)) continue;

                int status = this._posTerminalMgAcs.Delete(deletingRecord);
                if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    string msg = "同端末名データの完全削除に失敗しました。";
                    MessageBox.Show(msg, PROGRAM_ID, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 管理者モードであるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :管理者モードです。<br/>
        /// <c>false</c>:管理者モードではありません。
        /// </returns>
        private static bool IsAdminMode()
        {
            const int USER_ADMIN = 1;
            // 2010/07/01 >>>
            //return LoginInfoAcquisition.Employee.UserAdminFlag.Equals(USER_ADMIN);
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract && LoginInfoAcquisition.Employee.UserAdminFlag.Equals(USER_ADMIN))
                return true;
            return false;
            // 2010/07/01 <<<
        }

        /// <summary>
        /// 端末名で検索します。
        /// </summary>
        /// <param name="machineName">端末名</param>
        /// <returns>検索された端末管理設定データのリスト ※検索数が0件の場合、空のリストを返します。</returns>
        private IList<PosTerminalMg> FindAllByMachineName(string machineName)
        {
            List<PosTerminalMg> foundRecordList = null;
            {
                ArrayList searchedList = null;    // 1パラ目

                int status = this._posTerminalMgAcs.SearchServer(out searchedList, this._enterpriseCode);
                if (searchedList != null && searchedList.Count > 0)
                {
                    List<PosTerminalMg> searchedRecordList = new List<PosTerminalMg>(
                        (PosTerminalMg[])searchedList.ToArray(typeof(PosTerminalMg))
                    );
                    foundRecordList = searchedRecordList.FindAll(delegate(PosTerminalMg item)
                    {
                        return item.MachineName.Trim().Equals(machineName.Trim());
                    });
                }
            }
            return foundRecordList ?? new List<PosTerminalMg>();
        }

        #endregion // 書込み前処理
        // ADD 2009/09/24 同端末名の登録を許可しない仕様とする ----------<<<<<

        #endregion
    }
}
