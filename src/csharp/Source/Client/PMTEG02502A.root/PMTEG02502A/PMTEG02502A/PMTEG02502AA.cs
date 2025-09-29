//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�����ʕ\�A�N�Z�X�N���X
// �v���O�����T�v   : ��`�����ʕ\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��`�����ʕ\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�����ʕ\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class TegataTorihikisakiListReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`�����ʕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`�����ʕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        public TegataTorihikisakiListReportAcs()
		{
            this._iTegataTorihikisakiListReportResultDB = (ITegataTorihikisakiListReportResultDB)MediationTegataTorihikisakiListReportResultDB.GetTegataTorihikisakiListReportResultDB();
		}
        #endregion �� Constructor

        #region �� Private Member
        // ��`�����ʕ\�����C���^�t�F�[�X
        ITegataTorihikisakiListReportResultDB _iTegataTorihikisakiListReportResultDB;

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
        #region �� ��`�����ʕ\�f�[�^�擾
        /// <summary>
        /// ��`�����ʕ\�f�[�^�擾
        /// </summary>
        /// <param name="tegataTorihikisakiListReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�����ʕ\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        public int SearchTegataTorihikisakiListReportProcMain(TegataTorihikisakiListReport tegataTorihikisakiListReport, out string errMsg)
        {
            return this.SearchTegataTorihikisakiListReportProcProc(tegataTorihikisakiListReport, out errMsg);
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
        /// <param name="tegataTorihikisakiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�����ʕ\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        private int SearchTegataTorihikisakiListReportProcProc(TegataTorihikisakiListReport tegataTorihikisakiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02505EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                TegataTorihikisakiListReportParaWork tegataTorihikisakiListReportparaWork = new TegataTorihikisakiListReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataTorihikisakiListReport, out tegataTorihikisakiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataTorihikisakiListReportparaWork;
                status = _iTegataTorihikisakiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02505EA.ct_Tbl_TegataTorihikisakiListReportData], (ArrayList)retList, tegataTorihikisakiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02505EA.ct_Tbl_TegataTorihikisakiListReportData].Rows.Count < 1)
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
                        errMsg = "��`�����ʕ\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="tegataTorihikisakiListReport">UI���o�����N���X</param>
        /// <param name="tegataTorihikisakiListReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.21</br>
        /// </remarks>
        private int SetCondInfo(ref TegataTorihikisakiListReport tegataTorihikisakiListReport, out TegataTorihikisakiListReportParaWork tegataTorihikisakiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataTorihikisakiListReportParaWork = new TegataTorihikisakiListReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataTorihikisakiListReportParaWork.EnterpriseCode = tegataTorihikisakiListReport.EnterpriseCode; 
 
                // ���_
                if (tegataTorihikisakiListReport.SectionCodes.Length != 0)
                {
                    if (tegataTorihikisakiListReport.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        tegataTorihikisakiListReportParaWork.SectionCodes = null;
                    }
                    else
                    {
                        tegataTorihikisakiListReportParaWork.SectionCodes = tegataTorihikisakiListReport.SectionCodes;
                    }
                }
                else
                {
                    tegataTorihikisakiListReportParaWork.SectionCodes = null;
                }

                // �����R�[�h�i�J�n�j
                tegataTorihikisakiListReportParaWork.CustomerCodeSt = tegataTorihikisakiListReport.CustomerCodeSt;

                // �����R�[�h�i�I���j
                tegataTorihikisakiListReportParaWork.CustomerCodeEd = tegataTorihikisakiListReport.CustomerCodeEd;

                // ����͈͔N��
                tegataTorihikisakiListReportParaWork.SalesDate = tegataTorihikisakiListReport.SalesDate;

                // ����^�C�v
                tegataTorihikisakiListReportParaWork.PrintType = tegataTorihikisakiListReport.PrintType;

                // ��`�敪
                tegataTorihikisakiListReportParaWork.DraftDivide = tegataTorihikisakiListReport.DraftDivide;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
        /// <br>Note       : DataTable�Ƀf�[�^��ݒ菈�����s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataTorihikisakiListReportParaWork paraWork)
        {
            string nextCustomerCode = string.Empty;
            // �w�茎
            int month = 0;

            // �i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l
            long[] sumMonthGokei = new long[7];
            // �i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l(��`�敪���u0�F���U�v)
            long[] sumMonthSelf = new long[7];
            // �i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l(��`�敪���u1�F���U�v)
            long[] sumMonthElse = new long[7];

            DataRow dr = null;
            TegataTorihikisakiListReportResultWork rsltInfo = null;
            // �����R�[�h
            string customerCode = null;
            string formatStr = null;
            // ����`
            if (paraWork.DraftDivide == 0)
            {
                formatStr = "D8";
            }
            // �x����`
            else
            {
                formatStr = "D6";
            }

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataTorihikisakiListReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);

                // ���_�R�[�h�A���Ӑ�R�[�h�A�L�������ŏW�v���s���󎚂���B
                if (!nextCustomerCode.Equals(rsltInfo.SectionCode.Trim().PadLeft(2, '0') + "-" + customerCode))
                {
                    if (i != 0)
                    {
                        SetDataRow(ref dr, sumMonthGokei, sumMonthSelf, sumMonthElse);
                        dataTable.Rows.Add(dr);
                    }
                    nextCustomerCode = rsltInfo.SectionCode.Trim().PadLeft(2, '0') + "-" + customerCode;
                    dr = dataTable.NewRow();

                    // ���_�R�[�h
                    dr[PMTEG02505EA.ct_Col_SectionCode] = rsltInfo.SectionCode.PadLeft(2, '0');
                    // �����R�[�h
                    if (0 == rsltInfo.CustomerCode)
                    {
                        dr[PMTEG02505EA.ct_Col_CustomerCode] = string.Empty;
                    }
                    else
                    {
                        dr[PMTEG02505EA.ct_Col_CustomerCode] = nextCustomerCode;
                    }
                    // ����於��
                    dr[PMTEG02505EA.ct_Col_CustomerName] = rsltInfo.CustomerSnm;

                    sumMonthGokei = new long[7];
                    sumMonthSelf = new long[7];
                    sumMonthElse = new long[7];
                }

                // �J�n����
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == (this.DateTimeToLongDateYM(paraWork.SalesDate)).ToString())
                {
                    sumMonthGokei[0] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0) 
                        sumMonthSelf[0] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[0] += rsltInfo.Deposit; 
                }
                // �Q�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[1] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[1] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[1] += rsltInfo.Deposit; 
                }
                // �R�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[2] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[2] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[2] += rsltInfo.Deposit; 
                }
                // �S�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[3] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[3] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[3] += rsltInfo.Deposit; 
                }
                // �T�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[4] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[4] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[4] += rsltInfo.Deposit; 
                }
                // �U�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[5] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[5] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[5] += rsltInfo.Deposit; 
                }
                // �U�����ȍ~��
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6).CompareTo(month.ToString()) > 0)
                {
                    sumMonthGokei[6] += rsltInfo.Deposit;
                    if (rsltInfo.DraftDivide == 0)
                        sumMonthSelf[6] += rsltInfo.Deposit;
                    else if (rsltInfo.DraftDivide == 1)
                        sumMonthElse[6] += rsltInfo.Deposit; 
                }

                // �Ō�̃��R�[�h
                if (i == retList.Count - 1)
                {
                    SetDataRow(ref dr, sumMonthGokei, sumMonthSelf, sumMonthElse);
                    dataTable.Rows.Add(dr);
                }
            }
        }
        #endregion
        
        /// <summary>
        /// datarow�̐ݒ�
        /// </summary>
        /// <param name="dr">�s�f�[�^</param>
        /// <param name="sumMonthGokei">�i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l</param>
        /// <param name="sumMonthSelf">�i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l(��`�敪���u0�F���U�v)</param>
        /// <param name="sumMonthElse">�i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l(��`�敪���u1�F���U�v)</param>
        /// <remarks>
        /// <br>Note       : datarow�̐ݒ���s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private void SetDataRow(ref DataRow dr, long[] sumMonthGokei, long[] sumMonthSelf, long[] sumMonthElse)
        {
            // �J�n�����̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth1] = sumMonthGokei[0];
            // �Q�����ڕ��̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth2] = sumMonthGokei[1];
            // �Q�����ڕ��̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth3] = sumMonthGokei[2];
            // �Q�����ڕ��̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth4] = sumMonthGokei[3];
            // �Q�����ڕ��̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth5] = sumMonthGokei[4];
            // �Q�����ڕ��̍��v
            dr[PMTEG02505EA.ct_Col_SumMonth6] = sumMonthGokei[5];
            // �U�����ȍ~���̍��v
            dr[PMTEG02505EA.ct_Col_SumMonthSpare] = sumMonthGokei[6];
            // ���v
            dr[PMTEG02505EA.ct_Col_SumMonthAll] = sumMonthGokei[0] + sumMonthGokei[1] + sumMonthGokei[2] + sumMonthGokei[3] + sumMonthGokei[4] + sumMonthGokei[5] + sumMonthGokei[6];

            // �J�n�����̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth1Self] = sumMonthSelf[0];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth2Self] = sumMonthSelf[1];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth3Self] = sumMonthSelf[2];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth4Self] = sumMonthSelf[3];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth5Self] = sumMonthSelf[4];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth6Self] = sumMonthSelf[5];
            // �U�����ȍ~���̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonthSpareSelf] = sumMonthSelf[6];
            // ���v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonthAllSelf] = sumMonthSelf[0] + sumMonthSelf[1] + sumMonthSelf[2] + sumMonthSelf[3] + sumMonthSelf[4] + sumMonthSelf[5] + sumMonthSelf[6];

            // �J�n�����̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth1Else] = sumMonthElse[0];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth2Else] = sumMonthElse[1];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth3Else] = sumMonthElse[2];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth4Else] = sumMonthElse[3];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth5Else] = sumMonthElse[4];
            // �Q�����ڕ��̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonth6Else] = sumMonthElse[5];
            // �U�����ȍ~���̍��v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonthSpareElse] = sumMonthElse[6];
            // ���v(���U)
            dr[PMTEG02505EA.ct_Col_SumMonthAllElse] = sumMonthElse[0] + sumMonthElse[1] + sumMonthElse[2] + sumMonthElse[3] + sumMonthElse[4] + sumMonthElse[5] + sumMonthElse[6];
        }

        /// <summary>
        /// LongDate DateTime �ϊ�����(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTime����LongDate�ɕϊ����܂��B</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int DateTimeToLongDateYM(DateTime dt)
        {
            return TDateTime.DateTimeToLongDate("YYYYMM", dt);
        }

        /// <summary>
        /// �N���v�Z����
        /// </summary>
        /// <param name="yearMonth">�v�Z�O�N��</param>
        /// <param name="monthes">���Z(���Z)����</param>
        /// <returns>�v�Z��N��</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������Z�����N����Ԃ��܂��B</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int CalculateYearMonth(int yearMonth, int monthes)
        {
            int resultYearMonth = 0;

            // ��U���ɕϊ�
            int wkMonth = (yearMonth / 100) * 12 + (yearMonth % 100) - 1;

            // ���Z(���Z)�����𔽉f
            wkMonth += monthes;

            // �N���ɖ߂�
            resultYearMonth = (wkMonth / 12) * 100 + wkMonth % 12 + 1;

            return resultYearMonth;
        }

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
