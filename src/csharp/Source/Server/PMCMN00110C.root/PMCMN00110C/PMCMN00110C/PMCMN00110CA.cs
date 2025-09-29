using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using Broadleaf.Application.Resources;
using System.Threading;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Diagnostics;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�[�W�����Ǘ����ʕ��i
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���l�ϊ������������s���N���X�ł��B</br>
    /// <br>Programmer : 32470 ���� ���</br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertDoubleRelease : RemoteDB
    { 
        #region �v���C�x�[�g�ϐ�

        #region �v���p�e�B�Ŏg�p

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���i�R�[�h</summary>
        private string _goodsNo;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private int _goodsMakerCd;

        /// <summary>�ϊ��O�p�����[�^</summary>
        private double _convertSetParam;

        /// <summary>�ϊ����</summary>
        private ConvertInfoParam _convertInfoParam;

        #endregion // �v���p�e�B�Ŏg�p

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00110_Setting.xml";

        /// <summary>
        /// �R���o�[�g�Ώۃo�[�W�����ݒ�
        /// </summary>
        private ConvertVersionSetting _convertVersionSetting;

        /// <summary>
        /// �R���o�[�g�Ώۃo�[�W�����Ǘ�
        /// </summary>
        private ConvertVersionManager _convertVersionManager;

        /// <summary>
        /// �}�X�^�o�[�W�����擾�Ǘ�
        /// </summary>
        private bool _isGetMstVersion;

        /// <summary>
        /// �}�X�^�o�[�W�����ϊ��ݒ菉�����Ǘ�
        /// </summary>
        private bool _isMstSettingInit;

        /// <summary>
        /// �A�Z���u���o�[�W�����ϊ��ݒ菉�����Ǘ�
        /// </summary>
        private bool _isAsmSettingInit;

        private int _maxRetryCnt;
        private int _waitTime;

        #endregion

        #region �񋓑�

        /// <summary>
        /// ���\�b�h�̖߂�X�e�[�^�X
        /// </summary>
        public enum ReturnStatus
        {
            CT_RETURN_STATUS_OK = 0,
            CT_RETURN_STATUS_ERROR = 9,
            CT_RETURN_STATUS_ERROR_EXP = 1000
        }

        #endregion // �񋓑�

        #region �萔
        /// <summary>
        /// ���g���C�񐔏����l
        /// </summary>
        private const int RETRY_DEFAULT_COUNT = 5;

        /// <summary>
        /// ���g���C�҂����ԏ����l
        /// </summary>
        private const int RETRY_DEFAULT_WAIT_TIME = 5000;
        #endregion // �萔

        #region �f�o�b�O�p
        /// <summary>
        /// �����J�n�i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_START = "StartProcName:{0},StartTime\t{1}";

        /// <summary>
        /// �����I�� �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_END = "ENDProcName:{0},EndTime\t{1}";

        /// <summary>
        /// ������ �i���O�o�́j
        /// </summary>
        private const string LOGOUTPUT_INFO_DETAIL = "ProcName:{0},{1}:{2},ProcTime\t{3}";

        /// <summary>
        /// �f�o�b�O���O�t�@�C����
        /// </summary>
        private const string logtxt = @"Log\PMCMN00110C.txt";

        /// <summary>
        /// �f�o�b�O���O�o�̓p�X
        /// </summary>
        private string logpath = string.Empty;

        #endregion // �f�o�b�O�p

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ConvertDoubleRelease()
        {
            #region �f�o�b�O
            //logpath = Path.Combine(GetCurrentDirectory().TrimEnd('\\'), logtxt);
            //try
            //{
            //    File.AppendAllText(logpath, Environment.NewLine + string.Format(LOGOUTPUT_INFO_START, "ConvertDoubleRelease", DateTime.Now.ToString("HH:mm:ss.fffffff")));
            //}
            //catch
            //{
            //}
            #endregion // �f�o�b�O

            //// �����l�Z�b�g
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = double.MinValue;
            _convertInfoParam = new ConvertInfoParam();
            _convertVersionSetting = new ConvertVersionSetting();
            _convertVersionManager = new ConvertVersionManager();
            _isGetMstVersion = false;
            _isMstSettingInit = false;
            _isAsmSettingInit = false;
            _maxRetryCnt = RETRY_DEFAULT_COUNT;
            _waitTime = RETRY_DEFAULT_WAIT_TIME;
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h
        /// </summary>
        public int GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>
        /// ���i�ԍ�
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// �ϊ����p�����[�^
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// �ϊ����
        /// </summary>
        public ConvertInfoParam ConvertInfParam
        {
            get { return this._convertInfoParam; }
            set { this._convertInfoParam = value; }
        }

        #endregion

        #region public���\�b�h ���������p
        /// <summary>
        /// ��������
        /// �o�[�W���������擾
        /// �ϊ�����ݒ�
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseInitLib()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int retryCnt = 0;

            #region ���g���C���ݒ�

            string fileName = this.InitializeXmlSettings();
            XmlReaderSettings settings = new XmlReaderSettings();

            if (fileName != string.Empty)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("RetryCnt"))
                            {
                                _maxRetryCnt = reader.ReadElementContentAsInt();
                            }

                            if (reader.IsStartElement("WaitTime"))
                            {
                                _waitTime = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib");
                }
            }
            #endregion // ���g���C���ݒ�

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= _maxRetryCnt)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(_waitTime);
                }

                try
                {
                    // �A�Z���u���o�[�W�����擾
                    _convertInfoParam.ConvertVersionAsm = _convertVersionManager.ConvertVersionAsm;

                    if (!string.IsNullOrEmpty(_enterpriseCode))
                    {
                        // �}�X�^�o�[�W�������擾
                        statusVer = this.ConvertVersionRead();
                    }
                    else
                    {
                        // �X�e�[�^�X����
                        statusVer = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    // �e��������I�������ꍇ�A�X�e�[�^�X�𐳏�I���ɂ���
                    if (statusVer == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib", status);
                }

                if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }

                retryCnt += 1;
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            // �}�X�^�o�[�W�������擾
            // �擾�ς݂̏ꍇ�͍ēǂݍ��݂��Ȃ�
            this.ConvertVersionRead();

            // �����������s
            status = this.ReleaseProcSetting(_convertInfoParam.ConvertVersionMst);

            return status;
        }

        /// <summary>
        /// �ϊ�����
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ϊ��������s���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ConvertProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            // �}�X�^�o�[�W�������擾
            // �擾�ς݂̏ꍇ�͍ēǂݍ��݂��Ȃ�
            this.ConvertVersionRead();

            // �ϊ��������s
            status = this.ConvertProcSetting(_convertInfoParam.ConvertVersionMst);

            return status;
        }


        /// <summary>
        /// �����ϊ�����
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ϊ��������s���܂��B</br>
        /// <br>             �ꊇ�X�V�������ɌĂяo����܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseConvertProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusGet = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusInit = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // �}�X�^�o�[�W�������擾
                // �擾�ς݂̏ꍇ�͍ēǂݍ��݂��Ȃ�
                statusInit = this.ConvertVersionRead();

                // �A�Z���u���o�[�W�����ϊ���񏉊���
                // �������ς݂̏ꍇ�͉������Ȃ�
                statusGet = this.ConvertVersionSettingInitAsm();

                // �ϊ��p�^�[��
                // �@�}�X�^�A�A�Z���u���o�[�W����������F�������Ȃ�
                // �A�}�X�^�A�A�Z���u���o�[�W�������قȂ�
                // �A�|�P�}�X�^�o�[�W�����ϊ��ς݁A�A�Z���u���o�[�W�������ϊ��F�}�X�^�o�[�W��������
                // �A�|�Q�}�X�^�o�[�W�����ϊ��ς݁A�A�Z���u���o�[�W�����ϊ��ς݁F�}�X�^�o�[�W�����������A�Z���u���o�[�W�����ϊ�
                // �A�|�R�}�X�^�o�[�W�������ϊ��A�A�Z���u���o�[�W�����ϊ��ς݁F�A�Z���u���o�[�W�����ϊ�

                    // �}�X�^�A�A�Z���u���o�[�W��������
                    if (_convertInfoParam.ConvertVersionMst != _convertInfoParam.ConvertVersionAsm)
                    {
                        // �}�X�^�o�[�W�����ƃA�Z���u���o�[�W�������قȂ�ꍇ
                        // �}�X�^�o�[�W���������ϊ��̏ꍇ�͉����������s�����ϊ��O�l��ԋp
                        // �A�|�P�A�A�|�Q�̃}�X�^�o�[�W���������ɂ�����
                        // �A�|�R�̏ꍇ�͉����������ꂸ�I������
                        status = this.ReleaseProcSetting(_convertInfoParam.ConvertVersionMst);

                        if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // ������̒l��ϊ��O�l�ɍĐݒ�
                            _convertSetParam = _convertInfoParam.ConvertGetParam;

                            // �A�Z���u���o�[�W�����ŕϊ����������s����
                            // �A�Z���u���o�[�W���������ϊ��̏ꍇ�͕ϊ��������s�����ϊ��O�l��ԋp
                            // �A�|�Q�A�A�|�R�̃A�Z���u���o�[�W�����ϊ��ɂ�����
                            // �A�|�P�̏ꍇ�͕ϊ��������ꂸ�I������
                            status = this.ConvertProcSetting(_convertInfoParam.ConvertVersionAsm);
                        }
                    }

            }
            catch (Exception ex)
            {
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseConvertProc", status);

                // ��O���͕ϊ��O�l��ԋp
                _convertInfoParam.ConvertGetParam = _convertSetParam;
            }

            return status;
        }

        #endregion // public���\�b�h

        #region public���\�b�h �ꊇ�X�V�p
        /// <summary>
        /// ��������
        /// �F�؏��A�o�[�W���������擾
        /// �ꊇ�X�V�p
        /// </summary>
        /// <returns>���s�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�X�V�p�����������s���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseInitLibLump()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int retryCnt = 0;

            #region ���g���C���ݒ�

            string fileName = this.InitializeXmlSettings();
            XmlReaderSettings settings = new XmlReaderSettings();

            if (fileName != string.Empty)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("RetryCnt"))
                            {
                                _maxRetryCnt = reader.ReadElementContentAsInt();
                            }

                            if (reader.IsStartElement("WaitTime"))
                            {
                                _waitTime = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib");
                }
            }

            #endregion // ���g���C���ݒ�

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= _maxRetryCnt)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(_waitTime);
                }

                try
                {
                    Directory.SetCurrentDirectory(this.GetCurrentDirectory());
                    // �A�Z���u���o�[�W�����擾
                    _convertInfoParam.ConvertVersionAsm = _convertVersionManager.ConvertVersionAsm;

                    // �}�X�^�o�[�W�������擾
                    statusVer = this.ConvertVersionReadLump();

                    // �e��������I�������ꍇ�A�X�e�[�^�X�𐳏�I���ɂ���
                    if (statusVer == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLibLump", status);
                }

                if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }

                retryCnt += 1;
            }

            return status;
        }
        #endregion

        #region private���\�b�h

        /// <summary>
        /// ���������Ăяo��
        /// </summary>
        /// <param name="convertSetVersion">�����������s�o�[�W����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����������Ăяo���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ReleaseProcSetting(int convertSetVersion)
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // �ϊ��ς݃o�[�W�����̏ꍇ�����������{
                if (convertSetVersion != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                {
                    // �p�����[�^�ݒ�
                    _convertVersionSetting.GoodsMakerCd = _goodsMakerCd;
                    _convertVersionSetting.GoodsNo = _goodsNo;
                    _convertVersionSetting.ConvertSetParam = _convertSetParam;
                    _convertVersionSetting.ConvertSetVersion = convertSetVersion;

                    // ��������
                    status = _convertVersionSetting.ReleaseProc();

                    if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        _convertInfoParam.ConvertGetParam = _convertVersionSetting.ConvertGetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                    else
                    {
                        // �ϊ����s���͕ϊ��O�l��ԋp
                        _convertInfoParam.ConvertGetParam = _convertSetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                    }
                }
                else
                {
                    // �ϊ����Ă��Ȃ��o�[�W�����̏ꍇ���̂܂ܕԋp
                    _convertInfoParam.ConvertGetParam = _convertSetParam;

                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseProcSetting");

                // ��O���͕ϊ��O�l��ԋp
                _convertInfoParam.ConvertGetParam = _convertSetParam;
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// �ϊ������Ăяo��
        /// </summary>
        /// <param name="convertSetVersion">�ϊ��������s�o�[�W����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ϊ��������Ăяo���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertProcSetting(int convertSetVersion)
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // �ϊ��ς݃o�[�W�����̏ꍇ�ϊ��������{
                if (convertSetVersion != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                {
                    // �p�����[�^�ݒ�
                    _convertVersionSetting.GoodsMakerCd = _goodsMakerCd;
                    _convertVersionSetting.GoodsNo = _goodsNo;
                    _convertVersionSetting.ConvertSetParam = _convertSetParam;
                    _convertVersionSetting.ConvertSetVersion = convertSetVersion;

                    // �ϊ�����
                    status = _convertVersionSetting.ConvertProc();

                    if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        _convertInfoParam.ConvertGetParam = _convertVersionSetting.ConvertGetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                    else
                    {
                        // �ϊ����s���͕ϊ��O�l��ԋp
                        _convertInfoParam.ConvertGetParam = _convertSetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                    }
                }
                else
                {
                    // �ϊ����Ă��Ȃ��o�[�W�����̏ꍇ���̂܂ܕԋp
                    _convertInfoParam.ConvertGetParam = _convertSetParam;

                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }

                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertProcSetting");

                // ��O���͕ϊ��O�l��ԋp
                _convertInfoParam.ConvertGetParam = _convertSetParam;
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// �R���o�[�g�Ώۃo�[�W�����擾
        /// �����[�g�N���X�Ăяo���p
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����[�g�N���X����Ăяo���ꂽ�ꍇ�̃R���o�[�g�Ώۃo�[�W�������擾���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionRead()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusDB = (int)ConstantManagement.DB_Status.ctDB_ERROR; // �o�[�W�������擾�X�e�[�^�X
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR; // �o�[�W�����Ǘ���񏉊����X�e�[�^�X
            ConvObjVerMngDB convObjVerMngDB;
            object outConvObjVerMng;
            ConvObjVerMngWork paraConvObjVerMngWork;

            if (!_isGetMstVersion)
            {
                try
                {
                    // �o�[�W�������擾�����s���̂ݎ��s
                    // �����p�����[�^�ݒ�
                    paraConvObjVerMngWork = new ConvObjVerMngWork();
                    paraConvObjVerMngWork.EnterpriseCode = _enterpriseCode;

                    // ��������
                    convObjVerMngDB = new ConvObjVerMngDB();

                    statusDB = convObjVerMngDB.Search(out outConvObjVerMng, (object)paraConvObjVerMngWork);

                    switch (statusDB)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            foreach (ConvObjVerMngWork listConvObjVerMng in (ArrayList)outConvObjVerMng)
                            {
                                if (!string.IsNullOrEmpty(listConvObjVerMng.ConvertObjVer))
                                {
                                    _convertInfoParam.ConvertVersionMst = int.Parse(listConvObjVerMng.ConvertObjVer);
                                }
                            }

                            // 2��ڈȍ~�͎��{���Ȃ�
                            _isGetMstVersion = true;
                            break;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            // 0��������i�����[�X�㏉����s�j
                            // 2��ڈȍ~�͎��{���Ȃ�
                            _isGetMstVersion = true;
                            break;

                        default:
                            // �擾���s
                            break;
                    }

                    // �}�X�^�o�[�W�����Ǘ���񏉊���
                    // �������ς݂̏ꍇ�͉������Ȃ�
                    statusVer = this.ConvertVersionSettingInitMst();
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionRead", status);
                }

                // �e�������۔���
                if (_isGetMstVersion && statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
                else
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                }
            }
            else
            {
                // �������ς݂̏ꍇ�͐���
                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }

            return status;
        }

        /// <summary>
        /// �}�X�^�R���o�[�g�Ώۃo�[�W�����擾
        /// �ꊇ�X�V�p
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�X�V�p�R���o�[�g�Ώۃo�[�W�������擾���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionReadLump()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusDB = (int)ConstantManagement.DB_Status.ctDB_ERROR; // �o�[�W�������擾�X�e�[�^�X
            IConvObjVerMngDB iConvObjVerMngDB;
            object outConvObjVerMng;
            ConvObjVerMngWork paraConvObjVerMngWork;

            // �o�[�W�������擾�����s���̂ݎ��s
            if (!_isGetMstVersion)
            {
                try
                {
                    // �����p�����[�^�ݒ�
                    paraConvObjVerMngWork = new ConvObjVerMngWork();
                    paraConvObjVerMngWork.EnterpriseCode = _enterpriseCode;

                    // ��������
                    iConvObjVerMngDB = MediationConvObjVerMngDB.GetConvObjVerMngDB();

                    statusDB = iConvObjVerMngDB.Search(out outConvObjVerMng, (object)paraConvObjVerMngWork);

                    switch (statusDB)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            foreach (ConvObjVerMngWork listConvObjVerMng in (ArrayList)outConvObjVerMng)
                            {
                                if (!string.IsNullOrEmpty(listConvObjVerMng.ConvertObjVer))
                                {
                                    _convertInfoParam.ConvertVersionMst = int.Parse(listConvObjVerMng.ConvertObjVer);
                                }
                            }

                            // 2��ڈȍ~�͎��{���Ȃ�
                            _isGetMstVersion = true;
                            break;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            // 0��������i�����[�X�㏉����s�j
                            // 2��ڈȍ~�͎��{���Ȃ�
                            _isGetMstVersion = true;
                            break;

                        default:
                            // �擾���s
                            break;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //���O�o��
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionReadLump", status);
                }

                // �e�������۔���
                if (_isGetMstVersion)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
            }
            else
            {
                // �������ς݂̏ꍇ�͐���
                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }

            return status;
        }

        /// <summary>
        /// �}�X�^�o�[�W�����ϊ��ݒ菉����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�o�[�W�����ϊ��ݒ�����������܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionSettingInitMst()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                if (!_isMstSettingInit)
                {
                    // �}�X�^�o�[�W�������ϊ��ς݃o�[�W�����̏ꍇ�̂ݎ��{
                    if (_convertInfoParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                    {
                        // �o�[�W�����Ǘ���񏉊���
                        _convertVersionSetting.EnterpriseCode = _enterpriseCode;
                        _convertVersionSetting.ConvertSetVersion = _convertInfoParam.ConvertVersionMst;
                        statusVer = _convertVersionSetting.VersionInitLib();
                    }
                    else
                    {
                        // ���ϊ��̏ꍇ������������
                        statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    if (statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        // ����I�������ꍇ�A�Ď擾���Ȃ�
                        _isMstSettingInit = true;
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionReadMst", status);
            }

            return status;
        }

        /// <summary>
        /// �A�Z���u���o�[�W�����ϊ��ݒ菉����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �A�Z���u���o�[�W�����ϊ��ݒ�����������܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionSettingInitAsm()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // ���������̏ꍇ
                if (!_isAsmSettingInit)
                {
                    // �A�Z���u���o�[�W�������ϊ��ς݃o�[�W�����̏ꍇ�̂ݎ��{
                    if (_convertInfoParam.ConvertVersionAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                    {
                        // �o�[�W�����Ǘ���񏉊���
                        _convertVersionSetting.EnterpriseCode = _enterpriseCode;
                        _convertVersionSetting.ConvertSetVersion = _convertInfoParam.ConvertVersionAsm;
                        statusVer = _convertVersionSetting.VersionInitLib();
                    }
                    else
                    {
                        // ���ϊ��̏ꍇ������������
                        statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    if (statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        // ����I�������ꍇ�A�Ď擾���Ȃ�
                        _isAsmSettingInit = true;
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionSettingInitAsm", status);
            }

            return status;
        }

        /// <summary>
        /// XML�t�@�C���ݒ���擾����
        /// �t�@�C�������݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Note       : XML�t�@�C���ݒ�����擾���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.InitializeXmlSettings");
            }

            return path;
        }

        /// <summary>
        /// �J�����g�t�H���_�̃p�X�擾
        /// �t�H���_�����݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Note       : �J�����g�t�H���_�̃p�X���擾���܂��B</br>
        /// <br>Programmer : 32470 ���� ���</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g��
                        // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //���O�o��
                WriteErrorLogProc(ex, "ConvertDoubleRelease.GetCurrentDirectory");

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(string errorText)
        {
            try
            {
                base.WriteErrorLog(errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(Exception ex, string errorText)
        {
            try
            {
                base.WriteErrorLog(ex, errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <param name="status"></param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(Exception ex, string errorText, int status)
        {
            try
            {
                base.WriteErrorLog(ex, errorText, status);
            }
            catch
            {
            }
            finally
            {
            }
        }

        #endregion // private���\�b�h

        # region Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        public void Dispose()
        {
            // �C���X�^���X�������I�u�W�F�N�g�̏�����
            _convertInfoParam = null;
            _convertVersionSetting = null;
            _convertVersionManager = null;
            _isGetMstVersion = false;
            _isMstSettingInit = false;

            #region �f�o�b�O
            //try
            //{
            //    File.AppendAllText(logpath, Environment.NewLine + string.Format(LOGOUTPUT_INFO_END, "Dispose", DateTime.Now.ToString("HH:mm:ss.fffffff")));
            //}
            //catch
            //{
            //}
            #endregion // �f�o�b�O
        }
        #endregion

    }

    public class ConvertInfoParam
    {
        #region �v���C�x�[�g�ϐ�

        #region �v���p�e�B�Ŏg�p

        /// <summary>�}�X�^�ϊ��o�[�W����</summary>
        private int _convertVersionMst;

        /// <summary>�A�Z���u���ϊ��o�[�W����</summary>
        private int _convertVersionAsm;

        /// <summary>�ϊ���p�����[�^</summary>
        private double _convertGetParam;

        #endregion // �v���p�e�B�Ŏg�p

        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// 
        /// </summary>
        public ConvertInfoParam()
        {
            //// �����l�Z�b�g
            _convertVersionMst = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
            _convertVersionAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
            _convertGetParam = double.MinValue;
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// �}�X�^�ϊ��o�[�W����
        /// </summary>
        public int ConvertVersionMst
        {
            get { return _convertVersionMst; }
            set { _convertVersionMst = value; }
        }

        /// <summary>
        /// �A�Z���u���ϊ��o�[�W����
        /// </summary>
        public int ConvertVersionAsm
        {
            get { return _convertVersionAsm; }
            set { _convertVersionAsm = value; }
        }

        // �ϊ���p�����[�^
        public double ConvertGetParam
        {
            get { return _convertGetParam; }
            set { _convertGetParam = value; }
        }
        #endregion // �v���p�e�B
    }
}
