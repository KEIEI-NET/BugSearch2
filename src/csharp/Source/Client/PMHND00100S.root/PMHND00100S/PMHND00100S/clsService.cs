using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using log4net;
using HT_RELAY_SERVICE.Common;
using HT_RELAY_SERVICE.Socket;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace HT_RELAY_SERVICE
{
    class clsService
    {
#region "�萔"

    // ���K�[
    private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    /// <summary>�I�����b�Z�[�W</summary>
    private const string MESSAGE_CLOSE = "�I�����������s���Ă���낵���ł����H";

#endregion

#region "�ϐ�"

        // ************************************
        // �����o�[�ϐ�
        // ************************************
        private System.Net.Sockets.TcpListener ServerSocket;        // ���X�i�[(�ڑ��҂����M�����s�Ȃ���޼ު��)
        private System.Threading.Thread ListeningCallbackThread;    // �ڑ��҂��X���b�h
        private volatile bool SLTAlive;                             // �ڑ��҂��X���b�h�I���w���t���O

        // ����M�d�������X���b�h�Ăяo���p�I�u�W�F�N�g
        private CommunicationCallbackDelegate Caller = null;

        // ����M�d������ҿ��ޗp��عް�
        delegate ProcessingResultOfCommunication CommunicationCallbackDelegate(System.Net.Sockets.TcpListener listener);

        // �ҋ@���̃X���b�h���Ǘ�����I�u�W�F�N�g
        private static System.Threading.ManualResetEvent AllDone = new System.Threading.ManualResetEvent(false);

        // �΂o�l�m�r�p���� RemoteObject�C���^�[�t�F�[�X
        private IPmHandy _iPmHandy;

        // ��M�����i���O�o�͗p�j
        private string LogYmdTime = string.Empty;

#endregion

#region "�C�x���g"

        /// <summary>
        /// �J�n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        public void ServiceStart(object sender, EventArgs e)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "frmConsole_Load -->>");

            try
            {
                // ��M�����i���O�o�͗p�j�Z�b�g
                LogYmdTime = "�y �N�� "
                            + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            + "�z";

                // ���d�N���`�F�b�N
                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "���d�N���`�F�b�N �G���[ -->>");
                    return;
                }

                // �X���b�h�I���w���t���O�𖢏I���ɏ�����
                SLTAlive = false;

                // ����M�d�������X���b�h�p���\�b�h���X���b�h�p���\�b�h�Ƃ��ēo�^
                Caller = new CommunicationCallbackDelegate(CommunicationCallback);

                // �΃n���f�p�\�P�b�g����
                SocketSet();

                // �΂o�l�m�r�p�ʐM����
                AplSet();

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "frmConsole_Load <<--");
            }
        }

        /// <summary>
        /// �I��
        /// </summary>
        /// <remarks></remarks>
        public void ServiceStop(object sender, EventArgs e)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "toolStripMenuItem1_Click -->>");

            try
            {
                // ���ޱ��؂��I������ɂ�������炸�A�ڑ��҂��گ�ނ��I�����Ă��Ȃ��ꍇ�̏���
                if (SLTAlive)
                {
                    // �X���b�h�I���w���t���O���I���ɐݒ�
                    SLTAlive = false;

                    // �ڑ��v���󂯓���̏I��
                    ServerSocket.Stop();

                    // �O�̂��߃X���b�h��null�ݒ�
                    ListeningCallbackThread = null;
                }
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "toolStripMenuItem1_Click <<--");
            }
        }
#endregion

