//***************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\��ꗗ�\
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\ ����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI���� ����
// �� �� ��   2013/01/28 �C�����e : �V�K�쐬 �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �d���ԕi�\��ꗗ�\����N���X
    /// </summary>
    /// <remarks>
	/// <br>Note       : �d���ԕi�\��ꗗ�\�̈�����s�Ȃ��N���X�ł��B</br>
	/// <br>Programer  : FSI���� ����</br>
	/// <br>Date       :  2013/01/28</br>
	/// </remarks>
    public class PMKAK02033PA
    {
        //================================================================================
        //  �R���X�g���N�^�[
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// �d���ԕi�\��ꗗ�\����N���X�R���X�g���N�^
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\����N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02033PA()
        {
        }

        /// <summary>
        /// �d���ԕi�\��ꗗ�\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\��ꗗ�\����N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public PMKAK02033PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;

            this._pdfHistoryControl = new PdfHistoryControl();
            this._sfcmn00331C = new SFCMN00331C();

			this._extrInfo_PMKAK02034E = this._printInfo.jyoken as ExtrInfo_PMKAK02034E;

            this.SelectTableName();

        }
        #endregion

        //================================================================================
        //  �����萔
        //================================================================================
        #region private constant
        private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
        private const string CT_ITEM_INTERVAL = "�@�@�@�@�@";

        #endregion

        //================================================================================
        //  �����ϐ�
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;
        private PdfHistoryControl _pdfHistoryControl = null;
        private SFCMN00331C _sfcmn00331C = null;			// ���[�n���ʕ��i
		private ExtrInfo_PMKAK02034E _extrInfo_PMKAK02034E = null;	// ���o�����N���X
        #endregion

        // �f�[�^�擾���e�[�u����
        private string ct_TableName;

        //================================================================================
        //  �O���񋟃v���p�e�B
        //================================================================================
        #region public property
        #region IPrintProc�̎�����(�v���p�e�B)
        /// <summary>����f�[�^</summary>
        /// <value>�������f�[�^���擾�܂��͐ݒ肵�܂��B</value>
        public SFCMN06002C Printinfo
        {
            get { return _printInfo; }
            set { _printInfo = value; }
        }
        #endregion
        #endregion

        // ===============================================================================
        // ��O�N���X
        // ===============================================================================
        #region ��O�N���X
        private class DemandPrintException : ApplicationException
        {
            private int _status;

            #region constructor
            public DemandPrintException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region public property
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion

        //================================================================================
        //  IPrintProc�̎������@������C������
        //================================================================================
        #region IPrintProc�̎�����
        /// <summary>
        /// ����J�n����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����̊J�n�������s���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        public int StartPrint()
        {
            return this.PrintMain();
        }
        #endregion

        //================================================================================
        // �����֐�
        //================================================================================
        #region Private Methods
        #region ���@������C������
        /// <summary>
        /// ������C������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����̃��C���������s���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // ����t�H�[���N���X�C���X�^���X�쐬
                DataDynamics.ActiveReports.ActiveReport3 prtRpt;

                // ���|�[�g�C���X�^���X�쐬
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // ����f�[�^�擾
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv.Table = ds.Tables[ct_TableName];
				
                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = dv;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(out commonInfo);

                // �v���r���[�L��				
                int prevkbn = this._printInfo.prevkbn;

                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                if (this._printInfo.printmode == 2)
                {
                    prevkbn = 0;
                }
                switch (prevkbn)
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
                        case 1:		// �v�����^
                            break;
                        case 2:		// �o�c�e
                        case 3:		// ����(�v�����^ + �o�c�e)
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
            catch (DemandPrintException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;
        }
		#endregion ���@�\�[�g���o��

		/// <summary>
        /// �d�l�e�[�u�����ݒ菈��
        /// </summary>
        private void SelectTableName()
        {
            // �d���ԕi�\��ꗗ�\����
			ct_TableName = PMKAK02035EA.ct_Tbl_StockRetDtl;

        }

        #endregion

        #region ���@ActiveReport���[�C���X�^���X�쐬�֘A
        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
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
                throw new DemandPrintException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new DemandPrintException(er.Message, -1);
            }
            return obj;
        }
        #endregion

        #region ���@AvtiveReport�Ɋe��v���p�e�B��ݒ肵�܂�
        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet = null;
            string message = string.Empty;
            status = PMKAK02032A.ReadPrtOutSet(out prtOutSet, out message);
            if (!status.Equals(0))
            {
                throw new DemandPrintException(message, status);
            }

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
        #endregion

        #region ���@���o�����w�b�_�[�쐬����
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
		/// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            string target = "";
            string stTarget = "";
            string edTarget = "";

            // ���͓��F�J�n
            string fromInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_PMKAK02034E.InputDaySt);
            stTarget = "���͓�: " + (string.IsNullOrEmpty(fromInputDate) ? "�ŏ�����" : fromInputDate);

            // ���͓��F�I��
            string toInputDate = TDateTime.LongDateToString("YYYY/MM/DD", this._extrInfo_PMKAK02034E.InputDayEd);
            edTarget = "  �`�@" + (string.IsNullOrEmpty(toInputDate) ? "�Ō�܂�" : toInputDate);

            // "�ŏ����� �` �Ō�܂�"�͈󎚂��Ȃ�
            if (!string.IsNullOrEmpty(fromInputDate + toInputDate))
            {
                target = stTarget + edTarget;
                this.EditCondition(ref extraConditions, target);
            }

            // �d����
            if (this._extrInfo_PMKAK02034E.SupplierCdSt != 0)
            {
                if (this._extrInfo_PMKAK02034E.SupplierCdEd != 0)	//From To ������
                {
                    target = "�d����: " + this._extrInfo_PMKAK02034E.SupplierCdSt.ToString("000000") + " �` " + this._extrInfo_PMKAK02034E.SupplierCdEd.ToString("000000"); 
                }
                else�@											//From ������
                {
                    target = "�d����: " + this._extrInfo_PMKAK02034E.SupplierCdSt.ToString("000000") + " �` " + "�Ō�܂�";
                }
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._extrInfo_PMKAK02034E.SupplierCdEd != 0)	//To������
            {
                target = "�d����: " + "�ŏ����� �` " + this._extrInfo_PMKAK02034E.SupplierCdEd.ToString("000000"); 
                this.EditCondition(ref extraConditions, target);
            }

            // �o�͎w��
            target = "�o�͎w��F" + this._extrInfo_PMKAK02034E.SlipDivName;
            this.EditCondition(ref extraConditions, target);

            #region < ���s�^�C�v >
            target = "���s�^�C�v�F" + this._extrInfo_PMKAK02034E.MakeShowDivName;
            this.EditCondition(ref extraConditions, target);
            #endregion

        }

        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            // �ŏ��̃f�[�^
            if (editArea.Count == 0)
            {
                editArea.Add(target + CT_ITEM_INTERVAL);
                return;
            }

            int areaIndex = editArea.Count - 1;
            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);
            // �i�[�G���A�̃o�C�g���Z�o
            int areaByte = TStrConv.SizeCountSJIS(editArea[areaIndex]);

            // �A��������MAX��
            if ((areaByte + targetByte) <= 164)
            {
                // �A������ + �󔒂�MAX��
                if ((areaByte + targetByte + TStrConv.SizeCountSJIS(CT_ITEM_INTERVAL)) <= 164)
                {
                    editArea[areaIndex] = editArea[areaIndex] + target + CT_ITEM_INTERVAL;
                }
                else
                {
                    editArea[areaIndex] = editArea[areaIndex] + target;
                }
            }
            else
            {
                // MAX�ƂȂ�ꍇ�A���̍s
                editArea.Add(target + CT_ITEM_INTERVAL);
            }
        }
        #endregion

        #region ���@���ʃv���r���[���i�p�����[�^�ݒ�
        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // �v�����^��
            commonInfo.PrinterName = this._printInfo.prinm;
            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;
            // �������
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[ct_TableName].Rows.Count;
            // ������[�h
            commonInfo.PrintMode = this._printInfo.printmode;
            // �]���ݒ�
            // ���ʒu
            commonInfo.MarginsLeft = this._printInfo.px;
            // �s�ʒu
            commonInfo.MarginsTop = this._printInfo.py;
            // PDF�o�̓t���p�X
            string pdfPath = "";
            string pdfName = "";
            this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);

            string pdfFileName = System.IO.Path.Combine(pdfPath, pdfName);
            commonInfo.PdfFullPath = pdfFileName;

            this._printInfo.pdftemppath = pdfFileName;
        }
        #endregion

        #region ���@���b�Z�[�W�\������
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
        /// <br>Programer  : FSI���� ����</br>
        /// <br>Date       :  2013/01/28</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
			return TMsgDisp.Show(iLevel, "PMKAK02033P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
