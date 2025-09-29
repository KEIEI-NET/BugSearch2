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
    /// ���ɗ\��\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ɗ\��\�̈�����s���B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.12.03</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02064PA : IPrintProc
    {
        #region �� Constructor
		/// <summary>
		/// ���ɗ\��\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɗ\��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
		public PMUOE02064PA()
		{
		}

		/// <summary>
		/// ���ɗ\��\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���ɗ\��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        public PMUOE02064PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._enterSchOrderCndtn = this._printInfo.jyoken as EnterSchOrderCndtn;
		}
		#endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        private const string ct_DateFormat = "YYYY/MM/DD";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					    // ������N���X
        private EnterSchOrderCndtn _enterSchOrderCndtn;	// ���o�����N���X
        #endregion �� Private Member

        private string CT_Sort0_Odr = "SectionCode, WarehouseCode, WarehouseShelfNo";               // ���_+�q��+�I��
        private string CT_Sort1_Odr = "SectionCode, WarehouseCode, GoodsNo"; �@                     // ���_+�q��+�i��
        private string CT_Sort2_Odr = "SectionCode, WarehouseCode, SupplierCd, GoodsNo"; �@         // ���_+�q��+�d����+�i��
        private string CT_Sort3_Odr = "SectionCode, WarehouseCode, SupplierCd, SlipNo_Print";       // ���_+�q��+�d����+�d���`�[�ԍ�
        
        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class EnterSchOrderMainException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public EnterSchOrderMainException(string message, int status)
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
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
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = EnterSchResult.Col_Tbl_Result_EnterSch;

                // ����f�[�^�擾
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[EnterSchResult.Col_Tbl_Result_EnterSch];

                // �\�[�g���ݒ�
                dv.Sort = this.GetPrintOderQuerry();

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = dv;
                
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
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
                throw new EnterSchOrderMainException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new EnterSchOrderMainException(er.Message, -1);
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
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
            //commonInfo.PrintMax = 0;
            int maxCount = 0;
            foreach (object obj in (this._printInfo.rdData as DataSet).Tables)
            {
                if (obj is DataTable && (obj as DataTable).TableName == EnterSchResult.Col_Tbl_Result_EnterSch)
                {
                    maxCount = (obj as DataTable).Rows.Count;
                    break;
                }
            }
            commonInfo.PrintMax = maxCount;

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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            EnterSchOrderCndtn extraInfo = (EnterSchOrderCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = EnterSchOrderAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new EnterSchOrderMainException(message, status);
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
            instance.PageHeaderSubtitle = this._enterSchOrderCndtn.PrintDivName;

            // ���̑��f�[�^
            ArrayList otherDataList = new ArrayList();
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region �� �\�[�g�����̎擾
        /// <summary>
        /// �\�[�g�����̎擾
        /// </summary>
        /// <param name="rsltInfo_CollectPlan">���o����</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g�����̂��擾����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private string GetSortOrderName(EnterSchOrderCndtn enterSchOrderCndtn)
        {
            string sortOrderName = string.Empty;

            if (enterSchOrderCndtn.SortOrderDiv == 0)
            {
                sortOrderName = "[�q�ɁE�I�ԏ�]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 1)
            {
                sortOrderName = "[�q�ɁE�i�ԏ�]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 2)
            {
                sortOrderName = "[�q�ɁE�d����E�i�ԏ�]";
            }
            else if (enterSchOrderCndtn.SortOrderDiv == 3)
            {
                sortOrderName = "[�q�ɁE�d����E�d���`�[�ԍ���]";
            }
            
            return sortOrderName;
        }
        #endregion

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            StringCollection addConditions = new StringCollection();

            // ������
            if ((this._enterSchOrderCndtn.St_ReceiveDate != DateTime.MinValue) || (this._enterSchOrderCndtn.Ed_ReceiveDate != DateTime.MinValue))
            {
                string st_ReceiveDate = string.Empty;
                string ed_ReceiveDate = string.Empty;
                // �J�n
                if (this._enterSchOrderCndtn.St_ReceiveDate != DateTime.MinValue)
                    st_ReceiveDate = TDateTime.DateTimeToString(ct_DateFormat, this._enterSchOrderCndtn.St_ReceiveDate);
                else
                    st_ReceiveDate = ct_Extr_Top;
                // �I��
                if (this._enterSchOrderCndtn.Ed_ReceiveDate != DateTime.MinValue)
                    ed_ReceiveDate = TDateTime.DateTimeToString(ct_DateFormat, this._enterSchOrderCndtn.Ed_ReceiveDate);
                else
                    ed_ReceiveDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("������" + ct_RangeConst, st_ReceiveDate, ed_ReceiveDate));
            }            

            // ����^�C�v
            if (this._enterSchOrderCndtn.PrintTypeCndtn == 0)
            {
                this.EditCondition(ref addConditions, "����^�C�v�F���ɕ��݈̂������");
            }
            else if (this._enterSchOrderCndtn.PrintTypeCndtn == 1)
            {
                this.EditCondition(ref addConditions, "����^�C�v�FҰ��̫۰���݈̂������");
            }
            else
            {
                this.EditCondition(ref addConditions, "����^�C�v�F���i���݈̂������");
            }

            // ������
            if (this._enterSchOrderCndtn.SupplierExtra == 0)
            {
                // �͈�
                if (this._enterSchOrderCndtn.St_UOESupplierCd != 0 || this._enterSchOrderCndtn.Ed_UOESupplierCd != 0)
                {
                    string startCode = "";
                    if (this._enterSchOrderCndtn.St_UOESupplierCd == 0)
                    {
                        startCode = ct_Extr_Top;
                    }
                    else
                    {
                        startCode = this._enterSchOrderCndtn.St_UOESupplierCd.ToString("d06");
                    }

                    string endCode = "";
                    if (this._enterSchOrderCndtn.Ed_UOESupplierCd == 0)
                    {
                        endCode = ct_Extr_End;
                    }
                    else
                    {
                        endCode = this._enterSchOrderCndtn.Ed_UOESupplierCd.ToString("d06");
                    }
                    this.EditCondition(ref addConditions, string.Format("������" + ct_RangeConst, startCode, endCode));
                }
            }
            else
            {
                string unitCode = "";
                // �P��
                foreach (int uoeSupplierCd in this._enterSchOrderCndtn.UOESupplierCds)
                {
                    if (unitCode == "")
                    {
                        unitCode = uoeSupplierCd.ToString("d06");
                    }
                    else
                    {
                        unitCode += " " + uoeSupplierCd.ToString("d06");
                    }
                }
                this.EditCondition(ref addConditions, string.Format("������F{0}", unitCode));
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }

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
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            // 2008.11.20 30413 ���� ���o������K�X���s����悤�ɏC�� >>>>>>START
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;

            //    // �i�[�G���A�̃o�C�g���Z�o
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 190)
            //    {
            //        isEdit = true;

            //        // �S�p�X�y�[�X��}��
            //        if (editArea[i] != null) editArea[i] += ct_Space;

            //        editArea[i]  += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;

            // �ǉ�����G���A�̃C���f�b�N�X���擾
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // ���s
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[index] != null) editArea[index] += ct_Space;

                    editArea[index] += target;
                }
            }
            // 2008.11.20 30413 ���� ���o������K�X���s����悤�ɏC�� <<<<<<END

            // �V�K�ҏW�G���A�쐬
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion
        #endregion �� ���|�[�g�t�H�[���ݒ�֘A

        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._enterSchOrderCndtn.SortOrderDiv)
            {
                case 0:     // �q�ɁE�I��
                    {
                        oderQuerry = CT_Sort0_Odr;
                        break;
                    }
                case 1:     // �q�ɁE�i��
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 2:     // �q�ɁE�d����E�i��
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 3:     // �q�ɁE�d����E�d���`�[�ԍ�
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
            }

            return oderQuerry;
        }
        #endregion

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
        /// <br>Date	   : 2008.12.03</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMUOE02064P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
