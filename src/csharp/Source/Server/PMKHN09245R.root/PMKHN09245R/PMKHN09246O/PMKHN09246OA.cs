//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X
//                  :   PMKHN09246O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumCustStDB
    {
        /// <summary>
        /// �P��̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B
        /// </summary>
        /// <param name="sumCustStObj">SumCustStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStObj,
            int readMode);

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂�
        /// </summary>
        /// <param name="sumCustStList">�����폜���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v���链�Ӑ�}�X�^�i�����ݒ�j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            object sumCustStList);

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sumCustStList">��������</param>
        /// <param name="sumCustStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�����ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�����ݒ�j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList,
            object sumCustStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sumCustStList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j����_���폜���܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜���链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D", "Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);

        /// <summary>
        /// ���Ӑ�}�X�^�i�����ݒ�j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sumCustStList">�_���폜���������链�Ӑ�}�X�^�i�����ݒ�j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStWork �Ɋi�[����Ă��链�Ӑ�}�X�^�i�����ݒ�j���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09247D","Broadleaf.Application.Remoting.ParamData.SumCustStWork")]
            ref object sumCustStList);
    }
}
