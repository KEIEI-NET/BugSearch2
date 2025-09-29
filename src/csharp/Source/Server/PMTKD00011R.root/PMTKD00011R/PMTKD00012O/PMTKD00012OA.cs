using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ��DB�o�[�W�����`�F�b�NDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ��DB�o�[�W�����`�F�b�NDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2009.01.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IVersionChkTKDWorkDB
	{
        
        /// <summary>
        /// ��DB�o�[�W�����`�F�b�NLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="CurrrentVersion">�J�����g�o�[�W����</param>
        /// <param name="TargetVersion">�^�[�Q�b�g�o�[�W����</param>
        /// <param name="ErrorCode">�G���[�R�[�h</param>
        /// <param name="ErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="MergeCheckResult">�}�[�W�`�F�b�N��������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int VersionCheckDB(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode,
            out string ErrorMessage);

        /// <summary>
        /// ��AP�o�[�W�����`�F�b�NLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="CurrrentVersion">�J�����g�o�[�W����</param>
        /// <param name="TargetVersion">�^�[�Q�b�g�o�[�W����</param>
        /// <param name="ErrorCode">�G���[�R�[�h</param>
        /// <param name="ErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="MergeCheckResult">�}�[�W�`�F�b�N��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int VersionCheckAP(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode,
            out string ErrorMessage);
	}
}
