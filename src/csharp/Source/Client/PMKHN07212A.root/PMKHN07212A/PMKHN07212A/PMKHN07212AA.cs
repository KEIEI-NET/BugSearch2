//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 従業員マスタ（エクスポート）
// プログラム概要   : 従業員マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
    /// 従業員マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class EmployeeExportAcs
    {
        #region ■ Private Member
        private EmployeeAcs _employeeAcs;
        // 権限レベル１データ
        private Hashtable AuthorityLevel1Table;
        // 権限レベル２データ
        private Hashtable AuthorityLevel2Table;

        private const string PRINTSET_TABLE = "EmployeeExp";

        private const string JOBTYPE_TITLE = "ロール（業務）";
        private const string EMPLOYMENTFORM_TITLE = "ロール（権限）";

        private const int NULL_JOBTYPE_CODE = 0;
        private const string NULL_JOBTYPE_NAME = "";
        private const int NULL_EMPLOYMENTFORM_CODE = 0;
        private const string NULL_EMPLOYMENTFORM_NAME = "";

        #endregion

        # region ■Constracter
        /// <summary>
        /// 従業員マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public EmployeeExportAcs()
        {
            this.AuthorityLevel1Table = new Hashtable();
            this.AuthorityLevel2Table = new Hashtable();
        }
        #endregion

        #region ■ 従業員マスタ情報検索
        /// <summary>
        /// 従業員マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(EmployeeExportWork condition, out DataTable dataTable)
        {
            this._employeeAcs = new EmployeeAcs();

            int status = 0;
            int checkstatus = 0;

            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            // 従業員結果
            ArrayList employees = null;
            // 従業員詳細結果
            ArrayList employeesDtls = null;
            // 検索
            status = this._employeeAcs.Search(
                                out employees,
                                out employeesDtls,
                                condition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Employee employee in employees)
                {
                    // 抽出処理
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

        #region ■ Private Methods
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee">従業員データ</param>
        /// <param name="condition">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("EmployeeCodeRF", typeof(string));            //  従業員コード
            dataTable.Columns.Add("NameRF", typeof(string));	                //  名称
            dataTable.Columns.Add("KanaRF", typeof(string));	                //  カナ
            dataTable.Columns.Add("ShortNameRF", typeof(string));	            //  短縮名称
            dataTable.Columns.Add("CompanyTelNoRF", typeof(string));	        //  電話番号（会社）
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	        //  電話番号（携帯）
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	        //  メールアドレス１
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	        //  メールアドレス２
            dataTable.Columns.Add("SexNameRF", typeof(string));                 //  性別名称
            dataTable.Columns.Add("BirthdayRF", typeof(string));	            //  生年月日

            dataTable.Columns.Add("EnterCompanyDateRF", typeof(string));	    //  入社日
            dataTable.Columns.Add("RetirementDateRF", typeof(string));	        //  退社日
            dataTable.Columns.Add("BelongSectionCodeRF", typeof(string));	    //  所属拠点コード
            dataTable.Columns.Add("BelongSubSectionCodeRF", typeof(string));	//  部門コード	
            dataTable.Columns.Add("UOESnmDivRF", typeof(string));	            //  ＵＯＥ略称区分
            dataTable.Columns.Add("AuthorityLevel1RF", typeof(string));	        //  権限レベル１→権限レベル名称
            dataTable.Columns.Add("AuthorityLevel2RF", typeof(string));         //  権限レベル２→権限レベル名称
            dataTable.Columns.Add("EmployAnalysCode1RF", typeof(string));	    //  従業員分析コード１
            dataTable.Columns.Add("EmployAnalysCode2RF", typeof(string));	    //  従業員分析コード２
            dataTable.Columns.Add("EmployAnalysCode3RF", typeof(string));	    //  従業員分析コード３
            dataTable.Columns.Add("EmployAnalysCode4RF", typeof(string));	    //  従業員分析コード４
            dataTable.Columns.Add("EmployAnalysCode5RF", typeof(string));	    //  従業員分析コード５
            dataTable.Columns.Add("EmployAnalysCode6RF", typeof(string));	    //  従業員分析コード６
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="employee">検索結果</param>
        /// <param name="employeeDtl">検索結果</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
                // 権限レベル１の設定
                this.AuthorityLevel1Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow jobTypeRow in authorityLevelDB.JobTypeTbl)
                {
                    this.AuthorityLevel1Table.Add(jobTypeRow.AuthorityLevelCd.ToString(), jobTypeRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel1Table.ContainsKey(NULL_JOBTYPE_CODE.ToString()))
                {
                    this.AuthorityLevel1Table.Add(NULL_JOBTYPE_CODE.ToString(), NULL_JOBTYPE_NAME);
                }

                // 権限レベル２の設定
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
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
