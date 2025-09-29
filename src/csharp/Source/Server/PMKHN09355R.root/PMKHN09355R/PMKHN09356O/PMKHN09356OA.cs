using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ꊇ�C��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ꊇ�C��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 23012�@���� �[���N</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerCustomerChangeDB
    {
        /// <summary>
        /// �P��̓��Ӑ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeObj">customerCustomerChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�̃L�[�l����v���链�Ӑ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
            ref object customerCustomerChangeResultObj,
            int readMode);
        /// <summary>
        /// ���Ӑ�ꊇ�C�����̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeObjList">��������</param>
        /// <param name="customerCustomerChangeObjObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ꊇ�C���̃L�[�l����v����A�S�Ă̓��Ӑ�ꊇ�C�������擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
            ref object customerCustomerChangeResultObjList,
            object customerCustomerChangeParamObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // DEL 2009/04/10 >>>
        ///// <summary>
        ///// ���Ӑ�ꊇ�C������ǉ��E�X�V���܂��B
        ///// </summary>
        ///// <param name="customerCustomerChangeObjList">�ǉ��E�X�V���链�Ӑ�ꊇ�C�������܂� CustomSerializeArrayList</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : customerCustomerChangeObjList �Ɋi�[����Ă��链�Ӑ�ꊇ�C������ǉ��E�X�V���܂��B</br>
        ///// <br>Programmer : 23012�@���� �[���N</br>
        ///// <br>Date       : 2008.11.10</br>
        //[MustCustomSerialization]
        //int Write(
        //    [CustomSerializationMethodParameterAttribute("PMKHN09357D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork")]
        //    ref object customerCustomerChangeResultObjList);
        // DEL 2009/04/10 <<<


    }
}
