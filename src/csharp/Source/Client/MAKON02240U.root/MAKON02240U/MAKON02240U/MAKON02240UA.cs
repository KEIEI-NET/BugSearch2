//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���m�F�\
// �v���O�����T�v   : �d���m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ђJ �k��
// �� �� ��  2007/05/22  �C�����e : �L�����A�̈ꗗ���A�L�����A�\�����ʃA�N�Z�X�N���X����ǂނ悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �C �� ��  2008/07/16  �C�����e : �f�[�^���ڂ̒ǉ�/�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/07  �C�����e : ��Q�Ή�13159(�d�����̔C�Ӎ��ډ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/14  �C�����e : ��Q�Ή�12394,12396,12401
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �D�u��
// �C �� ��  2010/08/16  �C�����e : ��Q���ǑΉ�8���@�L�[�{�[�h����̉��ǂ��s���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : cheq
// �C �� ��  2012/12/26  �C�����e : 2013/03/13�z�M���ARedmine#34098 
//                                  �r���󎚐���̒ǉ��Əo�͏�����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2013/02/27  �C�����e : 2013/03/13�z�M���ARedmine#34098 
//                                  �r���󎚐���̒ǉ��Əo�͏�����̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �{�{ ����
// �C �� ��  2013/03/05  �C�����e : Tab�Enter�L�[�ł̃t�H�[�J�X������C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ����
// �C �� ��  2020/02/27  �C�����e : �y���ŗ��Ή�
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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/07 �s��Ή�[5639]
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinEditors; // ADD 2010/08/16
using Infragistics.Win.Misc; // ADD 2010/08/16
// --- ADD START 3H ���� 2020/02/27---------->>>>>
using System.IO;
using System.Text.RegularExpressions;
// --- ADD END 3H ���� 2020/02/27----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�E�`���[�g��������t�H�[���N���X
    /// </summary>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E�L�����A�̈ꗗ���A�L�����A�\�����ʃA�N�Z�X�N���X����ǂނ悤�ɏC��</br>
    /// <br>Programmer	: 980023�@�ђJ �k��</br>
    /// <br>Date		: 2007.05.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E�f�[�^���ڂ̒ǉ�/�C��</br>
    /// <br>Programmer	: 30415 �ēc �ύK</br>
    /// <br>Date		: 2008/07/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E��Q�Ή�13159(�d�����̔C�Ӎ��ډ�)</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �E��Q�Ή�12394,12396,12401</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2009/04/14</br>
    /// <br>Update Note : 2012/12/26 cheq</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Əo�͏�����̑Ή�</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : 2013/02/27 ���N</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Əo�͏�����̑Ή�</br>
    /// -----------------------------------------------------------------------------------
    public class MAKON02240UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer,
		//IPrintConditionInpTypeChart
        IPrintConditionInpTypeGuidExecuter      // F5�F�K�C�h�̕\����\�� // ADD 2010/08/16
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel MAKON02240UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private TDateEdit StockDateEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit StockDateStRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TNedit tNedit_SupplierCd_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TComboEditor tComboEditor_DebitNoteDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor tComboEditor_SupplierSlipCd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private TNedit AcceptAnOrderNoEd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private TNedit AcceptAnOrderNoSt_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private TEdit tEdit_StockAgentCode_Ed;
        private TEdit tEdit_StockAgentCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private ToolTip toolTip1;
		private TDateEdit InputDayEdRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private TDateEdit InputDayStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private TEdit PartySaleSlipNumEd_tEdit;
		private TEdit PartySaleSlipNumSt_tEdit;
		private UiSetControl uiSetControl1;
        private TComboEditor tComboEditor_PrintType;
        private TComboEditor tComboEditor_NewPage;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeEd_GuidBtn;
        private Infragistics.Win.Misc.UltraButton SalesAreaCodeSt_GuidBtn;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TComboEditor tComboEditor_StockOrderDivCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private TComboEditor tComboEditor_OutputDesignated;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private TNedit tNedit_SalesAreaCode_St;
        private TNedit tNedit_SalesAreaCode_Ed;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_PrintDailyFooter;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private System.ComponentModel.IContainer components;

        private object _preComboEditorValue = null;
        private TComboEditor _preCtrlName = null;    //ADD 2008/08/16
        private UiMemInput uiMemInput1;
        private TComboEditor tComboEditor_LinePrintDiv;
        private UltraLabel LinePrintDiv_Label;
        private TComboEditor tComboEditor_TaxPrintDiv;
        private UltraLabel ultraLabel20;    //ADD 2008/08/16
        // --- ADD 2010/08/26 ---------->>>>>
        private Control _preControl = null;
        public event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<
        // --- ADD START 3H ���� 2020/02/27---------->>>>>
        // XML����
        private const string ctPrintXmlFileName = "TaxRate_UserSetting.XML";
        // --- ADD END 3H ���� 2020/02/27----------<<<<<
		#endregion
		
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructer
        /// <remarks>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// <br></br>
        /// </remarks>
		public MAKON02240UA()
		{
			InitializeComponent();

			this._enterpriseCode   = LoginInfoAcquisition.EnterpriseCode;
            this._carrierDspList = new ArrayList();
            this._carrierList = new SortedList();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker    = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // �C���X�^���X����
            this._employeeAcs = new EmployeeAcs();
            this._lGoodsGanreAcs = new LGoodsGanreAcs();
            this._mGoodsGanreAcs = new MGoodsGanreAcs();
            //this._cellphoneModelAcs = new CellphoneModelAcs();

			//���t�擾���i
			this._dateGet = DateGetAcs.GetInstance();
            //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>> 
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tComboEditor_LinePrintDiv); // �r����

            uiMemInput1.TargetControls = ctrlList;
            //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<

        }
		#endregion

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		#region Dispose        
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

		// ===================================================================================== //
		// Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
		// ===================================================================================== //
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
        /// <remarks>
        /// <br>Update Note : 2013/02/27 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Əo�͏�����̑Ή�</br>
        /// </remarks>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_TaxPrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_LinePrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.LinePrintDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_PrintDailyFooter = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_NewPage = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.StockDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.StockDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tComboEditor_StockOrderDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_OutputDesignated = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesAreaCodeEd_GuidBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesAreaCodeSt_GuidBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartySaleSlipNumEd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.PartySaleSlipNumSt_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_StockAgentCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_StockAgentCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.AcceptAnOrderNoEd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.AcceptAnOrderNoSt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_DebitNoteDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAKON02240UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LinePrintDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPage)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockOrderDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputDesignated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumEd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumSt_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoEd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoSt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            this.MAKON02240UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_TaxPrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel20);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_LinePrintDiv);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.LinePrintDiv_Label);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_PrintDailyFooter);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel19);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_NewPage);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.StockDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.StockDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(712, 158);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // tComboEditor_TaxPrintDiv
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ActiveAppearance = appearance68;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.Appearance = appearance22;
            this.tComboEditor_TaxPrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ItemAppearance = appearance69;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0:�󎚂���";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1:�󎚂��Ȃ�";
            this.tComboEditor_TaxPrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_TaxPrintDiv.LimitToList = true;
            this.tComboEditor_TaxPrintDiv.Location = new System.Drawing.Point(168, 128);
            this.tComboEditor_TaxPrintDiv.Name = "tComboEditor_TaxPrintDiv";
            this.tComboEditor_TaxPrintDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_TaxPrintDiv.TabIndex = 72;
            // 
            // ultraLabel20
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance8;
            this.ultraLabel20.Location = new System.Drawing.Point(24, 128);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel20.TabIndex = 73;
            this.ultraLabel20.Text = "�ŕʓ����";
            // 
            // tComboEditor_LinePrintDiv
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_LinePrintDiv.Appearance = appearance90;
            this.tComboEditor_LinePrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_LinePrintDiv.ItemAppearance = appearance91;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "0:�󎚂���";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "1:�󎚂��Ȃ�";
            this.tComboEditor_LinePrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.tComboEditor_LinePrintDiv.LimitToList = true;
            this.tComboEditor_LinePrintDiv.Location = new System.Drawing.Point(168, 68);
            this.tComboEditor_LinePrintDiv.Name = "tComboEditor_LinePrintDiv";
            this.tComboEditor_LinePrintDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_LinePrintDiv.TabIndex = 4;
            // 
            // LinePrintDiv_Label
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.LinePrintDiv_Label.Appearance = appearance92;
            this.LinePrintDiv_Label.Location = new System.Drawing.Point(24, 68);
            this.LinePrintDiv_Label.Name = "LinePrintDiv_Label";
            this.LinePrintDiv_Label.Size = new System.Drawing.Size(122, 23);
            this.LinePrintDiv_Label.TabIndex = 71;
            this.LinePrintDiv_Label.Text = "�r����";
            // 
            // ultraOptionSet_PrintDailyFooter
            // 
            this.ultraOptionSet_PrintDailyFooter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "���Ȃ�";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "����";
            this.ultraOptionSet_PrintDailyFooter.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.ultraOptionSet_PrintDailyFooter.Location = new System.Drawing.Point(433, 72);
            this.ultraOptionSet_PrintDailyFooter.Name = "ultraOptionSet_PrintDailyFooter";
            this.ultraOptionSet_PrintDailyFooter.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_PrintDailyFooter.TabIndex = 5;
            this.ultraOptionSet_PrintDailyFooter.Text = "���Ȃ�";
            this.ultraOptionSet_PrintDailyFooter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultraOptionSet_PrintDailyFooter_KeyDown);
            // 
            // ultraLabel19
            // 
            appearance85.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance85;
            this.ultraLabel19.Location = new System.Drawing.Point(356, 69);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel19.TabIndex = 65;
            this.ultraLabel19.Text = "���v��";
            // 
            // tComboEditor_NewPage
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPage.ActiveAppearance = appearance43;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPage.Appearance = appearance30;
            this.tComboEditor_NewPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPage.ItemAppearance = appearance44;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "0:���_";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "1:�d����";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "2:���Ȃ�";
            this.tComboEditor_NewPage.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.tComboEditor_NewPage.LimitToList = true;
            this.tComboEditor_NewPage.Location = new System.Drawing.Point(168, 98);
            this.tComboEditor_NewPage.Name = "tComboEditor_NewPage";
            this.tComboEditor_NewPage.Size = new System.Drawing.Size(116, 24);
            this.tComboEditor_NewPage.TabIndex = 6;
            // 
            // ultraLabel6
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance5;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 98);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel6.TabIndex = 62;
            this.ultraLabel6.Text = "����";
            // 
            // InputDayEdRF_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEdRF_tDateEdit.ActiveEditAppearance = appearance1;
            this.InputDayEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEdRF_tDateEdit.CalendarDisp = true;
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.EditAppearance = appearance2;
            this.InputDayEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.LabelAppearance = appearance3;
            this.InputDayEdRF_tDateEdit.Location = new System.Drawing.Point(387, 38);
            this.InputDayEdRF_tDateEdit.Name = "InputDayEdRF_tDateEdit";
            this.InputDayEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEdRF_tDateEdit.TabIndex = 3;
            this.InputDayEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel4
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance6;
            this.ultraLabel4.Location = new System.Drawing.Point(356, 38);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel4.TabIndex = 37;
            this.ultraLabel4.Text = "�`";
            // 
            // StockDateEdRF_tDateEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockDateEdRF_tDateEdit.ActiveEditAppearance = appearance7;
            this.StockDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.StockDateEdRF_tDateEdit.CalendarDisp = true;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.StockDateEdRF_tDateEdit.EditAppearance = appearance84;
            this.StockDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.StockDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.StockDateEdRF_tDateEdit.LabelAppearance = appearance9;
            this.StockDateEdRF_tDateEdit.Location = new System.Drawing.Point(387, 8);
            this.StockDateEdRF_tDateEdit.Name = "StockDateEdRF_tDateEdit";
            this.StockDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.StockDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.StockDateEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.StockDateEdRF_tDateEdit.TabIndex = 1;
            this.StockDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance10;
            this.ultraLabel10.Location = new System.Drawing.Point(356, 8);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "�`";
            // 
            // InputDayStRF_tDateEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayStRF_tDateEdit.ActiveEditAppearance = appearance11;
            this.InputDayStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayStRF_tDateEdit.CalendarDisp = true;
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.EditAppearance = appearance12;
            this.InputDayStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.LabelAppearance = appearance13;
            this.InputDayStRF_tDateEdit.Location = new System.Drawing.Point(168, 38);
            this.InputDayStRF_tDateEdit.Name = "InputDayStRF_tDateEdit";
            this.InputDayStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayStRF_tDateEdit.TabIndex = 2;
            this.InputDayStRF_tDateEdit.TabStop = true;
            // 
            // StockDateStRF_tDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockDateStRF_tDateEdit.ActiveEditAppearance = appearance14;
            this.StockDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.StockDateStRF_tDateEdit.CalendarDisp = true;
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.StockDateStRF_tDateEdit.EditAppearance = appearance15;
            this.StockDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.StockDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.StockDateStRF_tDateEdit.LabelAppearance = appearance16;
            this.StockDateStRF_tDateEdit.Location = new System.Drawing.Point(168, 8);
            this.StockDateStRF_tDateEdit.Name = "StockDateStRF_tDateEdit";
            this.StockDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.StockDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.StockDateStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.StockDateStRF_tDateEdit.TabIndex = 0;
            this.StockDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel9
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance17;
            this.ultraLabel9.Location = new System.Drawing.Point(24, 38);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel9.TabIndex = 36;
            this.ultraLabel9.Text = "���͓�";
            // 
            // ultraLabel8
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance18;
            this.ultraLabel8.Location = new System.Drawing.Point(24, 8);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "�d����";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 241);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(712, 33);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance19;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance31;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance20;
            valueListItem10.DataValue = ((short)(5));
            valueListItem10.DisplayText = "0:�d���恨�d�������d��SEQ�ԍ�";
            valueListItem11.DataValue = ((short)(6));
            valueListItem11.DisplayText = "1:�d���恨���͓����d��SEQ�ԍ�";
            valueListItem12.DataValue = ((short)(1));
            valueListItem12.DisplayText = "2:�d���恨�d�������`�[�ԍ�";
            valueListItem13.DataValue = ((short)(3));
            valueListItem13.DisplayText = "3:�d���恨���͓����`�[�ԍ�";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13});
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(168, 4);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 5;
            // 
            // ultraLabel5
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance21;
            this.ultraLabel5.Location = new System.Drawing.Point(24, 3);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 4;
            this.ultraLabel5.Text = "�o�͏�";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_StockOrderDivCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel18);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_OutputDesignated);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel17);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeEd_GuidBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesAreaCodeSt_GuidBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_PrintType);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.PartySaleSlipNumEd_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.PartySaleSlipNumSt_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AcceptAnOrderNoEd_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AcceptAnOrderNoSt_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel26);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_DebitNoteDiv);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_SupplierSlipCd);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 311);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(712, 305);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance86.TextHAlignAsString = "Left";
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance86;
            appearance76.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance76;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(321, 34);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 9;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 12;
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance50;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(168, 34);
            this.tNedit_SalesAreaCode_St.MaxLength = 9;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 10;
            // 
            // tComboEditor_StockOrderDivCd
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_StockOrderDivCd.ActiveAppearance = appearance61;
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_StockOrderDivCd.Appearance = appearance83;
            this.tComboEditor_StockOrderDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_StockOrderDivCd.ItemAppearance = appearance62;
            valueListItem14.DataValue = -1;
            valueListItem14.DisplayText = "0:�S��";
            valueListItem15.DataValue = 1;
            valueListItem15.DisplayText = "1:�݌�";
            valueListItem16.DataValue = 0;
            valueListItem16.DisplayText = "2:���";
            this.tComboEditor_StockOrderDivCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.tComboEditor_StockOrderDivCd.LimitToList = true;
            this.tComboEditor_StockOrderDivCd.Location = new System.Drawing.Point(168, 273);
            this.tComboEditor_StockOrderDivCd.Name = "tComboEditor_StockOrderDivCd";
            this.tComboEditor_StockOrderDivCd.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_StockOrderDivCd.TabIndex = 26;
            // 
            // ultraLabel18
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance4;
            this.ultraLabel18.Location = new System.Drawing.Point(24, 273);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel18.TabIndex = 70;
            this.ultraLabel18.Text = "�݌Ɏ��w��";
            // 
            // tComboEditor_OutputDesignated
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputDesignated.ActiveAppearance = appearance71;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_OutputDesignated.Appearance = appearance82;
            this.tComboEditor_OutputDesignated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputDesignated.ItemAppearance = appearance72;
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "0:�S��";
            valueListItem18.DataValue = 1;
            valueListItem18.DisplayText = "1:�d������";
            valueListItem19.DataValue = 2;
            valueListItem19.DisplayText = "2:UOE��";
            valueListItem20.DataValue = 3;
            valueListItem20.DisplayText = "3:�������͕�";
            valueListItem21.DataValue = 4;
            valueListItem21.DisplayText = "4:UOE�A���}�b�`";
            this.tComboEditor_OutputDesignated.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20,
            valueListItem21});
            this.tComboEditor_OutputDesignated.LimitToList = true;
            this.tComboEditor_OutputDesignated.Location = new System.Drawing.Point(168, 243);
            this.tComboEditor_OutputDesignated.Name = "tComboEditor_OutputDesignated";
            this.tComboEditor_OutputDesignated.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_OutputDesignated.TabIndex = 25;
            // 
            // ultraLabel17
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance73;
            this.ultraLabel17.Location = new System.Drawing.Point(23, 243);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel17.TabIndex = 68;
            this.ultraLabel17.Text = "�o�͎w��";
            // 
            // SalesAreaCodeEd_GuidBtn
            // 
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeEd_GuidBtn.Appearance = appearance26;
            this.SalesAreaCodeEd_GuidBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeEd_GuidBtn.Location = new System.Drawing.Point(411, 33);
            this.SalesAreaCodeEd_GuidBtn.Name = "SalesAreaCodeEd_GuidBtn";
            this.SalesAreaCodeEd_GuidBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeEd_GuidBtn.TabIndex = 13;
            this.SalesAreaCodeEd_GuidBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesAreaCodeEd_GuidBtn, "�n��K�C�h");
            this.SalesAreaCodeEd_GuidBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeEd_GuidBtn.Click += new System.EventHandler(this.SalesAreaCodeEd_GuidBtn_Click);
            // 
            // SalesAreaCodeSt_GuidBtn
            // 
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesAreaCodeSt_GuidBtn.Appearance = appearance27;
            this.SalesAreaCodeSt_GuidBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesAreaCodeSt_GuidBtn.Location = new System.Drawing.Point(258, 33);
            this.SalesAreaCodeSt_GuidBtn.Name = "SalesAreaCodeSt_GuidBtn";
            this.SalesAreaCodeSt_GuidBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesAreaCodeSt_GuidBtn.TabIndex = 11;
            this.SalesAreaCodeSt_GuidBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesAreaCodeSt_GuidBtn, "�n��K�C�h");
            this.SalesAreaCodeSt_GuidBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesAreaCodeSt_GuidBtn.Click += new System.EventHandler(this.SalesAreaCodeSt_GuidBtn_Click);
            // 
            // ultraLabel7
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance32;
            this.ultraLabel7.Location = new System.Drawing.Point(292, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel7.TabIndex = 67;
            this.ultraLabel7.Text = "�`";
            // 
            // ultraLabel16
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance39;
            this.ultraLabel16.Location = new System.Drawing.Point(24, 33);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel16.TabIndex = 66;
            this.ultraLabel16.Text = "�n��";
            // 
            // tComboEditor_PrintType
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ActiveAppearance = appearance74;
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PrintType.Appearance = appearance81;
            this.tComboEditor_PrintType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ItemAppearance = appearance75;
            valueListItem22.DataValue = 0;
            valueListItem22.DisplayText = "0:�ʏ�";
            valueListItem23.DataValue = 1;
            valueListItem23.DisplayText = "1:����";
            valueListItem24.DataValue = 2;
            valueListItem24.DisplayText = "2:�폜";
            valueListItem25.DataValue = 3;
            valueListItem25.DisplayText = "3:�����{�폜";
            this.tComboEditor_PrintType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem22,
            valueListItem23,
            valueListItem24,
            valueListItem25});
            this.tComboEditor_PrintType.LimitToList = true;
            this.tComboEditor_PrintType.Location = new System.Drawing.Point(168, 213);
            this.tComboEditor_PrintType.Name = "tComboEditor_PrintType";
            this.tComboEditor_PrintType.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_PrintType.TabIndex = 24;
            // 
            // PartySaleSlipNumEd_tEdit
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartySaleSlipNumEd_tEdit.ActiveAppearance = appearance87;
            this.PartySaleSlipNumEd_tEdit.AutoSelect = true;
            this.PartySaleSlipNumEd_tEdit.DataText = "";
            this.PartySaleSlipNumEd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartySaleSlipNumEd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PartySaleSlipNumEd_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PartySaleSlipNumEd_tEdit.Location = new System.Drawing.Point(321, 124);
            this.PartySaleSlipNumEd_tEdit.MaxLength = 19;
            this.PartySaleSlipNumEd_tEdit.Name = "PartySaleSlipNumEd_tEdit";
            this.PartySaleSlipNumEd_tEdit.Size = new System.Drawing.Size(82, 24);
            this.PartySaleSlipNumEd_tEdit.TabIndex = 21;
            // 
            // ultraLabel2
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance70;
            this.ultraLabel2.Location = new System.Drawing.Point(23, 213);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "���s�^�C�v";
            // 
            // PartySaleSlipNumSt_tEdit
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartySaleSlipNumSt_tEdit.ActiveAppearance = appearance23;
            this.PartySaleSlipNumSt_tEdit.AutoSelect = true;
            this.PartySaleSlipNumSt_tEdit.DataText = "";
            this.PartySaleSlipNumSt_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PartySaleSlipNumSt_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PartySaleSlipNumSt_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PartySaleSlipNumSt_tEdit.Location = new System.Drawing.Point(168, 124);
            this.PartySaleSlipNumSt_tEdit.MaxLength = 19;
            this.PartySaleSlipNumSt_tEdit.Name = "PartySaleSlipNumSt_tEdit";
            this.PartySaleSlipNumSt_tEdit.Size = new System.Drawing.Size(82, 24);
            this.PartySaleSlipNumSt_tEdit.TabIndex = 20;
            // 
            // ultraLabel14
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance24;
            this.ultraLabel14.Location = new System.Drawing.Point(292, 124);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel14.TabIndex = 60;
            this.ultraLabel14.Text = "�`";
            // 
            // ultraLabel15
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance25;
            this.ultraLabel15.Location = new System.Drawing.Point(24, 124);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel15.TabIndex = 59;
            this.ultraLabel15.Text = "�`�[�ԍ�";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance63.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance63;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(411, 3);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 9;
            this.SalesEmployeeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "�]�ƈ��K�C�h");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance64.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance64;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(258, 3);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 7;
            this.SalesEmployeeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "�]�ƈ��K�C�h");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance28;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(411, 63);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 17;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "�d���挟��");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance29.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance29;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(258, 64);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 15;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "�d���挟��");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_StockAgentCode_Ed
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_Ed.ActiveAppearance = appearance65;
            this.tEdit_StockAgentCode_Ed.AutoSelect = true;
            this.tEdit_StockAgentCode_Ed.DataText = "";
            this.tEdit_StockAgentCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_Ed.Location = new System.Drawing.Point(321, 3);
            this.tEdit_StockAgentCode_Ed.MaxLength = 9;
            this.tEdit_StockAgentCode_Ed.Name = "tEdit_StockAgentCode_Ed";
            this.tEdit_StockAgentCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_Ed.TabIndex = 8;
            // 
            // tEdit_StockAgentCode_St
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_St.ActiveAppearance = appearance66;
            this.tEdit_StockAgentCode_St.AutoSelect = true;
            this.tEdit_StockAgentCode_St.DataText = "";
            this.tEdit_StockAgentCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_St.Location = new System.Drawing.Point(168, 3);
            this.tEdit_StockAgentCode_St.MaxLength = 9;
            this.tEdit_StockAgentCode_St.Name = "tEdit_StockAgentCode_St";
            this.tEdit_StockAgentCode_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_St.TabIndex = 6;
            // 
            // ultraLabel25
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance67;
            this.ultraLabel25.Location = new System.Drawing.Point(292, 3);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 56;
            this.ultraLabel25.Text = "�`";
            // 
            // AcceptAnOrderNoEd_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlignAsString = "Left";
            this.AcceptAnOrderNoEd_tNedit.ActiveAppearance = appearance33;
            appearance34.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoEd_tNedit.Appearance = appearance34;
            this.AcceptAnOrderNoEd_tNedit.AutoSelect = true;
            this.AcceptAnOrderNoEd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AcceptAnOrderNoEd_tNedit.DataText = "";
            this.AcceptAnOrderNoEd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AcceptAnOrderNoEd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.AcceptAnOrderNoEd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AcceptAnOrderNoEd_tNedit.Location = new System.Drawing.Point(321, 94);
            this.AcceptAnOrderNoEd_tNedit.MaxLength = 9;
            this.AcceptAnOrderNoEd_tNedit.Name = "AcceptAnOrderNoEd_tNedit";
            this.AcceptAnOrderNoEd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.AcceptAnOrderNoEd_tNedit.Size = new System.Drawing.Size(82, 24);
            this.AcceptAnOrderNoEd_tNedit.TabIndex = 19;
            // 
            // ultraLabel27
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance35;
            this.ultraLabel27.Location = new System.Drawing.Point(292, 94);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 53;
            this.ultraLabel27.Text = "�`";
            // 
            // AcceptAnOrderNoSt_tNedit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoSt_tNedit.ActiveAppearance = appearance36;
            appearance37.TextHAlignAsString = "Right";
            this.AcceptAnOrderNoSt_tNedit.Appearance = appearance37;
            this.AcceptAnOrderNoSt_tNedit.AutoSelect = true;
            this.AcceptAnOrderNoSt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AcceptAnOrderNoSt_tNedit.DataText = "";
            this.AcceptAnOrderNoSt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AcceptAnOrderNoSt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.AcceptAnOrderNoSt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AcceptAnOrderNoSt_tNedit.Location = new System.Drawing.Point(168, 94);
            this.AcceptAnOrderNoSt_tNedit.MaxLength = 9;
            this.AcceptAnOrderNoSt_tNedit.Name = "AcceptAnOrderNoSt_tNedit";
            this.AcceptAnOrderNoSt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.AcceptAnOrderNoSt_tNedit.Size = new System.Drawing.Size(82, 24);
            this.AcceptAnOrderNoSt_tNedit.TabIndex = 18;
            // 
            // ultraLabel28
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance38;
            this.ultraLabel28.Location = new System.Drawing.Point(24, 94);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel28.TabIndex = 51;
            this.ultraLabel28.Text = "�d��SEQ�ԍ�";
            // 
            // ultraLabel26
            // 
            appearance88.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance88;
            this.ultraLabel26.Location = new System.Drawing.Point(24, 3);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel26.TabIndex = 47;
            this.ultraLabel26.Text = "�S����";
            // 
            // tComboEditor_DebitNoteDiv
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ActiveAppearance = appearance40;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DebitNoteDiv.Appearance = appearance80;
            this.tComboEditor_DebitNoteDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DebitNoteDiv.ItemAppearance = appearance41;
            valueListItem26.DataValue = ((short)(0));
            valueListItem26.DisplayText = "0:�S��";
            valueListItem27.DataValue = ((short)(1));
            valueListItem27.DisplayText = "1:���`";
            valueListItem28.DataValue = ((short)(2));
            valueListItem28.DisplayText = "2:�ԓ`";
            valueListItem29.DataValue = "3";
            valueListItem29.DisplayText = "3:����";
            this.tComboEditor_DebitNoteDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem26,
            valueListItem27,
            valueListItem28,
            valueListItem29});
            this.tComboEditor_DebitNoteDiv.LimitToList = true;
            this.tComboEditor_DebitNoteDiv.Location = new System.Drawing.Point(168, 183);
            this.tComboEditor_DebitNoteDiv.Name = "tComboEditor_DebitNoteDiv";
            this.tComboEditor_DebitNoteDiv.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_DebitNoteDiv.TabIndex = 23;
            this.tComboEditor_DebitNoteDiv.Text = "����";
            // 
            // ultraLabel13
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance42;
            this.ultraLabel13.Location = new System.Drawing.Point(23, 183);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel13.TabIndex = 23;
            this.ultraLabel13.Text = "�ԓ`�敪";
            // 
            // tComboEditor_SupplierSlipCd
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ActiveAppearance = appearance59;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierSlipCd.Appearance = appearance79;
            this.tComboEditor_SupplierSlipCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ItemAppearance = appearance60;
            valueListItem30.DataValue = ((short)(0));
            valueListItem30.DisplayText = "0:�S��";
            valueListItem31.DataValue = ((short)(10));
            valueListItem31.DisplayText = "1:�d��";
            valueListItem32.DataValue = ((short)(20));
            valueListItem32.DisplayText = "2:�ԕi";
            this.tComboEditor_SupplierSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem30,
            valueListItem31,
            valueListItem32});
            this.tComboEditor_SupplierSlipCd.LimitToList = true;
            this.tComboEditor_SupplierSlipCd.Location = new System.Drawing.Point(168, 154);
            this.tComboEditor_SupplierSlipCd.Name = "tComboEditor_SupplierSlipCd";
            this.tComboEditor_SupplierSlipCd.Size = new System.Drawing.Size(144, 24);
            this.tComboEditor_SupplierSlipCd.TabIndex = 22;
            // 
            // ultraLabel12
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance45;
            this.ultraLabel12.Location = new System.Drawing.Point(23, 154);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel12.TabIndex = 21;
            this.ultraLabel12.Text = "�`�[�敪";
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance46;
            appearance47.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance47;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(321, 64);
            this.tNedit_SupplierCd_Ed.MaxLength = 9;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 16;
            // 
            // ultraLabel11
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance48;
            this.ultraLabel11.Location = new System.Drawing.Point(292, 64);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 19;
            this.ultraLabel11.Text = "�`";
            // 
            // tNedit_SupplierCd_St
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance77;
            appearance78.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance78;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(168, 64);
            this.tNedit_SupplierCd_St.MaxLength = 9;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_St.TabIndex = 14;
            // 
            // ultraLabel3
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance51;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 64);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 17;
            this.ultraLabel3.Text = "�d����";
            // 
            // MAKON02240UA_Fill_Panel
            // 
            this.MAKON02240UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAKON02240UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAKON02240UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAKON02240UA_Fill_Panel.Name = "MAKON02240UA_Fill_Panel";
            this.MAKON02240UA_Fill_Panel.Size = new System.Drawing.Size(750, 639);
            this.MAKON02240UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(750, 639);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance52.FontData.Name = "�l�r �S�V�b�N";
            appearance52.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance52;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance53;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 160;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance54;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 35;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@�\�[�g��";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance55;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 307;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance56.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance56;
            appearance57.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance57;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(3, 3);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(748, 624);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing_1);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance58.FontData.SizeInPoints = 20F;
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance58;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 639);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
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
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAKON02240UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 639);
            this.Controls.Add(this.MAKON02240UA_Fill_Panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAKON02240UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�d���m�F�\";
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_LinePrintDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPage)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_StockOrderDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputDesignated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumEd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNumSt_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoEd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderNoSt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DebitNoteDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            this.MAKON02240UA_Fill_Panel.ResumeLayout(false);
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

		//private bool _baseOption                     = false;
        
		private bool _printButtonEnabled = true;
		private bool _extraButtonEnabled = false;
		private bool _pdfButtonEnabled = true;
		private bool _printButtonVisibled = true;
		private bool _extraButtonVisibled = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// �v�㋒�_�I��\���擾

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = false;
		private bool _chartButtonEnabled = false;

        private string _StockConfDataTable;

		private Employee _loginWorker = null;
		// �����_�R�[�h
		private string _ownSectionCode = "";
		// �����ݒ苒�_�R�[�h
		//private string _balanceSectionCode = "";

        private ExtrInfo_MAKON02247E _chartStockconfListCndtn = null;

        // ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;

        // --- ADD 2008/07/16 -------------------------------->>>>>
        private static SupplierAcs _supplierAcs;
        private static UserGuideAcs _userGuideAcs;
        // --- ADD 2008/07/16 --------------------------------<<<<< 

        // �K�C�h�n�A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;
        LGoodsGanreAcs _lGoodsGanreAcs;
        MGoodsGanreAcs _mGoodsGanreAcs;
