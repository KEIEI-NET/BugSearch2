//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ꊇ�o�^�E�C���U����N���X �}�X����
// �v���O�����T�v   : �|���ꊇ�o�^�E�C���U����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v��
// �� �� ��  2013/02/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Collections.Specialized;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �|���ꊇ�o�^�E�C���U����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ꊇ�o�^�E�C���U�̈�����s���B</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    public class PMKHN09909PA : IPrintProc
    {
        #region �� Constructor
		/// <summary>
        /// �|���ꊇ�o�^�E�C���U����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �|���ꊇ�o�^�E�C���U����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
		public PMKHN09909PA()
		{
		}

		/// <summary>
        /// �|���ꊇ�o�^�E�C���U����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �|���ꊇ�o�^�E�C���U����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public PMKHN09909PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            _tegataConfirmReport = this._printInfo.jyoken as Rate2SearchParam;
        }
		#endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string STR_TOP = "�ŏ�����";
        private const string STR_END = "�Ō�܂�";
        
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private Rate2SearchParam _tegataConfirmReport;		// ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        /// <remarks>
        /// <br>Note       : �|���ꊇ�o�^�E�C���U�̗�O�N���X</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks> 
        private class TegataConfirmReportException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            /// <remarks>
            /// <br>Note       : �Ȃ�</br>
            /// <br>Programmer : �v��</br>
            /// <br>Date       : 2013/02/19</br>
            /// </remarks>
            public TegataConfirmReportException(string message, int status)
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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
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
                string filter = string.Empty;
                // �\�[�g��
                string sort = string.Empty;
                DataTable data = ((DataSet)this._printInfo.rdData).Tables[PMKHN09903EC.ct_Tbl_ReportData];

                data = sortTable(data);
                DataView dr = new DataView(data);
                prtRpt.DataSource = dr;

                prtRpt.DataMember = PMKHN09903EC.ct_Tbl_ReportData;

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

        #region �� �\�[�g����
        /// <summary>
        /// �\�[�g����
        /// </summary>
        /// <returns>DataTable</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g�������s���B</br>
        /// <br>Programmer : wangqx</br>
        /// <br>Date       : 2013/03/01</br>
        /// </remarks>
        private DataTable sortTable(DataTable data)
        {
            // �y�[�W��31���ׂ��\��
            if (data.Rows.Count <= PMKHN09903EC.CNTPERPAGE)
            {
                return data;
            }
            DataTable sortedTable = data.Copy();
            sortedTable.Rows.Clear();
            int tempPageCount, tempPageDetailCount = 0;
            //�@�y�[�W�O���[�v��
            int lastPageCount = 0;
            int PageGroupCount = 0;
            int PageKind1Count = 1;
            string PageKind1Col1InputHeadName = "";
            int PageKind1DetailCount = 0;
            bool changeFlag = false;
            // �y�[�W�O���[�v�̖��א��擾����
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (i == 0)
                { 
                    PageKind1Col1InputHeadName = data.Rows[i]["Col1InputHeadName"].ToString();
                }
                if ( !PageKind1Col1InputHeadName.Equals(data.Rows[i]["Col1InputHeadName"].ToString()))
                {
                    changeFlag = true;
                    break;
                }
                else
                {
                    PageKind1DetailCount = PageKind1DetailCount + 1;
                }
            }

            if (!changeFlag)
            {
                return data;
            }
            // �y�[�W�O���[�v��
            PageGroupCount = PageKind1DetailCount / PMKHN09903EC.CNTPERPAGE;
            lastPageCount = PageKind1DetailCount % PMKHN09903EC.CNTPERPAGE;
            if (lastPageCount > 0)
            {
                PageGroupCount = PageGroupCount + 1;
            }
            // �y�[�W��
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (i == 0)
                {
                    PageKind1Col1InputHeadName = data.Rows[i]["Col1InputHeadName"].ToString();
                }
                if (!PageKind1Col1InputHeadName.Equals(data.Rows[i]["Col1InputHeadName"].ToString()))
                {
                    PageKind1Count = PageKind1Count + 1;
                    PageKind1Col1InputHeadName = data.Rows[i]["Col1InputHeadName"].ToString();
                }
            }


            for (int i = 0; i < PageGroupCount; i++)
            {
                tempPageCount = i * PMKHN09903EC.CNTPERPAGE;

                for (int j = tempPageCount; j < (i * PMKHN09903EC.CNTPERPAGE) + PMKHN09903EC.CNTPERPAGE; j++)
                {
                    if (data.Rows.Count > j && PageKind1DetailCount > j)
                    {
                        sortedTable.ImportRow(data.Rows[j]);
                    }
                }
                // �����y�[�W�O���[�v���̑����גǉ�����ǉ�
                for (int detailIndex = 0; detailIndex < PageKind1Count-1; detailIndex++)
                {
                    tempPageDetailCount = detailIndex * PageKind1DetailCount + PageKind1DetailCount + (i * PMKHN09903EC.CNTPERPAGE);
                    for (int k = tempPageDetailCount; k < (tempPageDetailCount + PMKHN09903EC.CNTPERPAGE); k++)
                    {
                        if (data.Rows.Count > k )
                        {
                            if (i == PageGroupCount - 1 && lastPageCount > 0)
                            {
                                if (lastPageCount > (k - tempPageDetailCount))
                                {
                                    sortedTable.ImportRow(data.Rows[k]);
                                }
                            }
                            else
                            {
                                sortedTable.ImportRow(data.Rows[k]);
                            }
                        }
                    }
                }
            }

            return sortedTable;
        }
        #endregion �� �\�[�g����

        #region �� ���o�����o�͏��쐬����
        /// <summary>
        /// ���o�����o�͏��쐬����
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : �v��</br>                                   
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringBuilder tempSB = new StringBuilder();


            tempSB.Append("�d���� : ").Append(_tegataConfirmReport.SupplierCd).Append(" ")
                .Append(_tegataConfirmReport.SupplierNm.Trim()).Append(" ")
                .Append(ct_Space)
                .Append("�o�͋敪�F")
                .Append(_tegataConfirmReport.OutputDiv);
            
            this.EditCondition(ref extraConditions, tempSB.ToString());
        }
        #endregion

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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
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
                throw new TegataConfirmReportException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new TegataConfirmReportException(er.Message, -1);
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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDF�p�X�擾
            string pdfPath = string.Empty;
            string pdfName = string.Empty;

            // �v�����^��
            commonInfo.PrinterName = this._printInfo.prinm;
            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;
            // ������[�h
            commonInfo.PrintMode = this.Printinfo.printmode;
            // �������
            DataSet ds = (DataSet)this._printInfo.rdData;
            commonInfo.PrintMax = ds.Tables[PMKHN09903EC.ct_Tbl_ReportData].Rows.Count;

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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            Rate2SearchParam tegataConfirmReport = (Rate2SearchParam)this._printInfo.jyoken;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);
            instance.ExtraConditions = extraInfomations;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = RateUpdateAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new TegataConfirmReportException(message, status);
            }
            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);
            instance.PageFooters = footers;
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;
            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;
            
            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region �� ���o����������ҏW����
        /// <summary>
        /// ���o����������ҏW����
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : �v��</br>                                   
        /// <br>Date       : 2008.04.28</br>
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
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKHN09909P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
