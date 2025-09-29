using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentDataWork
    /// <summary>
    ///                      �x���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentDataWork : IFileHeader
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

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����̐e�R�[�h</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�x�����͋��_�R�[�h</summary>
        /// <remarks>�����^ �x�����͂������_�R�[�h</remarks>
        private string _paymentInpSectionCd = "";

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

        /// <summary>�x�����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        // ----- ADD 2011/12/15 ------->>>>>
        /// <summary>�O��x�����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _prePaymentDate;
        // ----- ADD 2011/12/15 -------<<<<<

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>�x���v</summary>
        /// <remarks>�x�����z�{�萔���x���z�{�l���x���z</remarks>
        private Int64 _paymentTotal;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

        /// <summary>�萔���x���z</summary>
        private Int64 _feePayment;

        /// <summary>�l���x���z</summary>
        private Int64 _discountPayment;

        /// <summary>�����x���敪</summary>
        /// <remarks>0:�ʏ�x��,�@1:�����x��</remarks>
        private Int32 _autoPayment;

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

        /// <summary>�ԍ��x���A���ԍ�</summary>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>�x���S���҃R�[�h</summary>
        private string _paymentAgentCode = "";

        /// <summary>�x���S���Җ���</summary>
        private string _paymentAgentName = "";

        /// <summary>�x�����͎҃R�[�h</summary>
        private string _paymentInputAgentCd = "";

        /// <summary>�x�����͎Җ���</summary>
        private string _paymentInputAgentNm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>�X�֋ǁF9900</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        private string _bankName = "";

        /// <summary>�x���s�ԍ��P</summary>
        private Int32 _paymentRowNo1;

        /// <summary>����R�[�h�P</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode1;

        /// <summary>���햼�̂P</summary>
        private string _moneyKindName1 = "";

        /// <summary>����敪�P</summary>
        private Int32 _moneyKindDiv1;

        /// <summary>�x�����z�P</summary>
        private Int64 _payment1;

        /// <summary>�L�������P</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm1;

        /// <summary>�x���s�ԍ��Q</summary>
        private Int32 _paymentRowNo2;

        /// <summary>����R�[�h�Q</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode2;

        /// <summary>���햼�̂Q</summary>
        private string _moneyKindName2 = "";

        /// <summary>����敪�Q</summary>
        private Int32 _moneyKindDiv2;

        /// <summary>�x�����z�Q</summary>
        private Int64 _payment2;

        /// <summary>�L�������Q</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm2;

        /// <summary>�x���s�ԍ��R</summary>
        private Int32 _paymentRowNo3;

        /// <summary>����R�[�h�R</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode3;

        /// <summary>���햼�̂R</summary>
        private string _moneyKindName3 = "";

        /// <summary>����敪�R</summary>
        private Int32 _moneyKindDiv3;

        /// <summary>�x�����z�R</summary>
        private Int64 _payment3;

        /// <summary>�L�������R</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm3;

        /// <summary>�x���s�ԍ��S</summary>
        private Int32 _paymentRowNo4;

        /// <summary>����R�[�h�S</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode4;

        /// <summary>���햼�̂S</summary>
        private string _moneyKindName4 = "";

        /// <summary>����敪�S</summary>
        private Int32 _moneyKindDiv4;

        /// <summary>�x�����z�S</summary>
        private Int64 _payment4;

        /// <summary>�L�������S</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm4;

        /// <summary>�x���s�ԍ��T</summary>
        private Int32 _paymentRowNo5;

        /// <summary>����R�[�h�T</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode5;

        /// <summary>���햼�̂T</summary>
        private string _moneyKindName5 = "";

        /// <summary>����敪�T</summary>
        private Int32 _moneyKindDiv5;

        /// <summary>�x�����z�T</summary>
        private Int64 _payment5;

        /// <summary>�L�������T</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm5;

        /// <summary>�x���s�ԍ��U</summary>
        private Int32 _paymentRowNo6;

        /// <summary>����R�[�h�U</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode6;

        /// <summary>���햼�̂U</summary>
        private string _moneyKindName6 = "";

        /// <summary>����敪�U</summary>
        private Int32 _moneyKindDiv6;

        /// <summary>�x�����z�U</summary>
        private Int64 _payment6;

        /// <summary>�L�������U</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm6;

        /// <summary>�x���s�ԍ��V</summary>
        private Int32 _paymentRowNo7;

        /// <summary>����R�[�h�V</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode7;

        /// <summary>���햼�̂V</summary>
        private string _moneyKindName7 = "";

        /// <summary>����敪�V</summary>
        private Int32 _moneyKindDiv7;

        /// <summary>�x�����z�V</summary>
        private Int64 _payment7;

        /// <summary>�L�������V</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm7;

        /// <summary>�x���s�ԍ��W</summary>
        private Int32 _paymentRowNo8;

        /// <summary>����R�[�h�W</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode8;

        /// <summary>���햼�̂W</summary>
        private string _moneyKindName8 = "";

        /// <summary>����敪�W</summary>
        private Int32 _moneyKindDiv8;

        /// <summary>�x�����z�W</summary>
        private Int64 _payment8;

        /// <summary>�L�������W</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm8;

        /// <summary>�x���s�ԍ��X</summary>
        private Int32 _paymentRowNo9;

        /// <summary>����R�[�h�X</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode9;

        /// <summary>���햼�̂X</summary>
        private string _moneyKindName9 = "";

        /// <summary>����敪�X</summary>
        private Int32 _moneyKindDiv9;

        /// <summary>�x�����z�X</summary>
        private Int64 _payment9;

        /// <summary>�L�������X</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm9;

        /// <summary>�x���s�ԍ��P�O</summary>
        private Int32 _paymentRowNo10;

        /// <summary>����R�[�h�P�O</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode10;

        /// <summary>���햼�̂P�O</summary>
        private string _moneyKindName10 = "";

        /// <summary>����敪�P�O</summary>
        private Int32 _moneyKindDiv10;

        /// <summary>�x�����z�P�O</summary>
        private Int64 _payment10;

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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�x���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�x����̐e�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>�x�����͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �x�����͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
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

        /// public propaty name  :  PaymentDate
        /// <summary>�x�����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        // ----- ADD 2011/12/15 ------------------------------------->>>>>
        /// public propaty name  :  PrePaymentDate
        /// <summary>�O��x�����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��x�����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PrePaymentDate
        {
            get { return _prePaymentDate; }
            set { _prePaymentDate = value; }
        }
        // ----- ADD 2011/12/15 -------------------------------------<<<<<

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

        /// public propaty name  :  PaymentTotal
        /// <summary>�x���v�v���p�e�B</summary>
        /// <value>�x�����z�{�萔���x���z�{�l���x���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>�x�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>�萔���x���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>�l���x���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>0:�ʏ�x��,�@1:�����x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
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

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>�ԍ��x���A���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��x���A���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>�x���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>�x���S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>�x�����͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>�x�����͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
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

        /// public propaty name  :  PaymentRowNo1
        /// <summary>�x���s�ԍ��P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo1
        {
            get { return _paymentRowNo1; }
            set { _paymentRowNo1 = value; }
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

        /// public propaty name  :  Payment1
        /// <summary>�x�����z�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment1
        {
            get { return _payment1; }
            set { _payment1 = value; }
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

        /// public propaty name  :  PaymentRowNo2
        /// <summary>�x���s�ԍ��Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo2
        {
            get { return _paymentRowNo2; }
            set { _paymentRowNo2 = value; }
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

        /// public propaty name  :  Payment2
        /// <summary>�x�����z�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment2
        {
            get { return _payment2; }
            set { _payment2 = value; }
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

        /// public propaty name  :  PaymentRowNo3
        /// <summary>�x���s�ԍ��R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo3
        {
            get { return _paymentRowNo3; }
            set { _paymentRowNo3 = value; }
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

        /// public propaty name  :  Payment3
        /// <summary>�x�����z�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment3
        {
            get { return _payment3; }
            set { _payment3 = value; }
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

        /// public propaty name  :  PaymentRowNo4
        /// <summary>�x���s�ԍ��S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo4
        {
            get { return _paymentRowNo4; }
            set { _paymentRowNo4 = value; }
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

        /// public propaty name  :  Payment4
        /// <summary>�x�����z�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment4
        {
            get { return _payment4; }
            set { _payment4 = value; }
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

        /// public propaty name  :  PaymentRowNo5
        /// <summary>�x���s�ԍ��T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo5
        {
            get { return _paymentRowNo5; }
            set { _paymentRowNo5 = value; }
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

        /// public propaty name  :  Payment5
        /// <summary>�x�����z�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment5
        {
            get { return _payment5; }
            set { _payment5 = value; }
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

        /// public propaty name  :  PaymentRowNo6
        /// <summary>�x���s�ԍ��U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo6
        {
            get { return _paymentRowNo6; }
            set { _paymentRowNo6 = value; }
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

        /// public propaty name  :  Payment6
        /// <summary>�x�����z�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment6
        {
            get { return _payment6; }
            set { _payment6 = value; }
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

        /// public propaty name  :  PaymentRowNo7
        /// <summary>�x���s�ԍ��V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo7
        {
            get { return _paymentRowNo7; }
            set { _paymentRowNo7 = value; }
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

        /// public propaty name  :  Payment7
        /// <summary>�x�����z�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment7
        {
            get { return _payment7; }
            set { _payment7 = value; }
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

        /// public propaty name  :  PaymentRowNo8
        /// <summary>�x���s�ԍ��W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo8
        {
            get { return _paymentRowNo8; }
            set { _paymentRowNo8 = value; }
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

        /// public propaty name  :  Payment8
        /// <summary>�x�����z�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment8
        {
            get { return _payment8; }
            set { _payment8 = value; }
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

        /// public propaty name  :  PaymentRowNo9
        /// <summary>�x���s�ԍ��X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo9
        {
            get { return _paymentRowNo9; }
            set { _paymentRowNo9 = value; }
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

        /// public propaty name  :  Payment9
        /// <summary>�x�����z�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment9
        {
            get { return _payment9; }
            set { _payment9 = value; }
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

        /// public propaty name  :  PaymentRowNo10
        /// <summary>�x���s�ԍ��P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo10
        {
            get { return _paymentRowNo10; }
            set { _paymentRowNo10 = value; }
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

        /// public propaty name  :  Payment10
        /// <summary>�x�����z�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment10
        {
            get { return _payment10; }
            set { _payment10 = value; }
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
        /// �x���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PaymentDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PaymentDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PaymentDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PaymentDataWork || graph is ArrayList || graph is PaymentDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PaymentDataWork).FullName));

            if (graph != null && graph is PaymentDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PaymentDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PaymentDataWork[])graph).Length;
            }
            else if (graph is PaymentDataWork)
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
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�x���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�x�����͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���͓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PrePaymentDate // ADD 2011/12/15
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�x���v
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //�x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //�萔���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //�l���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //�����x���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
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
            //�ԍ��x���A���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //�x���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //�x���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //�x�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //�x�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //��s�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //��s����
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //�x���s�ԍ��P
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo1
            //����R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode1
            //���햼�̂P
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName1
            //����敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv1
            //�x�����z�P
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment1
            //�L�������P
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm1
            //�x���s�ԍ��Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo2
            //����R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode2
            //���햼�̂Q
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName2
            //����敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv2
            //�x�����z�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment2
            //�L�������Q
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm2
            //�x���s�ԍ��R
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo3
            //����R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode3
            //���햼�̂R
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName3
            //����敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv3
            //�x�����z�R
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment3
            //�L�������R
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm3
            //�x���s�ԍ��S
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo4
            //����R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode4
            //���햼�̂S
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName4
            //����敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv4
            //�x�����z�S
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment4
            //�L�������S
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm4
            //�x���s�ԍ��T
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo5
            //����R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode5
            //���햼�̂T
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName5
            //����敪�T
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv5
            //�x�����z�T
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment5
            //�L�������T
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm5
            //�x���s�ԍ��U
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo6
            //����R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode6
            //���햼�̂U
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName6
            //����敪�U
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv6
            //�x�����z�U
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment6
            //�L�������U
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm6
            //�x���s�ԍ��V
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo7
            //����R�[�h�V
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode7
            //���햼�̂V
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName7
            //����敪�V
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv7
            //�x�����z�V
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment7
            //�L�������V
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm7
            //�x���s�ԍ��W
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo8
            //����R�[�h�W
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode8
            //���햼�̂W
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName8
            //����敪�W
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv8
            //�x�����z�W
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment8
            //�L�������W
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm8
            //�x���s�ԍ��X
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo9
            //����R�[�h�X
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode9
            //���햼�̂X
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName9
            //����敪�X
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv9
            //�x�����z�X
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment9
            //�L�������X
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm9
            //�x���s�ԍ��P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo10
            //����R�[�h�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindCode10
            //���햼�̂P�O
            serInfo.MemberInfo.Add(typeof(string)); //MoneyKindName10
            //����敪�P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //MoneyKindDiv10
            //�x�����z�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment10
            //�L�������P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //ValidityTerm10


            serInfo.Serialize(writer, serInfo);
            if (graph is PaymentDataWork)
            {
                PaymentDataWork temp = (PaymentDataWork)graph;

                SetPaymentDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PaymentDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PaymentDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PaymentDataWork temp in lst)
                {
                    SetPaymentDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PaymentDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 106; // DEL 2011/12/15
        private const int currentMemberCount = 107; // ADD 2011/12/15

        /// <summary>
        ///  PaymentDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPaymentDataWork(System.IO.BinaryWriter writer, PaymentDataWork temp)
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
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�x���`�[�ԍ�
            writer.Write(temp.PaymentSlipNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於��2
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�x�����͋��_�R�[�h
            writer.Write(temp.PaymentInpSectionCd);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���͓��t
            writer.Write((Int64)temp.InputDay.Ticks);
            //�x�����t
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //�x�����t
            writer.Write((Int64)temp.PrePaymentDate.Ticks); // ADD 2011/12/15
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�x���v
            writer.Write(temp.PaymentTotal);
            //�x�����z
            writer.Write(temp.Payment);
            //�萔���x���z
            writer.Write(temp.FeePayment);
            //�l���x���z
            writer.Write(temp.DiscountPayment);
            //�����x���敪
            writer.Write(temp.AutoPayment);
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
            //�ԍ��x���A���ԍ�
            writer.Write(temp.DebitNoteLinkPayNo);
            //�x���S���҃R�[�h
            writer.Write(temp.PaymentAgentCode);
            //�x���S���Җ���
            writer.Write(temp.PaymentAgentName);
            //�x�����͎҃R�[�h
            writer.Write(temp.PaymentInputAgentCd);
            //�x�����͎Җ���
            writer.Write(temp.PaymentInputAgentNm);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //��s�R�[�h
            writer.Write(temp.BankCode);
            //��s����
            writer.Write(temp.BankName);
            //�x���s�ԍ��P
            writer.Write(temp.PaymentRowNo1);
            //����R�[�h�P
            writer.Write(temp.MoneyKindCode1);
            //���햼�̂P
            writer.Write(temp.MoneyKindName1);
            //����敪�P
            writer.Write(temp.MoneyKindDiv1);
            //�x�����z�P
            writer.Write(temp.Payment1);
            //�L�������P
            writer.Write(temp.ValidityTerm1.Ticks);
            //�x���s�ԍ��Q
            writer.Write(temp.PaymentRowNo2);
            //����R�[�h�Q
            writer.Write(temp.MoneyKindCode2);
            //���햼�̂Q
            writer.Write(temp.MoneyKindName2);
            //����敪�Q
            writer.Write(temp.MoneyKindDiv2);
            //�x�����z�Q
            writer.Write(temp.Payment2);
            //�L�������Q
            writer.Write(temp.ValidityTerm2.Ticks);
            //�x���s�ԍ��R
            writer.Write(temp.PaymentRowNo3);
            //����R�[�h�R
            writer.Write(temp.MoneyKindCode3);
            //���햼�̂R
            writer.Write(temp.MoneyKindName3);
            //����敪�R
            writer.Write(temp.MoneyKindDiv3);
            //�x�����z�R
            writer.Write(temp.Payment3);
            //�L�������R
            writer.Write(temp.ValidityTerm3.Ticks);
            //�x���s�ԍ��S
            writer.Write(temp.PaymentRowNo4);
            //����R�[�h�S
            writer.Write(temp.MoneyKindCode4);
            //���햼�̂S
            writer.Write(temp.MoneyKindName4);
            //����敪�S
            writer.Write(temp.MoneyKindDiv4);
            //�x�����z�S
            writer.Write(temp.Payment4);
            //�L�������S
            writer.Write(temp.ValidityTerm4.Ticks);
            //�x���s�ԍ��T
            writer.Write(temp.PaymentRowNo5);
            //����R�[�h�T
            writer.Write(temp.MoneyKindCode5);
            //���햼�̂T
            writer.Write(temp.MoneyKindName5);
            //����敪�T
            writer.Write(temp.MoneyKindDiv5);
            //�x�����z�T
            writer.Write(temp.Payment5);
            //�L�������T
            writer.Write(temp.ValidityTerm5.Ticks);
            //�x���s�ԍ��U
            writer.Write(temp.PaymentRowNo6);
            //����R�[�h�U
            writer.Write(temp.MoneyKindCode6);
            //���햼�̂U
            writer.Write(temp.MoneyKindName6);
            //����敪�U
            writer.Write(temp.MoneyKindDiv6);
            //�x�����z�U
            writer.Write(temp.Payment6);
            //�L�������U
            writer.Write(temp.ValidityTerm6.Ticks);
            //�x���s�ԍ��V
            writer.Write(temp.PaymentRowNo7);
            //����R�[�h�V
            writer.Write(temp.MoneyKindCode7);
            //���햼�̂V
            writer.Write(temp.MoneyKindName7);
            //����敪�V
            writer.Write(temp.MoneyKindDiv7);
            //�x�����z�V
            writer.Write(temp.Payment7);
            //�L�������V
            writer.Write(temp.ValidityTerm7.Ticks);
            //�x���s�ԍ��W
            writer.Write(temp.PaymentRowNo8);
            //����R�[�h�W
            writer.Write(temp.MoneyKindCode8);
            //���햼�̂W
            writer.Write(temp.MoneyKindName8);
            //����敪�W
            writer.Write(temp.MoneyKindDiv8);
            //�x�����z�W
            writer.Write(temp.Payment8);
            //�L�������W
            writer.Write(temp.ValidityTerm8.Ticks);
            //�x���s�ԍ��X
            writer.Write(temp.PaymentRowNo9);
            //����R�[�h�X
            writer.Write(temp.MoneyKindCode9);
            //���햼�̂X
            writer.Write(temp.MoneyKindName9);
            //����敪�X
            writer.Write(temp.MoneyKindDiv9);
            //�x�����z�X
            writer.Write(temp.Payment9);
            //�L�������X
            writer.Write(temp.ValidityTerm9.Ticks);
            //�x���s�ԍ��P�O
            writer.Write(temp.PaymentRowNo10);
            //����R�[�h�P�O
            writer.Write(temp.MoneyKindCode10);
            //���햼�̂P�O
            writer.Write(temp.MoneyKindName10);
            //����敪�P�O
            writer.Write(temp.MoneyKindDiv10);
            //�x�����z�P�O
            writer.Write(temp.Payment10);
            //�L�������P�O
            writer.Write(temp.ValidityTerm10.Ticks);

        }

        /// <summary>
        ///  PaymentDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PaymentDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PaymentDataWork GetPaymentDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PaymentDataWork temp = new PaymentDataWork();

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
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�x���`�[�ԍ�
            temp.PaymentSlipNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於��2
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�x�����͋��_�R�[�h
            temp.PaymentInpSectionCd = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���͓��t
            temp.InputDay = new DateTime(reader.ReadInt64());
            //�x�����t
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //�x�����t
            temp.PrePaymentDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�x���v
            temp.PaymentTotal = reader.ReadInt64();
            //�x�����z
            temp.Payment = reader.ReadInt64();
            //�萔���x���z
            temp.FeePayment = reader.ReadInt64();
            //�l���x���z
            temp.DiscountPayment = reader.ReadInt64();
            //�����x���敪
            temp.AutoPayment = reader.ReadInt32();
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
            //�ԍ��x���A���ԍ�
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //�x���S���҃R�[�h
            temp.PaymentAgentCode = reader.ReadString();
            //�x���S���Җ���
            temp.PaymentAgentName = reader.ReadString();
            //�x�����͎҃R�[�h
            temp.PaymentInputAgentCd = reader.ReadString();
            //�x�����͎Җ���
            temp.PaymentInputAgentNm = reader.ReadString();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //��s�R�[�h
            temp.BankCode = reader.ReadInt32();
            //��s����
            temp.BankName = reader.ReadString();
            //�x���s�ԍ��P
            temp.PaymentRowNo1 = reader.ReadInt32();
            //����R�[�h�P
            temp.MoneyKindCode1 = reader.ReadInt32();
            //���햼�̂P
            temp.MoneyKindName1 = reader.ReadString();
            //����敪�P
            temp.MoneyKindDiv1 = reader.ReadInt32();
            //�x�����z�P
            temp.Payment1 = reader.ReadInt64();
            //�L�������P
            temp.ValidityTerm1 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��Q
            temp.PaymentRowNo2 = reader.ReadInt32();
            //����R�[�h�Q
            temp.MoneyKindCode2 = reader.ReadInt32();
            //���햼�̂Q
            temp.MoneyKindName2 = reader.ReadString();
            //����敪�Q
            temp.MoneyKindDiv2 = reader.ReadInt32();
            //�x�����z�Q
            temp.Payment2 = reader.ReadInt64();
            //�L�������Q
            temp.ValidityTerm2 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��R
            temp.PaymentRowNo3 = reader.ReadInt32();
            //����R�[�h�R
            temp.MoneyKindCode3 = reader.ReadInt32();
            //���햼�̂R
            temp.MoneyKindName3 = reader.ReadString();
            //����敪�R
            temp.MoneyKindDiv3 = reader.ReadInt32();
            //�x�����z�R
            temp.Payment3 = reader.ReadInt64();
            //�L�������R
            temp.ValidityTerm3 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��S
            temp.PaymentRowNo4 = reader.ReadInt32();
            //����R�[�h�S
            temp.MoneyKindCode4 = reader.ReadInt32();
            //���햼�̂S
            temp.MoneyKindName4 = reader.ReadString();
            //����敪�S
            temp.MoneyKindDiv4 = reader.ReadInt32();
            //�x�����z�S
            temp.Payment4 = reader.ReadInt64();
            //�L�������S
            temp.ValidityTerm4 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��T
            temp.PaymentRowNo5 = reader.ReadInt32();
            //����R�[�h�T
            temp.MoneyKindCode5 = reader.ReadInt32();
            //���햼�̂T
            temp.MoneyKindName5 = reader.ReadString();
            //����敪�T
            temp.MoneyKindDiv5 = reader.ReadInt32();
            //�x�����z�T
            temp.Payment5 = reader.ReadInt64();
            //�L�������T
            temp.ValidityTerm5 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��U
            temp.PaymentRowNo6 = reader.ReadInt32();
            //����R�[�h�U
            temp.MoneyKindCode6 = reader.ReadInt32();
            //���햼�̂U
            temp.MoneyKindName6 = reader.ReadString();
            //����敪�U
            temp.MoneyKindDiv6 = reader.ReadInt32();
            //�x�����z�U
            temp.Payment6 = reader.ReadInt64();
            //�L�������U
            temp.ValidityTerm6 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��V
            temp.PaymentRowNo7 = reader.ReadInt32();
            //����R�[�h�V
            temp.MoneyKindCode7 = reader.ReadInt32();
            //���햼�̂V
            temp.MoneyKindName7 = reader.ReadString();
            //����敪�V
            temp.MoneyKindDiv7 = reader.ReadInt32();
            //�x�����z�V
            temp.Payment7 = reader.ReadInt64();
            //�L�������V
            temp.ValidityTerm7 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��W
            temp.PaymentRowNo8 = reader.ReadInt32();
            //����R�[�h�W
            temp.MoneyKindCode8 = reader.ReadInt32();
            //���햼�̂W
            temp.MoneyKindName8 = reader.ReadString();
            //����敪�W
            temp.MoneyKindDiv8 = reader.ReadInt32();
            //�x�����z�W
            temp.Payment8 = reader.ReadInt64();
            //�L�������W
            temp.ValidityTerm8 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��X
            temp.PaymentRowNo9 = reader.ReadInt32();
            //����R�[�h�X
            temp.MoneyKindCode9 = reader.ReadInt32();
            //���햼�̂X
            temp.MoneyKindName9 = reader.ReadString();
            //����敪�X
            temp.MoneyKindDiv9 = reader.ReadInt32();
            //�x�����z�X
            temp.Payment9 = reader.ReadInt64();
            //�L�������X
            temp.ValidityTerm9 = new DateTime(reader.ReadInt64());
            //�x���s�ԍ��P�O
            temp.PaymentRowNo10 = reader.ReadInt32();
            //����R�[�h�P�O
            temp.MoneyKindCode10 = reader.ReadInt32();
            //���햼�̂P�O
            temp.MoneyKindName10 = reader.ReadString();
            //����敪�P�O
            temp.MoneyKindDiv10 = reader.ReadInt32();
            //�x�����z�P�O
            temp.Payment10 = reader.ReadInt64();
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
        /// <returns>PaymentDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PaymentDataWork temp = GetPaymentDataWork(reader, serInfo);
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
                    retValue = (PaymentDataWork[])lst.ToArray(typeof(PaymentDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
