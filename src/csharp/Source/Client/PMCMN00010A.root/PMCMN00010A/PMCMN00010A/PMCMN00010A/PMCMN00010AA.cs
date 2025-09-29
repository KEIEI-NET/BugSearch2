using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using System.Data.SqlClient;


namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// �o�[�W�����`�F�b�N�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �o�[�W�����`�F�b�N�A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30350 �N�� ����</br>
    /// <br>Date        : 2009/1/27</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/25 22008 ���� ���n</br>
    /// <br>                �E�I�t���C���Ή�</br>
    /// </remarks>
    public class VersionCheckAcs
    {
        #region Private Members

        private string _enterpriseCode;
        private IVersionChkWorkDB _versionChkWorkDB;
        private IVersionChkTKDWorkDB _versionChkTkdWorkDB;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �o�[�W�����`�F�b�N�A�N�Z�X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�[�W�����`�F�b�N�A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30350 �N�� ����</br>
        /// <br>Date        : 2009/1/27</br>
        /// </remarks>
        public VersionCheckAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._versionChkTkdWorkDB = (IVersionChkTKDWorkDB)MediationVersionChkTKDWorkDB.GetVersionChkTKDWorkDB();
                this._versionChkWorkDB = (IVersionChkWorkDB)MediationVersionChkWorkDB.GetVersionChkWorkDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._versionChkWorkDB = null;
                this._versionChkTkdWorkDB = null;
            }
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// ���[�U�[AP�o�[�W�����`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int UsrVersionCheckAP(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            try
            {
                status = this._versionChkWorkDB.VersionCheckAP(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage, this._enterpriseCode);
            }
            catch
            {
                status = -9;
            }

            return (status);

        }

        /// <summary>
        /// ���[�U�[DB�o�[�W�����`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int UsrVersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            try
            {
                status = this._versionChkWorkDB.VersionCheckDB(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
            }
            catch
            {
                status = -9;
            }

            return (status);
        }

        /// <summary>
        /// ��AP�o�[�W�����`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int TkdVersionCheckAP(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            try
            {
                status = this._versionChkTkdWorkDB.VersionCheckAP(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
            }
            catch
            {
                status = -9;
            }

            return (status);
        }

        /// <summary>
        /// ��DB�o�[�W�����`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int TkdVersionCheckDB(out string CurrentVersion, out string TargetVersion, out Int32 ErrorCode, out string ErrorMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CurrentVersion = string.Empty;
            TargetVersion  = string.Empty;
            ErrorMessage   = string.Empty;
            ErrorCode = 0;
            try
            {
                status = this._versionChkTkdWorkDB.VersionCheckDB(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
            }
            catch
            {
                status = -9;
            }

            return (status);
        }


        /// <summary>
        /// �}�[�W�`�F�b�N����
        /// </summary>
        /// <param name="MergeCheckResult">
        /// �������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int MergeCheck(out int MergeCheckResult, out string CurrentVersion)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                   CurrentVersion = string.Empty;
            string TargetVersion  = string.Empty;
            string ErrorMessage   = string.Empty;
            int    ErrorCode = 0;
            MergeCheckResult =0;

            // -- ADD 2010/05/25 ---------------------->>>
            if (!LoginInfoAcquisition.OnlineFlag && LoginInfoAcquisition.Employee != null) // �N���C�A���g���ŃI�t���C�����[�h�̏ꍇ
            {
                MergeCheckResult = 0;
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            //try
            //{
            status = this._versionChkTkdWorkDB.VersionCheckDB(out CurrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);

            status = this._versionChkWorkDB.MergeCheck(out MergeCheckResult, this._enterpriseCode, CurrentVersion);
            //}
            //catch (Exception ex)
            //{
            //   status = -9
            //}
            return (status);
        }

        /// <summary>
        /// ���[�U
        /// �[�o�[�W�����X�V����
        /// </summary>
        /// <param name="MergeCheckResult">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateVersion(ref string CurrentVersion)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            status = this._versionChkWorkDB.UpdateVersion(ref CurrentVersion);

            return status;
        }
        #endregion Public Methods
    }
}
