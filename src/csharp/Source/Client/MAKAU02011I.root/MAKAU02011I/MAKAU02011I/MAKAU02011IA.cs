using System;

namespace Broadleaf.Application.Common
{
	#region ���@�������[�nMDI�q��ʃC���^�[�t�F�[�X
	/// <summary>
	/// �������[�nMDI�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChild
	{
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		void Show(object parameter);
	}
	#endregion
    
	#region ���@�������[�nMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
	/// <summary>
	/// �������[�nMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChildMain
	{
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		void Show(object parameter);
		
		/// <summary>
		/// ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// �f�[�^���o����
		/// </summary>
		/// <param name="printKind">���[���[1:�����ꗗ,2:���v������,3:���א�����]</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		int ExtractData(int printKind);

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		int Print(ref object parameter);
	
		/// <summary>
		/// ������ޕύX����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ������ޕύX���̏������s���܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.07</br>
		/// </remarks>
		void ChangePrintType(int printType);
	}
	#endregion
	
	#region ���@�������[�n���ActiveReportType�C���^�[�t�F�[�X
	/// <summary>
	/// �������[�n���ActiveReportType�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.15</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandPrintActiveReportType
	{
		/// <summary>
		/// ����^�C�g��
		/// </summary>
		string Title
		{
			set;
		}
		
		/// <summary>
		/// ������p�����[�^�v���p�e�B
		/// </summary>
		SFCMN06002C PrintInfo
		{
			get;
			set;
		}
		
		/// <summary>
		/// ����p�����ݒ���ݒ�
		/// </summary>
		/// <param name="conditionInfo">�ݒ���I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����ɕK�v�ȏ����ݒ����ݒ肵�܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// ����p���ݒ菈��
		/// </summary>
		/// <param name="demandRelatedData">����p���I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ���ڃo�C���h���Ȃ�������ɕK�v�ȏ���ݒ肵�܂��B
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion

	#region ���@�f���Q�[�g
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);
	#endregion
}
