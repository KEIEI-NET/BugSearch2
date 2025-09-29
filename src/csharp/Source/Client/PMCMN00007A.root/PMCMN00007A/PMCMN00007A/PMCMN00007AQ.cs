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
// �C �� ��  2008/08/29  �C�����e : �V�K�쐬
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/11/13  �C�����e : MasMainController�AReportController��AddControlItem�ɂ�
//                                : �}�X�����p�A���[�p�̃c�[���o�[�A�{�^������
//                                : �C���X�^���X�𐶐�����悤�C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using OperationLimitationAcs= SingletonPolicy<OperationStDBAgent>;
    using OperationMasterAcs    = SingletonPolicy<OperationLcDBAgent>;
    using OperationHistoryLogAcs= SingletonPolicy<OperationHistoryLog>;
    
    using ButtonType = Infragistics.Win.Misc.UltraButton;
    using ToolBarType= Infragistics.Win.UltraWinToolbars.UltraToolbarsManager;

    #region <���쌠��/>

    /// <summary>
    /// ���쌠���C���^�[�t�F�[�X
    /// </summary>
    public interface IOperationAuthority
    {
        #region <�ΏۂƂ���@�\/>

        /// <summary>
        /// �J�e�S���R�[�h���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>�J�e�S���R�[�h</value>
        int CategoryCode { get; }

        /// <summary>
        /// �v���O����ID(�A�Z���u��ID)���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>�v���O����ID</value>
        string ProgramId { get; }

        /// <summary>
        /// �v���O�������̂̃A�N�Z�T
        /// </summary>
        /// <value>�v���O��������</value>
        string ProgramName
        {
            get;
            set;
        }

        /// <summary>
        /// ���O�C���]�ƈ����擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>���O�C���]�ƈ�</value>
        Employee LoginEmployee { get; }

        #endregion  // <�ΏۂƂ���@�\/>

        /// <summary>
        /// �N���\�����肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�N����<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        bool CanRun();

        /// <summary>
        /// ����\�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :�����<br/>
        /// <c>false</c>:����s��
        /// </returns>
        bool Enabled(int operationCode);

        /// <summary>
        /// ����\�i���O�������ݕK�v�j�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����\�i���O�������ݕK�v�j<br/>
        /// <c>false</c>:����\�i���O�������ݕK�v�j�ł͂Ȃ�
        /// </returns>
        bool EnabledWithLog(int operationCode);

        /// <summary>
        /// ����s�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����s��<br/>
        /// <c>false</c>:�����
        /// </returns>
        bool Disabled(int operationCode);

        /// <summary>
        /// ���K�[���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>���K�[</value>
        OperationHistoryLogHelper Logger { get; }
    }

    /// <summary>
    /// ���쌠���̎����N���X
    /// </summary>
    public sealed class OperationAuthorityImpl : IOperationAuthority
    {
        #region <IOperationAuthority �����o/>

        #region <�ΏۂƂ���@�\/>

        /// <summary>�J�e�S���R�[�h</summary>
        private readonly int _categoryCode;
        /// <summary>
        /// �J�e�S���R�[�h���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>�J�e�S���R�[�h</value>
        /// <see cref="IOperationAuthority"/>
        public int CategoryCode
        {
            get { return _categoryCode; }
        }

        /// <summary>�v���O����ID</summary>
        private readonly string _programId;
        /// <summary>
        /// �v���O����ID(�A�Z���u��ID)���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>�v���O����ID</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramId
        {
            get { return _programId; }
        }

        /// <summary>�v���O��������</summary>
        private string _programName;
        /// <summary>
        /// �v���O�������̂̃A�N�Z�T
        /// </summary>
        /// <value>�v���O��������</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramName
        {
            get { return _programName; }
            set { _programName = value; }
        }

        /// <summary>���O�C���]�ƈ�</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ���O�C���]�ƈ����擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>���O�C���]�ƈ�</value>
        /// <see cref="IOperationAuthority"/>
        public Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <�ΏۂƂ���@�\/>

        /// <summary>
        /// �N���\�����肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�N����<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool CanRun()
        {
            return CanRun(DEFAULT_RUN_OPERATION_CODE);
        }

        /// <summary>
        /// ����\�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :�����<br/>
        /// <c>false</c>:����s��
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Enabled(int operationCode)
        {
            //return GetOperationLimit(operationCode).Equals(OperationLimit.Enable);
            return GetOperationLimit(operationCode).Equals(OperationLimit.EnableWithLog);
        }

        /// <summary>
        /// ����\�i���O�������ݕK�v�j�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����\�i���O�������ݕK�v�j<br/>
        /// <c>false</c>:����\�i���O�������ݕK�v�j�ł͂Ȃ�
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool EnabledWithLog(int operationCode)
        {
            return GetOperationLimit(operationCode).Equals(OperationLimit.EnableWithLog);
        }

        /// <summary>
        /// ����s�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����s��<br/>
        /// <c>false</c>:�����
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Disabled(int operationCode)
        {
            return GetOperationLimit(operationCode).Equals(OperationLimit.Disable);
        }

        /// <summary>���K�[</summary>
        private readonly OperationHistoryLogHelper _logger;
        /// <summary>
        /// ���K�[���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>���K�[</value>
        /// <see cref="IOperationAuthority"/>
        public OperationHistoryLogHelper Logger
        {
            get { return _logger; }
        }

        #endregion  // <IOperationAuthority �����o/>

        /// <summary>�N������̃I�y���[�V�����R�[�h�̃f�t�H���g�l</summary>
        public const int DEFAULT_RUN_OPERATION_CODE = 0;

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// �ݒ肳���v���O����ID(�A�Z���u��ID)�Ɋg���q���܂܂��ꍇ�A�g���q�͏��O����܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="programId">�v���O����ID�i�܂��̓A�Z���u��ID�j</param>
        /// <param name="owner">���L��</param>
        /// <exception cref="ArgumentNullException">�v���O����ID��<c>null</c>�܂��͋�ł��B</exception>
        public OperationAuthorityImpl(
            EntityUtil.CategoryCode categoryCode,
            string programId,
            object owner
        )
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(programId)) throw new ArgumentNullException("programId is null or empty.");

            #endregion  // <Guard Phrase/>

            _categoryCode   = (int)categoryCode;
            _programId      = GetProgramId(programId);
            _programName    = OperationMasterAcs.Instance.Policy.GetProgramName(_programId);
            _loginEmployee  = LoginInfoAcquisition.Employee;

            _logger = new OperationHistoryLogHelper(this, owner);
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// �ݒ肳���v���O����ID(�A�Z���u��ID)�Ɋg���q���܂܂��ꍇ�A�g���q�͏��O����܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���[�R�[�h</param>
        /// <param name="programId">�v���O����ID�i�܂��̓A�Z���u��ID�j</param>
        /// <exception cref="ArgumentNullException">�v���O����ID��<c>null</c>�܂��͋�ł��B</exception>
        public OperationAuthorityImpl(
            EntityUtil.CategoryCode categoryCode,
            string programId
        ) : this(categoryCode, programId, null)
        { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���쌠�����擾���܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>���쌠��</returns>
        public OperationLimit GetOperationLimit(int operationCode)
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, operationCode))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    operationCode,
                    LoginEmployee);
            }
            return operationLimit;
        }

        /// <summary>
        /// �N���\�����肵�܂��B
        /// </summary>
        /// <param name="startOperationCode">�N������̃I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :�N����<br/>
        /// <c>false</c>:�N���s��
        /// </returns>
        public bool CanRun(int startOperationCode)
        {
            return !GetOperationLimit(startOperationCode).Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// �v���O����ID���擾���܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        /// <returns>�v���O����ID</returns>
        private static string GetProgramId(string assemblyId)
        {
            string pgId = string.Empty;
            if (Path.HasExtension(assemblyId.Trim()))
            {
                pgId = Path.GetFileNameWithoutExtension(assemblyId.Trim());
            }
            else
            {
                pgId = assemblyId.Trim();
            }
            return pgId;
        }
    }

    #endregion  // <���쌠��/>

    #region <���엚�����O�N���X�̃w���p/>

    /// <summary>
    /// ���엚�����O�N���X�̃w���p�N���X
    /// </summary>
    public sealed class OperationHistoryLogHelper
    {
        #region <���L��/>

        /// <summary>���L��</summary>
        private readonly object _owner;
        /// <summary>
        /// ���L�҂��擾���܂��B
        /// </summary>
        /// <value>���L��</value>
        private object Owner
        {
            get
            {
                if (_owner == null) return Parent;
                return _owner;
            }
        }

        /// <summary>�e�I�u�W�F�N�g</summary>
        private readonly IOperationAuthority _parent;
        /// <summary>
        /// �e�I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>�e�I�u�W�F�N�g</value>
        private IOperationAuthority Parent
        {
            get { return _parent; }
        }

        #endregion  // <���L��/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="parent">�e�I�u�W�F�N�g</param>
        /// <param name="owner">���L��</param>
        public OperationHistoryLogHelper(
            IOperationAuthority parent,
            object owner
        )
        {
            _parent= parent;
            _owner = owner;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���엚�����O�̏����݃I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���엚�����O�̏����݃I�u�W�F�N�g</value>
        public static OperationHistoryLog Writer
        {
            get { return OperationHistoryLogAcs.Instance.Policy; }
        }

        #region <���엚�����O�̏�����/>

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="logDataKind">���O���</param>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        /// <param name="status">�X�e�[�^�X�i�G���[�X�e�[�^�X�Ȃǁj</param>
        /// <param name="message">���b�Z�[�W�i�G���[���e�E�������e�Ȃǁj</param>
        /// <param name="data">�f�[�^�i�G���[�����̃f�[�^�̃L�[�^�ڍא����Ȃǁj</param>
        public void WriteOperationLog(
            LogDataKind logDataKind,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            if (Parent.EnabledWithLog(operationCode))
            {
                Writer.WriteOperationLog(
                    Owner,
                    logDataKind,
                    Parent.ProgramId,
                    Parent.ProgramName,
                    methodName,
                    operationCode,
                    status,
                    message,
                    data
                );
            }
        }

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="logDataCreateDateTime">���O�f�[�^�쐬����</param>
        /// <param name="logDataKind">���O���</param>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        /// <param name="status">�X�e�[�^�X�i�G���[�X�e�[�^�X�Ȃǁj</param>
        /// <param name="message">���b�Z�[�W�i�G���[���e�E�������e�Ȃǁj</param>
        /// <param name="data">�f�[�^�i�G���[�����̃f�[�^�̃L�[�^�ڍא����Ȃǁj</param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            LogDataKind logDataKind,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            if (Parent.EnabledWithLog(operationCode))
            {
                Writer.WriteOperationLog(
                    Owner,
                    logDataCreateDateTime,
                    logDataKind,
                    Parent.ProgramId,
                    Parent.ProgramName,
                    methodName,
                    operationCode,
                    status,
                    message,
                    data
                );
            }
        }

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        public void WriteOperationLog(
            string methodName,
            int operationCode
        )
        {
            WriteOperationLog(
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                OperationControlItem.DEFAULT_STATUS,
                OperationControlItem.DEFAULT_MESSAGE,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="logDataCreateDateTime">���O�f�[�^�쐬����</param>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            string methodName,
            int operationCode
        )
        {
            WriteOperationLog(
                logDataCreateDateTime,
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                OperationControlItem.DEFAULT_STATUS,
                OperationControlItem.DEFAULT_MESSAGE,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        /// <param name="status">�X�e�[�^�X�i�G���[�X�e�[�^�X�Ȃǁj</param>
        /// <param name="message">���b�Z�[�W�i�G���[���e�E�������e�Ȃǁj</param>
        public void WriteOperationLog(
            string methodName,
            int operationCode,
            int status,
            string message
        )
        {
            WriteOperationLog(
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                status,
                message,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// ���엚�����O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O�������݂��s�v�ȑ���ł���΁A���O�������݂��s���܂���B
        /// </remarks>
        /// <param name="logDataCreateDateTime">���O�f�[�^�쐬����</param>
        /// <param name="methodName">���O�𔭐����������\�b�h��</param>
        /// <param name="operationCode">
        /// �I�y���[�V�����R�[�h<br/>
        /// ���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂��B
        /// </param>
        /// <param name="status">�X�e�[�^�X�i�G���[�X�e�[�^�X�Ȃǁj</param>
        /// <param name="message">���b�Z�[�W�i�G���[���e�E�������e�Ȃǁj</param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            string methodName,
            int operationCode,
            int status,
            string message
        )
        {
            WriteOperationLog(
                logDataCreateDateTime,
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                status,
                message,
                OperationControlItem.DEFAULT_DATA
            );
        }

        #endregion  // <���엚�����O�̏�����/>
    }

    #endregion  // <���엚�����O�N���X�̃w���p/>

    #region <���쌠���̐���I�u�W�F�N�g/>

    /// <summary>
    /// ���쌠���̐ݒ�ɏ]���āA�R���g���[���𐧌䂷��N���X
    /// </summary>
    public abstract class OperationAuthorityController : IOperationAuthority
    {
        #region <IOperationAuthority �����o/>

        #region <�ΏۂƂ���@�\/>

        /// <summary>
        /// �J�e�S���R�[�h���擾���܂��B
        /// </summary>
        /// <value>�J�e�S���R�[�h</value>
        /// <see cref="IOperationAuthority"/>
        public int CategoryCode
        {
            get { return OpeAuthComponent.CategoryCode; }
        }

        /// <summary>
        /// �v���O����ID(�A�Z���u��ID)�̃A�N�Z�T
        /// </summary>
        /// <value>�v���O����ID</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramId
        {
            get { return OpeAuthComponent.ProgramId; }
        }

        /// <summary>
        /// �v���O�������̂��擾���܂��B
        /// </summary>
        /// <value>�v���O��������</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramName
        {
            get { return OpeAuthComponent.ProgramName; }
            set { OpeAuthComponent.ProgramName = value; }
        }

        /// <summary>
        /// ���O�C���]�ƈ����擾���܂��B
        /// </summary>
        /// <value>���O�C���]�ƈ�</value>
        /// <see cref="IOperationAuthority"/>
        public Employee LoginEmployee
        {
            get { return OpeAuthComponent.LoginEmployee; }
        }

        #endregion  // <�ΏۂƂ���@�\/>

        /// <summary>
        /// �N���\�����肵�܂��B
        /// </summary>
        /// <returns><c>true</c> :�N����<br/><c>false</c>:�N���s��</returns>
        /// <see cref="IOperationAuthority"/>
        public virtual bool CanRun()
        {
            return OpeAuthComponent.CanRun();
        }

        /// <summary>
        /// ����\�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :�����<br/>
        /// <c>false</c>:����s��
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Enabled(int operationCode)
        {
            return OpeAuthComponent.Enabled(operationCode);
        }

        /// <summary>
        /// ����\�i���O�������ݕK�v�j�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����\�i���O�������ݕK�v�j<br/>
        /// <c>false</c>:����\�i���O�������ݕK�v�j�ł͂Ȃ�
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool EnabledWithLog(int operationCode)
        {
            return OpeAuthComponent.EnabledWithLog(operationCode);
        }

        /// <summary>
        /// ����s�����肵�܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <returns>
        /// <c>true</c> :����s��<br/>
        /// <c>false</c>:�����
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Disabled(int operationCode)
        {
            return OpeAuthComponent.Disabled(operationCode);
        }

        /// <summary>
        /// ���K�[���擾���܂��B�i�ǎ��p�j
        /// </summary>
        /// <value>���K�[</value>
        /// <see cref="IOperationAuthority"/>
        public OperationHistoryLogHelper Logger
        {
            get { return OpeAuthComponent.Logger; }
        }

        #endregion  // <IOperationAuthority �����o/>

        #region <���쌠���R���|�[�l���g/>

        /// <summary>���쌠���R���|�[�l���g</summary>
        private readonly IOperationAuthority _opeAuthComponent;
        /// <summary>
        /// ���쌠���R���|�[�l���g���擾���܂��B
        /// </summary>
        /// <value>���쌠���R���|�[�l���g</value>
        protected IOperationAuthority OpeAuthComponent
        {
            get { return _opeAuthComponent; }
        }

        #endregion  // <���쌠���R���|�[�l���g/>

        #region <���쌠���̐���R���g���[��/>

        /// <summary>���쌠���̐���R���g���[���̃��X�g</summary>
        private readonly List<OperationControlItem> _controlItemList;
        /// <summary>
        /// ���쌠���̐���R���g���[���̃��X�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���R���g���[���̃��X�g</value>
        protected List<OperationControlItem> ControlItemList
        {
            get { return _controlItemList; }
        }

        #endregion  // <���쌠���̐���R���g���[��/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// �ݒ肳���v���O����ID(�A�Z���u��ID)�Ɋg���q���܂܂��ꍇ�A�g���q�͏��O����܂��B
        /// </remarks>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        protected OperationAuthorityController(
            EntityUtil.CategoryCode categoryCode,
            string assemblyId
        )
        {
            _opeAuthComponent = new OperationAuthorityImpl(categoryCode, assemblyId);
            _controlItemList= new List<OperationControlItem>();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���쌠���̐�����s���{�^���R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="button">���쌠���̐�����s���{�^���R���g���[��</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^���s���t���O</param>
        /// <exception cref="ArgumentNullException"><c>button</c>��<c>null</c>�ł��B</exception>
        /// <see cref="IOperationAuthority"/>
        public virtual void AddControlItem(
            ButtonType button,
            int operationCode,
            bool withLogs
        )
        {
            #region <Guard Pharse/>

            if (button == null) throw new ArgumentNullException("button is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new OperationButton(
                CategoryCode,
                ProgramId,
                ProgramName,
                operationCode,
                LoginEmployee,
                button,
                withLogs
            ));
        }

        /// <summary>
        /// ���쌠���̐�����s���c�[���o�[�R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="toolBar">���쌠���̐�����s���c�[���o�[�R���g���[��</param>
        /// <param name="toolButtonInfoList">�ΏۂƂ���c�[���{�^�����̃��X�g</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>��<c>null</c>�ł��B<br/>
        /// �܂���<c>toolButtonInfoList</c>��<c>null</c>�ł��B
        /// </exception>
        public virtual void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null)            throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new OperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <see cref="IOperationAuthority"/>
        public void BeginControl()
        {
            foreach (OperationControlItem eItem in ControlItemList)
            {
                eItem.BeginControl();
            }
        }

        /// <summary>
        /// �N���\�����肵�܂��B
        /// </summary>
        /// <param name="startOperationCode">�N������̃I�y���[�V�����R�[�h</param>
        /// <returns><c>true</c> :�N����<br/><c>false:</c>�N���s��</returns>
        protected bool CanRun(int startOperationCode)
        {
            try
            {
                return ((OperationAuthorityImpl)OpeAuthComponent).CanRun(startOperationCode);
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }

    #region <�}�X����/>

    /// <summary>
    /// �}�X�����t���[���̃I�y���[�V�����R�[�h
    /// </summary>
    public enum MasMainFrameOpeCode : int
    {
        /// <summary>�N��</summary>
        Run = 0,
        /// <summary>�ǉ�(�V�K)</summary>
        New = 1,
        /// <summary>�X�V(�C��)</summary>
        Modify = 2,
        /// <summary>�폜</summary>
        Delete = 3,
        /// <summary>���S�폜</summary>
        DeletePhysically = 4,
        /// <summary>����</summary>
        Revival = 5,
        /// <summary>���</summary>
        Print = 6,
        /// <summary>�ڍ�</summary>
        Details = 7
    }

    /// <summary>
    /// ���쌠���̐ݒ�ɏ]���āA�R���g���[���𐧌䂷��N���X(�}�X�����p)
    /// </summary>
    public sealed class MasMainController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        public MasMainController(string assemblyId) : base(EntityUtil.CategoryCode.MasterMaintenance, assemblyId)
        {
            const string METHOD_NAME = "MasMainController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)ReportFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)MasMainFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "���N���I");
                // ���샍�O�o��
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)MasMainFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)MasMainFrameOpeCode.Run);
        }

        // --- ADD 2008/11/13 -------------------------------->>>>>
        /// <summary>
        /// ���쌠���̐�����s���{�^���R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="button">���쌠���̐�����s���{�^���R���g���[��</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^���s���t���O</param>
        /// <exception cref="ArgumentNullException"><c>button</c>��<c>null</c>�ł��B</exception>
        /// <see cref="IOperationAuthority"/>
        public override void AddControlItem(
            ButtonType button,
            int operationCode,
            bool withLogs
        )
        {
            #region <Guard Pharse/>

            if (button == null) throw new ArgumentNullException("button is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new MasMainOperationButton(
                CategoryCode,
                ProgramId,
                ProgramName,
                operationCode,
                LoginEmployee,
                button,
                withLogs
            ));
        }

        /// <summary>
        /// ���쌠���̐�����s���c�[���o�[�R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="toolBar">���쌠���̐�����s���c�[���o�[�R���g���[��</param>
        /// <param name="toolButtonInfoList">�ΏۂƂ���c�[���{�^�����̃��X�g</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>��<c>null</c>�ł��B<br/>
        /// �܂���<c>toolButtonInfoList</c>��<c>null</c>�ł��B
        /// </exception>
        public override void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null) throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new MasMainOperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }
        // --- ADD 2008/11/13 --------------------------------<<<<<

        #endregion  // <Override/>

        /// <summary>
        /// ���쌠���̐�����s���{�^���R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="button">���쌠���̐�����s���{�^���R���g���[��</param>
        /// <param name="withLogs">���O�L�^���s���t���O</param>
        /// <exception cref="ArgumentNullException"><c>button</c>��<c>null</c>�ł��B</exception>
        public void AddControlItem(
            MasMainFrameOpeCode operationCode,
            ButtonType button,
            bool withLogs
        )
        {
            //base.AddControlItem(button, (int)operationCode, withLogs); // DEL 2008/11/13
            this.AddControlItem(button, (int)operationCode, withLogs); // ADD 2008/11/13
        }
    }

    /// <summary>
    /// �}�X�����̃c�[���{�^�����N���X
    /// </summary>
    public sealed class MasMainToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^����t���O</param>
        public MasMainToolButtonInfo(
            string key,
            MasMainFrameOpeCode operationCode,
            bool withLogs
        ) : base(key, (int)operationCode, withLogs)
        { }
    }

    #endregion  // <�}�X����/>

    #region <���[/>

    /// <summary>
    /// ���[�t���[���̃I�y���[�V�����R�[�h
    /// </summary>
    public enum ReportFrameOpeCode : int
    {
        /// <summary>�N��</summary>
        Run = 0,
        /// <summary>PDF�o��(PDF�\��)</summary>
        OutputPDF = 1,
        /// <summary>���</summary>
        Print = 2,
        /// <summary>���o</summary>
        Extract = 3,
        /// <summary>PDF����ۑ�</summary>
        SavePDF = 4,
        /// <summary>�e�L�X�g�o��</summary>
        OutputText = 5,
        /// <summary>�O���t�\��</summary>
        ShowGraph = 6,
        /// <summary>�ݒ�</summary>
        Setup = 7
    }

    /// <summary>
    /// ���쌠���̐ݒ�ɏ]���āA�R���g���[���𐧌䂷��N���X(���[�p)
    /// </summary>
    public sealed class ReportController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        public ReportController(string assemblyId) : base(EntityUtil.CategoryCode.Report, assemblyId)
        {
            const string METHOD_NAME = "ReportController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)ReportFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)ReportFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "���N���I");
                // ���샍�O�o��
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)ReportFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)ReportFrameOpeCode.Run);
        }

        // --- ADD 2008/11/13 -------------------------------->>>>>
        /// <summary>
        /// ���쌠���̐�����s���c�[���o�[�R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="toolBar">���쌠���̐�����s���c�[���o�[�R���g���[��</param>
        /// <param name="toolButtonInfoList">�ΏۂƂ���c�[���{�^�����̃��X�g</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>��<c>null</c>�ł��B<br/>
        /// �܂���<c>toolButtonInfoList</c>��<c>null</c>�ł��B
        /// </exception>
        public override void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null) throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new ReportOperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }
        // --- ADD 2008/11/13 --------------------------------<<<<<

        #endregion  // <Override/>

        

        /// <summary>
        /// ���쌠���̐�����s���{�^���R���g���[����ǉ����܂��B
        /// </summary>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="button">���쌠���̐�����s���{�^���R���g���[��</param>
        /// <param name="withLogs">���O�L�^���s���t���O</param>
        /// <exception cref="ArgumentNullException"><c>button</c>��<c>null</c>�ł��B</exception>
        public void AddControlItem(
            ReportFrameOpeCode operationCode,
            ButtonType button,
            bool withLogs
        )
        {
            //base.AddControlItem(button, (int)operationCode, withLogs); // DEL 2008/11/13
            this.AddControlItem(button, (int)operationCode, withLogs); // ADD 2008/11/13
        }
    }

    /// <summary>
    /// ���[�̃c�[���{�^�����N���X
    /// </summary>
    public sealed class ReportToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^����t���O</param>
        public ReportToolButtonInfo(
            string key,
            ReportFrameOpeCode operationCode,
            bool withLogs
        ) : base(key, (int)operationCode, withLogs)
        { }
    }

    #endregion  // <���[/>

    #region <�G���g��/>

    /// <summary>
    /// �G���g���t���[���̃I�y���[�V�����R�[�h
    /// </summary>
    public enum EntryFrameOpeCode : int
    {
        /// <summary>�N��</summary>
        Run = 0
    }

    /// <summary>
    /// ���쌠���̐ݒ�ɏ]���āA�R���g���[���𐧌䂷��N���X(�G���g���p)
    /// </summary>
    public sealed class EntryController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        public EntryController(string assemblyId) : base(EntityUtil.CategoryCode.Entry, assemblyId)
        {
            const string METHOD_NAME = "EntryController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)EntryFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)EntryFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "���N���I");
                // ���샍�O�o��
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)EntryFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)EntryFrameOpeCode.Run);
        }

        #endregion  // <Override/>
    }

    /// <summary>
    /// �G���g���̃c�[���{�^�����N���X
    /// </summary>
    public sealed class EntryToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^����t���O</param>
        public EntryToolButtonInfo(
            string key,
            int operationCode,
            bool withLogs
        ) : base(key, operationCode, withLogs)
        { }
    }

    #endregion  // <�G���g��/>

    #endregion  // <���쌠���̐���I�u�W�F�N�g/>
}
