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
//using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���Ӑ�d�q��������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����̈�����s���B</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// </remarks>
    class PMKAU04005P : IPrintProc
    {

        #region �v���C�x�[�g�ϐ�

        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�s�n�o";
        private const string ct_Extr_End = "�d�m�c";
        private const string ct_RangeConst = "�F{0} �` {1}";

        private SFCMN06002C _printInfo;					// ������N���X
        private PrintCndtn _localPrintCondition;        // ����w�b�_�󂯓n���N���X
        private PrtOutSet   _prtOutSet;                 // ���[�o�͐ݒ�f�[�^�N���X
        private PrtOutSetAcs _prtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X
        private Employee _employee;                     // ���O�C�����_���擾�p

        #endregion // �v���C�x�[�g�ϐ�

        #region �v���p�e�B

        /// <summary> ������擾�v���p�e�B </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        #endregion // �v���p�e�B

        #region �R���X�g���N�^

        /// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PMKAU04005P()
		{
            // ���O�C�����_�擾
            //_employee = null;
            //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            //if (loginEmployee != null)
            //{
            //    _employee = loginEmployee.Clone();
            //}

            //this._localPrintCondition = this.Printinfo.jyoken as PrintCndtn;     // �w�b�_���
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
        public PMKAU04005P(object printInfo)
		{
            //// ���O�C�����_�擾
            //_employee = null;
            //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            //if (loginEmployee != null)
            //{
            //    _employee = loginEmployee.Clone();
            //}

           
			this._printInfo = printInfo as SFCMN06002C;                             // ������i�[�I�u�W�F�N�g
            this._localPrintCondition = this.Printinfo.jyoken as PrintCndtn;     // �w�b�_���
        }

        #endregion // �R���X�g���N�^

        #region �p�u���b�N���\�b�h

        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        public int StartPrint()
        {
            return PrintMain();
        }

        #endregion // �p�u���b�N���\�b�h

        #region �v���C�x�[�g���\�b�h

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
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
                //prtRpt.DataMember = DCHAT02104EA.ct_Tbl_OrderList;

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
                    case 0:
                        {
                            // �v���r���[��c
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // ���ʏ����ݒ�
                            processForm.CommonInfo = commonInfo;

# if DEBUG
# else
                            // �v���O���X�o�[UP�C�x���g�ǉ�
                            if (prtRpt is IPrintActiveReportTypeCommon)
                            {
                                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            }
# endif

                            // ������s
                            status = processForm.Run(prtRpt);

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		
                        {
                            // �v���r���[�L
                            Broadleaf.Windows.Forms.SFCMN00293UA previewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // ���ʏ����ݒ�
                            previewForm.CommonInfo = commonInfo;

                            // �v���r���[���s
                            status = previewForm.Run(prtRpt);

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

        #region ActiveReport���[�C���X�^���X�쐬

        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 reportObj, string printFormId)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            reportObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                printFormId.Trim(), ct_ReportForm_NameSpace + "." + printFormId.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        #endregion // ActiveReport���[�C���X�^���X�쐬

        #region ���|�[�g�A�Z���u���C���X�^���X��

        /// <summary>
        /// ���|�[�g�A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
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
                throw new AssemblyErrorException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception ex)
            {
                throw new AssemblyErrorException(ex.Message, -1);
            }
            return obj;
        }

        #endregion // ���|�[�g�A�Z���u���C���X�^���X��

        #region �����ʋ��ʏ��ݒ�

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();

            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
            commonInfo.PrinterName = this._printInfo.prinm;                     // �v�����^��
            commonInfo.PrintName = this._printInfo.prpnm;		                // ���[��
            commonInfo.PrintMode = this.Printinfo.printmode;                   // ������[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
            //commonInfo.PrintMax = (this._printInfo.rdData as DataTable).Rows.Count;   // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
            if ( this._printInfo.rdData is DataView )
            {
                commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;   // �������
            }
            else if ( this._printInfo.rdData is DataTable )
            {
                commonInfo.PrintMax = (this._printInfo.rdData as DataTable).Rows.Count;   // �������
            }
            else
            {
                commonInfo.PrintMax = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
            commonInfo.MarginsTop = this._printInfo.py;                         // ��]��
            commonInfo.MarginsLeft = this._printInfo.px;                        // ���]��

            // PDF�p�X�擾
            string pdfPath = "";
            string pdfName = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;               // PDF�p�X
        }

        #endregion

        #region �e��v���p�e�B�ݒ�

        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            //PrintCndtn extraInfo = (PrintCndtn)this._localPrintCondition;
            this._printInfo.jyoken = (object)this._localPrintCondition;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = string.Empty;

            // ���[�o�͐ݒ���擾
            // ���O�C�����_�擾
            _employee = null;
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                _employee = loginEmployee.Clone();
            }

            _prtOutSetAcs = new PrtOutSetAcs();
            status = _prtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, _employee.BelongSectionCode);
            string msg;
            if (status != 0)
            {
                msg = "���[�o�͐ݒ���擾�Ɏ��s���܂����B";
                throw new AssemblyErrorException(msg, status);
            }

            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = _prtOutSet.ExtraCondHeadOutDiv;
            //instance.ExtraCondHeadOutDiv = 0;

            // �w�b�_�󂯓n�����ҏW
            //StringCollection extraInfomations;
            //this.MakeExtarCondition(out extraInfomations);
            //instance.ExtraConditions = extraInfomations;
            //StringCollection extraInfomations = null;
            //instance.ExtraConditions = extraInfomations;

            

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = _prtOutSet.FooterPrintOutCode;
            //instance.PageFooterOutCode = 0;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(_prtOutSet.PrintFooter1);
            footers.Add(_prtOutSet.PrintFooter2);
            instance.PageFooters = footers;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            // �w�b�_�[�^�C�g��
            object[] titleObj = new object[] { _printInfo.prpnm };
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

            // ���̑��f�[�^
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion // �e��v���p�e�B�ݒ�

        #region ���o�����o�͏��쐬

        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            //// ���_�R�[�h
            //this.EditCondition(ref addConditions, String.Format("���_�R�[�h�F{0}", this._localPrintCondition.SectionCd));
            //// ���_��
            //this.EditCondition(ref addConditions, String.Format("���_���F{0}", this._localPrintCondition.SectionName));
            //// ���Ӑ�R�[�h
            //this.EditCondition(ref addConditions, String.Format("���Ӑ�R�[�h�F{0}", this._localPrintCondition.CustomerCd));
            //// ���Ӑ於
            //this.EditCondition(ref addConditions, String.Format("���Ӑ於�F{0}", this._localPrintCondition.CustomerName));
            //// �J�n��
            //this.EditCondition(ref addConditions, String.Format("�J�n���F{0}", this._localPrintCondition.StartDt.ToString("yyyy�NMM��dd��")));
            //// �I����
            //this.EditCondition(ref addConditions, String.Format("�I�����F{0}", this._localPrintCondition.EndDt.ToString("yyyy�NMM��dd��")));
            //// ���ߓ�
            //this.EditCondition(ref addConditions, String.Format("���ߓ��F{0}", this._localPrintCondition.TotalDt.ToString("dd")));

            //// �O�񐿋��c��
            //this.EditCondition(ref addConditions, String.Format("�O�񐿋��c���F{0}", this._localPrintCondition.LastTimeDemand.ToString()));
            //// �����z
            //this.EditCondition(ref addConditions, String.Format("�����z�F{0}", this._localPrintCondition.ThisTimeDmdNrml.ToString()));
            //// �J�z���z
            //this.EditCondition(ref addConditions, String.Format("�J�z���z�F{0}", this._localPrintCondition.ForwardedAmount.ToString()));
            //// ���񔄏�z
            //this.EditCondition(ref addConditions, String.Format("���񔄏�z�F{0}", this._localPrintCondition.ThisSalesPriceTotal.ToString()));
            //// �����
            //this.EditCondition(ref addConditions, String.Format("����ŁF{0}", this._localPrintCondition.OfsThisSalesTax.ToString()));
            //// �ō����z
            //this.EditCondition(ref addConditions, String.Format("�ō����z�F{0}", this._localPrintCondition.TotalAmount.ToString()));
            //// �����c��
            //this.EditCondition(ref addConditions, String.Format("�����c���F{0}", this._localPrintCondition.AfCalBlc.ToString()));
            //// �`�[����
            //this.EditCondition(ref addConditions, String.Format("�`�[�����F{0}", this._localPrintCondition.SlipCount.ToString()));

            //// �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }

        #region ���o����������ҏW

        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
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

        #endregion // ���o����������ҏW

        #region ���t�͈̔͏��������񐶐�

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

        #endregion // ���t�͈̔͏��������񐶐�

        #endregion // ���o�����o�͏��쐬

        #region ���b�Z�[�W�\��

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        private DialogResult MsgDispProc(emErrorLevel errorLevel, string msg, int status, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            return TMsgDisp.Show(errorLevel, "PMKAU04005P", msg, status, buttons, defaultButton);
        }

        #endregion // ���b�Z�[�W�\��

        #endregion // �v���C�x�[�g���\�b�h

        #region ��O�N���X

        /// <summary>
        /// ��O�N���X
        /// </summary>
        private class AssemblyErrorException : ApplicationException
        {
            #region �v���C�x�[�g�ϐ�

            private int _status;

            #endregion // �v���C�x�[�g�ϐ�

            #region �R���X�g���N�^

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public AssemblyErrorException(string message, int status)
                : base(message)
            {
                this._status = status;
            }

            #endregion

            #region �v���p�e�B

            /// <summary> 
            /// �X�e�[�^�X
            /// </summary>
            public int Status
            {
                get { return this._status; }
            }

            #endregion // �v���p�e�B
        }

        #endregion ��O�N���X

    }
}
