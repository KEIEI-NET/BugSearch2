//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�בΉ��\
// �v���O�����T�v   : �^���ʏo�בΉ��\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhshh
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
    /// �^���ʏo�בΉ��\UI�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ʏo�בΉ��\UI�ŁA���o��������͂��܂��B</br>       
    /// <br>Programmer : zhshh</br>                                   
    /// <br>Date       : 2010.04.21</br>                                   
    /// </remarks>
    public partial class PMSYA02200UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// �^���ʏo�בΉ��\UI�N���X�R���X�g���N�^�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �@
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^���ʏo�בΉ��\UI����������уC���X�^���X�̐������s��</br>                 
        /// <br>Programmer : zhshh</br>                                  
        /// <br>Date       : 2010.04.21</br>                                     
        /// </remarks>
        public PMSYA02200UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._warehouseAcs = new WarehouseAcs();

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
        private ModelShipRsltListCndtn _modelShipRsltListCndtn;

        //���t�擾���i
        private DateGetAcs _dateGet;

        private CarMngInputAcs _carMngInputAcs;

        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        ///���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;

        /// <summary>MAKHN09332A)�q��</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>SFKTN09002A)���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        // �N���XID
        private const string ct_ClassID = "PMSYA02200UA";
        // �v���O����ID
        private const string ct_PGID = "PMSYA02200U";
        // ���[����
        private const string PDF_PRINT_NAME = "�^���ʏo�בΉ��\";
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
        /// <remarks>
        /// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
            printInfo.jyoken = this._modelShipRsltListCndtn;
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <param name="addUpCd">�v�㋒�_</param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E�敪
                this.uos_GroupBySectionDiv.Value = 1;   // ���_��
                this.uos_RsltTtlDiv.Value = 0;          //�݌Ɏ��w��
                this.uos_NewPageDiv.Value = 1;          //����

                // �����l�Z�b�g�E������
                //�Ԏ�
                this.tNedit_St_MakerCode.DataText = string.Empty; 
                this.tNedit_St_ModelCode.DataText = string.Empty;
                this.tNedit_St_ModelSubCode.DataText = string.Empty;
                this.tNedit_Ed_MakerCode.DataText = string.Empty;
                this.tNedit_Ed_ModelCode.DataText = string.Empty;
                this.tNedit_Ed_ModelSubCode.DataText = string.Empty;

                //��\�^��
                this.tEdit_FullModel.DataText = string.Empty;

                //���[�J�[
                this.tNedit_St_GoodsMakerCd.DataText = string.Empty;
                this.tNedit_Ed_GoodsMakerCd.DataText = string.Empty;

                //�a�k�R�[�h
                this.tNedit_St_BLGoodsCode.DataText = string.Empty;
                this.tNedit_Ed_BLGoodsCode.DataText = string.Empty;

                //�q��
                this.tEdit_WarehouseCode.Text = string.Empty;
                this.uLabel_WarehouseName.Text = string.Empty;
                // ���_�����擾
                SecInfoSet sectionInfo;
                status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this._ownSectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!String.IsNullOrEmpty(sectionInfo.SectWarehouseCd1))
                    {
                        this.tEdit_WarehouseCode.Text = sectionInfo.SectWarehouseCd1.Trim().PadLeft(4,'0');
                        // �R�[�h���疼�̂֕ϊ�
                        Warehouse warehouseInfo;
                        int statusWarehouse = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, sectionInfo.SectWarehouseCd1);
                        if (statusWarehouse == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName;
                        }
                    }
                }

                // �����
                this.tde_St_SalesDay.SetDateTime(DateTime.Now);
                this.tde_Ed_SalesDay.SetDateTime(DateTime.Now);

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_ModelFullGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MakerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_WarehouseGuide, Size16_Index.STAR1);


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
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���̐ݒ���s��</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
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
        /// <param name="cdrResult">�`�F�b�N����</param>
        /// <param name="tde_St_OrderDataCreateDate">�J�n���t</param>
        /// <param name="tde_Ed_OrderDataCreateDate">�I�����t</param>
        /// <returns>���t�͈̓`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 0, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true, false, false);
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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

            //�Ԏ�
            if ((this.tNedit_St_MakerCode.GetInt() != 0 || this.tNedit_St_ModelCode.GetInt() != 0 || this.tNedit_St_ModelSubCode.GetInt() != 0)
                && (this.tNedit_Ed_MakerCode.GetInt() != 0 || this.tNedit_Ed_ModelCode.GetInt() != 0 || this.tNedit_Ed_ModelSubCode.GetInt() != 0))
            { 
                if (this.tNedit_St_MakerCode.GetInt() > GetEndCode(this.tNedit_Ed_MakerCode))
                {
                    errMessage = string.Format("�Ԏ�{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_MakerCode;
                    status = false;
                }
                else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) 
                    && this.tNedit_St_ModelCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelCode))
                {
                    errMessage = string.Format("�Ԏ�{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_ModelCode;
                    status = false;
                }
                else if (this.tNedit_St_MakerCode.GetInt() == GetEndCode(this.tNedit_Ed_MakerCode) 
                    && this.tNedit_St_ModelCode.GetInt() == GetEndCode(this.tNedit_Ed_ModelCode)
                    && this.tNedit_St_ModelSubCode.GetInt() > GetEndCode(this.tNedit_Ed_ModelSubCode))
                {
                    errMessage = string.Format("�Ԏ�{0}", ct_RangeError);
                    errComponent = this.tNedit_Ed_ModelSubCode;
                    status = false;
                }
            }
            // ���[�J�[����
            else if (this.tNedit_St_GoodsMakerCd.GetInt() > GetEndCode(this.tNedit_Ed_GoodsMakerCd))
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_Ed_GoodsMakerCd;
                status = false;
            }
            // �a�k����
            else if (this.tNedit_St_BLGoodsCode.GetInt() > GetEndCode(this.tNedit_Ed_BLGoodsCode))
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_Ed_BLGoodsCode;
                status = false;
            }
            return status;
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit">���l����</param>
        /// <returns>�R�[�h�l</returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit">���l����</param>
        /// <param name="endCodeOnDB">��ʏ�R���|�[�l���g��Column</param>
        /// <returns>�R�[�h�l</returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this._modelShipRsltListCndtn = new ModelShipRsltListCndtn();
            try
            {
                // ��ƃR�[�h
                this._modelShipRsltListCndtn.EnterpriseCode = this._enterpriseCode;
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
                this._modelShipRsltListCndtn.IsOptSection = this._isOptSection;
                // �v�㋒�_�R�[�h�i�����w��j
                ArrayList sectionList = new ArrayList(this._selectedSectionList.Values);
                this._modelShipRsltListCndtn.SectionCodeList = (string[])sectionList.ToArray(typeof(string));

                // �W�v���@
                this._modelShipRsltListCndtn.GroupBySectionDiv = (ModelShipRsltListCndtn.GroupBySectionDivState)this.uos_GroupBySectionDiv.Value;
                // �����
                this._modelShipRsltListCndtn.SalesDateSt = this.tde_St_SalesDay.GetDateTime();
                this._modelShipRsltListCndtn.SalesDateEd = this.tde_Ed_SalesDay.GetDateTime();
                // ���͓�
                this._modelShipRsltListCndtn.InputDateSt = this.tde_St_InputDay.GetDateTime();
                this._modelShipRsltListCndtn.InputDateEd = this.tde_Ed_InputDay.GetDateTime();
                // �݌Ɏ��w��
                this._modelShipRsltListCndtn.RsltTtlDiv = (ModelShipRsltListCndtn.RsltTtlDivState)this.uos_RsltTtlDiv.Value;
                // ����
                this._modelShipRsltListCndtn.NewPageDiv = (ModelShipRsltListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;
                //�Ԏ�i�J�n�j
                this._modelShipRsltListCndtn.CarMakerCodeSt = this.tNedit_St_MakerCode.GetInt();
                this._modelShipRsltListCndtn.CarModelCodeSt = this.tNedit_St_ModelCode.GetInt();
                this._modelShipRsltListCndtn.CarModelSubCodeSt = this.tNedit_St_ModelSubCode.GetInt();

                //�Ԏ�i�I���j
                this._modelShipRsltListCndtn.CarMakerCodeEd = this.tNedit_Ed_MakerCode.GetInt();
                this._modelShipRsltListCndtn.CarModelCodeEd = this.tNedit_Ed_ModelCode.GetInt();
                this._modelShipRsltListCndtn.CarModelSubCodeEd = this.tNedit_Ed_ModelSubCode.GetInt();
                //��\�^��
                this._modelShipRsltListCndtn.ModelName = this.tEdit_FullModel.Text;
                // ��\�^�����o�敪
                this._modelShipRsltListCndtn.ModelOutDiv = (ModelShipRsltListCndtn.ModelOutDivState)this.tComboEditor_FullModelFuzzy.Value;
                //���[�J�[
                this._modelShipRsltListCndtn.MakerCodeSt = this.tNedit_St_GoodsMakerCd.GetInt();
                this._modelShipRsltListCndtn.MakerCodeEd = this.tNedit_Ed_GoodsMakerCd.GetInt();
                // �a�k�R�[�h
                this._modelShipRsltListCndtn.BLGoodsCodeSt = this.tNedit_St_BLGoodsCode.GetInt();
                this._modelShipRsltListCndtn.BLGoodsCodeEd = this.tNedit_Ed_BLGoodsCode.GetInt();
                //�q��
                this._modelShipRsltListCndtn.WarehouseCode = this.tEdit_WarehouseCode.Text;
                this._modelShipRsltListCndtn.WarehouseName = this.uLabel_WarehouseName.Text;
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
        /// <br>Programmer	: zhshh</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// PMSYA02200UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void PMSYA02200UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
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
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
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
        /// �a�k�R�[�h�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�K�C�h�{�^�����N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
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
                this.tNedit_St_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tNedit_Ed_BLGoodsCode.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_Ed_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_WarehouseCode.Focus();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �Ԏ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ԏ�K�C�h�{�^�����N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode;
            int modelCode;
            int modelSubCode;
            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
            {
                makerCode = this.tNedit_St_MakerCode.GetInt();
                modelCode = this.tNedit_St_ModelCode.GetInt();
                modelSubCode = this.tNedit_St_ModelSubCode.GetInt();
            }
            else
            {
                makerCode = this.tNedit_Ed_MakerCode.GetInt();
                modelCode = this.tNedit_Ed_ModelCode.GetInt();
                modelSubCode = this.tNedit_Ed_ModelSubCode.GetInt();
            }
            int status = modelNameUAcs.ExecuteGuid2(makerCode, modelCode, modelSubCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_ModelFullGuide)
                {
                    //�J�n
                    this.tNedit_St_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_St_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_St_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }
                else
                {
                    //�I��
                    this.tNedit_Ed_MakerCode.SetInt(modelNameU.MakerCode);
                    this.tNedit_Ed_ModelCode.SetInt(modelNameU.ModelCode);
                    this.tNedit_Ed_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                }

                // ���̍��ڂփt�H�[�J�X�ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>    
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt = null;
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }
            //���[�J�[�K�C�h�N��
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            switch (status)
            {
                //�擾
                case 0:
                    {
                        if (makerUMnt != null)
                        {
                            //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                            if ((Infragistics.Win.Misc.UltraButton)sender == this.ub_St_MakerGuide)
                            {
                                //�J�n
                                this.tNedit_St_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }
                            else
                            {
                                //�I��
                                this.tNedit_Ed_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            }

                            // ���̃R���g���[���փt�H�[�J�X���ړ�
                            this.SelectNextControl((Control)sender, true, true, true, true);
                        }
                        break;
                    }
                //�L�����Z��
                case 1:
                    {

                        break;
                    }
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g (tEdit_WarehouseCode)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void tEdit_WarehouseCode_Leave(object sender, EventArgs e)
        {
            if (!tEdit_WarehouseCode.Modified)
            {
                return;
            }

            if (tEdit_WarehouseCode.Text.Equals(string.Empty))
            {
                this.uLabel_WarehouseName.Text = "";
            }
            else
            {
                tEdit_WarehouseCode.Text = tEdit_WarehouseCode.Text.PadLeft(4,'0');
                Warehouse warehouseInfo;
                int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, this.tEdit_WarehouseCode.Text.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    #region �}�X�^���o�^
                    //-----------------------------------------------------------------------------
                    // �}�X�^���o�^
                    //-----------------------------------------------------------------------------
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�q�ɂ����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    this.tEdit_WarehouseCode.Text = string.Empty;
                    this.uLabel_WarehouseName.Text = string.Empty;
                    this.tEdit_WarehouseCode.Focus();
                    #endregion
                }
            }
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N�����Ɣ������܂��B</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>    
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            Warehouse warehouseData = null;

            int status = this._warehouseAcs.ExecuteGuid(out warehouseData, this._enterpriseCode, this._ownSectionCode);

            if (status == 0)
            {
                if (warehouseData != null)
                {
                    this.tEdit_WarehouseCode.DataText = warehouseData.WarehouseCode.TrimEnd();
                    this.uLabel_WarehouseName.Text = warehouseData.WarehouseName.Trim();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            else
            {
                //�L�����Z���Ȃ̂łȂɂ����Ȃ�
            }
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�J�X�R���g���ɔ������܂��B</br>
        /// <br>Programmer  : zhshh</br>
        /// <br>Date        : 2010.04.21</br>
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
                        case "tNedit_St_MakerCode":
                            {
                                if (0 == this.tNedit_St_MakerCode.GetInt())
                                {
                                    this.tNedit_St_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelCode;
                                break;
                            }
                        case "tNedit_St_ModelCode":
                            {
                                if (0 == this.tNedit_St_ModelCode.GetInt())
                                {
                                    this.tNedit_St_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelSubCode;
                                break;
                            }
                        case "tNedit_St_ModelSubCode":
                            {
                                if (0 == this.tNedit_St_ModelSubCode.GetInt())
                                {
                                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_ModelFullGuide;
                                break;
                            }
                        case "ub_St_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_MakerCode;
                                break;
                            }
                        case "tNedit_Ed_MakerCode":
                            {
                                if (0 == this.tNedit_Ed_MakerCode.GetInt())
                                {
                                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelCode;
                                break;
                            }
                        case "tNedit_Ed_ModelCode":
                            {
                                if (0 == this.tNedit_Ed_ModelCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelSubCode;
                                break;
                            }
                        case "tNedit_Ed_ModelSubCode":
                            {
                                if (0 == this.tNedit_Ed_ModelSubCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_ModelFullGuide;
                                break;
                            }
                        case "ub_Ed_ModelFullGuide":
                            {
                                e.NextCtrl = this.tEdit_FullModel;
                                break;
                            }
                        case "tEdit_FullModel":
                            {
                                e.NextCtrl = this.tComboEditor_FullModelFuzzy;
                                break;
                            }
                        case "tComboEditor_FullModelFuzzy":
                            {
                                e.NextCtrl = this.tNedit_St_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_St_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_St_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_MakerGuide;
                                break;
                            }
                        case "ub_St_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_Ed_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_Ed_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_MakerGuide;
                                break;
                            }
                        case "ub_Ed_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_St_BLGoodsCode;
                                break;
                            }
                        case "tNedit_St_BLGoodsCode":
                            {
                                if (0 == this.tNedit_St_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_St_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_St_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_BLGoodsCode;
                                break;
                            }
                        case "tNedit_Ed_BLGoodsCode":
                            {
                                if (0 == this.tNedit_Ed_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_Ed_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tEdit_WarehouseCode;
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
                        case "tNedit_St_MakerCode":
                            {
                                if (0 == this.tNedit_St_MakerCode.GetInt())
                                {
                                    this.tNedit_St_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.uos_NewPageDiv;
                                break;
                            }
                        case "tNedit_St_ModelCode":
                            {
                                if (0 == this.tNedit_St_ModelCode.GetInt())
                                {
                                    this.tNedit_St_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_MakerCode;
                                break;
                            }
                        case "tNedit_St_ModelSubCode":
                            {
                                if (0 == this.tNedit_St_ModelSubCode.GetInt())
                                {
                                    this.tNedit_St_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_St_ModelCode;
                                break;
                            }
                        case "ub_St_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_St_ModelSubCode;
                                break;
                            }
                        case "tNedit_Ed_MakerCode":
                            {
                                if (0 == this.tNedit_Ed_MakerCode.GetInt())
                                {
                                    this.tNedit_Ed_MakerCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_ModelFullGuide;
                                break;
                            }
                        case "tNedit_Ed_ModelCode":
                            {
                                if (0 == this.tNedit_Ed_ModelCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_MakerCode;
                                break;
                            }
                        case "tNedit_Ed_ModelSubCode":
                            {
                                if (0 == this.tNedit_Ed_ModelSubCode.GetInt())
                                {
                                    this.tNedit_Ed_ModelSubCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.tNedit_Ed_ModelCode;
                                break;
                            }
                        case "ub_Ed_ModelFullGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_ModelSubCode;
                                break;
                            }
                        case "tEdit_FullModel":
                            {
                                e.NextCtrl = this.ub_Ed_ModelFullGuide;
                                break;
                            }
                        case "tComboEditor_FullModelFuzzy":
                            {
                                e.NextCtrl = this.tEdit_FullModel;
                                break;
                            }
                        case "tNedit_St_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_St_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_St_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.tComboEditor_FullModelFuzzy;
                                break;
                            }
                        case "ub_St_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_St_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_Ed_GoodsMakerCd":
                            {
                                if (0 == this.tNedit_Ed_GoodsMakerCd.GetInt())
                                {
                                    this.tNedit_Ed_GoodsMakerCd.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_MakerGuide;
                                break;
                            }
                        case "ub_Ed_MakerGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_GoodsMakerCd;
                                break;
                            }
                        case "tNedit_St_BLGoodsCode":
                            {
                                if (0 == this.tNedit_St_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_St_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_MakerGuide;
                                break;
                            }
                        case "ub_St_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_St_BLGoodsCode;
                                break;
                            }
                        case "tNedit_Ed_BLGoodsCode":
                            {
                                if (0 == this.tNedit_Ed_BLGoodsCode.GetInt())
                                {
                                    this.tNedit_Ed_BLGoodsCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_St_BLGoodsCodeGuide;
                                break;
                            }
                        case "ub_Ed_BLGoodsCodeGuide":
                            {
                                e.NextCtrl = this.tNedit_Ed_BLGoodsCode;
                                break;
                            }
                        case "tEdit_WarehouseCode":
                            {
                                str = this.tEdit_WarehouseCode.Text;
                                if (str.Length != Encoding.Default.GetByteCount(str))
                                {
                                    this.tEdit_WarehouseCode.Text = string.Empty;
                                }
                                e.NextCtrl = this.ub_Ed_BLGoodsCodeGuide;
                                break;
                            }
                    }
                }
            }
        }


        # endregion     
    }
}
