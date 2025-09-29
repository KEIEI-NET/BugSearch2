//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n 
// �C �� ��  2011/02/01  �C�����e : �X�V�����擾�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/07/29  �C�����e : SCM�Ή� ���_�Ǘ�(10704767-00)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/24  �C�����e : Redmine #23808�\�[�X���r���[���ʂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/29  �C�����e : Redmine #24050�\�[�X���r���[���ʂ̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/08/31  �C�����e : Redmine #24278: �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/09 �C�����e :  Redmine#246331�`�[6���ׂ̃G���[�ڍׂ��\��������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2011/09/29 �C�����e :  �G���[�`�F�b�N���A�����`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : dingjx
// �C �� ��  2011/11/01 �C�����e :  Redmine#26228���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : x_chenjm
// �C �� ��  2011/11/01  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/29  �C�����e : Redmine #8136 ���_�Ǘ��^��M�����̒��`�F�b�N�����ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine #8293 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : 杍^
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using System.Data;
using Microsoft.Win32;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��M�f�[�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����͂̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate     : ���m�@2009.04.28 �f�[�^�ǉ�</br>
    /// </remarks>
    public class DataReceiveInputAcs
    {
        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region ��Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
        private DataReceiveInputAcs()
        {
            this._secMngConnectStAcs = new SecMngConnectStAcs();
            this._sendSetAcs = new SendSetAcs();
        }

        /// <summary>
        /// �d�����̓A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�d�����̓A�N�Z�X�N���X �C���X�^���X</returns>
        public static DataReceiveInputAcs GetInstance()
        {
            if (_dataReceiveInputAcs == null)
            {
                _dataReceiveInputAcs = new DataReceiveInputAcs();
            }

            return _dataReceiveInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�2
        // ===================================================================================== //
        # region ��Private Members
        private static DataReceiveInputAcs _dataReceiveInputAcs;
        private DataReceive _dataReceive;
        private DataTable _resultDataTable;
        private DataReceive.DataReceiveConditionDataTable _conditionDataTable;
        private IDCControlDB _dCControlDB = null;
        private IAPSendMessageDB _extraAddUpdControlDB = null;
        private ISndRcvHisDB _extraRcvHisDB = null;//ADD 2011/07/30 SCM�Ή� ���_�Ǘ�(10704767-00)
        private ISKControlDB _skControlDB = null;
        private ArrayList _secMngSetWorkList = new ArrayList();
        //ADD 2011/08/31 Redmine #24278 ------------------>>>>>
        private ISectionInfo _iSecInfo = null;
        private Hashtable secInfoSetWorkHash = new Hashtable();
        //ADD 2011/08/31 Redmine #24278 ------------------<<<<<
        // ���_�Ǘ��ڑ���ݒ�A�N�Z�X
        private SecMngConnectStAcs _secMngConnectStAcs;
        // ����M�Ώېݒ�̃A�N�Z�X
        SendSetAcs _sendSetAcs;
        ArrayList _sendDataList = new ArrayList();
        // �X�V����
        private int salesSlipCount = 0;
        private int salesDetailCount = 0;
        private int salesHistoryCount = 0;
        private int salesDtlHistCount = 0;
        private int depsitMainCount = 0;
        private int depsitDtlCount = 0;
        private int stockSlipCount = 0;
        private int stockDetailCount = 0;
        private int stockHistoryCount = 0;
        private int stockDtlHistCount = 0;
        private int paymentSlpCount = 0;
        private int paymentDtlCount = 0;
        private int acceptOdrCount = 0;
        private int acceptOdrCarCount = 0;
        //DEL 2011/08/29  #24050 ------->>>>>
        //private int mTtlSalesSlipCount = 0;
        //private int goodsSalesSlipCount = 0;
        //private int mTtlStockSlipCount = 0;
        //DEL 2011/08/29  #24050 -------<<<<<
        // �� 2009.04.28 liuyang add
        private int stockAdjustCount = 0;
        private int stockAdjustDtlCount = 0;
        private int stockMoveCount = 0;
        private int stockAcPayHistCount = 0;        
        // �� 2009.04.28 liuyang add
        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------>>>>>
        private int depositAlwCount = 0;            //��������
        private int rcvDraftDataCount = 0;          //����`�f�[�^
        private int payDraftDataRF = 0;             //�x����`�f�[�^
        private bool _doSalesSlipFlg = false;       //����v�ۃt���O
        private bool _doSalesDetailFlg = false;     //���㖾�חv�ۃt���O
        private bool _doAcceptOdrCarFlg = false;    //�󒍃}�X�^�i�ԗ��j�v�ۃt���O
        private bool _doAcceptOdrFlg = false;       //�󒍃}�X�^�v�ۃt���O
        private bool _doSalesHistoryFlg = false;    //���㗚��v�ۃt���O
        private bool _doSalesHistDtlFlg = false;    //���㗚�𖾍חv�ۃt���O
        private bool _doDepsitMainFlg = false;      //�����v�ۃt���O
        private bool _doDepsitDtlFlg = false;       //�������חv�ۃt���O
        private bool _doStockSlipFlg = false;       //�d���v�ۃt���O
        private bool _doStockDetailFlg = false;     //�d�����חv�ۃt���O
        private bool _doStockSlipHistFlg = false;   //�d������v�ۃt���O
        private bool _doStockSlHistDtlFlg = false;  //�d�����𖾍חv�ۃt���O
        private bool _doPaymentSlpFlg = false;      //�x���`�[�v�ۃt���O
        private bool _doPaymentDtlFlg = false;      //�x�����חv�ۃt���O
        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------<<<<<
        private bool _autoSendRecvDiv = false;//true:����,false:�蓮//ADD 2011/08/31 Redmine #24278: �f�[�^������M�������N�����܂���

        private string[] updateData = new string[] { "����f�[�^", "���㖾�׃f�[�^", "���㗚���f�[�^", "���㗚�𖾍׃f�[�^",
            "�����f�[�^", "�������׃f�[�^", "�d���f�[�^", "�d�����׃f�[�^", "�d�������f�[�^", "�d�����𖾍׃f�[�^", "�x���f�[�^", "�x�����׃f�[�^",
            "�󒍃}�X�^", "���q���f�[�^", "���㌎���W�v�f�[�^", "���i�ʔ��㌎���W�v�f�[�^", "�d�������W�v�f�[�^", "�݌Ɏd���f�[�^",
            "�݌Ɏd�����׃f�[�^", "�݌Ɉړ��f�[�^", "�݌Ɏ󕥗����f�[�^"};

        # endregion

        // ===================================================================================== //
        // �O���ɒ񋟂���萔�Q
        // ===================================================================================== //
        # region ��Public Readonly Members
        // private static readonly int defaultRowCount = 21;
        private static readonly string ctTableName_DataReceiveResult = "DataReceiveResult";
        private static readonly string ZERO_0 = "0";
        private static readonly string PROGRAM_ID = "PMKYO01103A";
        private static readonly string PROGRAM_NAME = "�f�[�^��M����";
        //private static readonly string TABLENAME_SALESSLIP = "����f�[�^";
        //private static readonly string TABLENAME_SALESDETAIL = "���㖾�׃f�[�^";
        //private static readonly string TABLENAME_SALESHISTORY = "���㗚���f�[�^";
        //private static readonly string TABLENAME_SALESHISTDTL = "���㗚�𖾍׃f�[�^";
        //private static readonly string TABLENAME_DEPSITMAIN = "�����f�[�^";
        //private static readonly string TABLENAME_DEPSITDTL = "�������׃f�[�^";
        //private static readonly string TABLENAME_STOCKSLIP = "�d���f�[�^";
        //private static readonly string TABLENAME_STOCKDETAIL = "�d�����׃f�[�^";
        //private static readonly string TABLENAME_STOCKSLIPHIST = "�d�������f�[�^";
        //private static readonly string TABLENAME_STOCKSLHISTDTL = "�d�����𖾍׃f�[�^";
        //private static readonly string TABLENAME_PAYMENTSLP = "�x���f�[�^";
        //private static readonly string TABLENAME_PAYMENTDTL = "�x�����׃f�[�^";
        //private static readonly string TABLENAME_ACCEPTODR = "�󒍃}�X�^";
        //private static readonly string TABLENAME_ACCEPTODRCAR = "���q���f�[�^";
        //private static readonly string TABLENAME_MTTLSALESSLIP = "���㌎���W�v�f�[�^";
        //private static readonly string TABLENAME_GOODSMTTLSASLIP = "���i�ʔ��㌎���W�v�f�[�^";
        //private static readonly string TABLENAME_MTTLSTOCKSLIP = "�d�������W�v�f�[�^";
        // �� 2009.04.28 liuyang add
        // private static readonly string TABLENAME_STOCKADJUST = "�݌Ɏd���f�[�^";
        // private static readonly string TABLENAME_STOCKADJUSTDTL = "�݌Ɏd�����׃f�[�^";
        // private static readonly string TABLENAME_STOCKMOVE = "�݌Ɉړ��f�[�^";
        // private static readonly string TABLENAME_STOCKACPAYHIST = "�݌Ɏ󕥗����f�[�^";
        // �� 2009.04.28 liuyang add
        private static readonly string COUNTNAME = "��";
        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------>>>>>
        private static readonly string ERRORMSG001 = "�O�񌎎��X�V���ȑO�ł�";
        private static readonly string ERRORMSG002 = "�O�񐿋����ȑO�ł�";
        private static readonly string ERRORMSG003 = "�O��x�����ȑO�ł�";
        private static readonly string ERRORMSG004 = "��������M�G���[";
        private static readonly string ERRORMSGSPACE = "�@";
        private const string ALL_SECTIONCODE = "00";
        private const string PROGRAMID = "PMKYO01100U";
        private const string PROGRAMNAME = "������M";        
        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------<<<<<

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties

        /// <summary>
        /// �f�[�^��M���ʃe�[�u���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        public ArrayList SecMngSetWorkList
        {
            get { return _secMngSetWorkList; }
        }
        //ADD 2011/08/31 Redmine #24278-------------->>>>>
        /// <summary>
        /// �����蓮�敪
        /// </summary>
        public Boolean AutoSendRecvDiv
        {
            get { return _autoSendRecvDiv; }
            set { _autoSendRecvDiv = value; }
        }
        //ADD 2011/08/31 Redmine #24278--------------<<<<<
        #endregion


        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ��Public Methods
        /// <summary>
        /// ���쌠���ݒ��UI�p�f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���ݒ��UI�p�f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public DataReceive DataReceive
        {
            get
            {
                if (_dataReceive == null)
                {
                    // �X�V�e�[�u���ݒ�
                    _dataReceive = new DataReceive();
                    _dataReceive.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
                    this._resultDataTable = _dataReceive.Tables[ctTableName_DataReceiveResult];
                    this._conditionDataTable = _dataReceive.DataReceiveCondition;
                    InitializeSettingDataSet();
                }
                return _dataReceive;
            }
        }

        /// <summary>
        /// �X�V�p�f�[�^�Z�b�g�����������܂��B
        /// </summary>
        private void InitializeSettingDataSet()
        {
            this._resultDataTable.BeginLoadData();
            try
            {
                // �X�V�O���b�h��ݒ肷��
                // �ԍ�
                this._resultDataTable.Columns.Add(this._dataReceive.Setting.ResultRowNoColumn.ColumnName, typeof(int));
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultRowNoColumn.ColumnName].DefaultValue = 0;
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultRowNoColumn.ColumnName].Caption = this._dataReceive.Setting.ResultRowNoColumn.Caption;
                // �X�V�f�[�^
                this._resultDataTable.Columns.Add(this._dataReceive.Setting.ResultNameColumn.ColumnName, typeof(string));
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultNameColumn.ColumnName].DefaultValue = string.Empty;
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultNameColumn.ColumnName].Caption = this._dataReceive.Setting.ResultNameColumn.Caption;
                // �X�V����
                for (int i = 0; i < _secMngSetWorkList.Count; i++)
                {
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------------------------------->>>>>
                    //APSecMngSetWork secMngSetWork = (APSecMngSetWork)this._secMngSetWorkList[i];
                    //this._resultDataTable.Columns.Add(secMngSetWork.SectionCode, typeof(string));
                    //this._resultDataTable.Columns[secMngSetWork.SectionCode].DefaultValue = string.Empty;
                    //this._resultDataTable.Columns[secMngSetWork.SectionCode].Caption = secMngSetWork.SectionGuideNm;
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -------------------------------------------------<<<<<
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------------------------------->>>>>
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._secMngSetWorkList[i];
                    this._resultDataTable.Columns.Add(sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString(), typeof(string));
					this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].DefaultValue = string.Empty;
					//this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].Caption = GetSectionName(sndRcvHisWork.SectionCode);
					this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].Caption = GetSectionName(sndRcvHisWork.SectionCode) + "(" + GetSectionName(sndRcvHisWork.ExtraObjSecCode)+")";
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -------------------------------------------------<<<<<
                }
            }
            finally
            {
                this._resultDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// �f�[�^�Đݒ�
        /// </summary>
        public void DataSetAgain()
        {
            // �X�V�e�[�u���ݒ�
            _dataReceive = new DataReceive();
            _dataReceive.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
            this._resultDataTable = _dataReceive.Tables[ctTableName_DataReceiveResult];
            this._conditionDataTable = _dataReceive.DataReceiveCondition;
            InitializeSettingDataSet();
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods
        /// <summary>
        /// �f�[�^��M���ʃe�[�u���̏����ݒ���s���܂��B
        /// </summary>
        public void DataReceiveResultRowInitialSetting()
        {
            this._resultDataTable.BeginLoadData();
            // �O���b�h���e���N���A����
            this._resultDataTable.Rows.Clear();

            // �s����ݒ肷��
            for (int i = 1; i <= this._sendDataList.Count; i++)
            {
                DataRow row = this._resultDataTable.NewRow();
                row[this._dataReceive.Setting.ResultRowNoColumn.ColumnName] = i;
                row[this._dataReceive.Setting.ResultNameColumn.ColumnName] = updateData[i - 1];

                this._resultDataTable.Rows.Add(row);
            }
            this._resultDataTable.EndLoadData();
        }

        /// <summary>
        /// �f�[�^��M���ʃe�[�u���̏����ݒ���s���܂��B
        /// </summary>
        public void DataReceiveConditionRowInitialSetting()
        {
            this._conditionDataTable.BeginLoadData();
            // �O���b�h���e���N���A����
            this._conditionDataTable.Rows.Clear();

            // �s����ݒ肷��
            for (int i = 1; i <= _secMngSetWorkList.Count; i++)
            {
                #region DEL
                //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                //APSecMngSetWork secMngSetWork = (APSecMngSetWork)_secMngSetWorkList[i - 1];

                //DataReceive.DataReceiveConditionRow row = this._conditionDataTable.NewDataReceiveConditionRow();
                //row.ConditionSectionCd = secMngSetWork.SectionCode;
                //row.ConditionSectionNm = secMngSetWork.SectionGuideNm;
                //// �J�n����
                //string startDateTime = Convert.ToString(secMngSetWork.SyncExecDate);
                //row.ConditionStartDate = secMngSetWork.SyncExecDate.Date;
                //row.ConditionStartTime = secMngSetWork.SyncExecDate.TimeOfDay.ToString().Substring(0, 8);
                //// �I������
                //string endDateTime = Convert.ToString(DateTime.Now);
                //row.ConditionEndDate = DateTime.Now.Date;
                //row.ConditionEndTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                #endregion
                //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                SndRcvHisWork sndRcvEtrWork = (SndRcvHisWork)_secMngSetWorkList[i - 1];
                DataReceive.DataReceiveConditionRow row = this._conditionDataTable.NewDataReceiveConditionRow();
                row.ConditionSectionCd = sndRcvEtrWork.SectionCode;
                row.ConditionSectionNm = GetSectionName(sndRcvEtrWork.SectionCode);
                row.ConditionDestSectionCd = sndRcvEtrWork.ExtraObjSecCode;
                row.ConditionDestSectionNm = GetSectionName(sndRcvEtrWork.ExtraObjSecCode);
                // ----- ADD xupz 2011/11/01 ---------->>>>>
                if (sndRcvEtrWork.SndLogExtraCondDiv == 0)
                {
                    row.ConditionExtraConDiv = "����";
                }
                else if (sndRcvEtrWork.SndLogExtraCondDiv == 1)
                {
                    row.ConditionExtraConDiv = "�`�[���t";
                }
                // ----- ADD xupz 2011/11/01 ----------<<<<<
                row.ConditionDestSectionNm = GetSectionName(sndRcvEtrWork.ExtraObjSecCode);


                // �J�n����
                DateTime startDateTime = sndRcvEtrWork.SndObjStartDate;
                row.ConditionStartDate = startDateTime.Date;
                row.ConditionStartTime = startDateTime.TimeOfDay.ToString().Substring(0, 8);
                // �I������
                DateTime endDateTime = sndRcvEtrWork.SndObjEndDate;
                row.ConditionEndDate = endDateTime.Date;
                row.ConditionEndTime = endDateTime.TimeOfDay.ToString().Substring(0, 8);
                //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<

                this._conditionDataTable.AddDataReceiveConditionRow(row);
            }

            this._conditionDataTable.EndLoadData();
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/07/30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>
            if (String.IsNullOrEmpty(sectionCode))
            {
                return sectionName;
            }
            else
            {
                sectionCode = sectionCode.Trim();
            }
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���--------------<<<<<
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S��";
                return sectionName;
            }
            #region DEL
            //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>
            //ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();

            //try
            //{
            //    foreach(SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            //    {
            //        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
            //        {
            //            sectionName = secInfoSet.SectionGuideNm.Trim();
            //            return sectionName;
            //        }
            //    }
            //}
            //catch
            //{
            //    sectionName = string.Empty;
            //}
            //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���--------------<<<<<
            #endregion
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���-------------->>>>>
            if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
            {
                GetSecInfoSetWork(sectionCode);
            }
            if(secInfoSetWorkHash.Contains(sectionCode))
            {
                sectionName = secInfoSetWorkHash[sectionCode].ToString();
            }
            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���--------------<<<<<
            
            return sectionName;
        }
        /// <summary>
        /// ���_�ݒ�}�X�^�擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���_�ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2011/08/31</br>
        /// </remarks>
        private int GetSecInfoSetWork(string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secInfoSetWorkHash = new Hashtable();
            if (_iSecInfo == null)
            {
                _iSecInfo = (ISectionInfo)MediationSectionInfo.GetSectionInfo();
            }
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

            //�L�[�̐ݒ�
            secInfoSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            secInfoSetWork.SectionCode = sectionCode;

            object paraobj = secInfoSetWork;
            object retobj = null;

            int errorLevel;
            string errorCode;
            string errorMessage;

            ArrayList wkSecInfoSetWorkList = null;
            status = _iSecInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
  
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList AList = retobj as ArrayList;
                foreach (object obj in AList)
                {
                    ArrayList wkal = obj as ArrayList;
                    if (wkal.Count > 0)
                    {
                        if (wkal[0] is SecInfoSetWork) wkSecInfoSetWorkList = wkal;
                    }
                }
                //���_���̂�HashTable�Ɋi�[
                foreach (SecInfoSetWork sec in wkSecInfoSetWorkList)
                {
                    //secInfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);//DEL 2011/08/31 Redmine #24278
                    secInfoSetWorkHash.Add(sec.SectionCode.Trim(), sec.SectionGuideNm);//ADD 2011/08/31 Redmine #24278
                }
            }
            return status;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int ReadInitData()
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region DEL
            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
            //ArrayList secMngSetWork = null;
            //string msg = "";            
            
            //// ���_�R���g���[��
            //if (this._extraAddUpdControlDB == null)
            //{
            //    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
            //}

            //// ��ʏ���������            
            //stauts = this._extraAddUpdControlDB.SearchSecMngSetData(LoginInfoAcquisition.EnterpriseCode, out secMngSetWork, out msg);
            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
            #endregion

            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
            object secMngSetWork = new object();
            SndRcvHisCondWork sndRcvHisWork = new SndRcvHisCondWork();
            // ���_�R���g���[��
            if (this._extraRcvHisDB == null)
            {
                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
            }

            sndRcvHisWork.Kind = 0;                 //0:�f�[�^�@1:�}�X�^
            sndRcvHisWork.SendOrReceiveDivCd = 0;   //0:���M�i�o�́j,1:��M�i�捞�j
            sndRcvHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //sndRcvHisWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278: �f�[�^������M�������N�����܂���
            //ADD 2011/08/31 Redmine #24278: �f�[�^������M�������N�����܂��� ---------->>>>>
            string belongSectionCode = string.Empty;
            if (_autoSendRecvDiv)
            {
                stauts = GetBelongSectionCodeFormXml(ref belongSectionCode);
                if(stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return stauts;
                }
                sndRcvHisWork.SectionCode = belongSectionCode;
            }
            else
            {
                sndRcvHisWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }            
            //ADD 2011/08/31 Redmine #24278: �f�[�^������M�������N�����܂��� ----------<<<<<
            // ��ʏ���������
            stauts = this._extraRcvHisDB.Search(sndRcvHisWork, out secMngSetWork);
            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<

            //if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL || stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
            {
                _secMngSetWorkList = new ArrayList();
                // ���ʂ�ۑ�����
                if (((ArrayList)secMngSetWork).Count > 0)
                {
                    //_secMngSetWorkList.AddRange((ArrayList)secMngSetWork);
                    for (int k = 0; k < ((ArrayList)secMngSetWork).Count; k++)
                    {
                        if (((ArrayList)secMngSetWork)[k] is ArrayList)
                        {
                        }
                        else
                        {
                            _secMngSetWorkList.Add(((ArrayList)secMngSetWork)[k]);
                        }
                    }
                    
                }
            }

            return stauts;
        }
        
        /// <summary>
        /// �����_�R�[�h���擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>		
        /// <br>Note		: �����_�R�[�h�擾�������s���B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date		: 2011.09.01</br>
        /// </remarks>
        private int GetBelongSectionCodeFormXml(ref string belongSectionCode)
        {       
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ServiceFilesInputAcs sfInputAcs = ServiceFilesInputAcs.GetInstance();
            string msg = string.Empty;
            int flg = 0;
            stauts = sfInputAcs.SearchForAutoSendRecv(ref msg, ref flg);
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                belongSectionCode = sfInputAcs.SecInfo.SecInfo.Rows[0][0].ToString();
            }
            return stauts;
        }        

        /// <summary>
        /// �����E�����̃`�F�b�N
        /// </summary>
        /// <param name="errMsgList">�߂�G���[���b�Z�[�W���X�g</param>
        /// <param name="errMsg">�߂�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>		
        /// <br>Note		: �����E�����̃`�F�b�N�������s���B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date		: 2011.07.29</br>
        /// </remarks>
        public bool CheckData(out ArrayList errMsgList,ref string errMsg)
        {
            errMsgList = new ArrayList();
            ArrayList errInfoList = new ArrayList();
            errMsg = "";

            try
            {
                ArrayList paramWorkList = new ArrayList();
                DateTime prevTotalDay;          //����O������X�V���t
                DateTime prevTotalDayMonthly;   //����O�񌎎��X�V���t
                DateTime prevTotalDayPayment;          //�d���O������X�V���t
                DateTime prevTotalDayPaymentMonthly;   //�d���O�񌎎��X�V���t
                DateTime hisTotalDay;       //����N�_���t
                DateTime hisTotalDayPayment;//�d���N�_���t
                DateTime hisTotalDayMin;       //����Min
                DateTime hisTotalDayPaymentMin;//�d��Min
                string errorInfo = "";
                string errorMsgMin = "";
                string errorMsgPayment = "";
                string errorMsgPaymentMin = "";
                bool saleCheckFlg = false;      //����`�F�b�N�t���O
                bool depsitCheckFlg = false;    //�����`�F�b�N�t���O
                bool stockCheckFlg = false;     //�d���`�F�b�N�t���O
                bool paymentCheckFlg = false;   //�x�����`�F�b�N�t���O

                //1.���E�����`�F�b�N�N�_���t�̎擾
                TotalDayCalculator toalDayCalculator = TotalDayCalculator.GetInstance();
                //������E�������t�̎擾
                toalDayCalculator.GetHisTotalDayDmdC(string.Empty, out prevTotalDay);                //�O������X�V���t�̎擾                
                toalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDayMonthly);
                if (prevTotalDay.CompareTo(prevTotalDayMonthly) > 0)
                {
                    hisTotalDay = prevTotalDay;
                    hisTotalDayMin = prevTotalDayMonthly;
                    errorInfo = ERRORMSG002;
                    errorMsgMin = ERRORMSG001;
                }
                else
                {
                    hisTotalDay = prevTotalDayMonthly;
                    hisTotalDayMin = prevTotalDay;
                    errorInfo = ERRORMSG001;
                    errorMsgMin = ERRORMSG002;
                }

                //�d�����E�������t�̎擾                
                toalDayCalculator.GetHisTotalDayPayment(string.Empty, out prevTotalDayPayment);             //�O������X�V���t�̎擾
                toalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDayPaymentMonthly);   //�O�񌎎��X�V���t�̎擾
                if (prevTotalDayPayment.CompareTo(prevTotalDayPaymentMonthly) > 0)
                {
                    hisTotalDayPayment = prevTotalDayPayment;
                    hisTotalDayPaymentMin = prevTotalDayPaymentMonthly;
                    errorMsgPayment = ERRORMSG003;
                    errorMsgPaymentMin = ERRORMSG001;
                }
                else
                {
                    hisTotalDayPayment = prevTotalDayPaymentMonthly;
                    hisTotalDayPaymentMin = prevTotalDayPayment;
                    errorMsgPayment = ERRORMSG001;
                    errorMsgPaymentMin = ERRORMSG003;
                }                

                //2.DC������E�����`�F�b�N�N�_���t�ȑO�̃f�[�^�擾
                for(int j =0; j<_sendDataList.Count;j++)
                {
                    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)_sendDataList[j];
                    switch (secMngSndRcv.FileId)
                    {
                        // ����f�[�^
                        case "SalesSlipRF":
                            saleCheckFlg = true;
                            _doSalesSlipFlg = true;
                            break;
                        // ���㖾�׃f�[�^
                        case "SalesDetailRF":
                            _doSalesDetailFlg = true;
                            break;
                        // ���㗚���f�[�^
                        case "SalesHistoryRF":
                            _doSalesHistoryFlg = true;
                            break;
                        // ���㗚�𖾍׃f�[�^
                        case "SalesHistDtlRF":
                            _doSalesHistDtlFlg = true;
                            break;
                        // �����f�[�^
                        case "DepsitMainRF":
                            depsitCheckFlg = true;
                            _doDepsitMainFlg = true;
                            break;
                        // �������׃f�[�^
                        case "DepsitDtlRF":
                            _doDepsitDtlFlg = true;
                            break;
                        // �d���f�[�^
                        case "StockSlipRF":
                            stockCheckFlg = true;
                            _doStockSlipFlg = true;
                            break;
                        // �d�����׃f�[�^
                        case "StockDetailRF":
                            _doStockDetailFlg = true;
                            break;
                        // �d�������f�[�^
                        case "StockSlipHistRF":
                            _doStockSlipHistFlg = true;
                            break;
                        // �d�����𖾍׃f�[�^
                        case "StockSlHistDtlRF":
                            _doStockSlHistDtlFlg = true;
                            break;
                        // �x���`�[�}�X�^
                        case "PaymentSlpRF":
                            paymentCheckFlg = true;
                            _doPaymentSlpFlg = true;
                            break;
                        // �x�����׃f�[�^
                        case "PaymentDtlRF":
                            _doPaymentDtlFlg = true;
                            break;
                        // �󒍃}�X�^
                        case "AcceptOdrRF":
                            _doAcceptOdrFlg = true;
                            break;
                        // �󒍃}�X�^�i�ԗ��j
                        case "AcceptOdrCarRF":
                            _doAcceptOdrCarFlg = true;
                            break;
                        default:
                            break;
                    }
                }
                //������E�������t�Ȃ��A�d�����E�������t�Ȃ�
                if (hisTotalDay.CompareTo(hisTotalDayPayment) == 0 && hisTotalDay.CompareTo(DateTime.MinValue) == 0)
                {
                    return true;
                }
                for (int i = 0; i < _secMngSetWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvEtrWork = (SndRcvHisWork)_secMngSetWorkList[i];
                    DCReceiveDataWork paraWork = new DCReceiveDataWork();
                    paraWork.PmSectionCode = sndRcvEtrWork.ExtraObjSecCode;
                    paraWork.StartDateTime = sndRcvEtrWork.SndObjStartDate.Ticks;
                    paraWork.EndDateTime = sndRcvEtrWork.SndObjEndDate.Ticks;
                    paraWork.PmEnterpriseCode = sndRcvEtrWork.EnterpriseCode;//ADD by Liangsd   2011/09/06 Redmine #24633

                    paraWork.DoSalesSlipFlg = _doSalesSlipFlg;          //����v�ۃt���O
                    paraWork.DoSalesDetailFlg = _doSalesDetailFlg;      //���㖾�חv�ۃt���O
                    paraWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //�󒍃}�X�^�i�ԗ��j�v�ۃt���O
                    paraWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //�󒍃}�X�^�v�ۃt���O
                    paraWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //���㗚��v�ۃt���O
                    paraWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //���㗚�𖾍חv�ۃt���O
                    paraWork.DoDepsitMainFlg = _doDepsitMainFlg;        //�����v�ۃt���O
                    paraWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //�������חv�ۃt���O
                    paraWork.DoStockSlipFlg = _doStockSlipFlg;          //�d���v�ۃt���O
                    paraWork.DoStockDetailFlg = _doStockDetailFlg;      //�d�����חv�ۃt���O
                    paraWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //�d������v�ۃt���O
                    paraWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//�d�����𖾍חv�ۃt���O
                    paraWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //�x���`�[�v�ۃt���O
                    paraWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //�x�����חv�ۃt���O
                    paraWork.EndDateTimeTicks = sndRcvEtrWork.SyncExecDate.Ticks; // ADD 2011/12/07
                    paraWork.SndLogExtraCondDiv = sndRcvEtrWork.SndLogExtraCondDiv; //����M���O���o�����敪  // ADD 2011/11/29
                        
                    paramWorkList.Add(paraWork);
                }
                // �f�[�^�Z���^�[
                if (this._dCControlDB == null)
                {
                    this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                }

                _dCControlDB.SimeCheckSCM(out errMsgList, paramWorkList, long.Parse(hisTotalDay.ToString("yyyyMMdd")), long.Parse(hisTotalDayPayment.ToString("yyyyMMdd")), saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg);
      

                if (errMsgList.Count == 0)
                {
                    return true;
                }
                //ErrorList����
                int hisDayMin = Convert.ToInt32(hisTotalDayMin.ToString("yyyyMMdd"));
                int hisDayPaymentMin = Convert.ToInt32(hisTotalDayPaymentMin.ToString("yyyyMMdd"));
                foreach (object err in errMsgList)
                {
                    ERInfoDataWork errWork = (ERInfoDataWork)err;
                    PMKYO01901EA errInfo = new PMKYO01901EA();
                    //�@����f�[�^�E�����}�X�^�̏ꍇ
                    if (errWork.ErSlipNm == "����" || errWork.ErSlipNm == "����")
                    {
                        
                        // 2011/09/29 Add >>>
                        int yyyy = errWork.ErDateTime / 10000;
                        int mm = errWork.ErDateTime / 100 % 100;
                        int dd = errWork.ErDateTime % 100;
                        DateTime checkDay = new DateTime(yyyy, mm, dd);
                        // ��������`�F�b�N
                        if (!toalDayCalculator.CheckDmdC(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                        {
                            // ���㌎���`�F�b�N
                            if (!toalDayCalculator.CheckMonthlyAccRec(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                            {
                                continue;
                            }
                            else
                            {
                                // ���㌎���`�F�b�N�ŃG���[
                                errWork.ErInfo = ERRORMSG001;
                            }
                        }
                        else
                        {
                            // ��������`�F�b�N�ŃG���[
                            errWork.ErInfo = ERRORMSG002;
                        }
                        // 2011/09/29 Add <<<
                        // 2011/09/29 Del >>>
                        //if (hisDayMin >= errWork.ErDateTime)
                        //{
                        //    errWork.ErInfo = errorMsgMin;
                        //}
                        //else
                        //{
                        //    errWork.ErInfo = errorInfo;
                        //}
                        // 2011/09/29 Del <<<
                    }
                    //�d���f�[�^�E�x���`�[�}�X�^�̏ꍇ
                    if (errWork.ErSlipNm == "�d��" || errWork.ErSlipNm == "�x��")
                    {
                        // 2011/09/29 Add >>>
                        int yyyy = errWork.ErDateTime / 10000;
                        int mm = errWork.ErDateTime / 100 % 100;
                        int dd = errWork.ErDateTime % 100;
                        DateTime checkDay = new DateTime(yyyy, mm, dd);
                        // �d�������`�F�b�N
                        if (!toalDayCalculator.CheckPayment(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                        {
                            // �d�������`�F�b�N
                            if (!toalDayCalculator.CheckMonthlyAccPay(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                            {
                                continue;
                            }
                            else
                            {
                                // �d�������`�F�b�N�ŃG���[
                                errWork.ErInfo = ERRORMSG001;
                            }
                        }
                        else
                        {
                            // �d�������`�F�b�N�ŃG���[
                            errWork.ErInfo = ERRORMSG003;
                        }
                        // 2011/09/29 Add <<<
                        // 2011/09/29 Del >>>
                        //if (hisDayPaymentMin >= errWork.ErDateTime)
                        //{
                        //    errWork.ErInfo = errorMsgPaymentMin;
                        //}
                        //else
                        //{
                        //    errWork.ErInfo = errorMsgPayment;
                        //}
                        // 2011/09/29 Del <<<
                    }

                    errInfo.NoFlg = errWork.ErSlipNm;
                    errInfo.No = errWork.ErSalesSlipNum;
					errInfo.Date = TDateTime.LongDateToString("YYYY/MM/DD", errWork.ErDateTime);
                    errInfo.SectionCode = errWork.ErSectionCode.Trim();
					errInfo.SectionNm = GetSectionName(errWork.ErSectionCode.Trim());
                    errInfo.CustomerCode = errWork.ErCustCode.ToString();
                    errInfo.CustomerNm = errWork.ErCustName;
                    errInfo.Error = errWork.ErInfo;
                    errInfoList.Add(errInfo);
                    
                }
                errMsgList = errInfoList;

                // 2011/09/29 Add >>>
                if (errMsgList.Count == 0)
                    return true;
                // 2011/09/29 Add <<<

                return false;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N
        /// </summary>
        //public int SaveData(int connectPointDiv)  // DEL 2011/11/29
        public int SaveData(ArrayList errMsgList, int connectPointDiv)  // ADD 2011/11/29
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            try
            {
                // �ۑ�����
                if (this._extraAddUpdControlDB == null)
                {
                    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }

                if (connectPointDiv == 0)
                {
                    // �f�[�^�Z���^�[
                    if (this._dCControlDB == null)
                    {
                        this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                    }
                }
                else
                {
                    // �W�v�@
                    if (this._skControlDB == null)
                    {
                        this._skControlDB = (ISKControlDB)MediationSKControlDB.GetSKControlDB();
                    }
                }

                // ���o���ʂȂ�
                bool _dataFlg = false;
                bool _errorFlg = false;

                // ���_�X�V
                int i = 0;
                //foreach (DataReceive.DataReceiveConditionRow row in this._conditionDataTable)//DEL 2011/07/29 SCM�Ή�-���_�Ǘ�
                foreach (SndRcvHisWork secMngSetWork in _secMngSetWorkList)//ADD 2011/07/29 SCM�Ή�-���_�Ǘ�
                {
                    // ���_���X�g
                    ArrayList sectionCodeList = new ArrayList();
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ----------------------------------------->>>>>
                    //foreach (DataReceive.DataReceiveConditionRow code in this._conditionDataTable)
                    //{
                    //    sectionCodeList.Add(code.ConditionSectionCd);
                    //}
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -----------------------------------------<<<<<
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ----------------------------------------->>>>>
                    foreach (SndRcvHisWork secMngSetWorkCopy in _secMngSetWorkList)
                    {
                        sectionCodeList.Add(secMngSetWorkCopy.SectionCode);
                    }
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -----------------------------------------<<<<<


                    object outreceiveList = null;
                    DCReceiveDataWork parareceiveWork = new DCReceiveDataWork();
                    #region DEL
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ----------------------------------------->>>>>
                    //APSecMngSetWork secMngSetWork = new APSecMngSetWork();                    
                    //// �����擾
                    //foreach (APSecMngSetWork secMngSet in this._secMngSetWorkList)                 
                    //{
                    //    if (secMngSet.SectionCode == row.ConditionSectionCd)
                    //    {
                    //        secMngSetWork = secMngSet;
                    //        break;
                    //    }
                    //}
                    
                    //// ��ƃR�[�h
                    //parareceiveWork.PmEnterpriseCode = secMngSetWork.PmEnterpriseCode;
                    //// �J�n����
                    //if (secMngSetWork.SyncExecDate.Year == row.ConditionStartDate.Year
                    //    && secMngSetWork.SyncExecDate.Month == row.ConditionStartDate.Month
                    //    && secMngSetWork.SyncExecDate.Day == row.ConditionStartDate.Day
                    //    && secMngSetWork.SyncExecDate.Hour == Convert.ToInt32(row.ConditionStartTime.Substring(0, 2))
                    //    && secMngSetWork.SyncExecDate.Minute == Convert.ToInt32(row.ConditionStartTime.Substring(3, 2))
                    //    && secMngSetWork.SyncExecDate.Second == Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)))
                    //{
                    //    parareceiveWork.StartDateTime = secMngSetWork.SyncExecDate.Ticks;
                    //}
                    //else
                    //{
                    //    parareceiveWork.StartDateTime = new DateTime(row.ConditionStartDate.Year, row.ConditionStartDate.Month, row.ConditionStartDate.Day,
                    //            Convert.ToInt32(row.ConditionStartTime.Substring(0, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(3, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(6, 2))).Ticks;
                    //}                    
                    //// �I������
                    //parareceiveWork.EndDateTime = new DateTime(row.ConditionEndDate.Year, row.ConditionEndDate.Month, row.ConditionEndDate.Day,
                    //        Convert.ToInt32(row.ConditionEndTime.Substring(0, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(3, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(6, 2))).Ticks;
                    //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -----------------------------------------<<<<<
                    #endregion
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ----------------------------------------->>>>>
                    parareceiveWork.PmEnterpriseCode = secMngSetWork.EnterpriseCode;
                    //  ADD x_chenjm  2011/11/01  --------------->>>>>>
                    if (secMngSetWork.Kind == 0 && secMngSetWork.SndLogExtraCondDiv==1)
                    {
                        parareceiveWork.StartDateTime =
                            Convert.ToInt32(secMngSetWork.SndObjStartDate.ToString("yyyyMMdd"));
                        parareceiveWork.EndDateTime = Convert.ToInt32(secMngSetWork.SndObjEndDate.ToString("yyyyMMdd"));

                        parareceiveWork.EndDateTimeTicks = secMngSetWork.SndObjEndDate.Ticks; //  ADD tanh  2011/11/30
                    }
                    else
                    {
                    //  ADD x_chenjm  2011/11/01  ---------------<<<<<<
                    parareceiveWork.StartDateTime = secMngSetWork.SndObjStartDate.Ticks;
                    parareceiveWork.EndDateTime = secMngSetWork.SndObjEndDate.Ticks;
                    }//  ADD x_chenjm  2011/11/01
                    parareceiveWork.PmSectionCode = secMngSetWork.ExtraObjSecCode;
                    //  ADD dingjx  2011/11/01  --------------->>>>>>
                    parareceiveWork.Kind = secMngSetWork.Kind;
                    parareceiveWork.SndLogExtraCondDiv = secMngSetWork.SndLogExtraCondDiv;
                    //  ADD dingjx  2011/11/01  ---------------<<<<<<

                    parareceiveWork.SyncExecDate = secMngSetWork.SyncExecDate.Ticks; //  ADD tanh  2011/11/30

                    parareceiveWork.DoSalesSlipFlg = _doSalesSlipFlg;          //����v�ۃt���O
                    parareceiveWork.DoSalesDetailFlg = _doSalesDetailFlg;      //���㖾�חv�ۃt���O
                    parareceiveWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //�󒍃}�X�^�i�ԗ��j�v�ۃt���O
                    parareceiveWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //�󒍃}�X�^�v�ۃt���O
                    parareceiveWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //���㗚��v�ۃt���O
                    parareceiveWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //���㗚�𖾍חv�ۃt���O
                    parareceiveWork.DoDepsitMainFlg = _doDepsitMainFlg;        //�����v�ۃt���O
                    parareceiveWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //�������חv�ۃt���O
                    parareceiveWork.DoStockSlipFlg = _doStockSlipFlg;          //�d���v�ۃt���O
                    parareceiveWork.DoStockDetailFlg = _doStockDetailFlg;      //�d�����חv�ۃt���O
                    parareceiveWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //�d������v�ۃt���O
                    parareceiveWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//�d�����𖾍חv�ۃt���O
                    parareceiveWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //�x���`�[�v�ۃt���O
                    parareceiveWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //�x�����חv�ۃt���O
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -----------------------------------------<<<<<
                    // �t�@�C��ID�z��
                    string[] fileIds = new string[this._sendDataList.Count];
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                        if (fileIds[j].Equals("SalesSlipRF"))
                        {
                            //�󒍃f�[�^��M�敪
                            parareceiveWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                            //�ݏo�f�[�^��M�敪
                            parareceiveWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                            //���σf�[�^��M�敪
                            parareceiveWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                        }
                        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    }

                    if (connectPointDiv == 0)
                    {
                        //stauts = this._dCControlDB.Search(out outreceiveList, parareceiveWork, row.ConditionSectionCd, fileIds);//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                        stauts = this._dCControlDB.SearchSCM(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)

                        // -- ADD 2011/11/29 --- >>>
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.ConvertreceiveList(errMsgList, ref outreceiveList); 
                        }
                        // -- ADD 2011/11/29 --- <<<
                    }
                    else
                    {
                        //stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, row.ConditionSectionCd, fileIds);//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                        stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    }

                    // ���o����
                    if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        // �f�[�^�ϊ�
                        object receiveList = null;
                        // -- UPD 2011/02/01 ------------------------------------>>>
                        //long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList);
                        long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList, parareceiveWork);
                        // -- UPD 2011/02/01 ------------------------------------<<<

                        _dataFlg = true;

                        // �ύX����
                        stauts = this._extraAddUpdControlDB.UpdateCustomSerializeArrayList(
                            LoginInfoAcquisition.EnterpriseCode, receiveList, sectionCodeList, ref stockAcPayHistCount);

                        // ����̏ꍇ�A�V�b�N���Ԃ��X�V����
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            #region DEL
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------->>>>>
                            //if (secMngSetWork.SyncExecDate.Ticks < updateTime)
                            //{
                            //    secMngSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            //    secMngSetWork.UpdateDateTime = DateTime.Now;
                            //    secMngSetWork.SectionCode = row.ConditionSectionCd;
                            //    secMngSetWork.Kind = 0;
                            //    secMngSetWork.ReceiveCondition = 1;
                            //    secMngSetWork.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                            //    // �X�V����
                            //    this._extraAddUpdControlDB.UpdateSecMngSetData(secMngSetWork, updateTime);
                            //}                            
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -------------------------<<<<<
                            #endregion

                            string logStr = string.Empty;

                            for (int m = 0; m < this._sendDataList.Count; m++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[m];
                                if (logStr == string.Empty)
                                {
                                    logStr += secMngSndRcv.FileNm + " ";
                                }
                                else
                                {
                                    logStr += "�A" + secMngSndRcv.FileNm + " ";
                                }
                                switch (secMngSndRcv.FileId)
                                {
                                    // ����f�[�^
                                    case "SalesSlipRF":
                                        logStr += IntConvert(salesSlipCount, false);
                                        break;
                                    // ���㖾�׃f�[�^
                                    case "SalesDetailRF":
                                        logStr += IntConvert(salesDetailCount, false);
                                        break;
                                    // ���㗚���f�[�^
                                    case "SalesHistoryRF":
                                        logStr += IntConvert(salesHistoryCount, false);
                                        break;
                                    // ���㗚�𖾍׃f�[�^
                                    case "SalesHistDtlRF":
                                        logStr += IntConvert(salesDtlHistCount, false);
                                        break;
                                    // �����f�[�^
                                    case "DepsitMainRF":
                                        logStr += IntConvert(depsitMainCount, false);
                                        break;
                                    // �������׃f�[�^
                                    case "DepsitDtlRF":
                                        logStr += IntConvert(depsitDtlCount, false);
                                        break;
                                    // �d���f�[�^
                                    case "StockSlipRF":
                                        logStr += IntConvert(stockSlipCount, false);
                                        break;
                                    // �d�����׃f�[�^
                                    case "StockDetailRF":
                                        logStr += IntConvert(stockDetailCount, false);
                                        break;
                                    // �d�������f�[�^
                                    case "StockSlipHistRF":
                                        logStr += IntConvert(stockHistoryCount, false);
                                        break;
                                    // �d�����𖾍׃f�[�^
                                    case "StockSlHistDtlRF":
                                        logStr += IntConvert(stockDtlHistCount, false);
                                        break;
                                    // �x���`�[�}�X�^
                                    case "PaymentSlpRF":
                                        logStr += IntConvert(paymentSlpCount, false);
                                        break;
                                    // �x�����׃f�[�^
                                    case "PaymentDtlRF":
                                        logStr += IntConvert(paymentDtlCount, false);
                                        break;
                                    // �󒍃}�X�^
                                    case "AcceptOdrRF":
                                        logStr += IntConvert(acceptOdrCount, false);
                                        break;
                                    // �󒍃}�X�^�i�ԗ��j
                                    case "AcceptOdrCarRF":
                                        logStr += IntConvert(acceptOdrCarCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050 --------------------------->>>>>
                                    //// ���㌎���W�v�f�[�^
                                    //case "MTtlSalesSlipRF":
                                    //    logStr += IntConvert(mTtlSalesSlipCount, false);
                                    //    break;
                                    //// ���i�ʔ��㌎���W�v�f�[�^
                                    //case "GoodsMTtlSaSlipRF":
                                    //    logStr += IntConvert(goodsSalesSlipCount, false);
                                    //    break;
                                    //// �d�������W�v�f�[�^
                                    //case "MTtlStockSlipRF":
                                    //    logStr += IntConvert(mTtlStockSlipCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050 ---------------------------<<<<<
                                    // �݌ɒ����f�[�^
                                    case "StockAdjustRF":
                                        logStr += IntConvert(stockAdjustCount, false);
                                        break;
                                    // �݌ɒ������׃f�[�^
                                    case "StockAdjustDtlRF":
                                        logStr += IntConvert(stockAdjustDtlCount, false);
                                        break;
                                    // �݌Ɉړ��f�[�^
                                    case "StockMoveRF":
                                        logStr += IntConvert(stockMoveCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050 --------------------------->>>>>
                                    //// �݌Ɏ󕥗����f�[�^
                                    //case "StockAcPayHistRF":
                                    //    logStr += IntConvert(stockAcPayHistCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050 ---------------------------<<<<<
                                    // ���������f�[�^
                                    case "DepositAlwRF":
                                        logStr += IntConvert(depositAlwCount, false);
                                        break;
                                    // ����`�f�[�^
                                    case "RcvDraftDataRF":
                                        logStr += IntConvert(rcvDraftDataCount, false);
                                        break;
                                    // �x����`�f�[�^
                                    case "PayDraftDataRF":
                                        logStr += IntConvert(payDraftDataRF, false);
                                        break;
                                }
                            }

                            // ���O����
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                //logStr, "����(���_�F" + row.ConditionSectionCd.Trim() + ")");//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                                    logStr, "����(���_�F" + secMngSetWork.SectionCode.Trim() + ")");//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                            
                            for (int k = 0; k < this._sendDataList.Count; k++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[k];
                                // ��ʕ\��
                                //this._resultDataTable.Rows[k][row.ConditionSectionCd] = GetCount(secMngSndRcv.FileId);//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                                this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = GetCount(secMngSndRcv.FileId);//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                            }

                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            if (this._extraRcvHisDB == null)
                            {
                                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
                            }

                            ArrayList logObj = new ArrayList();
                            secMngSetWork.SendOrReceiveDivCd = 1;
                            logObj.Add(secMngSetWork);

                            // ���M�������O�f�[�^�̍X�V
                            stauts = this._extraRcvHisDB.WriteRcvHisWork(ref logObj);
                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        }
                        else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            for (int k = 0; k < this._sendDataList.Count; k++)
                            {
                                // ��ʕ\��
                                //this._resultDataTable.Rows[k][row.ConditionSectionCd] = "�~";//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                                this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = "�~";//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                            }
                            // ���O����
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            //// �� 2009.06.17 ���m modify PVCS.160
                            //// operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + row.ConditionSectionCd.Trim() + ")");
                            //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + row.ConditionSectionCd.Trim() + ")", string.Empty);
                            //// �� 2009.06.17 ���m modify
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                            _errorFlg = true;
                        }
                        else
                        {
                            return stauts;
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        for (int k = 0; k < this._sendDataList.Count; k++)
                        {
                            //this._resultDataTable.Rows[k][row.ConditionSectionCd] = ZERO_0 + " " + COUNTNAME;//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                            this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = ZERO_0 + " " + COUNTNAME;//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        for (int k = 0; k < this._sendDataList.Count; k++)
                        {
                            // ��ʕ\��
                            //this._resultDataTable.Rows[k][row.ConditionSectionCd] = "�~";//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                            this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = "�~";//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                        }
                        // ���O����
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                        //// �� 2009.06.17 ���m modify PVCS.160
                        //// operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + row.ConditionSectionCd.Trim() + ")");
                        //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + row.ConditionSectionCd.Trim() + ")", string.Empty);
                        //// �� 2009.06.17 ���m modify
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                        //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        _errorFlg = true;
                    }

                    i++;
                }

                // �X�e�[�^�X���f
                if (!_errorFlg)
                {
                    if (_dataFlg)
                    {
                        // �X�e�[�^�X��߂�
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // ���O����
                        // �� 2009.06.17 liuyang modify PVCS.160
                        // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                        // �� 2009.06.17 liuyang modify
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // �X�e�[�^�X
                    stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return stauts;
        }

        #region DEL 2011/08/29  #24050
        ///// <summary>
        ///// ������M
        ///// </summary>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>		
        ///// <br>Note		: ������M�������s���B</br>
        ///// <br>Programmer	: ������</br>	
        ///// <br>Date		: 2011.07.29</br>
        ///// </remarks>
        //public int AutoReceiveData(int connectPointDiv)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {                
        //        StringBuilder errInfo = new StringBuilder();                
        //        ArrayList errMsgList;
        //        bool result = false;
        //        string errMsg = "";

        //        //��������������
        //        ReadInitData();

        //        // ��M�Ώۂ��擾����
        //        status = this.GetSecMngSendData(LoginInfoAcquisition.EnterpriseCode);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        result = CheckData(out errMsgList, ref errMsg);
        //        if (!result)
        //        {

        //            OperationLogSvrDB logSvr = new OperationLogSvrDB();
        //            DateTime now = DateTime.Now;
        //            string methodName = "AutoReceiveData()";
        //            string data = "";
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //            for (int i = 0; i < errMsgList.Count; i++)
        //            {
        //                //�h��������M�G���[�h�{�S�p�X�y�[�X�{�߂�G���[���X�g�̓`�[�{�S�p�X�y�[�X�{�`�[�ԍ��{�S�p�X�y�[�X
        //                //�{���t�{�S�p�X�y�[�X�{���_�R�[�h�{�S�p�X�y�[�X�{���_���́{�S�p�X�y�[�X�{���Ӑ�/�d����R�[�h
        //                //�{�S�p�X�y�[�X�{���Ӑ�/�d���於�́{�S�p�X�y�[�X�{�G���[�ڍד��e
        //                PMKYO01901EA errInfoWork = (PMKYO01901EA)errMsgList[i];
        //                errInfo.Remove(0, errInfo.Length);
        //                errInfo.Append(ERRORMSG004);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.NoFlg);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.No);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.Date);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.SectionCode);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.SectionNm);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.CustomerCode);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.CustomerNm);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.Error);

        //                logSvr.WriteOperationLogSvr(this, now, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, status, errInfo.ToString(), data);
        //            }
        //        }
        //        else
        //        {
        //            status = SaveData(connectPointDiv);
        //        }
        //    }
        //    catch
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;                
        //    }
        //    return status;
        //}
        #endregion

        /// <summary>
        /// �X�V���ʂ��擾����
        /// </summary>
        /// <param name="fileId">�t�@�C��ID</param>
        /// <returns>����</returns>
        private string GetCount(string fileId)
        {
            string count = string.Empty;

            switch (fileId)
            {
                // ����f�[�^
                case "SalesSlipRF":
                    count = IntConvert(salesSlipCount, true);
                    break;
                // ���㖾�׃f�[�^
                case "SalesDetailRF":
                    count = IntConvert(salesDetailCount, true);
                    break;
                // ���㗚���f�[�^
                case "SalesHistoryRF":
                    count = IntConvert(salesHistoryCount, true);
                    break;
                // ���㗚�𖾍׃f�[�^
                case "SalesHistDtlRF":
                    count = IntConvert(salesDtlHistCount, true);
                    break;
                // �����f�[�^
                case "DepsitMainRF":
                    count = IntConvert(depsitMainCount, true);
                    break;
                // �������׃f�[�^
                case "DepsitDtlRF":
                    count = IntConvert(depsitDtlCount, true);
                    break;
                // �d���f�[�^
                case "StockSlipRF":
                    count = IntConvert(stockSlipCount, true);
                    break;
                // �d�����׃f�[�^
                case "StockDetailRF":
                    count = IntConvert(stockDetailCount, true);
                    break;
                // �d�������f�[�^
                case "StockSlipHistRF":
                    count = IntConvert(stockHistoryCount, true);
                    break;
                // �d�����𖾍׃f�[�^
                case "StockSlHistDtlRF":
                    count = IntConvert(stockDtlHistCount, true);
                    break;
                // �x���`�[�}�X�^
                case "PaymentSlpRF":
                    count = IntConvert(paymentSlpCount, true);
                    break;
                // �x�����׃f�[�^
                case "PaymentDtlRF":
                    count = IntConvert(paymentDtlCount, true);
                    break;
                // �󒍃}�X�^
                case "AcceptOdrRF":
                    count = IntConvert(acceptOdrCount, true);
                    break;
                // �󒍃}�X�^�i�ԗ��j
                case "AcceptOdrCarRF":
                    count = IntConvert(acceptOdrCarCount, true);
                    break;
                //DEL 2011/08/29  #24050 --------------------------->>>>>
                //// ���㌎���W�v�f�[�^
                //case "MTtlSalesSlipRF":
                //    count = IntConvert(mTtlSalesSlipCount, true);
                //    break;
                //// ���i�ʔ��㌎���W�v�f�[�^
                //case "GoodsMTtlSaSlipRF":
                //    count = IntConvert(goodsSalesSlipCount, true);
                //    break;
                //// �d�������W�v�f�[�^
                //case "MTtlStockSlipRF":
                //    count = IntConvert(mTtlStockSlipCount, true);
                //    break;
                //DEL 2011/08/29  #24050 ---------------------------<<<<<
                // �݌ɒ����f�[�^
                case "StockAdjustRF":
                    count = IntConvert(stockAdjustCount, true);
                    break;
                // �݌ɒ������׃f�[�^
                case "StockAdjustDtlRF":
                    count = IntConvert(stockAdjustDtlCount, true);
                    break;
                // �݌Ɉړ��f�[�^
                case "StockMoveRF":
                    count = IntConvert(stockMoveCount, true);
                    break;
                //DEL 2011/08/29  #24050 --------------------------->>>>>
                //// �݌Ɏ󕥗����f�[�^
                //case "StockAcPayHistRF":
                //    count = IntConvert(stockAcPayHistCount, true);
                //    break;
                //DEL 2011/08/29  #24050 ---------------------------<<<<<
                // ���������f�[�^
                case "DepositAlwRF":
                    count = IntConvert(depositAlwCount, true);
                    break;
                // ����`�f�[�^
                case "RcvDraftDataRF":
                    count = IntConvert(rcvDraftDataCount, true);
                    break;
                // �x����`�f�[�^
                case "PayDraftDataRF":
                    count = IntConvert(payDraftDataRF, true);
                    break;
                default :
                    break;
            }

            return count;
        }

        /// <summary>
        /// �f�[�^�ϊ�
        /// </summary>
        /// <param name="receiveList">���o�f�[�^</param>
        /// <param name="outreceiveList">�X�V�f�[�^</param>
        /// <param name="parareceiveWork">�����N���X</param>
        /// <returns>�X�V����</returns>
        // -- UPD 2011/02/01 ----------------------------------->>>
        //private long DivisionCustomSerializeArrayList(out object receiveList, object outreceiveList)
        private long DivisionCustomSerializeArrayList(out object receiveList, object outreceiveList, DCReceiveDataWork parareceiveWork)
        // -- UPD 2011/02/01 -----------------------------------<<<
        {
            // �X�V����
            long updateTime = 0;
            // �����N���A
            this.salesSlipCount = 0;
            this.salesDetailCount = 0;
            this.salesHistoryCount = 0;
            this.salesDtlHistCount = 0;
            this.depsitMainCount = 0;
            this.depsitDtlCount = 0;
            this.stockSlipCount = 0;
            this.stockDetailCount = 0;
            this.stockHistoryCount = 0;
            this.stockDtlHistCount = 0;
            this.paymentSlpCount = 0;
            this.paymentDtlCount = 0;
            this.acceptOdrCount = 0;
            this.acceptOdrCarCount = 0;
            //DEL 2011/08/29  #24050------------>>>>>
            //this.mTtlSalesSlipCount = 0;
            //this.goodsSalesSlipCount = 0;
            //this.mTtlStockSlipCount = 0;
            //DEL 2011/08/29  #24050------------<<<<<
            // �� 2009.04.28 liuyang add
            this.stockAdjustCount = 0;
            this.stockAdjustDtlCount = 0;
            this.stockMoveCount = 0;
            //this.stockAcPayHistCount = 0;//DEL 2011/08/29  #24050
            // �� 2009.01.28 liuyang add
            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------------------->>>>>
            this.depositAlwCount = 0;    //��������
            this.rcvDraftDataCount = 0;  //����`�f�[�^
            this.payDraftDataRF = 0;     //�x����`�f�[�^
            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------<<<<<

            ArrayList _salesSlipList = new ArrayList();                       // ����f�[�^
            ArrayList _salesDetailList = new ArrayList();                     // ���㖾�׃f�[�^
            ArrayList _salesHistoryList = new ArrayList();                    // ���㗚���f�[�^
            ArrayList _salesHistDtlList = new ArrayList();                    // ���㗚�𖾍׃f�[�^
            ArrayList _depsitMainList = new ArrayList();                      // �����f�[�^
            ArrayList _depsitDtlList = new ArrayList();                       // �������׃f�[�^
            ArrayList _stockSlipList = new ArrayList();                       // �d���f�[�^
            ArrayList _stockDetailList = new ArrayList();                     // �d�����׃f�[�^
            ArrayList _stockSlipHistList = new ArrayList();                   // �d�������f�[�^
            ArrayList _stockSlHistDtlList = new ArrayList();                  // �d�����𖾍׃f�[�^
            ArrayList _paymentSlpList = new ArrayList();                      // �x���`�[�}�X�^
            ArrayList _paymentDtlList = new ArrayList();                      // �x�����׃f�[�^
            ArrayList _acceptOdrList = new ArrayList();                       // �󒍃}�X�^
            ArrayList _acceptOdrCarList = new ArrayList();                    // �󒍃}�X�^�i�ԗ��j
            //DEL 2011/08/29  #24050 -------------------------------------------------------------->>>>>
            //ArrayList _mTtlSalesSlipList = new ArrayList();                   // ���㌎���W�v�f�[�^
            //ArrayList _goodsMTtlSaSlipList = new ArrayList();                 // ���i�ʔ��㌎���W�v�f�[�^
            //ArrayList _mTtlStockSlipList = new ArrayList();                   // �d�������W�v�f�[�^
            //DEL 2011/08/29  #24050 --------------------------------------------------------------<<<<<
            // �� 2009.04.28 liuyang add
            ArrayList _stockAdjustList = new ArrayList();                     // �݌ɒ����f�[�^
            ArrayList _stockAdjustDtlList = new ArrayList();                  // �݌ɒ������׃f�[�^
            ArrayList _stockMoveList = new ArrayList();                       // �݌Ɉړ��f�[�^
            //ArrayList _stockAcPayHistList = new ArrayList();                  // �݌Ɏ󕥗����f�[�^//DEL 2011/08/29  #24050
            // �� 2009.04.28 liuyang add
            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------------------->>>>>
            ArrayList _dcDepositAlwList = new ArrayList();                    // ���������f�[�^
            ArrayList _dcRcvDraftDataList = new ArrayList();                  // ����`�f�[�^
            ArrayList _dcPayDraftDataList = new ArrayList();                  // �x����`�f�[�^
            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------<<<<<

            CustomSerializeArrayList outreceiveDataList = (CustomSerializeArrayList)outreceiveList;
            CustomSerializeArrayList receiveDataList = new CustomSerializeArrayList();

            // �ύX����
            for (int i = 0; i < outreceiveDataList.Count; i++)
            {
                if (outreceiveDataList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveDataList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is DCSalesSlipWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesSlipWork dcSalesSlipWork = (DCSalesSlipWork)list[j];
                            APSalesSlipWork salesSlipWork = ConvertReceive.SearchDataFromUpdateData(dcSalesSlipWork);
                            // ����f�[�^
                            _salesSlipList.Add(salesSlipWork);
                            // �X�V����
                            if (salesSlipWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = salesSlipWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_salesSlipList != null)
                        {
                            receiveDataList.Add(_salesSlipList);
                            // �ύX����
                            this.salesSlipCount = _salesSlipList.Count;
                        }
                    }
                    else if (list[0] is DCSalesDetailWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesDetailWork dcSalesDetailWork = (DCSalesDetailWork)list[j];
                            // ���㖾�׃f�[�^
                            _salesDetailList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesDetailWork));

                            // �X�V����
                            // -- UPD 2011/02/01 ------------------------------------>>>
                            //if (dcSalesDetailWork.UpdateDateTime.Ticks > updateTime)
                            if ((dcSalesDetailWork.UpdateDateTime.Ticks > updateTime) && (dcSalesDetailWork.UpdateDateTime.Ticks > parareceiveWork.StartDateTime && dcSalesDetailWork.UpdateDateTime.Ticks <= parareceiveWork.EndDateTime))
                            // -- UPD 2011/02/01 ------------------------------------<<<
                            {
                                updateTime = dcSalesDetailWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_salesDetailList != null)
                        {
                            receiveDataList.Add(_salesDetailList);
                            // �ύX����
                            this.salesDetailCount = _salesDetailList.Count;
                        }
                    }
                    else if (list[0] is DCSalesHistoryWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesHistoryWork dcSalesHistoryWork = (DCSalesHistoryWork)list[j];
                            // ���㗚���f�[�^
                            _salesHistoryList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesHistoryWork));

                            // �X�V����
                            if (dcSalesHistoryWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcSalesHistoryWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_salesHistoryList != null)
                        {
                            receiveDataList.Add(_salesHistoryList);
                            // �ύX����
                            this.salesHistoryCount = _salesHistoryList.Count;
                        }
                    }
                    else if (list[0] is DCSalesHistDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesHistDtlWork dcSalesHistDtlWork = (DCSalesHistDtlWork)list[j];
                            // ���㗚�𖾍׃f�[�^
                            _salesHistDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesHistDtlWork));

                            // �X�V����
                            if (dcSalesHistDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcSalesHistDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_salesHistDtlList != null)
                        {
                            receiveDataList.Add(_salesHistDtlList);
                            // �ύX����
                            this.salesDtlHistCount = _salesHistDtlList.Count;
                        }
                    }
                    else if (list[0] is DCDepsitMainWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepsitMainWork dcDepsitMainWork = (DCDepsitMainWork)list[j];
                            // �����f�[�^
                            _depsitMainList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepsitMainWork));

                            // �X�V����
                            if (dcDepsitMainWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepsitMainWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_depsitMainList != null)
                        {
                            receiveDataList.Add(_depsitMainList);
                            // �ύX����
                            this.depsitMainCount = _depsitMainList.Count;
                        }
                    }
                    else if (list[0] is DCDepsitDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepsitDtlWork dcDepsitDtlWork = (DCDepsitDtlWork)list[j];
                            // �������׃f�[�^
                            _depsitDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepsitDtlWork));

                            // �X�V����
                            if (dcDepsitDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepsitDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_depsitDtlList != null)
                        {
                            receiveDataList.Add(_depsitDtlList);
                            // �ύX����
                            this.depsitDtlCount = _depsitDtlList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlipWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlipWork dcStockSlipWork = (DCStockSlipWork)list[j];
                            // �d���f�[�^
                            _stockSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlipWork));

                            // �X�V����
                            if (dcStockSlipWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlipWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockSlipList != null)
                        {
                            receiveDataList.Add(_stockSlipList);
                            // �ύX����
                            this.stockSlipCount = _stockSlipList.Count;
                        }
                    }
                    else if (list[0] is DCStockDetailWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockDetailWork dcStockDetailWork = (DCStockDetailWork)list[j];
                            // �d�����׃f�[�^
                            _stockDetailList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockDetailWork));

                            // �X�V����
                            if (dcStockDetailWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockDetailWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockDetailList != null)
                        {
                            receiveDataList.Add(_stockDetailList);
                            // �ύX����
                            this.stockDetailCount = _stockDetailList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlipHistWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlipHistWork dcStockSlipHistWork = (DCStockSlipHistWork)list[j];
                            // �d�������f�[�^
                            _stockSlipHistList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlipHistWork));

                            // �X�V����
                            if (dcStockSlipHistWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlipHistWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockSlipHistList != null)
                        {
                            receiveDataList.Add(_stockSlipHistList);
                            // �ύX����
                            this.stockHistoryCount = _stockSlipHistList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlHistDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlHistDtlWork dcStockSlHistDtlWork = (DCStockSlHistDtlWork)list[j];
                            // �d�����𖾍׃f�[�^
                            _stockSlHistDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlHistDtlWork));

                            // �X�V����
                            if (dcStockSlHistDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlHistDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockSlHistDtlList != null)
                        {
                            receiveDataList.Add(_stockSlHistDtlList);
                            // �ύX����
                            this.stockDtlHistCount = _stockSlHistDtlList.Count;
                        }
                    }
                    else if (list[0] is DCPaymentSlpWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPaymentSlpWork dcPaymentSlpWork = (DCPaymentSlpWork)list[j];
                            // �x���`�[�}�X�^
                            _paymentSlpList.Add(ConvertReceive.SearchDataFromUpdateData(dcPaymentSlpWork));

                            // �X�V����
                            if (dcPaymentSlpWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPaymentSlpWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_paymentSlpList != null)
                        {
                            receiveDataList.Add(_paymentSlpList);
                            // �ύX����
                            this.paymentSlpCount = _paymentSlpList.Count;
                        }
                    }
                    else if (list[0] is DCPaymentDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPaymentDtlWork dcPaymentDtlWork = (DCPaymentDtlWork)list[j];
                            // �x�����׃f�[�^
                            _paymentDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcPaymentDtlWork));

                            // �X�V����
                            if (dcPaymentDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPaymentDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_paymentDtlList != null)
                        {
                            receiveDataList.Add(_paymentDtlList);
                            // �ύX����
                            this.paymentDtlCount = _paymentDtlList.Count;
                        }
                    }
                    else if (list[0] is DCAcceptOdrWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCAcceptOdrWork dcAcceptOdrWork = (DCAcceptOdrWork)list[j];
                            // �󒍃}�X�^
                            _acceptOdrList.Add(ConvertReceive.SearchDataFromUpdateData(dcAcceptOdrWork));

                            // �X�V����
                            if (dcAcceptOdrWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcAcceptOdrWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_acceptOdrList != null)
                        {
                            receiveDataList.Add(_acceptOdrList);
                            // �ύX����
                            this.acceptOdrCount = _acceptOdrList.Count;
                        }
                    }
                    else if (list[0] is DCAcceptOdrCarWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCAcceptOdrCarWork dcAcceptOdrCarWork = (DCAcceptOdrCarWork)list[j];
                            // �󒍃}�X�^�i�ԗ��j
                            _acceptOdrCarList.Add(ConvertReceive.SearchDataFromUpdateData(dcAcceptOdrCarWork));

                            // �X�V����
                            if (dcAcceptOdrCarWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcAcceptOdrCarWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_acceptOdrCarList != null)
                        {
                            receiveDataList.Add(_acceptOdrCarList);
                            // �ύX����
                            this.acceptOdrCarCount = _acceptOdrCarList.Count;
                        }
                    }
                    #region DEL 2011/08/29  #24050
                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                    //else if (list[0] is DCMTtlSalesSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCMTtlSalesSlipWork dcMTtlSalesSlipWork = (DCMTtlSalesSlipWork)list[j];
                    //        // ���㌎���ʓ`�[�f�[�^
                    //        _mTtlSalesSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcMTtlSalesSlipWork));

                    //        // �X�V����
                    //        if (dcMTtlSalesSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcMTtlSalesSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // ����ǉ�
                    //    if (_mTtlSalesSlipList != null)
                    //    {
                    //        receiveDataList.Add(_mTtlSalesSlipList);
                    //        // �ύX����
                    //        this.mTtlSalesSlipCount = _mTtlSalesSlipList.Count;
                    //    }
                    //}
                    //else if (list[0] is DCGoodsMTtlSaSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork = (DCGoodsMTtlSaSlipWork)list[j];
                    //        // ���i�����ʓ`�[�f�[�^
                    //        _goodsMTtlSaSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcGoodsMTtlSaSlipWork));

                    //        // �X�V����
                    //        if (dcGoodsMTtlSaSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcGoodsMTtlSaSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // ����ǉ�
                    //    if (_goodsMTtlSaSlipList != null)
                    //    {
                    //        receiveDataList.Add(_goodsMTtlSaSlipList);
                    //        // �ύX����
                    //        this.goodsSalesSlipCount = _goodsMTtlSaSlipList.Count;
                    //    }
                    //}
                    //else if (list[0] is DCMTtlStockSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCMTtlStockSlipWork dcMTtlStockSlipWork = (DCMTtlStockSlipWork)list[j];
                    //        // �d�������ʓ`�[�f�[�^
                    //        _mTtlStockSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcMTtlStockSlipWork));

                    //        // �X�V����
                    //        if (dcMTtlStockSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcMTtlStockSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // ����ǉ�
                    //    if (_mTtlStockSlipList != null)
                    //    {
                    //        receiveDataList.Add(_mTtlStockSlipList);
                    //        // �ύX����
                    //        this.mTtlStockSlipCount = _mTtlStockSlipList.Count;
                    //    }
                    //}
                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                    #endregion
                    // �� 2009.04.28 liuyang add
                    else if (list[0] is DCStockAdjustWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockAdjustWork dcStockAdjustWork = (DCStockAdjustWork)list[j];
                            // �݌ɒ����f�[�^
                            _stockAdjustList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAdjustWork));

                            // �X�V����
                            if (dcStockAdjustWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockAdjustWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockAdjustList != null)
                        {
                            receiveDataList.Add(_stockAdjustList);
                            // �ύX����
                            this.stockAdjustCount = _stockAdjustList.Count;
                        }
                    }
                    else if (list[0] is DCStockAdjustDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockAdjustDtlWork dcStockAdjustDtlWork = (DCStockAdjustDtlWork)list[j];
                            // �݌ɒ������׃f�[�^
                            _stockAdjustDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAdjustDtlWork));

                            // �X�V����
                            if (dcStockAdjustDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockAdjustDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockAdjustDtlList != null)
                        {
                            receiveDataList.Add(_stockAdjustDtlList);
                            // �ύX����
                            this.stockAdjustDtlCount = _stockAdjustDtlList.Count;
                        }
                    }
                    else if (list[0] is DCStockMoveWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockMoveWork dcStockMoveWork = (DCStockMoveWork)list[j];
                            // �݌Ɉړ��f�[�^
                            _stockMoveList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockMoveWork));

                            // �X�V����
                            if (dcStockMoveWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockMoveWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_stockMoveList != null)
                        {
                            receiveDataList.Add(_stockMoveList);
                            // �ύX����
                            this.stockMoveCount = _stockMoveList.Count;
                        }
                    }
                    #region DEL 2011/08/29  #24050
                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                    //else if (list[0] is DCStockAcPayHistWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCStockAcPayHistWork dcStockAcPayHistWork = (DCStockAcPayHistWork)list[j];
                    //        // �d�������ʓ`�[�f�[�^
                    //        _stockAcPayHistList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAcPayHistWork));

                    //        // �X�V����
                    //        if (dcStockAcPayHistWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcStockAcPayHistWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // ����ǉ�
                    //    if (_stockAcPayHistList != null)
                    //    {
                    //        receiveDataList.Add(_stockAcPayHistList);
                    //        // �ύX����
                    //        this.stockAcPayHistCount = _stockAcPayHistList.Count;
                    //    }
                    //}
                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                    #endregion
                    // �� 2009.04.28 liuyang add
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------->>>>>
                    else if (list[0] is DCDepositAlwWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepositAlwWork dcDepositAlwWork = (DCDepositAlwWork)list[j];
                            // ���������f�[�^
                            _dcDepositAlwList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepositAlwWork));

                            // �X�V����
                            if (dcDepositAlwWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepositAlwWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_dcDepositAlwList != null)
                        {
                            receiveDataList.Add(_dcDepositAlwList);
                            // �ύX����
                            this.depositAlwCount = _dcDepositAlwList.Count;
                        }
                    }
                    else if (list[0] is DCRcvDraftDataWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCRcvDraftDataWork dcRcvDraftDataWork = (DCRcvDraftDataWork)list[j];
                            // ����`�f�[�^
                            _dcRcvDraftDataList.Add(ConvertReceive.SearchDataFromUpdateData(dcRcvDraftDataWork));

                            // �X�V����
                            if (dcRcvDraftDataWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcRcvDraftDataWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_dcRcvDraftDataList != null)
                        {
                            receiveDataList.Add(_dcRcvDraftDataList);
                            // �ύX����
                            this.rcvDraftDataCount = _dcRcvDraftDataList.Count;
                        }
                    }
                    else if (list[0] is DCPayDraftDataWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPayDraftDataWork dcPayDraftDataWork = (DCPayDraftDataWork)list[j];
                            // �x����`�f�[�^
                            _dcPayDraftDataList.Add(ConvertReceive.SearchDataFromUpdateData(dcPayDraftDataWork));

                            // �X�V����
                            if (dcPayDraftDataWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPayDraftDataWork.UpdateDateTime.Ticks;
                            }
                        }

                        // ����ǉ�
                        if (_dcPayDraftDataList != null)
                        {
                            receiveDataList.Add(_dcPayDraftDataList);
                            // �ύX����
                            this.payDraftDataRF = _dcPayDraftDataList.Count;
                        }
                    }
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------<<<<<
                }
            }

            receiveList = (object)receiveDataList;

            return updateTime;
        }

        /// <summary>
        /// ���������t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount, bool spaceFlg)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr + " ��";
                }
                else
                {
                    searchCountStr = searchCountStr + "��";
                }
            }
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + " ��";
                }
                else
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + "��";
                }
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                        + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                        + searchCountStr.Substring(searchCountLen - 3) + " ��";
                }
                else
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                        + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                        + searchCountStr.Substring(searchCountLen - 3) + "��";
                }
            }
            return searchCountStr;
        }
        
        #endregion

        // ===================================================================================== //
        // DB�f�[�^�A�N�Z�X����
        // ===================================================================================== //
        # region ��DataBase Access Methods
        /// <summary>
        /// ���N������
        /// </summary>
        /// <param name="secMngSetList">���_���X�g</param>
        /// <param name="connectPointDiv">�ڑ���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public int MergeOfferToUserUpdate(ArrayList secMngSetList, int connectPointDiv, string enterpriseCode)
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
            //OperationHistoryLog operationHistoryLog = new OperationHistoryLog();//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���

            try
            {
                //��������������
                ReadInitData();

                // ��M�Ώۂ��擾����
                stauts = this.GetSecMngSendData(enterpriseCode);
                if (stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return stauts;
                }

                // �t�@�C��ID�z��
                string[] fileIds = new string[this._sendDataList.Count];
                for (int j = 0; j < this._sendDataList.Count; j++)
                {
                    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                    fileIds[j] = secMngSndRcv.FileId;
                }
                //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)-------------------------->>>>>
                ArrayList errMsgList;
                string errMsg = "";
                StringBuilder errInfo = new StringBuilder();
                bool result = CheckData(out errMsgList, ref errMsg);
                if (!result)
                {
                    DateTime now = DateTime.Now;
                    string methodName = "MergeOfferToUserUpdate()";
                    string data = "";
                    stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    for (int i = 0; i < errMsgList.Count; i++)
                    {
                        //�h��������M�G���[�h�{�S�p�X�y�[�X�{�߂�G���[���X�g�̓`�[�{�S�p�X�y�[�X�{�`�[�ԍ��{�S�p�X�y�[�X
                        //�{���t�{�S�p�X�y�[�X�{���_�R�[�h�{�S�p�X�y�[�X�{���_���́{�S�p�X�y�[�X�{���Ӑ�/�d����R�[�h
                        //�{�S�p�X�y�[�X�{���Ӑ�/�d���於�́{�S�p�X�y�[�X�{�G���[�ڍד��e
                        PMKYO01901EA errInfoWork = (PMKYO01901EA)errMsgList[i];
                        errInfo.Remove(0, errInfo.Length);
                        errInfo.Append(ERRORMSG004);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.NoFlg);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.No);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.Date);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.SectionCode);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.SectionNm);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.CustomerCode);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.CustomerNm);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.Error);
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, stauts, errInfo.ToString(), data);//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                        operationLogSvrDB.WriteOperationLogSvr(this, DateTime.Now, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, stauts, errInfo.ToString(), data);//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                    }
                    return stauts;
                }
                //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)--------------------------<<<<<

                // �ۑ�����
                if (this._extraAddUpdControlDB == null)
                {
                    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }

                if (connectPointDiv == 0)
                {
                    // �Z�[�^�[�R���g���[��
                    if (this._dCControlDB == null)
                    {
                        this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                    }
                }
                else
                {
                    // �W�v�@
                    if (this._skControlDB == null)
                    {
                        this._skControlDB = (ISKControlDB)MediationSKControlDB.GetSKControlDB();
                    }
                }

                // ���o���ʂȂ�
                bool _dataFlg = false;
                bool _errorFlg = false;

                // ���_�X�V
                //foreach (APSecMngSetWork secMngSetWork in secMngSetList)//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                foreach (SndRcvHisWork secMngSetWork in _secMngSetWorkList)//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                {
                    // ���_���X�g
                    ArrayList sectionCodeList = new ArrayList();
                    //foreach (APSecMngSetWork secMngSetWorkCopy in secMngSetList)//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    foreach (SndRcvHisWork secMngSetWorkCopy in _secMngSetWorkList)//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    {
                        sectionCodeList.Add(secMngSetWorkCopy.SectionCode);
                    }

                    object outreceiveList = null;
                    DCReceiveDataWork parareceiveWork = new DCReceiveDataWork();

                    // ��ƃR�[�h
                    //parareceiveWork.PmEnterpriseCode = secMngSetWork.PmEnterpriseCode;//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    parareceiveWork.PmEnterpriseCode = secMngSetWork.EnterpriseCode;//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    // �J�n����
                    //parareceiveWork.StartDateTime = secMngSetWork.SyncExecDate.Ticks;//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    parareceiveWork.StartDateTime = secMngSetWork.SndObjStartDate.Ticks;//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    // �I������
                    //parareceiveWork.EndDateTime = DateTime.Now.Ticks;//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    parareceiveWork.EndDateTime = secMngSetWork.SndObjEndDate.Ticks;//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------->>>>>
                    parareceiveWork.PmSectionCode = secMngSetWork.ExtraObjSecCode;

                    parareceiveWork.DoSalesSlipFlg = _doSalesSlipFlg;          //����v�ۃt���O
                    parareceiveWork.DoSalesDetailFlg = _doSalesDetailFlg;      //���㖾�חv�ۃt���O
                    parareceiveWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //�󒍃}�X�^�i�ԗ��j�v�ۃt���O
                    parareceiveWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //�󒍃}�X�^�v�ۃt���O
                    parareceiveWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //���㗚��v�ۃt���O
                    parareceiveWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //���㗚�𖾍חv�ۃt���O
                    parareceiveWork.DoDepsitMainFlg = _doDepsitMainFlg;        //�����v�ۃt���O
                    parareceiveWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //�������חv�ۃt���O
                    parareceiveWork.DoStockSlipFlg = _doStockSlipFlg;          //�d���v�ۃt���O
                    parareceiveWork.DoStockDetailFlg = _doStockDetailFlg;      //�d�����חv�ۃt���O
                    parareceiveWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //�d������v�ۃt���O
                    parareceiveWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//�d�����𖾍חv�ۃt���O
                    parareceiveWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //�x���`�[�v�ۃt���O
                    parareceiveWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //�x�����חv�ۃt���O
                    //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------<<<<<

                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
                    // ��M�敪�擾
                    for (int i = 0; i < _sendDataList.Count; i++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)_sendDataList[i];
                        if (secMngSndRcv.FileId.Equals("SalesSlipRF"))
                        {
                            //�󒍃f�[�^��M�敪
                            parareceiveWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                            //�ݏo�f�[�^��M�敪
                            parareceiveWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                            //���σf�[�^��M�敪
                            parareceiveWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                        }
                    }
                    // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
                    if (connectPointDiv == 0)
                    {
                        //stauts = this._dCControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                        stauts = this._dCControlDB.SearchSCM(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                    }
                    else
                    {
                        stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);
                    }

                    // ���o����
                    if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �f�[�^�ϊ�
                        object receiveList = null;
                        // -- UPD 2011/02/01 -------------------------------->>>
                        //long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList);
                        long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList, parareceiveWork);
                        // -- UPD 2011/02/01 --------------------------------<<<

                        _dataFlg = true;

                        // �ύX����
                        stauts = this._extraAddUpdControlDB.UpdateCustomSerializeArrayList(
                            LoginInfoAcquisition.EnterpriseCode, receiveList, sectionCodeList, ref stockAcPayHistCount);

                        // ����̏ꍇ�A�V�b�N���Ԃ��X�V����
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            #region DEL
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ------------------------->>>>>
                            //if (secMngSetWork.SyncExecDate.Ticks < updateTime)
                            //{
                            //    secMngSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            //    secMngSetWork.UpdateDateTime = DateTime.Now;
                            //    secMngSetWork.Kind = 0;
                            //    secMngSetWork.ReceiveCondition = 1;
                            //    secMngSetWork.UpdEmployeeCode = secMngSetWork.UpdEmployeeCode;
                            //    // �X�V����
                            //    this._extraAddUpdControlDB.UpdateSecMngSetData(secMngSetWork, updateTime);
                            //}
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) -------------------------<<<<<
                            #endregion

                            string logStr = string.Empty;

                            for (int m = 0; m < this._sendDataList.Count; m++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[m];
                                if (logStr == string.Empty)
                                {
                                    logStr += secMngSndRcv.FileNm + " ";
                                }
                                else
                                {
                                    logStr += "�A" + secMngSndRcv.FileNm + " ";
                                }
                                switch (secMngSndRcv.FileId)
                                {
                                    // ����f�[�^
                                    case "SalesSlipRF":
                                        logStr += IntConvert(salesSlipCount, false);
                                        break;
                                    // ���㖾�׃f�[�^
                                    case "SalesDetailRF":
                                        logStr += IntConvert(salesDetailCount, false);
                                        break;
                                    // ���㗚���f�[�^
                                    case "SalesHistoryRF":
                                        logStr += IntConvert(salesHistoryCount, false);
                                        break;
                                    // ���㗚�𖾍׃f�[�^
                                    case "SalesHistDtlRF":
                                        logStr += IntConvert(salesDtlHistCount, false);
                                        break;
                                    // �����f�[�^
                                    case "DepsitMainRF":
                                        logStr += IntConvert(depsitMainCount, false);
                                        break;
                                    // �������׃f�[�^
                                    case "DepsitDtlRF":
                                        logStr += IntConvert(depsitDtlCount, false);
                                        break;
                                    // �d���f�[�^
                                    case "StockSlipRF":
                                        logStr += IntConvert(stockSlipCount, false);
                                        break;
                                    // �d�����׃f�[�^
                                    case "StockDetailRF":
                                        logStr += IntConvert(stockDetailCount, false);
                                        break;
                                    // �d�������f�[�^
                                    case "StockSlipHistRF":
                                        logStr += IntConvert(stockHistoryCount, false);
                                        break;
                                    // �d�����𖾍׃f�[�^
                                    case "StockSlHistDtlRF":
                                        logStr += IntConvert(stockDtlHistCount, false);
                                        break;
                                    // �x���`�[�}�X�^
                                    case "PaymentSlpRF":
                                        logStr += IntConvert(paymentSlpCount, false);
                                        break;
                                    // �x�����׃f�[�^
                                    case "PaymentDtlRF":
                                        logStr += IntConvert(paymentDtlCount, false);
                                        break;
                                    // �󒍃}�X�^
                                    case "AcceptOdrRF":
                                        logStr += IntConvert(acceptOdrCount, false);
                                        break;
                                    // �󒍃}�X�^�i�ԗ��j
                                    case "AcceptOdrCarRF":
                                        logStr += IntConvert(acceptOdrCarCount, false);
                                        break;                                        
                                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                                    //// ���㌎���W�v�f�[�^
                                    //case "MTtlSalesSlipRF":
                                    //    logStr += IntConvert(mTtlSalesSlipCount, false);
                                    //    break;
                                    //// ���i�ʔ��㌎���W�v�f�[�^
                                    //case "GoodsMTtlSaSlipRF":
                                    //    logStr += IntConvert(goodsSalesSlipCount, false);
                                    //    break;
                                    //// �d�������W�v�f�[�^
                                    //case "MTtlStockSlipRF":
                                    //    logStr += IntConvert(mTtlStockSlipCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                                    // �݌ɒ����f�[�^
                                    case "StockAdjustRF":
                                        logStr += IntConvert(stockAdjustCount, false);
                                        break;
                                    // �݌ɒ������׃f�[�^
                                    case "StockAdjustDtlRF":
                                        logStr += IntConvert(stockAdjustDtlCount, false);
                                        break;
                                    // �݌Ɉړ��f�[�^
                                    case "StockMoveRF":
                                        logStr += IntConvert(stockMoveCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                                    //// �݌Ɏ󕥗����f�[�^
                                    //case "StockAcPayHistRF":
                                    //    logStr += IntConvert(stockAcPayHistCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                                    // ���������f�[�^
                                    case "DepositAlwRF":
                                        logStr += IntConvert(depositAlwCount, false);
                                        break;
                                    // ����`�f�[�^
                                    case "RcvDraftDataRF":
                                        logStr += IntConvert(rcvDraftDataCount, false);
                                        break;
                                    // �x����`�f�[�^
                                    case "PayDraftDataRF":
                                        logStr += IntConvert(payDraftDataRF, false);
                                        break;
                                }
                            }

                            // ���O����
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            //    logStr, "����(���_�F" + secMngSetWork.SectionCode.Trim() + ")");
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���--------------------------------------------------->>>>>
                            //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            //    logStr, "����(���_�F" + secMngSetWork.SectionCode.Trim() + ")");
                            //DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���---------------------------------------------------<<<<<
                            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���--------------------------------------------------->>>>>
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                logStr, "����(���_�F" + secMngSetWork.SectionCode.Trim() + ")");
                            //ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���---------------------------------------------------<<<<<
                            if (this._extraRcvHisDB == null)
                            {
                                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
                            }

                            ArrayList logObj = new ArrayList();
                            secMngSetWork.SendOrReceiveDivCd = 1;
                            logObj.Add(secMngSetWork);

                            // ���M�������O�f�[�^�̍X�V
                            stauts = this._extraRcvHisDB.WriteRcvHisWork(ref logObj);
                            //ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        }
                        else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            _errorFlg = true;
                            // ���O����
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                            //// �� 2009.06.17 liuyang modify PVCS.160
                            //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "�X�V�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")");
                            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                            //// �� 2009.06.17 liuyang modify
                            //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                            //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "�X�V�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        _errorFlg = true;
                        // ���O����
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                        //// �� 2009.06.17 liuyang modify PVCS.160
                        //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "���o�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")");
                        //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                        //// �� 2009.06.17 liuyang modify
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "���o�G���[(���_�F" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                    }
                }

                // �X�e�[�^�X���f
                if (!_errorFlg)
                {
                    if (_dataFlg)
                    {
                        // �X�e�[�^�X��߂�
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // ���O����
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) --------------------------------------------------------------------->>>>>
                        //// �� 2009.06.17 liuyang modify PVCS.160
                        //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "���o�Ώۂ̃f�[�^�����݂��܂���B");
                        //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);
                        //// �� 2009.06.17 liuyang modify
                        //DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00) ---------------------------------------------------------------------<<<<<
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);//DEL 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���o�Ώۂ̃f�[�^�����݂��܂���B", string.Empty);//ADD 2011/08/31 Redmine #24278 �f�[�^������M�������N�����܂���
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // �X�e�[�^�X
                    stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return stauts;
        }
        #endregion

        // �� 2009.04.30 liuyang add
        #region �� �ڑ���`�F�b�N���� ��
        /// <summary>
        /// �ڑ���`�F�b�N����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="connectPointDiv">�ڑ���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="regeditFlg">�t���O</param>
        /// </summary>
        /// <returns>�`�F�b�N��������</returns>
        public bool CheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg, int regeditFlg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);

            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;
                if (connectPointDiv == 0)
                {
                    // �ڑ��悪�u�f�[�^�Z���^�[�v�̏ꍇ�A����Ƃ��Ė߂�B
                    retResult = true;
                }
                else
                {
                    // �ڑ��悪�u�W�v�@�v�̏ꍇ
                    if (regeditFlg == 1)
                    {
                        retResult = true;
                    }
                    else
                    {
                        retResult = CheckRegistryKey(secMngConnectSt);
                        if (retResult == false)
                        {
                            errMsg = "�ڑ���̐ݒ肪�s���ł��B";
                        }
                    }
                }
            }
            else
            {
                errMsg = "�ڑ�����̎擾�����Ɏ��s���܂����B";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>���W�X�g������`�F�b�N����
        /// <param name="secMngConnectSt">���_�Ǘ��ڑ���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// </summary>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        private bool CheckRegistryKey(SecMngConnectSt secMngConnectSt)
        {
            bool retResult = false;

            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 != null && rKey2 != null)
                {
                    // ���W�X�g���捞
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string dbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();

                    if (String.IsNullOrEmpty(apServerIpAddress) || String.IsNullOrEmpty(dbServerIpAddress))
                    {
                        retResult = false;
                    }
                    else
                    {
                        retResult = (secMngConnectSt.ApServerIpAddress == apServerIpAddress) && (secMngConnectSt.DbServerIpAddress == dbServerIpAddress);
                    }
                }
                else
                {
                    // ���W�X�g����񂪖��ݒ�̏ꍇ
                    retResult = false;
                }
            }
            catch (Exception)
            {
                retResult = false;
            }

            return retResult;
        }
        #endregion �� �ڑ���`�F�b�N���� ��
        // �� 2009.04.30 liuyang add

        // �� 2009.05.25 liuyang add
        #region �� ���M�Ώۃf�[�^�̎擾���� ��
        /// <summary>
        /// ���M�Ώۃf�[�^�̎擾����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�Ώۃf�[�^�̎擾�������s���B</br>      
        /// <br>Programmer : ���m</br>                                  
        /// <br>Date       : 2009.05.25</br> 
        /// </remarks>
        /// <returns>�`�F�b�N��������</returns>
        public int GetSecMngSendData(string enterpriseCode)
        {
            _sendDataList = new ArrayList();
            List<SecMngSndRcv> sendList = new List<SecMngSndRcv>();
            List<SecMngSndRcvDtl> sendDtlList = new List<SecMngSndRcvDtl>();
            // �S������
            int status = this._sendSetAcs.SearchAll(out sendList, out sendDtlList, enterpriseCode);

            // ���M�f�[�^�̎擾
            foreach (SecMngSndRcv secMngSndRcv in sendList)
            {
                //if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngRecvDiv == 1)//DEL 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngRecvDiv >= 1)//ADD 2011/07/29 SCM�Ή� ���_�Ǘ�(10704767-00)
                {
                    _sendDataList.Add(secMngSndRcv);
                }
            }

            // ��ʕ\���ݒ�
            this.updateData = new string[_sendDataList.Count];
            int i = 0;
            foreach (SecMngSndRcv secMngSndRcv in _sendDataList)
            {
                this.updateData[i] = secMngSndRcv.MasterName;
                i++;
            }

            return status;
        }
        #endregion
        // �� 2009.05.25 liuyang add

        // -- ADD 2011/11/29 --- >>>
        private void ConvertreceiveList(ArrayList errMsgList, ref object outreceiveList)
        {
            CustomSerializeArrayList outreceiveDataList = (CustomSerializeArrayList)outreceiveList;
            CustomSerializeArrayList outreceiveDataTempList = new CustomSerializeArrayList();
            bool addFlg = true;

            for (int i = 0; i < outreceiveDataList.Count; i++)
            {
                addFlg = true;

                if (outreceiveDataList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveDataList[i];

                    if (list.Count == 0) continue;

                    ArrayList listTemp;

                    // ����f�[�^
                    if (list[0] is DCSalesSlipWork)
                    {
                        listTemp = new ArrayList();
                        
                        DCSalesSlipWork dcSalesSlipWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesSlipWork = (DCSalesSlipWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesSlipWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesSlipWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // ���㖾�׃f�[�^
                    else if (list[0] is DCSalesDetailWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesDetailWork dcSalesDetailWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesDetailWork = (DCSalesDetailWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesDetailWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesDetailWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // ���㗚���f�[�^
                    else if (list[0] is DCSalesHistoryWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesHistoryWork dcSalesHistoryWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesHistoryWork = (DCSalesHistoryWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesHistoryWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesHistoryWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // ���㗚�𖾍׃f�[�^
                    else if (list[0] is DCSalesHistDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesHistDtlWork dcSalesHistDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesHistDtlWork = (DCSalesHistDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesHistDtlWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesHistDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �󒍃}�X�^
                    else if (list[0] is DCAcceptOdrWork)
                    {
                        listTemp = new ArrayList();

                        DCAcceptOdrWork dcAcceptOdrWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcAcceptOdrWork = (DCAcceptOdrWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcAcceptOdrWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcAcceptOdrWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �󒍃}�X�^�i�ԗ��j
                    else if (list[0] is DCAcceptOdrCarWork)
                    {
                        listTemp = new ArrayList();

                        DCAcceptOdrCarWork dcAcceptOdrCarWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcAcceptOdrCarWork = (DCAcceptOdrCarWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcAcceptOdrCarWork.AcceptAnOrderNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcAcceptOdrCarWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �����}�X�^
                    else if (list[0] is DCDepsitMainWork)
                    {
                        listTemp = new ArrayList();

                        DCDepsitMainWork dcDepsitMainWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcDepsitMainWork = (DCDepsitMainWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcDepsitMainWork.DepositSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcDepsitMainWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �������׃f�[�^
                    else if (list[0] is DCDepsitDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCDepsitDtlWork dcDepsitDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcDepsitDtlWork = (DCDepsitDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("����".Equals(errInfo.NoFlg))
                                {
                                    if (dcDepsitDtlWork.DepositSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcDepsitDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �d���f�[�^
                    else if (list[0] is DCStockSlipWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlipWork dcStockSlipWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlipWork = (DCStockSlipWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�d��".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlipWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlipWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �d�����׃f�[�^
                    else if (list[0] is DCStockDetailWork)
                    {
                        listTemp = new ArrayList();

                        DCStockDetailWork dcStockDetailWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockDetailWork = (DCStockDetailWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�d��".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockDetailWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockDetailWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �d�������f�[�^
                    else if (list[0] is DCStockSlipHistWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlipHistWork dcStockSlipHistWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlipHistWork = (DCStockSlipHistWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�d��".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlipHistWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlipHistWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �d�����𖾍׃f�[�^
                    else if (list[0] is DCStockSlHistDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlHistDtlWork dcStockSlHistDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlHistDtlWork = (DCStockSlHistDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�d��".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlHistDtlWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlHistDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �x���`�[�}�X�^
                    else if (list[0] is DCPaymentSlpWork)
                    {
                        listTemp = new ArrayList();

                        DCPaymentSlpWork dcPaymentSlpWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcPaymentSlpWork = (DCPaymentSlpWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�x��".Equals(errInfo.NoFlg))
                                {
                                    if (dcPaymentSlpWork.PaymentSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcPaymentSlpWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // �x�����׃f�[�^
                    else if (list[0] is DCPaymentDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCPaymentDtlWork dcPaymentDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcPaymentDtlWork = (DCPaymentDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("�x��".Equals(errInfo.NoFlg))
                                {
                                    if (dcPaymentDtlWork.PaymentSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcPaymentDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    else
                    {
                        outreceiveDataTempList.Add(list);
                    }
                }
            }

            outreceiveList = (object)outreceiveDataTempList;
        }
        // -- ADD 2011/11/29 --- <<<
    }
}
