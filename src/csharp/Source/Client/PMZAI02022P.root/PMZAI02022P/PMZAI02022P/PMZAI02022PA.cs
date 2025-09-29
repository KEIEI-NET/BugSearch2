//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�݌Ƀ}�X�^�ꗗ���
// �v���O�����T�v   �F�݌Ƀ}�X�^�ꗗ�̈�����s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/01/13     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/20     �C�����e�FMantis�y12127�z���x�A�b�v�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/27     �C�����e�FMantis�y12126�z�q�ɂ̃O���[�v�T�v���X�Ή�
//                          �C�����e�FMantis�y11394�z�\�[�g���ݒ�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��ؐ��b
// �C����    2009/05/25     �C�����e�F�h�b�g�v�����^����Ή��B�ʏ�̈�����i���g�p����悤�ύX�B
// ---------------------------------------------------------------------//

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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���R���[�i�݌Ƀ}�X�^�ꗗ�j����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R���[�i�݌Ƀ}�X�^�ꗗ�j�̈�����s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009.01.13</br>
    /// </remarks>
    class PMZAI02022PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// ���R���[�i�݌Ƀ}�X�^�ꗗ�j����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R���[�i�݌Ƀ}�X�^�ꗗ�j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public PMZAI02022PA ()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            this._printARTypeCmn = new PrintActiveReportTypeCommon();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }

        /// <summary>
        /// ���R���[�i�݌Ƀ}�X�^�ꗗ�j����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���R���[�i�݌Ƀ}�X�^�ꗗ�j����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public PMZAI02022PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            this._printARTypeCmn = new PrintActiveReportTypeCommon();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        private const string ct_SortOrder = "STOCKRF.WAREHOUSECODERF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.GOODSNORF, STOCKRF.GOODSMAKERCDRF";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private ExtrInfo_StockMasterTbl _extrInfo;
        private List<string> _pdfPathList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        private PrintActiveReportTypeCommon _printARTypeCmn;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        #endregion �� Private Member

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
        /// ������擾�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ��������J�n
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int StartPrint ()
        {
            return PrintMain();
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int PrintMain ()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
                _printARTypeCmn.ClearCount();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

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

                DataSet printDataSet = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList];
                dv.Sort = ct_SortOrder;

                // ������f�[�^���X�g��W�J
                this._extrInfo = this._printInfo.jyoken as ExtrInfo_StockMasterTbl;
                List<SlipPrtSetWork> slipPrtSetWorkList = null;
                List<CustSlipMngWork> custSlipMngWorkList = null;
                List<FrePrtPSetWork> frePrtPSetWorkList = null;
                List<PrtManage> prtManageList = null;
                List<FrePprSrtOWork> frePprSrtOWorkList = null;     // ADD 2009/04/27

                foreach (object obj in this._extrInfo.PrintInfoList)
                {
                    if (obj is List<SlipPrtSetWork>)
                    {
                        slipPrtSetWorkList = (List<SlipPrtSetWork>)obj;
                    }
                    else if (obj is List<CustSlipMngWork>)
                    {
                        custSlipMngWorkList = (List<CustSlipMngWork>)obj;
                    }
                    else if (obj is List<FrePrtPSetWork>)
                    {
                        frePrtPSetWorkList = (List<FrePrtPSetWork>)obj;
                    }
                    else if (obj is List<PrtManage>)
                    {
                        prtManageList = (List<PrtManage>)obj;
                    }
                    // ADD 2009/04/27 ------>>>
                    else if (obj is List<FrePprSrtOWork>)
                    {
                        frePprSrtOWorkList = (List<FrePprSrtOWork>)obj;
                    }
                    // ADD 2009/04/27 ------<<<
                }

                // ADD 2009/04/27 ------>>>
                // �\�[�g���̐ݒ�
                string sortOrder = SFANL08235CE.GetSortString(frePprSrtOWorkList);
                if (sortOrder != string.Empty)
                {
                    dv.Sort = sortOrder;
                }
                // ADD 2009/04/27 ------<<<

                // PDF�o�͈ꗗ���X�g
                _pdfPathList = new List<string>();

                // ���R���[�󎚈ʒu�ݒ� �擾
                FrePrtPSetWork frePrtPSet = frePrtPSetWorkList[0];
                // �v�����^�Ǘ��ݒ� �擾
                PrtManage prtManage = prtManageList[0];

                # region [�������]
                // ���|�[�g�h�L�������g������
                Document printDocument = new Document();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                //SFCMN00299CA processingDialog = new SFCMN00299CA();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                try
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                    //processingDialog.Title = "�������";
                    //processingDialog.Message = "���݁A����������ł��B";
                    //processingDialog.DispCancelButton = false;
                    //processingDialog.Show();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                    using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
                    {
                        ar.ActiveReport3 prtRpt = null;
                        prtRpt = new ar.ActiveReport3();

                        # region [���|�[�g��{�ݒ�]
                        stream.Position = 0;
                        prtRpt.LoadLayout(stream);
                        //SFANL08235CE.AddScriptReference(ref prtRpt);	// Script�p�Q�ƒǉ�     // DEL 2009/04/20
                        prtRpt.Script = string.Empty;       // ADD 2009/04/20
                        SetPrinterInfo(prtRpt.Document, prtManage);
                        SFANL08235CE.SetValidPaperKind(prtRpt);
                        prtRpt.DataSource = dv;

                        // ADD 2009/04/27 ------>>>
                        // �O���[�v�T�v���X����
                        PMCMN02000CA prtCmn = PMCMN02000CA.GetInstance();
                        prtCmn.GroupSuppressDiv = PMCMN02000CA.GroupSuppressDivState.FreePrint;
                        prtCmn.SetReportProps(ref prtRpt);
                        // ADD 2009/04/27 ------<<<                        
                        # endregion

                        // �y�[�W�Z�N�V�����擾
                        ar.Section pageHeader = prtRpt.Sections["PageHeader1"];
                        foreach (ar.ARControl control in pageHeader.Controls)
                        {
                            if (control.Name == "PrintPageRF")
                            {
                                // �y�[�W���̐ݒ�
                                control.DataField = "";
                                ((ar.TextBox)control).SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
                                ((ar.TextBox)control).SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
                            }
                        }
                        // �O���[�v�Z�N�V�����̎擾
                        ar.Section groupHeader = prtRpt.Sections["GroupHeader1"];
                        foreach (ar.ARControl control in groupHeader.Controls)
                        {
                            if (control.Name == "PrintRangeRF")
                            {
                                // ���o�͈͂̐ݒ�
                                control.DataField = "";
                                string extarCondition;
                                MakeExtarCondition(out extarCondition);
                                ((ar.TextBox)control).Text = extarCondition;
                            }
                        }


                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                        //// ������s
                        //prtRpt.Run();

                        //// ����pDocument�ɂ܂Ƃ߂�
                        //printDocument.Pages.AddRange(prtRpt.Document.Pages);

                        //if (prtRpt != null)
                        //{
                        //    SetPrinterInfo(printDocument, prtManage);

                        //    // �p���̎�ނ��w��
                        //    printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                        //    // �p���T�C�Y���J�X�^���̎��͗p���T�C�Y�܂Ŏw��
                        //    if (prtRpt.PageSettings.PaperKind == PaperKind.Custom)
                        //    {
                        //        printDocument.Printer.PaperSize = new PaperSize("Custom", Convert.ToInt32(prtRpt.PageSettings.PaperWidth * 100), Convert.ToInt32(prtRpt.PageSettings.PaperHeight * 100));
                        //    }
                        //    // �p�������i�c�E���j�̐ݒ�
                        //    if (prtRpt.PageSettings.Orientation == PageOrientation.Landscape)
                        //    {
                        //        printDocument.Printer.Landscape = true;
                        //    }
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD

                        // ������ʏ��v���p�e�B�ݒ�
                        Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                        this.SetPrintCommonInfo( out commonInfo );

                        // �v���r���[�L��				
                        int prevkbn = this._printInfo.prevkbn;

                        // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                        if ( this._printInfo.printmode == 2 )
                        {
                            prevkbn = 0;
                        }
                        switch ( prevkbn )
                        {
                            case 0:		// �v���r����
                                {
                                    Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                                    // ���ʏ����ݒ�
                                    processForm.CommonInfo = commonInfo;

                                    // �v���O���X�o�[UP�C�x���g�ǉ�
                                    DataDynamics.ActiveReports.Detail detail = null;
                                    foreach ( DataDynamics.ActiveReports.Section sec in prtRpt.Sections )
                                    {
                                        if ( sec.Type == DataDynamics.ActiveReports.SectionType.Detail )
                                        {
                                            detail = (sec as DataDynamics.ActiveReports.Detail);
                                            break;
                                        }
                                    }
                                    if ( detail != null )
                                    {
                                        detail.AfterPrint += new EventHandler( PMZAI02022PA_Detail_AfterPrint );
                                        _printARTypeCmn.ProgressBarUpEvent += new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
                                    }

                                    // ������s
                                    status = processForm.Run( prtRpt );

                                    // �߂�l�ݒ�
                                    this._printInfo.status = status;

                                    break;
                                }
                            case 1:		// �v���r���L
                                {
                                    Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                                    // ���ʏ����ݒ�
                                    viewForm.CommonInfo = commonInfo;

                                    // �v���r���[���s
                                    status = viewForm.Run( prtRpt );

                                    // �߂�l�ݒ�
                                    this._printInfo.status = status;

                                    break;
                                }
                        }

                        // �o�c�e�o�͂̏ꍇ
                        if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                        {
                            switch ( this._printInfo.printmode )
                            {
                                case 1:		// �v�����^
                                    break;
                                case 2:		// �o�c�e
                                case 3:		// ����(�v�����^ + �o�c�e)
                                    {
                                        // �o�c�e�\���t���OON
                                        this._printInfo.pdfopen = true;

                                        // ����������̂ݗ���ۑ�
                                        if ( this._printInfo.printmode == 3 )
                                        {
                                            // �o�͗����Ǘ��ɒǉ�
                                            Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                            pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                                this._printInfo.pdftemppath );
                                        }
                                        break;
                                    }
                            }
                        }

                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

                        stream.Close();
                    }
                }
                finally
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                    //processingDialog.Dispose();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
                //if (_printInfo.printmode == 1 || _printInfo.printmode == 3)
                //{
                //    //-------------------------------------------
                //    // �@����F
                //    //-------------------------------------------
                //    ExecutePrint(printDocument, null);
                //}
                //if (_printInfo.printmode == 2)
                //{
                //    //-------------------------------------------
                //    // �A�o�c�e�F
                //    //-------------------------------------------
                //    _pdfPathList = new List<string>();
                //    ExecutePrint(printDocument, _pdfPathList);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL

                # endregion
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        /// <summary>
        /// ���׈����C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02022PA_Detail_AfterPrint( object sender, EventArgs e )
        {
            _printARTypeCmn.CallProgressBarUp();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

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
        /// <param name="pdfList"></param>
        private void ExecutePrint(Document printDocument, List<string> pdfList)
        {
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
                        this._printInfo.status = form.PrintPreview(para);
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
                            pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                this._printInfo.pdftemppath);
                        }
                        break;
                }
            }
            # endregion
        }

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
        /// �v�����^�[���Z�b�g����
        /// </summary>
        /// <param name="document">���|�[�gDocument</param>
        /// <param name="prtManage"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �v�����^�[����ݒ肵�܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009.01.13</br>
        /// </remarks>
        private void SetPrinterInfo( Document document, PrtManage prtManage )
        {
            // �g�p�v�����^�[�̐ݒ�
            document.Printer.PrinterSettings.PrinterName = prtManage.PrinterName;
            
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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

        #region �� �e��v���p�e�B�ݒ�
        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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
            //object[] titleObj = new object[] { "���R���[�i�݌Ƀ}�X�^�ꗗ�j" };
            //instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

            //// ���̑��f�[�^
            //// Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
            //instance.OtherDataList = null;

            //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.02.05</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 DEL
            //int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            //// ���[�`���[�g���ʕ��i�N���X
            //SFCMN00331C cmnCommon = new SFCMN00331C();

            //// PDF�p�X�擾
            //string pdfPath = "";
            //string pdfName = "";

            //// �v�����^��
            //commonInfo.PrinterName = string.Empty;//prtManage.PrinterName;
            //// ���[��
            //commonInfo.PrintName = "�݌Ƀ}�X�^�ꗗ���";
            //// ������[�h

            //try
            //{
            //    commonInfo.PrintMode = this.Printinfo.printmode;
            //}
            //catch
            //{
            //    commonInfo.PrintMode = 1;
            //}

            //// ��������\��
            //commonInfo.PrintMax = 0;

            //status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            //this._printInfo.pdftemppath = pdfPath + pdfName;
            //commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            //// ��]��
            //commonInfo.MarginsTop = 0;//this._printInfo.py;
            //// ���]��
            //commonInfo.MarginsLeft = 0;//this._printInfo.px;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
            SFCMN00331C sfcmn00331C = new SFCMN00331C();

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // �v�����^��
            commonInfo.PrinterName = this._printInfo.prinm;

            // ���[��
            commonInfo.PrintName = "�݌Ƀ}�X�^�ꗗ���";

            // �������
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[PMZAI02029AB.CT_Tbl_StockList].Rows.Count;

            // ������[�h
            commonInfo.PrintMode = this._printInfo.printmode;

            // �]���ݒ�
            // ���ʒu
            commonInfo.MarginsLeft = this._printInfo.px;

            // �s�ʒu
            commonInfo.MarginsTop = this._printInfo.py;

            // PDF�o�̓t���p�X
            string pdfPath = "";
            string pdfName = "";
            sfcmn00331C.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );

            string pdfFileName = System.IO.Path.Combine( pdfPath, pdfName );
            commonInfo.PdfFullPath = pdfFileName;

            this._printInfo.pdftemppath = pdfFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD
        }

        #endregion

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraCondition">�쐬�㒊�o����������</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void MakeExtarCondition(out String extraCondition)
        {
            extraCondition = "";
            StringCollection addConditions = new StringCollection();

            //-------------------------------------------------------------------------------------------------------------------
            // �q�� 
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_WarehouseCode != string.Empty || _extrInfo.Ed_WarehouseCode != string.Empty)
            {
                string stCode = _extrInfo.St_WarehouseCode;
                string edCode = _extrInfo.Ed_WarehouseCode;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�q��" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // �I�� 
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_WarehouseShelfNo != string.Empty || _extrInfo.Ed_WarehouseShelfNo != string.Empty)
            {
                string stCode = _extrInfo.St_WarehouseShelfNo;
                string edCode = _extrInfo.Ed_WarehouseShelfNo;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�I��" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // �d����
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_SupplierCd != 0 || _extrInfo.Ed_SupplierCd != 0)
            {
                string stCode = _extrInfo.St_SupplierCd.ToString("d08");
                string edCode = _extrInfo.Ed_SupplierCd.ToString("d08");
                if (_extrInfo.St_SupplierCd == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_SupplierCd == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�d����" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // ���[�J�[
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_GoodsMakerCd != 0 || _extrInfo.Ed_GoodsMakerCd != 0)
            {
                string stCode = _extrInfo.St_GoodsMakerCd.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsMakerCd.ToString("d04");
                if (_extrInfo.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsMakerCd == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // ���i�啪��
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_GoodsLGroup != 0 || _extrInfo.Ed_GoodsLGroup != 0)
            {
                string stCode = _extrInfo.St_GoodsLGroup.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsLGroup.ToString("d04");
                if (_extrInfo.St_GoodsLGroup == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsLGroup == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // ���i������
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_GoodsMGroup != 0 || _extrInfo.Ed_GoodsMGroup != 0)
            {
                string stCode = _extrInfo.St_GoodsMGroup.ToString("d04");
                string edCode = _extrInfo.Ed_GoodsMGroup.ToString("d04");
                if (_extrInfo.St_GoodsMGroup == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_GoodsMGroup == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // �O���[�v
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_BLGroupCode != 0 || _extrInfo.Ed_BLGroupCode != 0)
            {
                string stCode = _extrInfo.St_BLGroupCode.ToString("d05");
                string edCode = _extrInfo.Ed_BLGroupCode.ToString("d05");
                if (_extrInfo.St_BLGroupCode == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_BLGroupCode == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // BL
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_BLGoodsCode != 0 || _extrInfo.Ed_BLGoodsCode != 0)
            {
                string stCode = _extrInfo.St_BLGoodsCode.ToString("d05");
                string edCode = _extrInfo.Ed_BLGoodsCode.ToString("d05");
                if (_extrInfo.St_BLGoodsCode == 0) stCode = ct_Extr_Top;
                if (_extrInfo.Ed_BLGoodsCode == 0) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            //-------------------------------------------------------------------------------------------------------------------
            // �i�� 
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (_extrInfo.St_GoodsNo != string.Empty || _extrInfo.Ed_GoodsNo != string.Empty)
            {
                string stCode = _extrInfo.St_GoodsNo;
                string edCode = _extrInfo.Ed_GoodsNo;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;

                EditCondition(ref addConditions, string.Format("�i��" + ct_RangeConst, stCode, edCode));
            }

            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraCondition = extraCondition + exCondStr;
            }
        }
        #endregion

        #region �� ���o�͈͕�����쐬
        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "MAZAI02022P", iMsg, iSt, iButton, iDefButton );
        }

        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/25 ADD
        /// <summary>
        /// �v���O���X�o�[�J�E���g�A�b�v�p�N���X
        /// </summary>
        /// <remarks>�ʏ��Report�N���X�Ɏ������܂����A�{�o�f�͎��R���[��Report�̓N���X��`�������Ȃ��ׁA���̃N���X�ő�p���܂��B</remarks>
        private class PrintActiveReportTypeCommon : IPrintActiveReportTypeCommon
        {
            private int _printCount;

            public event ProgressBarUpEventHandler ProgressBarUpEvent;

            public int WatermarkMode
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public PrintActiveReportTypeCommon()
            {
                _printCount = 0;
            }
            /// <summary>
            /// �J�E���g�N���A
            /// </summary>
            public void ClearCount()
            {
                _printCount = 0;
            }
            /// <summary>
            /// �J�E���g�A�b�v�C�x���g�R�[��
            /// </summary>
            public void CallProgressBarUp()
            {
                _printCount++;

                if ( ProgressBarUpEvent != null )
                {
                    ProgressBarUpEvent( this, _printCount );
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/25 ADD

        #endregion
    }
}
