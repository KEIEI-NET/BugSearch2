//****************************************************************************//
// �V�X�e��         : ���M�O���X�g
// �v���O��������   : ���M�O���X�g ����N���X
// �v���O�����T�v   : ���M�O���X�g ����N���X���������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/09/11  �C�����e : MAHNB02012P�F�����m�F�\���Q�l�ɐV�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���M�O���X�g ����N���X
    /// </summary>
    public sealed class PMUOE02034PA : IPrintProc
    {
        #region <��O/>

        /// <summary>
        /// ���M�O���X�g��O�N���X
        /// </summary>
        private class SendBeforeOrderException : ApplicationException
        {
            /// <summary>�X�e�[�^�X</summary>
            private readonly int _status;
            /// <summary>
            /// �X�e�[�^�X���擾���܂��B
            /// </summary>
            /// <value>�X�e�[�^�X</value>
            public int Status { get { return _status; } }

            /// <summary>
            ///�J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public SendBeforeOrderException(
                string message,
                int status
            ) : base(message)
            {
                _status = status;
            }
        }

        #endregion  // <��O/>

        #region <IPrintProc �����o/>

        #region <������/>

        /// <summary>������</summary>
        private SFCMN06002C _printInfo;
        /// <summary>
        /// ������̃A�N�Z�T
        /// </summary>
        /// <value>������</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }

        #endregion  // <������/>

        /// <summary>
        /// ����������J�n���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        public int StartPrint()
        {
            return PrintMain();
        }

        /// <summary>
        /// ����������s���܂��B
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ����t�H�[��
            DataDynamics.ActiveReports.ActiveReport3 printingReport = null;

            try
            {
                // ���|�[�g�C���X�^���X�𐶐�
                printingReport = CreateReport(Printinfo.prpid);
                if (printingReport == null) return status;

                // �e��v���p�e�B��ݒ�
                status = SetPropertyOf(ref printingReport);
                if (!status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL)) return status;

                // �f�[�^�\�[�X�ݒ�
                printingReport.DataSource = (DataSet)Printinfo.rdData;
                printingReport.DataMember = SendBeforeAcs.SearchedDataTableName;

                // ������ʏ��𐶐�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo = CreatePrintCommonInfo();

                // �v���r���[�L��				
                int mode = Printinfo.prevkbn;
                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                if (Printinfo.printmode.Equals(2))  // HACK:(Magic Number)�o�̓��[�h.PDF
                {
                    mode = 0;   // HACK:(Magic Number)�o�̓��[�h.�v���r���[����
                }
                switch (mode)
                {
                    case 0: // HACK:(Magic Number)�o�̓��[�h.�v���r���[����
                    {
                        Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                        // ���ʏ�����ݒ�
                        processForm.CommonInfo = commonInfo;

                        // �v���O���X�o�[UP�C�x���g��ǉ�
                        if (printingReport is IPrintActiveReportTypeCommon)
                        {
                            ((IPrintActiveReportTypeCommon)printingReport).ProgressBarUpEvent += new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                        }

                        // ��������s
                        status = processForm.Run(printingReport);

                        // �߂�l��ݒ�
                        Printinfo.status = status;

                        break;
                    }
                    case 1: // HACK:(Magic Number)�o�̓��[�h.�v���r���[�L��
                    {
                        Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                        // ���ʏ�����ݒ�
                        viewForm.CommonInfo = commonInfo;

                        // �v���r���[�����s
                        status = viewForm.Run(printingReport);

                        // �߂�l��ݒ�
                        Printinfo.status = status;

                        break;
                    }
                }

                // �o�c�e�o�͂̏ꍇ
                if (status.Equals((int)ConstantManagement.MethodResult.ctFNC_NORMAL))
                {
                    switch (Printinfo.printmode)
                    {
                        case 1:  // HACK:(Magic Number)������[�h.�v�����^
                            break;
                        case 2:  // HACK:(Magic Number)������[�h.�o�c�e
                        case 3:  // HACK:(Magic Number)������[�h.����(�v�����^ + �o�c�e)
                        {
                            // �o�c�e�\���t���OON
                            Printinfo.pdfopen = true;

                            // ����������̂ݗ���ۑ�
                            if (Printinfo.printmode == 3)   // HACK:(Magic Number)������[�h.����(�v�����^ + �o�c�e)
                            {
                                // �o�͗����Ǘ��ɒǉ�
                                Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                pdfHistoryControl.AddPrintInfo(
                                    Printinfo.key,
                                    Printinfo.prpnm,
                                    Printinfo.prpnm,
                                    Printinfo.pdftemppath
                                );
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, STATUS_OF_ERROR, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (printingReport != null) printingReport.Dispose();
            }

            return status;
        }

        #region <���[�\�z/>

        /// <summary>���[�t�H�[���̖��O���</summary>
        private const string REPORT_FORM_NAME_SPACE = "Broadleaf.Drawing.Printing";

        /// <summary>
        /// �e��ActiveReport���[�̃C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <param name="reportId">���[�t�H�[��ID</param>
        /// <returns>�e��ActiveReport���[�̃C���X�^���X</returns>
        private static DataDynamics.ActiveReports.ActiveReport3 CreateReport(string reportId)
        {
            // ����t�H�[���N���X�̃C���X�^���X���쐬
            return (DataDynamics.ActiveReports.ActiveReport3)CreateInstanceFromAssembly(
                reportId.Trim(),
                REPORT_FORM_NAME_SPACE + "." + reportId.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3)
            );
        }

        /// <summary>
        /// �A�Z���u������C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <param name="assemblyName">�A�Z���u������</param>
        /// <param name="className">�N���X����</param>
        /// <param name="type">�N���X�^</param>
        /// <returns>�C���X�^���X</returns>
        private static object CreateInstanceFromAssembly(
            string assemblyName,
            string className,
            Type type
        )
        {
            object instance = null;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(assemblyName);
            Type loadedType = assembly.GetType(className);
            if (loadedType != null)
            {
                if (
                    (loadedType == type)
                        ||
                    loadedType.IsSubclassOf(type)
                        ||
                    (loadedType.GetInterface(type.Name).Name.Equals(type.Name)))
                {
                    instance = Activator.CreateInstance(loadedType);
                }
            }
            
            return instance;
        }

        /// <summary>
        /// �e��v���p�e�B��ݒ肵�܂��B
        /// </summary>
        /// <param name="reportForm">���[�t�H�[��</param>
        /// <returns>���ʃR�[�h</returns>
        private int SetPropertyOf(ref DataDynamics.ActiveReports.ActiveReport3 reportForm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList activeReport = reportForm as IPrintActiveReportTypeList;

            // ����������擾
            SendBeforeOrderCondition extraInfo = (SendBeforeOrderCondition)Printinfo.jyoken;

            // �\�[�g���v���p�e�B��ݒ�
            activeReport.PageHeaderSortOderTitle = string.Empty;

            // ���[�o�͐ݒ�����擾 
            PrtOutSet printOutSet;
            string message;
            int result = SendBeforeAcs.ReadPrtOutSet(out printOutSet, out message);
            if (!result.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                throw new SendBeforeOrderException(message, status);
            }

            // ���o�����w�b�_�o�͋敪
            activeReport.ExtraCondHeadOutDiv = printOutSet.ExtraCondHeadOutDiv;

            // ���o�����̕ҏW����
            StringCollection extraInfomations = CreateStringCollectionOfExtractionCondition();
            activeReport.ExtraConditions = extraInfomations;

            // �t�b�^�o�͋敪
            activeReport.PageFooterOutCode = printOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            {
                footers.Add(printOutSet.PrintFooter1);
                footers.Add(printOutSet.PrintFooter2);
            }
            activeReport.PageFooters = footers;

            // ������I�u�W�F�N�g
            activeReport.PrintInfo = Printinfo;

            // �w�b�_�[�T�u�^�C�g��
            activeReport.PageHeaderSubtitle = string.Empty;

            // ���̑��f�[�^
            ArrayList otherDataList = new ArrayList();
            activeReport.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #region <���[�w�b�_�i���o�����j/>

        /// <summary>
        /// ���o�����̕�����R���N�V�����𐶐����܂��B
        /// </summary>
        /// <returns>���o�����̕�����R���N�V����</returns>
        private StringCollection CreateStringCollectionOfExtractionCondition()
        {
            const string THAT = ": ";
            const string FROM_BEGIN = "�ŏ�����";   // HACK:�ŏ�����
            const string TO_END     = "�Ō�܂�";   // HACK:�Ō�܂�
            const string WAVE = " �` ";
            const string ONLINE_NO_FORMAT           = "000000000";
            const string UOE_SUPPLIER_CODE_FORMAT   = "000000";

            StringCollection extraConditions= new StringCollection();
            StringCollection addConditions  = new StringCollection();

            string target = string.Empty;

            // �V�X�e���敪
            EditCondition(ref addConditions, SendBeforeOrderCondition.SYSTEM_DIV_CD_TITLE + THAT + ExtractionCondition.SystemDivName);

            // �����
            EditCondition(ref addConditions, SendBeforeOrderCondition.PRINT_ORDER_TITLE + THAT + ExtractionCondition.PrintOrderName);

            // �����ԍ�
            string fromOnLineNo = ExtractionCondition.St_OnlineNo.ToString(ONLINE_NO_FORMAT);
            string toOnLineNo   = ExtractionCondition.Ed_OnlineNo.ToString(ONLINE_NO_FORMAT);
            if ((ExtractionCondition.St_OnlineNo.Equals(0)) && (!ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + FROM_BEGIN + WAVE + toOnLineNo;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_OnlineNo > 0) && (ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + fromOnLineNo + WAVE + TO_END;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_OnlineNo > 0) && (!ExtractionCondition.Ed_OnlineNo.Equals(0)))
            {
                target = SendBeforeOrderCondition.ONLINE_NO_TITLE + THAT + fromOnLineNo + WAVE + toOnLineNo;
                EditCondition(ref addConditions, target);
            }

            // ������
            string fromUOESupplierCode  = ExtractionCondition.St_UOESupplierCd.ToString(UOE_SUPPLIER_CODE_FORMAT);
            string toUOESupplierCode    = ExtractionCondition.Ed_UOESupplierCd.ToString(UOE_SUPPLIER_CODE_FORMAT);
            if ((ExtractionCondition.St_UOESupplierCd.Equals(0)) && (!ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + FROM_BEGIN + WAVE + toUOESupplierCode;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_UOESupplierCd > 0) && (ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + fromUOESupplierCode + WAVE + TO_END;
                EditCondition(ref addConditions, target);
            }
            if ((ExtractionCondition.St_UOESupplierCd > 0) && (!ExtractionCondition.Ed_UOESupplierCd.Equals(0)))
            {
                target = SendBeforeOrderCondition.UOE_SUPPLIER_CD_TITLE + THAT + fromUOESupplierCode + WAVE + toUOESupplierCode;
                EditCondition(ref addConditions, target);
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }

            return extraConditions;
        }

        /// <summary>
        /// �o�͂��钊�o�����������ҏW���܂��B
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        private static void EditCondition(
            ref StringCollection editArea,
            string target
        )
        {
            const string SPACE_CHAR = "�@"; // �󔒕���

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

                if ((areaByte + targetByte + 2) <= 190) // LITERAL:190[Byte]
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[i] != null) editArea[i] += SPACE_CHAR;

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

        #endregion  // <���[�w�b�_�i���o�����j/>

        #endregion  // <���[�\�z/>

        #region <����_�C�A���O/>

        /// <summary>
        /// �����ʂ̋��ʏ��𐶐����܂��B
        /// </summary>
        /// <returns>�����ʂ̋��ʏ��</returns>
        private Broadleaf.Windows.Forms.SFCMN00293UC CreatePrintCommonInfo()
        {
            Broadleaf.Windows.Forms.SFCMN00293UC commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // �v�����^��
            commonInfo.PrinterName = Printinfo.prinm;
            // ���[��
            commonInfo.PrintName = Printinfo.prpnm;
            // ������[�h
            commonInfo.PrintMode = Printinfo.printmode;
            // �������
            commonInfo.PrintMax = 0;

            // PDF�p�X�擾
            string pdfPath = string.Empty;
            string pdfName = string.Empty;

            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();
            int status = cmnCommon.GetPdfSavePathName(Printinfo.prpnm, ref pdfPath, ref pdfName);

            Printinfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = Printinfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = Printinfo.py;
            // ���]��
            commonInfo.MarginsLeft = Printinfo.px;

            return commonInfo;
        }

        #endregion  // <����_�C�A���O/>

        #endregion  // <IPrintProc �����o/>

        #region <���o����/>

        /// <summary>���o����</summary>
        private readonly SendBeforeOrderCondition _extractionCondition;
        /// <summary>
        /// ���o�������擾���܂��B
        /// </summary>
        /// <value>���o����</value>
        private SendBeforeOrderCondition ExtractionCondition { get { return _extractionCondition; } }

        #endregion  // <���o����/>

        #region <Constructor/>

        /// <summary>
		/// �J�X�^���N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������</param>
        public PMUOE02034PA(object printInfo)
		{
			_printInfo = printInfo as SFCMN06002C;
			_extractionCondition = _printInfo.jyoken as SendBeforeOrderCondition;
        }

        #endregion  // <Constructor/>

        #region <�G���[���b�Z�[�W�\��/>

        /// <summary>�ُ�</summary>
        private int STATUS_OF_ERROR = -1;

        /// <summary>
		/// �G���[���b�Z�[�W��\�����܂��B
		/// </summary>
        /// <param name="errorLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="button">�\���{�^��</param>
        /// <param name="defaultButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
		/// <returns>�_�C�A���O�̑��쌋��</returns>
		private static DialogResult ShowErrorMessage(
            emErrorLevel errorLevel,
            string message,
            int status,
            MessageBoxButtons button,
            MessageBoxDefaultButton defaultButton
        )
		{
            const string PG_ID = "PMUOE02034P"; // HACK:�v���O����ID
			return TMsgDisp.Show(errorLevel, PG_ID, message, status, button, defaultButton);
        }

        #endregion  // <�G���[���b�Z�[�W�\��/>
    }
}
