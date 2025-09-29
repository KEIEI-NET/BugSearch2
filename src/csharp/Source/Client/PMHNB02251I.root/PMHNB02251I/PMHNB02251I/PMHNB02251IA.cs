//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���������s(����)
// �v���O�����T�v   : ���������s(����)�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Common
{
	#region ���@���������s(����)�nMDI�q��ʃC���^�[�t�F�[�X
	/// <summary>
    /// ���������s(����)�nMDI�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br></br>
	/// </remarks>
	public interface ISumDemandTbsMDIChild
	{
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		void Show(object parameter);
	}
	#endregion

    #region ���@���������s(����)�nMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
    /// <summary>
    /// ���������s(����)�nMDI�q��ʏ������̓��C����ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br></br>
	/// </remarks>
	public interface ISumDemandTbsMDIChildMain
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
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// �f�[�^���o����
		/// </summary>
		/// <param name="printKind">���[���[1:�����ꗗ,2:���v������,3:���א�����]</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B
		/// </remarks>
		int ExtractData(int printKind);

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B
		/// </remarks>
		int Print(ref object parameter);
	
		/// <summary>
		/// ������ޕύX����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ������ޕύX���̏������s���܂��B
		/// </remarks>
		void ChangePrintType(int printType);
	}
	#endregion
	
	#region ���@���������s(����)�n���ActiveReportType�C���^�[�t�F�[�X
	/// <summary>
	/// ���������s(����)�n���ActiveReportType�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br></br>
	/// </remarks>
	public interface ISumDemandPrintActiveReportType
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
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion

	#region ���@�f���Q�[�g
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);
	#endregion
}
