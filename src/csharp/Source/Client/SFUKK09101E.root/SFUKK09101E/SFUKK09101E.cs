using System;

using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BillAllSt
	/// <summary>
	///                      請求全体設定クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求全体設定クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/07/13</br>
	/// <br>Genarated Date   :   2005/07/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006.06.01 23001 秋山　亮介</br>
    /// <br>                                1.前受金算定区分を追加</br>
    /// <br>Update Note      :   2006.12.13 22022 段上 知子</br>
    /// <br>        					    1.SF版を流用し携帯版を作成</br>
    /// <br>        					    2.未使用項目を固定値へ変更(マイナス諸費用残高調整区分・前受金算定区分を削除)</br>
    /// <br>Programmer       :   30415 柴田 倫幸</br>
    /// <br>Date             :   2008/06/16</br>	
    /// </remarks>
	public class BillAllSt
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

        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        /// <remarks>拠点コード（番号採番用）０は全社共通</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/16 --------------------------------<<<<< 

        /* --- DEL 2008/06/16 -------------------------------->>>>>
		/// <summary>請求全体設定管理コード</summary>
		/// <remarks>常にゼロ固定</remarks>
		private Int32 _billAllStCd;

		/// <summary>マイナス諸費用残高調整区分</summary>
		/// <remarks>0:調整しない,1:諸費用残がﾏｲﾅｽ時に諸費用残を0にする</remarks>
		private Int32 _minusVarCstBlAdjstCd;
           --- DEL 2008/06/16 --------------------------------<<<<< */
        
        /// <summary>引当処理区分</summary>
		/// <remarks>0:両方,1:必須,2:不可</remarks>
		private Int32 _allowanceProcCd;

		/// <summary>入金伝票修正区分</summary>
		/// <remarks>0:修正可,1:修正不可</remarks>
		private Int32 _depositSlipMntCd;

        /* --- DEL 2008/06/16 -------------------------------->>>>>
		/// <summary>前受金算定区分</summary>
		/// <remarks>0:預り金は全て前受金とする,1:自動的に今回入金と前受金に振り分ける</remarks>
		private Int32 _bfRmonCalcDivCd;
           --- DEL 2008/06/16 --------------------------------<<<<< */

        /// <summary>回収予定区分</summary>
        /// <remarks>0:区分 1:日付</remarks>
        private Int32 _collectPlnDiv;

        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// <summary>得意先締日１</summary>
        private Int32 _customerTotalDay1;

        /// <summary>得意先締日２</summary>
        private Int32 _customerTotalDay2;

        /// <summary>得意先締日３</summary>
        private Int32 _customerTotalDay3;

        /// <summary>得意先締日４</summary>
        private Int32 _customerTotalDay4;

        /// <summary>得意先締日５</summary>
        private Int32 _customerTotalDay5;

        /// <summary>得意先締日６</summary>
        private Int32 _customerTotalDay6;

        /// <summary>得意先締日７</summary>
        private Int32 _customerTotalDay7;

        /// <summary>得意先締日８</summary>
        private Int32 _customerTotalDay8;

        /// <summary>得意先締日９</summary>
        private Int32 _customerTotalDay9;

        /// <summary>得意先締日１０</summary>
        private Int32 _customerTotalDay10;

        /// <summary>得意先締日１１</summary>
        private Int32 _customerTotalDay11;

        /// <summary>得意先締日１２</summary>
        private Int32 _customerTotalDay12;

        /// <summary>仕入先締日１</summary>
        private Int32 _supplierTotalDay1;

        /// <summary>仕入先締日２</summary>
        private Int32 _supplierTotalDay2;

        /// <summary>仕入先締日３</summary>
        private Int32 _supplierTotalDay3;

        /// <summary>仕入先締日４</summary>
        private Int32 _supplierTotalDay4;

        /// <summary>仕入先締日５</summary>
        private Int32 _supplierTotalDay5;

        /// <summary>仕入先締日６</summary>
        private Int32 _supplierTotalDay6;

        /// <summary>仕入先締日７</summary>
        private Int32 _supplierTotalDay7;

        /// <summary>仕入先締日８</summary>
        private Int32 _supplierTotalDay8;

        /// <summary>仕入先締日９</summary>
        private Int32 _supplierTotalDay9;

        /// <summary>仕入先締日１０</summary>
        private Int32 _supplierTotalDay10;

        /// <summary>仕入先締日１１</summary>
        private Int32 _supplierTotalDay11;

        /// <summary>仕入先締日１２</summary>
        private Int32 _supplierTotalDay12;
        // --- ADD 2008/06/16 --------------------------------<<<<< 

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";


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
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
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
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
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
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
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
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点コード（番号採番用）０は全社共通</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/16 --------------------------------<<<<< 

        /* --- DEL 2008/06/16 -------------------------------->>>>>
		/// public propaty name  :  BillAllStCd
		/// <summary>請求全体設定管理コードプロパティ</summary>
		/// <value>常にゼロ固定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求全体設定管理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BillAllStCd
		{
			get{return _billAllStCd;}
			set{_billAllStCd = value;}
		}

		/// public propaty name  :  MinusVarCstBlAdjstCd
		/// <summary>マイナス諸費用残高調整区分プロパティ</summary>
		/// <value>0:調整しない,1:諸費用残がﾏｲﾅｽ時に諸費用残を0にする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   マイナス諸費用残高調整区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MinusVarCstBlAdjstCd
		{
			get{return _minusVarCstBlAdjstCd;}
			set{_minusVarCstBlAdjstCd = value;}
		}
           --- DEL 2008/06/16 --------------------------------<<<<< */
        
        /// public propaty name  :  AllowanceProcCd
		/// <summary>引当処理区分プロパティ</summary>
		/// <value>0:両方,1:必須,2:不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AllowanceProcCd
		{
			get{return _allowanceProcCd;}
			set{_allowanceProcCd = value;}
		}

		/// public propaty name  :  DepositSlipMntCd
		/// <summary>入金伝票修正区分プロパティ</summary>
		/// <value>0:修正可,1:修正不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金伝票修正区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepositSlipMntCd
		{
			get{return _depositSlipMntCd;}
			set{_depositSlipMntCd = value;}
		}

        /* --- DEL 2008/06/16 -------------------------------->>>>>
		/// public propaty name  :  BfRmonCalcDivCd
		/// <summary>前受金算定区分プロパティ</summary>
		/// <value>0:預り金は全て前受金とする,1:自動的に今回入金と前受金に振り分ける</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前受金算定区分プロパティ</br>
		/// <br>Programer        :   23001 秋山　亮介</br>
		/// </remarks>
		public Int32 BfRmonCalcDivCd
		{
			get{return _bfRmonCalcDivCd;}
			set{_bfRmonCalcDivCd = value;}
		}
           --- DEL 2008/06/16 --------------------------------<<<<< */

        /// public propaty name  :  CollectPlnDiv
        /// <summary>回収予定区分プロパティ</summary>
        /// <value>0:区分 1:日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収予定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectPlnDiv
        {
            get { return _collectPlnDiv; }
            set { _collectPlnDiv = value; }
        }

        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// public propaty name  :  CustomerTotalDay1
        /// <summary>得意先締日１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay1
        {
            get { return _customerTotalDay1; }
            set { _customerTotalDay1 = value; }
        }

        /// public propaty name  :  CustomerTotalDay2
        /// <summary>得意先締日２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日２プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay2
        {
            get { return _customerTotalDay2; }
            set { _customerTotalDay2 = value; }
        }

        /// public propaty name  :  CustomerTotalDay3
        /// <summary>得意先締日３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日３プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay3
        {
            get { return _customerTotalDay3; }
            set { _customerTotalDay3 = value; }
        }

        /// public propaty name  :  CustomerTotalDay4
        /// <summary>得意先締日４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日４プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay4
        {
            get { return _customerTotalDay4; }
            set { _customerTotalDay4 = value; }
        }

        /// public propaty name  :  CustomerTotalDay5
        /// <summary>得意先締日５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日５プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay5
        {
            get { return _customerTotalDay5; }
            set { _customerTotalDay5 = value; }
        }

        /// public propaty name  :  CustomerTotalDay6
        /// <summary>得意先締日６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日６プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay6
        {
            get { return _customerTotalDay6; }
            set { _customerTotalDay6 = value; }
        }

        /// public propaty name  :  CustomerTotalDay7
        /// <summary>得意先締日７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日７プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay7
        {
            get { return _customerTotalDay7; }
            set { _customerTotalDay7 = value; }
        }

        /// public propaty name  :  CustomerTotalDay8
        /// <summary>得意先締日８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日８プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay8
        {
            get { return _customerTotalDay8; }
            set { _customerTotalDay8 = value; }
        }

        /// public propaty name  :  CustomerTotalDay9
        /// <summary>得意先締日９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日９プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay9
        {
            get { return _customerTotalDay9; }
            set { _customerTotalDay9 = value; }
        }

        /// public propaty name  :  CustomerTotalDay10
        /// <summary>得意先締日１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１０プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay10
        {
            get { return _customerTotalDay10; }
            set { _customerTotalDay10 = value; }
        }

        /// public propaty name  :  CustomerTotalDay11
        /// <summary>得意先締日１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１１プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay11
        {
            get { return _customerTotalDay11; }
            set { _customerTotalDay11 = value; }
        }

        /// public propaty name  :  CustomerTotalDay12
        /// <summary>得意先締日１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１２プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTotalDay12
        {
            get { return _customerTotalDay12; }
            set { _customerTotalDay12 = value; }
        }

        /// public propaty name  :  SupplierTotalDay1
        /// <summary>仕入先締日１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay1
        {
            get { return _supplierTotalDay1; }
            set { _supplierTotalDay1 = value; }
        }

        /// public propaty name  :  SupplierTotalDay2
        /// <summary>仕入先締日２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日２プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay2
        {
            get { return _supplierTotalDay2; }
            set { _supplierTotalDay2 = value; }
        }

        /// public propaty name  :  SupplierTotalDay3
        /// <summary>仕入先締日３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日３プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay3
        {
            get { return _supplierTotalDay3; }
            set { _supplierTotalDay3 = value; }
        }

        /// public propaty name  :  SupplierTotalDay4
        /// <summary>仕入先締日４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日４プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay4
        {
            get { return _supplierTotalDay4; }
            set { _supplierTotalDay4 = value; }
        }

        /// public propaty name  :  SupplierTotalDay5
        /// <summary>仕入先締日５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日５プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay5
        {
            get { return _supplierTotalDay5; }
            set { _supplierTotalDay5 = value; }
        }

        /// public propaty name  :  SupplierTotalDay6
        /// <summary>仕入先締日６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日６プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay6
        {
            get { return _supplierTotalDay6; }
            set { _supplierTotalDay6 = value; }
        }

        /// public propaty name  :  SupplierTotalDay7
        /// <summary>仕入先締日７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日７プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay7
        {
            get { return _supplierTotalDay7; }
            set { _supplierTotalDay7 = value; }
        }

        /// public propaty name  :  SupplierTotalDay8
        /// <summary>仕入先締日８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日８プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay8
        {
            get { return _supplierTotalDay8; }
            set { _supplierTotalDay8 = value; }
        }

        /// public propaty name  :  SupplierTotalDay9
        /// <summary>仕入先締日９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日９プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay9
        {
            get { return _supplierTotalDay9; }
            set { _supplierTotalDay9 = value; }
        }

        /// public propaty name  :  SupplierTotalDay10
        /// <summary>仕入先締日１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１０プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay10
        {
            get { return _supplierTotalDay10; }
            set { _supplierTotalDay10 = value; }
        }

        /// public propaty name  :  SupplierTotalDay11
        /// <summary>仕入先締日１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１１プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay11
        {
            get { return _supplierTotalDay11; }
            set { _supplierTotalDay11 = value; }
        }

        /// public propaty name  :  SupplierTotalDay12
        /// <summary>仕入先締日１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１２プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierTotalDay12
        {
            get { return _supplierTotalDay12; }
            set { _supplierTotalDay12 = value; }
        }
        // --- ADD 2008/06/16 --------------------------------<<<<< 

        /// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


		/// <summary>
		/// 請求全体設定クラスコンストラクタ
		/// </summary>
		/// <returns>BillAllStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BillAllSt()
		{
		}

		/// <summary>
		/// 請求全体設定クラスコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// <param name="sectionCode">拠点コード(（番号採番用）０は全社共通)</param>
        // --- ADD 2008/06/16 --------------------------------<<<<< 
        /* --- DEL 2008/06/16 -------------------------------->>>>>
        /// <param name="billAllStCd">請求全体設定管理コード(常にゼロ固定)</param>
        /// <param name="minusVarCstBlAdjstCd">マイナス諸費用残高調整区分(0:調整しない,1:諸費用残がﾏｲﾅｽ時に諸費用残を0にする)</param>
           --- DEL 2008/06/16 --------------------------------<<<<< */
        /// <param name="allowanceProcCd">引当処理区分(0:両方,1:必須,2:不可)</param>
		/// <param name="depositSlipMntCd">入金伝票修正区分(0:修正可,1:修正不可)</param>
        /* --- DEL 2008/06/16 -------------------------------->>>>>
        /// <param name="bfRmonCalcDivCd">前受金算定区分</param>
           --- DEL 2008/06/16 --------------------------------<<<<< */
        /// <param name="collectPlnDiv">回収予定区分(0:区分,1:日付)</param>
        // --- ADD 2008/06/16 -------------------------------->>>>>
        /// <param name="customerTotalDay1">得意先締日１</param>
        /// <param name="customerTotalDay2">得意先締日２</param>
        /// <param name="customerTotalDay3">得意先締日３</param>
        /// <param name="customerTotalDay4">得意先締日４</param>
        /// <param name="customerTotalDay5">得意先締日５</param>
        /// <param name="customerTotalDay6">得意先締日６</param>
        /// <param name="customerTotalDay7">得意先締日７</param>
        /// <param name="customerTotalDay8">得意先締日８</param>
        /// <param name="customerTotalDay9">得意先締日９</param>
        /// <param name="customerTotalDay10">得意先締日１０</param>
        /// <param name="customerTotalDay11">得意先締日１１</param>
        /// <param name="customerTotalDay12">得意先締日１２</param>
        /// <param name="customerTotalDay1">得意先締日１</param>
        /// <param name="customerTotalDay2">得意先締日２</param>
        /// <param name="customerTotalDay3">得意先締日３</param>
        /// <param name="customerTotalDay4">得意先締日４</param>
        /// <param name="customerTotalDay5">得意先締日５</param>
        /// <param name="customerTotalDay6">得意先締日６</param>
        /// <param name="customerTotalDay7">得意先締日７</param>
        /// <param name="customerTotalDay8">得意先締日８</param>
        /// <param name="customerTotalDay9">得意先締日９</param>
        /// <param name="customerTotalDay10">得意先締日１０</param>
        /// <param name="customerTotalDay11">得意先締日１１</param>
        /// <param name="customerTotalDay12">得意先締日１２</param>
        // --- ADD 2008/06/16 --------------------------------<<<<< 
        /// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>BillAllStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public BillAllSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 billAllStCd,Int32 minusVarCstBlAdjstCd,Int32 allowanceProcCd,Int32 depositSlipMntCd,Int32 bfRmonCalcDivCd,string updEmployeeName,string enterpriseName)  // DEL 2008/06/16
        public BillAllSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 allowanceProcCd, Int32 depositSlipMntCd, Int32 collectPlnDiv, string updEmployeeName, string enterpriseName, Int32 customerTotalDay1, Int32 customerTotalDay2, Int32 customerTotalDay3, Int32 customerTotalDay4, Int32 customerTotalDay5, Int32 customerTotalDay6, Int32 customerTotalDay7, Int32 customerTotalDay8, Int32 customerTotalDay9, Int32 customerTotalDay10, Int32 customerTotalDay11, Int32 customerTotalDay12, Int32 supplierTotalDay1,Int32 supplierTotalDay2,Int32 supplierTotalDay3,Int32 supplierTotalDay4,Int32 supplierTotalDay5,Int32 supplierTotalDay6,Int32 supplierTotalDay7,Int32 supplierTotalDay8,Int32 supplierTotalDay9,Int32 supplierTotalDay10,Int32 supplierTotalDay11,Int32 supplierTotalDay12)  // ADD 2008/06/16
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;  // ADD 2008/06/16

            /* --- DEL 2008/06/16 -------------------------------->>>>>
			this._billAllStCd = billAllStCd;
			this._minusVarCstBlAdjstCd = minusVarCstBlAdjstCd;
               --- DEL 2008/06/16 --------------------------------<<<<< */

            this._allowanceProcCd = allowanceProcCd;
			this._depositSlipMntCd = depositSlipMntCd;
			this._updEmployeeName = updEmployeeName;
			this._enterpriseName = enterpriseName;
            this._collectPlnDiv = collectPlnDiv;

			//this._bfRmonCalcDivCd = bfRmonCalcDivCd;  //DEL 2008/06/16

            // --- ADD 2008/06/16 -------------------------------->>>>>
            this._customerTotalDay1 = customerTotalDay1;
            this._customerTotalDay2 = customerTotalDay2;
            this._customerTotalDay3 = customerTotalDay3;
            this._customerTotalDay4 = customerTotalDay4;
            this._customerTotalDay5 = customerTotalDay5;
            this._customerTotalDay6 = customerTotalDay6;
            this._customerTotalDay7 = customerTotalDay7;
            this._customerTotalDay8 = customerTotalDay8;
            this._customerTotalDay9 = customerTotalDay9;
            this._customerTotalDay10 = customerTotalDay10;
            this._customerTotalDay11 = customerTotalDay11;
            this._customerTotalDay12 = customerTotalDay12;

            this._supplierTotalDay1 = supplierTotalDay1;
            this._supplierTotalDay2 = supplierTotalDay2;
            this._supplierTotalDay3 = supplierTotalDay3;
            this._supplierTotalDay4 = supplierTotalDay4;
            this._supplierTotalDay5 = supplierTotalDay5;
            this._supplierTotalDay6 = supplierTotalDay6;
            this._supplierTotalDay7 = supplierTotalDay7;
            this._supplierTotalDay8 = supplierTotalDay8;
            this._supplierTotalDay9 = supplierTotalDay9;
            this._supplierTotalDay10 = supplierTotalDay10;
            this._supplierTotalDay11 = supplierTotalDay11;
            this._supplierTotalDay12 = supplierTotalDay12;
            // --- ADD 2008/06/16 --------------------------------<<<<< 
		}

		/// <summary>
		/// 請求全体設定クラス複製処理
		/// </summary>
		/// <returns>BillAllStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいBillAllStクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BillAllSt Clone()
		{
			//return new BillAllSt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._billAllStCd,this._minusVarCstBlAdjstCd,this._allowanceProcCd,this._depositSlipMntCd,this._bfRmonCalcDivCd,this._updEmployeeName,this._enterpriseName);  // DEL 2008/06/16
            return new BillAllSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._allowanceProcCd, this._depositSlipMntCd, this._collectPlnDiv, this._updEmployeeName, this._enterpriseName, this._customerTotalDay1, this._customerTotalDay2, this._customerTotalDay3, this._customerTotalDay4, this._customerTotalDay5, this._customerTotalDay6, this._customerTotalDay7, this._customerTotalDay8, this._customerTotalDay9, this._customerTotalDay10, this._customerTotalDay11, this._customerTotalDay12, this._supplierTotalDay1,this._supplierTotalDay2,this._supplierTotalDay3,this._supplierTotalDay4,this._supplierTotalDay5,this._supplierTotalDay6,this._supplierTotalDay7,this._supplierTotalDay8,this._supplierTotalDay9,this._supplierTotalDay10,this._supplierTotalDay11,this._supplierTotalDay12);  // ADD 2008/06/16
        }

		/// <summary>
		/// 請求全体設定クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBillAllStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(BillAllSt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				&& (this.UpdateDateTime == target.UpdateDateTime)
				&& (this.EnterpriseCode == target.EnterpriseCode)
				&& (this.FileHeaderGuid == target.FileHeaderGuid)
				&& (this.UpdEmployeeCode == target.UpdEmployeeCode)
				&& (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				&& (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				&& (this.LogicalDeleteCode == target.LogicalDeleteCode)

                && (this.SectionCode == target.SectionCode)  // ADD 2008/06/16

                /* --- DEL 2008/06/16 -------------------------------->>>>>
				&& (this.BillAllStCd == target.BillAllStCd)
				&& (this.MinusVarCstBlAdjstCd == target.MinusVarCstBlAdjstCd)
                   --- DEL 2008/06/16 --------------------------------<<<<< */

                && (this.AllowanceProcCd == target.AllowanceProcCd)
				&& (this.DepositSlipMntCd == target.DepositSlipMntCd)
                && (this._collectPlnDiv == target._collectPlnDiv)
				//&& (this.BfRmonCalcDivCd == target.BfRmonCalcDivCd)  // DEL 2008/06/16

				&& (this.UpdEmployeeName == target.UpdEmployeeName)
				&& (this.EnterpriseName == target.EnterpriseName)

                // --- ADD 2008/06/16 -------------------------------->>>>>
                && (this.CustomerTotalDay1 == target.CustomerTotalDay1)
                && (this.CustomerTotalDay2 == target.CustomerTotalDay2)
                && (this.CustomerTotalDay3 == target.CustomerTotalDay3)
                && (this.CustomerTotalDay4 == target.CustomerTotalDay4)
                && (this.CustomerTotalDay5 == target.CustomerTotalDay5)
                && (this.CustomerTotalDay6 == target.CustomerTotalDay6)
                && (this.CustomerTotalDay7 == target.CustomerTotalDay7)
                && (this.CustomerTotalDay8 == target.CustomerTotalDay8)
                && (this.CustomerTotalDay9 == target.CustomerTotalDay9)
                && (this.CustomerTotalDay10 == target.CustomerTotalDay10)
                && (this.CustomerTotalDay11 == target.CustomerTotalDay11)
                && (this.CustomerTotalDay12 == target.CustomerTotalDay12)
                && (this.SupplierTotalDay1 == target.SupplierTotalDay1)
                && (this.SupplierTotalDay2 == target.SupplierTotalDay2)
                && (this.SupplierTotalDay3 == target.SupplierTotalDay3)
                && (this.SupplierTotalDay4 == target.SupplierTotalDay4)
                && (this.SupplierTotalDay5 == target.SupplierTotalDay5)
                && (this.SupplierTotalDay6 == target.SupplierTotalDay6)
                && (this.SupplierTotalDay7 == target.SupplierTotalDay7)
                && (this.SupplierTotalDay8 == target.SupplierTotalDay8)
                && (this.SupplierTotalDay9 == target.SupplierTotalDay9)
                && (this.SupplierTotalDay10 == target.SupplierTotalDay10)
                && (this.SupplierTotalDay11 == target.SupplierTotalDay11)
                && (this.SupplierTotalDay12 == target.SupplierTotalDay12)
                // --- ADD 2008/06/16 --------------------------------<<<<< 
                );
		}

		/// <summary>
		/// 請求全体設定クラス比較処理
		/// </summary>
		/// <param name="billAllSt1">
		///                    比較するBillAllStクラスのインスタンス
		/// </param>
		/// <param name="billAllSt2">比較するBillAllStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(BillAllSt billAllSt1, BillAllSt billAllSt2)
		{
			return ((billAllSt1.CreateDateTime == billAllSt2.CreateDateTime)
				&& (billAllSt1.UpdateDateTime == billAllSt2.UpdateDateTime)
				&& (billAllSt1.EnterpriseCode == billAllSt2.EnterpriseCode)
				&& (billAllSt1.FileHeaderGuid == billAllSt2.FileHeaderGuid)
				&& (billAllSt1.UpdEmployeeCode == billAllSt2.UpdEmployeeCode)
				&& (billAllSt1.UpdAssemblyId1 == billAllSt2.UpdAssemblyId1)
				&& (billAllSt1.UpdAssemblyId2 == billAllSt2.UpdAssemblyId2)
				&& (billAllSt1.LogicalDeleteCode == billAllSt2.LogicalDeleteCode)

                && (billAllSt1.SectionCode == billAllSt2.SectionCode)  // ADD 2008/06/16

                /* --- DEL 2008/06/16 -------------------------------->>>>>
				&& (billAllSt1.BillAllStCd == billAllSt2.BillAllStCd)
				&& (billAllSt1.MinusVarCstBlAdjstCd == billAllSt2.MinusVarCstBlAdjstCd)
                   --- DEL 2008/06/16 --------------------------------<<<<< */

                && (billAllSt1.AllowanceProcCd == billAllSt2.AllowanceProcCd)
				&& (billAllSt1.DepositSlipMntCd == billAllSt2.DepositSlipMntCd)
                && (billAllSt1._collectPlnDiv == billAllSt2._collectPlnDiv)

				//&& (billAllSt1.BfRmonCalcDivCd == billAllSt2.BfRmonCalcDivCd)  // DEL 2008/06/16

				&& (billAllSt1.UpdEmployeeName == billAllSt2.UpdEmployeeName)
				&& (billAllSt1.EnterpriseName == billAllSt2.EnterpriseName)

                // --- ADD 2008/06/16 -------------------------------->>>>>
                && (billAllSt1.CustomerTotalDay1 == billAllSt2.CustomerTotalDay1)
                && (billAllSt1.CustomerTotalDay2 == billAllSt2.CustomerTotalDay2)
                && (billAllSt1.CustomerTotalDay3 == billAllSt2.CustomerTotalDay3)
                && (billAllSt1.CustomerTotalDay4 == billAllSt2.CustomerTotalDay4)
                && (billAllSt1.CustomerTotalDay5 == billAllSt2.CustomerTotalDay5)
                && (billAllSt1.CustomerTotalDay6 == billAllSt2.CustomerTotalDay6)
                && (billAllSt1.CustomerTotalDay7 == billAllSt2.CustomerTotalDay7)
                && (billAllSt1.CustomerTotalDay8 == billAllSt2.CustomerTotalDay8)
                && (billAllSt1.CustomerTotalDay9 == billAllSt2.CustomerTotalDay9)
                && (billAllSt1.CustomerTotalDay10 == billAllSt2.CustomerTotalDay10)
                && (billAllSt1.CustomerTotalDay11 == billAllSt2.CustomerTotalDay11)
                && (billAllSt1.CustomerTotalDay12 == billAllSt2.CustomerTotalDay12)
                && (billAllSt1.SupplierTotalDay1 == billAllSt2.SupplierTotalDay1)
                && (billAllSt1.SupplierTotalDay2 == billAllSt2.SupplierTotalDay2)
                && (billAllSt1.SupplierTotalDay3 == billAllSt2.SupplierTotalDay3)
                && (billAllSt1.SupplierTotalDay4 == billAllSt2.SupplierTotalDay4)
                && (billAllSt1.SupplierTotalDay5 == billAllSt2.SupplierTotalDay5)
                && (billAllSt1.SupplierTotalDay6 == billAllSt2.SupplierTotalDay6)
                && (billAllSt1.SupplierTotalDay7 == billAllSt2.SupplierTotalDay7)
                && (billAllSt1.SupplierTotalDay8 == billAllSt2.SupplierTotalDay8)
                && (billAllSt1.SupplierTotalDay9 == billAllSt2.SupplierTotalDay9)
                && (billAllSt1.SupplierTotalDay10 == billAllSt2.SupplierTotalDay10)
                && (billAllSt1.SupplierTotalDay11 == billAllSt2.SupplierTotalDay11)
                && (billAllSt1.SupplierTotalDay12 == billAllSt2.SupplierTotalDay12)
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                );
		}
		/// <summary>
		/// 請求全体設定クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBillAllStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(BillAllSt target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");

            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/16

            /* --- DEL 2008/06/16 -------------------------------->>>>>
			if(this.BillAllStCd != target.BillAllStCd)resList.Add("BillAllStCd");
			if(this.MinusVarCstBlAdjstCd != target.MinusVarCstBlAdjstCd)resList.Add("MinusVarCstBlAdjstCd");
               --- DEL 2008/06/16 --------------------------------<<<<< */
            if(this.AllowanceProcCd != target.AllowanceProcCd)resList.Add("AllowanceProcCd");
			if(this.DepositSlipMntCd != target.DepositSlipMntCd)resList.Add("DepositSlipMntCd");
            if (this.CollectPlnDiv != target.CollectPlnDiv) resList.Add("CollectPlnDiv");

			//if(this.BfRmonCalcDivCd != target.BfRmonCalcDivCd)resList.Add("BfRmonCalcDivCd");  // DEL 2008/06/16

			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

            // --- ADD 2008/06/16 -------------------------------->>>>>
            if (this.CustomerTotalDay1 != target.CustomerTotalDay1) resList.Add("CustomerTotalDay1");
            if (this.CustomerTotalDay2 != target.CustomerTotalDay2) resList.Add("CustomerTotalDay2");
            if (this.CustomerTotalDay3 != target.CustomerTotalDay3) resList.Add("CustomerTotalDay3");
            if (this.CustomerTotalDay4 != target.CustomerTotalDay4) resList.Add("CustomerTotalDay4");
            if (this.CustomerTotalDay5 != target.CustomerTotalDay5) resList.Add("CustomerTotalDay5");
            if (this.CustomerTotalDay6 != target.CustomerTotalDay6) resList.Add("CustomerTotalDay6");
            if (this.CustomerTotalDay7 != target.CustomerTotalDay7) resList.Add("CustomerTotalDay7");
            if (this.CustomerTotalDay8 != target.CustomerTotalDay8) resList.Add("CustomerTotalDay8");
            if (this.CustomerTotalDay9 != target.CustomerTotalDay9) resList.Add("CustomerTotalDay9");
            if (this.CustomerTotalDay10 != target.CustomerTotalDay10) resList.Add("CustomerTotalDay10");
            if (this.CustomerTotalDay11 != target.CustomerTotalDay11) resList.Add("CustomerTotalDay11");
            if (this.CustomerTotalDay12 != target.CustomerTotalDay12) resList.Add("CustomerTotalDay12");

            if (this.SupplierTotalDay1 != target.SupplierTotalDay1) resList.Add("SupplierTotalDay1");
            if (this.SupplierTotalDay2 != target.SupplierTotalDay2) resList.Add("SupplierTotalDay2");
            if (this.SupplierTotalDay3 != target.SupplierTotalDay3) resList.Add("SupplierTotalDay3");
            if (this.SupplierTotalDay4 != target.SupplierTotalDay4) resList.Add("SupplierTotalDay4");
            if (this.SupplierTotalDay5 != target.SupplierTotalDay5) resList.Add("SupplierTotalDay5");
            if (this.SupplierTotalDay6 != target.SupplierTotalDay6) resList.Add("SupplierTotalDay6");
            if (this.SupplierTotalDay7 != target.SupplierTotalDay7) resList.Add("SupplierTotalDay7");
            if (this.SupplierTotalDay8 != target.SupplierTotalDay8) resList.Add("SupplierTotalDay8");
            if (this.SupplierTotalDay9 != target.SupplierTotalDay9) resList.Add("SupplierTotalDay9");
            if (this.SupplierTotalDay10 != target.SupplierTotalDay10) resList.Add("SupplierTotalDay10");
            if (this.SupplierTotalDay11 != target.SupplierTotalDay11) resList.Add("SupplierTotalDay11");
            if (this.SupplierTotalDay12 != target.SupplierTotalDay12) resList.Add("SupplierTotalDay12");
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return resList;
		}

		/// <summary>
		/// 請求全体設定クラス比較処理
		/// </summary>
		/// <param name="billAllSt1">比較するBillAllStクラスのインスタンス</param>
		/// <param name="billAllSt2">比較するBillAllStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BillAllStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(BillAllSt billAllSt1, BillAllSt billAllSt2)
		{
			ArrayList resList = new ArrayList();
			if(billAllSt1.CreateDateTime != billAllSt2.CreateDateTime)resList.Add("CreateDateTime");
			if(billAllSt1.UpdateDateTime != billAllSt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(billAllSt1.EnterpriseCode != billAllSt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(billAllSt1.FileHeaderGuid != billAllSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(billAllSt1.UpdEmployeeCode != billAllSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(billAllSt1.UpdAssemblyId1 != billAllSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(billAllSt1.UpdAssemblyId2 != billAllSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(billAllSt1.LogicalDeleteCode != billAllSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");

            if (billAllSt1.SectionCode != billAllSt2.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/16

            /* --- DEL 2008/06/16 -------------------------------->>>>>
            if(billAllSt1.BillAllStCd != billAllSt2.BillAllStCd)resList.Add("BillAllStCd");
            if(billAllSt1.MinusVarCstBlAdjstCd != billAllSt2.MinusVarCstBlAdjstCd)resList.Add("MinusVarCstBlAdjstCd");
               --- DEL 2008/06/16 --------------------------------<<<<< */


            if (billAllSt1.AllowanceProcCd != billAllSt2.AllowanceProcCd)resList.Add("AllowanceProcCd");
			if(billAllSt1.DepositSlipMntCd != billAllSt2.DepositSlipMntCd)resList.Add("DepositSlipMntCd");
            if (billAllSt1.CollectPlnDiv != billAllSt2.CollectPlnDiv) resList.Add("CollectPlnDiv");

			//if(billAllSt1.BfRmonCalcDivCd != billAllSt2.BfRmonCalcDivCd)resList.Add("BfRmonCalcDivCd");  // DEL 2008/06/16

			if(billAllSt1.UpdEmployeeName != billAllSt2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(billAllSt1.EnterpriseName != billAllSt2.EnterpriseName)resList.Add("EnterpriseName");

            // --- ADD 2008/06/16 -------------------------------->>>>>
            if (billAllSt1.CustomerTotalDay1 != billAllSt2.CustomerTotalDay1) resList.Add("CustomerTotalDay1");
            if (billAllSt1.CustomerTotalDay2 != billAllSt2.CustomerTotalDay2) resList.Add("CustomerTotalDay2");
            if (billAllSt1.CustomerTotalDay3 != billAllSt2.CustomerTotalDay3) resList.Add("CustomerTotalDay3");
            if (billAllSt1.CustomerTotalDay4 != billAllSt2.CustomerTotalDay4) resList.Add("CustomerTotalDay4");
            if (billAllSt1.CustomerTotalDay5 != billAllSt2.CustomerTotalDay5) resList.Add("CustomerTotalDay5");
            if (billAllSt1.CustomerTotalDay6 != billAllSt2.CustomerTotalDay6) resList.Add("CustomerTotalDay6");
            if (billAllSt1.CustomerTotalDay7 != billAllSt2.CustomerTotalDay7) resList.Add("CustomerTotalDay7");
            if (billAllSt1.CustomerTotalDay8 != billAllSt2.CustomerTotalDay8) resList.Add("CustomerTotalDay8");
            if (billAllSt1.CustomerTotalDay9 != billAllSt2.CustomerTotalDay9) resList.Add("CustomerTotalDay9");
            if (billAllSt1.CustomerTotalDay10 != billAllSt2.CustomerTotalDay10) resList.Add("CustomerTotalDay10");
            if (billAllSt1.CustomerTotalDay11 != billAllSt2.CustomerTotalDay11) resList.Add("CustomerTotalDay11");
            if (billAllSt1.CustomerTotalDay12 != billAllSt2.CustomerTotalDay12) resList.Add("CustomerTotalDay12");

            if (billAllSt1.SupplierTotalDay1 != billAllSt2.SupplierTotalDay1) resList.Add("SupplierTotalDay1");
            if (billAllSt1.SupplierTotalDay2 != billAllSt2.SupplierTotalDay2) resList.Add("SupplierTotalDay2");
            if (billAllSt1.SupplierTotalDay3 != billAllSt2.SupplierTotalDay3) resList.Add("SupplierTotalDay3");
            if (billAllSt1.SupplierTotalDay4 != billAllSt2.SupplierTotalDay4) resList.Add("SupplierTotalDay4");
            if (billAllSt1.SupplierTotalDay5 != billAllSt2.SupplierTotalDay5) resList.Add("SupplierTotalDay5");
            if (billAllSt1.SupplierTotalDay6 != billAllSt2.SupplierTotalDay6) resList.Add("SupplierTotalDay6");
            if (billAllSt1.SupplierTotalDay7 != billAllSt2.SupplierTotalDay7) resList.Add("SupplierTotalDay7");
            if (billAllSt1.SupplierTotalDay8 != billAllSt2.SupplierTotalDay8) resList.Add("SupplierTotalDay8");
            if (billAllSt1.SupplierTotalDay9 != billAllSt2.SupplierTotalDay9) resList.Add("SupplierTotalDay9");
            if (billAllSt1.SupplierTotalDay10 != billAllSt2.SupplierTotalDay10) resList.Add("SupplierTotalDay10");
            if (billAllSt1.SupplierTotalDay11 != billAllSt2.SupplierTotalDay11) resList.Add("SupplierTotalDay11");
            if (billAllSt1.SupplierTotalDay12 != billAllSt2.SupplierTotalDay12) resList.Add("SupplierTotalDay12");
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return resList;
		}
	}
}
