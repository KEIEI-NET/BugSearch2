using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TrimCdRetWork
    /// <summary>
    ///                      �g�������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �g�������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
    /// </remarks>
    public class TrimCdRetWork
    {
        /// <summary>�g�����R�[�h</summary>
        private string _trimCode = "";

        /// <summary>�g��������</summary>
        private string _trimName = "";

        /// public propaty name  :  TrimCode
        /// <summary>�g�����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����R�[�h�v���p�e�B</br>
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
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }


        /// <summary>
        /// �g�������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TrimCdRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrimCdRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// </remarks>
        public TrimCdRetWork()
        {
        }

    }
}
