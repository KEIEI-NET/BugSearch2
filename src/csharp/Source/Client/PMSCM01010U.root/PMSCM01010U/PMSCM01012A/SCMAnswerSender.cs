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
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2011/08/10  �C�����e : Web���SCM�󔭒��Z�b�g����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ZHANGYH
// �� �� ��  2011/07/12  �C�����e : 1�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �� �� ��  2011/09/06  �C�����e : Websync PCCUOE�̃`�����l����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/04/11  �C�����e : �������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/13  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ�
//                                : 14.���׎捞�敪�̍X�V���@�����ǑΉ�
//                                : 15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ�
//                                : 16.�����i�������ǑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SCMSenderParameterType = Tuple<
        List<ISCMOrderHeaderRecord>,    // 1�p���ځFSCM�󒍃f�[�^
        List<ISCMOrderCarRecord>,       // 2�p���ځFSCM�󒍃f�[�^(�ԗ����)
        List<ISCMOrderDetailRecord>,    // 3�p���ځFSCM�󒍖��׃f�[�^(�⍇���E����)
        List<ISCMOrderAnswerRecord>,    // 4�p���ځFSCM�󒍖��׃f�[�^(��)
        // -- DELETE 2011/08/10   ------ >>>>>>
        //NullObject,
        // -- DELETE 2011/08/10   ------ <<<<<<
        // -- ADD 2011/08/10   ------ >>>>>>
        List<ISCMAcOdSetDtRecord>,    // 5�p���ځFSCM�󒍃Z�b�g���i�f�[�^
        // -- ADD 2011/08/10   ------ <<<<<<
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    
    /// <summary>
    /// SCM�񓚑��M�����N���X
    /// </summary>
    public sealed class SCMAnswerSender
    {
        private const string MY_NAME = "SCMAnswerSender";

        #region <SCM����f�[�^�쐬����>

        /// <summary>SCM����f�[�^�쐬��</summary>
        private readonly SCMSalesDataMaker _salesDataMaker;
        /// <summary>SCM����f�[�^�쐬�҂��擾���܂��B</summary>
        private SCMSalesDataMaker SalesDataMaker { get { return _salesDataMaker; } }

        /// <summary>
        /// �񓚑��M�����p�p�����[�^�𐶐����܂��B
        /// </summary>
        /// <returns>�񓚑��M�����p�p�����[�^</returns>
        private SCMSenderParameterType CreateSenderParameter()
        {
            SCMSenderParameterType parameter = new SCMSenderParameterType();
            {
                List<ISCMOrderHeaderRecord> headerRecordList= new List<ISCMOrderHeaderRecord>();
                List<ISCMOrderCarRecord> carRecordList      = new List<ISCMOrderCarRecord>();
                List<ISCMOrderDetailRecord> detailRecordList= new List<ISCMOrderDetailRecord>();
                List<ISCMOrderAnswerRecord> answerRecordList= new List<ISCMOrderAnswerRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                List<ISCMAcOdSetDtRecord> setDtRecordList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<

                {
                    foreach (string salesKey in SalesDataMaker.SCMSalesListEssenceMap.Keys)
                    {
                        SCMSalesListEssence essence = SalesDataMaker.SCMSalesListEssenceMap[salesKey];

                        ISCMOrderHeaderRecord scmHeaderRecord = essence.SCMHeaderRecord;
                        if (scmHeaderRecord.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            continue;  // �󒍃X�e�[�^�X��"��"�̏ꍇ�A�񓚑��M���������s���Ȃ�
                        }

                        headerRecordList.Add(essence.SCMHeaderRecord);  // SCM�󒍃f�[�^
                        carRecordList.Add(essence.SCMCarRecord);        // SCM�󒍃f�[�^(�ԗ����)

                        ListIterator<ISCMOrderDetailRecord> scmDetailIterator = essence.CreateSCMDetailIterator();
                        while (scmDetailIterator.HasNext())
                        {
                            detailRecordList.Add(scmDetailIterator.GetNext());  // SCM�󒍖��׃f�[�^(�⍇���E����)
                        }

                        ListIterator<ISCMOrderAnswerRecord> scmAnswerIterator = essence.CreateSCMAnswerIterator();
                        while (scmAnswerIterator.HasNext())
                        {
                            answerRecordList.Add(scmAnswerIterator.GetNext());  // SCM�󒍖��׃f�[�^(��)
                        }

                        // -- ADD 2011/08/10   ------ >>>>>>
                        ListIterator<ISCMAcOdSetDtRecord> scmSetDtIterator = essence.CreateSCMSetDtIterator();
                        while (scmSetDtIterator.HasNext())
                        {
                            setDtRecordList.Add(scmSetDtIterator.GetNext());
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                }
                parameter.Member01 = headerRecordList;
                parameter.Member02 = carRecordList;
                parameter.Member03 = detailRecordList;
                parameter.Member04 = answerRecordList;
                // -- ADD 2011/08/10   ------ >>>>>>
                parameter.Member05 = setDtRecordList;
                // -- ADD 2011/08/10   ------ <<<<<<
            }
            return parameter;
        }

        #endregion // </SCM����f�[�^�쐬����>

        #region <���`�����[�g�̏����݌���>

        /// <summary>���`�����[�g�̏����݌���</summary>
        private SalesSlipWriterParameter _writedSalesSlipParameter;
        /// <summary>���`�����[�g�̏����݌��ʂ��擾�܂��͐ݒ肵�܂��B</summary>
        public SalesSlipWriterParameter WritedSalesSlipParameter
        {
            get { return _writedSalesSlipParameter; }
            set { _writedSalesSlipParameter = value; }
        }

        /// <summary>
        /// �񓚑��M�����p�p�����[�^�ɕϊ����܂��B
        /// </summary>
        /// <returns>�񓚑��M�����p�p�����[�^</returns>
        private SCMSenderParameterType ConvertSenderParameter()
        {
            const string METHOD_NAME = "ConvertSenderParameter()";  // ���O�p

            SCMSenderParameterType parameter = new SCMSenderParameterType();
            {
                List<ISCMOrderHeaderRecord> headerRecordList= new List<ISCMOrderHeaderRecord>();
                List<ISCMOrderCarRecord>    carRecordList   = new List<ISCMOrderCarRecord>();
                List<ISCMOrderDetailRecord> detailRecordList= new List<ISCMOrderDetailRecord>();
                List<ISCMOrderAnswerRecord> answerRecordList= new List<ISCMOrderAnswerRecord>();
                // -- ADD 2011/08/10   ------ >>>>>>
                List<ISCMAcOdSetDtRecord> setDtRecordList = new List<ISCMAcOdSetDtRecord>();
                // -- ADD 2011/08/10   ------ <<<<<<
                {
                    foreach (SalesSlipWriterItem salesSlipItem in WritedSalesSlipParameter.SalesSlipItemList)
                    {
                        if (salesSlipItem.SCMOrderData.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            #region <Log>

                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                                "�󒍃X�e�[�^�X���u20:�󒍁v�̂��߁A�񓚑��M�f�[�^�𐶐����܂���ł����B" + Environment.NewLine
                                + SCMDataHelper.GetProfile(salesSlipItem.SCMOrderData)
                            ));

                            #endregion // </Log>

                            continue;  // �󒍃X�e�[�^�X��"��"�̏ꍇ�A�񓚑��M���������s���Ȃ�
                        }

                        // SCM�󒍃f�[�^
                        headerRecordList.Add(new UserSCMOrderHeaderRecord(salesSlipItem.SCMOrderData));

                        // SCM�󒍃f�[�^(�ԗ����)
                        carRecordList.Add(new UserSCMOrderCarRecord(salesSlipItem.SCMOrderCarData));

                        // SCM�󒍖��׃f�[�^(�⍇���E����)
                        foreach (SCMAcOdrDtlIqWork detailData in salesSlipItem.SCMOrderDataDetailList)
                        {
                            detailRecordList.Add(new UserSCMOrderDetailRecord(detailData));
                        }

                        // SCM�󒍖��׃f�[�^(��)
                        foreach (SCMAcOdrDtlAsWork answerData in salesSlipItem.ScmOrderDataAnswerList)
                        {
                            answerRecordList.Add(new UserSCMOrderAnswerRecord(answerData));
                        }
                        // -- ADD 2011/08/10   ------ >>>>>>
                        foreach (SCMAcOdSetDtWork setDt in salesSlipItem.ScmOrderDataSetDtList)
                        {
                            setDtRecordList.Add(new UserSCMAcOdSetDtRecord(setDt));
                        }
                        // -- ADD 2011/08/10   ------ <<<<<<
                    }
                }
                parameter.Member01 = headerRecordList;
                parameter.Member02 = carRecordList;
                parameter.Member03 = detailRecordList;
                parameter.Member04 = answerRecordList;
                // -- ADD 2011/08/10   ------ >>>>>>
                parameter.Member05 = setDtRecordList;
                // -- ADD 2011/08/10   ------ <<<<<<
            }
            return parameter;
        }

        #endregion // </���`�����[�g�̏����݌���>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="salesDataMaker">SCM����f�[�^�쐬��</param>
        public SCMAnswerSender(SCMSalesDataMaker salesDataMaker)
        {
            _salesDataMaker = salesDataMaker;
        }

        #endregion // </Constructor>

        /// <summary>
        /// SCM Web�T�[�o�֑��M���܂��B
        /// </summary>
        /// <param name="sendEnterpriceCodeList">��ƃR�[�h���X�g</param>
        /// <param name="sendSectionCodeList">���_�R�[�h���X�g</param>
        /// <param name="writeFlg">DB�X�V�t���O</param>
        /// <returns>���ʃR�[�h</returns>
        // 2011.07.12 ZHANGYH EDT STA >>>>>>
        //public int SendToWebServer()
        //>>>2012/04/11
        //public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList)
        public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, bool writeFlg)
        //<<<2012/04/11
        // 2011.07.12 ZHANGYH EDT END <<<<<<
        {
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
            // 2011.07.12 ZHANGYH EDT END <<<<<<
            // 2011.09.06 zhouzy ADD STA >>>>>>
            List<SCMAcOdrDataWork> scmAcOdrDataList = null;
            // 2011.09.06 zhouzy ADD END <<<<<<


            SCMSenderParameterType parameter = null;
            {
                if (WritedSalesSlipParameter != null)
                {
                    parameter = ConvertSenderParameter();
                }
                else
                {
                    parameter = CreateSenderParameter();
                }
            }
            // SCM�󒍖��׃f�[�^(��)���Ȃ��ꍇ�A���M�����ɏI��
            if (parameter.Member04.Count.Equals(0)) return (int)ResultUtil.ResultCode.Normal;

            // -- DEL 2011/08/10   ------ >>>>>>
            //SCMSendController sender = new SCMMethodCalledController(
            //    parameter.Member01,
            //    parameter.Member02,
            //    parameter.Member03,
            //    parameter.Member04
            //);
            // -- DEL 2011/08/10   ------ <<<<<<

            // -- ADD 2011/08/10   ------ >>>>>>
            SCMSendController sender = new SCMMethodCalledController(
                parameter.Member01,
                parameter.Member02,
                parameter.Member04,
                parameter.Member05
            );
            // -- ADD 2011/08/10   ------ <<<<<<
            
            sender.OpenLog();
            // 2011.07.12 ZHANGYH EDT STA >>>>>>
            //int status = sender.Send();
            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            //int status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList);

            //>>>2012/04/11
            //int status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            int status = 0;
            if (writeFlg)
            {
                status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            }
            //<<<2012/04/11

            // 2011.09.06 zhouzy UPDATE END <<<<<<
            // 2011.07.12 ZHANGYH EDT END <<<<<<
            sender.CloseLog();

            return status;
        }

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// SCM Web�T�[�o�֑��M���܂��B�iSCM�󔭒��f�[�^�i�ԗ����j�t�j
        /// </summary>
        /// <param name="sendEnterpriceCodeList">��ƃR�[�h���X�g</param>
        /// <param name="sendSectionCodeList">���_�R�[�h���X�g</param>
        /// <param name="writeFlg">DB�X�V�t���O</param>
        /// <param name="scmOdDtCarList">SCM�󒍃f�[�^�i�ԗ����j</param>
        /// <returns>���ʃR�[�h</returns>
        public int SendToWebServer(out List<string> sendEnterpriceCodeList, out List<string> sendSectionCodeList, bool writeFlg, List<ScmOdDtCar> scmOdDtCarList)
        {
            sendEnterpriceCodeList = null;
            sendSectionCodeList = null;
            List<SCMAcOdrDataWork> scmAcOdrDataList = null;

            SCMSenderParameterType parameter = null;
            {
                if (WritedSalesSlipParameter != null)
                {
                    parameter = ConvertSenderParameter();
                }
                else
                {
                    parameter = CreateSenderParameter();
                }
            }
            // SCM�󒍖��׃f�[�^(��)���Ȃ��ꍇ�A���M�����ɏI��
            if (parameter.Member04.Count.Equals(0)) return (int)ResultUtil.ResultCode.Normal;

            SCMSendController sender = new SCMMethodCalledController(
                parameter.Member01,
                parameter.Member02,
                parameter.Member04,
                parameter.Member05,
                scmOdDtCarList
            );

            sender.OpenLog();

            int status = 0;
            if (writeFlg)
            {
                status = sender.Send(out sendEnterpriceCodeList, out sendSectionCodeList, out scmAcOdrDataList);
            }
            sender.CloseLog();

            return status;
        }
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ� ----------------------------------<<<<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// SCM Web�T�[�o�֑��M���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        public int SendToWebServer()
        {
            List<string> sendEnterpriceCodeList;
            List<string> sendSectionCodeList;
            //>>>2012/04/11
            //return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList);
            return SendToWebServer(out sendEnterpriceCodeList, out sendSectionCodeList, true);
            //<<<2012/04/11
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<
    }
}
