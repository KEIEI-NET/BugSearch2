//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X
//                  :   PMTKD09072O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.06.10
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
    /// �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IModelNameDB
    {
        /// <summary>
        /// �P��̎Ԏ햼�̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="modelNameObj">ModelNameWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork")]
            ref object modelNameObj);

        /// <summary>
        /// �Ԏ햼�̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="modelNameList">��������</param>
        /// <param name="modelNameObj">��������[�R�[�h�ݒ�Ȃ��F�S������]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����A�S�Ă̎Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork")]
            ref object modelNameList,
            object modelNameObj);

    }
}
