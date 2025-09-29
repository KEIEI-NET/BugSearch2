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
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/11/13  �C�����e : �}�X�����A���[�pOperationToolBar�N���X�ǉ�
//                       �@�@�@�@ : �}�X�����pMasMainOperationButton�N���X�ǉ�
//                       �@�@�@�@ : ���O�����ݎ��̃v���O����ID���}�X�^�t���[����ID�ɌŒ�
//                       �@�@�@�@ : �E�}�X���� "SFCMN09000U" 
//                       �@�@�@�@ : �E���[�@�@ "SFANL07200U"
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
    using ToolClickEventHandlerType = Infragistics.Win.UltraWinToolbars.ToolClickEventHandler;
    using ToolClickEventArgsType    = Infragistics.Win.UltraWinToolbars.ToolClickEventArgs;

    /// <summary>
    /// ���쌠���̐���A�C�e���N���X
    /// </summary>
    public abstract class OperationControlItem
    {
        #region <������/>

        /// <summary>�f�t�H���g�X�e�[�^�X(���O�o�͂Ŏg�p)</summary>
        public const int DEFAULT_STATUS = 0;
        /// <summary>�f�t�H���g���b�Z�[�W(���O�o�͂Ŏg�p)</summary>
        public const string DEFAULT_MESSAGE = "";
        /// <summary>�f�t�H���g�f�[�^(���O�o�͂Ŏg�p)</summary>
        public const string DEFAULT_DATA = "";

        /// <summary>�J�e�S���R�[�h</summary>
        private readonly int _categoryCode;
        /// <summary>
        /// �J�e�S���R�[�h���擾���܂��B
        /// </summary>
        /// <value>�J�e�S���R�[�h</value>
        protected int CategoryCode
        {
            get { return _categoryCode; }
        }

        /// <summary>�v���O����ID</summary>
        private readonly string _pgId;
        /// <summary>
        /// �v���O����ID���擾���܂��B
        /// </summary>
        /// <value>�v���O����ID</value>
        protected string PgId
        {
            get { return _pgId; }
        }

        /// <summary>�v���O��������</summary>
        private string _pgName;
        /// <summary>
        /// �v���O�������̂��擾���܂��B
        /// </summary>
        /// <value>�v���O��������</value>
        protected string PgName
        {
            get
            {
                if (string.IsNullOrEmpty(_pgName))
                {
                    _pgName = OperationMasterAcs.Instance.Policy.GetProgramName(PgId);
                }
                return _pgName;
            }
        }

        /// <summary>���O�C�����Ă���]�ƈ�</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ���O�C�����Ă���]�ƈ����擾���܂��B
        /// </summary>
        /// <value>���O�C�����Ă���]�ƈ�</value>
        protected Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <������/>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="pgName">�v���O��������</param>
        /// <param name="loginEmployee">���O�C���]�ƈ�</param>
        protected OperationControlItem(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee
        )
        {
            _categoryCode   = categoryCode;
            _pgId           = pgId;
            _pgName         = pgName;
            _loginEmployee  = loginEmployee;
        }

        #endregion  // <Constructor>

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        public abstract void BeginControl();
    }

    #region <�{�^��/>

    /// <summary>
    /// ���쌠���̐���{�^���N���X
    /// </summary>
    public class OperationButton : OperationControlItem
    {
        #region <�A�N�Z�T/>

        /// <summary>����ΏۂƂȂ�{�^��</summary>
        private readonly ButtonType _button;
        /// <summary>
        /// ����ΏۂƂȂ�{�^�����擾���܂��B
        /// </summary>
        /// <value>����ΏۂƂȂ�{�^��</value>
        protected ButtonType Button
        {
            get { return _button; }
        }

        /// <summary>�I�y���[�V�����R�[�h</summary>
        private readonly int _operationCode;
        /// <summary>
        /// �I�y���[�V�����R�[�h���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����R�[�h</value>
        protected int OperationCode
        {
            get { return _operationCode; }
        }

        /// <summary>���O���L�^����t���O</summary>
        private readonly bool _withLogs;
        /// <summary>
        /// ���O���L�^����t���O���擾���܂��B
        /// </summary>
        /// <value>���O���L�^����t���O</value>
        protected bool WithLogs
        {
            get { return _withLogs; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="pgName">�v���O��������</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="loginEmployee">���O�C���]�ƈ�</param>
        /// <param name="button">����ΏۂƂȂ�{�^��</param>
        /// <param name="withLogs">���O���L�^����t���O</param>
        public OperationButton(
            int categoryCode,
            string pgId,
            string pgName,
            int operationCode,
            Employee loginEmployee,
            ButtonType button,
            bool withLogs
        ) : base(categoryCode, pgId, pgName, loginEmployee)
        {
            _button         = button;
            _operationCode  = operationCode;
            _withLogs       = withLogs;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �\���ł��邩���肵�܂��B
        /// </summary>
        /// <returns><c>true</c> :�\���ł���B<br/><c>false</c>:�\���ł��Ȃ��B</returns>
        protected bool CanVisible()
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, PgId, OperationCode))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    PgId,
                    OperationCode,
                    LoginEmployee
                );
            }
            return !operationLimit.Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// ���엚�����o�͂���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void WriteOperationLog(
            object sender,
            EventArgs e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!WithLogs) return;  // ���O�L�^�̑ΏۂłȂ���΁A�������Ȃ�

            Debug.WriteLine(PgName + "���{�^������I");
            // ���샍�O�o��
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                PgId,
                PgName,
                METHOD_NAME,
                OperationCode,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }

        #region <Override/>

        /// <see cref="OperationControlItem"/>
        public override void BeginControl()
        {
            if (Button.Visible)
            {
                Button.Visible = CanVisible();
            }
            Button.Click += new EventHandler(this.WriteOperationLog);
        }

        #endregion  // <Override/>
    }

    // --- ADD 2008/11/13 -------------------------------->>>>>
    /// <summary>
    /// ���쌠���̐���{�^���N���X�i�}�X�����p�j
    /// </summary>
    public sealed class MasMainOperationButton : OperationButton
    {
        private const string _logPGID = "SFCMN09000U";

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="pgName">�v���O��������</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="loginEmployee">���O�C���]�ƈ�</param>
        /// <param name="button">����ΏۂƂȂ�{�^��</param>
        /// <param name="withLogs">���O���L�^����t���O</param>
        public MasMainOperationButton(
            int categoryCode,
            string pgId,
            string pgName,
            int operationCode,
            Employee loginEmployee,
            ButtonType button,
            bool withLogs
        ) : base(categoryCode,
            pgId,
            pgName,
            operationCode,
            loginEmployee,
            button,
            withLogs)
        {
        }

        protected override void WriteOperationLog(
            object sender,
            EventArgs e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!WithLogs) return;  // ���O�L�^�̑ΏۂłȂ���΁A�������Ȃ�

            Debug.WriteLine(PgName + "���{�^������I");
            // ���샍�O�o��
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                OperationCode,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }
    // --- ADD 2008/11/13 --------------------------------<<<<<
    #endregion  // <�{�^��/>

    #region <�c�[���o�[/>

    /// <summary>
    /// �c�[���{�^�����N���X
    /// </summary>
    public class ToolButtonInfo : KeyValuePair<Pair<int, bool>>
    {
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="key">�c�[���{�^���̃L�[</param>
        /// <param name="operationCode">�Ή�����I�y���[�V�����R�[�h</param>
        /// <param name="withLogs">���O�L�^����t���O</param>
        public ToolButtonInfo(
            string key,
            int operationCode,
            bool withLogs
        ) : base(key, new Pair<int, bool>(operationCode, withLogs))
        { }
    }

    /// <summary>
    /// ���쌠���̐���c�[���o�[�N���X
    /// </summary>
    public class OperationToolBar : OperationControlItem
    {
        #region <�A�N�Z�T/>

        /// <summary>����ΏۂƂȂ�c�[���o�[</summary>
        private readonly ToolBarType _toolBar;
        /// <summary>
        /// ����ΏۂƂȂ�c�[���o�[���擾���܂��B
        /// </summary>
        /// <value>����ΏۂƂȂ�c�[���o�[</value>
        protected ToolBarType ToolBar
        {
            get { return _toolBar; }
        }

        /// <summary>�c�[���{�^�����̃}�b�v</summary>
        private readonly Dictionary<string, ToolButtonInfo> _toolButtonInfoMap;
        /// <summary>
        /// �c�[���{�^�����̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�c�[���{�^�����̃}�b�v</value>
        protected Dictionary<string, ToolButtonInfo> ToolButtonInfoMap
        {
            get { return _toolButtonInfoMap; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <param name="pgName">�v���O��������</param>
        /// <param name="loginEmployee">���O�C���]�ƈ�</param>
        /// <param name="toolBar">����ΏۂƂȂ�c�[���o�[</param>
        /// <param name="toolButtonInfoList">�ΏۂƂ���c�[���{�^�����̃��X�g</param>
        public OperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode, pgId, pgName, loginEmployee)
        {
            _toolBar = toolBar;

            _toolButtonInfoMap = new Dictionary<string, ToolButtonInfo>();
            foreach (ToolButtonInfo eToolButtonInfo in toolButtonInfoList)
            {
                _toolButtonInfoMap.Add(eToolButtonInfo.Key, eToolButtonInfo);
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �\���ł��邩���肵�܂��B
        /// </summary>
        /// <param name="toolButtonInfo">�c�[���{�^�����</param>
        /// <returns><c>true</c> :�\���ł���B<br/><c>false</c>:�\���ł��Ȃ��B</returns>
        protected bool CanVisible(ToolButtonInfo toolButtonInfo)
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, PgId, toolButtonInfo.Value.First))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    PgId,
                    toolButtonInfo.Value.First,
                    LoginEmployee
                );
            }
            return !operationLimit.Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// ���엚�����o�͂���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ���O�L�^�̑ΏۂłȂ���΁A�������Ȃ�

            Debug.WriteLine(PgName + "���c�[���{�^������I");
            // ���샍�O�o��
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                PgId,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }

        #region <Override/>

        /// <see cref="OperationControlItem"/>
        public override void BeginControl()
        {
            foreach (ToolButtonInfo eToolButtonInfo in ToolButtonInfoMap.Values)
            {
                if (ToolBar.Tools[eToolButtonInfo.Key].SharedProps.Visible)
                {
                    ToolBar.Tools[eToolButtonInfo.Key].SharedProps.Visible = CanVisible(eToolButtonInfo);
                }
            }

            ToolBar.ToolClick += new ToolClickEventHandlerType(this.WriteOperationLog);
        }

        #endregion  // <Override/>
    }

    // --- ADD 2008/11/13 -------------------------------->>>>>
    /// <summary>
    /// ���쌠���̐���c�[���o�[�N���X�i�}�X�����p�j
    /// </summary>
    public sealed class MasMainOperationToolBar : OperationToolBar
    {
        private const string _logPGID = "SFCMN09000U";

        public MasMainOperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode,
            pgId,   // MOD 2009/02/18 �s��Ή�[8971] _logPGID��pgId
            pgName,
            loginEmployee,
            toolBar,
            toolButtonInfoList)
        {
        }

        /// <summary>
        /// ���엚�����o�͂���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ���O�L�^�̑ΏۂłȂ���΁A�������Ȃ�

            Debug.WriteLine(PgName + "���c�[���{�^������I");
            // ���샍�O�o��
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }

    /// <summary>
    /// ���쌠���̐���c�[���o�[�N���X�i���[�p�j
    /// </summary>
    public sealed class ReportOperationToolBar : OperationToolBar
    {
        private const string _logPGID = "SFANL07200U";

        public ReportOperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode,
            pgId,
            pgName,
            loginEmployee,
            toolBar,
            toolButtonInfoList)
        {
        }

        /// <summary>
        /// ���엚�����o�͂���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ���O�L�^�̑ΏۂłȂ���΁A�������Ȃ�

            Debug.WriteLine(PgName + "���c�[���{�^������I");
            // ���샍�O�o��
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }
    // --- ADD 2008/11/13 --------------------------------<<<<<

    #endregion  // <�c�[���o�[/>
}
