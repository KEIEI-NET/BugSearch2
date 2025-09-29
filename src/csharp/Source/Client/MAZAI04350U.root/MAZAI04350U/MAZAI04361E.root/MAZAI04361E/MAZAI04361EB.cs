using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAdjustDtl
	/// <summary>
	///                      在庫調整明細データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫調整明細データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  長内</br>
	/// <br>                 :   受払元取引区分、受払元伝票区分の補足に</br>
	/// <br>                 :   「42:マスタメンテ」を追加</br>
	/// <br>Update Note      :   2008/6/30  杉村</br>
	/// <br>                 :   受払元取引区分の補足の</br>
	/// <br>                 :   「42:マスタメンテ」削除</br>
	/// <br>Update Note      :   2008/7/29  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   仕入形式（元）</br>
	/// <br>                 :   仕入明細通番（元）</br>
	/// <br>Update Note      :   2008/8/22  長内</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   　仕入在庫数</br>
	/// <br>                 :   　受託数</br>
	/// <br>                 :   　変更前在庫状態</br>
	/// <br>                 :   　在庫区分</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   　BL商品コード名称</br>
	/// <br>                 :   　オープン価格区分</br>
	/// <br>                 :   　仕入金額（税抜き）</br>
	/// </remarks>
	public class StockAdjustDtl
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

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>在庫調整伝票番号</summary>
		private Int32 _stockAdjustSlipNo;

		/// <summary>在庫調整行番号</summary>
		private Int32 _stockAdjustRowNo;

		/// <summary>仕入形式（元）</summary>
		/// <remarks>0:仕入,1:入荷,2:発注</remarks>
		private Int32 _supplierFormalSrc;

		/// <summary>仕入明細通番（元）</summary>
		/// <remarks>計上時の元データ明細通番をセット</remarks>
		private Int64 _stockSlipDtlNumSrc;

		/// <summary>受払元伝票区分</summary>
		/// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>受払元取引区分</summary>
		/// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
		private Int32 _acPayTransCd;

		/// <summary>調整日付</summary>
		private DateTime _adjustDate;

		/// <summary>入力日付</summary>
		private DateTime _inputDay;

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>仕入単価（税抜,浮動）</summary>
		/// <remarks>在庫調整入力、棚卸過不足更新の単価変更時にセット</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>変更前仕入単価（浮動）</summary>
		private Double _bfStockUnitPriceFl;

		/// <summary>調整数</summary>
		/// <remarks>変更前と変更後の仕入在庫数の差を登録する。</remarks>
		private Double _adjustCount;

		/// <summary>明細備考</summary>
		private string _dtlNote = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>定価（浮動）</summary>
		private Double _listPriceFl;

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>仕入金額（税抜き）</summary>
		private Int64 _stockPriceTaxExc;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private String _supplierSnm;

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

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  StockAdjustSlipNo
		/// <summary>在庫調整伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫調整伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAdjustSlipNo
		{
			get{return _stockAdjustSlipNo;}
			set{_stockAdjustSlipNo = value;}
		}

		/// public propaty name  :  StockAdjustRowNo
		/// <summary>在庫調整行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫調整行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockAdjustRowNo
		{
			get{return _stockAdjustRowNo;}
			set{_stockAdjustRowNo = value;}
		}

		/// public propaty name  :  SupplierFormalSrc
		/// <summary>仕入形式（元）プロパティ</summary>
		/// <value>0:仕入,1:入荷,2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入形式（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierFormalSrc
		{
			get{return _supplierFormalSrc;}
			set{_supplierFormalSrc = value;}
		}

		/// public propaty name  :  StockSlipDtlNumSrc
		/// <summary>仕入明細通番（元）プロパティ</summary>
		/// <value>計上時の元データ明細通番をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNumSrc
		{
			get{return _stockSlipDtlNumSrc;}
			set{_stockSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// <value>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>受払元取引区分プロパティ</summary>
		/// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元取引区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AdjustDate
		/// <summary>調整日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AdjustDate
		{
			get{return _adjustDate;}
			set{_adjustDate = value;}
		}

		/// public propaty name  :  AdjustDateJpFormal
		/// <summary>調整日付 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateJpInFormal
		/// <summary>調整日付 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdFormal
		/// <summary>調整日付 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  AdjustDateAdInFormal
		/// <summary>調整日付 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AdjustDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _adjustDate);}
			set{}
		}

		/// public propaty name  :  InputDay
		/// <summary>入力日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  InputDayJpFormal
		/// <summary>入力日付 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayJpInFormal
		/// <summary>入力日付 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdFormal
		/// <summary>入力日付 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  InputDayAdInFormal
		/// <summary>入力日付 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inputDay);}
			set{}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜,浮動）プロパティ</summary>
		/// <value>在庫調整入力、棚卸過不足更新の単価変更時にセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  BfStockUnitPriceFl
		/// <summary>変更前仕入単価（浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfStockUnitPriceFl
		{
			get{return _bfStockUnitPriceFl;}
			set{_bfStockUnitPriceFl = value;}
		}

		/// public propaty name  :  AdjustCount
		/// <summary>調整数プロパティ</summary>
		/// <value>変更前と変更後の仕入在庫数の差を登録する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   調整数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AdjustCount
		{
			get{return _adjustCount;}
			set{_adjustCount = value;}
		}

		/// public propaty name  :  DtlNote
		/// <summary>明細備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DtlNote
		{
			get{return _dtlNote;}
			set{_dtlNote = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL商品コード名称（全角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（全角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  ListPriceFl
		/// <summary>定価（浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceFl
		{
			get{return _listPriceFl;}
			set{_listPriceFl = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>オープン価格区分プロパティ</summary>
		/// <value>0:通常／1:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  StockPriceTaxExc
		/// <summary>仕入金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPriceTaxExc
		{
			get{return _stockPriceTaxExc;}
			set{_stockPriceTaxExc = value;}
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

		/// public propaty name  :  BLGoodsName
		/// <summary>BL商品コード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }


		/// <summary>
		/// 在庫調整明細データコンストラクタ
		/// </summary>
		/// <returns>StockAdjustDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjustDtl()
		{
		}

		/// <summary>
		/// 在庫調整明細データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
		/// <param name="stockAdjustRowNo">在庫調整行番号</param>
		/// <param name="supplierFormalSrc">仕入形式（元）(0:仕入,1:入荷,2:発注)</param>
		/// <param name="stockSlipDtlNumSrc">仕入明細通番（元）(計上時の元データ明細通番をセット)</param>
		/// <param name="acPaySlipCd">受払元伝票区分(10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸)</param>
		/// <param name="acPayTransCd">受払元取引区分(10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消)</param>
		/// <param name="adjustDate">調整日付</param>
		/// <param name="inputDay">入力日付</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="stockUnitPriceFl">仕入単価（税抜,浮動）(在庫調整入力、棚卸過不足更新の単価変更時にセット)</param>
		/// <param name="bfStockUnitPriceFl">変更前仕入単価（浮動）</param>
		/// <param name="adjustCount">調整数(変更前と変更後の仕入在庫数の差を登録する。)</param>
		/// <param name="dtlNote">明細備考</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="listPriceFl">定価（浮動）</param>
		/// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
		/// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
		/// <returns>StockAdjustDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjustDtl(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 stockAdjustSlipNo,Int32 stockAdjustRowNo,Int32 supplierFormalSrc,Int64 stockSlipDtlNumSrc,Int32 acPaySlipCd,Int32 acPayTransCd,DateTime adjustDate,DateTime inputDay,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,Double stockUnitPriceFl,Double bfStockUnitPriceFl,Double adjustCount,string dtlNote,string warehouseCode,string warehouseName,Int32 bLGoodsCode,string bLGoodsFullName,string warehouseShelfNo,Double listPriceFl,Int32 openPriceDiv,Int64 stockPriceTaxExc,string enterpriseName,string updEmployeeName,string bLGoodsName, Int32 supplierCd, String supplierSnm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode = sectionCode;
			this._stockAdjustSlipNo = stockAdjustSlipNo;
			this._stockAdjustRowNo = stockAdjustRowNo;
			this._supplierFormalSrc = supplierFormalSrc;
			this._stockSlipDtlNumSrc = stockSlipDtlNumSrc;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this.AdjustDate = adjustDate;
			this.InputDay = inputDay;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this._bfStockUnitPriceFl = bfStockUnitPriceFl;
			this._adjustCount = adjustCount;
			this._dtlNote = dtlNote;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._listPriceFl = listPriceFl;
			this._openPriceDiv = openPriceDiv;
			this._stockPriceTaxExc = stockPriceTaxExc;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
		}

		/// <summary>
		/// 在庫調整明細データ複製処理
		/// </summary>
		/// <returns>StockAdjustDtlクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockAdjustDtlクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAdjustDtl Clone()
		{
			return new StockAdjustDtl(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._stockAdjustSlipNo,this._stockAdjustRowNo,this._supplierFormalSrc,this._stockSlipDtlNumSrc,this._acPaySlipCd,this._acPayTransCd,this._adjustDate,this._inputDay,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._stockUnitPriceFl,this._bfStockUnitPriceFl,this._adjustCount,this._dtlNote,this._warehouseCode,this._warehouseName,this._bLGoodsCode,this._bLGoodsFullName,this._warehouseShelfNo,this._listPriceFl,this._openPriceDiv,this._stockPriceTaxExc,this._enterpriseName,this._updEmployeeName,this._bLGoodsName, this._supplierCd, this._supplierSnm);
		}

		/// <summary>
		/// 在庫調整明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAdjustDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockAdjustDtl target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.StockAdjustSlipNo == target.StockAdjustSlipNo)
				 && (this.StockAdjustRowNo == target.StockAdjustRowNo)
				 && (this.SupplierFormalSrc == target.SupplierFormalSrc)
				 && (this.StockSlipDtlNumSrc == target.StockSlipDtlNumSrc)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AdjustDate == target.AdjustDate)
				 && (this.InputDay == target.InputDay)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
				 && (this.AdjustCount == target.AdjustCount)
				 && (this.DtlNote == target.DtlNote)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.ListPriceFl == target.ListPriceFl)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 );
		}

		/// <summary>
		/// 在庫調整明細データ比較処理
		/// </summary>
		/// <param name="stockAdjustDtl1">
		///                    比較するStockAdjustDtlクラスのインスタンス
		/// </param>
		/// <param name="stockAdjustDtl2">比較するStockAdjustDtlクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockAdjustDtl stockAdjustDtl1, StockAdjustDtl stockAdjustDtl2)
		{
			return ((stockAdjustDtl1.CreateDateTime == stockAdjustDtl2.CreateDateTime)
				 && (stockAdjustDtl1.UpdateDateTime == stockAdjustDtl2.UpdateDateTime)
				 && (stockAdjustDtl1.EnterpriseCode == stockAdjustDtl2.EnterpriseCode)
				 && (stockAdjustDtl1.FileHeaderGuid == stockAdjustDtl2.FileHeaderGuid)
				 && (stockAdjustDtl1.UpdEmployeeCode == stockAdjustDtl2.UpdEmployeeCode)
				 && (stockAdjustDtl1.UpdAssemblyId1 == stockAdjustDtl2.UpdAssemblyId1)
				 && (stockAdjustDtl1.UpdAssemblyId2 == stockAdjustDtl2.UpdAssemblyId2)
				 && (stockAdjustDtl1.LogicalDeleteCode == stockAdjustDtl2.LogicalDeleteCode)
				 && (stockAdjustDtl1.SectionCode == stockAdjustDtl2.SectionCode)
				 && (stockAdjustDtl1.StockAdjustSlipNo == stockAdjustDtl2.StockAdjustSlipNo)
				 && (stockAdjustDtl1.StockAdjustRowNo == stockAdjustDtl2.StockAdjustRowNo)
				 && (stockAdjustDtl1.SupplierFormalSrc == stockAdjustDtl2.SupplierFormalSrc)
				 && (stockAdjustDtl1.StockSlipDtlNumSrc == stockAdjustDtl2.StockSlipDtlNumSrc)
				 && (stockAdjustDtl1.AcPaySlipCd == stockAdjustDtl2.AcPaySlipCd)
				 && (stockAdjustDtl1.AcPayTransCd == stockAdjustDtl2.AcPayTransCd)
				 && (stockAdjustDtl1.AdjustDate == stockAdjustDtl2.AdjustDate)
				 && (stockAdjustDtl1.InputDay == stockAdjustDtl2.InputDay)
				 && (stockAdjustDtl1.GoodsMakerCd == stockAdjustDtl2.GoodsMakerCd)
				 && (stockAdjustDtl1.MakerName == stockAdjustDtl2.MakerName)
				 && (stockAdjustDtl1.GoodsNo == stockAdjustDtl2.GoodsNo)
				 && (stockAdjustDtl1.GoodsName == stockAdjustDtl2.GoodsName)
				 && (stockAdjustDtl1.StockUnitPriceFl == stockAdjustDtl2.StockUnitPriceFl)
				 && (stockAdjustDtl1.BfStockUnitPriceFl == stockAdjustDtl2.BfStockUnitPriceFl)
				 && (stockAdjustDtl1.AdjustCount == stockAdjustDtl2.AdjustCount)
				 && (stockAdjustDtl1.DtlNote == stockAdjustDtl2.DtlNote)
				 && (stockAdjustDtl1.WarehouseCode == stockAdjustDtl2.WarehouseCode)
				 && (stockAdjustDtl1.WarehouseName == stockAdjustDtl2.WarehouseName)
				 && (stockAdjustDtl1.BLGoodsCode == stockAdjustDtl2.BLGoodsCode)
				 && (stockAdjustDtl1.BLGoodsFullName == stockAdjustDtl2.BLGoodsFullName)
				 && (stockAdjustDtl1.WarehouseShelfNo == stockAdjustDtl2.WarehouseShelfNo)
				 && (stockAdjustDtl1.ListPriceFl == stockAdjustDtl2.ListPriceFl)
				 && (stockAdjustDtl1.OpenPriceDiv == stockAdjustDtl2.OpenPriceDiv)
				 && (stockAdjustDtl1.StockPriceTaxExc == stockAdjustDtl2.StockPriceTaxExc)
				 && (stockAdjustDtl1.EnterpriseName == stockAdjustDtl2.EnterpriseName)
				 && (stockAdjustDtl1.UpdEmployeeName == stockAdjustDtl2.UpdEmployeeName)
                 && (stockAdjustDtl1.BLGoodsName == stockAdjustDtl2.BLGoodsName)
                 && (stockAdjustDtl1.SupplierCd == stockAdjustDtl2.SupplierCd)
                 && (stockAdjustDtl1.SupplierSnm == stockAdjustDtl2.SupplierSnm)
                 );
		}
		/// <summary>
		/// 在庫調整明細データ比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAdjustDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockAdjustDtl target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.StockAdjustSlipNo != target.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(this.StockAdjustRowNo != target.StockAdjustRowNo)resList.Add("StockAdjustRowNo");
			if(this.SupplierFormalSrc != target.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(this.StockSlipDtlNumSrc != target.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AdjustDate != target.AdjustDate)resList.Add("AdjustDate");
			if(this.InputDay != target.InputDay)resList.Add("InputDay");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.BfStockUnitPriceFl != target.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(this.AdjustCount != target.AdjustCount)resList.Add("AdjustCount");
			if(this.DtlNote != target.DtlNote)resList.Add("DtlNote");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.ListPriceFl != target.ListPriceFl)resList.Add("ListPriceFl");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.StockPriceTaxExc != target.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");

			return resList;
		}

		/// <summary>
		/// 在庫調整明細データ比較処理
		/// </summary>
		/// <param name="stockAdjustDtl1">比較するStockAdjustDtlクラスのインスタンス</param>
		/// <param name="stockAdjustDtl2">比較するStockAdjustDtlクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAdjustDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockAdjustDtl stockAdjustDtl1, StockAdjustDtl stockAdjustDtl2)
		{
			ArrayList resList = new ArrayList();
			if(stockAdjustDtl1.CreateDateTime != stockAdjustDtl2.CreateDateTime)resList.Add("CreateDateTime");
			if(stockAdjustDtl1.UpdateDateTime != stockAdjustDtl2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(stockAdjustDtl1.EnterpriseCode != stockAdjustDtl2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockAdjustDtl1.FileHeaderGuid != stockAdjustDtl2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(stockAdjustDtl1.UpdEmployeeCode != stockAdjustDtl2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(stockAdjustDtl1.UpdAssemblyId1 != stockAdjustDtl2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(stockAdjustDtl1.UpdAssemblyId2 != stockAdjustDtl2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(stockAdjustDtl1.LogicalDeleteCode != stockAdjustDtl2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(stockAdjustDtl1.SectionCode != stockAdjustDtl2.SectionCode)resList.Add("SectionCode");
			if(stockAdjustDtl1.StockAdjustSlipNo != stockAdjustDtl2.StockAdjustSlipNo)resList.Add("StockAdjustSlipNo");
			if(stockAdjustDtl1.StockAdjustRowNo != stockAdjustDtl2.StockAdjustRowNo)resList.Add("StockAdjustRowNo");
			if(stockAdjustDtl1.SupplierFormalSrc != stockAdjustDtl2.SupplierFormalSrc)resList.Add("SupplierFormalSrc");
			if(stockAdjustDtl1.StockSlipDtlNumSrc != stockAdjustDtl2.StockSlipDtlNumSrc)resList.Add("StockSlipDtlNumSrc");
			if(stockAdjustDtl1.AcPaySlipCd != stockAdjustDtl2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAdjustDtl1.AcPayTransCd != stockAdjustDtl2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAdjustDtl1.AdjustDate != stockAdjustDtl2.AdjustDate)resList.Add("AdjustDate");
			if(stockAdjustDtl1.InputDay != stockAdjustDtl2.InputDay)resList.Add("InputDay");
			if(stockAdjustDtl1.GoodsMakerCd != stockAdjustDtl2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockAdjustDtl1.MakerName != stockAdjustDtl2.MakerName)resList.Add("MakerName");
			if(stockAdjustDtl1.GoodsNo != stockAdjustDtl2.GoodsNo)resList.Add("GoodsNo");
			if(stockAdjustDtl1.GoodsName != stockAdjustDtl2.GoodsName)resList.Add("GoodsName");
			if(stockAdjustDtl1.StockUnitPriceFl != stockAdjustDtl2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockAdjustDtl1.BfStockUnitPriceFl != stockAdjustDtl2.BfStockUnitPriceFl)resList.Add("BfStockUnitPriceFl");
			if(stockAdjustDtl1.AdjustCount != stockAdjustDtl2.AdjustCount)resList.Add("AdjustCount");
			if(stockAdjustDtl1.DtlNote != stockAdjustDtl2.DtlNote)resList.Add("DtlNote");
			if(stockAdjustDtl1.WarehouseCode != stockAdjustDtl2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockAdjustDtl1.WarehouseName != stockAdjustDtl2.WarehouseName)resList.Add("WarehouseName");
			if(stockAdjustDtl1.BLGoodsCode != stockAdjustDtl2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockAdjustDtl1.BLGoodsFullName != stockAdjustDtl2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockAdjustDtl1.WarehouseShelfNo != stockAdjustDtl2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockAdjustDtl1.ListPriceFl != stockAdjustDtl2.ListPriceFl)resList.Add("ListPriceFl");
			if(stockAdjustDtl1.OpenPriceDiv != stockAdjustDtl2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockAdjustDtl1.StockPriceTaxExc != stockAdjustDtl2.StockPriceTaxExc)resList.Add("StockPriceTaxExc");
			if(stockAdjustDtl1.EnterpriseName != stockAdjustDtl2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockAdjustDtl1.UpdEmployeeName != stockAdjustDtl2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            if (stockAdjustDtl1.BLGoodsName != stockAdjustDtl2.BLGoodsName) resList.Add("BLGoodsName");
            if (stockAdjustDtl1.SupplierCd != stockAdjustDtl2.SupplierCd) resList.Add("SupplierCd");
            if (stockAdjustDtl1.SupplierSnm != stockAdjustDtl2.SupplierSnm) resList.Add("SupplierSnm");

			return resList;
		}
	}
}
