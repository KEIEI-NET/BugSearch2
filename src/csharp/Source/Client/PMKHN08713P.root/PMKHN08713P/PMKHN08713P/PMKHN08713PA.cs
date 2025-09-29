//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections.Specialized;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^�i����j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�i����j�̈�����s���B</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    public class PMKHN08713PA : IPrintProc
    {

        #region �� Constructor
		/// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�i����j�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�i����j�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
		public PMKHN08713PA()
		{
		}

		/// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�i����j�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�i����j�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public PMKHN08713PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._campaignTargetPrintWork = (CampaignTargetPrintWork)this._printInfo.jyoken;
		}
		#endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					                // ������N���X
        private CampaignTargetPrintWork _campaignTargetPrintWork;	    // ���o�����N���X
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int StartPrint()
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                // ���|�[�g�C���X�^���X�쐬
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = this._printInfo.rdData;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // �v���r���[�L��				
                int mode = this._printInfo.prevkbn;

                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                if (this._printInfo.printmode == 2)
                {
                    mode = 0;
                }

                switch (mode)
                {
                    case 0:		// �v���r����
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // ���ʏ����ݒ�
                            processForm.CommonInfo = commonInfo;

                            // �v���O���X�o�[UP�C�x���g�ǉ�
                            if (prtRpt is IPrintActiveReportTypeCommon)
                            {
                                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            }

                            // ������s
                            status = processForm.Run(prtRpt);

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
                            status = viewForm.Run(prtRpt);

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                }

                // �o�c�e�o�͂̏ꍇ
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (this._printInfo.printmode)
                    {
                        case 1:  // �v�����^
                            break;
                        case 2:  // �o�c�e
                        case 3:  // ����(�v�����^ + �o�c�e)
                            {
                                // �o�c�e�\���t���OON
                                this._printInfo.pdfopen = true;

                                // ����������̂ݗ���ۑ�
                                if (this._printInfo.printmode == 3)
                                {
                                    // �o�͗����Ǘ��ɒǉ�
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (prtRpt != null)
                {
                    prtRpt.Dispose();
                }
            }
            return status;
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
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
            commonInfo.PrinterName = this._printInfo.prinm;
            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;
            // ������[�h
            commonInfo.PrintMode = this.Printinfo.printmode;
            // �������
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;

            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = this._printInfo.py;
            // ���]��
            commonInfo.MarginsLeft = this._printInfo.px;
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = CampaignTargetPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new StockMoveException(message, status);
            }

            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            // �w�b�_�[�T�u�^�C�g��
            string st_title = "";
            switch (this._campaignTargetPrintWork.PrintType)
            {
                case 0:
                    st_title = "���_��";
                    break;
                case 1:
                    st_title = "���_�{���Ӑ��";
                    break;
                case 2:
                    st_title = "���_�{�S���ҕ�";
                    break;
                case 3:
                    st_title = "���_�{�󒍎ҕ�";
                    break;
                case 4:
                    st_title = "���_�{���s�ҕ�";
                    break;
                case 5:
                    st_title = "���_�{�n���";
                    break;
                case 6:
                    st_title = "���_�{��ٰ�ߺ��ޕ�";
                    break;
                case 7:
                    st_title = "���_�{BL���ޕ�";
                    break;
                case 8:
                    st_title = "���_�{�̔��敪��";
                    break;
            }

            instance.PageHeaderSubtitle = string.Format("�L�����y�[���ڕW�ݒ�}�X�^(" + st_title + ")");

            // ���̑��f�[�^
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            const string dateFormat = "YYYY/MM/DD";
            string stTarget = "";
            string edTarget = "";

            // �폜���
            if (this._campaignTargetPrintWork.LogicalDeleteCode == 1)
            {
                if ((this._campaignTargetPrintWork.DeleteDateTimeSt != 0) || (this._campaignTargetPrintWork.DeleteDateTimeEd != 0))
                {
                    // �J�n
                    if (this._campaignTargetPrintWork.DeleteDateTimeSt != 0)
                    {
                        stTarget = TDateTime.LongDateToString(dateFormat, this._campaignTargetPrintWork.DeleteDateTimeSt);
                    }
                    else
                    {
                        stTarget = ct_Extr_Top;
                    }
                    // �I��
                    if (this._campaignTargetPrintWork.DeleteDateTimeEd != 0)
                    {
                        edTarget = TDateTime.LongDateToString(dateFormat, this._campaignTargetPrintWork.DeleteDateTimeEd);
                    }
                    else
                    {
                        edTarget = ct_Extr_End;
                    }
                    this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                }
            }

            // �L�����y�[���R�[�h
            if (this._campaignTargetPrintWork.CampaignCodeSt != 0 || this._campaignTargetPrintWork.CampaignCodeEd != 0)
            {
                stTarget = this._campaignTargetPrintWork.CampaignCodeSt.ToString("000000");
                edTarget = this._campaignTargetPrintWork.CampaignCodeEd.ToString("000000");
                if (this._campaignTargetPrintWork.CampaignCodeSt == 0) stTarget = ct_Extr_Top;
                if (this._campaignTargetPrintWork.CampaignCodeEd == 0) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("�L�����y�[���R�[�h" + ct_RangeConst, stTarget, edTarget));

            }

            // ���_�R�[�h
            if (this._campaignTargetPrintWork.SectionCodeSt != string.Empty || this._campaignTargetPrintWork.SectionCodeEd != string.Empty)
            {
                stTarget = this._campaignTargetPrintWork.SectionCodeSt.PadLeft(2, '0');
                edTarget = this._campaignTargetPrintWork.SectionCodeEd.PadLeft(2, '0');
                if (this._campaignTargetPrintWork.SectionCodeSt == string.Empty) stTarget = ct_Extr_Top;
                if (this._campaignTargetPrintWork.SectionCodeEd == string.Empty) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("���_" + ct_RangeConst, stTarget, edTarget));

            }

            switch (this._campaignTargetPrintWork.PrintType)
            {
                case 1:
                    // ���Ӑ�R�[�h
                    if (this._campaignTargetPrintWork.CustomerCodeSt != 0 || this._campaignTargetPrintWork.CustomerCodeEd != 0)
                    {

                        stTarget = this._campaignTargetPrintWork.CustomerCodeSt.ToString("00000000");
                        edTarget = this._campaignTargetPrintWork.CustomerCodeEd.ToString("00000000");
                        if (this._campaignTargetPrintWork.CustomerCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.CustomerCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case 2:
                case 3:
                case 4:
                    // �S���҃R�[�h
                    if (this._campaignTargetPrintWork.EmployeeCodeSt != string.Empty || this._campaignTargetPrintWork.EmployeeCodeEd != string.Empty)
                    {
                        stTarget = this._campaignTargetPrintWork.EmployeeCodeSt.PadLeft(4, '0');
                        edTarget = this._campaignTargetPrintWork.EmployeeCodeEd.PadLeft(4, '0');
                        if (this._campaignTargetPrintWork.EmployeeCodeSt == string.Empty) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.EmployeeCodeEd == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case 5:
                    // �n��R�[�h
                    if (this._campaignTargetPrintWork.SalesAreaCodeSt != 0 || this._campaignTargetPrintWork.SalesAreaCodeEd != 0)
                    {

                        stTarget = this._campaignTargetPrintWork.SalesAreaCodeSt.ToString("0000");
                        edTarget = this._campaignTargetPrintWork.SalesAreaCodeEd.ToString("0000");
                        if (this._campaignTargetPrintWork.SalesAreaCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.SalesAreaCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�n��" + ct_RangeConst, stTarget, edTarget));
                    }

                    break;

                case 6:
                    // ��ٰ�ߺ���
                    if (this._campaignTargetPrintWork.BlGroupCodeSt != 0 || this._campaignTargetPrintWork.BlGroupCodeEd != 0)
                    {

                        stTarget = this._campaignTargetPrintWork.BlGroupCodeSt.ToString("00000");
                        edTarget = this._campaignTargetPrintWork.BlGroupCodeEd.ToString("00000");
                        if (this._campaignTargetPrintWork.BlGroupCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.BlGroupCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("��ٰ�ߺ���" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case 7:
                    // BL����
                    if (this._campaignTargetPrintWork.BlGoodsCdSt != 0 || this._campaignTargetPrintWork.BlGoodsCdEd != 0)
                    {

                        stTarget = this._campaignTargetPrintWork.BlGoodsCdSt.ToString("00000");
                        edTarget = this._campaignTargetPrintWork.BlGoodsCdEd.ToString("00000");
                        if (this._campaignTargetPrintWork.BlGoodsCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.BlGoodsCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("BL����" + ct_RangeConst, stTarget, edTarget));
                    }

                    break;
                case 8:
                    // �̔��敪�R�[�h
                    if (this._campaignTargetPrintWork.SalesCodeSt != 0 || this._campaignTargetPrintWork.SalesCodeEd != 0)
                    {

                        stTarget = this._campaignTargetPrintWork.SalesCodeSt.ToString("0000");
                        edTarget = this._campaignTargetPrintWork.SalesCodeEd.ToString("0000");
                        if (this._campaignTargetPrintWork.SalesCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._campaignTargetPrintWork.SalesCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�̔��敪" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
            }

            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region �� ���o�͈͓��t�쐬
        /// <summary>
        /// ���t�͈̔͏��������񐶐�
        /// </summary>
        /// <param name="dateTitle">���t�^�C�g��</param>
        /// <param name="stDate">�J�n���t</param>
        /// <param name="edDate">�I�����t</param>
        /// <returns></returns>
        private string GetExtarConditionOfDates(string dateTitle, DateTime stDate, DateTime edDate)
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((stDate != DateTime.MinValue) || (edDate != DateTime.MinValue))
            {
                // �J�n
                if (stDate != DateTime.MinValue)
                {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkStDate = ct_Extr_Top;
                }

                // �I��
                if (edDate != DateTime.MinValue)
                {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format(dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
        }
        #endregion �� ���o�͈͓��t�쐬

        #region �� ���o�͈͕�����쐬
        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
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
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKHN08713P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion

    }
}
