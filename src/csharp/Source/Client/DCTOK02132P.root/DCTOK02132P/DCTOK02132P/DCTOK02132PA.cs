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
    /// ���㐄�ڕ\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㐄�ڕ\�̈�����s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>Update Note: 2008.10.16 30452 ��� �r��</br>
    /// <br>            �EPM.NS�Ή�</br>
    /// <br>UpdateNote : 2008/10/30 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote : 2009/02/24 96186 ���ԗT��@�������[�G���[�Ή�</br>
    /// <br>Update Note: 2009/04/15 ����</br>
    /// <br>            �E���㐄�ڕ\�i�d����ʁj�̒ǉ�</br>
    /// <br>Update Note: 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// </remarks>
    class DCTOK02132PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// ���㐄�ڕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���㐄�ڕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02132PA()
        {
        }

        /// <summary>
        /// ���㐄�ڕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���㐄�ڕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02132PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._salesTransListCndtn = this._printInfo.jyoken as SalesTransListCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        //private const string ct_Extr_Top = "�s�n�o"; // DEL 2008/10/16
        //private const string ct_Extr_End = "�d�m�c"; // DEL 2008/10/16
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private SalesTransListCndtn _salesTransListCndtn;		// ���o�����N���X
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
                prtRpt.DataMember = DCTOK02134EA.ct_Tbl_SalesTransList;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //this.SetPrintCommonInfo( out commonInfo );

                this.SetPrintCommonInfo(ref prtRpt, out commonInfo);
                // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
                    // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    prtRpt.Document.Dispose();
                    // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <param name="rptObj"></param>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)

        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // 2009/02/24 Y.Tachibana >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // 2009/02/24 Y.Tachibana <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            SalesTransListCndtn extraInfo = (SalesTransListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            //instance.PageHeaderSortOderTitle = "";
            instance.PageHeaderSortOderTitle = "[" + extraInfo.DetailDataValueName + "��]"; // ADD 2008/10/16

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesTransListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            instance.PageHeaderSubtitle = string.Format("{0}", this._printInfo.prpnm);

            // ���̑��f�[�^
            // Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            string stCode;
            string edCode;

            //------------------------------------------------------------------------------------------------------------
            // �Ώ۔N��
            this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                                                                    this._salesTransListCndtn.St_ThisYearMonth.ToString("yyyy/MM"),
                                                                    this._salesTransListCndtn.Ed_ThisYearMonth.ToString("yyyy/MM")));

            // �W�v���@
            //this.EditCondition( ref addConditions, string.Format( "�W�v���@�F{0}", this._salesTransListCndtn.GroupBySectionDivName ) ); // DEL 2008/10/16
            this.EditCondition(ref addConditions, string.Format("�W�v���@�F{0}", this._salesTransListCndtn.TtlTypeName)); // ADD 2008/10/16

            // �o�א��w��
            //this.EditCondition( ref addConditions, string.Format( "�o�א��w��" + ct_RangeConst,
            //                                                        this._salesTransListCndtn.St_ShipmentCnt,
            //                                                        this._salesTransListCndtn.Ed_ShipmentCnt ) ); // DEL 2008/10/16

            // DEL 2008/10/31 �s��Ή�[7298] ---------->>>>>
            // --- ADD 2008/10/16 -------------------------------->>>>>
            //if (this._salesTransListCndtn.St_ShipmentCnt != 0 || this._salesTransListCndtn.Ed_ShipmentCnt != 999999999)
            //{
            //    stCode = ct_Extr_Top;
            //    edCode = ct_Extr_End;

            //    if (this._salesTransListCndtn.St_ShipmentCnt != 0)
            //    {
            //        stCode = this._salesTransListCndtn.St_ShipmentCnt.ToString("000000000");
            //    }

            //    if (this._salesTransListCndtn.Ed_ShipmentCnt != 999999999)
            //    {
            //        edCode = this._salesTransListCndtn.Ed_ShipmentCnt.ToString("000000000");
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("�o�א��w��" + ct_RangeConst, stCode, edCode));
            //}
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // DEL 2008/10/31 �s��Ή�[7298] ----------<<<<<
            // --- DEL 2009/02/10 -------------------------------->>>>>
            //// ADD 2008/10/31 �s��Ή�[7298] ---------->>>>>
            //this.EditCondition( ref addConditions, string.Format( "�o�א��w��" + ct_RangeConst,
            //                                                        this._salesTransListCndtn.St_ShipmentCnt,
            //                                                        this._salesTransListCndtn.Ed_ShipmentCnt));
            //// ADD 2008/10/31 �s��Ή�[7298] ----------<<<<<
            // --- DEL 2009/02/10 --------------------------------<<<<<
            // --- ADD 2009/02/10 -------------------------------->>>>>
            if (!this._salesTransListCndtn.St_ShipmentCntNoInputFlg || !this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg)
            {
                stCode = ct_Extr_Top;
                edCode = ct_Extr_End;

                if (!this._salesTransListCndtn.St_ShipmentCntNoInputFlg)
                {
                    stCode = this._salesTransListCndtn.St_ShipmentCnt.ToString();
                }

                if (!this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg)
                {
                    edCode = this._salesTransListCndtn.Ed_ShipmentCnt.ToString();
                }

                this.EditCondition(ref addConditions,
                    string.Format("�o�א��w��" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2009/02/10 --------------------------------<<<<<
            // ����^�C�v
            this.EditCondition(ref addConditions, string.Format("����^�C�v�F{0}",
                                                                    this._salesTransListCndtn.PrintTypeDivName));

            // ���z�P��
            this.EditCondition(ref addConditions, string.Format("���z�P�ʁF{0}",
                                                                    this._salesTransListCndtn.PriceUnitDivName));

            // �݌Ɏ��w��
            //this.EditCondition( ref addConditions, string.Format( "�݌Ɏ��w��F{0}",
            //                                                        this._salesTransListCndtn.StockOrderDivName ) ); // DEL 2008/10/16
            this.EditCondition(ref addConditions, string.Format("�ݎ�w��F{0}",
                                                                    this._salesTransListCndtn.StockOrderDivName)); // ADD 2008/10/16

            // --- ADD 2008/10/16 -------------------------------->>>>>
            // ���[�J�[�ʈ��
            this.EditCondition(ref addConditions, string.Format("���[�J�[�ʈ���F{0}",
                                                                    this._salesTransListCndtn.MakerPrintDivName));

            // ����
            if (this._salesTransListCndtn.NewPageDiv != SalesTransListCndtn.NewPageDivState.None)
            {
                this.EditCondition(ref addConditions, string.Format("���ŁF{0}",
                                                                this._salesTransListCndtn.NewPageDivName));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<

            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
            if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods)
            {
                // ���גP�ʂ��u�i�ԁv��
                if (this._salesTransListCndtn.Detail == 0)
                {
                    // �i�ԕ\���敪
                    this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F{0}",
                                                                            this._salesTransListCndtn.GoodsNoTtlDivName));
                    // �i�ԕ\���敪���u���Z�v��
                    if (this._salesTransListCndtn.GoodsNoTtlDiv == SalesTransListCndtn.GoodsNoTtlDivState.Together)
                    {
                        // �i�ԑI���敪
                        this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F{0}",
                                                                                this._salesTransListCndtn.GoodsNoShowDivName));
                    }
                }
            }
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

            //------------------------------------------------------------------------------------------------------------
            // ���Ӑ�
            if ((this._salesTransListCndtn.St_CustomerCode != 0) ||
                (this._salesTransListCndtn.Ed_CustomerCode != 99999999))
            {
                stCode = this._salesTransListCndtn.St_CustomerCode.ToString("00000000");
                edCode = this._salesTransListCndtn.Ed_CustomerCode.ToString("00000000");
                if (this._salesTransListCndtn.St_CustomerCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_CustomerCode == 99999999) edCode = ct_Extr_End;  // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_CustomerCode == 99999999 &&
                    this._salesTransListCndtn.Set_CustomerCode == false) edCode = ct_Extr_End;      // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_CustomerCode)
            {
                stCode = this._salesTransListCndtn.St_CustomerCode.ToString("00000000");
                edCode = this._salesTransListCndtn.Ed_CustomerCode.ToString("00000000");
                if (this._salesTransListCndtn.St_CustomerCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<
            // ----ADD 2009/04/15 ----------------------------------------->>>>>
            // �d����
            if ((this._salesTransListCndtn.St_SupplierCode != 0) ||
               (this._salesTransListCndtn.Ed_SupplierCode != 999999))
            {
                stCode = this._salesTransListCndtn.St_SupplierCode.ToString("000000");
                edCode = this._salesTransListCndtn.Ed_SupplierCode.ToString("000000");
                if (this._salesTransListCndtn.St_SupplierCode == 0) stCode = ct_Extr_Top;
                if (this._salesTransListCndtn.Ed_SupplierCode == 999999 &&
                    this._salesTransListCndtn.Set_SupplierCode == false) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�d����" + ct_RangeConst, stCode, edCode));
            }
            else if (this._salesTransListCndtn.Set_SupplierCode)
            {
                stCode = this._salesTransListCndtn.St_SupplierCode.ToString("000000");
                edCode = this._salesTransListCndtn.Ed_SupplierCode.ToString("000000");
                if (this._salesTransListCndtn.St_SupplierCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("�d����" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2009/04/15 -------------------------------------------<<<<<
            // �S����
            //if ( ( this._salesTransListCndtn.St_EmployeeCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() != string.Empty ) )
            //if ((this._salesTransListCndtn.St_EmployeeCode.TrimEnd() != "0000") ||
            ////(this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() != "9999")) // DEL 2008/12/16
            if (!string.IsNullOrEmpty(this._salesTransListCndtn.St_EmployeeCode)
                || !string.IsNullOrEmpty(this._salesTransListCndtn.Ed_EmployeeCode)) // ADD 2008/12/16
            {
                stCode = this._salesTransListCndtn.St_EmployeeCode.TrimEnd().PadLeft(4, '0');
                edCode = this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd().PadLeft(4, '0');
                if (string.IsNullOrEmpty(this._salesTransListCndtn.St_EmployeeCode)) stCode = ct_Extr_Top; // ADD 2008/12/16
                //if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "9999") edCode = ct_Extr_End;    // DEL 2008/10/30 �s��Ή�[7203]
                //if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "9999" &&
                //    this._salesTransListCndtn.Set_EmployeeCode == false) edCode = ct_Extr_End;    // ADD 2008/10/30 �s��Ή�[7203] // DEL 2008/12/16
                if (string.IsNullOrEmpty(this._salesTransListCndtn.Ed_EmployeeCode)) edCode = ct_Extr_End; // ADD 2008/12/16

                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stCode, edCode));
            }
            // --- DEL 2008/12/09 -------------------------------->>>>>
            //// ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            //else if (this._salesTransListCndtn.Set_EmployeeCode)
            //{
            //    stCode = this._salesTransListCndtn.St_EmployeeCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd();
            //    if (this._salesTransListCndtn.St_EmployeeCode.TrimEnd() == "0000") stCode = ct_Extr_Top;
            //    if (this._salesTransListCndtn.Ed_EmployeeCode.TrimEnd() == "0000") edCode = ct_Extr_End;

            //    this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stCode, edCode));
            //}
            //// ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<
            // --- DEL 2008/12/09 --------------------------------<<<<<

            // ���[�J�[
            if ((this._salesTransListCndtn.St_GoodsMakerCd != 0) ||
                (this._salesTransListCndtn.Ed_GoodsMakerCd != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsMakerCd.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMakerCd.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsMakerCd == 9999) edCode = ct_Extr_End;  // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_GoodsMakerCd == 9999 &&
                    this._salesTransListCndtn.Set_GoodsMakerCd == false) edCode = ct_Extr_End;  // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsMakerCd)
            {
                stCode = this._salesTransListCndtn.St_GoodsMakerCd.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMakerCd.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            // ���i�敪�O���[�v
            //if ( ( this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_LargeGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪�O���[�v" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // ���i�啪��
            if ((this._salesTransListCndtn.St_GoodsLGroup != 0) ||
                (this._salesTransListCndtn.Ed_GoodsLGroup != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsLGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsLGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsLGroup == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsLGroup == 9999) edCode = ct_Extr_End; // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_GoodsLGroup == 9999 &&
                    this._salesTransListCndtn.Set_GoodsLGroup == false) edCode = ct_Extr_End; // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsLGroup)
            {
                stCode = this._salesTransListCndtn.St_GoodsLGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsLGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsLGroup == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<



            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// ���i�敪
            //if ( ( this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_MediumGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 -------------------------------->>>>>
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // ���i������
            if ((this._salesTransListCndtn.St_GoodsMGroup != 0) ||
                (this._salesTransListCndtn.Ed_GoodsMGroup != 9999))
            {
                stCode = this._salesTransListCndtn.St_GoodsMGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMGroup == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_GoodsMGroup == 9999) edCode = ct_Extr_End; // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_GoodsMGroup == 9999 &&
                    this._salesTransListCndtn.Set_GoodsMGroup == false) edCode = ct_Extr_End; // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_GoodsMGroup)
            {
                stCode = this._salesTransListCndtn.St_GoodsMGroup.ToString("0000");
                edCode = this._salesTransListCndtn.Ed_GoodsMGroup.ToString("0000");
                if (this._salesTransListCndtn.St_GoodsMGroup == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// ���i�敪�ڍ�
            //if ( ( this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd();
            //    edCode = this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd();
            //    if ( this._salesTransListCndtn.St_DetailGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪�ڍ�" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // �O���[�v�R�[�h
            if ((this._salesTransListCndtn.St_BLGroupCode != 0) ||
                (this._salesTransListCndtn.Ed_BLGroupCode != 99999))
            {
                stCode = this._salesTransListCndtn.St_BLGroupCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGroupCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGroupCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_BLGroupCode == 99999) edCode = ct_Extr_End;    // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_BLGroupCode == 99999 &&
                    this._salesTransListCndtn.Set_BLGloupCode == false) edCode = ct_Extr_End;    // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_BLGloupCode)
            {
                stCode = this._salesTransListCndtn.St_BLGroupCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGroupCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGroupCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<

            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// ���Е��ރR�[�h
            //if ( (this._salesTransListCndtn.St_EnterpriseGanreCode != 0) ||
            //    (this._salesTransListCndtn.Ed_EnterpriseGanreCode != 9999) )
            //{
            //    stCode = this._salesTransListCndtn.St_EnterpriseGanreCode.ToString();
            //    edCode = this._salesTransListCndtn.Ed_EnterpriseGanreCode.ToString();
            //    if ( this._salesTransListCndtn.St_EnterpriseGanreCode == 0 ) stCode = ct_Extr_Top;
            //    if ( this._salesTransListCndtn.Ed_EnterpriseGanreCode == 9999 ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���Е��ރR�[�h" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<

            // �a�k���i�R�[�h
            if ((this._salesTransListCndtn.St_BLGoodsCode != 0) ||
                (this._salesTransListCndtn.Ed_BLGoodsCode != 99999))
            {
                stCode = this._salesTransListCndtn.St_BLGoodsCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGoodsCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGoodsCode == 0) stCode = ct_Extr_Top;
                //if (this._salesTransListCndtn.Ed_BLGoodsCode == 99999) edCode = ct_Extr_End;  // DEL 2008/10/30 �s��Ή�[7203]
                if (this._salesTransListCndtn.Ed_BLGoodsCode == 99999 &&
                    this._salesTransListCndtn.Set_BLGoodsCode == false) edCode = ct_Extr_End;  // ADD 2008/10/30 �s��Ή�[7203]

                this.EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ---------->>>>>
            else if (this._salesTransListCndtn.Set_BLGoodsCode)
            {
                stCode = this._salesTransListCndtn.St_BLGoodsCode.ToString("00000");
                edCode = this._salesTransListCndtn.Ed_BLGoodsCode.ToString("00000");
                if (this._salesTransListCndtn.St_BLGoodsCode == 0) stCode = ct_Extr_Top;

                this.EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }
            // ADD 2008/10/30 �s��Ή�[7203] ----------<<<<<

            // ���i�ԍ�
            if ((this._salesTransListCndtn.St_GoodsNo.TrimEnd() != string.Empty) ||
                (this._salesTransListCndtn.Ed_GoodsNo.TrimEnd() != string.Empty))
            {
                stCode = this._salesTransListCndtn.St_GoodsNo.TrimEnd();
                edCode = this._salesTransListCndtn.Ed_GoodsNo.TrimEnd();
                if (this._salesTransListCndtn.St_GoodsNo.TrimEnd() == string.Empty) stCode = ct_Extr_Top;
                if (this._salesTransListCndtn.Ed_GoodsNo.TrimEnd() == string.Empty) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�i��" + ct_RangeConst, stCode, edCode));
            }

            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion

        #region �� ���o�͈͕�����쐬
        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion
        #endregion
    }
}