//        CellphoneModelAcs _cellphoneModelAcs;

        private StockConfAcs _stockConfListAcs = null;  // ����m�F�\�A�N�Z�X�N���X

        private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// ���_�I�v�V�����L��
        private bool _isMainOfficeFunc;	// �{�Ћ@�\�L��

        SortedList _carrierList;
        ArrayList _carrierDspList;
        
		// �G�N�X�v���[���o�[�g������ 
		private Form _topForm = null;
		private bool _explorerBarExpanding = false;

		//���t�擾���i
		private DateGetAcs _dateGet; 

		// ���i�`���[�g���o�N���X�����o
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_MAKON02247E _stockConfListCndtnWork = new ExtrInfo_MAKON02247E();		//�����N���X(�O������ێ��p)
        private ExtrInfo_MAKON02247E _chartStockConfListCndtn = new ExtrInfo_MAKON02247E();		//�����N���X(�`���[�g���n���p)
        private DataSet _printBuffDataSet = null;

        // ADD 2008/10/07 �s��Ή�[5639]---------->>>>>
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
        // ADD 2008/10/07 �s��Ή�[5639]----------<<<<<

        // --- ADD 2009/04/14 -------------------------------->>>>>
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
        // --- ADD 2009/04/14 --------------------------------<<<<<
		#endregion
        
		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		#region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

		private const string THIS_ASSEMBLYID                         = "MAKON02240U";	
		private const string PDF_PRINT_KEY                           = "3ee0af24-56ae-435d-b294-298a93dfd243";
		private const string PDF_PRINT_NAME = "�d���m�F�\";

        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

		// �G�N�X�v���[���[�o�[�̕\����Ԃ����肷�邽�߂̊�ƂȂ�g�b�v�t�H�[���̍���
		private const int CT_TOPFORM_BASE_HEIGHT = 768;

        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent; // ADD 2010/08/16

		// ExporerBar �O���[�v����
		private const string ct_ExBarGroupNm_ReportSelectGroup = "CustomerConditionGroup";		// �o�͏���
		private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";
		private const string ct_ExBarGroupNm_PrintConditionGroup = "ExtraConditionCodeGroup";	// ���o����

		//�G���[�������b�Z�[�W
		const string ct_InputError = "�̓��͂��s���ł�";
		const string ct_NoInput = "����͂��ĉ�����";
		const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
		//const string ct_RangeOverError = "�͂P�����͈͓̔��œ��͂��ĉ�����";  // DEL 2008/07/16
        const string ct_RangeOverError = "�͂R�����͈͓̔��œ��͂��ĉ�����";    // ADD 2008/07/16

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
                return _chartStockconfListCndtn;
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
		/// <br>Note       : ��ʕ\�����s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public void Show(object parameter)
		{
            this.Show();
        }
		
		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public int Print(ref object parameter)
		{

		            
			SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // ������p�����[�^
		
			// ��ƃR�[�h
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // �N���o�f�h�c
			printInfo.key            = PDF_PRINT_KEY;               // PDF�����Ǘ��pKEY���

			// ��ʁ����o�����N���X
            ExtrInfo_MAKON02247E stockConfListCndtnWork = new ExtrInfo_MAKON02247E();
            this.SetExtraInfoFromScreen(ref stockConfListCndtnWork);
		            
			// ���o�����̐ݒ�
            printInfo.jyoken = stockConfListCndtnWork;

#if False
			// �`���[�g�p�����ݒ�
            //_chartStockOrderListCndtn = this._stockConfListCndtnWork; 

			// �f�[�^���o
            // ----------
            // ���o����ʃC���X�^���X�쐬
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "���o��";
            pd.Message = "���݁A�f�[�^���o���ł��B";

            int status = 0;

            try
            {
                pd.Show();
                status = this.SearchData(stockConfListCndtnWork);
            }
            finally
            {
                pd.Close();
                printInfo.status = status;
            }
            // ----------
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._printBuffDataSet = null;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                return status;
            }

            this._stockConfListCndtnWork = stockConfListCndtnWork;


			printInfo.rdData = this._printBuffDataSet;
