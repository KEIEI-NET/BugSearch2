using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [SalesSlipHeaderCopyData]
    /// <summary>
    /// ���o�\�t���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���o���ʁ��\�t�̓��e��ێ�����f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.08.10</br>
    /// <br></br>
    /// <br>Update Note  : 2009/09/08 ���M</br>
    /// <br>               PM.NS-2-A�E���q�Ǘ�</br>
    /// <br>               �ԗ����s�����A���q���l�A���^�������ԍ��A���^�����ǖ��̂̒ǉ�</br>
    /// <br>               �ԗ��o�^�ԍ��i��ʁj�A�ԗ��o�^�ԍ��i�J�i�j�A�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�̒ǉ�</br>
    /// <br>Update Note  : 2010/04/02 ��� ���b</br>
    /// <br>               �yMANTIS:0015240�z���o�\�t�̏C���Ή��i�Ԏ햼�J�i�j</br>
    /// <br>Update Note  : 2010/04/27 gaoyh</br>
    /// <br>               �󒍃}�X�^�i�ԗ��j���R�����^���Œ�ԍ��z��̒ǉ��Ή�</br>
    /// <br>Update Note: 2013/03/21 FSI���� ���T</br>
    /// <br>�Ǘ��ԍ�   : 10900269-00</br>
    /// <br>             SPK�ԑ�ԍ�������Ή�</br>   
    /// </remarks>
    [Serializable]
    public class SalesSlipHeaderCopyData
    {
        /// <summary>�󒍃X�e�[�^�X</summary>
        private int _acptAnOdrStatus;
        /// <summary>����`�[�敪</summary>
        private int _salesSlipCd;
        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";
        /// <summary>����s�ԍ�</summary>
        private int _salesRowNo;
        /// <summary>������t</summary>
        private int _salesDate;
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";
        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCode;
        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";
        /// <summary>�󒍎҃R�[�h</summary>
        private string _frontEmployeeCd;
        /// <summary>���s�҃R�[�h</summary>
        private string _salesInputCode;
        /// <summary>���q�Ǘ��ԍ�</summary>
        private string _carMngCode = "";
        /// <summary>���q�Ǘ�SEQ</summary>
        private int _carMngNo;
        /// <summary>�^���w��ԍ�</summary>
        private int _modelDesignationNo;
        /// <summary>�ޕʔԍ�</summary>
        private int _categoryNo;
        /// <summary>���[�J�[�R�[�h</summary>
        private int _makerCode;
        /// <summary>�Ԏ�R�[�h</summary>
        private int _modelCode;
        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private int _modelSubCode;
        /// <summary>�Ԏ햼��</summary>
        private string _modelFullName = "";
        /// <summary>�^���i�t���^���j</summary>
        private string _fullModel = "";
        /// <summary>�G���W���^��</summary>
        private string _engineModelNm = "";
        /// <summary>�N��</summary>
        private int _firstEntryDate;
        /// <summary>�ԑ�ԍ�</summary>
        private string _frameNo = "";
        /// <summary>�J���[�R�[�h</summary>
        private string _colorCode = "";
        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";
        /// <summary>�`�[���l�P</summary>
        private string _slipNote = "";
        /// <summary>�`�[���l�Q</summary>
        private string _slipNote2 = "";
        /// <summary>�`�[���l�R</summary>
        private string _slipNote3 = "";
        /// <summary>�[����R�[�h</summary>
        private int _addresseeCode;
        /// <summary>�[���於�̂P</summary>
        private string _addresseeName = "";
        /// <summary>�[���於�̂Q</summary>
        private string _addresseeName2 = "";
        /// <summary>�[�i�敪</summary>
        private int _deliveredGoodsDiv;
        /// <summary>���`�ԍ�</summary>
        private string _partySaleSlipNum = "";
        /// <summary>�t���^���Œ�ԍ��z��</summary>
        private int[] _fullModelFixedNoAry = new int[0];
        /// <summary>�������z��</summary>
        private byte[] _categoryObjAry = new byte[0];
        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>�ԗ����s����</summary>
        private int _mileage;
        /// <summary>���q���l</summary>
        private string _carNote = "";
        /// <summary>���^�������ԍ�</summary>
        private int _numberPlate1Code;
        /// <summary>���^�����ǖ���</summary>
        private string _numberPlate1Name = "";
        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
        private string _numberPlate2 = "";
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _numberPlate3 = "";
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private int _numberPlate4;

        /// <summary>�Ԍ�������</summary>
        private DateTime _inspectMaturityDate;
        /// <summary>�O��Ԍ�������</summary>
        private DateTime _lTimeCiMatDate;
        /// <summary>�Ԍ�����</summary>
        private int _carInspectYear;
        /// <summary>�����@�^���i�G���W���j</summary>
        private string _engineModel = "";
        /// <summary>���q�ǉ����P</summary>
        private string _carAddInfo1 = "";
        /// <summary>���q�ǉ����Q</summary>
        private string _carAddInfo2 = "";
        /// <summary>�o�^�N����</summary>
        private DateTime _entryDate;
        // --- ADD 2009/09/08 ----------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>�Ԏ피�p����</summary>
        private string _modelHalfName;
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        private string[] _freeSrchMdlFxdNoAry = new string[0];
        // --- ADD 2010/04/27 ----------<<<<<

        // PMNS:���Y/�O�ԋ敪 ��ǉ�
        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>���Y/�O�ԋ敪</summary>
        private int _domesticForeignCode;
        // --- ADD 2013/03/21 ----------<<<<<

        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public int AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }
        /// <summary>
        /// ����`�[�敪
        /// </summary>
        public int SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }
        /// <summary>
        /// ����`�[�ԍ�
        /// </summary>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }
        /// <summary>
        /// ����s�ԍ�
        /// </summary>
        public int SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }
        /// <summary>
        /// ������t
        /// </summary>
        public int SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        /// <summary>
        /// ���Ӑ旪��
        /// </summary>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }
        /// <summary>
        /// �󒍎҃R�[�h
        /// </summary>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }
        /// <summary>
        /// ���s�҃R�[�h
        /// </summary>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        /// <summary>
        /// ���q�Ǘ��ԍ�
        /// </summary>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        /// <summary>
        /// ���q�Ǘ�SEQ
        /// </summary>
        public int CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }
        /// <summary>
        /// �^���w��ԍ�
        /// </summary>
        public int ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }
        /// <summary>
        /// �ޕʔԍ�
        /// </summary>
        public int CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }
        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public int MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }
        /// <summary>
        /// �Ԏ�R�[�h
        /// </summary>
        public int ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }
        /// <summary>
        /// �Ԏ�T�u�R�[�h
        /// </summary>
        public int ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }
        /// <summary>
        /// �Ԏ햼��
        /// </summary>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }
        /// <summary>
        /// �^���i�t���^���j
        /// </summary>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }
        /// <summary>
        /// �G���W���^��
        /// </summary>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }
        /// <summary>
        /// �N��
        /// </summary>
        public int FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }
        /// <summary>
        /// �ԑ�ԍ�
        /// </summary>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }
        /// <summary>
        /// �J���[�R�[�h
        /// </summary>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }
        /// <summary>
        /// �g�����R�[�h
        /// </summary>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }
        /// <summary>
        /// �`�[���l�P
        /// </summary>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }
        /// <summary>
        /// �`�[���l�Q
        /// </summary>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }
        /// <summary>
        /// �`�[���l�R
        /// </summary>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }
        /// <summary>
        /// �[����R�[�h
        /// </summary>
        public int AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }
        /// <summary>
        /// �[���於�̂P
        /// </summary>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }
        /// <summary>
        /// �[���於�̂Q
        /// </summary>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }
        /// <summary>
        /// �[�i�敪
        /// </summary>
        public int DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }
        /// <summary>
        /// ���`�ԍ�
        /// </summary>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }
        /// <summary>
        /// �t���^���Œ�ԍ��z��
        /// </summary>
        public int[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }
        /// <summary>
        /// �������z��
        /// </summary>
        public byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        // --- ADD 2009/09/08 ---------->>>>>
        /// <summary>
        /// �ԗ����s����
        /// </summary>
        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// <summary>
        /// ���q���l
        /// </summary>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }

        /// <summary>
        /// ���^�������ԍ�
        /// </summary>
        public int NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// <summary>
        /// ���^�����ǖ���
        /// </summary>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// <summary>
        /// �ԗ��o�^�ԍ��i��ʁj
        /// </summary>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// <summary>
        /// �ԗ��o�^�ԍ��i�J�i�j
        /// </summary>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// <summary>
        /// �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        /// </summary>
        public int NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// <summary>
        /// �Ԍ�������
        /// </summary>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }

        /// <summary>
        /// �O��Ԍ�������
        /// </summary>
        public DateTime LTimeCiMatDate
        {
            get { return _lTimeCiMatDate; }
            set { _lTimeCiMatDate = value; }
        }

        /// <summary>
        /// �Ԍ�����
        /// </summary>
        public int CarInspectYear
        {
            get { return _carInspectYear; }
            set { _carInspectYear = value; }
        }

        /// <summary>
        /// �����@�^���i�G���W���j
        /// </summary>
        public string EngineModel
        {
            get { return _engineModel; }
            set { _engineModel = value; }
        }

        /// <summary>
        /// ���q�ǉ����P
        /// </summary>
        public string CarAddInfo1
        {
            get { return _carAddInfo1; }
            set { _carAddInfo1 = value; }
        }

        /// <summary>
        /// ���q�ǉ����Q
        /// </summary>
        public string CarAddInfo2
        {
            get { return _carAddInfo2; }
            set { _carAddInfo2 = value; }
        }

        /// <summary>
        /// �o�^�N����
        /// </summary>
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }
        // --- ADD 2009/09/08 ----------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>
        /// �Ԏ피�p���̃v���p�e�B
        /// </summary>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>
        /// ���R�����^���Œ�ԍ��z��v���p�e�B
        /// </summary>
        public string[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }
        // --- ADD 2010/04/27 ----------<<<<

        // --- ADD 2009/09/08 ----------<<<<<

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// ���Y/�O�ԋ敪�v���p�e�B
        /// </summary>
        public int DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }
        // --- ADD 2013/03/21 ----------<<<<

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SalesSlipHeaderCopyData()
        {
        }
    }
    # endregion

}
