//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������[�nMDI�q��ʃC���^�[�t�F�[�X�N���X
// �v���O�����T�v   : �������[�nMDI�q��ʃC���^�[�t�F�[�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00   �쐬�S�� : ���O
// �� �� ��  2022/04/21    �C�����e : �d�q����2���Ή�
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Common
{
	#region ���@�������[�nMDI�q��ʃC���^�[�t�F�[�X
	/// <summary>
	/// �������[�nMDI�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>Update Note : 2020/04/21 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br> 
	/// </remarks>
    public interface IDemandEbookChild
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
    /// <br>Note        : </br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandEbooksChildMain
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
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// �f�[�^���o����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int ExtractData();

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
        /// <br>Note        : ����������s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int Print(ref object parameter, bool syncFlg);

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        int SyncMain();

        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
        /// <summary>
        /// ���o�����^�u�ɖ߂�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���o�����^�u�ɖ߂���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        void ReturnToExtraCondition();
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
	}
	#endregion
	
	#region ���@�������[�n���ActiveReportType�C���^�[�t�F�[�X
	/// <summary>
	/// �������[�n���ActiveReportType�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note        : </br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandEBooksPrintActiveReportType
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
        /// <br>Note        : ����ɕK�v�ȏ����ݒ����ݒ肵�܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// ����p���ݒ菈��
		/// </summary>
		/// <param name="demandRelatedData">����p���I�u�W�F�N�g</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note        : ���ڃo�C���h���Ȃ�������ɕK�v�ȏ���ݒ肵�܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion

	#region ���@�f���Q�[�g
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);
	#endregion
}
