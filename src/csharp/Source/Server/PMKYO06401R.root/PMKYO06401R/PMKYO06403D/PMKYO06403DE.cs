using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SupplierProcParamWork
	/// <summary>
    ///                      �d����}�X�^���o�������[�N
	/// </summary>
	/// <remarks>
    /// <br>note             :   �d����}�X�^���o�������[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SupplierProcParamWork
	{
		/// <summary>�J�n����</summary>
		private Int64 _beginningDate;

		/// <summary>�I������</summary>
		private Int64 _endingDate;

		/// <summary>�d����(�J�n)</summary>
		private Int32 _supplierCdBegin;

		/// <summary>�d����(�I��)</summary>
		private Int32 _supplierCdEnd;


		/// public propaty name  :  BeginningDate
		/// <summary>�J�n�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int64 UpdateDateTimeBegin
		{
			get{return _beginningDate;}
			set{_beginningDate = value;}
		}

		/// public propaty name  :  EndingDate
		/// <summary>�I�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int64 UpdateDateTimeEnd
		{
			get{return _endingDate;}
			set{_endingDate = value;}
		}

		/// public propaty name  :  SupplierCdBegin
		/// <summary>�d����(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdBeginRF
		{
			get{return _supplierCdBegin;}
			set{_supplierCdBegin = value;}
		}

		/// public propaty name  :  SupplierCdEnd
		/// <summary>�d����(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCdEndRF
		{
			get{return _supplierCdEnd;}
			set{_supplierCdEnd = value;}
		}


		/// <summary>
        /// �d����}�X�^���o�������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SupplierProcParamWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SupplierProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SupplierProcParamWork()
		{
		}

	}
}