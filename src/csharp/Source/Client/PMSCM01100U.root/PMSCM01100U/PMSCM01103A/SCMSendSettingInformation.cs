//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/10/10  �C�����e : �V�K�쐬�F�s�r�o����M�����y�o�l���z(SFMIT02851A)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/29  �C�����e : SCM�p�ɃA�����W
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21112 �v�ۓc ��
// �� �� ��  2011/06/01  �C�����e : ���O�\���I�v�V�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2013/03/25  �C�����e : 2013/04/10�z�M�� SCM��Q��10493�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/04/09  �C�����e : SCM�d�|�ꗗ��10641�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/11/26  �C�����e : SCM�d�|�ꗗ��10707�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/06/30  �C�����e : SCM�d�|�ꗗ��10707
//                                  �@�񓚑��M���g���C����̎��s����(���c���i��ƃR�[�h)���폜
//                                  �BDB�X�V���g���C�񐔁E�ҋ@���Ԃ̏����o�^��ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common; // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή�

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ݒ���N���X
    /// </summary>
    [Serializable]
    public class SCMSendSettingInformation
    {
        /// <summary>�R���t�B�O�t�@�C����</summary>
        private const string CONFIG_FILE_NAME = "PMSCM01103A.config";
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
        #region <���c���i�p�f�t�H���g�l>
        // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        ///// <summary>���c���i��ƃR�[�h</summary>
        //private string ENTERPRISE_CODE_FUKUDA = "0101130064003200";
        // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        /// <summary>���c���i��� ���M���g���C��</summary>
        private const int DEFAULT_SEND_RETRY = 60;
        /// <summary>���c���i��� ���M���g���C�̑ҋ@����</summary>
        private const int DEFAULT_SEND_SLEEP_SEC = 5;
        /// <summary>���c���i��� �Ǎ��݃��g���C��</summary>
        private const int DEFAULT_READ_RETRY = 30;
        /// <summary>���c���i��� �Ǎ��݃��g���C�̑ҋ@����</summary>
        private const int DEFAULT_READ_SLEEP_SEC = 3;
        /// <summary>�f�[�^���ݒ�l</summary>
        private const int VALUE_NO_SET = -1;
        // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        /// <summary>DB�X�V���g���C��</summary>
        private const int DEFAULT_DB_RETRY = 5;
        /// <summary>DB�X�V���g���C�̑ҋ@����</summary>
        private const int DEFAULT_DB_SLEEP_SEC = 5;
        // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<


        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMSendSettingInformation() { }

        #endregion // </Constructor>

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~SCMSendSettingInformation()
        {
            Save(false);
        }

        #region <���M�f�[�^�t�H���_>

        /// <summary>SCM���M�f�[�^�t�H���_�p�X</summary>
        private string _scmDataPath;
        /// <summary>SCM���M�f�[�^�t�H���_�p�X���擾�܂��͐ݒ肵�܂��B</summary>
        public string SCMDataPath
        {
            get { return _scmDataPath; }
            set { _scmDataPath = value; }
        }
        /// <summary>SCM���M�f�[�^�t�H���_�p�X�̏���l</summary>
        private string _initialSCMDataPath;

        #endregion // </���M�f�[�^�t�H���_>

        #region <�ۑ�����>

        /// <summary>�ۑ����Ԏ��</summary>
        private int _savePeriodType;
        /// <summary>�ۑ����Ԏ�ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public int SavePeriodType
        {
            get { return _savePeriodType; }
            set { _savePeriodType = value; }
        }
        /// <summary>�ۑ����Ԏ�ʂ̏���l</summary>
        private int _initialSavePeriodType;

        #endregion // </�ۑ�����>

        // �����g�p
        #region <�O�񏈗�>

        /// <summary>�O�񏈗���</summary>
        private DateTime _lastDate = DateTime.MinValue;
        /// <summary>�O�񏈗������擾�܂��͐ݒ肵�܂��B</summary>
        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }
        /// <summary>�O�񏈗����̏���l</summary>
        private DateTime _initialLastDate = DateTime.MinValue;

        #endregion // </�O�񏈗�>

        # region <���O�\��>
        //--- ADD 2011/06/01 ------------------------------------------>>>
        private int _logDisplay;

        /// <summary>
        /// ���O�\��
        /// </summary>
        public int LogDisplay
        {
            get { return _logDisplay; }
            set { _logDisplay = value; }
        }

        private int _initialLogDisplay;

        //--- ADD 2011/06/01 ------------------------------------------<<<
        # endregion

        // --- ADD 2013/03/25 �O�� 2013/04/10�z�M�� SCM��Q��10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
        # region <�c�a�X�V���g���C��>
        // --- UPD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        //private int _dbRetry;
        private int _dbRetry = VALUE_NO_SET;
        // --- UPD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        /// <summary>
        /// �c�a�X�V���g���C��
        /// </summary>
        public int DbRetry
        {
            get { return _dbRetry; }
            set { _dbRetry = value; }
        }
        # endregion

        # region <���g���C���̑ҋ@�b��>
        // --- UPD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
        //private int _sleepSec;
        private int _sleepSec = VALUE_NO_SET;
        // --- UPD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
        /// <summary>
        /// ���g���C���̑ҋ@�b��
        /// </summary>
        public int SleepSec
        {
            get { return _sleepSec; }
            set { _sleepSec = value; }
        }
        # endregion
        // --- ADD 2013/03/25 �O�� 2013/04/10�z�M�� SCM��Q��10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------->>>>>
        # region <�P�̋N�����M�\�t���O>
        private int _aloneStartSend;

        /// <summary>
        /// �P�̋N�����M�\�t���O
        /// </summary>
        public int AloneStartSend
        {
            get { return _aloneStartSend; }
            set { _aloneStartSend = value; }
        }
        # endregion
        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� -----------------------------------<<<<<

        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
        #region <���M���g���C��>
        /// <summary>���M���g���C��</summary>
        private int _sendRetry = VALUE_NO_SET;

        /// <summary>���M���g���C��</summary>
        public int SendRetry
        {
            get { return _sendRetry; }
            set { _sendRetry = value; }
        }
        #endregion

        #region <���M���g���C�ҋ@����>
        /// <summary>���M���g���C�ҋ@����</summary>
        private int _sendSleepSec = VALUE_NO_SET;

        /// <summary>���M���g���C�ҋ@����</summary>
        public int SendSleepSec
        {
            get { return _sendSleepSec; }
            set { _sendSleepSec = value; }
        }
        #endregion

        #region <�Ǎ��݃��g���C��>
        /// <summary>�Ǎ��݃��g���C��</summary>
        private int _readRetry = VALUE_NO_SET;

        /// <summary>���M���g���C��</summary>
        public int ReadRetry
        {
            get { return _readRetry; }
            set { _readRetry = value; }
        }
        #endregion

        #region <�Ǎ��݃��g���C�ҋ@����>
        /// <summary>�Ǎ��݃��g���C�ҋ@����</summary>
        private int _readSleepSec = VALUE_NO_SET;

        /// <summary>�Ǎ��݃��g���C�ҋ@����</summary>
        public int ReadSleepSec
        {
            get { return _readSleepSec; }
            set { _readSleepSec = value; }
        }
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<

        /// <summary>
        /// ��ʏ����R���t�B�O�t�@�C������ǂݍ��݂܂��B
        /// </summary>
        public int Load()
        {
            SCMSendSettingInformation info = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SCMSendSettingInformation));

                string filePath = CONFIG_FILE_NAME;
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    info = (SCMSendSettingInformation)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            if (info == null)
            {
                // �ǂݎ��Ɏ��s�����ꍇ�͉������Ȃ�
                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------->>>>>
                // �Ǎ����s���A�����l�ݒ�
                SCMDataPath = SCMConfig.GetSCMDefaultLogPath("");
                _initialSCMDataPath = SCMDataPath;
                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� -----------------------------------<<<<<
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                // DB�X�V���g���C�񐔂Ƀf�t�H���g(5��)��ݒ�
                DbRetry = DEFAULT_DB_RETRY;
                // DB�X�V���g���C���̑ҋ@�b���Ƀf�t�H���g(5�b)��ݒ�
                SleepSec = DEFAULT_DB_SLEEP_SEC;
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //// ��ƃR�[�h�`�F�b�N
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                //    // ��ƃR�[�h�����c���i�̏ꍇ
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                    // ���M���g���C�񐔂Ƀf�t�H���g(60��)��ݒ�
                    SendRetry = DEFAULT_SEND_RETRY;
                    // ���M���g���C���̑ҋ@�b���Ƀf�t�H���g(5�b)��ݒ�
                    SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                    // �Ǎ��݃��g���C�񐔂Ƀf�t�H���g(60��)��ݒ�
                    ReadRetry = DEFAULT_SEND_RETRY;
                    // �Ǎ��݃��g���C���̑ҋ@�b���Ƀf�t�H���g(5�b)��ݒ�
                    ReadSleepSec = DEFAULT_SEND_SLEEP_SEC;
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //}
                //else
                //{
                //    // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //    SendRetry = 0;
                //    SendSleepSec = 0;
                //    ReadRetry = 0;
                //    ReadSleepSec = 0;
                //}
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<

                return (int)ResultUtil.ResultCode.Error;
            }
            else
            {
                SavePeriodType = info.SavePeriodType;
                SCMDataPath = SCMConfig.GetSCMDefaultLogPath(info.SCMDataPath);
                LastDate = info.LastDate;

                _initialSCMDataPath = SCMDataPath;
                _initialSavePeriodType = info.SavePeriodType;
                _initialLastDate = info.LastDate;

                //--- ADD 2011/06/01 ------------------>>>
                LogDisplay = info.LogDisplay;
                _initialLogDisplay = info.LogDisplay;
                //--- ADD 2011/06/01 ------------------<<<

                // --- DEL 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                // saveFlag��`��Ɉړ���
                //// --- ADD 2013/03/25 �O�� 2013/04/10�z�M�� SCM��Q��10493 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //DbRetry = info.DbRetry;
                //SleepSec = info.SleepSec;
                //// --- ADD 2013/03/25 �O�� 2013/04/10�z�M�� SCM��Q��10493 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                // --- DEL 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<

                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------->>>>>
                AloneStartSend = info.AloneStartSend;
                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� -----------------------------------<<<<<

                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                string enterpriceCode = LoginInfoAcquisition.EnterpriseCode.Trim();
                bool saveFlag = false;
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                // �R���t�B�O�t�@�C����DB�X�V���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                if (info.DbRetry == VALUE_NO_SET)
                {
                    // ���ݒ�̏ꍇ
                    // �f�t�H���g(5��)��ݒ�
                    DbRetry = DEFAULT_DB_RETRY;
                    saveFlag = true;
                }
                else
                {
                    // �ݒ�ς݂̏ꍇ
                    DbRetry = info.DbRetry;
                }
                //SleepSec = info.SleepSec;
                // �R���t�B�O�t�@�C����DB�X�V���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                if (info.SleepSec == VALUE_NO_SET)
                {
                    // ���ݒ�̏ꍇ
                    // �f�t�H���g(5�b)��ݒ�
                    SleepSec = DEFAULT_DB_SLEEP_SEC;
                    saveFlag = true;
                }
                else
                {
                    // �ݒ�ς݂̏ꍇ
                    SleepSec = info.SleepSec;
                }
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<

                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //// ��ƃR�[�h�`�F�b�N
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                //    // ��ƃR�[�h�����c���i�ȊO�̏ꍇ
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                    // �R���t�B�O�t�@�C���ɑ��M���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                    if (info.SendRetry == VALUE_NO_SET)
                    {
                        // ���ݒ�̏ꍇ
                        // �f�t�H���g(60��)��ݒ�
                        SendRetry = DEFAULT_SEND_RETRY;
                        saveFlag = true;
                    }
                    else
                    {
                        // �ݒ�ς݂̏ꍇ
                        SendRetry = info.SendRetry;
                    }

                    // �R���t�B�O�t�@�C���ɑ��M���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                    if (info.SendSleepSec == VALUE_NO_SET)
                    {
                        // ���ݒ�̏ꍇ
                        // �f�t�H���g(5�b)��ݒ�
                        SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                        saveFlag = true;
                    }
                    else
                    {
                        // �ݒ�ς݂̏ꍇ
                        SendSleepSec = info.SendSleepSec;
                    }

                    // �R���t�B�O�t�@�C���ɓǍ��݃��g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                    if (info.ReadRetry == VALUE_NO_SET)
                    {
                        // ���ݒ�̏ꍇ
                        // �f�t�H���g(60��)��ݒ�
                        ReadRetry = DEFAULT_READ_RETRY;
                        saveFlag = true;
                    }
                    else
                    {
                        // �ݒ�ς݂̏ꍇ
                        ReadRetry = info.ReadRetry;
                    }

                    // �R���t�B�O�t�@�C���ɓǍ��݃��g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                    if (info.ReadSleepSec == VALUE_NO_SET)
                    {
                        // ���ݒ�̏ꍇ
                        // �f�t�H���g(5�b)��ݒ�
                        ReadSleepSec = DEFAULT_READ_SLEEP_SEC;
                        saveFlag = true;
                    }
                    else
                    {
                        // �ݒ�ς݂̏ꍇ
                        ReadSleepSec = info.ReadSleepSec;
                    }
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //}
                //else
                //{
                //    // ��ƃR�[�h�����c���i�ȊO�̏ꍇ
                //    // �R���t�B�O�t�@�C���ɑ��M���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                //    if (info.SendRetry == VALUE_NO_SET)
                //    {
                //        // ���ݒ�̏ꍇ
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        SendRetry = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // �ݒ�ς݂̏ꍇ
                //        SendRetry = info.SendRetry;
                //    }

                //    // �R���t�B�O�t�@�C���ɑ��M���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                //    if (info.SendSleepSec == VALUE_NO_SET)
                //    {
                //        // ���ݒ�̏ꍇ
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        SendSleepSec = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // �ݒ�ς݂̏ꍇ
                //        SendSleepSec = info.SendSleepSec;
                //    }

                //    // �R���t�B�O�t�@�C���ɓǍ��݃��g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                //    if (info.ReadRetry == VALUE_NO_SET)
                //    {
                //        // ���ݒ�̏ꍇ
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        ReadRetry = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // �ݒ�ς݂̏ꍇ
                //        ReadRetry = info.ReadRetry;
                //    }

                //    // �R���t�B�O�t�@�C���ɓǍ��݃��g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                //    if (info.ReadSleepSec == VALUE_NO_SET)
                //    {
                //        // ���ݒ�̏ꍇ
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        ReadSleepSec = 0;
                //        saveFlag = true;
                //    }
                //    else
                //    {
                //        // �ݒ�ς݂̏ꍇ
                //        ReadSleepSec = info.ReadSleepSec;
                //    }
                //}
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<

                // ���M���g���C�񐔁A���M���g���C���̑ҋ@�b���ɖ��ݒ肪�������ꍇ�A�R���t�B�O�t�@�C�����X�V����
                // �Ǎ��݃��g���C�񐔁A�Ǎ��݃��g���C���̑ҋ@�b���ɖ��ݒ肪�������ꍇ�����l�ɕۑ�����
                if (saveFlag) this.Save(true);
                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<

                return (int)ResultUtil.ResultCode.Normal;
            }
        }

        /// <summary>
        /// �ݒ���R���t�B�O�t�@�C���ɕۑ����܂��B
        /// </summary>
        /// <param name="overwriting">�㏑���t���O</param>
        public void Save(bool overwriting)
        {
            if (
                !SavePeriodType.Equals(_initialSavePeriodType)
                    ||
                !SCMDataPath.Equals(_initialSCMDataPath)
                    ||
                !LastDate.Equals(_initialLastDate)
                    ||
                !LogDisplay.Equals(_initialLogDisplay)  //ADD 2011/06/01
                    ||
                overwriting
            )
            {
                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                // Load���ꂸ��Save���ꂽ�ꍇ�̑Ή�
                string enterpriceCode = LoginInfoAcquisition.EnterpriseCode.Trim();
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                // �R���t�B�O�t�@�C����DB�X�V���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                if (DbRetry == VALUE_NO_SET)
                {
                    // ���ݒ�̏ꍇ�A�f�t�H���g(5��)��ݒ�
                    DbRetry = DEFAULT_DB_RETRY;
                }
                // �R���t�B�O�t�@�C����DB�X�V���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                if (SleepSec == VALUE_NO_SET)
                {
                    // ���ݒ�̏ꍇ�A�f�t�H���g(5�b)��ݒ�
                    SleepSec = DEFAULT_DB_SLEEP_SEC;
                }
                // --- ADD 2015/06/30�B T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //// ��ƃR�[�h�`�F�b�N
                //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                //{
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                    // ��ƃR�[�h�����c���i�̏ꍇ
                    // ���M���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                    if (SendRetry == VALUE_NO_SET)
                    {
                        // ���M���g���C�񐔂����ݒ�̏ꍇ�A�f�t�H���g(60��)��ݒ�
                        SendRetry = DEFAULT_SEND_RETRY;
                    }

                    // ���M���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                    if (SendSleepSec == VALUE_NO_SET)
                    {
                        // �f�t�H���g(5�b)��ݒ�
                        SendSleepSec = DEFAULT_SEND_SLEEP_SEC;
                    }

                    // �Ǎ��݃��g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                    if (ReadRetry == VALUE_NO_SET)
                    {
                        // �Ǎ��݃��g���C�񐔂����ݒ�̏ꍇ�A�f�t�H���g(60��)��ݒ�
                        ReadRetry = DEFAULT_READ_RETRY;
                    }

                    // �Ǎ��݃��g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                    if (ReadSleepSec == VALUE_NO_SET)
                    {
                        // �f�t�H���g(5�b)��ݒ�
                        ReadSleepSec = DEFAULT_READ_SLEEP_SEC;
                    }
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 -------------------->>>>>
                //}
                //else
                //{
                //    // ��ƃR�[�h�����c���i�ȊO�̏ꍇ
                //    // ���M���g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                //    if (SendRetry == VALUE_NO_SET)
                //    {
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        SendRetry = 0;
                //    }

                //    // �R���g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                //    if (SendSleepSec == VALUE_NO_SET)
                //    {
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        SendSleepSec = 0;
                //    }

                //    // �Ǎ��݃��g���C�񐔂��ݒ肳��Ă��邩�`�F�b�N
                //    if (ReadRetry == VALUE_NO_SET)
                //    {
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        ReadRetry = 0;
                //    }

                //    // �Ǎ��݃��g���C���̑ҋ@�b�����ݒ肳��Ă��邩�`�F�b�N
                //    if (ReadSleepSec == VALUE_NO_SET)
                //    {
                //        // ���c���i�ȊO�̓��g���C���Ȃ��̂�0��ݒ�
                //        ReadSleepSec = 0;
                //    }
                //}
                // --- DEL 2015/06/30�@ T.Miyamoto SCM�d�|�ꗗ��10707 --------------------<<<<<
                // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SCMSendSettingInformation));

                    string filePath = CONFIG_FILE_NAME;
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        serializer.Serialize(stream, this);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// �ݒ��ʂ�\�����܂��B
        /// </summary>
        public void ShowDialog()
        {
            PMSCM01103AC settingForm = new PMSCM01103AC(SCMDataPath, SavePeriodType);
            settingForm.ShowDialog();
            if (settingForm.DialogResult.Equals(DialogResult.OK))
            {
                SCMDataPath = settingForm.SCMDataPath;
                SavePeriodType = settingForm.SavePeriodType;
                this.Save(true);
            }
        }
    }
}
