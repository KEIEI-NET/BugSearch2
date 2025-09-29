using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �ڕW�}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note			 : �ڕW�}�X�^�ւ̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.05.08</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// </remarks>
	public class SalesTargetAcs
	{
		#region Public Constant

		/// <summary>�ڕW�}�X�^�e�[�u����</summary>
		public const string CT_SalesTargetDataTable = "CsSalesTargetDataTable";

        #endregion Public Constant

        #region Private Constant

        /// <summary>�ڕW�}�X�^�e�[�u����</summary>
		private const string CT_CsSalesTargetDataTable = Broadleaf.Application.UIData.SalesTarget.CT_CsSalesTargetDataTable;
        /// <summary>�ڕW�o�b�t�@�f�[�^�e�[�u����</summary>
        private const string CT_CsSalesTargetBuffDataTable = Broadleaf.Application.UIData.SalesTarget.CT_CsSalesTargetBuffDataTable;

        #endregion Private Constant

        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I�����C�����[�h�̗񋓌^�ł��B
		/// </summary>
		/// <remarks>
		/// <br>Note	   : </br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		public enum OnlineMode
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online
		}
		#endregion

		#region static variable

		/// <summary>�����_�R�[�h</summary>
		private static string _mySectionCode = "";

		/// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
		private static PrtOutSet _prtOutSetData = null;

		#endregion static variable

		#region Private Member

		/// <summary>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�A�N�Z�X�N���X</summary>
		private EmpSalesTargetAcs _empSalesTargetAcs;
        /// <summary>���i�ʔ���ڕW�ݒ茟���}�X�^�A�N�Z�X�N���X</summary>
		private GcdSalesTargetAcs _gcdSalesTargetAcs;

//----- ueno add---------- start 2007.11.21
		/// <summary>���Ӑ�ʔ���ڕW�ݒ茟���}�X�^�A�N�Z�X�N���X</summary>
		private CustSalesTargetAcs _custSalesTargetAcs;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		///// <summary>����`���ʔ���ڕW�ݒ�}�X�^�A�N�Z�X�N���X</summary>
		//private SformSlTargetAcs _sformSlTargetAcs;
		///// <summary>�̔��`�ԕʔ���ڕW�ݒ�}�X�^�A�N�Z�X�N���X</summary>
		//private SfcdSalesTargetAcs _sfcdSalesTargetAcs;
		//----- ueno del---------- end   2007.11.21

        /// <summary>������я��擾�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ITrgtCompSalesRsltDB _iTrgtCompSalesRsltDB = null;

		//----- ueno del---------- start 2007.11.21
		///// <summary>���n�v�Z�䗦�Ǘ��ݒ�p�A�N�Z�X�N���X</summary>
		//private LdgCalcRatioMngAcs _ldgCalcRatioMngAcs;
		///// <summary>�x�Ɠ��ݒ�}�X�^�A�N�Z�X�N���X</summary>
		//private HolidaySettingAcs _holidaySettingAcs;
		//----- ueno del---------- end   2007.11.21

		/// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
		private static PrtOutSetAcs prtOutSetAcs = null;
		/// <summary>����pDataSet</summary>
		public DataSet _printDataSet;
        /// <summary>���_���A�N�Z�X�N���X</summary>
        private SecInfoAcs _secInfoAcs;
        /// <summary>���_�����X�g</summary>
        private Dictionary<string, string> _sctionNameList;

		#endregion Private Member

		#region Constructor

        /*----------------------------------------------------------------------------------*/
        /// <summary>
		/// �ڕW�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note	   : �����[�g�I�u�W�F�N�g���C���X�^���X�����܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		public SalesTargetAcs()
		{
			// �e�ڕW�ݒ�}�X�^�A�N�Z�X�N���X
			this._empSalesTargetAcs = new EmpSalesTargetAcs();
			this._gcdSalesTargetAcs = new GcdSalesTargetAcs();

//----- ueno add---------- start 2007.11.21
			this._custSalesTargetAcs = new CustSalesTargetAcs();
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//this._sformSlTargetAcs = new SformSlTargetAcs();
			//this._sfcdSalesTargetAcs = new SfcdSalesTargetAcs();
			//----- ueno del---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// ���n�v�Z�䗦�Ǘ��ݒ�p�A�N�Z�X�N���X�C���X�^���X��
			//this._ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();

			//this._holidaySettingAcs = new HolidaySettingAcs();
			//----- ueno del---------- end   2007.11.21

            // �I�����C���̏ꍇ
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iTrgtCompSalesRsltDB = (ITrgtCompSalesRsltDB)MediationTrgtCompSalesRsltDB.GetTrgtCompSalesRsltDB();
                }
                catch (Exception)
                {
                    this._iTrgtCompSalesRsltDB = null;
                }
            }
            else
            // �I�t���C���̏ꍇ
            {
                // �I�t���C������null���Z�b�g
                this._iTrgtCompSalesRsltDB = null;
            }

            // ���_�����X�g���쐬
            SecInfoSet secInfoSet;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._sctionNameList = new Dictionary<string, string>();
            foreach (SecInfoSet secInfoSetWk in this._secInfoAcs.SecInfoSetList)
            {
                this._sctionNameList.Add(secInfoSetWk.SectionCode, secInfoSetWk.SectionGuideNm);
            }

			// ����pDataSet
			this._printDataSet = new DataSet();
			DataSetColumnConstruction(ref this._printDataSet);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
		/// ����`�F�b�N���X�g�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
		/// </summary>
		/// <remarks>
		/// <br>Note	   : </br>
		/// <br>Programer  : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		static SalesTargetAcs()
		{
            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
            prtOutSetAcs = new PrtOutSetAcs();

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                _mySectionCode = loginEmployee.BelongSectionCode;
            }
		}

		#endregion Constructor

		#region Public Methods
        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note	   : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			prtOutSet = null;
			message = "";
			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (_prtOutSetData != null)
				{
					prtOutSet = _prtOutSetData.Clone();
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					status = prtOutSetAcs.Read(out _prtOutSetData, LoginInfoAcquisition.EnterpriseCode, _mySectionCode);

					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							prtOutSet = _prtOutSetData.Clone();
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
							prtOutSet = new PrtOutSet();
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							break;
						default:
							prtOutSet = new PrtOutSet();
							message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							break;
					}
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note	   : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
        public int GetOnlineMode()
        {
            if (this._iTrgtCompSalesRsltDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note	   : �o�^�E�X�V�������s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		public int Write(ref List<SalesTarget> salesTargetList)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (salesTargetList.Count <= 0)
            {
                return (status);
            }

            switch (salesTargetList[0].TargetContrastCd)
            {
				//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.Section:
                case (int)SalesTarget.ConstrastCd.SecAndSubSec:
                //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:
                case (int)SalesTarget.ConstrastCd.SecAndEmp:
				//----- ueno upd---------- end   2007.11.21
					// �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    List<EmpSalesTarget> empSalesTargetList;
                    empSalesTargetList = CopyToEmpSalesTargetFromSalesTarget(salesTargetList);
                    status = this._empSalesTargetAcs.Write(ref empSalesTargetList);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    salesTargetList = CopyToSalesTargetFromEmpSalesTarget(empSalesTargetList);
                    break;

				//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndMaker:
                case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:
				//----- ueno upd---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                case (int)SalesTarget.ConstrastCd.SecAndBLGroup:
                case (int)SalesTarget.ConstrastCd.SecAndBlCode:
                case (int)SalesTarget.ConstrastCd.SecAndSalesType:
                case (int)SalesTarget.ConstrastCd.SecAndItemType:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

					// ���i�ʔ���ڕW�ݒ�}�X�^
                    List<GcdSalesTarget> gcdSalesTargetList;
                    gcdSalesTargetList = CopyToGcdSalesTargetFromSalesTarget(salesTargetList);
                    status = this._gcdSalesTargetAcs.Write(ref gcdSalesTargetList);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    salesTargetList = CopyToSalesTargetFromGcdSalesTarget(gcdSalesTargetList);
                    break;

//----- ueno add---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndCust:
				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:
				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:
					// ���Ӑ�ʔ���ڕW�ݒ�}�X�^
					List<CustSalesTarget> custSalesTargetList;
					custSalesTargetList = CopyToCustSalesTargetFromSalesTarget(salesTargetList);
					status = this._custSalesTargetAcs.Write(ref custSalesTargetList);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return (status);
					}
					salesTargetList = CopyToSalesTargetFromCustSalesTarget(custSalesTargetList);
					break;
//----- ueno add---------- end   2007.11.21


				//----- ueno del---------- start 2007.11.21
				//case (int)SalesTarget.ConstrastCd.SalesFormal:
				//    // ����`���ʔ���ڕW�ݒ�}�X�^
				//    List<SformSlTarget> sformSlTargetList;
				//    sformSlTargetList = CopyToSformSlTargetFromSalesTarget(salesTargetList);
				//    status = this._sformSlTargetAcs.Write(ref sformSlTargetList);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    salesTargetList = CopyToSalesTargetFromSformSlTarget(sformSlTargetList);
				//    break;

				//case (int)SalesTarget.ConstrastCd.SalesForm:
				//    // �̔��`�ԕʔ���ڕW�ݒ�}�X�^
				//    List<SfcdSalesTarget> sfcdSalesTargetList;
				//    sfcdSalesTargetList = CopyToSfcdSalesTargetFromSalesTarget(salesTargetList);
				//    status = this._sfcdSalesTargetAcs.Write(ref sfcdSalesTargetList);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    salesTargetList = CopyToSalesTargetFromSfcdSalesTarget(sfcdSalesTargetList);
				//    break;
				//----- ueno del---------- end   2007.11.21
            }

            return (status);

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="salesTargetList">�ڕW�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �폜�������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Delete(List<SalesTarget> salesTargetList)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (salesTargetList.Count <= 0)
            {
                return (status);
            }

            switch (salesTargetList[0].TargetContrastCd)
            {
				//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.Section:
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:
				//case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:
				case (int)SalesTarget.ConstrastCd.SecAndEmp:
				//----- ueno upd---------- end   2007.11.21
                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    List<EmpSalesTarget> empSalesTargetList;
                    empSalesTargetList = CopyToEmpSalesTargetFromSalesTarget(salesTargetList);
                    status = this._empSalesTargetAcs.Delete(empSalesTargetList);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    break;

				//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndMaker:
				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:
				//----- ueno upd---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                case (int)SalesTarget.ConstrastCd.SecAndBLGroup:
                case (int)SalesTarget.ConstrastCd.SecAndBlCode:
                case (int)SalesTarget.ConstrastCd.SecAndSalesType:
                case (int)SalesTarget.ConstrastCd.SecAndItemType:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
                    // ���i�ʔ���ڕW�ݒ�}�X�^
                    List<GcdSalesTarget> gcdSalesTargetList;
                    gcdSalesTargetList = CopyToGcdSalesTargetFromSalesTarget(salesTargetList);
                    status = this._gcdSalesTargetAcs.Delete(gcdSalesTargetList);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    break;

//----- ueno add---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndCust:
				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:
				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:
					// ���Ӑ�ʔ���ڕW�ݒ�}�X�^
					List<CustSalesTarget> custSalesTargetList;
					custSalesTargetList = CopyToCustSalesTargetFromSalesTarget(salesTargetList);
					status = this._custSalesTargetAcs.Delete(custSalesTargetList);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return (status);
					}
					salesTargetList = CopyToSalesTargetFromCustSalesTarget(custSalesTargetList);
					break;
//----- ueno add---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				//case (int)SalesTarget.ConstrastCd.SalesFormal:
				//    // ����`���ʔ���ڕW�ݒ�}�X�^
				//    List<SformSlTarget> sformSlTargetList;
				//    sformSlTargetList = CopyToSformSlTargetFromSalesTarget(salesTargetList);
				//    status = this._sformSlTargetAcs.Delete(sformSlTargetList);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    break;

				//case (int)SalesTarget.ConstrastCd.SalesForm:
				//    // �̔��`�ԕʔ���ڕW�ݒ�}�X�^
				//    List<SfcdSalesTarget> sfcdSalesTargetList;
				//    sfcdSalesTargetList = CopyToSfcdSalesTargetFromSalesTarget(salesTargetList);
				//    status = this._sfcdSalesTargetAcs.Delete(sfcdSalesTargetList);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    break;
				//----- ueno del---------- end   2007.11.21
            }

            return (status);

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="salesTargetList">�擾�����ڕW�f�[�^</param>
        /// <param name="extrInfo">��������</param>
        /// <param name="logicalMode">�폜�t���O</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : �����������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Search(
            out List<SalesTarget> salesTargetList,
            ExtrInfo_MAMOK09197EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            salesTargetList = new List<SalesTarget>();

//----- ueno add---------- start 2007.11.21
			// ���_�E�]�ƈ������p
			List<EmpSalesTarget> empSalesTargetList;
			ExtrInfo_MAMOK09117EA extrInfo_MAMOK09117EA;
//----- ueno add---------- end   2007.11.21

            switch (extrInfo.TargetContrastCd)
            {
//----- ueno add---------- start 2007.11.21
				//----- ���_ -----//
				case (int)SalesTarget.ConstrastCd.Section:
					
					// �]�ƈ��ʔ���ڕW�ݒ�}�X�^
					extrInfo_MAMOK09117EA = CopyToEmpExtrInfoFromExtrInfo(extrInfo);

					status = this._empSalesTargetAcs.Search(out empSalesTargetList, extrInfo_MAMOK09117EA, ConstantManagement.LogicalMode.GetData0);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return (status);
					}
					salesTargetList = CopyToSalesTargetFromEmpSalesTarget(empSalesTargetList);
					break;
//----- ueno add---------- end   2007.11.21

				//----- ueno upd---------- start 2007.11.21
				// �]�ƈ�
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:
				//case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:
				case (int)SalesTarget.ConstrastCd.SecAndEmp:
				//----- ueno upd---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
					// �ڕW�Δ�敪�N���A�i�N���A���Ȃ��ƑS�ڕW�Δ�敪���擾�ł��Ȃ����߁j
					extrInfo.TargetContrastCd = 0;
//----- ueno add---------- end   2007.11.21

                    // �]�ƈ��ʔ���ڕW�ݒ�}�X�^
                    extrInfo_MAMOK09117EA = CopyToEmpExtrInfoFromExtrInfo(extrInfo);

                    status = this._empSalesTargetAcs.Search(out empSalesTargetList, extrInfo_MAMOK09117EA, ConstantManagement.LogicalMode.GetData0);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    salesTargetList = CopyToSalesTargetFromEmpSalesTarget(empSalesTargetList);
                    break;

				//----- ueno upd---------- start 2007.11.21
				//----- ���i -----//
				case (int)SalesTarget.ConstrastCd.SecAndMaker:
				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:
				//----- ueno upd---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                case (int)SalesTarget.ConstrastCd.SecAndBLGroup:
                case (int)SalesTarget.ConstrastCd.SecAndBlCode:
                case (int)SalesTarget.ConstrastCd.SecAndSalesType:
                case (int)SalesTarget.ConstrastCd.SecAndItemType:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

//----- ueno add---------- start 2007.11.21
					// �ڕW�Δ�敪�N���A�i�N���A���Ȃ��ƑS�ڕW�Δ�敪���擾�ł��Ȃ����߁j
					extrInfo.TargetContrastCd = 0;
//----- ueno add---------- end   2007.11.21

					// ���i�ʔ���ڕW�ݒ�}�X�^
                    List<GcdSalesTarget> gcdSalesTargetList;
                    ExtrInfo_MAMOK09137EA extrInfo_MAMOK09137EA = CopyToGcdExtrInfoFromExtrInfo(extrInfo);
					
                    status = this._gcdSalesTargetAcs.Search(out gcdSalesTargetList, extrInfo_MAMOK09137EA, ConstantManagement.LogicalMode.GetData0);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    salesTargetList = CopyToSalesTargetFromGcdSalesTarget(gcdSalesTargetList);
                    break;

//----- ueno add---------- start 2007.11.21
				//----- ���Ӑ� -----//
				case (int)SalesTarget.ConstrastCd.SecAndCust:
				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:
				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:

					// �ڕW�Δ�敪�N���A�i�N���A���Ȃ��ƑS�ڕW�Δ�敪���擾�ł��Ȃ����߁j
					extrInfo.TargetContrastCd = 0;

					// ���Ӑ�ʔ���ڕW�ݒ�}�X�^
					List<CustSalesTarget> custSalesTargetList;
					ExtrInfo_DCKHN09193EA extrInfo_DCKHN09193EA = CopyToCustExtrInfoFromExtrInfo(extrInfo);
					
					status = this._custSalesTargetAcs.Search(out custSalesTargetList, extrInfo_DCKHN09193EA, ConstantManagement.LogicalMode.GetData0);
					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return (status);
					}
					salesTargetList = CopyToSalesTargetFromCustSalesTarget(custSalesTargetList);
					break;
