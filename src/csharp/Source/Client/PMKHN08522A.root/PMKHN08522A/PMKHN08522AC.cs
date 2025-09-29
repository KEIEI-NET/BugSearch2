using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 従業員マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class EmployeeSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private EmployeeAcs _employeeAcs;
        private SubSectionAcs _subSectionAcs;

        // 権限レベル１データ
        private Hashtable AuthorityLevel1Table;
        // 権限レベル２データ
        private Hashtable AuthorityLevel2Table;
        private Dictionary<int, SubSection> _subSectionDic;
        /// <summary>拠点情報格納バッファ</summary>
        private Hashtable _secInfTable = null;

        private const int NULL_JOBTYPE_CODE = 0;
        private const string NULL_JOBTYPE_NAME = "";
        private const int NULL_EMPLOYMENTFORM_CODE = 0;
        private const string NULL_EMPLOYMENTFORM_NAME = "";

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 従業員マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 従業員マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public EmployeeSetAcs()
		{

            this.AuthorityLevel1Table = new Hashtable();
            this.AuthorityLevel2Table = new Hashtable();
            this._subSectionAcs = new SubSectionAcs();

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

			
        }

        

        /// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

	

		/// <summary>
		/// 従業員マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, EmployeePrintWork employeePrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, employeePrintWork);
		}

		/// <summary>
		/// 従業員マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, EmployeePrintWork employeePrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, employeePrintWork);
		}

		

		/// <summary>
		/// 従業員マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, EmployeePrintWork employeePrintWork)
		{

            this._employeeAcs = new EmployeeAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();
            
            ArrayList employees = null;
            ArrayList employeesDtls = null;

            if (logicalMode == ConstantManagement.LogicalMode.GetData01)
            {
                status = this._employeeAcs.SearchAll(
                                out employees,
                                out employeesDtls,
                                enterpriseCode);
            }
            else
            {
                status = this._employeeAcs.Search(
                                out employees,
                                out employeesDtls,
                                enterpriseCode);
            }

            foreach (Employee employee in employees)
            {
                // 抽出処理
                checkstatus = DataCheck(employee, employeePrintWork);
                if (checkstatus == 0)
                {
                    foreach (EmployeeDtl employeeDtl in employeesDtls)
                    {
                        if (employeeDtl.EmployeeCode == employee.EmployeeCode)
                        {
                            //拠点情報クラスへメンバコピー
                            retList.Add(CopyToEmployeeSetFromSecInfoSetWork(employee, employeeDtl, enterpriseCode));
                            
                        }
                    }
                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// 拠点情報検索
        /// </summary>
        /// <param name="sectionGuideNm"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int GetSecInf(out string sectionGuideNm, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            SecInfoSet secInfoSet = null;

            sectionGuideNm = "";

            // 自社情報読み込み
            status = ReadSecInf(out secInfoSet, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sectionGuideNm = secInfoSet.SectionGuideNm;
            }

            return status;
        }

        /// <summary>
        /// 拠点情報読込処理
        /// </summary>
        /// <param name="SecInfoSet"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadSecInf(out SecInfoSet secInfoSet, string enterpriseCode, string sectionCode)
        {
            int status = 0;
            secInfoSet = null;

            status = SetSecInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読み込み失敗
                return status;
            }

            // テーブルにキーが存在している
            if (this._secInfTable.ContainsKey(sectionCode) == true)
            {
                secInfoSet = ((SecInfoSet)this._secInfTable[sectionCode]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// 拠点情報検索処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetSecInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._secInfTable == null)
            {
                this._secInfTable = new Hashtable();
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._secInfTable.Clear();
                status = secInfoSetAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (this._secInfTable.ContainsKey(secInfoSet.SectionCode) == false)
                        {
                            this._secInfTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
                        }
                    }
                }

            }
            return status;
        }

        /// <summary>
        /// 部門名称取得処理
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns>部門名称</returns>
        /// <remarks>
        /// <br>Note       : 部門名称を取得します。</br>
        /// </remarks>
        private string GetSubSectionName(int subSectionCode, string enterpriseCode)
        {
            string subSectionName = "";
            ReadSubSection(enterpriseCode);
            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                subSectionName = this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }

            return subSectionName;
        }

        /// <summary>
        /// 部門マスタ読込処理
        /// </summary>
        private void ReadSubSection(string enterpriseCode)
        {
            try
            {
                if (this._subSectionDic.Count == 0)
                {
                    this._subSectionDic = new Dictionary<int, SubSection>();

                    ArrayList retList;

                    int status = this._subSectionAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (SubSection subSection in retList)
                        {
                            if (subSection.LogicalDeleteCode == 0)
                            {
                                this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._subSectionDic = new Dictionary<int, SubSection>();

                ArrayList retList;

                int status = this._subSectionAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// クラスメンバーコピー処理（従業員マスタワーククラス⇒従業員マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">従業員マスタワーククラス</param>
        /// <returns>従業員マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタワーククラスから従業員マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private EmployeeSet CopyToEmployeeSetFromSecInfoSetWork(Employee employee, EmployeeDtl employeeDtl, string enterpriseCode)
        {

            EmployeeSet employeeSet = new EmployeeSet();

            employeeSet.EmployeeCode = employee.EmployeeCode;
            employeeSet.Name = employee.Name;
            employeeSet.Kana = employee.Kana;
            employeeSet.ShortName = employee.ShortName;
            employeeSet.SexName = employee.SexName;
            employeeSet.Birthday = employee.Birthday;
            employeeSet.CompanyTelNo = employee.CompanyTelNo;
            employeeSet.PortableTelNo = employee.PortableTelNo;
            employeeSet.AuthorityLevel1 = employee.AuthorityLevel1;
            // 職種
            if (this.AuthorityLevel1Table.ContainsKey(employee.AuthorityLevel1.ToString()))
            {
                employeeSet.AuthorityLevelNm1 = this.AuthorityLevel1Table[employee.AuthorityLevel1.ToString()].ToString();
            }
            else
            {
                employeeSet.AuthorityLevelNm1 = this.AuthorityLevel1Table[NULL_JOBTYPE_CODE.ToString()].ToString();
            }
            employeeSet.AuthorityLevel2 = employee.AuthorityLevel2;
            // 雇用形態
            if (this.AuthorityLevel2Table.ContainsKey(employee.AuthorityLevel2.ToString()))
            {
                employeeSet.AuthorityLevelNm2 = this.AuthorityLevel2Table[employee.AuthorityLevel2.ToString()].ToString();
            }
            else
            {
                employeeSet.AuthorityLevelNm2 = this.AuthorityLevel2Table[NULL_EMPLOYMENTFORM_CODE.ToString()].ToString();
            }
            employeeSet.BelongSectionCode = employee.BelongSectionCode;
            string sectionGuideNm = null;
            GetSecInf(out sectionGuideNm, employee.EnterpriseCode, employee.BelongSectionCode);
            employeeSet.SectionGuideNm = sectionGuideNm;
            employeeSet.BelongSubSectionCode = employeeDtl.BelongSubSectionCode;
            employeeSet.SubSectionName = GetSubSectionName(employeeDtl.BelongSubSectionCode, enterpriseCode);
            employeeSet.EnterCompanyDate = employee.EnterCompanyDate;
            employeeSet.RetirementDate = employee.RetirementDate;
            employeeSet.EmployAnalysCode1 = employeeDtl.EmployAnalysCode1;
            employeeSet.EmployAnalysCode2 = employeeDtl.EmployAnalysCode2;
            employeeSet.EmployAnalysCode3 = employeeDtl.EmployAnalysCode3;
            employeeSet.EmployAnalysCode4 = employeeDtl.EmployAnalysCode4;
            employeeSet.EmployAnalysCode5 = employeeDtl.EmployAnalysCode5;
            employeeSet.EmployAnalysCode6 = employeeDtl.EmployAnalysCode6;

            return employeeSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(Employee employee, EmployeePrintWork employeePrintWork)
        {
            int status = 0;

            if (employee.LogicalDeleteCode != employeePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = employee.UpdateDateTime.Year.ToString("0000") +
                                employee.UpdateDateTime.Month.ToString("00") +
                                employee.UpdateDateTime.Day.ToString("00");

            if (employeePrintWork.LogicalDeleteCode == 1 &&
                employeePrintWork.DeleteDateTimeSt != 0 &&
                employeePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < employeePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > employeePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (employeePrintWork.LogicalDeleteCode == 1 &&
                        employeePrintWork.DeleteDateTimeSt != 0 &&
                        employeePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < employeePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (employeePrintWork.LogicalDeleteCode == 1 &&
                  employeePrintWork.DeleteDateTimeSt == 0 &&
                  employeePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > employeePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!employeePrintWork.SectionCodeSt.Trim().Equals(string.Empty) &&
                !employeePrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.BelongSectionCode) < Int32.Parse(employeePrintWork.SectionCodeSt) ||
                   Int32.Parse(employee.BelongSectionCode) > Int32.Parse(employeePrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!employeePrintWork.SectionCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.BelongSectionCode) < Int32.Parse(employeePrintWork.SectionCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!employeePrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.BelongSectionCode) > Int32.Parse(employeePrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }


            if (!employeePrintWork.EmployeeCodeSt.Trim().Equals(string.Empty) &&
                !employeePrintWork.EmployeeCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.EmployeeCode) < Int32.Parse(employeePrintWork.EmployeeCodeSt) ||
                   Int32.Parse(employee.EmployeeCode) > Int32.Parse(employeePrintWork.EmployeeCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!employeePrintWork.EmployeeCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.EmployeeCode) < Int32.Parse(employeePrintWork.EmployeeCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!employeePrintWork.EmployeeCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(employee.EmployeeCode) > Int32.Parse(employeePrintWork.EmployeeCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }
}
