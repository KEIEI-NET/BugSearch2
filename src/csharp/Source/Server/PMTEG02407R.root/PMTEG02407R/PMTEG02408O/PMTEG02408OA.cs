//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ʗ\��\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ��`���ʗ\��\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
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
    /// ��`���ʗ\��\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ʗ\��\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataTsukibetsuYoteListReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="tegataTorihikisakiListReportResultWork">��������</param>
        /// <param name="tegataTorihikisakiListReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02409D", "Broadleaf.Application.Remoting.ParamData.TegataTsukibetsuYoteListReportResultWork")]
			out object tegataTorihikisakiListReportResultWork,
           object tegataTorihikisakiListReportParaWork);
        #endregion
    }
}
