//****************************************************************************//
// �V�X�e��         : ���엚��\�����
// �v���O��������   : ���엚��\����ʃC���^�[�t�F�[�X
// �v���O�����T�v   : ���엚��\����ʂ̃e�L�X�g�o�͗p���ʃC���^�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11202046-00  �쐬�S�� : ���V��
// �� �� ��  K2016/10/28  �C�����e : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ǝ������������̒ǉ��Ή�
//----------------------------------------------------------------------------//

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���엚��\����ʃt�H�[���R���g���[���C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �e�L�X�g�o�͏����Ǝ������������̒ǉ����s���B</br>
    /// <br>Programmer  : ���V��</br>
    /// <br>Date        : K2016/10/28</br>
    /// </remarks>
    public interface IDoTextOutForm
    {
        /// <summary>
        /// �e�L�X�g�o�̓{�^���������̏������s���܂��B
        /// </summary>
        /// <param name="filePath">�t�@�C���p�X</param>
        /// <param name="fileMode">�t�@�C���`��(0:CSV 1:TXT)</param>
        /// <param name="fileCheckFlag">�t�@�C���`�F�b�N�t���O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�͏���</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        int DoTextOut(string filePath, int fileMode, out bool fileCheckFlag, out string errMsg);

        /// <summary>
        /// �ݒ���̐ݒ�
        /// </summary>
        /// <param name="canDisplay">true:�\�\�� false:��\��</param>
        /// <param name="setting"> �ݒ���</param>
        /// <remarks>
        /// <br>Note        : �ݒ���̐ݒ���s���B</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        void TransferSettingInfo(bool canDisplay, object setting);
    }
}
