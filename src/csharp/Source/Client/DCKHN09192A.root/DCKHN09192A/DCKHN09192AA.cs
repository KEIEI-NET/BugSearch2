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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�ʔ���ڕW�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note	   : ���Ӑ�ʔ���ڕW�}�X�^�ւ̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30167 ���@�O�M</br>
    /// <br>Date	   : 2007.11.21</br>
    /// <br></br>
    /// </remarks>
    public class CustSalesTargetAcs
    {
        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�����C�����[�h�̗񋓌^�ł��B
        /// </summary>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }
        #endregion

        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ICustSalesTargetDB _iCustSalesTargetDB = null;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// �ڕW�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �����[�g�I�u�W�F�N�g���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public CustSalesTargetAcs()
        {
            // �I�����C���̏ꍇ
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iCustSalesTargetDB = (ICustSalesTargetDB)MediationCustSalesTargetDB.GetCustSalesTargetDB();
                }
                catch (Exception)
                {
                    // �I�t���C������null���Z�b�g
                    this._iCustSalesTargetDB = null;
                }
            }
            else
            // �I�t���C���̏ꍇ
            {
                // �I�t���C������null���Z�b�g
                this._iCustSalesTargetDB = null;
            }
        }
        #endregion Constructor

        #region Public Methods
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note	   : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCustSalesTargetDB == null)
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
        /// <param name="custSalesTarget">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Write(ref List<CustSalesTarget> custSalesTargetList)
        {
			CustSalesTargetWork custSalesTargetWork;
			ArrayList paraList = new ArrayList();

			// UI�f�[�^�N���X�����[�N
			foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
			{
				custSalesTargetWork = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget);
				paraList.Add(custSalesTargetWork);
			}

			object paraobj = paraList;

			int status = 0;
			try
			{
				// �������ݏ���
			    status = this._iCustSalesTargetDB.Write(ref paraobj);
				if (status != 0)
				{
					return (status);
				}

			    // ���[�N��UI�f�[�^�N���X
			    paraList = (ArrayList)paraobj;
			    CustSalesTarget custSalesTarget2;
			    custSalesTargetList.Clear();
			    foreach (CustSalesTargetWork custSalesTargetWork2 in paraList)
			    {
			        custSalesTarget2 = CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork2);
			        custSalesTargetList.Add(custSalesTarget2);
			    }

                return (0);

			}
			catch (Exception ex)
			{
				// �ʐM�G���[��-1��߂�
				string err = ex.Message;
				return (-1);
			}
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="custSalesTarget">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �폜�������s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Delete(List<CustSalesTarget> custSalesTargetList)
        {
			CustSalesTargetWork[] custSalesTargetWorkList;
			custSalesTargetWorkList = new CustSalesTargetWork[custSalesTargetList.Count];

			// UI�f�[�^�N���X�����[�N
			for (int index = 0; index < custSalesTargetList.Count; index++)
			{
				custSalesTargetWorkList[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetList[index]);
			}

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(custSalesTargetWorkList);

			int status = 0;
			try
			{
				// �폜����
			    status = this._iCustSalesTargetDB.Delete(parabyte);
				if (status != 0)
				{
					return (status);
				}

			    return (0);
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��߂�
				return (-1);
			}
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">���X�g</param>
        /// <param name="extrInfo">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �����������s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Search(
            out List<CustSalesTarget> retList,
            ExtrInfo_DCKHN09193EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<CustSalesTarget>();

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // �p�����[�^
					SearchCustSalesTargetParaWork searchCustSalesTargetParaWork = new SearchCustSalesTargetParaWork();
					searchCustSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
					searchCustSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
					searchCustSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
					searchCustSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
					searchCustSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
					searchCustSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
					searchCustSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
					searchCustSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
					searchCustSalesTargetParaWork.BusinessTypeCode = extrInfo.BusinessTypeCode;
					searchCustSalesTargetParaWork.SalesAreaCode = extrInfo.SalesAreaCode;
					searchCustSalesTargetParaWork.CustomerCode = extrInfo.CustomerCode;
					searchCustSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
					searchCustSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
					searchCustSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
					searchCustSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;

					// �ڕW�}�X�^����
					object objectCustSalesTargetWork = null;
					status = this._iCustSalesTargetDB.Search(out objectCustSalesTargetWork, searchCustSalesTargetParaWork, 0, logicalMode);
					if (status != 0)
					{
						return (status);
					}

					// �p�����[�^���n���ė��Ă��邩�m�F
					ArrayList paraList = objectCustSalesTargetWork as ArrayList;
					if (paraList == null)
					{
						return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
					}

					// �f�[�^�ϊ�
					foreach (CustSalesTargetWork custSalesTargetWork in paraList)
					{
						retList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
					}
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                }

                return ((int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL);

            }
        }

        #endregion

        # region Private Methods

		///*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^���[�N�N���X�˖ڕW�}�X�^�N���X�j
		/// </summary>
		/// <param name="custSalesTargetWork">�ڕW�}�X�^���[�N�N���X</param>
		/// <returns>�ڕW�}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note	   : �ڕW�}�X�^���[�N�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date	   : 2007.11.21</br>
		/// </remarks>
		private CustSalesTarget CopyToCustSalesTargetFromCustSalesTargetWork(CustSalesTargetWork custSalesTargetWork)
		{
			CustSalesTarget custSalesTarget = new CustSalesTarget();

			custSalesTarget.CreateDateTime = custSalesTargetWork.CreateDateTime;
			custSalesTarget.UpdateDateTime = custSalesTargetWork.UpdateDateTime;
			custSalesTarget.EnterpriseCode = custSalesTargetWork.EnterpriseCode;
			custSalesTarget.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;
			custSalesTarget.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;
			custSalesTarget.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;
			custSalesTarget.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;
			custSalesTarget.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;

			custSalesTarget.SectionCode = custSalesTargetWork.SectionCode;
			custSalesTarget.TargetSetCd = custSalesTargetWork.TargetSetCd;
			custSalesTarget.TargetContrastCd = custSalesTargetWork.TargetContrastCd;
			custSalesTarget.TargetDivideCode = custSalesTargetWork.TargetDivideCode;
			custSalesTarget.TargetDivideName = custSalesTargetWork.TargetDivideName;
			custSalesTarget.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;
			custSalesTarget.SalesAreaCode = custSalesTargetWork.SalesAreaCode;
			custSalesTarget.CustomerCode = custSalesTargetWork.CustomerCode;
			custSalesTarget.ApplyStaDate = custSalesTargetWork.ApplyStaDate;
			custSalesTarget.ApplyEndDate = custSalesTargetWork.ApplyEndDate;
			custSalesTarget.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;
			custSalesTarget.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;
			custSalesTarget.SalesTargetCount = custSalesTargetWork.SalesTargetCount;

			return custSalesTarget;
		}

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˖ڕW�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="custSalesTarget">�ڕW�}�X�^�N���X</param>
        /// <returns>�ڕW�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�N���X����ڕW�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
		private CustSalesTargetWork CopyToCustSalesTargetWorkFromCustSalesTarget(CustSalesTarget custSalesTarget)
		{
			CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

			custSalesTargetWork.CreateDateTime = custSalesTarget.CreateDateTime;
			custSalesTargetWork.UpdateDateTime = custSalesTarget.UpdateDateTime;
			custSalesTargetWork.EnterpriseCode = custSalesTarget.EnterpriseCode;
			custSalesTargetWork.FileHeaderGuid = custSalesTarget.FileHeaderGuid;
			custSalesTargetWork.UpdEmployeeCode = custSalesTarget.UpdEmployeeCode;
			custSalesTargetWork.UpdAssemblyId1 = custSalesTarget.UpdAssemblyId1;
			custSalesTargetWork.UpdAssemblyId2 = custSalesTarget.UpdAssemblyId2;
			custSalesTargetWork.LogicalDeleteCode = custSalesTarget.LogicalDeleteCode;

			custSalesTargetWork.SectionCode = custSalesTarget.SectionCode;
			custSalesTargetWork.TargetSetCd = custSalesTarget.TargetSetCd;
			custSalesTargetWork.TargetContrastCd = custSalesTarget.TargetContrastCd;
			custSalesTargetWork.TargetDivideCode = custSalesTarget.TargetDivideCode;
			custSalesTargetWork.TargetDivideName = custSalesTarget.TargetDivideName;
			custSalesTargetWork.BusinessTypeCode = custSalesTarget.BusinessTypeCode;
			custSalesTargetWork.SalesAreaCode = custSalesTarget.SalesAreaCode;
			custSalesTargetWork.CustomerCode = custSalesTarget.CustomerCode;
			custSalesTargetWork.ApplyStaDate = custSalesTarget.ApplyStaDate;
			custSalesTargetWork.ApplyEndDate = custSalesTarget.ApplyEndDate;
			custSalesTargetWork.SalesTargetMoney = custSalesTarget.SalesTargetMoney;
			custSalesTargetWork.SalesTargetProfit = custSalesTarget.SalesTargetProfit;
			custSalesTargetWork.SalesTargetCount = custSalesTarget.SalesTargetCount;

			return custSalesTargetWork;
		}

        #endregion
    }
}
