//****************************************************************************
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================
// ����
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/23  �C�����e : ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/27  �C�����e : �V�X�e���e�X�g��Q�Ή�(No3�`No7)
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/10/28  �C�����e : �R�[�h���͂���ŃR�[�h����Shift�{Enter�L�[����������ƁA�t�H�[�J�X���O���ڂɈړ����Ȃ�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/10/28  �C�����e : �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/28  �C�����e : �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�
//----------------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/10/29  �C�����e : �ҏW���̃_�C�A���O�ɂāu�L�����Z���v��I������ƁA��ʂ�����
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMTAB�����\���]�ƈ��ݒ�}�X�^�\���ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̐ݒ���s���܂��B</br>
    /// <br>Programmer : 31065 �L�� ���O</br>
    /// <br>Date       : 2014/09/19</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTAB09190UA : Form, IMasterMaintenanceMultiType
    {
        #region Constructor

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        public PMTAB09190UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            this.DataSetColumnConstruction();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmtDefEmpAcs = new PmtDefEmpAcs();
            this._pmtDefEmpTable = new Hashtable();
            this._pmtEmployeeDivTable = new Hashtable();

            // �v���p�e�B�[�ϐ�������
            this._canPrint = false;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = true;
            this._dataIndex = -1;
            this._canSpecificationSearch = false;
            this._totalCount = 0;

            // �S���ҋ敪������擾�p�}�b�v�\�z
            for (int index = 0; index < this.SalesEmployeeDiv_ce.Items.Count; index++)
            {
                this._pmtEmployeeDivTable.Add(
                    this.SalesEmployeeDiv_ce.Items[index].DataValue,
                    this.SalesEmployeeDiv_ce.Items[index].DisplayText);
            }

        }

        #endregion

        #region Private const Members
        // �e�[�u����
        private const string PmtDefEmp_TABLE = "PmtDefEmp";

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string UPDATEDATETIME_DATE = "�X�V��";
        private const string DELETE_DATE = "�폜��";
        private const string LOGINAGENCODE_TITLE = "���O�C���S���҃R�[�h";
        private const string LOGINAGENNAME_TITLE = "���O�C���S���Җ���";
        private const string SALESEMPDIV_TITLE = "�S���ҋ敪";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� --->>>>>>
        private const string SALESEMPLOYEECD_TITLE = "�S���҃R�[�h";
        private const string SALESEMPLOYEENM_TITLE = "�S���Җ���";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� ---<<<<<<
        private const string FRONTEMPDIV_TITLE = "�󒍎ҋ敪";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� --->>>>>>
        private const string FRONTEMPLOYEECD_TITLE = "�󒍎҃R�[�h";
        private const string FRONTEMPLOYEENM_TITLE = "�󒍎Җ���";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� ---<<<<<<
        private const string SALESINPUTDIV_TITLE = "���s�ҋ敪";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� --->>>>>>
        private const string SALESINPUTCD_TITLE = "���s�҃R�[�h";
        private const string SALESINPUTNM_TITLE = "���s�Җ���";
        // UPD 2014/10/27 k.toyosawa �f�[�^�r���[�̍��ږ��̂����ꂳ��Ă��Ȃ��̑Ή� ---<<<<<<
        private const string GUID_TITLE = "GUID";

        // �ҏW���[�h
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string INSERT_MODE = "�V�K���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // Message�֘A��`
        private const string CT_PGID = "PMSCM05300U";
        private const string CT_PGNM = "��M�Ώۏ��}�X�^";
        private const string ASSEMBLY_ID = "PMSCM05300U";
        private const string ERR_SEAR_TIME_MSG = "�������Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�������s�Ȃ��Ă��������B";
        private const string ERR_WRITE_TIME_MSG = "�X�V���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string ERR_DEL_TIME_MSG = "�폜���Ƀ^�C���A�E�g���������܂����B\r\n���΂炭���Ԃ�u���čēx�X�V���Ă��������B";
        private const string SECTION_00_MES = "�S��";

        // �e�S���҃`�F�b�N�Ώۋ敪�萔
        private const int EMPLOYEE_CHECK_DIV = 3;

        // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
        private const string ID_0000_ID = "0000";
        // ADD 2014/10/27 k.toyosawa ���ʐݒ�̕\��������ʂƓ��ꂳ��Ă��Ȃ����̑Ή� --->>>>>>
        private const string ID_0000_NAME = "����";
        // ADD 2014/10/27 k.toyosawa ���ʐݒ�̕\��������ʂƓ��ꂳ��Ă��Ȃ����̑Ή� ---<<<<<<
        // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
        #endregion

        #region Private Members
        private string _enterpriseCode;    // ��ƃR�[�h
        private Hashtable _pmtDefEmpTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^ �A�N�Z�X�N���X
        private PmtDefEmpAcs _pmtDefEmpAcs;
        private PmtDefEmp _pmtDefEmp;
        /// </summary>
        // ��r�p�N���[��
        private PmtDefEmp _pmtDefEmpClone = new PmtDefEmp();
        private int _totalCount;
        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private int _detailsIndexBuf;
        // �K�C�h�n�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs = null;
        private Hashtable _employeeTb = null;
        // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
        private int _preLoginAgenCd = -1;   // �ύX�O���O�C���S���҃R�[�h
        // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
        private int _preSalesEmployeeCd = 0;   // �ύX�O�̔��]�ƈ��R�[�h
        private int _preFrontEmployeeCd = 0;   // �ύX�O��t�]�ƈ��R�[�h
        private int _preSalesInputCd = 0;   // �ύX�O������͎҃R�[�h

        // �S���ҋ敪������擾�p�}�b�v
        private Hashtable _pmtEmployeeDivTable;
        #endregion

        #region  Events

        /// <summary>
        /// ��ʔ�\���C�x���g
        /// </summary>
        /// <remarks>
        /// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
        /// </remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

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

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
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

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;

            }
        }

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;

            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get { return this._canSpecificationSearch; }
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
            get { return this._defaultAutoFillToColumn; }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public System.Collections.Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            // ���O�C���S���҃R�[�h
            appearanceTable.Add(LOGINAGENCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ���O�C���S���Җ���
            appearanceTable.Add(LOGINAGENNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �S���ҋ敪
            appearanceTable.Add(SALESEMPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �̔��]�ƈ��R�[�h
            appearanceTable.Add(SALESEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // �̔��]�ƈ�����
            appearanceTable.Add(SALESEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �󒍎ҋ敪
            appearanceTable.Add(FRONTEMPDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ��t�]�ƈ��R�[�h
            appearanceTable.Add(FRONTEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ��t�]�ƈ�����
            appearanceTable.Add(FRONTEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ���s�ҋ敪
            appearanceTable.Add(SALESINPUTDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ������͎҃R�[�h
            appearanceTable.Add(SALESINPUTCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ������͎Җ���
            appearanceTable.Add(SALESINPUTNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //GUID_TITLE
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <param name="tableName">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <param name="bindDataSet">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PmtDefEmp_TABLE;
        }

        /// <summary>
        ///  Print
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // ����A�Z���u�������[�h����i�������j
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            const string ctPROCNM = "Search";
            PmtDefEmp parsePmtDefEmp = new PmtDefEmp();
            List<PmtDefEmp> PmtDefEmpList = new List<PmtDefEmp>();
            parsePmtDefEmp.EnterpriseCode = this._enterpriseCode;
            if (this._pmtDefEmpTable.Count == 0)
            {
                status = this._pmtDefEmpAcs.Search(ref PmtDefEmpList, parsePmtDefEmp, out totalCount, 0, 0, ConstantManagement.LogicalMode.GetData01);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this._totalCount = PmtDefEmpList.Count;
                            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Clear();
                            this._pmtDefEmpTable.Clear();

                            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                            int index = 0;
                            foreach (PmtDefEmp PmtDefEmp in PmtDefEmpList)
                            {
                                if (this._pmtDefEmpTable.ContainsKey(PmtDefEmp.FileHeaderGuid) == false)
                                {
                                    this.PmtDefEmpToDataSet(PmtDefEmp.Clone(), index);
                                    ++index;
                                }
                            }

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // �T�[�`
                            TMsgDisp.Show(
                                this,                               // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                                CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Name,                          // �v���O��������
                                ctPROCNM,                           // ��������
                                TMsgDisp.OPE_GET,                   // �I�y���[�V����
                                ERR_SEAR_TIME_MSG,                  // �\�����郁�b�Z�[�W
                                status,                             // �X�e�[�^�X�l
                                this._pmtDefEmpAcs,                 // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,               // �\������{�^��
                                MessageBoxDefaultButton.Button1);   // �����\���{�^��
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                this.Name,
                                "�ǂݍ��݂Ɏ��s���܂����B",
                                status,
                                MessageBoxButtons.OK);
                            break;
                        }
                }
            }

            else
            {
                this._totalCount = this._pmtDefEmpTable.Count;
                SortedList sortedList = new SortedList();

                // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                int index = 0;
                foreach (PmtDefEmp pmtDefEmp in sortedList.Values)
                {
                    this.PmtDefEmpToDataSet(pmtDefEmp.Clone(), index);
                    ++index;
                }
            }
            // �߂�l�Z�b�g
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            return 0;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Delete()
        {

            const string ctPROCNM = "LogicalDelete";
            PmtDefEmp PmtDefEmp = null;

            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
            PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

            int status;
            int dummy = 0;
            // PMTAB�����\���]�ƈ��ݒ�}�X�^�_���폜����
            status = this._pmtDefEmpAcs.LogicalDelete(ref PmtDefEmp);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.PmtDefEmpToDataSet(PmtDefEmp.Clone(), this.DataIndex);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);

                        // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�f�[�^�Z�b�g�W�J����
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        return status;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_DEL_TIME_MSG,                   // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                 // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                            // �v���O��������
                            "Delete",                           // ��������
                            TMsgDisp.OPE_HIDE,                  // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                 // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��

                        //PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�f�[�^�Z�b�g�W�J����
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);

                        return status;
                    }
            }

            return status;
        }

        # endregion Public Methods

        #region  Control Events

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �v���p�e�B�̏����ݒ�
            this._canPrint = false;
            this._canClose = false;
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // �ۑ��{�^��
            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;

            // ����{�^��
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // �����{�^��
            this.Revive_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            // ���S�폜�{�^��
            this.Delete_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ���O�C���S���҃K�C�h
            this.LoginAgenCdGuid_ultraButton.ImageList = imageList16;
            this.LoginAgenCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // �̔��]�ƈ��K�C�h
            this.SalesEmployeeCdGuid_ultraButton.ImageList = imageList16;
            this.SalesEmployeeCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // ��t�]�ƈ��K�C�h
            this.FrontEmployeeCdGuid_ultraButton.ImageList = imageList16;
            this.FrontEmployeeCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            // ������͎҃K�C�h
            this.SalesInputCdGuid_ultraButton.ImageList = imageList16;
            this.SalesInputCdGuid_ultraButton.Appearance.Image = Size16_Index.STAR1;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Form.FormClosing �C�x���g (PMSCM05300UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._detailsIndexBuf = -2;
            // �`�F�b�N�p�N���[��������
            this._pmtDefEmpClone = null;

            // ���[�U�[�ɂ���ĕ�����ꍇ
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z�����ăt�H�[�����\��������B
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.VisibleChanged �C�x���g (PMSCM05300UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PMSCM05300UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                if (this.Owner != null)
                {
                    this.Owner.Activate();
                }
                return;
            }

            // ��ʃN���A����
            this.ScreenClear();

            this.Initial_Timer.Enabled = true;

        }

        /// <summary>
        /// Timer.Tick �C�x���g (Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "LoginAgenCd_tEdit":
                    {
                        int employeeCd = this.LoginAgenCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preLoginAgenCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    // ADD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ錏�̑Ή�  --->>>>>>
                                    int code = 0;
                                    if (this._preLoginAgenCd != -1)
                                    {
                                        code = this._preLoginAgenCd;
                                    }
                                    // ADD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ錏�̑Ή�  ---<<<<<<

                                    // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ錏�̑Ή�  --->>>>>>
                                    this.LoginAgenCd_tEdit.SetInt(code);
                                    // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ錏�̑Ή�  ---<<<<<<
                                    // ���̓`�F�b�N
                                    TMsgDisp.Show(
                                        this,                                   // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  --->>>>>>
                                        "�}�X�^�ɓo�^����Ă��܂���",           // �\�����郁�b�Z�[�W
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  ---<<<<<<
                                        0,                                      // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);                  // �\������{�^��
                                    e.NextCtrl = this.LoginAgenCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.LoginAgenNm_tEdit.Text = employeeNm;
                                    this._preLoginAgenCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            // DEL 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή�  --->>>>>>
                            //this.LoginAgenNm_tEdit.Text = string.Empty;
                            //_preLoginAgenCd = 0;
                            // DEL 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<

                            // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                            if (0 < this.LoginAgenCd_tEdit.DataText.Length)
                            {
                                this.LoginAgenCd_tEdit.Text = ID_0000_ID;
                                this.LoginAgenNm_tEdit.Text = ID_0000_NAME;
                                this._preLoginAgenCd = 0;
                            }
                            else
                            {
                                this.LoginAgenNm_tEdit.Text = string.Empty;
                                _preLoginAgenCd = -1;
                            }
                            // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.LoginAgenNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                        if ( _preLoginAgenCd == -1)
                        {
                            break;
                        }
                        // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<

                        if (this.ModeChangeProc(this.LoginAgenCd_tEdit.GetInt().ToString().PadLeft(4, '0')))
                        {
                            e.NextCtrl = this.LoginAgenCd_tEdit;
                        }

                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
                        if (0 < this.LoginAgenCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 �g�� ------->>>>>>>>>>>>
                            // e.NextCtrl = this.SalesEmployeeDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.SalesEmployeeDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  ---<<<<<<
                            }
                            // UPD 2014/10/28 �g�� -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
                        break;
                    }
                case "SalesEmployeeCd_tEdit":
                    {
                        int employeeCd = this.SalesEmployeeCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preSalesEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.SalesEmployeeCd_tEdit.SetInt(this._preSalesEmployeeCd);
                                    // ���̓`�F�b�N
                                    TMsgDisp.Show(
                                        this,                                   // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  --->>>>>>
                                        "�}�X�^�ɓo�^����Ă��܂���",           // �\�����郁�b�Z�[�W
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  ---<<<<<<
                                        0,                                      // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);                  // �\������{�^��
                                    e.NextCtrl = SalesEmployeeCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.SalesEmployeeNm_tEdit.Text = employeeNm;
                                    this._preSalesEmployeeCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.SalesEmployeeNm_tEdit.Text = string.Empty;
                            this._preSalesEmployeeCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.SalesEmployeeNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
                        if (0 < this.SalesEmployeeCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 �g�� ------->>>>>>>>>>>>
                            // e.NextCtrl = this.FrontEmployeeDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.FrontEmployeeDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  ---<<<<<<
                            }
                            // UPD 2014/10/28 �g�� -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
                        break;
                    }
                case "FrontEmployeeCd_tEdit":
                    {
                        int employeeCd = this.FrontEmployeeCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preFrontEmployeeCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.FrontEmployeeCd_tEdit.SetInt(this._preFrontEmployeeCd);
                                    // ���̓`�F�b�N
                                    TMsgDisp.Show(
                                        this,                                   // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  --->>>>>>
                                        "�}�X�^�ɓo�^����Ă��܂���",           // �\�����郁�b�Z�[�W
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  ---<<<<<<
                                        0,                                      // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);                  // �\������{�^��
                                    e.NextCtrl = FrontEmployeeCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.FrontEmployeeNm_tEdit.Text = employeeNm;
                                    this._preFrontEmployeeCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.FrontEmployeeNm_tEdit.Text = string.Empty;
                            this._preFrontEmployeeCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                this.FrontEmployeeNm_tEdit.Text.TrimEnd();
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
                        if (0 < this.FrontEmployeeCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 �g�� ------->>>>>>>>>>>>
                            // e.NextCtrl = this.SalesInputDiv_ce;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.SalesInputDiv_ce;
                                }
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  ---<<<<<<
                            }
                            // UPD 2014/10/28 �g�� -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
                        break;
                    }
                case "SalesInputCd_tEdit":
                    {
                        int employeeCd = this.SalesInputCd_tEdit.GetInt();
                        if (employeeCd != 0)
                        {
                            if (employeeCd != this._preSalesInputCd)
                            {
                                if (this._employeeAcs == null)
                                {
                                    this._employeeAcs = new EmployeeAcs();
                                }

                                string employeeNm = this.GetEmployeeNm(employeeCd.ToString().PadLeft(4, '0'));
                                if (string.IsNullOrEmpty(employeeNm))
                                {
                                    this.SalesInputCd_tEdit.SetInt(this._preSalesInputCd);
                                    // ���̓`�F�b�N
                                    TMsgDisp.Show(
                                        this,                                   // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                        CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  --->>>>>>
                                        "�}�X�^�ɓo�^����Ă��܂���",           // �\�����郁�b�Z�[�W
                                        // UPD 2014/10/27 k.toyosawa �}�X�^���o�^�̃`�F�b�N���b�Z�[�W���d�l�ƈقȂ�  ---<<<<<<
                                        0,                                      // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);                  // �\������{�^��
                                    e.NextCtrl = SalesInputCd_tEdit;
                                    return;
                                }
                                else
                                {
                                    this.SalesInputNm_tEdit.Text = employeeNm;
                                    this._preSalesInputCd = employeeCd;
                                }
                            }
                        }
                        else
                        {
                            this.SalesInputNm_tEdit.Text = string.Empty;
                            this._preSalesInputCd = 0;
                        }
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
                                this.SalesInputNm_tEdit.Text.TrimEnd();
                                // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
                            }
                        }

                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
                        if (0 < this.SalesInputCd_tEdit.Text.Length)
                        {
                            // UPD 2014/10/28 �g�� ------->>>>>>>>>>>>
                            // e.NextCtrl = this.Ok_Button;
                            if (!e.ShiftKey)
                            {
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  --->>>>>>
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                                // ADD 2014/10/27 k.toyosawa �S���҃R�[�h����㉺���E�L�[����������ƁA�t�H�[�J�X�ړ��悪����Ȃ����̑Ή�  ---<<<<<<
                            }
                            // UPD 2014/10/28 �g�� -------<<<<<<<<<<<<
                        }
                        // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
                        break;
                    }
            }
        }

        /// <summary>
        /// LoginAgenCdGuid_ultraButton_Click �C�x���g (LoginAgenCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void LoginAgenCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._employeeAcs == null)
                {
                    this._employeeAcs = new EmployeeAcs();
                }

                Employee employee;
                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    string employeeCode = employee.EmployeeCode.TrimEnd();
                    if (!this.ModeChangeProc(employeeCode))
                    {
                        this.LoginAgenCd_tEdit.Value = employeeCode;
                        this.LoginAgenNm_tEdit.Text = employee.Name;
                        this._preLoginAgenCd = this.LoginAgenCd_tEdit.GetInt();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
            this.SalesEmployeeDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<

        }

        /// <summary>
        /// SalesEmployeeCdGuid_ultraButton_Click �C�x���g(SalesEmployeeCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesEmployeeCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.SalesEmployeeCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.SalesEmployeeNm_tEdit.Text = employee.Name;
                this._preSalesEmployeeCd = this.SalesEmployeeCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
            this.FrontEmployeeDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
        }

        /// <summary>
        /// FrontEmployeeCdGuid_ultraButton_Click �C�x���g (FrontEmployeeCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void FrontEmployeeCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.FrontEmployeeCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.FrontEmployeeNm_tEdit.Text = employee.Name;
                this._preFrontEmployeeCd = this.FrontEmployeeCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
            this.SalesInputDiv_ce.Focus();
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<
        }

        /// <summary>
        /// SalesInputCdGuid_ultraButton_Click �C�x���g (SalesInputCdGuid_ultraButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesInputCdGuid_ultraButton_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.SalesInputCd_tEdit.Value = employee.EmployeeCode.TrimEnd();
                this.SalesInputNm_tEdit.Text = employee.Name;
                this._preSalesInputCd = this.SalesInputCd_tEdit.GetInt();
            }
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  --->>>>>>
            this.Ok_Button.Focus();
            // UPD 2014/10/27 k.toyosawa �R�[�h���󔒈ȊO�̂Ƃ��ɁA�K�C�h����]�ƈ���I������ƁA�K�C�h�{�^���փt�H�[�J�X���ړ����錏�̑Ή�  ---<<<<<<

        }

        /// <summary>
        /// Ok_Button_Click �C�x���g (Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // �t�H�[�������
            this.CloseForm(DialogResult.OK);

            // �t�H�[�����\��������B
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

        }

        /// <summary>
        /// Cancel_Button_Click �C�x���g (Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // �ۑ��m�F
                PmtDefEmp comparePmtDefEmp = new PmtDefEmp();
                comparePmtDefEmp = this._pmtDefEmpClone.Clone();
                this._detailsIndexBuf = this._dataIndex;

                // ���݂̉�ʏ����擾����
                this.DispToPmtDefEmp(ref comparePmtDefEmp);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._pmtDefEmpClone.Equals(comparePmtDefEmp)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                         this,                                  // �e�E�B���h�E�t�H�[��
                         emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // �G���[���x��
                         ASSEMBLY_ID,                           // �A�Z���u���h�c�܂��̓N���X�h�c
                         "",                                    // �\�����郁�b�Z�[�W 
                         0,                                     // �X�e�[�^�X�l
                         MessageBoxButtons.YesNoCancel);        // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �o�^����
                                if (this.SaveProc() == false)
                                {
                                    return;
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;
                                break;
                            }
                        default:
                            {
                                this.Cancel_Button.Focus();
                                // UPD 2014/10/29 k.toyosawa �ҏW���̃_�C�A���O�ɂāu�L�����Z���v��I������ƁA��ʂ����錏�̑Ή�  --->>>>>>
                                return;
                                // UPD 2014/10/29 k.toyosawa �ҏW���̃_�C�A���O�ɂāu�L�����Z���v��I������ƁA��ʂ����錏�̑Ή�  ---<<<<<<
                            }
                    }
                }
            }
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        /// <summary>
        /// Delete_Button_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "Delete";
            PmtDefEmp PmtDefEmp = new PmtDefEmp();

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
                CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H",                 // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,         // �\������{�^��
                MessageBoxDefaultButton.Button2);   // �����\���{�^��
            if (result == DialogResult.OK)
            {
                // �ێ����Ă���f�[�^�Z�b�g�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
                PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];
                // PMTAB�����\���]�ƈ��ݒ�}�X�^�_���폜����
                int status = this._pmtDefEmpAcs.Delete(ref PmtDefEmp);

                int dummy = 0;

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex].Delete();
                            this._pmtDefEmpTable.Remove(PmtDefEmp.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            this.ExclusiveTransaction(status, true);

                            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�f�[�^�Z�b�g�W�J����
                            this._pmtDefEmpTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            // TIMEOUT
                            TMsgDisp.Show(
                               this,                                // �e�E�B���h�E�t�H�[��
                               emErrorLevel.ERR_LEVEL_STOP,         // �G���[���x��
                               CT_PGID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                               this.Name,                           // �v���O��������
                               ctPROCNM,                            // ��������
                               TMsgDisp.OPE_UPDATE,                 // �I�y���[�V����
                               ERR_DEL_TIME_MSG,                    // �\�����郁�b�Z�[�W
                               status,                              // �X�e�[�^�X�l
                               this._pmtDefEmpAcs,                  // �G���[�����������I�u�W�F�N�g
                               MessageBoxButtons.OK,                // �\������{�^��
                               MessageBoxDefaultButton.Button1);    // �����\���{�^��
                            return;
                        }
                    default:
                        {
                            // �����폜
                            TMsgDisp.Show(
                                this,                               // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                                CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                                CT_PGNM,                            // �v���O��������
                                "Delete_Button_Click",              // ��������
                                TMsgDisp.OPE_DELETE,                // �I�y���[�V����
                                "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                                status,                             // �X�e�[�^�X�l
                                this._pmtDefEmpAcs,                 // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,               // �\������{�^��
                                MessageBoxDefaultButton.Button1);   // �����\���{�^��

                            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�f�[�^�Z�b�g�W�J����
                            this._pmtDefEmpTable.Clear();
                            this.Search(ref dummy, 0);
                            this.Close();

                            return;
                        }
                }

            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;


            // Grid��IndexBuffer�i�[�p�ϐ��̏�����
            this._detailsIndexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

        }

        /// <summary>
        /// Revive_Button_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks> 
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            const string ctPROCNM = "RevivalProc";
            PmtDefEmp PmtDefEmp = null;

            DialogResult res = TMsgDisp.Show(this,
                                             emErrorLevel.ERR_LEVEL_QUESTION,
                                             CT_PGID,
                                             "���ݕ\�����̃}�X�^�𕜊����܂��B" + "\r\n" + "��낵���ł����H",
                                             0,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this.DataIndex][GUID_TITLE];
            PmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
            int status = this._pmtDefEmpAcs.RevivalLogicalDelete(ref PmtDefEmp);
            int dummy = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this.PmtDefEmpToDataSet(PmtDefEmp, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);

                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();

                        return;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_WRITE_TIME_MSG,                 // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return;

                    }
                default:
                    {
                        // �������s
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                            // �v���O��������
                            "Revive_Button_Click",              // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            "�����Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                 // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        // �N���X�f�[�^�Z�b�g�W�J����
                        this._pmtDefEmpTable.Clear();
                        this.Search(ref dummy, 0);
                        this.Close();
                        break;
                    }
            }
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;

            this._detailsIndexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (this.CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note		: ���[�h�ύX����</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>  
        private bool ModeChangeProc(string employeeCd)
        {
            for (int i = 0; i < this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsEmployeeCd = (string)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[i][LOGINAGENCODE_TITLE];
                if (employeeCd.Equals(dsEmployeeCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this,                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
                            ASSEMBLY_ID,                    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���͂��ꂽ�R�[�h��PMTAB�����\���]�ƈ��ݒ�}�X�^���͊��ɍ폜����Ă��܂��B",  // �\�����郁�b�Z�[�W
                            0,                              // �X�e�[�^�X�l
                            MessageBoxButtons.OK);          // �\������{�^��
                        this.LoginAgenCd_tEdit.Clear();
                        this.LoginAgenNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��PMTAB�����\���]�ƈ��ݒ�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                this.ScreenClear();
                                this.ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                this.LoginAgenCd_tEdit.Clear();
                                this.LoginAgenNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// SalesEmployeeDiv_ce_ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesEmployeeDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.SalesEmployeeCd_tEdit.Enabled = true;
                this.SalesEmployeeCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.SalesEmployeeCd_tEdit.Enabled = false;
                this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
            }
            this.SalesEmployeeCd_tEdit.Text = string.Empty;
            this.SalesEmployeeNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ --------->>>>>>>>>>>>>>>>>>
            this._preSalesEmployeeCd = 0;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ ---------<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// FrontEmployeeDiv_ce_ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void FrontEmployeeDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.FrontEmployeeCd_tEdit.Enabled = true;
                this.FrontEmployeeCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.FrontEmployeeCd_tEdit.Enabled = false;
                this.FrontEmployeeCdGuid_ultraButton.Enabled = false;
            }
            this.FrontEmployeeCd_tEdit.Text = string.Empty;
            this.FrontEmployeeNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ --------->>>>>>>>>>>>>>>>>>
            this._preFrontEmployeeCd = 0;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ ---------<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SalesInputDiv_ce_ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void SalesInputDiv_ce_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesInputDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                this.SalesInputCd_tEdit.Enabled = true;
                this.SalesInputCdGuid_ultraButton.Enabled = true;
            }
            else
            {
                this.SalesInputCd_tEdit.Enabled = false;
                this.SalesInputCdGuid_ultraButton.Enabled = false;
            }
            this.SalesInputCd_tEdit.Text = string.Empty;
            this.SalesInputNm_tEdit.Text = string.Empty;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ --------->>>>>>>>>>>>>>>>>>
            this._preSalesInputCd = 0;
            // ADD 2014/10/28 �g�� �R�[�h���͌�A�]�ƈ����̂��\������Ȃ��ꍇ������ ---------<<<<<<<<<<<<<<<<<<
        }
        #endregion

        #region  Private Methods

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�V�K, 1:�X�V, 2:�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:�V�K
                case 0:
                    // ���O�C���S����
                    this.LoginAgenCd_tEdit.Enabled = true;
                    this.LoginAgenCdGuid_ultraButton.Enabled = true;

                    // �S����
                    // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                    this.SalesEmployeeDiv_ce.Enabled = true;
                    // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
                    // �V�K�̏ꍇ�A�S���ҋ敪�͗D��]�ƈ��̂��ߔ̔��]�ƈ��R�[�h�͓��͕s��
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
                    this.SalesEmployeeCd_tEdit.Enabled = false;
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;

                    // �󒍎�
                    this.FrontEmployeeDiv_ce.Enabled = true;
                    // �V�K�̏ꍇ�A�󒍎ҋ敪�͗D��]�ƈ��̂��ߎ�t�]�ƈ��R�[�h�͓��͕s��
                    this.FrontEmployeeDiv_ce.SelectedIndex = 0;
                    this.FrontEmployeeCd_tEdit.Enabled = false;
                    this.FrontEmployeeCdGuid_ultraButton.Enabled = false;

                    // ���s��
                    this.SalesInputDiv_ce.Enabled = true;
                    // �V�K�̏ꍇ�A���s�҂ɋ敪�͗D��]�ƈ��̂��ߔ�����͎҃R�[�h�͓��͕s��
                    this.SalesInputDiv_ce.SelectedIndex = 0;
                    this.SalesInputCd_tEdit.Enabled = false;
                    this.SalesInputCdGuid_ultraButton.Enabled = false;


                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 1:�X�V
                case 1:
                    // ���O�C���S����
                    this.LoginAgenCd_tEdit.Enabled = false;
                    this.LoginAgenCdGuid_ultraButton.Enabled = false;

                    // �S����
                    this.SalesEmployeeDiv_ce.Enabled = true;
                    // �̔��]�ƈ��R�[�h�̓��͂͒S���ҋ敪�Ɉˑ�
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.SalesEmpDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.SalesEmployeeCd_tEdit.Enabled = true;
                        this.SalesEmployeeCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.SalesEmployeeCd_tEdit.Enabled = false;
                        this.SalesEmployeeCdGuid_ultraButton.Enabled = false;
                    }

                    // �󒍎�
                    this.FrontEmployeeDiv_ce.Enabled = true;
                    // ��t�]�ƈ��R�[�h�̓��͎͂󒍎ҋ敪�Ɉˑ�
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.FrontEmpDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.FrontEmployeeCd_tEdit.Enabled = true;
                        this.FrontEmployeeCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.FrontEmployeeCd_tEdit.Enabled = false;
                        this.FrontEmployeeCdGuid_ultraButton.Enabled = false;
                    }

                    // ���s��
                    this.SalesInputDiv_ce.Enabled = true;
                    // ������͎҃R�[�h�̓��͔͂��s�҂ɋ敪
                    if (this._pmtDefEmpClone != null && this._pmtDefEmpClone.SalesInputDiv == EMPLOYEE_CHECK_DIV)
                    {
                        this.SalesInputCd_tEdit.Enabled = true;
                        this.SalesInputCdGuid_ultraButton.Enabled = true;
                    }
                    else
                    {
                        this.SalesInputCd_tEdit.Enabled = false;
                        this.SalesInputCdGuid_ultraButton.Enabled = false;
                    }


                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;

                    break;
                // 2:�폜
                case 2:
                    // ���O�C���S����
                    this.LoginAgenCd_tEdit.Enabled = false;
                    this.LoginAgenCdGuid_ultraButton.Enabled = false;

                    // �S����
                    this.SalesEmployeeDiv_ce.Enabled = false;
                    this.SalesEmployeeCd_tEdit.Enabled = false;
                    this.SalesEmployeeCdGuid_ultraButton.Enabled = false;

                    // �󒍎�
                    this.FrontEmployeeDiv_ce.Enabled = false;
                    this.FrontEmployeeCd_tEdit.Enabled = false;
                    this.FrontEmployeeCdGuid_ultraButton.Enabled = false;

                    // ���s��
                    this.SalesInputDiv_ce.Enabled = false;
                    this.SalesInputCd_tEdit.Enabled = false;
                    this.SalesInputCdGuid_ultraButton.Enabled = false;


                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// ��ʏ��S�̍��ڕ\�����̃N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <param name="PmtDefEmp">�S�̍��ڕ\�����̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̍��ڕ\�����̃N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void DispToPmtDefEmp(ref PmtDefEmp pmtDefEmp)
        {
            if (pmtDefEmp == null)
            {
                // �V�K�̏ꍇ
                pmtDefEmp = new PmtDefEmp();
                pmtDefEmp.EnterpriseCode = this._enterpriseCode;
            }

            if (pmtDefEmp.EnterpriseCode == "")
            {
                pmtDefEmp.EnterpriseCode = this._enterpriseCode;
            }

            // ���O�C���S���҃R�[�h
            if (this.LoginAgenCd_tEdit.GetInt() == 0)
            {
                // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
                pmtDefEmp.LoginAgenCode = ID_0000_ID;
                // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
            }
            else
            {
                pmtDefEmp.LoginAgenCode = this.LoginAgenCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // �S���ҋ敪
            pmtDefEmp.SalesEmpDiv = int.Parse(this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString());

            // �̔��]�ƈ��R�[�h
            if (this.SalesEmployeeCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.SalesEmployeeCd = "";
            }
            else
            {
                pmtDefEmp.SalesEmployeeCd = this.SalesEmployeeCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // �󒍎ҋ敪
            pmtDefEmp.FrontEmpDiv = int.Parse(this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString());

            // ��t�]�ƈ��R�[�h
            if (this.FrontEmployeeCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.FrontEmployeeCd = "";
            }
            else
            {
                pmtDefEmp.FrontEmployeeCd = this.FrontEmployeeCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }

            // ���s�ҋ敪
            pmtDefEmp.SalesInputDiv = int.Parse(this.SalesInputDiv_ce.SelectedItem.DataValue.ToString());

            // ������͎҃R�[�h
            if (this.SalesInputCd_tEdit.GetInt() == 0)
            {
                pmtDefEmp.SalesInputCode = "";
            }
            else
            {
                pmtDefEmp.SalesInputCode = this.SalesInputCd_tEdit.GetInt().ToString().PadLeft(4, '0');
            }
        }

        /// <summary>
        /// ��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\�����̃N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void AlItmDspNmToScreen()
        {
            this.PmtDefEmpToScreen(this._pmtDefEmp);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            this.ScreenInputPermissionControl(0);

            // ���O�C���S����
            this.LoginAgenCd_tEdit.Clear();
            this.LoginAgenNm_tEdit.Text = "";
            // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
            this._preLoginAgenCd = -1;
            // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<

            // �S����
            this.SalesEmployeeDiv_ce.SelectedIndex = 0;
            this.SalesEmployeeCd_tEdit.Clear();
            this.SalesEmployeeNm_tEdit.Text = "";
            this._preSalesEmployeeCd = 0;

            // �󒍎�
            this.FrontEmployeeDiv_ce.SelectedIndex = 0;
            this.FrontEmployeeCd_tEdit.Clear();
            this.FrontEmployeeNm_tEdit.Text = "";
            this._preFrontEmployeeCd = 0;

            // ���s��
            this.SalesInputDiv_ce.SelectedIndex = 0;
            this.SalesInputCd_tEdit.Clear();
            this.SalesInputNm_tEdit.Text = "";
            // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
            //this._preLoginAgenCd = 0;
            this._preSalesInputCd = 0;
            // UPD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {

            this._pmtDefEmp = new PmtDefEmp();
            PmtDefEmp pmtDefEmp = new PmtDefEmp();
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                this.PmtDefEmpToScreen(pmtDefEmp);
                // ��ʃN���A
                this.ScreenClear();
                // �N���[���쐬
                this._pmtDefEmpClone = pmtDefEmp.Clone();

                // �t�H�[�J�X�ݒ�
                this.SalesEmployeeCd_tEdit.Focus();
                this.ScreenInputPermissionControl(0);
                // ��ʓW�J����
                this.DispToPmtDefEmp(ref this._pmtDefEmpClone);
            }
            else
            {
                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this._dataIndex][GUID_TITLE];
                pmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];

                // ��ʓW�J����
                this.PmtDefEmpToScreen(pmtDefEmp);
                if (pmtDefEmp.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    //�N���[���쐬
                    this._pmtDefEmpClone = pmtDefEmp.Clone();

                    // ��ʓW�J����
                    this.DispToPmtDefEmp(ref this._pmtDefEmpClone);
                    this.ScreenInputPermissionControl(1);
                    this.SalesEmployeeDiv_ce.Focus();
                }
                // �폜�̏ꍇ
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓW�J����
                    this.PmtDefEmpToScreen(pmtDefEmp);
                    this.ScreenInputPermissionControl(2);
                    this.Delete_Button.Focus();

                }

                this._detailsIndexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// �f�[�^�ۑ��`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ���̓f�[�^�̕ۑ����s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private bool SaveProc()
        {

            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = null;

            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                                  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                    CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                               // �\�����郁�b�Z�[�W
                    0,                                     // �X�e�[�^�X�l
                    MessageBoxButtons.OK);                // �\������{�^��

                // �R���g���[����I��
                control.Focus();

                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            // �\�����擾
            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[this._dataIndex][GUID_TITLE];
                this._pmtDefEmp = (PmtDefEmp)this._pmtDefEmpTable[guid];
            }
            // ��ʂ���S�̍��ڕ\�����̂̃f�[�^���擾
            this.DispToPmtDefEmp(ref this._pmtDefEmp);

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            status = this._pmtDefEmpAcs.Write(ref this._pmtDefEmp);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.PmtDefEmpToDataSet(this._pmtDefEmp.Clone(), this.DataIndex);
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this,                                    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,             // �G���[���x��
                            CT_PGID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                       // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                   // �\������{�^��

                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                    {
                        // TIMEOUT
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Name,                          // �v���O��������
                            ctPROCNM,                           // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            ERR_WRITE_TIME_MSG,                 // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                            CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                              // �v���O��������
                            ctPROCNM,                             // ��������
                            TMsgDisp.OPE_READ,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                            status,                               // �X�e�[�^�X�l
                            this._pmtDefEmpAcs,                    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);     // �����\���{�^��
                        this.CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            return result;
        }

        /// <summary>
        /// ���Check
        /// </summary>
        /// <param name="control">STATUS</param>
        /// <param name="message">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : ���Check���s���܂�</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (this.LoginAgenCd_tEdit.Text == "")
            {
                control = this.LoginAgenCd_tEdit;
                message = "���O�C���S���҃R�[�h����͂��ĉ�����";
                return false;
            }

            if (this.SalesEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.SalesEmployeeCd_tEdit.Text == "")
                {
                    control = this.SalesEmployeeCd_tEdit;
                    message = "�S���҂���͂��ĉ�����";
                    return false;
                }

                if (this.SalesEmployeeNm_tEdit.Text.Trim() == "")
                {
                    control = this.SalesEmployeeNm_tEdit;
                    message = "�}�X�^�ɓo�^����Ă��܂���";
                    return false;
                }
            }

            if (this.FrontEmployeeDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.FrontEmployeeCd_tEdit.Text == "")
                {
                    // UPD 2014/10/27 k.toyosawa �󒍎Җ����͂̓��̓`�F�b�N��A�t�H�[�J�X���R�[�h�ł͂Ȃ��敪�Ɉړ����� --->>>>>>
                    control = this.FrontEmployeeCd_tEdit;
                    // UPD 2014/10/27 k.toyosawa �󒍎Җ����͂̓��̓`�F�b�N��A�t�H�[�J�X���R�[�h�ł͂Ȃ��敪�Ɉړ����� ---<<<<<<
                    message = "�󒍎҂���͂��ĉ�����";
                    return false;
                }

                if (this.FrontEmployeeNm_tEdit.Text.Trim() == "")
                {
                    control = this.FrontEmployeeNm_tEdit;
                    message = "�}�X�^�ɓo�^����Ă��܂���";
                    return false;
                }
            }

            if (this.SalesInputDiv_ce.SelectedItem.DataValue.ToString() == EMPLOYEE_CHECK_DIV.ToString())
            {
                if (this.SalesInputCd_tEdit.Text == "")
                {
                    control = this.SalesInputCd_tEdit;
                    message = "���s�҂���͂��ĉ�����";
                    return false;
                }

                if (this.SalesInputNm_tEdit.Text.Trim() == "")
                {
                    control = this.SalesInputNm_tEdit;
                    message = "�}�X�^�ɓo�^����Ă��܂���";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                 // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                 // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // ��r�p�N���[���N���A
            this._pmtDefEmpClone = null;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// �]�ƈ����̂̎擾
        /// </summary>
        /// <param name="employeeCode"> ��t�]�ƈ��R�[�h</param>
        /// <returns>��t�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂̎擾���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private string GetEmployeeNm(string employeeCode)
        {
            // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� --->>>>>>
            if (employeeCode.TrimEnd() == ID_0000_ID)
            {
                return ID_0000_NAME;
            }
            // ADD 2014/10/23 k.toyosawa ���O�C���S���҂�0000���ʂ�ݒ�ł��Ȃ����̑Ή� ---<<<<<<

            string employeeNm = string.Empty;
            if (_employeeTb == null)
            {
                this.GetAllEmployeeNm();
            }
            if (_employeeTb != null && this._employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                employeeNm = (string)this._employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return employeeNm;
        }

        /// <summary>
        /// �S�]�ƈ����̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�]�ƈ����̂̎擾���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
               this._employeeTb = new Hashtable();
            }
            else
            {
                this._employeeTb.Clear();
            }

            ArrayList employeeList;
            ArrayList employeeDtlList;
            int status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.LogicalDeleteCode == 0)
                    {
                        this._employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�W�J����
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void PmtDefEmpToDataSet(PmtDefEmp pmtDefEmp, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PmtDefEmp_TABLE].NewRow();
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (pmtDefEmp.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][DELETE_DATE] = pmtDefEmp.UpdateDateTimeJpFormal;
            }

            // ���O�C���S���҃R�[�h
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][LOGINAGENCODE_TITLE] = pmtDefEmp.LoginAgenCode;

            // ���O�C���S���Җ���
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][LOGINAGENNAME_TITLE] = this.GetEmployeeNm(pmtDefEmp.LoginAgenCode);

            // �S���ҋ敪
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.SalesEmpDiv);

            // �̔��]�ƈ��R�[�h
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPLOYEECD_TITLE] = pmtDefEmp.SalesEmployeeCd;

            // �̔��]�ƈ�����
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESEMPLOYEENM_TITLE] = this.GetEmployeeNm(pmtDefEmp.SalesEmployeeCd);

            // �󒍎ҋ敪
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.FrontEmpDiv);

            // ��t�]�ƈ��R�[�h
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPLOYEECD_TITLE] = pmtDefEmp.FrontEmployeeCd;

            // ��t�]�ƈ�����
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][FRONTEMPLOYEENM_TITLE] = this.GetEmployeeNm(pmtDefEmp.FrontEmployeeCd);

            // ���s�ҋ敪
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTDIV_TITLE] = this.GetEmployeeDivString(pmtDefEmp.SalesInputDiv);

            // ������͎҃R�[�h
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTCD_TITLE] = pmtDefEmp.SalesInputCode;

            // ������͎Җ���
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][SALESINPUTNM_TITLE] = this.GetEmployeeNm(pmtDefEmp.SalesInputCode);

            // GUID
            this.Bind_DataSet.Tables[PmtDefEmp_TABLE].Rows[index][GUID_TITLE] = pmtDefEmp.FileHeaderGuid;

            if (this._pmtDefEmpTable.ContainsKey(pmtDefEmp.FileHeaderGuid) == true)
            {
                this._pmtDefEmpTable.Remove(pmtDefEmp.FileHeaderGuid);
            }
            this._pmtDefEmpTable.Add(pmtDefEmp.FileHeaderGuid, pmtDefEmp);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable pmtDefEmpTable = new DataTable(PmtDefEmp_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            pmtDefEmpTable.Columns.Add(DELETE_DATE, typeof(string));                // �폜��
            pmtDefEmpTable.Columns.Add(LOGINAGENCODE_TITLE, typeof(string));        // ���O�C���S���҃R�[�h
            pmtDefEmpTable.Columns.Add(LOGINAGENNAME_TITLE, typeof(string));        // ���O�C���S���Җ���
            pmtDefEmpTable.Columns.Add(SALESEMPDIV_TITLE, typeof(string));          // �S���ҋ敪
            pmtDefEmpTable.Columns.Add(SALESEMPLOYEECD_TITLE, typeof(string));      // �̔��]�ƈ��R�[�h
            pmtDefEmpTable.Columns.Add(SALESEMPLOYEENM_TITLE, typeof(string));      // �̔��]�ƈ�����
            pmtDefEmpTable.Columns.Add(FRONTEMPDIV_TITLE, typeof(string));          // �󒍎ҋ敪
            pmtDefEmpTable.Columns.Add(FRONTEMPLOYEECD_TITLE, typeof(string));      // ��t�]�ƈ��R�[�h
            pmtDefEmpTable.Columns.Add(FRONTEMPLOYEENM_TITLE, typeof(string));      // ��t�]�ƈ�����
            pmtDefEmpTable.Columns.Add(SALESINPUTDIV_TITLE, typeof(string));        // ���s�ҋ敪
            pmtDefEmpTable.Columns.Add(SALESINPUTCD_TITLE, typeof(string));         // ������͎҃R�[�h
            pmtDefEmpTable.Columns.Add(SALESINPUTNM_TITLE, typeof(string));         // ������͎Җ���
            pmtDefEmpTable.Columns.Add(GUID_TITLE, typeof(Guid));
            this.Bind_DataSet.Tables.Add(pmtDefEmpTable);
        }

        /// <summary>
        /// �f�[�^�N���X��ʓW�J����
        /// </summary>
        /// <param name="PmtDefEmp">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// <br></br>
        /// </remarks>
        private void PmtDefEmpToScreen(PmtDefEmp pmtDefEmp)
        {

            // ���O�C���S���҃R�[�h
            this.LoginAgenCd_tEdit.Text = pmtDefEmp.LoginAgenCode.Trim().PadLeft(4, '0');

            // ���O�C���S���Җ���
            this.LoginAgenNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.LoginAgenCode);

            this._preLoginAgenCd = int.Parse(this.LoginAgenCd_tEdit.Text);

            // �S���ҋ敪
            this.SalesEmployeeDiv_ce.SelectedIndex = pmtDefEmp.SalesEmpDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.SalesEmployeeCd))
            {
                // �̔��]�ƈ��R�[�h
                this.SalesEmployeeCd_tEdit.Text = string.Empty;

                // �̔��]�ƈ�����
                this.SalesEmployeeNm_tEdit.Text = string.Empty;

                this._preSalesEmployeeCd = 0;
            }
            else
            {
                // �̔��]�ƈ��R�[�h
                this.SalesEmployeeCd_tEdit.Text = pmtDefEmp.SalesEmployeeCd.Trim().PadLeft(4, '0');

                // �̔��]�ƈ�����
                this.SalesEmployeeNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.SalesEmployeeCd);

                this._preSalesEmployeeCd = int.Parse(this.SalesEmployeeCd_tEdit.Text);
            }

            // �󒍎ҋ敪
            this.FrontEmployeeDiv_ce.SelectedIndex = pmtDefEmp.FrontEmpDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.FrontEmployeeCd))
            {
                // ��t�]�ƈ��R�[�h
                this.FrontEmployeeCd_tEdit.Text = string.Empty;

                // ��t�]�ƈ�����
                this.FrontEmployeeNm_tEdit.Text = string.Empty;

                this._preFrontEmployeeCd = 0;
            }
            else
            {
                // ��t�]�ƈ��R�[�h
                this.FrontEmployeeCd_tEdit.Text = pmtDefEmp.FrontEmployeeCd.Trim().PadLeft(4, '0');

                // ��t�]�ƈ�����
                this.FrontEmployeeNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.FrontEmployeeCd);

                this._preFrontEmployeeCd = int.Parse(this.FrontEmployeeCd_tEdit.Text);
            }

            // ���s�ҋ敪
            this.SalesInputDiv_ce.SelectedIndex = pmtDefEmp.SalesInputDiv;

            if (string.IsNullOrEmpty(pmtDefEmp.SalesInputCode))
            {
                // ������͎҃R�[�h
                this.SalesInputCd_tEdit.Text = string.Empty;

                // ������͎Җ���
                this.SalesInputNm_tEdit.Text = string.Empty;

                this._preSalesInputCd = 0;
            }
            else
            {
                // ������͎҃R�[�h
                this.SalesInputCd_tEdit.Text = pmtDefEmp.SalesInputCode.Trim().PadLeft(4, '0');

                // ������͎Җ���
                this.SalesInputNm_tEdit.Text = this.GetEmployeeNm(pmtDefEmp.SalesInputCode);

                this._preSalesInputCd = int.Parse(this.SalesInputCd_tEdit.Text);
            }
        }

        /// <summary>
        /// �S���ҋ敪(������)�̎擾
        /// </summary>
        /// <param name="employeeCode"> �S���ҋ敪(���l)</param>
        /// <returns>�S���ҋ敪(������)</returns>
        /// <remarks>
        /// <br>Note       : �S���ҋ敪(������)�擾���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private string GetEmployeeDivString(int employeeDiv)
        {
            string divString = string.Empty;
            if (this._pmtEmployeeDivTable.ContainsKey(employeeDiv))
            {
                divString = this._pmtEmployeeDivTable[employeeDiv].ToString();
            }
            return divString;
        }
        #endregion
    }
}