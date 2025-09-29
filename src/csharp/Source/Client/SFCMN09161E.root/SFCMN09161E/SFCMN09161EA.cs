using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   AlItmDspNm
	/// <summary>
	///                      全体項目表示名称マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   全体項目表示名称マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/08/25</br>
	/// <br>Genarated Date   :   2006/08/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class AlItmDspNm
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

		/// <summary>表示名称管理No</summary>
		/// <remarks>0固定</remarks>
		private Int32 _dspNameManageNo;

		/// <summary>自宅TEL表示名称</summary>
		private string _homeTelNoDspName = "";

		/// <summary>勤務先TEL表示名称</summary>
		private string _officeTelNoDspName = "";

		/// <summary>携帯TEL表示名称</summary>
		private string _mobileTelNoDspName = "";

		/// <summary>その他TEL表示名称</summary>
		private string _otherTelNoDspName = "";

		/// <summary>自宅FAX表示名称</summary>
		private string _homeFaxNoDspName = "";

		/// <summary>勤務先FAX表示名称</summary>
		private string _officeFaxNoDspName = "";

		/// <summary>追加情報1表示名称</summary>
		private string _addInfo1DspName = "";

		/// <summary>追加情報2表示名称</summary>
		private string _addInfo2DspName = "";

		/// <summary>追加情報3表示名称</summary>
		private string _addInfo3DspName = "";

        /// <summary>結合表示名称</summary>
        private string _joinDspName = "";

        /// <summary>仕入率表示名称</summary>
        private string _stockRateDspName = "";

        /// <summary>原単価表示名称</summary>
        private string _unitCostDspName = "";

        /// <summary>粗利額表示名称</summary>
        private string _profitDspName = "";

        /// <summary>粗利率表示名称</summary>
        private string _profitRateDspName = "";

        /// <summary>外税表示名称</summary>
        private string _outTaxDspName = "";

        /// <summary>内税表示名称</summary>
        private string _inTaxDspName = "";

        /// <summary>定価表示名称</summary>
        private string _listPriceDspName = "";

        /// <summary>納品書敬称初期値</summary>
        private string _deliHonorTtlDef = "";

        /// <summary>請求書敬称初期値</summary>
        private string _billHonorTtlDef = "";

        /// <summary>見積書敬称初期値</summary>
        private string _estmHonorTtlDef = "";

        /// <summary>発注書敬称初期値</summary>
        private string _rectHonorTtlDef = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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

		/// public propaty name  :  DspNameManageNo
		/// <summary>表示名称管理Noプロパティ</summary>
		/// <value>0固定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示名称管理Noプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DspNameManageNo
		{
			get{return _dspNameManageNo;}
			set{_dspNameManageNo = value;}
		}

		/// public propaty name  :  HomeTelNoDspName
		/// <summary>自宅TEL表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自宅TEL表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeTelNoDspName
		{
			get{return _homeTelNoDspName;}
			set{_homeTelNoDspName = value;}
		}

		/// public propaty name  :  OfficeTelNoDspName
		/// <summary>勤務先TEL表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   勤務先TEL表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeTelNoDspName
		{
			get{return _officeTelNoDspName;}
			set{_officeTelNoDspName = value;}
		}

		/// public propaty name  :  MobileTelNoDspName
		/// <summary>携帯TEL表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   携帯TEL表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MobileTelNoDspName
		{
			get{return _mobileTelNoDspName;}
			set{_mobileTelNoDspName = value;}
		}

		/// public propaty name  :  OtherTelNoDspName
		/// <summary>その他TEL表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   その他TEL表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OtherTelNoDspName
		{
			get{return _otherTelNoDspName;}
			set{_otherTelNoDspName = value;}
		}

		/// public propaty name  :  HomeFaxNoDspName
		/// <summary>自宅FAX表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自宅FAX表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HomeFaxNoDspName
		{
			get{return _homeFaxNoDspName;}
			set{_homeFaxNoDspName = value;}
		}

		/// public propaty name  :  OfficeFaxNoDspName
		/// <summary>勤務先FAX表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   勤務先FAX表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OfficeFaxNoDspName
		{
			get{return _officeFaxNoDspName;}
			set{_officeFaxNoDspName = value;}
		}

		/// public propaty name  :  AddInfo1DspName
		/// <summary>追加情報1表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   追加情報1表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddInfo1DspName
		{
			get{return _addInfo1DspName;}
			set{_addInfo1DspName = value;}
		}

		/// public propaty name  :  AddInfo2DspName
		/// <summary>追加情報2表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   追加情報2表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddInfo2DspName
		{
			get{return _addInfo2DspName;}
			set{_addInfo2DspName = value;}
		}

		/// public propaty name  :  AddInfo3DspName
		/// <summary>追加情報3表示名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   追加情報3表示名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddInfo3DspName
		{
			get{return _addInfo3DspName;}
			set{_addInfo3DspName = value;}
		}

        /// public propaty name  :  JoinDspName
        /// <summary>結合表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDspName
        {
            get { return _joinDspName; }
            set { _joinDspName = value; }
        }

        /// public propaty name  :  StockRateDspName
        /// <summary>仕入率表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入率表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockRateDspName
        {
            get { return _stockRateDspName; }
            set { _stockRateDspName = value; }
        }

        /// public propaty name  :  UnitCostDspName
        /// <summary>原単価表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原単価表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UnitCostDspName
        {
            get { return _unitCostDspName; }
            set { _unitCostDspName = value; }
        }

        /// public propaty name  :  ProfitDspName
        /// <summary>粗利額表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利額表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProfitDspName
        {
            get { return _profitDspName; }
            set { _profitDspName = value; }
        }

        /// public propaty name  :  ProfitRateDspName
        /// <summary>粗利率表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProfitRateDspName
        {
            get { return _profitRateDspName; }
            set { _profitRateDspName = value; }
        }

        /// public propaty name  :  OutTaxDspName
        /// <summary>外税表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   外税表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutTaxDspName
        {
            get { return _outTaxDspName; }
            set { _outTaxDspName = value; }
        }

        /// public propaty name  :  InTaxDspName
        /// <summary>内税表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   内税表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InTaxDspName
        {
            get { return _inTaxDspName; }
            set { _inTaxDspName = value; }
        }

        /// public propaty name  :  ListPriceDspName
        /// <summary>定価表示名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPriceDspName
        {
            get { return _listPriceDspName; }
            set { _listPriceDspName = value; }
        }

        /// public propaty name  :  DeliHonorTtlDef
        /// <summary>納品書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliHonorTtlDef
        {
            get { return _deliHonorTtlDef; }
            set { _deliHonorTtlDef = value; }
        }

        /// public propaty name  :  BillHonorTtlDef
        /// <summary>請求書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillHonorTtlDef
        {
            get { return _billHonorTtlDef; }
            set { _billHonorTtlDef = value; }
        }

        /// public propaty name  :  EstmHonorTtlDef
        /// <summary>見積書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstmHonorTtlDef
        {
            get { return _estmHonorTtlDef; }
            set { _estmHonorTtlDef = value; }
        }

        /// public propaty name  :  RectHonorTtlDef
        /// <summary>発注書敬称初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注書敬称初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RectHonorTtlDef
        {
            get { return _rectHonorTtlDef; }
            set { _rectHonorTtlDef = value; }
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


		/// <summary>
		/// 全体項目表示名称マスタコンストラクタ
		/// </summary>
		/// <returns>AlItmDspNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AlItmDspNm()
		{
		}

		/// <summary>
		/// 全体項目表示名称マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="dspNameManageNo">表示名称管理No(0固定)</param>
		/// <param name="homeTelNoDspName">自宅TEL表示名称</param>
		/// <param name="officeTelNoDspName">勤務先TEL表示名称</param>
		/// <param name="mobileTelNoDspName">携帯TEL表示名称</param>
		/// <param name="otherTelNoDspName">その他TEL表示名称</param>
		/// <param name="homeFaxNoDspName">自宅FAX表示名称</param>
		/// <param name="officeFaxNoDspName">勤務先FAX表示名称</param>
		/// <param name="addInfo1DspName">追加情報1表示名称</param>
		/// <param name="addInfo2DspName">追加情報2表示名称</param>
		/// <param name="addInfo3DspName">追加情報3表示名称</param>
        /// <param name="joinDspName">結合表示名称</param>
        /// <param name="stockRateDspName">仕入率表示名称</param>
        /// <param name="unitCostDspName">原単価表示名称</param>
        /// <param name="profitDspName">粗利額表示名称</param>
        /// <param name="profitRateDspName">粗利率表示名称</param>
        /// <param name="outTaxDspName">外税表示名称</param>
        /// <param name="inTaxDspName">内税表示名称</param>
        /// <param name="listPriceDspName">定価表示名称</param>
        /// <param name="deliHonorTtlDef">納品書敬称初期値</param>
        /// <param name="billHonorTtlDef">請求書敬称初期値</param>
        /// <param name="estmHonorTtlDef">見積書敬称初期値</param>
        /// <param name="rectHonorTtlDef">発注書敬称初期値</param>
        /// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>AlItmDspNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public AlItmDspNm(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dspNameManageNo, string homeTelNoDspName, string officeTelNoDspName, string mobileTelNoDspName, string otherTelNoDspName, string homeFaxNoDspName, string officeFaxNoDspName, string addInfo1DspName, string addInfo2DspName, string addInfo3DspName, string joinDspName, string stockRateDspName, string unitCostDspName, string profitDspName, string profitRateDspName, string outTaxDspName, string inTaxDspName, string listPriceDspName, string deliHonorTtlDef, string billHonorTtlDef, string estmHonorTtlDef, string rectHonorTtlDef, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._dspNameManageNo = dspNameManageNo;
			this._homeTelNoDspName = homeTelNoDspName;
			this._officeTelNoDspName = officeTelNoDspName;
			this._mobileTelNoDspName = mobileTelNoDspName;
			this._otherTelNoDspName = otherTelNoDspName;
			this._homeFaxNoDspName = homeFaxNoDspName;
			this._officeFaxNoDspName = officeFaxNoDspName;
			this._addInfo1DspName = addInfo1DspName;
			this._addInfo2DspName = addInfo2DspName;
			this._addInfo3DspName = addInfo3DspName;
            this._joinDspName = joinDspName;
            this._stockRateDspName = stockRateDspName;
            this._unitCostDspName = unitCostDspName;
            this._profitDspName = profitDspName;
            this._profitRateDspName = profitRateDspName;
            this._outTaxDspName = outTaxDspName;
            this._inTaxDspName = inTaxDspName;
            this._listPriceDspName = listPriceDspName;
            this._deliHonorTtlDef = deliHonorTtlDef;
            this._billHonorTtlDef = billHonorTtlDef;
            this._estmHonorTtlDef = estmHonorTtlDef;
            this._rectHonorTtlDef = rectHonorTtlDef;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 全体項目表示名称マスタ複製処理
		/// </summary>
		/// <returns>AlItmDspNmクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいAlItmDspNmクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AlItmDspNm Clone()
		{
			return new AlItmDspNm(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._dspNameManageNo,this._homeTelNoDspName,this._officeTelNoDspName,this._mobileTelNoDspName,this._otherTelNoDspName,this._homeFaxNoDspName,this._officeFaxNoDspName,this._addInfo1DspName,this._addInfo2DspName,this._addInfo3DspName,this._joinDspName,this._stockRateDspName,this._unitCostDspName,this._profitDspName,this._profitRateDspName,this._outTaxDspName,this._inTaxDspName,this._listPriceDspName,this._deliHonorTtlDef,this._billHonorTtlDef,this._estmHonorTtlDef,this._rectHonorTtlDef, this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// 全体項目表示名称マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のAlItmDspNmクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(AlItmDspNm target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.DspNameManageNo == target.DspNameManageNo)
				 && (this.HomeTelNoDspName == target.HomeTelNoDspName)
				 && (this.OfficeTelNoDspName == target.OfficeTelNoDspName)
				 && (this.MobileTelNoDspName == target.MobileTelNoDspName)
				 && (this.OtherTelNoDspName == target.OtherTelNoDspName)
				 && (this.HomeFaxNoDspName == target.HomeFaxNoDspName)
				 && (this.OfficeFaxNoDspName == target.OfficeFaxNoDspName)
				 && (this.AddInfo1DspName == target.AddInfo1DspName)
				 && (this.AddInfo2DspName == target.AddInfo2DspName)
				 && (this.AddInfo3DspName == target.AddInfo3DspName)
                 && (this.JoinDspName == target.JoinDspName)
                 && (this.StockRateDspName == target.StockRateDspName)
                 && (this.UnitCostDspName == target.UnitCostDspName)
                 && (this.ProfitDspName == target.ProfitDspName)
                 && (this.ProfitRateDspName == target.ProfitRateDspName)
                 && (this.OutTaxDspName == target.OutTaxDspName)
                 && (this.InTaxDspName == target.InTaxDspName)
                 && (this.ListPriceDspName == target.ListPriceDspName)
                 && (this.DeliHonorTtlDef == target.DeliHonorTtlDef)
                 && (this.BillHonorTtlDef == target.BillHonorTtlDef)
                 && (this.EstmHonorTtlDef == target.EstmHonorTtlDef)
                 && (this.RectHonorTtlDef == target.RectHonorTtlDef)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 全体項目表示名称マスタ比較処理
		/// </summary>
		/// <param name="alItmDspNm1">
		///                    比較するAlItmDspNmクラスのインスタンス
		/// </param>
		/// <param name="alItmDspNm2">比較するAlItmDspNmクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(AlItmDspNm alItmDspNm1, AlItmDspNm alItmDspNm2)
		{
			return ((alItmDspNm1.CreateDateTime == alItmDspNm2.CreateDateTime)
				 && (alItmDspNm1.UpdateDateTime == alItmDspNm2.UpdateDateTime)
				 && (alItmDspNm1.EnterpriseCode == alItmDspNm2.EnterpriseCode)
				 && (alItmDspNm1.FileHeaderGuid == alItmDspNm2.FileHeaderGuid)
				 && (alItmDspNm1.UpdEmployeeCode == alItmDspNm2.UpdEmployeeCode)
				 && (alItmDspNm1.UpdAssemblyId1 == alItmDspNm2.UpdAssemblyId1)
				 && (alItmDspNm1.UpdAssemblyId2 == alItmDspNm2.UpdAssemblyId2)
				 && (alItmDspNm1.LogicalDeleteCode == alItmDspNm2.LogicalDeleteCode)
				 && (alItmDspNm1.DspNameManageNo == alItmDspNm2.DspNameManageNo)
				 && (alItmDspNm1.HomeTelNoDspName == alItmDspNm2.HomeTelNoDspName)
				 && (alItmDspNm1.OfficeTelNoDspName == alItmDspNm2.OfficeTelNoDspName)
				 && (alItmDspNm1.MobileTelNoDspName == alItmDspNm2.MobileTelNoDspName)
				 && (alItmDspNm1.OtherTelNoDspName == alItmDspNm2.OtherTelNoDspName)
				 && (alItmDspNm1.HomeFaxNoDspName == alItmDspNm2.HomeFaxNoDspName)
				 && (alItmDspNm1.OfficeFaxNoDspName == alItmDspNm2.OfficeFaxNoDspName)
				 && (alItmDspNm1.AddInfo1DspName == alItmDspNm2.AddInfo1DspName)
				 && (alItmDspNm1.AddInfo2DspName == alItmDspNm2.AddInfo2DspName)
				 && (alItmDspNm1.AddInfo3DspName == alItmDspNm2.AddInfo3DspName)
                 && (alItmDspNm1.JoinDspName == alItmDspNm2.JoinDspName)
                 && (alItmDspNm1.StockRateDspName == alItmDspNm2.StockRateDspName)
                 && (alItmDspNm1.UnitCostDspName == alItmDspNm2.UnitCostDspName)
                 && (alItmDspNm1.ProfitDspName == alItmDspNm2.ProfitDspName)
                 && (alItmDspNm1.ProfitRateDspName == alItmDspNm2.ProfitRateDspName)
                 && (alItmDspNm1.OutTaxDspName == alItmDspNm2.OutTaxDspName)
                 && (alItmDspNm1.InTaxDspName == alItmDspNm2.InTaxDspName)
                 && (alItmDspNm1.ListPriceDspName == alItmDspNm2.ListPriceDspName)
                 && (alItmDspNm1.DeliHonorTtlDef == alItmDspNm2.DeliHonorTtlDef)
                 && (alItmDspNm1.BillHonorTtlDef == alItmDspNm2.BillHonorTtlDef)
                 && (alItmDspNm1.EstmHonorTtlDef == alItmDspNm2.EstmHonorTtlDef)
                 && (alItmDspNm1.RectHonorTtlDef == alItmDspNm2.RectHonorTtlDef)
				 && (alItmDspNm1.EnterpriseName == alItmDspNm2.EnterpriseName)
				 && (alItmDspNm1.UpdEmployeeName == alItmDspNm2.UpdEmployeeName));
		}
		/// <summary>
		/// 全体項目表示名称マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のAlItmDspNmクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(AlItmDspNm target)
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
			if(this.DspNameManageNo != target.DspNameManageNo)resList.Add("DspNameManageNo");
			if(this.HomeTelNoDspName != target.HomeTelNoDspName)resList.Add("HomeTelNoDspName");
			if(this.OfficeTelNoDspName != target.OfficeTelNoDspName)resList.Add("OfficeTelNoDspName");
			if(this.MobileTelNoDspName != target.MobileTelNoDspName)resList.Add("MobileTelNoDspName");
			if(this.OtherTelNoDspName != target.OtherTelNoDspName)resList.Add("OtherTelNoDspName");
			if(this.HomeFaxNoDspName != target.HomeFaxNoDspName)resList.Add("HomeFaxNoDspName");
			if(this.OfficeFaxNoDspName != target.OfficeFaxNoDspName)resList.Add("OfficeFaxNoDspName");
			if(this.AddInfo1DspName != target.AddInfo1DspName)resList.Add("AddInfo1DspName");
			if(this.AddInfo2DspName != target.AddInfo2DspName)resList.Add("AddInfo2DspName");
			if(this.AddInfo3DspName != target.AddInfo3DspName)resList.Add("AddInfo3DspName");
            if(this.JoinDspName != target.JoinDspName)resList.Add("JoinDspName");
            if (this.StockRateDspName != target.StockRateDspName) resList.Add("StockRateDspName");
            if (this.UnitCostDspName != target.UnitCostDspName) resList.Add("UnitCostDspName");
            if (this.ProfitDspName != target.ProfitDspName) resList.Add("ProfitDspName");
            if (this.ProfitRateDspName != target.ProfitRateDspName) resList.Add("ProfitRateDspName");
            if (this.OutTaxDspName != target.OutTaxDspName) resList.Add("OutTaxDspName");
            if (this.InTaxDspName != target.InTaxDspName) resList.Add("InTaxDspName");
            if (this.ListPriceDspName != target.ListPriceDspName) resList.Add("ListPriceDspName");
            if (this.DeliHonorTtlDef != target.DeliHonorTtlDef) resList.Add("DeliHonorTtlDef");
            if (this.BillHonorTtlDef != target.BillHonorTtlDef) resList.Add("BillHonorTtlDef");
            if (this.EstmHonorTtlDef != target.EstmHonorTtlDef) resList.Add("EstmHonorTtlDef");
            if (this.RectHonorTtlDef != target.RectHonorTtlDef) resList.Add("RectHonorTtlDef");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 全体項目表示名称マスタ比較処理
		/// </summary>
		/// <param name="alItmDspNm1">比較するAlItmDspNmクラスのインスタンス</param>
		/// <param name="alItmDspNm2">比較するAlItmDspNmクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AlItmDspNmクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(AlItmDspNm alItmDspNm1, AlItmDspNm alItmDspNm2)
		{
			ArrayList resList = new ArrayList();
			if(alItmDspNm1.CreateDateTime != alItmDspNm2.CreateDateTime)resList.Add("CreateDateTime");
			if(alItmDspNm1.UpdateDateTime != alItmDspNm2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(alItmDspNm1.EnterpriseCode != alItmDspNm2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(alItmDspNm1.FileHeaderGuid != alItmDspNm2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(alItmDspNm1.UpdEmployeeCode != alItmDspNm2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(alItmDspNm1.UpdAssemblyId1 != alItmDspNm2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(alItmDspNm1.UpdAssemblyId2 != alItmDspNm2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(alItmDspNm1.LogicalDeleteCode != alItmDspNm2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(alItmDspNm1.DspNameManageNo != alItmDspNm2.DspNameManageNo)resList.Add("DspNameManageNo");
			if(alItmDspNm1.HomeTelNoDspName != alItmDspNm2.HomeTelNoDspName)resList.Add("HomeTelNoDspName");
			if(alItmDspNm1.OfficeTelNoDspName != alItmDspNm2.OfficeTelNoDspName)resList.Add("OfficeTelNoDspName");
			if(alItmDspNm1.MobileTelNoDspName != alItmDspNm2.MobileTelNoDspName)resList.Add("MobileTelNoDspName");
			if(alItmDspNm1.OtherTelNoDspName != alItmDspNm2.OtherTelNoDspName)resList.Add("OtherTelNoDspName");
			if(alItmDspNm1.HomeFaxNoDspName != alItmDspNm2.HomeFaxNoDspName)resList.Add("HomeFaxNoDspName");
			if(alItmDspNm1.OfficeFaxNoDspName != alItmDspNm2.OfficeFaxNoDspName)resList.Add("OfficeFaxNoDspName");
			if(alItmDspNm1.AddInfo1DspName != alItmDspNm2.AddInfo1DspName)resList.Add("AddInfo1DspName");
			if(alItmDspNm1.AddInfo2DspName != alItmDspNm2.AddInfo2DspName)resList.Add("AddInfo2DspName");
			if(alItmDspNm1.AddInfo3DspName != alItmDspNm2.AddInfo3DspName)resList.Add("AddInfo3DspName");
            if (alItmDspNm1.StockRateDspName != alItmDspNm2.StockRateDspName) resList.Add("StockRateDspName");
            if (alItmDspNm1.UnitCostDspName != alItmDspNm2.UnitCostDspName) resList.Add("UnitCostDspName");
            if (alItmDspNm1.ProfitDspName != alItmDspNm2.ProfitDspName) resList.Add("ProfitDspName");
            if (alItmDspNm1.ProfitRateDspName != alItmDspNm2.ProfitRateDspName) resList.Add("ProfitRateDspName");
            if (alItmDspNm1.OutTaxDspName != alItmDspNm2.OutTaxDspName) resList.Add("OutTaxDspName");
            if (alItmDspNm1.InTaxDspName != alItmDspNm2.InTaxDspName) resList.Add("InTaxDspName");
            if (alItmDspNm1.ListPriceDspName != alItmDspNm2.ListPriceDspName) resList.Add("ListPriceDspName");
            if (alItmDspNm1.DeliHonorTtlDef != alItmDspNm2.DeliHonorTtlDef) resList.Add("DeliHonorTtlDef");
            if (alItmDspNm1.BillHonorTtlDef != alItmDspNm2.BillHonorTtlDef) resList.Add("BillHonorTtlDef");
            if (alItmDspNm1.EstmHonorTtlDef != alItmDspNm2.EstmHonorTtlDef) resList.Add("EstmHonorTtlDef");
            if (alItmDspNm1.RectHonorTtlDef != alItmDspNm2.RectHonorTtlDef) resList.Add("RectHonorTtlDef");
			if(alItmDspNm1.EnterpriseName != alItmDspNm2.EnterpriseName)resList.Add("EnterpriseName");
			if(alItmDspNm1.UpdEmployeeName != alItmDspNm2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
