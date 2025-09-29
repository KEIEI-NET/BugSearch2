//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O�����T�v   : �o�i�ꊇ�X�V RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00   �쐬�S�� : �v��
// �� �� �� : 2016/01/22    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// �o�i�ꊇ�X�VDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�ꊇ�X�VDB�C���^�[�t�F�[�X�ł�.</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsMaxStockUpdDB
    {
        /// <summary>
        ///���iMAX�����̎擾����
        /// </summary>
        /// <param name="searchCount">��������</param>
        /// <param name="partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : ���iMAX�������擾���܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        [MustCustomSerialization]
        int SearchCount(
           out int searchCount,
           object partsMaxStockUpdateCndtnWork,
           out string errMessage);

        /// <summary>
        /// �o�i�ꊇ�X�V������߂��܂�
        /// </summary>
        /// <param name="partsMaxStockUpdateResultWork">��������</param>
        /// <param name=" partsMaxStockUpdateCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �o�i�ꊇ�X�V��߂��܂�</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMMAX02016D", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockUpdateResultWork")]
          out object partsMaxStockUpdateResultWork,
          object partsMaxStockUpdateCndtnWork,
          out string errMessage,
          int loopIndex);
    }
}
