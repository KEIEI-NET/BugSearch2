//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �}�X�^�����e�i���X
// �v���O�����T�v   : �}�X�^�����e�i���X�̐���S�ʂ��s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2008/09/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller.Facade
{
    /// <summary>
    /// ���쌠���̐���̑����N���X
    /// </summary>
    public static class OpeAuthCtrlFacade
    {
        /// <summary>���b�Z�[�W�p�̖���</summary>
        private const string MY_NAME = "�Z�L�����e�B�Ǘ�";  // LITERAL:
        /// <summary>�N���s���̃��b�Z�[�W</summary>
        private const string CANNOT_RUN_BY_SECURITY_AUTHORITY = "���쌠���̐����ɂ��A�{�@�\�͂��g�p�ł��܂���B"; // LITERAL:

        #region <Obsolete/>

        /// <summary>
        /// ���������s���A�N���ł��邩���肵�܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="opeAuthCtrlform">���쌠���̐�����s���t�H�[��</param>
        /// <param name="assemblyId">�A�Z���u��ID(�v���O����ID)</param>
        /// <returns>
        /// <c>true</c> :�������ɐ�������ыN���\<br/>
        /// <c>false</c>:�������Ɏ��s�܂��͋N���s��
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">�ΏۊO�̃J�e�S���[�ł��B</exception>
        [Obsolete("CanRunWithInitializing(EntityUtil.CategoryCode, IOperationAuthorityControllable, string, string) ���g�p���ĉ������B")]
        public static bool CanRunWithInitializing(
            EntityUtil.CategoryCode categoryCode,
            IOperationAuthorityControllable opeAuthCtrlform,
            string assemblyId
        )
        {
            return CanRunWithInitializing(categoryCode, opeAuthCtrlform, assemblyId, string.Empty);
        }

        #endregion  // <Obsolete/>

        /// <summary>
        /// ���������s���A�N���ł��邩���肵�܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="opeAuthCtrlform">���쌠���̐�����s���t�H�[��</param>
        /// <param name="assemblyId">�A�Z���u��ID(�v���O����ID)</param>
        /// <param name="programName">�@�\����</param>
        /// <returns>
        /// <c>true</c> :�������ɐ�������ыN���\<br/>
        /// <c>false</c>:�������Ɏ��s�܂��͋N���s��
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">�ΏۊO�̃J�e�S���[�ł��B</exception>
        public static bool CanRunWithInitializing(
            EntityUtil.CategoryCode categoryCode,
            IOperationAuthorityControllable opeAuthCtrlform,
            string assemblyId,
            string programName
        )
        {
            bool canRun = false;
            try
            {
                switch (categoryCode)
                {
                    case EntityUtil.CategoryCode.MasterMaintenance:
                    {
                        opeAuthCtrlform.OperationController = new MasMainController(assemblyId);
                        canRun = ((MasMainController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    case EntityUtil.CategoryCode.Report:
                    {
                        opeAuthCtrlform.OperationController = new ReportController(assemblyId);
                        canRun = ((ReportController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    case EntityUtil.CategoryCode.Entry:
                    {
                        opeAuthCtrlform.OperationController = new EntryController(assemblyId);
                        canRun = ((EntryController)opeAuthCtrlform.OperationController).CanRun();
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(
                            "�ΏۊO�̃J�e�S���[�ł��B�F" + categoryCode.ToString()  // LITERAL:
                        );
                }
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }

            if (!canRun) ShowDefaultSecurityAlert();

            opeAuthCtrlform.OperationController.ProgramName = programName;
            return canRun;
        }

        /// <summary>
        /// �w�肵���@�\���N���\�����肵�܂��B
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <returns>
        /// <c>true</c> :�N���\<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public static bool CanRun(
            EntityUtil.CategoryCode categoryCode,
            string programId
        )
        {
            IOperationAuthority opeAuth = new OperationAuthorityImpl(categoryCode, programId);
            bool canRun = opeAuth.CanRun();
            if (!canRun) ShowDefaultSecurityAlert();
            return canRun;
        }

        #region <�A���[�g���b�Z�[�W/>

        /// <summary>
        /// �f�t�H���g�̃Z�L�����e�B�A���[�g���b�Z�[�W��\�����܂��B
        /// </summary>
        /// <param name="caption">���b�Z�[�W�{�b�N�X�̃L���v�V����(text)</param>
        public static void ShowDefaultSecurityAlert(string caption)
        {
            MessageBox.Show(CANNOT_RUN_BY_SECURITY_AUTHORITY, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// �f�t�H���g�̃Z�L�����e�B�A���[�g���b�Z�[�W��\�����܂��B
        /// </summary>
        public static void ShowDefaultSecurityAlert()
        {
            ShowDefaultSecurityAlert(MY_NAME);
        }

        #endregion  // <�A���[�g���b�Z�[�W/>

        #region <�}�X����/>

        /// <summary>
        /// �}�X�����̑��쌠���𐶐����܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <param name="owner">�}�X�����@�\���g�i�ʏ��<c>this</c>��n���ĉ������j</param>
        /// <returns>�}�X�����̑��쌠��</returns>
        /// <exception cref="ArgumentNullException">�v���O����ID��<c>null</c>�܂��͋�ł��B</exception>
        public static IOperationAuthority CreateMasterMaintenanceOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.MasterMaintenance, programId, owner);
        }

        #endregion  // <�}�X����/>

        #region <�G���g��/>

        /// <summary>
        /// �G���g���̑��쌠���𐶐����܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <param name="owner">�G���g���@�\���g�i�ʏ��<c>this</c>��n���ĉ������j</param>
        /// <returns>�G���g���̑��쌠��</returns>
        /// <exception cref="ArgumentNullException">�v���O����ID��<c>null</c>�܂��͋�ł��B</exception>
        public static IOperationAuthority CreateEntryOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.Entry, programId, owner);
        }

        /// <summary>
        /// �w�肵���G���g���@�\���N���\�����肵�܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <returns>
        /// <c>true</c> :�N���\<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public static bool CanRunEntry(string programId)
        {
            return CanRunEntry(programId, false);
        }

        /// <summary>
        /// �w�肵���G���g���@�\���N���\�����肵�܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <param name="withLog">�N���������O���o�͂���t���O</param>
        /// <returns>
        /// <c>true</c> :�N���\<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public static bool CanRunEntry(
            string programId,
            bool withLog
        )
        {
            IOperationAuthority opeAuth = CreateEntryOperationAuthority(programId, null);

            if (!opeAuth.CanRun())
            {
                ShowDefaultSecurityAlert();
                return false;
            }

            if (withLog)
            {
                const string METHOD_NAME = "Main";  // LITERAL:
                opeAuth.Logger.WriteOperationLog(METHOD_NAME, (int)EntryFrameOpeCode.Run);
            }

            return true;
        }

        #endregion  // <�G���g��/>

        #region <�Ɖ�/>

        /// <summary>
        /// �Ɖ�̑��쌠���𐶐����܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <param name="owner">�Ɖ�@�\���g�i�ʏ��<c>this</c>��n���ĉ������j</param>
        /// <returns>�Ɖ�̑��쌠��</returns>
        /// <exception cref="ArgumentNullException">�v���O����ID��<c>null</c>�܂��͋�ł��B</exception>
        public static IOperationAuthority CreateReferenceOperationAuthority(
            string programId,
            object owner
        )
        {
            return new OperationAuthorityImpl(EntityUtil.CategoryCode.Reference, programId, owner);
        }

        /// <summary>
        /// �w�肵���Ɖ�@�\���N���\�����肵�܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <returns>
        /// <c>true</c> :�N���\<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public static bool CanRunReference(string programId)
        {
            return CanRunReference(programId, false);
        }

        /// <summary>
        /// �w�肵���Ɖ�@�\���N���\�����肵�܂��B
        /// </summary>
        /// <param name="programId">�v���O����ID(�܂��̓A�Z���u��ID)</param>
        /// <param name="withLog">�N���������O���o�͂���t���O</param>
        /// <returns>
        /// <c>true</c> :�N���\<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public static bool CanRunReference(
            string programId,
            bool withLog
        )
        {
            IOperationAuthority opeAuth = CreateReferenceOperationAuthority(programId, null);

            if (!opeAuth.CanRun())
            {
                ShowDefaultSecurityAlert();
                return false;
            }

            if (withLog)
            {
                const string METHOD_NAME = "Main";  // LITERAL:
                opeAuth.Logger.WriteOperationLog(METHOD_NAME, OperationAuthorityImpl.DEFAULT_RUN_OPERATION_CODE);
            }

            return true;
        }

        #endregion  // <�Ɖ�/>
    }
}
