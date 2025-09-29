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
// �� �� ��  2009/07/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhouzy
// �� �� ��  2011/09/21  �C�����e : PCCUOE�Ŕ��������ꍇ�APCC�S�̐ݒ�̔���`�[���s�敪���Q�Ƃ��邱�Ƃł͂Ȃ��A
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@PCCUOE�ł́ABL�߰µ��ް�S�̐ݒ�̔���`�[����敪���Q�Ƃ���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00 �쐬�S�� : ���O
// �� �� ��  2022/05/26  �C�����e : PMKOBETSU-4208 �d�q����Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller.Other
{
    using EstimateDefSetServer  = SingletonInstance<EstimateDefSetAgent>;   // ���Ϗ����l�ݒ�}�X�^
    using SalesTtlStServer      = SingletonInstance<SalesTtlStAgent>;       // ����S�̐ݒ�}�X�^
    using AcptAnOdrTtlStServer  = SingletonInstance<AcptAnOdrTtlStAgent>;   // �󔭒��Ǘ��S�̐ݒ�}�X�^
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM�S�̐ݒ�}�X�^ 
    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>> 
    using System.IO;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Broadleaf.Application.Common;
    using Broadleaf.Drawing.Printing;
    using System.Text;
    using System.Windows.Forms;
    using Broadleaf.Library.Windows.Forms;
    using Broadleaf.Application.Resources;
    using System.Threading;
    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
    /// <summary>
    /// �`�[����N���X
    /// </summary>
    /// <remarks>
    /// �ڐA���FMAHNB01012AA.cs SalesSlipInputAcs.PrintSlip(bool) 2359�s��<br/>
    /// �{�N���X�͎����񓚏����ł̂ݎg�p����邽�߁A���`�����f�[�^��SCM�S�̐ݒ�}�X�^��p���܂��B
    /// </remarks>
    public sealed class SlipPrinter
    {
        private const string MY_NAME = "SlipPrinter";   // ���O�p

        #region �`�[������f�[�^

        /// <summary>
        /// �`�[������f�[�^�\����
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SlipPrintInfoValue 1019�s�ڂ��ڐA
        /// </remarks>
        public struct SlipPrintInfoValue
        {
            int _acptAnOdrStatus;
            string _salesSlipNum;

            /// <summary>
            /// �`�[������f�[�^�\���̃R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus"></param>
            /// <param name="salesSlipNum"></param>
            internal SlipPrintInfoValue(int acptAnOdrStatus, string salesSlipNum)
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }

            /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
            internal int AcptAnOdrStatus
            {
                get { return this._acptAnOdrStatus; }
                set { this._acptAnOdrStatus = value; }
            }

            /// <summary>�`�[�ԍ��v���p�e�B</summary>
            internal string SalesSlipNum
            {
                get { return this._salesSlipNum; }
                set { this._salesSlipNum = value; }
            }
        }

        #endregion // �`�[������f�[�^

        /// <summary>�ۑ��O�̔���`�[�ԍ�</summary>
        private const string SALES_SLIP_NUM_BEFORE_SAVE = "000000000";

        #region ��ƃR�[�h

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode;
        /// <summary>��ƃR�[�h���擾���܂��B</summary>
        private string EnterpriseCode { get { return _enterpriseCode; } }

        #endregion // ��ƃR�[�h

        #region <���_�R�[�h>

        /// <summary>���_�R�[�h</summary>
        private readonly string _sectionCode;
        /// <summary>���_�R�[�h���擾���܂��B</summary>
        private string SectionCode { get { return _sectionCode; } }

        #endregion // </���_�R�[�h>

        #region <���`�����f�[�^>

        /// <summary>
        /// ���݂�SCM�S�̐ݒ���擾���܂��B
        /// </summary>
        /// <value>�Y������ݒ肪���݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</value>
        private SCMTtlSt CurrentSCMTotalSetting
        {
            get
            {
                SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                    EnterpriseCode,
                    SectionCode
                );
                if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                return foundTotalSetting;
            }
        }

        /// <summary>
        /// ����ł��邩���f���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>
        /// <c>true</c> :����ł��܂��B<br/>
        /// <c>false</c>:����ł��܂���B
        /// </returns>
        private bool CanPrint(SalesSlipInputAcs.AcptAnOdrStatusState acptAnOdrStatus)
        {
            if (CurrentSCMTotalSetting == null) return false;

            const int CAN_PRINT = 1;    // 0:���Ȃ��^1:����

            switch (acptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:       // ����
                    return !CurrentSCMTotalSetting.EstimatePrtDiv.Equals(CAN_PRINT);    // ���Ϗ����s�敪��0/1���t

                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:          // ����
                    // zhouzy update 20110927 begin
                    //return CurrentSCMTotalSetting.SalesSlipPrtDiv.Equals(CAN_PRINT);
                    return true;
                    // zhouzy update 20110927 end
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:  // ��
                    return CurrentSCMTotalSetting.AcpOdrrSlipPrtDiv.Equals(CAN_PRINT);

                default:
                    return false;
            }
        }

        #region <�Q�l>

        ///// <summary>
        ///// ���Ϗ����l�ݒ���擾���܂��B
        ///// </summary>
        ///// <returns>���Ϗ����l�ݒ�</returns>
        //private EstimateDefSet GetEstimateDefSet()
        //{
        //    return EstimateDefSetServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new EstimateDefSet();
        //}

        ///// <summary>
        ///// ����S�̐ݒ���擾���܂��B
        ///// </summary>
        ///// <returns>����S�̐ݒ�</returns>
        //private SalesTtlSt GetSalesTtlSt()
        //{
        //    return SalesTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode);
        //}

        ///// <summary>
        ///// �󔭒��Ǘ��S�̐ݒ���擾���܂��B
        ///// </summary>
        ///// <returns>�󔭒��Ǘ��S�̐ݒ�</returns>
        //private AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        //{
        //    return AcptAnOdrTtlStServer.Singleton.Instance.Find(EnterpriseCode, SectionCode) ?? new AcptAnOdrTtlSt();
        //}

        #endregion // </�Q�l>

        #endregion // </���`�����f�[�^>

        #region ����`�[����L�[���

        /// <summary>����`�[����L�[���(key:�`�[�ԍ� value:�󒍃X�e�[�^�X,�ۑ��O�`�[�ԍ�)</summary>
        private readonly Dictionary<string, SlipPrintInfoValue> _printSalesKeyInfo;
        //----- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�------->>>>>
        private const string CT_PORTNAME = "\\{0}_{1}_{2}_{3}.pdf";
        private const string CT_LOCALPORT = ",XcvMonitor Local Port";
        private const string CT_ZERO = "\0";
        private const string CT_ADDPORT = "AddPort";
        private const string CT_DELETEPORT = "DeletePort";
        private const string METHOD_NAME_PORT1 = "PrinterPortNameChange";
        private const string METHOD_NAME_PORT2 = "PrinterPortNameRecovery";
        private const string CT_PRINTER = "Microsoft Print to PDF";
        private const string CT_DEFALUT_PORTNAME = "PORTPROMPT:";
        private const string CT_XMLEBOOKSFILEFOLDERXMLINFO = "MAKAU03000U_EBooksLinkSetting.XML";
        private const string CT_EBOOKSFOLDER = "\\eBooks\\eBooks";
        private const string CT_CUSTOMERFOLDER = "\\eBooks\\Customer";
        private const string CT_TEMPFOLDER = "\\Temp\\SCMAutoEBooks";
        private const string CT_RENAMEOLDER = "\\Rename";
        private const string CT_LOGFOLDER = "\\Log\\eBooks";
        private const string CT_LOGFILENM = "\\{0}_SCMAutoEBooks_{1}.txt";
        private const string CT_FOLDERSPLIT = "\\";
        private const string CT_STRSPLIT = "\"";
        private const string CT_EBOOKSFLPATH = "\\nN2_{0}_{1}.csv";
        private const string CT_CUSTOMERFLPATH = "\\nN7_CustomerRF_Diff_{0}.csv";
        private const string CT_DATETIMEFOMART = "yyyyMMddHHmmss";
        private const string CT_YMDFOMART = "yyyyMMdd";
        private const string CT_LOGDATETIMEFOMART = "yyyy/MM/dd HH:mm:ss";
        private const string CT_LOGCOUNT = "{0}��";
        private const string CT_OPLOGMSG = "{0}���𓯊��@Log�F{1}";
        private const string PGNAME_STR = "BLP������";
        private const string ASSID_PMSCM01010U = "PMSCM01010U";
        private const string PGID_VIRTUALPRINTER = "VirtualPrinterController.exe";
        private const string CT_NAME_SALE = "����";
        private const string CT_NAME_ESTIMATE = "����";
        private const string CT_NAME_EBOOK = "Partsman_DenchoDX_VirtualPrinterMutex";
        private const string CT_MODE_SALE = "1";
        private const int OPERATIONCODE_EBOOKS = 0;
        private const int STATUS_NORMAL= 0;
        private const int COMMAND_THREE = 3;
        private const int COMMAND_ZERO = 0;
        private const int LEVEL_TWO = 2;
        private const int LEVEL_ZERO = 0;
        private const int CBBUF_ZERO = 0;
        private const int DESIREDACCESS_ONE = 1;
        private const int CT_INT_TWO = 2;
        private const int CT_INT_ZERO = 0;
        private const int CT_MUTEX_WAIT_MAX = 360; // ���z�v�����^�o�͔r���l���ő�҂����ԁi6���j
        private const string CT_CUSTOMERCDFOMART = "00000000";
        private const string CT_SPLITSTR = "_";
        private const char CT_SPLITCHAR = '_';
        private const double RATE10 = 0.1;
        private const double RATE8 = 0.08;
        // �d���o�͐ݒ�XML�t�@�C��
        private const string XML_PDFOUTPUTSETTINGS = "MAHNB01001U_PDFOutputSettings.xml";
        private const string PRINTER_NORMAL = "Microsoft Print to PDF";
        private const string PRINTER_CUBE = "CubePDF";
        //����̓d�q����Ή��ł̓_�C�A���O�\�����g�p���Ȃ�
        private const string XML_PDFPRINTERSETTINGENABLE = "MAHNB01001U_PDFPrinterSettingEnable.xml";
        private const string MESS_PRINTERPORT_ERR = "PDF�v�����^�|�[�g�̐ݒ�Ɏ��s���܂���({0})";
        private const string MESS_PRINTERMUTEX_ERR = "PDF�v�����^�ւ̏o�͂Ɏ��s���܂����i�r���擾�G���[�j";
        // �֎~����
        private char[] badChars = new char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|', '_' };
        // �t�@�C���ۑ��_�C�A���O�\��
        private bool _fileDialogDisplay = false;
        // �|�[�g��
        private string _portName = string.Empty;
        // ����f�[�^
        private Dictionary<string, SalesSlipWork> _svSalesSlipWorkDic = new Dictionary<string, SalesSlipWork>();
        // ���㖾�׃f�[�^
        private Dictionary<string, ArrayList> _svSalesDetailWorkDic = new Dictionary<string, ArrayList>();
        // �d�q����A�g�I�v�V����
        private int _opt_PM_EBooks;
        /// <summary>
        /// �d�q����o�̓t���O
        /// </summary>
        public static int PDFPrintStatus = 0;
        /// <summary>
        /// �d�q����o�̓t���O
        /// </summary>
        public int PDFPrinterStatus_EXT
        {
            get { return PDFPrintStatus; }
        }
        /// <summary>
        /// �`�[PDF�o��
        /// </summary>
        private enum OutputMode : int
        {
            /// <summary>���Ȃ�</summary>
            PDFPrintUnable = 0,
            /// <summary>����</summary>
            PDFPrintEnable = 1,
            /// <summary>�d�q����o�͂ɏ]��</summary>
            PDFPrintCustom = 2,
        }
        /// <summary>
        /// ���Ӑ�d�q����o��
        /// </summary>
        private enum DmOutCode : int
        {
            /// <summary>����</summary>
            YES = 0,
            /// <summary>���Ȃ�</summary>
            NO = 1,
        }
        /// <summary>
        /// �d�q����o��
        /// </summary>
        private enum PDFPrint : int
        {
            /// <summary>�ʏ���</summary>
            Usually = 0,
            /// <summary>�d�q����o��</summary>
            EBook = 1,
        }
        /// <summary>�o�͓`�[�敪 0:�����I���Ȃ�/1:����/2:����/3:�����I������ </summary>
        private enum outPutSlipTypeEnum : int
        {
            No = 0,                 // 0:�����I���Ȃ�
            Sales = 1,              // ����
            Estimate = 2,           // ����
            All = 3,                // �����I������
        }

        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        /// <summary>
        /// �d�q����A�g�I�v�V����
        /// </summary>
        public int Opt_PM_EBooks
        {
            get { return this._opt_PM_EBooks; }
            set { this._opt_PM_EBooks = value; }
        }
        //----- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�-------<<<<<
        /// <summary>����`�[����L�[���(key:�`�[�ԍ� value:�󒍃X�e�[�^�X,�ۑ��O�`�[�ԍ�)���擾���܂��B</summary>
        private Dictionary<string, SlipPrintInfoValue> PrintSalesKeyInfo { get { return _printSalesKeyInfo; } }

        #endregion // ����`�[����L�[���

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SaveDBData() 2007�s�ڂ��ڐA
        /// </remarks>
        /// <param name="salesDataList">���`�����[�g�̃p�����[�^(�����݌��ʁF�������X�g)</param>
        public SlipPrinter(ArrayList salesDataList)
        {
            _printSalesKeyInfo = new Dictionary<string, SlipPrintInfoValue>();

            if (salesDataList.Count.Equals(0)) return;
            // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
            #region ���d�q����A�g�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PM_EBooks = (int)Option.ON;
            }
            else
            {
                this._opt_PM_EBooks = (int)Option.OFF;
            }
            #endregion
            this._svSalesSlipWorkDic = new Dictionary<string, SalesSlipWork>();
            this._svSalesDetailWorkDic = new Dictionary<string, ArrayList>();
            // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
            //------------------------------------------------------
            // ����f�[�^�擾
            //------------------------------------------------------
            CustomSerializeArrayList list = null;
            for (int i = 0; i < salesDataList.Count; i++)
            {
                list = salesDataList[i] as CustomSerializeArrayList;
                if (list == null) continue;
                string prtOutputKey = string.Empty;// ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�
                foreach (object obj in list)
                {
                    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
                    if (obj is ArrayList && ((ArrayList)obj).Count > 0)
                    {
                        ArrayList al = (ArrayList)obj;
                        if (al[0].GetType() == typeof(SalesDetailWork))
                        {
                            prtOutputKey = ((SalesDetailWork)al[0]).SalesSlipNum + ((SalesDetailWork)al[0]).AcptAnOdrStatus.ToString();
                            if (!this._svSalesDetailWorkDic.ContainsKey(prtOutputKey) && ((SalesDetailWork)al[0]).AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                            {
                                _svSalesDetailWorkDic.Add(prtOutputKey, al);
                            }                           
                        }
                        continue;
                    }
                    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
                    SalesSlipWork salesSlipWork = obj as SalesSlipWork;
                    if (salesSlipWork == null) continue;

                    _enterpriseCode = salesSlipWork.EnterpriseCode;
                    _sectionCode    = salesSlipWork.SectionCode;

                    SlipPrintInfoValue slipPrintInfoValue = new SlipPrintInfoValue(
                        salesSlipWork.AcptAnOdrStatus,
                        SALES_SLIP_NUM_BEFORE_SAVE
                    );
                    if (CanPrint((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus))
                    {
                        _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                        // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
                        if (!this._svSalesSlipWorkDic.ContainsKey(prtOutputKey) && salesSlipWork.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                        {
                            prtOutputKey = salesSlipWork.SalesSlipNum + salesSlipWork.AcptAnOdrStatus.ToString();
                            this._svSalesSlipWorkDic.Add(prtOutputKey, salesSlipWork);
                        }
                        // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
                    }
                    continue;

                    #region <�Q�l>

                    //switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)
                    //{
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:       // ����
                    //    //case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                    //        if (GetEstimateDefSet().EstimatePrtDiv == 0)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:          // ����
                    //        if (GetSalesTtlSt().SalesSlipPrtDiv == 0)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    //case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                    //    //    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().ShipmSlipPrtDiv == 0) this._printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //    //    break;
                    //    case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:  // ��
                    //        if (GetAcptAnOdrTtlSt().AcpOdrrSlipPrtDiv == 1)
                    //        {
                    //            _printSalesKeyInfo.Add(salesSlipWork.SalesSlipNum, slipPrintInfoValue);
                    //        }
                    //        break;
                    //    default:
                    //        break;
                    //}   // switch ((SalesSlipInputAcs.AcptAnOdrStatusState)salesSlipWork.AcptAnOdrStatus)

                    #endregion // </�Q�l>
                }   // foreach (object obj in list)
            }   // for (int i = 0; i < salesDataList.Count; i++)
        }

        #endregion // </Constructor>

        /// <summary>
        /// �`�[����X���b�h
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.PrintSlipThread() 12441�s�ڂ��ڐA
        /// </remarks>
        public void PrintSlipThread()
        {
            PrintSlip(true);
        }

        /// <summary>
        /// �`�[�������
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.PrintSlip(bool) 2359�s�ڂ��ڐA
        /// </remarks>
        private void PrintSlip(bool printWithoutDialog)
        {
        #if DEBUG
            const string METHOD_NAME = "PrintSlip(bool)";   // ���O�p
        #else
            const string METHOD_NAME = "PrintSlip(bool) @Thread";   // ���O�p
        #endif

            #region ����������
            DCCMN02000UA printDisp = new DCCMN02000UA(SectionCode); // �`�[������ݒ��ʃC���X�^���X����
            {
                printDisp.IsService = 1;    // �T�[�r�X�N���Ή�
                // ADD 2011/08/12
                printDisp.IsAutoAns = 1;    // PCCUOE �����񓚋N���Ή�
            }
            SalesSlipPrintCndtn.SalesSlipKey key = new SalesSlipPrintCndtn.SalesSlipKey(); // �`�[����pKey�C���X�^���X����
            List<SalesSlipPrintCndtn.SalesSlipKey> keyList = new List<SalesSlipPrintCndtn.SalesSlipKey>(); // �`�[����pKeyList�C���X�^���X����
            bool reissueDiv = false;
            #endregion

            #region ������`�[Key���Z�b�g
            foreach (string salesSlipNum in PrintSalesKeyInfo.Keys)
            {
                SlipPrintInfoValue slipPrintInfoValue = PrintSalesKeyInfo[salesSlipNum];
                //if (slipPrintInfoValue.AcptAnOdrStatus != (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder)
                //{
                key = new SalesSlipPrintCndtn.SalesSlipKey();
                key.AcptAnOdrStatus = slipPrintInfoValue.AcptAnOdrStatus;
                key.SalesSlipNum = salesSlipNum;
                keyList.Add(key);
                //}
                if (slipPrintInfoValue.SalesSlipNum != OtherAppComponent.ctDefaultSalesSlipNum) reissueDiv = true;
            }
            //PrintSalesKeyInfo.Clear();
            #endregion

            #region ��������p�����[�^�Z�b�g
            SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
            salesSlipPrintCndtn.EnterpriseCode = EnterpriseCode;
            salesSlipPrintCndtn.SalesSlipKeyList = keyList;
            salesSlipPrintCndtn.ReissueDiv = reissueDiv;
            // zhouzy 20110921 add begin
            ////PCC�S�̐ݒ�ŁA����`�[���s�敪�́u1�F����v�̏ꍇ
            //if (CurrentSCMTotalSetting.SalesSlipPrtDiv.Equals(1))
            //{
            //    //�������
            //    salesSlipPrintCndtn.NomalSalesSlipPrintFlag = 0;
            //}
            //else
            //{
            //    //������Ȃ�
            //    salesSlipPrintCndtn.NomalSalesSlipPrintFlag = 1;
            //}
            salesSlipPrintCndtn.SCMTotalSettingSalesSlipPrtDiv = CurrentSCMTotalSetting.SalesSlipPrtDiv;
            salesSlipPrintCndtn.ScmFlg = true;
            // zhouzy 20110921 add end
            #endregion

            #region ���������

            #region <Log>

            string msg = string.Format(
                "DCCMN02000UA.IsService={0}, salesSlipPrintCndtn.SalesSlipKeyList.Count={1}",
                printDisp.IsService,
                salesSlipPrintCndtn.SalesSlipKeyList.Count
            );
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            try
            {
                if (salesSlipPrintCndtn.SalesSlipKeyList.Count != 0)
                {
                    PDFPrintStatus = (int)PDFPrint.Usually;//ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�
                    printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);
                    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>> 
                    //�d��.DX�I�v�V�����L���̏ꍇ�̂�
                    if (this._opt_PM_EBooks == (int)Option.ON)
                    {   
                        //�d�q����o��
                        EbooksOutput(keyList, printWithoutDialog); 
                    }
                    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<< 

                }
            }
            catch (InvalidOperationException ex)
            {
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME, LogHelper.GetExceptionMsg(
                    "DCCMN02000UA.ShowDialog()�ŗ�O���������܂����B",
                    ex,
                    true
                ));

                #endregion // </Log>
            }

            #endregion
        }
        // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
        #region DllImport
        [StructLayout(LayoutKind.Sequential)]
        private class PRINTER_DEFAULTS
        {
            public string pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public Int32 Attributes;
            public Int32 Priority;
            public Int32 DefaultPriority;
            public Int32 StartTime;
            public Int32 UntilTime;
            public Int32 Status;
            public Int32 cJobs;
            public Int32 AveragePPM;
        }
        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool GetPrinter(IntPtr hPrinter,
            int dwLevel, IntPtr pPrinter, int cbBuf, out int pcbNeeded);
        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
        pPrinter, int Command);
        [DllImport("winspool.drv", EntryPoint = "XcvDataW", SetLastError = true)]
        private static extern bool XcvData(
            IntPtr hXcv,
            [MarshalAs(UnmanagedType.LPWStr)] string pszDataName,
            IntPtr pInputData,
            uint cbInputData,
            IntPtr pOutputData,
            uint cbOutputData,
            out uint pcbOutputNeeded,
            out uint pwdStatus);
        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        private static extern int OpenPrinter(
            string pPrinterName,
            ref IntPtr phPrinter,
            PRINTER_DEFAULTS pDefault);
        #endregion DllImport

        /// <summary>
        /// �d�q����o��
        /// </summary>
        /// <param name="keyList">�`�[Key��񃊃X�g</param>
        /// <param name="printWithoutDialog">�_�C�A���O�\���Ȃ��t���O</param> 
        /// <remarks>
        /// <br>Note        : �d�q����o�͂��s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void EbooksOutput(List<SalesSlipPrintCndtn.SalesSlipKey> keyList, bool printWithoutDialog)
        {
            //�d�q����A�g�T�|�[�g�ݒ�XML�t�@�C���擾(MAHNB01001U_PDFOutputSettings.xml)
            eBooksOutputSetting eBookSetting = GetEBooksSettings();
            if (eBookSetting == null) return;

            //�o�c�e�_�C�A���O�\���t�@�C�����擾
            GetFileDialogDisplay();

            //�d�q����o�̓f�[�^�擾
            List<SalesSlipPrintCndtn.SalesSlipKey> printList;
            CustomerInfo customerInfo = new CustomerInfo();
            GetEbooksOutputData(eBookSetting, keyList, out printList, ref customerInfo);
            if (printList.Count == 0) return;

            //�r���Ώ�
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, CT_NAME_EBOOK);
            //�d�q����o�͐���(����`�[����/���Ӑ�d�q����/BLP�����񓚂�r��)
            int count = 0;
            while (!mutex.WaitOne(0, false))
            {
                if (count++ >= CT_MUTEX_WAIT_MAX)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        "",
                        MESS_PRINTERMUTEX_ERR,
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                        form.TopMost = false;
                        return;
                }
                Thread.Sleep(1000);
            }

            try
            {
                // �d�q����o�̓t���O:1(�d�q����o�͂���)
                PDFPrintStatus = (int)PDFPrint.EBook;

                #region �d�q����o��
                #region temp�t�H���_������
                // �d�������̏ꍇ�Atemp�t�H���_������
                if (!Directory.Exists(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                {
                    Directory.CreateDirectory(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
                }
                else
                {
                    foreach (string strFile in Directory.GetFiles(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                    {
                        File.Delete(strFile);
                    }
                }

                // �t�@�C���ۑ��_�C�A���O���\�����Ȃ����A��ƃt�H���_\Rename��������
                if (!this._fileDialogDisplay)
                {
                    string folderName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_RENAMEOLDER;
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    else
                    {
                        foreach (string strFile in Directory.GetFiles(folderName))
                        {
                            File.Delete(strFile);
                        }
                    }
                }
                #endregion

                #region PDF�t�@�C������
                // �`�[������ݒ��ʃC���X�^���X����
                DCCMN02000UA printDisp = new DCCMN02000UA(SectionCode); // �`�[������ݒ��ʃC���X�^���X����
                {
                    printDisp.IsService = 1;    // �T�[�r�X�N���Ή�
                    // ADD 2011/08/12
                    printDisp.IsAutoAns = 1;    // PCCUOE �����񓚋N���Ή�
                }
                //�Ĕ��s�敪
                bool reissueDiv = false;
                //������X�g��1�����L�̏������s��
                foreach (SalesSlipPrintCndtn.SalesSlipKey slipKey in printList)
                {
                    if (slipKey.SalesSlipNum != OtherAppComponent.ctDefaultSalesSlipNum) reissueDiv = true;
                    _portName = string.Empty;
                    Process WindowController = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    //PDF�o�͊Ď��̋N�����
                    startInfo.FileName = System.Environment.CurrentDirectory + CT_FOLDERSPLIT + PGID_VIRTUALPRINTER;
                    {
                        // �p�X
                        string filePath = CT_STRSPLIT + System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_STRSPLIT;
                        // ���Ӑ�R�[�h
                        string customerCd = customerInfo.CustomerCode.ToString(CT_CUSTOMERCDFOMART);
                        // ���Ӑ於
                        string cuntomerNm = CT_STRSPLIT + BadCharRemove(customerInfo.CustomerSnm.Trim()) + CT_STRSPLIT;
                        // �`�[�敪
                        string acptAnOdrStatusNm = string.Empty;
                        if (slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales)
                        {
                            acptAnOdrStatusNm = CT_NAME_SALE;
                        }
                        else
                        {
                            acptAnOdrStatusNm = CT_NAME_ESTIMATE;
                        }
                        // �`�[�ԍ�
                        string salesSlipNo = slipKey.SalesSlipNum;
                        // �ҋ@����
                        string waitTime = eBookSetting.PDFPrinterWait.ToString();
                        // �N����
                        string startFrom = CT_MODE_SALE; //���z�v�����^�_�C�A���O����ɑ΂��āA����`�[���͂���Ă΂�Ă��邱�Ƃɂ���

                        startInfo.Arguments = filePath + " " + customerCd + " "
                                            + cuntomerNm + " " + acptAnOdrStatusNm + " " + salesSlipNo + " "
                                            + waitTime + " " + startFrom;
                        WindowController.StartInfo = startInfo;
                        //�t�@�C���ۑ��_�C�A���O���\�����Ȃ����A���z�v�����^�̃|�[�g���𐶐�
                        if (!this._fileDialogDisplay)
                        {
                            // PDF�t�@�C�����u<���Ӑ�R�[�h>_<���Ӑ旪��>_<�`�[�敪��>_<�`�[�ԍ�>_<�o�͓���>.pdf�v
                            _portName = string.Format(CT_PORTNAME, customerCd, BadCharRemove(customerInfo.CustomerSnm.Trim()), acptAnOdrStatusNm, salesSlipNo);
                        }
                        // PDF�o�͊Ď������N��
                        WindowController.Start();
                    }
                    try
                    {
                        //�t�@�C���ۑ��_�C�A���O���\�����Ȃ����A���z�v�����^�̃|�[�g����ύX
                        if (!this._fileDialogDisplay) PrinterPortNameChange();

                        List<SalesSlipPrintCndtn.SalesSlipKey> subKeysList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
                        subKeysList.Add(slipKey);
                        SalesSlipPrintCndtn salesSlipPrintCndtn = new SalesSlipPrintCndtn();
                        salesSlipPrintCndtn.EnterpriseCode = EnterpriseCode;
                        salesSlipPrintCndtn.SalesSlipKeyList = subKeysList;
                        salesSlipPrintCndtn.ReissueDiv = reissueDiv;
                        salesSlipPrintCndtn.SCMTotalSettingSalesSlipPrtDiv = CurrentSCMTotalSetting.SalesSlipPrtDiv;
                        salesSlipPrintCndtn.ScmFlg = true;
                        salesSlipPrintCndtn.RemoteSalesSlipPrintFlag = 1;// �����[�g�`�[���s���Ȃ�
                        // �`�[������s
                        printDisp.ShowDialog(salesSlipPrintCndtn, printWithoutDialog);

                        // PDF�o�͊Ď������I����A����
                        WindowController.WaitForExit();
                    }
                    finally
                    {
                        //�t�@�C���ۑ��_�C�A���O���\�����Ȃ����A���z�v�����^�̃|�[�g���ɖ߂�
                        if (!this._fileDialogDisplay) PrinterPortNameRecovery();
                    }
                }
                #endregion PDF�t�@�C������

                //�d�q����󂯓n���p�t�H���_�擾
                EBooksLinkSetInfo eBooksFileFolderXmlInfo = GetEBooksFileFolderXmlInfo();
                // �C���f�b�N�X�t�@�C��
                List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList;
                MakeIndexFile(printList, eBooksFileFolderXmlInfo, out denchoDXIndexCSVEntityList);

                //����惊�X�g�쐬
                DenchoDXCustomerExportAcs denchoDXCustomerExportAcs = new DenchoDXCustomerExportAcs();
                denchoDXCustomerExportAcs.MakeCustomerCSVDifference(EnterpriseCode, eBooksFileFolderXmlInfo.CustomFolder + string.Format(CT_CUSTOMERFLPATH, DateTime.Now.ToString(CT_DATETIMEFOMART)));

                //���O�o��
                OutEBooksLog(DateTime.Now, denchoDXIndexCSVEntityList);
                #endregion �d�q����o��
            }
            finally
            {
                // �d�q����o�̓t���O:0(�ʏ�[�i���o��)
                PDFPrintStatus = (int)PDFPrint.Usually;
                //�~���[�e�b�N�X���������
                mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// �d�q���냍�O�o��
        /// </summary>
        /// <param name="stDateTime">�V�X�e������</param>
        /// <param name="denchoDXIndexCSVEntityList">�C���f�b�N�Xcsv�t�@�C�����X�g</param>
        /// <remarks>
        /// <br>Note        : �d�q���냍�O�o�͂��s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void OutEBooksLog(DateTime stDateTime, List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList)
        {
            System.IO.StreamWriter writer = null;
            try
            {
                // �[���ԍ��擾
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                int cashRegisterNo;
                posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, LoginInfoAcquisition.EnterpriseCode);

                string path = System.Environment.CurrentDirectory + CT_LOGFOLDER;
                // �t�H���_�쐬
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                string logPath = System.Environment.CurrentDirectory + CT_LOGFOLDER + string.Format(CT_LOGFILENM, DateTime.Now.ToString(CT_YMDFOMART), cashRegisterNo.ToString());
                writer = new System.IO.StreamWriter(logPath, true, System.Text.Encoding.Default);

                // �o�͓���
                writer.Write(stDateTime.ToString(CT_LOGDATETIMEFOMART));
                writer.Write(Environment.NewLine);

                // ����
                writer.Write(string.Format(CT_LOGCOUNT, denchoDXIndexCSVEntityList.Count.ToString()));
                writer.Write(Environment.NewLine);

                // �t�@�C����
                foreach (DenchoDXIndexCSVEntity work in denchoDXIndexCSVEntityList)
                {
                    writer.Write(work.Filename);
                    writer.Write(Environment.NewLine);
                }

                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                string opLogMsg = string.Format(CT_OPLOGMSG, denchoDXIndexCSVEntityList.Count.ToString(), logPath);
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_PMSCM01010U, PGNAME_STR, string.Empty, OPERATIONCODE_EBOOKS, 0, opLogMsg, string.Empty);
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// �d�q����󂯓n���p�t�H���_�擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : �d�q����󂯓n���p�t�H���_�擾�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private EBooksLinkSetInfo GetEBooksFileFolderXmlInfo()
        {
            EBooksLinkSetInfo eBooksFileFolderXmlInfo = new EBooksLinkSetInfo();
            try
            {
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO)))
                {
                    // XML����`�F�b�N�敪���擾����
                    eBooksFileFolderXmlInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO));
                }
                else
                {
                    // �f�t�H���g�t�H���_
                    eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                    eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
                }
            }
            catch
            {
                // �f�t�H���g�t�H���_
                eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
            }
            finally
            {
                // �t�H���_�쐬
                if (!Directory.Exists(eBooksFileFolderXmlInfo.EBooksFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.EBooksFolder);
                }
                if (!Directory.Exists(eBooksFileFolderXmlInfo.CustomFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.CustomFolder);
                }
            }
            return eBooksFileFolderXmlInfo;
        }

        /// <summary>
        /// �d�q����o�̓f�[�^�擾
        /// </summary>
        /// <param name="eBookSetting">�d�q����A�g�T�|�[�g�ݒ�XML�t�@�C��</param>
        /// <param name="keyList">�`�[���X�g</param>
        /// <param name="printList">�d�q����o�̓f�[�^</param>
        /// <param name="customerInfo">���Ӑ���</param>
        /// <remarks>
        /// <br>Note        : �d�q����o�̓f�[�^�擾�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void GetEbooksOutputData(eBooksOutputSetting eBookSetting, List<SalesSlipPrintCndtn.SalesSlipKey> keyList, out List<SalesSlipPrintCndtn.SalesSlipKey> printList, ref CustomerInfo customerInfo)
        {
            printList = new List<SalesSlipPrintCndtn.SalesSlipKey>();
            int customerCode = 0;
            //�擪�`�[���̓��Ӑ�����擾
            if (keyList.Count >0)
            {
                SalesSlipPrintCndtn.SalesSlipKey key = (SalesSlipPrintCndtn.SalesSlipKey)keyList[0];
                // ����f�[�^
                string dicKey = key.SalesSlipNum + key.AcptAnOdrStatus.ToString();
                if (_svSalesSlipWorkDic.ContainsKey(dicKey)) customerCode = ((SalesSlipWork)_svSalesSlipWorkDic[dicKey]).CustomerCode;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.ReadDBData(EnterpriseCode, customerCode, out customerInfo);
                if (customerInfo == null) return;

            }

            //�`�[PDF�o�� 0:���Ȃ��^1:����^2:�d�q����o�͂ɏ]��
            if (eBookSetting.OutputMode == (int)OutputMode.PDFPrintEnable ||
                ((eBookSetting.OutputMode == (int)OutputMode.PDFPrintCustom) && (customerInfo.DmOutCode == (int)DmOutCode.YES)))
            {
                //�o�͓`�[�敪 0:�����I���Ȃ�/1:����/2:����/3:�����I������
                foreach (SalesSlipPrintCndtn.SalesSlipKey slipKey in keyList)
                {
                    if ((slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales
                        && (eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.Sales || eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.All)) ||
                       (slipKey.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate
                        && (eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.Estimate || eBookSetting.OutputSlipType == (int)outPutSlipTypeEnum.All)))
                    {
                        //�d�q����o�͑ΏۂƂ���
                        printList.Add(slipKey);
                    }
                }
 
            }
        }

        /// <summary>
        /// �C���f�b�N�X�t�@�C���쐬
        /// </summary>
        /// <param name="denchoDXIndexCSVEntityList">�C���f�b�N�Xcsv�t�@�C�����X�g</param>
        /// <param name="eBooksFileFolderXmlInfo">XML�t�@�C��</param>
        /// <param name="keyList">�`�[���X�g</param>
        /// <remarks>
        /// <br>Note        : �C���f�b�N�X�t�@�C���쐬�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void MakeIndexFile(List<SalesSlipPrintCndtn.SalesSlipKey> keyList, EBooksLinkSetInfo eBooksFileFolderXmlInfo, out List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList)
        {

            denchoDXIndexCSVEntityList = new List<DenchoDXIndexCSVEntity>();
            try
            {
                //�t�@�C�������X�g
                Dictionary<string, ArrayList> pdfFileNmList = new Dictionary<string, ArrayList>();

                // PDF�󂯓n��
                //�t�@�C���R�s�[
                DirectoryInfo dir;
                if (this._fileDialogDisplay)
                {
                    // ��ƃt�H���_����擾
                    dir = new DirectoryInfo(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
                }
                else
                {
                    // ��ƃt�H���_\Rename����擾
                    dir = new DirectoryInfo(System.Environment.CurrentDirectory + CT_TEMPFOLDER + CT_RENAMEOLDER);
                }
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        continue;
                    }
                    else
                    {
                        string[] subFlNm = i.FullName.Split(CT_SPLITCHAR);
                        if (pdfFileNmList.ContainsKey(subFlNm[3]))
                        {
                            pdfFileNmList[subFlNm[3]].Add(i.Name);
                        }
                        else
                        {
                            ArrayList al = new ArrayList();
                            al.Add(i.Name);
                            pdfFileNmList.Add(subFlNm[3], al);
                        }
                    }
                }
                if (pdfFileNmList.Count == 0) return;
                foreach (SalesSlipPrintCndtn.SalesSlipKey key in keyList)
                {
                    // ����f�[�^
                    string dicKey = key.SalesSlipNum + key.AcptAnOdrStatus.ToString();
                    SalesSlipWork salesSlipWork = new SalesSlipWork();
                    ArrayList salesDetailWorkList = new ArrayList();
                    if (_svSalesSlipWorkDic.ContainsKey(dicKey)) salesSlipWork = _svSalesSlipWorkDic[dicKey];
                    if (_svSalesDetailWorkDic.ContainsKey(dicKey)) salesDetailWorkList = _svSalesDetailWorkDic[dicKey];

                    // �C���f�b�N�X�t�@�C���쐬�p�G���e�B�e�B
                    DenchoDXIndexCSVEntity denchoDXIndexCSVEntity = new DenchoDXIndexCSVEntity();

                    //�V�X�e���敪
                    denchoDXIndexCSVEntity.Mcd = DenchoDXIndexCSVEntity.EMcdType.PMNS;
                    //�����R�[�h(����)	
                    denchoDXIndexCSVEntity.Blcustomercd = LoginInfoAcquisition.EnterpriseCode;

                    //���ޕ���	
                    if (key.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales)
                    {
                        //�[�i��
                        denchoDXIndexCSVEntity.Doctype = DenchoDXIndexCSVEntity.EDocType.DeliverySlip;
                    }
                    else
                    {
                        //���Ϗ�
                        denchoDXIndexCSVEntity.Doctype = DenchoDXIndexCSVEntity.EDocType.Quotation;
                    }
                    //�����R�[�h	
                    denchoDXIndexCSVEntity.Customercd = salesSlipWork.CustomerCode.ToString(CT_CUSTOMERCDFOMART);
                    //����於��	
                    denchoDXIndexCSVEntity.Customername = BadCharRemove(salesSlipWork.CustomerSnm.Trim());
                    //���ޔԍ�	
                    denchoDXIndexCSVEntity.Docnumber = key.SalesSlipNum;
                    //���Ӑ�̓]�ŕ����F������/�����q�̎�
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        //������z���v(�Ŕ���)	
                        denchoDXIndexCSVEntity.Price_tax_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //������z���v(�ō���)	
                        denchoDXIndexCSVEntity.Price_tax_included = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //����ŋ��z���v	
                        denchoDXIndexCSVEntity.Total_tax = 0;
                    }
                    else
                    {
                        //������z���v(�ō���)	
                        denchoDXIndexCSVEntity.Price_tax_included = (decimal)salesSlipWork.SalesTotalTaxInc;
                        //������z���v(�Ŕ���)	
                        denchoDXIndexCSVEntity.Price_tax_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                        //����ŋ��z���v	
                        denchoDXIndexCSVEntity.Total_tax = (decimal)(salesSlipWork.SalesTotalTaxInc - salesSlipWork.SalesTotalTaxExc);
                    }
                    // ���l
                    denchoDXIndexCSVEntity.Memo = salesSlipWork.SlipNote;
                    // �o�^�ԍ�(���s��)
                    denchoDXIndexCSVEntity.Aojcorporatenumber = string.Empty;
                    // ���s�Җ���
                    denchoDXIndexCSVEntity.Companyname = GetCompanyName();
                    // ���s���_�R�[�h
                    denchoDXIndexCSVEntity.Sectioncd = Convert.ToUInt64(salesSlipWork.ResultsAddUpSecCd);
                    // ���s���_����
                    denchoDXIndexCSVEntity.Sectionname = GetSectionNm(salesSlipWork.ResultsAddUpSecCd.Trim());
                    //�ʉݒP��
                    denchoDXIndexCSVEntity.Currencyunit = DenchoDXIndexCSVEntity.ECurrencyUnitType.JPY;

                    // �ŗ������z�擾
                    decimal price_taxrate1_excluded = decimal.Zero;
                    decimal price_taxrate1_included = decimal.Zero;
                    decimal tax1 = decimal.Zero;
                    decimal price_taxrate2_excluded = decimal.Zero;
                    decimal price_taxrate2_included = decimal.Zero;
                    decimal tax2 = decimal.Zero;
                    decimal price_taxrate3_excluded = decimal.Zero;
                    decimal price_taxrate3_included = decimal.Zero;
                    decimal tax3 = decimal.Zero;
                    GetPriceByRate(salesSlipWork, salesDetailWorkList,
                        out price_taxrate1_excluded, out price_taxrate1_included, out tax1,
                        out price_taxrate2_excluded, out price_taxrate2_included, out tax2,
                        out price_taxrate3_excluded, out price_taxrate3_included, out tax3);

                    // �ŗ�(1)	
                    denchoDXIndexCSVEntity.Taxrate1 = 100;
                    // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
                    denchoDXIndexCSVEntity.Price_taxrate1_excluded = price_taxrate1_excluded;
                    // �ŗ�(1)�Ώۋ��z���v(�ō���)
                    denchoDXIndexCSVEntity.Price_taxrate1_included = price_taxrate1_included;
                    // �Ŋz(1)
                    denchoDXIndexCSVEntity.Tax1 = tax1;
                    // �ŗ�(2)	
                    denchoDXIndexCSVEntity.Taxrate2 = 80;
                    // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
                    denchoDXIndexCSVEntity.Price_taxrate2_excluded = price_taxrate2_excluded;
                    // �ŗ�(2)�Ώۋ��z���v(�ō���)
                    denchoDXIndexCSVEntity.Price_taxrate2_included = price_taxrate2_included;
                    // �Ŋz(2)
                    denchoDXIndexCSVEntity.Tax2 = tax2;
                    // �ŗ�(3)	
                    denchoDXIndexCSVEntity.Taxrate3 = 0;
                    // �ŗ�(3)�Ώۋ��z���v(�Ŕ���)
                    denchoDXIndexCSVEntity.Price_taxrate3_excluded = price_taxrate3_excluded;
                    // �ŗ�(3)�Ώۋ��z���v(�ō���)
                    denchoDXIndexCSVEntity.Price_taxrate3_included = price_taxrate3_included;
                    // �Ŋz(3)
                    denchoDXIndexCSVEntity.Tax3 = tax3;
                    if (pdfFileNmList.Count > 0)
                    {
                        ArrayList al = pdfFileNmList[key.SalesSlipNum];
                        if (al.Count == 1)
                        {
                            //����`�[��1��PDF�����̂�
                            //�t�@�C����	 
                            denchoDXIndexCSVEntity.Filename = (string)al[0];
                            //����N����
                            int idx = ((string)al[0]).LastIndexOf(CT_SPLITSTR);
                            string dateStr = ((string)al[0]).Substring(idx + 1, 14);
                            DateTime dateTime = DateTime.ParseExact(dateStr, CT_DATETIMEFOMART, System.Globalization.CultureInfo.CurrentCulture);
                            denchoDXIndexCSVEntity.Transactiondate = dateTime;
                            //�������	
                            denchoDXIndexCSVEntity.Transactiontime = dateTime;
                            denchoDXIndexCSVEntityList.Add(denchoDXIndexCSVEntity);
                        }
                        else
                        {
                            //����`�[��������PDF����
                            foreach (string fileName in al)
                            {
                                DenchoDXIndexCSVEntity csvEntity = DenchoDXIndexCSVEntityClone(denchoDXIndexCSVEntity);
                                //�t�@�C����
                                csvEntity.Filename = fileName;
                                //����N����
                                int idx = fileName.LastIndexOf(CT_SPLITSTR);
                                string dateStr = fileName.Substring(idx + 1, 14);
                                DateTime dateTime = DateTime.ParseExact(dateStr, CT_DATETIMEFOMART, System.Globalization.CultureInfo.CurrentCulture);
                                csvEntity.Transactiondate = dateTime;
                                //�������	
                                csvEntity.Transactiontime = dateTime;
                                denchoDXIndexCSVEntityList.Add(csvEntity);
                            }
                        }
                    }
                }

                DenchoDXIndexCSV denchoDXIndexCSV = new DenchoDXIndexCSV(denchoDXIndexCSVEntityList);
                string pathCSV = dir + string.Format(CT_EBOOKSFLPATH, LoginInfoAcquisition.EnterpriseCode, DateTime.Now.ToString(CT_DATETIMEFOMART));
                denchoDXIndexCSV.MakeIndexCSV(pathCSV);

                //�t�@�C���R�s�[
                fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        continue;
                    }
                    else
                    {
                        File.Copy(i.FullName, eBooksFileFolderXmlInfo.EBooksFolder + CT_FOLDERSPLIT + i.Name);
                    }
                }
            }
            catch
            {
                //���������e���Ȃ�
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̎擾���s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks> 
        private string GetSectionNm(string sectionCode)
        {
            string sectionNm = string.Empty;
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            if (secInfoAcs.SecInfoSetList != null)
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim())
                    {
                        // ���_���擾
                        sectionNm = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            return sectionNm;
        }

        /// <summary>
        /// ���Ж��擾
        /// </summary>
        /// <returns>���Ж�</returns>
        /// <remarks>
        /// <br>Note        : ���Ж��擾���s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private string GetCompanyName()
        {
            string companyName = string.Empty;
            CompanyInf companyInf;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out companyInf, EnterpriseCode);
            if (companyInf != null) companyName = companyInf.CompanyName1.Trim();
            return companyName;
        }

        /// <summary>
        /// Clone����
        /// </summary>
        /// <param name="denchoDXIndexCSVEntity">�C���f�b�N�Xcsv�t�@�C��</param>
        /// <remarks>
        /// <br>Note        : Clone�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private DenchoDXIndexCSVEntity DenchoDXIndexCSVEntityClone(DenchoDXIndexCSVEntity denchoDXIndexCSVEntity)
        {
            DenchoDXIndexCSVEntity csvEntity = new DenchoDXIndexCSVEntity();
            //�V�X�e���敪
            csvEntity.Mcd = denchoDXIndexCSVEntity.Mcd;
            //�����R�[�h(����)	
            csvEntity.Blcustomercd = denchoDXIndexCSVEntity.Blcustomercd;
            //�t�@�C����	
            csvEntity.Filename = denchoDXIndexCSVEntity.Filename;
            //���ޕ���	
            csvEntity.Doctype = denchoDXIndexCSVEntity.Doctype;
            //�����R�[�h	
            csvEntity.Customercd = denchoDXIndexCSVEntity.Customercd;
            //����於��	
            csvEntity.Customername = denchoDXIndexCSVEntity.Customername;
            //���ޔԍ�	
            csvEntity.Docnumber = denchoDXIndexCSVEntity.Docnumber;
            //����N����	
            csvEntity.Transactiondate = denchoDXIndexCSVEntity.Transactiondate;
            //�������
            csvEntity.Transactiontime = denchoDXIndexCSVEntity.Transactiontime;
            //������z���v(�ō���)	
            csvEntity.Price_tax_included = denchoDXIndexCSVEntity.Price_tax_included;
            //������z���v(�Ŕ���)	
            csvEntity.Price_tax_excluded = denchoDXIndexCSVEntity.Price_tax_excluded;
            //����ŋ��z���v	
            csvEntity.Total_tax = denchoDXIndexCSVEntity.Total_tax;
            // ���l
            csvEntity.Memo = denchoDXIndexCSVEntity.Memo;
            // �o�^�ԍ�(���s��)
            csvEntity.Aojcorporatenumber = denchoDXIndexCSVEntity.Aojcorporatenumber;
            // ���s�Җ���
            csvEntity.Companyname = denchoDXIndexCSVEntity.Companyname;
            // ���s���_�R�[�h
            csvEntity.Sectioncd = denchoDXIndexCSVEntity.Sectioncd;
            // ���s���_����
            csvEntity.Sectionname = denchoDXIndexCSVEntity.Sectionname;
            //�ʉݒP��
            csvEntity.Currencyunit = denchoDXIndexCSVEntity.Currencyunit;
            // �ŗ�(1)	
            csvEntity.Taxrate1 = denchoDXIndexCSVEntity.Taxrate1;
            // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
            csvEntity.Price_taxrate1_excluded = denchoDXIndexCSVEntity.Price_taxrate1_excluded;
            // �ŗ�(1)�Ώۋ��z���v(�ō���)
            csvEntity.Price_taxrate1_included = denchoDXIndexCSVEntity.Price_taxrate1_included;
            // �Ŋz(1)
            csvEntity.Tax1 = denchoDXIndexCSVEntity.Tax1;
            // �ŗ�(2)	
            csvEntity.Taxrate2 = denchoDXIndexCSVEntity.Taxrate2;
            // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
            csvEntity.Price_taxrate2_excluded = denchoDXIndexCSVEntity.Price_taxrate2_excluded;
            // �ŗ�(2)�Ώۋ��z���v(�ō���)
            csvEntity.Price_taxrate2_included = denchoDXIndexCSVEntity.Price_taxrate2_included;
            // �Ŋz(2)
            csvEntity.Tax2 = denchoDXIndexCSVEntity.Tax2;
            // �ŗ�(3)	
            csvEntity.Taxrate3 = denchoDXIndexCSVEntity.Taxrate3;
            // �ŗ�(3)�Ώۋ��z���v(�Ŕ���)
            csvEntity.Price_taxrate3_excluded = denchoDXIndexCSVEntity.Price_taxrate3_excluded;
            // �ŗ�(3)�Ώۋ��z���v(�ō���)
            csvEntity.Price_taxrate3_included = denchoDXIndexCSVEntity.Price_taxrate3_included;
            // �Ŋz(3)
            csvEntity.Tax3 = denchoDXIndexCSVEntity.Tax3;
            return csvEntity;

        }

        /// <summary>
        /// �ŗ��P�`�ŗ��R�̋��z���Z�o
        /// </summary>
        /// <param name="salesDetailWorkList">���㖾�׃f�[�^���X�g</param>
        /// <param name="salesSlipWork">����`�[�f�[�^���X�g</param>
        /// <param name="price_taxrate1_excluded">�ŗ�(1)�Ώۋ��z���v(�Ŕ���)</param>
        /// <param name="price_taxrate1_included">�ŗ�(1)�Ώۋ��z���v(�ō���)</param>
        /// <param name="tax1">�Ŋz(1)</param>
        /// <param name="price_taxrate2_excluded">�ŗ�(2)�Ώۋ��z���v(�Ŕ���)</param>
        /// <param name="price_taxrate2_included">�ŗ�(2)�Ώۋ��z���v(�ō���)</param>
        /// <param name="tax2">�Ŋz(2)</param>
        /// <param name="price_taxrate3_excluded">�ŗ�(3)�Ώۋ��z���v(�Ŕ���)</param>
        /// <param name="price_taxrate3_included">�ŗ�(3)�Ώۋ��z���v(�ō���)</param>
        /// <param name="tax3">�Ŋz(3)</param>
        /// <remarks>
        /// <br>Note        : �ŗ��P�`�ŗ��R�̋��z���Z�o����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/05/26</br>
        /// </remarks>
        private void GetPriceByRate(SalesSlipWork salesSlipWork, ArrayList salesDetailWorkList,
                        out decimal price_taxrate1_excluded, out decimal price_taxrate1_included, out decimal tax1,
                        out decimal price_taxrate2_excluded, out decimal price_taxrate2_included, out decimal tax2,
                        out decimal price_taxrate3_excluded, out decimal price_taxrate3_included, out decimal tax3)
        {
            // ������
            price_taxrate1_excluded = decimal.Zero;
            price_taxrate1_included = decimal.Zero;
            tax1 = 0;
            price_taxrate2_excluded = decimal.Zero;
            price_taxrate2_included = decimal.Zero;
            tax2 = 0;
            price_taxrate3_excluded = decimal.Zero;
            price_taxrate3_included = decimal.Zero;
            tax3 = 0;

            // ��ېł̏ꍇ
            if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                price_taxrate3_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                price_taxrate3_included = (decimal)salesSlipWork.SalesTotalTaxInc;
            }
            else
            {
                decimal price_excluded = (decimal)salesSlipWork.SalesTotalTaxExc;
                decimal price_included = (decimal)salesSlipWork.SalesTotalTaxInc;
                decimal tax = (decimal)salesSlipWork.SalesSubtotalTax;
                decimal price_taxNone = decimal.Zero;
                foreach (SalesDetailWork detailWork in salesDetailWorkList)
                {
                    if (detailWork.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                    {
                        // ��ېŋ��z�Z�o
                        price_taxNone = price_taxNone + detailWork.SalesMoneyTaxExc;
                    }
                }
                if (salesSlipWork.ConsTaxRate == RATE10)
                {
                    //���Ӑ�̓]�ŕ����F������/�����q�̎�
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        price_taxrate1_excluded = price_excluded - price_taxNone;
                        price_taxrate1_included = price_taxrate1_excluded;
                        tax1 = 0;
                    }
                    else
                    {
                        price_taxrate1_excluded = price_excluded - price_taxNone;
                        price_taxrate1_included = price_included - price_taxNone;
                        tax1 = tax;
                    }

                }
                if (salesSlipWork.ConsTaxRate == RATE8)
                {
                    //���Ӑ�̓]�ŕ����F������/�����q�̎�
                    if (salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandParentLay ||
                        salesSlipWork.ConsTaxLayMethod == (int)ConsTaxLayMethod.DemandChildLay)
                    {
                        price_taxrate2_excluded = price_excluded - price_taxNone;
                        price_taxrate2_included = price_taxrate2_excluded;
                        tax2 = 0;
                    }
                    else
                    {
                        price_taxrate2_excluded = price_excluded - price_taxNone;
                        price_taxrate2_included = price_included - price_taxNone;
                        tax2 = tax;
                    }
                }
                price_taxrate3_excluded = price_taxNone;
                price_taxrate3_included = price_taxNone;
            }
        }

        /// <summary>
        /// �֎~�������폜����(�u\�v�u/�v�u:�v�u*�v�u?�v�u"�v�u>�v�u|�v�u_�v)
        /// </summary>
        /// <param name="customNm">���Ӑ於</param>
        /// <returns>�u����̓��Ӑ於</returns>
        /// <remarks>
        /// <br>Note         : �֎~�������폜����</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private string BadCharRemove(string customNm)
        {
            StringBuilder claimSnmStr = new StringBuilder();
            string[] result = customNm.Split(badChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in result)
            {
                claimSnmStr.Append(str);
            }
            return claimSnmStr.ToString();
        }

        /// <summary>
        /// ���z�v�����^�̃|�[�g�ύX
        /// </summary>
        /// <remarks>
        /// <br>Note         : ���z�v�����^�̃|�[�g�ύX</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void PrinterPortNameChange()
        {
            // �|�[�g��
            string portName = string.Empty;
            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pPrinterInfo = IntPtr.Zero;
            PRINTER_DEFAULTS def;
            PRINTER_INFO_2 pi;
            try
            {
                // �|�[�g��
                portName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + _portName;
                //���[�J���|�[�g�̃f�[�^�^�A���A�������f�[�^�A����уA�N�Z�X�����w��
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = DESIREDACCESS_ONE;

                //���[�J���|�[�g�̃n���h�����擾����
                int n = OpenPrinter(CT_LOCALPORT, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;

                if (!portName.EndsWith(CT_ZERO)) portName += CT_ZERO;
                uint size = (uint)(portName.Length * CT_INT_TWO);
                pPrinterInfo = Marshal.AllocHGlobal((int)size);
                Marshal.Copy(portName.ToCharArray(), CT_INT_ZERO, pPrinterInfo, portName.Length);

                uint needed;
                uint xcvResult;
                // ���[�J���|�[�g��ǉ�
                bool result = XcvData(hPrinter, CT_ADDPORT, pPrinterInfo, size, IntPtr.Zero, CT_INT_ZERO, out needed, out xcvResult);
                if (!result) return;
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);

                pi = new PRINTER_INFO_2();
                hPrinter = IntPtr.Zero;
                pPrinterInfo = IntPtr.Zero;
                int needed2;
                int temp;

                //�v�����^�[�̃f�[�^�^�A���A�������f�[�^�A����уA�N�Z�X�����w��
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = 0xf000C;// PRINTER_ALL_ACCESS


                //���z�v�����^�̃n���h�����擾����
                n = OpenPrinter(CT_PRINTER, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;
                //�o�b�t�@�ɕK�v�ȃo�C�g�����擾����
                GetPrinter(hPrinter, LEVEL_TWO, IntPtr.Zero, CBBUF_ZERO, out needed2);
                //�����������蓖�Ă�
                pPrinterInfo = Marshal.AllocHGlobal(needed2);
                //�ڍׂȃv�����^�����擾
                result = GetPrinter(hPrinter, LEVEL_TWO, (IntPtr)pPrinterInfo, needed2, out temp);
                if (!result) return;
                //PRINTER_INFO_2�^�Ƀ}�[�V�������O����
                pi = (PRINTER_INFO_2)Marshal.PtrToStructure(pPrinterInfo, typeof(PRINTER_INFO_2));

                //�v�����^�ݒ�F�|�[�g��
                pi.pPortName = portName;
                Marshal.StructureToPtr(pi, pPrinterInfo, true);
                //���z�v�����^�̃|�[�g�ύX���A�|�[�g�ύX�Ώۂ̃v�����^�̃W���u���N���A����
                result = SetPrinter(hPrinter, LEVEL_ZERO, IntPtr.Zero, COMMAND_THREE);
                if (!result) return;
                //�v�����^�ݒ���𔽉f
                result = SetPrinter(hPrinter, LEVEL_TWO, pPrinterInfo, COMMAND_ZERO);
                if (!result) return;
            }
            catch(Exception ex)
            {
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME_PORT1, LogHelper.GetExceptionMsg(
                    string.Format(MESS_PRINTERPORT_ERR, 1),
                    ex,
                    true
                ));
                #endregion // </Log>
            }
        }

        /// <summary>
        /// ���z�v�����^�̃|�[�g���ɖ߂�
        /// </summary>
        /// <remarks>
        /// <br>Note         : ���z�v�����^�̃|�[�g���ɖ߂�</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void PrinterPortNameRecovery()
        {
            IntPtr hPrinter = IntPtr.Zero;
            IntPtr pPrinterInfo = IntPtr.Zero;
            PRINTER_INFO_2 pi = new PRINTER_INFO_2();
            PRINTER_DEFAULTS def;
            try
            {
                int needed2;
                int temp;
                //�v�����^�[�̃f�[�^�^�A���A�������f�[�^�A����уA�N�Z�X�����w��
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = 0xf000C;

                //���z�v�����^�̃n���h�����擾����
                int n = OpenPrinter(CT_PRINTER, ref hPrinter, def);
                if (n == STATUS_NORMAL) return;
                //�o�b�t�@�ɕK�v�ȃo�C�g�����擾����
                GetPrinter(hPrinter, LEVEL_TWO, IntPtr.Zero, CBBUF_ZERO, out needed2);
                //�����������蓖�Ă�
                pPrinterInfo = Marshal.AllocHGlobal(needed2);
                //�ڍׂȃv�����^�����擾
                bool result = GetPrinter(hPrinter, LEVEL_TWO, (IntPtr)pPrinterInfo, needed2, out temp);
                if (!result) return;
                //PRINTER_INFO_2�^�Ƀ}�[�V�������O����
                pi = (PRINTER_INFO_2)Marshal.PtrToStructure(pPrinterInfo, typeof(PRINTER_INFO_2));

                //�v�����^�ݒ�F�f�t�H���g�|�[�g�ɖ߂�
                pi.pPortName = CT_DEFALUT_PORTNAME;
                Marshal.StructureToPtr(pi, pPrinterInfo, true);
                //�v�����^�ݒ���𔽉f
                result = SetPrinter(hPrinter, LEVEL_TWO, pPrinterInfo, COMMAND_ZERO);
                if (!result) return;
                //�v�����^�����
                ClosePrinter(hPrinter);
                Marshal.FreeHGlobal(pPrinterInfo);

                // �ǉ��̃��[�J���|�[�g��
                string portName = System.Environment.CurrentDirectory + CT_TEMPFOLDER + _portName;
                def = new PRINTER_DEFAULTS();
                def.pDatatype = null;
                def.pDevMode = IntPtr.Zero;
                def.DesiredAccess = DESIREDACCESS_ONE;
                hPrinter = IntPtr.Zero;
                pPrinterInfo = IntPtr.Zero;

                //�ǉ��̃��[�J���|�[�g�̃n���h�����擾����
                n = OpenPrinter(CT_LOCALPORT, ref hPrinter, def);
                if (n == 0) return;
                if (!portName.EndsWith(CT_ZERO)) portName += CT_ZERO;
                uint size = (uint)(portName.Length * CT_INT_TWO);
                pPrinterInfo = Marshal.AllocHGlobal((int)size);
                Marshal.Copy(portName.ToCharArray(), CT_INT_ZERO, pPrinterInfo, portName.Length);

                uint needed;
                uint xcvResult;
                //�ǉ��̃��[�J���|�[�g���폜
                result = XcvData(hPrinter, CT_DELETEPORT, pPrinterInfo, size, IntPtr.Zero, CT_INT_ZERO, out needed, out xcvResult);
                if (!result) return;
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
            }
            catch (Exception ex)
            {
                Marshal.FreeHGlobal(pPrinterInfo);
                ClosePrinter(hPrinter);
                #region <Log>

                EasyLogger.Write(MY_NAME, METHOD_NAME_PORT1, LogHelper.GetExceptionMsg(
                    string.Format(MESS_PRINTERPORT_ERR, 2),
                    ex,
                    true
                ));
                #endregion // </Log>

            }
         // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
        }

        /// <summary>
        /// �d���ݒ�t�@�C���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : �d���ݒ�t�@�C���擾</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private eBooksOutputSetting GetEBooksSettings()
        {
            eBooksOutputSetting eBooksOutputSetting = null;
            try
            {
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS)))
                {
                    // �d���ݒ���擾����
                    eBooksOutputSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFOUTPUTSETTINGS));                   
                }
            }
            catch
            {
                //�@���������e���Ȃ�
            }
            return eBooksOutputSetting;
        }

        /// <summary>
        /// �t�@�C���ۑ��_�C�A���O�\���𐧌� ������̓d�q����Ή��ł̓_�C�A���O�\�����g�p���Ȃ�
        /// </summary>
        /// <remarks>
        /// <br>Note         : �t�@�C���ۑ��_�C�A���O�\���𐧌䂷��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/05/26</br>
        /// </remarks>
        private void GetFileDialogDisplay()
        {
            try
            {
                // �t�@�C���ۑ��_�C�A���O�\���𐧌�
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_PDFPRINTERSETTINGENABLE)))
                {
                    this._fileDialogDisplay = true;
                }
                else
                {
                    this._fileDialogDisplay = false;
                }
            }
            catch
            {
                this._fileDialogDisplay = false;
            }
        }
        // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
    }
    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
    # region �d�q����v�����^���ڐݒ���
    /// <summary>
    /// �d�q����v�����^���ڐݒ���
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�q����v�����^���ڐݒ���</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2022/05/26</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class eBooksOutputSetting
    {
        /// <summary>�d�q����v�����^���ڐݒ���</summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>�`�[PDF�o��</summary>
        private int _outputMode;
        /// <summary>�o�͓`�[�敪</summary>
        private int _outputSlipType;
        /// <summary>PDF�v�����^ [Windows�W���^���̑�] </summary>
        private int _pDFPrinter;
        /// <summary>���蓖�čς݂̃v�����^�Ǘ��ԍ� </summary>
        private int _pDFPrinterNumber;
        /// <summary>���z�v�����^���䂪�I������܂ł̑ҋ@����</summary>
        private int _pDFPrinterWait;

        /// <summary>�`�[PDF�o��</summary>
        public Int32 OutputMode
        {
            get { return _outputMode; }
            set { _outputMode = value; }
        }

        /// <summary>�o�͓`�[�敪</summary>
        public Int32 OutputSlipType
        {
            get { return _outputSlipType; }
            set { _outputSlipType = value; }
        }
        /// <summary>PDF�v�����^ [Windows�W���^���̑�] </summary>
        public Int32 PDFPrinter
        {
            get { return _pDFPrinter; }
            set { _pDFPrinter = value; }
        }

        /// <summary>���蓖�čς݂̃v�����^�Ǘ��ԍ� </summary>
        public Int32 PDFPrinterNumber
        {
            get { return _pDFPrinterNumber; }
            set { _pDFPrinterNumber = value; }
        }

        /// <summary>���z�v�����^���䂪�I������܂ł̑ҋ@����</summary>
        public Int32 PDFPrinterWait
        {
            get { return _pDFPrinterWait; }
            set { _pDFPrinterWait = value; }
        }
    }
    # endregion
    // --- ADD ���O 2022/05/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
}
