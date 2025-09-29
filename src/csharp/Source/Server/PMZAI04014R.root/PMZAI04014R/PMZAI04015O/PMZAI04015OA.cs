using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɒ����f�[�^���� RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɒ����f�[�^���� RemoteObject�C���^�[�t�F�[�X</br>
    /// <br>Programmer : 22018�@��؁@���b</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockAdjRefSearchDB
    {
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̍݌ɒ����f�[�^LIST��߂��܂�
        /// </summary>
        /// <param name="searchPara">�����p�����[�^</param>
        /// <param name="retWork">�������ʍ݌ɒ����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����L�[�̍݌ɒ����f�[�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22018�@��؁@���b</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object searchPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retWork);
    }
}
