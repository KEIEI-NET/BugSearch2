//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
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
using DataDynamics.ActiveReports;
using Broadleaf.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �������i���i��������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i���i�����̈�����s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009/04/28</br>
    /// </remarks>
    class PMKHN02304PA : IPrintProc
    {
        # region �� Private Const

        /// <summary> ����t�H�[���l�[���X�y�[�X </summary>
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        /// <summary> �X�y�[�X(����p) </summary>
        private const string ct_Space = "�@";
        /// <summary> �J�n ���o�͈͏����l(����p) </summary>
        private const string ct_Extr_Top = "�ŏ�����";
        /// <summary> �I�� ���o�͈͏����l(����p) </summary>
        private const string ct_Extr_End = "�Ō�܂�";

        # endregion �� Private Const


        # region �� Private Member

        /// <summary> ������N���X </summary>
        private SFCMN06002C _printInfo;
        /// <summary> ���o�����N���X </summary>
        private GoodsInfoCndtn _goodsInfoCndtn;
        /// <summary> �ϑ��݌ɕ�[�����A�N�Z�X�N���X </summary>
        private GoodsInfoAcs _goodsInfoAcs;

        # endregion �� Private Member


        # region �� Constructor
        /// <summary>
        /// �������i���i��������N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i��������N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02304PA()
        {
        }

        /// <summary>
        /// �������i���i��������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �������i���i��������N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02304PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._goodsInfoCndtn = this._printInfo.jyoken as GoodsInfoCndtn;
            this._goodsInfoAcs = new GoodsInfoAcs();
        }
        # endregion �� Constructor


        # region �� IPrintProc �C���^�[�t�F�[�X
        /// <summary>
        /// ������擾�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public int StartPrint()
        {
            // �������
            return PrintMain();
        }
        # endregion �� IPrintProc �C���^�[�t�F�[�X


        # region �� Private Method
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            ActiveReport3 prtRpt = null;

            try
            {
                // �e��ActiveReport���[�C���X�^���X�쐬
                CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = (DataView)this._printInfo.rdData;
                prtRpt.DataMember = PMKHN02306EA.ct_Tbl_GoodsWarnErrorCheck;

                // ������ʏ��v���p�e�B�ݒ�
                SFCMN00293UC commonInfo;
                SetPrintCommonInfo(out commonInfo);

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
                            SFCMN00293UB processForm = new SFCMN00293UB();

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
                            SFCMN00293UA viewForm = new SFCMN00293UA();

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
                                    SFANL06101UA pdfHistoryControl = new SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm,
                                                                   this._printInfo.prpnm, this._printInfo.pdftemppath);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
                            ex.Message,
                            -1,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
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

        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (ActiveReport3)LoadAssemblyReport(prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), typeof(ActiveReport3));
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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                Assembly asm = Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new ConfirmTrustStockOrderException(asmname + "�����݂��܂���B", -1);
            }
            catch (Exception er)
            {
                throw new ConfirmTrustStockOrderException(er.Message, -1);
            }
            return obj;
        }

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void SetPrintCommonInfo(out SFCMN00293UC commonInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new SFCMN00293UC();

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
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private int SettingProperty(ref ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            GoodsInfoCndtn extraInfo = (GoodsInfoCndtn)this._printInfo.jyoken;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet = new PrtOutSet();
            string message;
            int st = this._goodsInfoAcs.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new ConfirmTrustStockOrderException(message, status);
            }

            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            MakeExtarCondition(out extraInfomations);

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

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            //const string ct_RangeConst = "�F{0} �` {1}";
            extraConditions = new StringCollection();

            string strTarget;

            // ��[�X�V
            strTarget = "";
            if (this._goodsInfoCndtn.UpdateType == 0)
            {
                strTarget = "���i�}�X�^�X�V�敪�F���i����(�ǉ��L��)";
            }
            else if (this._goodsInfoCndtn.UpdateType == 1)
            {
                strTarget = "���i�}�X�^�X�V�敪�F���i�����̂�";
            }
            else if (this._goodsInfoCndtn.UpdateType == 2)
            {
                strTarget = "���i�}�X�^�X�V�敪�F�ǉ��̂�";
            }

            EditCondition(ref extraConditions, strTarget);

        }

        /// <summary>
        /// ���o�͈͕�����쐬
        /// </summary>
        /// <returns>�쐬������</returns>
        /// <remarks>
        /// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
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
                result = String.Format(title + "�F {0} �` {1}", start, end);
            }
            return result;
        }

        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
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
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMKHN02304P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion �� Private Methods


        # region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class ConfirmTrustStockOrderException : ApplicationException
        {
            private int _status;
            # region Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public ConfirmTrustStockOrderException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            # endregion

            # region Public Property
            /// <summary> �X�e�[�^�X�v���p�e�B </summary>
            public int Status
            {
                get { return this._status; }
            }
            # endregion
        }
        # endregion �� Exception Class
    }
}
