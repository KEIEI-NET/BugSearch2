//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���iMAX���ח\��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : ���O
// �� �� ��  2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>���iMAX���ח\��DB�C���^�[�t�F�[�X</summary>
    /// <br>Note       : ���iMAX���ח\��DB�C���^�[�t�F�[�X�ł�.</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsMaxStockArrivalDB
    {
        #region ���iMAX���ח\�����̎擾����
        /// <summary>
        ///���iMAX���ח\�����̎擾�����B
        /// </summary>
        /// <param name="searchCount">��������</param>
        /// <param name="partsMaxStockArrivalCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : ���iMAX���ח\��̌������擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        [MustCustomSerialization]
        int SearchCount(
           out int searchCount,
           object partsMaxStockArrivalCndtnWork,
           out string errMessage);
        #endregion

        #region ���iMAX���ח\���񃊃X�g�̎擾����
        /// <summary>
        ///���iMAX���ח\���񃊃X�g�̎擾�����B
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">��������</param>
        /// <param name="partsMaxStockArrivalCndtnWork">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : ���iMAX���ח\��̃L�[�l����v����A�S�Ă̔���f�[�^�e�L�X�g�����擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMMAX02006D", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockArrivalWork")]
            out object partsMaxStockArrivalResultWork,
            object partsMaxStockArrivalCndtnWork,
            out string errMessage,
            int loopIndex);

        #endregion
    }
}
