using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailDefaultCar
    /// <summary>
    ///                      ���[�������l�ԗ��f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�������l�ԗ��f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailDefaultCar
    {
        /// <summary>���q�Ǘ��R�[�h</summary>
        /// <remarks>��PM7�ł̎ԗ��Ǘ��ԍ�</remarks>
        private string _carMngCode = "";

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

        /// <summary>���N�x</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _firstEntryDate;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>���[�J�[�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _makerFullName = "";

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�r�K�X�L��</summary>
        private string _exhaustGasSign = "";

        /// <summary>�V���[�Y�^��</summary>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _categorySignModel = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>�ԑ�^��</summary>
        private string _frameModel = "";

        /// <summary>�ԑ�ԍ�</summary>
        /// <remarks>�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j</remarks>
        private string _frameNo = "";

        /// <summary>�G���W���^������</summary>
        /// <remarks>�G���W������</remarks>
        private string _engineModelNm = "";

        /// <summary>�ԗ����s����</summary>
        private Int32 _mileage;

        /// <summary>���q���l</summary>
        private string _carNote = "";


        /// public propaty name  :  CarMngCode
        /// <summary>���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��PM7�ł̎ԗ��Ǘ��ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
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

        /// public propaty name  :  FirstEntryDate
        /// <summary>���N�x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FirstEntryDate
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

        /// public propaty name  :  MakerFullName
        /// <summary>���[�J�[�S�p���̃v���p�e�B</summary>
        /// <value>�������́i�J�i�������݂őS�p�Ǘ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�S�p���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerFullName
        {
            get { return _makerFullName; }
            set { _makerFullName = value; }
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

        /// public propaty name  :  ExhaustGasSign
        /// <summary>�r�K�X�L���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�K�X�L���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
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


        /// <summary>
        /// ���[�������l�ԗ��f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>MailDefaultCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultCar()
        {
        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="carMngCode">���q�Ǘ��R�[�h(��PM7�ł̎ԗ��Ǘ��ԍ�)</param>
        /// <param name="numberPlate1Code">���^�������ԍ�</param>
        /// <param name="numberPlate1Name">���^�����ǖ���</param>
        /// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
        /// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
        /// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
        /// <param name="firstEntryDate">���N�x(YYYYMM)</param>
        /// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="makerFullName">���[�J�[�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="modelCode">�Ԏ�R�[�h(�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h(0�`899:�񋟕�,900�`հ�ް�o�^)</param>
        /// <param name="modelFullName">�Ԏ�S�p����(�������́i�J�i�������݂őS�p�Ǘ��j)</param>
        /// <param name="exhaustGasSign">�r�K�X�L��</param>
        /// <param name="seriesModel">�V���[�Y�^��</param>
        /// <param name="categorySignModel">�^���i�ޕʋL���j</param>
        /// <param name="fullModel">�^���i�t���^�j(�t���^��(44���p))</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʔԍ�</param>
        /// <param name="frameModel">�ԑ�^��</param>
        /// <param name="frameNo">�ԑ�ԍ�(�Ԍ��؋L�ڃt�H�[�}�b�g�Ή��i HCR32-100251584 ���j)</param>
        /// <param name="engineModelNm">�G���W���^������(�G���W������)</param>
        /// <param name="mileage">�ԗ����s����</param>
        /// <param name="carNote">���q���l</param>
        /// <returns>MailDefaultCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultCar(string carMngCode, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 firstEntryDate, Int32 makerCode, string makerFullName, Int32 modelCode, Int32 modelSubCode, string modelFullName, string exhaustGasSign, string seriesModel, string categorySignModel, string fullModel, Int32 modelDesignationNo, Int32 categoryNo, string frameModel, string frameNo, string engineModelNm, Int32 mileage, string carNote)
        {
            this._carMngCode = carMngCode;
            this._numberPlate1Code = numberPlate1Code;
            this._numberPlate1Name = numberPlate1Name;
            this._numberPlate2 = numberPlate2;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this.FirstEntryDate = firstEntryDate;
            this._makerCode = makerCode;
            this._makerFullName = makerFullName;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._modelFullName = modelFullName;
            this._exhaustGasSign = exhaustGasSign;
            this._seriesModel = seriesModel;
            this._categorySignModel = categorySignModel;
            this._fullModel = fullModel;
            this._modelDesignationNo = modelDesignationNo;
            this._categoryNo = categoryNo;
            this._frameModel = frameModel;
            this._frameNo = frameNo;
            this._engineModelNm = engineModelNm;
            this._mileage = mileage;
            this._carNote = carNote;

        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^��������
        /// </summary>
        /// <returns>MailDefaultCar�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailDefaultCar�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailDefaultCar Clone()
        {
            return new MailDefaultCar(this._carMngCode, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._firstEntryDate, this._makerCode, this._makerFullName, this._modelCode, this._modelSubCode, this._modelFullName, this._exhaustGasSign, this._seriesModel, this._categorySignModel, this._fullModel, this._modelDesignationNo, this._categoryNo, this._frameModel, this._frameNo, this._engineModelNm, this._mileage, this._carNote);
        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailDefaultCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(MailDefaultCar target)
        {
            return ( ( this.CarMngCode == target.CarMngCode )
                 && ( this.NumberPlate1Code == target.NumberPlate1Code )
                 && ( this.NumberPlate1Name == target.NumberPlate1Name )
                 && ( this.NumberPlate2 == target.NumberPlate2 )
                 && ( this.NumberPlate3 == target.NumberPlate3 )
                 && ( this.NumberPlate4 == target.NumberPlate4 )
                 && ( this.FirstEntryDate == target.FirstEntryDate )
                 && ( this.MakerCode == target.MakerCode )
                 && ( this.MakerFullName == target.MakerFullName )
                 && ( this.ModelCode == target.ModelCode )
                 && ( this.ModelSubCode == target.ModelSubCode )
                 && ( this.ModelFullName == target.ModelFullName )
                 && ( this.ExhaustGasSign == target.ExhaustGasSign )
                 && ( this.SeriesModel == target.SeriesModel )
                 && ( this.CategorySignModel == target.CategorySignModel )
                 && ( this.FullModel == target.FullModel )
                 && ( this.ModelDesignationNo == target.ModelDesignationNo )
                 && ( this.CategoryNo == target.CategoryNo )
                 && ( this.FrameModel == target.FrameModel )
                 && ( this.FrameNo == target.FrameNo )
                 && ( this.EngineModelNm == target.EngineModelNm )
                 && ( this.Mileage == target.Mileage )
                 && ( this.CarNote == target.CarNote ) );
        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^��r����
        /// </summary>
        /// <param name="mailDefaultCar1">
        ///                    ��r����MailDefaultCar�N���X�̃C���X�^���X
        /// </param>
        /// <param name="mailDefaultCar2">��r����MailDefaultCar�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(MailDefaultCar mailDefaultCar1, MailDefaultCar mailDefaultCar2)
        {
            return ( ( mailDefaultCar1.CarMngCode == mailDefaultCar2.CarMngCode )
                 && ( mailDefaultCar1.NumberPlate1Code == mailDefaultCar2.NumberPlate1Code )
                 && ( mailDefaultCar1.NumberPlate1Name == mailDefaultCar2.NumberPlate1Name )
                 && ( mailDefaultCar1.NumberPlate2 == mailDefaultCar2.NumberPlate2 )
                 && ( mailDefaultCar1.NumberPlate3 == mailDefaultCar2.NumberPlate3 )
                 && ( mailDefaultCar1.NumberPlate4 == mailDefaultCar2.NumberPlate4 )
                 && ( mailDefaultCar1.FirstEntryDate == mailDefaultCar2.FirstEntryDate )
                 && ( mailDefaultCar1.MakerCode == mailDefaultCar2.MakerCode )
                 && ( mailDefaultCar1.MakerFullName == mailDefaultCar2.MakerFullName )
                 && ( mailDefaultCar1.ModelCode == mailDefaultCar2.ModelCode )
                 && ( mailDefaultCar1.ModelSubCode == mailDefaultCar2.ModelSubCode )
                 && ( mailDefaultCar1.ModelFullName == mailDefaultCar2.ModelFullName )
                 && ( mailDefaultCar1.ExhaustGasSign == mailDefaultCar2.ExhaustGasSign )
                 && ( mailDefaultCar1.SeriesModel == mailDefaultCar2.SeriesModel )
                 && ( mailDefaultCar1.CategorySignModel == mailDefaultCar2.CategorySignModel )
                 && ( mailDefaultCar1.FullModel == mailDefaultCar2.FullModel )
                 && ( mailDefaultCar1.ModelDesignationNo == mailDefaultCar2.ModelDesignationNo )
                 && ( mailDefaultCar1.CategoryNo == mailDefaultCar2.CategoryNo )
                 && ( mailDefaultCar1.FrameModel == mailDefaultCar2.FrameModel )
                 && ( mailDefaultCar1.FrameNo == mailDefaultCar2.FrameNo )
                 && ( mailDefaultCar1.EngineModelNm == mailDefaultCar2.EngineModelNm )
                 && ( mailDefaultCar1.Mileage == mailDefaultCar2.Mileage )
                 && ( mailDefaultCar1.CarNote == mailDefaultCar2.CarNote ) );
        }
        /// <summary>
        /// ���[�������l�ԗ��f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailDefaultCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(MailDefaultCar target)
        {
            ArrayList resList = new ArrayList();
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FirstEntryDate != target.FirstEntryDate) resList.Add("FirstEntryDate");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerFullName != target.MakerFullName) resList.Add("MakerFullName");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.ExhaustGasSign != target.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (this.SeriesModel != target.SeriesModel) resList.Add("SeriesModel");
            if (this.CategorySignModel != target.CategorySignModel) resList.Add("CategorySignModel");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
            if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.Mileage != target.Mileage) resList.Add("Mileage");
            if (this.CarNote != target.CarNote) resList.Add("CarNote");

            return resList;
        }

        /// <summary>
        /// ���[�������l�ԗ��f�[�^��r����
        /// </summary>
        /// <param name="mailDefaultCar1">��r����MailDefaultCar�N���X�̃C���X�^���X</param>
        /// <param name="mailDefaultCar2">��r����MailDefaultCar�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailDefaultCar�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(MailDefaultCar mailDefaultCar1, MailDefaultCar mailDefaultCar2)
        {
            ArrayList resList = new ArrayList();
            if (mailDefaultCar1.CarMngCode != mailDefaultCar2.CarMngCode) resList.Add("CarMngCode");
            if (mailDefaultCar1.NumberPlate1Code != mailDefaultCar2.NumberPlate1Code) resList.Add("NumberPlate1Code");
            if (mailDefaultCar1.NumberPlate1Name != mailDefaultCar2.NumberPlate1Name) resList.Add("NumberPlate1Name");
            if (mailDefaultCar1.NumberPlate2 != mailDefaultCar2.NumberPlate2) resList.Add("NumberPlate2");
            if (mailDefaultCar1.NumberPlate3 != mailDefaultCar2.NumberPlate3) resList.Add("NumberPlate3");
            if (mailDefaultCar1.NumberPlate4 != mailDefaultCar2.NumberPlate4) resList.Add("NumberPlate4");
            if (mailDefaultCar1.FirstEntryDate != mailDefaultCar2.FirstEntryDate) resList.Add("FirstEntryDate");
            if (mailDefaultCar1.MakerCode != mailDefaultCar2.MakerCode) resList.Add("MakerCode");
            if (mailDefaultCar1.MakerFullName != mailDefaultCar2.MakerFullName) resList.Add("MakerFullName");
            if (mailDefaultCar1.ModelCode != mailDefaultCar2.ModelCode) resList.Add("ModelCode");
            if (mailDefaultCar1.ModelSubCode != mailDefaultCar2.ModelSubCode) resList.Add("ModelSubCode");
            if (mailDefaultCar1.ModelFullName != mailDefaultCar2.ModelFullName) resList.Add("ModelFullName");
            if (mailDefaultCar1.ExhaustGasSign != mailDefaultCar2.ExhaustGasSign) resList.Add("ExhaustGasSign");
            if (mailDefaultCar1.SeriesModel != mailDefaultCar2.SeriesModel) resList.Add("SeriesModel");
            if (mailDefaultCar1.CategorySignModel != mailDefaultCar2.CategorySignModel) resList.Add("CategorySignModel");
            if (mailDefaultCar1.FullModel != mailDefaultCar2.FullModel) resList.Add("FullModel");
            if (mailDefaultCar1.ModelDesignationNo != mailDefaultCar2.ModelDesignationNo) resList.Add("ModelDesignationNo");
            if (mailDefaultCar1.CategoryNo != mailDefaultCar2.CategoryNo) resList.Add("CategoryNo");
            if (mailDefaultCar1.FrameModel != mailDefaultCar2.FrameModel) resList.Add("FrameModel");
            if (mailDefaultCar1.FrameNo != mailDefaultCar2.FrameNo) resList.Add("FrameNo");
            if (mailDefaultCar1.EngineModelNm != mailDefaultCar2.EngineModelNm) resList.Add("EngineModelNm");
            if (mailDefaultCar1.Mileage != mailDefaultCar2.Mileage) resList.Add("Mileage");
            if (mailDefaultCar1.CarNote != mailDefaultCar2.CarNote) resList.Add("CarNote");

            return resList;
        }
    }
}
