//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �]�ƈ��}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class EmployeeExportAcs
    {
        #region �� Private Member
        private EmployeeAcs _employeeAcs;
        // �������x���P�f�[�^
        private Hashtable AuthorityLevel1Table;
        // �������x���Q�f�[�^
        private Hashtable AuthorityLevel2Table;

        private const string PRINTSET_TABLE = "EmployeeExp";

        private const string JOBTYPE_TITLE = "���[���i�Ɩ��j";
        private const string EMPLOYMENTFORM_TITLE = "���[���i�����j";

        private const int NULL_JOBTYPE_CODE = 0;
        private const string NULL_JOBTYPE_NAME = "";
        private const int NULL_EMPLOYMENTFORM_CODE = 0;
        private const string NULL_EMPLOYMENTFORM_NAME = "";

        #endregion

        # region ��Constracter
        /// <summary>
        /// �]�ƈ��}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public EmployeeExportAcs()
        {
            this.AuthorityLevel1Table = new Hashtable();
            this.AuthorityLevel2Table = new Hashtable();
        }
        #endregion

        #region �� �]�ƈ��}�X�^��񌟍�
        /// <summary>
        /// �]�ƈ��}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(EmployeeExportWork condition, out DataTable dataTable)
        {
            this._employeeAcs = new EmployeeAcs();

            int status = 0;
            int checkstatus = 0;

            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);
            // �]�ƈ�����
            ArrayList employees = null;
            // �]�ƈ��ڍ׌���
            ArrayList employeesDtls = null;
            // ����
            status = this._employeeAcs.Search(
                                out employees,
                                out employeesDtls,
                                condition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Employee employee in employees)
                {
                    // ���o����
                    checkstatus = DataCheck(employee, condition);
                    if (checkstatus == 0)
                    {
                        foreach (EmployeeDtl employeeDtl in employeesDtls)
                        {
                            if (employeeDtl.EmployeeCode == employee.EmployeeCode)
                            {
                                ConverToDataSetWarehouseInf(employee, employeeDtl, ref dataTable);
                            }
                        }
                    }
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region �� Private Methods
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee">�]�ƈ��f�[�^</param>
        /// <param name="condition">��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataCheck(Employee employee, EmployeeExportWork condition)
        {
            int status = 0;
            if (employee.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(employee.BelongSectionCode.Trim()) && !String.IsNullOrEmpty(condition.SectionCdSt.Trim())
                && Int32.Parse(condition.SectionCdSt.Trim()) > Int32.Parse(employee.BelongSectionCode.Trim()))
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(employee.BelongSectionCode.Trim()) && !String.IsNullOrEmpty(condition.SectionCdEd.Trim())
                && Int32.Parse(condition.SectionCdEd.Trim()) < Int32.Parse(employee.BelongSectionCode.Trim()))
            {
                status = -1;
                return status;
            }

            if (!String.IsNullOrEmpty(employee.EmployeeCode.Trim()) && !String.IsNullOrEmpty(condition.EmployeeCdSt.Trim())
                && condition.EmployeeCdSt.Trim().CompareTo(employee.EmployeeCode.Trim()) == 1)
            {
                status = -1;
                return status;
            }
            if (!String.IsNullOrEmpty(employee.EmployeeCode.Trim()) && !String.IsNullOrEmpty(condition.EmployeeCdEd.Trim())
                && condition.EmployeeCdEd.Trim().CompareTo(employee.EmployeeCode.Trim()) == -1)
            {
                status = -1;
                return status;
            }
            return status;
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("EmployeeCodeRF", typeof(string));            //  �]�ƈ��R�[�h
            dataTable.Columns.Add("NameRF", typeof(string));	                //  ����
            dataTable.Columns.Add("KanaRF", typeof(string));	                //  �J�i
            dataTable.Columns.Add("ShortNameRF", typeof(string));	            //  �Z�k����
            dataTable.Columns.Add("CompanyTelNoRF", typeof(string));	        //  �d�b�ԍ��i��Ёj
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	        //  �d�b�ԍ��i�g�сj
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	        //  ���[���A�h���X�P
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	        //  ���[���A�h���X�Q
            dataTable.Columns.Add("SexNameRF", typeof(string));                 //  ���ʖ���
            dataTable.Columns.Add("BirthdayRF", typeof(string));	            //  ���N����

            dataTable.Columns.Add("EnterCompanyDateRF", typeof(string));	    //  ���Г�
            dataTable.Columns.Add("RetirementDateRF", typeof(string));	        //  �ގГ�
            dataTable.Columns.Add("BelongSectionCodeRF", typeof(string));	    //  �������_�R�[�h
            dataTable.Columns.Add("BelongSubSectionCodeRF", typeof(string));	//  ����R�[�h	
            dataTable.Columns.Add("UOESnmDivRF", typeof(string));	            //  �t�n�d���̋敪
            dataTable.Columns.Add("AuthorityLevel1RF", typeof(string));	        //  �������x���P���������x������
            dataTable.Columns.Add("AuthorityLevel2RF", typeof(string));         //  �������x���Q���������x������
            dataTable.Columns.Add("EmployAnalysCode1RF", typeof(string));	    //  �]�ƈ����̓R�[�h�P
            dataTable.Columns.Add("EmployAnalysCode2RF", typeof(string));	    //  �]�ƈ����̓R�[�h�Q
            dataTable.Columns.Add("EmployAnalysCode3RF", typeof(string));	    //  �]�ƈ����̓R�[�h�R
            dataTable.Columns.Add("EmployAnalysCode4RF", typeof(string));	    //  �]�ƈ����̓R�[�h�S
            dataTable.Columns.Add("EmployAnalysCode5RF", typeof(string));	    //  �]�ƈ����̓R�[�h�T
            dataTable.Columns.Add("EmployAnalysCode6RF", typeof(string));	    //  �]�ƈ����̓R�[�h�U
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="employee">��������</param>
        /// <param name="employeeDtl">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetWarehouseInf(Employee employee, EmployeeDtl employeeDtl, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();

            dataRow["EmployeeCodeRF"] = AppendZero(employee.EmployeeCode.ToString(), 4);
            dataRow["NameRF"] = GetSubString(employee.Name, 30);
            dataRow["KanaRF"] = GetSubString(employee.Kana, 30);
            dataRow["ShortNameRF"] = GetSubString(employee.ShortName, 5);
            dataRow["CompanyTelNoRF"] = GetSubString(employee.CompanyTelNo, 16);
            dataRow["PortableTelNoRF"] = GetSubString(employee.PortableTelNo, 16);
            dataRow["MailAddress1RF"] = GetSubString(employeeDtl.MailAddress1,40);
            dataRow["MailAddress2RF"] = GetSubString(employeeDtl.MailAddress2,40);
            dataRow["SexNameRF"] = GetSubString(employee.SexName, 2);
            if (employee.Birthday == DateTime.MinValue)
            {
                dataRow["BirthdayRF"] = string.Empty;
            }
            else
            {
                dataRow["BirthdayRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", employee.Birthday).ToString();
            }
            if (employee.EnterCompanyDate == DateTime.MinValue)
            {
                dataRow["EnterCompanyDateRF"] = string.Empty;
            }
            else
            {
                dataRow["EnterCompanyDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", employee.EnterCompanyDate).ToString();
            }
            if (employee.RetirementDate == DateTime.MinValue)
            {
                dataRow["RetirementDateRF"] = string.Empty;
            }
            else
            {
                dataRow["RetirementDateRF"] = TDateTime.DateTimeToLongDate("YYYYMMDD", employee.RetirementDate).ToString();
            }
            dataRow["BelongSectionCodeRF"] = AppendZero(employee.BelongSectionCode.ToString(), 2);
            dataRow["BelongSubSectionCodeRF"] = AppendZero(employeeDtl.BelongSubSectionCode.ToString(),2);
            dataRow["UOESnmDivRF"] = employeeDtl.UOESnmDiv.Trim();

            using (AuthorityLevelLcDBAgent authorityLevelDB = new AuthorityLevelLcDBAgent())
            {
                // �������x���P�̐ݒ�
                this.AuthorityLevel1Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow jobTypeRow in authorityLevelDB.JobTypeTbl)
                {
                    this.AuthorityLevel1Table.Add(jobTypeRow.AuthorityLevelCd.ToString(), jobTypeRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel1Table.ContainsKey(NULL_JOBTYPE_CODE.ToString()))
                {
                    this.AuthorityLevel1Table.Add(NULL_JOBTYPE_CODE.ToString(), NULL_JOBTYPE_NAME);
                }

                // �������x���Q�̐ݒ�
                this.AuthorityLevel2Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow employmentFormRow in authorityLevelDB.EmploymentFormTbl)
                {
                    this.AuthorityLevel2Table.Add(employmentFormRow.AuthorityLevelCd.ToString(), employmentFormRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel2Table.ContainsKey(NULL_EMPLOYMENTFORM_CODE.ToString()))
                {
                    this.AuthorityLevel2Table.Add(NULL_EMPLOYMENTFORM_CODE.ToString(), NULL_EMPLOYMENTFORM_NAME);
                }
            }

            if (employee.AuthorityLevel1 != 0 && this.AuthorityLevel1Table.ContainsKey(Convert.ToString(employee.AuthorityLevel1)))
            {
                dataRow["AuthorityLevel1RF"] = AuthorityLevel1Table[Convert.ToString(employee.AuthorityLevel1)];
            }
            if (employee.AuthorityLevel2 != 0 && this.AuthorityLevel2Table.ContainsKey(Convert.ToString(employee.AuthorityLevel2)))
            {
                dataRow["AuthorityLevel2RF"] = AuthorityLevel2Table[Convert.ToString(employee.AuthorityLevel2)];
            }
            dataRow["EmployAnalysCode1RF"] = employeeDtl.EmployAnalysCode1.ToString();
            dataRow["EmployAnalysCode2RF"] = employeeDtl.EmployAnalysCode2.ToString();
            dataRow["EmployAnalysCode3RF"] = employeeDtl.EmployAnalysCode3.ToString();
            dataRow["EmployAnalysCode4RF"] = employeeDtl.EmployAnalysCode4.ToString();
            dataRow["EmployAnalysCode5RF"] = employeeDtl.EmployAnalysCode5.ToString();
            dataRow["EmployAnalysCode6RF"] = employeeDtl.EmployAnalysCode6.ToString();


            dataTable.Rows.Add(dataRow);
        }


        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();
            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            bfString = bfString.Trim();
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }
        #endregion
    }
}