//----- ueno add---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				//case (int)SalesTarget.ConstrastCd.SalesFormal:
				//    // ����`���ʔ���ڕW�ݒ�}�X�^
				//    List<SformSlTarget> sformSlTargetList;
				//    ExtrInfo_MAMOK09157EA extrInfo_MAMOK09157EA = CopyToSformExtrInfoFromExtrInfo(extrInfo);
				//    status = this._sformSlTargetAcs.Search(out sformSlTargetList, extrInfo_MAMOK09157EA, ConstantManagement.LogicalMode.GetData0);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    salesTargetList = CopyToSalesTargetFromSformSlTarget(sformSlTargetList);
				//    break;

				//case (int)SalesTarget.ConstrastCd.SalesForm:
				//    // �̔��`�ԕʔ���ڕW�ݒ�}�X�^
				//    List<SfcdSalesTarget> sfcdSalesTargetList;
				//    ExtrInfo_MAMOK09177EA extrInfo_MAMOK09177EA = CopyToSfcdExtrInfoFromExtrInfo(extrInfo);
				//    status = this._sfcdSalesTargetAcs.Search(out sfcdSalesTargetList, extrInfo_MAMOK09177EA, ConstantManagement.LogicalMode.GetData0);
				//    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				//    {
				//        return (status);
				//    }
				//    salesTargetList = CopyToSalesTargetFromSfcdSalesTarget(sfcdSalesTargetList);
				//    break;
				//----- ueno del---------- end   2007.11.21
			}

            return (status);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�}�X�^��������(���[�p)
        /// </summary>
        /// <param name="extrInfoMAMOK02121EA">��������</param>
        /// <param name="salesTargetDataSet">�擾�����f�[�^</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int SearchContrast(
            ExtrInfo_MAMOK02121EA extrInfoMAMOK02121EA,
            out DataSet salesTargetDataSet, 
            out string message)
        {
            return (SearchContrastMain(extrInfoMAMOK02121EA, 0, out salesTargetDataSet, out message));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�}�X�^��������(�O���t�p)
        /// </summary>
        /// <param name="extrInfoMAMOK02121EA">��������</param>
        /// <param name="salesTargetDataSet">�擾�����f�[�^</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int SearchContrastDays(
            ExtrInfo_MAMOK02121EA extrInfoMAMOK02121EA, 
            out DataSet salesTargetDataSet, 
            out string message)
        {
            return (SearchContrastMain(extrInfoMAMOK02121EA, 1, out salesTargetDataSet, out message));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����f�[�^��������
        /// </summary>
        /// <param name="retList">����f�[�^</param>
        /// <param name="extrInfo">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : ����f�[�^���������܂�</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int SearchSalesRslt(
            out List<TrgtCompSalesRslt> retList,
            ExtrInfo_MAMOK09197EA extrInfo)
        {
            int status;

            retList = new List<TrgtCompSalesRslt>();

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // �p�����[�^
                    TrgtCompSalesRsltParaWork trgtCompSalesRsltParaWork = CopyToTrgtCompSalesRsltParaWorkFromExtrInfo(extrInfo);

                    // ������я�񌟍�
                    object objectTrgtCompSalesRsltWork = null;
                    status = this._iTrgtCompSalesRsltDB.Search(out objectTrgtCompSalesRsltWork, trgtCompSalesRsltParaWork);
                    if (status != 0)
                    {
                        return (status);
                    }

                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList paraList = objectTrgtCompSalesRsltWork as ArrayList;
                    if (paraList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (TrgtCompSalesRsltWork trgtCompSalesRsltWork in paraList)
                    {
                        retList.Add(CopyTrgtCompSalesRsltFromTrgtCompSalesRsltWork(trgtCompSalesRsltWork));
                    }
                }
                catch
                {
                    return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                }

                return ((int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL);

            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
		/// �ڕW�}�X�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note	   : Static�������������܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
			// --�e�[�u���s������-----------------------
			// ���o���ʃf�[�^�e�[�u�����N���A
			if (this._printDataSet.Tables[CT_CsSalesTargetDataTable] != null)
			{
				this._printDataSet.Tables[CT_CsSalesTargetDataTable].Rows.Clear();
			}
			// ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
			if (this._printDataSet.Tables[CT_CsSalesTargetBuffDataTable] != null)
			{
				this._printDataSet.Tables[CT_CsSalesTargetBuffDataTable].Rows.Clear();
			}
		}

		#endregion

		# region Private Methods

		private void DataSetColumnConstruction(ref DataSet ds)
		{
			// ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
			// ����`�F�b�N���X�g(�w�b�_)
			Broadleaf.Application.UIData.SalesTarget.SettingDataSet(ref ds);
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�}�X�^��������
        /// </summary>
        /// <param name="extrInfoMAMOK02121EA">��������</param>
        /// <param name="mode">���[�h(0:���[�A1:�O���t)</param>
        /// <param name="salesTargetDataSet">�擾�����f�[�^</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private int SearchContrastMain(
            ExtrInfo_MAMOK02121EA extrInfoMAMOK02121EA,
            int mode,
            out DataSet salesTargetDataSet,
            out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<SalesTarget> salesTargetList;

            message = "";
            salesTargetDataSet = null;

			//----- ueno del---------- start 2007.11.21
			#region del
			//// ���n�v�Z�䗦�Ǘ��}�X�^�擾
			//List<LdgCalcRatioMng> ldgCalcRatioMngList;
			//status = this._ldgCalcRatioMngAcs.Search(
			//    out ldgCalcRatioMngList,
			//    LoginInfoAcquisition.EnterpriseCode,
			//    extrInfoMAMOK02121EA.SelectSectCd);
			//switch (status)
			//{
			//    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
			//    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
			//    case (int)ConstantManagement.DB_Status.ctDB_EOF:
			//        // ����
			//        break;
			//    default:
			//        // �G���[
			//        return (status);
			//}

			//// �x�Ɠ��ݒ�}�X�^�擾
			//Dictionary<SectionAndDate, HolidaySetting> holidaySettingDic;
			//status = this._holidaySettingAcs.SearchSecList(
			//    out holidaySettingDic,
			//    LoginInfoAcquisition.EnterpriseCode,
			//    extrInfoMAMOK02121EA.SelectSectCd,
			//    DateTime.MinValue,
			//    DateTime.MaxValue);
			//switch (status)
			//{
			//    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
			//    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
			//    case (int)ConstantManagement.DB_Status.ctDB_EOF:
			//        // ����
			//        break;
			//    default:
			//        // �G���[
			//        return (status);
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21
			
            // ���������ϊ�
            ExtrInfo_MAMOK09197EA extrInfoMAMOK09197EA = CopyToExtrInfoFromExtrInfoContrast(extrInfoMAMOK02121EA);

            // �ڕW�f�[�^�̎擾
            List<SalesTarget> salesTargetListWk;
            status = Search(out salesTargetListWk, extrInfoMAMOK09197EA, ConstantManagement.LogicalMode.GetData0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return (status);
            }

            // �ڕW�敪���̂���ъ��Ԃ��قȂ���̂�����
            salesTargetList = salesTargetListWk.FindAll(delegate(SalesTarget salesTarget)
            {
                if (salesTarget.TargetDivideName.TrimEnd() != extrInfoMAMOK02121EA.TargetDivideName.TrimEnd())
                {
                    return (false);
                }
                if (salesTarget.ApplyStaDate != extrInfoMAMOK02121EA.ApplyStaDateSt)
                {
                    return (false);
                }
                if (salesTarget.ApplyEndDate != extrInfoMAMOK02121EA.ApplyEndDateEd)
                {
                    return (false);
                }
                return (true);
            });
            if (salesTargetList.Count <= 0)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_EOF);
            }

            // ����f�[�^�̎擾
            List<TrgtCompSalesRslt> salesRsltList;
            status = SearchSalesRslt(out salesRsltList, extrInfoMAMOK09197EA);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    break;
                default:
                    return (status);
            }

            // �ڕW�}�X�^���X�g��DataSet�ɕϊ�
            if (mode == 0)
            {
                //
                // ���[�̏ꍇ
                //
                status = ConvertSalesTargetToDataSet(
                    extrInfoMAMOK02121EA,
                    salesTargetList,
                    salesRsltList,
					//----- ueno del---------- start 2007.11.21
					//ldgCalcRatioMngList,
					//holidaySettingDic,
					//----- ueno del---------- end   2007.11.21
                    out salesTargetDataSet,
                    out message);
            }
            else
            {
                //
                // �O���t�̏ꍇ
                //
                status = ConvertSalesTargetToDataSetChart(
                    extrInfoMAMOK02121EA,
                    salesTargetList,
                    salesRsltList,
					//----- ueno del---------- start 2007.11.21
					//ldgCalcRatioMngList,
					//holidaySettingDic,
					//----- ueno del---------- end   2007.11.21
                    out salesTargetDataSet,
                    out message);
            }

            return (status);

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW����Δ�\(���)���o�����N���X�˖ڕW�}�X�^�����ݒ�N���X�j
        /// </summary>
        /// <param name="extrInfo_MAMOK02121EA">�ڕW����Δ�\(���)���o�����N���X</param>
        /// <returns>�ڕW�}�X�^�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW����Δ�\(���)���o�����N���X����ڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.04.19</br>
        /// </remarks>
        private ExtrInfo_MAMOK09197EA CopyToExtrInfoFromExtrInfoContrast(ExtrInfo_MAMOK02121EA extrInfo_MAMOK02121EA)
        {
            ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA = new ExtrInfo_MAMOK09197EA();

            extrInfo_MAMOK09197EA.EnterpriseCode = extrInfo_MAMOK02121EA.EnterpriseCode;
            extrInfo_MAMOK09197EA.ApplyStaDateSt = extrInfo_MAMOK02121EA.ApplyStaDateSt;
            extrInfo_MAMOK09197EA.ApplyStaDateEd = extrInfo_MAMOK02121EA.ApplyStaDateEd;
            extrInfo_MAMOK09197EA.ApplyEndDateSt = extrInfo_MAMOK02121EA.ApplyEndDateSt;
            extrInfo_MAMOK09197EA.ApplyEndDateEd = extrInfo_MAMOK02121EA.ApplyEndDateEd;
            extrInfo_MAMOK09197EA.SelectSectCd = extrInfo_MAMOK02121EA.SelectSectCd;
            extrInfo_MAMOK09197EA.TargetSetCd = extrInfo_MAMOK02121EA.TargetSetCd;
            extrInfo_MAMOK09197EA.TargetContrastCd = extrInfo_MAMOK02121EA.TargetContrastCd;
            extrInfo_MAMOK09197EA.TargetDivideCode = extrInfo_MAMOK02121EA.TargetDivideCode;
            extrInfo_MAMOK09197EA.EmployeeCode = extrInfo_MAMOK02121EA.EmployeeCode;
			extrInfo_MAMOK09197EA.MakerCode = extrInfo_MAMOK02121EA.MakerCode;
			extrInfo_MAMOK09197EA.GoodsCode = extrInfo_MAMOK02121EA.GoodsCode;
//----- ueno add---------- start 2007.11.21
			extrInfo_MAMOK09197EA.EmployeeDivCd = extrInfo_MAMOK02121EA.EmployeeDivCd;
			extrInfo_MAMOK09197EA.SubSectionCode = extrInfo_MAMOK02121EA.SubSectionCode;
			extrInfo_MAMOK09197EA.MinSectionCode = extrInfo_MAMOK02121EA.MinSectionCode;
			extrInfo_MAMOK09197EA.BusinessTypeCode = extrInfo_MAMOK02121EA.BusinessTypeCode;
			extrInfo_MAMOK09197EA.SalesAreaCode = extrInfo_MAMOK02121EA.SalesAreaCode;
			extrInfo_MAMOK09197EA.CustomerCode = extrInfo_MAMOK02121EA.CustomerCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            //extrInfo_MAMOK09197EA.BusinessTypeName = extrInfo_MAMOK02121EA.BU

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//extrInfo_MAMOK09197EA.CarrierCode = extrInfo_MAMOK02121EA.CarrierCode;
			//extrInfo_MAMOK09197EA.CellphoneModelCode = extrInfo_MAMOK02121EA.CellphoneModelCode;
			//extrInfo_MAMOK09197EA.SalesFormal = extrInfo_MAMOK02121EA.SalesFormal;
			//extrInfo_MAMOK09197EA.SalesFormCode = extrInfo_MAMOK02121EA.SalesFormCode;
			//----- ueno del---------- end   2007.11.21

            return extrInfo_MAMOK09197EA;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�ˏ]�ƈ��ڕW�}�X�^�����ݒ�N���X�j
        /// </summary>
        /// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
        /// <returns>�]�ƈ��ʖڕW�}�X�^�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X����]�ƈ��ڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.04.19</br>
        /// </remarks>
        private ExtrInfo_MAMOK09117EA CopyToEmpExtrInfoFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
        {
            ExtrInfo_MAMOK09117EA extrInfo_MAMOK09117EA = new ExtrInfo_MAMOK09117EA();

            extrInfo_MAMOK09117EA.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
            extrInfo_MAMOK09117EA.ApplyStaDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
            extrInfo_MAMOK09117EA.ApplyStaDateEd = extrInfo_MAMOK09197EA.ApplyStaDateEd;
            extrInfo_MAMOK09117EA.ApplyEndDateSt = extrInfo_MAMOK09197EA.ApplyEndDateSt;
            extrInfo_MAMOK09117EA.ApplyEndDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
            // ���_
            if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
            {
                if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
                {
                    // �S�Ђ̎�
                    extrInfo_MAMOK09117EA.AllSecSelEpUnit = true;
                    extrInfo_MAMOK09117EA.AllSecSelSecUnit = true;
                }
                else
                {
                    extrInfo_MAMOK09117EA.AllSecSelEpUnit = false;
                    if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă���
                        extrInfo_MAMOK09117EA.AllSecSelSecUnit = true;
                    }
                    else
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
                        extrInfo_MAMOK09117EA.AllSecSelSecUnit = false;
                        extrInfo_MAMOK09117EA.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
                    }
                }
            }
            else
            {
                // �S���_�W�v���R�[�h�ł̏o��
                extrInfo_MAMOK09117EA.AllSecSelEpUnit = false;
                extrInfo_MAMOK09117EA.AllSecSelSecUnit = true;
            }
            extrInfo_MAMOK09117EA.TargetSetCd = extrInfo_MAMOK09197EA.TargetSetCd;
            extrInfo_MAMOK09117EA.TargetContrastCd = extrInfo_MAMOK09197EA.TargetContrastCd;
            extrInfo_MAMOK09117EA.TargetDivideCode = extrInfo_MAMOK09197EA.TargetDivideCode;
            extrInfo_MAMOK09117EA.TargetDivideName = extrInfo_MAMOK09197EA.TargetDivideName;
            extrInfo_MAMOK09117EA.EmployeeCode = extrInfo_MAMOK09197EA.EmployeeCode;
