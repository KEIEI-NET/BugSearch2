//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈������N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �����_�ݒ菈������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ菈���̈�����s���B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date	   : 2009.04.13</br>
    /// <br></br>
    /// </remarks>
    public class PMHAT09104PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// �����_�ݒ菈������N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ菈������N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        public PMHAT09104PA()
        {
        }

        /// <summary>
        /// �����_�ݒ菈������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �����_�ݒ菈������N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        public PMHAT09104PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._paramWork = this._printInfo.jyoken as ExtrInfo_OrderPointStSimulationWorkTbl;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_PGID_1 = "PMHAT09104P_01A4C";   // �i�ԏ�
        private const string ct_PGID_2 = "PMHAT09104P_02A4C";   // �I�ԏ�
        private const string ct_PGID_3 = "PMHAT09104P_03A4C";   // ���[�J�[�E�i�ԏ�
        private const string ct_PGID_4 = "PMHAT09104P_04A4C";   // ���[�J�[�E�I�ԏ�
        private const string ct_Space = "�@";
        private const string ct_RangeConst = "{0} �` {1}";
        private const string ct_DateFormat = "YYYY�NMM��DD��";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					        // ������N���X
        private ExtrInfo_OrderPointStSimulationWorkTbl _paramWork;	            // ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class OrderPointStSimulationException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public OrderPointStSimulationException(string message, int status)
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
            try
            {
                // ���[�̃v���O����ID�̐ݒ�
                this.SetReportID(ref this._printInfo.prpid);

                // ���|�[�g�C���X�^���X�쐬
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // ����f�[�^�擾
                DataSet printDataSet = (DataSet)this._printInfo.rdData;

                // �t�B���^����
                StringBuilder filter = new StringBuilder();

                DataTable data = printDataSet.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation];
                // �\�[�g��
                StringBuilder sort = new StringBuilder();
                sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode);
                sort.Append(" ASC,");

                // ��������擾
                ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

                switch (extraInfo.OutPutDiv)
                {
                    case 0:
                        // �i�ԏ�
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMGroup).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGroupCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGoodsCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 1:
                        // �I�ԏ�
                        sort.Append(OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMGroup).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGroupCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_BLGoodsCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 2:
                        // ���[�J�[�E�i�ԏ�
                        sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsNo).Append(" ASC");
                        break;
                    case 3:
                        // ���[�J�[�E�I�ԏ�
                        sort.Append(OrderPointStSimulationTbl.Col_WarehouseCode).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_GoodsMakerCd).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo).Append(" ASC,");
                        sort.Append(OrderPointStSimulationTbl.Col_SupplierCd).Append(" ASC");
                        break;
                }
                DataView dv = new DataView(data, filter.ToString(), sort.ToString(), DataViewRowState.CurrentRows);

                OrderPointStSimulationAcs acs = new OrderPointStSimulationAcs();
                DataTable filterData = dv.ToTable();
                string lastWarehouseCode = string.Empty;
                string lastSupplierCd = string.Empty;
                string lastGoodsMakerCd = string.Empty;
                string lastWarehouseShelfNo = string.Empty;
                for (int i = 0; i < filterData.Rows.Count; i++)
                {
                    DataRow dr = filterData.Rows[i];
                    if (i == 0)
                    {
                        lastWarehouseCode = dr[OrderPointStSimulationTbl.Col_WarehouseCode].ToString().TrimEnd();
                        lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                        lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                    }
                    else
                    {
                        DataRow lastDr = filterData.Rows[i - 1];
                        bool isSame = false;
                        acs.DataFilter(extraInfo.OutPutDiv, extraInfo.FractionProcCd, ref dr, ref lastDr, out isSame, ref lastWarehouseCode, ref lastSupplierCd, ref lastWarehouseShelfNo, ref lastGoodsMakerCd);
                        if (isSame)
                        {
                            filterData.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
                dv = new DataView(filterData, filter.ToString(), sort.ToString(), DataViewRowState.CurrentRows);

                // �f�[�^�Z�b�g�̕ϊ�
                DataTable dtTemp = dv.Table.Clone();
                dtTemp.TableName = OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation;
                foreach (DataRowView drv in dv)
                {
                    dtTemp.ImportRow(drv.Row);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dtTemp);
                this._printInfo.rdData = ds;
                
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
        #region �� ���[ID�̐ݒ�
        /// <summary>
        /// ���[ID�̐ݒ�
        /// </summary>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �o�͏��ɂ��A���[ID�̐ݒ���s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private void SetReportID(ref string pgId)
        {
            pgId = string.Empty;

            // ��������擾
            ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

            switch (extraInfo.OutPutDiv)
            {
                case 0: // �i�ԏ�
                    pgId = ct_PGID_1;
                    break;
                case 1: // �I�ԏ�
                    pgId = ct_PGID_2;
                    break;
                case 2: // ���[�J�[�E�i�ԏ�
                    pgId = ct_PGID_3;
                    break;
                case 3: // ���[�J�[�E�I�ԏ�
                    pgId = ct_PGID_4;
                    break;
            }
        }
        #endregion

        #region �� �e��ActiveReport���[�C���X�^���X�쐬
        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
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
                throw new OrderPointStSimulationException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new OrderPointStSimulationException(er.Message, -1);
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            ExtrInfo_OrderPointStSimulationWorkTbl extraInfo = (ExtrInfo_OrderPointStSimulationWorkTbl)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = OrderPointStSimulationAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new OrderPointStSimulationException(message, status);
            }

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations, extraInfo);
            instance.ExtraConditions = extraInfomations;

            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            // ���̑��f�[�^
            ArrayList otherDataList = new ArrayList();
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        #endregion

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <param name="rateUnMatchCndtn">���o����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions, ExtrInfo_OrderPointStSimulationWorkTbl rateUnMatchCndtn)
        {
            extraConditions = new StringCollection();

            string target = string.Empty;

            // �ݒ�R�[�h
            this.EditCondition(ref extraConditions, string.Format("�ݒ�R�[�h�F{0}", rateUnMatchCndtn.SettingCode.ToString("d03")));

            // �q�ɃR�[�h
            if (!string.IsNullOrEmpty(rateUnMatchCndtn.St_WarehouseCode) || !string.IsNullOrEmpty(rateUnMatchCndtn.Ed_WarehouseCode))
            {
                string st_WarehouseCode = string.Empty;
                string ed_WarehouseCode = string.Empty;
                // �J�n
                if (!string.IsNullOrEmpty(rateUnMatchCndtn.St_WarehouseCode))
                    st_WarehouseCode = rateUnMatchCndtn.St_WarehouseCode.PadLeft(4, '0');
                else
                    st_WarehouseCode = ct_Extr_Top;
                // �I��
                if (!string.IsNullOrEmpty(rateUnMatchCndtn.Ed_WarehouseCode))
                    ed_WarehouseCode = rateUnMatchCndtn.Ed_WarehouseCode.PadLeft(4, '0');
                else
                    ed_WarehouseCode = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("�q�ɁF" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
            }

            //�d����
            if ((rateUnMatchCndtn.St_SupplierCd == 0) && (rateUnMatchCndtn.Ed_SupplierCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�d����F" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_SupplierCd.ToString("d06")));
            }

            if ((rateUnMatchCndtn.St_SupplierCd > 0) && (rateUnMatchCndtn.Ed_SupplierCd == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�d����F" + ct_RangeConst, rateUnMatchCndtn.St_SupplierCd.ToString("d06"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_SupplierCd > 0) && (rateUnMatchCndtn.Ed_SupplierCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�d����F" + ct_RangeConst, rateUnMatchCndtn.St_SupplierCd.ToString("d06"), rateUnMatchCndtn.Ed_SupplierCd.ToString("d06")));
            }

            //���[�J�[
            if ((rateUnMatchCndtn.St_GoodsMakerCd == 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("Ұ���F" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_GoodsMakerCd.ToString("d04")));
            }

            if ((rateUnMatchCndtn.St_GoodsMakerCd > 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("Ұ���F" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMakerCd.ToString("d04"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_GoodsMakerCd > 0) && (rateUnMatchCndtn.Ed_GoodsMakerCd != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("Ұ���F" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMakerCd.ToString("d04"), rateUnMatchCndtn.Ed_GoodsMakerCd.ToString("d04")));
            }

            // ������
            if ((rateUnMatchCndtn.St_GoodsMGroup == 0) && (rateUnMatchCndtn.Ed_GoodsMGroup != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�����ށF" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_GoodsMGroup.ToString("d04")));
            }

            if ((rateUnMatchCndtn.St_GoodsMGroup > 0) && (rateUnMatchCndtn.Ed_GoodsMGroup == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�����ށF" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMGroup.ToString("d04"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_GoodsMGroup > 0) && (rateUnMatchCndtn.Ed_GoodsMGroup != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("�����ށF" + ct_RangeConst, rateUnMatchCndtn.St_GoodsMGroup.ToString("d04"), rateUnMatchCndtn.Ed_GoodsMGroup.ToString("d04")));
            }

            // �O���[�v
            if ((rateUnMatchCndtn.St_BLGroupCode == 0) && (rateUnMatchCndtn.Ed_BLGroupCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("��ٰ�߁F" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_BLGroupCode.ToString("d05")));
            }

            if ((rateUnMatchCndtn.St_BLGroupCode > 0) && (rateUnMatchCndtn.Ed_BLGroupCode == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("��ٰ�߁F" + ct_RangeConst, rateUnMatchCndtn.St_BLGroupCode.ToString("d05"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_BLGroupCode > 0) && (rateUnMatchCndtn.Ed_BLGroupCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("��ٰ�߁F" + ct_RangeConst, rateUnMatchCndtn.St_BLGroupCode.ToString("d05"), rateUnMatchCndtn.Ed_BLGroupCode.ToString("d05")));
            }

            // BL�R�[�h
            if ((rateUnMatchCndtn.St_BLGoodsCode == 0) && (rateUnMatchCndtn.Ed_BLGoodsCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BL���ށF" + ct_RangeConst, ct_Extr_Top, rateUnMatchCndtn.Ed_BLGoodsCode.ToString("d05")));
            }

            if ((rateUnMatchCndtn.St_BLGoodsCode > 0) && (rateUnMatchCndtn.Ed_BLGoodsCode == 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BL���ށF" + ct_RangeConst, rateUnMatchCndtn.St_BLGoodsCode.ToString("d05"), ct_Extr_End));
            }

            if ((rateUnMatchCndtn.St_BLGoodsCode > 0) && (rateUnMatchCndtn.Ed_BLGoodsCode != 0))
            {
                this.EditCondition(ref extraConditions, string.Format("BL���ށF" + ct_RangeConst, rateUnMatchCndtn.St_BLGoodsCode.ToString("d05"), rateUnMatchCndtn.Ed_BLGoodsCode.ToString("d05")));
            }

            // �Ǘ��敪�P
            if (rateUnMatchCndtn.ManagementDivide1.Length > 0)
            {
                this.EditCondition(ref extraConditions, string.Format("�Ǘ��敪�P�F{0}", GetManagerDiv(rateUnMatchCndtn.ManagementDivide1)));
            }

            // �Ǘ��敪�Q
            if (rateUnMatchCndtn.ManagementDivide2.Length > 0)
            {
                this.EditCondition(ref extraConditions, string.Format("�Ǘ��敪�Q�F{0}", GetManagerDiv(rateUnMatchCndtn.ManagementDivide2)));
            }

            // �W�v���@
            this.EditCondition(ref extraConditions, string.Format("�W�v���@�F{0}", rateUnMatchCndtn.SumMethodNm));

            // �o�בΏۊ���
            if (rateUnMatchCndtn.StckShipMonthSt != 0 || rateUnMatchCndtn.StckShipMonthEd != 0)
            {
                string st_StckShipMonth = string.Empty;
                string ed_StckShipMonth = string.Empty;
                // �J�n
                if (rateUnMatchCndtn.StckShipMonthSt != 0)
                    st_StckShipMonth = TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StckShipMonthSt);
                else
                    st_StckShipMonth = ct_Extr_Top;
                // �I��
                if (rateUnMatchCndtn.StckShipMonthEd != 0)
                    ed_StckShipMonth = TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StckShipMonthEd);
                else
                    ed_StckShipMonth = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("�o�בΏۊ��ԁF" + ct_RangeConst, st_StckShipMonth, ed_StckShipMonth));
            }

            // �݌ɓo�^���t
            this.EditCondition(ref extraConditions, string.Format("�݌ɓo�^���t�F{0}{1}", TDateTime.LongDateToString(ct_DateFormat, rateUnMatchCndtn.StockCreateDate), "�ȑO"));
        }
        #endregion

        #region �Ǘ��敪�̏o�͐ݒ�
        /// <summary>
        /// �Ǘ��敪�̏o�͐ݒ�
        /// </summary>
        /// <param name="value">�ݒ�l</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <br>Note       : �Ǘ��敪�o�͐ݒ���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private string GetManagerDiv(string[] value)
        {
            string ret;
            if (value == null || value.Length == 0)
            {
                ret = string.Empty;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string str in value)
                {
                    sb.Append(str);
                }
                ret = sb.ToString();
            }

            return ret;
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
        /// <br>Programmer : ���w�q</br>
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

        #region �� �\�[�g�����̎擾
        /// <summary>
        /// �\�[�g�����̎擾
        /// </summary>
        /// <param name="rateUnMatchCndtn">���o����</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g�����̂��擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private string GetSortOrderName(ExtrInfo_OrderPointStSimulationWorkTbl rateUnMatchCndtn)
        {
            string strOrder = string.Empty;
            switch (rateUnMatchCndtn.OutPutDiv)
            {
                case 0:
                    strOrder = "�i�ԏ�";
                    break;
                case 1:
                    strOrder = "�I�ԏ�";
                    break;
                case 2:
                    strOrder = "���[�J�[�E�i�ԏ�";
                    break;
                case 3:
                    strOrder = "���[�J�[�E�I�ԏ�";
                    break;
            }
            return strOrder;
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            return string.Empty;
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date	   : 2009.04.13</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHAT09104P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