#endif

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
		/// <br>Note       : ����O�̃`�F�b�N�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;

            // --- ADD 2010/08/26 ---------->>>>>
            ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Space, this._preControl, this._preControl);
            this.tArrowKeyControl1_ChangeFocus(this, e);
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
		/// <br>Note       : ���o�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.19</br>
		/// </remarks>
		public int Extract(ref object parameter)
		{
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            ExtrInfo_MAKON02247E extraInfo = new ExtrInfo_MAKON02247E();     // ���o�����N���X

            this.SetExtraInfoFromScreen(ref extraInfo);

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
                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();
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
          System.Windows.Forms.Application.Run(new MAKON02240UA());
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
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// <br>Update Note: 2020/02/27 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00 �y���ŗ��Ή�</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            // ���t�����l
			DateTime staratDate;
			DateTime endDate;
			this._dateGet.GetPeriod(DateGetAcs.ProcModeDivState.PastDays, 1, out staratDate, out endDate);

			this.StockDateStRF_tDateEdit.SetDateTime(DateTime.MinValue);
			this.StockDateEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //this.InputDayStRF_tDateEdit.SetDateTime(staratDate);
            //this.InputDayEdRF_tDateEdit.SetDateTime(endDate);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this.StockDateStRF_tDateEdit.SetDateTime(staratDate);
            this.StockDateEdRF_tDateEdit.SetDateTime(endDate);
            // --- ADD 2008/07/16 --------------------------------<<<<<

            //this.PrintOder_tComboEditor.SelectedIndex = 0;  // DEL 2008/07/16
            this.PrintOder_tComboEditor.SelectedIndex = 3;    // ADD 2008/07/16

            this.tComboEditor_SupplierSlipCd.SelectedIndex = 0;
            this.tComboEditor_DebitNoteDiv.SelectedIndex = 0;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            this.tComboEditor_NewPage.SelectedIndex = 0;           // ����
            this.tComboEditor_PrintType.SelectedIndex = 0;         // ���s�^�C�v
            this.tComboEditor_OutputDesignated.SelectedIndex = 0;  // �o�͎w��
            this.tComboEditor_StockOrderDivCd.SelectedIndex = 0;   // �ݎ�w��
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // �ŕʓ���󎚃R���{�{�b�N�X�̏����l��ݒ�
            this.tComboEditor_TaxPrintDiv.Value = 1;
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<

            // �K�C�h�{�^���C���[�W�ݒ�
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            SalesAreaCodeSt_GuidBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeSt_GuidBtn.Appearance.Image = Size16_Index.STAR1;
            SalesAreaCodeEd_GuidBtn.ImageList = IconResourceManagement.ImageList16;
            SalesAreaCodeEd_GuidBtn.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/07/16 --------------------------------<<<<< 
            // --- ADD cheq 2012/12/26 Redmine#34098---------->>>>>
            // �r����
            this.tComboEditor_LinePrintDiv.Value = 0;
            uiMemInput1.ReadMemInput();
            // --- ADD cheq 2012/12/26 Redmine#34098----------<<<<<
        }

        // --- 2010/08/16 ---------->>>>>
        #region �� F5�F�K�C�h�̎��s
        /// <summary>
        /// F5�F�K�C�h�̎��s
        /// </summary>
        /// <returns></returns>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tEdit_StockAgentCode_St.Focused)
            {
                SalesEmployeeCdSt_GuideBtn_Click(SalesEmployeeCdSt_GuideBtn, e);
                this.tEdit_StockAgentCode_St.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_StockAgentCode_St.Name, this.tEdit_StockAgentCode_St.Text);
            }
            else if (this.tEdit_StockAgentCode_Ed.Focused)
            {
                SalesEmployeeCdEd_GuideBtn_Click(SalesEmployeeCdEd_GuideBtn, e);
                this.tEdit_StockAgentCode_Ed.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_StockAgentCode_Ed.Name, this.tEdit_StockAgentCode_Ed.Text);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused) 
            {
                SalesAreaCodeSt_GuidBtn_Click(SalesAreaCodeSt_GuidBtn, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                SalesAreaCodeEd_GuidBtn_Click(SalesAreaCodeEd_GuidBtn, e);
            }
            else if (this.tNedit_SupplierCd_St.Focused) 
            {
                CustomerCdSt_GuideBtn_Click(CustomerCdSt_GuideBtn, e);
            }
            else if (this.tNedit_SupplierCd_Ed.Focused) 
            {
                CustomerCdEd_GuideBtn_Click(CustomerCdEd_GuideBtn, e);
            };
        }
        #endregion
        // --- 2010/08/16 ----------<<<<<


        /// <summary>
        /// ���_�I���R���|�{�b�N�X�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�����R���|�{�b�N�X�ɐݒ肵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void SettingSectionCombList()
        {
        }


		/// <summary>
		/// ���t�`�F�b�N�����Ăяo��
		/// </summary>
		/// <param name="cdrResult"></param>
		/// <param name="tde_St_OrderDataCreateDate"></param>
		/// <param name="tde_Ed_OrderDataCreateDate"></param>
		/// <returns></returns>
		//private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode)
		private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int range)
        {
			//cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode, false);

            //if (mode == false)  // DEL 2008/07/16
            // ���͓��͈̓`�F�b�N�H
            if (tde_St_OrderDataCreateDate.Name == "InputDayStRF_tDateEdit")  // ADD 2008/07/16
			{
				if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver)
				{
					cdrResult = DateGetAcs.CheckDateRangeResult.OK;
				}
			}

			return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
		}

        // ADD 2008/10/23 �s��Ή�[6521]---------->>>>>
        /// <summary>
        /// ���͓��t�`�F�b�N�����Ăяo��(�͈̓`�F�b�N�Ȃ��A������OK)
        /// </summary>
        /// <param name="cdrResult">�`�F�b�N����</param>
        /// <param name="tde_St_AddUpADate">���͓��i�J�n�j</param>
        /// <param name="tde_Ed_AddUpADate">���͓��i�I���j</param>
        /// <param name="mode">���[�h</param>
        /// <param name="range">�͈�</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit tde_St_AddUpADate,
            ref TDateEdit tde_Ed_AddUpADate,
            bool mode,
            int range
        )
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2008/10/23 �s��Ή�[6521]----------<<<<<

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2020/02/27</br>
        /// </remarks>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

			DateGetAcs.CheckDateRangeResult cdrResult;

			// �d�����t�i�J�n�`�I���j
			//if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, true) == false)  // DEL 2008/07/16
            //if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, false, 3) == false)   // ADD 2008/07/16 // DEL 2009/04/07
            if (CallCheckDateRange(out cdrResult, ref StockDateStRF_tDateEdit, ref StockDateEdRF_tDateEdit, true, 0) == false)   // ADD 2009/04/07
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //{
                        //    message = string.Format("�J�n�d����{0}", ct_NoInput);
                        //    errControl = this.StockDateStRF_tDateEdit;
                        //}
                        //break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        //return true; // ADD 2009/04/07 // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n�d����{0}", ct_InputError);
                            errControl = this.StockDateStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        // --- DEL 2009/04/07 -------------------------------->>>>>
                        //{
                        //    message = string.Format("�I���d����{0}", ct_NoInput);
                        //    errControl = this.StockDateEdRF_tDateEdit;
                        //}
                        //break;
                        // --- DEL 2009/04/07 --------------------------------<<<<<
                        //return true; // ADD 2009/04/07 // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I���d����{0}", ct_InputError);
                            errControl = this.StockDateEdRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("�d����{0}", ct_RangeError);
                            errControl = this.StockDateStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    // --- ADD 2008/07/16 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("�d����{0}", ct_RangeOverError);
                    //        errControl = this.StockDateStRF_tDateEdit;
                    //    }
                    //    break;
                    //// --- ADD 2008/07/16 --------------------------------<<<<<
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                //result = false; // DEL 2009/04/07
                //return result; // DEL 2009/04/07
            }
            else
            {
                result = true;
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            if (!result)
            {
                return result;
            }
            else
            {
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<
            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // XML�̐ŗ����擾
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                if (errMsg != string.Empty)
                {
                    message = errMsg;
                    errControl = this.tComboEditor_TaxPrintDiv;
                    return result;
                }
            }
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<
			// ���͓��t�i�J�n�`�I���j
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, false) == false)  // DEL 2008/07/16
            // DEL 2008/10/14 �s��Ή�[6521]��
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 1) == false)     // ADD 2008/07/16
            // DEL 2008/10/23 �s��Ή�[6521]��
            //if (CallCheckDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 3) == false)   // ADD 2008/10/16 �s��Ή�[6521]
            if (CallCheckInputDateRange(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit, true, 3) == false)   // ADD 2008/10/23 �s��Ή�[6521]
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        // DEL 2008/10/23 �s��Ή�[6521]---------->>>>>
                        //{
                        //    message = string.Format("�J�n���͓�{0}", ct_NoInput);
                        //    errControl = this.InputDayStRF_tDateEdit;
                        //}
                        //break;
                        // DEL 2008/10/23 �s��Ή�[6521]----------<<<<<
                        //return true;    // ADD 2008/10/23 �s��Ή�[6521] // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n���͓�{0}", ct_InputError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        // DEL 2008/10/23 �s��Ή�[6521]---------->>>>>
                        //{
                        //    message = string.Format("�I�����͓�{0}", ct_NoInput);
                        //    errControl = this.InputDayEdRF_tDateEdit;
                        //}
                        //break;
                        // DEL 2008/10/23 �s��Ή�[6521]----------<<<<<
                        //return true;    // ADD 2008/10/23 �s��Ή�[6521] // DEL 2009/04/07
                        {
                            result = true; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I�����͓�{0}", ct_InputError);
                            errControl = this.InputDayEdRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���͓�{0}", ct_RangeError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            message = string.Format("���͓�{0}", ct_RangeOverError);
                            errControl = this.InputDayStRF_tDateEdit;
                            result = false; // ADD 2009/04/07
                        }
                        break;
                }
                //result = false; // DEL 2009/04/07
                //return result; // DEL 2009/04/07
            }
            else
            {
                result = true;
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            if (!result)
            {
                return result;
            }
            else
            {
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            // �S���҃R�[�h�͈̓`�F�b�N
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //if ((this.tEdit_StockAgentCode_Ed.Text != "") &&
            //    (this.tEdit_StockAgentCode_St.Text.CompareTo(this.tEdit_StockAgentCode_Ed.Text) > 0))
            // --- DEL 2008/07/16 --------------------------------<<<<< 
            if ((this.tEdit_StockAgentCode_St.Text != "") && (this.tEdit_StockAgentCode_Ed.Text != ""))
            {
                if (Int32.Parse(this.tEdit_StockAgentCode_St.Text) > Int32.Parse(this.tEdit_StockAgentCode_Ed.Text)) 
                {
                    message = "�S���҂͈̔͂Ɍ�肪����܂�";
                    errControl = this.tEdit_StockAgentCode_Ed;
                    return result;
                }
            }

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �n��`�F�b�N
            if ((this.tNedit_SalesAreaCode_St.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                (this.tNedit_SalesAreaCode_St.GetInt()) > (this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                message = "�n��͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_SalesAreaCode_Ed;
                return result;
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // �d����R�[�h�͈̓`�F�b�N
            if ((this.tNedit_SupplierCd_St.GetInt() != 0) &&
				(this.tNedit_SupplierCd_Ed.GetInt() != 0) &&
                (this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
            {
                message = "�d����͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_SupplierCd_Ed;
                return result;
            }

            // �d��SEQ�ԍ��͈̓`�F�b�N
            if ((this.AcceptAnOrderNoSt_tNedit.GetInt() !=0) &&
				(this.AcceptAnOrderNoEd_tNedit.GetInt() != 0) &&
                (this.AcceptAnOrderNoSt_tNedit.GetInt()) > (this.AcceptAnOrderNoEd_tNedit.GetInt()))
            {
                message = "�d��SEQ�ԍ��͈̔͂Ɍ�肪����܂�";
				errControl = this.AcceptAnOrderNoEd_tNedit;
                return result;
            }

			// �`�[�ԍ��͈̓`�F�b�N
			if ((this.PartySaleSlipNumEd_tEdit.Text != "") &&
                (this.PartySaleSlipNumSt_tEdit.Text.CompareTo(this.PartySaleSlipNumEd_tEdit.Text) > 0))
			{
				message = "�`�[�ԍ��͈̔͂Ɍ�肪����܂�";
				errControl = this.PartySaleSlipNumSt_tEdit;
				return result;
			}

            return true;        
        }


        /// <summary>
		/// 
		/// </summary>
		/// <param name="goodsCndtn"></param>
		/// <returns></returns>
        private int SearchData(ExtrInfo_MAKON02247E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o�������ς���Ă���Ȃ烊���[�e�B���O
            if (this._printBuffDataSet == null || this._stockConfListCndtnWork == null || !this._stockConfListCndtnWork.Equals(extraInfo))
            {
                try
                {
                    status = this._stockConfListAcs.Search(extraInfo, out message, 0);
                    if (status == 0)
                    {
                        this._printBuffDataSet = this._stockConfListAcs._printDataSet;
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
                            this._stockConfListCndtnWork = extraInfo.Clone();

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            //this._printBuffDataSet = new DataSet();
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
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_StockConfDataTable].Rows.Count == 0)
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
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy   = date / 10000;  
            int mm   = date / 100 % 100;
            int dd   = date % 100;  

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;
            	
            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
              // �N�E���E���\����
            case emDateFormat.dfG2Y2M2D:
            case emDateFormat.df4Y2M2D :
            case emDateFormat.df2Y2M2D :
              if (yy == 0 || mm == 0 || dd == 0) return false;
              break;
              // �N�E��    �\����
            case emDateFormat.dfG2Y2M  :
            case emDateFormat.df4Y2M   :
            case emDateFormat.df2Y2M   :
              if (yy == 0 || mm == 0) return false;
              break;
              // �N        �\����
            case emDateFormat.dfG2Y    :
            case emDateFormat.df4Y     :
            case emDateFormat.df2Y     :
              if (yy == 0) return false;
              break;
              // ���E���@�@�\����
            case emDateFormat.df2M2D   :
              if (mm == 0 || dd == 0) return false;
              break;
              // ��        �\����
            case emDateFormat.df2M     :
              if (mm == 0) return false;
              break;
              // ��        �\����
            case emDateFormat.df2D     :
              if (dd == 0) return false;
              break;
            }
                 
            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD",date);
            // �P�����t�Ó����`�F�b�N
            if (TDateTime.IsAvailableDate(dt) == false) return false;

            return true;
            
        }
            
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
        /// <br>Update Note: 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// <br>Update Note: 2020/02/27 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00 �y���ŗ��Ή�</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(ref ExtrInfo_MAKON02247E extraInfo)
        {
            // ��ƃR�[�h
            extraInfo.EnterpriseCode = this._enterpriseCode;
            // �I�����_
            // ���_�I�v�V��������̂Ƃ�
            if (IsOptSection)
            {
                ArrayList secList = new ArrayList();
                // �S�БI�����ǂ���
                if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
                {
					extraInfo.StockSectionCd = new string[1];
					extraInfo.StockSectionCd[0] = "0";
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
					extraInfo.StockSectionCd = (string[])secList.ToArray(typeof(string));
                }
            }
            // ���_�I�v�V�����Ȃ��̎�
            else
            {
				extraInfo.StockSectionCd = new string[0];
            }

            // �`�[���t(�J�n)        
            extraInfo.StockDateSt = this.StockDateStRF_tDateEdit.GetLongDate();
			// �`�[���t(�I��)        
            extraInfo.StockDateEd = this.StockDateEdRF_tDateEdit.GetLongDate();
            // ���ד��t(�J�n)        
            extraInfo.ArrivalGoodsDaySt = 0;
			// ���ד��t(�I��)        
            extraInfo.ArrivalGoodsDayEd = 0;
			// ���͓��t(�J�n)        
			extraInfo.InputDaySt = this.InputDayStRF_tDateEdit.GetLongDate();
			// ���͓��t(�I��)        
			extraInfo.InputDayEd = this.InputDayEdRF_tDateEdit.GetLongDate();
            // ���s�^�C�v
			//extraInfo.PrintType = Convert.ToInt32(this.ultraOptionSet_RowDetailMode.CheckedIndex);  // DEL 2008/07/16
            extraInfo.PrintType = Convert.ToInt32(this.tComboEditor_PrintType.SelectedIndex);         // ADD 2008/07/16
            // �o�͏�
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

            // --- DEL 2008/07/16 -------------------------------->>>>>
            //// ���Ӑ�(�J�n)
            //extraInfo.CustomerCodeSt = this.tNedit_SupplierCd_St.GetInt();
            //// ���Ӑ�(�I��)
            //extraInfo.CustomerCodeEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �d����(�J�n)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();

            // �d����(�I��)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- ADD 2008/07/16 --------------------------------<<<<<

            // �`�[�敪
            extraInfo.SupplierSlipCd = Convert.ToInt32(this.tComboEditor_SupplierSlipCd.SelectedItem.DataValue);
            // �ԓ`�敪
            extraInfo.DebitNoteDiv = Convert.ToInt32(this.tComboEditor_DebitNoteDiv.SelectedItem.DataValue) - 1;

            // �S���R�[�h(�J�n)
            extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            // �S���R�[�h(�I��)
            extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;

            // �`�[�ԍ�(�J�n)
            extraInfo.SupplierSlipNoSt = this.AcceptAnOrderNoSt_tNedit.GetInt();
            // �`�[�ԍ�(�I��)
            extraInfo.SupplierSlipNoEd = this.AcceptAnOrderNoEd_tNedit.GetInt();

			// �����`�[�ԍ�(�J�n)
			extraInfo.PartySaleSlipNumSt = this.PartySaleSlipNumSt_tEdit.Text;
			// �����`�[�ԍ�(�I��)
			extraInfo.PartySaleSlipNumEd = this.PartySaleSlipNumEd_tEdit.Text;

            // --- ADD 2008/07/16 -------------------------------->>>>>
            // �n��(�J�n)
            extraInfo.SalesAreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();

            // �n��(�I��)
            extraInfo.SalesAreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

            // �o�͎w��
            extraInfo.OutputDesignated = (Int32)this.tComboEditor_OutputDesignated.SelectedItem.DataValue;

            // �ݎ�w��
            extraInfo.StockOrderDivCd = (int)this.tComboEditor_StockOrderDivCd.SelectedItem.DataValue;

            // ���ŋ敪
            extraInfo.NewPageKind = (int)this.tComboEditor_NewPage.SelectedItem.DataValue;  
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // --- ADD START 3H ���� 2020/02/27 ----->>>>>
            // �ŕʓ���󎚋敪
            extraInfo.TaxPrintDiv = Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue);
            // XML�̐ŗ����擾
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                // �ŗ�1
                extraInfo.TaxRate1 = taxRatePrintInfo.TaxRate1;
                // �ŗ�2
                extraInfo.TaxRate2 = taxRatePrintInfo.TaxRate2;
            }
            // --- ADD END 3H ���� 2020/02/27 -----<<<<<

            //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>> 
            // �r����
            extraInfo.LinePrintDiv = (int)this.tComboEditor_LinePrintDiv.SelectedItem.DataValue;
            //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
            // ���v��
            extraInfo.PrintDailyFooter = (int)this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue; // ADD 2009/04/14
        }

        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            _StockConfDataTable = Broadleaf.Application.UIData.MAKON02249EA.CT_StockConfDataTable;
        }

        /// <summary>
        /// �L�����A���X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2006.09.08</br>
        /// </remarks>
        //private void GetCarrierList()
        //{
#if False
			// �L�����A�}�X�^�Ǎ�
            // ----- iitani c ---------- start 2007.05.22
            //CarrierAcs carrierAcs = new CarrierAcs();
            //ArrayList retList = new ArrayList();
            //int status = carrierAcs.Search(out retList, this._enterpriseCode);
            //foreach (CarrierU carrierU in retList)
            //{
            //    this._carrierList.Add(carrierU.CarrierCode, carrierU.CarrierName);
            //}
            CarrierOdrAcs carrierOdrAcs = new CarrierOdrAcs();
            List<Carrier> retList = new List<Carrier>();
            int status = carrierOdrAcs.SearchLocalDB(out retList, this._enterpriseCode, this._ownSectionCode);

            foreach (Carrier carrier in retList)
            {
                this._carrierList.Add(carrier.CarrierCode, carrier.CarrierName);
                this._carrierDspList.Add(carrier.CarrierName);
            }
            // ----- iitani c ---------- start 2007.05.22
#endif
        //}

        /// <summary>
        /// �ŏ�ʃt�H�[���擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2006.09.08</br>
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
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.30</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
          return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

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
        /// <br>Note        : ��ʂ����[�h���ꂽ�ہA��������C�x���g�ł��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void SFUKK01390UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._stockConfListAcs = new StockConfAcs();

            // �ŏ�ʃt�H�[���擾
		    this.GetTopForm();

            // ���_�I�v�V�����L�����擾����
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // �{��/���_�����擾����
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
            ParentToolbarGuideSettingEvent(true); // ADD 2010/08/16

            // �L�����A���X�g�擾
            //this.GetCarrierList();

            // --- ADD 2009/04/14 -------------------------------->>>>>
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_PrintDailyFooter);
            PrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/04/14 --------------------------------<<<<<

		    this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ��ʃA�N�e�B�u�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �������C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programer  : 18012�@Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
        /// </remarks>
        private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }


        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// <br>Update Note : 2020/02/27 3H ����</br>
        /// <br>�Ǘ��ԍ�    : 11570208-00 �y���ŗ��Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

            // --- ADD 2010/08/16 --- >>>>>
            if (e.PrevCtrl != null)
            {
                switch (e.PrevCtrl.Name)
                {
                    case "tComboEditor_NewPage":
                    case "PrintOder_tComboEditor":
                    case "tComboEditor_SupplierSlipCd":
                    case "tComboEditor_DebitNoteDiv":
                    case "tComboEditor_PrintType":
                    case "tComboEditor_OutputDesignated":
                    case "tComboEditor_StockOrderDivCd":
                    case "tComboEditor_LinePrintDiv": // ADD cheq 2012/12/26 Redmine#34098
                    case "tComboEditor_TaxPrintDiv":  // ADD 3H ���� 2020/02/27
                        this._preCtrlName = (TComboEditor)e.PrevCtrl;
                        this.setTComboEditorByName(e.PrevCtrl.Name);
                        this.CustomerCdSt_GuideBtn.Focus();
                        this._preCtrlName.Focus();
                        break; ;

                }
            }
            if (e.NextCtrl != null && (e.NextCtrl is TComboEditor))
            {
                this._preComboEditorValue = ((TComboEditor)e.NextCtrl).Value;
            }

            // --- ADD 2010/08/26 --- >>>>>
            this._preControl = e.NextCtrl;
            // --- ADD 2010/08/26 --- <<<<<
            // --- ADD 2010/08/16 --- <<<<<

            // ���͎x�� ============================================ //
            // �d����
            if ((e.PrevCtrl == this.StockDateStRF_tDateEdit) ||
                (e.PrevCtrl == this.StockDateEdRF_tDateEdit))
            {
                //AutoSetEndValue(this.StockDateStRF_tDateEdit, this.StockDateEdRF_tDateEdit);
            }

            // ADD 2008/10/07 �s��Ή�[5639]---------->>>>>
            // �o�͏�����S���҂֑J��
            if (e.PrevCtrl == this.PrintOder_tComboEditor)
            {
                // 2009.01.09 30413 ���� Shift+TAB�ł��S���҂ɑJ�ڂ���̂��C�� >>>>>>START
                //e.NextCtrl = this.tEdit_StockAgentCode_St;
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tEdit_StockAgentCode_St;
                }
                // 2009.01.09 30413 ���� Shift+TAB�ł��S���҂ɑJ�ڂ���̂��C�� <<<<<<END
            }
            // ADD 2008/10/07 �s��Ή�[5639]----------<<<<<

            // �d����R�[�h
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                //AutoSetEndValue(this.CustomerCodeStRF_Nedit, this.CustomerCodeEdRF_Nedit);
            }

            // �S���R�[�h
            if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
            {
                //AutoSetEndValue(this.StockAgentCodeSt_tEdit, this.StockAgentCodeEd_tEdit);
            }

            // �`�[�ԍ�
            if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
            {
                //AutoSetEndValue(this.AcceptAnOrderNoSt_tNedit, this.AcceptAnOrderNoEd_tNedit);
            }
            //  ---ADD 2010/08/12----------<<<<<<<

            // ADD 2010/08/16   ----  >>>>>>>
            if (e.Key == Keys.Left)
            {
                if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                {
                    // �݌Ɏ��w�� �� �o�͎w��
                    e.NextCtrl = this.tComboEditor_OutputDesignated;
                }
                else if (e.PrevCtrl == tComboEditor_OutputDesignated)
                {
                    // �o�͎w��     ��  ���s�^�C�v
                    e.NextCtrl = this.tComboEditor_PrintType;
                }
                else if (e.PrevCtrl == tComboEditor_PrintType)
                {
                    // ���s�^�C�v   �� �ԓ`�敪
                    e.NextCtrl = this.tComboEditor_DebitNoteDiv;
                }
                else if (e.PrevCtrl == this.tComboEditor_DebitNoteDiv)
                {
                    // �ԓ`�敪   ��  �`�[�敪
                    e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                }
                else if (e.PrevCtrl == this.tComboEditor_SupplierSlipCd)
                {
                    //  �`�[�敪  ��  �`�[�ԍ�(�I��)
                    e.NextCtrl = this.PartySaleSlipNumEd_tEdit;
                }
                else if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                {
                    //  �`�[�ԍ�(�I��)  ��  �`�[�ԍ�(�J�n)
                    e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                }
                else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                {
                    //  �`�[�ԍ�(�J�n)  �� �d��SEQ�ԍ�(�I��)
                    e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                }
                else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                {
                    //  �d��SEQ�ԍ�(�I��)  ��  �d��SEQ�ԍ�(�J�n)
                    e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                }
                else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                {
                    //  �d��SEQ�ԍ�(�J�n)  �� �d���� (�I��)
                    e.NextCtrl = this.tNedit_SupplierCd_Ed;
                }
                else if (e.PrevCtrl == tNedit_SupplierCd_Ed)
                {
                    // �d���� (�I��)   ��  �d���� (�J�n) 
                    e.NextCtrl = this.tNedit_SupplierCd_St;
                }
                else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // �d���� (�J�n)  ��  �n��(�I��) 
                    e.NextCtrl = tNedit_SalesAreaCode_Ed;
                }
                else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                {
                    //  �n��(�I��) ��  �n��(�J�n) 
                    e.NextCtrl = tNedit_SalesAreaCode_St;
                }
                else if (e.PrevCtrl == tNedit_SalesAreaCode_St)
                {
                    //  �n��(�J�n)  ��  �S����(�I��)
                    e.NextCtrl = tEdit_StockAgentCode_Ed;
                }
                else if (e.PrevCtrl == tEdit_StockAgentCode_Ed)
                {
                    // �S����(�I��) �� �S����(�J�n)
                    e.NextCtrl = tEdit_StockAgentCode_St;
                }
                else if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                {
                    // �S����(�J�n) �� �o�͏�
                    e.NextCtrl = PrintOder_tComboEditor;
                }
                /*----- DEL 2012/12/26 cheq Redmine#34098 ----->>>>> 
                else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                {
                    // �o�͏� �����v��
                    e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                }
                ----- DEL 2012/12/26 cheq Redmine#34098 -----<<<<<*/
                //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>                
                else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                {
                    // --- DEL START 3H ���� 2020/02/27 ----->>>>>            
                    //    // �o�͏� ���r����
                    //    e.NextCtrl = this.tComboEditor_LinePrintDiv;
                    // --- DEL END 3H ���� 2020/02/27 -----<<<<<
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    // �o�͏� �� �ŕʓ����
                    e.NextCtrl = this.tComboEditor_TaxPrintDiv;
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                }
                // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                {
                    // �ŕʓ���� �� ����
                    e.NextCtrl = this.tComboEditor_NewPage;
                }
                // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                {
                    // �r���� �����v��
                    e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());
                }
                //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
                else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                {
                    // ���v�� �� ����
                    this.ultraOptionSet_PrintDailyFooter.FocusedIndex = int.Parse(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue.ToString());        
                    e.NextCtrl = this.tComboEditor_NewPage;
                }
                else if (e.PrevCtrl == this.tComboEditor_NewPage)
                {
                    // ���� �� ���͓�(�I��)
                    e.NextCtrl = this.InputDayEdRF_tDateEdit.Controls[3];
                }
                else if (e.PrevCtrl == this.InputDayEdRF_tDateEdit)
                {
                    // ���͓�(�I��) �� ���͓�(�J�n)
                    e.NextCtrl = this.InputDayStRF_tDateEdit;
                }
                else if (e.PrevCtrl == this.InputDayStRF_tDateEdit)
                {
                    // ���͓�(�J�n) �� �d����(�I��)
                    e.NextCtrl = this.StockDateEdRF_tDateEdit.Controls[3];
                }
                else if (e.PrevCtrl == this.StockDateEdRF_tDateEdit)
                {
                    // �d����(�I��) �� �d����(�J�n)
                    e.NextCtrl = this.StockDateStRF_tDateEdit;
                }
                else if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                {
                    // �d����(�J�n)  �� �d����(�J�n)
                     e.NextCtrl = null;
                }
            }
            if (!e.ShiftKey)
            {
                if ((e.Key == Keys.Right) || (e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                    {
                        // �d����(�J�n)�@���@�d����(�I��)
                        e.NextCtrl = this.StockDateEdRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.StockDateEdRF_tDateEdit)
                    {
                        // �d����(�I��) ���@���͓�(�J�n)
                        e.NextCtrl = this.InputDayStRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.InputDayStRF_tDateEdit)
                    {
                        // ���͓�(�J�n) �� ���͓�(�I��)
                        e.NextCtrl = this.InputDayEdRF_tDateEdit;
                    }
                    else if (e.PrevCtrl == this.InputDayEdRF_tDateEdit)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// ���͓�(�I��)  ��  ���� 
                        //e.NextCtrl = this.tComboEditor_NewPage;
                        // ���͓�(�I��)  ��  �r����
                        e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_NewPage)
                    {
                        // --- DEL START 3H ���� 2020/02/27 ----->>>>>
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        ////// ����  ��   ���v��
                        ////e.NextCtrl = ultraOptionSet_PrintDailyFooter;
                        //// ����  ��   �o�͏�
                        //e.NextCtrl = this.PrintOder_tComboEditor;
                        //// UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                        //this.ultraOptionSet_PrintDailyFooter.FocusedIndex = this.ultraOptionSet_PrintDailyFooter.CheckedIndex;
                        // --- DEL END 3H ���� 2020/02/27 -----<<<<<
                        // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                        // ����  ��   �ŕʓ����
                        e.NextCtrl = this.tComboEditor_TaxPrintDiv;
                        // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    }
                    // --- ADD START 3H ���� 2020/02/27 ----->>>>>
                    else if (e.PrevCtrl == this.tComboEditor_TaxPrintDiv)
                    {
                        // �ŕʓ����  ��   �o�͏�
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    // --- ADD END 3H ���� 2020/02/27 -----<<<<<
                    /*----- DEL 2012/12/26 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                    {
                        // ���v��  �� �o�͏�
                        e.NextCtrl = this.PrintOder_tComboEditor;
                    }
                    ----- DEL 2012/12/26 cheq Redmine#34098 -----<<<<<*/
                    //----- ADD 2012/12/26 cheq Redmine#34098 ----->>>>>
                    else if (e.PrevCtrl == this.ultraOptionSet_PrintDailyFooter)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// ���v��  �� �r����
                        //e.NextCtrl = this.tComboEditor_LinePrintDiv;
                        // ���v��  �� ����
                        e.NextCtrl = this.tComboEditor_NewPage;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    else if (e.PrevCtrl == this.tComboEditor_LinePrintDiv)
                    {
                        // UPD 2013/03/05 T.Miyamoto ------------------------------>>>>>
                        //// �r����  �� �o�͏�
                        //e.NextCtrl = this.PrintOder_tComboEditor;
                        // �r����  �� ���v��
                        e.NextCtrl = this.ultraOptionSet_PrintDailyFooter;
                        // UPD 2013/03/05 T.Miyamoto ------------------------------<<<<<
                    }
                    //----- ADD 2012/12/26 cheq Redmine#34098 -----<<<<<
                    else if (e.PrevCtrl == this.PrintOder_tComboEditor)
                    {
                        // �o�͏�  �� �S����(�J�n)
                        e.NextCtrl = this.tEdit_StockAgentCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                    {
                        // �S����(�J�n) �� �S����(�I��)
                        e.NextCtrl = this.tEdit_StockAgentCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_StockAgentCode_Ed)
                    {
                        // �S����(�I��) �� �n��(�J�n)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // �n��(�J�n) �� �n��(�I��)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // �n��(�I��) �� �d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                    else if (e.PrevCtrl == tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n) �� �d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��) �� �d��SEQ�ԍ�(�J�n)
                        e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                    {
                        // �d��SEQ�ԍ�(�J�n) �� �d��SEQ�ԍ�(�I��)
                        e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                    {
                        // �d��SEQ�ԍ�(�I��) �� �`�[�ԍ�(�J�n)
                        e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                    {
                        // �`�[�ԍ�(�J�n) �� �`�[�ԍ�(�I��)
                        e.NextCtrl = this.PartySaleSlipNumEd_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                    {
                        // �`�[�ԍ�(�I��) �� �`�[�敪
                        e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SupplierSlipCd)
                    {
                        // �`�[�敪  ��  �ԓ`�敪
                        e.NextCtrl = this.tComboEditor_DebitNoteDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_DebitNoteDiv)
                    {
                        // �ԓ`�敪  ��  ���s�^�C�v
                        e.NextCtrl = this.tComboEditor_PrintType;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_PrintType)
                    {
                        // ���s�^�C�v �� �o�͎w��
                        e.NextCtrl = this.tComboEditor_OutputDesignated;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDesignated)
                    {
                        // �o�͎w��   �� �݌Ɏ��w��
                        e.NextCtrl = this.tComboEditor_StockOrderDivCd;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                    {
                        // �݌Ɏ��w�� �� �d����(�J�n)
                        e.NextCtrl = this.StockDateStRF_tDateEdit;
                    }
                    if (e.PrevCtrl == this.tComboEditor_StockOrderDivCd)
                    {
                        // --- ADD 2010/08/26 ---------->>>>>
                        if (this.ParentPrintCall != null)
                        {
                            this.ParentPrintCall();
                        }
                        // --- ADD 2010/08/26 ----------<<<<<
                        e.NextCtrl = null;
                    }
                }

                if (e.NextCtrl != null)
                {
                    switch (e.NextCtrl.Name)
                    {
                        case "tEdit_StockAgentCode_St":
                        case "tEdit_StockAgentCode_Ed":
                        case "tNedit_SalesAreaCode_St":
                        case "tNedit_SalesAreaCode_Ed":
                        case "tNedit_SupplierCd_St":
                        case "tNedit_SupplierCd_Ed":
                            {
                                ParentToolbarGuideSettingEvent(true);
                                break;
                            }
                        default:
                            {
                                if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                    || e.NextCtrl is TDateEdit || e.NextCtrl is UltraOptionSet || e.NextCtrl is UltraButton)
                                {
                                    ParentToolbarGuideSettingEvent(false);
                                }
                                break;
                            }
                    }
                }
                
            }
            else
            {
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    if (e.PrevCtrl == this.PartySaleSlipNumEd_tEdit)
                    {
                        e.NextCtrl = this.PartySaleSlipNumSt_tEdit;
                    }
                    else if (e.PrevCtrl == this.PartySaleSlipNumSt_tEdit)
                    {
                        e.NextCtrl = this.AcceptAnOrderNoEd_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoEd_tNedit)
                    {
                        e.NextCtrl = this.AcceptAnOrderNoSt_tNedit;
                    }
                    else if (e.PrevCtrl == this.AcceptAnOrderNoSt_tNedit)
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_St;                   
                    }
                    else if (e.PrevCtrl == this.StockDateStRF_tDateEdit)
                    {
                        e.NextCtrl = null;
                    }
                }
            }
            // --- 2010/08/16 ----------<<<<<
        }

        /// <summary>
        /// �����^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʏ����\��
            this.InitialScreenSetting();
        
            // �����t�H�[�J�X�ݒ�
			//this.InputDayStRF_tDateEdit.Focus();  // DEL 2008/07/16
            this.StockDateStRF_tDateEdit.Focus();   // ADD 2008/07/16

    	    // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);

            // ADD 2008/10/07 �s��Ή�[5639]---------->>>>>
            // �͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̐ݒ�
            // �S���ҁF�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_St,
                this.SalesEmployeeCdSt_GuideBtn,
                this.tEdit_StockAgentCode_Ed
            ));
            // �S���ҁF�I��
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_Ed,
                this.SalesEmployeeCdEd_GuideBtn,
                this.tNedit_SalesAreaCode_St
            ));

            // �n��F�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SalesAreaCode_St,
                this.SalesAreaCodeSt_GuidBtn,
                this.tNedit_SalesAreaCode_Ed
            ));
            // �n��F�I��
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SalesAreaCode_Ed,
                this.SalesAreaCodeEd_GuidBtn,
                this.tNedit_SupplierCd_St
            ));

            // �d����F�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.CustomerCdSt_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));
            // �d����F�I��
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_Ed,
                this.CustomerCdEd_GuideBtn,
                this.AcceptAnOrderNoSt_tNedit
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            // ADD 2008/10/07 �s��Ή�[5639]----------<<<<<
	    }

    	        
        /// <summary>
        /// Control.GroupCollapsing�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �G�N�X�v���[���o�[�̃O���[�v��W�J�����ۂɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.14</br>
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

	    #endregion


	    #region IPrintConditionInpTypeChart �����o


	    #endregion

	    #region IPrintConditionInpTypeSelectedSection �����o

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
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note       : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 22021�@�J���@�͍K</br>
        /// <br>Date       : 2006.02.14</br>
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
        /// <param name="IsOptSection"></param>
        /// <remarks>
        /// <br>Note       : ���_�I�v�V�����擾�v���p�e�B</br>
        /// <br>Programmer : 22021 �J���@�͍K</br>
        /// <br>Date       : 2006.03.22</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary>
        /// �{�Ћ@�\�擾�v���p�e�B
        /// </summary>
        /// <param name="IsMainOfficeFunc"></param>
        /// <remarks>
        /// <br>Note       : �{�Ћ@�\�擾�v���p�e�B</br>
        /// <br>Programmer : 22021 �J���@�͍K</br>
        /// <br>Date       : 2006.03.22</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary>
        /// �v�㋒�_�I������
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note       : �v�㋒�_�I������</br>
        /// <br>Programmer : 22021 �J���@�͍K</br>
        /// <br>Date       : 2006.01.19</br>
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
        /// <br>Note       : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 22021�@�J���@�͍K</br>
        /// <br>Date       : 2006.02.14</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            this._selectedAddUpCd = addUpCd;
            return;
        }


        #endregion
        
        #region [--- DEL 2008/12/02 G.Miyatsu ---]
        ///// <summary>
        ///// ���Ӑ�I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
        //        this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "���Ӑ���̎擾�Ɏ��s���܂����B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}

        ///// <summary>
        ///// ���Ӑ�I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
        //        this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "���Ӑ���̎擾�Ɏ��s���܂����B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}
        # endregion

        #region ���K�C�h�N���C�x���g
        /// <summary>
        /// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
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
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;            
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 
        }
        #endregion

        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // --- DEL 2008/07/16 -------------------------------->>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            // --- DEL 2008/07/16 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
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
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(false);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/07/16 --------------------------------<<<<< 
        }

        /// <summary>
        /// ��t�]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�N��
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_St.DataText = employee.EmployeeCode.TrimEnd();
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ��t�]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�N��
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		private void Main_ultraExplorerBar_GroupCollapsing_1(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}

		}

		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}

		}

        /// <summary>
        /// �n��(�J�n)�K�C�h�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �n��(�̔��G���A)�K�C�h���N�����܂��B </br>
        /// <br>Programmer  : 30415 �ēc �ύK</br>
        /// <br>Date        : 2008/07/16</br>
        /// </remarks>
        private void SalesAreaCodeSt_GuidBtn_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_userGuideAcs == null)
                {
                    _userGuideAcs = new UserGuideAcs();
                }

                // ���[�U�[�K�C�h�N��
                if (_userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 21) == 0)
                {
                    // DELL 2008/10/02 �s��Ή�[5638]��
                    //this.tNedit_SalesAreaCode_St.Text = userGdBd.GuideCode.ToString();
                    this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);    // ADD 2008/10/02 �s��Ή�[5638]
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                   
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// �n��(�I��)�K�C�h�{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �n��(�̔��G���A)�K�C�h���N�����܂��B </br>
        /// <br>Programmer  : 30415 �ēc �ύK</br>
        /// <br>Date        : 2008/07/16</br>
        /// </remarks>
        private void SalesAreaCodeEd_GuidBtn_Click(object sender, EventArgs e)
        {
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_userGuideAcs == null)
                {
                    _userGuideAcs = new UserGuideAcs();
                }

                // ���[�U�[�K�C�h�N��
                if (_userGuideAcs.ExecuteGuid(_enterpriseCode, out userGdHd, out userGdBd, 21) == 0)
                {
                    // DELL 2008/10/02 �s��Ή�[5638]��
                    //this.tNedit_SalesAreaCode_Ed.Text = userGdBd.GuideCode.ToString();
                    this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);    // ADD 2008/10/02 �s��Ή�[5638]
                    this.SelectNextControl((Control)sender, true, true, true, true); // ADD 2010/08/16
                    ParentToolbarGuideSettingEvent(true);  // ADD 2010/08/16
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //---ADD 2010/08/16---------->>>>>
        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �o�͏�����̑Ή�</br>
        /// </remarks>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            switch (control.Name)
            {
                // �o�͏�
                case "PrintOder_tComboEditor":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:�d���恨�d�������d��SEQ�ԍ�":
                                control.Value = 5;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:�d���恨���͓����d��SEQ�ԍ�":
                                control.Value = 6;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:�d���恨�d�������`�[�ԍ�":
                                control.Value = 1;
                                inputErrorFlg = false;
                                break;
                            case "3":
                            //case "3:�d���恨���͓����d��SEQ�ԍ�": // DEL cheq 2012/12/26 Redmine#34098
                            case "3:�d���恨���͓����`�[�ԍ�": // ADD cheq 2012/12/26 Redmine#34098
                                control.Value = 3;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                // �`�[�敪
                case "tComboEditor_SupplierSlipCd":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:�S��":
                                control.Value = 0;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:�d��":
                                control.Value = 10;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:�ԕi":
                                control.Value = 20;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                // �݌Ɏ��w��
                case "tComboEditor_StockOrderDivCd":
                    {
                        switch (control.Text.Trim())
                        {
                            case "0":
                            case "0:�S��":
                                control.Value = -1;
                                inputErrorFlg = false;
                                break;
                            case "1":
                            case "1:�݌�":
                                control.Value = 1;
                                inputErrorFlg = false;
                                break;
                            case "2":
                            case "2:���":
                                control.Value = 0;
                                inputErrorFlg = false;
                                break;
                        }
                    }
                    break;
                default:
                    {
                        foreach (Infragistics.Win.ValueListItem item in control.Items)
                        {
                            if (item.DataValue == control.Value)
                            {
                                inputErrorFlg = false;
                                break;
                            }
                        }
                    }
                    break;
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

        //---ADD 2010/08/16----------<<<<<
        /// <summary>
        /// ultraOptionSet_PrintDailyFooter_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2012/12/26 cheq</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
        /// </remarks>
        private void ultraOptionSet_PrintDailyFooter_KeyDown(object sender, KeyEventArgs e)
        {
            this.ultraOptionSet_PrintDailyFooter.FocusedIndex = this.ultraOptionSet_PrintDailyFooter.CheckedIndex;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        this.tComboEditor_NewPage.Focus();
                        break;
                    }
                case Keys.Right:
                    {
                        //this.PrintOder_tComboEditor.Focus(); // DEL cheq 2012/12/26 Redmine#34098
                        this.tComboEditor_LinePrintDiv.Focus(); // ADD cheq 2012/12/26 Redmine#34098

                        break;
                    }
                default:
                    break;
            }
        }

        //---ADD 2010/08/16----------<<<<<
        // --- ADD START 3H ���� 2020/02/27---------->>>>>
        # region [����p�ŗ����XML]
        /// <summary>
        /// ����p�ŗ����
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            private string _taxRate1;
            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            private string _taxRate2;

            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }
        # endregion
        # region[�f�V���A���C�Y����]
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <returns>�f�V���A���C�Y����</returns>
        /// <remarks> 
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // ����p�ŗ����XML�t�@�C�����݂̔��f
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName));
                    // �ŗ��ݒ���ŗ��P
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // �ŗ��ݒ���ŗ��Q
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // �ŗ����ݒ�̏ꍇ�A
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // �����ŗ��l�̏ꍇ
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // �����ȊO�̏ꍇ�A
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // �ŗ��l�̓}�C�i�X�̏ꍇ
                        (dTaxRate1 < 0) || (dTaxRate2 < 0) ||
                        // �ŗ��l��10�ȏ�̏ꍇ
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                    return status;
                }
            }
            else
            {
                errmsg = "�ŗ��ݒ���t�@�C��(" + ctPrintXmlFileName + ")�����݂��܂���B";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL; ;
        }
        # endregion        
        // --- ADD END 3H ���� 2020/02/27----------<<<<<
    }
}
