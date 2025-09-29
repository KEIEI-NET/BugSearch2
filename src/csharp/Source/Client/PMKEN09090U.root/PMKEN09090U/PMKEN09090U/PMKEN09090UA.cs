using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i��֐ݒ�i���[�U�[�o�^�j�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̐ݒ���s���܂��B</br>
    /// <br>Programmer  : 30413 ����</br>
    /// <br>Date        : 2008.07.25</br>
    /// <br>UpdateNote   : 2008/10/10 30462 �s�V �m���@�o�O�C��</br>
    /// <br>Update Note : 2009/03/16 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12342</br>
    /// </remarks>
    public partial class PMKEN09090UA : Form, IMasterMaintenanceMultiType
    {
        // --------------------------------------------------
        #region Constructor
        /// <summary>
        /// ���i��֐ݒ�i���[�U�[�o�^�j�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public PMKEN09090UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._sectionCode = this._loginEmployee.BelongSectionCode.Trim();
            }

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l
            this._canPrint = false;                         // ����@�\
            this._canClose = false;							// ����@�\(false�Œ�)
            this._canNew = true;                            // �V�K�쐬�@�\
            this._canDelete = true;							// �폜�@�\
            this._canLogicalDeleteDataExtraction = true;    // �_���폜�f�[�^�\���@�\
            this._defaultAutoFillToColumn = false;          // ��T�C�Y���������@�\
            this._canSpecificationSearch = false;           // �����w�茟���@�\

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            this._partsSubstUAcs = new PartsSubstUAcs();
            this._makerAcs = new MakerAcs();
            this._partsSubstUTable = new Hashtable();

            // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� >>>>>>START
            string message;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._sectionCode, out message);
            // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� <<<<<<END
        }

        #endregion

        // --------------------------------------------------
        #region Private Members

        private int _totalCount;
        private string _enterpriseCode = "";           // ��ƃR�[�h
        private Hashtable _partsSubstUTable;

        private PartsSubstUAcs _partsSubstUAcs = null;
        private MakerAcs _makerAcs = null;

        // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� >>>>>>START
        private GoodsAcs _goodsAcs = null;
        // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� <<<<<<END
            
        //��r�pclone
        private PartsSubstU _partsSubstUClone = null;

        // ���[�N�f�[�^�֘A
        private int _chgSrcMakerCdWork = 0;			// ��֌����[�J�[�R�[�h�i���[�N�j
        private int _chgDestMakerCdWork = 0;		// ��֐惁�[�J�[�R�[�h�i���[�N�j
        private string _chgSrcGoodsNoWork = "";		// ��֌��i�ԁi���[�N�j
        private string _chgDestGoodsNoWork = "";	// ��֐�i�ԁi���[�N�j

        // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _dataIndex;
        private int _indexBuf;

        // ���_�R�[�h
        private string _sectionCode;

        // ���O�C���]�ƈ�
        private Employee _loginEmployee = null;

        // �v���p�e�B�p
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string CHGSRCMAKERCD_TITLE = "��֌����[�J�[�R�[�h";
        private const string CHGSRCMAKERNM_TITLE = "��֌����[�J�[��";
        private const string CHGSRCGOODSNO_TITLE = "��֌��i��";
        private const string CHGDESTMAKERCD_TITLE = "��֐惁�[�J�[�R�[�h";
        private const string CHGDESTMAKERNM_TITLE = "��֐惁�[�J�[��";
        private const string CHGDESTGOODSNO_TITLE = "��֐�i��";
        private const string APPLYSTADATE_TITLE = "�K�p�J�n��";
        private const string APPLYENDDATE_TITLE = "�K�p�I����";
        
        private const string GUID_TITLE = "GUID";

        // �e�[�u������
        private const string PARTSSUBSTU_TABLE = "PARTSSUBSTU_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string REFERENCE_MODE = "�Q�ƃ��[�h";

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMKEN09090U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂��B";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂��B";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂��B";
        private const string CONF_DEL_MSG = "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H";

        #endregion

        #region enum
        /// <summary>
        /// ���̓G���[�`�F�b�N�X�e�[�^�X
        /// </summary>
        private enum InputChkStatus
        {
            // ������
            NotInput = -1,
            // ���݂��Ȃ�
            NotExist = -2,
            // ���̓~�X
            InputErr = -3,
            // ����
            Normal = 0,
            // �L�����Z��
            Cancel = 1
        }

        /// <summary>
        /// ��ʃf�[�^�ݒ�X�e�[�^�X
        /// </summary>
        private enum DispSetStatus
        {
            // �N���A
            Clear = 0,
            // �X�V
            Update = 1,
            // ���ɖ߂�
            Back = 2
        }
        #endregion enum

        // --------------------------------------------------
        #region Events

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        #endregion

        // --------------------------------------------------
        #region Properties
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

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>������\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

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

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }
        #endregion

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u����</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PARTSSUBSTU_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�̌������s�����o���ʂ�DataSet�Ɋi�[���A�Y��������Ԃ��܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList partsSubstUretList = null;

            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            status = this._partsSubstUAcs.SearchAll(out partsSubstUretList, this._enterpriseCode);

            this._totalCount = partsSubstUretList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (PartsSubstU partsSubstU in partsSubstUretList)
                        {
                            // �n�b�V���L�[�擾
                            string hashKey = CreateHashKey(partsSubstU);

                            if (this._partsSubstUTable.ContainsKey(hashKey) == false)
                            {
                                PartsSubstUToDataSet(partsSubstU.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:      // ��������0��
                    {
                        // ��������0���́A�X�e�[�^�X���m�[�}���ŕԂ�
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        // �T�[�`
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            ASSEMBLY_ID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Search",                           // ��������
                            TMsgDisp.OPE_GET,                   // �I�y���[�V����
                            ERR_READ_MSG,                       // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._partsSubstUAcs,              // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);  // �����\���{�^��
                        break;
                    }
            }
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// Next�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : Next�f�[�^�̌����������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Delete()
        {
            // �_���폜
            int status = LogicalDeletePartsSubstU();

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����(������)
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �O���b�h�̊e��̊O�ς�ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ��֌����[�J�[�R�[�h
            appearanceTable.Add(CHGSRCMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ��֌����[�J�[����
            appearanceTable.Add(CHGSRCMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ��֌��i��
            appearanceTable.Add(CHGSRCGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ��֐惁�[�J�[�R�[�h
            appearanceTable.Add(CHGDESTMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // ��֐惁�[�J�[����
            appearanceTable.Add(CHGDESTMAKERNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ��֐�i��
            appearanceTable.Add(CHGDESTGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �K�p�J�n��
            appearanceTable.Add(APPLYSTADATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �K�p�I����
            appearanceTable.Add(APPLYENDDATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// ���i��֐ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PartsSubstUToDataSet(PartsSubstU partsSubstU, int index)
        {
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            if ((index < 0) || (this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].NewRow();
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (partsSubstU.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][DELETE_DATE] = partsSubstU.UpdateDateTimeJpInFormal;
            }

            // ��֌����[�J�[�R�[�h
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCMAKERCD_TITLE] = partsSubstU.ChgSrcMakerCd;

            // ��֌����[�J�[����
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCMAKERNM_TITLE] = this._partsSubstUAcs.GetMakerName(partsSubstU.ChgSrcMakerCd);
            
            // ��֌��i��
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGSRCGOODSNO_TITLE] = partsSubstU.ChgSrcGoodsNo;

            // ��֐惁�[�J�[�R�[�h
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTMAKERCD_TITLE] = partsSubstU.ChgDestMakerCd;

            // ��֐惁�[�J�[����
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTMAKERNM_TITLE] = this._partsSubstUAcs.GetMakerName(partsSubstU.ChgDestMakerCd);
            
            // ��֐�i��
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][CHGDESTGOODSNO_TITLE] = partsSubstU.ChgDestGoodsNo;

            //--------------------
            // �K�p�J�n���`�F�b�N
            //--------------------
            // �����ݒ�
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(partsSubstU.ApplyStaDate.Year);
            inParamList.Add(partsSubstU.ApplyStaDate.Month);
            inParamList.Add(partsSubstU.ApplyStaDate.Day);
            inParamObj = inParamList;

            // �K�p�J�n��������̏ꍇ�̂ݐݒ�
            if (CheckDetApplyDate(inParamObj, out outParamObj) == 0)
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYSTADATE_TITLE] = partsSubstU.ApplyStaDate;
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYSTADATE_TITLE] = DBNull.Value;
            }

            //--------------------
            // �K�p�I�����`�F�b�N
            //--------------------
            // �����ݒ�
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(partsSubstU.ApplyEndDate.Year);
            inParamList.Add(partsSubstU.ApplyEndDate.Month);
            inParamList.Add(partsSubstU.ApplyEndDate.Day);
            inParamObj = inParamList;

            // �K�p�I����������̏ꍇ�̂ݐݒ�
            if (CheckDetApplyDate(inParamObj, out outParamObj) == 0)
            {
                if ((partsSubstU.ApplyEndDate == DateTime.Parse("9999/12/31")) ||
                    (partsSubstU.ApplyEndDate == DateTime.MaxValue))
                {
                    // �K�p�I������MaxValue�̏ꍇ�͋�
                    this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = DBNull.Value;
                }
                else
                {
                    // ��L�ȊO�̏ꍇ�͕��i��֐ݒ�̒l��ݒ�
                    this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = partsSubstU.ApplyEndDate;
                }
            }
            else
            {
                this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][APPLYENDDATE_TITLE] = DBNull.Value;
            }

            // �n�b�V���L�[�擾
            string hashKey = CreateHashKey(partsSubstU);

            // �L�[�ݒ�
            this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[index][GUID_TITLE] = hashKey;

            if (this._partsSubstUTable.ContainsKey(hashKey))
            {
                this._partsSubstUTable.Remove(hashKey);
            }
            this._partsSubstUTable.Add(hashKey, partsSubstU);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                   �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable goodschangeUTable = new DataTable(PARTSSUBSTU_TABLE);

            // 2009.02.16 30413 ���� �i�ԁ����[�J�[���ɕύX-----
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            goodschangeUTable.Columns.Add(DELETE_DATE, typeof(string));	// �폜��
            goodschangeUTable.Columns.Add(CHGSRCGOODSNO_TITLE, typeof(string));	    // ��֌��i��
            goodschangeUTable.Columns.Add(CHGSRCMAKERCD_TITLE, typeof(Int32));		// ��֌����[�J�[�R�[�h
            goodschangeUTable.Columns.Add(CHGSRCMAKERNM_TITLE, typeof(string));		// ��֌����[�J�[��
            goodschangeUTable.Columns.Add(CHGDESTGOODSNO_TITLE, typeof(string));	// ��֐�i��
            goodschangeUTable.Columns.Add(CHGDESTMAKERCD_TITLE, typeof(Int32));		// ��֐惁�[�J�[�R�[�h
            goodschangeUTable.Columns.Add(CHGDESTMAKERNM_TITLE, typeof(string));	// ��֐惁�[�J�[��
            goodschangeUTable.Columns.Add(APPLYSTADATE_TITLE, typeof(DateTime));	// �K�p�J�n��
            goodschangeUTable.Columns.Add(APPLYENDDATE_TITLE, typeof(DateTime));	// �K�p�I����
            goodschangeUTable.Columns.Add(GUID_TITLE, typeof(string));	// GUID

            this.Bind_DataSet.Tables.Add(goodschangeUTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̃N���A���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Delete_Button.Visible = true;		// ���S�폜�{�^��
            this.Revive_Button.Visible = true;		// �����{�^��
            this.Ok_Button.Visible = true;			// �ۑ��{�^��
            this.Cancel_Button.Visible = true;		// ����{�^��

            // ����
            this.ChgSrcMakerCd_tNedit.Clear();		// ��֌����[�J�[�R�[�h
            this.ChgSrcMakerCdNm_tEdit.Clear();		// ��֌����[�J�[��
            this.ChgSrcGoodsNo_tEdit.Clear();		// ��֌��i��
            this.ChgSrcGoodsNoNm_tEdit.Clear();     // ��֌����i��
            
            this.ChgDestMakerCd_tNedit.Clear();		// ��֐惁�[�J�[�R�[�h
            this.ChgDestMakerCdNm_tEdit.Clear();	// ��֐惁�[�J�[��
            this.ChgDestGoodsNo_tEdit.Clear();		// ��֐�i��
            this.ChgDestGoodsNoNm_tEdit.Clear();	// ��֐揤�i��		

            this.detApplyStaDate.Clear();			// �K�p�J�n��
            this.detApplyEndDate.Clear();			// �K�p�I����
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̍č\�z�������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // �V�K�̎�
            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                //------------
                // �����l�ݒ�
                //------------
                // �K�p�J�n�������l�ݒ�i���ݓ��t�j
                this.detApplyStaDate.SetDateTime(DateTime.Today);

                PartsSubstU partsSubstU = new PartsSubstU();

                //�N���[���쐬
                this._partsSubstUClone = partsSubstU.Clone();
                DispToPartsSubstU(ref this._partsSubstUClone);

                // 2009.02.16 30413 ���� �����t�H�[�J�X���֌��i�ԂɕύX-----
                // �t�H�[�J�X�ݒ�
                //this.ChgSrcMakerCd_tNedit.Focus();
                this.ChgSrcGoodsNo_tEdit.Focus();

                // ADD 2008/10/10 �s��Ή�[6525] ---------->>>>>
                //�O��l�N���A
                this._chgSrcMakerCdWork = 0;			// ��֌����[�J�[�R�[�h�i���[�N�j
                this._chgDestMakerCdWork = 0;		// ��֐惁�[�J�[�R�[�h�i���[�N�j
                this._chgSrcGoodsNoWork = "";		// ��֌��i�ԁi���[�N�j
                this._chgDestGoodsNoWork = "";	// ��֐�i�ԁi���[�N�j
                // ADD 2008/10/10 �s��Ή�[6525] ----------<<<<<
            }
            else
            {
                // �n�b�V���L�[�擾
                string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

                if (partsSubstU.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // �{�^���ݒ�
                    this.Ok_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // ��ʓW�J����
                    PartsSubstUToScreen(partsSubstU);

                    //�N���[���쐬
                    this._partsSubstUClone = partsSubstU.Clone();
                    DispToPartsSubstU(ref this._partsSubstUClone);

                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // �t�H�[�J�X�ݒ�
                    this.detApplyStaDate.Focus();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // �{�^���ݒ�
                    this.Ok_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    PartsSubstUToScreen(partsSubstU);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="editingMode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:		// �V�K
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = true;			// ��֌����[�J�[�R�[�h
                        this.ChgSrcMakerGuide_Button.Enabled = true;		// ��֌����[�J�[�K�C�h
                        this.ChgSrcGoodsNo_tEdit.Enabled = true;			// ��֌��i��
                        
                        this.ChgDestMakerCd_tNedit.Enabled = true;			// ��֐惁�[�J�[�R�[�h
                        this.ChgDestMakerGuide_Button.Enabled = true;		// ��֐惁�[�J�[�K�C�h
                        this.ChgDestGoodsNo_tEdit.Enabled = true;			// ��֐�i��
                        
                        this.detApplyStaDate.Enabled = true;				// �K�p�J�n��
                        this.detApplyEndDate.Enabled = true;				// �K�p�I����

                        break;
                    }
                case UPDATE_MODE:		// �X�V
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = false;			// ��֌����[�J�[�R�[�h
                        this.ChgSrcMakerGuide_Button.Enabled = false;		// ��֌����[�J�[�K�C�h
                        this.ChgSrcGoodsNo_tEdit.Enabled = false;			// ��֌��i��
                        
                        this.ChgDestMakerCd_tNedit.Enabled = false;			// ��֐惁�[�J�[�R�[�h
                        this.ChgDestMakerGuide_Button.Enabled = false;		// ��֐惁�[�J�[�K�C�h
                        this.ChgDestGoodsNo_tEdit.Enabled = false;			// ��֐�i��
                        
                        this.detApplyStaDate.Enabled = true;				// �K�p�J�n��
                        this.detApplyEndDate.Enabled = true;				// �K�p�I����

                        break;
                    }
                case DELETE_MODE:		// �폜
                case REFERENCE_MODE:	// �Q��
                    {
                        this.ChgSrcMakerCd_tNedit.Enabled = false;			// ��֌����[�J�[�R�[�h
                        this.ChgSrcMakerGuide_Button.Enabled = false;		// ��֌����[�J�[�K�C�h
                        this.ChgSrcGoodsNo_tEdit.Enabled = false;			// ��֌��i��
                        
                        this.ChgDestMakerCd_tNedit.Enabled = false;			// ��֐惁�[�J�[�R�[�h
                        this.ChgDestMakerGuide_Button.Enabled = false;		// ��֐惁�[�J�[�K�C�h
                        this.ChgDestGoodsNo_tEdit.Enabled = false;			// ��֐�i��
                        
                        this.detApplyStaDate.Enabled = false;				// �K�p�J�n��
                        this.detApplyEndDate.Enabled = false;				// �K�p�I����

                        break;
                    }
            }
        }

        /// <summary>
        /// ���i��֐ݒ�}�X�^�@�N���X��ʓW�J����
        /// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : �}�X�^������ʂɓW�J���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PartsSubstUToScreen(PartsSubstU partsSubstU)
        {
            // ���i���̌����p
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;
            ArrayList outParamList = null;

            this.ChgSrcMakerCd_tNedit.SetInt(partsSubstU.ChgSrcMakerCd);			// ��֌����[�J�[�R�[�h 
            this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();			// ��֌����[�J�[�R�[�h���[�N
            this.ChgSrcMakerCdNm_tEdit.Text =
                this._partsSubstUAcs.GetMakerName(partsSubstU.ChgSrcMakerCd);		// ��֌����[�J�[��

            this.ChgSrcGoodsNo_tEdit.Text = partsSubstU.ChgSrcGoodsNo;				// ��֌��i��
            this._chgSrcGoodsNoWork = this.ChgSrcGoodsNo_tEdit.Text;				// ��֌����i�R�[�h���[�N

            //--------------------
            // ��֌����i���̎擾
            //--------------------
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            // �����ݒ�
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // ���݃`�F�b�N
            if (CheckGoodsNoCd(inParamObj, out outParamObj, false) == 0)
            {
                if ((outParamObj != null) && (outParamObj is ArrayList))
                {
                    outParamList = outParamObj as ArrayList;

                    if ((outParamList != null)
                        && (outParamList.Count == 5)
                        && (outParamList[1] is string)
                        && (outParamList[2] is string)
                        && (outParamList[3] is int)
                        && (outParamList[4] is string))
                    {
                        this.ChgSrcGoodsNoNm_tEdit.Text = (string)outParamList[2];	// ��֌����i����
                    }
                }
            }
            
            this.ChgDestMakerCd_tNedit.SetInt(partsSubstU.ChgDestMakerCd);			// ��֐惁�[�J�[�R�[�h
            this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();			// ��֐惁�[�J�[�R�[�h���[�N
            this.ChgDestMakerCdNm_tEdit.Text =
                this._partsSubstUAcs.GetMakerName(partsSubstU.ChgDestMakerCd);	// ��֐惁�[�J�[��

            this.ChgDestGoodsNo_tEdit.Text = partsSubstU.ChgDestGoodsNo;			// ��֐�i��
            this._chgDestGoodsNoWork = this.ChgDestGoodsNo_tEdit.Text;				// ��֐揤�i�R�[�h���[�N

            //--------------------
            // ��֐揤�i���̎擾
            //--------------------
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            // �����ݒ�
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // ���݃`�F�b�N
            if (CheckGoodsNoCd(inParamObj, out outParamObj, false) == 0)
            {
                if ((outParamObj != null) && (outParamObj is ArrayList))
                {
                    outParamList = outParamObj as ArrayList;

                    if ((outParamList != null)
                        && (outParamList.Count == 5)
                        && (outParamList[1] is string)
                        && (outParamList[2] is string)
                        && (outParamList[3] is int)
                        && (outParamList[4] is string))
                    {
                        this.ChgDestGoodsNoNm_tEdit.Text = (string)outParamList[2];	// ��֐揤�i��
                    }
                }
            }

            this.detApplyStaDate.SetDateTime(partsSubstU.ApplyStaDate);			// �K�p�J�n��
            
            if ((partsSubstU.ApplyEndDate == DateTime.Parse("9999/12/31")) ||
                (partsSubstU.ApplyEndDate == DateTime.MaxValue))
            {
                // �K�p�I������MaxValue�̏ꍇ�͋�
                this.detApplyEndDate.Clear();                                   // �K�p�I����
            }
            else
            {
                // ��L�ȊO�̏ꍇ�͕��i��֐ݒ�̒l��ݒ�
                this.detApplyEndDate.SetDateTime(partsSubstU.ApplyEndDate);     // �K�p�I����
            }
        }

        /// <summary>
        /// ��ʏ�񕔕i��֐ݒ�}�X�^�@�N���X�i�[����
        /// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�}�X�^�@�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂畔�i��֐ݒ�}�X�^�@�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispToPartsSubstU(ref PartsSubstU partsSubstU)
        {
            if (partsSubstU == null)
            {
                // �V�K�̏ꍇ
                partsSubstU = new PartsSubstU();
            }

            partsSubstU.EnterpriseCode = this._enterpriseCode;							// ��ƃR�[�h
            partsSubstU.ChgSrcMakerCd = this.ChgSrcMakerCd_tNedit.GetInt();			    // ��֌����[�J�[�R�[�h
            partsSubstU.ChgSrcGoodsNo = this.ChgSrcGoodsNo_tEdit.Text.TrimEnd();		// ��֌��i��
            partsSubstU.ChgSrcGoodsNoNoneHp = this.ChgSrcGoodsNo_tEdit.Text.TrimEnd().Replace("-", "");     // �n�C�t�����ϊ������i�ԍ�
            partsSubstU.ChgDestMakerCd = this.ChgDestMakerCd_tNedit.GetInt();			// ��֐惁�[�J�[�R�[�h
            partsSubstU.ChgDestGoodsNo = this.ChgDestGoodsNo_tEdit.Text.TrimEnd();		// ��֐�i��
            partsSubstU.ChgDestGoodsNoNoneHp = this.ChgDestGoodsNo_tEdit.Text.TrimEnd().Replace("-", "");   // �n�C�t�����ϊ��揤�i�ԍ�
            partsSubstU.ApplyStaDate = (DateTime)this.detApplyStaDate.GetDateTime();	// �K�p�J�n��
            if (this.detApplyEndDate.GetLongDate() == 0)
            {
                // �����͎��͍ő�l��ݒ�
                partsSubstU.ApplyEndDate = DateTime.MaxValue;                               // �K�p�I����
            }
            else
            {
                partsSubstU.ApplyEndDate = (DateTime)this.detApplyEndDate.GetDateTime();	// �K�p�I����
            }            
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����[true: OK, false: NG]</returns>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>   
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            //bool canChangeFocus = true;	// �����ł͖��g�p
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            // 2009.02.16 30413 ���� �i�ԁ����[�J�[���ɓ��̓`�F�b�N��ύX-----
            //-----------------------------
            // ��֌��i�ԁi�K�{���́j
            //-----------------------------
            // �����ݒ�N���A
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

            // �����ݒ�
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // ���݃`�F�b�N
            switch (CheckGoodsNoCd(inParamObj, out outParamObj, false))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "��֌��i�Ԃ���͂��Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                case (int)InputChkStatus.Cancel:
                    {
                        message = "��֌��i�Ԃ�I�����Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "�w�肳�ꂽ�����ŕi�Ԃ͑��݂��܂���ł����B";
                        dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// �f�[�^�ݒ�
            //DispSetChgSrcGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgSrcGoodsNo_tEdit;
                return false;
            }

            //---------------------------------
            // ��֌����[�J�[�R�[�h�i�K�{���́j
            //---------------------------------
            // �����ݒ�N���A
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

            // �����ݒ�
            inParamObj = this.ChgSrcMakerCd_tNedit.GetInt();

            // ���݃`�F�b�N
            switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "��֌����[�J�[�R�[�h����͂��Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B";
                        dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// �f�[�^�ݒ�
            //DispSetChgSrcMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgSrcMakerCd_tNedit;
                return false;
            }

            //-----------------------------
            // ��֐�i�ԁi�K�{���́j
            //-----------------------------
            // �����ݒ�N���A
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

            // �����ݒ�
            inParamList.Add(this._sectionCode);
            inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt());
            inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text);
            inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
            inParamObj = inParamList;

            // ���݃`�F�b�N
            switch (CheckGoodsNoCd(inParamObj, out outParamObj, false))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "��֐�i�Ԃ���͂��Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                case (int)InputChkStatus.Cancel:
                    {
                        message = "��֐�i�Ԃ�I�����Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "�w�肳�ꂽ�����ŕi�Ԃ͑��݂��܂���ł����B";
                        dispSetStatus = this._chgDestGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// �f�[�^�ݒ�
            //DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgDestGoodsNo_tEdit;
                return false;
            }
            
            //---------------------------------
            // ��֐惁�[�J�[�R�[�h�i�K�{���́j
            //---------------------------------
            // �����ݒ�N���A
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

            // �����ݒ�
            inParamObj = this.ChgDestMakerCd_tNedit.GetInt();

            // ���݃`�F�b�N
            switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        dispSetStatus = DispSetStatus.Update;
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        message = "��֐惁�[�J�[�R�[�h����͂��Ă��������B";
                        dispSetStatus = DispSetStatus.Clear;
                        break;
                    }
                default:
                    {
                        message = "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B";
                        dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                        break;
                    }
            }
            //// �f�[�^�ݒ�
            //DispSetChgDestMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

            if (dispSetStatus != DispSetStatus.Update)
            {
                control = this.ChgDestMakerCd_tNedit;
                return false;
            }

            // 2008.10.16 30413 ���� ��֌��Ƒ�֐悪���ꏤ�i���`�F�b�N��ǉ� >>>>>>START
            // ��֌��Ƒ�֐�̓��ꏤ�i�`�F�b�N
            if ((this.ChgSrcMakerCd_tNedit.GetInt() == this.ChgDestMakerCd_tNedit.GetInt()) &&
                (this.ChgSrcGoodsNo_tEdit.Text == this.ChgDestGoodsNo_tEdit.Text))
            {
                // ��֌��Ƒ�֐悪���ꏤ�i
                message = "��֌��Ƒ�֐�̏��i������ł��B";
                control = this.ChgDestGoodsNo_tEdit;
                return false;
                        
            }

            //-----------------------
            // �K�p�J�n���i�K�{���́j
            //-----------------------
            // �����ݒ�
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(this.detApplyStaDate.GetDateYear());
            inParamList.Add(this.detApplyStaDate.GetDateMonth());
            inParamList.Add(this.detApplyStaDate.GetDateDay());
            inParamObj = inParamList;

            // �K�p�J�n���G���[�`�F�b�N
            switch (CheckDetApplyDate(inParamObj, out outParamObj))
            {
                case (int)InputChkStatus.Normal:
                    {
                        // �������Ȃ�
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        // ������
                        control = this.detApplyStaDate;
                        message = "�K�p�J�n�������͂���Ă��܂���B";
                        return false;
                    }
                case (int)InputChkStatus.InputErr:
                    {
                        // �s���f�[�^
                        control = this.detApplyStaDate;
                        message = "�K�p�J�n��������������܂���B";
                        return false;
                    }
            }

            //-------------------------------------------------
            // �K�p�I�����i�C�ӓ��́j
            //-------------------------------------------------
            // ���͎�
            if ((this.detApplyEndDate.GetDateYear() > 0)
                || (this.detApplyEndDate.GetDateMonth() > 0)
                || (this.detApplyEndDate.GetDateDay() > 0))
            {
                // �����ݒ�
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                inParamList.Add(this.detApplyEndDate.GetDateYear());
                inParamList.Add(this.detApplyEndDate.GetDateMonth());
                inParamList.Add(this.detApplyEndDate.GetDateDay());
                inParamObj = inParamList;

                // �K�p�I�����G���[�`�F�b�N
                switch (CheckDetApplyDate(inParamObj, out outParamObj))
                {
                    case (int)InputChkStatus.Normal:
                        {
                            // �������Ȃ�
                            break;
                        }
                    case (int)InputChkStatus.NotInput:
                        {
                            // ������
                            control = this.detApplyEndDate;
                            message = "�K�p�I�����ɓ��͘R�ꂪ����܂��B";
                            return false;
                        }
                    case (int)InputChkStatus.InputErr:
                        {
                            // �s���f�[�^
                            control = this.detApplyEndDate;
                            message = "�K�p�I����������������܂���B";
                            return false;
                        }
                }
            }

            //------------------------
            // �K�p�J�n���E�I��������
            //------------------------
            if ((this.detApplyStaDate.GetDateYear() > 0)
                && (this.detApplyStaDate.GetDateMonth() > 0)
                && (this.detApplyStaDate.GetDateDay() > 0)
                && (this.detApplyEndDate.GetDateYear() > 0)
                && (this.detApplyEndDate.GetDateMonth() > 0)
                && (this.detApplyEndDate.GetDateDay() > 0))
            {
                if (this.detApplyStaDate.GetDateTime() >= this.detApplyEndDate.GetDateTime())
                {
                    control = this.detApplyStaDate;
                    message = "�u�K�p�J�n���@���@�K�p�I�����v�Őݒ肵�Ă��������B";
                    return false;
                }
            }
            return result;
        }

        #region ���[�J�[�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���[�J�[�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					  �����I�u�W�F�N�g:���[�J�[�R�[�h
        ///					  ���ʃI�u�W�F�N�g:���[�J�[�}�X�^�������ʃX�e�[�^�X, ���[�J�[����</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                MakerUMnt makerUMnt = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���[�J�[�}�X�^�X�e�[�^�X�ݒ�

                if (makerUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    if (makerUMnt.LogicalDeleteCode == 0)
                    {
                        ret = (int)InputChkStatus.Normal;
                        outParamList.Add(makerUMnt.MakerName);	// ���[�J�[���̐ݒ�
                    }
                    else
                    {
                        ret = (int)InputChkStatus.NotExist;
                    }
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        #endregion ���[�J�[�R�[�h�G���[�`�F�b�N����

        #region ���i��֐ݒ�G���[�`�F�b�N����
        /// <summary>
        /// ���i��֐ݒ�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <param name="sameWindowDiv">�E�B���h�E�\���敪</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�̃G���[�`�F�b�N���s���܂��B
        ///					  �����I�u�W�F�N�g:���_�R�[�h, ���[�J�[�R�[�h, ���[�J�[����, ���i�R�[�h
        ///					  ���ʃI�u�W�F�N�g:���i�}�X�^�������ʃX�e�[�^�X, ���i�R�[�h, ���i����, ���[�J�[�R�[�h, ���[�J�[����</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsNoCd(object inParamObj, out object outParamObj, bool sameWindowDiv)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 4)) return ret;
                if ((inParamList[0] is string) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is string) == false) return ret;
                if ((inParamList[3] is string) == false) return ret;
                if ((string)inParamList[3] == "") return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                
                // �����̎�ނ��擾
                string searchCode;
                int searchType = GetSearchType((string)inParamList[3], out searchCode);

                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // ���i���������ݒ�
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = (string)inParamList[0];
                goodsCndtn.GoodsMakerCd = (int)inParamList[1];
                goodsCndtn.MakerName = (string)inParamList[2];
                goodsCndtn.GoodsNo = (string)inParamList[3];
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� >>>>>>START
                //GoodsAcs goodsAcs = new GoodsAcs();
                //status = goodsAcs.SearchInitial(this._enterpriseCode, (string)inParamList[0], out message);
                // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX >>>>>>START
                //status = goodsAcs.SearchPartsFromGoodsNoForMst(goodsCndtn, out list, out message);
                //status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, sameWindowDiv, out list, out message);
                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, sameWindowDiv, out list, out message);
                // 2008.08.26 30413 ���� ���i�A�N�Z�X�N���X�̃��\�b�h�ύX <<<<<<END
                // 2008.10.08 30413 ���� ���i�A�N�Z�X�N���X�̃p�t�H�[�}���X���P�΍� <<<<<<END
            
                outParamList.Add(status);	// ���i�}�X�^�X�e�[�^�X�ݒ�

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�}�X�^�f�[�^�N���X
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    goodsUnitData = (GoodsUnitData)list[0];

                    outParamList.Add(goodsUnitData.GoodsNo);		// ���i�R�[�h
                    outParamList.Add(goodsUnitData.GoodsName);		// ���i���ݒ�
                    outParamList.Add(goodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
                    outParamList.Add(goodsUnitData.MakerName);		// ���[�J�[���ݒ�

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // �I���_�C�A���O�ŃL�����Z��
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        #endregion ���i��֐ݒ�G���[�`�F�b�N����

        #region �K�p���t�G���[�`�F�b�N����
        /// <summary>
        /// �K�p���t�G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note        : �K�p���t�G���[�`�F�b�N���s���܂��B
        ///				 	  �����I�u�W�F�N�g:�K�p���t
        ///					  ���ʃI�u�W�F�N�g:����</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckDetApplyDate(object inParamObj, out object outParamObj)
        {
            outParamObj = 0;	// ���ʃI�u�W�F�N�g�͖��g�p
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;

            ArrayList inParamList = null;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is int) == false) return ret;

                if (((int)inParamList[0] > 0) && ((int)inParamList[1] > 0) && ((int)inParamList[2] > 0))
                {
                    // ���͂����������t���H
                    int inputDate_int = ((int)inParamList[0] * 10000) + ((int)inParamList[1] * 100) + ((int)inParamList[2]);
                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);

                    // ������
                    if (inputDate != DateTime.MinValue)
                    {
                        ret = (int)InputChkStatus.Normal;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.InputErr;	// �s���f�[�^
                    }
                }
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion �K�p���t�G���[�`�F�b�N����

        #region ��֌����[�J�[�R�[�h�ݒ菈��
        /// <summary>
        /// ��֌����[�J�[�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��֌����[�J�[�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgSrcMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.ChgSrcMakerCd_tNedit.Clear();
                            this.ChgSrcMakerCdNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._chgSrcMakerCdWork = 0;

                            // �i�ԃN���A
                            this.ChgSrcGoodsNo_tEdit.Clear();
                            this.ChgSrcGoodsNoNm_tEdit.Clear();
                            this._chgSrcGoodsNoWork = "";

                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.ChgSrcMakerCd_tNedit.SetInt(this._chgSrcMakerCdWork);

                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.ChgSrcMakerCdNm_tEdit.Text = (string)outParamList[1];	// ���[�J�[��

                                    //----------------------------
                                    // ���[�J�[�R�[�h�ύX�`�F�b�N
                                    //----------------------------
                                    if (this._chgSrcMakerCdWork != this.ChgSrcMakerCd_tNedit.GetInt())
                                    {
                                        // ���[�J�[�R�[�h�ύX���́A���i�R�[�h�N���A
                                        this.ChgSrcGoodsNo_tEdit.Clear();
                                        this.ChgSrcGoodsNoNm_tEdit.Clear();
                                        this._chgSrcGoodsNoWork = "";
                                    }

                                    // ���݃f�[�^�ۑ�
                                    this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ��֌����[�J�[�R�[�h�ݒ菈��

        #region ��֌��i�Ԑݒ菈��
        /// <summary>
        /// ��֌��i�Ԑݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��֌��i�Ԃ���ʂɐݒ肵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgSrcGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.ChgSrcGoodsNo_tEdit.Clear();
                            this.ChgSrcGoodsNoNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._chgSrcGoodsNoWork = "";

                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.ChgSrcGoodsNo_tEdit.Text = this._chgSrcGoodsNoWork;

                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 5)
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is int)
                                    && (outParamList[4] is string))
                                {
                                    this.ChgSrcGoodsNo_tEdit.Text = (string)outParamList[1];	// ��֌��i��
                                    this.ChgSrcGoodsNoNm_tEdit.Text = (string)outParamList[2];	// ��֌����i
                                    this.ChgSrcMakerCd_tNedit.SetInt((int)outParamList[3]);	    // ��֌����[�J�[�R�[�h
                                    this.ChgSrcMakerCdNm_tEdit.Text = (string)outParamList[4];	// ��֌����[�J�[��

                                    // ���݃f�[�^�ۑ�
                                    this._chgSrcGoodsNoWork = this.ChgSrcGoodsNo_tEdit.Text;
                                    this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ��֌��i�Ԑݒ菈��

        #region ��֐惁�[�J�[�R�[�h�ݒ菈��
        /// <summary>
        /// ��֐惁�[�J�[�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��֐惁�[�J�[�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.ChgDestMakerCd_tNedit.Clear();
                            this.ChgDestMakerCdNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._chgDestMakerCdWork = 0;

                            // ���i�R�[�h�N���A
                            this.ChgDestGoodsNo_tEdit.Clear();
                            this.ChgDestGoodsNoNm_tEdit.Clear();
                            this._chgDestGoodsNoWork = "";

                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.ChgDestMakerCd_tNedit.SetInt(this._chgDestMakerCdWork);

                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.ChgDestMakerCdNm_tEdit.Text = (string)outParamList[1];	// ���[�J�[��

                                    //----------------------------
                                    // ���[�J�[�R�[�h�ύX�`�F�b�N
                                    //----------------------------
                                    if (this._chgDestMakerCdWork != this.ChgDestMakerCd_tNedit.GetInt())
                                    {
                                        // ���[�J�[�R�[�h�ύX���́A���i�R�[�h�N���A
                                        this.ChgDestGoodsNo_tEdit.Clear();
                                        this.ChgDestGoodsNoNm_tEdit.Clear();
                                        this._chgDestGoodsNoWork = "";
                                    }

                                    // ���݃f�[�^�ۑ�
                                    this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ��֐惁�[�J�[�R�[�h�ݒ菈��

        #region ��֐�i�Ԑݒ菈��
        /// <summary>
        /// ��֐�i�Ԑݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��֐�i�Ԃ���ʂɐݒ肵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.ChgDestGoodsNo_tEdit.Clear();
                            this.ChgDestGoodsNoNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._chgDestGoodsNoWork = "";

                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.ChgDestGoodsNo_tEdit.Text = this._chgDestGoodsNoWork;

                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 5)
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is int)
                                    && (outParamList[4] is string))
                                {
                                    this.ChgDestGoodsNo_tEdit.Text = (string)outParamList[1];	// ��֐�i��
                                    this.ChgDestGoodsNoNm_tEdit.Text = (string)outParamList[2];	// ��֐�i��
                                    this.ChgDestMakerCd_tNedit.SetInt((int)outParamList[3]);	// ��֐惁�[�J�[�R�[�h
                                    this.ChgDestMakerCdNm_tEdit.Text = (string)outParamList[4];	// ��֐惁�[�J�[��

                                    // ���݃f�[�^�ۑ�
                                    this._chgDestGoodsNoWork = this.ChgDestGoodsNo_tEdit.Text;
                                    this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ��֐�i�Ԑݒ菈��

        #region �����^�C�v�擾����
        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// <br>Note		: ����������@���擾���鏈�����s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }
        #endregion �����^�C�v�擾����

        /// <summary>
        /// ���i��֐ݒ�}�X�^�@���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�}�X�^�@���o�^���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this,                               // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                            // �\�����郁�b�Z�[�W
                    0,                                  // �X�e�[�^�X�l
                    MessageBoxButtons.OK);             // �\������{�^��

                control.Focus();
                return false;
            }

            // ���i��֐ݒ�X�V
            SavePartsSubstU();

            return true;
        }

        /// <summary>
        /// ���i��֐ݒ�X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�̍X�V���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private bool SavePartsSubstU()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            PartsSubstU partsSubstU = null;

            if (this._dataIndex >= 0)
            {
                // �n�b�V���L�[�擾
                string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();
            }

            DispToPartsSubstU(ref partsSubstU);

            // ��������
            status = this._partsSubstUAcs.Write(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this,                           // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
                            ASSEMBLY_ID,                    // �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,                    // �\�����郁�b�Z�[�W
                            0,                              // �X�e�[�^�X�l
                            MessageBoxButtons.OK);          // �\������{�^��

                        this.ChgSrcMakerCd_tNedit.Focus();
                        this.ChgSrcMakerCd_tNedit.SelectAll();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return false;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SavePartsSubstU",					// ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_UPDT_MSG,                       // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._partsSubstUAcs,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return false;
                    }
            }

            // DataSet�W�J����
            PartsSubstUToDataSet(partsSubstU, this._dataIndex);

            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// ���i��֐ݒ� �_���폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int LogicalDeletePartsSubstU()
        {
            int status = 0;
            int dummy = 0;

            // �n�b�V���L�[�擾
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // �_���폜
            status = this._partsSubstUAcs.LogicalDelete(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�X�V�̈�
                        Search(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);

                        // �t���[���X�V
                        Search(ref dummy, 0);
                        return status;
                    }
                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        // �t���[���X�V
                        Search(ref dummy, 0);
                        return status;
                    }

                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._partsSubstUAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        // �t���[���X�V
                        Search(ref dummy, 0);
                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            PartsSubstUToDataSet(partsSubstU.Clone(), this._dataIndex);
            return status;
        }

        /// <summary>
        /// ���i��֐ݒ� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int PhysicalDeletePartsSubstU()
        {
            int status = 0;

            // �n�b�V���L�[�擾
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // �����폜
            status = this._partsSubstUAcs.Delete(partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�X�V�̈�
                        this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex].Delete();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Delete_Button_Click",				  // ��������
                            TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                            ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._partsSubstUAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        // UI�q��ʋ����I������
                        EnforcedEndTransaction();

                        this.Hide();

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            int dummy = 0;
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // �f�[�^�C���f�b�N�X������������
                this._dataIndex = -1;

                // �t���[���X�V
                Search(ref dummy, 0);

                // ��ʃN���A����
                ScreenClear();

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                
                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                ScreenInputPermissionControl(INSERT_MODE);

                Initial_Timer.Enabled = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = -2;
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
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
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �r���������s���܂�</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            ERR_800_MSG,							// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            ERR_801_MSG,							// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                        break;
                    }
            }
        }

        # region HashTable�pKey�쐬
        /// <summary>
        /// HashTable�pKey�쐬
        /// </summary>
        /// <param name="goodsChangeU">���i�ϊ��N���X</param>
        /// <returns>Hash�pKey</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�N���X����n�b�V���e�[�u���p��
        ///					  �L�[���쐬���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private string CreateHashKey(PartsSubstU partsSubstU)
        {
            return partsSubstU.ChgSrcMakerCd.ToString("d6") +
                    partsSubstU.ChgSrcGoodsNo.PadRight(40) +
                    partsSubstU.ChgDestMakerCd.ToString("d6") +
                    partsSubstU.ChgDestGoodsNo.PadRight(40);
        }
        #endregion HashTable�pKey�쐬

        /// <summary>
        /// Form.Load �C�x���g (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_Load(object sender, EventArgs e)
        {
            this.ChgSrcMakerGuide_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            this.ChgDestMakerGuide_Button.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;         // �ۑ��{�^��
            this.Cancel_Button.ImageList = imageList24;     // ����{�^��
            this.Revive_Button.ImageList = imageList24;     // �����{�^��
            this.Delete_Button.ImageList = imageList24;     // ���S�폜�{�^��

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;            // �ۑ��{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;       // ����{�^��
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;     // �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;      // ���S�폜�{�^��
        }

        /// <summary>
        /// Form.FormClosing �C�x���g (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_dataIndex�o�b�t�@�ێ�
            this._indexBuf = -2;

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Form.VisibleChanged �C�x���g (PMKEN09090UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���̕\����Ԃ��ω��������ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void PMKEN09090UA_VisibleChanged(object sender, EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            Initial_Timer.Enabled = true;
        }


        /// <summary>
        /// UltraButton.Click �C�x���g (Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �ۑ��{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// UltraButton.Click �C�x���g (Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                PartsSubstU comparePartsSubstU = new PartsSubstU();
                comparePartsSubstU = this._partsSubstUClone.Clone();

                //���݂̉�ʏ����擾����
                DispToPartsSubstU(ref comparePartsSubstU);

                // �ŏ��Ɏ擾������ʂƔ�r
                if (!(this._partsSubstUClone.Equals(comparePartsSubstU)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������B
                    DialogResult res = TMsgDisp.Show(
                        this,                               // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        ASSEMBLY_ID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W
                        0,                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
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

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            //_dataIndex�o�b�t�@�ێ�
            this._indexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

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
        /// UltraButton.Click �C�x���g (Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���S�폜�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        // </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                CONF_DEL_MSG,						// �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,         // �\������{�^��
                MessageBoxDefaultButton.Button2);  // �����\���{�^��

            if (result == DialogResult.OK)
            {
                // ���i��֐ݒ蕨���폜
                PhysicalDeletePartsSubstU();
            }
            else
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            //_dataIndex�o�b�t�@�ێ�
            this._indexBuf = -2;

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
        /// UltraButton.Click �C�x���g (Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �n�b�V���L�[�擾
            string hashKey = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            PartsSubstU partsSubstU = ((PartsSubstU)this._partsSubstUTable[hashKey]).Clone();

            // �_���폜����
            status = this._partsSubstUAcs.Revival(ref partsSubstU);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u��ID
                            SDC_RDEL_MSG,						// �\�����郁�b�Z�[�W
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.Hide();
                        break;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_RVV_MSG,                        // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._partsSubstUAcs,              // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);  // �����\���{�^��

                        this.Hide();
                        return;
                    }
            }

            PartsSubstUToDataSet(partsSubstU, this._dataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            //_dataIndex�o�b�t�@�ێ�
            this._indexBuf = -2;

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
        /// Timer.Tick �C�x���g (Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂������ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        // --------------------------------------------------
        #region ChangeFocus Events
        /// <summary>Control.ChangeFocus �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;
            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = new ArrayList();

            switch (e.PrevCtrl.Name)
            {
                #region ��֌����[�J�[�R�[�h
                case "ChgSrcMakerCd_tNedit":
                    {
                        if ((this._chgSrcMakerCdWork == 0) && (this.ChgSrcMakerCd_tNedit.GetInt() == 0))
                        {
                            // �����͎��͑��݃`�F�b�N���͎��{���Ȃ�
                            break;
                        }
                        else if (this._chgSrcMakerCdWork == this.ChgSrcMakerCd_tNedit.GetInt())
                        {
                            // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                            // �l���ύX����Ă��Ȃ��ꍇ�͑��݃`�F�b�N���͎��{���Ȃ�
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.ChgSrcGoodsNo_tEdit;
                            //}
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                }
                            }
                            break;
                        }

                        // �����ݒ�
                        inParamObj = this.ChgSrcMakerCd_tNedit.GetInt();

                        // ���݃`�F�b�N
                        switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    //{
                                    //    //e.NextCtrl = this.ChgSrcGoodsNo_tEdit;
                                    //    //e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                    //}
                                    if (!e.ShiftKey)
                                    {
                                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                        {
                                            e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                        }
                                    }
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 													// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                                            this.Name,												// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            0,														// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);									// �\������{�^��

                                    dispSetStatus = this._chgSrcMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // �f�[�^�ݒ�
                        DispSetChgSrcMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                        break;
                    }
                #endregion

                #region ��֌��i��
                case "ChgSrcGoodsNo_tEdit":
                    {
                        if ((this.ChgSrcMakerCd_tNedit.GetInt() == 0) && (this.ChgSrcGoodsNo_tEdit.Text == "")) 
                        {
                            // ���[�J�[�ƕi�Ԃ������͂̏ꍇ�͑��݃`�F�b�N���s��Ȃ�
                            break;
                        }
                        else if ((this.ChgSrcMakerCd_tNedit.GetInt() != 0) && (this.ChgSrcGoodsNo_tEdit.Text != "") &&
                                 (this._chgSrcMakerCdWork == this.ChgSrcMakerCd_tNedit.GetInt()) &&
                                 (this._chgSrcGoodsNoWork == this.ChgSrcGoodsNo_tEdit.Text))
                        {
                            // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                            // ���[�J�[�ƕi�Ԃ����͍ς݂Œl���ύX����Ă��Ȃ��ꍇ�͑��݃`�F�b�N���s��Ȃ�
                            //if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            //{
                            //    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                            //}
                            break;
                        }

                        // �����ݒ�
                        inParamList.Add(this._sectionCode);
                        //inParamList.Add(this.ChgSrcMakerCd_tNedit.GetInt()); // DEL 2009/03/16
                        //inParamList.Add(this.ChgSrcMakerCdNm_tEdit.Text); // DEL 2009/03/16
                        inParamList.Add(0); // ADD 2009/03/16
                        inParamList.Add(string.Empty); // ADD 2009/03/16
                        inParamList.Add(this.ChgSrcGoodsNo_tEdit.Text);
                        inParamObj = inParamList;

                        // ���݃`�F�b�N
                        switch (CheckGoodsNoCd(inParamObj, out outParamObj, true))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            case (int)InputChkStatus.Cancel:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŕi�Ԃ͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            0,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                                    dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // �f�[�^�ݒ�
                        DispSetChgSrcGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

                        // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                        // �t�H�[�J�X�ύX��
                        //if ((canChangeFocus) && (e.ShiftKey) && (e.Key == Keys.Tab))
                        //{
                        //    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                        //}
                        
                        break;
                    }
                #endregion

                #region ��֐惁�[�J�[�R�[�h
                case "ChgDestMakerCd_tNedit":
                    {
                        if ((this._chgDestMakerCdWork == 0) && (this.ChgDestMakerCd_tNedit.GetInt() == 0))
                        {
                            // �����͎��͑��݃`�F�b�N���͎��{���Ȃ�
                            break;
                        }
                        else if (this._chgDestMakerCdWork == this.ChgDestMakerCd_tNedit.GetInt())
                        {
                            // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                            // �l���ύX����Ă��Ȃ��ꍇ�͑��݃`�F�b�N���͎��{���Ȃ�
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            //{
                            //    //e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                            //}
                            if (!e.ShiftKey)
                            {
                                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                {
                                    e.NextCtrl = this.detApplyStaDate;
                                }
                            }
                            break;
                        }

                        // �����ݒ�
                        inParamObj = this.ChgDestMakerCd_tNedit.GetInt();

                        // ���݃`�F�b�N
                        switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                    //{
                                    //    e.NextCtrl = this.ChgDestGoodsNo_tEdit;
                                    //}
                                    if (!e.ShiftKey)
                                    {
                                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                                        {
                                            e.NextCtrl = this.detApplyStaDate;
                                        }
                                    }
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 													// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 							// �G���[���x��
                                            this.Name,												// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            0,														// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);									// �\������{�^��

                                    dispSetStatus = this._chgDestMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // �f�[�^�ݒ�
                        DispSetChgDestMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            
                        break;
                    }
                #endregion

                #region ��֐�i��
                case "ChgDestGoodsNo_tEdit":
                    {
                        if ((this.ChgDestMakerCd_tNedit.GetInt() == 0) && (this.ChgDestGoodsNo_tEdit.Text == ""))
                        {
                            // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                            // ���[�J�[�ƕi�Ԃ������͂̏ꍇ�͑��݃`�F�b�N���s��Ȃ�
                            if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            {
                                if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                                {
                                    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                                }
                            }
                            break;
                        }
                        else if ((this.ChgDestMakerCd_tNedit.GetInt() != 0) && (this.ChgDestGoodsNo_tEdit.Text != "") &&
                                 (this._chgDestMakerCdWork == this.ChgDestMakerCd_tNedit.GetInt()) &&
                                 (this._chgDestGoodsNoWork == this.ChgDestGoodsNo_tEdit.Text))
                        {
                            // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                            // ���[�J�[�ƕi�Ԃ����͍ς݂Œl���ύX����Ă��Ȃ��ꍇ�͑��݃`�F�b�N���s��Ȃ�
                            if ((e.ShiftKey) && (e.Key == Keys.Tab))
                            {
                                //e.NextCtrl = this.ChgDestMakerCd_tNedit;
                                if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                                {
                                    e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                                }
                            }
                            break;
                        }

                        // �����ݒ�
                        inParamList.Add(this._sectionCode);
                        //inParamList.Add(this.ChgDestMakerCd_tNedit.GetInt()); // DEL 2009/03/16
                        //inParamList.Add(this.ChgDestMakerCdNm_tEdit.Text); // DEL 2009/03/16
                        inParamList.Add(0); // ADD 2009/03/16
                        inParamList.Add(string.Empty); // ADD 2009/03/16
                        inParamList.Add(this.ChgDestGoodsNo_tEdit.Text);
                        inParamObj = inParamList;

                        // ���݃`�F�b�N
                        switch (CheckGoodsNoCd(inParamObj, out outParamObj, true))
                        {
                            case (int)InputChkStatus.Normal:
                                {
                                    dispSetStatus = DispSetStatus.Update;
                                    break;
                                }
                            case (int)InputChkStatus.NotInput:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            case (int)InputChkStatus.Cancel:
                                {
                                    dispSetStatus = DispSetStatus.Clear;
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(
                                            this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŕi�Ԃ͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            0,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                                    dispSetStatus = this._chgDestGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                    break;
                                }
                        }
                        // �f�[�^�ݒ�
                        DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, outParamObj);

                        // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                        // �t�H�[�J�X�ύX��
                        if ((canChangeFocus) && (e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            //e.NextCtrl = this.ChgDestMakerCd_tNedit;
                            if (this.ChgSrcMakerCd_tNedit.GetInt() != 0)
                            {
                                e.NextCtrl = this.ChgSrcMakerCd_tNedit;
                            }
                        }

                        break;
                    }
                #endregion

                // 2009.02.16 30413 ���� �t�H�[�J�X������C��-----
                #region �K�p�J�n��
                case "detApplyStaDate":
                    {
                        // ��֐�̃��[�J�[�R�[�h���ݒ��
                        if ((e.ShiftKey) && (e.Key == Keys.Tab))
                        {
                            if (this.ChgDestMakerCd_tNedit.GetInt() != 0)
                            {
                                e.NextCtrl = this.ChgDestMakerCd_tNedit;
                            }
                        }
                        break;
                    }
                #endregion
            }

            // �t�H�[�J�X����
            if (canChangeFocus == false)
            {
                e.NextCtrl = e.PrevCtrl;

                // ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
                e.NextCtrl.Select();
            }

            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "ChgDestGoodsNo_tEdit":        // ��֐�i��
                case "ChgDestMakerCd_tNedit":       // ��֐惁�[�J�[�R�[�h
                case "ChgDestMakerGuide_Button":    // ��֐惁�[�J�[�K�C�h
                case "detApplyStaDate":     // �K�p�J�n��
                case "detApplyEndDate":     // �K�p�I����
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = ChgSrcGoodsNo_tEdit;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }
        #endregion ChangeFocus Events

        #region �K�C�h����
        /// <summary>
        /// ChgSrcMakerGuide_Button_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ��֌����[�J�[�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ChgSrcMakerGuide_Button_Click(object sender, EventArgs e)
        {
            int goodsMakerCd = 0;
            string makerName = "";

            if (GoodsMakerCdGuide(out goodsMakerCd, out makerName) == 0)
            {
                this.ChgSrcMakerCd_tNedit.SetInt(goodsMakerCd);
                this.ChgSrcMakerCdNm_tEdit.Text = makerName;

                // ���݃f�[�^�ۑ�
                this._chgSrcMakerCdWork = this.ChgSrcMakerCd_tNedit.GetInt();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ChgDestMakerGuide_Button_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ��֐惁�[�J�[�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void ChgDestMakerGuide_Button_Click(object sender, EventArgs e)
        {
            int goodsMakerCd = 0;
            string makerName = "";

            if (GoodsMakerCdGuide(out goodsMakerCd, out makerName) == 0)
            {
                this.ChgDestMakerCd_tNedit.SetInt(goodsMakerCd);
                this.ChgDestMakerCdNm_tEdit.Text = makerName;

                //----------------------------
                // ���[�J�[�R�[�h�ύX�`�F�b�N
                //----------------------------
                if (this.ChgDestMakerCd_tNedit.GetInt() != this._chgDestMakerCdWork)
                {
                    // ���i�R�[�h�N���A
                    this.ChgDestGoodsNo_tEdit.Clear();
                    this.ChgDestGoodsNoNm_tEdit.Clear();
                }

                // ���݃f�[�^�ۑ�
                this._chgDestMakerCdWork = this.ChgDestMakerCd_tNedit.GetInt();

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// ���[�J�[�R�[�h�K�C�h�N������
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[�R�[�h����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : ���[�J�[�R�[�h�K�C�h���N�����܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int GoodsMakerCdGuide(out int goodsMakerCd, out string makerName)
        {
            MakerUMnt makerUMnt;
            goodsMakerCd = 0;
            makerName = "";

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);  // �K�C�h�f�[�^

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                goodsMakerCd = makerUMnt.GoodsMakerCd;
                makerName = makerUMnt.MakerName.TrimEnd();
            }
            return status;
        }

        #endregion �K�C�h����

        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ��֌��i��
            string chgSrcGoodsNo = ChgSrcGoodsNo_tEdit.Text.TrimEnd();
            // ��֌����[�J�[�R�[�h
            int chgSrcMakerCd = ChgSrcMakerCd_tNedit.GetInt();
            //// ��֐�i��
            //string chgDestGoodsNo = ChgDestGoodsNo_tEdit.Text.TrimEnd();
            //// ��֐惁�[�J�[�R�[�h
            //int chgDestMakerCd = ChgDestMakerCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsChgSrcGoodsNo = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGSRCGOODSNO_TITLE];
                int dsChgSrcMakerCd = (int)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGSRCMAKERCD_TITLE];
                //string dsChgDestGoodsNo = (string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGDESTGOODSNO_TITLE];
                //int dsChgDestMakerCd = (int)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][CHGDESTMAKERCD_TITLE];
                if ((chgSrcGoodsNo.Equals(dsChgSrcGoodsNo.TrimEnd())) &&
                    (chgSrcMakerCd == dsChgSrcMakerCd))
                    //(chgSrcMakerCd == dsChgSrcMakerCd) &&
                    //(chgDestGoodsNo.Equals(dsChgDestGoodsNo.TrimEnd())) &&
                    //(chgDestMakerCd == dsChgDestMakerCd))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[PARTSSUBSTU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̑�փ}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ��֌��^��֐�̃N���A
                        ChgSrcGoodsNo_tEdit.Clear();
                        ChgSrcGoodsNoNm_tEdit.Clear();
                        ChgSrcMakerCd_tNedit.Clear();
                        ChgSrcMakerCdNm_tEdit.Clear();
                        //ChgDestGoodsNo_tEdit.Clear();
                        //ChgDestGoodsNoNm_tEdit.Clear();
                        //ChgDestMakerCd_tNedit.Clear();
                        //ChgDestMakerCdNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̑�փ}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ��֌��^��֐�̃N���A
                                ChgSrcGoodsNo_tEdit.Clear();
                                ChgSrcGoodsNoNm_tEdit.Clear();
                                ChgSrcMakerCd_tNedit.Clear();
                                ChgSrcMakerCdNm_tEdit.Clear();
                                //ChgDestGoodsNo_tEdit.Clear();
                                //ChgDestGoodsNoNm_tEdit.Clear();
                                //ChgDestMakerCd_tNedit.Clear();
                                //ChgDestMakerCdNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.30 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}