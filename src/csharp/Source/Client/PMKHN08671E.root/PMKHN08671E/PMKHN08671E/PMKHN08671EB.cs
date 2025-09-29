using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ModelNameSet
    /// <summary>
    ///                      �Ԏ�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �Ԏ�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class ModelNameSet
    {
        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ�S�p����</summary>
        /// <remarks>�������́i�J�i�������݂őS�p�Ǘ��j</remarks>
        private string _modelFullName = "";

        /// <summary>�Ԏ피�p����</summary>
        /// <remarks>�������́i���p�ŊǗ��j</remarks>
        private string _modelHalfName = "";

        /// <summary>�Ԏ�Ăі�����</summary>
        /// <remarks>�Ăі��i�����ŊǗ��j</remarks>
        private string _modelAliasName = "";


        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  ModelAliasName
        /// <summary>�Ԏ�Ăі����̃v���p�e�B</summary>
        /// <value>�Ăі��i�����ŊǗ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�Ăі����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelAliasName
        {
            get { return _modelAliasName; }
            set { _modelAliasName = value; }
        }

        /// <summary>
        /// �Ԏ�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ModelNameSet Clone()
        {
            return new ModelNameSet(this._makerCode, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._modelAliasName);
        }

        /// <summary>
        /// �Ԏ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ModelNameSet()
        {
        }

        /// <summary>
        /// �Ԏ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="MakerCode"></param>
        /// <param name="ModelCode"></param>
        /// <param name="ModelSubCode"></param>
        /// <param name="ModelFullName"></param>
        /// <param name="ModelHalfName"></param>
        /// <param name="ModelAliasName"></param>
        public ModelNameSet(Int32 MakerCode, Int32 ModelCode, Int32 ModelSubCode, string ModelFullName, string ModelHalfName, string ModelAliasName)
        {
            this._makerCode = MakerCode;
            this._modelCode = ModelCode;
            this._modelSubCode = ModelSubCode;
            this._modelFullName = ModelFullName;
            this._modelHalfName = ModelHalfName;
            this._modelAliasName = ModelAliasName;
        }
    }
}
