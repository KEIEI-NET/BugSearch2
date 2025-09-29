//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : �c����
// �� �� ��  2019/12/02      �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : ���c�`�[
// �X �V ��  2020/02/04      �C�����e : �i�C�����e�ꗗNo.�Q�j���l�o�͐ݒ荀�ڕύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670214-00     �쐬�S�� : 3H ����
// �X �V ��  2019/09/03      �C�����e : ����f�[�^�o�͕�����g���Ή�
//                                      �@�A�g�f�[�^�̕i���S�p�����𔼊p�X�y�[�X�ɕϊ����鏈���������A���̕i���̂܂ܑ��M����
//                                      �A�A�g�f�[�^�̏��i���̃J�i�����ݒ�̏ꍇ�A���i���̂�ݒ肷��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Broadleaf.Application.Resources;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ����f�[�^�e�L�X�g�o�͂Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2019/12/02</br>
    /// </remarks>
    public class SalesCprtAcs
    {
        #region �� Constructor
        /// <summary>
        /// ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public SalesCprtAcs()
        {
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._iSalesCprtWorkDB = (ISalesCprtWorkDB)MediationSalesCprtResultDB.GetSalesCprtWorkDB();

            //�`�[����ݒ�}�X�^���X�g�̎擾
            _slipPrtSetAcs = new SlipPrtSetAcs();

            _custSlipMngAcs = new CustSlipMngAcs();

            _slipTypeController = new SlipTypeController();

            //�`�[����ݒ�}�X�^���X�g
            ArrayList slipPrtSetList;

            _slipPrtSetAcs.SearchSlipPrtSet(out slipPrtSetList, this._enterpriseCode);

            //���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g
            int totalCount;
            _custSlipMngAcs.SearchOnlyCustSlipMng(out totalCount, this._enterpriseCode);

            _slipTypeController.EnterpriseCode = this._enterpriseCode;
            _slipTypeController.SlipPrtSetList = GetSlipPrtSet(slipPrtSetList);
            _slipTypeController.CustSlipMngList = GetCustSlipMng(_custSlipMngAcs.CustSlipMngList);
            ReadMaker(this._enterpriseCode);
            GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

        }

        /// <summary>
        /// ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        static SalesCprtAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }
        #endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			            // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X

        #region API��`
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        #endregion
        #endregion �� Static Member

        #region �� Private Member
        ISalesCprtWorkDB _iSalesCprtWorkDB;

        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _salesHistoryDt;			// ���DataTable

        private const string ZERO = "0";
        private const string ONE = "1";
        private const string TWO = "2";
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";
        private const int ERROR_SUCCESS = 0;
        private const int SUPPLIERCD = 0;

        /// <summary>���O���b�Z�[�W�F���M�Ώۃf�[�^����</summary>
        private const string LOGMSG_NODATA = "�Y������f�[�^�͂���܂���";
        /// <summary>���O���b�Z�[�W�F���M�����G���[</summary>
        private const string LOGMSG_ERROR = "���M�����G���[";
        /// <summary>���O���b�Z�[�W�FJava�o�[�W�����G���[</summary>
        private const string LOGMSG_JAVAVERERR = "Java�̃o�[�W�������Â��ׁA���s�ł��܂���B�o�[�W����5.0�ȏ��Java���C���X�g�[�����ĉ������B";
        /// <summary>���O���b�Z�[�W�F�ʐM�G���[</summary>
        private const string LOGMSG_SENDERR = "�ʐM�G���[";
        /// <summary>���O���b�Z�[�W�F���[�U�[�ƃp�X���[�h�s��</summary>
        private const string LOGMSG_USERERR = "���[�U�[�ƃp�X���[�h�s��";
        /// <summary>���O���b�Z�[�W�F�^�C���A�E�g�G���[</summary>
        private const string LOGMSG_TIMEOUTERR = "�^�C���A�E�g�G���[";
        /// <summary>���O���b�Z�[�W�F�ʐM�G���[�␳</summary>
        private const string LOGMSG_SENDADDERR = "(Code:";
        /// <summary>���O���b�Z�[�W�F�\�z�O�̃G���[</summary>
        private const string LOGMSG_UNEXPECTEDERR = "�\�����ʗ�O���������܂����B(Code:-999)";
        private const string LOGMSG_RETRYCNT = "(Retry)";

        private const string CtWebSendError = "�A�g��ւ̑��M�Ɏ��s���܂����B";
        private const string CtRequestError = "�C���^�[�l�b�g����ڑ��Ɏ��s���܂����B";
        private const string CtWebError = "�A�g��ւ̃��N�G�X�g���M�Ɏ��s���܂����B";
        private const string CtHeaderError = "���擾�����Ɏ��s���܂����B";
        private const string CtWSSETokenError = "�A�g��Ƃ̔F�؏��擾�Ɏ��s���܂����B";
        private const string CtDigestError = "�Í��������Ɏ��s���܂����B";
        private const string CtResponseError = "�A�g��̌��ʎ�M�Ɏ��s���܂����B";
        private const string CtConnectError = "�A�g��ւ̐ڑ��Ɏ��s���܂����B";
        // �v���O����ID
        private const string CtPGID = "PMSDC02015A";
        /// <summary> XML�t�@�C������ </summary>
        private const string XML_FILE_NAME = "PMSDC02015A_RetryWaitTimeSetting.xml";
        private DataSet UiDataSet;

        /// <summary>���M�����i�J�n�j</summary>
        private long _sendDateTimeStart;
        /// <summary>���M�����i�I���j</summary>
        private long _sendDateTimeEnd;
        /// <summary>���M�`�[����</summary>
        private int _sendSlipCount;
        /// <summary>���M�`�[���א�</summary>
        private int _sendSlipDtlCnt;
        /// <summary>���M�`�[���v���z</summary>
        private long _sendSlipTotalMny;

        /// <summary>���M�����i�I���j</summary>
        public long SendDateTimeEnd
        {
            set { this._sendDateTimeEnd = value; }
            get { return this._sendDateTimeEnd; }
        }

        private SlipPrtSetAcs _slipPrtSetAcs = null;

        private CustSlipMngAcs _custSlipMngAcs = null;

        private SlipTypeController _slipTypeController = null;

        private ArrayList _resultWorkClone;
        // ���[�J�[�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;

        // ���[�J�[�f�[�^�i�[�p
        private static Hashtable _makerListStc = null;

        //�ڑ����}�X�^
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs = null;
        private HttpWebRequest request = null;
        // �[���ݒ�
        private PosTerminalMg _posTerminalMg = null;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ���_�R�[�h
        private string _sectionCode = "";

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataTable SalesHistoryDt
        {
            get { return this._salesHistoryDt; }
        }
        #endregion �� Public Property

        #region �� Public Method
        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <param name="salesCprtCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="connectInfoWork">�ڑ����</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public int SearchSalesHistoryProcMain(SalesCprtCndtnWork salesCprtCndtn, out string errMsg, SalCprtConnectInfoWork connectInfoWork)
        {
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //return this.SearchSalesHistoryProc(salesCprtCndtn, out errMsg);
            return this.SearchSalesHistoryProc(salesCprtCndtn, out errMsg, connectInfoWork);
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        }

        /// <summary>
        /// ����f�[�^���o����
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public DataTable GetprintdataTable()
        {
            DataView printdataView;
            DataTable printdataTable = null;

            if (this._salesHistoryDt != null && this._salesHistoryDt.Rows.Count > 0)
            {
                // DataView�쐬
                printdataView = new DataView(this._salesHistoryDt, string.Empty, GetSortOrder(), DataViewRowState.CurrentRows);

                // DataTable Create ----------------------------------------------------------
                PMSDC02014EA.CreatePrintDataTable(ref printdataTable);

                //�O�񋒓_�R�[�h
                string befSectionCode = string.Empty;
                //�O�񓾈Ӑ溰��
                string befCustomerCode = string.Empty;

                List<List<DataRowView>> tempList = new List<List<DataRowView>>();
                List<DataRowView> temp = new List<DataRowView>();

                for (int i = 0; i < printdataView.Count; i++)
                {
                    DataRowView dataRowView = (DataRowView)printdataView[i];

                    if ((string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        || (!befSectionCode.Equals(dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSDC02014EA.ct_Col_CustomerCode]))))
                    {
                        if (string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        {
                            temp.Add(dataRowView);
                        }

                        if ((!string.IsNullOrEmpty(befSectionCode) && (!string.IsNullOrEmpty(befCustomerCode)))
                            && (!befSectionCode.Equals(dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSDC02014EA.ct_Col_CustomerCode]))))
                        {
                            tempList.Add(temp);

                            temp = new List<DataRowView>();

                            temp.Add(dataRowView);
                        }
                        else if ((!string.IsNullOrEmpty(befSectionCode)) && (!string.IsNullOrEmpty(befCustomerCode)))
                        {
                            temp.Add(dataRowView);
                        }

                        befSectionCode = dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF].ToString();

                        befCustomerCode = dataRowView[PMSDC02014EA.ct_Col_CustomerCode].ToString();

                    }
                    else
                    {
                        temp.Add(dataRowView);
                    }

                    if (i == (printdataView.Count - 1))
                    {
                        tempList.Add(temp);
                    }
                }

                foreach (List<DataRowView> detailList in tempList)
                {
                    //�O�񔄏�`�[�ԍ�
                    string befSalesSlipNum = string.Empty;

                    DataRow dr = printdataTable.NewRow();

                    //�`�[����
                    int slipCountSum = 0;
                    //���㍇�v
                    long salesMoneySum = 0;
                    //�l���\��z
                    long salesSupplierMoneySum = 0;

                    //�s��
                    int pureCount = 0;

                    for (int j = 0; j < detailList.Count; j++)
                    {
                        DataRowView detailView = (DataRowView)detailList[j];

                        //�`�[����
                        string salesSlipNum = detailView[PMSDC02014EA.ct_Col_SalesSlipNum].ToString();
                        if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                        {
                            slipCountSum++;
                        }
                        befSalesSlipNum = salesSlipNum;

                        //���㍇�v
                        salesMoneySum += Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);

                        //�l���\��z
                        long salesMoneyDetail = Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                        long supplierMoneyDetail = Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSupplierMoney]);
                        salesSupplierMoneySum += (salesMoneyDetail - supplierMoneyDetail);
                        //�s��
                        pureCount++;
                    }
                    dr[PMSDC02014EA.ct_Col_CustomerCode] = detailList[0][PMSDC02014EA.ct_Col_CustomerCode];
                    dr[PMSDC02014EA.ct_Col_SectionCodeRF] = detailList[0][PMSDC02014EA.ct_Col_SectionCodeRF];
                    dr[PMSDC02014EA.ct_Col_SectionGuideSnm] = detailList[0][PMSDC02014EA.ct_Col_SectionGuideSnm];
                    dr[PMSDC02014EA.ct_Col_CustomerSnm] = detailList[0][PMSDC02014EA.ct_Col_CustomerSnm];
                    dr[PMSDC02014EA.ct_Col_SlipCountSum] = slipCountSum.ToString();
                    dr[PMSDC02014EA.ct_Col_SalesMoneySum] = salesMoneySum.ToString();
                    dr[PMSDC02014EA.ct_Col_SalesSupplierMoneySum] = salesSupplierMoneySum.ToString();
                    dr[PMSDC02014EA.ct_Col_PureCount] = pureCount.ToString();

                    printdataTable.Rows.Add(dr);
                }
            }
            else
            {
                printdataTable = new DataTable();
            }

            return printdataTable;
        }

        /// <summary>
        /// ���㒊�o�f�[�^�X�V����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Write(out string errMsg)
        {
            return this.WriteProc(this._resultWorkClone, out errMsg);
        }
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesCprtCndtn"></param>
        /// <param name="errMsg"></param>
        /// <param name="connectInfoWork"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private int SearchSalesHistoryProc(SalesCprtCndtnWork salesCprtCndtn, out string errMsg, SalCprtConnectInfoWork connectInfoWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SalCprtSndLogListResultWork salCprtSndLogWork = new SalCprtSndLogListResultWork();

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSDC02014EA.CreateDataTable(ref this._salesHistoryDt);

                // �f�[�^�擾  ----------------------------------------------------------------
                object salesHistoryResultWork = null;
                status = _iSalesCprtWorkDB.Search(out salesHistoryResultWork, (object)salesCprtCndtn);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList salesHistoryResultList = salesHistoryResultWork as ArrayList;

                        //�f�[�^��Convert���� 
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        //status = GetSalesHistoryData(salesCprtCndtn, salesHistoryResultList);
                        status = GetSalesHistoryData(salesCprtCndtn, salesHistoryResultList, connectInfoWork);
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                        // �`�[�����A���ז����A���v���z�̌v�Z
                        CalcuSalseInfo();

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            errMsg = "�Y������f�[�^������܂���B";
                            // ���M���O��o�^
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                            logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, 2, LOGMSG_NODATA);
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "�Y������f�[�^������܂���B";
                        //���M���O�̓o�^
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, 2, LOGMSG_NODATA);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        errMsg = "�f�[�^���o�����Ɏ��s���܂����B";
                        //���M���O�̓o�^
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                        break;
                    default:
                        errMsg = "�f�[�^���o�����Ɏ��s���܂����B";
                        //���M���O�̓o�^
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, -1, LOGMSG_ERROR);
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //���M���O�̓o�^
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            }
            return status;
        }
        #endregion

        #region �� �\�[�g���쐬
        /// <summary>
        /// �\�[�g���쐬
        /// </summary>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g������̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetSortOrder()
        {
            StringBuilder strSortOrder = new StringBuilder();

            strSortOrder.Append(string.Format("{0} ASC,", PMSDC02014EA.ct_Col_SectionCodeRF));
            strSortOrder.Append(string.Format("{0} ASC,", PMSDC02014EA.ct_Col_CustomerCode));
            strSortOrder.Append(string.Format("{0} ASC", PMSDC02014EA.ct_Col_SalesSlipNum));

            return strSortOrder.ToString();
        }
        #endregion

        #region �� ���㒊�o�f�[�^�X�V����
        /// <summary>
        /// ���㒊�o�f�[�^�X�V
        /// </summary>
        /// <param name="resultWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���㒊�o�f�[�^���X�V����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int WriteProc(ArrayList resultWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = string.Empty;

            object objectresultWork = resultWork as object;

            if (resultWork != null && resultWork.Count > 0)
            {
                // �������ݏ���
                status = this._iSalesCprtWorkDB.Write(ref objectresultWork);
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errMsg = "���㒊�o�f�[�^�X�V�����Ɏ��s���܂����B";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }
        #region ReadMaker
        /// <summary>
        /// ���[�J�[�f�[�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^����S���擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int ReadMaker(string enterpriseCode)
        {
            _makerListStc = new Hashtable();

            if (this._makerAcs == null)
            {
                // ���[�J�[�A�N�Z�X�N���X
				this._makerAcs = new MakerAcs();
            }
            ArrayList makerList;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this._makerAcs.SearchAll(out makerList, enterpriseCode);

            if ((status == 0) && (makerList.Count > 0))
            {
                foreach (MakerUMnt makerUMnt in (ArrayList)makerList)
                {
                    //---------------------------------
                    // Key  �F���[�J�[�R�[�h
                    // Value�F���[�J�[����
                    //---------------------------------
                    _makerListStc.Add(makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
                }
            }
            return status;
        }
        #endregion ReadMaker

        #region ���[�J�[���̎擾
        /// <summary>
        /// ���[�J�[���̎擾
        /// </summary>
        /// <remarks>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public string GetMakerName(int goodsMakerCd)
        {
            string retStr = "";

            if ((_makerListStc != null) && (_makerListStc.ContainsKey(goodsMakerCd) == true))
            {
                retStr = _makerListStc[goodsMakerCd].ToString();
            }
            return retStr;
        }
        #endregion

        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �擾�f�[�^�W�J����
        #endregion �� �f�[�^�W�J����

        #region �� ���[�ݒ�f�[�^�擾
        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�ݒ�f�[�^�擾

        /// <summary>
        /// �擾�f�[�^����
        /// </summary>
        /// <param name="salesCprtCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <param name="connectInfoWork">�ڑ����</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private int GetSalesHistoryData(SalesCprtCndtnWork salesCprtCndtn, ArrayList resultWork, SalCprtConnectInfoWork connectInfoWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            //���㒊�o�f�[�^�X�V�p
            _resultWorkClone = new ArrayList();

            foreach (SalesCprtWork salesCprtWork in resultWork)
            {
                //���M�敪(0:�蓮;1:����)
                if (salesCprtCndtn.SendDataDiv == 0)
                {
                    //���㒊�o�f�[�^�Ƀ��R�[�h�����݂��Ȃ�
                    if (salesCprtCndtn.PdfOutDiv == 0)
                    {
                        if ((salesCprtWork.SEAcptAnOdrStatus == 0
                            && string.IsNullOrEmpty(salesCprtWork.SEEnterpriseCode)
                            && salesCprtWork.SESalesCreateDateTime == 0
                            && string.IsNullOrEmpty(salesCprtWork.SESalesSlipNum)) ||
                            (salesCprtWork.SEAcptAnOdrStatus != 0
                            && salesCprtWork.SESalesCreateDateTime != salesCprtWork.SalesUpdateDateTime))
                        {
                            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                            //ConvertSalesHistoryData(salesCprtWork);
                            ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                            _resultWorkClone.Add(salesCprtWork);
                        }
                    }
                    //���㒊�o�f�[�^�Ƀ��R�[�h�����݂���
                    else if (salesCprtCndtn.PdfOutDiv == 1)
                    {
                        if (salesCprtWork.SEAcptAnOdrStatus != 0
                            && !string.IsNullOrEmpty(salesCprtWork.SEEnterpriseCode)
                            && salesCprtWork.SESalesCreateDateTime == salesCprtWork.SalesUpdateDateTime
                            && !string.IsNullOrEmpty(salesCprtWork.SESalesSlipNum))
                        {
                            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                            //ConvertSalesHistoryData(salesCprtWork);
                            ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                            _resultWorkClone.Add(salesCprtWork);
                        }

                    }
                    //�S�āi���㒊�o�f�[�^�Ɉˑ����Ȃ��j
                    else
                    {
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                        //ConvertSalesHistoryData(salesCprtWork);
                        ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                        _resultWorkClone.Add(salesCprtWork);
                    }
                }
                else
                {
                    //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
                    //ConvertSalesHistoryData(salesCprtWork);
                    ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                    //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

                    _resultWorkClone.Add(salesCprtWork);
                }
            }

            if (_resultWorkClone.Count == 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// �擾�f�[�^Convert����
        /// </summary>
        /// <param name="salesCprtWork">�擾�f�[�^</param>
        /// <param name="connectInfoWork">�ڑ����</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�   : 11570219-00</br>
        /// <br>           :�i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// <br>Update Note: 2020/09/15 3H ����</br>
        /// <br>�Ǘ��ԍ�   : 11670214-00</br>
        /// <br>           : ����f�[�^�o�͕�����g���Ή�</br>
        /// </remarks>
        private void ConvertSalesHistoryData(SalesCprtWork salesCprtWork, SalCprtConnectInfoWork connectInfoWork)
        {
            DataRow dr = _salesHistoryDt.NewRow();

            //AB�`�[��
            dr[PMSDC02014EA.ct_Col_SalesSlipNum] =salesCprtWork.SalesSlipNum;
            //�����`�[�ԍ�
            dr[PMSDC02014EA.ct_Col_DebitNLnkSalesSlNum] = salesCprtWork.DebitNLnkSalesSlNum;
            //�����敪
            if (salesCprtWork.SalesSlipCd == 0)
            {
                dr[PMSDC02014EA.ct_Col_RequestDiv] = "010";
            }
            else if (salesCprtWork.SalesSlipCd == 1)
            {
                dr[PMSDC02014EA.ct_Col_RequestDiv] = "020";
            }

            //�����
            dr[PMSDC02014EA.ct_Col_AddUpADate] = salesCprtWork.AddUpADate.ToString("yyyyMMdd");

            //�����D�ǋ敪
            int goodsMakerCd = salesCprtWork.GoodsMakerCd;
            dr[PMSDC02014EA.ct_Col_GoodDiv] = GetGoodDiv(goodsMakerCd);

            //AB���㗦
            dr[PMSDC02014EA.ct_Col_AbSalesRate] = "0000";

            //�s��
            dr[PMSDC02014EA.ct_Col_SalesRowNo] = DataNoSubStr(4, salesCprtWork.SalesRowNo.ToString("d4"));

            //�Ǘ���
            bool flag = GetBlEffective(salesCprtWork.CustomerCode);

            if (flag == true)
            {
                dr[PMSDC02014EA.ct_Col_AdministrationNo] = DataNoSubStr(4, salesCprtWork.PrtBLGoodsCode.ToString("d4"));
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_AdministrationNo] = "0000";
            }

            //�Ǘ����́i�i�ԁj
            dr[PMSDC02014EA.ct_Col_GoodsNo] = GetCharFormat(salesCprtWork.GoodsNo);

            //�i��
            // dr[PMSDC02014EA.ct_Col_GoodsNameKana] = DataNoSubStr(100,GetGoodsNameCharFormat(salesCprtWork.GoodsNameKana)); // 2020/09/15 3H ���� DEL
            dr[PMSDC02014EA.ct_Col_GoodsNameKana] = DataNoSubStr(100, GetGoodsNameCharFormat(salesCprtWork.GoodsNameKana, salesCprtWork.GoodsName)); // 2020/09/15 3H ���� ADD

            //BL���i���� 20191216�[���T�v���X�˗�
            //dr[PMSDC02014EA.ct_Col_BLGoodsCode] = DataNoSubStr(5, salesCprtWork.BLGoodsCode.ToString("d5"));
            dr[PMSDC02014EA.ct_Col_BLGoodsCode] = DataNoSubStr(5, salesCprtWork.BLGoodsCode.ToString("G0"));

            //����
            dr[PMSDC02014EA.ct_Col_ShipmentCnt] = GetShipmentCnt(salesCprtWork.ShipmentCnt);

            //�[���P��
            dr[PMSDC02014EA.ct_Col_SalesUnPrcTaxExcFl] = salesCprtWork.SalesUnPrcTaxExcFl.ToString("0000000.00");

            //�[�����z
            dr[PMSDC02014EA.ct_Col_SalesMoneyTaxExc] = GetNumFormat(salesCprtWork.SalesMoneyTaxExc);

            //PDF�p�[�����z
            dr[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc] = GetNumRound(salesCprtWork.SalesMoneyTaxExc);

            //�d�����z
            dr[PMSDC02014EA.ct_Col_SupplierMoney] = GetNumFormat(salesCprtWork.SalesUnPrcTaxExcFl);

            //PDF�p�d�����z
            dr[PMSDC02014EA.ct_Col_PdfSupplierMoney] = GetNumFormat(salesCprtWork.SalesUnPrcTaxExcFl);

            //������z
            dr[PMSDC02014EA.ct_Col_SalesMoney] = "00000000";

            //�o��敪
            dr[PMSDC02014EA.ct_Col_ExpenseDivCd] = "0";

            //���Ӑ溰��
            dr[PMSDC02014EA.ct_Col_CustomerCode] = salesCprtWork.CustomerCode.ToString("d8");

            //�����ްĂx�l�c
            dr[PMSDC02014EA.ct_Col_SearchSlipDate] = salesCprtWork.SearchSlipDate.ToString("yyyyMMdd");

            //�d����R�[�h
            dr[PMSDC02014EA.ct_Col_SupplierCd] = salesCprtWork.SupplierCd.ToString("d8");

            //���[�J�[�R�[�h
            dr[PMSDC02014EA.ct_Col_GoodsMakerCd] = DataNoSubStr(4, salesCprtWork.GoodsMakerCd.ToString("d4"));

            //�n�溰��
            dr[PMSDC02014EA.ct_Col_AreaCd] = "0";

            //�e�h�k�k�d�q
            dr[PMSDC02014EA.ct_Col_Filler] = " ";

            //���_�R�[�h
            dr[PMSDC02014EA.ct_Col_SectionCodeRF] = salesCprtWork.ResultsAddUpSecCd;

            // ���_�K�C�h����
            string sectionGuideSnm = "";
            if (string.IsNullOrEmpty(salesCprtWork.SectionGuideSnm))
            {
                sectionGuideSnm = "���o�^";
            }
            else
            {
                sectionGuideSnm = salesCprtWork.SectionGuideSnm;
            }
            dr[PMSDC02014EA.ct_Col_SectionGuideSnm] = sectionGuideSnm;

            // ���Ӑ旪��
            string customerSnm = "";
            if (string.IsNullOrEmpty(salesCprtWork.CustomerSnm))
            {
                customerSnm = "���o�^";
            }
            else
            {
                customerSnm = salesCprtWork.CustomerSnm;
            }
            dr[PMSDC02014EA.ct_Col_CustomerSnm] = customerSnm;

            // �`�[���l
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //dr[PMSDC02014EA.ct_Col_SlipNote] = DataNoSubStr(30,salesCprtWork.SlipNote);
            long partySalesLipNum_lng = 0;
            string partySalesLipNum = string.Empty;
            if (long.TryParse(salesCprtWork.PartySalesLipNum, out partySalesLipNum_lng))
            {
                partySalesLipNum = partySalesLipNum_lng.ToString("G0");
            }
            else
            {
                partySalesLipNum = salesCprtWork.PartySalesLipNum;
            }

            if (connectInfoWork.Note1SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = partySalesLipNum;
            }
            else if (connectInfoWork.Note1SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = DataNoSubStr(30, salesCprtWork.SlipNote);
            }
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

            // �`�[���l2
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //dr[PMSDC02014EA.ct_Col_SlipNote2] = DataNoSubStr(30, salesCprtWork.SlipNote2);
            if (connectInfoWork.Note2SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = partySalesLipNum;
            }
            else if (connectInfoWork.Note2SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = DataNoSubStr(30, salesCprtWork.SlipNote2);
            }
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            
            // �`�[���l3
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //dr[PMSDC02014EA.ct_Col_SlipNote3] = DataNoSubStr(30, salesCprtWork.SlipNote3);
            if (connectInfoWork.Note3SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = partySalesLipNum;
            }
            else if (connectInfoWork.Note3SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = DataNoSubStr(30, salesCprtWork.SlipNote3);
            }
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

            // �X�V����
            dr[PMSDC02014EA.ct_Col_UpDate] = Convert.ToInt64(salesCprtWork.UpdateDateTime.ToString("yyyyMMddHHmmss"));
            // �`�[�敪
            dr[PMSDC02014EA.ct_Col_SalesSlipCd] = salesCprtWork.SalesSlipCd.ToString("d2");
            // ���[�J�[��
            dr[PMSDC02014EA.ct_Col_MakerName] = DataNoSubStr(30, GetMakerName(salesCprtWork.GoodsMakerCd));

            _salesHistoryDt.Rows.Add(dr);
        }

        /// <summary>
        /// ��n���̎擾����
        /// </summary>
        /// <param name="index">���o����</param>
        /// <param name="DataNo">�`�[�ԍ�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :��n���̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string DataNoSubStr(int index, string DataNo)
        {
            string DataNum = DataNo;

            // ��n���̂݁F������n���݂̂��擾
            if (DataNo.Length > index)
            {
                DataNum = DataNo.Substring((DataNo.Length - index), index);
            }
            return DataNum;
        }

        /// <summary>
        /// �����D�ǋ敪�̎擾����
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>�����D�ǋ敪</returns>
        /// <remarks>
        /// <br>Note       : �����D�ǋ敪�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetGoodDiv(int goodsMakerCd)
        {
            string DataNum = ONE;

            if (goodsMakerCd > 0)
            {
                if ((1 <= goodsMakerCd) && (99 >= goodsMakerCd))
                {
                    DataNum = ONE;
                }
                else
                {
                    DataNum = TWO;
                }
            }

            return DataNum;
        }


        /// <summary>
        /// BL���i�R�[�h�̈󎚗L���̎擾����
        /// </summary>
        /// <param name="customerCode">BL���i�R�[�h</param>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : BL���i�R�[�h�̈󎚗L���̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private bool GetBlEffective(int customerCode)
        {
            bool flag = false;
            SlipPrtSet slipPrtSet;
            SlipTypeController.SlipKind slipKind = SlipTypeController.SlipKind.SalesSlip;
            _slipTypeController.GetSlipType(slipKind, out slipPrtSet, _sectionCode, customerCode);

            if (ZERO.Equals(slipPrtSet.EachSlipTypeColPrt2.ToString()))
            {
                flag = false;
            }
            else if (ONE.Equals(slipPrtSet.EachSlipTypeColPrt2.ToString()))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// �S�p�����̎擾����
        /// </summary>
        /// <param name="data">�i��</param>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �S�p�����̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetCharFormat(string data)
        {
            string s;

            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(data))
            {
                char[] datachar = data.ToCharArray();

                foreach (char c in datachar)
                {
                    if (2 * c.ToString().Length == Encoding.Default.GetByteCount(c.ToString()))
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            if (sb.ToString().Length > 16)
            {
                s = sb.ToString().Substring(0, 16);
            }
            else
            {
                s = sb.ToString();
            }

            return s;

        }

        // 2020/09/15 3H ���� DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �S�p�����̎擾����
        ///// </summary>
        ///// <param name="data">�i��</param>
        ///// <returns>�L��</returns>
        ///// <remarks>
        ///// <br>Note       : �S�p�����̎擾�������s���܂��B</br>
        ///// <br>Programmer : �c����</br>
        ///// <br>Date       : 2019/12/02</br>
        ///// </remarks>
        //private string GetGoodsNameCharFormat(string data)
        //{
        //    string s;

        //    StringBuilder sb = new StringBuilder();

        //    if (!String.IsNullOrEmpty(data))
        //    {
        //        char[] datachar = data.ToCharArray();

        //        foreach (char c in datachar)
        //        {
        //            if (2 * c.ToString().Length == Encoding.Default.GetByteCount(c.ToString()))
        //            {
        //                sb.Append(" ");
        //            }
        //            else
        //            {
        //                sb.Append(c);
        //            }
        //        }
        //    }

        //    s = sb.ToString();

        //    return s;

        //}
        // 2020/09/15 3H ���� DEL END   <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2020/09/15 3H ���� ADD START >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i����
        /// </summary>
        /// <param name="GoodsNameKana">���i���̃J�i</param>
        /// <param name="GoodsName">���i����</param>
        /// <returns>���i����</returns>
        private string GetGoodsNameCharFormat(string GoodsNameKana, string GoodsName)
        {
            // ���i���̃J�i���ݒ�̏ꍇ�A���i���̂��o��
            if (String.IsNullOrEmpty(GoodsNameKana))
            {
                return GoodsName;
            }
            return GoodsNameKana;

        }
        // 2020/09/15 3H ���� ADD END   <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �o�א��}�C�i�X�l�̏ꍇ�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �o�א��}�C�i�X�l�̏ꍇ�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetShipmentCnt(Double data)
        {
            string result;

            if (data < 0)
            {
                result = data.ToString("00000000.00");
            }
            else
            {
                result = data.ToString("000000000.00");
            }

            return result;
        }

        /// <summary>
        /// �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetNumFormat(Double data)
        {
            long numFormat;
            string result;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0)
            {
                if (numFormat.ToString().Length > 10)
                {
                    numFormat = Convert.ToInt64(DataNoSubStr(9, numFormat.ToString())) * (-1);

                    result = numFormat.ToString("d9");
                }
                else
                {
                    result = numFormat.ToString("d9");
                }
            }
            else
            {
                result = DataNoSubStr(10, numFormat.ToString("d10"));
            }

            return result;
        }

        /// <summary>
        /// �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetNumRound(Double data)
        {
            long numFormat;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            return numFormat.ToString();
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�̎擾����
        /// </summary>
        /// <returns>���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private List<CustSlipMng> GetCustSlipMng(ArrayList inputList)
        {
            List<CustSlipMng> resulrList = new List<CustSlipMng>();

            foreach (CustSlipMng custSlipMng in inputList)
            {
                resulrList.Add(custSlipMng);
            }

            return resulrList;
        }

        /// <summary>
        /// �`�[����ݒ�}�X�^���X�g�̎擾����
        /// </summary>
        /// <returns>�`�[����ݒ�}�X�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ݒ�}�X�^���X�g�̎擾�������s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private List<SlipPrtSet> GetSlipPrtSet(ArrayList inputList)
        {
            List<SlipPrtSet> resulrList = new List<SlipPrtSet>();

            foreach (SlipPrtSet slipPrtSet in inputList)
            {
                resulrList.Add(slipPrtSet);
            }

            return resulrList;
        }

        #region [�������M]
        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="salesCprtCndtn">����</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="salCprtSndLogWork">���M���O���</param>
        /// <param name="logStatus">���M���O�o�^�X�e�[�^�X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	   : Web�T�[�o�Ƒ���M���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        public int SendAndReceive(ref SalesCprtCndtnWork salesCprtCndtn, String fileName, out SalCprtSndLogListResultWork salCprtSndLogWork, out int logStatus) 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; 
            string xmlFileName = string.Empty;
            string logErrMsg = string.Empty;
            logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            salCprtSndLogWork = new SalCprtSndLogListResultWork();

            if (fileName.Contains("."))
            {
                int index = fileName.LastIndexOf(".");
                xmlFileName = fileName.Substring(0, index) + ".XML";
            }
            else 
            {
                xmlFileName = fileName + ".XML";
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
                }
                else
                {
                    //�Ȃ�
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesCprtCndtn.EnterpriseCode, SUPPLIERCD, salesCprtCndtn.SectionCode, salesCprtCndtn.CustomerCode);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
                return status;
            }

            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
                return status;
            }

            //String command = CommandOrganization(connectInfoWork, fileName);
            //if (string.IsNullOrEmpty(command) || command.Equals("<1.5.0"))
            //{
            //    status = -1;
            //    this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logErrMsg = LOGMSG_JAVAVERERR;
            //    //���M���O�̓o�^
            //    logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
            //    return status;
            //}

            bool errFlag = false;
            string errMsg = string.Empty;
            int retryCnt = connectInfoWork.RetryCnt;
            status = Send(connectInfoWork, xmlFileName, salesCprtCndtn, ref salCprtSndLogWork, ref errFlag, ref errMsg, retryCnt);

            return status;
        }

        /// <summary>
        /// Web�T�[�o�ɑ��M���܂��B
        /// </summary>
        /// <param name="connectInfoWork">����A�g�ڑ����</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="salesCprtCndtn">����</param>
        /// <param name="salCprtSndLogWork">���M���O���</param>
        /// <param name="errFlag">�G���[�t���O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	   : Web�T�[�o�ɑ��M�������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int Send(SalCprtConnectInfoWork connectInfoWork, String fileName, SalesCprtCndtnWork salesCprtCndtn, ref SalCprtSndLogListResultWork salCprtSndLogWork, ref bool errFlag, ref string errMsg, int retryCnt)
        {
            int status = -1;
            int logStatus = -1;
            string logErrMsg = string.Empty;
            string exErrMsg = string.Empty;
            string ret = string.Empty;
            try
            {
                SalesCprtAcsSendRequest sendRequest = new SalesCprtAcsSendRequest();
                ret = sendRequest.SendRequest(connectInfoWork, fileName, ref errFlag, ref errMsg, connectInfoWork.LoginTimeoutVal * 1000, retryCnt);

                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                if (errFlag)
                {
                    status = -1;
                }
                if (string.IsNullOrEmpty(ret))
                {
                    status = -1;
                    logErrMsg = LOGMSG_UNEXPECTEDERR;
                }
                else if (ret != "0")
                {
                    status = -1;
                    if ("10194062" == ret)
                    {
                        logErrMsg = LOGMSG_USERERR;
                    }
                    else if (ret == LOGMSG_TIMEOUTERR)
                    {
                        logErrMsg = LOGMSG_TIMEOUTERR;
                    }
                    else if (ret == "90101")
                    {
                        logErrMsg = CtWebSendError + LOGMSG_SENDADDERR + "90101)";
                        exErrMsg = CtWebSendError;
                    }
                    else if (ret == "90102")
                    {
                        logErrMsg = CtRequestError + LOGMSG_SENDADDERR + "90102)";
                        exErrMsg = CtRequestError;
                    }
                    else if (ret == "90103")
                    {
                        logErrMsg = CtWebError + LOGMSG_SENDADDERR + "90103)";
                        exErrMsg = CtWebError;
                    }
                    else if (ret == "90104")
                    {
                        logErrMsg = CtHeaderError + LOGMSG_SENDADDERR + "90104)";
                        exErrMsg = CtHeaderError;
                    }
                    else if (ret == "90105")
                    {
                        logErrMsg = CtWSSETokenError + LOGMSG_SENDADDERR + "90105)";
                        exErrMsg = CtWSSETokenError;
                    }
                    else if (ret == "90106")
                    {
                        logErrMsg = CtDigestError + LOGMSG_SENDADDERR + "90106)";
                        exErrMsg = CtDigestError;
                    }
                    else if (ret == "90107")
                    {
                        logErrMsg = CtResponseError + LOGMSG_SENDADDERR + "90107)";
                        exErrMsg = CtResponseError;
                    }
                    else if (ret == "90108")
                    {
                        logErrMsg = CtConnectError + LOGMSG_SENDADDERR + "90108)";
                        exErrMsg = CtConnectError;
                    }
                    else
                    {
                        logErrMsg = errMsg;
                    }
                }
                else
                {
                    status = 0;
                }

                // �G���[���e���t�@�C���ŏo�͂���
                if (status != 0)
                {
                    int intRet = 0;
                    if (int.TryParse(ret, out intRet))
                    {
                        LogWrite(intRet, exErrMsg, errMsg);
                    }
                }
            }
            catch (Exception exc)
            {
                exc.ToString();
                status = -1;
                //���M���O�̓o�^
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_UNEXPECTEDERR;
            }
            finally
            {
                if (retryCnt > 0)
                {
                    logErrMsg = logErrMsg + LOGMSG_RETRYCNT;
                }

                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);

                if (status == -1)
                {
                    if (retryCnt == 0)
                    {
                        ret = LOGMSG_TIMEOUTERR;
                    }
                    else
                    {
                        retryCnt = retryCnt - 1;
                        int waitTime = GetWaitTime();
                        Thread.Sleep(waitTime);
                        this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                        status = Send(connectInfoWork, fileName, salesCprtCndtn, ref salCprtSndLogWork, ref errFlag, ref errMsg, retryCnt);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// �҂����Ԏ擾
        /// </summary>
        /// <returns>waitTime</returns>
        /// <remarks>
        /// <br>Note	   : �҂����Ԃ��擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>			
        /// </remarks>
        public int GetWaitTime()
        {
            int waitTime = 5000;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (UiDataSet == null)
                    {
                        UiDataSet = new DataSet();
                    }
                    UiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    waitTime = Convert.ToInt32(UiDataSet.Tables["RetryWaitTimeInfo"].Rows[0][0]);
                }
            }
            catch
            {
                waitTime = 5000;
            }
            return waitTime;
        }

        /// <summary>
        /// �`�[�����A���א��A���㍇�v�̌v�Z
        /// </summary>
        /// <remarks>
        /// <br>Note		: �`�[�����A���א��A���㍇�v�̌v�Z���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>		
        /// </remarks>
        private void CalcuSalseInfo()
        {
            DataView printdataView;
            this._sendSlipCount = 0;
            this._sendSlipDtlCnt = 0;
            this._sendSlipTotalMny = 0;

            if (this._salesHistoryDt != null && this._salesHistoryDt.Rows.Count > 0)
            {
                //�`�[����
                int slipCountSum = 0;
                //���א�
                int detailCount = 0;
                //���㍇�v
                long salesMoneySum = 0;

                //�O�񔄏�`�[�ԍ�
                string befSalesSlipNum = string.Empty;

                // DataView�쐬
                printdataView = new DataView(this._salesHistoryDt, string.Empty, GetSortOrder(), DataViewRowState.CurrentRows);

                for (int i = 0; i < printdataView.Count; i++)
                {
                    DataRowView detailView = (DataRowView)printdataView[i];

                    //�`�[����
                    string salesSlipNum = detailView[PMSDC02014EA.ct_Col_SalesSlipNum].ToString();
                    if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                    {
                        slipCountSum++;
                    }
                    befSalesSlipNum = salesSlipNum;

                    //���א�
                    detailCount++;

                    //���㍇�v
                    salesMoneySum += Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                }

                this._sendSlipCount = slipCountSum;
                this._sendSlipDtlCnt = detailCount;
                this._sendSlipTotalMny = salesMoneySum;
            }
        }

        /// <summary>
        /// ���M���O���̓o�^
        /// </summary>
        /// <param name="salesCprtCndtn">��������</param>
        /// <param name="salCprtSndLogWork">���M���O���</param>
        /// <param name="sendResult">���M�̖߂����X�e�[�^�X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>		
        /// </remarks>
        public int WriteLogInfo(SalesCprtCndtnWork salesCprtCndtn, ref SalCprtSndLogListResultWork salCprtSndLogWork, int sendResult, string errMsg)
        {
            int status = -1;

            //���M���O�̍쐬
            salCprtSndLogWork = MakeLogInfo(salesCprtCndtn, sendResult, errMsg);
            object obj = salCprtSndLogWork;

            //���M���O�̓o�^
            status = _iSalesCprtWorkDB.WriteLog(ref obj);
            salCprtSndLogWork = obj as SalCprtSndLogListResultWork;

            return status;
        }

        /// <summary>
        /// ���M���O���̍쐬
        /// </summary>
        /// <param name="salesCprtCndtn">��������</param>
        /// <param name="sendResult">���M�̖߂����X�e�[�^�X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���M���O���</returns>
        /// <remarks>
        /// <br>Note		: ���M���O�����쐬���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private SalCprtSndLogListResultWork MakeLogInfo(SalesCprtCndtnWork salesCprtCndtn, int sendResult, string errMsg)
        {
            SalCprtSndLogListResultWork salCprtSndLogWork = new SalCprtSndLogListResultWork();
            // ��ƃR�[�h
            salCprtSndLogWork.EnterpriseCode = this._enterpriseCode;
            // �_���폜�敪
            salCprtSndLogWork.LogicalDeleteCode = 0;
            // ���_�R�[�h
            salCprtSndLogWork.SectionCode = this._sectionCode;
            // ���M�����i�J�n�j
            salCprtSndLogWork.SendDateTimeStart = this._sendDateTimeStart;
            // ���M�����i�I���j
            salCprtSndLogWork.SendDateTimeEnd = this._sendDateTimeEnd;

            if (salesCprtCndtn.SendDataDiv == 0)
            {
                // ���M�ΏۊJ�n���t
                salCprtSndLogWork.SendObjDateStart = salesCprtCndtn.AddUpADateSt;
                // ���M�ΏۏI�����t
                salCprtSndLogWork.SendObjDateEnd = salesCprtCndtn.AddUpADateEd;
                // �������M�敪
                salCprtSndLogWork.SAndEAutoSendDiv = 0;
                // ���M�Ώۓ��Ӑ�i�J�n�j
                salCprtSndLogWork.SendObjCustStart = salesCprtCndtn.CustomerCode;
                // ���M�Ώۓ��Ӑ�i�I���j
                salCprtSndLogWork.SendObjCustEnd = salesCprtCndtn.CustomerCode;
                // ���M�Ώۋ敪
                salCprtSndLogWork.SendObjDiv = salesCprtCndtn.PdfOutDiv; 
            }
            else
            {
                // ���M�ΏۊJ�n���t
                salCprtSndLogWork.SendObjDateStart = salesCprtCndtn.SalesInfoTimeSt;
                // ���M�ΏۏI�����t
                salCprtSndLogWork.SendObjDateEnd = salesCprtCndtn.SalesInfoTimeEd;
                // �������M�敪
                salCprtSndLogWork.SAndEAutoSendDiv = 1;
                // ���M�Ώۓ��Ӑ�i�J�n�j
                salCprtSndLogWork.SendObjCustStart = salesCprtCndtn.CustomerCode;
                // ���M�Ώۓ��Ӑ�i�I���j
                salCprtSndLogWork.SendObjCustEnd = salesCprtCndtn.CustomerCode;
                // ���M�Ώۋ敪
                salCprtSndLogWork.SendObjDiv = salesCprtCndtn.AutoDataSendDiv;
            }


            if (sendResult == 0)
            {
                // ���M����
                salCprtSndLogWork.SendResults = 0;
                // ���M�G���[���e
                salCprtSndLogWork.SendErrorContents = string.Empty;
                // ���M�`�[����
                salCprtSndLogWork.SendSlipCount = this._sendSlipCount;
                // ���M�`�[���א�
                salCprtSndLogWork.SendSlipDtlCnt = this._sendSlipDtlCnt;
                // ���M�`�[���v���z
                salCprtSndLogWork.SendSlipTotalMny = this._sendSlipTotalMny;
            }
            else
            {
                // ���M����
                if (sendResult == 2) // ���M�f�[�^�Ȃ��̏ꍇ�A�X�e�[�^�X�́u2�v�ŌŒ�
                {
                    salCprtSndLogWork.SendResults = 2;
                }
                else
                {
                    salCprtSndLogWork.SendResults = 1;
                }
                // ���M�G���[���e
                salCprtSndLogWork.SendErrorContents = errMsg;
                // ���M�`�[����
                salCprtSndLogWork.SendSlipCount = 0;
                // ���M�`�[���א�
                salCprtSndLogWork.SendSlipDtlCnt = 0;
                // ���M�`�[���v���z
                salCprtSndLogWork.SendSlipTotalMny = 0;
            }

            return salCprtSndLogWork;
        }

        /// <summary>
        /// ���M�f�[�^�t�B�����̏������܂�
        /// </summary>
        /// <param name="value">�t�B����</param>
        /// <returns>���M�f�[�^�t�B����</returns>
        /// <remarks>
        /// <br>Note		: ���M�f�[�^�t�B�����̏������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>										
        /// </remarks>
        private String SetFileNm(String value)
        {
            if (String.IsNullOrEmpty(value))
                return "";
            if (value.Contains("."))
            {
                value = value.Substring(0, value.IndexOf('.'));
            }
            if (value.ToUpper().EndsWith(".TXT"))
            {
                return value;
            }
            else
            {
                return value + ".txt";
            }
        }

        /// <summary>
        /// �R�}���h�I�v�V�����̏������܂�
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����</param>
        /// <param name="fileName">���M�f�[�^�t�B����</param>
        /// <returns>�R�}���h</returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�I�v�V�����̏������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private String CommandOrganization(SalCprtConnectInfoWork connectInfoWork, String fileName)
        {
            String userName = connectInfoWork.SendCcnctUserid.Trim();
            String password = connectInfoWork.SendCcnctPass.Trim();
            String fileId = connectInfoWork.CnectFileId.Trim();
            String mode = "S";
            String logLevel = "2";
            int templength = fileName.Length;
            int tempof = fileName.LastIndexOf("\\");
            String dataName =SetFileNm( fileName.Substring(fileName.LastIndexOf("\\")+1 , (fileName.Length -1)- fileName.LastIndexOf("\\")));
            string httpHead = "";
            //HTTP/HTTPS �v���g�R��  
            httpHead = "https://";
            String connectURL = httpHead + connectInfoWork.CprtUrl;
            String dataPath = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT);

            String logName = GetLogName();
            bool verFlag = false;
            string errMsg = string.Empty; 
            String command = "";
            String version = RunCmd("java -version", ref verFlag, 0, errMsg, 2000, 0); 
            if (!verFlag)
            {
                if (String.CompareOrdinal(version, "\"1.5.0\"") >= 0)
                {
                    command = "Java dtrcmd";
                }
                else
                {
                    command = "<1.5.0";
                    return command;
                }

                command = "Java -cp dtrcmd.jar dtrcmd";
            }
            else
            {
                return command;
            }
            command = command + " -u " + ExchangeString(userName)
                              + " -p " + ExchangeString(password)
                              + " -m " + ExchangeString(mode)
                              + " -f " + ExchangeString(fileId)
                              + " -c " + ExchangeString(connectURL)
                              + " -d " + ExchangeString(dataPath + "\\" + dataName)
                              + " -o " + ExchangeString(logName)
                              + " -v " + ExchangeString(logLevel);
            return command;
             
        }

        /// <summary>
        /// DOS Command�����̓]��
        /// </summary>
        /// <param name="inputStr">����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�I�v�V�����̏������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private string ExchangeString(string inputStr)
        {
            string str = string.Empty;
            str = inputStr.Replace("\"", "\"\"\"");
            str = "\"" + str + "\"";

            return str;
        }

        /// <summary>
        /// �R�}���h�����s���܂��B
        /// </summary>
        /// <param name="command">�R�}���h</param>
        /// <param name="errFlag">�G���[�t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�����s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>										
        /// </remarks>
        private String RunCmd(String command,ref bool errFlag) 
        {
            string ret = null;
            string err = null;
            string otp = null;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
                otp = p.StandardOutput.ReadToEnd();
                err = p.StandardError.ReadToEnd();
                if (null == err || String.IsNullOrEmpty(err))
                {
                    errFlag = false;
                    string[] arr = Regex.Split(otp, "\r\n");
                    bool flg = false;
                    foreach (string str in arr)
                    {
                        if (flg)
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                ret = str;
                                break;
                            }
                        }
                        if (str.Contains("Java dtrcmd14"))
                        {
                            flg = true;
                        }
                    }
                }
                else 
                {
                    errFlag = true;
                    ret = err;
                }
            }
            catch(Exception e) 
            {
                e.ToString();
            }
            finally 
            {
                if (p != null) p.Close();
            }
            return ret;
        }

        /// <summary>
        /// �R�}���h�����s���܂��B
        /// </summary>
        /// <param name="command">�R�}���h</param>
        /// <param name="errFlag">�G���[�t���O</param>
        /// <param name="mode">���[�h</param>
        /// <param name="errMsg">�G���[�X�e�[�^�X</param>
        /// <param name="timeout">�^�C���A�E�g</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�����s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private String RunCmd(String command, ref bool errFlag, int mode, string errMsg, int timeout, int retryCnt) 
        {
            string ret = errMsg; 
            string err = null;
            string otp = null;

            if (retryCnt == -1)
            {
                ret = LOGMSG_TIMEOUTERR;
                return ret;
            }

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                if (mode == 0)
                {
                    p.Start();
                    p.StandardInput.WriteLine(command);
                    p.StandardInput.WriteLine("exit");
                    err = p.StandardError.ReadToEnd();
                    if (!String.IsNullOrEmpty(err))
                    {
                        errFlag = false;
                        string[] arr = Regex.Split(err, "\r\n");
                        foreach (string str in arr)
                        {
                            if (str.Contains("java version"))
                            {
                                ret = str.Substring(13);
                                break;
                            }
                        }
                    }
                    else
                    {
                        errFlag = true;
                        ret = err;
                    }
                }
                else if (mode == 1)
                {
                    p.Start();
                    p.StandardInput.WriteLine(command);
                    p.StandardInput.WriteLine("exit");
                    otp = p.StandardOutput.ReadToEnd();
                    err = p.StandardError.ReadToEnd();
                    if (null == err || String.IsNullOrEmpty(err))
                    {
                        errFlag = false;
                        string[] arr = Regex.Split(otp, "\r\n");
                        foreach (string str in arr)
                        {
                            if (str.Contains("returncode="))
                            {
                                ret = str.Substring(str.IndexOf("returncode=") + 11);
                                break;
                            }
                        }
                    }
                    else
                    {
                        errFlag = true;
                        ret = err;
                    }
                }

                if (timeout != 0 && !p.WaitForExit(timeout))
                {
                    p.Kill();

                    retryCnt = retryCnt - 1;
                    RunCmd(command, ref errFlag, mode, ret, timeout, retryCnt);
                }
            }
            catch (Exception e)
            {
                e.ToString();
                errFlag = true;
                ret = string.Empty;
            }
            finally
            {
                if (p != null) p.Close();
            }
            return ret;
        }

        /// <summary>
        /// ���O�t�@�C����
        /// </summary>
        /// <returns>���O�t�@�C����</returns>
        /// <remarks>
        /// <br>Note		: ���O�t�@�C����</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private String GetLogName()
        {
            string workDir;
            // ڼ޽�ط��擾
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (null == key)
            {
                workDir = @"C:\SFNETASM";
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\SFNETASM").ToString();
            }
            //�t�H�[������̂��̔��f
            string folderPath = workDir + "\\LOG\\";
            if (!Directory.Exists(folderPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderPath);
                DirectoryInfo dis = di.CreateSubdirectory("SAndESend\\");
            }
            else
            {

                if (!Directory.Exists(folderPath + "SAndESend\\"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath + "SAndESend\\");
                }
            }

            String ret = folderPath + "SAndESend\\";
            ret += DateTime.Now.ToString("yyyyMMdd") + ".log";
            return ret;
        }

        /// <summary>
        /// ����I�[�v������
        /// </summary>
        /// <param name="connectInfo">����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����I�[�v���������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>									
        /// </remarks>
        private bool RequestOpen(ConnectInfoWork connectInfo)
        {
            bool isConnected;
            int flags;
            isConnected = InternetGetConnectedState(out flags, 0);

            if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
            {
                // ������I�[�y���G���[
                return false;
            }
            string httpHead = "";

            //HTTP/HTTPS �v���g�R��  
            if (connectInfo.DaihatsuOrdreDiv == 0)
            {
                httpHead = "http://";
            }
            else
            {
                httpHead = "https://";
            }
            //�ڑ�����}�X�^�̔�����z�敪�i�_�C�n�c�j�{�ڑ�����}�X�^�̔���URL�{�ڑ�����}�X�^�̍݌Ɋm�FURL
            request = (HttpWebRequest)HttpWebRequest.Create(httpHead + connectInfo.OrderUrl + connectInfo.StockCheckUrl);
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            return true;
        }

        /// <summary>
        /// ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����
        /// </summary>
        /// <param name="connectInfo">����</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ����܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>									
        /// </remarks>
        private string ConvertUoeSndHedToXML(ConnectInfoWork connectInfo, string fileName)
        {
            // �w�b�_���ǉ�
            HeaderMake(connectInfo);
            string xmlFileString = "";
            xmlFileString = fileChange(fileName);

            return xmlFileString;
        }

        /// <summary>
        /// �w�b�_���ǉ�
        /// </summary>
        /// <param name="connectInfo">����</param>
        /// <remarks>
        /// <br>Note		: �w�b�_���ǉ����܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private void HeaderMake(ConnectInfoWork connectInfo)
        {
            request.Accept = "*/*";
            request.Headers.Add("Accept-Language" , "ja");
            //WSSE�F�ؗp�̕���������
            string wsse = CreateWSSEToken(connectInfo.ConnectUserId, connectInfo.ConnectPassword);

            request.Headers.Add("X-WSSE:"+wsse);

            request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
            request.KeepAlive = true;
            //�ڑ�����}�X�^�̃��O�C���^�C���A�E�g
            if (connectInfo.LoginTimeoutVal != 0)
            {
                request.Timeout = connectInfo.LoginTimeoutVal * 1000;
            }
        }

        /// <summary>
        /// �F�ؗp�E�v���𐶐����܂��B
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �F�ؗp�E�v���𐶐����܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>							
        /// </remarks>
        private string CreateWSSEToken(string userName, string password)
        {
            StringBuilder wsseToken = new StringBuilder();
            string nonce = CreateNonce();
            string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
            string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password))));

            //Username Token�̕�����𐶐����� 
            wsseToken.Append("UsernameToken ");
            wsseToken.AppendFormat("Username=\"{0}\", ", userName);
            wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
            wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
            wsseToken.AppendFormat("Created=\"{0}\" ", created);

            return wsseToken.ToString();
        }

        /// <summary>
        /// Nonce�𐶐����܂��B
        /// Nonce�͐��x�̍����[������������𗘗p���Ă��������B
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: Nonce�͐��x�̍����[�������������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private string CreateNonce()
        {
            Random r = new Random();
            double d1 = r.NextDouble();
            double d2 = d1 * d1;
            return GetDigest(d2.ToString());
        }

        /// <summary>
        /// 16�i���\�L��SHA-1���b�Z�[�W�_�C�W�F�X�g�𐶐����܂��B
        /// </summary>
        /// <param name="source">source</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: 16�i���\�L��SHA-1���b�Z�[�W�_�C�W�F�X�g�𐶐����܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>							
        /// </remarks>
        private string GetDigest(string source)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder answer = new StringBuilder();
            foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
            {
                if (b < 16)
                {
                    answer.Append("0");
                }
                answer.Append(Convert.ToString(b, 16));
            }
            return answer.ToString();
        }

        /// <summary>
        /// �t�@�C����ύX
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �t�@�C����ύX���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private string fileChange(string fileName)
        {
            //�t�@�C���֑��M
            string fileString = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                file.Read(byDate, 0, (int)file.Length);
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }

        #endregion
        #region
        /// <summary>
        /// ���O�o�͏���
        /// </summary>
        /// <param name="intRet"></param>
        /// <param name="exErrMsg"></param>
        /// <param name="pMsg"></param>
        /// <remarks>
        /// <br>Note       :���O�o�͏������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void LogWrite(int intRet, string exErrMsg, string pMsg)
        {
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            DateTime edt = DateTime.Now;
            try
            {
                // Log�t�H���_�[
                string logFolderPath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Log"), CtPGID);
                if (!Directory.Exists(logFolderPath))
                {
                    // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                    Directory.CreateDirectory(logFolderPath);
                }

                string fileName = _posTerminalMg.CashRegisterNo + "_" + edt.ToString("yyyyMMdd") + ".Log";
                // ���O�t�@�C��
                string logFilePath = Path.Combine(logFolderPath, fileName);
                _fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5}�@{2}�@{3}�@{4}", edt, edt.Millisecond, intRet, exErrMsg, pMsg));
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception)
            {
            }
        }
         #endregion 

        # region [�[���ݒ�擾]
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �[���ݒ�擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
        #endregion �� Private Method
    }
}
