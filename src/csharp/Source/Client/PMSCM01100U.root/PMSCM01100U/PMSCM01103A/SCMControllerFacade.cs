//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : NS�ҋ@�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/10/17  �C�����e : SCM��Q�Ή� SCM�A�g�����M�f�[�^�擾�������C�� ��10414
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/12/05  �C�����e : 2012/12/99�z�M SCM��Q��10442�Ή� ���M�{�^���\������A�P�̋N�������O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/08/28  �C�����e : �^�u���b�g����̔���o�^���A"���M��"�E�B���h�E���\���ɂ���
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.IO;
// ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
using System.Collections;
using System.Collections.Generic;
// ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �񓚑��M�����̑����N���X
    /// </summary>
    public static class SCMControllerFacade
    {
        private const string MY_NAME = "SCMControllerFacade";   // ���O�p

        /// <summary>PM.NS�̃p�����[�^�L�[���[�h</summary>
        private const string PMNS_PARAMETER_KEYWORD = "/A";
        /// <summary>PM7�̃p�����[�^�L�[���[�h</summary>
        private const string PM7_PARAMETER_KEYWORD = "/B";
        // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�T�|�[�g���j���[����N���̃p�����[�^�L�[���[�h</summary>
        private const string SYS_PARAMETER_KEYWORD = "/C";
        // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �񓚑��M�����R���g���[���𐶐����܂��B
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        /// <returns>
        /// �N���p�����[�^�F�����c�P�̋N�����[�h(�N���FPM.NS)��<c>PMNSNormalController</c><br/>
        /// �N���p�����[�^�F"/A"�c���M�N�����[�h(�N���FPM.NS)��<c>PMNSBatchController</c><br/>
        /// �N���p�����[�^�F"/B"�c�P�̋N�����[�h(�N���FPM7)��<c>PM7NormalController</c><br/>
        /// �N���p�����[�^�F"/B �`�[�ԍ� �`�[��� �T�[�o�[�ԍ�"�c���M�N�����[�h(�N���FPM7)��<c>PM7BatchController</c>
        /// </returns>
        public static SCMSendController CreateSCMController(string[] commandLineArgs)
        {
            foreach (string arg in commandLineArgs) Debug.WriteLine(arg);

            // PM7�̏ꍇ�̋N���p�����[�^�m�F
            // �N���p�����[�^�F����
            if (commandLineArgs == null || commandLineArgs.Length.Equals(0))
            {
                return new PMNSNormalController();  // �P�̋N�����[�h(�N���FPM.NS)
            }

            // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // �N���p�����[�^�F"/C"
            if (commandLineArgs[0].Equals(SYS_PARAMETER_KEYWORD))
            {
                PMNSNormalController PMNSNormalControllerSys = new PMNSNormalController();
                PMNSNormalControllerSys.SendDisplay = true;
                return PMNSNormalControllerSys;
            }
            // --- ADD 2012/12/05 �O�� 2012/12/99�z�M�� SCM��Q��10442 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // �N���p�����[�^�F"/A"
            if (commandLineArgs[0].Equals(PMNS_PARAMETER_KEYWORD))
            {
                //>>>2010/04/08
                //// 2010/03/15 Add >>>
                ////return new PMNSBatchController();   // ���M�N�����[�h(�N���FPM.NS)
                //int acptAnOdrStatus = 0;
                //string salesSlipNum = string.Empty;
                //if (commandLineArgs.Length > 1)
                //{
                //    string[] prm = ( commandLineArgs[1] ).Split(':');
                //    if (prm.Length > 1)
                //    {
                //        acptAnOdrStatus = TStrConv.StrToIntDef(prm[0].Trim(), 0);
                //        salesSlipNum = prm[1];
                //    }
                //}
                //PMNSBatchController ctlr = new PMNSBatchController();
                //ctlr.AcptAnOdrStatus = acptAnOdrStatus;
                //ctlr.SalesSlipNum = salesSlipNum;

                //return ctlr;   // ���M�N�����[�h(�N���FPM.NS)
                //// 2010/03/15 Add <<<

                Int64 inquiryNumber = 0;
                int inqOrdDivCd = 0;
                // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
                List<string> salesSlipNumList = new List<string>();
                // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<
                if (commandLineArgs.Length > 1)
                {
                    string[] prm = (commandLineArgs[1]).Split(':');
                    if (prm.Length > 1)
                    {
                        Int64 outPrm0;
                        Int64.TryParse(prm[0].Trim(), out outPrm0);
                        inquiryNumber = outPrm0;
                        inqOrdDivCd = TStrConv.StrToIntDef(prm[1].Trim(), 0);
                        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
                        if (prm.Length == 3)
                        {
                            if (prm[2].Trim().Length != 0)
                            {
                                string[] numList = (prm[2].Trim()).Split(',');
                                if (numList.Length != 0)
                                {
                                    for (int i = 0; i < numList.Length; i++)
                                    {
                                        if (numList[i] != null && numList[i].Trim().Length != 0)
                                        {
                                            salesSlipNumList.Add(numList[i].Trim());
                                        }
                                    }
                                }
                            }
                        }
                        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<
                    }
                }
                PMNSBatchController ctlr = new PMNSBatchController();
                ctlr.InquiryNumber = inquiryNumber;
                ctlr.InqOrdDivCd = inqOrdDivCd;
                // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
                ctlr.SalesSlipNumList = salesSlipNumList;
                // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<
                // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ---------->>>>>>>>>>
                // �^�u���b�g����̋N���̏ꍇ�̂݃Z�b�g����
                if (commandLineArgs.Length > 2 && commandLineArgs[2] == SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET)
                {
                    ctlr.CmdLineTablet = SCMSendController.CMD_LINE_FOR_PMSCM01100_TABLET;
                }
                // ADD 2013/08/28 �g�� �^�u���b�g ���M���E�B���h�E��\�� ----------<<<<<<<<<<
                return ctlr;   // ���M�N�����[�h(�N���FPM.NS)
                //<<<2010/04/08
            }

            // �N���p�����[�^�F"/B"
            if (commandLineArgs.Length.Equals(1) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            {
                return new PM7NormalController();
            }

            // DEL 2010/06/22 NS�ҋ@�����Ή� ---------->>>>>
            //// �N���p�����[�^�F"/B ���Ӑ�R�[�h �`�[�ԍ� �`�[��� �T�[�o�[�ԍ�"
            //if (commandLineArgs.Length.Equals(5) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            //{
            //    return new PM7BatchController(commandLineArgs);
            //}
            // DEL 2010/06/22 NS�ҋ@�����Ή� ----------<<<<<
            // ADD 2010/06/22 NS�ҋ@�����Ή� ---------->>>>>
            // �N���p�����[�^�F"/B ���M�f�[�^�p�X�i�ʏ�� SCM�S�̐ݒ�}�X�^.���V�X�e���A�g�t�H���_ + \Send�j"
            if (commandLineArgs.Length.Equals(2) && commandLineArgs[0].Equals(PM7_PARAMETER_KEYWORD))
            {
                return new PM7BatchController(commandLineArgs[1]);
            }
            // ADD 2010/06/22 NS�ҋ@�����Ή� ----------<<<<<

            // ����ȊO��PMNS�P�̋N��
            return new PMNSNormalController();
        }

        #region <PM7�p>

        /// <summary>
        /// PM7�p�̃R�}���h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        /// <returns>
        /// <c>true</c> :PM7�p�̃R�}���h�ł��B<br/>
        /// <c>false</c>:PM7�p�̃R�}���h�ł͂���܂���B
        /// </returns>
        private static bool IsPM7Mode(string[] commandLineArgs)
        {
            return Array.Exists(commandLineArgs, delegate(string commandLineArg)
            {
                return commandLineArg.Equals(PM7_PARAMETER_KEYWORD);
            });
        }

        /// <summary>
        /// PM7�p���M�N�����[�h�̃R�}���h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        /// <returns>
        /// <c>true</c> :PM7�p���M�N�����[�h�̃R�}���h�ł��B<br/>
        /// <c>false</c>:PM7�p���M�N�����[�h�̃R�}���h�ł͂���܂���B
        /// </returns>
        public static bool IsPM7BatchMode(string[] commandLineArgs)
        {
            if (IsPM7Mode(commandLineArgs))
            {
                int index = Array.IndexOf(commandLineArgs, PM7_PARAMETER_KEYWORD) + 1;
                if (commandLineArgs.Length > index)
                {
                    string parameter = commandLineArgs[index];
                    return Directory.Exists(parameter);
                }
            }
            return false;
        }

        /// <summary>
        /// PM7�p���M�N�����[�h��SCM Web�T�[�o�֑��M���܂��B
        /// </summary>
        /// <param name="answerDataPath">�񓚃f�[�^�̕ۑ��p�X</param>
        /// <remarks>
        /// �񓚑��M�p���O�t�@�C���̃I�[�v���ɂ��A�P�̋N�����[�h�����M���ł��邩���肵�Ă��܂��B
        /// ���M���ł���ꍇ�A�����𒆒f���܂��B
        /// </remarks>
        /// <returns>���ʃR�[�h</returns>
        public static int SendToWebServerByPM7BatchMode(string answerDataPath)
        {
            const string METHOD_NAME = "SendToWebServerByPM7BatchMode()";   // ���O�p

            #region <Log>

            string start = "PM7���M�N�����[�h�ŉ񓚑��M�������s���܂��B";
            SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetStartMsg(start));
            #endregion // </Log>

            SCMSendController sender = new PM7BatchController(answerDataPath);
            {
                try
                {
                    // TODO:�S�~�|���c���O�t�@�C���͑��݂��Ȃ���΍쐬����̂Ń{�c
                    #region <�{�c>
                    //// ���O�t�@�C�����`�F�b�N
                    //if (!File.Exists(sender.LogFilePath))
                    //{
                    //    #region <Log>

                    //    string msg = string.Format("���O�t�@�C�������݂��܂���ł����B(�t�@�C���p�X@{0})", sender.LogFilePath);
                    //    SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetErrorMsg(msg, (int)ResultUtil.ResultCode.Error));

                    //    #endregion // </Log>

                    //    return (int)ResultUtil.ResultCode.Error;
                    //}
                    #endregion // </�{�c>

                    // ���O�t�@�C�����I�[�v��
                    int status = sender.OpenLog();
                    if (!status.Equals((int)ResultUtil.ResultCode.Normal))
                    {
                        #region <Log>

                        string abort = "�P�̋N�����[�h�ő��M�����ɂ��A���O�t�@�C�����I�[�v���ł��܂���ł����̂ŁA�񓚑��M�����𒆒f���܂����B";
                        SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetInfoMsg(abort));

                        #endregion // </Log>

                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // ���Ӑ�����`�F�b�N
                    string customerDataFile = Path.Combine(answerDataPath, PM7IOAgent.CUSTOMER_LIST_FILE_NAME);
                    if (!File.Exists(customerDataFile))
                    {
                        string msg = string.Format(
                            "���Ӑ�f�[�^�t�@�C�������݂��Ȃ��̂ŁA�����𒆒f���܂����G{0}",
                            customerDataFile
                        );
                        sender.WriteLog(Environment.NewLine + msg + Environment.NewLine);
                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // SCM Web�T�[�o�֑��M
                    status = sender.Send();
                    Debug.WriteLine("��������=" + status.ToString());

                    #region <Log>

                    string end = "PM7���M�N�����[�h�ŉ񓚑��M�������s���܂����B";
                    SimpleLogger.Write(MY_NAME, METHOD_NAME, MsgHelper.GetEndMsg(end, status));

                    #endregion // </Log>

                    return status;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());

                    #region <Log>

                    string err = "PM7���M�N�����[�h�ŉ񓚑��M�������ɗ�O���������܂����B";
                    MsgHelper.WriteExceptionLog(MY_NAME, METHOD_NAME, err, ex);

                    #endregion // </Log>

                    return (int)ResultUtil.ResultCode.Error;
                }
                finally
                {
                    // ���O�t�@�C�����N���[�Y
                    if (sender != null) sender.CloseLog();
                }
            }
        }

        #endregion // </PM7�p>
    }
}
