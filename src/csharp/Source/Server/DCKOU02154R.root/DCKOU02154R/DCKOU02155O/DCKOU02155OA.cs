using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�����v�݌v�\DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����v�݌v�\DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.09.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockDayTotalDataDB
    {
        /// <summary>
        /// �d�����v�݌v�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockdaytotalDataWork">��������</param>
        /// <param name="parastockdaytotalDataWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(0:�S���ҕ�,1:�S���ҁE�d�����)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU02156D","Broadleaf.Application.Remoting.ParamData.StockDayTotalDataWork")]
            out object stockdaytotalDataWork,
            object parastockdaytotalDataWork,
            int readMode);
    }
}
