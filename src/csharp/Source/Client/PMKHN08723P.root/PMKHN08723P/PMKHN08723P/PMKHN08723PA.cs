//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : gezh
// �� �� ��  2012/07/02  �C�����e : Redmine#30390 ���[�w�b�_���ڂɔ��s�^�C�v�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using System.Data;
using Broadleaf.Application.Controller;
using System.Collections.Specialized;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �\���敪�}�X�^�i����j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^�i����j�̈�����s���B</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>Update Note: 2012/07/02 gezh</br>	
    /// <br>�Ǘ��ԍ�   �F10801804-00 Redmine#30390 ���[�w�b�_���ڂɔ��s�^�C�v�̒ǉ�</br>
    /// </remarks>
    public class PMKHN08723PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// �\���敪�}�X�^�i����j�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�i����j�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public PMKHN08723PA()
        {

        }
        /// <summary>
        /// �\���敪�}�X�^�i����j�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�i����j�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public PMKHN08723PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._priceSelectSetPrint = (PriceSelectSetPrint)this._printInfo.jyoken;
        }
        #endregion �� Constructor

        #region �� Private Member
        private SFCMN06002C _printInfo;					                // ������N���X
        private PriceSelectSetPrint _priceSelectSetPrint;	            // ���o�����N���X
        #endregion �� Private Member

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        private const string ct_Const = "�F{0}";  // ADD gezh 2012/07/02 redmine#30390
        #endregion �� Pricate Const

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
        /// ������
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
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
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
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
        /// <param name="prtRpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 prtRpt, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            prtRpt = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion �� �e��ActiveReport���[�C���X�^���X�쐬

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
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
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
        #endregion �� ���|�[�g�A�Z���u���C���X�^���X��

        #region �� �����ʋ��ʏ��ݒ�
        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
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
            pdfName = "�\" + pdfName;
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = this._printInfo.py;
            // ���]��
            commonInfo.MarginsLeft = this._printInfo.px;
        }
        #endregion �� �����ʋ��ʏ��ݒ�

        #region �� �e��v���p�e�B�ݒ�
        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="prtRpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 prtRpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = prtRpt as IPrintActiveReportTypeList;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = PartsPosCodePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            instance.PageHeaderSubtitle = string.Format("�\���敪�}�X�^");

            // ���̑��f�[�^
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion �� �e��v���p�e�B�ݒ�

        #region �� ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>Update Note: 2012/07/02 gezh</br>	
        /// <br>�Ǘ��ԍ�   �F10801804-00 Redmine#30390 ���[�w�b�_���ڂɔ��s�^�C�v�̒ǉ�</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            const string dateFormat = "yyyy/MM/dd";
            string stTarget = "";
            string edTarget = "";
            // ADD gezh 2012/07/02 redmine#30390 ------------------------------------------------->>>>>
            // ���s�^�C�v
            switch (this._priceSelectSetPrint.PrintType)
            {
                case 0:
                    stTarget = "Ұ�����ށEBL���ށE���Ӑ溰��";
                    break;
                case 1:
                    stTarget = "Ұ�����ށE���Ӑ溰��";
                    break;
                case 2:
                    stTarget = "BL���ށE���Ӑ溰��";
                    break;
                case 3:
                    stTarget = "Ұ�����ށEBL���ށE���Ӑ�|����ٰ��";
                    break;
                case 4:
                    stTarget = "Ұ�����ށE���Ӑ�|����ٰ��";
                    break;
                case 5:
                    stTarget = "BL���ށE���Ӑ�|����ٰ��";
                    break;
                case 6:
                    stTarget = "Ұ�����ށEBL���";
                    break;
                case 7:
                    stTarget = "Ұ������";
                    break;
                case 8:
                    stTarget = "BL����";
                    break;
                case 9:
                    stTarget = "�S��";
                    break;
            }
            this.EditCondition(ref extraConditions, string.Format("���s�^�C�v" + ct_Const, stTarget));
            // ADD gezh 2012/07/02 redmine#30390 -------------------------------------------------<<<<<
            // �폜���
            if (this._priceSelectSetPrint.LogicalDeleteCode == 1)
            {
                if ((this._priceSelectSetPrint.DeleteDateTimeSt != DateTime.MinValue) || (this._priceSelectSetPrint.DeleteDateTimeEd != DateTime.MinValue))
                {
                    // �J�n
                    if (this._priceSelectSetPrint.DeleteDateTimeSt != DateTime.MinValue)
                    {
                        stTarget = this._priceSelectSetPrint.DeleteDateTimeSt.ToString(dateFormat);
                    }
                    else
                    {
                        stTarget = ct_Extr_Top;
                    }
                    // �I��
                    if (this._priceSelectSetPrint.DeleteDateTimeEd != DateTime.MinValue)
                    {
                        edTarget = this._priceSelectSetPrint.DeleteDateTimeEd.ToString(dateFormat);
                    }
                    else
                    {
                        edTarget = ct_Extr_End;
                    }
                    this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                }
            }
            // ���[�J�[�R�[�h
            if (this._priceSelectSetPrint.GoodsMakerCdSt != 0 || this._priceSelectSetPrint.GoodsMakerCdEd != 0)
            {
                stTarget = this._priceSelectSetPrint.GoodsMakerCdSt.ToString("0000");
                edTarget = this._priceSelectSetPrint.GoodsMakerCdEd.ToString("0000");
                if (this._priceSelectSetPrint.GoodsMakerCdSt == 0) stTarget = ct_Extr_Top;
                if (this._priceSelectSetPrint.GoodsMakerCdEd == 0) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("���[�J�[" + ct_RangeConst, stTarget, edTarget));

            }

            // BL�R�[�h
            if (this._priceSelectSetPrint.BLGoodsCodeSt != 0 || this._priceSelectSetPrint.BLGoodsCodeEd != 0)
            {
                stTarget = this._priceSelectSetPrint.BLGoodsCodeSt.ToString("00000");
                edTarget = this._priceSelectSetPrint.BLGoodsCodeEd.ToString("00000");
                if (this._priceSelectSetPrint.BLGoodsCodeSt == 0) stTarget = ct_Extr_Top;
                if (this._priceSelectSetPrint.BLGoodsCodeEd == 0) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("BL�R�[�h" + ct_RangeConst, stTarget, edTarget));

            }
            // ���Ӑ�R�[�h
            if (this._priceSelectSetPrint.CustomerCodeSt != 0 || this._priceSelectSetPrint.CustomerCodeEd != 0)
            {
                stTarget = this._priceSelectSetPrint.CustomerCodeSt.ToString("00000000");
                edTarget = this._priceSelectSetPrint.CustomerCodeEd.ToString("00000000");
                if (this._priceSelectSetPrint.CustomerCodeSt == 0) stTarget = ct_Extr_Top;
                if (this._priceSelectSetPrint.CustomerCodeEd == 0) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));

            }

            // ���Ӑ�|���O���[�v
            if (!string.IsNullOrEmpty(this._priceSelectSetPrint.BLGroupCodeSt) || !string.IsNullOrEmpty(this._priceSelectSetPrint.BLGroupCodeEd))
            {
                stTarget = this._priceSelectSetPrint.BLGroupCodeSt;
                edTarget = this._priceSelectSetPrint.BLGroupCodeEd;
                if (string.IsNullOrEmpty(this._priceSelectSetPrint.BLGroupCodeSt)) stTarget = ct_Extr_Top;
                if (string.IsNullOrEmpty(this._priceSelectSetPrint.BLGroupCodeEd)) edTarget = ct_Extr_End;

                this.EditCondition(ref extraConditions, string.Format("���Ӑ�|���O���[�v" + ct_RangeConst, stTarget, edTarget));

            }
            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }
        #endregion �� ���o�����o�͏��쐬

        #region �� ���o����������ҏW
        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
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
        #endregion �� ���o����������ҏW
        #endregion �� ���|�[�g�t�H�[���ݒ�֘A

        #region �� ���b�Z�[�W�\��
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKHN08723P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion�� ���b�Z�[�W�\��
        #endregion �� Private Member
    }
}
