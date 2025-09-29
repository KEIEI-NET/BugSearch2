using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ȈՃ}�X�����}���`�t�H�[���ҏW�C���^�[�t�F�[�X
	/// </summary>
	public interface ISimpleMasterMaintenanceMulti
	{
		/// <summary>
		/// �I���f�[�^�C���f�b�N�X�v���p�e�B
		/// </summary>
		int DataIndex
		{
			get;
			set;
		}

		/// <summary>
		/// �V�K�ǉ����v���p�e�B
		/// </summary>
		bool AllowNew
		{
			get;
		}

		/// <summary>
		/// �폜���v���p�e�B
		/// </summary>
		bool AllowDelete
		{
			get;
		}

		/// <summary>
		/// �N���[�Y�ۃv���p�e�B
		/// </summary>
		bool CanClose
		{
			get;
			set;
		}

		/// <summary>
		/// �f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="dataSet">�f�[�^�Z�b�g</param>
		/// <param name="dataMember">�f�[�^�����o�[</param>
		void GetDataSet( ref DataSet dataSet, ref string dataMember );

		/// <summary>
		/// �I�v�V�����c�[���擾����
		/// </summary>
		/// <param name="optionTools">�I�v�V�����c�[��</param>
		void GetOptionTools( ref SortedList<string,ToolStripItem> optionTools );

		/// <summary>
		/// �O���b�h��O�ϐݒ�擾����
		/// </summary>
		/// <returns>�O���b�h��O�ϐݒ�f�B�N�V���i���[</returns>
		Dictionary<string,GridColAppearance> GetGridColAppearance();

		/// <summary>
		/// ��������
		/// </summary>
		/// <returns>STATUS</returns>
		int Search();

		/// <summary>
		/// �폜����
		/// </summary>
		/// <returns>STATUS</returns>
		int Delete();

		/// <summary>
		/// �I�v�V�����c�[���R�}���h����
		/// </summary>
		/// <param name="key">�R�}���h�L�[</param>
		/// <param name="owner">System.Forms.IWin32Window ���������A���̃t�H�[�������L����g�b�v���x�� �E�B���h�E��\���I�u�W�F�N�g�B</param>
		void OptionToolCommand( string key, IWin32Window owner );
	}
}
