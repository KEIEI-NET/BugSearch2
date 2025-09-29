using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   NoteGuidSet
    /// <summary>
    ///                      ���l�K�C�h�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���l�K�C�h�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class NoteGuidSet 
    {
        /// <summary>���l�K�C�h�敪</summary>
        private Int32 _noteGuideDivCode;

        /// <summary>���l�K�C�h�敪����</summary>
        private string _noteGuideDivName = "";

        /// <summary>���l�K�C�h�R�[�h</summary>
        private Int32 _noteGuideCode;

        /// <summary>���l�K�C�h����</summary>
        private string _noteGuideName = "";


        /// public propaty name  :  NoteGuideDivCode
        /// <summary>���l�K�C�h�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�K�C�h�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoteGuideDivCode
        {
            get { return _noteGuideDivCode; }
            set { _noteGuideDivCode = value; }
        }

        /// public propaty name  :  NoteGuideDivName
        /// <summary>���l�K�C�h�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�K�C�h�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NoteGuideDivName
        {
            get { return _noteGuideDivName; }
            set { _noteGuideDivName = value; }
        }

        /// public propaty name  :  NoteGuideCode
        /// <summary>���l�K�C�h�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�K�C�h�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NoteGuideCode
        {
            get { return _noteGuideCode; }
            set { _noteGuideCode = value; }
        }

        /// public propaty name  :  NoteGuideName
        /// <summary>���l�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NoteGuideName
        {
            get { return _noteGuideName; }
            set { _noteGuideName = value; }
        }

        /// <summary>
        /// ���l�K�C�h�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NoteGuidSet Clone()
        {
            return new NoteGuidSet(this._noteGuideDivCode, this._noteGuideDivName, this._noteGuideCode, this._noteGuideName);
        }

        /// <summary>
		/// ���l�K�C�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoteGuidSet()
		{
		}

        /// <summary>
        /// ���l�K�C�h�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="NoteGuideDivCode"></param>
        /// <param name="NoteGuideDivName"></param>
        /// <param name="NoteGuideCode"></param>
        /// <param name="NoteGuideName"></param>
        public NoteGuidSet(Int32 NoteGuideDivCode, string NoteGuideDivName, Int32 NoteGuideCode, string NoteGuideName)
        {
            this._noteGuideDivCode = NoteGuideDivCode;
            this._noteGuideDivName = NoteGuideDivName;
            this._noteGuideCode = NoteGuideCode;
            this._noteGuideName = NoteGuideName;
        }
    }
}
