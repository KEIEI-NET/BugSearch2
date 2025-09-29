//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.Misc;
using System.IO;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������i���i����UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i����UI�t�H�[���N���X</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    public partial class PMKHN02301UA : Form,
                                        IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                        IPrintConditionInpTypeUpdate,       //���[�Ɩ�(�������̓^�C�v)���s
                                        IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Private Const
        /// <summary> �N���XID </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_ClassID = "PMKHN02301UA";
        /// <summary> �v���O����ID </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_PGID = "PMKHN02301U";
        /// <summary> ���[���� </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_PrintName = "�������i���i����";
        /// <summary> ���[�L�[ </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_PrintKey = "0c38d05b-a581-4548-b794-25cbfcbf2070";
        /// <summary> ���@�P�� </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_Ken = "��";
        /// <summary> 0 </summary>
        /// <remarks>�Ȃ�</remarks>
        private const string ct_Zero = "0";
        /// <summary>�R�[�f�B���O</summary>
        /// <remarks>�Ȃ�</remarks>
        public const string ENCODING_CODE = "shift_jis";
        #endregion �� Private Const


        #region �� Private Members

        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B 
        private bool _canPdf = false;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = false;
        // �m��{�^���\���L���v���p�e�B
        private bool _canUpdate = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;
        //���[�J�[�A�N�Z�X�N���X
        private MakerAcs _makerAcs;
        //BL���i�R�[�h�N�Z�X�N���X
        private BLGoodsCdAcs _bLGoodsCdAcs;
        //�d����N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        //��ƃR�[�h
        private string _enterpriseCode;
        //�������i���i�����A�N�Z�X�N���X
        private GoodsInfoAcs _goodsInfoAcs;

        //private bool _updateFlg;

        //�t�@�C���f�[�^
        ArrayList _data;
        //�`�F�b�N��f�[�^
        List<List<GoodsInfoData>> _checkData;

        //�`�F�b�N��Pdf�f�[�^
        List<List<GoodsInfoStringData>> _checkPdfData;

        #endregion �� Private Members


        # region �� Constractor
        /// <summary>
        /// �������i���i����UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i����UI�t�H�[���N���X�R���X�g���N�^</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02301UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //�������i���i�����A�N�Z�X�N���X
            this._goodsInfoAcs = new GoodsInfoAcs();

            //���[�J�[�A�N�Z�X�N���X
            this._makerAcs = new MakerAcs();

            //BL���i�R�[�h�N�Z�X�N���X
            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            //�d����N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();

            //_updateFlg = false;
        }
        # endregion �� Constractor


        #region �� IPrintConditionInpType �����o

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

        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }

        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            //if (!this._updateFlg)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�m��{�^�����s���B", 0);
            //    return -1;
            //}

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            ////�t�@�C���f�[�^
            //this._data = null;
            //status = this.ReadData(out _data);

            //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�t�@�C����ǂݍ��ނ����s���܂��B", 0);
            //    return status;
            //}

            //if (_data.Count == 0)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�e�L�X�g�t�@�C���̒��ɁA�f�[�^��������܂���ł����B", 0);
            //    return status;
            //}

            //this._checkData = null;
            //this._checkPdfData = null;
            //status = this.CheckData(ref _data, out _checkData, out _checkPdfData);

            //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�t�@�C���f�[�^���`�F�b�N�����s���܂��B", 0);
            //    return status;
            //}

            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            printInfo.enterpriseCode = this._enterpriseCode;	// ��ƃR�[�h
            printInfo.kidopgid = ct_PGID;				        // �N��PGID
            printInfo.key = ct_PrintKey;			            // PDF�o�͗���p
            printInfo.prpnm = ct_PrintName;			            // PDF�o�͗���p

            // ���o�����N���X
            GoodsInfoCndtn extrInfo = new GoodsInfoCndtn();

            // ���o�����ݒ菈��(��ʁ����o����)
            SetExtrInfo(ref extrInfo);

            // ���o�����̐ݒ�
            printInfo.PrintPaperSetCd = 0;
            printInfo.jyoken = extrInfo;

            //// �X�V��̏ꍇ�A���Ƀf�[�^���擾�ς݂Ȃ̂ōČ������s��Ȃ�
            //if (this._updateFlg == true)
            //{
            //    printInfo.rdData = this._dataView;
            //}
            //else
            //{
            //    printInfo.rdData = null;
            //}

            DataTable dataTable = new DataTable();
            PMKHN02306EA.CreateDataTableGoodsWarnErrorCheck(ref dataTable);
            //this.SetDataTable(ref dataTable, _checkData);
            this.SetDataTable(ref dataTable, _checkPdfData);
            // �t�B���^�[������
            string strFilter = string.Empty;
            // �\�[�g��������擾
            //string strSort = MakeSortingOrderString();
            string strSort = PMKHN02306EA.ct_Col_Orderby + " ASC";

            // ���o���ʃe�[�u������w�肳�ꂽ�t�B���^�E�\�[�g�����Ńf�[�^�r���[���쐬
            DataView dv = new DataView(dataTable, strFilter, strSort, DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                // �f�[�^���Z�b�g
                printInfo.rdData = dv;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
                return status;
            }

            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            printDialog.ShowDialog();

            //if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            //{
            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Ώۏ��i�����݂��܂���B", 0);
            //}

            parameter = printInfo;

            this._canPdf = false;
            this._canPrint = false;
            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);

            return printInfo.status;
        }

        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���܂��B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {

            string errMessage = "";
            Control errComponent = null;

            // ���̓`�F�b�N����
            if (!ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null) errComponent.Focus();

                return (false);
            }

            return (true);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
            this.Show();
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B</summary>
        /// <value>VisibledExtractButton</value>               
        /// <remarks>���o�{�^���\���L���擾�v���p�e�B </remarks> 
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L��</summary>
        /// <value>CanPrint</value>               
        /// <remarks>PDF�o�̓{�^���\���L���v���p�e�B�擾�v���p�e�B </remarks> 
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\��</summary>
        /// <value>VisibledPrintButton</value>               
        /// <remarks>����{�^���\���擾�v���p�e�B </remarks> 
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� IPrintConditionInpType �����o


        #region �� IPrintConditionInpTypePdfCareer �����o

        /// <summary> ���[�L�[</summary>
        /// <value>PrintKey</value>               
        /// <remarks>���[�L�[�擾�v���p�e�B </remarks>  
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> ���[��</summary>
        /// <value>PrintName</value>               
        /// <remarks>���[���擾�v�v���p�e�B </remarks> 
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        #endregion �� IPrintConditionInpTypePdfCareer �����o


        #region �� IPrintConditionInpTypeUpdate �����o

        /// <summary> ���s�{�^�����</summary>
        /// <value>CanUpdate</value>               
        /// <remarks>���s�{�^����Ԏ擾�v�v���p�e�B </remarks> 
        public bool CanUpdate
        {
            get { return this._canUpdate; }
        }

        /// <summary>
        /// ���s����
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �X�V�{����������s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        public int Update(ref object parameter)
        {
            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    "�������i���i����" + "�f�[�^�X�V�Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL; ;
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //�t�@�C���f�[�^
            this._data = null;
            status = this.ReadData(out _data);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�t�@�C����ǂݍ��ނ����s���܂��B", 0);
                return status;
            }

            if (_data.Count == 0)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�e�L�X�g�t�@�C���̒��ɁA�f�[�^��������܂���ł����B", 0);
                return status;
            }

            this._checkData = null;
            this._checkPdfData = null;
            //�f�[�^���`�F�b�N����
            status = this.CheckData(ref _data, out _checkData, out _checkPdfData);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�t�@�C���f�[�^���`�F�b�N�����s���܂��B", 0);
                return status;
            }

            List<GoodsInfoData> errorLst = new List<GoodsInfoData>();
            List<GoodsInfoData> normalLst = new List<GoodsInfoData>();
            List<GoodsInfoData> warnLst = new List<GoodsInfoData>();
            normalLst = _checkData[0] as List<GoodsInfoData>;
            warnLst = _checkData[1] as List<GoodsInfoData>;
            errorLst = _checkData[2] as List<GoodsInfoData>;

            // �X�V����
            if (((null != warnLst) && (warnLst.Count > 0))
                || ((null != errorLst) && (errorLst.Count > 0)))
            {
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                        ct_ClassID,
                                                        "�G���[�E�x�����������܂����B����^PDF�o�͂��s���A���e���m�F���ĉ������B",
                                                        0,
                                                        MessageBoxButtons.OK);
                this._canPdf = true;
                this._canPrint = true;
                // �c�[���o�[�ݒ�C�x���g
                ParentToolbarSettingEvent(this);
                //this._updateFlg = true;
            }
            else
            {
                this._canPdf = false;
                this._canPrint = false;
                // �c�[���o�[�ݒ�C�x���g
                ParentToolbarSettingEvent(this);
                //this._updateFlg = false;
            }

            // ���o�����ݒ菈��(��ʁ����o����)
            GoodsInfoCndtn extrInfo = new GoodsInfoCndtn();
            SetExtrInfo(ref extrInfo);

            object countNum = null;
            object writeError;
            string errMsg = string.Empty;
            // �X�V
            if (((null != normalLst) && (normalLst.Count > 0)) || ((null != warnLst) && (warnLst.Count > 0)))
            {
                status = this._goodsInfoAcs.WriteGoodsInfo(out countNum, out writeError, extrInfo, normalLst, warnLst, out  errMsg);
            }

            ArrayList ret = countNum as ArrayList;

            //���͌���
            this.ultraLabel_InsertNum.Text = NumberFormat(this._data.Count) + ct_Ken;

            if (null != countNum && null != ret && ret.Count > 0)
            {
                //�X�V����
                this.ultraLabel_UpdateNum.Text = NumberFormat(Convert.ToInt32(ret[0])) + ct_Ken;
                //�ǉ�����
                this.ultraLabel_AddNum.Text = NumberFormat(Convert.ToInt32(ret[1])) + ct_Ken;
            }
            else
            {
                //�X�V����
                this.ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
                //�ǉ�����
                this.ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            }

            //�x������
            if ((null != warnLst) && (warnLst.Count > 0))
            {
                this.ultraLabel_WarnNum.Text = NumberFormat(warnLst.Count) + ct_Ken;
            }
            else
            {
                this.ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            }

            //�G���[����
            if ((null != errorLst) && (errorLst.Count > 0))
            {
                this.ultraLabel_ErrorNum.Text = NumberFormat(errorLst.Count) + ct_Ken;
            }
            else
            {
                this.ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;
            }

            this.tEdit_FileName.Focus();


            if (null != countNum && null != ret && ret.Count > 0)
            {
                if (Convert.ToInt32(ret[0]) > 0 || Convert.ToInt32(ret[1]) > 0)
                {
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            return (status);
            // �������
            //return Print(ref parameter);
        }

        #endregion �� IPrintConditionInpTypeUpdate �����o


        #region �� Private Methods
        /// <summary>
        /// ��ʏ�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񏉊��ݒ菈��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // ���i�}�X�^�X�V�敪
            InitializeUpdateType();

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SetIconImage(this.ultraButton_FileName, Size16_Index.STAR1);

        }

        /// <summary>
        /// ���i�}�X�^�X�V�敪
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���i�}�X�^�X�V�敪�̏��������s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void InitializeUpdateType()
        {
            this.tComboEditor_UpdateType.Items.Clear();

            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateZero, GoodsInfoCndtn.ct_UpdateZeroName);
            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateOne, GoodsInfoCndtn.ct_UpdateOneName);
            this.tComboEditor_UpdateType.Items.Add(GoodsInfoCndtn.ct_UpdateTwo, GoodsInfoCndtn.ct_UpdateTwoName);

            this.tComboEditor_UpdateType.MaxDropDownItems = this.tComboEditor_UpdateType.Items.Count;
            this.tComboEditor_UpdateType.SelectedIndex = 0;
        }

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion


        /// <summary>
        /// ���o�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����ݒ菈��</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetExtrInfo(ref GoodsInfoCndtn goodsInfoCndtn)
        {
            // ��ƃR�[�h
            goodsInfoCndtn.EnterpriseCode = this._enterpriseCode;

            //�t�@�C������
            goodsInfoCndtn.FileName = this.tEdit_FileName.Text;

            //���i�}�X�^�X�V�敪
            goodsInfoCndtn.UpdateType = Convert.ToInt32(this.tComboEditor_UpdateType.SelectedItem.DataValue);

        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���g���[��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: ���͓��e�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            const string ct_MustInputError = "����͂��Ă��������B";
            const string ct_ExistError = "��������܂���ł����B";

            if (!string.IsNullOrEmpty(this.tEdit_FileName.Text))
            {
                if ((!File.Exists(this.tEdit_FileName.Text)))
                {
                    errMessage = string.Format("{0}{1}", this.tEdit_FileName.Text, ct_ExistError);
                    errComponent = this.tEdit_FileName;
                    return (false);
                }
            }
            else
            {
                errMessage = string.Format("���̓t�@�C����{0}", ct_MustInputError);
                errComponent = this.tEdit_FileName;
                return (false);
            }
            return (true);
        }

        /// <summary>
        /// ���̓t�@�C��Read����
        /// </summary>
        /// <param name="textCode">�ϊ���Ώ�</param>
        /// <returns>�߂�l�F0:���� 3:EOF</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ��B</br>
        /// <br>Programmer : ���痈</br>            
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int ReadData(out ArrayList data)
        {
            data = new ArrayList();
            string fileName = this.tEdit_FileName.Text;
            if (!File.Exists(fileName))
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            StreamReader sr;
            sr = new StreamReader(fileName, Encoding.GetEncoding(ENCODING_CODE));
            int i = 0;
            try
            {
                //GoodsInfoData temGoodsAddData = null;
                GoodsInfoStringData temStringData = null;

                while (sr.Peek() >= 0)
                {
                    string lineText = sr.ReadLine();
                    string lineTextTmp;
                    string ret;
                    if (lineText.Trim().Length != 0)
                    {
                        //    textCode = GetTextCode(lineText.Split('='), true, null);
                        //    return 0;
                        //temGoodsAddData = new GoodsInfoData();



                        //if (119 != lineText.Length)
                        if ((lineText.Length < 109) && (lineText.Length > 119))
                        {
                            sr.Close();
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        temStringData = new GoodsInfoStringData();
                        lineTextTmp = lineText.Clone() as string;


                        //// ��ƃR�[�h
                        //temGoodsAddData.EnterpriseCode = this._enterpriseCode;
                        ////�d���溰��		4 	4 	1 
                        //temGoodsAddData.SupplierCd = Convert.ToInt32(lineText.Substring(0, 4));
                        ////Ұ������		4 	4 	5 
                        //temGoodsAddData.GoodsMakerCd = Convert.ToInt32(lineText.Substring(4, 4));
                        ////���޺���		4 	4 	9 
                        //temGoodsAddData.KindCd = lineText.Substring(8, 4);
                        ////������		4 	4 	13 
                        //temGoodsAddData.BLGoodsCode = Convert.ToInt32(lineText.Substring(12, 4));
                        ////�i�@��		18 	18 	17 
                        //temGoodsAddData.GoodsNo = lineText.Substring(16, 18);
                        ////�i�@��		20 	20 	35 
                        //temGoodsAddData.GoodsName = lineText.Substring(34, 20);
                        ////��@��		7 	7 	55 
                        //temGoodsAddData.Price = Convert.ToDouble(lineText.Substring(54, 7));
                        ////���i�������P		7 	7 	62 
                        //temGoodsAddData.Price1 = Convert.ToDouble(lineText.Substring(61, 7));
                        ////���i�������Q		7 	7 	69 
                        //temGoodsAddData.Price2 = Convert.ToDouble(lineText.Substring(68, 7));
                        ////���i�������R		7 	7 	76 
                        //temGoodsAddData.Price3 = Convert.ToDouble(lineText.Substring(75, 7));
                        ////���i���{��		8 	8 	83 
                        //temGoodsAddData.PriceStartDate = Convert.ToInt64(lineText.Substring(82, 8));
                        ////�o�^�敪		1 	1 	91 
                        //temGoodsAddData.LoginFlg = lineText.Substring(90, 1);
                        ////������		5 	5 	92 
                        //temGoodsAddData.StockRate = Convert.ToDouble(lineText.Substring(91, 5));
                        ////���@��		9 	9 	97 
                        //temGoodsAddData.SalesUnitCost = Convert.ToDouble(lineText.Substring(96, 9));
                        ////���i������		6 	6 	106 
                        //temGoodsAddData.GoodsTraderCd = lineText.Substring(105, 6);
                        ////�쐬���t		8 	8 	112 
                        //temGoodsAddData.FileCreateDateTime = Convert.ToInt64(lineText.Substring(111, 8));

                        // ��ƃR�[�h
                        temStringData.EnterpriseCode = this._enterpriseCode;
                        //�d���溰��		4 	4 	1 
                        temStringData.SupplierCd = lineText.Substring(0, 4);
                        //Ұ������		4 	4 	5 
                        temStringData.GoodsMakerCd = lineText.Substring(4, 4);
                        //���޺���		4 	4 	9 
                        temStringData.KindCd = lineText.Substring(8, 4);
                        //������		4 	4 	13 
                        temStringData.BLGoodsCode = lineText.Substring(12, 4);
                        //�i�@��		18 	18 	17 
                        temStringData.GoodsNo = lineText.Substring(16, 18);
                        //�i�@��		20 	20 	35 
                        //temStringData.GoodsName = lineText.Substring(34, 20);
                        //temStringData.GoodsName = GetStringToByte(lineTextTmp.Substring(34), 20);
                        int index = GetGoodsName(lineTextTmp, 34, 20, out ret);
                        temStringData.GoodsName = ret;
                        //��@��		7 	7 	55 
                        //temStringData.Price = lineText.Substring(54, 7);
                        temStringData.Price = lineText.Substring(index, 7);
                        //���i�������P		7 	7 	62 
                        //temStringData.Price1 = lineText.Substring(61, 7);
                        temStringData.Price1 = lineText.Substring(index + 7, 7);
                        //���i�������Q		7 	7 	69 
                        //temStringData.Price2 = lineText.Substring(68, 7);
                        temStringData.Price2 = lineText.Substring(index + 14, 7);
                        //���i�������R		7 	7 	76 
                        //temStringData.Price3 = lineText.Substring(75, 7);
                        temStringData.Price3 = lineText.Substring(index + 21, 7);
                        //���i���{��		8 	8 	83 
                        //temStringData.PriceStartDate = lineText.Substring(82, 8);
                        temStringData.PriceStartDate = lineText.Substring(index + 28, 8);
                        //�o�^�敪		1 	1 	91 
                        //temStringData.LoginFlg = lineText.Substring(90, 1);
                        temStringData.LoginFlg = lineText.Substring(index + 36, 1);
                        //������		5 	5 	92 
                        //temStringData.StockRate = lineText.Substring(91, 5);
                        temStringData.StockRate = lineText.Substring(index + 37, 5);
                        //���@��		9 	9 	97 
                        //temStringData.SalesUnitCost = lineText.Substring(96, 9);
                        temStringData.SalesUnitCost = lineText.Substring(index + 42, 9);
                        //���i������		6 	6 	106 
                        //temStringData.GoodsTraderCd = lineText.Substring(105, 6);
                        temStringData.GoodsTraderCd = lineText.Substring(index + 51, 6);
                        //�쐬���t		8 	8 	112 
                        //temStringData.FileCreateDateTime = lineText.Substring(111, 8);
                        temStringData.FileCreateDateTime = lineText.Substring(index + 57, 8);
                        //�󎚏�
                        temStringData.Orderby = i++;

                        data.Add(temStringData);
                    }
                }
                sr.Close();
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                sr.Close();
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        int GetGoodsName(string srcStr, int startIndex, int byteLength, out string ret)
        {
            string tempStr = srcStr.Substring(startIndex);
            int index = 0;
            ret = string.Empty;
            int byteCount = 0;
            for (int i = 0; i < tempStr.Length; i++)
            {
                string str = tempStr[i].ToString();
                if (ValidString(str))
                {
                    byteCount += 2;
                }
                else
                {
                    byteCount++;
                }
                if (byteCount == byteLength)
                {
                    ret = tempStr.Substring(0, i + 1);
                    index = i + startIndex + 1;
                    break;
                }
            }
            return index;
        }

        static bool ValidString(string value)
        {
            if (Regex.IsMatch(value, @"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        /// <summary>
        /// �f�[�^�ʐ��𐧌�����
        /// </summary>
        /// <param name="useName"></param>
        /// <param name="byteLength"></param>
        /// <returns>�����㕶��</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ʐ��𐧌��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private string GetStringToByte(string useName, int byteLength)
        {
            string str = useName.Clone() as string;
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
            int n = 0;  //  ���Y�̊���
            int i;  //  �\���̊���
            if (bytes.GetLength(0) < byteLength)
            {
                return str;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                if (i % 2 == 0)
                {
                    n++;
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            if (i % 2 == 1)
            {
                if (bytes[i] > 0)
                    i = i - 1;
                else
                    i = i + 1;
            }
            string ret = System.Text.Encoding.Unicode.GetString(bytes, 0, i);
            return ret;
        }

        /// <summary>
        /// �f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="dataTable">�f�[�^�e�[�u��</param>
        /// <param name="trustStockResultList">�������i���i�������[�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �������i���i�������[�f�[�^���f�[�^�e�[�u���ɐݒ肵�܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetDataTable(ref DataTable dataTable, List<List<GoodsInfoStringData>> checkPdfData)
        {
            List<GoodsInfoStringData> warnPdfLst = checkPdfData[1] as List<GoodsInfoStringData>;
            List<GoodsInfoStringData> errorPdfLst = checkPdfData[2] as List<GoodsInfoStringData>;

            if (((warnPdfLst != null) && (warnPdfLst.Count > 0)) || ((null != errorPdfLst) && (errorPdfLst.Count > 0)))
            {
                if ((warnPdfLst != null) && (warnPdfLst.Count > 0))
                {
                    foreach (GoodsInfoStringData temGoodsInfoPdfData in warnPdfLst)
                    {
                        DataRow dr = dataTable.NewRow();
                        //�d���溰��
                        dr[PMKHN02306EA.ct_Col_SupplierCd] = temGoodsInfoPdfData.SupplierCd;
                        //���[�J�[
                        dr[PMKHN02306EA.ct_Col_GoodsMakerCd] = temGoodsInfoPdfData.GoodsMakerCd;
                        //�a�k�R�[�h
                        dr[PMKHN02306EA.ct_Col_BLGoodsCode] = temGoodsInfoPdfData.BLGoodsCode;
                        //�i��
                        dr[PMKHN02306EA.ct_Col_GoodsNo] = temGoodsInfoPdfData.GoodsNo;
                        //�i��
                        dr[PMKHN02306EA.ct_Col_GoodsName] = temGoodsInfoPdfData.GoodsName;
                        //�艿
                        dr[PMKHN02306EA.ct_Col_Price] = temGoodsInfoPdfData.Price;
                        //�d����
                        dr[PMKHN02306EA.ct_Col_SaleRate] = temGoodsInfoPdfData.StockRate;
                        //����
                        dr[PMKHN02306EA.ct_Col_SalesUnitCost] = temGoodsInfoPdfData.SalesUnitCost;

                        //���
                        if (GoodsInfoData.ct_PdfStatusForWarn.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForWarnName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForError.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForErrorName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForNormal.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForNormalName;
                        }
                        //�`�F�b�N
                        dr[PMKHN02306EA.ct_Col_CheckMessage] = temGoodsInfoPdfData.CheckMessage;
                        //�󎚏�
                        dr[PMKHN02306EA.ct_Col_Orderby] = temGoodsInfoPdfData.Orderby;

                        dataTable.Rows.Add(dr);
                    }
                }

                if ((errorPdfLst != null) && (errorPdfLst.Count > 0))
                {
                    foreach (GoodsInfoStringData temGoodsInfoPdfData in errorPdfLst)
                    {
                        DataRow dr = dataTable.NewRow();
                        //�d���溰��
                        dr[PMKHN02306EA.ct_Col_SupplierCd] = temGoodsInfoPdfData.SupplierCd;
                        //���[�J�[
                        dr[PMKHN02306EA.ct_Col_GoodsMakerCd] = temGoodsInfoPdfData.GoodsMakerCd;
                        //�a�k�R�[�h
                        dr[PMKHN02306EA.ct_Col_BLGoodsCode] = temGoodsInfoPdfData.BLGoodsCode;
                        //�i��
                        dr[PMKHN02306EA.ct_Col_GoodsNo] = temGoodsInfoPdfData.GoodsNo;
                        //�i��
                        dr[PMKHN02306EA.ct_Col_GoodsName] = temGoodsInfoPdfData.GoodsName;
                        //�艿
                        dr[PMKHN02306EA.ct_Col_Price] = temGoodsInfoPdfData.Price;
                        //�d����
                        dr[PMKHN02306EA.ct_Col_SaleRate] = temGoodsInfoPdfData.StockRate;
                        //����
                        dr[PMKHN02306EA.ct_Col_SalesUnitCost] = temGoodsInfoPdfData.SalesUnitCost;
                        //���
                        if (GoodsInfoData.ct_PdfStatusForWarn.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForWarnName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForError.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForErrorName;
                        }
                        else if (GoodsInfoData.ct_PdfStatusForNormal.Equals(temGoodsInfoPdfData.PdfStatus))
                        {
                            dr[PMKHN02306EA.ct_Col_PdfStatus] = GoodsInfoData.ct_PdfStatusForNormalName;
                        }
                        //�`�F�b�N
                        dr[PMKHN02306EA.ct_Col_CheckMessage] = temGoodsInfoPdfData.CheckMessage;

                        //�󎚏�
                        dr[PMKHN02306EA.ct_Col_Orderby] = temGoodsInfoPdfData.Orderby;

                        dataTable.Rows.Add(dr);
                    }
                }
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
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

        ///// <summary>
        ///// �G���[���b�Z�[�W�\������
        ///// </summary>
        ///// <param name="message">�\�����b�Z�[�W</param>
        ///// <param name="status">�X�e�[�^�X</param>
        ///// <param name="procnm">�������\�b�hID</param>
        ///// <param name="ex">��O���</param>
        ///// <remarks>
        ///// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        ///// <br>Programmer : ���痈</br>
        ///// <br>Date       : 2009/04/28</br>
        ///// </remarks>
        //private void MsgDispProc(string message, int status, string procnm, Exception ex)
        //{
        //    string errMessage = message + "\r\n" + ex.Message;

        //    TMsgDisp.Show(
        //        this, 								// �e�E�B���h�E�t�H�[��
        //        emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
        //        ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
        //        ct_PrintName,						// �v���O��������
        //        procnm, 							// ��������
        //        "",									// �I�y���[�V����
        //        errMessage,							// �\�����郁�b�Z�[�W
        //        status, 							// �X�e�[�^�X�l
        //        null, 								// �G���[�����������I�u�W�F�N�g
        //        MessageBoxButtons.OK, 				// �\������{�^��
        //        MessageBoxDefaultButton.Button1);	// �����\���{�^��
        //}


        #region �� �I�t���C����ԃ`�F�b�N����

        /// <summary>
        /// ���O�I�����I�����C����ԃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        private bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// �����[�g�ڑ��\����
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #endregion �� Private Methods


        #region �� Control Events
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������[�h�������ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void PMKHN02301UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�񏉊��ݒ�
            SetScreenInitialSetting();
            //string st = "1000000";


            //�󔒂��Z�b�g����
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);

            // �����t�H�[�J�X�ݒ�
            this.tEdit_FileName.Focus();
        }


        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }


        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���̓t�@�C�����{�^�����N���b�N�������ɔ������܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void ultraButton_FileName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // �^�C�g���o�[�̕�����
                    openFileDialog.Title = "���i�ǉ��f�[�^�t�@�C���I��";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                    //�u�t�@�C���̎�ށv���w��
                    //openFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";
                    openFileDialog.Filter = "���ׂẴt�@�C�� (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_FileName.Text = openFileDialog.FileName;
                    }
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// �f�[�^���`�F�b�N����
        /// </summary>
        /// <param name="data">�t�@�C���f�[�^</param>
        /// <param name="checkData">�`�F�b�N�����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �f�[�^���`�F�b�N���邱�Ƃ��s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int CheckData(ref  ArrayList data, out List<List<GoodsInfoData>> checkData, out List<List<GoodsInfoStringData>> checkPdfData)
        {
            // �i�@�ԃX�y�[�X
            const string SPACE18 = "                  ";
            // �i�@���X�y�[�X
            const string SPACE20 = "                    ";

            //�i�ԃG���[�t���O
            bool goodsNoErrFlg = false;

            //�i���x���t���O
            bool goodsNameWarnFlg = false;

            //���[�J�[�G���[�t���O
            bool goodsMakerCdErrFlg = false;
            //���[�J�[�x���t���O
            bool goodsMakerCdWarnFlg = false;

            //BL�R�[�h�G���[�t���O
            bool bLGoodsCodeErrFlg = false;

            //BL�R�[�h�x���t���O
            bool bLGoodsCodeWarnFlg = false;

            //�d����R�[�h�G���[�t���O
            bool supplierCdErrFlg = false;

            //�d����R�[�h�x���t���O
            bool supplierCdWarnFlg = false;

            //�艿�G���[�t���O
            bool priceErrFlg = false;

            //�������G���[�t���O
            bool stockRateErrFlg = false;
            //���@���G���[�t���O
            bool salesUnitCostErrFlg = false;


            ArrayList _makerLst = new ArrayList();
            ArrayList _bLGoodsCdLst = new ArrayList();
            ArrayList _supplierLst = new ArrayList();

            this.SearchAllMaker(out _makerLst);
            this.SearchAllBLGoodsCd(out _bLGoodsCdLst);
            this.SearchAllSupplierCode(out _supplierLst);

            int makerLstLen = _makerLst.Count;
            int bLGoodsCdLstLen = _bLGoodsCdLst.Count;
            int supplierLstLen = _supplierLst.Count;


            //�`�F�b�N���b�Z�[�W������
            StringBuilder strBuilder = null;
            checkData = new List<List<GoodsInfoData>>();
            List<GoodsInfoData> errorLst = new List<GoodsInfoData>();
            List<GoodsInfoData> normalLst = new List<GoodsInfoData>();
            List<GoodsInfoData> warnLst = new List<GoodsInfoData>();
            checkData.Add(normalLst);
            checkData.Add(warnLst);
            checkData.Add(errorLst);

            checkPdfData = new List<List<GoodsInfoStringData>>();
            List<GoodsInfoStringData> errorPdfLst = new List<GoodsInfoStringData>();
            List<GoodsInfoStringData> normalPdfLst = new List<GoodsInfoStringData>();
            List<GoodsInfoStringData> warnPdfLst = new List<GoodsInfoStringData>();
            checkPdfData.Add(normalPdfLst);
            checkPdfData.Add(warnPdfLst);
            checkPdfData.Add(errorPdfLst);

            GoodsInfoData temData = null;


            try
            {
                foreach (GoodsInfoStringData tmpGoodsInfoStringData in data)
                {
                    temData = new GoodsInfoData();
                    strBuilder = new StringBuilder(string.Empty);
                    goodsNoErrFlg = false;
                    goodsNameWarnFlg = false;
                    goodsMakerCdErrFlg = false;
                    goodsMakerCdWarnFlg = false;
                    bLGoodsCodeErrFlg = false;
                    bLGoodsCodeWarnFlg = false;
                    supplierCdErrFlg = false;
                    supplierCdWarnFlg = false;
                    priceErrFlg = false;
                    stockRateErrFlg = false;
                    salesUnitCostErrFlg = false;

                    //���g�p����
                    temData.EnterpriseCode = this._enterpriseCode;
                    temData.KindCd = tmpGoodsInfoStringData.KindCd;
                    temData.Price1 = tmpGoodsInfoStringData.Price1;
                    temData.Price2 = tmpGoodsInfoStringData.Price2;
                    temData.Price3 = tmpGoodsInfoStringData.Price3;
                    temData.LoginFlg = tmpGoodsInfoStringData.LoginFlg;
                    temData.GoodsTraderCd = tmpGoodsInfoStringData.GoodsTraderCd;
                    temData.FileCreateDateTime = tmpGoodsInfoStringData.FileCreateDateTime;
                    temData.PriceStartDate = Convert.ToInt64(tmpGoodsInfoStringData.PriceStartDate);

                    //�i�ԃ`�F�b�N	
                    //�X�y�[�X�̏ꍇ�̓G���[�Ƃ��܂��B
                    if (string.IsNullOrEmpty(tmpGoodsInfoStringData.GoodsNo)
                        || SPACE18.Equals(tmpGoodsInfoStringData.GoodsNo))
                    {
                        goodsNoErrFlg = true;
                    }
                    temData.GoodsNo = tmpGoodsInfoStringData.GoodsNo;
                    //�i���`�F�b�N	
                    //�X�y�[�X�̏ꍇ�͌x���Ƃ��܂��B
                    if (string.IsNullOrEmpty(tmpGoodsInfoStringData.GoodsName)
                        || SPACE20.Equals(tmpGoodsInfoStringData.GoodsName))
                    {
                        goodsNameWarnFlg = true;
                    }
                    temData.GoodsName = tmpGoodsInfoStringData.GoodsName;
                    //���[�J�[�`�F�b�N	
                    try
                    {
                        //�P�`�X�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.GoodsMakerCd = Convert.ToInt32(tmpGoodsInfoStringData.GoodsMakerCd);
                        if (temData.GoodsMakerCd < 1 || temData.GoodsMakerCd > 9999)
                        {
                            goodsMakerCdErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.GoodsMakerCd = temData.GoodsMakerCd.ToString("d04");
                        }

                        //���[�J�[�}�X�^���o�^�͌x���Ƃ��܂��B
                        if (makerLstLen > 0)
                        {
                            if (!ExistMaker(_makerLst, temData.GoodsMakerCd))
                            {
                                goodsMakerCdWarnFlg = true;
                            }
                        }
                        else
                        {
                            goodsMakerCdWarnFlg = true;
                        }
                    }
                    catch
                    {
                        goodsMakerCdErrFlg = true;
                        goodsMakerCdWarnFlg = true;
                    }




                    //BL�R�[�h�`�F�b�N	
                    try
                    {
                        //�O�`�X�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.BLGoodsCode = Convert.ToInt32(tmpGoodsInfoStringData.BLGoodsCode);
                        if (temData.BLGoodsCode < 0 || temData.BLGoodsCode > 9999)
                        {
                            bLGoodsCodeErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.BLGoodsCode = temData.BLGoodsCode.ToString("d05");
                        }
                        //BL�R�[�h�}�X�^���o�^�͌x���Ƃ��܂��B
                        if (bLGoodsCdLstLen > 0)
                        {
                            if (!ExistBLGoodsCd(_bLGoodsCdLst, temData.BLGoodsCode))
                            {
                                bLGoodsCodeWarnFlg = true;
                            }
                        }
                        else
                        {
                            bLGoodsCodeWarnFlg = true;
                        }
                    }
                    catch
                    {
                        bLGoodsCodeErrFlg = true;
                        bLGoodsCodeWarnFlg = true;
                    }


                    //�d����R�[�h�`�F�b�N	
                    try
                    {
                        //�O�`�X�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.SupplierCd = Convert.ToInt32(tmpGoodsInfoStringData.SupplierCd);
                        if (temData.SupplierCd < 0 || temData.SupplierCd > 9999)
                        {
                            supplierCdErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.SupplierCd = ((temData.SupplierCd)*100).ToString("d06");
                        }
                        //�d����}�X�^���o�^�͌x���Ƃ��܂��B
                        if (supplierLstLen > 0)
                        {
                            if (!ExistSupplierCode(_supplierLst, temData.SupplierCd))
                            {
                                supplierCdWarnFlg = true;
                            }
                        }
                        else
                        {
                            supplierCdWarnFlg = true;
                        }
                    }
                    catch
                    {
                        supplierCdErrFlg = true;
                        supplierCdWarnFlg = true;
                    }

                    //�艿�`�F�b�N	
                    try
                    {
                        //�O�`�X,�X�X�X,�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.Price = Convert.ToDouble(tmpGoodsInfoStringData.Price);
                        if (temData.Price < 0 || temData.Price > 9999999)
                        {
                            priceErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.Price = NumberFormat(temData.Price);
                        }
                        //tmpGoodsInfoStringData.Price = Convert.ToString((temData.Price));
                        temData.Price = (temData.Price);
                    }
                    catch
                    {
                        priceErrFlg = true;
                    }

                    //�������`�F�b�N	
                    try
                    {
                        //�O�`�X�X�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.StockRate = Convert.ToDouble(tmpGoodsInfoStringData.StockRate);
                        if (temData.StockRate < 0 || temData.StockRate > 9999999)
                        {
                            stockRateErrFlg = true;
                        }
                        else 
                        {
                            tmpGoodsInfoStringData.StockRate = ((temData.StockRate) / 100).ToString("0.00");
                        }
                        //tmpGoodsInfoStringData.StockRate = Convert.ToString((temData.StockRate) / 100);
                        temData.StockRate = (temData.StockRate);
                    }
                    catch
                    {
                        stockRateErrFlg = true;
                    }

                    //�����`�F�b�N	
                    try
                    {
                        //�O�`�X�X�X�X�X�X�X�X�X�ȊO�̓G���[�Ƃ��܂��B
                        temData.SalesUnitCost = Convert.ToDouble(tmpGoodsInfoStringData.SalesUnitCost);
                        //tmpGoodsInfoStringData.SalesUnitCost = Convert.ToString(temData.SalesUnitCost);
                        if (temData.SalesUnitCost < 0 || temData.SalesUnitCost > 999999999)
                        {
                            salesUnitCostErrFlg = true;
                        }
                        else 
                        {
                            //tmpGoodsInfoStringData.SalesUnitCost = NumberFormat(temData.SalesUnitCost);
                            tmpGoodsInfoStringData.SalesUnitCost = NumberFormat(temData.SalesUnitCost/100);
                        }
                    }
                    catch
                    {
                        salesUnitCostErrFlg = true;
                    }

                    //pdf��Ԃ��Z�b�g����
                    if (goodsNoErrFlg ||
                        goodsMakerCdErrFlg ||
                        bLGoodsCodeErrFlg ||
                        supplierCdErrFlg ||
                        priceErrFlg ||
                        stockRateErrFlg ||
                        salesUnitCostErrFlg)
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForError;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForError;
                        errorLst.Add(temData);
                        errorPdfLst.Add(tmpGoodsInfoStringData);
                    }
                    else if ((goodsNameWarnFlg
                                    || goodsMakerCdWarnFlg
                                    || bLGoodsCodeWarnFlg
                                    || supplierCdWarnFlg))
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForWarn;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForWarn;
                        warnLst.Add(temData);
                        warnPdfLst.Add(tmpGoodsInfoStringData);
                    }
                    else
                    {
                        tmpGoodsInfoStringData.PdfStatus = GoodsInfoData.ct_PdfStatusForNormal;
                        temData.PdfStatus = GoodsInfoData.ct_PdfStatusForNormal;
                        normalLst.Add(temData);
                        normalPdfLst.Add(tmpGoodsInfoStringData);
                    }

                    //�`�F�b�N���b�Z�[�W
                    //�d����R�[�h�`�F�b�N
                    if (supplierCdErrFlg || supplierCdWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_Supplier);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_Supplier);
                        }
                    }
                    //���[�J�[�`�F�b�N
                    if (goodsMakerCdErrFlg || goodsMakerCdWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsMaker);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsMaker);
                        }
                    }
                    //BL�R�[�h�`�F�b�N
                    if (bLGoodsCodeErrFlg || bLGoodsCodeWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_BLGoodsCode);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_BLGoodsCode);
                        }
                    }
                    //�i�ԃ`�F�b�N
                    if (goodsNoErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsNo);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsNo);
                        }
                    }
                    //�i���`�F�b�N
                    if (goodsNameWarnFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_GoodsName);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_GoodsName);
                        }
                    }


                    //�艿�`�F�b�N
                    if (priceErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_Price);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_Price);
                        }
                    }
                    //�������`�F�b�N
                    if (stockRateErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_StockRate);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_StockRate);
                        }
                    }
                    //�����`�F�b�N
                    if (salesUnitCostErrFlg)
                    {
                        if (strBuilder.Length == 0)
                        {
                            strBuilder.Append(GoodsInfoData.ct_SalesUnitCost);
                        }
                        else
                        {
                            strBuilder.Append(GoodsInfoData.ct_Sign);
                            strBuilder.Append(GoodsInfoData.ct_SalesUnitCost);
                        }
                    }
                    //�`�F�b�N���b�Z�[�W���Z�b�g����
                    tmpGoodsInfoStringData.CheckMessage = strBuilder.ToString();
                    temData.CheckMessage = strBuilder.ToString();
                }
                return 0;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }


        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(double number)
        {
            string ret;
            if (Math.Abs(number) > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }

        /// <summary>
        /// ���[�J�[���݂���
        /// </summary>
        /// <param name="_makerLst">���[�J�[���X�g</param>
        /// <param name="goodsMakerCd">���[�J�[</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�𑶍݂��邱�Ƃ��s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistMaker(ArrayList _makerLst, int goodsMakerCd)
        {
            bool result = false;
            foreach (MakerUMnt makerUMnt in _makerLst)
            {
                if (makerUMnt.GoodsMakerCd.Equals(goodsMakerCd))
                {
                    result = true;
                    break;

                }
            }
            return result;
        }



        /// <summary>
        /// ���[�J�[Read
        /// </summary>
        /// <param name="_makerLst">���[�J�[���X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[Read���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllMaker(out ArrayList _makerLst)
        {
            bool result = false;
            // �ǂݍ���
            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            //MakerUMnt makerUMnt;
            //int status = _makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsMakerCd);

            int status = _makerAcs.SearchAll(out _makerLst, this._enterpriseCode);

            if (status == 0 && _makerLst != null)
            {
                // ���݂��܂�
                result = true;
            }
            else
            {

                // ���݂��܂���
                result = false;
            }
            return result;
        }

        /// <summary>
        /// BL���i�R�[�h����
        /// </summary>
        /// <param name="_bLGoodsCdLst">BL���i�R�[�h���X�g</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : BL���i�R�[�h�𑶍݂��邱�Ƃ��s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistBLGoodsCd(ArrayList _bLGoodsCdLst, int bLGoodsCode)
        {
            bool result = false;
            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in _bLGoodsCdLst)
            {
                if (bLGoodsCdUMnt.BLGoodsCode.Equals(bLGoodsCode))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// BL���i�R�[�hRead
        /// </summary>
        /// <param name="_bLGoodsCdLst">BL���i�R�[�h���X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : BL���i�R�[�hRead���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllBLGoodsCd(out ArrayList _bLGoodsCdLst)
        {
            bool result = false;
            // �ǂݍ���
            if (_bLGoodsCdAcs == null)
            {
                _bLGoodsCdAcs = new BLGoodsCdAcs();
            }

            //BLGoodsCdUMnt bLGoodsCdUMnt;
            //int status = _bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, bLGoodsCode);

            int status = _bLGoodsCdAcs.SearchAll(out _bLGoodsCdLst, this._enterpriseCode);
            if (status == 0 && _bLGoodsCdLst != null)
            {
                // ���݂��܂�
                result = true;
            }
            else
            {

                // ���݂��܂���
                result = false;
            }
            return result;
        }

        /// <summary>
        /// �d����R�[�h���݂���
        /// </summary>
        /// <param name="_supplierLst">�d����R�[�h���X�g</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h���݂��邱�Ƃ��s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool ExistSupplierCode(ArrayList _supplierLst, int supplierCode)
        {
            bool result = false;
            int supplierCodeCmp = supplierCode * 100;
            foreach (Supplier supplier in _supplierLst)
            {
                if (supplier.SupplierCd.Equals(supplierCodeCmp))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// �d����R�[�hRead
        /// </summary>
        /// <param name="_supplierLst">�d����R�[�h���X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�hRead���s���B </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private bool SearchAllSupplierCode(out ArrayList _supplierLst)
        {
            bool result = false;
            // �ǂݍ���
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }

            //Supplier supplier;
            //int status = _supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);
            int status = _supplierAcs.SearchAll(out _supplierLst, this._enterpriseCode);

            if (status == 0 && _supplierLst != null)
            {
                // ���݂��܂�
                result = true;
            }
            else
            {

                // ���݂��܂���
                result = false;
            }
            return result;
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
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
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "PrintConditionGroup") ||
                (e.Group.Key == "ExtractConditionGroup"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ���̓t�@�C���� ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : ���̓t�@�C���� ValueChanged �C�x���g�𔭐����܂��B</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void tEdit_FileName_ValueChanged(object sender, EventArgs e)
        {
            this._canPdf = false;
            this._canPrint = false;

            //�󔒂��Z�b�g����
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);

            // �����t�H�[�J�X�ݒ�
            this.tEdit_FileName.Focus();

        }

        /// <summary>
        /// ���i�}�X�^�X�V�敪 ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�X�V�敪 ValueChanged �C�x���g�𔭐����܂��B</br>
        /// <br>Programer  : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void tComboEditor_UpdateType_ValueChanged(object sender, EventArgs e)
        {
            this._canPdf = false;
            this._canPrint = false;

            // �c�[���o�[�ݒ�C�x���g
            ParentToolbarSettingEvent(this);

            //�󔒂��Z�b�g����
            ultraLabel_InsertNum.Text = ct_Zero + ct_Ken;
            ultraLabel_UpdateNum.Text = ct_Zero + ct_Ken;
            ultraLabel_AddNum.Text = ct_Zero + ct_Ken;
            ultraLabel_WarnNum.Text = ct_Zero + ct_Ken;
            ultraLabel_ErrorNum.Text = ct_Zero + ct_Ken;

        }

        #endregion �� Control Events




    }
}