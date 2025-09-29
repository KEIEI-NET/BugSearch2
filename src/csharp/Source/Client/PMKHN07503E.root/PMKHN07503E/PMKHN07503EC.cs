using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    //******************************************************************************************
    //
    //  ���̃\�[�X�t�@�C���ɂ́u���[�����M���C�u�����v�Ɋ֘A����N���X, �e��p�����[�^��A
    //  �e���`����������Ă��܂�
    //
    //******************************************************************************************


    /// <summary>
    /// ���[�����M���C�u��������p�����[�^
    /// </summary>
    /// <remarks>
    /// OperationMode �� 0:Automatic �̏ꍇ�� MailInfoBase�̐ݒ�l���g�p����
    /// OperationMode �� 0:Automatic�ȊO(Specify��) �̏ꍇ�� ���̃p�����[�^�̐ݒ�l���g�p����(����Ȃ����ڂ�MailInfoBase�̐ݒ�l�܂��͋K��l���g�p)
    /// </remarks>
    public class MailSenderOperationInfo
    {
        // OperationMode �� Automatic �̏ꍇ�� MailInfoBase�̐ݒ�l���g�p����
        // OperationMode �� Automatic�ȊO(Specify��) �̏ꍇ�� ���̃p�����[�^�̐ݒ�l���g�p����(����Ȃ����ڂ�MailInfoBase�̐ݒ�l�܂��͋K��l���g�p)


        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MailSenderOperationInfo()
        {
            OperationMode = 0;

        }

        /// <summary>
        /// �R���X�g���N�^(���샂�[�h�w��)
        /// </summary>
        /// <param name="operationMode">���샂�[�h 0:Automatic(�f�t�H���g�ݒ�œ��삵�܂�), 1:Specify(�w�肳�ꂽ�v���p�e�B�l���g�p���܂�)  </param>
        public MailSenderOperationInfo(int operationMode)
        {
            OperationMode = operationMode;
        }
        #endregion


        #region �v���p�e�B
        /// <summary>
        /// ���샂�[�h 0:Automatic(�f�t�H���g�ݒ�œ��삵�܂�), 1:Specify(�w�肳�ꂽ�v���p�e�B�l���g�p���܂�)
        /// </summary>
        public int OperationMode = 0;


        // �ȉ��ɊO�����璼�ڑ��삵�Ă��ǂ��ݒ��錾���Ă�������(���ʂ͕s�v)
        // (���[�����M�Ǘ��ݒ�}�X�^�̑S�Ă̍��ڂ͕s�v���Ǝv���܂�)

        /// <summary>
        /// BCC�o�b�N�A�b�v���M true:���M����
        /// </summary>
        public bool SendBccBackup = true;

        /// <summary>
        /// �i���_�C�A���O�\���敪 true:�\������
        /// </summary>
        public bool DispProgressDialog = true;

        /// <summary>
        /// �G���[�_�C�A���O�\���敪 true:�\������
        /// </summary>
        public bool DispErrorDialog = false;

        /// <summary>
        /// ���M�X�e�[�^�X
        /// </summary>
        public int SendStatus = 0;

        /// <summary>
        /// �G���[���b�Z�[�W (���M�X�e�[�^�X�ɑ΂��郁�b�Z�[�W)  
        /// </summary>
        public string StatusMessage = "";


        #endregion

    }
}
