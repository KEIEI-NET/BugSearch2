//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/03/30  �C�����e : ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
    using HeaderPair = KeyValuePair<SCMAcOdrDataWork, SCMAcOdrData>; // SCM�󒍃f�[�^�̃y�A(NS�ł�PM7��)

    /// <summary>
    /// PM7��I/O�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class PM7IOAgent : SCMIOAgent
    {
        const string MY_NAME = "PM7IOAgent";    // ���O�p

        #region <�t�@�C���I�[�v���̃��g���C>

        /// <summary>���g���C�̍ő��</summary>
        private const int RETRY_LIMIT = 5;
        /// <summary>���g���C�̍ő�񐔂��擾���܂��B</summary>
        private int RetryLimit { get { return RETRY_LIMIT; } }

        /// <summary>���g���C���̑҂�����[msec]</summary>
        private const int WAIT_MILLI_SEC = 1000;
        /// <summary>���g���C���̑҂�����[msec]���擾���܂��B</summary>
        private int WaitMilliSec { get { return WAIT_MILLI_SEC; } }

        #endregion // </�t�@�C���I�[�v���̃��g���C>

        #region <�f�[�^�p�X>

        /// <summary>�f�[�^�p�X</summary>
        private readonly string _dataPath;
        /// <summary>�f�[�^�p�X���擾���܂��B</summary>
        private string DataPath { get { return _dataPath; } }

        /// <summary>�N���p�����[�^�̔���`�[�ԍ�</summary>
        private readonly string _defaultSalesSlipNum;
        /// <summary>�N���p�����[�^�̔���`�[�ԍ����擾���܂��B</summary>
        private string DefaultSalesSlipNum { get { return _defaultSalesSlipNum; } } 

        /// <summary>�N���p�����[�^�̎󒍃X�e�[�^�X</summary>
        private readonly int _defaultAcptAnOdrStatus;
        /// <summary>�N���p�����[�^�̎󒍃X�e�[�^�X���擾���܂��B</summary>
        private int DefaultAcptAnOdrStatus { get { return _defaultAcptAnOdrStatus; } } 

        /// <summary>�N���p�����[�^�̃T�[�o�ԍ�</summary>
        private readonly int _defaultServerNumber = -1;
        /// <summary>�N���p�����[�^�̃T�[�o�ԍ����擾���܂��B</summary>
        private int DefaultServerNumber { get { return _defaultServerNumber; } } 

        /// <summary>�N���p�����[�^�̓��Ӑ�R�[�h</summary>
        private readonly int _defaultCustomerCd;
        /// <summary>�N���p�����[�^�̓��Ӑ�R�[�h���擾���܂��B</summary>
        private int DefaultCustomerCd { get { return _defaultCustomerCd; } } 

        #endregion // </�f�[�^�p�X>

        #region <XML�t�@�C����>
        /// <summary>���M�Ώۓ��Ӑ惊�X�g�̃t�@�C����</summary>
        public const string CUSTOMER_LIST_FILE_NAME = "ScmList.xml";

        /// <summary>SCM�󔭒��f�[�^.xml�̃t�@�C����(�g���q�Ȃ�)</summary>
        private const string HEADER_FILE_BODY = "ScmSdRvDt";

        /// <summary>SCM�󔭒����׃f�[�^(��).xml�̃t�@�C����(�g���q�Ȃ�)</summary>
        private const string ANSWER_FILE_BODY = "ScmSdRvDtl";

        /// <summary>SCM�󔭒��f�[�^(�ԗ����).xml�̃t�@�C����(�g���q�Ȃ�)</summary>
        private const string CAR_FILE_BODY = "ScmSdRvSya";

        /// <summary>�X�V�pCSV�t�@�C����(�g���q�Ȃ�)</summary>
        private const string UPDATE_CSV_BODY = "InquiryNumber";

        /// <summary>�X�V�N�����𐔒l�ϊ�����ۂ̃t�H�[�}�b�g</summary>
        private const string UPDATE_DATE_TO_NUMBER_FORMAT = "yyyyMMdd";
        #endregion

        #region <�����p�ێ��f�[�^>
        /// <summary>�Ǎ���XML�}�ԕێ�Dic (Key:���Ӑ�R�[�h(8������) + �`�[�ԍ� value:�}��)</summary>
        private Dictionary<string, int> _filePathDic;

        /// <summary>�⍇���ԍ�0�̓`�[�ԍ����X�g</summary>
        private List<string> _inquiryZeroSalesSlipList;
        #endregion

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^(PM7NormalController�p)
        /// </summary>
        /// <param name="dataPath">�f�[�^�p�X</param>
        public PM7IOAgent(
            string dataPath
        ) : base(false) // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
        {
            _dataPath = dataPath;

            this._filePathDic = new Dictionary<string, int>();
            this._inquiryZeroSalesSlipList = new List<string>();
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^(PM7BatchController�p)
        /// </summary>
        /// <param name="dataPath">�f�[�^�p�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="serverNumber">�T�[�o�ԍ�</param>
        /// <param name="customerCd">�N���p�����[�^�̓��Ӑ�R�[�h</param>
        public PM7IOAgent(
            string dataPath,
            string salesSlipNum,
            int acptAnOdrStatus,
            int serverNumber,
            int customerCd
        ) : base(true)  // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
        {
            _dataPath = dataPath;
            _defaultSalesSlipNum = salesSlipNum;
            _defaultAcptAnOdrStatus = acptAnOdrStatus;
            _defaultServerNumber = serverNumber;
            _defaultCustomerCd = customerCd;

            this._filePathDic = new Dictionary<string, int>();
            this._inquiryZeroSalesSlipList = new List<string>();
        }

        #endregion // </Constructor>

        #region <��������>

        List<ISCMOrderHeaderRecord> _headerList;
        List<ISCMOrderAnswerRecord> _answerList;
        List<ISCMOrderCarRecord> _carList;

        /// <summary>NS�ł�PM7�ł�SCM�󒍃f�[�^�̃}�b�v</summary>
        private IDictionary<string, HeaderPair> _nsPM7HeaderDataMap;
        /// <summary>NS�ł�PM7�ł�SCM�󒍃f�[�^�̃}�b�v</summary>
        /// <remarks>�L�[�FSCM�󒍃f�[�^���m�̊֘A�L�[�i���Ӑ�R�[�h + "_" + �󒍃X�e�[�^�X + "_" + ����`�[�ԍ��j</remarks>
        private IDictionary<string, HeaderPair> NSPM7HeaderDataMap
        {
            get
            {
                if (_nsPM7HeaderDataMap == null)
                {
                    _nsPM7HeaderDataMap = new Dictionary<string, HeaderPair>();
                }
                return _nsPM7HeaderDataMap;
            }
        }

        /// <summary>
        /// NS�ł�PM7�ł�SCM�󒍃f�[�^��ǉ����܂��B
        /// </summary>
        /// <param name="headerPair">NS�ł�PM7�ł�SCM�󒍃f�[�^�̑�</param>
        private void AddHeaderPair(HeaderPair headerPair)
        {
            string relationKey = SimpleXMLDB.GetHeaderRelationKey(headerPair.Key);
            if (!NSPM7HeaderDataMap.ContainsKey(relationKey))
            {
                NSPM7HeaderDataMap.Add(relationKey, headerPair);
            }
        }

        /// <summary>
        /// PM7�ł�SCM�󒍃f�[�^���������܂��B
        /// </summary>
        /// <param name="scmAcOdrDataWork">NS�ł�SCM�󒍃f�[�^</param>
        /// <returns>�΂ɂȂ�PM7�ł�SCM�󒍃f�[�^ ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        private SCMAcOdrData FindPM7SCMAcOdrData(SCMAcOdrDataWork scmAcOdrDataWork)
        {
            string relationKey = SimpleXMLDB.GetHeaderRelationKey(scmAcOdrDataWork);
            if (NSPM7HeaderDataMap.ContainsKey(relationKey))
            {
                return NSPM7HeaderDataMap[relationKey].Value;
            }
            return null;
        }

        #endregion

        #region <SCM�f�[�^����>

        /// <summary>
        /// ���M����SCM�󒍃f�[�^���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍃f�[�^</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderHeaderRecord> FindSendingHeaderData()
        {
            IList<ISCMOrderHeaderRecord> foundList = new List<ISCMOrderHeaderRecord>();
            {
                if (this._headerList != null)
                {
                    foundList = this._headerList;
                }
                else
                {
                    int status = this.GetUserXMLData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._headerList;
                    }
                }
            }
            return foundList;
        }

        /// <summary>
        /// ���M����SCM�󒍖��׃f�[�^(��)���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍖��׃f�[�^(��)</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderAnswerRecord> FindSendingAnswerData()
        {
            IList<ISCMOrderAnswerRecord> foundList = new List<ISCMOrderAnswerRecord>();
            {
                if (this._answerList != null)
                {
                    foundList = this._answerList;
                }
                else
                {
                    int status = this.GetUserXMLData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._answerList;
                    }
                }

            }
            return foundList;
        }

        /// <summary>
        /// ���M����SCM�󒍃f�[�^(�ԗ����)���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍃f�[�^(�ԗ����)</returns>
        /// <see cref="SCMIOAgent"/>
        protected override IList<ISCMOrderCarRecord> FindSendingCarData()
        {
            IList<ISCMOrderCarRecord> foundList = new List<ISCMOrderCarRecord>();
            {
                if (this._carList != null)
                {
                    foundList = this._carList;
                }
                else
                {
                    int status = this.GetUserXMLData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._carList;
                    }
                }
            }
            return foundList;
        }

        //--- ADD 2011/08/12 -------------------------------------------->>>
        /// <summary>
        /// ���M����SCM�Z�b�g�}�X�^���������܂��B
        /// </summary>
        /// <returns>���M����SCM�Z�b�g�}�X�^</returns>
        protected override IList<ISCMAcOdSetDtRecord> FindSendingSetDtData()
        {
            return null;
        }
        //--- ADD 2011/08/12 --------------------------------------------<<<

        /// <summary>
        /// ��XML�f�[�^�擾
        /// </summary>
        /// <returns></returns>
        private int GetUserXMLData()
        {
            _headerList = new List<ISCMOrderHeaderRecord>();
            _answerList = new List<ISCMOrderAnswerRecord>();
            _carList = new List<ISCMOrderCarRecord>();

            NSPM7HeaderDataMap.Clear();

            if (DefaultCustomerCd == 0)
            {
                // �P�̋N������
                return this.GetUserXMLDataALL();
            }
            else
            {
                // ���M�N������
                return this.GetUserXMLDataDefault();
            }
        }

        /// <summary>
        /// ��XML�S���擾(�P�̋N���p)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SCMFileOpeningException">XML�f�[�^�t�@�C�����쐬���ł��B</exception>
        private int GetUserXMLDataALL()
        {
            const string METHOD_NAME = "GetUserXMLDataALL()";   // ���O�p

            // XML�̃f�[�^���X�g(�t�B���^�O)
            List<SCMAcOdrDataWork> scmAcOdrDataWorkList = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList = new List<SCMAcOdrDtlAsWork>();
            List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList = new List<SCMAcOdrDtCarWork>();

            // �t�H���_�ꗗ�̎擾
            string[] custFolderList; // ���Ӑ斈�̃t�H���_�ꗗ
            string[] salesslipFolderList; // ���Ӑ�t�H���_���̓`�[�ԍ����t�H���_�ꗗ

            try
            {
                custFolderList = Directory.GetDirectories(DataPath);

                foreach (string custFolder in custFolderList)
                {
                    salesslipFolderList = Directory.GetDirectories(custFolder);

                    foreach (string salesslipFolder in salesslipFolderList)
                    {
                        for (int iCnt = 99; iCnt >= 0; iCnt--)
                        {
                            string check_SCMAcOdrDataFile = salesslipFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍃f�[�^

                            if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                            this.ReadAnswerXMLFiles(salesslipFolder, iCnt, ref scmAcOdrDataWorkList, ref scmAcOdrDtlAsWorkList, ref scmAcOdrDtCarWorkList);

                            break;
                        }
                    }
                }

                // �X�V�������ݒ肳��Ă���f�[�^���폜
                scmAcOdrDataWorkList.RemoveAll(
                    delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                    {
                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                scmAcOdrDtlAsWorkList.RemoveAll(
                    delegate(SCMAcOdrDtlAsWork scmAcOdrDtlAsWork)
                    {
                        if (scmAcOdrDtlAsWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // �ԗ����̓w�b�_�Ɠ��L�[�̃f�[�^���擾
                scmAcOdrDtCarWorkList.RemoveAll(
                    delegate(SCMAcOdrDtCarWork scmAcOdrDtCarWork)
                    {
                        if (!scmAcOdrDataWorkList.Exists(
                                delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                                {
                                    if (scmAcOdrDataWork.InqOriginalEpCd.Trim() == scmAcOdrDtCarWork.InqOriginalEpCd.Trim()
                                        && scmAcOdrDataWork.InqOriginalSecCd.Trim() == scmAcOdrDtCarWork.InqOriginalSecCd.Trim()
                                        && scmAcOdrDataWork.InquiryNumber == scmAcOdrDtCarWork.InquiryNumber
                                        && scmAcOdrDataWork.AcptAnOdrStatus == scmAcOdrDtCarWork.AcptAnOdrStatus
                                        && scmAcOdrDataWork.SalesSlipNum == scmAcOdrDtCarWork.SalesSlipNum)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            )
                            )
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                foreach (SCMAcOdrDataWork scmAcOdrDataWork in scmAcOdrDataWorkList)
                {
                    _headerList.Add(new UserSCMOrderHeaderRecord(scmAcOdrDataWork));
                }

                foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsWork in scmAcOdrDtlAsWorkList)
                {
                    _answerList.Add(new UserSCMOrderAnswerRecord(scmAcOdrDtlAsWork));
                }

                foreach (SCMAcOdrDtCarWork scmAcOdrDtCarWork in scmAcOdrDtCarWorkList)
                {
                    _carList.Add(new UserSCMOrderCarRecord(scmAcOdrDtCarWork));
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (SCMFileOpeningException ex)
            {
                #region <Log>

                string msg = "XML�f�[�^���쐬���ł��B" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                throw ex;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n" + ex.ToString());

                #region <Log>

                string msg = "XML�f�[�^�̓Ǎ��݂Ɏ��s���܂����B" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ��XML�S���擾(���M�N���p)
        /// </summary>
        /// <returns></returns>
        private int GetUserXMLDataDefault()
        {
            const string METHOD_NAME = "GetUserXMLDataDefault()";   // ���O�p

            // XML�̃f�[�^���X�g(�t�B���^�O)
            List<SCMAcOdrDataWork> scmAcOdrDataWorkList = new List<SCMAcOdrDataWork>();
            List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList = new List<SCMAcOdrDtlAsWork>();
            List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList = new List<SCMAcOdrDtCarWork>();

            string fileFolder = DataPath
                                + @"\" + GetCustomerFolderName(DefaultCustomerCd)
                                + @"\" + GetSalesSlipNumberFolderName(DefaultAcptAnOdrStatus, DefaultSalesSlipNum);
            
            try
            {
                // �}�Ԏ擾
                for (int iCnt = 99; iCnt >= 0; iCnt--)
                {
                    string check_SCMAcOdrDataFile = fileFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍃f�[�^

                    if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                    this.ReadAnswerXMLFiles(fileFolder, iCnt, ref scmAcOdrDataWorkList, ref scmAcOdrDtlAsWorkList, ref scmAcOdrDtCarWorkList);

                    break;
                }

                // �X�V�������ݒ肳��Ă���f�[�^���폜
                scmAcOdrDataWorkList.RemoveAll(
                    delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                    {
                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                scmAcOdrDtlAsWorkList.RemoveAll(
                    delegate(SCMAcOdrDtlAsWork scmAcOdrDtlAsWork)
                    {
                        if (scmAcOdrDtlAsWork.UpdateDate != DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                // �ԗ����̓w�b�_�Ɠ��L�[�̃f�[�^���擾
                scmAcOdrDtCarWorkList.RemoveAll(
                    delegate(SCMAcOdrDtCarWork scmAcOdrDtCarWork)
                    {
                        if (!scmAcOdrDataWorkList.Exists(
                                delegate(SCMAcOdrDataWork scmAcOdrDataWork)
                                {
                                    if (scmAcOdrDataWork.InqOriginalEpCd.Trim() == scmAcOdrDtCarWork.InqOriginalEpCd.Trim()
                                        && scmAcOdrDataWork.InqOriginalSecCd.Trim() == scmAcOdrDtCarWork.InqOriginalSecCd.Trim()
                                        && scmAcOdrDataWork.InquiryNumber == scmAcOdrDtCarWork.InquiryNumber
                                        && scmAcOdrDataWork.AcptAnOdrStatus == scmAcOdrDtCarWork.AcptAnOdrStatus
                                        && scmAcOdrDataWork.SalesSlipNum == scmAcOdrDtCarWork.SalesSlipNum)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            )
                            )
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                foreach (SCMAcOdrDataWork scmAcOdrDataWork in scmAcOdrDataWorkList)
                {
                    _headerList.Add(new UserSCMOrderHeaderRecord(scmAcOdrDataWork));
                }

                foreach (SCMAcOdrDtlAsWork scmAcOdrDtlAsWork in scmAcOdrDtlAsWorkList)
                {
                    _answerList.Add(new UserSCMOrderAnswerRecord(scmAcOdrDtlAsWork));
                }

                foreach (SCMAcOdrDtCarWork scmAcOdrDtCarWork in scmAcOdrDtCarWorkList)
                {
                    _carList.Add(new UserSCMOrderCarRecord(scmAcOdrDtCarWork));
                }

                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                #region <Log>

                string msg = "XML�f�[�^�̓Ǎ��݂Ɏ��s���܂����B" + Environment.NewLine;
                msg += ex.ToString();
                SimpleLogger.WriteDebugLog(MY_NAME, METHOD_NAME, MsgHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w��t�H���_�̉�XML��ǂݍ���
        /// </summary>
        /// <param name="targetFolder">�t�H���_�p�X</param>
        /// <param name="iCnt">�t�@�C���}��</param>
        /// <param name="scmAcOdrDataWorkList"></param>
        /// <param name="scmAcOdrDtlAsWorkList"></param>
        /// <param name="scmAcOdrDtCarWorkList"></param>
        /// <exception cref="SCMFileOpeningException">XML�f�[�^�t�@�C�����쐬���ł��B</exception>
        private void ReadAnswerXMLFiles(string targetFolder, 
                                        int iCnt,
                                        ref List<SCMAcOdrDataWork> scmAcOdrDataWorkList, 
                                        ref List<SCMAcOdrDtlAsWork> scmAcOdrDtlAsWorkList, 
                                        ref List<SCMAcOdrDtCarWork> scmAcOdrDtCarWorkList)
        {
            string scmAcOdrDataFile = targetFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍃f�[�^
            string scmAcOdrDtlAsWorkFile = targetFolder + String.Format(@"\" + ANSWER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍖��׃f�[�^(��)
            // TODO:�S�~�|���cstring scmAcOdrDtCarWorkFile = targetFolder + @"\" + CAR_FILE_BODY + @".xml"; // �󒍃f�[�^(�ԗ�)
            string scmAcOdrDtCarWorkFile = targetFolder + String.Format(@"\" + CAR_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍃f�[�^(�ԗ�)

            for (int retryCount = 0; retryCount <= RetryLimit; retryCount++)
            {
                string openingFileName = string.Empty;
                try
                {
                    // �󒍃f�[�^
                    System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                        = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));

                    openingFileName = scmAcOdrDataFile;
                    SCMAcOdrDataWork scmAcOdrDataWork;
                    using (System.IO.FileStream scmAcOdrData_Stream = new System.IO.FileStream(scmAcOdrDataFile, System.IO.FileMode.Open))
                    {
                        //scmAcOdrDataWork = SimpleXMLDB.DeserializeHeaderData(scmAcOdrData_Serializer, scmAcOdrData_Stream);

                        // TODO:NS�ł�PM7�ł�SCM�󒍃f�[�^���擾���A�ێ����� �摗�M���PM7�ł̃T�[�o�ԍ����g�p���邽��
                        HeaderPair headerPair = SimpleXMLDB.DeserializeHeaderData(scmAcOdrData_Stream);
                        {
                            AddHeaderPair(headerPair);
                        }
                        scmAcOdrDataWork = headerPair.Key;
                        scmAcOdrDataWorkList.Add(scmAcOdrDataWork);
                    }

                    // �󒍖��׃f�[�^(��)
                    System.Xml.Serialization.XmlSerializer scmAcOdrDtlAs_Serializer
                        = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtlAsWork[]));

                    openingFileName = scmAcOdrDtlAsWorkFile;
                    using (System.IO.FileStream scmAcOdrDtlAs_Stream = new System.IO.FileStream(scmAcOdrDtlAsWorkFile, System.IO.FileMode.Open))
                    {
                        SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWork = SimpleXMLDB.DeserializeAnswerData(scmAcOdrDtlAs_Serializer, scmAcOdrDtlAs_Stream);
                        scmAcOdrDtlAsWorkList.AddRange(scmAcOdrDtlAsWork);
                    }

                    if (System.IO.File.Exists(scmAcOdrDtCarWorkFile))
                    {
                        // �󒍃f�[�^(�ԗ�)
                        System.Xml.Serialization.XmlSerializer scmAcOdrDtCar_Serializer
                            = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtCarWork));

                        openingFileName = scmAcOdrDtCarWorkFile;
                        using (System.IO.FileStream scmAcOdrDtCar_Stream = new System.IO.FileStream(scmAcOdrDtCarWorkFile, System.IO.FileMode.Open))
                        {
                            SCMAcOdrDtCarWork scmAcOdrDtCarWork = SimpleXMLDB.DeserializeCarData(scmAcOdrDtCar_Serializer, scmAcOdrDtCar_Stream);
                            scmAcOdrDtCarWorkList.Add(scmAcOdrDtCarWork);
                        }
                    }

                    // �e�`�[�ԍ��t�H���_�z���̎}�Ԃ�ێ�(�X�V���ɐ������t�@�C����Ώۂɂ��邽��)
                    this._filePathDic.Add(scmAcOdrDataWork.CustomerCode.ToString("d8") + scmAcOdrDataWork.SalesSlipNum, iCnt);

                    // �⍇���ԍ�0�̓`�[�ԍ����X�g��ێ�(�񓚌��CSV�o�͗p)
                    if (scmAcOdrDataWork.InquiryNumber == 0)
                    {
                        this._inquiryZeroSalesSlipList.Add(scmAcOdrDataWork.SalesSlipNum);
                    }

                    break;
                }
                catch (IOException ex)
                {
                    if (retryCount.Equals(RetryLimit))
                    {
                        string msg = string.Format("�f�[�^�t�@�C�����I�[�v����({0})", openingFileName);
                        throw new SCMFileOpeningException(msg, ex);
                    }
                    System.Threading.Thread.Sleep(WaitMilliSec);
                }
            }   // for (int retryCount = 0; retryCount <= RetryLimit; retryCount++)
        }
        #endregion

        #region <���M������ʗp�f�[�^�Z�b�g>
        /// <summary>
        /// ���M������ʗp�f�[�^�Z�b�g�𐶐����܂��B
        /// </summary>
        /// <returns>���M������ʗp�f�[�^�Z�b�g</returns>
        /// <see cref="SCMIOAgent"/>
        public override SCMSendViewDataSet CreateSCMSendViewDataSet()
        {
            SCMSendViewDataSet sendingViewDB = new SCMSendViewDataSet();

            // SCM�󒍃f�[�^
            long headerID = 0;
            foreach (ISCMOrderHeaderRecord headerRecord in FoundSendingHeaderList)
            {
                string sendStatus;

                if (headerRecord.UpdateDate == DateTime.MinValue)
                {
                    sendStatus = "�����M";
                }
                else
                {
                    sendStatus = "���M��";
                }

                sendingViewDB.SendingSlipHeader.AddSendingSlipHeaderRow(
                    headerID++,                                     // ID
                    sendStatus,                                     // �ʐM���(�񓚋敪)
                    headerRecord.InquiryNumber,                     // �⍇���ԍ�
                    headerRecord.AcptAnOdrStatus,                   // �󒍃X�e�[�^�X
                    GetSlipTypeName(headerRecord.AcptAnOdrStatus),  // �`�[���
                    headerRecord.SalesSlipNum,                      // �`�[�ԍ�
                    headerRecord.InquiryDate,                       // ������t
                    headerRecord.SalesTotalTaxInc,                  // ���v���z
                    headerRecord.InqOrdNote,                        // ���l(�⍇���E�������l)
                    headerRecord.CustomerCode,                      // ���Ӑ�R�[�h
                    headerRecord.InqOriginalEpCd.Trim(),                   // �⍇������ƃR�[�h//@@@@20230303
                    headerRecord.InqOriginalSecCd,                  // �⍇�������_�R�[�h
                    headerRecord.InqOtherEpCd,                      // �⍇�����ƃR�[�h
                    headerRecord.InqOtherSecCd,                     // �⍇���拒�_�R�[�h
                    headerRecord.UpdateDate,                        // �X�V�N����
                    headerRecord.UpdateTime,                        // �X�V�����b�~���b
                    headerRecord.InqOrdDivCd                        // �⍇���E�������
                );

                //CustomerDB.TakeCustomerInfo(headerRecord);
            }

            // SCM�󒍖��׃f�[�^(��)
            long detailID = 0;
            foreach (ISCMOrderAnswerRecord answerRecord in FoundSendingAnswerList)
            {
                sendingViewDB.SendingSlipDetail.AddSendingSlipDetailRow(
                    detailID++,                                             // ID
                    RelationalHeaderMap[answerRecord.ToRelationKey() + answerRecord.SalesSlipNum.PadLeft(9, '0') + answerRecord.AcptAnOdrStatus.ToString("d2")].Key,  // �Ή�����SCM�󒍃f�[�^��ID
                    answerRecord.BLGoodsCode,           // BL�R�[�h(BL���i�R�[�h)
                    answerRecord.GoodsNo,               // �i��(���i�ԍ�)
                    answerRecord.AnsGoodsName,          // �i��(�񓚏��i��(�J�i))
                    answerRecord.DeliveredGoodsCount,   // ����(�[�i��)
                    answerRecord.UnitPrice,             // �P��
                    (long)Math.Round(answerRecord.UnitPrice * answerRecord.DeliveredGoodsCount, 0, MidpointRounding.AwayFromZero)  // �����_��1�ʂŎl�̌ܓ�
                );
            }

            #region ���M��Ώۓ��Ӑ惊�X�g���̎擾
            string _customerListPath = Path.Combine(DataPath, CUSTOMER_LIST_FILE_NAME);

            TspCustomer[] tsplst = null;

            System.Xml.Serialization.XmlSerializer cust_serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspCustomer[]));
            using (System.IO.FileStream stream = new System.IO.FileStream(_customerListPath, System.IO.FileMode.Open))
            {
                tsplst = (TspCustomer[])cust_serializer.Deserialize(stream);
            }

            // ���Ӑ�}�X�^
            foreach (TspCustomer tspCustomer in tsplst)
            {
                sendingViewDB.SendingCustomer.AddSendingCustomerRow(
                    tspCustomer.PmCustomerCode,  // ���Ӑ�R�[�h
                    tspCustomer.PmCustomerName,  // ���Ӑ於��
                    10                           // 10:SCM �Œ�
                );
            }

            #endregion

            return sendingViewDB;
        }
        #endregion

        #region ���Ӑ惊�X�g�e�[�u��(TspCustomer)
        /// <summary>
        /// ���Ӑ�e�[�u���N���X
        /// </summary>
        public class TspCustomer
        {
            #region �R���X�g���N�^
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public TspCustomer()
            {
                _PmEnterpriseCode = "";
                _PmSectionCode = "";
                _PmCustomerCode = 0;
                _PmCustomerName = "";
            }
            #endregion

            #region �t�B�[���h
            /// <summary>��ƃR�[�h</summary>
            public const string CUST_PmEnterpriseCode = "PmEnterpriseCode";
            /// <summary>���_�R�[�h</summary>
            public const string CUST_PmSectionCode = "PmSectionCode";
            /// <summary>���Ӑ�R�[�h</summary>
            public const string CUST_PmCustomerCode = "PmCustomerCode";
            /// <summary>���Ӑ於��</summary>
            public const string CUST_PmCustomerName = "PmCustomerName";
            #endregion

            #region �v���p�e�B
            private string _PmEnterpriseCode;
            private string _PmSectionCode;
            private int _PmCustomerCode;
            private string _PmCustomerName;

            /// <summary>
            /// ��ƃR�[�h
            /// </summary>
            public string PmEnterpriseCode
            {
                set { _PmEnterpriseCode = value; }

                get { return _PmEnterpriseCode; }
            }
            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string PmSectionCode
            {
                set { _PmSectionCode = value; }

                get { return _PmSectionCode; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int PmCustomerCode
            {
                set { _PmCustomerCode = value; }

                get { return _PmCustomerCode; }
            }
            /// <summary>
            /// ���Ӑ於��
            /// </summary>
            public string PmCustomerName
            {
                set { _PmCustomerName = value; }

                get { return _PmCustomerName; }
            }

            #endregion
        }

        #endregion

        #region <�X�V�������s>
        /// <summary>
        /// �X�V�������s(Insert�ł͂Ȃ�)
        /// </summary>
        /// <returns></returns>
        public override int UpdateData(object wirtePara)
        {
            CustomSerializeArrayList writeList = (CustomSerializeArrayList)wirtePara;

            try
            {
                foreach (CustomSerializeArrayList oneData in writeList)
                {
                    SCMAcOdrDataWork header;
                    List<SCMAcOdrDtlIqWork> detailList;
                    List<SCMAcOdrDtlAsWork> answerList;
                    SCMAcOdrDtCarWork car;

                    IOWriterUtil.ExpandSCMReadRet(oneData, out header, out detailList, out answerList, out car);

                    // ���Ӑ�R�[�h�A�`�[�ԍ����Ώۃt�@�C��������
                    string folderPath = DataPath
                                      + @"\" + GetCustomerFolderName(header)        // ���Ӑ�t�H���_ 
                                      + @"\" + GetSalesSlipNumberFolderName(header) // �`�[�ԍ��t�H���_
                                      + @"\";

                    // �}�Ԃ��擾
                    int branchNum = this._filePathDic[header.CustomerCode.ToString("d8") + header.SalesSlipNum];

                    // ��CSV�o�͏���
                    if (header.InquiryNumber != 0
                        && this._inquiryZeroSalesSlipList.Contains(header.SalesSlipNum))
                    {
                        // �X�V�O�̖⍇���ԍ���0�ŁA�X�V����Ă���ꍇCSV�o��
                        this.OutputUpdateCSV(header, folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml");
                    }

                    // �e�t�@�C���ɏ㏑��
                    // �󒍃f�[�^
                    //System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));
                    System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrData));

                    Debug.WriteLine(folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml");
                    using (System.IO.FileStream stream1 = new System.IO.FileStream(folderPath + HEADER_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                    {
                        MemoryStream memstr = new MemoryStream();

                        // TODO:PM7�ł�SCM�󒍃f�[�^��XML�f�[�^��W�J
                        SCMAcOdrData pm7SCMAcOdrData = FindPM7SCMAcOdrData(header);
                        if (pm7SCMAcOdrData != null)
                        {
                            SimpleXMLDB.CopyHeaderData(header, ref pm7SCMAcOdrData);
                            serializer1.Serialize(memstr, pm7SCMAcOdrData);
                        }
                        else
                        {
                            Debug.Assert(false, "�΂ɂȂ�PM7�ł�SCM�󒍃f�[�^�����݂��܂���B");
                            serializer1.Serialize(memstr, header);
                        }
                        byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                        stream1.Write(baff, 0, baff.Length);
                    }

                    // �󒍃f�[�^(�ԗ�)
                    if (car != null)
                    {
                        System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtCarWork));

                        using (System.IO.FileStream stream2 = new System.IO.FileStream(folderPath + CAR_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                        {
                            MemoryStream memstr = new MemoryStream();
                            serializer2.Serialize(memstr, car);
                            byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                            stream2.Write(baff, 0, baff.Length);
                        }
                    }

                    // �󒍖��׃f�[�^(��)
                    System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDtlAsWork[]));

                    using (System.IO.FileStream stream3 = new System.IO.FileStream(folderPath + ANSWER_FILE_BODY + branchNum.ToString("d2") + ".xml", System.IO.FileMode.Create))
                    {
                        MemoryStream memstr = new MemoryStream();
                        serializer3.Serialize(memstr, answerList.ToArray());
                        byte[] baff = Broadleaf.Windows.Forms.TSPSendXMLWriter.EncryptXML(memstr);
                        stream3.Write(baff, 0, baff.Length);
                    }
                }

                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n" + ex.ToString());
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// ���Ӑ�t�H���_�����擾���܂��B
        /// </summary>
        /// <param name="headerData">SCM�󒍃f�[�^</param>
        /// <returns>���Ӑ�R�[�h(8��)</returns>
        private static string GetCustomerFolderName(SCMAcOdrDataWork headerData)
        {
            return GetCustomerFolderName(headerData.CustomerCode);
        }

        /// <summary>
        /// ���Ӑ�t�H���_�����擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ�R�[�h(8��)</returns>
        private static string GetCustomerFolderName(int customerCode)
        {
            return customerCode.ToString("d8");
        }

        /// <summary>
        /// �`�[�ԍ��t�H���_�����擾���܂��B
        /// </summary>
        /// <param name="headerData">SCM�󒍃f�[�^</param>
        /// <returns>�󒍃X�e�[�^�X + "_" + ����`�[�ԍ�(8��)</returns>
        private static string GetSalesSlipNumberFolderName(SCMAcOdrDataWork headerData)
        {
            return GetSalesSlipNumberFolderName(headerData.AcptAnOdrStatus, headerData.SalesSlipNum);
        }

        /// <summary>
        /// �`�[�ԍ��t�H���_�����擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <returns>�󒍃X�e�[�^�X + "_" + ����`�[�ԍ�(8��)</returns>
        private static string GetSalesSlipNumberFolderName(
            int acptAnOdrStatus,
            string salesSlipNum
        )
        {
            return acptAnOdrStatus.ToString() + "_" + salesSlipNum.Trim().PadLeft(8, '0');
        }

        /// <summary>
        /// �󒍃X�e�[�^�X�񋓌^
        /// </summary>
        private enum AcptAnOdrStatus : int
        {
            /// <summary>10:����</summary>
            Estimate = 10,
            /// <summary>20:��</summary>
            Order = 20,
            /// <summary>30:����</summary>
            Sales = 30
        }

        /// <summary>
        /// PM7�̓`�[��ʗ񋓌^
        /// </summary>
        private enum PM7SlipType : int
        {
            /// <summary>����</summary>
            Sales = 10,
            /// <summary>����</summary>
            Estimate = 93
        }

        /// <summary>
        /// �X�VCSV�o�͏���
        /// </summary>
        /// <param name="header"></param>
        /// <param name="filePath"></param>
        private void OutputUpdateCSV(SCMAcOdrDataWork header, string filePath)
        {
            StringBuilder csvSB = new StringBuilder();
            {
                const string COMMA = ",";

                                        // �⍇���ԍ�
                csvSB.Append(ConvertCSVCell(header.InquiryNumber));
                csvSB.Append(COMMA);    // �X�V�N����
                csvSB.Append(ConvertCSVCell(header.UpdateDate.ToString(UPDATE_DATE_TO_NUMBER_FORMAT)));
                csvSB.Append(COMMA);    // �X�V�����b�~���b
                csvSB.Append(ConvertCSVCell(header.UpdateTime));
                csvSB.Append(COMMA);    // �⍇������ƃR�[�h
                csvSB.Append(ConvertCSVCell(header.InqOriginalEpCd.Trim()));//@@@@20230303
                csvSB.Append(COMMA);    // �⍇�������_�R�[�h
                csvSB.Append(ConvertCSVCell(header.InqOriginalSecCd));
                csvSB.Append(COMMA);    // �T�[�o�[�ԍ�
                csvSB.Append(ConvertCSVCell(GetServerNumber(header)));
                csvSB.Append(COMMA);    // �`�[���
                csvSB.Append(ConvertCSVCell(ConvertPM7SlipType(header)));
                csvSB.Append(COMMA);    // �`�[�ԍ�
                csvSB.Append(ConvertCSVCell(header.SalesSlipNum));
            }
            // TODO:�S�~�|��
            #region �{�c
            //using (FileStream _fs = new FileStream(DataPath + @"\" + UPDATE_CSV_BODY + header.SalesSlipNum + @".csv",
            //                                FileMode.Create, FileAccess.Write, FileShare.None))
            #endregion // �{�c
            using (FileStream _fs = new FileStream(
                    DataPath + @"\" + GetInquiryCSVFileName(header),
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None
            ))
            {
                using (StreamWriter _sw = new StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    _sw.WriteLine(csvSB.ToString());
                }
            }
        }

        /// <summary>
        /// �T�[�o�ԍ����擾���܂��B
        /// </summary>
        /// <param name="header">NS�ł�SCM�󒍃f�[�^</param>
        /// <returns>
        /// <c>DefaultServerNumber</c>�����̒l�̏ꍇ�A<c>DefaultServerNumber</c>��Ԃ��܂��B
        /// </returns>
        private int GetServerNumber(SCMAcOdrDataWork header)
        {
            if (DefaultServerNumber >= 0)
            {
                return DefaultServerNumber;
            }
            // �P�̋N�����̃T�[�o�ԍ�
            SCMAcOdrData pm7SCMAcOdrData = FindPM7SCMAcOdrData(header);
            if (pm7SCMAcOdrData != null)
            {
                return pm7SCMAcOdrData.ServerNumber;
            }
            return 0;
        }

        /// <summary>
        /// CSV�f�[�^�̃Z���l�ɕϊ����܂��B
        /// </summary>
        /// <typeparam name="T">�l�̌^</typeparam>
        /// <param name="cellValue">�l</param>
        /// <returns>" + �l + "</returns>
        private static string ConvertCSVCell<T>(T cellValue)
        {
            return "\"" + cellValue.ToString() + "\"";
        }

        /// <summary>
        /// �⍇���ԍ��X�V�pCSV�t�@�C�������擾���܂��B
        /// </summary>
        /// <param name="header">SCM�󒍃f�[�^</param>
        /// <returns>"InquiryNumber" + "_" + �⍇���ԍ� + "_" + �X�V���� + ".csv"</returns>
        private static string GetInquiryCSVFileName(SCMAcOdrDataWork header)
        {
            StringBuilder csvFileName = new StringBuilder();
            {
                const string DELIM = "_";

                csvFileName.Append(UPDATE_CSV_BODY);
                csvFileName.Append(DELIM);  // �⍇���ԍ�
                csvFileName.Append(header.InquiryNumber);

                // �X�V���t
                string dateValue = header.UpdateDate.ToString(UPDATE_DATE_TO_NUMBER_FORMAT);

                // �X�V����
                string timeValue = header.UpdateTime.ToString("000000");
                if (header.UpdateTime >= 100000000)
                {
                    timeValue = timeValue.Substring(0, 6);
                }

                csvFileName.Append(DELIM);  // �X�V�N���� + �X�V�����b�~���b(HHmmss)
                csvFileName.Append(dateValue).Append(timeValue);

                csvFileName.Append(".csv");
            }
            return csvFileName.ToString();
        }

        /// <summary>
        /// �󒍃X�e�[�^�X�ɕϊ����܂��B
        /// </summary>
        /// <param name="pm7SlipType">PM7�̓`�[���</param>
        /// <returns>
        /// 93�̏ꍇ�A����(=10)<br/>
        /// 10�̏ꍇ�A����(=30)
        /// </returns>
        /// <exception cref="ArgumentException">
        /// PM7�̓`�[��ʂ�����(=10)�܂��͌���(=93)�ł͂���܂���B
        /// </exception>
        public static int ConvertAcptAnOdrStatus(int pm7SlipType)
        {
            switch (pm7SlipType)
            {
                case (int)PM7SlipType.Sales:
                    return (int)AcptAnOdrStatus.Sales;
                case (int)PM7SlipType.Estimate:
                    return (int)AcptAnOdrStatus.Estimate;
                default:
                    string msg = string.Format(
                        "PM7�̓`�[��ʂ�����(={0})�܂��͌���(={1})�ł͂���܂���B",
                        (int)PM7SlipType.Sales,
                        (int)PM7SlipType.Estimate
                    );
                    throw new ArgumentException(msg);
            }
        }

        /// <summary>
        /// PM7�̓`�[��ʂɕϊ����܂��B
        /// </summary>
        /// <param name="header">SCM�󒍃f�[�^</param>
        /// <returns>
        /// SCM�󒍃f�[�^.�󒍃X�e�[�^�X������(=10)�̏ꍇ�A93<br/>
        /// SCM�󒍃f�[�^.�󒍃X�e�[�^�X������(=30)�̏ꍇ�A10
        /// </returns>
        /// <exception cref="ArgumentException">
        /// SCM�󒍃f�[�^.�󒍃X�e�[�^�X������(=10)�܂��͔���(=30)�ł͂���܂���B
        /// </exception>
        private static int ConvertPM7SlipType(SCMAcOdrDataWork header)
        {
            switch (header.AcptAnOdrStatus)
            {
                case (int)AcptAnOdrStatus.Estimate: //10:����
                    return (int)PM7SlipType.Estimate;
                case (int)AcptAnOdrStatus.Sales:    // 30:����
                    return (int)PM7SlipType.Sales;
                default:
                    string msg = string.Format(
                        "SCM�󒍃f�[�^.�󒍃X�e�[�^�X������(={0})�܂��͔���(={1})�ł͂���܂���B",
                        (int)AcptAnOdrStatus.Estimate,
                        (int)AcptAnOdrStatus.Sales
                    );
                    throw new ArgumentException(msg);
            }
        }
        #endregion // <�X�V�������s>

        #region <�ێ������؂�XML�t�@�C���폜����>
        /// <summary>
        /// �f�[�^�ێ������؂�XML�폜
        /// </summary>
        public override void DeletePassedPeriodXMLFiles(DateTime limit)
        {
            // �t�H���_�ꗗ�̎擾
            string[] custFolderList; // ���Ӑ斈�̃t�H���_�ꗗ
            string[] salesslipFolderList; // ���Ӑ�t�H���_���̓`�[�ԍ����t�H���_�ꗗ

            custFolderList = Directory.GetDirectories(DataPath);

            foreach (string custFolder in custFolderList)
            {
                salesslipFolderList = Directory.GetDirectories(custFolder);

                foreach (string salesslipFolder in salesslipFolderList)
                {
                    for (int iCnt = 99; iCnt >= 0; iCnt--)
                    {
                        string check_SCMAcOdrDataFile = salesslipFolder + String.Format(@"\" + HEADER_FILE_BODY + @"{0}.xml", iCnt.ToString("d2")); // �󒍃f�[�^

                        if (!System.IO.File.Exists(check_SCMAcOdrDataFile)) { continue; }

                        string scmAcOdrDataFile = check_SCMAcOdrDataFile;

                        // HACK:�S�~�|���c�󒍃f�[�^
                        //System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                        //    = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrDataWork));
                        System.Xml.Serialization.XmlSerializer scmAcOdrData_Serializer
                            = new System.Xml.Serialization.XmlSerializer(typeof(SCMAcOdrData));

                        SCMAcOdrDataWork scmAcOdrDataWork;
                        using (System.IO.FileStream scmAcOdrData_Stream = new System.IO.FileStream(scmAcOdrDataFile, System.IO.FileMode.Open))
                        {
                            // ��������
                            byte[] decryptXML = Broadleaf.Windows.Forms.TSPSendXMLReader.DecryptXML(scmAcOdrData_Stream);
                            MemoryStream memStr = new MemoryStream(decryptXML);
                            // TODO:�S�~�|���cscmAcOdrDataWork = (SCMAcOdrDataWork)scmAcOdrData_Serializer.Deserialize(memStr);
                            SCMAcOdrData pm7SCMAcOdrData = (SCMAcOdrData)scmAcOdrData_Serializer.Deserialize(memStr);
                            scmAcOdrDataWork = SimpleXMLDB.CreateSCMAcOdrDataWork(pm7SCMAcOdrData);
                        }

                        if (scmAcOdrDataWork.UpdateDate != DateTime.MinValue
                            && scmAcOdrDataWork.InquiryDate.CompareTo(limit) <= 0)
                        {
                            // �񓚍� ���� �⍇���������������O�ł���΍폜�Ώ�
                            Directory.Delete(salesslipFolder, true);
                        }

                        break;
                    }
                }

                string[] remainFolderList = Directory.GetDirectories(custFolder);

                if (remainFolderList.Length == 0)
                {
                    Directory.Delete(custFolder, true);
                }
            }
        }
        #endregion
    }
}
