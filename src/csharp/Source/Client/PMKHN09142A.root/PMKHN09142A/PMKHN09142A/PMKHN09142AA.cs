//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���엚���A�N�Z�X
// �v���O�����T�v   : �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B
//                  : �E�I�y���[�V�����}�X�^���[�J���A�N�Z�X
//                  : �E�������x���}�X�^���[�J���A�N�Z�X�N���X
//                  : �E���엚�������[�g�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/08  �C�����e : �V�K�쐬
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2008/11/18  �C�����e : �}�X�����A���[�̏ꍇ�̗���\�����ύX�B
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �� �� ��  2011/03/22  �C�����e : �Ɖ�v���O�����̒��o�J�n�E�I���̗���\���ɑΉ��B
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �� �� ��  2011/04/06  �C�����e : Redmine#20388�̑Ή��B
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���엚���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B<br/>
    /// �E�I�y���[�V�����}�X�^���[�J���A�N�Z�X<br/>
    /// �E�������x���}�X�^���[�J���A�N�Z�X�N���X<br/>
    /// �E���엚�������[�g�N���X<br/>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̒��o�J�n�E�I���̗���\���ɑΉ��B</br>
    /// <br>Update Note: 2011/04/06  ������</br>
    /// <br>           : Redmine#20388�̑Ή��B</br>
    /// </remarks>
    public sealed class OperationHistoryAcs : IDisposable
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static OperationHistoryAcs _instance;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>���쌠���ݒ�A�N�Z�X�N���X�̃V���O���g���C���X�^���X</value>
        public static OperationHistoryAcs Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new OperationHistoryAcs();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private OperationHistoryAcs() { }

        #endregion  // <Singleton Idiom/>

        #region <IDisposable Member/>

        /// <summary>�����ς݃t���O</summary>
        private bool _disposed;
        /// <summary>
        /// �����ς݃t���O���擾���܂��B
        /// </summary>
        /// <value>true :�����ς�<br/>false:�������Ă��Ȃ�</value>
        private bool Disposed { get { return _disposed; } }

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this._disposed = true;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        private void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (this.Disposed) return;

            #endregion  // <Guard Phrase/>

            // �}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                ResetDataSet();
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~OperationHistoryAcs()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        #region <DB�A�N�Z�X�㗝�l/>

        #region <���_�A�N�Z�X/>

        /// <summary>���_�}�X�^DB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        /// <summary>
        /// ���_�}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>���_�}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public SecInfoSetAcsAgent SectionInfoDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_sectionInfoDB == null)
                {
                    _sectionInfoDB = new SecInfoSetAcsAgent();
                }
                return _sectionInfoDB;
            }
        }

        #endregion // <���_�A�N�Z�X/>

        #region <�������x���}�X�^���[�J���A�N�Z�X/>

        /// <summary>
        /// �������x���}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�������x���}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public AuthorityLevelLcDBAgent AuthorityLevelMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.AuthorityLevelMasterDB;
            }
        }

        #endregion  // <�������x���}�X�^���[�J���A�N�Z�X/>

        #region <�I�y���[�V�����}�X�^���[�J���A�N�Z�X/>

        /// <summary>
        /// �I�y���[�V�����}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�I�y���[�V�����}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public OperationLcDBAgent OperationMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.OperationMasterDB;
            }
        }

        # endregion // <�I�y���[�V�����}�X�^���[�J���A�N�Z�X/>

        #region <�]�ƈ��e�[�u���A�N�Z�X/>

        /// <summary>
        /// �]�ƈ��}�X�^DB���擾���܂��B
        /// </summary>
        /// <value>�]�ƈ��}�X�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public EmployeeAcsAgent EmployeeMasterDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                return OperationAuthoritySettingAcs.Instance.EmployeeMasterDB;
            }
        }

        #endregion  // <�]�ƈ��e�[�u���A�N�Z�X/>

        #region <���엚�������[�g>

        /// <summary>���엚�����O�f�[�^DB</summary>
        private OperationHistoryLogAgent _operationHistoryLogDB;
        /// <summary>
        /// ���엚�����O�f�[�^DB���擾���܂��B
        /// </summary>
        /// <value>���엚�����O�f�[�^DB</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public OperationHistoryLogAgent OperationHistoryLogDB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_operationHistoryLogDB == null)
                {
                    _operationHistoryLogDB = new OperationHistoryLogAgent();
                }
                return _operationHistoryLogDB;
            }
        }

        #endregion  // <���엚�������[�g>

        #endregion  // <DB�A�N�Z�X�㗝�l/>

        /// <summary>�\���p���O�f�[�^�Z�b�g</summary>
        private LogDataSet _logSet;
        /// <summary>
        /// �\���p���O�f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>�\���p���O�f�[�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public LogDataSet LogSet
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_logSet == null)
                {
                    _logSet = new LogDataSet();
                    InitializeLogDataSet();
                }
                return _logSet;
            }
        }

        /// <summary>
        /// �\���p���O�f�[�^�Z�b�g���X�V���܂��B
        /// </summary>
        /// <param name="condition">�X�V����</param>
        /// <returns>�X�V�����\���p���O�f�[�^�Z�b�g</returns>
        public LogDataSet RefreshLogSet(LogCondition condition)
        {
            OperationHistoryLogDB.RefreshLog(condition);

            if (_logSet != null)
            {
                _logSet.Clear();
                _logSet.Dispose();
                _logSet = null;
            }

            return LogSet;
        }

        /// <summary>
        /// �\���p���O�f�[�^�Z�b�g�����������܂��B
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̒��o�J�n�E�I���̗���\���ɑΉ��B</br>
        /// <br>Update Note: 2011/04/06 ������</br>
        /// <br>             ���Ӑ�d�q�����̎d�l�ύX��A"����"="����"��\���\�ɂ���ׁB</br>
        /// </remarks>
        private void InitializeLogDataSet()
        {
            Dictionary<string, string> sectionNameMap       = new Dictionary<string,string>();
            Dictionary<int, string> jobTypeNameMap          = new Dictionary<int, string>();
            Dictionary<int, string> employmentFormNameMap   = new Dictionary<int, string>();
            Dictionary<int, string> categoryNameMap         = new Dictionary<int,string>();
            Dictionary<string, string> pgNameMap            = new Dictionary<string,string>();
            Dictionary<string, string> operationNameMap     = new Dictionary<string,string>();

            foreach (OperationHistoryLogDataSet.OperationHistoryLogRow opeRow in OperationHistoryLogDB.Tbl)
            {
                // ���t�A����
                string date = opeRow.LogDataCreateDateTime.ToString("yyyy/MM/dd");
                string time = opeRow.LogDataCreateDateTime.ToString("HH:mm:ss");

                // ���_
                string sectionCode = opeRow.LoginSectionCd;
                if (!sectionNameMap.ContainsKey(sectionCode))
                {
                    sectionNameMap.Add(sectionCode, SectionInfoDB.GetSectionName(sectionCode));
                }
                string sectionName = sectionNameMap[sectionCode];

                // �E��
                int jobTypeLevel = -1;  // string.Empty���o�^����Ă��邱�Ƃ�����
                try
                {
                    jobTypeLevel = int.Parse(opeRow.LogOperaterDtProcLvl);
                }
                catch (FormatException)
                {
                    // -1�̂܂�
                }
                if (!jobTypeNameMap.ContainsKey(jobTypeLevel))
                {
                    jobTypeNameMap.Add(
                        jobTypeLevel,
                        AuthorityLevelMasterDB.GetJobTypeName(jobTypeLevel)
                    );
                }
                string jobTypeName = jobTypeNameMap[jobTypeLevel];

                // �ٗp�`��
                int employmentFormLevel = -1;  // string.Empty���o�^����Ă��邱�Ƃ�����
                try
                {
                    employmentFormLevel = int.Parse(opeRow.LogOperaterFuncLvl);
                }
                catch (FormatException)
                {
                    // -1�̂܂�
                }
                if (!employmentFormNameMap.ContainsKey(employmentFormLevel))
                {
                    employmentFormNameMap.Add(
                        employmentFormLevel,
                        AuthorityLevelMasterDB.GetEmploymentFormName(employmentFormLevel)
                    );
                }
                string employmentFormName = employmentFormNameMap[employmentFormLevel];

                // �J�e�S�����́A�@�\����
                string pgId = opeRow.LogDataObjAssemblyID;
                CodeNamePair<int> categoryPair;
                // --- ADD 2008/11/18 -------------------------------->>>>>
                // �}�X�����A���[�̏ꍇ�͒��ڐݒ�
                if (pgId == "SFCMN09000U")
                {
                    categoryPair = new CodeNamePair<int>(50, "�}�X����");

                }
                else if (pgId == "SFANL07200U")
                {
                    categoryPair = new CodeNamePair<int>(4, "���[");
                }
                // --- ADD 2008/11/18 --------------------------------<<<<<
                // ---ADD 2011/03/22--------------->>>>>
                else if (pgId == "DCCMN04000U")
                {
                    categoryPair = new CodeNamePair<int>(3, "�Ɖ�");
                }
                // ---ADD 2011/03/22---------------<<<<<
                else
                {
                    categoryPair = OperationMasterDB.GetCategory(pgId);
                    if (!pgNameMap.ContainsKey(pgId))
                    {
                        if (!categoryNameMap.ContainsKey(categoryPair.Code))
                        {
                            categoryNameMap.Add(categoryPair.Code, categoryPair.Name);
                        }
                        pgNameMap.Add(pgId, OperationMasterDB.GetProgramName(pgId));
                    }
                }
                //string pgName = pgNameMap[pgId];
                // TODO:�����K�[���������g�p����Ă���΁AopeRow.LogDataObjAssemblyNm��pgId�ɑΉ����閼��
                string pgName = opeRow.LogDataObjAssemblyNm;

                // ����
                int categoryCode = categoryPair.Code;
                int operationCode = opeRow.LogDataOperationCd;
                
                string operationKey = categoryCode.ToString() + pgId + operationCode.ToString();
                
                if (!operationNameMap.ContainsKey(operationKey))
                {
                    // --- ADD 2008/11/18 -------------------------------->>>>>
                    // �}�X�����A���[�̏ꍇ�A�J�e�S���̑S�̐ݒ�(PGID = "")���瑀�얼�̂��擾
                    if (pgId == "SFCMN09000U" || pgId == "SFANL07200U")
                    {
                        operationNameMap.Add(
                            operationKey,
                            OperationMasterDB.GetOperationName(categoryCode, "", operationCode)
                        );
                    }
                    // --- ADD 2008/11/18 --------------------------------<<<<<
                    // ---ADD 2011/03/22------------->>>>>
                    else if (pgId == "DCCMN04000U")
                    {
                        if (operationCode == 0)
                        {
                            operationNameMap.Add(operationKey, "����");
                        }
                        else
                        {
                            operationNameMap.Add(operationKey, string.Empty);
                        }
                    }
                    // ---ADD 2011/03/22-------------<<<<<
                    // ---ADD 2011/04/06------------->>>>>
                    else if (pgId == "PMKAU04000U")
                    {
                        if (operationCode == 0)
                        {
                            operationNameMap.Add(operationKey, "����");
                        }
                        else
                        {
                            operationNameMap.Add(
                                operationKey,
                                OperationMasterDB.GetOperationName(categoryCode, pgId, operationCode)
                            );
                        }
                    }
                    // ---ADD 2011/04/06-------------<<<<<
                    else
                    {
                        operationNameMap.Add(
                            operationKey,
                            OperationMasterDB.GetOperationName(categoryCode, pgId, operationCode)
                        );
                    }
                }
                string operationName = operationNameMap[operationKey];

                // �f�[�^�Z�b�g�ɒǉ�
                LogSet.Log.AddLogRow(
                    date,
                    time,
                    opeRow.LogDataKindCd,
                    OperationHistoryLogDataSet.GetLogKingName(opeRow.LogDataKindCd),
                    sectionCode,
                    sectionName,
                    opeRow.LogDataMachineName,
                    jobTypeLevel,
                    jobTypeName,
                    employmentFormLevel,
                    employmentFormName,
                    opeRow.LogDataAgentCd,
                    opeRow.LogDataAgentNm,
                    categoryPair.Code,
                    categoryPair.Name,
                    pgId,
                    pgName,
                    operationCode,
                    operationName,
                    opeRow.LogDataMassage,
                    opeRow.LogDataCreateDateTime
                );
            }
        }

        /// <summary>
        /// �ێ����Ă���f�[�^�Z�b�g�����Z�b�g���܂��B
        /// </summary>
        public void ResetDataSet()
        {
            if (_sectionInfoDB != null)
            {
                _sectionInfoDB.Dispose();
                _sectionInfoDB = null;
            }
            if (_operationHistoryLogDB != null)
            {
                _operationHistoryLogDB.Dispose();
                _operationHistoryLogDB = null;
            }
            if (_logSet != null)
            {
                _logSet.Dispose();
                _logSet = null;
            }
        }
    }
}
