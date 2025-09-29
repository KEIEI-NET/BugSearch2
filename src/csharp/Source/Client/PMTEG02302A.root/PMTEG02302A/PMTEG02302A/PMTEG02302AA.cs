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
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
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
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataKibiListReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`�����ʕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`�����ʕ\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataKibiListReportAcs()
		{
            this._iTegataKibiListReportResultDB = (ITegataKibiListReportResultDB)MediationTegataKibiListReportResultDB.GetTegataKibiListReportResultDB();
		}
        #endregion �� Constructor

        #region �� Private Member
        // ��`�����ʕ\�����C���^�t�F�[�X
        ITegataKibiListReportResultDB _iTegataKibiListReportResultDB;

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
        /// <param name="TegataKibiListReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�����ʕ\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataKibiListReportProcMain(TegataKibiListReport tegataKibiListReport, out string errMsg)
        {
            return this.SearchTegataKibiListReportProcProc(tegataKibiListReport, out errMsg);
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
        /// <param name="TegataKibiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�����ʕ\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataKibiListReportProcProc(TegataKibiListReport tegataKibiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02305EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                TegataKibiListReportParaWork tegataKibiListReportparaWork = new TegataKibiListReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataKibiListReport, out tegataKibiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataKibiListReportparaWork;
                status = _iTegataKibiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02305EA.ct_Tbl_TegataKibiListReportData], (ArrayList)retList, tegataKibiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02305EA.ct_Tbl_TegataKibiListReportData].Rows.Count < 1)
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
        /// <param name="TegataKibiListReport">UI���o�����N���X</param>
        /// <param name="TegataKibiListReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataKibiListReport tegataKibiListReport, out TegataKibiListReportParaWork tegataKibiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataKibiListReportParaWork = new TegataKibiListReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataKibiListReportParaWork.EnterpriseCode = tegataKibiListReport.EnterpriseCode;

                // ��s/�x�X�J�n
                tegataKibiListReportParaWork.BankAndBranchCdSt = tegataKibiListReport.BankAndBranchCdSt;

                // ��s/�x�X�I��
                tegataKibiListReportParaWork.BankAndBranchCdEd = tegataKibiListReport.BankAndBranchCdEd;

                // ����͈͔N��
                tegataKibiListReportParaWork.SalesDate = tegataKibiListReport.SalesDate;

                // ��`���
                if (tegataKibiListReport.DraftKindCds.Length != 0)
                {
                    tegataKibiListReportParaWork.DraftKindCds = tegataKibiListReport.DraftKindCds;
                }
                else
                {
                    tegataKibiListReportParaWork.DraftKindCds = null;
                }

                // ��`��ʖ���
                tegataKibiListReportParaWork.DraftKindCdsHt = tegataKibiListReport.DraftKindCdsHt;

                // ��`�敪
                tegataKibiListReportParaWork.DraftDivide = tegataKibiListReport.DraftDivide;
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
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataKibiListReportParaWork paraWork)
        {
            // �w�茎
            int month = 0;
            // �L������
            string validityTermStr = null;

            // �i�J�n�����`�U�����ڕ��j�̍��v�l
            long[,] sumMonthGokei = new long[6, 31];
            // �i�J�n�����`�U�����ڕ��j�̌������v
            long[,] countMonthGokei = new long[6, 31];

            DataRow dr = null;
            DataRow drNew = null;
            TegataKibiListReportResultWork rsltInfo = null;
            // ��s/�x�X�R�[�h
            string bankAndBranchCd = string.Empty;
            // ��`��ʃR�[�h
            int draftKindCd = 0;

            // ���y�[�W�R�[�h
            string nextPageDiv = string.Empty;

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataKibiListReportResultWork)retList[i];
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");
                draftKindCd = rsltInfo.DraftKindCd;

                // ��`��ʁA��s�E�x�X�R�[�h�A�L�������ŏW�v���s���󎚂���B
                if (!nextPageDiv.Equals(draftKindCd + "\\&" + bankAndBranchCd))
                {
                    if (i != 0)
                    {
                        for (int k = 0; k < 31; k++) 
                        {
                            drNew = dataTable.NewRow();
                            drNew[PMTEG02305EA.ct_Col_DraftKindName] = dr[PMTEG02305EA.ct_Col_DraftKindName];
                            drNew[PMTEG02305EA.ct_Col_BankAndBranchNm] = dr[PMTEG02305EA.ct_Col_BankAndBranchNm];
                            drNew[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode];
                            SetDataRow(ref drNew, k, sumMonthGokei, countMonthGokei);
                            dataTable.Rows.Add(drNew);
                        }
                    }
                    nextPageDiv = draftKindCd + "\\&" + bankAndBranchCd;
                    dr = dataTable.NewRow();
                    // ��`���
                    dr[PMTEG02305EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[draftKindCd];
                    // ��s�x�X
                    dr[PMTEG02305EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                        + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                    // ��`��� + ��s�x�X
                    dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = nextPageDiv;

                    sumMonthGokei = new long[6, 31];
                    countMonthGokei = new long[6, 31];
                }

                validityTermStr = rsltInfo.ValidityTerm.ToString();
                // �J�n����
                month = this.DateTimeToLongDateYM(paraWork.SalesDate);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[0, j] += rsltInfo.Deposit;
                            countMonthGokei[0, j] += 1;
                        }
                    }
                }
                // �Q�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[1, j] += rsltInfo.Deposit;
                            countMonthGokei[1, j] += 1;
                        }
                    }
                }
                // �R�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[2, j] += rsltInfo.Deposit;
                            countMonthGokei[2, j] += 1;
                        }
                    }
                }
                // �S�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[3, j] += rsltInfo.Deposit;
                            countMonthGokei[3, j] += 1;
                        }
                    }
                }
                // �T�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[4, j] += rsltInfo.Deposit;
                            countMonthGokei[4, j] += 1;
                        }
                    }
                }
                // �U�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (validityTermStr.Substring(0, 6) == month.ToString())
                {
                    // �O�P���`�R�P���ɕ����āA�W�v����
                    for (int j = 0; j < 31; j++)
                    {
                        if (validityTermStr == validityTermStr.Substring(0, 6) + (j + 1).ToString().PadLeft(2, '0'))
                        {
                            sumMonthGokei[5, j] += rsltInfo.Deposit;
                            countMonthGokei[5, j] += 1;
                        }
                    }
                }

                // �Ō�̃��R�[�h
                if (i == retList.Count - 1)
                {
                    for (int k = 0; k < 31; k++)
                    {
                        drNew = dataTable.NewRow();
                        drNew[PMTEG02305EA.ct_Col_DraftKindName] = dr[PMTEG02305EA.ct_Col_DraftKindName];
                        drNew[PMTEG02305EA.ct_Col_BankAndBranchNm] = dr[PMTEG02305EA.ct_Col_BankAndBranchNm];
                        drNew[PMTEG02305EA.ct_Col_DraftKindAndBankCode] = dr[PMTEG02305EA.ct_Col_DraftKindAndBankCode];
                        SetDataRow(ref drNew, k, sumMonthGokei, countMonthGokei);
                        dataTable.Rows.Add(drNew);
                    }
                }
            }
        }
        #endregion
        
        /// <summary>
        /// datarow�̐ݒ�
        /// </summary>
        /// <param name="dr">�s�f�[�^</param>
        /// <param name="k">���t�̃C���f�b�N�X</param>
        /// <param name="sumMonthGokei">�i�J�n�����`�U�����ڕ��j�̍��v�l</param>
        /// <param name="countMonthGokei">�i�J�n�����`�U�����ڕ��j�̌������v</param>
        /// <remarks>
        /// <br>Note       : datarow�̐ݒ���s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void SetDataRow(ref DataRow dr, int k, long[,] sumMonthGokei, long[,] countMonthGokei)
        {

            // ���t
            dr[PMTEG02305EA.ct_Col_Day] = (k + 1).ToString().PadLeft(2, '0');

            // �J�n�����̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth1] = sumMonthGokei[0, k];
            // �Q�����ڕ��̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth2] = sumMonthGokei[1, k];
            // �R�����ڕ��̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth3] = sumMonthGokei[2, k];
            // �S�����ڕ��̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth4] = sumMonthGokei[3, k];
            // �T�����ڕ��̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth5] = sumMonthGokei[4, k];
            // �U�����ڕ��̍��v
            dr[PMTEG02305EA.ct_Col_SumMonth6] = sumMonthGokei[5, k];

            // �J�n�����̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth1] = countMonthGokei[0, k];
            // �Q�����ڕ��̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth2] = countMonthGokei[1, k];
            // �R�����ڕ��̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth3] = countMonthGokei[2, k];
            // �S�����ڕ��̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth4] = countMonthGokei[3, k];
            // �T�����ڕ��̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth5] = countMonthGokei[4, k];
            // �U�����ڕ��̌������v
            dr[PMTEG02305EA.ct_Col_CountMonth6] = countMonthGokei[5, k];
        }

        /// <summary>
        /// LongDate DateTime �ϊ�����(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTime����LongDate�ɕϊ����܂��B</br>
        /// <br>Programmer : wangkq</br>
        /// <br>Date       : 2010.05.05</br>
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
        /// <br>Date       : 2010.05.05</br>
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
