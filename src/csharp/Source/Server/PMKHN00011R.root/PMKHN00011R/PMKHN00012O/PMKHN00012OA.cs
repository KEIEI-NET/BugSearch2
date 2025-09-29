using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���[�U�[DB�o�[�W�����`�F�b�NDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�U�[DB�o�[�W�����`�F�b�NDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2009.01.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IVersionChkWorkDB
	{
        
        /// <summary>
        /// ���[�U�[DB�o�[�W�����`�F�b�NLIST��S�Ė߂��܂��i�_���폜�����j
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
        int VersionCheckDB(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage);

        /// <summary>
        /// ���[�U�[AP�o�[�W�����`�F�b�NLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="CurrrentVersion">�J�����g�o�[�W����</param>
        /// <param name="TargetVersion">�^�[�Q�b�g�o�[�W����</param>
        /// <param name="ErrorCode">�G���[�R�[�h</param>
        /// <param name="ErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="MergeCheckResult">�}�[�W�`�F�b�N��������</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int VersionCheckAP(out string CurrrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage, string EnterpriseCode);

        /// <summary>
        /// ���[�U�[DB�o�[�W�����`�F�b�NLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="currentVersion">�J�����g�o�[�W����</param>
        /// <param name="TargetVersion">�^�[�Q�b�g�o�[�W����</param>
        /// <param name="ErrorCode">�G���[�R�[�h</param>
        /// <param name="ErrorMessage">�G���[���b�Z�[�W</param>
        /// <param name="MergeCheckResult">�}�[�W�`�F�b�N��������</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int MergeCheck(out int MergeCheckResult, string EnterpriseCode, string currentVersion);

        
        /// <summary>
        /// ���[�U�[�o�[�W�����X�V����
        /// </summary>
        /// <param name="CurrrentVersion">�J�����g�o�[�W����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.01.23</br>
        [MustCustomSerialization]
        int UpdateVersion(ref string CurrentVersion);
	}
}
