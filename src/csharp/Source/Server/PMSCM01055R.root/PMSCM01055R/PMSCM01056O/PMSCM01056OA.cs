//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�f�[�^��M�����N��DB�C���^�[�t�F�[�X
//                  :   PMSCM01056O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024�@���X�� ��
// Date             :   2010/05/20
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM�f�[�^��M�����N��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�f�[�^��M�����N��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMDtRcveExecDB
    {
        /// <summary>
        /// SCM�f�[�^��M�������N�����܂�
        /// </summary>
        /// <param name="wait">True:��M�����̏I����҂��܂�</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�f�[�^��M�������N�����܂�</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/05/20</br>
        int ExecuteDataReceive(
            bool wait
            );
    }
}
