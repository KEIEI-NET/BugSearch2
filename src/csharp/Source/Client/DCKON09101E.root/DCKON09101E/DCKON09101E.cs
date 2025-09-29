using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockProcMoney
    /// <summary>
    ///						 仕入金額処理区分設定マスタ
    /// </summary>
    /// <remarks>
	/// <br>note             :   仕入金額処理区分設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成 / 30167 上野 弘貴</br>
    /// <br>Date             :   2007.08.20</br>
    /// <br>Genarated Date   :   2006.08.20  (CSharp File Generated Date)</br>
    /// </remarks>
    public class StockProcMoney
    {
        /*----------------------------------------------------------------------------------*/
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

		/// <summary>端数処理対象金額区分</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Int32 _fracProcMoneyDiv;

		/// <summary>端数処理コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Int32 _fractionProcCode;

		/// <summary>上限金額</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Double _upperLimitPrice;

		/// <summary>端数処理単位</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Double _fractionProcUnit;

		/// <summary>端数処理区分</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Int32 _fractionProcCd;

		/// <summary>端数処理区分名</summary>
		/// <remarks>共通ファイルヘッダ(ガイド用)</remarks>
		private string _fractionProcCdNm;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /*----------------------------------------------------------------------------------*/
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

		/// public propaty name  :  FracProcMoneyDiv
		/// <summary>端数処理対象金額区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理対象金額区分プロパティ</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public Int32 FracProcMoneyDiv
		{
			get { return _fracProcMoneyDiv; }
			set { _fracProcMoneyDiv = value; }
		}

		/// public propaty name  :  FractionProcCode
		/// <summary>端数処理コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理コードプロパティ</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public Int32 FractionProcCode
		{
			get { return _fractionProcCode; }
			set { _fractionProcCode = value; }
		}

		/// public propaty name  :  UpperLimitPrice
		/// <summary>上限金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上限金額プロパティ</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public Double UpperLimitPrice
		{
			get { return _upperLimitPrice; }
			set { _upperLimitPrice = value; }
		}

		/// public propaty name  :  FractionProcUnit
		/// <summary>端数処理単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位プロパティ</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public Double FractionProcUnit
		{
			get { return _fractionProcUnit; }
			set { _fractionProcUnit = value; }
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get { return _fractionProcCd; }
			set { _fractionProcCd = value; }
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分名プロパティ(ガイド用)</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分名プロパティ(ガイド用)</br>
		/// <br>Programer        :   30167 上野 弘貴</br>
		/// </remarks>
		public string FractionProcCdNm
		{
			get { return _fractionProcCdNm; }
			set { _fractionProcCdNm = value; }
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタコンストラクタ
        /// </summary>
        /// <returns>StockProcMoneyクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockProcMoney()
        {
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
		/// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
		/// <param name="fractionProcCode">端数処理コード</param>
		/// <param name="upperLimitPrice">上限金額</param>
		/// <param name="fractionProcUnit">端数処理単位</param>
		/// <param name="fractionProcCd">端数処理区分</param>
		/// <param name="fractionProcCdNm">端数処理区分名(ガイド用)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>StockProcMoneyクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成 / 30167 上野 弘貴</br>
        /// </remarks>
        public StockProcMoney(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice, Double fractionProcUnit, Int32 fractionProcCd, string fractionProcCdNm, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
			this._fracProcMoneyDiv = fracProcMoneyDiv;
			this._fractionProcCode = fractionProcCode;
			this._upperLimitPrice = upperLimitPrice;
			this._fractionProcUnit = fractionProcUnit;
			this._fractionProcCd = fractionProcCd;
			this._fractionProcCdNm = fractionProcCdNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタ複製処理
        /// </summary>
        /// <returns>StockProcMoneyクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockProcMoneyクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成 / 30167 上野 弘貴</br>
        /// </remarks>
        public StockProcMoney Clone()
        {
            return new StockProcMoney(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._fracProcMoneyDiv, this._fractionProcCode, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._fractionProcCdNm, this._enterpriseName, this._updEmployeeName);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockProcMoneyクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成 / 30167 上野 弘貴</br>
        /// </remarks>
        public bool Equals(StockProcMoney target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.FracProcMoneyDiv == target.FracProcMoneyDiv)
				 && (this.FractionProcCode == target.FractionProcCode)
				 && (this.UpperLimitPrice == target.UpperLimitPrice)
				 && (this.FractionProcUnit == target.FractionProcUnit)
				 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタ比較処理
        /// </summary>
        /// <param name="StockProcMoney1">
        ///                    比較するStockProcMoneyクラスのインスタンス
        /// </param>
        /// <param name="StockProcMoney2">比較するStockProcMoneyクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成 / 30167 上野 弘貴</br>
        /// </remarks>
        public static bool Equals(StockProcMoney StockProcMoney1, StockProcMoney StockProcMoney2)
        {
            return ((StockProcMoney1.CreateDateTime == StockProcMoney2.CreateDateTime)
                 && (StockProcMoney1.UpdateDateTime == StockProcMoney2.UpdateDateTime)
                 && (StockProcMoney1.EnterpriseCode == StockProcMoney2.EnterpriseCode)
                 && (StockProcMoney1.FileHeaderGuid == StockProcMoney2.FileHeaderGuid)
                 && (StockProcMoney1.UpdEmployeeCode == StockProcMoney2.UpdEmployeeCode)
                 && (StockProcMoney1.UpdAssemblyId1 == StockProcMoney2.UpdAssemblyId1)
                 && (StockProcMoney1.UpdAssemblyId2 == StockProcMoney2.UpdAssemblyId2)
				 && (StockProcMoney1.FracProcMoneyDiv == StockProcMoney2.FracProcMoneyDiv)
				 && (StockProcMoney1.FractionProcCode == StockProcMoney2.FractionProcCode)
				 && (StockProcMoney1.UpperLimitPrice == StockProcMoney2.UpperLimitPrice)
				 && (StockProcMoney1.FractionProcUnit == StockProcMoney2.FractionProcUnit)
				 && (StockProcMoney1.FractionProcCd == StockProcMoney2.FractionProcCd)
                 && (StockProcMoney1.LogicalDeleteCode == StockProcMoney2.LogicalDeleteCode)
                 && (StockProcMoney1.EnterpriseName == StockProcMoney2.EnterpriseName)
                 && (StockProcMoney1.UpdEmployeeName == StockProcMoney2.UpdEmployeeName));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockProcMoneyクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成 / 30167 上野弘貴</br>
        /// </remarks>
        public ArrayList Compare(StockProcMoney target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (this.FracProcMoneyDiv != target.FracProcMoneyDiv) resList.Add("FracProcMoneyDiv");
			if (this.FractionProcCode != target.FractionProcCode) resList.Add("FractionProcCode");
			if (this.UpperLimitPrice != target.UpperLimitPrice) resList.Add("UpperLimitPrice");
			if (this.FractionProcUnit != target.FractionProcUnit) resList.Add("FractionProcUnit");
			if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 仕入金額処理区分設定マスタ比較処理
        /// </summary>
        /// <param name="StockProcMoney1">比較するStockProcMoneyクラスのインスタンス</param>
        /// <param name="StockProcMoney2">比較するStockProcMoneyクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockProcMoneyクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成 / 30167 上野弘貴</br>
        /// </remarks>
        public static ArrayList Compare(StockProcMoney StockProcMoney1, StockProcMoney StockProcMoney2)
        {
            ArrayList resList = new ArrayList();
            if (StockProcMoney1.CreateDateTime != StockProcMoney2.CreateDateTime) resList.Add("CreateDateTime");
            if (StockProcMoney1.UpdateDateTime != StockProcMoney2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (StockProcMoney1.EnterpriseCode != StockProcMoney2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (StockProcMoney1.FileHeaderGuid != StockProcMoney2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (StockProcMoney1.UpdEmployeeCode != StockProcMoney2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (StockProcMoney1.UpdAssemblyId1 != StockProcMoney2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (StockProcMoney1.UpdAssemblyId2 != StockProcMoney2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (StockProcMoney1.FracProcMoneyDiv != StockProcMoney2.FracProcMoneyDiv) resList.Add("FracProcMoneyDiv");
			if (StockProcMoney1.FractionProcCode != StockProcMoney2.FractionProcCode) resList.Add("FractionProcCode");
			if (StockProcMoney1.UpperLimitPrice != StockProcMoney2.UpperLimitPrice) resList.Add("UpperLimitPrice");
			if (StockProcMoney1.FractionProcUnit != StockProcMoney2.FractionProcUnit) resList.Add("FractionProcUnit");
			if (StockProcMoney1.FractionProcCd != StockProcMoney2.FractionProcCd) resList.Add("FractionProcCd");
            if (StockProcMoney1.LogicalDeleteCode != StockProcMoney2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (StockProcMoney1.EnterpriseName != StockProcMoney2.EnterpriseName) resList.Add("EnterpriseName");
            if (StockProcMoney1.UpdEmployeeName != StockProcMoney2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

		/// <summary>
		/// 端数処理対象金額区分コードリスト取得処理
		/// </summary>
		/// <returns>端数処理対象金額区分コードリスト</returns>
		/// <remarks>
		/// <br>Note		: 端数処理対象金額区分にて使用するコードのリストを取得します。</br>
		/// <br>			: インデックスはGetFracProcMoneyNmList()にて取得出来る名称と一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFracProcMoneyDivCdList()
		{
			ArrayList retList = new ArrayList();
			retList.Add(0);
			retList.Add(1);
			retList.Add(2);
			return retList;
		}

		/// <summary>
		/// 端数処理対象金額区分名称リスト取得処理
		/// </summary>
		/// <returns>端数処理対象金額区分名称リスト</returns>
		/// <remarks>
		/// <br>Note		: 端数処理対象金額区分にて使用する名称のリストを取得します。</br>
		/// <br>			: インデックスはGetFracProcMoneyCdList()にて取得出来るコードと一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFracProcMoneyDivNmList()
		{
			ArrayList retList = new ArrayList();
			retList.Add("仕入金額");
			retList.Add("消費税");
			retList.Add("仕入単価");
			return retList;
		}

		/// <summary>
		/// 端数処理対象金額区分名称取得処理
		/// </summary>
		/// <returns>端数処理対象金額区分名称</returns>
		/// <remarks>
		/// <br>Note		: 端数処理対象金額区分にて使用する名称を取得します。</br>
		/// <br>			: インデックスはGetFracProcMoneyCdList()にて取得出来るコードと一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.22</br>
		/// </remarks>
		public static string GetFracProcMoneyDivNm(Int32 getFracProcMoneyDivCd)
		{
			string retFracProcMoneyDivNm = "";
			ArrayList wkListCd = GetFracProcMoneyDivCdList();
			ArrayList wkListNm = GetFracProcMoneyDivNmList();

			for (int ix = 0; ix != wkListCd.Count; ix++)
			{
				if (getFracProcMoneyDivCd == (Int32)wkListCd[ix])
				{
					retFracProcMoneyDivNm = wkListNm[ix].ToString();
					break;
				}
			}
			return retFracProcMoneyDivNm;
		}

		/// <summary>
		/// 端数処理区分コードリスト取得処理
		/// </summary>
		/// <returns>端数処理区分コードリスト</returns>
		/// <remarks>
		/// <br>Note		: 端数処理区分にて使用するコードのリストを取得します。</br>
		/// <br>			: インデックスはGetFractionProcCdNmList()にて取得出来る名称と一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFractionProcCdCdList()
		{
			ArrayList retList = new ArrayList();
			retList.Add(1);
			retList.Add(2);
			retList.Add(3);
			return retList;
		}

		/// <summary>
		/// 端数処理区分名称リスト取得処理
		/// </summary>
		/// <returns>端数処理区分名称リスト</returns>
		/// <remarks>
		/// <br>Note		: 端数処理区分にて使用する名称のリストを取得します。</br>
		/// <br>			: インデックスはGetFractionProcCdCdList()にて取得出来るコードと一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
		public static ArrayList GetFractionProcCdNmList()
		{
			ArrayList retList = new ArrayList();
			retList.Add("切捨て");
			retList.Add("四捨五入");
			retList.Add("切上げ");
			return retList;
		}

		/// <summary>
		/// 端数処理区分名称取得処理
		/// </summary>
		/// <returns>端数処理区分名称名称</returns>
		/// <remarks>
		/// <br>Note		: 端数処理区分にて使用する名称を取得します。</br>
		/// <br>			: インデックスはGetFractionProcCdCdList()にて取得出来るコードと一致します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.22</br>
		/// </remarks>
		public static string GetFractionProcCdNm(Int32 getFractionProcCd)
		{
			string retFractionProcCd = "";
			ArrayList wkListCd = GetFractionProcCdCdList();
			ArrayList wkListNm = GetFractionProcCdNmList();

			for (int ix = 0; ix != wkListCd.Count; ix++)
			{
				if (getFractionProcCd == (Int32)wkListCd[ix])
				{
					retFractionProcCd = wkListNm[ix].ToString();
					break;
				}
			}
			return retFractionProcCd;
		}
    
        /// <summary>
        /// 端数処理区分コード取得処理
        /// </summary>
        /// <returns>端数処理区分コード</returns>
        /// <remarks>
        /// <br>Note		: 端数処理区分にて使用するコードを取得します。</br>
        /// <br>			: インデックスはGetFractionProcCdCdList()にて取得出来るコードと一致します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.08.22</br>
        /// </remarks>
        public static int GetFractionProcCd(string getFractionProcCdNm)
        {
            int retFractionProcCd = 0;
            ArrayList wkListCd = GetFractionProcCdCdList();
            ArrayList wkListNm = GetFractionProcCdNmList();

            for (int ix = 0; ix != wkListNm.Count; ix++)
            {
                if (string.Equals(wkListNm[ix].ToString(), getFractionProcCdNm) == true)
                {
                    retFractionProcCd = int.Parse(wkListCd[ix].ToString());
                    break;
                }
            }
            return retFractionProcCd;
        }
    }
}
