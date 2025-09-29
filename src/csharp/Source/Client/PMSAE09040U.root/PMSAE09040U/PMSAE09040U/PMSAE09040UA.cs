//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���c�`�[
// �� �� ��  2020/02/20  �C�����e : �V�K�쐬
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
    /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
    /// <br>Programmer	: ���c�`�[</br>
    /// <br>Date		: 2020.02.20</br>
    /// </remarks>
    public partial class PMSAE09040UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {

        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        public PMSAE09040UA()
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

            // �ϐ�������
            this._dataIndex = -1;
            this._makerGoodsCodeSetAcs = new MakerGoodsCodeSetAcs();
            this._totalCount = 0;
            this._goodsMakerCdSetTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // �e��}�X�^�Ǎ�
            LoadMasterUMnt();
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
        private MakerGoodsCodeSetAcs _makerGoodsCodeSetAcs;

        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _goodsMakerCdSetTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private SAndEMkrGdsCdChg _sAndEMkrGdsCdChgClone;

        // ���[�J�[�f�[�^�N���X
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        // ���[�J�[�e�[�u���A�N�Z�X�N���X
        MakerAcs _makerAcs = new MakerAcs();

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
        private const string VIEW_GOODSMAKER_CODE_TITLE = "���[�J�[�R�[�h";
        private const string VIEW_GOODSMAKER_NAME_TITLE = "���[�J�[��";
        private const string VIEW_GOODSNO_TITLE = "�i��";
        private const string VIEW_ABGOODSCODE_TITLE = "���i����";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // ���o�����O����͒l(�X�V�L���`�F�b�N�p)
        private string _tmpGoodsMakerCode;
        private string _tmpGoodsNo;

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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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
            ArrayList goodsMakerList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._goodsMakerCdSetTable.Clear();

            // �S����
            status = this._makerGoodsCodeSetAcs.SearchAll(out goodsMakerList, this._enterpriseCode);

            //������
            this._totalCount = goodsMakerList.Count;

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        int index = 0;

                        foreach (SAndEMkrGdsCdChg sAndEGoodsCdSet in goodsMakerList)
                        {
                            SAndEMakerGoodsCdSetToDataSet(sAndEGoodsCdSet.Clone(), index);
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
                            "PMSAE09040U",							// �A�Z���u��ID
                            "���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^", // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._makerGoodsCodeSetAcs,				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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
            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = (SAndEMkrGdsCdChg)this._goodsMakerCdSetTable[guid];

            int status;

            // ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���_���폜����
            status = this._makerGoodsCodeSetAcs.LogicalDelete(ref sAndEMkrGdsCdChg);

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
                            "PMSAE09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�폜�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._makerGoodsCodeSetAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���N���X�f�[�^�Z�b�g�W�J����
            SAndEMakerGoodsCdSetToDataSet(sAndEMkrGdsCdChg.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(VIEW_GOODSMAKER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSMAKER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_GOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ABGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SAndEMkrGdsCdChg sAndEMkrGdsCdChg = new SAndEMkrGdsCdChg();
                //�N���[���쐬
                this._sAndEMkrGdsCdChgClone = sAndEMkrGdsCdChg.Clone();

                this._indexBuf = this._dataIndex;

                this._tmpGoodsMakerCode = string.Empty;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSAndEMkrGdsCdChg(ref this._sAndEMkrGdsCdChgClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tNedit_GoodsMakerCd.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SAndEMkrGdsCdChg sAndEMkrGdsCdChgSet = (SAndEMkrGdsCdChg)this._goodsMakerCdSetTable[guid];

                if (sAndEMkrGdsCdChgSet.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_ABGoodsCode.Focus();

                    // ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���N���X��ʓW�J����
                    SAndEMkrGdsCdChgToScreen(sAndEMkrGdsCdChgSet);

                    // �N���[���쐬
                    this._sAndEMkrGdsCdChgClone = sAndEMkrGdsCdChgSet.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSAndEMkrGdsCdChg(ref this._sAndEMkrGdsCdChgClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();

                    // ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���N���X��ʓW�J����
                    SAndEMkrGdsCdChgToScreen(sAndEMkrGdsCdChgSet);
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
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
                    this.tEdit_MakerName.Enabled = false;

                    if (mode == INSERT_MODE)
                    {
                        // �V�K���[�h
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.GoodsMakerGuide_Button.Enabled = true;
                        this.tEdit_GoodsNo.Enabled = true;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }
                    else
                    {
                        // �X�V���[�h
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerGuide_Button.Enabled = false;
                        this.tEdit_GoodsNo.Enabled = false;
                        this.tEdit_ABGoodsCode.Enabled = true;
                    }

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.tNedit_GoodsMakerCd.Enabled = false;
                    this.GoodsMakerGuide_Button.Enabled = false;
                    this.tEdit_MakerName.Enabled = false;
                    this.tEdit_GoodsNo.Enabled = false;
                    this.tEdit_ABGoodsCode.Enabled = false;
                    break;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ�񃁁[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X�i�[����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private void ScreenToSAndEMkrGdsCdChg(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            if (sAndEMkrGdsCdChg == null)
            {
                // �V�K�̏ꍇ
                sAndEMkrGdsCdChg = new SAndEMkrGdsCdChg();
            }

            //��ƃR�[�h
            sAndEMkrGdsCdChg.EnterpriseCode = this._enterpriseCode;
            //���[�J�[
            sAndEMkrGdsCdChg.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            //�i��
            sAndEMkrGdsCdChg.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            //���i����
            sAndEMkrGdsCdChg.ABGoodsCode = this.tEdit_ABGoodsCode.Text.PadLeft(8, '0');
            //���[�J�[��
            sAndEMkrGdsCdChg.MakerName = this.tEdit_MakerName.DataText;
        }

        /// <summary>
        /// �}�X�^�Ǎ�����
        /// </summary>
        private void LoadMasterUMnt()
        {
            // ���[�J�[�}�X�^���擾
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable allDefSetTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_CODE_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSMAKER_NAME_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_GOODSNO_TITLE, typeof(string));
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tEdit_MakerName.DataText = "";
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_ABGoodsCode.DataText = "";
            this._tmpGoodsMakerCode = string.Empty;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private void SAndEMkrGdsCdChgToScreen(SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            // ���[�J�[
            this.tNedit_GoodsMakerCd.Text = sAndEMkrGdsCdChg.GoodsMakerCd.ToString().PadLeft(4, '0');
            // ���[�J�[��
            this.tEdit_MakerName.Text = sAndEMkrGdsCdChg.MakerName.Trim();
            // �i��
            this.tEdit_GoodsNo.DataText = sAndEMkrGdsCdChg.GoodsNo.Trim();
            // ���i����
            this.tEdit_ABGoodsCode.DataText = sAndEMkrGdsCdChg.ABGoodsCode.PadLeft(8, '0');
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private int CheckDisplay(ref string checkMessage)
        {
            int returnStatus = 0;

            try
            {
                // ���[�J�[
                if (this.tNedit_GoodsMakerCd.DataText.Trim() == "")
                {
                    checkMessage = "Ұ�����ނ�ݒ肵�ĉ������B";
                    returnStatus = 10;
                    return returnStatus;
                }

                // �i��
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    checkMessage = "�i�Ԃ�ݒ肵�ĉ������B";
                    returnStatus = 20;
                    return returnStatus;
                }

                // ���i����
                if (this.tEdit_ABGoodsCode.DataText.Trim() == "")
                {
                    checkMessage = "���i���ނ�ݒ肵�ĉ������B";
                    returnStatus = 30;
                    return returnStatus;
                }

                string reg = "^[0-9]*$";
                Regex regex = new Regex(reg);
                if (!regex.IsMatch(this.tEdit_ABGoodsCode.DataText.Trim()))
                {
                    checkMessage = "���i���ނ̐ݒ肪�s���ł��B";
                    returnStatus = 30;
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
                        "PMSAE09040U",							// �A�Z���u��ID
                        checkMessage,	                        // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                }

                //�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
                switch (returnStatus)
                {
                    case 10:
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                            break;
                        }
                    case 20:
                        {
                            this.tEdit_GoodsNo.Focus();
                            break;
                        }
                    case 30:
                        {
                            this.tEdit_ABGoodsCode.Focus();
                            break;
                        }
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@�ۑ�����(SaveSAndEMkrGdsCdChg())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private bool SaveSAndEMkrGdsCdChg()
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

            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                sAndEMkrGdsCdChg = ((SAndEMkrGdsCdChg)this._goodsMakerCdSetTable[guid]).Clone();
            }

            //��ʃf�[�^�Z�b�g
            ScreenToSAndEMkrGdsCdChg(ref sAndEMkrGdsCdChg);

            //�ۑ�����
            int status = this._makerGoodsCodeSetAcs.Write(ref sAndEMkrGdsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.ScreenClear();
                        tNedit_GoodsMakerCd.Focus();
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
                            "PMSAE09040U",							// �A�Z���u��ID
                            "���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^", // �v���O��������
                            "SaveSAndEMkrGdsCdChg",                   // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�o�^�����Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._makerGoodsCodeSetAcs,				// �G���[�����������I�u�W�F�N�g
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

            //���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
            SAndEMakerGoodsCdSetToDataSet(sAndEMkrGdsCdChg, this.DataIndex);

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
        ///���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private void SAndEMakerGoodsCdSetToDataSet(SAndEMkrGdsCdChg sAndEMkrGdsCdChg, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (sAndEMkrGdsCdChg.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = sAndEMkrGdsCdChg.UpdateDateTimeJpInFormal;
            }

            //���[�J�[
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_CODE_TITLE] = sAndEMkrGdsCdChg.GoodsMakerCd.ToString().PadLeft(4, '0');

            //���[�J�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSMAKER_NAME_TITLE] = sAndEMkrGdsCdChg.MakerName;

            //�i��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODSNO_TITLE] = sAndEMkrGdsCdChg.GoodsNo.Trim();

            //���i����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ABGOODSCODE_TITLE] = sAndEMkrGdsCdChg.ABGoodsCode.PadLeft(8, '0');

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = sAndEMkrGdsCdChg.FileHeaderGuid;

            if (this._goodsMakerCdSetTable.ContainsKey(sAndEMkrGdsCdChg.FileHeaderGuid) == true)
            {
                this._goodsMakerCdSetTable.Remove(sAndEMkrGdsCdChg.FileHeaderGuid);
            }
            this._goodsMakerCdSetTable.Add(sAndEMkrGdsCdChg.FileHeaderGuid, sAndEMkrGdsCdChg);
        }

        /// <summary>
        /// ����f�[�^�̃��b�Z�[�W
        /// </summary>
        /// <param name="status">�X�f�[�^�X</param>
        /// <param name="control">�R���g���[��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ƀ��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�ɓ���f�[�^����ꍇ�A���b�Z�[�W������B</br>
        /// <br>Programmer  : ���c�`�[</br>
        /// <br>Date        : 2009/08/05</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "PMSAE09040U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^�����ɑ��݂��Ă��܂��B", 	// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            tNedit_GoodsMakerCd.Focus();

            control = tNedit_GoodsMakerCd;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date	   : 2020.02.20</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    "PMSAE09040U",							// �A�Z���u��ID
                    "���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
        }

        #endregion

        # region -- Control Events --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Load �C�x���g(PMSAE09040UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void PMSAE09040U_Load(object sender, EventArgs e)
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

            this.GoodsMakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///	Form.Closing �C�x���g(PMSAE09040U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void PMSAE09040U_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged �C�x���g(PMSAE09040U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void PMSAE09040U_VisibleChanged(object sender, EventArgs e)
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
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

            if (!SaveSAndEMkrGdsCdChg())
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SAndEMkrGdsCdChg compareSAndEMkrGdsCdChg = new SAndEMkrGdsCdChg();

                compareSAndEMkrGdsCdChg = this._sAndEMkrGdsCdChgClone.Clone();
                ScreenToSAndEMkrGdsCdChg(ref compareSAndEMkrGdsCdChg);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._sAndEMkrGdsCdChgClone.Equals(compareSAndEMkrGdsCdChg))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        "PMSAE09040U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveSAndEMkrGdsCdChg())
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
        /// <br>Programmer	: ���c�`�[</br>
        /// <br>Date		: 2020.02.20</br>
        /// </remarks>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(GoodsMakerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���i���[�J�[�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private void GoodsMakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���i���[�J�[�R�[�h�K�C�h�\��
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    this.tNedit_GoodsMakerCd.DataText = makerUMnt.GoodsMakerCd.ToString();
                    this.tEdit_MakerName.DataText = makerUMnt.MakerName.Trim();
                    // �ݒ�l��ۑ�
                    this._tmpGoodsMakerCode = makerUMnt.GoodsMakerCd.ToString().Trim();

                    if (this.ModeChangeProc())
                    {
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        this.tNedit_GoodsMakerCd.Focus();
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
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
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                "PMSAE09040U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = (SAndEMkrGdsCdChg)this._goodsMakerCdSetTable[guid];

            //���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�_���폜����
            int status = this._makerGoodsCodeSetAcs.Delete(sAndEMkrGdsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._goodsMakerCdSetTable.Remove(sAndEMkrGdsCdChg.FileHeaderGuid);

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
                            "PMSAE09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "���[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���S�폜�������s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._makerGoodsCodeSetAcs, 			// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
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
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                "PMSAE09040U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̃��[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�𕜊����܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Revive_Button.Focus();
                return;
            }

            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = ((SAndEMkrGdsCdChg)this._goodsMakerCdSetTable[guid]).Clone();

            // ����
            status = this._makerGoodsCodeSetAcs.Revival(ref sAndEMkrGdsCdChg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        SAndEMakerGoodsCdSetToDataSet(sAndEMkrGdsCdChg, this._dataIndex);
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
                            "PMSAE09040U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revival",				            // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "���[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���������Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._makerGoodsCodeSetAcs,			// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.LoadMasterUMnt();
            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09040U", "�ŐV�����擾���܂����B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
                #region ���[�J�[
                case "tNedit_GoodsMakerCd":
                    {
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.DataText.Trim()))
                        {
                            _tmpGoodsMakerCode = string.Empty;
                            this.tEdit_MakerName.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMakerCd.DataText.Trim().Equals(_tmpGoodsMakerCode))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.tEdit_GoodsNo;

                            break;

                        }
                        else
                        {
                            // ���[�J�[�R�[�h�擾
                            int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

                            if (!string.IsNullOrEmpty(GetGoodsMakerName(goodsMakerCd)))
                            {
                                // ���ʂ���ʂɐݒ�
                                this.tNedit_GoodsMakerCd.Text = goodsMakerCd.ToString();
                                this.tEdit_MakerName.DataText = GetGoodsMakerName(goodsMakerCd);

                                // �ݒ�l��ۑ�
                                this._tmpGoodsMakerCode = goodsMakerCd.ToString();
                            }
                            else
                            {
                                // �O����͒l��ݒ�
                                this.tNedit_GoodsMakerCd.Text = this._tmpGoodsMakerCode;

                                TMsgDisp.Show(this,                  // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_INFO,     // �G���[���x��
                                    "PMSAE09040U",					 // �A�Z���u��ID
                                    "Ұ�����ނ����݂��܂���B",	     // �\�����郁�b�Z�[�W
                                    0,								 // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);			 // �\������{�^��

                                e.NextCtrl = this.tNedit_GoodsMakerCd;

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
                                        e.NextCtrl = this.tEdit_GoodsNo;
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
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }

                            break;
                        }
                    }
                #endregion ���[�J�[

                #region �i��
                case "tEdit_GoodsNo":
                    {
                        // ���͂Ȃ�
                        if (string.IsNullOrEmpty(this.tEdit_GoodsNo.DataText.Trim()))
                        {
                            _tmpGoodsNo = string.Empty;
                            this.tEdit_GoodsNo.DataText = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_GoodsNo.DataText.Trim().Equals(_tmpGoodsNo) &&
                            this.tEdit_ABGoodsCode.DataText.Trim().Equals(_tmpGoodsMakerCode))
                        {
                            break;
                        }
                        else
                        {
                            // ���[�J�[�A�i�ԂƂ��ɓ��͂���
                            if (this.tNedit_GoodsMakerCd.DataText.Trim() != "" &&
                                this.tEdit_GoodsNo.DataText.Trim() != "")
                            {
                                if (this.ModeChangeProc())
                                {
                                    e.NextCtrl = this.tEdit_ABGoodsCode;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                        }
                        break;
                    }
                #endregion �i��
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// ���[�J�[�R�[�h���̎擾����
        /// </summary>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <returns>���[�J�[�J�i����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�J�i���̂��擾���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private string GetGoodsMakerName(int goodsMakerCd)
        {
            string goodsMakerName = "";

            try
            {
                if (this._makerUMntDic.ContainsKey(goodsMakerCd))
                {
                    goodsMakerName = this._makerUMntDic[goodsMakerCd].MakerName.Trim();
                }
            }
            catch
            {
                goodsMakerName = "";
            }

            return goodsMakerName;
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h�E���i�ԍ��̑��݃`�F�b�N����
        /// </summary>
        /// <returns>���݂̔��f</returns>
        /// <remarks>
        /// <br>Note       : ���i���[�J�[�R�[�h�E���i�ԍ��̑��݃`�F�b�N�������܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            string iMsg = "���͂��ꂽ�R�[�h�̃��[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";
            string str2 = this.tNedit_GoodsMakerCd.Text.TrimEnd(new char[0]).PadLeft(4, '0');
            string inpGoodsNo = this.tEdit_GoodsNo.Text.Trim();
            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string str3 = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_GOODSMAKER_CODE_TITLE];
                string viewGoodsNo = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_GOODSNO_TITLE];
                if (str2.Equals(str3.TrimEnd(new char[0])) && inpGoodsNo.Equals(viewGoodsNo))
                {
                    if (((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE]) != "")
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09040U", "���͂��ꂽ�R�[�h�̃��[�J�[�E�i�ԃI�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^���͊��ɍ폜����Ă��܂��B", 0, MessageBoxButtons.OK);
                        this.tNedit_GoodsMakerCd.Clear();
                        this.tEdit_MakerName.Clear();
                        this.tEdit_GoodsNo.Clear();
                        _tmpGoodsMakerCode = string.Empty;
                        _tmpGoodsNo = string.Empty;
                        return false;
                    }

                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, "PMSAE09040U", iMsg, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this._dataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            return true;

                        case DialogResult.No:
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tEdit_MakerName.Clear();
                            this.tEdit_GoodsNo.Clear();
                            _tmpGoodsMakerCode = string.Empty;
                            _tmpGoodsNo = string.Empty;
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