using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����擾�}�X�^�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����擾�}�X�^ RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IVariousMasterSearchDB
    {
        /// <summary>
        /// �����擾�}�X�^�擾����
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STSTUS</returns>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}