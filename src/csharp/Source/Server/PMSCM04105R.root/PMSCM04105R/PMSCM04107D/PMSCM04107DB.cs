using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAnsHistResultWork
	/// <summary>
	///                      SCM売上・回答履歴照会結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM売上・回答履歴照会結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAnsHistResultWork
	{
		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>拠点名称</summary>
		private string _sectionGuidNm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>問合せ番号</summary>
		private Int64 _inquiryNumber;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時間</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>回答区分</summary>
		/// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
		private Int32 _answerDivCd;

		/// <summary>確定日</summary>
		/// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
		private Int32 _judgementDate;

		/// <summary>問合せ・発注備考</summary>
		private string _inqOrdNote = "";

		/// <summary>問合せ従業員コード</summary>
		/// <remarks>問合せした従業員コード</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>問合せ従業員名称</summary>
		/// <remarks>問合せした従業員名称</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>回答従業員コード</summary>
		private string _ansEmployeeCd = "";

		/// <summary>回答従業員名称</summary>
		private string _ansEmployeeNm = "";

		/// <summary>問合せ日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _inquiryDate;

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

		/// <summary>メーカー名称</summary>
		private string _carMakerName = "";

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
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

		/// <summary>コメント</summary>
		/// <remarks>カタログのコメントや単位・カラーが格納</remarks>
		private string _comment = "";

		/// <summary>リペアカラーコード</summary>
		/// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
		private string _rpColorCode = "";

		/// <summary>カラー名称1</summary>
		/// <remarks>画面表示用正式名称</remarks>
		private string _colorName1 = "";

		/// <summary>トリムコード</summary>
		private string _trimCode = "";

		/// <summary>トリム名称</summary>
		private string _trimName = "";

		/// <summary>車両走行距離</summary>
		private Int32 _mileage;

		/// <summary>装備オブジェクト</summary>
		private byte[] _equipObj;

		/// <summary>問合せ行番号</summary>
		private Int32 _inqRowNumber;

		/// <summary>問合せ行番号枝番</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>商品種別</summary>
		/// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
		private Int32 _goodsDivCd;

		/// <summary>リサイクル部品種別</summary>
		private Int32 _recyclePrtKindCode;

		/// <summary>リサイクル部品種別名称</summary>
		private string _recyclePrtKindName = "";

		/// <summary>納品区分</summary>
		/// <remarks>0:配送,1:引取</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>取扱区分</summary>
		/// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
		private Int32 _handleDivCode;

		/// <summary>商品形態</summary>
		/// <remarks>1:部品,2:用品</remarks>
		private Int32 _goodsShape;

		/// <summary>納品確認区分</summary>
		/// <remarks>0:未確認,1:確認</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>納品完了予定日</summary>
		/// <remarks>納品予定日付 YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード枝番</summary>
		private Int32 _bLGoodsDrCode;

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>納品数</summary>
		private Double _deliveredGoodsCount;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>純正商品メーカーコード</summary>
		private Int32 _pureGoodsMakerCd;

		/// <summary>純正商品メーカー名称</summary>
		private string _pureMakerName = "";

		/// <summary>純正商品番号</summary>
		private string _pureGoodsNo = "";

		/// <summary>純正商品名称</summary>
		private string _pureGoodsName = "";

		/// <summary>定価</summary>
		/// <remarks>0:オープン価格</remarks>
		private Int64 _listPrice;

		/// <summary>単価</summary>
		private Int64 _unitPrice;

		/// <summary>商品補足情報</summary>
		private string _goodsAddInfo = "";

		/// <summary>粗利額</summary>
		private Int64 _roughRrofit;

		/// <summary>粗利率</summary>
		private Double _roughRate;

		/// <summary>回答期限</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _answerLimitDate;

		/// <summary>備考(明細)</summary>
		private string _commentDtl = "";

		/// <summary>棚番</summary>
		private string _shelfNo = "";

		/// <summary>追加区分</summary>
		private Int32 _additionalDivCd;

		/// <summary>訂正区分</summary>
		private Int32 _correctDivCD;

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>売上行番号</summary>
		private Int32 _salesRowNo;

		/// <summary>在庫区分</summary>
		/// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
		private Int32 _stockDiv;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>キャンペーンコード</summary>
		private Int32 _campaignCode;

		/// <summary>キャンペーン名称</summary>
		private string _campaignName = "";

		/// <summary>売上伝票合計（税込み）</summary>
		/// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>売上小計（税）</summary>
		/// <remarks>値引後の税額（外税分、内税分の合計）</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>問発・回答種別</summary>
		/// <remarks>1:問合せ・発注 2:回答</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>受信日時</summary>
		/// <remarks>（DateTime:精度は100ナノ秒）</remarks>
		private Int64 _receiveDateTime;

		/// <summary>回答作成区分</summary>
		/// <remarks>0:自動, 1:手動（Web）, 2:手動（その他）</remarks>
		private Int32 _answerCreateDiv;

		/// <summary>回答納期</summary>
		private string _answerDeliveryDate = "";

		/// <summary>問発商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _inqGoodsName = "";

		/// <summary>回答商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _ansGoodsName = "";

		/// <summary>問発純正商品番号</summary>
		/// <remarks>(半角のみ)</remarks>
		private string _inqPureGoodsNo = "";

		/// <summary>回答純正商品番号</summary>
		/// <remarks>(半角のみ)</remarks>
		private string _ansPureGoodsNo = "";

		/// <summary>問発純正商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _inqPureGoodsName = "";

		/// <summary>回答純正商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _ansPureGoodsName = "";


		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>問合せ先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  SectionGuidNm
		/// <summary>拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuidNm
		{
			get{return _sectionGuidNm;}
			set{_sectionGuidNm = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerName
		/// <summary>得意先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName
		{
			get{return _customerName;}
			set{_customerName = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>問合せ番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>更新年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>更新時間プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>回答区分プロパティ</summary>
		/// <value>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>確定日プロパティ</summary>
		/// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>問合せ・発注備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>問合せ従業員コードプロパティ</summary>
		/// <value>問合せした従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>問合せ従業員名称プロパティ</summary>
		/// <value>問合せした従業員名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>回答従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>回答従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  InquiryDate
		/// <summary>問合せ日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
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

		/// public propaty name  :  CarMakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CarMakerName
		{
			get{return _carMakerName;}
			set{_carMakerName = value;}
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
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

		/// public propaty name  :  Comment
		/// <summary>コメントプロパティ</summary>
		/// <value>カタログのコメントや単位・カラーが格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Comment
		{
			get{return _comment;}
			set{_comment = value;}
		}

		/// public propaty name  :  RpColorCode
		/// <summary>リペアカラーコードプロパティ</summary>
		/// <value>カタログの色コード（リペア用が新車時と異なる場合）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リペアカラーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RpColorCode
		{
			get{return _rpColorCode;}
			set{_rpColorCode = value;}
		}

		/// public propaty name  :  ColorName1
		/// <summary>カラー名称1プロパティ</summary>
		/// <value>画面表示用正式名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カラー名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ColorName1
		{
			get{return _colorName1;}
			set{_colorName1 = value;}
		}

		/// public propaty name  :  TrimCode
		/// <summary>トリムコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリムコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimCode
		{
			get{return _trimCode;}
			set{_trimCode = value;}
		}

		/// public propaty name  :  TrimName
		/// <summary>トリム名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   トリム名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TrimName
		{
			get{return _trimName;}
			set{_trimName = value;}
		}

		/// public propaty name  :  Mileage
		/// <summary>車両走行距離プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両走行距離プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Mileage
		{
			get{return _mileage;}
			set{_mileage = value;}
		}

		/// public propaty name  :  EquipObj
		/// <summary>装備オブジェクトプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備オブジェクトプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public byte[] EquipObj
		{
			get{return _equipObj;}
			set{_equipObj = value;}
		}

		/// public propaty name  :  InqRowNumber
		/// <summary>問合せ行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqRowNumber
		{
			get{return _inqRowNumber;}
			set{_inqRowNumber = value;}
		}

		/// public propaty name  :  InqRowNumDerivedNo
		/// <summary>問合せ行番号枝番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ行番号枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqRowNumDerivedNo
		{
			get{return _inqRowNumDerivedNo;}
			set{_inqRowNumDerivedNo = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>商品種別プロパティ</summary>
		/// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  RecyclePrtKindCode
		/// <summary>リサイクル部品種別プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リサイクル部品種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RecyclePrtKindCode
		{
			get{return _recyclePrtKindCode;}
			set{_recyclePrtKindCode = value;}
		}

		/// public propaty name  :  RecyclePrtKindName
		/// <summary>リサイクル部品種別名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リサイクル部品種別名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RecyclePrtKindName
		{
			get{return _recyclePrtKindName;}
			set{_recyclePrtKindName = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>納品区分プロパティ</summary>
		/// <value>0:配送,1:引取</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>取扱区分プロパティ</summary>
		/// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   取扱区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  GoodsShape
		/// <summary>商品形態プロパティ</summary>
		/// <value>1:部品,2:用品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品形態プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsShape
		{
			get{return _goodsShape;}
			set{_goodsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>納品確認区分プロパティ</summary>
		/// <value>0:未確認,1:確認</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品確認区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
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

		/// public propaty name  :  BLGoodsDrCode
		/// <summary>BL商品コード枝番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsDrCode
		{
			get{return _bLGoodsDrCode;}
			set{_bLGoodsDrCode = value;}
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

		/// public propaty name  :  SalesOrderCount
		/// <summary>発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>納品数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
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

		/// public propaty name  :  PureGoodsMakerCd
		/// <summary>純正商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PureGoodsMakerCd
		{
			get{return _pureGoodsMakerCd;}
			set{_pureGoodsMakerCd = value;}
		}

		/// public propaty name  :  PureMakerName
		/// <summary>純正商品メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PureMakerName
		{
			get{return _pureMakerName;}
			set{_pureMakerName = value;}
		}

		/// public propaty name  :  PureGoodsNo
		/// <summary>純正商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PureGoodsNo
		{
			get{return _pureGoodsNo;}
			set{_pureGoodsNo = value;}
		}

		/// public propaty name  :  PureGoodsName
		/// <summary>純正商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   純正商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PureGoodsName
		{
			get{return _pureGoodsName;}
			set{_pureGoodsName = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
		/// <value>0:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  GoodsAddInfo
		/// <summary>商品補足情報プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品補足情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsAddInfo
		{
			get{return _goodsAddInfo;}
			set{_goodsAddInfo = value;}
		}

		/// public propaty name  :  RoughRrofit
		/// <summary>粗利額プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 RoughRrofit
		{
			get{return _roughRrofit;}
			set{_roughRrofit = value;}
		}

		/// public propaty name  :  RoughRate
		/// <summary>粗利率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double RoughRate
		{
			get{return _roughRate;}
			set{_roughRate = value;}
		}

		/// public propaty name  :  AnswerLimitDate
		/// <summary>回答期限プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerLimitDate
		{
			get{return _answerLimitDate;}
			set{_answerLimitDate = value;}
		}

		/// public propaty name  :  CommentDtl
		/// <summary>備考(明細)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考(明細)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CommentDtl
		{
			get{return _commentDtl;}
			set{_commentDtl = value;}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShelfNo
		{
			get{return _shelfNo;}
			set{_shelfNo = value;}
		}

		/// public propaty name  :  AdditionalDivCd
		/// <summary>追加区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   追加区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AdditionalDivCd
		{
			get{return _additionalDivCd;}
			set{_additionalDivCd = value;}
		}

		/// public propaty name  :  CorrectDivCD
		/// <summary>訂正区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   訂正区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CorrectDivCD
		{
			get{return _correctDivCD;}
			set{_correctDivCD = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>売上伝票番号プロパティ</summary>
		/// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesRowNo
		/// <summary>売上行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesRowNo
		{
			get{return _salesRowNo;}
			set{_salesRowNo = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>在庫区分プロパティ</summary>
		/// <value>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>問合せ・発注種別プロパティ</summary>
		/// <value>1:問合せ 2:発注</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ・発注種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  CampaignCode
		/// <summary>キャンペーンコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンペーンコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CampaignCode
		{
			get{return _campaignCode;}
			set{_campaignCode = value;}
		}

		/// public propaty name  :  CampaignName
		/// <summary>キャンペーン名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンペーン名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CampaignName
		{
			get{return _campaignName;}
			set{_campaignName = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>売上伝票合計（税込み）プロパティ</summary>
		/// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票合計（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>売上小計（税）プロパティ</summary>
		/// <value>値引後の税額（外税分、内税分の合計）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上小計（税）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>問発・回答種別プロパティ</summary>
		/// <value>1:問合せ・発注 2:回答</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発・回答種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>受信日時プロパティ</summary>
		/// <value>（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受信日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>回答作成区分プロパティ</summary>
		/// <value>0:自動, 1:手動（Web）, 2:手動（その他）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答作成区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

		/// public propaty name  :  AnswerDeliveryDate
		/// <summary>回答納期プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答納期プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerDeliveryDate
		{
			get{return _answerDeliveryDate;}
			set{_answerDeliveryDate = value;}
		}

		/// public propaty name  :  InqGoodsName
		/// <summary>問発商品名プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発商品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqGoodsName
		{
			get{return _inqGoodsName;}
			set{_inqGoodsName = value;}
		}

		/// public propaty name  :  AnsGoodsName
		/// <summary>回答商品名プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答商品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsGoodsName
		{
			get{return _ansGoodsName;}
			set{_ansGoodsName = value;}
		}

		/// public propaty name  :  InqPureGoodsNo
		/// <summary>問発純正商品番号プロパティ</summary>
		/// <value>(半角のみ)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発純正商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqPureGoodsNo
		{
			get{return _inqPureGoodsNo;}
			set{_inqPureGoodsNo = value;}
		}

		/// public propaty name  :  AnsPureGoodsNo
		/// <summary>回答純正商品番号プロパティ</summary>
		/// <value>(半角のみ)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答純正商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsPureGoodsNo
		{
			get{return _ansPureGoodsNo;}
			set{_ansPureGoodsNo = value;}
		}

		/// public propaty name  :  InqPureGoodsName
		/// <summary>問発純正商品名プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問発純正商品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqPureGoodsName
		{
			get{return _inqPureGoodsName;}
			set{_inqPureGoodsName = value;}
		}

		/// public propaty name  :  AnsPureGoodsName
		/// <summary>回答純正商品名プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答純正商品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnsPureGoodsName
		{
			get{return _ansPureGoodsName;}
			set{_ansPureGoodsName = value;}
		}


		/// <summary>
		/// SCM売上・回答履歴照会結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>SCMAnsHistResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAnsHistResultWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAnsHistResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMAnsHistResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAnsHistResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAnsHistResultWork || graph is ArrayList || graph is SCMAnsHistResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMAnsHistResultWork).FullName));

            if (graph != null && graph is SCMAnsHistResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAnsHistResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAnsHistResultWork[])graph).Length;
            }
            else if (graph is SCMAnsHistResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuidNm
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //確定日
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //問合せ・発注備考
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //問合せ従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //問合せ従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //回答従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //回答従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //問合せ日
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //陸運事務所番号
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
            //陸運事務局名称
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
            //車両登録番号（種別）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
            //型式指定番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //CarMakerName
            //車種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
            //車種名
            serInfo.MemberInfo.Add(typeof(string)); //ModelName
            //車検証型式
            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
            //型式（フル型）
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //車台番号
            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
            //車台型式
            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
            //シャシーNo
            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
            //車両固有番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
            //生産年式（NUMタイプ）
            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
            //コメント
            serInfo.MemberInfo.Add(typeof(string)); //Comment
            //リペアカラーコード
            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
            //カラー名称1
            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
            //トリムコード
            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
            //トリム名称
            serInfo.MemberInfo.Add(typeof(string)); //TrimName
            //車両走行距離
            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
            //装備オブジェクト
            serInfo.MemberInfo.Add(typeof(byte[])); //EquipObj
            //問合せ行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //問合せ行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //商品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
            //リサイクル部品種別
            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
            //リサイクル部品種別名称
            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
            //納品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //取扱区分
            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
            //商品形態
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
            //納品確認区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //納品数
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //純正商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //純正商品メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //PureMakerName
            //純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsNo
            //純正商品名称
            serInfo.MemberInfo.Add(typeof(string)); //PureGoodsName
            //定価
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //単価
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //商品補足情報
            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
            //粗利額
            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
            //粗利率
            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
            //回答期限
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
            //備考(明細)
            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
            //棚番
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //追加区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
            //訂正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //キャンペーン名称
            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //売上小計（税）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //問発・回答種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
            //受信日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
            //回答作成区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerCreateDiv
            //回答納期
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate
            //問発商品名
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //回答商品名
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //問発純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //回答純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
            //問発純正商品名
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsName
            //回答純正商品名
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsName


            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAnsHistResultWork)
            {
                SCMAnsHistResultWork temp = (SCMAnsHistResultWork)graph;

                SetSCMAnsHistResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAnsHistResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAnsHistResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAnsHistResultWork temp in lst)
                {
                    SetSCMAnsHistResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAnsHistResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 94;

        /// <summary>
        ///  SCMAnsHistResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMAnsHistResultWork(System.IO.BinaryWriter writer, SCMAnsHistResultWork temp)
        {
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //拠点名称
            writer.Write(temp.SectionGuidNm);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先名称
            writer.Write(temp.CustomerName);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //回答区分
            writer.Write(temp.AnswerDivCd);
            //確定日
            writer.Write(temp.JudgementDate);
            //問合せ・発注備考
            writer.Write(temp.InqOrdNote);
            //問合せ従業員コード
            writer.Write(temp.InqEmployeeCd);
            //問合せ従業員名称
            writer.Write(temp.InqEmployeeNm);
            //回答従業員コード
            writer.Write(temp.AnsEmployeeCd);
            //回答従業員名称
            writer.Write(temp.AnsEmployeeNm);
            //問合せ日
            writer.Write(temp.InquiryDate);
            //陸運事務所番号
            writer.Write(temp.NumberPlate1Code);
            //陸運事務局名称
            writer.Write(temp.NumberPlate1Name);
            //車両登録番号（種別）
            writer.Write(temp.NumberPlate2);
            //車両登録番号（カナ）
            writer.Write(temp.NumberPlate3);
            //車両登録番号（プレート番号）
            writer.Write(temp.NumberPlate4);
            //型式指定番号
            writer.Write(temp.ModelDesignationNo);
            //類別番号
            writer.Write(temp.CategoryNo);
            //メーカーコード
            writer.Write(temp.MakerCode);
            //メーカー名称
            writer.Write(temp.CarMakerName);
            //車種コード
            writer.Write(temp.ModelCode);
            //車種サブコード
            writer.Write(temp.ModelSubCode);
            //車種名
            writer.Write(temp.ModelName);
            //車検証型式
            writer.Write(temp.CarInspectCertModel);
            //型式（フル型）
            writer.Write(temp.FullModel);
            //車台番号
            writer.Write(temp.FrameNo);
            //車台型式
            writer.Write(temp.FrameModel);
            //シャシーNo
            writer.Write(temp.ChassisNo);
            //車両固有番号
            writer.Write(temp.CarProperNo);
            //生産年式（NUMタイプ）
            writer.Write(temp.ProduceTypeOfYearNum);
            //コメント
            writer.Write(temp.Comment);
            //リペアカラーコード
            writer.Write(temp.RpColorCode);
            //カラー名称1
            writer.Write(temp.ColorName1);
            //トリムコード
            writer.Write(temp.TrimCode);
            //トリム名称
            writer.Write(temp.TrimName);
            //車両走行距離
            writer.Write(temp.Mileage);
            //装備オブジェクト
            writer.Write(temp.EquipObj.Length);
            writer.Write(temp.EquipObj);
            //問合せ行番号
            writer.Write(temp.InqRowNumber);
            //問合せ行番号枝番
            writer.Write(temp.InqRowNumDerivedNo);
            //商品種別
            writer.Write(temp.GoodsDivCd);
            //リサイクル部品種別
            writer.Write(temp.RecyclePrtKindCode);
            //リサイクル部品種別名称
            writer.Write(temp.RecyclePrtKindName);
            //納品区分
            writer.Write(temp.DeliveredGoodsDiv);
            //取扱区分
            writer.Write(temp.HandleDivCode);
            //商品形態
            writer.Write(temp.GoodsShape);
            //納品確認区分
            writer.Write(temp.DelivrdGdsConfCd);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード枝番
            writer.Write(temp.BLGoodsDrCode);
            //商品名称
            writer.Write(temp.GoodsName);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //納品数
            writer.Write(temp.DeliveredGoodsCount);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //純正商品メーカーコード
            writer.Write(temp.PureGoodsMakerCd);
            //純正商品メーカー名称
            writer.Write(temp.PureMakerName);
            //純正商品番号
            writer.Write(temp.PureGoodsNo);
            //純正商品名称
            writer.Write(temp.PureGoodsName);
            //定価
            writer.Write(temp.ListPrice);
            //単価
            writer.Write(temp.UnitPrice);
            //商品補足情報
            writer.Write(temp.GoodsAddInfo);
            //粗利額
            writer.Write(temp.RoughRrofit);
            //粗利率
            writer.Write(temp.RoughRate);
            //回答期限
            writer.Write(temp.AnswerLimitDate);
            //備考(明細)
            writer.Write(temp.CommentDtl);
            //棚番
            writer.Write(temp.ShelfNo);
            //追加区分
            writer.Write(temp.AdditionalDivCd);
            //訂正区分
            writer.Write(temp.CorrectDivCD);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //在庫区分
            writer.Write(temp.StockDiv);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //キャンペーン名称
            writer.Write(temp.CampaignName);
            //売上伝票合計（税込み）
            writer.Write(temp.SalesTotalTaxInc);
            //売上小計（税）
            writer.Write(temp.SalesSubtotalTax);
            //問発・回答種別
            writer.Write(temp.InqOrdAnsDivCd);
            //受信日時
            writer.Write(temp.ReceiveDateTime);
            //回答作成区分
            writer.Write(temp.AnswerCreateDiv);
            //回答納期
            writer.Write(temp.AnswerDeliveryDate);
            //問発商品名
            writer.Write(temp.InqGoodsName);
            //回答商品名
            writer.Write(temp.AnsGoodsName);
            //問発純正商品番号
            writer.Write(temp.InqPureGoodsNo);
            //回答純正商品番号
            writer.Write(temp.AnsPureGoodsNo);
            //問発純正商品名
            writer.Write(temp.InqPureGoodsName);
            //回答純正商品名
            writer.Write(temp.AnsPureGoodsName);

        }

        /// <summary>
        ///  SCMAnsHistResultWorkインスタンス取得
        /// </summary>
        /// <returns>SCMAnsHistResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMAnsHistResultWork GetSCMAnsHistResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMAnsHistResultWork temp = new SCMAnsHistResultWork();

            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //拠点名称
            temp.SectionGuidNm = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先名称
            temp.CustomerName = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //回答区分
            temp.AnswerDivCd = reader.ReadInt32();
            //確定日
            temp.JudgementDate = reader.ReadInt32();
            //問合せ・発注備考
            temp.InqOrdNote = reader.ReadString();
            //問合せ従業員コード
            temp.InqEmployeeCd = reader.ReadString();
            //問合せ従業員名称
            temp.InqEmployeeNm = reader.ReadString();
            //回答従業員コード
            temp.AnsEmployeeCd = reader.ReadString();
            //回答従業員名称
            temp.AnsEmployeeNm = reader.ReadString();
            //問合せ日
            temp.InquiryDate = reader.ReadInt32();
            //陸運事務所番号
            temp.NumberPlate1Code = reader.ReadInt32();
            //陸運事務局名称
            temp.NumberPlate1Name = reader.ReadString();
            //車両登録番号（種別）
            temp.NumberPlate2 = reader.ReadString();
            //車両登録番号（カナ）
            temp.NumberPlate3 = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.NumberPlate4 = reader.ReadInt32();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //メーカー名称
            temp.CarMakerName = reader.ReadString();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //車種名
            temp.ModelName = reader.ReadString();
            //車検証型式
            temp.CarInspectCertModel = reader.ReadString();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //車台型式
            temp.FrameModel = reader.ReadString();
            //シャシーNo
            temp.ChassisNo = reader.ReadString();
            //車両固有番号
            temp.CarProperNo = reader.ReadInt32();
            //生産年式（NUMタイプ）
            temp.ProduceTypeOfYearNum = reader.ReadInt32();
            //コメント
            temp.Comment = reader.ReadString();
            //リペアカラーコード
            temp.RpColorCode = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //装備オブジェクト
            int equipObjLength = reader.ReadInt32();
            temp.EquipObj = reader.ReadBytes(equipObjLength);
            //問合せ行番号
            temp.InqRowNumber = reader.ReadInt32();
            //問合せ行番号枝番
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //商品種別
            temp.GoodsDivCd = reader.ReadInt32();
            //リサイクル部品種別
            temp.RecyclePrtKindCode = reader.ReadInt32();
            //リサイクル部品種別名称
            temp.RecyclePrtKindName = reader.ReadString();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //取扱区分
            temp.HandleDivCode = reader.ReadInt32();
            //商品形態
            temp.GoodsShape = reader.ReadInt32();
            //納品確認区分
            temp.DelivrdGdsConfCd = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード枝番
            temp.BLGoodsDrCode = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //発注数
            temp.SalesOrderCount = reader.ReadDouble();
            //納品数
            temp.DeliveredGoodsCount = reader.ReadDouble();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //純正商品メーカーコード
            temp.PureGoodsMakerCd = reader.ReadInt32();
            //純正商品メーカー名称
            temp.PureMakerName = reader.ReadString();
            //純正商品番号
            temp.PureGoodsNo = reader.ReadString();
            //純正商品名称
            temp.PureGoodsName = reader.ReadString();
            //定価
            temp.ListPrice = reader.ReadInt64();
            //単価
            temp.UnitPrice = reader.ReadInt64();
            //商品補足情報
            temp.GoodsAddInfo = reader.ReadString();
            //粗利額
            temp.RoughRrofit = reader.ReadInt64();
            //粗利率
            temp.RoughRate = reader.ReadDouble();
            //回答期限
            temp.AnswerLimitDate = reader.ReadInt32();
            //備考(明細)
            temp.CommentDtl = reader.ReadString();
            //棚番
            temp.ShelfNo = reader.ReadString();
            //追加区分
            temp.AdditionalDivCd = reader.ReadInt32();
            //訂正区分
            temp.CorrectDivCD = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //キャンペーン名称
            temp.CampaignName = reader.ReadString();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上小計（税）
            temp.SalesSubtotalTax = reader.ReadInt64();
            //問発・回答種別
            temp.InqOrdAnsDivCd = reader.ReadInt32();
            //受信日時
            temp.ReceiveDateTime = reader.ReadInt64();
            //回答作成区分
            temp.AnswerCreateDiv = reader.ReadInt32();
            //回答納期
            temp.AnswerDeliveryDate = reader.ReadString();
            //問発商品名
            temp.InqGoodsName = reader.ReadString();
            //回答商品名
            temp.AnsGoodsName = reader.ReadString();
            //問発純正商品番号
            temp.InqPureGoodsNo = reader.ReadString();
            //回答純正商品番号
            temp.AnsPureGoodsNo = reader.ReadString();
            //問発純正商品名
            temp.InqPureGoodsName = reader.ReadString();
            //回答純正商品名
            temp.AnsPureGoodsName = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>SCMAnsHistResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAnsHistResultWork temp = GetSCMAnsHistResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMAnsHistResultWork[])lst.ToArray(typeof(SCMAnsHistResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

// 2009.08.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
#region 削除
//using System;
//using System.Collections;
//using Broadleaf.Library.Data;
//using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Resources;

//namespace Broadleaf.Application.Remoting.ParamData
//{
//    /// public class name:   SCMAnsHistResultWork
//    /// <summary>
//    ///                      SCM売上・回答履歴照会結果クラスワーク
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   SCM売上・回答履歴照会結果クラスワークヘッダファイル</br>
//    /// <br>Programmer       :   自動生成</br>
//    /// <br>Date             :    2009/4/13</br>
//    /// <br>Genarated Date   :   2009/06/19  (CSharp File Generated Date)</br>
//    /// <br>Update Note      :   </br>
//    /// </remarks>
//    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
//    public class SCMAnsHistResultWork
//    {
//        /// <summary>問合せ先企業コード</summary>
//        private string _inqOtherEpCd = "";

//        /// <summary>問合せ先拠点コード</summary>
//        private string _inqOtherSecCd = "";

//        /// <summary>拠点名称</summary>
//        private string _sectionGuidNm = "";

//        /// <summary>得意先コード</summary>
//        private Int32 _customerCode;

//        /// <summary>得意先名称</summary>
//        private string _customerName = "";

//        /// <summary>問合せ番号</summary>
//        private Int64 _inquiryNumber;

//        /// <summary>更新年月日</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private DateTime _updateDate;

//        /// <summary>更新時間</summary>
//        /// <remarks>HHMMSSXXX</remarks>
//        private Int32 _updateTime;

//        /// <summary>回答区分</summary>
//        /// <remarks>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</remarks>
//        private Int32 _answerDivCd;

//        /// <summary>確定日</summary>
//        /// <remarks>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</remarks>
//        private Int32 _judgementDate;

//        /// <summary>問合せ・発注備考</summary>
//        private string _inqOrdNote = "";

//        /// <summary>問合せ従業員コード</summary>
//        /// <remarks>問合せした従業員コード</remarks>
//        private string _inqEmployeeCd = "";

//        /// <summary>問合せ従業員名称</summary>
//        /// <remarks>問合せした従業員名称</remarks>
//        private string _inqEmployeeNm = "";

//        /// <summary>回答従業員コード</summary>
//        private string _ansEmployeeCd = "";

//        /// <summary>回答従業員名称</summary>
//        private string _ansEmployeeNm = "";

//        /// <summary>問合せ日</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _inquiryDate;

//        /// <summary>陸運事務所番号</summary>
//        private Int32 _numberPlate1Code;

//        /// <summary>陸運事務局名称</summary>
//        private string _numberPlate1Name = "";

//        /// <summary>車両登録番号（種別）</summary>
//        private string _numberPlate2 = "";

//        /// <summary>車両登録番号（カナ）</summary>
//        private string _numberPlate3 = "";

//        /// <summary>車両登録番号（プレート番号）</summary>
//        private Int32 _numberPlate4;

//        /// <summary>型式指定番号</summary>
//        private Int32 _modelDesignationNo;

//        /// <summary>類別番号</summary>
//        private Int32 _categoryNo;

//        /// <summary>メーカーコード</summary>
//        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
//        private Int32 _makerCode;

//        /// <summary>メーカー名称</summary>
//        private string _carMakerName = "";

//        /// <summary>車種コード</summary>
//        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
//        private Int32 _modelCode;

//        /// <summary>車種サブコード</summary>
//        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
//        private Int32 _modelSubCode;

//        /// <summary>車種名</summary>
//        private string _modelName = "";

//        /// <summary>車検証型式</summary>
//        private string _carInspectCertModel = "";

//        /// <summary>型式（フル型）</summary>
//        /// <remarks>フル型式(44桁用)</remarks>
//        private string _fullModel = "";

//        /// <summary>車台番号</summary>
//        private string _frameNo = "";

//        /// <summary>車台型式</summary>
//        private string _frameModel = "";

//        /// <summary>シャシーNo</summary>
//        private string _chassisNo = "";

//        /// <summary>車両固有番号</summary>
//        /// <remarks>ユニークな固定番号</remarks>
//        private Int32 _carProperNo;

//        /// <summary>生産年式（NUMタイプ）</summary>
//        /// <remarks>YYYYMM</remarks>
//        private Int32 _produceTypeOfYearNum;

//        /// <summary>コメント</summary>
//        /// <remarks>カタログのコメントや単位・カラーが格納</remarks>
//        private string _comment = "";

//        /// <summary>リペアカラーコード</summary>
//        /// <remarks>カタログの色コード（リペア用が新車時と異なる場合）</remarks>
//        private string _rpColorCode = "";

//        /// <summary>カラー名称1</summary>
//        /// <remarks>画面表示用正式名称</remarks>
//        private string _colorName1 = "";

//        /// <summary>トリムコード</summary>
//        private string _trimCode = "";

//        /// <summary>トリム名称</summary>
//        private string _trimName = "";

//        /// <summary>車両走行距離</summary>
//        private Int32 _mileage;

//        /// <summary>装備オブジェクト</summary>
//        private Byte[] _equipObj;

//        /// <summary>問合せ行番号</summary>
//        private Int32 _inqRowNumber;

//        /// <summary>問合せ行番号枝番</summary>
//        private Int32 _inqRowNumDerivedNo;

//        /// <summary>商品種別</summary>
//        /// <remarks>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</remarks>
//        private Int32 _goodsDivCd;

//        /// <summary>リサイクル部品種別</summary>
//        private Int32 _recyclePrtKindCode;

//        /// <summary>リサイクル部品種別名称</summary>
//        private string _recyclePrtKindName = "";

//        /// <summary>納品区分</summary>
//        /// <remarks>0:配送,1:引取</remarks>
//        private Int32 _deliveredGoodsDiv;

//        /// <summary>取扱区分</summary>
//        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
//        private Int32 _handleDivCode;

//        /// <summary>商品形態</summary>
//        /// <remarks>1:部品,2:用品</remarks>
//        private Int32 _goodsShape;

//        /// <summary>納品確認区分</summary>
//        /// <remarks>0:未確認,1:確認</remarks>
//        private Int32 _delivrdGdsConfCd;

//        /// <summary>納品完了予定日</summary>
//        /// <remarks>納品予定日付 YYYYMMDD</remarks>
//        private DateTime _deliGdsCmpltDueDate;

//        /// <summary>BL商品コード</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL商品コード枝番</summary>
//        private Int32 _bLGoodsDrCode;

//        /// <summary>問発商品名</summary>
//        /// <remarks>(半角全角混在)</remarks>
//        private string _inqGoodsName = "";

//        /// <summary>回答商品名</summary>
//        /// <remarks>(半角全角混在)</remarks>
//        private string _ansGoodsName = "";

//        /// <summary>発注数</summary>
//        private Double _salesOrderCount;

//        /// <summary>納品数</summary>
//        private Double _deliveredGoodsCount;

//        /// <summary>商品番号</summary>
//        private string _goodsNo = "";

//        /// <summary>商品メーカーコード</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>メーカー名称</summary>
//        private string _makerName = "";

//        /// <summary>純正商品メーカーコード</summary>
//        private Int32 _pureGoodsMakerCd;

//        /// <summary>純正商品メーカー名称</summary>
//        private string _pureMakerName = "";

//        /// <summary>問発純正商品番号</summary>
//        /// <remarks>(半角のみ)</remarks>
//        private string _inqPureGoodsNo = "";

//        /// <summary>回答純正商品番号</summary>
//        /// <remarks>(半角のみ)</remarks>
//        private string _ansPureGoodsNo = "";

//        /// <summary>問発純正商品名称</summary>
//        private string _inqPureGoodsName = "";

//        /// <summary>回答純正商品名称</summary>
//        private string _ansPureGoodsName = "";

//        /// <summary>定価</summary>
//        /// <remarks>0:オープン価格</remarks>
//        private Int64 _listPrice;

//        /// <summary>単価</summary>
//        private Int64 _unitPrice;

//        /// <summary>商品補足情報</summary>
//        private string _goodsAddInfo = "";

//        /// <summary>粗利額</summary>
//        private Int64 _roughRrofit;

//        /// <summary>粗利率</summary>
//        private Double _roughRate;

//        /// <summary>回答期限</summary>
//        /// <remarks>YYYYMMDD</remarks>
//        private Int32 _answerLimitDate;

//        /// <summary>備考(明細)</summary>
//        private string _commentDtl = "";

//        /// <summary>棚番</summary>
//        private string _shelfNo = "";

//        /// <summary>追加区分</summary>
//        private Int32 _additionalDivCd;

//        /// <summary>訂正区分</summary>
//        private Int32 _correctDivCD;

//        /// <summary>受注ステータス</summary>
//        /// <remarks>10:見積,20:受注,30:売上</remarks>
//        private Int32 _acptAnOdrStatus;

//        /// <summary>売上伝票番号</summary>
//        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
//        private string _salesSlipNum = "";

//        /// <summary>売上行番号</summary>
//        private Int32 _salesRowNo;

//        /// <summary>在庫区分</summary>
//        /// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
//        private Int32 _stockDiv;

//        /// <summary>問合せ・発注種別</summary>
//        /// <remarks>1:問合せ 2:発注</remarks>
//        private Int32 _inqOrdDivCd;

//        /// <summary>表示順位</summary>
//        private Int32 _displayOrder;

//        /// <summary>キャンペーンコード</summary>
//        private Int32 _campaignCode;

//        /// <summary>キャンペーン名称</summary>
//        private string _campaignName = "";

//        /// <summary>売上伝票合計（税込み）</summary>
//        /// <remarks>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</remarks>
//        private Int64 _salesTotalTaxInc;

//        /// <summary>売上小計（税）</summary>
//        /// <remarks>値引後の税額（外税分、内税分の合計）</remarks>
//        private Int64 _salesSubtotalTax;

//        /// <summary>問発・回答種別</summary>
//        /// <remarks>1:問合せ・発注 2:回答</remarks>
//        private Int32 _inqOrdAnsDivCd;

//        /// <summary>受信日時</summary>
//        /// <remarks>（DateTime:精度は100ナノ秒）</remarks>
//        private Int64 _receiveDateTime;

//        /// <summary>回答納期</summary>
//        private string _answerDeliveryDate = "";


//        /// public propaty name  :  InqOtherEpCd
//        /// <summary>問合せ先企業コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ先企業コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOtherEpCd
//        {
//            get { return _inqOtherEpCd; }
//            set { _inqOtherEpCd = value; }
//        }

//        /// public propaty name  :  InqOtherSecCd
//        /// <summary>問合せ先拠点コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ先拠点コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOtherSecCd
//        {
//            get { return _inqOtherSecCd; }
//            set { _inqOtherSecCd = value; }
//        }

//        /// public propaty name  :  SectionGuidNm
//        /// <summary>拠点名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   拠点名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string SectionGuidNm
//        {
//            get { return _sectionGuidNm; }
//            set { _sectionGuidNm = value; }
//        }

//        /// public propaty name  :  CustomerCode
//        /// <summary>得意先コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>得意先名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  InquiryNumber
//        /// <summary>問合せ番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 InquiryNumber
//        {
//            get { return _inquiryNumber; }
//            set { _inquiryNumber = value; }
//        }

//        /// public propaty name  :  UpdateDate
//        /// <summary>更新年月日プロパティ</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   更新年月日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public DateTime UpdateDate
//        {
//            get { return _updateDate; }
//            set { _updateDate = value; }
//        }

//        /// public propaty name  :  UpdateTime
//        /// <summary>更新時間プロパティ</summary>
//        /// <value>HHMMSSXXX</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   更新時間プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 UpdateTime
//        {
//            get { return _updateTime; }
//            set { _updateTime = value; }
//        }

//        /// public propaty name  :  AnswerDivCd
//        /// <summary>回答区分プロパティ</summary>
//        /// <value>0:アクションなし 10:一部回答 20:回答完了 30:承認 99:キャンセル</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AnswerDivCd
//        {
//            get { return _answerDivCd; }
//            set { _answerDivCd = value; }
//        }

//        /// public propaty name  :  JudgementDate
//        /// <summary>確定日プロパティ</summary>
//        /// <value>YYYYMMDD     ＰＳＦにて使用する。取引が終息した日。伝票ロックにも使用する。</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   確定日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 JudgementDate
//        {
//            get { return _judgementDate; }
//            set { _judgementDate = value; }
//        }

//        /// public propaty name  :  InqOrdNote
//        /// <summary>問合せ・発注備考プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ・発注備考プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqOrdNote
//        {
//            get { return _inqOrdNote; }
//            set { _inqOrdNote = value; }
//        }

//        /// public propaty name  :  InqEmployeeCd
//        /// <summary>問合せ従業員コードプロパティ</summary>
//        /// <value>問合せした従業員コード</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ従業員コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqEmployeeCd
//        {
//            get { return _inqEmployeeCd; }
//            set { _inqEmployeeCd = value; }
//        }

//        /// public propaty name  :  InqEmployeeNm
//        /// <summary>問合せ従業員名称プロパティ</summary>
//        /// <value>問合せした従業員名称</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ従業員名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqEmployeeNm
//        {
//            get { return _inqEmployeeNm; }
//            set { _inqEmployeeNm = value; }
//        }

//        /// public propaty name  :  AnsEmployeeCd
//        /// <summary>回答従業員コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答従業員コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsEmployeeCd
//        {
//            get { return _ansEmployeeCd; }
//            set { _ansEmployeeCd = value; }
//        }

//        /// public propaty name  :  AnsEmployeeNm
//        /// <summary>回答従業員名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答従業員名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsEmployeeNm
//        {
//            get { return _ansEmployeeNm; }
//            set { _ansEmployeeNm = value; }
//        }

//        /// public propaty name  :  InquiryDate
//        /// <summary>問合せ日プロパティ</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InquiryDate
//        {
//            get { return _inquiryDate; }
//            set { _inquiryDate = value; }
//        }

//        /// public propaty name  :  NumberPlate1Code
//        /// <summary>陸運事務所番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   陸運事務所番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 NumberPlate1Code
//        {
//            get { return _numberPlate1Code; }
//            set { _numberPlate1Code = value; }
//        }

//        /// public propaty name  :  NumberPlate1Name
//        /// <summary>陸運事務局名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   陸運事務局名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string NumberPlate1Name
//        {
//            get { return _numberPlate1Name; }
//            set { _numberPlate1Name = value; }
//        }

//        /// public propaty name  :  NumberPlate2
//        /// <summary>車両登録番号（種別）プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車両登録番号（種別）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string NumberPlate2
//        {
//            get { return _numberPlate2; }
//            set { _numberPlate2 = value; }
//        }

//        /// public propaty name  :  NumberPlate3
//        /// <summary>車両登録番号（カナ）プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string NumberPlate3
//        {
//            get { return _numberPlate3; }
//            set { _numberPlate3 = value; }
//        }

//        /// public propaty name  :  NumberPlate4
//        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 NumberPlate4
//        {
//            get { return _numberPlate4; }
//            set { _numberPlate4 = value; }
//        }

//        /// public propaty name  :  ModelDesignationNo
//        /// <summary>型式指定番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   型式指定番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 ModelDesignationNo
//        {
//            get { return _modelDesignationNo; }
//            set { _modelDesignationNo = value; }
//        }

//        /// public propaty name  :  CategoryNo
//        /// <summary>類別番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   類別番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CategoryNo
//        {
//            get { return _categoryNo; }
//            set { _categoryNo = value; }
//        }

//        /// public propaty name  :  MakerCode
//        /// <summary>メーカーコードプロパティ</summary>
//        /// <value>1～899:提供分, 900～ユーザー登録</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 MakerCode
//        {
//            get { return _makerCode; }
//            set { _makerCode = value; }
//        }

//        /// public propaty name  :  CarMakerName
//        /// <summary>メーカー名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカー名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CarMakerName
//        {
//            get { return _carMakerName; }
//            set { _carMakerName = value; }
//        }

//        /// public propaty name  :  ModelCode
//        /// <summary>車種コードプロパティ</summary>
//        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車種コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 ModelCode
//        {
//            get { return _modelCode; }
//            set { _modelCode = value; }
//        }

//        /// public propaty name  :  ModelSubCode
//        /// <summary>車種サブコードプロパティ</summary>
//        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車種サブコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 ModelSubCode
//        {
//            get { return _modelSubCode; }
//            set { _modelSubCode = value; }
//        }

//        /// public propaty name  :  ModelName
//        /// <summary>車種名プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車種名プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string ModelName
//        {
//            get { return _modelName; }
//            set { _modelName = value; }
//        }

//        /// public propaty name  :  CarInspectCertModel
//        /// <summary>車検証型式プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車検証型式プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CarInspectCertModel
//        {
//            get { return _carInspectCertModel; }
//            set { _carInspectCertModel = value; }
//        }

//        /// public propaty name  :  FullModel
//        /// <summary>型式（フル型）プロパティ</summary>
//        /// <value>フル型式(44桁用)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   型式（フル型）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string FullModel
//        {
//            get { return _fullModel; }
//            set { _fullModel = value; }
//        }

//        /// public propaty name  :  FrameNo
//        /// <summary>車台番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車台番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string FrameNo
//        {
//            get { return _frameNo; }
//            set { _frameNo = value; }
//        }

//        /// public propaty name  :  FrameModel
//        /// <summary>車台型式プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車台型式プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string FrameModel
//        {
//            get { return _frameModel; }
//            set { _frameModel = value; }
//        }

//        /// public propaty name  :  ChassisNo
//        /// <summary>シャシーNoプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   シャシーNoプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string ChassisNo
//        {
//            get { return _chassisNo; }
//            set { _chassisNo = value; }
//        }

//        /// public propaty name  :  CarProperNo
//        /// <summary>車両固有番号プロパティ</summary>
//        /// <value>ユニークな固定番号</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車両固有番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CarProperNo
//        {
//            get { return _carProperNo; }
//            set { _carProperNo = value; }
//        }

//        /// public propaty name  :  ProduceTypeOfYearNum
//        /// <summary>生産年式（NUMタイプ）プロパティ</summary>
//        /// <value>YYYYMM</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   生産年式（NUMタイプ）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 ProduceTypeOfYearNum
//        {
//            get { return _produceTypeOfYearNum; }
//            set { _produceTypeOfYearNum = value; }
//        }

//        /// public propaty name  :  Comment
//        /// <summary>コメントプロパティ</summary>
//        /// <value>カタログのコメントや単位・カラーが格納</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   コメントプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string Comment
//        {
//            get { return _comment; }
//            set { _comment = value; }
//        }

//        /// public propaty name  :  RpColorCode
//        /// <summary>リペアカラーコードプロパティ</summary>
//        /// <value>カタログの色コード（リペア用が新車時と異なる場合）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   リペアカラーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string RpColorCode
//        {
//            get { return _rpColorCode; }
//            set { _rpColorCode = value; }
//        }

//        /// public propaty name  :  ColorName1
//        /// <summary>カラー名称1プロパティ</summary>
//        /// <value>画面表示用正式名称</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   カラー名称1プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string ColorName1
//        {
//            get { return _colorName1; }
//            set { _colorName1 = value; }
//        }

//        /// public propaty name  :  TrimCode
//        /// <summary>トリムコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   トリムコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string TrimCode
//        {
//            get { return _trimCode; }
//            set { _trimCode = value; }
//        }

//        /// public propaty name  :  TrimName
//        /// <summary>トリム名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   トリム名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string TrimName
//        {
//            get { return _trimName; }
//            set { _trimName = value; }
//        }

//        /// public propaty name  :  Mileage
//        /// <summary>車両走行距離プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   車両走行距離プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 Mileage
//        {
//            get { return _mileage; }
//            set { _mileage = value; }
//        }

//        /// public propaty name  :  EquipObj
//        /// <summary>装備オブジェクトプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   装備オブジェクトプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Byte[] EquipObj
//        {
//            get { return _equipObj; }
//            set { _equipObj = value; }
//        }

//        /// public propaty name  :  InqRowNumber
//        /// <summary>問合せ行番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ行番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqRowNumber
//        {
//            get { return _inqRowNumber; }
//            set { _inqRowNumber = value; }
//        }

//        /// public propaty name  :  InqRowNumDerivedNo
//        /// <summary>問合せ行番号枝番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ行番号枝番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqRowNumDerivedNo
//        {
//            get { return _inqRowNumDerivedNo; }
//            set { _inqRowNumDerivedNo = value; }
//        }

//        /// public propaty name  :  GoodsDivCd
//        /// <summary>商品種別プロパティ</summary>
//        /// <value>0:純正部品 1:優良部品 2:リビルド 3:中古 4:平均相場</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsDivCd
//        {
//            get { return _goodsDivCd; }
//            set { _goodsDivCd = value; }
//        }

//        /// public propaty name  :  RecyclePrtKindCode
//        /// <summary>リサイクル部品種別プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   リサイクル部品種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 RecyclePrtKindCode
//        {
//            get { return _recyclePrtKindCode; }
//            set { _recyclePrtKindCode = value; }
//        }

//        /// public propaty name  :  RecyclePrtKindName
//        /// <summary>リサイクル部品種別名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   リサイクル部品種別名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string RecyclePrtKindName
//        {
//            get { return _recyclePrtKindName; }
//            set { _recyclePrtKindName = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsDiv
//        /// <summary>納品区分プロパティ</summary>
//        /// <value>0:配送,1:引取</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DeliveredGoodsDiv
//        {
//            get { return _deliveredGoodsDiv; }
//            set { _deliveredGoodsDiv = value; }
//        }

//        /// public propaty name  :  HandleDivCode
//        /// <summary>取扱区分プロパティ</summary>
//        /// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   取扱区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 HandleDivCode
//        {
//            get { return _handleDivCode; }
//            set { _handleDivCode = value; }
//        }

//        /// public propaty name  :  GoodsShape
//        /// <summary>商品形態プロパティ</summary>
//        /// <value>1:部品,2:用品</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品形態プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsShape
//        {
//            get { return _goodsShape; }
//            set { _goodsShape = value; }
//        }

//        /// public propaty name  :  DelivrdGdsConfCd
//        /// <summary>納品確認区分プロパティ</summary>
//        /// <value>0:未確認,1:確認</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品確認区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DelivrdGdsConfCd
//        {
//            get { return _delivrdGdsConfCd; }
//            set { _delivrdGdsConfCd = value; }
//        }

//        /// public propaty name  :  DeliGdsCmpltDueDate
//        /// <summary>納品完了予定日プロパティ</summary>
//        /// <value>納品予定日付 YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品完了予定日プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public DateTime DeliGdsCmpltDueDate
//        {
//            get { return _deliGdsCmpltDueDate; }
//            set { _deliGdsCmpltDueDate = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL商品コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsDrCode
//        /// <summary>BL商品コード枝番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コード枝番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 BLGoodsDrCode
//        {
//            get { return _bLGoodsDrCode; }
//            set { _bLGoodsDrCode = value; }
//        }

//        /// public propaty name  :  InqGoodsName
//        /// <summary>問発商品名プロパティ</summary>
//        /// <value>(半角全角混在)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発商品名プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqGoodsName
//        {
//            get { return _inqGoodsName; }
//            set { _inqGoodsName = value; }
//        }

//        /// public propaty name  :  AnsGoodsName
//        /// <summary>回答商品名プロパティ</summary>
//        /// <value>(半角全角混在)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答商品名プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsGoodsName
//        {
//            get { return _ansGoodsName; }
//            set { _ansGoodsName = value; }
//        }

//        /// public propaty name  :  SalesOrderCount
//        /// <summary>発注数プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   発注数プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double SalesOrderCount
//        {
//            get { return _salesOrderCount; }
//            set { _salesOrderCount = value; }
//        }

//        /// public propaty name  :  DeliveredGoodsCount
//        /// <summary>納品数プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   納品数プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double DeliveredGoodsCount
//        {
//            get { return _deliveredGoodsCount; }
//            set { _deliveredGoodsCount = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>商品番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>商品メーカーコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  MakerName
//        /// <summary>メーカー名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカー名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string MakerName
//        {
//            get { return _makerName; }
//            set { _makerName = value; }
//        }

//        /// public propaty name  :  PureGoodsMakerCd
//        /// <summary>純正商品メーカーコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   純正商品メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 PureGoodsMakerCd
//        {
//            get { return _pureGoodsMakerCd; }
//            set { _pureGoodsMakerCd = value; }
//        }

//        /// public propaty name  :  PureMakerName
//        /// <summary>純正商品メーカー名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   純正商品メーカー名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string PureMakerName
//        {
//            get { return _pureMakerName; }
//            set { _pureMakerName = value; }
//        }

//        /// public propaty name  :  InqPureGoodsNo
//        /// <summary>問発純正商品番号プロパティ</summary>
//        /// <value>(半角のみ)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発純正商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqPureGoodsNo
//        {
//            get { return _inqPureGoodsNo; }
//            set { _inqPureGoodsNo = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsNo
//        /// <summary>回答純正商品番号プロパティ</summary>
//        /// <value>(半角のみ)</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答純正商品番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsPureGoodsNo
//        {
//            get { return _ansPureGoodsNo; }
//            set { _ansPureGoodsNo = value; }
//        }

//        /// public propaty name  :  InqPureGoodsName
//        /// <summary>問発純正商品名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発純正商品名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string InqPureGoodsName
//        {
//            get { return _inqPureGoodsName; }
//            set { _inqPureGoodsName = value; }
//        }

//        /// public propaty name  :  AnsPureGoodsName
//        /// <summary>回答純正商品名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答純正商品名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnsPureGoodsName
//        {
//            get { return _ansPureGoodsName; }
//            set { _ansPureGoodsName = value; }
//        }

//        /// public propaty name  :  ListPrice
//        /// <summary>定価プロパティ</summary>
//        /// <value>0:オープン価格</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   定価プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 ListPrice
//        {
//            get { return _listPrice; }
//            set { _listPrice = value; }
//        }

//        /// public propaty name  :  UnitPrice
//        /// <summary>単価プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   単価プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 UnitPrice
//        {
//            get { return _unitPrice; }
//            set { _unitPrice = value; }
//        }

//        /// public propaty name  :  GoodsAddInfo
//        /// <summary>商品補足情報プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品補足情報プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsAddInfo
//        {
//            get { return _goodsAddInfo; }
//            set { _goodsAddInfo = value; }
//        }

//        /// public propaty name  :  RoughRrofit
//        /// <summary>粗利額プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   粗利額プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 RoughRrofit
//        {
//            get { return _roughRrofit; }
//            set { _roughRrofit = value; }
//        }

//        /// public propaty name  :  RoughRate
//        /// <summary>粗利率プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   粗利率プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Double RoughRate
//        {
//            get { return _roughRate; }
//            set { _roughRate = value; }
//        }

//        /// public propaty name  :  AnswerLimitDate
//        /// <summary>回答期限プロパティ</summary>
//        /// <value>YYYYMMDD</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答期限プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AnswerLimitDate
//        {
//            get { return _answerLimitDate; }
//            set { _answerLimitDate = value; }
//        }

//        /// public propaty name  :  CommentDtl
//        /// <summary>備考(明細)プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   備考(明細)プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CommentDtl
//        {
//            get { return _commentDtl; }
//            set { _commentDtl = value; }
//        }

//        /// public propaty name  :  ShelfNo
//        /// <summary>棚番プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   棚番プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string ShelfNo
//        {
//            get { return _shelfNo; }
//            set { _shelfNo = value; }
//        }

//        /// public propaty name  :  AdditionalDivCd
//        /// <summary>追加区分プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   追加区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AdditionalDivCd
//        {
//            get { return _additionalDivCd; }
//            set { _additionalDivCd = value; }
//        }

//        /// public propaty name  :  CorrectDivCD
//        /// <summary>訂正区分プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   訂正区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CorrectDivCD
//        {
//            get { return _correctDivCD; }
//            set { _correctDivCD = value; }
//        }

//        /// public propaty name  :  AcptAnOdrStatus
//        /// <summary>受注ステータスプロパティ</summary>
//        /// <value>10:見積,20:受注,30:売上</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   受注ステータスプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 AcptAnOdrStatus
//        {
//            get { return _acptAnOdrStatus; }
//            set { _acptAnOdrStatus = value; }
//        }

//        /// public propaty name  :  SalesSlipNum
//        /// <summary>売上伝票番号プロパティ</summary>
//        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上伝票番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string SalesSlipNum
//        {
//            get { return _salesSlipNum; }
//            set { _salesSlipNum = value; }
//        }

//        /// public propaty name  :  SalesRowNo
//        /// <summary>売上行番号プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上行番号プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 SalesRowNo
//        {
//            get { return _salesRowNo; }
//            set { _salesRowNo = value; }
//        }

//        /// public propaty name  :  StockDiv
//        /// <summary>在庫区分プロパティ</summary>
//        /// <value>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   在庫区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 StockDiv
//        {
//            get { return _stockDiv; }
//            set { _stockDiv = value; }
//        }

//        /// public propaty name  :  InqOrdDivCd
//        /// <summary>問合せ・発注種別プロパティ</summary>
//        /// <value>1:問合せ 2:発注</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問合せ・発注種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqOrdDivCd
//        {
//            get { return _inqOrdDivCd; }
//            set { _inqOrdDivCd = value; }
//        }

//        /// public propaty name  :  DisplayOrder
//        /// <summary>表示順位プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   表示順位プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 DisplayOrder
//        {
//            get { return _displayOrder; }
//            set { _displayOrder = value; }
//        }

//        /// public propaty name  :  CampaignCode
//        /// <summary>キャンペーンコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   キャンペーンコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CampaignCode
//        {
//            get { return _campaignCode; }
//            set { _campaignCode = value; }
//        }

//        /// public propaty name  :  CampaignName
//        /// <summary>キャンペーン名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   キャンペーン名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CampaignName
//        {
//            get { return _campaignName; }
//            set { _campaignName = value; }
//        }

//        /// public propaty name  :  SalesTotalTaxInc
//        /// <summary>売上伝票合計（税込み）プロパティ</summary>
//        /// <value>売上正価金額＋売上値引金額計（税抜き）＋売上金額消費税額</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 SalesTotalTaxInc
//        {
//            get { return _salesTotalTaxInc; }
//            set { _salesTotalTaxInc = value; }
//        }

//        /// public propaty name  :  SalesSubtotalTax
//        /// <summary>売上小計（税）プロパティ</summary>
//        /// <value>値引後の税額（外税分、内税分の合計）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   売上小計（税）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 SalesSubtotalTax
//        {
//            get { return _salesSubtotalTax; }
//            set { _salesSubtotalTax = value; }
//        }

//        /// public propaty name  :  InqOrdAnsDivCd
//        /// <summary>問発・回答種別プロパティ</summary>
//        /// <value>1:問合せ・発注 2:回答</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   問発・回答種別プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 InqOrdAnsDivCd
//        {
//            get { return _inqOrdAnsDivCd; }
//            set { _inqOrdAnsDivCd = value; }
//        }

//        /// public propaty name  :  ReceiveDateTime
//        /// <summary>受信日時プロパティ</summary>
//        /// <value>（DateTime:精度は100ナノ秒）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   受信日時プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int64 ReceiveDateTime
//        {
//            get { return _receiveDateTime; }
//            set { _receiveDateTime = value; }
//        }

//        /// public propaty name  :  AnswerDeliveryDate
//        /// <summary>回答納期プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   回答納期プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string AnswerDeliveryDate
//        {
//            get { return _answerDeliveryDate; }
//            set { _answerDeliveryDate = value; }
//        }


//        /// <summary>
//        /// SCM売上・回答履歴照会結果クラスワークコンストラクタ
//        /// </summary>
//        /// <returns>SCMAnsHistResultWorkクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスの新しいインスタンスを生成します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public SCMAnsHistResultWork()
//        {
//        }

//    }

//    /// <summary>
//    ///  Ver5.10.1.0用のカスタムシライアライザです。
//    /// </summary>
//    /// <returns>SCMAnsHistResultWorkクラスのインスタンス(object)</returns>
//    /// <remarks>
//    /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムシリアライザを定義します</br>
//    /// <br>Programer        :   自動生成</br>
//    /// </remarks>
//    public class SCMAnsHistResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
//    {
//        #region ICustomSerializationSurrogate メンバ

//        /// <summary>
//        ///  Ver5.10.1.0用のカスタムシリアライザです
//        /// </summary>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムシリアライザを定義します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public void Serialize(System.IO.BinaryWriter writer, object graph)
//        {
//            // TODO:  SCMAnsHistResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
//            if (writer == null)
//                throw new ArgumentNullException();

//            if (graph != null && !(graph is SCMAnsHistResultWork || graph is ArrayList || graph is SCMAnsHistResultWork[]))
//                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMAnsHistResultWork).FullName));

//            if (graph != null && graph is SCMAnsHistResultWork)
//            {
//                Type t = graph.GetType();
//                if (!CustomFormatterServices.NeedCustomSerialization(t))
//                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
//            }

//            //SerializationTypeInfo
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAnsHistResultWork");

//            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
//            int occurrence = 0;     //一般にゼロの場合もありえます
//            if (graph is ArrayList)
//            {
//                serInfo.RetTypeInfo = 0;
//                occurrence = ((ArrayList)graph).Count;
//            }
//            else if (graph is SCMAnsHistResultWork[])
//            {
//                serInfo.RetTypeInfo = 2;
//                occurrence = ((SCMAnsHistResultWork[])graph).Length;
//            }
//            else if (graph is SCMAnsHistResultWork)
//            {
//                serInfo.RetTypeInfo = 1;
//                occurrence = 1;
//            }

//            serInfo.Occurrence = occurrence;		 //繰り返し数	

//            //問合せ先企業コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
//            //問合せ先拠点コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
//            //拠点名称
//            serInfo.MemberInfo.Add(typeof(string)); //SectionGuidNm
//            //得意先コード
//            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
//            //得意先名称
//            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
//            //問合せ番号
//            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
//            //更新年月日
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
//            //更新時間
//            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
//            //回答区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
//            //確定日
//            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
//            //問合せ・発注備考
//            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
//            //問合せ従業員コード
//            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
//            //問合せ従業員名称
//            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
//            //回答従業員コード
//            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
//            //回答従業員名称
//            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
//            //問合せ日
//            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
//            //陸運事務所番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate1Code
//            //陸運事務局名称
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate1Name
//            //車両登録番号（種別）
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate2
//            //車両登録番号（カナ）
//            serInfo.MemberInfo.Add(typeof(string)); //NumberPlate3
//            //車両登録番号（プレート番号）
//            serInfo.MemberInfo.Add(typeof(Int32)); //NumberPlate4
//            //型式指定番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
//            //類別番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
//            //メーカーコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
//            //メーカー名称
//            serInfo.MemberInfo.Add(typeof(string)); //CarMakerName
//            //車種コード
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
//            //車種サブコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
//            //車種名
//            serInfo.MemberInfo.Add(typeof(string)); //ModelName
//            //車検証型式
//            serInfo.MemberInfo.Add(typeof(string)); //CarInspectCertModel
//            //型式（フル型）
//            serInfo.MemberInfo.Add(typeof(string)); //FullModel
//            //車台番号
//            serInfo.MemberInfo.Add(typeof(string)); //FrameNo
//            //車台型式
//            serInfo.MemberInfo.Add(typeof(string)); //FrameModel
//            //シャシーNo
//            serInfo.MemberInfo.Add(typeof(string)); //ChassisNo
//            //車両固有番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
//            //生産年式（NUMタイプ）
//            serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearNum
//            //コメント
//            serInfo.MemberInfo.Add(typeof(string)); //Comment
//            //リペアカラーコード
//            serInfo.MemberInfo.Add(typeof(string)); //RpColorCode
//            //カラー名称1
//            serInfo.MemberInfo.Add(typeof(string)); //ColorName1
//            //トリムコード
//            serInfo.MemberInfo.Add(typeof(string)); //TrimCode
//            //トリム名称
//            serInfo.MemberInfo.Add(typeof(string)); //TrimName
//            //車両走行距離
//            serInfo.MemberInfo.Add(typeof(Int32)); //Mileage
//            //装備オブジェクト
//            serInfo.MemberInfo.Add(typeof(Byte[])); //EquipObj
//            //問合せ行番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
//            //問合せ行番号枝番
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
//            //商品種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDivCd
//            //リサイクル部品種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //RecyclePrtKindCode
//            //リサイクル部品種別名称
//            serInfo.MemberInfo.Add(typeof(string)); //RecyclePrtKindName
//            //納品区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
//            //取扱区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //HandleDivCode
//            //商品形態
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsShape
//            //納品確認区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //DelivrdGdsConfCd
//            //納品完了予定日
//            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
//            //BL商品コード
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
//            //BL商品コード枝番
//            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
//            //問発商品名
//            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
//            //回答商品名
//            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
//            //発注数
//            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
//            //納品数
//            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
//            //商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
//            //商品メーカーコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
//            //メーカー名称
//            serInfo.MemberInfo.Add(typeof(string)); //MakerName
//            //純正商品メーカーコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
//            //純正商品メーカー名称
//            serInfo.MemberInfo.Add(typeof(string)); //PureMakerName
//            //問発純正商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
//            //回答純正商品番号
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
//            //問発純正商品名称
//            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsName
//            //回答純正商品名称
//            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsName
//            //定価
//            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
//            //単価
//            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
//            //商品補足情報
//            serInfo.MemberInfo.Add(typeof(string)); //GoodsAddInfo
//            //粗利額
//            serInfo.MemberInfo.Add(typeof(Int64)); //RoughRrofit
//            //粗利率
//            serInfo.MemberInfo.Add(typeof(Double)); //RoughRate
//            //回答期限
//            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerLimitDate
//            //備考(明細)
//            serInfo.MemberInfo.Add(typeof(string)); //CommentDtl
//            //棚番
//            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
//            //追加区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //AdditionalDivCd
//            //訂正区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //CorrectDivCD
//            //受注ステータス
//            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
//            //売上伝票番号
//            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
//            //売上行番号
//            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
//            //在庫区分
//            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
//            //問合せ・発注種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
//            //表示順位
//            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
//            //キャンペーンコード
//            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
//            //キャンペーン名称
//            serInfo.MemberInfo.Add(typeof(string)); //CampaignName
//            //売上伝票合計（税込み）
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
//            //売上小計（税）
//            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
//            //問発・回答種別
//            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
//            //受信日時
//            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
//            //回答納期
//            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate


//            serInfo.Serialize(writer, serInfo);
//            if (graph is SCMAnsHistResultWork)
//            {
//                SCMAnsHistResultWork temp = (SCMAnsHistResultWork)graph;

//                SetSCMAnsHistResultWork(writer, temp);
//            }
//            else
//            {
//                ArrayList lst = null;
//                if (graph is SCMAnsHistResultWork[])
//                {
//                    lst = new ArrayList();
//                    lst.AddRange((SCMAnsHistResultWork[])graph);
//                }
//                else
//                {
//                    lst = (ArrayList)graph;
//                }

//                foreach (SCMAnsHistResultWork temp in lst)
//                {
//                    SetSCMAnsHistResultWork(writer, temp);
//                }

//            }


//        }


//        /// <summary>
//        /// SCMAnsHistResultWorkメンバ数(publicプロパティ数)
//        /// </summary>
//        private const int currentMemberCount = 91;

//        /// <summary>
//        ///  SCMAnsHistResultWorkインスタンス書き込み
//        /// </summary>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkのインスタンスを書き込み</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        private void SetSCMAnsHistResultWork(System.IO.BinaryWriter writer, SCMAnsHistResultWork temp)
//        {
//            //問合せ先企業コード
//            writer.Write(temp.InqOtherEpCd);
//            //問合せ先拠点コード
//            writer.Write(temp.InqOtherSecCd);
//            //拠点名称
//            writer.Write(temp.SectionGuidNm);
//            //得意先コード
//            writer.Write(temp.CustomerCode);
//            //得意先名称
//            writer.Write(temp.CustomerName);
//            //問合せ番号
//            writer.Write(temp.InquiryNumber);
//            //更新年月日
//            writer.Write((Int64)temp.UpdateDate.Ticks);
//            //更新時間
//            writer.Write(temp.UpdateTime);
//            //回答区分
//            writer.Write(temp.AnswerDivCd);
//            //確定日
//            writer.Write(temp.JudgementDate);
//            //問合せ・発注備考
//            writer.Write(temp.InqOrdNote);
//            //問合せ従業員コード
//            writer.Write(temp.InqEmployeeCd);
//            //問合せ従業員名称
//            writer.Write(temp.InqEmployeeNm);
//            //回答従業員コード
//            writer.Write(temp.AnsEmployeeCd);
//            //回答従業員名称
//            writer.Write(temp.AnsEmployeeNm);
//            //問合せ日
//            writer.Write(temp.InquiryDate);
//            //陸運事務所番号
//            writer.Write(temp.NumberPlate1Code);
//            //陸運事務局名称
//            writer.Write(temp.NumberPlate1Name);
//            //車両登録番号（種別）
//            writer.Write(temp.NumberPlate2);
//            //車両登録番号（カナ）
//            writer.Write(temp.NumberPlate3);
//            //車両登録番号（プレート番号）
//            writer.Write(temp.NumberPlate4);
//            //型式指定番号
//            writer.Write(temp.ModelDesignationNo);
//            //類別番号
//            writer.Write(temp.CategoryNo);
//            //メーカーコード
//            writer.Write(temp.MakerCode);
//            //メーカー名称
//            writer.Write(temp.CarMakerName);
//            //車種コード
//            writer.Write(temp.ModelCode);
//            //車種サブコード
//            writer.Write(temp.ModelSubCode);
//            //車種名
//            writer.Write(temp.ModelName);
//            //車検証型式
//            writer.Write(temp.CarInspectCertModel);
//            //型式（フル型）
//            writer.Write(temp.FullModel);
//            //車台番号
//            writer.Write(temp.FrameNo);
//            //車台型式
//            writer.Write(temp.FrameModel);
//            //シャシーNo
//            writer.Write(temp.ChassisNo);
//            //車両固有番号
//            writer.Write(temp.CarProperNo);
//            //生産年式（NUMタイプ）
//            writer.Write(temp.ProduceTypeOfYearNum);
//            //コメント
//            writer.Write(temp.Comment);
//            //リペアカラーコード
//            writer.Write(temp.RpColorCode);
//            //カラー名称1
//            writer.Write(temp.ColorName1);
//            //トリムコード
//            writer.Write(temp.TrimCode);
//            //トリム名称
//            writer.Write(temp.TrimName);
//            //車両走行距離
//            writer.Write(temp.Mileage);
//            //装備オブジェクト
//            writer.Write(temp.EquipObj.Length);
//            writer.Write(temp.EquipObj);
//            //問合せ行番号
//            writer.Write(temp.InqRowNumber);
//            //問合せ行番号枝番
//            writer.Write(temp.InqRowNumDerivedNo);
//            //商品種別
//            writer.Write(temp.GoodsDivCd);
//            //リサイクル部品種別
//            writer.Write(temp.RecyclePrtKindCode);
//            //リサイクル部品種別名称
//            writer.Write(temp.RecyclePrtKindName);
//            //納品区分
//            writer.Write(temp.DeliveredGoodsDiv);
//            //取扱区分
//            writer.Write(temp.HandleDivCode);
//            //商品形態
//            writer.Write(temp.GoodsShape);
//            //納品確認区分
//            writer.Write(temp.DelivrdGdsConfCd);
//            //納品完了予定日
//            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
//            //BL商品コード
//            writer.Write(temp.BLGoodsCode);
//            //BL商品コード枝番
//            writer.Write(temp.BLGoodsDrCode);
//            //問発商品名
//            writer.Write(temp.InqGoodsName);
//            //回答商品名
//            writer.Write(temp.AnsGoodsName);
//            //発注数
//            writer.Write(temp.SalesOrderCount);
//            //納品数
//            writer.Write(temp.DeliveredGoodsCount);
//            //商品番号
//            writer.Write(temp.GoodsNo);
//            //商品メーカーコード
//            writer.Write(temp.GoodsMakerCd);
//            //メーカー名称
//            writer.Write(temp.MakerName);
//            //純正商品メーカーコード
//            writer.Write(temp.PureGoodsMakerCd);
//            //純正商品メーカー名称
//            writer.Write(temp.PureMakerName);
//            //問発純正商品番号
//            writer.Write(temp.InqPureGoodsNo);
//            //回答純正商品番号
//            writer.Write(temp.AnsPureGoodsNo);
//            //問発純正商品名称
//            writer.Write(temp.InqPureGoodsName);
//            //回答純正商品名称
//            writer.Write(temp.AnsPureGoodsName);
//            //定価
//            writer.Write(temp.ListPrice);
//            //単価
//            writer.Write(temp.UnitPrice);
//            //商品補足情報
//            writer.Write(temp.GoodsAddInfo);
//            //粗利額
//            writer.Write(temp.RoughRrofit);
//            //粗利率
//            writer.Write(temp.RoughRate);
//            //回答期限
//            writer.Write(temp.AnswerLimitDate);
//            //備考(明細)
//            writer.Write(temp.CommentDtl);
//            //棚番
//            writer.Write(temp.ShelfNo);
//            //追加区分
//            writer.Write(temp.AdditionalDivCd);
//            //訂正区分
//            writer.Write(temp.CorrectDivCD);
//            //受注ステータス
//            writer.Write(temp.AcptAnOdrStatus);
//            //売上伝票番号
//            writer.Write(temp.SalesSlipNum);
//            //売上行番号
//            writer.Write(temp.SalesRowNo);
//            //在庫区分
//            writer.Write(temp.StockDiv);
//            //問合せ・発注種別
//            writer.Write(temp.InqOrdDivCd);
//            //表示順位
//            writer.Write(temp.DisplayOrder);
//            //キャンペーンコード
//            writer.Write(temp.CampaignCode);
//            //キャンペーン名称
//            writer.Write(temp.CampaignName);
//            //売上伝票合計（税込み）
//            writer.Write(temp.SalesTotalTaxInc);
//            //売上小計（税）
//            writer.Write(temp.SalesSubtotalTax);
//            //問発・回答種別
//            writer.Write(temp.InqOrdAnsDivCd);
//            //受信日時
//            writer.Write(temp.ReceiveDateTime);
//            //回答納期
//            writer.Write(temp.AnswerDeliveryDate);

//        }

//        /// <summary>
//        ///  SCMAnsHistResultWorkインスタンス取得
//        /// </summary>
//        /// <returns>SCMAnsHistResultWorkクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkのインスタンスを取得します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        private SCMAnsHistResultWork GetSCMAnsHistResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
//        {
//            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
//            // serInfo.MemberInfo.Count < currentMemberCount
//            // のケースについての配慮が必要になります。

//            SCMAnsHistResultWork temp = new SCMAnsHistResultWork();

//            //問合せ先企業コード
//            temp.InqOtherEpCd = reader.ReadString();
//            //問合せ先拠点コード
//            temp.InqOtherSecCd = reader.ReadString();
//            //拠点名称
//            temp.SectionGuidNm = reader.ReadString();
//            //得意先コード
//            temp.CustomerCode = reader.ReadInt32();
//            //得意先名称
//            temp.CustomerName = reader.ReadString();
//            //問合せ番号
//            temp.InquiryNumber = reader.ReadInt64();
//            //更新年月日
//            temp.UpdateDate = new DateTime(reader.ReadInt64());
//            //更新時間
//            temp.UpdateTime = reader.ReadInt32();
//            //回答区分
//            temp.AnswerDivCd = reader.ReadInt32();
//            //確定日
//            temp.JudgementDate = reader.ReadInt32();
//            //問合せ・発注備考
//            temp.InqOrdNote = reader.ReadString();
//            //問合せ従業員コード
//            temp.InqEmployeeCd = reader.ReadString();
//            //問合せ従業員名称
//            temp.InqEmployeeNm = reader.ReadString();
//            //回答従業員コード
//            temp.AnsEmployeeCd = reader.ReadString();
//            //回答従業員名称
//            temp.AnsEmployeeNm = reader.ReadString();
//            //問合せ日
//            temp.InquiryDate = reader.ReadInt32();
//            //陸運事務所番号
//            temp.NumberPlate1Code = reader.ReadInt32();
//            //陸運事務局名称
//            temp.NumberPlate1Name = reader.ReadString();
//            //車両登録番号（種別）
//            temp.NumberPlate2 = reader.ReadString();
//            //車両登録番号（カナ）
//            temp.NumberPlate3 = reader.ReadString();
//            //車両登録番号（プレート番号）
//            temp.NumberPlate4 = reader.ReadInt32();
//            //型式指定番号
//            temp.ModelDesignationNo = reader.ReadInt32();
//            //類別番号
//            temp.CategoryNo = reader.ReadInt32();
//            //メーカーコード
//            temp.MakerCode = reader.ReadInt32();
//            //メーカー名称
//            temp.CarMakerName = reader.ReadString();
//            //車種コード
//            temp.ModelCode = reader.ReadInt32();
//            //車種サブコード
//            temp.ModelSubCode = reader.ReadInt32();
//            //車種名
//            temp.ModelName = reader.ReadString();
//            //車検証型式
//            temp.CarInspectCertModel = reader.ReadString();
//            //型式（フル型）
//            temp.FullModel = reader.ReadString();
//            //車台番号
//            temp.FrameNo = reader.ReadString();
//            //車台型式
//            temp.FrameModel = reader.ReadString();
//            //シャシーNo
//            temp.ChassisNo = reader.ReadString();
//            //車両固有番号
//            temp.CarProperNo = reader.ReadInt32();
//            //生産年式（NUMタイプ）
//            temp.ProduceTypeOfYearNum = reader.ReadInt32();
//            //コメント
//            temp.Comment = reader.ReadString();
//            //リペアカラーコード
//            temp.RpColorCode = reader.ReadString();
//            //カラー名称1
//            temp.ColorName1 = reader.ReadString();
//            //トリムコード
//            temp.TrimCode = reader.ReadString();
//            //トリム名称
//            temp.TrimName = reader.ReadString();
//            //車両走行距離
//            temp.Mileage = reader.ReadInt32();
//            //装備オブジェクト
//            int equipObjLength = reader.ReadInt32();
//            temp.EquipObj = reader.ReadBytes(equipObjLength);
//            //問合せ行番号
//            temp.InqRowNumber = reader.ReadInt32();
//            //問合せ行番号枝番
//            temp.InqRowNumDerivedNo = reader.ReadInt32();
//            //商品種別
//            temp.GoodsDivCd = reader.ReadInt32();
//            //リサイクル部品種別
//            temp.RecyclePrtKindCode = reader.ReadInt32();
//            //リサイクル部品種別名称
//            temp.RecyclePrtKindName = reader.ReadString();
//            //納品区分
//            temp.DeliveredGoodsDiv = reader.ReadInt32();
//            //取扱区分
//            temp.HandleDivCode = reader.ReadInt32();
//            //商品形態
//            temp.GoodsShape = reader.ReadInt32();
//            //納品確認区分
//            temp.DelivrdGdsConfCd = reader.ReadInt32();
//            //納品完了予定日
//            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
//            //BL商品コード
//            temp.BLGoodsCode = reader.ReadInt32();
//            //BL商品コード枝番
//            temp.BLGoodsDrCode = reader.ReadInt32();
//            //問発商品名
//            temp.InqGoodsName = reader.ReadString();
//            //回答商品名
//            temp.AnsGoodsName = reader.ReadString();
//            //発注数
//            temp.SalesOrderCount = reader.ReadDouble();
//            //納品数
//            temp.DeliveredGoodsCount = reader.ReadDouble();
//            //商品番号
//            temp.GoodsNo = reader.ReadString();
//            //商品メーカーコード
//            temp.GoodsMakerCd = reader.ReadInt32();
//            //メーカー名称
//            temp.MakerName = reader.ReadString();
//            //純正商品メーカーコード
//            temp.PureGoodsMakerCd = reader.ReadInt32();
//            //純正商品メーカー名称
//            temp.PureMakerName = reader.ReadString();
//            //問発純正商品番号
//            temp.InqPureGoodsNo = reader.ReadString();
//            //回答純正商品番号
//            temp.AnsPureGoodsNo = reader.ReadString();
//            //問発純正商品名称
//            temp.InqPureGoodsName = reader.ReadString();
//            //回答純正商品名称
//            temp.AnsPureGoodsName = reader.ReadString();
//            //定価
//            temp.ListPrice = reader.ReadInt64();
//            //単価
//            temp.UnitPrice = reader.ReadInt64();
//            //商品補足情報
//            temp.GoodsAddInfo = reader.ReadString();
//            //粗利額
//            temp.RoughRrofit = reader.ReadInt64();
//            //粗利率
//            temp.RoughRate = reader.ReadDouble();
//            //回答期限
//            temp.AnswerLimitDate = reader.ReadInt32();
//            //備考(明細)
//            temp.CommentDtl = reader.ReadString();
//            //棚番
//            temp.ShelfNo = reader.ReadString();
//            //追加区分
//            temp.AdditionalDivCd = reader.ReadInt32();
//            //訂正区分
//            temp.CorrectDivCD = reader.ReadInt32();
//            //受注ステータス
//            temp.AcptAnOdrStatus = reader.ReadInt32();
//            //売上伝票番号
//            temp.SalesSlipNum = reader.ReadString();
//            //売上行番号
//            temp.SalesRowNo = reader.ReadInt32();
//            //在庫区分
//            temp.StockDiv = reader.ReadInt32();
//            //問合せ・発注種別
//            temp.InqOrdDivCd = reader.ReadInt32();
//            //表示順位
//            temp.DisplayOrder = reader.ReadInt32();
//            //キャンペーンコード
//            temp.CampaignCode = reader.ReadInt32();
//            //キャンペーン名称
//            temp.CampaignName = reader.ReadString();
//            //売上伝票合計（税込み）
//            temp.SalesTotalTaxInc = reader.ReadInt64();
//            //売上小計（税）
//            temp.SalesSubtotalTax = reader.ReadInt64();
//            //問発・回答種別
//            temp.InqOrdAnsDivCd = reader.ReadInt32();
//            //受信日時
//            temp.ReceiveDateTime = reader.ReadInt64();
//            //回答納期
//            temp.AnswerDeliveryDate = reader.ReadString();


//            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
//            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
//            //型情報にしたがって、ストリームから情報を読み出します...といっても
//            //読み出して捨てることになります。
//            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
//            {
//                //byte[],char[]をデシリアライズする直前に、そのlengthが
//                //デシリアライズされているケースがある、byte[],char[]の
//                //デシリアライズにはlengthが必要なのでint型のデータをデ
//                //シリアライズした場合は、この値をこの変数に退避します。
//                int optCount = 0;
//                object oMemberType = serInfo.MemberInfo[k];
//                if (oMemberType is Type)
//                {
//                    Type t = (Type)oMemberType;
//                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
//                    if (t.Equals(typeof(int)))
//                    {
//                        optCount = Convert.ToInt32(oData);
//                    }
//                    else
//                    {
//                        optCount = 0;
//                    }
//                }
//                else if (oMemberType is string)
//                {
//                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
//                    object userData = formatter.Deserialize(reader);  //読み飛ばし
//                }
//            }
//            return temp;
//        }

//        /// <summary>
//        ///  Ver5.10.1.0用のカスタムデシリアライザです
//        /// </summary>
//        /// <returns>SCMAnsHistResultWorkクラスのインスタンス(object)</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   SCMAnsHistResultWorkクラスのカスタムデシリアライザを定義します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public object Deserialize(System.IO.BinaryReader reader)
//        {
//            object retValue = null;
//            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
//            ArrayList lst = new ArrayList();
//            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
//            {
//                SCMAnsHistResultWork temp = GetSCMAnsHistResultWork(reader, serInfo);
//                lst.Add(temp);
//            }
//            switch (serInfo.RetTypeInfo)
//            {
//                case 0:
//                    retValue = lst;
//                    break;
//                case 1:
//                    retValue = lst[0];
//                    break;
//                case 2:
//                    retValue = (SCMAnsHistResultWork[])lst.ToArray(typeof(SCMAnsHistResultWork));
//                    break;
//            }
//            return retValue;
//        }

//        #endregion
//    }

//}
#endregion
// 2009.08.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
