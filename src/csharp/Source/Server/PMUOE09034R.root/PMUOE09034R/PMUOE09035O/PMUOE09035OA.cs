//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE �K�C�h���̃}�X�^DB�C���^�[�t�F�[�X
//                  :   PMUOE09035O.DLL
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
    /// UOE �K�C�h���̃}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE �K�C�h���̃}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUOEGuideNameDB
    {
        /// <summary>
        /// �P���UOE �K�C�h���̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameObj">UOEGuideNameWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            ref object uoeGuideNameObj,
            int readMode);

        /// <summary>
        /// UOE �K�C�h���̃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeGuideNameList">�����폜����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            object uoeGuideNameList);

        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">��������</param>
        /// <param name="uoeGuideNameObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����A�S�Ă�UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            ref object uoeGuideNameList,
            object uoeGuideNameObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�ǉ��E�X�V����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            ref object uoeGuideNameList);

        /// <summary>
        /// UOE �K�C�h���̃}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            ref object uoeGuideNameList);

        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜����������UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMUOE09036D","Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork")]
            ref object uoeGuideNameList);
    }
}
