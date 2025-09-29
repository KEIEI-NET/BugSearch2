//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d����ϊ��c�[��
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̍œK���ׁ̈A�s�v�ȃ��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/07/13  �C�����e : �V�K�쐬
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
    /// �d����ϊ��c�[���pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����ϊ��c�[���pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.07.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISupplierChangeProcDB
    {
        /// <summary>
        /// �d����ϊ��c�[���̍폜����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="readCount">��������</param>
        /// <param name="delCount">�폜����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����ϊ��c�[���̍폜�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteGoodsMng(
            string enterpriseCodes,
            out int readCount,
            out int delCount);
    }
}
