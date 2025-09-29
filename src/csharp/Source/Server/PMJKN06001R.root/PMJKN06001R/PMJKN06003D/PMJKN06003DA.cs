using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchModelSCndtnWork
    /// <summary>
    ///                      ���R�����^�����o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R�����^�����o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/04/19</br>
    /// <br>Genarated Date   :   2010/04/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchModelSCndtnWork
    {
        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^/�����l:-1</remarks>
        private Int32 _modelSubCode = -1;

        /// <summary>�r�K�X�L��</summary>
        private string _exhaustGasSign = "";

        /// <summary>�V���[�Y�^��</summary>
        private string _seriesModel = "";

        /// <summary>�^���i�ޕʋL���j</summary>
        private string _categorySignModel = "";

        /// <summary>�G���W���^������</summary>
        /// <remarks>�^���ɂ��ϓ�</remarks>
        private string _engineModelNm = "";

        /// <summary>���f���v���[�g</summary>
        private string _modelPlate;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>���R�����^���Œ�ԍ��z��</summary>
        private string[] _freeSrchMdlFxdNos;

        /// <summary>�������[�h</summary>
        private Int32 _searchMode;

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

        /// public propaty name  :  EngineModelNm
        /// <summary>�G���W���^�����̃v���p�e�B</summary>
        /// <value>�^���ɂ��ϓ�</value>
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

        /// public propaty name  :  ModelPlateNo
        /// <summary>���f���v���[�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���f���v���[�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelPlate
        {
            get { return _modelPlate; }
            set { _modelPlate = value; }
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

        /// public propaty name  :  FreeSrchMdlFxdNos
        /// <summary>���R�����^���Œ�ԍ��z��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] FreeSrchMdlFxdNos
        {
            get { return _freeSrchMdlFxdNos; }
            set { _freeSrchMdlFxdNos = value; }
        }

        /// public propaty name  :  SearchMode
        /// <summary>�������[�h�v���p�e�B[0:�Ԏ��� /1:�^�����]</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchMode
        {
            get { return _searchMode; }
            set { _searchMode = value; }
        }

        /// <summary>
        /// ���q�^�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FreeSearchModelSCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchModelSCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FreeSearchModelSCndtnWork()
        {
        }

    }
}
