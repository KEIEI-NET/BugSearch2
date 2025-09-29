//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE����M�W���[�i��(�݌Ɂj�N���X
// �v���O�����T�v   : UOE����M�W���[�i��(�݌Ɂj�̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockSndRcvJnl
    /// <summary>
    ///                      UOE����M�W���[�i���i�݌Ɂj
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE����M�W���[�i���i�݌Ɂj�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockSndRcvJnl
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

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>UOE�����s�ԍ�</summary>
        private Int32 _uOESalesOrderRowNo;

        /// <summary>���M�[���ԍ�</summary>
        /// <remarks>���M�������s�[���ԍ�</remarks>
        private Int32 _sendTerminalNo;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>�ʐM�A�Z���u��ID</summary>
        private string _commAssemblyId = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>�I�����C���s�ԍ�</summary>
        private Int32 _onlineRowNo;

        /// <summary>������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>�f�[�^�X�V����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _dataUpdateDateTime;

        /// <summary>UOE���</summary>
        /// <remarks>0:UOE 1:�����d����M</remarks>
        private Int32 _uOEKind;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>�󒍓`�[�ԍ�</remarks>
        private string _salesSlipNum = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>20:��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>���㖾�גʔ�</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�[���ԍ�</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>���ʒʔ�</summary>
        private Int64 _commonSeqNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>UOE�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪����</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE�w�苒�_����</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        /// <remarks>�˗��Җ���</remarks>
        private string _employeeName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�󒍐���</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>�艿�i�����j</summary>
        /// <remarks>�K�p�i�艿�j</remarks>
        private Double _listPrice;

        /// <summary>�����P��</summary>
        /// <remarks>�d�؂艿�i</remarks>
        private Double _salesUnitCost;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>��M���t</summary>
        private DateTime _receiveDate;

        /// <summary>��M����</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _receiveTime;

        /// <summary>�񓚃��[�J�[�R�[�h</summary>
        private Int32 _answerMakerCd;

        /// <summary>�񓚕i��</summary>
        private string _answerPartsNo = "";

        /// <summary>�񓚕i��</summary>
        private string _answerPartsName = "";

        /// <summary>��֕i��</summary>
        private string _substPartsNo = "";

        /// <summary>��֕i�ԁi�Z���^�[�j</summary>
        private string _centerSubstPartsNo = "";

        /// <summary>�񓚒艿</summary>
        private Double _answerListPrice;

        /// <summary>�񓚌����P��</summary>
        private Double _answerSalesUnitCost;

        /// <summary>���i�`���i</summary>
        private Double _goodsAPrice;

        /// <summary>UOE���~�R�[�h</summary>
        private string _uOEStopCd = "";

        /// <summary>UOE��փR�[�h</summary>
        private string _uOESubstCode = "";

        /// <summary>UOE�[���R�[�h</summary>
        private string _uOEDelivDateCd = "";

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>�̔��X�d���P��</summary>
        private Double _shopStUnitPrice;

        /// <summary>UOE���_�R�[�h�P</summary>
        /// <remarks>�}�c�_�ݒ荀�ځi���_�R�[�h1�`8)</remarks>
        private string _uOESectionCode1 = "";

        /// <summary>UOE���_�R�[�h�Q</summary>
        private string _uOESectionCode2 = "";

        /// <summary>UOE���_�R�[�h�R</summary>
        private string _uOESectionCode3 = "";

        /// <summary>UOE���_�R�[�h�S</summary>
        private string _uOESectionCode4 = "";

        /// <summary>UOE���_�R�[�h�T</summary>
        private string _uOESectionCode5 = "";

        /// <summary>UOE���_�R�[�h�U</summary>
        private string _uOESectionCode6 = "";

        /// <summary>UOE���_�R�[�h�V</summary>
        private string _uOESectionCode7 = "";

        /// <summary>UOE���_�R�[�h�W</summary>
        private string _uOESectionCode8 = "";

        /// <summary>�{���݌�</summary>
        private string _headQtrsStock = "";

        /// <summary>UOE���_�݌ɐ��P</summary>
        private Int32 _uOESectionStock1;

        /// <summary>UOE���_�݌ɐ��Q</summary>
        private Int32 _uOESectionStock2;

        /// <summary>UOE���_�݌ɐ��R</summary>
        private Int32 _uOESectionStock3;

        /// <summary>UOE���_�݌ɐ��S</summary>
        private Int32 _uOESectionStock4;

        /// <summary>UOE���_�݌ɐ��T</summary>
        private Int32 _uOESectionStock5;

        /// <summary>UOE���_�݌ɐ��U</summary>
        private Int32 _uOESectionStock6;

        /// <summary>UOE���_�݌ɐ��V</summary>
        private Int32 _uOESectionStock7;

        /// <summary>UOE���_�݌ɐ��W</summary>
        private Int32 _uOESectionStock8;

        /// <summary>UOE���_�݌ɐ��X</summary>
        private Int32 _uOESectionStock9;

        /// <summary>UOE���_�݌ɐ��P�O</summary>
        private Int32 _uOESectionStock10;

        /// <summary>UOE���_�݌ɐ��P�P</summary>
        private Int32 _uOESectionStock11;

        /// <summary>UOE���_�݌ɐ��P�Q</summary>
        private Int32 _uOESectionStock12;

        /// <summary>UOE���_�݌ɐ��P�R</summary>
        private Int32 _uOESectionStock13;

        /// <summary>UOE���_�݌ɐ��P�S</summary>
        private Int32 _uOESectionStock14;

        /// <summary>UOE���_�݌ɐ��P�T</summary>
        private Int32 _uOESectionStock15;

        /// <summary>UOE���_�݌ɐ��P�U</summary>
        private Int32 _uOESectionStock16;

        /// <summary>UOE���_�݌ɐ��P�V</summary>
        private Int32 _uOESectionStock17;

        /// <summary>UOE���_�݌ɐ��P�W</summary>
        private Int32 _uOESectionStock18;

        /// <summary>UOE���_�݌ɐ��P�X</summary>
        private Int32 _uOESectionStock19;

        /// <summary>UOE���_�݌ɐ��Q�O</summary>
        private Int32 _uOESectionStock20;

        /// <summary>UOE���_�݌ɐ��Q�P</summary>
        private Int32 _uOESectionStock21;

        /// <summary>UOE���_�݌ɐ��Q�Q</summary>
        private Int32 _uOESectionStock22;

        /// <summary>UOE���_�݌ɐ��Q�R</summary>
        private Int32 _uOESectionStock23;

        /// <summary>UOE���_�݌ɐ��Q�S</summary>
        private Int32 _uOESectionStock24;

        /// <summary>UOE���_�݌ɐ��Q�T</summary>
        private Int32 _uOESectionStock25;

        /// <summary>UOE���_�݌ɐ��Q�U</summary>
        private Int32 _uOESectionStock26;

        /// <summary>UOE���_�݌ɐ��Q�V</summary>
        private Int32 _uOESectionStock27;

        /// <summary>UOE���_�݌ɐ��Q�W</summary>
        private Int32 _uOESectionStock28;

        /// <summary>UOE���_�݌ɐ��Q�X</summary>
        private Int32 _uOESectionStock29;

        /// <summary>UOE���_�݌ɐ��R�O</summary>
        private Int32 _uOESectionStock30;

        /// <summary>UOE���_�݌ɐ��R�P</summary>
        private Int32 _uOESectionStock31;

        /// <summary>UOE���_�݌ɐ��R�Q</summary>
        private Int32 _uOESectionStock32;

        /// <summary>UOE���_�݌ɐ��R�R</summary>
        private Int32 _uOESectionStock33;

        /// <summary>UOE���_�݌ɐ��R�S</summary>
        private Int32 _uOESectionStock34;

        /// <summary>UOE���_�݌ɐ��R�T</summary>
        private Int32 _uOESectionStock35;

        /// <summary>�w�b�h�G���[���b�Z�[�W</summary>
        private string _headErrorMassage = "";

        /// <summary>���C���G���[���b�Z�[�W</summary>
        private string _lineErrorMassage = "";

        /// <summary>�f�[�^���M�敪</summary>
        /// <remarks>���M�t���O</remarks>
        private Int32 _dataSendCode;

        /// <summary>�f�[�^�����敪</summary>
        /// <remarks>���������t���O</remarks>
        private Int32 _dataRecoverDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UOESalesOrderRowNo
        /// <summary>UOE�����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderRowNo
        {
            get { return _uOESalesOrderRowNo; }
            set { _uOESalesOrderRowNo = value; }
        }

        /// public propaty name  :  SendTerminalNo
        /// <summary>���M�[���ԍ��v���p�e�B</summary>
        /// <value>���M�������s�[���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendTerminalNo
        {
            get { return _sendTerminalNo; }
            set { _sendTerminalNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>�ʐM�A�Z���u��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM�A�Z���u��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }

        /// public propaty name  :  OnlineNo
        /// <summary>�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>�I�����C���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  InputDayJpFormal
        /// <summary>���͓� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>���͓� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>���͓� ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>���͓� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>�f�[�^�X�V�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  DataUpdateDateTimeJpFormal
        /// <summary>�f�[�^�X�V���� �a��v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataUpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeJpInFormal
        /// <summary>�f�[�^�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataUpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeAdFormal
        /// <summary>�f�[�^�X�V���� ����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataUpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeAdInFormal
        /// <summary>�f�[�^�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataUpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  UOEKind
        /// <summary>UOE��ʃv���p�e�B</summary>
        /// <value>0:UOE 1:�����d����M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOEKind
        {
            get { return _uOEKind; }
            set { _uOEKind = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>�󒍓`�[�ԍ�</value>
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>20:��</value>
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

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>���㖾�גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�[���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>���ʒʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʒʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
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

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�t�H���[�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE�w�苒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// <value>�˗��Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>�K�p�i�艿�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�d�؂艿�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
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

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  ReceiveDate
        /// <summary>��M���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        /// public propaty name  :  ReceiveDateJpFormal
        /// <summary>��M���t �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateJpInFormal
        /// <summary>��M���t �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateAdFormal
        /// <summary>��M���t ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateAdInFormal
        /// <summary>��M���t ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveTime
        /// <summary>��M�����v���p�e�B</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        /// public propaty name  :  AnswerMakerCd
        /// <summary>�񓚃��[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚃��[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerMakerCd
        {
            get { return _answerMakerCd; }
            set { _answerMakerCd = value; }
        }

        /// public propaty name  :  AnswerPartsNo
        /// <summary>�񓚕i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsNo
        {
            get { return _answerPartsNo; }
            set { _answerPartsNo = value; }
        }

        /// public propaty name  :  AnswerPartsName
        /// <summary>�񓚕i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerPartsName
        {
            get { return _answerPartsName; }
            set { _answerPartsName = value; }
        }

        /// public propaty name  :  SubstPartsNo
        /// <summary>��֕i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֕i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubstPartsNo
        {
            get { return _substPartsNo; }
            set { _substPartsNo = value; }
        }

        /// public propaty name  :  CenterSubstPartsNo
        /// <summary>��֕i�ԁi�Z���^�[�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��֕i�ԁi�Z���^�[�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CenterSubstPartsNo
        {
            get { return _centerSubstPartsNo; }
            set { _centerSubstPartsNo = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>�񓚒艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>�񓚌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }

        /// public propaty name  :  GoodsAPrice
        /// <summary>���i�`���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�`���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GoodsAPrice
        {
            get { return _goodsAPrice; }
            set { _goodsAPrice = value; }
        }

        /// public propaty name  :  UOEStopCd
        /// <summary>UOE���~�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���~�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEStopCd
        {
            get { return _uOEStopCd; }
            set { _uOEStopCd = value; }
        }

        /// public propaty name  :  UOESubstCode
        /// <summary>UOE��փR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE��փR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESubstCode
        {
            get { return _uOESubstCode; }
            set { _uOESubstCode = value; }
        }

        /// public propaty name  :  UOEDelivDateCd
        /// <summary>UOE�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDelivDateCd
        {
            get { return _uOEDelivDateCd; }
            set { _uOEDelivDateCd = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  ShopStUnitPrice
        /// <summary>�̔��X�d���P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��X�d���P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShopStUnitPrice
        {
            get { return _shopStUnitPrice; }
            set { _shopStUnitPrice = value; }
        }

        /// public propaty name  :  UOESectionCode1
        /// <summary>UOE���_�R�[�h�P�v���p�e�B</summary>
        /// <value>�}�c�_�ݒ荀�ځi���_�R�[�h1�`8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode1
        {
            get { return _uOESectionCode1; }
            set { _uOESectionCode1 = value; }
        }

        /// public propaty name  :  UOESectionCode2
        /// <summary>UOE���_�R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode2
        {
            get { return _uOESectionCode2; }
            set { _uOESectionCode2 = value; }
        }

        /// public propaty name  :  UOESectionCode3
        /// <summary>UOE���_�R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode3
        {
            get { return _uOESectionCode3; }
            set { _uOESectionCode3 = value; }
        }

        /// public propaty name  :  UOESectionCode4
        /// <summary>UOE���_�R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode4
        {
            get { return _uOESectionCode4; }
            set { _uOESectionCode4 = value; }
        }

        /// public propaty name  :  UOESectionCode5
        /// <summary>UOE���_�R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode5
        {
            get { return _uOESectionCode5; }
            set { _uOESectionCode5 = value; }
        }

        /// public propaty name  :  UOESectionCode6
        /// <summary>UOE���_�R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode6
        {
            get { return _uOESectionCode6; }
            set { _uOESectionCode6 = value; }
        }

        /// public propaty name  :  UOESectionCode7
        /// <summary>UOE���_�R�[�h�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode7
        {
            get { return _uOESectionCode7; }
            set { _uOESectionCode7 = value; }
        }

        /// public propaty name  :  UOESectionCode8
        /// <summary>UOE���_�R�[�h�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�R�[�h�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionCode8
        {
            get { return _uOESectionCode8; }
            set { _uOESectionCode8 = value; }
        }

        /// public propaty name  :  HeadQtrsStock
        /// <summary>�{���݌Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{���݌Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HeadQtrsStock
        {
            get { return _headQtrsStock; }
            set { _headQtrsStock = value; }
        }

        /// public propaty name  :  UOESectionStock1
        /// <summary>UOE���_�݌ɐ��P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock1
        {
            get { return _uOESectionStock1; }
            set { _uOESectionStock1 = value; }
        }

        /// public propaty name  :  UOESectionStock2
        /// <summary>UOE���_�݌ɐ��Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock2
        {
            get { return _uOESectionStock2; }
            set { _uOESectionStock2 = value; }
        }

        /// public propaty name  :  UOESectionStock3
        /// <summary>UOE���_�݌ɐ��R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock3
        {
            get { return _uOESectionStock3; }
            set { _uOESectionStock3 = value; }
        }

        /// public propaty name  :  UOESectionStock4
        /// <summary>UOE���_�݌ɐ��S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock4
        {
            get { return _uOESectionStock4; }
            set { _uOESectionStock4 = value; }
        }

        /// public propaty name  :  UOESectionStock5
        /// <summary>UOE���_�݌ɐ��T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock5
        {
            get { return _uOESectionStock5; }
            set { _uOESectionStock5 = value; }
        }

        /// public propaty name  :  UOESectionStock6
        /// <summary>UOE���_�݌ɐ��U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock6
        {
            get { return _uOESectionStock6; }
            set { _uOESectionStock6 = value; }
        }

        /// public propaty name  :  UOESectionStock7
        /// <summary>UOE���_�݌ɐ��V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock7
        {
            get { return _uOESectionStock7; }
            set { _uOESectionStock7 = value; }
        }

        /// public propaty name  :  UOESectionStock8
        /// <summary>UOE���_�݌ɐ��W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock8
        {
            get { return _uOESectionStock8; }
            set { _uOESectionStock8 = value; }
        }

        /// public propaty name  :  UOESectionStock9
        /// <summary>UOE���_�݌ɐ��X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock9
        {
            get { return _uOESectionStock9; }
            set { _uOESectionStock9 = value; }
        }

        /// public propaty name  :  UOESectionStock10
        /// <summary>UOE���_�݌ɐ��P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock10
        {
            get { return _uOESectionStock10; }
            set { _uOESectionStock10 = value; }
        }

        /// public propaty name  :  UOESectionStock11
        /// <summary>UOE���_�݌ɐ��P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock11
        {
            get { return _uOESectionStock11; }
            set { _uOESectionStock11 = value; }
        }

        /// public propaty name  :  UOESectionStock12
        /// <summary>UOE���_�݌ɐ��P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock12
        {
            get { return _uOESectionStock12; }
            set { _uOESectionStock12 = value; }
        }

        /// public propaty name  :  UOESectionStock13
        /// <summary>UOE���_�݌ɐ��P�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock13
        {
            get { return _uOESectionStock13; }
            set { _uOESectionStock13 = value; }
        }

        /// public propaty name  :  UOESectionStock14
        /// <summary>UOE���_�݌ɐ��P�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock14
        {
            get { return _uOESectionStock14; }
            set { _uOESectionStock14 = value; }
        }

        /// public propaty name  :  UOESectionStock15
        /// <summary>UOE���_�݌ɐ��P�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock15
        {
            get { return _uOESectionStock15; }
            set { _uOESectionStock15 = value; }
        }

        /// public propaty name  :  UOESectionStock16
        /// <summary>UOE���_�݌ɐ��P�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock16
        {
            get { return _uOESectionStock16; }
            set { _uOESectionStock16 = value; }
        }

        /// public propaty name  :  UOESectionStock17
        /// <summary>UOE���_�݌ɐ��P�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock17
        {
            get { return _uOESectionStock17; }
            set { _uOESectionStock17 = value; }
        }

        /// public propaty name  :  UOESectionStock18
        /// <summary>UOE���_�݌ɐ��P�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock18
        {
            get { return _uOESectionStock18; }
            set { _uOESectionStock18 = value; }
        }

        /// public propaty name  :  UOESectionStock19
        /// <summary>UOE���_�݌ɐ��P�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��P�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock19
        {
            get { return _uOESectionStock19; }
            set { _uOESectionStock19 = value; }
        }

        /// public propaty name  :  UOESectionStock20
        /// <summary>UOE���_�݌ɐ��Q�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock20
        {
            get { return _uOESectionStock20; }
            set { _uOESectionStock20 = value; }
        }

        /// public propaty name  :  UOESectionStock21
        /// <summary>UOE���_�݌ɐ��Q�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock21
        {
            get { return _uOESectionStock21; }
            set { _uOESectionStock21 = value; }
        }

        /// public propaty name  :  UOESectionStock22
        /// <summary>UOE���_�݌ɐ��Q�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock22
        {
            get { return _uOESectionStock22; }
            set { _uOESectionStock22 = value; }
        }

        /// public propaty name  :  UOESectionStock23
        /// <summary>UOE���_�݌ɐ��Q�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock23
        {
            get { return _uOESectionStock23; }
            set { _uOESectionStock23 = value; }
        }

        /// public propaty name  :  UOESectionStock24
        /// <summary>UOE���_�݌ɐ��Q�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock24
        {
            get { return _uOESectionStock24; }
            set { _uOESectionStock24 = value; }
        }

        /// public propaty name  :  UOESectionStock25
        /// <summary>UOE���_�݌ɐ��Q�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock25
        {
            get { return _uOESectionStock25; }
            set { _uOESectionStock25 = value; }
        }

        /// public propaty name  :  UOESectionStock26
        /// <summary>UOE���_�݌ɐ��Q�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock26
        {
            get { return _uOESectionStock26; }
            set { _uOESectionStock26 = value; }
        }

        /// public propaty name  :  UOESectionStock27
        /// <summary>UOE���_�݌ɐ��Q�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock27
        {
            get { return _uOESectionStock27; }
            set { _uOESectionStock27 = value; }
        }

        /// public propaty name  :  UOESectionStock28
        /// <summary>UOE���_�݌ɐ��Q�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock28
        {
            get { return _uOESectionStock28; }
            set { _uOESectionStock28 = value; }
        }

        /// public propaty name  :  UOESectionStock29
        /// <summary>UOE���_�݌ɐ��Q�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��Q�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock29
        {
            get { return _uOESectionStock29; }
            set { _uOESectionStock29 = value; }
        }

        /// public propaty name  :  UOESectionStock30
        /// <summary>UOE���_�݌ɐ��R�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock30
        {
            get { return _uOESectionStock30; }
            set { _uOESectionStock30 = value; }
        }

        /// public propaty name  :  UOESectionStock31
        /// <summary>UOE���_�݌ɐ��R�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock31
        {
            get { return _uOESectionStock31; }
            set { _uOESectionStock31 = value; }
        }

        /// public propaty name  :  UOESectionStock32
        /// <summary>UOE���_�݌ɐ��R�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock32
        {
            get { return _uOESectionStock32; }
            set { _uOESectionStock32 = value; }
        }

        /// public propaty name  :  UOESectionStock33
        /// <summary>UOE���_�݌ɐ��R�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock33
        {
            get { return _uOESectionStock33; }
            set { _uOESectionStock33 = value; }
        }

        /// public propaty name  :  UOESectionStock34
        /// <summary>UOE���_�݌ɐ��R�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock34
        {
            get { return _uOESectionStock34; }
            set { _uOESectionStock34 = value; }
        }

        /// public propaty name  :  UOESectionStock35
        /// <summary>UOE���_�݌ɐ��R�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�݌ɐ��R�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectionStock35
        {
            get { return _uOESectionStock35; }
            set { _uOESectionStock35 = value; }
        }

        /// public propaty name  :  HeadErrorMassage
        /// <summary>�w�b�h�G���[���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�b�h�G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HeadErrorMassage
        {
            get { return _headErrorMassage; }
            set { _headErrorMassage = value; }
        }

        /// public propaty name  :  LineErrorMassage
        /// <summary>���C���G���[���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���C���G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LineErrorMassage
        {
            get { return _lineErrorMassage; }
            set { _lineErrorMassage = value; }
        }

        /// public propaty name  :  DataSendCode
        /// <summary>�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>���M�t���O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  DataRecoverDiv
        /// <summary>�f�[�^�����敪�v���p�e�B</summary>
        /// <value>���������t���O</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataRecoverDiv
        {
            get { return _dataRecoverDiv; }
            set { _dataRecoverDiv = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj�R���X�g���N�^
        /// </summary>
        /// <returns>StockSndRcvJnl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockSndRcvJnl()
        {
        }

        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="uOESalesOrderRowNo">UOE�����s�ԍ�</param>
        /// <param name="sendTerminalNo">���M�[���ԍ�(���M�������s�[���ԍ�)</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="onlineNo">�I�����C���ԍ�</param>
        /// <param name="onlineRowNo">�I�����C���s�ԍ�</param>
        /// <param name="salesDate">������t(YYYYMMDD)</param>
        /// <param name="inputDay">���͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="dataUpdateDateTime">�f�[�^�X�V����(DateTime:���x��100�i�m�b)</param>
        /// <param name="uOEKind">UOE���(0:UOE 1:�����d����M)</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(�󒍓`�[�ԍ�)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(20:��)</param>
        /// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="cashRegisterNo">���W�ԍ�(�[���ԍ�)</param>
        /// <param name="commonSeqNo">���ʒʔ�</param>
        /// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="boCode">BO�敪</param>
        /// <param name="uOEDeliGoodsDiv">UOE�[�i�敪</param>
        /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
        /// <param name="followDeliGoodsDiv">�t�H���[�[�i�敪</param>
        /// <param name="followDeliGoodsDivNm">�t�H���[�[�i�敪����</param>
        /// <param name="uOEResvdSection">UOE�w�苒�_</param>
        /// <param name="uOEResvdSectionNm">UOE�w�苒�_����</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        /// <param name="employeeName">�]�ƈ�����(�˗��Җ���)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseName">�q�ɖ���</param>
        /// <param name="warehouseShelfNo">�q�ɒI��</param>
        /// <param name="acceptAnOrderCnt">�󒍐���</param>
        /// <param name="listPrice">�艿�i�����j(�K�p�i�艿�j)</param>
        /// <param name="salesUnitCost">�����P��(�d�؂艿�i)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="receiveDate">��M���t</param>
        /// <param name="receiveTime">��M����(HHMMSS)</param>
        /// <param name="answerMakerCd">�񓚃��[�J�[�R�[�h</param>
        /// <param name="answerPartsNo">�񓚕i��</param>
        /// <param name="answerPartsName">�񓚕i��</param>
        /// <param name="substPartsNo">��֕i��</param>
        /// <param name="centerSubstPartsNo">��֕i�ԁi�Z���^�[�j</param>
        /// <param name="answerListPrice">�񓚒艿</param>
        /// <param name="answerSalesUnitCost">�񓚌����P��</param>
        /// <param name="goodsAPrice">���i�`���i</param>
        /// <param name="uOEStopCd">UOE���~�R�[�h</param>
        /// <param name="uOESubstCode">UOE��փR�[�h</param>
        /// <param name="uOEDelivDateCd">UOE�[���R�[�h</param>
        /// <param name="partsLayerCd">�w�ʃR�[�h</param>
        /// <param name="shopStUnitPrice">�̔��X�d���P��</param>
        /// <param name="uOESectionCode1">UOE���_�R�[�h�P(�}�c�_�ݒ荀�ځi���_�R�[�h1�`8))</param>
        /// <param name="uOESectionCode2">UOE���_�R�[�h�Q</param>
        /// <param name="uOESectionCode3">UOE���_�R�[�h�R</param>
        /// <param name="uOESectionCode4">UOE���_�R�[�h�S</param>
        /// <param name="uOESectionCode5">UOE���_�R�[�h�T</param>
        /// <param name="uOESectionCode6">UOE���_�R�[�h�U</param>
        /// <param name="uOESectionCode7">UOE���_�R�[�h�V</param>
        /// <param name="uOESectionCode8">UOE���_�R�[�h�W</param>
        /// <param name="headQtrsStock">�{���݌�</param>
        /// <param name="uOESectionStock1">UOE���_�݌ɐ��P</param>
        /// <param name="uOESectionStock2">UOE���_�݌ɐ��Q</param>
        /// <param name="uOESectionStock3">UOE���_�݌ɐ��R</param>
        /// <param name="uOESectionStock4">UOE���_�݌ɐ��S</param>
        /// <param name="uOESectionStock5">UOE���_�݌ɐ��T</param>
        /// <param name="uOESectionStock6">UOE���_�݌ɐ��U</param>
        /// <param name="uOESectionStock7">UOE���_�݌ɐ��V</param>
        /// <param name="uOESectionStock8">UOE���_�݌ɐ��W</param>
        /// <param name="uOESectionStock9">UOE���_�݌ɐ��X</param>
        /// <param name="uOESectionStock10">UOE���_�݌ɐ��P�O</param>
        /// <param name="uOESectionStock11">UOE���_�݌ɐ��P�P</param>
        /// <param name="uOESectionStock12">UOE���_�݌ɐ��P�Q</param>
        /// <param name="uOESectionStock13">UOE���_�݌ɐ��P�R</param>
        /// <param name="uOESectionStock14">UOE���_�݌ɐ��P�S</param>
        /// <param name="uOESectionStock15">UOE���_�݌ɐ��P�T</param>
        /// <param name="uOESectionStock16">UOE���_�݌ɐ��P�U</param>
        /// <param name="uOESectionStock17">UOE���_�݌ɐ��P�V</param>
        /// <param name="uOESectionStock18">UOE���_�݌ɐ��P�W</param>
        /// <param name="uOESectionStock19">UOE���_�݌ɐ��P�X</param>
        /// <param name="uOESectionStock20">UOE���_�݌ɐ��Q�O</param>
        /// <param name="uOESectionStock21">UOE���_�݌ɐ��Q�P</param>
        /// <param name="uOESectionStock22">UOE���_�݌ɐ��Q�Q</param>
        /// <param name="uOESectionStock23">UOE���_�݌ɐ��Q�R</param>
        /// <param name="uOESectionStock24">UOE���_�݌ɐ��Q�S</param>
        /// <param name="uOESectionStock25">UOE���_�݌ɐ��Q�T</param>
        /// <param name="uOESectionStock26">UOE���_�݌ɐ��Q�U</param>
        /// <param name="uOESectionStock27">UOE���_�݌ɐ��Q�V</param>
        /// <param name="uOESectionStock28">UOE���_�݌ɐ��Q�W</param>
        /// <param name="uOESectionStock29">UOE���_�݌ɐ��Q�X</param>
        /// <param name="uOESectionStock30">UOE���_�݌ɐ��R�O</param>
        /// <param name="uOESectionStock31">UOE���_�݌ɐ��R�P</param>
        /// <param name="uOESectionStock32">UOE���_�݌ɐ��R�Q</param>
        /// <param name="uOESectionStock33">UOE���_�݌ɐ��R�R</param>
        /// <param name="uOESectionStock34">UOE���_�݌ɐ��R�S</param>
        /// <param name="uOESectionStock35">UOE���_�݌ɐ��R�T</param>
        /// <param name="headErrorMassage">�w�b�h�G���[���b�Z�[�W</param>
        /// <param name="lineErrorMassage">���C���G���[���b�Z�[�W</param>
        /// <param name="dataSendCode">�f�[�^���M�敪(���M�t���O)</param>
        /// <param name="dataRecoverDiv">�f�[�^�����敪(���������t���O)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>StockSndRcvJnl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockSndRcvJnl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 systemDivCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo, Int32 sendTerminalNo, Int32 uOESupplierCd, string uOESupplierName, string commAssemblyId, Int32 onlineNo, Int32 onlineRowNo, DateTime salesDate, DateTime inputDay, DateTime dataUpdateDateTime, Int32 uOEKind, string salesSlipNum, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum, string sectionCode, Int32 subSectionCode, Int32 customerCode, string customerSnm, Int32 cashRegisterNo, Int64 commonSeqNo, Int32 supplierFormal, Int32 supplierSlipNo, Int64 stockSlipDtlNum, string boCode, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsNoNoneHyphen, string goodsName, string warehouseCode, string warehouseName, string warehouseShelfNo, Double acceptAnOrderCnt, Double listPrice, Double salesUnitCost, Int32 supplierCd, string supplierSnm, string uoeRemark1, string uoeRemark2, DateTime receiveDate, Int32 receiveTime, Int32 answerMakerCd, string answerPartsNo, string answerPartsName, string substPartsNo, string centerSubstPartsNo, Double answerListPrice, Double answerSalesUnitCost, Double goodsAPrice, string uOEStopCd, string uOESubstCode, string uOEDelivDateCd, string partsLayerCd, Double shopStUnitPrice, string uOESectionCode1, string uOESectionCode2, string uOESectionCode3, string uOESectionCode4, string uOESectionCode5, string uOESectionCode6, string uOESectionCode7, string uOESectionCode8, string headQtrsStock, Int32 uOESectionStock1, Int32 uOESectionStock2, Int32 uOESectionStock3, Int32 uOESectionStock4, Int32 uOESectionStock5, Int32 uOESectionStock6, Int32 uOESectionStock7, Int32 uOESectionStock8, Int32 uOESectionStock9, Int32 uOESectionStock10, Int32 uOESectionStock11, Int32 uOESectionStock12, Int32 uOESectionStock13, Int32 uOESectionStock14, Int32 uOESectionStock15, Int32 uOESectionStock16, Int32 uOESectionStock17, Int32 uOESectionStock18, Int32 uOESectionStock19, Int32 uOESectionStock20, Int32 uOESectionStock21, Int32 uOESectionStock22, Int32 uOESectionStock23, Int32 uOESectionStock24, Int32 uOESectionStock25, Int32 uOESectionStock26, Int32 uOESectionStock27, Int32 uOESectionStock28, Int32 uOESectionStock29, Int32 uOESectionStock30, Int32 uOESectionStock31, Int32 uOESectionStock32, Int32 uOESectionStock33, Int32 uOESectionStock34, Int32 uOESectionStock35, string headErrorMassage, string lineErrorMassage, Int32 dataSendCode, Int32 dataRecoverDiv, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._systemDivCd = systemDivCd;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uOESalesOrderRowNo = uOESalesOrderRowNo;
            this._sendTerminalNo = sendTerminalNo;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._commAssemblyId = commAssemblyId;
            this._onlineNo = onlineNo;
            this._onlineRowNo = onlineRowNo;
            this.SalesDate = salesDate;
            this.InputDay = inputDay;
            this.DataUpdateDateTime = dataUpdateDateTime;
            this._uOEKind = uOEKind;
            this._salesSlipNum = salesSlipNum;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipDtlNum = salesSlipDtlNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._cashRegisterNo = cashRegisterNo;
            this._commonSeqNo = commonSeqNo;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._boCode = boCode;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._followDeliGoodsDivNm = followDeliGoodsDivNm;
            this._uOEResvdSection = uOEResvdSection;
            this._uOEResvdSectionNm = uOEResvdSectionNm;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._goodsName = goodsName;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._acceptAnOrderCnt = acceptAnOrderCnt;
            this._listPrice = listPrice;
            this._salesUnitCost = salesUnitCost;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this.ReceiveDate = receiveDate;
            this._receiveTime = receiveTime;
            this._answerMakerCd = answerMakerCd;
            this._answerPartsNo = answerPartsNo;
            this._answerPartsName = answerPartsName;
            this._substPartsNo = substPartsNo;
            this._centerSubstPartsNo = centerSubstPartsNo;
            this._answerListPrice = answerListPrice;
            this._answerSalesUnitCost = answerSalesUnitCost;
            this._goodsAPrice = goodsAPrice;
            this._uOEStopCd = uOEStopCd;
            this._uOESubstCode = uOESubstCode;
            this._uOEDelivDateCd = uOEDelivDateCd;
            this._partsLayerCd = partsLayerCd;
            this._shopStUnitPrice = shopStUnitPrice;
            this._uOESectionCode1 = uOESectionCode1;
            this._uOESectionCode2 = uOESectionCode2;
            this._uOESectionCode3 = uOESectionCode3;
            this._uOESectionCode4 = uOESectionCode4;
            this._uOESectionCode5 = uOESectionCode5;
            this._uOESectionCode6 = uOESectionCode6;
            this._uOESectionCode7 = uOESectionCode7;
            this._uOESectionCode8 = uOESectionCode8;
            this._headQtrsStock = headQtrsStock;
            this._uOESectionStock1 = uOESectionStock1;
            this._uOESectionStock2 = uOESectionStock2;
            this._uOESectionStock3 = uOESectionStock3;
            this._uOESectionStock4 = uOESectionStock4;
            this._uOESectionStock5 = uOESectionStock5;
            this._uOESectionStock6 = uOESectionStock6;
            this._uOESectionStock7 = uOESectionStock7;
            this._uOESectionStock8 = uOESectionStock8;
            this._uOESectionStock9 = uOESectionStock9;
            this._uOESectionStock10 = uOESectionStock10;
            this._uOESectionStock11 = uOESectionStock11;
            this._uOESectionStock12 = uOESectionStock12;
            this._uOESectionStock13 = uOESectionStock13;
            this._uOESectionStock14 = uOESectionStock14;
            this._uOESectionStock15 = uOESectionStock15;
            this._uOESectionStock16 = uOESectionStock16;
            this._uOESectionStock17 = uOESectionStock17;
            this._uOESectionStock18 = uOESectionStock18;
            this._uOESectionStock19 = uOESectionStock19;
            this._uOESectionStock20 = uOESectionStock20;
            this._uOESectionStock21 = uOESectionStock21;
            this._uOESectionStock22 = uOESectionStock22;
            this._uOESectionStock23 = uOESectionStock23;
            this._uOESectionStock24 = uOESectionStock24;
            this._uOESectionStock25 = uOESectionStock25;
            this._uOESectionStock26 = uOESectionStock26;
            this._uOESectionStock27 = uOESectionStock27;
            this._uOESectionStock28 = uOESectionStock28;
            this._uOESectionStock29 = uOESectionStock29;
            this._uOESectionStock30 = uOESectionStock30;
            this._uOESectionStock31 = uOESectionStock31;
            this._uOESectionStock32 = uOESectionStock32;
            this._uOESectionStock33 = uOESectionStock33;
            this._uOESectionStock34 = uOESectionStock34;
            this._uOESectionStock35 = uOESectionStock35;
            this._headErrorMassage = headErrorMassage;
            this._lineErrorMassage = lineErrorMassage;
            this._dataSendCode = dataSendCode;
            this._dataRecoverDiv = dataRecoverDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj��������
        /// </summary>
        /// <returns>StockSndRcvJnl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockSndRcvJnl�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockSndRcvJnl Clone()
        {
            return new StockSndRcvJnl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._systemDivCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo, this._sendTerminalNo, this._uOESupplierCd, this._uOESupplierName, this._commAssemblyId, this._onlineNo, this._onlineRowNo, this._salesDate, this._inputDay, this._dataUpdateDateTime, this._uOEKind, this._salesSlipNum, this._acptAnOdrStatus, this._salesSlipDtlNum, this._sectionCode, this._subSectionCode, this._customerCode, this._customerSnm, this._cashRegisterNo, this._commonSeqNo, this._supplierFormal, this._supplierSlipNo, this._stockSlipDtlNum, this._boCode, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoNoneHyphen, this._goodsName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._acceptAnOrderCnt, this._listPrice, this._salesUnitCost, this._supplierCd, this._supplierSnm, this._uoeRemark1, this._uoeRemark2, this._receiveDate, this._receiveTime, this._answerMakerCd, this._answerPartsNo, this._answerPartsName, this._substPartsNo, this._centerSubstPartsNo, this._answerListPrice, this._answerSalesUnitCost, this._goodsAPrice, this._uOEStopCd, this._uOESubstCode, this._uOEDelivDateCd, this._partsLayerCd, this._shopStUnitPrice, this._uOESectionCode1, this._uOESectionCode2, this._uOESectionCode3, this._uOESectionCode4, this._uOESectionCode5, this._uOESectionCode6, this._uOESectionCode7, this._uOESectionCode8, this._headQtrsStock, this._uOESectionStock1, this._uOESectionStock2, this._uOESectionStock3, this._uOESectionStock4, this._uOESectionStock5, this._uOESectionStock6, this._uOESectionStock7, this._uOESectionStock8, this._uOESectionStock9, this._uOESectionStock10, this._uOESectionStock11, this._uOESectionStock12, this._uOESectionStock13, this._uOESectionStock14, this._uOESectionStock15, this._uOESectionStock16, this._uOESectionStock17, this._uOESectionStock18, this._uOESectionStock19, this._uOESectionStock20, this._uOESectionStock21, this._uOESectionStock22, this._uOESectionStock23, this._uOESectionStock24, this._uOESectionStock25, this._uOESectionStock26, this._uOESectionStock27, this._uOESectionStock28, this._uOESectionStock29, this._uOESectionStock30, this._uOESectionStock31, this._uOESectionStock32, this._uOESectionStock33, this._uOESectionStock34, this._uOESectionStock35, this._headErrorMassage, this._lineErrorMassage, this._dataSendCode, this._dataRecoverDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockSndRcvJnl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(StockSndRcvJnl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UOESalesOrderRowNo == target.UOESalesOrderRowNo)
                 && (this.SendTerminalNo == target.SendTerminalNo)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.CommAssemblyId == target.CommAssemblyId)
                 && (this.OnlineNo == target.OnlineNo)
                 && (this.OnlineRowNo == target.OnlineRowNo)
                 && (this.SalesDate == target.SalesDate)
                 && (this.InputDay == target.InputDay)
                 && (this.DataUpdateDateTime == target.DataUpdateDateTime)
                 && (this.UOEKind == target.UOEKind)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.BoCode == target.BoCode)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.FollowDeliGoodsDivNm == target.FollowDeliGoodsDivNm)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.UOEResvdSectionNm == target.UOEResvdSectionNm)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.GoodsName == target.GoodsName)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.AcceptAnOrderCnt == target.AcceptAnOrderCnt)
                 && (this.ListPrice == target.ListPrice)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.ReceiveDate == target.ReceiveDate)
                 && (this.ReceiveTime == target.ReceiveTime)
                 && (this.AnswerMakerCd == target.AnswerMakerCd)
                 && (this.AnswerPartsNo == target.AnswerPartsNo)
                 && (this.AnswerPartsName == target.AnswerPartsName)
                 && (this.SubstPartsNo == target.SubstPartsNo)
                 && (this.CenterSubstPartsNo == target.CenterSubstPartsNo)
                 && (this.AnswerListPrice == target.AnswerListPrice)
                 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost)
                 && (this.GoodsAPrice == target.GoodsAPrice)
                 && (this.UOEStopCd == target.UOEStopCd)
                 && (this.UOESubstCode == target.UOESubstCode)
                 && (this.UOEDelivDateCd == target.UOEDelivDateCd)
                 && (this.PartsLayerCd == target.PartsLayerCd)
                 && (this.ShopStUnitPrice == target.ShopStUnitPrice)
                 && (this.UOESectionCode1 == target.UOESectionCode1)
                 && (this.UOESectionCode2 == target.UOESectionCode2)
                 && (this.UOESectionCode3 == target.UOESectionCode3)
                 && (this.UOESectionCode4 == target.UOESectionCode4)
                 && (this.UOESectionCode5 == target.UOESectionCode5)
                 && (this.UOESectionCode6 == target.UOESectionCode6)
                 && (this.UOESectionCode7 == target.UOESectionCode7)
                 && (this.UOESectionCode8 == target.UOESectionCode8)
                 && (this.HeadQtrsStock == target.HeadQtrsStock)
                 && (this.UOESectionStock1 == target.UOESectionStock1)
                 && (this.UOESectionStock2 == target.UOESectionStock2)
                 && (this.UOESectionStock3 == target.UOESectionStock3)
                 && (this.UOESectionStock4 == target.UOESectionStock4)
                 && (this.UOESectionStock5 == target.UOESectionStock5)
                 && (this.UOESectionStock6 == target.UOESectionStock6)
                 && (this.UOESectionStock7 == target.UOESectionStock7)
                 && (this.UOESectionStock8 == target.UOESectionStock8)
                 && (this.UOESectionStock9 == target.UOESectionStock9)
                 && (this.UOESectionStock10 == target.UOESectionStock10)
                 && (this.UOESectionStock11 == target.UOESectionStock11)
                 && (this.UOESectionStock12 == target.UOESectionStock12)
                 && (this.UOESectionStock13 == target.UOESectionStock13)
                 && (this.UOESectionStock14 == target.UOESectionStock14)
                 && (this.UOESectionStock15 == target.UOESectionStock15)
                 && (this.UOESectionStock16 == target.UOESectionStock16)
                 && (this.UOESectionStock17 == target.UOESectionStock17)
                 && (this.UOESectionStock18 == target.UOESectionStock18)
                 && (this.UOESectionStock19 == target.UOESectionStock19)
                 && (this.UOESectionStock20 == target.UOESectionStock20)
                 && (this.UOESectionStock21 == target.UOESectionStock21)
                 && (this.UOESectionStock22 == target.UOESectionStock22)
                 && (this.UOESectionStock23 == target.UOESectionStock23)
                 && (this.UOESectionStock24 == target.UOESectionStock24)
                 && (this.UOESectionStock25 == target.UOESectionStock25)
                 && (this.UOESectionStock26 == target.UOESectionStock26)
                 && (this.UOESectionStock27 == target.UOESectionStock27)
                 && (this.UOESectionStock28 == target.UOESectionStock28)
                 && (this.UOESectionStock29 == target.UOESectionStock29)
                 && (this.UOESectionStock30 == target.UOESectionStock30)
                 && (this.UOESectionStock31 == target.UOESectionStock31)
                 && (this.UOESectionStock32 == target.UOESectionStock32)
                 && (this.UOESectionStock33 == target.UOESectionStock33)
                 && (this.UOESectionStock34 == target.UOESectionStock34)
                 && (this.UOESectionStock35 == target.UOESectionStock35)
                 && (this.HeadErrorMassage == target.HeadErrorMassage)
                 && (this.LineErrorMassage == target.LineErrorMassage)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.DataRecoverDiv == target.DataRecoverDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj��r����
        /// </summary>
        /// <param name="stockSndRcvJnl1">
        ///                    ��r����StockSndRcvJnl�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockSndRcvJnl2">��r����StockSndRcvJnl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(StockSndRcvJnl stockSndRcvJnl1, StockSndRcvJnl stockSndRcvJnl2)
        {
            return ((stockSndRcvJnl1.CreateDateTime == stockSndRcvJnl2.CreateDateTime)
                 && (stockSndRcvJnl1.UpdateDateTime == stockSndRcvJnl2.UpdateDateTime)
                 && (stockSndRcvJnl1.EnterpriseCode == stockSndRcvJnl2.EnterpriseCode)
                 && (stockSndRcvJnl1.FileHeaderGuid == stockSndRcvJnl2.FileHeaderGuid)
                 && (stockSndRcvJnl1.UpdEmployeeCode == stockSndRcvJnl2.UpdEmployeeCode)
                 && (stockSndRcvJnl1.UpdAssemblyId1 == stockSndRcvJnl2.UpdAssemblyId1)
                 && (stockSndRcvJnl1.UpdAssemblyId2 == stockSndRcvJnl2.UpdAssemblyId2)
                 && (stockSndRcvJnl1.LogicalDeleteCode == stockSndRcvJnl2.LogicalDeleteCode)
                 && (stockSndRcvJnl1.SystemDivCd == stockSndRcvJnl2.SystemDivCd)
                 && (stockSndRcvJnl1.UOESalesOrderNo == stockSndRcvJnl2.UOESalesOrderNo)
                 && (stockSndRcvJnl1.UOESalesOrderRowNo == stockSndRcvJnl2.UOESalesOrderRowNo)
                 && (stockSndRcvJnl1.SendTerminalNo == stockSndRcvJnl2.SendTerminalNo)
                 && (stockSndRcvJnl1.UOESupplierCd == stockSndRcvJnl2.UOESupplierCd)
                 && (stockSndRcvJnl1.UOESupplierName == stockSndRcvJnl2.UOESupplierName)
                 && (stockSndRcvJnl1.CommAssemblyId == stockSndRcvJnl2.CommAssemblyId)
                 && (stockSndRcvJnl1.OnlineNo == stockSndRcvJnl2.OnlineNo)
                 && (stockSndRcvJnl1.OnlineRowNo == stockSndRcvJnl2.OnlineRowNo)
                 && (stockSndRcvJnl1.SalesDate == stockSndRcvJnl2.SalesDate)
                 && (stockSndRcvJnl1.InputDay == stockSndRcvJnl2.InputDay)
                 && (stockSndRcvJnl1.DataUpdateDateTime == stockSndRcvJnl2.DataUpdateDateTime)
                 && (stockSndRcvJnl1.UOEKind == stockSndRcvJnl2.UOEKind)
                 && (stockSndRcvJnl1.SalesSlipNum == stockSndRcvJnl2.SalesSlipNum)
                 && (stockSndRcvJnl1.AcptAnOdrStatus == stockSndRcvJnl2.AcptAnOdrStatus)
                 && (stockSndRcvJnl1.SalesSlipDtlNum == stockSndRcvJnl2.SalesSlipDtlNum)
                 && (stockSndRcvJnl1.SectionCode == stockSndRcvJnl2.SectionCode)
                 && (stockSndRcvJnl1.SubSectionCode == stockSndRcvJnl2.SubSectionCode)
                 && (stockSndRcvJnl1.CustomerCode == stockSndRcvJnl2.CustomerCode)
                 && (stockSndRcvJnl1.CustomerSnm == stockSndRcvJnl2.CustomerSnm)
                 && (stockSndRcvJnl1.CashRegisterNo == stockSndRcvJnl2.CashRegisterNo)
                 && (stockSndRcvJnl1.CommonSeqNo == stockSndRcvJnl2.CommonSeqNo)
                 && (stockSndRcvJnl1.SupplierFormal == stockSndRcvJnl2.SupplierFormal)
                 && (stockSndRcvJnl1.SupplierSlipNo == stockSndRcvJnl2.SupplierSlipNo)
                 && (stockSndRcvJnl1.StockSlipDtlNum == stockSndRcvJnl2.StockSlipDtlNum)
                 && (stockSndRcvJnl1.BoCode == stockSndRcvJnl2.BoCode)
                 && (stockSndRcvJnl1.UOEDeliGoodsDiv == stockSndRcvJnl2.UOEDeliGoodsDiv)
                 && (stockSndRcvJnl1.DeliveredGoodsDivNm == stockSndRcvJnl2.DeliveredGoodsDivNm)
                 && (stockSndRcvJnl1.FollowDeliGoodsDiv == stockSndRcvJnl2.FollowDeliGoodsDiv)
                 && (stockSndRcvJnl1.FollowDeliGoodsDivNm == stockSndRcvJnl2.FollowDeliGoodsDivNm)
                 && (stockSndRcvJnl1.UOEResvdSection == stockSndRcvJnl2.UOEResvdSection)
                 && (stockSndRcvJnl1.UOEResvdSectionNm == stockSndRcvJnl2.UOEResvdSectionNm)
                 && (stockSndRcvJnl1.EmployeeCode == stockSndRcvJnl2.EmployeeCode)
                 && (stockSndRcvJnl1.EmployeeName == stockSndRcvJnl2.EmployeeName)
                 && (stockSndRcvJnl1.GoodsMakerCd == stockSndRcvJnl2.GoodsMakerCd)
                 && (stockSndRcvJnl1.MakerName == stockSndRcvJnl2.MakerName)
                 && (stockSndRcvJnl1.GoodsNo == stockSndRcvJnl2.GoodsNo)
                 && (stockSndRcvJnl1.GoodsNoNoneHyphen == stockSndRcvJnl2.GoodsNoNoneHyphen)
                 && (stockSndRcvJnl1.GoodsName == stockSndRcvJnl2.GoodsName)
                 && (stockSndRcvJnl1.WarehouseCode == stockSndRcvJnl2.WarehouseCode)
                 && (stockSndRcvJnl1.WarehouseName == stockSndRcvJnl2.WarehouseName)
                 && (stockSndRcvJnl1.WarehouseShelfNo == stockSndRcvJnl2.WarehouseShelfNo)
                 && (stockSndRcvJnl1.AcceptAnOrderCnt == stockSndRcvJnl2.AcceptAnOrderCnt)
                 && (stockSndRcvJnl1.ListPrice == stockSndRcvJnl2.ListPrice)
                 && (stockSndRcvJnl1.SalesUnitCost == stockSndRcvJnl2.SalesUnitCost)
                 && (stockSndRcvJnl1.SupplierCd == stockSndRcvJnl2.SupplierCd)
                 && (stockSndRcvJnl1.SupplierSnm == stockSndRcvJnl2.SupplierSnm)
                 && (stockSndRcvJnl1.UoeRemark1 == stockSndRcvJnl2.UoeRemark1)
                 && (stockSndRcvJnl1.UoeRemark2 == stockSndRcvJnl2.UoeRemark2)
                 && (stockSndRcvJnl1.ReceiveDate == stockSndRcvJnl2.ReceiveDate)
                 && (stockSndRcvJnl1.ReceiveTime == stockSndRcvJnl2.ReceiveTime)
                 && (stockSndRcvJnl1.AnswerMakerCd == stockSndRcvJnl2.AnswerMakerCd)
                 && (stockSndRcvJnl1.AnswerPartsNo == stockSndRcvJnl2.AnswerPartsNo)
                 && (stockSndRcvJnl1.AnswerPartsName == stockSndRcvJnl2.AnswerPartsName)
                 && (stockSndRcvJnl1.SubstPartsNo == stockSndRcvJnl2.SubstPartsNo)
                 && (stockSndRcvJnl1.CenterSubstPartsNo == stockSndRcvJnl2.CenterSubstPartsNo)
                 && (stockSndRcvJnl1.AnswerListPrice == stockSndRcvJnl2.AnswerListPrice)
                 && (stockSndRcvJnl1.AnswerSalesUnitCost == stockSndRcvJnl2.AnswerSalesUnitCost)
                 && (stockSndRcvJnl1.GoodsAPrice == stockSndRcvJnl2.GoodsAPrice)
                 && (stockSndRcvJnl1.UOEStopCd == stockSndRcvJnl2.UOEStopCd)
                 && (stockSndRcvJnl1.UOESubstCode == stockSndRcvJnl2.UOESubstCode)
                 && (stockSndRcvJnl1.UOEDelivDateCd == stockSndRcvJnl2.UOEDelivDateCd)
                 && (stockSndRcvJnl1.PartsLayerCd == stockSndRcvJnl2.PartsLayerCd)
                 && (stockSndRcvJnl1.ShopStUnitPrice == stockSndRcvJnl2.ShopStUnitPrice)
                 && (stockSndRcvJnl1.UOESectionCode1 == stockSndRcvJnl2.UOESectionCode1)
                 && (stockSndRcvJnl1.UOESectionCode2 == stockSndRcvJnl2.UOESectionCode2)
                 && (stockSndRcvJnl1.UOESectionCode3 == stockSndRcvJnl2.UOESectionCode3)
                 && (stockSndRcvJnl1.UOESectionCode4 == stockSndRcvJnl2.UOESectionCode4)
                 && (stockSndRcvJnl1.UOESectionCode5 == stockSndRcvJnl2.UOESectionCode5)
                 && (stockSndRcvJnl1.UOESectionCode6 == stockSndRcvJnl2.UOESectionCode6)
                 && (stockSndRcvJnl1.UOESectionCode7 == stockSndRcvJnl2.UOESectionCode7)
                 && (stockSndRcvJnl1.UOESectionCode8 == stockSndRcvJnl2.UOESectionCode8)
                 && (stockSndRcvJnl1.HeadQtrsStock == stockSndRcvJnl2.HeadQtrsStock)
                 && (stockSndRcvJnl1.UOESectionStock1 == stockSndRcvJnl2.UOESectionStock1)
                 && (stockSndRcvJnl1.UOESectionStock2 == stockSndRcvJnl2.UOESectionStock2)
                 && (stockSndRcvJnl1.UOESectionStock3 == stockSndRcvJnl2.UOESectionStock3)
                 && (stockSndRcvJnl1.UOESectionStock4 == stockSndRcvJnl2.UOESectionStock4)
                 && (stockSndRcvJnl1.UOESectionStock5 == stockSndRcvJnl2.UOESectionStock5)
                 && (stockSndRcvJnl1.UOESectionStock6 == stockSndRcvJnl2.UOESectionStock6)
                 && (stockSndRcvJnl1.UOESectionStock7 == stockSndRcvJnl2.UOESectionStock7)
                 && (stockSndRcvJnl1.UOESectionStock8 == stockSndRcvJnl2.UOESectionStock8)
                 && (stockSndRcvJnl1.UOESectionStock9 == stockSndRcvJnl2.UOESectionStock9)
                 && (stockSndRcvJnl1.UOESectionStock10 == stockSndRcvJnl2.UOESectionStock10)
                 && (stockSndRcvJnl1.UOESectionStock11 == stockSndRcvJnl2.UOESectionStock11)
                 && (stockSndRcvJnl1.UOESectionStock12 == stockSndRcvJnl2.UOESectionStock12)
                 && (stockSndRcvJnl1.UOESectionStock13 == stockSndRcvJnl2.UOESectionStock13)
                 && (stockSndRcvJnl1.UOESectionStock14 == stockSndRcvJnl2.UOESectionStock14)
                 && (stockSndRcvJnl1.UOESectionStock15 == stockSndRcvJnl2.UOESectionStock15)
                 && (stockSndRcvJnl1.UOESectionStock16 == stockSndRcvJnl2.UOESectionStock16)
                 && (stockSndRcvJnl1.UOESectionStock17 == stockSndRcvJnl2.UOESectionStock17)
                 && (stockSndRcvJnl1.UOESectionStock18 == stockSndRcvJnl2.UOESectionStock18)
                 && (stockSndRcvJnl1.UOESectionStock19 == stockSndRcvJnl2.UOESectionStock19)
                 && (stockSndRcvJnl1.UOESectionStock20 == stockSndRcvJnl2.UOESectionStock20)
                 && (stockSndRcvJnl1.UOESectionStock21 == stockSndRcvJnl2.UOESectionStock21)
                 && (stockSndRcvJnl1.UOESectionStock22 == stockSndRcvJnl2.UOESectionStock22)
                 && (stockSndRcvJnl1.UOESectionStock23 == stockSndRcvJnl2.UOESectionStock23)
                 && (stockSndRcvJnl1.UOESectionStock24 == stockSndRcvJnl2.UOESectionStock24)
                 && (stockSndRcvJnl1.UOESectionStock25 == stockSndRcvJnl2.UOESectionStock25)
                 && (stockSndRcvJnl1.UOESectionStock26 == stockSndRcvJnl2.UOESectionStock26)
                 && (stockSndRcvJnl1.UOESectionStock27 == stockSndRcvJnl2.UOESectionStock27)
                 && (stockSndRcvJnl1.UOESectionStock28 == stockSndRcvJnl2.UOESectionStock28)
                 && (stockSndRcvJnl1.UOESectionStock29 == stockSndRcvJnl2.UOESectionStock29)
                 && (stockSndRcvJnl1.UOESectionStock30 == stockSndRcvJnl2.UOESectionStock30)
                 && (stockSndRcvJnl1.UOESectionStock31 == stockSndRcvJnl2.UOESectionStock31)
                 && (stockSndRcvJnl1.UOESectionStock32 == stockSndRcvJnl2.UOESectionStock32)
                 && (stockSndRcvJnl1.UOESectionStock33 == stockSndRcvJnl2.UOESectionStock33)
                 && (stockSndRcvJnl1.UOESectionStock34 == stockSndRcvJnl2.UOESectionStock34)
                 && (stockSndRcvJnl1.UOESectionStock35 == stockSndRcvJnl2.UOESectionStock35)
                 && (stockSndRcvJnl1.HeadErrorMassage == stockSndRcvJnl2.HeadErrorMassage)
                 && (stockSndRcvJnl1.LineErrorMassage == stockSndRcvJnl2.LineErrorMassage)
                 && (stockSndRcvJnl1.DataSendCode == stockSndRcvJnl2.DataSendCode)
                 && (stockSndRcvJnl1.DataRecoverDiv == stockSndRcvJnl2.DataRecoverDiv)
                 && (stockSndRcvJnl1.EnterpriseName == stockSndRcvJnl2.EnterpriseName)
                 && (stockSndRcvJnl1.UpdEmployeeName == stockSndRcvJnl2.UpdEmployeeName));
        }
        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockSndRcvJnl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(StockSndRcvJnl target)
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
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UOESalesOrderRowNo != target.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (this.SendTerminalNo != target.SendTerminalNo) resList.Add("SendTerminalNo");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.CommAssemblyId != target.CommAssemblyId) resList.Add("CommAssemblyId");
            if (this.OnlineNo != target.OnlineNo) resList.Add("OnlineNo");
            if (this.OnlineRowNo != target.OnlineRowNo) resList.Add("OnlineRowNo");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.DataUpdateDateTime != target.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (this.UOEKind != target.UOEKind) resList.Add("UOEKind");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipDtlNum != target.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.BoCode != target.BoCode) resList.Add("BoCode");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.FollowDeliGoodsDivNm != target.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.UOEResvdSectionNm != target.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.AcceptAnOrderCnt != target.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.ReceiveDate != target.ReceiveDate) resList.Add("ReceiveDate");
            if (this.ReceiveTime != target.ReceiveTime) resList.Add("ReceiveTime");
            if (this.AnswerMakerCd != target.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (this.AnswerPartsNo != target.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (this.AnswerPartsName != target.AnswerPartsName) resList.Add("AnswerPartsName");
            if (this.SubstPartsNo != target.SubstPartsNo) resList.Add("SubstPartsNo");
            if (this.CenterSubstPartsNo != target.CenterSubstPartsNo) resList.Add("CenterSubstPartsNo");
            if (this.AnswerListPrice != target.AnswerListPrice) resList.Add("AnswerListPrice");
            if (this.AnswerSalesUnitCost != target.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (this.GoodsAPrice != target.GoodsAPrice) resList.Add("GoodsAPrice");
            if (this.UOEStopCd != target.UOEStopCd) resList.Add("UOEStopCd");
            if (this.UOESubstCode != target.UOESubstCode) resList.Add("UOESubstCode");
            if (this.UOEDelivDateCd != target.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (this.PartsLayerCd != target.PartsLayerCd) resList.Add("PartsLayerCd");
            if (this.ShopStUnitPrice != target.ShopStUnitPrice) resList.Add("ShopStUnitPrice");
            if (this.UOESectionCode1 != target.UOESectionCode1) resList.Add("UOESectionCode1");
            if (this.UOESectionCode2 != target.UOESectionCode2) resList.Add("UOESectionCode2");
            if (this.UOESectionCode3 != target.UOESectionCode3) resList.Add("UOESectionCode3");
            if (this.UOESectionCode4 != target.UOESectionCode4) resList.Add("UOESectionCode4");
            if (this.UOESectionCode5 != target.UOESectionCode5) resList.Add("UOESectionCode5");
            if (this.UOESectionCode6 != target.UOESectionCode6) resList.Add("UOESectionCode6");
            if (this.UOESectionCode7 != target.UOESectionCode7) resList.Add("UOESectionCode7");
            if (this.UOESectionCode8 != target.UOESectionCode8) resList.Add("UOESectionCode8");
            if (this.HeadQtrsStock != target.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (this.UOESectionStock1 != target.UOESectionStock1) resList.Add("UOESectionStock1");
            if (this.UOESectionStock2 != target.UOESectionStock2) resList.Add("UOESectionStock2");
            if (this.UOESectionStock3 != target.UOESectionStock3) resList.Add("UOESectionStock3");
            if (this.UOESectionStock4 != target.UOESectionStock4) resList.Add("UOESectionStock4");
            if (this.UOESectionStock5 != target.UOESectionStock5) resList.Add("UOESectionStock5");
            if (this.UOESectionStock6 != target.UOESectionStock6) resList.Add("UOESectionStock6");
            if (this.UOESectionStock7 != target.UOESectionStock7) resList.Add("UOESectionStock7");
            if (this.UOESectionStock8 != target.UOESectionStock8) resList.Add("UOESectionStock8");
            if (this.UOESectionStock9 != target.UOESectionStock9) resList.Add("UOESectionStock9");
            if (this.UOESectionStock10 != target.UOESectionStock10) resList.Add("UOESectionStock10");
            if (this.UOESectionStock11 != target.UOESectionStock11) resList.Add("UOESectionStock11");
            if (this.UOESectionStock12 != target.UOESectionStock12) resList.Add("UOESectionStock12");
            if (this.UOESectionStock13 != target.UOESectionStock13) resList.Add("UOESectionStock13");
            if (this.UOESectionStock14 != target.UOESectionStock14) resList.Add("UOESectionStock14");
            if (this.UOESectionStock15 != target.UOESectionStock15) resList.Add("UOESectionStock15");
            if (this.UOESectionStock16 != target.UOESectionStock16) resList.Add("UOESectionStock16");
            if (this.UOESectionStock17 != target.UOESectionStock17) resList.Add("UOESectionStock17");
            if (this.UOESectionStock18 != target.UOESectionStock18) resList.Add("UOESectionStock18");
            if (this.UOESectionStock19 != target.UOESectionStock19) resList.Add("UOESectionStock19");
            if (this.UOESectionStock20 != target.UOESectionStock20) resList.Add("UOESectionStock20");
            if (this.UOESectionStock21 != target.UOESectionStock21) resList.Add("UOESectionStock21");
            if (this.UOESectionStock22 != target.UOESectionStock22) resList.Add("UOESectionStock22");
            if (this.UOESectionStock23 != target.UOESectionStock23) resList.Add("UOESectionStock23");
            if (this.UOESectionStock24 != target.UOESectionStock24) resList.Add("UOESectionStock24");
            if (this.UOESectionStock25 != target.UOESectionStock25) resList.Add("UOESectionStock25");
            if (this.UOESectionStock26 != target.UOESectionStock26) resList.Add("UOESectionStock26");
            if (this.UOESectionStock27 != target.UOESectionStock27) resList.Add("UOESectionStock27");
            if (this.UOESectionStock28 != target.UOESectionStock28) resList.Add("UOESectionStock28");
            if (this.UOESectionStock29 != target.UOESectionStock29) resList.Add("UOESectionStock29");
            if (this.UOESectionStock30 != target.UOESectionStock30) resList.Add("UOESectionStock30");
            if (this.UOESectionStock31 != target.UOESectionStock31) resList.Add("UOESectionStock31");
            if (this.UOESectionStock32 != target.UOESectionStock32) resList.Add("UOESectionStock32");
            if (this.UOESectionStock33 != target.UOESectionStock33) resList.Add("UOESectionStock33");
            if (this.UOESectionStock34 != target.UOESectionStock34) resList.Add("UOESectionStock34");
            if (this.UOESectionStock35 != target.UOESectionStock35) resList.Add("UOESectionStock35");
            if (this.HeadErrorMassage != target.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (this.LineErrorMassage != target.LineErrorMassage) resList.Add("LineErrorMassage");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.DataRecoverDiv != target.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// UOE����M�W���[�i���i�݌Ɂj��r����
        /// </summary>
        /// <param name="stockSndRcvJnl1">��r����StockSndRcvJnl�N���X�̃C���X�^���X</param>
        /// <param name="stockSndRcvJnl2">��r����StockSndRcvJnl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSndRcvJnl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(StockSndRcvJnl stockSndRcvJnl1, StockSndRcvJnl stockSndRcvJnl2)
        {
            ArrayList resList = new ArrayList();
            if (stockSndRcvJnl1.CreateDateTime != stockSndRcvJnl2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockSndRcvJnl1.UpdateDateTime != stockSndRcvJnl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockSndRcvJnl1.EnterpriseCode != stockSndRcvJnl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockSndRcvJnl1.FileHeaderGuid != stockSndRcvJnl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockSndRcvJnl1.UpdEmployeeCode != stockSndRcvJnl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockSndRcvJnl1.UpdAssemblyId1 != stockSndRcvJnl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockSndRcvJnl1.UpdAssemblyId2 != stockSndRcvJnl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockSndRcvJnl1.LogicalDeleteCode != stockSndRcvJnl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockSndRcvJnl1.SystemDivCd != stockSndRcvJnl2.SystemDivCd) resList.Add("SystemDivCd");
            if (stockSndRcvJnl1.UOESalesOrderNo != stockSndRcvJnl2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (stockSndRcvJnl1.UOESalesOrderRowNo != stockSndRcvJnl2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (stockSndRcvJnl1.SendTerminalNo != stockSndRcvJnl2.SendTerminalNo) resList.Add("SendTerminalNo");
            if (stockSndRcvJnl1.UOESupplierCd != stockSndRcvJnl2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (stockSndRcvJnl1.UOESupplierName != stockSndRcvJnl2.UOESupplierName) resList.Add("UOESupplierName");
            if (stockSndRcvJnl1.CommAssemblyId != stockSndRcvJnl2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (stockSndRcvJnl1.OnlineNo != stockSndRcvJnl2.OnlineNo) resList.Add("OnlineNo");
            if (stockSndRcvJnl1.OnlineRowNo != stockSndRcvJnl2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (stockSndRcvJnl1.SalesDate != stockSndRcvJnl2.SalesDate) resList.Add("SalesDate");
            if (stockSndRcvJnl1.InputDay != stockSndRcvJnl2.InputDay) resList.Add("InputDay");
            if (stockSndRcvJnl1.DataUpdateDateTime != stockSndRcvJnl2.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (stockSndRcvJnl1.UOEKind != stockSndRcvJnl2.UOEKind) resList.Add("UOEKind");
            if (stockSndRcvJnl1.SalesSlipNum != stockSndRcvJnl2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (stockSndRcvJnl1.AcptAnOdrStatus != stockSndRcvJnl2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (stockSndRcvJnl1.SalesSlipDtlNum != stockSndRcvJnl2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (stockSndRcvJnl1.SectionCode != stockSndRcvJnl2.SectionCode) resList.Add("SectionCode");
            if (stockSndRcvJnl1.SubSectionCode != stockSndRcvJnl2.SubSectionCode) resList.Add("SubSectionCode");
            if (stockSndRcvJnl1.CustomerCode != stockSndRcvJnl2.CustomerCode) resList.Add("CustomerCode");
            if (stockSndRcvJnl1.CustomerSnm != stockSndRcvJnl2.CustomerSnm) resList.Add("CustomerSnm");
            if (stockSndRcvJnl1.CashRegisterNo != stockSndRcvJnl2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (stockSndRcvJnl1.CommonSeqNo != stockSndRcvJnl2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (stockSndRcvJnl1.SupplierFormal != stockSndRcvJnl2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockSndRcvJnl1.SupplierSlipNo != stockSndRcvJnl2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (stockSndRcvJnl1.StockSlipDtlNum != stockSndRcvJnl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockSndRcvJnl1.BoCode != stockSndRcvJnl2.BoCode) resList.Add("BoCode");
            if (stockSndRcvJnl1.UOEDeliGoodsDiv != stockSndRcvJnl2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (stockSndRcvJnl1.DeliveredGoodsDivNm != stockSndRcvJnl2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (stockSndRcvJnl1.FollowDeliGoodsDiv != stockSndRcvJnl2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (stockSndRcvJnl1.FollowDeliGoodsDivNm != stockSndRcvJnl2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (stockSndRcvJnl1.UOEResvdSection != stockSndRcvJnl2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (stockSndRcvJnl1.UOEResvdSectionNm != stockSndRcvJnl2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (stockSndRcvJnl1.EmployeeCode != stockSndRcvJnl2.EmployeeCode) resList.Add("EmployeeCode");
            if (stockSndRcvJnl1.EmployeeName != stockSndRcvJnl2.EmployeeName) resList.Add("EmployeeName");
            if (stockSndRcvJnl1.GoodsMakerCd != stockSndRcvJnl2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockSndRcvJnl1.MakerName != stockSndRcvJnl2.MakerName) resList.Add("MakerName");
            if (stockSndRcvJnl1.GoodsNo != stockSndRcvJnl2.GoodsNo) resList.Add("GoodsNo");
            if (stockSndRcvJnl1.GoodsNoNoneHyphen != stockSndRcvJnl2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stockSndRcvJnl1.GoodsName != stockSndRcvJnl2.GoodsName) resList.Add("GoodsName");
            if (stockSndRcvJnl1.WarehouseCode != stockSndRcvJnl2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockSndRcvJnl1.WarehouseName != stockSndRcvJnl2.WarehouseName) resList.Add("WarehouseName");
            if (stockSndRcvJnl1.WarehouseShelfNo != stockSndRcvJnl2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockSndRcvJnl1.AcceptAnOrderCnt != stockSndRcvJnl2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (stockSndRcvJnl1.ListPrice != stockSndRcvJnl2.ListPrice) resList.Add("ListPrice");
            if (stockSndRcvJnl1.SalesUnitCost != stockSndRcvJnl2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (stockSndRcvJnl1.SupplierCd != stockSndRcvJnl2.SupplierCd) resList.Add("SupplierCd");
            if (stockSndRcvJnl1.SupplierSnm != stockSndRcvJnl2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockSndRcvJnl1.UoeRemark1 != stockSndRcvJnl2.UoeRemark1) resList.Add("UoeRemark1");
            if (stockSndRcvJnl1.UoeRemark2 != stockSndRcvJnl2.UoeRemark2) resList.Add("UoeRemark2");
            if (stockSndRcvJnl1.ReceiveDate != stockSndRcvJnl2.ReceiveDate) resList.Add("ReceiveDate");
            if (stockSndRcvJnl1.ReceiveTime != stockSndRcvJnl2.ReceiveTime) resList.Add("ReceiveTime");
            if (stockSndRcvJnl1.AnswerMakerCd != stockSndRcvJnl2.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (stockSndRcvJnl1.AnswerPartsNo != stockSndRcvJnl2.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (stockSndRcvJnl1.AnswerPartsName != stockSndRcvJnl2.AnswerPartsName) resList.Add("AnswerPartsName");
            if (stockSndRcvJnl1.SubstPartsNo != stockSndRcvJnl2.SubstPartsNo) resList.Add("SubstPartsNo");
            if (stockSndRcvJnl1.CenterSubstPartsNo != stockSndRcvJnl2.CenterSubstPartsNo) resList.Add("CenterSubstPartsNo");
            if (stockSndRcvJnl1.AnswerListPrice != stockSndRcvJnl2.AnswerListPrice) resList.Add("AnswerListPrice");
            if (stockSndRcvJnl1.AnswerSalesUnitCost != stockSndRcvJnl2.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (stockSndRcvJnl1.GoodsAPrice != stockSndRcvJnl2.GoodsAPrice) resList.Add("GoodsAPrice");
            if (stockSndRcvJnl1.UOEStopCd != stockSndRcvJnl2.UOEStopCd) resList.Add("UOEStopCd");
            if (stockSndRcvJnl1.UOESubstCode != stockSndRcvJnl2.UOESubstCode) resList.Add("UOESubstCode");
            if (stockSndRcvJnl1.UOEDelivDateCd != stockSndRcvJnl2.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (stockSndRcvJnl1.PartsLayerCd != stockSndRcvJnl2.PartsLayerCd) resList.Add("PartsLayerCd");
            if (stockSndRcvJnl1.ShopStUnitPrice != stockSndRcvJnl2.ShopStUnitPrice) resList.Add("ShopStUnitPrice");
            if (stockSndRcvJnl1.UOESectionCode1 != stockSndRcvJnl2.UOESectionCode1) resList.Add("UOESectionCode1");
            if (stockSndRcvJnl1.UOESectionCode2 != stockSndRcvJnl2.UOESectionCode2) resList.Add("UOESectionCode2");
            if (stockSndRcvJnl1.UOESectionCode3 != stockSndRcvJnl2.UOESectionCode3) resList.Add("UOESectionCode3");
            if (stockSndRcvJnl1.UOESectionCode4 != stockSndRcvJnl2.UOESectionCode4) resList.Add("UOESectionCode4");
            if (stockSndRcvJnl1.UOESectionCode5 != stockSndRcvJnl2.UOESectionCode5) resList.Add("UOESectionCode5");
            if (stockSndRcvJnl1.UOESectionCode6 != stockSndRcvJnl2.UOESectionCode6) resList.Add("UOESectionCode6");
            if (stockSndRcvJnl1.UOESectionCode7 != stockSndRcvJnl2.UOESectionCode7) resList.Add("UOESectionCode7");
            if (stockSndRcvJnl1.UOESectionCode8 != stockSndRcvJnl2.UOESectionCode8) resList.Add("UOESectionCode8");
            if (stockSndRcvJnl1.HeadQtrsStock != stockSndRcvJnl2.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (stockSndRcvJnl1.UOESectionStock1 != stockSndRcvJnl2.UOESectionStock1) resList.Add("UOESectionStock1");
            if (stockSndRcvJnl1.UOESectionStock2 != stockSndRcvJnl2.UOESectionStock2) resList.Add("UOESectionStock2");
            if (stockSndRcvJnl1.UOESectionStock3 != stockSndRcvJnl2.UOESectionStock3) resList.Add("UOESectionStock3");
            if (stockSndRcvJnl1.UOESectionStock4 != stockSndRcvJnl2.UOESectionStock4) resList.Add("UOESectionStock4");
            if (stockSndRcvJnl1.UOESectionStock5 != stockSndRcvJnl2.UOESectionStock5) resList.Add("UOESectionStock5");
            if (stockSndRcvJnl1.UOESectionStock6 != stockSndRcvJnl2.UOESectionStock6) resList.Add("UOESectionStock6");
            if (stockSndRcvJnl1.UOESectionStock7 != stockSndRcvJnl2.UOESectionStock7) resList.Add("UOESectionStock7");
            if (stockSndRcvJnl1.UOESectionStock8 != stockSndRcvJnl2.UOESectionStock8) resList.Add("UOESectionStock8");
            if (stockSndRcvJnl1.UOESectionStock9 != stockSndRcvJnl2.UOESectionStock9) resList.Add("UOESectionStock9");
            if (stockSndRcvJnl1.UOESectionStock10 != stockSndRcvJnl2.UOESectionStock10) resList.Add("UOESectionStock10");
            if (stockSndRcvJnl1.UOESectionStock11 != stockSndRcvJnl2.UOESectionStock11) resList.Add("UOESectionStock11");
            if (stockSndRcvJnl1.UOESectionStock12 != stockSndRcvJnl2.UOESectionStock12) resList.Add("UOESectionStock12");
            if (stockSndRcvJnl1.UOESectionStock13 != stockSndRcvJnl2.UOESectionStock13) resList.Add("UOESectionStock13");
            if (stockSndRcvJnl1.UOESectionStock14 != stockSndRcvJnl2.UOESectionStock14) resList.Add("UOESectionStock14");
            if (stockSndRcvJnl1.UOESectionStock15 != stockSndRcvJnl2.UOESectionStock15) resList.Add("UOESectionStock15");
            if (stockSndRcvJnl1.UOESectionStock16 != stockSndRcvJnl2.UOESectionStock16) resList.Add("UOESectionStock16");
            if (stockSndRcvJnl1.UOESectionStock17 != stockSndRcvJnl2.UOESectionStock17) resList.Add("UOESectionStock17");
            if (stockSndRcvJnl1.UOESectionStock18 != stockSndRcvJnl2.UOESectionStock18) resList.Add("UOESectionStock18");
            if (stockSndRcvJnl1.UOESectionStock19 != stockSndRcvJnl2.UOESectionStock19) resList.Add("UOESectionStock19");
            if (stockSndRcvJnl1.UOESectionStock20 != stockSndRcvJnl2.UOESectionStock20) resList.Add("UOESectionStock20");
            if (stockSndRcvJnl1.UOESectionStock21 != stockSndRcvJnl2.UOESectionStock21) resList.Add("UOESectionStock21");
            if (stockSndRcvJnl1.UOESectionStock22 != stockSndRcvJnl2.UOESectionStock22) resList.Add("UOESectionStock22");
            if (stockSndRcvJnl1.UOESectionStock23 != stockSndRcvJnl2.UOESectionStock23) resList.Add("UOESectionStock23");
            if (stockSndRcvJnl1.UOESectionStock24 != stockSndRcvJnl2.UOESectionStock24) resList.Add("UOESectionStock24");
            if (stockSndRcvJnl1.UOESectionStock25 != stockSndRcvJnl2.UOESectionStock25) resList.Add("UOESectionStock25");
            if (stockSndRcvJnl1.UOESectionStock26 != stockSndRcvJnl2.UOESectionStock26) resList.Add("UOESectionStock26");
            if (stockSndRcvJnl1.UOESectionStock27 != stockSndRcvJnl2.UOESectionStock27) resList.Add("UOESectionStock27");
            if (stockSndRcvJnl1.UOESectionStock28 != stockSndRcvJnl2.UOESectionStock28) resList.Add("UOESectionStock28");
            if (stockSndRcvJnl1.UOESectionStock29 != stockSndRcvJnl2.UOESectionStock29) resList.Add("UOESectionStock29");
            if (stockSndRcvJnl1.UOESectionStock30 != stockSndRcvJnl2.UOESectionStock30) resList.Add("UOESectionStock30");
            if (stockSndRcvJnl1.UOESectionStock31 != stockSndRcvJnl2.UOESectionStock31) resList.Add("UOESectionStock31");
            if (stockSndRcvJnl1.UOESectionStock32 != stockSndRcvJnl2.UOESectionStock32) resList.Add("UOESectionStock32");
            if (stockSndRcvJnl1.UOESectionStock33 != stockSndRcvJnl2.UOESectionStock33) resList.Add("UOESectionStock33");
            if (stockSndRcvJnl1.UOESectionStock34 != stockSndRcvJnl2.UOESectionStock34) resList.Add("UOESectionStock34");
            if (stockSndRcvJnl1.UOESectionStock35 != stockSndRcvJnl2.UOESectionStock35) resList.Add("UOESectionStock35");
            if (stockSndRcvJnl1.HeadErrorMassage != stockSndRcvJnl2.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (stockSndRcvJnl1.LineErrorMassage != stockSndRcvJnl2.LineErrorMassage) resList.Add("LineErrorMassage");
            if (stockSndRcvJnl1.DataSendCode != stockSndRcvJnl2.DataSendCode) resList.Add("DataSendCode");
            if (stockSndRcvJnl1.DataRecoverDiv != stockSndRcvJnl2.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (stockSndRcvJnl1.EnterpriseName != stockSndRcvJnl2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockSndRcvJnl1.UpdEmployeeName != stockSndRcvJnl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
