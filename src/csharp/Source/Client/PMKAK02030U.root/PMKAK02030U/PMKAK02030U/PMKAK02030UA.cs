//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ���̓t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
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
        // �R���X�g���N�^
        // ===================================================================================== //
        #region constructer
        /// <summary>
        /// �d���ԕi�\��ꗗ�\UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\UI�N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : FSI���� ����</br>
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

            //���t�`�F�b�N���i�̃C���X�^���X�𐶐�
            this._dateGetAcs = DateGetAcs.GetInstance();

        }
        #endregion

        // ===================================================================================== //
        // �j��
        // ===================================================================================== //
        #region Dispose
        /// <summary>
        /// �j��
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
        // Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
        // ===================================================================================== //
        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
            this.ultraLabel2.Text = "���t�w��";
            // 
            // SpecifyDate_ultraOptionSet
            // 
            this.SpecifyDate_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "�`�[���t";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "���͓��t";
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
            this.ultraLabel21.Text = "����";
            // 
            // NewPageType_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ActiveAppearance = appearance68;
            this.NewPageType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ItemAppearance = appearance69;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "���_";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "�d����";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "���Ȃ�";
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
            this.ultraLabel10.Text = "�`";
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
            this.Date_Title_Label.Text = "�Ώۓ�";
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
            valueListItem6.DisplayText = "�ʏ�";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "�폜";
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
            this.ultraLabel6.Text = "���s�^�C�v";
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
            this.toolTip1.SetToolTip(this.SupplierCdEd_GuideBtn, "�d���挟��");
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
            this.toolTip1.SetToolTip(this.SupplierCdSt_GuideBtn, "�d���挟��");
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
            valueListItem8.DisplayText = "�S��";
            valueListItem9.DataValue = 0;
            valueListItem9.DisplayText = "�ԕi�\��̂�";
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "�ԕi�ς̂�";
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
            this.ultraLabel12.Text = "�o�͎w��";
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
            this.ultraLabel11.Text = "�`";
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
            this.ultraLabel3.Text = "�d����";
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
            appearance55.FontData.Name = "�l�r �S�V�b�N";
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
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup2.Key = "ExtraConditionCodeGroup";
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance58;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 197;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@���o����";
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
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
        // �v���C�x�[�g�ϐ�
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

        // �����_�R�[�h
        private string _ownSectionCode = "";

        private ExtrInfo_PMKAK02034E _chartExtrInfo_PMKAK02034E = null;

        // ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;

        private static SupplierAcs _supplierAcs;

        //���t�擾���i
        DateGetAcs _dateGetAcs;

        // ����m�F�\�A�N�Z�X�N���X
        private PMKAK02032A _salesTableListAcs = null;

        private Hashtable _selectedhSectinTable = new Hashtable();
        // ���_�I�v�V�����L��
        private bool _isOptSection;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc;

        private string _SalesTableDataTable;

        SortedList _salesFormalList;
        SortedList _salesSlipKindList;

        // �G�N�X�v���[���o�[�g������
        private Form _topForm = null;

        private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();		//�����N���X(�O������ێ��p)
        private ExtrInfo_PMKAK02034E _chart_ExtrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();		//�����N���X(�`���[�g���n���p)
        private DataSet _printBuffDataSet = null;

        /// <summary>�͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();

        /// <summary>
        /// �͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g���擾���܂��B
        /// </summary>
        /// <value>�͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }

        /// <summary>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _printDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// ���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper PrintDailyFooterRadioKeyPressHelper
        {
            get { return _printDailyFooterRadioKeyPressHelper; }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMKAK02030UA";
        // �v���O����ID
        private const string ct_PGID = "PMKAK02030U";
        // ���[����
        private const string ct_PrintName = "�d���ԕi�\��ꗗ�\";
        // ���[�L�[	
        private const string ct_PrintKey = "1b038c00-51d9-4964-a156-7fd9a3340233";

        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";


        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";			// �\�[�g��
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        private const string ct_ExBarGroupNm_BuyPrintGroup = "BuyPrintGroup";                   // ���|����ݒ�

        // �G�N�X�v���[���[�o�[�̕\����Ԃ����肷�邽�߂̊�ƂȂ�g�b�v�t�H�[���̍���
        private const int CT_TOPFORM_BASE_HEIGHT = 768;
        #endregion

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------

        #endregion �� Interface member
        #endregion

        // ===================================================================================== //
        // IPrintConditionInpType �����o
        // ===================================================================================== //
        #region IPrintConditionInpType �����o
        /// <summary>
        /// ����{�^���L�������v���p�e�B
        /// </summary>
        public bool CanPrint
        {
            get
            {
                return _printButtonEnabled;
            }
        }

        /// <summary>
        /// ���o�{�^���L�������v���p�e�B
        /// </summary>
        public bool CanExtract
        {
            get
            {
                return _extraButtonEnabled;
            }
        }

        /// <summary>
        /// PDF�{�^���L�������v���p�e�B
        /// </summary>
        public bool CanPdf
        {
            get
            {
                return _pdfButtonEnabled;
            }
        }

        /// <summary>
        /// ����{�^���\���v���p�e�B
        /// </summary>
        public bool VisibledPrintButton
        {
            get
            {
                return _printButtonVisibled;
            }
        }

        /// <summary>
        /// ���o�{�^���\���v���p�e�B
        /// </summary>
        public bool VisibledExtractButton
        {
            get
            {
                return _extraButtonVisibled;
            }
        }

        /// <summary>
        /// PDF�{�^���\���v���p�e�B
        /// </summary>
        public bool VisibledPdfButton
        {
            get
            {
                return _pdfButtonVisibled;
            }
        }

        // ===================================================================================== //
        // IPrintConditionInpTypeCondition �����o
        // ===================================================================================== //
        /// <summary>
        /// �`���[�g�p���o�����ݒ�
        /// </summary>
        public object ObjExtract
        {
            get
            {
                return _chartExtrInfo_PMKAK02034E;
            }
        }

        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion
        /// <summary>
        /// �c�[���o�[�\������C�x���g
        /// </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;


        /// <summary>
        /// Control.Show�̃I�[�o�[���[�h
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ����������s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public int Print(ref object parameter)
        {

            SFCMN06001U printDialog = new SFCMN06001U();			// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	  // ������p�����[�^

            // ��ƃR�[�h
            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            printInfo.kidopgid = ct_PGID;			  // �N���o�f�h�c
            printInfo.key = ct_PrintKey;				 // PDF�����Ǘ��pKEY���

            // ��ʁ����o�����N���X
            ExtrInfo_PMKAK02034E extrInfo_PMKAK02034E = new ExtrInfo_PMKAK02034E();
            this.SetExtraInfoFromScreen(out extrInfo_PMKAK02034E);

            // ���o�����̐ݒ�
            printInfo.jyoken = extrInfo_PMKAK02034E;

            printInfo.PrintPaperSetCd = 0;

            printInfo.rdData = this._printBuffDataSet;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = (Object)printInfo;

            return printInfo.status;
        }

        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: FSI���� ����</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
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
        // IPrintConditionInpTypePdfCareer �����o
        // ===================================================================================== //
        #region IPrintConditionInpTypePdfCareer �����o
        /// <summary>���[KEY�v���p�e�B</summary>
        /// <remarks>���[�̏o�͗����擾�p��KEY�l���擾���܂��B</remarks>
        public string PrintKey
        {
            get
            {
                return ct_PrintKey;
            }
        }

        /// <summary>���[���v���p�e�B</summary>
        /// <remarks>���[�����擾���܂��B</remarks>
        public string PrintName
        {
            get
            {
                return ct_PrintName;
            }
        }
        #endregion

        // ===================================================================================== //
        // ���C��
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKAK02030UA());
        }
        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private methods
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            #region < ���t�͈� >
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            this.InputDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;// �V�X�e�����t
            this.InputDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;// �V�X�e�����t
            this.InputDaySt_tDateEdit.SetLongDate(nowLongDate);
            this.InputDayEd_tDateEdit.SetLongDate(nowLongDate);
            #endregion

            #region < ���_ >
            this.NewPageType_tComboEditor.Value = 0;    // ���_
            #endregion

            #region < ���t�w�� >
            this.SpecifyDate_ultraOptionSet.Value = 0;  // �`�[���t
            #endregion

            #region < �o�͎w�� >
            this.SlipDiv_tComboEditor.Value = 2;        // ���ׂ�
            #endregion

            #region < ���s�^�C�v >
            this.MakeShowDiv_tComboEditor.Value = 0;    // �ʏ�
            #endregion

            this.InputDaySt_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // �Ώۓ�From
            this.InputDayEd_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // �Ώۓ�To

        }


        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion

        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "����͂��ĉ�����";
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // �������i�J�n�E�I���j
            if (CallCheckDateRange(out cdrResult, ref InputDaySt_tDateEdit, ref InputDayEd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώۓ�{0}", ct_NoInput);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώۓ�{0}", ct_InputError);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώۓ�{0}", ct_NoInput);
                            errComponent = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώۓ�{0}", ct_InputError);
                            errComponent = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۓ�{0}", ct_RangeError);
                            errComponent = this.InputDaySt_tDateEdit;
                        }
                        break;
                }
                status = false;
            }

            // �d����
            if ((this.tNedit_SupplierCd_Ed.GetInt() != 0) && (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("�d����{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }

            return status;
        }
        #endregion

        /// <summary>
        /// ���t�͈̓`�F�b�N�Ăяo��
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            cdrResult = this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        #region �� �N�����̓`�F�b�N����
        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
            // �P�����t�Ó����`�F�b�N
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

            // ���o�������ς���Ă���Ȃ烊���[�e�B���O
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
                    // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
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
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(out ExtrInfo_PMKAK02034E extraInfo)
        {
            extraInfo = new ExtrInfo_PMKAK02034E();

            #region < ��ƃR�[�h >
            extraInfo.EnterpriseCode = this._enterpriseCode;
            #endregion

            #region < �I�����_ >
            // ���_�I�v�V��������̂Ƃ�
            if (IsOptSection)
            {
                ArrayList secList = new ArrayList();
                // �S�БI�����ǂ���
                if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
                {

                    //A�N���XSearchParaSet()�Łg�S�Ђ̏ꍇ�h��if���ɓ��邽�߂̏���
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
            // ���_�I�v�V�����Ȃ��̎�
            else
            {
                extraInfo.SectionCodes = new string[0];
                extraInfo.SectionCodes[0] = "0";
            }
            #endregion

            #region < ���t�w�� >
            extraInfo.PrintDailyFooter = Convert.ToInt32(this.SpecifyDate_ultraOptionSet.CheckedItem.DataValue);
            #endregion

            #region < �Ώۓ� >
            // �Ώۓ�(�J�n)
            extraInfo.InputDaySt = this.InputDaySt_tDateEdit.GetLongDate();
            // �Ώۓ�(�I��)
            extraInfo.InputDayEd = this.InputDayEd_tDateEdit.GetLongDate();
            #endregion

            #region < ���� >
            extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageType_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < �d���� >
            // �d����(�J�n)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
            // �d����(�I��)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            #endregion

            #region < �o�͎w�� >
            // �o�͎w��
            extraInfo.SlipDiv = Convert.ToInt32(this.SlipDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.SlipDivName = this.SlipDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

            #region < ���s�^�C�v >
            // ���s�^�C�v
            extraInfo.MakeShowDiv = Convert.ToInt32(this.MakeShowDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.MakeShowDivName = MakeShowDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

        }

        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            _SalesTableDataTable = Broadleaf.Application.UIData.PMKAK02035EA.ct_Tbl_StockRetDtl;
        }

        /// <summary>
        /// �ŏ�ʃt�H�[���擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer  : FSI���� ����</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void GetTopForm()
        {
            // �ŏ�ʂ̐e�R���g���[�����擾����
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
        /// �g�b�v�t�H�[���T�C�Y�ύX�C�x���g
        /// </summary>
        private void TopForm_SizeChanged(object sender, EventArgs e)
        {
            this.AdjustExplorerBarExpand();
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[�W�J��Ԓ���
        /// </summary>
        private void AdjustExplorerBarExpand()
        {

        }

        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note	   : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TDateEdit)
        /// </summary>
        /// <param name="startDate">�J�n���t����TDateEdit</param>
        /// <param name="endDate">�I�����t����TDateEdit</param>
        private void AutoSetEndValue(TDateEdit startDate, TDateEdit endDate)
        {
            if (endDate.LongDate == 0)
            {
                endDate.SetLongDate(startDate.LongDate);
            }
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TEdit)
        /// </summary>
        /// <param name="startEdit">�J�n�����񍀖�TEdit</param>
        /// <param name="endEdit">�I�������񍀖�TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TNedit)
        /// </summary>
        /// <param name="startNedit">�J�n���l����TEdit</param>
        /// <param name="endNedit">�I�����l����TEdit</param>
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
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool GetMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // �{�Ћ@�\���H
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
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region Control Event
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		: ��ʂ����[�h���ꂽ�ہA��������C�x���g�ł��B</br>
        /// <br>Programmer  : FSI���� ����</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void PMKAK02030UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._salesTableListAcs = new PMKAK02032A();

            // �ŏ�ʃt�H�[���擾
            this.GetTopForm();

            // ���_�I�v�V�����L�����擾����
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // �{��/���_�����擾����
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

            // �d����F�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.SupplierCdSt_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));

            // �d����F�I��
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
        /// ��ʃA�N�e�B�u�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note	   : �d���ԕi�\��ꗗ�\���C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void PMKAK02030UA_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// tArrowKey �� tRetKey �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note	   : �R���g���[���ŃL�[��������ăt�H�[�J�X�ړ������Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programer  : FSI���� ����</br>
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
                // �d����From
                if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tNedit_SupplierCd_St.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text) == false))
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    return;
                }
                // �d����To
                if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tNedit_SupplierCd_Ed.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text) == false))
                    {
                        e.NextCtrl = this.SlipDiv_tComboEditor;
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// �����^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note		: �����������s���܂��B</br>
        /// <br>Programmer  : FSI���� ����</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʏ����\��
            this.InitialScreenSetting();

            // �����t�H�[�J�X
            this.InputDaySt_tDateEdit.Focus();

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SetIconImage(this.SupplierCdSt_GuideBtn, Size16_Index.STAR1);
            this.SetIconImage(this.SupplierCdEd_GuideBtn, Size16_Index.STAR1);

            // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
            if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
        }

        /// <summary>
        /// �o�͎w��I���C�x���g
        /// </summary>
        private void OutPutTypeChanged(object sender, EventArgs e)
        {
            //�u�ԕi�ς̂݁v��I�����́u���s�^�C�v�v��I��s�ɂ���
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
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: FSI���� ����</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer	: FSI���� ����</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        #region ���K�C�h�N���C�x���g
        /// <summary>
        /// �d����R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SupplierCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // �C���X�^���X����
                    _supplierAcs = new SupplierAcs();
                }

                // �K�C�h�N��
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // ���ڂɓW�J
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
        /// �d����R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SupplierCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // �C���X�^���X����
                    _supplierAcs = new SupplierAcs();
                }

                // �K�C�h�N��
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // ���ڂɓW�J
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
        // IPrintConditionInpTypeSelectedSection �����o
        // ===================================================================================== //
        #region IPrintConditionInpTypeSelectedSection �����o

        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="checkState">�R���g���[�����</param>
        /// <remarks>
        /// <br>Note	   : ���_��I���������s�Ȃ��܂��B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ��
                if (sectionCode == "0")
                {
                    // �I��I�����X�g���N���A
                    this._selectedhSectinTable.Clear();
                }

                // ���X�g�ɋ��_���ǉ�����Ă��Ȃ����A���_�̏�Ԃ�ǉ�
                if (this._selectedhSectinTable.ContainsKey(sectionCode) == false)
                {
                    this._selectedhSectinTable.Add(sectionCode, checkState);
                }
            }
            // ���_�̑I��������������
            else if (checkState == CheckState.Unchecked)
            {
                // �I�����_���X�g����폜
                if (this._selectedhSectinTable.ContainsKey(sectionCode))
                {
                    this._selectedhSectinTable.Remove(sectionCode);
                }
            }
        }

        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : FSI���� ����</br>
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
                // �I�����_��ǉ�
                this._selectedhSectinTable.Add(sectionCodeLst[ix], CheckState.Checked);
            }
        }

        /// <summary>
        /// ���_�\���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }

        /// <summary>
        /// �v�㋒�_�I��\���擾�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : FSI���� ����</br>
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
        /// ���_�I�v�V�����擾�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���_�I�v�V�����擾�v���p�e�B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary>
        /// �{�Ћ@�\�擾�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �{�Ћ@�\�擾�v���p�e�B</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary>
        /// �v�㋒�_�I������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �v�㋒�_�I������</br>
        /// <br>Programmer : FSI���� ����</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        public void SelectedAddUpCd(int SelectAddUpCd)
        {
            // ���݂̃`�F�b�N����Ă���v�㋒�_����n���B
            this._selectedAddUpCd = SelectAddUpCd;
        }

        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : FSI���� ����</br>
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
        