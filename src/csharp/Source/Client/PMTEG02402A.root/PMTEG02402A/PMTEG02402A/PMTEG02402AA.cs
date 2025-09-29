//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ʗ\��\�A�N�Z�X�N���X
// �v���O�����T�v   : ��`���ʗ\��\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010.05.05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �C �� ��  2010.05.16  �C�����e : ��Q�Ή� redmin#7598 ��x��`��ʂ��󎚂�����A��`��ʂ��ύX�ɂȂ�܂ŁA�󎚂͕s�v�ł�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �C �� ��  2010.06.29  �C�����e : ��Q�Ή� redmin#10554��`���ʗ\��\�^�d�l���̓��e�ƈ󎚓��e���قȂ�
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
    /// ��`���ʗ\��\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ʗ\��\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : �I�M</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br>Update Note: 2010.05.16 �I�M ��Q�Ή�</br>
    /// <br>             redmin#7598 ��x��`��ʂ��󎚂�����A��`��ʂ��ύX�ɂȂ�܂ŁA�󎚂͕s�v�ł�</br>
    /// </remarks>
    public class TegataTsukibetsuYoteListReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`���ʗ\��\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`���ʗ\��\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataTsukibetsuYoteListReportAcs()
		{
            this._iTegataTsukibetsuYoteListReportResultDB = (ITegataTsukibetsuYoteListReportResultDB)MediationTegataTsukibetsuYoteListReportResultDB.GetTegataTsukibetsuYoteListReportResultDB();
		}
        #endregion �� Constructor

        #region �� Private Member
        // ��`���ʗ\��\�����C���^�t�F�[�X
        ITegataTsukibetsuYoteListReportResultDB _iTegataTsukibetsuYoteListReportResultDB;

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
        #region �� ��`���ʗ\��\�f�[�^�擾
        /// <summary>
        /// ��`���ʗ\��\�f�[�^�擾
        /// </summary>
        /// <param name="tegataTorihikisakiListReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`���ʗ\��\�f�[�^���擾����B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataTsukibetsuYoteListReportProcMain(TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out string errMsg)
        {
            return this.SearchTegataTsukibetsuYoteListReportProcProc(tegataTorihikisakiListReport, out errMsg);
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
        /// <br>Note       : ��������`���ʗ\��\�f�[�^���擾����B</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataTsukibetsuYoteListReportProcProc(TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02405EA.CreateDataTable(ref _dataSet);
                // ���o�����W�J  --------------------------------------------------------------
                TegataTsukibetsuYoteListReportParaWork tegataTorihikisakiListReportparaWork = new TegataTsukibetsuYoteListReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataTorihikisakiListReport, out tegataTorihikisakiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataTorihikisakiListReportparaWork;
                status = _iTegataTsukibetsuYoteListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02405EA.ct_Tbl_TegataTsukibetsuYoteListReportData], (ArrayList)retList, tegataTorihikisakiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02405EA.ct_Tbl_TegataTsukibetsuYoteListReportData].Rows.Count < 1)
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
                        errMsg = "��`���ʗ\��\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <br>Programmer : �I�M</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataTsukibetsuYoteListReport tegataTorihikisakiListReport, out TegataTsukibetsuYoteListReportParaWork tegataTorihikisakiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataTorihikisakiListReportParaWork = new TegataTsukibetsuYoteListReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataTorihikisakiListReportParaWork.EnterpriseCode = tegataTorihikisakiListReport.EnterpriseCode;

				// ��`�敪
				tegataTorihikisakiListReportParaWork.DraftDivide = tegataTorihikisakiListReport.DraftDivide;

                // ����͈͔N��
                tegataTorihikisakiListReportParaWork.SalesDate = tegataTorihikisakiListReport.SalesDate;

				// ����
				tegataTorihikisakiListReportParaWork.ChangePageDiv = tegataTorihikisakiListReport.ChangePageDiv;

				// �\�[�g��
				tegataTorihikisakiListReportParaWork.SortOrder = tegataTorihikisakiListReport.SortOrder;

				// ��s/�x�X�J�n
				tegataTorihikisakiListReportParaWork.BankAndBranchCdSt = tegataTorihikisakiListReport.BankAndBranchCdSt;

				// ��s/�x�X�I��
				tegataTorihikisakiListReportParaWork.BankAndBranchCdEd = tegataTorihikisakiListReport.BankAndBranchCdEd;

				// ��`���
				if (tegataTorihikisakiListReport.DraftKindCds.Length != 0)
				{
					tegataTorihikisakiListReportParaWork.DraftKindCds = tegataTorihikisakiListReport.DraftKindCds;
				}
				else
				{
					tegataTorihikisakiListReportParaWork.DraftKindCds = null;
				}

				// ��`��ʖ���
				tegataTorihikisakiListReportParaWork.DraftKindCdsHt = tegataTorihikisakiListReport.DraftKindCdsHt;

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
		/// <br>Programmer : �I�M</br>
		/// <br>Date       : 2010.05.05</br>
		/// <br>Update Note: 2010.05.16 �I�M ��x��`��ʂ��󎚂�����A��`��ʂ��ύX�ɂȂ�܂ŁA�󎚂͕s�v�ł�</br>
		/// </remarks>
		private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataTsukibetsuYoteListReportParaWork paraWork)
		{
			// ��`���+��s�x�X
			string nextDraftKindCd_BankAndBranchCd = string.Empty;
			// --- ADD 2010/05/16 -------------->>>>>
			// ��`���
			string nextDraftKindCd = string.Empty;
			// --- ADD 2010/05/16 --------------<<<<<
			// �w�茎
            int month = 0;

            // �i�J�n�����`�U�����ڕ��j�ƂU�����ȍ~�̍��v�l
            long[] sumMonthGokei = new long[7];

            DataRow dr = null;
            TegataTsukibetsuYoteListReportResultWork rsltInfo = null;

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataTsukibetsuYoteListReportResultWork)retList[i];

				// ��`��ʁA��s�x�X�A�L�������ŏW�v���s���󎚂���B
				if (!nextDraftKindCd_BankAndBranchCd.Equals(rsltInfo.DraftKindCd.ToString("D2")
							+ "|" + rsltInfo.BankAndBranchCd.ToString("D7")))
				{
					if (i != 0)
					{
						SetDataRow(ref dr, sumMonthGokei);
						dataTable.Rows.Add(dr);
					}
					nextDraftKindCd_BankAndBranchCd = rsltInfo.DraftKindCd.ToString("D2")
							+ "|" + rsltInfo.BankAndBranchCd.ToString("D7");
					dr = dataTable.NewRow();

					// ��`���
					dr[PMTEG02405EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                    // --- DEL 2010.06.29 Redmine#10554 ���` ---------->>>>>
					// --- ADD 2010/05/16 -------------->>>>>
					// �o�͏��͎�`��ʏ��@���@��`��ʕs�ς̏ꍇ
                    //if ((paraWork.SortOrder == 0) && (nextDraftKindCd.Equals(rsltInfo.DraftKindCd.ToString("D2"))))
                    //{
                    //    // ��`��ʖ���
                    //    dr[PMTEG02405EA.ct_Col_DraftKindName] = string.Empty;
                    //}
                    //else
                    //{
                    //// --- ADD 2010/05/16 --------------<<<<<
                    //    // ��`��ʖ���
                    //    dr[PMTEG02405EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd];
                    //}	//  ADD 2010/05/16 
                    // --- DEL 2010.06.29 Redmine#10554 ���` ----------<<<<<
                    dr[PMTEG02405EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd]; //ADD 2010.06.29 Redmine#10554 ���`
					// ��s�x�X
					dr[PMTEG02405EA.ct_Col_BankAndBranchCd] = rsltInfo.BankAndBranchCd.ToString("D7").Substring(0, 4)
						+ "-" + rsltInfo.BankAndBranchCd.ToString("D7").Substring(4, 3);
					// ��s�x�X����
					dr[PMTEG02405EA.ct_Col_BankAndBranchNm] = rsltInfo.BankAndBranchNm;

					sumMonthGokei = new long[7];
					nextDraftKindCd = rsltInfo.DraftKindCd.ToString("D2"); //  ADD 2010/05/16 
				}

				// �J�n����
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == (this.DateTimeToLongDateYM(paraWork.SalesDate)).ToString())
                {
                    sumMonthGokei[0] += rsltInfo.Deposit;
                }
                // �Q�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 1);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[1] += rsltInfo.Deposit;
                }
                // �R�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 2);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[2] += rsltInfo.Deposit;
                }
                // �S�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 3);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[3] += rsltInfo.Deposit; 
                }
                // �T�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 4);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[4] += rsltInfo.Deposit; 
                }
                // �U�����ڕ�
                month = this.CalculateYearMonth(this.DateTimeToLongDateYM(paraWork.SalesDate), 5);
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6) == month.ToString())
                {
                    sumMonthGokei[5] += rsltInfo.Deposit; 
                }
                // �U�����ȍ~��
                if (rsltInfo.ValidityTerm.ToString().Substring(0, 6).CompareTo(month.ToString()) > 0)
                {
                    sumMonthGokei[6] += rsltInfo.Deposit;
                }

                // �Ō�̃��R�[�h
                if (i == retList.Count - 1)
                {
                    SetDataRow(ref dr, sumMonthGokei);
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
        /// <remarks>
        /// <br>Note       : datarow�̐ݒ���s��</br>
        /// <br>Programmer : �I�M</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
		private void SetDataRow(ref DataRow dr, long[] sumMonthGokei)
		{
			// �J�n�����̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth1] = sumMonthGokei[0];
			// �Q�����ڕ��̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth2] = sumMonthGokei[1];
			// �R�����ڕ��̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth3] = sumMonthGokei[2];
			// �S�����ڕ��̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth4] = sumMonthGokei[3];
			// �T�����ڕ��̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth5] = sumMonthGokei[4];
			// �U�����ڕ��̍��v
			dr[PMTEG02405EA.ct_Col_SumMonth6] = sumMonthGokei[5];
			// �U�����ȍ~���̍��v
			dr[PMTEG02405EA.ct_Col_SumMonthSpare] = sumMonthGokei[6];
			// ���v
			dr[PMTEG02405EA.ct_Col_SumMonthAll] = sumMonthGokei[0] + sumMonthGokei[1] + sumMonthGokei[2] + sumMonthGokei[3] + sumMonthGokei[4] + sumMonthGokei[5] + sumMonthGokei[6];
		}

        /// <summary>
        /// LongDate DateTime �ϊ�����(YYYYMM)
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>LongDate(YYYYMM)</returns>
        /// <remarks>
        /// <br>Note       : DateTime����LongDate�ɕϊ����܂��B</br>
        /// <br>Programmer : �I�M</br>
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
        /// <br>Programmer : �I�M</br>
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
