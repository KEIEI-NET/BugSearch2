//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.Collections.Specialized;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using System.Globalization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �d��������ѕ\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class PMKOU02063PA
    {

        #region �� Constructor
        /// <summary>
        /// �d��������ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063PA()
        {
        }

        /// <summary>
        /// �d��������ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._stockSalesResultInfoMainCndtn = this._printInfo.jyoken as StockSalesResultInfoMainCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Zero = "0";
        private const string ct_All = "00";
        private const string FILENAME_YYYYMMDD = "YYYYMMDD";
        private const string FILENAME_HHMMSSFF = "HHMMSSFF";
        private const string ct_Month = "���x";
        const string ct_RangeConst = "�F{0} �` {1}";
        const string ct_DateFormat = "YYYY/MM/DD";
        const string ct_Extr_Top = "�ŏ�����";
        const string ct_Extr_End = "�Ō�܂�";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					    // ������N���X
        private StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn;

        #endregion �� Private Member

        #region �� Exception Class
        /// <summary>
        /// ��O�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��O�N���X�̍쐬���s���B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private class SalesStockInfoMainException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            /// <remarks>
            /// <br>Note		: ��O�N���X�R���X�g���N�^�̍쐬���s���B</br>
            /// <br>Programmer	: ���痈</br>
            /// <br>Date		: 2009.05.13</br>
            /// </remarks>
            public SalesStockInfoMainException(string message, int status)
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
        /// <summary>  ������v���p�e�B</summary>
        /// <value>Printinfo</value>               
        /// <remarks> ������擾���̓Z�b�g�v���p�e�B </remarks> 
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion �� Public Property

        # region Interface Member



        # endregion

        #region �� Public Method
        #region �� ��������J�n
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
                status = 0;
                if (status != 0) return status;


                //���_�|�d����|�d����`�[�ԍ�(�����`�[�ԍ�)�|�敪(�d��������)�|�d�����t�|�d��SEQ�ԍ�(�d���`�[�ԍ�)�|�s�ԍ�(�d���s�ԍ�)�@��
                // �t�B���^����
                string filter = string.Empty;
                // �\�[�g��
                string sort = PMKOU02065EA.Col_SectionCode + " ASC,"
                           + PMKOU02065EA.Col_SupplierCdForSort + " ASC,"
                           + PMKOU02065EA.Col_PartySaleSlipNumForSort + " ASC,"
                           + PMKOU02065EA.Col_KuBec + " ASC,"
                           + PMKOU02065EA.Col_StockDateForSort + " ASC,"
                           + PMKOU02065EA.Col_SupplierSlipNo + " ASC,"
                           + PMKOU02065EA.Col_StockRowNo + " ASC";
                DataTable data = ((DataSet)this._printInfo.rdData).Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain];

                DataView dr = new DataView(data, filter, sort, DataViewRowState.CurrentRows);

                // �f�[�^�\�[�X�ݒ�
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;

                prtRpt.DataSource = dr;


                prtRpt.DataMember = PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain;

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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
                throw new SalesStockInfoMainException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new SalesStockInfoMainException(er.Message, -1);
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
            commonInfo.PrintMax = ds.Tables[0].Rows.Count;
            // SAVE PATH
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = string.Empty;
            // ��������擾
            StockSalesResultInfoMainCndtn extraInfo = (StockSalesResultInfoMainCndtn)this._printInfo.jyoken;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesStockResultInfoMainAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new SalesStockInfoMainException(message, status);
            }

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;



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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            string target = string.Empty;

            //�d����
            if (_stockSalesResultInfoMainCndtn.StStockDate != 0 || _stockSalesResultInfoMainCndtn.EdStockDate != 0)
            {

                string st_StockDate = string.Empty;
                string ed_StockDate = string.Empty;
                // �J�n
                if (this._stockSalesResultInfoMainCndtn.StStockDate != 0)
                    st_StockDate = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.StStockDate);
                else
                    st_StockDate = ct_Extr_Top;
                // �I��
                if (this._stockSalesResultInfoMainCndtn.EdStockDate != 0)
                    ed_StockDate = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.EdStockDate);
                else
                    ed_StockDate = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("�d����" + ct_RangeConst, st_StockDate, ed_StockDate));

            }

            //���͓�
            if ((this._stockSalesResultInfoMainCndtn.StInputDay != 0) || (this._stockSalesResultInfoMainCndtn.EdInputDay != 0))
            {
                string st_InputDay = string.Empty;
                string ed_InputDay = string.Empty;
                // �J�n
                if (this._stockSalesResultInfoMainCndtn.StInputDay != 0)
                    st_InputDay = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.StInputDay);
                else
                    st_InputDay = ct_Extr_Top;
                // �I��
                if (this._stockSalesResultInfoMainCndtn.EdInputDay != 0)
                    ed_InputDay = TDateTime.LongDateToString(ct_DateFormat, this._stockSalesResultInfoMainCndtn.EdInputDay);
                else
                    ed_InputDay = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("���͓�" + ct_RangeConst, st_InputDay, ed_InputDay));
            }


            //�d����
            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd == 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd != 0))
            {
                //target = "�d���� :" + ct_Extr_Top + " �` " + this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06");
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("�d����" + ct_RangeConst, ct_Extr_Top, this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06")));
            }

            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd > 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd == 0))
            {
                //target = "�d���� :" + this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06") + " �` " + ct_Extr_End;
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("�d����" + ct_RangeConst, this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06"), ct_Extr_End));
            }

            if ((this._stockSalesResultInfoMainCndtn.StSupplierCd > 0) && (this._stockSalesResultInfoMainCndtn.EdSupplierCd != 0))
            {
                //target = "�d���� :" + this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06") + " �` " + this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06");
                //this.EditCondition(ref extraConditions, target);
                this.EditCondition(ref extraConditions, string.Format("�d����" + ct_RangeConst, this._stockSalesResultInfoMainCndtn.StSupplierCd.ToString("d06"), this._stockSalesResultInfoMainCndtn.EdSupplierCd.ToString("d06")));
            }

            //�o�͎w��
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.WayToOrderTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("�o�͎w��F{0}", _stockSalesResultInfoMainCndtn.WayToOrderTypeName));

            }

            //�݌Ɏ��w��
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.StockOrderDivCdTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("�݌Ɏ��w��F{0}", _stockSalesResultInfoMainCndtn.StockOrderDivCdTypeName));

            }

            //����`�[�w��
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.SalesTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("����`�[�w��F{0}", _stockSalesResultInfoMainCndtn.SalesTypeName));

            }

            //�����w��
            if (!string.IsNullOrEmpty(_stockSalesResultInfoMainCndtn.StockUnitChngDivTypeName))
            {
                this.EditCondition(ref extraConditions,
                         string.Format("�����w��F{0}", _stockSalesResultInfoMainCndtn.StockUnitChngDivTypeName));

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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKOU02063P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion

    }
}
