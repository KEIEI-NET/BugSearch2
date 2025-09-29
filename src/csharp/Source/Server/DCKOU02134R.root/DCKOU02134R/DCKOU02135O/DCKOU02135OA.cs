using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���ԕi�`�[(�ӕ�)DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�`�[(�ӕ�)DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcRetGdsSlipTtlDataDB
    {
        /// <summary>
        /// �d���ԕi�`�[(�ӕ�)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stcretgdsslipttlDataWork">��������</param>
        /// <param name="parastcretgdsslipttlExtraWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object stcretgdsslipttlDataWork,
            object parastcretgdsslipttlExtraWork);
    }
}
