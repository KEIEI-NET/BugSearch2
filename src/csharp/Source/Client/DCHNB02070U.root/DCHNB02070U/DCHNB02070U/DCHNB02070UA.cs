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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;

using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�E�`���[�g��������t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note	   : ���[�E�`���[�g��������t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 980035 ����@��`</br>
    /// <br>Date	   : 2007.12.07</br>
    /// <br>Update Note: 2008.02.26 20081 �D�c �E�l</br>
    /// <br>			 �EDC.NS�Ή��i���ʏC��:���t�`�F�b�N�A�O���ߑΉ��j</br>
    /// <br>Update Note: 2008.03.05 980035 ���� ��`</br>
    /// <br>			 �E�s��C���iDC.NS�Ή��j</br>
    /// <br>Update Note: 2008.09.08 30452 ��� �r��</br>
    /// <br>			 �EPM.NS�Ή�</br>
    /// <br>Update Note: 2008.12.04 30452 ��� �r��</br>
    /// <br>			 �E��Q�Ή�</br>
    /// <br>Update Note: 2009.02.09 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�11226(�`���[�g�{�^�����\���ɕύX)</br>
    /// <br>Update Note: 2009/02/24 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�11810 �����̏ꍇ�̔N�x�ׂ�`�F�b�N���폜�B�N�x�ׂ�̏ꍇ�A�����Ō�������悤�C���B</br>
    /// <br>           : 2009/03/05       �Ɠc �M�u�@�s��Ή�[12192]</br>
    /// <br>Update Note: 2010/08/12 caowj</br>
    /// <br>             �EPM1012�Ή�</br>
    /// <br>UpdateNote : 2012/12/28 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
    /// <br>UpdateNote : 2013/02/27 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
    /// <br>UpdateNote : 2013/03/08 cheq</br>
    /// <br>�Ǘ��ԍ�   : 10900690-00 2013/03/26�z�M��</br>
    /// <br>           : Redmine#34987 ���[redmine#34098�̎c���̑Ή�</br>
    /// </remarks>
	public class DCHNB02070UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer,
        //IPrintConditionInpTypeChart, // DEL 2009/02/09
        IPrintConditionInpTypeCondition,
        IPrintConditionInpTypeGuidExecuter      // F5�F�K�C�h�̕\����\�� // ADD 2010/08/12
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel DCHNB02070UA_Fill_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private ToolTip toolTip1;
        private UiSetControl uiSetControl1;
        private TComboEditor tComboEditor1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private TNedit tNedit1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private TNedit tNedit2;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private TNedit tNedit3;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Panel OrderPanel1;
        private TComboEditor OrderAppointment_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TNedit OrderRange_Nedit;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet OrderMethod_ultraOptionSet;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet OrderUnit_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Panel CustomerCodePanel1;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private TNedit tNedit_CustomerCode_Ed;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TNedit tNedit_CustomerCode_St;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private Panel PrintOrderPanel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet PrintOrder_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Panel PrintOrderPanel1;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor CrMode2_ultraCheckEditor;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor CrMode1_ultraCheckEditor;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet MoneyUnit_ultraOptionSet;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ConstUnit_ultraOptionSet;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet PrintType_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet TtlType_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TDateEdit TargetDateEd_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit TargetDateSt_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel Date_Title_Label;
        private UiMemInput uiMemInput1;
        private Panel SalesCodePanel;
        private Infragistics.Win.Misc.UltraButton SalesCodeEd_GuideBtn;
        private TNedit tNedit_SalesCode_Ed;
        private Infragistics.Win.Misc.UltraButton SalesCodeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private TNedit tNedit_SalesCode_St;
        private Panel BusinessTypePanel;
        private Infragistics.Win.Misc.UltraButton BusinessTypeEd_GuideBtn;
        private TNedit tNedit_BusinessTypeCode_Ed;
        private Infragistics.Win.Misc.UltraButton BusinessTypeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private TNedit tNedit_BusinessTypeCode_St;
        private Panel SalesAreaPanel;
        private Infragistics.Win.Misc.UltraButton SalesAreaEd_GuideBtn;
        private TNedit tNedit_SalesAreaCode_Ed;
        private Infragistics.Win.Misc.UltraButton SalesAreaSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private TNedit tNedit_SalesAreaCode_St;
        private Panel SalesInputPanel;
        private Infragistics.Win.Misc.UltraButton SalesInputEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesInputSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Panel FrontEmployeePanel;
        private Infragistics.Win.Misc.UltraButton FrontEmployeeEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton FrontEmployeeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private Panel SalesEmployeePanel;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeSt_GuideBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private TEdit tEdit_SalesInputCode_Ed;
        private TEdit tEdit_SalesInputCode_St;
        private TEdit tEdit_FrontEmployeeCode_Ed;
        private TEdit tEdit_FrontEmployeeCode_St;
        private TEdit tEdit_SalesEmployeeCode_Ed;
        private TEdit tEdit_SalesEmployeeCode_St;
		private System.ComponentModel.IContainer components;
        private TComboEditor tComboEditor_LineMaSqOfCh;
        private UltraLabel LineMaSqOfCh_Label;
        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<
		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructer
        /// <summary>
        /// ���㌎��N��UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���㌎��N��UI�N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
        /// <br></br>
        /// </remarks>
        public DCHNB02070UA()
		{
			InitializeComponent();

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._salesFormalList = new SortedList();
			this._salesSlipKindList = new SortedList();
            this._companyInfAcs = new CompanyInfAcs();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();   // 2008.02.26 add
            // --- ADD 2008/09/08 -------------------------------->>>>>
            // �]�ƈ��K�C�h�p�A�N�Z�X�N���X
            this._employeeAcs = new EmployeeAcs();
            // ���[�U�[�K�C�h�p�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();
            // --- ADD 2008/09/08 --------------------------------<<<<<

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry= new List<Control>();
            saveCtrAry.Add(this.TtlType_ultraOptionSet);
            //saveCtrAry.Add(this.TargetDateSt_tDateEdit);          //DEL 2009/03/05 �s��Ή�[12192]
            //saveCtrAry.Add(this.TargetDateEd_tDateEdit);          //DEL 2009/03/05 �s��Ή�[12192]
            saveCtrAry.Add(this.PrintType_ultraOptionSet);
            saveCtrAry.Add(this.ConstUnit_ultraOptionSet);
            saveCtrAry.Add(this.MoneyUnit_ultraOptionSet);
            saveCtrAry.Add(this.PrintOder_tComboEditor);
            saveCtrAry.Add(this.PrintOrder_ultraOptionSet);
            // --- DEL 2008/12/05 -------------------------------->>>>>
            //saveCtrAry.Add(this.tNedit_ExtractCode_St);
            //saveCtrAry.Add(this.tNedit_ExtractCode_Ed);
            // --- DEL 2008/12/05 --------------------------------<<<<<
            // --- ADD 2008/12/05 -------------------------------->>>>>
            saveCtrAry.Add(this.tEdit_SalesEmployeeCode_St);
            saveCtrAry.Add(this.tEdit_SalesEmployeeCode_Ed);
            saveCtrAry.Add(this.tEdit_FrontEmployeeCode_St);
            saveCtrAry.Add(this.tEdit_FrontEmployeeCode_Ed);
            saveCtrAry.Add(this.tEdit_SalesInputCode_St);
            saveCtrAry.Add(this.tEdit_SalesInputCode_Ed);
            saveCtrAry.Add(this.tNedit_SalesAreaCode_St);
            saveCtrAry.Add(this.tNedit_SalesAreaCode_Ed);
            saveCtrAry.Add(this.tNedit_BusinessTypeCode_St);
            saveCtrAry.Add(this.tNedit_BusinessTypeCode_Ed);
            saveCtrAry.Add(this.tNedit_SalesCode_St);
            saveCtrAry.Add(this.tNedit_SalesCode_Ed);
            // --- ADD 2008/12/05 --------------------------------<<<<<
            saveCtrAry.Add(this.tNedit_CustomerCode_St);
            saveCtrAry.Add(this.tNedit_CustomerCode_Ed);
            saveCtrAry.Add(this.OrderUnit_ultraOptionSet);
            saveCtrAry.Add(this.OrderMethod_ultraOptionSet);
            saveCtrAry.Add(this.OrderRange_Nedit);
            saveCtrAry.Add(this.OrderAppointment_tComboEditor);
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            saveCtrAry.Add(this.tComboEditor_LineMaSqOfCh);
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
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
        /// <remarks>
        /// <br>UpdateNote : 2013/02/27 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
        /// </remarks>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_LineMaSqOfCh = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.LineMaSqOfCh_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CrMode2_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.CrMode1_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.MoneyUnit_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ConstUnit_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.PrintType_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlType_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDateEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDateSt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Date_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOrderPanel2 = new System.Windows.Forms.Panel();
            this.PrintOrder_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.PrintOrderPanel1 = new System.Windows.Forms.Panel();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.SalesCodePanel = new System.Windows.Forms.Panel();
            this.SalesCodeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_SalesCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesCodeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SalesCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BusinessTypePanel = new System.Windows.Forms.Panel();
            this.BusinessTypeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_BusinessTypeCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BusinessTypeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BusinessTypeCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesAreaPanel = new System.Windows.Forms.Panel();
            this.SalesAreaEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesAreaSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SalesInputPanel = new System.Windows.Forms.Panel();
            this.tEdit_SalesInputCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesInputCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SalesInputEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesInputSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.FrontEmployeePanel = new System.Windows.Forms.Panel();
            this.tEdit_FrontEmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_FrontEmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.FrontEmployeeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.FrontEmployeeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeePanel = new System.Windows.Forms.Panel();
            this.tEdit_SalesEmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesEmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SalesEmployeeEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCodePanel1 = new System.Windows.Forms.Panel();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.OrderPanel1 = new System.Windows.Forms.Panel();
            this.OrderAppointment_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.OrderRange_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.OrderMethod_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.OrderUnit_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.DCHNB02070UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tComboEditor1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraOptionSet1 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraOptionSet2 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LineMaSqOfCh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyUnit_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstUnit_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintType_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlType_ultraOptionSet)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            this.PrintOrderPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOrder_ultraOptionSet)).BeginInit();
            this.PrintOrderPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            this.SalesCodePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCode_St)).BeginInit();
            this.BusinessTypePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).BeginInit();
            this.SalesAreaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            this.SalesInputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_St)).BeginInit();
            this.FrontEmployeePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCode_St)).BeginInit();
            this.SalesEmployeePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCode_St)).BeginInit();
            this.CustomerCodePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.OrderPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAppointment_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderRange_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderMethod_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderUnit_ultraOptionSet)).BeginInit();
            this.DCHNB02070UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit3)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_LineMaSqOfCh);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.LineMaSqOfCh_Label);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CrMode2_ultraCheckEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CrMode1_ultraCheckEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.MoneyUnit_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ConstUnit_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.PrintType_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TtlType_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TargetDateEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TargetDateSt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.Date_Title_Label);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(714, 219);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // tComboEditor_LineMaSqOfCh
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LineMaSqOfCh.ActiveAppearance = appearance68;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_LineMaSqOfCh.Appearance = appearance22;
            this.tComboEditor_LineMaSqOfCh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LineMaSqOfCh.ItemAppearance = appearance69;
            this.tComboEditor_LineMaSqOfCh.LimitToList = true;
            //this.tComboEditor_LineMaSqOfCh.Location = new System.Drawing.Point(178, 190);// DEL ���N 2013/02/27 Redmine#33741 
            this.tComboEditor_LineMaSqOfCh.Location = new System.Drawing.Point(178, 160);// ADD ���N 2013/02/27 Redmine#33741 
            this.tComboEditor_LineMaSqOfCh.Name = "tComboEditor_LineMaSqOfCh";
            this.tComboEditor_LineMaSqOfCh.Size = new System.Drawing.Size(125, 24);
            this.tComboEditor_LineMaSqOfCh.TabIndex = 12;
            // 
            // LineMaSqOfCh_Label
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.LineMaSqOfCh_Label.Appearance = appearance26;
            //this.LineMaSqOfCh_Label.Location = new System.Drawing.Point(24, 190);// DEL ���N 2013/02/27 Redmine#34098
            this.LineMaSqOfCh_Label.Location = new System.Drawing.Point(24, 160);// ADD ���N 2013/02/27 Redmine#34098
            this.LineMaSqOfCh_Label.Name = "LineMaSqOfCh_Label";
            this.LineMaSqOfCh_Label.Size = new System.Drawing.Size(122, 23);
            this.LineMaSqOfCh_Label.TabIndex = 15;
            this.LineMaSqOfCh_Label.Text = "�r����";
            // 
            // CrMode2_ultraCheckEditor
            // 
            this.CrMode2_ultraCheckEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //this.CrMode2_ultraCheckEditor.Location = new System.Drawing.Point(355, 159);// DEL ���N 2013/02/27 Redmine#33741
            this.CrMode2_ultraCheckEditor.Location = new System.Drawing.Point(355, 190);// ADD ���N 2013/02/27 Redmine#33741
            this.CrMode2_ultraCheckEditor.Name = "CrMode2_ultraCheckEditor";
            this.CrMode2_ultraCheckEditor.Size = new System.Drawing.Size(150, 24);
            this.CrMode2_ultraCheckEditor.TabIndex = 14;
            this.CrMode2_ultraCheckEditor.Text = "�S���Җ��ŉ���";
            this.CrMode2_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.CrMode2_ultraCheckEditor_CheckedChanged);
            // 
            // CrMode1_ultraCheckEditor
            // 
            this.CrMode1_ultraCheckEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //this.CrMode1_ultraCheckEditor.Location = new System.Drawing.Point(178, 160); // DEL ���N 2013/02/27 Redmine#33741 
            this.CrMode1_ultraCheckEditor.Location = new System.Drawing.Point(178, 190); // ADD ���N 2013/02/27 Redmine#33741 
            this.CrMode1_ultraCheckEditor.Name = "CrMode1_ultraCheckEditor";
            this.CrMode1_ultraCheckEditor.Size = new System.Drawing.Size(150, 24);
            this.CrMode1_ultraCheckEditor.TabIndex = 13;
            this.CrMode1_ultraCheckEditor.Text = "���_���ŉ���";
            this.CrMode1_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.CrMode1_ultraCheckEditor_CheckedChanged);
            // 
            // MoneyUnit_ultraOptionSet
            // 
            this.MoneyUnit_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.MoneyUnit_ultraOptionSet.CheckedIndex = 0;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "�~";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "��~";
            this.MoneyUnit_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.MoneyUnit_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.MoneyUnit_ultraOptionSet.Location = new System.Drawing.Point(178, 133);
            this.MoneyUnit_ultraOptionSet.Name = "MoneyUnit_ultraOptionSet";
            this.MoneyUnit_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.MoneyUnit_ultraOptionSet.TabIndex = 11;
            this.MoneyUnit_ultraOptionSet.Text = "�~";
            this.MoneyUnit_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoneyUnit_ultraOptionSet_KeyDown);
            // 
            // ConstUnit_ultraOptionSet
            // 
            this.ConstUnit_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ConstUnit_ultraOptionSet.CheckedIndex = 0;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "�����v";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "���v";
            this.ConstUnit_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.ConstUnit_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.ConstUnit_ultraOptionSet.Location = new System.Drawing.Point(178, 103);
            this.ConstUnit_ultraOptionSet.Name = "ConstUnit_ultraOptionSet";
            this.ConstUnit_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.ConstUnit_ultraOptionSet.TabIndex = 9;
            this.ConstUnit_ultraOptionSet.Text = "�����v";
            this.ConstUnit_ultraOptionSet.Visible = false;
            this.ConstUnit_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConstUnit_ultraOptionSet_KeyDown);
            // 
            // PrintType_ultraOptionSet
            // 
            this.PrintType_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.PrintType_ultraOptionSet.CheckedIndex = 2;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "����";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "����";
            valueListItem7.DataValue = 2;
            valueListItem7.DisplayText = "����������";
            this.PrintType_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.PrintType_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.PrintType_ultraOptionSet.Location = new System.Drawing.Point(178, 73);
            this.PrintType_ultraOptionSet.Name = "PrintType_ultraOptionSet";
            this.PrintType_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.PrintType_ultraOptionSet.TabIndex = 7;
            this.PrintType_ultraOptionSet.Text = "����������";
            this.PrintType_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintType_ultraOptionSet_KeyDown);
            // 
            // ultraLabel13
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance4;
            //this.ultraLabel13.Location = new System.Drawing.Point(24, 160); // DEL ���N 2013/02/27 Redmine#34098
            this.ultraLabel13.Location = new System.Drawing.Point(24, 190); // ADD ���N 2013/02/27 Redmine#34098
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel13.TabIndex = 12;
            this.ultraLabel13.Text = "����";
            // 
            // ultraLabel8
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance5;
            this.ultraLabel8.Location = new System.Drawing.Point(24, 130);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel8.TabIndex = 10;
            this.ultraLabel8.Text = "���z�P��";
            // 
            // ultraLabel6
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance6;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 100);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel6.TabIndex = 8;
            this.ultraLabel6.Text = "�\����P��";
            // 
            // ultraLabel4
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance7;
            this.ultraLabel4.Location = new System.Drawing.Point(24, 70);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 6;
            this.ultraLabel4.Text = "����^�C�v";
            // 
            // TtlType_ultraOptionSet
            // 
            this.TtlType_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.TtlType_ultraOptionSet.CheckedIndex = 1;
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "�S��";
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "���_��";
            this.TtlType_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.TtlType_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.TtlType_ultraOptionSet.Location = new System.Drawing.Point(178, 13);
            this.TtlType_ultraOptionSet.Name = "TtlType_ultraOptionSet";
            this.TtlType_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.TtlType_ultraOptionSet.TabIndex = 1;
            this.TtlType_ultraOptionSet.Text = "���_��";
            this.TtlType_ultraOptionSet.ValueChanged += new System.EventHandler(this.TtlType_ultraOptionSet_ValueChanged);
            this.TtlType_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TtlType_ultraOptionSet_KeyDown);
            // 
            // ultraLabel16
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance9;
            this.ultraLabel16.Location = new System.Drawing.Point(24, 10);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel16.TabIndex = 0;
            this.ultraLabel16.Text = "�W�v���@";
            // 
            // TargetDateEd_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TargetDateEd_tDateEdit.ActiveEditAppearance = appearance10;
            this.TargetDateEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TargetDateEd_tDateEdit.CalendarDisp = true;
            this.TargetDateEd_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.TargetDateEd_tDateEdit.EditAppearance = appearance11;
            this.TargetDateEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TargetDateEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.TargetDateEd_tDateEdit.LabelAppearance = appearance12;
            this.TargetDateEd_tDateEdit.Location = new System.Drawing.Point(355, 40);
            this.TargetDateEd_tDateEdit.Name = "TargetDateEd_tDateEdit";
            this.TargetDateEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TargetDateEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TargetDateEd_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.TargetDateEd_tDateEdit.TabIndex = 5;
            this.TargetDateEd_tDateEdit.TabStop = true;
            this.TargetDateEd_tDateEdit.Leave += new System.EventHandler(this.TargetDateEd_tDateEdit_Leave);
            // 
            // ultraLabel10
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance13;
            this.ultraLabel10.Location = new System.Drawing.Point(320, 40);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 4;
            this.ultraLabel10.Text = "�`";
            // 
            // TargetDateSt_tDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TargetDateSt_tDateEdit.ActiveEditAppearance = appearance14;
            this.TargetDateSt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TargetDateSt_tDateEdit.CalendarDisp = true;
            this.TargetDateSt_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.TargetDateSt_tDateEdit.EditAppearance = appearance15;
            this.TargetDateSt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TargetDateSt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.TargetDateSt_tDateEdit.LabelAppearance = appearance16;
            this.TargetDateSt_tDateEdit.Location = new System.Drawing.Point(178, 40);
            this.TargetDateSt_tDateEdit.Name = "TargetDateSt_tDateEdit";
            this.TargetDateSt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TargetDateSt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TargetDateSt_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.TargetDateSt_tDateEdit.TabIndex = 3;
            this.TargetDateSt_tDateEdit.TabStop = true;
            this.TargetDateSt_tDateEdit.Leave += new System.EventHandler(this.TargetDateSt_tDateEdit_Leave);
            // 
            // Date_Title_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.Date_Title_Label.Appearance = appearance17;
            this.Date_Title_Label.Location = new System.Drawing.Point(24, 40);
            this.Date_Title_Label.Name = "Date_Title_Label";
            this.Date_Title_Label.Size = new System.Drawing.Size(140, 23);
            this.Date_Title_Label.TabIndex = 2;
            this.Date_Title_Label.Text = "�Ώ۔N��";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOrderPanel2);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOrderPanel1);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 302);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(714, 64);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOrderPanel2
            // 
            this.PrintOrderPanel2.Controls.Add(this.PrintOrder_ultraOptionSet);
            this.PrintOrderPanel2.Controls.Add(this.ultraLabel20);
            this.PrintOrderPanel2.Location = new System.Drawing.Point(13, 35);
            this.PrintOrderPanel2.Name = "PrintOrderPanel2";
            this.PrintOrderPanel2.Size = new System.Drawing.Size(551, 28);
            this.PrintOrderPanel2.TabIndex = 14;
            // 
            // PrintOrder_ultraOptionSet
            // 
            this.PrintOrder_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.PrintOrder_ultraOptionSet.CheckedIndex = 0;
            valueListItem10.DataValue = 0;
            valueListItem10.DisplayText = "�R�[�h";
            valueListItem11.DataValue = 1;
            valueListItem11.DisplayText = "����";
            this.PrintOrder_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.PrintOrder_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.PrintOrder_ultraOptionSet.Location = new System.Drawing.Point(165, 4);
            this.PrintOrder_ultraOptionSet.Name = "PrintOrder_ultraOptionSet";
            this.PrintOrder_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.PrintOrder_ultraOptionSet.TabIndex = 111;
            this.PrintOrder_ultraOptionSet.Text = "�R�[�h";
            this.PrintOrder_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintOrder_ultraOptionSet_KeyDown);
            // 
            // ultraLabel20
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance20;
            this.ultraLabel20.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel20.TabIndex = 110;
            this.ultraLabel20.Text = "�����";
            // 
            // PrintOrderPanel1
            // 
            this.PrintOrderPanel1.Controls.Add(this.PrintOder_tComboEditor);
            this.PrintOrderPanel1.Controls.Add(this.ultraLabel5);
            this.PrintOrderPanel1.Location = new System.Drawing.Point(13, 2);
            this.PrintOrderPanel1.Name = "PrintOrderPanel1";
            this.PrintOrderPanel1.Size = new System.Drawing.Size(550, 31);
            this.PrintOrderPanel1.TabIndex = 13;
            // 
            // PrintOder_tComboEditor
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance8;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance21;
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(165, 3);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(240, 24);
            this.PrintOder_tComboEditor.TabIndex = 101;
            this.PrintOder_tComboEditor.SelectionChanged += new System.EventHandler(this.PrintOder_tComboEditor_SelectionChanged);
            // 
            // ultraLabel5
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance1;
            this.ultraLabel5.Location = new System.Drawing.Point(11, 4);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 100;
            this.ultraLabel5.Text = "�o�͏�";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesCodePanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypePanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaPanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesInputPanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.FrontEmployeePanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeePanel);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCodePanel1);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.OrderPanel1);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 403);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(714, 432);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // SalesCodePanel
            // 
            this.SalesCodePanel.Controls.Add(this.SalesCodeEd_GuideBtn);
            this.SalesCodePanel.Controls.Add(this.tNedit_SalesCode_Ed);
            this.SalesCodePanel.Controls.Add(this.SalesCodeSt_GuideBtn);
            this.SalesCodePanel.Controls.Add(this.ultraLabel31);
            this.SalesCodePanel.Controls.Add(this.ultraLabel32);
            this.SalesCodePanel.Controls.Add(this.tNedit_SalesCode_St);
            this.SalesCodePanel.Location = new System.Drawing.Point(13, 178);
            this.SalesCodePanel.Name = "SalesCodePanel";
            this.SalesCodePanel.Size = new System.Drawing.Size(551, 33);
            this.SalesCodePanel.TabIndex = 20;
            this.SalesCodePanel.Visible = false;
            // 
            // SalesCodeEd_GuideBtn
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesCodeEd_GuideBtn.Appearance = appearance30;
            this.SalesCodeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesCodeEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.SalesCodeEd_GuideBtn.Name = "SalesCodeEd_GuideBtn";
            this.SalesCodeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesCodeEd_GuideBtn.TabIndex = 255;
            this.SalesCodeEd_GuideBtn.TabStop = false;
            this.SalesCodeEd_GuideBtn.Tag = "2";
            this.SalesCodeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesCodeEd_GuideBtn.Click += new System.EventHandler(this.SalesCodeSt_GuideBtn_Click);
            // 
            // tNedit_SalesCode_Ed
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance57.TextHAlignAsString = "Right";
            this.tNedit_SalesCode_Ed.ActiveAppearance = appearance57;
            appearance29.TextHAlignAsString = "Right";
            this.tNedit_SalesCode_Ed.Appearance = appearance29;
            this.tNedit_SalesCode_Ed.AutoSelect = true;
            this.tNedit_SalesCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesCode_Ed.DataText = "";
            this.tNedit_SalesCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tNedit_SalesCode_Ed.MaxLength = 4;
            this.tNedit_SalesCode_Ed.Name = "tNedit_SalesCode_Ed";
            this.tNedit_SalesCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tNedit_SalesCode_Ed.TabIndex = 254;
            // 
            // SalesCodeSt_GuideBtn
            // 
            appearance31.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesCodeSt_GuideBtn.Appearance = appearance31;
            this.SalesCodeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesCodeSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.SalesCodeSt_GuideBtn.Name = "SalesCodeSt_GuideBtn";
            this.SalesCodeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesCodeSt_GuideBtn.TabIndex = 252;
            this.SalesCodeSt_GuideBtn.TabStop = false;
            this.SalesCodeSt_GuideBtn.Tag = "1";
            this.SalesCodeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesCodeSt_GuideBtn.Click += new System.EventHandler(this.SalesCodeSt_GuideBtn_Click);
            // 
            // ultraLabel31
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance32;
            this.ultraLabel31.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel31.TabIndex = 253;
            this.ultraLabel31.Text = "�`";
            // 
            // ultraLabel32
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance33;
            this.ultraLabel32.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel32.TabIndex = 250;
            this.ultraLabel32.Text = "�̔��敪";
            // 
            // tNedit_SalesCode_St
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.TextHAlignAsString = "Right";
            this.tNedit_SalesCode_St.ActiveAppearance = appearance23;
            appearance24.TextHAlignAsString = "Right";
            this.tNedit_SalesCode_St.Appearance = appearance24;
            this.tNedit_SalesCode_St.AutoSelect = true;
            this.tNedit_SalesCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesCode_St.DataText = "";
            this.tNedit_SalesCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesCode_St.Location = new System.Drawing.Point(165, 4);
            this.tNedit_SalesCode_St.MaxLength = 4;
            this.tNedit_SalesCode_St.Name = "tNedit_SalesCode_St";
            this.tNedit_SalesCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesCode_St.Size = new System.Drawing.Size(76, 24);
            this.tNedit_SalesCode_St.TabIndex = 251;
            // 
            // BusinessTypePanel
            // 
            this.BusinessTypePanel.Controls.Add(this.BusinessTypeEd_GuideBtn);
            this.BusinessTypePanel.Controls.Add(this.tNedit_BusinessTypeCode_Ed);
            this.BusinessTypePanel.Controls.Add(this.BusinessTypeSt_GuideBtn);
            this.BusinessTypePanel.Controls.Add(this.ultraLabel29);
            this.BusinessTypePanel.Controls.Add(this.ultraLabel30);
            this.BusinessTypePanel.Controls.Add(this.tNedit_BusinessTypeCode_St);
            this.BusinessTypePanel.Location = new System.Drawing.Point(13, 143);
            this.BusinessTypePanel.Name = "BusinessTypePanel";
            this.BusinessTypePanel.Size = new System.Drawing.Size(551, 33);
            this.BusinessTypePanel.TabIndex = 19;
            this.BusinessTypePanel.Visible = false;
            // 
            // BusinessTypeEd_GuideBtn
            // 
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeEd_GuideBtn.Appearance = appearance34;
            this.BusinessTypeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.BusinessTypeEd_GuideBtn.Name = "BusinessTypeEd_GuideBtn";
            this.BusinessTypeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeEd_GuideBtn.TabIndex = 245;
            this.BusinessTypeEd_GuideBtn.TabStop = false;
            this.BusinessTypeEd_GuideBtn.Tag = "2";
            this.BusinessTypeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeEd_GuideBtn.Click += new System.EventHandler(this.BusinessTypeSt_GuideBtn_Click);
            // 
            // tNedit_BusinessTypeCode_Ed
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance35.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.ActiveAppearance = appearance35;
            appearance36.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.Appearance = appearance36;
            this.tNedit_BusinessTypeCode_Ed.AutoSelect = true;
            this.tNedit_BusinessTypeCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_Ed.DataText = "";
            this.tNedit_BusinessTypeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tNedit_BusinessTypeCode_Ed.MaxLength = 4;
            this.tNedit_BusinessTypeCode_Ed.Name = "tNedit_BusinessTypeCode_Ed";
            this.tNedit_BusinessTypeCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_BusinessTypeCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tNedit_BusinessTypeCode_Ed.TabIndex = 244;
            // 
            // BusinessTypeSt_GuideBtn
            // 
            appearance37.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeSt_GuideBtn.Appearance = appearance37;
            this.BusinessTypeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.BusinessTypeSt_GuideBtn.Name = "BusinessTypeSt_GuideBtn";
            this.BusinessTypeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeSt_GuideBtn.TabIndex = 242;
            this.BusinessTypeSt_GuideBtn.TabStop = false;
            this.BusinessTypeSt_GuideBtn.Tag = "1";
            this.BusinessTypeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeSt_GuideBtn.Click += new System.EventHandler(this.BusinessTypeSt_GuideBtn_Click);
            // 
            // ultraLabel29
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance38;
            this.ultraLabel29.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel29.TabIndex = 243;
            this.ultraLabel29.Text = "�`";
            // 
            // ultraLabel30
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance39;
            this.ultraLabel30.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel30.TabIndex = 240;
            this.ultraLabel30.Text = "�Ǝ�";
            // 
            // tNedit_BusinessTypeCode_St
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.ActiveAppearance = appearance40;
            appearance41.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.Appearance = appearance41;
            this.tNedit_BusinessTypeCode_St.AutoSelect = true;
            this.tNedit_BusinessTypeCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_St.DataText = "";
            this.tNedit_BusinessTypeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_St.Location = new System.Drawing.Point(165, 4);
            this.tNedit_BusinessTypeCode_St.MaxLength = 4;
            this.tNedit_BusinessTypeCode_St.Name = "tNedit_BusinessTypeCode_St";
            this.tNedit_BusinessTypeCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_BusinessTypeCode_St.Size = new System.Drawing.Size(76, 24);
            this.tNedit_BusinessTypeCode_St.TabIndex = 241;
            // 
            // SalesAreaPanel
            // 
            this.SalesAreaPanel.Controls.Add(this.SalesAreaEd_GuideBtn);
            this.SalesAreaPanel.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.SalesAreaPanel.Controls.Add(this.SalesAreaSt_GuideBtn);
            this.SalesAreaPanel.Controls.Add(this.ultraLabel27);
            this.SalesAreaPanel.Controls.Add(this.ultraLabel28);
            this.SalesAreaPanel.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.SalesAreaPanel.Location = new System.Drawing.Point(13, 108);
            this.SalesAreaPanel.Name = "SalesAreaPanel";
            this.SalesAreaPanel.Size = new System.Drawing.Size(551, 33);
            this.SalesAreaPanel.TabIndex = 18;
            this.SalesAreaPanel.Visible = false;
            // 
            // SalesAreaEd_GuideBtn
            // 
            appearance42.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaEd_GuideBtn.Appearance = appearance42;
            this.SalesAreaEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.SalesAreaEd_GuideBtn.Name = "SalesAreaEd_GuideBtn";
            this.SalesAreaEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaEd_GuideBtn.TabIndex = 235;
            this.SalesAreaEd_GuideBtn.TabStop = false;
            this.SalesAreaEd_GuideBtn.Tag = "2";
            this.SalesAreaEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaEd_GuideBtn.Click += new System.EventHandler(this.SalesAreaSt_GuideBtn_Click);
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance43;
            appearance44.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance44;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 4;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 234;
            // 
            // SalesAreaSt_GuideBtn
            // 
            appearance45.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaSt_GuideBtn.Appearance = appearance45;
            this.SalesAreaSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.SalesAreaSt_GuideBtn.Name = "SalesAreaSt_GuideBtn";
            this.SalesAreaSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaSt_GuideBtn.TabIndex = 232;
            this.SalesAreaSt_GuideBtn.TabStop = false;
            this.SalesAreaSt_GuideBtn.Tag = "1";
            this.SalesAreaSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaSt_GuideBtn.Click += new System.EventHandler(this.SalesAreaSt_GuideBtn_Click);
            // 
            // ultraLabel27
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance46;
            this.ultraLabel27.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 233;
            this.ultraLabel27.Text = "�`";
            // 
            // ultraLabel28
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance47;
            this.ultraLabel28.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel28.TabIndex = 230;
            this.ultraLabel28.Text = "�n��";
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance54;
            appearance55.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance55;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(165, 4);
            this.tNedit_SalesAreaCode_St.MaxLength = 4;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(76, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 231;
            // 
            // SalesInputPanel
            // 
            this.SalesInputPanel.Controls.Add(this.tEdit_SalesInputCode_Ed);
            this.SalesInputPanel.Controls.Add(this.tEdit_SalesInputCode_St);
            this.SalesInputPanel.Controls.Add(this.SalesInputEd_GuideBtn);
            this.SalesInputPanel.Controls.Add(this.SalesInputSt_GuideBtn);
            this.SalesInputPanel.Controls.Add(this.ultraLabel25);
            this.SalesInputPanel.Controls.Add(this.ultraLabel26);
            this.SalesInputPanel.Location = new System.Drawing.Point(13, 73);
            this.SalesInputPanel.Name = "SalesInputPanel";
            this.SalesInputPanel.Size = new System.Drawing.Size(551, 33);
            this.SalesInputPanel.TabIndex = 17;
            this.SalesInputPanel.Visible = false;
            // 
            // tEdit_SalesInputCode_Ed
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode_Ed.ActiveAppearance = appearance62;
            appearance63.TextHAlignAsString = "Left";
            this.tEdit_SalesInputCode_Ed.Appearance = appearance63;
            this.tEdit_SalesInputCode_Ed.AutoSelect = true;
            this.tEdit_SalesInputCode_Ed.DataText = "";
            this.tEdit_SalesInputCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SalesInputCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tEdit_SalesInputCode_Ed.MaxLength = 4;
            this.tEdit_SalesInputCode_Ed.Name = "tEdit_SalesInputCode_Ed";
            this.tEdit_SalesInputCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tEdit_SalesInputCode_Ed.TabIndex = 224;
            // 
            // tEdit_SalesInputCode_St
            // 
            appearance118.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode_St.ActiveAppearance = appearance118;
            appearance119.TextHAlignAsString = "Left";
            this.tEdit_SalesInputCode_St.Appearance = appearance119;
            this.tEdit_SalesInputCode_St.AutoSelect = true;
            this.tEdit_SalesInputCode_St.DataText = "";
            this.tEdit_SalesInputCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SalesInputCode_St.Location = new System.Drawing.Point(165, 4);
            this.tEdit_SalesInputCode_St.MaxLength = 4;
            this.tEdit_SalesInputCode_St.Name = "tEdit_SalesInputCode_St";
            this.tEdit_SalesInputCode_St.Size = new System.Drawing.Size(76, 24);
            this.tEdit_SalesInputCode_St.TabIndex = 221;
            // 
            // SalesInputEd_GuideBtn
            // 
            appearance56.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesInputEd_GuideBtn.Appearance = appearance56;
            this.SalesInputEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesInputEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.SalesInputEd_GuideBtn.Name = "SalesInputEd_GuideBtn";
            this.SalesInputEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesInputEd_GuideBtn.TabIndex = 225;
            this.SalesInputEd_GuideBtn.TabStop = false;
            this.SalesInputEd_GuideBtn.Tag = "2";
            this.SalesInputEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesInputEd_GuideBtn.Click += new System.EventHandler(this.SalesInputSt_GuideBtn_Click);
            // 
            // SalesInputSt_GuideBtn
            // 
            appearance59.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesInputSt_GuideBtn.Appearance = appearance59;
            this.SalesInputSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesInputSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.SalesInputSt_GuideBtn.Name = "SalesInputSt_GuideBtn";
            this.SalesInputSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesInputSt_GuideBtn.TabIndex = 222;
            this.SalesInputSt_GuideBtn.TabStop = false;
            this.SalesInputSt_GuideBtn.Tag = "1";
            this.SalesInputSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesInputSt_GuideBtn.Click += new System.EventHandler(this.SalesInputSt_GuideBtn_Click);
            // 
            // ultraLabel25
            // 
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance60;
            this.ultraLabel25.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 223;
            this.ultraLabel25.Text = "�`";
            // 
            // ultraLabel26
            // 
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance61;
            this.ultraLabel26.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel26.TabIndex = 220;
            this.ultraLabel26.Text = "���s��";
            // 
            // FrontEmployeePanel
            // 
            this.FrontEmployeePanel.Controls.Add(this.tEdit_FrontEmployeeCode_Ed);
            this.FrontEmployeePanel.Controls.Add(this.tEdit_FrontEmployeeCode_St);
            this.FrontEmployeePanel.Controls.Add(this.FrontEmployeeEd_GuideBtn);
            this.FrontEmployeePanel.Controls.Add(this.FrontEmployeeSt_GuideBtn);
            this.FrontEmployeePanel.Controls.Add(this.ultraLabel23);
            this.FrontEmployeePanel.Controls.Add(this.ultraLabel24);
            this.FrontEmployeePanel.Location = new System.Drawing.Point(13, 38);
            this.FrontEmployeePanel.Name = "FrontEmployeePanel";
            this.FrontEmployeePanel.Size = new System.Drawing.Size(551, 33);
            this.FrontEmployeePanel.TabIndex = 16;
            this.FrontEmployeePanel.Visible = false;
            // 
            // tEdit_FrontEmployeeCode_Ed
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FrontEmployeeCode_Ed.ActiveAppearance = appearance111;
            appearance112.TextHAlignAsString = "Left";
            this.tEdit_FrontEmployeeCode_Ed.Appearance = appearance112;
            this.tEdit_FrontEmployeeCode_Ed.AutoSelect = true;
            this.tEdit_FrontEmployeeCode_Ed.DataText = "";
            this.tEdit_FrontEmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_FrontEmployeeCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tEdit_FrontEmployeeCode_Ed.MaxLength = 4;
            this.tEdit_FrontEmployeeCode_Ed.Name = "tEdit_FrontEmployeeCode_Ed";
            this.tEdit_FrontEmployeeCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tEdit_FrontEmployeeCode_Ed.TabIndex = 214;
            // 
            // tEdit_FrontEmployeeCode_St
            // 
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FrontEmployeeCode_St.ActiveAppearance = appearance120;
            appearance121.TextHAlignAsString = "Left";
            this.tEdit_FrontEmployeeCode_St.Appearance = appearance121;
            this.tEdit_FrontEmployeeCode_St.AutoSelect = true;
            this.tEdit_FrontEmployeeCode_St.DataText = "";
            this.tEdit_FrontEmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_FrontEmployeeCode_St.Location = new System.Drawing.Point(165, 4);
            this.tEdit_FrontEmployeeCode_St.MaxLength = 4;
            this.tEdit_FrontEmployeeCode_St.Name = "tEdit_FrontEmployeeCode_St";
            this.tEdit_FrontEmployeeCode_St.Size = new System.Drawing.Size(76, 24);
            this.tEdit_FrontEmployeeCode_St.TabIndex = 211;
            // 
            // FrontEmployeeEd_GuideBtn
            // 
            appearance64.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.FrontEmployeeEd_GuideBtn.Appearance = appearance64;
            this.FrontEmployeeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.FrontEmployeeEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.FrontEmployeeEd_GuideBtn.Name = "FrontEmployeeEd_GuideBtn";
            this.FrontEmployeeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.FrontEmployeeEd_GuideBtn.TabIndex = 215;
            this.FrontEmployeeEd_GuideBtn.TabStop = false;
            this.FrontEmployeeEd_GuideBtn.Tag = "2";
            this.FrontEmployeeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.FrontEmployeeEd_GuideBtn.Click += new System.EventHandler(this.FrontEmployeeSt_GuideBtn_Click);
            // 
            // FrontEmployeeSt_GuideBtn
            // 
            appearance82.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.FrontEmployeeSt_GuideBtn.Appearance = appearance82;
            this.FrontEmployeeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.FrontEmployeeSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.FrontEmployeeSt_GuideBtn.Name = "FrontEmployeeSt_GuideBtn";
            this.FrontEmployeeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.FrontEmployeeSt_GuideBtn.TabIndex = 212;
            this.FrontEmployeeSt_GuideBtn.TabStop = false;
            this.FrontEmployeeSt_GuideBtn.Tag = "1";
            this.FrontEmployeeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.FrontEmployeeSt_GuideBtn.Click += new System.EventHandler(this.FrontEmployeeSt_GuideBtn_Click);
            // 
            // ultraLabel23
            // 
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance83;
            this.ultraLabel23.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel23.TabIndex = 213;
            this.ultraLabel23.Text = "�`";
            // 
            // ultraLabel24
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance84;
            this.ultraLabel24.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel24.TabIndex = 210;
            this.ultraLabel24.Text = "�󒍎�";
            // 
            // SalesEmployeePanel
            // 
            this.SalesEmployeePanel.Controls.Add(this.tEdit_SalesEmployeeCode_Ed);
            this.SalesEmployeePanel.Controls.Add(this.tEdit_SalesEmployeeCode_St);
            this.SalesEmployeePanel.Controls.Add(this.SalesEmployeeEd_GuideBtn);
            this.SalesEmployeePanel.Controls.Add(this.SalesEmployeeSt_GuideBtn);
            this.SalesEmployeePanel.Controls.Add(this.ultraLabel21);
            this.SalesEmployeePanel.Controls.Add(this.ultraLabel22);
            this.SalesEmployeePanel.Location = new System.Drawing.Point(13, 3);
            this.SalesEmployeePanel.Name = "SalesEmployeePanel";
            this.SalesEmployeePanel.Size = new System.Drawing.Size(551, 33);
            this.SalesEmployeePanel.TabIndex = 15;
            this.SalesEmployeePanel.Visible = false;
            // 
            // tEdit_SalesEmployeeCode_Ed
            // 
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesEmployeeCode_Ed.ActiveAppearance = appearance115;
            appearance116.TextHAlignAsString = "Left";
            this.tEdit_SalesEmployeeCode_Ed.Appearance = appearance116;
            this.tEdit_SalesEmployeeCode_Ed.AutoSelect = true;
            this.tEdit_SalesEmployeeCode_Ed.DataText = "";
            this.tEdit_SalesEmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesEmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SalesEmployeeCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tEdit_SalesEmployeeCode_Ed.MaxLength = 4;
            this.tEdit_SalesEmployeeCode_Ed.Name = "tEdit_SalesEmployeeCode_Ed";
            this.tEdit_SalesEmployeeCode_Ed.Size = new System.Drawing.Size(76, 24);
            this.tEdit_SalesEmployeeCode_Ed.TabIndex = 204;
            // 
            // tEdit_SalesEmployeeCode_St
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesEmployeeCode_St.ActiveAppearance = appearance122;
            appearance123.TextHAlignAsString = "Left";
            this.tEdit_SalesEmployeeCode_St.Appearance = appearance123;
            this.tEdit_SalesEmployeeCode_St.AutoSelect = true;
            this.tEdit_SalesEmployeeCode_St.DataText = "";
            this.tEdit_SalesEmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesEmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SalesEmployeeCode_St.Location = new System.Drawing.Point(165, 4);
            this.tEdit_SalesEmployeeCode_St.MaxLength = 4;
            this.tEdit_SalesEmployeeCode_St.Name = "tEdit_SalesEmployeeCode_St";
            this.tEdit_SalesEmployeeCode_St.Size = new System.Drawing.Size(76, 24);
            this.tEdit_SalesEmployeeCode_St.TabIndex = 201;
            // 
            // SalesEmployeeEd_GuideBtn
            // 
            appearance95.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeEd_GuideBtn.Appearance = appearance95;
            this.SalesEmployeeEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.SalesEmployeeEd_GuideBtn.Name = "SalesEmployeeEd_GuideBtn";
            this.SalesEmployeeEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeEd_GuideBtn.TabIndex = 205;
            this.SalesEmployeeEd_GuideBtn.TabStop = false;
            this.SalesEmployeeEd_GuideBtn.Tag = "2";
            this.SalesEmployeeEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeSt_GuideBtn_Click);
            // 
            // SalesEmployeeSt_GuideBtn
            // 
            appearance98.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeSt_GuideBtn.Appearance = appearance98;
            this.SalesEmployeeSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.SalesEmployeeSt_GuideBtn.Name = "SalesEmployeeSt_GuideBtn";
            this.SalesEmployeeSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeSt_GuideBtn.TabIndex = 202;
            this.SalesEmployeeSt_GuideBtn.TabStop = false;
            this.SalesEmployeeSt_GuideBtn.Tag = "1";
            this.SalesEmployeeSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeSt_GuideBtn_Click);
            // 
            // ultraLabel21
            // 
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance99;
            this.ultraLabel21.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel21.TabIndex = 203;
            this.ultraLabel21.Text = "�`";
            // 
            // ultraLabel22
            // 
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance100;
            this.ultraLabel22.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel22.TabIndex = 200;
            this.ultraLabel22.Text = "�S����";
            // 
            // CustomerCodePanel1
            // 
            this.CustomerCodePanel1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.CustomerCodePanel1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.CustomerCodePanel1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.CustomerCodePanel1.Controls.Add(this.ultraLabel11);
            this.CustomerCodePanel1.Controls.Add(this.ultraLabel3);
            this.CustomerCodePanel1.Controls.Add(this.tNedit_CustomerCode_St);
            this.CustomerCodePanel1.Location = new System.Drawing.Point(13, 213);
            this.CustomerCodePanel1.Name = "CustomerCodePanel1";
            this.CustomerCodePanel1.Size = new System.Drawing.Size(551, 33);
            this.CustomerCodePanel1.TabIndex = 21;
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance85.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance85;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(404, 4);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 265;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "���Ӑ挟��");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance86.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance86;
            appearance87.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance87;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(322, 4);
            this.tNedit_CustomerCode_Ed.MaxLength = 8;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(75, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 264;
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance88.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance88;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(246, 4);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 262;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "���Ӑ挟��");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // ultraLabel11
            // 
            appearance89.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance89;
            this.ultraLabel11.Location = new System.Drawing.Point(291, 5);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 263;
            this.ultraLabel11.Text = "�`";
            // 
            // ultraLabel3
            // 
            appearance90.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance90;
            this.ultraLabel3.Location = new System.Drawing.Point(10, 4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 260;
            this.ultraLabel3.Text = "���Ӑ�";
            // 
            // tNedit_CustomerCode_St
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance91.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance91;
            appearance92.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance92;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(165, 4);
            this.tNedit_CustomerCode_St.MaxLength = 8;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(75, 24);
            this.tNedit_CustomerCode_St.TabIndex = 261;
            // 
            // OrderPanel1
            // 
            this.OrderPanel1.Controls.Add(this.OrderAppointment_tComboEditor);
            this.OrderPanel1.Controls.Add(this.ultraLabel9);
            this.OrderPanel1.Controls.Add(this.ultraLabel7);
            this.OrderPanel1.Controls.Add(this.OrderRange_Nedit);
            this.OrderPanel1.Controls.Add(this.OrderMethod_ultraOptionSet);
            this.OrderPanel1.Controls.Add(this.OrderUnit_ultraOptionSet);
            this.OrderPanel1.Controls.Add(this.ultraLabel2);
            this.OrderPanel1.Location = new System.Drawing.Point(13, 248);
            this.OrderPanel1.Name = "OrderPanel1";
            this.OrderPanel1.Size = new System.Drawing.Size(549, 126);
            this.OrderPanel1.TabIndex = 22;
            // 
            // OrderAppointment_tComboEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderAppointment_tComboEditor.ActiveAppearance = appearance27;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OrderAppointment_tComboEditor.ItemAppearance = appearance48;
            valueListItem12.DataValue = 0;
            valueListItem12.DisplayText = "0:������";
            valueListItem13.DataValue = 1;
            valueListItem13.DisplayText = "1:�e��";
            valueListItem14.DataValue = 2;
            valueListItem14.DisplayText = "2:�ԕi";
            this.OrderAppointment_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem12,
            valueListItem13,
            valueListItem14});
            this.OrderAppointment_tComboEditor.LimitToList = true;
            this.OrderAppointment_tComboEditor.Location = new System.Drawing.Point(165, 96);
            this.OrderAppointment_tComboEditor.Name = "OrderAppointment_tComboEditor";
            this.OrderAppointment_tComboEditor.Size = new System.Drawing.Size(107, 24);
            this.OrderAppointment_tComboEditor.TabIndex = 275;
            // 
            // ultraLabel9
            // 
            appearance49.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance49;
            this.ultraLabel9.Location = new System.Drawing.Point(10, 96);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel9.TabIndex = 274;
            this.ultraLabel9.Text = "���ʎw��";
            // 
            // ultraLabel7
            // 
            appearance50.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance50;
            this.ultraLabel7.Location = new System.Drawing.Point(246, 59);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel7.TabIndex = 15;
            this.ultraLabel7.Text = "�ʂ܂�";
            // 
            // OrderRange_Nedit
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance51.TextHAlignAsString = "Left";
            this.OrderRange_Nedit.ActiveAppearance = appearance51;
            appearance52.TextHAlignAsString = "Right";
            this.OrderRange_Nedit.Appearance = appearance52;
            this.OrderRange_Nedit.AutoSelect = true;
            this.OrderRange_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.OrderRange_Nedit.DataText = "";
            this.OrderRange_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OrderRange_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.OrderRange_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.OrderRange_Nedit.Location = new System.Drawing.Point(165, 58);
            this.OrderRange_Nedit.MaxLength = 7;
            this.OrderRange_Nedit.Name = "OrderRange_Nedit";
            this.OrderRange_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.OrderRange_Nedit.Size = new System.Drawing.Size(66, 24);
            this.OrderRange_Nedit.TabIndex = 273;
            // 
            // OrderMethod_ultraOptionSet
            // 
            this.OrderMethod_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.OrderMethod_ultraOptionSet.CheckedIndex = 0;
            valueListItem15.DataValue = 0;
            valueListItem15.DisplayText = "���";
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "����";
            this.OrderMethod_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem15,
            valueListItem16});
            this.OrderMethod_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.OrderMethod_ultraOptionSet.Location = new System.Drawing.Point(165, 30);
            this.OrderMethod_ultraOptionSet.Name = "OrderMethod_ultraOptionSet";
            this.OrderMethod_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.OrderMethod_ultraOptionSet.TabIndex = 272;
            this.OrderMethod_ultraOptionSet.Text = "���";
            this.OrderMethod_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderMethod_ultraOptionSet_KeyDown);
            // 
            // OrderUnit_ultraOptionSet
            // 
            this.OrderUnit_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.OrderUnit_ultraOptionSet.CheckedIndex = 0;
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "�S��";
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "���v��";
            this.OrderUnit_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18});
            this.OrderUnit_ultraOptionSet.ItemSpacingHorizontal = 10;
            this.OrderUnit_ultraOptionSet.Location = new System.Drawing.Point(165, 3);
            this.OrderUnit_ultraOptionSet.Name = "OrderUnit_ultraOptionSet";
            this.OrderUnit_ultraOptionSet.Size = new System.Drawing.Size(300, 23);
            this.OrderUnit_ultraOptionSet.TabIndex = 271;
            this.OrderUnit_ultraOptionSet.Text = "�S��";
            this.OrderUnit_ultraOptionSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderUnit_ultraOptionSet_KeyDown);
            // 
            // ultraLabel2
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance53;
            this.ultraLabel2.Location = new System.Drawing.Point(10, 3);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel2.TabIndex = 270;
            this.ultraLabel2.Text = "���ʕt���ݒ�";
            // 
            // DCHNB02070UA_Fill_Panel
            // 
            this.DCHNB02070UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.DCHNB02070UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCHNB02070UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.DCHNB02070UA_Fill_Panel.Name = "DCHNB02070UA_Fill_Panel";
            this.DCHNB02070UA_Fill_Panel.Size = new System.Drawing.Size(750, 677);
            this.DCHNB02070UA_Fill_Panel.TabIndex = 0;
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
            appearance73.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance73.FontData.Name = "�l�r �S�V�b�N";
            appearance73.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance73;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance74;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 221;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance75;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 66;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@�\�[�g��";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance76;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 434;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance77.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance77.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance77.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance77;
            appearance78.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance78;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(750, 677);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing_1);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance79.FontData.SizeInPoints = 20F;
            appearance79.TextHAlignAsString = "Center";
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance79;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 560);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.CatchMouse = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ultraButton1
            // 
            appearance65.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ultraButton1.Appearance = appearance65;
            this.ultraButton1.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraButton1.Location = new System.Drawing.Point(423, 13);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(25, 25);
            this.ultraButton1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ultraButton1, "���Ӑ挟��");
            this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraButton2
            // 
            appearance66.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ultraButton2.Appearance = appearance66;
            this.ultraButton2.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ultraButton2.Location = new System.Drawing.Point(265, 12);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(25, 25);
            this.ultraButton2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ultraButton2, "���Ӑ挟��");
            this.ultraButton2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // tComboEditor1
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor1.ActiveAppearance = appearance18;
            this.tComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor1.ItemAppearance = appearance19;
            valueListItem19.DataValue = 0;
            valueListItem19.DisplayText = "������";
            valueListItem20.DataValue = 1;
            valueListItem20.DisplayText = "�e��";
            valueListItem21.DataValue = 2;
            valueListItem21.DisplayText = "�ԕi";
            this.tComboEditor1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem19,
            valueListItem20,
            valueListItem21});
            this.tComboEditor1.LimitToList = true;
            this.tComboEditor1.Location = new System.Drawing.Point(178, 148);
            this.tComboEditor1.Name = "tComboEditor1";
            this.tComboEditor1.Size = new System.Drawing.Size(107, 21);
            this.tComboEditor1.TabIndex = 17;
            // 
            // ultraLabel12
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance3;
            this.ultraLabel12.Location = new System.Drawing.Point(24, 148);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel12.TabIndex = 16;
            this.ultraLabel12.Text = "���ʎw��";
            // 
            // ultraLabel14
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance72;
            this.ultraLabel14.Location = new System.Drawing.Point(260, 111);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel14.TabIndex = 15;
            this.ultraLabel14.Text = "�ʂ܂�";
            // 
            // tNedit1
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance70.TextHAlignAsString = "Left";
            this.tNedit1.ActiveAppearance = appearance70;
            appearance71.TextHAlignAsString = "Right";
            this.tNedit1.Appearance = appearance71;
            this.tNedit1.AutoSelect = true;
            this.tNedit1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit1.DataText = "";
            this.tNedit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit1.Location = new System.Drawing.Point(178, 110);
            this.tNedit1.MaxLength = 7;
            this.tNedit1.Name = "tNedit1";
            this.tNedit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit1.Size = new System.Drawing.Size(74, 21);
            this.tNedit1.TabIndex = 14;
            // 
            // ultraOptionSet1
            // 
            this.ultraOptionSet1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet1.CheckedIndex = 0;
            valueListItem22.DataValue = 0;
            valueListItem22.DisplayText = "���";
            valueListItem23.DataValue = 1;
            valueListItem23.DisplayText = "����";
            this.ultraOptionSet1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem22,
            valueListItem23});
            this.ultraOptionSet1.ItemSpacingHorizontal = 10;
            this.ultraOptionSet1.Location = new System.Drawing.Point(178, 82);
            this.ultraOptionSet1.Name = "ultraOptionSet1";
            this.ultraOptionSet1.Size = new System.Drawing.Size(300, 23);
            this.ultraOptionSet1.TabIndex = 13;
            this.ultraOptionSet1.Text = "���";
            // 
            // ultraOptionSet2
            // 
            this.ultraOptionSet2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet2.CheckedIndex = 0;
            valueListItem24.DataValue = 0;
            valueListItem24.DisplayText = "�S��";
            valueListItem25.DataValue = 1;
            valueListItem25.DisplayText = "���v��";
            this.ultraOptionSet2.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem24,
            valueListItem25});
            this.ultraOptionSet2.ItemSpacingHorizontal = 10;
            this.ultraOptionSet2.Location = new System.Drawing.Point(178, 55);
            this.ultraOptionSet2.Name = "ultraOptionSet2";
            this.ultraOptionSet2.Size = new System.Drawing.Size(300, 23);
            this.ultraOptionSet2.TabIndex = 12;
            this.ultraOptionSet2.Text = "�S��";
            // 
            // ultraLabel15
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance58;
            this.ultraLabel15.Location = new System.Drawing.Point(24, 52);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel15.TabIndex = 6;
            this.ultraLabel15.Text = "���ʕt���ݒ�";
            // 
            // tNedit2
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.TextHAlignAsString = "Left";
            this.tNedit2.ActiveAppearance = appearance67;
            appearance80.TextHAlignAsString = "Right";
            this.tNedit2.Appearance = appearance80;
            this.tNedit2.AutoSelect = true;
            this.tNedit2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit2.DataText = "";
            this.tNedit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit2.Location = new System.Drawing.Point(336, 14);
            this.tNedit2.MaxLength = 9;
            this.tNedit2.Name = "tNedit2";
            this.tNedit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit2.Size = new System.Drawing.Size(82, 21);
            this.tNedit2.TabIndex = 4;
            // 
            // ultraLabel17
            // 
            appearance81.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance81;
            this.ultraLabel17.Location = new System.Drawing.Point(305, 14);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel17.TabIndex = 3;
            this.ultraLabel17.Text = "�`";
            // 
            // ultraLabel18
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance2;
            this.ultraLabel18.Location = new System.Drawing.Point(24, 13);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel18.TabIndex = 0;
            this.ultraLabel18.Text = "���Ӑ�";
            // 
            // tNedit3
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.TextHAlignAsString = "Left";
            this.tNedit3.ActiveAppearance = appearance25;
            appearance28.TextHAlignAsString = "Right";
            this.tNedit3.Appearance = appearance28;
            this.tNedit3.AutoSelect = true;
            this.tNedit3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit3.DataText = "";
            this.tNedit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit3.Location = new System.Drawing.Point(178, 13);
            this.tNedit3.MaxLength = 9;
            this.tNedit3.Name = "tNedit3";
            this.tNedit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit3.Size = new System.Drawing.Size(82, 21);
            this.tNedit3.TabIndex = 1;
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.CustomizeWrite += new Broadleaf.Library.Windows.Forms.CustomizeWriteEventHandler(this.uiMemInput1_CustomizeWrite);
            this.uiMemInput1.CustomizeRead += new Broadleaf.Library.Windows.Forms.CustomizeReadEventHandler(this.uiMemInput1_CustomizeRead);
            // 
            // DCHNB02070UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 677);
            this.Controls.Add(this.DCHNB02070UA_Fill_Panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCHNB02070UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LineMaSqOfCh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyUnit_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstUnit_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintType_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlType_ultraOptionSet)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.PrintOrderPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrintOrder_ultraOptionSet)).EndInit();
            this.PrintOrderPanel1.ResumeLayout(false);
            this.PrintOrderPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.SalesCodePanel.ResumeLayout(false);
            this.SalesCodePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCode_St)).EndInit();
            this.BusinessTypePanel.ResumeLayout(false);
            this.BusinessTypePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).EndInit();
            this.SalesAreaPanel.ResumeLayout(false);
            this.SalesAreaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            this.SalesInputPanel.ResumeLayout(false);
            this.SalesInputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode_St)).EndInit();
            this.FrontEmployeePanel.ResumeLayout(false);
            this.FrontEmployeePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCode_St)).EndInit();
            this.SalesEmployeePanel.ResumeLayout(false);
            this.SalesEmployeePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCode_St)).EndInit();
            this.CustomerCodePanel1.ResumeLayout(false);
            this.CustomerCodePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.OrderPanel1.ResumeLayout(false);
            this.OrderPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAppointment_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderRange_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderMethod_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderUnit_ultraOptionSet)).EndInit();
            this.DCHNB02070UA_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).EndInit();
            this.Main_ultraExplorerBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit3)).EndInit();
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
		private bool _visibledSelectAddUpCd = false;	// �v�㋒�_�I��\���擾

		private int _selectedAddUpCd;

		private string _SalesTableDataTable;

		private Employee _loginWorker = null;
		// �����_�R�[�h
		private string _ownSectionCode = "";
        // �N�����[
        private int _selPrintMode;  // 0:���_�� 1:���Ӑ�� 2:�S���ҕ� 3:������ 4:���[�J�[�� 5:���Ӑ�ʃ��[�J�[�� 6:�n��� 7:�Ǝ��
        private string _selPrintModeName;

        private SalesMonthYearReportCndtn _chartSalesTableListCndtn = null;

		// ���_�A�N�Z�X�N���X
		private static SecInfoAcs _secInfoAcs;
		// ����m�F�\�A�N�Z�X�N���X
		private SalesTableAcs _salesTableListAcs = null;
        // ���Џ��A�N�Z�X�N���X
        private CompanyInfAcs _companyInfAcs;
        private CompanyInf _companyInf;
        //���t�擾���i
        private DateGetAcs _dateGet;   // 2008.02.26 add

		private Hashtable _selectedhSectinTable = new Hashtable();
		// ���_�I�v�V�����L��
		private bool _isOptSection;
		// �{�Ћ@�\�L��
		private bool _isMainOfficeFunc;

		SortedList _salesFormalList;
		SortedList _salesSlipKindList;

		// �G�N�X�v���[���o�[�g������
		private Form _topForm = null;
		private bool _explorerBarExpanding = false;

        private SalesMonthYearReportCndtn _saleConfListCndtnWork = new SalesMonthYearReportCndtn();     //�����N���X(�O������ێ��p)
        private SalesMonthYearReportCndtn _chartSaleConfListCndtn = new SalesMonthYearReportCndtn();    //�����N���X(�`���[�g���n���p)
		private DataSet _printBuffDataSet = null;

        // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //private int _companyBiginDate;
        private int _secMngDiv;
        // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
        //private string _crModeText = "";      // DEL 2008.08.14

        // ���i�`���[�g���o�N���X�����o
        private List<IChartExtract> _iChartExtractList;

        private bool _chartButtonVisibled = true;
        private bool _chartButtonEnabled = true;

        // --- ADD 2008/09/08 -------------------------------->>>>>
        // �]�ƈ��}�X�^�A�N�Z�X
        private EmployeeAcs _employeeAcs;
        // ���[�U�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;
        // --- ADD 2008/09/08 --------------------------------<<<<<

        // ���Ӑ�K�C�h�ݒ萬���t���O
        private bool _customerGuidOK; // ADD 2008/12/04

        // ADD 2009/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
        #region ���W�I�{�^���̃X�y�[�X�L�[����

        /// <summary>�W�v���@���W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _ttlTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// �W�v���@���W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�W�v���@���W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper TtlTypeRadioKeyPressHelper
        {
            get { return _ttlTypeRadioKeyPressHelper; }
        }

        /// <summary>����^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _printTypeRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ����^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>����^�C�v���W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper PrintTypeRadioKeyPressHelper
        {
            get { return _printTypeRadioKeyPressHelper; }
        }

        /// <summary>�\����P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _constUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// �\����P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�\����P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper ConstUnitRadioKeyPressHelper
        {
            get { return _constUnitRadioKeyPressHelper; }
        }

        /// <summary>���z�P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _moneyUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���z�P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���z�P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper MoneyUnitRadioKeyPressHelper
        {
            get { return _moneyUnitRadioKeyPressHelper; }
        }

        /// <summary>��������W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _printOrderRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ��������W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>��������W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper PrintOrderRadioKeyPressHelper
        {
            get { return _printOrderRadioKeyPressHelper; }
        }

        /// <summary>���ʕt���ݒ胉�W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _orderUnitRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���ʕt���ݒ胉�W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���ʕt���ݒ胉�W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper OrderUnitRadioKeyPressHelper
        {
            get { return _orderUnitRadioKeyPressHelper; }
        }

        /// <summary>���ʕt���ݒ�2���W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _orderMethodRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���ʕt���ݒ�2���W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���ʕt���ݒ�2���W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper OrderMethodRadioKeyPressHelper
        {
            get { return _orderMethodRadioKeyPressHelper; }
        }

        #endregion  // ���W�I�{�^���̃X�y�[�X�L�[����
        // ADD 2009/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        private object _preComboEditorValue = null;
        // --- ADD 2010/08/12 ----------------------------------<<<<<
        private object _preComboEditorLineMaSqOfChValue;// ADD zhuhh 2012/12/28 for Redmine #34098

        #endregion

		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		#region private constant
		private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";
        // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private const string EXPLORERBAR_PRINTODERGROUP_KEY = "PrintOderGroup";
        private const string EXPLORERBAR_CUSTOMERCONDITIONGROUP_KEY = "CustomerConditionGroup";
        // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

        private const string THIS_ASSEMBLYID = "DCHNB02070U";
		private const string PDF_PRINT_KEY = "D086E2FA-69C3-4886-98FA-06DF7F43ACAE";
        private const string PDF_PRINT_NAME = "���㌎��N��";

		private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

		// �G�N�X�v���[���[�o�[�̕\����Ԃ����肷�邽�߂̊�ƂȂ�g�b�v�t�H�[���̍���
		private const int CT_TOPFORM_BASE_HEIGHT = 768;

        // --- ADD 2008/09/08 -------------------------------->>>>>
        // �N�����[�ԍ�
        private const int CT_SelPrintMode_Customer = 0;      // ���Ӑ��
        private const int CT_SelPrintMode_SalesEmployee = 1; // �S���ҕ�
        private const int CT_SelPrintMode_FrontEmployee = 2; // �󒍎ҕ�
        private const int CT_SelPrintMode_SalesInput = 3;    // ���s�ҕ�
        private const int CT_SelPrintMode_Area = 4;          // �n���
        private const int CT_SelPrintMode_BusinessType = 5;  // �Ǝ��
        private const int CT_SelPrintMode_SalesDivision = 6; // �̔��敪��

        // �N�����[��
        private const string CT_SelPrintModeName_Customer       = "���Ӑ��";
        private const string CT_SelPrintModeName_SalesEmployee  = "�S���ҕ�";
        private const string CT_SelPrintModeName_FrontEmployee  = "�󒍎ҕ�";
        private const string CT_SelPrintModeName_SalesInput     = "���s�ҕ�";
        private const string CT_SelPrintModeName_Area           = "�n���";
        private const string CT_SelPrintModeName_BusinessType   = "�Ǝ��";
        private const string CT_SelPrintModeName_SalesDivision  = "�̔��敪��";
        // --- ADD 2008/09/08 --------------------------------<<<<<

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
                return this._chartSalesTableListCndtn;
			}
		}

		/// <summary>
		/// �c�[���o�[�\������C�x���g
		/// </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;


		/// <summary>
		/// Control.Show�̃I�[�o�[���[�h
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʕ\�����s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public void Show(object parameter)
		{
            this._selPrintMode = CT_SelPrintMode_Customer;

            #region < �N�����[�h�擾 >

            //�^�`�F�b�N�iString���ǂ����j
            if (parameter is string)
            {
                //�N�����[�h���擾���܂��i0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝ�� 6:�̔��敪�ʁj
                this._selPrintMode = TStrConv.StrToIntDef((string)parameter, 0);
            }

            //�N�����[�h��0�`7�ȊO�̒l�ł���΁A�f�t�H���g(���Ӑ��)�Ƃ���
            if ((this._selPrintMode < CT_SelPrintMode_Customer) && (this._selPrintMode > CT_SelPrintMode_SalesDivision))
            {
                this._selPrintMode = CT_SelPrintMode_Customer;
            }

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = this._selPrintMode.ToString();
            // --- ADD 2008/09/08 --------------------------------<<<<<

            #endregion

            #region < �N�����[�h���̃Z�b�g >
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_Customer;
                        break;
                    }
                case CT_SelPrintMode_SalesEmployee:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_SalesEmployee;
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_FrontEmployee;
                        break;
                    }
                case CT_SelPrintMode_SalesInput:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_SalesInput;
                        break;
                    }
                case CT_SelPrintMode_Area:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_Area;
                        break;
                    }
                case CT_SelPrintMode_BusinessType:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_BusinessType;
                        break;
                    }
                case CT_SelPrintMode_SalesDivision:
                    {
                        this._selPrintModeName = CT_SelPrintModeName_SalesDivision;
                        break;
                    }
            }
            #endregion

            this.Show();
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ����������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public int Print(ref object parameter)
		{

			SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
			SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

			// ��ƃR�[�h
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			printInfo.kidopgid = THIS_ASSEMBLYID;			    // �N���o�f�h�c
			printInfo.key = PDF_PRINT_KEY;				        // PDF�����Ǘ��pKEY���

            #region < �ݒ�R�[�h�Z�b�g >
            /*
            // �N�����[�h�ʂɐݒ�R�[�h���Z�b�g
            switch (this._selPrintMode)
            {
                case 0: // ���_��
                    {
                        printInfo.PrintPaperSetCd = 0;
                        break;
                    }
                case 1: // ���Ӑ��
                    {
                        switch (this.PrintOder_tComboEditor.SelectedIndex)
                        {
                            case 0: // ���Ӑ��
                                {
                                    printInfo.PrintPaperSetCd = 10;
                                    break;
                                }
                            case 1: // �n��ʓ��Ӑ��
                                {
                                    printInfo.PrintPaperSetCd = 20;
                                    break;
                                }
                            case 2: // �Ǝ�ʓ��Ӑ��
                                {
                                    printInfo.PrintPaperSetCd = 30;
                                    break;
                                }
                        }
                        break;
                    }
                case 2: // �S���ҕ�
                    {
                        printInfo.PrintPaperSetCd = 60;
                        break;
                    }
                case 3: // ������
                    {
                        printInfo.PrintPaperSetCd = 70;
                        break;
                    }
                case 4: // ���[�J�[��
                    {
                        printInfo.PrintPaperSetCd = 80;
                        break;
                    }
                case 5: // ���Ӑ�ʃ��[�J�[��
                    {
                        printInfo.PrintPaperSetCd = 90;
                        break;
                    }
                case 6: // �n���
                    {
                        printInfo.PrintPaperSetCd = 40;
                        break;
                    }
                case 7: // �Ǝ��
                    {
                        printInfo.PrintPaperSetCd = 50;
                        break;
                    }
            }
            */
            #endregion

            // 2009.03.19 30413 ���� PDF�t�@�C�����̏C���Ή� >>>>>>START
            printInfo.PrintPaperSetCd = this._selPrintMode;
            // 2009.03.19 30413 ���� PDF�t�@�C�����̏C���Ή� <<<<<<END

            // ��ʁ����o�����N���X
            SalesMonthYearReportCndtn salesTableListCndtnWork;
			this.SetExtraInfoFromScreen(out salesTableListCndtnWork);

			// ���o�����̐ݒ�
			printInfo.jyoken = salesTableListCndtnWork;

			// �f�[�^���o
			//int status = this.SearchData(salesTableListCndtnWork);
			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            //
			//	  return status;
			//}

			printInfo.rdData = this._printBuffDataSet;
			printDialog.PrintInfo = printInfo;

			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			parameter = (Object)printInfo;

			return printInfo.status;
		}

		/// <summary>
		/// ����O�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ����O�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;

			// ��ʂ͈͎̔w�荀�ڂ̓��͕⏕������ǉ�
			this.ScreenInputAssist();

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tKeyControl_ChangeFocus(this, e);
            // --- ADD 2010/08/26 ----------<<<<<
			// ��ʓ��͏����`�F�b�N
			bool result = this.ScreenInputCheack(out message, ref errControl);
			if (!result)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				if (errControl != null) errControl.Focus();
			}
			return result;
		}

		/// <summary>
		/// ���o����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ���o�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
            
			int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            SalesMonthYearReportCndtn extraInfo = new SalesMonthYearReportCndtn();	   // ���o�����N���X

			this.SetExtraInfoFromScreen(out extraInfo);

            // �`���[�g�p�����ݒ�
            _chartSalesTableListCndtn = extraInfo;

			// �f�[�^���o
			status = this.SearchData(extraInfo);
			if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				  this._printBuffDataSet = null;
				  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
			{
				  this._printBuffDataSet = null;
				  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�f�[�^�̒��o�ŃG���[���������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
				return PDF_PRINT_KEY;
			}
		}

		/// <summary>���[���v���p�e�B</summary>
		/// <remarks>���[�����擾���܂��B</remarks>
		public string PrintName
		{
			get
			{
				return PDF_PRINT_NAME;
			}
		}
		#endregion

        // ===================================================================================== //
        // IPrintConditionInpTypeChart �����o
        // ===================================================================================== //
        #region IPrintConditionInpTypeChart �����o
        /// <summary>
        /// �`���[�g�{�^��Enabled����
        /// </summary>
        public bool CanChart
        {
            get { return this._chartButtonEnabled; }
        }

        /// <summary>
        /// �`���[�g�{�^���\������
        /// </summary>
        public bool VisibledChartButton
        {
            get { return this._chartButtonVisibled; }
        }

        /// <summary>
        /// �`���[�g�f�[�^�̒��o�`�F�b�N
        /// </summary>
        public bool CheckBefore()
        {
            // TODO �`���[�g�f�[�^�̒��o�`�F�b�N���s���܂��B
            return true;
        }

        /// <summary>
        /// �`���[�g���o�N���X�����o�擾
        /// </summary>
        /// <param name="chartExtractMemberList"></param>
        /// <returns></returns>
        public int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList)
        {
            try
            {
                string message;
                Control errControl = null;

                // ��ʓ��͏����`�F�b�N
                bool result = this.ChartInputCheack(out message, ref errControl);
                if (result == false)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    if (errControl != null) errControl.Focus();

                    chartExtractMemberList = null;

                    return 9;
                }

                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();

                    AgentOrderChart chartExtract1 = new AgentOrderChart(0);
                    this._iChartExtractList.Add(chartExtract1);

                    AgentOrderChart chartExtract2 = new AgentOrderChart(1);
                    this._iChartExtractList.Add(chartExtract2);
                }

                chartExtractMemberList = this._iChartExtractList;
            }
            finally
            {
            }

            return 0;
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
			System.Windows.Forms.Application.Run(new DCHNB02070UA());
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
        /// </remarks>
		private void InitialScreenSetting()
		{
            #region < ���t�͈� >
            /*  ---ADD 2009/03/05 �s��Ή�[12192] -------------------------------->>>>>
            // 2008.02.26 upd start -------------------------------------->>
            //int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            //this.TargetDateSt_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            //this.TargetDateEd_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            //this.TargetDateSt_tDateEdit.SetLongDate(nowLongDate);
            //this.TargetDateEd_tDateEdit.SetLongDate(nowLongDate);
            // �����N�����擾
            DateTime yearMonth;
            this._dateGet.GetThisYearMonth(out yearMonth);

            this.TargetDateSt_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            this.TargetDateSt_tDateEdit.SetDateTime(yearMonth);
            this.TargetDateEd_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            this.TargetDateEd_tDateEdit.SetDateTime(yearMonth);

            // 2008.02.26 upd end ----------------------------------------<<
               ---ADD 2009/03/05 �s��Ή�[12192] --------------------------------<<<<< */
            // ---ADD 2009/03/05 �s��Ή�[12192] -------------------------------->>>>>
            this.TargetDateSt_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            this.TargetDateEd_tDateEdit.DateFormat = emDateFormat.df4Y2M;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // ���㍡�񌎎��X�V����ݒ�
                this.TargetDateSt_tDateEdit.SetDateTime(currentTotalMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(currentTotalMonth);
            }
            else
            {
                // ������ݒ�
                DateTime nowYearMonth;
                this._dateGet.GetThisYearMonth(out nowYearMonth);

                this.TargetDateSt_tDateEdit.SetDateTime(nowYearMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(nowYearMonth);
            }
            // ---ADD 2009/03/05 �s��Ή�[12192] --------------------------------<<<<<
            #endregion

            #region < �W�v���@ >
            this.TtlType_ultraOptionSet.CheckedIndex = 1;
            #endregion

            #region < ����^�C�v >
            this.PrintType_ultraOptionSet.CheckedIndex = 2;
            #endregion

            #region < �\����P�� >
            this.ConstUnit_ultraOptionSet.CheckedIndex = 0;
            #endregion

            #region < ���z�P�� >
            this.MoneyUnit_ultraOptionSet.CheckedIndex = 0;
            #endregion

            #region < ���� >
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (this._selPrintMode == 0)
            if ( (this._selPrintMode == 0) ||
                ((this._selPrintMode == 3) && (this._secMngDiv == 0)))
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                this.CrMode1_ultraCheckEditor.Checked = false;
            }
            else
            {
            --- DEL 2008/09/08 -------------------------------->>>>> */
            // �u���_���ŉ��Łv�͑I�����
            this.CrMode1_ultraCheckEditor.Checked = true;
            // --- DEL 2008/09/08 -------------------------------->>>>>
            //}
            //--- DEL 2008/09/08 ---------------------------------<<<<<
            //this.CrMode2_ultraCheckEditor.Checked = false;        // DEL 2008.08.14

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // ���ŏ���2
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "���Ӑ斈�ŉ���";
                        break;
                    }
                case CT_SelPrintMode_SalesEmployee:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "�S���Җ��ŉ���";
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "�󒍎Җ��ŉ���";
                        break;
                    }
                case CT_SelPrintMode_SalesInput:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "���s�Җ��ŉ���";
                        break;
                    }
                case CT_SelPrintMode_Area:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "�n�斈�ŉ���";
                        break;
                    }
                case CT_SelPrintMode_BusinessType:
                    {
                        this.CrMode2_ultraCheckEditor.Checked = false;
                        this.CrMode2_ultraCheckEditor.Text = "�Ǝ했�ŉ���";
                        break;
                    }
                default:
                    {
                        // �̔��敪�ʂ̏ꍇ�͕\�����Ȃ��B
                        this.CrMode2_ultraCheckEditor.Visible = false;
                        break;
                    }
            }

            // --- ADD 2008/09/08 --------------------------------<<<<<
            #endregion

            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            #region <�r����>
            this.tComboEditor_LineMaSqOfCh.Items.Clear();
            this.tComboEditor_LineMaSqOfCh.Items.Add(0, "0:�󎚂���");
            this.tComboEditor_LineMaSqOfCh.Items.Add(1, "1:�󎚂��Ȃ�");
            this.tComboEditor_LineMaSqOfCh.Value = 0;
            #endregion
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

            #region < �o�͏� >
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            if (this._selPrintMode == 1)
            {
             �o�͏��͑S�ĕ\��
            this.PrintOder_tComboEditor.Value = 0;
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // �o�͏�comboBox�̐ݒ�
            Infragistics.Win.ValueListItem listItem = new Infragistics.Win.ValueListItem();

            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer: // ���Ӑ��
                    {
                        // ���Ӑ�
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:���Ӑ�|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ������
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 4;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "������";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "4:������";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_SalesEmployee: // �S���ҕ�
                    {
                        // �S����
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�S����";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:�S����";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �S���ҁ|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�S���ҁ|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:�S���ҁ|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_Area: // �n���
                    {
                        // �n��
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�n��";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:�n��";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �n��|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�n��|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:�n��|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_BusinessType: // �Ǝ��
                    {
                        // �Ǝ�
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǝ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:�Ǝ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǝ�|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǝ�|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:�Ǝ�|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_FrontEmployee: // �󒍎ҕ�
                    {
                        // �󒍎�
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�󒍎�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:�󒍎�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �󒍎ҁ|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�󒍎ҁ|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:�󒍎ҁ|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_SalesInput: // ���s�ҕ�
                    {
                        // ���s��
                        listItem.DataValue = 0;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���s��";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "0:���s��";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���Ӑ�
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 1;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���Ӑ�";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "1:���Ӑ�";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // ���s�ҁ|���_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 2;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "���s�ҁ|���_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "2:���s�ҁ|���_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);
                        // �Ǘ����_
                        listItem = new Infragistics.Win.ValueListItem();
                        listItem.DataValue = 3;
                        // --- DEL 2010/08/12 ---------------------------------->>>>>
                        //listItem.DisplayText = "�Ǘ����_";
                        // --- DEL 2010/08/12 ----------------------------------<<<<<
                        // --- ADD 2010/08/12 ---------------------------------->>>>>
                        listItem.DisplayText = "3:�Ǘ����_";
                        // --- ADD 2010/08/12 ----------------------------------<<<<<
                        this.PrintOder_tComboEditor.Items.Add(listItem);

                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪��
                    {
                        // �̔��敪�ʂ̏ꍇ�A�\�����Ȃ�
                        this.PrintOrderPanel1.Visible = false;

                        // �\���ʒu����
                        this.PrintOrderPanel2.Location = new Point(13, 2);
                        this.Main_ultraExplorerBar.Groups[1].Settings.ContainerHeight = 33;

                        break;
                    }
            }

            this.PrintOder_tComboEditor.SelectedIndex = 0;

            // --- ADD 2008/09/08 --------------------------------<<<<<
            #endregion

            #region < �K�C�h�{�^���̃A�C�R���ݒ� >
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/12/05 -------------------------------->>>>>
            SalesEmployeeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            FrontEmployeeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            FrontEmployeeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            FrontEmployeeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            FrontEmployeeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            SalesInputSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesInputSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesInputEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesInputEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            SalesAreaSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesAreaEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            BusinessTypeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            BusinessTypeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            BusinessTypeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            BusinessTypeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            SalesCodeSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesCodeSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesCodeEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesCodeEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/12/05 --------------------------------<<<<<
            // --- DEL 2008/12/05 -------------------------------->>>>>
            //// --- ADD 2008/09/08 -------------------------------->>>>>
            //if (this._selPrintMode != CT_SelPrintMode_Customer)
            //{
            //    ExtractUltraButton1.ImageList = IconResourceManagement.ImageList16;
            //    ExtractUltraButton1.Appearance.Image = Size16_Index.STAR1;
            //    ExtractUltraButton2.ImageList = IconResourceManagement.ImageList16;
            //    ExtractUltraButton2.Appearance.Image = Size16_Index.STAR1;
            //}
            //// --- ADD 2008/09/08 --------------------------------<<<<< 
            // --- DEL 2008/12/05 --------------------------------<<<<<
            //--- DEL 2008.08.14 ---------->>>>>
            //EmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //EmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //EmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //EmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //GoodsMakerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //GoodsMakerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //GoodsMakerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //GoodsMakerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //SalesAreaCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //SalesAreaCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //SalesAreaCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //SalesAreaCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //BusinessTypeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //BusinessTypeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //BusinessTypeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //BusinessTypeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //SectionCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //SectionCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //SectionCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            //SectionCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            //--- DEL 2008.08.14 ----------<<<<<
            #endregion

            #region < ��ʒ��� >
            Point point = new Point();
            point.X = 0;
            point.Y = 7;

            //--- DEL 2008.08.14 ---------->>>>>
            //// ���[�̎�ނɂ�菈���𕪂���
            //switch (this._selPrintMode)
            //{
            //    case 0: // ���_��
            //        {
            //            // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //            ConstUnit_ultraOptionSet.Items.RemoveAt(1);
            //            // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //            break;
            //        }
            //    case 1: // ���Ӑ��
            //        {
            //            this._crModeText = this.CrMode2_ultraCheckEditor.Text;
            //            this.Customer_panel.Location = point;
            //            this.Customer_panel.Visible = true;
            //            break;
            //        }
            //    case 2: // �S���ҕ�
            //        {
            //            this.Employee_panel.Location = point;
            //            this.Employee_panel.Visible = true;

            //            point.Y = point.Y + 30;
            //            this.Customer_panel.Location = point;
            //            this.Customer_panel.Visible = true;
            //            break;
            //        }
            //    case 3: // ������
            //        {
            //            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //            //this.CrMode2_ultraCheckEditor.Text = "����" + this.CrMode2_ultraCheckEditor.Text;
            //            //this.CrMode2_ultraCheckEditor.Visible = true;
            //            if (this._secMngDiv == 0)
            //            {
            //                ConstUnit_ultraOptionSet.Items.RemoveAt(1);
            //            }
            //            else if (this._secMngDiv == 2)
            //            {
            //                this.CrMode2_ultraCheckEditor.Text = "����" + this.CrMode2_ultraCheckEditor.Text;
            //                this.CrMode2_ultraCheckEditor.Visible = true;
            //            }
            //            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<

            //            // 2008.03.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //            //this.Section_panel.Location = point;
            //            //this.Section_panel.Visible = true;
            //            // 2008.03.05 �폜 <<<<<<<<<<<<<<<<<<<<
            //            break;
            //        }
            //    case 4: // ���[�J�[��
            //        {
            //            this.GoodsMaker_panel.Location = point;
            //            this.GoodsMaker_panel.Visible = true;
            //            break;
            //        }
            //    case 5: // ���Ӑ�ʃ��[�J�[��
            //        {
            //            this.CrMode2_ultraCheckEditor.Text = "���Ӑ�" + this.CrMode2_ultraCheckEditor.Text;
            //            this.CrMode2_ultraCheckEditor.Visible = true;

            //            this.Customer_panel.Location = point;
            //            this.Customer_panel.Visible = true;

            //            point.Y = point.Y + 30;
            //            this.GoodsMaker_panel.Location = point;
            //            this.GoodsMaker_panel.Visible = true;
            //            break;
            //        }
            //    case 6: // �n���
            //        {
            //            this.SalesArea_panel.Location = point;
            //            this.SalesArea_panel.Visible = true;

            //            point.Y = point.Y + 30;
            //            this.Customer_panel.Location = point;
            //            this.Customer_panel.Visible = true;
            //            break;
            //        }
            //    case 7: // �Ǝ��
            //        {
            //            this.BusinessType_panel.Location = point;
            //            this.BusinessType_panel.Visible = true;

            //            point.Y = point.Y + 30;
            //            this.Customer_panel.Location = point;
            //            this.Customer_panel.Visible = true;
            //            break;
            //        }
            //}
            //--- DEL 2008.08.14 ----------<<<<<

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (this._selPrintMode > 0)
            if ((this._selPrintMode != 0) && (this._selPrintMode != 3))
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                // ���o����
                this.Main_ultraExplorerBar.Groups[2].Visible = true;
                switch (this._selPrintMode)
                {
                    case 1: // ���Ӑ��
                        {
                            break;
                        }
                    case 2: // �S���ҕ�
                    case 5: // ���Ӑ�ʃ��[�J�[��
                    case 6: // �n���
                    case 7: // �Ǝ��
                        {
                            this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 80;
                            break;
                        }
                    case 3: // ������
                    case 4: // ���[�J�[��
                        {
                            this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 50;
                            break;
                        }
                }
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 --------------------------------<<<<< 
            // ���o�����͑S�ĕ\��
            if (this._selPrintMode == CT_SelPrintMode_Customer)
            {
                // ���Ӑ�̏ꍇ�̂ݕ\������
                //this.ExtractPanel1.Visible = false; // DEL 2008/12/05
                //this.CustomerCodePanel1.Location = new Point(13, 7); // DEL 2008/12/05
                this.CustomerCodePanel1.Location = this.SalesEmployeePanel.Location; // ADD 2008/12/05

                //this.OrderPanel1.Location = new Point(13, 46);// DEL 2008/12/05
                this.OrderPanel1.Location = this.FrontEmployeePanel.Location; // ADD 2008/12/05

                this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 180;
                //this.ultraExplorerBarContainerControl1.Height = 180;
            }

            // ���o�����̃��x�����ƃK�C�h�{�^���L���v�V����
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_SalesEmployee: // �S����
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "�S����";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "�S���Ҍ���");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "�S���Ҍ���");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.SalesEmployeePanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "�󒍎�";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "�󒍎Ҍ���");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "�󒍎Ҍ���");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.FrontEmployeePanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.FrontEmployeePanel.Location = this.SalesEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
                case CT_SelPrintMode_SalesInput: // ���s��
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "���s��";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "���s�Ҍ���");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "���s�Ҍ���");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.SalesInputPanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.SalesInputPanel.Location = this.SalesEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
                case CT_SelPrintMode_Area: // �n��
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "�n��";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "�n�挟��");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "�n�挟��");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.SalesAreaPanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.SalesAreaPanel.Location = this.SalesEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "�Ǝ�";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "�Ǝ팟��");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "�Ǝ팟��");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.BusinessTypePanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.BusinessTypePanel.Location = this.SalesEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        // --- DEL 2008/12/05 -------------------------------->>>>>
                        //this.ExtractUltraLabel1.Text = "�̔��敪";
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton1, "�̔��敪����");
                        //this.toolTip1.SetToolTip(this.ExtractUltraButton2, "�̔��敪����");
                        // --- DEL 2008/12/05 --------------------------------<<<<<
                        // --- ADD 2008/12/05 -------------------------------->>>>>
                        this.SalesCodePanel.Visible = true;
                        this.OrderPanel1.Location = this.SalesInputPanel.Location;
                        this.CustomerCodePanel1.Location = this.FrontEmployeePanel.Location;
                        this.SalesCodePanel.Location = this.SalesEmployeePanel.Location;
                        this.Main_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 215;
                        // --- ADD 2008/12/05 --------------------------------<<<<<
                        break;
                    }
            }

            // --- ADD 2008/09/08 --------------------------------<<<<<

            // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ConstUnit_ultraOptionSet.Visible = true;
            // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            #endregion

            #region < �����l�ݒ� >
            // 2008.03.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �n��R�[�h
            //this.SalesAreaCodeSt_Nedit.SetInt(0);
            //this.SalesAreaCodeEd_Nedit.SetInt(9999);

            //// �Ǝ�R�[�h
            //this.BusinessTypeCodeSt_Nedit.SetInt(0);
            //this.BusinessTypeCodeEd_Nedit.SetInt(9999);

            //// ���Ӑ�R�[�h
            //this.tNedit_CustomerCode_St.SetInt(0);
            //this.tNedit_CustomerCode_Ed.SetInt(999999999);

            //// ���[�J�[�R�[�h
            //this.GoodsMakerCdSt_Nedit.SetInt(0);
            //this.GoodsMakerCdEd_Nedit.SetInt(999999);
            // 2008.03.05 �폜 <<<<<<<<<<<<<<<<<<<<


            //---ADD 2008.08.14 ---------->>>>>
            this.OrderRange_Nedit.SetInt(9999999);                      // ���ʕt���ݒ�(�͈�)
            this.OrderAppointment_tComboEditor.SelectedIndex = 0;       // ���ʎw��
            //---ADD 2008.08.14 ----------<<<<<

            #endregion

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
            this._preComboEditorLineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;// ADD zhuhh 2012/12/28 for Redmine #34098
        }

		/// <summary>
		/// ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		private bool ScreenInputCheack(out string message, ref Control errControl)
		{
			message = "";
			bool result = false;
			errControl = null;

            // --- ADD 2008/12/05 -------------------------------->>>>>
            // ���ʂɓ��͂������ꍇ�A1�ɕύX
            if (string.IsNullOrEmpty(this.OrderRange_Nedit.Text) ||
                this.OrderRange_Nedit.GetInt() == 0)
            {
                this.OrderRange_Nedit.SetInt(1);
            }
            // --- ADD 2008/12/05 --------------------------------<<<<<

            // 2008.02.26 upd start -------------------------------------------------->>
            //#region < �Ώۓ��t(�J�n) >
            //if (!InputDateEditCheack(this.TargetDateSt_tDateEdit))
            //{
            //    message = "�Ώۓ��t�̎w��Ɍ�肪����܂�";
            //    errControl = this.TargetDateSt_tDateEdit;
            //    return result;
            //}
            //#endregion

            //#region < �Ώۓ��t(�I��) >
            //if (!InputDateEditCheack(this.TargetDateEd_tDateEdit))
            //{
            //    message = "�Ώۓ��t�̎w��Ɍ�肪����܂�";
            //    errControl = this.TargetDateEd_tDateEdit;
            //    return result;
            //}
            //#endregion

            //#region < �Ώۓ��t�͈̓`�F�b�N >
            //if ((this.TargetDateSt_tDateEdit.GetLongDate()) > (this.TargetDateEd_tDateEdit.GetLongDate()))
            //{
            //    message = "�Ώۓ��t�͈̔͂Ɍ�肪����܂�";
            //    errControl = this.TargetDateSt_tDateEdit;
            //    return result;
            //}
            //#endregion

            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            //const string ct_RangeOverError = "�͓���N�x���œ��͂��ĉ�����";// DEL 2009/02/24
            const string ct_RangeOverError = "��12�����ȓ��œ��͂��ĉ�����";// ADD 2009/02/24
            const string ct_NotOnYearError = "�͓���N�x���œ��͂��ĉ�����";// ADD 2009/02/24

            DateGetAcs.CheckDateRangeResult cdrResult;

            // �Ώ۔N��
            if (CallCheckDateRange(out cdrResult, ref TargetDateSt_tDateEdit, ref TargetDateEd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("�J�n�Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n�Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("�I���Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I���Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("�Ώ۔N��{0}", ct_RangeError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        // --- ADD 2009/02/24 -------------------------------->>>>>
                        {
                            message = string.Format("�Ώ۔N��{0}", ct_RangeOverError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                        // --- ADD 2009/02/24 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                        {
                            //message = string.Format("�Ώ۔N��{0}", ct_RangeOverError); // DEL 2009/02/24
                            message = string.Format("�Ώ۔N��{0}", ct_NotOnYearError); // ADD 2009/02/24
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                }
                return result;
            }
            // 2008.02.26 upd end ----------------------------------------------------<<

            // --- DEL 2008/12/05 -------------------------------->>>>>
            //// --- ADD 2008/09/08 -------------------------------->>>>>
            //// 2008/12/04 �`�F�b�N�D�揇�ʂ𓾈Ӑ�̑O�ɕύX
            //#region ����2�`�F�b�N
            //if ((this.tNedit_ExtractCode_St.GetInt() != 0) &&
            //    (this.tNedit_ExtractCode_Ed.GetInt() != 0) &&
            //    (this.tNedit_ExtractCode_St.GetInt() > this.tNedit_ExtractCode_Ed.GetInt()))
            //{
            //    switch (this._selPrintMode)
            //    {
            //        case CT_SelPrintMode_SalesEmployee: // �S����
            //            {
            //                message = "�S���҂͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //        case CT_SelPrintMode_FrontEmployee: // �󒍎�
            //            {
            //                message = "�󒍎҂͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //        case CT_SelPrintMode_SalesInput: // ���s��
            //            {
            //                message = "���s�҂͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //        case CT_SelPrintMode_Area: // �n��
            //            {
            //                message = "�n��͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //        case CT_SelPrintMode_BusinessType: // �Ǝ�
            //            {
            //                message = "�Ǝ�͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //        case CT_SelPrintMode_SalesDivision: // �̔��敪
            //            {
            //                message = "�̔��敪�͈̔͂Ɍ�肪����܂�";
            //                break;
            //            }
            //    }

            //    errControl = this.tNedit_ExtractCode_St;
            //    return result;
            //}
            //#endregion
            //// --- ADD 2008/09/08 --------------------------------<<<<<
            // --- DEL 2008/12/05 --------------------------------<<<<<
            // --- ADD 2008/12/05 -------------------------------->>>>>
            #region < �S���҃R�[�h�͈̓`�F�b�N >
            if (
                (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd()) > 0))
            {
                message = "�S���҂͈̔͂Ɍ�肪����܂�";
                errControl = this.tEdit_SalesEmployeeCode_St;
                return result;
            }
            #endregion

            #region < �󒍎҃R�[�h�͈̓`�F�b�N >
            if (
                (this.tEdit_FrontEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_FrontEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_FrontEmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_FrontEmployeeCode_Ed.DataText.TrimEnd()) > 0))
            {
                message = "�󒍎҂͈̔͂Ɍ�肪����܂�";
                errControl = this.tEdit_FrontEmployeeCode_St;
                return result;
            }
            #endregion

            #region < ���s�҃R�[�h�͈̓`�F�b�N >
            if (
                (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SalesInputCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd()) > 0))
            {
                message = "���s�҂͈̔͂Ɍ�肪����܂�";
                errControl = this.tEdit_SalesInputCode_St;
                return result;
            }
            #endregion

            #region < �n��R�[�h�͈̓`�F�b�N >
            if (
                (this.tNedit_SalesAreaCode_St.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                message = "�n��͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_SalesAreaCode_St;
                return result;
            }
            #endregion

            #region < �Ǝ�R�[�h�͈̓`�F�b�N >
            if (
                (this.tNedit_BusinessTypeCode_St.GetInt() != 0) &&
                (this.tNedit_BusinessTypeCode_Ed.GetInt() != 0) &&
                (this.tNedit_BusinessTypeCode_St.GetInt() > this.tNedit_BusinessTypeCode_Ed.GetInt()))
            {
                message = "�Ǝ�͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_BusinessTypeCode_St;
                return result;
            }
            #endregion

            #region < �̔��敪�R�[�h�͈̓`�F�b�N >
            if (
                (this.tNedit_SalesCode_St.GetInt() != 0) &&
                (this.tNedit_SalesCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt()))
            {
                message = "�̔��敪�͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_SalesCode_St;
                return result;
            }
            #endregion
            // --- ADD 2008/12/05 --------------------------------<<<<<

            #region < ���Ӑ�R�[�h�͈̓`�F�b�N >
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            if ((this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
			{
                message = "���Ӑ�͈̔͂Ɍ�肪����܂�";
				errControl = this.tNedit_CustomerCode_St;
				return result;
            }
            #endregion

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �n��R�[�h�͈̓`�F�b�N >
            //// 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this.SalesAreaCodeSt_Nedit.GetInt()) > (this.SalesAreaCodeEd_Nedit.GetInt()))
            //if ((this.SalesAreaCodeSt_Nedit.GetInt() != 0) &&
            //    (this.SalesAreaCodeEd_Nedit.GetInt() != 0) &&
            //    (this.SalesAreaCodeSt_Nedit.GetInt() > this.SalesAreaCodeEd_Nedit.GetInt()))
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    message = "�n��͈̔͂Ɍ�肪����܂�";
            //    errControl = this.tNedit_CustomerCode_St;
            //    return result;
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �Ǝ�R�[�h�͈̓`�F�b�N >
            //// 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this.BusinessTypeCodeSt_Nedit.GetInt()) > (this.BusinessTypeCodeEd_Nedit.GetInt()))
            //if ((this.BusinessTypeCodeSt_Nedit.GetInt() != 0) &&
            //    (this.BusinessTypeCodeEd_Nedit.GetInt() != 0) &&
            //    (this.BusinessTypeCodeSt_Nedit.GetInt() > this.BusinessTypeCodeEd_Nedit.GetInt()))
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    message = "�Ǝ�͈̔͂Ɍ�肪����܂�";
            //    errControl = this.tNedit_CustomerCode_St;
            //    return result;
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �]�ƈ��R�[�h�͈̓`�F�b�N >
            //// 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if (this.EmployeeCodeSt_tEdit.DataText.CompareTo(this.EmployeeCodeEd_tEdit.DataText) > 0)
            //if ((this.EmployeeCodeSt_tEdit.DataText.TrimEnd() != string.Empty) &&
            //    (this.EmployeeCodeEd_tEdit.DataText.TrimEnd() != string.Empty) &&
            //    (this.EmployeeCodeSt_tEdit.DataText.CompareTo(this.EmployeeCodeEd_tEdit.DataText) > 0))
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    message = "�S���҂͈̔͂Ɍ�肪����܂�";
            //    errControl = this.EmployeeCodeSt_tEdit;
            //    return result;
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < ���[�J�[�R�[�h�͈̓`�F�b�N >
            //// 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this.GoodsMakerCdSt_Nedit.GetInt()) > (this.GoodsMakerCdEd_Nedit.GetInt()))
            //if ((this.GoodsMakerCdSt_Nedit.GetInt() != 0) &&
            //    (this.GoodsMakerCdEd_Nedit.GetInt() != 0) &&
            //    (this.GoodsMakerCdSt_Nedit.GetInt() > this.GoodsMakerCdEd_Nedit.GetInt()))
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    message = "���[�J�[�͈̔͂Ɍ�肪����܂�";
            //    errControl = this.EmployeeCodeSt_tEdit;
            //    return result;
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �����R�[�h�͈̓`�F�b�N >
            //// 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this.SectionCodeSt_tEdit.DataText.TrimEnd() != string.Empty) &&
            ////    (this.SectionCodeSt_tEdit.DataText.TrimEnd() != string.Empty))
            //if ((this.SectionCodeSt_tEdit.DataText.TrimEnd() != string.Empty) &&
            //    (this.SectionCodeEd_tEdit.DataText.TrimEnd() != string.Empty))
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    int status = this.SectionCodeSt_tEdit.DataText.CompareTo(this.SectionCodeEd_tEdit.DataText);
            //    if (status > 0)
            //    {
            //        message = "�����͈̔͂Ɍ�肪����܂�";
            //        errControl = this.SectionCodeSt_tEdit;
            //        return result;
            //    }
            //    else if (status == 0)
            //    {
            //        // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //        if ((this.SubSectionCodeSt_Nedit.GetInt() != 0) &&
            //            (this.SubSectionCodeEd_Nedit.GetInt() != 0))
            //        {
            //        // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //            if (this.SubSectionCodeSt_Nedit.GetInt() > this.SubSectionCodeEd_Nedit.GetInt())
            //            {
            //                message = "�����͈̔͂Ɍ�肪����܂�";
            //                // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //                //errControl = this.SectionCodeSt_tEdit;
            //                errControl = this.SubSectionCodeEd_Nedit;
            //                // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //                return result;
            //            }
            //            else if (this.SubSectionCodeSt_Nedit.GetInt() == this.SubSectionCodeEd_Nedit.GetInt())
            //            {
            //                // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //                //if (this.MinSectionCodeSt_Nedit.GetInt() > this.MinSectionCodeEd_Nedit.GetInt())
            //                if ((this.MinSectionCodeSt_Nedit.GetInt() != 0) &&
            //                    (this.MinSectionCodeEd_Nedit.GetInt() != 0) &&
            //                    (this.MinSectionCodeSt_Nedit.GetInt() > this.MinSectionCodeEd_Nedit.GetInt()))
            //                // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //                {
            //                    message = "�����͈̔͂Ɍ�肪����܂�";
            //                    // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //                    //errControl = this.SectionCodeSt_tEdit;
            //                    errControl = this.MinSectionCodeEd_Nedit;
            //                    // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //                    return result;
            //                }
            //            }
            //        // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //        }
            //        // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //    }
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            return true;
		}

		/// <summary>
		/// ��ʓ��͕⏕����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʂ͈͎̔w��̓��͕⏕���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		private void ScreenInputAssist()
        {
            #region < �Ώۓ��t >
            if (this.TargetDateSt_tDateEdit.LongDate != 0 && this.TargetDateEd_tDateEdit.LongDate == 0)
			{
				this.TargetDateEd_tDateEdit.SetLongDate(this.TargetDateSt_tDateEdit.LongDate);
            }
            #endregion

            #region < ���Ӑ�R�[�h >
            // 2008.03.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (this.tNedit_CustomerCode_St.DataText != "" && this.tNedit_CustomerCode_Ed.DataText == "")
            //{
            //    this.tNedit_CustomerCode_Ed.DataText = this.tNedit_CustomerCode_St.DataText;
            //}
            // 2008.03.05 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion

            #region < �]�ƈ��R�[�h >
            // 2008.03.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (this.EmployeeCodeSt_tEdit.DataText != "" && this.EmployeeCodeEd_tEdit.DataText == "")
            //{
            //    this.EmployeeCodeEd_tEdit.DataText = this.EmployeeCodeSt_tEdit.DataText;
            //}
            // 2008.03.05 �폜 <<<<<<<<<<<<<<<<<<<<
            #endregion
        }

        // 2008.02.26 add start ---------------------------------------->>
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            //cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, true); // DEL 2009/02/24
            // --- ADD 2009/02/24 -------------------------------->>>>>
            if (this.PrintType_ultraOptionSet.CheckedIndex == 0)
            {
                // �����̏ꍇ�A�N�x�ׂ�̃`�F�b�N�Ȃ�
                cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false);
            }
            else
            {
                // �������܂ޏꍇ�A�N�x�ׂ���`�F�b�N
                cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, true);

                if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear)
                {
                    // �N�x�ׂ�ȊO���ă`�F�b�N
                    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false);

                    if (cdrResult == DateGetAcs.CheckDateRangeResult.OK)
                    {
                        // �N�x�ׂ�G���[�̏ꍇ�͓����ɂ���
                        this.PrintType_ultraOptionSet.CheckedIndex = 0;
                    }
                }
            }
            // --- ADD 2009/02/24 --------------------------------<<<<<
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // 2008.02.26 add end ------------------------------------------<<

        /// <summary>
        /// �`���[�g�p��ʓ��̓`�F�b�N����
        /// </summary>
        private bool ChartInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            switch (this._selPrintMode)
            {
                case 0: // ���_��
                    {
                        break;
                    }
                case 1: // ���Ӑ��
                case 2: // �S���ҕ�
                case 3: // ������
                case 4: // ���[�J�[��
                case 5: // ���Ӑ�ʃ��[�J�[��
                case 6: // �n���
                case 7: // �Ǝ��
                    {
                        // ���_���e�`�F�b�N
                        if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
                        {
                            message = "�O���t�o�͂̏ꍇ�A���_�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                            return result;
                        }
                        break;
                    }
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 -------------------------------->>>>>
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer: // ���Ӑ�
                    {
                        if (this.PrintOder_tComboEditor.SelectedIndex == 0
                            || this.PrintOder_tComboEditor.SelectedIndex == 3
                            || this.PrintOder_tComboEditor.SelectedIndex == 4) // ���Ӑ�A�Ǘ����_�A������
                        {
                            // ���_���e�`�F�b�N
                            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
                            {
                                message = "�O���t�o�͂̏ꍇ�A���_�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }
                        else if (this.PrintOder_tComboEditor.SelectedIndex == 1) // ���_
                        {
                            // ����Ȃ�
                        }
                        else if (this.PrintOder_tComboEditor.SelectedIndex == 2) // ���Ӑ�-���_ 
                        {
                            // ���Ӑ�`�F�b�N
                            if (this.tNedit_CustomerCode_St.Text != this.tNedit_CustomerCode_Ed.Text)
                            {
                                message = "�O���t�o�͂̏ꍇ�A���Ӑ�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }

                        break;
                    }
                case CT_SelPrintMode_SalesEmployee: // �S����
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                case CT_SelPrintMode_SalesInput: // ���s��
                case CT_SelPrintMode_Area: // �n��
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        // ���b�Z�[�W�ɕ\�����鍀�ږ�
                        string mess = "";

                        if (this._selPrintMode == CT_SelPrintMode_SalesEmployee)
                        {
                            mess = "�S����";
                        }
                        else if (this._selPrintMode == CT_SelPrintMode_FrontEmployee)
                        {
                            mess = "�󒍎�";
                        }
                        else if (this._selPrintMode == CT_SelPrintMode_SalesInput)
                        {
                            mess = "���s��";
                        }
                        else if (this._selPrintMode == CT_SelPrintMode_Area)
                        {
                            mess = "�n��";
                        }
                        else if (this._selPrintMode == CT_SelPrintMode_BusinessType)
                        {
                            mess = "�Ǝ�";
                        }

                        if (this.PrintOder_tComboEditor.SelectedIndex == 0
                            || this.PrintOder_tComboEditor.SelectedIndex == 3) // xx�A�Ǘ����_
                        {
                            // ���_���e�`�F�b�N
                            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
                            {
                                message = "�O���t�o�͂̏ꍇ�A���_�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }
                        else if (this.PrintOder_tComboEditor.SelectedIndex == 1) // ���Ӑ�
                        {
                            // ���_���e�A�W�v�P�ʖ��`�F�b�N
                            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0"))
                                //|| (this.tNedit_ExtractCode_St.Text != this.tNedit_ExtractCode_Ed.Text) // DEL 2008/12/05
                                || (this.tEdit_SalesEmployeeCode_St.DataText != this.tEdit_SalesEmployeeCode_Ed.DataText)
                                || (this.tEdit_FrontEmployeeCode_St.DataText != this.tEdit_FrontEmployeeCode_Ed.DataText)
                                || (this.tEdit_SalesInputCode_St.DataText != this.tEdit_SalesInputCode_Ed.DataText)
                                || (this.tNedit_SalesAreaCode_St.DataText != this.tNedit_SalesAreaCode_Ed.DataText)
                                || (this.tNedit_BusinessTypeCode_St.DataText != this.tNedit_BusinessTypeCode_Ed.DataText)
                                || (this.tNedit_SalesCode_St.DataText != this.tNedit_SalesCode_Ed.DataText)
                                ) // ADD 2008/12/05
                            {
                                message = "�O���t�o�͂̏ꍇ�A���_��"
                                    + mess
                                    + "�͑Ώۂ�1���ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }
                        else if (this.PrintOder_tComboEditor.SelectedIndex == 2) // �W�v�P��
                        {
                            // �W�v�P�ʃ`�F�b�N
                            //if (this.tNedit_ExtractCode_St.Text != this.tNedit_ExtractCode_Ed.Text) // DEL 2008/12/05
                            if ((this.tEdit_SalesEmployeeCode_St.DataText != this.tEdit_SalesEmployeeCode_Ed.DataText)
                            || (this.tEdit_FrontEmployeeCode_St.DataText != this.tEdit_FrontEmployeeCode_Ed.DataText)
                            || (this.tEdit_SalesInputCode_St.DataText != this.tEdit_SalesInputCode_Ed.DataText)
                            || (this.tNedit_SalesAreaCode_St.DataText != this.tNedit_SalesAreaCode_Ed.DataText)
                            || (this.tNedit_BusinessTypeCode_St.DataText != this.tNedit_BusinessTypeCode_Ed.DataText)
                            || (this.tNedit_SalesCode_St.DataText != this.tNedit_SalesCode_Ed.DataText)) // ADD 2008/12/05
                            {
                                message = "�O���t�o�͂̏ꍇ�A"
                                    + mess
                                    + "�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }

                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        if (this.TtlType_ultraOptionSet.CheckedIndex == 1)
                        {
                            // ���_���e�`�F�b�N
                            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
                            {
                                message = "�O���t�o�͂̏ꍇ�A���_�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                                return result;
                            }
                        }

                        break;
                    }
            }
            // --- ADD 2008/09/08 --------------------------------<<<<<

            return true;
        }

        /// <summary>
		///
		/// </summary>
		/// <param name="extraInfo"></param>
		/// <returns></returns>
        private int SearchData(SalesMonthYearReportCndtn extraInfo)
		{
			string message;
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ���o�������ς���Ă���Ȃ烊���[�e�B���O
			if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
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
							this._saleConfListCndtnWork = extraInfo.Clone();

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
		/// ���t���̓`�F�b�N����
		/// </summary>
		/// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
		/// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
		/// <remarks>
		/// <br>Note	   : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
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
				// �N�E��	 �\����
				case emDateFormat.dfG2Y2M:
				case emDateFormat.df4Y2M:
				case emDateFormat.df2Y2M:
					if (yy == 0 || mm == 0) return false;
					break;
				// �N		 �\����
				case emDateFormat.dfG2Y:
				case emDateFormat.df4Y:
				case emDateFormat.df2Y:
					if (yy == 0) return false;
					break;
				// ���E���@�@�\����
				case emDateFormat.df2M2D:
					if (mm == 0 || dd == 0) return false;
					break;
				// ��		 �\����
				case emDateFormat.df2M:
					if (mm == 0) return false;
					break;
				// ��		 �\����
				case emDateFormat.df2D:
					if (dd == 0) return false;
					break;
			}

			DateTime dt = TDateTime.LongDateToDateTime("YYYYMM", date / 100);
			// �P�����t�Ó����`�F�b�N
			if (TDateTime.IsAvailableDate(dt) == false) return false;

			return true;
		}

		/// <summary>
		/// ���o�����ݒ菈��(��ʁ����o����)
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(out SalesMonthYearReportCndtn extraInfo)
		{
            extraInfo = new SalesMonthYearReportCndtn();

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
                    extraInfo.SectionCodes = null;
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
                extraInfo.SectionCodes = null;
            }
            #endregion

            #region < �Ώۓ��t >
            int workIntSt;
            int workIntEd;
            //DateTime workDate;    // 2008.03.05 �C��
            // �v��N��(�J�n)
            workIntSt = (this.TargetDateSt_tDateEdit.GetLongDate() / 100) * 100 + 1;
            extraInfo.AddUpYearMonthSt = TDateTime.LongDateToDateTime(workIntSt);
            // �v��N��(�I��)
            workIntEd = (this.TargetDateEd_tDateEdit.GetLongDate() / 100) * 100 + 1;
            extraInfo.AddUpYearMonthEd = TDateTime.LongDateToDateTime(workIntEd);

            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �v����N��(�J�n)
            //workDate = TDateTime.LongDateToDateTime(this._companyBiginDate);
            //if (workIntSt < this._companyBiginDate)
            //{
            //    for (int ix = 0; ix < (this._companyBiginDate / 10000) - (workIntSt / 10000) + 1; ix++)
            //    {
            //        workDate = workDate.AddYears(-1);
            //        if (workIntSt >= TDateTime.DateTimeToLongDate(workDate)) break;
            //    }
            //}
            //extraInfo.AnnualAddUpYearMonthSt = workDate;
            //// �v����N��(�I��)
            //extraInfo.AnnualAddUpYaerMonthEd = (workDate.AddYears(1)).AddMonths(-1);

            // �Ώ۔N�x�擾
            int      difYear;
            int      targetYear;
            DateTime startYearDate;
            DateTime endYearDate;
            this._dateGet.GetYearFromMonth(extraInfo.AddUpYearMonthSt, out targetYear, out difYear, out startYearDate, out endYearDate);

            //--- DEL 2008.08.14 ---------->>>>>
            // �v����N��(�J�n)
            extraInfo.AnnualAddUpYearMonthSt = startYearDate;
            // �v����N��(�I��)
            extraInfo.AnnualAddUpYaerMonthEd = extraInfo.AddUpYearMonthEd;
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008.08.14 ----------<<<<<
            #endregion

            #region < �W�v���@ >
            extraInfo.TtlType = (int)this.TtlType_ultraOptionSet.CheckedItem.DataValue;
            extraInfo.TtlTypeName = this.TtlType_ultraOptionSet.CheckedItem.DisplayText;
            #endregion

            #region < �W�v�P�� >
            switch (this._selPrintMode)
            {
                /* --- DEL 2008/09/08 -------------------------------->>>>>
                case 0: // ���_��
                    {
                        extraInfo.TotalType = 0;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 1: // ���Ӑ��
                    {
                        switch (this.PrintOder_tComboEditor.SelectedIndex)
                        {
                            //case 0: // ���Ӑ��
                            //    {
                            //        extraInfo.TotalType = 1;
                            //        extraInfo.TotalTypeName = this._selPrintModeName;
                            //        break;
                            //    }
                            //case 1: // �n��ʓ��Ӑ��
                            //    {
                            //        extraInfo.TotalType = 2;
                            //        extraInfo.TotalTypeName = "�n��ʓ��Ӑ��";
                            //        break;
                            //    }
                            //case 2: // �Ǝ�ʓ��Ӑ��
                            //    {
                            //        extraInfo.TotalType = 3;
                            //        extraInfo.TotalTypeName = "�Ǝ�ʓ��Ӑ��";
                            //        break;
                            //    }
                            case 0: // ���Ӑ�
                            case 2: // ���Ӑ�|���_
                            case 3: // �Ǘ����_
                            case 4: // ������
                                {
                                    extraInfo.TotalType = 0;
                                    extraInfo.PrintingPattern = 0;
                                    extraInfo.TotalTypeName = this._selPrintModeName;
                                    break;
                                }
                            case 1: // ���_
                                {
                                    extraInfo.TotalType = 0;
                                    extraInfo.PrintingPattern = 1;
                                    extraInfo.TotalTypeName = this._selPrintModeName;
                                    break; 
                                }

                        }
                        break;
                    }
                case 2: // �S���ҕ�
                    {
                        extraInfo.TotalType = 6;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 3: // ������
                    {
                        // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
                        //extraInfo.TotalType = 7;
                        if (this._secMngDiv == 0)
                        {
                            extraInfo.TotalType = 0;
                        }
                        else
                        {
                            extraInfo.TotalType = 7;
                        }
                        // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 4: // ���[�J�[��
                    {
                        extraInfo.TotalType = 8;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 5: // ���Ӑ�ʃ��[�J�[��
                    {
                        extraInfo.TotalType = 9;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 6: // �n���
                    {
                        extraInfo.TotalType = 4;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case 7: // �Ǝ��
                    {
                        extraInfo.TotalType = 5;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                 --- DEL 2008/09/08 -------------------------------->>>>> */
                // --- ADD 2008/09/08 -------------------------------->>>>>
                case CT_SelPrintMode_Customer: // ���Ӑ�
                    {
                        extraInfo.TotalType = (int) SalesMonthYearReportCndtn.TotalTypeEnum.Customer;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_SalesEmployee: // �S����
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesEmployee;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.FrontEmployee;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_SalesInput: // ���s��
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesInput;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_Area: // �n��
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.Area;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.BusinessType;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        extraInfo.TotalType = (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision;
                        extraInfo.TotalTypeName = this._selPrintModeName;
                        break;
                    }
                // --- ADD 2008/09/08 --------------------------------<<<<< 
            }
            #endregion

            #region < ����^�C�v >
            extraInfo.PrintType = this.PrintType_ultraOptionSet.CheckedIndex;
            extraInfo.PrintTypeName = this.PrintType_ultraOptionSet.CheckedItem.DisplayText;
            #endregion

            #region < �\����P�� >
            extraInfo.ConstUnit = this.ConstUnit_ultraOptionSet.CheckedIndex;
            extraInfo.ConstUnitName = this.ConstUnit_ultraOptionSet.CheckedItem.DisplayText;
            #endregion

            #region < ���z�P�� >
            extraInfo.MoneyUnit = this.MoneyUnit_ultraOptionSet.CheckedIndex;
            extraInfo.MoneyUnitName = this.MoneyUnit_ultraOptionSet.CheckedItem.DisplayText;
            #endregion

            #region < ���� >
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            int crMode = 0;

            if (this.CrMode1_ultraCheckEditor.Checked == true) crMode = 1;

            //--- DEL 2008.08.14 ---------->>>>>
            //if ((this.CrMode2_ultraCheckEditor.Visible == true) &&
            //    (this.CrMode2_ultraCheckEditor.Checked == true))
            //{
            //    switch (extraInfo.TotalType)
            //    {
            //        case 2: { crMode = crMode + 3; break; } // �n��ʓ��Ӑ��
            //        case 3: { crMode = crMode + 4; break; } // �Ǝ�ʓ��Ӑ��
            //        case 7: { crMode = crMode + 1; break; } // ������
            //        case 9: { crMode = crMode + 2; break; } // ���Ӑ�ʃ��[�J�[��
            //    }
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            extraInfo.CrMode = crMode;
            --- DEL 2008/09/08 -------------------------------->>>>> */
            
            // ���ŏ���ێ�
            if (this.CrMode1_ultraCheckEditor.Checked)
            {
                extraInfo.CrMode1 = true;
            }
            else
            {
                extraInfo.CrMode1 = false;
            }

            if (this.CrMode2_ultraCheckEditor.Checked)
            {
                extraInfo.CrMode2 = true;
            }
            else
            {
                extraInfo.CrMode2 = false;
            }

            #endregion

            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            #region <�r���󎚐���>
            extraInfo.LineMaSqOfChDiv =(int) this.tComboEditor_LineMaSqOfCh.Value;
            #endregion
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

            #region < �o�͏� >
            //extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);
            if (extraInfo.TotalType != (int)SalesMonthYearReportCndtn.TotalTypeEnum.SalesDivision)
            {
                extraInfo.OutType = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);        // ADD 2008.08.14
            }
            #endregion

            #region < ���Ӑ� >
            //--- DEL 2008.08.14 ---------->>>>>
            //if (this.Customer_panel.Visible == true)
            //{
            //    // ���Ӑ�(�J�n)
            //    extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            //    // ���Ӑ�(�I��)
            //    extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            //--- ADD 2008.08.14 ---------->>>>>
            // ���Ӑ�(�J�n)
            extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            // ���Ӑ�(�I��)
            //extraInfo.CustomerCodeEd = GetEndCode(this.tNedit_CustomerCode_Ed); // DEL 2008/10/24
            extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt(); // ADD 2008/10/24
            
            //--- ADD 2008.08.14 ----------<<<<<
            #endregion

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region < �������� >
            // ��������(�J�n)
            // --- DEL 2008/12/05 -------------------------------->>>>>
            //if (this.tNedit_ExtractCode_St.DataText == "")
            //{
            //    //extraInfo.SearchCodeSt = "0"; // DEL 2008/10/24
            //    extraInfo.SearchCodeSt = string.Empty; // ADD 2008/10/24
            //}
            //else
            //{
            //    //extraInfo.SearchCodeSt = this.tNedit_ExtractCode_St.Text; // DEL 2008/10/06
            //    extraInfo.SearchCodeSt = this.tNedit_ExtractCode_St.Text.PadLeft(4, '0'); // ADD 2008/10/06
            //}
            // --- DEL 2008/12/05 --------------------------------<<<<<
            // --- ADD 2008/12/05 -------------------------------->>>>>
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_SalesEmployee: // �S����
                    {
                        extraInfo.SearchCodeSt = this.tEdit_SalesEmployeeCode_St.DataText;
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                    {
                        extraInfo.SearchCodeSt = this.tEdit_FrontEmployeeCode_St.DataText;
                        break;
                    }
                case CT_SelPrintMode_SalesInput: // ���s��
                    {
                        extraInfo.SearchCodeSt = this.tEdit_SalesInputCode_St.DataText;
                        break;
                    }
                case CT_SelPrintMode_Area: // �n��
                    {
                        if (this.tNedit_SalesAreaCode_St.GetInt() != 0)
                        {
                            extraInfo.SearchCodeSt = this.tNedit_SalesAreaCode_St.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeSt = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        if (this.tNedit_BusinessTypeCode_St.GetInt() != 0)
                        {
                            extraInfo.SearchCodeSt = this.tNedit_BusinessTypeCode_St.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeSt = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        if (this.tNedit_SalesCode_St.GetInt() != 0)
                        {
                            extraInfo.SearchCodeSt = this.tNedit_SalesCode_St.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeSt = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
            }
            // --- ADD 2008/12/05 --------------------------------<<<<<

            // ��������(�I��)
            // --- DEL 2008/12/05 -------------------------------->>>>>
            ////extraInfo.SearchCodeEd = GetEndCode(this.tNedit_ExtractCode_Ed).ToString().PadLeft(4, '0'); // DEL 2008/10/06
            ////extraInfo.SearchCodeEd = GetEndCode(this.tNedit_ExtractCode_Ed).ToString().PadLeft(4, '0'); // ADD 2008/10/06 // DEL 2008/10/24
            //// --- ADD 2008/10/24 -------------------------------->>>>>
            //if (this.tNedit_ExtractCode_Ed.DataText == "")
            //{
            //    extraInfo.SearchCodeEd = string.Empty;
            //}
            //else
            //{
            //    extraInfo.SearchCodeEd = this.tNedit_ExtractCode_Ed.DataText.PadLeft(4, '0');
            //}
            //// --- ADD 2008/10/24 --------------------------------<<<<<
            // --- DEL 2008/12/05 --------------------------------<<<<<
            // --- ADD 2008/12/05 -------------------------------->>>>>
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_SalesEmployee: // �S����
                    {
                        extraInfo.SearchCodeEd = this.tEdit_SalesEmployeeCode_Ed.DataText;
                        break;
                    }
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                    {
                        extraInfo.SearchCodeEd = this.tEdit_FrontEmployeeCode_Ed.DataText;
                        break;
                    }
                case CT_SelPrintMode_SalesInput: // ���s��
                    {
                        extraInfo.SearchCodeEd = this.tEdit_SalesInputCode_Ed.DataText;
                        break;
                    }
                case CT_SelPrintMode_Area: // �n��
                    {
                        if (this.tNedit_SalesAreaCode_Ed.GetInt() != 0)
                        {
                            extraInfo.SearchCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeEd = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        if (this.tNedit_BusinessTypeCode_Ed.GetInt() != 0)
                        {
                            extraInfo.SearchCodeEd = this.tNedit_BusinessTypeCode_Ed.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeEd = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        if (this.tNedit_SalesCode_Ed.GetInt() != 0)
                        {
                            extraInfo.SearchCodeEd = this.tNedit_SalesCode_Ed.GetInt().ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            extraInfo.SearchCodeEd = string.Empty; // ADD 2008/12/15
                        }
                        break;
                    }
            }
            // --- ADD 2008/12/05 --------------------------------<<<<<

            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �n�� >
            //if (this.SalesArea_panel.Visible == true)
            //{
            //    // �n��(�J�n)
            //    extraInfo.SalesAreaCodeSt = this.SalesAreaCodeSt_Nedit.GetInt();
            //    // �n��(�I��)
            //    extraInfo.SalesAreaCodeEd = this.SalesAreaCodeEd_Nedit.GetInt();
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �Ǝ� >
            //if (this.BusinessType_panel.Visible == true)
            //{
            //    // �Ǝ�(�J�n)
            //    extraInfo.BusinessTypeCodeSt = this.BusinessTypeCodeSt_Nedit.GetInt();
            //    // �Ǝ�(�I��)
            //    extraInfo.BusinessTypeCodeEd = this.BusinessTypeCodeEd_Nedit.GetInt();
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < �]�ƈ� >
            //if (this.Employee_panel.Visible == true)
            //{
            //    // �]�ƈ��R�[�h(�J�n)
            //    extraInfo.SalesEmployeeCdSt = this.EmployeeCodeSt_tEdit.Text;
            //    // �]�ƈ��R�[�h(�I��)
            //    extraInfo.SalesEmployeeCdEd = this.EmployeeCodeEd_tEdit.Text;
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            //--- DEL 2008.08.14 ---------->>>>>
            #region < ���[�J�[ >
            //if (this.GoodsMaker_panel.Visible == true)
            //{
            //    // ���[�J�[(�J�n)
            //    extraInfo.GoodsMakerCdSt = this.GoodsMakerCdSt_Nedit.GetInt();
            //    // ���[�J�[(�I��)
            //    extraInfo.GoodsMakerCdEd = this.GoodsMakerCdEd_Nedit.GetInt();
            //}
            #endregion
            //--- DEL 2008.08.14 ----------<<<<<

            #region < ���� >
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (this.Section_panel.Visible == true)
            //{
            //    // ���_(�J�n)
            //    extraInfo.SectionCodeSt = this.SectionCodeSt_tEdit.DataText;
            //    // ���_(�I��)
            //    extraInfo.SectionCodeEd = this.SectionCodeEd_tEdit.DataText;
            //    // ����(�J�n)
            //    extraInfo.SubSectionCodeSt = this.SubSectionCodeSt_Nedit.GetInt();
            //    // ����(�I��)
            //    extraInfo.SubSectionCodeEd = this.SubSectionCodeEd_Nedit.GetInt();
            //    // ��(�J�n)
            //    extraInfo.MinSectionCodeSt = this.MinSectionCodeSt_Nedit.GetInt();
            //    // ��(�I��)
            //    extraInfo.MinSectionCodeEd = this.MinSectionCodeEd_Nedit.GetInt();
            //}
            //--- DEL 2008.08.14 ---------->>>>>
            //if (this._selPrintMode == 3)
            //{
            //    extraInfo.SectionDiv        = this._secMngDiv;
            //    // ���_(�J�n)
            //    extraInfo.SectionCodeSt     = string.Empty;
            //    // ���_(�I��)
            //    extraInfo.SectionCodeEd     = string.Empty;
            //    // ����(�J�n)
            //    extraInfo.SubSectionCodeSt  = 0;
            //    // ����(�I��)
            //    extraInfo.SubSectionCodeEd  = 0;
            //    // ��(�J�n)
            //    extraInfo.MinSectionCodeSt  = 0;
            //    // ��(�I��)
            //    extraInfo.MinSectionCodeEd  = 0;
            //}
            //// 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //--- DEL 2008.08.14 ----------<<<<<
            #endregion

            //--- ADD 2008.08.14 ---------->>>>>
            #region < ����� >
            // �����
            extraInfo.PrintOrder = (SalesMonthYearReportCndtn.PrintOrderDivState)this.PrintOrder_ultraOptionSet.Value;
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            #region < ���ʕt���ݒ� >
            // ���ʕt���ݒ�(�S�ЁE���v��)
            extraInfo.OrderUnit = (int)this.OrderUnit_ultraOptionSet.Value;
            // ���ʕt���ݒ�(��ʁE����)
            extraInfo.OrderMethod = (SalesMonthYearReportCndtn.StockOrderDivState)this.OrderMethod_ultraOptionSet.Value;
            // ���ʕt���ݒ�(�`�ʂ܂�)
            // --- ADD 2008/10/02 -------------------------------->>>>>
            if (this.OrderRange_Nedit.GetInt() != 0)
            {
                extraInfo.OrderRange = (int)this.OrderRange_Nedit.GetInt();
            }
            else
            {
                extraInfo.OrderRange = 1;
            }
            // --- ADD 2008/10/02 --------------------------------<<<<<
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            //--- ADD 2008.08.14 ---------->>>>>
            #region < ���ʎw�� >
            // ���ʎw��
            extraInfo.OrderAppointment = (SalesMonthYearReportCndtn.OrderAppointmentDivState)this.OrderAppointment_tComboEditor.Value;
            #endregion
            //--- ADD 2008.08.14 ----------<<<<<

            // --- ADD 2008/09/08 -------------------------------->>>>>
            #region �󎚃p�^�[��(���[�p�^�[��)
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer: // ���Ӑ�
                    {
                        switch (this.PrintOder_tComboEditor.SelectedIndex)
                        {
                            case 0: // ���Ӑ�
                            case 3: // �Ǘ����_
                            case 4: // ������
                                {
                                    extraInfo.PrintingPattern = 0;
                                    break;
                                }
                            case 1:
                                {
                                    extraInfo.PrintingPattern = 1;
                                    break;
                                }
                            case 2:
                                {
                                    extraInfo.PrintingPattern = 2;
                                    break;
                                }
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesEmployee: // �S����
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                case CT_SelPrintMode_SalesInput: // ���s�� 
                case CT_SelPrintMode_Area: // �n��
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        switch (this.PrintOder_tComboEditor.SelectedIndex)
                        {
                            case 0: // �������� (�S���ғ�)
                            case 3: // �Ǘ����_
                                {
                                    extraInfo.PrintingPattern = 0;
                                    break;
                                }
                            case 1: // ���Ӑ�
                                {
                                    extraInfo.PrintingPattern = 1;
                                    break;
                                }
                            case 2: // ��������-���_
                                {
                                    extraInfo.PrintingPattern = 2;
                                    break;
                                }
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��敪
                    {
                        if (TtlType_ultraOptionSet.CheckedIndex == 0) // �W�v���@�S��
                        {
                            // �S��
                            extraInfo.PrintingPattern = 1;
                        }
                        else
                        {
                            // ���_��
                            extraInfo.PrintingPattern = 0;
                        }
                    }

                    break;
            }
            #endregion
            // --- ADD 2008/09/08 --------------------------------<<<<< 
        }

		/// <summary>
		/// �N�����[�h���f�[�^�e�[�u���ݒ�
		/// </summary>
		private void SettingDataTable()
		{
			_SalesTableDataTable = Broadleaf.Application.UIData.DCHNB02074EA.ct_Tbl_SalesMonthYearReportDtl;
		}

		/// <summary>
		/// �ŏ�ʃt�H�[���擾
		/// </summary>
		/// <remarks>
		/// <br>Note		: </br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.12.07</br>
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TopForm_SizeChanged(object sender, EventArgs e)
		{
			this.AdjustExplorerBarExpand();
		}

		/// <summary>
		/// �G�N�X�v���[���[�o�[�W�J��Ԓ���
		/// </summary>
		private void AdjustExplorerBarExpand()
		{
			if (this._topForm == null) return;

			if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
			{
				// �g�b�v�t�H�[���̍�������l��荂���ꍇ
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
			else
			{
				// �g�b�v�t�H�[���̍�������l���Ⴂ�ꍇ
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
		}

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
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

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>
        /// ��ʕ\�����ڂ̐�����s��
        /// </summary>
        private void ScreenSetting()
        {
            switch (this._selPrintMode)
            {
                case CT_SelPrintMode_Customer: // ���Ӑ�
                    {
                        if (this.TtlType_ultraOptionSet.CheckedIndex == 0) // �W�v���@���S��
                        {
                            // ���ŏ���1�͑I��s��
                            this.CrMode1_ultraCheckEditor.Checked = false;
                            this.CrMode1_ultraCheckEditor.Enabled = false;

                            if (this.PrintOder_tComboEditor.SelectedIndex != 2) // �o�͏�������-���_�ȊO
                            {
                                // �I��s��
                                this.CrMode2_ultraCheckEditor.Checked = false;
                                this.CrMode2_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode2_ultraCheckEditor.Enabled = true;
                            }
                        }
                        else // �W�v���@�@���_��
                        {
                            // ���ŏ���1�̐���
                            if (this.PrintOder_tComboEditor.SelectedIndex == 1
                                || this.PrintOder_tComboEditor.SelectedIndex == 2) // �o�͏� ���_�A����-���_
                            {
                                this.CrMode1_ultraCheckEditor.Checked = false;
                                this.CrMode1_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode1_ultraCheckEditor.Enabled = true;
                            }

                            // ���ŏ���2�̐���
                            if (this.PrintOder_tComboEditor.SelectedIndex != 2) // �o�͏�������-���_�ȊO
                            {
                                // �I��s��
                                this.CrMode2_ultraCheckEditor.Checked = false;
                                this.CrMode2_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode2_ultraCheckEditor.Enabled = true;
                            }
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesEmployee: // �S����
                case CT_SelPrintMode_FrontEmployee: // �󒍎�
                case CT_SelPrintMode_SalesInput: // ���s��
                case CT_SelPrintMode_Area: // �n��
                case CT_SelPrintMode_BusinessType: // �Ǝ�
                    {
                        if (this.TtlType_ultraOptionSet.CheckedIndex == 0) // �W�v���@���S��
                        {
                            // ���ŏ���1�͑I��s��
                            this.CrMode1_ultraCheckEditor.Checked = false;
                            this.CrMode1_ultraCheckEditor.Enabled = false;

                            if (this.PrintOder_tComboEditor.SelectedIndex == 0
                                || this.PrintOder_tComboEditor.SelectedIndex == 3) // �o�͏���<�@�\>�A�Ǘ����_
                            {
                                this.CrMode2_ultraCheckEditor.Checked = false;
                                this.CrMode2_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode2_ultraCheckEditor.Enabled = true;
                            }
                        }
                        else // �W�v���@�@���_��
                        {
                            // ���ŏ���1�̐���
                            if (this.PrintOder_tComboEditor.SelectedIndex == 2) // �o�͏���<�@�\>-���_
                            {
                                this.CrMode1_ultraCheckEditor.Checked = false;
                                this.CrMode1_ultraCheckEditor.Enabled = false;
                            }
                            else if (this.PrintOder_tComboEditor.SelectedIndex == 1
                                && this.CrMode2_ultraCheckEditor.Checked == true) // �o�͏������Ӑ悩���ŏ���2���`�F�b�N
                            {
                                this.CrMode1_ultraCheckEditor.Checked = true;
                                this.CrMode1_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode1_ultraCheckEditor.Enabled = true;
                            }

                            // ���ŏ���2��<�@�\>�A�Ǘ����_�̏ꍇ�I��s��
                            if (this.PrintOder_tComboEditor.SelectedIndex == 0
                                || this.PrintOder_tComboEditor.SelectedIndex == 3)
                            {
                                this.CrMode2_ultraCheckEditor.Checked = false;
                                this.CrMode2_ultraCheckEditor.Enabled = false;
                            }
                            else
                            {
                                this.CrMode2_ultraCheckEditor.Enabled = true;
                            }
                        }
                        break;
                    }
                case CT_SelPrintMode_SalesDivision: // �̔��n���
                    {
                        if (this.TtlType_ultraOptionSet.CheckedIndex == 0) // �W�v���@ �S��
                        {
                            this.CrMode1_ultraCheckEditor.Checked = false;
                            this.CrMode1_ultraCheckEditor.Enabled = false;
                        }
                        else // �W�v���@�@���_��
                        {
                            this.CrMode1_ultraCheckEditor.Enabled = true;
                        }

                        break;
                    }
            }
        }
        // --- ADD 2008/09/08 --------------------------------<<<<<

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

        /// <summary>
        /// ���Џ��ǂݍ��ݏ���
        /// </summary>
        public void GetCompanyInf()
        {
            // 2008.03.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //int companyBiginDay;
            //int companyBiginMonth;
            //int companyBiginYear;
            // 2008.03.05 �폜 <<<<<<<<<<<<<<<<<<<<

            // ���Џ��ǂݍ���
            int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
                //companyBiginDay   =  this._companyInf.CompanyBiginDate % 100;
                //companyBiginMonth = (this._companyInf.CompanyBiginDate % 10000) / 100;
                //companyBiginYear  =  this._companyInf.FinancialYear;

                //_companyBiginDate = (companyBiginYear * 10000) + (companyBiginMonth * 100) + companyBiginDay;

                this._secMngDiv = this._companyInf.SecMngDiv;
                // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            }
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
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
		private void SFUKK01390UA_Load(object sender, System.EventArgs e)
		{
			this.SettingDataTable();
			this._salesTableListAcs = new SalesTableAcs();

			// �ŏ�ʃt�H�[���擾
			this.GetTopForm();

			// ���_�I�v�V�����L�����擾����
			this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

			// �{��/���_�����擾����
			this._isMainOfficeFunc = this.GetMainOfficeFunc();

            // ���Џ��擾
            this.GetCompanyInf();

            this.Initial_Timer.Enabled = true;

            // ADD 2009/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ---------->>>>>
            #region ���W�I�{�^���̃X�y�[�X�L�[����

            TtlTypeRadioKeyPressHelper.ControlList.Add(this.TtlType_ultraOptionSet);
            TtlTypeRadioKeyPressHelper.StartSpaceKeyControl();

            PrintTypeRadioKeyPressHelper.ControlList.Add(this.PrintType_ultraOptionSet);
            PrintTypeRadioKeyPressHelper.StartSpaceKeyControl();

            ConstUnitRadioKeyPressHelper.ControlList.Add(this.ConstUnit_ultraOptionSet);
            ConstUnitRadioKeyPressHelper.StartSpaceKeyControl();

            MoneyUnitRadioKeyPressHelper.ControlList.Add(this.MoneyUnit_ultraOptionSet);
            MoneyUnitRadioKeyPressHelper.StartSpaceKeyControl();

            PrintOrderRadioKeyPressHelper.ControlList.Add(this.PrintOrder_ultraOptionSet);
            PrintOrderRadioKeyPressHelper.StartSpaceKeyControl();

            OrderUnitRadioKeyPressHelper.ControlList.Add(this.OrderUnit_ultraOptionSet);
            OrderUnitRadioKeyPressHelper.StartSpaceKeyControl();

            OrderMethodRadioKeyPressHelper.ControlList.Add(this.OrderMethod_ultraOptionSet);
            OrderMethodRadioKeyPressHelper.StartSpaceKeyControl();

            #endregion  // ���W�I�{�^���̃X�y�[�X�L�[����
            // ADD 2009/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������ ----------<<<<<
        }

		/// <summary>
		/// ��ʃA�N�e�B�u�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note	    : �������C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
		private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        /// <br>UpdateNote : 2012/12/28 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34098 �r���󎚐����ǉ�����</br>
        /// <br>UpdateNote : 2013/03/08 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10900690-00 2013/03/26�z�M��</br>
        /// <br>           : Redmine#34987 ���[redmine#34098�̎c���̑Ή�</br>
        /// </remarks>
		private void tKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// ���͎x�� ============================================ //
			// �����
			if ((e.PrevCtrl == this.TargetDateSt_tDateEdit) ||
				(e.PrevCtrl == this.TargetDateEd_tDateEdit))
			{
				AutoSetEndValue(this.TargetDateSt_tDateEdit, this.TargetDateEd_tDateEdit);
			}

            // --- ADD 2010/08/12 ---------------------------------->>>>>
            #region ���ڏ���
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "PrintOder_tComboEditor":
                    case "OrderAppointment_tComboEditor":
                        {
                            this.setTComboEditorByName(e.PrevCtrl.Name);
                            break;
                        }
                }
            }
            // --- ADD 2010/08/27 --- >>>>>
            if (e.PrevCtrl == this.PrintOder_tComboEditor)
            {
                // ��ʕ\��������s
                this.ScreenSetting();
            }
            // --- ADD 2010/08/27 --- <<<<<
            if (e.NextCtrl != null)
            {
                if (e.NextCtrl.GetType().Name == "TComboEditor")
                {
                    this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
                }
            }
            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            #endregion
            // --- ADD 2010/08/12 ----------------------------------<<<<<

			// ���Ӑ�R�[�h
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((e.PrevCtrl == this.tNedit_CustomerCode_St) && (this.tNedit_CustomerCode_St.GetInt() == 0))
            //{
            //    this.tNedit_CustomerCode_St.SetInt(0);
            //}
            //if ((e.PrevCtrl == this.tNedit_CustomerCode_Ed) && (this.tNedit_CustomerCode_Ed.GetInt() == 0))
            //{
            //    this.tNedit_CustomerCode_Ed.SetInt(999999999);
            //}
            if ((e.PrevCtrl == this.tNedit_CustomerCode_St) && (this.tNedit_CustomerCode_St.GetInt() == 0))
            {
                this.tNedit_CustomerCode_St.Clear();
            }
            // --- DEL 2008/09/24 -------------------------------->>>>>
            // --- ADD 2008/09/08 -------------------------------->>>>>
            //else if ((e.PrevCtrl == this.tNedit_CustomerCode_St) && (this.tNedit_CustomerCode_St.GetInt() != 0))
            //{
            //    e.NextCtrl = this.tNedit_CustomerCode_Ed;
            //}
            // --- ADD 2008/09/08 --------------------------------<<<<<
            // --- DEL 2008/09/24 --------------------------------<<<<<
            if ((e.PrevCtrl == this.tNedit_CustomerCode_Ed) && (this.tNedit_CustomerCode_Ed.GetInt() == 0))
            {
                this.tNedit_CustomerCode_Ed.Clear();
            }
            // --- DEL 2008/10/22 -------------------------------->>>>>
            // --- ADD 2008/10/02 -------------------------------->>>>>
            //if ((e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            //    && this.tNedit_CustomerCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_CustomerCode_Ed.ExtEdit.Column))))
            //{
            //    // �ő�l�̏ꍇ�A�N���A����
            //    this.tNedit_CustomerCode_Ed.Clear();
            //}
            // --- ADD 2008/10/02 --------------------------------<<<<<
            // --- DEL 2008/10/22 --------------------------------<<<<<
            // --- ADD 2008/09/08 -------------------------------->>>>>
            // --- DEL 2008/09/30 -------------------------------->>>>>
            //else if ((e.PrevCtrl == this.tNedit_CustomerCode_Ed) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            //{
            //    e.NextCtrl = this.OrderUnit_ultraOptionSet;
            //}
            // --- DEL 2008/09/30 --------------------------------<<<<<
            // --- DEL 2008/12/05 -------------------------------->>>>>
            //if ((e.PrevCtrl == this.tNedit_ExtractCode_St) && (this.tNedit_ExtractCode_St.GetInt() == 0))
            //{
            //    this.tNedit_ExtractCode_St.Clear();
            //}
            //// --- DEL 2008/09/30 -------------------------------->>>>>
            ////else if ((e.PrevCtrl == this.tNedit_ExtractCode_St) && (this.tNedit_ExtractCode_St.GetInt() != 0))
            ////{
            ////    e.NextCtrl = this.tNedit_ExtractCode_Ed;
            ////}
            //// --- DEL 2008/09/30 -------------------------------->>>>>

            //if ((e.PrevCtrl == this.tNedit_ExtractCode_Ed) && (this.tNedit_ExtractCode_Ed.GetInt() == 0))
            //{
            //    this.tNedit_ExtractCode_Ed.Clear();
            //}
            // --- DEL 2008/12/05 --------------------------------<<<<<
            // --- DEL 2008/10/22 -------------------------------->>>>>
            // --- ADD 2008/10/02 -------------------------------->>>>>
            //if ((e.PrevCtrl == this.tNedit_ExtractCode_Ed)
            //    && this.tNedit_ExtractCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_ExtractCode_Ed.ExtEdit.Column))))
            //{
            //    // �ő�l�̏ꍇ�A�N���A����
            //    this.tNedit_ExtractCode_Ed.Clear();
            //}
            // --- ADD 2008/10/02 --------------------------------<<<<< 
            // --- DEL 2008/10/22 --------------------------------<<<<<
            // --- DEL 2008/09/30 -------------------------------->>>>>
            //else if ((e.PrevCtrl == this.tNedit_ExtractCode_Ed) && (this.tNedit_ExtractCode_Ed.GetInt() != 0))
            //{
            //    e.NextCtrl = this.tNedit_CustomerCode_St;
            //}
            // --- DEL 2008/09/30 --------------------------------<<<<<
            // --- ADD 2008/09/08 --------------------------------<<<<<
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<

            // �n��R�[�h
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((e.PrevCtrl == this.SalesAreaCodeSt_Nedit) && (this.SalesAreaCodeSt_Nedit.GetInt() == 0))
            //{
            //    this.SalesAreaCodeSt_Nedit.SetInt(0);
            //}
            //if ((e.PrevCtrl == this.SalesAreaCodeEd_Nedit) && (this.SalesAreaCodeEd_Nedit.GetInt() == 0))
            //{
            //    this.SalesAreaCodeEd_Nedit.SetInt(9999);
            //}
            //--- DEL 2008.08.14 ---------->>>>>
            //if ((e.PrevCtrl == this.SalesAreaCodeSt_Nedit) && (this.SalesAreaCodeSt_Nedit.GetInt() == 0))
            //{
            //    this.SalesAreaCodeSt_Nedit.Clear();
            //}
            //if ((e.PrevCtrl == this.SalesAreaCodeEd_Nedit) && (this.SalesAreaCodeEd_Nedit.GetInt() == 0))
            //{
            //    this.SalesAreaCodeEd_Nedit.Clear();
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<

            // �Ǝ�R�[�h
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((e.PrevCtrl == this.BusinessTypeCodeSt_Nedit) && (this.BusinessTypeCodeSt_Nedit.GetInt() == 0))
            //{
            //    this.BusinessTypeCodeSt_Nedit.SetInt(0);
            //}
            //if ((e.PrevCtrl == this.BusinessTypeCodeEd_Nedit) && (this.BusinessTypeCodeEd_Nedit.GetInt() == 0))
            //{
            //    this.BusinessTypeCodeEd_Nedit.SetInt(9999);
            //}
            //--- DEL 2008.08.14 ---------->>>>>
            //if ((e.PrevCtrl == this.BusinessTypeCodeSt_Nedit) && (this.BusinessTypeCodeSt_Nedit.GetInt() == 0))
            //{
            //    this.BusinessTypeCodeSt_Nedit.Clear();
            //}
            //if ((e.PrevCtrl == this.BusinessTypeCodeEd_Nedit) && (this.BusinessTypeCodeEd_Nedit.GetInt() == 0))
            //{
            //    this.BusinessTypeCodeEd_Nedit.Clear();
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<

            // �]�ƈ��R�[�h
			//if ((e.PrevCtrl == this.EmployeeCodeSt_tEdit) ||
			//	(e.PrevCtrl == this.EmployeeCodeEd_tEdit))
			//{
			//	AutoSetEndValue(this.EmployeeCodeSt_tEdit, this.EmployeeCodeEd_tEdit);
			//}

            // ���[�J�[�R�[�h
            // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((e.PrevCtrl == this.GoodsMakerCdSt_Nedit) && (this.GoodsMakerCdSt_Nedit.GetInt() == 0))
            //{
            //    this.GoodsMakerCdSt_Nedit.SetInt(0);
            //}
            //if ((e.PrevCtrl == this.GoodsMakerCdEd_Nedit) && (this.GoodsMakerCdEd_Nedit.GetInt() == 0))
            //{
            //    this.GoodsMakerCdEd_Nedit.SetInt(999999);
            //}
            //--- DEL 2008.08.14 ---------->>>>>
            //if ((e.PrevCtrl == this.GoodsMakerCdSt_Nedit) && (this.GoodsMakerCdSt_Nedit.GetInt() == 0))
            //{
            //    this.GoodsMakerCdSt_Nedit.Clear();
            //}
            //if ((e.PrevCtrl == this.GoodsMakerCdEd_Nedit) && (this.GoodsMakerCdEd_Nedit.GetInt() == 0))
            //{
            //    this.GoodsMakerCdEd_Nedit.Clear();
            //}
            //--- DEL 2008.08.14 ----------<<<<<
            // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            // --- ADD 2008/12/04 -------------------------------->>>>>
            // ���ʕt�ݒ�ő�l
            if (e.PrevCtrl == this.OrderRange_Nedit
                && (string.IsNullOrEmpty(this.OrderRange_Nedit.Text)
                    || this.OrderRange_Nedit.GetInt() == 0))
            {
                this.OrderRange_Nedit.SetInt(1);
            }
            // --- ADD 2008/12/04 --------------------------------<<<<<

            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (e.PrevCtrl == this.OrderAppointment_tComboEditor)
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Right:
                        case Keys.Tab:
                        case Keys.Enter:
                            {
                                this.OrderAppointment_tComboEditor.SelectAll();
                                if (this.OrderAppointment_tComboEditor.Text.Equals("0") 
                                    || this.OrderAppointment_tComboEditor.Text.Equals("1")
                                    || this.OrderAppointment_tComboEditor.Text.Equals("2"))
                                {
                                    int index = Convert.ToInt32(this.OrderAppointment_tComboEditor.Text);
                                    this.OrderAppointment_tComboEditor.SelectedText = this.OrderAppointment_tComboEditor.Items[index].DisplayText;
                                }

                                this.OrderAppointment_tComboEditor.SelectAll();
                                this.OrderAppointment_tComboEditor.SelectedText = this.OrderAppointment_tComboEditor.Text;
                                // --- ADD 2010/08/26 ---------->>>>>
                                if (this.ParentPrintCall != null)
                                {
                                    this.ParentPrintCall();
                                }
                                // --- ADD 2010/08/26 ----------<<<<<
                                e.NextCtrl = null;
                                break;
                            }
                    }
                }
            }

            #region focus
            if (!e.ShiftKey)
            {
                if (e.Key == Keys.Right || e.Key==Keys.Enter)
                {
                    if (e.PrevCtrl == this.TtlType_ultraOptionSet)
                    {
                        e.NextCtrl = this.TargetDateSt_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.TargetDateEd_tDateEdit)
                    {
                        e.NextCtrl = this.PrintType_ultraOptionSet;
                        this.PrintType_ultraOptionSet.FocusedIndex = (int)this.PrintType_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintType_ultraOptionSet)
                    {
                        e.NextCtrl = this.ConstUnit_ultraOptionSet;
                        this.ConstUnit_ultraOptionSet.FocusedIndex = (int)this.ConstUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.ConstUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    /* ----- DEL zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.MoneyUnit_ultraOptionSet)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                            switch (this._selPrintModeName)
                            {
                                case CT_SelPrintModeName_Customer:
                                case CT_SelPrintModeName_SalesEmployee:
                                case CT_SelPrintModeName_FrontEmployee:
                                case CT_SelPrintModeName_SalesInput:
                                case CT_SelPrintModeName_Area:
                                case CT_SelPrintModeName_BusinessType:
                                    {
                                        e.NextCtrl = this.PrintOder_tComboEditor;
                                        break;
                                    }
                                default:
                                    {
                                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                                        break;
                                    }
                            }
                        }
                    }
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor || e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                            case CT_SelPrintModeName_SalesEmployee:
                            case CT_SelPrintModeName_FrontEmployee:
                            case CT_SelPrintModeName_SalesInput:
                            case CT_SelPrintModeName_Area:
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.PrintOder_tComboEditor;
                                    break;
                                }
                            default:
                                {
                                    e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                    this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                                    break;
                                }
                        }
                    }
                       ----- DEL zhuhh 2012/12/28 for Redmine #34098 -----<<<<< */
                    /*  ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.MoneyUnit_ultraOptionSet)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                        }
                    }
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor)
                            {
                        if(this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                                    {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                                    }
                        else
                                    {
                            e.NextCtrl=this.tComboEditor_LineMaSqOfCh;
                            }
                        }
                    else if (e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditorLineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditorLineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                        ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<< */
                    // ----- ADD cheq 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.MoneyUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                    }
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor)
                    {
                        if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                            if (this.PrintOder_tComboEditor.Enabled && this.PrintOder_tComboEditor.Visible)
                            {
                                e.NextCtrl = this.PrintOder_tComboEditor;
                            }
                            else
                            {
                                e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                            }
                        }
                    }
                    else if (e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditorLineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditorLineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                        // ----- ADD cheq 2012/12/28 for Redmine #34098 -----<<<<<
                            switch (this._selPrintModeName)
                            {
                                case CT_SelPrintModeName_Customer:
                                case CT_SelPrintModeName_SalesEmployee:
                                case CT_SelPrintModeName_FrontEmployee:
                                case CT_SelPrintModeName_SalesInput:
                                case CT_SelPrintModeName_Area:
                                case CT_SelPrintModeName_BusinessType:
                                    {
                                        e.NextCtrl = this.PrintOder_tComboEditor;
                                        break;
                                    }
                                default:
                                    {
                                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                                        break;
                                    }
                            }
                        }
                    }
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintOrder_ultraOptionSet)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_St;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesEmployee:
                                {
                                    e.NextCtrl = this.tEdit_SalesEmployeeCode_St;
                                    break;
                                }
                            case CT_SelPrintModeName_FrontEmployee:
                                {
                                    e.NextCtrl = this.tEdit_FrontEmployeeCode_St;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesInput:
                                {
                                    e.NextCtrl = this.tEdit_SalesInputCode_St;
                                    break;
                                }
                            case CT_SelPrintModeName_Area:
                                {
                                    e.NextCtrl = this.tNedit_SalesAreaCode_St;
                                    break;
                                }
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_St;
                                    break;
                                }
                            default:
                                {
                                    e.NextCtrl = this.tNedit_SalesCode_St;
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        e.NextCtrl = this.OrderUnit_ultraOptionSet;
                        this.OrderUnit_ultraOptionSet.FocusedIndex = (int)this.OrderUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_Ed)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.OrderUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.OrderMethod_ultraOptionSet;
                        this.OrderMethod_ultraOptionSet.FocusedIndex = (int)this.OrderMethod_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderMethod_ultraOptionSet)
                    {
                        e.NextCtrl = this.OrderRange_Nedit;
                    }
                    else if (e.PrevCtrl == this.OrderRange_Nedit)
                    {
                        e.NextCtrl = this.OrderAppointment_tComboEditor;
                    }
                    else if (e.PrevCtrl == this.OrderAppointment_tComboEditor)
                    {
                        // --- UPD 2010/08/26 ---------->>>>>
                        e.NextCtrl = null;
                        // --- UPD 2010/08/26 ----------<<<<<
                    }
                }
                else if (e.Key == Keys.Left)
                {
                    if (e.PrevCtrl == this.TtlType_ultraOptionSet)
                    {
                        e.NextCtrl = null;
                    }
                    else if (e.PrevCtrl == this.TargetDateSt_tDateEdit)
                    {
                        e.NextCtrl = this.TtlType_ultraOptionSet;
                        this.TtlType_ultraOptionSet.FocusedIndex = (int)this.TtlType_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintType_ultraOptionSet)
                    {
                        e.NextCtrl = this.TargetDateEd_tDateEdit.Controls[4];
                    }
                    else if (e.PrevCtrl == this.ConstUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.PrintType_ultraOptionSet;
                        this.PrintType_ultraOptionSet.FocusedIndex = (int)this.PrintType_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.MoneyUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.ConstUnit_ultraOptionSet;
                        this.ConstUnit_ultraOptionSet.FocusedIndex = (int)this.ConstUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    /* ----- DEL zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor || e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else if (this.CrMode2_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        }
                    }
                       ----- DEL zhuhh 2012/12/28 for Redmine #34098 -----<<<<< */
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor)
                    {
                        // DEL cheq 2013/03/08 for Redmine #34987 ---- >>>>>
                        //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        // DEL cheq 2013/03/08 for Redmine #34987 ---- <<<<<
                        this.tComboEditor_LineMaSqOfCh.Focus(); // ADD cheq 2013/03/08 for Redmine #34987 
                    }
                    else if (e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else 
                        {
                            // DEL cheq 2013/03/08 for Redmine #34987 ---- >>>>>
                            //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                            // DEL cheq 2013/03/08 for Redmine #34987 ---- <<<<<
                            this.tComboEditor_LineMaSqOfCh.Focus();// ADD cheq 2013/03/08 for Redmine #34987 
                        }
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditorLineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditorLineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                        /* ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else
                        {
                         ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<< */
                            e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                            //}//DEL cheq 2013/03/08 for Redmine #34987
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                    }
                        else
                    {
                            // ----- ADD cheq for Redmine #34987 -----<<<<<
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                        } // ADD cheq 2013/03/08 for Redmine #34987
                    }
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                    else if (e.PrevCtrl == this.PrintOrder_ultraOptionSet)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                            case CT_SelPrintModeName_SalesEmployee:
                            case CT_SelPrintModeName_FrontEmployee:
                            case CT_SelPrintModeName_SalesInput:
                            case CT_SelPrintModeName_Area:
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.PrintOder_tComboEditor;
                                    break;
                                }
                            default:
                                {
                                    if (this.CrMode1_ultraCheckEditor.Enabled)
                                    {
                                        e.NextCtrl = this.CrMode1_ultraCheckEditor;
                                    }
                                    else
                                    {
                                        // ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                                        //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                                        //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                                        // ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                                        this.tComboEditor_LineMaSqOfCh.Focus();// ADD cheq 2013/03/08 for Redmine #34987
                                    }
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                                {
                                    e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                    this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesEmployee:
                                {
                                    e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_FrontEmployee:
                                {
                                    e.NextCtrl = this.tEdit_FrontEmployeeCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesInput:
                                {
                                    e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_Area:
                                {
                                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                                    break;
                                }
                            default:
                                {
                                    e.NextCtrl = this.tNedit_SalesCode_Ed;
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.OrderMethod_ultraOptionSet)
                    {
                        e.NextCtrl = this.OrderUnit_ultraOptionSet;
                        this.OrderUnit_ultraOptionSet.FocusedIndex = (int)this.OrderUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderRange_Nedit)
                    {
                        e.NextCtrl = this.OrderMethod_ultraOptionSet;
                        this.OrderMethod_ultraOptionSet.FocusedIndex = (int)this.OrderMethod_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderAppointment_tComboEditor)
                    {
                        e.NextCtrl = this.OrderRange_Nedit;
                    }
                }
                // ----- ADD cheq 2013/03/08 for Redmine#34987 ----->>>>>
                else if (e.Key == Keys.Up)
                {
                    if (e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                    }
                }
                // ----- ADD cheq 2013/03/08 for Redmine#34987 -----<<<<<
            }
            if (e.ShiftKey)
            {
                if (e.Key == Keys.Enter)
                {
                    if (e.PrevCtrl == this.TtlType_ultraOptionSet)
                    {
                        e.NextCtrl = null;
                    }
                    else if (e.PrevCtrl == this.TargetDateSt_tDateEdit)
                    {
                        e.NextCtrl = this.TtlType_ultraOptionSet;
                        this.TtlType_ultraOptionSet.FocusedIndex = (int)this.TtlType_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintType_ultraOptionSet)
                    {
                        e.NextCtrl = this.TargetDateEd_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.ConstUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.PrintType_ultraOptionSet;
                        this.PrintType_ultraOptionSet.FocusedIndex = (int)this.PrintType_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.MoneyUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.ConstUnit_ultraOptionSet;
                        this.ConstUnit_ultraOptionSet.FocusedIndex = (int)this.ConstUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    /* ----- DEL zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor || e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else if (this.CrMode2_ultraCheckEditor.Enabled)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        }
                    }
                       ----- DEL zhuhh 2012/12/28 for Redmine #34098 -----<<<<<  */
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                    else if (e.PrevCtrl == this.CrMode1_ultraCheckEditor)
                    {
                        // ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        // ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // ADD cheq 2013/03/08 for Redmine #34987
                    }
                    else if (e.PrevCtrl == this.CrMode2_ultraCheckEditor)
                    {
                        if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else
                        {
                            // ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                            //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                            // ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<<
                            e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // ADD cheq 2013/03/08 for Redmine #34987
                        }
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LineMaSqOfCh)
                    {
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
                        bool errorFlag = true;
                        foreach (Infragistics.Win.ValueListItem item in this.tComboEditor_LineMaSqOfCh.Items)
                        {
                            if (item.DataValue == this.tComboEditor_LineMaSqOfCh.Value)
                            {
                                errorFlag = false;
                                break;
                            }
                        }
                        if (errorFlag)
                        {
                            this.tComboEditor_LineMaSqOfCh.Value = this._preComboEditorLineMaSqOfChValue;
                        }
                        else
                        {
                            this._preComboEditorLineMaSqOfChValue = this.tComboEditor_LineMaSqOfCh.Value;
                        }
                        /* ----- DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                        if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode1_ultraCheckEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                            this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        }
                        ----- DEL cheq 2013/03/08 for Redmine #34987 -----<<<<< */
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                        this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                        // ----- ADD cheq 2013/03/08 for Redmine #34987-----<<<<<
                    }
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        //e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // DEL cheq 2013/03/08 for Redmine #34987
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 ----->>>>>
                        if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl = this.CrMode2_ultraCheckEditor;
                        }
                        else if (this.CrMode1_ultraCheckEditor.Enabled && this.CrMode1_ultraCheckEditor.Visible)
                        {
                            e.NextCtrl=this.CrMode1_ultraCheckEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.tComboEditor_LineMaSqOfCh;
                        }
                        // ----- ADD cheq 2013/03/08 for Redmine #34987 -----<<<<<
                    }
                    // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<
                    else if (e.PrevCtrl == this.PrintOrder_ultraOptionSet)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                            case CT_SelPrintModeName_SalesEmployee:
                            case CT_SelPrintModeName_FrontEmployee:
                            case CT_SelPrintModeName_SalesInput:
                            case CT_SelPrintModeName_Area:
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.PrintOder_tComboEditor;
                                    break;
                                }
                            default:
                                {
                                    if (this.CrMode1_ultraCheckEditor.Enabled)
                                    {
                                        e.NextCtrl = this.CrMode1_ultraCheckEditor;
                                    }
                                    else
                                    {
                                        // ----- DEL cheq 2013/03/08 for Redmine#34987 ----->>>>>
                                        //e.NextCtrl = this.MoneyUnit_ultraOptionSet;
                                        //this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                                        // ----- DEL cheq 2013/03/08 for Redmine#34987 -----<<<<<
                                        e.NextCtrl = this.tComboEditor_LineMaSqOfCh; // ADD cheq 2013/03/08 for Redmine#34987
                                    }
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        switch (this._selPrintModeName)
                        {
                            case CT_SelPrintModeName_Customer:
                                {
                                    e.NextCtrl = this.PrintOrder_ultraOptionSet;
                                    this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesEmployee:
                                {
                                    e.NextCtrl = this.tEdit_SalesEmployeeCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_FrontEmployee:
                                {
                                    e.NextCtrl = this.tEdit_FrontEmployeeCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_SalesInput:
                                {
                                    e.NextCtrl = this.tEdit_SalesInputCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_Area:
                                {
                                    e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                                    break;
                                }
                            case CT_SelPrintModeName_BusinessType:
                                {
                                    e.NextCtrl = this.tNedit_BusinessTypeCode_Ed;
                                    break;
                                }
                            default:
                                {
                                    e.NextCtrl = this.tNedit_SalesCode_Ed;
                                    break;
                                }
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesEmployeeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tEdit_FrontEmployeeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tEdit_SalesInputCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_BusinessTypeCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesCode_St)
                    {
                        e.NextCtrl = this.PrintOrder_ultraOptionSet;
                        this.PrintOrder_ultraOptionSet.FocusedIndex = (int)this.PrintOrder_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderUnit_ultraOptionSet)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.OrderMethod_ultraOptionSet)
                    {
                        e.NextCtrl = this.OrderUnit_ultraOptionSet;
                        this.OrderUnit_ultraOptionSet.FocusedIndex = (int)this.OrderUnit_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderRange_Nedit)
                    {
                        e.NextCtrl = this.OrderMethod_ultraOptionSet;
                        this.OrderMethod_ultraOptionSet.FocusedIndex = (int)this.OrderMethod_ultraOptionSet.CheckedItem.DataValue;
                    }
                    else if (e.PrevCtrl == this.OrderAppointment_tComboEditor)
                    {
                        e.NextCtrl = this.OrderRange_Nedit;
                    }
                }
                else if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.TtlType_ultraOptionSet)
                    {
                        e.NextCtrl = null;
                    }
                }
            }
            #endregion

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_SalesEmployeeCode_St":
                    case "tEdit_SalesEmployeeCode_Ed":
                    case "tEdit_FrontEmployeeCode_St":
                    case "tEdit_FrontEmployeeCode_Ed":
                    case "tEdit_SalesInputCode_St":
                    case "tEdit_SalesInputCode_Ed":
                    case "tNedit_SalesAreaCode_St":
                    case "tNedit_SalesAreaCode_Ed":
                    case "tNedit_BusinessTypeCode_St":
                    case "tNedit_BusinessTypeCode_Ed":
                    case "tNedit_SalesCode_St":
                    case "tNedit_SalesCode_Ed":
                    case "tNedit_CustomerCode_St":
                    case "tNedit_CustomerCode_Ed":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

		/// <summary>
		/// �����^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note		: �����������s���܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// ��ʏ����\��
			this.InitialScreenSetting();

			// �����t�H�[�J�X�ݒ�
            this.TtlType_ultraOptionSet.Focus();
            this.TtlType_ultraOptionSet.FocusedIndex = (int)this.TtlType_ultraOptionSet.Value;  // ADD 2008/03/31 �s��Ή�[12924]�`[12926]�F�X�y�[�X�L�[�ł̍��ڑI���@�\������

			// ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

        /// <summary>
        /// �o�͏��ύX�������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        private void PrintOder_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {
            Point point = new Point();
            point.X = 0;
            point.Y = 7;

            /* --- DEL 2008/09/08 -------------------------------->>>>>
            switch (this.PrintOder_tComboEditor.SelectedIndex)
            {
                //--- DEL 2008.08.14 ---------->>>>>
                //case 0: // ���Ӑ�
                //    {
                //        this.CrMode2_ultraCheckEditor.Visible = false;

                //        this.SalesArea_panel.Visible = false;
                //        this.BusinessType_panel.Visible = false;
                //        this.Customer_panel.Location = point;
                //        break;
                //    }
                //case 1: // �n��
                //    {
                //        this.CrMode2_ultraCheckEditor.Text = "�n��" + this._crModeText;
                //        this.CrMode2_ultraCheckEditor.Visible = true;

                //        this.SalesArea_panel.Location = point;
                //        this.SalesArea_panel.Visible = true;
                //        this.BusinessType_panel.Visible = false;

                //        point.Y = point.Y + 30;
                //        this.Customer_panel.Location = point;
                //        break;
                //    }
                //case 2: // �Ǝ�
                //    {
                //        this.CrMode2_ultraCheckEditor.Text = "�Ǝ�" + this._crModeText;
                //        this.CrMode2_ultraCheckEditor.Visible = true;

                //        this.SalesArea_panel.Visible = false;
                //        this.BusinessType_panel.Location = point;
                //        this.BusinessType_panel.Visible = true;

                //        point.Y = point.Y + 30;
                //        this.Customer_panel.Location = point;
                //        break;
                //    }
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                case CT_SelPrintMode_Customer: // ���Ӑ�
                    {
                        this.CrMode1_ultraCheckEditor.Text = "���_���ŉ���";
                        if ((int)TtlType_ultraOptionSet.Value == 1)
                        {
                            this.CrMode1_ultraCheckEditor.Enabled = true;
                        }
                        break;
                    }
                
                case 1: // ���_
                    {
                        this.CrMode1_ultraCheckEditor.Text = "���_���ŉ���";
                        this.CrMode1_ultraCheckEditor.Checked = false;
                        this.CrMode1_ultraCheckEditor.Enabled = false;
                        break;
                    }
                case 2: // ���Ӑ�|���_
                    {
                        this.CrMode1_ultraCheckEditor.Text = "���Ӑ斈�ŉ���";
                        if ((int)TtlType_ultraOptionSet.Value == 1)
                        {
                            this.CrMode1_ultraCheckEditor.Enabled = true;
                        }
                        break;
                    }
                case 3: // �Ǘ����_
                    {
                        this.CrMode1_ultraCheckEditor.Text = "���_���ŉ���";
                        if ((int)TtlType_ultraOptionSet.Value == 1)
                        {
                            this.CrMode1_ultraCheckEditor.Enabled = true;
                        }
                        break;
                    }
                case 4: // ������
                    {
                        this.CrMode1_ultraCheckEditor.Text = "���_���ŉ���";
                        if ((int)TtlType_ultraOptionSet.Value == 1)
                        {
                            this.CrMode1_ultraCheckEditor.Enabled = true;
                        }
                        break;
                    }
                //--- ADD 2008.08.14 ----------<<<<<
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */
            // --- ADD 2008/09/08 -------------------------------->>>>>
            // ��ʕ\��������s
            this.ScreenSetting();
            // --- ADD 2008/09/08 --------------------------------<<<<<
        }

        /// <summary>
        /// ���Ń`�F�b�N�������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        private void CrMode1_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            //--- DEL 2008.08.14 ---------->>>>>
            //if (CrMode2_ultraCheckEditor.Visible == true)
            //{
            //    // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //if (CrMode1_ultraCheckEditor.Checked == false)
            //    if ((this.CrMode1_ultraCheckEditor.Checked == false) &&
            //        (this.CrMode1_ultraCheckEditor.Enabled == true))
            //    // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //    {
            //        CrMode2_ultraCheckEditor.Checked = false;
            //    }
            //}
            //--- DEL 2008.08.14 ----------<<<<<
        }

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>
        /// ���ŏ���2�`�F�b�N�������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        private void CrMode2_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // ��ʕ\��������s
            this.ScreenSetting();
        }
        // --- ADD 2008/09/08 --------------------------------<<<<<

        //--- DEL 2008.08.14 ---------->>>>>
        ///// <summary>
        ///// ���Ń`�F�b�N�������C�x���g
        ///// </summary>
        ///// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g����</param>
        //private void CrMode2_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CrMode2_ultraCheckEditor.Checked == true)
        //    {
        //        // 2008.03.05 �C�� >>>>>>>>>>>>>>>>>>>>
        //        //CrMode1_ultraCheckEditor.Checked = true;
        //        if (this.CrMode1_ultraCheckEditor.Enabled == true)
        //        {
        //            CrMode1_ultraCheckEditor.Checked = true;
        //        }
        //        // 2008.03.05 �C�� <<<<<<<<<<<<<<<<<<<<
        //    }
        //}
        //--- DEL 2008.08.14 ----------<<<<<

        /// <summary>
		/// Control.GroupCollapsing�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note		: �G�N�X�v���[���o�[�̃O���[�v��W�J�����ۂɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.12.07</br>
        /// </remarks>
		private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if (this._explorerBarExpanding) return;

			this._explorerBarExpanding = true;

			try
			{
				if (!e.Group.Key.Equals(EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
				{
					e.Cancel = true;
				}
			}
			finally
			{
				this._explorerBarExpanding = false;
			}
		}

		/// <summary>
		/// ���Ӑ�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
		private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

			int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
				this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                this._customerGuidOK = true; // ADD 2008/12/04
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���Ӑ���̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

				return;
			}
		}

		/// <summary>
		/// ���Ӑ�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
		private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

			int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
				this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                this._customerGuidOK = true; // ADD 2008/12/04
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
					status,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"���Ӑ���̎擾�Ɏ��s���܂����B",
					status,
					MessageBoxButtons.OK);

				return;
			}
		}

        // 2008.03.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �W�v���@���͒l�ύX�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �W�v���@�̓��͒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 980035 ����@��`</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        private void TtlType_ultraOptionSet_ValueChanged(object sender, EventArgs e)
        {
            /* --- DEL 2008/09/08 -------------------------------->>>>>
            if (this.TtlType_ultraOptionSet.CheckedIndex == 0)
            {
                this.CrMode1_ultraCheckEditor.Enabled = false;
                this.CrMode1_ultraCheckEditor.Checked = false;
            }
            else
            {
                //--- DEL 2008.08.14 ---------->>>>>
                //this.CrMode1_ultraCheckEditor.Enabled = true;

                //if (this.CrMode2_ultraCheckEditor.Checked == true)
                //{
                //    CrMode1_ultraCheckEditor.Checked = true;
                //}
                //--- DEL 2008.08.14 ----------<<<<<
                //--- ADD 2008.08.14 ---------->>>>>
                if (PrintOder_tComboEditor.SelectedIndex != 1)
                {
                    this.CrMode1_ultraCheckEditor.Enabled = true;
                }
                //--- ADD 2008.08.14 ----------<<<<<
            }
            --- DEL 2008/09/08 -------------------------------->>>>> */

            // --- ADD 2008/09/08 -------------------------------->>>>>
            // ��ʕ\��������s
            this.ScreenSetting();
            // --- ADD 2008/09/08 --------------------------------<<<<<
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programer  : 980035 ����@��`</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing_1(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == EXPLORERBAR_CUSTOMERCONDITIONGROUP_KEY) ||
                (e.Group.Key == EXPLORERBAR_PRINTODERGROUP_KEY) ||
                (e.Group.Key == EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�W�J �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���W�J�����O�ɔ������܂��B</br>
        /// <br>Programer  : 980035 ����@��`</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == EXPLORERBAR_CUSTOMERCONDITIONGROUP_KEY) ||
                (e.Group.Key == EXPLORERBAR_PRINTODERGROUP_KEY) ||
                (e.Group.Key == EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        // 2008.03.05 �ǉ� <<<<<<<<<<<<<<<<<<<<

        #region ���K�C�h�N���C�x���g
		/// <summary>
		/// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
		private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            //--- DEL 2008.08.14 ---------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            //--- DEL 2008.08.14 ----------<<<<<
            this._customerGuidOK = false; // ADD 2008/12/04
            //--- ADD 2008.08.14 ---------->>>>>
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            //--- ADD 2008.08.14 ----------<<<<<

            if (this._customerGuidOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
                // --- ADD 2010/08/12 -------------------------------->>>>>
                ParentToolbarGuideSettingEvent(true);
                // --- ADD 2010/08/12 --------------------------------<<<<<
            }
		}

		/// <summary>
		/// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
		private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
            //--- DEL 2008.08.14 ---------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            //--- DEL 2008.08.14 ----------<<<<<
            this._customerGuidOK = false; // ADD 2008/12/04
            //--- ADD 2008.08.14 ---------->>>>>
            // ���Ӑ�K�C�h
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            //--- ADD 2008.08.14 ----------<<<<<

            if (this._customerGuidOK)
            {
                this.OrderUnit_ultraOptionSet.Focus();
                // --- ADD 2010/08/12 -------------------------------->>>>>
                ParentToolbarGuideSettingEvent(false);
                // --- ADD 2010/08/12 --------------------------------<<<<<
            }
		}

        // --- DEL 2008/12/05 -------------------------------->>>>>
        //// --- ADD 2008/09/08 -------------------------------->>>>>
        ///// <summary>
        ///// �K�C�h�N���{�^��1�N���C�x���g
        ///// </summary>
        //private void ExtractUltraButton1_Click(object sender, EventArgs e)
        //{
        //    // �K�C�h�Ԃ�l
        //    int status = -1;

        //    switch (this._selPrintMode)
        //    {
        //        case CT_SelPrintMode_SalesEmployee: // �S����
        //        case CT_SelPrintMode_FrontEmployee: // �󒍎�
        //        case CT_SelPrintMode_SalesInput: // ���s��
        //            {
        //                // �K�C�h�N��
        //                Employee employee = new Employee();
        //                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_St.DataText = employee.EmployeeCode.TrimEnd();
        //                    this.tNedit_ExtractCode_Ed.Focus(); // ADD 2008/12/04
        //                }
        //                break;
        //            }
        //        case CT_SelPrintMode_Area: // �n��
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_St.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_ExtractCode_Ed.Focus(); // ADD 2008/12/04
        //                }

        //                break;
        //            }
        //        case CT_SelPrintMode_BusinessType: // �Ǝ�
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_St.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_ExtractCode_Ed.Focus(); // ADD 2008/12/04
        //                }
        //                break;
        //            }
        //        case CT_SelPrintMode_SalesDivision: // �̔��敪
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_St.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_ExtractCode_Ed.Focus(); // ADD 2008/12/04
        //                }

        //                break;
        //            }
        //    }
        //}

        ///// <summary>
        ///// �K�C�h�N���{�^��2�N���C�x���g
        ///// </summary>
        //private void ExtractUltraButton2_Click(object sender, EventArgs e)
        //{
        //    // �K�C�h�Ԃ�l
        //    int status = -1;

        //    switch (this._selPrintMode)
        //    {
        //        case CT_SelPrintMode_SalesEmployee: // �S����
        //        case CT_SelPrintMode_FrontEmployee: // �󒍎�
        //        case CT_SelPrintMode_SalesInput: // ���s��
        //            {
        //                // �K�C�h�N��
        //                Employee employee = new Employee();
        //                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
        //                    this.tNedit_CustomerCode_St.Focus(); // ADD 2008/12/04
        //                }
        //                break;
        //            }
        //        case CT_SelPrintMode_Area: // �n��
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_Ed.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_CustomerCode_St.Focus(); // ADD 2008/12/04
        //                }

        //                break;
        //            }
        //        case CT_SelPrintMode_BusinessType: // �Ǝ�
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_Ed.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_CustomerCode_St.Focus(); // ADD 2008/12/04
        //                }
        //                break;
        //            }
        //        case CT_SelPrintMode_SalesDivision: // �̔��敪
        //            {
        //                // �K�C�h�N��
        //                UserGdBd userGdBd = new UserGdBd();
        //                UserGdHd userGdHd = new UserGdHd();
        //                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);

        //                // ���ڂɓW�J
        //                if (status == 0)
        //                {
        //                    this.tNedit_ExtractCode_Ed.SetInt(userGdBd.GuideCode);
        //                    this.tNedit_CustomerCode_St.Focus(); // ADD 2008/12/04
        //                }

        //                break;
        //            }
        //    }
        //}
        //// --- ADD 2008/09/08 --------------------------------<<<<<
        // --- DEL 2008/12/05 --------------------------------<<<<<

        // --- ADD 2008/12/05 -------------------------------->>>>>
        /// <summary>
        /// SalesEmployeeSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void SalesEmployeeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            Employee employee = new Employee();
            int status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 -------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //        this.tEdit_SalesEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesEmployeeCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tEdit_SalesEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 --------------------------------<<<<<
            // --- ADD 2010/08/12 -------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SalesEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesEmployeeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tEdit_SalesEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tEdit_SalesEmployeeCode_St.Focused)
                    {
                        this.tEdit_SalesEmployeeCode_St.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tEdit_SalesEmployeeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tEdit_SalesEmployeeCode_Ed.Focused)
                    {
                        this.tEdit_SalesEmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 --------------------------------<<<<<
        }

        /// <summary>
        /// FrontEmployeeSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void FrontEmployeeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            Employee employee = new Employee();
            int status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //        this.tEdit_FrontEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_FrontEmployeeCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tEdit_FrontEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_FrontEmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_FrontEmployeeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tEdit_FrontEmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tEdit_FrontEmployeeCode_St.Focused)
                    {
                        this.tEdit_FrontEmployeeCode_St.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tEdit_FrontEmployeeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tEdit_FrontEmployeeCode_Ed.Focused)
                    {
                        this.tEdit_FrontEmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// SalesInputSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void SalesInputSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            Employee employee = new Employee();
            int status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //       this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tEdit_SalesInputCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tEdit_SalesInputCode_St.DataText = employee.EmployeeCode.TrimEnd();
                        this.tEdit_SalesInputCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tEdit_SalesInputCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tEdit_SalesInputCode_St.Focused)
                    {
                        this.tEdit_SalesInputCode_St.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tEdit_SalesInputCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tEdit_SalesInputCode_Ed.Focused)
                    {
                        this.tEdit_SalesInputCode_Ed.Text = employee.EmployeeCode.TrimEnd().PadLeft(4, '0');
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// SalesAreaSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void SalesAreaSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //        this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
            //        this.tNedit_SalesAreaCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesAreaCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tNedit_SalesAreaCode_St.Focused)
                    {
                        this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesAreaCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tNedit_SalesAreaCode_Ed.Focused)
                    {
                        this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// BusinessTypeSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void BusinessTypeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //        this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
            //        this.tNedit_BusinessTypeCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tNedit_BusinessTypeCode_St.Focused)
                    {
                        this.tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_BusinessTypeCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tNedit_BusinessTypeCode_Ed.Focused)
                    {
                        this.tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }

        /// <summary>
        /// SalesCodeSt_GuideBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>UpdateNote : 2010/08/12 caowj</br>
        /// <br>              PM1012�Ή�</br>
        private void SalesCodeSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // �K�C�h�N��
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);

            // ���ڂɓW�J
            // --- DEL 2010/08/12 ---------------------------------->>>>>
            //if (status == 0)
            //{
            //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            //    {
            //        this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);
            //        this.tNedit_SalesCode_Ed.Focus();
            //    }
            //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            //    {
            //        this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);
            //        this.tNedit_CustomerCode_St.Focus();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            // --- DEL 2010/08/12 ----------------------------------<<<<<
            // --- ADD 2010/08/12 ---------------------------------->>>>>
            if (sender is Infragistics.Win.Misc.UltraButton)
            {
                if (status == 0)
                {
                    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                    {
                        this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                    {
                        this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (status == 0)
                {
                    if (this.tNedit_SalesCode_St.Focused)
                    {
                        this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_Ed.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                    else if (this.tNedit_SalesCode_Ed.Focused)
                    {
                        this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_CustomerCode_St.Focus();
                        ParentToolbarGuideSettingEvent(true);
                    }
                }
            }
            // --- ADD 2010/08/12 ----------------------------------<<<<<
        }
        // --- ADD 2008/12/05 --------------------------------<<<<<

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ�ۑ�����B</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[2];
            if (this.CrMode1_ultraCheckEditor.Checked)
            {
                customizeData[0] = "true";
            }
            else
            {
                customizeData[0] = "false";
            }

            if (this.CrMode2_ultraCheckEditor.Checked)
            {
                customizeData[1] = "true";
            }
            else
            {
                customizeData[1] = "false";
            }
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>���s�����`�F�b�N�{�b�N�X�̏�Ԃ𕜌�����B</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                if (customizeData[0] == "true")
                {
                    this.CrMode1_ultraCheckEditor.Checked = true;
                }
                else
                {
                    this.CrMode1_ultraCheckEditor.Checked = false;
                }

                if (customizeData[1] == "true")
                {
                    this.CrMode2_ultraCheckEditor.Checked = true;
                }
                else
                {
                    this.CrMode2_ultraCheckEditor.Checked = false;
                }
            }
        }
        // --- ADD 2008/09/08 --------------------------------<<<<<

        //--- DEL 2008.08.14 ---------->>>>>
        ///// <summary>
        ///// �]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        ///// </summary>
        //private void EmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // �C���X�^���X����
        //    EmployeeAcs _employeeAcs = new EmployeeAcs();

        //    // �K�C�h�N��
        //    Employee employee = new Employee();
        //    status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

        //    // ���ڂɓW�J
        //    if (status == 0)
        //    {
        //        this.EmployeeCodeSt_tEdit.DataText = employee.EmployeeCode.TrimEnd();
        //    }
        //}

        ///// <summary>
        ///// �]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        ///// </summary>
        //private void EmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    int status = -1;
        //    // �C���X�^���X����
        //    EmployeeAcs _employeeAcs = new EmployeeAcs();

        //    // �K�C�h�N��
        //    Employee employee = new Employee();
        //    status = _employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

        //    // ���ڂɓW�J
        //    if (status == 0)
        //    {
        //        this.EmployeeCodeEd_tEdit.DataText = employee.EmployeeCode.TrimEnd();
        //    }
        //}

        ///// <summary>
        ///// ���[�J�[�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        ///// </summary>
        //private void GoodsMakerCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    // �C���X�^���X����
        //    MakerAcs _makerAcs = new MakerAcs();

        //    //���[�J�[�K�C�h�N��
        //    MakerUMnt makerUMnt = new MakerUMnt();
        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    // ���ڂɓW�J
        //    if (status == 0)
        //    {
        //        this.GoodsMakerCdSt_Nedit.SetInt(makerUMnt.GoodsMakerCd);
        //    }
        //}

        ///// <summary>
        ///// ���[�J�[�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        ///// </summary>
        //private void GoodsMakerCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    // �C���X�^���X����
        //    MakerAcs _makerAcs = new MakerAcs();

        //    //���[�J�[�K�C�h�N��
        //    MakerUMnt makerUMnt = new MakerUMnt();
        //    int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

        //    // ���ڂɓW�J
        //    if (status == 0)
        //    {
        //        this.GoodsMakerCdEd_Nedit.SetInt(makerUMnt.GoodsMakerCd);
        //    }
        //}

        ///// <summary>
        ///// �̔��G���A�R�[�h(�J�n)�K�C�h�{�^���N���C�x���g
        ///// </summary>
        //private void SalesAreaCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    UserGuideGuide _userGuideGuide = new UserGuideGuide();
        //    UserGdBd userGdBd = new UserGdBd();
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        this.SalesAreaCodeSt_Nedit.SetInt(userGdBd.GuideCode);
        //    }
        //}

        ///// <summary>
        ///// �̔��G���A�R�[�h(�I��)�K�C�h�{�^���N���C�x���g
        ///// </summary>
        //private void SalesAreaCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    UserGuideGuide _userGuideGuide = new UserGuideGuide();
        //    UserGdBd userGdBd = new UserGdBd();
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(21, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        this.SalesAreaCodeEd_Nedit.SetInt(userGdBd.GuideCode);
        //    }
        //}

        ///// <summary>
        ///// �Ǝ�R�[�h(�J�n)�K�C�h�{�^���N���C�x���g
        ///// </summary>
        //private void BusinessTypeCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    UserGuideGuide _userGuideGuide = new UserGuideGuide();
        //    UserGdBd userGdBd = new UserGdBd();
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        this.BusinessTypeCodeSt_Nedit.SetInt(userGdBd.GuideCode);
        //    }
        //}

        ///// <summary>
        ///// �Ǝ�R�[�h(�I��)�K�C�h�{�^���N���C�x���g
        ///// </summary>
        //private void BusinessTypeCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    UserGuideGuide _userGuideGuide = new UserGuideGuide();
        //    UserGdBd userGdBd = new UserGdBd();
        //    System.Windows.Forms.DialogResult result = _userGuideGuide.UserGuideGuideShow(33, 0, this._enterpriseCode, ref userGdBd);

        //    if ((result == DialogResult.OK) || (result == DialogResult.Yes))
        //    {
        //        this.BusinessTypeCodeEd_Nedit.SetInt(userGdBd.GuideCode);
        //    }
        //}

        ///// <summary>
        ///// ���_�K�C�h�{�^���N���b�N�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^�N���X</param>
        //private void SectionCdSt_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
        //    SecInfoSet secInfoSet;
        //    int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._isMainOfficeFunc, out secInfoSet);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        SectionCodeSt_tEdit.DataText = secInfoSet.SectionCode.TrimEnd();
        //    }
        //}

        //private void SectionCdEd_GuideBtn_Click(object sender, EventArgs e)
        //{
        //    SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
        //    SecInfoSet secInfoSet;
        //    int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._isMainOfficeFunc, out secInfoSet);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        SectionCodeEd_tEdit.DataText = secInfoSet.SectionCode.TrimEnd();
        //    }
        //}
        //--- DEL 2008.08.14 ----------<<<<<
        #endregion


        #region ��KeyDown
        /// <summary>
        /// TtlType_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TtlType_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.TargetDateSt_tDateEdit.Focus();
            }
        }

        /// <summary>
        /// PrintType_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintType_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.ConstUnit_ultraOptionSet.FocusedIndex = (int)this.ConstUnit_ultraOptionSet.CheckedItem.DataValue;
                this.ConstUnit_ultraOptionSet.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.TargetDateEd_tDateEdit.Controls[4].Focus();
            }
        }

        /// <summary>
        /// ConstUnit_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConstUnit_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                this.MoneyUnit_ultraOptionSet.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.PrintType_ultraOptionSet.FocusedIndex = (int)this.PrintType_ultraOptionSet.CheckedItem.DataValue;
                this.PrintType_ultraOptionSet.Focus();
            }
        }

        /// <summary>
        /// MoneyUnit_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>UpdateNote : 2013/03/08 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10900690-00 2013/03/26�z�M��</br>
        /// <br>           : Redmine#34987 ���[redmine#34098�̎c���̑Ή�</br>
        /// </remarks>
        private void MoneyUnit_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                /* DEL cheq 2013/03/08 for Redmine #34987 ----->>>>>
                if (this.CrMode1_ultraCheckEditor.Enabled)
                {
                    this.CrMode1_ultraCheckEditor.Focus();
                }
                else if (this.CrMode2_ultraCheckEditor.Enabled && this.CrMode2_ultraCheckEditor.Visible)
                {
                    this.CrMode2_ultraCheckEditor.Focus();
                }
                else
                {
                    switch (this._selPrintModeName)
                    {
                        case CT_SelPrintModeName_Customer:
                        case CT_SelPrintModeName_SalesEmployee:
                        case CT_SelPrintModeName_FrontEmployee:
                        case CT_SelPrintModeName_SalesInput:
                        case CT_SelPrintModeName_Area:
                        case CT_SelPrintModeName_BusinessType:
                            {
                                this.PrintOder_tComboEditor.Focus();
                                break;
                            }
                        default:
                            {
                                this.PrintOrder_ultraOptionSet.Focus();
                                break;
                            }
                    }
                }
                 ----- DEL cheq 2013/03/08 for Redmine #34987 */
                this.tComboEditor_LineMaSqOfCh.Focus(); // ADD cheq 2013/03/08 for Redmine #34987
            }
            if (e.KeyCode == Keys.Left)
            {
                this.ConstUnit_ultraOptionSet.FocusedIndex = (int)this.ConstUnit_ultraOptionSet.CheckedItem.DataValue;
                this.ConstUnit_ultraOptionSet.Focus();
            }
        }

        /// <summary>
        /// PrintOrder_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintOrder_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                switch (this._selPrintModeName)
                {
                    case CT_SelPrintModeName_Customer:
                        {
                            this.tNedit_CustomerCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    case CT_SelPrintModeName_SalesEmployee:
                        {
                            this.tEdit_SalesEmployeeCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    case CT_SelPrintModeName_FrontEmployee:
                        {
                            this.tEdit_FrontEmployeeCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    case CT_SelPrintModeName_SalesInput:
                        {
                            this.tEdit_SalesInputCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    case CT_SelPrintModeName_Area:
                        {
                            this.tNedit_SalesAreaCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    case CT_SelPrintModeName_BusinessType:
                        {
                            this.tNedit_BusinessTypeCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            this.tNedit_SalesCode_St.Focus();
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                switch (this._selPrintModeName)
                {
                    case CT_SelPrintModeName_Customer:
                    case CT_SelPrintModeName_SalesEmployee:
                    case CT_SelPrintModeName_FrontEmployee:
                    case CT_SelPrintModeName_SalesInput:
                    case CT_SelPrintModeName_Area:
                    case CT_SelPrintModeName_BusinessType:
                        {
                            this.PrintOder_tComboEditor.Focus();
                            break;
                        }
                    default:
                        {
                            if (this.CrMode1_ultraCheckEditor.Enabled)
                            {
                                this.CrMode1_ultraCheckEditor.Focus();
                            }
                            else
                            {
                                this.MoneyUnit_ultraOptionSet.FocusedIndex = (int)this.MoneyUnit_ultraOptionSet.CheckedItem.DataValue;
                                this.MoneyUnit_ultraOptionSet.Focus();
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// OrderUnit_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderUnit_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.OrderMethod_ultraOptionSet.FocusedIndex = (int)this.OrderMethod_ultraOptionSet.CheckedItem.DataValue;
                this.OrderMethod_ultraOptionSet.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.tNedit_CustomerCode_Ed.Focus();
                ParentToolbarGuideSettingEvent(true);
            }
        }

        /// <summary>
        /// OrderMethod_ultraOptionSet_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderMethod_ultraOptionSet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.OrderRange_Nedit.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.OrderUnit_ultraOptionSet.FocusedIndex = (int)this.OrderUnit_ultraOptionSet.CheckedItem.DataValue;
                this.OrderUnit_ultraOptionSet.Focus();
            }
        }
        #endregion

        #endregion

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        #region Public Event
        /// <summary> �K�C�h�{�^���\����\���ݒ�C�x���g </summary>
        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;
        #endregion
        // --- ADD 2010/08/12 ----------------------------------<<<<<

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
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
        /// <param name="sectionCodeLst"></param>
		/// <remarks>
		/// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
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
        /// <param name="isDefaultState"></param>
        /// <remarks>
        /// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public bool InitVisibleCheckSection(bool isDefaultState)
		{
			return isDefaultState;
		}

		/// <summary>
		/// �v�㋒�_�I��\���擾�v���p�e�B
		/// </summary>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public bool IsMainOfficeFunc
		{
			get { return _isMainOfficeFunc; }
			set { _isMainOfficeFunc = value; }
		}

		/// <summary>
		/// �v�㋒�_�I������
		/// </summary>
        /// <param name="SelectAddUpCd"></param>
		/// <remarks>
		/// <br>Note	   : �v�㋒�_�I������</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public void SelectedAddUpCd(int SelectAddUpCd)
		{
			// ���݂̃`�F�b�N����Ă���v�㋒�_����n���B
			this._selectedAddUpCd = SelectAddUpCd;
		}

		/// <summary>
		/// �����I���v�㋒�_�ݒ菈��
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note	   : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.12.07</br>
        /// </remarks>
		public void InitSelectAddUpCd(int addUpCd)
		{
			this._selectedAddUpCd = addUpCd;
			return;
		}

        
        #endregion

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }
        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

        // --- ADD 2008/09/08 -------------------------------->>>>>
        /// <summary>
        /// �Ώ۔N��(�J�n) Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>�N����TDateEdit�R���g���[����DateTime�Ŏ擾�\�Ȍ`���ɂ��邽�߁A1���i�߂�</br>
        /// </remarks>
        private void TargetDateSt_tDateEdit_Leave(object sender, EventArgs e)
        {
            int longdate = this.TargetDateSt_tDateEdit.GetLongDate();

            if (longdate % 10 == 0)
            {
                longdate++;
            }

            this.TargetDateSt_tDateEdit.SetLongDate(longdate);
        }

        /// <summary>
        /// �Ώ۔N��(�I��) Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/08</br>
        /// <br>�N����TDateEdit�R���g���[����DateTime�Ŏ擾�\�Ȍ`���ɂ��邽�߁A1���i�߂�</br>
        /// </remarks>
        private void TargetDateEd_tDateEdit_Leave(object sender, EventArgs e)
        {
            int longdate = this.TargetDateEd_tDateEdit.GetLongDate();

            longdate = (longdate / 100) * 100 + 1;
            //if (longdate % 10 == 0)
            //{
            //    longdate++;
            //}

            this.TargetDateEd_tDateEdit.SetLongDate(longdate);
        }

        




        // --- ADD 2008/09/08 --------------------------------<<<<<

        // --- ADD 2010/08/12 ---------------------------------->>>>>
        #region
        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }
        #endregion

        #region �� F5�F�K�C�h�̎��s
        /// <summary>
        /// F5�F�K�C�h�̎��s
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note	   : F5�F�K�C�h�̎��s</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tEdit_SalesEmployeeCode_St.Focused)
            {
                SalesEmployeeSt_GuideBtn_Click(tEdit_SalesEmployeeCode_St, e);
            }
            else if (this.tEdit_SalesEmployeeCode_Ed.Focused)
            {
                SalesEmployeeSt_GuideBtn_Click(tEdit_SalesEmployeeCode_Ed, e);
            }
            else if (this.tEdit_FrontEmployeeCode_St.Focused)
            {
                FrontEmployeeSt_GuideBtn_Click(tEdit_FrontEmployeeCode_St, e);
            }
            else if (this.tEdit_FrontEmployeeCode_Ed.Focused)
            {
                FrontEmployeeSt_GuideBtn_Click(tEdit_FrontEmployeeCode_Ed, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                SalesInputSt_GuideBtn_Click(tEdit_SalesInputCode_St, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                SalesInputSt_GuideBtn_Click(tEdit_SalesInputCode_Ed, e);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused)
            {
                SalesAreaSt_GuideBtn_Click(tNedit_SalesAreaCode_St, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                SalesAreaSt_GuideBtn_Click(tNedit_SalesAreaCode_Ed, e);
            }
            else if (this.tNedit_BusinessTypeCode_St.Focused)
            {
                BusinessTypeSt_GuideBtn_Click(tNedit_BusinessTypeCode_St, e);
            }
            else if (this.tNedit_BusinessTypeCode_Ed.Focused)
            {
                BusinessTypeSt_GuideBtn_Click(tNedit_BusinessTypeCode_Ed, e);
            }
            else if (this.tNedit_SalesCode_St.Focused)
            {
                SalesCodeSt_GuideBtn_Click(tNedit_SalesCode_St, e);
            }
            else if (this.tNedit_SalesCode_Ed.Focused)
            {
                SalesCodeSt_GuideBtn_Click(tNedit_SalesCode_Ed, e);
            }
            else if (this.tNedit_CustomerCode_St.Focused)
            {
                CustomerCdSt_GuideBtn_Click(tNedit_CustomerCode_St, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                CustomerCdEd_GuideBtn_Click(tNedit_CustomerCode_Ed, e);
            };
        }
        #endregion
        // --- ADD 2010/08/12 ----------------------------------<<<<<
    }
}
