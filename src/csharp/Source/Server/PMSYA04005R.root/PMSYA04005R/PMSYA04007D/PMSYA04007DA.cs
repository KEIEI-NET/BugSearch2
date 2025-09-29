using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CarShipmentPartsDispWork
    /// <summary>
    ///                      ���q�o�ו��i�\�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���q�o�ו��i�\�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   ����l����ېőΏۊz���v</br>
    /// <br>                 :   ���㐳�����z</br>
    /// <br>                 :   ������z����Ŋz�i�O�Łj</br>
    /// <br>Update Note      :   2008/7/29  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ�</br>
    /// <br>Update Note      :   2012/08/09   ������</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �s�ԍ�</br>
    /// <br>Update Note      :   SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
    /// <br>Programmer       :   FSI���� �G</br>
    /// <br>Date             :   2013/03/25</br>
    /// <br>�Ǘ��ԍ�         :   10900269-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CarShipmentPartsDispWork
    {
        /// <summary>������t</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�ō���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>�o�א�</summary>
        private Double _shipmentCnt;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�e�����z</summary>
        private Int64 _grossProfit;

        /// <summary>�����P��</summary>
        private Double _salesUnitCost;

        /// <summary>�`�[���l</summary>
        private string _slipNote = "";

        /// <summary>���q���l</summary>
        private string _carNote = "";

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>�V���[�Y�^��</summary>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _categorySignModel = "";

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _firstEntryDate;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�Ԏ피�p����</summary>
        /// <remarks>�������́i���p�ŊǗ��j</remarks>
        private string _modelHalfName = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>�ԑ�ԍ�</summary>
        /// <remarks>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</remarks>
        private string _frameNo = "";

        /// <summary>�G���W���^������</summary>
        /// <remarks>�G���W������</remarks>
        private string _engineModelNm = "";

        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _colorCode = "";

        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>���Y�ԑ�ԍ��J�n</summary>
        private Int32 _stProduceFrameNo;

        /// <summary>���Y�ԑ�ԍ��I��</summary>
        private Int32 _edProduceFrameNo;

        /// <summary>�����@�^���i�G���W���j</summary>
        /// <remarks>�Ԍ��؋L�ڌ����@�^��</remarks>
        private string _engineModel = "";

        /// <summary>�^���O���[�h����</summary>
        private string _modelGradeNm = "";

        /// <summary>�r�C�ʖ���</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E�敪����</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _eDivNm = "";

        /// <summary>�~�b�V��������</summary>
        private string _transmissionNm = "";

        /// <summary>�V�t�g����</summary>
        private string _shiftNm = "";

        /// <summary>�쓮��������</summary>
        /// <remarks>�V�K�ǉ�</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>�ǉ�����1</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec1 = "";

        /// <summary>�ǉ�����2</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec2 = "";

        /// <summary>�ǉ�����3</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec3 = "";

        /// <summary>�ǉ�����4</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec4 = "";

        /// <summary>�ǉ�����5</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec5 = "";

        /// <summary>�ǉ�����6</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpec6 = "";

        /// <summary>�ǉ������^�C�g��1</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle1 = "";

        /// <summary>�ǉ������^�C�g��2</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle2 = "";

        /// <summary>�ǉ������^�C�g��3</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle3 = "";

        /// <summary>�ǉ������^�C�g��4</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle4 = "";

        /// <summary>�ǉ������^�C�g��5</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle5 = "";

        /// <summary>�ǉ������^�C�g��6</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _addiCarSpecTitle6 = "";

        /// <summary>�J�n���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _stProduceTypeOfYear;

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _edProduceTypeOfYear;

        /// <summary>�h�A��</summary>
        private Int32 _doorCount;

        /// <summary>�{�f�B�[����</summary>
        private string _bodyName = "";

        /// <summary>�o�׉\��</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>����</summary>
        private Int64 _cost;

        /// <summary>����</summary>
        private Double _shipmentTotalCnt;

        /// <summary>������z�i���v�j</summary>
        private Int64 _salesMoneyTaxExcTotal;

        /// <summary>�o�׉�</summary>
        private Double _shipmentCntTotal;

        /// <summary>���ʁi�݌Ɂj</summary>
        private Double _shipmentCntInTotal;

        /// <summary>���ʁi���j</summary>
        private Double _shipmentCntOutTotal;

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

        /// <summary>�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _colorName1 = "";

        /// <summary>�g��������</summary>
        private string _trimName = "";

        /// <summary>�Ǘ��ԍ�</summary>
        private string _carMngCode = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        private int _acptAnOdrStatus;

        /// <summary>����`�[�敪�i���ׁj</summary>
        private Int32 _salesSlipCdDtl;

        // -------ADD BY �����@on 2012/08/09 for Redmine#31532------->>>>>>>
        /// <summary>�s�ԍ�</summary>
        private int _rowNo;

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>���Y/�O�ԋ敪</summary>
        private Int32 _domesticForeignCode;
        // --- ADD 2013/03/25 ----------<<<<<

        /// public propaty name  :  RowNo
        /// <summary>�s�ԍ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   Redmine#31532�̑Ή���ǉ�</br>
        /// </remarks>
        public Int32 RowNo
        {
            get { return _rowNo; }
            set { _rowNo = value; }
        }
        // -------ADD BY �����@on 2012/08/09 for Redmine#31532-------<<<<<<<
        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�ō���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
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

        /// public propaty name  :  CarNote
        /// <summary>���q���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
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

        /// public propaty name  :  SeriesModel
        /// <summary>�V���[�Y�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���[�Y�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>�^���i�ޕʋL���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
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

        /// public propaty name  :  ModelFullName
        /// <summary>�Ԏ�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>�Ԏ피�p���̃v���p�e�B</summary>
        /// <value>�������́i���p�ŊǗ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ피�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
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

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</value>
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

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�G���W������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
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

        /// public propaty name  :  StProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StProduceFrameNo
        {
            get { return _stProduceFrameNo; }
            set { _stProduceFrameNo = value; }
        }

        /// public propaty name  :  EdProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdProduceFrameNo
        {
            get { return _edProduceFrameNo; }
            set { _edProduceFrameNo = value; }
        }

        /// public propaty name  :  EngineModel
        /// <summary>�����@�^���i�G���W���j�v���p�e�B</summary>
        /// <value>�Ԍ��؋L�ڌ����@�^��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����@�^���i�G���W���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineModel
        {
            get { return _engineModel; }
            set { _engineModel = value; }
        }

        /// public propaty name  :  ModelGradeNm
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public propaty name  :  EngineDisplaceNm
        /// <summary>�r�C�ʖ��̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�C�ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public propaty name  :  EDivNm
        /// <summary>E�敪���̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public propaty name  :  TransmissionNm
        /// <summary>�~�b�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �~�b�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public propaty name  :  ShiftNm
        /// <summary>�V�t�g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�t�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public propaty name  :  WheelDriveMethodNm
        /// <summary>�쓮�������̃v���p�e�B</summary>
        /// <value>�V�K�ǉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쓮�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }

        /// public propaty name  :  AddiCarSpec1
        /// <summary>�ǉ�����1�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec1
        {
            get { return _addiCarSpec1; }
            set { _addiCarSpec1 = value; }
        }

        /// public propaty name  :  AddiCarSpec2
        /// <summary>�ǉ�����2�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec2
        {
            get { return _addiCarSpec2; }
            set { _addiCarSpec2 = value; }
        }

        /// public propaty name  :  AddiCarSpec3
        /// <summary>�ǉ�����3�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec3
        {
            get { return _addiCarSpec3; }
            set { _addiCarSpec3 = value; }
        }

        /// public propaty name  :  AddiCarSpec4
        /// <summary>�ǉ�����4�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec4
        {
            get { return _addiCarSpec4; }
            set { _addiCarSpec4 = value; }
        }

        /// public propaty name  :  AddiCarSpec5
        /// <summary>�ǉ�����5�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec5
        {
            get { return _addiCarSpec5; }
            set { _addiCarSpec5 = value; }
        }

        /// public propaty name  :  AddiCarSpec6
        /// <summary>�ǉ�����6�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ�����6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpec6
        {
            get { return _addiCarSpec6; }
            set { _addiCarSpec6 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle1
        /// <summary>�ǉ������^�C�g��1�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle1
        {
            get { return _addiCarSpecTitle1; }
            set { _addiCarSpecTitle1 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle2
        /// <summary>�ǉ������^�C�g��2�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle2
        {
            get { return _addiCarSpecTitle2; }
            set { _addiCarSpecTitle2 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle3
        /// <summary>�ǉ������^�C�g��3�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle3
        {
            get { return _addiCarSpecTitle3; }
            set { _addiCarSpecTitle3 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle4
        /// <summary>�ǉ������^�C�g��4�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle4
        {
            get { return _addiCarSpecTitle4; }
            set { _addiCarSpecTitle4 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle5
        /// <summary>�ǉ������^�C�g��5�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle5
        {
            get { return _addiCarSpecTitle5; }
            set { _addiCarSpecTitle5 = value; }
        }

        /// public propaty name  :  AddiCarSpecTitle6
        /// <summary>�ǉ������^�C�g��6�v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������^�C�g��6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddiCarSpecTitle6
        {
            get { return _addiCarSpecTitle6; }
            set { _addiCarSpecTitle6 = value; }
        }

        /// public propaty name  :  StProduceTypeOfYear
        /// <summary>�J�n���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public propaty name  :  EdProduceTypeOfYear
        /// <summary>�I�����Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

        /// public propaty name  :  DoorCount
        /// <summary>�h�A���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�A���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        /// public propaty name  :  BodyName
        /// <summary>�{�f�B�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�f�B�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
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

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  ShipmentTotalCnt
        /// <summary>���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentTotalCnt
        {
            get { return _shipmentTotalCnt; }
            set { _shipmentTotalCnt = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExcTotal
        /// <summary>������z�i���v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExcTotal
        {
            get { return _salesMoneyTaxExcTotal; }
            set { _salesMoneyTaxExcTotal = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  ShipmentCntTotal
        /// <summary>�o�׉񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCntTotal
        {
            get { return _shipmentCntTotal; }
            set { _shipmentCntTotal = value; }
        }

        /// public propaty name  :  ShipmentCntInTotal
        /// <summary>���ʁi�݌Ɂj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʁi�݌Ɂj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCntInTotal
        {
            get { return _shipmentCntInTotal; }
            set { _shipmentCntInTotal = value; }
        }

        /// public propaty name  :  ShipmentCntOutTotal
        /// <summary>���ʁi���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʁi���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCntOutTotal
        {
            get { return _shipmentCntOutTotal; }
            set { _shipmentCntOutTotal = value; }
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

        /// public propaty name  :  CarMngCode
        /// <summary>�Ǘ��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
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

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�i���ׁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�i���ׁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        // --- ADD 2013/03/25 ---------->>>>>
        /// public propaty name  :  DomesticForeignCode
        /// <summary>���Y/�O�ԋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y/�O�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DomesticForeignCode
        {
            get { return _domesticForeignCode; }
            set { _domesticForeignCode = value; }
        }
        // --- ADD 2013/03/25 ----------<<<<<

        /// <summary>
        /// ���q�o�ו��i�\�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CarShipmentPartsDispWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CarShipmentPartsDispWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CarShipmentPartsDispWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CarShipmentPartsDispWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer       :   FSI���� �G</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CarShipmentPartsDispWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CarShipmentPartsDispWork || graph is ArrayList || graph is CarShipmentPartsDispWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CarShipmentPartsDispWork).FullName));

            if (graph != null && graph is CarShipmentPartsDispWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CarShipmentPartsDispWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CarShipmentPartsDispWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CarShipmentPartsDispWork[])graph).Length;
            }
            else if (graph is CarShipmentPartsDispWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //�艿�i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //�o�א�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //����P���i�Ŕ��C�����j
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //������z�i�Ŕ����j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�e�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //�`�[���l
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //���q���l
            serInfo.MemberInfo.Add(typeof(string)); //CarNote
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�ԗ����s����
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //�V���[�Y�^��
            serInfo.MemberInfo.Add(typeof(string)); //SeriesModel
            //�^���i�ޕʋL���j
            serInfo.MemberInfo.Add(typeof(string)); //CategorySignModel
            //���N�x
            serInfo.MemberInfo.Add(typeof(Int32)); //FirstEntryDate
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //�Ԏ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //�Ԏ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //�Ԏ�S�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelFullName
            //�Ԏ피�p����
            serInfo.MemberInfo.Add(typeof(string)); //ModelHalfName
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�^���w��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //�ޕʔԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //�ԑ�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //�G���W���^������
            serInfo.MemberInfo.Add(typeof(string)); //EngineModelNm
            //�J���[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ColorCode
            //�g�����R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //���Y�ԑ�ԍ��J�n
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
            //���Y�ԑ�ԍ��I��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
            //�����@�^���i�G���W���j
            serInfo.MemberInfo.Add(typeof(string)); //EngineModel
            //�^���O���[�h����
            serInfo.MemberInfo.Add(typeof(string)); //ModelGradeNm
            //�r�C�ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //EngineDisplaceNm
            //E�敪����
            serInfo.MemberInfo.Add(typeof(string)); //EDivNm
            //�~�b�V��������
            serInfo.MemberInfo.Add(typeof(string)); //TransmissionNm
            //�V�t�g����
            serInfo.MemberInfo.Add(typeof(string)); //ShiftNm
            //�쓮��������
            serInfo.MemberInfo.Add(typeof(string)); //WheelDriveMethodNm
            //�ǉ�����1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec1
            //�ǉ�����2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec2
            //�ǉ�����3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec3
            //�ǉ�����4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec4
            //�ǉ�����5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec5
            //�ǉ�����6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpec6
            //�ǉ������^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle1
            //�ǉ������^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle2
            //�ǉ������^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle3
            //�ǉ������^�C�g��4
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle4
            //�ǉ������^�C�g��5
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle5
            //�ǉ������^�C�g��6
            serInfo.MemberInfo.Add(typeof(string)); //AddiCarSpecTitle6
            //�J�n���Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //StProduceTypeOfYear
            //�I�����Y�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceTypeOfYear
            //�h�A��
            serInfo.MemberInfo.Add(typeof(Int32)); //DoorCount
            //�{�f�B�[����
            serInfo.MemberInfo.Add(typeof(string)); //BodyName
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //����
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentTotalCnt
            //������z�i���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExcTotal
            //�o�׉�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntTotal
            //���ʁi�݌Ɂj
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntInTotal
            //���ʁi���j
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCntOutTotal
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
            //�J���[����1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //�g��������
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //�Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�敪�i���ׁj
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            // --- ADD 2013/03/25 ---------->>>>>
            //���Y/�O�ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DomesticForeignCode
            // --- ADD 2013/03/25 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CarShipmentPartsDispWork)
            {
                CarShipmentPartsDispWork temp = (CarShipmentPartsDispWork)graph;

                SetCarShipmentPartsDispWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CarShipmentPartsDispWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CarShipmentPartsDispWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CarShipmentPartsDispWork temp in lst)
                {
                    SetCarShipmentPartsDispWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CarShipmentPartsDispWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 77;//DEL BY �����@on 2012/08/09 for Redmine#31532
        //private const int currentMemberCount = 78;//ADD BY �����@on 2012/08/09 for Redmine#31532 //DEL 2013/03/25
        private const int currentMemberCount = 79;//ADD 2013/03/25

        /// <summary>
        ///  CarShipmentPartsDispWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer       :   FSI���� �G</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        private void SetCarShipmentPartsDispWork(System.IO.BinaryWriter writer, CarShipmentPartsDispWork temp)
        {
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerName);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
            //�艿�i�Ŕ��C�����j
            writer.Write(temp.ListPriceTaxExcFl);
            //�o�א�
            writer.Write(temp.ShipmentCnt);
            //����P���i�Ŕ��C�����j
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //������z�i�Ŕ����j
            writer.Write(temp.SalesMoneyTaxExc);
            //�e�����z
            writer.Write(temp.GrossProfit);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�`�[���l
            writer.Write(temp.SlipNote);
            //���q���l
            writer.Write(temp.CarNote);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�ԗ����s����
            writer.Write(temp.Mileage);
            //�V���[�Y�^��
            writer.Write(temp.SeriesModel);
            //�^���i�ޕʋL���j
            writer.Write(temp.CategorySignModel);
            //���N�x
            writer.Write((Int64)temp.FirstEntryDate.Ticks);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCode);
            //�Ԏ�R�[�h
            writer.Write(temp.ModelCode);
            //�Ԏ�T�u�R�[�h
            writer.Write(temp.ModelSubCode);
            //�Ԏ�S�p����
            writer.Write(temp.ModelFullName);
            //�Ԏ피�p����
            writer.Write(temp.ModelHalfName);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�^���w��ԍ�
            writer.Write(temp.ModelDesignationNo);
            //�ޕʔԍ�
            writer.Write(temp.CategoryNo);
            //�ԑ�ԍ�
            writer.Write(temp.FrameNo);
            //�G���W���^������
            writer.Write(temp.EngineModelNm);
            //�J���[�R�[�h
            writer.Write(temp.ColorCode);
            //�g�����R�[�h
            writer.Write(temp.TrimCode);
            //���Y�ԑ�ԍ��J�n
            writer.Write(temp.StProduceFrameNo);
            //���Y�ԑ�ԍ��I��
            writer.Write(temp.EdProduceFrameNo);
            //�����@�^���i�G���W���j
            writer.Write(temp.EngineModel);
            //�^���O���[�h����
            writer.Write(temp.ModelGradeNm);
            //�r�C�ʖ���
            writer.Write(temp.EngineDisplaceNm);
            //E�敪����
            writer.Write(temp.EDivNm);
            //�~�b�V��������
            writer.Write(temp.TransmissionNm);
            //�V�t�g����
            writer.Write(temp.ShiftNm);
            //�쓮��������
            writer.Write(temp.WheelDriveMethodNm);
            //�ǉ�����1
            writer.Write(temp.AddiCarSpec1);
            //�ǉ�����2
            writer.Write(temp.AddiCarSpec2);
            //�ǉ�����3
            writer.Write(temp.AddiCarSpec3);
            //�ǉ�����4
            writer.Write(temp.AddiCarSpec4);
            //�ǉ�����5
            writer.Write(temp.AddiCarSpec5);
            //�ǉ�����6
            writer.Write(temp.AddiCarSpec6);
            //�ǉ������^�C�g��1
            writer.Write(temp.AddiCarSpecTitle1);
            //�ǉ������^�C�g��2
            writer.Write(temp.AddiCarSpecTitle2);
            //�ǉ������^�C�g��3
            writer.Write(temp.AddiCarSpecTitle3);
            //�ǉ������^�C�g��4
            writer.Write(temp.AddiCarSpecTitle4);
            //�ǉ������^�C�g��5
            writer.Write(temp.AddiCarSpecTitle5);
            //�ǉ������^�C�g��6
            writer.Write(temp.AddiCarSpecTitle6);
            //�J�n���Y�N��
            writer.Write((Int64)temp.StProduceTypeOfYear.Ticks);
            //�I�����Y�N��
            writer.Write((Int64)temp.EdProduceTypeOfYear.Ticks);
            //�h�A��
            writer.Write(temp.DoorCount);
            //�{�f�B�[����
            writer.Write(temp.BodyName);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //����
            writer.Write(temp.Cost);
            //����
            writer.Write(temp.ShipmentTotalCnt);
            //������z�i���v�j
            writer.Write(temp.SalesMoneyTaxExcTotal);
            //�o�׉�
            writer.Write(temp.ShipmentCntTotal);
            //���ʁi�݌Ɂj
            writer.Write(temp.ShipmentCntInTotal);
            //���ʁi���j
            writer.Write(temp.ShipmentCntOutTotal);
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
            //�J���[����1
            writer.Write(temp.ColorName1);
            //�g��������
            writer.Write(temp.TrimName);
            //�Ǘ��ԍ�
            writer.Write(temp.CarMngCode);
            // �󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            // ����`�[�敪�i���ׁj
            writer.Write(temp.SalesSlipCdDtl);
            //�s�ԍ�
            writer.Write(temp.RowNo);//ADD BY �����@on 2012/08/09 for Redmine#31532
            // --- ADD 2013/03/25 ---------->>>>>
            //���Y/�O�ԋ敪
            writer.Write(temp.DomesticForeignCode);
            // --- ADD 2013/03/25 ----------<<<<<

        }

        /// <summary>
        ///  CarShipmentPartsDispWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CarShipmentPartsDispWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer       :   FSI���� �G</br>
        /// <br>Date             :   2013/03/25</br>
        /// </remarks>
        private CarShipmentPartsDispWork GetCarShipmentPartsDispWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CarShipmentPartsDispWork temp = new CarShipmentPartsDispWork();

            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerName = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
            //�艿�i�Ŕ��C�����j
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //�o�א�
            temp.ShipmentCnt = reader.ReadDouble();
            //����P���i�Ŕ��C�����j
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //������z�i�Ŕ����j
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�e�����z
            temp.GrossProfit = reader.ReadInt64();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //�`�[���l
            temp.SlipNote = reader.ReadString();
            //���q���l
            temp.CarNote = reader.ReadString();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�ԗ����s����
            temp.Mileage = reader.ReadInt32();
            //�V���[�Y�^��
            temp.SeriesModel = reader.ReadString();
            //�^���i�ޕʋL���j
            temp.CategorySignModel = reader.ReadString();
            //���N�x
            temp.FirstEntryDate = new DateTime(reader.ReadInt64());
            //���[�J�[�R�[�h
            temp.MakerCode = reader.ReadInt32();
            //�Ԏ�R�[�h
            temp.ModelCode = reader.ReadInt32();
            //�Ԏ�T�u�R�[�h
            temp.ModelSubCode = reader.ReadInt32();
            //�Ԏ�S�p����
            temp.ModelFullName = reader.ReadString();
            //�Ԏ피�p����
            temp.ModelHalfName = reader.ReadString();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�^���w��ԍ�
            temp.ModelDesignationNo = reader.ReadInt32();
            //�ޕʔԍ�
            temp.CategoryNo = reader.ReadInt32();
            //�ԑ�ԍ�
            temp.FrameNo = reader.ReadString();
            //�G���W���^������
            temp.EngineModelNm = reader.ReadString();
            //�J���[�R�[�h
            temp.ColorCode = reader.ReadString();
            //�g�����R�[�h
            temp.TrimCode = reader.ReadString();
            //���Y�ԑ�ԍ��J�n
            temp.StProduceFrameNo = reader.ReadInt32();
            //���Y�ԑ�ԍ��I��
            temp.EdProduceFrameNo = reader.ReadInt32();
            //�����@�^���i�G���W���j
            temp.EngineModel = reader.ReadString();
            //�^���O���[�h����
            temp.ModelGradeNm = reader.ReadString();
            //�r�C�ʖ���
            temp.EngineDisplaceNm = reader.ReadString();
            //E�敪����
            temp.EDivNm = reader.ReadString();
            //�~�b�V��������
            temp.TransmissionNm = reader.ReadString();
            //�V�t�g����
            temp.ShiftNm = reader.ReadString();
            //�쓮��������
            temp.WheelDriveMethodNm = reader.ReadString();
            //�ǉ�����1
            temp.AddiCarSpec1 = reader.ReadString();
            //�ǉ�����2
            temp.AddiCarSpec2 = reader.ReadString();
            //�ǉ�����3
            temp.AddiCarSpec3 = reader.ReadString();
            //�ǉ�����4
            temp.AddiCarSpec4 = reader.ReadString();
            //�ǉ�����5
            temp.AddiCarSpec5 = reader.ReadString();
            //�ǉ�����6
            temp.AddiCarSpec6 = reader.ReadString();
            //�ǉ������^�C�g��1
            temp.AddiCarSpecTitle1 = reader.ReadString();
            //�ǉ������^�C�g��2
            temp.AddiCarSpecTitle2 = reader.ReadString();
            //�ǉ������^�C�g��3
            temp.AddiCarSpecTitle3 = reader.ReadString();
            //�ǉ������^�C�g��4
            temp.AddiCarSpecTitle4 = reader.ReadString();
            //�ǉ������^�C�g��5
            temp.AddiCarSpecTitle5 = reader.ReadString();
            //�ǉ������^�C�g��6
            temp.AddiCarSpecTitle6 = reader.ReadString();
            //�J�n���Y�N��
            temp.StProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //�I�����Y�N��
            temp.EdProduceTypeOfYear = new DateTime(reader.ReadInt64());
            //�h�A��
            temp.DoorCount = reader.ReadInt32();
            //�{�f�B�[����
            temp.BodyName = reader.ReadString();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //����
            temp.Cost = reader.ReadInt64();
            //����
            temp.ShipmentTotalCnt = reader.ReadDouble();
            //������z�i���v�j
            temp.SalesMoneyTaxExcTotal = reader.ReadInt64();
            //�o�׉�
            temp.ShipmentCntTotal = reader.ReadDouble();
            //���ʁi�݌Ɂj
            temp.ShipmentCntInTotal = reader.ReadDouble();
            //���ʁi���j
            temp.ShipmentCntOutTotal = reader.ReadDouble();
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
            //�J���[����1
            temp.ColorName1 = reader.ReadString();
            //�g��������
            temp.TrimName = reader.ReadString();
            //�Ǘ��ԍ�
            temp.CarMngCode = reader.ReadString();
            // �󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�敪�i���ׁj
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //�s�ԍ�
            temp.RowNo = reader.ReadInt32();//ADD BY �����@on 2012/08/09 for Redmine#31532
            // --- ADD 2013/03/25 ---------->>>>>
            //���Y/�O�ԋ敪
            temp.DomesticForeignCode = reader.ReadInt32();
            // --- ADD 2013/03/25 ----------<<<<<

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
        /// <returns>CarShipmentPartsDispWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CarShipmentPartsDispWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CarShipmentPartsDispWork temp = GetCarShipmentPartsDispWork(reader, serInfo);
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
                    retValue = (CarShipmentPartsDispWork[])lst.ToArray(typeof(CarShipmentPartsDispWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
