using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMInquiryResultWork
    /// <summary>
    ///                      SCM�₢���킹�ꗗ���o����(�`�[)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�₢���킹�ꗗ���o����(�`�[)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   ���ڒǉ�</br>
    /// <br>Programmer       :   ����</br>
    /// <br>Date             :   2010/06/17</br>
    /// <br>Update Note      :   ���ڒǉ�</br>
    /// <br>Programmer       :   �v�ۓc</br>
    /// <br>Date             :   2011/05/26</br>
    /// <br>Update Note      :   ���ڒǉ�</br>
    /// <br>Programmer       :   ������</br>
    /// <br>Date             :   2011/11/12</br>
    /// <br>Update Note      :   2012/11/14�z�M�\�� SCM��Q��176�Ή��F���ڒǉ�</br>
    /// <br>Programmer       :   ���� ����q</br>
    /// <br>Date             :   2012/10/10</br>
    /// <br>Update Note      :   SCM��Q��10384�Ή��F���ڒǉ�</br>
    /// <br>Programmer       :   ���� ����q</br>
    /// <br>Date             :   2013/05/13</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryResultWork
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _salesSlipNum = "";

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�⍇���ԍ�</summary>
        private Int64 _inquiryNumber;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>�X�V����</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>�⍇���E�������</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        private Int32 _inqOrdDivCd;

        /// <summary>�񓚋敪</summary>
        /// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
        private Int32 _answerDivCd;

        /// <summary>�m���</summary>
        /// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
        private Int32 _judgementDate;

        /// <summary>�⍇���E�������l</summary>
        private string _inqOrdNote = "";

        /// <summary>�⍇���]�ƈ��R�[�h</summary>
        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
        private string _inqEmployeeCd = "";

        /// <summary>�⍇���]�ƈ�����</summary>
        /// <remarks>�⍇�������]�ƈ�����</remarks>
        private string _inqEmployeeNm = "";

        /// <summary>�񓚏]�ƈ��R�[�h</summary>
        private string _ansEmployeeCd = "";

        /// <summary>�񓚏]�ƈ�����</summary>
        private string _ansEmployeeNm = "";

        /// <summary>�⍇����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _inquiryDate;

        /// <summary>���^�������ԍ�</summary>
        private Int32 _numberPlate1Code;

        /// <summary>���^�����ǖ���</summary>
        private string _numberPlate1Name = "";

        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
        private string _numberPlate2 = "";

        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _numberPlate3 = "";

        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private Int32 _numberPlate4;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ햼</summary>
        private string _modelName = "";

        /// <summary>�Ԍ��،^��</summary>
        private string _carInspectCertModel = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�ԑ�ԍ�</summary>
        private string _frameNo = "";

        /// <summary>�ԑ�^��</summary>
        private string _frameModel = "";

        /// <summary>�V���V�[No</summary>
        private string _chassisNo = "";

        /// <summary>�ԗ��ŗL�ԍ�</summary>
        /// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
        private Int32 _carProperNo;

        /// <summary>���Y�N���iNUM�^�C�v�j</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _produceTypeOfYearNum;

        /// <summary>�⍇����(�ԗ����)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _inquiryDate_Car;

        /// <summary>�⍇���]�ƈ��R�[�h(�ԗ����)</summary>
        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
        private string _inqEmployeeCd_Car = "";

        /// <summary>�⍇���]�ƈ�����(�ԗ����)</summary>
        /// <remarks>�⍇�������]�ƈ�����</remarks>
        private string _inqEmployeeNm_Car = "";

        /// <summary>������(�ԗ����)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _salesOrderDate_Car;

        /// <summary>�����ҏ]�ƈ��R�[�h</summary>
        /// <remarks>���������]�ƈ��R�[�h</remarks>
        private string _salesOrderEmployeeCd = "";

        /// <summary>�����ҏ]�ƈ�����</summary>
        /// <remarks>���������]�ƈ�����</remarks>
        private string _salesOrderEmployeeNm = "";

        /// <summary>�R�����g</summary>
        /// <remarks>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</remarks>
        private string _comment = "";

        /// <summary>���y�A�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</remarks>
        private string _rpColorCode = "";

        /// <summary>�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _colorName1 = "";

        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>�g��������</summary>
        private string _trimName = "";

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�񓚕��@</summary>
        private Int32 _awnserMethod;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _salesTotalTaxInc;

        // -- ADD 2010/06/17 ----------->>>
        /// <summary>�L�����Z���敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        private Int16 _cancelDiv;

        /// <summary>CMT�A�g�敪</summary>
        /// <remarks>0:�A�g�Ȃ� 1:�A�g����</remarks>
        private Int16 _cMTCooprtDiv;
        // -- ADD 2010/06/17 -----------<<<

        //--- ADD 2011/05/26 --->>>
        /// <summary>SF-PM�A�g�w�����ԍ�</summary>
        /// <remarks>���Ӑ撍��</remarks>
        private string _sfPmCprtInstSlipNo;
        //--- ADD 2011/05/26 ---<<<

        //--- ADD gezh 2011/11/12 --->>>>>
        /// <summary>�A�g�Ώۋ敪</summary>
        private Int16 _cooperationOptionDiv;
        //--- ADD gezh 2011/11/12 ---<<<<<

        //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ---------->>>>>
        /// <summary>�񓚕��@�����i�����񓚕��j</summary>
        private Int32 _autoAnswerCount;

        /// <summary>�񓚕��@�����i�蓮�񓚕��j</summary>
        private Int32 _manualAnswerCount;
        //--- ADD 2012/10/10 2012/11/14�z�M�\�� SCM��Q��176�Ή� ----------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// <summary>���ɗ\���</summary>
        private Int32 _expectedCeDate;
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InquiryNumber
        /// <summary>�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V���ԃv���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>1:�⍇�� 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  AnswerDivCd
        /// <summary>�񓚋敪�v���p�e�B</summary>
        /// <value>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnswerDivCd
        {
            get { return _answerDivCd; }
            set { _answerDivCd = value; }
        }

        /// public propaty name  :  JudgementDate
        /// <summary>�m����v���p�e�B</summary>
        /// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �m����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JudgementDate
        {
            get { return _judgementDate; }
            set { _judgementDate = value; }
        }

        /// public propaty name  :  InqOrdNote
        /// <summary>�⍇���E�������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E�������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOrdNote
        {
            get { return _inqOrdNote; }
            set { _inqOrdNote = value; }
        }

        /// public propaty name  :  InqEmployeeCd
        /// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeCd
        {
            get { return _inqEmployeeCd; }
            set { _inqEmployeeCd = value; }
        }

        /// public propaty name  :  InqEmployeeNm
        /// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeNm
        {
            get { return _inqEmployeeNm; }
            set { _inqEmployeeNm = value; }
        }

        /// public propaty name  :  AnsEmployeeCd
        /// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsEmployeeCd
        {
            get { return _ansEmployeeCd; }
            set { _ansEmployeeCd = value; }
        }

        /// public propaty name  :  AnsEmployeeNm
        /// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsEmployeeNm
        {
            get { return _ansEmployeeNm; }
            set { _ansEmployeeNm = value; }
        }

        /// public propaty name  :  InquiryDate
        /// <summary>�⍇�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InquiryDate
        {
            get { return _inquiryDate; }
            set { _inquiryDate = value; }
        }

        /// public propaty name  :  NumberPlate1Code
        /// <summary>���^�������ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�������ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>���^�����ǖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>�Ԏ햼�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  CarInspectCertModel
        /// <summary>�Ԍ��،^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ��،^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarInspectCertModel
        {
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  FrameModel
        /// <summary>�ԑ�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameModel
        {
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  ChassisNo
        /// <summary>�V���V�[No�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���V�[No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChassisNo
        {
            get { return _chassisNo; }
            set { _chassisNo = value; }
        }

        /// public propaty name  :  CarProperNo
        /// <summary>�ԗ��ŗL�ԍ��v���p�e�B</summary>
        /// <value>���j�[�N�ȌŒ�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��ŗL�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarProperNo
        {
            get { return _carProperNo; }
            set { _carProperNo = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNum
        /// <summary>���Y�N���iNUM�^�C�v�j�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�N���iNUM�^�C�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearNum
        {
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
        }

        /// public propaty name  :  InquiryDate_Car
        /// <summary>�⍇����(�ԗ����)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇����(�ԗ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InquiryDate_Car
        {
            get { return _inquiryDate_Car; }
            set { _inquiryDate_Car = value; }
        }

        /// public propaty name  :  InqEmployeeCd_Car
        /// <summary>�⍇���]�ƈ��R�[�h(�ԗ����)�v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ��R�[�h(�ԗ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeCd_Car
        {
            get { return _inqEmployeeCd_Car; }
            set { _inqEmployeeCd_Car = value; }
        }

        /// public propaty name  :  InqEmployeeNm_Car
        /// <summary>�⍇���]�ƈ�����(�ԗ����)�v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ�����(�ԗ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeNm_Car
        {
            get { return _inqEmployeeNm_Car; }
            set { _inqEmployeeNm_Car = value; }
        }

        /// public propaty name  :  SalesOrderDate_Car
        /// <summary>������(�ԗ����)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������(�ԗ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDate_Car
        {
            get { return _salesOrderDate_Car; }
            set { _salesOrderDate_Car = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeCd
        /// <summary>�����ҏ]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���������]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ҏ]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderEmployeeCd
        {
            get { return _salesOrderEmployeeCd; }
            set { _salesOrderEmployeeCd = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeNm
        /// <summary>�����ҏ]�ƈ����̃v���p�e�B</summary>
        /// <value>���������]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ҏ]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderEmployeeNm
        {
            get { return _salesOrderEmployeeNm; }
            set { _salesOrderEmployeeNm = value; }
        }

        /// public propaty name  :  Comment
        /// <summary>�R�����g�v���p�e�B</summary>
        /// <value>�J�^���O�̃R�����g��P�ʁE�J���[���i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        /// public propaty name  :  RpColorCode
        /// <summary>���y�A�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h�i���y�A�p���V�Ԏ��ƈقȂ�ꍇ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���y�A�J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RpColorCode
        {
            get { return _rpColorCode; }
            set { _rpColorCode = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>�J���[����1�v���p�e�B</summary>
        /// <value>��ʕ\���p��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>�g�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>�ԗ����s�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ����s�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
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

        /// public propaty name  :  AwnserMethod
        /// <summary>�񓚕��@�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AwnserMethod
        {
            get { return _awnserMethod; }
            set { _awnserMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        // -- ADD 2010/06/17 ----------------------------->>>
        /// public propaty name  :  CancelDiv
        /// <summary>�L�����Z���敪�v���p�e�B</summary>
        /// <value>0:�L�����Z���Ȃ� 1:�L�����Z������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����Z���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// public propaty name  :  CMTCooprtDiv
        /// <summary>CMT�A�g�敪�v���p�e�B</summary>
        /// <value>0:�A�g�Ȃ� 1:�A�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CMT�A�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CMTCooprtDiv
        {
            get { return _cMTCooprtDiv; }
            set { _cMTCooprtDiv = value; }
        }
        // -- ADD 2010/06/17 -----------------------------<<<

        //--- ADD 2011/05/26 ----------------------------->>>
        /// public propaty name  :  SfPmCprtInstSlipNo
        /// <summary>SF-PM�A�g�w�����ԍ��v���p�e�B</summary>
        /// <value>0:�A�g�Ȃ� 1:�A�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF-PM�A�g�w�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SfPmCprtInstSlipNo
        {
            get { return _sfPmCprtInstSlipNo; }
            set { _sfPmCprtInstSlipNo = value; }
        }

        //--- ADD 2011/05/26 -----------------------------<<<

        //--- ADD gezh 2011/11/12 ----------------------------->>>>>
        /// public propaty name  :  CooperationOptionDiv
        /// <summary>�񓚕��@�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��@�v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public Int16 CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }
        //--- ADD gezh 2011/11/12 -----------------------------<<<<<

        //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ---------->>>>>
        /// public propaty name  :  AutoAnswerCount
        /// <summary>�񓚕��@�����i�����񓚕��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��@�����i�����񓚕��j�v���p�e�B</br>
        /// </remarks>
        public Int32 AutoAnswerCount
        {
            get { return _autoAnswerCount; }
            set { _autoAnswerCount = value; }
        }

        /// public propaty name  :  ManualAnswerCount
        /// <summary>�񓚕��@�����i�蓮�񓚕��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��@�����i�蓮�񓚕��j�v���p�e�B</br>
        /// </remarks>
        public Int32 ManualAnswerCount
        {
            get { return _manualAnswerCount; }
            set { _manualAnswerCount = value; }
        }

        //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ----------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// public propaty name  :  ExpectedCeDate
        /// <summary>���ɗ\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɗ\����v���p�e�B</br>
        /// </remarks>
        public Int32 ExpectedCeDate
        {
            get { return _expectedCeDate; }
            set { _expectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

        /// <summary>
        /// SCM�₢���킹�ꗗ���o����(�`�[)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMInquiryResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMInquiryResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMInquiryResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMInquiryResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMInquiryResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMInquiryResultWork || graph is ArrayList || graph is SCMInquiryResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMInquiryResultWork).FullName));

            if (graph != null && graph is SCMInquiryResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMInquiryResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMInquiryResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMInquiryResultWork[])graph).Length;
            }
            else if (graph is SCMInquiryResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //�񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //�m���
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //�⍇���E�������l
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //�⍇���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //�⍇���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //�񓚏]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //�񓚏]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //�⍇����
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //���^�������ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //���^�����ǖ���
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //�ԗ��o�^�ԍ��i��ʁj
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //�ԗ��o�^�ԍ��i�J�i�j
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //�Ԏ햼
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //�Ԍ��،^��
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //�ԑ�^��
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //�V���V�[No
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //�ԗ��ŗL�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //���Y�N���iNUM�^�C�v�j
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //�⍇����(�ԗ����)
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate_Car
            //�⍇���]�ƈ��R�[�h(�ԗ����)
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd_Car
            //�⍇���]�ƈ�����(�ԗ����)
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm_Car
            //������(�ԗ����)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDate_Car
            //�����ҏ]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderEmployeeCd
            //�����ҏ]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //SalesOrderEmployeeNm
            //�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //���y�A�J���[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //�J���[����1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //�g�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //�g��������
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //�ԗ����s����
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�񓚕��@
            serInfo.MemberInfo.Add(typeof(Int32)); //AwnserMethod
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            // -- ADD 2010/06/17 ---------->>>
            //�L�����Z���敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelDiv
            //CMT�A�g�敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CMTCooprtDiv
            // -- ADD 2010/06/17 ----------<<<
            //SF-PM�A�g�w�����ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SfPmCprtInstSlipNo
            // -- ADD gezh 2011/11/12 ---------->>>>>
            // �A�g�Ώۋ敪
            serInfo.MemberInfo.Add(typeof(Int16)); // CooperationOptionDiv
            // -- ADD gezh 2011/11/12 ----------<<<<<

            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ---------->>>>>
            // �񓚕��@�����i�����񓚕��j
            serInfo.MemberInfo.Add(typeof(Int32)); // AutoAnswerCount
            // �񓚕��@�����i�蓮�񓚕��j
            serInfo.MemberInfo.Add(typeof(Int32)); // ManualAnswerCount
            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ----------<<<<<

            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            serInfo.MemberInfo.Add(typeof(Int32)); // ExpectedCeDate
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMInquiryResultWork)
            {
                SCMInquiryResultWork temp = (SCMInquiryResultWork)graph;

                SetSCMInquiryResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMInquiryResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMInquiryResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMInquiryResultWork temp in lst)
                {
                    SetSCMInquiryResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMInquiryResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        // -- UPD 2010/06/17 ------------------------>>>
        //private const int currentMemberCount = 53;
        //private const int currentMemberCount = 55;  //DEL 2011/05/26
        //private const int currentMemberCount = 56;    //ADD 2011/05/26 //DEL 2011/11/12
        //--- UPD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ---------->>>>>
        //private const int currentMemberCount = 57;    // ADD 2011/11/12
        // UPD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        //private const int currentMemberCount = 59;
        private const int currentMemberCount = 60;
        // UPD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        //--- UPD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ----------<<<<<
        // -- UPD 2010/06/17 ------------------------<<<

        /// <summary>
        ///  SCMInquiryResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMInquiryResultWork(System.IO.BinaryWriter writer, SCMInquiryResultWork temp)
        {
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //�񓚋敪
            writer.Write(temp.AnswerDivCd);
            //�m���
            writer.Write(temp.JudgementDate);
            //�⍇���E�������l
            writer.Write(temp.InqOrdNote);
            //�⍇���]�ƈ��R�[�h
            writer.Write(temp.InqEmployeeCd);
            //�⍇���]�ƈ�����
            writer.Write(temp.InqEmployeeNm);
            //�񓚏]�ƈ��R�[�h
            writer.Write(temp.AnsEmployeeCd);
            //�񓚏]�ƈ�����
            writer.Write(temp.AnsEmployeeNm);
            //�⍇����
            writer.Write(temp.InquiryDate);
            //���^�������ԍ�
            writer.Write(temp.NumberPlate1Code);
            //���^�����ǖ���
            writer.Write(temp.NumberPlate1Name);
            //�ԗ��o�^�ԍ��i��ʁj
            writer.Write(temp.NumberPlate2);
            //�ԗ��o�^�ԍ��i�J�i�j
            writer.Write(temp.NumberPlate3);
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            writer.Write(temp.NumberPlate4);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //�Ԏ�R�[�h
            writer.Write(temp.ModelCode);
            //�Ԏ�T�u�R�[�h
            writer.Write(temp.ModelSubCode);
            //�Ԏ햼
            writer.Write(temp.ModelName);
            //�Ԍ��،^��
            writer.Write(temp.CarInspectCertModel);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�ԑ�ԍ�
            writer.Write(temp.FrameNo);
            //�ԑ�^��
            writer.Write(temp.FrameModel);
            //�V���V�[No
            writer.Write(temp.ChassisNo);
            //�ԗ��ŗL�ԍ�
            writer.Write(temp.CarProperNo);
            //���Y�N���iNUM�^�C�v�j
            writer.Write(temp.ProduceTypeOfYearNum);
            //�⍇����(�ԗ����)
            writer.Write(temp.InquiryDate_Car);
            //�⍇���]�ƈ��R�[�h(�ԗ����)
            writer.Write(temp.InqEmployeeCd_Car);
            //�⍇���]�ƈ�����(�ԗ����)
            writer.Write(temp.InqEmployeeNm_Car);
            //������(�ԗ����)
            writer.Write(temp.SalesOrderDate_Car);
            //�����ҏ]�ƈ��R�[�h
            writer.Write(temp.SalesOrderEmployeeCd);
            //�����ҏ]�ƈ�����
            writer.Write(temp.SalesOrderEmployeeNm);
            //�R�����g
            writer.Write(temp.Comment);
            //���y�A�J���[�R�[�h
            writer.Write(temp.RpColorCode);
            //�J���[����1
            writer.Write(temp.ColorName1);
            //�g�����R�[�h
            writer.Write(temp.TrimCode);
            //�g��������
            writer.Write(temp.TrimName);
            //�ԗ����s����
            writer.Write(temp.Mileage);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�񓚕��@
            writer.Write(temp.AwnserMethod);
            //����`�[���v�i�ō��݁j
            writer.Write(temp.SalesTotalTaxInc);
            // -- ADD 2010/06/17 -------------->>>
            //�L�����Z���敪
            writer.Write(temp.CancelDiv);
            //CMT�A�g�敪
            writer.Write(temp.CMTCooprtDiv);
            // -- ADD 2010/06/17 --------------<<<
            //SF-PM�A�g�w�����ԍ�
            writer.Write(temp.SfPmCprtInstSlipNo);  //ADD 2011/05/26
            // ADD gezh 2011/11/12 -------------->>>>>
            // �A�g�Ώۋ敪
            writer.Write(temp.CooperationOptionDiv);
            // ADD gezh 2011/11/12 --------------<<<<<
            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ---------->>>>>
            // �񓚕��@�����i�����񓚕��j
            writer.Write(temp.AutoAnswerCount);
            // �񓚕��@�����i�蓮�񓚕��j
            writer.Write(temp.ManualAnswerCount);
            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ----------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            // ���ɗ\���
            writer.Write(temp.ExpectedCeDate);
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        }

        /// <summary>
        ///  SCMInquiryResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMInquiryResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMInquiryResultWork GetSCMInquiryResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMInquiryResultWork temp = new SCMInquiryResultWork();

            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //�񓚋敪
            temp.AnswerDivCd = reader.ReadInt32();
            //�m���
            temp.JudgementDate = reader.ReadInt32();
            //�⍇���E�������l
            temp.InqOrdNote = reader.ReadString();
            //�⍇���]�ƈ��R�[�h
            temp.InqEmployeeCd = reader.ReadString();
            //�⍇���]�ƈ�����
            temp.InqEmployeeNm = reader.ReadString();
            //�񓚏]�ƈ��R�[�h
            temp.AnsEmployeeCd = reader.ReadString();
            //�񓚏]�ƈ�����
            temp.AnsEmployeeNm = reader.ReadString();
            //�⍇����
            temp.InquiryDate = reader.ReadInt32();
            //���^�������ԍ�
            temp.NumberPlate1Code = reader.ReadInt32();
            //���^�����ǖ���
            temp.NumberPlate1Name = reader.ReadString();
            //�ԗ��o�^�ԍ��i��ʁj
            temp.NumberPlate2 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�J�i�j
            temp.NumberPlate3 = reader.ReadString();
            //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            temp.NumberPlate4 = reader.ReadInt32();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�Ԏ햼
            temp.ModelName = reader.ReadString();
            //�Ԍ��،^��
            temp.CarInspectCertModel = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�ԑ�^��
            temp.FrameModel = reader.ReadString();
            //�V���V�[No
            temp.ChassisNo = reader.ReadString();
            //�ԗ��ŗL�ԍ�
            temp.CarProperNo = reader.ReadInt32();
            //���Y�N���iNUM�^�C�v�j
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //�⍇����(�ԗ����)
            temp.InquiryDate_Car = reader.ReadInt32();
            //�⍇���]�ƈ��R�[�h(�ԗ����)
            temp.InqEmployeeCd_Car = reader.ReadString();
            //�⍇���]�ƈ�����(�ԗ����)
            temp.InqEmployeeNm_Car = reader.ReadString();
            //������(�ԗ����)
            temp.SalesOrderDate_Car = reader.ReadInt32();
            //�����ҏ]�ƈ��R�[�h
            temp.SalesOrderEmployeeCd = reader.ReadString();
            //�����ҏ]�ƈ�����
            temp.SalesOrderEmployeeNm = reader.ReadString();
            //�R�����g
            temp.Comment = reader.ReadString();
            //���y�A�J���[�R�[�h
            temp.RpColorCode = reader.ReadString();
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�񓚕��@
            temp.AwnserMethod = reader.ReadInt32();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            // -- UPD 2010/06/17 ------------------------->>>
            //�L�����Z���敪
            temp.CancelDiv = reader.ReadInt16();
            //CMT�A�g�敪
            temp.CMTCooprtDiv = reader.ReadInt16();
            // -- UPD 2010/06/17 -------------------------<<<
            //SF-PM�A�g�w�����ԍ�
            temp.SfPmCprtInstSlipNo = reader.ReadString();  //ADD 2011/05/26
            // ADD gezh 2011/11/12 ----------------------->>>>>
            // �A�g�Ώۋ敪
            temp.CooperationOptionDiv = reader.ReadInt16();
            // ADD gezh 2011/11/12 -----------------------<<<<<
            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ---------->>>>>
            // �񓚕��@�����i�����񓚕��j
            temp.AutoAnswerCount = reader.ReadInt32();
            // �񓚕��@�����i�蓮�񓚕��j
            temp.ManualAnswerCount = reader.ReadInt32();
            //--- ADD 2012/10/10 2012/11/14�z�M�\��  SCM��Q��176�Ή� ----------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            // ���ɗ\���
            temp.ExpectedCeDate = reader.ReadInt32();
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

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
        /// <returns>SCMInquiryResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMInquiryResultWork temp = GetSCMInquiryResultWork(reader, serInfo);
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
                    retValue = (SCMInquiryResultWork[])lst.ToArray(typeof(SCMInquiryResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
