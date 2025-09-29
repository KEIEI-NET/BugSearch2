using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// ����`�[�����p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����`�[�����̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2007.06.18</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class SalesSearchConstruction
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private int _searchSlipDateStartRangeValue = DEFAULT_SearchSlipDateStartRange_VALUE;
		private int _addUpADateStartRangeValue = DEFAULT_AddUpADateStartRange_VALUE;
		private int _regiProcDateStartRangeValue = DEFAULT_RegiProcDateStartRange_VALUE;
		private int _detailConditionOpenValue = DEFAULT_DetailConditionOpen_VALUE;
		private int _dataChangedAutoSearchValue = DEFAULT_DataChangedAutoSearch_VALUE;
		private int _execAutoSearchValue = DEFAULT_ExecAutoSearch_VALUE;

		private const int DEFAULT_SearchSlipDateStartRange_VALUE = 2;
		private const int DEFAULT_AddUpADateStartRange_VALUE = 0;
		private const int DEFAULT_RegiProcDateStartRange_VALUE = 0;
		private const int DEFAULT_DetailConditionOpen_VALUE = 1;
		private const int DEFAULT_DataChangedAutoSearch_VALUE = 1;
		private const int DEFAULT_ExecAutoSearch_VALUE = 1;
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����`�[�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public SalesSearchConstruction()
		{
			this._searchSlipDateStartRangeValue = DEFAULT_SearchSlipDateStartRange_VALUE;
			this._addUpADateStartRangeValue = DEFAULT_AddUpADateStartRange_VALUE;
			this._regiProcDateStartRangeValue = DEFAULT_RegiProcDateStartRange_VALUE;
			this._detailConditionOpenValue = DEFAULT_DetailConditionOpen_VALUE;
			this._dataChangedAutoSearchValue = DEFAULT_DataChangedAutoSearch_VALUE;
			this._execAutoSearchValue = DEFAULT_ExecAutoSearch_VALUE;
		}

		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X
		/// </summary>
		/// <param name="searchSlipDateStartRangeValue">�`�[���t�͈͎w��</param>
		/// <param name="addUpADateStartRangetValue">�v����͈͎w��</param>
		/// <param name="regiProcDateStartRangeValue">���W�������͈͎w��</param>
		/// <param name="detailConditionOpenValue">�ڍ׏����\��</param>
		/// <param name="dataChangedAutoSearchValue">���o�����ύX����������</param>
		/// <param name="execAutoSearchValue">�N������������</param>
		/// <remarks>
		/// <br>Note       : ����`�[�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2007.01.11</br>
		/// </remarks>
		public SalesSearchConstruction(int searchSlipDateStartRangeValue, int addUpADateStartRangetValue, int regiProcDateStartRangeValue, int detailConditionOpenValue, int dataChangedAutoSearchValue, int execAutoSearchValue)
		{
			this._searchSlipDateStartRangeValue = searchSlipDateStartRangeValue;
			this._addUpADateStartRangeValue = addUpADateStartRangetValue;
			this._regiProcDateStartRangeValue = regiProcDateStartRangeValue;
			this._detailConditionOpenValue = detailConditionOpenValue;
			this._dataChangedAutoSearchValue = dataChangedAutoSearchValue;
			this._execAutoSearchValue = execAutoSearchValue;
		}
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>�`�[���t�͈͎w��</summary>
		public int SearchSlipDateStartRange
		{
			get { return this._searchSlipDateStartRangeValue; }
			set { this._searchSlipDateStartRangeValue = value; }
		}

		/// <summary>�v����͈͎w��</summary>
		public int AddUpADateStartRangeValue
		{
			get { return this._addUpADateStartRangeValue; }
			set { this._addUpADateStartRangeValue = value; }
		}

		/// <summary>���W�������͈͎w��</summary>
		public int RegiProcDateStartRangeValue
		{
			get { return this._regiProcDateStartRangeValue; }
			set { this._regiProcDateStartRangeValue = value; }
		}

		/// <summary>�ڍ׏����\��</summary>
		public int DetailConditionOpenValue
		{
			get { return this._detailConditionOpenValue; }
			set { this._detailConditionOpenValue = value; }
		}

		/// <summary>���o�����ύX����������</summary>
		public int DataChangedAutoSearchValue
		{
			get { return this._dataChangedAutoSearchValue; }
			set { this._dataChangedAutoSearchValue = value; }
		}

		/// <summary>�N������������</summary>
		public int ExecAutoSearchValue
		{
			get { return this._execAutoSearchValue; }
			set { this._execAutoSearchValue = value; }
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// ����`�[�����p���[�U�[�ݒ�N���X��������
		/// </summary>
		/// <returns>����`�[�����p���[�U�[�ݒ�N���X</returns>
		public SalesSearchConstruction Clone()
		{
			return new SalesSearchConstruction(
				this._searchSlipDateStartRangeValue,
				this._addUpADateStartRangeValue,
				this._regiProcDateStartRangeValue,
				this._detailConditionOpenValue,
				this._dataChangedAutoSearchValue,
				this._execAutoSearchValue);
		}
		# endregion
	}
}
