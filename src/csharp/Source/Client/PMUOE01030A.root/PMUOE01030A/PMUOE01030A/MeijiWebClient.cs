//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Web�T�[�o�Ƒ���M���鏈���N���X
// �v���O�����T�v   : Web�T�[�o�Ƒ���M���鏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �x�c ����
// �� �� ��  2012/12/06  �C�����e : �����Y��WEB�@�A�h���X�ύX�Ή�
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@WebReferences�Q�Ɛ��ύX
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�A�@�ɔ����Q�ƃt�H���_�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c������
// �� �� ��  2023/01/27  �C�����e : TLS1.2�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.IO;
// 2012/12/06 ��>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//using Broadleaf.Application.Controller.jp.mesaco.catalog;
using Broadleaf.Application.Controller.jp.mesaco.meijiweb;
// 2012/12/06 ��>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Xml;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
// ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------>>>>>
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
// ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����M�f�[�^��ϊ����AWeb�T�[�o�Ƒ���M����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: Web�T�[�o�Ƒ���M���鏈���N���X</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public class MeijiWebClient : IUOEWebClient
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private System.Data.DataSet dsRequest;
        private System.Data.DataSet dsResponse;
        private NewDataSet1.InfomationReqTableDataTable _informationReqTableDataTable;
        private NewDataSet1.PartsmanRequestTblDataTable _netSendDataTable;
        private System.Data.DataTable tableinfo;
        private System.Data.DataTable tableresp;
        private UOESupplier _uoeSupplier;
        // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------>>>>>
        // �ؖ������؎��̃G���[���e(���O�o�͍͂s��Ȃ�)
        private string strSslPolErrMsg = string.Empty;
        // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------<<<<<
        # endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members
        private const int DENBKB_35 = 35;
        private const int DENBKB_45 = 45;
        private const string ERROR_CODE_0 = "0";
        private const string ERROR_CODE_1 = "1";
        private const string ERROR_CODE_2 = "2";
        private const string ERROR_CODE_3 = "3";
        private const string REQUEST_ID = "BBB101";
        private const int DENBKB_60 = 60;
        private const string KUBUN_STOCK = "3";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// Web�T�[�o�Ƒ���M���鏈���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : Web�T�[�o�Ƒ���M���鏈���N���X�̏��������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        public MeijiWebClient(UOESupplier uoeSupplier)
        {
            this.dsRequest = new NewDataSet1();
            this.dsResponse = new NewDataSet2();
            this._informationReqTableDataTable = ((NewDataSet1)this.dsRequest).InfomationReqTable;
            this._netSendDataTable = ((NewDataSet1)this.dsRequest).PartsmanRequestTbl;
            this._uoeSupplier = uoeSupplier;
        }
        # endregion

        #region IUOEWebClient �����o

        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <param name="errorMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : Web�T�[�o�Ƒ���M���鏈�����s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        public int SendAndReceive(UoeSndHed uoeSendingData, bool isReceivingStock, out UoeRecHed uoeReceivedData, out string errorMessage)
        {
            uoeReceivedData = new UoeRecHed();
            errorMessage = string.Empty;

            // ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����
            ConvertUoeSndHedToDataSet(uoeSendingData, isReceivingStock);
            // Web�T�[�r�X���ďo��
            int status = WebServiceCall();

            //string errorCode = ((NewDataSet2.InfomationResTableRow)this._informationResTableDataTable.Rows[0]).ErrorCode;

            this.tableinfo = this.dsResponse.Tables["InfomationResTable"];
            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl"];
            string errorCode = string.Empty;

            if (this.tableinfo.Rows.Count != 0)
            {
                errorCode = (string)tableinfo.Rows[0]["ErrorCode"];
                switch (errorCode)
                {
                    case ERROR_CODE_0: { errorMessage = "����"; break; }
                    case ERROR_CODE_1: { errorMessage = "I/F�G���["; break; }
                    case ERROR_CODE_2: { errorMessage = "��G���["; break; }
                }
            }
            else
            {
                errorCode = ERROR_CODE_3;
                errorMessage = "�^�C���A�E�g�G���[";
            }

            if (errorCode == ERROR_CODE_0)
            {
                // Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ����� 
                ConvertDataSetToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, out uoeReceivedData);
            }

            return status;
        }

        /// <summary>
        /// ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void ConvertUoeSndHedToDataSet(UoeSndHed uoeSendingData, bool isReceivingStock)
        {
            // �C���t�H���[�V�����˗����̐ݒ�
            SetInformationReqTableDataTable(this._uoeSupplier);
            // �v�����̐ݒ�
            SetNetsendDataTable(uoeSendingData, isReceivingStock);

        }

        /// <summary>
        /// Web�T�[�r�X���ďo��
        /// </summary>
        /// <remarks>
        /// <br>Note       : Web�T�[�r�X���ďo��</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Note       : TLS1.2�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/01/27</br>
        /// </remarks>
        private int WebServiceCall()
        {
            MeijiWebApp meijiWebApp = new MeijiWebApp();
            try
            {
                // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------>>>>>
                // Partsman Product�萔��`�N���X(PMCMN00500C.dll)����Z�L�����e�B�v���g�R�����擾����B
                ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;

                // �ؖ����̌��؊m�F�ǉ�
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
                    Object certsender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    //���؂͍s�������O�o�͂͂��Ȃ��i�ؖ����̃G���[�̓u���E�U��Ŕ��f�ł��邽�߁j
                    return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
                });
                // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------<<<<<
                this.dsResponse = meijiWebApp.GetRequestData(this.dsRequest);
            }
            catch (Exception ex)
            {
                return (int)EnumUoeConst.Status.ct_ERROR;
            }
            return (int)EnumUoeConst.Status.ct_NORMAL;
        }

        // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------>>>>>
        /// <summary>
        /// �ؖ����̌��؊m�F�ǉ�
        /// </summary>
        /// <param name="certsender">certsender</param>
        /// <param name="certificate">certificate</param>
        /// <param name="chain">chain</param>
        /// <param name="sslPolicyErrors">sslPolicyErrors</param>
        /// <param name="strSslPolErrMsg">strSslPolErrMsg</param>
        /// <remarks>
        /// <br>Note        : �ؖ����̌��؊m�F���s���܂��B</br>
        /// <br>Programmer  : �c������</br>
        /// <br>Date        : 2023/01/27</br>
        /// </remarks>
        private bool AddServerCertificateValidation(Object certsender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors, out string strSslPolErrMsg)
        {
            strSslPolErrMsg = string.Empty;
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                strSslPolErrMsg = "�T�[�o�[�ؖ����̌��؂ɐ������܂����B";
                return true;
            }
            else
            {
                strSslPolErrMsg = "�T�[�o�[�ؖ����̌��؂Ɏ��s���܂����B";

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) ==
                    SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    strSslPolErrMsg += "ChainStatus���A��łȂ��z���Ԃ��܂����B";
                    strSslPolErrMsg += "[";
                    foreach (X509ChainStatus C509CS in chain.ChainStatus)
                    {
                        strSslPolErrMsg += string.Format("{0}:{1} ", C509CS.Status, C509CS.StatusInformation);
                    }
                    strSslPolErrMsg += "]";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) ==
                    SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    strSslPolErrMsg += "�ؖ��������s��v�ł��B";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) ==
                    SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    strSslPolErrMsg += "�ؖ��������p�ł��܂���B";
                }
                return false;
            }
        }
        // ------ADD 2023/01/27 �c������ TLS1.2�Ή� ------<<<<<

        /// <summary>
        /// Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="isReceivingStock"></param>
        /// <param name="errorCode"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Web�T�[�r�X����̖߂�l����M�d���f�[�^�ɕϊ�����</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void ConvertDataSetToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, string errorCode, out UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();

            UoeRecDtl uoeRecDtl;
            byte[] toByteArray;
            for (int index = 0; index < this.tableresp.Rows.Count; index++)
            {
                System.Data.DataRow netrecvRow = tableresp.Rows[index];
                uoeRecDtl = new UoeRecDtl();

                //�����d����M�̏ꍇ
                if (isReceivingStock)
                {
                    //�ŏ��ɋ󖾍ׂ̍쐬�u�J�ǂƋU��v�@
                    if (index == 0)
                    {
                        toByteArray = new byte[256];

                        uoeRecDtl.RecTelegram = toByteArray;
                        uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                        uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
                        uoeRecDtl = new UoeRecDtl();

                    }

                    //�d���敪���u69�v�́A�Y���f�[�^�����ɂ���B
                    if ((int)tableresp.Rows[index]["DENBKB"] == 69)
                    {
                        //�Y���f�[�^�Ȃ��́A[UOESalesOrderNo]�֒l���Z�b�g���Ȃ�
                        uoeRecDtl.RecTelegram = ToByteArray(netrecvRow);
                        uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                        uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
                        break;
                    }
                    else
                    {
                        //�Y���f�[�^�̏ꍇ�́A[UOESalesOrderNo]�֒l���Z�b�g
                        //�Ώۖ��ׂ�Send���̒l���Z�b�g
                        uoeRecDtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                        uoeRecDtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    }
                }
                else
                {
                    //�����d����M�ł͂Ȃ��ꍇ
                    //�Y���f�[�^�̏ꍇ�́A[UOESalesOrderNo]�֒l���Z�b�g
                    uoeRecDtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);
                    uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                    uoeRecDtl.UOESalesOrderRowNo.Add((int)tableresp.Rows[index]["REQGYO"]);
                }

                //if ((int)netrecvRow["DENBKB"] == 69)
                //{
                //    uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();
                //    break;
                //}

                //UoeRecDtl uoeRecDtl = new UoeRecDtl();
                ////�����ԍ�
                //uoeRecDtl.UOESalesOrderNo = (int)netrecvRow["REQNO"];
                ////�����s�ԍ�
                //uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                //uoeRecDtl.UOESalesOrderRowNo.Add((int)netrecvRow["EQGYO"]);

                //���M�t���O
                if (errorCode == ERROR_CODE_0)
                {
                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                }
                else
                {
                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                }
                //�����t���O
                if (uoeRecDtl.DataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_OK)
                {
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//�����Ȃ�
                }
                else
                {
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;	//��������
                }
                //��M�d��
                uoeRecDtl.RecTelegram = ToByteArray(netrecvRow);
                uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);

            }

            //�����d����M�̏ꍇ(�_�~�[���ׂ̍쐬�u�Ǖ����U��v)
            if (isReceivingStock)
            {
                uoeRecDtl = new UoeRecDtl();
                toByteArray = new byte[256];

                uoeRecDtl.RecTelegram = toByteArray;
                uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
            }

        }

        /// <summary>
        /// �C���t�H���[�V�����˗����̐ݒ�
        /// </summary>
        /// <param name="uoeSupplier">�t�n�d������}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �C���t�H���[�V�����˗����̐ݒ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void SetInformationReqTableDataTable(UOESupplier uoeSupplier)
        {
            NewDataSet1.InfomationReqTableRow informationReqRow = this._informationReqTableDataTable.NewInfomationReqTableRow();

            informationReqRow.RequestID = REQUEST_ID;
            informationReqRow.EigyousyoFlag = uoeSupplier.InqOrdDivCd.ToString();
            informationReqRow.JigyousyoCode = uoeSupplier.UOELoginUrl;
            informationReqRow.CoCode = uoeSupplier.UOEForcedTermUrl;
            informationReqRow.TerminalID = uoeSupplier.EPartsUserId;
            informationReqRow.Password = uoeSupplier.EPartsPassWord;
            informationReqRow.EigyousyoCode = uoeSupplier.UOEItemCd;
            informationReqRow.ESystemUseType = uoeSupplier.UOETestMode;

            this._informationReqTableDataTable.AddInfomationReqTableRow(informationReqRow);
        }

        /// <summary>
        /// �v�����̐ݒ�
        /// </summary>
        /// <param name="uoeSendingData">�t�n�d��M�w�b�_�[�N���X</param>
        /// <remarks>
        /// <br>Note       : �v�����̐ݒ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void SetNetsendDataTable(UoeSndHed uoeSendingData, bool isReceivingStock)
        {
            int j = 1;
            //int k = 1;
            // �J�Ǔd���̔����敪
            string kubun = null;
            //foreach(UoeSndDtl uoeSndDtl in uoeSendingData.UoeSndDtlList) {
            for (int index = 0; index < uoeSendingData.UoeSndDtlList.Count; index++)
            {

                UoeSndDtl uoeSndDtl = uoeSendingData.UoeSndDtlList[index];

                if (index == 0)
                {
                    byte[] kaiTelegram = uoeSndDtl.SndTelegram;
                    UoeCommonFnc.MemCopy(ref kubun, ref kaiTelegram, 36, 1);
                }

                // �d����M�����ł���
                if (isReceivingStock && index != 0) 
                {
                    byte[] sndTelegram = uoeSndDtl.SndTelegram;

                    NewDataSet1.PartsmanRequestTblRow netsendRow = this._netSendDataTable.NewPartsmanRequestTblRow();
                    // �d���敪���d���敪
                    // �d���敪�Ɂg�U�O�h���Œ�ŃZ�b�g���A���̍��ڂ͉����Z�b�g�v���܂���
                    netsendRow.DENBKB = DENBKB_60;
                    netsendRow.GYONO = 0;  // �s�ԍ�
                    netsendRow.REQNO = 0;  // �d���⍇�ԍ�
                    netsendRow.REQGYO = 0; // �`�[�p�s�ԍ�
                    netsendRow.HNSBT = 0;  // ���i���
                    netsendRow.JYUSU = 0;  // ����
                    this._netSendDataTable.AddPartsmanRequestTblRow(netsendRow);
                }

                if (index != 0 && index != uoeSendingData.UoeSndDtlList.Count - 1)
                {
                    byte[] sndTelegram = uoeSndDtl.SndTelegram;
                    string readStr = null;

                    // �d����M�����ł͂Ȃ�
                    if (!isReceivingStock)
                    {
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, 15, 1);
                        int detailCount = int.Parse(readStr);
                        for (int m = 1; m <= detailCount; m++)
                        {
                            int i = 0;
                            NewDataSet1.PartsmanRequestTblRow netsendRow = this._netSendDataTable.NewPartsmanRequestTblRow();
                            // ����
                            if (uoeSendingData.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                            {
                                netsendRow.DENBKB = DENBKB_35;
                            }
                            // �݌�
                            else
                            {
                                netsendRow.DENBKB = DENBKB_45;
                            }
                            i = i + 1;

                            //// �d���敪���d���敪
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            //netsendRow.DENBKB = int.Parse(readStr);
                            //i = i + 1;

                            // �J�Ǔd���̔����敪�������敪
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.KUBUN = kubun;
                            //// ����́i�ً}�j����
                            //if (readStr = (int)EnumUoeConst.ctSystemDivCd.ct_Input || readStr = (int)EnumUoeConst.ctSystemDivCd.ct_Search:)
                            //{
                            //    netsendRow.KUBUN = 1;
                            //// �`������
                            //} else if (readStr =(int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                            //{
                            //    netsendRow.KUBUN = 9;
                            //// �݌Ɉꊇ����
                            //} else
                            //{
                            //    netsendRow.KUBUN = 3;
                            //}
                            i = i + 1;
                            // �s�ԍ�
                            //UoeCommonFnc.MemCopy(netsendRow.DENBKB, uoeSndDtl.SndTelegram, i, 7);
                            netsendRow.GYONO = j;
                            j++;
                            i = i + 7;
                            // �d���⍇���ԍ����d���⍇���ԍ�
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 6);
                            netsendRow.REQNO = int.Parse(readStr);
                            //netsendRow.REQNO = k;
                            i = i + 6;
                            // ���M���i�����`�[�p�s�ԍ�
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            //netsendRow.REQGYO = int.Parse(readStr);
                            netsendRow.REQGYO = m;
                            i = i + 1;
                            // ���}�[�N�i���l�j�����}�[�N�i���l�j
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                            netsendRow.REMARK = readStr;
                            i = i + 10;
                            // �[�i�敪���[�i�敪
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.NHNKB = readStr;
                            i = i + 1;
                            // ���i��� 1:���Y���i��ݒ�i�Œ�j
                            netsendRow.HNSBT = 1;
                            i = i + 5 + (m - 1) * 43;
                            // ���i�ԍ��`���C�����}�[�N�i���l�jTODO
                            // �d���̕��i�ԍ������i�ԍ�
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 20);
                            netsendRow.JYUHNNO = readStr;
                            i = i + 20;
                            // �d���̃��[�J�[�R�[�h�����[�J�[�R�[�h
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 4);
                            netsendRow.MKCD = readStr;
                            i = i + 8;
                            // �d���̐��ʁ�����
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 3);
                            netsendRow.JYUSU = int.Parse(readStr);
                            i = i + 3;
                            // �d���̂a�^�n�敪���a�^�n�敪
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.BOKB = readStr;
                            i = i + 2;
                            // �d���̃`�F�b�N�R�[�h�����C�����}�[�N�i���l�j
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                            netsendRow.CHKCD = readStr;
                            i = i + 10;

                            this._netSendDataTable.AddPartsmanRequestTblRow(netsendRow);
                        }

                    }
                    //k++;
                }
            }
        }

        /// <summary>
        /// �o�C�g�^�z��ɕϊ�
        /// </summary>
        /// <returns>�o�C�g�^�z��</returns>
        /// <remarks>
        /// <br>Note       : �o�C�g�^�z��ɕϊ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Programmer : �x�c</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public byte[] ToByteArray(System.Data.DataRow netrecvRow)
        {
            byte[] toByteArray = new byte[256];
            UoeCommonFnc.MemSet(ref toByteArray, 0x20, toByteArray.Length);
            byte[] byteArr = null;

            // Web�T�[�r�X�߂�l�̓d���敪����M�d���f�[�^�̓d���敪
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["DENBKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 0);

            // Web�T�[�r�X�߂�l�̏����敪����M�d���f�[�^�̏����敪
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["KUBUN"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 1);

            // Web�T�[�r�X�߂�l�̏������ʁ���M�d���f�[�^�̏�������
            byteArr = new byte[2];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["RESULT"].ToString().PadLeft(2, '0'), 2);
            byteArr.CopyTo(toByteArray, 2);

            // Web�T�[�r�X�߂�l�̓d���⍇���ԍ�����M�d���f�[�^�̓d���⍇���ԍ�
            byteArr = new byte[6];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQNO"].ToString().PadLeft(6, '0'), 6);
            byteArr.CopyTo(toByteArray, 4);

            // Web�T�[�r�X�߂�l�̓`�[�p�s�ԍ�����M�d���f�[�^�̉񓚓d���Ή��s��
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQGYO"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 10);

            // Web�T�[�r�X�߂�l�̃��}�[�N�i���l�j����M�d���f�[�^�̃��}�[�N�i���l�j
            byteArr = new byte[10];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REMARK"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 11);

            // Web�T�[�r�X�߂�l�̔[�i�敪����M�d���f�[�^�̔[�i�敪
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["NHNKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 21);

            // Web�T�[�r�X�߂�l�̎󒍕��i�ԍ�����M�d���f�[�^�̎󒍕��i�ԍ�
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 25);

            // Web�T�[�r�X�߂�l�̏o�ו��i�ԍ�����M�d���f�[�^�̏o�ו��i�ԍ�
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 45);

            // Web�T�[�r�X�߂�l�̃��[�J�[�R�[�h����M�d���f�[�^�̃��[�J�[�R�[�h
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["MKCD"].ToString().PadLeft(4, '0'), 4);
            byteArr.CopyTo(toByteArray, 65);

            // Web�T�[�r�X�߂�l�̎�t���t����M�d���f�[�^�̕��ރR�[�h
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, TDateTime.LongDateToDateTime((Int32)netrecvRow["UKEYMD"]).ToString("yyyyMMdd").Substring(4, 4), 4);
            byteArr.CopyTo(toByteArray, 69);

            // Web�T�[�r�X�߂�l�̕i������M�d���f�[�^�̕i��
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["HINNM"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 73);

            // Web�T�[�r�X�߂�l�̒艿����M�d���f�[�^�̒艿
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SHOTIK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 93);

            // Web�T�[�r�X�߂�l�̎d�ؒP������M�d���f�[�^�̎d�ؒP��
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SKRTNK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 100);

            // Web�T�[�r�X�߂�l�̎󒍐�����M�d���f�[�^�̎󒍐�
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 107);

            // Web�T�[�r�X�߂�l�̏o�ɐ�����M�d���f�[�^�̏o�ɐ�
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 110);

            // Web�T�[�r�X�߂�l�̂a�^�n�敪����M�d���f�[�^�̂a�^�n�敪
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 113);

            // �\���R�[�h
            byteArr = new byte[1];
            string prepareCode = string.Empty;
            if ((int)netrecvRow["HNSBT"] == 9)
            {
                prepareCode = "1";
            }
            else
            {
                prepareCode = "0";
            }
            UoeCommonFnc.MemCopy(ref byteArr, prepareCode, 1);
            byteArr.CopyTo(toByteArray, 114);

            // Web�T�[�r�X�߂�l�̂a�^�n������M�d���f�[�^�̂a�^�n��
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 115);

            // Web�T�[�r�X�߂�l�̏o�ד`�[�ԍ�����M�d���f�[�^�̏o�ד`�[�ԍ�
            byteArr = new byte[6];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            if ((int)netrecvRow["SYUNO"] == 0)
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            else
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString(), 6);
            }
            byteArr.CopyTo(toByteArray, 118);

            // Web�T�[�r�X�߂�l�̂a�^�n��t�ԍ�����M�d���f�[�^�̂a�^�n��t�ԍ�
            byteArr = new byte[6];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            if ((int)netrecvRow["BOUKENO"] == 0)
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            else
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString(), 6);
            }
            byteArr.CopyTo(toByteArray, 124);

            // Web�T�[�r�X�߂�l�̃��C�����b�Z�[�W����M�d���f�[�^�̃��C���G���[
            byteArr = new byte[15];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["LINERR"].ToString(), 15);
            byteArr.CopyTo(toByteArray, 130);

            // Web�T�[�r�X�߂�l�̃��C���}�[�N�i���l�j����M�d���f�[�^�̃`�F�b�N�R�[�h
            byteArr = new byte[10];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["CHKCD"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 145);

            return toByteArray;
        }

        # endregion

    }
}