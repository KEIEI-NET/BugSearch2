using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �|���}�X�^�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|���}�X�^�p�C���^�[�t�F�[�X�̒�`</br>
    /// <br>Programer	: 30414 �E �K�j</br>
    /// <br>Date		: 2008/09/25</br>
    /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
    /// <br>              �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
    /// <br>Update Note : 2011/08/05 �A��265 caohh</br>
    /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
    /// </remarks>
    public interface IRateMDIChild
    {
        #region �� �C�x���g
        /// <summary>
        /// �c�[���o�[�{�^������C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        event ParentToolbarRateSettingEventHandler ParentToolbarRateSettingEvent;
        #endregion

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsClose { get; }

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsNew { get; }

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsSave { get; }

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsDelete { get; }

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsRevival { get; }

        /// <summary> �ۑ��{�^��Enable�v���p�e�B </summary>
        bool IsRenewal { get; }
        //-----ADD 2010/08/10---------->>>>>
        /// <summary> Guide�{�^��Enable�v���p�e�B </summary>
        bool IsGuide { get; }
        //-----ADD 2010/08/10----------<<<<<
        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary> SetUp�{�^��Enable�v���p�e�B </summary>
        bool IsSetUp { get; }
        //-----ADD caohh 2011/08/05 ----------<<<<<

        #region �� Public Method
        /// <summary>
        /// �I���O����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �I���O�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int BeforeClose(object parameter);

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �ۑ��������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Save(object parameter);

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �V�K�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int New(object parameter);

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �폜�������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Delete(object parameter);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �����������s��</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Revival(object parameter);

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �ŐV�����擾����</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        int Renewal(object parameter);

        //-----ADD 2010/08/10---------->>>>>
        /// <summary>
        /// �K�C�h�擾����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �K�C�h���擾����</br>
        /// <br>Programer  : �k���r</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        int Guide(object parameter);
        //-----ADD 2010/08/10----------<<<<<

        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary>
        /// �ݒ�擾����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �ݒ���擾����</br>
        /// <br>Programer  : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        int SetUp(object parameter);
        //-----ADD caohh 2011/08/05 ----------<<<<<
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
    /// <br>Date       : 2008/09/25</br>
    /// </remarks>
    public delegate void ParentToolbarRateSettingEventHandler(object targetForm);
    #endregion

}
