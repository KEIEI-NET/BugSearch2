//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈��UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �C �� ��  2009/07/27  �C�����e : �m��APDF�\���{�^�����s���̊e�����ƃ��b�Z�[�W�̕ύX
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����_�ݒ菈��UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ菈��UI�t�H�[���N���X</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.13</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMHAT09101UA : Form,
                                IPrintConditionInpTypeUpdate,           // ���[���ʁi�X�V�j
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor
        /// <summary>
        /// �����_�ݒ菈��UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ菈��UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br></br>
        /// </remarks>
        public PMHAT09101UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �����_�ݒ菈���A�N�Z�X�N���X
            this._orderPointStSimulationAcs = new OrderPointStSimulationAcs();
            // �����_�ݒ�}�X�^�����e�i���X�A�N�Z�X
            this._orderPointStAcs = new OrderPointStAcs();
            // �q�Ƀ}�X�^�A�N�Z�X�N���X
            this._wareHouseAcs = new WarehouseAcs();
            // �d����}�X�^�A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
            // ���[�J�[�}�X�^�A�N�Z�X�N���X
            this._makerAcs = new MakerAcs();
            // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();
            // ���i�����ރA�N�Z�X�N���X
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            // BL�O���[�v�A�N�Z�X�N���X
            this._blGroupUAcs = new BLGroupUAcs();
            // BL�R�[�h�A�N�Z�X�N���X
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // �����_�ݒ�}�X�^���[�N�N���X
            this._orderPointStList = new List<OrderPointSt>();
        }
        #endregion

        #region �� Private Member
        #region �� Interface member
        // ���s�{�^����Ԏ擾�v���p�e�B
        private bool _canUpdate = false;
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = false;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = false;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = false;
        // �O��ݒ�R�[�h
        private string _patterNo;
        #endregion �� Interface member

        // ���_�R�[�h
        private string _enterpriseCode = "";
        // �����_�ݒ菈���A�N�Z�X�N���X
        private OrderPointStSimulationAcs _orderPointStSimulationAcs;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �����_�ݒ�}�X�^�����e�i���X�A�N�Z�X
        private OrderPointStAcs _orderPointStAcs;
        // �K�C�h�A�N�Z�X�N���X
        // �q�Ƀ}�X�^�A�N�Z�X�N���X
        private WarehouseAcs _wareHouseAcs;
        // �d����}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        // ���[�J�[�}�X�^�A�N�Z�X�N���X
        private MakerAcs _makerAcs;
        // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;
        // ���i�����ރA�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs;
        // BL�O���[�v�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs;
        // �����_�ݒ�}�X�^���[�N�N���X
        private List<OrderPointSt> _orderPointStList;
        // �ݒ�R�[�h�̃t�H�[�J�X�ړ����ǂ���
        private bool isPatterNoReaded = false;
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMHAT09101UA";
        // �v���O����ID
        private const string ct_PGID = "PMHAT09101U";
        // ���[����
        private const string ct_PrintName = "�����_�ݒ菈��";
        // ���[�L�[	
        private const string ct_PrintKey = "0db9c72a-5463-49e0-b738-08780ca74f53";
        // �X�V�{�^���t���O
        private bool _updateFlg = false;

        // �����K�p�敪
        // ADD 2009/07/14
        private  Int32 _orderApplyDiv = 0;
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���s�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }

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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            // ����{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A���̓G���[
            //upd by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX start
            //if (this._updateFlg == false && (int)this.tComboEditor_Simulation.Value == 1)
            if ((int)this.tComboEditor_Simulation.Value == 1)
            //upd by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX end
            {
                this.tComboEditor_Simulation.Select();
                //upd by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX start
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�I���o���Ȃ��敪�ł��B", 0);
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�c�e�\���͑I���o���܂���B", 0);
                //upd by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX end
                return -1;
            }
            SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	    // ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;

            // ���o�����N���X
            ExtrInfo_OrderPointStSimulationWorkTbl extrInfo = new ExtrInfo_OrderPointStSimulationWorkTbl();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = extrInfo;

            // ���[�I���K�C�h
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // �v���r���[�̏ꍇ
            if (printDialog.EnablePreview == 1)
            {
                // �v���r���[��ʂ����ꍇ
                if (printInfo.status == -1)
                {
                    printInfo.status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
            }

            // �߂�X�e�[�^�X
            switch (printInfo.status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    break;
                default:
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���[���C�A�E�g�̎擾�Ɏ��s���܂����B", 0);
                    break;
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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;
            bool isSetCodeErr = false;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent, out isSetCodeErr))
            {
                // ���b�Z�[�W��\��
                if (isSetCodeErr)
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMessage, 0);
                }
                else
                {
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                }

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

        #region �� ���s����
        /// <summary>
        /// ���s����
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �X�V�{����������s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;
            this._updateFlg = true;

            //add by liuxz on 2009/07/27 for �m��{�^���̃G���[�`�F�b�N�ǉ� start
            // ������Ȃ��ƍX�V���Ȃ��ꍇ�A�G���[�Ƃ���
            if (this.UpdateBeforeCheck() == false)
            {
                return status;
            }
            //add by liuxz on 2009/07/27 for �m��{�^���̃G���[�`�F�b�N�ǉ� end

            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            try
            {
                // �������ꍇ
                if ((int)this.tComboEditor_Simulation.Value == 0)
                {
                    // �������
                    status = Print(ref parameter);

                    // �����������
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // �X�V����ꍇ
                        if ((int)this.tComboEditor_Update.Value == 1)
                        {
                            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID,
                                "������������܂����B\n�݌Ƀ}�X�^���X�V���Ă���낵���ł����H", 0, MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                // �\��������ݒ�
                                form.Title = "�X�V��";
                                form.Message = "���݁A�f�[�^���X�V���ł��B";
                                // �_�C�A���O�\��
                                form.Show();
                                SFCMN06002C printInfo = parameter as SFCMN06002C;
                                DataSet dataSet = printInfo.rdData as DataSet;
                                // �݌Ƀ}�X�^�X�V����
                                status = StockUpdate(dataSet, out errMsg);
                                // �_�C�A���O�����
                                form.Close();
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                                        break;
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        // �o�^����
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��폜����Ă��܂��B", 0);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��X�V����Ă��܂��B", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // �X�V����ꍇ
                    if ((int)this.tComboEditor_Update.Value == 1)
                    {
                        DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID,
                            "�݌Ƀ}�X�^���X�V���Ă���낵���ł����H", 0, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            // �\��������ݒ�
                            form.Title = "���o��";
                            form.Message = "���݁A�f�[�^�𒊏o���ł��B";
                            // �_�C�A���O�\��
                            form.Show();
                            // ���o�����N���X
                            ExtrInfo_OrderPointStSimulationWorkTbl paramWork = new ExtrInfo_OrderPointStSimulationWorkTbl();

                            // ��ʁ����o�����N���X
                            status = this.SetExtraInfoFromScreen(paramWork);

                            // �����_�ݒ菈���f�[�^�擾
                            status = this._orderPointStSimulationAcs.Search(paramWork, out errMsg);
                            // �_�C�A���O�����
                            form.Close();
                            // �߂�X�e�[�^�X
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // �\��������ݒ�
                                form.Title = "�X�V��";
                                form.Message = "���݁A�f�[�^���X�V���ł��B";
                                // �_�C�A���O�\��
                                form.Show();
                                DataSet dataSet = this._orderPointStSimulationAcs.DataSet;
                                // �݌Ƀ}�X�^�X�V����
                                status = StockUpdate(dataSet, out errMsg);
                                // �_�C�A���O�����
                                form.Close();
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                                        break;
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        // �o�^����
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��폜����Ă��܂��B", 0);
                                        break;
                                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���ɑ��[���ɂ��X�V����Ă��܂��B", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                                        break;
                                }
                            }
                            else
                            {
                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                                        break;
                                    default:
                                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���[���C�A�E�g�̎擾�Ɏ��s���܂����B", 0);
                                        break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // �_�C�A���O�����
                form.Close();
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            this._updateFlg = false;
            return status;
        }
        #endregion

        #region �� �m��O�̃`�F�b�N����
        //add by liuxz on 2009/07/27 for �m��{�^���̃G���[�`�F�b�N�ǉ� start
        /// <summary>
        /// �m��O�̃`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���s�O�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.07.27</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool ret = true;

            // ������Ȃ��ƍX�V���Ȃ��ꍇ 
            if ((int)this.tComboEditor_Simulation.Value == 1 && (int)this.tComboEditor_Update.Value == 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�m��͑I���o���܂���B", 0);
                this.tComboEditor_Simulation.Focus();
                ret = false;
            }

            return ret;
        }
        //add by liuxz on 2009/07/27 for �m��{�^���̃G���[�`�F�b�N�ǉ� end
        #endregion �� ���s�O�̃`�F�b�N����

        #region �� �݌Ƀ}�X�^�X�V����
        /// <summary>
        /// �݌Ƀ}�X�^�X�V����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �݌Ƀ}�X�^�X�V�������s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        private int StockUpdate(DataSet ds, out string errMsg)
        {
            int status = this._orderPointStSimulationAcs.StockUpdate(ds, this._orderPointStList, out errMsg);

            return status;
        }
        #endregion �� �݌Ƀ}�X�^�X�V����

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
            this.Show();
            return;
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
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
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // PDF�Ɗm��̐���
                this._canPdf = false;
                this._canUpdate = false;
                ParentToolbarSettingEvent(this);

                // ��ʍ��ڂ̐���
                this.SetControlEnable();

                // �ݒ�R�[�h
                this.tNEdit_PatterNo.Clear();
                // �q��
                this.tEdit_WarehouseCode_St.Clear();
                this.tEdit_WarehouseCode_Ed.Clear();                
                // �d����
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();                
                // ���[�J�[
                this.tNedit_GoodsMakerCd_St.Clear();
                this.tNedit_GoodsMakerCd_Ed.Clear();                
                // ���i������
                this.tNedit_GoodsMGroup_St.Clear();
                this.tNedit_GoodsMGroup_Ed.Clear();                
                // �O���[�v�R�[�h
                this.tNedit_BLGloupCode_St.Clear();
                this.tNedit_BLGloupCode_Ed.Clear();                
                // BL�R�[�h
                this.tNedit_BLGoodsCode_St.Clear();
                this.tNedit_BLGoodsCode_Ed.Clear();
                // �W�v���@
                this.tComboEditor_SumMethod.SelectedIndex = 0;
                // �V���~���[�V����
                this.tComboEditor_Simulation.SelectedIndex = 0;                
                // �o�͏�
                this.tComboEditor_OutputDiv.SelectedIndex = 0;
                // �݌Ƀ}�X�^�X�V
                this.tComboEditor_Update.SelectedIndex = 0;
                // �Ǘ��敪�P
                foreach (int index in this.clb_ManagerDiv1.CheckedIndices)
                {
                    this.clb_ManagerDiv1.SetItemChecked(index, false);
                }
                this.clb_ManagerDiv1.SelectedItems.Clear();
                // �Ǘ��敪�Q
                foreach (int index in this.clb_ManagerDiv2.CheckedIndices)
                {
                    this.clb_ManagerDiv2.SetItemChecked(index, false);
                }
                this.clb_ManagerDiv2.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� ��ʍ��ڂ̐��䏈��
        /// <summary>
        /// ��ʍ��ڂ̐��䏈��
        /// </summary>
        private void SetControlEnable()
        {
            // �q�ɃR�[�h
            this.tEdit_WarehouseCode_St.ReadOnly = true;
            this.tEdit_WarehouseCode_Ed.ReadOnly = true;
            this.ub_St_WarehouseCodeGuide.Enabled = false;
            this.ub_Ed_WarehouseCodeGuide.Enabled = false;
            // �d����R�[�h 
            this.tNedit_SupplierCd_St.ReadOnly = true;
            this.tNedit_SupplierCd_Ed.ReadOnly = true;
            this.ub_St_SupplierCodeGuide.Enabled = false;
            this.ub_Ed_SupplierCodeGuide.Enabled = false;
            // ���[�J�[
            this.tNedit_GoodsMakerCd_St.ReadOnly = true;
            this.tNedit_GoodsMakerCd_Ed.ReadOnly = true;
            this.ub_St_GoodsMakerCdGuide.Enabled = false;
            this.ub_Ed_GoodsMakerCdGuide.Enabled = false;
            // ������
            this.tNedit_GoodsMGroup_St.ReadOnly = true;
            this.tNedit_GoodsMGroup_Ed.ReadOnly = true;
            this.ub_St_GoodsMGroupGuide.Enabled = false;
            this.ub_Ed_GoodsMGroupGuide.Enabled = false;
            // �O���[�v
            this.tNedit_BLGloupCode_St.ReadOnly = true;
            this.tNedit_BLGloupCode_Ed.ReadOnly = true;
            this.ub_St_BLGloupCodeGuide.Enabled = false;
            this.ub_Ed_BLGloupCodeGuide.Enabled = false;
            // BL�R�[�h
            this.tNedit_BLGoodsCode_St.ReadOnly = true;
            this.tNedit_BLGoodsCode_Ed.ReadOnly = true;
            this.ub_St_BLGoodsCodeGuide.Enabled = false;
            this.ub_Ed_BLGoodsCodeGuide.Enabled = false;
        }
        #endregion �� ��ʍ��ڂ̐��䏈��

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
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <param name="isSetCodeErr">�ݒ�R�[�h���݂��ǂ���</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent, out bool isSetCodeErr)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
            
            errMessage = "";
            errComponent = null;
            isSetCodeErr = false;

            // �ݒ�R�[�h
            if (String.IsNullOrEmpty(this.tNEdit_PatterNo.DataText.TrimEnd()))
            {
                errMessage = "�ݒ�R�[�h����͂��Ă��������B";
                errComponent = this.tNEdit_PatterNo;
                status = false;
            }
            else
            {
                if (this._orderPointStList.Count > 0)
                {
                    OrderPointSt orderPointSt = (OrderPointSt)this._orderPointStList[0];
                    if (orderPointSt.PatterNo != this.tNEdit_PatterNo.GetInt() || isPatterNoReaded == false)
                    {
                        // �����_�̑��݃`�F�b�N����
                        if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            errMessage = "�Y������f�[�^�����݂��܂���B";
                            errComponent = this.tNEdit_PatterNo;
                            isSetCodeErr = true;
                            status = false;
                        }
                        // ��ʃf�[�^�̐ݒ菈��
                        this.SetScreenDataInfo(this._orderPointStList);
                    }
                }
                else
                {
                    // �����_�̑��݃`�F�b�N����
                    if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        errMessage = "�Y������f�[�^�����݂��܂���B";
                        errComponent = this.tNEdit_PatterNo;
                        isSetCodeErr = true;
                        status = false;
                    }
                    if (isPatterNoReaded == false)
                    {
                        // ��ʃf�[�^�̐ݒ菈��
                        this.SetScreenDataInfo(this._orderPointStList);
                    }
                }
            }
            // �q�Ƀ`�F�b�N
            if ((this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                errMessage = string.Format("�q��{0}", ct_RangeError);
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // �d����`�F�b�N
            else if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("�d����{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // ���[�J�[�`�F�b�N
            else if ((this.tNedit_GoodsMakerCd_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()))
            {
                errMessage = string.Format("���[�J�[�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // ���i�����ރ`�F�b�N
            else if ((this.tNedit_GoodsMGroup_St.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_Ed.DataText.Trim() != "") &&
                    (this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()))
            {
                errMessage = string.Format("������{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // �O���[�v�R�[�h�`�F�b�N
            else if ((this.tNedit_BLGloupCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()))
            {
                errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // BL�R�[�h�`�F�b�N
            else if ((this.tNedit_BLGoodsCode_St.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_Ed.DataText.Trim() != "") &&
                    (this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()))
            {
                errMessage = string.Format("BL�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }

            //del by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX start
            ///*------DEL 2009/07/14 PVCS341----->>>>>
            //// ������Ȃ��ƍX�V���Ȃ��ꍇ 
            //// if ((int)this.tComboEditor_Simulation.Value == 1 && (int)this.tComboEditor_Update.Value == 0)
            // ------DEL 2009/07/14 PVCS341-----<<<<<*/
            //// ������Ȃ��ꍇ
            //if ((int)this.tComboEditor_Simulation.Value == 1) // ADD 2009/07/14 PVCS341
            //{
            //    // errMessage = "�I���o���Ȃ��敪�ł��B"; // DEL 2009/07/14 PVCS341
            //    errMessage = "�o�c�e�\���͑I���o���܂���B";
            //    errComponent = this.tComboEditor_Simulation;
            //    status = false;
            //}
            //del by liuxz on 2009/07/27 for PDF�{�^���������āA�V�~�����[�V�������u������Ȃ��v�ꍇ�A�G���[���b�Z�[�W�ύX end
            return status;
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="paramWork">���o�����N���X</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(ExtrInfo_OrderPointStSimulationWorkTbl paramWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ADD 2009/07/14
                // �����K�p�敪
                paramWork.OrderApplyDiv = this._orderApplyDiv;
                // ��ƃR�[�h
                paramWork.EnterpriseCode = this._enterpriseCode;
                // �ݒ�R�[�h
                paramWork.SettingCode = this.tNEdit_PatterNo.GetInt();
                // �q��
                // �J�n
                if (this.tEdit_WarehouseCode_St.Text.TrimEnd() == "")
                {
                    paramWork.St_WarehouseCode = "";
                }
                else
                {
                    paramWork.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text.TrimEnd().PadLeft(4, '0');
                }
                // �I��
                if (this.tEdit_WarehouseCode_Ed.Text.TrimEnd() == "")
                {
                    paramWork.Ed_WarehouseCode = "";
                }
                else
                {
                    paramWork.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text.TrimEnd().PadLeft(4, '0');
                }
                // �d����
                paramWork.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                paramWork.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                // ���[�J�[�R�[�h
                paramWork.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                paramWork.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // ���i������
                paramWork.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                paramWork.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // �O���[�v�R�[�h
                paramWork.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                paramWork.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // BL�R�[�h
                paramWork.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                paramWork.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();
                // �W�v���@
                paramWork.SumMethodCd = Convert.ToInt32(this.tComboEditor_SumMethod.Value);
                paramWork.SumMethodNm = this.tComboEditor_SumMethod.Text;
                // �o�͏�
                paramWork.OutPutDiv = Convert.ToInt32(this.tComboEditor_OutputDiv.Value);
                // �݌ɏo�בΏۊJ�n��
                paramWork.StckShipMonthSt = (this._orderPointStList[0] as OrderPointSt).StckShipMonthSt;
                // �݌ɏo�בΏۏI����
                paramWork.StckShipMonthEd = (this._orderPointStList[0] as OrderPointSt).StckShipMonthEd;
                // �݌ɓo�^��
                paramWork.StockCreateDate = (this._orderPointStList[0] as OrderPointSt).StockCreateDate;
                // �Ǘ��敪�P
                string[] managerDiv1 = new string[this.clb_ManagerDiv1.CheckedItems.Count];
                for (int i = 0; i < this.clb_ManagerDiv1.CheckedItems.Count; i++)
                {
                    object checkedItem = this.clb_ManagerDiv1.CheckedItems[i];
                    int itemIndex = this.clb_ManagerDiv1.Items.IndexOf(checkedItem);
                    managerDiv1[i] = itemIndex.ToString();
                }
                paramWork.ManagementDivide1 = managerDiv1;
                // �Ǘ��敪�Q
                string[] managerDiv2 = new string[this.clb_ManagerDiv2.CheckedItems.Count];
                for (int i = 0; i < this.clb_ManagerDiv2.CheckedItems.Count; i++)
                {
                    object checkedItem = this.clb_ManagerDiv2.CheckedItems[i];
                    int itemIndex = this.clb_ManagerDiv2.Items.IndexOf(checkedItem);
                    managerDiv2[i] = itemIndex.ToString();
                }
                paramWork.ManagementDivide2 = managerDiv2;

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region �� �����_�̑��݃`�F�b�N����
        /// <summary>
        /// �����_�̑��݃`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����_�̑��݃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetCodeCheck()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            List<OrderPointSt> retList = null;
            try
            {
                if (!String.IsNullOrEmpty(this.tNEdit_PatterNo.DataText.TrimEnd()))
                {
                    if (!IsNumber(this.tNEdit_PatterNo.DataText.TrimEnd()))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    else
                    {
                        int patterNo = this.tNEdit_PatterNo.GetInt();
                        this._orderPointStAcs.Search(out retList, patterNo, this._enterpriseCode);
                        if (retList.Count > 0)
                        {
                            List<OrderPointSt> list = new List<OrderPointSt>();
                            foreach (OrderPointSt orderPointSt in retList)
                            {
                                // �_���폜�̃f�[�^���`�F�b�N����
                                if (orderPointSt.LogicalDeleteCode == 1)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                    return status;
                                }
                                else
                                {
                                    // �����_�����X�V�t���O
                                    orderPointSt.OrderPProcUpdFlg = 1;
                                    // ADD 2009/07/14
                                    this._orderApplyDiv = orderPointSt.OrderApplyDiv;
                                    list.Add(orderPointSt);
                                }
                            }
                            this._orderPointStList = list;

                            // �O��ݒ�R�[�h
                            this._patterNo = this.tNEdit_PatterNo.Text;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                    }
                }
                else
                {
                    // �O��ݒ�R�[�h
                    this._patterNo = string.Empty;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� �����_�̑��݃`�F�b�N����

        #region �� ��ʃf�[�^�̐ݒ菈��
        /// <summary>
        /// ��ʃf�[�^�̐ݒ菈��
        /// </summary>
        /// <param name="orderPointStWorkList">�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note        : ��ʃf�[�^�̐ݒ菈�����s���܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private int SetScreenDataInfo(List<OrderPointSt> orderPointStWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                OrderPointSt orderPointSt = orderPointStWorkList[0] as OrderPointSt;

                // ��ʐ���
                this.SetControlEnable();

                // �q��
                if (string.IsNullOrEmpty(orderPointSt.WarehouseCode.TrimEnd()) || Convert.ToInt32(orderPointSt.WarehouseCode.TrimEnd()) == 0)
                {
                    this.tEdit_WarehouseCode_St.Text = string.Empty;
                    this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                    this.tEdit_WarehouseCode_St.ReadOnly = false;
                    this.tEdit_WarehouseCode_Ed.ReadOnly = false;
                    this.ub_St_WarehouseCodeGuide.Enabled = true;
                    this.ub_Ed_WarehouseCodeGuide.Enabled = true;
                }
                else
                {
                    this.tEdit_WarehouseCode_St.Text = orderPointSt.WarehouseCode;
                    this.tEdit_WarehouseCode_Ed.Text = orderPointSt.WarehouseCode;
                }
                // �d����
                this.tNedit_SupplierCd_St.SetInt(orderPointSt.SupplierCd);
                this.tNedit_SupplierCd_Ed.SetInt(orderPointSt.SupplierCd);
                if (orderPointSt.SupplierCd == 0)
                {
                    this.tNedit_SupplierCd_St.ReadOnly = false;
                    this.tNedit_SupplierCd_Ed.ReadOnly = false;
                    this.ub_St_SupplierCodeGuide.Enabled = true;
                    this.ub_Ed_SupplierCodeGuide.Enabled = true;
                }
                // ���[�J�[
                this.tNedit_GoodsMakerCd_St.SetInt(orderPointSt.GoodsMakerCd);
                this.tNedit_GoodsMakerCd_Ed.SetInt(orderPointSt.GoodsMakerCd);
                if (orderPointSt.GoodsMakerCd == 0)
                {
                    this.tNedit_GoodsMakerCd_St.ReadOnly = false;
                    this.tNedit_GoodsMakerCd_Ed.ReadOnly = false;
                    this.ub_St_GoodsMakerCdGuide.Enabled = true;
                    this.ub_Ed_GoodsMakerCdGuide.Enabled = true;
                }
                // ���i������
                this.tNedit_GoodsMGroup_St.SetInt(orderPointSt.GoodsMGroup);
                this.tNedit_GoodsMGroup_Ed.SetInt(orderPointSt.GoodsMGroup);
                if (orderPointSt.GoodsMGroup == 0)
                {
                    this.tNedit_GoodsMGroup_St.ReadOnly = false;
                    this.tNedit_GoodsMGroup_Ed.ReadOnly = false;
                    this.ub_St_GoodsMGroupGuide.Enabled = true;
                    this.ub_Ed_GoodsMGroupGuide.Enabled = true;
                }
                // �O���[�v�R�[�h
                this.tNedit_BLGloupCode_St.SetInt(orderPointSt.BLGroupCode);
                this.tNedit_BLGloupCode_Ed.SetInt(orderPointSt.BLGroupCode);
                if (orderPointSt.BLGroupCode == 0)
                {
                    this.tNedit_BLGloupCode_St.ReadOnly = false;
                    this.tNedit_BLGloupCode_Ed.ReadOnly = false;
                    this.ub_St_BLGloupCodeGuide.Enabled = true;
                    this.ub_Ed_BLGloupCodeGuide.Enabled = true;
                }
                // BL�R�[�h
                this.tNedit_BLGoodsCode_St.SetInt(orderPointSt.BLGoodsCode);
                this.tNedit_BLGoodsCode_Ed.SetInt(orderPointSt.BLGoodsCode);
                if (orderPointSt.BLGoodsCode == 0)
                {
                    this.tNedit_BLGoodsCode_St.ReadOnly = false;
                    this.tNedit_BLGoodsCode_Ed.ReadOnly = false;
                    this.ub_St_BLGoodsCodeGuide.Enabled = true;
                    this.ub_Ed_BLGoodsCodeGuide.Enabled = true;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� ��ʃf�[�^�̐ݒ菈��

        #region �� �����̃`�F�b�N����
        /// <summary>
        /// �����̃`�F�b�N����
        /// </summary>
        /// <param name="s">������</param>
        /// <remarks>
        /// <br>Note		: �����̃`�F�b�N�������s��</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.06.02</br>
        /// </remarks>
        private static bool IsNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion �� �����̃`�F�b�N����

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
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
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
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
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
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� �G���[���b�Z�[�W�\��
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMZAI02020UA
        #region �� PMZAI02020UA_Load Event
        /// <summary>
        /// PMHAT09101UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        /// 
        private void PMHAT09101UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // �R���{�{�b�N�X�̏�����
            this.InitComboBox();

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

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion

        /// <summary>
        /// �R���{�{�b�N�X�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �R���{�{�b�N�X�̏��������s��</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        /// 
        private void InitComboBox()
        {
            Infragistics.Win.ValueListItem listItem = new Infragistics.Win.ValueListItem();
            // �W�v���@
            // ��񂹕����܂�
            listItem.DataValue = 0;
            listItem.DisplayText = "��񂹕����܂�";
            this.tComboEditor_SumMethod.Items.Add(listItem);
            // �݌ɕ��̂�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "�݌ɕ��̂�";
            this.tComboEditor_SumMethod.Items.Add(listItem);

            // �V���~���[�V����
            // �������
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "�������";
            this.tComboEditor_Simulation.Items.Add(listItem);
            // ������Ȃ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "������Ȃ�";
            this.tComboEditor_Simulation.Items.Add(listItem);

            // �o�͏�
            // �i�ԏ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "�i�ԏ�";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // �I�ԏ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "�I�ԏ�";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // ���[�J�[�E�i�ԏ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 2;
            listItem.DisplayText = "���[�J�[�E�i�ԏ�";
            this.tComboEditor_OutputDiv.Items.Add(listItem);
            // ���[�J�[�E�I�ԏ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 3;
            listItem.DisplayText = "���[�J�[�E�I�ԏ�";
            this.tComboEditor_OutputDiv.Items.Add(listItem);

            // �݌Ƀ}�X�^�X�V
            // �X�V���Ȃ�
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 0;
            listItem.DisplayText = "�X�V���Ȃ�";
            this.tComboEditor_Update.Items.Add(listItem);
            // �X�V����
            listItem = new Infragistics.Win.ValueListItem();
            listItem.DataValue = 1;
            listItem.DisplayText = "�X�V����";
            this.tComboEditor_Update.Items.Add(listItem);
        }

        #region �� �ݒ�R�[�h�̃��[�X�g�t�H�[�J�X�C�x���g
        /// <summary>
        /// �ݒ�R�[�h�̃��[�X�g�t�H�[�J�X�C�x���g
        /// </summary>
        private bool ub_PatterNo_Leave()
        {
            Int32 prePatterNo = -1;
            if (!string.IsNullOrEmpty(this._patterNo) && IsNumber(this._patterNo))
            {
                prePatterNo = Convert.ToInt32(this._patterNo);
            }
            if (this.tNEdit_PatterNo.DataText.TrimEnd() == "0" ||
                this.tNEdit_PatterNo.DataText.TrimEnd() == "00" ||
                this.tNEdit_PatterNo.DataText.TrimEnd() == "000")
            {
                string errMsg = string.Empty;
                // ��ʂ̏���������
                this.InitializeScreen(out errMsg);
                return false;
            }

            if (prePatterNo == -1 || this.tNEdit_PatterNo.GetInt() != prePatterNo)
            {
                // �����_�ݒ�R�[�h�̑��݃`�F�b�N����
                if (this.SetCodeCheck() != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // �O��ݒ�R�[�h
                    this.tNEdit_PatterNo.Text = this._patterNo;
                    this.tNEdit_PatterNo.Select();
                    // ���b�Z�[�W��\��
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^�����݂��܂���B", 0);
                    return false;
                }
                if (string.IsNullOrEmpty(this.tNEdit_PatterNo.Text))
                {
                    string errMsg = string.Empty;
                    // ��ʂ̏���������
                    this.InitializeScreen(out errMsg);
                }
                else
                {
                    // ��ʃf�[�^�̐ݒ菈��
                    this.SetScreenDataInfo(this._orderPointStList);

                    // PDF�Ɗm��̐���
                    this._canPdf = true;
                    this._canUpdate = true;
                    ParentToolbarSettingEvent(this);
                }
            }

            return true;
        }
        #endregion

        #endregion �� PMZAI02020UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.04.13</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }
        #endregion
        #endregion �� ueb_MainExplorerBar Event

        #region �� �J�n�q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // �K�C�h�N��
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_St.DataText = wareHouse.WarehouseCode.TrimEnd();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_WarehouseCodeGuide_Click(object sender, EventArgs e)
        {
            int status = 0;
            string sectionCode = "";

            // �K�C�h�N��
            Warehouse wareHouse = new Warehouse();
            status = this._wareHouseAcs.ExecuteGuid(out wareHouse, this._enterpriseCode, sectionCode);

            if (status == 0)
            {
                this.tEdit_WarehouseCode_Ed.DataText = wareHouse.WarehouseCode.TrimEnd();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I�����[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I�����[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            int status = -1;
            
            // �K�C�h�N��
            MakerUMnt makerUMnt;
            status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n���i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n���i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            GoodsGroupU goodgroupU;            
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I�����i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I�����i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_GoodsMGroupGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            GoodsGroupU goodgroupU;
            status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);

            if (status == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�n�O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�n�O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I���O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I���O���[�v�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_BLGloupCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGroupU blGroupU;
            status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);

            if (status == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �J�nBL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �J�nBL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� �I��BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// <summary>
        /// �I��BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;
            status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            bool isMouseClick = true;
            Int32 patterNo = 0;

            // �ݒ�R�[�h�̃t�H�[�J�X�ړ�����
            if (e.PrevCtrl == this.tNEdit_PatterNo)
            {
                if (!string.IsNullOrEmpty(this._patterNo) && IsNumber(this._patterNo))
                {
                    patterNo = Convert.ToInt32(this._patterNo);
                }
                // �ݒ�R�[�h�̃��[�X�g�t�H�[�J�X�C�x���g
                if (!this.ub_PatterNo_Leave())
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                    return;
                }
                isPatterNoReaded = true;

                if (this.tNEdit_PatterNo.GetInt() != patterNo)
                {
                    // �ق��̍��ڂ�����������
                    // �W�v���@
                    this.tComboEditor_SumMethod.SelectedIndex = 0;
                    // �V���~���[�V����
                    this.tComboEditor_Simulation.SelectedIndex = 0;
                    // �o�͏�
                    this.tComboEditor_OutputDiv.SelectedIndex = 0;
                    // �݌Ƀ}�X�^�X�V
                    this.tComboEditor_Update.SelectedIndex = 0;
                    // �Ǘ��敪�P
                    foreach (int index in this.clb_ManagerDiv1.CheckedIndices)
                    {
                        this.clb_ManagerDiv1.SetItemChecked(index, false);
                    }
                    // �Ǘ��敪�Q
                    foreach (int index in this.clb_ManagerDiv2.CheckedIndices)
                    {
                        this.clb_ManagerDiv2.SetItemChecked(index, false);
                    }
                }
            }

            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    isMouseClick = false;
                    if (e.PrevCtrl == this.tNEdit_PatterNo)
                    {
                        if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �ݒ�R�[�h��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else
                        {
                            // L�R�[�h(�I��)���W�v���@
                            e.NextCtrl = this.tComboEditor_SumMethod;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // L�R�[�h(�I��)���W�v���@
                        e.NextCtrl = this.tComboEditor_SumMethod;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SumMethod)
                    {
                        // �W�v���@���V���~���[�V����
                        e.NextCtrl = this.tComboEditor_Simulation;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Simulation)
                    {
                        // �V���~���[�V�������o�͏�
                        e.NextCtrl = this.tComboEditor_OutputDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDiv)
                    {
                        // �o�͏����݌Ƀ}�X�^�X�V
                        e.NextCtrl = this.tComboEditor_Update;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Update)
                    {
                        // �݌Ƀ}�X�^�X�V���Ǘ��敪�P
                        e.NextCtrl = this.clb_ManagerDiv1;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv1)
                    {
                        // �Ǘ��敪�P���Ǘ��敪�Q
                        e.NextCtrl = this.clb_ManagerDiv2;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv2)
                    {
                        // �Ǘ��敪�Q���ݒ�R�[�h
                        e.NextCtrl = this.tNEdit_PatterNo;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    isMouseClick = false;
                    if (e.PrevCtrl == this.clb_ManagerDiv2)
                    {
                        // �Ǘ��敪�Q���Ǘ��敪�P
                        e.NextCtrl = this.clb_ManagerDiv1;
                    }
                    else if (e.PrevCtrl == this.clb_ManagerDiv1)
                    {
                        // �Ǘ��敪�P���݌Ƀ}�X�^�X�V
                        e.NextCtrl = this.tComboEditor_Update;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Update)
                    {
                        // �݌Ƀ}�X�^�X�V���o�͏�
                        e.NextCtrl = this.tComboEditor_OutputDiv;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_OutputDiv)
                    {
                        // �o�͏����V���~���[�V����
                        e.NextCtrl = this.tComboEditor_Simulation;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_Simulation)
                    {
                        // �V���~���[�V�������W�v���@
                        e.NextCtrl = this.tComboEditor_SumMethod;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_SumMethod)
                    {
                        if (!this.tNedit_BLGoodsCode_Ed.ReadOnly)
                        {
                            // �W�v���@��BL�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                        }
                        else if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �W�v���@��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �W�v���@�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        if (!this.tNedit_BLGoodsCode_St.ReadOnly)
                        {
                            // �W�v���@��BL�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGoodsCode_St;
                        }
                        else if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �W�v���@�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        if (!this.tNedit_BLGloupCode_Ed.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�I��)
                            e.NextCtrl = this.tNedit_BLGloupCode_Ed;
                        }
                        else if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �W�v���@�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
                    {
                        if (!this.tNedit_BLGloupCode_St.ReadOnly)
                        {
                            // �W�v���@���O���[�v�R�[�h(�J�n)
                            e.NextCtrl = this.tNedit_BLGloupCode_St;
                        }
                        else if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �W�v���@�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
                    {
                        if (!this.tNedit_GoodsMGroup_Ed.ReadOnly)
                        {
                            // �W�v���@�����i������(�I��)
                            e.NextCtrl = this.tNedit_GoodsMGroup_Ed;
                        }
                        else if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
                    {
                        if (!this.tNedit_GoodsMGroup_St.ReadOnly)
                        {
                            // �W�v���@�����i������(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMGroup_St;
                        }
                        else if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
                    {
                        if (!this.tNedit_GoodsMakerCd_Ed.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�I��)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                        }
                        else if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        if (!this.tNedit_GoodsMakerCd_St.ReadOnly)
                        {
                            // �W�v���@�����[�J�[(�J�n)
                            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                        }
                        else if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        if (!this.tNedit_SupplierCd_Ed.ReadOnly)
                        {
                            // �W�v���@���d����(�I��)
                            e.NextCtrl = this.tNedit_SupplierCd_Ed;
                        }
                        else if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        if (!this.tNedit_SupplierCd_St.ReadOnly)
                        {
                            // �W�v���@���d����(�J�n)
                            e.NextCtrl = this.tNedit_SupplierCd_St;
                        }
                        else if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        if (!this.tEdit_WarehouseCode_Ed.ReadOnly)
                        {
                            // �W�v���@���q��(�I��)
                            e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                        }
                        else if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_Ed)
                    {
                        if (!this.tEdit_WarehouseCode_St.ReadOnly)
                        {
                            // �W�v���@���q��(�J�n)
                            e.NextCtrl = this.tEdit_WarehouseCode_St;
                        }
                        else
                        {
                            // �W�v���@���ݒ�R�[�h
                            e.NextCtrl = this.tNEdit_PatterNo;
                        }
                    }
                    else if (e.PrevCtrl == this.tEdit_WarehouseCode_St)
                    {
                        // �q��(�J�n)���ݒ�R�[�h
                        e.NextCtrl = this.tNEdit_PatterNo;
                    }
                    else if (e.PrevCtrl == this.tNEdit_PatterNo)
                    {
                        // �ݒ�R�[�h���Ǘ��敪�Q
                        e.NextCtrl = this.clb_ManagerDiv2;
                    }
                }
            }

            if (isMouseClick)
            {
                // �q��(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tEdit_WarehouseCode_St && this.tEdit_WarehouseCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // �q��(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tEdit_WarehouseCode_Ed && this.tEdit_WarehouseCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // �d����(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_SupplierCd_St && this.tNedit_SupplierCd_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // �d����(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_SupplierCd_Ed && this.tNedit_SupplierCd_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // ���[�J�[(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_GoodsMakerCd_St && this.tNedit_GoodsMakerCd_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // ���[�J�[(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_GoodsMakerCd_Ed && this.tNedit_GoodsMakerCd_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // ������(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_GoodsMGroup_St && this.tNedit_GoodsMGroup_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // ������(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_GoodsMGroup_Ed && this.tNedit_GoodsMGroup_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // �O���[�v(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_BLGloupCode_St && this.tNedit_BLGloupCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // �O���[�v(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_BLGloupCode_Ed && this.tNedit_BLGloupCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // BL�R�[�h(�J�n)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_BLGoodsCode_St && this.tNedit_BLGoodsCode_St.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
                // BL�R�[�h(�I��)���ݒ�R�[�h
                if (e.NextCtrl == this.tNedit_BLGoodsCode_Ed && this.tNedit_BLGoodsCode_Ed.ReadOnly == true)
                {
                    e.NextCtrl = this.tNEdit_PatterNo;
                }
            }
        }
        #endregion
        #endregion �� Control Event

        #region �� Initialize_Timer
        #region �� Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R���g���[��������
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // �K�C�h�{�^���̃A�C�R���ݒ�
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMGroupGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGloupCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);

                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                // �����t�H�[�J�X
                this.tNEdit_PatterNo.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion �� Initialize_Timer

        #region �� �t�H�[�J�X�A�E�g
        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNEdit_PatterNo_AfterExitEditMode(object sender, EventArgs e)
        {
            if (0 == this.tNEdit_PatterNo.GetInt())
            {
                this.tNEdit_PatterNo.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �q�ɃR�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (!IsNumber(this.tEdit_WarehouseCode_St.Text))
            {
                this.tEdit_WarehouseCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃR�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tEdit_WarehouseCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �q�ɃR�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (!IsNumber(this.tEdit_WarehouseCode_Ed.Text))
            {
                this.tEdit_WarehouseCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �d����R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_SupplierCd_St.GetInt())
            {
                this.tNedit_SupplierCd_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_SupplierCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �d����R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_SupplierCd_Ed.GetInt())
            {
                this.tNedit_SupplierCd_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMakerCd_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���[�J�[�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMakerCd_St.GetInt())
            {
                this.tNedit_GoodsMakerCd_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks>
        private void tNedit_GoodsMakerCd_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // ���[�J�[�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                this.tNedit_GoodsMakerCd_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �����ރR�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �����ރR�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMGroup_St.GetInt())
            {
                this.tNedit_GoodsMGroup_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �����ރR�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_GoodsMGroup_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �����ރR�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                this.tNedit_GoodsMGroup_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // �O���[�v�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGloupCode_St.GetInt())
            {
                this.tNedit_BLGloupCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGloupCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // �O���[�v�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGloupCode_Ed.GetInt())
            {
                this.tNedit_BLGloupCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�J�n�t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_St_AfterExitEditMode(object sender, EventArgs e)
        {
            // BL�R�[�h�J�n�̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGoodsCode_St.GetInt())
            {
                this.tNedit_BLGoodsCode_St.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// AfterExitEditMode �C�x���g�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�I���t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void tNedit_BLGoodsCode_Ed_AfterExitEditMode(object sender, EventArgs e)
        {
            // BL�R�[�h�I���̒l�͐����ł͂Ȃ��ꍇ
            if (0 == this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                this.tNedit_BLGoodsCode_Ed.Text = string.Empty;
                return;
            }
        }

        /// <summary>
        /// �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XEnter���A�I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XEnter�ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                // �I�����
                ((ListBox)sender).SetSelected(0, true);
            }
        }

        /// <summary>
        /// �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XLeave���A�I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XLeave�ɔ������܂��B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.02</br> 
        /// </remarks> 
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // �I����ԉ���
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        #endregion
    }
}
