//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2009/09/02  �C�����e : PVCS#425 �O���b�h�\���̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �C �� ��  2012/12/07  �C�����e : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�R�[�h�ϊ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���i�R�[�h�ϊ��ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
    /// <br>Programmer	: ���M</br>
    /// <br>Date		: 2009.08.05</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSAE09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���i�R�[�h�ϊ��t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���i�R�[�h�ϊ��t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public PMSAE09020UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;
            this.flag = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // �ϐ�������
            this._dataIndex = -1;
            this._bLGoodsCodeSetAcs = new BLGoodsCodeSetAcs();
            this._totalCount = 0;
            this._bLGoodsCodeSetTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // �e��}�X�^�Ǎ�
            LoadBLGoodsCdUMnt();
        }

        #endregion

        #region -- Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        /*----------------------------------------------------------------------------------*/
        private BLGoodsCodeSetAcs _bLGoodsCodeSetAcs;
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BL�A�N�Z�X�N���X
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _bLGoodsCodeSetTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private SAndEGoodsCdChg _sAndEGoodsCdChgClone;

        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_BLGOODS_CODE_TITLE = "BL����";
        private const string VIEW_BLGOODS_NAME_TITLE = "BL���ޖ�";
        private const string VIEW_ABGOODSCODE_TITLE = "���i����";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _tmpBLCode;

        private Control _prevControl = null;

        private bool flag = false;

        #endregion

        #region -- Properties --
        /*----------------------------------------------------------------------------------*/
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        # endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʌ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            int status = 0;
            ArrayList bLCodeList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._bLGoodsCodeSetTable.Clear();

            // �S����
            status = this._bLGoodsCodeSetAcs.SearchAll(out bLCodeList, this._enterpriseCode);

            //������
            this._totalCount = bLCodeList.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SAndEGoodsCdChg sAndEGoodsCdSet in bLCodeList)
                        {
                            SAndEGoodsCdSetToDataSet(sAndEGoodsCdSet.Clone(), index);
                            ++index;
                        }
                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            "PMSAE09020U",							// �A�Z���u��ID
                            "���i�R�[�h�ϊ�",              �@�@   // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._bLGoodsCodeSetAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public int Delete()
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʍ폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 0;
            }

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SAndEGoodsCdChg sAndEGoodsCdChg = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

            int status;

            // ���i�R�[�h�ϊ��}�X�^���_���폜����
            status = this._bLGoodsCodeSetAcs.LogicalDelete(ref sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMSAE09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�폜�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGoodsCodeSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // ���i�R�[�h�ϊ��}�X�^���N���X�f�[�^�Z�b�g�W�J����
            SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(VIEW_BLGOODS_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));// ADD 2009/09/02
            appearanceTable.Add(VIEW_BLGOODS_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ABGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));// ADD 2009/09/02

            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SAndEGoodsCdChg sAndEGoodsCdChg = new SAndEGoodsCdChg();
                //�N���[���쐬
                this._sAndEGoodsCdChgClone = sAndEGoodsCdChg.Clone();

                this._indexBuf = this._dataIndex;

                this._tmpBLCode = string.Empty;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSAndEGoodsCdChg(ref this._sAndEGoodsCdChgClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tNedit_BLGoodsCode.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SAndEGoodsCdChg sAndEGoodsCdChgSet = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

                if (sAndEGoodsCdChgSet.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_ABGoodsCode.Focus();

                    // ���i�R�[�h�ϊ����N���X��ʓW�J����
                    SAndEGoodsCdChgToScreen(sAndEGoodsCdChgSet);

                    // �N���[���쐬
                    this._sAndEGoodsCdChgClone = sAndEGoodsCdChgSet.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSAndEGoodsCdChg(ref this._sAndEGoodsCdChgClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();

                    // ���i�R�[�h�ϊ����N���X��ʓW�J����
                    SAndEGoodsCdChgToScreen(sAndEGoodsCdChgSet);
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Renewal_Button.Visible = true;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.tEdit_BLGoodsHalfName.Enabled = false;

                    if (mode == INSERT_MODE)
                    {
                        // �V�K���[�h
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.BLGoodsGuide_Button.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }
                    else
                    {
                        // �X�V���[�h
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tNedit_BLGoodsCode.Enabled = false;
                    this.BLGoodsGuide_Button.Enabled = false;
                    this.tEdit_BLGoodsHalfName.Enabled = false;
                    this.tEdit_ABGoodsCode.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ�񏤕i�R�[�h�ϊ��N���X�i�[����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂珤�i�R�[�h�ϊ��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void ScreenToSAndEGoodsCdChg(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            if (sAndEGoodsCdChg == null)
            {
                // �V�K�̏ꍇ
                sAndEGoodsCdChg = new SAndEGoodsCdChg();
            }

            //��ƃR�[�h
            sAndEGoodsCdChg.EnterpriseCode = this._enterpriseCode;
            //BL����
            sAndEGoodsCdChg.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            //���i����
            //sAndEGoodsCdChg.ABGoodsCode = this.tEdit_ABGoodsCode.Text.PadLeft(6, '0');// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            sAndEGoodsCdChg.ABGoodsCode = this.tEdit_ABGoodsCode.Text.PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            //BL���ޖ�
            sAndEGoodsCdChg.BLGoodsHalfName = this.tEdit_BLGoodsHalfName.DataText;
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
            allDefSetTable.Columns.Add(VIEW_BLGOODS_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_BLGOODS_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ABGOODSCODE_TITLE, typeof(string));

            allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(allDefSetTable);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_BLGoodsCode.DataText = "";
            this.tEdit_BLGoodsHalfName.DataText = "";
            this.tEdit_ABGoodsCode.DataText = "";
            this._tmpBLCode = string.Empty;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���i�R�[�h�ϊ��N���X��ʓW�J����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void SAndEGoodsCdChgToScreen(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            // BL����
            this.tNedit_BLGoodsCode.Text = sAndEGoodsCdChg.BLGoodsCode.ToString().PadLeft(5, '0');
            // BL���ޖ�
            this.tEdit_BLGoodsHalfName.Text = sAndEGoodsCdChg.BLGoodsHalfName.Trim();
            // ���i����
            //this.tEdit_ABGoodsCode.DataText = sAndEGoodsCdChg.ABGoodsCode;// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            this.tEdit_ABGoodsCode.DataText = sAndEGoodsCdChg.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	���i�R�[�h�ϊ���ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���i�R�[�h�ϊ���ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
                // BL����
                if (this.tNedit_BLGoodsCode.DataText.Trim() == "")
                {
                    checkMessage = "BL���ނ�ݒ肵�ĉ������B";
                    returnStatus = 10;
                    return returnStatus;
                }

                // ���i����
                if (this.tEdit_ABGoodsCode.DataText.Trim() == "")
                {
                    checkMessage = "���i���ނ�ݒ肵�ĉ������B";
                    returnStatus = 20;
                    return returnStatus;
                }

                string reg = "^[0-9]*$";
                Regex regex = new Regex(reg);
                if (!regex.IsMatch(this.tEdit_ABGoodsCode.DataText.Trim()))
                {
                    checkMessage = "���i���ނ̐ݒ肪�s���ł��B";
                    returnStatus = 20;
                    return returnStatus;
                }

                return returnStatus;
            }
            finally
            {
                if (returnStatus != 0)
                {
                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "PMSAE09020U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }

                //�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
                switch (returnStatus)
                {
                    case 10:
                        {
                            this.tNedit_BLGoodsCode.Focus();
                            break;
                        }
                    case 20:
                        {
                            this.tEdit_ABGoodsCode.Focus();
                            break;
                        }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@�ۑ�����(SaveSAndEGoodsCdChg())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.05</br>
        /// </remarks>
        private bool SaveSAndEGoodsCdChg()
        {
            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e2 = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e2);
            }

            if (this.flag == false)
            {
                return false;
            }

            bool result = false;
            Control control = null;
            //��ʃf�[�^���̓`�F�b�N����
            string checkMessage = "";
            int chkSt = CheckDisplay(ref checkMessage);
            if (chkSt != 0)
            {
                return result;
            }

            SAndEGoodsCdChg sAndEGoodsCdChg = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                sAndEGoodsCdChg = ((SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid]).Clone();
            }

            //��ʃf�[�^�Z�b�g
            ScreenToSAndEGoodsCdChg(ref sAndEGoodsCdChg);

            //�ۑ�����
            int status = this._bLGoodsCodeSetAcs.Write(ref sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        tNedit_BLGoodsCode.Focus();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            "PMSAE09020U",							// �A�Z���u��ID
                            "���i�R�[�h�ϊ��}�X�^",  �@�@                 // �v���O��������
                            "SaveSAndEGoodsCdChg",                       // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�o�^�����Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._bLGoodsCodeSetAcs,				    	// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,			  		// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
            }

            //���i�R�[�h�ϊ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
            SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            // �V�K�o�^��
            if (this.Mode_Label.Text.Equals(UPDATE_MODE))
            {
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            result = true;
            return result;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///���i�R�[�h�ϊ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// </remarks>
        private void SAndEGoodsCdSetToDataSet(SAndEGoodsCdChg sAndEGoodsCdChg, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (sAndEGoodsCdChg.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = sAndEGoodsCdChg.UpdateDateTimeJpInFormal;
            }

            // BL����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODS_CODE_TITLE] = sAndEGoodsCdChg.BLGoodsCode.ToString().PadLeft(5, '0');

            //BL���ޖ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BLGOODS_NAME_TITLE] = sAndEGoodsCdChg.BLGoodsHalfName;

            //���i����
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODSCODE_TITLE] = sAndEGoodsCdChg.ABGoodsCode;// DEL zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODSCODE_TITLE] = sAndEGoodsCdChg.ABGoodsCode.PadLeft(8, '0');// ADD zhuhh 2012/12/07 �`�a���i�R�[�h�̌����̉��C
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sAndEGoodsCdChg.FileHeaderGuid;

            if (this._bLGoodsCodeSetTable.ContainsKey(sAndEGoodsCdChg.FileHeaderGuid) == true)
            {
                this._bLGoodsCodeSetTable.Remove(sAndEGoodsCdChg.FileHeaderGuid);
            }
            this._bLGoodsCodeSetTable.Add(sAndEGoodsCdChg.FileHeaderGuid, sAndEGoodsCdChg);
        }

        /// <summary>
        /// ����f�[�^�̃��b�Z�[�W
        /// </summary>
        /// <param name="status">�X�f�[�^�X</param>
        /// <param name="control">�R���g���[��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���ɏ��i�R�[�h�ϊ��}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/08/05</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "PMSAE09020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^�����ɑ��݂��Ă��܂��B", 	// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            tNedit_BLGoodsCode.Focus();

            control = tNedit_BLGoodsCode;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date	   : 2009.08.05</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMSAE09020U",							// �A�Z���u��ID
                    "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load �C�x���g(PMSAE09020UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing �C�x���g(PMSAE09020U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSAE09020U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void PMSAE09020U_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }
            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            ScreenClear();

            Timer.Enabled = true;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕۑ������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!SaveSAndEGoodsCdChg())
            {
                return;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SAndEGoodsCdChg compareSAndEGoodsCdChg = new SAndEGoodsCdChg();

                compareSAndEGoodsCdChg = this._sAndEGoodsCdChgClone.Clone();
                ScreenToSAndEGoodsCdChg(ref compareSAndEGoodsCdChg);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._sAndEGoodsCdChgClone.Equals(compareSAndEGoodsCdChg))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        "PMSAE09020U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSAndEGoodsCdChg())
                                {
                                    return;
                                }
                                return;
                            }

                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }

                        default:
                            {
                                this.Cancel_Button.Focus();
                                return;
                            }
                    }

                }

            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.08.06</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : BL�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.DataText = blGoodsCdUMnt.BLGoodsCode.ToString();
                    this.tEdit_BLGoodsHalfName.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    // �ݒ�l��ۑ�
                    this._tmpBLCode = blGoodsCdUMnt.BLGoodsCode.ToString().Trim();

                    if (this.ModeChangeProc())
                    {
                        this.tEdit_ABGoodsCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʊ��S�폜�����Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                "PMSAE09020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SAndEGoodsCdChg sAndEGoodsCdChg = (SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid];

            //���i�R�[�h�ϊ��_���폜����
            int status = this._bLGoodsCodeSetAcs.Delete(sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._bLGoodsCodeSetTable.Remove(sAndEGoodsCdChg.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMSAE09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���S�폜�������s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._bLGoodsCodeSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕ��������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // ���������m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION, // �G���[���x��
                "PMSAE09020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̃I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SAndEGoodsCdChg sAndEGoodsCdChg = ((SAndEGoodsCdChg)this._bLGoodsCodeSetTable[guid]).Clone();

            // ����
            status = this._bLGoodsCodeSetAcs.Revival(ref sAndEGoodsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        SAndEGoodsCdSetToDataSet(sAndEGoodsCdChg, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            "PMSAE09020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revival",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���������Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._bLGoodsCodeSetAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Renewal_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ŐV���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.LoadBLGoodsCdUMnt();
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", "�ŐV�����擾���܂����B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            this.flag = true;

            switch (e.PrevCtrl.Name)
            {
                // BL�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tNedit_BLGoodsCode.DataText.Trim()))
                        {
                            _tmpBLCode = string.Empty;
                            this.tEdit_BLGoodsHalfName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_BLGoodsCode.DataText.Trim().Equals(_tmpBLCode))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.tEdit_ABGoodsCode;

                            break;

                        }
                        else
                        {
                            // BL�R�[�h�擾
                            int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                            if (!string.IsNullOrEmpty(GetBLGoodsName(blGoodsCode)))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tNedit_BLGoodsCode.Text = blGoodsCode.ToString();
                                this.tEdit_BLGoodsHalfName.DataText = GetBLGoodsName(blGoodsCode);

                                // �ݒ�l��ۑ�
                                this._tmpBLCode = blGoodsCode.ToString();
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_BLGoodsCode.Text = this._tmpBLCode;

                                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO,     // �G���[���x��
                                    "PMSAE09020U",							// �A�Z���u��ID
                                    "BL���ނ����݂��܂���B",	    // �\�����郁�b�Z�[�W
                                    0,									    // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��

                                e.NextCtrl = this.tNedit_BLGoodsCode;

                                this.flag = false;
                                return;
                            }

                            if (ModeChangeProc())
                            {
                                if (e.ShiftKey == false)
                                {
                                    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                                    {
                                        // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                        e.NextCtrl = this.tEdit_ABGoodsCode;
                                    }
                                }
                                // [Shift+Tab]
                                else if (e.ShiftKey == true)
                                {
                                    if (e.Key == Keys.Tab)
                                    {
                                        // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                }

                            }
                            else
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_BLGoodsCode;
                            }

                            break;
                        }
                    }
            }
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// BL�R�[�h�̑��݃`�F�b�N����
        /// </summary>
        /// <returns>���݂̔��f</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�̑��݃`�F�b�N�������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            string str2 = this.tNedit_BLGoodsCode.Text.TrimEnd(new char[0]).PadLeft(5, '0');
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string str3 = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_BLGOODS_CODE_TITLE];
                if (str2.Equals(str3.TrimEnd(new char[0])))
                {
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", "���͂��ꂽ�R�[�h�̃I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                        this.tNedit_BLGoodsCode.Clear();
                        this.tEdit_BLGoodsHalfName.Clear();
                        _tmpBLCode = string.Empty;
                        return false;
                    }

                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09020U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tNedit_BLGoodsCode.Clear();
                            this.tEdit_BLGoodsHalfName.Clear();
                            _tmpBLCode = string.Empty;
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        #endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        public static bool CheckOnline()
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
        private static bool CheckRemoteOn()
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
    }
}