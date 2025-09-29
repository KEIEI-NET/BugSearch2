using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdDtInq
	/// <summary>
	///                      SCM受発注明細データ（問合せ・発注）
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受発注明細データ（問合せ・発注）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/7  寺坂　誉志</br>
	/// <br>                 :   添付ファイル(明細),添付ファイル名(明細)</br>
	/// <br>                 :   削除</br>
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   追加</br>
	/// <br>Update Note      :   2009/5/15  柏原　頼人</br>
	/// <br>                 :   表示順位を追加</br>
	/// <br>Update Note      :   2009/5/19  岩本　勇</br>
	/// <br>                 :   商品種別の備考変更、リサイクル部品種別、</br>
	/// <br>                 :   リサイクル部品種別名称追加、明細取込区分削除</br>
	/// <br>                 :   回答納期追加</br>
	/// <br>Update Note      :   2009/5/22  岩本　勇</br>
	/// <br>                 :   商品種別の備考を削除</br>
	/// <br>Update Note      :   2009/5/22  寺坂　誉志</br>
	/// <br>                 :   最新識別区分</br>
	/// <br>                 :   追加</br>
	/// <br>Update Note      :   2009/6/1  岩本　勇</br>
	/// <br>                 :   商品メーカー名称追加、純正商品メーカー</br>
	/// <br>                 :   コードの桁数変更</br>
	/// <br>Update Note      :   2009/6/11  寺坂　誉志</br>
	/// <br>                 :   商品名（カナ）、純正商品番号</br>
	/// <br>                 :   削除</br>
	/// <br>                 :   問発商品名、回答商品名、問発純正商品番号</br>
	/// <br>                 :   回答純正商品番号</br>
	/// <br>                 :   追加</br>
	/// <br>Update Note      :   2010/5/17  柏原　頼人</br>
	/// <br>                 :   キャンセル状態区分、PM受注ステータス</br>
	/// <br>                 :   PM売上伝票番号、PM売上行番号</br>
	/// <br>                 :   追加</br>
	/// <br>                 :   商品種別の備考に値引きを追加</br>
	/// <br>Update Note      :   2011/2/1  寺坂　誉志</br>
	/// <br>                 :   明細取込区分</br>
	/// <br>                 :   追加</br>
	/// <br>Update Note      :   2011/4/19  柏原　頼人</br>
	/// <br>                 :   PM倉庫コード</br>
	/// <br>                 :   PM倉庫名称</br>
	/// <br>                 :   PM棚番</br>
	/// <br>                 :   追加</br>
	/// <br>Update Note      :   2011/8/1  植田　知弘</br>
	/// <br>                 :   PM現在個数</br>
	/// <br>                 :   セット部品メーカーコード</br>
	/// <br>                 :   セット部品番号</br>
	/// <br>                 :   セット部品親子番号</br>
	/// <br>                 :   追加</br>
	/// </remarks>
	[Serializable]
	public class ScmOdDtInq
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>問合せ番号</summary>
		private Int64 _inquiryNumber;

		/// <summary>更新年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>更新時分秒ミリ秒</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>問合せ行番号</summary>
		private Int32 _inqRowNumber;

		/// <summary>問合せ行番号枝番</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>問合せ元明細識別GUID</summary>
		private Guid _inqOrgDtlDiscGuid;

		/// <summary>問合せ先明細識別GUID</summary>
		/// <remarks>回答データの場合有効、問合せ／発注元の明細GUIDを設定</remarks>
		private Guid _inqOthDtlDiscGuid;

		/// <summary>商品種別</summary>
		/// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き</remarks>
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

		/// <summary>回答納期</summary>
		private string _answerDeliveryDate = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード枝番</summary>
		private Int32 _bLGoodsDrCode;

		/// <summary>問発商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _inqGoodsName = "";

		/// <summary>回答商品名</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _ansGoodsName = "";

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>納品数</summary>
		private Double _deliveredGoodsCount;

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品メーカー名称</summary>
		private string _goodsMakerNm = "";

		/// <summary>純正商品メーカーコード</summary>
		private Int32 _pureGoodsMakerCd;

		/// <summary>問発純正商品番号</summary>
		/// <remarks>(半角のみ)</remarks>
		private string _inqPureGoodsNo = "";

		/// <summary>回答純正商品番号</summary>
		/// <remarks>(半角のみ)</remarks>
		private string _ansPureGoodsNo = "";

		/// <summary>定価</summary>
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
		private DateTime _answerLimitDate;

		/// <summary>備考(明細)</summary>
		private string _commentDtl = "";

		/// <summary>棚番</summary>
		private string _shelfNo = "";

		/// <summary>追加区分</summary>
		private Int32 _additionalDivCd;

		/// <summary>訂正区分</summary>
		private Int32 _correctDivCD;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>最新識別区分</summary>
		/// <remarks>0:最新データ 1:旧データ</remarks>
		private Int16 _latestDiscCode;

		/// <summary>キャンセル状態区分</summary>
		/// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
		private Int16 _cancelCndtinDiv;

		/// <summary>PM受注ステータス</summary>
		/// <remarks>10：見積 20:受注 30:売上 40:出荷</remarks>
		private Int32 _pMAcptAnOdrStatus;

		/// <summary>PM売上伝票番号</summary>
		/// <remarks>PMの売上伝票番号</remarks>
		private Int32 _pMSalesSlipNum;

		/// <summary>PM売上行番号</summary>
		private Int32 _pMSalesRowNo;

		/// <summary>明細取込区分</summary>
		/// <remarks>0:未取込 1:取込済</remarks>
		private Int32 _dtlTakeinDivCd;

		/// <summary>PM倉庫コード</summary>
		private string _pmWarehouseCd = "";

		/// <summary>PM倉庫名称</summary>
		private string _pmWarehouseName = "";

		/// <summary>PM棚番</summary>
		private string _pmShelfNo = "";

		/// <summary>PM現在個数</summary>
		private Double _pmPrsntCount;

		/// <summary>セット部品メーカーコード</summary>
		private Int32 _setPartsMkrCd;

		/// <summary>セット部品番号</summary>
		private string _setPartsNumber = "";

		/// <summary>セット部品親子番号</summary>
		/// <remarks>0:親,1-*:子</remarks>
		private Int32 _setPartsMainSubNo;


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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get { return _inqOriginalEpCd; }
			set { _inqOriginalEpCd = value; }
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>問合せ元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get { return _inqOriginalSecCd; }
			set { _inqOriginalSecCd = value; }
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get { return _inqOtherEpCd; }
			set { _inqOtherEpCd = value; }
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
			get { return _inqOtherSecCd; }
			set { _inqOtherSecCd = value; }
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
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
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
			get { return _updateDate; }
			set { _updateDate = value; }
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>更新年月日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>更新年月日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>更新年月日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>更新年月日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新年月日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
			set { }
		}

		/// public propaty name  :  UpdateTime
		/// <summary>更新時分秒ミリ秒プロパティ</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新時分秒ミリ秒プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get { return _updateTime; }
			set { _updateTime = value; }
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
			get { return _inqRowNumber; }
			set { _inqRowNumber = value; }
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
			get { return _inqRowNumDerivedNo; }
			set { _inqRowNumDerivedNo = value; }
		}

		/// public propaty name  :  InqOrgDtlDiscGuid
		/// <summary>問合せ元明細識別GUIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元明細識別GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid InqOrgDtlDiscGuid
		{
			get { return _inqOrgDtlDiscGuid; }
			set { _inqOrgDtlDiscGuid = value; }
		}

		/// public propaty name  :  InqOthDtlDiscGuid
		/// <summary>問合せ先明細識別GUIDプロパティ</summary>
		/// <value>回答データの場合有効、問合せ／発注元の明細GUIDを設定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先明細識別GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid InqOthDtlDiscGuid
		{
			get { return _inqOthDtlDiscGuid; }
			set { _inqOthDtlDiscGuid = value; }
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>商品種別プロパティ</summary>
		/// <value>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get { return _goodsDivCd; }
			set { _goodsDivCd = value; }
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
			get { return _recyclePrtKindCode; }
			set { _recyclePrtKindCode = value; }
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
			get { return _recyclePrtKindName; }
			set { _recyclePrtKindName = value; }
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
			get { return _deliveredGoodsDiv; }
			set { _deliveredGoodsDiv = value; }
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
			get { return _handleDivCode; }
			set { _handleDivCode = value; }
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
			get { return _goodsShape; }
			set { _goodsShape = value; }
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
			get { return _delivrdGdsConfCd; }
			set { _delivrdGdsConfCd = value; }
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
			get { return _deliGdsCmpltDueDate; }
			set { _deliGdsCmpltDueDate = value; }
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>納品完了予定日 和暦プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
			set { }
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>納品完了予定日 和暦(略)プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>納品完了予定日 西暦プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>納品完了予定日 西暦(略)プロパティ</summary>
		/// <value>納品予定日付 YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
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
			get { return _answerDeliveryDate; }
			set { _answerDeliveryDate = value; }
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
			get { return _bLGoodsCode; }
			set { _bLGoodsCode = value; }
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
			get { return _bLGoodsDrCode; }
			set { _bLGoodsDrCode = value; }
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
			get { return _inqGoodsName; }
			set { _inqGoodsName = value; }
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
			get { return _ansGoodsName; }
			set { _ansGoodsName = value; }
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
			get { return _salesOrderCount; }
			set { _salesOrderCount = value; }
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
			get { return _deliveredGoodsCount; }
			set { _deliveredGoodsCount = value; }
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
			get { return _goodsNo; }
			set { _goodsNo = value; }
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
			get { return _goodsMakerCd; }
			set { _goodsMakerCd = value; }
		}

		/// public propaty name  :  GoodsMakerNm
		/// <summary>商品メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMakerNm
		{
			get { return _goodsMakerNm; }
			set { _goodsMakerNm = value; }
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
			get { return _pureGoodsMakerCd; }
			set { _pureGoodsMakerCd = value; }
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
			get { return _inqPureGoodsNo; }
			set { _inqPureGoodsNo = value; }
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
			get { return _ansPureGoodsNo; }
			set { _ansPureGoodsNo = value; }
		}

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get { return _listPrice; }
			set { _listPrice = value; }
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
			get { return _unitPrice; }
			set { _unitPrice = value; }
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
			get { return _goodsAddInfo; }
			set { _goodsAddInfo = value; }
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
			get { return _roughRrofit; }
			set { _roughRrofit = value; }
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
			get { return _roughRate; }
			set { _roughRate = value; }
		}

		/// public propaty name  :  AnswerLimitDate
		/// <summary>回答期限プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AnswerLimitDate
		{
			get { return _answerLimitDate; }
			set { _answerLimitDate = value; }
		}

		/// public propaty name  :  AnswerLimitDateJpFormal
		/// <summary>回答期限 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerLimitDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateJpInFormal
		/// <summary>回答期限 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerLimitDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateAdFormal
		/// <summary>回答期限 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerLimitDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateAdInFormal
		/// <summary>回答期限 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   回答期限 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AnswerLimitDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _answerLimitDate); }
			set { }
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
			get { return _commentDtl; }
			set { _commentDtl = value; }
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
			get { return _shelfNo; }
			set { _shelfNo = value; }
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
			get { return _additionalDivCd; }
			set { _additionalDivCd = value; }
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
			get { return _correctDivCD; }
			set { _correctDivCD = value; }
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
			get { return _inqOrdDivCd; }
			set { _inqOrdDivCd = value; }
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
			get { return _displayOrder; }
			set { _displayOrder = value; }
		}

		/// public propaty name  :  LatestDiscCode
		/// <summary>最新識別区分プロパティ</summary>
		/// <value>0:最新データ 1:旧データ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最新識別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 LatestDiscCode
		{
			get { return _latestDiscCode; }
			set { _latestDiscCode = value; }
		}

		/// public propaty name  :  CancelCndtinDiv
		/// <summary>キャンセル状態区分プロパティ</summary>
		/// <value>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   キャンセル状態区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 CancelCndtinDiv
		{
			get { return _cancelCndtinDiv; }
			set { _cancelCndtinDiv = value; }
		}

		/// public propaty name  :  PMAcptAnOdrStatus
		/// <summary>PM受注ステータスプロパティ</summary>
		/// <value>10：見積 20:受注 30:売上 40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM受注ステータスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PMAcptAnOdrStatus
		{
			get { return _pMAcptAnOdrStatus; }
			set { _pMAcptAnOdrStatus = value; }
		}

		/// public propaty name  :  PMSalesSlipNum
		/// <summary>PM売上伝票番号プロパティ</summary>
		/// <value>PMの売上伝票番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM売上伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PMSalesSlipNum
		{
			get { return _pMSalesSlipNum; }
			set { _pMSalesSlipNum = value; }
		}

		/// public propaty name  :  PMSalesRowNo
		/// <summary>PM売上行番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM売上行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PMSalesRowNo
		{
			get { return _pMSalesRowNo; }
			set { _pMSalesRowNo = value; }
		}

		/// public propaty name  :  DtlTakeinDivCd
		/// <summary>明細取込区分プロパティ</summary>
		/// <value>0:未取込 1:取込済</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細取込区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DtlTakeinDivCd
		{
			get { return _dtlTakeinDivCd; }
			set { _dtlTakeinDivCd = value; }
		}

		/// public propaty name  :  PmWarehouseCd
		/// <summary>PM倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmWarehouseCd
		{
			get { return _pmWarehouseCd; }
			set { _pmWarehouseCd = value; }
		}

		/// public propaty name  :  PmWarehouseName
		/// <summary>PM倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmWarehouseName
		{
			get { return _pmWarehouseName; }
			set { _pmWarehouseName = value; }
		}

		/// public propaty name  :  PmShelfNo
		/// <summary>PM棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PmShelfNo
		{
			get { return _pmShelfNo; }
			set { _pmShelfNo = value; }
		}

		/// public propaty name  :  PmPrsntCount
		/// <summary>PM現在個数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM現在個数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PmPrsntCount
		{
			get{return _pmPrsntCount;}
			set{_pmPrsntCount = value;}
		}

		/// public propaty name  :  SetPartsMkrCd
		/// <summary>セット部品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット部品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetPartsMkrCd
		{
			get{return _setPartsMkrCd;}
			set{_setPartsMkrCd = value;}
		}

		/// public propaty name  :  SetPartsNumber
		/// <summary>セット部品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット部品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetPartsNumber
		{
			get{return _setPartsNumber;}
			set{_setPartsNumber = value;}
		}

		/// public propaty name  :  SetPartsMainSubNo
		/// <summary>セット部品親子番号プロパティ</summary>
		/// <value>0:親,1-*:子</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット部品親子番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetPartsMainSubNo
		{
			get{return _setPartsMainSubNo;}
			set{_setPartsMainSubNo = value;}
		}


		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）コンストラクタ
		/// </summary>
		/// <returns>ScmOdDtInqクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdDtInq()
		{
		}

		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="inqOriginalEpCd">問合せ元企業コード</param>
		/// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
		/// <param name="inqOtherEpCd">問合せ先企業コード</param>
		/// <param name="inqOtherSecCd">問合せ先拠点コード</param>
		/// <param name="inquiryNumber">問合せ番号</param>
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqRowNumber">問合せ行番号</param>
		/// <param name="inqRowNumDerivedNo">問合せ行番号枝番</param>
		/// <param name="inqOrgDtlDiscGuid">問合せ元明細識別GUID</param>
		/// <param name="inqOthDtlDiscGuid">問合せ先明細識別GUID(回答データの場合有効、問合せ／発注元の明細GUIDを設定)</param>
		/// <param name="goodsDivCd">商品種別(0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き)</param>
		/// <param name="recyclePrtKindCode">リサイクル部品種別</param>
		/// <param name="recyclePrtKindName">リサイクル部品種別名称</param>
		/// <param name="deliveredGoodsDiv">納品区分(0:配送,1:引取)</param>
		/// <param name="handleDivCode">取扱区分(0:取り扱い品,1:納期確認中,2:未取り扱い品)</param>
		/// <param name="goodsShape">商品形態(1:部品,2:用品)</param>
		/// <param name="delivrdGdsConfCd">納品確認区分(0:未確認,1:確認)</param>
		/// <param name="deliGdsCmpltDueDate">納品完了予定日(納品予定日付 YYYYMMDD)</param>
		/// <param name="answerDeliveryDate">回答納期</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsDrCode">BL商品コード枝番</param>
		/// <param name="inqGoodsName">問発商品名((半角全角混在))</param>
		/// <param name="ansGoodsName">回答商品名((半角全角混在))</param>
		/// <param name="salesOrderCount">発注数</param>
		/// <param name="deliveredGoodsCount">納品数</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="goodsMakerNm">商品メーカー名称</param>
		/// <param name="pureGoodsMakerCd">純正商品メーカーコード</param>
		/// <param name="inqPureGoodsNo">問発純正商品番号((半角のみ))</param>
		/// <param name="ansPureGoodsNo">回答純正商品番号((半角のみ))</param>
		/// <param name="listPrice">定価</param>
		/// <param name="unitPrice">単価</param>
		/// <param name="goodsAddInfo">商品補足情報</param>
		/// <param name="roughRrofit">粗利額</param>
		/// <param name="roughRate">粗利率</param>
		/// <param name="answerLimitDate">回答期限(YYYYMMDD)</param>
		/// <param name="commentDtl">備考(明細)</param>
		/// <param name="shelfNo">棚番</param>
		/// <param name="additionalDivCd">追加区分</param>
		/// <param name="correctDivCD">訂正区分</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="latestDiscCode">最新識別区分(0:最新データ 1:旧データ)</param>
		/// <param name="cancelCndtinDiv">キャンセル状態区分(0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定)</param>
		/// <param name="pMAcptAnOdrStatus">PM受注ステータス(10：見積 20:受注 30:売上 40:出荷)</param>
		/// <param name="pMSalesSlipNum">PM売上伝票番号(PMの売上伝票番号)</param>
		/// <param name="pMSalesRowNo">PM売上行番号</param>
		/// <param name="dtlTakeinDivCd">明細取込区分(0:未取込 1:取込済)</param>
		/// <param name="pmWarehouseCd">PM倉庫コード</param>
		/// <param name="pmWarehouseName">PM倉庫名称</param>
		/// <param name="pmShelfNo">PM棚番</param>
		/// <param name="pmPrsntCount">PM現在個数</param>
		/// <param name="setPartsMkrCd">セット部品メーカーコード</param>
		/// <param name="setPartsNumber">セット部品番号</param>
		/// <param name="setPartsMainSubNo">セット部品親子番号(0:親,1-*:子)</param>
		/// <returns>ScmOdDtInqクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, Int16 cancelCndtinDiv, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, Int32 dtlTakeinDivCd, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo,Double pmPrsntCount,Int32 setPartsMkrCd,string setPartsNumber,Int32 setPartsMainSubNo)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqRowNumber = inqRowNumber;
			this._inqRowNumDerivedNo = inqRowNumDerivedNo;
			this._inqOrgDtlDiscGuid = inqOrgDtlDiscGuid;
			this._inqOthDtlDiscGuid = inqOthDtlDiscGuid;
			this._goodsDivCd = goodsDivCd;
			this._recyclePrtKindCode = recyclePrtKindCode;
			this._recyclePrtKindName = recyclePrtKindName;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._handleDivCode = handleDivCode;
			this._goodsShape = goodsShape;
			this._delivrdGdsConfCd = delivrdGdsConfCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._answerDeliveryDate = answerDeliveryDate;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsDrCode = bLGoodsDrCode;
			this._inqGoodsName = inqGoodsName;
			this._ansGoodsName = ansGoodsName;
			this._salesOrderCount = salesOrderCount;
			this._deliveredGoodsCount = deliveredGoodsCount;
			this._goodsNo = goodsNo;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsMakerNm = goodsMakerNm;
			this._pureGoodsMakerCd = pureGoodsMakerCd;
			this._inqPureGoodsNo = inqPureGoodsNo;
			this._ansPureGoodsNo = ansPureGoodsNo;
			this._listPrice = listPrice;
			this._unitPrice = unitPrice;
			this._goodsAddInfo = goodsAddInfo;
			this._roughRrofit = roughRrofit;
			this._roughRate = roughRate;
			this.AnswerLimitDate = answerLimitDate;
			this._commentDtl = commentDtl;
			this._shelfNo = shelfNo;
			this._additionalDivCd = additionalDivCd;
			this._correctDivCD = correctDivCD;
			this._inqOrdDivCd = inqOrdDivCd;
			this._displayOrder = displayOrder;
			this._latestDiscCode = latestDiscCode;
			this._cancelCndtinDiv = cancelCndtinDiv;
			this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
			this._pMSalesSlipNum = pMSalesSlipNum;
			this._pMSalesRowNo = pMSalesRowNo;
			this._dtlTakeinDivCd = dtlTakeinDivCd;
			this._pmWarehouseCd = pmWarehouseCd;
			this._pmWarehouseName = pmWarehouseName;
			this._pmShelfNo = pmShelfNo;
			this._pmPrsntCount = pmPrsntCount;
			this._setPartsMkrCd = setPartsMkrCd;
			this._setPartsNumber = setPartsNumber;
			this._setPartsMainSubNo = setPartsMainSubNo;

		}

		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）複製処理
		/// </summary>
		/// <returns>ScmOdDtInqクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいScmOdDtInqクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ScmOdDtInq Clone()
		{
			return new ScmOdDtInq(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._inqOriginalEpCd,this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._inquiryNumber,this._updateDate,this._updateTime,this._inqRowNumber,this._inqRowNumDerivedNo,this._inqOrgDtlDiscGuid,this._inqOthDtlDiscGuid,this._goodsDivCd,this._recyclePrtKindCode,this._recyclePrtKindName,this._deliveredGoodsDiv,this._handleDivCode,this._goodsShape,this._delivrdGdsConfCd,this._deliGdsCmpltDueDate,this._answerDeliveryDate,this._bLGoodsCode,this._bLGoodsDrCode,this._inqGoodsName,this._ansGoodsName,this._salesOrderCount,this._deliveredGoodsCount,this._goodsNo,this._goodsMakerCd,this._goodsMakerNm,this._pureGoodsMakerCd,this._inqPureGoodsNo,this._ansPureGoodsNo,this._listPrice,this._unitPrice,this._goodsAddInfo,this._roughRrofit,this._roughRate,this._answerLimitDate,this._commentDtl,this._shelfNo,this._additionalDivCd,this._correctDivCD,this._inqOrdDivCd,this._displayOrder,this._latestDiscCode,this._cancelCndtinDiv,this._pMAcptAnOdrStatus,this._pMSalesSlipNum,this._pMSalesRowNo,this._dtlTakeinDivCd,this._pmWarehouseCd,this._pmWarehouseName,this._pmShelfNo,this._pmPrsntCount,this._setPartsMkrCd,this._setPartsNumber,this._setPartsMainSubNo);
		}

		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdDtInqクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ScmOdDtInq target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqRowNumber == target.InqRowNumber)
				 && (this.InqRowNumDerivedNo == target.InqRowNumDerivedNo)
				 && (this.InqOrgDtlDiscGuid == target.InqOrgDtlDiscGuid)
				 && (this.InqOthDtlDiscGuid == target.InqOthDtlDiscGuid)
				 && (this.GoodsDivCd == target.GoodsDivCd)
				 && (this.RecyclePrtKindCode == target.RecyclePrtKindCode)
				 && (this.RecyclePrtKindName == target.RecyclePrtKindName)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.HandleDivCode == target.HandleDivCode)
				 && (this.GoodsShape == target.GoodsShape)
				 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.AnswerDeliveryDate == target.AnswerDeliveryDate)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsDrCode == target.BLGoodsDrCode)
				 && (this.InqGoodsName == target.InqGoodsName)
				 && (this.AnsGoodsName == target.AnsGoodsName)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsMakerNm == target.GoodsMakerNm)
				 && (this.PureGoodsMakerCd == target.PureGoodsMakerCd)
				 && (this.InqPureGoodsNo == target.InqPureGoodsNo)
				 && (this.AnsPureGoodsNo == target.AnsPureGoodsNo)
				 && (this.ListPrice == target.ListPrice)
				 && (this.UnitPrice == target.UnitPrice)
				 && (this.GoodsAddInfo == target.GoodsAddInfo)
				 && (this.RoughRrofit == target.RoughRrofit)
				 && (this.RoughRate == target.RoughRate)
				 && (this.AnswerLimitDate == target.AnswerLimitDate)
				 && (this.CommentDtl == target.CommentDtl)
				 && (this.ShelfNo == target.ShelfNo)
				 && (this.AdditionalDivCd == target.AdditionalDivCd)
				 && (this.CorrectDivCD == target.CorrectDivCD)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.CancelCndtinDiv == target.CancelCndtinDiv)
				 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
				 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
				 && (this.PMSalesRowNo == target.PMSalesRowNo)
				 && (this.DtlTakeinDivCd == target.DtlTakeinDivCd)
				 && (this.PmWarehouseCd == target.PmWarehouseCd)
				 && (this.PmWarehouseName == target.PmWarehouseName)
				 && (this.PmShelfNo == target.PmShelfNo)
				 && (this.PmPrsntCount == target.PmPrsntCount)
				 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
				 && (this.SetPartsNumber == target.SetPartsNumber)
				 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo));
		}

		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）比較処理
		/// </summary>
		/// <param name="scmOdDtInq1">
		///                    比較するScmOdDtInqクラスのインスタンス
		/// </param>
		/// <param name="scmOdDtInq2">比較するScmOdDtInqクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			return ((scmOdDtInq1.CreateDateTime == scmOdDtInq2.CreateDateTime)
				 && (scmOdDtInq1.UpdateDateTime == scmOdDtInq2.UpdateDateTime)
				 && (scmOdDtInq1.LogicalDeleteCode == scmOdDtInq2.LogicalDeleteCode)
				 && (scmOdDtInq1.InqOriginalEpCd == scmOdDtInq2.InqOriginalEpCd)
				 && (scmOdDtInq1.InqOriginalSecCd == scmOdDtInq2.InqOriginalSecCd)
				 && (scmOdDtInq1.InqOtherEpCd == scmOdDtInq2.InqOtherEpCd)
				 && (scmOdDtInq1.InqOtherSecCd == scmOdDtInq2.InqOtherSecCd)
				 && (scmOdDtInq1.InquiryNumber == scmOdDtInq2.InquiryNumber)
				 && (scmOdDtInq1.UpdateDate == scmOdDtInq2.UpdateDate)
				 && (scmOdDtInq1.UpdateTime == scmOdDtInq2.UpdateTime)
				 && (scmOdDtInq1.InqRowNumber == scmOdDtInq2.InqRowNumber)
				 && (scmOdDtInq1.InqRowNumDerivedNo == scmOdDtInq2.InqRowNumDerivedNo)
				 && (scmOdDtInq1.InqOrgDtlDiscGuid == scmOdDtInq2.InqOrgDtlDiscGuid)
				 && (scmOdDtInq1.InqOthDtlDiscGuid == scmOdDtInq2.InqOthDtlDiscGuid)
				 && (scmOdDtInq1.GoodsDivCd == scmOdDtInq2.GoodsDivCd)
				 && (scmOdDtInq1.RecyclePrtKindCode == scmOdDtInq2.RecyclePrtKindCode)
				 && (scmOdDtInq1.RecyclePrtKindName == scmOdDtInq2.RecyclePrtKindName)
				 && (scmOdDtInq1.DeliveredGoodsDiv == scmOdDtInq2.DeliveredGoodsDiv)
				 && (scmOdDtInq1.HandleDivCode == scmOdDtInq2.HandleDivCode)
				 && (scmOdDtInq1.GoodsShape == scmOdDtInq2.GoodsShape)
				 && (scmOdDtInq1.DelivrdGdsConfCd == scmOdDtInq2.DelivrdGdsConfCd)
				 && (scmOdDtInq1.DeliGdsCmpltDueDate == scmOdDtInq2.DeliGdsCmpltDueDate)
				 && (scmOdDtInq1.AnswerDeliveryDate == scmOdDtInq2.AnswerDeliveryDate)
				 && (scmOdDtInq1.BLGoodsCode == scmOdDtInq2.BLGoodsCode)
				 && (scmOdDtInq1.BLGoodsDrCode == scmOdDtInq2.BLGoodsDrCode)
				 && (scmOdDtInq1.InqGoodsName == scmOdDtInq2.InqGoodsName)
				 && (scmOdDtInq1.AnsGoodsName == scmOdDtInq2.AnsGoodsName)
				 && (scmOdDtInq1.SalesOrderCount == scmOdDtInq2.SalesOrderCount)
				 && (scmOdDtInq1.DeliveredGoodsCount == scmOdDtInq2.DeliveredGoodsCount)
				 && (scmOdDtInq1.GoodsNo == scmOdDtInq2.GoodsNo)
				 && (scmOdDtInq1.GoodsMakerCd == scmOdDtInq2.GoodsMakerCd)
				 && (scmOdDtInq1.GoodsMakerNm == scmOdDtInq2.GoodsMakerNm)
				 && (scmOdDtInq1.PureGoodsMakerCd == scmOdDtInq2.PureGoodsMakerCd)
				 && (scmOdDtInq1.InqPureGoodsNo == scmOdDtInq2.InqPureGoodsNo)
				 && (scmOdDtInq1.AnsPureGoodsNo == scmOdDtInq2.AnsPureGoodsNo)
				 && (scmOdDtInq1.ListPrice == scmOdDtInq2.ListPrice)
				 && (scmOdDtInq1.UnitPrice == scmOdDtInq2.UnitPrice)
				 && (scmOdDtInq1.GoodsAddInfo == scmOdDtInq2.GoodsAddInfo)
				 && (scmOdDtInq1.RoughRrofit == scmOdDtInq2.RoughRrofit)
				 && (scmOdDtInq1.RoughRate == scmOdDtInq2.RoughRate)
				 && (scmOdDtInq1.AnswerLimitDate == scmOdDtInq2.AnswerLimitDate)
				 && (scmOdDtInq1.CommentDtl == scmOdDtInq2.CommentDtl)
				 && (scmOdDtInq1.ShelfNo == scmOdDtInq2.ShelfNo)
				 && (scmOdDtInq1.AdditionalDivCd == scmOdDtInq2.AdditionalDivCd)
				 && (scmOdDtInq1.CorrectDivCD == scmOdDtInq2.CorrectDivCD)
				 && (scmOdDtInq1.InqOrdDivCd == scmOdDtInq2.InqOrdDivCd)
				 && (scmOdDtInq1.DisplayOrder == scmOdDtInq2.DisplayOrder)
				 && (scmOdDtInq1.LatestDiscCode == scmOdDtInq2.LatestDiscCode)
				 && (scmOdDtInq1.CancelCndtinDiv == scmOdDtInq2.CancelCndtinDiv)
				 && (scmOdDtInq1.PMAcptAnOdrStatus == scmOdDtInq2.PMAcptAnOdrStatus)
				 && (scmOdDtInq1.PMSalesSlipNum == scmOdDtInq2.PMSalesSlipNum)
				 && (scmOdDtInq1.PMSalesRowNo == scmOdDtInq2.PMSalesRowNo)
				 && (scmOdDtInq1.DtlTakeinDivCd == scmOdDtInq2.DtlTakeinDivCd)
				 && (scmOdDtInq1.PmWarehouseCd == scmOdDtInq2.PmWarehouseCd)
				 && (scmOdDtInq1.PmWarehouseName == scmOdDtInq2.PmWarehouseName)
				 && (scmOdDtInq1.PmShelfNo == scmOdDtInq2.PmShelfNo)
				 && (scmOdDtInq1.PmPrsntCount == scmOdDtInq2.PmPrsntCount)
				 && (scmOdDtInq1.SetPartsMkrCd == scmOdDtInq2.SetPartsMkrCd)
				 && (scmOdDtInq1.SetPartsNumber == scmOdDtInq2.SetPartsNumber)
				 && (scmOdDtInq1.SetPartsMainSubNo == scmOdDtInq2.SetPartsMainSubNo));
		}
		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）比較処理
		/// </summary>
		/// <param name="target">比較対象のScmOdDtInqクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ScmOdDtInq target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.InqRowNumber != target.InqRowNumber) resList.Add("InqRowNumber");
			if (this.InqRowNumDerivedNo != target.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
			if (this.InqOrgDtlDiscGuid != target.InqOrgDtlDiscGuid) resList.Add("InqOrgDtlDiscGuid");
			if (this.InqOthDtlDiscGuid != target.InqOthDtlDiscGuid) resList.Add("InqOthDtlDiscGuid");
			if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
			if (this.RecyclePrtKindCode != target.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
			if (this.RecyclePrtKindName != target.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
			if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
			if (this.HandleDivCode != target.HandleDivCode) resList.Add("HandleDivCode");
			if (this.GoodsShape != target.GoodsShape) resList.Add("GoodsShape");
			if (this.DelivrdGdsConfCd != target.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
			if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
			if (this.AnswerDeliveryDate != target.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
			if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
			if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
			if (this.InqGoodsName != target.InqGoodsName) resList.Add("InqGoodsName");
			if (this.AnsGoodsName != target.AnsGoodsName) resList.Add("AnsGoodsName");
			if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
			if (this.DeliveredGoodsCount != target.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
			if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
			if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
			if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
			if (this.PureGoodsMakerCd != target.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
			if (this.InqPureGoodsNo != target.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
			if (this.AnsPureGoodsNo != target.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
			if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
			if (this.UnitPrice != target.UnitPrice) resList.Add("UnitPrice");
			if (this.GoodsAddInfo != target.GoodsAddInfo) resList.Add("GoodsAddInfo");
			if (this.RoughRrofit != target.RoughRrofit) resList.Add("RoughRrofit");
			if (this.RoughRate != target.RoughRate) resList.Add("RoughRate");
			if (this.AnswerLimitDate != target.AnswerLimitDate) resList.Add("AnswerLimitDate");
			if (this.CommentDtl != target.CommentDtl) resList.Add("CommentDtl");
			if (this.ShelfNo != target.ShelfNo) resList.Add("ShelfNo");
			if (this.AdditionalDivCd != target.AdditionalDivCd) resList.Add("AdditionalDivCd");
			if (this.CorrectDivCD != target.CorrectDivCD) resList.Add("CorrectDivCD");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.CancelCndtinDiv != target.CancelCndtinDiv) resList.Add("CancelCndtinDiv");
			if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
			if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
			if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
			if (this.DtlTakeinDivCd != target.DtlTakeinDivCd) resList.Add("DtlTakeinDivCd");
			if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
			if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
			if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
			if(this.PmPrsntCount != target.PmPrsntCount)resList.Add("PmPrsntCount");
			if(this.SetPartsMkrCd != target.SetPartsMkrCd)resList.Add("SetPartsMkrCd");
			if(this.SetPartsNumber != target.SetPartsNumber)resList.Add("SetPartsNumber");
			if(this.SetPartsMainSubNo != target.SetPartsMainSubNo)resList.Add("SetPartsMainSubNo");

			return resList;
		}

		/// <summary>
		/// SCM受発注明細データ（問合せ・発注）比較処理
		/// </summary>
		/// <param name="scmOdDtInq1">比較するScmOdDtInqクラスのインスタンス</param>
		/// <param name="scmOdDtInq2">比較するScmOdDtInqクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ScmOdDtInqクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdDtInq1.CreateDateTime != scmOdDtInq2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmOdDtInq1.UpdateDateTime != scmOdDtInq2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmOdDtInq1.LogicalDeleteCode != scmOdDtInq2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmOdDtInq1.InqOriginalEpCd != scmOdDtInq2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdDtInq1.InqOriginalSecCd != scmOdDtInq2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdDtInq1.InqOtherEpCd != scmOdDtInq2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdDtInq1.InqOtherSecCd != scmOdDtInq2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdDtInq1.InquiryNumber != scmOdDtInq2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdDtInq1.UpdateDate != scmOdDtInq2.UpdateDate) resList.Add("UpdateDate");
			if (scmOdDtInq1.UpdateTime != scmOdDtInq2.UpdateTime) resList.Add("UpdateTime");
			if (scmOdDtInq1.InqRowNumber != scmOdDtInq2.InqRowNumber) resList.Add("InqRowNumber");
			if (scmOdDtInq1.InqRowNumDerivedNo != scmOdDtInq2.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
			if (scmOdDtInq1.InqOrgDtlDiscGuid != scmOdDtInq2.InqOrgDtlDiscGuid) resList.Add("InqOrgDtlDiscGuid");
			if (scmOdDtInq1.InqOthDtlDiscGuid != scmOdDtInq2.InqOthDtlDiscGuid) resList.Add("InqOthDtlDiscGuid");
			if (scmOdDtInq1.GoodsDivCd != scmOdDtInq2.GoodsDivCd) resList.Add("GoodsDivCd");
			if (scmOdDtInq1.RecyclePrtKindCode != scmOdDtInq2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
			if (scmOdDtInq1.RecyclePrtKindName != scmOdDtInq2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
			if (scmOdDtInq1.DeliveredGoodsDiv != scmOdDtInq2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
			if (scmOdDtInq1.HandleDivCode != scmOdDtInq2.HandleDivCode) resList.Add("HandleDivCode");
			if (scmOdDtInq1.GoodsShape != scmOdDtInq2.GoodsShape) resList.Add("GoodsShape");
			if (scmOdDtInq1.DelivrdGdsConfCd != scmOdDtInq2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
			if (scmOdDtInq1.DeliGdsCmpltDueDate != scmOdDtInq2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
			if (scmOdDtInq1.AnswerDeliveryDate != scmOdDtInq2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
			if (scmOdDtInq1.BLGoodsCode != scmOdDtInq2.BLGoodsCode) resList.Add("BLGoodsCode");
			if (scmOdDtInq1.BLGoodsDrCode != scmOdDtInq2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
			if (scmOdDtInq1.InqGoodsName != scmOdDtInq2.InqGoodsName) resList.Add("InqGoodsName");
			if (scmOdDtInq1.AnsGoodsName != scmOdDtInq2.AnsGoodsName) resList.Add("AnsGoodsName");
			if (scmOdDtInq1.SalesOrderCount != scmOdDtInq2.SalesOrderCount) resList.Add("SalesOrderCount");
			if (scmOdDtInq1.DeliveredGoodsCount != scmOdDtInq2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
			if (scmOdDtInq1.GoodsNo != scmOdDtInq2.GoodsNo) resList.Add("GoodsNo");
			if (scmOdDtInq1.GoodsMakerCd != scmOdDtInq2.GoodsMakerCd) resList.Add("GoodsMakerCd");
			if (scmOdDtInq1.GoodsMakerNm != scmOdDtInq2.GoodsMakerNm) resList.Add("GoodsMakerNm");
			if (scmOdDtInq1.PureGoodsMakerCd != scmOdDtInq2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
			if (scmOdDtInq1.InqPureGoodsNo != scmOdDtInq2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
			if (scmOdDtInq1.AnsPureGoodsNo != scmOdDtInq2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
			if (scmOdDtInq1.ListPrice != scmOdDtInq2.ListPrice) resList.Add("ListPrice");
			if (scmOdDtInq1.UnitPrice != scmOdDtInq2.UnitPrice) resList.Add("UnitPrice");
			if (scmOdDtInq1.GoodsAddInfo != scmOdDtInq2.GoodsAddInfo) resList.Add("GoodsAddInfo");
			if (scmOdDtInq1.RoughRrofit != scmOdDtInq2.RoughRrofit) resList.Add("RoughRrofit");
			if (scmOdDtInq1.RoughRate != scmOdDtInq2.RoughRate) resList.Add("RoughRate");
			if (scmOdDtInq1.AnswerLimitDate != scmOdDtInq2.AnswerLimitDate) resList.Add("AnswerLimitDate");
			if (scmOdDtInq1.CommentDtl != scmOdDtInq2.CommentDtl) resList.Add("CommentDtl");
			if (scmOdDtInq1.ShelfNo != scmOdDtInq2.ShelfNo) resList.Add("ShelfNo");
			if (scmOdDtInq1.AdditionalDivCd != scmOdDtInq2.AdditionalDivCd) resList.Add("AdditionalDivCd");
			if (scmOdDtInq1.CorrectDivCD != scmOdDtInq2.CorrectDivCD) resList.Add("CorrectDivCD");
			if (scmOdDtInq1.InqOrdDivCd != scmOdDtInq2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (scmOdDtInq1.DisplayOrder != scmOdDtInq2.DisplayOrder) resList.Add("DisplayOrder");
			if (scmOdDtInq1.LatestDiscCode != scmOdDtInq2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdDtInq1.CancelCndtinDiv != scmOdDtInq2.CancelCndtinDiv) resList.Add("CancelCndtinDiv");
			if (scmOdDtInq1.PMAcptAnOdrStatus != scmOdDtInq2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
			if (scmOdDtInq1.PMSalesSlipNum != scmOdDtInq2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
			if (scmOdDtInq1.PMSalesRowNo != scmOdDtInq2.PMSalesRowNo) resList.Add("PMSalesRowNo");
			if (scmOdDtInq1.DtlTakeinDivCd != scmOdDtInq2.DtlTakeinDivCd) resList.Add("DtlTakeinDivCd");
			if (scmOdDtInq1.PmWarehouseCd != scmOdDtInq2.PmWarehouseCd) resList.Add("PmWarehouseCd");
			if (scmOdDtInq1.PmWarehouseName != scmOdDtInq2.PmWarehouseName) resList.Add("PmWarehouseName");
			if (scmOdDtInq1.PmShelfNo != scmOdDtInq2.PmShelfNo) resList.Add("PmShelfNo");
			if(scmOdDtInq1.PmPrsntCount != scmOdDtInq2.PmPrsntCount)resList.Add("PmPrsntCount");
			if(scmOdDtInq1.SetPartsMkrCd != scmOdDtInq2.SetPartsMkrCd)resList.Add("SetPartsMkrCd");
			if(scmOdDtInq1.SetPartsNumber != scmOdDtInq2.SetPartsNumber)resList.Add("SetPartsNumber");
			if(scmOdDtInq1.SetPartsMainSubNo != scmOdDtInq2.SetPartsMainSubNo)resList.Add("SetPartsMainSubNo");

			return resList;
		}
	}
}
