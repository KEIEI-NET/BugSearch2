//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �����[�g�`���ݒ�}�X�^
// �v���O�����T�v   : �����[�g�`���ݒ�̓o�^�E�C���E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011.08.03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �C �� �� 2011.09.21   �C�����e : #25386 �_���폜�f�[�^�\���s��
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
using System.Drawing;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Web.Services;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����[�g�`���ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.08.03</br>
    /// </remarks>
    public class RmSlpPrtStAcs : IGeneralGuideData
    {
        // --------------------------------------------------
        #region Private Members

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        //�⍇�����ƃR�[�h
        private string _inqOtherEpCd = string.Empty;
        //�⍇���拒�_�R�[�h
        private string _inqOtherSecCd = string.Empty;
        //�����[�g�`���ݒ�}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IRmSlpPrtStDB _iRmSlpPrtStDB = null;
        // �f�[�^�Z�b�g
        private DataSet _bindDataSet = null;
        private DataTable _rmSlpPrtStTable = null;
        // ����ݒ�p���[�R���{�{�b�N�X�p
        private SortedList _slipPrtSetPaperIdList = null;
        // �}�X�^�N���X�i�[���X�g
        private Dictionary<string, RmSlpPrtStWork> _rmSlpPrtStDic = null;     // �����[�g�`���ݒ�}�X�^�i�[�p
        // �}�X�^�擾�p���X�g
        private ArrayList _rmSlpPrtStWorkList = null;                         // �����[�g�`���ݒ�}�X�^�擾�p
        // �v���p�e�B�Z�b�g�p���X�g
        private ArrayList _rmSlpPrtStList = null;
        // �`�[����ݒ�p�}�X�^�A�N�Z�X�N���X
        private SlipPrtSetAcs _slipPrtSetAcs = null;
        // ���Ӑ�
        private CustomerInfoAcs _customerInfoAcs = null;
        // �����񌋍��p
        private StringBuilder _stringBuilder = null;
        // ���_�}�X�^�A�N�Z�X�N���X
        SecInfoAcs _secInfoAcs;

        // �K�C�h�p
        private const string GUIDE_XML_FILENAME = "CUSTSLIPMNGGUIDEPARENT.XML";        // XML�t�@�C����
        private const string GUIDE_INQORIGINALEPCDRF_TITLE = "InqOriginalEpCd";        // �⍇������ƃR�[�h
        private const string GUIDE_INQORIGINALEPCDRFNAME_TITLE = "InqOriginalEpCdName";// �⍇������Ɩ�
        private const string GUIDE_INQORIGINALSECCD_TITLE = "InqOriginalSecCd";        // �⍇�������_�R�[�h
        private const string GUIDE_INQORIGINALSECCDNAME_TITLE = "InqOriginalSecCdName";// �⍇�������_��
        private const string GUIDE_INQOTHEREPCDRF_TITLE = "InqOtherEpCd";              // �⍇�����ƃR�[�h
        private const string GUIDE_INQOTHEREPCDRFNAME_TITLE = "InqOtherEpCdName";      // �⍇�����Ɩ�
        private const string GUIDE_INQOTHERSECCD_TITLE = "InqOtherSecCd";              // �⍇���拒�_�R�[�h
        private const string GUIDE_INQOTHERSECCDNAME_TITLE = "InqOtherSecCdName";      // �⍇���拒�_��
        private const string GUIDE_SLIPPRTKINDID_TITLE = "SlipPrtKindId";              // �`�[�����ʃR�[�h
        private const string GUIDE_SLIPPRTKIND_TITLE = "SlipPrtKind";                  // �`�[�����ʖ���
        private const string GUIDE_SLIPPRTSETPAPERID_TITLE = "SlipPrtSetPaperId";      // �`�[����ݒ�p���[ID
        private const string GUIDE_RMTSLPPRTDIV_TITLE = "RmtSlpPrtDiv";                // �����[�g�`���敪
        private const string GUIDE_PPCCCOMPANYCODE_TITLE = "PccCompanyCode";           // PCC���ЃR�[�h
        private const string GUIDE_PPCCCOMPANYCODENAME_TITLE = "PccCompanyCodeName";   // PCC���Ж�
        private const string GUIDE_CREATEDATETIME_TITLE = "CreateDateTime";            // �쐬����
        private const string GUIDE_UPDATEDATETIME_TITLE = "UpdateDateTime";            // �X�V����
        private const string GUIDE_LOGICALDELETECODE_TITLE = "LogicalDeleteCode";      // �_���폜�敪
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        private const string GUIDE_TOPMARGIN_TITLE = "TopMargin";                      // ��]��
        private const string GUIDE_LEFTMARGINE_TITLE = "LeftMargine";                  // ���]��
                // 2011.09.16 zhouzy UPDATE END <<<<<<

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)

        private const string TBL_RMSLPPRTST_TITLE = "RMSLPPRTST_TABLE";
        private const string COL_DELETEDATE_TITLE = "�폜��";
        private const string COL_SLIPPRTKINDID_TITLE = "�`�[������";
        private const string COL_SLIPPRTKIND_TITLE = "�`�[�����ʖ�";
        private const string COL_SLIPPRTSETPAPERID_TITLE = "�`�[����ݒ�p���[ID_Dmmy";
        private const string COL_SLIPPRTSETPAPERNAME_TITLE = "�`�[����ݒ�p���[ID";
        private const string COL_RMTSLPPRTDIV_TITLE = "�����[�g�`���敪";
        private const string COL_INQORIGINALEPCD_TITLE = "�⍇������ƃR�[�h";
        private const string COL_INQORIGINALEPCDNAME_TITLE = "�⍇������Ɩ�";
        private const string COL_INQORIGINALSECCD_TITLE = "�⍇�������_�R�[�h";
        private const string COL_INQORIGINALSECCDNAME_TITLE = "�⍇�������_��";
        private const string COL_INQOTHEREPCD_TITLE = "�⍇�����ƃR�[�h";
        private const string COL_INQOTHEREPCDNAME_TITLE = "�⍇�����Ɩ�";
        private const string COL_INQOTHERSECCD_TITLE = "�⍇���拒�_�R�[�h";
        private const string COL_INQOTHERSECCDNAME_TITLE = "�⍇���拒�_��";
        private const string COL_PCCCOMPANYCODE_TITLE = "���Ӑ�R�[�h";
        private const string COL_PCCCOMPANYCODENAME_TITLE = "���Ӑ於";
        private const string COL_CREATEDATETIME_TITLE = "�쐬����";
        private const string COL_UPDATEDATETIME_TITLE = "�X�V����";
        private const string COL_LOGICALDELETECODE_TITLE = "�_���폜�敪";
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        private const string COL_TOPMARGIN_TITLE = "��]��";
        private const string COL_LEFTMARGINE_TITLE = "���]��";
        // 2011.09.16 zhouzy UPDATE END <<<<<<
        private const string COL_GUID_TITLE = "GUID";


        // �f�t�H���g�̓����[�g
        private static bool _isLocalDBRead = false;

        #endregion

        // --------------------------------------------------
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
            Cancel = 1,
            // �قȂ�
            Different
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
        #region Constructor

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public RmSlpPrtStAcs()
        {
            try
            {
                // ��ƃR�[�h�擾
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // �⍇������ƃR�[�h
                this._inqOtherEpCd = this._enterpriseCode.TrimEnd();
                // �⍇�������_�R�[�h
                this._inqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                // �����[�g�I�u�W�F�N�g�擾
                this._iRmSlpPrtStDB = (IRmSlpPrtStDB)MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
                // �}�X�^�N���X�i�[���X�g������
                this._rmSlpPrtStDic = new Dictionary<string, RmSlpPrtStWork>();
                // �}�X�^�擾�p���X�g������
                this._rmSlpPrtStWorkList = new ArrayList();
                // �v���p�e�B�Z�b�g�p���X�g
                this._rmSlpPrtStList = new ArrayList();
                // �f�[�^�Z�b�g������
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();
                // �`�[����ݒ�
                this._slipPrtSetAcs = new SlipPrtSetAcs();
                // ����ݒ�p���[�R���{�{�b�N�X�p
                this._slipPrtSetPaperIdList = new SortedList();
                // �����񌋍��p
                this._stringBuilder = new StringBuilder();
                // ���_���擾���i
                this._secInfoAcs = new SecInfoAcs();
                // ���Ӑ揉����
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;
            }

        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // �`�[�Ǘ��}�X�^�e�[�u��
            this._rmSlpPrtStTable = new DataTable(TBL_RMSLPPRTST_TITLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            this._rmSlpPrtStTable.Columns.Add(COL_DELETEDATE_TITLE, typeof(string));            // �폜��
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTKINDID_TITLE, typeof(string));         // �`�[������
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTKIND_TITLE, typeof(string));           // �`�[�����ʖ�
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALEPCD_TITLE, typeof(string));       // �⍇������ƃR�[�h
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALEPCDNAME_TITLE, typeof(string));   // �⍇������Ɩ�
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALSECCD_TITLE, typeof(string));      // �⍇�������_�R�[�h
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALSECCDNAME_TITLE, typeof(string));  // �⍇�������_��
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHEREPCD_TITLE, typeof(string));          // �⍇�����ƃR�[�h 
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHEREPCDNAME_TITLE, typeof(string));      // �⍇�����Ɩ�
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHERSECCD_TITLE, typeof(string));         // �⍇���拒�_�R�[�h
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHERSECCDNAME_TITLE, typeof(string));     // �⍇���拒�_��
            this._rmSlpPrtStTable.Columns.Add(COL_PCCCOMPANYCODE_TITLE, typeof(Int32));         // PCC���ЃR�[�h
            this._rmSlpPrtStTable.Columns.Add(COL_PCCCOMPANYCODENAME_TITLE, typeof(string));    // PCC���Ж�
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTSETPAPERID_TITLE, typeof(string));     // ���[ID
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTSETPAPERNAME_TITLE, typeof(string));   // ���[��
            this._rmSlpPrtStTable.Columns.Add(COL_RMTSLPPRTDIV_TITLE, typeof(string));          // �����[�g�`���敪
            this._rmSlpPrtStTable.Columns.Add(COL_CREATEDATETIME_TITLE, typeof(DateTime));      // �쐬����
            this._rmSlpPrtStTable.Columns.Add(COL_UPDATEDATETIME_TITLE, typeof(DateTime));      // �X�V����   
            this._rmSlpPrtStTable.Columns.Add(COL_LOGICALDELETECODE_TITLE, typeof(Int32));      // �_���폜�敪
            this._rmSlpPrtStTable.Columns.Add(COL_GUID_TITLE, typeof(string));                  // GUID
            // 2011.09.16 zhouzy UPDATE STA >>>>>> 
            this._rmSlpPrtStTable.Columns.Add(COL_TOPMARGIN_TITLE, typeof(double));             // ��]��
            this._rmSlpPrtStTable.Columns.Add(COL_LEFTMARGINE_TITLE, typeof(double));           // ���]��
        // 2011.09.16 zhouzy UPDATE END <<<<<<

            this._rmSlpPrtStTable.PrimaryKey = new DataColumn[] { this._rmSlpPrtStTable.Columns[COL_GUID_TITLE] };

            this._bindDataSet.Tables.Add(this._rmSlpPrtStTable);
        }

        #endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public Dictionary<string, RmSlpPrtStWork> RmSlpPrtStDic
        {
            get
            {
                return this._rmSlpPrtStDic;
            }
        }

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        /// <summary>�����[�g�`���ݒ�}�X�^���X�g</summary>
        /// <value>�����[�g�`���ݒ�}�X�^���擾���܂��B</value>
        public ArrayList RmSlpPrtStList
        {
            get { return _rmSlpPrtStList; }
        }

        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// ����ݒ�p���[�R���{�{�b�N�X�p
        /// </summary>
        public SortedList SlipPrtSetPaperIdList
        {
            get { return _slipPrtSetPaperIdList; }
            set { _slipPrtSetPaperIdList = value; }
        }

        #endregion

        // --------------------------------------------------
        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            // �I�����C�����[�h���擾
            if (this._iRmSlpPrtStDB == null)
            {
                // �I�t���C��
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                // �I�����C��
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        // --------------------------------------------------
        #region Read Methods

        /// <summary>
        ///�ǂݍ��ݏ���
        /// </summary>
        /// <param name="RmSlpPrtSt">�����[�g�`���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="dataInputSystem">�����[�g�`���敪</param>
        /// <param name="slipPrtKind">�`�[�����ʃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">�����[�g�`���ݒ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Read(out RmSlpPrtSt RmSlpPrtSt, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
        {
            return this.ReadProc(out RmSlpPrtSt, enterpriseCode, dataInputSystem, slipPrtKind, sectionCode, customerCode);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="rmSlpPrtSt">�����[�g�`���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="rmtSlpPrtDiv">�����[�g�`���敪</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">�����[�g�`���ݒ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int ReadProc(out RmSlpPrtSt rmSlpPrtSt, string enterpriseCode, Int32 rmtSlpPrtDiv, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
        {
            int status1 = 0;

            rmSlpPrtSt = null;

            try
            {
                // �L�[�����Z�b�g
                RmSlpPrtStWork rmSlpPrtStWork = new RmSlpPrtStWork();
                rmSlpPrtStWork.InqOtherEpCd = enterpriseCode;        // �⍇�����ƃR�[�h
                rmSlpPrtStWork.RmtSlpPrtDiv = rmtSlpPrtDiv;          // �����[�g�`���敪
                rmSlpPrtStWork.SlipPrtKind = slipPrtKind;            // �`�[������
                rmSlpPrtStWork.InqOriginalSecCd = sectionCode;       // �⍇�������_�R�[�h
                rmSlpPrtStWork.PccCompanyCode = customerCode;        // ���Ӑ�R�[�h

                //�����[�g�`���ݒ�}�X�^�ǂݍ���
                status1 = this._iRmSlpPrtStDB.Read(ref rmSlpPrtStWork, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʂ������o�R�s�[
                    rmSlpPrtSt = this.CopyToRmSlpPrtStFromRmSlpPrtStWork(rmSlpPrtStWork);
                }

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                rmSlpPrtSt = null;
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status1 = -1;
            }

            return status1;
        }

        #endregion

        // --------------------------------------------------
        #region Write Methods

        /// <summary>
        ///�������ݏ���
        /// </summary>
        /// <param name="RmSlpPrtSt">�����[�g�`���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Write(RmSlpPrtSt RmSlpPrtSt)
        {
            // �����[�g�`���ݒ�}�X�^�X�V
            return this.WriteProc(RmSlpPrtSt);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�������ݏ���
        /// </summary>
        /// <param name="RmSlpPrtSt">�����[�g�`���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int WriteProc(RmSlpPrtSt RmSlpPrtSt)
        {
            int status = 0;

            try
            {
                RmSlpPrtStWork rmSlpPrtStWork = new RmSlpPrtStWork();

                // �ҏW�O���擾
                if (this._rmSlpPrtStDic.ContainsKey(RmSlpPrtSt.EnterpriseCode) == true)
                {
                    rmSlpPrtStWork = (this._rmSlpPrtStDic[RmSlpPrtSt.EnterpriseCode] as RmSlpPrtStWork);
                }

                // �ҏW���擾
                CopyToRmSlpPrtStWorkFromDispRmSlpPrtSt(ref rmSlpPrtStWork, RmSlpPrtSt);

                object retObj = (object)rmSlpPrtStWork;

                //�����[�g�`���ݒ�}�X�^��������
                status = this._iRmSlpPrtStDB.Write(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�Z�b�g�ɒǉ�
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    rmSlpPrtStWork = (RmSlpPrtStWork)retArray[0];
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;

                    rmSlpPrtStWork.EnterpriseCode = keyConst;

                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region LogicalDelete Methods

        /// <summary>
        ///�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int LogicalDelete(string fileHeaderGuid)
        {
            // �����[�g�`���ݒ�}�X�^�_���폜
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�_���폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int LogicalDeleteProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                object retObj = (object)rmSlpPrtStWork;

                //�����[�g�`���ݒ�}�X�^�_���폜
                status = this._iRmSlpPrtStDB.LogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�Z�b�g�ɒǉ�
                    rmSlpPrtStWork = (RmSlpPrtStWork)retObj;
                    //-----ADD by huanghx for #25386 �_���폜�f�[�^�\���s�� on 20110921 ----->>>>>
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;
                    rmSlpPrtStWork.EnterpriseCode = keyConst;
                    //-----ADD by huanghx for #25386 �_���폜�f�[�^�\���s�� on 20110921 -----<<<<<
                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Revival Methods

        /// <summary>
        ///�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Revival(string fileHeaderGuid)
        {
            // �����[�g�`���ݒ�}�X�^����
            return this.RevivalProc(fileHeaderGuid);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int RevivalProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                object retObj = (object)rmSlpPrtStWork;

                //�����[�g�`���ݒ�}�X�^�_���폜����
                status = this._iRmSlpPrtStDB.RevivalLogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�Z�b�g�ɒǉ�
                    rmSlpPrtStWork = (RmSlpPrtStWork)retObj;
                    //-----ADD by huanghx for #25386 �_���폜�f�[�^�\���s�� on 20110921 ----->>>>>
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;
                    rmSlpPrtStWork.EnterpriseCode = keyConst;
                    //-----ADD by huanghx for #25386 �_���폜�f�[�^�\���s�� on 20110921 -----<<<<<
                    
                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Delete Methods

        /// <summary>
        ///�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Delete(string fileHeaderGuid)
        {
            // �����[�g�`���ݒ�}�X�^�����폜
            return this.DeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^�����폜����
        /// </summary>
        /// <param name="fileHeaderGuid">�����[�g�`���ݒ�}�X�^Guid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int DeleteProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(rmSlpPrtStWork);

                //�����[�g�`���ݒ�}�X�^�����폜
                status = this._iRmSlpPrtStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._rmSlpPrtStDic.Remove(rmSlpPrtStWork.EnterpriseCode);
                    // �f�[�^�e�[�u������폜
                    DataRow dr = this._rmSlpPrtStTable.Rows.Find(rmSlpPrtStWork.EnterpriseCode);

                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Search Methods

        /// <summary>
        ///��������(�_���폜����)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Search(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            // �����[�g�`���ݒ�}�X�^����
            return this.SearchProc(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        /// ���������i�_���폜�����ARmSlpPrtSt�̂�Search�j
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int SearchOnlyRmSlpPrtSt(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            return this.SearchProcOnlyRmSlpPrtSt(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        ///��������(�_���폜�܂�)
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            // �����[�g�`���ݒ�}�X�^����
            return this.SearchProc(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData01);

        }

        /// <summary>
        ///��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;
            int status = 0;


            // �`�[����ݒ�p���[ID�S�擾
            ArrayList slipPrtRetList = null;

            try
            {
                // �`�[����ݒ�p���[�J���t���O�ݒ�
                this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;
                status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);
            }
            catch { }


            if ((status == 0) && (slipPrtRetList != null) && (slipPrtRetList.Count > 0))
            {
                this._slipPrtSetPaperIdList = new SortedList();

                string key = "";

                foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
                {
                    //--------------------------------------------------------------------
                    // Key  �F�t�@�C�����C�A�E�g�̃L�[���ڂ���������
                    //   �ް����ͼ���(2��) + �`�[������(4��)�{�`�[����ݒ�p���[ID(24��)
                    // Value�F�`�[����ݒ�}�X�^�N���X
                    //--------------------------------------------------------------------
                    this._stringBuilder.Remove(0, this._stringBuilder.Length);
                    this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
                    this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
                    this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
                    key = this._stringBuilder.ToString();

                    this._slipPrtSetPaperIdList.Add(key, slipPrtSet);
                }
            }

            // �����[�g�`���ݒ�}�X�^����
            status1 = this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, inqOtherSecCd, logicalMode);


            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            if (totalCount > 0)
            {
                // �L���b�V������
                status2 = this.Cache(this._rmSlpPrtStWorkList);
            }
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }


            // �X�e�[�^�X���f
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^���������iRmSlpPrtSt�̂�Search�j
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchProcOnlyRmSlpPrtSt(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            return this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, inqOtherSecCd, logicalMode);
        }

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^��������
        /// </summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="inqOtherSecCd">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchSlipTypeMngProc(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._rmSlpPrtStWorkList.Clear();

                // �v���p�e�B�Z�b�g�p���X�g
                this._rmSlpPrtStList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._rmSlpPrtStDic.Clear();

                // �L�[�����Z�b�g
                RmSlpPrtStWork paramRmSlpPrtStWork = new RmSlpPrtStWork();
                paramRmSlpPrtStWork.InqOtherEpCd = enterpriseCode;    // ��ƃR�[�h
                paramRmSlpPrtStWork.InqOtherSecCd = inqOtherSecCd;    // ���_�R�[�h

                object retobj = null;


                //�����[�g�`���ݒ�}�X�^����
                status = this._iRmSlpPrtStDB.Search(out retobj, paramRmSlpPrtStWork, 0, logicalMode);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._rmSlpPrtStWorkList = retobj as ArrayList;

                    if (this._rmSlpPrtStWorkList != null && this._rmSlpPrtStWorkList.Count > 0)
                    {
                        // �v���p�e�B�Z�b�g�p���X�g�쐬
                        this._rmSlpPrtStList = this.CopyToRmSlpPrtStListFromRmSlpPrtStWorkList(this._rmSlpPrtStWorkList);
                        // �Y�������i�[
                        totalCount = this._rmSlpPrtStWorkList.Count;
                    }

                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception ex)
            {
                // �I�t���C������null���Z�b�g
                this._iRmSlpPrtStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// �}�X�^�L���b�V������
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">�`�[�Ǘ��}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Cache(ArrayList rmSlpPrtStWorkList)
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._rmSlpPrtStTable.BeginLoadData();

                    // �e�[�u�����N���A
                    this._rmSlpPrtStTable.Clear();

                    // �Ǘ��f�[�^��DataSet�Ɋi�[
                    foreach (RmSlpPrtStWork rmSlpPrtStWork in rmSlpPrtStWorkList)
                    {
                        switch (rmSlpPrtStWork.SlipPrtKind)
                        {
                            case 10:        // ���Ϗ�
                            case 30:        // ����`�[
                            case 120:       // �󒍓`�[
                            case 130:       // �ݏo�`�[
                            case 140:       // ���ϓ`�[
                            case 150:       // �݌Ɉړ��`�[
                            case 160:       // �t�n�d�`�[
                                {
                                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                                    break;
                                }
                        }
                    }
                }
                finally
                {
                    // �X�V�����I��
                    this._rmSlpPrtStTable.EndLoadData();

                    // �\�[�g
                    this._rmSlpPrtStTable.DefaultView.Sort = COL_SLIPPRTKIND_TITLE + " ASC";           // �`�[�����ʃR�[�h
                    this._rmSlpPrtStTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�R�s�[���� (��ʕύX�����[�g�`���ݒ�}�X�^�N���X�˃����[�g�`���ݒ�}�X�^���[�N�N���X)
        /// </summary>
        /// <param name="rmSlpPrtStWork">�����[�g�`���ݒ�}�X�^���[�N�N���X</param>
        /// <param name="RmSlpPrtSt">�����[�g�`���ݒ�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX�����[�g�`���ݒ�}�X�^�N���X����
        ///                  �����[�g�`���ݒ�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void CopyToRmSlpPrtStWorkFromDispRmSlpPrtSt(ref RmSlpPrtStWork rmSlpPrtStWork, RmSlpPrtSt RmSlpPrtSt)
        {
            rmSlpPrtStWork.CreateDateTime = RmSlpPrtSt.CreateDateTime;          // �쐬����  
            rmSlpPrtStWork.UpdateDateTime = RmSlpPrtSt.UpdateDateTime;          // �X�V����
            rmSlpPrtStWork.SlipPrtKind = RmSlpPrtSt.SlipPrtKind;                // �`�[������
            rmSlpPrtStWork.SlipPrtSetPaperId = RmSlpPrtSt.SlipPrtSetPaperId;    // �`�[����ݒ�p���[ID
            rmSlpPrtStWork.InqOriginalEpCd = RmSlpPrtSt.InqOriginalEpCd.Trim();        // �⍇������ƃR�[�h//@@@@20230303
            rmSlpPrtStWork.InqOriginalSecCd = RmSlpPrtSt.InqOriginalSecCd;      // �⍇�������_�R�[�h
            rmSlpPrtStWork.InqOtherEpCd = RmSlpPrtSt.InqOtherEpCd;              // �⍇�����ƃR�[�h
            rmSlpPrtStWork.InqOtherSecCd = RmSlpPrtSt.InqOtherSecCd;            // �⍇���拒�_�R�[�h
            rmSlpPrtStWork.RmtSlpPrtDiv = RmSlpPrtSt.RmtSlpPrtDiv;              // �����[�g�`���敪
            rmSlpPrtStWork.PccCompanyCode = RmSlpPrtSt.PccCompanyCode;          // ���Ӑ�R�[�h
            rmSlpPrtStWork.LogicalDeleteCode = RmSlpPrtSt.LogicalDeleteCode;    // �_���폜�敪
            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            rmSlpPrtStWork.TopMargin = RmSlpPrtSt.TopMargin;                                        // ��]��
            rmSlpPrtStWork.LeftMargin = RmSlpPrtSt.LeftMargin;                                       // ���]��
            // 2011.09.16 zhouzy UPDATE END <<<<<<

        }

        /// <summary>
        /// �����[�g�`������
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">�����[�g�`���擾���ʃ��X�g</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private ArrayList CopyToRmSlpPrtStListFromRmSlpPrtStWorkList(ArrayList rmSlpPrtStWorkList)
        {
            ArrayList retList = new ArrayList();
            foreach (RmSlpPrtStWork rmSlpPrtStWork in rmSlpPrtStWorkList)
            {
                switch (rmSlpPrtStWork.SlipPrtKind)
                {
                    case 10:        // ���Ϗ�
                    case 30:        // ����`�[
                    case 120:       // �󒍓`�[
                    case 130:       // �ݏo�`�[
                    case 140:       // ���ϓ`�[
                    case 150:       // �݌Ɉړ��`�[
                    case 160:       // �t�n�d�`�[
                        {
                            RmSlpPrtSt RmSlpPrtSt = this.CopyToRmSlpPrtStFromRmSlpPrtStWork(rmSlpPrtStWork);
                            retList.Add(RmSlpPrtSt);
                            break;
                        }
                }
            }
            return retList;
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�����[�g�`���ݒ�}�X�^���[�N�N���X�˃����[�g�`���ݒ�}�X�^�N���X)
        /// </summary>
        /// <param name="rmSlpPrtStWork">�����[�g�`���ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�����[�g�`���ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^���[�N�N���X����
        ///                  �����[�g�`���ݒ�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private RmSlpPrtSt CopyToRmSlpPrtStFromRmSlpPrtStWork(RmSlpPrtStWork rmSlpPrtStWork)
        {
            RmSlpPrtSt rmSlpPrtSt = new RmSlpPrtSt();
            string keyConst = "";
            rmSlpPrtSt.CreateDateTime = rmSlpPrtStWork.CreateDateTime;        // �쐬����
            rmSlpPrtSt.UpdateDateTime = rmSlpPrtStWork.UpdateDateTime;        // �X�V����
            rmSlpPrtSt.SlipPrtKind = rmSlpPrtStWork.SlipPrtKind;              // �`�[������
            rmSlpPrtSt.SlipPrtSetPaperId = rmSlpPrtStWork.SlipPrtSetPaperId;  // �`�[����ݒ�p���[ID
            rmSlpPrtSt.InqOriginalEpCd = rmSlpPrtStWork.InqOriginalEpCd.Trim();      // �⍇������ƃR�[�h//@@@@20230303
            rmSlpPrtSt.InqOriginalSecCd = rmSlpPrtStWork.InqOriginalSecCd;    // �⍇�������_�R�[�h
            rmSlpPrtSt.InqOtherEpCd = rmSlpPrtStWork.InqOtherEpCd;            // �⍇�����ƃR�[�h
            rmSlpPrtSt.InqOtherSecCd = rmSlpPrtStWork.InqOtherSecCd;          // �⍇���拒�_�R�[�h
            rmSlpPrtSt.RmtSlpPrtDiv = rmSlpPrtStWork.RmtSlpPrtDiv;            // �����[�g�`���敪
            rmSlpPrtSt.PccCompanyCode = rmSlpPrtStWork.PccCompanyCode;        // ���Ӑ�R�[�h
            rmSlpPrtSt.LogicalDeleteCode = rmSlpPrtStWork.LogicalDeleteCode;  // �_���폜�敪
            rmSlpPrtSt.FileHeaderGuid = rmSlpPrtStWork.FileHeaderGuid;        // GUID
            rmSlpPrtSt.UpdEmployeeCode = "";                                  // �X�V�]�ƈ��R�[�h
            rmSlpPrtSt.UpdAssemblyId1 = "";                                   // �X�V�A�Z���u��ID1
            rmSlpPrtSt.UpdAssemblyId2 = "";                                   // �X�V�A�Z���u��ID2
            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            rmSlpPrtSt.TopMargin = rmSlpPrtStWork.TopMargin;                                        // ��]��
            rmSlpPrtSt.LeftMargin = rmSlpPrtStWork.LeftMargin;                                       // ���]��
            // 2011.09.16 zhouzy UPDATE END <<<<<<

            // �����g��
            keyConst = rmSlpPrtSt.InqOriginalEpCd.Trim() + rmSlpPrtSt.InqOriginalSecCd.Trim() + rmSlpPrtSt.InqOtherEpCd.Trim() + rmSlpPrtSt.InqOtherSecCd.Trim() + rmSlpPrtSt.SlipPrtKind;

            rmSlpPrtStWork.EnterpriseCode = keyConst;
            rmSlpPrtSt.EnterpriseCode = rmSlpPrtStWork.EnterpriseCode;

            // �e�[�u���X�V
            _rmSlpPrtStDic[rmSlpPrtSt.EnterpriseCode] = rmSlpPrtStWork;

            return rmSlpPrtSt;
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����
        /// </summary>
        /// <param name="rmSlpPrtStWork">�����[�g�`���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void RmSlpPrtStWorkToDataSet(RmSlpPrtStWork rmSlpPrtStWork)
        {
            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            DataRow dr = this._rmSlpPrtStTable.Rows.Find(rmSlpPrtStWork.EnterpriseCode);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._rmSlpPrtStTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            #region �폜��
            // �폜��
            if (rmSlpPrtStWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", rmSlpPrtStWork.UpdateDateTime);
            }
            #endregion

            #region �`�[������ �`�[�����ʖ���
            // �`�[������
            dr[COL_SLIPPRTKINDID_TITLE] = rmSlpPrtStWork.SlipPrtKind;
            // �`�[�����ʖ���
            switch (rmSlpPrtStWork.SlipPrtKind)
            {
                case 10:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "���Ϗ�";
                        break;
                    }
                case 20:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�w����(������)";
                        break;
                    }
                case 21:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "���菑";
                        break;
                    }
                case 30:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�[�i��";
                        break;
                    }
                case 40:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�ԕi�`�[";
                        break;
                    }
                case 100:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "���[�N�V�[�g";
                        break;
                    }
                case 110:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�{�f�B���@�}";
                        break;
                    }
                case 120:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�󒍓`�[";
                        break;
                    }
                case 130:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�ݏo�`�[";
                        break;
                    }
                case 140:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "���ϓ`�[";
                        break;
                    }
                case 150:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�݌Ɉړ��`�[";
                        break;
                    }
                case 160:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "�t�n�d�`�[";
                        break;
                    }
            }
            #endregion

            #region ���Ӑ� ���Ӑ於
            // ���Ӑ�
            dr[COL_PCCCOMPANYCODE_TITLE] = rmSlpPrtStWork.PccCompanyCode;

            // �����ݒ�N���A
            object inParamObj = null;
            object outParamObj = null;
            // �����ݒ�
            inParamObj = rmSlpPrtStWork.PccCompanyCode;
            this.CheckCustomerCode(inParamObj, out outParamObj);
            // ���Ӑ於�̐ݒ�
            if ((outParamObj != null) &&
                (((ArrayList)outParamObj).Count == 2) &&
                (((ArrayList)outParamObj)[1] is string))
            {
                dr[COL_PCCCOMPANYCODENAME_TITLE] = (string)((ArrayList)outParamObj)[1];  // ���Ӑ於��
            }
            else
            {
                dr[COL_PCCCOMPANYCODENAME_TITLE] = "";
            }
            #endregion

            #region �`�[����ݒ�p���[ID ����
            // �`�[����ݒ�p���[ID 
            dr[COL_SLIPPRTSETPAPERID_TITLE] = rmSlpPrtStWork.SlipPrtSetPaperId;

            // �`�[����ݒ�p���[����
            dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(rmSlpPrtStWork);
            #endregion

            #region �����[�g�`���敪
            // �����[�g�`���敪 
            if (rmSlpPrtStWork.RmtSlpPrtDiv == 0)  // 0:���s���Ȃ�, 1:���s����
            {
                dr[COL_RMTSLPPRTDIV_TITLE] = "���s���Ȃ�";
            }
            else
            {
                dr[COL_RMTSLPPRTDIV_TITLE] = "���s����";
            }
            #endregion

            #region �R�[�h
            bool msgDiv;
            string errMsg;
            int i = 0;
            List<ScmEpCnect> scmEpCnectWorks = null;
            List<ScmEpScCnt> scmEpScCntWorks = null;
            ScmEpCnect aimScmEpCnectWork = null;
            ScmEpScCnt aimScmEpScCntWork = null;

            ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
            int status = scmEpScCntAcs.SearchAll(string.Empty, string.Empty, 0, out scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);


            //���_
            if (rmSlpPrtStWork.InqOriginalEpCd.Trim().Equals("00") && rmSlpPrtStWork.InqOriginalSecCd.Trim().Equals("00"))
            {
                //�⍇������ƃR�[�h
                dr[COL_INQORIGINALEPCD_TITLE] = "";
                dr[COL_INQORIGINALEPCDNAME_TITLE] = "";
                // �⍇�������_�R�[�h
                dr[COL_INQORIGINALSECCD_TITLE] = "";
                dr[COL_INQORIGINALSECCDNAME_TITLE] = "";

                // �⍇�����ƃR�[�h
                dr[COL_INQOTHEREPCD_TITLE] = rmSlpPrtStWork.InqOtherEpCd;

                for (i = 0; i < scmEpCnectWorks.Count; i++)
                {
                    if (scmEpCnectWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd)
                    {
                        aimScmEpCnectWork = scmEpCnectWorks[i] as ScmEpCnect;
                        dr[COL_INQOTHEREPCDNAME_TITLE] = aimScmEpCnectWork.CnectOtherEpNm;
                        break;
                    }

                }

                // �⍇���拒�_�R�[�h
                dr[COL_INQOTHERSECCD_TITLE] = rmSlpPrtStWork.InqOtherSecCd;
                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOtherSecCd == rmSlpPrtStWork.InqOtherSecCd)
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        dr[COL_INQOTHERSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOtherSecNm;
                        break;
                    }
                }

            }
            else//���Ӑ�
            {
                //�⍇������ƃR�[�h
                dr[COL_INQORIGINALEPCD_TITLE] = rmSlpPrtStWork.InqOriginalEpCd.Trim();//@@@@20230303
                // �⍇�������_�R�[�h
                dr[COL_INQORIGINALSECCD_TITLE] = rmSlpPrtStWork.InqOriginalSecCd;
                // �⍇�����ƃR�[�h
                dr[COL_INQOTHEREPCD_TITLE] = rmSlpPrtStWork.InqOtherEpCd;
                // �⍇���拒�_�R�[�h
                dr[COL_INQOTHERSECCD_TITLE] = rmSlpPrtStWork.InqOtherSecCd;

                for (i = 0; i < scmEpCnectWorks.Count; i++)
                {
                    if (scmEpCnectWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpCnectWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpCnectWork = scmEpCnectWorks[i] as ScmEpCnect;
                        dr[COL_INQOTHEREPCDNAME_TITLE] = aimScmEpCnectWork.CnectOtherEpNm;
                        dr[COL_INQORIGINALEPCDNAME_TITLE] = aimScmEpCnectWork.CnectOriginalEpNm;
                        break;
                    }

                }

                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        if (scmEpScCntWorks[i].CnectOtherSecCd == rmSlpPrtStWork.InqOtherSecCd)
                        {
                            dr[COL_INQOTHERSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOtherSecNm;
                            break;
                        }
                    }
                }

                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        if (scmEpScCntWorks[i].CnectOriginalSecCd == rmSlpPrtStWork.InqOriginalSecCd)
                        {
                            dr[COL_INQORIGINALSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOriginalSecNm;
                            break;
                        }
                    }
                }

            }

            // ���_���� �⍇�������_�R�[�h
            if ((int.Parse(rmSlpPrtStWork.InqOtherSecCd.Trim()) == 0))
            {
                // ���_�R�[�h���[���ŁA���Ӑ�R�[�h���ݒ肳��Ă��Ȃ�
                dr[COL_INQOTHERSECCDNAME_TITLE] = "�S�Ћ���";
            }
            else
            {
                dr[COL_INQOTHERSECCDNAME_TITLE] = GetSectionName(rmSlpPrtStWork.InqOtherSecCd);
            }
            #endregion

            #region ���̑�

            // GUID 
            dr[COL_GUID_TITLE] = rmSlpPrtStWork.EnterpriseCode;

            // �쐬����
            dr[COL_CREATEDATETIME_TITLE] = rmSlpPrtStWork.CreateDateTime;

            // �X�V����
            dr[COL_UPDATEDATETIME_TITLE] = rmSlpPrtStWork.UpdateDateTime;

            // �_���폜�敪
            dr[COL_LOGICALDELETECODE_TITLE] = rmSlpPrtStWork.LogicalDeleteCode;

            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            // ��]��
            dr[COL_TOPMARGIN_TITLE] = rmSlpPrtStWork.TopMargin;
            // ���]��
            dr[COL_LEFTMARGINE_TITLE] = rmSlpPrtStWork.LeftMargin;
            // 2011.09.16 zhouzy UPDATE END <<<<<<
            #endregion

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._rmSlpPrtStTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._rmSlpPrtStDic.ContainsKey(rmSlpPrtStWork.EnterpriseCode) == true)
            {
                this._rmSlpPrtStDic.Remove(rmSlpPrtStWork.EnterpriseCode);
            }
            this._rmSlpPrtStDic.Add(rmSlpPrtStWork.EnterpriseCode, rmSlpPrtStWork);
        }

        /// <summary>
        /// ���Ӑ�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:���� 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�G���[�`�F�b�N���s���܂��B</br>
        ///	<br>			 �����I�u�W�F�N�g:���Ӑ�R�[�h</br>
        ///	<br>			 ���ʃI�u�W�F�N�g:���Ӑ�}�X�^�������ʃX�e�[�^�X, ���Ӑ於��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void CheckCustomerCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // �����l�ݒ�
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // ���s�`�F�b�N
                //-------------------------------------------------------------
                if (inParamObj == null) return;             // ���͂Ȃ�
                if ((inParamObj is int) == false) return;   // ���͒l�h�����ȊO
                if ((int)inParamObj == 0) return;           // ���͒l�[��

                //-------------------------------------------------------------
                // ���Ӑ�}�X�^�Ǎ�
                //-------------------------------------------------------------
                CustomerInfo customerInfo = null;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
                outParamList.Add(status);	// ���Ӑ�}�X�^�X�e�[�^�X�ݒ�

                //-------------------------------------------------------------
                // ���Ӑ���ݒ�
                //-------------------------------------------------------------
                if (customerInfo != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.CustomerSnm);	// ���Ӑ旪�̐ݒ�
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

        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks> 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// ����ݒ�p���[���̖��̎擾����
        /// </summary>
        /// <param name="rmSlpPrtStWork">����ݒ�p���[ID</param>
        /// <returns>����ݒ�p���[����</returns>
        /// <remarks>
        /// <br>Note       : ����ݒ�p���[���̂��擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks> 
        private string GetSlipPrtSetPaperName(RmSlpPrtStWork rmSlpPrtStWork)
        {
            string slipPrtSetPaperName = "";

            foreach (DictionaryEntry de in this._slipPrtSetPaperIdList)
            {
                SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
                if (rmSlpPrtStWork.SlipPrtSetPaperId.TrimEnd().Equals(slipPrtSetWk.SlipPrtSetPaperId))
                {
                    slipPrtSetPaperName = slipPrtSetWk.SlipComment.TrimEnd();
                }
            }

            return slipPrtSetPaperName;

        }
        #endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="RmSlpPrtSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out RmSlpPrtSt RmSlpPrtSt)
        {
            int status = -1;
            RmSlpPrtSt = new RmSlpPrtSt();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add(GUIDE_INQOTHEREPCDRF_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                RmSlpPrtSt.SlipPrtKind = (int)retObj[GUIDE_SLIPPRTKIND_TITLE];                          // �`�[������
                RmSlpPrtSt.SlipPrtSetPaperId = retObj[GUIDE_SLIPPRTSETPAPERID_TITLE].ToString();        // ���[ID
                RmSlpPrtSt.InqOriginalSecCd = retObj[GUIDE_INQORIGINALSECCD_TITLE].ToString();          // �⍇������ƃR�[�h
                RmSlpPrtSt.InqOriginalEpCd = retObj[GUIDE_INQORIGINALEPCDRF_TITLE].ToString().Trim();          // �⍇�������_�R�[�h//@@@@20230303
                RmSlpPrtSt.InqOtherEpCd = retObj[GUIDE_INQOTHEREPCDRF_TITLE].ToString();                // �⍇�����ƃR�[�h
                RmSlpPrtSt.InqOtherSecCd = retObj[GUIDE_INQOTHERSECCD_TITLE].ToString();                // �⍇���拒�_�R�[�h
                RmSlpPrtSt.RmtSlpPrtDiv = (int)retObj[GUIDE_RMTSLPPRTDIV_TITLE];                        // �����[�g�`���敪
                RmSlpPrtSt.PccCompanyCode = (int)retObj[GUIDE_PPCCCOMPANYCODE_TITLE];                   // ���Ӑ�R�[�h

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string inqOtherSeCd = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey(GUIDE_INQOTHEREPCDRF_TITLE))
            {
                enterpriseCode = inParm[GUIDE_INQOTHEREPCDRF_TITLE].ToString();
                inqOtherSeCd = inParm[GUIDE_INQOTHERSECCD_TITLE].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // �}�X�^�e�[�u���Ǎ���
            int iCnt = 0;
            status = Search(out iCnt, enterpriseCode, inqOtherSeCd);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �K�C�h�����N�����̓J�����ݒ�������Ȃ�
                        if (guideList.Tables.Count == 0)
                        {
                            DataTable table = new DataTable();
                            DataColumn column;

                            // �`�[������
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKINDID_TITLE;
                            table.Columns.Add(column);
                            // �`�[�����ʖ�
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
                            table.Columns.Add(column);
                            // �⍇������ƃR�[�h
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALEPCDRF_TITLE;
                            table.Columns.Add(column);
                            // �⍇������Ɩ�
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALEPCDRFNAME_TITLE;
                            table.Columns.Add(column);
                            // �⍇�������_�R�[�h
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALSECCD_TITLE;
                            table.Columns.Add(column);
                            // �⍇�������_��
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALSECCDNAME_TITLE;
                            table.Columns.Add(column);
                            // �⍇�����ƃR�[�h
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHEREPCDRF_TITLE;
                            table.Columns.Add(column);
                            // �⍇�����Ɩ�
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHEREPCDRFNAME_TITLE;
                            table.Columns.Add(column);
                            // �⍇���拒�_�R�[�h
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHERSECCD_TITLE;
                            table.Columns.Add(column);
                            // �⍇���拒�_��
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHERSECCDNAME_TITLE;
                            table.Columns.Add(column);
                            // ���Ӑ�R�[�h
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_PPCCCOMPANYCODE_TITLE;
                            table.Columns.Add(column);
                            // ���Ӑ於
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_PPCCCOMPANYCODENAME_TITLE;
                            table.Columns.Add(column);
                            // �`�[����ݒ�p���[ID
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
                            table.Columns.Add(column);
                            // �����[�g�`���敪
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_RMTSLPPRTDIV_TITLE;
                            table.Columns.Add(column);

                            guideList.Tables.Add(table.Clone());
                        }

                        // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                        GetGuideDataSet(ref guideList, mode);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    {
                        status = -1;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
        /// <param name="mode">�ėp�K�C�h�\���ؑ�(0:�ʏ�\�� 5:�S���\��)</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, int mode)
        {
            int dataCnt = 0;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();
            switch (mode)
            {
                // �ʏ�\��
                case 0:
                // �S���\��
                case 5:
                    {
                        while (dataCnt < this._rmSlpPrtStTable.Rows.Count)
                        {
                            // �_���폜�敪:�L��
                            if ((string)this._rmSlpPrtStTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                dr[GUIDE_SLIPPRTKINDID_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTKINDID_TITLE];                // �`�[������
                                dr[GUIDE_SLIPPRTKIND_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTKIND_TITLE];                    // �`�[������
                                dr[GUIDE_SLIPPRTSETPAPERID_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTSETPAPERID_TITLE];        // �`�[����ݒ�p���[ID
                                dr[GUIDE_INQORIGINALEPCDRF_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALEPCD_TITLE];          // �⍇������ƃR�[�h
                                dr[GUIDE_INQORIGINALEPCDRFNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALEPCDNAME_TITLE];  // �⍇������Ɩ�
                                dr[GUIDE_INQORIGINALSECCD_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALSECCD_TITLE];          // �⍇�������_�R�[�h
                                dr[GUIDE_INQORIGINALSECCDNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALSECCDNAME_TITLE];  // �⍇�������_��
                                dr[GUIDE_INQOTHEREPCDRF_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHEREPCD_TITLE];                // �⍇�����ƃR�[�h
                                dr[GUIDE_INQOTHEREPCDRFNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHEREPCDNAME_TITLE];        // �⍇�����Ɩ�
                                dr[GUIDE_INQOTHERSECCD_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHERSECCD_TITLE];                // �⍇���拒�_�R�[�h
                                dr[GUIDE_INQOTHERSECCDNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHERSECCDNAME_TITLE];        // �⍇���拒�_��
                                dr[GUIDE_RMTSLPPRTDIV_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_RMTSLPPRTDIV_TITLE];                  // �����[�g�`���敪
                                dr[GUIDE_PPCCCOMPANYCODE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_PCCCOMPANYCODE_TITLE];             // PCC���ЃR�[�h
                                dr[GUIDE_PPCCCOMPANYCODENAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_PCCCOMPANYCODENAME_TITLE];     // PCC���ЃR�[�h
                                dr[GUIDE_CREATEDATETIME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_CREATEDATETIME_TITLE];              // �쐬����
                                dr[GUIDE_UPDATEDATETIME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_UPDATEDATETIME_TITLE];              // �X�V����
                                dr[GUIDE_LOGICALDELETECODE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_LOGICALDELETECODE_TITLE];        // �_���폜�敪
                                // 2011.09.16 zhouzy UPDATE STA >>>>>>
                                dr[GUIDE_TOPMARGIN_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_TOPMARGIN_TITLE];              // ��]��
                                dr[GUIDE_LEFTMARGINE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_LEFTMARGINE_TITLE];        // ���]��
                                // 2011.09.16 zhouzy UPDATE END <<<<<<

                                retDataSet.Tables[0].Rows.Add(dr);
                            }
                            dataCnt++;
                        }
                        break;
                    }
            }
            retDataSet.Tables[0].EndLoadData();
        }

        #endregion

        // --------------------------------------------------
        #region ��r�p�N���X

        /// <summary>
        ///�����[�g�`���ݒ�}�X�^��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public class RmSlpPrtStCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>
            /// ��r�p���\�b�h
            /// </summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : �����[�g�`���ݒ�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : ������</br>
            /// <br>Date       : 2011.08.03</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                RmSlpPrtSt obj1 = x as RmSlpPrtSt;
                RmSlpPrtSt obj2 = y as RmSlpPrtSt;

                // �`�[�����ʂŔ�r
                return obj1.SlipPrtKind.CompareTo(obj2.SlipPrtKind);
            }

            #endregion
        }

        #endregion

    }
}
