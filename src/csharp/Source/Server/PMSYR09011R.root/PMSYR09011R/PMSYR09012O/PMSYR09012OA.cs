//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ԗ��Ǘ��}�X�^DB�C���^�[�t�F�[�X
//                  :   PMSYR09012O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.06.02
//----------------------------------------------------------------------
// Update Note      :   2009/09/11 �����
//                      ���q�Ǘ��}�X�^ LDNS�J���Ή�
//----------------------------------------------------------------------
// Update Note      :   2009/10/10 ����
//                      �Ǘ��ԍ��K�C�h�̕\�����x�A�b�v�̑Ή�
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
    /// �ԗ��Ǘ��}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��Ǘ��}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.06.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICarManagementDB
    {
        /// <summary>
        /// �P��̎ԗ��Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="carManagementObj">CarManagementWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            ref object carManagementObj,
            int readMode);

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="carManagementList">�����폜����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����ԗ��Ǘ��}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object carManagementList);

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">��������</param>
        /// <param name="carManagementObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int Search(
            // --- UPD 2009/09/11 -------------->>>
            //[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            // --- UPD 2009/09/11 --------------<<<
            ref object carManagementList,
            object carManagementObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // --- ADD 2009/09/11 -------------->>>
        /// <summary>
        /// �ԗ��Ǘ��}�X�^�K�C�h�p���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carMngGuideWorkObj">��������</param>
        /// <param name="carMngWorkListObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�̃L�[�l����v����A�S�Ă̎ԗ��Ǘ��}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/11</br>
        [MustCustomSerialization]
        int SearchGuide(
            // --- UPD 2009/10/10 -------------->>>
           // [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            object carMngGuideWorkObj,
        [CustomSerializationMethodParameterAttribute("PMSYR09013D", "Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            out object carMngWorkListObj);
        // --- UPD 2009/10/10  --------------<<<

        /// <summary>
        /// �ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="carManagementList">�ǉ��E�X�V����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementList �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);

        /// <summary>
        /// �ԗ��Ǘ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜����ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="carManagementList">�_���폜����������ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSYR09013D","Broadleaf.Application.Remoting.ParamData.CarManagementWork")]
            ref object carManagementList);

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̏����Ƙ_���폜�����B
        /// </summary>
        /// <param name="carManagementList">�_���폜����Ə�������ԗ��Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : carManagementWork �Ɋi�[����Ă���ԗ��Ǘ��}�X�^���������Ƙ_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteAndLogicDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object carManagementList);
    }
}
