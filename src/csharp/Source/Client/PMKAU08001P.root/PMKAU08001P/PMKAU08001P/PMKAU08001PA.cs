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
    /// ���R���[�i�������j����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R���[�i�������j�̈�����s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// <br>Update Note  : 2009.09.28  22018  ��� ���b</br>
    /// <br>             : ���l���s���[�^�[�X���� �ʐ������Ή�</br>
    /// <br>             : �@�@�Q�Ŗڈȍ~�̖��׍s�����s���ɂȂ�s��̏C���B</br>
    /// <br>             : �@�A�Q�Ŗڈȍ~�󎚂��Ȃ�������\�ɕύX�B</br>
    /// <br></br>
    /// <br>Update Note  : 2009.12.11  30531  ��� �r��</br>
    /// <br>             : �^�C�g���ݒ�i�v���[�g�ԍ��j�̍��ڂ̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.03  22018  ��� ���b</br>
    /// <br>             : ������(����)�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/25  30517  �Ė� �x��</br>
    /// <br>             : �X�암�i���Ή�</br>
    /// <br>             : �B�`�[���v����Ń��e�����ǉ�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/16  30531  ��� �r��</br>
    /// <br>             : ���|�c����Ή�</br>
    /// <br>             : �@�f�U�C���K�C�h(����t�b�^�Q)�����ǉ�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/23  22018  ��� ���b</br>
    /// <br>             : ����������y�[�W�w��Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/09  30531  ��� �r��</br>
    /// <br>             : ���R������Ή�</br>
    /// <br>             : �ʍ��ڒǉ�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/22  22018  ��� ���b</br>
    /// <br>             : �A�E�g�I�u�������G���[�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/05  30517  �Ė� �x��</br>
    /// <br>             : ���������Ή�</br>
    /// <br>             : �ʍ��ڒǉ��i����ŁE�ېō��v�E*�����v*</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/10  22018  ��� ���b</br>
    /// <br>             : �E���ʈ���Ή�</br>
    /// <br>             : �E�g�p�ς݃��|�[�g�̉���������C��</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/16  22018  ��� ���b</br>
    /// <br>             : �E���זԊ|���Ή��i���݂ɖԊ|���j</br>
    /// <br></br>
    /// <br>Update Note  : 2010/11/17  22018  ��� ���b</br>
    /// <br>             : �E���Ж��󎚁��r�b�g�}�b�v�ŕ���������̈�����ɃG���[�ɂȂ錏�̏C���B</br>
    /// <br>             : �E�璷�ȏ���(��x,����pDocument��AddRange���Ă���,������x�ʂ�Document��AddRange����)���폜�B</br>
    /// <br></br>
    /// <br>Update Note  : 2011/01/13  30517  �Ė� �x��</br>
    /// <br>             : �䓌���i����ʑΉ�</br>
    /// <br>             : �`�[�v�s�̉��Ɍr��������</br>
    /// <br>Update Note�@: 2011/03/09 yangmj readmine #19751�Ή�</br>
    /// <br></br>
    /// </remarks>
    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
    //public class PMKAU08001PA : IPrintProc // m.suzuki 2009/03/10 internal��public
    public class PMKAU08001PA : IPrintProc, IDisposable
    // --- UPD m.suzuki 2010/07/22 ----------<<<<<
    {
        #region �� Constructor
        /// <summary>
        /// ���R���[�i�������j����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R���[�i�������j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public PMKAU08001PA ()
        {
            _reportCtrl = PMCMN02000CA.GetInstance();
            // 2011/01/13 Add >>>
            _reportCtrl.BeforePrintEditLine += new PMCMN02000CA.BeforePrintEditLineHandler(_reportCtrl_BeforePrintEditLine);
            // 2011/01/13 Add <<<
        }

        /// <summary>
        /// ���R���[�i�������j����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���R���[�i�������j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public PMKAU08001PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;

            _reportCtrl = PMCMN02000CA.GetInstance();
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�s�n�o";
        private const string ct_Extr_End = "�d�m�c";
        private const string ct_RangeConst = "�F{0} �` {1}";
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
        // --- ADD  ���r��  2010/07/09 ---------->>>>>
        private string _ofsThisSalesTaxIncTtl;
        // --- ADD  ���r��  2010/07/09 ----------<<<<<
        private Dictionary<int, List<PrintMarkScheme>> _printMarkDic;
        private List<string> _pdfPathList;
        private List<string> _previewPdfPathList;
        private PMCMN02000CA _reportCtrl;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
        private bool _printCancelFlag; // ����L�����Z���t���O
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
        private string _reportTitle; // ���[�^�C�g��
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
        // --- ADD  ���r��  2009/12/11 ---------->>>>>
        private string _carmngCodeTitle;
        // --- ADD  ���r��  2009/12/11 ----------<<<<<
        // 2010/05/25 Add >>>
        private string _slipTtlTaxTitle;
        // 2010/05/25 Add <<<
        // --- ADD  ���r��  2010/06/16 ---------->>>>>
        private string _footerTitleOfTax;
        private string _footerTitleOfSlipTaxInc;
        private bool _existsSalesFooter;
        private bool _existsSalesFooter2;
        // --- ADD  ���r��  2010/06/16 ----------<<<<<
        // --- ADD  ���r��  2010/07/09 ---------->>>>>
        private bool _existsSalesFooter3;
        private bool _existsSalesHeader2;
        // --- ADD  ���r��  2010/07/09 ----------<<<<<
        // --- ADD m.suzuki 2010/08/05 ---------->>>>>
        private bool _existsMoneyKindCodeOther;
        // --- ADD m.suzuki 2010/08/05 ----------<<<<<
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        private Dictionary<string, Document> _documentByTypeDic;
        private Dictionary<string, Document> _orgDocuments;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
        // --- ADD m.suzuki 2010/11/10 ---------->>>>>
        private List<ar.ActiveReport3> _prtRptList;
        // --- ADD m.suzuki 2010/11/10 ----------<<<<<
        // 2010/11/05 Add >>>
        private string _depositFooterTitleOfSlip;
        private string _footerTitleOfTax2;
        private string _footerTitleOfSlipTaxInc2;
        // 2010/11/05 Add <<<
        // --- ADD m.suzuki 2010/11/16 ---------->>>>>
        private bool _existsMesh;
        private int _lineCount;
        // --- ADD m.suzuki 2010/11/16 ----------<<<<<
        // 2011/01/13 Add >>>
        private int _formFeedLineCount = 0;
        private int _detailPrtCount = 1;
        private int _depoDtlPrcPrtDiv = 0;
        // 2011/01/13 Add <<<
        #endregion �� Private Member

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        public event EventHandler MessageChange;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public StockMoveException ( string message, int status )
                : base( message )
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
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// �^�C�v�ʃh�L�������g�f�B�N�V���i��
        /// </summary>
        public Dictionary<string, Document> DocumentByTypeDic
        {
            get
            {
                if ( _documentByTypeDic == null )
                {
                    _documentByTypeDic = new Dictionary<string, Document>();
                }
                return _documentByTypeDic;
            }
            set { _documentByTypeDic = value; }
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
        #endregion �� Public Property

        #region �� Public Method
        #region �� ��������J�n
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public int StartPrint ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
            //return PrintMain();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
            int status = PrintMain();
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, "PMKAU08001P", "��������𒆒f���܂����B", 0, MessageBoxButtons.OK );
            }
            return status;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� Private Member
        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        /// <br>Update Note: 2011/03/09 yangmj readmine #19751�Ή�</br>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            _reportTitle = "������";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

            try
            {
                // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                //if ( (this._printInfo.jyoken is ExtrInfo_DemandTotal) == false )
                if ( (this._printInfo.jyoken is ExtrInfo_DemandTotal) == false && (this._printInfo.jyoken is SumExtrInfo_DemandTotal) == false )
                // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                {
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", "�ݒ肪�s���ȈׁA����o���܂���ł����B", 0, MessageBoxButtons.OK );
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // ������[�h���ݒ�̏ꍇ�̃f�t�H���g�ݒ�
                # region [������[�h���ݒ�]
                if ( this._printInfo.printmode == 0 )
                {
                    // 1:�v���r���[����
                    this._printInfo.prevkbn = 1;
                    // 1:�v�����^�i���v���r���[����Ȃ̂Ŏ��ۂɂ͈�����Ȃ��j
                    this._printInfo.printmode = 1;

# if DEBUG
                    //// �v���r���[�Ȃ��o�c�e�e�X�g
                    //this._printInfo.prevkbn = 0;
                    //this._printInfo.printmode = 2;
# endif
                }
                # endregion

                // �^�C�v�ʈ���h�L�������g�f�B�N�V���i��
                Dictionary<string, Document> documentsDic = new Dictionary<string, Document>();
                // �������ʃh�L�������g�f�B�N�V���i��
                Dictionary<string, Document> orgDocuments = new Dictionary<string, Document>();

                // PDF�o�͈ꗗ���X�g
                _pdfPathList = new List<string>();

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataTable billData = printDataSet.Tables[PMKAU08002AB.CT_Tbl_BillList];

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                // ���o����(E��A)�ŃL�����Z�����ꂽ�ꍇ�̃L�����Z������
                if ( billData.Rows.Count > 0 )
                {
                    if ( (bool)billData.Rows[0][PMKAU08002AB.CT_BillList_ExtractCancel] == true )
                    {
                        // �L�����Z��
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                // �G���[���R�f�B�N�V���i��
                Dictionary<string, bool> errReasonDic = new Dictionary<string, bool>();
                errReasonDic.Add( PMKAU08002AB.CT_BillList_DmdPrtPtn, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_FrePrtPSet, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_FrePBillHead, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_PrtManage, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_BillAllSt, false );
                errReasonDic.Add( PMKAU08002AB.CT_BillList_BillPrtSt, false );

                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //SFCMN00299CA processingDialog = new SFCMN00299CA();
                //// --- ADD m.suzuki 2010/06/23 ---------->>>>>
                //bool disposed = false;
                //// --- ADD m.suzuki 2010/06/23 ----------<<<<<
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                try
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    string prevOutputFormFileName = string.Empty;
                    _printCancelFlag = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                    // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                    //processingDialog.Title = "�������";
                    //processingDialog.Message = "���݁A����������ł��B";
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
                    ////processingDialog.DispCancelButton = false;
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    //processingDialog.DispCancelButton = true;
                    //processingDialog.CancelButtonClick += new EventHandler( processingDialog_CancelButtonClick );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    //processingDialog.Show();
                    // --- DEL m.suzuki 2010/07/22 ----------<<<<<

                    DataView billDataView = new DataView( billData );

                    //----------------------------------------------------------------
                    // �������̃\�[�g��
                    //----------------------------------------------------------------
                    # region [�w�b�_�̃\�[�g��]
                    // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                    //switch ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).SortOrder )

                    int sortOrder = 0;
                    int customerAgentDivCd = 0;
                    int prCustDtl = 0;
                    if ( this._printInfo.jyoken is ExtrInfo_DemandTotal )
                    {
                        // ������
                        ExtrInfo_DemandTotal cndtn = (this._printInfo.jyoken as ExtrInfo_DemandTotal);
                        sortOrder = cndtn.SortOrder;
                        customerAgentDivCd = cndtn.CustomerAgentDivCd;
                        prCustDtl = cndtn.PrCustDtl;
                    }
                    else if ( this._printInfo.jyoken is SumExtrInfo_DemandTotal )
                    {
                        // ������(����)
                        SumExtrInfo_DemandTotal sumCndtn = (this._printInfo.jyoken as SumExtrInfo_DemandTotal);
                        sortOrder = sumCndtn.SortOrder;
                        customerAgentDivCd = sumCndtn.CustomerAgentDivCd;
                        prCustDtl = 0;
                    }

                    switch ( sortOrder )
                    // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                    {
                        // �S���ҏ�
                        case 1:
                            {
                                // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                                //if ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).CustomerAgentDivCd == 0 )
                                if ( customerAgentDivCd == 0 )
                                // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                                {
                                    // ���Ӑ�S����
                                    billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_CustomerAgentCd, // �S����
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                                }
                                else
                                {
                                    // �W���S����
                                    billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_BillCollecterCd, // �W���S����
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                                }
                            }
                            break;
                        // �n�揇
                        case 2:
                            {
                                billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_SalesAreaCode, // �n��
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                            }
                            break;
                        // ���Ӑ揇
                        default:
                            {
                                billDataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}",
                                                                        PMKAU08002AB.CT_BillList_AddUpDateInt,
                                                                        PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                                        PMKAU08002AB.CT_BillList_ClaimCode,
                                                                        PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                                        PMKAU08002AB.CT_BillList_CustomerCode );
                            }
                            break;
                    }
                    # endregion

                    //----------------------------------------------------------------
                    // �u�e�𐿋���Ɋ܂߂�v�Ȃ�ΐe���R�[�h�����O
                    //----------------------------------------------------------------
                    # region [������Ɋ܂߂�A�Ή�]
                    // --- UPD m.suzuki 2010/02/03 ---------->>>>>
                    //if ( (this._printInfo.jyoken as ExtrInfo_DemandTotal).PrCustDtl == 0 )
                    if ( prCustDtl == 0 )
                    // --- UPD m.suzuki 2010/02/03 ----------<<<<<
                    {
                        // ���_�Ⴂor���Ӑ�Ⴂ��ΏۂƂ���i���ʓI�ɏW�v���R�[�h���Ώہj
                        billDataView.RowFilter = string.Format( "{0}<>{1} OR {2}<>{3}",
                                                    PMKAU08002AB.CT_BillList_AddUpSecCode,
                                                    PMKAU08002AB.CT_BillList_ResultsSectCd,
                                                    PMKAU08002AB.CT_BillList_ClaimCode,
                                                    PMKAU08002AB.CT_BillList_CustomerCode );
                    }
                    else
                    {
                        billDataView.RowFilter = string.Empty;
                    }
                    # endregion

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    if ( _printCancelFlag )
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                    // --- ADD m.suzuki 2010/11/17 ---------->>>>> // ���[�v�̒�����ړ�
                    // ������ɑS�Ẵ��|�[�g���������ׂ̃��X�g
                    if ( _prtRptList != null )
                    {
                        foreach ( ar.ActiveReport3 report in _prtRptList )
                        {
                            report.Dispose();
                        }
                    }
                    _prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();
                    // --- ADD m.suzuki 2010/11/17 ----------<<<<<

                    //----------------------------------------------------------------
                    // �������̈��
                    //----------------------------------------------------------------
                    foreach ( DataRowView billRowView in billDataView )
                    {
                        # region [�������P��]
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        if ( _printCancelFlag )
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        DataRow billRow = billRowView.Row;

                        // �K�v�}�X�^��񂪂Ȃ���΁u���R���[(������)�v�Ƃ��Ă͑ΏۊO�ɂ��܂��B
                        bool errCheck = false;
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_DmdPrtPtn] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_DmdPrtPtn] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_FrePrtPSet] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_FrePrtPSet] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_FrePBillHead] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_FrePBillHead] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_PrtManage] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_PrtManage] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_BillAllSt] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_BillAllSt] = true; errCheck = true; }
                        if ( IsNull( billRow[PMKAU08002AB.CT_BillList_BillPrtSt] ) ) { errReasonDic[PMKAU08002AB.CT_BillList_BillPrtSt] = true; errCheck = true; }
                        if ( errCheck )
                        {
                            continue;
                        }

                        // ����������p�^�[���ݒ� �擾
                        DmdPrtPtnWork dmdPrtPtn = (DmdPrtPtnWork)billRow[PMKAU08002AB.CT_BillList_DmdPrtPtn];
                        // ���R���[�󎚈ʒu�ݒ� �擾
                        FrePrtPSetWork frePrtPSet = (FrePrtPSetWork)billRow[PMKAU08002AB.CT_BillList_FrePrtPSet];
                        // �v�����^�Ǘ��ݒ� �擾
                        PrtManage prtManage = (PrtManage)billRow[PMKAU08002AB.CT_BillList_PrtManage];
                        // ��������ݒ� �擾
                        BillPrtStWork billPrtSt = (BillPrtStWork)billRow[PMKAU08002AB.CT_BillList_BillPrtSt];

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                        // 80:�̎���
                        if ( dmdPrtPtn.SlipPrtKind == 80 )
                        {
                            _reportTitle = "�̎���";
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                        //_existsSalesTotalFooter = false;
                        //_existsDepositTotalFooter = false;
                        //_feedAddCount = 1;
                        //_printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                        // ����Ώۃe�[�u�������i�P�������P�ʁj
                        DataTable printData = PMKAU08002AC.CreatePrintDataTable();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                        //this.SearchPrintLayout( frePrtPSet );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                        if ( prevOutputFormFileName != frePrtPSet.OutputFormFileName.Trim() )
                        {
                            _existsSalesTotalFooter = false;
                            _existsDepositTotalFooter = false;
                            // --- ADD  ���r��  2010/06/16 ---------->>>>>
                            _existsSalesFooter = false;
                            _existsSalesFooter2 = false;
                            // --- ADD  ���r��  2010/06/16 ----------<<<<<
                            // --- ADD  ���r��  2010/07/09 ---------->>>>>
                            _existsSalesFooter3 = false;
                            _existsSalesHeader2 = false;
                            // --- ADD  ���r��  2010/07/09 ----------<<<<<
                            // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                            _existsMesh = false;
                            // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL
                            //_feedAddCount = 1;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                            _feedAddCount = 0; // �Q�Ŗڈȍ~�̍s�������̓f�t�H���g0
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                            _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                            this.SearchPrintLayout( frePrtPSet );
                        }
                        prevOutputFormFileName = frePrtPSet.OutputFormFileName.Trim();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL ���g�p�Ȃ̂ō폜
                        //int feedAddCount = _feedAddCount;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL

                        // 2011/01/13 Add >>>
                        _depoDtlPrcPrtDiv = dmdPrtPtn.DepoDtlPrcPrtDiv;
                        _formFeedLineCount = frePrtPSet.FormFeedLineCount;
                        _detailPrtCount = 1;
                        // 2011/01/13 Add <<<

                        // ������C�A�E�g�p�����[�^
                        PMKAU08002AC.BillDmdPrintParameter parameter = new PMKAU08002AC.BillDmdPrintParameter();
                        # region [parameter]
                        parameter.OtherFeedAddCount = _feedAddCount;
                        parameter.ExistsSalesTotalFooter = _existsSalesTotalFooter;
                        parameter.ExistsDepositTotalFooter = _existsDepositTotalFooter;
                        parameter.FooterTitleOfSlip = _footerTitleOfSlip;
                        parameter.FooterTitleOfDaily = _footerTitleOfDaily;
                        parameter.FooterTitleOfCustomer = _footerTitleOfCustomer;
                        parameter.TaxTitle = _taxTitle;
                        // --- ADD  ���r��  2010/07/09 ---------->>>>>
                        parameter.OfsThisSalesTaxIncTtl = _ofsThisSalesTaxIncTtl;
                        // --- ADD  ���r��  2010/07/09 ----------<<<<<
                        // --- ADD  ���r��  2009/12/11 ---------->>>>>
                        parameter.CarmngCodeTitle = _carmngCodeTitle;
                        // --- ADD  ���r��  2009/12/11 ----------<<<<<
                        // 2010/05/25 Add >>>
                        parameter.SlipTtlTaxTitle = _slipTtlTaxTitle;
                        // 2010/05/25 Add <<<
                        // --- ADD  ���r��  2010/06/16 ---------->>>>>
                        parameter.FooterTitleOfTax = _footerTitleOfTax;
                        parameter.FooterTitleOfSlipTaxInc = _footerTitleOfSlipTaxInc;
                        parameter.ExistsSalesFooter = _existsSalesFooter;
                        parameter.ExistsSalesFooter2 = _existsSalesFooter2;
                        // --- ADD  ���r��  2010/06/16 ----------<<<<<
                        // --- ADD  ���r��  2010/07/09 ---------->>>>>
                        parameter.ExistsSalesFooter3 = _existsSalesFooter3;
                        parameter.ExistsSalesHeader2 = _existsSalesHeader2;
                        // --- ADD  ���r��  2010/07/09 ----------<<<<<
                        // 2010/11/05 Add >>>
                        parameter.DepositFooterTitleOfSlip = _depositFooterTitleOfSlip;
                        parameter.FooterTitleOfSlipTaxInc2 = _footerTitleOfSlipTaxInc2;
                        parameter.FooterTitleOfTax2 = _footerTitleOfTax2;
                        // 2010/11/05 Add <<<
                        # endregion

                        PMKAU08002AC.CopyToPrintDataTable( ref printData, this._printInfo.jyoken, billRow, parameter );

                        // ����f�[�^��ŒP�ʂɕ�����
                        List<DataTable> printDataList = PMKAU08002AC.DevelopPrintDataList( ref printData );
                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        if ( printData != null )
                        {
                            printData.Dispose();
                        }
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                        # region [����h�L�������g��������]

                        // --- DEL m.suzuki 2010/11/17 ---------->>>>> // �������璷�Ȃ̂ō폜
                        //// ���|�[�g�h�L�������g������
                        //Document printDocument = new Document();
                        // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                        using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
                        {
                            ar.ActiveReport3 prtRpt = null;

                            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                            // --- DEL m.suzuki 2010/11/17 ---------->>>>> // ���[�v�̊O�Ɉړ�
                            //// ������ɑS�Ẵ��|�[�g���������ׂ̃��X�g
                            //if ( _prtRptList != null )
                            //{
                            //    foreach ( ar.ActiveReport3 report in _prtRptList )
                            //    {
                            //        report.Dispose();
                            //    }
                            //}
                            //_prtRptList = new List<DataDynamics.ActiveReports.ActiveReport3>();
                            // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                            // ���ʖ����̎擾
                            int copyCount;
                            # region [copyCount��dmdPrtPtn.CopyCount]
                            // ���ʖ������Z�b�g
                            if ( dmdPrtPtn.CopyCount != 0 )
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
                            for ( int copyIndex = 0; copyIndex < copyCount; copyIndex++ )
                            {
                            // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                // ���C�A�E�g�Ⴂ�J��Ԃ�
                                for ( int pageIndex = 0; pageIndex < printDataList.Count; pageIndex++ )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                                    if ( _printCancelFlag )
                                    {
                                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                                    printData = printDataList[pageIndex];
                                    bool isParent = PMKAU08002AC.IsParent( printData );
                                    int consTaxLayMethod = PMKAU08002AC.GetConsTaxLayMethod( printData );

                                    prtRpt = new ar.ActiveReport3();
                                    // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                                    // ��ŉ���ł���悤�ɑޔ�
                                    _prtRptList.Add( prtRpt );
                                    // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                    # region [���|�[�g��{�ݒ�]
                                    stream.Position = 0;
                                    prtRpt.LoadLayout( stream );
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                                    //SFANL08235CE.AddScriptReference( ref prtRpt );	// Script�p�Q�ƒǉ�
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    prtRpt.Script = string.Empty; // �X�N���v�g�폜
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    SetMargin( prtRpt, dmdPrtPtn );
                                    SetPrinterInfo( prtRpt.Document, prtManage );
                                    SFANL08235CE.SetValidPaperKind( prtRpt );
                                    _reportCtrl.SetReportProps( ref prtRpt ); // ���[���ʐݒ�
                                    prtRpt.DataSource = printData;
                                    prtRpt.DataMember = printData.TableName;
                                    // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                                    SetReportPropsByPrinting( ref prtRpt ); // ���[�ɒǉ��Őݒ�
                                    // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                                    # endregion

                                    # region [���ʑΉ�]
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
                                    //// ���ʂ���ׂ̐���
                                    //DataDynamics.ActiveReports.GroupHeader topHeader;
                                    //try
                                    //{
                                    //    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //}
                                    //catch
                                    //{
                                    //    prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                    //    topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //}
                                    //topHeader.DataField = PMKAU08002AC.ct_col_InpageCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL

                                    // --- DEL m.suzuki 2010/11/10 ---------->>>>>
                                    //// ���v�������E�̎����ȊO�͕��ʂ̍ۂɉ��y�[�W����
                                    //if ( frePrtPSet.FreePrtPprSpPrpseCd != 50 && frePrtPSet.FreePrtPprSpPrpseCd != 80 )
                                    //{
                                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    //    // ���ʂ���ׂ̐���
                                    //    DataDynamics.ActiveReports.GroupHeader topHeader;
                                    //    try
                                    //    {
                                    //        topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //    }
                                    //    catch
                                    //    {
                                    //        prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                    //        topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                                    //    }
                                    //    topHeader.DataField = PMKAU08002AC.ct_col_InpageCount;
                                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    //    topHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
                                    //}
                                    // --- DEL m.suzuki 2010/11/10 ----------<<<<<

                                    // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                                    // ���ʎ��̃^�C�g�������ւ�
                                    // �i��DataTable������������̂ŁA���ʂQ���ڂ̎��������s����Ηǂ��j
                                    if ( copyIndex == 1 )
                                    {
                                        PMKAU08002AC.SetCopyTitle( ref printData );
                                    }
                                    // --- ADD m.suzuki 2010/11/10 ----------<<<<<

                                    # endregion

                                    # region [���׃f�U�C���Ή�]
                                    //ReflectReportDesign(ref prtRpt, billPrtSt, pageIndex, isParent, consTaxLayMethod);//DEL 2011/03/09
                                    ReflectReportDesign(ref prtRpt, dmdPrtPtn, billPrtSt, pageIndex, isParent, consTaxLayMethod);//ADD 2011/03/09
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                                    //ReflectDetailDesign( ref prtRpt );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                                    # endregion

                                    // ������s
                                    prtRpt.Run();

                                    // �L����
                                    PrintMarks( prtRpt, dmdPrtPtn );

                                    // --- DEL m.suzuki 2010/11/17 ---------->>>>> // �������璷�Ȃ̂ō폜
                                    //// ����pDocument�ɂ܂Ƃ߂�
                                    //printDocument.Pages.AddRange( prtRpt.Document.Pages );
                                    // --- DEL m.suzuki 2010/11/17 ----------<<<<<
                                    // --- ADD m.suzuki 2010/11/17 ---------->>>>>
                                    // �^�C�v�ʂɃh�L�������g���܂Ƃ߂�
                                    if ( !documentsDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo( ref document, prtRpt, prtManage );
                                        documentsDic.Add( dmdPrtPtn.SlipPrtSetPaperId, document );
                                    }
                                    documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange( prtRpt.Document.Pages );

                                    // �������ʂɃh�L�������g���܂Ƃ߂�
                                    string derivedNo = PMKAU08002AC.GetDocumentDerivedNo( billRow );
                                    if ( !orgDocuments.ContainsKey( derivedNo ) )
                                    {
                                        Document document = new Document();
                                        SettingDocumentInfo( ref document, prtRpt, prtManage );
                                        orgDocuments.Add( derivedNo, document );
                                    }
                                    orgDocuments[derivedNo].Pages.AddRange( prtRpt.Document.Pages );
                                    // --- ADD m.suzuki 2010/11/17 ----------<<<<<

                                }
                            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
                            }
                            // --- ADD m.suzuki 2010/11/10 ----------<<<<<


                            //if ( prtRpt != null )
                            //{
                            //    SetPrinterInfo( printDocument, prtManage );

                            //    // �p���̎�ނ��w��
                            //    printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                            //    // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                            //    if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                            //    {
                            //        printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                            //    }
                            //    // �p�������i�c�E���j�̐ݒ�
                            //    if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                            //    {
                            //        printDocument.Printer.Landscape = true;
                            //    }
                            //}

                            //// �������
                            //SetPrinterInfo( printDocument, prtManage );

                            // --- DEL m.suzuki 2010/11/17 ---------->>>>> // �璷�ȏ������폜����ׂɃ��[�v�̒��Ɉړ�
                            //// �^�C�v�ʂɃh�L�������g���܂Ƃ߂�
                            //if ( !documentsDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                            //{
                            //    Document document = new Document();
                            //    SettingDocumentInfo( ref document, prtRpt, prtManage );
                            //    documentsDic.Add( dmdPrtPtn.SlipPrtSetPaperId, document );
                            //}
                            //documentsDic[dmdPrtPtn.SlipPrtSetPaperId].Pages.AddRange( printDocument.Pages );

                            //// �������ʂɃh�L�������g���܂Ƃ߂�
                            //string derivedNo = PMKAU08002AC.GetDocumentDerivedNo( billRow );
                            //if ( !orgDocuments.ContainsKey( derivedNo ) )
                            //{
                            //    Document document = new Document();
                            //    SettingDocumentInfo( ref document, prtRpt, prtManage );
                            //    orgDocuments.Add( derivedNo, document );
                            //}
                            //orgDocuments[derivedNo].Pages.AddRange( printDocument.Pages );
                            // --- DEL m.suzuki 2010/11/17 ----------<<<<<

                            stream.Close();

                            // --- DEL m.suzuki 2010/11/10 ---------->>>>>
                            //// --- ADD m.suzuki 2010/07/22 ---------->>>>>
                            //prtRpt.Dispose();
                            //// --- ADD m.suzuki 2010/07/22 ----------<<<<<
                            // --- DEL m.suzuki 2010/11/10 ----------<<<<<
                        }

                        # endregion

                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        if ( printDataList != null )
                        {
                            foreach ( DataTable table in printDataList )
                            {
                                table.Dispose();
                            }
                        }
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                        # endregion
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 DEL
                    //}
                    //finally
                    //{
                    //    processingDialog.Dispose();
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 DEL
                    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                    //// --- UPD m.suzuki 2010/06/23 ---------->>>>>
                    ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    ////processingDialog.Message = "���݁A����������ł��B";
                    ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    //if ( _printInfo.prevkbn == 0 )
                    //{
                    //    // �v���r���[������
                    //    processingDialog.Message = "���݁A����������ł��B";
                    //}
                    //else
                    //{
                    //    // �v���r���[�L�莞
                    //    processingDialog.Dispose();
                    //    disposed = true;
                    //}
                    //// --- UPD m.suzuki 2010/06/23 ----------<<<<<
                    if ( this.MessageChange != null )
                    {
                        // ���b�Z�[�W�ύX����
                        MessageChange( this, new EventArgs() );
                    }
                    // --- UPD m.suzuki 2010/07/22 ----------<<<<<

                    # region [����^�o�c�e�o��]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                    if ( _printCancelFlag )
                    {
                        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                    if ( _printInfo.printmode == 1 || _printInfo.printmode == 3 )
                    {
                        //-------------------------------------------
                        // �@����F�^�C�v���Ɉ�����s
                        //-------------------------------------------
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        if ( _printCancelFlag )
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        foreach ( string typeName in documentsDic.Keys )
                        {
                            ExecutePrint( documentsDic[typeName], typeName, null );
                        }
                    }
                    if ( _printInfo.printmode == 2 || _printInfo.printmode == 3 )
                    {
                        //-------------------------------------------
                        // �A�o�c�e�F�������ʏo��
                        //-------------------------------------------
                        _pdfPathList = new List<string>();
                        foreach ( string derivedNo in orgDocuments.Keys )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                            if ( _printCancelFlag )
                            {
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                            ExecutePrint( orgDocuments[derivedNo], derivedNo, _pdfPathList );
                        }
                        // --- DEL m.suzuki 2010/07/22 ---------->>>>> // �^�C�v�ʂ̓��\�b�h�𕪂���(��PrintPDF)
                        //// UI�ł̕\���p�Ƀ^�C�v�ʂ��o��
                        //_previewPdfPathList = new List<string>();
                        //foreach ( string typeName in documentsDic.Keys )
                        //{
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                        //    if ( _printCancelFlag )
                        //    {
                        //        return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        //    }
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
                        //    ExecutePrint( documentsDic[typeName], typeName, _previewPdfPathList );
                        //}
                        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                    }
                    # endregion
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
                }
                finally
                {
                    // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                    //// --- UPD m.suzuki 2010/06/23 ---------->>>>>
                    ////processingDialog.Dispose();
                    //if ( !disposed )
                    //{
                    //    processingDialog.Dispose();
                    //}
                    //// --- UPD m.suzuki 2010/06/23 ----------<<<<<
                    // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD

                string errorMessage = string.Empty;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_BillAllSt] ) errorMessage += "�����S�̐ݒ�" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_BillPrtSt] ) errorMessage += "���������l�ݒ�" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_DmdPrtPtn] ) errorMessage += "����������p�^�[���ݒ�" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_FrePrtPSet] ) errorMessage += "���R���[�󎚈ʒu�ݒ�" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_PrtManage] ) errorMessage += "�v�����^�ݒ�" + Environment.NewLine;
                if ( errReasonDic[PMKAU08002AB.CT_BillList_FrePBillHead] ) errorMessage += "�������f�[�^" + Environment.NewLine;

                if ( errorMessage != string.Empty )
                {
                    errorMessage = "�ݒ肪�s���ȈׁA����ł��Ȃ��f�[�^������܂����B" + Environment.NewLine + Environment.NewLine + errorMessage;
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", errorMessage, 0, MessageBoxButtons.OK );
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                // �^�C�v�ʃh�L�������g���Z�b�g(�O������Q�Ƃł���悤�ɂ���)
                _documentByTypeDic = documentsDic;
                // ����h�L�������g�ޔ�(���Ƃ�Dispose�����)
                _orgDocuments = orgDocuments;
                // --- ADD m.suzuki 2010/07/22 ----------<<<<<
            }
            catch( Exception ex )
            {
                TMsgDisp.Show( emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKAU08001P", ex.Message, 0, MessageBoxButtons.OK );
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

# if DEBUG
            //string txt = string.Empty;
            //foreach ( string str in _pdfPathList )
            //{
            //    txt += str + Environment.NewLine;
            //}
            //MessageBox.Show( txt );

            //txt = string.Empty;
            //foreach ( string str in _previewPdfPathList )
            //{
            //    txt += str + Environment.NewLine;
            //}
            //MessageBox.Show( txt );
# endif

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            // �ԋp�O�ɒ��[��������������(�Œ�)
            _printInfo.prpnm = _reportTitle;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        // --- ADD m.suzuki 2010/11/16 ---------->>>>>
        # region [���|�[�g�ɑ΂��钠�[�����ݒ菈��]
        /// <summary>
        /// ���[�����ݒ菈��
        /// </summary>
        /// <param name="prtRpt"></param>
        private void SetReportPropsByPrinting( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
        {
            if ( _existsMesh )
            {
                // �s�J�E���g��������
                _lineCount = 0;

                // "����"�Z�N�V�������擾
                ar.Section detail = prtRpt.Sections["Detail1"];
                if ( detail != null && detail.Type == DataDynamics.ActiveReports.SectionType.Detail )
                {
                    // "����"�Z�N�V�����̈���O�C�x���g��ݒ�
                    detail.BeforePrint += new EventHandler( ReportDetail_BeforePrint );

                    // ���|�[�g�̉��y�[�W�C�x���g��ݒ�
                    prtRpt.PageEnd += new EventHandler( Report_PageEnd );
                }
            }
        }
        /// <summary>
        /// ���׃Z�N�V��������O����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportDetail_BeforePrint( object sender, EventArgs e )
        {
            if ( sender is ar.Section )
            {
                ar.Section detail = (sender as ar.Section);
                foreach ( ar.ARControl control in detail.Controls )
                {
                    // 74:�Ԋ|���̐���
                    if ( control != null &&
                         control is ar.Shape &&
                         control.Tag is string &&
                         (control.Tag as string).StartsWith( "74," ) )
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_PageEnd( object sender, EventArgs e )
        {
            // ������
            _lineCount = 0;
        }
        # endregion
        // --- ADD m.suzuki 2010/11/16 ----------<<<<<

        // --- DEL m.suzuki 2010/07/22 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/02 ADD
        ///// <summary>
        ///// ����L�����Z���{�^��
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void processingDialog_CancelButtonClick( object sender, EventArgs e )
        //{
        //    // ����L�����Z���t���O�𗧂Ă�
        //    _printCancelFlag = true;
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/02 ADD
        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// ����L�����Z��
        /// </summary>
        public void Cancel()
        {
            // ����L�����Z���t���O�𗧂Ă�
            _printCancelFlag = true;
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// PDF�L�����Z���f���Q�[�g��`
        /// </summary>
        /// <returns></returns>
        public delegate bool PDFCancelDelegate();

        /// <summary>
        /// PDF�o�͏���
        /// </summary>
        /// <param name="printInfo"></param>
        /// <param name="documentsDic"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="cancelDelegate"></param>
        /// <returns></returns>
        public static List<string> PrintPDF( ref SFCMN06002C printInfo, Dictionary<string, Document> documentsDic, int slipPrtKind, PDFCancelDelegate cancelDelegate )
        {
            List<string> previewPdfPathList = new List<string>();

            // ���[�^�C�g��
            string reportTitle;
            if ( slipPrtKind != 80 )
            {
                reportTitle = "������";
            }
            else
            {
                reportTitle = "�̎���";
            }


            foreach ( string typeName in documentsDic.Keys )
            {
                // �L�����Z��(delegate�ɂ��Ăяo�����Ŕ��f)
                if ( cancelDelegate != null && cancelDelegate() )
                {
                    break;
                }

                //--------------------------------------------------
                // PDF���[��
                //--------------------------------------------------
                # region [PDF���[��]
                // PDF���[��
                printInfo.prpnm = string.Format( "{0}({1})", reportTitle, typeName );

                // ���ʏ����ݒ�
                SFCMN00293UC commonInfo;
                SetPrintCommonInfo( out commonInfo, printInfo, reportTitle );
                printInfo.pdftemppath = commonInfo.PdfFullPath;
                if ( previewPdfPathList != null )
                {
                    previewPdfPathList.Add( commonInfo.PdfFullPath );
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

                    pdfExport1.Export( doc, printInfo.pdftemppath );
                    printInfo.status = 0;
                }
                catch ( Exception ex )
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
                if ( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    switch ( printInfo.printmode )
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
                                pdfHistoryControl.AddPrintInfo( printInfo.key, reportTitle, reportTitle, printInfo.pdftemppath );
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
        /// SetPrintCommonInfo(static�p)
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <param name="printInfo"></param>
        /// <param name="reportTitle"></param>
        private static void SetPrintCommonInfo( out SFCMN00293UC commonInfo, SFCMN06002C printInfo, string reportTitle )
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

            status = cmnCommon.GetPdfSavePathName( printInfo.prpnm, ref pdfPath, ref pdfName );
            printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = 0;
            // ���]��
            commonInfo.MarginsLeft = 0;
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        /// <summary>
        /// ����h�L�������g���ݒ�
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="prtRpt"></param>
        /// <param name="prtManage"></param>
        private void SettingDocumentInfo( ref Document printDocument, DataDynamics.ActiveReports.ActiveReport3 prtRpt, PrtManage prtManage )
        {
            if ( prtRpt != null )
            {
                SetPrinterInfo( printDocument, prtManage );

                // �p���̎�ނ��w��
                printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                {
                    printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                }
                // �p�������i�c�E���j�̐ݒ�
                if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                {
                    printDocument.Printer.Landscape = true;
                }
            }
        }

        /// <summary>
        /// �L���������
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <remarks>�������ꂽ����h�L�������g�ɑ΂��ċL����`��������</remarks>
        private void PrintMarks( DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn )
        {
            if ( _printMarkDic == null || _printMarkDic.Count == 0 ) return;

            float adjustX = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.LeftMargin);
            float adjustY = ar.ActiveReport3.CmToInch((float)dmdPrtPtn.TopMargin);

            foreach ( Page page in prtRpt.Document.Pages )
            {
                // �܂�Ԃ��}�[�N(>)
                foreach ( PrintMarkScheme mark in _printMarkDic[64] )
                {
                    page.TextAngle = 900; // ���v���90.0�x
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font( "�l�r�S�V�b�N", mark.Size );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
                    page.DrawText( "��", new System.Drawing.RectangleF( mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f ) );
                }

                // �܂�Ԃ��}�[�N(<)
                foreach ( PrintMarkScheme mark in _printMarkDic[65] )
                {
                    page.TextAngle = -900; // �����v���90.0�x
                    page.ForeColor = mark.ForeColor;
                    page.Font = new System.Drawing.Font( "�l�r�S�V�b�N", mark.Size );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                    page.TextAlignment = DataDynamics.ActiveReports.TextAlignment.Left;
                    page.VerticalTextAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Top;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD
                    page.DrawText( "��", new System.Drawing.RectangleF( mark.Position.X + adjustX, mark.Position.Y + adjustY, 0.5f, 0.5f ) );
                }
            }
        }
        /// <summary>
        /// ���C�A�E�g���擾�i�P�y�[�W�ڂ̃w�b�_�������ו��ɑ������邩�Ȃǁj
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private void SearchPrintLayout( FrePrtPSetWork frePrtPSet )
        {
            // �����l�ݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 DEL
            //_feedAddCount = 1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
            _feedAddCount = 0; // �Q�Ŗڈȍ~�̍s�������̓f�t�H���g0
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
            _footerTitleOfSlip = "*�`�[�v*";
            _footerTitleOfDaily = "*���v*";
            _footerTitleOfCustomer = "*���Ӑ�v*";
            _taxTitle = "�����";
            // --- ADD  ���r��  2010/07/09 ---------->>>>>
            _ofsThisSalesTaxIncTtl = "*���㍇�v���z(�ō�)*";
            // --- ADD  ���r��  2010/07/09 ----------<<<<<
            // --- ADD  ���r��  2009/12/11 ---------->>>>>
            _carmngCodeTitle = "�v���[�g�ԍ�";
            // --- ADD  ���r��  2009/12/11 ----------<<<<<
            // --- ADD  ���r��  2010/06/16 ---------->>>>>
            _footerTitleOfTax = "*�����*";
            _footerTitleOfSlipTaxInc = "*�ېō��v*";
            // --- ADD  ���r��  2010/06/16 ----------<<<<<
            // 2010/05/25 Add >>>
            _slipTtlTaxTitle = "�����";
            // 2010/11/05 Add >>>
            _depositFooterTitleOfSlip = "*�����v*";
            _footerTitleOfSlipTaxInc2 = "�ېō��v";
            _footerTitleOfTax2 = "�����";
            // 2010/11/05 Add <<<
            // --- UPD  ���r��  2010/07/09 ---------->>>>>
            //Dictionary<string, string> reportItemDic = PMKAU08002AC.ReportItemDic;
            //if (reportItemDic == null)
            //{
            //    reportItemDic = new Dictionary<string, string>();
            //}
            Dictionary<string, string> reportItemDic = new Dictionary<string, string>();
            // --- UPD  ���r��  2010/07/09 ----------<<<<<
            // 2010/05/25 Add <<<

            // ���C�A�E�g���̎�荞��
            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            {
                // ���C�A�E�g���擾
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );


                foreach ( ar.Section section in prtRpt.Sections )
                {
                    foreach ( ar.ARControl control in section.Controls )
                    {
                        // 2010/05/25 Add >>>
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
                        // 2010/05/25 Add <<<

                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            // --- ADD  ���r��  2010/06/16 ---------->>>>>
                            // 53:����t�b�^
                            case "53,":
                                _existsSalesFooter = true;
                                break;
                            // --- ADD  ���r��  2010/06/16 ----------<<<<<
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
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                                _feedAddCount += 1; // ���ɏo�׍ς݂̋�ڲ��Ă̌݊�����ۂ���,�{�P����
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                                _feedAddCount += GetFeedAddCount( control );
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
                                if ( (control as ar.Label).Visible )
                                {
                                    AddToMarkDic( 64, (control as ar.Label) );
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // 65:�܂�Ԃ��}�[�N(<)
                            case "65,":
                                if ( (control as ar.Label).Visible )
                                {
                                    AddToMarkDic( 65, (control as ar.Label) );
                                }
                                (control as ar.Label).Visible = false;
                                break;
                            // --- ADD  ���r��  2009/12/11 ---------->>>>>
                            // 66:�^�C�g���ݒ�i�v���[�g�ԍ��j
                            case "66,":
                                _carmngCodeTitle = (control as ar.Label).Text;
                                break;
                            // --- ADD  ���r��  2009/12/11 ----------<<<<<
                            // 2010/05/25 Add >>>
                            // 67:�`�[���v����Ń��e����
                            case "67,":
                                _slipTtlTaxTitle = (control as ar.Label).Text;
                                break;
                            // 2010/05/25 Add <<<
                            // --- ADD  ���r��  2010/06/16 ---------->>>>>
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
                            // --- ADD  ���r��  2010/06/16 ----------<<<<<                        
                            // --- ADD  ���r��  2010/07/09 ----------<<<<<
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
                            // --- ADD  ���r��  2010/07/09 ---------->>>>>
                            // --- ADD m.suzuki 2010/11/16 ---------->>>>>
                            //74:���זԊ|��
                            case "74,":
                                _existsMesh = true;
                                break;
                            // --- ADD m.suzuki 2010/11/16 ----------<<<<<
                        }
                    }
                }

                // 2010/05/25 Add >>>
                PMKAU08002AC.ReportItemDic = reportItemDic;
                // 2010/05/25 Add <<<

                // �X�g���[������
                stream.Close();
            }
        }
        /// <summary>
        /// �L���f�B�N�V���i���ɒǉ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arLabel"></param>
        private void AddToMarkDic( int key, ar.Label arLabel )
        {
            string text = arLabel.Text;

            if ( text.Contains( "," ) )
            {
                string[] subText = text.Split( ',' );
                if ( subText.Length >= 2 )
                {
                    float posX = ToSingle( subText[0] );
                    float posY = ToSingle( subText[1] );

                    // �f�B�N�V���i����������΍쐬
                    if ( _printMarkDic == null )
                    {
                        _printMarkDic = new Dictionary<int, List<PrintMarkScheme>>();
                    }
                    // �f�B�N�V���i�����Ƀ��X�g��������ΐ���
                    if ( !_printMarkDic.ContainsKey( key ) )
                    {
                        _printMarkDic.Add( key, new List<PrintMarkScheme>() );
                    }

                    // �f�B�N�V���i�������X�g�ɒǉ�
                    _printMarkDic[key].Add( new PrintMarkScheme( new PointF( posX, posY ), arLabel.ForeColor, arLabel.Font.Size ) );
                }
            }
        }
        /// <summary>
        /// �����񁨐��l(float)�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static private float ToSingle( string text )
        {
            try
            {
                return float.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �R���g���[�������FeedAddCount�擾�i�e�L�X�g���j
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int GetFeedAddCount(ar.ARControl control)
        {
            if ( control is ar.Label )
            {
                return GetInt( (control as ar.Label).Text );
            }
            return 0;
        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int GetInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ���or����v���r���[���s
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="derivedNo"></param>
        /// <param name="pdfList"></param>
        private void ExecutePrint( Document printDocument, string derivedNo, List<string> pdfList )
        {
            # region // DEL
            ////if ( isDirectPrint )
            ////{
            ////    // ������s
            ////    bool printStatus = printDocument.Print( false, false, false );

            ////    if ( printStatus )
            ////    {
            ////        this._printInfo.status = 0;
            ////    }
            ////    else
            ////    {
            ////        this._printInfo.status = 9;
            ////    }
            ////}
            ////else
            ////{
            ////    //Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

            ////    //// ���ʏ����ݒ�
            ////    //SFCMN00293UC commonInfo;
            ////    //SetPrintCommonInfo( out commonInfo, dmdPrtPtn, frePrtPSet, prtManage );
            ////    //viewForm.CommonInfo = commonInfo;
            ////    //// �v���r���[���s
            ////    //status = viewForm.Run( prtRpt );
            ////    //// �߂�l�ݒ�
            ////    //this._printInfo.status = status;

            ////    // ����v���r���[�\��
            ////    SFMIT01290UB para = new SFMIT01290UB();
            ////    para.PrintDocument = printDocument;
            ////    para.PreviewDocument = printDocument;
            ////    para.ExpansionRate = 50;

            ////    SFMIT01290UA form = new SFMIT01290UA();
            ////    this._printInfo.status = form.PrintPreview( para );
            ////}
            # endregion

            // ���̐ݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
            //_printInfo.prpnm = string.Format( "������({0})", derivedNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
            _printInfo.prpnm = string.Format( "{0}({1})", _reportTitle, derivedNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

            // ���ʏ����ݒ�
            SFCMN00293UC commonInfo;
            SetPrintCommonInfo( out commonInfo );
            _printInfo.pdftemppath = commonInfo.PdfFullPath;
            if ( pdfList != null )
            {
                pdfList.Add( commonInfo.PdfFullPath );
            }

            // �v���r���[�L��				
            int mode = this._printInfo.prevkbn;

            // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
            if ( this._printInfo.printmode == 2 )
            {
                mode = 0;
            }

            switch ( mode )
            {
                case 0:
                    {
                        // �v���r���[��
                        # region [�v���r���[��]
                        // �@���ڈ��
                        if ( this._printInfo.printmode == 1 || this._printInfo.printmode == 3 )
                        {
                            bool printStatus = printDocument.Print( false, false, false );

                            if ( printStatus )
                            {
                                this._printInfo.status = 0;
                            }
                            else
                            {
                                this._printInfo.status = 9;
                            }
                        }
                        // �APDF�o��
                        if ( this._printInfo.printmode == 2 || this._printInfo.printmode == 3 )
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

                                pdfExport1.Export( printDocument, _printInfo.pdftemppath );
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
                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        //this._printInfo.status = form.PrintPreview( para );
                        this._printInfo.status = form.PrintPreviewDefaultSetting( para );
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                        form.Dispose();
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
                        # endregion

                        break;
                    }
            }

            // �o�c�e�o�͂̏ꍇ
            # region [�o�c�e�o�͂̏ꍇ�̏���]
            if ( this._printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                switch ( this._printInfo.printmode )
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
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
                            //pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                            //    this._printInfo.pdftemppath );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                            pdfHistoryControl.AddPrintInfo( this._printInfo.key, _reportTitle, _reportTitle, this._printInfo.pdftemppath );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                            pdfHistoryControl.Dispose();
                            // --- ADD m.suzuki 2010/07/22 ----------<<<<<
                        }
                        break;
                }
            }
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <param name="billPrtSt"></param>
        /// <remarks>ReflectDetailDesign�̓��e�͂�����Ɉڍs</remarks>
        /// <br>Update Note: 2011/03/09 yangmj readmine #19751�Ή�</br>
        //private void ReflectReportDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod )//DEL 2011/03/09
        private void ReflectReportDesign(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DmdPrtPtnWork dmdPrtPtn, BillPrtStWork billPrtSt, int layoutChangeIndex, bool isParent, int consTaxLayMethod)//ADD 2011/03/09
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                //// ���׃Z�N�V�����擾
                //ar.Section detail = prtRpt.Sections["Detail1"];

                // ���׃f�U�C���p���x��
                ar.Label designSalesHeader = null;
                ar.Label designSalesDetail = null;
                ar.Label designSalesFooter = null;
                ar.Label designSalesTotal = null;
                ar.Label designDepositDetail = null;
                ar.Label designDepositTotal = null;
                // --- ADD  ���r��  2010/06/16 ---------->>>>>
                ar.Label designSalesFooter2 = null;
                // --- ADD  ���r��  2010/06/16 ----------<<<<<
                // --- ADD  ���r��  2010/07/09 ---------->>>>>
                ar.Label designSalesFooter3 = null;
                ar.Label designSalesHeader2 = null;
                // --- ADD  ���r��  2010/07/09 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD


                // �S�Z�N�V����
                foreach ( ar.Section section in prtRpt.Sections )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                    if ( section is ar.GroupHeader )
                    {
                        // �O���[�v�ێ��n�m
                        (section as ar.GroupHeader).GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                        // �J��Ԃ��n�m
                        (section as ar.GroupHeader).RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
                        //(section as ar.GroupHeader).IsRepeating = true;
                        // ���y�[�W�t�B�[���h
                        (section as ar.GroupHeader).DataField = PMKAU08002AC.ct_col_PageCount;
                    }
                    //else if ( sectino is ar.GroupFooter )
                    //{
                    //    ( sectino as ar.GroupFooter ).
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                    // �Z�N�V�����̃R���g���[���𒲍�
                    foreach ( ar.ARControl control in section.Controls )
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
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
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                            case "55,":
                                {
                                    //-----ADD 2011/03/09----->>>>>
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
                                    //// 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
                                    //switch (billPrtSt.BillCoNmPrintOutCd)
                                    //{
                                    //    case 0:
                                    //    case 1:
                                    //        break;
                                    //    case 2:
                                    //    case 3:
                                    //    default:
                                    //        {
                                    //            control.Visible = false;
                                    //        }
                                    //        break;
                                    //}
                                    //-----ADD 2011/03/09-----<<<<<
                                }
                                break;
                            case "58,":
                                // ���C�A�E�g����i�P�Ŗځj
                                // ���̃R���g���[���̓\���Ă���Z�N�V�������󎚂ɂ���
                                if ( layoutChangeIndex != 0 )
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "59,":
                                // ���C�A�E�g����i�Q�Ŗڈȍ~�j
                                // ���̃R���g���[���̓\���Ă���Z�N�V�������󎚂ɂ���
                                if ( layoutChangeIndex == 0 )
                                {
                                    section.Visible = false;
                                }
                                break;
                            case "60,":
                                // �ӏ���Ń^�C�g��
                                if ( !isParent || consTaxLayMethod == 9 )
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU08002AC.ct_col_TaxTitle;
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
                            // --- ADD  ���r��  2010/06/16 ---------->>>>>
                            case "68,":
                                designSalesFooter2 = (ar.Label)control;
                                break;
                            // --- ADD  ���r��  2010/06/16 ----------<<<<<
                            // --- ADD  ���r��  2010/07/09 ---------->>>>>
                            case "71,":
                                // ���E�㔄�㍇�v���z(�ō�)�^�C�g��
                                if (!isParent || consTaxLayMethod == 9)
                                {
                                    control.Visible = false;
                                }
                                else
                                {
                                    control.DataField = PMKAU08002AC.ct_col_OfsThisSalesTaxIncTtl;
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
                            // --- ADD  ���r��  2010/07/09 ----------<<<<<
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/28 ADD
                        // �e��w�b�_�E�t�b�^�̂�
                        if ( section.Type != DataDynamics.ActiveReports.SectionType.Detail )
                        {
                            string[] tagParams;
                            //--------------------------------------------------
                            // ����y�[�W�敪�i�S�y�[�W�^�P�y�[�W�ڂ̂݁j�̑Ή�
                            //--------------------------------------------------
                            try
                            {
                                tagParams = ((string)control.Tag).Split( ',' );
                            }
                            catch
                            {
                                continue;
                            }
                            if ( tagParams.Length > 1 )
                            {
                                string printPageCtrlDivCd = tagParams[1].Trim();
                                if ( printPageCtrlDivCd == "1" )
                                {
                                    if ( layoutChangeIndex != 0 )
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
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/28 ADD
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                    # region [���ڃO���[�v��]
                    if ( section is ar.Detail )
                    {
                        ar.Detail detail = (section as ar.Detail);

                        // �Ώۃf�[�^�t�B�[���h���X�g�擾
                        List<string> salesHeaderList = PMKAU08002AC.GetDesignSalesHeaderList();
                        List<string> salesFooterList = PMKAU08002AC.GetDesignSalesFooterList();
                        List<string> salesDetailList = PMKAU08002AC.GetDesignSalesDetailList();
                        List<string> salesTotalList = PMKAU08002AC.GetDesignSalesTotalList();
                        List<string> depositDetailList = PMKAU08002AC.GetDesignDepositDetailList();
                        List<string> depositTotalList = PMKAU08002AC.GetDesignDepositTotalList();
                        // --- ADD  ���r��  2010/06/16 ---------->>>>>
                        List<string> salesFooter2List = PMKAU08002AC.GetDesignSalesFooter2List();
                        // --- ADD  ���r��  2010/06/16 ----------<<<<<
                        // --- ADD  ���r��  2010/07/09 ---------->>>>>
                        List<string> salesFooter3List = PMKAU08002AC.GetDesignSalesFooter3List();
                        List<string> salesHeader2List = PMKAU08002AC.GetDesignSalesHeader2List();
                        // --- ADD  ���r��  2010/07/09 ----------<<<<<

                        if ( designSalesHeader == null )
                        {
                            // ����w�b�_�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăw�b�_���X�g���N���A
                            salesDetailList.AddRange( salesHeaderList );
                            salesHeaderList.Clear();
                        }
                        if ( designSalesFooter == null )
                        {
                            // ����t�b�^�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^���X�g���N���A
                            salesDetailList.AddRange( salesFooterList );
                            salesFooterList.Clear();
                        }
                        if ( designSalesTotal == null )
                        {
                            // ����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��Ĕ���W�v���X�g���N���A
                            salesDetailList.AddRange( salesTotalList );
                            salesTotalList.Clear();
                        }
                        if ( designSalesDetail == null )
                        {
                            // ���㖾�׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
                            salesDetailList.Clear();
                        }
                        if ( designDepositTotal == null )
                        {
                            // �����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ē����W�v���X�g���N���A
                            depositDetailList.AddRange( depositTotalList );
                            depositTotalList.Clear();
                        }
                        if ( designDepositDetail == null )
                        {
                            // �������׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
                            depositDetailList.Clear();
                        }
                        // --- ADD  ���r��  2010/06/16 ---------->>>>>
                        if (designSalesFooter2 == null)
                        {
                            //����t�b�^�Q�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^�Q���X�g���N���A
                            salesDetailList.AddRange(salesFooter2List);
                            salesFooter2List.Clear();
                        }
                        // --- ADD  ���r��  2010/06/16 ----------<<<<<
                        // --- ADD  ���r��  2010/07/09 ---------->>>>>
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
                        // --- ADD  ���r��  2010/07/09 ----------<<<<<

                        // �S�ẴR���g���[���𒲍�
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( salesHeaderList.Contains( dataField ) )
                                {
                                    // ����w�b�_���ڂ̏ꍇ
                                    control.Top -= designSalesHeader.Top;
                                }
                                else if ( salesFooterList.Contains( dataField ) )
                                {
                                    // ����t�b�^���ڂ̏ꍇ
                                    control.Top -= designSalesFooter.Top;
                                }
                                else if ( salesTotalList.Contains( dataField ) )
                                {
                                    // ����W�v���ڂ̏ꍇ
                                    control.Top -= designSalesTotal.Top;
                                }
                                else if ( salesDetailList.Contains( dataField ) )
                                {
                                    // ���㖾�׍��ڂ̏ꍇ
                                    control.Top -= designSalesDetail.Top;
                                }
                                else if ( depositTotalList.Contains( dataField ) )
                                {
                                    // �����W�v���ڂ̏ꍇ
                                    control.Top -= designDepositTotal.Top;
                                }
                                else if ( depositDetailList.Contains( dataField ) )
                                {
                                    // �������׍��ڂ̏ꍇ
                                    control.Top -= designDepositDetail.Top;
                                }
                                // --- ADD  ���r��  2010/06/16 ---------->>>>>
                                else if ( salesFooter2List.Contains( dataField ) )
                                {
                                    //����t�b�^�Q�̏ꍇ
                                    control.Top -= designSalesFooter2.Top;
                                }
                                // --- ADD  ���r��  2010/06/16 ----------<<<<<
                                // --- ADD  ���r��  2010/07/09 ---------->>>>>
                                else if ( salesFooter3List.Contains( dataField ) )
                                {
                                    //����t�b�^�R�̏ꍇ
                                    control.Top -= designSalesFooter3.Top; 
                                }
                                else if (salesHeader2List.Contains(dataField))
                                {
                                    //����w�b�_�Q�̏ꍇ
                                    control.Top -= designSalesHeader2.Top;
                                }
                                // --- ADD  ���r��  2010/07/09 ----------<<<<<
                            }
                        }
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
                }
            }
            catch
            {
            }
        }

        // 2011/01/13 Add >>>
        /// <summary>
        /// DetailLine��`�悷�邩�ǂ����𔻒f���܂��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        void _reportCtrl_BeforePrintEditLine(object sender, PMCMN02000CA.BeforePrintEditLineEventArgs e)
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
        /// <param name="arControlList"></param>
        /// <returns>�擾�����l</returns>
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
        // 2011/01/13 Add <<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
        ///// <summary>
        ///// ���׃f�U�C���K�p
        ///// </summary>
        ///// <param name="prtRpt"></param>
        ///// <remarks>���X�g�ɑ����鍀�ڂ̏c�ʒu�𒲐�����</remarks>
        //private void ReflectDetailDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
        //{
        //    try
        //    {
        //        // ���׃Z�N�V�����擾
        //        ar.Section detail = prtRpt.Sections["Detail1"];

        //        // ���׃f�U�C���p���x��
        //        ar.Label designSalesHeader = null;
        //        ar.Label designSalesDetail = null;
        //        ar.Label designSalesFooter = null;
        //        ar.Label designSalesTotal = null;
        //        ar.Label designDepositDetail = null;
        //        ar.Label designDepositTotal = null;

        //        // ���׃Z�N�V�����̃R���g���[���𒲍�
        //        foreach ( ar.ARControl control in detail.Controls )
        //        {
        //            string tagText = (string)control.Tag;
        //            tagText = tagText.Substring( 0, 3 );

        //            switch ( tagText )
        //            {
        //                case "51,":
        //                    designSalesHeader = (ar.Label)control;
        //                    break;
        //                case "52,":
        //                    designSalesDetail = (ar.Label)control;
        //                    break;
        //                case "53,":
        //                    designSalesFooter = (ar.Label)control;
        //                    break;
        //                case "54,":
        //                    designDepositDetail = (ar.Label)control;
        //                    break;
        //                case "56,":
        //                    designSalesTotal = (ar.Label)control;
        //                    break;
        //                case "57,":
        //                    designDepositTotal = (ar.Label)control;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        // �Ώۃf�[�^�t�B�[���h���X�g�擾
        //        List<string> salesHeaderList = PMKAU08002AC.GetDesignSalesHeaderList();
        //        List<string> salesFooterList = PMKAU08002AC.GetDesignSalesFooterList();
        //        List<string> salesDetailList = PMKAU08002AC.GetDesignSalesDetailList();
        //        List<string> salesTotalList = PMKAU08002AC.GetDesignSalesTotalList();
        //        List<string> depositDetailList = PMKAU08002AC.GetDesignDepositDetailList();
        //        List<string> depositTotalList = PMKAU08002AC.GetDesignDepositTotalList();

        //        if ( designSalesHeader == null )
        //        {
        //            // ����w�b�_�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăw�b�_���X�g���N���A
        //            salesDetailList.AddRange( salesHeaderList );
        //            salesHeaderList.Clear();
        //        }
        //        if ( designSalesFooter == null )
        //        {
        //            // ����t�b�^�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ăt�b�^���X�g���N���A
        //            salesDetailList.AddRange( salesFooterList );
        //            salesFooterList.Clear();
        //        }
        //        if ( designSalesTotal == null )
        //        {
        //            // ����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��Ĕ���W�v���X�g���N���A
        //            salesDetailList.AddRange( salesTotalList );
        //            salesTotalList.Clear();
        //        }
        //        if ( designSalesDetail == null )
        //        {
        //            // ���㖾�׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
        //            salesDetailList.Clear();
        //        }
        //        if ( designDepositTotal == null )
        //        {
        //            // �����W�v�f�U�C���K�C�h�������ꍇ�͖��׃��X�g�Ɉڂ��ē����W�v���X�g���N���A
        //            depositDetailList.AddRange( depositTotalList );
        //            depositTotalList.Clear();
        //        }
        //        if ( designDepositDetail == null )
        //        {
        //            // �������׃f�U�C���K�C�h�������ꍇ�̓��X�g���N���A
        //            depositDetailList.Clear();
        //        }

        //        // �S�ẴR���g���[���𒲍�
        //        foreach ( ar.ARControl control in detail.Controls )
        //        {
        //            if ( control is ar.TextBox )
        //            {
        //                string dataField = control.DataField.ToUpper();

        //                if ( salesHeaderList.Contains( dataField ) )
        //                {
        //                    // ����w�b�_���ڂ̏ꍇ
        //                    control.Top -= designSalesHeader.Top;
        //                }
        //                else if ( salesFooterList.Contains( dataField ) )
        //                {
        //                    // ����t�b�^���ڂ̏ꍇ
        //                    control.Top -= designSalesFooter.Top;
        //                }
        //                else if ( salesTotalList.Contains( dataField ) )
        //                {
        //                    // ����W�v���ڂ̏ꍇ
        //                    control.Top -= designSalesTotal.Top;
        //                }
        //                else if ( salesDetailList.Contains( dataField ) )
        //                {
        //                    // ���㖾�׍��ڂ̏ꍇ
        //                    control.Top -= designSalesDetail.Top;
        //                }
        //                else if ( depositTotalList.Contains( dataField ) )
        //                {
        //                    // �����W�v���ڂ̏ꍇ
        //                    control.Top -= designDepositTotal.Top;
        //                }
        //                else if ( depositDetailList.Contains( dataField ) )
        //                {
        //                    // �������׍��ڂ̏ꍇ
        //                    control.Top -= designDepositDetail.Top;
        //                }
        //            }
        //        }
        //        //detail.Height = designSalesDetail.Height;
        //    }
        //    catch
        //    {
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
        /// <summary>
        /// �e�[�u���Z����NULL���菈��
        /// </summary>
        /// <param name="cellObject"></param>
        /// <returns></returns>
        private bool IsNull( object cellObject )
        {
            return (cellObject == null || cellObject == DBNull.Value);
        }
        /// <summary>
        /// �]���ݒ菈��
        /// </summary>
        /// <param name="rpt">�A�N�e�B�u���|�[�g�I�u�W�F�N�g</param>
        /// <param name="dmdPrtPtn">����������p�^�[��</param>
        /// <remarks>
        /// <br>Note		: �]���ݒ�����܂��B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.08.09</br>
        /// </remarks>
        private void SetMargin( ar.ActiveReport3 rpt, DmdPrtPtnWork dmdPrtPtn )
        {
            // ��̗]����ݒ�
            rpt.PageSettings.Margins.Top
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.TopMargin );
            // ���̗]����ݒ�
            rpt.PageSettings.Margins.Bottom
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.BottomMargin );
            // ���̗]����ݒ�
            rpt.PageSettings.Margins.Left
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.LeftMargin );
            // �E�̗]����ݒ�
            rpt.PageSettings.Margins.Right
                = ar.ActiveReport3.CmToInch( (float)dmdPrtPtn.RightMargin );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 ADD
            // Report��PrintWidth��inch�P�ʂŒ��r���[�ȏꍇ�A�s�v�ȋ�y�[�W���������Ă��܂��̂Ŗh�~����B
            // (������R�ʈȍ~�͐؂�̂Ă�)
            int width = (int)((float)rpt.PrintWidth * (float)100.0f);
            rpt.PrintWidth = (float)width / (float)100.0f;
            // �]����������
            rpt.PrintWidth -= (rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 ADD
        }

        /// <summary>
        /// �v�����^�[���Z�b�g����
        /// </summary>
        /// <param name="document">���|�[�gDocument</param>
        /// <param name="prtManage"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �v�����^�[����ݒ肵�܂��B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.08.09</br>
        /// </remarks>
        private void SetPrinterInfo( Document document, PrtManage prtManage )
        {
            // �g�p�v�����^�[�̐ݒ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //foreach ( string wkStr in PrinterSettings.InstalledPrinters )
            //{
            //    if ( wkStr.Equals( prtManage.PrinterName ) )
            //    {
            //        document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

            // �g�p�v�����^�̗L���L���`�F�b�N�i�L���ł͖����ꍇ�͉��z�v�����^���g�p�j
            if ( !document.Printer.PrinterSettings.IsValid )
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void CreateReport ( out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid )
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private object LoadAssemblyReport ( string asmname, string classname, Type type )
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
                Type objType = asm.GetType( classname );
                if ( objType != null )
                {
                    if ( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) )
                    {
                        obj = Activator.CreateInstance( objType );
                    }
                }
            }
            catch ( System.IO.FileNotFoundException )
            {
                throw new StockMoveException( asmname + "�����݂��܂���B", -1 );
            }
            catch ( System.Exception er )
            {
                throw new StockMoveException( er.Message, -1 );
            }
            return obj;
        }
        #endregion

        #region �� �����ʋ��ʏ��ݒ�

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void SetPrintCommonInfo ( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 DEL
            //// ���[��
            //commonInfo.PrintName = "������";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            // ���[��
            commonInfo.PrintName = _reportTitle;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
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

            status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = 0;//this._printInfo.py;
            // ���]��
            commonInfo.MarginsLeft = 0;//this._printInfo.px;
        }

        #endregion

        #region �� �e��v���p�e�B�ݒ�

        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private int SettingProperty ( ref DataDynamics.ActiveReports.ActiveReport3 rpt )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            //// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            //IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            //// ��������擾
            //FrePBillCndtn extraInfo = (FrePBillCndtn)this._printInfo.jyoken;

            //// �\�[�g���v���p�e�B�ݒ�
            //instance.PageHeaderSortOderTitle = "";

            //// ���[�o�͐ݒ���擾 
            //PrtOutSet prtOutSet;
            //string message;
            //int st = FrePBillAcs.ReadPrtOutSet( out prtOutSet, out message );
            //if ( st != 0 )
            //{
            //    throw new StockMoveException( message, status );
            //}



            //// ���o�����w�b�_�o�͋敪
            //instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            //// ���o�����ҏW����
            //StringCollection extraInfomations;
            //this.MakeExtarCondition( out extraInfomations );

            //instance.ExtraConditions = extraInfomations;

            //// �t�b�^�o�͋敪
            //instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            //// �t�b�^�o�̓��b�Z�[�W
            //StringCollection footers = new StringCollection();
            //footers.Add( prtOutSet.PrintFooter1 );
            //footers.Add( prtOutSet.PrintFooter2 );

            //instance.PageFooters = footers;

            //// ������I�u�W�F�N�g
            //instance.PrintInfo = this._printInfo;

            //// �w�b�_�[�T�u�^�C�g��
            //object[] titleObj = new object[] { "���R���[�i�������j" };
            //instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

            //// ���̑��f�[�^
            //// Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
            //instance.OtherDataList = null;

            //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region �� ���o�����o�͏��쐬
        ///// <summary>
        ///// ���o�����o�͏��쐬
        ///// </summary>
        ///// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        ///// <remarks>
        ///// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        ///// <br>Programmer : 22018 ��� ���b</br>
        ///// <br>Date       : 2007.09.19</br>
        ///// </remarks>
        //private void MakeExtarCondition ( out StringCollection extraConditions )
        //{
            //const string dateFormat = "yyyy�NMM��dd��";

            //extraConditions = new StringCollection();
            //StringCollection addConditions = new StringCollection();
            //string stDate = string.Empty;
            //string edDate = string.Empty;


            ////-------------------------------------------------------------------------------------------------------------------
            //// ���͓�
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue ) || ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue ) )
            //{
            //    // �J�n
            //    if ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SearchSlipDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // �I��
            //    if ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SearchSlipDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "���͓�" + ct_RangeConst, stDate, edDate ) );
            //}
            ////-------------------------------------------------------------------------------------------------------------------
            //// ���ϓ�

            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( (this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue) )
            //{
            //    // �J�n
            //    if ( this._estimateListCndtn.St_SalesDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // �I��
            //    if ( this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "���ϓ�" + ct_RangeConst, stDate, edDate ) );
            //}

            ////----------------------------------------------------------------------------------------------------------------
            //// ���Ӑ�
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( this._estimateListCndtn.St_CustomerCode != 0 || this._estimateListCndtn.Ed_CustomerCode != 999999999 )
            //{
            //    string stCode = this._estimateListCndtn.St_CustomerCode.ToString();
            //    string edCode = this._estimateListCndtn.Ed_CustomerCode.ToString();
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���Ӑ�" + ct_RangeConst, stCode, edCode ) );
            //}

            ////-------------------------------------------------------------------------------------------------------------------
            //// �S���� 
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( this._estimateListCndtn.St_SalesEmployeeCd != string.Empty || this._estimateListCndtn.Ed_SalesEmployeeCd != string.Empty )
            //{
            //    string stCode = this._estimateListCndtn.St_SalesEmployeeCd;
            //    string edCode = this._estimateListCndtn.Ed_SalesEmployeeCd;
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "�S����" + ct_RangeConst, stCode, edCode ) );
            //}

            //// �ǉ�
            //foreach ( string exCondStr in addConditions )
            //{
            //    extraConditions.Add( exCondStr );
            //}
        //}
        #endregion

        #region �� ���o�͈͕�����쐬
        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private string GetConditionRange ( string title, string startString, string endString )
        {
            string result = "";
            if ( ( startString != "" ) || ( endString != "" ) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startString != "" ) start = startString;
                if ( endString != "" ) end = endString;
                result = String.Format( title + ct_RangeConst, start, end );
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private void EditCondition ( ref StringCollection editArea, string target )
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS( target );

            for ( int i = 0; i < editArea.Count; i++ )
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if ( editArea[i] != null )
                {
                    areaByte = TStrConv.SizeCountSJIS( editArea[i] );
                }

                if ( ( areaByte + targetByte + 2 ) <= 190 )
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if ( editArea[i] != null ) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // �V�K�ҏW�G���A�쐬
            if ( !isEdit )
            {
                editArea.Add( target );
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "PMKAU08001P", iMsg, iSt, iButton, iDefButton );
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
            public PrintMarkScheme( PointF position, Color foreColor, float size )
            {
                _position = position;
                _foreColor = foreColor;
                _size = size;
            }
        }
        # endregion
        #endregion

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// �j������
        /// </summary>
        public void Dispose()
        {
            // �^�C�v�ʃh�L�������g���
            if ( _documentByTypeDic != null )
            {
                foreach ( Document doc in _documentByTypeDic.Values )
                {
                    doc.Dispose();
                }
                _documentByTypeDic = null;
            }
            // ����h�L�������g���
            if ( _orgDocuments != null )
            {
                foreach ( Document doc in _orgDocuments.Values )
                {
                    doc.Dispose();
                }
                _orgDocuments = null;
            }
            // ���[���ʕ��i�L���b�V���N���A
            if ( _reportCtrl != null )
            {
                _reportCtrl.Clear();
                _reportCtrl = null;
            }
            // --- ADD m.suzuki 2010/11/10 ---------->>>>>
            // ���|�[�g�N���X
            if ( _prtRptList != null )
            {
                foreach ( ar.ActiveReport3 report in _prtRptList )
                {
                    report.Dispose();
                }
                _prtRptList = null;
            }
            // --- ADD m.suzuki 2010/11/10 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
    }
}
