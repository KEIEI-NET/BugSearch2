//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���`�F�b�N���X�gDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���`�F�b�N���X�gDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IStockSlipResultDB
    {
        /// <summary>
        /// �d���`�F�b�N���X�g��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockSlipResultWork">��������</param>
        /// <param name="stockSlipCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02059D", "Broadleaf.Application.Remoting.ParamData.StockSlipResultWork")]
            out object stockSlipResultWork,
            object stockSlipCndtnWork);

    }
}
