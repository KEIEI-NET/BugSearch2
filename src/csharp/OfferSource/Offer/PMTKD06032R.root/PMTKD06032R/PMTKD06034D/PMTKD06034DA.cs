using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferPrimeBlSearchCondWork
    /// <summary>
    ///                      �D�ǂa�k�R�[�h���������N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�ǂa�k�R�[�h���������N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/06/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferPrimeBlSearchCondWork
    {
        /// <summary>BL�R�[�h</summary>
        /// <remarks>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�ԃ��[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�V���[�Y�^��</summary>
        /// <remarks>�^���P</remarks>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private List<string> _categorySignModel = new List<string>();

        /// <summary>�J�n���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private List<Int32> _stProduceTypeOfYear = new List<int>();

        /// <summary>�I�����Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private List<Int32> _edProduceTypeOfYear = new List<int>();

        /// <summary>���Y�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _ProduceTypeOfYear = 0;

        /// <summary>���Y�ԑ�ԍ��J�n</summary>
        private List<Int32> _stProduceFrameNo = new List<int>();

        /// <summary>���Y�ԑ�ԍ��I��</summary>
        private List<Int32> _edProduceFrameNo = new List<int>();

        /// <summary>���Y�ԑ�ԍ�</summary>
        private Int32 _ProduceFrameNo = 0;

        /// <summary>�^���O���[�h����</summary>
        private List<string> _modelGradeNm = new List<string>();

        /// <summary>�{�f�B�[����</summary>
        private List<string> _bodyName = new List<string>();

        /// <summary>�h�A��</summary>
        private List<Int32> _doorCount = new List<int>();

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private List<string> _engineModelNm = new List<string>();

        /// <summary>�r�C�ʖ���</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private List<string> _engineDisplaceNm = new List<string>();

        /// <summary>E�敪����</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private List<string> _eDivNm = new List<string>();

        /// <summary>�~�b�V��������</summary>
        private List<string> _transmissionNm = new List<string>();

        /// <summary>�V�t�g����</summary>
        private List<string> _shiftNm = new List<string>();

        /// <summary>�쓮��������</summary>
        private List<string> _wheelDriveMethodNm = new List<string>();


        /// public property name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>�B�������ŗD�ǐݒ�}�X�^���`�F�b�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public property name  :  MakerCode
        /// <summary>�ԃ��[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԃ��[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public property name  :  ModelCode
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

        /// public property name  :  ModelSubCode
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

        /// public property name  :  SeriesModel
        /// <summary>�V���[�Y�^���v���p�e�B</summary>
        /// <value>�^���P</value>
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

        /// public property name  :  CategorySignModel
        /// <summary>�^���i�ޕʋL���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�ޕʋL���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public property name  :  StProduceTypeOfYear
        /// <summary>�J�n���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> StProduceTypeOfYear
        {
            get { return _stProduceTypeOfYear; }
            set { _stProduceTypeOfYear = value; }
        }

        /// public property name  :  EdProduceTypeOfYear
        /// <summary>�I�����Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> EdProduceTypeOfYear
        {
            get { return _edProduceTypeOfYear; }
            set { _edProduceTypeOfYear = value; }
        }

        /// public property name  :  ProduceTypeOfYear
        /// <summary>���Y�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceTypeOfYear
        {
            get { return _ProduceTypeOfYear; }
            set { _ProduceTypeOfYear = value; }
        }

        /// public property name  :  StProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> StProduceFrameNo
        {
            get { return _stProduceFrameNo; }
            set { _stProduceFrameNo = value; }
        }

        /// public property name  :  EdProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> EdProduceFrameNo
        {
            get { return _edProduceFrameNo; }
            set { _edProduceFrameNo = value; }
        }

        /// public property name  :  ProduceFrameNo
        /// <summary>���Y�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceFrameNo
        {
            get { return _ProduceFrameNo; }
            set { _ProduceFrameNo = value; }
        }

        /// public property name  :  ModelGradeNm
        /// <summary>�^���O���[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���O���[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public property name  :  BodyName
        /// <summary>�{�f�B�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�f�B�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public property name  :  DoorCount
        /// <summary>�h�A���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�A���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        /// public property name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���W���^�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public property name  :  EngineDisplaceNm
        /// <summary>�r�C�ʖ��̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r�C�ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public property name  :  EDivNm
        /// <summary>E�敪���̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public property name  :  TransmissionNm
        /// <summary>�~�b�V�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �~�b�V�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public property name  :  ShiftNm
        /// <summary>�V�t�g���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�t�g���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public property name  :  WheelDriveMethodNm
        /// <summary>�쓮�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쓮�������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }


        /// <summary>
        /// �D�ǂa�k�R�[�h���������N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>OfferPrimeBlSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OfferPrimeBlSearchCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OfferPrimeBlSearchCondWork()
        {
        }

    }
}