//----- ueno add---------- start 2007.11.21
			extrInfo_MAMOK09117EA.EmployeeDivCd = extrInfo_MAMOK09197EA.EmployeeDivCd;
			extrInfo_MAMOK09117EA.SubSectionCode = extrInfo_MAMOK09197EA.SubSectionCode;
			extrInfo_MAMOK09117EA.MinSectionCode = extrInfo_MAMOK09197EA.MinSectionCode;
//----- ueno add---------- end   2007.11.21

            return extrInfo_MAMOK09117EA;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�ˏ��i�ʔ���ڕW���������N���X�j
        /// </summary>
        /// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
        /// <returns>���i�ʖڕW�}�X�^�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X���珤�i�ʖڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.04.19</br>
        /// </remarks>
        private ExtrInfo_MAMOK09137EA CopyToGcdExtrInfoFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
        {
            ExtrInfo_MAMOK09137EA extrInfo_MAMOK09137EA = new ExtrInfo_MAMOK09137EA();

            extrInfo_MAMOK09137EA.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
            extrInfo_MAMOK09137EA.ApplyStaDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
            extrInfo_MAMOK09137EA.ApplyStaDateEd = extrInfo_MAMOK09197EA.ApplyStaDateEd;
            extrInfo_MAMOK09137EA.ApplyEndDateSt = extrInfo_MAMOK09197EA.ApplyEndDateSt;
            extrInfo_MAMOK09137EA.ApplyEndDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
            // ���_
            if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
            {
                if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
                {
                    // �S�Ђ̎�
                    extrInfo_MAMOK09137EA.AllSecSelEpUnit = true;
                    extrInfo_MAMOK09137EA.AllSecSelSecUnit = true;
                }
                else
                {
                    extrInfo_MAMOK09137EA.AllSecSelEpUnit = false;
                    if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă���
                        extrInfo_MAMOK09137EA.AllSecSelSecUnit = true;
                    }
                    else
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
                        extrInfo_MAMOK09137EA.AllSecSelSecUnit = false;
                        extrInfo_MAMOK09137EA.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
                    }
                }
            }
            else
            {
                // �S���_�W�v���R�[�h�ł̏o��
                extrInfo_MAMOK09137EA.AllSecSelEpUnit = false;
                extrInfo_MAMOK09137EA.AllSecSelSecUnit = true;
            }
            extrInfo_MAMOK09137EA.TargetSetCd = extrInfo_MAMOK09197EA.TargetSetCd;
            extrInfo_MAMOK09137EA.TargetContrastCd = extrInfo_MAMOK09197EA.TargetContrastCd;
            extrInfo_MAMOK09137EA.TargetDivideCode = extrInfo_MAMOK09197EA.TargetDivideCode;
            extrInfo_MAMOK09137EA.TargetDivideName = extrInfo_MAMOK09197EA.TargetDivideName;
			//----- ueno del---------- start 2007.11.21
			//extrInfo_MAMOK09137EA.CarrierCode = extrInfo_MAMOK09197EA.CarrierCode;
			//extrInfo_MAMOK09137EA.CellphoneModelCode = extrInfo_MAMOK09197EA.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            extrInfo_MAMOK09137EA.MakerCode = extrInfo_MAMOK09197EA.MakerCode;
            extrInfo_MAMOK09137EA.GoodsCode = extrInfo_MAMOK09197EA.GoodsCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            extrInfo_MAMOK09137EA.BLCode = extrInfo_MAMOK09197EA.BLCode;
            extrInfo_MAMOK09197EA.BLCodeName = extrInfo_MAMOK09197EA.BLCodeName;
            extrInfo_MAMOK09137EA.BLGroupCode = extrInfo_MAMOK09197EA.BLGroupCode;
            extrInfo_MAMOK09197EA.BLGroupName = extrInfo_MAMOK09197EA.BLGroupName;
            extrInfo_MAMOK09137EA.SalesTypeCode = extrInfo_MAMOK09197EA.SalesTypeCode;
            extrInfo_MAMOK09137EA.SalesTypeName = extrInfo_MAMOK09197EA.SalesTypeName;
            extrInfo_MAMOK09137EA.ItemTypeCode = extrInfo_MAMOK09197EA.ItemTypeCode;
            extrInfo_MAMOK09137EA.ItemTypeName = extrInfo_MAMOK09197EA.ItemTypeName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
            return extrInfo_MAMOK09137EA;
        }

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�˓��Ӑ�ڕW�}�X�^�����ݒ�N���X�j
		/// </summary>
		/// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
		/// <returns>���Ӑ�ʖڕW�}�X�^�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X���瓾�Ӑ�ڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date	   : 2007.11.21</br>
		/// </remarks>
		private ExtrInfo_DCKHN09193EA CopyToCustExtrInfoFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
		{
			ExtrInfo_DCKHN09193EA extrInfo_DCKHN09193EA = new ExtrInfo_DCKHN09193EA();

			extrInfo_DCKHN09193EA.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
			extrInfo_DCKHN09193EA.ApplyStaDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
			extrInfo_DCKHN09193EA.ApplyStaDateEd = extrInfo_MAMOK09197EA.ApplyStaDateEd;
			extrInfo_DCKHN09193EA.ApplyEndDateSt = extrInfo_MAMOK09197EA.ApplyEndDateSt;
			extrInfo_DCKHN09193EA.ApplyEndDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
			// ���_
			if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
			{
				if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
				{
					// �S�Ђ̎�
					extrInfo_DCKHN09193EA.AllSecSelEpUnit = true;
					extrInfo_DCKHN09193EA.AllSecSelSecUnit = true;
				}
				else
				{
					extrInfo_DCKHN09193EA.AllSecSelEpUnit = false;
					if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
					{
						// �S���_�Ƀ`�F�b�N�������Ă���
						extrInfo_DCKHN09193EA.AllSecSelSecUnit = true;
					}
					else
					{
						// �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
						extrInfo_DCKHN09193EA.AllSecSelSecUnit = false;
						extrInfo_DCKHN09193EA.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
					}
				}
			}
			else
			{
				// �S���_�W�v���R�[�h�ł̏o��
				extrInfo_DCKHN09193EA.AllSecSelEpUnit = false;
				extrInfo_DCKHN09193EA.AllSecSelSecUnit = true;
			}
			extrInfo_DCKHN09193EA.TargetSetCd = extrInfo_MAMOK09197EA.TargetSetCd;
			extrInfo_DCKHN09193EA.TargetContrastCd = extrInfo_MAMOK09197EA.TargetContrastCd;
			extrInfo_DCKHN09193EA.TargetDivideCode = extrInfo_MAMOK09197EA.TargetDivideCode;
			extrInfo_DCKHN09193EA.TargetDivideName = extrInfo_MAMOK09197EA.TargetDivideName;
			extrInfo_DCKHN09193EA.BusinessTypeCode = extrInfo_MAMOK09197EA.BusinessTypeCode;
			extrInfo_DCKHN09193EA.SalesAreaCode = extrInfo_MAMOK09197EA.SalesAreaCode;
			extrInfo_DCKHN09193EA.CustomerCode = extrInfo_MAMOK09197EA.CustomerCode;
			
			return extrInfo_DCKHN09193EA;
		}	
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�˔���`���ʖڕW�}�X�^�����ݒ�N���X�j
		///// </summary>
		///// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
		///// <returns>����`���ʖڕW�}�X�^�����ݒ�N���X</returns>
		///// <remarks>
		///// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X���甄��`���ʖڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.04.19</br>
		///// </remarks>
		//private ExtrInfo_MAMOK09157EA CopyToSformExtrInfoFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
		//{
		//    ExtrInfo_MAMOK09157EA extrInfo_MAMOK09157EA = new ExtrInfo_MAMOK09157EA();

		//    extrInfo_MAMOK09157EA.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
		//    extrInfo_MAMOK09157EA.ApplyStaDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
		//    extrInfo_MAMOK09157EA.ApplyStaDateEd = extrInfo_MAMOK09197EA.ApplyStaDateEd;
		//    extrInfo_MAMOK09157EA.ApplyEndDateSt = extrInfo_MAMOK09197EA.ApplyEndDateSt;
		//    extrInfo_MAMOK09157EA.ApplyEndDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
		//    // ���_
		//    if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
		//    {
		//        if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
		//        {
		//            // �S�Ђ̎�
		//            extrInfo_MAMOK09157EA.AllSecSelEpUnit = true;
		//            extrInfo_MAMOK09157EA.AllSecSelSecUnit = true;
		//        }
		//        else
		//        {
		//            extrInfo_MAMOK09157EA.AllSecSelEpUnit = false;
		//            if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
		//            {
		//                // �S���_�Ƀ`�F�b�N�������Ă���
		//                extrInfo_MAMOK09157EA.AllSecSelSecUnit = true;
		//            }
		//            else
		//            {
		//                // �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
		//                extrInfo_MAMOK09157EA.AllSecSelSecUnit = false;
		//                extrInfo_MAMOK09157EA.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
		//            }
		//        }
		//    }
		//    else
		//    {
		//        // �S���_�W�v���R�[�h�ł̏o��
		//        extrInfo_MAMOK09157EA.AllSecSelEpUnit = false;
		//        extrInfo_MAMOK09157EA.AllSecSelSecUnit = true;
		//    }
		//    extrInfo_MAMOK09157EA.TargetSetCd = extrInfo_MAMOK09197EA.TargetSetCd;
		//    extrInfo_MAMOK09157EA.TargetDivideCode = extrInfo_MAMOK09197EA.TargetDivideCode;
		//    extrInfo_MAMOK09157EA.TargetDivideName = extrInfo_MAMOK09197EA.TargetDivideName;
		//    extrInfo_MAMOK09157EA.SalesFormal = extrInfo_MAMOK09197EA.SalesFormal;

		//    return extrInfo_MAMOK09157EA;
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�˔̔��`�ԕʖڕW�}�X�^�����ݒ�N���X�j
		///// </summary>
		///// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
		///// <returns>�̔��`�ԕʖڕW�}�X�^�����ݒ�N���X</returns>
		///// <remarks>
		///// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X����̔��`�ԕʖڕW�}�X�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.04.19</br>
		///// </remarks>
		//private ExtrInfo_MAMOK09177EA CopyToSfcdExtrInfoFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
		//{
		//    ExtrInfo_MAMOK09177EA extrInfo_MAMOK09177EA = new ExtrInfo_MAMOK09177EA();

		//    extrInfo_MAMOK09177EA.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
		//    extrInfo_MAMOK09177EA.ApplyStaDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
		//    extrInfo_MAMOK09177EA.ApplyStaDateEd = extrInfo_MAMOK09197EA.ApplyStaDateEd;
		//    extrInfo_MAMOK09177EA.ApplyEndDateSt = extrInfo_MAMOK09197EA.ApplyEndDateSt;
		//    extrInfo_MAMOK09177EA.ApplyEndDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
		//    // ���_
		//    if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
		//    {
		//        if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
		//        {
		//            // �S�Ђ̎�
		//            extrInfo_MAMOK09177EA.AllSecSelEpUnit = true;
		//            extrInfo_MAMOK09177EA.AllSecSelSecUnit = true;
		//        }
		//        else
		//        {
		//            extrInfo_MAMOK09177EA.AllSecSelEpUnit = false;
		//            if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
		//            {
		//                // �S���_�Ƀ`�F�b�N�������Ă���
		//                extrInfo_MAMOK09177EA.AllSecSelSecUnit = true;
		//            }
		//            else
		//            {
		//                // �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
		//                extrInfo_MAMOK09177EA.AllSecSelSecUnit = false;
		//                extrInfo_MAMOK09177EA.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
		//            }
		//        }
		//    }
		//    else
		//    {
		//        // �S���_�W�v���R�[�h�ł̏o��
		//        extrInfo_MAMOK09177EA.AllSecSelEpUnit = false;
		//        extrInfo_MAMOK09177EA.AllSecSelSecUnit = true;
		//    }
		//    extrInfo_MAMOK09177EA.TargetSetCd = extrInfo_MAMOK09197EA.TargetSetCd;
		//    extrInfo_MAMOK09177EA.TargetDivideCode = extrInfo_MAMOK09197EA.TargetDivideCode;
		//    extrInfo_MAMOK09177EA.TargetDivideName = extrInfo_MAMOK09197EA.TargetDivideName;
		//    extrInfo_MAMOK09177EA.SalesFormCode = extrInfo_MAMOK09197EA.SalesFormCode;

		//    return extrInfo_MAMOK09177EA;
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

        /*----------------------------------------------------------------------------------*/
		/// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�ˏ]�ƈ��ʔ���ڕW�ݒ�}�X�^�j
		/// </summary>
        /// <param name="salesTargetList">�ڕW�}�X�^���[�N�N���X</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^</returns>
		/// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�N���X����]�ƈ��ʔ���ڕW�ݒ�}�X�^�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private List<EmpSalesTarget> CopyToEmpSalesTargetFromSalesTarget(List<SalesTarget> salesTargetList)
		{
            EmpSalesTarget empSalesTarget;
            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();

            foreach (SalesTarget salesTarget in salesTargetList)
            {
                empSalesTarget = new EmpSalesTarget();

                empSalesTarget.CreateDateTime = salesTarget.CreateDateTime;
                empSalesTarget.UpdateDateTime = salesTarget.UpdateDateTime;
                empSalesTarget.EnterpriseCode = salesTarget.EnterpriseCode;
                empSalesTarget.FileHeaderGuid = salesTarget.FileHeaderGuid;
                empSalesTarget.UpdEmployeeCode = salesTarget.UpdEmployeeCode;
                empSalesTarget.UpdAssemblyId1 = salesTarget.UpdAssemblyId1;
                empSalesTarget.UpdAssemblyId2 = salesTarget.UpdAssemblyId2;
                empSalesTarget.LogicalDeleteCode = salesTarget.LogicalDeleteCode;

                empSalesTarget.SectionCode = salesTarget.SectionCode;
                empSalesTarget.TargetSetCd = salesTarget.TargetSetCd;
                empSalesTarget.TargetContrastCd = salesTarget.TargetContrastCd;
                empSalesTarget.TargetDivideCode = salesTarget.TargetDivideCode;
                empSalesTarget.TargetDivideName = salesTarget.TargetDivideName;
//----- ueno add---------- start 2007.11.21
				empSalesTarget.EmployeeDivCd = salesTarget.EmployeeDivCd;
				empSalesTarget.SubSectionCode = salesTarget.SubSectionCode;
				empSalesTarget.MinSectionCode = salesTarget.MinSectionCode;
//----- ueno add---------- end   2007.11.21
                empSalesTarget.EmployeeCode = salesTarget.EmployeeCode;
                empSalesTarget.EmployeeName = salesTarget.EmployeeName;
                empSalesTarget.ApplyStaDate = salesTarget.ApplyStaDate;
                empSalesTarget.ApplyEndDate = salesTarget.ApplyEndDate;
                empSalesTarget.SalesTargetMoney = salesTarget.SalesTargetMoney;
                empSalesTarget.SalesTargetProfit = salesTarget.SalesTargetProfit;
                empSalesTarget.SalesTargetCount = salesTarget.SalesTargetCount;
				//----- ueno del---------- start 2007.11.21
				//empSalesTarget.WeekdayRatio = salesTarget.WeekdayRatio;
                //empSalesTarget.SatSunRatio = salesTarget.SatSunRatio;
				//----- ueno del---------- end   2007.11.21

                empSalesTargetList.Add(empSalesTarget);
            }

            return empSalesTargetList;

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�ˏ]�ƈ��ʔ���ڕW�ݒ�}�X�^�j
		/// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW�ݒ�}�X�^</param>
		/// <returns>�ڕW�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note	   : �]�ƈ��ʔ���ڕW�ݒ�}�X�^����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private List<SalesTarget> CopyToSalesTargetFromEmpSalesTarget(List<EmpSalesTarget> empSalesTargetList)
		{
            SalesTarget salesTarget;
            List<SalesTarget> salesTargetList = new List<SalesTarget>();

            foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
            {
                salesTarget = new SalesTarget();

                salesTarget.CreateDateTime = empSalesTarget.CreateDateTime;
                salesTarget.UpdateDateTime = empSalesTarget.UpdateDateTime;
                salesTarget.EnterpriseCode = empSalesTarget.EnterpriseCode;
                salesTarget.FileHeaderGuid = empSalesTarget.FileHeaderGuid;
                salesTarget.UpdEmployeeCode = empSalesTarget.UpdEmployeeCode;
                salesTarget.UpdAssemblyId1 = empSalesTarget.UpdAssemblyId1;
                salesTarget.UpdAssemblyId2 = empSalesTarget.UpdAssemblyId2;
                salesTarget.LogicalDeleteCode = empSalesTarget.LogicalDeleteCode;

                salesTarget.SectionCode = empSalesTarget.SectionCode;
                salesTarget.TargetSetCd = empSalesTarget.TargetSetCd;
                salesTarget.TargetContrastCd = empSalesTarget.TargetContrastCd;
                salesTarget.TargetDivideCode = empSalesTarget.TargetDivideCode;
                salesTarget.TargetDivideName = empSalesTarget.TargetDivideName;
//----- ueno add---------- start 2007.11.21
				salesTarget.EmployeeDivCd = empSalesTarget.EmployeeDivCd;
				salesTarget.SubSectionCode = empSalesTarget.SubSectionCode;
				salesTarget.MinSectionCode = empSalesTarget.MinSectionCode;
//----- ueno add---------- end   2007.11.21
                salesTarget.EmployeeCode = empSalesTarget.EmployeeCode;
                salesTarget.EmployeeName = empSalesTarget.EmployeeName;
                salesTarget.ApplyStaDate = empSalesTarget.ApplyStaDate;
                salesTarget.ApplyEndDate = empSalesTarget.ApplyEndDate;
                salesTarget.SalesTargetMoney = empSalesTarget.SalesTargetMoney;
                salesTarget.SalesTargetProfit = empSalesTarget.SalesTargetProfit;
                salesTarget.SalesTargetCount = empSalesTarget.SalesTargetCount;
				//----- ueno del---------- start 2007.11.21
				//salesTarget.WeekdayRatio = empSalesTarget.WeekdayRatio;
                //salesTarget.SatSunRatio = empSalesTarget.SatSunRatio;
				//----- ueno del---------- end   2007.11.21

                salesTargetList.Add(salesTarget);
            }

            return salesTargetList;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^���[�N�N���X�ˏ��i�ʖڕW�}�X�^�N���X�j
		/// </summary>
        /// <param name="salesTargetList">�ڕW�}�X�^�N���X</param>
        /// <returns>���i�ʖڕW�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�N���X���珤�i�ʖڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private List<GcdSalesTarget> CopyToGcdSalesTargetFromSalesTarget(List<SalesTarget> salesTargetList)
		{
			GcdSalesTarget gcdSalesTarget;
            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();

            foreach (SalesTarget salesTarget in salesTargetList)
            {
                gcdSalesTarget = new GcdSalesTarget();

                gcdSalesTarget.CreateDateTime = salesTarget.CreateDateTime;
                gcdSalesTarget.UpdateDateTime = salesTarget.UpdateDateTime;
                gcdSalesTarget.EnterpriseCode = salesTarget.EnterpriseCode;
                gcdSalesTarget.FileHeaderGuid = salesTarget.FileHeaderGuid;
                gcdSalesTarget.UpdEmployeeCode = salesTarget.UpdEmployeeCode;
                gcdSalesTarget.UpdAssemblyId1 = salesTarget.UpdAssemblyId1;
                gcdSalesTarget.UpdAssemblyId2 = salesTarget.UpdAssemblyId2;
                gcdSalesTarget.LogicalDeleteCode = salesTarget.LogicalDeleteCode;

                gcdSalesTarget.SectionCode = salesTarget.SectionCode;
                gcdSalesTarget.TargetSetCd = salesTarget.TargetSetCd;
                gcdSalesTarget.TargetContrastCd = salesTarget.TargetContrastCd;
                gcdSalesTarget.TargetDivideCode = salesTarget.TargetDivideCode;
                gcdSalesTarget.TargetDivideName = salesTarget.TargetDivideName;
				//----- ueno del---------- start 2007.11.21
				//gcdSalesTarget.CarrierCode = salesTarget.CarrierCode;
				//gcdSalesTarget.CarrierName = salesTarget.CarrierName;
				//gcdSalesTarget.CellphoneModelCode = salesTarget.CellphoneModelCode;
				//gcdSalesTarget.CellphoneModelName = salesTarget.CellphoneModelName;
				//----- ueno del---------- end   2007.11.21
                gcdSalesTarget.MakerCode = salesTarget.MakerCode;
                gcdSalesTarget.MakerName = salesTarget.MakerName;
                gcdSalesTarget.GoodsCode = salesTarget.GoodsCode;
                gcdSalesTarget.GoodsName = salesTarget.GoodsName;
                gcdSalesTarget.ApplyStaDate = salesTarget.ApplyStaDate;
                gcdSalesTarget.ApplyEndDate = salesTarget.ApplyEndDate;
                gcdSalesTarget.GcdSalesTargetMoney = salesTarget.SalesTargetMoney;
                gcdSalesTarget.GcdSalesTargetProfit = salesTarget.SalesTargetProfit;
                gcdSalesTarget.GcdSalesTargetCount = salesTarget.SalesTargetCount;
				//----- ueno del---------- start 2007.11.21
				//gcdSalesTarget.WeekdayRatio = salesTarget.WeekdayRatio;
				//gcdSalesTarget.SatSunRatio = salesTarget.SatSunRatio;
				//----- ueno del---------- end   2007.11.21

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                gcdSalesTarget.BLGroupCode = salesTarget.BLGroupCode;
                gcdSalesTarget.BLGroupName = salesTarget.BLGroupName;
                gcdSalesTarget.BLCode = salesTarget.BLCode;
                gcdSalesTarget.BLCodeName = salesTarget.BLCodeName;
                gcdSalesTarget.SalesTypeCode = salesTarget.SalesTypeCode;
                gcdSalesTarget.SalesTypeName = salesTarget.SalesTypeName;
                gcdSalesTarget.ItemTypeCode = salesTarget.ItemTypeCode;
                gcdSalesTarget.ItemTypeName = salesTarget.ItemTypeName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

                gcdSalesTargetList.Add(gcdSalesTarget);
            }

            return gcdSalesTargetList;

		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���i�ʖڕW�}�X�^�N���X�˖ڕW�}�X�^�N���X�j
		/// </summary>
        /// <param name="gcdSalesTargetList">���i�ʖڕW�}�X�^�N���X</param>
		/// <returns>�ڕW�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note	   : ���i�ʖڕW�}�X�^�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2007.05.08</br>
		/// </remarks>
		private List<SalesTarget> CopyToSalesTargetFromGcdSalesTarget(List<GcdSalesTarget> gcdSalesTargetList)
		{
			SalesTarget salesTarget;
            List<SalesTarget> salesTargetList = new List<SalesTarget>();

            foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
            {
                salesTarget = new SalesTarget();

                salesTarget.CreateDateTime = gcdSalesTarget.CreateDateTime;
                salesTarget.UpdateDateTime = gcdSalesTarget.UpdateDateTime;
                salesTarget.EnterpriseCode = gcdSalesTarget.EnterpriseCode;
                salesTarget.FileHeaderGuid = gcdSalesTarget.FileHeaderGuid;
                salesTarget.UpdEmployeeCode = gcdSalesTarget.UpdEmployeeCode;
                salesTarget.UpdAssemblyId1 = gcdSalesTarget.UpdAssemblyId1;
                salesTarget.UpdAssemblyId2 = gcdSalesTarget.UpdAssemblyId2;
                salesTarget.LogicalDeleteCode = gcdSalesTarget.LogicalDeleteCode;

                salesTarget.SectionCode = gcdSalesTarget.SectionCode;
                salesTarget.TargetSetCd = gcdSalesTarget.TargetSetCd;
                salesTarget.TargetContrastCd = gcdSalesTarget.TargetContrastCd;
                salesTarget.TargetDivideCode = gcdSalesTarget.TargetDivideCode;
                salesTarget.TargetDivideName = gcdSalesTarget.TargetDivideName;
				//----- ueno del---------- start 2007.11.21
				//salesTarget.CarrierCode = gcdSalesTarget.CarrierCode;
				//salesTarget.CarrierName = gcdSalesTarget.CarrierName;
				//salesTarget.CellphoneModelCode = gcdSalesTarget.CellphoneModelCode;
				//salesTarget.CellphoneModelName = gcdSalesTarget.CellphoneModelName;
				//----- ueno del---------- end   2007.11.21
                salesTarget.MakerCode = gcdSalesTarget.MakerCode;
                salesTarget.MakerName = gcdSalesTarget.MakerName;
                salesTarget.GoodsCode = gcdSalesTarget.GoodsCode;
                salesTarget.GoodsName = gcdSalesTarget.GoodsName;
                salesTarget.ApplyStaDate = gcdSalesTarget.ApplyStaDate;
                salesTarget.ApplyEndDate = gcdSalesTarget.ApplyEndDate;
                salesTarget.SalesTargetMoney = gcdSalesTarget.GcdSalesTargetMoney;
                salesTarget.SalesTargetProfit = gcdSalesTarget.GcdSalesTargetProfit;
                salesTarget.SalesTargetCount = gcdSalesTarget.GcdSalesTargetCount;
				//----- ueno del---------- start 2007.11.21
				//salesTarget.WeekdayRatio = gcdSalesTarget.WeekdayRatio;
				//salesTarget.SatSunRatio = gcdSalesTarget.SatSunRatio;
				//----- ueno del---------- end   2007.11.21

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
                gcdSalesTarget.BLGroupCode = salesTarget.BLGroupCode;
                gcdSalesTarget.BLGroupName = salesTarget.BLGroupName;
                gcdSalesTarget.BLCode = salesTarget.BLCode;
                gcdSalesTarget.BLCodeName = salesTarget.BLCodeName;
                gcdSalesTarget.SalesTypeCode = salesTarget.SalesTypeCode;
                gcdSalesTarget.SalesTypeName = salesTarget.SalesTypeName;
                gcdSalesTarget.ItemTypeCode = salesTarget.ItemTypeCode;
                gcdSalesTarget.ItemTypeName = salesTarget.ItemTypeName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END
                salesTargetList.Add(salesTarget);
            }

			return salesTargetList;

		}

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˓��Ӑ�ʔ���ڕW�ݒ�}�X�^�j
		/// </summary>
		/// <param name="salesTargetList">�ڕW�}�X�^���[�N�N���X</param>
		/// <returns>���Ӑ�ʔ���ڕW�ݒ�}�X�^</returns>
		/// <remarks>
		/// <br>Note	   : �ڕW�}�X�^�N���X���瓾�Ӑ�ʔ���ڕW�ݒ�}�X�^�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date	   : 2007.11.21</br>
		/// </remarks>
		private List<CustSalesTarget> CopyToCustSalesTargetFromSalesTarget(List<SalesTarget> salesTargetList)
		{
			CustSalesTarget custSalesTarget;
			List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();

			foreach (SalesTarget salesTarget in salesTargetList)
			{
				custSalesTarget = new CustSalesTarget();

				custSalesTarget.CreateDateTime = salesTarget.CreateDateTime;
				custSalesTarget.UpdateDateTime = salesTarget.UpdateDateTime;
				custSalesTarget.EnterpriseCode = salesTarget.EnterpriseCode;
				custSalesTarget.FileHeaderGuid = salesTarget.FileHeaderGuid;
				custSalesTarget.UpdEmployeeCode = salesTarget.UpdEmployeeCode;
				custSalesTarget.UpdAssemblyId1 = salesTarget.UpdAssemblyId1;
				custSalesTarget.UpdAssemblyId2 = salesTarget.UpdAssemblyId2;
				custSalesTarget.LogicalDeleteCode = salesTarget.LogicalDeleteCode;

				custSalesTarget.SectionCode = salesTarget.SectionCode;
				custSalesTarget.TargetSetCd = salesTarget.TargetSetCd;
				custSalesTarget.TargetContrastCd = salesTarget.TargetContrastCd;
				custSalesTarget.TargetDivideCode = salesTarget.TargetDivideCode;
				custSalesTarget.TargetDivideName = salesTarget.TargetDivideName;
				custSalesTarget.BusinessTypeCode = salesTarget.BusinessTypeCode;
				custSalesTarget.SalesAreaCode = salesTarget.SalesAreaCode;
				custSalesTarget.CustomerCode = salesTarget.CustomerCode;
				custSalesTarget.ApplyStaDate = salesTarget.ApplyStaDate;
				custSalesTarget.ApplyEndDate = salesTarget.ApplyEndDate;
				custSalesTarget.SalesTargetMoney = salesTarget.SalesTargetMoney;
				custSalesTarget.SalesTargetProfit = salesTarget.SalesTargetProfit;
				custSalesTarget.SalesTargetCount = salesTarget.SalesTargetCount;

				custSalesTargetList.Add(custSalesTarget);
			}

			return custSalesTargetList;

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˓��Ӑ�ʔ���ڕW�ݒ�}�X�^�j
		/// </summary>
		/// <param name="empSalesTargetList">���Ӑ�ʔ���ڕW�ݒ�}�X�^</param>
		/// <returns>�ڕW�}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note	   : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date	   : 2007.11.21</br>
		/// </remarks>
		private List<SalesTarget> CopyToSalesTargetFromCustSalesTarget(List<CustSalesTarget> custSalesTargetList)
		{
			SalesTarget salesTarget;
			List<SalesTarget> salesTargetList = new List<SalesTarget>();

			foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
			{
				salesTarget = new SalesTarget();

				salesTarget.CreateDateTime = custSalesTarget.CreateDateTime;
				salesTarget.UpdateDateTime = custSalesTarget.UpdateDateTime;
				salesTarget.EnterpriseCode = custSalesTarget.EnterpriseCode;
				salesTarget.FileHeaderGuid = custSalesTarget.FileHeaderGuid;
				salesTarget.UpdEmployeeCode = custSalesTarget.UpdEmployeeCode;
				salesTarget.UpdAssemblyId1 = custSalesTarget.UpdAssemblyId1;
				salesTarget.UpdAssemblyId2 = custSalesTarget.UpdAssemblyId2;
				salesTarget.LogicalDeleteCode = custSalesTarget.LogicalDeleteCode;

				salesTarget.SectionCode = custSalesTarget.SectionCode;
				salesTarget.TargetSetCd = custSalesTarget.TargetSetCd;
				salesTarget.TargetContrastCd = custSalesTarget.TargetContrastCd;
				salesTarget.TargetDivideCode = custSalesTarget.TargetDivideCode;
				salesTarget.TargetDivideName = custSalesTarget.TargetDivideName;
				salesTarget.BusinessTypeCode = custSalesTarget.BusinessTypeCode;
				salesTarget.SalesAreaCode = custSalesTarget.SalesAreaCode;
				salesTarget.CustomerCode = custSalesTarget.CustomerCode;
				salesTarget.ApplyStaDate = custSalesTarget.ApplyStaDate;
				salesTarget.ApplyEndDate = custSalesTarget.ApplyEndDate;
				salesTarget.SalesTargetMoney = custSalesTarget.SalesTargetMoney;
				salesTarget.SalesTargetProfit = custSalesTarget.SalesTargetProfit;
				salesTarget.SalesTargetCount = custSalesTarget.SalesTargetCount;

				salesTargetList.Add(salesTarget);
			}

			return salesTargetList;
		}
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˔���`���ʖڕW�}�X�^�N���X�j
		///// </summary>
		///// <param name="salesTargetList">�ڕW�}�X�^�N���X</param>
		///// <returns>����`���ʖڕW�}�X�^�N���X</returns>
		///// <remarks>
		///// <br>Note	   : �ڕW�}�X�^�N���X���甄��`���ʖڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.05.08</br>
		///// </remarks>
		//private List<SformSlTarget> CopyToSformSlTargetFromSalesTarget(List<SalesTarget> salesTargetList)
		//{
		//    SformSlTarget sformSlTarget;
		//    List<SformSlTarget> sformSlTargetList = new List<SformSlTarget>();

		//    foreach (SalesTarget salesTarget in salesTargetList)
		//    {
		//        sformSlTarget = new SformSlTarget();

		//        sformSlTarget.CreateDateTime = salesTarget.CreateDateTime;
		//        sformSlTarget.UpdateDateTime = salesTarget.UpdateDateTime;
		//        sformSlTarget.EnterpriseCode = salesTarget.EnterpriseCode;
		//        sformSlTarget.FileHeaderGuid = salesTarget.FileHeaderGuid;
		//        sformSlTarget.UpdEmployeeCode = salesTarget.UpdEmployeeCode;
		//        sformSlTarget.UpdAssemblyId1 = salesTarget.UpdAssemblyId1;
		//        sformSlTarget.UpdAssemblyId2 = salesTarget.UpdAssemblyId2;
		//        sformSlTarget.LogicalDeleteCode = salesTarget.LogicalDeleteCode;

		//        sformSlTarget.SectionCode = salesTarget.SectionCode;
		//        sformSlTarget.TargetSetCd = salesTarget.TargetSetCd;
		//        sformSlTarget.TargetDivideCode = salesTarget.TargetDivideCode;
		//        sformSlTarget.TargetDivideName = salesTarget.TargetDivideName;
		//        sformSlTarget.SalesFormal = salesTarget.SalesFormal;
		//        sformSlTarget.ApplyStaDate = salesTarget.ApplyStaDate;
		//        sformSlTarget.ApplyEndDate = salesTarget.ApplyEndDate;
		//        sformSlTarget.SformSlTargetMoney = salesTarget.SalesTargetMoney;
		//        sformSlTarget.SformSlTargetProfit = salesTarget.SalesTargetProfit;
		//        sformSlTarget.SformSlTargetCount = salesTarget.SalesTargetCount;
		//        sformSlTarget.WeekdayRatio = salesTarget.WeekdayRatio;
		//        sformSlTarget.SatSunRatio = salesTarget.SatSunRatio;

		//        sformSlTargetList.Add(sformSlTarget);
		//    }

		//    return sformSlTargetList;

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i����`���ʖڕW�}�X�^�N���X�˖ڕW�}�X�^�N���X�j
		///// </summary>
		///// <param name="sformSlTargetList">����`���ʖڕW�}�X�^�N���X</param>
		///// <returns>�ڕW�}�X�^�N���X</returns>
		///// <remarks>
		///// <br>Note	   : ����`���ʖڕW�}�X�^�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.05.08</br>
		///// </remarks>
		//private List<SalesTarget> CopyToSalesTargetFromSformSlTarget(List<SformSlTarget> sformSlTargetList)
		//{
		//    SalesTarget salesTarget;
		//    List<SalesTarget> salesTargetList = new List<SalesTarget>();

		//    foreach (SformSlTarget sformSlTarget in sformSlTargetList)
		//    {
		//        salesTarget = new SalesTarget();

		//        salesTarget.CreateDateTime = sformSlTarget.CreateDateTime;
		//        salesTarget.UpdateDateTime = sformSlTarget.UpdateDateTime;
		//        salesTarget.EnterpriseCode = sformSlTarget.EnterpriseCode;
		//        salesTarget.FileHeaderGuid = sformSlTarget.FileHeaderGuid;
		//        salesTarget.UpdEmployeeCode = sformSlTarget.UpdEmployeeCode;
		//        salesTarget.UpdAssemblyId1 = sformSlTarget.UpdAssemblyId1;
		//        salesTarget.UpdAssemblyId2 = sformSlTarget.UpdAssemblyId2;
		//        salesTarget.LogicalDeleteCode = sformSlTarget.LogicalDeleteCode;

		//        salesTarget.SectionCode = sformSlTarget.SectionCode;
		//        salesTarget.TargetSetCd = sformSlTarget.TargetSetCd;
		//        salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
		//        salesTarget.TargetDivideCode = sformSlTarget.TargetDivideCode;
		//        salesTarget.TargetDivideName = sformSlTarget.TargetDivideName;
		//        salesTarget.SalesFormal = sformSlTarget.SalesFormal;
		//        salesTarget.ApplyStaDate = sformSlTarget.ApplyStaDate;
		//        salesTarget.ApplyEndDate = sformSlTarget.ApplyEndDate;
		//        salesTarget.SalesTargetMoney = sformSlTarget.SformSlTargetMoney;
		//        salesTarget.SalesTargetProfit = sformSlTarget.SformSlTargetProfit;
		//        salesTarget.SalesTargetCount = sformSlTarget.SformSlTargetCount;
		//        salesTarget.WeekdayRatio = sformSlTarget.WeekdayRatio;
		//        salesTarget.SatSunRatio = sformSlTarget.SatSunRatio;

		//        salesTargetList.Add(salesTarget);
		//    }

		//    return salesTargetList;

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˔̔��`�ԕʖڕW�}�X�^�N���X�j
		///// </summary>
		///// <param name="salesTargetList">�ڕW�}�X�^�N���X</param>
		///// <returns>�̔��`�ԕʖڕW�}�X�^�N���X</returns>
		///// <remarks>
		///// <br>Note	   : �ڕW�}�X�^�N���X����̔��`�ԕʖڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.05.08</br>
		///// </remarks>
		//private List<SfcdSalesTarget> CopyToSfcdSalesTargetFromSalesTarget(List<SalesTarget> salesTargetList)
		//{
		//    SfcdSalesTarget sfcdSalesTarget;
		//    List<SfcdSalesTarget> sfcdSalesTargetList = new List<SfcdSalesTarget>();

		//    foreach (SalesTarget salesTarget in salesTargetList)
		//    {
		//        sfcdSalesTarget = new SfcdSalesTarget();

		//        sfcdSalesTarget.CreateDateTime = salesTarget.CreateDateTime;
		//        sfcdSalesTarget.UpdateDateTime = salesTarget.UpdateDateTime;
		//        sfcdSalesTarget.EnterpriseCode = salesTarget.EnterpriseCode;
		//        sfcdSalesTarget.FileHeaderGuid = salesTarget.FileHeaderGuid;
		//        sfcdSalesTarget.UpdEmployeeCode = salesTarget.UpdEmployeeCode;
		//        sfcdSalesTarget.UpdAssemblyId1 = salesTarget.UpdAssemblyId1;
		//        sfcdSalesTarget.UpdAssemblyId2 = salesTarget.UpdAssemblyId2;
		//        sfcdSalesTarget.LogicalDeleteCode = salesTarget.LogicalDeleteCode;

		//        sfcdSalesTarget.SectionCode = salesTarget.SectionCode;
		//        sfcdSalesTarget.TargetSetCd = salesTarget.TargetSetCd;
		//        sfcdSalesTarget.TargetDivideCode = salesTarget.TargetDivideCode;
		//        sfcdSalesTarget.TargetDivideName = salesTarget.TargetDivideName;
		//        sfcdSalesTarget.SalesFormCode = salesTarget.SalesFormCode;
		//        sfcdSalesTarget.SalesFormName = salesTarget.SalesFormName;
		//        sfcdSalesTarget.ApplyStaDate = salesTarget.ApplyStaDate;
		//        sfcdSalesTarget.ApplyEndDate = salesTarget.ApplyEndDate;
		//        sfcdSalesTarget.SfcdSalesTargetMoney = salesTarget.SalesTargetMoney;
		//        sfcdSalesTarget.SfcdSalesTargetProfit = salesTarget.SalesTargetProfit;
		//        sfcdSalesTarget.SfcdSalesTargetCount = salesTarget.SalesTargetCount;
		//        sfcdSalesTarget.WeekdayRatio = salesTarget.WeekdayRatio;
		//        sfcdSalesTarget.SatSunRatio = salesTarget.SatSunRatio;

		//        sfcdSalesTargetList.Add(sfcdSalesTarget);
		//    }

		//    return sfcdSalesTargetList;

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �N���X�����o�[�R�s�[�����i�̔��`�ԕʖڕW�}�X�^�N���X�˖ڕW�}�X�^�N���X�j
		///// </summary>
		///// <param name="sfcdSalesTargetList">�̔��`�ԕʖڕW�}�X�^�N���X</param>
		///// <returns>�ڕW�}�X�^�N���X</returns>
		///// <remarks>
		///// <br>Note	   : �̔��`�ԕʖڕW�}�X�^�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		///// <br>Programmer : NEPCO</br>
		///// <br>Date	   : 2007.05.08</br>
		///// </remarks>
		//private List<SalesTarget> CopyToSalesTargetFromSfcdSalesTarget(List<SfcdSalesTarget> sfcdSalesTargetList)
		//{
		//    SalesTarget salesTarget;
		//    List<SalesTarget> salesTargetList = new List<SalesTarget>();

		//    foreach (SfcdSalesTarget sfcdSalesTarget in sfcdSalesTargetList)
		//    {
		//        salesTarget = new SalesTarget();

		//        salesTarget.CreateDateTime = sfcdSalesTarget.CreateDateTime;
		//        salesTarget.UpdateDateTime = sfcdSalesTarget.UpdateDateTime;
		//        salesTarget.EnterpriseCode = sfcdSalesTarget.EnterpriseCode;
		//        salesTarget.FileHeaderGuid = sfcdSalesTarget.FileHeaderGuid;
		//        salesTarget.UpdEmployeeCode = sfcdSalesTarget.UpdEmployeeCode;
		//        salesTarget.UpdAssemblyId1 = sfcdSalesTarget.UpdAssemblyId1;
		//        salesTarget.UpdAssemblyId2 = sfcdSalesTarget.UpdAssemblyId2;
		//        salesTarget.LogicalDeleteCode = sfcdSalesTarget.LogicalDeleteCode;

		//        salesTarget.SectionCode = sfcdSalesTarget.SectionCode;
		//        salesTarget.TargetSetCd = sfcdSalesTarget.TargetSetCd;
		//        salesTarget.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
		//        salesTarget.TargetDivideCode = sfcdSalesTarget.TargetDivideCode;
		//        salesTarget.TargetDivideName = sfcdSalesTarget.TargetDivideName;
		//        salesTarget.SalesFormCode = sfcdSalesTarget.SalesFormCode;
		//        salesTarget.SalesFormName = sfcdSalesTarget.SalesFormName;
		//        salesTarget.ApplyStaDate = sfcdSalesTarget.ApplyStaDate;
		//        salesTarget.ApplyEndDate = sfcdSalesTarget.ApplyEndDate;
		//        salesTarget.SalesTargetMoney = sfcdSalesTarget.SfcdSalesTargetMoney;
		//        salesTarget.SalesTargetProfit = sfcdSalesTarget.SfcdSalesTargetProfit;
		//        salesTarget.SalesTargetCount = sfcdSalesTarget.SfcdSalesTargetCount;
		//        salesTarget.WeekdayRatio = sfcdSalesTarget.WeekdayRatio;
		//        salesTarget.SatSunRatio = sfcdSalesTarget.SatSunRatio;

		//        salesTargetList.Add(salesTarget);
		//    }

		//    return salesTargetList;

		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�����ݒ�N���X�˔�����я��f�[�^�����ݒ�N���X�j
        /// </summary>
        /// <param name="extrInfo_MAMOK09197EA">�ڕW�}�X�^�����ݒ�N���X</param>
        /// <returns>������я��f�[�^�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�����ݒ�N���X���甄����я��f�[�^�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private TrgtCompSalesRsltParaWork CopyToTrgtCompSalesRsltParaWorkFromExtrInfo(ExtrInfo_MAMOK09197EA extrInfo_MAMOK09197EA)
        {
            TrgtCompSalesRsltParaWork trgtCompSalesRsltParaWork = new TrgtCompSalesRsltParaWork();

            trgtCompSalesRsltParaWork.EnterpriseCode = extrInfo_MAMOK09197EA.EnterpriseCode;
            trgtCompSalesRsltParaWork.SalesDateSt = extrInfo_MAMOK09197EA.ApplyStaDateSt;
            trgtCompSalesRsltParaWork.SalesDateEd = extrInfo_MAMOK09197EA.ApplyEndDateEd;
            // ���_
            if (extrInfo_MAMOK09197EA.SelectSectCd.Length != 0)
            {
                if (extrInfo_MAMOK09197EA.SelectSectCd[0] == "0")
                {
                    // �S�Ђ̎�
                    trgtCompSalesRsltParaWork.AllSecSelEpUnit = false;  // true�ɂ���Ǝ擾�ł��Ȃ�
                    trgtCompSalesRsltParaWork.AllSecSelSecUnit = true;
                }
                else
                {
                    trgtCompSalesRsltParaWork.AllSecSelEpUnit = false;
                    if (_secInfoAcs.SecInfoSetList.Length == extrInfo_MAMOK09197EA.SelectSectCd.Length)
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă���
                        trgtCompSalesRsltParaWork.AllSecSelSecUnit = true;
                    }
                    else
                    {
                        // �S���_�Ƀ`�F�b�N�������Ă��Ȃ�
                        trgtCompSalesRsltParaWork.AllSecSelSecUnit = false;
                        trgtCompSalesRsltParaWork.SelectSectCd = extrInfo_MAMOK09197EA.SelectSectCd;     // ���_�R�[�h
                    }
                }
            }
            else
            {
                // �S���_�W�v���R�[�h�ł̏o��
                trgtCompSalesRsltParaWork.AllSecSelEpUnit = false;
                trgtCompSalesRsltParaWork.AllSecSelSecUnit = true;
            }
            switch (extrInfo_MAMOK09197EA.TargetContrastCd)
            {
                case (int)SalesTarget.ConstrastCd.Section:
                    trgtCompSalesRsltParaWork.ExtraCondFlag = 1;
                    break;
//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 2;
					break;

				//case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:
				//	trgtCompSalesRsltParaWork.ExtraCondFlag = 3;
				//	break;

				case (int)SalesTarget.ConstrastCd.SecAndEmp:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 4;
                    break;

				case (int)SalesTarget.ConstrastCd.SecAndMaker:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 5;
					break;

				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 6;
					break;

				case (int)SalesTarget.ConstrastCd.SecAndCust:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 7;
					break;

				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 8;
					break;

				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:
					trgtCompSalesRsltParaWork.ExtraCondFlag = 9;
					break;
//----- ueno upd---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				//case (int)SalesTarget.ConstrastCd.SalesFormal:
				//    trgtCompSalesRsltParaWork.ExtraCondFlag = 3;
				//    break;
				//case (int)SalesTarget.ConstrastCd.SalesForm:
				//    trgtCompSalesRsltParaWork.ExtraCondFlag = 4;
				//    break;
				//case (int)SalesTarget.ConstrastCd.Carrier:
				//    trgtCompSalesRsltParaWork.ExtraCondFlag = 5;
				//    break;
				//----- ueno del---------- end   2007.11.21

                default:
                    trgtCompSalesRsltParaWork.ExtraCondFlag = 0;
                    break;
            }
            trgtCompSalesRsltParaWork.EmployeeCode = extrInfo_MAMOK09197EA.EmployeeCode;
			//----- ueno del---------- start 2007.11.21
			//trgtCompSalesRsltParaWork.SalesFormal = extrInfo_MAMOK09197EA.SalesFormal;
			//trgtCompSalesRsltParaWork.SalesFormCode = extrInfo_MAMOK09197EA.SalesFormCode;
			//trgtCompSalesRsltParaWork.CarrierCode = extrInfo_MAMOK09197EA.CarrierCode;
			//trgtCompSalesRsltParaWork.CellphoneModelCode = extrInfo_MAMOK09197EA.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            trgtCompSalesRsltParaWork.MakerCode = extrInfo_MAMOK09197EA.MakerCode;
            trgtCompSalesRsltParaWork.GoodsCode = extrInfo_MAMOK09197EA.GoodsCode;

            return trgtCompSalesRsltParaWork;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i������я��f�[�^���[�N�N���X�˔�����я��f�[�^�N���X�j
        /// </summary>
        /// <param name="trgtCompSalesRsltWork">������я��f�[�^���[�N�N���X</param>
        /// <returns>������я��f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : ������я��f�[�^���[�N�N���X���甄����я��f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.07</br>
        /// </remarks>
        private TrgtCompSalesRslt CopyTrgtCompSalesRsltFromTrgtCompSalesRsltWork(TrgtCompSalesRsltWork trgtCompSalesRsltWork)
        {
            TrgtCompSalesRslt trgtCompSalesRslt = new TrgtCompSalesRslt();

            trgtCompSalesRslt.EnterpriseCode = trgtCompSalesRsltWork.EnterpriseCode;
            trgtCompSalesRslt.SalesDate = trgtCompSalesRsltWork.SalesDate;
            trgtCompSalesRslt.SectionCode = trgtCompSalesRsltWork.SectionCode;
            trgtCompSalesRslt.EmployeeCode = trgtCompSalesRsltWork.EmployeeCode;

//----- ueno add---------- start 2007.11.21
//sagyo ���[�N�t�@�C���v�Ή�
// �ڕW������ъJ�����ɑΉ����Ă�������

			//trgtCompSalesRslt.EmployeeDivCd = trgtCompSalesRsltWork.EmployeeDivCd;
			//trgtCompSalesRslt.SubSectionCode = trgtCompSalesRsltWork.SubSectionCode;
			//trgtCompSalesRslt.MinSectionCode = trgtCompSalesRsltWork.MinSectionCode;
			//trgtCompSalesRslt.BusinessTypeCode = trgtCompSalesRsltWork.BusinessTypeCode;
			//trgtCompSalesRslt.SalesAreaCode = trgtCompSalesRsltWork.SalesAreaCode;
			//trgtCompSalesRslt.CustomerCode = trgtCompSalesRsltWork.CustomerCode;

//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//trgtCompSalesRslt.SalesFormal = trgtCompSalesRsltWork.SalesFormal;
            //trgtCompSalesRslt.SalesFormCode = trgtCompSalesRsltWork.SalesFormCode;
            //trgtCompSalesRslt.CarrierCode = trgtCompSalesRsltWork.CarrierCode;
            //trgtCompSalesRslt.CellphoneModelCode = trgtCompSalesRsltWork.CellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            trgtCompSalesRslt.MakerCode = trgtCompSalesRsltWork.MakerCode;
            trgtCompSalesRslt.GoodsCode = trgtCompSalesRsltWork.GoodsCode;
            trgtCompSalesRslt.SalesmonyTaxExc = trgtCompSalesRsltWork.SalesMoneyTaxExc;
            trgtCompSalesRslt.Cost = trgtCompSalesRsltWork.Cost;
			//----- ueno del---------- start 2007.11.21
			//trgtCompSalesRslt.InsentiveRecv = trgtCompSalesRsltWork.IncentiveRecv;
            //trgtCompSalesRslt.InsentiveDtbt = trgtCompSalesRsltWork.IncentiveDtbt;
			//----- ueno del---------- end   2007.11.21
            trgtCompSalesRslt.SalesCount = trgtCompSalesRsltWork.SalesCount;

            switch (trgtCompSalesRsltWork.ExtraCondFlag)
            {
                case 1:
                    trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
                    break;
//----- ueno upd---------- start 2007.11.21
                case 2:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndSubSec;
					break;

                //case 3:
                //    trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec;
                //    break;

				case 4:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
					break;

				case 5:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMaker;
					break;

				case 6:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
					break;

				case 7:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
					break;

				case 8:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndBusinessType;
					break;

				case 9:
					trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndSalesArea;
					break;
//----- ueno upd---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				//case 3:
				//    trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
				//    break;
				//case 4:
				//    trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
				//    break;
				//case 5:
				//    trgtCompSalesRslt.TargetContrastCd = (int)SalesTarget.ConstrastCd.Carrier;
				//    break;
				//----- ueno del---------- end   2007.11.21

				//----- ueno upd---------- start 2007.11.21

                default:
                    trgtCompSalesRslt.TargetContrastCd = 0;
                    break;
            }

            return trgtCompSalesRslt;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����f�[�^�����Z����
        /// </summary>
        /// <param name="salesRsltList">����f�[�^</param>
        /// <param name="salesTarget">�ڕW�f�[�^(����)</param>
        /// <param name="salesMoney">���Z��������f�[�^</param>
        /// <param name="salesProfit">���Z�����e���f�[�^</param>
        /// <param name="salesCount">���Z��������</param>
        /// <remarks>
        /// <br>Note	   : ���ʂ̔���f�[�^��Ώۏ����ō��v����</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private void AddTargetSales(
            List<TrgtCompSalesRslt> salesRsltList,
            SalesTarget salesTarget,
			//----- ueno del---------- start 2007.11.21
			//List<LdgCalcRatioMng> ldgCalcRatioMngList,
			//Dictionary<SectionAndDate, HolidaySetting> holidaySettingDic,
			//----- ueno del---------- end   2007.11.21
            out long salesMoney, 
            out long salesProfit, 
            out double salesCount)
        {
            salesMoney  = 0;
            salesProfit = 0;
            salesCount  = 0;

			//----- ueno del---------- start 2007.11.21
			//// �Ώۊ��Ԃ̔䗦�擾
			//double[] ratioList;
			//SalesLandingAcs.GetRatioInTargetDate(
			//    salesTarget.ApplyStaDate,
			//    salesTarget.ApplyEndDate,
			//    salesTarget.SectionCode,
			//    ldgCalcRatioMngList,
			//    holidaySettingDic,
			//    out ratioList);

			//// �䗦0�̓��̃��X�g�쐬
			//DateTime day;
			//List<DateTime> zeroRaioDays = new List<DateTime>();
			//for (int dayCount = 0; dayCount < ratioList.Length; dayCount++)
			//{
			//    if (ratioList[dayCount] == 0.0)
			//    {
			//        day = salesTarget.ApplyStaDate.AddDays(dayCount);
			//        zeroRaioDays.Add(day);
			//    }
			//}
			//----- ueno del---------- end   2007.11.21

            // ���������ݒ�
            Predicate<TrgtCompSalesRslt> predicate;
            switch (salesTarget.TargetContrastCd)
            {
                case (int)SalesTarget.ConstrastCd.Section:
                    predicate = 
                        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
                        {
                            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
                                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
                                trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.Section &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode)
								//----- ueno del---------- start 2007.11.21
                                //!zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
								//----- ueno del---------- end   2007.11.21
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        };
                    break;

//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:
					predicate =
						delegate(TrgtCompSalesRslt trgtCompSalesRslt)
						{
							if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
								trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSec &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
								trgtCompSalesRslt.SubSectionCode == salesTarget.SubSectionCode)
							{
								return (true);
							}
							else
							{
								return (false);
							}
						};
					break;
				
                //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:
                //    predicate =
                //        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
                //        {
                //            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
                //                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
                //                trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec &&
                //                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
                //                trgtCompSalesRslt.SubSectionCode == salesTarget.SubSectionCode &&
                //                trgtCompSalesRslt.MinSectionCode == salesTarget.MinSectionCode)
                //            {
                //                return (true);
                //            }
                //            else
                //            {
                //                return (false);
                //            }
                //        };
                //    break;

				case (int)SalesTarget.ConstrastCd.SecAndEmp:
					predicate =
                        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
                        {
                            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
                                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndEmp &&
                                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
                                trgtCompSalesRslt.EmployeeCode == salesTarget.EmployeeCode)
								//----- ueno del---------- start 2007.11.21
								//!zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
								//----- ueno del---------- end   2007.11.21
							{
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        };
                    break;
//----- ueno upd---------- end   2007.11.21

				//----- ueno del---------- start 2007.11.21
				#region del
				//case (int)SalesTarget.ConstrastCd.SalesFormal:
				//    predicate =
				//        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
				//        {
				//            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
				//                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate && 
				//                trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SalesFormal &&
				//                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
				//                trgtCompSalesRslt.SalesFormal == salesTarget.SalesFormal &&
				//                !zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
				//            {
				//                return (true);
				//            }
				//            else
				//            {
				//                return (false);
				//            }
				//        };
				//    break;

				//case (int)SalesTarget.ConstrastCd.SalesForm:
				//    predicate =
				//        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
				//        {
				//            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
				//                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate && 
				//                trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SalesForm &&
				//                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
				//                trgtCompSalesRslt.SalesFormCode == salesTarget.SalesFormCode &&
				//                !zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
				//            {
				//                return (true);
				//            }
				//            else
				//            {
				//                return (false);
				//            }
				//        };
				//    break;

				//case (int)SalesTarget.ConstrastCd.Carrier:
				//    predicate =
				//        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
				//        {
				//            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
				//                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate && 
				//                trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.Carrier &&
				//                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
				//                trgtCompSalesRslt.CarrierCode == salesTarget.CarrierCode &&
				//                trgtCompSalesRslt.CellphoneModelCode == salesTarget.CellphoneModelCode &&
				//                !zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
				//            {
				//                return (true);
				//            }
				//            else
				//            {
				//                return (false);
				//            }
				//        };
				//    break;
                #endregion del
				//----- ueno del---------- end   2007.11.21

//----- ueno upd---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndMaker:
					predicate =
						delegate(TrgtCompSalesRslt trgtCompSalesRslt)
						{
							if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
								trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndMaker &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
								trgtCompSalesRslt.MakerCode == salesTarget.MakerCode)
							{
								return (true);
							}
							else
							{
								return (false);
							}
						};
					break;

				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:
					predicate =
                        delegate(TrgtCompSalesRslt trgtCompSalesRslt)
                        {
                            if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
                                trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods &&
                                trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
                                trgtCompSalesRslt.MakerCode == salesTarget.MakerCode &&
                                trgtCompSalesRslt.GoodsCode == salesTarget.GoodsCode)
								//----- ueno del---------- start 2007.11.21
								//!zeroRaioDays.Contains(trgtCompSalesRslt.SalesDate))
								//----- ueno del---------- end   2007.11.21
							{
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        };
                    break;
//----- ueno upd---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21
				case (int)SalesTarget.ConstrastCd.SecAndCust:
					predicate =
						delegate(TrgtCompSalesRslt trgtCompSalesRslt)
						{
							if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
								trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndCust &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
								trgtCompSalesRslt.CustomerCode == salesTarget.CustomerCode)
							{
								return (true);
							}
							else
							{
								return (false);
							}
						};
					break;

				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:
					predicate =
						delegate(TrgtCompSalesRslt trgtCompSalesRslt)
						{
							if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
								trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndBusinessType &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
								trgtCompSalesRslt.BusinessTypeCode == salesTarget.BusinessTypeCode)
							{
								return (true);
							}
							else
							{
								return (false);
							}
						};
					break;

				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:
					predicate =
						delegate(TrgtCompSalesRslt trgtCompSalesRslt)
						{
							if (trgtCompSalesRslt.SalesDate >= salesTarget.ApplyStaDate &&
								trgtCompSalesRslt.SalesDate <= salesTarget.ApplyEndDate &&
								trgtCompSalesRslt.TargetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSalesArea &&
								trgtCompSalesRslt.SectionCode == salesTarget.SectionCode &&
								trgtCompSalesRslt.SalesAreaCode == salesTarget.SalesAreaCode)
							{
								return (true);
							}
							else
							{
								return (false);
							}
						};
					break;

//----- ueno add---------- end   2007.11.21

                default:
                    return;
            }

            // �Ώۊ��Ԃ̃f�[�^������
            List<TrgtCompSalesRslt> targetSpanSalesRslt;
            targetSpanSalesRslt = salesRsltList.FindAll(predicate);

            // �f�[�^�����Z
            foreach (TrgtCompSalesRslt trgtCompSalesRslt in targetSpanSalesRslt)
            {
                salesMoney += trgtCompSalesRslt.SalesmonyTaxExc;
                salesProfit += trgtCompSalesRslt.SalesmonyTaxExc - trgtCompSalesRslt.Cost;
                salesCount += trgtCompSalesRslt.SalesCount;
            }

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�}�X�^��DataSet�ɕϊ�(���[�p)
        /// </summary>
        /// <param name="extrInfoMAMOK02121EA">��������</param>
        /// <param name="salesTargetList">�ڕW�}�X�^</param>
        /// <param name="salesRsltList">����f�[�^</param>
        /// <param name="salesTargetDataSet">�ڕW�}�X�^DataSet</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^��DataSet�ɕϊ����܂�</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private int ConvertSalesTargetToDataSet(
            ExtrInfo_MAMOK02121EA extrInfoMAMOK02121EA,
            List<SalesTarget> salesTargetList,
            List<TrgtCompSalesRslt> salesRsltList,
			//----- ueno del---------- start 2007.11.21
			//List<LdgCalcRatioMng> ldgCalcRatioMngList,
            //Dictionary<SectionAndDate, HolidaySetting> holidaySettingDic,
			//----- ueno del---------- end   2007.11.21
            out DataSet salesTargetDataSet,
            out string message)
        {
            // ������
            message = "";
            salesTargetDataSet = null;

            try
            {
                // �f�[�^�Z�b�g�쐬
                salesTargetDataSet = new DataSet();
                MAMOK02123EA.SettingDataSet(ref salesTargetDataSet);

                // �f�[�^�i�[
                DataRow row;
                long salesMoney;
                long salesProfit;
                double salesCount;
                long salesMoneyTotal = 0;
                long salesProfitTotal = 0;
                double salesCountTotal = 0.0;
                DateTime salesDateEd;
                foreach (SalesTarget salesTarget in salesTargetList)
                {
                    row = salesTargetDataSet.Tables[MAMOK02123EA.CT_CsSalesTargetDataTable].NewRow();

                    row[MAMOK02123EA.CT_CsSalesTarget_SectionCode] = salesTarget.SectionCode;
                    if (this._sctionNameList.ContainsKey(salesTarget.SectionCode))
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_SectionName] = this._sctionNameList[salesTarget.SectionCode];
                    }
                    else
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_SectionName] = "";
                    }
                    row[MAMOK02123EA.CT_CsSalesTarget_TargetSetCd] = salesTarget.TargetSetCd;
                    row[MAMOK02123EA.CT_CsSalesTarget_TargetContrastCd] = salesTarget.TargetContrastCd;
                    row[MAMOK02123EA.CT_CsSalesTarget_TargetDivideCode] = salesTarget.TargetDivideCode;
                    row[MAMOK02123EA.CT_CsSalesTarget_TargetDivideName] = salesTarget.TargetDivideName;
                    row[MAMOK02123EA.CT_CsSalesTarget_ApplyStaDate] = salesTarget.ApplyStaDate;
                    row[MAMOK02123EA.CT_CsSalesTarget_ApplyEndDate] = salesTarget.ApplyEndDate;
                    row[MAMOK02123EA.CT_CsSalesTarget_EmployeeCode] = salesTarget.EmployeeCode;
                    row[MAMOK02123EA.CT_CsSalesTarget_EmployeeName] = salesTarget.EmployeeName;
