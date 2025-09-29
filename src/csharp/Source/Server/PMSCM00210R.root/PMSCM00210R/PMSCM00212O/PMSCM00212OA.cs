//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������s�Ǘ� DBRemoteObject�C���^�[�t�F�[�X
//                  :   PMSCM00212O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������s�Ǘ� DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������s�Ǘ� DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISynchExecuteMngDB
    {
        /// <summary>
        /// �ő�Ď��s�񐔂̎擾����
        /// </summary>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <remarks>
        /// <br>Note       : �ő�Ď��s�񐔂̎擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        void GetMaxRetryCount(out int maxRetryCount);

        /// <summary>
        /// �w��e�[�u�������v������
        /// </summary>
        /// <param name="enterpriceCode">��ƃR�[�h</param>
        /// <param name="tableIDList">�e�[�u�����i�����j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �w��e�[�u�������v���������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        int SyncReqExecuteForTable(string enterpriceCode, object tableIDList);

        /// <summary>
        /// �����v���ĊJ����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �����v���ĊJ�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        int SyncReqReExecute();

        /// <summary>
        /// �ϊ��J�n�v������
        /// </summary>
        /// <remarks>
        /// </remarks>
        void TranslateExecute();

        /// <summary>
        /// ����N������
        /// </summary>
        /// <param name="syncServUrl"></param>
        void RegularStart(string syncServUrl);
    }
}
