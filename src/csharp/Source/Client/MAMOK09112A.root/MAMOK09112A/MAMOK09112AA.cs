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
    /// �]�ƈ��ʔ���ڕW�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note	   : �]�ƈ��ʔ���ڕW�}�X�^�ւ̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : NEPCO</br>
    /// <br>Date	   : 2007.05.08</br>
    /// <br></br>
    /// <br>UpdateNote: 2007.10.01 ��� ���b</br>
    /// <br>            ����.DC�p�ɕύX�B�i���ڒǉ��E�폜�j</br>
	/// <br>            2007.11.21 ��� �O�M</br>
	/// <br>            �]�ƈ��ʔ���ڕW�C���i���ڒǉ��E�폜�j</br>
    /// </remarks>
    public class EmpSalesTargetAcs
    {
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

        #region Private Member

        ///// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IEmpSalesTargetDB _iEmpSalesTargetDB = null;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// �ڕW�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �����[�g�I�u�W�F�N�g���C���X�^���X�����܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public EmpSalesTargetAcs()
        {
            // �I�����C���̏ꍇ
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iEmpSalesTargetDB = (IEmpSalesTargetDB)MediationEmpSalesTargetDB.GetEmpSalesTargetDB();
                }
                catch (Exception)
                {
                    // �I�t���C������null���Z�b�g
                    this._iEmpSalesTargetDB = null;
                }
            }
            else
            // �I�t���C���̏ꍇ
            {
                // �I�t���C������null���Z�b�g
                this._iEmpSalesTargetDB = null;
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
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iEmpSalesTargetDB == null)
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
        /// <param name="empSalesTarget">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Write(ref List<EmpSalesTarget> empSalesTargetList)
        {
            EmpSalesTargetWork empSalesTargetWork;
            ArrayList paraList = new ArrayList();

            // UI�f�[�^�N���X�����[�N
            foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
            {
                empSalesTargetWork = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget);
                paraList.Add(empSalesTargetWork);
            }

            object paraobj = paraList;

            int status = 0;
            try
            {
                // �������ݏ���
                status = this._iEmpSalesTargetDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }

                // ���[�N��UI�f�[�^�N���X
                paraList = (ArrayList)paraobj;
                EmpSalesTarget empSalesTarget2;
                empSalesTargetList.Clear();
                foreach (EmpSalesTargetWork empSalesTargetWork2 in paraList)
                {
                    empSalesTarget2 = CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork2);
                    empSalesTargetList.Add(empSalesTarget2);
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
        /// <param name="empSalesTarget">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : �폜�������s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Delete(List<EmpSalesTarget> empSalesTargetList)
        {
            EmpSalesTargetWork [] empSalesTargetWorkList;
            empSalesTargetWorkList = new EmpSalesTargetWork[empSalesTargetList.Count];

            // UI�f�[�^�N���X�����[�N
            for (int index = 0; index < empSalesTargetList.Count; index++)
            {
                empSalesTargetWorkList[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetList[index]);
            }

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(empSalesTargetWorkList);

            int status = 0;
            try
            {
                // �������ݏ���
                status = this._iEmpSalesTargetDB.Delete(parabyte);
                if (status != 0)
                {
                    return (status);
                }
                // static�폜

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
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Search(
            out List<EmpSalesTarget> retList,
            ExtrInfo_MAMOK09117EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<EmpSalesTarget>();

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // �p�����[�^
                    SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork = new SearchEmpSalesTargetParaWork();
                    searchEmpSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
                    searchEmpSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
                    searchEmpSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
                    searchEmpSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
                    searchEmpSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
                    searchEmpSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
                    searchEmpSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
                    searchEmpSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
                    searchEmpSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
                    searchEmpSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
                    searchEmpSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
                    searchEmpSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;
                    searchEmpSalesTargetParaWork.EmployeeCode = extrInfo.EmployeeCode;
					//----- ueno add---------- start 2007.11.21
					searchEmpSalesTargetParaWork.EmployeeDivCd = extrInfo.EmployeeDivCd;
					//----- ueno add---------- end   2007.11.21
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    searchEmpSalesTargetParaWork.SubSectionCode = extrInfo.SubSectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
                    //searchEmpSalesTargetParaWork.MinSectionCode = extrInfo.MinSectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // �ڕW�}�X�^����
                    object objectEmpSalesTargetWork = null;
                    status = this._iEmpSalesTargetDB.Search(out objectEmpSalesTargetWork, searchEmpSalesTargetParaWork, 0, logicalMode);
                    if (status != 0)
                    {
                        return (status);
                    }

                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList paraList = objectEmpSalesTargetWork as ArrayList;
                    if (paraList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in paraList)
                    {
//----- ueno add---------- start 2007.11.21
						// �ڕW�Δ�敪���u0�v�̏ꍇ�A�]�ƈ��݂̂�ݒ肷��i�u10:���_�v�ȊO��ݒ�j
						if ((extrInfo.TargetContrastCd == 0)&&(empSalesTargetWork.TargetContrastCd == 10))
						{
							continue;
						}
//----- ueno add---------- end   2007.11.21

                        retList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^���[�N�N���X�˖ڕW�}�X�^�N���X�j
        /// </summary>
        /// <param name="empSalesTargetWork">�ڕW�}�X�^���[�N�N���X</param>
        /// <returns>�ڕW�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^���[�N�N���X����ڕW�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private EmpSalesTarget CopyToEmpSalesTargetFromEmpSalesTargetWork(EmpSalesTargetWork empSalesTargetWork)
        {
            EmpSalesTarget empSalesTarget = new EmpSalesTarget();

            empSalesTarget.CreateDateTime = empSalesTargetWork.CreateDateTime;
            empSalesTarget.UpdateDateTime = empSalesTargetWork.UpdateDateTime;
            empSalesTarget.EnterpriseCode = empSalesTargetWork.EnterpriseCode;
            empSalesTarget.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;
            empSalesTarget.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;
            empSalesTarget.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;
            empSalesTarget.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;
            empSalesTarget.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;

            empSalesTarget.SectionCode = empSalesTargetWork.SectionCode;
            empSalesTarget.TargetSetCd = empSalesTargetWork.TargetSetCd;
            empSalesTarget.TargetContrastCd = empSalesTargetWork.TargetContrastCd;
            empSalesTarget.TargetDivideCode = empSalesTargetWork.TargetDivideCode;
            empSalesTarget.TargetDivideName = empSalesTargetWork.TargetDivideName;
			//----- ueno add---------- start 2007.11.21
			empSalesTarget.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            empSalesTarget.SubSectionCode = empSalesTargetWork.SubSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //empSalesTarget.MinSectionCode = empSalesTargetWork.MinSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            empSalesTarget.EmployeeCode = empSalesTargetWork.EmployeeCode;
            empSalesTarget.EmployeeName = empSalesTargetWork.EmployeeName;
            empSalesTarget.ApplyStaDate = empSalesTargetWork.ApplyStaDate;
            empSalesTarget.ApplyEndDate = empSalesTargetWork.ApplyEndDate;
            empSalesTarget.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;
            empSalesTarget.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;
            empSalesTarget.SalesTargetCount = empSalesTargetWork.SalesTargetCount;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //empSalesTarget.WeekdayRatio = empSalesTargetWork.WeekdayRatio;
            //empSalesTarget.SatSunRatio = empSalesTargetWork.SatSunRatio;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return empSalesTarget;
        }

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڕW�}�X�^�N���X�˖ڕW�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="empSalesTarget">�ڕW�}�X�^�N���X</param>
        /// <returns>�ڕW�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note	   : �ڕW�}�X�^�N���X����ڕW�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromEmpSalesTarget(EmpSalesTarget empSalesTarget)
        {
            EmpSalesTargetWork empSalesTargetWork = new EmpSalesTargetWork();

            empSalesTargetWork.CreateDateTime = empSalesTarget.CreateDateTime;
            empSalesTargetWork.UpdateDateTime = empSalesTarget.UpdateDateTime;
            empSalesTargetWork.EnterpriseCode = empSalesTarget.EnterpriseCode;
            empSalesTargetWork.FileHeaderGuid = empSalesTarget.FileHeaderGuid;
            empSalesTargetWork.UpdEmployeeCode = empSalesTarget.UpdEmployeeCode;
            empSalesTargetWork.UpdAssemblyId1 = empSalesTarget.UpdAssemblyId1;
            empSalesTargetWork.UpdAssemblyId2 = empSalesTarget.UpdAssemblyId2;
            empSalesTargetWork.LogicalDeleteCode = empSalesTarget.LogicalDeleteCode;

            empSalesTargetWork.SectionCode = empSalesTarget.SectionCode;
            empSalesTargetWork.TargetSetCd = empSalesTarget.TargetSetCd;
            empSalesTargetWork.TargetContrastCd = empSalesTarget.TargetContrastCd;
            empSalesTargetWork.TargetDivideCode = empSalesTarget.TargetDivideCode;
            empSalesTargetWork.TargetDivideName = empSalesTarget.TargetDivideName;
			//----- ueno add---------- start 2007.11.21
			empSalesTargetWork.EmployeeDivCd = empSalesTarget.EmployeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            empSalesTargetWork.SubSectionCode = empSalesTarget.SubSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //empSalesTargetWork.MinSectionCode = empSalesTarget.MinSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            empSalesTargetWork.EmployeeCode = empSalesTarget.EmployeeCode;
            empSalesTargetWork.EmployeeName = empSalesTarget.EmployeeName;
            empSalesTargetWork.ApplyStaDate = empSalesTarget.ApplyStaDate;
            empSalesTargetWork.ApplyEndDate = empSalesTarget.ApplyEndDate;
            empSalesTargetWork.SalesTargetMoney = empSalesTarget.SalesTargetMoney;
            empSalesTargetWork.SalesTargetProfit = empSalesTarget.SalesTargetProfit;
            empSalesTargetWork.SalesTargetCount = empSalesTarget.SalesTargetCount;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //empSalesTargetWork.WeekdayRatio = empSalesTarget.WeekdayRatio;
            //empSalesTargetWork.SatSunRatio = empSalesTarget.SatSunRatio;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return empSalesTargetWork;
        }

        #endregion
    }
}
