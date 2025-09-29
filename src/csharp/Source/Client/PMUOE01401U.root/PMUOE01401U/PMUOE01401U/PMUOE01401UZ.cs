//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���������f�[�^�e�[�u����\���R���g���[���N���X
// �v���O�����T�v   : �t�n�d�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/12/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �f�[�^�e�[�u����\���R���g���[���N���X
	/// </summary>
	internal class ProductStockRowVisibleControl
	{
		private Dictionary<StockDetailColStatusKey, bool> _statusDictionary = new Dictionary<StockDetailColStatusKey, bool>();

		/// <summary>
		/// ��\����\���ݒ�l�ǉ�����
		/// </summary>
		/// <param name="colName">�񖼏�</param>
		/// <param name="statusType">�X�e�[�^�X�^�C�v</param>
		/// <param name="value">�l</param>
		/// <param name="hidden">�\����\���ݒ�l</param>
		internal void Add(string colName, StatusType statusType, int value, bool hidden)
		{
			StockDetailColStatusKey key = new StockDetailColStatusKey(colName, statusType, value);

			if (this._statusDictionary.ContainsKey(key))
			{
				this._statusDictionary[key] = hidden;
			}
			else
			{
				this._statusDictionary.Add(key, hidden);
			}
		}

		/// <summary>
		/// ��\����\���ݒ�l�擾����
		/// </summary>
		/// <param name="colName">�񖼏�</param>
		/// <param name="statusType">�X�e�[�^�X�^�C�v</param>
		/// <param name="value">�l</param>
		/// <param name="visible">�\����\���ݒ�l</param>
		/// <returns>0:�擾�\ 0�ȊO:�擾���s</returns>
		internal int GetHidden(string colName, StatusType statusType, int value, out bool hidden)
		{
			StockDetailColStatusKey key = new StockDetailColStatusKey(colName, statusType, value);

			if (this._statusDictionary.ContainsKey(key))
			{
				hidden = this._statusDictionary[key];
				return 0;
			}
			else
			{
				hidden = true;
				return -1;
			}
		}
	}

	/// <summary>
	/// �f�[�^�e�[�u����X�e�[�^�X�L�[�\����
	/// </summary>
	internal struct StockDetailColStatusKey
	{
		string _colName;
		StatusType _statusType;
		int _value;

		/// <summary>
		/// �d�����׃f�[�^�e�[�u����X�e�[�^�X�L�[�\���̃R���X�g���N�^
		/// </summary>
		/// <param name="colName">�񖼏�</param>
		/// <param name="statusType">�X�e�[�^�X�^�C�v</param>
		/// <param name="value">�l</param>
		internal StockDetailColStatusKey(string colName, StatusType statusType, int value)
		{
			this._colName = colName;
			this._statusType = statusType;
			this._value = value;
		}

		/// <summary>�񖼏̃v���p�e�B</summary>
		internal string ColName
		{
			get { return _colName; }
			set { _colName = value; }
		}

		/// <summary>�X�e�[�^�X�^�C�v�v���p�e�B</summary>
		internal StatusType StatusType
		{
			get { return _statusType; }
			set { _statusType = value; }
		}

		/// <summary>�l�v���p�e�B</summary>
		internal int Value
		{
			get { return _value; }
			set { _value = value; }
		}
	}

	/// <summary>
	/// �R���{�G�f�B�^�f�[�^�擾�^�C�v
	/// </summary>
	internal enum StatusType : int
	{
		Default = 0,
		StockGoodsCd = 1,
		ProductNumberInput = 2,
		SupplierFormal = 3,
        StockDate = 4,
        StoockDiv = 5

	}
}
