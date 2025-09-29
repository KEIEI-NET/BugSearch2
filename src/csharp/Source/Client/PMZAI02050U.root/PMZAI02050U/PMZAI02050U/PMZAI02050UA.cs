//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌ɊŔ��
// �v���O�����T�v   : �݌ɊŔ��UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2008/12/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/13  �C�����e : ��Q�Ή�13102
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌ɊŔ��UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊŔ��UI�t�H�[���N���X</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>Update Note: 2009/04/13 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13102</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI02050UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMZAI02050UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // �K�C�h�A�N�Z�X�N���X������
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();

            // ���o�����N���X
            this._stockSignOrderCndtn = new StockSignOrderCndtn();
        }
        #endregion

        #region �� private�萔
        #region Interface�֘A
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMZAI02050UA";
        // �v���O����ID
        private const string ct_PGID = "PMZAI02050U";
        //// ���[����
        private string _printName = "�݌ɊŔ��";
        // ���[�L�[	
        private string _printKey = "6851b06d-20e0-4679-911b-5a19f3e6ebd1";
        #endregion
        #endregion

        #region �� private�ϐ�

        #region Interface�֘A
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 DEL
        //private bool _canPdf = true;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
        private bool _canPdf = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B
	    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 DEL
        //private bool _visibledPdfButton = true;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/26 ADD
        private bool _visibledPdfButton = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/26 ADD
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �]�ƈ��}�X�^�A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;
        // ���[�U�}�X�^�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;

        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // �q�ɃK�C�h�p
        WarehouseAcs _wareHouseAcs;

        // �݌ɊŔ�� ���o�����f�[�^�N���X
        private StockSignOrderCndtn _stockSignOrderCndtn;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �C�x���g
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        #region Public�v���p�e�B
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

        #endregion

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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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

            switch ((int)this.tComboEditor_LabelType.SelectedItem.DataValue)
            {
                //���i�ʁA���Ӑ�ʁA�S���ҕ�
                case (int)StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine:
                    {
                        printInfo.PrintPaperSetCd = 0;
                        break;
                    }
                case (int)StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine:
                    {
                        printInfo.PrintPaperSetCd = 1;
                        break;
                    }
                case (int)StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine:
                    {
                        printInfo.PrintPaperSetCd = 2;
                        break;
                    }
                //BL�R�[�h��
                case (int)StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven:
                    {
                        printInfo.PrintPaperSetCd = 3;
                        break;
                    }
            }
            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._stockSignOrderCndtn;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this.Show();
            return;
        }
        #endregion

        #endregion
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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
            get { return this._printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� private���\�b�h
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ��������s��</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �K�C�h�{�^���ݒ�
                this.SetIconImage(this.uButton_GoodsMakerCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GoodsMakerCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCodeStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_WarehouseCodeEdGuid, Size16_Index.STAR1);

                // �q��
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                // ���[�J�[
                this.tNedit_GoodsMakerCd_St.SetInt(0);
                this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                // �I��
                this.tEdit_WarehouseShelfNo_St.DataText = string.Empty;
                this.tEdit_WarehouseShelfNo_Ed.DataText = string.Empty;
                // �i��
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;

                // �����
                this.tComboEditor_PrintOrder.Value = 0;

                // ����^�C�v
                this.tComboEditor_PrintType.Value = 0;
                // ���x���^�C�v
                this.tComboEditor_LabelType.Value = 0;
                // ����J�n�s
                this.tComboEditor_StartRow.ResetItems();
                this.SetPrintStartRow();
                this.tComboEditor_StartRow.SelectedIndex = 0;
                
                // �����t�H�[�J�X�ݒ�
                this.tEdit_WarehouseCode_St.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

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

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // �q��
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�q�ɃR�[�h{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // ���[�J�[
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("���[�J�[�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // �I��
            if ((this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�I��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // �i��
            if ((this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            

            return status;
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �S���_�`�F�b�N
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
                this._stockSignOrderCndtn.IsOptSection = this._isOptSection;
                // ���_�R�[�h
                this._stockSignOrderCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ��ƃR�[�h
                this._stockSignOrderCndtn.EnterpriseCode = this._enterpriseCode;

                this._stockSignOrderCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText; // �q�ɃR�[�h(�J�n)
                this._stockSignOrderCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText; // �q�ɃR�[�h(�I��)
                this._stockSignOrderCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt(); // ���i���[�J�[�R�[�h(�J�n)
                this._stockSignOrderCndtn.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt(); // ���i���[�J�[�R�[�h(�I��)
                this._stockSignOrderCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.DataText; // �q�ɒI��(�J�n)
                this._stockSignOrderCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.DataText; // �q�ɒI��(�I��)
                this._stockSignOrderCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.DataText; // ���i�ԍ�(�J�n)
                this._stockSignOrderCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText; // ���i�ԍ�(�I��)
                this._stockSignOrderCndtn.PrintOrder 
                    = (StockSignOrderCndtn.PrintOrderState)this.tComboEditor_PrintOrder.SelectedItem.DataValue; // �����
                this._stockSignOrderCndtn.PrintType 
                    = (StockSignOrderCndtn.PrintTypeState)this.tComboEditor_PrintType.SelectedItem.DataValue; // ����^�C�v
                this._stockSignOrderCndtn.LabelType 
                    = (StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue; // ���x���^�C�v
                this._stockSignOrderCndtn.PrintStartRow 
                    = (StockSignOrderCndtn.PrintStartRowState)this.tComboEditor_StartRow.SelectedItem.DataValue; // ����J�n�s
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ����J�n�s�ݒ�
        /// </summary>
        private void SetPrintStartRow()
        {
            Infragistics.Win.ValueListItem listItem;

            if ((StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                || (StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
            {
                // �h�b�g
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�Q�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "�R�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "�S�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "�T�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "�U�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "�V�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "�W�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "�X�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }
            else if ((StockSignOrderCndtn.LabelTypeState)this.tComboEditor_LabelType.SelectedItem.DataValue 
                == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                // 3�~9 ���[�U�[
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�P�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�Q�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "�R�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "�S�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "�T�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "�U�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "�V�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "�W�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "�X�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }
            else
            {
                // 4�~11 ���[�U�[
                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 0;
                listItem.DataValue = 0;
                listItem.DisplayText = "�P�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 1;
                listItem.DataValue = 1;
                listItem.DisplayText = "�Q�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 2;
                listItem.DataValue = 2;
                listItem.DisplayText = "�R�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 3;
                listItem.DataValue = 3;
                listItem.DisplayText = "�S�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 4;
                listItem.DataValue = 4;
                listItem.DisplayText = "�T�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 5;
                listItem.DataValue = 5;
                listItem.DisplayText = "�U�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 6;
                listItem.DataValue = 6;
                listItem.DisplayText = "�V�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 7;
                listItem.DataValue = 7;
                listItem.DisplayText = "�W�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 8;
                listItem.DataValue = 8;
                listItem.DisplayText = "�X�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 9;
                listItem.DataValue = 9;
                listItem.DisplayText = "�P�O�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);

                listItem = new Infragistics.Win.ValueListItem();
                listItem.Tag = 10;
                listItem.DataValue = 10;
                listItem.DisplayText = "�P�P�s��";
                this.tComboEditor_StartRow.Items.Add(listItem);
            }

        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
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

        #region �� �R���g���[���C�x���g
        /// <summary>
        /// PMZAI02050UA_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02050UA_Load(object sender, EventArgs e)
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
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
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
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ReportSelectGroup") ||
                (e.Group.Key == "PrintOderGroup") ||
                (e.Group.Key == "PrintConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// tComboEditor_LabelType_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���x���^�C�v�̕ύX���A����J�n�s�̐ݒ��ύX����B</br>
        /// <br>Programmer	: 30452 ��� �r��</br>
        /// <br>Date		: 2008.12.12</br>
        /// </remarks>
        private void tComboEditor_LabelType_ValueChanged(object sender, EventArgs e)
        {
            // �I�𒆂̒l��ێ�
            object tmpObj;

            if (this.tComboEditor_StartRow.SelectedItem != null)
            {
                tmpObj = this.tComboEditor_StartRow.SelectedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            this.tComboEditor_StartRow.ResetItems();

            this.SetPrintStartRow();

            this.tComboEditor_StartRow.Value = tmpObj;

            if (this.tComboEditor_StartRow.SelectedItem == null)
            {
                this.tComboEditor_StartRow.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// �q�ɃK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_WarehouseCodeStGuid_Click(object sender, EventArgs e)
        {
            if (this._wareHouseAcs == null)
            {
                this._wareHouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = this._wareHouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tEdit_WarehouseCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = warehouse.WarehouseCode.TrimEnd();
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdStGuid_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_WarehouseShelfNo_St.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // �^�u�AEnter�L�[�ł̃K�C�h�J�ڕs��
            if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
            {
                if (e.NextCtrl == uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_St;
                }
                else if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                if (e.NextCtrl == this.uButton_WarehouseCodeEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                }
                else if (e.NextCtrl == this.uButton_GoodsMakerCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                if (e.NextCtrl == this.uButton_GoodsMakerCdStGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                }
                else if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tEdit_WarehouseShelfNo_St;
                }
            }
            else if (e.PrevCtrl == this.tEdit_WarehouseShelfNo_St)
            {
                if (e.NextCtrl == this.uButton_GoodsMakerCdEdGuid && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
            }
        }

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // �I��O�̕���
                                 + e.KeyChar.ToString() // �I�𕔂����̓L�[�ɒu������镔��
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // �I����̕���

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8�o�C�g(���p8���A�S�p4��)�܂œ��͉�
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<
        #endregion

    }
}