//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������i���i����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsInfoWorkDB
    {

        /// <summary>
        /// �������i���i������LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="trustStockResultWork">��������</param>
        /// <param name="trustStockOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        [MustCustomSerialization]
        int WriteGoodsInfo(
            // [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork")]
               out object countNum,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] out  object writeError,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] ref  object noramlGoodsInfoDataWorkLst,
              [CustomSerializationMethodParameterAttribute("PMKHN02313D", "Broadleaf.Application.Remoting.ParamData.GoodsInfoDataWork")] ref  object warnGoodsInfoDataWorkLst,
           object goodsInfoCndtnWork);

    }
}
