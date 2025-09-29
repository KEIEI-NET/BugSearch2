using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBOSearchCondWork
    /// <summary>
    ///                      �񋟎��q��񌋍����������N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟎��q��񌋍����������N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchCondWork
    {
        /// <summary>BL�R�[�h</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>��������</summary>
        private string[] _equipName;

        /// <summary>��������</summary>
        private Int32 _equipGenreCode;

        /// <summary>�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]</summary>
        private Int32 _carMakerCd;

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>�������̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  EquipGenreCode
        /// <summary>�������ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  CarMakerCd
        /// <summary>�����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�������p�ԃ��[�J�[�R�[�h[0�̏ꍇ�͌����i�������Ȃ�]�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCd
        {
            get { return _carMakerCd; }
            set { _carMakerCd = value; }
        }

        /// <summary>
        /// �񋟎��q��񌋍����������N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TBOSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchCondWork()
        {
        }

    }
}
