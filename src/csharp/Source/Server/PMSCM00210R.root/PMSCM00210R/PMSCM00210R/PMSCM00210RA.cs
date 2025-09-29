//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������s�Ǘ� �����[�g�I�u�W�F�N�g
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      : 
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������s�Ǘ� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������s�Ǘ����f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// </remarks>
    [Serializable]
    public class SynchExecuteMngDB : RemoteWithAppLockDB, ISynchExecuteMngDB
    {
        #region [ Constructor]
        /// <summary>
        /// �������s�Ǘ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchExecuteMngDB()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SyncNotify(object sender, EventArgs e)
        {
            SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
            synchExecuteMng.SyncReqExecute();
        }

        /// <summary>
        /// �������s�N���X��Instance��
        /// </summary>
        /// <param name="syncServUrl"></param>
        private void InitializeSyncExecWorkDB(string syncServUrl)
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            SyncAuthenticationInfo info = new SyncAuthenticationInfo();
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            info.EnterpriseCode = acquisition.EnterpriseCode;
            info.UserDbConnectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            info.PmSyncUrl = syncServUrl;
            //�������s�N���X��Instance��
            SyncExecWorkDB.Initialize(info, this.GetPmDbId());
        }

        private SyncExecWorkDB GetSyncExecWorkDB()
        {
            return SyncExecWorkDB.GetInstance(new ServerLoginInfoAcquisition().EnterpriseCode);
        }
        #endregion

        /// <summary>
        /// ���񓯊����{�L�����菈��
        /// </summary>
        /// <returns>true:�L��,false:����</returns>
        /// <remarks>
        /// <br>Note       : ���񓯊����{�L�����菈�����s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private bool SyncMngDataExists()
        {
            SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
            bool isSyncMngDataExists = synchConfirmDB.SyncMngDataExists();

            return isSyncMngDataExists;
        }

        #region ISynchExecuteMngDB �����o

        /// <summary>
        /// �ő�Ď��s�񐔂̎擾����
        /// </summary>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <remarks>
        /// <br>Note       : �ő�Ď��s�񐔂̎擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void GetMaxRetryCount(out int maxRetryCount)
        {
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                maxRetryCount = 0;
            }
            else
            {
                maxRetryCount = worker.XmlSetting.MaxRetryCount;
            }
        }

        /// <summary>
        /// �����v������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����v���������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void SyncReqExecute()
        {
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker != null)
            {
                worker.StartSyncExec();
            }
        }

        /// <summary>
        /// �ϊ��J�n�v������
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void TranslateExecute()
        {
            string enterpriseCode = new ServerLoginInfoAcquisition().EnterpriseCode;
            SyncExecWorkDB worker = SyncExecWorkDB.GetInstance(enterpriseCode);
            if (worker != null)
            {
                worker.TranslateThreadWakeUp();
            }
        }

        /// <summary>
        /// �w��e�[�u�������v������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableIDList">�e�[�u�����i�����j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �w��e�[�u�������v���������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqExecuteForTable(string enterpriseCode, object tableIDList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                return status;
            }

            //���񓯊����{�L�����菈�������ɂď��񓯊��̗L�����m�F
            if (SyncMngDataExists())
            {
                SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
                ArrayList tableList = (ArrayList)tableIDList;
                status = synchConfirmDB.WriteSyncReqDataForTable(enterpriseCode, tableList, GetSyncExecWorkDB().XmlSetting.MaxRetryCount);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�������s�X���b�h��҂���Ԃ��������܂�
                    worker.StartSyncExec();
                    worker.SyncBatchThreadWakeUp();
                }
            }
            return status;
        }

        /// <summary>
        /// �����v���ĊJ����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �����v���ĊJ�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqReExecute()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                return status;
            }

            //�ő厎�s�񐔂̎擾
            int maxRetryCount = 0;
            this.GetMaxRetryCount(out maxRetryCount);

            SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
            status = synchConfirmDB.UpdateRetryCount(maxRetryCount);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�������s�X���b�h��҂���Ԃ��������܂�
                worker.StartSyncExec();
                worker.SyncBatchThreadWakeUp();
            }

            return status;
        }

        /// <summary>
        /// ����N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���C�A���g�ɓo�^����铯�������N����ʂ���Ăяo����܂�</br>
        /// <br>             �I�v�V�������r������ǉ��ɂȂ����ꍇ��A���񓯊����s���</br>
        /// <br>             �������s�N���X��Instance�����A�������������삷��l�ɂ��܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void RegularStart(string syncServUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(syncServUrl))
                {
                    throw new Exception("syncServUrl is null.");
                }
                //�������s�N���X��Instance������Ă��Ȃ��ꍇ��Instance��
                //�������s�N���X��Instance��
                InitializeSyncExecWorkDB(syncServUrl);
                this.SyncReqExecute();
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchExecuteMngDB.RegularStart Exception=" + ex.Message);
            }
        }
        #endregion

        private Dictionary<string, string> GetPmDbId()
        {
            Dictionary<string, string> answer = new Dictionary<string, string>();

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            string sqlText = "SELECT ENTERPRISECODERF,DBIDMNGGUIDRF FROM PMDBIDMNGRF WITH(READUNCOMMITTED)";
            string enterpriseCode = null;
            string pmdbid = null;
            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    enterpriseCode = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("ENTERPRISECODERF"));
                    pmdbid = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("DBIDMNGGUIDRF"));
                    answer.Add(enterpriseCode, pmdbid);
                }
                return answer;
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
    }

    /// <summary>
    /// �I�v�V�����`�F�b�N�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�v�V�����`�F�b�N�N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// </remarks>
    public class CheckOptionWork
    {
        /// <summary>
        /// �I�v�V�����`�F�b�N�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public CheckOptionWork()
        {

        }

        /// <summary>
        /// �I�v�V�����L���m�F����
        /// </summary>
        /// <param name="softwareCode">�R�[�h</param>
        /// <returns>true:�L��,false:����</returns>
        /// <remarks>
        /// <br>Note       : �w��̃\�t�g�E�F�A�R�[�h�̃I�v�V���������݂��邩�ǂ������m�F���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public bool CheckSoftwarePurchasedPrco(string softwareCode)
        {
            bool exists = false;
            try
            {
                object objReslutList = null;

                //�I�v�V�����Ǘ��}�X�^�����[�g
                PMOptMngDB pmOptMngDB = new PMOptMngDB();
                int status = pmOptMngDB.SearchAll(out objReslutList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = (ArrayList)objReslutList;

                    if (resultList != null && resultList.Count > 0)
                    {
                        foreach (PMOptMngWork work in resultList)
                        {
                            //�I�v�V�������p�敪 [0:���g�p�A1:�g�p]
                            if (work.OptionCode == softwareCode && work.OptionUseDiv == 1)
                            {
                                exists = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                exists = false;
            }
            return exists;
        }

        /// <summary>
        /// �w��I�v�V���������ς݊�ƃR�[�h�̎擾
        /// </summary>
        /// <param name="softwareCode">�R�[�h</param>
        /// <returns>true:�L��,false:����</returns>
        /// <remarks>
        /// <br>Note       : �w��̃\�t�g�E�F�A�R�[�h�̃I�v�V���������݂��邩�ǂ������m�F���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public List<string> GetSoftwarePurchasedPrco(string softwareCode)
        {
            List<string> answer = new List<string>();
            try
            {
                object objReslutList = null;

                //�I�v�V�����Ǘ��}�X�^�����[�g
                PMOptMngDB pmOptMngDB = new PMOptMngDB();
                int status = pmOptMngDB.SearchAll(out objReslutList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = (ArrayList)objReslutList;

                    if (resultList != null && resultList.Count > 0)
                    {
                        foreach (PMOptMngWork work in resultList)
                        {
                            //�I�v�V�������p�敪 [0:���g�p�A1:�g�p]
                            if (work.OptionCode == softwareCode && work.OptionUseDiv == 1)
                            {
                                answer.Add(work.EnterpriseCode);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return answer;
        }
    }
}