//----- ueno add---------- start 2007.11.21
					row[MAMOK02123EA.CT_CsSalesTarget_EmployeeDivCd] = salesTarget.EmployeeDivCd;
					row[MAMOK02123EA.CT_CsSalesTarget_SubSectionCode] = salesTarget.SubSectionCode;
					row[MAMOK02123EA.CT_CsSalesTarget_MinSectionCode] = salesTarget.MinSectionCode;
					row[MAMOK02123EA.CT_CsSalesTarget_BusinessTypeCode] = salesTarget.BusinessTypeCode;
					row[MAMOK02123EA.CT_CsSalesTarget_SalesAreaCode] = salesTarget.SalesAreaCode;
					row[MAMOK02123EA.CT_CsSalesTarget_CustomerCode] = salesTarget.CustomerCode;
//----- ueno add---------- end   2007.11.21

					//----- ueno del---------- start 2007.11.21
					//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormal] = salesTarget.SalesFormal;
					//switch (extrInfoMAMOK02121EA.SalesFormal)
					//{
					//    case 10:
					//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_COUNTER_SALES;
					//        break;
					//    case 11:
					//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_OUTSIDE_SALES;
					//        break;
					//    case 20:
					//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_BUSINESS_SALES;
					//        break;
					//    case 30:
					//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_OTHERS_SALES;
					//        break;
					//    default:
					//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = "";
					//        break;
					//}
					//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormCode] = salesTarget.SalesFormCode;
					//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormName] = salesTarget.SalesFormName;
					//----- ueno del---------- end   2007.11.21
                    row[MAMOK02123EA.CT_CsSalesTarget_MakerCode] = salesTarget.MakerCode;
                    row[MAMOK02123EA.CT_CsSalesTarget_MakerName] = salesTarget.MakerName;
                    row[MAMOK02123EA.CT_CsSalesTarget_GoodsCode] = salesTarget.GoodsCode;
                    row[MAMOK02123EA.CT_CsSalesTarget_GoodsName] = salesTarget.GoodsName;
                    row[MAMOK02123EA.CT_CsSalesTarget_MakerCode_GoodsCode] = salesTarget.MakerCode.ToString() + "_" + salesTarget.GoodsCode.TrimEnd();
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] = salesTarget.SalesTargetMoney;
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] = salesTarget.SalesTargetProfit;
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount] = salesTarget.SalesTargetCount;
					//----- ueno del---------- start 2007.11.21
					//row[MAMOK02123EA.CT_CsSalesTarget_WeekdayRatio] = salesTarget.WeekdayRatio;
					//row[MAMOK02123EA.CT_CsSalesTarget_SatSunRatio] = salesTarget.SatSunRatio;
					//----- ueno del---------- end   2007.11.21

                    AddTargetSales(
                        salesRsltList, 
                        salesTarget,
						//----- ueno del---------- start 2007.11.21
						//ldgCalcRatioMngList,
						//holidaySettingDic,
						//----- ueno del---------- end   2007.11.21
                        out salesMoney, 
                        out salesProfit, 
                        out salesCount);

                    // ����
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] = salesMoney;
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] = salesProfit;
                    row[MAMOK02123EA.CT_CsSalesTarget_SalesCount] = salesCount;

                    salesMoneyTotal += salesMoney;
                    salesProfitTotal += salesProfit;
                    salesCountTotal += salesCount;

                    if (salesTarget.ApplyStaDate <= extrInfoMAMOK02121EA.SalesFixedDate)
                    {
						//----- ueno del---------- start 2007.11.21
						//// �i����
						//row[MAMOK02123EA.CT_CsSalesTarget_Sales_ProgressRate]
						//    = SalesLandingAcs.CalcProgressRatio(
						//        (double)salesMoney,
						//        (double)salesTarget.SalesTargetMoney,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        extrInfoMAMOK02121EA.SalesFixedDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_ProgressRate]
						//    = SalesLandingAcs.CalcProgressRatio(
						//        (double)salesProfit,
						//        (double)salesTarget.SalesTargetProfit,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        extrInfoMAMOK02121EA.SalesFixedDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//row[MAMOK02123EA.CT_CsSalesTarget_Amount_ProgressRate]
						//    = SalesLandingAcs.CalcProgressRatio(
						//        salesCount,
						//        salesTarget.SalesTargetCount,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        extrInfoMAMOK02121EA.SalesFixedDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//----- ueno del---------- end   2007.11.21
						
                        if (extrInfoMAMOK02121EA.SalesFixedDate <= salesTarget.ApplyEndDate)
                        {
                            salesDateEd = extrInfoMAMOK02121EA.SalesFixedDate;
                        }
                        else
                        {
                            salesDateEd = salesTarget.ApplyEndDate;
                        }

						//----- ueno del---------- start 2007.11.21
						//// ���n
						//row[MAMOK02123EA.CT_CsSalesTarget_Sales_Landing]
						//    = SalesLandingAcs.CalcLanding(
						//        (double)salesMoney,
						//        salesTarget.ApplyStaDate,
						//        salesDateEd,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Landing]
						//    = SalesLandingAcs.CalcLanding(
						//        (double)salesProfit,
						//        salesTarget.ApplyStaDate,
						//        salesDateEd,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//row[MAMOK02123EA.CT_CsSalesTarget_Amount_Landing]
						//    = SalesLandingAcs.CalcLanding(
						//        salesCount,
						//        salesTarget.ApplyStaDate,
						//        salesDateEd,
						//        salesTarget.ApplyStaDate,
						//        salesTarget.ApplyEndDate,
						//        salesTarget.SectionCode,
						//        ldgCalcRatioMngList,
						//        holidaySettingDic
						//        );
						//----- ueno del---------- end   2007.11.21
					}
                    else
                    {
                        // �i����
                        row[MAMOK02123EA.CT_CsSalesTarget_Sales_ProgressRate] = 0.0;
                        row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_ProgressRate] = 0.0;
                        row[MAMOK02123EA.CT_CsSalesTarget_Amount_ProgressRate] = 0.0;
                        // ���n
                        row[MAMOK02123EA.CT_CsSalesTarget_Sales_Landing] = 0.0;
                        row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Landing] = 0.0;
                        row[MAMOK02123EA.CT_CsSalesTarget_Amount_Landing] = 0.0;
                    }

                    row[MAMOK02123EA.CT_CsSalesTarget_Sales_Equally] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] - (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney];
                    row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Equally] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] - (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit];
                    row[MAMOK02123EA.CT_CsSalesTarget_Amount_Equally] = (Double)row[MAMOK02123EA.CT_CsSalesTarget_SalesCount] - (Double)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount];

                    if (extrInfoMAMOK02121EA.DispMoneyUnit == ExtrInfo_MAMOK02121EA.MoneyUnit.Thousand)
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_Sales_Landing] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_Sales_Landing] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Landing] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Landing] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_Sales_Equally] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_Sales_Equally] / 1000;
                        row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Equally] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_Equally] / 1000;
                    }

                    if ((Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] != 0)
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_Sales_AccomplishmentRate] = (Double)(Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] / (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney];
                    }
                    if ((Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] != 0)
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_AccomplishmentRate] = (Double)(Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] / (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit];
                    }
                    if ((Double)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount] != 0)
                    {
                        row[MAMOK02123EA.CT_CsSalesTarget_Amount_AccomplishmentRate] = (Double)row[MAMOK02123EA.CT_CsSalesTarget_SalesCount] / (Double)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount];
                    }

                    // �s��ǉ�
                    salesTargetDataSet.Tables[MAMOK02123EA.CT_CsSalesTargetDataTable].Rows.Add(row);

                }

                // �\������v�Z
                foreach (DataRow targetRow in salesTargetDataSet.Tables[MAMOK02123EA.CT_CsSalesTargetDataTable].Rows)
                {
                    if (salesMoneyTotal != 0)
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_Sales_CompositionRatio] = (Double)(Int64)targetRow[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] / salesMoneyTotal;
                    }
                    else
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_Sales_CompositionRatio] = 0;
                    }
                    if (salesProfitTotal != 0)
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_CompositionRatio] = (Double)(Int64)targetRow[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] / salesProfitTotal;
                    }
                    else
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_GrossMargin_CompositionRatio] = 0;
                    }
                    if (salesCountTotal != 0)
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_Amount_CompositionRatio] = (Double)targetRow[MAMOK02123EA.CT_CsSalesTarget_SalesCount] / salesCountTotal;
                    }
                    else
                    {
                        targetRow[MAMOK02123EA.CT_CsSalesTarget_Amount_CompositionRatio] = 0;
                    }
                }

                return ((int)ConstantManagement.DB_Status.ctDB_NORMAL);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڕW�}�X�^��DataSet�ɕϊ�(�O���t�p)
        /// </summary>
        /// <param name="extrInfoMAMOK02121EA">��������</param>
        /// <param name="salesTargetList">�ڕW�}�X�^</param>
        /// <param name="salesRsltList">����f�[�^</param>
        /// <param name="salesTargetDataSet">�ڕW�}�X�^DataSet</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^��DataSet�ɕϊ����܂�</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private int ConvertSalesTargetToDataSetChart(
            ExtrInfo_MAMOK02121EA extrInfo,
            List<SalesTarget> salesTargetList,
            List<TrgtCompSalesRslt> salesRsltList,
			//----- ueno del---------- start 2007.11.21
			//List<LdgCalcRatioMng> ldgCalcRatioMngList,
			//Dictionary<SectionAndDate, HolidaySetting> holidaySettingDic,
			//----- ueno del---------- end   2007.11.21
            out DataSet salesTargetDataSet,
            out string message)
        {
            // ������
            message = "";
            salesTargetDataSet = null;

            try
            {
                // �f�[�^�Z�b�g�쐬
                salesTargetDataSet = new DataSet();
                MAMOK02123EA.SettingDataSet(ref salesTargetDataSet);

                // �f�[�^�i�[
                DataRow row;

                SalesTarget salesTargetWk;

                long salesMoney;
                long salesProfit;
                double salesCount;

                long salesMoneyTotal;
                long salesProfitTotal;
                double salesCountTotal;

                double salesTargetMoneyTotal;
                double salesTargetProfitTotal;
                double salesTargetCountTotal;

				//----- ueno del---------- start 2007.11.21
				//double[] salesTargetMoneyDays;
				//double[] salesTargetProfitDays;
				//double[] salesTargetCountDays;
				//----- ueno del---------- end   2007.11.21

                int dayIndex;

                foreach (SalesTarget salesTarget in salesTargetList)
                {
                    // ������
                    salesMoneyTotal = 0;
                    salesProfitTotal = 0;
                    salesCountTotal = 0;
                    salesTargetMoneyTotal = 0;
                    salesTargetProfitTotal = 0;
                    salesTargetCountTotal = 0;

					//----- ueno del---------- start 2007.11.21
					//// ���ʔ���ڕW�擾
					//SalesLandingAcs.CalcDaysSalesTarget(
					//    out salesTargetMoneyDays,
					//    (double)salesTarget.SalesTargetMoney,
					//    salesTarget.ApplyStaDate,
					//    salesTarget.ApplyEndDate,
					//    salesTarget.SectionCode,
					//    ldgCalcRatioMngList,
					//    holidaySettingDic);
					//SalesLandingAcs.CalcDaysSalesTarget(
					//    out salesTargetProfitDays,
					//    (double)salesTarget.SalesTargetProfit,
					//    salesTarget.ApplyStaDate,
					//    salesTarget.ApplyEndDate,
					//    salesTarget.SectionCode,
					//    ldgCalcRatioMngList,
					//    holidaySettingDic);
					//SalesLandingAcs.CalcDaysSalesTarget(
					//    out salesTargetCountDays,
					//    salesTarget.SalesTargetCount,
					//    salesTarget.ApplyStaDate,
					//    salesTarget.ApplyEndDate,
					//    salesTarget.SectionCode,
					//    ldgCalcRatioMngList,
					//    holidaySettingDic);
					//----- ueno del---------- end   2007.11.21

                    dayIndex = 0;
                    for (DateTime workDate = extrInfo.ApplyStaDateSt; workDate <= extrInfo.ApplyEndDateEd; workDate = workDate.AddDays(1), dayIndex++)
                    {
                        row = salesTargetDataSet.Tables[MAMOK02123EA.CT_CsSalesTargetDataTable].NewRow();

                        row[MAMOK02123EA.CT_CsSalesTarget_SectionCode] = salesTarget.SectionCode;
                        if (this._sctionNameList.ContainsKey(salesTarget.SectionCode))
                        {
                            row[MAMOK02123EA.CT_CsSalesTarget_SectionName] = this._sctionNameList[salesTarget.SectionCode];
                        }
                        else
                        {
                            row[MAMOK02123EA.CT_CsSalesTarget_SectionName] = "";
                        }
                        row[MAMOK02123EA.CT_CsSalesTarget_TargetSetCd] = salesTarget.TargetSetCd;
                        row[MAMOK02123EA.CT_CsSalesTarget_TargetContrastCd] = salesTarget.TargetContrastCd;
                        row[MAMOK02123EA.CT_CsSalesTarget_TargetDivideCode] = salesTarget.TargetDivideCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_TargetDivideName] = salesTarget.TargetDivideName;
                        row[MAMOK02123EA.CT_CsSalesTarget_ApplyStaDate] = workDate;
                        row[MAMOK02123EA.CT_CsSalesTarget_ApplyEndDate] = workDate;
                        row[MAMOK02123EA.CT_CsSalesTarget_EmployeeCode] = salesTarget.EmployeeCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_EmployeeName] = salesTarget.EmployeeName;
//----- ueno add---------- start 2007.11.21
                        row[MAMOK02123EA.CT_CsSalesTarget_EmployeeDivCd] = salesTarget.EmployeeDivCd;
                        row[MAMOK02123EA.CT_CsSalesTarget_SubSectionCode] = salesTarget.SubSectionCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_MinSectionCode] = salesTarget.MinSectionCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_BusinessTypeCode] = salesTarget.BusinessTypeCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesAreaCode] = salesTarget.SalesAreaCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_CustomerCode] = salesTarget.CustomerCode;
