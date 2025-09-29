//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCCUOE�����[�g�`�[���s�A�N�Z�X�N���X
// �v���O�����T�v   : PCCUOE�����[�g�`�[���s���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702938-02 �쐬�S�� : zhouzy
// �� �� ��  K2011/08/11 �쐬���e : PCCUOE�����[�g�`�[���s
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �� �� ��  2011/09/13  �C�����e : �����[�g�`�[���s�A�r�e���ɓn�������̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �� �� ��  2011/09/14  �C�����e : �����[�g�`�[���s�AActiveReport�o�[�W�������������̑Ή�
//                                  SF����ActiveReport2.0��ActiveReport3.0
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangqx
// �� �� ��  2011/09/28  �C�����e : Readmine#25623�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : x_chenjm
// �� �� ��  2011/10/12  �C�����e : Readmine#25623�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/06/22  �C�����e : RC-SCM�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhubj
// �� �� ��  2013/06/17  �C�����e : Redmine #36594�Ή� ��10542 SCM
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhubj
// �� �� ��  2013/07/28  �C�����e : Redmine #36594�Ή� ��10542 SCM NO.10�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhubj
// �� �� ��  2013/07/30  �C�����e : Redmine #36594�Ή� ��10542 SCM NO.12�ANO.13�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ����
// �� �� ��  2013/09/19  �C�����e : Redmine #40342�Ή� �����[�g�`�[���s���G���[�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/09/20  �C�����e : �����e��UOE���M���� ���x�x���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : 30973 ����
// �� �� ��  2014/12/25  �C�����e : ��BSSK�����[�g�`�[�Ή� �����[�g�`�[����ϋ敪(�o�l�[�i��)�����l�ݒ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : �{�{ ����
// �� �� ��  2015/11/20  �C�����e : �����`��Q�Ή�
//                                  �@SCM-DB�X�V�����Ƀ��g���C�����ǉ�
//                                  �A�G���[�E��O���̒ʒm�A�����o�߂̃��O�o�͂�ǉ�
//----------------------------------------------------------------------------//

//extern alias SFCMN02501alias; // 2012/06/22// DEL 2013/07/28 zhubj FOR Redmine #36594
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Web.Services;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;//zhouzy add 2011.09.13
using Broadleaf.Library.Globarization;//zhouzy add 2011.09.13
// --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
using System.Windows.Forms;
using Broadleaf.Application.Controller.Util;
// --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCCUOE�����[�g�`�[���s�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: PCCUOE�����[�g�`�[���s���s��</br>
    /// <br>Programmer : zhouzy</br>
    /// <br>Date       : K2011/08/11</br>
    /// <br>�Ǘ��ԍ�   : 10702938-02 SCM����(PCC-UOE�E�����[�g�`��)</br>
    /// <br>Update Note: 2013/07/28  zhubj</br>
    /// <br>           : Redmine #36594</br>
    /// <br>           : ��10542 SCM NO.10�̑Ή�</br>
    /// <br>Update Note: 2013/07/30 zhubj</br>
    /// <br>           : Redmine #36594</br>
    /// <br>           : ��10542 SCM NO.12�ANO.13�Ή�</br>
    /// </remarks>
    public class ScmRtPrtDtAcs
    {
        #region Private Member
        /// <summary>
        /// �F�؃R�[�h
        /// </summary> 
        private const string ctAuthenticateCode_SFCMN02555A = "e44f2f5a-7e2c-4368-86b0-ab355887c926";
        /// <summary>
        /// �F�؃R�[�h
        /// </summary> 
        private const string ctAuthenticateCode_SFCMN02501A = "00cd03ea-b30f-409e-a3df-0abd531648f3";
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�擾�p
        /// </summary>
        private IRmSlpPrtStDB _iRmSlpPrtStDB;
        /// <summary>
        /// SCM�����[�g�`�[����f�[�^�擾�p
        /// </summary>
        //private IScmRtPrtDtDB _iScmRtPrtDtDB;
        /// <summary>
        /// SCM�󔭒� �T�[�r�X �����[�g�I�u�W�F�N�g
        /// </summary>
        private IScmOdrDataDB _iScmOdrDataDB;// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <summary>
        /// �����[�g�`�[�p�����[�g�I�u�W�F�N�g
        /// </summary>
        private IScmRtPrtDtDB _iScmRtPrtDtDB;// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <summary>
        /// ����ԍ����X�g
        /// </summary>
        // UPD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
        //private static List<string> _slipNumlist = null;
        private List<string> _slipNumlist;
        // UPD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
        /// <summary>
        /// �₢���킹�ԍ����X�g
        /// </summary>
        // UPD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
        //private static List<string> _inquiryNumList = null;// ADD 2013/07/30 zhubj FOR Redmine #36594
        private List<string> _inquiryNumList;
        // UPD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
        ScmRtPrtDtSrchRstWork _scmRtPrtDtInfo = null;  �@// ������
        private int _CMTCooprtDiv;�@                   �@// SCM�󒍃f�[�^�ECMT�A�g�敪
        private const int ctCMTCooprtDiv_AutoInq = 11;   // SCM�󒍃f�[�^�ECMT�A�g�敪�̋K��l(11:�⍇��������)
        private const int ctCMTCooprtDiv_AutoOrder = 12; // SCM�󒍃f�[�^�ECMT�A�g�敪�̋K��l(12:����������)
        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
        #endregion

        #region �v���p�e�B
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private List<List<object>> _printDataList = new List<List<object>>();
        /// <summary>
        /// �����`�[���̃f�[�^���X�g
        /// index0:�`�[�ԍ��@index1:�X�V��(UpdateDate)�@index2:�X�V����(UpdateTime)
        /// </summary>
        public List<List<object>> PrintDataList
        {
            get { return _printDataList; }
            set { _printDataList = value; }
        }
        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
        // �ݒ���
        private SCMSendSettingInformation _settingInfo = null;

        /// <summary>�ݒ�����擾�܂��͐ݒ肵�܂��B</summary>
        public SCMSendSettingInformation SettingInformation
        {
            get { return _settingInfo; }
            set { _settingInfo = value; }
        }
        //// --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
        #endregion

        #region public method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ScmRtPrtDtAcs()
        {
            _iRmSlpPrtStDB = MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
            _iScmOdrDataDB = (IScmOdrDataDB)MediationGetScmOdrDataDB.GetScmOdrDataDB();// ADD 2013/07/28 zhubj FOR Redmine #36594
            _iScmRtPrtDtDB = (IScmRtPrtDtDB)MediationGetScmRtPrtDtDB.GetScmRtPrtDtDB();// ADD 2013/07/28 zhubj FOR Redmine #36594
        }

        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        /// <summary>
        /// SCM�����[�g�`�[����f�[�^��o�^����
        /// </summary>
        /// <param name="prtObj">����I�u�W�F�N�g</param>
        /// <param name="printData">����f�[�^</param>
        /// <param name="rmSlpPrtStWork">�����[�g�`�[����f�[�^</param>
        /// <param name="isOnlyOneSlip">����`�[���ʂ͂P���t���O�ifalse:�P���ȏ�Atrue:�P���j</param>
        /// <param name="isLastSlip">�Ō㑗�M�̔���`�[�t���O�ifalse:�Ō�ł͂Ȃ��Atrue:�Ō�j</param>
        /// <param name="isKeyChangeFlag">�����[�g�`�[�ŐV���ʋ敪KEY�ύX�t���O�ifalse:�ύX���Ȃ��Atrue:�ύX����j</param>// ADD 2013/07/28 zhubj FOR Redmine #36594
        /// <param name="errMsg">�G���[</param>
        /// <returns>�X�e�[�^�X</returns>
        //public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, out string errMsg)//DEL 2013/07/28 zhubj FOR Redmine #36594
        // UPD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
        //public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, bool isKeyChangeFlag, out string errMsg)//ADD 2013/07/28 zhubj FOR Redmine #36594
        public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, bool isOnlyOneSlip, bool isLastSlip, bool isKeyChangeFlag, List<string> slipNumlist, List<string> inquiryNumList, out string errMsg)//ADD 2013/07/28 zhubj FOR Redmine #36594
        // UPD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���擾�@�ʒm�ɕK�v�ȏ�������̂ŁA����̓`�[�����M�Ώۂ���Ȃ��Ă����{����
            ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
            status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
            try
            {
            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<

            errMsg = string.Empty;
            // ���M���������{�̏ꍇ�̓����`�o�͏��������{���Ȃ��ŁA�ʒm�����Ԃ� �⍇���ԍ����̔Ԃ���Ă���΁A���M�������{�ς݂Ƃ���
            bool send = false;
            if (printData != null && printData.Count > 0 && printData[0] != null && printData[0].Count > 1)
            {
                send = (printData[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>)[0].SALESDETAILRF_INQUIRYNUMBERRF > 0;
            }
            if (send)
            {
            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // DEL 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
                // status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
                // DEL 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                if (status == 0)
                {
                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    // �Y�������[�g�`�[�͂c�a�ő��݂���ꍇ�A���ԃ����[�g�f�[�^��KEY���A�ŐV���ʋ敪�X�V�������s��
                    // ���ԃ����[�g�f�[�^��KEY�ȊO�̃f�[�^�́A�ŐV���ʋ敪�X�V�������s��Ȃ�
                    if (isKeyChangeFlag)
                    {
                        ScmRtPrtDtParamWork scmRtPrtDtParam = new ScmRtPrtDtParamWork();
                        //�⍇������ƃR�[�h
                        scmRtPrtDtParam.InqOriginalEpCd = scmRtPrtDtWorkResult.InqOriginalEpCd.Trim();//@@@@20230303
                        //�⍇�������_�R�[�h
                        scmRtPrtDtParam.InqOriginalSecCd = scmRtPrtDtWorkResult.InqOriginalSecCd;
                        //�⍇�����ƃR�[�h
                        scmRtPrtDtParam.InqOtherEpCd = scmRtPrtDtWorkResult.InqOtherEpCd;
                        //�⍇���拒�_�R�[�h
                        scmRtPrtDtParam.InqOtherSecCd = scmRtPrtDtWorkResult.InqOtherSecCd;
                        //�⍇���ԍ� 
                        scmRtPrtDtParam.InquiryNumber = scmRtPrtDtWorkResult.InquiryNumber;
                        //�f�[�^���̓V�X�e��:[10�FPM]
                        scmRtPrtDtParam.DataInputSystem = 10;
                        //����`�[�ԍ�
                        scmRtPrtDtParam.SalesSlipNum = scmRtPrtDtWorkResult.SalesSlipNum;
                        //�ŐV���ʋ敪
                        scmRtPrtDtParam.LatestDiscCode = 0;
                        IScmRtPrtDtDB iScmRtPrtDtDB = (IScmRtPrtDtDB)MediationGetScmRtPrtDtDB.GetScmRtPrtDtDB();
                        ScmRtPrtDtSrchRstWork[] scmRtPrtDtSrchRstWorkArray;
                        ScmOdDtCarWork scmOdDtCarWork;
                        //SCM�����[�g�`�[����f�[�^��o�^����
                        bool msgDiv;
                        status = iScmRtPrtDtDB.ReadScmRtPrtDt(ctAuthenticateCode_SFCMN02555A, scmRtPrtDtParam, out scmRtPrtDtSrchRstWorkArray, out scmOdDtCarWork, out msgDiv, out errMsg);
                        if (status == 0)
                        {
                            scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 0;
                        }
                        else
                        {
                            scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 1;
                        }
                    }
                    else
                    {
                        scmRtPrtDtWorkResult.UpdateLatestDiscDivCd = 1;
                    }

                    // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
                    //SCM�����[�g�`�[����f�[�^��o�^����
                     status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg, printData);
                    // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        if (scmRtPrtDtWorkResult != null)
                        {
                            if (PrintDataList == null)
                            {
                                PrintDataList = new List<List<object>>();
                            }
                            List<object> wk = new List<object>();
                            wk.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                            wk.Add(scmRtPrtDtWorkResult.UpdateDate);
                            wk.Add(scmRtPrtDtWorkResult.UpdateTime);
                            PrintDataList.Add(wk);
                        }
                    }
                    // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // �P������ԍ��ꍇ
            if (isOnlyOneSlip)
            {
                //Websync�𗘗p���āA�������ɒʒm���܂�
                // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (status == 0)
                if (status == 0 && send)
                // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", scmRtPrtDtWorkResult.UpdateDate) * 1000 + scmRtPrtDtWorkResult.UpdateDate.Millisecond;
                    SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                        scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmRtPrtDtWorkResult.UpdateDate),
                        updateTime, scmRtPrtDtWorkResult.SlipPrtKind, scmRtPrtDtWorkResult.SalesSlipNum);
                }
            }
            else
            {
                if (status == 0)
                {
                    // �Ō㔄��ꍇ�A�������ɒʒm���܂�
                    if (isLastSlip)
                    {
                        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // ���M�Ώۂ�1����������Βʒm���Ȃ�
                        bool send2 = false;
                        int sendCnt = 0;
                        string sendSalesSlipNum = string.Empty;
                        foreach (string wk in inquiryNumList)
                        {
                            if(!string.IsNullOrEmpty(wk.Trim().Replace("0",string.Empty)))
                            {
                                send2 = true;
                                break;
                            }
                        }

                        if (send2)
                        {
                        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            // ADD 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                            _slipNumlist = new List<string>();
                            _inquiryNumList = new List<string>();
                            _slipNumlist = slipNumlist;
                            _inquiryNumList = inquiryNumList;
                            // ADD 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<

                            string salesSlipNums = "";
                            // DEL 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                            //_slipNumlist.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                            //_inquiryNumList.Add(scmRtPrtDtWorkResult.InquiryNumber.ToString());//ADD 2013/07/30 zhubj FOR Redmine#36594
                            // DEL 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
                            if (_slipNumlist != null)
                            {
                                int index = 0;
                                #region DEL 2013/07/30 zhubj FOR Redmine#36594
                                //// ����ԍ��͒ʒm���e�֒ǉ�
                                //_slipNumlist.ForEach(delegate(string slipNum)
                                //{
                                //    if (index == 0) salesSlipNums = slipNum;
                                //    else salesSlipNums += "_" + slipNum;
                                //    index++;
                                //});
                                //// �₢���킹�ԍ��͒ʒm���e�֒ǉ�
                                //salesSlipNums += "_" + scmRtPrtDtWorkResult.InquiryNumber;
                                #endregion
                                // --------------- ADD START 2013/07/30 zhubj FOR Redmine#36594-------->>>>
                                // ����ԍ��A�₢���킹�ԍ��͒ʒm���e�֒ǉ�
                                for (int indexNm = 0; indexNm < _slipNumlist.Count; indexNm++)
                                {
                                    // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // ���M�ΏۊO�͏Ȃ�
                                    if (string.IsNullOrEmpty(_inquiryNumList[indexNm].Trim().Replace("0", string.Empty)))
                                    {
                                        continue;
                                    }
                                    sendCnt++;
                                    sendSalesSlipNum = _slipNumlist[indexNm];
                                    // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                                    // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    // if (indexNm == 0) salesSlipNums = _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    // else salesSlipNums += "_" + _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    if (salesSlipNums.Trim() == string.Empty)
                                    {
                                        salesSlipNums = _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    }
                                    else
                                    {
                                        salesSlipNums += "_" + _slipNumlist[indexNm] + "_" + _inquiryNumList[indexNm];
                                    }
                                    // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                // --------------- ADD END 2013/07/30 zhubj FOR Redmine#36594--------<<<<
                            }

                            // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            // �������ɒʒm���܂�
                            //SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd, scmRtPrtDtWorkResult.InqOriginalSecCd,
                            //    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, 0,
                            //    0, scmRtPrtDtWorkResult.SlipPrtKind, salesSlipNums);
                            if (sendCnt == 1)
                            {
                                // �P���̏ꍇ

                                // ���M�Ώۂ�PrintDataList����T��
                                ScmRtPrtDtSrchRstWork wkScmRtPrtDtWorkResult = new ScmRtPrtDtSrchRstWork();
                                if (scmRtPrtDtWorkResult.SalesSlipNum == sendSalesSlipNum)
                                {
                                    // ����`�[�����M�Ώۂ̏ꍇ
                                    wkScmRtPrtDtWorkResult = scmRtPrtDtWorkResult;
                                }
                                else
                                {
                                    //�⍇������ƃR�[�h
                                    wkScmRtPrtDtWorkResult.InqOriginalEpCd = scmRtPrtDtWorkResult.InqOriginalEpCd.Trim();//@@@@20230303
                                    //�⍇�������_�R�[�h
                                    wkScmRtPrtDtWorkResult.InqOriginalSecCd = scmRtPrtDtWorkResult.InqOriginalSecCd;
                                    //�⍇�����ƃR�[�h
                                    wkScmRtPrtDtWorkResult.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                                    //�⍇���拒�_�R�[�h
                                    wkScmRtPrtDtWorkResult.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                                    //�`�[�ԍ�
                                    wkScmRtPrtDtWorkResult.SalesSlipNum = sendSalesSlipNum;
                                    //�`�[������
                                    wkScmRtPrtDtWorkResult.SlipPrtKind = 30;

                                    foreach (List<object> wk in PrintDataList)
                                    {
                                        if ((string)wk[0] == sendSalesSlipNum)
                                        {
                                            //�X�V�N����
                                            wkScmRtPrtDtWorkResult.UpdateDate = (DateTime)wk[1];
                                            //�X�V����
                                            wkScmRtPrtDtWorkResult.UpdateTime = (int)wk[2];
                                            break;
                                        }
                                    }
                                }

                                SCMChecker.NotifyOtherSidePCCUOERslip(wkScmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), wkScmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                                    wkScmRtPrtDtWorkResult.InqOtherEpCd, wkScmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkScmRtPrtDtWorkResult.UpdateDate),
                                    wkScmRtPrtDtWorkResult.UpdateTime, wkScmRtPrtDtWorkResult.SlipPrtKind, wkScmRtPrtDtWorkResult.SalesSlipNum);
                            }
                            else
                            {
                                // �����`�[�̏ꍇ
                                SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                                    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, 0,
                                    0, scmRtPrtDtWorkResult.SlipPrtKind, salesSlipNums);
                            }
                            // UPD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        }
                        // ADD 2013/09/20 �g�� 2013/09/99�z�M�\�� �����e��UOE���M���� ���x�x���Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // DEL 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                        //// �������ɒʒm�����B���������N���A
                        //_slipNumlist = null;
                        //_inquiryNumList = null;//ADD 2013/07/30 zhubj FOR Redmine#36594
                        // DEL 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
                    }
                    // DEL 2013/09/19 yugami Redmine#40342�Ή� --------------------------------------------------->>>>>
                    //else
                    //{
                        //// �Ō㔄�㖾�׈ȊO�ꍇ�A�������֕ۑ�����
                        //if (_slipNumlist == null) _slipNumlist = new List<string>();
                        //_slipNumlist.Add(scmRtPrtDtWorkResult.SalesSlipNum);
                        //if (_inquiryNumList == null) _inquiryNumList = new List<string>();//ADD 2013/07/30 zhubj FOR Redmine#36594
                        //_inquiryNumList.Add(scmRtPrtDtWorkResult.InquiryNumber.ToString());//ADD 2013/07/30 zhubj FOR Redmine#36594
                    //}
                    // DEL 2013/09/19 yugami Redmine#40342�Ή� ---------------------------------------------------<<<<<
                }
            }
            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
            }
            catch (Exception ex)
            {
                this.WriteOperationLog("PMKHN02102A", "WriteScmRtPrtDt", "�����[�g�`�[����f�[�^�o�^�G���[�F��O�y" + ex.Message + "�z");
                
                errMsg = "�����[�g�`�[����f�[�^�o�^���ɗ�O���������܂����B" + Environment.NewLine
                       + ex.Message + Environment.NewLine + Environment.NewLine
                       + "���Ӑ�Ƀ����[�g�`�[�����s����Ă��Ȃ��\��������܂��B" + Environment.NewLine 
                       + "�S���T�|�[�g�֘A�������肢�v���܂��B";
                this.errMessageBoxShow(errMsg);
            }
            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<

            return status;
        }
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        /// <summary>
        /// SCM�����[�g�`�[����f�[�^��o�^����
        /// </summary>
        /// <param name="prtObj">����I�u�W�F�N�g</param>
        /// <param name="printData">����f�[�^</param>
        /// <param name="rmSlpPrtStWork">�����[�g�`�[����f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        public int WriteScmRtPrtDt(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult = null;
            status = getScmRtPrtDtWorkResult(prtObj, printData, rmSlpPrtStWork, out scmRtPrtDtWorkResult, out errMsg);
            if (status == 0)
            {
                // update by wangqx 20110928  begin
                //SCM�����[�g�`�[����f�[�^��o�^����
                //status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg);
                status = WriteRmSlpPrtSt(ref scmRtPrtDtWorkResult, out errMsg, printData);
                // update by wangqx 20110928  end
            }

            //Websync�𗘗p���āA�������ɒʒm���܂�
            //zhouzy update 2011.09.13 begin
            //SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd, scmRtPrtDtWorkResult.InqOriginalSecCd,
            //    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, scmRtPrtDtWorkResult.InquiryNumber);
            if (status == 0)
            {
                int updateTime = TDateTime.DateTimeToLongDate("HHMMSS", scmRtPrtDtWorkResult.UpdateDate) * 1000 + scmRtPrtDtWorkResult.UpdateDate.Millisecond;
                SCMChecker.NotifyOtherSidePCCUOERslip(scmRtPrtDtWorkResult.InqOriginalEpCd.Trim(), scmRtPrtDtWorkResult.InqOriginalSecCd,//@@@@20230303
                    scmRtPrtDtWorkResult.InqOtherEpCd, scmRtPrtDtWorkResult.InqOtherSecCd, (int)SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(scmRtPrtDtWorkResult.UpdateDate),
                    updateTime, scmRtPrtDtWorkResult.SlipPrtKind, scmRtPrtDtWorkResult.SalesSlipNum);
            }
            //zhouzy update 2011.09.13 end

            return status;
        }
        #endregion

        #region private method
        /// <summary>
        /// SCM�����[�g�`�[����f�[�^���쐬����
        /// </summary>
        /// <param name="prtObj">����I�u�W�F�N�g</param>
        /// <param name="printData">����f�[�^</param>
        /// <param name="rmSlpPrtStWork">�����[�g�`�[����f�[�^</param>
        /// <returns>�����[�g�`�[����f�[�^</returns>
        private int getScmRtPrtDtWorkResult(ISlipPrintProc prtObj, List<ArrayList> printData, RmSlpPrtStWork rmSlpPrtStWork, out ScmRtPrtDtSrchRstWork scmRtPrtDtWorkResult, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            scmRtPrtDtWorkResult = new ScmRtPrtDtSrchRstWork();
            errMsg = null;

            //�����[�g�`�[����f�[�^
            MemoryStream ms = new MemoryStream();
            try
            {
                //zhouzy update 2011.09.14 begin
                //((ISlipPrintProc)prtObj).PrintDocument.Save(ms, DataDynamics.ActiveReports.Document.RdfFormat.AR20);
                ((ISlipPrintProc)prtObj).PrintDocument.Save(ms);
                //zhouzy update 2011.09.14 end
                ms.Position = 0;
                //����f�[�^��ۑ�����
                scmRtPrtDtWorkResult.RmtPrintData = ms.ToArray();

                //����f�[�^
                List<ArrayList> printDataWk = printData;

                // ����`�[�̏ꍇ
                FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printDataWk[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;

                // ���Ӑ�K�C�h������
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                Broadleaf.Application.UIData.CustomerInfo customerInfo;
                customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, true, out customerInfo);
                //�⍇������ƃR�[�h
                scmRtPrtDtWorkResult.InqOriginalEpCd = customerInfo.CustomerEpCode.Trim();//@@@@20230303
                //�⍇�������_�R�[�h
                scmRtPrtDtWorkResult.InqOriginalSecCd = customerInfo.CustomerSecCode;
                //�⍇�����ƃR�[�h
                scmRtPrtDtWorkResult.InqOtherEpCd = LoginInfoAcquisition.EnterpriseCode;
                //�⍇���拒�_�R�[�h
                scmRtPrtDtWorkResult.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                //�⍇���ԍ� 
                scmRtPrtDtWorkResult.InquiryNumber = frePSalesDetailWorkList[0].SALESDETAILRF_INQUIRYNUMBERRF;
                //�X�V�N����
                scmRtPrtDtWorkResult.UpdateDate = new DateTime(slipWork.SALESSLIPRF_UPDATEDATETIMERF);
                //�f�[�^���̓V�X�e��:[10�FPM]
                scmRtPrtDtWorkResult.DataInputSystem = 10;
                //�`�[������
                scmRtPrtDtWorkResult.SlipPrtKind = 30;
                //�`�[����ݒ�p���[ID
                scmRtPrtDtWorkResult.SlipPrtSetPaperId = rmSlpPrtStWork.SlipPrtSetPaperId;
                //����`�[�ԍ�
                scmRtPrtDtWorkResult.SalesSlipNum = slipWork.SALESSLIPRF_SALESSLIPNUMRF;
                //���M�S���҃R�[�h
                scmRtPrtDtWorkResult.SendEmployeeCd = LoginInfoAcquisition.Employee.EmployeeCode;
                //���M�S���Җ���
                scmRtPrtDtWorkResult.SenEmployeeNm = LoginInfoAcquisition.Employee.Name;
                //�ԍ��ԕi�`�[�敪
                scmRtPrtDtWorkResult.RdBlkRetSlpDivCd = getRdBlkRetSlpDivCd(printDataWk);
                // ADD 2014/12/25 ���� ��BSSK�����[�g�`�[�Ή� ---------------------------------------------->>>>>
                scmRtPrtDtWorkResult.PrtFinishDivCd = 1; // �����[�g�`�[����ϋ敪(�o�l�[�i��) 1:�������ݒ�
                // ADD 2014/12/25 ���� ��BSSK�����[�g�`�[�Ή� ----------------------------------------------<<<<<
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
            finally
            {
                _CMTCooprtDiv = -1; // CMT�A�g�敪
                _scmRtPrtDtInfo = scmRtPrtDtWorkResult; // ������̑Ҕ�
            }
            // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
            return status;
        }

        /// <summary>
        /// SCM�����[�g�`�[����f�[�^��o�^����
        /// </summary>
        /// <param name="scmRtPrtDtWork">�����[�g�`�[����f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        // update by wangqx 20110928  begin
        //private int WriteRmSlpPrtSt(ref ScmRtPrtDtSrchRstWork scmRtPrtDtWork, out string errMsg)
        private int WriteRmSlpPrtSt(ref ScmRtPrtDtSrchRstWork scmRtPrtDtWork, out string errMsg, List<ArrayList> printData)
        // update by wangqx 20110928 end
        {
            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "�����[�g�`�[����f�[�^�o�^����"); // ADD 2015/11/20 T.Miyamoto �����`��Q�Ή�
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            #region�@SCM��ƘA�������擾����
            int i = 0;
            ScmEpCnectWork[] scmEpCnectWorks = null;
            ScmEpScCntWork[] scmEpScCntWorks = null;
            ScmEpCnectWork aimScmEpCnectWork = null;
            ScmEpScCntWork aimScmEpScCntWork = null;
            bool msgDiv;
            try
            {
                SFCMN02564AServices sfcmn02564aservices = GetSFCMN02564AServices();

                //�⍇�����̊�ƃR�[�h�͑��݂���ꍇ
                if (!string.IsNullOrEmpty(scmRtPrtDtWork.InqOriginalEpCd.Trim()))	//@@@@20230303
                {
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM�A���ݒ�����擾���c"); // ADD 2015/11/20 T.Miyamoto �����`��Q�Ή�
                    //SCM�A���ݒ�����擾����
                    sfcmn02564aservices.SearchAll(scmRtPrtDtWork.InqOriginalEpCd.Trim(), scmRtPrtDtWork.InqOriginalSecCd, 0,//@@@@20230303
                        out  scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);
                    //SCM��ƘA���f�[�^��T��
                    if (null != scmEpCnectWorks && scmEpCnectWorks.Length > 0)
                    {
                        for (i = 0; i < scmEpCnectWorks.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(scmEpCnectWorks[i].CnectOtherEpCd)
                                && !string.IsNullOrEmpty(scmRtPrtDtWork.InqOtherEpCd)
                                && scmEpCnectWorks[i].CnectOtherEpCd.Trim().Equals(scmRtPrtDtWork.InqOtherEpCd.Trim()))
                            {
                                aimScmEpCnectWork = scmEpCnectWorks[i];
                                break;
                            }
                        }
                        if (null != aimScmEpCnectWork)
                        {
                            //�_���Ɩ�
                            scmRtPrtDtWork.CntrctntEpName = aimScmEpCnectWork.CnectOtherEpNm;
                            //�����_���Ɩ�
                            scmRtPrtDtWork.TransCntrctntEpName = aimScmEpCnectWork.CnectOriginalEpNm;
                        }
                    }

                    //SCM��Ƌ��_�A���f�[�^��T��
                    if (null != scmEpScCntWorks && scmEpScCntWorks.Length > 0)
                    {
                        for (i = 0; i < scmEpScCntWorks.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(scmEpScCntWorks[i].CnectOtherSecCd)
                                && !string.IsNullOrEmpty(scmRtPrtDtWork.InqOtherSecCd)
                                && scmEpScCntWorks[i].CnectOtherEpCd.Trim().Equals(scmRtPrtDtWork.InqOtherEpCd.Trim())
                                && scmEpScCntWorks[i].CnectOtherSecCd.Trim().Equals(scmRtPrtDtWork.InqOtherSecCd.Trim()))
                            {
                                aimScmEpScCntWork = scmEpScCntWorks[i];
                                break;
                            }
                        }
                        if (null != aimScmEpScCntWork)
                        {
                            //�_�񋒓_��
                            scmRtPrtDtWork.SectionName = aimScmEpScCntWork.CnectOtherSecNm;
                            //�����_�񋒓_��
                            scmRtPrtDtWork.TransSectionName = aimScmEpScCntWork.CnectOriginalSecNm;
                        }
                    }
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM�A���ݒ���̎擾���������܂����B"); // ADD 2015/11/20 T.Miyamoto �����`��Q�Ή�
                }

            #endregion

                #region SCM�܂���PCCUOE�ŉ񓚂����f�[�^���擾����
                SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "�⍇���񓚏����擾���c"); // ADD 2015/11/20 T.Miyamoto �����`��Q�Ή�
                //>>>2012/06/22
                //SFCMN02501AServices sfcmn02501aservices = GetSFCMN02501AServices();
                //SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices sfcmn02501aservices = GetSFCMN02501AServices();// DEL 2013/07/28 zhubj FOR Redmine #36594
                //<<<2012/06/22

                //>>>2012/06/22
                //ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();

                //ScmOdrDataWork[] scmOdrDataWorkArray;
                //ScmOdDtInqWork[] scmOdDtInqWorkArray;
                //ScmOdDtAnsWork[] scmOdDtAnsWorkArray;
                //ScmOdDtCarWork[] scmOdDtCarWorkArray;

                //SFCMN02501alias::ScmOdReadParamWork scmOdReadParamWork = new SFCMN02501alias::ScmOdReadParamWork();// DEL 2013/07/28 zhubj FOR Redmine #36594

                //SFCMN02501alias::ScmOdrDataWork[] scmOdrDataWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtInqWork[] scmOdDtInqWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594
                //SFCMN02501alias::ScmOdDtCarWork[] scmOdDtCarWorkArray = null;// DEL 2013/07/28 zhubj FOR Redmine #36594

                ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();// ADD 2013/07/28 zhubj FOR Redmine #36594

                ScmOdrDataWork[] scmOdrDataWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtInqWork[] scmOdDtInqWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                ScmOdDtCarWork[] scmOdDtCarWorkArray = null;// ADD 2013/07/28 zhubj FOR Redmine #36594
                //<<<2012/06/22

                scmOdReadParamWork.InqOriginalEpCd = scmRtPrtDtWork.InqOriginalEpCd.Trim();//@@@@20230303
                scmOdReadParamWork.InqOriginalSecCd = scmRtPrtDtWork.InqOriginalSecCd;
                scmOdReadParamWork.InqOtherEpCd = scmRtPrtDtWork.InqOtherEpCd;
                // uodate by x_chenjm 20111012 for 25623 begin
                // update by wangqx 20110928  begin
                scmOdReadParamWork.InqOtherSecCd = scmRtPrtDtWork.InqOtherSecCd;
                ////����f�[�^
                //List<ArrayList> printDataWk = printData;
                //// ����`�[�̏ꍇ
                //FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
                //scmOdReadParamWork.InqOtherSecCd = slipWork.SALESSLIPRF_RESULTSADDUPSECCDRF;
                // update by wangqx 20110928 end
                // uodate by x_chenjm 20111012 end
                scmOdReadParamWork.InquiryNumber = scmRtPrtDtWork.InquiryNumber;
                // 1:�⍇���E���� 2:��
                scmOdReadParamWork.InqOrdAnsDivCd = 2;
                // �ŐV���ʋ敪(-1:�w�薳�� 0:�ŐV�f�[�^ 1:���f�[�^)
                scmOdReadParamWork.LatestDiscCode = 0;
                //�⍇���񓚏����擾����
                //status = sfcmn02501aservices.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);// DEL 2013/07/28 zhubj FOR Redmine #36594
                status = _iScmOdrDataDB.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);// ADD 2013.07.28 zhubj FOR Redmine #36594
                SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "�⍇���񓚏��̎擾���������܂����B"); // ADD 2015/11/20 T.Miyamoto �����`��Q�Ή�
                #endregion
                if (status == 0)
                {
                    if (null != scmOdrDataWorkArray && scmOdrDataWorkArray.Length > 0)
                    {
                        //>>>2012/06/22
                        //ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];
                        //SFCMN02501alias::ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];// DEL 2013/07/28 zhubj FOR Redmine #36594
                        ScmOdrDataWork scmOdrDataWork = scmOdrDataWorkArray[0];// ADD 2013.07.28 zhubj FOR Redmine #36594
                        //<<<2012/06/22
                        //�ۋ�������
                        scmRtPrtDtWork.BillingAccuralDate = scmOdrDataWork.UpdateDate;
                        //�ۋ���������
                        scmRtPrtDtWork.BillingAccuralTime = scmOdrDataWork.UpdateTime;
                        //�ۋ�������
                        scmRtPrtDtWork.BillingOccurMonth = scmOdrDataWork.UpdateDate.Month;
                        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
                        //CMT�A�g�敪
                        _CMTCooprtDiv = scmOdrDataWork.CMTCooprtDiv;
                        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
                    }
                    ScmRtPrtDtSrchRstWork[] scmRtPrtDtWorks = new ScmRtPrtDtSrchRstWork[1];
                    scmRtPrtDtWorks[0] = scmRtPrtDtWork;
                    // --- UPD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
                    ////SFCMN02555AServices services = GetSFCMN02555AServices();// DEL 2013/07/28 zhubj FOR Redmine #36594
                    ////status = services.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);// DEL 2013/07/28 zhubj FOR Redmine #36594
                    //status = _iScmRtPrtDtDB.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);// ADD 2013/07/28 zhubj FOR Redmine #36594
                    //�yPMSCM01103A.config�z���烊�g���C�񐔁E�҂����Ԃ��擾
                    SCMSendSettingInformation SettingInfo = new SCMSendSettingInformation();
                    SettingInfo.Load();
                    int Limit = SettingInfo.DbRetry;           // ���g���C��
                    int SleepMS = SettingInfo.SleepSec * 1000; // �҂�

                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM-DB�X�V����(���g���C" + Limit.ToString() + "��A" + SettingInfo.SleepSec.ToString() + "�b�҂�)");
                    SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "�`�[�ԍ��F" + scmRtPrtDtWorks[0].SalesSlipNum + "�A�⍇���ԍ��F" + scmRtPrtDtWorks[0].InquiryNumber);

                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    int iCnt = 0;
                    for (iCnt = 0; iCnt <= Limit; iCnt++)
                    {
                        if (iCnt > 0)
                        {
                            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "���g���C" + iCnt.ToString() + "��� status=" + status.ToString());
                        }

                        status = _iScmRtPrtDtDB.Write(ctAuthenticateCode_SFCMN02555A, ref scmRtPrtDtWorks, out msgDiv, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            SimpleLogger.Write("PMKHN02102A", "WriteRmSlpPrtSt", "SCM-DB�X�V����������I�����܂����B");
                            break;
                        }
                        System.Threading.Thread.Sleep(SleepMS);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.WriteOperationLog("PMKHN02102A", "WriteRmSlpPrtSt", "�����[�g�`�[����f�[�^�o�^�G���[�F����`�[�ԍ��y" + scmRtPrtDtWorks[0].SalesSlipNum + "�z�X�e�[�^�X�y" + status.ToString() + "�z");

                        errMsg = "�����[�g�`�[����f�[�^�o�^���ɃG���[���������܂����B" + Environment.NewLine
                               + "(SCM-DB�X�V�G���[)" + Environment.NewLine 
                               + "����`�[�ԍ��y" + scmRtPrtDtWorks[0].SalesSlipNum + "�z" + Environment.NewLine
                               + "�X�e�[�^�X�y" + status.ToString() + "�z"+ Environment.NewLine + Environment.NewLine
                               + "���Ӑ�Ƀ����[�g�`�[�����s����Ă��Ȃ��\��������܂��B" + Environment.NewLine 
                               + "�S���T�|�[�g�֘A�������肢�v���܂��B";
                        this.errMessageBoxShow(errMsg);
                    }
                    // --- UPD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<

                    //>>>2012/06/22
                    if (status == 0)
                    {
                        if (scmEpCnectWorks != null && scmEpCnectWorks.Length != 0)
                        {
                            scmRtPrtDtWork = scmRtPrtDtWorks[0];
                        }
                    }
                    //<<<2012/06/22
                }
            }
            catch (Exception ex)
            {
                // --- UPD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
                //errMsg = ex.Message;
                //status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                this.WriteOperationLog("PMKHN02102A", "WriteRmSlpPrtSt", "�����[�g�`�[����f�[�^�o�^�G���[�F��O�y" + ex.Message + "�z");

                errMsg = "�����[�g�`�[����f�[�^�o�^���ɗ�O���������܂����B" + Environment.NewLine
                       + ex.Message + Environment.NewLine + Environment.NewLine
                       + "���Ӑ�Ƀ����[�g�`�[�����s����Ă��Ȃ��\��������܂��B" + Environment.NewLine 
                       + "�S���T�|�[�g�֘A�������肢�v���܂��B";
                this.errMessageBoxShow(errMsg);
                // --- UPD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
            }
            return status;
        }

        /// <summary>
        /// �ԍ��ԕi�`�[�敪�𔻒f����
        /// 0:���` 1:�ԓ` 2:�ԕi
        /// </summary>
        /// <param name="printDataWk">����f�[�^���[�N</param>
        /// <returns>�X�e�[�^�X</returns>
        private int getRdBlkRetSlpDivCd(List<ArrayList> printDataWk)
        {
            // ����`�[�f�[�^���[�N
            FrePSalesSlipWork slipWork = (printDataWk[0][0] as FrePSalesSlipWork);
            // ���㖾�׃f�[�^���[�N
            FrePSalesDetailWork salesDetailWork = null;
            List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork> frePSalesDetailWorkList = printDataWk[0][1] as List<Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork>;
            int iResult = -1;
            //����`�[�敪[0:����]�̏ꍇ
            if (slipWork.SALESSLIPRF_SALESSLIPCDRF == 0)
            {
                for (int i = 0; i < frePSalesDetailWorkList.Count; i++)
                {
                    salesDetailWork = frePSalesDetailWorkList[i];
                    if (salesDetailWork.SALESDETAILRF_SHIPMENTCNTRF == 0)
                    {
                        //�o�א�0�ȊO�̏ꍇ�A���̖��ׂ��Q�Ƃ���
                        //���`
                        iResult = 0;
                        continue;
                    }
                    else
                    {
                        if (salesDetailWork.SALESDETAILRF_SHIPMENTCNTRF > 0)
                        {
                            //�o�א�0�ȏ�̏ꍇ
                            if (salesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF != 2)
                            {
                                //����`�[�敪�i���ׁj[2:�ԕi]�ȊO�̏ꍇ,���`
                                iResult = 0;
                                break;
                            }
                            else
                            {
                                //�ԓ`
                                iResult = 1;
                                break;
                            }
                        }
                        else
                        {
                            //�o�א�0�ȏ�̏ꍇ
                            if (salesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF != 2)
                            {
                                //����`�[�敪�i���ׁj[2:�ԕi]�ȊO�̏ꍇ,�ԓ`
                                iResult = 1;
                                break;
                            }
                            else
                            {
                                //���`
                                iResult = 0;
                                break;
                            }
                        }
                    }
                }
                iResult = 0;
            }
            else
            {
                //�ԕi�̏ꍇ
                iResult = 2;
            }
            return iResult;
        }

        #region DEL 2013/07/28 zhubj FOR Redmine#36594
        ///// <summary>
        ///// �����[�g�`�[�f�[�^���s�p�T�[�r�X���擾����
        ///// </summary>
        ///// <returns>�����[�g�`�[�f�[�^���s�p�T�[�r�X</returns>
        //private SFCMN02555AServices GetSFCMN02555AServices()
        //{
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

        //    SFCMN02555AServices result = new SFCMN02555AServices(wkStr1 + wkStr2 + "SFCMN02555AA.asmx");
        //    //�^�C���A�E�g10��
        //    result.Timeout = 600000;

        //    return result;
        //}
        #endregion

        /// <summary>
        /// SCM�A���ݒ���T�[�r�X���擾����
        /// </summary>
        /// <returns>SCM�A���ݒ���T�[�r�X</returns>
        private SFCMN02564AServices GetSFCMN02564AServices()
        {
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

            SFCMN02564AServices result = new SFCMN02564AServices(wkStr1 + wkStr2 + "SFCMN02564AA.asmx");

            //�^�C���A�E�g10��
            result.Timeout = 600000;

            return result;
        }

        #region DEL 2013/07/28 zhubj FOR Redmine#36594
        ///// <summary>
        ///// �⍇���񓚏��擾�p�T�[�r�X���擾����
        ///// </summary>
        ///// <returns>�⍇���񓚏��</returns>
        //>>>2012/06/22
        //private SFCMN02501AServices GetSFCMN02501AServices()
        //private SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices GetSFCMN02501AServices()
        ////<<<2012/06/22
        //{
        //    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
        //    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

        //    //>>>2012/06/22
        //    //SFCMN02501AServices result = new SFCMN02501AServices(wkStr1 + wkStr2 + "SFCMN02501AA.asmx");
        //    SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices result = new SFCMN02501alias.Broadleaf.Web.Services.SFCMN02501AServices(wkStr1 + wkStr2 + "SFCMN02501AA.asmx");
        //    //<<<2012/06/22

        //    //�^�C���A�E�g10��
        //    result.Timeout = 600000;

        //    return result;
        //}
        #endregion

        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------>>>>>
        /// <summary>
        /// �I�y���[�V�������O�������݂܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        public void WriteOperationLog(string className, string methodName, string msg)
        {
            SimpleLogger.Write(className, methodName, msg);

            OperationHistoryLog log = new OperationHistoryLog();
            log.WriteOperationLog(this, DateTime.Now, LogDataKind.SystemLog, "PMKHN02102A", "�����[�g�`�[���s�A�N�Z�X�N���X", string.Empty, 0, 0, msg, string.Empty);
            log = null;
        }

        /// <summary>
        /// �G���[�������Ƀ��b�Z�[�W�_�C�A���O��\�����܂�
        /// </summary>
        public void errMessageBoxShow(string dspMsg)
        {
            try
            {
                // �����񓚖��m�F�̏ꍇ��SCM�󒍃f�[�^���擾
                if (_CMTCooprtDiv < 0)
                {
                    bool msgDiv;
                    string errMsg;
                    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

                    ScmOdReadParamWork scmOdReadParamWork = new ScmOdReadParamWork();

                    ScmOdrDataWork[] scmOdrDataWorkArray = null;
                    ScmOdDtInqWork[] scmOdDtInqWorkArray = null;
                    ScmOdDtAnsWork[] scmOdDtAnsWorkArray = null;
                    ScmOdDtCarWork[] scmOdDtCarWorkArray = null;

                    scmOdReadParamWork.InqOriginalEpCd = _scmRtPrtDtInfo.InqOriginalEpCd.Trim();   //�⍇������ƃR�[�h//@@@@20230303
                    scmOdReadParamWork.InqOriginalSecCd = _scmRtPrtDtInfo.InqOriginalSecCd; //�⍇�������_�R�[�h
                    scmOdReadParamWork.InqOtherEpCd = _scmRtPrtDtInfo.InqOtherEpCd;         //�⍇�����ƃR�[�h
                    scmOdReadParamWork.InqOtherSecCd = _scmRtPrtDtInfo.InqOtherSecCd;       //�⍇���拒�_�R�[�h
                    scmOdReadParamWork.InquiryNumber = _scmRtPrtDtInfo.InquiryNumber;       //�⍇���ԍ�
                    scmOdReadParamWork.InqOrdAnsDivCd = 2;                                  //�┭�E�񓚎��(1:�⍇���E���� 2:��)
                    scmOdReadParamWork.LatestDiscCode = 0;                                  //�ŐV���ʋ敪(0:�ŐV�f�[�^ 1:���f�[�^)
                    //�⍇���񓚏����擾����
                    status = _iScmOdrDataDB.ReadWithCar(ctAuthenticateCode_SFCMN02501A, scmOdReadParamWork, out scmOdrDataWorkArray, out scmOdDtInqWorkArray, out scmOdDtAnsWorkArray, out scmOdDtCarWorkArray, out msgDiv, out errMsg);
                    if (status == 0)
                    {
                        if (null != scmOdrDataWorkArray && scmOdrDataWorkArray.Length > 0)
                        {
                            //CMT�A�g�敪
                            _CMTCooprtDiv = scmOdrDataWorkArray[0].CMTCooprtDiv;
                        }
                    }
                }
                if ((_CMTCooprtDiv < 0) || ((_CMTCooprtDiv != ctCMTCooprtDiv_AutoInq) && (_CMTCooprtDiv != ctCMTCooprtDiv_AutoOrder)))
                {
                    // �����񓚈ȊO�̏ꍇ�̓G���[���b�Z�[�W��\������
                    MessageBox.Show(dspMsg, "�����[�g�`�[���s����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                this.WriteOperationLog("PMKHN02102A", "autoAnsCheck", "SCM�󒍃f�[�^�擾�G���[�F��O�y" + ex.Message + "�z");
            }
        }
        // --- ADD 2015/11/20 T.Miyamoto �����`��Q�Ή� ------------------------------<<<<<
        #endregion
    }
}
