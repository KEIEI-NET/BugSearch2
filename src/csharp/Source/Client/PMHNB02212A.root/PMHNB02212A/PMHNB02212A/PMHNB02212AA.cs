//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�A�N�Z�X�N���X
// �v���O�����T�v   : �ԕi���R�ꗗ�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ԕi���R�ꗗ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi���R�ꗗ�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.06.26</br>
    /// </remarks>
    public class RetGoodsReasonReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// �ԕi���R�ꗗ�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �ԕi���R�ꗗ�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        public RetGoodsReasonReportAcs()
		{
            this._iRetGoodsReasonReportResultDB = (IRetGoodsReasonReportResultDB)MediationRetGoodsReasonReportResultDB.GetRetGoodsReasonReportResultDB();
		}
        #endregion �� Constructor

        #region �� Private Member
        // �ԕi���R�ꗗ�����C���^�t�F�[�X
        IRetGoodsReasonReportResultDB _iRetGoodsReasonReportResultDB;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �ԕi���R�ꗗ�f�[�^�擾
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^�擾
        /// </summary>
        /// <param name="henbiRiyuListReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������ԕi���R�ꗗ�f�[�^���擾����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        public int SearchRetGoodsReasonReportProcMain(HenbiRiyuListReport henbiRiyuListReport, out string errMsg)
        {
            return this.SearchRetGoodsReasonReportProcProc(henbiRiyuListReport, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="henbiRiyuListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������ԕi���R�ꗗ�f�[�^���擾����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        private int SearchRetGoodsReasonReportProcProc(HenbiRiyuListReport henbiRiyuListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02215EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                RetGoodsReasonReportParaWork retGoodReasonReportparaWork = new RetGoodsReasonReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref henbiRiyuListReport, out retGoodReasonReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = retGoodReasonReportparaWork;
                status = _iRetGoodsReasonReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData], (ArrayList)retList, retGoodReasonReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMHNB02215EA.ct_Tbl_RetGoodsReasonReportData].Rows.Count < 1)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�ԕi���R�ꗗ�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �f�[�^�W�J����
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="henbiRiyuListReport">UI���o�����N���X</param>
        /// <param name="retGoodsReasonReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date	   : 2009.05.12</br>
        /// </remarks>
        private int SetCondInfo(ref HenbiRiyuListReport henbiRiyuListReport, out RetGoodsReasonReportParaWork retGoodsReasonReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            retGoodsReasonReportParaWork = new RetGoodsReasonReportParaWork();
            try
            {  
                // ��ƃR�[�h
                retGoodsReasonReportParaWork.EnterpriseCode = henbiRiyuListReport.EnterpriseCode; 
 
                // ���_
                if (henbiRiyuListReport.SectionCodes.Length != 0)
                {
                    if (henbiRiyuListReport.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        retGoodsReasonReportParaWork.SectionCodes = null;
                    }
                    else
                    {
                        retGoodsReasonReportParaWork.SectionCodes = henbiRiyuListReport.SectionCodes;
                    }
                }
                else
                {
                    retGoodsReasonReportParaWork.SectionCodes = null;
                }

                // ���Ӑ�R�[�h�i�J�n�j
                retGoodsReasonReportParaWork.CustomerCodeSt = henbiRiyuListReport.CustomerCodeSt;

                // ���Ӑ�R�[�h�i�I���j
                retGoodsReasonReportParaWork.CustomerCodeEd = henbiRiyuListReport.CustomerCodeEd;

                // �S���҃R�[�h�i�J�n�j
                retGoodsReasonReportParaWork.SalesEmployeeCdRFSt = henbiRiyuListReport.SalesEmployeeCdRFSt;

                // �S���҃R�[�h�i�I���j
                retGoodsReasonReportParaWork.SalesEmployeeCdRFEd = henbiRiyuListReport.SalesEmployeeCdRFEd;

                // �󒍎҃R�[�h�i�J�n�j
                retGoodsReasonReportParaWork.FrontEmployeeCdRFSt = henbiRiyuListReport.FrontEmployeeCdRFSt;

                // �󒍎҃R�[�h�i�I���j
                retGoodsReasonReportParaWork.FrontEmployeeCdRFEd = henbiRiyuListReport.FrontEmployeeCdRFEd;

                // ���s�҃R�[�h�i�J�n�j
                retGoodsReasonReportParaWork.SalesInputCdRFSt = henbiRiyuListReport.SalesInputCdRFSt;

                // ���s�҃R�[�h�i�I���j
                retGoodsReasonReportParaWork.SalesInputCdRFEd = henbiRiyuListReport.SalesInputCdRFEd;

                // �ԕi���R�R�[�h�i�J�n�j
                retGoodsReasonReportParaWork.RetGoodsReasonDivSt = henbiRiyuListReport.RetGoodsReasonDivSt;

                // �ԕi���R�R�[�h�i�I���j
                retGoodsReasonReportParaWork.RetGoodsReasonDivEd = henbiRiyuListReport.RetGoodsReasonDivEd;

                // �O����������i�J�n�j
                retGoodsReasonReportParaWork.PrevTotalDay = henbiRiyuListReport.PrevTotalDay;

                // �����������
                retGoodsReasonReportParaWork.CurrentTotalDay = henbiRiyuListReport.CurrentTotalDay;

                // �N�x�J�n��
                retGoodsReasonReportParaWork.StartYearDate = henbiRiyuListReport.StartYearDate;

                // �N�x�I����
                retGoodsReasonReportParaWork.EndYearDate = henbiRiyuListReport.EndYearDate;

                // �o�͏�
                retGoodsReasonReportParaWork.PrintType = henbiRiyuListReport.PrintType;

                //�`�[���
                retGoodsReasonReportParaWork.SlipKindCd = henbiRiyuListReport.SlipKindCd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        ///// <summary>
        ///// �N���擾�����iYYYYMM �� DateTime�j
        ///// </summary>
        ///// <param name="dateTime"></param>
        ///// <returns></returns>
        //private int GetYearMonthFromDateTime(DateTime dateTime)
        //{
        //    // �N����YYYYMM��int�ŕԂ�
        //    return (dateTime.Year * 100 + dateTime.Month);
        //}
        #endregion

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, RetGoodsReasonReportParaWork paraWork)
        {
            for (int i = 0; i < retList.Count; i++)
            {
                RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                DataRow dr = null;
                dr = dataTable.NewRow();
                // ���_�R�[�h
                dr[PMHNB02215EA.ct_Col_SectionCode] = rsltInfo.ResultsAddUpSecCd.PadLeft(2,'0');
                // ���_����
                dr[PMHNB02215EA.ct_Col_SectionName] = rsltInfo.SectionName;
                // ���Ӑ�R�[�h
                if (0 == rsltInfo.CustomerCode)
                {
                    dr[PMHNB02215EA.ct_Col_CustomerCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02215EA.ct_Col_CustomerCode] = rsltInfo.CustomerCode.ToString("D8");
                }
                // ���Ӑ於��
                dr[PMHNB02215EA.ct_Col_CustomerName] = rsltInfo.CustomerName;
                // �S���҃R�[�h
                dr[PMHNB02215EA.ct_Col_SalesEmployeeCd] = rsltInfo.SalesEmployeeCd.PadLeft(4, '0');
                // �S���Җ���
                dr[PMHNB02215EA.ct_Col_SalesEmployeeNm] = rsltInfo.SalesEmployeeNm;
                // �󒍎҃R�[�h
                dr[PMHNB02215EA.ct_Col_FrontEmployeeCd] = rsltInfo.FrontEmployeeCd.PadLeft(4, '0');
                // �󒍎Җ���
                dr[PMHNB02215EA.ct_Col_FrontEmployeeNm] = rsltInfo.FrontEmployeeNm;
                // ���s�҃R�[�h
                dr[PMHNB02215EA.ct_Col_SalesInputCode] = rsltInfo.SalesInputCode.PadLeft(4, '0');
                // ���s�Җ���
                dr[PMHNB02215EA.ct_Col_SalesInputName] = rsltInfo.SalesInputName;

                // �ԕi���R�R�[�h
                if (0 == rsltInfo.RetGoodsReasonDiv)
                {
                    dr[PMHNB02215EA.ct_Col_RetGoodsReasonDiv] = rsltInfo.RetGoodsReasonDiv.ToString("D4");
                    // �ԕi���R�R�[�h = 0 �ƕԕi���R���̂͋󔒂̏ꍇ
                    if (string.IsNullOrEmpty(rsltInfo.RetGoodsReason))
                    {
                        dr[PMHNB02215EA.ct_Col_RetGoodsReason] = "���o�^";
                    }
                    else
                    {
                        dr[PMHNB02215EA.ct_Col_RetGoodsReason] = rsltInfo.RetGoodsReason;
                    }
                }
                else
                {
                    dr[PMHNB02215EA.ct_Col_RetGoodsReasonDiv] = rsltInfo.RetGoodsReasonDiv;
                    // �ԕi���R����
                    dr[PMHNB02215EA.ct_Col_RetGoodsReason] = rsltInfo.RetGoodsReason;
                }
                // ���
                dr[PMHNB02215EA.ct_Col_SlipKind] = rsltInfo.SlipKind;
                // ���z
                dr[PMHNB02215EA.ct_Col_MoneySum] = rsltInfo.SalesTotalTaxExc;
                // ����
                dr[PMHNB02215EA.ct_Col_Count] = rsltInfo.Count;
                // �䗦
                int printType = paraWork.PrintType;
                CountRate(dr, retList, printType);
                // ����s�ԍ�
                SetSlipKey(dr, retList, printType);
                // �ڍ�
                SetDetailInfo(dr, retList, printType);

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        /// <summary>
        /// �䗦��ݒ菈��
        /// </summary>
        /// <param name="dr">�s�f�[�^</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="printType">�o�͏�</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void CountRate(DataRow dr, ArrayList retList, int printType)
        {   
            // ���z
            long currMoney = (long)dr[PMHNB02215EA.ct_Col_MoneySum];
            // �W�v���z(���Ӑ�v�A�S���Ҍv�A�󒍎Ҍv�A���s�Ҍv)
            long detailMoney =0;
            // �W�v���z(���_�v)
            long secMoney = 0;
            // �W�v���z(�����v)
            long sumMoney = 0;
            // �ԕi���R
            if (0 == printType)
            {
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // �W�v���z
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                        secMoney += rsltInfo.SalesTotalTaxExc; 
                    }
                }

            }
            // ���Ӑ�
            else if (1 == printType)
            {
                string customer = dr[PMHNB02215EA.ct_Col_CustomerCode].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // �W�v���z
                for (int i = 0; i < retList.Count; i++)
                {
                  RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                  string currCustomer = rsltInfo.CustomerCode.ToString("D8");
                  string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                  sumMoney += rsltInfo.SalesTotalTaxExc;
                  if (currCustomer.Equals(customer) && currSection.Equals(section))
                  {
                      detailMoney += rsltInfo.SalesTotalTaxExc;
                  }
                  if (currSection.Equals(section))
                  {
                      secMoney += rsltInfo.SalesTotalTaxExc;
                  }
                }

            }
            // �S����
            else if (2 == printType)
            {
                string salesEmployee = dr[PMHNB02215EA.ct_Col_SalesEmployeeCd].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // �W�v���z
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSalesEmployee = rsltInfo.SalesEmployeeCd.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSalesEmployee.Equals(salesEmployee) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // �󒍎�
            else if (3 == printType)
            {
                string frontEmployee = dr[PMHNB02215EA.ct_Col_FrontEmployeeCd].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // �W�v���z
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currFrontEmployee = rsltInfo.FrontEmployeeCd.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currFrontEmployee.Equals(frontEmployee) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // ���s��
            else if (4 == printType)
            {
                string salesInput = dr[PMHNB02215EA.ct_Col_SalesInputCode].ToString();
                string section = dr[PMHNB02215EA.ct_Col_SectionCode].ToString();
                // �W�v���z
                for (int i = 0; i < retList.Count; i++)
                {
                    RetGoodsReasonReportResultWork rsltInfo = (RetGoodsReasonReportResultWork)retList[i];
                    string currSalesInput = rsltInfo.SalesInputCode.PadLeft(4, '0');
                    string currSection = rsltInfo.ResultsAddUpSecCd.PadLeft(2, '0');
                    sumMoney += rsltInfo.SalesTotalTaxExc;
                    if (currSalesInput.Equals(salesInput) && currSection.Equals(section))
                    {
                        detailMoney += rsltInfo.SalesTotalTaxExc;
                    }
                    if (currSection.Equals(section))
                    {
                        secMoney += rsltInfo.SalesTotalTaxExc;
                    }
                }
            }
            // �䗦
            if (0 == currMoney || 0 == detailMoney)
            {
                dr[PMHNB02215EA.ct_Col_Rate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_Rate] = (double)((decimal)currMoney / (decimal)detailMoney * 100);
            }
            // �䗦(���Ӑ�v�A�S���Ҍv�A�󒍎Ҍv�A���s�Ҍv)
            if (0 == detailMoney || 0 == secMoney)
            {
                dr[PMHNB02215EA.ct_Col_DetailRate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_DetailRate] = (double)((decimal)detailMoney / (decimal)secMoney * 100);
            }
            // �䗦(���_�v)
            if (0 == secMoney || 0 == sumMoney)
            {
                dr[PMHNB02215EA.ct_Col_SectionRate] = 0;
            }
            else
            {
                dr[PMHNB02215EA.ct_Col_SectionRate] = (double)((decimal)secMoney / (decimal)sumMoney * 100);

            }
            
        }

        /// <summary>
        /// �L�[��ݒ菈��
        /// </summary>
        /// <param name="dr">�s�f�[�^</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="printType">�o�͏�</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void�@SetSlipKey(DataRow dr, ArrayList retList, int printType)
        {
            switch (printType)
            {
                case (0):// �ԕi���R
                    {
                        
                    }
                    break;
                case (1):// ���Ӑ�
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_CustomerCode].ToString().Trim();
                    }
                    break;
                case (2):// �S����
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_SalesEmployeeCd].ToString().Trim();
                    }
                    break;
                case (3):// �󒍎�
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_FrontEmployeeCd].ToString().Trim();
                    }
                    break;
                case (4):// ���s��
                    {
                        dr[PMHNB02215EA.ct_Col_SlipKey] = dr[PMHNB02215EA.ct_Col_SectionCode].ToString().Trim() + dr[PMHNB02215EA.ct_Col_SalesInputCode].ToString().Trim();
                    }
                    break;
            }

        }

        /// <summary>
        /// �o�͏��ɂ��ڍׂ�ݒ菈��
        /// </summary>
        /// <param name="dr">�s�f�[�^</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="printType">�o�͏�</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.05.11</br>
        /// </remarks>
        private void SetDetailInfo(DataRow dr, ArrayList retList, int printType)
        {
            switch (printType)
            {
                case (0):// �ԕi���R
                    {

                    }
                    break;
                case (1):// ���Ӑ�
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_CustomerCode];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_CustomerName];
                    }
                    break;
                case (2):// �S����
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_SalesEmployeeCd];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_SalesEmployeeNm];
                    }
                    break;
                case (3):// �󒍎�
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_FrontEmployeeCd];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_FrontEmployeeNm];
                    }
                    break;
                case (4):// ���s��
                    {
                        dr[PMHNB02215EA.ct_Col_DetailCode] = dr[PMHNB02215EA.ct_Col_SalesInputCode];
                        dr[PMHNB02215EA.ct_Col_DetailNm] = dr[PMHNB02215EA.ct_Col_SalesInputName];
                    }
                    break;
            }

        }

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
