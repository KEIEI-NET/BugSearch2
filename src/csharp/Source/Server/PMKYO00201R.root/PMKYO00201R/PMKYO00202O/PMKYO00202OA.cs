//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ʐM�e�X�g�c�[��
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2014/09/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �f�[�^���M�����pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ʐM�e�X�g�c�[�������pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2014/09/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IAPNSNetworkTestDB
    {
        /// <summary>
        /// �f�[�^�����ݒ�
        /// </summary>
        /// <param name="tusinTestLogList">��������</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�������ݒ肷��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/18</br>
        int SearchLogData(
            ArrayList tusinTestLogList,
            out string retMessage);

        /// <summary>
        /// �f�[�^�����ݒ�
        /// </summary>
        /// <param name="tusinTestLogList">�o�^���e</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�������ݒ肷��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/18</br>
        int InsertLogData(
            ArrayList tusinTestLogList,
            out string retMessage);

    }
}