#region "�֐�"
        /// <summary>
        /// �΃n���f�p�\�P�b�g����
        /// </summary>
        /// <remarks></remarks>
        private void SocketSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "SocketSet -->>");
            try
            {
                if (!SLTAlive)  // �܂��ڑ��҂��گ�ނ𐶐����Ă��Ȃ��ꍇ
                {

                    // ���X�i�[(�ڑ��v���󂯓���ҋ@)�𐶐�
                    ServerSocket = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse(clsCommon.gIpAddress), clsCommon.gSocketPort);

                    // �ڑ��v���󂯓���J�n
                    ServerSocket.Start();

                    // �ڑ��҂��p�X���b�h���쐬
                    ListeningCallbackThread = new System.Threading.Thread(ListeningCallback);

                    // �ڑ��҂��p�X���b�h���J�n
                    ListeningCallbackThread.Start();

                    // �X���b�h�I���w���t���O�𖢏I���ɐݒ�
                    SLTAlive = true;
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "SocketSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "SocketSet <<--");
            }
        }

        /// <summary>
        // ����M�d�������X���b�h�p���\�b�h
        //  --- ��M���ꂽ�d���ɑ΂��āA��̓I�ȏ������s�Ȃ����\�b�h�ł��B���̃T
        //      ���v���ł́A��M�d�����e�L�X�g�{�b�N�X�ɕ\�����A�܂��A�N���C�A��
        //      �g�֕ԐM��Ԃ������Ƃ��Ă��܂��B
        //      �Ȃ��A�{���\�b�h(�d��������)�́A�����̃N���C�A���g����̐ڑ��ɑ�
        //      �����Ă��܂��B���Ȃ킿�A��M�����邽�тɃX���b�h���N�����A�{���\
        //      �b�h�����s����܂��B
        /// </summary>
        /// <param name="listener">�N���C�A���g����̎�M�ڑ��v�����������郊�X�i�[</param>
        /// <remarks>��������</remarks>
        public ProcessingResultOfCommunication CommunicationCallback(System.Net.Sockets.TcpListener listener)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "CommunicationCallback -->>");

            // AllDone���V�O�i����Ԃɂ���B
            // ���Ȃ킿�A�ڑ��҂��X���b�h�̃��b�N���������āA�ڑ��҂��X���b�h�̎��s�ĊJ�̋�������B
            AllDone.Set();

            // �������ʊi�[�p�N���X�̐���
            ProcessingResultOfCommunication ResultData = new ProcessingResultOfCommunication();

            if (SLTAlive)  // �ڑ��҂��گ�ނ��쐬����Ă��Ďg����ꍇ
            {
                try
                {
                    // �N���C�A���g����̐ڑ����󂯕t����
                    System.Net.Sockets.TcpClient ClientSocket = listener.AcceptTcpClient(); // TCP�ײ���

                    // �ʐM�X�g���[���̎擾
                    System.Net.Sockets.NetworkStream stream = ClientSocket.GetStream();

                    //============
                    // �N���C�A���g����̓d���̎�M
                    byte[] ReceiveData = new byte[2000];
                    int DataLength = stream.Read(ReceiveData, 0, ReceiveData.Length);   // �d���̗�
                    string rcvstr = System.Text.Encoding.Unicode.GetString(ReceiveData, 0, DataLength);
                    rcvstr = rcvstr.Trim();

                    // �n���f�B����̎�M�f�[�^�istring ResultData.ReceivedData�j������
                    // �A�v������������擾���āA���M�f�[�^�istring ResultData.Reply�j�ɃZ�b�g
                    byte[] reply = APLCom(ReceiveData);

                    //============
                    // �ԐM�d�����N���C�A���g�֑��M
                    //byte[] SendBuffer = System.Text.Encoding.Unicode.GetBytes(ResultData.Reply);
                    stream.Write(reply, 0, reply.Length);
                    stream.Flush(); // �t���b�V��(���������o��)

                    // �ʐM�X�g���[�����N���[�Y
                    stream.Close();

                    // TCP�ײ��Ă�۰��
                    ClientSocket.Close();
                }
                catch (Exception ex)
                {
                    clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "CommunicationCallback ERROR = " + ex.Message);
                }
            }

            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "CommunicationCallback <<--");

            return ResultData;
        }

        /// <summary>
        // �ڑ��҂��X���b�h�p���\�b�h
        //  --- �N���C�A���g����̎�M�󂯕t�����s�Ȃ����\�b�h�ł��B�Ȃ��A��M��
        //      ���t������ɍs�Ȃ����߁A�������[�v�Ŏ󂯕t���������s���Ă��܂��B
        //      �������[�v�́A�������L���āA�{�T�[�o�[�v���O�������̂̓���ɉe
        //      �����܂��̂ŁA�{���\�b�h�́A�X���b�h�Ƃ��ċN�����܂��B
        /// </summary>
        /// <remarks></remarks>
        private void ListeningCallback()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ListeningCallback -->>");

            try
            {
                // ��M�̎�t���s�Ȃ����߂̖������[�v
                while (SLTAlive)    // �گ�ޏI���w���׸ނł̏I���w��������ꍇ��ٰ�ߏI��
                {
                    // ��M�ڑ��L���[���ŁA�ڑ��҂������邩���f
                    if (ServerSocket.Pending() == true)
                    {
                        // AllDone���V�O�i����Ԃɂ���
                        // ���Ȃ킿�A�X���b�h�̎��s�w���̏�Ԃ����Z�b�g���Ė߂��B
                        AllDone.Reset();

                        // ܰ���گ�ނł̏����I�����ɋN�����麰��ޯ�ҿ��ނ��w��
                        AsyncCallback asc = new AsyncCallback(ReturnCallback);

                        // �X���b�h���N�����A����M�d�������X���b�h�p���\�b�h�����s���܂��B
                        IAsyncResult AsyRes = Caller.BeginInvoke(ServerSocket, asc, null);

                        // AllDone���V�O�i����ԂɂȂ�܂ŃX���b�h���u���b�N�B
                        // ���Ȃ킿�A����M�d�������p�X���b�h����A���s�J�n�̎w�����o��܂őҋ@����B
                        AllDone.WaitOne();
                    }

                    // �Z���Ԃ����ҋ@
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "ListeningCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ListeningCallback <<--");
            }
        }

        /// <summary>
        // �X���b�h�������N���̃R�[���o�b�N���\�b�h
        // BeginInvoke�ł̌Ăяo��(�񓯊��Ăяo��)�ŋN�����ꂽ�X���b�h�ɂ����āA
        // ���̏����������������ɁA�Ăяo�����ɌĂяo����郁�\�b�h�ł��B
        // ����āA���[�J�[�X���b�h(BeginInvoke�ŌĂяo�����X���b�h)�ł̏���
        // ���ʂɊւ��鏈�����������ɒ�`����ƕ֗��ł��B
        // ��1����: �񓯊���عްĂł̔񓯊�����̌���(���J�v�Z����������)
        /// </summary>
        /// <param name="AsyRes"></param>
        /// <remarks></remarks>
        private void ReturnCallback(IAsyncResult AsyRes)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ReturnCallback -->>");

            try
            {
                //------------------------
                // EndInvoke ���g���āA�񓯊��Ăяo���ɂ��X���b�h����A�ԋp�l���擾����B
                //  --- �X���b�h�̔񓯊��Ăяo���ł̌��ʁuAsyRes�v�̓J�v�Z��������Ă��܂��B
                //      ����āA�������ʂ����o�����߂ɁA�܂��A����AsyRes�𷬽Ă���K�v������B

                // ���ʂ����o�����߂̔񓯊����ʂ̃L���X�g�B
                System.Runtime.Remoting.Messaging.AsyncResult aResult = (System.Runtime.Remoting.Messaging.AsyncResult)AsyRes;

                // �񓯊��̌Ăяo�����s��ꂽ�f���Q�[�g�I�u�W�F�N�g���擾�B
                CommunicationCallbackDelegate dele = (CommunicationCallbackDelegate)aResult.AsyncDelegate;

                // EndInvoke()���\�b�h�ŁA�X���b�h�̊������������s�B
                // �y�у��[�J�[�X���b�h�ł̏������ʂ̎󂯎��B
                ProcessingResultOfCommunication ResultData = dele.EndInvoke(AsyRes);
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "ReturnCallback ERROR = " + ex.Message);
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "ReturnCallback <<--");
            }
        }

        /// <summary>
        /// �n���f�B����̎�M�f�[�^�����ɃA�v������������擾����
        /// �߂�l�ɃZ�b�g
        /// </summary>
        /// <param name="rcvData"></param>
        /// <remarks></remarks>
        private byte[] APLCom(byte[] rcvData)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "APLCom -->>");

            try
            {
                string msgInfo = "";
                int status = 0;
                object condObjs;
                object retObjs;

                byte[] reply = null;
                clsLoginInfo logininfo = new clsLoginInfo();
                clsSyohinInfo syohininfo = new clsSyohinInfo();

                // �\�P�b�g�����敪���擾���邽�߂Ɉ�U���O�C�����œW�J
                logininfo.RelayGetHtInArg(rcvData);
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "�\�P�b�g�����敪���擾=" + logininfo.SokSyoriKbn);

                switch (Int32.Parse(logininfo.SokSyoriKbn))
                {
                    // ���O�C�����
                    case 1:
                        logininfo.RelayGetHtInArg(rcvData);

                        // ��M�����i���O�o�͗p�j�Z�b�g
                        LogYmdTime = "�y" + logininfo.HtName.Trim() + " "
                                    + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                                    + "�z";

                        msgInfo = "APLCom�i�΃n���f�B�j ��M = " + logininfo.SokSyoriKbn + logininfo.HtName + logininfo.LoginId;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        HandyLoginInfoCondWork condObj = new HandyLoginInfoCondWork();
                        condObj.MachineName = logininfo.HtName.ToString();
                        condObj.LoginId = logininfo.LoginId.ToString();
                        condObjs = condObj;
                        retObjs = null;

                        msgInfo = "APLCom�i�΂o�l�m�r�j ���M = " + logininfo.HtName + logininfo.LoginId;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        status = 0;
                        try
                        {
                            // �΂o�l�m�r����������
                            status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);
                        }
                        catch (Exception ex)
                        {
                            LOGGER.Error(LogYmdTime + "�΂o�l�m�r �G���[ " + ex.Message);
                            status = -3;
                        }

                        logininfo.IniOutArg();
                        logininfo.RetVal = string.Empty;
                        logininfo.RetVal = status.ToString();

                        HandyLoginInfoWork LoginRetObj = new HandyLoginInfoWork();
                        if (retObjs != null)
                        {
                            LoginRetObj = (HandyLoginInfoWork)retObjs;
                        }

                        if (LoginRetObj != null)
                        {
                            msgInfo = "APLCom�i�΂o�l�m�r�j ��M = "
                                     + LoginRetObj.BelongSectionCode + LoginRetObj.BelongSectionName
                                     + LoginRetObj.EmployeeCode + LoginRetObj.Name
                                     + LoginRetObj.RetirementDate + LoginRetObj.EnterCompanyDate
                                     + LoginRetObj.AuthorityLevel1 + LoginRetObj.AuthorityLevel2
                                     + status.ToString();

                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }
                        else
                        {
                            msgInfo = "APLCom�i�΂o�l�m�r�j ��M = " + status.ToString();
                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }

                        if (Int32.Parse(logininfo.RetVal.ToString()) == 0)
                        {
                            logininfo.BaseCd = LoginRetObj.BelongSectionCode;
                            logininfo.BaseName = LoginRetObj.BelongSectionName;
                            logininfo.EmpCd = LoginRetObj.EmployeeCode;
                            logininfo.EmpName = LoginRetObj.Name;
                            logininfo.RetDate = LoginRetObj.RetirementDate.ToString();
                            logininfo.EntDate = LoginRetObj.EnterCompanyDate.ToString();
                            logininfo.AutLv1 = LoginRetObj.AuthorityLevel1.ToString();
                            logininfo.AutLv2 = LoginRetObj.AuthorityLevel2.ToString();
                        }
                        
                        reply = logininfo.RelayGetOutArg();

                        break;

