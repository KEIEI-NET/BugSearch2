using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    #region �����v���J�ʐM�ݒ�t�@�C���\��
    /// <summary>
    /// ���v���J�ʐM�ݒ�t�@�C���\���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���v���J�ʐM�ݒ�t�@�C���\���N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class ReplicaCommunicationData
    {
        /// <summary>�Ď��s��</summary>
        private int _shortRetryMaxCount;
        /// <summary>�Ď��s�Ԋu</summary>
        private int _shortRetryWaitTime;
        /// <summary>���񓯊��Ď��Ԋu</summary>
        private int _firstSyncWatchInterval;
        /// <summary>���񓯊��Ď���</summary>
        private int _firstSyncWatchCount;

        /// <summary>
        /// �Ď��s��
        /// </summary>
        public int ShortRetryMaxCount
        {
            get
            {
                return _shortRetryMaxCount;
            }
            set
            {
                _shortRetryMaxCount = value;
            }
        }

        /// <summary>
        /// �Ď��s�Ԋu
        /// </summary>
        public int ShortRetryWaitTime
        {
            get
            {
                return _shortRetryWaitTime;
            }
            set
            {
                _shortRetryWaitTime = value;
            }
        }

        /// <summary>
        /// ���񓯊��Ď��Ԋu
        /// </summary>
        public int FirstSyncWatchInterval
        {
            get
            {
                return _firstSyncWatchInterval;
            }
            set
            {
                _firstSyncWatchInterval = value;
            }
        }

        /// <summary>
        /// ���񓯊��Ď���
        /// </summary>
        public int FirstSyncWatchCount
        {
            get
            {
                return _firstSyncWatchCount;
            }
            set
            {
                _firstSyncWatchCount = value;
            }
        }
    }
    #endregion

    #region ��PM�f�[�^������{�F�؏��
    /// <summary>
    /// PM�f�[�^������{�F�؏��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: PM�f�[�^������{�F�؏��N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class SyncBasicInfo
    {
        //��ƃR�[�h
        private string _enterpriseCode;

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
    }
    #endregion

    #region 000.API����
    public class SyncResponse
    {
        /// <summary>�X�e�[�^�X</summary>
        private int _status;

        /// <summary>�e�푗�M�x���b��</summary>
        private int _requestDelayTime;

        /// <summary>
        /// �X�e�[�^�X
        /// </summary>
        public int Status
        {
            set { this._status = value; }
            get { return this._status; }
        }

        /// <summary>
        /// �v�����M�x���b��
        /// </summary>
        public int RequestDelayTime
        {
            set { this._requestDelayTime = value; }
            get { return this._requestDelayTime; }
        }
    }
    #endregion

    #region 001.�ʏ퓯���v��API

    #endregion

    #region 100.BL������擾API
    /// <summary>
    /// 100.BL������擾API-���N�G�X�g�N���X�B
    /// </summary>
    /// <remarks>
    /// <br>Note		: 100.BL������擾API-���N�G�X�g�N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class BlSyncControlRequest
    {
        //��ƃR�[�h
        private string _enterpriseCode;

        //PMDB ID
        private string _pmDbID;

        //TransactionId
        private long _transactionID;

        //�F��KEY
        private string _authenticationKey;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            set { this._enterpriseCode = value; }
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// PMDBID
        /// </summary>
        public string PmDbID
        {
            set { this._pmDbID = value; }
            get { return this._pmDbID; }
        }

        /// <summary>
        /// �g�����U�N�V����ID
        /// </summary>
        public long TransactionID
        {
            set { this._transactionID = value; }
            get { return this._transactionID; }
        }

        /// <summary>
        /// �F��KEY
        /// </summary>
        public string AuthenticationKey
        {
            set { this._authenticationKey = value; }
            get { return this._authenticationKey; }
        }
    }

    /// <summary>
    /// 100.BL������擾API���X�|���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: 100.BL������擾API���X�|���X�N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class BlSyncControlResponse
    {
        //�߂�X�e�[�^�X
        private int _status;

        //���񓯊����ԏ��
        private FirsySyncInfo _firstSyncDuration;

        //�����`�F�b�N���{�Ԋu(��)
        private int dataCheckInterval;

        //�f�[�^�A�b�v���[�h�v�����
        private string _dataUploadRequest;

        /// <summary>
        /// �߂�X�e�[�^�X
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// ���񓯊����ԏ��
        /// </summary>
        public FirsySyncInfo FirstSyncDuration
        {
            get { return _firstSyncDuration; }
            set { _firstSyncDuration = value; }
        }

        /// <summary>
        /// �����`�F�b�N���{�Ԋu(��)
        /// </summary>
        public int DataCheckInterval
        {
            set { this.dataCheckInterval = value; }
            get { return this.dataCheckInterval; }
        }

        /// <summary>
        /// �f�[�^�A�b�v���[�h�v�����
        /// </summary>
        public string DataUploadRequest
        {
            get { return _dataUploadRequest; }
            set { _dataUploadRequest = value; }
        }
    }
    #endregion

    /// <summary>
    /// ���񓯊����ԏ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���񓯊����ԏ��N���X</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class FirsySyncInfo
    {
        //���񓯊����{���t
        private int _date;
        //���񓯊����{�J�n����
        private int _startTime;
        //���񓯊����{�I������
        private int _endTime;

        /// <summary>
        /// ���񓯊����{���t
        /// </summary>
        public int Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// ���񓯊����{�J�n����
        /// </summary>
        public int StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// ���񓯊����{�I������
        /// </summary>
        public int EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
    }


    #region ���G���[���
    /// <summary>
    /// �G���[���N���X
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>�G���[�R�[�h</summary>
        private int _errorStatus;
        /// <summary>�G���[���b�Z�[�W</summary>
        private string _errorContents;

        /// <summary>
        /// �G���[�R�[�h
        /// </summary>
        public int ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// <summary>
        /// �G���[���b�Z�[�W
        /// </summary>
        public string ErrorContents
        {
            get { return _errorContents; }
            set { _errorContents = value; }
        }
    }
    #endregion
}
