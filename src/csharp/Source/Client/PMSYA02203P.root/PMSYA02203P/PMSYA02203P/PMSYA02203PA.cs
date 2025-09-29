//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�בΉ��\
// �v���O�����T�v   : �^���ʏo�בΉ��\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//Update Note : 2010/05/13 ���C�� redmine #7109
//              �d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// �^���ʏo�בΉ��\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ʏo�בΉ��\�̈�����s���B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    class PMSYA02203PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// �^���ʏo�בΉ��\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^���ʏo�בΉ��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public PMSYA02203PA()
        {
        }

        /// <summary>
        /// �^���ʏo�בΉ��\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �^���ʏo�בΉ��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public PMSYA02203PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._modelShipRsltListCndtn = this._printInfo.jyoken as ModelShipRsltListCndtn;
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
        private ModelShipRsltListCndtn _modelShipRsltListCndtn;		// ���o�����N���X
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                this._printInfo.prpid = "PMSYA02203P_01A4C";
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
                DataTable data = ((DataSet)this._printInfo.rdData).Tables[PMSYA02205EA.Tbl_ModelShipListData];

                DataView dr = new DataView(data, filter, sort, DataViewRowState.CurrentRows);
                prtRpt.DataSource = dr;
                prtRpt.DataMember = PMSYA02205EA.Tbl_ModelShipListData;

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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) 
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
            this._printInfo.prpnm = "�^���ʏo�בΉ��\";
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            ModelShipRsltListCndtn extraInfo = (ModelShipRsltListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = ""; 
            
            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = ModelShipRsltAcs.ReadPrtOutSet(out prtOutSet, out message);
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// <br>Update Note: 2010/05/13 ���C�� ��\�^���̕ύX</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            // �����
            if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.SalesDateSt))
            {
                if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         this._modelShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                         this._modelShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                        this._modelShipRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.SalesDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("������F{0} �` {1}",
                         ct_Extr_Top,
                         this._modelShipRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // ���͓�
            if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.InputDateSt))
            {
                if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         this._modelShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                         this._modelShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                        this._modelShipRsltListCndtn.InputDateSt.ToString("yyyy/MM/dd"),
                        ct_Extr_End));
                }
            }
            else
            {
                if (!DateTime.MinValue.Equals(this._modelShipRsltListCndtn.InputDateEd))
                {
                    this.EditCondition(ref addConditions, string.Format("���͓��F{0} �` {1}",
                         ct_Extr_Top,
                         this._modelShipRsltListCndtn.InputDateEd.ToString("yyyy/MM/dd")));
                }
            }

            // �݌Ɏ��w��
            this.EditCondition(ref addConditions, string.Format("�݌Ɏ��w��F{0}",
                         this._modelShipRsltListCndtn.RsltTtlDivName));

            //�Ԏ�
            string carModelSt = _modelShipRsltListCndtn.CarMakerCodeSt.ToString("000");
            carModelSt += "-" + _modelShipRsltListCndtn.CarModelCodeSt.ToString("000");
            carModelSt += "-" + _modelShipRsltListCndtn.CarModelSubCodeSt.ToString("000");

            if (_modelShipRsltListCndtn.CarMakerCodeEd == 0)
            {
                _modelShipRsltListCndtn.CarMakerCodeEd = 999;
            }
            if (_modelShipRsltListCndtn.CarModelCodeEd == 0)
            {
                _modelShipRsltListCndtn.CarModelCodeEd = 999;
            }
            if (_modelShipRsltListCndtn.CarModelSubCodeEd == 0)
            {
                _modelShipRsltListCndtn.CarModelSubCodeEd = 999;
            }

            string carModelEd = _modelShipRsltListCndtn.CarMakerCodeEd.ToString("000");
            carModelEd += "-" + _modelShipRsltListCndtn.CarModelCodeEd.ToString("000");
            carModelEd += "-" + _modelShipRsltListCndtn.CarModelSubCodeEd.ToString("000");
            if (carModelSt != "000-000-000")
            {
                if (carModelEd != "999-999-999")
                {
                    this.EditCondition(ref addConditions, string.Format("�Ԏ�F{0} �` {1}",
                         carModelSt, carModelEd));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("�Ԏ�F{0} �` {1}",
                        carModelSt, ct_Extr_End));
                }
            }
            else
            {
                if (carModelEd != "999-999-999")
                {
                    this.EditCondition(ref addConditions, string.Format("�Ԏ�F{0} �` {1}",
                         ct_Extr_Top, carModelEd));
                }
            }

            //���[�J�[
            if (this._modelShipRsltListCndtn.MakerCodeSt != 0)
            {
                if (this._modelShipRsltListCndtn.MakerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���[�J�[�F{0} �` {1}",
                         this._modelShipRsltListCndtn.MakerCodeSt.ToString("0000"), this._modelShipRsltListCndtn.MakerCodeEd.ToString("0000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���[�J�[�F{0} �` {1}",
                        this._modelShipRsltListCndtn.MakerCodeSt.ToString("0000"), ct_Extr_End));
                }
            }
            else
            {
                if (this._modelShipRsltListCndtn.MakerCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���[�J�[�F{0} �` {1}",
                         ct_Extr_Top, this._modelShipRsltListCndtn.MakerCodeEd.ToString("0000")));
                }
            }

            // BL����
            if (this._modelShipRsltListCndtn.BLGoodsCodeSt != 0)
            {
                if (this._modelShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         this._modelShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), this._modelShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                        this._modelShipRsltListCndtn.BLGoodsCodeSt.ToString("00000"), ct_Extr_End));
                }
            }
            else
            {
                if (this._modelShipRsltListCndtn.BLGoodsCodeEd != 0)
                {
                    this.EditCondition(ref addConditions, string.Format("BL�R�[�h�F{0} �` {1}",
                         ct_Extr_Top, this._modelShipRsltListCndtn.BLGoodsCodeEd.ToString("00000")));
                }
            }

            // ��\�^��
            if (!string.IsNullOrEmpty(this._modelShipRsltListCndtn.ModelName))
            {
                // --- UPD 2010/05/13 ---------->>>>>
                //// ��\�^��,��\�^�����o�敪
                //this.EditCondition(ref addConditions, string.Format("��\�^���F{0} {1}",
                //         this._modelShipRsltListCndtn.ModelName, this._modelShipRsltListCndtn.ModelOutDivName));
                // �^��,�^�����o�敪
                this.EditCondition(ref addConditions, string.Format("�^���F{0} {1}",
                         this._modelShipRsltListCndtn.ModelName, this._modelShipRsltListCndtn.ModelOutDivName));
                // --- UPD 2010/05/13 ----------<<<<<
            }

            //�q��
            if (!string.IsNullOrEmpty(this._modelShipRsltListCndtn.WarehouseCode))
            {
                // �q�ɃR�[�h,�q�ɖ�
                this.EditCondition(ref addConditions, string.Format("�q�ɁF{0} {1}",
                         this._modelShipRsltListCndtn.WarehouseCode, this._modelShipRsltListCndtn.WarehouseName));

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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMSYA02203P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
