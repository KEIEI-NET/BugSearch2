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
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM�f�[�^������{�F�؏��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������s�X���b�h(����)�̃I�u�W�F�N�g</br>
    /// <br>Programmer : ���{ �G�I</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncAuthenticationInfo
    {
        //��ƃR�[�h
        private string _enterpriseCode;

        //���[�U�[DB�ڑ�������
        private string _userDbConnectionText;

        //���v���J�ڑ��T�[�o�[
        private string _pmSyncUrl;

        //PMDB ID
        private string _pmDbId;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            set { this._enterpriseCode = value; }
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// ���[�U�[DB�ڑ�������
        /// </summary>
        public string UserDbConnectionText
        {
            set { this._userDbConnectionText = value; }
            get { return this._userDbConnectionText; }
        }

        /// <summary>
        /// ���v���J�ڑ��T�[�o�[
        /// </summary>
        public string PmSyncUrl
        {
            set { this._pmSyncUrl = value; }
            get { return this._pmSyncUrl; }
        }

        /// <summary>
        /// PMDBID
        /// </summary>
        public string PmDbId
        {
            set { this._pmDbId = value; }
            get { return this._pmDbId; }
        }

        /// <summary>
        /// SyncBasicInfo�N���X�`���ɕϊ����܂��B
        /// </summary>
        /// <returns></returns>
        public SyncBasicInfo ToSyncBasicInfo()
        {
            SyncBasicInfo answer = new SyncBasicInfo();
            answer.EnterpriseCode = this.EnterpriseCode;
            answer.PmDbId = this.PmDbId;
            answer.PmSyncUrl = this.PmSyncUrl;
            return answer;
        }
    }

    /// <summary>
    /// �������s��{���(BL������)
    /// </summary>
    public class SyncBasicWorkInfo
    {
        //�����`�F�b�N���{�Ԋu(��)
        private int dataCheckInterval;

        //���񓯊����{���t(0:�J�n�\��������,999999:���ł����{�\�A����ȊO:�w����t)
        private int firstSyncDate;

        //���񓯊����{�J�n����
        private int firstSyncStartTime;

        //���񓯊����{�I������
        private int firstSyncEndTime;

        /// <summary>
        /// �����`�F�b�N���{�Ԋu(��)
        /// </summary>
        public int DataCheckInterval
        {
            set { this.dataCheckInterval = value; }
            get { return this.dataCheckInterval; }
        }

        /// <summary>
        /// ���񓯊����{���t(0:�J�n�\��������,999999:���ł����{�\�A����ȊO:�w����t)
        /// </summary>
        public int FirstSyncDate
        {
            set { this.firstSyncDate = value; }
            get { return this.firstSyncDate; }
        }

        /// <summary>
        /// ���񓯊����{�J�n����
        /// </summary>
        public int FirstSyncStartTime
        {
            set { this.firstSyncStartTime = value; }
            get { return this.firstSyncStartTime; }
        }

        /// <summary>
        /// ���񓯊����{�I������
        /// </summary>
        public int FirsySyncEndTime
        {
            set { this.firstSyncEndTime = value; }
            get { return this.firstSyncEndTime; }
        }

        /// <summary>
        /// ���񓯊����{���Ԃ̃`�F�b�N
        /// </summary>
        /// <returns></returns>
        public bool CheckFirstSyncExecTime()
        {
            DateTime now = DateTime.Now;
            #region ���t�`�F�b�N
            if (this.FirstSyncDate == 0)
            {
                return false;
            }
            else if (this.FirstSyncDate != 99999999 && this.FirstSyncDate != 999999)
            {
                int yyyyMMdd = now.Year * 10000 + now.Month * 100 + now.Day;
                if (this.FirstSyncDate != yyyyMMdd)
                {
                    return false;
                }
            }
            #endregion
            #region ���ԃ`�F�b�N
            int HHmmss = now.Hour * 10000 + now.Minute * 100 + now.Second;
            if (this.FirstSyncStartTime <= HHmmss && HHmmss <= this.FirsySyncEndTime)
            {
                return true;
            }
            #endregion
            return false;
        }
    }

    /// <summary>
    /// �ݒ�XML�f�[�^�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ݒ�XML�f�[�^�I�u�W�F�N�g</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class PMSCM00210R_Setting
    {
        /// <summary>
        /// �ݒ�XML�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        public PMSCM00210R_Setting()
        {
            _maxRetryCount = 0;
            _retryIntervalTime = 0;
            _watchOnReplicaDBIntervalTime = 0;
            _tablesInfoList = new List<SyncTableInfo>();
            _watchOnHesitateTime = 0;
            _batchInterval = 300;
            _dataSendLimitSize = 1000;
            _translateTime = "010000";
        }

        #region Private�����o�ϐ�
        /// <summary>���g���C�񐔂̍ő�l (0�ȉ��̏ꍇ�͖�����)</summary>
        private int _maxRetryCount = 0;
        /// <summary>���g���C�Ԋu�i�b�j</summary>
        private int _retryIntervalTime = 0;
        /// <summary>���v���JDB����Ď��Ԋu�i�b�j</summary>
        private int _watchOnReplicaDBIntervalTime = 0;
        /// <summary> �Ď��P�\���ԁi�b�j</summary>
        private int _watchOnHesitateTime = 0;
        /// <summary> �o�b�`�v�������Ԋu (�b) </summary>
        private int _batchInterval = 0;
        /// <summary>�����Ώۃe�[�u������</summary>
        private List<SyncTableInfo> _tablesInfoList = null;
        /// <summary>�f�[�^�ꊇ���M����</summary>
        private int _dataSendLimitSize = 0;
        /// <summary>�ϊ��J�n�v�����{����</summary>
        private string _translateTime = null;

        #endregion
        /// <summary> �Ď��P�\���ԁi�b�j</summary>
        public int WatchOnHesitateTime
        {
            get { return _watchOnHesitateTime; }
            set { _watchOnHesitateTime = value; }
        }

        /// <summary>�����Ώۃe�[�u������</summary>
        public List<SyncTableInfo> TablesInfoList
        {
            get { return _tablesInfoList; }
            set { _tablesInfoList = value; }
        }

        /// <summary>���g���C�񐔂̍ő�l (0�ȉ��̏ꍇ�͖�����)</summary>
        public int MaxRetryCount
        {
            get { return _maxRetryCount; }
            set { _maxRetryCount = value; }
        }

        /// <summary>���g���C�Ԋu�i�b�j</summary>
        public int RetryIntervalTime
        {
            get { return _retryIntervalTime; }
            set { _retryIntervalTime = value; }
        }

        /// <summary>���v���JDB����Ď��Ԋu�i�b�j</summary>
        public int WatchOnReplicaDBIntervalTime
        {
            get { return _watchOnReplicaDBIntervalTime; }
            set { _watchOnReplicaDBIntervalTime = value; }
        }

        /// <summary>
        /// �o�b�`���s�Ԋu(�b)
        /// </summary>
        public int BatchInterval
        {
            get { return this._batchInterval; }
            set { this._batchInterval = value; }
        }

        /// <summary>�f�[�^�ꊇ���M����</summary>
        public int DataSendLimitSize
        {
            get { return this._dataSendLimitSize; }
            set { this._dataSendLimitSize = value; }
        }

        /// <summary>�ϊ��J�n�v�����{����</summary>
        public string TranslateTime
        {
            get { return this._translateTime; }
            set { this._translateTime = value; }
        }

        /// <summary>
        /// �n���ꂽtableid�ɑΉ����閼�̂̎擾
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public string GetSyncTableNm(string tableId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableId == tableId)
                {
                    return info.SyncTableNm;
                }
            }
            return null;
        }


        /// <summary>
        /// �n���ꂽtableid�ɑΉ����閼�̂̎擾
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public string GetSyncTableJsonId(string tableId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableId == tableId)
                {
                    return info.SyncTableJsonId;
                }
            }
            return null;
        }

        /// <summary>
        /// �n���ꂽtableid�ɑΉ����閼�̂̎擾
        /// </summary>
        /// <param name="jsonId"></param>
        /// <returns></returns>
        public string GetSyncTableIdFromJsonId(string jsonId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableJsonId == jsonId)
                {
                    return info.SyncTableId;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// �����Ώۃe�[�u���I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Ώۃe�[�u���I�u�W�F�N�g</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncTableInfo
    {
        /// <summary>
        /// �����Ώۃe�[�u���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        public SyncTableInfo()
        {
            _syncTableId = "";
            _syncTableNm = "";
            _syncTableJsonId = "";
        }

        /// <summary>�e�[�u��ID</summary>
        private string _syncTableId = "";

        /// <summary>�e�[�u������</summary>
        private string _syncTableNm = "";

        /// <summary>�e�[�u��ID(JSON���M�`��)</summary>
        private string _syncTableJsonId = "";

        /// <summary>�e�[�u������</summary>
        public string SyncTableNm
        {
            get { return _syncTableNm; }
            set { _syncTableNm = value; }
        }

        /// <summary>�e�[�u��ID</summary>
        public string SyncTableId
        {
            get { return _syncTableId; }
            set { _syncTableId = value; }
        }


        /// <summary>�e�[�u��ID</summary>
        public string SyncTableJsonId
        {
            get { return _syncTableJsonId; }
            set { _syncTableJsonId = value; }
        }
    }


}
