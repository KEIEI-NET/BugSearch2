using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   KingetCustDmdPrcWork
    /// <summary>
    ///                      KINGET�p���Ӑ搿�����z�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   KINGET�p���Ӑ搿�����z�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class KingetCustDmdPrcWork : IFileHeader
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

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _lastTimeDemand;

        /// <summary>����萔���z�i�ʏ�����j</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>����l���z�i�ʏ�����j</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>�����z�̍��v���z</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>����J�z�c���i�����v�j</summary>
        /// <remarks>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>���E�㍡�񔄏���z</summary>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡�񔄏�����</summary>
        private Int64 _ofsThisSalesTax;

        /// <summary>���E��O�őΏۊz</summary>
        /// <remarks>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetOutTax;

        /// <summary>���E����őΏۊz</summary>
        /// <remarks>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetInTax;

        /// <summary>���E���ېőΏۊz</summary>
        /// <remarks>���E�p�F��ېŊz�̏W�v</remarks>
        private Int64 _itdedOffsetTaxFree;

        /// <summary>���E��O�ŏ����</summary>
        /// <remarks>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _offsetOutTax;

        /// <summary>���E����ŏ����</summary>
        /// <remarks>���E�p�F���ŏ���ł̏W�v</remarks>
        private Int64 _offsetInTax;

        /// <summary>���񔄏���z</summary>
        /// <remarks>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
        private Int64 _thisTimeSales;

        /// <summary>���񔄏�����</summary>
        private Int64 _thisSalesTax;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>������őΏۊz</summary>
        /// <remarks>�����p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>�����ېőΏۊz</summary>
        /// <remarks>�����p�F��ېŊz�̏W�v</remarks>
        private Int64 _itdedSalesTaxFree;

        /// <summary>����O�Ŋz</summary>
        /// <remarks>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _salesOutTax;

        /// <summary>������Ŋz</summary>
        /// <remarks>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
        private Int64 _salesInTax;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>���񔄏�ԕi�����</summary>
        /// <remarks>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxRgds;

        /// <summary>�ԕi�O�őΏۊz���v</summary>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>�ԕi���őΏۊz���v</summary>
        private Int64 _ttlItdedRetInTax;

        /// <summary>�ԕi��ېőΏۊz���v</summary>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>�ԕi�O�Ŋz���v</summary>
        private Int64 _ttlRetOuterTax;

        /// <summary>�ԕi���Ŋz���v</summary>
        /// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
        private Int64 _ttlRetInnerTax;

        /// <summary>���񔄏�l�����z</summary>
        /// <remarks>�|���F�Ŕ����̔���l�����z</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>���񔄏�l�������</summary>
        /// <remarks>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxDis;

        /// <summary>�l���O�őΏۊz���v</summary>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>�l�����őΏۊz���v</summary>
        private Int64 _ttlItdedDisInTax;

        /// <summary>�l����ېőΏۊz���v</summary>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>�l���O�Ŋz���v</summary>
        private Int64 _ttlDisOuterTax;

        /// <summary>�l�����Ŋz���v</summary>
        /// <remarks>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</remarks>
        private Int64 _ttlDisInnerTax;

        //--- DEL 2008/04/25 M.Kubota --->>>
        //// <summary>����x�����E���z</summary>
        //// <remarks>���E�p�`�[�F���E�p����`�[�v�i���E�Ώۊz�j</remarks>
        //private Int64 _thisPayOffset;

        //// <summary>����x�����E�����</summary>
        //// <remarks>���E�p�`�[�F���E�p�������ō��v</remarks>
        //private Int64 _thisPayOffsetTax;

        //// <summary>�x���O�őΏۊz</summary>
        //// <remarks>���E�p�`�[�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        //private Int64 _itdedPaymOutTax;

        //// <summary>�x�����őΏۊz</summary>
        //// <remarks>���E�p�`�[�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        //private Int64 _itdedPaymInTax;

        //// <summary>�x����ېőΏۊz</summary>
        //// <remarks>���E�p�`�[�F��ېŊz�̏W�v</remarks>
        //private Int64 _itdedPaymTaxFree;

        //// <summary>�x���O�ŏ����</summary>
        //// <remarks>���E�p�`�[�F�O�ŏ���ł̏W�v</remarks>
        //private Int64 _paymentOutTax;

        //// <summary>�x�����ŏ����</summary>
        //// <remarks>���E�p�`�[�F���ŏ���ł̏W�v</remarks>
        //private Int64 _paymentInTax;
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�v�Z�㐿�����z</summary>
        /// <remarks>���񐿋����z</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>�O������X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>����`�[����</summary>
        /// <remarks>�|���̓`�[����</remarks>
        private Int32 _salesSlipCount;

        /// <summary>���������s��</summary>
        /// <remarks>"YYYYMMDD"  �������𔭍s�����N����</remarks>
        private DateTime _billPrintDate;

        /// <summary>�����\���</summary>
        private DateTime _expectedDepositDate;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����ŗ�</summary>
        /// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
        private Double _consTaxRate;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>�����R�[�h</summary>
        /// <remarks>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</remarks>
        private Int32 _outputNameCode;

        /// <summary>��������</summary>
        private string _outputName = "";

        /// <summary>�l�E�@�l�敪</summary>
        /// <remarks>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</remarks>
        private Int32 _corporateDivCode;

        /// <summary>�X�֔ԍ�</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address1 = "";

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// <summary>�Z��2�i���ځj</summary>
        ///// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        //private Int32 _address2;
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// <summary>�Z��3�i�Ԓn�j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _address4 = "";

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>FAX�ԍ��i����j</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private string _officeFaxNo = "";

        /// <summary>�d�b�ԍ��i���̑��j</summary>
        private string _othersTelNo = "";

        /// <summary>��A����敪</summary>
        /// <remarks>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</remarks>
        private Int32 _mainContactCode;

        /// <summary>���Ӑ敪�̓R�[�h1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>���Ӑ敪�̓R�[�h2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>���Ӑ敪�̓R�[�h3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>���Ӑ敪�̓R�[�h4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>���Ӑ敪�̓R�[�h5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>���Ӑ敪�̓R�[�h6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�W�����敪�R�[�h</summary>
        /// <remarks>0:����,1:����,2:���X��</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = "";

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentNm = "";

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>�W���S���]�ƈ�����</summary>
        private string _billCollecterNm = "";

        /// <summary>���ڋq�S���]�ƈ��R�[�h</summary>
        private string _oldCustomerAgentCd = "";

        /// <summary>���ڋq�S���]�ƈ�����</summary>
        private string _oldCustomerAgentNm = "";

        /// <summary>�ڋq�S���ύX��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>�v��N�����͈́i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _startDateSpan;

        /// <summary>�v��N�����͈́i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _endDateSpan;


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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
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

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>�O�񐿋����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񐿋����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>����l���z�i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>�����z�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>����J�z�c���i�����v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ItdedOffsetOutTax
        /// <summary>���E��O�őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetOutTax
        {
            get { return _itdedOffsetOutTax; }
            set { _itdedOffsetOutTax = value; }
        }

        /// public propaty name  :  ItdedOffsetInTax
        /// <summary>���E����őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetInTax
        {
            get { return _itdedOffsetInTax; }
            set { _itdedOffsetInTax = value; }
        }

        /// public propaty name  :  ItdedOffsetTaxFree
        /// <summary>���E���ېőΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E���ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetTaxFree
        {
            get { return _itdedOffsetTaxFree; }
            set { _itdedOffsetTaxFree = value; }
        }

        /// public propaty name  :  OffsetOutTax
        /// <summary>���E��O�ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetOutTax
        {
            get { return _offsetOutTax; }
            set { _offsetOutTax = value; }
        }

        /// public propaty name  :  OffsetInTax
        /// <summary>���E����ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F���ŏ���ł̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetInTax
        {
            get { return _offsetInTax; }
            set { _offsetInTax = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  ThisSalesTax
        /// <summary>���񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesTax
        {
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  ItdedSalesTaxFree
        /// <summary>�����ېőΏۊz�v���p�e�B</summary>
        /// <value>�����p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesTaxFree
        {
            get { return _itdedSalesTaxFree; }
            set { _itdedSalesTaxFree = value; }
        }

        /// public propaty name  :  SalesOutTax
        /// <summary>����O�Ŋz�v���p�e�B</summary>
        /// <value>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalesInTax
        /// <summary>������Ŋz�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesInTax
        {
            get { return _salesInTax; }
            set { _salesInTax = value; }
        }

        /// public propaty name  :  ThisSalesPricRgds
        /// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
        /// <value>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricRgds
        {
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxRgds
        /// <summary>���񔄏�ԕi����Ńv���p�e�B</summary>
        /// <value>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxRgds
        {
            get { return _thisSalesPrcTaxRgds; }
            set { _thisSalesPrcTaxRgds = value; }
        }

        /// public propaty name  :  TtlItdedRetOutTax
        /// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetOutTax
        {
            get { return _ttlItdedRetOutTax; }
            set { _ttlItdedRetOutTax = value; }
        }

        /// public propaty name  :  TtlItdedRetInTax
        /// <summary>�ԕi���őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetInTax
        {
            get { return _ttlItdedRetInTax; }
            set { _ttlItdedRetInTax = value; }
        }

        /// public propaty name  :  TtlItdedRetTaxFree
        /// <summary>�ԕi��ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi��ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetTaxFree
        {
            get { return _ttlItdedRetTaxFree; }
            set { _ttlItdedRetTaxFree = value; }
        }

        /// public propaty name  :  TtlRetOuterTax
        /// <summary>�ԕi�O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlRetOuterTax
        {
            get { return _ttlRetOuterTax; }
            set { _ttlRetOuterTax = value; }
        }

        /// public propaty name  :  TtlRetInnerTax
        /// <summary>�ԕi���Ŋz���v�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlRetInnerTax
        {
            get { return _ttlRetInnerTax; }
            set { _ttlRetInnerTax = value; }
        }

        /// public propaty name  :  ThisSalesPricDis
        /// <summary>���񔄏�l�����z�v���p�e�B</summary>
        /// <value>�|���F�Ŕ����̔���l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricDis
        {
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxDis
        /// <summary>���񔄏�l������Ńv���p�e�B</summary>
        /// <value>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxDis
        {
            get { return _thisSalesPrcTaxDis; }
            set { _thisSalesPrcTaxDis = value; }
        }

        /// public propaty name  :  TtlItdedDisOutTax
        /// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisOutTax
        {
            get { return _ttlItdedDisOutTax; }
            set { _ttlItdedDisOutTax = value; }
        }

        /// public propaty name  :  TtlItdedDisInTax
        /// <summary>�l�����őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisInTax
        {
            get { return _ttlItdedDisInTax; }
            set { _ttlItdedDisInTax = value; }
        }

        /// public propaty name  :  TtlItdedDisTaxFree
        /// <summary>�l����ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisTaxFree
        {
            get { return _ttlItdedDisTaxFree; }
            set { _ttlItdedDisTaxFree = value; }
        }

        /// public propaty name  :  TtlDisOuterTax
        /// <summary>�l���O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlDisOuterTax
        {
            get { return _ttlDisOuterTax; }
            set { _ttlDisOuterTax = value; }
        }

        /// public propaty name  :  TtlDisInnerTax
        /// <summary>�l�����Ŋz���v�v���p�e�B</summary>
        /// <value>�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlDisInnerTax
        {
            get { return _ttlDisInnerTax; }
            set { _ttlDisInnerTax = value; }
        }

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// public propaty name  :  ThisPayOffset
        ///// <summary>����x�����E���z�v���p�e�B</summary>
        ///// <value>���E�p�`�[�F���E�p����`�[�v�i���E�Ώۊz�j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ����x�����E���z�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ThisPayOffset
        //{
        //    get { return _thisPayOffset; }
        //    set { _thisPayOffset = value; }
        //}

        ///// public propaty name  :  ThisPayOffsetTax
        ///// <summary>����x�����E����Ńv���p�e�B</summary>
        ///// <value>���E�p�`�[�F���E�p�������ō��v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ����x�����E����Ńv���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ThisPayOffsetTax
        //{
        //    get { return _thisPayOffsetTax; }
        //    set { _thisPayOffsetTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymOutTax
        ///// <summary>�x���O�őΏۊz�v���p�e�B</summary>
        ///// <value>���E�p�`�[�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �x���O�őΏۊz�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ItdedPaymOutTax
        //{
        //    get { return _itdedPaymOutTax; }
        //    set { _itdedPaymOutTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymInTax
        ///// <summary>�x�����őΏۊz�v���p�e�B</summary>
        ///// <value>���E�p�`�[�F���Ŋz�i�Ŕ����j�̏W�v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �x�����őΏۊz�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        ////public Int64 ItdedPaymInTax
        //{
        //    get { return _itdedPaymInTax; }
        //    set { _itdedPaymInTax = value; }
        //}

        ///// public propaty name  :  ItdedPaymTaxFree
        ///// <summary>�x����ېőΏۊz�v���p�e�B</summary>
        ///// <value>���E�p�`�[�F��ېŊz�̏W�v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �x����ېőΏۊz�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ItdedPaymTaxFree
        //{
        //    get { return _itdedPaymTaxFree; }
        //    set { _itdedPaymTaxFree = value; }
        //}

        ///// public propaty name  :  PaymentOutTax
        ///// <summary>�x���O�ŏ���Ńv���p�e�B</summary>
        ///// <value>���E�p�`�[�F�O�ŏ���ł̏W�v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �x���O�ŏ���Ńv���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 PaymentOutTax
        //{
        //    get { return _paymentOutTax; }
        //    set { _paymentOutTax = value; }
        //}

        ///// public propaty name  :  PaymentInTax
        ///// <summary>�x�����ŏ���Ńv���p�e�B</summary>
        ///// <value>���E�p�`�[�F���ŏ���ł̏W�v</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �x�����ŏ���Ńv���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 PaymentInTax
        //{
        //    get { return _paymentInTax; }
        //    set { _paymentInTax = value; }
        //}
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>�v�Z�㐿�����z�v���p�e�B</summary>
        /// <value>���񐿋����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�Z�㐿�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>��2��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��2��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>��3��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��3��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDate
        /// <summary>�O������X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastCAddUpUpdDate
        {
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>�|���̓`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  BillPrintDate
        /// <summary>���������s���v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �������𔭍s�����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime BillPrintDate
        {
            get { return _billPrintDate; }
            set { _billPrintDate = value; }
        }

        /// public propaty name  :  ExpectedDepositDate
        /// <summary>�����\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExpectedDepositDate
        {
            get { return _expectedDepositDate; }
            set { _expectedDepositDate = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>����ŗ��v���p�e�B</summary>
        /// <value>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>�����R�[�h�v���p�e�B</summary>
        /// <value>0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>�l�E�@�l�敪�v���p�e�B</summary>
        /// <value>0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�E�@�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        //--- DEL 2008/04/25 M.Kubota --->>>
        ///// public propaty name  :  Address2
        ///// <summary>�Z��2�i���ځj�v���p�e�B</summary>
        ///// <value>�[����̏ꍇ�̎g�p�\����</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �Z��2�i���ځj�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 Address2
        //{
        //    get { return _address2; }
        //    set { _address2 = value; }
        //}
        //--- DEL 2008/04/25 M.Kubota ---<<<

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>�d�b�ԍ��i���̑��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i���̑��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>��A����敪�v���p�e�B</summary>
        /// <value>0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��A����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>���Ӑ敪�̓R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>���Ӑ敪�̓R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>���Ӑ敪�̓R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>���Ӑ敪�̓R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>���Ӑ敪�̓R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>���Ӑ敪�̓R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����,1:����,2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>���ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>���ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>�ڋq�S���ύX���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���ύX���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  StartDateSpan
        /// <summary>�v��N�����͈́i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����͈́i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartDateSpan
        {
            get { return _startDateSpan; }
            set { _startDateSpan = value; }
        }

        /// public propaty name  :  EndDateSpan
        /// <summary>�v��N�����͈́i�I���j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����͈́i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndDateSpan
        {
            get { return _endDateSpan; }
            set { _endDateSpan = value; }
        }


        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public KingetCustDmdPrcWork()
        {
        }

        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="claimCode">������R�[�h(������e�R�[�h)</param>
        /// <param name="claimName">�����於��</param>
        /// <param name="claimName2">�����於��2</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="addUpDate">�v��N����(YYYYMMDD ���������s�Ȃ������i������j)</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
        /// <param name="lastTimeDemand">�O�񐿋����z</param>
        /// <param name="thisTimeFeeDmdNrml">����萔���z�i�ʏ�����j</param>
        /// <param name="thisTimeDisDmdNrml">����l���z�i�ʏ�����j</param>
        /// <param name="thisTimeDmdNrml">����������z�i�ʏ�����j(�����z�̍��v���z)</param>
        /// <param name="thisTimeTtlBlcDmd">����J�z�c���i�����v�j(����J�z�c�����O�񐿋��z�|��������z���v�i�ʏ�j)</param>
        /// <param name="ofsThisTimeSales">���E�㍡�񔄏���z</param>
        /// <param name="ofsThisSalesTax">���E�㍡�񔄏�����</param>
        /// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetInTax">���E����őΏۊz(���E�p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E�p�F��ېŊz�̏W�v)</param>
        /// <param name="offsetOutTax">���E��O�ŏ����(���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="offsetInTax">���E����ŏ����(���E�p�F���ŏ���ł̏W�v)</param>
        /// <param name="thisTimeSales">���񔄏���z(�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z)</param>
        /// <param name="thisSalesTax">���񔄏�����</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz(�����p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedSalesInTax">������őΏۊz(�����p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedSalesTaxFree">�����ېőΏۊz(�����p�F��ېŊz�̏W�v)</param>
        /// <param name="salesOutTax">����O�Ŋz(�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="salesInTax">������Ŋz(�|���F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j)</param>
        /// <param name="thisSalesPricRgds">���񔄏�ԕi���z(�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z)</param>
        /// <param name="thisSalesPrcTaxRgds">���񔄏�ԕi�����(���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
        /// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v</param>
        /// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v</param>
        /// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v</param>
        /// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v</param>
        /// <param name="ttlRetInnerTax">�ԕi���Ŋz���v(�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j)</param>
        /// <param name="thisSalesPricDis">���񔄏�l�����z(�|���F�Ŕ����̔���l�����z)</param>
        /// <param name="thisSalesPrcTaxDis">���񔄏�l�������(���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v)</param>
        /// <param name="ttlItdedDisOutTax">�l���O�őΏۊz���v</param>
        /// <param name="ttlItdedDisInTax">�l�����őΏۊz���v</param>
        /// <param name="ttlItdedDisTaxFree">�l����ېőΏۊz���v</param>
        /// <param name="ttlDisOuterTax">�l���O�Ŋz���v</param>
        /// <param name="ttlDisInnerTax">�l�����Ŋz���v(�|���F���ŏ��i�ԕi�̓��ŏ���Ŋz)</param>
        /// <param name="taxAdjust">����Œ����z</param>
        /// <param name="balanceAdjust">�c�������z</param>
        /// <param name="afCalDemandPrice">�v�Z�㐿�����z(���񐿋����z)</param>
        /// <param name="acpOdrTtl2TmBfBlDmd">��2��O�c���i�����v�j</param>
        /// <param name="acpOdrTtl3TmBfBlDmd">��3��O�c���i�����v�j</param>
        /// <param name="cAddUpUpdExecDate">�����X�V���s�N����(YYYYMMDD)</param>
        /// <param name="startCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
        /// <param name="lastCAddUpUpdDate">�O������X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
        /// <param name="salesSlipCount">����`�[����(�|���̓`�[����)</param>
        /// <param name="billPrintDate">���������s��("YYYYMMDD"  �������𔭍s�����N����)</param>
        /// <param name="expectedDepositDate">�����\���</param>
        /// <param name="collectCond">�������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ)</param>
        /// <param name="consTaxRate">����ŗ�(�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p)</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="kana">�J�i</param>
        /// <param name="outputNameCode">�����R�[�h(0:�ڋq����1��2,1:�ڋq����1,2:�ڋq����2,3:��������)</param>
        /// <param name="outputName">��������</param>
        /// <param name="corporateDivCode">�l�E�@�l�敪(0:�l,1:�@�l,2:����@�l,3:�Ǝ�,4:�Ј�)</param>
        /// <param name="postNo">�X�֔ԍ�(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address1">�Z��1�i�s���{���s��S�E�����E���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address3">�Z��3�i�Ԓn�j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="address4">�Z��4�i�A�p�[�g���́j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
        /// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
        /// <param name="homeFaxNo">FAX�ԍ��i����j</param>
        /// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="othersTelNo">�d�b�ԍ��i���̑��j</param>
        /// <param name="mainContactCode">��A����敪(0:����,1:�Ζ���,2:�g��,3:����FAX,4:�Ζ���FAX���)</param>
        /// <param name="custAnalysCode1">���Ӑ敪�̓R�[�h1</param>
        /// <param name="custAnalysCode2">���Ӑ敪�̓R�[�h2</param>
        /// <param name="custAnalysCode3">���Ӑ敪�̓R�[�h3</param>
        /// <param name="custAnalysCode4">���Ӑ敪�̓R�[�h4</param>
        /// <param name="custAnalysCode5">���Ӑ敪�̓R�[�h5</param>
        /// <param name="custAnalysCode6">���Ӑ敪�̓R�[�h6</param>
        /// <param name="totalDay">����(DD)</param>
        /// <param name="collectMoneyCode">�W�����敪�R�[�h(0:����,1:����,2:���X��)</param>
        /// <param name="collectMoneyName">�W�����敪����(����,����,���X��)</param>
        /// <param name="collectMoneyDay">�W����(DD)</param>
        /// <param name="customerAgentCd">�ڋq�S���]�ƈ��R�[�h(�����^)</param>
        /// <param name="customerAgentNm">�ڋq�S���]�ƈ�����(�����^)</param>
        /// <param name="billCollecterCd">�W���S���]�ƈ��R�[�h</param>
        /// <param name="billCollecterNm">�W���S���]�ƈ�����</param>
        /// <param name="oldCustomerAgentCd">���ڋq�S���]�ƈ��R�[�h</param>
        /// <param name="oldCustomerAgentNm">���ڋq�S���]�ƈ�����</param>
        /// <param name="custAgentChgDate">�ڋq�S���ύX��(YYYYMMDD)</param>
        /// <param name="startDateSpan">�v��N�����͈́i�J�n�j(YYYYMMDD)</param>
        /// <param name="endDateSpan">�v��N�����͈́i�I���j(YYYYMMDD)</param>
        /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public KingetCustDmdPrcWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 thisPayOffset, Int64 thisPayOffsetTax, Int64 itdedPaymOutTax, Int64 itdedPaymInTax, Int64 itdedPaymTaxFree, Int64 paymentOutTax, Int64 paymentInTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, string honorificTitle, string kana, Int32 outputNameCode, string outputName, Int32 corporateDivCode, string postNo, string address1, Int32 address2, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 startDateSpan, Int32 endDateSpan)  //DEL 2008/04/25 M.Kubota
        public KingetCustDmdPrcWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeSales, Int64 thisSalesTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 salesSlipCount, DateTime billPrintDate, DateTime expectedDepositDate, Int32 collectCond, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, string honorificTitle, string kana, Int32 outputNameCode, string outputName, Int32 corporateDivCode, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 startDateSpan, Int32 endDateSpan)                    //ADD 2008/04/25 M.Kubota
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._addUpSecCode = addUpSecCode;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimeDemand = lastTimeDemand;
            this._thisTimeFeeDmdNrml = thisTimeFeeDmdNrml;
            this._thisTimeDisDmdNrml = thisTimeDisDmdNrml;
            this._thisTimeDmdNrml = thisTimeDmdNrml;
            this._thisTimeTtlBlcDmd = thisTimeTtlBlcDmd;
            this._ofsThisTimeSales = ofsThisTimeSales;
            this._ofsThisSalesTax = ofsThisSalesTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._thisTimeSales = thisTimeSales;
            this._thisSalesTax = thisSalesTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._itdedSalesTaxFree = itdedSalesTaxFree;
            this._salesOutTax = salesOutTax;
            this._salesInTax = salesInTax;
            this._thisSalesPricRgds = thisSalesPricRgds;
            this._thisSalesPrcTaxRgds = thisSalesPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._thisSalesPricDis = thisSalesPricDis;
            this._thisSalesPrcTaxDis = thisSalesPrcTaxDis;
            this._ttlItdedDisOutTax = ttlItdedDisOutTax;
            this._ttlItdedDisInTax = ttlItdedDisInTax;
            this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
            this._ttlDisOuterTax = ttlDisOuterTax;
            this._ttlDisInnerTax = ttlDisInnerTax;
            //--- DEL 2008/04/25 M.Kubota --->>>
            //this._thisPayOffset = thisPayOffset;
            //this._thisPayOffsetTax = thisPayOffsetTax;
            //this._itdedPaymOutTax = itdedPaymOutTax;
            //this._itdedPaymInTax = itdedPaymInTax;
            //this._itdedPaymTaxFree = itdedPaymTaxFree;
            //this._paymentOutTax = paymentOutTax;
            //this._paymentInTax = paymentInTax;
            //--- DEL 2008/04/25 M.Kubota ---<<<
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._afCalDemandPrice = afCalDemandPrice;
            this._acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd;
            this._acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._salesSlipCount = salesSlipCount;
            this.BillPrintDate = billPrintDate;
            this.ExpectedDepositDate = expectedDepositDate;
            this._collectCond = collectCond;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._postNo = postNo;
            this._address1 = address1;
            //this._address2 = address2;  //DEL 2008/04/25 M.Kubota
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._billCollecterNm = billCollecterNm;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this.CustAgentChgDate = custAgentChgDate;
            this._startDateSpan = startDateSpan;
            this._endDateSpan = endDateSpan;

        }

        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X��������
        /// </summary>
        /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����KingetCustDmdPrcWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public KingetCustDmdPrcWork Clone()
        {
            //return new KingetCustDmdPrcWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._thisPayOffset, this._thisPayOffsetTax, this._itdedPaymOutTax, this._itdedPaymInTax, this._itdedPaymTaxFree, this._paymentOutTax, this._paymentInTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._honorificTitle, this._kana, this._outputNameCode, this._outputName, this._corporateDivCode, this._postNo, this._address1, this._address2, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._startDateSpan, this._endDateSpan);  //DEL 2008/04/25 M.Kubota
            return new KingetCustDmdPrcWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeDmdNrml, this._thisTimeTtlBlcDmd, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeSales, this._thisSalesTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._taxAdjust, this._balanceAdjust, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._salesSlipCount, this._billPrintDate, this._expectedDepositDate, this._collectCond, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._honorificTitle, this._kana, this._outputNameCode, this._outputName, this._corporateDivCode, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._startDateSpan, this._endDateSpan);                    //ADD 2008/04/25 M.Kubota
        }

        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�KingetCustDmdPrcWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(KingetCustDmdPrcWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimeDemand == target.LastTimeDemand)
                 && (this.ThisTimeFeeDmdNrml == target.ThisTimeFeeDmdNrml)
                 && (this.ThisTimeDisDmdNrml == target.ThisTimeDisDmdNrml)
                 && (this.ThisTimeDmdNrml == target.ThisTimeDmdNrml)
                 && (this.ThisTimeTtlBlcDmd == target.ThisTimeTtlBlcDmd)
                 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
                 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ThisTimeSales == target.ThisTimeSales)
                 && (this.ThisSalesTax == target.ThisSalesTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.ItdedSalesTaxFree == target.ItdedSalesTaxFree)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalesInTax == target.SalesInTax)
                 && (this.ThisSalesPricRgds == target.ThisSalesPricRgds)
                 && (this.ThisSalesPrcTaxRgds == target.ThisSalesPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.ThisSalesPricDis == target.ThisSalesPricDis)
                 && (this.ThisSalesPrcTaxDis == target.ThisSalesPrcTaxDis)
                 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
                 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
                 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
                 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
                 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
                 //--- DEL 2008/04/25 M.Kubota --->>>
                 //&& (this.ThisPayOffset == target.ThisPayOffset)
                 //&& (this.ThisPayOffsetTax == target.ThisPayOffsetTax)
                 //&& (this.ItdedPaymOutTax == target.ItdedPaymOutTax)
                 //&& (this.ItdedPaymInTax == target.ItdedPaymInTax)
                 //&& (this.ItdedPaymTaxFree == target.ItdedPaymTaxFree)
                 //&& (this.PaymentOutTax == target.PaymentOutTax)
                 //&& (this.PaymentInTax == target.PaymentInTax)
                 //--- DEL 2008/04/25 M.Kubota ---<<<
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.AfCalDemandPrice == target.AfCalDemandPrice)
                 && (this.AcpOdrTtl2TmBfBlDmd == target.AcpOdrTtl2TmBfBlDmd)
                 && (this.AcpOdrTtl3TmBfBlDmd == target.AcpOdrTtl3TmBfBlDmd)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.SalesSlipCount == target.SalesSlipCount)
                 && (this.BillPrintDate == target.BillPrintDate)
                 && (this.ExpectedDepositDate == target.ExpectedDepositDate)
                 && (this.CollectCond == target.CollectCond)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.OutputNameCode == target.OutputNameCode)
                 && (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 //&& (this.Address2 == target.Address2)  //DEL 2008/04/25 M.Kubota
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.StartDateSpan == target.StartDateSpan)
                 && (this.EndDateSpan == target.EndDateSpan));
        }

        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X��r����
        /// </summary>
        /// <param name="kingetCustDmdPrc1">
        ///                    ��r����KingetCustDmdPrcWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="kingetCustDmdPrc2">��r����KingetCustDmdPrcWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(KingetCustDmdPrcWork kingetCustDmdPrc1, KingetCustDmdPrcWork kingetCustDmdPrc2)
        {
            return ((kingetCustDmdPrc1.CreateDateTime == kingetCustDmdPrc2.CreateDateTime)
                 && (kingetCustDmdPrc1.UpdateDateTime == kingetCustDmdPrc2.UpdateDateTime)
                 && (kingetCustDmdPrc1.EnterpriseCode == kingetCustDmdPrc2.EnterpriseCode)
                 && (kingetCustDmdPrc1.FileHeaderGuid == kingetCustDmdPrc2.FileHeaderGuid)
                 && (kingetCustDmdPrc1.UpdEmployeeCode == kingetCustDmdPrc2.UpdEmployeeCode)
                 && (kingetCustDmdPrc1.UpdAssemblyId1 == kingetCustDmdPrc2.UpdAssemblyId1)
                 && (kingetCustDmdPrc1.UpdAssemblyId2 == kingetCustDmdPrc2.UpdAssemblyId2)
                 && (kingetCustDmdPrc1.LogicalDeleteCode == kingetCustDmdPrc2.LogicalDeleteCode)
                 && (kingetCustDmdPrc1.AddUpSecCode == kingetCustDmdPrc2.AddUpSecCode)
                 && (kingetCustDmdPrc1.ClaimCode == kingetCustDmdPrc2.ClaimCode)
                 && (kingetCustDmdPrc1.ClaimName == kingetCustDmdPrc2.ClaimName)
                 && (kingetCustDmdPrc1.ClaimName2 == kingetCustDmdPrc2.ClaimName2)
                 && (kingetCustDmdPrc1.ClaimSnm == kingetCustDmdPrc2.ClaimSnm)
                 && (kingetCustDmdPrc1.CustomerCode == kingetCustDmdPrc2.CustomerCode)
                 && (kingetCustDmdPrc1.CustomerName == kingetCustDmdPrc2.CustomerName)
                 && (kingetCustDmdPrc1.CustomerName2 == kingetCustDmdPrc2.CustomerName2)
                 && (kingetCustDmdPrc1.CustomerSnm == kingetCustDmdPrc2.CustomerSnm)
                 && (kingetCustDmdPrc1.AddUpDate == kingetCustDmdPrc2.AddUpDate)
                 && (kingetCustDmdPrc1.AddUpYearMonth == kingetCustDmdPrc2.AddUpYearMonth)
                 && (kingetCustDmdPrc1.LastTimeDemand == kingetCustDmdPrc2.LastTimeDemand)
                 && (kingetCustDmdPrc1.ThisTimeFeeDmdNrml == kingetCustDmdPrc2.ThisTimeFeeDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeDisDmdNrml == kingetCustDmdPrc2.ThisTimeDisDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeDmdNrml == kingetCustDmdPrc2.ThisTimeDmdNrml)
                 && (kingetCustDmdPrc1.ThisTimeTtlBlcDmd == kingetCustDmdPrc2.ThisTimeTtlBlcDmd)
                 && (kingetCustDmdPrc1.OfsThisTimeSales == kingetCustDmdPrc2.OfsThisTimeSales)
                 && (kingetCustDmdPrc1.OfsThisSalesTax == kingetCustDmdPrc2.OfsThisSalesTax)
                 && (kingetCustDmdPrc1.ItdedOffsetOutTax == kingetCustDmdPrc2.ItdedOffsetOutTax)
                 && (kingetCustDmdPrc1.ItdedOffsetInTax == kingetCustDmdPrc2.ItdedOffsetInTax)
                 && (kingetCustDmdPrc1.ItdedOffsetTaxFree == kingetCustDmdPrc2.ItdedOffsetTaxFree)
                 && (kingetCustDmdPrc1.OffsetOutTax == kingetCustDmdPrc2.OffsetOutTax)
                 && (kingetCustDmdPrc1.OffsetInTax == kingetCustDmdPrc2.OffsetInTax)
                 && (kingetCustDmdPrc1.ThisTimeSales == kingetCustDmdPrc2.ThisTimeSales)
                 && (kingetCustDmdPrc1.ThisSalesTax == kingetCustDmdPrc2.ThisSalesTax)
                 && (kingetCustDmdPrc1.ItdedSalesOutTax == kingetCustDmdPrc2.ItdedSalesOutTax)
                 && (kingetCustDmdPrc1.ItdedSalesInTax == kingetCustDmdPrc2.ItdedSalesInTax)
                 && (kingetCustDmdPrc1.ItdedSalesTaxFree == kingetCustDmdPrc2.ItdedSalesTaxFree)
                 && (kingetCustDmdPrc1.SalesOutTax == kingetCustDmdPrc2.SalesOutTax)
                 && (kingetCustDmdPrc1.SalesInTax == kingetCustDmdPrc2.SalesInTax)
                 && (kingetCustDmdPrc1.ThisSalesPricRgds == kingetCustDmdPrc2.ThisSalesPricRgds)
                 && (kingetCustDmdPrc1.ThisSalesPrcTaxRgds == kingetCustDmdPrc2.ThisSalesPrcTaxRgds)
                 && (kingetCustDmdPrc1.TtlItdedRetOutTax == kingetCustDmdPrc2.TtlItdedRetOutTax)
                 && (kingetCustDmdPrc1.TtlItdedRetInTax == kingetCustDmdPrc2.TtlItdedRetInTax)
                 && (kingetCustDmdPrc1.TtlItdedRetTaxFree == kingetCustDmdPrc2.TtlItdedRetTaxFree)
                 && (kingetCustDmdPrc1.TtlRetOuterTax == kingetCustDmdPrc2.TtlRetOuterTax)
                 && (kingetCustDmdPrc1.TtlRetInnerTax == kingetCustDmdPrc2.TtlRetInnerTax)
                 && (kingetCustDmdPrc1.ThisSalesPricDis == kingetCustDmdPrc2.ThisSalesPricDis)
                 && (kingetCustDmdPrc1.ThisSalesPrcTaxDis == kingetCustDmdPrc2.ThisSalesPrcTaxDis)
                 && (kingetCustDmdPrc1.TtlItdedDisOutTax == kingetCustDmdPrc2.TtlItdedDisOutTax)
                 && (kingetCustDmdPrc1.TtlItdedDisInTax == kingetCustDmdPrc2.TtlItdedDisInTax)
                 && (kingetCustDmdPrc1.TtlItdedDisTaxFree == kingetCustDmdPrc2.TtlItdedDisTaxFree)
                 && (kingetCustDmdPrc1.TtlDisOuterTax == kingetCustDmdPrc2.TtlDisOuterTax)
                 && (kingetCustDmdPrc1.TtlDisInnerTax == kingetCustDmdPrc2.TtlDisInnerTax)
                 //--- DEL 2008/04/25 M.Kubota --->>>
                 //&& (kingetCustDmdPrc1.ThisPayOffset == kingetCustDmdPrc2.ThisPayOffset)
                 //&& (kingetCustDmdPrc1.ThisPayOffsetTax == kingetCustDmdPrc2.ThisPayOffsetTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymOutTax == kingetCustDmdPrc2.ItdedPaymOutTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymInTax == kingetCustDmdPrc2.ItdedPaymInTax)
                 //&& (kingetCustDmdPrc1.ItdedPaymTaxFree == kingetCustDmdPrc2.ItdedPaymTaxFree)
                 //&& (kingetCustDmdPrc1.PaymentOutTax == kingetCustDmdPrc2.PaymentOutTax)
                 //&& (kingetCustDmdPrc1.PaymentInTax == kingetCustDmdPrc2.PaymentInTax)
                 //--- DEL 2008/04/25 M.Kubota ---<<<
                 && (kingetCustDmdPrc1.TaxAdjust == kingetCustDmdPrc2.TaxAdjust)
                 && (kingetCustDmdPrc1.BalanceAdjust == kingetCustDmdPrc2.BalanceAdjust)
                 && (kingetCustDmdPrc1.AfCalDemandPrice == kingetCustDmdPrc2.AfCalDemandPrice)
                 && (kingetCustDmdPrc1.AcpOdrTtl2TmBfBlDmd == kingetCustDmdPrc2.AcpOdrTtl2TmBfBlDmd)
                 && (kingetCustDmdPrc1.AcpOdrTtl3TmBfBlDmd == kingetCustDmdPrc2.AcpOdrTtl3TmBfBlDmd)
                 && (kingetCustDmdPrc1.CAddUpUpdExecDate == kingetCustDmdPrc2.CAddUpUpdExecDate)
                 && (kingetCustDmdPrc1.StartCAddUpUpdDate == kingetCustDmdPrc2.StartCAddUpUpdDate)
                 && (kingetCustDmdPrc1.LastCAddUpUpdDate == kingetCustDmdPrc2.LastCAddUpUpdDate)
                 && (kingetCustDmdPrc1.SalesSlipCount == kingetCustDmdPrc2.SalesSlipCount)
                 && (kingetCustDmdPrc1.BillPrintDate == kingetCustDmdPrc2.BillPrintDate)
                 && (kingetCustDmdPrc1.ExpectedDepositDate == kingetCustDmdPrc2.ExpectedDepositDate)
                 && (kingetCustDmdPrc1.CollectCond == kingetCustDmdPrc2.CollectCond)
                 && (kingetCustDmdPrc1.ConsTaxLayMethod == kingetCustDmdPrc2.ConsTaxLayMethod)
                 && (kingetCustDmdPrc1.ConsTaxRate == kingetCustDmdPrc2.ConsTaxRate)
                 && (kingetCustDmdPrc1.FractionProcCd == kingetCustDmdPrc2.FractionProcCd)
                 && (kingetCustDmdPrc1.HonorificTitle == kingetCustDmdPrc2.HonorificTitle)
                 && (kingetCustDmdPrc1.Kana == kingetCustDmdPrc2.Kana)
                 && (kingetCustDmdPrc1.OutputNameCode == kingetCustDmdPrc2.OutputNameCode)
                 && (kingetCustDmdPrc1.OutputName == kingetCustDmdPrc2.OutputName)
                 && (kingetCustDmdPrc1.CorporateDivCode == kingetCustDmdPrc2.CorporateDivCode)
                 && (kingetCustDmdPrc1.PostNo == kingetCustDmdPrc2.PostNo)
                 && (kingetCustDmdPrc1.Address1 == kingetCustDmdPrc2.Address1)
                 //&& (kingetCustDmdPrc1.Address2 == kingetCustDmdPrc2.Address2)  //DEL 2008/04/25 M.Kubota
                 && (kingetCustDmdPrc1.Address3 == kingetCustDmdPrc2.Address3)
                 && (kingetCustDmdPrc1.Address4 == kingetCustDmdPrc2.Address4)
                 && (kingetCustDmdPrc1.HomeTelNo == kingetCustDmdPrc2.HomeTelNo)
                 && (kingetCustDmdPrc1.OfficeTelNo == kingetCustDmdPrc2.OfficeTelNo)
                 && (kingetCustDmdPrc1.PortableTelNo == kingetCustDmdPrc2.PortableTelNo)
                 && (kingetCustDmdPrc1.HomeFaxNo == kingetCustDmdPrc2.HomeFaxNo)
                 && (kingetCustDmdPrc1.OfficeFaxNo == kingetCustDmdPrc2.OfficeFaxNo)
                 && (kingetCustDmdPrc1.OthersTelNo == kingetCustDmdPrc2.OthersTelNo)
                 && (kingetCustDmdPrc1.MainContactCode == kingetCustDmdPrc2.MainContactCode)
                 && (kingetCustDmdPrc1.CustAnalysCode1 == kingetCustDmdPrc2.CustAnalysCode1)
                 && (kingetCustDmdPrc1.CustAnalysCode2 == kingetCustDmdPrc2.CustAnalysCode2)
                 && (kingetCustDmdPrc1.CustAnalysCode3 == kingetCustDmdPrc2.CustAnalysCode3)
                 && (kingetCustDmdPrc1.CustAnalysCode4 == kingetCustDmdPrc2.CustAnalysCode4)
                 && (kingetCustDmdPrc1.CustAnalysCode5 == kingetCustDmdPrc2.CustAnalysCode5)
                 && (kingetCustDmdPrc1.CustAnalysCode6 == kingetCustDmdPrc2.CustAnalysCode6)
                 && (kingetCustDmdPrc1.TotalDay == kingetCustDmdPrc2.TotalDay)
                 && (kingetCustDmdPrc1.CollectMoneyCode == kingetCustDmdPrc2.CollectMoneyCode)
                 && (kingetCustDmdPrc1.CollectMoneyName == kingetCustDmdPrc2.CollectMoneyName)
                 && (kingetCustDmdPrc1.CollectMoneyDay == kingetCustDmdPrc2.CollectMoneyDay)
                 && (kingetCustDmdPrc1.CustomerAgentCd == kingetCustDmdPrc2.CustomerAgentCd)
                 && (kingetCustDmdPrc1.CustomerAgentNm == kingetCustDmdPrc2.CustomerAgentNm)
                 && (kingetCustDmdPrc1.BillCollecterCd == kingetCustDmdPrc2.BillCollecterCd)
                 && (kingetCustDmdPrc1.BillCollecterNm == kingetCustDmdPrc2.BillCollecterNm)
                 && (kingetCustDmdPrc1.OldCustomerAgentCd == kingetCustDmdPrc2.OldCustomerAgentCd)
                 && (kingetCustDmdPrc1.OldCustomerAgentNm == kingetCustDmdPrc2.OldCustomerAgentNm)
                 && (kingetCustDmdPrc1.CustAgentChgDate == kingetCustDmdPrc2.CustAgentChgDate)
                 && (kingetCustDmdPrc1.StartDateSpan == kingetCustDmdPrc2.StartDateSpan)
                 && (kingetCustDmdPrc1.EndDateSpan == kingetCustDmdPrc2.EndDateSpan));
        }
        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�KingetCustDmdPrcWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(KingetCustDmdPrcWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimeDemand != target.LastTimeDemand) resList.Add("LastTimeDemand");
            if (this.ThisTimeFeeDmdNrml != target.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (this.ThisTimeDisDmdNrml != target.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (this.ThisTimeDmdNrml != target.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (this.ThisTimeTtlBlcDmd != target.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (this.OfsThisTimeSales != target.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (this.OfsThisSalesTax != target.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ThisTimeSales != target.ThisTimeSales) resList.Add("ThisTimeSales");
            if (this.ThisSalesTax != target.ThisSalesTax) resList.Add("ThisSalesTax");
            if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (this.ItdedSalesTaxFree != target.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
            if (this.SalesInTax != target.SalesInTax) resList.Add("SalesInTax");
            if (this.ThisSalesPricRgds != target.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (this.ThisSalesPrcTaxRgds != target.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.ThisSalesPricDis != target.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (this.ThisSalesPrcTaxDis != target.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (this.TtlItdedDisOutTax != target.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (this.TtlItdedDisInTax != target.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (this.TtlDisOuterTax != target.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (this.TtlDisInnerTax != target.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (this.ThisPayOffset != target.ThisPayOffset) resList.Add("ThisPayOffset");
            //if (this.ThisPayOffsetTax != target.ThisPayOffsetTax) resList.Add("ThisPayOffsetTax");
            //if (this.ItdedPaymOutTax != target.ItdedPaymOutTax) resList.Add("ItdedPaymOutTax");
            //if (this.ItdedPaymInTax != target.ItdedPaymInTax) resList.Add("ItdedPaymInTax");
            //if (this.ItdedPaymTaxFree != target.ItdedPaymTaxFree) resList.Add("ItdedPaymTaxFree");
            //if (this.PaymentOutTax != target.PaymentOutTax) resList.Add("PaymentOutTax");
            //if (this.PaymentInTax != target.PaymentInTax) resList.Add("PaymentInTax");
            //--- DEL 2008/04/25 M.Kubota ---<<<
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.AfCalDemandPrice != target.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (this.AcpOdrTtl2TmBfBlDmd != target.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (this.AcpOdrTtl3TmBfBlDmd != target.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.SalesSlipCount != target.SalesSlipCount) resList.Add("SalesSlipCount");
            if (this.BillPrintDate != target.BillPrintDate) resList.Add("BillPrintDate");
            if (this.ExpectedDepositDate != target.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (this.CollectCond != target.CollectCond) resList.Add("CollectCond");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            if (this.CorporateDivCode != target.CorporateDivCode) resList.Add("CorporateDivCode");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.Address1 != target.Address1) resList.Add("Address1");
            //if (this.Address2 != target.Address2) resList.Add("Address2");  //DEL 2008/04/25 M.Kubota
            if (this.Address3 != target.Address3) resList.Add("Address3");
            if (this.Address4 != target.Address4) resList.Add("Address4");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.OthersTelNo != target.OthersTelNo) resList.Add("OthersTelNo");
            if (this.MainContactCode != target.MainContactCode) resList.Add("MainContactCode");
            if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (this.CollectMoneyName != target.CollectMoneyName) resList.Add("CollectMoneyName");
            if (this.CollectMoneyDay != target.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.OldCustomerAgentCd != target.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (this.OldCustomerAgentNm != target.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (this.CustAgentChgDate != target.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (this.StartDateSpan != target.StartDateSpan) resList.Add("StartDateSpan");
            if (this.EndDateSpan != target.EndDateSpan) resList.Add("EndDateSpan");

            return resList;
        }

        /// <summary>
        /// KINGET�p���Ӑ搿�����z�N���X��r����
        /// </summary>
        /// <param name="kingetCustDmdPrc1">��r����KingetCustDmdPrcWork�N���X�̃C���X�^���X</param>
        /// <param name="kingetCustDmdPrc2">��r����KingetCustDmdPrcWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(KingetCustDmdPrcWork kingetCustDmdPrc1, KingetCustDmdPrcWork kingetCustDmdPrc2)
        {
            ArrayList resList = new ArrayList();
            if (kingetCustDmdPrc1.CreateDateTime != kingetCustDmdPrc2.CreateDateTime) resList.Add("CreateDateTime");
            if (kingetCustDmdPrc1.UpdateDateTime != kingetCustDmdPrc2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (kingetCustDmdPrc1.EnterpriseCode != kingetCustDmdPrc2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (kingetCustDmdPrc1.FileHeaderGuid != kingetCustDmdPrc2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (kingetCustDmdPrc1.UpdEmployeeCode != kingetCustDmdPrc2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (kingetCustDmdPrc1.UpdAssemblyId1 != kingetCustDmdPrc2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (kingetCustDmdPrc1.UpdAssemblyId2 != kingetCustDmdPrc2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (kingetCustDmdPrc1.LogicalDeleteCode != kingetCustDmdPrc2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (kingetCustDmdPrc1.AddUpSecCode != kingetCustDmdPrc2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (kingetCustDmdPrc1.ClaimCode != kingetCustDmdPrc2.ClaimCode) resList.Add("ClaimCode");
            if (kingetCustDmdPrc1.ClaimName != kingetCustDmdPrc2.ClaimName) resList.Add("ClaimName");
            if (kingetCustDmdPrc1.ClaimName2 != kingetCustDmdPrc2.ClaimName2) resList.Add("ClaimName2");
            if (kingetCustDmdPrc1.ClaimSnm != kingetCustDmdPrc2.ClaimSnm) resList.Add("ClaimSnm");
            if (kingetCustDmdPrc1.CustomerCode != kingetCustDmdPrc2.CustomerCode) resList.Add("CustomerCode");
            if (kingetCustDmdPrc1.CustomerName != kingetCustDmdPrc2.CustomerName) resList.Add("CustomerName");
            if (kingetCustDmdPrc1.CustomerName2 != kingetCustDmdPrc2.CustomerName2) resList.Add("CustomerName2");
            if (kingetCustDmdPrc1.CustomerSnm != kingetCustDmdPrc2.CustomerSnm) resList.Add("CustomerSnm");
            if (kingetCustDmdPrc1.AddUpDate != kingetCustDmdPrc2.AddUpDate) resList.Add("AddUpDate");
            if (kingetCustDmdPrc1.AddUpYearMonth != kingetCustDmdPrc2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (kingetCustDmdPrc1.LastTimeDemand != kingetCustDmdPrc2.LastTimeDemand) resList.Add("LastTimeDemand");
            if (kingetCustDmdPrc1.ThisTimeFeeDmdNrml != kingetCustDmdPrc2.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeDisDmdNrml != kingetCustDmdPrc2.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeDmdNrml != kingetCustDmdPrc2.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (kingetCustDmdPrc1.ThisTimeTtlBlcDmd != kingetCustDmdPrc2.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (kingetCustDmdPrc1.OfsThisTimeSales != kingetCustDmdPrc2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (kingetCustDmdPrc1.OfsThisSalesTax != kingetCustDmdPrc2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (kingetCustDmdPrc1.ItdedOffsetOutTax != kingetCustDmdPrc2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (kingetCustDmdPrc1.ItdedOffsetInTax != kingetCustDmdPrc2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (kingetCustDmdPrc1.ItdedOffsetTaxFree != kingetCustDmdPrc2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (kingetCustDmdPrc1.OffsetOutTax != kingetCustDmdPrc2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (kingetCustDmdPrc1.OffsetInTax != kingetCustDmdPrc2.OffsetInTax) resList.Add("OffsetInTax");
            if (kingetCustDmdPrc1.ThisTimeSales != kingetCustDmdPrc2.ThisTimeSales) resList.Add("ThisTimeSales");
            if (kingetCustDmdPrc1.ThisSalesTax != kingetCustDmdPrc2.ThisSalesTax) resList.Add("ThisSalesTax");
            if (kingetCustDmdPrc1.ItdedSalesOutTax != kingetCustDmdPrc2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (kingetCustDmdPrc1.ItdedSalesInTax != kingetCustDmdPrc2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (kingetCustDmdPrc1.ItdedSalesTaxFree != kingetCustDmdPrc2.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (kingetCustDmdPrc1.SalesOutTax != kingetCustDmdPrc2.SalesOutTax) resList.Add("SalesOutTax");
            if (kingetCustDmdPrc1.SalesInTax != kingetCustDmdPrc2.SalesInTax) resList.Add("SalesInTax");
            if (kingetCustDmdPrc1.ThisSalesPricRgds != kingetCustDmdPrc2.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (kingetCustDmdPrc1.ThisSalesPrcTaxRgds != kingetCustDmdPrc2.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (kingetCustDmdPrc1.TtlItdedRetOutTax != kingetCustDmdPrc2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (kingetCustDmdPrc1.TtlItdedRetInTax != kingetCustDmdPrc2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (kingetCustDmdPrc1.TtlItdedRetTaxFree != kingetCustDmdPrc2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (kingetCustDmdPrc1.TtlRetOuterTax != kingetCustDmdPrc2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (kingetCustDmdPrc1.TtlRetInnerTax != kingetCustDmdPrc2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (kingetCustDmdPrc1.ThisSalesPricDis != kingetCustDmdPrc2.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (kingetCustDmdPrc1.ThisSalesPrcTaxDis != kingetCustDmdPrc2.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (kingetCustDmdPrc1.TtlItdedDisOutTax != kingetCustDmdPrc2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (kingetCustDmdPrc1.TtlItdedDisInTax != kingetCustDmdPrc2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (kingetCustDmdPrc1.TtlItdedDisTaxFree != kingetCustDmdPrc2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (kingetCustDmdPrc1.TtlDisOuterTax != kingetCustDmdPrc2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (kingetCustDmdPrc1.TtlDisInnerTax != kingetCustDmdPrc2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (kingetCustDmdPrc1.ThisPayOffset != kingetCustDmdPrc2.ThisPayOffset) resList.Add("ThisPayOffset");
            //if (kingetCustDmdPrc1.ThisPayOffsetTax != kingetCustDmdPrc2.ThisPayOffsetTax) resList.Add("ThisPayOffsetTax");
            //if (kingetCustDmdPrc1.ItdedPaymOutTax != kingetCustDmdPrc2.ItdedPaymOutTax) resList.Add("ItdedPaymOutTax");
            //if (kingetCustDmdPrc1.ItdedPaymInTax != kingetCustDmdPrc2.ItdedPaymInTax) resList.Add("ItdedPaymInTax");
            //if (kingetCustDmdPrc1.ItdedPaymTaxFree != kingetCustDmdPrc2.ItdedPaymTaxFree) resList.Add("ItdedPaymTaxFree");
            //if (kingetCustDmdPrc1.PaymentOutTax != kingetCustDmdPrc2.PaymentOutTax) resList.Add("PaymentOutTax");
            //if (kingetCustDmdPrc1.PaymentInTax != kingetCustDmdPrc2.PaymentInTax) resList.Add("PaymentInTax");
            //--- DEL 2008/04/25 M.Kubota ---<<<
            if (kingetCustDmdPrc1.TaxAdjust != kingetCustDmdPrc2.TaxAdjust) resList.Add("TaxAdjust");
            if (kingetCustDmdPrc1.BalanceAdjust != kingetCustDmdPrc2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (kingetCustDmdPrc1.AfCalDemandPrice != kingetCustDmdPrc2.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (kingetCustDmdPrc1.AcpOdrTtl2TmBfBlDmd != kingetCustDmdPrc2.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (kingetCustDmdPrc1.AcpOdrTtl3TmBfBlDmd != kingetCustDmdPrc2.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (kingetCustDmdPrc1.CAddUpUpdExecDate != kingetCustDmdPrc2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (kingetCustDmdPrc1.StartCAddUpUpdDate != kingetCustDmdPrc2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (kingetCustDmdPrc1.LastCAddUpUpdDate != kingetCustDmdPrc2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (kingetCustDmdPrc1.SalesSlipCount != kingetCustDmdPrc2.SalesSlipCount) resList.Add("SalesSlipCount");
            if (kingetCustDmdPrc1.BillPrintDate != kingetCustDmdPrc2.BillPrintDate) resList.Add("BillPrintDate");
            if (kingetCustDmdPrc1.ExpectedDepositDate != kingetCustDmdPrc2.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (kingetCustDmdPrc1.CollectCond != kingetCustDmdPrc2.CollectCond) resList.Add("CollectCond");
            if (kingetCustDmdPrc1.ConsTaxLayMethod != kingetCustDmdPrc2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (kingetCustDmdPrc1.ConsTaxRate != kingetCustDmdPrc2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (kingetCustDmdPrc1.FractionProcCd != kingetCustDmdPrc2.FractionProcCd) resList.Add("FractionProcCd");
            if (kingetCustDmdPrc1.HonorificTitle != kingetCustDmdPrc2.HonorificTitle) resList.Add("HonorificTitle");
            if (kingetCustDmdPrc1.Kana != kingetCustDmdPrc2.Kana) resList.Add("Kana");
            if (kingetCustDmdPrc1.OutputNameCode != kingetCustDmdPrc2.OutputNameCode) resList.Add("OutputNameCode");
            if (kingetCustDmdPrc1.OutputName != kingetCustDmdPrc2.OutputName) resList.Add("OutputName");
            if (kingetCustDmdPrc1.CorporateDivCode != kingetCustDmdPrc2.CorporateDivCode) resList.Add("CorporateDivCode");
            if (kingetCustDmdPrc1.PostNo != kingetCustDmdPrc2.PostNo) resList.Add("PostNo");
            if (kingetCustDmdPrc1.Address1 != kingetCustDmdPrc2.Address1) resList.Add("Address1");
            //if (kingetCustDmdPrc1.Address2 != kingetCustDmdPrc2.Address2) resList.Add("Address2");  //DEL 2008/04/25 M.Kubota
            if (kingetCustDmdPrc1.Address3 != kingetCustDmdPrc2.Address3) resList.Add("Address3");
            if (kingetCustDmdPrc1.Address4 != kingetCustDmdPrc2.Address4) resList.Add("Address4");
            if (kingetCustDmdPrc1.HomeTelNo != kingetCustDmdPrc2.HomeTelNo) resList.Add("HomeTelNo");
            if (kingetCustDmdPrc1.OfficeTelNo != kingetCustDmdPrc2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (kingetCustDmdPrc1.PortableTelNo != kingetCustDmdPrc2.PortableTelNo) resList.Add("PortableTelNo");
            if (kingetCustDmdPrc1.HomeFaxNo != kingetCustDmdPrc2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (kingetCustDmdPrc1.OfficeFaxNo != kingetCustDmdPrc2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (kingetCustDmdPrc1.OthersTelNo != kingetCustDmdPrc2.OthersTelNo) resList.Add("OthersTelNo");
            if (kingetCustDmdPrc1.MainContactCode != kingetCustDmdPrc2.MainContactCode) resList.Add("MainContactCode");
            if (kingetCustDmdPrc1.CustAnalysCode1 != kingetCustDmdPrc2.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (kingetCustDmdPrc1.CustAnalysCode2 != kingetCustDmdPrc2.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (kingetCustDmdPrc1.CustAnalysCode3 != kingetCustDmdPrc2.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (kingetCustDmdPrc1.CustAnalysCode4 != kingetCustDmdPrc2.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (kingetCustDmdPrc1.CustAnalysCode5 != kingetCustDmdPrc2.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (kingetCustDmdPrc1.CustAnalysCode6 != kingetCustDmdPrc2.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (kingetCustDmdPrc1.TotalDay != kingetCustDmdPrc2.TotalDay) resList.Add("TotalDay");
            if (kingetCustDmdPrc1.CollectMoneyCode != kingetCustDmdPrc2.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (kingetCustDmdPrc1.CollectMoneyName != kingetCustDmdPrc2.CollectMoneyName) resList.Add("CollectMoneyName");
            if (kingetCustDmdPrc1.CollectMoneyDay != kingetCustDmdPrc2.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (kingetCustDmdPrc1.CustomerAgentCd != kingetCustDmdPrc2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (kingetCustDmdPrc1.CustomerAgentNm != kingetCustDmdPrc2.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (kingetCustDmdPrc1.BillCollecterCd != kingetCustDmdPrc2.BillCollecterCd) resList.Add("BillCollecterCd");
            if (kingetCustDmdPrc1.BillCollecterNm != kingetCustDmdPrc2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (kingetCustDmdPrc1.OldCustomerAgentCd != kingetCustDmdPrc2.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (kingetCustDmdPrc1.OldCustomerAgentNm != kingetCustDmdPrc2.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (kingetCustDmdPrc1.CustAgentChgDate != kingetCustDmdPrc2.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (kingetCustDmdPrc1.StartDateSpan != kingetCustDmdPrc2.StartDateSpan) resList.Add("StartDateSpan");
            if (kingetCustDmdPrc1.EndDateSpan != kingetCustDmdPrc2.EndDateSpan) resList.Add("EndDateSpan");

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class KingetCustDmdPrcWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  KingetCustDmdPrcWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is KingetCustDmdPrcWork || graph is ArrayList || graph is KingetCustDmdPrcWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(KingetCustDmdPrcWork).FullName));

            if (graph != null && graph is KingetCustDmdPrcWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is KingetCustDmdPrcWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((KingetCustDmdPrcWork[])graph).Length;
            }
            else if (graph is KingetCustDmdPrcWork)
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
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�O�񐿋����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //����萔���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //����l���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //����J�z�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //���E��O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //���E����őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //���E���ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //���E��O�ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //���E����ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //���񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //���񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //����O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //������őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //�����ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesTaxFree
            //����O�Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesOutTax
            //������Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesInTax
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //���񔄏�ԕi�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //�ԕi�O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //�ԕi���őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //�ԕi��ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //�ԕi�O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //�ԕi���Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //���񔄏�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //���񔄏�l�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //�l���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //�l�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //�l����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //�l���O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //�l�����Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //����x�����E���z
            //serInfo.MemberInfo.Add(typeof(Int64)); //ThisPayOffset
            //����x�����E�����
            //serInfo.MemberInfo.Add(typeof(Int64)); //ThisPayOffsetTax
            //�x���O�őΏۊz
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymOutTax
            //�x�����őΏۊz
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymInTax
            //�x����ېőΏۊz
            //serInfo.MemberInfo.Add(typeof(Int64)); //ItdedPaymTaxFree
            //�x���O�ŏ����
            //serInfo.MemberInfo.Add(typeof(Int64)); //PaymentOutTax
            //�x�����ŏ����
            //serInfo.MemberInfo.Add(typeof(Int64)); //PaymentInTax
            //--- DEL 2008/04/25 M.Kubota ---<<<

            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�v�Z�㐿�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //��2��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //��3��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //�O������X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //���������s��
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPrintDate
            //�����\���
            serInfo.MemberInfo.Add(typeof(Int32)); //ExpectedDepositDate
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //����ŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //�J�i
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //OutputName
            //�l�E�@�l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CorporateDivCode
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z��2�i���ځj
            //serInfo.MemberInfo.Add(typeof(Int32)); //Address2  //DEL 2008/04/25 M.Kubota
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //�d�b�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //FAX�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            //�d�b�ԍ��i���̑��j
            serInfo.MemberInfo.Add(typeof(string)); //OthersTelNo
            //��A����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MainContactCode
            //���Ӑ敪�̓R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //���Ӑ敪�̓R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //���Ӑ敪�̓R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //���Ӑ敪�̓R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //���Ӑ敪�̓R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //���Ӑ敪�̓R�[�h6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //�W�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //�W�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //�W����
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //�ڋq�S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //�W���S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //���ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentCd
            //���ڋq�S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentNm
            //�ڋq�S���ύX��
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAgentChgDate
            //�v��N�����͈́i�J�n�j
            serInfo.MemberInfo.Add(typeof(Int32)); //StartDateSpan
            //�v��N�����͈́i�I���j
            serInfo.MemberInfo.Add(typeof(Int32)); //EndDateSpan


            serInfo.Serialize(writer, serInfo);
            if (graph is KingetCustDmdPrcWork)
            {
                KingetCustDmdPrcWork temp = (KingetCustDmdPrcWork)graph;

                SetKingetCustDmdPrcWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is KingetCustDmdPrcWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((KingetCustDmdPrcWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (KingetCustDmdPrcWork temp in lst)
                {
                    SetKingetCustDmdPrcWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// KingetCustDmdPrcWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 110;  //DEL 2008/04/25 M.Kubota
        private const int currentMemberCount = 102;    //ADD 2008/04/25 M.Kubota

        /// <summary>
        ///  KingetCustDmdPrcWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetKingetCustDmdPrcWork(System.IO.BinaryWriter writer, KingetCustDmdPrcWork temp)
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
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�O�񐿋����z
            writer.Write(temp.LastTimeDemand);
            //����萔���z�i�ʏ�����j
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //����l���z�i�ʏ�����j
            writer.Write(temp.ThisTimeDisDmdNrml);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //����J�z�c���i�����v�j
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //���E��O�őΏۊz
            writer.Write(temp.ItdedOffsetOutTax);
            //���E����őΏۊz
            writer.Write(temp.ItdedOffsetInTax);
            //���E���ېőΏۊz
            writer.Write(temp.ItdedOffsetTaxFree);
            //���E��O�ŏ����
            writer.Write(temp.OffsetOutTax);
            //���E����ŏ����
            writer.Write(temp.OffsetInTax);
            //���񔄏���z
            writer.Write(temp.ThisTimeSales);
            //���񔄏�����
            writer.Write(temp.ThisSalesTax);
            //����O�őΏۊz
            writer.Write(temp.ItdedSalesOutTax);
            //������őΏۊz
            writer.Write(temp.ItdedSalesInTax);
            //�����ېőΏۊz
            writer.Write(temp.ItdedSalesTaxFree);
            //����O�Ŋz
            writer.Write(temp.SalesOutTax);
            //������Ŋz
            writer.Write(temp.SalesInTax);
            //���񔄏�ԕi���z
            writer.Write(temp.ThisSalesPricRgds);
            //���񔄏�ԕi�����
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //�ԕi�O�őΏۊz���v
            writer.Write(temp.TtlItdedRetOutTax);
            //�ԕi���őΏۊz���v
            writer.Write(temp.TtlItdedRetInTax);
            //�ԕi��ېőΏۊz���v
            writer.Write(temp.TtlItdedRetTaxFree);
            //�ԕi�O�Ŋz���v
            writer.Write(temp.TtlRetOuterTax);
            //�ԕi���Ŋz���v
            writer.Write(temp.TtlRetInnerTax);
            //���񔄏�l�����z
            writer.Write(temp.ThisSalesPricDis);
            //���񔄏�l�������
            writer.Write(temp.ThisSalesPrcTaxDis);
            //�l���O�őΏۊz���v
            writer.Write(temp.TtlItdedDisOutTax);
            //�l�����őΏۊz���v
            writer.Write(temp.TtlItdedDisInTax);
            //�l����ېőΏۊz���v
            writer.Write(temp.TtlItdedDisTaxFree);
            //�l���O�Ŋz���v
            writer.Write(temp.TtlDisOuterTax);
            //�l�����Ŋz���v
            writer.Write(temp.TtlDisInnerTax);
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //����x�����E���z
            //writer.Write(temp.ThisPayOffset);
            //����x�����E�����
            //writer.Write(temp.ThisPayOffsetTax);
            //�x���O�őΏۊz
            //writer.Write(temp.ItdedPaymOutTax);
            //�x�����őΏۊz
            //writer.Write(temp.ItdedPaymInTax);
            //�x����ېőΏۊz
            //writer.Write(temp.ItdedPaymTaxFree);
            //�x���O�ŏ����
            //writer.Write(temp.PaymentOutTax);
            //�x�����ŏ����
            //writer.Write(temp.PaymentInTax);
            //--- DEL 2008/04/25 M.Kubota ---<<<

            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�v�Z�㐿�����z
            writer.Write(temp.AfCalDemandPrice);
            //��2��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //��3��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //�����X�V���s�N����
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //�����X�V�J�n�N����
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //�O������X�V�N����
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //���������s��
            writer.Write((Int64)temp.BillPrintDate.Ticks);
            //�����\���
            writer.Write((Int64)temp.ExpectedDepositDate.Ticks);
            //�������
            writer.Write(temp.CollectCond);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //����ŗ�
            writer.Write(temp.ConsTaxRate);
            //�[�������敪
            writer.Write(temp.FractionProcCd);
            //�h��
            writer.Write(temp.HonorificTitle);
            //�J�i
            writer.Write(temp.Kana);
            //�����R�[�h
            writer.Write(temp.OutputNameCode);
            //��������
            writer.Write(temp.OutputName);
            //�l�E�@�l�敪
            writer.Write(temp.CorporateDivCode);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z��2�i���ځj
            //writer.Write(temp.Address2);  //DEL 2008/04/25 M.Kubota
            //�Z��3�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //�d�b�ԍ��i����j
            writer.Write(temp.HomeTelNo);
            //�d�b�ԍ��i�Ζ���j
            writer.Write(temp.OfficeTelNo);
            //�d�b�ԍ��i�g�сj
            writer.Write(temp.PortableTelNo);
            //FAX�ԍ��i����j
            writer.Write(temp.HomeFaxNo);
            //FAX�ԍ��i�Ζ���j
            writer.Write(temp.OfficeFaxNo);
            //�d�b�ԍ��i���̑��j
            writer.Write(temp.OthersTelNo);
            //��A����敪
            writer.Write(temp.MainContactCode);
            //���Ӑ敪�̓R�[�h1
            writer.Write(temp.CustAnalysCode1);
            //���Ӑ敪�̓R�[�h2
            writer.Write(temp.CustAnalysCode2);
            //���Ӑ敪�̓R�[�h3
            writer.Write(temp.CustAnalysCode3);
            //���Ӑ敪�̓R�[�h4
            writer.Write(temp.CustAnalysCode4);
            //���Ӑ敪�̓R�[�h5
            writer.Write(temp.CustAnalysCode5);
            //���Ӑ敪�̓R�[�h6
            writer.Write(temp.CustAnalysCode6);
            //����
            writer.Write(temp.TotalDay);
            //�W�����敪�R�[�h
            writer.Write(temp.CollectMoneyCode);
            //�W�����敪����
            writer.Write(temp.CollectMoneyName);
            //�W����
            writer.Write(temp.CollectMoneyDay);
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.CustomerAgentCd);
            //�ڋq�S���]�ƈ�����
            writer.Write(temp.CustomerAgentNm);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //�W���S���]�ƈ�����
            writer.Write(temp.BillCollecterNm);
            //���ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.OldCustomerAgentCd);
            //���ڋq�S���]�ƈ�����
            writer.Write(temp.OldCustomerAgentNm);
            //�ڋq�S���ύX��
            writer.Write((Int64)temp.CustAgentChgDate.Ticks);
            //�v��N�����͈́i�J�n�j
            writer.Write(temp.StartDateSpan);
            //�v��N�����͈́i�I���j
            writer.Write(temp.EndDateSpan);

        }

        /// <summary>
        ///  KingetCustDmdPrcWork�C���X�^���X�擾
        /// </summary>
        /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private KingetCustDmdPrcWork GetKingetCustDmdPrcWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            KingetCustDmdPrcWork temp = new KingetCustDmdPrcWork();

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
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�O�񐿋����z
            temp.LastTimeDemand = reader.ReadInt64();
            //����萔���z�i�ʏ�����j
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //����l���z�i�ʏ�����j
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //����J�z�c���i�����v�j
            temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //���E��O�őΏۊz
            temp.ItdedOffsetOutTax = reader.ReadInt64();
            //���E����őΏۊz
            temp.ItdedOffsetInTax = reader.ReadInt64();
            //���E���ېőΏۊz
            temp.ItdedOffsetTaxFree = reader.ReadInt64();
            //���E��O�ŏ����
            temp.OffsetOutTax = reader.ReadInt64();
            //���E����ŏ����
            temp.OffsetInTax = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //���񔄏�����
            temp.ThisSalesTax = reader.ReadInt64();
            //����O�őΏۊz
            temp.ItdedSalesOutTax = reader.ReadInt64();
            //������őΏۊz
            temp.ItdedSalesInTax = reader.ReadInt64();
            //�����ېőΏۊz
            temp.ItdedSalesTaxFree = reader.ReadInt64();
            //����O�Ŋz
            temp.SalesOutTax = reader.ReadInt64();
            //������Ŋz
            temp.SalesInTax = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //���񔄏�ԕi�����
            temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
            //�ԕi�O�őΏۊz���v
            temp.TtlItdedRetOutTax = reader.ReadInt64();
            //�ԕi���őΏۊz���v
            temp.TtlItdedRetInTax = reader.ReadInt64();
            //�ԕi��ېőΏۊz���v
            temp.TtlItdedRetTaxFree = reader.ReadInt64();
            //�ԕi�O�Ŋz���v
            temp.TtlRetOuterTax = reader.ReadInt64();
            //�ԕi���Ŋz���v
            temp.TtlRetInnerTax = reader.ReadInt64();
            //���񔄏�l�����z
            temp.ThisSalesPricDis = reader.ReadInt64();
            //���񔄏�l�������
            temp.ThisSalesPrcTaxDis = reader.ReadInt64();
            //�l���O�őΏۊz���v
            temp.TtlItdedDisOutTax = reader.ReadInt64();
            //�l�����őΏۊz���v
            temp.TtlItdedDisInTax = reader.ReadInt64();
            //�l����ېőΏۊz���v
            temp.TtlItdedDisTaxFree = reader.ReadInt64();
            //�l���O�Ŋz���v
            temp.TtlDisOuterTax = reader.ReadInt64();
            //�l�����Ŋz���v
            temp.TtlDisInnerTax = reader.ReadInt64();
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            //����x�����E���z
            //temp.ThisPayOffset = reader.ReadInt64();
            //����x�����E�����
            //temp.ThisPayOffsetTax = reader.ReadInt64();
            //�x���O�őΏۊz
            //temp.ItdedPaymOutTax = reader.ReadInt64();
            //�x�����őΏۊz
            //temp.ItdedPaymInTax = reader.ReadInt64();
            //�x����ېőΏۊz
            //temp.ItdedPaymTaxFree = reader.ReadInt64();
            //�x���O�ŏ����
            //temp.PaymentOutTax = reader.ReadInt64();
            //�x�����ŏ����
            //temp.PaymentInTax = reader.ReadInt64();
            //--- DEL 2008/04/25 M.Kubota ---<<<

            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�v�Z�㐿�����z
            temp.AfCalDemandPrice = reader.ReadInt64();
            //��2��O�c���i�����v�j
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //��3��O�c���i�����v�j
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //�����X�V���s�N����
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //�����X�V�J�n�N����
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�O������X�V�N����
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //���������s��
            temp.BillPrintDate = new DateTime(reader.ReadInt64());
            //�����\���
            temp.ExpectedDepositDate = new DateTime(reader.ReadInt64());
            //�������
            temp.CollectCond = reader.ReadInt32();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //����ŗ�
            temp.ConsTaxRate = reader.ReadDouble();
            //�[�������敪
            temp.FractionProcCd = reader.ReadInt32();
            //�h��
            temp.HonorificTitle = reader.ReadString();
            //�J�i
            temp.Kana = reader.ReadString();
            //�����R�[�h
            temp.OutputNameCode = reader.ReadInt32();
            //��������
            temp.OutputName = reader.ReadString();
            //�l�E�@�l�敪
            temp.CorporateDivCode = reader.ReadInt32();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z��2�i���ځj
            //temp.Address2 = reader.ReadInt32();  //DEL 2008/04/25 M.Kubota
            //�Z��3�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //�d�b�ԍ��i����j
            temp.HomeTelNo = reader.ReadString();
            //�d�b�ԍ��i�Ζ���j
            temp.OfficeTelNo = reader.ReadString();
            //�d�b�ԍ��i�g�сj
            temp.PortableTelNo = reader.ReadString();
            //FAX�ԍ��i����j
            temp.HomeFaxNo = reader.ReadString();
            //FAX�ԍ��i�Ζ���j
            temp.OfficeFaxNo = reader.ReadString();
            //�d�b�ԍ��i���̑��j
            temp.OthersTelNo = reader.ReadString();
            //��A����敪
            temp.MainContactCode = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h1
            temp.CustAnalysCode1 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h2
            temp.CustAnalysCode2 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h3
            temp.CustAnalysCode3 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h4
            temp.CustAnalysCode4 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h5
            temp.CustAnalysCode5 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h6
            temp.CustAnalysCode6 = reader.ReadInt32();
            //����
            temp.TotalDay = reader.ReadInt32();
            //�W�����敪�R�[�h
            temp.CollectMoneyCode = reader.ReadInt32();
            //�W�����敪����
            temp.CollectMoneyName = reader.ReadString();
            //�W����
            temp.CollectMoneyDay = reader.ReadInt32();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CustomerAgentCd = reader.ReadString();
            //�ڋq�S���]�ƈ�����
            temp.CustomerAgentNm = reader.ReadString();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //�W���S���]�ƈ�����
            temp.BillCollecterNm = reader.ReadString();
            //���ڋq�S���]�ƈ��R�[�h
            temp.OldCustomerAgentCd = reader.ReadString();
            //���ڋq�S���]�ƈ�����
            temp.OldCustomerAgentNm = reader.ReadString();
            //�ڋq�S���ύX��
            temp.CustAgentChgDate = new DateTime(reader.ReadInt64());
            //�v��N�����͈́i�J�n�j
            temp.StartDateSpan = reader.ReadInt32();
            //�v��N�����͈́i�I���j
            temp.EndDateSpan = reader.ReadInt32();


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
        /// <returns>KingetCustDmdPrcWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   KingetCustDmdPrcWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                KingetCustDmdPrcWork temp = GetKingetCustDmdPrcWork(reader, serInfo);
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
                    retValue = (KingetCustDmdPrcWork[])lst.ToArray(typeof(KingetCustDmdPrcWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