#region "�֐� APLCom�i���i���j"
                    // ���i���
                    case 2:
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "1");
                        syohininfo.RelayGetHtInArg(rcvData);
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, "2");

                        // ��M�����i���O�o�͗p�j�Z�b�g
                        LogYmdTime = "�y" + syohininfo.HtName.Trim() + " "
                                    + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                                    + "�z";

                        msgInfo = "APLCom�i�΃n���f�B�j ��M = " + syohininfo.SokSyoriKbn + syohininfo.HtName + syohininfo.SokoCd + syohininfo.TokShouCd;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        HandyLoginInfoCondWork SyohinCondObj = new HandyLoginInfoCondWork();    //TODO
                        SyohinCondObj.MachineName = syohininfo.HtName.ToString();               //TODO
                        SyohinCondObj.LoginId = syohininfo.SokoCd.ToString();                   //TODO
                        SyohinCondObj.LoginId = syohininfo.TokShouCd.ToString();                //TODO
                        condObjs = SyohinCondObj;
                        retObjs = null;

                        msgInfo = "APLCom�i�΂o�l�m�r�j ���M = " + syohininfo.HtName + syohininfo.SokoCd + syohininfo.TokShouCd;
                        clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                        status = 0;
                        try
                        {
                            // �΂o�l�m�r����������
                            status = _iPmHandy.SearchHandyLoginInfo(ref condObjs, out retObjs);     //TODO
                        }
                        catch (Exception ex)
                        {
                            LOGGER.Error(LogYmdTime + "�΂o�l�m�r �G���[ " + ex.Message);
                            status = -3;
                        }

                        syohininfo.IniOutArg();
                        syohininfo.RetVal = string.Empty;
                        syohininfo.RetVal = status.ToString();

                        HandyLoginInfoWork SyohinRetObj = new HandyLoginInfoWork();       //TODO
                        if (retObjs != null)
                        {
                            SyohinRetObj = (HandyLoginInfoWork)retObjs;                   //TODO
                        }

                        if (SyohinRetObj != null)
                        {
                            msgInfo = "APLCom�i�΂o�l�m�r�j ��M = "
                                     + SyohinRetObj.BelongSectionCode + SyohinRetObj.BelongSectionName      //TODO
                                     + SyohinRetObj.EmployeeCode + SyohinRetObj.Name                        //TODO
                                     + SyohinRetObj.RetirementDate + SyohinRetObj.EnterCompanyDate          //TODO
                                     + SyohinRetObj.AuthorityLevel1 + SyohinRetObj.AuthorityLevel2          //TODO
                                     + status.ToString();

                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }
                        else
                        {
                            msgInfo = "APLCom�i�΂o�l�m�r�j ��M = " + status.ToString();
                            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);
                        }

                        if (Int32.Parse(syohininfo.RetVal.ToString()) == 0)
                        {
                            syohininfo.MakerCd = SyohinRetObj.BelongSectionCode;                      //TODO
                            syohininfo.MakerNm = SyohinRetObj.BelongSectionName;                      //TODO
                            syohininfo.SyoCd = SyohinRetObj.EmployeeCode;                             //TODO
                            syohininfo.TanaNo = SyohinRetObj.Name;                                    //TODO
                            syohininfo.RtSokoCd = SyohinRetObj.RetirementDate.ToString();             //TODO
                            syohininfo.SokoNm = SyohinRetObj.EnterCompanyDate.ToString();             //TODO
                            syohininfo.ZaikoNum = SyohinRetObj.AuthorityLevel1.ToString();            //TODO
                            syohininfo.LastUri = SyohinRetObj.AuthorityLevel2.ToString();             //TODO
                            syohininfo.LastSir = SyohinRetObj.AuthorityLevel2.ToString();             //TODO
                            syohininfo.BefTokShouCd = SyohinRetObj.AuthorityLevel2.ToString();        //TODO
                            syohininfo.NetTokShouCd = SyohinRetObj.AuthorityLevel2.ToString();        //TODO
                        }

                        reply = syohininfo.RelayGetOutArg();

                        break;
