//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�C���^�[�t�F�[�X
//                  :   PMKEN09033O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPrmSettingUDB
    {
        /// <summary>
        /// �P��̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B
        /// </summary>
        /// <param name="prmSettingUObj">PrmSettingUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUObj,
            int readMode);

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
        /// </summary>
        /// <param name="prmSettingUList">�����폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� ArrayList</param>
        /// <param name="goodsMngList">���i�Ǘ���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            object prmSettingUList,
            object goodsMngList);

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUList">��������</param>
        /// <param name="prmSettingUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����A�S�Ă̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList,
            object prmSettingUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� ArrayList</param>
        /// <param name="goodsMngList">�X�V���鏤�i�Ǘ������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Note       : GoodsMngList �Ɋi�[����Ă��鏤�i�Ǘ������X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList,
            ref object goodsMngList);

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����_���폜���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList);

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜����������D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09034D","Broadleaf.Application.Remoting.ParamData.PrmSettingUWork")]
            ref object prmSettingUList);
    }
}
