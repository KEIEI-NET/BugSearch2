using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���{�G�f�B�^�A�C�e���i���Ӑ�p�j
    /// </summary>
	public class ComboEditorItemCustomer : IComparable
	{
		// ===================================================================================== //
		// �R���X�g���N�^
        // ===================================================================================== //
        # region [�R���X�g���N�^]
        /// <summary>
		/// �R���X�g���N�^
		/// </summary>
        public ComboEditorItemCustomer()
		{
			//
		}
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="code"></param>
		/// <param name="name"></param>
		public ComboEditorItemCustomer(int code, string name)
		{
			this._code = code;
			this._name = name;
        }
        # endregion

        # region [private �t�B�[���h]
        /// <summary>�R�[�h</summary>
        private int _code = 0;
        /// <summary>����</summary>
        private string _name = string.Empty;
        # endregion

        # region [public �v���p�e�B]
        /// <summary>
        /// �R�[�h
        /// </summary>
        public int Code
		{
			get{ return this._code; }
			set{ this._code = value; }
		}
        /// <summary>
        /// ����
        /// </summary>
		public string Name
		{
			get{ return this._name; }
			set{ this._name = value; }
        }
        # endregion

        // ===================================================================================== //
		// IComparable �����o
		// ===================================================================================== //
		#region IComparable �����o
		/// <summary>
		/// ��r����
		/// </summary>
		/// <param name="obj">�ΏۃI�u�W�F�N�g</param>
		/// <returns>��r����</returns>
		/// <remarks>
		/// <br>Note�@�@�@: �\�[�g�p�̔�r�����ł��B</br>
		/// <br>Programer : 980076 �Ȓ� ����Y</br>
		/// </remarks>
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			ComboEditorItemCustomer comboEditorItemCustomer = obj as ComboEditorItemCustomer;
			if (comboEditorItemCustomer == null) return 1;

			return this.Code.CompareTo(comboEditorItemCustomer.Code);
		}
		#endregion
	}
}
