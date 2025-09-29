using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UserGdSet
    /// <summary>
    ///                      ���[�U�[�K�C�h�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�U�[�K�C�h�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class UserGdSet 
    {
        /// <summary>�K�C�h�R�[�h</summary>
		private Int32 _guideCode;

		/// <summary>�K�C�h����</summary>
		private string _guideName = "";


		/// public propaty name  :  GuideCode
		/// <summary>�K�C�h�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�C�h�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GuideCode
		{
			get{return _guideCode;}
			set{_guideCode = value;}
		}

		/// public propaty name  :  GuideName
		/// <summary>�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GuideName
		{
			get{return _guideName;}
			set{_guideName = value;}
		}

        /// <summary>
        /// ���[�U�[�K�C�h�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>UserGdSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UserGdSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UserGdSet Clone()
        {
            return new UserGdSet(this._guideCode, this.GuideName);
        }

        /// <summary>
		/// ���[�U�[�K�C�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UserGdSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UserGdSet()
		{
		}
        
        /// <summary>
        /// ���[�U�[�K�C�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="GuideCode"></param>
        /// <param name="GuideName"></param>
        public UserGdSet(Int32 GuideCode, string GuideName)
        {

            this._guideCode = GuideCode;
            this.GuideName = GuideName;
        }
    }
}
