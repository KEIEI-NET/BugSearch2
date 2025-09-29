using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I�y���[�V�����ݒ�DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�y���[�V�����ݒ�DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOperationStDB
    {
        /// <summary>
        /// �P���OperationSt�����擾���܂��B
        /// </summary>
        /// <param name="operationStObj">OperationStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����OperationSt�����擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.22</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStObj,
            int readMode);

        /// <summary>
        /// OperationSt���𕨗��폜���܂�
        /// </summary>
        /// <param name="operationStList">�����폜����OperationSt�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����OperationSt���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            object operationStList);

        /// <summary>
        /// OperationSt���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="operationStList">��������</param>
        /// <param name="operationStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationSt�̃L�[�l����v����A�S�Ă�OperationSt�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList,
            object operationStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// OperationSt����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="operationStList">�ǉ��E�X�V����OperationSt�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStList �Ɋi�[����Ă���OperationSt����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);

        /// <summary>
        /// OperationSt����_���폜���܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜����OperationSt�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);

        /// <summary>
        /// OperationSt���̘_���폜���������܂��B
        /// </summary>
        /// <param name="operationStList">�_���폜����������OperationSt�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationStWork �Ɋi�[����Ă���OperationSt���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09136D", "Broadleaf.Application.Remoting.ParamData.OperationStWork")]
            ref object operationStList);
    }
}
