using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �݌ɊŔ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊŔ���̈�����s���B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br>Update Note: 2009.01.08 30452 ��� �r��</br>
    /// <br>            ��Q�Ή�9615</br>
    /// </remarks>
    public class PMZAI02053PA : IPrintProc
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMZAI02053PA()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="printInfo"></param>
        public PMZAI02053PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._stockSignOrderCndtn = this._printInfo.jyoken as StockSignOrderCndtn;
        }
        #endregion

        #region �� Private�萔
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        #endregion

        #region �� Private�ϐ�
        private SFCMN06002C _printInfo;					// ������N���X
        private StockSignOrderCndtn _stockSignOrderCndtn;		// ���o�����N���X
        #endregion

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
        #endregion

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
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� private���\�b�h
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null; // ���[�U�[�܂��̓h�b�g��1�y�[�W�ڗp
            DataDynamics.ActiveReports.ActiveReport3 prtRptSub = null; // �h�b�g��2�y�[�W�ڈȍ~�p

            try
            {
                #region 1�y�[�W�ڗp ���[�C���X�^���X�쐬
                // ���|�[�g�C���X�^���X�쐬
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                if (this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                    || this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
                {
                    // �h�b�g
                    DataTable firstPageDataTable = ((DataView)this._printInfo.rdData).Table.Clone();

                    for (int i = 0; i < ((DataView)this._printInfo.rdData).Table.Rows.Count && i < 8; i++)
                    {
                        // ��s���܂߁A8�s�ڂ܂ł�1�Ŗڂ̒��[�ɐݒ�
                        DataRow dr = ((DataView)this._printInfo.rdData).Table.Rows[i];

                        firstPageDataTable.ImportRow(dr);
                    }

                    // �f�[�^�\�[�X�ݒ�
                    prtRpt.DataSource = new DataView(firstPageDataTable, "", "", DataViewRowState.CurrentRows);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
                    //---------------------------------------------
                    // �p�������␳
                    //---------------------------------------------
                    try
                    {
                        // 1�œ��Ɏ��߂�=true
                        (prtRpt.Sections["detail"] as DataDynamics.ActiveReports.Detail).KeepTogether = true;

                        // �w�b�_�]�������i�}�X�^�ݒ�l��cm�ɕϊ����Ă���AInch�P�ʂɂ���j
                        float adjustY = DataDynamics.ActiveReports.ActiveReport3.CmToInch( ((float)_printInfo.py / 100f) );
                        prtRpt.Sections["reportHeader1"].Height = CalculateFruction( prtRpt.Sections["reportHeader1"].Height + adjustY );

                        // �������Čv�Z����i�w�b�_�~�P�{���ׁ~�W�j
                        float totalHeight = prtRpt.Sections["reportHeader1"].Height + prtRpt.Sections["detail"].Height * 8.0f;
                        prtRpt.PageSettings.PaperHeight = CalculateFruction( totalHeight );

                        // ��L�����̑���ɁA�ʏ�̗]������𖳂���
                        _printInfo.py = 0;
                    }
                    catch
                    {
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD
                }
                else
                {
                    // ���[�U�[
                    prtRpt.DataSource = this._printInfo.rdData;
                }
                prtRpt.DataMember = PMZAI02059EA.ct_Tbl_StockSignResult;
                #endregion

                #region 2�y�[�W�ڈȍ~�p ���[�C���X�^���X�쐬
                if (this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_FiveByNine
                    || this._stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine)
                {
                    if (((DataView)this._printInfo.rdData).Table.Rows.Count > 8)
                    {
                        // ���|�[�g�C���X�^���X�쐬
                        this.CreateSubReport(out prtRptSub, this._printInfo.prpid);
                        if (prtRptSub == null) return status;

                        // �e��v���p�e�B�ݒ�
                        status = this.SettingProperty(ref prtRptSub);
                        if (status != 0) return status;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
                        try
                        {
                            // 1�œ��Ɏ��߂�=true
                            (prtRptSub.Sections["detail"] as DataDynamics.ActiveReports.Detail).KeepTogether = true;

                            // �������Čv�Z����i���ׁ~�X�j
                            float totalHeight = prtRptSub.Sections["detail"].Height * 9.0f;
                            prtRptSub.PageSettings.PaperHeight = CalculateFruction( totalHeight );
                        }
                        catch
                        {
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD

                        DataTable secondPageDataTable = ((DataView)this._printInfo.rdData).Table.Clone();

                        for (int i = 8; i < ((DataView)this._printInfo.rdData).Table.Rows.Count; i++)
                        {
                            // 9�s�ڈȍ~�𒠕[�ɐݒ�
                            DataRow dr = ((DataView)this._printInfo.rdData).Table.Rows[i];

                            secondPageDataTable.ImportRow(dr);
                        }

                        // �f�[�^�\�[�X�ݒ�
                        prtRptSub.DataSource = new DataView(secondPageDataTable, "", "", DataViewRowState.CurrentRows);
                        prtRptSub.DataMember = PMZAI02059EA.ct_Tbl_StockSignResult;
                    }
                }
                #endregion

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

                            // --- ADD 2009/01/08 -------------------------------->>>>>
                            if (prtRptSub != null)
                            {
                                // �v���O���X�o�[UP�C�x���g�ǉ�
                                if (prtRpt is IPrintActiveReportTypeCommon)
                                {
                                    ((IPrintActiveReportTypeCommon)prtRptSub).ProgressBarUpEvent +=
                                        new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                                }
                            }
                            // --- ADD 2009/01/08 --------------------------------<<<<<

                            ArrayList prtList = new ArrayList();

                            prtList.Add(prtRpt);
                            if (prtRptSub != null)
                            {
                                prtList.Add(prtRptSub);
                            }

                            // ������s
                            status = processForm.Run(prtList, true);

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		// �v���r���L
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // ���ʏ����ݒ�
                            viewForm.CommonInfo = commonInfo;

                            ArrayList prtList = new ArrayList();

                            prtList.Add(prtRpt);
                            if (prtRptSub != null)
                            {
                                prtList.Add(prtRptSub);
                            }

                            // �v���r���[���s
                            status = viewForm.Run(prtList);

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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/27 ADD
        /// <summary>
        /// ���|�[�g�p���T�C�Y�[������
        /// </summary>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        private float CalculateFruction( float targetValue )
        {
            // �����Q���܂ŗL���A�؂�グ
            // (10.22625 �� 10.23)

            decimal val = (decimal)targetValue;

            val = Math.Ceiling( val * 100m ) / 100m;
            return (float)val;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/27 ADD

        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>           : �P�y�[�W�ڗp�̒��[�C���X�^���X���쐬���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>           : �Q�y�[�W�ڈȍ~�p�̒��[�C���X�^���X���쐬���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private void CreateSubReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim() + "_Sub",
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// ���|�[�g�A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
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

        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            StockSignOrderCndtn extraInfo = (StockSignOrderCndtn)this._printInfo.jyoken;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = StockSignPrintAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new StockMoveException(message, status);
            }

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
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
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMZAI02053P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
