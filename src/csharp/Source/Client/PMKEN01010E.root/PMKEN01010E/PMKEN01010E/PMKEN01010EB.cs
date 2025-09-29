using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �ԗ������^�C�v�񋓑�
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������̂P�Ƃ��Ďԗ������̕��@��UI������w�肵�܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum CarSearchType : int
    {
        /// <summary> ���w��(�ʏ�͎g�p���Ȃ�) </summary>
        csNone = 0,

        /// <summary> �ޕʌ��� </summary>
        csCategory = 1,

        /// <summary> �^������ </summary>
        csModel = 2,

        /// <summary> �G���W���^������ </summary>
        csEngineModel = 3,

        /// <summary> �v���[�g���� </summary>
        csPlate = 4
    };

    /// <summary>
    /// �ԗ��^���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��^���ɂ܂��f�[�^�Ə������������܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CarModel
    {
        private const char _Delimiter = '-';  // ��؂蕶��
        private string _ExhaustGasSign;       // �r�K�X�K�����ʋL��
        private string _SeriesModel;          // �V���[�Y�^��
        private string _CategorySign;         // �ޕʋL��

        /// <summary>
        /// �ԗ��^���N���X�R���X�g���N�^
        /// </summary>
        public CarModel()
        {
            Clear();
        }

        /// <summary>
        /// �ԗ��^���N���A
        /// </summary>
        /// <remarks>
        /// �ԗ��^�����\�����郁���o��S�ď��������܂��B
        /// </remarks>
        internal void Clear()
        {
            ExhaustGasSign = "";
            SeriesModel = "";
            CategorySign = "";
        }

        /// <summary>
        /// �ԗ��^�����e�̃R�s�[���\�b�h
        /// </summary>
        /// <param name="Source">�R�s�[���̎ԗ��^���N���X</param>
        internal void Assign(CarModel Source)
        {
            _ExhaustGasSign = Source._ExhaustGasSign;
            _SeriesModel = Source._SeriesModel;
            _CategorySign = Source._CategorySign;
        }

        # region Property

        /// <summary>
        /// �r�K�X�L��
        /// </summary>
        public string ExhaustGasSign
        {
            get { return _ExhaustGasSign; }
            set { _ExhaustGasSign = value.ToUpper(); }
        }

        /// <summary>
        /// �V���[�Y�^��
        /// </summary>
        public string SeriesModel
        {
            get { return _SeriesModel; }
            set { _SeriesModel = value.ToUpper(); }
        }

        /// <summary>
        /// �ޕʋL��
        /// </summary>
        public string CategorySign
        {
            get { return _CategorySign; }
            set { _CategorySign = value.ToUpper(); }
        }

        /// <summary>
        /// �t���^��
        /// </summary>
        /// <remarks>
        /// "xxx-xxx-xxx"�̕�����Ńt���^�����擾���܂��B
        /// "xxx-xxx-xxx"�̕�����Ńt���^����ݒ肵���ꍇ�́A������Ɋ܂܂��n�C�t��(-)����؂�Ƃ���
        /// �����I�ɔr�K�X�K�����ʋ敪��V���[�Y�^���Ȃǂɕ�������܂��B
        /// </remarks>
        public string FullModel
        {
            get
            {
                string _FullModel = "";

                // �r�K�X�K�����ʋL���̐ݒ�
                if (ExhaustGasSign != "")
                {
                    _FullModel = ExhaustGasSign;
                }

                // �V���[�Y�^���̐ݒ�
                if (SeriesModel != "")
                {
                    if (_FullModel != "")
                    {
                        _FullModel += _Delimiter;
                    }

                    _FullModel += SeriesModel;
                }

                // �ޕʋL���̐ݒ�
                if (CategorySign != "")
                {
                    if (_FullModel != "")
                    {
                        _FullModel += _Delimiter;
                    }

                    _FullModel += CategorySign;
                }

                return _FullModel;
            }

            set
            {
                Clear();  // �ԗ��^����������

                // �n�C�t���ŕ������Ĕz��Ɋi�[
                string[] Models = value.Split(new char[] { _Delimiter });

                if (Models.Length == 1)
                {
                    SeriesModel = Models[0];  // �������ʂ��P�̏ꍇ�̓V���[�Y�^���Œ�Ƃ���
                }
                else
                {
                    // �������ʂ��������݂���ꍇ�͏��ɐݒ肵�Ă���
                    for (int iCnt = 0; iCnt < Models.Length; iCnt++)
                    {
                        switch (iCnt)
                        {
                            case 0:
                                ExhaustGasSign = Models[iCnt];  // �r�K�X�K�����ʋ敪
                                break;
                            case 1:
                                SeriesModel = Models[iCnt];     // �V���[�Y�^��
                                break;
                            case 2:
                                CategorySign = Models[iCnt];  // �ޕʋL��
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// �t���^������
        /// </summary>
        /// <remarks>
        /// �t���^�����ݒ肳��Ă���� true ��Ԃ��܂��B
        /// ����ȊO�� false ��Ԃ��܂��B
        /// </remarks>
        public bool IsFullModel
        {
            // �r�K�X�K�����ʋ敪�ƃV���[�Y�^�������͂���Ă���΃t���^���Ɣ��肷��
            get { return (_ExhaustGasSign != "") && (_SeriesModel != ""); }
        }

        # endregion

    }

    /// <summary>
    /// �G���W���^���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �G���W���^���ɂ܂��f�[�^�Ə������������܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class EngineModel
    {
        private const char _Delimiter = '-';  // ��؂蕶��
        private string _ModelNm;              // �G���W���^������(�t���^������n�C�t������������)
        private string _FullModel;            // �G���W���t���^��
        private string _Model;                // �G���W���^��(�Ԍ��؋L�ڌ`��)

        /// <summary>
        /// �G���W���^���N���X�R���X�g���N�^
        /// </summary>
        public EngineModel()
        {
            Clear();
        }

        /// <summary>
        /// �G���W���^���N���A
        /// </summary>
        /// <remarks>
        /// �G���W���^�����\�����郁���o��S�ď��������܂��B
        /// </remarks>
        internal void Clear()
        {
            _ModelNm = "";
            _FullModel = "";
            _Model = "";
        }

        /// <summary>
        /// �G���W���^�����e�̃R�s�[���\�b�h
        /// </summary>
        /// <param name="Source">�R�s�[���̃G���W���^���N���X</param>
        internal void Assign(EngineModel Source)
        {
            _ModelNm = Source._ModelNm;
            _FullModel = Source._FullModel;
            _Model = Source._Model;
        }

        # region Property

        /// <summary>
        /// �G���W���^������
        /// </summary>
        /// <remarks>
        /// �G���W���t���^������n�C�t����������������(��:1NZ-FE �� 1NZFE)
        /// </remarks>
        public string ModelNm
        {
            get { return _ModelNm; }
            set { _ModelNm = value; }
        }

        /// <summary>
        /// �G���W���t���^��
        /// </summary>
        /// <remarks>
        /// �G���W���t���^�����w�肷�鎖�ɂ���āA�G���W���^�����̂ƃG���W���^���������ɐݒ肳��܂��B
        /// </remarks>
        public string FullModel
        {
            get { return _FullModel; }

            set
            {
                Clear();  // �ԗ��^����������

                _FullModel = value.ToUpper();

                // �n�C�t���ŕ������Ĕz��Ɋi�[
                string[] Models = value.Split(new char[] { _Delimiter });

                // �������ʂ��������݂���ꍇ�͏��ɐݒ肵�Ă���
                for (int iCnt = 0; iCnt < Models.Length; iCnt++)
                {
                    if (iCnt == 0) { _Model = Models[iCnt]; };  // �G���W���^����ݒ�
                    _ModelNm += Models[iCnt].ToUpper();                   // �G���W���^�����̂�ݒ�
                }
            }
        }

        /// <summary>
        /// �G���W���^��
        /// </summary>
        /// <remarks>
        /// �Ԍ��؂ɋL�ڂ���Ă���G���W���̌^��(��:1NZ-FE �� 1NZ)
        /// </remarks>
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        # endregion
    }

    /// <summary>
    /// �ԗ����������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��������s�����߂̌����������Ǘ����܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/21  22018 ��� ���b</br>
    /// <br>             ���R�����I�v�V�����Ή��i���R�����^���}�X�����Ŏg�p���鎩�R����ONLY�敪��ǉ��j</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018  ��� ���b</br>
    /// <br>             ���ʕ�����</br>
    /// <br>               ���R���� 2010/04/21 �̑g��</br>
    /// </remarks>
    [Serializable]
    public class CarSearchCondition
    {
        # region Private Members

        private CarSearchType _Type;        // �ԗ������^�C�v
        private Int32 _MakerCode;           // ���[�J�[�R�[�h
        private Int32 _ModelCode;           // �Ԏ�R�[�h
        private Int32 _ModelSubCode = -1;   // �Ԏ�T�u�R�[�h
        private Int32 _ModelDesignationNo;  // �^���w��ԍ�
        private Int32 _CategoryNo;          // �ޕʋ敪�ԍ�
        private CarModel _CarModel;         // �ԗ��^��
        private EngineModel _EngineModel;   // �G���W���^��
        private string _ModelPlate;         // ���f���v���[�g
        /// <summary>�����\���敪�P</summary>
        /// <remarks>0:����@1:�a��i�N���j</remarks>
        private Int32 _eraNameDispCd1;
        // --- ADD m.suzuki 2010/04/21 ---------->>>>>
        private bool _freeSearchModelOnly; // ���R�����^���̂ݒ��o�敪
        // --- ADD m.suzuki 2010/04/21 ----------<<<<<
        # endregion

        /// <summary>
        /// �ԗ����������N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>�ԗ����������N���X�̃R���X�g���N�^</remarks>
        public CarSearchCondition()
        {
            _CarModel = new CarModel();
            _EngineModel = new EngineModel();
            Clear();
        }

        /// <summary>
        /// �ԗ����������N���X�f�X�g���N�^
        /// </summary>
        ~CarSearchCondition()
        {
            _CarModel = null;
            _EngineModel = null;
        }

        /// <summary>
        /// �ԗ����������N���A���\�b�h
        /// </summary>
        public void Clear()
        {
            _Type = CarSearchType.csNone;
            _MakerCode = 0;
            _ModelCode = 0;
            _ModelSubCode = -1;
            _ModelDesignationNo = 0;
            _CategoryNo = 0;
            _ModelPlate = "";
            _CarModel.Clear();
            _EngineModel.Clear();
        }

        /// <summary>
        /// �ԗ������������e�̃R�s�[���\�b�h
        /// </summary>
        /// <param name="Source">�R�s�[���̎ԗ����������N���X</param>
        public void Assign(CarSearchCondition Source)
        {
            _Type = Source._Type;
            _MakerCode = Source._MakerCode;
            _ModelCode = Source._ModelCode;
            _ModelSubCode = Source._ModelSubCode;
            _ModelDesignationNo = Source._ModelDesignationNo;
            _CategoryNo = Source._CategoryNo;
            _ModelPlate = Source._ModelPlate;
            CarModel.Assign(Source.CarModel);
            EngineModel.Assign(Source.EngineModel);
            _eraNameDispCd1 = Source.EraNameDispCd1;
        }

        /// <summary>
        /// �ԗ������^�C�v�v���p�e�B
        /// </summary>
        public CarSearchType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// ���[�J�[�R�[�h�v���p�e�B
        /// </summary>
        public Int32 MakerCode
        {
            get { return _MakerCode; }
            set { _MakerCode = value; }
        }

        /// <summary>
        /// �Ԏ�R�[�h�v���p�e�B
        /// </summary>
        public Int32 ModelCode
        {
            get { return _ModelCode; }
            set { _ModelCode = value; }
        }

        /// <summary>
        /// �Ԏ�T�u�R�[�h
        /// </summary>
        public Int32 ModelSubCode
        {
            get { return _ModelSubCode; }
            set { _ModelSubCode = value; }
        }

        /// <summary>
        /// �^���w��ԍ��v���p�e�B
        /// </summary>
        public Int32 ModelDesignationNo
        {
            get { return _ModelDesignationNo; }
            set { _ModelDesignationNo = value; }
        }

        /// <summary>
        /// �ޕʋ敪�ԍ��v���p�e�B
        /// </summary>
        public Int32 CategoryNo
        {
            get { return _CategoryNo; }
            set { _CategoryNo = value; }
        }

        /// <summary>
        /// ���f���v���[�g�v���p�e�B
        /// </summary>
        public String ModelPlate
        {
            get { return _ModelPlate; }
            set { _ModelPlate = value.ToUpper(); }
        }

        /// <summary>
        /// �^���v���p�e�B
        /// </summary>
        public CarModel CarModel
        {
            get { return _CarModel; }
        }

        /// <summary>
        /// �G���W���^���v���p�e�B
        /// </summary>
        public EngineModel EngineModel
        {
            get { return _EngineModel; }
            set { _EngineModel = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>0:����@1:�a��i�N���j</value>
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

        // --- ADD m.suzuki 2010/04/21 ---------->>>>>
        /// <summary>
        /// ���R�����^���̂ݒ��o�敪
        /// </summary>
        public bool FreeSearchModelOnly
        {
            get { return _freeSearchModelOnly; }
            set { _freeSearchModelOnly = value; }
        }
        // --- ADD m.suzuki 2010/04/21 ----------<<<<<

        /// <summary>
        /// ���������ݒ芮���v���p�e�B
        /// </summary>
        /// <remarks>
        /// ���������������o���Ă���ꍇ�� true ��Ԃ��܂��B
        /// �������o���Ă��Ȃ��ꍇ�� false ��Ԃ��܂��B
        /// </remarks>
        public bool IsReady
        {
            get
            {
                bool _ret = false;

                switch (_Type)
                {
                    // �ޕʌ�������
                    case CarSearchType.csCategory:
                        // �^���w��ԍ���0�ȏ�ł���΁A�ޕʋ敪�ԍ��� 0 �ł��\��Ȃ��B
                        _ret = _ModelDesignationNo > 0;
                        break;
                    // �^����������
                    case CarSearchType.csModel:
                        if (_CarModel.IsFullModel)
                        {
                            // �t���^���Ɣ��f���ꂽ�ꍇ
                            _ret = true;
                        }
                        else
                        {
                            // �V���[�Y�^���Ɣ��f���ꂽ�ꍇ
                            _ret = _CarModel.SeriesModel != "";
                        }
                        break;
                    // �G���W���^����������
                    case CarSearchType.csEngineModel:
                        _ret = _EngineModel.ModelNm != "";
                        break;
                    default:
                        break;
                }

                return _ret;
            }
        }
    }
}
