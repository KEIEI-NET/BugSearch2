//using System;
//using System.Collections.Generic;
//using System.Text;
using Broadleaf.Application.UIData;
 
namespace Broadleaf.Application.Common
{

    /// <summary>
    /// ���[�����M�����쐬���C�u��������C���^�t�F�[�X
    /// </summary>
    /// <remarks>
    /// ���[���̑��M�����쐬�Ɋւ��鑀����`���܂�
    /// </remarks>
    public interface IMailSendingHistoryMaker
    {

        /// <summary>
        /// ���[�����M�����쐬
        /// </summary>
        /// <param name="mailSourceData">�����쐬�Ώۃ��[���f�[�^</param>
        /// <returns>�����쐬����</returns>
        int InitializeSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// ���[�����M�����쐬
        /// </summary>
        /// <param name="mailSourceData">�����쐬�Ώۃ��[���f�[�^</param>
        /// <returns>�����쐬����</returns>
        int MakeSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// ���[�����M�����쐬
        /// </summary>
        /// <param name="targetIndex">����Ώۃf�[�^�C���f�b�N�X</param>
        /// <param name="mailSourceData">�����쐬�Ώۃ��[���f�[�^</param>
        /// <returns>�����쐬����</returns>
        int MakeSendingHistory(int targetIndex, ref MailSourceData mailSourceData);


        /// <summary>
        /// ���[�����M�����폜
        /// </summary>
        /// <param name="mailSourceData">�����폜�Ώۃ��[���f�[�^</param>
        /// <returns>�����폜����</returns>
        int DeleteSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// ���[�����M�����폜
        /// </summary>
        /// <param name="targetIndex">����Ώۃf�[�^�C���f�b�N�X</param>
        /// <param name="mailSourceData">�����폜�Ώۃ��[���f�[�^</param>
        /// <returns>�����폜����</returns>
        int DeleteSendingHistory(int targetIndex, ref MailSourceData mailSourceData);


        /// <summary>
        /// ���[�����M�����쐬���C�u�����o�[�W����
        /// </summary>
        string Version { get; }

    }

}
