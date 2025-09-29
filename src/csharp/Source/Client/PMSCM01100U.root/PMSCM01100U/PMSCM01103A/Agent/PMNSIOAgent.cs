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
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2010/03/05  �C�����e : ���[�UDB�f�[�^(�󒍃f�[�^�A�ԗ����A���׏��)�擾���ɁA�����_�R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2010/03/15  �C�����e : �N���p�����[�^�ɓ`�[�ԍ��̒ǉ�
//                                  2010/03/05�̕s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/03/30  �C�����e : ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2010/04/08  �C�����e : �N���p�����[�^�̕ύX
//                                  (����`�[���͂���P�⍇���ɑ΂������`�[�ƂȂ�o�^���s�����ꍇ�A�ŏI�`�[�������M����Ȃ���)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/10/17  �C�����e : SCM��Q�Ή� SCM�A�g�����M�f�[�^�擾�������C�� ��10414
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/03/11  �C�����e : SCM�d�|�ꗗ��10639�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/11/26  �C�����e : SCM�d�|�ꗗ��10707�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �� �� ��  2015/06/30  �C�����e : �ASCM�d�|�ꗗ��10707 ���O�o�͂̒ǉ�
//----------------------------------------------------------------------------//

#define _LOCAL_DEBUG_

using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller.Util; // ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707

//#if _LOCAL_DEBUG_

//using SCMLocalDebug;

//#endif

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// PM.NS��I/O�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class PMNSIOAgent : SCMIOAgent
    {
        /// <summary>���O�p�̖���</summary>
        private const string MY_NAME = "PMNSIOAgent";

        #region <�{���̃A�N�Z�T>

        /// <summary>�{���̃A�N�Z�T</summary>
        private IIOWriteScmDB _realAccesser;
        /// <summary>�{���̃A�N�Z�T���擾���܂��B</summary>
        private IIOWriteScmDB RealAccesser
        {
            get
            {
                if (_realAccesser == null)
                {
                    _realAccesser = MediationIOWriteScmDB.GetIOWriteScmDB();
                }
                return _realAccesser;
            }
        }

        #endregion // </�{���̃A�N�Z�T>

        #region <���Ӑ�}�X�^>

        /// <summary>���Ӑ�}�X�^DB�̃A�N�Z�T</summary>
        private CustomerAgent _customerDB;
        /// <summary>���Ӑ�}�X�^DB�̃A�N�Z�T���擾���܂��B</summary>
        private CustomerAgent CustomerDB
        {
            get
            {
                if (_customerDB == null)
                {
                    _customerDB = new CustomerAgent();
                }
                return _customerDB;
            }
        }

        #endregion // </���Ӑ�}�X�^>

        #region <Constructor>

        // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
        ///// <summary>
        ///// �f�t�H���g�R���X�g���N�^
        ///// </summary>
        //public PMNSIOAgent() : base() { }
        // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<
        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="withoutCustomerInfo">���Ӑ��K�v�Ƃ��Ȃ��t���O</param>
        public PMNSIOAgent(bool withoutCustomerInfo) : base(withoutCustomerInfo) { }
        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<

        #endregion // </Constructor>

        #region <��������>
        List<ISCMOrderHeaderRecord> _headerList;
        List<ISCMOrderAnswerRecord> _answerList;
        List<ISCMOrderCarRecord> _carList;
        // -- ADD 2011/08/10   ------ >>>>>>
        List<ISCMAcOdSetDtRecord> _setDtList;
        // -- ADD 2011/08/10   ------ <<<<<<

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
                    int status = this.GetUserDBData();

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
                    int status = this.GetUserDBData();

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
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._carList;
                    }
                }
            }
            return foundList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// ���M����SCM�Z�b�g�}�X�^���������܂��B
        /// </summary>
        /// <returns>���M����SCM�Z�b�g�}�X�^</returns>
        protected override IList<ISCMAcOdSetDtRecord> FindSendingSetDtData()
        {
            IList<ISCMAcOdSetDtRecord> foundList = new List<ISCMAcOdSetDtRecord>();
            {
                if (this._setDtList != null)
                {
                    foundList = this._setDtList;
                }
                else
                {
                    int status = this.GetUserDBData();

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        foundList = this._setDtList;
                    }
                }
            }
            return foundList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        /// <summary>
        /// ���[�UDB�f�[�^(�󒍃f�[�^�A�ԗ����A���׏��)���擾����B
        /// </summary>
        /// <returns></returns>
        private int GetUserDBData()
        {
            const string METHOD = "GetUserDBData";
            const string INDENT = "\t    ";

            #region �e�X�g���W�b�N
            //this._headerList = CreateScmOdrDataForTest();
            //this._detailList = new List<ISCMOrderDetailRecord>();
            //this._answerList = CreateScmOdDtAnsForTest();
            //this._carList = CreateScmOdDtCarForTest();

            //return 0;
            #endregion

            // --- ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707 ------------------------------>>>>>
            try
            {
            // --- ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707 ------------------------------<<<<<
                this._headerList = new List<ISCMOrderHeaderRecord>();
                this._answerList = new List<ISCMOrderAnswerRecord>();
                this._carList = new List<ISCMOrderCarRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                _setDtList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<

                IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();

                // �����M�f�[�^�̎擾
                readWork.EnterpriseCode = EnterpriseCd;
                // 2010/03/15 Del >>>
                ////>>>2010/03/05
                //readWork.InqOtherSecCd = BelongSectionCode;
                ////<<<2010/03/05
                // 2010/03/15 Del <<<

                // ADD 2014/03/11 SCM�d�|�ꗗ��10639 -------------------------------------------------------------->>>>>
                object paraSalesSlipNumList = (object)SalesSlipNumList;
                // ADD 2014/03/11 SCM�d�|�ꗗ��10639 --------------------------------------------------------------<<<<< 
                object paraObject = readWork; // ����
                object retObject = new CustomSerializeArrayList(); // �߂�

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "IIOWriteScmDB.ScmZeroSearch()�F�����[�g�A�N�Z�X���c");
                // CHG 2014/03/11 SCM�d�|�ꗗ��10639 -------------------------------------------------------------->>>>>
                //int status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject);
                // UPD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                //int status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject, paraSalesSlipNumList, InquiryNumber);
                int retryLimit = 0;              // ���g���C��
                int sleepMS = 0;  // �҂�
                if (SettingInformation != null)
                {
                    // �ݒ���v���p�e�B���ݒ肳��Ă���ꍇ���g���C�ݒ���擾����
                    retryLimit = SettingInformation.ReadRetry;
                    // ThreadSleep�̐��x�~���b�Ȃ̂�1000�{����
                    sleepMS = SettingInformation.ReadSleepSec * 1000;
                }

                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                int count = 0;
                for (count = 0; count <= retryLimit; count++)
                {
                    status = this.RealAccesser.ScmZeroSearch(ref retObject, paraObject, paraSalesSlipNumList, InquiryNumber);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                    System.Threading.Thread.Sleep(sleepMS);
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, string.Format("{0}���g���C��:{1}", INDENT, count));
                // UPD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<
                // CHG 2014/03/11 SCM�d�|�ꗗ��10639 --------------------------------------------------------------<<<<<
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "IIOWriteScmDB.ScmZeroSearch()�F�����[�g�A�N�Z�X����");

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "DB�擾���ʂ�W�J���c");
                    // �W�J
                    foreach (object ret in (CustomSerializeArrayList)retObject)
                    {
                        SCMAcOdrDataWork header;
                        List<SCMAcOdrDtlIqWork> detailList;
                        List<SCMAcOdrDtlAsWork> answerList;
                        SCMAcOdrDtCarWork car;

                        // -- ADD 2011/08/10   ------ >>>>>>
                        List<SCMAcOdSetDtWork> setDtList;
                        // -- ADD 2011/08/10   ------ <<<<<<

                        //IOWriterUtil.ExpandSCMReadRet(ret, out header, out detailList, out answerList, out car);              // DEL 2011/08/12
                        IOWriterUtil.ExpandSCMReadRet(ret, out header, out detailList, out answerList, out setDtList, out car); // ADD 2011/08/12

                        // �񓚃f�[�^���Ȃ��f�[�^�͑ΏۊO
                        if (answerList.Count == 0)
                        {
                            continue;
                        }

                        // >>> 2010/04/08
                        //// 2010/03/15 Add >>>
                        //// �󒍃X�e�[�^�X���Z�b�g����Ă���ꍇ
                        //if (AcptAnOdrStatus != 0)
                        //{
                        //    // ���M�Ώۂ̃f�[�^�ȊO�͑ΏۊO
                        //    if (header.AcptAnOdrStatus != AcptAnOdrStatus || header.SalesSlipNum.Trim() != SalesSlipNum.Trim())
                        //    {
                        //        continue;
                        //    }
                        //}
                        //// 2010/03/15 Add <<<

                        // �⍇���ԍ����ݒ肳��Ă���ꍇ�A���⍇���ԍ��̂ݑ��M�ΏۂƂ���
                        if (InquiryNumber != 0)
                        {
                            if ((header.InquiryNumber != InquiryNumber) || (header.InqOrdDivCd != InqOrdDivCd))
                            {
                                continue;
                            }
                        }
                        //<<<2010/04/08

                        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
                        // �p�����[�^�ɔ���`�[�ԍ����ݒ肳��Ă��鎞�A�Ώ۔���`�[�ԍ��̂ݑ��M�ΏۂƂ���
                        bool retFound = false;  // true:���M�Ώہ@false:���M�ΏۊO
                        if (SalesSlipNumList != null && SalesSlipNumList.Count != 0)
                        {
                            for (int i = 0; i < SalesSlipNumList.Count; i++)
                            {
                                if (header.SalesSlipNum.Trim() == SalesSlipNumList[i].Trim())
                                {
                                    retFound = true;
                                    break;
                                }
                            }
                            if (!retFound)
                            {
                                continue;
                            }
                        }
                        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<

                        this._headerList.Add(new UserSCMOrderHeaderRecord(header));

                        answerList.Sort(new SCMAcOdrDtlAsWorkCompare());    // 2010/03/24 Add

                        foreach (SCMAcOdrDtlAsWork answer in answerList)
                        {
                            this._answerList.Add(new UserSCMOrderAnswerRecord(answer));
                        }

                        this._carList.Add(new UserSCMOrderCarRecord(car));

                        // -- ADD 2011/08/10   ------ >>>>>>
                        if (setDtList != null && setDtList.Count > 0)
                        {
                            setDtList.Sort(new SCMAcOdrSetDtWorkCompare());

                            foreach (SCMAcOdSetDtWork setDt in setDtList)
                            {
                                this._setDtList.Add(new UserSCMAcOdSetDtRecord(setDt));
                            }
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "DB�擾���ʂ�W�J����");

                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD,
                        string.Format("{0}���[�UDB�f�[�^�擾�ŃG���[ �X�e�[�^�X�F{1}", INDENT, status));
                    // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            // --- ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707 ------------------------------>>>>>
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, MsgHelper.GetDebugMsg(msg));
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // --- ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707 ------------------------------<<<<<
        }

        /// <summary>
        /// SCM�󔭒����׃f�[�^�i�񓚁j���A�L�[���Ƀ\�[�g����(�s�ԍ��A�s�}�Ԃ̂݋t��
        /// </summary>
        /// <remarks></remarks>
        private class SCMAcOdrDtlAsWorkCompare : Comparer<SCMAcOdrDtlAsWork>
        {
            public override int Compare(SCMAcOdrDtlAsWork x, SCMAcOdrDtlAsWork y)
            {
                int result = x.InqOriginalEpCd.Trim().CompareTo(y.InqOriginalEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOriginalSecCd.Trim().CompareTo(y.InqOriginalSecCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherEpCd.Trim().CompareTo(y.InqOtherEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherSecCd.Trim().CompareTo(y.InqOtherSecCd.Trim());
                if (result != 0) return result;

                result = x.InquiryNumber.CompareTo(y.InquiryNumber);
                if (result != 0) return result;

                result = x.UpdateDate.CompareTo(y.UpdateDate);
                if (result != 0) return result;

                result = x.UpdateTime.CompareTo(y.UpdateTime);
                if (result != 0) return result;

                result = y.InqRowNumber.CompareTo(x.InqRowNumber);
                if (result != 0) return result;

                result = y.InqRowNumDerivedNo.CompareTo(x.InqRowNumDerivedNo);
                if (result != 0) return result;

                return result;
            }
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCM�Z�b�g�}�X�^���A�L�[���Ƀ\�[�g����(�s�ԍ��A�s�}�Ԃ̂݋t��
        /// </summary>
        /// <remarks></remarks>
        private class SCMAcOdrSetDtWorkCompare : Comparer<SCMAcOdSetDtWork>
        {
            public override int Compare(SCMAcOdSetDtWork x, SCMAcOdSetDtWork y)
            {
                int result = x.InqOriginalEpCd.Trim().CompareTo(y.InqOriginalEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOriginalSecCd.Trim().CompareTo(y.InqOriginalSecCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherEpCd.Trim().CompareTo(y.InqOtherEpCd.Trim());
                if (result != 0) return result;

                result = x.InqOtherSecCd.Trim().CompareTo(y.InqOtherSecCd.Trim());
                if (result != 0) return result;

                result = x.InquiryNumber.CompareTo(y.InquiryNumber);
                if (result != 0) return result;

                return result;
            }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <test�f�[�^>

        //private readonly Int64 testInquiryNumber = 0;
        //private readonly DateTime testUpdateDate = DateTime.MinValue;
        //private readonly string salesSlipNum = "333444555";
        //private readonly int acptAnOdrStatus = 30; // ����

        ///// <summary>
        ///// �e�X�g�p�󔭒��f�[�^�쐬
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderHeaderRecord> CreateScmOdrDataForTest()
        //{
        //    List<ISCMOrderHeaderRecord> testDataList = new List<ISCMOrderHeaderRecord>();

        //    SCMAcOdrDataWork testData1 = new SCMAcOdrDataWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//�⍇������ƃR�[�h
        //    testData1.InqOriginalSecCd = "000001";//�⍇�������_�R�[�h
        //    testData1.InqOtherEpCd = "0101150842020000";//�⍇�����ƃR�[�h
        //    testData1.InqOtherSecCd = "01";//�⍇���拒�_�R�[�h
        //    testData1.InquiryNumber = testInquiryNumber;//�⍇���ԍ�
        //    testData1.CustomerCode = 555; // ���Ӑ�R�[�h
        //    testData1.UpdateDate = DateTime.MinValue;//�X�V�N����
        //    testData1.UpdateTime = 0;//�X�V�����b�~���b
        //    testData1.AnswerDivCd = 0;//�񓚋敪
        //    testData1.JudgementDate = DateTime.Now;//�m���
        //    testData1.InqOrdNote = "1";//�⍇���E�������l
        //    testData1.InqEmployeeCd = "0001";//�⍇���]�ƈ��R�[�h
        //    testData1.InqEmployeeNm = "1";//�⍇���]�ƈ�����
        //    testData1.AnsEmployeeCd = "0001";//�񓚏]�ƈ��R�[�h
        //    testData1.AnsEmployeeNm = "1";//�񓚏]�ƈ�����
        //    testData1.InquiryDate = DateTime.Now;//�⍇����
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // �󒍃X�e�[�^�X
        //    testData1.SalesSlipNum = salesSlipNum; // ����`�[�ԍ�
        //    testData1.SalesTotalTaxInc = 10500; // �`�[���v�ō�
        //    testData1.SalesSubtotalTax = 500; // ���㏬�v(��)
        //    testData1.InqOrdDivCd = 2; // �⍇���E������� 2:����
        //    testData1.InqOrdAnsDivCd = 2; // �┭�񓚁@2:��
        //    testData1.ReceiveDateTime = DateTime.MinValue;//��M����
        //    testData1.AnswerCreateDiv = 0; // ����

        //    testDataList.Add(new UserSCMOrderHeaderRecord(testData1));

        //    return testDataList;
        //}

        ///// <summary>
        ///// �e�X�g�p�󔭒����׃f�[�^(�⍇���E����)�쐬
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderDetailRecord> CreateScmOdDtInqForTest()
        //{
        //    List<ISCMOrderDetailRecord> testDataList = new List<ISCMOrderDetailRecord>();

        //    return testDataList;
        //}

        ///// <summary>
        ///// �e�X�g�p�󔭒����׃f�[�^(��)�쐬
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderAnswerRecord> CreateScmOdDtAnsForTest()
        //{
        //    List<ISCMOrderAnswerRecord> testDataList = new List<ISCMOrderAnswerRecord>();

        //    SCMAcOdrDtlAsWork testData1 = new SCMAcOdrDtlAsWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//�⍇������ƃR�[�h
        //    testData1.InqOriginalSecCd = "000001";//�⍇�������_�R�[�h
        //    testData1.InqOtherEpCd = "0101150842020000";//�⍇�����ƃR�[�h
        //    testData1.InqOtherSecCd = "01";//�⍇���拒�_�R�[�h
        //    testData1.InquiryNumber = testInquiryNumber;//�⍇���ԍ�
        //    testData1.UpdateDate = DateTime.MinValue;//�X�V�N���� 
        //    testData1.UpdateTime = 0;//�X�V�����b�~���b

        //    testData1.InqRowNumber = 1; // �⍇���s�ԍ�
        //    testData1.InqRowNumDerivedNo = 1; // �⍇���s�ԍ��}��
        //    testData1.InqOrgDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // �⍇�������׎���GUID
        //    testData1.InqOthDtlDiscGuid = new Guid("61459ebb-9db0-4722-9195-68ccf6f048ad"); // �⍇���斾�׎���GUID
        //    testData1.GoodsDivCd = 0; // ���i��� 0:���� 1:�D�� 2:���r���h 3:���� 4:���ϑ���
        //    testData1.RecyclePrtKindCode = 1; // ���T�C�N�����i��� 1���r���h
        //    testData1.RecyclePrtKindName = "���r���h";
        //    testData1.DeliveredGoodsDiv = 0; // �[�i�敪 0:�z�� 1:����
        //    testData1.HandleDivCode = 0; // �戵�敪 0:�戵�i 1:�[���m�F�� 2:���戵�i
        //    testData1.GoodsShape = 1; // ���i�`�� 1:���i 2:�p�i
        //    testData1.DelivrdGdsConfCd = 0; // �[�i�m�F�敪 0:���m�F 1:�m�F
        //    testData1.DeliGdsCmpltDueDate = DateTime.Now.AddMonths(3); // �[�i�����\���
        //    testData1.BLGoodsCode = 0001; // BL���i�R�[�h
        //    testData1.BLGoodsDrCode = 1; // BL���i�R�[�h�}��
        //    testData1.InqGoodsName = "1"; // �┭���i��
        //    testData1.AnsGoodsName = "1"; // �񓚏��i��
        //    testData1.SalesOrderCount = 2; // ������
        //    testData1.DeliveredGoodsCount = 1; // �[�i��
        //    testData1.GoodsNo = "TESTUENOret100"; // ���i�ԍ�
        //    testData1.GoodsMakerCd = 1; // ���i���[�J�[�R�[�h
        //    testData1.PureGoodsMakerCd = 1; // �������i���[�J�[�R�[�h
        //    testData1.InqPureGoodsNo = "TESTUENOpure100"; // �┭�������i�ԍ�
        //    testData1.AnsPureGoodsNo = "TESTUENOpure100"; // �񓚏������i�ԍ�
        //    testData1.ListPrice = 100; // �艿
        //    testData1.UnitPrice = 100; // �P��
        //    testData1.GoodsAddInfo = "1"; // ���i�⑫���
        //    testData1.RoughRrofit = 5; // �e���z
        //    testData1.RoughRate = 5; // �e����
        //    testData1.AnswerLimitDate = DateTime.Now; // �񓚊���
        //    testData1.CommentDtl = "1"; // ���l(����)
        //    testData1.ShelfNo = ""; // �I��
        //    testData1.AdditionalDivCd = 0; // �ǉ��敪
        //    testData1.CorrectDivCD = 0; // �����敪
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // �󒍃X�e�[�^�X
        //    testData1.SalesSlipNum = salesSlipNum; // ����`�[�ԍ�
        //    testData1.CampaignCode = 1; // �L�����y�[���R�[�h
        //    testData1.StockDiv = 1; // �݌ɋ敪
        //    testData1.InqOrdDivCd = 1; // �⍇���E�������
        //    testData1.DisplayOrder = 1; // �\������
        //    testData1.GoodsMngNo = 1; // ���i�Ǘ��ԍ��H

        //    testDataList.Add(new UserSCMOrderAnswerRecord(testData1));

        //    return testDataList;
        //}

        ///// <summary>
        ///// �e�X�g�p�󔭒��f�[�^(�ԗ����)�쐬
        ///// </summary>
        ///// <returns></returns>
        //private List<ISCMOrderCarRecord> CreateScmOdDtCarForTest()
        //{
        //    List<ISCMOrderCarRecord> testDataList = new List<ISCMOrderCarRecord>();

        //    SCMAcOdrDtCarWork testData1 = new SCMAcOdrDtCarWork();

        //    testData1.EnterpriseCode = "0101150842020000";
        //    testData1.InqOriginalEpCd = "0140150842030050";//�⍇������ƃR�[�h
        //    testData1.InqOriginalSecCd = "000001";//�⍇�������_�R�[�h
        //    testData1.InquiryNumber = testInquiryNumber;//�⍇���ԍ�

        //    testData1.NumberPlate1Code = 11; // ���^�������ԍ�
        //    testData1.NumberPlate1Name = "1"; // ���^�����ǖ���
        //    testData1.NumberPlate2 = "1"; // �ԗ��o�^�ԍ�(���)
        //    testData1.NumberPlate3 = "1"; // �ԗ��o�^�ԍ�(�J�i)
        //    testData1.NumberPlate4 = 1234; // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
        //    testData1.ModelDesignationNo = 5; // �^���w��ԍ�
        //    testData1.CategoryNo = 1; // �ޕʔԍ�
        //    testData1.MakerCode = 1; // ���[�J�[�R�[�h
        //    testData1.ModelCode = 1; // �Ԏ�R�[�h
        //    testData1.ModelSubCode = 1; // �Ԏ�T�u�R�[�h
        //    testData1.ModelName = "1"; // �Ԏ햼
        //    testData1.CarInspectCertModel = "1"; // �Ԍ��،^��
        //    testData1.FullModel = "1"; // �^��(�t���^)
        //    testData1.FrameNo = "1"; // �ԑ�ԍ�
        //    testData1.FrameModel = "1"; // �ԑ�^��
        //    testData1.ChassisNo = "1"; // �V���V�[No
        //    testData1.CarProperNo = 1234; // �ԗ��ŗL�ԍ�
        //    testData1.ProduceTypeOfYearNum = 201012; // ���Y�N��(Num�^�C�v)
        //    testData1.Comment = "1"; // �R�����g
        //    testData1.RpColorCode = "1"; // ���y�A�J���[�R�[�h
        //    testData1.ColorName1 = "1"; // �J���[����1
        //    testData1.TrimCode = "1"; // �g�����R�[�h
        //    testData1.TrimName = "1"; // �g��������
        //    testData1.Mileage = 999999; // �ԗ����s����
        //    testData1.EquipObj = System.Text.Encoding.Unicode.GetBytes("1"); // �����I�u�W�F�g
        //    testData1.AcptAnOdrStatus = acptAnOdrStatus; // �󒍃X�e�[�^�X
        //    testData1.SalesSlipNum = salesSlipNum; // ����`�[�ԍ�

        //    testDataList.Add(new UserSCMOrderCarRecord(testData1));

        //    return testDataList;
        //}
        #endregion test�f�[�^

        #region <���M������ʗp�f�[�^�Z�b�g>

        /// <summary>
        /// ���M������ʗp�f�[�^�Z�b�g�𐶐����܂��B
        /// </summary>
        /// <returns>���M������ʗp�f�[�^�Z�b�g</returns>
        /// <see cref="SCMIOAgent"/>
        public override SCMSendViewDataSet CreateSCMSendViewDataSet()
        {
            const string METHOD = "CreateSCMSendViewDataSet";
            const string INDENT = "\t  ";

            SCMSendViewDataSet sendingViewDB = new SCMSendViewDataSet();
            {
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM�󒍃f�[�^���\�z���c");
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

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("���M�`�[���X�g�p�e�[�u���𐶐��FheaderID = [{0}]", headerID)); // ADD 2015/06/30�A T.Miyamoto SCM�d�|�ꗗ��10707

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

                    if (!WithoutCustomerInfo)   // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
                    {
                        Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("[{0}] @{1} : ���Ӑ�f�[�^���擾���c", headerID, headerRecord.CustomerCode));
                        CustomerDB.TakeCustomerInfo(headerRecord);  // FIXME:�ӊO�Ǝ��Ԃ������鏈��
                        Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + string.Format("[{0}] @{1} : ���Ӑ�f�[�^���擾����", headerID, headerRecord.CustomerCode));
                    }
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM�󒍃f�[�^���\�z����");

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM�󒍖��׃f�[�^(��)���\�z���c");
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
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "SCM�󒍖��׃f�[�^(��)���\�z����");

                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "���Ӑ�f�[�^���\�z���c");
                // ���Ӑ�}�X�^
                foreach (CustomerInfo customerInfo in CustomerDB.CustomerInfoMap.Values)
                {
                    sendingViewDB.SendingCustomer.AddSendingCustomerRow(
                        customerInfo.CustomerCode,  // ���Ӑ�R�[�h
                        customerInfo.CustomerSnm,   // ���Ӑ於��
                        customerInfo.OnlineKindDiv
                    );
                }
                Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "���Ӑ�f�[�^���\�z����");
            }
            return sendingViewDB;
        }

        #endregion // </���M������ʗp�f�[�^�Z�b�g>

        #region <�X�V�������s>
        /// <summary>
        /// �X�V�������s(Insert�ł͂Ȃ�)
        /// </summary>
        /// <returns></returns>
        public override int UpdateData(object wirtePara)
        {
            int status;

            status = this.RealAccesser.ScmDeleteInsert(ref wirtePara);

            return status;
        }
        #endregion

        /// <summary>
        /// �񓚋敪
        /// </summary>
        private enum AnswerDivCd : int
        {
            /// <summary>����</summary>
            NoAction = 0,
            /// <summary>�񓚒�(Web���݂̂̃X�e�[�^�X)</summary>
            OnAnswer = 1,
            /// <summary>�ꕔ��</summary>
            AnsParts = 10,
            /// <summary>�񓚊���</summary>
            AnsComplete = 20,
            /// <summary>�L�����Z��</summary>
            Cancel = 99
        }
    }
}
