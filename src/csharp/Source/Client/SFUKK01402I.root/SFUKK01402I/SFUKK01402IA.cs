using System;
using System.Collections;

namespace Broadleaf.Application.Common
{
	#region IDepositInputMDIChild �������͌n�̂l�c�h�q��ʂŎ������Ȃ���΂����Ȃ����\�b�h��`
	/// <summary>
	/// �l�c�h�q��ʃC���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������͌n�̂l�c�h�q��ʂŎ������Ȃ���΂����Ȃ����\�b�h��`�ł��B</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// <br>Update Note: 2008.02.21 20081 �D�c �E�l DC.NS�p�ɕύX</br>
    /// <br>Update Note: 2012/12/24 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33741�̑Ή�</br>
	/// </remarks>
	public interface IDepositInputMDIChild
	{
		#region Event
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		event ParentToolbarDepositSettingEventHandler ParentToolbarSettingEvent;

		/// <summary>
		/// �I�����_�擾�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		event GetDepositSelectSectionCodeEventHandler GetSelectSectionCodeEvent;

        /// <summary>
        /// �v�㋒�_���̃C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���C����ʂŎ擾�����v�㋒�_���̂��t���[���ɓn���܂��B</br>
        /// <br>Programer  : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.02.20</br>
        /// </remarks>
        event HandOverDepositAddUpSecNameEventHandler HandOverAddUpSecNameEvent;
		#endregion

		# region Property
		/// <summary>�V�K�{�^���L�������v���p�e�B</summary>
		bool NewButton		{get;}

		/// <summary>�ۑ��{�^���L�������v���p�e�B</summary>
		bool SaveButton		{get;}

		/// <summary>�폜�{�^���L�������v���p�e�B</summary>
		bool DeleteButton	{get;}

		/// <summary>�ԓ`�{�^���L�������v���p�e�B</summary>
		bool AkaButton		{get;}

		/// <summary>�̎������s�{�^���L�������v���p�e�B</summary>
		bool ReceiptPrintButton { get;}

        bool RenewalButton { get;}
        // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
        // <summary>�`�[�ԍ��ďo�{�^���L�������v���p�e�B</summary>
        bool ReadSlipButton { get;}
        // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
		# endregion

		# region Methods
		/// <summary>
		/// Control.Show ���\�b�h�̃I�[�o�[���[�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : object�^�̈������󂯎��A�R���g���[�������[�U�[�ɑ΂��ĕ\�����܂��B
		///					 �������g�p���Ȃ��ꍇ�́A���\�b�h����[this.show();]�݂̂��L�q���ĉ������B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void Show(object parameter);

		/// <summary>
		/// �\���ʒm����
		/// </summary>
		/// <param name="mode">�N�����[�h 0:���Ӑ�R�[�h�w��, 1:�󒍔ԍ��w��</param>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0������</param>
		/// <param return="int">0���ُ�</param>
		/// <remarks>
		/// <br>Note       : �l�c�h�e��ʂ���\���w�����s�����ꍇ�ɔ�������C�x���g</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	ShowData(int mode, object[] parameter);

		/// <summary>
		/// �^�u�ύX�O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK</param>
		/// <param return="int">0��NG �^�u�ύX�s��</param>
		/// <remarks>
		/// <br>Note       : �^�u�ύX���s����O�ɁA�ύX�������邩�̔��f���s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	BeforeTabChange(object parameter);

		/// <summary>
		/// ���_�ύX�O�ʒm����
		/// </summary>
		/// <param return="int">0��OK</param>
		/// <param return="int">0��NG ���_�ύX�s��</param>
		/// <remarks>
		/// <br>Note       : ���_�ύX���A�ύX�������邩�̔��f���s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int BeforeSectionChange();

		/// <summary>
		/// ���_�ύX��ʒm����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���_�ύX��̏������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void AfterSectionChange();

		/// <summary>
		/// �I���O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK</param>
		/// <param return="int">0��NG</param>
		/// <remarks>
		/// <br>Note       : �I������O�ɁA�ύX�������邩�̔��f���s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		int	BeforeClose(object parameter);

		/// <summary>
		/// �V�K����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�K���͏������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void NewDepositProc();

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ۑ��������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void SaveDepositProc();

		/// <summary>
		/// �폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �폜�������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void DeleteDepositProc();

		/// <summary>
		/// �ԓ`����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ԓ`�������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void AkaDepositProc();

		/// <summary>
		/// �̎������s����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �̎������s�������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		void ReceiptPrintProc();

        void RenewalProc();

        /// <summary>
        /// �`�[�ԍ��ďo�����B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ďo�������s���܂��B</br>
        /// <br>Programer  : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        void ReadSlipProc();
        
		# endregion
	}
	#endregion

	#region �f���Q�[�g     
	/// <summary>
	/// �c�[���o�[�{�^������
	/// </summary>
	/// <param name="sender">�I�u�W�F�N�g</param>
	/// <remarks>
	/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// </remarks>
	public delegate void ParentToolbarDepositSettingEventHandler(object sender);

	/// <summary>
	/// ���_�R�[�h�擾
	/// </summary>
	/// <param name="sender">�I�u�W�F�N�g</param>
	/// <remarks>
	/// <br>Note       : �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
	/// <br>Programer  : 97036 amami</br>
	/// <br>Date       : 2005.07.30</br>
	/// </remarks>
	public delegate string GetDepositSelectSectionCodeEventHandler(object sender);

    /// <summary>
    /// �v�㋒�_����
    /// </summary>
    /// <param name="sender">�I�u�W�F�N�g</param>
    /// <param name="sectionName">�v�㋒�_����</param>
    /// <remarks>
    /// <br>Note       : ���C����ʂŎ擾�����v�㋒�_���̂��t���[���ɓn���܂��B</br>
    /// <br>Programer  : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.02.20</br>
    /// </remarks>
    public delegate void HandOverDepositAddUpSecNameEventHandler(object sender, string sectionName);
	#endregion
}
