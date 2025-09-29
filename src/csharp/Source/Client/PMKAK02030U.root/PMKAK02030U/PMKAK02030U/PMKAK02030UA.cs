//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 入力フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Windows.Forms
{
    public class PMKAK02030UA : System.Windows.Forms.Form,
        IPrintConditionInpType,
        IPrintConditionInpTypeSelectedSection,
        IPrintConditionInpTypePdfCareer
    {
        # region Private Members (Component)

        private System.Windows.Forms.Panel Centering_Panel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Timer Initial_Timer;
        private System.Windows.Forms.Panel MAHNB02020UA_Fill_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private ToolTip toolTip1;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private TComboEditor MakeShowDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton SupplierCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SupplierCdSt_GuideBtn;
        private TComboEditor SlipDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private TNedit tNedit_SupplierCd_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet SpecifyDate_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor NewPageType_tComboEditor;
        private TDateEdit InputDayEd_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit InputDaySt_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel Date_Title_Label;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region constructer
        /// <summary>
        /// 仕入返品予定一覧表UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入返品予定一覧表UIクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// <br></br>
        /// </remarks>
        public PMKAK02030UA()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._salesFormalList = new SortedList();
            this._salesSlipKindList = new SortedList();

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                this._ownSectionCode = this._loginWorker.BelongSectionCode;
            }

            //日付チェック部品のインスタンスを生成
            this._dateGetAcs = DateGetAcs.GetInstance();

        }
        #endregion

        // ===================================================================================== //
        // 破棄
        // ===================================================================================== //
        #region Dispose
        /// <summary>
        /// 破棄
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

        // ===================================================================================== //
        // Windowsフォームデザイナで生成されたコード
        // ===================================================================================== //
        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SpecifyDate_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.NewPageType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.InputDayEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDaySt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Date_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.MakeShowDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SupplierCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SlipDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAHNB02020UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecifyDate_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            this.MAHNB02020UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SpecifyDate_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.NewPageType_tComboEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDaySt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.Date_Title_Label);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(714, 104);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // ultraLabel2
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance16;
            this.ultraLabel2.Location = new System.Drawing.Point(24, 10);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel2.TabIndex = 39;
            this.ultraLabel2.Text = "日付指定";
            // 
            // SpecifyDate_ultraOptionSet
            // 
            this.SpecifyDate_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "伝票日付";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "入力日付";
            this.SpecifyDate_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.SpecifyDate_ultraOptionSet.Location = new System.Drawing.Point(178, 13);
            this.SpecifyDate_ultraOptionSet.Name = "SpecifyDate_ultraOptionSet";
            this.SpecifyDate_ultraOptionSet.Size = new System.Drawing.Size(248, 20);
            this.SpecifyDate_ultraOptionSet.TabIndex = 1;
            // 
            // ultraLabel21
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance8;
            this.ultraLabel21.Location = new System.Drawing.Point(24, 69);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel21.TabIndex = 37;
            this.ultraLabel21.Text = "改頁";
            // 
            // NewPageType_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ActiveAppearance = appearance68;
            this.NewPageType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ItemAppearance = appearance69;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "拠点";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "仕入先";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "しない";
            this.NewPageType_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.NewPageType_tComboEditor.LimitToList = true;
            this.NewPageType_tComboEditor.Location = new System.Drawing.Point(178, 70);
            this.NewPageType_tComboEditor.Name = "NewPageType_tComboEditor";
            this.NewPageType_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.NewPageType_tComboEditor.TabIndex = 36;
            // 
            // InputDayEd_tDateEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEd_tDateEdit.ActiveEditAppearance = appearance9;
            this.InputDayEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEd_tDateEdit.CalendarDisp = true;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.EditAppearance = appearance10;
            this.InputDayEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.LabelAppearance = appearance11;
            this.InputDayEd_tDateEdit.Location = new System.Drawing.Point(397, 39);
            this.InputDayEd_tDateEdit.Name = "InputDayEd_tDateEdit";
            this.InputDayEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEd_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEd_tDateEdit.TabIndex = 3;
            this.InputDayEd_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance12;
            this.ultraLabel10.Location = new System.Drawing.Point(366, 39);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "～";
            // 
            // InputDaySt_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDaySt_tDateEdit.ActiveEditAppearance = appearance13;
            this.InputDaySt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDaySt_tDateEdit.CalendarDisp = true;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.EditAppearance = appearance14;
            this.InputDaySt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDaySt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.LabelAppearance = appearance15;
            this.InputDaySt_tDateEdit.Location = new System.Drawing.Point(178, 39);
            this.InputDaySt_tDateEdit.Name = "InputDaySt_tDateEdit";
            this.InputDaySt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDaySt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDaySt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDaySt_tDateEdit.TabIndex = 2;
            this.InputDaySt_tDateEdit.TabStop = true;
            // 
            // Date_Title_Label
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.Date_Title_Label.Appearance = appearance62;
            this.Date_Title_Label.Location = new System.Drawing.Point(24, 39);
            this.Date_Title_Label.Name = "Date_Title_Label";
            this.Date_Title_Label.Size = new System.Drawing.Size(140, 23);
            this.Date_Title_Label.TabIndex = 6;
            this.Date_Title_Label.Text = "対象日";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.MakeShowDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SlipDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 187);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(714, 195);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // MakeShowDiv_tComboEditor
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ActiveAppearance = appearance24;
            this.MakeShowDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ItemAppearance = appearance25;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "通常";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "削除";
            this.MakeShowDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.MakeShowDiv_tComboEditor.LimitToList = true;
            this.MakeShowDiv_tComboEditor.Location = new System.Drawing.Point(178, 69);
            this.MakeShowDiv_tComboEditor.Name = "MakeShowDiv_tComboEditor";
            this.MakeShowDiv_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.MakeShowDiv_tComboEditor.TabIndex = 150;
            // 
            // ultraLabel6
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance26;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 71);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel6.TabIndex = 26;
            this.ultraLabel6.Text = "発行タイプ";
            // 
            // SupplierCdEd_GuideBtn
            // 
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SupplierCdEd_GuideBtn.Appearance = appearance34;
            this.SupplierCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SupplierCdEd_GuideBtn.Location = new System.Drawing.Point(401, 9);
            this.SupplierCdEd_GuideBtn.Name = "SupplierCdEd_GuideBtn";
            this.SupplierCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SupplierCdEd_GuideBtn.TabIndex = 65;
            this.SupplierCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SupplierCdEd_GuideBtn, "仕入先検索");
            this.SupplierCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SupplierCdEd_GuideBtn.Click += new System.EventHandler(this.SupplierCdEd_GuideBtn_Click);
            // 
            // SupplierCdSt_GuideBtn
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SupplierCdSt_GuideBtn.Appearance = appearance35;
            this.SupplierCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SupplierCdSt_GuideBtn.Location = new System.Drawing.Point(258, 8);
            this.SupplierCdSt_GuideBtn.Name = "SupplierCdSt_GuideBtn";
            this.SupplierCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SupplierCdSt_GuideBtn.TabIndex = 55;
            this.SupplierCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SupplierCdSt_GuideBtn, "仕入先検索");
            this.SupplierCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SupplierCdSt_GuideBtn.Click += new System.EventHandler(this.SupplierCdSt_GuideBtn_Click);
            // 
            // SlipDiv_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ActiveAppearance = appearance46;
            this.SlipDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ItemAppearance = appearance47;
            valueListItem8.DataValue = 2;
            valueListItem8.DisplayText = "全て";
            valueListItem9.DataValue = 0;
            valueListItem9.DisplayText = "返品予定のみ";
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "返品済のみ";
            this.SlipDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.SlipDiv_tComboEditor.LimitToList = true;
            this.SlipDiv_tComboEditor.Location = new System.Drawing.Point(178, 39);
            this.SlipDiv_tComboEditor.Name = "SlipDiv_tComboEditor";
            this.SlipDiv_tComboEditor.Size = new System.Drawing.Size(131, 24);
            this.SlipDiv_tComboEditor.TabIndex = 130;
            this.SlipDiv_tComboEditor.ValueChanged += new System.EventHandler(this.OutPutTypeChanged);
            // 
            // ultraLabel12
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance48;
            this.ultraLabel12.Location = new System.Drawing.Point(24, 41);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel12.TabIndex = 22;
            this.ultraLabel12.Text = "出力指定";
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance50;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(321, 9);
            this.tNedit_SupplierCd_Ed.MaxLength = 9;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(74, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 60;
            // 
            // ultraLabel11
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance51;
            this.ultraLabel11.Location = new System.Drawing.Point(291, 10);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 56;
            this.ultraLabel11.Text = "～";
            // 
            // tNedit_SupplierCd_St
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance52;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance53;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(178, 9);
            this.tNedit_SupplierCd_St.MaxLength = 9;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(74, 24);
            this.tNedit_SupplierCd_St.TabIndex = 50;
            // 
            // ultraLabel3
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance54;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "仕入先";
            // 
            // MAHNB02020UA_Fill_Panel
            // 
            this.MAHNB02020UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAHNB02020UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAHNB02020UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAHNB02020UA_Fill_Panel.Name = "MAHNB02020UA_Fill_Panel";
            this.MAHNB02020UA_Fill_Panel.Size = new System.Drawing.Size(750, 677);
            this.MAHNB02020UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(750, 677);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance55.FontData.Name = "ＭＳ ゴシック";
            appearance55.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance55;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance56;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 106;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup2.Key = "ExtraConditionCodeGroup";
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance58;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 197;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　抽出条件";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance45.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance45;
            appearance60.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance60;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(750, 677);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance61.FontData.SizeInPoints = 20F;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance61;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 560);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // PMKAK02030UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 677);
            this.Controls.Add(this.MAHNB02020UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMKAK02030UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PMKAK02030UA_Load);
            this.Activated += new System.EventHandler(this.PMKAK02030UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecifyDate_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            this.MAHNB02020UA_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).EndInit();
            this.Main_ultraExplorerBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private string _enterpriseCode = "";

        private bool _printButtonEnabled = true;
        private bool _extraButtonEnabled = false;
        private bool _pdfButtonEnabled = true;
        private bool _printButtonVisibled = true;
        private bool _extraButtonVisibled = false;
        private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;

        private int _selectedAddUpCd;

        private Employee _loginWorker = null;

        // 自拠点コード
        private string _ownSectionCode = "";

        private ExtrInfo_PMKAK02034E _chartExtrInfo_PMKAK02034E = null;

        // 拠点アクセスクラス
        private static SecInfoAcs _secInfoAcs;

        private static SupplierAcs _supplierAcs;

        //日付取得部品
        DateGetAcs _dateGetAcs;

        // 売上確認表アクセスクラス
        private PMKAK02032A _salesTableListAcs = null;

        private Hashtable _selectedhSectinTable = new Hashtable();
        // 拠点オプション有無
        private bool _isOptSection;
        // 本社機能有無
        private bool _isMainOfficeFunc;

        private string _SalesTableDataTable;

        SortedList _salesFormalList;
        SortedList _salesSlipKindList;

        // エクスプローラバー拡大基準高さ
        private Form _topForm = null;

        private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();		//条件クラス(前回条件保持用)
        private ExtrInfo_PMKAK02034E _chart_ExtrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();		//条件クラス(チャート引渡し用)
        private DataSet _printBuffDataSet = null;

        /// <summary>範囲指定ガイドのフォーカス制御オブジェクトのリスト</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();

        /// <summary>
        /// 範囲指定ガイドのフォーカス制御オブジェクトのリストを取得します。
        /// </summary>
        /// <value>範囲指定ガイドのフォーカス制御オブジェクトのリスト</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }

        /// <summary>日計印字ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// 日計印字ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>日計印字ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PrintDailyFooterRadioKeyPressHelper
        {
            get { return _printDailyFooterRadioKeyPressHelper; }
        }
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

        #region ◆ Interface member
        // クラスID
        private const string ct_ClassID = "PMKAK02030UA";
        // プログラムID
        private const string ct_PGID = "PMKAK02030U";
        // 帳票名称
        private const string ct_PrintName = "仕入返品予定一覧表";
        // 帳票キー	
        private const string ct_PrintKey = "1b038c00-51d9-4964-a156-7fd9a3340233";

        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";


        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";			// ソート順
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// 抽出条件
        private const string ct_ExBarGroupNm_BuyPrintGroup = "BuyPrintGroup";                   // 買掛印刷設定

        // エクスプローラーバーの表示状態を決定するための基準となるトップフォームの高さ
        private const int CT_TOPFORM_BASE_HEIGHT = 768;
        #endregion

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------

        #endregion ◆ Interface member
        #endregion

        // ===================================================================================== //
        // IPrintConditionInpType メンバ
        // ===================================================================================== //
        #region IPrintConditionInpType メンバ
        /// <summary>
        /// 印刷ボタン有効無効プロパティ
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return _printButtonEnabled;
            }
        }

        /// <summary>
        /// 抽出ボタン有効無効プロパティ
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return _extraButtonEnabled;
            }
        }

        /// <summary>
        /// PDFボタン有効無効プロパティ
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return _pdfButtonEnabled;
            }
        }

        /// <summary>
        /// 印刷ボタン表示プロパティ
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return _printButtonVisibled;
            }
        }

        /// <summary>
        /// 抽出ボタン表示プロパティ
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return _extraButtonVisibled;
            }
        }

        /// <summary>
        /// PDFボタン表示プロパティ
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return _pdfButtonVisibled;
            }
        }

        // ===================================================================================== //
        // IPrintConditionInpTypeCondition メンバ
        // ===================================================================================== //
        /// <summary>
        /// チャート用抽出条件設定
        /// </summary>
        public object ObjExtract
        {
            get
            {
                return _chartExtrInfo_PMKAK02034E;
            }
        }

        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract(ref object parameter)
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion
        /// <summary>
        /// ツールバー表示制御イベント
        /// </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;


        /// <summary>
        /// Control.Showのオーバーロード
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面表示を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 印刷処理を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            SFCMN06001U printDialog = new SFCMN06001U();			// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	  // 印刷情報パラメータ

            // 企業コード
            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            printInfo.kidopgid = ct_PGID;			  // 起動ＰＧＩＤ
            printInfo.key = ct_PrintKey;				 // PDF履歴管理用KEY情報

            // 画面→抽出条件クラス
            ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();
            this.SetExtraInfoFromScreen(out extrInfo_PMKAK02034E);

            // 抽出条件の設定
            printInfo.jyoken = extrInfo_PMKAK02034E;

            printInfo.PrintPaperSetCd = 0;

            printInfo.rdData = this._printBuffDataSet;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = (Object)printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }


        #endregion
        // ===================================================================================== //
        // IPrintConditionInpTypePdfCareer メンバ
        // ===================================================================================== //
        #region IPrintConditionInpTypePdfCareer メンバ
        /// <summary>帳票KEYプロパティ</summary>
        /// <remarks>帳票の出力履歴取得用のKEY値を取得します。</remarks>
        public string PrintKey
        {
            get
            {
                return ct_PrintKey;
            }
        }

        /// <summary>帳票名プロパティ</summary>
        /// <remarks>帳票名を取得します。</remarks>
        public string PrintName
        {
            get
            {
                return ct_PrintName;
            }
        }
        #endregion

        // ===================================================================================== //
        // メイン
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKAK02030UA());
        }
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private methods
        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 初期画面設定を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            #region < 日付範囲 >
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            this.InputDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;// システム日付
            this.InputDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;// システム日付
            this.InputDaySt_tDateEdit.SetLongDate(nowLongDate);
            this.InputDayEd_tDateEdit.SetLongDate(nowLongDate);
            #endregion

            #region < 拠点 >
            this.NewPageType_tComboEditor.Value = 0;    // 拠点
            #endregion

            #region < 日付指定 >
            this.SpecifyDate_ultraOptionSet.Value = 0;  // 伝票日付
            #endregion

            #region < 出力指定 >
            this.SlipDiv_tComboEditor.Value = 2;        // すべて
            #endregion

            #region < 発行タイプ >
            this.MakeShowDiv_tComboEditor.Value = 0;    // 通常
            #endregion

            this.InputDaySt_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // 対象日From
            this.InputDayEd_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // 対象日To

        }


        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note	   : 画面の入力チェックを行う。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい";
            const string ct_InputError = "の入力が不正です";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // 処理月（開始・終了）
            if (CallCheckDateRange(out cdrResult, ref InputDaySt_tDateEdit, ref InputDayEd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象日{0}", ct_NoInput);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象日{0}", ct_InputError);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象日{0}", ct_NoInput);
                            errComponent = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象日{0}", ct_InputError);
                            errComponent = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象日{0}", ct_RangeError);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                }
                status = false;
            }

            // 仕入先
            if ((this.tNedit_SupplierCd_Ed.GetInt() != 0) && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 日付範囲チェック呼び出し
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            cdrResult = this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        #region ◎ 年月入力チェック処理
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;

            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;

        }
        #endregion

        /// <summary>
        ///
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <returns></returns>
        private int SearchData(ExtrInfo_PMKAK02034E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 抽出条件が変わっているならリモーティング
            if (this._printBuffDataSet == null || this._extrInfo_PMKAK02034E == null || !this._extrInfo_PMKAK02034E.Equals(extraInfo))
            {
                try
                {
                    status = this._salesTableListAcs.Search(extraInfo, out message, 0);
                    if (status == 0)
                    {
                        this._printBuffDataSet = this._salesTableListAcs._printDataSet;
                    }
                }
                catch (Exception ex)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // 戻り値を設定。異常の場合はメッセージを表示
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            this._extrInfo_PMKAK02034E = extraInfo.Clone();

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        default:
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                    }
                }
            }
            else
            {
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_SalesTableDataTable].Rows.Count == 0)
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面→抽出条件へ設定します。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(out ExtrInfo_PMKAK02034E extraInfo)
        {
            extraInfo = new ExtrInfo_PMKAK02034E();

            #region < 企業コード >
            extraInfo.EnterpriseCode = this._enterpriseCode;
            #endregion

            #region < 選択拠点 >
            // 拠点オプションありのとき
            if (IsOptSection)
            {
                ArrayList secList = new ArrayList();
                // 全社選択かどうか
                if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
                {

                    //AクラスSearchParaSet()で“全社の場合”のif文に入るための条件
                    extraInfo.SectionCodes = new string[1];
                    extraInfo.SectionCodes[0] = "0";

                }
                else
                {
                    foreach (DictionaryEntry dicEntry in this._selectedhSectinTable)
                    {
                        if ((CheckState)dicEntry.Value == CheckState.Checked)
                        {
                            secList.Add(dicEntry.Key);
                        }
                    }
                    extraInfo.SectionCodes = (string[])secList.ToArray(typeof(string));
                }
            }
            // 拠点オプションなしの時
            else
            {
                extraInfo.SectionCodes = new string[0];
                extraInfo.SectionCodes[0] = "0";
            }
            #endregion

            #region < 日付指定 >
            extraInfo.PrintDailyFooter = Convert.ToInt32(this.SpecifyDate_ultraOptionSet.CheckedItem.DataValue);
            #endregion

            #region < 対象日 >
            // 対象日(開始)
            extraInfo.InputDaySt = this.InputDaySt_tDateEdit.GetLongDate();
            // 対象日(終了)
            extraInfo.InputDayEd = this.InputDayEd_tDateEdit.GetLongDate();
            #endregion

            #region < 改頁 >
            extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageType_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < 仕入先 >
            // 仕入先(開始)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
            // 仕入先(終了)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            #endregion

            #region < 出力指定 >
            // 出力指定
            extraInfo.SlipDiv = Convert.ToInt32(this.SlipDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.SlipDivName = this.SlipDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

            #region < 発行タイプ >
            // 発行タイプ
            extraInfo.MakeShowDiv = Convert.ToInt32(this.MakeShowDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.MakeShowDivName = MakeShowDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

        }

        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            _SalesTableDataTable = Broadleaf.Application.UIData.PMKAK02035EA.ct_Tbl_StockRetDtl;
        }

        /// <summary>
        /// 最上位フォーム取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void GetTopForm()
        {
            // 最上位の親コントロールを取得する
            Control parent = this.Parent;

            while (parent != null)
            {
                if (parent.Parent == null) break;

                parent = parent.Parent;
            }

            if (parent != null)
            {
                if (parent is Form)
                {
                    this._topForm = (Form)parent;
                    this._topForm.SizeChanged += new EventHandler(TopForm_SizeChanged);
                }
            }
        }

        /// <summary>
        /// トップフォームサイズ変更イベント
        /// </summary>
        private void TopForm_SizeChanged(object sender, EventArgs e)
        {
            this.AdjustExplorerBarExpand();
        }

        /// <summary>
        /// エクスプローラーバー展開状態調整
        /// </summary>
        private void AdjustExplorerBarExpand()
        {

        }

        #endregion ◆ 印刷前処理

        #region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note	   : エラーメッセージを表示します。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }

        /// <summary>
        /// 終了項目値自動設定処理(TDateEdit)
        /// </summary>
        /// <param name="startDate">開始日付項目TDateEdit</param>
        /// <param name="endDate">終了日付項目TDateEdit</param>
        private void AutoSetEndValue(TDateEdit startDate, TDateEdit endDate)
        {
            if (endDate.LongDate == 0)
            {
                endDate.SetLongDate(startDate.LongDate);
            }
        }

        /// <summary>
        /// 終了項目値自動設定処理(TEdit)
        /// </summary>
        /// <param name="startEdit">開始文字列項目TEdit</param>
        /// <param name="endEdit">終了文字列項目TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// 終了項目値自動設定処理(TNedit)
        /// </summary>
        /// <param name="startNedit">開始数値項目TEdit</param>
        /// <param name="endNedit">終了数値項目TEdit</param>
        private void AutoSetEndValue(TNedit startNedit, TNedit endNedit)
        {
            if ((endNedit.GetInt() == 0) &&
                (startNedit.GetInt() != 0))
            {
                endNedit.SetInt(startNedit.GetInt());
            }
        }

        #endregion

        #region internal methods
        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        public bool GetMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // 本社機能か？
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }
        #endregion

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region Control Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		: 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void PMKAK02030UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._salesTableListAcs = new PMKAK02032A();

            // 最上位フォーム取得
            this.GetTopForm();

            // 拠点オプション有無を取得する
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 本社/拠点情報を取得する
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

            // 仕入先：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.SupplierCdSt_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));

            // 仕入先：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.SupplierCdEd_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.SpecifyDate_ultraOptionSet);
            PrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 画面アクティブイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note	   : 仕入返品予定一覧表メイン画面がアクティブになったときのイベント処理です。</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void PMKAK02030UA_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// tArrowKey ＆ tRetKey イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note	   : コントロールでキーが押されてフォーカス移動したときのイベント処理です。</br>
        /// <br>Programer  : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void tKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.ShiftKey)
            {
                return;
            }
            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
            {
                // 仕入先From
                if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tNedit_SupplierCd_St.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text) == false))
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    return;
                }
                // 仕入先To
                if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                {
                    // データがあればガイドを飛ばす
                    if ((this.tNedit_SupplierCd_Ed.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text) == false))
                    {
                        e.NextCtrl = this.SlipDiv_tComboEditor;
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// 初期タイマーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note		: 初期処理を行います。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // 画面初期表示
            this.InitialScreenSetting();

            // 初期フォーカス
            this.InputDaySt_tDateEdit.Focus();

            // ガイドボタンのアイコン設定
            this.SetIconImage(this.SupplierCdSt_GuideBtn, Size16_Index.STAR1);
            this.SetIconImage(this.SupplierCdEd_GuideBtn, Size16_Index.STAR1);

            // メインフレームにツールバー設定通知
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// 出力指定選択イベント
        /// </summary>
        private void OutPutTypeChanged(object sender, EventArgs e)
        {
            //「返品済のみ」を選択時は「発行タイプ」を選択不可にする
            if ((int)this.SlipDiv_tComboEditor.Value == 1)
            {
                this.MakeShowDiv_tComboEditor.Enabled = false;
                this.MakeShowDiv_tComboEditor.Value = 0;
            }
            else
            {
                this.MakeShowDiv_tComboEditor.Enabled = true;
            }
        }


        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup"))
            {
                // グループの縮小をキャンセル
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup"))
            {
                // グループの展開をキャンセル
                e.Cancel = true;
            }
        }

        #region ■ガイド起動イベント
        /// <summary>
        /// 仕入先コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_St.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 仕入先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // インスタンス生成
                    _supplierAcs = new SupplierAcs();
                }

                // ガイド起動
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // 項目に展開
                if (status == 0)
                {
                    this.tNedit_SupplierCd_Ed.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        // ===================================================================================== //
        // IPrintConditionInpTypeSelectedSection メンバ
        // ===================================================================================== //
        #region IPrintConditionInpTypeSelectedSection メンバ

        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkState">コントロール状態</param>
        /// <remarks>
        /// <br>Note	   : 拠点を選択処理を行ないます。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // 拠点を選択した時
            if (checkState == CheckState.Checked)
            {
                // 全社が選択された時
                if (sectionCode == "0")
                {
                    // 選択選択リストをクリア
                    this._selectedhSectinTable.Clear();
                }

                // リストに拠点が追加されていない時、拠点の状態を追加
                if (this._selectedhSectinTable.ContainsKey(sectionCode) == false)
                {
                    this._selectedhSectinTable.Add(sectionCode, checkState);
                }
            }
            // 拠点の選択を解除した時
            else if (checkState == CheckState.Unchecked)
            {
                // 選択拠点リストから削除
                if (this._selectedhSectinTable.ContainsKey(sectionCode))
                {
                    this._selectedhSectinTable.Remove(sectionCode);
                }
            }
        }

        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 選択されている拠点を設定します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }

            this._selectedhSectinTable.Clear();
            for (int ix = 0; ix < sectionCodeLst.Length; ix++)
            {
                // 選択拠点を追加
                this._selectedhSectinTable.Add(sectionCodeLst[ix], CheckState.Checked);
            }
        }

        /// <summary>
        /// 拠点表示取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 選択されている拠点を設定します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }

        /// <summary>
        /// 計上拠点選択表示取得プロパティ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 選択されている拠点を設定します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return _visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// 拠点オプション取得プロパティ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 拠点オプション取得プロパティ</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary>
        /// 本社機能取得プロパティ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 本社機能取得プロパティ</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary>
        /// 計上拠点選択処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 計上拠点選択処理</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void SelectedAddUpCd(int SelectAddUpCd)
        {
            // 現在のチェックされている計上拠点情報を渡す。
            this._selectedAddUpCd = SelectAddUpCd;
        }

        /// <summary>
        /// 初期選択計上拠点設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 選択されている計上拠点を設定します</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            this._selectedAddUpCd = addUpCd;
            return;
        }

        #endregion
        #endregion
    }
}
        