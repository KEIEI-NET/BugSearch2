//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\����N���X
// �v���O�����T�v   : �ԕi���R�ꗗ�\������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �ԕi���R�ꗗ�\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�\�̈�����s���B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class PMHNB02213PA : IPrintProc
    {
        #region �� Constructor
		/// <summary>
        /// �ԕi���R�ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
		public PMHNB02213PA()
		{
		}

		/// <summary>
        /// �ԕi���R�ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PMHNB02213PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            _henbiRiyuListReport = this._printInfo.jyoken as HenbiRiyuListReport;
        }
		#endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string STR_TOP = "�ŏ�����";
        private const string STR_END = "�Ō�܂�";
        private const string ct_Month = "���x";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private HenbiRiyuListReport _henbiRiyuListReport;		// ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        /// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�\�̗�O�N���X</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks> 
        private class HenbiRiyuListReportException : ApplicationException
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
            /// <br>Programmer : ������</br>
            /// <br>Date       : 2009.05.12</br>
            /// </remarks>
            public HenbiRiyuListReportException(string message, int status)
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
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
                prtRpt.DataMember = PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData;

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

        #region �� ���o�����o�͏��쐬����
        /// <summary>
        /// ���o�����o�͏��쐬����
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            // �Ώ۔N��
            string salesDate = this._henbiRiyuListReport.SalesDate.ToString("yyyy/MM");
            this.EditCondition(ref extraConditions, string.Format("�Ώ۔N���F{0} {1}", salesDate, ct_Month));

            // ����
            string changePage = SetChangePage();
            if (!string.IsNullOrEmpty(changePage))
            {
                this.EditCondition(ref extraConditions, string.Format("���ŁF{0}", changePage));
            }
            

            // �`�[���
            string slipKind = string.Empty;
            if (0 == _henbiRiyuListReport.SlipKindCd)
            {
                slipKind = "����";
            }
            if (1 == _henbiRiyuListReport.SlipKindCd)
            {
                slipKind = "�ݏo�܂�";
            }
            this.EditCondition(ref extraConditions, string.Format("�`�[��ʁF{0}", slipKind));

            // ���Ӑ�
            string customerCodeSt = string.Empty;
            string customerCodeEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.CustomerCodeSt))
            {
                customerCodeSt = STR_TOP;
            }
            else
            {
                customerCodeSt = this._henbiRiyuListReport.CustomerCodeSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.CustomerCodeEd))
            {
                customerCodeEd = STR_END;
            }
            else
            {
                customerCodeEd = this._henbiRiyuListReport.CustomerCodeEd;
            }

            if (!STR_TOP.Equals(customerCodeSt) || !STR_END.Equals(customerCodeEd))
            {
                this.EditCondition(ref extraConditions, string.Format("���Ӑ�F{0} �` {1}", customerCodeSt, customerCodeEd));
            }

            // �S����
            string salesEmployeeCdRFSt = string.Empty;
            string salesEmployeeCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesEmployeeCdRFSt))
            {
                salesEmployeeCdRFSt = STR_TOP;
            }
            else
            {
                salesEmployeeCdRFSt = this._henbiRiyuListReport.SalesEmployeeCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesEmployeeCdRFEd))
            {
                salesEmployeeCdRFEd = STR_END;
            }
            else
            {
                salesEmployeeCdRFEd = this._henbiRiyuListReport.SalesEmployeeCdRFEd;
            }

            if (!STR_TOP.Equals(salesEmployeeCdRFSt) || !STR_END.Equals(salesEmployeeCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("�S���ҁF{0} �` {1}", salesEmployeeCdRFSt,salesEmployeeCdRFEd));
            }

            // �󒍎�
            string frontEmployeeCdRFSt = string.Empty;
            string frontEmployeeCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.FrontEmployeeCdRFSt))
            {
                frontEmployeeCdRFSt = STR_TOP;
            }
            else
            {
                frontEmployeeCdRFSt = this._henbiRiyuListReport.FrontEmployeeCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.FrontEmployeeCdRFEd))
            {
                frontEmployeeCdRFEd = STR_END;
            }
            else
            {
                frontEmployeeCdRFEd = this._henbiRiyuListReport.FrontEmployeeCdRFEd;
            }

            if (!STR_TOP.Equals(frontEmployeeCdRFSt) || !STR_END.Equals(frontEmployeeCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("�󒍎ҁF{0} �` {1}", frontEmployeeCdRFSt, frontEmployeeCdRFEd));
            }

            // ���s��
            string salesInputCdRFSt = string.Empty;
            string salesInputCdRFEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesInputCdRFSt))
            {
                salesInputCdRFSt = STR_TOP;
            }
            else
            {
                salesInputCdRFSt = this._henbiRiyuListReport.SalesInputCdRFSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.SalesInputCdRFEd))
            {
                salesInputCdRFEd = STR_END;
            }
            else
            {
                salesInputCdRFEd = this._henbiRiyuListReport.SalesInputCdRFEd;
            }

            if (!STR_TOP.Equals(salesInputCdRFSt) || !STR_END.Equals(salesInputCdRFEd))
            {
                this.EditCondition(ref extraConditions, string.Format("���s�ҁF{0} �` {1}", salesInputCdRFSt, salesInputCdRFEd));
            }

            // �ԕi���R
            string retGoodsReasonDivSt = string.Empty;
            string retGoodsReasonDivEd = string.Empty;

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.RetGoodsReasonDivSt))
            {
                retGoodsReasonDivSt = STR_TOP;
            }
            else
            {
                retGoodsReasonDivSt = this._henbiRiyuListReport.RetGoodsReasonDivSt;
            }

            if (string.IsNullOrEmpty(this._henbiRiyuListReport.RetGoodsReasonDivEd))
            {
                retGoodsReasonDivEd = STR_END;
            }
            else
            {
                retGoodsReasonDivEd = this._henbiRiyuListReport.RetGoodsReasonDivEd;
            }

            if (!STR_TOP.Equals(retGoodsReasonDivSt) || !STR_END.Equals(retGoodsReasonDivEd))
            {
                this.EditCondition(ref extraConditions, string.Format("�ԕi���R�F{0} �` {1}", retGoodsReasonDivSt, retGoodsReasonDivEd));
            }
        }

        /// <summary>
        /// ���ł�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string SetChangePage()
       {
           int changePageDiv = _henbiRiyuListReport.ChangePageDiv;
           int printType = _henbiRiyuListReport.PrintType;
           string changePage = string.Empty;
           // ���_
           if (0 == changePageDiv)
           {
               changePage = "���_";
           }
           // ���v
           else if (1 == changePageDiv)
           {
               changePage = "���v";
           }
           // ���Ȃ�
           else if (2 == changePageDiv)
           {

           }
           return changePage;
           
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
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
                throw new HenbiRiyuListReportException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new HenbiRiyuListReportException(er.Message, -1);
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
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
            commonInfo.PrintMax = ds.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData].Rows.Count;

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            HenbiRiyuListReport henbiRiyuListReport= (HenbiRiyuListReport)this._printInfo.jyoken;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);
            instance.ExtraConditions = extraInfomations;

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
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2008.05.11</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHNB02213P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
