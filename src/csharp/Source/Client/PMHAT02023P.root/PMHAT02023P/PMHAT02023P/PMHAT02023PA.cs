//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g����N���X
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�g������s���B</br>
    /// <br>Programmer : ������</br>                                   
    /// <br>Date       : 2009.04.02</br>                                       
    /// </remarks>
    public class PMHAT02023PA
    {
        #region �� Private Members
        private SFCMN00299CA _waitDialog = new SFCMN00299CA();

        // ������N���X
        private SFCMN06002C _printInfo;

        // namespace
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";

        // ��������
        private OrderSetMasListPara _orderSetMasListPara;

        // Space
        private const string ct_Space = "�@";

        // ������TOP
        private const string STR_TOP = "�ŏ�����";

        // ������END
        private const string STR_END = "�Ō�܂�";
        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public PMHAT02023PA()
        {

        }
        #endregion

        #region �� �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���X�g����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public PMHAT02023PA(object printInfo)
        {
            _printInfo = printInfo as SFCMN06002C;

            _orderSetMasListPara = this._printInfo.jyoken as OrderSetMasListPara;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : ������</br> 
        /// <br>Date       : 2009.04.02</br>
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

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0)
                {
                    return status;
                }

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;

                prtRpt.DataMember = PMHAT02025EA.Tbl_OrderSetMasListReportData;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                //�v���r���[�L��				
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
        #endregion

        #region �� �e��ActiveReport���[�C���X�^���X�쐬����
        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬����
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }
        #endregion

        #region �� ���|�[�g�A�Z���u���C���X�^���X������
        /// <summary>
        /// ���|�[�g�A�Z���u���C���X�^���X������
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
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
                throw new SuplierPayMainException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new SuplierPayMainException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region �� Exception Class
        /// <summary>
        /// ��O�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��O�N���X�R���X�g���N�^�̍쐬���s���B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private class SuplierPayMainException : ApplicationException
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
            /// <br>Programmer	: ������</br>
            /// <br>Date		: 2009.04.02</br>
            /// </remarks>
            public SuplierPayMainException(string message, int status)
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

        #region �� ���b�Z�[�W�\������
        /// <summary>
        /// ���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHAT02023P", iMsg, iSt, iButton, iDefButton);
        }

        #endregion

        #region �� �v���p�e�B�ݒ菈��
        /// <summary>
        /// �e��v���p�e�B�ݒ菈��
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            OrderSetMasListPara extraInfo = (OrderSetMasListPara)this._printInfo.jyoken;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;
            

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }
        #endregion

        #region �� �����ʋ��ʏ��ݒ菈��
        /// <summary>
        /// �����ʋ��ʏ��ݒ菈��
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
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

            // ��Ԉ����
            DataSet ds = (DataSet)this._printInfo.rdData;
            commonInfo.PrintMax = ds.Tables[PMHAT02025EA.Tbl_OrderSetMasListReportData].Rows.Count;

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

        #region �� ���o�����o�͏��쐬����
        /// <summary>
        /// ���o�����o�͏��쐬����
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();

            // ���s�^�C�v
            string printType = GetString(this._orderSetMasListPara.PrintType);
            this.EditCondition(ref extraConditions, string.Format("���s�^�C�v�F{0}", printType));

             // �ݒ�R�[�h
            string startSetCode = string.Empty;
            string endSetCode = string.Empty;

            if (String.IsNullOrEmpty(this._orderSetMasListPara.StartSetCode))
            {
                startSetCode = STR_TOP;
            }
            else
            {
                startSetCode = this._orderSetMasListPara.StartSetCode;
            }

            if (String.IsNullOrEmpty(this._orderSetMasListPara.EndSetCode))
            {
                endSetCode = STR_END;
            }
            else
            {
                endSetCode = this._orderSetMasListPara.EndSetCode.ToString();
            }

            if (!STR_TOP.Equals(startSetCode) || !STR_END.Equals(endSetCode))
            {
                this.EditCondition(ref extraConditions, string.Format("�ݒ�R�[�h�F{0} �` {1}", startSetCode, endSetCode));
            }


            // �q�ɃR�[�h
            string startWarehouseCode = string.Empty;
            string endWarehouseCode = string.Empty;

            if (string.IsNullOrEmpty(this._orderSetMasListPara.StartWarehouseCode))
            {
                startWarehouseCode = STR_TOP;
            }
            else
            {
                startWarehouseCode = this._orderSetMasListPara.StartWarehouseCode;
            }

            if (string.IsNullOrEmpty(this._orderSetMasListPara.EndWarehouseCode))
            {
                endWarehouseCode = STR_END;
            }
            else
            {
                endWarehouseCode = this._orderSetMasListPara.EndWarehouseCode;
            }

            if (!STR_TOP.Equals(startWarehouseCode) || !STR_END.Equals(endWarehouseCode))
            {
                this.EditCondition(ref extraConditions, string.Format("�q�ɁF{0} �` {1}", startWarehouseCode, endWarehouseCode));
            }

            // �d����R�[�h
            string startSupplierCd = string.Empty;
            string endSupplierCd = string.Empty;

            if (0 == this._orderSetMasListPara.StartSupplierCd)
            {
                startSupplierCd = STR_TOP;
            }
            else
            {
                startSupplierCd = this._orderSetMasListPara.StartSupplierCd.ToString("D6");
            }

            if (0 == this._orderSetMasListPara.EndSupplierCd)
            {
                endSupplierCd = STR_END;
            }
            else
            {
                endSupplierCd = this._orderSetMasListPara.EndSupplierCd.ToString("D6");
            }

            if (!STR_TOP.Equals(startSupplierCd) || !STR_END.Equals(endSupplierCd))
            {
                this.EditCondition(ref extraConditions, string.Format("�d����F{0} �` {1}", startSupplierCd, endSupplierCd));
            }


            // ���[�J�[�R�[�h
            string startGoodsMakerCd = string.Empty;
            string endGoodsMakerCd = string.Empty;

            if (0 == this._orderSetMasListPara.StartGoodsMakerCd)
            {
                startGoodsMakerCd = STR_TOP;
            }
            else
            {
                startGoodsMakerCd = this._orderSetMasListPara.StartGoodsMakerCd.ToString("D4");
            }

            if (0 == this._orderSetMasListPara.EndGoodsMakerCd)
            {
                endGoodsMakerCd = STR_END;
            }
            else
            {
                endGoodsMakerCd = this._orderSetMasListPara.EndGoodsMakerCd.ToString("D4");
            }

            if (!STR_TOP.Equals(startGoodsMakerCd) || !STR_END.Equals(endGoodsMakerCd))
            {
                this.EditCondition(ref extraConditions, string.Format("Ұ���F{0} �` {1}", startGoodsMakerCd, endGoodsMakerCd));
            }

            // �����ރR�[�h
            string startGoodsMGroup = string.Empty;
            string endGoodsMGroup = string.Empty;

            if (0 == this._orderSetMasListPara.StartGoodsMGroup)
            {
                startGoodsMGroup = STR_TOP;
            }
            else
            {
                startGoodsMGroup = this._orderSetMasListPara.StartGoodsMGroup.ToString("D4");
            }

            if (0 == this._orderSetMasListPara.EndGoodsMGroup)
            {
                endGoodsMGroup = STR_END;
            }
            else
            {
                endGoodsMGroup = this._orderSetMasListPara.EndGoodsMGroup.ToString("D4");
            }

            if (!STR_TOP.Equals(startGoodsMGroup) || !STR_END.Equals(endGoodsMGroup))
            {
                this.EditCondition(ref extraConditions, string.Format("���i�����ށF{0} �` {1}", startGoodsMGroup, endGoodsMGroup));
            }

            // �O���[�v�R�[�h
            string startBLGroupCode = string.Empty;
            string endBLGroupCode = string.Empty;

            if (0 == this._orderSetMasListPara.StartBLGroupCode)
            {
                startBLGroupCode = STR_TOP;
            }
            else
            {
                startBLGroupCode = this._orderSetMasListPara.StartBLGroupCode.ToString("D5");
            }

            if (0 == this._orderSetMasListPara.EndBLGroupCode)
            {
                endBLGroupCode = STR_END;
            }
            else
            {
                endBLGroupCode = this._orderSetMasListPara.EndBLGroupCode.ToString("D5");
            }

            if (!STR_TOP.Equals(startBLGroupCode) || !STR_END.Equals(endBLGroupCode))
            {
                this.EditCondition(ref extraConditions, string.Format("��ٰ�ߺ��ށF{0} �` {1}", startBLGroupCode, endBLGroupCode));
            }

            //BL�R�[�h
            string startBLGoodsCode = string.Empty;
            string endBLGoodsCode = string.Empty;

            if (0 == this._orderSetMasListPara.StartBLGoodsCode)
            {
                startBLGoodsCode = STR_TOP;
            }
            else
            {
                startBLGoodsCode = this._orderSetMasListPara.StartBLGoodsCode.ToString("D5");
            }

            if (0 == this._orderSetMasListPara.EndBLGoodsCode)
            {
                endBLGoodsCode = STR_END;
            }
            else
            {
                endBLGoodsCode = this._orderSetMasListPara.EndBLGoodsCode.ToString("D5");
            }

            if (!STR_TOP.Equals(startBLGoodsCode) || !STR_END.Equals(endBLGoodsCode))
            {
                this.EditCondition(ref extraConditions, string.Format("BL���ށF{0} �` {1}", startBLGoodsCode, endBLGoodsCode));
            }

        }

        /// <summary>
        /// IntToString
        /// </summary>
        /// <param name="p">���s�^�C�v int</param>
        /// <returns>���s�^�C�v string</returns>
        /// <remarks>
        /// <br>Note       : ���s�^�C�v���擾���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2008.04.22</br>
        /// </remarks>
        private string GetString(int p)
        {
            string printType = String.Empty;
            switch (p)
            {
                case (0):
                    {
                        // �ʏ�
                        printType = "�ʏ�";
                    }
                    break;
                case (1):
                    {
                        // �폜
                        printType = "�폜";
                    }
                    break;
                case (2):
                    {
                        // �S��
                        printType = "�S��";
                    }
                    break;
            }
            return printType;
        }
        #endregion

        #region �� ���o����������ҏW����
        /// <summary>
        /// ���o����������ҏW����
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : ������</br>                                   
        /// <br>Date       : 2008.04.02</br>
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

        #region �� Public Members
        /// <summary>  ������v���p�e�B</summary>
        /// <value>Printinfo</value>               
        /// <remarks> ������擾���̓Z�b�g�v���p�e�B </remarks> 
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion
    }
}
