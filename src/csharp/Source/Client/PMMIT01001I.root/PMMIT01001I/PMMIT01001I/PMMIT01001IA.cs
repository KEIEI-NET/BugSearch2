using System;

namespace Broadleaf.Application.Common
{
	#region �� IEstimateMDIChild�@�C���^�[�t�F�[�X
	/// <summary>
	/// �l�c�h�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������ςl�c�h�q��ʂŎ������Ȃ���΂����Ȃ����\�b�h��`�ł��B</br>
	/// <br>Programer  : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.06.18</br>
	/// <br>Update Note:</br>
    /// <br>2009.03.26 20056 ���n ��� ��12625 �ŐV���{�^���ǉ�</br>
    /// </remarks>
	public interface IEstimateMDIChild
	{
		#region �� �C�x���g
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.06.18</br>
		/// </remarks>
		event ParentToolbarLedgerSettingEventHandler ParentToolbarLedgerSettingEvent;
		#endregion

		#region �� ���\�b�h
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : object�^�̈������󂯎��A�R���g���[�������[�U�[�ɑ΂��ĕ\�����܂��B
		///					 �������g�p���Ȃ��ꍇ�́A���\�b�h����[this.show();]�݂̂��L�q���ĉ������B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void Show(object[] parameters);

		/// <summary>
		/// �������
		/// </summary>
	    /// <returns></returns>
		/// <remarks>
        /// <br>Note       : ����������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
        int Print();

		/// <summary>
		/// ����O�`�F�b�N����
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
        /// <br>Note       : ��������O�`�F�b�N���s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		bool PrintBeforeCheack();

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void InitialScreen();

		/// <summary>
		/// �t�H�[�J�X�߂鏈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X��߂��������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void FocusSet_Return();

		/// <summary>
		/// �t�H�[�J�X�i�ޏ���
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X��i�ޏ������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void FocusSet_Forward();

		/// <summary>
		/// �V�K�쐬
		/// </summary>
		/// <remarks>
		/// <br>Note       : �`�[�V�K�쐬�������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void CreateNewSlip();

		/// <summary>
		/// �`�[�폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �`�[�폜�������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void DeleteSlip();

		/// <summary>
		/// �K�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �K�C�h�N���������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ExecuteGuide();

		/// <summary>
		/// �`�[�ďo����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �`�[�ďo�������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ReadSlip();

		/// <summary>
		/// �`�[���ʏ���
		/// </summary>
		/// <remarks>
		/// <br>Note       : �`�[���ʏ������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void CopySlip();

		/// <summary>
		/// ���i�����ؑ֏���
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i�����ؑ֏������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ChangePartsSearch();

		/// <summary>
		/// ��ʐؑ֏���
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʐؑւ��s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ChangeDisplay();

		/// <summary>
		/// �����o�^����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����o�^�������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void EntryJoinParts();

		/// <summary>
		/// ���ɖ߂�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɖ߂��������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void Undo();

		/// <summary>
		/// �����I��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����I���������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void OrderSelect();

		/// <summary>
		/// �Z�b�g�\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Z�b�g�\���������s���܂��B</br>
		/// <br>Programer  : 21024 ���X�� ��</br>
		/// <br>Date       : 2008.06.18</br>
		/// </remarks>
		void ShowSet();

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �ŐV���擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ŐV���̎擾���s���܂��B</br>
        /// <br>Programer  : 20056 ���n ���</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        void ReNewal();
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

		#region �� �v���p�e�B

		/// <summary>
		/// �߂�{�^���L�������v���p�e�B
		/// </summary>
		bool CanReturnButton { get;}

		/// <summary>
		/// �i�ރ{�^���L�������v���p�e�B
		/// </summary>
		bool CanForwardButton { get;}

		/// <summary>
		/// ����{�^���L�������v���p�e�B
		/// </summary>
		bool CanPrintButton { get;}

		/// <summary>
		/// �V�K�{�^���L�������v���p�e�B
		/// </summary>
		bool CanNewButton { get;}

		/// <summary>
		/// �`�[�폜�{�^���L�������v���p�e�B
		/// </summary>
		bool CanDeleteSlipButton { get;}

		/// <summary>
		/// ����{�^���L�������v���p�e�B
		/// </summary>
		bool CanUndoButton { get;}

		/// <summary>
		/// �K�C�h�{�^���L�������v���p�e�B
		/// </summary>
		bool CanGuideButton { get;}

		/// <summary>
		/// �`�[�ďo�{�^���L�������v���p�e�B
		/// </summary>
		bool CanReadSlipButton { get;}

		/// <summary>
		/// �`�[���ʃ{�^���L�������v���p�e�B
		/// </summary>
		bool CanCopySlipButton { get;}

		/// <summary>
		/// ���i�����ؑփ{�^���L�������v���p�e�B
		/// </summary>
		bool CanChangePartsSearchButton { get;}

		/// <summary>
		/// �����o�^�{�^���L�������v���p�e�B
		/// </summary>
		bool CanEntryJoinPartsButton { get;}

		/// <summary>
		/// �����I���{�^���L�������v���p�e�B
		/// </summary>
		bool CanOrderSelectButton { get;}

		/// <summary>
		/// ��ʐؑփ{�^���L�������v���p�e�B
		/// </summary>
		bool CanChangeDisplayButton { get;}

		/// <summary>
		/// �Z�b�g�{�^���L�������v���p�e�B
		/// </summary>
		bool CanShowSetButton { get;}

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �ŐV���{�^���L�������v���p�e�B
        /// </summary>
        bool CanReNewalButton { get;}
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
	}
	#endregion

	#region �� �f���Q�[�g     
	/// <summary>
	/// �c�[���o�[�{�^������
	/// </summary>
    /// <param name="sender">�ڋq�ԗ��I���p�����[�^</param>
	/// <remarks>
    /// <br>Note       : ��ʂ̏��������s���܂��B</br>
	/// <br>Programer  : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.06.18</br>
	/// </remarks>
	public delegate void ParentToolbarLedgerSettingEventHandler(object sender);
	#endregion

	# region �� �񋓌^
	# endregion
}

