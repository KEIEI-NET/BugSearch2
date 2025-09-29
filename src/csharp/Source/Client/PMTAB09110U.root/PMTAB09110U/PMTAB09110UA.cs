//**********************************************************************//
// システム         ：.NSシリーズ                                       //
// プログラム名称   ：PMTAB全体設定（得意先別）マスタ                   //
// プログラム概要   ：PMTAB全体設定（得意先別）の登録・修正・削除を行う //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 管理番号  10902622-01     作成担当：許培珠
// 修正日    2013/05/31　    修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号  10902622-01     作成担当：吉岡
// 修正日    2013/08/08　    修正内容：得意先デフォルト対応
// ---------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLP送信設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLP送信設定マスタを行います。</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PMTAB09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TEdit CustomerCdGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel CustomerCd_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private UltraButton CustomerCdGuide_ultraButton;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private UltraLabel ultraLabel15;
        private UltraLabel BlpSendDiv_Title_Lable;
        private TComboEditor BlpSendDiv_tComboEditor;
        private TNedit tNedit_CustomerCode;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// BLP送信設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PMTAB09110UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;

            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmTabTtlStCustAcs = new PmTabTtlStCustAcs();       // PMTAB全体設定（得意先）

            this._detailsTable = new Hashtable();
            this._allSearchHash = new Hashtable();

            this._detailsIndexBuf = -2;

            GetCacheData();
        }

        # endregion

        # region Dispose

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

        # endregion

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTAB09110UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCdGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.CustomerCdGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.BlpSendDiv_Title_Lable = new Infragistics.Win.Misc.UltraLabel();
            this.BlpSendDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCdGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlpSendDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 194);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(664, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(146, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(273, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(400, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(527, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // CustomerCd_Title_Label
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.CustomerCd_Title_Label.Appearance = appearance3;
            this.CustomerCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerCd_Title_Label.Location = new System.Drawing.Point(32, 47);
            this.CustomerCd_Title_Label.Name = "CustomerCd_Title_Label";
            this.CustomerCd_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.CustomerCd_Title_Label.TabIndex = 4;
            this.CustomerCd_Title_Label.Text = "得意先コード";
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(552, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "更新モード";
            // 
            // CustomerCdGuideNm_tEdit
            // 
            this.CustomerCdGuideNm_tEdit.AcceptsTab = true;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.CustomerCdGuideNm_tEdit.ActiveAppearance = appearance16;
            appearance1.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.CustomerCdGuideNm_tEdit.Appearance = appearance1;
            this.CustomerCdGuideNm_tEdit.AutoSelect = true;
            this.CustomerCdGuideNm_tEdit.DataText = "";
            this.CustomerCdGuideNm_tEdit.Enabled = false;
            this.CustomerCdGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCdGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCdGuideNm_tEdit.Location = new System.Drawing.Point(330, 47);
            this.CustomerCdGuideNm_tEdit.MaxLength = 6;
            this.CustomerCdGuideNm_tEdit.Name = "CustomerCdGuideNm_tEdit";
            this.CustomerCdGuideNm_tEdit.ReadOnly = true;
            this.CustomerCdGuideNm_tEdit.Size = new System.Drawing.Size(237, 24);
            this.CustomerCdGuideNm_tEdit.TabIndex = 2;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // CustomerCdGuide_ultraButton
            // 
            this.CustomerCdGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerCdGuide_ultraButton.Location = new System.Drawing.Point(299, 47);
            this.CustomerCdGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerCdGuide_ultraButton.Name = "CustomerCdGuide_ultraButton";
            this.CustomerCdGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.CustomerCdGuide_ultraButton.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "得意先ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerCdGuide_ultraButton, ultraToolTipInfo1);
            this.CustomerCdGuide_ultraButton.Click += new System.EventHandler(this.uButton_CustomerCodeGuid_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 134);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(664, 54);
            this.Button_Panel.TabIndex = 168;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(273, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 5;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(12, 81);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(640, 3);
            this.ultraLabel15.TabIndex = 169;
            // 
            // BlpSendDiv_Title_Lable
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.BlpSendDiv_Title_Lable.Appearance = appearance13;
            this.BlpSendDiv_Title_Lable.BackColorInternal = System.Drawing.Color.Transparent;
            this.BlpSendDiv_Title_Lable.Location = new System.Drawing.Point(31, 93);
            this.BlpSendDiv_Title_Lable.Name = "BlpSendDiv_Title_Lable";
            this.BlpSendDiv_Title_Lable.Size = new System.Drawing.Size(171, 24);
            this.BlpSendDiv_Title_Lable.TabIndex = 2385;
            this.BlpSendDiv_Title_Lable.Text = "ＢＬＰ伝票送信区分";
            // 
            // BlpSendDiv_tComboEditor
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BlpSendDiv_tComboEditor.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.BlpSendDiv_tComboEditor.Appearance = appearance45;
            this.BlpSendDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BlpSendDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BlpSendDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BlpSendDiv_tComboEditor.ItemAppearance = appearance79;
            this.BlpSendDiv_tComboEditor.Location = new System.Drawing.Point(208, 93);
            this.BlpSendDiv_tComboEditor.Name = "BlpSendDiv_tComboEditor";
            this.BlpSendDiv_tComboEditor.Size = new System.Drawing.Size(193, 24);
            this.BlpSendDiv_tComboEditor.TabIndex = 3;
            // 
            // tNedit_CustomerCode
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance18;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(208, 47);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 1;
            this.tNedit_CustomerCode.ValueChanged += new System.EventHandler(this.tNedit_CustomerCode_ValueChanged);
            // 
            // PMTAB09110UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(664, 217);
            this.Controls.Add(this.tNedit_CustomerCode);
            this.Controls.Add(this.BlpSendDiv_tComboEditor);
            this.Controls.Add(this.BlpSendDiv_Title_Lable);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.CustomerCdGuide_ultraButton);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CustomerCd_Title_Label);
            this.Controls.Add(this.CustomerCdGuideNm_tEdit);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTAB09110UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BLP伝票送信設定マスタ";
            this.Load += new System.EventHandler(this.PMTAB09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMTAB09110UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMTAB09110UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCdGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlpSendDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region IMasterMaintenanceMultiType メンバ

        # region ▼Properties
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
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
        # endregion ▼Properties

        # region ▼Public Methods

        /// <summary>GetAppearanceTable</summary>
        /// <value>AppearanceTableを取得または設定します。</value>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CUSTOMERCODENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BLPSENDDIVNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>GetBindDataSet</summary>
        /// <value>BindDataSetを取得または設定します。</value>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ▼Public Methods

        # region ▼Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion

        #region Private Menbers

        private PmTabTtlStCustAcs _pmTabTtlStCustAcs;     // BLP送信設定マスタ用アクセスクラス

        private string _enterpriseCode;         // 企業コード
        private Hashtable _detailsTable;        // BLP送信設定マスタ用ハッシュテーブル
        private Hashtable _allSearchHash;       // 全レコード確保用

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;

        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        private bool _modeFlg = false;

        private int _detailsIndexBuf;

        // 得意先ガイド用
        private UltraButton _customerGuideSender;

        // 得意先ガイド結果OKフラグ
        private bool _customerGuideOK;

        private CustomerInfoAcs _customerInfoAcs = null;　//得意先マスタ用
        // 得意先キャッシュ
        private Dictionary<string, CustomerInfo> _customerInfoDic;

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private PmTabTtlStCust _PmTabTtlStCustClone;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string CUSTOMERCODE_TITLE      = "得意先コード";
        private const string CUSTOMERCODENM_TITLE = "得意先名";
        private const string BLPSENDDIVNM_TITLE = "BLP送信区分";
        
        //印刷品番選択区分
        private const string BLPSENDDIVNM_VALUE0 = "送信しない";
        private const string BLPSENDDIVNM_VALUE1 = "送信する";

        // テーブル名称
        private const string DETAILS_TABLE = "PmTabTtlStCust";  // PMTAB全体設定マスタ（得意先別）

        // ガイドキー
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 146;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 273;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 400;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 527;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "PMTAB09110U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        // ADD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private const string CUSTOMER_DEFAULT_NAME = "デフォルト";
        private const string CUSTOMER_DEFAULT_CODE_DISP = "00000000";
        private const int CUSTOMER_DEFAULT_CODE = 0;
        /// <summary>
        /// 得意先コード入力欄で、デフォルトコードが入力されたか
        /// </summary>
        private bool isCustomerCodeDefaultInput = false;
        /// <summary>
        /// 表示されている得意先コードがデフォルトコードであるか
        /// </summary>
        private bool isCustomerCodeDefaultDisp = false;
        // ADD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTAB09110UA());
        }
        # endregion

        # region Properties

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        # endregion

        # region Public Methods

        /// <summary>
        /// 得意先検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // クリア
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();  
                this._detailsTable.Clear();  

                ArrayList retList = new ArrayList();
                status = this._pmTabTtlStCustAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PmTabTtlStCust pmTabTtlStCust in retList)
                        {
                            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(pmTabTtlStCust.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
				    default:
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"PMTAB09110U", 						// アセンブリＩＤまたはクラスＩＤ
                        // UPD 2013/08/07 Redmine#39735 --------------------------------------->>>>>
                        //"タブレット全体設定マスタ(得意先別)", 					    // プログラム名称
                        "BLP送信設定マスタ", 					    // プログラム名称
                        // UPD 2013/08/07 Redmine#39735 ---------------------------------------<<<<<
                        "Search", 					        // 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._pmTabTtlStCustAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
                }
            }
            catch (Exception)
            {
                // サーチ
                TMsgDisp.Show(
                    this,								  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                    this.Text,							  // プログラム名称
                    "Search",							  // 処理名称
                    TMsgDisp.OPE_GET,					  // オペレーション
                    ERR_READ_MSG,						  // 表示するメッセージ 
                    status,								  // ステータス値
                    this._pmTabTtlStCustAcs,				      // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,				  // 表示するボタン
                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
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
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            status = LogicalDeleteSubsection();  

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// BLP送信設定マスタオブジェクトデータセット展開処理
        /// </summary>
        /// <param name="pmTabTtlStCust">BLP送信設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : BLP送信設定マスタクラスをデータセットに格納します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DetailsToDataSet(PmTabTtlStCust pmTabTtlStCust, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (pmTabTtlStCust.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pmTabTtlStCust.UpdateDateTimeJpInFormal;
            }

            // 得意先コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = pmTabTtlStCust.CustomerCode.PadLeft(8,'0');

            // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //string custNm = this.GetCustomNm(pmTabTtlStCust.CustomerCode);
            //if (custNm == "")
            //{
            //    custNm = "未登録";
            //}
            //// 得意先名称
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODENM_TITLE] = custNm;
            #endregion
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODENM_TITLE] = GetCustomerNameForDefault(pmTabTtlStCust.CustomerCode);
            // UPD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 印刷品番選択区分
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][BLPSENDDIVNM_TITLE] = this.GetBlpSendDivNm(pmTabTtlStCust.BlpSendDiv);

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = pmTabTtlStCust.FileHeaderGuid;

            // ハッシュテーブル更新
            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStCust.FileHeaderGuid);
            }
            this._detailsTable.Add(pmTabTtlStCust.FileHeaderGuid, pmTabTtlStCust);
        }

        /// <summary>
        /// BLP送信設定マスタオブジェクトデータセット削除処理
        /// </summary>
        /// <param name="pmTabTtlStCust">BLP送信設定マスタオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        private void DeleteFromDataSet(PmTabTtlStCust pmTabTtlStCust, int index)
        {
            // データセットから行削除します
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // ハッシュテーブルから削除します
            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStCust.FileHeaderGuid);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // PMTAB全体設定マスタ

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODENM_TITLE, typeof(string));
            detailsTable.Columns.Add(BLPSENDDIVNM_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible  = true;  // 完全削除ボタン
            this.Revive_Button.Visible  = true;  // 復活ボタン
            this.Ok_Button.Visible      = true;  // 保存ボタン
            this.Cancel_Button.Visible = true;  // 閉じるボタン
            this.Renewal_Button.Visible = true;  // 最新情報ボタン
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置

            // 得意先部
            this.tNedit_CustomerCode.Clear();
            this.CustomerCdGuideNm_tEdit.Text = "";
            this.tNedit_CustomerCode.Enabled = true;
            this.CustomerCdGuideNm_tEdit.Enabled = false;
            this.CustomerCdGuide_ultraButton.Enabled = true;

            //印刷品番選択区分
            this.BlpSendDiv_tComboEditor.Items.Clear();
            this.BlpSendDiv_tComboEditor.Items.Add(0,BLPSENDDIVNM_VALUE0);
            this.BlpSendDiv_tComboEditor.Items.Add(1,BLPSENDDIVNM_VALUE1);
            this.BlpSendDiv_tComboEditor.Enabled = true;


        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 新規の場合
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(1);                        // 画面入力許可制御
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(2);                        // 画面入力許可制御
            }
            // 更新の場合
            else
            {
                ScreenInputPermissionControl(3);                        // 画面入力許可制御
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 1:新規
                case 1:
                    this.tNedit_CustomerCode.Enabled = true;
                    this.CustomerCdGuide_ultraButton.Enabled = true;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = true;

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    break;
                // 2:更新
                case 3:
                    // 表示項目
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.CustomerCdGuide_ultraButton.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = true;

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    break;
                // 3:削除
                case 2:
                    // 表示項目
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.CustomerCdGuide_ultraButton.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = false;

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                SubsectionToScreen(pmTabTtlStCust);

                // クローン作成
                this._PmTabTtlStCustClone = pmTabTtlStCust.Clone();
                DispToSubsection(ref this._PmTabTtlStCustClone);

            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = (PmTabTtlStCust)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(pmTabTtlStCust);
            }
            // 更新の場合
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = (PmTabTtlStCust)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(pmTabTtlStCust);

                // クローン作成
                this._PmTabTtlStCustClone = pmTabTtlStCust.Clone();
                DispToSubsection(ref this._PmTabTtlStCustClone);

            }

            this._detailsIndexBuf = this._dataIndex; 

        }

        /// <summary>
        /// PMT全体設定クラス画面展開処理
        /// </summary>
        /// <param name="pmTabTtlStCust">PMT全体設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SubsectionToScreen(PmTabTtlStCust pmTabTtlStCust)
        {
            // 得意先コード
            this.tNedit_CustomerCode.DataText = pmTabTtlStCust.CustomerCode.Trim();

            if (this.tNedit_CustomerCode.DataText == "")
            {
                // 得意先名称
                this.CustomerCdGuideNm_tEdit.DataText = "";
            }
            else
            {
                // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //string custNm = this.GetCustomNm(pmTabTtlStCust.CustomerCode.Trim());
                //if (custNm == "")
                //{
                //    custNm = "未登録";
                //}
                #endregion
                // 得意先名称
                this.CustomerCdGuideNm_tEdit.DataText = GetCustomerNameForDefault(pmTabTtlStCust.CustomerCode);
                // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            }
           
            // 印刷品番選択区分
            this.BlpSendDiv_tComboEditor.SelectedIndex = pmTabTtlStCust.BlpSendDiv;

        }

        // ADD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 得意先名称取得　デフォルト対応
        /// </summary>
        /// <param name="code">得意先コード</param>
        /// <returns></returns>
        private string GetCustomerNameForDefault(string code)
        {
            string custNm = string.Empty;
            int customercode;
            if (int.TryParse(code.Trim(), out customercode))
            {
                if (customercode.Equals(CUSTOMER_DEFAULT_CODE))
                {
                    custNm = CUSTOMER_DEFAULT_NAME;
                }
                else
                {
                    custNm = this.GetCustomNm(code.Trim());
                }
            }
            if (custNm == "")
            {
                custNm = "未登録";
            }
         
            return custNm;
        }
        // ADD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 画面情報全体設定クラス格納処理
        /// </summary>
        /// <param name="pmTabTtlStCust">PMTAB全体設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から全体設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DispToSubsection(ref PmTabTtlStCust pmTabTtlStCust)
        {
            // 企業コード
            pmTabTtlStCust.EnterpriseCode = this._enterpriseCode;

            // 新規モードのみ、得意先を更新必要
            if (this._dataIndex < 0)
            {
                // 得意先コード
                pmTabTtlStCust.CustomerCode = this.tNedit_CustomerCode.DataText;
            }
            
            // 印刷品番選択区分
            pmTabTtlStCust.BlpSendDiv = this.BlpSendDiv_tComboEditor.SelectedIndex;

        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // 得意先コード
            if (this.tNedit_CustomerCode.DataText.Trim() == "")
            {
                control = this.tNedit_CustomerCode;
                message = this.CustomerCd_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 画面入力情報存在チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報存在チェックを行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool DateExistCheck(ref Control control, ref string message)
        {
            bool result = true;

            if (this.GetCustomNm(this.tNedit_CustomerCode.DataText.ToString()) == "")
            {
                control = this.tNedit_CustomerCode;
                message = "得意先コードが存在しません。";
                this.tNedit_CustomerCode.Clear();
                this.CustomerCdGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }


        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 得意先・PMTAB全体設定マスタの保存処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            if(this._dataIndex <0 )
            {
                if(ModeChangeProc())
                {
                    this.tNedit_CustomerCode.Focus();
                    return false;
                }
            }

            // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //if (!DateExistCheck(ref control, ref message))
            //{
            //    TMsgDisp.Show(
            //        this, 								// 親ウィンドウフォーム
            //        emErrorLevel.ERR_LEVEL_INFO, 　　 　// エラーレベル
            //        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
            //        message, 							// 表示するメッセージ
            //        0, 									// ステータス値
            //        MessageBoxButtons.OK);				// 表示するボタン

            //    control.Focus();
            //    return false;
            //}
            #endregion
            // デフォルトでは無い場合に存在チェック
            if (!CustomerCdGuideNm_tEdit.Text.Trim().Equals(CUSTOMER_DEFAULT_NAME))
            {
                if (!DateExistCheck(ref control, ref message))
                {
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 　　 　// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    control.Focus();
                    return false;
                }
            }
            // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>

            // PMTAB全体設定マスタ更新
            if (!SaveSubsection())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// BLP送信設定マスタテーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : Subsectionテーブルの更新を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            // 登録レコード情報取得
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();
            }

            // SecInfoSetクラスにデータを格納
            DispToSubsection(ref pmTabTtlStCust);

            // SecInfoSetクラスをアクセスクラスに渡して登録・更新
            int status = this._pmTabTtlStCustAcs.Write(ref pmTabTtlStCust);

            // エラー処理
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash更新処理
                    DetailsToDataSet(pmTabTtlStCust, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStCustAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();
                    return false;
                default:
                    // 登録失敗
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "SaveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_UPDT_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStCustAcs,				    // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return false;
            }

            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// BLP送信設定マスタ 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP送信設定マスタの対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // 削除対象PMTAB全体設定マスタ取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            status = this._pmTabTtlStCustAcs.LogicalDelete(ref pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pmTabTtlStCustAcs);
                    // フレーム更新
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "LogicalDeleteSubsection",	        // 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStCustAcs,			        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // フレーム更新
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// BLP送信設定マスタ 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP送信設定マスタの対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // 削除対象BLP送信設定マスタ取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            // 物理削除
            status = this._pmTabTtlStCustAcs.Delete(pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DeleteFromDataSet(pmTabTtlStCust, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pmTabTtlStCustAcs);
                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "PhysicalDeleteSubsection",		    // 処理名称
                        TMsgDisp.OPE_HIDE,					// オペレーション
                        ERR_RDEL_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStCustAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // UI子画面強制終了処理
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// 得意先 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全体設定得意先別の対象レコードを復活します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // 復活対象BLP送信設定マスタ取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            // 復活
            status = this._pmTabTtlStCustAcs.Revival(ref pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet展開処理
                    DetailsToDataSet(pmTabTtlStCust, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStCustAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ReviveSubsection",				    // 処理名称
                        TMsgDisp.OPE_UPDATE,				// オペレーション
                        ERR_RVV_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        this._pmTabTtlStCustAcs,					// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                // 画面クリア処理
                ScreenClear();
                // 画面初期設定処理
                ScreenInitialSetting();
                // 画面再構築処理
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI子画面強制終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="control">対象コントロール</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン

            control = this.tNedit_CustomerCode;

        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_800_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        this.Text,							// プログラム名称
                        "ExclusiveTransaction",				// 処理名称
                        operation,							// オペレーション
                        ERR_801_MSG,						// 表示するメッセージ 
                        status,								// ステータス値
                        erObject,							// エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                    break;
            }
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SetControlSize()
        {
            //印刷品番選択区分
            this.BlpSendDiv_tComboEditor.Items.Clear();
            this.BlpSendDiv_tComboEditor.Items.Add(0,BLPSENDDIVNM_VALUE0);
            this.BlpSendDiv_tComboEditor.Items.Add(1, BLPSENDDIVNM_VALUE1);
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(MAKHN09230U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // ガイドボタンのアイコン設定
            this.CustomerCdGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // コントロールサイズ設定
            SetControlSize();

            // ADD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // デザイナで設定された内容(0表示する)が有効にならないので、ここで再設定
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            // ADD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// Form.Closing イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;

            // フォームの「×」をクリックされた場合の対応です。
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if ( this.Visible == false ) {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            // 画面初期設定処理
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録処理
            SaveProc();
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE ) {

                // 現在の画面情報を取得
                PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();
                pmTabTtlStCust = this._PmTabTtlStCustClone.Clone();
                DispToSubsection(ref pmTabTtlStCust);
                // 最初に取得した画面情報と比較
                cloneFlg = this._PmTabTtlStCustClone.Equals(pmTabTtlStCust);

                if ( !( cloneFlg ) ) {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    DialogResult res = TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        "",									// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.YesNoCancel);		// 表示するボタン

                    switch ( res ) {
                        case DialogResult.Yes:
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            if (_modeFlg)
                            {
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            return;
                    }
                }
            }

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if ( result == DialogResult.OK ) {

                // BLP送信設定マスタ物理削除
                PhysicalDeleteSubsection();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSubsection();  
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// 得意先ガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeGuid_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.BlpSendDiv_tComboEditor.Focus();
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                }
            }

        }

        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;

            _customerGuideOK = true;
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 許培珠</br>
        /// <br>Date		: 2013/05/31</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;
        
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":

                    if (this.tNedit_CustomerCode.DataText.Trim() == "")
                    {
                        this.CustomerCdGuideNm_tEdit.DataText = "";
                    }
                    else
                    {
                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();
                        // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        ////　得意先名称の取得
                        //CustomerInfo customerInfo;
                        //if (this._customerInfoAcs == null)
                        //{
                        //    this._customerInfoAcs = new CustomerInfoAcs();
                        //}
                        //int status = this._customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out customerInfo);

                        //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //{
                        //    this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;
                        //}
                        //else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //{
                        //    TMsgDisp.Show(
                        //        this,
                        //        emErrorLevel.ERR_LEVEL_INFO,
                        //        this.Name,
                        //        "得意先コードが存在しません。",
                        //        status,
                        //        MessageBoxButtons.OK);

                        //    this.tNedit_CustomerCode.Clear();
                        //    this.CustomerCdGuideNm_tEdit.Clear();

                        //    e.NextCtrl = e.PrevCtrl;

                        //    break;
                        //}
                        //else
                        //{
                        //    TMsgDisp.Show(this,
                        //                  emErrorLevel.ERR_LEVEL_STOPDISP,
                        //                  this.Name,
                        //                  "得意先情報の取得に失敗しました。",
                        //                  status,
                        //                  MessageBoxButtons.OK);

                        //    this.tNedit_CustomerCode.Clear();
                        //    this.CustomerCdGuideNm_tEdit.Clear();

                        //    e.NextCtrl = e.PrevCtrl;

                        //    break;
                        //}
                        #endregion

                        if (customerCode.Equals(CUSTOMER_DEFAULT_CODE))
                        {
                            this.CustomerCdGuideNm_tEdit.DataText = CUSTOMER_DEFAULT_NAME;
                            isCustomerCodeDefaultInput = true;
                        }
                        else
                        {
                            //　得意先名称の取得
                            CustomerInfo customerInfo;
                            if (this._customerInfoAcs == null)
                            {
                                this._customerInfoAcs = new CustomerInfoAcs();
                            }
                            int status = this._customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out customerInfo);

                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "得意先コードが存在しません。",
                                    status,
                                    MessageBoxButtons.OK);

                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;

                                break;
                            }
                            else
                            {
                                TMsgDisp.Show(this,
                                              emErrorLevel.ERR_LEVEL_STOPDISP,
                                              this.Name,
                                              "得意先情報の取得に失敗しました。",
                                              status,
                                              MessageBoxButtons.OK);

                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;

                                break;
                            }
                        }
                        // UPD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }

                    // 得意先コードにフォーカスがある場合
                    if (e.Key == Keys.Right)
                    {
                        if (this.tNedit_CustomerCode.DataText.Trim() == "")
                        {
                            e.NextCtrl = this.CustomerCdGuide_ultraButton;
                        }
                        else 
                        {
                            e.NextCtrl = this.BlpSendDiv_tComboEditor;
                        }
                    }
                    // モード変更処理
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                    break;
                case "BlpSendDiv_tComboEditor":
                    if(e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode;
                    }
                    break;
                case "Ok_Button":
                    // 保存ボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 得意先ガイドボタンにフォーカスを移します
                        e.NextCtrl = this.BlpSendDiv_tComboEditor;
                    }
                    break;
                default:
                    break;
            }


            // ADD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            switch (e.NextCtrl .Name)
            {
                case "tNedit_CustomerCode":
                    if (tNedit_CustomerCode.GetInt().Equals(CUSTOMER_DEFAULT_CODE) && !tNedit_CustomerCode.Text.Equals(string.Empty))
                    {
                        isCustomerCodeDefaultDisp = true;
                    }
                    break;
            }
            // ADD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._pmTabTtlStCustAcs = new PmTabTtlStCustAcs();

            this.GetCacheData();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 得意先コード
            string customerCode = this.tNedit_CustomerCode.Text.PadLeft(8,'0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dbCustCd = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][CUSTOMERCODE_TITLE];

                if (customerCode.Equals(dbCustCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのBLP送信設定マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // PMTAB全体設定マスタコードのクリア
                        this.tNedit_CustomerCode.Clear();
                        this.CustomerCdGuideNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのBLP送信設定マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 得意先コードのクリア
                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                } 
            }
            return false;
        }

        /// <summary>
        /// ＢＬＰ送信区分名称を取得します。
        /// </summary>
        /// <param name="blpSendDiv">ＢＬＰ送信区分</param>
        /// <returns>ＢＬＰ送信区分名称</returns>
        /// <remarks>
        /// <br>Note       : ＢＬＰ送信区分からＢＬＰ送信区分名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetBlpSendDivNm(int blpSendDiv)
        {
            string str = string.Empty;

            switch (blpSendDiv)
            {
                case 0:
                    str = BLPSENDDIVNM_VALUE0;
                    break;
                case 1:
                    str = BLPSENDDIVNM_VALUE1;
                    break;
                default:
                    break;
            }
            return str;
        }
               
        /// <summary>
        /// 得意先名称を取得
        /// </summary>
        /// <param name="customercode"></param>
        /// <returns></returns>
        private string GetCustomNm(string customercode)
        {
            //　得意先名称の取得
            string customerNm = "";
            CustomerInfo customerinfo = null;
            try
            {
                if (_customerInfoDic.ContainsKey(customercode.PadLeft(8,'0')))
                {
                    customerinfo = _customerInfoDic[customercode.PadLeft(8,'0')];
                    customerNm = customerinfo.CustomerSnm.Trim();
                    return customerNm;
                }
                else 
                {
                    return customerNm;
                }
            }
            catch
            {
                return customerNm;
            }

        }

        /// <summary>
        /// 得意先マスタのローカルキャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタのローカルキャッシュを作成します。</br>
        /// <br></br>
        /// </remarks>
        private void GetCacheData()
        {
            int status;
            List<CustomerInfo> retList = new List<CustomerInfo>();
            // 得意先マスタのローカルキャッシュをクリア
            _customerInfoDic = new Dictionary<string, CustomerInfo>();

            bool cacheFlag = true;
            bool issetting = true;

            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            // 得意先マスタの取得
            status = customerInfoAcs.Search(LoginInfoAcquisition.EnterpriseCode, cacheFlag, issetting, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (CustomerInfo wkCustomerInfo in retList)
                {
                    if (wkCustomerInfo.LogicalDeleteCode == 0)
                    {
                        string key = wkCustomerInfo.CustomerCode.ToString().PadLeft(8,'0');
                        if (_customerInfoDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            _customerInfoDic.Remove(key);
                        }
                        _customerInfoDic.Add(key, wkCustomerInfo);
                    }
                }
            }
        }

        /// <summary>
        /// 得意先コードtNedit_CustomerCode_ValueChanged処理、数字以外入力できない
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先コードtNedit_CustomerCode_ValueChanged処理、数字以外入力できない</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_CustomerCode_ValueChanged(object sender, EventArgs e)
        {
            // UPD 吉岡 2013/08/08 得意先デフォルト対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region コントロールのプロパティ(ExtEdit)で数字以外入力できないよう制御しているので不要
            //Regex x = new Regex("^[0-9]*$");
            //if (!(x.IsMatch(this.tNedit_CustomerCode.Text)))
            //{
            //    this.tNedit_CustomerCode.Clear();
            //    this.tNedit_CustomerCode.Focus();
            //}
            #endregion
            
            // NumEditプロパティで"0表示する"にしているが、0を入力した場合、
            // 最終的にクリアされ空文字が設定されてしまうので、以下で設定する
            if (isCustomerCodeDefaultInput && tNedit_CustomerCode.Text.Equals(string.Empty))
            {
                tNedit_CustomerCode.Text = CUSTOMER_DEFAULT_CODE_DISP;
                isCustomerCodeDefaultInput = false;
            }

            // 得意先コードに"00000000"が設定されている場合、フォーカス取得時に、全てクリアされて空文字になってしまうので、
            // 以下で"0"を設定する
            if (isCustomerCodeDefaultDisp)
            {
                tNedit_CustomerCode.Text = CUSTOMER_DEFAULT_CODE.ToString();
                isCustomerCodeDefaultDisp = false;
            }
            // UPD 吉岡 2013/08/08 得意先デフォルト対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        # endregion
    }
}
