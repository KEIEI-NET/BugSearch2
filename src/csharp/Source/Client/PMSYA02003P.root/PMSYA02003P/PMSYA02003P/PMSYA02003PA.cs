//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// ���q�ʏo�׎��ѕ\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�ʏo�׎��ѕ\�̈�����s���B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.09.15</br>
    /// </remarks>
    class PMSYA02003PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// ���q�ʏo�׎��ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public PMSYA02003PA()
        {
        }

        /// <summary>
        /// ���q�ʏo�׎��ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���q�ʏo�׎��ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public PMSYA02003PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._carShipRsltListCndtn = this._printInfo.jyoken as CarShipRsltListCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        const string ct_Extr_Top = "�ŏ�����";
        const string ct_Extr_End = "�Ō�܂�";
        const string ct_Space = "�@";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;				// ������N���X
        private CarShipRsltListCndtn _carShipRsltListCndtn;		// ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class CarShipRsltException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public CarShipRsltException(string message, int status)
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� Private Method
        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                if ((int)_carShipRsltListCndtn.GroupBySectionDiv == 0)
                {
                    this._printInfo.prpid = "PMSYA02003P_01A4C";
                }
                else
                {
                    this._printInfo.prpid = "PMSYA02003P_02A4C";
                }
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
                DataTable data = ((DataSet)this._printInfo.rdData).Tables[PMSYA02005EA.Tbl_CarShipListData];

                DataView dr = new DataView(data, filter, sort, DataViewRowState.CurrentRows);
                prtRpt.DataSource = dr;
                //prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = PMSYA02005EA.Tbl_CarShipListData;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); 

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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
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
                throw new CarShipRsltException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new CarShipRsltException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region �� �����ʋ��ʏ��ݒ�

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <param name="rptObj"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17 
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
            if ((int)_carShipRsltListCndtn.GroupBySectionDiv == 0)
            {
                this._printInfo.prpnm = "���q�ʏo�׎��ѕ\";
            }
            else
            {
                this._printInfo.prpnm = "���q�ʏo�ו��i���X�g";
            }
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

            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;

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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            CarShipRsltListCndtn extraInfo = (CarShipRsltListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = ""; 
            
            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = CarShipRsltAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new CarShipRsltException(message, status);
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
            instance.PageHeaderSubtitle = string.Format("{0}", this._printInfo.prpnm);

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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            // �����
            if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.SalesDateSt))
            {
                if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         this._carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                         this._carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                        this._carShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         ct_Extr_Top,
                         this._carShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // ���͓�
            if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.InputDateSt))
            {
                if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         this._carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                         this._carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                        this._carShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(this._carShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         ct_Extr_Top,
                         this._carShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // �݌Ɏ��w��
            this.EditCondition(ref addConditions, string.Format("�݌Ɏ��w��F{0}",
                         this._carShipRsltListCndtn.RsltTtlDivName));

            // ���Ӑ�
            if (this._carShipRsltListCndtn.CustomerCodeSt != 0)
            {
                if (this._carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                         this._carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), this._carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                        this._carShipRsltListCndtn.CustomerCodeSt.ToString("00000000"), ct_Extr_End));
                }
            }
            else
            {
                if (this._carShipRsltListCndtn.CustomerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���Ӑ�F{0} �` {1}",
                         ct_Extr_Top, this._carShipRsltListCndtn.CustomerCodeEd.ToString("00000000")));
                }
            }

            // �Ǘ��ԍ�
            if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.CarMngCodeSt))
            {
                if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                         this._carShipRsltListCndtn.CarMngCodeSt, this._carShipRsltListCndtn.CarMngCodeEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                        this._carShipRsltListCndtn.CarMngCodeSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.CarMngCodeEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�Ǘ��ԍ��F{0} �` {1}",
                         ct_Extr_Top, this._carShipRsltListCndtn.CarMngCodeEd));
                }
            }

            // ��ٰ�ߺ���
            if (this._carShipRsltListCndtn.BLGroupCodeSt != 0)
            {
                if (this._carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                         this._carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), this._carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                        this._carShipRsltListCndtn.BLGroupCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (this._carShipRsltListCndtn.BLGroupCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h�F{0} �` {1}",
                         ct_Extr_Top, this._carShipRsltListCndtn.BLGroupCodeEd.ToString("00000")));
                }
            }

            // BL����
            if (this._carShipRsltListCndtn.BLGoodsCodeSt != 0)
            {
                if (this._carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         this._carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), this._carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                        this._carShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (this._carShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         ct_Extr_Top, this._carShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
            }

            // �i��
            if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.GoodsNoSt))
            {
                if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                         this._carShipRsltListCndtn.GoodsNoSt, this._carShipRsltListCndtn.GoodsNoEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                        this._carShipRsltListCndtn.GoodsNoSt, ct_Extr_End));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.GoodsNoEd))
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԁF{0} �` {1}",
                         ct_Extr_Top, this._carShipRsltListCndtn.GoodsNoEd));
                }
            }

            // ���q���l
            if (!string.IsNullOrEmpty(this._carShipRsltListCndtn.SlipNoteCar))
            {
                // ���q���l,���q���l�����敪
                this.EditCondition(ref addConditions, string.Format("���q���l�F{0} {1}",
                         this._carShipRsltListCndtn.SlipNoteCar, this._carShipRsltListCndtn.CarOutDivName));

            }
            
            // �ǉ�
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMSYA02003P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
