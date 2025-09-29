//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈��DB RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ菈�����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ菈�����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderPointStSimulationDB
    {
        #region �����_�ݒ菈������f�[�^�̎擾����
        /// <summary>
        /// �����_�ݒ菈������f�[�^���擾����
        /// </summary>
        /// <param name="list">��������</param>
        /// <param name="stockList">�݌Ƀ}�X�^��������</param>
        /// <param name="extrInfo_OrderPointStSimulationWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHAT09113D", "Broadleaf.Application.Remoting.ParamData.OrderPointStSimulationWork")]
            out object list,
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            out object stockList,
            object extrInfo_OrderPointStSimulationWork);
        #endregion

        #region �݌Ƀ}�X�^�̍X�V����
        /// <summary>
        /// �����_�ݒ菈������f�[�^���擾����
        /// </summary>
        /// <param name="stockWorkList">�݌Ƀ}�X�^���[�N</param>
        /// <param name="orderPointStWorkList">�����_�ݒ胏�[�N</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            ref object stockWorkList,
            [CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStWorkList,
            out string retMsg);
        #endregion
    }
}
