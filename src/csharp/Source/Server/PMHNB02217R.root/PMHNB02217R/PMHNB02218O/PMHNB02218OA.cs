//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : �ԕi���R�ꗗ�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ԕi���R�ꗗ�\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRetGoodsReasonReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retGoodsReasonReportResultWork">��������</param>
        /// <param name="retGoodsReasonReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>

        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02219D", "Broadleaf.Application.Remoting.ParamData.RetGoodsReasonReportResultWork")]
			out object retGoodsReasonReportResultWork,
           object retGoodsReasonReportParaWork);
        #endregion
    }
}
