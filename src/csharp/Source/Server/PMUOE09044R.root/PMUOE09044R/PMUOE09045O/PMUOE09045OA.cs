//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ���Аݒ�}�X�^DB�C���^�[�t�F�[�X
//                  :   PMUOE09045O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
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
    /// UOE ���Аݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE ���Аݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOESettingDB
    {
        /// <summary>
        /// �P���UOE ���Аݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeSettingObj">UOESettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingObj,
            int readMode);

        /// <summary>
        /// UOE ���Аݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeSettingList">�����폜����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����UOE ���Аݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            object uoeSettingList);

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeSettingList">��������</param>
        /// <param name="uoeSettingObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ���Аݒ�}�X�^�̃L�[�l����v����A�S�Ă�UOE ���Аݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList,
            object uoeSettingObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�ǉ��E�X�V����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingList �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);

        /// <summary>
        /// UOE ���Аݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜����UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D", "Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);

        /// <summary>
        /// UOE ���Аݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeSettingList">�_���폜����������UOE ���Аݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESettingWork �Ɋi�[����Ă���UOE ���Аݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09046D","Broadleaf.Application.Remoting.ParamData.UOESettingWork")]
            ref object uoeSettingList);
    }
}
