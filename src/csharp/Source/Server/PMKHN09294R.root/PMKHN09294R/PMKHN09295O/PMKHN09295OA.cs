//****************************************************************************//
// �V�X�e��         : RC.NS
// �v���O��������   : �o�b�N�A�b�v�����N���X
// �v���O�����T�v   : �o�b�N�A�b�v�����N���XDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.06.22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�b�N�A�b�v�����N���XDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�b�N�A�b�v�����N���XDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ��������</br>
    /// <br>Date       : 2011.06.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBackUpExecutionDB
    {

        /// <summary>
        /// �o�b�N�A�b�v�̃t�H���_���݃`�F�b�N����
        /// </summary>
        /// <param name="filePath">�o�b�N�A�b�v�p�ۑ���t�H���_</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int FilePathCheck(
            string filePath);

        /// <summary>
        /// �o�b�N�A�b�v�̏��������擾�p����
        /// </summary>
        /// <param name="backUpExecutionWorkList">�o�b�N�A�b�v�̏��������f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetBackUpManual(
            [CustomSerializationMethodParameterAttribute("PMKHN09296D", "Broadleaf.Application.Remoting.ParamData.BackUpExecutionWork")]
            out object backUpExecutionWorkList);

        /// <summary>
        /// �o�b�N�A�b�v����
        /// </summary>
        /// <param name="filePath">�o�b�N�A�b�v�p�ۑ���t�H���_</param>
        /// <param name="fileName">�o�b�N�A�b�v�p�ۑ���t�H���_��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ��������</br>
        /// <br>Date       : 2011.06.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int ExecuteBackUp(
            string filePath, 
            string fileName);

    }
}