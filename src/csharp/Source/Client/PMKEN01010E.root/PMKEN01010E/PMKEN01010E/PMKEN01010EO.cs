using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CEquipInfoWork
	/// <summary>
	///                      �������o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �������o���ʃN���X���[�N�t�@�C��</br>
	/// <br>Programmer       :   30290</br>
	/// <br>Date             :   2008/06/04</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CEquipInfoWork
	{
		/// <summary>�����\������</summary>
		private Int32 _equipmentDispOrder;

		/// <summary>�������ރR�[�h</summary>
		private Int32 _equipmentGenreCd;

		/// <summary>�������ޖ���</summary>
		private string _equipmentGenreNm = "";

		/// <summary>�����R�[�h</summary>
		private Int32 _equipmentCode;

		/// <summary>��������</summary>
		private string _equipmentName = "";

		/// <summary>��������</summary>
		private string _equipmentShortName = "";

		/// <summary>����ICON�R�[�h</summary>
		private Int32 _equipmentIconCode;

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\�����ʃv���p�e�B</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  EquipmentGenreCd
		/// <summary>�������ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ރR�[�h�v���p�e�B</br>
		/// </remarks>
		public Int32 EquipmentGenreCd
		{
			get { return _equipmentGenreCd; }
			set { _equipmentGenreCd = value; }
		}

		/// public propaty name  :  EquipmentGenreNm
		/// <summary>�������ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ޖ��̃v���p�e�B</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
		}

		/// public propaty name  :  EquipmentCode
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// </remarks>
		public Int32 EquipmentCode
		{
			get { return _equipmentCode; }
			set { _equipmentCode = value; }
		}

		/// public propaty name  :  EquipmentName
		/// <summary>�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������̃v���p�e�B</br>
		/// </remarks>
		public string EquipmentName
		{
			get { return _equipmentName; }
			set { _equipmentName = value; }
		}

		/// public propaty name  :  EquipmentShortName
		/// <summary>�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������̃v���p�e�B</br>
		/// </remarks>
		public string EquipmentShortName
		{
			get { return _equipmentShortName; }
			set { _equipmentShortName = value; }
		}

		/// public propaty name  :  EquipmentIconCode
		/// <summary>����ICON�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ICON�R�[�h�v���p�e�B</br>
		/// </remarks>
		public Int32 EquipmentIconCode
		{
			get { return _equipmentIconCode; }
			set { _equipmentIconCode = value; }
		}


		/// <summary>
		/// �������o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CEqpDefDspRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// </remarks>
		public CEquipInfoWork()
		{
		}

	}
}
