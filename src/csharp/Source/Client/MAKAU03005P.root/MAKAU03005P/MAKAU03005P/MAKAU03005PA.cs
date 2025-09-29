//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������ꗗ����N���X
// �v���O�����T�v   : �������ꗗ����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �������ꗗ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �������ꗗ�̈�����s���܂��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
    public class MAKAU03005PA : ICustomTextWriter
    {
        //================================================================================
        //  �R���X�g���N�^�[
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// �������ꗗ����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : �������ꗗ����N���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public MAKAU03005PA()
        {
        }
        /// <summary>
        /// �������ꗗ����N���X�R���X�g���N�^(�I�[�o�[���[�h +1)
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : �������ꗗ����N���X�̏��������s���V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public MAKAU03005PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._demandExtraInfo = this._printInfo.jyoken as ExtrInfo_EBooksDemandTotal;

            this._demandPrintAcs = new DemandEBooksPrintAcs();
            this._pdfHistoryControl = new PdfHistoryControl();
            this._sfcmn00331C = new SFCMN00331C();

            // �e�L�X�g�o�͕��i�̃C���X�^���X��
            this._customTextWriter = new CustomTextWriter();
        }
        #endregion

        //================================================================================
        //  �����萔
        //================================================================================
        #region private constant
        private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
        private const string CT_ITEM_INTERVAL = "�@";
        #endregion

        //================================================================================
        //  �����ϐ�
        //================================================================================
        #region private member
        private SFCMN06002C _printInfo = null;
        private ExtrInfo_EBooksDemandTotal _demandExtraInfo = null;
        private DemandEBooksPrintAcs _demandPrintAcs = null;
        private PdfHistoryControl _pdfHistoryControl = null;
        private SFCMN00331C _sfcmn00331C = null;			// ���[�n���ʕ��i
        private CustomTextWriter _customTextWriter = null;				// �e�L�X�g�o�͕��i
        #endregion

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
        /// <br>Note        : ����̊J�n�������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int StartPrint()
        {
            return this.PrintMain();
        }
        #endregion

        //================================================================================
        //  ICustomTextWriter�������@�e�L�X�g�o�͏���
        //================================================================================
        #region ICustomTextWriter �����o

        /// <summary>
        /// �e�L�X�g�o�͐ݒ���擾
        /// </summary>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="customTextProviderInfo">�e�L�X�g�o�͐ݒ���</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int GetCustomTextDefInfo(string schemaPath, out Broadleaf.Library.Text.CustomTextProviderInfo customTextProviderInfo)
        {
            customTextProviderInfo = _customTextWriter.GetCustomTextProviderInfo(schemaPath);
            return 0;
        }

        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <param name="source">�o�͑Ώۃf�[�^</param>
        /// <param name="schemaPath">�X�L�[�}�p�X</param>
        /// <param name="outputFilePath">�o�̓p�X</param>
        /// <param name="customTextProviderInfo">�e�L�X�g�o�͐ݒ���</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int MakeCustomText(object source, string schemaPath, string outputFilePath, ref Broadleaf.Library.Text.CustomTextProviderInfo customTextProviderInfo)
        {

            // �o�͏���ݒ�
            // ����f�[�^�擾
            DataView dv = source as DataView;
            // �\�[�g���ݒ�
            dv.Sort = this.GetPrintOderQuerry();

            // �e�L�X�g�o�͎��s �� �o�̓f�[�^�A�X�L�[�}�t�@�C����(=���[ID)�A�o�̓p�X�A�㏑�����[�h
            return _customTextWriter.WriteText(source, schemaPath, outputFilePath, _printInfo.overWriteFlag);
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
        /// <br>Note        : ����̃��C���������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                PMCMN02001CA reportCtrl = PMCMN02001CA.GetInstance();
                reportCtrl.SetReportProps(ref prtRpt, PMCMN02001CA.SetReportPropsKind.NormalList);

                // ����f�[�^�擾
                DataView dv = (DataView)this._printInfo.rdData;

                // �\�[�g���ݒ�
                dv.Sort = this.GetPrintOderQuerry();

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
                                    this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "�����ꗗ�\", this._printInfo.prpnm,
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
        #endregion

        #region ���@ActiveReport���[�C���X�^���X�쐬�֘A
        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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
        /// <br>Note        : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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
        /// <br>Note        : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // �\�[�g���v���p�e�B�ݒ�
            string wrkstr = "";
            switch (this._demandExtraInfo.SortOrder)
            {
                case 0:
                    wrkstr = "[���Ӑ揇]";
                    break;
                case 1:
                    wrkstr = "[�S���ҏ�]";
                    break;
                case 2:
                    wrkstr = "[�n�揇]";
                    break;
                default:
                    break;
            }
            instance.PageHeaderSortOderTitle = wrkstr;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            status = this._demandPrintAcs.ReadPrtOutSet(out prtOutSet, out message);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        throw new DemandPrintException(message, status);
                    }
            }

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

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // ���̑��f�[�^
            bool isSection = (this._demandExtraInfo.IsOptSection && this._demandExtraInfo.IsMainOfficeFunc == true);
            ArrayList otherData = new ArrayList();
            otherData.Add(isSection);

            // �S�̍��ڕ\���ݒ�̎擾
            AlItmDspNm alItmDspNm = this._demandPrintAcs.GetAlItmDspNm();
            otherData.Add(alItmDspNm);

            instance.OtherDataList = otherData;

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
        /// <br>Note        : �o�͂��钊�o������������쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            // ���o�����w�b�_�[����
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            const string ct_Extr_Top = "�ŏ�����";
            const string ct_Extr_End = "�Ō�܂�";

            string target = "";

            string addUpADate = string.Empty;

            if (this._demandExtraInfo.AddUpDate == DateTime.MinValue)
            {
                addUpADate = "";
            }
            else
            {
                addUpADate = this._demandExtraInfo.AddUpDate.ToString("yyyy/MM/dd");
            }
            target = String.Format("�����F{0}�@����", addUpADate);
            this.EditCondition(ref addConditions, target);

            // �S���҃R�[�h
            switch (this._demandExtraInfo.CustomerAgentDivCd)
            {
                case 0:     // ���Ӑ�S��
                    {
                        if (this._demandExtraInfo.CustomerAgentCdSt.Trim() != "" || this._demandExtraInfo.CustomerAgentCdEd.Trim() != "")
                        {
                            string startEmpCode = "";
                            if (this._demandExtraInfo.CustomerAgentCdSt.Trim() == "")
                            {
                                startEmpCode = ct_Extr_Top;
                            }
                            else
                            {
                                startEmpCode = this._demandExtraInfo.CustomerAgentCdSt;
                            }

                            string endEmpCode = "";
                            if (this._demandExtraInfo.CustomerAgentCdEd.Trim() == "")
                            {
                                endEmpCode = ct_Extr_End;
                            }
                            else
                            {
                                endEmpCode = this._demandExtraInfo.CustomerAgentCdEd;
                            }

                            string title = "";
                            //title = "���Ӑ�S���҃R�[�h�F";
                            title = "���Ӑ�S���F";
                            target = title + startEmpCode + " �` " + endEmpCode;
                            this.EditCondition(ref addConditions, target);
                        }

                        break;
                    }
                case 1:     // �W���S��
                    {
                        if (this._demandExtraInfo.BillCollecterCdSt.Trim() != "" || this._demandExtraInfo.BillCollecterCdEd.Trim() != "")
                        {
                            string startEmpCode = "";
                            if (this._demandExtraInfo.BillCollecterCdSt.Trim() == "")
                            {
                                startEmpCode = ct_Extr_Top;
                            }
                            else
                            {
                                startEmpCode = this._demandExtraInfo.BillCollecterCdSt;
                            }

                            string endEmpCode = "";
                            if (this._demandExtraInfo.BillCollecterCdEd.Trim() == "")
                            {
                                endEmpCode = ct_Extr_End;
                            }
                            else
                            {
                                endEmpCode = this._demandExtraInfo.BillCollecterCdEd;
                            }

                            string title = "";
                            title = "�W���S���F";

                            target = title + startEmpCode + " �` " + endEmpCode;
                            this.EditCondition(ref addConditions, target);
                        }

                        break;
                    }
                default:
                    break;
            }

            // �n��
            if ((this._demandExtraInfo.SalesAreaCodeSt == 0) && (this._demandExtraInfo.SalesAreaCodeEd != 0))
            {
                target = "�n��: " + ct_Extr_Top + " �` " + this._demandExtraInfo.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._demandExtraInfo.SalesAreaCodeSt > 0) && (this._demandExtraInfo.SalesAreaCodeEd == 0))
            {
                target = "�n��: " + this._demandExtraInfo.SalesAreaCodeSt.ToString("d04") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._demandExtraInfo.SalesAreaCodeSt > 0) && (this._demandExtraInfo.SalesAreaCodeEd != 0))
            {
                target = "�n��: " + this._demandExtraInfo.SalesAreaCodeSt.ToString("d04") + " �` " + this._demandExtraInfo.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // ���Ӑ�R�[�h
            if (this._demandExtraInfo.CustomerCodeSt != 0 || this._demandExtraInfo.CustomerCodeEd != 0)
            {
                string startCode = "";
                if (this._demandExtraInfo.CustomerCodeSt == 0)
                {
                    startCode = ct_Extr_Top;
                }
                else
                {
                    startCode = this._demandExtraInfo.CustomerCodeSt.ToString("d08");
                }

                string endCode = "";
                if (this._demandExtraInfo.CustomerCodeEd == 0)
                {
                    endCode = ct_Extr_End;
                }
                else
                {
                    endCode = this._demandExtraInfo.CustomerCodeEd.ToString("d08");
                }
                target = "���Ӑ�F" + startCode + " �` " + endCode;
                this.EditCondition(ref addConditions, target);
            }

            // �������ڒǉ�
            foreach (string str in addConditions)
            {
                extraConditions.Add(str);
            }

        }

        /// <summary>
        /// ���o����������ҏW(�R�[�h�͈̔�)
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�͂��钊�o����������(�R�[�h�͈̔�)��ҏW���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string EditCodeRange(int startCd, int endCd)
        {
            string result = "";
            result = String.Format("{0} �` {1}", startCd.ToString(), endCd.ToString());
            return result;
        }

        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note        : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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
                    if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;

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

        #region ���@���ʃv���r���[���i�p�����[�^�ݒ�
        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
        {
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // �v�����^��
            commonInfo.PrinterName = this._printInfo.prinm;

            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;

            // �������
            commonInfo.PrintMax = ((DataView)this._printInfo.rdData).Count;

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

        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note        : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            // �󎚏��ݒ�
            switch (this._demandExtraInfo.SortOrder)
            {
                case 0:
                    {
                        // ���Ӑ揇(�������_�|�������Ӑ�|���ы��_�|���Ӑ揇)
                        oderQuerry = DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ClaimCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
                case 1:
                    {
                        // �S���ҏ�(���_�|�S���ҁ|���Ӑ揇)
                        string employeeKey = "";

                        if ((int)this._demandExtraInfo.CustomerAgentDivCd == 0)
                        {
                            // ���Ӑ�S��
                            employeeKey = DemandEBooksPrintAcs.CT_CsDmd_CustomerAgentCd;
                        }
                        else
                        {
                            // �W���S��
                            employeeKey = DemandEBooksPrintAcs.CT_CsDmd_BillCollecterCd;
                        }

                        // �S���ҏ�(�������_�|�S���ҁ|�������Ӑ�|���ы��_�|���Ӑ揇)
                        oderQuerry = DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + employeeKey + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ClaimCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
                case 2:
                    {
                        // �n�揇(�������_�|�n��|�������Ӑ�|���ы��_�|���Ӑ揇)
                        oderQuerry = DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_SalesAreaCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ClaimCode + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd + ","
                                   + DemandEBooksPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
            }

            return oderQuerry;
        }
        #endregion

        #region ���@�t�B���^�[�ݒ菈��
        /// <summary>
        /// �t�B���^�[�ݒ菈��
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note        : �������󂪗����̏ꍇ��DataView�ɐݒ肷��t�B���^�[��ǉ�����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string SelectTotalRecordOnlyFilter(string rowFilter)
        {
            string filter = "";

            // ���Ƀt�B���^�[�����݂��邩�H
            if (rowFilter.Trim().Length == 0)
            {
                // ���̃t�B���^�[����
                filter = String.Format("{0} = {1}",
                        DemandEBooksPrintAcs.CT_CsDmd_CustomerCode,
                        0);
            }
            else
            {
                // ���̃t�B���^�[�L��
                filter = String.Format("{0} AND {1} = {2}",
                        rowFilter,
                        DemandEBooksPrintAcs.CT_CsDmd_CustomerCode,
                        0);
            }

            return filter;
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
        /// <br>Note        : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult rst = TMsgDisp.Show(form, iLevel, "MAKAU03005P", iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return rst;
        }
        #endregion
        #endregion


    }
}
