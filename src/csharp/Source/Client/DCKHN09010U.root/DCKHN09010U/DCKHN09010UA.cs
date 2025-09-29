using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
//using Broadleaf.Application.Remoting.ParamData;  // DEL 2008/06/04

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 部門設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部門設定を行います。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.08.09</br>
    /// <br>Update Note: 2008/06/04 30414 忍　幸史</br>
    /// <br>                        拠点テーブル削除</br>
    /// <br>Update Note: 2008/09/16 30452 上野　俊治</br>
    /// <br>                        拠点名称をアクセスクラス経由で取得するよう修正</br>
    /// </remarks>
    public class DCKHN09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Broadleaf.Library.Windows.Forms.TEdit SectionGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private TEdit SubSectionName_tEdit;
        private UltraLabel SubsectionName_Title_Label;
        private UltraLabel SubsectionCode_Title_Label;
        private TNedit tNedit_SubSectionCode;
        private UltraButton SectionGuide_ultraButton;
        private TEdit tEdit_SectionCode;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// 部門設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public DCKHN09010UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainGridTitle = "拠点情報";
            this._detailsGridTitle          = "部門";
            this._defaultGridDisplayLayout  = MGridDisplayLayout.Vertical;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._targetTableName = "";
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //this._secInfoAcs = new SecInfoAcs(1);         // 拠点(リモート読込)
            // --- DEL 2008/09/16 --------------------------------<<<<< 
            this._subsectionAcs = new SubSectionAcs();       // 部門

            //this._mainTable = new Hashtable();  // DEL 2008/06/04
            this._detailsTable = new Hashtable();
            this._allSearchHash = new Hashtable();

            //GridIndexバッファ（メインフレーム最小化対応）
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // アイコン用ダミー
            this._mainGridIcon = null;
            this._detailsGridIcon = null;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09010UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SubsectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubsectionName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubSectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubSectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 183);
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
            this.Delete_Button.TabIndex = 8;
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
            this.Revive_Button.TabIndex = 9;
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
            this.Ok_Button.TabIndex = 10;
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
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance13;
            this.SectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(12, 85);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SectionCode_Title_Label.TabIndex = 4;
            this.SectionCode_Title_Label.Text = "拠点";
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(559, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "更新モード";
            // 
            // SectionGuideNm_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.Appearance = appearance10;
            this.SectionGuideNm_tEdit.AutoSelect = true;
            this.SectionGuideNm_tEdit.DataText = "";
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionGuideNm_tEdit.Location = new System.Drawing.Point(190, 85);
            this.SectionGuideNm_tEdit.MaxLength = 6;
            this.SectionGuideNm_tEdit.Name = "SectionGuideNm_tEdit";
            this.SectionGuideNm_tEdit.ReadOnly = true;
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.SectionGuideNm_tEdit.TabIndex = 6;
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
            // SectionGuide_ultraButton
            // 
            this.SectionGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGuide_ultraButton.Location = new System.Drawing.Point(312, 85);
            this.SectionGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGuide_ultraButton.Name = "SectionGuide_ultraButton";
            this.SectionGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_ultraButton.TabIndex = 7;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_ultraButton, ultraToolTipInfo1);
            this.SectionGuide_ultraButton.Click += new System.EventHandler(this.SectionGuide_ultraButton_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 129);
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
            this.Renewal_Button.TabIndex = 9;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SubsectionCode_Title_Label
            // 
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.SubsectionCode_Title_Label.Appearance = appearance8;
            this.SubsectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubsectionCode_Title_Label.Location = new System.Drawing.Point(12, 25);
            this.SubsectionCode_Title_Label.Name = "SubsectionCode_Title_Label";
            this.SubsectionCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SubsectionCode_Title_Label.TabIndex = 0;
            this.SubsectionCode_Title_Label.Text = "部門コード";
            // 
            // SubsectionName_Title_Label
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.SubsectionName_Title_Label.Appearance = appearance7;
            this.SubsectionName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubsectionName_Title_Label.Location = new System.Drawing.Point(12, 55);
            this.SubsectionName_Title_Label.Name = "SubsectionName_Title_Label";
            this.SubsectionName_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SubsectionName_Title_Label.TabIndex = 2;
            this.SubsectionName_Title_Label.Text = "部門名";
            // 
            // SubSectionName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SubSectionName_tEdit.ActiveAppearance = appearance12;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubSectionName_tEdit.Appearance = appearance14;
            this.SubSectionName_tEdit.AutoSelect = true;
            this.SubSectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubSectionName_tEdit.DataText = "";
            this.SubSectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SubSectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SubSectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SubSectionName_tEdit.Location = new System.Drawing.Point(148, 55);
            this.SubSectionName_tEdit.MaxLength = 20;
            this.SubSectionName_tEdit.Name = "SubSectionName_tEdit";
            this.SubSectionName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SubSectionName_tEdit.TabIndex = 3;
            // 
            // tNedit_SubSectionCode
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.Appearance = appearance2;
            this.tNedit_SubSectionCode.AutoSelect = true;
            this.tNedit_SubSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SubSectionCode.DataText = "";
            this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(148, 25);
            this.tNedit_SubSectionCode.MaxLength = 2;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_SubSectionCode.TabIndex = 1;
            // 
            // tEdit_SectionCode
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance6;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(148, 85);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 5;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCKHN09010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(664, 206);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.SectionGuide_ultraButton);
            this.Controls.Add(this.tNedit_SubSectionCode);
            this.Controls.Add(this.SubSectionName_tEdit);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.SubsectionName_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SubsectionCode_Title_Label);
            this.Controls.Add(this.SectionGuideNm_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部門設定";
            this.Load += new System.EventHandler(this.MAKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubSectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
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
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUBSECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SUBSECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

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
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        #region Private Menbers

        // --- DEL 2008/09/16 -------------------------------->>>>>
        // private SecInfoAcs   _secInfoAcs;       // 拠点用アクセスクラス
        // --- DEL 2008/09/16 --------------------------------<<<<< 
        private SubSectionAcs _subsectionAcs;     // 部門用アクセスクラス

        private string _enterpriseCode;         // 企業コード
        //private Hashtable _mainTable;           // 拠点用ハッシュテーブル  // DEL 2008/06/04
        private Hashtable _detailsTable;        // 部門用ハッシュテーブル
        private Hashtable _allSearchHash;       // 全レコード確保用

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private string _mainGridTitle;
        private string _detailsGridTitle;
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private MGridDisplayLayout _defaultGridDisplayLayout;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            
        //_GridIndexバッファ（メインフレーム最小化対応）
        //private int _mainIndexBuf;  // DEL 2008/06/04
        private int _detailsIndexBuf;
        //private string _targetTableBuf;  // DEL 2008/06/04

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private SubSection _SubsectionClone;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string SECTIONCODE_TITLE      = "拠点コード";
        private const string SECTIONGUIDENM_TITLE   = "拠点名";
        private const string SUBSECTIONCODE_TITLE   = "部門コード";
        private const string SUBSECTIONNAME_TITLE   = "部門名";

        // テーブル名称
        //private const string MAIN_TABLE     = "SecInfoSet"; // 拠点  // DEL 2008/06/04
        private const string DETAILS_TABLE  = "SubSection";  // 部門

        // ガイドキー
        //private const string MAIN_GUID_KEY = "MainGuid";  // DEL 2008/06/04
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 146;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 273;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 400;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 527;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 8;        // ボタン位置Y(共通)

        // Message関連定義
        //private const string ASSEMBLY_ID = "MAKHN09330U";
        private const string ASSEMBLY_ID = "DCKHN09010U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCKHN09010UA());
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

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Public Methods

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { false, true };
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _detailsGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { _mainGridIcon, _detailsGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 拠点検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // クリア
                //this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();  // DEL 2008/06/04
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();  // ADD 2008/06/04
                //this._mainTable.Clear();  // DEL 2008/06/04
                this._detailsTable.Clear();  // ADD 2008/06/04

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (this._secInfoAcs.SecInfoSetList.Length > 0)
                {
                    
                    // 取得した拠点情報クラスをデータセットへ展開する
                    int index = 0;
                    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                    {
                        // 拠点情報クラスデータセット展開処理
                        MainToDataSet(secInfoSet.Clone(), index);
                        ++index;
                    }

                    totalCount = this._secInfoAcs.SecInfoSetList.Length;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                ArrayList retList = new ArrayList();
                status = this._subsectionAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (SubSection subSection in retList)
                        {
                            if (this._detailsTable.ContainsKey(subSection.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(subSection.Clone(), index);
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
						"DCKHN09010U", 						// アセンブリＩＤまたはクラスＩＤ
						"部門設定", 					    // プログラム名称
                        "Search", 					        // 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._subsectionAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
                }
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
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
                    // --- DEL 2008/09/16 -------------------------------->>>>>
                    //this._secInfoAcs,				      // エラーが発生したオブジェクト
                    // --- DEL 2008/09/16 --------------------------------<<<<<
                    // --- ADD 2008/09/16 -------------------------------->>>>>
                    this._subsectionAcs,				      // エラーが発生したオブジェクト
                    // --- ADD 2008/09/16 --------------------------------<<<<<
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 部門検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList SubsectionList = null;

            // 選択されている拠点コードを取得する
            string sectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];

            // 部門取得
            status = this._subsectionAcs.SearchAll(out SubsectionList, this._enterpriseCode, sectionCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();

                        int index = 0;
                        foreach ( SubSection subsection in SubsectionList )
                        {
                            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == false )
                            {
                                DetailsToDataSet(subsection.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = SubsectionList.Count;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // データなしの場合はグリッドをクリア
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "DetailsDataSearch", 				// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            ERR_READ_MSG,						// 表示するメッセージ 
                            status, 							// ステータス値
                            this._subsectionAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // 未実装
            return 9;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    // 部門論理削除処理
                    status = LogicalDeleteSubsection();
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            status = LogicalDeleteSubsection();  // ADD 2008/06/04

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // 拠点Grid
            Hashtable main = new Hashtable();
            main.Add(SECTIONCODE_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(SECTIONGUIDENM_TITLE,  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(MAIN_GUID_KEY,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            // 部門Grid
            Hashtable details = new Hashtable();
            details.Add(DELETE_DATE_TITLE,      new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            details.Add(SECTIONCODE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(SUBSECTIONCODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "",   Color.Black));
            details.Add(SUBSECTIONNAME_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(DETAILS_GUID_KEY,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            _hashtable = new Hashtable[2];
            _hashtable[0] = main;
            _hashtable[1] = details;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Private Methods

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="secInfoSet">拠点設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONCODE_TITLE] = secInfoSet.SectionCode;
            // 拠点名称
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = secInfoSet.SectionGuideNm;
            // GUID
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][MAIN_GUID_KEY] = secInfoSet.FileHeaderGuid;


            // ハッシュテーブル更新
            if (this._mainTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
            {
                this._mainTable.Remove(secInfoSet.FileHeaderGuid);
            }
            this._mainTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 部門設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="subsection">部門設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 部門設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DetailsToDataSet ( SubSection subsection, int index )
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
            if ( subsection.LogicalDeleteCode == 0 )
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = subsection.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = subsection.SectionCode;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(subsection.SectionCode);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // 部門コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString("00");
            // 部門名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SUBSECTIONNAME_TITLE] = subsection.SubSectionName;

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = subsection.FileHeaderGuid;

            // ハッシュテーブル更新
            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == true )
            {
                this._detailsTable.Remove(subsection.FileHeaderGuid);
            }
            this._detailsTable.Add(subsection.FileHeaderGuid, subsection);
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            /* --- DEL 2008/09/16 -------------------------------->>>>>
            string sectionName = "未登録";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
            --- DEL 2008/09/16 -------------------------------->>>>> */
            // --- ADD 2008/09/16 -------------------------------->>>>>
            return this._subsectionAcs.GetSectionName(sectionCode);
            // --- ADD 2008/09/16 --------------------------------<<<<<
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 部門設定オブジェクトデータセット削除処理
        /// </summary>
        /// <param name="subsection">部門設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        private void DeleteFromDataSet ( SubSection subsection, int index )
        {
            // データセットから行削除します
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // ハッシュテーブルから削除します
            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == true ) {
                this._detailsTable.Remove(subsection.FileHeaderGuid);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //DataTable mainTable     = new DataTable(MAIN_TABLE);    // 拠点  // DEL 2008/06/04
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // 部門

            // Addを行う順番が、列の表示順位となります。
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            mainTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            mainTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            mainTable.Columns.Add(MAIN_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(mainTable);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(SUBSECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SUBSECTIONNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));

            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
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
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.Visible = true;  // 最新情報ボタン
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置

            // 拠点部
            this.tEdit_SectionCode.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            this.tEdit_SectionCode.Enabled = true;
            this.SectionGuideNm_tEdit.Enabled = false;

            // 部門部
            this.tNedit_SubSectionCode.Clear();
            this.SubSectionName_tEdit.Clear();
            this.tNedit_SubSectionCode.Enabled = true;
            this.SubSectionName_tEdit.Enabled = true;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI画面表示時のチラつきを抑える為に、ここでサイズ等変更
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    // 新規の場合
                    if (this._detailsDataIndex < 0) {
                        ScreenInputPermissionControl(3);                        // 画面入力許可制御
                    }
                    // 削除の場合
                    else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "") {
                        ScreenInputPermissionControl(5);                        // 画面入力許可制御
                    }
                    // 更新の場合
                    else {
                        ScreenInputPermissionControl(4);                        // 画面入力許可制御
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 新規の場合
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(3);                        // 画面入力許可制御
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(5);                        // 画面入力許可制御
            }
            // 更新の場合
            else
            {
                ScreenInputPermissionControl(4);                        // 画面入力許可制御
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 0:拠点-新規
                case 0:
                    break;
                // 1:拠点-更新
                case 1:
                    break;
                // 2:拠点-削除
                case 2:
                    break;
                // 3:部門-新規
                case 3:
                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // ボタン
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<

                    break;
                // 4:部門-更新
                case 4:
                    // 表示項目
                    this.tNedit_SubSectionCode.Enabled = false;

                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // ボタン
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<

                    break;
                // 5:部門-削除
                case 5:
                    // 表示項目
                    this.tNedit_SubSectionCode.Enabled = false;
                    this.SubSectionName_tEdit.Enabled = false;

                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // ボタン
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 拠点が論理削除の場合は復活禁止
                    Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][MAIN_GUID_KEY];
                    SecInfoSet pustSecInfoSet = (SecInfoSet)this._mainTable[guid];
                    if (pustSecInfoSet.LogicalDeleteCode != 0) {
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                        this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
                    }
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                    break;
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    SubSection subsection = new SubSection();

                    // 新規の場合
                    if (this._detailsDataIndex < 0) {
                        // 画面展開処理
                        SubsectionToScreen(subsection);

                        // クローン作成
                        this._SubsectionClone = subsection.Clone();
                        DispToSubsection(ref this._SubsectionClone);

                        // フォーカス設定
                        this.SubSectionCode_tNedit.Focus();
                    }
                    // 削除の場合
                    else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "") {
                        // 削除モード
                        this.Mode_Label.Text = DELETE_MODE;

                        // 表示情報取得
                        Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                        subsection = ( SubSection ) this._detailsTable[guid];

                        // 画面展開処理
                        SubsectionToScreen(subsection);
                    }
                    // 更新の場合
                    else {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // 表示情報取得
                        Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                        subsection = ( SubSection ) this._detailsTable[guid];

                        // 画面展開処理
                        SubsectionToScreen(subsection);

                        // クローン作成
                        this._SubsectionClone = subsection.Clone();
                        DispToSubsection(ref this._SubsectionClone);

                        // フォーカス設定
                        this.SubSectionName_tEdit.SelectAll();
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SubSection subsection = new SubSection();

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                SubsectionToScreen(subsection);

                // クローン作成
                this._SubsectionClone = subsection.Clone();
                DispToSubsection(ref this._SubsectionClone);

                // フォーカス設定
                this.tNedit_SubSectionCode.Focus();
            }
            // 削除の場合
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                subsection = (SubSection)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(subsection);
            }
            // 更新の場合
            else
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;

                // 表示情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                subsection = (SubSection)this._detailsTable[guid];

                // 画面展開処理
                SubsectionToScreen(subsection);

                // クローン作成
                this._SubsectionClone = subsection.Clone();
                DispToSubsection(ref this._SubsectionClone);

                // フォーカス設定
                this.SubSectionName_tEdit.SelectAll();
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //_GridIndexバッファ保持
            this._detailsIndexBuf = this._dataIndex;  // ADD 2008/06/04
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._detailsIndexBuf = this._detailsDataIndex;
            this._mainIndexBuf = this._mainDataIndex;
            this._targetTableBuf = this._targetTableName;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// 拠点クラス画面展開処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCode.Text     = secInfoSet.SectionCode;       // 拠点コード
            this.SectionGuideNm_tEdit.Text  = secInfoSet.SectionGuideNm;    // 拠点名称
        }

        /// <summary>
        /// 部門クラス画面展開処理
        /// </summary>
        /// <param name="Subsection">部門オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void SubsectionToScreen(SubSection Subsection)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点コード
            this.SectionCode_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            // 拠点名称
            this.SectionGuideNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONGUIDENM_TITLE];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 拠点コード
            this.tEdit_SectionCode.DataText = Subsection.SectionCode.Trim();

            // 拠点名称
            this.SectionGuideNm_tEdit.DataText = GetSectionName(Subsection.SectionCode);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // 部門コード
            if (Subsection.SubSectionCode == 0) {
                this.tNedit_SubSectionCode.Text = "";
            }
            else {
                this.tNedit_SubSectionCode.Text = Subsection.SubSectionCode.ToString("00");
            }
            this.SubSectionName_tEdit.Text = Subsection.SubSectionName;                 // 部門名称

        }

        /// <summary>
        /// 画面情報拠点クラス格納処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCode.Text;      // 拠点コード
            secInfoSet.SectionGuideNm   = this.SectionGuideNm_tEdit.Text;   // 拠点名称
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // 企業コード
        }

        /// <summary>
        /// 画面情報部門クラス格納処理
        /// </summary>
        /// <param name="Subsection">部門オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から部門オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DispToSubsection(ref SubSection Subsection)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (Mode_Label.Text == INSERT_MODE) {
                // 拠点コード
                Subsection.SectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 企業コード
            Subsection.EnterpriseCode = this._enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    Subsection.SectionCode   = this.SectionCode_tEdit.Text;
                    Subsection.SectionGuideNm = this.SectionGuideNm_tEdit.Text;
                    Subsection.SubSectionCode = ToInt( this.SubSectionCode_tNedit.Text );
                    Subsection.SubSectionName = this.SubSectionName_tEdit.Text;
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            Subsection.SectionCode = this.tEdit_SectionCode.DataText;
            Subsection.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
            Subsection.SubSectionName = this.SubSectionName_tEdit.DataText;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    // 部門コード
                    if (this.SubSectionCode_tNedit.Text == "") {
                        control = this.SubSectionCode_tNedit;
                        message = this.SubsectionCode_Title_Label.Text + "を入力して下さい。";
                        result = false;
                    }
                    // 部門名称
                    else if (this.SubSectionName_tEdit.Text.Trim() == "") {
                        control = this.SubSectionName_tEdit;
                        message = this.SubsectionName_Title_Label.Text + "を入力して下さい。";
                        result = false;
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // 部門コード
            if (this.tNedit_SubSectionCode.Text == "")
            {
                control = this.tNedit_SubSectionCode;
                message = this.SubsectionCode_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            // 部門名称
            else if (this.SubSectionName_tEdit.Text.Trim() == "")
            {
                control = this.SubSectionName_tEdit;
                message = this.SubsectionName_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            // 拠点コード
            else if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = this.SectionCode_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            else if (GetSectionName(this.tEdit_SectionCode.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCode;
                message = "マスタに登録されていません。";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 拠点・部門の保存処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        //private bool SaveProc(string saveTarget)  // DEL 2008/06/04
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

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (saveTarget) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    // 部門更新
                    if (!SaveSubsection()) {
                        return false;
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 部門更新
            if (!SaveSubsection())
            {
                return false;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return true;
        }

        /// <summary>
        /// 部門テーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : Subsectionテーブルの更新を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            SubSection Subsection = new SubSection();
            //SubSectionWork SubsectionWork = new SubSectionWork();  // DEL 2008/06/04

            // 登録レコード情報取得
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                Subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();
            }

            // SecInfoSetクラスにデータを格納
            DispToSubsection(ref Subsection);

            // SecInfoSetクラスをアクセスクラスに渡して登録・更新
            int status = this._subsectionAcs.Write(ref Subsection);

            // エラー処理
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash更新処理
                    DetailsToDataSet(Subsection, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // 重複処理
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._subsectionAcs);
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
                        this._subsectionAcs,				    // エラーが発生したオブジェクト
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
        /// 部門 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部門の対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // 削除対象部門取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            status = this._subsectionAcs.LogicalDelete(ref subsection);
            
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DetailsToDataSet(subsection, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._subsectionAcs);
                    // フレーム更新
                    DetailsToDataSet(subsection, _dataIndex);
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
                        this._subsectionAcs,			        // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,				// 表示するボタン
                        MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                    // フレーム更新
                    DetailsToDataSet(subsection, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// 部門 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部門の対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // 削除対象部門取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            // 物理削除
            status = this._subsectionAcs.Delete(subsection);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet更新
                    DeleteFromDataSet(subsection, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._subsectionAcs);
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
                        this._subsectionAcs,					// エラーが発生したオブジェクト
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
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// 拠点 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部門の対象レコードを復活します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // 復活対象部門取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection Subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            // 復活
            status = this._subsectionAcs.Revival(ref Subsection);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet展開処理
                    DetailsToDataSet(Subsection, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._subsectionAcs);
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
                        this._subsectionAcs,					// エラーが発生したオブジェクト
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
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
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (TargetTableName == MAIN_TABLE) 
                {
                    // データインデックスを初期化する
                    this._mainDataIndex = -1;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this._mainIndexBuf = -2;
                this._targetTableBuf = "";
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
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

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch ( TargetTableName ) {
                // 拠点テーブルの場合
                case MAIN_TABLE: 
                    control = this.SectionCode_tEdit;
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    control = this.SubSectionCode_tNedit;
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            control = this.tNedit_SubSectionCode;  // ADD 2008/06/04
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(36, 24);
            this.SubSectionName_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(115, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(MAKHN09230U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<

            // ガイドボタンのアイコン設定
            this.SectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// Form.Closing イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録処理
            //SaveProc(this._targetTableName);  // DEL 2008/06/04
            SaveProc();
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // 削除モード以外の場合は保存確認処理を行う
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch ( this._targetTableName ) {
                    // 拠点テーブルの場合
                    case MAIN_TABLE:
                        break;
                    // 部門テーブルの場合
                    case DETAILS_TABLE: 
                        // 現在の画面情報を取得
                        SubSection subsection = new SubSection();
                        subsection = this._SubsectionClone.Clone();
                        DispToSubsection(ref subsection);
                        // 最初に取得した画面情報と比較
                        cloneFlg = this._SubsectionClone.Equals(subsection);
                        break;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // 現在の画面情報を取得
                SubSection subsection = new SubSection();
                subsection = this._SubsectionClone.Clone();
                DispToSubsection(ref subsection);
                // 最初に取得した画面情報と比較
                cloneFlg = this._SubsectionClone.Equals(subsection);
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

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
                            //if ( SaveProc(this._targetTableName) ) {  // DEL 2008/06/04
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
                            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_SubSectionCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
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

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
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
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch ( this._targetTableName ) {
                    // 拠点テーブルの場合
                    case MAIN_TABLE:
                        break;
                    // 部門テーブルの場合
                    case DETAILS_TABLE:
                        // 部門物理削除
                        PhysicalDeleteSubsection();
                        break;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // 部門物理削除
                PhysicalDeleteSubsection();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch ( this._targetTableName ) {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    break;
                // 部門テーブルの場合
                case DETAILS_TABLE:
                    // 拠点復活
                    ReviveSubsection();
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            ReviveSubsection();  // ADD 2008/06/04
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 文字列→数値　変換
        /// </summary>
        /// <param name="text">文字列</param>
        /// <returns>数値</returns>
        private int ToInt( string text ) 
        {
            try {
                return Convert.ToInt32( text );
            }
            catch {
                return 0;
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private void SectionGuide_ultraButton_Click(object sender, EventArgs e)
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
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionGuideNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        
            switch (e.PrevCtrl.Name)
            {
                //case "SubSectionCode_tNedit":
                case "tNedit_SubSectionCode":
                    // 部門コードにフォーカスがある場合
                    if (e.Key == Keys.Right)
                    {
                        // 部門名称にフォーカスを移します
                        e.NextCtrl = this.SubSectionName_tEdit;
                    }
                    
                    // モード変更処理
                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = tNedit_SubSectionCode;
                        }
                    }
                    // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                    break;
                case "SubSectionName_tEdit":
                    // 部門名称にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 拠点コードにフォーカスを移します
                        e.NextCtrl = tEdit_SectionCode;
                    }
                    break;
                case "tEdit_SectionCode":
                    // 拠点コードが未入力の場合
                    if (this.tEdit_SectionCode.DataText.Trim() == "")
                    {
                        this.SectionGuideNm_tEdit.DataText = "";
                        return;
                    }

                    // 拠点コード取得
                    string sectionCode = this.tEdit_SectionCode.DataText;

                    // 拠点名称取得
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                    // 拠点コードにフォーカスがある場合
                    if (e.Key == Keys.Enter)
                    {
                        if (this.SectionGuideNm_tEdit.DataText != "")
                        {
                            // 拠点コードにフォーカスを移します
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "Ok_Button":
                    // 保存ボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 拠点ガイドボタンにフォーカスを移します
                        e.NextCtrl = SectionGuide_ultraButton;
                    }
                    break;
                default:
                    break;
            }
        }

        // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._subsectionAcs = new SubSectionAcs();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/18 残案件No.14対応------------------------------------------------------<<<<<
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 部門コード
            string subSecCd = tNedit_SubSectionCode.GetInt().ToString("00");

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSubSecCd = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][SUBSECTIONCODE_TITLE];
                if (subSecCd.Equals(dsSubSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの部門設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 部門コードのクリア
                        tNedit_SubSectionCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの部門設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // 部門コードのクリア
                                tNedit_SubSectionCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        # endregion
    }
}
