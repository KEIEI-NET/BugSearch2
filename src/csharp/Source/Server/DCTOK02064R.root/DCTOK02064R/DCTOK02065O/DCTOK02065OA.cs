using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�׏��i���͕\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i���͕\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IShipGoodsAnalyzeDB
    {

        /// <summary>
        /// �o�׏��i���͕\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�׏��i���͕\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int SearchShipGoodsAnalyze(
            [CustomSerializationMethodParameterAttribute("DCTOK02066D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_ShipGoodsAnalyzeWork")]
            out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode
            );

    }
}
