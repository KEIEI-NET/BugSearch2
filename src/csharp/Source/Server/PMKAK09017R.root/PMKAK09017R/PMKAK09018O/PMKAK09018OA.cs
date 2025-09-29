//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���摍���}�X�^�ꗗ�\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/09/07</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumSuppStPrintResultDB
    {
        #region [�J�X�^���V���A���C�Y�Ή����\�b�h]
        /// <summary>
        /// �d���摍���}�X�^�ꗗ�\�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="SumSuppStPrintResultWork">��������</param>
        /// <param name="SumSuppStPrintParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAK09019D", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork")]
			out object SumSuppStPrintResultWork,
            object     SumSuppStPrintParaWork);
        #endregion
    }
}
