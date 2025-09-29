//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/27  �C�����e : Redmine ��Q�� #23232 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/08/03  �C�����e : Redmine ��Q�� #23232 �̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Reflection;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �L�����y�[�����ѕ\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �L�����y�[�����ѕ\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2011/05/19</br>
    /// <br>Update Note : 2011/07/27 ����</br>
    /// <br>            : Redmine ��Q�� #23232 �̑Ή�</br>
    /// <br>Update Note : 2011/08/03 yangmj</br>
    /// <br>            : Redmine ��Q�� #23232 �̑Ή�</br>
    /// </remarks>
	public class CampaignRsltListAcs
	{
		#region �� Constructor
		/// <summary>
		/// �L�����y�[�����ѕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : �c����</br>
	    /// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public CampaignRsltListAcs()
		{
			this._iCampaignRsltListResultDB = (ICampaignRsltListResultDB)MediationCampaignRsltListResultDB.GetCampaignRsltListResultDB();

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
		}

		/// <summary>
		/// �L�����y�[�����ѕ\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : �c����</br>
	    /// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static CampaignRsltListAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion �� Constructor

		#region �� Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
		#endregion �� Static Member

		#region �� Private Member
		ICampaignRsltListResultDB _iCampaignRsltListResultDB;

        private DataTable _campaignRsltListDt;			// ���DataTable
        private DataView _campaignRsltListView;	        // ���DataView

        private CampaignTargetValue _dictionaryCampTarget;  // Dictionary��Value�p�N���X
        private Dictionary<string, CampaignTargetValue> _totalDic = new Dictionary<string, CampaignTargetValue>();

        private const string ctSalesTargetMoney = "SalesTargetMoney";   // ����ڕW���z
        private const string ctSalesTargetProfit = "SalesTargetProfit"; // ����ڕW�e���z
        private const string ctSalesTargetCount = "SalesTargetCount";   // ����ڕW����

        //���t�擾���i
        private DateGetAcs _dateGet;

		#endregion �� Private Member

		#region �� Public Property
		/// <summary>
		/// ����f�[�^�Z�b�g(�ǂݎ���p)
		/// </summary>
        public DataView CampaignView
		{
            get { return this._campaignRsltListView; }
		}
		#endregion �� Public Property

		#region �� Private Method
        /// <summary>
        /// ���擾����
        /// </summary>
        /// <param name="numerator">���q</param>
        /// <param name="denominator">����</param>
        /// <remarks>
        /// <br>Note       : ���擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private double GetRatio(object numerator, object denominator)
        {
            double workRate;
            double numeratorD = Convert.ToDouble(numerator);
            double denominatorD = Convert.ToDouble(denominator);

            if (denominatorD == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numeratorD / denominatorD) * 100;
            }

            return workRate;
        }

        #region [ReadPrtOutSet]
        /// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>status</returns>
		/// <remarks>
        /// <br>Note       : ���[�o�͐ݒ�Ǎ����s���܂��B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = string.Empty;	

			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
        }

        #endregion [ReadPrtOutSet]

        #region [���o����] 
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="campaignRsltList">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�擾���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public int SeachCampaignMain(CampaignRsltList campaignRsltList, out string errMsg)
        {
            return SeachCampaignMainProc(campaignRsltList, out errMsg);
        }

        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="campaignRsltList">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�擾���s���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int SeachCampaignMainProc(CampaignRsltList campaignRsltList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKHN02054EA.CreateDataTable(ref this._campaignRsltListDt);

                // ���o�����W�J  --------------------------------------------------------------
                CampaignstRsltListPrtWork paramWork = new CampaignstRsltListPrtWork();
                status = this.DevSalesDayMonthReport(campaignRsltList, out paramWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object campaignstSalseWork = null;
                object campaignstTargetWork = null;

                status = this._iCampaignRsltListResultDB.Search(out campaignstSalseWork, out campaignstTargetWork, paramWork);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList resultLst = new ArrayList();
                            ArrayList salesLst = new ArrayList();
                            ArrayList campaignstSalesWorkLst = (ArrayList)campaignstSalseWork;
                            ArrayList campaignstTargetWorkLst = (ArrayList)campaignstTargetWork;
                            if (campaignstSalesWorkLst == null || campaignstTargetWorkLst == null || campaignstSalesWorkLst.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }
                            // ����f�[�^�̍��v
                            SumSalesData(campaignstSalesWorkLst, campaignRsltList, ref salesLst);
                            if (salesLst.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                                break;
                            }

                            // �f�[�^���o����
                            SetDataFrmTargetToSales(salesLst, campaignstTargetWorkLst, campaignRsltList, out resultLst);

                            // �f�[�^�W�J����
                            DevStockMoveData(campaignRsltList, resultLst);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "���㖾�׃f�[�^�̎擾�Ɏ��s���܂����B";
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

        #endregion [���o����]

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <param name="paramWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int DevSalesDayMonthReport(CampaignRsltList campaignRsltList, out CampaignstRsltListPrtWork paramWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            paramWork = new CampaignstRsltListPrtWork();

            try
            {
                paramWork.TotalType = (int)campaignRsltList.TotalType;                   // �W�v�P��(0:���i�� 1:���Ӑ�� 2:�S���ҕ�)
                paramWork.EnterpriseCode = campaignRsltList.EnterpriseCode;              // ��ƃR�[�h
                paramWork.CampaignCode = campaignRsltList.CampaignCode;                  // �L�����y�[���R�[�h
                paramWork.SectionCodes = campaignRsltList.SectionCodes;                  // ���_�R�[�h
                paramWork.ApplyStaDate = campaignRsltList.ApplyStaDate;                  // �K�p�J�n��
                paramWork.ApplyEndDate = campaignRsltList.ApplyEndDate;                  // �K�p�I����

                paramWork.PrintType = campaignRsltList.PrintType;                        // ����^�C�v

                paramWork.AddUpYearMonthSt = campaignRsltList.AddUpYearMonthSt;          // �J�n�Ώ۔N��
                paramWork.AddUpYearMonthEd = campaignRsltList.AddUpYearMonthEd;          // �I���Ώ۔N��
                paramWork.AddUpYearMonthDaySt = campaignRsltList.AddUpYearMonthDaySt;    // �J�n�Ώ۔N��
                paramWork.AddUpYearMonthDayEd = campaignRsltList.AddUpYearMonthDayEd;    // �I���Ώ۔N��

                paramWork.Detail = campaignRsltList.Detail;                              // ���גP��
                paramWork.Total = campaignRsltList.Total;                                // ���v�P��
                paramWork.OutputSort = campaignRsltList.OutputSort;                      // �o�͏�

                paramWork.EmployeeCodeSt = campaignRsltList.EmployeeCodeSt;              // �J�n�S����
                paramWork.EmployeeCodeEd = campaignRsltList.EmployeeCodeEd;              // �I���S����

                paramWork.AcceptOdrCodeSt = campaignRsltList.AcceptOdrCodeSt;            // �J�n�󒍎�
                paramWork.AcceptOdrCodeEd = campaignRsltList.AcceptOdrCodeEd;            // �I���󒍎�

                paramWork.PrinterCodeSt = campaignRsltList.PrinterCodeSt;                // �J�n���s��
                paramWork.PrinterCodeEd = campaignRsltList.PrinterCodeEd;                // �I�����s��

                paramWork.CustomerCodeSt = campaignRsltList.CustomerCodeSt;              // ���Ӑ�R�[�h
                paramWork.CustomerCodeEd = campaignRsltList.CustomerCodeEd;              // ���Ӑ�R�[�h

                paramWork.AreaCodeSt = campaignRsltList.AreaCodeSt;                      // �n��J�n�R�[�h
                paramWork.AreaCodeEd = campaignRsltList.AreaCodeEd;                      // �n��I���R�[�h

                paramWork.GoodsMakerCdSt = campaignRsltList.GoodsMakerCdSt;�@�@�@�@�@�@�@// �J�n���i���[�J�[
                paramWork.GoodsMakerCdEd = campaignRsltList.GoodsMakerCdEd;�@�@�@�@�@�@�@// �I�����i���[�J�[

                paramWork.GoodsNoSt = campaignRsltList.GoodsNoSt;                        // �J�n�i��
                paramWork.GoodsNoEd = campaignRsltList.GoodsNoEd;                        // �I���i��

                paramWork.BLGoodsCodeSt = campaignRsltList.BLGoodsCodeSt;                // �J�nBL�R�[�h
                paramWork.BLGoodsCodeEd = campaignRsltList.BLGoodsCodeEd;                // �I��BL�R�[�h

                paramWork.BLGroupCodeSt = campaignRsltList.BLGroupCodeSt;                // �J�n�O���[�v�R�[�h
                paramWork.BLGroupCodeEd = campaignRsltList.BLGroupCodeEd;                // �I���O���[�v�R�[�h

                paramWork.SalesCodeSt = campaignRsltList.SalesCodeSt;                    // �J�n�̔��敪�R�[�h
                paramWork.SalesCodeEd = campaignRsltList.SalesCodeEd;                    // �I���̔��敪�R�[�h
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// ����f�[�^�̍��v
        /// </summary>
        /// <param name="salesList">�擾�̔���f�[�^</param>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <param name="resultLst">���ʃf�[�^</param>
        /// <remarks>
        /// <br>Note       : ����f�[�^�̍��v���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// <br>Update Note: 2011/07/27 ����</br>
        /// <br>           : Redmine ��Q�� #23232 �̑Ή�</br>
        /// <br>Update Note: 2011/08/03 yangmj</br>
        /// <br>           : Redmine ��Q�� #23232 �̑Ή�</br>
        /// </remarks>
        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
        //private void SumSalesData(ArrayList salesList, CampaignRsltList campaignRsltList, ref ArrayList resultLst)
        private void SumSalesData(ArrayList salesList, CampaignRsltList campaignRsltList, ref ArrayList dataList)
        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
        {
            string workKey = string.Empty;
            string compKey = string.Empty;
            string makerCode = string.Empty;
            CampaignstRsltListResultWork work = new CampaignstRsltListResultWork();
            int monthCnt = GetTermMonthCount(campaignRsltList);
            Dictionary<string, DateTerm> dic = new Dictionary<string,DateTerm>();
            ArrayList resultLst = new ArrayList(); // ADD 2011/07/27

            // ����^�C�v�F����
            if (campaignRsltList.PrintType == 1)
            {
                DateTime monthSt = campaignRsltList.AddUpYearMonthSt;

                while (monthSt <= campaignRsltList.AddUpYearMonthEd)
                {
                    DateTime startDate = DateTime.MinValue;
                    DateTime endDate = DateTime.MinValue;
                    this._dateGet.GetDaysFromMonth(monthSt, out startDate, out endDate);

                    if (TDateTime.DateTimeToLongDate(endDate) < campaignRsltList.ApplyStaDate || TDateTime.DateTimeToLongDate(startDate) > campaignRsltList.ApplyEndDate)
                    {
                        monthSt = monthSt.AddMonths(1);
                        continue;
                    }

                    // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                    //if (TDateTime.DateTimeToLongDate(startDate) < campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(endDate) > campaignRsltList.ApplyStaDate)
                    if (TDateTime.DateTimeToLongDate(startDate) <= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(endDate) >= campaignRsltList.ApplyStaDate)
                    // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                    {
                        startDate = TDateTime.LongDateToDateTime(campaignRsltList.ApplyStaDate);
                    }
                    // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                    //if (TDateTime.DateTimeToLongDate(startDate) < campaignRsltList.ApplyEndDate && TDateTime.DateTimeToLongDate(endDate) > campaignRsltList.ApplyEndDate)
                    if (TDateTime.DateTimeToLongDate(startDate) <= campaignRsltList.ApplyEndDate && TDateTime.DateTimeToLongDate(endDate) >= campaignRsltList.ApplyEndDate)
                    // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                    {
                        endDate = TDateTime.LongDateToDateTime(campaignRsltList.ApplyEndDate);
                    }

                    DateTerm dateTerm = new DateTerm();
                    dateTerm.DateTimeSt = startDate;
                    dateTerm.DateTimeEd = endDate;

                    dic.Add(monthSt.Month.ToString(), dateTerm);
                    monthSt = monthSt.AddMonths(1);
                }
            }

            foreach (CampaignstRsltListResultWork camWork in salesList)
            {
                // ----- ADD 2011/07/27 ----- >>>>>
                if (camWork.SalesSlipCdDtl == 2 && camWork.GoodsNo == string.Empty)
                {
                    continue;
                }
                // ----- ADD 2011/07/27 ----- <<<<<

                if (campaignRsltList.PrintType != 1)
                {
                    makerCode = camWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                }

                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods:
                        {
                            #region ���i��
                            #region Key�̍쐬
                            // ���גP��
                            if (campaignRsltList.Detail == 0)
                            {
                                // ���v�P��
                                if (campaignRsltList.Total == 0)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                            }
                            else if (campaignRsltList.Detail == 1)
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            else
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            #endregion

                            #region ���v
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());
                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // �������v
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ���ԍ��v
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // ����^�C�v�F����/���t
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // ����^�C�v�F����
                            else
                            {
                                // ----- UPD 2011/07/27 --------------------------->>>>>
                                //if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                if (compKey != workKey && CheckMonthValue(monthCnt, work))
                                // ----- UPD 2011/07/27 ---------------------------<<<<<
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer:
                        {
                            #region ���Ӑ��
                            #region Key�̍쐬
                            // �o�͏�
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region ���v
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // �������v
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ���ԍ��v
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // ����^�C�v�F����/���t
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // ����^�C�v�F����
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachEmployee:
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr:
                    case CampaignRsltList.TotalTypeState.EachPrinter:
                        {
                            #region �S���ҕʁE�󒍎ҕʁE���s�ҕ�
                            #region Key�̍쐬
                            // �o�͏�
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region ���v
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }

                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // �������v
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ���ԍ��v
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<

                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {

                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // ����^�C�v�F����/���t
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // ����^�C�v�F����
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachArea:
                        {
                            #region �n���
                            #region Key�̍쐬
                            // �o�͏�
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else if (campaignRsltList.OutputSort == 1)
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.CustomerCode.ToString().PadLeft(8, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            else
                            {
                                // ���גP��
                                if (campaignRsltList.Detail == 0)
                                {
                                    // ���v�P��
                                    if (campaignRsltList.Total == 0)
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                    else
                                    {
                                        workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                    }
                                }
                                else if (campaignRsltList.Detail == 1)
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                                else
                                {
                                    workKey = camWork.ManageSectionCode + camWork.SalesAreaCode.ToString().PadLeft(4, '0') + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                                }
                            }
                            #endregion

                            #region ���v
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }

                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {

                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // �������v
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ���ԍ��v
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // ����^�C�v�F����/���t
                            if (campaignRsltList.PrintType != 1)
                            {
                                //if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27

                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // ����^�C�v�F����
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachSales:
                        {
                            #region �̔��敪��
                            #region Key�̍쐬
                            // ���גP��
                            if (campaignRsltList.Detail == 0)
                            {
                                // ���v�P��
                                if (campaignRsltList.Total == 0)
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                                else
                                {
                                    workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode + camWork.GoodsNo;
                                }
                            }
                            else if (campaignRsltList.Detail == 1)
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            else
                            {
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd + camWork.BLGroupCode.ToString().PadLeft(5, '0') + makerCode;
                            }
                            #endregion

                            #region ���v
                            if (compKey != workKey)
                            {
                                work = camWork;

                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt = work.ShipmentCnt;
                                    if (work.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt = work.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit = work.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt = work.ShipmentCnt;
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt = work.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc = work.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit = work.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;

                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            if (work.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, work.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, work.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, work.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            else
                            {
                                // �������v
                                if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                    && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                {
                                    // ----- UPD 2011/07/27 ----->>>>>
                                    //work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    if (camWork.SalesSlipCdDtl != 2)
                                    {
                                        work.AddUpShipmentCnt += camWork.ShipmentCnt;
                                    }
                                    // ----- UPD 2011/07/27 -----<<<<<
                                    work.AddUpSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                    work.AddUpSalesProfit += camWork.SalesProfit;
                                }
                                // ----- ADD 2011/08/03 ----->>>>>
                                if (campaignRsltList.PrintType != 1)
                                {
                                // ----- ADD 2011/08/03 -----<<<<<
                                    // ���ԍ��v
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        // ----- UPD 2011/07/27 ----->>>>>
                                        //work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        if (camWork.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        // ----- UPD 2011/07/27 -----<<<<<
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                // ----- ADD 2011/08/03 ----->>>>>
                                }
                                else
                                {
                                   
                                    if (TDateTime.DateTimeToLongDate(camWork.SalesDate) >= campaignRsltList.ApplyStaDate
                                        && camWork.SalesDate >= campaignRsltList.AddUpYearMonthDaySt
                                        && TDateTime.DateTimeToLongDate(camWork.SalesDate) <= campaignRsltList.ApplyEndDate
                                        && camWork.SalesDate <= campaignRsltList.AddUpYearMonthDayEd)
                                    {
                                        if (work.SalesSlipCdDtl != 2)
                                        {
                                            work.CampaignShipmentCnt += camWork.ShipmentCnt;
                                        }
                                        work.CampaignSalesMoneyTaxExc += camWork.SalesMoneyTaxExc;
                                        work.CampaignSalesProfit += camWork.SalesProfit;
                                    }
                                }
                                // ----- ADD 2011/08/03 -----<<<<<
                                //����^�C�v�F����
                                if (campaignRsltList.PrintType == 1)
                                {
                                    DateTime month_St = campaignRsltList.AddUpYearMonthSt;
                                    int index = 0;
                                    while (month_St <= campaignRsltList.AddUpYearMonthEd)
                                    {
                                        index++;
                                        // ----- UPD 2011/07/27 --------------------------------------------------------------------->>>>>
                                        //if (camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        if (dic.ContainsKey(month_St.Month.ToString()) && camWork.SalesDate >= dic[month_St.Month.ToString()].DateTimeSt && camWork.SalesDate <= dic[month_St.Month.ToString()].DateTimeEd)
                                        // ----- UPD 2011/07/27 ---------------------------------------------------------------------<<<<<
                                        {
                                            PropertyInfo propInfo_monthShipmentCntSum_work = work.GetType().GetProperty("TotalSalesCount" + index.ToString());
                                            PropertyInfo propInfo_monthSalesmoneyTaxexcSum_work = work.GetType().GetProperty("SalesMoneyTaxExc" + index.ToString());
                                            PropertyInfo propInfo_monthGrsProfitSum_work = work.GetType().GetProperty("SalesProfit" + index.ToString());

                                            // ----- UPD 2011/07/27 ----->>>>>
                                            //propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            if (camWork.SalesSlipCdDtl != 2)
                                            {
                                                propInfo_monthShipmentCntSum_work.SetValue(work, (double)propInfo_monthShipmentCntSum_work.GetValue(work, null) + camWork.ShipmentCnt, null);
                                            }
                                            // ----- UPD 2011/07/27 -----<<<<<
                                            propInfo_monthSalesmoneyTaxexcSum_work.SetValue(work, (long)propInfo_monthSalesmoneyTaxexcSum_work.GetValue(work, null) + camWork.SalesMoneyTaxExc, null);
                                            propInfo_monthGrsProfitSum_work.SetValue(work, (long)propInfo_monthGrsProfitSum_work.GetValue(work, null) + camWork.SalesProfit, null);
                                        }
                                        month_St = month_St.AddMonths(1);
                                    }
                                }
                            }
                            #endregion

                            // ����^�C�v�F����/���t
                            if (campaignRsltList.PrintType != 1)
                            {
                                // if (compKey != workKey && work.CampaignShipmentCnt != 0) // DEL 2011/07/27
                                if (compKey != workKey && (work.AddUpShipmentCnt != 0 || work.CampaignShipmentCnt != 0 || work.AddUpSalesMoneyTaxExc != 0
                                    || work.CampaignSalesMoneyTaxExc != 0 || work.AddUpSalesProfit != 0 || work.CampaignSalesProfit != 0))  // ADD 2011/07/27
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            // ����^�C�v�F����
                            else
                            {
                                if (compKey != workKey && CheckMonthValue(monthCnt, camWork))
                                {
                                    resultLst.Add(work);
                                    compKey = workKey;
                                }
                            }
                            #endregion
                        }
                        break;
                }

            }

            // ----- ADD 2011/07/27 ------------------------------------------->>>>>
            foreach (CampaignstRsltListResultWork resultwork in resultLst)
            {
                // ����^�C�v�F����/���t
                if (campaignRsltList.PrintType != 1)
                {
                    if (resultwork.AddUpShipmentCnt != 0 || resultwork.CampaignShipmentCnt != 0 || resultwork.AddUpSalesMoneyTaxExc != 0
                        || resultwork.CampaignSalesMoneyTaxExc != 0 || resultwork.AddUpSalesProfit != 0 || resultwork.CampaignSalesProfit != 0)
                    {
                        dataList.Add(resultwork);
                    }
                }
                // ����^�C�v�F����
                else
                {
                    if (CheckMonthValue(monthCnt, resultwork))
                    {
                        dataList.Add(resultwork);
                    }
                }
            }
            // ----- ADD 2011/07/27 -------------------------------------------<<<<<
        }

        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <param name="salesList">�擾�̔���f�[�^</param>
        /// <param name="targetList">�擾�̖ڕW�f�[�^</param>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <param name="resultLst">���ʃf�[�^</param>
        /// <remarks>
        /// <br>Note       : �f�[�^���o�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void SetDataFrmTargetToSales(ArrayList salesList, ArrayList targetList, CampaignRsltList campaignRsltList, out ArrayList resultLst)
        {
            string dicKey = string.Empty;
            string workSec = string.Empty;
            string secCode = string.Empty;// ���_�p
            string section = string.Empty; // �S���җp
            string employee = string.Empty;
            int customer = 0;
            string groupGoodsCode = string.Empty;
            string area = string.Empty;
            int index = 0;
            string section1 = string.Empty; // ���v�p
            string section2 = string.Empty; // ���_�v�p

            // �ڕW�l�̎擾�E�Z�o
            if (salesList.Count != 0 && targetList.Count != 0)
            {
                GetTargetDate(targetList, campaignRsltList);

                // ���їp�̃��X�g�̃Z�b�g���@
                foreach (CampaignstRsltListResultWork camWork in salesList)
                {
                    switch (campaignRsltList.TotalType)
                    {
                        case CampaignRsltList.TotalTypeState.EachGoods: //���i��
                            {
                                #region �����i��
                                //���v�p
                                #region
                                string subTotalCode = string.Empty;
                                // ���v�P��:�u0:��ٰ�ߺ��ށv�ꍇ
                                if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode;
                                    subTotalCode = camWork.BLGroupCode.ToString();
                                }
                                else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode;
                                    subTotalCode = camWork.BLGoodsCode.ToString();
                                }

                                if ((campaignRsltList.PrintType != 1 && campaignRsltList.Detail == 0) || campaignRsltList.PrintType == 1)
                                {
                                    if (section != camWork.ResultsAddUpSecCd || groupGoodsCode != subTotalCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;

                                            section = camWork.ResultsAddUpSecCd;
                                            // ���v�P��:�u0:��ٰ�ߺ��ށv�ꍇ
                                            if (campaignRsltList.Total == 0)
                                            {
                                                groupGoodsCode = camWork.BLGroupCode.ToString();
                                            }
                                            else
                                            {
                                                groupGoodsCode = camWork.BLGoodsCode.ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                        camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                        camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                        camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                        camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                        camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;                                        
                                    }
                                }
                                #endregion

                                // ���_�v�p
                                #region
                                if (index == 0)
                                {
                                    section2 = string.Empty;
                                }
                                dicKey = camWork.ResultsAddUpSecCd;

                                if (section2 != camWork.ResultsAddUpSecCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                        camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                        camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                        camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                        camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                        camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;

                                        section2 = camWork.ResultsAddUpSecCd;
                                    }
                                }
                                #endregion

                                index++;
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                            {
                                #region �����Ӑ��
                                // �o�͏����u���Ӑ�v�u�Ǘ����_�v�̏ꍇ
                                if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 3)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }
                                    // ���Ӑ�v
                                    // �L�[ = ���_�E���Ӑ�
                                    dicKey = workSec + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                    if (section != workSec || customer != camWork.CustomerCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget3 = this._totalDic[dicKey].MonthlySalesTarget3;
                                            camWork.MonthlySalesTargetProfit3 = this._totalDic[dicKey].MonthlySalesTargetProfit3;
                                            camWork.MonthlySalesTargetCount3 = this._totalDic[dicKey].MonthlySalesTargetCount3;

                                            camWork.TermSalesTarget3 = this._totalDic[dicKey].TermSalesTarget3;
                                            camWork.TermSalesTargetProfit3 = this._totalDic[dicKey].TermSalesTargetProfit3;
                                            camWork.TermSalesTargetCount3 = this._totalDic[dicKey].TermSalesTargetCount3;
                                        }

                                        section = workSec;
                                        customer = camWork.CustomerCode;
                                    }
                                    // ���_�v
                                    // �L�[ = ���_����
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // �o�͏����u���_�v�̏ꍇ
                                else if (campaignRsltList.OutputSort == 1)
                                {
                                    // ���_�v
                                    // �L�[ = ���_
                                    dicKey = camWork.ResultsAddUpSecCd;

                                    if (secCode != camWork.ResultsAddUpSecCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = camWork.ResultsAddUpSecCd;
                                    }
                                    //���v�p
                                    string subTotalCode = string.Empty;
                                    // ���v�P��:�u0:��ٰ�ߺ��ށv�ꍇ
                                    if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                    {
                                        dicKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0');
                                        subTotalCode = camWork.BLGroupCode.ToString();
                                    }
                                    else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                    {
                                        dicKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0');
                                        subTotalCode = camWork.BLGoodsCode.ToString();
                                    }

                                    if ((campaignRsltList.PrintType != 1 && campaignRsltList.Detail == 0) || campaignRsltList.PrintType == 1)
                                    {
                                        if (section != camWork.ResultsAddUpSecCd || groupGoodsCode != subTotalCode)
                                        {
                                            if (this._totalDic.ContainsKey(dicKey))
                                            {
                                                camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                                camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                                camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                                camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                                camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                                camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                            }

                                            section = camWork.ResultsAddUpSecCd;
                                            // ���v�P��:�u0:��ٰ�ߺ��ށv�ꍇ
                                            if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2)
                                            {
                                                groupGoodsCode = camWork.BLGroupCode.ToString();
                                            }
                                            else if ((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1)
                                            {
                                                groupGoodsCode = camWork.BLGoodsCode.ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }
                                    }
                                }
                                // �o�͏����u���Ӑ�|���_�v�̏ꍇ
                                else if (campaignRsltList.OutputSort == 2)
                                {
                                    // �L�[ = ���Ӑ�E���_
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                    if (section != camWork.ResultsAddUpSecCd || customer != camWork.CustomerCode)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget3;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit3;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount3;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget3;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit3;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount3;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        customer = camWork.CustomerCode;
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                        case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                        case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                            {
                                #region ���S���ҕʁE���s�ҕʁE�󒍎ҕ�
                                // �o�͏����u�S����/���s��/�󒍎ҁv�u���Ӑ�v�u�Ǘ����_�v�̏ꍇ
                                if (campaignRsltList.OutputSort != 2)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }

                                    // �S���җp
                                    dicKey = workSec + camWork.SalesEmployeeCd;

                                    if (section != workSec || employee != camWork.SalesEmployeeCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = workSec;
                                        employee = camWork.SalesEmployeeCd;
                                    }
                                    // ���_�p
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // �o�͏����u�S���ҁ|���_/���s�ҁ|���_/�󒍎ҁ|���_�v�̏ꍇ
                                else
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;

                                    if (section != camWork.ResultsAddUpSecCd || employee != camWork.SalesEmployeeCd)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        employee = camWork.SalesEmployeeCd;
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachArea: // �n���
                            {
                                #region ���n���
                                // �o�͏����u�n��v�u���Ӑ�v�u�Ǘ����_�v�̏ꍇ
                                if (campaignRsltList.OutputSort != 2)
                                {
                                    if (campaignRsltList.OutputSort == 3)
                                    {
                                        workSec = camWork.ManageSectionCode;
                                    }
                                    else
                                    {
                                        workSec = camWork.ResultsAddUpSecCd;
                                    }

                                    // �n��p
                                    dicKey = workSec + camWork.SalesAreaCode;

                                    if (section != workSec || area != camWork.SalesAreaCode.ToString())
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = workSec;
                                        area = camWork.SalesAreaCode.ToString();
                                    }
                                    // ���_�p
                                    dicKey = workSec;

                                    if (secCode != workSec)
                                    {
                                        if (this._totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                        }

                                        secCode = workSec;
                                    }
                                }
                                // �o�͏����u�n��|���_�v�̏ꍇ
                                else
                                {
                                    dicKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;

                                    if (section != camWork.ResultsAddUpSecCd || area != camWork.SalesAreaCode.ToString())
                                    {
                                        if (_totalDic.ContainsKey(dicKey))
                                        {
                                            camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget1;
                                            camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                            camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                            camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget1;
                                            camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                            camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount1;
                                        }

                                        section = camWork.ResultsAddUpSecCd;
                                        area = camWork.SalesAreaCode.ToString();
                                    }
                                }
                                #endregion
                            }
                            break;
                        case CampaignRsltList.TotalTypeState.EachSales: // �̔��敪
                            {
                                #region ���̔��敪��
                                // �̔��敪
                                dicKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;

                                if (section != camWork.ResultsAddUpSecCd || employee != camWork.SalesEmployeeCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget1 = this._totalDic[dicKey].MonthlySalesTarget1;
                                        camWork.MonthlySalesTargetProfit1 = this._totalDic[dicKey].MonthlySalesTargetProfit1;
                                        camWork.MonthlySalesTargetCount1 = this._totalDic[dicKey].MonthlySalesTargetCount1;

                                        camWork.TermSalesTarget1 = this._totalDic[dicKey].TermSalesTarget1;
                                        camWork.TermSalesTargetProfit1 = this._totalDic[dicKey].TermSalesTargetProfit1;
                                        camWork.TermSalesTargetCount1 = this._totalDic[dicKey].TermSalesTargetCount1;
                                    }

                                    section = camWork.ResultsAddUpSecCd;
                                    employee = camWork.SalesEmployeeCd;
                                }
                                // ���_�p
                                dicKey = camWork.ResultsAddUpSecCd;

                                if (secCode != camWork.ResultsAddUpSecCd)
                                {
                                    if (this._totalDic.ContainsKey(dicKey))
                                    {
                                        camWork.MonthlySalesTarget2 = this._totalDic[dicKey].MonthlySalesTarget2;
                                        camWork.MonthlySalesTargetProfit2 = this._totalDic[dicKey].MonthlySalesTargetProfit2;
                                        camWork.MonthlySalesTargetCount2 = this._totalDic[dicKey].MonthlySalesTargetCount2;

                                        camWork.TermSalesTarget2 = this._totalDic[dicKey].TermSalesTarget2;
                                        camWork.TermSalesTargetProfit2 = this._totalDic[dicKey].TermSalesTargetProfit2;
                                        camWork.TermSalesTargetCount2 = this._totalDic[dicKey].TermSalesTargetCount2;
                                    }

                                    secCode = camWork.ResultsAddUpSecCd;
                                }
                                #endregion
                            }
                            break;
                    }
                }
            }
            resultLst = salesList;
        }

        #region [�ڕW�l�̎擾�E�Z�o]
        /// <summary>
        /// �ڕW�l�̎擾�E�Z�o
        /// </summary>
        /// <param name="list">�擾�f�[�^</param>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^���o�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void GetTargetDate(ArrayList list, CampaignRsltList campaignRsltList)
        {
            DateTime startDate = campaignRsltList.AddUpYearMonthSt;
            DateTime endDate = campaignRsltList.AddUpYearMonthEd;

            // �Ώۓ��t�̌���
            int month = 0;
            ArrayList monthlist = new ArrayList();
            while (startDate <= endDate) 
            {
                monthlist.Add(startDate.Month);
                startDate = startDate.AddMonths(1);
            }
            month = monthlist.Count;

            // ���ԖڕW
            long monthlySalesTarget = 0;
            long monthlySalesTargetProfit = 0;
            double monthlySalesTargetCount = 0;
            // ���ԖڕW
            long termSalesTarget = 0;
            long termSalesTargetProfit = 0;
            double termSalesTargetCount = 0;

            string workKey = string.Empty; 

            foreach (CampaignstRsltListResultWork camWork in list)
            {
                monthlySalesTarget = 0;
                monthlySalesTargetProfit = 0;
                monthlySalesTargetCount = 0;

                // ���ԖڕW
                if (campaignRsltList.PrintType == 0)
                {
                    // ���㌎�ԖڕW���z                
                    if (camWork.MonthlySalesTarget != 0)
                    {
                        monthlySalesTarget = camWork.MonthlySalesTarget * month;
                    }
                    else
                    {
                        // �Ώۓ��t�͈̔͂ɊY�����錎�ʂ̖ڕW�l�̗݌v
                        for (int ix = 1; ix < 13; ix++) 
                        {
                            if (monthlist.Contains(ix))
                            {
                                long salesTargetMoney = 0;
                                salesTargetMoney = this.GetLongPropertyValueFromObject(camWork, ctSalesTargetMoney + ix);
                                if (salesTargetMoney != 0)
                                {
                                    monthlySalesTarget += salesTargetMoney;
                                }
                            }
                        }
                    }
                    // ���㌎�ԖڕW�e���z
                    if (camWork.MonthlySalesTargetProfit != 0)
                    {
                        monthlySalesTargetProfit = camWork.MonthlySalesTargetProfit * month;
                    }
                    else
                    {
                        // �Ώۓ��t�͈̔͂ɊY�����錎�ʂ̖ڕW�l�̗݌v
                        for (int ix = 1; ix < 13; ix++)
                        {
                            if (monthlist.Contains(ix))
                            {
                                long salesTargetProfit = this.GetLongPropertyValueFromObject(camWork, ctSalesTargetProfit + ix);
                                if (salesTargetProfit != 0)
                                {
                                    monthlySalesTargetProfit += salesTargetProfit;
                                }
                            }
                        }
                    }
                    // ���㌎�ԖڕW����
                    if (camWork.MonthlySalesTargetCount != 0)
                    {
                        monthlySalesTargetCount = camWork.MonthlySalesTargetCount * month;
                    }
                    else
                    {
                        // �Ώۓ��t�͈̔͂ɊY�����錎�ʂ̖ڕW�l�̗݌v
                        for (int ix = 1; ix < 13; ix++)
                        {
                            if (monthlist.Contains(ix))
                            {
                                double salesTargetCount = this.GetDoublePropertyValueFromObject(camWork, ctSalesTargetCount + ix);
                                if (salesTargetCount != 0)
                                {
                                    monthlySalesTargetCount += salesTargetCount;
                                }
                            }
                        }
                    }
                }

                // ���ԖڕW
                // ������ԖڕW���z                
                if (camWork.TermSalesTarget != 0)
                {
                    termSalesTarget = camWork.TermSalesTarget;
                }
                else
                {
                    termSalesTarget = camWork.SalesTargetMoney1 +
                                      camWork.SalesTargetMoney2 +
                                      camWork.SalesTargetMoney3 +
                                      camWork.SalesTargetMoney4 +
                                      camWork.SalesTargetMoney5 +
                                      camWork.SalesTargetMoney6 +
                                      camWork.SalesTargetMoney7 +
                                      camWork.SalesTargetMoney8 +
                                      camWork.SalesTargetMoney9 +
                                      camWork.SalesTargetMoney10 +
                                      camWork.SalesTargetMoney11 +
                                      camWork.SalesTargetMoney12;
                }
                // ������ԖڕW�e���z
                if (camWork.TermSalesTargetProfit != 0)
                {
                    termSalesTargetProfit = camWork.TermSalesTargetProfit;
                }
                else
                {
                    termSalesTargetProfit = camWork.SalesTargetProfit1 +
                                            camWork.SalesTargetProfit2 +
                                            camWork.SalesTargetProfit3 +
                                            camWork.SalesTargetProfit4 +
                                            camWork.SalesTargetProfit5 +
                                            camWork.SalesTargetProfit6 +
                                            camWork.SalesTargetProfit7 +
                                            camWork.SalesTargetProfit8 +
                                            camWork.SalesTargetProfit9 +
                                            camWork.SalesTargetProfit10 +
                                            camWork.SalesTargetProfit11 +
                                            camWork.SalesTargetProfit12;
                }
                // ������ԖڕW����
                if (camWork.TermSalesTargetCount != 0)
                {
                    termSalesTargetCount = camWork.TermSalesTargetCount;
                }
                else
                {
                    termSalesTargetCount = camWork.SalesTargetCount1 +
                                           camWork.SalesTargetCount2 +
                                           camWork.SalesTargetCount3 +
                                           camWork.SalesTargetCount4 +
                                           camWork.SalesTargetCount5 +
                                           camWork.SalesTargetCount6 +
                                           camWork.SalesTargetCount7 +
                                           camWork.SalesTargetCount8 +
                                           camWork.SalesTargetCount9 +
                                           camWork.SalesTargetCount10 +
                                           camWork.SalesTargetCount11 +
                                           camWork.SalesTargetCount12;
                }

                this._dictionaryCampTarget = new CampaignTargetValue();
                
                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                        {
                            #region �����i��
                            // ���v�p
                            if (camWork.TargetContrastCd == 60 || camWork.TargetContrastCd == 50)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                //���v�P��:�u0�F��ٰ�ߺ�āv�ꍇ
                                if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2) && camWork.TargetContrastCd == 50)
                                {
                                    // ���_�E��ٰ�ߺ��
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode;
                                }
                                // �ڕW�Δ�敪:60�u���_�EBL���ށv�̏ꍇ
                                else if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1) && camWork.TargetContrastCd == 60)
                                {
                                    // ���_�EBLߺ��
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode;
                                }
                                else
                                {
                                    workKey = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���_�p
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // ���_����
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                        {
                            #region �����Ӑ��
                            // ���v�p
                            if (camWork.TargetContrastCd == 60 || camWork.TargetContrastCd == 50)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // �ڕW�Δ�敪:50�u���_�{��ٰ�ߺ��ށv�̏ꍇ
                                if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 0) || campaignRsltList.Detail == 2) && camWork.TargetContrastCd == 50)
                                {
                                    // ���_�E��ٰ�ߺ��
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGroupCode.ToString().PadLeft(5, '0');
                                }
                                // �ڕW�Δ�敪:60�u���_�EBL���ށv�̏ꍇ
                                else if (((campaignRsltList.Detail == 0 && campaignRsltList.Total == 1) || campaignRsltList.Detail == 1) && camWork.TargetContrastCd == 60)
                                {
                                    // ���_�EBLߺ��
                                    workKey = camWork.ResultsAddUpSecCd + camWork.BLGoodsCode.ToString().PadLeft(5, '0');
                                }
                                else
                                {
                                    workKey = string.Empty;
                                }

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���Ӑ�p
                            else if (camWork.TargetContrastCd == 30)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget3 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit3 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount3 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget3 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit3 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount3 = termSalesTargetCount;

                                // ���_�E���Ӑ�
                                workKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode.ToString().PadLeft(8, '0');

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���_�p
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // ���_����
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                    case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                        {
                            #region ���S���ҕʁE�󒍎ҕʁE���s�ҕ�
                            // �S���җp/�󒍎�/���s�җp
                            if (camWork.TargetContrastCd == 22)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // ���_�E�S����/�󒍎�/���s��
                                workKey = camWork.ResultsAddUpSecCd + camWork.EmployeeCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���_�p
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // ���_����
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachArea: // �n���
                        {
                            #region ���n���
                            // �n��p
                            if (camWork.TargetContrastCd == 32)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // ���_�E�n��
                                workKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���_�p
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // ���_����
                                workKey = camWork.ResultsAddUpSecCd;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                    case CampaignRsltList.TotalTypeState.EachSales:
                        {
                            #region ���̔��敪��
                            // �̔��敪�p
                            if (camWork.TargetContrastCd == 44)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget1 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit1 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount1 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget1 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit1 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount1 = termSalesTargetCount;

                                // ���_�E�̔��敪
                                workKey = camWork.ManageSectionCode + camWork.EmployeeCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            // ���_�p
                            else if (camWork.TargetContrastCd == 10)
                            {
                                // ���ԖڕW
                                this._dictionaryCampTarget.MonthlySalesTarget2 = monthlySalesTarget;
                                this._dictionaryCampTarget.MonthlySalesTargetProfit2 = monthlySalesTargetProfit;
                                this._dictionaryCampTarget.MonthlySalesTargetCount2 = monthlySalesTargetCount;
                                // ���ԖڕW
                                this._dictionaryCampTarget.TermSalesTarget2 = termSalesTarget;
                                this._dictionaryCampTarget.TermSalesTargetProfit2 = termSalesTargetProfit;
                                this._dictionaryCampTarget.TermSalesTargetCount2 = termSalesTargetCount;

                                // ���_����
                                workKey = camWork.ManageSectionCode;

                                if (!string.IsNullOrEmpty(workKey))
                                {
                                    this._totalDic.Add(workKey, this._dictionaryCampTarget);
                                }
                            }
                            #endregion
                        }
                        break;
                }
            }
        }
        #endregion [�ڕW�l�̎擾�E�Z�o]

        #region [�v���p�e�B�l�̎Z�o]
        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g��long�v���p�e�B�̒l�擾
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <param name="propertyName">�v���p�e�B����</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�I�u�W�F�N�g��long�v���p�e�B�l�擾</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private long GetLongPropertyValueFromObject(object obj, string propertyName)
        {
            // �߂�l��`
            long result = 0;

            // �v���p�e�B�l�擾
            object retVal = GetPropertyValueFromObject(obj, propertyName);

            // �f�[�^�L�����`�F�b�N
            if (retVal != null && retVal is long)
            {
                result = Convert.ToInt64(retVal);
            }

            return result;
        }

        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g��long�v���p�e�B�̒l�擾
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <param name="propertyName">�v���p�e�B����</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�I�u�W�F�N�g��long�v���p�e�B�l�擾</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private double GetDoublePropertyValueFromObject(object obj, string propertyName)
        {
            // �߂�l��`
            double result = 0;

            // �v���p�e�B�l�擾
            object retVal = GetPropertyValueFromObject(obj, propertyName);

            // �f�[�^�L�����`�F�b�N
            if (retVal != null && retVal is double)
            {
                result = Convert.ToDouble(retVal);
            }

            return result;
        }

        /// <summary>
        /// �w�肳�ꂽ�I�u�W�F�N�g�̃v���p�e�B�̒l�擾
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <param name="propertyName">�v���p�e�B����</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�I�u�W�F�N�g��int�v���p�e�B�l�擾</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private object GetPropertyValueFromObject(object obj, string propertyName)
        {
            // �߂�l��`
            object result = null;

            // NULL�`�F�b�N
            if (obj != null && propertyName != null && !String.IsNullOrEmpty(propertyName))
            {
                // ����R�[�h�v���p�e�B�擾
                PropertyInfo propInfo = obj.GetType().GetProperty(propertyName);

                // NULL�`�F�b�N
                if (propInfo != null)
                {
                    // �v���p�e�B�l�擾
                    result = propInfo.GetValue(obj, null);
                }
            }

            return result;
        }

        /// <summary>
        /// �����̎Z�o
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>���Ԍ���</returns>
        /// <remarks>
        /// <br>Note       : �����̎Z�o���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private int GetTermMonthCount(CampaignRsltList campaignRsltList)
        {
            DateTime startDate = campaignRsltList.AddUpYearMonthSt;
            DateTime endDate = campaignRsltList.AddUpYearMonthEd;

            // �Ώۓ��t�̌���
            int month = 0;
            ArrayList monthlist = new ArrayList();
            while (startDate <= endDate)
            {
                monthlist.Add(startDate.Month);
                startDate = startDate.AddMonths(1);
            }
            month = monthlist.Count;
            return month;
        }

        /// <summary>
        /// �`�F�b�N
        /// </summary>
        /// <param name="monthCnt">����</param>
        /// <param name="camWork">����f�[�^</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���o�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private bool CheckMonthValue(int monthCnt, CampaignstRsltListResultWork camWork)
        {
            bool isTargetData = false;

            for (int i = 1; i <= monthCnt; i++)
            {
                if ((long)GetPropertyValueFromObject(camWork, "SalesMoneyTaxExc" + i.ToString()) != 0
                    || (long)GetPropertyValueFromObject(camWork, "SalesProfit" + i.ToString()) != 0
                    //|| (double)GetPropertyValueFromObject(camWork, "SalesTargetCount" + i.ToString()) != 0)
                    || (double)GetPropertyValueFromObject(camWork, "TotalSalesCount" + i.ToString()) != 0)
                {
                    isTargetData = true;
                    break;
                }
            }
            return isTargetData;
        }
        #endregion

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <param name="list">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^�W�J�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void DevStockMoveData(CampaignRsltList campaignRsltList, ArrayList list)
        {
            DataRow dr;
            string applyDate = string.Empty;
            string headerKey = string.Empty;

            applyDate = "[ " + campaignRsltList.ApplyStaDate.ToString("####/##/##") + " �` " + campaignRsltList.ApplyEndDate.ToString("####/##/##") + " ]";
            
            foreach (CampaignstRsltListResultWork camWork in list)
            {
                dr = this._campaignRsltListDt.NewRow();
                dr[PMKHN02054EA.ct_Col_ApplyDate]           = applyDate;                    // ����߰ݓK�p��
                dr[PMKHN02054EA.ct_Col_CampaignCode]        = camWork.CampaignCode;         // ����߰�
                dr[PMKHN02054EA.ct_Col_CampaignName]        = camWork.CampaignName;         // ����߰ݖ���

                switch (campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                    case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                    case CampaignRsltList.TotalTypeState.EachArea: // �n���
                    {
                        // ��ʂ̏o�͏����u�S���ҁv�u���Ӑ�v�u�S����-���_�v/�u�n��v�u���Ӑ�v�u�n��-���_�v�̏ꍇ
                        if (campaignRsltList.OutputSort != 3)
                        {
                            // ���ьv�㋒�_�R�[�h
                            dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                            // ���_����
                            if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "���o�^";
                            }

                            // �o�͏����u���Ӑ�v�̏ꍇ
                            if (campaignRsltList.OutputSort == 1)
                            {
                                // ���Ӑ�R�[�h
                                dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                                // ���Ӑ於��
                                if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                                }
                                else
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = "���o�^";
                                }                                
                            }
                            else
                            {
                                switch (campaignRsltList.TotalType)
                                {
                                    case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                                    case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                                        {
                                            headerKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;
                                        }
                                        break;
                                    case CampaignRsltList.TotalTypeState.EachArea: // �n���
                                        {
                                            headerKey = camWork.ResultsAddUpSecCd + camWork.SalesAreaCode;
                                        }
                                        break;
                                }
                                dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                            }
                            
                            
                        }
                        // ��ʂ̏o�͏����u�Ǘ����_�v�̏ꍇ
                        else
                        {
                            // �Ǘ����_�R�[�h
                            dr[PMKHN02054EA.ct_Col_ManageSectionCode] = camWork.ManageSectionCode;
                            // ���_����
                            if (!string.IsNullOrEmpty(camWork.ManageSectionSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = camWork.ManageSectionSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = "���o�^";
                            }
                            switch (campaignRsltList.TotalType)
                            {
                                case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                                case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                                    {
                                        headerKey = camWork.ManageSectionCode + camWork.SalesEmployeeCd;
                                    }
                                    break;
                                case CampaignRsltList.TotalTypeState.EachArea: // �n���
                                    {
                                        headerKey = camWork.ManageSectionCode + camWork.SalesAreaCode;
                                    }
                                    break;
                            }
                            dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                    {
                        // ���ьv�㋒�_�R�[�h
                        dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                        // ���_����
                        if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "���o�^";
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                    {
                        // ��ʂ̏o�͏����u���Ӑ�v�u���_�v�u���Ӑ�-���_�v�̏ꍇ
                        if (campaignRsltList.OutputSort != 3)
                        {
                            // ���ьv�㋒�_�R�[�h
                            dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                            // ���_����
                            if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "���o�^";
                            }

                            // �o�͏����u���Ӑ�v/�u���Ӑ�-���_�v�̏ꍇ
                            if (campaignRsltList.OutputSort == 0 || campaignRsltList.OutputSort == 2)
                            {
                                // ���Ӑ�R�[�h
                                dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                                // ���Ӑ於��
                                if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                                }
                                else
                                {
                                    dr[PMKHN02054EA.ct_Col_CustomerSnm] = "���o�^";
                                }
                                headerKey = camWork.ResultsAddUpSecCd + camWork.CustomerCode;
                                dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                            }

                        }
                        // ��ʂ̏o�͏����u�Ǘ����_�v�̏ꍇ
                        else
                        {
                            // �Ǘ����_�R�[�h
                            dr[PMKHN02054EA.ct_Col_ManageSectionCode] = camWork.ManageSectionCode;
                            // ���_����
                            if (!string.IsNullOrEmpty(camWork.ManageSectionSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = camWork.ManageSectionSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_ManageSectionNm] = "���o�^";
                            }
                            // ���Ӑ�R�[�h
                            dr[PMKHN02054EA.ct_Col_CustomerCode] = camWork.CustomerCode;
                            // ���Ӑ於��
                            if (!string.IsNullOrEmpty(camWork.CustomerSnm))
                            {
                                dr[PMKHN02054EA.ct_Col_CustomerSnm] = camWork.CustomerSnm;
                            }
                            else
                            {
                                dr[PMKHN02054EA.ct_Col_CustomerSnm] = "���o�^";
                            }
                            headerKey = camWork.ManageSectionCode + camWork.CustomerCode;
                            dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        }
                        break;
                    }

                    case CampaignRsltList.TotalTypeState.EachSales: // �̔��敪��
                    {
                        // ���ьv�㋒�_�R�[�h
                        dr[PMKHN02054EA.ct_Col_AddUpSecCode] = camWork.ResultsAddUpSecCd;
                        // ���_����
                        if (!string.IsNullOrEmpty(camWork.SectionGuideSnm))
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = camWork.SectionGuideSnm;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_SectionGuideNm] = "���o�^";
                        }

                        // �̔��敪
                        dr[PMKHN02054EA.ct_Col_EmployeeCode] = camWork.SalesEmployeeCd;
                        // �̔��敪����
                        if (!string.IsNullOrEmpty(camWork.EmployeeName))
                        {
                            dr[PMKHN02054EA.ct_Col_EmployeeName] = camWork.EmployeeName;
                        }
                        else
                        {
                            dr[PMKHN02054EA.ct_Col_EmployeeName] = "���o�^";
                        }

                        headerKey = camWork.ResultsAddUpSecCd + camWork.SalesEmployeeCd;
                        dr[PMKHN02054EA.ct_Col_HeaderKey1] = headerKey;
                        break;
                    }
                }
                // �S����
                dr[PMKHN02054EA.ct_Col_EmployeeCode]        = camWork.SalesEmployeeCd;
                // �S���Җ���
                if (!string.IsNullOrEmpty(camWork.EmployeeName))
                {
                    dr[PMKHN02054EA.ct_Col_EmployeeName] = camWork.EmployeeName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_EmployeeName] = "���o�^";
                }                
                // �n��R�[�h
                dr[PMKHN02054EA.ct_Col_AreaCode] = camWork.SalesAreaCode;
                // �n�於��
                if (!string.IsNullOrEmpty(camWork.GuideName))
                {
                    dr[PMKHN02054EA.ct_Col_AreaName] = camWork.GuideName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_AreaName] = "���o�^";
                }

                // BL�O���[�v�R�[�h
                dr[PMKHN02054EA.ct_Col_BLGroupCode] = camWork.BLGroupCode;
                // BL�O���[�v�R�[�h����
                if (!string.IsNullOrEmpty(camWork.BLGroupKanaName))
                {
                    dr[PMKHN02054EA.ct_Col_BLGroupKanaName] = camWork.BLGroupKanaName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_BLGroupKanaName] = "���o�^";
                }

                // BL���i�R�[�h
                dr[PMKHN02054EA.ct_Col_BLGoodsCode] = camWork.BLGoodsCode;
                // BL���i�R�[�h����
                if (!string.IsNullOrEmpty(camWork.BLGoodsHalfName))
                {
                    dr[PMKHN02054EA.ct_Col_BLGoodsHalfName] = camWork.BLGoodsHalfName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_BLGoodsHalfName] = "���o�^";
                }

                // ���i�ԍ�
                dr[PMKHN02054EA.ct_Col_GoodsNo] = camWork.GoodsNo;
                // ���i����
                if (!string.IsNullOrEmpty(camWork.GoodsNameKana))
                {
                    dr[PMKHN02054EA.ct_Col_GoodsName] = camWork.GoodsNameKana;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_GoodsName] = "���o�^";
                }

                // ���i���[�J�[�R�[�h
                dr[PMKHN02054EA.ct_Col_GoodsMakerCd]        = camWork.GoodsMakerCd;
                // ���i���[�J�[���� 
                if (!string.IsNullOrEmpty(camWork.MakerName))
                {
                    dr[PMKHN02054EA.ct_Col_MakerShortName] = camWork.MakerName;
                }
                else
                {
                    dr[PMKHN02054EA.ct_Col_MakerShortName] = "���o�^";
                }

                // ����^�C�v�F����
                if (campaignRsltList.PrintType == 1)
                {
                    // ���㐔1
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount1] = camWork.TotalSalesCount1;
                    // ���㐔2
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount2] = camWork.TotalSalesCount2;
                    // ���㐔3
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount3] = camWork.TotalSalesCount3;
                    // ���㐔4
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount4] = camWork.TotalSalesCount4;
                    // ���㐔5
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount5] = camWork.TotalSalesCount5;
                    // ���㐔6
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount6] = camWork.TotalSalesCount6;
                    // ���㐔7
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount7] = camWork.TotalSalesCount7;
                    // ���㐔8
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount8] = camWork.TotalSalesCount8;
                    // ���㐔9
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount9] = camWork.TotalSalesCount9;
                    // ���㐔10
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount10] = camWork.TotalSalesCount10;
                    // ���㐔11
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount11] = camWork.TotalSalesCount11;
                    // ���㐔12
                    dr[PMKHN02054EA.ct_Col_TotalSalesCount12] = camWork.TotalSalesCount12;
                    // ������z1
                    dr[PMKHN02054EA.ct_Col_SalesMoney1] = camWork.SalesMoneyTaxExc1;
                    // ������z2
                    dr[PMKHN02054EA.ct_Col_SalesMoney2] = camWork.SalesMoneyTaxExc2;
                    // ������z3
                    dr[PMKHN02054EA.ct_Col_SalesMoney3] = camWork.SalesMoneyTaxExc3;
                    // ������z4
                    dr[PMKHN02054EA.ct_Col_SalesMoney4] = camWork.SalesMoneyTaxExc4;
                    // ������z5
                    dr[PMKHN02054EA.ct_Col_SalesMoney5] = camWork.SalesMoneyTaxExc5;
                    // ������z6
                    dr[PMKHN02054EA.ct_Col_SalesMoney6] = camWork.SalesMoneyTaxExc6;
                    // ������z7
                    dr[PMKHN02054EA.ct_Col_SalesMoney7] = camWork.SalesMoneyTaxExc7;
                    // ������z8
                    dr[PMKHN02054EA.ct_Col_SalesMoney8] = camWork.SalesMoneyTaxExc8;
                    // ������z9
                    dr[PMKHN02054EA.ct_Col_SalesMoney9] = camWork.SalesMoneyTaxExc9;
                    // ������z10
                    dr[PMKHN02054EA.ct_Col_SalesMoney10] = camWork.SalesMoneyTaxExc10;
                    // ������z11
                    dr[PMKHN02054EA.ct_Col_SalesMoney11] = camWork.SalesMoneyTaxExc11;
                    // ������z12
                    dr[PMKHN02054EA.ct_Col_SalesMoney12] = camWork.SalesMoneyTaxExc12;
                    // �e���z1
                    dr[PMKHN02054EA.ct_Col_GrossProfit1] = camWork.SalesProfit1;
                    // �e���z2
                    dr[PMKHN02054EA.ct_Col_GrossProfit2] = camWork.SalesProfit2;
                    // �e���z3
                    dr[PMKHN02054EA.ct_Col_GrossProfit3] = camWork.SalesProfit3;
                    // �e���z4
                    dr[PMKHN02054EA.ct_Col_GrossProfit4] = camWork.SalesProfit4;
                    // �e���z5
                    dr[PMKHN02054EA.ct_Col_GrossProfit5] = camWork.SalesProfit5;
                    // �e���z6
                    dr[PMKHN02054EA.ct_Col_GrossProfit6] = camWork.SalesProfit6;
                    // �e���z7
                    dr[PMKHN02054EA.ct_Col_GrossProfit7] = camWork.SalesProfit7;
                    // �e���z8
                    dr[PMKHN02054EA.ct_Col_GrossProfit8] = camWork.SalesProfit8;
                    // �e���z9
                    dr[PMKHN02054EA.ct_Col_GrossProfit9] = camWork.SalesProfit9;
                    // �e���z10
                    dr[PMKHN02054EA.ct_Col_GrossProfit10] = camWork.SalesProfit10;
                    // �e���z11
                    dr[PMKHN02054EA.ct_Col_GrossProfit11] = camWork.SalesProfit11;
                    // �e���z12
                    dr[PMKHN02054EA.ct_Col_GrossProfit12] = camWork.SalesProfit12;
                }
                // �������㐔
                dr[PMKHN02054EA.ct_Col_MonthlySalesCount] = camWork.AddUpShipmentCnt;
                // ���ԗ݌v���㐔
                dr[PMKHN02054EA.ct_Col_TermSalesCount] = camWork.CampaignShipmentCnt;
                // �������ʖڕW1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount1] = camWork.MonthlySalesTargetCount1;
                // ���ԗ݌v���ʖڕW1
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount1] = camWork.TermSalesTargetCount1;
                // �������ʒB����1
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate1] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount1);
                // ���ԗ݌v���ʒB����1
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate1] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount1);
                // �������ʖڕW2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount2] = camWork.MonthlySalesTargetCount2;
                // ���ԗ݌v���ʖڕW2
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount2] = camWork.TermSalesTargetCount2;
                // �������ʒB����2
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate2] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount2);
                // ���ԗ݌v���ʒB����2
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate2] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount2);
                // �������ʖڕW3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetCount3] = camWork.MonthlySalesTargetCount3;
                // ���ԗ݌v���ʖڕW3
                dr[PMKHN02054EA.ct_Col_TermSalesTargetCount3] = camWork.TermSalesTargetCount3;
                // �������ʒB����3
                dr[PMKHN02054EA.ct_Col_MonthlySalesCountAchivRate3] = this.GetRatio(camWork.AddUpShipmentCnt, camWork.MonthlySalesTargetCount3);
                // ���ԗ݌v���ʒB����3
                dr[PMKHN02054EA.ct_Col_TermSalesCountAchivRate3] = this.GetRatio(camWork.CampaignShipmentCnt, camWork.TermSalesTargetCount3);

                // ��������z
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoney] = camWork.AddUpSalesMoneyTaxExc;
                // ���ԗ݌v����z
                dr[PMKHN02054EA.ct_Col_TermSalesMoney] = camWork.CampaignSalesMoneyTaxExc;
                // ��������ڕW1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget1] = camWork.MonthlySalesTarget1;
                // ���ԗ݌v����ڕW1
                dr[PMKHN02054EA.ct_Col_TermSalesTarget1] = camWork.TermSalesTarget1;
                // ��������B����1
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate1] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget1);
                // ���ԗ݌v����B����1
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate1] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget1);
                // ��������ڕW2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget2] = camWork.MonthlySalesTarget2;
                // ���ԗ݌v����ڕW2
                dr[PMKHN02054EA.ct_Col_TermSalesTarget2] = camWork.TermSalesTarget2;
                // ��������B����2
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate2] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget2);
                // ���ԗ݌v����B����2
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate2] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget2);
                // ��������ڕW3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTarget3] = camWork.MonthlySalesTarget3;
                // ���ԗ݌v����ڕW3
                dr[PMKHN02054EA.ct_Col_TermSalesTarget3] = camWork.TermSalesTarget3;
                // ��������B����3
                dr[PMKHN02054EA.ct_Col_MonthlySalesMoneyAchivRate3] = this.GetRatio(camWork.AddUpSalesMoneyTaxExc, camWork.MonthlySalesTarget3);
                // ���ԗ݌v����B����3
                dr[PMKHN02054EA.ct_Col_TermSalesMoneyAchivRate3] = this.GetRatio(camWork.CampaignSalesMoneyTaxExc, camWork.TermSalesTarget3);

                // �����e���z
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfit] = camWork.AddUpSalesProfit;
                // ���ԗ݌v�e���z
                dr[PMKHN02054EA.ct_Col_TermSalesProfit] = camWork.CampaignSalesProfit;
                // �����e����
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitRate] = this.GetRatio(camWork.AddUpSalesProfit, camWork.AddUpSalesMoneyTaxExc);
                // ���ԗ݌v�e����
                dr[PMKHN02054EA.ct_Col_TermSalesProfitRate] = this.GetRatio(camWork.CampaignSalesProfit, camWork.CampaignSalesMoneyTaxExc);
                // �����e���ڕW1
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit1] = camWork.MonthlySalesTargetProfit1;
                // ���ԗ݌v�e���ڕW1
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit1] = camWork.TermSalesTargetProfit1;
                // �����e���B����1
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate1] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit1);
                // ���ԗ݌v�e���B����1
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate1] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit1);
                // �����e���ڕW2
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit2] = camWork.MonthlySalesTargetProfit2;
                // ���ԗ݌v�e���ڕW2
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit2] = camWork.TermSalesTargetProfit2;
                // �����e���B����2
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate2] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit2);
                // ���ԗ݌v�e���B����2
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate2] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit2);
                // �����e���ڕW3
                dr[PMKHN02054EA.ct_Col_MonthlySalesTargetProfit3] = camWork.MonthlySalesTargetProfit3;
                // ���ԗ݌v�e���ڕW3
                dr[PMKHN02054EA.ct_Col_TermSalesTargetProfit3] = camWork.TermSalesTargetProfit3;
                // �����e���B����3
                dr[PMKHN02054EA.ct_Col_MonthlySalesProfitAchivRate3] = this.GetRatio(camWork.AddUpSalesProfit, camWork.MonthlySalesTargetProfit3);
                // ���ԗ݌v�e���B����3
                dr[PMKHN02054EA.ct_Col_TermSalesProfitAchivRate3] = this.GetRatio(camWork.CampaignSalesProfit, camWork.TermSalesTargetProfit3);
                
                // Table��Add
                this._campaignRsltListDt.Rows.Add(dr);
            }

            this._campaignRsltListView = new DataView(this._campaignRsltListDt, "", GetSortOrder(campaignRsltList), DataViewRowState.CurrentRows);
        }

        #region [�\�[�g���̍쐬]
        /// <summary>
        /// �\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g�����쐬����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string GetSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            switch (campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                    {
                        strSortOrder = GetGoodsSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                    {
                        strSortOrder = GetCustomerSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                    {
                        strSortOrder = GetEmpSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachArea: // �n���
                    {
                        strSortOrder = GetAreaSortOrder(campaignRsltList);
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachSales: // �̔��敪��
                    {
                        strSortOrder = GetSalesSortOrder(campaignRsltList);
                        break;
                    }
            }
            
            return strSortOrder.ToString();
        }

        #region [���i�ʃ\�[�g���̍쐬]
        /// <summary>
        /// ���i�ʃ\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʃ\�[�g���̍쐬���s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetGoodsSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();
            // ���ьv�㋒�_�R�[�h
            strSortOrder.Append(string.Format("{0} ASC", PMKHN02054EA.ct_Col_AddUpSecCode));
            // �i��
            if (campaignRsltList.Detail == 0)
            {
                // ��ٰ�ߺ���
                if (campaignRsltList.Total == 0)
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    if (campaignRsltList.PrintType != 1)
                    {
                        // �i�ԁ{Ұ��
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // Ұ���{�i��
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
                // BL����
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    if (campaignRsltList.PrintType != 1)
                    {
                        // �i�ԁ{Ұ��
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // Ұ���{�i��
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
            }
            // BL����
            else if (campaignRsltList.Detail == 1)
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                }
            }
            // ��ٰ�ߺ���
            else
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                }
            }

            return strSortOrder;
        }
        #endregion // ���i�ʃ\�[�g���̍쐬

        #region [���Ӑ�ʃ\�[�g���̍쐬]
        /// <summary>
        /// ���Ӑ�ʃ\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʃ\�[�g�����쐬����B</br>
        /// <br>Programmer : jijj</br>
        /// <br>Date       : 2011/05/23</br>
        /// </remarks>
        private StringBuilder GetCustomerSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // ���Ӑ�
            {
                // ���ьv�㋒�_�R�[�h�E���Ӑ�R�[�h ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_CustomerCode));
                // �]�v�ȃ\�[�g��
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }
            else if (campaignRsltList.OutputSort == 1) // ���_
            {
                // ���ьv�㋒�_�R�[�h ASC
                strSortOrder.Append(string.Format("{0} ASC", PMKHN02054EA.ct_Col_AddUpSecCode));
                // �]�v�ȃ\�[�g��
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }
            else if (campaignRsltList.OutputSort == 2) // ���Ӑ�-���_
            {
                // ���Ӑ�R�[�h�E���ьv�㋒�_�R�[�h ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_CustomerCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // �]�v�ȃ\�[�g��
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);

            }
            else if (campaignRsltList.OutputSort == 3) // �Ǘ����_
            {
                // �Ǘ����_�R�[�h�E���Ӑ�R�[�h ASC
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_CustomerCode));
                // �]�v�ȃ\�[�g��
                GetCustomerSubSortOrder(campaignRsltList, ref strSortOrder);
            }

            return strSortOrder;
        }

        /// <summary>
        /// ���Ӑ��sub�\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <param name="strSortOrder">���Ӑ��sub�\�[�g��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ��sub�\�[�g�����쐬����B</br>
        /// <br>Programmer : jijj</br>
        /// <br>Date       : 2011/05/23</br>
        /// </remarks>
        private void GetCustomerSubSortOrder(CampaignRsltList campaignRsltList, ref StringBuilder strSortOrder)
        {
            // �i��
            if (campaignRsltList.Detail == 0)
            {
                // ��ٰ�ߺ���
                if (campaignRsltList.Total == 0)
                {
                    // ��ٰ�ߺ��� ASC
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));

                    if (campaignRsltList.PrintType != 1)
                    {
                        // �i�ԁ{Ұ�� ASC
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // Ұ���{�i�� ACS
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
                // BL����
                else
                {
                    // BL���� ASC
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));

                    if (campaignRsltList.PrintType != 1)
                    {
                        // �i�ԁ{Ұ��
                        if (campaignRsltList.PrintSort == 0)
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                        }
                        // Ұ���{�i��
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                    }
                }
            }
            // BL����
            else if (campaignRsltList.Detail == 1)
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                }
            }
            // ��ٰ�ߺ���
            else
            {
                if (campaignRsltList.PrintType != 1)
                {
                    strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                }
                else
                {
                    strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                }
            }
        }
        #endregion // ���Ӑ�ʃ\�[�g���̍쐬

        #region [�S���ҕʃ\�[�g���̍쐬]
        /// <summary>
        /// �S���ҕʃ\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : �S���ҕʃ\�[�g�����쐬����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetEmpSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // 0�F�S����
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        // ����^�C�v�����Ԃ̏ꍇ
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        // ����^�C�v�����Ԃ̏ꍇ
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 1) // 1�F���Ӑ�
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC, {2} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode, PMKHN02054EA.ct_Col_CustomerCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 2) // 2�F�S���ҁ|���_
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_EmployeeCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 3) // 3�F�Ǘ����_
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else
            {
                // �Ȃ�
            }

            return strSortOrder;
        }
        #endregion // �S���ҕʃ\�[�g���̍쐬                

        #region [�̔��敪�ʃ\�[�g���̍쐬]
        /// <summary>
        /// �̔��敪�ʃ\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : �̔��敪�ʃ\�[�g�����쐬����B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private StringBuilder GetSalesSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_EmployeeCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            return strSortOrder;
        }
        #endregion // �S���ҕʃ\�[�g���̍쐬

        #region [�n��ʃ\�[�g���̍쐬]
        /// <summary>
        /// �n��ʃ\�[�g���̍쐬
        /// </summary>
        /// <param name="campaignRsltList">UI���o�����N���X</param>
        /// <returns>strSortOrder</returns>
        /// <remarks>
        /// <br>Note       : �n��ʃ\�[�g�����쐬����B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/26</br>
        /// </remarks>
        private StringBuilder GetAreaSortOrder(CampaignRsltList campaignRsltList)
        {
            StringBuilder strSortOrder = new StringBuilder();

            if (campaignRsltList.OutputSort == 0) // 0�F�n��
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_AreaCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 1) // 1�F���Ӑ�
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC, {2} ASC", PMKHN02054EA.ct_Col_AddUpSecCode, PMKHN02054EA.ct_Col_AreaCode, PMKHN02054EA.ct_Col_CustomerCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 2) // 2�F�n��|���_
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_AreaCode, PMKHN02054EA.ct_Col_AddUpSecCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else if (campaignRsltList.OutputSort == 3) // 3�F�Ǘ����_
            {
                strSortOrder.Append(string.Format("{0} ASC, {1} ASC", PMKHN02054EA.ct_Col_ManageSectionCode, PMKHN02054EA.ct_Col_AreaCode));
                // �i��
                if (campaignRsltList.Detail == 0)
                {
                    // ��ٰ�ߺ���
                    if (campaignRsltList.Total == 0)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                    // BL����
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                        if (campaignRsltList.PrintType != 1)
                        {
                            // �i�ԁ{Ұ��
                            if (campaignRsltList.PrintSort == 0)
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsNo, PMKHN02054EA.ct_Col_GoodsMakerCd));
                            }
                            // Ұ���{�i��
                            else
                            {
                                strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_GoodsMakerCd, PMKHN02054EA.ct_Col_GoodsNo));
                            }
                        }
                        else
                        {
                            strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_GoodsNo));
                        }
                    }
                }
                // BL����
                else if (campaignRsltList.Detail == 1)
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGoodsCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGoodsCode));
                    }
                }
                // ��ٰ�ߺ���
                else
                {
                    if (campaignRsltList.PrintType != 1)
                    {
                        strSortOrder.Append(string.Format(", {0} ASC, {1} ASC", PMKHN02054EA.ct_Col_BLGroupCode, PMKHN02054EA.ct_Col_GoodsMakerCd));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format(", {0} ASC", PMKHN02054EA.ct_Col_BLGroupCode));
                    }
                }
            }
            else
            {
                // �Ȃ�
            }

            return strSortOrder;
        }
        #endregion //�n��ʃ\�[�g���̍쐬

        #endregion // �\�[�g���̍쐬

        #endregion

        #region Dictionary��Value�p�N���X
        /// <summary>
        /// Dictionary��Value�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note		: Dictionary��Value�p�N���X���쐬����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        class CampaignTargetValue
        {
            #region private members
            /// <summary>���Ԕ���ڕW���z1</summary>
            private Int64 _monthlySalesTarget1;

            /// <summary>������ԖڕW���z1</summary>
            private Int64 _termSalesTarget1;

            /// <summary>���㌎�ԖڕW�e���z1</summary>
            private Int64 _monthlySalesTargetProfit1;

            /// <summary>������ԖڕW�e���z1</summary>
            private Int64 _termSalesTargetProfit1;

            /// <summary>���㌎�ԖڕW����1</summary>
            private Double _monthlySalesTargetCount1;

            /// <summary>�S������ԖڕW����1</summary>
            private Double _termSalesTargetCount1;

            /// <summary>���Ԕ���ڕW���z2</summary>
            private Int64 _monthlySalesTarget2;

            /// <summary>������ԖڕW���z2</summary>
            private Int64 _termSalesTarget2;

            /// <summary>���㌎�ԖڕW�e���z2</summary>
            private Int64 _monthlySalesTargetProfit2;

            /// <summary>������ԖڕW�e���z2</summary>
            private Int64 _termSalesTargetProfit2;

            /// <summary>���㌎�ԖڕW����2</summary>
            private Double _monthlySalesTargetCount2;

            /// <summary>������ԖڕW����2</summary>
            private Double _termSalesTargetCount2;

            /// <summary>���Ԕ���ڕW���z3</summary>
            private Int64 _monthlySalesTarget3;

            /// <summary>������ԖڕW���z3</summary>
            private Int64 _termSalesTarget3;

            /// <summary>���㌎�ԖڕW�e���z3</summary>
            private Int64 _monthlySalesTargetProfit3;

            /// <summary>������ԖڕW�e���z3</summary>
            private Int64 _termSalesTargetProfit3;

            /// <summary>���㌎�ԖڕW����3</summary>
            private Double _monthlySalesTargetCount3;

            /// <summary>�S������ԖڕW����3</summary>
            private Double _termSalesTargetCount3;
            #endregion

            #region Public propaty
            /// public propaty name  :  MonthlySalesTarget1
            /// <summary>���Ԕ���ڕW���z1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���Ԕ���ڕW���z1�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTarget1
            {
                get { return _monthlySalesTarget1; }
                set { _monthlySalesTarget1 = value; }
            }

            /// public propaty name  :  TermSalesTarget1
            /// <summary>������ԖڕW���z1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW���z1�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTarget1
            {
                get { return _termSalesTarget1; }
                set { _termSalesTarget1 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit1
            /// <summary>���㌎�ԖڕW�e���z1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW�e���z1�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit1
            {
                get { return _monthlySalesTargetProfit1; }
                set { _monthlySalesTargetProfit1 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit1
            /// <summary>������ԖڕW�e���z1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW�e���v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit1
            {
                get { return _termSalesTargetProfit1; }
                set { _termSalesTargetProfit1 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount1
            /// <summary>���㌎�ԖڕW����1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW����1�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double MonthlySalesTargetCount1
            {
                get { return _monthlySalesTargetCount1; }
                set { _monthlySalesTargetCount1 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount1
            /// <summary>������ԖڕW����1�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW����1�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TermSalesTargetCount1
            {
                get { return _termSalesTargetCount1; }
                set { _termSalesTargetCount1 = value; }
            }

            /// public propaty name  :  MonthlySalesTarget2
            /// <summary>���Ԕ���ڕW���z2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���Ԕ���ڕW���z2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTarget2
            {
                get { return _monthlySalesTarget2; }
                set { _monthlySalesTarget2 = value; }
            }
            /// public propaty name  :  TermSalesTarget2
            /// <summary>������ԖڕW���z2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW���z2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTarget2
            {
                get { return _termSalesTarget2; }
                set { _termSalesTarget2 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit2
            /// <summary>���㌎�ԖڕW�e���z2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW�e���z2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit2
            {
                get { return _monthlySalesTargetProfit2; }
                set { _monthlySalesTargetProfit2 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit2
            /// <summary>������ԖڕW�e���z2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW�e���z2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit2
            {
                get { return _termSalesTargetProfit2; }
                set { _termSalesTargetProfit2 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount2
            /// <summary>���㌎�ԖڕW����2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW����2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double MonthlySalesTargetCount2
            {
                get { return _monthlySalesTargetCount2; }
                set { _monthlySalesTargetCount2 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount2
            /// <summary>������ԖڕW����2�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW����2�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TermSalesTargetCount2
            {
                get { return _termSalesTargetCount2; }
                set { _termSalesTargetCount2 = value; }
            }

            /// public propaty name  :  MonthlySalesTarget1
            /// <summary>���Ԕ���ڕW���z3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���Ԕ���ڕW���z3�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTarget3
            {
                get { return _monthlySalesTarget3; }
                set { _monthlySalesTarget3 = value; }
            }

            /// public propaty name  :  TermSalesTarget3
            /// <summary>������ԖڕW���z3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW���z3�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTarget3
            {
                get { return _termSalesTarget3; }
                set { _termSalesTarget3 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetProfit3
            /// <summary>���㌎�ԖڕW�e���z3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW�e���z3�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 MonthlySalesTargetProfit3
            {
                get { return _monthlySalesTargetProfit3; }
                set { _monthlySalesTargetProfit3 = value; }
            }
            /// public propaty name  :  TermSalesTargetProfit3
            /// <summary>������ԖڕW�e���z3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW�e���v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int64 TermSalesTargetProfit3
            {
                get { return _termSalesTargetProfit3; }
                set { _termSalesTargetProfit3 = value; }
            }

            /// public propaty name  :  MonthlySalesTargetCount3
            /// <summary>���㌎�ԖڕW����3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���㌎�ԖڕW����3�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double MonthlySalesTargetCount3
            {
                get { return _monthlySalesTargetCount3; }
                set { _monthlySalesTargetCount3 = value; }
            }
            /// public propaty name  :  TermSalesTargetCount3
            /// <summary>������ԖڕW����3�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ������ԖڕW����3�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TermSalesTargetCount3
            {
                get { return _termSalesTargetCount3; }
                set { _termSalesTargetCount3 = value; }
            }
            #endregion
        }

        /// <summary>
        /// Dictionary��Value�p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note		: Dictionary��Value�p�N���X���쐬����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        class DateTerm
        {
            #region private members

            /// <summary>�J�n</summary>
            private DateTime _dateTimeSt;
            /// <summary>�I��</summary>
            private DateTime _dateTimeEd;

            #endregion

            #region Public propaty

            /// public propaty name  :  DateTimeSt
            /// <summary>�J�n�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �J�n�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public DateTime DateTimeSt
            {
                get { return _dateTimeSt; }
                set { _dateTimeSt = value; }
            }
            /// public propaty name  :  DateTimeEd
            /// <summary>�I���v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �I���v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public DateTime DateTimeEd
            {
                get { return _dateTimeEd; }
                set { _dateTimeEd = value; }
            }
            #endregion
        }
        #endregion        
    }
}
