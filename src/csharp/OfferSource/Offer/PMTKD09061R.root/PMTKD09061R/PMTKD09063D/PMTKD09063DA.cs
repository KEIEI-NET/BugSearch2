using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
	
namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrJoinPartsCondWork
	/// <summary>
	///                      ���[�U�[�����������o�����N���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[�����������o�����N���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/04  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OfrPartsCondWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�n�C�t���t���i�i��</summary>
		private string _prtsNo = "";

        /// <summary>���i�ԁi�����A�Z�b�g�̌��i�ԁj</summary>
        private string _prtsNoOrg = "";

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

		/// public propaty name  :  PrtsNo
		/// <summary>�n�C�t���t���i�i�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n�C�t���t���i�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtsNo
		{
			get { return _prtsNo; }
			set { _prtsNo = value; }
		}

        /// public propaty name  :  PrtsNoOrg
        /// <summary>���i�ԁi�����A�Z�b�g�̌��i�ԁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԁi�����A�Z�b�g�̌��i�ԁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtsNoOrg
        {
            get { return _prtsNoOrg; }
            set { _prtsNoOrg = value; }
        }

		/// <summary>
		/// ���[�U�[�����������o�����N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UsrJoinPartsCondWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public OfrPartsCondWork()
		{
		}
	}
}
