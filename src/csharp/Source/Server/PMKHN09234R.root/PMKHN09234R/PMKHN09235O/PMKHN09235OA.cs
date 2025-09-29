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
    /// BL�R�[�h�K�C�h�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�K�C�h�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 23015�@�X�{ ��P</br>
    /// <br>Date       : 2008.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLCodeGuideDB
    {
        /// <summary>
        /// �P���BL�R�[�h�K�C�h�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideObj">BLCodeGuideWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjObj,
            int readMode);

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideObjList">��������</param>
        /// <param name="bLCodeGuideObjObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����A�S�Ă�BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList,
            object bLCodeGuideObjObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="bLCodeGuideObjList">�ǉ��E�X�V����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideObjList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="bLCodeGuideObjList">�����폜����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            object bLCodeGuideObjList);

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="bLCodeGuideObjList">�_���폜����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="bLCodeGuideObjList">�_���폜����������BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork")]
            ref object bLCodeGuideObjList);
    }
}
