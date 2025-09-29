//using System;
//using System.Collections.Generic;
//using System.Text;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{

    /// <summary>
    /// ���[�����M���C�u��������C���^�t�F�[�X
    /// </summary>
    /// <remarks>
    /// ���[���̑��M���s���e�탉�C�u�����Ɋւ��鑀����`���܂�
    /// </remarks>
    public interface IMailSender
    {

        /// <summary>
        /// ���[�����M
        /// </summary>
        /// <param name="mailSenderOperationInfo">���[�����M���C�u��������p�����[�^</param>
        /// <param name="mailSourceData">���M�Ώۃ��[���f�[�^�\�[�X</param>
        /// <returns>�����X�e�[�^�X</returns>
        int SendMail(ref MailSenderOperationInfo mailSenderOperationInfo, MailSourceData mailSourceData);


        /// <summary>
        /// ���[�����M���C�u�����o�[�W����
        /// </summary>
        string Version{get;}

        /// <summary>
        /// �����I���t���O
        /// </summary>
        bool SendEndFlg{get;}
    
    }



}
