//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Globarization;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���q�ʏo�׎��ѕ\UI�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�ʏo�׎��ѕ\UI�ŁA���o��������͂��܂��B</br>       
    /// <br>Programmer : ����</br>                                   
    /// <br>Date       : 2009.09.15</br>                                   
    /// </remarks>
    public partial class PMSYA02000UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���q�ʏo�׎��ѕ\UI�N���X�R���X�g���N�^�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �@
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\UI����������уC���X�^���X�̐������s��</br>                 
        /// <br>Programmer : ����</br>                                  
        /// <br>Date       : 2009.09.15</br>                                     
        /// </remarks>
        public PMSYA02000UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();

            this._carMngInputAcs = CarMngInputAcs.GetInstance();
        }

        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member

        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;
        // �ݒ�{�^���\���L���v���p�e�B
        private bool _visibledSetButton = true;
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        // ���O�C�����
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private CarShipRsltListCndtn _carShipRsltListCndtn;

        //���t�擾���i
        private DateGetAcs _dateGet;

        private CarMngInputAcs _carMngInputAcs;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;
        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;
        // �O���[�v�R�[�h�K�C�h
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary>���q���l�K�C�h�敪 </summary>
        public static readonly int CT_DIVCODE_NOTEGUIDEDIVCD_4 = 201;
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMSYA02000UA";
        // �v���O����ID
        private const string ct_PGID = "PMSYA02000U";
        // ���[����
        private const string PDF_PRINT_NAME = "���q�ʏo�׎��ѕ\";
        private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
        private const string PDF_PRINT_KEY = "156cc2cb-3afc-45bc-ac54-5017c884fa2f";
        private string _printKey = PDF_PRINT_KEY;
        #endregion �� Interface member

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̓��͂��s���ł��B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        /// <summary> �ݒ�{�^���\���v���p�e�B </summary>
        public bool VisibledSetButton
        {
            get { return this._visibledSetButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
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

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._carShipRsltListCndtn;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
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

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypeSelectedSection �����o
        #region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion �� Public Property

        #region �� Public Method

        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();

                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }
            }
            // ���_�I��������������
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I�����_�ݒ菈��
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
        }
        #endregion

        #region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypeSelectedSection �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return _printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E�敪
                this.uos_GroupBySectionDiv.Value = 0;   // �W�v���@
                this.uos_RsltTtlDiv.Value = 0;          //�݌Ɏ��w��
                this.uos_GoodsNoPrint.Value = 1;        //�i�ԏo��
                this.uos_CostGrossPrint.Value = 1;      //�����E�e���o��
                this.uos_NewPageDiv.Value = 1;          //����

                // �����l�Z�b�g�E������
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                this.tEdit_CarMngCode_St.DataText = string.Empty;
                this.tEdit_CarMngCode_Ed.DataText = string.Empty;
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                this.tEdit_CarSlipNote.DataText = string.Empty;
                this.tComboEditor_ModelFullNameFuzzy.Value = 0;

                // �����
                this.tde_St_SalesDay.SetDateTime(DateTime.Now);
                this.tde_Ed_SalesDay.SetDateTime(DateTime.Now);

                // ���גP��
                Infragistics.Win.ValueListItem listItem;
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�i��";
                this.tComboEditor_Detail.Items.Add(listItem);
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�a�k�R�[�h";
                this.tComboEditor_Detail.Items.Add(listItem);
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "�O���[�v�R�[�h";
                this.tComboEditor_Detail.Items.Add(listItem);
                this.tComboEditor_Detail.Value = 0;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CarMngNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BlGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BlGroupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_SlipNoteCar, Size16_Index.STAR1);


                // �����t�H�[�J�X�Z�b�g
                this.uos_GroupBySectionDiv.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����

        /// <summary>
        /// ���t�͈̓`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;


            // ������i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref tde_St_SalesDay, ref tde_Ed_SalesDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_InputError);
                            errComponent = this.tde_St_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I����{0}", ct_InputError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�����{0}", ct_RangeError);
                            errComponent = this.tde_Ed_SalesDay;
                            status = false;
                        }
                        break;
                }
            }
            if(status == false)
            {
                return status;
            }
            // ���͓��i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref tde_St_InputDay, ref tde_Ed_InputDay) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_InputError);
                            errComponent = this.tde_St_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I����{0}", ct_InputError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("���͓�{0}", ct_RangeError);
                            errComponent = this.tde_Ed_InputDay;
                        }
                        status = false;
                        break;
                }
            }
            if (status == false)
            {
                return status;
            }
            // ���Ӑ�
            if (this.tNedit_CustomerCode_St.GetInt() > GetEndCode(this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_Ed;
                status = false;
            }
            // �Ǘ��ԍ�
            else if((this.tEdit_CarMngCode_St.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_CarMngCode_Ed.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_CarMngCode_St.DataText.TrimEnd().CompareTo(this.tEdit_CarMngCode_Ed.DataText.TrimEnd()) > 0)) 
            {
                errMessage = string.Format("�Ǘ��ԍ�{0}", ct_RangeError);
                errComponent = this.tEdit_CarMngCode_Ed;
                status = false;
            }
            // ��ٰ�ߺ���
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed))
            {
                errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_Ed;
                status = false;
            }
            // �a�k����
            else if (this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode(this.tNedit_BLGoodsCode_Ed))
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_Ed;
                status = false;
            }
            // �i��
            else if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                 (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_Ed;
                status = false;
            }

            return status;
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
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

        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._carShipRsltListCndtn = new CarShipRsltListCndtn();
            try
            {
                // ��ƃR�[�h
                this._carShipRsltListCndtn.EnterpriseCode = this._enterpriseCode;
                // �u�S���_�v���I������Ă���ꍇ�̓��X�g���N���A
                bool allSections = false;

                foreach (object obj in _selectedSectionList.Values)
                {
                    if (obj is string)
                    {
                        if ((obj as string) == "0")
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if (allSections)
                {
                    _selectedSectionList.Clear();
                }

                // ���_�I�v�V����
                this._carShipRsltListCndtn.IsOptSection = this._isOptSection;
                // �v�㋒�_�R�[�h�i�����w��j
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._carShipRsltListCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // �W�v���@
                this._carShipRsltListCndtn.GroupBySectionDiv = (CarShipRsltListCndtn.GroupBySectionDivState)this.uos_GroupBySectionDiv.Value;
                // �����
                this._carShipRsltListCndtn.SalesDateSt = this.tde_St_SalesDay.GetDateTime();
                this._carShipRsltListCndtn.SalesDateEd = this.tde_Ed_SalesDay.GetDateTime();
                // ���͓�
                this._carShipRsltListCndtn.InputDateSt = this.tde_St_InputDay.GetDateTime();
                this._carShipRsltListCndtn.InputDateEd = this.tde_Ed_InputDay.GetDateTime();
                // �݌Ɏ��w��
                this._carShipRsltListCndtn.RsltTtlDiv = (CarShipRsltListCndtn.RsltTtlDivState)this.uos_RsltTtlDiv.Value;
                // �i�ԏo��
                this._carShipRsltListCndtn.GoodsNoPrint = (CarShipRsltListCndtn.GoodsNoPrintState)this.uos_GoodsNoPrint.Value;
                // �����E�e���o��
                this._carShipRsltListCndtn.CostGrossPrint = (CarShipRsltListCndtn.CostGrossPrintState)this.uos_CostGrossPrint.Value;
                // ����
                this._carShipRsltListCndtn.NewPageDiv = (CarShipRsltListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                // ���גP��
                this._carShipRsltListCndtn.DetailDataValue = (CarShipRsltListCndtn.DetailDataValueState)this.tComboEditor_Detail.Value;
                // ���Ӑ�
                this._carShipRsltListCndtn.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                this._carShipRsltListCndtn.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                // �Ǘ��ԍ�
                this._carShipRsltListCndtn.CarMngCodeSt = this.tEdit_CarMngCode_St.Text;
                this._carShipRsltListCndtn.CarMngCodeEd = this.tEdit_CarMngCode_Ed.Text;
                // �O���[�v�R�[�h
                this._carShipRsltListCndtn.BLGroupCodeSt = this.tNedit_BLGloupCode_St.GetInt();
                this._carShipRsltListCndtn.BLGroupCodeEd = this.tNedit_BLGloupCode_Ed.GetInt();
                // �a�k�R�[�h
                this._carShipRsltListCndtn.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                this._carShipRsltListCndtn.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                // �i��
                this._carShipRsltListCndtn.GoodsNoSt = this.tEdit_GoodsNo_St.Text;
                this._carShipRsltListCndtn.GoodsNoEd = this.tEdit_GoodsNo_Ed.Text;
                // ���q���l
                this._carShipRsltListCndtn.SlipNoteCar = this.tEdit_CarSlipNote.Text;
                // ���q���o�敪
                this._carShipRsltListCndtn.CarOutDiv = (CarShipRsltListCndtn.CarOutDivState)this.tComboEditor_ModelFullNameFuzzy.Value;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #endregion �� Private Method

        # region Control Events

        /// <summary>
        /// PMSYA02000UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void PMSYA02000UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);
        }
        # endregion

        # region �K�C�h �C�x���g
        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "ReportPublishGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == ub_St_CustomerGuide)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tEdit_CarMngCode_St.Focus();
                }
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.ub_St_CustomerGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }
            _customerGuideOK = true;

        }

        /// <summary>
        /// �O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BlGroupCodeGuide_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_GoodsNo_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ���q���l�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ���q���l�K�C�h��ʂ�\�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void ub_SlipNoteCar_Click(object sender, EventArgs e)
        {
            NoteGuidAcs noteGuideAcs = new NoteGuidAcs();
            NoteGuidBd noteGuideBd;

            int status = noteGuideAcs.ExecuteGuide(out noteGuideBd, this._enterpriseCode, CT_DIVCODE_NOTEGUIDEDIVCD_4);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_CarSlipNote.Text = noteGuideBd.NoteGuideName;
                // ���t�H�[�J�X
                this.tComboEditor_ModelFullNameFuzzy.Focus();
              
            }
        }

        /// <summary>
        /// �Ǘ��ԍ��K�C�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void ub_St_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // �u�V�K�o�^�v�s�\���Ȃ�
                paramInfo.IsDispNewRow = false;
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = true;
                // ���Ӑ�R�[�h�i�荞�ݖ���
                paramInfo.IsCheckCustomerCode = false;
                // �Ǘ��ԍ��i�荞�ݖ���
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "�V�K�o�^")
                    {
                        this.tEdit_CarMngCode_St.Text = selectedInfo.CarMngCode;
                        this.tEdit_CarMngCode_Ed.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �Ǘ��ԍ��K�C�h �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void ub_Ed_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // �u�V�K�o�^�v�s�\���Ȃ�
                paramInfo.IsDispNewRow = false;
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = true;
                // ���Ӑ�R�[�h�i�荞�ݖ���
                paramInfo.IsCheckCustomerCode = false;
                // �Ǘ��ԍ��i�荞�ݖ���
                paramInfo.IsCheckCarMngCode = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "�V�K�o�^")
                    {
                        this.tEdit_CarMngCode_Ed.Text = selectedInfo.CarMngCode;
                        this.tNedit_BLGloupCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �W�v���@�@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_GroupBySectionDiv_ValueChanged(object sender, EventArgs e)
        {
            // ���ѕ\
            if((int)this.uos_GroupBySectionDiv.Value == 0)
            {
                this.tComboEditor_Detail.Enabled = true;
            }
            // ���X�g
            else if ((int)this.uos_GroupBySectionDiv.Value == 1)
            {
                this.tComboEditor_Detail.Enabled = false;
                this.tComboEditor_Detail.Value = 0;
            }
        }

        /// <summary>
        /// ���s�^�C�v�@�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_Detail_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 0)
            {
                // �i�ԏo��
                this.uos_GoodsNoPrint.Enabled = true;
                this.uos_GoodsNoPrint.Value = 1;
            }
            else
            {
                // �i�ԏo��
                this.uos_GoodsNoPrint.Enabled = false;
                this.uos_GoodsNoPrint.Value = 0;
            }

        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�J�X�R���g���ɔ������܂��B</br>
        /// <br>Programmer  : ����</br>
        /// <br>Date        : 2009.09.15</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            string str = null;
            if (!e.ShiftKey)
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_CustomerCode_St":
                            {
                                if (0 == this.tNedit_CustomerCode_St.GetInt())
                                {
                                    this.tNedit_CustomerCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                break;
                            }
                        case "tNedit_CustomerCode_Ed":
                            {
                                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                                {
                                    this.tNedit_CustomerCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_St;
                                break;
                            }
                        case "tEdit_CarMngCode_St":
                            {
                                str = this.tEdit_CarMngCode_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_Ed;
                                break;
                            }
                        case "tEdit_CarMngCode_Ed":
                            {
                                str = this.tEdit_CarMngCode_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_Ed.Text = string.Empty;
                                }

                                e.NextCtrl = this.tNedit_BLGloupCode_St;
                                break;
                            }
                        case "tNedit_BLGloupCode_St":
                            {
                                if (0 == this.tNedit_BLGloupCode_St.GetInt())
                                {
                                    this.tNedit_BLGloupCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                                break;
                            }
                        case "tNedit_BLGloupCode_Ed":
                            {
                                if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                break;
                            }
                        case "tNedit_BLGoodsCode_St":
                            {
                                if (0 == this.tNedit_BLGoodsCode_St.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                break;
                            }
                        case "tNedit_BLGoodsCode_Ed":
                            {
                                if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_St;
                                break;
                            }
                        case "tEdit_GoodsNo_St":
                            {
                                str = this.tEdit_GoodsNo_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                break;
                            }
                        case "tEdit_GoodsNo_Ed":
                            {
                                str = this.tEdit_GoodsNo_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarSlipNote;
                                break;
                            }
                        case "tEdit_CarSlipNote":
                            {
                                e.NextCtrl = this.tComboEditor_ModelFullNameFuzzy;
                                break;
                            }
                    }
                }
            }
            else
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    switch (e.PrevCtrl.Name)
                    {
                        case "tNedit_CustomerCode_St":
                            {
                                if (0 == this.tNedit_CustomerCode_St.GetInt())
                                {
                                    this.tNedit_CustomerCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tComboEditor_Detail;
                                break;
                            }
                        case "tNedit_CustomerCode_Ed":
                            {
                                if (0 == this.tNedit_CustomerCode_Ed.GetInt())
                                {
                                    this.tNedit_CustomerCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                                break;
                            }
                        case "tEdit_CarMngCode_St":
                            {
                                str = this.tEdit_CarMngCode_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                break;
                            }
                        case "tEdit_CarMngCode_Ed":
                            {
                                str = this.tEdit_CarMngCode_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_CarMngCode_Ed.Text = string.Empty;
                                }

                                e.NextCtrl = this.tEdit_CarMngCode_St;
                                break;
                            }
                        case "tNedit_BLGloupCode_St":
                            {
                                if (0 == this.tNedit_BLGloupCode_St.GetInt())
                                {
                                    this.tNedit_BLGloupCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_CarMngCode_Ed;
                                break;
                            }
                        case "tNedit_BLGloupCode_Ed":
                            {
                                if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_St;
                                break;
                            }
                        case "tNedit_BLGoodsCode_St":
                            {
                                if (0 == this.tNedit_BLGoodsCode_St.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                                break;
                            }
                        case "tNedit_BLGoodsCode_Ed":
                            {
                                if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
                                {
                                    this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_St;
                                break;
                            }
                        case "tEdit_GoodsNo_St":
                            {
                                str = this.tEdit_GoodsNo_St.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_St.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                                break;
                            }
                        case "tEdit_GoodsNo_Ed":
                            {
                                str = this.tEdit_GoodsNo_Ed.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_GoodsNo_Ed.Text = string.Empty;
                                }
                                e.NextCtrl = this.tEdit_GoodsNo_St;
                                break;
                            }
                        case "tEdit_CarSlipNote":
                            {
                                e.NextCtrl = this.tEdit_GoodsNo_Ed;
                                break;
                            }
                        case "uos_GroupBySectionDiv":
                            {
                                e.NextCtrl = this.tComboEditor_ModelFullNameFuzzy;
                                break;
                            }
                        case "tComboEditor_ModelFullNameFuzzy":
                            {
                                e.NextCtrl = this.tEdit_CarSlipNote;
                                break;
                            }
                    }
                }
            }
            
        }


        # endregion
        
    }
}
