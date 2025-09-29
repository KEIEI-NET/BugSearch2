//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ʌ��Ϗ��E�I���\ 
// �v���O�����T�v   : ���Ӑ�ʌ��Ϗ��E�I���\ RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10970531-00  �쐬�S�� : songg
// �� �� ��  K2013/12/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ʌ��Ϗ��E�I���\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʌ��Ϗ��E�I���\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : K2013/12/03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITakekawaQuotaInventWorkDB
    {

        /// <summary>
        /// ���Ӑ�ʌ��Ϗ��E�I���\��߂��܂�
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">��������</param>
        /// <param name="goodsPriceUWorkList">���i�}�X�^���X�g</param>
        /// <param name=" takekawaQuotaInventCndtnWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʌ��Ϗ��E�I���\��߂��܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMMIT02009DC", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork")]
          out object takekawaQuotaInventResultWork,
          [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
          out object goodsPriceUWorkList,     
          object takekawaQuotaInventCndtnWork, ConstantManagement.LogicalMode logicalMode);

    }
}