//----- ueno add---------- end   2007.11.21

						//----- ueno del---------- start 2007.11.21
						//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormal] = salesTarget.SalesFormal;
						//switch (salesTarget.SalesFormal)
						//{
						//    case 10:
						//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_COUNTER_SALES;
						//        break;
						//    case 11:
						//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_OUTSIDE_SALES;
						//        break;
						//    case 20:
						//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_BUSINESS_SALES;
						//        break;
						//    case 30:
						//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = SalesTarget.SALESFORMAL_OTHERS_SALES;
						//        break;
						//    default:
						//        row[MAMOK02123EA.CT_CsSalesTarget_SalesFormalName] = "";
						//        break;
						//}
						//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormCode] = salesTarget.SalesFormCode;
						//row[MAMOK02123EA.CT_CsSalesTarget_SalesFormName] = salesTarget.SalesFormName;
						//----- ueno del---------- end   2007.11.21
                        row[MAMOK02123EA.CT_CsSalesTarget_MakerCode] = salesTarget.MakerCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_MakerName] = salesTarget.MakerName;
                        row[MAMOK02123EA.CT_CsSalesTarget_GoodsCode] = salesTarget.GoodsCode;
                        row[MAMOK02123EA.CT_CsSalesTarget_GoodsName] = salesTarget.GoodsName;

						//----- ueno del---------- start 2007.11.21
						//salesTargetMoneyTotal += salesTargetMoneyDays[dayIndex];
						//salesTargetProfitTotal += salesTargetProfitDays[dayIndex];
						//salesTargetCountTotal += salesTargetCountDays[dayIndex];
						//----- ueno del---------- end   2007.11.21

                        if (workDate != extrInfo.ApplyEndDateEd)
                        {
                            // �ŏI���ȊO
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] = Math.Round(salesTargetMoneyTotal, MidpointRounding.AwayFromZero);
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] = Math.Round(salesTargetProfitTotal, MidpointRounding.AwayFromZero);
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount] = Math.Round(salesTargetCountTotal, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            // �ŏI���̏ꍇ�A�o�^����Ă���ڕW�l��ݒ�
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] = salesTarget.SalesTargetMoney;
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] = salesTarget.SalesTargetProfit;
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetCount] = salesTarget.SalesTargetCount;
                        }

						//----- ueno del---------- start 2007.11.21
						//row[MAMOK02123EA.CT_CsSalesTarget_WeekdayRatio] = salesTarget.WeekdayRatio;
						//row[MAMOK02123EA.CT_CsSalesTarget_SatSunRatio] = salesTarget.SatSunRatio;
						//----- ueno del---------- end   2007.11.21

                        // ����f�[�^�擾
                        salesTargetWk = salesTarget.Clone();
                        salesTargetWk.ApplyStaDate = workDate;
                        salesTargetWk.ApplyEndDate = workDate;
                        AddTargetSales(
                            salesRsltList, 
                            salesTargetWk,
							//----- ueno del---------- start 2007.11.21
							//ldgCalcRatioMngList,
							//holidaySettingDic,
							//----- ueno del---------- end   2007.11.21
                            out salesMoney, 
                            out salesProfit, 
                            out salesCount);

                        salesMoneyTotal += salesMoney;
                        salesProfitTotal += salesProfit;
                        salesCountTotal += salesCount;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] = salesMoneyTotal;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] = salesProfitTotal;
                        row[MAMOK02123EA.CT_CsSalesTarget_SalesCount] = salesCountTotal;

                        if (extrInfo.DispMoneyUnit == ExtrInfo_MAMOK02121EA.MoneyUnit.Thousand)
                        {
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetMoney] / 1000;
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesTargetProfit] / 1000;
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesMoney] / 1000;
                            row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] = (Int64)row[MAMOK02123EA.CT_CsSalesTarget_SalesProfit] / 1000;
                        }

                        salesTargetDataSet.Tables[MAMOK02123EA.CT_CsSalesTargetDataTable].Rows.Add(row);
                    }
                }

                return ((int)ConstantManagement.DB_Status.ctDB_NORMAL);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
        }

		#endregion

	}
}
