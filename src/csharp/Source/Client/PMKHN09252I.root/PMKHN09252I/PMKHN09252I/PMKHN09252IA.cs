using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ����ڕW�ݒ�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ����ڕW�ݒ�p�C���^�[�t�F�[�X�̒�`</br>
    /// <br>Programer	: 30414 �E �K�j</br>
    /// <br>Date		: 2008/10/08</br>
    /// </remarks>
    public interface ISalesTargetMDIChild
    {
        #region �� �C�x���g
        /// <summary>
        /// �c�[���o�[�{�^������C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        event ParentToolbarSalesTargetEventHandler ParentToolbarSalesTargetEvent;
        #endregion

        /// <summary> �I���{�^��Visible�v���p�e�B </summary>
        bool IsClose { get; }

        /// <summary> �V�K�{�^��Visible�v���p�e�B </summary>
        bool IsNew { get; }

        /// <summary> �ۑ��{�^��Visible�v���p�e�B </summary>
        bool IsSave { get; }

        /// <summary> �_���폜�{�^��Visible�v���p�e�B </summary>
        bool IsLogicalDelete { get; }

        /// <summary> ���S�폜�{�^��Visible�v���p�e�B </summary>
        bool IsDelete { get; }

        /// <summary> �����{�^��Visible�v���p�e�B </summary>
        bool IsRevival { get; }

        /// <summary> ���ɖ߂��{�^��Visible�v���p�e�B </summary>
        bool IsUndo { get; }

        /// <summary> �䗦����v�Z�{�^��Visible�v���p�e�B </summary>
        bool IsCalc { get; }

        /// <summary> �ŐV���{�^��Visible�v���p�e�B </summary>
        bool IsRenewal { get; }

        #region �� Public Method
        /// <summary>
        /// �I���O����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �I���O�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int BeforeClose();

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �ۑ��������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Save();

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �V�K�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int New();

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �_���폜�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int LogicalDelete();

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �폜�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Delete();

        /// <summary>
        /// ��������
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �����������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Revival();

        /// <summary>
        /// ���ɖ߂�����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : ���ɖ߂��������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Undo();

        /// <summary>
        /// �䗦����v�Z����
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �䗦����v�Z�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Calc();

        /// <summary>
        /// �ŐV��񏈗�
        /// </summary>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �L���b�V���ێ����Ă���f�[�^�̍ŐV�����擾</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        int Renewal();

        /// <summary>
        /// �����t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����t�H�[�J�X�ݒ���s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        void SetFocus();

        #endregion �� Public Method
    }
    #region �� �f���Q�[�g
    /// <summary>
    /// �c�[���o�[�{�^������
    /// </summary>
    /// <param name="targetForm">�p�����[�^</param>
    /// <remarks>
    /// <br>Note       : �c�[���o�[�̐�����s���܂��B</br>
    /// <br>Programer  : 30414 �E �K�j</br>
    /// <br>Date       : 2008/10/08</br>
    /// </remarks>
    public delegate void ParentToolbarSalesTargetEventHandler(object targetForm);
    #endregion

}
