using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailDefaultHeader
    /// <summary>
    ///                      ���[�������l�w�b�_�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�������l�w�b�_�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailDefaultHeader
    {
        /// <summary>�N�����[�h</summary>
        /// <remarks>0:�ʏ�N���A1:QR�t���N��</remarks>
        private Int32 _mode;

        /// <summary>�Y�t�t�@�C���p�X</summary>
        /// <remarks>�Y�t�t�@�C���p�X�i�p�q�R�[�h�̃t�@�C���p�X�j</remarks>
        private string _attachedFilePath = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>������͋��_�R�[�h</summary>
        /// <remarks>�����^ �������͂������_�R�[�h</remarks>
        private string _salesInpSecCd = "";

        /// <summary>�����v�㋒�_�R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _demandAddUpSecCd = "";

        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _shipmentDay;

        /// <summary>������t</summary>
        /// <remarks>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>�v����t</summary>
        /// <remarks>�������@(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>���ϋ敪</summary>
        /// <remarks>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</remarks>
        private Int32 _estimateDivide;

        /// <summary>���͒S���҃R�[�h</summary>
        /// <remarks>���O�C���S���ҁi�t�r�a�j</remarks>
        private string _inputAgenCd = "";

        /// <summary>���͒S���Җ���</summary>
        private string _inputAgenNm = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>���㍇�v���z(�Ŕ���)</summary>
        /// <remarks>��ʏ�̔��㍇�v�ɑ���</remarks>
        private Int64 _salesTotalPriceTaxExc;

        /// <summary>�������Łi���v�j</summary>
        /// <remarks>��ʏ�̏����</remarks>
        private Int64 _salesPriceConsTaxTotal;

        /// <summary>���㍇�v���z�i�ō��݁j</summary>
        /// <remarks>��ʏ�̍��v���z</remarks>
        private Int64 _salesTotalPrice;

        /// <summary>�������z�v</summary>
        private Int64 _totalCost;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>���Ӑ�`�[�ԍ�</summary>
        private Int32 _custSlipNo;

        /// <summary>�`�[�Z���敪</summary>
        /// <remarks>1:���Ӑ�,2:�[����</remarks>
        private Int32 _slipAddressDiv;

        /// <summary>�[�i��R�[�h</summary>
        private Int32 _addresseeCode;

        /// <summary>�[�i�於��</summary>
        private string _addresseeName = "";

        /// <summary>�[�i�於��2</summary>
        /// <remarks>�ǉ�(�o�^�R��) ����</remarks>
        private string _addresseeName2 = "";

        /// <summary>�[�i��X�֔ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseePostNo = "";

        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr1 = "";

        /// <summary>�[�i��Z��3(�Ԓn)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr3 = "";

        /// <summary>�[�i��Z��4(�A�p�[�g����)</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeAddr4 = "";

        /// <summary>�[�i��d�b�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeTelNo = "";

        /// <summary>�[�i��FAX�ԍ�</summary>
        /// <remarks>�`�[�Z���敪�ɏ]�����e</remarks>
        private string _addresseeFaxNo = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";

        /// <summary>�`�[���l�R</summary>
        private string _slipNote3 = "";

        /// <summary>�ԕi���R�R�[�h</summary>
        private Int32 _retGoodsReasonDiv;

        /// <summary>�ԕi���R</summary>
        private string _retGoodsReason = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�[�i�敪</summary>
        /// <remarks>��) 1:�z�B,2:�X���n��,3:����,�c</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�����\���敪�P</summary>
        /// <remarks>�ʏ�@�@0:����@1:�a��</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>���ьv�㋒�_����</summary>
        private string _resultsAddUpSecNm = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";


        /// public propaty name  :  Mode
        /// <summary>�N�����[�h�v���p�e�B</summary>
        /// <value>0:�ʏ�N���A1:QR�t���N��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�����[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// public propaty name  :  AttachedFilePath
        /// <summary>�Y�t�t�@�C���p�X�v���p�e�B</summary>
        /// <value>�Y�t�t�@�C���p�X�i�p�q�R�[�h�̃t�@�C���p�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Y�t�t�@�C���p�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AttachedFilePath
        {
            get { return _attachedFilePath; }
            set { _attachedFilePath = value; }
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

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
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

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  SalesInpSecCd
        /// <summary>������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInpSecCd
        {
            get { return _salesInpSecCd; }
            set { _salesInpSecCd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCd
        /// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DemandAddUpSecCd
        {
            get { return _demandAddUpSecCd; }
            set { _demandAddUpSecCd = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
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

        /// public propaty name  :  ShipmentDay
        /// <summary>�o�ד��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        /// public propaty name  :  ShipmentDayJpFormal
        /// <summary>�o�ד��t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayJpInFormal
        /// <summary>�o�ד��t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdFormal
        /// <summary>�o�ד��t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  ShipmentDayAdInFormal
        /// <summary>�o�ד��t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipmentDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay); }
            set { }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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
        /// <value>���ϓ��A�󒍓��A����������˂�B(YYYYMMDD)</value>
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

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
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

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>�v����t �a��v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>�v����t �a��(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>�v����t ����v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>�v����t ����(��)�v���p�e�B</summary>
        /// <value>�������@(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  EstimateDivide
        /// <summary>���ϋ敪�v���p�e�B</summary>
        /// <value>1:�ʏ팩�ρ@2:�P�����ρ@3:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ϋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateDivide
        {
            get { return _estimateDivide; }
            set { _estimateDivide = value; }
        }

        /// public propaty name  :  InputAgenCd
        /// <summary>���͒S���҃R�[�h�v���p�e�B</summary>
        /// <value>���O�C���S���ҁi�t�r�a�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenCd
        {
            get { return _inputAgenCd; }
            set { _inputAgenCd = value; }
        }

        /// public propaty name  :  InputAgenNm
        /// <summary>���͒S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͒S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputAgenNm
        {
            get { return _inputAgenNm; }
            set { _inputAgenNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  SalesTotalPriceTaxExc
        /// <summary>���㍇�v���z(�Ŕ���)�v���p�e�B</summary>
        /// <value>��ʏ�̔��㍇�v�ɑ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㍇�v���z(�Ŕ���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalPriceTaxExc
        {
            get { return _salesTotalPriceTaxExc; }
            set { _salesTotalPriceTaxExc = value; }
        }

        /// public propaty name  :  SalesPriceConsTaxTotal
        /// <summary>�������Łi���v�j�v���p�e�B</summary>
        /// <value>��ʏ�̏����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������Łi���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPriceConsTaxTotal
        {
            get { return _salesPriceConsTaxTotal; }
            set { _salesPriceConsTaxTotal = value; }
        }

        /// public propaty name  :  SalesTotalPrice
        /// <summary>���㍇�v���z�i�ō��݁j�v���p�e�B</summary>
        /// <value>��ʏ�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㍇�v���z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalPrice
        {
            get { return _salesTotalPrice; }
            set { _salesTotalPrice = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>�������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�</value>
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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  CustSlipNo
        /// <summary>���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  SlipAddressDiv
        /// <summary>�`�[�Z���敪�v���p�e�B</summary>
        /// <value>1:���Ӑ�,2:�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Z���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipAddressDiv
        {
            get { return _slipAddressDiv; }
            set { _slipAddressDiv = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>�[�i��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>�[�i�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>�[�i�於��2�v���p�e�B</summary>
        /// <value>�ǉ�(�o�^�R��) ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  AddresseePostNo
        /// <summary>�[�i��X�֔ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseePostNo
        {
            get { return _addresseePostNo; }
            set { _addresseePostNo = value; }
        }

        /// public propaty name  :  AddresseeAddr1
        /// <summary>�[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��1(�s���{���s��S�E�����E��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr1
        {
            get { return _addresseeAddr1; }
            set { _addresseeAddr1 = value; }
        }

        /// public propaty name  :  AddresseeAddr3
        /// <summary>�[�i��Z��3(�Ԓn)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��3(�Ԓn)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr3
        {
            get { return _addresseeAddr3; }
            set { _addresseeAddr3 = value; }
        }

        /// public propaty name  :  AddresseeAddr4
        /// <summary>�[�i��Z��4(�A�p�[�g����)�v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��Z��4(�A�p�[�g����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeAddr4
        {
            get { return _addresseeAddr4; }
            set { _addresseeAddr4 = value; }
        }

        /// public propaty name  :  AddresseeTelNo
        /// <summary>�[�i��d�b�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeTelNo
        {
            get { return _addresseeTelNo; }
            set { _addresseeTelNo = value; }
        }

        /// public propaty name  :  AddresseeFaxNo
        /// <summary>�[�i��FAX�ԍ��v���p�e�B</summary>
        /// <value>�`�[�Z���敪�ɏ]�����e</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i��FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddresseeFaxNo
        {
            get { return _addresseeFaxNo; }
            set { _addresseeFaxNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>�`�[���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>�`�[���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>�`�[���l�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���l�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  RetGoodsReasonDiv
        /// <summary>�ԕi���R�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsReasonDiv
        {
            get { return _retGoodsReasonDiv; }
            set { _retGoodsReasonDiv = value; }
        }

        /// public propaty name  :  RetGoodsReason
        /// <summary>�ԕi���R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReason
        {
            get { return _retGoodsReason; }
            set { _retGoodsReason = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>��) 1:�z�B,2:�X���n��,3:����,�c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>�ʏ�@�@0:����@1:�a��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// public propaty name  :  ResultsAddUpSecNm
        /// <summary>���ьv�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecNm
        {
            get { return _resultsAddUpSecNm; }
            set { _resultsAddUpSecNm = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }


        /// <summary>
        /// ���[�������l�w�b�_�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>MailDefaultHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultHeader()
        {
        }

        /// <summary>
        /// ���[�������l�w�b�_�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="mode">�N�����[�h(0:�ʏ�N���A1:QR�t���N��)</param>
        /// <param name="attachedFilePath">�Y�t�t�@�C���p�X(�Y�t�t�@�C���p�X�i�p�q�R�[�h�̃t�@�C���p�X�j)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
        /// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi)</param>
        /// <param name="accRecDivCd">���|�敪(0:���|�Ȃ�,1:���|)</param>
        /// <param name="salesInpSecCd">������͋��_�R�[�h(�����^ �������͂������_�R�[�h)</param>
        /// <param name="demandAddUpSecCd">�����v�㋒�_�R�[�h(�����^)</param>
        /// <param name="resultsAddUpSecCd">���ьv�㋒�_�R�[�h(���ьv����s����Ɠ��̋��_�R�[�h)</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
        /// <param name="shipmentDay">�o�ד��t(YYYYMMDD)</param>
        /// <param name="salesDate">������t(���ϓ��A�󒍓��A����������˂�B(YYYYMMDD))</param>
        /// <param name="addUpADate">�v����t(�������@(YYYYMMDD))</param>
        /// <param name="estimateDivide">���ϋ敪(1:�ʏ팩�ρ@2:�P�����ρ@3:��������)</param>
        /// <param name="inputAgenCd">���͒S���҃R�[�h(���O�C���S���ҁi�t�r�a�j)</param>
        /// <param name="inputAgenNm">���͒S���Җ���</param>
        /// <param name="salesInputCode">������͎҃R�[�h(���͒S���ҁi���s�ҁj)</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S���ҁi�󒍎ҁj)</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S���ҁi�S���ҁj)</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="salesTotalPriceTaxExc">���㍇�v���z(�Ŕ���)(��ʏ�̔��㍇�v�ɑ���)</param>
        /// <param name="salesPriceConsTaxTotal">�������Łi���v�j(��ʏ�̏����)</param>
        /// <param name="salesTotalPrice">���㍇�v���z�i�ō��݁j(��ʏ�̍��v���z)</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�)</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="honorificTitle">�h��</param>
        /// <param name="custSlipNo">���Ӑ�`�[�ԍ�</param>
        /// <param name="slipAddressDiv">�`�[�Z���敪(1:���Ӑ�,2:�[����)</param>
        /// <param name="addresseeCode">�[�i��R�[�h</param>
        /// <param name="addresseeName">�[�i�於��</param>
        /// <param name="addresseeName2">�[�i�於��2(�ǉ�(�o�^�R��) ����)</param>
        /// <param name="addresseePostNo">�[�i��X�֔ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr1">�[�i��Z��1(�s���{���s��S�E�����E��)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr3">�[�i��Z��3(�Ԓn)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeAddr4">�[�i��Z��4(�A�p�[�g����)(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeTelNo">�[�i��d�b�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="addresseeFaxNo">�[�i��FAX�ԍ�(�`�[�Z���敪�ɏ]�����e)</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(���Ӑ撍���ԍ��i���`�ԍ��j)</param>
        /// <param name="slipNote">�`�[���l</param>
        /// <param name="slipNote2">�`�[���l�Q</param>
        /// <param name="slipNote3">�`�[���l�R</param>
        /// <param name="retGoodsReasonDiv">�ԕi���R�R�[�h</param>
        /// <param name="retGoodsReason">�ԕi���R</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪(��) 1:�z�B,2:�X���n��,3:����,�c)</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="eraNameDispCd1">�����\���敪�P(�ʏ�@�@0:����@1:�a��)</param>
        /// <param name="resultsAddUpSecNm">���ьv�㋒�_����</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <returns>MailDefaultHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultHeader(Int32 mode, string attachedFilePath, Int32 acptAnOdrStatus, string salesSlipNum, string sectionCode, Int32 subSectionCode, Int32 debitNoteDiv, Int32 salesSlipCd, Int32 accRecDivCd, string salesInpSecCd, string demandAddUpSecCd, string resultsAddUpSecCd, string updateSecCd, DateTime shipmentDay, DateTime salesDate, DateTime addUpADate, Int32 estimateDivide, string inputAgenCd, string inputAgenNm, string salesInputCode, string frontEmployeeCd, string salesEmployeeCd, Int32 totalAmountDispWayCd, Int64 salesTotalPriceTaxExc, Int64 salesPriceConsTaxTotal, Int64 salesTotalPrice, Int64 totalCost, Int32 consTaxLayMethod, Int32 claimCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, string honorificTitle, Int32 custSlipNo, Int32 slipAddressDiv, Int32 addresseeCode, string addresseeName, string addresseeName2, string addresseePostNo, string addresseeAddr1, string addresseeAddr3, string addresseeAddr4, string addresseeTelNo, string addresseeFaxNo, string partySaleSlipNum, string slipNote, string slipNote2, string slipNote3, Int32 retGoodsReasonDiv, string retGoodsReason, Int32 businessTypeCode, Int32 deliveredGoodsDiv, Int32 salesAreaCode, Int32 eraNameDispCd1, string resultsAddUpSecNm, string salesEmployeeNm, string businessTypeName)
        {
            this._mode = mode;
            this._attachedFilePath = attachedFilePath;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._debitNoteDiv = debitNoteDiv;
            this._salesSlipCd = salesSlipCd;
            this._accRecDivCd = accRecDivCd;
            this._salesInpSecCd = salesInpSecCd;
            this._demandAddUpSecCd = demandAddUpSecCd;
            this._resultsAddUpSecCd = resultsAddUpSecCd;
            this._updateSecCd = updateSecCd;
            this.ShipmentDay = shipmentDay;
            this.SalesDate = salesDate;
            this.AddUpADate = addUpADate;
            this._estimateDivide = estimateDivide;
            this._inputAgenCd = inputAgenCd;
            this._inputAgenNm = inputAgenNm;
            this._salesInputCode = salesInputCode;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._salesTotalPriceTaxExc = salesTotalPriceTaxExc;
            this._salesPriceConsTaxTotal = salesPriceConsTaxTotal;
            this._salesTotalPrice = salesTotalPrice;
            this._totalCost = totalCost;
            this._consTaxLayMethod = consTaxLayMethod;
            this._claimCode = claimCode;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._honorificTitle = honorificTitle;
            this._custSlipNo = custSlipNo;
            this._slipAddressDiv = slipAddressDiv;
            this._addresseeCode = addresseeCode;
            this._addresseeName = addresseeName;
            this._addresseeName2 = addresseeName2;
            this._addresseePostNo = addresseePostNo;
            this._addresseeAddr1 = addresseeAddr1;
            this._addresseeAddr3 = addresseeAddr3;
            this._addresseeAddr4 = addresseeAddr4;
            this._addresseeTelNo = addresseeTelNo;
            this._addresseeFaxNo = addresseeFaxNo;
            this._partySaleSlipNum = partySaleSlipNum;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._retGoodsReasonDiv = retGoodsReasonDiv;
            this._retGoodsReason = retGoodsReason;
            this._businessTypeCode = businessTypeCode;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._salesAreaCode = salesAreaCode;
            this._eraNameDispCd1 = eraNameDispCd1;
            this._resultsAddUpSecNm = resultsAddUpSecNm;
            this._salesEmployeeNm = salesEmployeeNm;
            this._businessTypeName = businessTypeName;

        }

        /// <summary>
        /// ���[�������l�w�b�_�f�[�^��������
        /// </summary>
        /// <returns>MailDefaultHeader�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailDefaultHeader�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultHeader Clone()
        {
            return new MailDefaultHeader(this._mode, this._attachedFilePath, this._acptAnOdrStatus, this._salesSlipNum, this._sectionCode, this._subSectionCode, this._debitNoteDiv, this._salesSlipCd, this._accRecDivCd, this._salesInpSecCd, this._demandAddUpSecCd, this._resultsAddUpSecCd, this._updateSecCd, this._shipmentDay, this._salesDate, this._addUpADate, this._estimateDivide, this._inputAgenCd, this._inputAgenNm, this._salesInputCode, this._frontEmployeeCd, this._salesEmployeeCd, this._totalAmountDispWayCd, this._salesTotalPriceTaxExc, this._salesPriceConsTaxTotal, this._salesTotalPrice, this._totalCost, this._consTaxLayMethod, this._claimCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._honorificTitle, this._custSlipNo, this._slipAddressDiv, this._addresseeCode, this._addresseeName, this._addresseeName2, this._addresseePostNo, this._addresseeAddr1, this._addresseeAddr3, this._addresseeAddr4, this._addresseeTelNo, this._addresseeFaxNo, this._partySaleSlipNum, this._slipNote, this._slipNote2, this._slipNote3, this._retGoodsReasonDiv, this._retGoodsReason, this._businessTypeCode, this._deliveredGoodsDiv, this._salesAreaCode, this._eraNameDispCd1, this._resultsAddUpSecNm, this._salesEmployeeNm, this._businessTypeName);
        }

        /// <summary>
        /// ���[�������l�w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailDefaultHeader�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(MailDefaultHeader target)
        {
            return ( ( this.Mode == target.Mode )
                 && ( this.AttachedFilePath == target.AttachedFilePath )
                 && ( this.AcptAnOdrStatus == target.AcptAnOdrStatus )
                 && ( this.SalesSlipNum == target.SalesSlipNum )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.SubSectionCode == target.SubSectionCode )
                 && ( this.DebitNoteDiv == target.DebitNoteDiv )
                 && ( this.SalesSlipCd == target.SalesSlipCd )
                 && ( this.AccRecDivCd == target.AccRecDivCd )
                 && ( this.SalesInpSecCd == target.SalesInpSecCd )
                 && ( this.DemandAddUpSecCd == target.DemandAddUpSecCd )
                 && ( this.ResultsAddUpSecCd == target.ResultsAddUpSecCd )
                 && ( this.UpdateSecCd == target.UpdateSecCd )
                 && ( this.ShipmentDay == target.ShipmentDay )
                 && ( this.SalesDate == target.SalesDate )
                 && ( this.AddUpADate == target.AddUpADate )
                 && ( this.EstimateDivide == target.EstimateDivide )
                 && ( this.InputAgenCd == target.InputAgenCd )
                 && ( this.InputAgenNm == target.InputAgenNm )
                 && ( this.SalesInputCode == target.SalesInputCode )
                 && ( this.FrontEmployeeCd == target.FrontEmployeeCd )
                 && ( this.SalesEmployeeCd == target.SalesEmployeeCd )
                 && ( this.TotalAmountDispWayCd == target.TotalAmountDispWayCd )
                 && ( this.SalesTotalPriceTaxExc == target.SalesTotalPriceTaxExc )
                 && ( this.SalesPriceConsTaxTotal == target.SalesPriceConsTaxTotal )
                 && ( this.SalesTotalPrice == target.SalesTotalPrice )
                 && ( this.TotalCost == target.TotalCost )
                 && ( this.ConsTaxLayMethod == target.ConsTaxLayMethod )
                 && ( this.ClaimCode == target.ClaimCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.CustomerName == target.CustomerName )
                 && ( this.CustomerName2 == target.CustomerName2 )
                 && ( this.CustomerSnm == target.CustomerSnm )
                 && ( this.HonorificTitle == target.HonorificTitle )
                 && ( this.CustSlipNo == target.CustSlipNo )
                 && ( this.SlipAddressDiv == target.SlipAddressDiv )
                 && ( this.AddresseeCode == target.AddresseeCode )
                 && ( this.AddresseeName == target.AddresseeName )
                 && ( this.AddresseeName2 == target.AddresseeName2 )
                 && ( this.AddresseePostNo == target.AddresseePostNo )
                 && ( this.AddresseeAddr1 == target.AddresseeAddr1 )
                 && ( this.AddresseeAddr3 == target.AddresseeAddr3 )
                 && ( this.AddresseeAddr4 == target.AddresseeAddr4 )
                 && ( this.AddresseeTelNo == target.AddresseeTelNo )
                 && ( this.AddresseeFaxNo == target.AddresseeFaxNo )
                 && ( this.PartySaleSlipNum == target.PartySaleSlipNum )
                 && ( this.SlipNote == target.SlipNote )
                 && ( this.SlipNote2 == target.SlipNote2 )
                 && ( this.SlipNote3 == target.SlipNote3 )
                 && ( this.RetGoodsReasonDiv == target.RetGoodsReasonDiv )
                 && ( this.RetGoodsReason == target.RetGoodsReason )
                 && ( this.BusinessTypeCode == target.BusinessTypeCode )
                 && ( this.DeliveredGoodsDiv == target.DeliveredGoodsDiv )
                 && ( this.SalesAreaCode == target.SalesAreaCode )
                 && ( this.EraNameDispCd1 == target.EraNameDispCd1 )
                 && ( this.ResultsAddUpSecNm == target.ResultsAddUpSecNm )
                 && ( this.SalesEmployeeNm == target.SalesEmployeeNm )
                 && ( this.BusinessTypeName == target.BusinessTypeName ) );
        }

        /// <summary>
        /// ���[�������l�w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="mailDefaultHeader1">
        ///                    ��r����MailDefaultHeader�N���X�̃C���X�^���X
        /// </param>
        /// <param name="mailDefaultHeader2">��r����MailDefaultHeader�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(MailDefaultHeader mailDefaultHeader1, MailDefaultHeader mailDefaultHeader2)
        {
            return ( ( mailDefaultHeader1.Mode == mailDefaultHeader2.Mode )
                 && ( mailDefaultHeader1.AttachedFilePath == mailDefaultHeader2.AttachedFilePath )
                 && ( mailDefaultHeader1.AcptAnOdrStatus == mailDefaultHeader2.AcptAnOdrStatus )
                 && ( mailDefaultHeader1.SalesSlipNum == mailDefaultHeader2.SalesSlipNum )
                 && ( mailDefaultHeader1.SectionCode == mailDefaultHeader2.SectionCode )
                 && ( mailDefaultHeader1.SubSectionCode == mailDefaultHeader2.SubSectionCode )
                 && ( mailDefaultHeader1.DebitNoteDiv == mailDefaultHeader2.DebitNoteDiv )
                 && ( mailDefaultHeader1.SalesSlipCd == mailDefaultHeader2.SalesSlipCd )
                 && ( mailDefaultHeader1.AccRecDivCd == mailDefaultHeader2.AccRecDivCd )
                 && ( mailDefaultHeader1.SalesInpSecCd == mailDefaultHeader2.SalesInpSecCd )
                 && ( mailDefaultHeader1.DemandAddUpSecCd == mailDefaultHeader2.DemandAddUpSecCd )
                 && ( mailDefaultHeader1.ResultsAddUpSecCd == mailDefaultHeader2.ResultsAddUpSecCd )
                 && ( mailDefaultHeader1.UpdateSecCd == mailDefaultHeader2.UpdateSecCd )
                 && ( mailDefaultHeader1.ShipmentDay == mailDefaultHeader2.ShipmentDay )
                 && ( mailDefaultHeader1.SalesDate == mailDefaultHeader2.SalesDate )
                 && ( mailDefaultHeader1.AddUpADate == mailDefaultHeader2.AddUpADate )
                 && ( mailDefaultHeader1.EstimateDivide == mailDefaultHeader2.EstimateDivide )
                 && ( mailDefaultHeader1.InputAgenCd == mailDefaultHeader2.InputAgenCd )
                 && ( mailDefaultHeader1.InputAgenNm == mailDefaultHeader2.InputAgenNm )
                 && ( mailDefaultHeader1.SalesInputCode == mailDefaultHeader2.SalesInputCode )
                 && ( mailDefaultHeader1.FrontEmployeeCd == mailDefaultHeader2.FrontEmployeeCd )
                 && ( mailDefaultHeader1.SalesEmployeeCd == mailDefaultHeader2.SalesEmployeeCd )
                 && ( mailDefaultHeader1.TotalAmountDispWayCd == mailDefaultHeader2.TotalAmountDispWayCd )
                 && ( mailDefaultHeader1.SalesTotalPriceTaxExc == mailDefaultHeader2.SalesTotalPriceTaxExc )
                 && ( mailDefaultHeader1.SalesPriceConsTaxTotal == mailDefaultHeader2.SalesPriceConsTaxTotal )
                 && ( mailDefaultHeader1.SalesTotalPrice == mailDefaultHeader2.SalesTotalPrice )
                 && ( mailDefaultHeader1.TotalCost == mailDefaultHeader2.TotalCost )
                 && ( mailDefaultHeader1.ConsTaxLayMethod == mailDefaultHeader2.ConsTaxLayMethod )
                 && ( mailDefaultHeader1.ClaimCode == mailDefaultHeader2.ClaimCode )
                 && ( mailDefaultHeader1.CustomerCode == mailDefaultHeader2.CustomerCode )
                 && ( mailDefaultHeader1.CustomerName == mailDefaultHeader2.CustomerName )
                 && ( mailDefaultHeader1.CustomerName2 == mailDefaultHeader2.CustomerName2 )
                 && ( mailDefaultHeader1.CustomerSnm == mailDefaultHeader2.CustomerSnm )
                 && ( mailDefaultHeader1.HonorificTitle == mailDefaultHeader2.HonorificTitle )
                 && ( mailDefaultHeader1.CustSlipNo == mailDefaultHeader2.CustSlipNo )
                 && ( mailDefaultHeader1.SlipAddressDiv == mailDefaultHeader2.SlipAddressDiv )
                 && ( mailDefaultHeader1.AddresseeCode == mailDefaultHeader2.AddresseeCode )
                 && ( mailDefaultHeader1.AddresseeName == mailDefaultHeader2.AddresseeName )
                 && ( mailDefaultHeader1.AddresseeName2 == mailDefaultHeader2.AddresseeName2 )
                 && ( mailDefaultHeader1.AddresseePostNo == mailDefaultHeader2.AddresseePostNo )
                 && ( mailDefaultHeader1.AddresseeAddr1 == mailDefaultHeader2.AddresseeAddr1 )
                 && ( mailDefaultHeader1.AddresseeAddr3 == mailDefaultHeader2.AddresseeAddr3 )
                 && ( mailDefaultHeader1.AddresseeAddr4 == mailDefaultHeader2.AddresseeAddr4 )
                 && ( mailDefaultHeader1.AddresseeTelNo == mailDefaultHeader2.AddresseeTelNo )
                 && ( mailDefaultHeader1.AddresseeFaxNo == mailDefaultHeader2.AddresseeFaxNo )
                 && ( mailDefaultHeader1.PartySaleSlipNum == mailDefaultHeader2.PartySaleSlipNum )
                 && ( mailDefaultHeader1.SlipNote == mailDefaultHeader2.SlipNote )
                 && ( mailDefaultHeader1.SlipNote2 == mailDefaultHeader2.SlipNote2 )
                 && ( mailDefaultHeader1.SlipNote3 == mailDefaultHeader2.SlipNote3 )
                 && ( mailDefaultHeader1.RetGoodsReasonDiv == mailDefaultHeader2.RetGoodsReasonDiv )
                 && ( mailDefaultHeader1.RetGoodsReason == mailDefaultHeader2.RetGoodsReason )
                 && ( mailDefaultHeader1.BusinessTypeCode == mailDefaultHeader2.BusinessTypeCode )
                 && ( mailDefaultHeader1.DeliveredGoodsDiv == mailDefaultHeader2.DeliveredGoodsDiv )
                 && ( mailDefaultHeader1.SalesAreaCode == mailDefaultHeader2.SalesAreaCode )
                 && ( mailDefaultHeader1.EraNameDispCd1 == mailDefaultHeader2.EraNameDispCd1 )
                 && ( mailDefaultHeader1.ResultsAddUpSecNm == mailDefaultHeader2.ResultsAddUpSecNm )
                 && ( mailDefaultHeader1.SalesEmployeeNm == mailDefaultHeader2.SalesEmployeeNm )
                 && ( mailDefaultHeader1.BusinessTypeName == mailDefaultHeader2.BusinessTypeName ) );
        }
        /// <summary>
        /// ���[�������l�w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailDefaultHeader�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(MailDefaultHeader target)
        {
            ArrayList resList = new ArrayList();
            if (this.Mode != target.Mode) resList.Add("Mode");
            if (this.AttachedFilePath != target.AttachedFilePath) resList.Add("AttachedFilePath");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesInpSecCd != target.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (this.DemandAddUpSecCd != target.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (this.ResultsAddUpSecCd != target.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.ShipmentDay != target.ShipmentDay) resList.Add("ShipmentDay");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.EstimateDivide != target.EstimateDivide) resList.Add("EstimateDivide");
            if (this.InputAgenCd != target.InputAgenCd) resList.Add("InputAgenCd");
            if (this.InputAgenNm != target.InputAgenNm) resList.Add("InputAgenNm");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.SalesTotalPriceTaxExc != target.SalesTotalPriceTaxExc) resList.Add("SalesTotalPriceTaxExc");
            if (this.SalesPriceConsTaxTotal != target.SalesPriceConsTaxTotal) resList.Add("SalesPriceConsTaxTotal");
            if (this.SalesTotalPrice != target.SalesTotalPrice) resList.Add("SalesTotalPrice");
            if (this.TotalCost != target.TotalCost) resList.Add("TotalCost");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.CustSlipNo != target.CustSlipNo) resList.Add("CustSlipNo");
            if (this.SlipAddressDiv != target.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.AddresseeName != target.AddresseeName) resList.Add("AddresseeName");
            if (this.AddresseeName2 != target.AddresseeName2) resList.Add("AddresseeName2");
            if (this.AddresseePostNo != target.AddresseePostNo) resList.Add("AddresseePostNo");
            if (this.AddresseeAddr1 != target.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (this.AddresseeAddr3 != target.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (this.AddresseeAddr4 != target.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (this.AddresseeTelNo != target.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (this.AddresseeFaxNo != target.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            if (this.RetGoodsReasonDiv != target.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (this.RetGoodsReason != target.RetGoodsReason) resList.Add("RetGoodsReason");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.ResultsAddUpSecNm != target.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }

        /// <summary>
        /// ���[�������l�w�b�_�f�[�^��r����
        /// </summary>
        /// <param name="mailDefaultHeader1">��r����MailDefaultHeader�N���X�̃C���X�^���X</param>
        /// <param name="mailDefaultHeader2">��r����MailDefaultHeader�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultHeader�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(MailDefaultHeader mailDefaultHeader1, MailDefaultHeader mailDefaultHeader2)
        {
            ArrayList resList = new ArrayList();
            if (mailDefaultHeader1.Mode != mailDefaultHeader2.Mode) resList.Add("Mode");
            if (mailDefaultHeader1.AttachedFilePath != mailDefaultHeader2.AttachedFilePath) resList.Add("AttachedFilePath");
            if (mailDefaultHeader1.AcptAnOdrStatus != mailDefaultHeader2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (mailDefaultHeader1.SalesSlipNum != mailDefaultHeader2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (mailDefaultHeader1.SectionCode != mailDefaultHeader2.SectionCode) resList.Add("SectionCode");
            if (mailDefaultHeader1.SubSectionCode != mailDefaultHeader2.SubSectionCode) resList.Add("SubSectionCode");
            if (mailDefaultHeader1.DebitNoteDiv != mailDefaultHeader2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (mailDefaultHeader1.SalesSlipCd != mailDefaultHeader2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (mailDefaultHeader1.AccRecDivCd != mailDefaultHeader2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (mailDefaultHeader1.SalesInpSecCd != mailDefaultHeader2.SalesInpSecCd) resList.Add("SalesInpSecCd");
            if (mailDefaultHeader1.DemandAddUpSecCd != mailDefaultHeader2.DemandAddUpSecCd) resList.Add("DemandAddUpSecCd");
            if (mailDefaultHeader1.ResultsAddUpSecCd != mailDefaultHeader2.ResultsAddUpSecCd) resList.Add("ResultsAddUpSecCd");
            if (mailDefaultHeader1.UpdateSecCd != mailDefaultHeader2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (mailDefaultHeader1.ShipmentDay != mailDefaultHeader2.ShipmentDay) resList.Add("ShipmentDay");
            if (mailDefaultHeader1.SalesDate != mailDefaultHeader2.SalesDate) resList.Add("SalesDate");
            if (mailDefaultHeader1.AddUpADate != mailDefaultHeader2.AddUpADate) resList.Add("AddUpADate");
            if (mailDefaultHeader1.EstimateDivide != mailDefaultHeader2.EstimateDivide) resList.Add("EstimateDivide");
            if (mailDefaultHeader1.InputAgenCd != mailDefaultHeader2.InputAgenCd) resList.Add("InputAgenCd");
            if (mailDefaultHeader1.InputAgenNm != mailDefaultHeader2.InputAgenNm) resList.Add("InputAgenNm");
            if (mailDefaultHeader1.SalesInputCode != mailDefaultHeader2.SalesInputCode) resList.Add("SalesInputCode");
            if (mailDefaultHeader1.FrontEmployeeCd != mailDefaultHeader2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (mailDefaultHeader1.SalesEmployeeCd != mailDefaultHeader2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (mailDefaultHeader1.TotalAmountDispWayCd != mailDefaultHeader2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (mailDefaultHeader1.SalesTotalPriceTaxExc != mailDefaultHeader2.SalesTotalPriceTaxExc) resList.Add("SalesTotalPriceTaxExc");
            if (mailDefaultHeader1.SalesPriceConsTaxTotal != mailDefaultHeader2.SalesPriceConsTaxTotal) resList.Add("SalesPriceConsTaxTotal");
            if (mailDefaultHeader1.SalesTotalPrice != mailDefaultHeader2.SalesTotalPrice) resList.Add("SalesTotalPrice");
            if (mailDefaultHeader1.TotalCost != mailDefaultHeader2.TotalCost) resList.Add("TotalCost");
            if (mailDefaultHeader1.ConsTaxLayMethod != mailDefaultHeader2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (mailDefaultHeader1.ClaimCode != mailDefaultHeader2.ClaimCode) resList.Add("ClaimCode");
            if (mailDefaultHeader1.CustomerCode != mailDefaultHeader2.CustomerCode) resList.Add("CustomerCode");
            if (mailDefaultHeader1.CustomerName != mailDefaultHeader2.CustomerName) resList.Add("CustomerName");
            if (mailDefaultHeader1.CustomerName2 != mailDefaultHeader2.CustomerName2) resList.Add("CustomerName2");
            if (mailDefaultHeader1.CustomerSnm != mailDefaultHeader2.CustomerSnm) resList.Add("CustomerSnm");
            if (mailDefaultHeader1.HonorificTitle != mailDefaultHeader2.HonorificTitle) resList.Add("HonorificTitle");
            if (mailDefaultHeader1.CustSlipNo != mailDefaultHeader2.CustSlipNo) resList.Add("CustSlipNo");
            if (mailDefaultHeader1.SlipAddressDiv != mailDefaultHeader2.SlipAddressDiv) resList.Add("SlipAddressDiv");
            if (mailDefaultHeader1.AddresseeCode != mailDefaultHeader2.AddresseeCode) resList.Add("AddresseeCode");
            if (mailDefaultHeader1.AddresseeName != mailDefaultHeader2.AddresseeName) resList.Add("AddresseeName");
            if (mailDefaultHeader1.AddresseeName2 != mailDefaultHeader2.AddresseeName2) resList.Add("AddresseeName2");
            if (mailDefaultHeader1.AddresseePostNo != mailDefaultHeader2.AddresseePostNo) resList.Add("AddresseePostNo");
            if (mailDefaultHeader1.AddresseeAddr1 != mailDefaultHeader2.AddresseeAddr1) resList.Add("AddresseeAddr1");
            if (mailDefaultHeader1.AddresseeAddr3 != mailDefaultHeader2.AddresseeAddr3) resList.Add("AddresseeAddr3");
            if (mailDefaultHeader1.AddresseeAddr4 != mailDefaultHeader2.AddresseeAddr4) resList.Add("AddresseeAddr4");
            if (mailDefaultHeader1.AddresseeTelNo != mailDefaultHeader2.AddresseeTelNo) resList.Add("AddresseeTelNo");
            if (mailDefaultHeader1.AddresseeFaxNo != mailDefaultHeader2.AddresseeFaxNo) resList.Add("AddresseeFaxNo");
            if (mailDefaultHeader1.PartySaleSlipNum != mailDefaultHeader2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (mailDefaultHeader1.SlipNote != mailDefaultHeader2.SlipNote) resList.Add("SlipNote");
            if (mailDefaultHeader1.SlipNote2 != mailDefaultHeader2.SlipNote2) resList.Add("SlipNote2");
            if (mailDefaultHeader1.SlipNote3 != mailDefaultHeader2.SlipNote3) resList.Add("SlipNote3");
            if (mailDefaultHeader1.RetGoodsReasonDiv != mailDefaultHeader2.RetGoodsReasonDiv) resList.Add("RetGoodsReasonDiv");
            if (mailDefaultHeader1.RetGoodsReason != mailDefaultHeader2.RetGoodsReason) resList.Add("RetGoodsReason");
            if (mailDefaultHeader1.BusinessTypeCode != mailDefaultHeader2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (mailDefaultHeader1.DeliveredGoodsDiv != mailDefaultHeader2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (mailDefaultHeader1.SalesAreaCode != mailDefaultHeader2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (mailDefaultHeader1.EraNameDispCd1 != mailDefaultHeader2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (mailDefaultHeader1.ResultsAddUpSecNm != mailDefaultHeader2.ResultsAddUpSecNm) resList.Add("ResultsAddUpSecNm");
            if (mailDefaultHeader1.SalesEmployeeNm != mailDefaultHeader2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (mailDefaultHeader1.BusinessTypeName != mailDefaultHeader2.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }
    }
}