#endregion

#region "�֐� APLCom�i�`�[���j"

                    // �`�[���
                    case 3:
                        break;
#endregion


                }
                msgInfo = "APLCom�i�΃n���f�B�j ���M = "
                         + logininfo.BaseCd.ToString() + logininfo.BaseName.ToString()
                         + logininfo.EmpCd.ToString() + logininfo.EmpName.ToString()
                         + logininfo.RetDate.ToString() + logininfo.EntDate.ToString()
                         + logininfo.AutLv1.ToString() + logininfo.AutLv2.ToString()
                         + logininfo.RetVal.ToString();

                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.INFO, LogYmdTime + msgInfo);

                //return reply;
                return reply;
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "APLCom ERROR = " + ex.Message);
                return null;
            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "APLCom <<--");
            }
        }

        /// <summary>
        /// �΂o�l�m�r�p�ʐM����
        /// </summary>
        /// <remarks></remarks>
        private void AplSet()
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "AplSet -->>");

            try
            {
                // IPC�Z�b�g
                _iPmHandy = (IPmHandy)Activator.GetObject(typeof(IPmHandy), clsCommon.gIpcAddress);

            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "AplSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "AplSet <<--");
            }
        }

        /// <summary>
        /// �A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/08</br>
        /// </remarks>
        private object LoadAssembly(string asmname, string classname, out string errMessage)
        {
            clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "LoadAssembly -->>");

            object obj = null;
            errMessage = string.Empty;

            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.ERROR, LogYmdTime + "LoadAssembly ERROR = " + ex.Message);

                LOGGER.Error("AplSet ERROR = " + ex.Message);

            }
            finally
            {
                clsCommon.writeLog4(LOGGER, clsBtConst.enumLOG4_KBN.DEBUG, LogYmdTime + "LoadAssembly <<--");
            }
            
            return obj;
        }

#endregion
    
    }
}
