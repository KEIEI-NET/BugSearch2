using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{
	#region ���@���[�Ɩ�(�������̓^�C�v)�`���[�g�\���p�C���^�t�F�[�X
	/// <summary>
	/// ���[�Ɩ�(�������̓^�C�v)�`���[�g�C���^�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`���[�g�\������ہA�������Ȃ���΂����Ȃ������o��`�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.05</br>
	/// </remarks>
	public interface IPrintConditionInpTypeChart
	{
		#region Property
		
		/// <summary>�`���[�g�{�^���\���ݒ�v���p�e�B</summary>
		/// <value>[True:�\��,False:��\��]</value>
		/// <remarks>�`���[�g�{�^����\�����邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool VisibledChartButton { get;}

		/// <summary>�`���[�g�{�^���L�������ݒ�v���p�e�B</summary>
		/// <value>[True:�L��,False:����]</value>
		/// <remarks>�`���[�g�{�^���\���������邩�ǂ����̐ݒ���擾���܂��B</remarks>
		bool CanChart { get;}
		
		#endregion

		#region Method

		/// <summary>
		/// �`���[�g���o�N���X�I�u�W�F�N�g�擾
		/// </summary>
		/// <param name="chartExtractMemberList">�`���[�g���o�N���X�I�u�W�F�N�g���X�g</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		/// <remarks>
		/// <br>Note       : �O���t�̉�ʏ����̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.03.05</br>
		/// </remarks>
		int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList);
		
		#endregion
	}
	#endregion

	#region ���@�`���[�g���o�N���X�C���^�t�F�[�X
	/// <summary>
	/// �`���[�g���o�N���X�C���^�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`���[�g���o�N���X���쐬����ہA�������Ȃ���΂����Ȃ������o��`�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.03.08</br>
	/// </remarks>
	public interface IChartExtract
	{
		#region Property

		/// <summary>
		/// �`���[�g�쐬�p�����[�^
		/// </summary>
		ChartParamater ChartParamater { get; set;}�@ 

		#endregion

		#region Method

		/// <summary>
		/// �`���[�g�f�[�^�쐬����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="parameter">�ďo�p�����[�^</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int MakeChartData(object sender, object parameter, out string msg);

		/// <summary>
		/// �`���[�g�p�����[�^�擾
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="parameter">�ďo�p�����[�^</param>
		/// <param name="chartInfo">�`���[�g���p�����[�^</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);

		/// <summary>
		/// �h�����_�E���`���[�g�p�����[�^�擾
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="parameter">�ďo�p�����[�^</param>
		/// <param name="chartInfo">�`���[�g���p�����[�^</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);


		/// <summary>
		/// �`���[�g�i���ݏ�����ʋN��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="parameter">�ďo�p�����[�^</param>
		/// <returns>ConstantManagement.MethodResult</returns>
		int ShowCondition(object sender, object parameter);
		
		#endregion
	}


	#endregion


	#region ���@�`���[�g�쐬�p�����[�^�N���X
	/// <summary>
	/// �`���[�g�쐬�p�����[�^
	/// </summary>
	public class ChartParamater
	{
		/// <summary>
		/// �`���[�g�쐬�p�����[�^�R���X�g���N�^
		/// </summary>
		public ChartParamater()
		{
		}

		/// <summary>�ďo�p�����[�^</summary>
		private string _paramater;

		/// <summary>�����{�^���L��</summary>
		private bool _isCondtnButton;

		/// <summary>�h�����_�E���L��</summary>
		private bool _isDrillDown;


		/// <summary>
		/// �ďo�p�����[�^�v���p�e�B
		/// </summary>
		public string Paramater
		{
			get { return this._paramater; }
			set { this._paramater = value; }
		}

		/// <summary>
		/// �����{�^���L���v���p�e�B
		/// </summary>
		public bool IsCondtnButton
		{
			get { return this._isCondtnButton; }
			set { this._isCondtnButton = value; }
		}

		/// <summary>
		/// �h�����_�E���{�^���L���v���p�e�B
		/// </summary>
		public bool IsDrillDown
		{
			get { return this._isDrillDown; }
			set { this._isDrillDown = value; }
		}
	}
	#endregion
}
