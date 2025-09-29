using System;
using System.Collections;
using Broadleaf.Library.Globarization;
using System.Xml.Serialization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TspSdRvDt
	/// <summary>
	///                      TSP送受信データ
	/// </summary>
	/// <remarks>
	/// <br>note             :   TSP送受信データヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2020/12/01</br>
	/// <br>Genarated Date   :   2020/12/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    [XmlInclude(typeof(TspSdRvDt))]
    public class TspSdRvDt
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

		/// <summary>PM企業コード</summary>
		/// <remarks>部品商の企業コード</remarks>
		private string _pmEnterpriseCode = "";

		/// <summary>TSP通信番号</summary>
		/// <remarks>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</remarks>
		private Int32 _tspCommNo;

		/// <summary>TSP通信回数</summary>
		/// <remarks>PM側が１発注に対して回答を行う回数</remarks>
		private Int32 _tspCommCount;

		/// <summary>発注内容区分</summary>
		/// <remarks>1:通常発注,2:価格問い合わせ,3:在庫問い合わせ</remarks>
		private Int32 _orderContentsDivCd;

		/// <summary>指示書番号（文字列）</summary>
		/// <remarks>文字型</remarks>
		private string _instSlipNoStr = "";

		/// <summary>受注番号</summary>
		/// <remarks>発注側(SF・BK)の受注番号</remarks>
		private Int32 _acceptAnOrderNo;

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販　発注側のデータ入力システム</remarks>
		private Int32 _dataInputSystem;

		/// <summary>伝票番号</summary>
		private string _slipNo = "";

		/// <summary>伝票種別</summary>
		/// <remarks>10:見積,20:指示,21:承り書,30:納品,40:加修</remarks>
		private Int32 _slipKind;

		/// <summary>通信状態区分</summary>
		/// <remarks>0:未処理,1:送信済み,2:処理済,9:エラー</remarks>
		private Int32 _commConditionDivCd;

		/// <summary>陸運事務所番号</summary>
		private Int32 _numberPlate1Code;

		/// <summary>陸運事務局名称</summary>
		private string _numberPlate1Name = "";

		/// <summary>車両登録番号（種別）</summary>
		private string _numberPlate2 = "";

		/// <summary>車両登録番号（カナ）</summary>
		private string _numberPlate3 = "";

		/// <summary>車両登録番号（プレート番号）</summary>
		private Int32 _numberPlate4;

		/// <summary>型式指定番号</summary>
		private Int32 _modelDesignationNo;

		/// <summary>類別番号</summary>
		private Int32 _categoryNo;

		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種コード</summary>
		/// <remarks>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>車種名</summary>
		private string _modelName = "";

		/// <summary>車検証型式</summary>
		private string _carInspectCertModel = "";

		/// <summary>型式（フル型）</summary>
		/// <remarks>フル型式(44桁用)</remarks>
		private string _fullModel = "";

		/// <summary>車台番号</summary>
		private string _frameNo = "";

		/// <summary>車台型式</summary>
		private string _frameModel = "";

		/// <summary>シャシーNo</summary>
		private string _chassisNo = "";

		/// <summary>車両固有番号</summary>
		/// <remarks>ユニークな固定番号</remarks>
		private Int32 _carProperNo;

		/// <summary>生産年式（NUMタイプ）</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _produceTypeOfYearNum;

		/// <summary>発注日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _salesOrderDate;

		/// <summary>発注者従業員コード</summary>
		/// <remarks>発注した従業員コード</remarks>
		private string _salesOrderEmployeeCd = "";

		/// <summary>発注者従業員名称</summary>
		/// <remarks>発注した従業員名称</remarks>
		private string _salesOrderEmployeeNm = "";

		/// <summary>発注時コメント</summary>
		/// <remarks>発注する際に入力するコメント</remarks>
		private string _salesOrderComment = "";

		/// <summary>発注側システムバージョン区分</summary>
		/// <remarks>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</remarks>
		private Int32 _orderSideSystemVerCd;

		/// <summary>TSP回答データ管理番号</summary>
		/// <remarks>発注時、番号採番</remarks>
		private Int32 _tspAnswerDataMngNo;

		/// <summary>TSP伝票タイプ</summary>
		/// <remarks>0:オンライン発注分,1:電話発注分</remarks>
		private Int32 _tspSlipType;

		/// <summary>受注日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _acceptAnOrderDate;

		/// <summary>PM伝票番号</summary>
		private Int32 _pmSlipNo;

		/// <summary>受注者名</summary>
		/// <remarks>受注した従業員名称</remarks>
		private string _acceptAnOrderNm = "";

		/// <summary>TSP伝票合計金額</summary>
		private Int64 _tspTotalSlipPrice;

		/// <summary>PMコメント</summary>
		private string _pmComment = "";

		/// <summary>PMバージョン</summary>
		private string _pmVersion = "";

		/// <summary>PM送信日</summary>
		/// <remarks>PM側が送信した日付 YYYYMMDD</remarks>
		private DateTime _pmSendDate;

		/// <summary>PM伝票種別</summary>
		/// <remarks>10:売上、20:返品</remarks>
		private Int32 _pmSlipKind;

		/// <summary>PM元黒伝票番号</summary>
		/// <remarks>赤伝・返品の場合に元の黒伝票番号を設定</remarks>
		private Int32 _pmOriginalSlipNo;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>データ入力システム名称</summary>
		/// <remarks>共通,整備,鈑金,車販</remarks>
		private string _dataInputSystemName = "";


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

		/// public propaty name  :  PmEnterpriseCode
		/// <summary>PM企業コードプロパティ</summary>
		/// <value>部品商の企業コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmEnterpriseCode
		{
			get{return _pmEnterpriseCode;}
			set{_pmEnterpriseCode = value;}
		}

		/// public propaty name  :  TspCommNo
		/// <summary>TSP通信番号プロパティ</summary>
		/// <value>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP通信番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspCommNo
		{
			get{return _tspCommNo;}
			set{_tspCommNo = value;}
		}

		/// public propaty name  :  TspCommCount
		/// <summary>TSP通信回数プロパティ</summary>
		/// <value>PM側が１発注に対して回答を行う回数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP通信回数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspCommCount
		{
			get{return _tspCommCount;}
			set{_tspCommCount = value;}
		}

		/// public propaty name  :  OrderContentsDivCd
		/// <summary>発注内容区分プロパティ</summary>
		/// <value>1:通常発注,2:価格問い合わせ,3:在庫問い合わせ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注内容区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderContentsDivCd
		{
			get{return _orderContentsDivCd;}
			set{_orderContentsDivCd = value;}
		}

		/// public propaty name  :  InstSlipNoStr
		/// <summary>指示書番号（文字列）プロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   指示書番号（文字列）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InstSlipNoStr
		{
			get{return _instSlipNoStr;}
			set{_instSlipNoStr = value;}
		}

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>受注番号プロパティ</summary>
		/// <value>発注側(SF・BK)の受注番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcceptAnOrderNo
		{
			get{return _acceptAnOrderNo;}
			set{_acceptAnOrderNo = value;}
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>データ入力システムプロパティ</summary>
		/// <value>0:共通,1:整備,2:鈑金,3:車販　発注側のデータ入力システム</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   データ入力システムプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get{return _dataInputSystem;}
			set{_dataInputSystem = value;}
		}

		/// public propaty name  :  SlipNo
		/// <summary>伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNo
		{
			get{return _slipNo;}
			set{_slipNo = value;}
		}

		/// public propaty name  :  SlipKind
		/// <summary>伝票種別プロパティ</summary>
		/// <value>10:見積,20:指示,21:承り書,30:納品,40:加修</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipKind
		{
			get{return _slipKind;}
			set{_slipKind = value;}
		}

		/// public propaty name  :  CommConditionDivCd
		/// <summary>通信状態区分プロパティ</summary>
		/// <value>0:未処理,1:送信済み,2:処理済,9:エラー</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   通信状態区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CommConditionDivCd
		{
			get{return _commConditionDivCd;}
			set{_commConditionDivCd = value;}
		}

		/// public propaty name  :  NumberPlate1Code
		/// <summary>陸運事務所番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務所番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get{return _numberPlate1Code;}
			set{_numberPlate1Code = value;}
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>陸運事務局名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   陸運事務局名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get{return _numberPlate1Name;}
			set{_numberPlate1Name = value;}
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>車両登録番号（種別）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（種別）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate2
		{
			get{return _numberPlate2;}
			set{_numberPlate2 = value;}
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>車両登録番号（カナ）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（カナ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string NumberPlate3
		{
			get{return _numberPlate3;}
			set{_numberPlate3 = value;}
		}

		/// public propaty name  :  NumberPlate4
		/// <summary>車両登録番号（プレート番号）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get{return _numberPlate4;}
			set{_numberPlate4 = value;}
		}

		/// public propaty name  :  ModelDesignationNo
		/// <summary>型式指定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式指定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get{return _modelDesignationNo;}
			set{_modelDesignationNo = value;}
		}

		/// public propaty name  :  CategoryNo
		/// <summary>類別番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   類別番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get{return _categoryNo;}
			set{_categoryNo = value;}
		}

		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get{return _makerCode;}
			set{_makerCode = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get{return _modelCode;}
			set{_modelCode = value;}
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get{return _modelSubCode;}
			set{_modelSubCode = value;}
		}

		/// public propaty name  :  ModelName
		/// <summary>車種名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ModelName
		{
			get{return _modelName;}
			set{_modelName = value;}
		}

		/// public propaty name  :  CarInspectCertModel
		/// <summary>車検証型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車検証型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get{return _carInspectCertModel;}
			set{_carInspectCertModel = value;}
		}

		/// public propaty name  :  FullModel
		/// <summary>型式（フル型）プロパティ</summary>
		/// <value>フル型式(44桁用)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式（フル型）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FullModel
		{
			get{return _fullModel;}
			set{_fullModel = value;}
		}

		/// public propaty name  :  FrameNo
		/// <summary>車台番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameNo
		{
			get{return _frameNo;}
			set{_frameNo = value;}
		}

		/// public propaty name  :  FrameModel
		/// <summary>車台型式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車台型式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrameModel
		{
			get{return _frameModel;}
			set{_frameModel = value;}
		}

		/// public propaty name  :  ChassisNo
		/// <summary>シャシーNoプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   シャシーNoプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ChassisNo
		{
			get{return _chassisNo;}
			set{_chassisNo = value;}
		}

		/// public propaty name  :  CarProperNo
		/// <summary>車両固有番号プロパティ</summary>
		/// <value>ユニークな固定番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両固有番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarProperNo
		{
			get{return _carProperNo;}
			set{_carProperNo = value;}
		}

		/// public propaty name  :  ProduceTypeOfYearNum
		/// <summary>生産年式（NUMタイプ）プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   生産年式（NUMタイプ）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearNum
		{
			get{return _produceTypeOfYearNum;}
			set{_produceTypeOfYearNum = value;}
		}

		/// public propaty name  :  SalesOrderDate
		/// <summary>発注日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime SalesOrderDate
		{
			get{return _salesOrderDate;}
			set{_salesOrderDate = value;}
		}

		/// public propaty name  :  SalesOrderEmployeeCd
		/// <summary>発注者従業員コードプロパティ</summary>
		/// <value>発注した従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注者従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesOrderEmployeeCd
		{
			get{return _salesOrderEmployeeCd;}
			set{_salesOrderEmployeeCd = value;}
		}

		/// public propaty name  :  SalesOrderEmployeeNm
		/// <summary>発注者従業員名称プロパティ</summary>
		/// <value>発注した従業員名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注者従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesOrderEmployeeNm
		{
			get{return _salesOrderEmployeeNm;}
			set{_salesOrderEmployeeNm = value;}
		}

		/// public propaty name  :  SalesOrderComment
		/// <summary>発注時コメントプロパティ</summary>
		/// <value>発注する際に入力するコメント</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注時コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesOrderComment
		{
			get{return _salesOrderComment;}
			set{_salesOrderComment = value;}
		}

		/// public propaty name  :  OrderSideSystemVerCd
		/// <summary>発注側システムバージョン区分プロパティ</summary>
		/// <value>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注側システムバージョン区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderSideSystemVerCd
		{
			get{return _orderSideSystemVerCd;}
			set{_orderSideSystemVerCd = value;}
		}

		/// public propaty name  :  TspAnswerDataMngNo
		/// <summary>TSP回答データ管理番号プロパティ</summary>
		/// <value>発注時、番号採番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP回答データ管理番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspAnswerDataMngNo
		{
			get{return _tspAnswerDataMngNo;}
			set{_tspAnswerDataMngNo = value;}
		}

		/// public propaty name  :  TspSlipType
		/// <summary>TSP伝票タイププロパティ</summary>
		/// <value>0:オンライン発注分,1:電話発注分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP伝票タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TspSlipType
		{
			get{return _tspSlipType;}
			set{_tspSlipType = value;}
		}

		/// public propaty name  :  AcceptAnOrderDate
		/// <summary>受注日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AcceptAnOrderDate
		{
			get{return _acceptAnOrderDate;}
			set{_acceptAnOrderDate = value;}
		}

		/// public propaty name  :  PmSlipNo
		/// <summary>PM伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PmSlipNo
		{
			get{return _pmSlipNo;}
			set{_pmSlipNo = value;}
		}

		/// public propaty name  :  AcceptAnOrderNm
		/// <summary>受注者名プロパティ</summary>
		/// <value>受注した従業員名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注者名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcceptAnOrderNm
		{
			get{return _acceptAnOrderNm;}
			set{_acceptAnOrderNm = value;}
		}

		/// public propaty name  :  TspTotalSlipPrice
		/// <summary>TSP伝票合計金額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   TSP伝票合計金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 TspTotalSlipPrice
		{
			get{return _tspTotalSlipPrice;}
			set{_tspTotalSlipPrice = value;}
		}

		/// public propaty name  :  PmComment
		/// <summary>PMコメントプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PMコメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmComment
		{
			get{return _pmComment;}
			set{_pmComment = value;}
		}

		/// public propaty name  :  PmVersion
		/// <summary>PMバージョンプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PMバージョンプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmVersion
		{
			get{return _pmVersion;}
			set{_pmVersion = value;}
		}

		/// public propaty name  :  PmSendDate
		/// <summary>PM送信日プロパティ</summary>
		/// <value>PM側が送信した日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM送信日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PmSendDate
		{
			get{return _pmSendDate;}
			set{_pmSendDate = value;}
		}

		/// public propaty name  :  PmSlipKind
		/// <summary>PM伝票種別プロパティ</summary>
		/// <value>10:売上、20:返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM伝票種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PmSlipKind
		{
			get{return _pmSlipKind;}
			set{_pmSlipKind = value;}
		}
        
		/// public propaty name  :  PmOriginalSlipNo
		/// <summary>PM元黒伝票番号プロパティ</summary>
		/// <value>赤伝・返品の場合に元の黒伝票番号を設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM元黒伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PmOriginalSlipNo
		{
			get{return _pmOriginalSlipNo;}
			set{_pmOriginalSlipNo = value;}
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

		/// public propaty name  :  DataInputSystemName
		/// <summary>データ入力システム名称プロパティ</summary>
		/// <value>共通,整備,鈑金,車販</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   データ入力システム名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DataInputSystemName
		{
			get{return _dataInputSystemName;}
			set{_dataInputSystemName = value;}
		}

		/// <summary>
		/// TSP送受信データコンストラクタ
		/// </summary>
		/// <returns>TspSdRvDtクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDt()
		{

		}

		/// <summary>
		/// TSP送受信データコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="pmEnterpriseCode">PM企業コード(部品商の企業コード)</param>
		/// <param name="tspCommNo">TSP通信番号(１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番))</param>
		/// <param name="tspCommCount">TSP通信回数(PM側が１発注に対して回答を行う回数)</param>
		/// <param name="orderContentsDivCd">発注内容区分(1:通常発注,2:価格問い合わせ,3:在庫問い合わせ)</param>
		/// <param name="instSlipNoStr">指示書番号（文字列）(文字型)</param>
		/// <param name="acceptAnOrderNo">受注番号(発注側(SF・BK)の受注番号)</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販　発注側のデータ入力システム)</param>
		/// <param name="slipNo">伝票番号</param>
		/// <param name="slipKind">伝票種別(10:見積,20:指示,21:承り書,30:納品,40:加修)</param>
		/// <param name="commConditionDivCd">通信状態区分(0:未処理,1:送信済み,2:処理済,9:エラー)</param>
		/// <param name="numberPlate1Code">陸運事務所番号</param>
		/// <param name="numberPlate1Name">陸運事務局名称</param>
		/// <param name="numberPlate2">車両登録番号（種別）</param>
		/// <param name="numberPlate3">車両登録番号（カナ）</param>
		/// <param name="numberPlate4">車両登録番号（プレート番号）</param>
		/// <param name="modelDesignationNo">型式指定番号</param>
		/// <param name="categoryNo">類別番号</param>
		/// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="modelCode">車種コード(車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録)</param>
		/// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
		/// <param name="modelName">車種名</param>
		/// <param name="carInspectCertModel">車検証型式</param>
		/// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
		/// <param name="frameNo">車台番号</param>
		/// <param name="frameModel">車台型式</param>
		/// <param name="chassisNo">シャシーNo</param>
		/// <param name="carProperNo">車両固有番号(ユニークな固定番号)</param>
		/// <param name="produceTypeOfYearNum">生産年式（NUMタイプ）(YYYYMM)</param>
		/// <param name="salesOrderDate">発注日(YYYYMMDD)</param>
		/// <param name="salesOrderEmployeeCd">発注者従業員コード(発注した従業員コード)</param>
		/// <param name="salesOrderEmployeeNm">発注者従業員名称(発注した従業員名称)</param>
		/// <param name="salesOrderComment">発注時コメント(発注する際に入力するコメント)</param>
		/// <param name="orderSideSystemVerCd">発注側システムバージョン区分(0:SF.NS or BK.NS,1:Pegasus,2:Phoenix)</param>
		/// <param name="tspAnswerDataMngNo">TSP回答データ管理番号(発注時、番号採番)</param>
		/// <param name="tspSlipType">TSP伝票タイプ(0:オンライン発注分,1:電話発注分)</param>
		/// <param name="acceptAnOrderDate">受注日(YYYYMMDD)</param>
		/// <param name="pmSlipNo">PM伝票番号</param>
		/// <param name="acceptAnOrderNm">受注者名(受注した従業員名称)</param>
		/// <param name="tspTotalSlipPrice">TSP伝票合計金額</param>
		/// <param name="pmComment">PMコメント</param>
		/// <param name="pmVersion">PMバージョン</param>
		/// <param name="pmSendDate">PM送信日(PM側が送信した日付 YYYYMMDD)</param>
		/// <param name="pmSlipKind">PM伝票種別(10:売上、20:返品)</param>
		/// <param name="pmOriginalSlipNo">PM元黒伝票番号(赤伝・返品の場合に元の黒伝票番号を設定)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="dataInputSystemName">データ入力システム名称(共通,整備,鈑金,車販)</param>
		/// <returns>TspSdRvDtクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string pmEnterpriseCode,Int32 tspCommNo,Int32 tspCommCount,Int32 orderContentsDivCd,string instSlipNoStr,Int32 acceptAnOrderNo,Int32 dataInputSystem,string slipNo,Int32 slipKind,Int32 commConditionDivCd,Int32 numberPlate1Code,string numberPlate1Name,string numberPlate2,string numberPlate3,Int32 numberPlate4,Int32 modelDesignationNo,Int32 categoryNo,Int32 makerCode,Int32 modelCode,Int32 modelSubCode,string modelName,string carInspectCertModel,string fullModel,string frameNo,string frameModel,string chassisNo,Int32 carProperNo,Int32 produceTypeOfYearNum,DateTime salesOrderDate,string salesOrderEmployeeCd,string salesOrderEmployeeNm,string salesOrderComment,Int32 orderSideSystemVerCd,Int32 tspAnswerDataMngNo,Int32 tspSlipType,DateTime acceptAnOrderDate,Int32 pmSlipNo,string acceptAnOrderNm,Int64 tspTotalSlipPrice,string pmComment,string pmVersion,DateTime pmSendDate,Int32 pmSlipKind,Int32 pmOriginalSlipNo,string enterpriseName,string updEmployeeName,string dataInputSystemName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._pmEnterpriseCode = pmEnterpriseCode;
			this._tspCommNo = tspCommNo;
			this._tspCommCount = tspCommCount;
			this._orderContentsDivCd = orderContentsDivCd;
			this._instSlipNoStr = instSlipNoStr;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._dataInputSystem = dataInputSystem;
			this._slipNo = slipNo;
			this._slipKind = slipKind;
			this._commConditionDivCd = commConditionDivCd;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._modelDesignationNo = modelDesignationNo;
			this._categoryNo = categoryNo;
			this._makerCode = makerCode;
			this._modelCode = modelCode;
			this._modelSubCode = modelSubCode;
			this._modelName = modelName;
			this._carInspectCertModel = carInspectCertModel;
			this._fullModel = fullModel;
			this._frameNo = frameNo;
			this._frameModel = frameModel;
			this._chassisNo = chassisNo;
			this._carProperNo = carProperNo;
			this._produceTypeOfYearNum = produceTypeOfYearNum;
			this.SalesOrderDate = salesOrderDate;
			this._salesOrderEmployeeCd = salesOrderEmployeeCd;
			this._salesOrderEmployeeNm = salesOrderEmployeeNm;
			this._salesOrderComment = salesOrderComment;
			this._orderSideSystemVerCd = orderSideSystemVerCd;
			this._tspAnswerDataMngNo = tspAnswerDataMngNo;
			this._tspSlipType = tspSlipType;
			this.AcceptAnOrderDate = acceptAnOrderDate;
			this._pmSlipNo = pmSlipNo;
			this._acceptAnOrderNm = acceptAnOrderNm;
			this._tspTotalSlipPrice = tspTotalSlipPrice;
			this._pmComment = pmComment;
			this._pmVersion = pmVersion;
			this.PmSendDate = pmSendDate;
			this._pmSlipKind = pmSlipKind;
			this._pmOriginalSlipNo = pmOriginalSlipNo;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._dataInputSystemName = dataInputSystemName;

            return;

		}

		/// <summary>
		/// TSP送受信データ複製処理
		/// </summary>
		/// <returns>TspSdRvDtクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいTspSdRvDtクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public TspSdRvDt Clone()
		{
			return new TspSdRvDt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._pmEnterpriseCode,this._tspCommNo,this._tspCommCount,this._orderContentsDivCd,this._instSlipNoStr,this._acceptAnOrderNo,this._dataInputSystem,this._slipNo,this._slipKind,this._commConditionDivCd,this._numberPlate1Code,this._numberPlate1Name,this._numberPlate2,this._numberPlate3,this._numberPlate4,this._modelDesignationNo,this._categoryNo,this._makerCode,this._modelCode,this._modelSubCode,this._modelName,this._carInspectCertModel,this._fullModel,this._frameNo,this._frameModel,this._chassisNo,this._carProperNo,this._produceTypeOfYearNum,this._salesOrderDate,this._salesOrderEmployeeCd,this._salesOrderEmployeeNm,this._salesOrderComment,this._orderSideSystemVerCd,this._tspAnswerDataMngNo,this._tspSlipType,this._acceptAnOrderDate,this._pmSlipNo,this._acceptAnOrderNm,this._tspTotalSlipPrice,this._pmComment,this._pmVersion,this._pmSendDate,this._pmSlipKind,this._pmOriginalSlipNo,this._enterpriseName,this._updEmployeeName,this._dataInputSystemName);
		}

		/// <summary>
		/// TSP送受信データ比較処理
		/// </summary>
		/// <param name="target">比較対象のTspSdRvDtクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(TspSdRvDt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.PmEnterpriseCode == target.PmEnterpriseCode)
				 && (this.TspCommNo == target.TspCommNo)
				 && (this.TspCommCount == target.TspCommCount)
				 && (this.OrderContentsDivCd == target.OrderContentsDivCd)
				 && (this.InstSlipNoStr == target.InstSlipNoStr)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.SlipNo == target.SlipNo)
				 && (this.SlipKind == target.SlipKind)
				 && (this.CommConditionDivCd == target.CommConditionDivCd)
				 && (this.NumberPlate1Code == target.NumberPlate1Code)
				 && (this.NumberPlate1Name == target.NumberPlate1Name)
				 && (this.NumberPlate2 == target.NumberPlate2)
				 && (this.NumberPlate3 == target.NumberPlate3)
				 && (this.NumberPlate4 == target.NumberPlate4)
				 && (this.ModelDesignationNo == target.ModelDesignationNo)
				 && (this.CategoryNo == target.CategoryNo)
				 && (this.MakerCode == target.MakerCode)
				 && (this.ModelCode == target.ModelCode)
				 && (this.ModelSubCode == target.ModelSubCode)
				 && (this.ModelName == target.ModelName)
				 && (this.CarInspectCertModel == target.CarInspectCertModel)
				 && (this.FullModel == target.FullModel)
				 && (this.FrameNo == target.FrameNo)
				 && (this.FrameModel == target.FrameModel)
				 && (this.ChassisNo == target.ChassisNo)
				 && (this.CarProperNo == target.CarProperNo)
				 && (this.ProduceTypeOfYearNum == target.ProduceTypeOfYearNum)
				 && (this.SalesOrderDate == target.SalesOrderDate)
				 && (this.SalesOrderEmployeeCd == target.SalesOrderEmployeeCd)
				 && (this.SalesOrderEmployeeNm == target.SalesOrderEmployeeNm)
				 && (this.SalesOrderComment == target.SalesOrderComment)
				 && (this.OrderSideSystemVerCd == target.OrderSideSystemVerCd)
				 && (this.TspAnswerDataMngNo == target.TspAnswerDataMngNo)
				 && (this.TspSlipType == target.TspSlipType)
				 && (this.AcceptAnOrderDate == target.AcceptAnOrderDate)
				 && (this.PmSlipNo == target.PmSlipNo)
				 && (this.AcceptAnOrderNm == target.AcceptAnOrderNm)
				 && (this.TspTotalSlipPrice == target.TspTotalSlipPrice)
				 && (this.PmComment == target.PmComment)
				 && (this.PmVersion == target.PmVersion)
				 && (this.PmSendDate == target.PmSendDate)
				 && (this.PmSlipKind == target.PmSlipKind)
				 && (this.PmOriginalSlipNo == target.PmOriginalSlipNo)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.DataInputSystemName == target.DataInputSystemName));
		}

		/// <summary>
		/// TSP送受信データ比較処理
		/// </summary>
		/// <param name="tspSdRvDt1">
		///                    比較するTspSdRvDtクラスのインスタンス
		/// </param>
		/// <param name="tspSdRvDt2">比較するTspSdRvDtクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2)
		{
			return ((tspSdRvDt1.CreateDateTime == tspSdRvDt2.CreateDateTime)
				 && (tspSdRvDt1.UpdateDateTime == tspSdRvDt2.UpdateDateTime)
				 && (tspSdRvDt1.EnterpriseCode == tspSdRvDt2.EnterpriseCode)
				 && (tspSdRvDt1.FileHeaderGuid == tspSdRvDt2.FileHeaderGuid)
				 && (tspSdRvDt1.UpdEmployeeCode == tspSdRvDt2.UpdEmployeeCode)
				 && (tspSdRvDt1.UpdAssemblyId1 == tspSdRvDt2.UpdAssemblyId1)
				 && (tspSdRvDt1.UpdAssemblyId2 == tspSdRvDt2.UpdAssemblyId2)
				 && (tspSdRvDt1.LogicalDeleteCode == tspSdRvDt2.LogicalDeleteCode)
				 && (tspSdRvDt1.PmEnterpriseCode == tspSdRvDt2.PmEnterpriseCode)
				 && (tspSdRvDt1.TspCommNo == tspSdRvDt2.TspCommNo)
				 && (tspSdRvDt1.TspCommCount == tspSdRvDt2.TspCommCount)
				 && (tspSdRvDt1.OrderContentsDivCd == tspSdRvDt2.OrderContentsDivCd)
				 && (tspSdRvDt1.InstSlipNoStr == tspSdRvDt2.InstSlipNoStr)
				 && (tspSdRvDt1.AcceptAnOrderNo == tspSdRvDt2.AcceptAnOrderNo)
				 && (tspSdRvDt1.DataInputSystem == tspSdRvDt2.DataInputSystem)
				 && (tspSdRvDt1.SlipNo == tspSdRvDt2.SlipNo)
				 && (tspSdRvDt1.SlipKind == tspSdRvDt2.SlipKind)
				 && (tspSdRvDt1.CommConditionDivCd == tspSdRvDt2.CommConditionDivCd)
				 && (tspSdRvDt1.NumberPlate1Code == tspSdRvDt2.NumberPlate1Code)
				 && (tspSdRvDt1.NumberPlate1Name == tspSdRvDt2.NumberPlate1Name)
				 && (tspSdRvDt1.NumberPlate2 == tspSdRvDt2.NumberPlate2)
				 && (tspSdRvDt1.NumberPlate3 == tspSdRvDt2.NumberPlate3)
				 && (tspSdRvDt1.NumberPlate4 == tspSdRvDt2.NumberPlate4)
				 && (tspSdRvDt1.ModelDesignationNo == tspSdRvDt2.ModelDesignationNo)
				 && (tspSdRvDt1.CategoryNo == tspSdRvDt2.CategoryNo)
				 && (tspSdRvDt1.MakerCode == tspSdRvDt2.MakerCode)
				 && (tspSdRvDt1.ModelCode == tspSdRvDt2.ModelCode)
				 && (tspSdRvDt1.ModelSubCode == tspSdRvDt2.ModelSubCode)
				 && (tspSdRvDt1.ModelName == tspSdRvDt2.ModelName)
				 && (tspSdRvDt1.CarInspectCertModel == tspSdRvDt2.CarInspectCertModel)
				 && (tspSdRvDt1.FullModel == tspSdRvDt2.FullModel)
				 && (tspSdRvDt1.FrameNo == tspSdRvDt2.FrameNo)
				 && (tspSdRvDt1.FrameModel == tspSdRvDt2.FrameModel)
				 && (tspSdRvDt1.ChassisNo == tspSdRvDt2.ChassisNo)
				 && (tspSdRvDt1.CarProperNo == tspSdRvDt2.CarProperNo)
				 && (tspSdRvDt1.ProduceTypeOfYearNum == tspSdRvDt2.ProduceTypeOfYearNum)
				 && (tspSdRvDt1.SalesOrderDate == tspSdRvDt2.SalesOrderDate)
				 && (tspSdRvDt1.SalesOrderEmployeeCd == tspSdRvDt2.SalesOrderEmployeeCd)
				 && (tspSdRvDt1.SalesOrderEmployeeNm == tspSdRvDt2.SalesOrderEmployeeNm)
				 && (tspSdRvDt1.SalesOrderComment == tspSdRvDt2.SalesOrderComment)
				 && (tspSdRvDt1.OrderSideSystemVerCd == tspSdRvDt2.OrderSideSystemVerCd)
				 && (tspSdRvDt1.TspAnswerDataMngNo == tspSdRvDt2.TspAnswerDataMngNo)
				 && (tspSdRvDt1.TspSlipType == tspSdRvDt2.TspSlipType)
				 && (tspSdRvDt1.AcceptAnOrderDate == tspSdRvDt2.AcceptAnOrderDate)
				 && (tspSdRvDt1.PmSlipNo == tspSdRvDt2.PmSlipNo)
				 && (tspSdRvDt1.AcceptAnOrderNm == tspSdRvDt2.AcceptAnOrderNm)
				 && (tspSdRvDt1.TspTotalSlipPrice == tspSdRvDt2.TspTotalSlipPrice)
				 && (tspSdRvDt1.PmComment == tspSdRvDt2.PmComment)
				 && (tspSdRvDt1.PmVersion == tspSdRvDt2.PmVersion)
				 && (tspSdRvDt1.PmSendDate == tspSdRvDt2.PmSendDate)
				 && (tspSdRvDt1.PmSlipKind == tspSdRvDt2.PmSlipKind)
				 && (tspSdRvDt1.PmOriginalSlipNo == tspSdRvDt2.PmOriginalSlipNo)
				 && (tspSdRvDt1.EnterpriseName == tspSdRvDt2.EnterpriseName)
				 && (tspSdRvDt1.UpdEmployeeName == tspSdRvDt2.UpdEmployeeName)
				 && (tspSdRvDt1.DataInputSystemName == tspSdRvDt2.DataInputSystemName));
		}
		/// <summary>
		/// TSP送受信データ比較処理
		/// </summary>
		/// <param name="target">比較対象のTspSdRvDtクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(TspSdRvDt target)
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
			if(this.PmEnterpriseCode != target.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(this.TspCommNo != target.TspCommNo)resList.Add("TspCommNo");
			if(this.TspCommCount != target.TspCommCount)resList.Add("TspCommCount");
			if(this.OrderContentsDivCd != target.OrderContentsDivCd)resList.Add("OrderContentsDivCd");
			if(this.InstSlipNoStr != target.InstSlipNoStr)resList.Add("InstSlipNoStr");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.DataInputSystem != target.DataInputSystem)resList.Add("DataInputSystem");
			if(this.SlipNo != target.SlipNo)resList.Add("SlipNo");
			if(this.SlipKind != target.SlipKind)resList.Add("SlipKind");
			if(this.CommConditionDivCd != target.CommConditionDivCd)resList.Add("CommConditionDivCd");
			if(this.NumberPlate1Code != target.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(this.NumberPlate1Name != target.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(this.NumberPlate2 != target.NumberPlate2)resList.Add("NumberPlate2");
			if(this.NumberPlate3 != target.NumberPlate3)resList.Add("NumberPlate3");
			if(this.NumberPlate4 != target.NumberPlate4)resList.Add("NumberPlate4");
			if(this.ModelDesignationNo != target.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(this.CategoryNo != target.CategoryNo)resList.Add("CategoryNo");
			if(this.MakerCode != target.MakerCode)resList.Add("MakerCode");
			if(this.ModelCode != target.ModelCode)resList.Add("ModelCode");
			if(this.ModelSubCode != target.ModelSubCode)resList.Add("ModelSubCode");
			if(this.ModelName != target.ModelName)resList.Add("ModelName");
			if(this.CarInspectCertModel != target.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(this.FullModel != target.FullModel)resList.Add("FullModel");
			if(this.FrameNo != target.FrameNo)resList.Add("FrameNo");
			if(this.FrameModel != target.FrameModel)resList.Add("FrameModel");
			if(this.ChassisNo != target.ChassisNo)resList.Add("ChassisNo");
			if(this.CarProperNo != target.CarProperNo)resList.Add("CarProperNo");
			if(this.ProduceTypeOfYearNum != target.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(this.SalesOrderDate != target.SalesOrderDate)resList.Add("SalesOrderDate");
			if(this.SalesOrderEmployeeCd != target.SalesOrderEmployeeCd)resList.Add("SalesOrderEmployeeCd");
			if(this.SalesOrderEmployeeNm != target.SalesOrderEmployeeNm)resList.Add("SalesOrderEmployeeNm");
			if(this.SalesOrderComment != target.SalesOrderComment)resList.Add("SalesOrderComment");
			if(this.OrderSideSystemVerCd != target.OrderSideSystemVerCd)resList.Add("OrderSideSystemVerCd");
			if(this.TspAnswerDataMngNo != target.TspAnswerDataMngNo)resList.Add("TspAnswerDataMngNo");
			if(this.TspSlipType != target.TspSlipType)resList.Add("TspSlipType");
			if(this.AcceptAnOrderDate != target.AcceptAnOrderDate)resList.Add("AcceptAnOrderDate");
			if(this.PmSlipNo != target.PmSlipNo)resList.Add("PmSlipNo");
			if(this.AcceptAnOrderNm != target.AcceptAnOrderNm)resList.Add("AcceptAnOrderNm");
			if(this.TspTotalSlipPrice != target.TspTotalSlipPrice)resList.Add("TspTotalSlipPrice");
			if(this.PmComment != target.PmComment)resList.Add("PmComment");
			if(this.PmVersion != target.PmVersion)resList.Add("PmVersion");
			if(this.PmSendDate != target.PmSendDate)resList.Add("PmSendDate");
			if(this.PmSlipKind != target.PmSlipKind)resList.Add("PmSlipKind");
			if(this.PmOriginalSlipNo != target.PmOriginalSlipNo)resList.Add("PmOriginalSlipNo");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.DataInputSystemName != target.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}

		/// <summary>
		/// TSP送受信データ比較処理
		/// </summary>
		/// <param name="tspSdRvDt1">比較するTspSdRvDtクラスのインスタンス</param>
		/// <param name="tspSdRvDt2">比較するTspSdRvDtクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   TspSdRvDtクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(TspSdRvDt tspSdRvDt1, TspSdRvDt tspSdRvDt2)
		{
			ArrayList resList = new ArrayList();
			if(tspSdRvDt1.CreateDateTime != tspSdRvDt2.CreateDateTime)resList.Add("CreateDateTime");
			if(tspSdRvDt1.UpdateDateTime != tspSdRvDt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(tspSdRvDt1.EnterpriseCode != tspSdRvDt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(tspSdRvDt1.FileHeaderGuid != tspSdRvDt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(tspSdRvDt1.UpdEmployeeCode != tspSdRvDt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(tspSdRvDt1.UpdAssemblyId1 != tspSdRvDt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(tspSdRvDt1.UpdAssemblyId2 != tspSdRvDt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(tspSdRvDt1.LogicalDeleteCode != tspSdRvDt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(tspSdRvDt1.PmEnterpriseCode != tspSdRvDt2.PmEnterpriseCode)resList.Add("PmEnterpriseCode");
			if(tspSdRvDt1.TspCommNo != tspSdRvDt2.TspCommNo)resList.Add("TspCommNo");
			if(tspSdRvDt1.TspCommCount != tspSdRvDt2.TspCommCount)resList.Add("TspCommCount");
			if(tspSdRvDt1.OrderContentsDivCd != tspSdRvDt2.OrderContentsDivCd)resList.Add("OrderContentsDivCd");
			if(tspSdRvDt1.InstSlipNoStr != tspSdRvDt2.InstSlipNoStr)resList.Add("InstSlipNoStr");
			if(tspSdRvDt1.AcceptAnOrderNo != tspSdRvDt2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(tspSdRvDt1.DataInputSystem != tspSdRvDt2.DataInputSystem)resList.Add("DataInputSystem");
			if(tspSdRvDt1.SlipNo != tspSdRvDt2.SlipNo)resList.Add("SlipNo");
			if(tspSdRvDt1.SlipKind != tspSdRvDt2.SlipKind)resList.Add("SlipKind");
			if(tspSdRvDt1.CommConditionDivCd != tspSdRvDt2.CommConditionDivCd)resList.Add("CommConditionDivCd");
			if(tspSdRvDt1.NumberPlate1Code != tspSdRvDt2.NumberPlate1Code)resList.Add("NumberPlate1Code");
			if(tspSdRvDt1.NumberPlate1Name != tspSdRvDt2.NumberPlate1Name)resList.Add("NumberPlate1Name");
			if(tspSdRvDt1.NumberPlate2 != tspSdRvDt2.NumberPlate2)resList.Add("NumberPlate2");
			if(tspSdRvDt1.NumberPlate3 != tspSdRvDt2.NumberPlate3)resList.Add("NumberPlate3");
			if(tspSdRvDt1.NumberPlate4 != tspSdRvDt2.NumberPlate4)resList.Add("NumberPlate4");
			if(tspSdRvDt1.ModelDesignationNo != tspSdRvDt2.ModelDesignationNo)resList.Add("ModelDesignationNo");
			if(tspSdRvDt1.CategoryNo != tspSdRvDt2.CategoryNo)resList.Add("CategoryNo");
			if(tspSdRvDt1.MakerCode != tspSdRvDt2.MakerCode)resList.Add("MakerCode");
			if(tspSdRvDt1.ModelCode != tspSdRvDt2.ModelCode)resList.Add("ModelCode");
			if(tspSdRvDt1.ModelSubCode != tspSdRvDt2.ModelSubCode)resList.Add("ModelSubCode");
			if(tspSdRvDt1.ModelName != tspSdRvDt2.ModelName)resList.Add("ModelName");
			if(tspSdRvDt1.CarInspectCertModel != tspSdRvDt2.CarInspectCertModel)resList.Add("CarInspectCertModel");
			if(tspSdRvDt1.FullModel != tspSdRvDt2.FullModel)resList.Add("FullModel");
			if(tspSdRvDt1.FrameNo != tspSdRvDt2.FrameNo)resList.Add("FrameNo");
			if(tspSdRvDt1.FrameModel != tspSdRvDt2.FrameModel)resList.Add("FrameModel");
			if(tspSdRvDt1.ChassisNo != tspSdRvDt2.ChassisNo)resList.Add("ChassisNo");
			if(tspSdRvDt1.CarProperNo != tspSdRvDt2.CarProperNo)resList.Add("CarProperNo");
			if(tspSdRvDt1.ProduceTypeOfYearNum != tspSdRvDt2.ProduceTypeOfYearNum)resList.Add("ProduceTypeOfYearNum");
			if(tspSdRvDt1.SalesOrderDate != tspSdRvDt2.SalesOrderDate)resList.Add("SalesOrderDate");
			if(tspSdRvDt1.SalesOrderEmployeeCd != tspSdRvDt2.SalesOrderEmployeeCd)resList.Add("SalesOrderEmployeeCd");
			if(tspSdRvDt1.SalesOrderEmployeeNm != tspSdRvDt2.SalesOrderEmployeeNm)resList.Add("SalesOrderEmployeeNm");
			if(tspSdRvDt1.SalesOrderComment != tspSdRvDt2.SalesOrderComment)resList.Add("SalesOrderComment");
			if(tspSdRvDt1.OrderSideSystemVerCd != tspSdRvDt2.OrderSideSystemVerCd)resList.Add("OrderSideSystemVerCd");
			if(tspSdRvDt1.TspAnswerDataMngNo != tspSdRvDt2.TspAnswerDataMngNo)resList.Add("TspAnswerDataMngNo");
			if(tspSdRvDt1.TspSlipType != tspSdRvDt2.TspSlipType)resList.Add("TspSlipType");
			if(tspSdRvDt1.AcceptAnOrderDate != tspSdRvDt2.AcceptAnOrderDate)resList.Add("AcceptAnOrderDate");
			if(tspSdRvDt1.PmSlipNo != tspSdRvDt2.PmSlipNo)resList.Add("PmSlipNo");
			if(tspSdRvDt1.AcceptAnOrderNm != tspSdRvDt2.AcceptAnOrderNm)resList.Add("AcceptAnOrderNm");
			if(tspSdRvDt1.TspTotalSlipPrice != tspSdRvDt2.TspTotalSlipPrice)resList.Add("TspTotalSlipPrice");
			if(tspSdRvDt1.PmComment != tspSdRvDt2.PmComment)resList.Add("PmComment");
			if(tspSdRvDt1.PmVersion != tspSdRvDt2.PmVersion)resList.Add("PmVersion");
			if(tspSdRvDt1.PmSendDate != tspSdRvDt2.PmSendDate)resList.Add("PmSendDate");
			if(tspSdRvDt1.PmSlipKind != tspSdRvDt2.PmSlipKind)resList.Add("PmSlipKind");
			if(tspSdRvDt1.PmOriginalSlipNo != tspSdRvDt2.PmOriginalSlipNo)resList.Add("PmOriginalSlipNo");
			if(tspSdRvDt1.EnterpriseName != tspSdRvDt2.EnterpriseName)resList.Add("EnterpriseName");
			if(tspSdRvDt1.UpdEmployeeName != tspSdRvDt2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(tspSdRvDt1.DataInputSystemName != tspSdRvDt2.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}
	}
}
