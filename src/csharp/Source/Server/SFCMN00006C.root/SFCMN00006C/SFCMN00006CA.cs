using System;
using System.Data;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// ���ʒ萔�Ǘ��N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���ʒ萔�Ǘ��N���X�ł��B</br>
	/// <br>Programmer : 96137�@�v�ۓc�@�M��</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: 2008/12/19 PM.NS�p�Ɉꕔ�ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2010/08/16 22018 ��� ���b  �������b�N�^�C���A�E�g�ǉ�</br>
    /// </remarks>
	public class ConstantManagement
	{
		/// <summary>
		/// ���ʒ萔�Ǘ��N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 96137�@�v�ۓc�@�M��</br>
		/// <br>Date       : 2005.03.17</br>
		/// </remarks>
		public ConstantManagement()
		{
		}

		/// <summary>
		/// �X�e�[�^�X
		/// </summary>
		public enum DB_Status
		{
			/// <summary>
			/// ����I��
			/// </summary>
			ctDB_NORMAL	= 0,
			/// <summary>
			/// �������ʖ���
			/// </summary>
			ctDB_NOT_FOUND	= 4,
			/// <summary>
			/// ������EOF�ɒB���� 
			/// </summary>
			ctDB_EOF		= 9,
			/// <summary>
			/// INSERT���ɏd��
			/// </summary>
			ctDB_DUPLICATE	= 5,
			//�����������ۗ�
			//			ctDB_AGNST_REC		= 80,		// ���R�[�h����
			//			ctDB_LOCK_ERR		= 81,		// ���b�N�G���[
			//			ctDB_ALRDY_LOCKREC	= 84,		// ���R�[�h�����b�N�ς�
			//			ctDB_ALRDY_LOCKFILE	= 85,		// �t�@�C�������b�N�ς�
			//�����������ۗ�
			/// <summary>
			/// �r���i�ʒ[���X�V�ρj
			/// </summary>
			ctDB_ALRDY_UPDATE	= 800,
			/// <summary>
			/// �r���i�ʒ[�������폜�ρj
			/// </summary>
			ctDB_ALRDY_DELETE	= 801,
			/// <summary>
			/// �ڑ��^�C���A�E�g
			/// </summary>
			ctDB_CONCT_TIMEOUT  = 810,
            /// <summary>
            /// SQL�R�}���h�^�C���A�E�g
            /// </summary>
            ctDB_SQLCMD_TIMEOUT = 811,

            //--- ADD 2008/12/19 M.Kubota --->>>
            /// <summary>��ƃ��b�N�^�C���A�E�g</summary>
            ctDB_ENT_LOCK_TIMEOUT = 850,
            /// <summary>���_���b�N�^�C���A�E�g</summary>
            ctDB_SEC_LOCK_TIMEOUT = 851,
            /// <summary>�q�Ƀ��b�N�^�C���A�E�g</summary>
            ctDB_WAR_LOCK_TIMEOUT = 852,
            //--- ADD 2008/12/19 M.Kubota ---<<<
            // --- ADD m.suzuki 2010/08/16 ---------->>>>>
            /// <summary>�������b�N�^�C���A�E�g(�W�v��)</summary>
            ctDB_ADU_LOCK_TIMEOUT = 853,
            /// <summary>�������b�N�^�C���A�E�g(�`�[��)</summary>
            ctDB_ADS_LOCK_TIMEOUT = 854,
            // --- ADD m.suzuki 2010/08/16 ----------<<<<<

			/// <summary>
			/// �I�t���C�� �A�N�Z�X�s��
			/// </summary>
			ctDB_OFFLINE		= OnlineMode.Offline,
            /// <summary>
            /// �x������
            /// </summary>
            ctDB_WARNING        = 999,
			/// <summary>
			/// �G���[����
			/// </summary>
			ctDB_ERROR			= 1000
		}


		/// <summary>
		/// �I�����C�����[�h
		/// </summary>
		public enum OnlineMode
		{
			/// <summary>
			/// �I�t���C��
			/// </summary>
			Offline = 900,
			/// <summary>
			/// �I�����C��
			/// </summary>
			Online = 901
		}

		/// <summary>
		/// �_���폜�f�[�^�擾�敪
		/// </summary>
		public enum LogicalMode
		{
			/// <summary>
			/// ���폜�f�[�^�̂ݎ擾
			/// </summary>
			GetData0   = 0,
			/// <summary>
			/// �_���폜�f�[�^�̂ݎ擾
			/// </summary>
			GetData1   = 1,
			/// <summary>
			/// �ۗ��f�[�^�̂ݎ擾
			/// </summary>
			GetData2   = 2,
			/// <summary>
			/// �폜�m��f�[�^�̂ݎ擾
			/// </summary>
			GetData3   = 3,
			/// <summary>
			/// �S�f�[�^�擾
			/// </summary>
			GetDataAll = 4,
			/// <summary>
			/// ���폜�E�_���폜�f�[�^�擾
			/// </summary>
			GetData01  = 5,
			/// <summary>
			/// ���폜�E�_���폜�E�ۗ��f�[�^�擾
			/// </summary>
			GetData012 = 6
		}

		/// <summary>
		/// ���\�b�h�߂�l��`
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���\�b�h�̏������ʂ��`���܂��B</br>
		/// <br>Programer  : 980152  �{�x �F�m</br>
		/// <br>Date       : 2005.07.20</br>
		/// </remarks>
		public enum MethodResult: int
		{
			/// <summary>
			/// ����I��
			/// </summary>
			ctFNC_NORMAL		= 0,
			/// <summary>
			/// ���\�b�h�������ʖ���  (���\�b�h�{���̏������ʂƂ��Ė߂��ׂ��l������ - �������\�b�h�Ō�������0���Ȃ�)
			/// </summary>
			ctFNC_NO_RETURN		= 1,
			/// <summary>
			/// �l�擾�������s    (�ꕔ�̒l�擾�Ɏ��s���� - ���̎擾�ɂ͐����������A�l(���z�E���ʂȂ�)�̎擾�ɂ͎��s�������Ȃ�)
			/// </summary>
			ctFNC_PART_VAL_RTN	= 3,
			/// <summary>
			/// �x���E����        (�G���[�ł͗L�邪�APG�I���ɂ͎���Ȃ�or�d�l�ɂ��I���̏ꍇ)
			/// </summary>
			ctFNC_WARNING		= 5,
			/// <summary>
			/// �ُ�              (�G���[�����ׁ̈APG�I���̏ꍇ)
			/// </summary>
			ctFNC_ERROR			= 9,
			/// <summary>
			/// �L�����Z�� or ���f
			/// </summary>
			ctFNC_CANCEL		= -1,
			/// <summary>
			/// �q��ʁE�@�\�֐��n����̖��߂Ƃ��āA�e�d�w�d�̏I���v�����s���߂�l
			/// </summary>
			ctFNC_DO_END		= 9999
		}

        /// <summary>
        /// �g�����U�N�V�����������x����`
        /// </summary>
        /// <remarks>
        /// <br>Note       : �g�����U�N�V�����̕������x�����`���܂��B</br>
        /// <br>Programer  : 23002  ���@�k��</br>
        /// <br>Date       : 2006.10.10</br>
        /// </remarks>
        public enum DB_IsolationLevel
        {
            ctDB_Default = IsolationLevel.RepeatableRead,
            ctDB_ReadUnCommitted = IsolationLevel.ReadUncommitted,
            ctDB_ReadCommitted = IsolationLevel.ReadCommitted,
            ctDB_RepeatableRead = IsolationLevel.RepeatableRead,
            ctDB_SnapShot = IsolationLevel.Snapshot,
            ctDB_Serializable = IsolationLevel.Serializable
        }
	}
}
