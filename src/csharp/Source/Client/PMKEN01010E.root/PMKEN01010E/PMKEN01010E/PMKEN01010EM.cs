using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ColorCdRetWork
    /// <summary>
    ///                      �J���[���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �J���[���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
    /// </remarks>
    public class ColorCdRetWork
    {
        /// <summary>�J���[�R�[�h</summary>
        /// <remarks>�J�^���O�̐F�R�[�h</remarks>
        private string _colorCode = "";

        /// <summary>�J���[�R�[�h�d�����}��</summary>
        private Int32 _colorCdDupDerivedNo;

        /// <summary>�J���[����1</summary>
        /// <remarks>��ʕ\���p��������</remarks>
        private string _colorName = "";

        /// public propaty name  :  ColorCode
        /// <summary>�J���[�R�[�h�v���p�e�B</summary>
        /// <value>�J�^���O�̐F�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  ColorCdDupDerivedNo
        /// <summary>�J���[�R�[�h�d�����}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[�R�[�h�d�����}�ԃv���p�e�B</br>
        /// </remarks>
        public Int32 ColorCdDupDerivedNo
        {
            get { return _colorCdDupDerivedNo; }
            set { _colorCdDupDerivedNo = value; }
        }

        /// public propaty name  :  ColorName
        /// <summary>�J���[���̃v���p�e�B</summary>
        /// <value>��ʕ\���p��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J���[���̃v���p�e�B</br>
        /// </remarks>
        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }


        /// <summary>
        /// �J���[���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ColorCdRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// </remarks>
        public ColorCdRetWork()
        {
        }

    }
}
