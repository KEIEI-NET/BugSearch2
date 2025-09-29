using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DepsitDataWork
    /// <summary>
    ///                      �����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/12/15 tianjw</br>
    /// <br>                     Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepsitDataWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�����ԍ��敪</summary>
        /// <remarks>0:��,1:��,2:���E�ςݍ�</remarks>
        private Int32 _depositDebitNoteCd;

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _depositSlipNo;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>�������͋��_�R�[�h</summary>
        /// <remarks>�������͂������_�R�[�h</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���͓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDay;

        /// <summary>�������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        // ----- ADD 2011/12/15 ---------->>>>>
        /// <summary>�O��������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _preDepositDate;
        // ----- ADD 2011/12/15 ----------<<<<<

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>�����v</summary>
        /// <remarks>�������z�{�萔���x���z�{�l���x���z</remarks>
        private Int64 _depositTotal;

        /// <summary>�������z</summary>
        /// <remarks>�l���E�萔�����������z</remarks>
        private Int64 _deposit;

        /// <summary>�萔�������z</summary>
        private Int64 _feeDeposit;

        /// <summary>�l�������z</summary>
        private Int64 _discountDeposit;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _autoDepositCd;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>��`���</summary>
        private Int32 _draftKind;

        /// <summary>��`��ޖ���</summary>
        /// <remarks>�񑩁A�בցA���؎�</remarks>
        private string _draftKindName = "";

        /// <summary>��`�敪</summary>
        private Int32 _draftDivide;

        /// <summary>��`�敪����</summary>
        /// <remarks>���U�A��</remarks>
        private string _draftDivideName = "";

        /// <summary>��`�ԍ�</summary>
        private string _draftNo = "";

        /// <summary>���������z</summary>
        private Int64 _depositAllowance;

        /// <summary>���������c��</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>�ԍ������A���ԍ�</summary>
        private Int32 _debitNoteLinkDepoNo;

        /// <summary>�ŏI�������݌v���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastReconcileAddUpDt;

        /// <summary>�����S���҃R�[�h</summary>
        private string _depositAgentCode = "";

        /// <summary>�����S���Җ���</summary>
        private string _depositAgentNm = "";

        /// <summary>�������͎҃R�[�h</summary>
        private string _depositInputAgentCd = "";

        /// <summary>�������͎Җ���</summary>
        private string _depositInputAgentNm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        /// <remarks>�������Ӑ於��</remarks>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        /// <remarks>�������Ӑ於�̂Q</remarks>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>�X�֋ǁF9900</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        private string _bankName = "";

        /// <summary>�����s�ԍ��P</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo1;

        /// <summary>����R�[�h�P</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode1;

        /// <summary>���햼�̂P</summary>
        private string _moneyKindName1 = "";

        /// <summary>����敪�P</summary>
        private Int32 _moneyKindDiv1;

        /// <summary>�������z�P</summary>
        private Int64 _deposit1;

        /// <summary>�L�������P</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm1;

        /// <summary>�����s�ԍ��Q</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo2;

        /// <summary>����R�[�h�Q</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode2;

        /// <summary>���햼�̂Q</summary>
        private string _moneyKindName2 = "";

        /// <summary>����敪�Q</summary>
        private Int32 _moneyKindDiv2;

        /// <summary>�������z�Q</summary>
        private Int64 _deposit2;

        /// <summary>�L�������Q</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm2;

        /// <summary>�����s�ԍ��R</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo3;

        /// <summary>����R�[�h�R</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode3;

        /// <summary>���햼�̂R</summary>
        private string _moneyKindName3 = "";

        /// <summary>����敪�R</summary>
        private Int32 _moneyKindDiv3;

        /// <summary>�������z�R</summary>
        private Int64 _deposit3;

        /// <summary>�L�������R</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm3;

        /// <summary>�����s�ԍ��S</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo4;

        /// <summary>����R�[�h�S</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode4;

        /// <summary>���햼�̂S</summary>
        private string _moneyKindName4 = "";

        /// <summary>����敪�S</summary>
        private Int32 _moneyKindDiv4;

        /// <summary>�������z�S</summary>
        private Int64 _deposit4;

        /// <summary>�L�������S</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm4;

        /// <summary>�����s�ԍ��T</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo5;

        /// <summary>����R�[�h�T</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode5;

        /// <summary>���햼�̂T</summary>
        private string _moneyKindName5 = "";

        /// <summary>����敪�T</summary>
        private Int32 _moneyKindDiv5;

        /// <summary>�������z�T</summary>
        private Int64 _deposit5;

        /// <summary>�L�������T</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm5;

        /// <summary>�����s�ԍ��U</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo6;

        /// <summary>����R�[�h�U</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode6;

        /// <summary>���햼�̂U</summary>
        private string _moneyKindName6 = "";

        /// <summary>����敪�U</summary>
        private Int32 _moneyKindDiv6;

        /// <summary>�������z�U</summary>
        private Int64 _deposit6;

        /// <summary>�L�������U</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm6;

        /// <summary>�����s�ԍ��V</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo7;

        /// <summary>����R�[�h�V</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode7;

        /// <summary>���햼�̂V</summary>
        private string _moneyKindName7 = "";

        /// <summary>����敪�V</summary>
        private Int32 _moneyKindDiv7;

        /// <summary>�������z�V</summary>
        private Int64 _deposit7;

        /// <summary>�L�������V</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm7;

        /// <summary>�����s�ԍ��W</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo8;

        /// <summary>����R�[�h�W</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode8;

        /// <summary>���햼�̂W</summary>
        private string _moneyKindName8 = "";

        /// <summary>����敪�W</summary>
        private Int32 _moneyKindDiv8;

        /// <summary>�������z�W</summary>
        private Int64 _deposit8;

        /// <summary>�L�������W</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm8;

        /// <summary>�����s�ԍ��X</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo9;

        /// <summary>����R�[�h�X</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode9;

        /// <summary>���햼�̂X</summary>
        private string _moneyKindName9 = "";

        /// <summary>����敪�X</summary>
        private Int32 _moneyKindDiv9;

        /// <summary>�������z�X</summary>
        private Int64 _deposit9;

        /// <summary>�L�������X</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm9;

        /// <summary>�����s�ԍ��P�O</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo10;

        /// <summary>����R�[�h�P�O</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode10;

        /// <summary>���햼�̂P�O</summary>
        private string _moneyKindName10 = "";

        /// <summary>����敪�P�O</summary>
        private Int32 _moneyKindDiv10;

        /// <summary>�������z�P�O</summary>
        private Int64 _deposit10;

        /// <summary>�L�������P�O</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm10;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  DepositDebitNoteCd
        /// <summary>�����ԍ��敪�v���p�e�B</summary>
        /// <value>0:��,1:��,2:���E�ςݍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositDebitNoteCd
        {
            get { return _depositDebitNoteCd; }
            set { _depositDebitNoteCd = value; }
        }

        /// public propaty name  :  DepositSlipNo
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositSlipNo
        {
            get { return _depositSlipNo; }
            set { _depositSlipNo = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InputDepositSecCd
        /// <summary>�������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDepositSecCd
        {
            get { return _inputDepositSecCd; }
            set { _inputDepositSecCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  DepositDate
        /// <summary>�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        // ----- ADD 2011/12/15 ------------------------------>>>>>
        /// public propaty name  :  PreDepositDate
        /// <summary>�O��������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PreDepositDate
        {
            get { return _preDepositDate; }
            set { _preDepositDate = value; }
        }
        // ----- ADD 2011/12/15 ------------------------------<<<<<

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  DepositTotal
        /// <summary>�����v�v���p�e�B</summary>
        /// <value>�������z�{�萔���x���z�{�l���x���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositTotal
        {
            get { return _depositTotal; }
            set { _depositTotal = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>�������z�v���p�e�B</summary>
        /// <value>�l���E�萔�����������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>�萔�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>�l�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftKind
        /// <summary>��`��ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftKind
        {
            get { return _draftKind; }
            set { _draftKind = value; }
        }

        /// public propaty name  :  DraftKindName
        /// <summary>��`��ޖ��̃v���p�e�B</summary>
        /// <value>�񑩁A�בցA���؎�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftKindName
        {
            get { return _draftKindName; }
            set { _draftKindName = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DraftDivideName
        /// <summary>��`�敪���̃v���p�e�B</summary>
        /// <value>���U�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDivideName
        {
            get { return _draftDivideName; }
            set { _draftDivideName = value; }
        }

        /// public propaty name  :  DraftNo
        /// <summary>��`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftNo
        {
            get { return _draftNo; }
            set { _draftNo = value; }
        }

        /// public propaty name  :  DepositAllowance
        /// <summary>���������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAllowance
        {
            get { return _depositAllowance; }
            set { _depositAllowance = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  DebitNoteLinkDepoNo
        /// <summary>�ԍ������A���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ������A���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteLinkDepoNo
        {
            get { return _debitNoteLinkDepoNo; }
            set { _debitNoteLinkDepoNo = value; }
        }

        /// public propaty name  :  LastReconcileAddUpDt
        /// <summary>�ŏI�������݌v����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastReconcileAddUpDt
        {
            get { return _lastReconcileAddUpDt; }
            set { _lastReconcileAddUpDt = value; }
        }

        /// public propaty name  :  DepositAgentCode
        /// <summary>�����S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositAgentCode
        {
            get { return _depositAgentCode; }
            set { _depositAgentCode = value; }
        }

        /// public propaty name  :  DepositAgentNm
        /// <summary>�����S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositAgentNm
        {
            get { return _depositAgentNm; }
            set { _depositAgentNm = value; }
        }

        /// public propaty name  :  DepositInputAgentCd
        /// <summary>�������͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositInputAgentCd
        {
            get { return _depositInputAgentCd; }
            set { _depositInputAgentCd = value; }
        }

        /// public propaty name  :  DepositInputAgentNm
        /// <summary>�������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositInputAgentNm
        {
            get { return _depositInputAgentNm; }
            set { _depositInputAgentNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�����擾�Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// <value>�������Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於��2�v���p�e�B</summary>
        /// <value>�������Ӑ於�̂Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>��s�R�[�h�v���p�e�B</summary>
        /// <value>�X�֋ǁF9900</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        /// public propaty name  :  BankName
        /// <summary>��s���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        /// public propaty name  :  DepositRowNo1
        /// <summary>�����s�ԍ��P�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo1
        {
            get { return _depositRowNo1; }
            set { _depositRowNo1 = value; }
        }

        /// public propaty name  :  MoneyKindCode1
        /// <summary>����R�[�h�P�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode1
        {
            get { return _moneyKindCode1; }
            set { _moneyKindCode1 = value; }
        }

        /// public propaty name  :  MoneyKindName1
        /// <summary>���햼�̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName1
        {
            get { return _moneyKindName1; }
            set { _moneyKindName1 = value; }
        }

        /// public propaty name  :  MoneyKindDiv1
        /// <summary>����敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv1
        {
            get { return _moneyKindDiv1; }
            set { _moneyKindDiv1 = value; }
        }

        /// public propaty name  :  Deposit1
        /// <summary>�������z�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit1
        {
            get { return _deposit1; }
            set { _deposit1 = value; }
        }

        /// public propaty name  :  ValidityTerm1
        /// <summary>�L�������P�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm1
        {
            get { return _validityTerm1; }
            set { _validityTerm1 = value; }
        }

        /// public propaty name  :  DepositRowNo2
        /// <summary>�����s�ԍ��Q�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo2
        {
            get { return _depositRowNo2; }
            set { _depositRowNo2 = value; }
        }

        /// public propaty name  :  MoneyKindCode2
        /// <summary>����R�[�h�Q�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode2
        {
            get { return _moneyKindCode2; }
            set { _moneyKindCode2 = value; }
        }

        /// public propaty name  :  MoneyKindName2
        /// <summary>���햼�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName2
        {
            get { return _moneyKindName2; }
            set { _moneyKindName2 = value; }
        }

        /// public propaty name  :  MoneyKindDiv2
        /// <summary>����敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv2
        {
            get { return _moneyKindDiv2; }
            set { _moneyKindDiv2 = value; }
        }

        /// public propaty name  :  Deposit2
        /// <summary>�������z�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit2
        {
            get { return _deposit2; }
            set { _deposit2 = value; }
        }

        /// public propaty name  :  ValidityTerm2
        /// <summary>�L�������Q�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm2
        {
            get { return _validityTerm2; }
            set { _validityTerm2 = value; }
        }

        /// public propaty name  :  DepositRowNo3
        /// <summary>�����s�ԍ��R�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo3
        {
            get { return _depositRowNo3; }
            set { _depositRowNo3 = value; }
        }

        /// public propaty name  :  MoneyKindCode3
        /// <summary>����R�[�h�R�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode3
        {
            get { return _moneyKindCode3; }
            set { _moneyKindCode3 = value; }
        }

        /// public propaty name  :  MoneyKindName3
        /// <summary>���햼�̂R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName3
        {
            get { return _moneyKindName3; }
            set { _moneyKindName3 = value; }
        }

        /// public propaty name  :  MoneyKindDiv3
        /// <summary>����敪�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv3
        {
            get { return _moneyKindDiv3; }
            set { _moneyKindDiv3 = value; }
        }

        /// public propaty name  :  Deposit3
        /// <summary>�������z�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit3
        {
            get { return _deposit3; }
            set { _deposit3 = value; }
        }

        /// public propaty name  :  ValidityTerm3
        /// <summary>�L�������R�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm3
        {
            get { return _validityTerm3; }
            set { _validityTerm3 = value; }
        }

        /// public propaty name  :  DepositRowNo4
        /// <summary>�����s�ԍ��S�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo4
        {
            get { return _depositRowNo4; }
            set { _depositRowNo4 = value; }
        }

        /// public propaty name  :  MoneyKindCode4
        /// <summary>����R�[�h�S�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode4
        {
            get { return _moneyKindCode4; }
            set { _moneyKindCode4 = value; }
        }

        /// public propaty name  :  MoneyKindName4
        /// <summary>���햼�̂S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName4
        {
            get { return _moneyKindName4; }
            set { _moneyKindName4 = value; }
        }

        /// public propaty name  :  MoneyKindDiv4
        /// <summary>����敪�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv4
        {
            get { return _moneyKindDiv4; }
            set { _moneyKindDiv4 = value; }
        }

        /// public propaty name  :  Deposit4
        /// <summary>�������z�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit4
        {
            get { return _deposit4; }
            set { _deposit4 = value; }
        }

        /// public propaty name  :  ValidityTerm4
        /// <summary>�L�������S�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm4
        {
            get { return _validityTerm4; }
            set { _validityTerm4 = value; }
        }

        /// public propaty name  :  DepositRowNo5
        /// <summary>�����s�ԍ��T�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo5
        {
            get { return _depositRowNo5; }
            set { _depositRowNo5 = value; }
        }

        /// public propaty name  :  MoneyKindCode5
        /// <summary>����R�[�h�T�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode5
        {
            get { return _moneyKindCode5; }
            set { _moneyKindCode5 = value; }
        }

        /// public propaty name  :  MoneyKindName5
        /// <summary>���햼�̂T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName5
        {
            get { return _moneyKindName5; }
            set { _moneyKindName5 = value; }
        }

        /// public propaty name  :  MoneyKindDiv5
        /// <summary>����敪�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv5
        {
            get { return _moneyKindDiv5; }
            set { _moneyKindDiv5 = value; }
        }

        /// public propaty name  :  Deposit5
        /// <summary>�������z�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit5
        {
            get { return _deposit5; }
            set { _deposit5 = value; }
        }

        /// public propaty name  :  ValidityTerm5
        /// <summary>�L�������T�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm5
        {
            get { return _validityTerm5; }
            set { _validityTerm5 = value; }
        }

        /// public propaty name  :  DepositRowNo6
        /// <summary>�����s�ԍ��U�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo6
        {
            get { return _depositRowNo6; }
            set { _depositRowNo6 = value; }
        }

        /// public propaty name  :  MoneyKindCode6
        /// <summary>����R�[�h�U�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode6
        {
            get { return _moneyKindCode6; }
            set { _moneyKindCode6 = value; }
        }

        /// public propaty name  :  MoneyKindName6
        /// <summary>���햼�̂U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName6
        {
            get { return _moneyKindName6; }
            set { _moneyKindName6 = value; }
        }

        /// public propaty name  :  MoneyKindDiv6
        /// <summary>����敪�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv6
        {
            get { return _moneyKindDiv6; }
            set { _moneyKindDiv6 = value; }
        }

        /// public propaty name  :  Deposit6
        /// <summary>�������z�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit6
        {
            get { return _deposit6; }
            set { _deposit6 = value; }
        }

        /// public propaty name  :  ValidityTerm6
        /// <summary>�L�������U�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm6
        {
            get { return _validityTerm6; }
            set { _validityTerm6 = value; }
        }

        /// public propaty name  :  DepositRowNo7
        /// <summary>�����s�ԍ��V�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo7
        {
            get { return _depositRowNo7; }
            set { _depositRowNo7 = value; }
        }

        /// public propaty name  :  MoneyKindCode7
        /// <summary>����R�[�h�V�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode7
        {
            get { return _moneyKindCode7; }
            set { _moneyKindCode7 = value; }
        }

        /// public propaty name  :  MoneyKindName7
        /// <summary>���햼�̂V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName7
        {
            get { return _moneyKindName7; }
            set { _moneyKindName7 = value; }
        }

        /// public propaty name  :  MoneyKindDiv7
        /// <summary>����敪�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv7
        {
            get { return _moneyKindDiv7; }
            set { _moneyKindDiv7 = value; }
        }

        /// public propaty name  :  Deposit7
        /// <summary>�������z�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit7
        {
            get { return _deposit7; }
            set { _deposit7 = value; }
        }

        /// public propaty name  :  ValidityTerm7
        /// <summary>�L�������V�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm7
        {
            get { return _validityTerm7; }
            set { _validityTerm7 = value; }
        }

        /// public propaty name  :  DepositRowNo8
        /// <summary>�����s�ԍ��W�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo8
        {
            get { return _depositRowNo8; }
            set { _depositRowNo8 = value; }
        }

        /// public propaty name  :  MoneyKindCode8
        /// <summary>����R�[�h�W�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode8
        {
            get { return _moneyKindCode8; }
            set { _moneyKindCode8 = value; }
        }

        /// public propaty name  :  MoneyKindName8
        /// <summary>���햼�̂W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName8
        {
            get { return _moneyKindName8; }
            set { _moneyKindName8 = value; }
        }

        /// public propaty name  :  MoneyKindDiv8
        /// <summary>����敪�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv8
        {
            get { return _moneyKindDiv8; }
            set { _moneyKindDiv8 = value; }
        }

        /// public propaty name  :  Deposit8
        /// <summary>�������z�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit8
        {
            get { return _deposit8; }
            set { _deposit8 = value; }
        }

        /// public propaty name  :  ValidityTerm8
        /// <summary>�L�������W�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm8
        {
            get { return _validityTerm8; }
            set { _validityTerm8 = value; }
        }

        /// public propaty name  :  DepositRowNo9
        /// <summary>�����s�ԍ��X�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo9
        {
            get { return _depositRowNo9; }
            set { _depositRowNo9 = value; }
        }

        /// public propaty name  :  MoneyKindCode9
        /// <summary>����R�[�h�X�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode9
        {
            get { return _moneyKindCode9; }
            set { _moneyKindCode9 = value; }
        }

        /// public propaty name  :  MoneyKindName9
        /// <summary>���햼�̂X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName9
        {
            get { return _moneyKindName9; }
            set { _moneyKindName9 = value; }
        }

        /// public propaty name  :  MoneyKindDiv9
        /// <summary>����敪�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv9
        {
            get { return _moneyKindDiv9; }
            set { _moneyKindDiv9 = value; }
        }

        /// public propaty name  :  Deposit9
        /// <summary>�������z�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit9
        {
            get { return _deposit9; }
            set { _deposit9 = value; }
        }

        /// public propaty name  :  ValidityTerm9
        /// <summary>�L�������X�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm9
        {
            get { return _validityTerm9; }
            set { _validityTerm9 = value; }
        }

        /// public propaty name  :  DepositRowNo10
        /// <summary>�����s�ԍ��P�O�v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo10
        {
            get { return _depositRowNo10; }
            set { _depositRowNo10 = value; }
        }

        /// public propaty name  :  MoneyKindCode10
        /// <summary>����R�[�h�P�O�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode10
        {
            get { return _moneyKindCode10; }
            set { _moneyKindCode10 = value; }
        }

        /// public propaty name  :  MoneyKindName10
        /// <summary>���햼�̂P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̂P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName10
        {
            get { return _moneyKindName10; }
            set { _moneyKindName10 = value; }
        }

        /// public propaty name  :  MoneyKindDiv10
        /// <summary>����敪�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv10
        {
            get { return _moneyKindDiv10; }
            set { _moneyKindDiv10 = value; }
        }

        /// public propaty name  :  Deposit10
        /// <summary>�������z�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit10
        {
            get { return _deposit10; }
            set { _deposit10 = value; }
        }

        /// public propaty name  :  ValidityTerm10
        /// <summary>�L�������P�O�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm10
        {
            get { return _validityTerm10; }
            set { _validityTerm10 = value; }
        }


        /// <summary>
        /// �����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>DepsitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepsitDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>DepsitDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DepsitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepsitDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepsitDataWork || graph is ArrayList || graph is DepsitDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DepsitDataWork).FullName));

            if (graph != null && graph is DepsitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepsitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepsitDataWork[])graph).Length;
            }
            else if (graph is DepsitDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //�����ԍ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDebitNoteCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�������͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InputDepositSecCd
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���͓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate
            //�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //PreDepositDate // ADD 2011/12/15
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�����v
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositTotal
            //�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
            //�萔�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //FeeDeposit
            //�l�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountDeposit
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //��`�U�o��
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //��`���
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKind
            //��`��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //DraftKindName
            //��`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //��`�敪����
            serInfo.MemberInfo.Add(typeof(string)); //DraftDivideName
            //��`�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //DraftNo
            //���������z
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowance
            //���������c��
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAlwcBlnce
            //�ԍ������A���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkDepoNo
            //�ŏI�������݌v���
            serInfo.MemberInfo.Add(typeof(Int32)); //LastReconcileAddUpDt
            //�����S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentCode
            //�����S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentNm
            //�������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentCd
            //�������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentNm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //��s�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //��s����
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //�����s�ԍ��P
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo1
            //����R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode1
            //���햼�̂P
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName1
            //����敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv1
            //�������z�P
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit1
            //�L�������P
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm1
            //�����s�ԍ��Q
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo2
            //����R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode2
            //���햼�̂Q
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName2
            //����敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv2
            //�������z�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit2
            //�L�������Q
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm2
            //�����s�ԍ��R
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo3
            //����R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode3
            //���햼�̂R
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName3
            //����敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv3
            //�������z�R
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit3
            //�L�������R
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm3
            //�����s�ԍ��S
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo4
            //����R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode4
            //���햼�̂S
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName4
            //����敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv4
            //�������z�S
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit4
            //�L�������S
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm4
            //�����s�ԍ��T
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo5
            //����R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode5
            //���햼�̂T
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName5
            //����敪�T
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv5
            //�������z�T
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit5
            //�L�������T
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm5
            //�����s�ԍ��U
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo6
            //����R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode6
            //���햼�̂U
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName6
            //����敪�U
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv6
            //�������z�U
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit6
            //�L�������U
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm6
            //�����s�ԍ��V
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo7
            //����R�[�h�V
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode7
            //���햼�̂V
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName7
            //����敪�V
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv7
            //�������z�V
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit7
            //�L�������V
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm7
            //�����s�ԍ��W
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo8
            //����R�[�h�W
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode8
            //���햼�̂W
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName8
            //����敪�W
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv8
            //�������z�W
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit8
            //�L�������W
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm8
            //�����s�ԍ��X
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo9
            //����R�[�h�X
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode9
            //���햼�̂X
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName9
            //����敪�X
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv9
            //�������z�X
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit9
            //�L�������X
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm9
            //�����s�ԍ��P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo10
            //����R�[�h�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode10
            //���햼�̂P�O
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName10
            //����敪�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv10
            //�������z�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit10
            //�L�������P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm10


            serInfo.Serialize(writer, serInfo);
            if (graph is DepsitDataWork)
            {
                DepsitDataWork temp = (DepsitDataWork)graph;

                SetDepsitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepsitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepsitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepsitDataWork temp in lst)
                {
                    SetDepsitDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepsitDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 109; // DEL 2011/12/15
        private const int currentMemberCount = 110; // ADD 2011/12/15

        /// <summary>
        ///  DepsitDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetDepsitDataWork(System.IO.BinaryWriter writer, DepsitDataWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //�����ԍ��敪
            writer.Write(temp.DepositDebitNoteCd);
            //�����`�[�ԍ�
            writer.Write(temp.DepositSlipNo);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�������͋��_�R�[�h
            writer.Write(temp.InputDepositSecCd);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���͓��t
            writer.Write((Int64)temp.InputDay.Ticks);
            //�������t
            writer.Write((Int64)temp.DepositDate.Ticks);
            //�������t
            writer.Write((Int64)temp.PreDepositDate.Ticks); // ADD 2011/12/15
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�����v
            writer.Write(temp.DepositTotal);
            //�������z
            writer.Write(temp.Deposit);
            //�萔�������z
            writer.Write(temp.FeeDeposit);
            //�l�������z
            writer.Write(temp.DiscountDeposit);
            //���������敪
            writer.Write(temp.AutoDepositCd);
            //��`�U�o��
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //��`���
            writer.Write(temp.DraftKind);
            //��`��ޖ���
            writer.Write(temp.DraftKindName);
            //��`�敪
            writer.Write(temp.DraftDivide);
            //��`�敪����
            writer.Write(temp.DraftDivideName);
            //��`�ԍ�
            writer.Write(temp.DraftNo);
            //���������z
            writer.Write(temp.DepositAllowance);
            //���������c��
            writer.Write(temp.DepositAlwcBlnce);
            //�ԍ������A���ԍ�
            writer.Write(temp.DebitNoteLinkDepoNo);
            //�ŏI�������݌v���
            writer.Write((Int64)temp.LastReconcileAddUpDt.Ticks);
            //�����S���҃R�[�h
            writer.Write(temp.DepositAgentCode);
            //�����S���Җ���
            writer.Write(temp.DepositAgentNm);
            //�������͎҃R�[�h
            writer.Write(temp.DepositInputAgentCd);
            //�������͎Җ���
            writer.Write(temp.DepositInputAgentNm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //��s�R�[�h
            writer.Write(temp.BankCode);
            //��s����
            writer.Write(temp.BankName);
            //�����s�ԍ��P
            writer.Write(temp.DepositRowNo1);
            //����R�[�h�P
            writer.Write(temp.MoneyKindCode1);
            //���햼�̂P
            writer.Write(temp.MoneyKindName1);
            //����敪�P
            writer.Write(temp.MoneyKindDiv1);
            //�������z�P
            writer.Write(temp.Deposit1);
            //�L�������P
            writer.Write((Int64)temp.ValidityTerm1.Ticks);
            //�����s�ԍ��Q
            writer.Write(temp.DepositRowNo2);
            //����R�[�h�Q
            writer.Write(temp.MoneyKindCode2);
            //���햼�̂Q
            writer.Write(temp.MoneyKindName2);
            //����敪�Q
            writer.Write(temp.MoneyKindDiv2);
            //�������z�Q
            writer.Write(temp.Deposit2);
            //�L�������Q
            writer.Write((Int64)temp.ValidityTerm2.Ticks);
            //�����s�ԍ��R
            writer.Write(temp.DepositRowNo3);
            //����R�[�h�R
            writer.Write(temp.MoneyKindCode3);
            //���햼�̂R
            writer.Write(temp.MoneyKindName3);
            //����敪�R
            writer.Write(temp.MoneyKindDiv3);
            //�������z�R
            writer.Write(temp.Deposit3);
            //�L�������R
            writer.Write((Int64)temp.ValidityTerm3.Ticks);
            //�����s�ԍ��S
            writer.Write(temp.DepositRowNo4);
            //����R�[�h�S
            writer.Write(temp.MoneyKindCode4);
            //���햼�̂S
            writer.Write(temp.MoneyKindName4);
            //����敪�S
            writer.Write(temp.MoneyKindDiv4);
            //�������z�S
            writer.Write(temp.Deposit4);
            //�L�������S
            writer.Write((Int64)temp.ValidityTerm4.Ticks);
            //�����s�ԍ��T
            writer.Write(temp.DepositRowNo5);
            //����R�[�h�T
            writer.Write(temp.MoneyKindCode5);
            //���햼�̂T
            writer.Write(temp.MoneyKindName5);
            //����敪�T
            writer.Write(temp.MoneyKindDiv5);
            //�������z�T
            writer.Write(temp.Deposit5);
            //�L�������T
            writer.Write((Int64)temp.ValidityTerm5.Ticks);
            //�����s�ԍ��U
            writer.Write(temp.DepositRowNo6);
            //����R�[�h�U
            writer.Write(temp.MoneyKindCode6);
            //���햼�̂U
            writer.Write(temp.MoneyKindName6);
            //����敪�U
            writer.Write(temp.MoneyKindDiv6);
            //�������z�U
            writer.Write(temp.Deposit6);
            //�L�������U
            writer.Write((Int64)temp.ValidityTerm6.Ticks);
            //�����s�ԍ��V
            writer.Write(temp.DepositRowNo7);
            //����R�[�h�V
            writer.Write(temp.MoneyKindCode7);
            //���햼�̂V
            writer.Write(temp.MoneyKindName7);
            //����敪�V
            writer.Write(temp.MoneyKindDiv7);
            //�������z�V
            writer.Write(temp.Deposit7);
            //�L�������V
            writer.Write((Int64)temp.ValidityTerm7.Ticks);
            //�����s�ԍ��W
            writer.Write(temp.DepositRowNo8);
            //����R�[�h�W
            writer.Write(temp.MoneyKindCode8);
            //���햼�̂W
            writer.Write(temp.MoneyKindName8);
            //����敪�W
            writer.Write(temp.MoneyKindDiv8);
            //�������z�W
            writer.Write(temp.Deposit8);
            //�L�������W
            writer.Write((Int64)temp.ValidityTerm8.Ticks);
            //�����s�ԍ��X
            writer.Write(temp.DepositRowNo9);
            //����R�[�h�X
            writer.Write(temp.MoneyKindCode9);
            //���햼�̂X
            writer.Write(temp.MoneyKindName9);
            //����敪�X
            writer.Write(temp.MoneyKindDiv9);
            //�������z�X
            writer.Write(temp.Deposit9);
            //�L�������X
            writer.Write((Int64)temp.ValidityTerm9.Ticks);
            //�����s�ԍ��P�O
            writer.Write(temp.DepositRowNo10);
            //����R�[�h�P�O
            writer.Write(temp.MoneyKindCode10);
            //���햼�̂P�O
            writer.Write(temp.MoneyKindName10);
            //����敪�P�O
            writer.Write(temp.MoneyKindDiv10);
            //�������z�P�O
            writer.Write(temp.Deposit10);
            //�L�������P�O
            writer.Write((Int64)temp.ValidityTerm10.Ticks);

        }

        /// <summary>
        ///  DepsitDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>DepsitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private DepsitDataWork GetDepsitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DepsitDataWork temp = new DepsitDataWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //�����ԍ��敪
            temp.DepositDebitNoteCd = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.DepositSlipNo = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�������͋��_�R�[�h
            temp.InputDepositSecCd = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���͓��t
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�������t
            temp.DepositDate = new DateTime(reader.ReadInt64());
            //�������t
            temp.PreDepositDate = new DateTime(reader.ReadInt64()); // ADD 2011/12/15
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�����v
            temp.DepositTotal = reader.ReadInt64();
            //�������z
            temp.Deposit = reader.ReadInt64();
            //�萔�������z
            temp.FeeDeposit = reader.ReadInt64();
            //�l�������z
            temp.DiscountDeposit = reader.ReadInt64();
            //���������敪
            temp.AutoDepositCd = reader.ReadInt32();
            //��`�U�o��
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //��`���
            temp.DraftKind = reader.ReadInt32();
            //��`��ޖ���
            temp.DraftKindName = reader.ReadString();
            //��`�敪
            temp.DraftDivide = reader.ReadInt32();
            //��`�敪����
            temp.DraftDivideName = reader.ReadString();
            //��`�ԍ�
            temp.DraftNo = reader.ReadString();
            //���������z
            temp.DepositAllowance = reader.ReadInt64();
            //���������c��
            temp.DepositAlwcBlnce = reader.ReadInt64();
            //�ԍ������A���ԍ�
            temp.DebitNoteLinkDepoNo = reader.ReadInt32();
            //�ŏI�������݌v���
            temp.LastReconcileAddUpDt = new DateTime(reader.ReadInt64());
            //�����S���҃R�[�h
            temp.DepositAgentCode = reader.ReadString();
            //�����S���Җ���
            temp.DepositAgentNm = reader.ReadString();
            //�������͎҃R�[�h
            temp.DepositInputAgentCd = reader.ReadString();
            //�������͎Җ���
            temp.DepositInputAgentNm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //��s�R�[�h
            temp.BankCode = reader.ReadInt32();
            //��s����
            temp.BankName = reader.ReadString();
            //�����s�ԍ��P
            temp.DepositRowNo1 = reader.ReadInt32();
            //����R�[�h�P
            temp.MoneyKindCode1 = reader.ReadInt32();
            //���햼�̂P
            temp.MoneyKindName1 = reader.ReadString();
            //����敪�P
            temp.MoneyKindDiv1 = reader.ReadInt32();
            //�������z�P
            temp.Deposit1 = reader.ReadInt64();
            //�L�������P
            temp.ValidityTerm1 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��Q
            temp.DepositRowNo2 = reader.ReadInt32();
            //����R�[�h�Q
            temp.MoneyKindCode2 = reader.ReadInt32();
            //���햼�̂Q
            temp.MoneyKindName2 = reader.ReadString();
            //����敪�Q
            temp.MoneyKindDiv2 = reader.ReadInt32();
            //�������z�Q
            temp.Deposit2 = reader.ReadInt64();
            //�L�������Q
            temp.ValidityTerm2 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��R
            temp.DepositRowNo3 = reader.ReadInt32();
            //����R�[�h�R
            temp.MoneyKindCode3 = reader.ReadInt32();
            //���햼�̂R
            temp.MoneyKindName3 = reader.ReadString();
            //����敪�R
            temp.MoneyKindDiv3 = reader.ReadInt32();
            //�������z�R
            temp.Deposit3 = reader.ReadInt64();
            //�L�������R
            temp.ValidityTerm3 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��S
            temp.DepositRowNo4 = reader.ReadInt32();
            //����R�[�h�S
            temp.MoneyKindCode4 = reader.ReadInt32();
            //���햼�̂S
            temp.MoneyKindName4 = reader.ReadString();
            //����敪�S
            temp.MoneyKindDiv4 = reader.ReadInt32();
            //�������z�S
            temp.Deposit4 = reader.ReadInt64();
            //�L�������S
            temp.ValidityTerm4 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��T
            temp.DepositRowNo5 = reader.ReadInt32();
            //����R�[�h�T
            temp.MoneyKindCode5 = reader.ReadInt32();
            //���햼�̂T
            temp.MoneyKindName5 = reader.ReadString();
            //����敪�T
            temp.MoneyKindDiv5 = reader.ReadInt32();
            //�������z�T
            temp.Deposit5 = reader.ReadInt64();
            //�L�������T
            temp.ValidityTerm5 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��U
            temp.DepositRowNo6 = reader.ReadInt32();
            //����R�[�h�U
            temp.MoneyKindCode6 = reader.ReadInt32();
            //���햼�̂U
            temp.MoneyKindName6 = reader.ReadString();
            //����敪�U
            temp.MoneyKindDiv6 = reader.ReadInt32();
            //�������z�U
            temp.Deposit6 = reader.ReadInt64();
            //�L�������U
            temp.ValidityTerm6 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��V
            temp.DepositRowNo7 = reader.ReadInt32();
            //����R�[�h�V
            temp.MoneyKindCode7 = reader.ReadInt32();
            //���햼�̂V
            temp.MoneyKindName7 = reader.ReadString();
            //����敪�V
            temp.MoneyKindDiv7 = reader.ReadInt32();
            //�������z�V
            temp.Deposit7 = reader.ReadInt64();
            //�L�������V
            temp.ValidityTerm7 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��W
            temp.DepositRowNo8 = reader.ReadInt32();
            //����R�[�h�W
            temp.MoneyKindCode8 = reader.ReadInt32();
            //���햼�̂W
            temp.MoneyKindName8 = reader.ReadString();
            //����敪�W
            temp.MoneyKindDiv8 = reader.ReadInt32();
            //�������z�W
            temp.Deposit8 = reader.ReadInt64();
            //�L�������W
            temp.ValidityTerm8 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��X
            temp.DepositRowNo9 = reader.ReadInt32();
            //����R�[�h�X
            temp.MoneyKindCode9 = reader.ReadInt32();
            //���햼�̂X
            temp.MoneyKindName9 = reader.ReadString();
            //����敪�X
            temp.MoneyKindDiv9 = reader.ReadInt32();
            //�������z�X
            temp.Deposit9 = reader.ReadInt64();
            //�L�������X
            temp.ValidityTerm9 = new DateTime(reader.ReadInt64());
            //�����s�ԍ��P�O
            temp.DepositRowNo10 = reader.ReadInt32();
            //����R�[�h�P�O
            temp.MoneyKindCode10 = reader.ReadInt32();
            //���햼�̂P�O
            temp.MoneyKindName10 = reader.ReadString();
            //����敪�P�O
            temp.MoneyKindDiv10 = reader.ReadInt32();
            //�������z�P�O
            temp.Deposit10 = reader.ReadInt64();
            //�L�������P�O
            temp.ValidityTerm10 = new DateTime(reader.ReadInt64());


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>DepsitDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepsitDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepsitDataWork temp = GetDepsitDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (DepsitDataWork[])lst.ToArray(typeof(DepsitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

    /// <summary>
    /// �����f�[�^
    /// </summary>
    public static class DepsitDataUtil
    {
        /// <summary>
        /// �����}�X�^�f�[�^�Ɠ������׃f�[�^�����̂��܂��B
        /// </summary>
        /// <param name="depsitDataWrk">�����f�[�^���[�N(����)</param>
        /// <param name="depsitMainWrk">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWrkArray">�������׃f�[�^�̔z��</param>
        public static void Union(out DepsitDataWork depsitDataWrk, DepsitMainWork depsitMainWrk, DepsitDtlWork[] depsitDtlWrkArray)
        {
            depsitDataWrk = new DepsitDataWork();
            DepsitDataUtil.UnionRef(ref depsitDataWrk, depsitMainWrk, depsitDtlWrkArray);
        }

        /// <summary>
        /// �����}�X�^�f�[�^�Ɠ������׃f�[�^�����̂��܂��B
        /// </summary>
        /// <param name="depsitDataWrk">�����f�[�^���[�N(����)</param>
        /// <param name="depsitMainWrk">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWrkArray">�������׃f�[�^�̔z��</param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        public static void UnionRef(ref DepsitDataWork depsitDataWrk, DepsitMainWork depsitMainWrk, DepsitDtlWork[] depsitDtlWrkArray)
        {
            if (depsitDataWrk != null)
            {
                # region [DepsitDataWork �� DepsitMainWork]
                if (depsitMainWrk != null)
                {
                    depsitDataWrk.CreateDateTime = depsitMainWrk.CreateDateTime;              // �쐬����
                    depsitDataWrk.UpdateDateTime = depsitMainWrk.UpdateDateTime;              // �X�V����
                    depsitDataWrk.EnterpriseCode = depsitMainWrk.EnterpriseCode;              // ��ƃR�[�h
                    depsitDataWrk.FileHeaderGuid = depsitMainWrk.FileHeaderGuid;              // GUID
                    depsitDataWrk.UpdEmployeeCode = depsitMainWrk.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
                    depsitDataWrk.UpdAssemblyId1 = depsitMainWrk.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
                    depsitDataWrk.UpdAssemblyId2 = depsitMainWrk.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
                    depsitDataWrk.LogicalDeleteCode = depsitMainWrk.LogicalDeleteCode;        // �_���폜�敪
                    depsitDataWrk.AcptAnOdrStatus = depsitMainWrk.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
                    depsitDataWrk.DepositDebitNoteCd = depsitMainWrk.DepositDebitNoteCd;      // �����ԍ��敪
                    depsitDataWrk.DepositSlipNo = depsitMainWrk.DepositSlipNo;                // �����`�[�ԍ�
                    depsitDataWrk.SalesSlipNum = depsitMainWrk.SalesSlipNum;                  // ����`�[�ԍ�
                    depsitDataWrk.InputDepositSecCd = depsitMainWrk.InputDepositSecCd;        // �������͋��_�R�[�h
                    depsitDataWrk.AddUpSecCode = depsitMainWrk.AddUpSecCode;                  // �v�㋒�_�R�[�h
                    depsitDataWrk.UpdateSecCd = depsitMainWrk.UpdateSecCd;                    // �X�V���_�R�[�h
                    depsitDataWrk.SubSectionCode = depsitMainWrk.SubSectionCode;              // ����R�[�h
                    depsitDataWrk.InputDay = depsitMainWrk.InputDay;                          // ���͓��t  //ADD 2009/03/25
                    depsitDataWrk.DepositDate = depsitMainWrk.DepositDate;                    // �������t
                    depsitDataWrk.PreDepositDate = depsitMainWrk.PreDepositDate;              // �������t // ADD 2011/12/21
                    depsitDataWrk.AddUpADate = depsitMainWrk.AddUpADate;                      // �v����t
                    depsitDataWrk.DepositTotal = depsitMainWrk.DepositTotal;                  // �����v
                    depsitDataWrk.Deposit = depsitMainWrk.Deposit;                            // �������z
                    depsitDataWrk.FeeDeposit = depsitMainWrk.FeeDeposit;                      // �萔�������z
                    depsitDataWrk.DiscountDeposit = depsitMainWrk.DiscountDeposit;            // �l�������z
                    depsitDataWrk.AutoDepositCd = depsitMainWrk.AutoDepositCd;                // ���������敪
                    depsitDataWrk.DraftDrawingDate = depsitMainWrk.DraftDrawingDate;          // ��`�U�o��
                    depsitDataWrk.DraftKind = depsitMainWrk.DraftKind;                        // ��`���
                    depsitDataWrk.DraftKindName = depsitMainWrk.DraftKindName;                // ��`��ޖ���
                    depsitDataWrk.DraftDivide = depsitMainWrk.DraftDivide;                    // ��`�敪
                    depsitDataWrk.DraftDivideName = depsitMainWrk.DraftDivideName;            // ��`�敪����
                    depsitDataWrk.DraftNo = depsitMainWrk.DraftNo;                            // ��`�ԍ�
                    depsitDataWrk.DepositAllowance = depsitMainWrk.DepositAllowance;          // ���������z
                    depsitDataWrk.DepositAlwcBlnce = depsitMainWrk.DepositAlwcBlnce;          // ���������c��
                    depsitDataWrk.DebitNoteLinkDepoNo = depsitMainWrk.DebitNoteLinkDepoNo;    // �ԍ������A���ԍ�
                    depsitDataWrk.LastReconcileAddUpDt = depsitMainWrk.LastReconcileAddUpDt;  // �ŏI�������݌v���
                    depsitDataWrk.DepositAgentCode = depsitMainWrk.DepositAgentCode;          // �����S���҃R�[�h
                    depsitDataWrk.DepositAgentNm = depsitMainWrk.DepositAgentNm;              // �����S���Җ���
                    depsitDataWrk.DepositInputAgentCd = depsitMainWrk.DepositInputAgentCd;    // �������͎҃R�[�h
                    depsitDataWrk.DepositInputAgentNm = depsitMainWrk.DepositInputAgentNm;    // �������͎Җ���
                    depsitDataWrk.CustomerCode = depsitMainWrk.CustomerCode;                  // ���Ӑ�R�[�h
                    depsitDataWrk.CustomerName = depsitMainWrk.CustomerName;                  // ���Ӑ於��
                    depsitDataWrk.CustomerName2 = depsitMainWrk.CustomerName2;                // ���Ӑ於��2
                    depsitDataWrk.CustomerSnm = depsitMainWrk.CustomerSnm;                    // ���Ӑ旪��
                    depsitDataWrk.ClaimCode = depsitMainWrk.ClaimCode;                        // ������R�[�h
                    depsitDataWrk.ClaimName = depsitMainWrk.ClaimName;                        // �����於��
                    depsitDataWrk.ClaimName2 = depsitMainWrk.ClaimName2;                      // �����於��2
                    depsitDataWrk.ClaimSnm = depsitMainWrk.ClaimSnm;                          // �����旪��
                    depsitDataWrk.Outline = depsitMainWrk.Outline;                            // �`�[�E�v
                    depsitDataWrk.BankCode = depsitMainWrk.BankCode;                          // ��s�R�[�h
                    depsitDataWrk.BankName = depsitMainWrk.BankName;                          // ��s����
                }
                # endregion

                # region [DepsitDataWork �� DepsitDtlWork ]
                if (depsitDtlWrkArray != null)
                {
                    for (int idx = 0; idx < depsitDtlWrkArray.Length; idx++)
                    {
                        DepsitDtlWork depsitDtlWrk = depsitDtlWrkArray[idx];

                        switch (depsitDtlWrk.DepositRowNo)
                        {
                            case 1:
                                {
                                    depsitDataWrk.DepositRowNo1 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode1 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName1 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv1 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit1 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm1 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 2:
                                {
                                    depsitDataWrk.DepositRowNo2 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode2 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName2 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv2 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit2 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm2 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 3:
                                {
                                    depsitDataWrk.DepositRowNo3 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode3 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName3 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv3 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit3 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm3 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 4:
                                {
                                    depsitDataWrk.DepositRowNo4 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode4 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName4 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv4 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit4 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm4 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 5:
                                {
                                    depsitDataWrk.DepositRowNo5 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode5 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName5 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv5 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit5 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm5 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 6:
                                {
                                    depsitDataWrk.DepositRowNo6 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode6 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName6 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv6 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit6 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm6 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 7:
                                {
                                    depsitDataWrk.DepositRowNo7 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode7 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName7 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv7 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit7 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm7 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 8:
                                {
                                    depsitDataWrk.DepositRowNo8 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode8 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName8 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv8 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit8 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm8 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 9:
                                {
                                    depsitDataWrk.DepositRowNo9 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode9 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName9 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv9 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit9 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm9 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                            case 10:
                                {
                                    depsitDataWrk.DepositRowNo10 = depsitDtlWrk.DepositRowNo;
                                    depsitDataWrk.MoneyKindCode10 = depsitDtlWrk.MoneyKindCode;
                                    depsitDataWrk.MoneyKindName10 = depsitDtlWrk.MoneyKindName;
                                    depsitDataWrk.MoneyKindDiv10 = depsitDtlWrk.MoneyKindDiv;
                                    depsitDataWrk.Deposit10 = depsitDtlWrk.Deposit;
                                    depsitDataWrk.ValidityTerm10 = depsitDtlWrk.ValidityTerm;
                                    break;
                                }
                        }
                    }
                }
                # endregion
            }
        }

        /// <summary>
        /// �����f�[�^(����)������}�X�^�f�[�^�Ɠ������׃f�[�^�ɕ������܂��B
        /// </summary>
        /// <param name="depsitDataWrk">�����f�[�^���[�N(����)</param>
        /// <param name="depsitMainWrk">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWrkArray">�������׃f�[�^�̔z��</param>
        public static void Division(DepsitDataWork depsitDataWrk, out DepsitMainWork depsitMainWrk, out DepsitDtlWork[] depsitDtlWrkArray)
        {
            depsitMainWrk = new DepsitMainWork();
            depsitDtlWrkArray = new DepsitDtlWork[0];
            DepsitDataUtil.DivisionRef(depsitDataWrk, ref depsitMainWrk, ref depsitDtlWrkArray);
        }

        /// <summary>
        /// �����f�[�^(����)������}�X�^�f�[�^�Ɠ������׃f�[�^�ɕ������܂��B
        /// </summary>
        /// <param name="depsitDataWrk">�����f�[�^���[�N(����)</param>
        /// <param name="depsitMainWrk">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWrkArray">�������׃f�[�^�̔z��</param>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        public static void DivisionRef(DepsitDataWork depsitDataWrk, ref DepsitMainWork depsitMainWrk, ref DepsitDtlWork[] depsitDtlWrkArray)
        {
            if (depsitDataWrk != null && depsitMainWrk != null && depsitDtlWrkArray != null)
            {
                # region [DepsitMainWork �� DepsitDataWork]
                depsitMainWrk.CreateDateTime = depsitDataWrk.CreateDateTime;              // �쐬����
                depsitMainWrk.UpdateDateTime = depsitDataWrk.UpdateDateTime;              // �X�V����
                depsitMainWrk.EnterpriseCode = depsitDataWrk.EnterpriseCode;              // ��ƃR�[�h
                depsitMainWrk.FileHeaderGuid = depsitDataWrk.FileHeaderGuid;              // GUID
                depsitMainWrk.UpdEmployeeCode = depsitDataWrk.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
                depsitMainWrk.UpdAssemblyId1 = depsitDataWrk.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
                depsitMainWrk.UpdAssemblyId2 = depsitDataWrk.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
                depsitMainWrk.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;        // �_���폜�敪
                depsitMainWrk.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
                depsitMainWrk.DepositDebitNoteCd = depsitDataWrk.DepositDebitNoteCd;      // �����ԍ��敪
                depsitMainWrk.DepositSlipNo = depsitDataWrk.DepositSlipNo;                // �����`�[�ԍ�
                depsitMainWrk.SalesSlipNum = depsitDataWrk.SalesSlipNum;                  // ����`�[�ԍ�
                depsitMainWrk.InputDepositSecCd = depsitDataWrk.InputDepositSecCd;        // �������͋��_�R�[�h
                depsitMainWrk.AddUpSecCode = depsitDataWrk.AddUpSecCode;                  // �v�㋒�_�R�[�h
                depsitMainWrk.UpdateSecCd = depsitDataWrk.UpdateSecCd;                    // �X�V���_�R�[�h
                depsitMainWrk.SubSectionCode = depsitDataWrk.SubSectionCode;              // ����R�[�h
                depsitMainWrk.InputDay = depsitDataWrk.InputDay;                          // ���͓��t  //ADD 2009/03/25
                depsitMainWrk.DepositDate = depsitDataWrk.DepositDate;                    // �������t
                depsitMainWrk.PreDepositDate = depsitDataWrk.PreDepositDate;              // �O��������t // ADD 2011/12/15
                depsitMainWrk.AddUpADate = depsitDataWrk.AddUpADate;                      // �v����t
                depsitMainWrk.DepositTotal = depsitDataWrk.DepositTotal;                  // �����v
                depsitMainWrk.Deposit = depsitDataWrk.Deposit;                            // �������z
                depsitMainWrk.FeeDeposit = depsitDataWrk.FeeDeposit;                      // �萔�������z
                depsitMainWrk.DiscountDeposit = depsitDataWrk.DiscountDeposit;            // �l�������z
                depsitMainWrk.AutoDepositCd = depsitDataWrk.AutoDepositCd;                // ���������敪
                depsitMainWrk.DraftDrawingDate = depsitDataWrk.DraftDrawingDate;          // ��`�U�o��
                depsitMainWrk.DraftKind = depsitDataWrk.DraftKind;                        // ��`���
                depsitMainWrk.DraftKindName = depsitDataWrk.DraftKindName;                // ��`��ޖ���
                depsitMainWrk.DraftDivide = depsitDataWrk.DraftDivide;                    // ��`�敪
                depsitMainWrk.DraftDivideName = depsitDataWrk.DraftDivideName;            // ��`�敪����
                depsitMainWrk.DraftNo = depsitDataWrk.DraftNo;                            // ��`�ԍ�
                depsitMainWrk.DepositAllowance = depsitDataWrk.DepositAllowance;          // ���������z
                depsitMainWrk.DepositAlwcBlnce = depsitDataWrk.DepositAlwcBlnce;          // ���������c��
                depsitMainWrk.DebitNoteLinkDepoNo = depsitDataWrk.DebitNoteLinkDepoNo;    // �ԍ������A���ԍ�
                depsitMainWrk.LastReconcileAddUpDt = depsitDataWrk.LastReconcileAddUpDt;  // �ŏI�������݌v���
                depsitMainWrk.DepositAgentCode = depsitDataWrk.DepositAgentCode;          // �����S���҃R�[�h
                depsitMainWrk.DepositAgentNm = depsitDataWrk.DepositAgentNm;              // �����S���Җ���
                depsitMainWrk.DepositInputAgentCd = depsitDataWrk.DepositInputAgentCd;    // �������͎҃R�[�h
                depsitMainWrk.DepositInputAgentNm = depsitDataWrk.DepositInputAgentNm;    // �������͎Җ���
                depsitMainWrk.CustomerCode = depsitDataWrk.CustomerCode;                  // ���Ӑ�R�[�h
                depsitMainWrk.CustomerName = depsitDataWrk.CustomerName;                  // ���Ӑ於��
                depsitMainWrk.CustomerName2 = depsitDataWrk.CustomerName2;                // ���Ӑ於��2
                depsitMainWrk.CustomerSnm = depsitDataWrk.CustomerSnm;                    // ���Ӑ旪��
                depsitMainWrk.ClaimCode = depsitDataWrk.ClaimCode;                        // ������R�[�h
                depsitMainWrk.ClaimName = depsitDataWrk.ClaimName;                        // �����於��
                depsitMainWrk.ClaimName2 = depsitDataWrk.ClaimName2;                      // �����於��2
                depsitMainWrk.ClaimSnm = depsitDataWrk.ClaimSnm;                          // �����旪��
                depsitMainWrk.Outline = depsitDataWrk.Outline;                            // �`�[�E�v
                depsitMainWrk.BankCode = depsitDataWrk.BankCode;                          // ��s�R�[�h
                depsitMainWrk.BankName = depsitDataWrk.BankName;                          // ��s����
                # endregion

                # region [DepsitDtlWork[] �� DepsitDataWork]

                ArrayList depsitDtlWrkList = new ArrayList();
                
                if (depsitDataWrk.DepositRowNo1 > 0)
                {
                    DepsitDtlWork depsitDtlWrk1 = new DepsitDtlWork();
                    depsitDtlWrk1.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk1.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk1.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk1.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk1.DepositRowNo = depsitDataWrk.DepositRowNo1;
                    depsitDtlWrk1.MoneyKindCode = depsitDataWrk.MoneyKindCode1;
                    depsitDtlWrk1.MoneyKindName = depsitDataWrk.MoneyKindName1;
                    depsitDtlWrk1.MoneyKindDiv = depsitDataWrk.MoneyKindDiv1;
                    depsitDtlWrk1.Deposit = depsitDataWrk.Deposit1;
                    depsitDtlWrk1.ValidityTerm = depsitDataWrk.ValidityTerm1;
                    depsitDtlWrkList.Add(depsitDtlWrk1);
                }
                if (depsitDataWrk.DepositRowNo2 > 0)
                {
                    DepsitDtlWork depsitDtlWrk2 = new DepsitDtlWork();
                    depsitDtlWrk2.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk2.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk2.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk2.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk2.DepositRowNo = depsitDataWrk.DepositRowNo2;
                    depsitDtlWrk2.MoneyKindCode = depsitDataWrk.MoneyKindCode2;
                    depsitDtlWrk2.MoneyKindName = depsitDataWrk.MoneyKindName2;
                    depsitDtlWrk2.MoneyKindDiv = depsitDataWrk.MoneyKindDiv2;
                    depsitDtlWrk2.Deposit = depsitDataWrk.Deposit2;
                    depsitDtlWrk2.ValidityTerm = depsitDataWrk.ValidityTerm2;
                    depsitDtlWrkList.Add(depsitDtlWrk2);
                }
                if (depsitDataWrk.DepositRowNo3 > 0)
                {
                    DepsitDtlWork depsitDtlWrk3 = new DepsitDtlWork();
                    depsitDtlWrk3.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk3.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk3.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk3.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk3.DepositRowNo = depsitDataWrk.DepositRowNo3;
                    depsitDtlWrk3.MoneyKindCode = depsitDataWrk.MoneyKindCode3;
                    depsitDtlWrk3.MoneyKindName = depsitDataWrk.MoneyKindName3;
                    depsitDtlWrk3.MoneyKindDiv = depsitDataWrk.MoneyKindDiv3;
                    depsitDtlWrk3.Deposit = depsitDataWrk.Deposit3;
                    depsitDtlWrk3.ValidityTerm = depsitDataWrk.ValidityTerm3;
                    depsitDtlWrkList.Add(depsitDtlWrk3);
                }
                if (depsitDataWrk.DepositRowNo4 > 0)
                {
                    DepsitDtlWork depsitDtlWrk4 = new DepsitDtlWork();
                    depsitDtlWrk4.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk4.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk4.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk4.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk4.DepositRowNo = depsitDataWrk.DepositRowNo4;
                    depsitDtlWrk4.MoneyKindCode = depsitDataWrk.MoneyKindCode4;
                    depsitDtlWrk4.MoneyKindName = depsitDataWrk.MoneyKindName4;
                    depsitDtlWrk4.MoneyKindDiv = depsitDataWrk.MoneyKindDiv4;
                    depsitDtlWrk4.Deposit = depsitDataWrk.Deposit4;
                    depsitDtlWrk4.ValidityTerm = depsitDataWrk.ValidityTerm4;
                    depsitDtlWrkList.Add(depsitDtlWrk4);
                }
                if (depsitDataWrk.DepositRowNo5 > 0)
                {
                    DepsitDtlWork depsitDtlWrk5 = new DepsitDtlWork();
                    depsitDtlWrk5.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk5.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk5.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk5.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk5.DepositRowNo = depsitDataWrk.DepositRowNo5;
                    depsitDtlWrk5.MoneyKindCode = depsitDataWrk.MoneyKindCode5;
                    depsitDtlWrk5.MoneyKindName = depsitDataWrk.MoneyKindName5;
                    depsitDtlWrk5.MoneyKindDiv = depsitDataWrk.MoneyKindDiv5;
                    depsitDtlWrk5.Deposit = depsitDataWrk.Deposit5;
                    depsitDtlWrk5.ValidityTerm = depsitDataWrk.ValidityTerm5;
                    depsitDtlWrkList.Add(depsitDtlWrk5);
                }
                if (depsitDataWrk.DepositRowNo6 > 0)
                {
                    DepsitDtlWork depsitDtlWrk6 = new DepsitDtlWork();
                    depsitDtlWrk6.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk6.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk6.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk6.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk6.DepositRowNo = depsitDataWrk.DepositRowNo6;
                    depsitDtlWrk6.MoneyKindCode = depsitDataWrk.MoneyKindCode6;
                    depsitDtlWrk6.MoneyKindName = depsitDataWrk.MoneyKindName6;
                    depsitDtlWrk6.MoneyKindDiv = depsitDataWrk.MoneyKindDiv6;
                    depsitDtlWrk6.Deposit = depsitDataWrk.Deposit6;
                    depsitDtlWrk6.ValidityTerm = depsitDataWrk.ValidityTerm6;
                    depsitDtlWrkList.Add(depsitDtlWrk6);
                }
                if (depsitDataWrk.DepositRowNo7 > 0)
                {
                    DepsitDtlWork depsitDtlWrk7 = new DepsitDtlWork();
                    depsitDtlWrk7.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk7.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk7.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk7.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk7.DepositRowNo = depsitDataWrk.DepositRowNo7;
                    depsitDtlWrk7.MoneyKindCode = depsitDataWrk.MoneyKindCode7;
                    depsitDtlWrk7.MoneyKindName = depsitDataWrk.MoneyKindName7;
                    depsitDtlWrk7.MoneyKindDiv = depsitDataWrk.MoneyKindDiv7;
                    depsitDtlWrk7.Deposit = depsitDataWrk.Deposit7;
                    depsitDtlWrk7.ValidityTerm = depsitDataWrk.ValidityTerm7;
                    depsitDtlWrkList.Add(depsitDtlWrk7);
                }
                if (depsitDataWrk.DepositRowNo8 > 0)
                {
                    DepsitDtlWork depsitDtlWrk8 = new DepsitDtlWork();
                    depsitDtlWrk8.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk8.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk8.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk8.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk8.DepositRowNo = depsitDataWrk.DepositRowNo8;
                    depsitDtlWrk8.MoneyKindCode = depsitDataWrk.MoneyKindCode8;
                    depsitDtlWrk8.MoneyKindName = depsitDataWrk.MoneyKindName8;
                    depsitDtlWrk8.MoneyKindDiv = depsitDataWrk.MoneyKindDiv8;
                    depsitDtlWrk8.Deposit = depsitDataWrk.Deposit8;
                    depsitDtlWrk8.ValidityTerm = depsitDataWrk.ValidityTerm8;
                    depsitDtlWrkList.Add(depsitDtlWrk8);
                }
                if (depsitDataWrk.DepositRowNo9 > 0)
                {
                    DepsitDtlWork depsitDtlWrk9 = new DepsitDtlWork();
                    depsitDtlWrk9.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk9.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk9.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk9.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk9.DepositRowNo = depsitDataWrk.DepositRowNo9;
                    depsitDtlWrk9.MoneyKindCode = depsitDataWrk.MoneyKindCode9;
                    depsitDtlWrk9.MoneyKindName = depsitDataWrk.MoneyKindName9;
                    depsitDtlWrk9.MoneyKindDiv = depsitDataWrk.MoneyKindDiv9;
                    depsitDtlWrk9.Deposit = depsitDataWrk.Deposit9;
                    depsitDtlWrk9.ValidityTerm = depsitDataWrk.ValidityTerm9;
                    depsitDtlWrkList.Add(depsitDtlWrk9);
                }
                if (depsitDataWrk.DepositRowNo10 > 0)
                {
                    DepsitDtlWork depsitDtlWrk10 = new DepsitDtlWork();
                    depsitDtlWrk10.EnterpriseCode = depsitDataWrk.EnterpriseCode;
                    depsitDtlWrk10.LogicalDeleteCode = depsitDataWrk.LogicalDeleteCode;
                    depsitDtlWrk10.AcptAnOdrStatus = depsitDataWrk.AcptAnOdrStatus;
                    depsitDtlWrk10.DepositSlipNo = depsitDataWrk.DepositSlipNo;
                    depsitDtlWrk10.DepositRowNo = depsitDataWrk.DepositRowNo10;
                    depsitDtlWrk10.MoneyKindCode = depsitDataWrk.MoneyKindCode10;
                    depsitDtlWrk10.MoneyKindName = depsitDataWrk.MoneyKindName10;
                    depsitDtlWrk10.MoneyKindDiv = depsitDataWrk.MoneyKindDiv10;
                    depsitDtlWrk10.Deposit = depsitDataWrk.Deposit10;
                    depsitDtlWrk10.ValidityTerm = depsitDataWrk.ValidityTerm10;
                    depsitDtlWrkList.Add(depsitDtlWrk10);
                }

                if (depsitDtlWrkList != null && depsitDtlWrkList.Count > 0)
                {
                    depsitDtlWrkArray = (DepsitDtlWork[])depsitDtlWrkList.ToArray(typeof(DepsitDtlWork));
                }
                # endregion
            }
        }


    }
}
