//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �C �� ��  2012/12/07  �C�����e : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/02/25  �C�����e : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/03/06  �C�����e : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/05/21  �C�����e : �r���d(AB) �e�L�X�g�o�͎������MJava�c�[���𗘗p����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/06/24  �C�����e : Redmine#37017 S&E�u���[�L���M�R�}���h
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/06/26  �C�����e : �������M�����̒ǉ��y�ё��M���O�̓o�^
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/07/25  �C�����e : Redmine#39145 �G���[��������S&E���㒊�o�f�[�^�X�V�����ꍇ������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/08/07  �C�����e : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����  
// �C �� ��  2013/08/12  �C�����e : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11670121-00  �쐬�S�� : �΍�  
// �C �� ��  2020/02/26  �C�����e : S&E���ǑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
// ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
// ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����f�[�^�e�L�X�g�o�� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ����f�[�^�e�L�X�g�o�͂Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: ���M</br>
    /// <br>Date		: 2009.08.13</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
    /// <br>UpdateNote  : 2013/02/25 zhuhh</br>
    /// <br>            : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
    /// <br>UpdateNote  : 2013/05/21 zhuhh</br>
    /// <br>            : �������MJava�c�[���𗘗p����</br>
    /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
    /// <br>            : S&E�u���[�L���M�R�}���h</br>
    /// <br>UpdateNote  : 2013/06/26 �c����</br>
    /// <br>            : �������M�����̒ǉ��y�ё��M���O�̓o�^</br>
    /// <br>UpdateNote  : 2013/07/25 �c����</br>
    /// <br>            : Redmine#39145 �G���[��������S&E���㒊�o�f�[�^�X�V�����ꍇ������Ή�</br>
    /// <br>UpdateNote  : 2013/08/07 �c����</br>
    /// <br>            : Redmine#39695 ���o���ʖ����̌��ʉ�ʕ\���̕ύX�Ή�</br>
    /// <br>UpdateNote  : 2013/08/12 �c����</br>
    /// <br>            : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
    /// <br>UpdateNote  : 2020/02/26 �΍�</br>
    /// <br>            : �r���d���ǑΉ�</br>
    /// </remarks>
    public class SalesHistoryAcs
    {
        #region �� Constructor
        /// <summary>
        /// ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public SalesHistoryAcs()
        {
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���O�C�����_���擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._iSalesHistoryJoinWorkDB = (ISalesHistoryJoinWorkDB)MediationSalesHistoryJoinResultDB.GetSalesHistoryJoinWorkDB();

            //�`�[����ݒ�}�X�^���X�g�̎擾
            _slipPrtSetAcs = new SlipPrtSetAcs();

            _custSlipMngAcs = new CustSlipMngAcs();

            _slipTypeController = new SlipTypeController();


            // ----- ADD �΍� 2020/02/26 ----->>>>>
            //���[�J�[�E�i��AB���i�R�[�h�ϊ��}�X�^�̎擾
            _MakerGoodsCodeSetAcs = new MakerGoodsCodeSetAcs();
            // ----- ADD �΍� 2020/02/26 -----<<<<<


            //�`�[����ݒ�}�X�^���X�g
            ArrayList slipPrtSetList;

            _slipPrtSetAcs.SearchSlipPrtSet(out slipPrtSetList, this._enterpriseCode);

            //���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g
            int totalCount;
            _custSlipMngAcs.SearchOnlyCustSlipMng(out totalCount, this._enterpriseCode);

            _slipTypeController.EnterpriseCode = this._enterpriseCode;
            _slipTypeController.SlipPrtSetList = GetSlipPrtSet(slipPrtSetList);
            _slipTypeController.CustSlipMngList = GetCustSlipMng(_custSlipMngAcs.CustSlipMngList);
        }

        /// <summary>
        /// ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�̓A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        static SalesHistoryAcs()
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        #region API��`
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        #endregion
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
        #endregion �� Static Member

        #region �� Private Member
        ISalesHistoryJoinWorkDB _iSalesHistoryJoinWorkDB;

        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _salesHistoryDt;			// ���DataTable

        private const string ZERO = "0";
        private const string ONE = "1";
        private const string TWO = "2";
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";
        private const int ERROR_SUCCESS = 0;
        //�Œ�̎d����u913011�v
        //private const int SUPPLIERCD = 913011;// DEL �c���� 2013/06/26
        private const int SUPPLIERCD = 0; // ADD �c���� 2013/06/26
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        // ----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>���O���b�Z�[�W�F���M�Ώۃf�[�^����</summary>
        //private const string LOGMSG_NODATA = "���M�Ώۃf�[�^����"; // DEL �c���� 2013/08/07 Redmine#39695
        private const string LOGMSG_NODATA = "�Y������f�[�^�͂���܂���"; // ADD �c���� 2013/08/07 Redmine#39695
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
        // --- ADD �c���� 2013/07/25 --->>>>>
        /// <summary>���O���b�Z�[�W�F�\�z�O�̃G���[</summary>
        private const string LOGMSG_UNEXPECTEDERR = "�\�����ʗ�O���������܂����B(Code:-999)";
        // --- ADD �c���� 2013/07/25 ---<<<<<

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
        // ----- ADD �c���� 2013/06/26 -----<<<<<

        private SlipPrtSetAcs _slipPrtSetAcs = null;

        private CustSlipMngAcs _custSlipMngAcs = null;

        private SlipTypeController _slipTypeController = null;

        private ArrayList _resultWorkClone;

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        //�ڑ����}�X�^
        private ConnectInfoWorkAcs _connectInfoWorkAcs = null;
        private HttpWebRequest request = null;
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<
        // ----- ADD �΍� 2020/02/26 ----->>>>>
        //���[�J�[�E�i��AB���i�R�[�h�ϊ��}�X�^�̎擾
        private MakerGoodsCodeSetAcs _MakerGoodsCodeSetAcs = null;
        // ----- ADD �΍� 2020/02/26 -----<<<<<

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
        /// <param name="salesHistoryCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public int SearchSalesHistoryProcMain(SalesHistoryCndtn salesHistoryCndtn, out string errMsg)
        {
            return this.SearchSalesHistoryProc(salesHistoryCndtn, out errMsg);
        }

        /// <summary>
        /// ����f�[�^���o����
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
                PMSAE02014EA.CreatePrintDataTable(ref printdataTable);

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
                        || (!befSectionCode.Equals(dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSAE02014EA.ct_Col_CustomerCode]))))
                    {
                        if (string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        {
                            temp.Add(dataRowView);
                        }

                        if ((!string.IsNullOrEmpty(befSectionCode) && (!string.IsNullOrEmpty(befCustomerCode)))
                            && (!befSectionCode.Equals(dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSAE02014EA.ct_Col_CustomerCode]))))
                        {
                            tempList.Add(temp);

                            temp = new List<DataRowView>();

                            temp.Add(dataRowView);
                        }
                        else if ((!string.IsNullOrEmpty(befSectionCode)) && (!string.IsNullOrEmpty(befCustomerCode)))
                        {
                            temp.Add(dataRowView);
                        }

                        befSectionCode = dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF].ToString();

                        befCustomerCode = dataRowView[PMSAE02014EA.ct_Col_CustomerCode].ToString();

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

                    //�s���i�����j
                    int pureCount = 0;
                    //������z�i�����j
                    long pureSalesMoneyTaxExc = 0;
                    //�d�؋��z�i�����j
                    long pureSupplierMoney = 0;
                    //�s���i�D�ǁj
                    int priCount = 0;
                    //������z�i�D�ǁj
                    long priSalesMoneyTaxExc = 0;
                    //�d�؋��z�i�D�ǁj
                    long priSupplierMoney = 0;

                    for (int j = 0; j < detailList.Count; j++)
                    {
                        DataRowView detailView = (DataRowView)detailList[j];

                        //�`�[����
                        string salesSlipNum = detailView[PMSAE02014EA.ct_Col_SalesSlipNum].ToString();
                        if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                        {
                            slipCountSum++;
                        }
                        befSalesSlipNum = salesSlipNum;

                        //���㍇�v
                        salesMoneySum += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);

                        //�l���\��z
                        long salesMoneyDetail = Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                        long supplierMoneyDetail = Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        salesSupplierMoneySum += (salesMoneyDetail - supplierMoneyDetail);

                        //�i�����j
                        if (ONE.Equals(detailView[PMSAE02014EA.ct_Col_GoodDiv].ToString()))
                        {
                            //�s���i�����j
                            pureCount++;
                            //������z�i�����j
                            pureSalesMoneyTaxExc += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                            //�d�؋��z�i�����j
                            pureSupplierMoney += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        }

                        //�i�D�ǁj
                        if (TWO.Equals(detailView[PMSAE02014EA.ct_Col_GoodDiv].ToString()))
                        {
                            //�s���i�D�ǁj
                            priCount++;
                            //������z�i�D�ǁj
                            priSalesMoneyTaxExc += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                            //�d�؋��z�i�D�ǁj
                            priSupplierMoney += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        }
                    }

                    dr[PMSAE02014EA.ct_Col_CustomerCode] = detailList[0][PMSAE02014EA.ct_Col_CustomerCode];
                    dr[PMSAE02014EA.ct_Col_PureDefferent] = (pureSalesMoneyTaxExc - pureSupplierMoney);
                    dr[PMSAE02014EA.ct_Col_PriDefferent] = (priSalesMoneyTaxExc - priSupplierMoney); ;
                    dr[PMSAE02014EA.ct_Col_SectionCodeRF] = detailList[0][PMSAE02014EA.ct_Col_SectionCodeRF];
                    dr[PMSAE02014EA.ct_Col_SectionGuideSnm] = detailList[0][PMSAE02014EA.ct_Col_SectionGuideSnm];
                    dr[PMSAE02014EA.ct_Col_CustomerSnm] = detailList[0][PMSAE02014EA.ct_Col_CustomerSnm];
                    dr[PMSAE02014EA.ct_Col_SlipCountSum] = slipCountSum.ToString();
                    dr[PMSAE02014EA.ct_Col_SalesMoneySum] = salesMoneySum.ToString();
                    dr[PMSAE02014EA.ct_Col_SalesSupplierMoneySum] = salesSupplierMoneySum.ToString();
                    dr[PMSAE02014EA.ct_Col_PureCount] = pureCount.ToString();
                    dr[PMSAE02014EA.ct_Col_PureSalesMoneyTaxExc] = pureSalesMoneyTaxExc.ToString();
                    dr[PMSAE02014EA.ct_Col_PureSupplierMoney] = pureSupplierMoney.ToString();
                    dr[PMSAE02014EA.ct_Col_PriCount] = priCount.ToString();
                    dr[PMSAE02014EA.ct_Col_PriSalesMoneyTaxExc] = priSalesMoneyTaxExc.ToString();
                    dr[PMSAE02014EA.ct_Col_PriSupplierMoney] = priSupplierMoney.ToString();

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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="salesHistoryCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2013/06/26 �c����</br>
        /// <br>           : �������M�����̒ǉ��y�ё��M���O�̓o�^</br>
        /// <br>UpdateNote : 2013/08/12 �c����</br>
        /// <br>           : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
        /// </remarks>
        private int SearchSalesHistoryProc(SalesHistoryCndtn salesHistoryCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            //----- ADD �c���� 2013/06/26 ----------------->>>>>
            this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�J�n�j
            //int logStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL �c���� 2013/07/25
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD �c���� 2013/07/25
            SAndESalSndLogListResultWork sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            //----- ADD �c���� 2013/06/26 -----------------<<<<<

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSAE02014EA.CreateDataTable(ref this._salesHistoryDt);

                // ���o�����W�J  --------------------------------------------------------------
                SalesHistoryCndtnWork salesHistoryCndtnWork = new SalesHistoryCndtnWork();
                status = this.DevSalesHistory(salesHistoryCndtn, out salesHistoryCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object salesHistoryResultWork = null;
                status = _iSalesHistoryJoinWorkDB.Search(out salesHistoryResultWork, (object)salesHistoryCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList salesHistoryResultList = salesHistoryResultWork as ArrayList;

                        //�f�[�^��Convert����
                        status  = GetSalesHistoryData(salesHistoryCndtn, salesHistoryResultList);

                        // �`�[�����A���ז����A���v���z�̌v�Z
                        CalcuSalseInfo(); // ADD �c���� 2013/06/26

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            errMsg = "�Y������f�[�^������܂���B";
                            // ----- ADD �c���� 2013/06/26 ----->>>>>
                            // �蓮���M�i����e�L�X�g�o�͂���j�̏ꍇ�A���A�������M�敪���u����v
                            // ���邢�͎������M�̏ꍇ�A���M���O��o�^
                            if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                            {
                                //���M���O�̓o�^
                                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                                //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_NODATA); // DEL �c���� 2013/08/12 Redmine#39695
                                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, 2, LOGMSG_NODATA); // ADD �c���� 2013/08/12 Redmine#39695
                            }
                            // ----- ADD �c���� 2013/06/26 -----<<<<<
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "�Y������f�[�^������܂���B";
                        // ----- ADD �c���� 2013/06/26 ----->>>>>
                        // �蓮���M�i����e�L�X�g�o�͂���j�̏ꍇ�A���A�������M�敪���u����v
                        // ���邢�͎������M�̏ꍇ�A���M���O��o�^
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //���M���O�̓o�^
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                            //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_NODATA); // DEL �c���� 2013/08/12 Redmine#39695
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, 2, LOGMSG_NODATA); // ADD �c���� 2013/08/12 Redmine#39695
                        }
                        // ----- ADD �c���� 2013/06/26 -----<<<<<
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        errMsg = "�f�[�^���o�����Ɏ��s���܂����B";
                        // ----- ADD �c���� 2013/06/26 ----->>>>>
                        // �蓮���M�i����e�L�X�g�o�͂���j�̏ꍇ�A���A�������M�敪���u����v
                        // ���邢�͎������M�̏ꍇ�A���M���O��o�^
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //���M���O�̓o�^
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                        }
                        // ----- ADD �c���� 2013/06/26 -----<<<<<
                        break;
                    default:
                        errMsg = "�f�[�^���o�����Ɏ��s���܂����B";
                        // ----- ADD �c���� 2013/06/26 ----->>>>>
                        // �蓮���M�i����e�L�X�g�o�͂���j�̏ꍇ�A���A�������M�敪���u����v
                        // ���邢�͎������M�̏ꍇ�A���M���O��o�^
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //���M���O�̓o�^
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                            //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR); // DEL �c���� 2013/08/12 Redmine#39695
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_ERROR); // ADD �c���� 2013/08/12 Redmine#39695
                        }
                        // ----- ADD �c���� 2013/06/26 -----<<<<<
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                // ----- ADD �c���� 2013/06/26 ----->>>>>
                // �蓮���M�i����e�L�X�g�o�͂���j�̏ꍇ�A���A�������M�敪���u����v
                // ���邢�͎������M�̏ꍇ�A���M���O��o�^
                if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                {
                    //���M���O�̓o�^
                    this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ���M�����i�I���j
                    logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD �c���� 2013/06/26 -----<<<<<
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetSortOrder()
        {
            StringBuilder strSortOrder = new StringBuilder();

            strSortOrder.Append(string.Format("{0} ASC,", PMSAE02014EA.ct_Col_SectionCodeRF));
            strSortOrder.Append(string.Format("{0} ASC,", PMSAE02014EA.ct_Col_CustomerCode));
            strSortOrder.Append(string.Format("{0} ASC", PMSAE02014EA.ct_Col_SalesSlipNum));

            return strSortOrder.ToString();
        }
        #endregion

        #region �� S&E���㒊�o�f�[�^�X�V����
        /// <summary>
        /// ���㒊�o�f�[�^�X�V
        /// </summary>
        /// <param name="resultWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���㒊�o�f�[�^���X�V����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private int WriteProc(ArrayList resultWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = string.Empty;

            object objectresultWork = resultWork as object;

            if (resultWork != null && resultWork.Count > 0)
            {
                // �������ݏ���
                status = this._iSalesHistoryJoinWorkDB.Write(ref objectresultWork);
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errMsg = "S&E���㒊�o�f�[�^�X�V�����Ɏ��s���܂����B";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }


        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �擾�f�[�^�W�J����

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesHistoryCndtn">UI���o�����N���X</param>
        /// <param name="salesHistoryCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSalesHistory(SalesHistoryCndtn salesHistoryCndtn, out SalesHistoryCndtnWork salesHistoryCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            salesHistoryCndtnWork = new SalesHistoryCndtnWork();
            try
            {
                // ��ƃR�[�h 
                salesHistoryCndtnWork.EnterpriseCode = salesHistoryCndtn.EnterpriseCode;
                // ���_�R�[�h���X�g
                salesHistoryCndtnWork.SectionCodeList = salesHistoryCndtn.SectionCodeList;
                // �v���(�J�n)
                salesHistoryCndtnWork.AddUpADateSt = salesHistoryCndtn.AddUpADateSt;
                // �v���(�I��)
                salesHistoryCndtnWork.AddUpADateEd = salesHistoryCndtn.AddUpADateEd;
                //���Ӑ�(�J�n)
                salesHistoryCndtnWork.CustomerCodeSt = salesHistoryCndtn.CustomerCodeSt;
                //���Ӑ�(�I��)
                salesHistoryCndtnWork.CustomerCodeEd = salesHistoryCndtn.CustomerCodeEd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }


        #endregion �� ���o�����W�J����
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="salesHistoryCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2020/2/26 �΍�</br>
        /// <br>           : �r���d���ǑΉ� </br>
        /// </remarks>
        private int GetSalesHistoryData(SalesHistoryCndtn salesHistoryCndtn, ArrayList resultWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // ----- ADD �΍� 2020/02/26 ----->>>>>
            //���[�J�[�E�i��AB���i�R�[�h�ϊ��}�X�^�̎擾
            ArrayList sAEMkrGdsCdChgList = new ArrayList();
            sAEMkrGdsCdChgList.Clear();
            status = this._MakerGoodsCodeSetAcs.SearchAll(out sAEMkrGdsCdChgList, this._enterpriseCode);
            // ----- ADD �΍� 2020/02/26 -----<<<<<
            //S&E���㒊�o�f�[�^�X�V�p
            _resultWorkClone = new ArrayList();

            foreach (SalesHistoryJoinWork salesHistoryJoinWork in resultWork)
            {
                //S&E���㒊�o�f�[�^�Ƀ��R�[�h�����݂��Ȃ�
                if (salesHistoryCndtn.PdfOutDiv == 0)
                {
                    if (salesHistoryJoinWork.SEAcptAnOdrStatus == 0
                        && string.IsNullOrEmpty(salesHistoryJoinWork.SEEnterpriseCode)
                        && salesHistoryJoinWork.SESalesCreateDateTime == 0
                        && string.IsNullOrEmpty(salesHistoryJoinWork.SESalesSlipNum))
                    {
                        ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                        _resultWorkClone.Add(salesHistoryJoinWork);
                    }
                }
                //S&E���㒊�o�f�[�^�Ƀ��R�[�h�����݂���
                else if (salesHistoryCndtn.PdfOutDiv == 1)
                {
                    if (salesHistoryJoinWork.SEAcptAnOdrStatus != 0
                        && !string.IsNullOrEmpty(salesHistoryJoinWork.SEEnterpriseCode)
                        && salesHistoryJoinWork.SESalesCreateDateTime != 0
                        && !string.IsNullOrEmpty(salesHistoryJoinWork.SESalesSlipNum))
                    {
                        ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                        _resultWorkClone.Add(salesHistoryJoinWork);
                    }

                }
                //�S�āiS&E���㒊�o�f�[�^�Ɉˑ����Ȃ��j
                else
                {
                    ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                    _resultWorkClone.Add(salesHistoryJoinWork);
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
        /// <param name="salesHistoryJoinWork">�擾�f�[�^</param>
        /// <param name="sAEMkrGdsCdChgWorkList">���[�J�[�E�i��AB���i�R�[�h�ϊ��}�X�^�̎擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : �r���d�u���[�L�`�a���i�R�[�h�̌����̉��C</br>
        /// <br>UpdateNote : 2013/02/25 zhuhh</br>
        /// <br>           : �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
        /// <br>UpdateNote : 2013/03/06 zhuhh</br>
        /// <br>           : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�</br>
        /// <br>UpdateNote : 2020/2/26 �΍�</br>
        /// <br>           : �r���d���ǑΉ�</br>
        /// </remarks>
        private void ConvertSalesHistoryData(SalesHistoryJoinWork salesHistoryJoinWork, ArrayList sAEMkrGdsCdChgWorkList)  // ----- UPD �΍� 2020/02/26 
        {
            DataRow dr = _salesHistoryDt.NewRow();

            //AB�`�[��
            dr[PMSAE02014EA.ct_Col_SalesSlipNum] = DataNoSubStr(6, salesHistoryJoinWork.SalesSlipNum);

            //�����敪
            if (salesHistoryJoinWork.SalesSlipCd == 0)
            {
                dr[PMSAE02014EA.ct_Col_RequestDiv] = "010";
            }
            else if (salesHistoryJoinWork.SalesSlipCd == 1)
            {
                dr[PMSAE02014EA.ct_Col_RequestDiv] = "020";
            }
            else
            {
                //
            }

            //AB�X�ܺ���
            dr[PMSAE02014EA.ct_Col_AddresseeShopCd] = salesHistoryJoinWork.AddresseeShopCd;

            //�����
            dr[PMSAE02014EA.ct_Col_AddUpADate] = salesHistoryJoinWork.AddUpADate.ToString("yyyyMMdd");

            //�����D�ǋ敪
            int goodsMakerCd = salesHistoryJoinWork.GoodsMakerCd;
            dr[PMSAE02014EA.ct_Col_GoodDiv] = GetGoodDiv(goodsMakerCd, salesHistoryJoinWork);

            //���i������
            if (ONE.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                dr[PMSAE02014EA.ct_Col_TradCompCd] = salesHistoryJoinWork.PureTradCompCd;

            }
            else if (TWO.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                dr[PMSAE02014EA.ct_Col_TradCompCd] = salesHistoryJoinWork.PriTradCompCd;

            }

            //�r���d�d����
            double tradCompRate = 0;
            if (ONE.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                tradCompRate = salesHistoryJoinWork.PureTradCompRate * 10;

            }
            else if (TWO.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                tradCompRate = salesHistoryJoinWork.PriTradCompRate * 10;
            }
            dr[PMSAE02014EA.ct_Col_TradCompRate] = DataNoSubStr(4, tradCompRate.ToString("0000"));

            //AB���㗦
            dr[PMSAE02014EA.ct_Col_AbSalesRate] = "0000";

            //�s��
            dr[PMSAE02014EA.ct_Col_SalesRowNo] = DataNoSubStr(2, salesHistoryJoinWork.SalesRowNo.ToString("d2"));

            //�Ǘ���
            bool flag = GetBlEffective(salesHistoryJoinWork.CustomerCode);

            if (flag == true)
            {
                dr[PMSAE02014EA.ct_Col_AdministrationNo] = DataNoSubStr(4, salesHistoryJoinWork.PrtBLGoodsCode.ToString("d4"));
            }
            else
            {
                dr[PMSAE02014EA.ct_Col_AdministrationNo] = "0000";
            }


            //�Ǘ����́i�i�ԁj
            dr[PMSAE02014EA.ct_Col_GoodsNo] = GetCharFormat(salesHistoryJoinWork.GoodsNo);

            //�i��
            //dr[PMSAE02014EA.ct_Col_GoodsNameKana] = GetCharFormat(salesHistoryJoinWork.GoodsNameKana);// DEL zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX
            dr[PMSAE02014EA.ct_Col_GoodsNameKana] = GetGoodsNameCharFormat(salesHistoryJoinWork.GoodsNameKana);// ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX

            // ----- add �΍� 2020/02/26 ----->>>>>
            //���i����
            string ABGoodsCode = string.Empty;
            foreach (SAndEMkrGdsCdChg sAEMkrGdsCdChgWork in sAEMkrGdsCdChgWorkList)
            {
                if ((DataNoSubStr(4, salesHistoryJoinWork.GoodsMakerCd.ToString("d4")) == DataNoSubStr(4, sAEMkrGdsCdChgWork.GoodsMakerCd.ToString("d4")))
                    && (GetCharFormat(salesHistoryJoinWork.GoodsNo) == GetCharFormat(sAEMkrGdsCdChgWork.GoodsNo))
                    && (sAEMkrGdsCdChgWork.LogicalDeleteCode) == 0 )
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = sAEMkrGdsCdChgWork.ABGoodsCode.PadLeft(8, '0');
                    ABGoodsCode = sAEMkrGdsCdChgWork.ABGoodsCode;
                    break;
                }
            }
            if (string.IsNullOrEmpty(ABGoodsCode))
            {
                if (!string.IsNullOrEmpty(salesHistoryJoinWork.ABGoodsCode))
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode.PadLeft(8, '0'); 
                }
                else
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode.PadLeft(8, '0'); 
                }
            }
            // ----- add �΍� 2020/02/26 -----<<<<<
            // ----- del �΍� 2020/02/26 ----->>>>>
            ////���i����
            //if (!string.IsNullOrEmpty(salesHistoryJoinWork.ABGoodsCode))
            //{
            //    //dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode;// DEL zhuhh 2012/12/07 AB���i�R�[�h�̌����̉��C
            //    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode.PadLeft(8, '0'); // ADD zhuhh 2012/12/07 AB���i�R�[�h�̌����̉��C
            //}
            //else
            //{
            //    //dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode;// DEL zhuhh 2012/12/07 AB���i�R�[�h�̌����̉��C
            //    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode.PadLeft(8, '0'); // ADD zhuhh 2012/12/07 AB���i�R�[�h�̌����̉��C
            //}
            // ----- del �΍� 2020/02/26 -----<<<<<

            //����
            dr[PMSAE02014EA.ct_Col_ShipmentCnt] = GetNumFormat(salesHistoryJoinWork.ShipmentCnt);

            //�[���P��
            dr[PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl] = GetNumFormat(salesHistoryJoinWork.SalesUnPrcTaxExcFl);

            //�[�����z
            dr[PMSAE02014EA.ct_Col_SalesMoneyTaxExc] = GetNumFormat(salesHistoryJoinWork.SalesMoneyTaxExc);

            //PDF�p�[�����z
            dr[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc] = GetNumRound(salesHistoryJoinWork.SalesMoneyTaxExc);

            //�d�����z
            dr[PMSAE02014EA.ct_Col_SupplierMoney] = GetSupplierMoney(dr[PMSAE02014EA.ct_Col_GoodDiv].ToString(), salesHistoryJoinWork,1);

            //PDF�p�d�����z
            dr[PMSAE02014EA.ct_Col_PdfSupplierMoney] = GetSupplierMoney(dr[PMSAE02014EA.ct_Col_GoodDiv].ToString(), salesHistoryJoinWork,2);

            //������z
            dr[PMSAE02014EA.ct_Col_SalesMoney] = "00000000";

            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            //�X�ܔ���
            dr[PMSAE02014EA.ct_Col_ShopMoney] = GetNumFormat(salesHistoryJoinWork.ListPriceTaxExcFl);

            //�������z
            dr[PMSAE02014EA.ct_Col_PriceMoney] = GetNumFormatWithoutMinus(salesHistoryJoinWork.ListPriceTaxExcFl * salesHistoryJoinWork.ShipmentCnt);
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<

            //Txt���Ӑ溰��
            dr[PMSAE02014EA.ct_Col_TxtCustomerCode] = salesHistoryJoinWork.SAndEMngCode;

            //���Ӑ溰��
            dr[PMSAE02014EA.ct_Col_CustomerCode] = salesHistoryJoinWork.CustomerCode.ToString("d8");

            //�n�溰��
            dr[PMSAE02014EA.ct_Col_AreaCd] = "0";

            //�����ްĂx�l�c
            dr[PMSAE02014EA.ct_Col_SearchSlipDate] = salesHistoryJoinWork.SearchSlipDate.ToString("yyyyMMdd");

            //�d����R�[�h
            dr[PMSAE02014EA.ct_Col_SupplierCd] = salesHistoryJoinWork.SupplierCd.ToString("d8");

            //�o��敪
            string expenseDivCd;
            if (salesHistoryJoinWork.ExpenseDivCd == 0)
            {
                expenseDivCd = "1";
            }
            else
            {
                expenseDivCd = salesHistoryJoinWork.ExpenseDivCd.ToString();
            }
            dr[PMSAE02014EA.ct_Col_ExpenseDivCd] = expenseDivCd;

            //���[�J�[�R�[�h
            dr[PMSAE02014EA.ct_Col_GoodsMakerCd] = DataNoSubStr(4, salesHistoryJoinWork.GoodsMakerCd.ToString("d4"));

            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
            //�����i���o�[
            dr[PMSAE02014EA.ct_Col_OrderNum] = "999999";
            // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<

            //�e�h�k�k�d�q
            dr[PMSAE02014EA.ct_Col_Filler] = " ";

            //���_�R�[�h
            dr[PMSAE02014EA.ct_Col_SectionCodeRF] = salesHistoryJoinWork.ResultsAddUpSecCd;

            // ���_�K�C�h����
            string sectionGuideSnm = "";
            if (string.IsNullOrEmpty(salesHistoryJoinWork.SectionGuideSnm))
            {
                sectionGuideSnm = "���o�^";
            }
            else
            {
                sectionGuideSnm = salesHistoryJoinWork.SectionGuideSnm;
            }
            dr[PMSAE02014EA.ct_Col_SectionGuideSnm] = sectionGuideSnm;

            // ���Ӑ旪��
            string customerSnm = "";
            if (string.IsNullOrEmpty(salesHistoryJoinWork.CustomerSnm))
            {
                customerSnm = "���o�^";
            }
            else
            {
                customerSnm = salesHistoryJoinWork.CustomerSnm;
            }
            dr[PMSAE02014EA.ct_Col_CustomerSnm] = customerSnm;
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
            // �f�[�^�敪
            dr[PMSAE02014EA.ct_Col_DataDiv] = "01";

            // �p�[�c�}���[���R�[�h
            dr[PMSAE02014EA.ct_Col_PartsManWSCD] = "";
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
            _salesHistoryDt.Rows.Add(dr);
        }

        /// <summary>
        /// ��n���̎擾����
        /// </summary>
        /// <param name="index">���o����</param>
        /// <param name="DataNo">�`�[�ԍ�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :  ��n���̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="inputGoodsMakerCd">���o����</param>
        /// <param name="salesHistoryJoinWork">�`�[�ԍ�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����D�ǋ敪�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetGoodDiv(int inputGoodsMakerCd, SalesHistoryJoinWork salesHistoryJoinWork)
        {
            string DataNum;

            if (inputGoodsMakerCd > 0)
            {
                bool isExistFlg = false;
                bool isExistTwoFlg = false;

                // ���i���[�J�[�R�[�h�ǉ�
                ArrayList goodsMakerCdList = new ArrayList();

                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd1);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd2);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd3);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd4);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd5);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd6);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd7);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd8);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd9);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd10);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd11);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd12);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd13);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd14);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd15);

                // �f�[�^��r
                foreach (int goodsMakserCd in goodsMakerCdList)
                {
                    if (inputGoodsMakerCd == goodsMakserCd)
                    {
                        isExistFlg = true;
                        break;
                    }
                }

                if ((1 <= inputGoodsMakerCd) && (99 >= inputGoodsMakerCd))
                {
                    isExistTwoFlg = true;
                }

                if ((isExistFlg == true) || (isExistTwoFlg == true))
                {
                    DataNum = ONE;
                }
                else
                {
                    DataNum = TWO;
                }
            }
            else
            {
                DataNum = TWO;
            }

            return DataNum;
        }

        /// <summary>
        /// BL���i�R�[�h�̈󎚗L���̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : BL���i�R�[�h�̈󎚗L���̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �S�p�����̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX----->>>>>
        /// <summary>
        /// �S�p�����̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �S�p�����̎擾�������s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/02/25</br>
        /// </remarks>
        private string GetGoodsNameCharFormat(string data)
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

            if (sb.ToString().Length > 20)
            {
                s = sb.ToString().Substring(0, 20);
            }
            else
            {
                s = sb.ToString().PadRight(20,' ');
            }

            return s;

        }

        /// <summary>
        /// �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̓v���X�ɂȂ�܂�
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̓v���X�ɂȂ�܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/02/25</br>
        /// </remarks>
        private string GetNumFormatWithoutMinus(Double data)
        {
            long numFormat;            
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0) 
            {
                numFormat = numFormat * (-1);
            }

            return DataNoSubStr(8, numFormat.ToString("d8"));
        }
        // ----- ADD zhuhh 2013/02/25 �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX-----<<<<<

        /// <summary>
        /// �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetNumFormat(Double data)
        {
            long numFormat;
            string result;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0)
            {
                if (numFormat.ToString().Length > 8)
                {
                    numFormat = Convert.ToInt64(DataNoSubStr(7, numFormat.ToString())) * (-1);

                    result = numFormat.ToString("d7");
                }
                else
                {
                    result = numFormat.ToString("d7");
                }
            }
            else
            {
                result = DataNoSubStr(8, numFormat.ToString("d8"));
            }

            return result;
        }

        /// <summary>
        /// �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �����_�ȉ�1���Ŏl�̌ܓ��A�}�C�i�X�l�̏ꍇ�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetNumRound(Double data)
        {
            long numFormat;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            return numFormat.ToString();
        }

        /// <summary>
        /// �d�����z�̎擾����
        /// </summary>
        /// <returns>�L��</returns>
        /// <remarks>
        /// <br>Note       : �d�����z�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetSupplierMoney(string goodDiv, SalesHistoryJoinWork salesHistoryJoinWork ,int flag)
        {
            double input = 0;
            double numFormat = 0;

            if (ONE.Equals(goodDiv))
            {
                input = (salesHistoryJoinWork.SalesUnPrcTaxExcFl * salesHistoryJoinWork.PureTradCompRate / 100);

                FractionCalculate.FracCalcMoney(input, 1, 2, out numFormat);
            }
            else if (TWO.Equals(goodDiv))
            {
                input = (salesHistoryJoinWork.SalesUnPrcTaxExcFl * salesHistoryJoinWork.PriTradCompRate / 100);

                FractionCalculate.FracCalcMoney(input, 1, 2, out numFormat);
            }

            if (flag == 1)
            {
                return GetNumFormat(numFormat * salesHistoryJoinWork.ShipmentCnt);
            }
            else
            {
                return GetNumRound(numFormat * salesHistoryJoinWork.ShipmentCnt);
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�̎擾����
        /// </summary>
        /// <returns>���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g�̎擾�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        #region [�������M]
        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="salesHistoryCndtn">����</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="sAndESalSndLogWork">���M���O���</param>
        /// <param name="logStatus">���M���O�o�^�X�e�[�^�X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: Web�T�[�o�Ƒ���M���܂��B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// <br>UpdateNote  : 2013/05/21 zhuhh</br>
        /// <br>            : �������MJava�c�[���𗘗p����</br>
        /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
        /// <br>            : S&E�u���[�L���M�R�}���h</br>
        /// <br>UpdateNote  : 2013/06/26 �c����</br>
        /// <br>            : �������M�����̒ǉ��y�ё��M���O�̓o�^</br>
        /// <br>UpdateNote  : 2013/07/25 �c����</br>
        /// <br>            : Redmine#39145 �G���[��������S&E���㒊�o�f�[�^�X�V�����ꍇ������Ή�</br>
        /// </remarks>
        //public int SendAndReceive(ref SalesHistoryCndtn salesHistoryCndtn, String fileName) // DEL �c���� 2013/06/26
        public int SendAndReceive(ref SalesHistoryCndtn salesHistoryCndtn, String fileName, out SAndESalSndLogListResultWork sAndESalSndLogWork, out int logStatus) // ADD �c���� 2013/06/26
        {
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL �c���� 2013/07/25
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD �c���� 2013/07/25
            string xmlFileName = string.Empty;

            //----- ADD �c���� 2013/06/26 ---------->>>>>
            string logErrMsg = string.Empty;
            //logStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL �c���� 2013/07/25
            logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD �c���� 2013/07/25
            sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            //----- ADD �c���� 2013/06/26 ----------<<<<<

            if (fileName.Contains("."))
            {
                int index = fileName.LastIndexOf(".");
                xmlFileName = fileName.Substring(0, index) + ".XML";
            }
            else 
            {
                xmlFileName = fileName + ".XML";
            }

            ConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new ConnectInfoWorkAcs();
                }
                else
                { 
                    //�Ȃ�
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesHistoryCndtn.EnterpriseCode, SUPPLIERCD);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                // ----- ADD �c���� 2013/06/26 ----->>>>>
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD �c���� 2013/06/26 -----<<<<<
                return status;
            }

            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                // ----- ADD �c���� 2013/06/26 ----->>>>>
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD �c���� 2013/06/26 -----<<<<<
                return status;
            }

            /* ----- DEL zhuhh 2013/05/21 for Redmine#35639 ----->>>>>
            string myString = "";
            string content = "";
            string fileRecStream = "";
            string errorMessage = "";

            // ����I�[�v������
            if (RequestOpen(connectInfoWork))
            {
                HttpWebResponse response = null;
                try
                {
                    // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
                    content = ConvertUoeSndHedToXML(connectInfoWork, xmlFileName);

                    myString += STRING_BOUNDARY;
                    myString += STRING_CHANGE_ROW;
                    myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
                    myString += "filename=\"" + fileName + "\"";
                    myString += STRING_CHANGE_ROW;
                    myString += STRING_CHANGE_ROW;

                    myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;

                    byte[] body = Encoding.ASCII.GetBytes(myString);

                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(body, 0, body.Length);
                        reqStream.Close();
                    }
                    response = (HttpWebResponse)request.GetResponse();
                    using (Stream revStream = response.GetResponseStream())
                    {                                                
                        StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
                        fileRecStream = sr.ReadToEnd();

                    }
                }
                catch (WebException ex)
                {
                    errorMessage = ex.Message;
                    status = -1;
                    return status;
                }
                response.Close();
                try
                {
                    //Rec�t�@�C���쐬

                    if (fileRecStream == string.Empty)
                    {
                        status = -1;
                        errorMessage = "�ް���M���ɴװ������(��M�t�@�C�����e������܂���) ";
                        return status;
                    }

                    string fileRecName = xmlFileName.Substring(0,xmlFileName.Length-4) + "RECV.XML";

                    FileStream file = new FileStream(fileRecName, FileMode.Create);

                    file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
                    file.Close();

                }
                catch (Exception ex)
                {
                    ex.ToString();
                    status = -1;
                    return status;
                }
            }
            else
            {
                status = -1;
                return status;
            }
               ----- DEL zhuhh 2013/05/21 for Redmine#35639 -----<<<<< */
            // ----- ADD zhuhh 2013/05/21 for Redmine#35639 ----->>>>>

            String command = CommandOrganization(connectInfoWork, fileName);
            // ----- ADD �c���� 2013/06/26 ----->>>>>
            if (string.IsNullOrEmpty(command) || command.Equals("<1.5.0"))
            {
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_JAVAVERERR;
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                return status;
            }
            // ----- ADD �c���� 2013/06/26 -----<<<<<

            bool errFlag = false;
            string errMsg = string.Empty; // ADD �c���� 2013/06/26
            try
            {
                //status = int.Parse(RunCmd(command, ref errFlag));// DEL zhuhh 2013/06/24 for Redmine#37017
                //status = int.Parse(RunCmd(command, ref errFlag, 1));// ADD zhuhh 2013/06/24 for Redmine#37017 // DEL �c���� 2013/06/26
                string ret = RunCmd(command, ref errFlag, 1, errMsg, connectInfoWork.LoginTimeoutVal * 1000, connectInfoWork.RetryCnt); // ADD �c���� 2013/06/26
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ADD �c���� 2013/06/26
                if (errFlag)
                {
                    status = -1;
                }
                // ----- DEL �c���� 2013/06/26 ----->>>>>
                //if (status != 0)
                //{
                //    status = -1;
                //}
                // ----- DEL �c���� 2013/06/26 -----<<<<<
                // ----- ADD �c���� 2013/06/26 ----->>>>>
                // --- ADD �c���� 2013/07/25 --->>>>>
                if (string.IsNullOrEmpty(ret))
                {
                    status = -1;
                    logErrMsg = LOGMSG_UNEXPECTEDERR;
                } 
                else
                // --- ADD �c���� 2013/07/25 ---<<<<<
                if (ret != "0")
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
                    else
                    {
                        int intRet = 0;
                        if (!int.TryParse(ret, out intRet))
                        {
                            ret = "���̑�";
                        }
                        logErrMsg = LOGMSG_SENDERR + LOGMSG_SENDADDERR + ret + ")";
                    }
                }
                // --- ADD �c���� 2013/07/25 --->>>>>
                else
                {
                    status = 0;
                }
                // --- ADD �c���� 2013/07/25 ---<<<<<
                //���M���O�̓o�^
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD �c���� 2013/06/26 -----<<<<<
            }
            catch (Exception exc)
            {
                exc.ToString();
                status = -1;
                // ----- ADD �c���� 2013/06/26 ----->>>>>
                //���M���O�̓o�^
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ADD �c���� 2013/06/26
                //logErrMsg = LOGMSG_SENDERR; // DEL �c���� 2013/07/25
                logErrMsg = LOGMSG_UNEXPECTEDERR; // ADD �c���� 2013/07/25
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD �c���� 2013/06/26 -----<<<<<
            }
            // ----- ADD zhuhh 2013/05/21 for Redmine#35639 -----<<<<<
            return status;
        }

        // ----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>
        /// �`�[�����A���א��A���㍇�v�̌v�Z
        /// </summary>
        /// <remarks>
        /// <br>Note		: �`�[�����A���א��A���㍇�v�̌v�Z���s���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2013/06/26</br>
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
                    string salesSlipNum = detailView[PMSAE02014EA.ct_Col_SalesSlipNum].ToString();
                    if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                    {
                        slipCountSum++;
                    }
                    befSalesSlipNum = salesSlipNum;

                    //���א�
                    detailCount++;

                    //���㍇�v
                    salesMoneySum += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                }

                this._sendSlipCount = slipCountSum;
                this._sendSlipDtlCnt = detailCount;
                this._sendSlipTotalMny = salesMoneySum;
            }
        }

        /// <summary>
        /// ���M���O���̓o�^
        /// </summary>
        /// <param name="salesHistoryCndtn">��������</param>
        /// <param name="sAndESalSndLogWork">���M���O���</param>
        /// <param name="sendResult">���M�̖߂����X�e�[�^�X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: ���M���O����o�^���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        public int WriteLogInfo(SalesHistoryCndtn salesHistoryCndtn, ref SAndESalSndLogListResultWork sAndESalSndLogWork, int sendResult, string errMsg)
        {
            int status = -1;

            //���M���O�̍쐬
            sAndESalSndLogWork = MakeLogInfo(salesHistoryCndtn, sendResult, errMsg);
            object obj = sAndESalSndLogWork;

            //���M���O�̓o�^
            status = _iSalesHistoryJoinWorkDB.WriteLog(ref obj);
            sAndESalSndLogWork = obj as SAndESalSndLogListResultWork;

            return status;
        }

        /// <summary>
        /// ���M���O���̍쐬
        /// </summary>
        /// <param name="salesHistoryCndtn">��������</param>
        /// <param name="sendResult">���M�̖߂����X�e�[�^�X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���M���O���</returns>
        /// <remarks>
        /// <br>Note		: ���M���O�����쐬���܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>UpdateNote  : 2013/08/12 �c����</br>
        /// <br>            : Redmine#39695 ���o���ʖ����̃��O���e�̕ύX�Ή�</br>
        /// </remarks>
        private SAndESalSndLogListResultWork MakeLogInfo(SalesHistoryCndtn salesHistoryCndtn, int sendResult, string errMsg)
        {
            SAndESalSndLogListResultWork sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            // ��ƃR�[�h
            sAndESalSndLogWork.EnterpriseCode = this._enterpriseCode;
            // �_���폜�敪
            sAndESalSndLogWork.LogicalDeleteCode = 0;
            // ���_�R�[�h
            sAndESalSndLogWork.SectionCode = this._sectionCode;
            // ���M�����i�J�n�j
            sAndESalSndLogWork.SendDateTimeStart = this._sendDateTimeStart;
            // ���M�����i�I���j
            sAndESalSndLogWork.SendDateTimeEnd = this._sendDateTimeEnd;
            // ���M�ΏۊJ�n���t
            sAndESalSndLogWork.SendObjDateStart = salesHistoryCndtn.AddUpADateSt;
            // ���M�ΏۏI�����t
            sAndESalSndLogWork.SendObjDateEnd = salesHistoryCndtn.AddUpADateEd;
            // (0:�蓮;1:����)
            if (salesHistoryCndtn.SendDataDiv == 0)
            {
                // �������M�敪
                sAndESalSndLogWork.SAndEAutoSendDiv = 0;
                // ���M�Ώۓ��Ӑ�i�J�n�j
                sAndESalSndLogWork.SendObjCustStart = salesHistoryCndtn.CustomerCodeSt;
                // ���M�Ώۓ��Ӑ�i�I���j
                sAndESalSndLogWork.SendObjCustEnd = salesHistoryCndtn.CustomerCodeEd;
                // �������M�敪
            }
            else
            {
                sAndESalSndLogWork.SAndEAutoSendDiv = 1;
                // ���M�Ώۓ��Ӑ�i�J�n�j
                sAndESalSndLogWork.SendObjCustStart = 0;
                // ���M�Ώۓ��Ӑ�i�I���j
                sAndESalSndLogWork.SendObjCustEnd = 0;
            }
            // ���M�Ώۋ敪
            if (salesHistoryCndtn.PdfOutDiv == 0)
            {
                sAndESalSndLogWork.SendObjDiv = 1; // ���o�͕��������M
            }
            else if (salesHistoryCndtn.PdfOutDiv == 1)
            {
                sAndESalSndLogWork.SendObjDiv = 2; // �o�͕������M��
            }
            else if (salesHistoryCndtn.PdfOutDiv == 2)
            {
                sAndESalSndLogWork.SendObjDiv = 0; // �S�ā��S��
            }

            if (sendResult == 0)
            {
                // ���M����
                sAndESalSndLogWork.SendResults = 0;
                // ���M�G���[���e
                sAndESalSndLogWork.SendErrorContents = string.Empty;
                // ���M�`�[����
                sAndESalSndLogWork.SendSlipCount = this._sendSlipCount;
                // ���M�`�[���א�
                sAndESalSndLogWork.SendSlipDtlCnt = this._sendSlipDtlCnt;
                // ���M�`�[���v���z
                sAndESalSndLogWork.SendSlipTotalMny = this._sendSlipTotalMny;
            }
            else
            {
                // ���M����
                //----- ADD �c���� 2013/08/12 Redmine#39695 ----->>>>>
                if (sendResult == 2) // ���M�f�[�^�Ȃ��̏ꍇ�A�X�e�[�^�X�́u2�v�ŌŒ�
                {
                    sAndESalSndLogWork.SendResults = 2;
                }
                else
                {
                    sAndESalSndLogWork.SendResults = 1;
                }
                //----- ADD �c���� 2013/08/12 Redmine#39695 -----<<<<<
                //sAndESalSndLogWork.SendResults = 1; // DEL �c���� 2013/08/12 Redmine#39695
                // ���M�G���[���e
                sAndESalSndLogWork.SendErrorContents = errMsg;
                // ���M�`�[����
                sAndESalSndLogWork.SendSlipCount = 0;
                // ���M�`�[���א�
                sAndESalSndLogWork.SendSlipDtlCnt = 0;
                // ���M�`�[���v���z
                sAndESalSndLogWork.SendSlipTotalMny = 0;
            }

            return sAndESalSndLogWork;
        }
        // ----- ADD �c���� 2013/06/26 -----<<<<<

        // ----- ADD zhuhh 2013/05/21 for Redmine#35639 ----->>>>>
        /// <summary>
        /// ���M�f�[�^�t�B�����̏������܂�
        /// </summary>
        /// <param name="value">�t�B����</param>
        /// <returns>���M�f�[�^�t�B����</returns>
        /// <remarks>
        /// <br>Note		: ���M�f�[�^�t�B�����̏������܂��B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
        /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
        /// <br>            : S&E�u���[�L���M�R�}���h</br>
        /// </remarks>
        private String CommandOrganization(ConnectInfoWork connectInfoWork, String fileName)
        {
            //----- DEL �c���� 2013/06/26 ---------->>>>>
            //String userName = connectInfoWork.ConnectUserId;
            //String password = connectInfoWork.ConnectPassword;
            //----- DEL �c���� 2013/06/26 ----------<<<<<
            //----- ADD �c���� 2013/06/26 ---------->>>>>
            String userName = connectInfoWork.SAndECnctUserId.Trim();
            String password = connectInfoWork.SAndECnctPass.Trim();
            //----- ADD �c���� 2013/06/26 ----------<<<<<
            String fileId = connectInfoWork.CnectFileId.Trim();// ADD zhuhh 2013/06/24 for Redmine#37017
            String mode = "S";
            String logLevel = "2";// ADD zhuhh 2013/06/24 for Redmine#37017
            int templength = fileName.Length;
            int tempof = fileName.LastIndexOf("\\");
            String dataName =SetFileNm( fileName.Substring(fileName.LastIndexOf("\\")+1 , (fileName.Length -1)- fileName.LastIndexOf("\\")));
            string httpHead = "";
            //HTTP/HTTPS �v���g�R��  
            if (connectInfoWork.DaihatsuOrdreDiv == 0)
            {
                httpHead = "http://";
            }
            else
            {
                httpHead = "https://";
            }
            String connectURL = httpHead+connectInfoWork.OrderUrl+connectInfoWork.StockCheckUrl;
            String dataPath = fileName.Substring(0, fileName.LastIndexOf("\\"));
            /* ----- DEL zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
            String logPath = dataPath;

            String command = "Java dtrcmd14"
                           + " -u " + userName
                           + " -p " + password
                           + " -m " + mode
                           + " -f " + dataName
                           + " -c " + connectURL
                           + " -d " + dataPath
                           + " -o " + logPath;
               ----- DEL zhuhh 2013/06/24 for Redmine#37017 -----<<<<<*/
            // ----- ADD zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
            String logName = GetLogName();
            bool verFlag = false;
            string errMsg = string.Empty; // ADD �c���� 2013/06/26
            String command = "";
            //String version = RunCmd("java -version", ref verFlag, 0); // DEL �c���� 2013/06/26
            String version = RunCmd("java -version", ref verFlag, 0, errMsg, 2000, 0); // ADD �c���� 2013/06/26
            if (!verFlag)
            {
                if (String.CompareOrdinal(version, "\"1.5.0\"") >= 0)
                {
                    command = "Java dtrcmd";
                }
                else
                {
                    //command = "Java dtrcmd14"; // DEL �c���� 2013/06/26
                    //----- ADD �c���� 2013/06/26 ----->>>>>
                    command = "<1.5.0";
                    return command;
                    //----- ADD �c���� 2013/06/26 -----<<<<<
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
            // ----- ADD zhuhh 2013/06/24 for Redmine#37017 -----<<<<<
            return command;
             
        }

        //----- ADD �c���� 2013/06/26 ------------------------->>>>>
        /// <summary>
        /// DOS Command�����̓]��
        /// </summary>
        /// <param name="inputStr">����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�I�v�V�����̏������܂��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private string ExchangeString(string inputStr)
        {
            string str = string.Empty;
            str = inputStr.Replace("\"", "\"\"\"");
            str = "\"" + str + "\"";

            return str;
        }
        //----- ADD �c���� 2013/06/26 -------------------------<<<<<

        /// <summary>
        /// �R�}���h�����s���܂��B
        /// </summary>
        /// <param name="command">�R�}���h</param>
        /// <param name="errFlag">�G���[�t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �R�}���h�����s���܂��B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
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

        // ----- ADD zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/06/24</br>
        /// <br>UpdateNote  : 2013/07/25 �c����</br>
        /// <br>            : Redmine#39145 �G���[��������S&E���㒊�o�f�[�^�X�V�����ꍇ������Ή�</br>
        /// </remarks>
        //private String RunCmd(String command, ref bool errFlag, int mode) // DEL �c���� 2013/06/26
        private String RunCmd(String command, ref bool errFlag, int mode, string errMsg, int timeout, int retryCnt) // ADD �c���� 2013/06/26
        {
            //string ret = null; // DEL �c���� 2013/06/26
            string ret = errMsg; // ADD �c���� 2013/06/26
            string err = null;
            string otp = null;

            //----- ADD �c���� 2013/06/26 ----->>>>>
            if (retryCnt == -1)
            {
                ret = LOGMSG_TIMEOUTERR;
                return ret;
            }
            //----- ADD �c���� 2013/06/26 -----<<<<<

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

                //----- ADD �c���� 2013/06/26 ----->>>>>
                if (timeout != 0 && !p.WaitForExit(timeout))
                {
                    p.Kill();

                    retryCnt = retryCnt - 1;
                    RunCmd(command, ref errFlag, mode, ret, timeout, retryCnt);
                }
                //----- ADD �c���� 2013/06/26 -----<<<<<
            }
            catch (Exception e)
            {
                e.ToString();
                //----- ADD �c���� 2013/06/26 ----->>>>>
                errFlag = true;
                ret = string.Empty;
                //----- ADD �c���� 2013/06/26 -----<<<<<
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/06/24</br>										
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
        // ----- ADD zhuhh 2013/06/24 for Redmine#37017 -----<<<<<
        // ----- ADD zhuhh 2013/05/21 for Redmine#35639 -----<<<<<

        /// <summary>
        /// ����I�[�v������
        /// </summary>
        /// <param name="connectInfo">����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����I�[�v���������܂��B</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<
        #endregion �� Private Method
    }
}
