//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������s�i�d�q����A�g�j���R���[�i�������j����N���X
// �v���O�����T�v   : ���������s�i�d�q����A�g�j���R���[�i�������j����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00  �쐬�S�� : ���O
// �� �� ��  2022/03/07   �C�����e : ���������s�i�d�q����A�g�j�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00  �쐬�S�� : ���O
// �� �� ��  2022/04/21   �C�����e : �d�q����2���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11800082-00   �쐬�S�� : ���O
// �� �� ��  2023/01/10    �C�����e : �d�q����A�g�i�������j��CSV�o�͏��ԑΉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ar = DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using System.Drawing.Printing;
using Broadleaf.Windows.Forms;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���������s�i�d�q����A�g�j���R���[�i�������j����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���R���[�i�������j�̈�����s���B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/08</br>
    /// <br>Update Note : 2022/04/21 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>  
    /// <br>Update Note : 2023/01/10 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11800082-00 �d�q����A�g�i�������j��CSV�o�͏��ԑΉ�</br>
    /// </remarks>
    public class PMKAU01001PA : IPrintProc, IDisposable
    {
        #region �� Constructor
        /// <summary>
        /// ���R���[�i�������j����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R���[�i�������j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        public PMKAU01001PA()
        {
            _reportCtrl = PMCMN02001CA.GetInstance();
            _reportCtrl.BeforePrintEditLine += new PMCMN02001CA.BeforePrintEditLineHandler(_reportCtrl_BeforePrintEditLine);
        }

        /// <summary>
        /// ���R���[�i�������j����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���R���[�i�������j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public PMKAU01001PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            _reportCtrl = PMCMN02001CA.GetInstance();
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�s�n�o";
        private const string ct_Extr_End = "�d�m�c";
        private const string ct_RangeConst = "�F{0} �` {1}";

        private const int EXSTATUS = -1;
        private const int INITSTATUS = 0;
        private const int INITCOUNT = 0;
        private const int FIRSTINDEX = 0;
        private const int INITVAR = 0;
        private const int COPYCOUNT = 0;
        private const int TAGPARAMSLENGTH = 1;
        private const int MARKLEN = 2;
        private const int DEPODTLGROPUCOUNT = 2;
        private const int CONSTAXLAYMETHODNOTAX = 9;

        private const string CT_LINEFORMAT = "74,";
        private const string CT_CUSTOMSTR = "Custom";
        private const string CT_FONT = "�l�r�S�V�b�N";
        private const string CT_TRIANGLE = "��";
        private const string CT_HOURMS = "_yyyyMMdd_HHmmss";
        private const string CT_YEARMD = "_yyyyMMdd_HHmmssff";
        private const string CT_YEARMD2 = "_yyyyMMddHHmmssff";// ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή�
        private const string CT_PDFFILE = ".pdf";
        private const string CT_FOOTERTITLEOFSLIP = "*�`�[�v*";
        private const string CT_FOOTERTITLEOFDAILY = "*���v*";
        private const string CT_FOOTERTITLEOFCUSTOMER = "*���Ӑ�v*";
        private const string CT_TAXTITLE = "�����";
        private const string CT_OFSTHISSALESTAXINCTTL = "*���㍇�v���z(�ō�)*";
        private const string CT_CARMNGCODETITLE = "�v���[�g�ԍ�";
        private const string CT_FOOTERTITLEOFTAX = "*�����*";
        private const string CT_FOOTERTITLEOFSLIPTAXINC = "*�ېō��v*";
        private const string CT_DEPOSITFOOTERTITLEOFSLIP = "*�����v*";
        private const string CT_FOOTERTITLEOFSLIPTAXINC2 = "�ېō��v";
        private const string CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        private const string CT_ASSEMBLYID = "PMKAU01001P";
        private const string CT_STOPERR = "��������𒆒f���܂����B";
        private const string CT_SEETINGERRNOPRT = "�ݒ肪�s���ȈׁA����o���܂���ł����B";
        private const string CT_TITLE = "������";
        private const string CT_NOTEXIST = "�����݂��܂���B";
        private const string CT_BILLALLST = "�����S�̐ݒ�";
        private const string CT_BILLINITST = "���������l�ݒ�";
        private const string CT_BILLPRTPATTERNST = "����������p�^�[���ݒ�";
        private const string CT_FREPRTPSET = "���R���[�󎚈ʒu�ݒ�";
        private const string CT_PRINTERST = "�v�����^�ݒ�";
        private const string CT_BILLDATA = "�������f�[�^";
        private const string CT_SEETINGERRNODATA = "�ݒ肪�s���ȈׁA����ł��Ȃ��f�[�^������܂����B";

        /// <summary>
        /// �t�@�C�����p�^�[��
        /// </summary>
        private enum FileNameDivEnum : int
        {
            /// <summary>�p�^�[���P</summary>
            Pattern1 = 1,
            /// <summary>�p�^�[���Q</summary>
            Pattern2 = 2,
            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
            /// <summary>�p�^�[���R</summary>
            Pattern3 = 3
            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
        }
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private bool _existsSalesTotalFooter;
        private bool _existsDepositTotalFooter;
        private int _feedAddCount;
        private string _footerTitleOfSlip;
        private string _footerTitleOfDaily;
        private string _footerTitleOfCustomer;
        private string _taxTitle;
        private string _ofsThisSalesTaxIncTtl;
        private Dictionary<int, List<PrintMarkScheme>> _printMarkDic;
        private List<string> _pdfPathList;
        private DateTime _OutPutDateTime;
        private List<string> _previewPdfPathList;
        private PMCMN02001CA _reportCtrl;
        private bool _printCancelFlag; // ����L�����Z���t���O
        private string _reportTitle; // ���[�^�C�g��
        private string _carmngCodeTitle;
        private string _slipTtlTaxTitle;
        private string _footerTitleOfTax;
        private string _footerTitleOfSlipTaxInc;
        private bool _existsSalesFooter;
        private bool _existsSalesFooter2;
        private bool _existsSalesFooter3;
        private bool _existsSalesHeader2;
        private Dictionary<string, Document> _documentByTypeDic;
        private Dictionary<string, Document> _orgDocuments;
        private List<ar.ActiveReport3> _prtRptList;
        private string _depositFooterTitleOfSlip;
        private string _footerTitleOfTax2;
        private string _footerTitleOfSlipTaxInc2;
        private bool _existsMesh;
        private int _lineCount;
        private int _formFeedLineCount = 0;
        private int _detailPrtCount = 1;
        private int _depoDtlPrcPrtDiv = 0;
        #endregion �� Private Member

        /// <summary>
        /// ���b�Z�[�W�ύX����
        /// </summary>
        public event EventHandler MessageChange;

        #region �� Exception Class
        /// <summary>
        /// ��O�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��O�N���X</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public StockMoveException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region �� Public Property
            /// <summary> �X�e�[�^�X�v���p�e�B </summary>
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion �� Exception Class

        #region �� IPrintProc �����o
        #region �� Public Property
        /// <summary>
        /// �o�c�e�o�̓p�X�ꗗ�v���p�e�B
        /// </summary>
        public List<string> PdfPathList
        {
            get { return _pdfPathList; }
            set { _pdfPathList = value; }
        }
        /// <summary>
        /// �v���r���[�p�o�c�e�o�̓p�X�ꗗ�v���p�e�B
        /// </summary>
        public List<string> PreviewPdfPathList
        {
            get { return _previewPdfPathList; }
            set { _previewPdfPathList = value; }
        }
        /// <summary>
        /// ������擾�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        /// <summary>
        /// �^�C�v�ʃh�L�������g�f�B�N�V���i��
        /// </summary>
        public Dictionary<string, Document> DocumentByTypeDic
        {
            get
            {
                if (_documentByTypeDic == null)
                {
                    _documentByTypeDic = new Dictionary<string, Document>();
                }
                return _documentByTypeDic;
            }
            set { _documentByTypeDic = value; }
        }
        /// <summary>
        /// �o�͓���
        /// </summary>
        public DateTime OutPutDateTime
        {
            get { return _OutPutDateTime; }
            set { _OutPutDateTime = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ��������J�n
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������J�n����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public int StartPrint()
        {
            int status = PrintMain();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, "PMKAU01001P", "��������𒆒f���܂����B", 0, MessageBoxButtons.OK);
                form.TopMost = false;
            }
            return status;
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� Private Member
        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ����������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// <br>Update Note : 2022/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br> 
        /// <br>Update Note : 2023/01/10 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11800082-00 �d�q����A�g�i�������j��CSV�o�͏��ԑΉ�</br> 
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            _reportTitle = "������";

            ExtrInfo_EBooksDemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_EBooksDemandTotal);
            if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern2)
            {
                _reportTitle = string.Empty;
            }

            try
            {
                if ((this._printInfo.jyoken is ExtrInfo_EBooksDemandTotal) == false)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", "�ݒ肪�s���ȈׁA����o���܂���ł����B", 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // ������[�h���ݒ�̏ꍇ�̃f�t�H���g�ݒ�
                # region [������[�h���ݒ�]
                if (this._printInfo.printmode == 0)
                {
                    // 1:�v���r���[����
                    this._printInfo.prevkbn = 1;
                    // 1:�v�����^�i���v���r���[����Ȃ̂Ŏ��ۂɂ͈�����Ȃ��j
                    this._printInfo.printmode = 1;
                }
                # endregion

                // �^�C�v�ʈ���h�L�������g�f�B�N�V���i��
                Dictionary<string, Document> documentsDic = new Dictionary<string, Document>();
                // �������ʃh�L�������g�f�B�N�V���i��
                Dictionary<string, Document> orgDocuments = new Dictionary<string, Document>();

                // PDF�o�͈ꗗ���X�g
                _pdfPathList = new List<string>();

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataTable billData = printDataSet.Tables[PMKAU01002AB.CT_Tbl_BillList];

                // ���o����(E��A)�ŃL�����Z�����ꂽ�ꍇ�̃L�����Z������
                if (billData.Rows.Count > 0)
                {
                    if ((bool)billData.Rows[0][PMKAU01002AB.CT_BillList_ExtractCancel] == true)
                    {
                        // �L�����Z��
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }

                // �G���[���R�f�B�N�V���i��
                Dictionary<string, bool> errReasonDic = new Dictionary<string, bool>();
                errReasonDic.Add(PMKAU01002AB.CT_BillList_DmdPrtPtn, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_FrePrtPSet, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_FrePBillHead, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_PrtManage, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_BillAllSt, false);
                errReasonDic.Add(PMKAU01002AB.CT_BillList_BillPrtSt, false);

                try
                {
                    string prevOutputFormFileName = string.Empty;
                    _printCancelFlag = false;
                    DataView billDataView = new DataView(billData);

                    //----------------------------------------------------------------
                    // �������̃\�[�g��
                    //----------------------------------------------------------------
                    # region [�w�b�_�̃\�[�g��]
                    int sortOrder = 0;
                    int customerAgentDivCd = 0;
                    if (this._printInfo.jyoken is ExtrInfo_EBooksDemandTotal)
                    {
                        // ������
                        sortOrder = cndtn.SortOrder;
                        customerAgentDivCd = cndtn.CustomerAgentDivCd;
                    }

                    switch (sortOrder)
                    {
                        // �S���ҏ�
                        case 1:
                            {
                                if (customerAgentDivCd == 0)
                                {
                                    // ���Ӑ�S����
                                    billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_CustomerAgentCd, // �S����
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                                }
                                else
                                {
                                    // �W���S����
                                    billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_BillCollecterCd, // �W���S����
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                                }
                            }
                            break;
                        // �n�揇
                        case 2:
                            {
                                billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_SalesAreaCode, // �n��
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                            }
                            break;
                        // ���Ӑ揇
                        default:
                            {
                                billDataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}",
                                                                        PMKAU01002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU01002AB.CT_BillList_ClaimCode,
                                                                        PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU01002AB.CT_BillList_CustomerCode);
                            }
                            break;
                    }
                    # endregion

                    //---ADD 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��--->>>>>
                    //_printInfo���̈���f�[�^�u_printInfo.rdData�v��ύX����u�������̃\�[�g���ǉ��v
                    DataSet rdDataDS = new DataSet();
                    rdDataDS.Tables.Add(billDataView.ToTable());
                    this._printInfo.rdData = rdDataDS;
                    //---ADD 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��---<<<<<

                    //----------------------------------------------------------------
                    // �u�e�𐿋���Ɋ܂߂�v�Ȃ�ΐe���R�[�h�����O
                    //----------------------------------------------------------------
                    # region [������Ɋ܂߂�A�Ή�]
                    // ���_�Ⴂor���Ӑ�Ⴂ��ΏۂƂ���i���ʓI�ɏW�v���R�[�h���Ώہj
                    billDataView.RowFilter = string.Format("{0}<>{1} OR {2}<>{3}",
                                                PMKAU01002AB.CT_BillList_AddUpSecCode,
                                                PMKAU01002AB.CT_BillList_ResultsSectCd,
                                                PMKAU01002AB.CT_BillList_ClaimCode,
                                                PMKAU01002AB.CT_BillList_CustomerCode);
                    # endregion

                    if (_printCancelFlag)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }

                    // ������ɑS�Ẵ��|�[�g���������ׂ̃��X�g
                    if (_prtRptList != null)
                    {
                        foreach (ar.ActiveReport3 report in _prtRptList)
                        {
                            report.Dispose();
                        }
                    }
                    _prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();

                    //----------------------------------------------------------------
                    // �������̈��
                    //----------------------------------------------------------------
                    foreach (DataRowView billRowView in billDataView)
                    {
                        # region [�������P��]
                        if (_printCancelFlag)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        DataRow billRow = billRowView.Row;

                        // �K�v�}�X�^��񂪂Ȃ���΁u���R���[(������)�v�Ƃ��Ă͑ΏۊO�ɂ��܂��B
                        bool errCheck = false;
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_DmdPrtPtn])) { errReasonDic[PMKAU01002AB.CT_BillList_DmdPrtPtn] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_FrePrtPSet])) { errReasonDic[PMKAU01002AB.CT_BillList_FrePrtPSet] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_FrePBillHead])) { errReasonDic[PMKAU01002AB.CT_BillList_FrePBillHead] = true; errCheck = true; }
                        if (_printInfo.printmode != 2 && IsNull(billRow[PMKAU01002AB.CT_BillList_PrtManage])) { errReasonDic[PMKAU01002AB.CT_BillList_PrtManage] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_BillAllSt])) { errReasonDic[PMKAU01002AB.CT_BillList_BillAllSt] = true; errCheck = true; }
                        if (IsNull(billRow[PMKAU01002AB.CT_BillList_BillPrtSt])) { errReasonDic[PMKAU01002AB.CT_BillList_BillPrtSt] = true; errCheck = true; }
                        if (errCheck)
                        {
                            continue;
                        }

                        // ����������p�^�[���ݒ� �擾
                        DmdPrtPtnWork dmdPrtPtn = (DmdPrtPtnWork)billRow[PMKAU01002AB.CT_BillList_DmdPrtPtn];
                        // ���R���[�󎚈ʒu�ݒ� �擾
                        FrePrtPSetWork frePrtPSet = (FrePrtPSetWork)billRow[PMKAU01002AB.CT_BillList_FrePrtPSet];
                        // �v�����^�Ǘ��ݒ� �擾
                        PrtManage prtManage = null;
                        if (!IsNull(billRow[PMKAU01002AB.CT_BillList_PrtManage]))
                        {
                            prtManage = (PrtManage)billRow[PMKAU01002AB.CT_BillList_PrtManage];
                        }
                        // ��������ݒ� �擾
                        BillPrtStWork billPrtSt = (BillPrtStWork)billRow[PMKAU01002AB.CT_BillList_BillPrtSt];

                        // ����Ώۃe�[�u�������i�P�������P�ʁj
                        DataTable printData = PMKAU01002AC.CreatePrintDataTable();
                        string outFileName = frePrtPSet.OutputFormFileName.Trim();
                        outFileName = this._printInfo.prpid;


                        if (prevOutputFormFileName != frePrtPSet.OutputFormFileName.Trim())
                        {
                            _existsSalesTotalFooter = false;
                            _existsDepositTotalFooter = false;
                            _existsSalesFooter = false;
                            _existsSalesFooter2 = false;
                            _existsSalesFooter3 = false;
                            _existsSalesHeader2 = false;
                            _existsMesh = false;
                            _feedAddCount = 0; // �Q�Ŗڈȍ~�̍s�������̓f�t�H���g0
                            _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                            this.SearchPrintLayout(frePrtPSet);
                        }
                        prevOutputFormFileName = outFileName;

                        _depoDtlPrcPrtDiv = dmdPrtPtn.DepoDtlPrcPrtDiv;
                        _formFeedLineCount = frePrtPSet.FormFeedLineCount;
                        _detailPrtCount = 1;

                        // ������C�A�E�g�p�����[�^
                        PMKAU01002AC.BillDmdPrintParameter parameter = new PMKAU01002AC.BillDmdPrintParameter();
                        # region [parameter]
                        parameter.OtherFeedAddCount = _feedAddCount;
                        parameter.ExistsSalesTotalFooter = _existsSalesTotalFooter;
                        parameter.ExistsDepositTotalFooter = _existsDepositTotalFooter;
                        parameter.FooterTitleOfSlip = _footerTitleOfSlip;
                        parameter.FooterTitleOfDaily = _footerTitleOfDaily;
                        parameter.FooterTitleOfCustomer = _footerTitleOfCustomer;
                        parameter.TaxTitle = _taxTitle;
                        parameter.OfsThisSalesTaxIncTtl = _ofsThisSalesTaxIncTtl;
                        parameter.CarmngCodeTitle = _carmngCodeTitle;
                        parameter.SlipTtlTaxTitle = _slipTtlTaxTitle;
                        parameter.FooterTitleOfTax = _footerTitleOfTax;
                        parameter.FooterTitleOfSlipTaxInc = _footerTitleOfSlipTaxInc;
                        parameter.ExistsSalesFooter = _existsSalesFooter;
                        parameter.ExistsSalesFooter2 = _existsSalesFooter2;
                        parameter.ExistsSalesFooter3 = _existsSalesFooter3;
                        parameter.ExistsSalesHeader2 = _existsSalesHeader2;
                        parameter.DepositFooterTitleOfSlip = _depositFooterTitleOfSlip;
                        parameter.FooterTitleOfSlipTaxInc2 = _footerTitleOfSlipTaxInc2;
                        parameter.FooterTitleOfTax2 = _footerTitleOfTax2;
                        # endregion

                        PMKAU01002AC.CopyToPrintDataTable(ref printData, this._printInfo.jyoken, billRow, parameter);

                        // ����f�[�^��ŒP�ʂɕ�����
                        List<DataTable> printDataList = PMKAU01002AC.DevelopPrintDataList(ref printData);
                        if (printData != null)
                        {
                            printData.Dispose();
                        }

                        # region [����h�L�������g��������]
                        using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
                        {
                            ar.ActiveReport3 prtRpt = null;

                            // ���ʖ����̎擾
                            int copyCount;
                            # region [copyCount��dmdPrtPtn.CopyCount]
                            // ���ʖ������Z�b�g
                            if (dmdPrtPtn.CopyCount != 0)
                            {
                                // ����=1�@��1��(�T��0��)
                                // ����=2�@��2��(�T��1��)
                                copyCount = dmdPrtPtn.CopyCount;
                            }
                            else
                            {
                                // ��ۂ͂P�ɕ␳����B
                                copyCount = 1;
                            }
                            # endregion

                            // ���ʕ��J��Ԃ�
                            for (int copyIndex = 0; copyIndex < copyCount; copyIndex++)
                            {

                                // ���C�A�E�g�Ⴂ�J��Ԃ�
                                for (int pageIndex = 0; pageIndex < printDataList.Count; pageIndex++)
                                {
                                    if (_printCancelFlag)
                                    {
                                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    }

                                    printData = printDataList[pageIndex];
                                    bool isParent = PMKAU01002AC.IsParent(printData);
                                    int consTaxLayMethod = PMKAU01002AC.GetConsTaxLayMethod(printData);

                                    prtRpt = new ar.ActiveReport3();
                                    // ��ŉ���ł���悤�ɑޔ�
                                    _prtRptList.Add(prtRpt);

                                    # region [���|�[�g��{�ݒ�]
                                    stream.Position = 0;
                                    prtRpt.LoadLayout(stream);
                                    prtRpt.Script = string.Empty; // �X�N���v�g�폜
                                    SetMargin(prtRpt, dmdPrtPtn);
                                    SetPrinterInfo(prtRpt.Document, prtManage);
                                    SFANL08235CE.SetValidPaperKind(prtRpt);
                                    _reportCtrl.SetReportProps(ref prtRpt); // ���[���ʐݒ�
                                    prtRpt.DataSource = printData;
                                    prtRpt.DataMember = printData.TableName;
                                    SetReportPropsByPrinting(ref prtRpt); // ���[�ɒǉ��Őݒ�
                                    # endregion

                                    # region [���ʑΉ�]
                                    // ���ʎ��̃^�C�g�������ւ�
                                    // �i��DataTable������������̂ŁA���ʂQ���ڂ̎��������s����Ηǂ��j
                                    if (copyIndex == 1)
                                    {
                                        PMKAU01002AC.SetCopyTitle(ref printData);
                                    }

                                    # endregion

                                    # region [���׃f�U�C���Ή�]
                                    ReflectReportDesign(ref prtRpt, dmdPrtPtn, billPrtSt, pageIndex, isParent, consTaxLayMethod);
                                    # endregion

                                    // ������s
                                    prtRpt.Run();

                                    // �L����
                                    PrintMarks(prtRpt, dmdPrtPtn);

                                    // �^�C�v�ʂɃh�L�������g���܂Ƃ߂�
                                    if (!documentsDic.ContainsKey(dmdPrtPtn.SlipPrtSetPaperId))
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo(ref document, prtRpt, prtManage);
                                        documentsDic.Add(dmdPrtPtn.SlipPrtSetPaperId, document);
                                    }
                                    documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange(prtRpt.Document.Pages);

                                    // �������ʂɃh�L�������g���܂Ƃ߂�
                                    string derivedNo = string.Empty;
                                    if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern2)
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNoForBatch(billRow);
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>
                                    else if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern3)
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNoForPattern3(billRow);
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                    else
                                    {
                                        derivedNo = PMKAU01002AC.GetDocumentDerivedNo(billRow);
                                    }
                                    if (!orgDocuments.ContainsKey(derivedNo))
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo(ref document, prtRpt, prtManage);
                                        orgDocuments.Add(derivedNo, document);
                                    }
                                    orgDocuments[derivedNo].Pages.AddRange(prtRpt.Document.Pages);

                                }
                            }
                            stream.Close();
                        }

                        # endregion

                        if (printDataList != null)
                        {
                            foreach (DataTable table in printDataList)
                            {
                                table.Dispose();
                            }
                        }

                        # endregion
                    }

                    if (this.MessageChange != null)
                    {
                        // ���b�Z�[�W�ύX����
                        MessageChange(this, new EventArgs());
                    }

                    # region [����^�o�c�e�o��]
                    if (_printCancelFlag)
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    if (_printInfo.printmode == 1 || _printInfo.printmode == 3)
                    {
                        //-------------------------------------------
                        // �@����F�^�C�v���Ɉ�����s
                        //-------------------------------------------
                        if (_printCancelFlag)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        foreach (string typeName in documentsDic.Keys)
                        {
                            ExecutePrint(documentsDic[typeName], typeName, null);
                        }
                    }
                    if (_printInfo.printmode == 2 || _printInfo.printmode == 3)
                    {
                        //-------------------------------------------
                        // �A�o�c�e�F�������ʏo��
                        //-------------------------------------------
                        _pdfPathList = new List<string>();
                        foreach (string derivedNo in orgDocuments.Keys)
                        {
                            if (_printCancelFlag)
                            {
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                            ExecutePrint(orgDocuments[derivedNo], derivedNo, _pdfPathList);
                        }
                    }
                    # endregion
                }
                finally
                {
                }

                string errorMessage = string.Empty;
                if (errReasonDic[PMKAU01002AB.CT_BillList_BillAllSt]) errorMessage += "�����S�̐ݒ�" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_BillPrtSt]) errorMessage += "���������l�ݒ�" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_DmdPrtPtn]) errorMessage += "����������p�^�[���ݒ�" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_FrePrtPSet]) errorMessage += "���R���[�󎚈ʒu�ݒ�" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_PrtManage]) errorMessage += "�v�����^�ݒ�" + Environment.NewLine;
                if (errReasonDic[PMKAU01002AB.CT_BillList_FrePBillHead]) errorMessage += "�������f�[�^" + Environment.NewLine;

                if (errorMessage != string.Empty)
                {
                    errorMessage = "�ݒ肪�s���ȈׁA����ł��Ȃ��f�[�^������܂����B" + Environment.NewLine + Environment.NewLine + errorMessage;
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", errorMessage, 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // �^�C�v�ʃh�L�������g���Z�b�g(�O������Q�Ƃł���悤�ɂ���)
                _documentByTypeDic = documentsDic;
                // ����h�L�������g�ޔ�(���Ƃ�Dispose�����)
                _orgDocuments = orgDocuments;
            }
            catch (Exception ex)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU01001P", ex.Message, 0, MessageBoxButtons.OK);
                form.TopMost = false;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // �ԋp�O�ɒ��[��������������(�Œ�)
            _printInfo.prpnm = _reportTitle;


            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        # region [���|�[�g�ɑ΂��钠�[�����ݒ菈��]
        /// <summary>
        /// ���[�����ݒ菈��
        /// </summary>
        /// <param name="prtRpt">ActiveReport</param>
        /// <remarks>
        /// <br>Note        : ���[�����ݒ菈�����s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetReportPropsByPrinting(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt)
        {
            if (_existsMesh)
            {
                // �s�J�E���g��������
                _lineCount = 0;

                // "����"�Z�N�V�������擾
                ar.Section detail = prtRpt.Sections["Detail1"];
                if (detail != null && detail.Type == DataDynamics.ActiveReports.SectionType.Detail)
                {
                    // "����"�Z�N�V�����̈���O�C�x���g��ݒ�
                    detail.BeforePrint += new EventHandler(ReportDetail_BeforePrint);

                    // ���|�[�g�̉��y�[�W�C�x���g��ݒ�
                    prtRpt.PageEnd += new EventHandler(Report_PageEnd);
                }
            }
        }
        /// <summary>
        /// ���׃Z�N�V��������O����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Note        : ���׃Z�N�V��������O�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void ReportDetail_BeforePrint(object sender, EventArgs e)
        {
            if (sender is ar.Section)
            {
                ar.Section detail = (sender as ar.Section);
                foreach (ar.ARControl control in detail.Controls)
                {
                    // 74:�Ԋ|���̐���
                    if (control != null &&
                         control is ar.Shape &&
                         control.Tag is string &&
                         (control.Tag as string).StartsWith("74,"))
                    {
                        // 0,2,4,�c�s�� �� �󎚂��Ȃ�
                        // 1,3,5,�c�s�� �� �󎚂���
                        control.Visible = ((_lineCount % 2) != 0);

                        // ���ėp�I�ł͖��������ۂɉe���͖����Ǝv����̂ŁA
                        //   �������ׂ̈�break����B
                        break;
                    }
                }
            }
            _lineCount++;
        }
        /// <summary>
        /// ���|�[�g���y�[�W�㏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g</param>
        /// <remarks>
        /// <br>Note        : ���|�[�g���y�[�W�㏈�����s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void Report_PageEnd(object sender, EventArgs e)
        {
            // ������
            _lineCount = 0;
        }
        # endregion
        /// <summary>
        /// ����L�����Z��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����L�����Z�����s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks> 
        public void Cancel()
        {
            // ����L�����Z���t���O�𗧂Ă�
            _printCancelFlag = true;
        }

        /// <summary>
        /// PDF�L�����Z���f���Q�[�g��`
        /// </summary>
        /// <returns></returns>
        public delegate bool PDFCancelDelegate();

        /// <summary>
        /// PDF�o�͏���
        /// </summary>
        /// <param name="printInfo">������</param>
        /// <param name="documentsDic">�h�L�������gDic</param>
        /// <param name="cancelDelegate">PDF�L�����Z���f���Q�[�g</param>
        /// <returns>previewPdfPathList</returns>
        /// <remarks>
        /// <br>Note        : PDF�o�͏������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks> 
        public static List<string> PrintPDF(ref SFCMN06002C printInfo, Dictionary<string, Document> documentsDic, PDFCancelDelegate cancelDelegate)
        {
            List<string> previewPdfPathList = new List<string>();

            // ���[�^�C�g��
            string reportTitle = "������";

            foreach (string typeName in documentsDic.Keys)
            {
                // �L�����Z��(delegate�ɂ��Ăяo�����Ŕ��f)
                if (cancelDelegate != null && cancelDelegate())
                {
                    break;
                }

                //--------------------------------------------------
                // PDF���[��
                //--------------------------------------------------
                # region [PDF���[��]
                // PDF���[��
                printInfo.prpnm = string.Format("{0}({1})", reportTitle, typeName);

                // ���ʏ����ݒ�
                SFCMN00293UC commonInfo;
                SetPrintCommonInfo(out commonInfo, printInfo, reportTitle);
                printInfo.pdftemppath = commonInfo.PdfFullPath;
                if (previewPdfPathList != null)
                {
                    previewPdfPathList.Add(commonInfo.PdfFullPath);
                }
                # endregion

                //--------------------------------------------------
                // PDF�G�N�X�|�[�g����
                //--------------------------------------------------
                # region [PDF�G�N�X�|�[�g����]
                Document doc = documentsDic[typeName];
                DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                try
                {
                    pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
                                            | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));

                    pdfExport1.Export(doc, printInfo.pdftemppath);
                    printInfo.status = 0;
                }
                catch
                {
                    printInfo.status = 9;
                }
                finally
                {
                    pdfExport1.Dispose();
                }
                # endregion

                //--------------------------------------------------
                // �o�͗����Ǘ� �ǉ�
                //--------------------------------------------------
                # region [�o�͗����Ǘ� �ǉ�]
                if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (printInfo.printmode)
                    {
                        case 1:  // �v�����^
                            break;
                        case 2:  // �o�c�e
                            {
                                // �o�c�e�\���t���OON
                                printInfo.pdfopen = true;
                            }
                            break;
                        case 3:  // ����(�v�����^ + �o�c�e)
                            {
                                // �o�c�e�\���t���OON
                                printInfo.pdfopen = true;

                                // �o�͗����Ǘ��ɒǉ�
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(printInfo.key, reportTitle, reportTitle, printInfo.pdftemppath);
                                pdfHistoryControl.Dispose();
                            }
                            break;
                    }
                }
                # endregion
            }

            return previewPdfPathList;
        }
        /// <summary>
        /// ������ʏ��ݒ�(static�p)
        /// </summary>
        /// <param name="commonInfo">���ʏ��</param>
        /// <param name="printInfo">������</param>
        /// <param name="reportTitle">���[�^�C�g��</param>
        /// <remarks>
        /// <br>Note        : ������ʏ��ݒ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private static void SetPrintCommonInfo(out SFCMN00293UC commonInfo, SFCMN06002C printInfo, string reportTitle)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDF�p�X�擾
            string pdfPath = "";
            string pdfName = "";

            // �v�����^��
            commonInfo.PrinterName = string.Empty;
            // ���[��
            commonInfo.PrintName = reportTitle;
            // ������[�h

            try
            {
                commonInfo.PrintMode = printInfo.printmode;
            }
            catch
            {
                commonInfo.PrintMode = 1;
            }

            // ��������\��
            commonInfo.PrintMax = 0;

            status = cmnCommon.GetPdfSavePathName(printInfo.prpnm, ref pdfPath, ref pdfName);
            printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = 0;
            // ���]��
            commonInfo.MarginsLeft = 0;
        }

        /// <summary>
        /// ����h�L�������g���ݒ�
        /// </summary>
        /// <param name="printDocument">����p�h�L�������g</param>
        /// <param name="prtRpt">����Ώ�</param>
        /// <param name="prtManage">����Ǘ��Ώ�</param>
        /// <remarks>
        /// <br>Note        : ����h�L�������g���ݒ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SettingDocumentInfo(ref Document printDocument, DataDynamics.ActiveReports.ActiveReport3 prtRpt, PrtManage prtManage)
        {
            if (prtRpt != null)
            {
                SetPrinterInfo(printDocument, prtManage);

                // �p���̎�ނ��w��
                printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                {
                    printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                }
                // �p�������i�c�E���j�̐ݒ�
                if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                {
                    printDocument.Printer.Landscape = true;
                }
            }
        }


        /// <summary>
        /// �L���������
        /// </summary>
        /// <param name="prtRpt">����Ώ�</param>
        /// <param name="dmdPrtPtn">����p���[�N</param>
        /// <remarks>
        /// <br>Note        : �L���������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void PrintMarks(DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn)
        {
            if (_printMarkDic == null || _printMarkDic.Count == 0) return;

            float adjustX = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            float adjustY = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);

            foreach (Page page in prtRpt.Document.Pages)
            {
                // �܂�Ԃ��}�[�N(>)
                foreach (PrintMarkScheme mark in _printMarkDic[64])
                {
                    page.TextAngle = 900; // ���v���90.0�x
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font("�l�r�S�V�b�N", mark.Size);
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    page.DrawText("��", new System.Drawing.RectangleF(mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f));
                }

                // �܂�Ԃ��}�[�N(<)
                foreach (PrintMarkScheme mark in _printMarkDic[65])
                {
                    page.TextAngle = -900; // �����v���90.0�x
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font("�l�r�S�V�b�N", mark.Size);
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    page.DrawText("��", new System.Drawing.RectangleF(mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f));
                }
            }
        }
        /// <summary>
        /// ���C�A�E�g���擾�i�P�y�[�W�ڂ̃w�b�_�������ו��ɑ������邩�Ȃǁj
        /// </summary>
        /// <param name="frePrtPSet">���C�A�E�g���</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���C�A�E�g���擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SearchPrintLayout(FrePrtPSetWork frePrtPSet)
        {
            // �����l�ݒ�
            _feedAddCount = 0; // �Q�Ŗڈȍ~�̍s�������̓f�t�H���g0
            _footerTitleOfSlip = "*�`�[�v*";
            _footerTitleOfDaily = "*���v*";
            _footerTitleOfCustomer = "*���Ӑ�v*";
            _taxTitle = "�����";
            _ofsThisSalesTaxIncTtl = "*���㍇�v���z(�ō�)*";
            _carmngCodeTitle = "�v���[�g�ԍ�";
            _footerTitleOfTax = "*�����*";
            _footerTitleOfSlipTaxInc = "*�ېō��v*";
            _slipTtlTaxTitle = "�����";
            _depositFooterTitleOfSlip = "*�����v*";
            _footerTitleOfSlipTaxInc2 = "�ېō��v";
            _footerTitleOfTax2 = "�����";
            Dictionary<string, string> reportItemDic = new Dictionary<string, string>();

            // ���C�A�E�g���̎�荞��
            using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
            {
                // ���C�A�E�g���擾
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout(stream);


                foreach (ar.Section section in prtRpt.Sections)
                {
                    foreach (ar.ARControl control in section.Controls)
                    {
                        // �f�B�N�V���i���ǉ�
                        if (control is ar.TextBox && control.Tag is string)
                        {
                            string dataFieldName = control.DataField.ToUpper();
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                        }
                        else if (control is ar.Barcode)
                        {
                            string dataFieldName = (control as ar.Barcode).DataField.ToUpper();
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                        }
                        else if (control is ar.Label)
                        {
                            ar.Label label = (control as ar.Label);
                            const string subReportDataField = "FREEPRINT.SUBREPORT";

                            // ���|�[�g���ڃf�B�N�V���i���ɒǉ�
                            if (!reportItemDic.ContainsKey(subReportDataField))
                            {
                                reportItemDic.Add(subReportDataField, subReportDataField);
                            }
                        }

                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring(0, 3);

                        switch (tagText)
                        {
                            // 53:����t�b�^
                            case "53,":
                                _existsSalesFooter = true;
                                break;
                            // ����W�v�t�b�^
                            case "56,":
                                _existsSalesTotalFooter = true;
                                break;
                            // �����W�v�t�b�^
                            case "57,":
                                _existsDepositTotalFooter = true;
                                break;
                            // 58:���C�A�E�g����i�P�y�[�W�ځj
                            case "58,":
                                _feedAddCount += 1; // ���ɏo�׍ς݂̋�ڲ��Ă̌݊�����ۂ���,�{�P����
                                _feedAddCount += GetFeedAddCount(control);
                                break;
                            // 60:�ӏ���Ń^�C�g��
                            case "60,":
                                _taxTitle = (control as ar.Label).Text;
                                break;
                            // 61:�^�C�g���ݒ�i�`�[�v�j
                            case "61,":
                                _footerTitleOfSlip = (control as ar.Label).Text;
                                break;
                            // 62:�^�C�g���ݒ�i���v�j
                            case "62,":
                                _footerTitleOfDaily = (control as ar.Label).Text;
                                break;
                            // 63:�^�C�g���ݒ�i���Ӑ�v�j
                            case "63,":
                                _footerTitleOfCustomer = (control as ar.Label).Text;
                                break;
                            // 64:�܂�Ԃ��}�[�N(>)
                            case "64,":
                                if ((control as ar.Label).Visible)
                                {
                                    AddToMarkDic(64, (control as ar.Label));
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 65:�܂�Ԃ��}�[�N(<)
                            case "65,":
                                if ((control as ar.Label).Visible)
                                {
                                    AddToMarkDic(65, (control as ar.Label));
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 66:�^�C�g���ݒ�i�v���[�g�ԍ��j
                            case "66,":
                                _carmngCodeTitle = (control as ar.Label).Text;
                                break;
                            // 2010/05/25 Add >>>
                            // 67:�`�[���v����Ń��e����
                            case "67,":
                                _slipTtlTaxTitle = (control as ar.Label).Text;
                                break;
                            //68�F����t�b�^�Q
                            case "68,":
                                _existsSalesFooter2 = true;
                                break;
                            //69:�^�C�g���ݒ�(�����)
                            case "69,":
                                _footerTitleOfTax = (control as ar.Label).Text;
                                break;
                            //70�F�^�C�g���ݒ�(�ېō��v)
                            case "70,":
                                _footerTitleOfSlipTaxInc = (control as ar.Label).Text;
                                break;
                            //71�F���E�㔄�㍇�v���z(�ō�)�^�C�g��
                            case "71,":
                                _ofsThisSalesTaxIncTtl = (control as ar.Label).Text;
                                break;
                            //72�F����t�b�^�R(�R������ʗp)
                            case "72,":
                                _existsSalesFooter3 = true;
                                break;
                            //73�F����w�b�_�Q(�R������ʗp)
                            case "73,":
                                _existsSalesHeader2 = true;
                                break;
                            //74:���זԊ|��
                            case "74,":
                                _existsMesh = true;
                                break;
                        }
                    }
                }

                PMKAU01002AC.ReportItemDic = reportItemDic;

                // �X�g���[������
                stream.Close();
            }
        }
        /// <summary>
        /// �L���f�B�N�V���i���ɒǉ�
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="arLabel">���x��</param>
        /// <remarks>
        /// <br>Note        : �L���f�B�N�V���i���ɒǉ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void AddToMarkDic(int key, ar.Label arLabel)
        {
            string text = arLabel.Text;

            if (text.Contains(","))
            {
                string[] subText = text.Split(',');
                if (subText.Length >= 2)
                {
                    float posX = ToSingle(subText[0]);
                    float posY = ToSingle(subText[1]);

                    // �f�B�N�V���i����������΍쐬
                    if (_printMarkDic == null)
                    {
                        _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                    }
                    // �f�B�N�V���i�����Ƀ��X�g��������ΐ���
                    if (!_printMarkDic.ContainsKey(key))
                    {
                        _printMarkDic.Add(key, new List<PrintMarkScheme>());
                    }

                    // �f�B�N�V���i�������X�g�ɒǉ�
                    _printMarkDic[key].Add(new PrintMarkScheme(new PointF(posX, posY), arLabel.ForeColor, arLabel.Font.Size));
                }
            }
        }
        /// <summary>
        /// �����񁨐��l(float)�ϊ�
        /// </summary>
        /// <param name="text">�ϊ��e�L�X�g</param>
        /// <returns>�ϊ�����</returns>
        /// <remarks>
        /// <br>Note        : �����񁨐��l(float)�ϊ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        static private float ToSingle(string text)
        {
            try
            {
                return float.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �R���g���[�������FeedAddCount�擾�i�e�L�X�g���j
        /// </summary>
        /// <param name="control">�󎚃R���g���[��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �R���g���[�������FeedAddCount�擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private int GetFeedAddCount(ar.ARControl control)
        {
            if (control is ar.Label)
            {
                return GetInt((control as ar.Label).Text);
            }
            return 0;
        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text">�ϊ��e�L�X�g</param>
        /// <returns>�ϊ�����</returns>
        /// <remarks>
        /// <br>Note        : ���l�ϊ�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private int GetInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������s
        /// </summary>
        /// <param name="printDocument">����h�L�������g</param>
        /// <param name="derivedNo"></param>
        /// <param name="pdfList">PDF�t�@�C���o�̓p�X���X�g</param>
        /// <remarks>
        /// <br>Note        : ������s</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// <br>Update Note : 2022/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>  
        /// </remarks>
        private void ExecutePrint(Document printDocument, string derivedNo, List<string> pdfList)
        {

            // ���̐ݒ�
            ExtrInfo_EBooksDemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_EBooksDemandTotal);
            _OutPutDateTime = DateTime.Now;
            if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern1)
            {
                _printInfo.prpnm = string.Format("{0}({1})", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_YEARMD) + CT_PDFFILE;
            }
            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
            else if (cndtn.OutPutPattern == (int)FileNameDivEnum.Pattern3)
            {
                _printInfo.prpnm = string.Format("{0}{1}", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_YEARMD2) + CT_PDFFILE;
            }
            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
            else
            {
                _printInfo.prpnm = string.Format("{0}{1}", _reportTitle, derivedNo) + _OutPutDateTime.ToString(CT_HOURMS) + CT_PDFFILE;
            }

            // ���ʏ����ݒ�
            SFCMN00293UC commonInfo;
            SetPrintCommonInfo(out commonInfo);
            _printInfo.pdftemppath = commonInfo.PdfFullPath;
            if (pdfList != null)
            {
                pdfList.Add(commonInfo.PdfFullPath);
            }

            // �v���r���[�L��				
            int mode = this._printInfo.prevkbn;

            // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
            if (this._printInfo.printmode == 2)
            {
                mode = 0;
            }

            switch (mode)
            {
                case 0:
                    {
                        // �v���r���[��
                        # region [�v���r���[��]
                        // �@���ڈ��
                        if (this._printInfo.printmode == 1 || this._printInfo.printmode == 3)
                        {
                            bool printStatus = printDocument.Print(false, false, false);

                            if (printStatus)
                            {
                                this._printInfo.status = 0;
                            }
                            else
                            {
                                this._printInfo.status = 9;
                            }
                        }
                        // �APDF�o��
                        if (this._printInfo.printmode == 2 || this._printInfo.printmode == 3)
                        {
                            DataDynamics.ActiveReports.Export.Pdf.PdfExport pdfExport1 = new DataDynamics.ActiveReports.Export.Pdf.PdfExport();
                            try
                            {
                                pdfExport1.Security.Permissions = ((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions)(((((((DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyContents)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowCopy)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowModifyAnnotations)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowFillIn)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAccessibleReaders)
                                                        | DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowAssembly)));

                                pdfExport1.Export(printDocument, _printInfo.pdftemppath);
                                this._printInfo.status = 0;
                            }
                            catch
                            {
                                this._printInfo.status = 9;
                            }
                            finally
                            {
                                pdfExport1.Dispose();
                            }
                        }
                        # endregion

                        break;
                    }
                case 1:
                    {
                        // �v���r���[�L
                        # region [�v���r���[�L]
                        SFMIT01290UB para = new SFMIT01290UB();
                        para.PrintDocument = printDocument;
                        para.PreviewDocument = printDocument;
                        para.ExpansionRate = 50;

                        SFMIT01290UA form = new SFMIT01290UA();
                        this._printInfo.status = form.PrintPreviewDefaultSetting(para);
                        form.Dispose();
                        # endregion

                        break;
                    }
            }

            // �o�c�e�o�͂̏ꍇ
            # region [�o�c�e�o�͂̏ꍇ�̏���]
            if (this._printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                switch (this._printInfo.printmode)
                {
                    case 1:  // �v�����^
                        break;
                    case 2:  // �o�c�e
                        {
                            // �o�c�e�\���t���OON
                            this._printInfo.pdfopen = true;
                        }
                        break;
                    case 3:  // ����(�v�����^ + �o�c�e)
                        {
                            // �o�c�e�\���t���OON
                            this._printInfo.pdfopen = true;

                            // �o�͗����Ǘ��ɒǉ�
                            Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                            pdfHistoryControl.AddPrintInfo(this._printInfo.key, _reportTitle, _reportTitle, this._printInfo.pdftemppath);
                            pdfHistoryControl.Dispose();
                        }
                        break;
                }
            }
            # endregion
        }

        /// <summary>
        /// ���׃f�U�C���Ή�
        /// </summary>
        /// <param name="prtRpt">����Ώ�</param>
        /// <param name="dmdPrtPtn">����p���[�N</param>
        /// <param name="billPrtSt">��������ݒ�</param>
        /// <param name="layoutChangeIndex">���C�A�E�g�ύX�C���f�b�N�X</param>
        /// <param name="isParent">�e�t���O</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void ReflectReportDesign(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod)//ADD 2011/03/09
        {
            try
            {
                // ���׃f�U�C���p���x��
                ar.Label designSalesHeader = null;
                ar.Label designSalesDetail = null;
                ar.Label designSalesFooter = null;
                ar.Label designSalesTotal = null;
                ar.Label designDepositDetail = null;
                ar.Label designDepositTotal = null;
                ar.Label designSalesFooter2 = null;
                ar.Label designSalesFooter3 = null;
                ar.Label designSalesHeader2 = null;


                // �S�Z�N�V����
                foreach (ar.Section section in prtRpt.Sections)
                {
                    if (section is ar.GroupHeader)
                    {
                        // �O���[�v�ێ��n�m
                        (section as ar.GroupHeader).GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                        // �J��Ԃ��n�m
                        (section as ar.GroupHeader).RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
                        // ���y�[�W�t�B�[���h
                        (section as ar.GroupHeader).DataField = PMKAU01002AC.ct_col_PageCount;
                    }

                    // �Z�N�V�����̃R���g���[���𒲍�
                    foreach (ar.ARControl control in section.Controls)
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring(0, 3);

                        switch (tagText)
                        {
                            case "51,":
                                designSalesHeader = (ar.Label)control;
                                break;
                            case "52,":
                                designSalesDetail = (ar.Label)control;
                                break;
                            case "53,":
                                designSalesFooter = (ar.Label)control;
                                break;
                            case "54,":
                                designDepositDetail = (ar.Label)control;
                                break;
                            case "56,":
                                designSalesTotal = (ar.Label)control;
                                break;
                            case "57,":
                                designDepositTotal = (ar.Label)control;
                                break;
                            case "55,":
                                {
                                    switch (dmdPrtPtn.CoNmPrintOutCd)
                                    {
                                        case 0:
                                            {
                                                // 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
                                                switch (billPrtSt.BillCoNmPrintOutCd)
                                                {
                                                    case 0:
                                                    case 1:
                                                        break;
                                                    case 2:
                                                    case 3:
                                                    default:
                                                        {
                                                            control.Visible = false;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case 1:
                                        case 2:
                                            break;
                                        case 3:
                                        case 4:
                                        default:
                                            {
                                                control.Visible = false;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "58,":
                                // ���C�A�E�g����i�P�Ŗځj
                                // ���̃R���g���[���̓\���Ă���Z�N�V�������󎚂ɂ���
                                if (layoutChangeIndex != 0)
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "59,":
                                // ���C�A�E�g����i�Q�Ŗڈȍ~�j
                                // ���̃R���g���[���̓\���Ă���Z�N�V�������󎚂ɂ���
                                if (layoutChangeIndex == 0)
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "60,":
                                // �ӏ���Ń^�C�g��
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU01002AC.ct_col_TaxTitle;
                                }
                                break;
                            case "64,":
                                // �܂�Ԃ��}�[�N(>)
                                control.Visible = false;
                                break;
                            case "65,":
                                // �܂�Ԃ��}�[�N(<)
                                control.Visible = false;
                                break;
                            default:
                                break;
                            case "68,":
                                designSalesFooter2 = (ar.Label)control;
                                break;
                            case "71,":
                                // ���E�㔄�㍇�v���z(�ō�)�^�C�g��
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU01002AC.ct_col_OfsThisSalesTaxIncTtl;
                                }
                                break;
                            case "72,":
                                //���׃K�C�h�i����t�b�^�R�j
                                designSalesFooter3 = (ar.Label)control;
                                break;
                            //
                            case "73,":
                                //���׃K�C�h�i����w�b�_�Q�j
                                designSalesHeader2 = (ar.Label)control;
                                break;
                        }
                        // �e��w�b�_�E�t�b�^�̂�
                        if (section.Type != DataDynamics.ActiveReports.SectionType.Detail)
                        {
                            string[] tagParams;
                            //--------------------------------------------------
                            // ����y�[�W�敪�i�S�y�[�W�^�P�y�[�W�ڂ̂݁j�̑Ή�
                            //--------------------------------------------------
                            try
                            {
                                tagParams = ((string)control.Tag).Split(',');
                            }
                            catch
                            {
                                continue;
                            }
                            if (tagParams.Length > 1)
                            {
                                string printPageCtrlDivCd = tagParams[1].Trim();
                                if (printPageCtrlDivCd == "1")
                                {
                                    if (layoutChangeIndex != 0)
                                    {
                                        // 2�y�[�W�ڈȍ~
                                        control.Visible = false;
                                    }
                                    else
                                    {
                                        // 1�y�[�W��
                                        control.Visible = true;
                                    }
                                }
                            }
                        }
                    }

                    # region [���ڃO���[�v��]
                    if (section is ar.Detail)
                    {
                        ar.Detail detail = (section as ar.Detail);

                        // �Ώۃf�[�^�t�B�[���h���X�g�擾
                        List<string> salesHeaderList = PMKAU01002AC.GetDesignSalesHeaderList();
                        List<string> salesFooterList = PMKAU01002AC.GetDesignSalesFooterList();
                        List<string> salesDetailList = PMKAU01002AC.GetDesignSalesDetailList();
                        List<string> salesTotalList = PMKAU01002AC.GetDesignSalesTotalList();
                        List<string> depositDetailList = PMKAU01002AC.GetDesignDepositDetailList();
                        List<string> depositTotalList = PMKAU01002AC.GetDesignDepositTotalList();
                        List<string> salesFooter2List = PMKAU01002AC.GetDesignSalesFooter2List();
                        List<string> salesFooter3List = PMKAU01002AC.GetDesignSalesFooter3List();
                        List<string> salesHeader2List = PMKAU01002AC.GetDesignSalesHeader2List();

                        if (designSalesHeader == null)
                        {
                            // ����w�b�_�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăw�b�_���X�g���N���A
                            salesDetailList.AddRange(salesHeaderList);
                            salesHeaderList.Clear();
                        }
                        if (designSalesFooter == null)
                        {
                            // ����t�b�^�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^���X�g���N���A
                            salesDetailList.AddRange(salesFooterList);
                            salesFooterList.Clear();
                        }
                        if (designSalesTotal == null)
                        {
                            // ����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��Ĕ���W�v���X�g���N���A
                            salesDetailList.AddRange(salesTotalList);
                            salesTotalList.Clear();
                        }
                        if (designSalesDetail == null)
                        {
                            // ���㖾�׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
                            salesDetailList.Clear();
                        }
                        if (designDepositTotal == null)
                        {
                            // �����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ē����W�v���X�g���N���A
                            depositDetailList.AddRange(depositTotalList);
                            depositTotalList.Clear();
                        }
                        if (designDepositDetail == null)
                        {
                            // �������׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
                            depositDetailList.Clear();
                        }
                        if (designSalesFooter2 == null)
                        {
                            //����t�b�^�Q�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^�Q���X�g���N���A
                            salesDetailList.AddRange(salesFooter2List);
                            salesFooter2List.Clear();
                        }
                        if (designSalesFooter3 == null)
                        {
                            //����t�b�^�R�f�U�C���K�C�h���Ȃ��ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^�R���X�g���N���A
                            salesFooter3List.AddRange(salesFooter3List);
                            salesFooter3List.Clear();
                        }
                        if (designSalesHeader2 == null)
                        {
                            //����w�b�_�Q�f�U�C���K�C�h���Ȃ��ꍇ�͖��׃��X�g�Ɉڂ��ăw�b�_�Q���X�g���N���A
                            salesHeader2List.AddRange(salesHeader2List);
                            salesHeader2List.Clear();
                        }

                        // �S�ẴR���g���[���𒲍�
                        foreach (ar.ARControl control in detail.Controls)
                        {
                            if (control is ar.TextBox)
                            {
                                string dataField = control.DataField.ToUpper();

                                if (salesHeaderList.Contains(dataField))
                                {
                                    // ����w�b�_���ڂ̏ꍇ
                                    control.Top -= designSalesHeader.Top;
                                }
                                else if (salesFooterList.Contains(dataField))
                                {
                                    // ����t�b�^���ڂ̏ꍇ
                                    control.Top -= designSalesFooter.Top;
                                }
                                else if (salesTotalList.Contains(dataField))
                                {
                                    // ����W�v���ڂ̏ꍇ
                                    control.Top -= designSalesTotal.Top;
                                }
                                else if (salesDetailList.Contains(dataField))
                                {
                                    // ���㖾�׍��ڂ̏ꍇ
                                    control.Top -= designSalesDetail.Top;
                                }
                                else if (depositTotalList.Contains(dataField))
                                {
                                    // �����W�v���ڂ̏ꍇ
                                    control.Top -= designDepositTotal.Top;
                                }
                                else if (depositDetailList.Contains(dataField))
                                {
                                    // �������׍��ڂ̏ꍇ
                                    control.Top -= designDepositDetail.Top;
                                }
                                else if (salesFooter2List.Contains(dataField))
                                {
                                    //����t�b�^�Q�̏ꍇ
                                    control.Top -= designSalesFooter2.Top;
                                }
                                else if (salesFooter3List.Contains(dataField))
                                {
                                    //����t�b�^�R�̏ꍇ
                                    control.Top -= designSalesFooter3.Top;
                                }
                                else if (salesHeader2List.Contains(dataField))
                                {
                                    //����w�b�_�Q�̏ꍇ
                                    control.Top -= designSalesHeader2.Top;
                                }
                            }
                        }
                    }
                    # endregion
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// DetailLine��`�悷�邩�ǂ����𔻒f���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : DetailLine��`�悷�邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        void _reportCtrl_BeforePrintEditLine(object sender, PMCMN02001CA.BeforePrintEditLineEventArgs e)
        {
            if (e.Control.Name == "DetailLineRF")
            {
                if (_detailPrtCount <= _formFeedLineCount)
                {
                    // �P�Ŗډ��Ń`�F�b�N
                    if (_detailPrtCount == _formFeedLineCount)
                    {
                        (e.Control as ar.Line).LineColor = Color.Transparent;
                        _detailPrtCount++;
                        return;
                    }
                    _detailPrtCount++;
                }
                else
                {
                    // �Q�Ŗڈȍ~���Ń`�F�b�N
                    if (_detailPrtCount == _formFeedLineCount + _formFeedLineCount + _feedAddCount)
                    {
                        (e.Control as ar.Line).LineColor = Color.Transparent;
                        _detailPrtCount = _formFeedLineCount + 1;
                        return;
                    }
                    _detailPrtCount++;
                }
                // �`�[�v�s���`�F�b�N
                string SalesFtTitle = getSalesFtTitle(e.ControlList);
                if (string.IsNullOrEmpty(SalesFtTitle))
                {
                    (e.Control as ar.Line).LineColor = Color.Transparent;
                }
                else
                {
                    (e.Control as ar.Line).LineColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// �R���g���[�����X�g���甄��`�[�v�^�C�g���E�����W�v�^�C�g���E�����z�̓������ꂩ�̒l���擾���܂��B
        /// </summary>
        /// <param name="arControlList">�R���g���[�����X�g</param>
        /// <returns>�擾�����l</returns>
        /// <remarks>
        /// <br>Note        : �R���g���[�����X�g���甄��`�[�v�^�C�g���E�����W�v�^�C�g���E�����z�̓������ꂩ�̒l���擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        string getSalesFtTitle(List<ar.ARControl> arControlList)
        {
            string salesFtTitle = string.Empty;
            int hitCount = 0;
            bool countUpFlg = false;
            foreach (ar.ARControl cntrl in arControlList)
            {
                if (cntrl.Name == "SalesFtTitleRF")
                {
                    ar.TextBox textBox = cntrl as ar.TextBox;
                    salesFtTitle = textBox.Text;
                    hitCount++;
                }
                // �������׈󎚂���i���v�j
                if (_depoDtlPrcPrtDiv == 1)
                {
                    if (cntrl.Name == "DepositRF")
                    {
                        ar.TextBox textBox = cntrl as ar.TextBox;
                        salesFtTitle = textBox.Text;
                        hitCount++;
                    }
                }
                // �������׈󎚂���i���ׁj
                else if (_depoDtlPrcPrtDiv == 2)
                {
                    if (cntrl.Name == "DetailSumPriceRF")
                    {
                        ar.TextBox textBox = cntrl as ar.TextBox;
                        salesFtTitle = textBox.Text;
                        hitCount++;
                    }
                }
                else
                {
                    if (!countUpFlg)
                    {
                        hitCount++;
                        countUpFlg = true;
                    }
                }
                if (string.IsNullOrEmpty(salesFtTitle))
                {
                    if (hitCount == 2) break;
                }
                else break;
            }
            return salesFtTitle;
        }

        /// <summary>
        /// �e�[�u���Z����NULL���菈��
        /// </summary>
        /// <param name="cellObject">�Z���Ώ�</param>
        /// <returns>NULL�̔��茋��</returns>
        /// <remarks>
        /// <br>Note        : �e�[�u���Z����NULL���菈��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private bool IsNull(object cellObject)
        {
            return (cellObject == null || cellObject == DBNull.Value);
        }

        /// <summary>
        /// �]���ݒ菈��
        /// </summary>
        /// <param name="rpt">�A�N�e�B�u���|�[�g�I�u�W�F�N�g</param>
        /// <param name="dmdPrtPtn">����������p�^�[��</param>
        /// <remarks>
        /// <br>Note        : �]���ݒ�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetMargin(ar.ActiveReport3 rpt, DmdPrtPtnWork dmdPrtPtn)
        {
            // ��̗]����ݒ�
            rpt.PageSettings.Margins.Top
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);
            // ���̗]����ݒ�
            rpt.PageSettings.Margins.Bottom
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.BottomMargin);
            // ���̗]����ݒ�
            rpt.PageSettings.Margins.Left
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            // �E�̗]����ݒ�
            rpt.PageSettings.Margins.Right
                = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.RightMargin);

            // Report��PrintWidth��inch�P�ʂŒ��r���[�ȏꍇ�A�s�v�ȋ�y�[�W���������Ă��܂��̂Ŗh�~����B
            // (������R�ʈȍ~�͐؂�̂Ă�)
            int width = (int)((float)rpt.PrintWidth * (float)100.0f);
            rpt.PrintWidth = (float)width / (float)100.0f;
            // �]����������
            rpt.PrintWidth -= (rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right);
        }

        /// <summary>
        /// �v�����^�[���Z�b�g����
        /// </summary>
        /// <param name="document">���|�[�gDocument</param>
        /// <param name="prtManage">����Ǘ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �v�����^�[����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetPrinterInfo(Document document, PrtManage prtManage)
        {
            // �g�p�v�����^�[�̐ݒ�
            if (prtManage != null)
            {
                document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            }
            else
            {
                document.Printer.PrinterSettings.PrinterName = string.Empty;
            }

            // �g�p�v�����^�̗L���L���`�F�b�N�i�L���ł͖����ꍇ�͉��z�v�����^���g�p�j
            if (!document.Printer.PrinterSettings.IsValid)
                document.Printer.PrinterSettings.PrinterName = string.Empty;
        }

        #endregion �� �������

        #region �� ���|�[�g�t�H�[���ݒ�֘A
        #region �� �e��ActiveReport���[�C���X�^���X�쐬
        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion

        #region �� ���|�[�g�A�Z���u���C���X�^���X��
        /// <summary>
        /// ���|�[�g�A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new StockMoveException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new StockMoveException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region �� �����ʋ��ʏ��ݒ�

        /// <summary>
        /// �o�c�e�o�̓t�@�C�����擾����
        /// </summary>
        /// <param name="commonInfo">�o�͏��</param>
        /// <returns>status(0:����,-1:�G���[)</returns>
        /// <remarks>
        /// <br>Note        : �o�c�e�o�̓p�X�����擾���܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDF�p�X�擾
            string pdfPath = "";
            string pdfName = "";

            // �v�����^��
            commonInfo.PrinterName = string.Empty;//prtManage.PrinterName;
            // ���[��
            commonInfo.PrintName = _reportTitle;
            // ������[�h

            try
            {
                commonInfo.PrintMode = this.Printinfo.printmode;
            }
            catch
            {
                commonInfo.PrintMode = 1;
            }

            // ��������\��
            commonInfo.PrintMax = 0;

            if (!string.IsNullOrEmpty(this._printInfo.outPutFilePathName))
            {
                pdfPath = this._printInfo.outPutFilePathName + "\\";
            }
            else
            {
                status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            }
            this._printInfo.pdftemppath = pdfPath + this._printInfo.prpnm;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = 0;
            // ���]��
            commonInfo.MarginsLeft = 0;
        }

        #endregion

        #region �� ���o�͈͕�����쐬
        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <param name="title">�^�C�g��</param>
        /// <param name="startString">�J�n������</param>
        /// <param name="endString">�I��������</param>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private string GetConditionRange(string title, string startString, string endString)
        {
            string result = "";
            if ((startString != "") || (endString != ""))
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if (startString != "") start = startString;
                if (endString != "") end = endString;
                result = String.Format(title + ct_RangeConst, start, end);
            }
            return result;
        }
        #endregion

        #region �� ���o����������ҏW
        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // �V�K�ҏW�G���A�쐬
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion
        #endregion �� ���|�[�g�t�H�[���ݒ�֘A

        #region �� ���b�Z�[�W�\��

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/03/08</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult rst = TMsgDisp.Show(form, iLevel, "PMKAU01001P", iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return rst;
        }

        #endregion

        # region [����}�[�N��`]
        /// <summary>
        /// ����}�[�N��`
        /// </summary>
        internal struct PrintMarkScheme
        {
            /// <summary>�󎚈ʒu</summary>
            private PointF _position;
            /// <summary>�󎚃J���[</summary>
            private Color _foreColor;
            /// <summary>�󎚃T�C�Y</summary>
            private float _size;
            /// <summary>
            /// �󎚈ʒu
            /// </summary>
            /// <remarks>�C���`�P��</remarks>
            public PointF Position
            {
                get { return _position; }
                set { _position = value; }
            }
            /// <summary>
            /// �󎚃J���[
            /// </summary>
            public Color ForeColor
            {
                get { return _foreColor; }
                set { _foreColor = value; }
            }
            /// <summary>
            /// �󎚃T�C�Y
            /// </summary>
            public float Size
            {
                get { return _size; }
                set { _size = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="position">�󎚈ʒu</param>
            /// <param name="foreColor">�󎚃J���[</param>
            /// <param name="size">�󎚃T�C�Y</param>
            public PrintMarkScheme(PointF position, Color foreColor, float size)
            {
                _position = position;
                _foreColor = foreColor;
                _size = size;
            }
        }
        # endregion
        #endregion

        /// <summary>
        /// �j������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �j������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/08</br>
        /// </remarks>
        public void Dispose()
        {
            // �^�C�v�ʃh�L�������g���
            if (_documentByTypeDic != null)
            {
                foreach (Document doc in _documentByTypeDic.Values)
                {
                    doc.Dispose();
                }
                _documentByTypeDic = null;
            }
            // ����h�L�������g���
            if (_orgDocuments != null)
            {
                foreach (Document doc in _orgDocuments.Values)
                {
                    doc.Dispose();
                }
                _orgDocuments = null;
            }
            // ���[���ʕ��i�L���b�V���N���A
            if (_reportCtrl != null)
            {
                _reportCtrl.Clear();
                _reportCtrl = null;
            }
            // ���|�[�g�N���X
            if (_prtRptList != null)
            {
                foreach (ar.ActiveReport3 report in _prtRptList)
                {
                    report.Dispose();
                }
                _prtRptList = null;
            }
        }
    }
}
