using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PrtManage
    /// <summary>
    ///                      プリンタ管理マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   プリンタ管理マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/3/7</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PrtManage : System.IComparable
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>プリンタ管理No</summary>
        private Int32 _printerMngNo;

        /// <summary>プリンタ名</summary>
        private string _printerName = "";

        /// <summary>プリンタポート（パス）</summary>
        private string _printerPort = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>プリンタ種別</summary>
        private Int32 _printerKind;

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PrinterMngNo
        /// <summary>プリンタ管理Noプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタ管理Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrinterMngNo
        {
            get { return _printerMngNo; }
            set { _printerMngNo = value; }
        }

        /// public propaty name  :  PrinterName
        /// <summary>プリンタ名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタ名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        /// public propaty name  :  PrinterPort
        /// <summary>プリンタポート（パス）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタポート（パス）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrinterPort
        {
            get { return _printerPort; }
            set { _printerPort = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  PrinterKind
        /// <summary>プリンタ種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタ種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrinterKind
        {
            get { return _printerKind; }
            set { _printerKind = value; }
        }


        /// <summary>SVF制御コード（プリンタ種類）</summary>
        public static string[] PrinterKindCodes = 
		{
			"ESCP",		
			"ESCPI",		
			"PR201",		
			"PR201I",		
			"PRINTER",		
			"LIPS3",		
			"LIPS4",		
			"RPDL2",		
			"NPDL2",		
			"ESCPAGE",		
			"PRESCRIBE2",	
			"PCL5",		
			"XEROX",		
			"POSTSCRIPT"
		};

        /// <summary>
        /// プリンタ種類名称の取得
        /// </summary>
        /// <param name="code">SVF制御コード</param>
        /// <returns>プリンタ種類名称</returns>
        public string GetPrinterKindName(string code)
        {
            string name = "";
            switch (code)
            {
                case "ESCP": { name = "ESC/P"; break; }
                case "ESCPI": { name = "ESC/P(イメージ)"; break; }
                case "PR201": { name = "PC-PR201"; break; }
                case "PR201I": { name = "PC-PR201(イメージ)"; break; }
                case "PRINTER": { name = "イメージ印刷"; break; }
                case "LIPS3": { name = "LIPSⅢ"; break; }
                case "LIPS4": { name = "LIPSⅣ"; break; }
                case "RPDL2": { name = "RPDL"; break; }
                case "NPDL2": { name = "NPDL(Level2)"; break; }
                case "ESCPAGE": { name = "ESC/Page"; break; }
                case "PRESCRIBE2": { name = "PRESCRIBE2"; break; }
                case "PCL5": { name = "HP LaserJet 4V"; break; }
                case "XEROX": { name = "XEROX DocuStation DP300"; break; }
                case "POSTSCRIPT": { name = "PostScript(Level2)"; break; }
            }
            return name;
        }

        /// <summary>
        /// プリンタ管理マスタコンストラクタ
        /// </summary>
        /// <returns>PrtManageクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrtManage()
        {
        }

        /// <summary>
        /// プリンタ管理マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="printerMngNo">プリンタ管理No</param>
        /// <param name="printerName">プリンタ名</param>
        /// <param name="printerPort">プリンタポート（パス）</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PrtManageクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrtManage(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 printerMngNo, string printerName, string printerPort, string enterpriseName, string updEmployeeName, Int32 printerKind)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._printerMngNo = printerMngNo;
            this._printerName = printerName;
            this._printerPort = printerPort;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._printerKind = printerKind;

        }

        /// <summary>
        /// プリンタ管理マスタ複製処理
        /// </summary>
        /// <returns>PrtManageクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPrtManageクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrtManage Clone()
        {
            return new PrtManage(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._printerMngNo, this._printerName, this._printerPort, this._enterpriseName, this._updEmployeeName, this._printerKind);
        }

        /// <summary>
        /// プリンタ管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPrtManageクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PrtManage target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PrinterMngNo == target.PrinterMngNo)
                 && (this.PrinterName == target.PrinterName)
                 && (this.PrinterPort == target.PrinterPort)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.PrinterKind == target.PrinterKind));
        }

        /// <summary>
        /// プリンタ管理マスタ比較処理
        /// </summary>
        /// <param name="prtManage1">
        ///                    比較するPrtManageクラスのインスタンス
        /// </param>
        /// <param name="prtManage2">比較するPrtManageクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PrtManage prtManage1, PrtManage prtManage2)
        {
            return ((prtManage1.CreateDateTime == prtManage2.CreateDateTime)
                 && (prtManage1.UpdateDateTime == prtManage2.UpdateDateTime)
                 && (prtManage1.EnterpriseCode == prtManage2.EnterpriseCode)
                 && (prtManage1.FileHeaderGuid == prtManage2.FileHeaderGuid)
                 && (prtManage1.UpdEmployeeCode == prtManage2.UpdEmployeeCode)
                 && (prtManage1.UpdAssemblyId1 == prtManage2.UpdAssemblyId1)
                 && (prtManage1.UpdAssemblyId2 == prtManage2.UpdAssemblyId2)
                 && (prtManage1.LogicalDeleteCode == prtManage2.LogicalDeleteCode)
                 && (prtManage1.PrinterMngNo == prtManage2.PrinterMngNo)
                 && (prtManage1.PrinterName == prtManage2.PrinterName)
                 && (prtManage1.PrinterPort == prtManage2.PrinterPort)
                 && (prtManage1.EnterpriseName == prtManage2.EnterpriseName)
                 && (prtManage1.UpdEmployeeName == prtManage2.UpdEmployeeName)
                 && (prtManage1.PrinterKind == prtManage2.PrinterKind));
        }
        /// <summary>
        /// プリンタ管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPrtManageクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PrtManage target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PrinterMngNo != target.PrinterMngNo) resList.Add("PrinterMngNo");
            if (this.PrinterName != target.PrinterName) resList.Add("PrinterName");
            if (this.PrinterPort != target.PrinterPort) resList.Add("PrinterPort");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.PrinterKind != target.PrinterKind) resList.Add("PrinterKind");

            return resList;
        }

        /// <summary>
        /// プリンタ管理マスタ比較処理
        /// </summary>
        /// <param name="prtManage1">比較するPrtManageクラスのインスタンス</param>
        /// <param name="prtManage2">比較するPrtManageクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// 
        /// <remarks>
        /// <br>Note　　　　　　 :   PrtManageクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PrtManage prtManage1, PrtManage prtManage2)
        {
            ArrayList resList = new ArrayList();
            if (prtManage1.CreateDateTime != prtManage2.CreateDateTime) resList.Add("CreateDateTime");
            if (prtManage1.UpdateDateTime != prtManage2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (prtManage1.EnterpriseCode != prtManage2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (prtManage1.FileHeaderGuid != prtManage2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (prtManage1.UpdEmployeeCode != prtManage2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (prtManage1.UpdAssemblyId1 != prtManage2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (prtManage1.UpdAssemblyId2 != prtManage2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (prtManage1.LogicalDeleteCode != prtManage2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (prtManage1.PrinterMngNo != prtManage2.PrinterMngNo) resList.Add("PrinterMngNo");
            if (prtManage1.PrinterName != prtManage2.PrinterName) resList.Add("PrinterName");
            if (prtManage1.PrinterPort != prtManage2.PrinterPort) resList.Add("PrinterPort");
            if (prtManage1.EnterpriseName != prtManage2.EnterpriseName) resList.Add("EnterpriseName");
            if (prtManage1.UpdEmployeeName != prtManage2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (prtManage1.PrinterKind != prtManage2.PrinterKind) resList.Add("PrinterKind");

            return resList;
        }

        /// <summary>
        /// プリンタ管理クラス比較処理（IComparableの実装）
        /// </summary>
        /// <param name="x">プリンタ管理クラス</param>
        /// <returns>一致する場合は０</returns>
        public int CompareTo(object x)
        {
            PrtManage prtManageX = (PrtManage)x;

            //			int ret = _enterpriseCode.CompareTo(prtManageX.EnterpriseCode);
            //			if (ret == 0) ret = this._printerMngNo - prtManageX.PrinterMngNo;
            int ret = this._printerMngNo - prtManageX.PrinterMngNo;
            return ret;
        }
    }
}
