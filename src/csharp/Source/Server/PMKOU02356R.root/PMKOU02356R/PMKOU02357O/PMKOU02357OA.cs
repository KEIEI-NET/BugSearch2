//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���׍��ٕ\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ���׍��ٕ\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00  �쐬�S�� : 杍^
// �� �� ��  K2019/08/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���׍��ٕ\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���׍��ٕ\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/08/14</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IArrGoodsDiffResultDB
    {
        #region [�J�X�^���V���A���C�Y�Ή����\�b�h]
        /// <summary>
        /// ���׍��ٕ\�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="ArrGoodsDiffResultWork">��������</param>
        /// <param name="ArrGoodsDiffCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/08/14</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02358D", "Broadleaf.Application.Remoting.ParamData.ArrGoodsDiffResultWork")]
            out object ArrGoodsDiffResultWork,
            object ArrGoodsDiffCndtnWork);
        #endregion
    }
}
