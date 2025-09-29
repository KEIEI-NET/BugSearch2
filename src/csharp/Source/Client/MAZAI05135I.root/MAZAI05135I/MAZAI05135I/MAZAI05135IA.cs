//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I������
// �v���O�����T�v   : �I�����͗p�C���^�[�t�F�[�X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �� �� ��  2007/04/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : kubo
// �C �� ��  2007/07/25  �C�����e : �c�[���o�[�{�^������C�x���g�A�f���Q�[�g�ǉ�
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�C���{�^��Enable�v���p�e�B�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/14  �C�����e : �s��Ή�[13260]�@BeforeSave()�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ��
// �C �� ��  2015/04/27 �C�����e : Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ�����
//                                  Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �I�������̓C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �I�������͗p�C���^�[�t�F�[�X�̒�`</br>
    /// <br>Programer	: 22013 kubo</br>
    /// <br>Date		: 2007.04.05</br>
    /// <br>Update Note	: 2007.07.25 22013 kubo </br>
    /// <br>			:	�E�c�[���o�[�{�^������C�x���g�A�f���Q�[�g�ǉ� </br>
    /// <br>			:	�E�C���{�^��Enable�v���p�e�B�ǉ�</br>
    /// <br>            : 2009/05/14 �Ɠc �M�u�@�s��Ή�[13260]�@BeforeSave()�ǉ�</br>
	/// </remarks>
	public interface IInventInputMdiChild
	{
		#region �� �C�x���g
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
		#endregion

		#region �� Public Property
		/// <summary> ��ƃR�[�h�v���p�e�B </summary>
		string EnterpriseCode { set; }

		/// <summary> ���O�C�����_�R�[�h�v���p�e�B </summary>
		string SectionCode { set; }

		/// <summary> ���O�C�����_���̃v���p�e�B </summary>
		string SectionName { set; }

		/// <summary> ����{�^��Enable�v���p�e�B </summary>
		bool IsCansel { get; }

		/// <summary> ���o�{�^��Enable�v���p�e�B </summary>
		bool IsExtract { get; }

		/// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
		bool IsSave { get; }

		/// <summary> �ڍו\���{�^��Enable�v���p�e�B </summary>
		bool IsDetail { get; }

		/// <summary> �V�K�I���{�^��Enable�v���p�e�B </summary>
		bool IsNewInvent { get; }

		/// <summary> �o�[�R�[�h�捞�{�^��Enable�v���p�e�B </summary>
		bool IsBarcodeRead { get; }

        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� ----->>>>>
        /// <summary> �i�Ԍ����{�^��Enable�v���p�e�B </summary>
        bool IsGoodsSearch { get; }
        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� -----<<<<<

		/// <summary> �C���{�^��Enable�v���p�e�B </summary>
		bool IsDataEdit { get; }

		#endregion �� Property

		#region �� Public Method
		///// <summary>
		///// Control.Show ���\�b�h�̃I�[�o�[���[�h
		///// </summary>
		///// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		///// <remarks>
		///// <br>Note       : object�^�̈������󂯎��A�R���g���[�������[�U�[�ɑ΂��ĕ\������B
		/////					 �������g�p���Ȃ��ꍇ�́A���\�b�h����[this.show();]�݂̂��L�q���ĉ������B</br>
		///// <br>Programer  : 22013 kubo</br>
		///// <br>Date       : 2007.04.05</br>
		///// </remarks>
		//void Show(object parameter);

		/// <summary>
		/// �\���ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0������, 0���ُ�</param>
		/// <remarks>
		/// <br>Note       : �l�c�h�e��ʂ���\���w�����s�����ꍇ�ɔ�������C�x���g</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	ShowData(object parameter);

		/// <summary>
		/// �^�u�ύX�O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG �^�u�ύX�s��</param>
		/// <remarks>
		/// <br>Note       : �^�u�ύX���s����O�ɁA�ύX�������邩�̔��f���s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeTabChange(object parameter);

		/// <summary>
		/// �I���O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �I������O�ɁA�ύX�������邩�̔��f���s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeClose(object parameter);

		/// <summary>
		/// ���o�O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : ���o����O�ɁA�ύX�������邩�̔��f���s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeExtract(object parameter);

		/// <summary>
		/// ���o����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : ���o�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Extract(ref object parameter);

		/// <summary>
		/// ����O�ʒm����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �������O�ɁA�ύX�������邩�̔��f���s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BeforeCansel(object parameter);

		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : ����������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Cansel(object parameter);

        // ---ADD 2009/05/14 �s��Ή�[13260] ----------------------------->>>>>
        /// <summary>
        /// �ۑ��O����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>0��OK, 0��NG</returns>
        /// <remarks>
        /// <br>Note       : �ۑ�����O�ɁA�ۑ��������邩�̔��f���s��</br>
        /// <br>Programer  : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/14</br>
        /// </remarks>
        int BeforeSave(object parameter);
        // ---ADD 2009/05/14 �s��Ή�[13260] -----------------------------<<<<<

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �ۑ��������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	Save(object parameter);

		/// <summary>
		/// �ڍו\������
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �ڍו\���������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	ShowDetail(object parameter);

		/// <summary>
		/// �V�K�I���f�[�^�쐬����
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �V�K�I���f�[�^�쐬�������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	NewInvent(object parameter);

		/// <summary>
		/// �o�[�R�[�h�ǂݍ��ݏ���
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�h�ǂݍ��ݏ������s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.04.05</br>
		/// </remarks>
		int	BarcodeRead(object parameter);

		/// <summary>
		/// �C������
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <param return="int">0��OK, 0��NG</param>
		/// <remarks>
		/// <br>Note       : �I���s�̏C�����s��</br>
		/// <br>Programer  : 22013 kubo</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		int	DataEdit(object parameter);

        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� ----->>>>>
        /// <summary>
        /// �i�Ԍ���
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �i�Ԍ������s��</br>
        /// <br>Programer  : ��</br>
        /// <br>Date       : 2015/04/27</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/27 �i�Ԍ�����ǉ�</br>
        /// </remarks>
        int GoodsSearch(object parameter);
        // --- ADD �� 2015/04/27 Redmine#45746 �I�����͉�ʂ̒I�����̓^�u�ɕi�Ԍ����{�^����ǉ����� -----<<<<<

        // --- ADD �� 2015/04/27 Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������ ----->>>>>
        /// <summary>
        /// ����O�`�F�b�N
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : ����O�`�F�b�N���s��</br>
        /// <br>Programer  : ��</br>
        /// <br>Date       : 2015/04/29</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00 2015/04/29 ����O�`�F�b�N��ǉ�</br>
        /// </remarks>
        bool ClosingCheck();
        // --- ADD �� 2015/04/27 Redmine#45747 �I�����͉�ʂ��~�{�^���ŕ���ۂɖ��ۑ��̓��̓f�[�^������ꍇ�͌x�����b�Z�[�W��\������ -----<<<<<

		#endregion �� Public Method



	}
	#region �� �f���Q�[�g     
	/// <summary>
	/// �c�[���o�[�{�^������
	/// </summary>
    /// <param name="targetForm">�ڋq�ԗ��I���p�����[�^</param>
	/// <remarks>
    /// <br>Note       : ��ʂ̏��������s���܂��B</br>
	/// <br>Programer  : 22013 kubo</br>
	/// <br>Date       : 2007.07.25</br>
	/// </remarks>
	public delegate void ParentToolbarInventSettingEventHandler(object targetForm);
	#endregion

}
